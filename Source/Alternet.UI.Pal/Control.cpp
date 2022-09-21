#include "Control.h"
#include "Application.h"
#include "Screenshot.h"

namespace Alternet::UI
{
    /*static*/ Control::ControlsByWxWindowsMap Control::s_controlsByWxWindowsMap;

    Control::Control() :
        _flags(ControlFlags::None),
        _delayedFlags(
            *this,
            DelayedControlFlags::Visible,
            &Control::IsWxWindowCreated,
            {
                {DelayedControlFlags::Visible, std::make_tuple(&Control::RetrieveVisible, &Control::ApplyVisible)},
                {DelayedControlFlags::Frozen, std::make_tuple(&Control::RetrieveFrozen, &Control::ApplyFrozen)},
                {DelayedControlFlags::Enabled, std::make_tuple(&Control::RetrieveEnabled, &Control::ApplyEnabled)},
            }),
            _bounds(*this, Rect(), &Control::IsWxWindowCreated, &Control::RetrieveBounds, &Control::ApplyBounds),
            _backgroundColor(*this, Color(), &Control::IsWxWindowCreated, &Control::RetrieveBackgroundColor, &Control::ApplyBackgroundColor),
            _foregroundColor(*this, Color(), &Control::IsWxWindowCreated, &Control::RetrieveForegroundColor, &Control::ApplyForegroundColor),
            _delayedValues({&_delayedFlags, &_bounds, &_backgroundColor, &_foregroundColor})
    {
    }

    Control::~Control()
    {
        DestroyDropTarget();
        DestroyWxWindow();
    }

    void Control::Destroy()
    {
        DestroyWxWindow();
    }

    bool Control::GetHasWindowCreated()
    {
        return IsWxWindowCreated();
    }

    void* Control::GetHandle()
    {
#ifdef  __WXMSW__
        return GetWxWindow()->GetHWND();
#else
        return nullptr;
#endif
    }

    void Control::SaveScreenshot(const string& fileName)
    {
        UI::SaveScreenshot(GetWxWindow(), fileName);
    }

    void Control::OnDestroy(wxWindowDestroyEvent& event)
    {
        auto app = Application::GetCurrent();
        if (app == nullptr || app->GetInUixmlPreviewerMode())
            return; // HACK. This gets invoked by wxWidgets on a dead this pointer.

        if (!_flags.IsSet(ControlFlags::RecreatingWxWindow))
            _wxWindow = nullptr;

        auto wxWindow = event.GetWindow();

        wxWindow->Unbind(wxEVT_PAINT, &Control::OnPaint, this);
        //wxWindow->Unbind(wxEVT_ERASE_BACKGROUND, &Control::OnEraseBackground, this);
        wxWindow->Unbind(wxEVT_DESTROY, &Control::OnDestroy, this);
        wxWindow->Unbind(wxEVT_SHOW, &Control::OnVisibleChanged, this);
        wxWindow->Unbind(wxEVT_MOUSE_CAPTURE_LOST, &Control::OnMouseCaptureLost, this);
        wxWindow->Unbind(wxEVT_ENTER_WINDOW, &Control::OnMouseEnter, this);
        wxWindow->Unbind(wxEVT_LEAVE_WINDOW, &Control::OnMouseLeave, this);
        wxWindow->Unbind(wxEVT_SIZE, &Control::OnSizeChanged, this);

        RemoveWxWindowControlAssociation(wxWindow);

        OnWxWindowDestroyed(wxWindow);
        RaiseEvent(ControlEvent::Destroyed);

        if (_flags.IsSet(ControlFlags::RecreatingWxWindow))
            _flags.Set(ControlFlags::RecreatingWxWindow, false);
    }

    void Control::DestroyWxWindow()
    {
        if (_wxWindow != nullptr)
        {
            OnBeforeDestroyWxWindow();
            _wxWindow->Destroy();
            _wxWindow = nullptr;
        }
    }

    DrawingContext* Control::OpenPaintDrawingContext()
    {
        //auto dc = new wxAutoBufferedPaintDC(GetWxWindow());
        auto dc = new wxPaintDC(GetWxWindow());
        
        // // todo: work out a proper background brush solution (including transparency, patterns, etc)
        // auto oldBackground = dc->GetBackground();
        // dc->SetBackground(wxSystemSettings::GetColour(wxSystemColour::wxSYS_COLOUR_BTNFACE));
        // dc->Clear();
        // dc->SetBackground(oldBackground);

        return new DrawingContext(dc);
    }

