// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "Control.h"
#include "Font.h"
#include "UnmanagedDataObject.h"
#include "DrawingContext.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API c_bool Control_GetProcessIdle_(Control* obj)
{
    return obj->GetProcessIdle();
}

ALTERNET_UI_API void Control_SetProcessIdle_(Control* obj, c_bool value)
{
    obj->SetProcessIdle(value);
}

ALTERNET_UI_API c_bool Control_GetProcessUIUpdates_(Control* obj)
{
    return obj->GetProcessUIUpdates();
}

ALTERNET_UI_API void Control_SetProcessUIUpdates_(Control* obj, c_bool value)
{
    obj->SetProcessUIUpdates(value);
}

ALTERNET_UI_API c_bool Control_GetIsBold_(Control* obj)
{
    return obj->GetIsBold();
}

ALTERNET_UI_API void Control_SetIsBold_(Control* obj, c_bool value)
{
    obj->SetIsBold(value);
}

ALTERNET_UI_API c_bool Control_GetAcceptsFocus_(Control* obj)
{
    return obj->GetAcceptsFocus();
}

ALTERNET_UI_API void Control_SetAcceptsFocus_(Control* obj, c_bool value)
{
    obj->SetAcceptsFocus(value);
}

ALTERNET_UI_API c_bool Control_GetAcceptsFocusFromKeyboard_(Control* obj)
{
    return obj->GetAcceptsFocusFromKeyboard();
}

ALTERNET_UI_API void Control_SetAcceptsFocusFromKeyboard_(Control* obj, c_bool value)
{
    obj->SetAcceptsFocusFromKeyboard(value);
}

ALTERNET_UI_API c_bool Control_GetAcceptsFocusRecursively_(Control* obj)
{
    return obj->GetAcceptsFocusRecursively();
}

ALTERNET_UI_API void Control_SetAcceptsFocusRecursively_(Control* obj, c_bool value)
{
    obj->SetAcceptsFocusRecursively(value);
}

ALTERNET_UI_API c_bool Control_GetAcceptsFocusAll_(Control* obj)
{
    return obj->GetAcceptsFocusAll();
}

ALTERNET_UI_API void Control_SetAcceptsFocusAll_(Control* obj, c_bool value)
{
    obj->SetAcceptsFocusAll(value);
}

ALTERNET_UI_API int Control_GetBorderStyle_(Control* obj)
{
    return obj->GetBorderStyle();
}

ALTERNET_UI_API void Control_SetBorderStyle_(Control* obj, int value)
{
    obj->SetBorderStyle(value);
}

ALTERNET_UI_API int Control_GetLayoutDirection_(Control* obj)
{
    return obj->GetLayoutDirection();
}

ALTERNET_UI_API void Control_SetLayoutDirection_(Control* obj, int value)
{
    obj->SetLayoutDirection(value);
}

ALTERNET_UI_API char16_t* Control_GetName_(Control* obj)
{
    return AllocPInvokeReturnString(obj->GetName());
}

ALTERNET_UI_API void Control_SetName_(Control* obj, const char16_t* value)
{
    obj->SetName(value);
}

ALTERNET_UI_API int Control_GetId_(Control* obj)
{
    return obj->GetId();
}

ALTERNET_UI_API void Control_SetId_(Control* obj, int value)
{
    obj->SetId(value);
}

ALTERNET_UI_API c_bool Control_GetIsActive_(Control* obj)
{
    return obj->GetIsActive();
}

ALTERNET_UI_API c_bool Control_GetIsHandleCreated_(Control* obj)
{
    return obj->GetIsHandleCreated();
}

ALTERNET_UI_API c_bool Control_GetIsWxWidgetCreated_(Control* obj)
{
    return obj->GetIsWxWidgetCreated();
}

ALTERNET_UI_API void* Control_GetHandle_(Control* obj)
{
    return obj->GetHandle();
}

ALTERNET_UI_API void* Control_GetWxWidget_(Control* obj)
{
    return obj->GetWxWidget();
}

