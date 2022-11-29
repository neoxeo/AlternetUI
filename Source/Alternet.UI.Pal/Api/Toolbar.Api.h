// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>

#pragma once

#include "Toolbar.h"
#include "ToolbarItem.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Toolbar* Toolbar_Create_()
{
    return MarshalExceptions<Toolbar*>([&](){
            return new Toolbar();
        });
}

ALTERNET_UI_API int Toolbar_GetItemsCount_(Toolbar* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetItemsCount();
        });
}

ALTERNET_UI_API void Toolbar_InsertItemAt_(Toolbar* obj, int index, ToolbarItem* item)
{
    MarshalExceptions<void>([&](){
            obj->InsertItemAt(index, item);
        });
}

ALTERNET_UI_API void Toolbar_RemoveItemAt_(Toolbar* obj, int index)
{
    MarshalExceptions<void>([&](){
            obj->RemoveItemAt(index);
        });
}

