// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "PrintPreviewDialog.h"
#include "PrintDocument.h"
#include "Window.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API PrintPreviewDialog* PrintPreviewDialog_Create_()
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<PrintPreviewDialog*>([&](){
    #endif
        return new PrintPreviewDialog();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API char16_t* PrintPreviewDialog_GetTitle_(PrintPreviewDialog* obj)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<char16_t*>([&](){
    #endif
        return AllocPInvokeReturnString(obj->GetTitle());
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void PrintPreviewDialog_SetTitle_(PrintPreviewDialog* obj, const char16_t* value)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetTitle(ToOptional(value));
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API PrintDocument* PrintPreviewDialog_GetDocument_(PrintPreviewDialog* obj)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<PrintDocument*>([&](){
    #endif
        return obj->GetDocument();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void PrintPreviewDialog_SetDocument_(PrintPreviewDialog* obj, PrintDocument* value)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetDocument(value);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void PrintPreviewDialog_ShowModal_(PrintPreviewDialog* obj, Window* owner)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        obj->ShowModal(owner);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