ALTERNET_UI_API c_bool Control_GetIsScrollable_(Control* obj)
{
    return obj->GetIsScrollable();
}

ALTERNET_UI_API void Control_SetIsScrollable_(Control* obj, c_bool value)
{
    obj->SetIsScrollable(value);
}

ALTERNET_UI_API c_bool Control_GetIsMouseCaptured_(Control* obj)
{
    return obj->GetIsMouseCaptured();
}

ALTERNET_UI_API c_bool Control_GetTabStop_(Control* obj)
{
    return obj->GetTabStop();
}

ALTERNET_UI_API void Control_SetTabStop_(Control* obj, c_bool value)
{
    obj->SetTabStop(value);
}

ALTERNET_UI_API c_bool Control_GetIsFocused_(Control* obj)
{
    return obj->GetIsFocused();
}

ALTERNET_UI_API c_bool Control_GetIsFocusable_(Control* obj)
{
    return obj->GetIsFocusable();
}

ALTERNET_UI_API c_bool Control_GetCanAcceptFocus_(Control* obj)
{
    return obj->GetCanAcceptFocus();
}

ALTERNET_UI_API Control* Control_GetParentRefCounted_(Control* obj)
{
    return obj->GetParentRefCounted();
}

ALTERNET_UI_API char16_t* Control_GetToolTip_(Control* obj)
{
    return AllocPInvokeReturnString(obj->GetToolTip());
}

ALTERNET_UI_API void Control_SetToolTip_(Control* obj, const char16_t* value)
{
    obj->SetToolTip(ToOptional(value));
}

ALTERNET_UI_API c_bool Control_GetAllowDrop_(Control* obj)
{
    return obj->GetAllowDrop();
}

ALTERNET_UI_API void Control_SetAllowDrop_(Control* obj, c_bool value)
{
    obj->SetAllowDrop(value);
}

ALTERNET_UI_API SizeD_C Control_GetSize_(Control* obj)
{
    return obj->GetSize();
}

ALTERNET_UI_API void Control_SetSize_(Control* obj, SizeD value)
{
    obj->SetSize(value);
}

ALTERNET_UI_API PointD_C Control_GetLocation_(Control* obj)
{
    return obj->GetLocation();
}

ALTERNET_UI_API void Control_SetLocation_(Control* obj, PointD value)
{
    obj->SetLocation(value);
}

ALTERNET_UI_API RectD_C Control_GetBounds_(Control* obj)
{
    return obj->GetBounds();
}

ALTERNET_UI_API void Control_SetBounds_(Control* obj, RectD value)
{
    obj->SetBounds(value);
}

ALTERNET_UI_API SizeD_C Control_GetClientSize_(Control* obj)
{
    return obj->GetClientSize();
}

ALTERNET_UI_API void Control_SetClientSize_(Control* obj, SizeD value)
{
    obj->SetClientSize(value);
}

ALTERNET_UI_API Thickness_C Control_GetIntrinsicLayoutPadding_(Control* obj)
{
    return obj->GetIntrinsicLayoutPadding();
}

ALTERNET_UI_API Thickness_C Control_GetIntrinsicPreferredSizePadding_(Control* obj)
{
    return obj->GetIntrinsicPreferredSizePadding();
}

ALTERNET_UI_API c_bool Control_GetVisible_(Control* obj)
{
    return obj->GetVisible();
}

ALTERNET_UI_API void Control_SetVisible_(Control* obj, c_bool value)
{
    obj->SetVisible(value);
}

ALTERNET_UI_API c_bool Control_GetEnabled_(Control* obj)
{
    return obj->GetEnabled();
}

ALTERNET_UI_API void Control_SetEnabled_(Control* obj, c_bool value)
{
    obj->SetEnabled(value);
}

ALTERNET_UI_API c_bool Control_GetUserPaint_(Control* obj)
{
    return obj->GetUserPaint();
}

ALTERNET_UI_API void Control_SetUserPaint_(Control* obj, c_bool value)
{
    obj->SetUserPaint(value);
}

ALTERNET_UI_API c_bool Control_GetIsMouseOver_(Control* obj)
{
    return obj->GetIsMouseOver();
}

