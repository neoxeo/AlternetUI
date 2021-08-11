// Auto generated code, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2021.

#pragma once

#include "Control.h"
#include "Font.h"
#include "DrawingContext.h"
#include "ApiUtils.h"

using namespace Alternet::UI;

ALTERNET_UI_API Control* Control_GetParent_(Control* obj)
{
    return obj->GetParent();
}

ALTERNET_UI_API SizeF_C Control_GetSize_(Control* obj)
{
    return obj->GetSize();
}

ALTERNET_UI_API void Control_SetSize_(Control* obj, SizeF value)
{
    obj->SetSize(value);
}

ALTERNET_UI_API PointF_C Control_GetLocation_(Control* obj)
{
    return obj->GetLocation();
}

ALTERNET_UI_API void Control_SetLocation_(Control* obj, PointF value)
{
    obj->SetLocation(value);
}

ALTERNET_UI_API RectangleF_C Control_GetBounds_(Control* obj)
{
    return obj->GetBounds();
}

ALTERNET_UI_API void Control_SetBounds_(Control* obj, RectangleF value)
{
    obj->SetBounds(value);
}

ALTERNET_UI_API SizeF_C Control_GetClientSize_(Control* obj)
{
    return obj->GetClientSize();
}

ALTERNET_UI_API void Control_SetClientSize_(Control* obj, SizeF value)
{
    obj->SetClientSize(value);
}

ALTERNET_UI_API Thickness_C Control_GetIntrinsicLayoutPadding_(Control* obj)
{
    return obj->GetIntrinsicLayoutPadding();
}

ALTERNET_UI_API Thickness_C Control_GetIntrinsicPreferredSizePadding_(Control* obj)
{
    return obj->GetIntrinsicPreferredSizePadding();
}

ALTERNET_UI_API c_bool Control_GetVisible_(Control* obj)
{
    return obj->GetVisible();
}

ALTERNET_UI_API void Control_SetVisible_(Control* obj, c_bool value)
{
    obj->SetVisible(value);
}

ALTERNET_UI_API c_bool Control_GetIsMouseOver_(Control* obj)
{
    return obj->GetIsMouseOver();
}

ALTERNET_UI_API Color_C Control_GetBackgroundColor_(Control* obj)
{
    return obj->GetBackgroundColor();
}

ALTERNET_UI_API void Control_SetBackgroundColor_(Control* obj, Color value)
{
    obj->SetBackgroundColor(value);
}

ALTERNET_UI_API Color_C Control_GetForegroundColor_(Control* obj)
{
    return obj->GetForegroundColor();
}

ALTERNET_UI_API void Control_SetForegroundColor_(Control* obj, Color value)
{
    obj->SetForegroundColor(value);
}

ALTERNET_UI_API Font* Control_GetFont_(Control* obj)
{
    return obj->GetFont();
}

ALTERNET_UI_API void Control_SetFont_(Control* obj, Font* value)
{
    obj->SetFont(value);
}

ALTERNET_UI_API void Control_SetMouseCapture_(Control* obj, c_bool value)
{
    obj->SetMouseCapture(value);
}

ALTERNET_UI_API void Control_AddChild_(Control* obj, Control* control)
{
    obj->AddChild(control);
}

ALTERNET_UI_API void Control_RemoveChild_(Control* obj, Control* control)
{
    obj->RemoveChild(control);
}

ALTERNET_UI_API void Control_Update_(Control* obj)
{
    obj->Update();
}

ALTERNET_UI_API SizeF_C Control_GetPreferredSize_(Control* obj, SizeF availableSize)
{
    return obj->GetPreferredSize(availableSize);
}

ALTERNET_UI_API DrawingContext* Control_OpenPaintDrawingContext_(Control* obj)
{
    return obj->OpenPaintDrawingContext();
}

ALTERNET_UI_API DrawingContext* Control_OpenClientDrawingContext_(Control* obj)
{
    return obj->OpenClientDrawingContext();
}

ALTERNET_UI_API void Control_BeginUpdate_(Control* obj)
{
    obj->BeginUpdate();
}

ALTERNET_UI_API void Control_EndUpdate_(Control* obj)
{
    obj->EndUpdate();
}

ALTERNET_UI_API void Control_SetEventCallback_(Control::ControlEventCallbackType callback)
{
    Control::SetEventCallback(callback);
}

