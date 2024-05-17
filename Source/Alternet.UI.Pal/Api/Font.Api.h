// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "Font.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Font* Font_Create_()
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<Font*>([&](){
    #endif
        return new Font();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API char16_t* Font_GetName_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<char16_t*>([&](){
    #endif
        return AllocPInvokeReturnString(obj->GetName());
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API double Font_GetSizeInPoints_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<double>([&](){
    #endif
        return obj->GetSizeInPoints();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API FontStyle Font_GetStyle_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<FontStyle>([&](){
    #endif
        return obj->GetStyle();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API char16_t* Font_GetDescription_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<char16_t*>([&](){
    #endif
        return AllocPInvokeReturnString(obj->GetDescription());
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void* Font_OpenFamiliesArray_()
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<void*>([&](){
    #endif
        return Font::OpenFamiliesArray();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API int Font_GetFamiliesItemCount_(void* array)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<int>([&](){
    #endif
        return Font::GetFamiliesItemCount(array);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API char16_t* Font_GetFamiliesItemAt_(void* array, int index)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<char16_t*>([&](){
    #endif
        return AllocPInvokeReturnString(Font::GetFamiliesItemAt(array, index));
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void Font_CloseFamiliesArray_(void* array)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        Font::CloseFamiliesArray(array);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API SizeI_C Font_GetPixelSize_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<SizeI_C>([&](){
    #endif
        return obj->GetPixelSize();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API c_bool Font_IsUsingSizeInPixels_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->IsUsingSizeInPixels();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API int Font_GetNumericWeight_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<int>([&](){
    #endif
        return obj->GetNumericWeight();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API c_bool Font_GetUnderlined_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->GetUnderlined();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API c_bool Font_GetItalic_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->GetItalic();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API c_bool Font_GetStrikethrough_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->GetStrikethrough();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API int Font_GetEncoding_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<int>([&](){
    #endif
        return obj->GetEncoding();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API c_bool Font_IsFixedWidth_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->IsFixedWidth();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API int Font_GetDefaultEncoding_()
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<int>([&](){
    #endif
        return Font::GetDefaultEncoding();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void Font_SetDefaultEncoding_(int encoding)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        Font::SetDefaultEncoding(encoding);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API int Font_GetWeight_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<int>([&](){
    #endif
        return obj->GetWeight();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void Font_Initialize_(Font* obj, GenericFontFamily genericFamily, const char16_t* familyName, double emSizeInPoints, FontStyle style)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->Initialize(genericFamily, ToOptional(familyName), emSizeInPoints, style);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void Font_InitializeWithDefaultFont_(Font* obj)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->InitializeWithDefaultFont();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void Font_InitializeWithDefaultMonoFont_(Font* obj)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->InitializeWithDefaultMonoFont();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void Font_InitializeFromFont_(Font* obj, Font* font)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->InitializeFromFont(font);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API c_bool Font_IsFamilyValid_(const char16_t* fontFamily)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return Font::IsFamilyValid(fontFamily);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API char16_t* Font_GetGenericFamilyName_(GenericFontFamily genericFamily)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<char16_t*>([&](){
    #endif
        return AllocPInvokeReturnString(Font::GetGenericFamilyName(genericFamily));
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API c_bool Font_IsEqualTo_(Font* obj, Font* other)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->IsEqualTo(other);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API char16_t* Font_Serialize_(Font* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<char16_t*>([&](){
    #endif
        return AllocPInvokeReturnString(obj->Serialize());
    #if !defined(__WXMSW__)
    });
    #endif
}

