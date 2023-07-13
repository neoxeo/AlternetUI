// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>

#pragma once

#include "ToolbarItem.h"
#include "Menu.h"
#include "ImageSet.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API ToolbarItem* ToolbarItem_Create_()
{
    return MarshalExceptions<ToolbarItem*>([&](){
            return new ToolbarItem();
        });
}

ALTERNET_UI_API char16_t* ToolbarItem_GetManagedCommandId_(ToolbarItem* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetManagedCommandId());
        });
}

ALTERNET_UI_API void ToolbarItem_SetManagedCommandId_(ToolbarItem* obj, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetManagedCommandId(value);
        });
}

ALTERNET_UI_API char16_t* ToolbarItem_GetText_(ToolbarItem* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetText());
        });
}

ALTERNET_UI_API void ToolbarItem_SetText_(ToolbarItem* obj, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetText(value);
        });
}

ALTERNET_UI_API c_bool ToolbarItem_GetChecked_(ToolbarItem* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetChecked();
        });
}

ALTERNET_UI_API void ToolbarItem_SetChecked_(ToolbarItem* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetChecked(value);
        });
}

ALTERNET_UI_API Menu* ToolbarItem_GetDropDownMenu_(ToolbarItem* obj)
{
    return MarshalExceptions<Menu*>([&](){
            return obj->GetDropDownMenu();
        });
}

ALTERNET_UI_API void ToolbarItem_SetDropDownMenu_(ToolbarItem* obj, Menu* value)
{
    MarshalExceptions<void>([&](){
            obj->SetDropDownMenu(value);
        });
}

ALTERNET_UI_API c_bool ToolbarItem_GetIsCheckable_(ToolbarItem* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetIsCheckable();
        });
}

ALTERNET_UI_API void ToolbarItem_SetIsCheckable_(ToolbarItem* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetIsCheckable(value);
        });
}

ALTERNET_UI_API ImageSet* ToolbarItem_GetDisabledImage_(ToolbarItem* obj)
{
    return MarshalExceptions<ImageSet*>([&](){
            return obj->GetDisabledImage();
        });
}

ALTERNET_UI_API void ToolbarItem_SetDisabledImage_(ToolbarItem* obj, ImageSet* value)
{
    MarshalExceptions<void>([&](){
            obj->SetDisabledImage(value);
        });
}

ALTERNET_UI_API ImageSet* ToolbarItem_GetImage_(ToolbarItem* obj)
{
    return MarshalExceptions<ImageSet*>([&](){
            return obj->GetImage();
        });
}

ALTERNET_UI_API void ToolbarItem_SetImage_(ToolbarItem* obj, ImageSet* value)
{
    MarshalExceptions<void>([&](){
            obj->SetImage(value);
        });
}

ALTERNET_UI_API void ToolbarItem_SetEventCallback_(ToolbarItem::ToolbarItemEventCallbackType callback)
{
    ToolbarItem::SetEventCallback(callback);
}