ALTERNET_UI_API c_bool Control_GetHasWindowCreated_(Control* obj)
{
    return obj->GetHasWindowCreated();
}

ALTERNET_UI_API Color_C Control_GetBackgroundColor_(Control* obj)
{
    return obj->GetBackgroundColor();
}

ALTERNET_UI_API void Control_SetBackgroundColor_(Control* obj, Color value)
{
    obj->SetBackgroundColor(value);
}

ALTERNET_UI_API Color_C Control_GetForegroundColor_(Control* obj)
{
    return obj->GetForegroundColor();
}

ALTERNET_UI_API void Control_SetForegroundColor_(Control* obj, Color value)
{
    obj->SetForegroundColor(value);
}

ALTERNET_UI_API Font* Control_GetFont_(Control* obj)
{
    return obj->GetFont();
}

ALTERNET_UI_API void Control_SetFont_(Control* obj, Font* value)
{
    obj->SetFont(value);
}

ALTERNET_UI_API SizeD_C Control_GetMinimumSize_(Control* obj)
{
    return obj->GetMinimumSize();
}

ALTERNET_UI_API void Control_SetMinimumSize_(Control* obj, SizeD value)
{
    obj->SetMinimumSize(value);
}

ALTERNET_UI_API SizeD_C Control_GetMaximumSize_(Control* obj)
{
    return obj->GetMaximumSize();
}

ALTERNET_UI_API void Control_SetMaximumSize_(Control* obj, SizeD value)
{
    obj->SetMaximumSize(value);
}

ALTERNET_UI_API int Control_GetScrollBarLargeChange_(Control* obj, ScrollBarOrientation orientation)
{
    return obj->GetScrollBarLargeChange(orientation);
}

ALTERNET_UI_API int Control_GetScrollBarMaximum_(Control* obj, ScrollBarOrientation orientation)
{
    return obj->GetScrollBarMaximum(orientation);
}

ALTERNET_UI_API int Control_GetScrollBarEvtKind_(Control* obj)
{
    return obj->GetScrollBarEvtKind();
}

ALTERNET_UI_API int Control_GetScrollBarEvtPosition_(Control* obj)
{
    return obj->GetScrollBarEvtPosition();
}

ALTERNET_UI_API Control* Control_HitTest_(PointD screenPoint)
{
    return Control::HitTest(screenPoint);
}

ALTERNET_UI_API Control* Control_GetFocusedControl_()
{
    return Control::GetFocusedControl();
}

ALTERNET_UI_API void Control_NotifyCaptureLost_()
{
    Control::NotifyCaptureLost();
}

ALTERNET_UI_API void Control_Freeze_(Control* obj)
{
    obj->Freeze();
}

ALTERNET_UI_API void Control_Thaw_(Control* obj)
{
    obj->Thaw();
}

ALTERNET_UI_API void Control_ShowPopupMenu_(Control* obj, void* menu, double x, double y)
{
    obj->ShowPopupMenu(menu, x, y);
}

ALTERNET_UI_API void Control_BeginIgnoreRecreate_(Control* obj)
{
    obj->BeginIgnoreRecreate();
}

ALTERNET_UI_API void Control_EndIgnoreRecreate_(Control* obj)
{
    obj->EndIgnoreRecreate();
}

ALTERNET_UI_API SizeD_C Control_GetDPI_(Control* obj)
{
    return obj->GetDPI();
}

ALTERNET_UI_API void Control_SetMouseCapture_(Control* obj, c_bool value)
{
    obj->SetMouseCapture(value);
}

ALTERNET_UI_API void Control_AddChild_(Control* obj, Control* control)
{
    obj->AddChild(control);
}

ALTERNET_UI_API void Control_RemoveChild_(Control* obj, Control* control)
{
    obj->RemoveChild(control);
}

ALTERNET_UI_API void Control_Invalidate_(Control* obj)
{
    obj->Invalidate();
}

ALTERNET_UI_API void Control_Update_(Control* obj)
{
    obj->Update();
}

