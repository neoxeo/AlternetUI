// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>

#pragma once

#include "DrawingContext.h"
#include "TransformMatrix.h"
#include "Region.h"
#include "Font.h"
#include "Image.h"
#include "Pen.h"
#include "Brush.h"
#include "GraphicsPath.h"
#include "ApiUtils.h"
#include "Exceptions.h"

using namespace Alternet::UI;

ALTERNET_UI_API c_bool DrawingContext_GetIsOk_(DrawingContext* obj)
{
    return obj->GetIsOk();
}

ALTERNET_UI_API void* DrawingContext_GetWxWidgetDC_(DrawingContext* obj)
{
    return obj->GetWxWidgetDC();
}

ALTERNET_UI_API TransformMatrix* DrawingContext_GetTransform_(DrawingContext* obj)
{
    return obj->GetTransform();
}

ALTERNET_UI_API void DrawingContext_SetTransform_(DrawingContext* obj, TransformMatrix* value)
{
    obj->SetTransform(value);
}

ALTERNET_UI_API Region* DrawingContext_GetClip_(DrawingContext* obj)
{
    return obj->GetClip();
}

ALTERNET_UI_API void DrawingContext_SetClip_(DrawingContext* obj, Region* value)
{
    obj->SetClip(value);
}

ALTERNET_UI_API InterpolationMode DrawingContext_GetInterpolationMode_(DrawingContext* obj)
{
    return obj->GetInterpolationMode();
}

ALTERNET_UI_API void DrawingContext_SetInterpolationMode_(DrawingContext* obj, InterpolationMode value)
{
    obj->SetInterpolationMode(value);
}

ALTERNET_UI_API void* DrawingContext_GetHandle_(DrawingContext* obj)
{
    return obj->GetHandle();
}

ALTERNET_UI_API void DrawingContext_DrawRotatedTextI_(DrawingContext* obj, const char16_t* text, PointI location, Font* font, Color foreColor, Color backColor, double angle)
{
    obj->DrawRotatedTextI(text, location, font, foreColor, backColor, angle);
}

ALTERNET_UI_API Image* DrawingContext_GetAsBitmapI_(DrawingContext* obj, RectI subrect)
{
    return obj->GetAsBitmapI(subrect);
}

ALTERNET_UI_API c_bool DrawingContext_BlitI_(DrawingContext* obj, PointI destPt, SizeI sz, DrawingContext* source, PointI srcPt, int rop, c_bool useMask, PointI srcPtMask)
{
    return obj->BlitI(destPt, sz, source, srcPt, rop, useMask, srcPtMask);
}

ALTERNET_UI_API c_bool DrawingContext_StretchBlitI_(DrawingContext* obj, PointI dstPt, SizeI dstSize, DrawingContext* source, PointI srcPt, SizeI srcSize, int rop, c_bool useMask, PointI srcMaskPt)
{
    return obj->StretchBlitI(dstPt, dstSize, source, srcPt, srcSize, rop, useMask, srcMaskPt);
}

ALTERNET_UI_API RectD_C DrawingContext_DrawLabel_(DrawingContext* obj, const char16_t* text, Font* font, Color foreColor, Color backColor, Image* image, RectD rect, int alignment, int indexAccel)
{
    return obj->DrawLabel(text, font, foreColor, backColor, image, rect, alignment, indexAccel);
}

ALTERNET_UI_API void DrawingContext_DestroyClippingRegion_(DrawingContext* obj)
{
    obj->DestroyClippingRegion();
}

ALTERNET_UI_API void DrawingContext_SetClippingRegion_(DrawingContext* obj, RectD rect)
{
    obj->SetClippingRegion(rect);
}

ALTERNET_UI_API RectD_C DrawingContext_GetClippingBox_(DrawingContext* obj)
{
    return obj->GetClippingBox();
}

ALTERNET_UI_API void DrawingContext_DrawText_(DrawingContext* obj, const char16_t* text, PointD location, Font* font, Color foreColor, Color backColor)
{
    obj->DrawText(text, location, font, foreColor, backColor);
}

ALTERNET_UI_API SizeD_C DrawingContext_GetDpi_(DrawingContext* obj)
{
    return obj->GetDpi();
}

ALTERNET_UI_API void DrawingContext_ImageFromDrawingContext_(Image* image, int width, int height, DrawingContext* dc)
{
    DrawingContext::ImageFromDrawingContext(image, width, height, dc);
}

ALTERNET_UI_API void DrawingContext_ImageFromGenericImageDC_(Image* image, void* source, DrawingContext* dc)
{
    DrawingContext::ImageFromGenericImageDC(image, source, dc);
}

ALTERNET_UI_API void DrawingContext_GetPartialTextExtents_(DrawingContext* obj, const char16_t* text, double* widths, int widthsCount, Font* font, void* control)
{
    obj->GetPartialTextExtents(text, widths, widthsCount, font, control);
}

