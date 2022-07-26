// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>

#pragma once

#include "FileDialog.h"
#include "Window.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API FileDialog* FileDialog_Create_()
{
    return MarshalExceptions<FileDialog*>([&](){
            return new FileDialog();
        });
}

ALTERNET_UI_API FileDialogMode FileDialog_GetMode_(FileDialog* obj)
{
    return MarshalExceptions<FileDialogMode>([&](){
            return obj->GetMode();
        });
}

ALTERNET_UI_API void FileDialog_SetMode_(FileDialog* obj, FileDialogMode value)
{
    MarshalExceptions<void>([&](){
            obj->SetMode(value);
        });
}

ALTERNET_UI_API char16_t* FileDialog_GetInitialDirectory_(FileDialog* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetInitialDirectory());
        });
}

ALTERNET_UI_API void FileDialog_SetInitialDirectory_(FileDialog* obj, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetInitialDirectory(ToOptional(value));
        });
}

ALTERNET_UI_API char16_t* FileDialog_GetTitle_(FileDialog* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetTitle());
        });
}

ALTERNET_UI_API void FileDialog_SetTitle_(FileDialog* obj, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetTitle(ToOptional(value));
        });
}

ALTERNET_UI_API char16_t* FileDialog_GetFilter_(FileDialog* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetFilter());
        });
}

ALTERNET_UI_API void FileDialog_SetFilter_(FileDialog* obj, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetFilter(ToOptional(value));
        });
}

ALTERNET_UI_API int FileDialog_GetSelectedFilterIndex_(FileDialog* obj)
{
    return MarshalExceptions<int>([&](){
            return obj->GetSelectedFilterIndex();
        });
}

ALTERNET_UI_API void FileDialog_SetSelectedFilterIndex_(FileDialog* obj, int value)
{
    MarshalExceptions<void>([&](){
            obj->SetSelectedFilterIndex(value);
        });
}

ALTERNET_UI_API char16_t* FileDialog_GetFileName_(FileDialog* obj)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetFileName());
        });
}

ALTERNET_UI_API void FileDialog_SetFileName_(FileDialog* obj, const char16_t* value)
{
    MarshalExceptions<void>([&](){
            obj->SetFileName(ToOptional(value));
        });
}

ALTERNET_UI_API c_bool FileDialog_GetAllowMultipleSelection_(FileDialog* obj)
{
    return MarshalExceptions<c_bool>([&](){
            return obj->GetAllowMultipleSelection();
        });
}

ALTERNET_UI_API void FileDialog_SetAllowMultipleSelection_(FileDialog* obj, c_bool value)
{
    MarshalExceptions<void>([&](){
            obj->SetAllowMultipleSelection(value);
        });
}

ALTERNET_UI_API void* FileDialog_OpenFileNamesArray_(FileDialog* obj)
{
    return MarshalExceptions<void*>([&](){
            return obj->OpenFileNamesArray();
        });
}

ALTERNET_UI_API int FileDialog_GetFileNamesItemCount_(FileDialog* obj, void* array)
{
    return MarshalExceptions<int>([&](){
            return obj->GetFileNamesItemCount(array);
        });
}

ALTERNET_UI_API char16_t* FileDialog_GetFileNamesItemAt_(FileDialog* obj, void* array, int index)
{
    return MarshalExceptions<char16_t*>([&](){
            return AllocPInvokeReturnString(obj->GetFileNamesItemAt(array, index));
        });
}

ALTERNET_UI_API void FileDialog_CloseFileNamesArray_(FileDialog* obj, void* array)
{
    MarshalExceptions<void>([&](){
            obj->CloseFileNamesArray(array);
        });
}

ALTERNET_UI_API ModalResult FileDialog_ShowModal_(FileDialog* obj, Window* owner)
{
    return MarshalExceptions<ModalResult>([&](){
            return obj->ShowModal(owner);
        });
}

