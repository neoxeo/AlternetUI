// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "UnmanagedStream.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API UnmanagedStream* UnmanagedStream_Create_()
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<UnmanagedStream*>([&](){
    #endif
        return new UnmanagedStream();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API int64_t UnmanagedStream_GetLength_(UnmanagedStream* obj)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<int64_t>([&](){
    #endif
        return obj->GetLength();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API c_bool UnmanagedStream_GetIsOK_(UnmanagedStream* obj)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->GetIsOK();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API c_bool UnmanagedStream_GetIsSeekable_(UnmanagedStream* obj)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->GetIsSeekable();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API int64_t UnmanagedStream_GetPosition_(UnmanagedStream* obj)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<int64_t>([&](){
    #endif
        return obj->GetPosition();
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void UnmanagedStream_SetPosition_(UnmanagedStream* obj, int64_t value)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetPosition(value);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

ALTERNET_UI_API void* UnmanagedStream_Read_(UnmanagedStream* obj, void* buffer, int bufferCount, void* length)
{
    #if !defined(__WXMSW__) || defined(_DEBUG)
    return MarshalExceptions<void*>([&](){
    #endif
        return obj->Read(buffer, bufferCount, length);
    #if !defined(__WXMSW__) || defined(_DEBUG)
    });
    #endif
}

