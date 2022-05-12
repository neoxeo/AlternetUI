// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>

#pragma once

#include "Window.h"
#include "ImageSet.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Window* Window_Create_()
{
    return MarshalExceptions<Window*>([&](){
            return new Window();
        });
}

ALTERNET_UI_API char16_t* Window_GetTitle_(Window* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetTitle());
        });
}

ALTERNET_UI_API void Window_SetTitle_(Window* obj, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetTitle(value);
        });
}

ALTERNET_UI_API WindowStartPosition Window_GetWindowStartPosition_(Window* obj)
{
    return MarshalExceptions<WindowStartPosition>([&](){
            return obj->GetWindowStartPosition();
        });
}

ALTERNET_UI_API void Window_SetWindowStartPosition_(Window* obj, WindowStartPosition value)
{
    MarshalExceptions<void>([&](){
            obj->SetWindowStartPosition(value);
        });
}

ALTERNET_UI_API c_bool Window_GetShowInTaskbar_(Window* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetShowInTaskbar();
        });
}

ALTERNET_UI_API void Window_SetShowInTaskbar_(Window* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetShowInTaskbar(value);
        });
}

ALTERNET_UI_API c_bool Window_GetMinimizeEnabled_(Window* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetMinimizeEnabled();
        });
}

ALTERNET_UI_API void Window_SetMinimizeEnabled_(Window* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetMinimizeEnabled(value);
        });
}

ALTERNET_UI_API c_bool Window_GetMaximizeEnabled_(Window* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetMaximizeEnabled();
        });
}

ALTERNET_UI_API void Window_SetMaximizeEnabled_(Window* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetMaximizeEnabled(value);
        });
}

ALTERNET_UI_API c_bool Window_GetCloseEnabled_(Window* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetCloseEnabled();
        });
}

ALTERNET_UI_API void Window_SetCloseEnabled_(Window* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetCloseEnabled(value);
        });
}

ALTERNET_UI_API c_bool Window_GetAlwaysOnTop_(Window* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetAlwaysOnTop();
        });
}

ALTERNET_UI_API void Window_SetAlwaysOnTop_(Window* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetAlwaysOnTop(value);
        });
}

ALTERNET_UI_API c_bool Window_GetIsToolWindow_(Window* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetIsToolWindow();
        });
}

ALTERNET_UI_API void Window_SetIsToolWindow_(Window* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetIsToolWindow(value);
        });
}

ALTERNET_UI_API c_bool Window_GetResizable_(Window* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetResizable();
        });
}

ALTERNET_UI_API void Window_SetResizable_(Window* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetResizable(value);
        });
}

ALTERNET_UI_API c_bool Window_GetHasBorder_(Window* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetHasBorder();
        });
}

ALTERNET_UI_API void Window_SetHasBorder_(Window* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetHasBorder(value);
        });
}

ALTERNET_UI_API c_bool Window_GetHasTitleBar_(Window* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetHasTitleBar();
        });
}

ALTERNET_UI_API void Window_SetHasTitleBar_(Window* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetHasTitleBar(value);
        });
}

ALTERNET_UI_API c_bool Window_GetIsActive_(Window* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetIsActive();
        });
}

ALTERNET_UI_API Window* Window_GetActiveWindow_()
{
    return MarshalExceptions<Window*>([&](){
            return Window::GetActiveWindow();
        });
}

ALTERNET_UI_API WindowState Window_GetState_(Window* obj)
{
    return MarshalExceptions<WindowState>([&](){
            return obj->GetState();
        });
}

ALTERNET_UI_API void Window_SetState_(Window* obj, WindowState value)
{
    MarshalExceptions<void>([&](){
            obj->SetState(value);
        });
}

ALTERNET_UI_API ImageSet* Window_GetIcon_(Window* obj)
{
    return MarshalExceptions<ImageSet*>([&](){
            return obj->GetIcon();
        });
}

ALTERNET_UI_API void Window_SetIcon_(Window* obj, ImageSet* value)
{
    MarshalExceptions<void>([&](){
            obj->SetIcon(value);
        });
}

ALTERNET_UI_API void* Window_OpenOwnedWindowsArray_(Window* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->OpenOwnedWindowsArray();
        });
}

ALTERNET_UI_API int Window_GetOwnedWindowsItemCount_(Window* obj, void* array)
{
    return MarshalExceptions<int>([&](){
            return obj->GetOwnedWindowsItemCount(array);
        });
}

ALTERNET_UI_API Window* Window_GetOwnedWindowsItemAt_(Window* obj, void* array, int index)
{
    return MarshalExceptions<Window*>([&](){
            return obj->GetOwnedWindowsItemAt(array, index);
        });
}

ALTERNET_UI_API void Window_CloseOwnedWindowsArray_(Window* obj, void* array)
{
    MarshalExceptions<void>([&](){
            obj->CloseOwnedWindowsArray(array);
        });
}

ALTERNET_UI_API void Window_Activate_(Window* obj)
{
    MarshalExceptions<void>([&](){
            obj->Activate();
        });
}

ALTERNET_UI_API void Window_SetEventCallback_(Window::WindowEventCallbackType callback)
{
    Window::SetEventCallback(callback);
}

