// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "GridBagSizer.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API GridBagSizer* GridBagSizer_Create_()
{
    return new GridBagSizer();
}

ALTERNET_UI_API void* GridBagSizer_CreateGridBagSizer_(int vgap, int hgap)
{
    return GridBagSizer::CreateGridBagSizer(vgap, hgap);
}

ALTERNET_UI_API SizeI_C GridBagSizer_CalcMin_(void* handle)
{
    return GridBagSizer::CalcMin(handle);
}

ALTERNET_UI_API void* GridBagSizer_FindItemAtPoint_(void* handle, PointI pt)
{
    return GridBagSizer::FindItemAtPoint(handle, pt);
}

ALTERNET_UI_API void* GridBagSizer_FindItemAtPosition_(void* handle, PointI pos)
{
    return GridBagSizer::FindItemAtPosition(handle, pos);
}

ALTERNET_UI_API void* GridBagSizer_FindItemWithData_(void* handle, void* userData)
{
    return GridBagSizer::FindItemWithData(handle, userData);
}

ALTERNET_UI_API SizeI_C GridBagSizer_GetCellSize_(void* handle, int row, int col)
{
    return GridBagSizer::GetCellSize(handle, row, col);
}

ALTERNET_UI_API SizeI_C GridBagSizer_GetEmptyCellSize_(void* handle)
{
    return GridBagSizer::GetEmptyCellSize(handle);
}

ALTERNET_UI_API void GridBagSizer_RepositionChildren_(void* handle, SizeI minSize)
{
    GridBagSizer::RepositionChildren(handle, minSize);
}

ALTERNET_UI_API void GridBagSizer_SetEmptyCellSize_(void* handle, SizeI sz)
{
    GridBagSizer::SetEmptyCellSize(handle, sz);
}

ALTERNET_UI_API void* GridBagSizer_Add_(void* handle, void* window, PointI pos, SizeI span, int flag, int border, void* userData)
{
    return GridBagSizer::Add(handle, window, pos, span, flag, border, userData);
}

ALTERNET_UI_API void* GridBagSizer_Add2_(void* handle, void* sizer, PointI pos, SizeI span, int flag, int border, void* userData)
{
    return GridBagSizer::Add2(handle, sizer, pos, span, flag, border, userData);
}

ALTERNET_UI_API void* GridBagSizer_Add3_(void* handle, void* item)
{
    return GridBagSizer::Add3(handle, item);
}

ALTERNET_UI_API void* GridBagSizer_Add4_(void* handle, int width, int height, PointI pos, SizeI span, int flag, int border, void* userData)
{
    return GridBagSizer::Add4(handle, width, height, pos, span, flag, border, userData);
}

ALTERNET_UI_API c_bool GridBagSizer_CheckForIntersection_(void* handle, void* item, void* excludeItem)
{
    return GridBagSizer::CheckForIntersection(handle, item, excludeItem);
}

ALTERNET_UI_API c_bool GridBagSizer_CheckForIntersection2_(void* handle, PointI pos, SizeI span, void* excludeItem)
{
    return GridBagSizer::CheckForIntersection2(handle, pos, span, excludeItem);
}

ALTERNET_UI_API void* GridBagSizer_FindItem_(void* handle, void* window)
{
    return GridBagSizer::FindItem(handle, window);
}

ALTERNET_UI_API void* GridBagSizer_FindItem2_(void* handle, void* sizer)
{
    return GridBagSizer::FindItem2(handle, sizer);
}

ALTERNET_UI_API PointI_C GridBagSizer_GetItemPosition_(void* handle, void* window)
{
    return GridBagSizer::GetItemPosition(handle, window);
}

ALTERNET_UI_API PointI_C GridBagSizer_GetItemPosition2_(void* handle, void* sizer)
{
    return GridBagSizer::GetItemPosition2(handle, sizer);
}

ALTERNET_UI_API PointI_C GridBagSizer_GetItemPosition3_(void* handle, int index)
{
    return GridBagSizer::GetItemPosition3(handle, index);
}

ALTERNET_UI_API PointI_C GridBagSizer_GetItemSpan_(void* handle, void* window)
{
    return GridBagSizer::GetItemSpan(handle, window);
}

ALTERNET_UI_API PointI_C GridBagSizer_GetItemSpan2_(void* handle, void* sizer)
{
    return GridBagSizer::GetItemSpan2(handle, sizer);
}

ALTERNET_UI_API PointI_C GridBagSizer_GetItemSpan3_(void* handle, int index)
{
    return GridBagSizer::GetItemSpan3(handle, index);
}

ALTERNET_UI_API c_bool GridBagSizer_SetItemPosition_(void* handle, void* window, PointI pos)
{
    return GridBagSizer::SetItemPosition(handle, window, pos);
}

ALTERNET_UI_API c_bool GridBagSizer_SetItemPosition2_(void* handle, void* sizer, PointI pos)
{
    return GridBagSizer::SetItemPosition2(handle, sizer, pos);
}

ALTERNET_UI_API c_bool GridBagSizer_SetItemPosition3_(void* handle, int index, PointI pos)
{
    return GridBagSizer::SetItemPosition3(handle, index, pos);
}

ALTERNET_UI_API c_bool GridBagSizer_SetItemSpan_(void* handle, void* window, SizeI span)
{
    return GridBagSizer::SetItemSpan(handle, window, span);
}

ALTERNET_UI_API c_bool GridBagSizer_SetItemSpan2_(void* handle, void* sizer, SizeI span)
{
    return GridBagSizer::SetItemSpan2(handle, sizer, span);
}

ALTERNET_UI_API c_bool GridBagSizer_SetItemSpan3_(void* handle, int index, SizeI span)
{
    return GridBagSizer::SetItemSpan3(handle, index, span);
}