    DrawingContext* Control::OpenClientDrawingContext()
    {
        return new DrawingContext(new wxClientDC(GetWxWindow()));
    }

    Control* Control::GetParent()
    {
        return _parent;
    }

    Control* Control::GetParentRefCounted()
    {
        if (_parent != nullptr)
            _parent->AddRef();
        return _parent;
    }

    void Control::BeginInit()
    {
        if (_flags.IsSet(ControlFlags::InitInProgress))
            throwExInvalidOp;

        _flags.Set(ControlFlags::InitInProgress, true);

        OnBeginInit();
    }

    void Control::EndInit()
    {
        if (!_flags.IsSet(ControlFlags::InitInProgress))
            throwExInvalidOp;

        _flags.Set(ControlFlags::InitInProgress, false);

        if (_flags.IsSet(ControlFlags::PostInitWxWindowRecreationPending))
        {
            RecreateWxWindowIfNeeded();
            _flags.Set(ControlFlags::PostInitWxWindowRecreationPending, false);
        }

        for (auto action : _postInitActions)
        {
            action();
        }

        _postInitActions.clear();

        OnEndInit();
    }

    void Control::OnBeginInit()
    {
    }

    void Control::OnEndInit()
    {
    }

    bool Control::IsInitInProgress()
    {
        return _flags.IsSet(ControlFlags::InitInProgress);
    }

    DragDropEffects Control::DoDragDrop(UnmanagedDataObject* data, DragDropEffects allowedEffects)
    {
        return DragDropEffects();
    }

    bool Control::GetAllowDrop()
    {
        return _dropTarget != nullptr;
    }

    void Control::SetAllowDrop(bool value)
    {
        if (value)
            CreateDropTarget();
        else
            DestroyDropTarget();
    }

    void Control::CreateDropTarget()
    {
        if (_dropTarget != nullptr)
            throwExNoInfo;

        _dropTarget = new DropTarget(this);
        GetWxWindow()->SetDropTarget(_dropTarget);
    }

    void Control::DestroyDropTarget()
    {
        if (_dropTarget != nullptr)
        {
            GetWxWindow()->SetDropTarget(nullptr);
            delete _dropTarget;
            _dropTarget = nullptr;
        }
    }

    wxWindow* Control::GetWxWindow()
    {
        if (_wxWindow == nullptr)
            CreateWxWindow();

        if (_wxWindow == nullptr)
            throwExInvalidOp;

        return _wxWindow;
    }

    void Control::Invalidate()
    {
        if (!IsWxWindowCreated())
            return;

        auto wxWindow = GetWxWindow();
        wxWindow->Refresh();
    }

    void Control::Update()
    {
        if (!IsWxWindowCreated())
            return;

        auto wxWindow = GetWxWindow();
        wxWindow->Update();
    }

    void Control::CreateWxWindow()
    {
        _flags.Set(ControlFlags::CreatingWxWindow, true);
        _flags.Set(ControlFlags::DestroyingWxWindow, false);
        wxWindow* parentingWxWindow = nullptr;
        if (_parent != nullptr)
            parentingWxWindow = _parent->GetParentingWxWindow(this);
        else
            parentingWxWindow = ParkingWindow::GetWindow();
        
        _wxWindow = CreateWxWindowCore(parentingWxWindow);

        if (GetUserPaint())
        {
            _wxWindow->SetDoubleBuffered(true);
            _wxWindow->SetBackgroundStyle(wxBG_STYLE_PAINT);
        }

        _wxWindow->Bind(wxEVT_PAINT, &Control::OnPaint, this);
        //_wxWindow->Bind(wxEVT_ERASE_BACKGROUND, &Control::OnEraseBackground, this);
        _wxWindow->Bind(wxEVT_DESTROY, &Control::OnDestroy, this);
        _wxWindow->Bind(wxEVT_SHOW, &Control::OnVisibleChanged, this);
        _wxWindow->Bind(wxEVT_MOUSE_CAPTURE_LOST, &Control::OnMouseCaptureLost, this);
        _wxWindow->Bind(wxEVT_ENTER_WINDOW, &Control::OnMouseEnter, this);
        _wxWindow->Bind(wxEVT_LEAVE_WINDOW, &Control::OnMouseLeave, this);
        _wxWindow->Bind(wxEVT_SIZE, &Control::OnSizeChanged, this);

        AssociateControlWithWxWindow(_wxWindow, this);

        OnWxWindowCreated();
        _delayedValues.ApplyIfPossible();

        _flags.Set(ControlFlags::CreatingWxWindow, false);

        for (auto child : _children)
            child->UpdateWxWindowParent();
    }

