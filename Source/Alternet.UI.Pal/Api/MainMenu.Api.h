// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "MainMenu.h"
#include "Menu.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API MainMenu* MainMenu_Create_()
{
    return new MainMenu();
}

ALTERNET_UI_API int MainMenu_GetItemsCount_(MainMenu* obj)
{
    return obj->GetItemsCount();
}

ALTERNET_UI_API void MainMenu_InsertItemAt_(MainMenu* obj, int index, Menu* menu, const char16_t* text)
{
    obj->InsertItemAt(index, menu, text);
}

ALTERNET_UI_API void MainMenu_RemoveItemAt_(MainMenu* obj, int index)
{
    obj->RemoveItemAt(index);
}

ALTERNET_UI_API void MainMenu_SetItemText_(MainMenu* obj, int index, const char16_t* text)
{
    obj->SetItemText(index, text);
}

