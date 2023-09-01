// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>

#pragma once

#include "PropertyGridVariant.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API PropertyGridVariant* PropertyGridVariant_Create_()
{
    return MarshalExceptions<PropertyGridVariant*>([&](){
            return new PropertyGridVariant();
        });
}

ALTERNET_UI_API void PropertyGridVariant_Delete_(void* handle)
{
    MarshalExceptions<void>([&](){
            PropertyGridVariant::Delete(handle);
        });
}

ALTERNET_UI_API void* PropertyGridVariant_CreateVariant_()
{
    return MarshalExceptions<void*>([&](){
            return PropertyGridVariant::CreateVariant();
        });
}

ALTERNET_UI_API c_bool PropertyGridVariant_IsNull_(void* handle)
{
    return MarshalExceptions<c_bool>([&](){
            return PropertyGridVariant::IsNull(handle);
        });
}

ALTERNET_UI_API c_bool PropertyGridVariant_Unshare_(void* handle)
{
    return MarshalExceptions<c_bool>([&](){
            return PropertyGridVariant::Unshare(handle);
        });
}

ALTERNET_UI_API void PropertyGridVariant_MakeNull_(void* handle)
{
    MarshalExceptions<void>([&](){
            PropertyGridVariant::MakeNull(handle);
        });
}

ALTERNET_UI_API void PropertyGridVariant_Clear_(void* handle)
{
    MarshalExceptions<void>([&](){
            PropertyGridVariant::Clear(handle);
        });
}

ALTERNET_UI_API char16_t* PropertyGridVariant_GetValueType_(void* handle)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(PropertyGridVariant::GetValueType(handle));
        });
}

ALTERNET_UI_API c_bool PropertyGridVariant_IsType_(void* handle, const char16_t* type)
{
    return MarshalExceptions<c_bool>([&](){
            return PropertyGridVariant::IsType(handle, type);
        });
}

ALTERNET_UI_API char16_t* PropertyGridVariant_MakeString_(void* handle)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(PropertyGridVariant::MakeString(handle));
        });
}

ALTERNET_UI_API Color_C PropertyGridVariant_GetColor_(void* handle)
{
    return MarshalExceptions<Color_C>([&](){
            return PropertyGridVariant::GetColor(handle);
        });
}

ALTERNET_UI_API double PropertyGridVariant_GetDouble_(void* handle)
{
    return MarshalExceptions<double>([&](){
            return PropertyGridVariant::GetDouble(handle);
        });
}

ALTERNET_UI_API c_bool PropertyGridVariant_GetBool_(void* handle)
{
    return MarshalExceptions<c_bool>([&](){
            return PropertyGridVariant::GetBool(handle);
        });
}

ALTERNET_UI_API int64_t PropertyGridVariant_GetLong_(void* handle)
{
    return MarshalExceptions<int64_t>([&](){
            return PropertyGridVariant::GetLong(handle);
        });
}

ALTERNET_UI_API uint64_t PropertyGridVariant_GetULong_(void* handle)
{
    return MarshalExceptions<uint64_t>([&](){
            return PropertyGridVariant::GetULong(handle);
        });
}

ALTERNET_UI_API DateTime_C PropertyGridVariant_GetDateTime_(void* handle)
{
    return MarshalExceptions<DateTime_C>([&](){
            return PropertyGridVariant::GetDateTime(handle);
        });
}

ALTERNET_UI_API char16_t* PropertyGridVariant_GetString_(void* handle)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(PropertyGridVariant::GetString(handle));
        });
}

ALTERNET_UI_API void PropertyGridVariant_SetColor_(void* handle, Color val)
{
    MarshalExceptions<void>([&](){
            PropertyGridVariant::SetColor(handle, val);
        });
}

ALTERNET_UI_API void PropertyGridVariant_SetDouble_(void* handle, double val)
{
    MarshalExceptions<void>([&](){
            PropertyGridVariant::SetDouble(handle, val);
        });
}

ALTERNET_UI_API void PropertyGridVariant_SetBool_(void* handle, c_bool val)
{
    MarshalExceptions<void>([&](){
            PropertyGridVariant::SetBool(handle, val);
        });
}

ALTERNET_UI_API void PropertyGridVariant_SetLong_(void* handle, int64_t val)
{
    MarshalExceptions<void>([&](){
            PropertyGridVariant::SetLong(handle, val);
        });
}

ALTERNET_UI_API void PropertyGridVariant_SetULong_(void* handle, uint64_t val)
{
    MarshalExceptions<void>([&](){
            PropertyGridVariant::SetULong(handle, val);
        });
}

ALTERNET_UI_API void PropertyGridVariant_SetInt_(void* handle, int val)
{
    MarshalExceptions<void>([&](){
            PropertyGridVariant::SetInt(handle, val);
        });
}

ALTERNET_UI_API void PropertyGridVariant_SetShort_(void* handle, int16_t val)
{
    MarshalExceptions<void>([&](){
            PropertyGridVariant::SetShort(handle, val);
        });
}

ALTERNET_UI_API void PropertyGridVariant_SetDateTime_(void* handle, DateTime val)
{
    MarshalExceptions<void>([&](){
            PropertyGridVariant::SetDateTime(handle, val);
        });
}

ALTERNET_UI_API void PropertyGridVariant_SetString_(void* handle, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            PropertyGridVariant::SetString(handle, value);
        });
}
