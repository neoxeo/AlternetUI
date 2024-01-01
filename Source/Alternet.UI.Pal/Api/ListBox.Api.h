// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "ListBox.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API ListBox* ListBox_Create_()
{
    return new ListBox();
}

ALTERNET_UI_API c_bool ListBox_GetHasBorder_(ListBox* obj)
{
    return obj->GetHasBorder();
}

ALTERNET_UI_API void ListBox_SetHasBorder_(ListBox* obj, c_bool value)
{
    obj->SetHasBorder(value);
}

ALTERNET_UI_API int ListBox_GetItemsCount_(ListBox* obj)
{
    return obj->GetItemsCount();
}

ALTERNET_UI_API ListBoxSelectionMode ListBox_GetSelectionMode_(ListBox* obj)
{
    return obj->GetSelectionMode();
}

ALTERNET_UI_API void ListBox_SetSelectionMode_(ListBox* obj, ListBoxSelectionMode value)
{
    obj->SetSelectionMode(value);
}

ALTERNET_UI_API void* ListBox_OpenSelectedIndicesArray_(ListBox* obj)
{
    return obj->OpenSelectedIndicesArray();
}

ALTERNET_UI_API int ListBox_GetSelectedIndicesItemCount_(ListBox* obj, void* array)
{
    return obj->GetSelectedIndicesItemCount(array);
}

ALTERNET_UI_API int ListBox_GetSelectedIndicesItemAt_(ListBox* obj, void* array, int index)
{
    return obj->GetSelectedIndicesItemAt(array, index);
}

ALTERNET_UI_API void ListBox_CloseSelectedIndicesArray_(ListBox* obj, void* array)
{
    obj->CloseSelectedIndicesArray(array);
}

ALTERNET_UI_API void* ListBox_CreateEx_(int64_t styles)
{
    return ListBox::CreateEx(styles);
}

ALTERNET_UI_API void ListBox_InsertItem_(ListBox* obj, int index, const char16_t* value)
{
    obj->InsertItem(index, value);
}

ALTERNET_UI_API void ListBox_RemoveItemAt_(ListBox* obj, int index)
{
    obj->RemoveItemAt(index);
}

ALTERNET_UI_API void ListBox_ClearItems_(ListBox* obj)
{
    obj->ClearItems();
}

ALTERNET_UI_API void ListBox_ClearSelected_(ListBox* obj)
{
    obj->ClearSelected();
}

ALTERNET_UI_API void ListBox_SetSelected_(ListBox* obj, int index, c_bool value)
{
    obj->SetSelected(index, value);
}

ALTERNET_UI_API void ListBox_EnsureVisible_(ListBox* obj, int itemIndex)
{
    obj->EnsureVisible(itemIndex);
}

ALTERNET_UI_API int ListBox_ItemHitTest_(ListBox* obj, PointD position)
{
    return obj->ItemHitTest(position);
}

ALTERNET_UI_API void ListBox_SetItem_(ListBox* obj, int index, const char16_t* value)
{
    obj->SetItem(index, value);
}

ALTERNET_UI_API void ListBox_SetEventCallback_(ListBox::ListBoxEventCallbackType callback)
{
    ListBox::SetEventCallback(callback);
}

