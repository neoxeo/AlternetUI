// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2023 AlterNET Software.</auto-generated>

#pragma once

#include "Window.h"
#include "ImageSet.h"
#include "MainMenu.h"
#include "Toolbar.h"
#include "StatusBar.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Window* Window_Create_()
{
    return new Window();
}

ALTERNET_UI_API char16_t* Window_GetTitle_(Window* obj)
{
    return AllocPInvokeReturnString(obj->GetTitle());
}

ALTERNET_UI_API void Window_SetTitle_(Window* obj, const char16_t* value)
{
    obj->SetTitle(value);
}

ALTERNET_UI_API WindowStartLocation Window_GetWindowStartLocation_(Window* obj)
{
    return obj->GetWindowStartLocation();
}

ALTERNET_UI_API void Window_SetWindowStartLocation_(Window* obj, WindowStartLocation value)
{
    obj->SetWindowStartLocation(value);
}

ALTERNET_UI_API c_bool Window_GetShowInTaskbar_(Window* obj)
{
    return obj->GetShowInTaskbar();
}

ALTERNET_UI_API void Window_SetShowInTaskbar_(Window* obj, c_bool value)
{
    obj->SetShowInTaskbar(value);
}

ALTERNET_UI_API c_bool Window_GetMinimizeEnabled_(Window* obj)
{
    return obj->GetMinimizeEnabled();
}

ALTERNET_UI_API void Window_SetMinimizeEnabled_(Window* obj, c_bool value)
{
    obj->SetMinimizeEnabled(value);
}

ALTERNET_UI_API c_bool Window_GetMaximizeEnabled_(Window* obj)
{
    return obj->GetMaximizeEnabled();
}

ALTERNET_UI_API void Window_SetMaximizeEnabled_(Window* obj, c_bool value)
{
    obj->SetMaximizeEnabled(value);
}

ALTERNET_UI_API c_bool Window_GetCloseEnabled_(Window* obj)
{
    return obj->GetCloseEnabled();
}

ALTERNET_UI_API void Window_SetCloseEnabled_(Window* obj, c_bool value)
{
    obj->SetCloseEnabled(value);
}

ALTERNET_UI_API c_bool Window_GetAlwaysOnTop_(Window* obj)
{
    return obj->GetAlwaysOnTop();
}

ALTERNET_UI_API void Window_SetAlwaysOnTop_(Window* obj, c_bool value)
{
    obj->SetAlwaysOnTop(value);
}

ALTERNET_UI_API c_bool Window_GetIsToolWindow_(Window* obj)
{
    return obj->GetIsToolWindow();
}

ALTERNET_UI_API void Window_SetIsToolWindow_(Window* obj, c_bool value)
{
    obj->SetIsToolWindow(value);
}

ALTERNET_UI_API c_bool Window_GetResizable_(Window* obj)
{
    return obj->GetResizable();
}

ALTERNET_UI_API void Window_SetResizable_(Window* obj, c_bool value)
{
    obj->SetResizable(value);
}

ALTERNET_UI_API c_bool Window_GetHasBorder_(Window* obj)
{
    return obj->GetHasBorder();
}

ALTERNET_UI_API void Window_SetHasBorder_(Window* obj, c_bool value)
{
    obj->SetHasBorder(value);
}

ALTERNET_UI_API c_bool Window_GetHasTitleBar_(Window* obj)
{
    return obj->GetHasTitleBar();
}

ALTERNET_UI_API void Window_SetHasTitleBar_(Window* obj, c_bool value)
{
    obj->SetHasTitleBar(value);
}

ALTERNET_UI_API c_bool Window_GetHasSystemMenu_(Window* obj)
{
    return obj->GetHasSystemMenu();
}

ALTERNET_UI_API void Window_SetHasSystemMenu_(Window* obj, c_bool value)
{
    obj->SetHasSystemMenu(value);
}

ALTERNET_UI_API c_bool Window_GetIsPopupWindow_(Window* obj)
{
    return obj->GetIsPopupWindow();
}

ALTERNET_UI_API void Window_SetIsPopupWindow_(Window* obj, c_bool value)
{
    obj->SetIsPopupWindow(value);
}

ALTERNET_UI_API ModalResult Window_GetModalResult_(Window* obj)
{
    return obj->GetModalResult();
}

ALTERNET_UI_API void Window_SetModalResult_(Window* obj, ModalResult value)
{
    obj->SetModalResult(value);
}

ALTERNET_UI_API c_bool Window_GetModal_(Window* obj)
{
    return obj->GetModal();
}

ALTERNET_UI_API c_bool Window_GetIsActive_(Window* obj)
{
    return obj->GetIsActive();
}

ALTERNET_UI_API Window* Window_GetActiveWindow_()
{
    return Window::GetActiveWindow();
}

ALTERNET_UI_API WindowState Window_GetState_(Window* obj)
{
    return obj->GetState();
}

ALTERNET_UI_API void Window_SetState_(Window* obj, WindowState value)
{
    obj->SetState(value);
}

ALTERNET_UI_API ImageSet* Window_GetIcon_(Window* obj)
{
    return obj->GetIcon();
}

ALTERNET_UI_API void Window_SetIcon_(Window* obj, ImageSet* value)
{
    obj->SetIcon(value);
}

ALTERNET_UI_API MainMenu* Window_GetMenu_(Window* obj)
{
    return obj->GetMenu();
}

ALTERNET_UI_API void Window_SetMenu_(Window* obj, MainMenu* value)
{
    obj->SetMenu(value);
}

ALTERNET_UI_API Toolbar* Window_GetToolbar_(Window* obj)
{
    return obj->GetToolbar();
}

ALTERNET_UI_API void Window_SetToolbar_(Window* obj, Toolbar* value)
{
    obj->SetToolbar(value);
}

ALTERNET_UI_API StatusBar* Window_GetStatusBar_(Window* obj)
{
    return obj->GetStatusBar();
}

ALTERNET_UI_API void Window_SetStatusBar_(Window* obj, StatusBar* value)
{
    obj->SetStatusBar(value);
}

ALTERNET_UI_API void* Window_OpenOwnedWindowsArray_(Window* obj)
{
    return obj->OpenOwnedWindowsArray();
}

ALTERNET_UI_API int Window_GetOwnedWindowsItemCount_(Window* obj, void* array)
{
    return obj->GetOwnedWindowsItemCount(array);
}

ALTERNET_UI_API Window* Window_GetOwnedWindowsItemAt_(Window* obj, void* array, int index)
{
    return obj->GetOwnedWindowsItemAt(array, index);
}

ALTERNET_UI_API void Window_CloseOwnedWindowsArray_(Window* obj, void* array)
{
    obj->CloseOwnedWindowsArray(array);
}

ALTERNET_UI_API void Window_ShowModal_(Window* obj)
{
    obj->ShowModal();
}

ALTERNET_UI_API void Window_Close_(Window* obj)
{
    obj->Close();
}

ALTERNET_UI_API void Window_Activate_(Window* obj)
{
    obj->Activate();
}

ALTERNET_UI_API void Window_AddInputBinding_(Window* obj, const char16_t* managedCommandId, Key key, ModifierKeys modifiers)
{
    obj->AddInputBinding(managedCommandId, key, modifiers);
}

ALTERNET_UI_API void Window_RemoveInputBinding_(Window* obj, const char16_t* managedCommandId)
{
    obj->RemoveInputBinding(managedCommandId);
}

ALTERNET_UI_API void Window_SetEventCallback_(Window::WindowEventCallbackType callback)
{
    Window::SetEventCallback(callback);
}

