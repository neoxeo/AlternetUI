// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2021.</auto-generated>

#pragma once

#include "Pen.h"
#include "ApiUtils.h"

using namespace Alternet::UI;

ALTERNET_UI_API Pen* Pen_Create_()
{
    return new Pen();
}

ALTERNET_UI_API void Pen_Initialize_(Pen* obj, PenDashStyle style, Color color, float width)
{
    obj->Initialize(style, color, width);
}

