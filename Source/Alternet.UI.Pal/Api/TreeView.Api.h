// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2023 AlterNET Software.</auto-generated>

#pragma once

#include "TreeView.h"
#include "ImageList.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API TreeView* TreeView_Create_()
{
    return new TreeView();
}

ALTERNET_UI_API int64_t TreeView_GetCreateStyle_(TreeView* obj)
{
    return obj->GetCreateStyle();
}

ALTERNET_UI_API void TreeView_SetCreateStyle_(TreeView* obj, int64_t value)
{
    obj->SetCreateStyle(value);
}

ALTERNET_UI_API c_bool TreeView_GetHideRoot_(TreeView* obj)
{
    return obj->GetHideRoot();
}

ALTERNET_UI_API void TreeView_SetHideRoot_(TreeView* obj, c_bool value)
{
    obj->SetHideRoot(value);
}

ALTERNET_UI_API c_bool TreeView_GetVariableRowHeight_(TreeView* obj)
{
    return obj->GetVariableRowHeight();
}

ALTERNET_UI_API void TreeView_SetVariableRowHeight_(TreeView* obj, c_bool value)
{
    obj->SetVariableRowHeight(value);
}

ALTERNET_UI_API c_bool TreeView_GetTwistButtons_(TreeView* obj)
{
    return obj->GetTwistButtons();
}

ALTERNET_UI_API void TreeView_SetTwistButtons_(TreeView* obj, c_bool value)
{
    obj->SetTwistButtons(value);
}

ALTERNET_UI_API uint32_t TreeView_GetStateImageSpacing_(TreeView* obj)
{
    return obj->GetStateImageSpacing();
}

ALTERNET_UI_API void TreeView_SetStateImageSpacing_(TreeView* obj, uint32_t value)
{
    obj->SetStateImageSpacing(value);
}

ALTERNET_UI_API uint32_t TreeView_GetIndentation_(TreeView* obj)
{
    return obj->GetIndentation();
}

ALTERNET_UI_API void TreeView_SetIndentation_(TreeView* obj, uint32_t value)
{
    obj->SetIndentation(value);
}

ALTERNET_UI_API c_bool TreeView_GetRowLines_(TreeView* obj)
{
    return obj->GetRowLines();
}

ALTERNET_UI_API void TreeView_SetRowLines_(TreeView* obj, c_bool value)
{
    obj->SetRowLines(value);
}

ALTERNET_UI_API c_bool TreeView_GetHasBorder_(TreeView* obj)
{
    return obj->GetHasBorder();
}

ALTERNET_UI_API void TreeView_SetHasBorder_(TreeView* obj, c_bool value)
{
    obj->SetHasBorder(value);
}

ALTERNET_UI_API ImageList* TreeView_GetImageList_(TreeView* obj)
{
    return obj->GetImageList();
}

ALTERNET_UI_API void TreeView_SetImageList_(TreeView* obj, ImageList* value)
{
    obj->SetImageList(value);
}

ALTERNET_UI_API void* TreeView_GetRootItem_(TreeView* obj)
{
    return obj->GetRootItem();
}

ALTERNET_UI_API TreeViewSelectionMode TreeView_GetSelectionMode_(TreeView* obj)
{
    return obj->GetSelectionMode();
}

ALTERNET_UI_API void TreeView_SetSelectionMode_(TreeView* obj, TreeViewSelectionMode value)
{
    obj->SetSelectionMode(value);
}

ALTERNET_UI_API c_bool TreeView_GetShowLines_(TreeView* obj)
{
    return obj->GetShowLines();
}

ALTERNET_UI_API void TreeView_SetShowLines_(TreeView* obj, c_bool value)
{
    obj->SetShowLines(value);
}

ALTERNET_UI_API c_bool TreeView_GetShowRootLines_(TreeView* obj)
{
    return obj->GetShowRootLines();
}

ALTERNET_UI_API void TreeView_SetShowRootLines_(TreeView* obj, c_bool value)
{
    obj->SetShowRootLines(value);
}

ALTERNET_UI_API c_bool TreeView_GetShowExpandButtons_(TreeView* obj)
{
    return obj->GetShowExpandButtons();
}

ALTERNET_UI_API void TreeView_SetShowExpandButtons_(TreeView* obj, c_bool value)
{
    obj->SetShowExpandButtons(value);
}

ALTERNET_UI_API void* TreeView_GetTopItem_(TreeView* obj)
{
    return obj->GetTopItem();
}

ALTERNET_UI_API c_bool TreeView_GetFullRowSelect_(TreeView* obj)
{
    return obj->GetFullRowSelect();
}

ALTERNET_UI_API void TreeView_SetFullRowSelect_(TreeView* obj, c_bool value)
{
    obj->SetFullRowSelect(value);
}

ALTERNET_UI_API c_bool TreeView_GetAllowLabelEdit_(TreeView* obj)
{
    return obj->GetAllowLabelEdit();
}

ALTERNET_UI_API void TreeView_SetAllowLabelEdit_(TreeView* obj, c_bool value)
{
    obj->SetAllowLabelEdit(value);
}

ALTERNET_UI_API void* TreeView_OpenSelectedItemsArray_(TreeView* obj)
{
    return obj->OpenSelectedItemsArray();
}

