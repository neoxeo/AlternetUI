// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "VListBox.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API VListBox* VListBox_Create_()
{
    return new VListBox();
}

ALTERNET_UI_API void* VListBox_GetEventDc_(VListBox* obj)
{
    return obj->GetEventDc();
}

ALTERNET_UI_API RectI_C VListBox_GetEventRect_(VListBox* obj)
{
    return obj->GetEventRect();
}

ALTERNET_UI_API int VListBox_GetEventItem_(VListBox* obj)
{
    return obj->GetEventItem();
}

ALTERNET_UI_API int VListBox_GetEventHeight_(VListBox* obj)
{
    return obj->GetEventHeight();
}

ALTERNET_UI_API void VListBox_SetEventHeight_(VListBox* obj, int value)
{
    obj->SetEventHeight(value);
}

ALTERNET_UI_API c_bool VListBox_GetHasBorder_(VListBox* obj)
{
    return obj->GetHasBorder();
}

ALTERNET_UI_API void VListBox_SetHasBorder_(VListBox* obj, c_bool value)
{
    obj->SetHasBorder(value);
}

ALTERNET_UI_API int VListBox_GetItemsCount_(VListBox* obj)
{
    return obj->GetItemsCount();
}

ALTERNET_UI_API void VListBox_SetItemsCount_(VListBox* obj, int value)
{
    obj->SetItemsCount(value);
}

ALTERNET_UI_API ListBoxSelectionMode VListBox_GetSelectionMode_(VListBox* obj)
{
    return obj->GetSelectionMode();
}

ALTERNET_UI_API void VListBox_SetSelectionMode_(VListBox* obj, ListBoxSelectionMode value)
{
    obj->SetSelectionMode(value);
}

ALTERNET_UI_API void* VListBox_CreateEx_(int64_t styles)
{
    return VListBox::CreateEx(styles);
}

ALTERNET_UI_API void VListBox_ClearItems_(VListBox* obj)
{
    obj->ClearItems();
}

ALTERNET_UI_API void VListBox_ClearSelected_(VListBox* obj)
{
    obj->ClearSelected();
}

ALTERNET_UI_API void VListBox_SetSelected_(VListBox* obj, int index, c_bool value)
{
    obj->SetSelected(index, value);
}

ALTERNET_UI_API int VListBox_GetFirstSelected_(VListBox* obj)
{
    return obj->GetFirstSelected();
}

ALTERNET_UI_API int VListBox_GetNextSelected_(VListBox* obj)
{
    return obj->GetNextSelected();
}

ALTERNET_UI_API int VListBox_GetSelectedCount_(VListBox* obj)
{
    return obj->GetSelectedCount();
}

ALTERNET_UI_API int VListBox_GetSelection_(VListBox* obj)
{
    return obj->GetSelection();
}

ALTERNET_UI_API void VListBox_EnsureVisible_(VListBox* obj, int itemIndex)
{
    obj->EnsureVisible(itemIndex);
}

ALTERNET_UI_API int VListBox_ItemHitTest_(VListBox* obj, PointD position)
{
    return obj->ItemHitTest(position);
}

ALTERNET_UI_API void VListBox_SetSelection_(VListBox* obj, int selection)
{
    obj->SetSelection(selection);
}

ALTERNET_UI_API void VListBox_SetSelectionBackground_(VListBox* obj, Color color)
{
    obj->SetSelectionBackground(color);
}

ALTERNET_UI_API c_bool VListBox_IsCurrent_(VListBox* obj, int current)
{
    return obj->IsCurrent(current);
}

ALTERNET_UI_API c_bool VListBox_DoSetCurrent_(VListBox* obj, int current)
{
    return obj->DoSetCurrent(current);
}

ALTERNET_UI_API void VListBox_SetEventCallback_(VListBox::VListBoxEventCallbackType callback)
{
    VListBox::SetEventCallback(callback);
}