ALTERNET_UI_API SizeD_C Control_GetPreferredSize_(Control* obj, SizeD availableSize)
{
    return obj->GetPreferredSize(availableSize);
}

ALTERNET_UI_API DragDropEffects Control_DoDragDrop_(Control* obj, UnmanagedDataObject* data, DragDropEffects allowedEffects)
{
    return obj->DoDragDrop(data, allowedEffects);
}

ALTERNET_UI_API DrawingContext* Control_OpenPaintDrawingContext_(Control* obj)
{
    return obj->OpenPaintDrawingContext();
}

ALTERNET_UI_API DrawingContext* Control_OpenClientDrawingContext_(Control* obj)
{
    return obj->OpenClientDrawingContext();
}

ALTERNET_UI_API void Control_BeginUpdate_(Control* obj)
{
    obj->BeginUpdate();
}

ALTERNET_UI_API void Control_EndUpdate_(Control* obj)
{
    obj->EndUpdate();
}

ALTERNET_UI_API void Control_RecreateWindow_(Control* obj)
{
    obj->RecreateWindow();
}

ALTERNET_UI_API void Control_ResetBackgroundColor_(Control* obj)
{
    obj->ResetBackgroundColor();
}

ALTERNET_UI_API void Control_ResetForegroundColor_(Control* obj)
{
    obj->ResetForegroundColor();
}

ALTERNET_UI_API PointD_C Control_ClientToScreen_(Control* obj, PointD point)
{
    return obj->ClientToScreen(point);
}

ALTERNET_UI_API PointD_C Control_ScreenToClient_(Control* obj, PointD point)
{
    return obj->ScreenToClient(point);
}

ALTERNET_UI_API PointI_C Control_ScreenToDevice_(Control* obj, PointD point)
{
    return obj->ScreenToDevice(point);
}

ALTERNET_UI_API PointD_C Control_DeviceToScreen_(Control* obj, PointI point)
{
    return obj->DeviceToScreen(point);
}

ALTERNET_UI_API c_bool Control_SetFocus_(Control* obj)
{
    return obj->SetFocus();
}

ALTERNET_UI_API void Control_FocusNextControl_(Control* obj, c_bool forward, c_bool nested)
{
    obj->FocusNextControl(forward, nested);
}

ALTERNET_UI_API void Control_BeginInit_(Control* obj)
{
    obj->BeginInit();
}

ALTERNET_UI_API void Control_EndInit_(Control* obj)
{
    obj->EndInit();
}

ALTERNET_UI_API void Control_Destroy_(Control* obj)
{
    obj->Destroy();
}

ALTERNET_UI_API void Control_SaveScreenshot_(Control* obj, const char16_t* fileName)
{
    obj->SaveScreenshot(fileName);
}

ALTERNET_UI_API void Control_SendSizeEvent_(Control* obj)
{
    obj->SendSizeEvent();
}

ALTERNET_UI_API void Control_SendMouseDownEvent_(Control* obj, int x, int y)
{
    obj->SendMouseDownEvent(x, y);
}

ALTERNET_UI_API void Control_SendMouseUpEvent_(Control* obj, int x, int y)
{
    obj->SendMouseUpEvent(x, y);
}

ALTERNET_UI_API void Control_SetBoundsEx_(Control* obj, RectD rect, int flags)
{
    obj->SetBoundsEx(rect, flags);
}

ALTERNET_UI_API void* Control_GetContainingSizer_(Control* obj)
{
    return obj->GetContainingSizer();
}

ALTERNET_UI_API void* Control_GetSizer_(Control* obj)
{
    return obj->GetSizer();
}

ALTERNET_UI_API void Control_SetSizer_(Control* obj, void* sizer, c_bool deleteOld)
{
    obj->SetSizer(sizer, deleteOld);
}

ALTERNET_UI_API void Control_SetSizerAndFit_(Control* obj, void* sizer, c_bool deleteOld)
{
    obj->SetSizerAndFit(sizer, deleteOld);
}

