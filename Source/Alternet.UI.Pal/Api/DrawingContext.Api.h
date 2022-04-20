// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>

#pragma once

#include "DrawingContext.h"
#include "Brush.h"
#include "Pen.h"
#include "Font.h"
#include "Image.h"
#include "ApiUtils.h"

using namespace Alternet::UI;

ALTERNET_UI_API void DrawingContext_FillRectangle_(DrawingContext* obj, Rect rectangle, Brush* brush)
{
    obj->FillRectangle(rectangle, brush);
}

ALTERNET_UI_API void DrawingContext_DrawRectangle_(DrawingContext* obj, Rect rectangle, Pen* pen)
{
    obj->DrawRectangle(rectangle, pen);
}

ALTERNET_UI_API void DrawingContext_FillEllipse_(DrawingContext* obj, Rect bounds, Brush* brush)
{
    obj->FillEllipse(bounds, brush);
}

ALTERNET_UI_API void DrawingContext_DrawEllipse_(DrawingContext* obj, Rect bounds, Pen* pen)
{
    obj->DrawEllipse(bounds, pen);
}

ALTERNET_UI_API void DrawingContext_DrawText_(DrawingContext* obj, const char16_t* text, Point origin, Font* font, Brush* brush)
{
    obj->DrawText(text, origin, font, brush);
}

ALTERNET_UI_API void DrawingContext_DrawImage_(DrawingContext* obj, Image* image, Point origin)
{
    obj->DrawImage(image, origin);
}

ALTERNET_UI_API Size_C DrawingContext_MeasureText_(DrawingContext* obj, const char16_t* text, Font* font)
{
    return obj->MeasureText(text, font);
}

ALTERNET_UI_API void DrawingContext_PushTransform_(DrawingContext* obj, Size translation)
{
    obj->PushTransform(translation);
}

ALTERNET_UI_API void DrawingContext_Pop_(DrawingContext* obj)
{
    obj->Pop();
}

ALTERNET_UI_API void DrawingContext_DrawLine_(DrawingContext* obj, Point a, Point b, Pen* pen)
{
    obj->DrawLine(a, b, pen);
}

ALTERNET_UI_API void DrawingContext_DrawLines_(DrawingContext* obj, Point* points, int pointsCount, Pen* pen)
{
    obj->DrawLines(points, pointsCount, pen);
}

