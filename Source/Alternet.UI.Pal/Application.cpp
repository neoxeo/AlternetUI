#include "Application.h"
#include "Common.h"
#include "Window.h"
#include "Image.h"
#include "Exceptions.h"
#include "wx/sysopt.h"

IMPLEMENT_APP_NO_MAIN(Alternet::UI::App);
IMPLEMENT_WX_THEME_SUPPORT;

namespace Alternet::UI
{
    App::App()
    {
    }

    wxWindow* App::GetTopWindow() const
    {
        //return wxApp::GetTopWindow();
        
        wxWindow* window = m_topWindow;

        // If there is no top window or it is about to be destroyed,
        // we need to search for the first TLW which is not pending delete
        if (!window || wxPendingDelete.Member(window))
        {
            window = NULL;
            wxWindowList::compatibility_iterator node = wxTopLevelWindows.GetFirst();
            while (node)
            {
                wxWindow* win = node->GetData();
                if (!wxPendingDelete.Member(win))
                {
                    //if (win->IsShownOnScreen())
                    {
                        window = win;
                        break;
                    }
                }
                node = node->GetNext();
            }
        }

        return window;
    }

    bool App::OnInit()
    {
#if defined(__WXGTK__)
        wxApp::GTKAllowDiagnosticsControl();
#endif
#ifdef _DEBUG
        wxLog::SetActiveTarget(new wxAlternetLog());
        wxLog::GetActiveTarget()->SetFormatter(new wxAlternetLogFormatter());
#endif
        return wxApp::OnInit();
    }

    int App::OnExit()
    {
        return wxApp::OnExit();
    }

    void App::Run()
    {
        wxApp::OnRun();
    }

    void App::OnFatalException()
    {
        if (_owner != nullptr)
            _owner->OnFatalException();
        wxApp::OnFatalException();
    }

    void App::OnAssertFailure(const wxChar* file, int line, const wxChar* func,
        const wxChar* cond, const wxChar* msg)
    {
        if (_owner != nullptr)
            _owner->OnAssertFailure(file, line, func, cond, msg);
        wxApp::OnAssertFailure(file, line, func, cond, msg);
    }

    void App::OnUnhandledException()
    {
        if (_owner != nullptr)
            _owner->OnUnhandledException();
        wxApp::OnUnhandledException();
    }