    void Control::RecreateWxWindowIfNeeded()
    {
        if (!IsWxWindowCreated())
            return;

        _flags.Set(ControlFlags::RecreatingWxWindow, true);
        DestroyWxWindow();
        CreateWxWindow();
    }

    void Control::OnWxWindowCreated()
    {
    }

    void Control::OnBeforeDestroyWxWindow()
    {
        _flags.Set(ControlFlags::DestroyingWxWindow, true);
        _delayedValues.ReceiveIfPossible();
    }

    void Control::OnWxWindowDestroyed(wxWindow* window)
    {
    }

    DelayedValues& Control::GetDelayedValues()
    {
        return _delayedValues;
    }

    bool Control::IsWxWindowCreated()
    {
        return _wxWindow != nullptr;
    }

    void Control::SetBackgroundColor(const Color& value)
    {
        _backgroundColor.Set(value);
    }

    Color Control::GetBackgroundColor()
    {
        return _backgroundColor.Get();
    }

    void Control::SetForegroundColor(const Color& value)
    {
        _foregroundColor.Set(value);
    }

    Color Control::GetForegroundColor()
    {
        return _foregroundColor.Get();
    }

    void Control::SetMouseCapture(bool value)
    {
        auto wxWindow = GetWxWindow();
        if (value)
        {
            if (!(wxWindow->HasCapture()))
                wxWindow->CaptureMouse();
        }
        else
        {
            if (wxWindow->HasCapture())
                wxWindow->ReleaseMouse();
        }
    }

    bool Control::GetIsMouseCaptured()
    {
        return GetWxWindow()->HasCapture();
    }

    bool Control::GetIsMouseOver()
    {
        auto wxWindow = GetWxWindow();

        wxPoint pt;
        auto window = wxFindWindowAtPointer(pt);
        while (window != nullptr)
        {
            if (window == wxWindow)
                return true;
            window = window->GetParent();
        }

        return false;
    }

    wxWindow* Control::GetParentingWxWindow(Control* child)
    {
        return GetWxWindow();
    }

    void Control::ScheduleRecreateWxWindow(std::function<void()> postRecreateAction)
    {
        if (!_flags.IsSet(ControlFlags::InitInProgress))
        {
            RecreateWxWindowIfNeeded();
            postRecreateAction();
            return;
        }

        _flags.Set(ControlFlags::PostInitWxWindowRecreationPending, true);

        _postInitActions.push_back([postRecreateAction]
            {
                postRecreateAction();
            });
    }

    void Control::ScheduleRecreateWxWindow()
    {
        ScheduleRecreateWxWindow([] {});
    }

    bool Control::RetrieveVisible()
    {
        return GetWxWindow()->IsShown();
    }

    void Control::ApplyVisible(bool value)
    {
        if (value)
            ShowCore();
        else
            HideCore();
    }

    void Control::ShowCore()
    {
        //if (Application::GetCurrent()->GetInUixmlPreviewerMode())
        //    return;

        GetWxWindow()->Show();
    }

    void Control::HideCore()
    {
        GetWxWindow()->Hide();
    }

    bool Control::IsDestroyingWxWindow()
    {
        return _flags.IsSet(ControlFlags::DestroyingWxWindow);
    }

    bool Control::IsRecreatingWxWindow()
    {
        return _flags.IsSet(ControlFlags::RecreatingWxWindow);
    }

    bool Control::RetrieveEnabled()
    {
        return GetWxWindow()->IsEnabled();
    }

    void Control::ApplyEnabled(bool value)
    {
        auto wxWindow = GetWxWindow();
        if (value)
            wxWindow->Enable();
        else
            wxWindow->Disable();
    }

