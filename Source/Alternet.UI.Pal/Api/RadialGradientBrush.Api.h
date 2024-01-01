// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "RadialGradientBrush.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API RadialGradientBrush* RadialGradientBrush_Create_()
{
    return new RadialGradientBrush();
}

ALTERNET_UI_API void RadialGradientBrush_Initialize_(RadialGradientBrush* obj, PointD center, double radius, PointD gradientOrigin, Color* gradientStopsColors, int gradientStopsColorsCount, double* gradientStopsOffsets, int gradientStopsOffsetsCount)
{
    obj->Initialize(center, radius, gradientOrigin, gradientStopsColors, gradientStopsColorsCount, gradientStopsOffsets, gradientStopsOffsetsCount);
}

