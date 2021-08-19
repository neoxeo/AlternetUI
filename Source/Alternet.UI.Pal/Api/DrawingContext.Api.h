// Auto generated code, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2021.

#pragma once

#include "DrawingContext.h"
#include "Brush.h"
#include "Pen.h"
#include "Font.h"
#include "Image.h"
#include "ApiUtils.h"

using namespace Alternet::UI;

ALTERNET_UI_API void DrawingContext_FillRectangle_(DrawingContext* obj, RectangleF rectangle, Brush* brush)
{
    obj->FillRectangle(rectangle, brush);
}

ALTERNET_UI_API void DrawingContext_DrawRectangle_(DrawingContext* obj, RectangleF rectangle, Pen* pen)
{
    obj->DrawRectangle(rectangle, pen);
}

ALTERNET_UI_API void DrawingContext_FillEllipse_(DrawingContext* obj, RectangleF bounds, Brush* brush)
{
    obj->FillEllipse(bounds, brush);
}

ALTERNET_UI_API void DrawingContext_DrawEllipse_(DrawingContext* obj, RectangleF bounds, Pen* pen)
{
    obj->DrawEllipse(bounds, pen);
}

ALTERNET_UI_API void DrawingContext_DrawText_(DrawingContext* obj, const char16_t* text, PointF origin, Font* font, Brush* brush)
{
    obj->DrawText(text, origin, font, brush);
}

ALTERNET_UI_API void DrawingContext_DrawImage_(DrawingContext* obj, Image* image, PointF origin)
{
    obj->DrawImage(image, origin);
}

ALTERNET_UI_API SizeF_C DrawingContext_MeasureText_(DrawingContext* obj, const char16_t* text, Font* font)
{
    return obj->MeasureText(text, font);
}

ALTERNET_UI_API void DrawingContext_PushTransform_(DrawingContext* obj, SizeF translation)
{
    obj->PushTransform(translation);
}

ALTERNET_UI_API void DrawingContext_Pop_(DrawingContext* obj)
{
    obj->Pop();
}