    bool Control::RetrieveFrozen()
    {
        return GetWxWindow()->IsFrozen();
    }

    void Control::ApplyFrozen(bool value)
    {
        auto window = GetWxWindow();
        if (value)
        {
            if (!window->IsFrozen())
                window->Freeze();
        }
        else
        {
            if (window->IsFrozen())
                window->Thaw();
        }
    }

    Color Control::RetrieveBackgroundColor()
    {
#ifndef __WXMSW__
        // This is a workaround for non-Windows systems returning wrong background color when recreating a wxWindow.
        // For example, see ListBox on SelectionMode change.
        // Later this wrong color is reapplied to the recreated control. See also RetrieveForegroundColor().
        return _backgroundColor.GetDelayed();
#else
        return GetWxWindow()->GetBackgroundColour();
#endif
    }

    void Control::ApplyBackgroundColor(const Color& value)
    {
        if (!value.IsEmpty())
            GetWxWindow()->SetBackgroundColour(value);
    }

    Color Control::RetrieveForegroundColor()
    {
#ifndef __WXMSW__
        return _foregroundColor.GetDelayed();
#else
        return GetWxWindow()->GetForegroundColour();
#endif
    }

    void Control::ApplyForegroundColor(const Color& value)
    {
        if (!value.IsEmpty())
            GetWxWindow()->SetForegroundColour(value);
    }

    std::vector<Control*> Control::GetChildren()
    {
        return _children;
    }

    bool Control::GetDoNotDestroyWxWindow()
    {
        return _flags.IsSet(ControlFlags::DoNotDestroyWxWindow);
    }

    void Control::SetDoNotDestroyWxWindow(bool value)
    {
        _flags.Set(ControlFlags::DoNotDestroyWxWindow, value);
    }

    Font* Control::GetFont()
    {
        return nullptr;
    }

    void Control::SetFont(Font* value)
    {
    }

    void Control::BeginUpdate()
    {
        _beginUpdateCount++;
        if (_beginUpdateCount == 1)
        {
            _delayedFlags.Set(DelayedControlFlags::Frozen, true);
        }
    }

    void Control::EndUpdate()
    {
        if (_beginUpdateCount <= 0)
            throwEx(u"EndUpdate() without matching BeginUpdate()");

        _beginUpdateCount--;
        if (_beginUpdateCount == 0)
        {
            _delayedFlags.Set(DelayedControlFlags::Frozen, false);
        }
    }

    Size Control::GetClientSize()
    {
        if (!_flags.IsSet(ControlFlags::ClientSizeCacheValid))
        {
            _clientSizeCache = GetClientSizeCore();
            _flags.Set(ControlFlags::ClientSizeCacheValid, true);
        }

        return _clientSizeCache;
    }

    Size Control::GetClientSizeCore()
    {
        return SizeToClientSize(GetBounds().GetSize());
    }

    void Control::SetClientSize(const Size& value)
    {
        SetBounds(Rect(GetBounds().GetLocation(), ClientSizeToSize(value)));
    }

    Size Control::ClientSizeToSize(const Size& clientSize)
    {
        // todo: On Linux ClientSize is not reported correctly until the window is shown
        // See https://forums.wxwidgets.org/viewtopic.php?f=1&t=47439
        // So on Linux ClientSizeToSize and SizeToClientSize will return the input value
        // until the window is shown.

        auto window = GetWxWindow();
        return toDip(GetWxWindow()->ClientToWindowSize(fromDip(clientSize, window)), window);
    }

    Size Control::SizeToClientSize(const Size& size)
    {
        auto window = GetWxWindow();
        return toDip(GetWxWindow()->WindowToClientSize(fromDip(size, window)), window);
    }

    Thickness Control::GetIntrinsicLayoutPadding()
    {
        return Thickness();
    }

    Thickness Control::GetIntrinsicPreferredSizePadding()
    {
        return Thickness();
    }

    Rect Control::RetrieveBounds()
    {
        auto wxWindow = GetWxWindow();
        return toDip(wxWindow->GetRect(), wxWindow);
    }

    void Control::ApplyBounds(const Rect& value)
    {
        auto wxWindow = GetWxWindow();
        wxRect rect(fromDip(value, wxWindow));
        wxWindow->SetSize(rect);
        wxWindow->Refresh();
    }

