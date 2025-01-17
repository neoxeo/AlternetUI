// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2025 AlterNET Software.</auto-generated>

#pragma once

#include "ValidatorText.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API ValidatorText* ValidatorText_Create_()
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<ValidatorText*>([&](){
    #endif
        return new ValidatorText();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void ValidatorText_DeleteValidatorText_(void* handle)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        ValidatorText::DeleteValidatorText(handle);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void* ValidatorText_CreateValidatorText_(int64_t style)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<void*>([&](){
    #endif
        return ValidatorText::CreateValidatorText(style);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API int64_t ValidatorText_GetStyle_(void* handle)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<int64_t>([&](){
    #endif
        return ValidatorText::GetStyle(handle);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void ValidatorText_SetStyle_(void* handle, int64_t style)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        ValidatorText::SetStyle(handle, style);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void ValidatorText_SetCharIncludes_(void* handle, const char16_t* chars)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        ValidatorText::SetCharIncludes(handle, chars);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void ValidatorText_AddCharIncludes_(void* handle, const char16_t* chars)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        ValidatorText::AddCharIncludes(handle, chars);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API char16_t* ValidatorText_GetCharIncludes_(void* handle)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<char16_t*>([&](){
    #endif
        return AllocPInvokeReturnString(ValidatorText::GetCharIncludes(handle));
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void ValidatorText_AddInclude_(void* handle, const char16_t* include)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        ValidatorText::AddInclude(handle, include);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void ValidatorText_AddExclude_(void* handle, const char16_t* exclude)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        ValidatorText::AddExclude(handle, exclude);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void ValidatorText_SetCharExcludes_(void* handle, const char16_t* chars)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        ValidatorText::SetCharExcludes(handle, chars);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void ValidatorText_AddCharExcludes_(void* handle, const char16_t* chars)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        ValidatorText::AddCharExcludes(handle, chars);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API char16_t* ValidatorText_GetCharExcludes_(void* handle)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<char16_t*>([&](){
    #endif
        return AllocPInvokeReturnString(ValidatorText::GetCharExcludes(handle));
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void ValidatorText_ClearExcludes_(void* handle)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        ValidatorText::ClearExcludes(handle);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void ValidatorText_ClearIncludes_(void* handle)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        ValidatorText::ClearIncludes(handle);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API char16_t* ValidatorText_IsValid_(void* handle, const char16_t* val)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<char16_t*>([&](){
    #endif
        return AllocPInvokeReturnString(ValidatorText::IsValid(handle, val));
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

