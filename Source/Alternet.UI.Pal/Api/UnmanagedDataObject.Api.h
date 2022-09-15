// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>

#pragma once

#include "UnmanagedDataObject.h"
#include "UnmanagedStream.h"
#include "InputStream.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API UnmanagedDataObject* UnmanagedDataObject_Create_()
{
    return MarshalExceptions<UnmanagedDataObject*>([&](){
            return new UnmanagedDataObject();
        });
}

ALTERNET_UI_API void* UnmanagedDataObject_OpenFormatsArray_(UnmanagedDataObject* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->OpenFormatsArray();
        });
}

ALTERNET_UI_API int UnmanagedDataObject_GetFormatsItemCount_(UnmanagedDataObject* obj, void* array)
{
    return MarshalExceptions<int>([&](){
            return obj->GetFormatsItemCount(array);
        });
}

ALTERNET_UI_API char16_t* UnmanagedDataObject_GetFormatsItemAt_(UnmanagedDataObject* obj, void* array, int index)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetFormatsItemAt(array, index));
        });
}

ALTERNET_UI_API void UnmanagedDataObject_CloseFormatsArray_(UnmanagedDataObject* obj, void* array)
{
    MarshalExceptions<void>([&](){
            obj->CloseFormatsArray(array);
        });
}

ALTERNET_UI_API char16_t* UnmanagedDataObject_GetStringData_(UnmanagedDataObject* obj, const char16_t* format)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetStringData(format));
        });
}

ALTERNET_UI_API char16_t* UnmanagedDataObject_GetFileNamesData_(UnmanagedDataObject* obj, const char16_t* format)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetFileNamesData(format));
        });
}

ALTERNET_UI_API UnmanagedStream* UnmanagedDataObject_GetStreamData_(UnmanagedDataObject* obj, const char16_t* format)
{
    return MarshalExceptions<UnmanagedStream*>([&](){
            return obj->GetStreamData(format);
        });
}

ALTERNET_UI_API void UnmanagedDataObject_SetStringData_(UnmanagedDataObject* obj, const char16_t* format, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetStringData(format, value);
        });
}

ALTERNET_UI_API void UnmanagedDataObject_SetFileNamesData_(UnmanagedDataObject* obj, const char16_t* format, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetFileNamesData(format, value);
        });
}

ALTERNET_UI_API void UnmanagedDataObject_SetStreamData_(UnmanagedDataObject* obj, const char16_t* format, void* value)
{
    MarshalExceptions<void>([&](){
            obj->SetStreamData(format, value);
        });
}

ALTERNET_UI_API c_bool UnmanagedDataObject_GetDataPresent_(UnmanagedDataObject* obj, const char16_t* format)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetDataPresent(format);
        });
}

