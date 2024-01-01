// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "WxStatusBarFactory.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API WxStatusBarFactory* WxStatusBarFactory_Create_()
{
    return new WxStatusBarFactory();
}

ALTERNET_UI_API void WxStatusBarFactory_DeleteStatusBar_(void* handle)
{
    WxStatusBarFactory::DeleteStatusBar(handle);
}

ALTERNET_UI_API void* WxStatusBarFactory_CreateStatusBar_(void* window, int64_t style)
{
    return WxStatusBarFactory::CreateStatusBar(window, style);
}

ALTERNET_UI_API int WxStatusBarFactory_GetFieldsCount_(void* handle)
{
    return WxStatusBarFactory::GetFieldsCount(handle);
}

ALTERNET_UI_API void WxStatusBarFactory_SetStatusText_(void* handle, const char16_t* text, int number)
{
    WxStatusBarFactory::SetStatusText(handle, text, number);
}

ALTERNET_UI_API char16_t* WxStatusBarFactory_GetStatusText_(void* handle, int number)
{
    return AllocPInvokeReturnString(WxStatusBarFactory::GetStatusText(handle, number));
}

ALTERNET_UI_API void WxStatusBarFactory_PushStatusText_(void* handle, const char16_t* text, int number)
{
    WxStatusBarFactory::PushStatusText(handle, text, number);
}

ALTERNET_UI_API void WxStatusBarFactory_PopStatusText_(void* handle, int number)
{
    WxStatusBarFactory::PopStatusText(handle, number);
}

ALTERNET_UI_API void WxStatusBarFactory_SetStatusWidths_(void* handle, int* widths, int widthsCount)
{
    WxStatusBarFactory::SetStatusWidths(handle, widths, widthsCount);
}

ALTERNET_UI_API void WxStatusBarFactory_SetFieldsCount_(void* handle, int number)
{
    WxStatusBarFactory::SetFieldsCount(handle, number);
}

ALTERNET_UI_API int WxStatusBarFactory_GetStatusWidth_(void* handle, int n)
{
    return WxStatusBarFactory::GetStatusWidth(handle, n);
}

ALTERNET_UI_API int WxStatusBarFactory_GetStatusStyle_(void* handle, int n)
{
    return WxStatusBarFactory::GetStatusStyle(handle, n);
}

ALTERNET_UI_API void WxStatusBarFactory_SetStatusStyles_(void* handle, int* styles, int stylesCount)
{
    WxStatusBarFactory::SetStatusStyles(handle, styles, stylesCount);
}

ALTERNET_UI_API RectI_C WxStatusBarFactory_GetFieldRect_(void* handle, int i)
{
    return WxStatusBarFactory::GetFieldRect(handle, i);
}

ALTERNET_UI_API void WxStatusBarFactory_SetMinHeight_(void* handle, int height)
{
    WxStatusBarFactory::SetMinHeight(handle, height);
}

ALTERNET_UI_API int WxStatusBarFactory_GetBorderX_(void* handle)
{
    return WxStatusBarFactory::GetBorderX(handle);
}

ALTERNET_UI_API int WxStatusBarFactory_GetBorderY_(void* handle)
{
    return WxStatusBarFactory::GetBorderY(handle);
}

