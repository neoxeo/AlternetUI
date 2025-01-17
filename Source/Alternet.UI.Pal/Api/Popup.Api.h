// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2025 AlterNET Software.</auto-generated>

#pragma once

#include "Popup.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Popup* Popup_Create_()
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<Popup*>([&](){
    #endif
        return new Popup();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API c_bool Popup_GetIsTransient_(Popup* obj)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->GetIsTransient();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void Popup_SetIsTransient_(Popup* obj, c_bool value)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetIsTransient(value);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API c_bool Popup_GetPuContainsControls_(Popup* obj)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->GetPuContainsControls();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void Popup_SetPuContainsControls_(Popup* obj, c_bool value)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetPuContainsControls(value);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void Popup_DoPopup_(Popup* obj, void* focus)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        obj->DoPopup(focus);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void Popup_Dismiss_(Popup* obj)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        obj->Dismiss();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void Popup_Position_(Popup* obj, PointI ptOrigin, SizeI sizePopup)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        obj->Position(ptOrigin, sizePopup);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

