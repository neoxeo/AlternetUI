// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>

#pragma once

#include "MessageBox_.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API void MessageBox__Show_(const char16_t* text, const char16_t* caption)
{
    MarshalExceptions<void>([&](){
            MessageBox_::Show(text, ToOptional(caption));
        });
}

