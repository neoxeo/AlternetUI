// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "Image.h"
#include "InputStream.h"
#include "OutputStream.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API Image* Image_Create_()
{
    return new Image();
}

ALTERNET_UI_API double Image_GetScaleFactor_(Image* obj)
{
    return obj->GetScaleFactor();
}

ALTERNET_UI_API void Image_SetScaleFactor_(Image* obj, double value)
{
    obj->SetScaleFactor(value);
}

ALTERNET_UI_API SizeI_C Image_GetDipSize_(Image* obj)
{
    return obj->GetDipSize();
}

ALTERNET_UI_API double Image_GetScaledHeight_(Image* obj)
{
    return obj->GetScaledHeight();
}

ALTERNET_UI_API SizeI_C Image_GetScaledSize_(Image* obj)
{
    return obj->GetScaledSize();
}

ALTERNET_UI_API double Image_GetScaledWidth_(Image* obj)
{
    return obj->GetScaledWidth();
}

ALTERNET_UI_API SizeI_C Image_GetPixelSize_(Image* obj)
{
    return obj->GetPixelSize();
}

ALTERNET_UI_API c_bool Image_GetIsOk_(Image* obj)
{
    return obj->GetIsOk();
}

ALTERNET_UI_API c_bool Image_GetHasAlpha_(Image* obj)
{
    return obj->GetHasAlpha();
}

ALTERNET_UI_API void Image_SetHasAlpha_(Image* obj, c_bool value)
{
    obj->SetHasAlpha(value);
}

ALTERNET_UI_API int Image_GetPixelWidth_(Image* obj)
{
    return obj->GetPixelWidth();
}

ALTERNET_UI_API int Image_GetPixelHeight_(Image* obj)
{
    return obj->GetPixelHeight();
}

ALTERNET_UI_API int Image_GetDepth_(Image* obj)
{
    return obj->GetDepth();
}

ALTERNET_UI_API c_bool Image_InitializeFromDipSize_(Image* obj, int width, int height, double scale, int depth)
{
    return obj->InitializeFromDipSize(width, height, scale, depth);
}

ALTERNET_UI_API c_bool Image_InitializeFromScreen_(Image* obj)
{
    return obj->InitializeFromScreen();
}

ALTERNET_UI_API c_bool Image_LoadFromStream_(Image* obj, void* stream)
{
    return obj->LoadFromStream(stream);
}

ALTERNET_UI_API c_bool Image_LoadSvgFromStream_(Image* obj, void* stream, int width, int height, Color color)
{
    return obj->LoadSvgFromStream(stream, width, height, color);
}

ALTERNET_UI_API c_bool Image_LoadSvgFromString_(Image* obj, const char16_t* s, int width, int height, Color color)
{
    return obj->LoadSvgFromString(s, width, height, color);
}

ALTERNET_UI_API void Image_Initialize_(Image* obj, SizeI size, int depth)
{
    obj->Initialize(size, depth);
}

ALTERNET_UI_API void Image_InitializeFromImage_(Image* obj, Image* source, SizeI size)
{
    obj->InitializeFromImage(source, size);
}

ALTERNET_UI_API void Image_CopyFrom_(Image* obj, Image* otherImage)
{
    obj->CopyFrom(otherImage);
}

ALTERNET_UI_API c_bool Image_SaveToStream_(Image* obj, void* stream, const char16_t* format)
{
    return obj->SaveToStream(stream, format);
}

ALTERNET_UI_API c_bool Image_SaveToFile_(Image* obj, const char16_t* fileName)
{
    return obj->SaveToFile(fileName);
}

ALTERNET_UI_API void* Image_ConvertToGenericImage_(Image* obj)
{
    return obj->ConvertToGenericImage();
}

ALTERNET_UI_API void Image_LoadFromGenericImage_(Image* obj, void* image, int depth)
{
    obj->LoadFromGenericImage(image, depth);
}

ALTERNET_UI_API c_bool Image_GrayScale_(Image* obj)
{
    return obj->GrayScale();
}

ALTERNET_UI_API void Image_ResetAlpha_(Image* obj)
{
    obj->ResetAlpha();
}

ALTERNET_UI_API c_bool Image_LoadFile_(Image* obj, const char16_t* name, int type)
{
    return obj->LoadFile(name, type);
}

ALTERNET_UI_API c_bool Image_SaveFile_(Image* obj, const char16_t* name, int type)
{
    return obj->SaveFile(name, type);
}

ALTERNET_UI_API c_bool Image_SaveStream_(Image* obj, void* stream, int type)
{
    return obj->SaveStream(stream, type);
}

ALTERNET_UI_API c_bool Image_LoadStream_(Image* obj, void* stream, int type)
{
    return obj->LoadStream(stream, type);
}

ALTERNET_UI_API Image* Image_GetSubBitmap_(Image* obj, RectI rect)
{
    return obj->GetSubBitmap(rect);
}

ALTERNET_UI_API Image* Image_ConvertToDisabled_(Image* obj, uint8_t brightness)
{
    return obj->ConvertToDisabled(brightness);
}

ALTERNET_UI_API void Image_Rescale_(Image* obj, SizeI sizeNeeded)
{
    obj->Rescale(sizeNeeded);
}

ALTERNET_UI_API int Image_GetDefaultBitmapType_()
{
    return Image::GetDefaultBitmapType();
}

