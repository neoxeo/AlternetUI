// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>

#pragma once

#include "Control.h"
#include "Font.h"
#include "DrawingContext.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Control* Control_GetParentRefCounted_(Control* obj)
{
    return MarshalExceptions<Control*>([&](){
            return obj->GetParentRefCounted();
        });
}

ALTERNET_UI_API Size_C Control_GetSize_(Control* obj)
{
    return MarshalExceptions<Size_C>([&](){
            return obj->GetSize();
        });
}

ALTERNET_UI_API void Control_SetSize_(Control* obj, Size value)
{
    MarshalExceptions<void>([&](){
            obj->SetSize(value);
        });
}

ALTERNET_UI_API Point_C Control_GetLocation_(Control* obj)
{
    return MarshalExceptions<Point_C>([&](){
            return obj->GetLocation();
        });
}

ALTERNET_UI_API void Control_SetLocation_(Control* obj, Point value)
{
    MarshalExceptions<void>([&](){
            obj->SetLocation(value);
        });
}

ALTERNET_UI_API Rect_C Control_GetBounds_(Control* obj)
{
    return MarshalExceptions<Rect_C>([&](){
            return obj->GetBounds();
        });
}

ALTERNET_UI_API void Control_SetBounds_(Control* obj, Rect value)
{
    MarshalExceptions<void>([&](){
            obj->SetBounds(value);
        });
}

ALTERNET_UI_API Size_C Control_GetClientSize_(Control* obj)
{
    return MarshalExceptions<Size_C>([&](){
            return obj->GetClientSize();
        });
}

ALTERNET_UI_API void Control_SetClientSize_(Control* obj, Size value)
{
    MarshalExceptions<void>([&](){
            obj->SetClientSize(value);
        });
}

ALTERNET_UI_API Thickness_C Control_GetIntrinsicLayoutPadding_(Control* obj)
{
    return MarshalExceptions<Thickness_C>([&](){
            return obj->GetIntrinsicLayoutPadding();
        });
}

ALTERNET_UI_API Thickness_C Control_GetIntrinsicPreferredSizePadding_(Control* obj)
{
    return MarshalExceptions<Thickness_C>([&](){
            return obj->GetIntrinsicPreferredSizePadding();
        });
}

ALTERNET_UI_API c_bool Control_GetVisible_(Control* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetVisible();
        });
}

ALTERNET_UI_API void Control_SetVisible_(Control* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetVisible(value);
        });
}

ALTERNET_UI_API c_bool Control_GetEnabled_(Control* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetEnabled();
        });
}

ALTERNET_UI_API void Control_SetEnabled_(Control* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetEnabled(value);
        });
}

ALTERNET_UI_API c_bool Control_GetUserPaint_(Control* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetUserPaint();
        });
}

ALTERNET_UI_API void Control_SetUserPaint_(Control* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetUserPaint(value);
        });
}

ALTERNET_UI_API c_bool Control_GetIsMouseOver_(Control* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetIsMouseOver();
        });
}

ALTERNET_UI_API c_bool Control_GetHasWindowCreated_(Control* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetHasWindowCreated();
        });
}

ALTERNET_UI_API Color_C Control_GetBackgroundColor_(Control* obj)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetBackgroundColor();
        });
}

ALTERNET_UI_API void Control_SetBackgroundColor_(Control* obj, Color value)
{
    MarshalExceptions<void>([&](){
            obj->SetBackgroundColor(value);
        });
}

ALTERNET_UI_API Color_C Control_GetForegroundColor_(Control* obj)
{
    return MarshalExceptions<Color_C>([&](){
            return obj->GetForegroundColor();
        });
}

ALTERNET_UI_API void Control_SetForegroundColor_(Control* obj, Color value)
{
    MarshalExceptions<void>([&](){
            obj->SetForegroundColor(value);
        });
}

ALTERNET_UI_API Font* Control_GetFont_(Control* obj)
{
    return MarshalExceptions<Font*>([&](){
            return obj->GetFont();
        });
}

