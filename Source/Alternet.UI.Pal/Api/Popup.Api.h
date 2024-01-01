// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "Popup.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Popup* Popup_Create_()
{
    return new Popup();
}

ALTERNET_UI_API c_bool Popup_GetIsTransient_(Popup* obj)
{
    return obj->GetIsTransient();
}

ALTERNET_UI_API void Popup_SetIsTransient_(Popup* obj, c_bool value)
{
    obj->SetIsTransient(value);
}

ALTERNET_UI_API c_bool Popup_GetPuContainsControls_(Popup* obj)
{
    return obj->GetPuContainsControls();
}

ALTERNET_UI_API void Popup_SetPuContainsControls_(Popup* obj, c_bool value)
{
    obj->SetPuContainsControls(value);
}

ALTERNET_UI_API void Popup_DoPopup_(Popup* obj, void* focus)
{
    obj->DoPopup(focus);
}

ALTERNET_UI_API void Popup_Dismiss_(Popup* obj)
{
    obj->Dismiss();
}

ALTERNET_UI_API void Popup_Position_(Popup* obj, PointI ptOrigin, SizeI sizePopup)
{
    obj->Position(ptOrigin, sizePopup);
}