ALTERNET_UI_API void Control_SetScrollBar_(Control* obj, ScrollBarOrientation orientation, c_bool visible, int value, int largeChange, int maximum)
{
    obj->SetScrollBar(orientation, visible, value, largeChange, maximum);
}

ALTERNET_UI_API c_bool Control_IsScrollBarVisible_(Control* obj, ScrollBarOrientation orientation)
{
    return obj->IsScrollBarVisible(orientation);
}

ALTERNET_UI_API int Control_GetScrollBarValue_(Control* obj, ScrollBarOrientation orientation)
{
    return obj->GetScrollBarValue(orientation);
}

ALTERNET_UI_API void Control_CenterOnParent_(Control* obj, int orientation)
{
    obj->CenterOnParent(orientation);
}

ALTERNET_UI_API void Control_RefreshRect_(Control* obj, RectD rect, c_bool eraseBackground)
{
    obj->RefreshRect(rect, eraseBackground);
}

ALTERNET_UI_API void Control_Raise_(Control* obj)
{
    obj->Raise();
}

ALTERNET_UI_API void Control_Lower_(Control* obj)
{
    obj->Lower();
}

ALTERNET_UI_API void Control_DisableRecreate_(Control* obj)
{
    obj->DisableRecreate();
}

ALTERNET_UI_API void Control_EnableRecreate_(Control* obj)
{
    obj->EnableRecreate();
}

ALTERNET_UI_API void Control_UnsetToolTip_(Control* obj)
{
    obj->UnsetToolTip();
}

ALTERNET_UI_API c_bool Control_IsTransparentBackgroundSupported_(Control* obj)
{
    return obj->IsTransparentBackgroundSupported();
}

ALTERNET_UI_API c_bool Control_SetBackgroundStyle_(Control* obj, int style)
{
    return obj->SetBackgroundStyle(style);
}

ALTERNET_UI_API int Control_GetBackgroundStyle_(Control* obj)
{
    return obj->GetBackgroundStyle();
}

ALTERNET_UI_API void Control_AlwaysShowScrollbars_(Control* obj, c_bool hflag, c_bool vflag)
{
    obj->AlwaysShowScrollbars(hflag, vflag);
}

ALTERNET_UI_API Color_C Control_GetDefaultAttributesBgColor_(Control* obj)
{
    return obj->GetDefaultAttributesBgColor();
}

ALTERNET_UI_API Color_C Control_GetDefaultAttributesFgColor_(Control* obj)
{
    return obj->GetDefaultAttributesFgColor();
}

ALTERNET_UI_API Font* Control_GetDefaultAttributesFont_(Control* obj)
{
    return obj->GetDefaultAttributesFont();
}

ALTERNET_UI_API Color_C Control_GetClassDefaultAttributesBgColor_(int controlType, int windowVariant)
{
    return Control::GetClassDefaultAttributesBgColor(controlType, windowVariant);
}

ALTERNET_UI_API Color_C Control_GetClassDefaultAttributesFgColor_(int controlType, int windowVariant)
{
    return Control::GetClassDefaultAttributesFgColor(controlType, windowVariant);
}

ALTERNET_UI_API Font* Control_GetClassDefaultAttributesFont_(int controlType, int windowVariant)
{
    return Control::GetClassDefaultAttributesFont(controlType, windowVariant);
}

ALTERNET_UI_API int Control_DrawingFromDip_(double value, void* window)
{
    return Control::DrawingFromDip(value, window);
}

ALTERNET_UI_API double Control_DrawingDPIScaleFactor_(void* window)
{
    return Control::DrawingDPIScaleFactor(window);
}

ALTERNET_UI_API double Control_DrawingToDip_(int value, void* window)
{
    return Control::DrawingToDip(value, window);
}

ALTERNET_UI_API double Control_DrawingFromDipF_(double value, void* window)
{
    return Control::DrawingFromDipF(value, window);
}

ALTERNET_UI_API void Control_SetCursor_(Control* obj, void* handle)
{
    obj->SetCursor(handle);
}

ALTERNET_UI_API void Control_SetEventCallback_(Control::ControlEventCallbackType callback)
{
    Control::SetEventCallback(callback);
}