    bool App::OnExceptionInMainLoop()
    {
        if (_owner != nullptr)
            _owner->OnExceptionInMainLoop();
        return wxApp::OnExceptionInMainLoop();
    }

/*

wxDEFINE_EVENT( wxEVT_LEFT_DOWN, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_LEFT_UP, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_MIDDLE_DOWN, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_MIDDLE_UP, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_RIGHT_DOWN, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_RIGHT_UP, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_MOTION, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_ENTER_WINDOW, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_LEAVE_WINDOW, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_LEFT_DCLICK, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_MIDDLE_DCLICK, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_RIGHT_DCLICK, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_SET_FOCUS, wxFocusEvent );
wxDEFINE_EVENT( wxEVT_KILL_FOCUS, wxFocusEvent );
wxDEFINE_EVENT( wxEVT_CHILD_FOCUS, wxChildFocusEvent );
wxDEFINE_EVENT( wxEVT_MOUSEWHEEL, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_AUX1_DOWN, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_AUX1_UP, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_AUX1_DCLICK, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_AUX2_DOWN, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_AUX2_UP, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_AUX2_DCLICK, wxMouseEvent );
wxDEFINE_EVENT( wxEVT_MAGNIFY, wxMouseEvent );
*/
    void App::ProcessMouseEvent(wxMouseEvent& e, bool& handled)
    {
        auto eventType = e.GetEventType();

        if (eventType == wxEVT_MOTION)
        {
            _owner->GetMouseInternal()->OnMouseMove(e, handled);
            return;
        }      

        if (eventType == wxEVT_MOUSEWHEEL)
            _owner->GetMouseInternal()->OnMouseWheel(e, handled);
        else if (eventType == wxEVT_LEFT_DOWN)
        {
            _owner->GetMouseInternal()->OnMouseDown(e, MouseButton::Left, handled);
        }
        else if (eventType == wxEVT_MIDDLE_DOWN)
            _owner->GetMouseInternal()->OnMouseDown(e, MouseButton::Middle, handled);
        else if (eventType == wxEVT_RIGHT_DOWN)
            _owner->GetMouseInternal()->OnMouseDown(e, MouseButton::Right, handled);
        else if (eventType == wxEVT_AUX1_DOWN)
            _owner->GetMouseInternal()->OnMouseDown(
                e, MouseButton::XButton1, handled);
        else if (eventType == wxEVT_AUX2_DOWN)
            _owner->GetMouseInternal()->OnMouseDown(
                e, MouseButton::XButton2, handled);
        else if (eventType == wxEVT_LEFT_UP)
        {
            _owner->GetMouseInternal()->OnMouseUp(e, MouseButton::Left, handled);
        }
        else if (eventType == wxEVT_MIDDLE_UP)
            _owner->GetMouseInternal()->OnMouseUp(e, MouseButton::Middle, handled);
        else if (eventType == wxEVT_RIGHT_UP)
            _owner->GetMouseInternal()->OnMouseUp(e, MouseButton::Right, handled);
        else if (eventType == wxEVT_AUX1_UP)
            _owner->GetMouseInternal()->OnMouseUp(e, MouseButton::XButton1, handled);
        else if (eventType == wxEVT_AUX2_UP)
            _owner->GetMouseInternal()->OnMouseUp(e, MouseButton::XButton2, handled);
        else if (eventType == wxEVT_LEFT_DCLICK)
            _owner->GetMouseInternal()->OnMouseDoubleClick(
                e, MouseButton::Left, handled);
        else if (eventType == wxEVT_MIDDLE_DCLICK)
            _owner->GetMouseInternal()->OnMouseDoubleClick(
                e, MouseButton::Middle, handled);
        else if (eventType == wxEVT_RIGHT_DCLICK)
            _owner->GetMouseInternal()->OnMouseDoubleClick(
                e, MouseButton::Right, handled);
        else if (eventType == wxEVT_AUX1_DCLICK)
            _owner->GetMouseInternal()->OnMouseDoubleClick(
                e, MouseButton::XButton1, handled);
        else if (eventType == wxEVT_AUX2_DCLICK)
            _owner->GetMouseInternal()->OnMouseDoubleClick(
                e, MouseButton::XButton2, handled);
    }

/*
wxDEFINE_EVENT( wxEVT_CHAR, wxKeyEvent );
wxDEFINE_EVENT( wxEVT_AFTER_CHAR, wxKeyEvent );
wxDEFINE_EVENT( wxEVT_CHAR_HOOK, wxKeyEvent );
wxDEFINE_EVENT( wxEVT_NAVIGATION_KEY, wxNavigationKeyEvent );
wxDEFINE_EVENT( wxEVT_KEY_DOWN, wxKeyEvent );
wxDEFINE_EVENT( wxEVT_KEY_UP, wxKeyEvent );
#if wxUSE_HOTKEY
wxDEFINE_EVENT( wxEVT_HOTKEY, wxKeyEvent );
#endif
*/
    void App::ProcessKeyEvent(wxKeyEvent& e, bool& handled)
    {
        auto eventType = e.GetEventType();
        if (eventType == wxEVT_KEY_UP)
            _owner->GetKeyboardInternal()->OnKeyUp(e, handled);
        else if (eventType == wxEVT_KEY_DOWN)
        {
#ifndef __WXOSX_COCOA__            
            // For some reason, on Windows and Linux wxEVT_CHAR_HOOK are not sent
            // when mouse capture is active.
            if (wxWindow::GetCapture() != nullptr)
                _owner->GetKeyboardInternal()->OnKeyDown(e, handled);
#endif                
        }
        else if (eventType == wxEVT_CHAR_HOOK)
            _owner->GetKeyboardInternal()->OnKeyDown(e, handled);
        else if (eventType == wxEVT_CHAR)
            _owner->GetKeyboardInternal()->OnChar(e, handled);
    }

