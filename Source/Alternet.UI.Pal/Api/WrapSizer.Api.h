// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2023 AlterNET Software.</auto-generated>

#pragma once

#include "WrapSizer.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API WrapSizer* WrapSizer_Create_()
{
    return new WrapSizer();
}

ALTERNET_UI_API void* WrapSizer_CreateWrapSizer_(int orient, int flags)
{
    return WrapSizer::CreateWrapSizer(orient, flags);
}

ALTERNET_UI_API void WrapSizer_RepositionChildren_(void* handle, SizeI minSize)
{
    WrapSizer::RepositionChildren(handle, minSize);
}

ALTERNET_UI_API SizeI_C WrapSizer_CalcMin_(void* handle)
{
    return WrapSizer::CalcMin(handle);
}

