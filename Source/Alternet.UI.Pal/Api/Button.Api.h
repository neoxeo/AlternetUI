// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2023 AlterNET Software.</auto-generated>

#pragma once

#include "Button.h"
#include "Image.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Button* Button_Create_()
{
    return new Button();
}

ALTERNET_UI_API c_bool Button_GetImagesEnabled_()
{
    return Button::GetImagesEnabled();
}

ALTERNET_UI_API void Button_SetImagesEnabled_(c_bool value)
{
    Button::SetImagesEnabled(value);
}

ALTERNET_UI_API char16_t* Button_GetText_(Button* obj)
{
    return AllocPInvokeReturnString(obj->GetText());
}

ALTERNET_UI_API void Button_SetText_(Button* obj, const char16_t* value)
{
    obj->SetText(value);
}

ALTERNET_UI_API c_bool Button_GetExactFit_(Button* obj)
{
    return obj->GetExactFit();
}

ALTERNET_UI_API void Button_SetExactFit_(Button* obj, c_bool value)
{
    obj->SetExactFit(value);
}

ALTERNET_UI_API c_bool Button_GetIsDefault_(Button* obj)
{
    return obj->GetIsDefault();
}

ALTERNET_UI_API void Button_SetIsDefault_(Button* obj, c_bool value)
{
    obj->SetIsDefault(value);
}

ALTERNET_UI_API c_bool Button_GetHasBorder_(Button* obj)
{
    return obj->GetHasBorder();
}

ALTERNET_UI_API void Button_SetHasBorder_(Button* obj, c_bool value)
{
    obj->SetHasBorder(value);
}

ALTERNET_UI_API c_bool Button_GetIsCancel_(Button* obj)
{
    return obj->GetIsCancel();
}

ALTERNET_UI_API void Button_SetIsCancel_(Button* obj, c_bool value)
{
    obj->SetIsCancel(value);
}

ALTERNET_UI_API Image* Button_GetNormalImage_(Button* obj)
{
    return obj->GetNormalImage();
}

ALTERNET_UI_API void Button_SetNormalImage_(Button* obj, Image* value)
{
    obj->SetNormalImage(value);
}

ALTERNET_UI_API Image* Button_GetHoveredImage_(Button* obj)
{
    return obj->GetHoveredImage();
}

ALTERNET_UI_API void Button_SetHoveredImage_(Button* obj, Image* value)
{
    obj->SetHoveredImage(value);
}

ALTERNET_UI_API Image* Button_GetPressedImage_(Button* obj)
{
    return obj->GetPressedImage();
}

ALTERNET_UI_API void Button_SetPressedImage_(Button* obj, Image* value)
{
    obj->SetPressedImage(value);
}

ALTERNET_UI_API Image* Button_GetDisabledImage_(Button* obj)
{
    return obj->GetDisabledImage();
}

ALTERNET_UI_API void Button_SetDisabledImage_(Button* obj, Image* value)
{
    obj->SetDisabledImage(value);
}

ALTERNET_UI_API Image* Button_GetFocusedImage_(Button* obj)
{
    return obj->GetFocusedImage();
}

ALTERNET_UI_API void Button_SetFocusedImage_(Button* obj, Image* value)
{
    obj->SetFocusedImage(value);
}

ALTERNET_UI_API c_bool Button_GetAcceptsFocus_(Button* obj)
{
    return obj->GetAcceptsFocus();
}

ALTERNET_UI_API void Button_SetAcceptsFocus_(Button* obj, c_bool value)
{
    obj->SetAcceptsFocus(value);
}

ALTERNET_UI_API c_bool Button_GetAcceptsFocusFromKeyboard_(Button* obj)
{
    return obj->GetAcceptsFocusFromKeyboard();
}

ALTERNET_UI_API void Button_SetAcceptsFocusFromKeyboard_(Button* obj, c_bool value)
{
    obj->SetAcceptsFocusFromKeyboard(value);
}

ALTERNET_UI_API c_bool Button_GetAcceptsFocusRecursively_(Button* obj)
{
    return obj->GetAcceptsFocusRecursively();
}

ALTERNET_UI_API void Button_SetAcceptsFocusRecursively_(Button* obj, c_bool value)
{
    obj->SetAcceptsFocusRecursively(value);
}

ALTERNET_UI_API c_bool Button_GetTextVisible_(Button* obj)
{
    return obj->GetTextVisible();
}

ALTERNET_UI_API void Button_SetTextVisible_(Button* obj, c_bool value)
{
    obj->SetTextVisible(value);
}

ALTERNET_UI_API int Button_GetTextAlign_(Button* obj)
{
    return obj->GetTextAlign();
}

ALTERNET_UI_API void Button_SetTextAlign_(Button* obj, int value)
{
    obj->SetTextAlign(value);
}

ALTERNET_UI_API void Button_SetImagePosition_(Button* obj, int dir)
{
    obj->SetImagePosition(dir);
}

ALTERNET_UI_API void Button_SetImageMargins_(Button* obj, double x, double y)
{
    obj->SetImageMargins(x, y);
}

ALTERNET_UI_API void Button_SetEventCallback_(Button::ButtonEventCallbackType callback)
{
    Button::SetEventCallback(callback);
}

