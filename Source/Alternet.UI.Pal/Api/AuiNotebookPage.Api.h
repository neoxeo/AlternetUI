// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "AuiNotebookPage.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API AuiNotebookPage* AuiNotebookPage_Create_()
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<AuiNotebookPage*>([&](){
    #endif
        return new AuiNotebookPage();
    #if !defined(__WXMSW__)
    });
    #endif
}