    int App::FilterEvent(wxEvent& e)
    {
        if (_owner == nullptr)
            return Event_Skip;

        auto category = e.GetEventCategory();

        if(category != wxEVT_CATEGORY_USER_INPUT)
            return Event_Skip;

        bool handled = false;

        auto eventType = e.GetEventType();

        if (eventType >= wxEVT_LEFT_DOWN && eventType <= wxEVT_MAGNIFY)
            ProcessMouseEvent((wxMouseEvent&)e, handled);
        else
        if (eventType >= wxEVT_CHAR && eventType <= wxEVT_KEY_UP)
            ProcessKeyEvent((wxKeyEvent&)e, handled);

        return handled ? Event_Processed : Event_Skip;
    }

    void App::SetOwner(Application* value)
    {
        _owner = value;
    }

    //-----------------

    void IdleCallback()
    {
        Application::GetCurrent()->RaiseIdle();
    }

    Application::Application()
    {
        Image::EnsureImageHandlersInitialized();

        if (s_current != nullptr)
            throwExInvalidOpWithInfo(wxStr("Application::Application"));
        s_current = this;

#ifdef __WXMSW__    
        windowsVisualThemeSupportCookie = WindowsVisualThemeSupport::GetInstance().Enable();
#endif

        char b[] = "";
        char* argv[] = { b };
        int argc = 1;
        wxEntryStart(argc, argv);
        wxTheApp->CallOnInit();

        _keyboard = new Keyboard();
        _mouse = new Mouse();
        _clipboard = new Clipboard();

        _app = static_cast<App*>(wxTheApp);
        _app->SetOwner(this);

        ParkingWindow::SetIdleCallback(IdleCallback);
    }

    void Application::SuppressDiagnostics(int flags)
    {
#if defined(__WXGTK__)
        wxApp::GTKSuppressDiagnostics(flags);
#endif
    }

    Application::~Application()
    {
        s_current = nullptr;

        _keyboard->Release();
        _keyboard = nullptr;

        _mouse->Release();
        _mouse = nullptr;

        _clipboard->Release();
        _clipboard = nullptr;
    }

    void* Application::GetDisplayMode()
    {
        return nullptr;
    }

    bool Application::GetExitOnFrameDelete()
    {
        return _app->GetExitOnFrameDelete();
    }

    int Application::GetLayoutDirection()
    {
        return _app->GetLayoutDirection();
    }

    bool Application::GetUseBestVisual()
    {
        return _app->GetUseBestVisual();
    }

    bool Application::IsActive()
    {
        return _app->IsActive();
    }

    bool Application::SafeYield(void* window, bool onlyIfNeeded)
    {
        return _app->SafeYield((wxWindow*)window, onlyIfNeeded);
    }

    bool Application::SafeYieldFor(void* window, int64_t eventsToProcess)
    {
        return _app->SafeYieldFor((wxWindow*)window, eventsToProcess);
    }

    bool Application::SetDisplayMode(void* videoMode)
    {
        return false;
    }

    void Application::SetExitOnFrameDelete(bool flag)
    {
        _app->SetExitOnFrameDelete(flag);
    }

    bool Application::SetNativeTheme(const string& theme)
    {
        return _app->SetNativeTheme(wxStr(theme));
    }

    void Application::SetTopWindow(void* window)
    {
        _app->SetTopWindow((wxWindow*)window);
    }

    void Application::SetUseBestVisual(bool flag, bool forceTrueColour)
    {
        _app->SetUseBestVisual(flag, forceTrueColour);
    }

    void Application::WakeUpIdle()
    {
        _app->WakeUpIdle();
    }

    void* Application::GetTopWindow()
    {
        return _app->GetTopWindow();
    }

    void Application::ExitMainLoop()
    {
        _app->ExitMainLoop();
    }

    void Application::Exit()
    {
        _app->Exit();
    }

    bool Application::GetInUixmlPreviewerMode()
    {
        return _inUixmlPreviewerMode;
    }

    void Application::SetInUixmlPreviewerMode(bool value)
    {
        _inUixmlPreviewerMode = value;
    }

    string Application::GetDisplayName() 
    {
        return wxStr(_app->GetAppDisplayName());
    }

    void Application::SetDisplayName(const string& value) 
    {
        _app->SetAppDisplayName(wxStr(value));
    }