ALTERNET_UI_API void Control_SetFont_(Control* obj, Font* value)
{
    MarshalExceptions<void>([&](){
            obj->SetFont(value);
        });
}

ALTERNET_UI_API c_bool Control_GetIsMouseCaptured_(Control* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetIsMouseCaptured();
        });
}

ALTERNET_UI_API void* Control_GetHandle_(Control* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetHandle();
        });
}

ALTERNET_UI_API void Control_SetMouseCapture_(Control* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetMouseCapture(value);
        });
}

ALTERNET_UI_API void Control_AddChild_(Control* obj, Control* control)
{
    MarshalExceptions<void>([&](){
            obj->AddChild(control);
        });
}

ALTERNET_UI_API void Control_RemoveChild_(Control* obj, Control* control)
{
    MarshalExceptions<void>([&](){
            obj->RemoveChild(control);
        });
}

ALTERNET_UI_API void Control_Invalidate_(Control* obj)
{
    MarshalExceptions<void>([&](){
            obj->Invalidate();
        });
}

ALTERNET_UI_API void Control_Update_(Control* obj)
{
    MarshalExceptions<void>([&](){
            obj->Update();
        });
}

ALTERNET_UI_API Size_C Control_GetPreferredSize_(Control* obj, Size availableSize)
{
    return MarshalExceptions<Size_C>([&](){
            return obj->GetPreferredSize(availableSize);
        });
}

ALTERNET_UI_API DrawingContext* Control_OpenPaintDrawingContext_(Control* obj)
{
    return MarshalExceptions<DrawingContext*>([&](){
            return obj->OpenPaintDrawingContext();
        });
}

ALTERNET_UI_API DrawingContext* Control_OpenClientDrawingContext_(Control* obj)
{
    return MarshalExceptions<DrawingContext*>([&](){
            return obj->OpenClientDrawingContext();
        });
}

ALTERNET_UI_API void Control_BeginUpdate_(Control* obj)
{
    MarshalExceptions<void>([&](){
            obj->BeginUpdate();
        });
}

ALTERNET_UI_API void Control_EndUpdate_(Control* obj)
{
    MarshalExceptions<void>([&](){
            obj->EndUpdate();
        });
}

ALTERNET_UI_API Control* Control_GetFocusedControl_()
{
    return MarshalExceptions<Control*>([&](){
            return Control::GetFocusedControl();
        });
}

ALTERNET_UI_API Control* Control_HitTest_(Point screenPoint)
{
    return MarshalExceptions<Control*>([&](){
            return Control::HitTest(screenPoint);
        });
}

ALTERNET_UI_API Point_C Control_ClientToScreen_(Control* obj, Point point)
{
    return MarshalExceptions<Point_C>([&](){
            return obj->ClientToScreen(point);
        });
}

ALTERNET_UI_API Point_C Control_ScreenToClient_(Control* obj, Point point)
{
    return MarshalExceptions<Point_C>([&](){
            return obj->ScreenToClient(point);
        });
}

ALTERNET_UI_API c_bool Control_Focus_(Control* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->Focus();
        });
}

ALTERNET_UI_API void Control_BeginInit_(Control* obj)
{
    MarshalExceptions<void>([&](){
            obj->BeginInit();
        });
}

ALTERNET_UI_API void Control_EndInit_(Control* obj)
{
    MarshalExceptions<void>([&](){
            obj->EndInit();
        });
}

ALTERNET_UI_API void Control_Destroy_(Control* obj)
{
    MarshalExceptions<void>([&](){
            obj->Destroy();
        });
}

ALTERNET_UI_API void Control_SaveScreenshot_(Control* obj, const char16_t* fileName)
{
    MarshalExceptions<void>([&](){
            obj->SaveScreenshot(fileName);
        });
}

ALTERNET_UI_API void Control_SetEventCallback_(Control::ControlEventCallbackType callback)
{
    Control::SetEventCallback(callback);
}

