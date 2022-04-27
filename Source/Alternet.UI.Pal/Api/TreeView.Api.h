// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>

#pragma once

#include "TreeView.h"
#include "ImageList.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API TreeView* TreeView_Create_()
{
    return MarshalExceptions<TreeView*>([&](){
            return new TreeView();
        });
}

ALTERNET_UI_API ImageList* TreeView_GetImageList_(TreeView* obj)
{
    return MarshalExceptions<ImageList*>([&](){
            return obj->GetImageList();
        });
}

ALTERNET_UI_API void TreeView_SetImageList_(TreeView* obj, ImageList* value)
{
    MarshalExceptions<void>([&](){
            obj->SetImageList(value);
        });
}

ALTERNET_UI_API void* TreeView_GetRootItem_(TreeView* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetRootItem();
        });
}

ALTERNET_UI_API TreeViewSelectionMode TreeView_GetSelectionMode_(TreeView* obj)
{
    return MarshalExceptions<TreeViewSelectionMode>([&](){
            return obj->GetSelectionMode();
        });
}

ALTERNET_UI_API void TreeView_SetSelectionMode_(TreeView* obj, TreeViewSelectionMode value)
{
    MarshalExceptions<void>([&](){
            obj->SetSelectionMode(value);
        });
}

ALTERNET_UI_API void* TreeView_OpenSelectedItemsArray_(TreeView* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->OpenSelectedItemsArray();
        });
}

ALTERNET_UI_API int TreeView_GetSelectedItemsItemCount_(TreeView* obj, void* array)
{
    return MarshalExceptions<int>([&](){
            return obj->GetSelectedItemsItemCount(array);
        });
}

ALTERNET_UI_API void* TreeView_GetSelectedItemsItemAt_(TreeView* obj, void* array, int index)
{
    return MarshalExceptions<void*>([&](){
            return obj->GetSelectedItemsItemAt(array, index);
        });
}

ALTERNET_UI_API void TreeView_CloseSelectedItemsArray_(TreeView* obj, void* array)
{
    MarshalExceptions<void>([&](){
            obj->CloseSelectedItemsArray(array);
        });
}

ALTERNET_UI_API int TreeView_GetItemCount_(TreeView* obj, void* parentItem)
{
    return MarshalExceptions<int>([&](){
            return obj->GetItemCount(parentItem);
        });
}

ALTERNET_UI_API void* TreeView_InsertItem_(TreeView* obj, void* parentItem, void* insertAfter, const char16_t* text, int imageIndex, c_bool parentIsExpanded)
{
    return MarshalExceptions<void*>([&](){
            return obj->InsertItem(parentItem, insertAfter, text, imageIndex, parentIsExpanded);
        });
}

ALTERNET_UI_API void TreeView_RemoveItem_(TreeView* obj, void* item)
{
    MarshalExceptions<void>([&](){
            obj->RemoveItem(item);
        });
}

ALTERNET_UI_API void TreeView_ClearItems_(TreeView* obj, void* parentItem)
{
    MarshalExceptions<void>([&](){
            obj->ClearItems(parentItem);
        });
}

ALTERNET_UI_API void TreeView_ClearSelected_(TreeView* obj)
{
    MarshalExceptions<void>([&](){
            obj->ClearSelected();
        });
}

ALTERNET_UI_API void TreeView_SetSelected_(TreeView* obj, void* item, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetSelected(item, value);
        });
}

ALTERNET_UI_API void TreeView_SetEventCallback_(TreeView::TreeViewEventCallbackType callback)
{
    TreeView::SetEventCallback(callback);
}