    bool Control::EventsSuspended()
    {
        return _flags.IsSet(ControlFlags::CreatingWxWindow);
    }

    void Control::OnPaint(wxPaintEvent& event)
    {
        event.Skip();

        if (GetUserPaint())
        {
            wxPaintDC dc(GetWxWindow());
            
            auto background = GetBackgroundColor();
            wxColor color;
            if (background.IsEmpty())
                color = wxSystemSettings::GetColour(wxSystemColour::wxSYS_COLOUR_BTNFACE);
            else
                color = background;
            
            dc.SetBackground(wxBrush(color));
            dc.Clear();
        }

        RaiseEvent(ControlEvent::Paint);
    }

    void Control::OnEraseBackground(wxEraseEvent& event)
    {
    }

    void Control::OnMouseCaptureLost(wxEvent& event)
    {
        RaiseEvent(ControlEvent::MouseCaptureLost);
    }

    void Control::OnMouseEnter(wxMouseEvent& event)
    {
        RaiseEvent(ControlEvent::MouseEnter);

        auto window = GetParent();
        while (window != nullptr)
        {
            if (window->GetIsMouseOver())
                window->RaiseEvent(ControlEvent::MouseEnter);

            window = window->GetParent();
        }
    }

    void Control::OnMouseLeave(wxMouseEvent& event)
    {
        RaiseEvent(ControlEvent::MouseLeave);

        auto window = GetParent();
        while (window != nullptr)
        {
            if(!window->GetIsMouseOver())
                window->RaiseEvent(ControlEvent::MouseLeave);

            window = window->GetParent();
        }
    }

    void Control::OnVisibleChanged(wxShowEvent& event)
    {
        event.Skip();

        // For some reason this event is being called while destroying the window, despite the Unbind call prior to destruction.
        auto window = dynamic_cast<wxWindow*>(event.GetEventObject());
        if (window->IsBeingDeleted())
            return;

        RaiseEvent(ControlEvent::VisibleChanged);
    }

    void Control::OnSizeChanged(wxSizeEvent& event)
    {
        event.Skip();

        _flags.Set(ControlFlags::ClientSizeCacheValid, false);
    }

    void Control::UpdateWxWindowParent()
    {
        auto wxWindow = GetWxWindow();
        auto parkingWindow = ParkingWindow::GetWindow();

        auto parent = GetParent();
        if (parent == nullptr)
        {
            if (wxWindow->GetParent() != parkingWindow)
                SetWxWindowParent(parkingWindow);
        }
        else
        {
            auto parentWxWindow = parent->GetParentingWxWindow(this);
            auto oldParent = wxWindow->GetParent();
            if (oldParent != parentWxWindow)
                SetWxWindowParent(parentWxWindow);
        }
    }

    void Control::SetWxWindowParent(wxWindow* parent)
    {
        auto wxWindow = GetWxWindow();
        if (wxWindow != nullptr)
            wxWindow->Reparent(parent);
    }

    Size Control::GetSize()
    {
        return GetBounds().GetSize();
    }

    void Control::SetSize(const Size& value)
    {
        SetBounds(Rect(GetLocation(), value));
    }

    Point Control::GetLocation()
    {
        return GetBounds().GetLocation();
    }

    void Control::SetLocation(const Point& value)
    {
        SetBounds(Rect(value, GetSize()));
    }

    Rect Control::GetBounds()
    {
        return _bounds.Get();
    }

    void Control::SetBounds(const Rect& value)
    {
        _bounds.Set(value);
    }

    bool Control::GetVisible()
    {
        return _delayedFlags.Get(DelayedControlFlags::Visible);
    }

    void Control::SetVisible(bool value)
    {
        _delayedFlags.Set(DelayedControlFlags::Visible, value);
    }

    bool Control::GetEnabled()
    {
        return _delayedFlags.Get(DelayedControlFlags::Enabled);
    }

    void Control::SetEnabled(bool value)
    {
        _delayedFlags.Set(DelayedControlFlags::Enabled, value);
    }

    void Control::AddChild(Control* control)
    {
        verifyNonNull(control);

        _children.push_back(control);
        control->_parent = this;
        control->UpdateWxWindowParent();
    }

