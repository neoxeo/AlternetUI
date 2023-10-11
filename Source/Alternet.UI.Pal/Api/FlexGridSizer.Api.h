// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2023 AlterNET Software.</auto-generated>

#pragma once

#include "FlexGridSizer.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API FlexGridSizer* FlexGridSizer_Create_()
{
    return new FlexGridSizer();
}

ALTERNET_UI_API void FlexGridSizer_AddGrowableCol_(void* handle, int idx, int proportion)
{
    FlexGridSizer::AddGrowableCol(handle, idx, proportion);
}

ALTERNET_UI_API void FlexGridSizer_AddGrowableRow_(void* handle, int idx, int proportion)
{
    FlexGridSizer::AddGrowableRow(handle, idx, proportion);
}

ALTERNET_UI_API int FlexGridSizer_GetFlexibleDirection_(void* handle)
{
    return FlexGridSizer::GetFlexibleDirection(handle);
}

ALTERNET_UI_API int FlexGridSizer_GetNonFlexibleGrowMode_(void* handle)
{
    return FlexGridSizer::GetNonFlexibleGrowMode(handle);
}

ALTERNET_UI_API c_bool FlexGridSizer_IsColGrowable_(void* handle, int idx)
{
    return FlexGridSizer::IsColGrowable(handle, idx);
}

ALTERNET_UI_API c_bool FlexGridSizer_IsRowGrowable_(void* handle, int idx)
{
    return FlexGridSizer::IsRowGrowable(handle, idx);
}

ALTERNET_UI_API void FlexGridSizer_RemoveGrowableCol_(void* handle, int idx)
{
    FlexGridSizer::RemoveGrowableCol(handle, idx);
}

ALTERNET_UI_API void FlexGridSizer_RemoveGrowableRow_(void* handle, int idx)
{
    FlexGridSizer::RemoveGrowableRow(handle, idx);
}

ALTERNET_UI_API void FlexGridSizer_SetFlexibleDirection_(void* handle, int direction)
{
    FlexGridSizer::SetFlexibleDirection(handle, direction);
}

ALTERNET_UI_API void FlexGridSizer_SetNonFlexibleGrowMode_(void* handle, int mode)
{
    FlexGridSizer::SetNonFlexibleGrowMode(handle, mode);
}

ALTERNET_UI_API void* FlexGridSizer_GetRowHeights_(void* handle)
{
    return FlexGridSizer::GetRowHeights(handle);
}

ALTERNET_UI_API void* FlexGridSizer_GetColWidths_(void* handle)
{
    return FlexGridSizer::GetColWidths(handle);
}

ALTERNET_UI_API void FlexGridSizer_RepositionChildren_(void* handle, Int32Size minSize)
{
    FlexGridSizer::RepositionChildren(handle, minSize);
}

ALTERNET_UI_API Int32Size_C FlexGridSizer_CalcMin_(void* handle)
{
    return FlexGridSizer::CalcMin(handle);
}

ALTERNET_UI_API void* FlexGridSizer_CreateFlexGridSizer_(int cols, int vgap, int hgap)
{
    return FlexGridSizer::CreateFlexGridSizer(cols, vgap, hgap);
}

ALTERNET_UI_API void* FlexGridSizer_CreateFlexGridSizer2_(int rows, int cols, int vgap, int hgap)
{
    return FlexGridSizer::CreateFlexGridSizer2(rows, cols, vgap, hgap);
}

