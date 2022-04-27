// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>

#pragma once

#include "ImageList.h"
#include "Image.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API ImageList* ImageList_Create_()
{
    return MarshalExceptions<ImageList*>([&](){
            return new ImageList();
        });
}

ALTERNET_UI_API Int32Size_C ImageList_GetPixelImageSize_(ImageList* obj)
{
    return MarshalExceptions<Int32Size_C>([&](){
            return obj->GetPixelImageSize();
        });
}

ALTERNET_UI_API void ImageList_SetPixelImageSize_(ImageList* obj, Int32Size value)
{
    MarshalExceptions<void>([&](){
            obj->SetPixelImageSize(value);
        });
}

ALTERNET_UI_API Size_C ImageList_GetImageSize_(ImageList* obj)
{
    return MarshalExceptions<Size_C>([&](){
            return obj->GetImageSize();
        });
}

ALTERNET_UI_API void ImageList_SetImageSize_(ImageList* obj, Size value)
{
    MarshalExceptions<void>([&](){
            obj->SetImageSize(value);
        });
}

ALTERNET_UI_API void ImageList_AddImage_(ImageList* obj, Image* image)
{
    MarshalExceptions<void>([&](){
            obj->AddImage(image);
        });
}

