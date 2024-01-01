// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "Keyboard.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Keyboard* Keyboard_Create_()
{
    return new Keyboard();
}

ALTERNET_UI_API KeyStates Keyboard_GetKeyState_(Keyboard* obj, Key key)
{
    return obj->GetKeyState(key);
}

ALTERNET_UI_API void Keyboard_SetEventCallback_(Keyboard::KeyboardEventCallbackType callback)
{
    Keyboard::SetEventCallback(callback);
}

