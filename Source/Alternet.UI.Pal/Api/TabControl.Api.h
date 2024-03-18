// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "TabControl.h"
#include "Control.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API TabControl* TabControl_Create_()
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<TabControl*>([&](){
    #endif
        return new TabControl();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API int TabControl_GetPageCount_(TabControl* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<int>([&](){
    #endif
        return obj->GetPageCount();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API int TabControl_GetSelectedPageIndex_(TabControl* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<int>([&](){
    #endif
        return obj->GetSelectedPageIndex();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void TabControl_SetSelectedPageIndex_(TabControl* obj, int value)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetSelectedPageIndex(value);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API TabAlignment TabControl_GetTabAlignment_(TabControl* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<TabAlignment>([&](){
    #endif
        return obj->GetTabAlignment();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void TabControl_SetTabAlignment_(TabControl* obj, TabAlignment value)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetTabAlignment(value);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void TabControl_InsertPage_(TabControl* obj, int index, Control* page, const char16_t* title)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->InsertPage(index, page, title);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void TabControl_RemovePage_(TabControl* obj, int index, Control* page)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->RemovePage(index, page);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void TabControl_SetPageTitle_(TabControl* obj, int index, const char16_t* title)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetPageTitle(index, title);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API SizeD_C TabControl_GetTotalPreferredSizeFromPageSize_(TabControl* obj, SizeD pageSize)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<SizeD_C>([&](){
    #endif
        return obj->GetTotalPreferredSizeFromPageSize(pageSize);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void TabControl_SetEventCallback_(TabControl::TabControlEventCallbackType callback)
{
    TabControl::SetEventCallback(callback);
}