ALTERNET_UI_API RectD_C DrawingContext_GetTextExtent_(DrawingContext* obj, const char16_t* text, Font* font, void* control)
{
    return obj->GetTextExtent(text, font, control);
}

ALTERNET_UI_API SizeD_C DrawingContext_GetTextExtentSimple_(DrawingContext* obj, const char16_t* text, Font* font, void* control)
{
    return obj->GetTextExtentSimple(text, font, control);
}

ALTERNET_UI_API SizeD_C DrawingContext_MeasureText_(DrawingContext* obj, const char16_t* text, Font* font, double maximumWidth, TextWrapping textWrapping)
{
    return obj->MeasureText(text, font, maximumWidth, textWrapping);
}

ALTERNET_UI_API DrawingContext* DrawingContext_FromImage_(Image* image)
{
    return DrawingContext::FromImage(image);
}

ALTERNET_UI_API DrawingContext* DrawingContext_FromScreen_()
{
    return DrawingContext::FromScreen();
}

ALTERNET_UI_API void DrawingContext_RoundedRectangle_(DrawingContext* obj, Pen* pen, Brush* brush, RectD rectangle, double cornerRadius)
{
    obj->RoundedRectangle(pen, brush, rectangle, cornerRadius);
}

ALTERNET_UI_API void DrawingContext_Rectangle_(DrawingContext* obj, Pen* pen, Brush* brush, RectD rectangle)
{
    obj->Rectangle(pen, brush, rectangle);
}

ALTERNET_UI_API void DrawingContext_Ellipse_(DrawingContext* obj, Pen* pen, Brush* brush, RectD rectangle)
{
    obj->Ellipse(pen, brush, rectangle);
}

ALTERNET_UI_API void DrawingContext_Path_(DrawingContext* obj, Pen* pen, Brush* brush, GraphicsPath* path)
{
    obj->Path(pen, brush, path);
}

ALTERNET_UI_API void DrawingContext_Pie_(DrawingContext* obj, Pen* pen, Brush* brush, PointD center, double radius, double startAngle, double sweepAngle)
{
    obj->Pie(pen, brush, center, radius, startAngle, sweepAngle);
}

ALTERNET_UI_API void DrawingContext_Circle_(DrawingContext* obj, Pen* pen, Brush* brush, PointD center, double radius)
{
    obj->Circle(pen, brush, center, radius);
}

ALTERNET_UI_API void DrawingContext_Polygon_(DrawingContext* obj, Pen* pen, Brush* brush, PointD* points, int pointsCount, FillMode fillMode)
{
    obj->Polygon(pen, brush, points, pointsCount, fillMode);
}

ALTERNET_UI_API void DrawingContext_FillRectangleI_(DrawingContext* obj, Brush* brush, RectI rectangle)
{
    obj->FillRectangleI(brush, rectangle);
}

ALTERNET_UI_API void DrawingContext_FillRectangle_(DrawingContext* obj, Brush* brush, RectD rectangle)
{
    obj->FillRectangle(brush, rectangle);
}

ALTERNET_UI_API void DrawingContext_DrawRectangle_(DrawingContext* obj, Pen* pen, RectD rectangle)
{
    obj->DrawRectangle(pen, rectangle);
}

ALTERNET_UI_API void DrawingContext_FillEllipse_(DrawingContext* obj, Brush* brush, RectD bounds)
{
    obj->FillEllipse(brush, bounds);
}

ALTERNET_UI_API void DrawingContext_DrawEllipse_(DrawingContext* obj, Pen* pen, RectD bounds)
{
    obj->DrawEllipse(pen, bounds);
}

ALTERNET_UI_API void DrawingContext_FloodFill_(DrawingContext* obj, Brush* brush, PointD point)
{
    obj->FloodFill(brush, point);
}

ALTERNET_UI_API void DrawingContext_DrawPath_(DrawingContext* obj, Pen* pen, GraphicsPath* path)
{
    obj->DrawPath(pen, path);
}

ALTERNET_UI_API void DrawingContext_FillPath_(DrawingContext* obj, Brush* brush, GraphicsPath* path)
{
    obj->FillPath(brush, path);
}

ALTERNET_UI_API void DrawingContext_DrawTextAtPoint_(DrawingContext* obj, const char16_t* text, PointD origin, Font* font, Brush* brush)
{
    obj->DrawTextAtPoint(text, origin, font, brush);
}

ALTERNET_UI_API void DrawingContext_DrawTextAtRect_(DrawingContext* obj, const char16_t* text, RectD bounds, Font* font, Brush* brush, TextHorizontalAlignment horizontalAlignment, TextVerticalAlignment verticalAlignment, TextTrimming trimming, TextWrapping wrapping)
{
    obj->DrawTextAtRect(text, bounds, font, brush, horizontalAlignment, verticalAlignment, trimming, wrapping);
}

ALTERNET_UI_API void DrawingContext_DrawImageAtPoint_(DrawingContext* obj, Image* image, PointD origin, c_bool useMask)
{
    obj->DrawImageAtPoint(image, origin, useMask);
}