ALTERNET_UI_API int TreeView_GetSelectedItemsItemCount_(TreeView* obj, void* array)
{
    return obj->GetSelectedItemsItemCount(array);
}

ALTERNET_UI_API void* TreeView_GetSelectedItemsItemAt_(TreeView* obj, void* array, int index)
{
    return obj->GetSelectedItemsItemAt(array, index);
}

ALTERNET_UI_API void TreeView_CloseSelectedItemsArray_(TreeView* obj, void* array)
{
    obj->CloseSelectedItemsArray(array);
}

ALTERNET_UI_API void TreeView_SetNodeUniqueId_(TreeView* obj, void* node, int64_t uniqueId)
{
    obj->SetNodeUniqueId(node, uniqueId);
}

ALTERNET_UI_API int64_t TreeView_GetNodeUniqueId_(TreeView* obj, void* node)
{
    return obj->GetNodeUniqueId(node);
}

ALTERNET_UI_API void TreeView_MakeAsListBox_(TreeView* obj)
{
    obj->MakeAsListBox();
}

ALTERNET_UI_API int TreeView_GetItemCount_(TreeView* obj, void* parentItem)
{
    return obj->GetItemCount(parentItem);
}

ALTERNET_UI_API void* TreeView_InsertItem_(TreeView* obj, void* parentItem, void* insertAfter, const char16_t* text, int imageIndex, c_bool parentIsExpanded)
{
    return obj->InsertItem(parentItem, insertAfter, text, imageIndex, parentIsExpanded);
}

ALTERNET_UI_API void TreeView_RemoveItem_(TreeView* obj, void* item)
{
    obj->RemoveItem(item);
}

ALTERNET_UI_API void TreeView_ClearItems_(TreeView* obj, void* parentItem)
{
    obj->ClearItems(parentItem);
}

ALTERNET_UI_API void TreeView_ClearSelected_(TreeView* obj)
{
    obj->ClearSelected();
}

ALTERNET_UI_API void TreeView_SetSelected_(TreeView* obj, void* item, c_bool value)
{
    obj->SetSelected(item, value);
}

ALTERNET_UI_API void TreeView_ExpandAll_(TreeView* obj)
{
    obj->ExpandAll();
}

ALTERNET_UI_API void TreeView_CollapseAll_(TreeView* obj)
{
    obj->CollapseAll();
}

ALTERNET_UI_API void* TreeView_ItemHitTest_(TreeView* obj, PointD point)
{
    return obj->ItemHitTest(point);
}

ALTERNET_UI_API TreeViewHitTestLocations TreeView_GetHitTestResultLocations_(TreeView* obj, void* hitTestResult)
{
    return obj->GetHitTestResultLocations(hitTestResult);
}

ALTERNET_UI_API void* TreeView_GetHitTestResultItem_(TreeView* obj, void* hitTestResult)
{
    return obj->GetHitTestResultItem(hitTestResult);
}

ALTERNET_UI_API void TreeView_FreeHitTestResult_(TreeView* obj, void* hitTestResult)
{
    obj->FreeHitTestResult(hitTestResult);
}

ALTERNET_UI_API c_bool TreeView_IsItemSelected_(TreeView* obj, void* item)
{
    return obj->IsItemSelected(item);
}

ALTERNET_UI_API void TreeView_SetFocused_(TreeView* obj, void* item, c_bool value)
{
    obj->SetFocused(item, value);
}

ALTERNET_UI_API c_bool TreeView_IsItemFocused_(TreeView* obj, void* item)
{
    return obj->IsItemFocused(item);
}

ALTERNET_UI_API void TreeView_SetItemText_(TreeView* obj, void* item, const char16_t* text)
{
    obj->SetItemText(item, text);
}

ALTERNET_UI_API char16_t* TreeView_GetItemText_(TreeView* obj, void* item)
{
    return AllocPInvokeReturnString(obj->GetItemText(item));
}

ALTERNET_UI_API void TreeView_SetItemImageIndex_(TreeView* obj, void* item, int imageIndex)
{
    obj->SetItemImageIndex(item, imageIndex);
}

ALTERNET_UI_API int TreeView_GetItemImageIndex_(TreeView* obj, void* item)
{
    return obj->GetItemImageIndex(item);
}

ALTERNET_UI_API void TreeView_BeginLabelEdit_(TreeView* obj, void* item)
{
    obj->BeginLabelEdit(item);
}

ALTERNET_UI_API void TreeView_EndLabelEdit_(TreeView* obj, void* item, c_bool cancel)
{
    obj->EndLabelEdit(item, cancel);
}

ALTERNET_UI_API void TreeView_ExpandAllChildren_(TreeView* obj, void* item)
{
    obj->ExpandAllChildren(item);
}

ALTERNET_UI_API void TreeView_CollapseAllChildren_(TreeView* obj, void* item)
{
    obj->CollapseAllChildren(item);
}

ALTERNET_UI_API void TreeView_EnsureVisible_(TreeView* obj, void* item)
{
    obj->EnsureVisible(item);
}

ALTERNET_UI_API void TreeView_ScrollIntoView_(TreeView* obj, void* item)
{
    obj->ScrollIntoView(item);
}

ALTERNET_UI_API void TreeView_SetEventCallback_(TreeView::TreeViewEventCallbackType callback)
{
    TreeView::SetEventCallback(callback);
}

