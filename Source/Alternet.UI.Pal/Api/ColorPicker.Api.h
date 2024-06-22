// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "ColorPicker.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API ColorPicker* ColorPicker_Create_()
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<ColorPicker*>([&](){
    #endif
        return new ColorPicker();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API Color_C ColorPicker_GetValue_(ColorPicker* obj)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<Color_C>([&](){
    #endif
        return obj->GetValue();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void ColorPicker_SetValue_(ColorPicker* obj, Color value)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetValue(value);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void ColorPicker_SetEventCallback_(ColorPicker::ColorPickerEventCallbackType callback)
{
    ColorPicker::SetEventCallback(callback);
}