ALTERNET_UI_API void DrawingContext_DrawImageAtRect_(DrawingContext* obj, Image* image, RectD destinationRect, c_bool useMask)
{
    obj->DrawImageAtRect(image, destinationRect, useMask);
}

ALTERNET_UI_API void DrawingContext_DrawImagePortionAtRect_(DrawingContext* obj, Image* image, RectD destinationRect, RectD sourceRect)
{
    obj->DrawImagePortionAtRect(image, destinationRect, sourceRect);
}

ALTERNET_UI_API void DrawingContext_DrawImagePortionAtPixelRect_(DrawingContext* obj, Image* image, RectI destinationRect, RectI sourceRect)
{
    obj->DrawImagePortionAtPixelRect(image, destinationRect, sourceRect);
}

ALTERNET_UI_API void DrawingContext_Push_(DrawingContext* obj)
{
    obj->Push();
}

ALTERNET_UI_API void DrawingContext_Pop_(DrawingContext* obj)
{
    obj->Pop();
}

ALTERNET_UI_API void DrawingContext_DrawLine_(DrawingContext* obj, Pen* pen, PointD a, PointD b)
{
    obj->DrawLine(pen, a, b);
}

ALTERNET_UI_API void DrawingContext_DrawLines_(DrawingContext* obj, Pen* pen, PointD* points, int pointsCount)
{
    obj->DrawLines(pen, points, pointsCount);
}

ALTERNET_UI_API void DrawingContext_DrawArc_(DrawingContext* obj, Pen* pen, PointD center, double radius, double startAngle, double sweepAngle)
{
    obj->DrawArc(pen, center, radius, startAngle, sweepAngle);
}

ALTERNET_UI_API void DrawingContext_FillPie_(DrawingContext* obj, Brush* brush, PointD center, double radius, double startAngle, double sweepAngle)
{
    obj->FillPie(brush, center, radius, startAngle, sweepAngle);
}

ALTERNET_UI_API void DrawingContext_DrawPie_(DrawingContext* obj, Pen* pen, PointD center, double radius, double startAngle, double sweepAngle)
{
    obj->DrawPie(pen, center, radius, startAngle, sweepAngle);
}

ALTERNET_UI_API void DrawingContext_DrawBezier_(DrawingContext* obj, Pen* pen, PointD startPoint, PointD controlPoint1, PointD controlPoint2, PointD endPoint)
{
    obj->DrawBezier(pen, startPoint, controlPoint1, controlPoint2, endPoint);
}

ALTERNET_UI_API void DrawingContext_DrawBeziers_(DrawingContext* obj, Pen* pen, PointD* points, int pointsCount)
{
    obj->DrawBeziers(pen, points, pointsCount);
}

ALTERNET_UI_API void DrawingContext_DrawPoint_(DrawingContext* obj, Pen* pen, double x, double y)
{
    obj->DrawPoint(pen, x, y);
}

ALTERNET_UI_API void DrawingContext_DrawCircle_(DrawingContext* obj, Pen* pen, PointD center, double radius)
{
    obj->DrawCircle(pen, center, radius);
}

ALTERNET_UI_API void DrawingContext_FillCircle_(DrawingContext* obj, Brush* brush, PointD center, double radius)
{
    obj->FillCircle(brush, center, radius);
}

ALTERNET_UI_API void DrawingContext_DrawRoundedRectangle_(DrawingContext* obj, Pen* pen, RectD rect, double cornerRadius)
{
    obj->DrawRoundedRectangle(pen, rect, cornerRadius);
}

ALTERNET_UI_API void DrawingContext_FillRoundedRectangle_(DrawingContext* obj, Brush* brush, RectD rect, double cornerRadius)
{
    obj->FillRoundedRectangle(brush, rect, cornerRadius);
}

ALTERNET_UI_API void DrawingContext_DrawPolygon_(DrawingContext* obj, Pen* pen, PointD* points, int pointsCount)
{
    obj->DrawPolygon(pen, points, pointsCount);
}

ALTERNET_UI_API void DrawingContext_FillPolygon_(DrawingContext* obj, Brush* brush, PointD* points, int pointsCount, FillMode fillMode)
{
    obj->FillPolygon(brush, points, pointsCount, fillMode);
}

ALTERNET_UI_API void DrawingContext_DrawRectangles_(DrawingContext* obj, Pen* pen, RectD* rects, int rectsCount)
{
    obj->DrawRectangles(pen, rects, rectsCount);
}

ALTERNET_UI_API void DrawingContext_FillRectangles_(DrawingContext* obj, Brush* brush, RectD* rects, int rectsCount)
{
    obj->FillRectangles(brush, rects, rectsCount);
}

ALTERNET_UI_API Color_C DrawingContext_GetPixel_(DrawingContext* obj, PointD p)
{
    return obj->GetPixel(p);
}

ALTERNET_UI_API void DrawingContext_SetPixel_(DrawingContext* obj, PointD p, Pen* pen)
{
    obj->SetPixel(p, pen);
}

