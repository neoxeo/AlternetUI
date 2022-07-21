// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>

#pragma once

#include "Application.h"
#include "Keyboard.h"
#include "Mouse.h"
#include "Window.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Application* Application_Create_()
{
    return MarshalExceptions<Application*>([&](){
            return new Application();
        });
}

ALTERNET_UI_API char16_t* Application_GetName_(Application* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetName());
        });
}

ALTERNET_UI_API void Application_SetName_(Application* obj, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetName(value);
        });
}

ALTERNET_UI_API Keyboard* Application_GetKeyboard_(Application* obj)
{
    return MarshalExceptions<Keyboard*>([&](){
            return obj->GetKeyboard();
        });
}

ALTERNET_UI_API Mouse* Application_GetMouse_(Application* obj)
{
    return MarshalExceptions<Mouse*>([&](){
            return obj->GetMouse();
        });
}

ALTERNET_UI_API c_bool Application_GetInUixmlPreviewerMode_(Application* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetInUixmlPreviewerMode();
        });
}

ALTERNET_UI_API void Application_SetInUixmlPreviewerMode_(Application* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetInUixmlPreviewerMode(value);
        });
}

ALTERNET_UI_API void Application_Run_(Application* obj, Window* window)
{
    MarshalExceptions<void>([&](){
            obj->Run(window);
        });
}

ALTERNET_UI_API void Application_SetEventCallback_(Application::ApplicationEventCallbackType callback)
{
    Application::SetEventCallback(callback);
}

