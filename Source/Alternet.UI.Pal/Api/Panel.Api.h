// Auto generated code, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2021.

#pragma once

#include "Panel.h"
#include "ApiUtils.h"

using namespace Alternet::UI;

ALTERNET_UI_API Panel* Panel_Create()
{
    return new Panel();
}

ALTERNET_UI_API void Panel_Destroy(Panel* obj)
{
    delete obj;
}

