// Auto generated code, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2021.

#pragma once

#include "SolidBrush.h"
#include "ApiUtils.h"

using namespace Alternet::UI;

ALTERNET_UI_API SolidBrush* SolidBrush_Create_()
{
    return new SolidBrush();
}

ALTERNET_UI_API void SolidBrush_Initialize_(SolidBrush* obj, Color color)
{
    obj->Initialize(color);
}

