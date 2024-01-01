// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "Panel.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Panel* Panel_Create_()
{
    return new Panel();
}

ALTERNET_UI_API c_bool Panel_GetWantChars_(Panel* obj)
{
    return obj->GetWantChars();
}

ALTERNET_UI_API void Panel_SetWantChars_(Panel* obj, c_bool value)
{
    obj->SetWantChars(value);
}

ALTERNET_UI_API c_bool Panel_GetShowVertScrollBar_(Panel* obj)
{
    return obj->GetShowVertScrollBar();
}

ALTERNET_UI_API void Panel_SetShowVertScrollBar_(Panel* obj, c_bool value)
{
    obj->SetShowVertScrollBar(value);
}

ALTERNET_UI_API c_bool Panel_GetShowHorzScrollBar_(Panel* obj)
{
    return obj->GetShowHorzScrollBar();
}

ALTERNET_UI_API void Panel_SetShowHorzScrollBar_(Panel* obj, c_bool value)
{
    obj->SetShowHorzScrollBar(value);
}

ALTERNET_UI_API c_bool Panel_GetScrollBarAlwaysVisible_(Panel* obj)
{
    return obj->GetScrollBarAlwaysVisible();
}

ALTERNET_UI_API void Panel_SetScrollBarAlwaysVisible_(Panel* obj, c_bool value)
{
    obj->SetScrollBarAlwaysVisible(value);
}

