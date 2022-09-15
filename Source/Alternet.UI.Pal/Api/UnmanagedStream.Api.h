// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>

#pragma once

#include "UnmanagedStream.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API UnmanagedStream* UnmanagedStream_Create_()
{
    return MarshalExceptions<UnmanagedStream*>([&](){
            return new UnmanagedStream();
        });
}

ALTERNET_UI_API int64_t UnmanagedStream_GetLength_(UnmanagedStream* obj)
{
    return MarshalExceptions<int64_t>([&](){
            return obj->GetLength();
        });
}

ALTERNET_UI_API c_bool UnmanagedStream_GetIsOK_(UnmanagedStream* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetIsOK();
        });
}

ALTERNET_UI_API c_bool UnmanagedStream_GetIsSeekable_(UnmanagedStream* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetIsSeekable();
        });
}

ALTERNET_UI_API int64_t UnmanagedStream_GetPosition_(UnmanagedStream* obj)
{
    return MarshalExceptions<int64_t>([&](){
            return obj->GetPosition();
        });
}

ALTERNET_UI_API void UnmanagedStream_SetPosition_(UnmanagedStream* obj, int64_t value)
{
    MarshalExceptions<void>([&](){
            obj->SetPosition(value);
        });
}

ALTERNET_UI_API void* UnmanagedStream_Read_(UnmanagedStream* obj, void* buffer, int bufferCount, void* length)
{
    return MarshalExceptions<void*>([&](){
            return obj->Read(buffer, bufferCount, length);
        });
}