    string Application::GetAppClassName() 
    {
        return wxStr(_app->GetClassName());
    }
    void Application::SetAppClassName(const string& value)
    {
        _app->SetClassName(wxStr(value));
    }

    string Application::GetVendorName()
    {
        return wxStr(_app->GetVendorName());
    }

    void Application::SetVendorName(const string& value)
    {
        _app->SetVendorName(wxStr(value));
    }

    string Application::GetVendorDisplayName()
    {
        return wxStr(_app->GetVendorDisplayName());
    }

    void Application::SetVendorDisplayName(const string& value)
    {
        _app->SetVendorDisplayName(wxStr(value));
    }

    string Application::GetName()
    {
        return wxStr(_app->GetAppName());
    }

    void Application::SetName(const string& value)
    {
        _app->SetAppName(wxStr(value));
    }

    void Application::RaiseIdle()
    {
        RaiseEvent(ApplicationEvent::Idle);
    }

    Clipboard* Application::GetClipboard()
    {
        _clipboard->AddRef();
        return _clipboard;
    }

    Mouse* Application::GetMouse()
    {
        _mouse->AddRef();
        return _mouse;
    }

    Keyboard* Application::GetKeyboard()
    {
        _keyboard->AddRef();
        return _keyboard;
    }


    bool Application::GetInvokeRequired()
    {
        return !wxThread::IsMain();
    }

    void Application::BeginInvoke(PInvokeCallbackActionType action)
    {
        ParkingWindow::GetWindow()->CallAfter([=]() { action(); });
    }

    Mouse* Application::GetMouseInternal()
    {
        return _mouse;
    }

    Keyboard* Application::GetKeyboardInternal()
    {
        return _keyboard;
    }

    string Application::GetEventArgString()
    {
        return _eventArgString;
    }

    void Application::Log(wxString msg)
    {
        Log(wxStr(msg));
    }

    void Application::Log(string msg)
    {
        GetCurrent()->_eventArgString = msg;
        GetCurrent()->RaiseEvent(ApplicationEvent::LogMessage);
    }

    void Application::DoLogRecord(wxLogLevel level /*unsigned long*/, const wxString& msg,
        const wxLogRecordInfo& info)
    {
        _eventArgString = wxStr(msg);
        RaiseEvent(ApplicationEvent::LogMessage);
    }

    /*static*/ Application* Application::GetCurrent()
    {
        return s_current;
    }

    void Application::SetSystemOptionInt(const string& name, int value)
    {
        wxSystemOptions::SetOption(wxStr(name), value);
    }

    void Application::ProcessPendingEvents()
    {
        _app->ProcessPendingEvents();
    }

    bool Application::HasPendingEvents()
    {
        return _app->HasPendingEvents();
    }

    void Application::ThrowError(int value)
    {
        throw value;
    }

    void Application::Run(Window* window)
    {
        verifyNonNull(window);

#ifdef __WXMSW__
        if (!WindowsVisualThemeSupport::GetInstance().IsEnabled())
            windowsVisualThemeSupportCookie = WindowsVisualThemeSupport::GetInstance().Enable();
#endif

        _app->Run();

#ifdef __WXMSW__
        if (WindowsVisualThemeSupport::GetInstance().IsEnabled())
            WindowsVisualThemeSupport::GetInstance().Disable(windowsVisualThemeSupportCookie);
#endif
    }

    bool Application::OnFatalException()
    {
        Application::Log("Error: Fatal Exception");
        RaiseEvent(ApplicationEvent::FatalException);
        return false;
    }

    bool Application::OnAssertFailure(const wxChar* file, int line, const wxChar* func,
        const wxChar* cond, const wxChar* msg)
    {
        RaiseEvent(ApplicationEvent::AssertFailure);
        return false;
    }

    bool Application::OnUnhandledException()
    {
        Application::Log("Error: Unhandled Exception");
        RaiseEvent(ApplicationEvent::UnhandledException);
        return false;
    }

    bool Application::OnExceptionInMainLoop()
    {
        Application::Log("Error: Exception In Main Loop");
        RaiseEvent(ApplicationEvent::ExceptionInMainLoop);
        return false;
    }
}