    void Control::RemoveChild(Control* control)
    {
        _children.erase(std::find(_children.begin(), _children.end(), control));
        control->_parent = nullptr;
        control->UpdateWxWindowParent();
    }

    Size Control::GetPreferredSize(const Size& availableSize)
    {
        auto wxWindow = GetWxWindow();
        return toDip(wxWindow->GetBestSize(), wxWindow);
    }

    /*static*/ Control* Control::TryFindControlByWxWindow(wxWindow* wxWindow)
    {
        ControlsByWxWindowsMap::const_iterator i = s_controlsByWxWindowsMap.find(wxWindow);
        return i == s_controlsByWxWindowsMap.end() ? NULL : i->second;
    }

    /*static*/ DragDropEffects Control::GetDragDropEffects(wxDragResult input)
    {
        switch (input)
        {
        case wxDragError:
        case wxDragNone:
        case wxDragCancel:
            return DragDropEffects::None;
        case wxDragCopy:
            return DragDropEffects::Copy;
        case wxDragMove:
            return DragDropEffects::Move;
        case wxDragLink:
            return DragDropEffects::Link;
        default:
            throwExNoInfo;
        }
    }

    wxDragResult Control::GetDragResult(DragDropEffects input)
    {
        switch (input)
        {
        case DragDropEffects::None:
            return wxDragResult::wxDragNone;
        case DragDropEffects::Copy:
            return wxDragResult::wxDragCopy;
        case DragDropEffects::Move:
            return wxDragResult::wxDragMove;
        case DragDropEffects::Link:
            return wxDragResult::wxDragLink;
        default:
            throwExNoInfo;
        }
    }

    wxDragResult Control::RaiseDragOver(const wxPoint& location, wxDragResult defaultDragResult, wxDataObjectComposite* dataObjectComposite)
    {
        auto clientPoint = toDip(location, GetWxWindow());

        DragEventData data =
        {
            new UnmanagedDataObject(dataObjectComposite) /*data*/,
            clientPoint.X /*mouseClientLocationX*/,
            clientPoint.Y /*mouseClientLocationY*/,
            GetDragDropEffects(defaultDragResult) /*effect*/,
        };

        return GetDragResult((DragDropEffects)(size_t)RaiseEventWithPointerResult(ControlEvent::DragOver, &data));
    }

    bool Control::GetUserPaint()
    {
        return _flags.IsSet(ControlFlags::UserPaint);
    }

    void Control::SetUserPaint(bool value)
    {
        _flags.Set(ControlFlags::UserPaint, value);
        RecreateWxWindowIfNeeded();
    }

    /*static*/ void Control::AssociateControlWithWxWindow(wxWindow* wxWindow, Control* control)
    {
        s_controlsByWxWindowsMap[wxWindow] = control;
    }

    /*static*/ void Control::RemoveWxWindowControlAssociation(wxWindow* wxWindow)
    {
        s_controlsByWxWindowsMap.erase(wxWindow);
    }

    /*static*/ Control* Control::HitTest(const Point& screenPoint)
    {
        auto window = wxFindWindowAtPoint(fromDip(screenPoint, nullptr));
        if (window == nullptr)
            return nullptr;
    
        auto control = TryFindControlByWxWindow(window);
        if (control != nullptr)
            control->AddRef();

        return control;
    }

    Point Control::ClientToScreen(const Point& point)
    {
        auto window = GetWxWindow();
        auto screenPixelPoint = window->ClientToScreen(fromDip(point, window));
        return toDip(screenPixelPoint, window);
    }

    Point Control::ScreenToClient(const Point& point)
    {
        auto window = GetWxWindow();
        auto screenClientPoint = window->ScreenToClient(fromDip(point, window));
        return toDip(screenClientPoint, window);
    }

    bool Control::Focus()
    {
        auto window = GetWxWindow();
        if (!window->AcceptsFocus() || !window->CanAcceptFocus() || !window->CanBeFocused())
            return false;

        window->SetFocus();
        return window->HasFocus();
    }

    /*static*/ Control* Control::GetFocusedControl()
    {
        auto focusedWxWindow = wxWindow::FindFocus();
        if (focusedWxWindow == nullptr)
            return nullptr;

        auto control = TryFindControlByWxWindow(focusedWxWindow);
        if (control != nullptr)
            control->AddRef();

        return control;
    }
}