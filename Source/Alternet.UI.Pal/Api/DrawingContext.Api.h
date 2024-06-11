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
    #if !defined(__WXMSW__)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->GetIsOk();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void* DrawingContext_GetWxWidgetDC_(DrawingContext* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<void*>([&](){
    #endif
        return obj->GetWxWidgetDC();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API TransformMatrix* DrawingContext_GetTransform_(DrawingContext* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<TransformMatrix*>([&](){
    #endif
        return obj->GetTransform();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_SetTransform_(DrawingContext* obj, TransformMatrix* value)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetTransform(value);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API Region* DrawingContext_GetClip_(DrawingContext* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<Region*>([&](){
    #endif
        return obj->GetClip();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_SetClip_(DrawingContext* obj, Region* value)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetClip(value);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API InterpolationMode DrawingContext_GetInterpolationMode_(DrawingContext* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<InterpolationMode>([&](){
    #endif
        return obj->GetInterpolationMode();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_SetInterpolationMode_(DrawingContext* obj, InterpolationMode value)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetInterpolationMode(value);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API DrawingContext* DrawingContext_CreateMemoryDC_(double scaleFactor)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<DrawingContext*>([&](){
    #endif
        return DrawingContext::CreateMemoryDC(scaleFactor);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void* DrawingContext_GetHandle_(DrawingContext* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<void*>([&](){
    #endif
        return obj->GetHandle();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawRotatedText_(DrawingContext* obj, const char16_t* text, PointD location, Font* font, Color foreColor, Color backColor, double angle)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawRotatedText(text, location, font, foreColor, backColor, angle);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawRotatedTextI_(DrawingContext* obj, const char16_t* text, PointI location, Font* font, Color foreColor, Color backColor, double angle)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawRotatedTextI(text, location, font, foreColor, backColor, angle);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API Image* DrawingContext_GetAsBitmapI_(DrawingContext* obj, RectI subrect)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<Image*>([&](){
    #endif
        return obj->GetAsBitmapI(subrect);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API c_bool DrawingContext_Blit_(DrawingContext* obj, PointD destPt, SizeD sz, DrawingContext* source, PointD srcPt, int rop, c_bool useMask, PointD srcPtMask)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->Blit(destPt, sz, source, srcPt, rop, useMask, srcPtMask);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API c_bool DrawingContext_StretchBlit_(DrawingContext* obj, PointD dstPt, SizeD dstSize, DrawingContext* source, PointD srcPt, SizeD srcSize, int rop, c_bool useMask, PointD srcMaskPt)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->StretchBlit(dstPt, dstSize, source, srcPt, srcSize, rop, useMask, srcMaskPt);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API c_bool DrawingContext_BlitI_(DrawingContext* obj, PointI destPt, SizeI sz, DrawingContext* source, PointI srcPt, int rop, c_bool useMask, PointI srcPtMask)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->BlitI(destPt, sz, source, srcPt, rop, useMask, srcPtMask);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API c_bool DrawingContext_StretchBlitI_(DrawingContext* obj, PointI dstPt, SizeI dstSize, DrawingContext* source, PointI srcPt, SizeI srcSize, int rop, c_bool useMask, PointI srcMaskPt)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<c_bool>([&](){
    #endif
        return obj->StretchBlitI(dstPt, dstSize, source, srcPt, srcSize, rop, useMask, srcMaskPt);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API RectD_C DrawingContext_DrawLabel_(DrawingContext* obj, const char16_t* text, Font* font, Color foreColor, Color backColor, Image* image, RectD rect, int alignment, int indexAccel)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<RectD_C>([&](){
    #endif
        return obj->DrawLabel(text, font, foreColor, backColor, image, rect, alignment, indexAccel);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DestroyClippingRegion_(DrawingContext* obj)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DestroyClippingRegion();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_SetClippingRegion_(DrawingContext* obj, RectD rect)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetClippingRegion(rect);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API RectD_C DrawingContext_GetClippingBox_(DrawingContext* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<RectD_C>([&](){
    #endif
        return obj->GetClippingBox();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawText_(DrawingContext* obj, const char16_t* text, PointD location, Font* font, Color foreColor, Color backColor)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawText(text, location, font, foreColor, backColor);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API SizeI_C DrawingContext_GetDpi_(DrawingContext* obj)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<SizeI_C>([&](){
    #endif
        return obj->GetDpi();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_ImageFromDrawingContext_(Image* image, int width, int height, DrawingContext* dc)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        DrawingContext::ImageFromDrawingContext(image, width, height, dc);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_ImageFromGenericImageDC_(Image* image, void* source, DrawingContext* dc)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        DrawingContext::ImageFromGenericImageDC(image, source, dc);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_GetPartialTextExtents_(DrawingContext* obj, const char16_t* text, double* widths, int widthsCount, Font* font, void* control)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->GetPartialTextExtents(text, widths, widthsCount, font, control);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API RectD_C DrawingContext_GetTextExtent_(DrawingContext* obj, const char16_t* text, Font* font, void* control)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<RectD_C>([&](){
    #endif
        return obj->GetTextExtent(text, font, control);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API SizeD_C DrawingContext_GetTextExtentSimple_(DrawingContext* obj, const char16_t* text, Font* font, void* control)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<SizeD_C>([&](){
    #endif
        return obj->GetTextExtentSimple(text, font, control);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API SizeD_C DrawingContext_MeasureText_(DrawingContext* obj, const char16_t* text, Font* font, double maximumWidth, TextWrapping textWrapping)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<SizeD_C>([&](){
    #endif
        return obj->MeasureText(text, font, maximumWidth, textWrapping);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API DrawingContext* DrawingContext_FromImage_(Image* image)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<DrawingContext*>([&](){
    #endif
        return DrawingContext::FromImage(image);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API DrawingContext* DrawingContext_FromScreen_()
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<DrawingContext*>([&](){
    #endif
        return DrawingContext::FromScreen();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_RoundedRectangle_(DrawingContext* obj, Pen* pen, Brush* brush, RectD rectangle, double cornerRadius)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->RoundedRectangle(pen, brush, rectangle, cornerRadius);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_Rectangle_(DrawingContext* obj, Pen* pen, Brush* brush, RectD rectangle)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->Rectangle(pen, brush, rectangle);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_Ellipse_(DrawingContext* obj, Pen* pen, Brush* brush, RectD rectangle)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->Ellipse(pen, brush, rectangle);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_Path_(DrawingContext* obj, Pen* pen, Brush* brush, GraphicsPath* path)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->Path(pen, brush, path);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_Pie_(DrawingContext* obj, Pen* pen, Brush* brush, PointD center, double radius, double startAngle, double sweepAngle)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->Pie(pen, brush, center, radius, startAngle, sweepAngle);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_Circle_(DrawingContext* obj, Pen* pen, Brush* brush, PointD center, double radius)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->Circle(pen, brush, center, radius);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_Polygon_(DrawingContext* obj, Pen* pen, Brush* brush, PointD* points, int pointsCount, FillMode fillMode)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->Polygon(pen, brush, points, pointsCount, fillMode);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_FillRectangle_(DrawingContext* obj, Brush* brush, RectD rectangle)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->FillRectangle(brush, rectangle);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_FillRectangleI_(DrawingContext* obj, Brush* brush, RectI rectangle)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->FillRectangleI(brush, rectangle);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawRectangle_(DrawingContext* obj, Pen* pen, RectD rectangle)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawRectangle(pen, rectangle);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_FillEllipse_(DrawingContext* obj, Brush* brush, RectD bounds)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->FillEllipse(brush, bounds);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawEllipse_(DrawingContext* obj, Pen* pen, RectD bounds)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawEllipse(pen, bounds);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_FloodFill_(DrawingContext* obj, Brush* brush, PointD point)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->FloodFill(brush, point);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawPath_(DrawingContext* obj, Pen* pen, GraphicsPath* path)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawPath(pen, path);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_FillPath_(DrawingContext* obj, Brush* brush, GraphicsPath* path)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->FillPath(brush, path);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawTextAtPoint_(DrawingContext* obj, const char16_t* text, PointD origin, Font* font, Brush* brush)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawTextAtPoint(text, origin, font, brush);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawTextAtRect_(DrawingContext* obj, const char16_t* text, RectD bounds, Font* font, Brush* brush, TextHorizontalAlignment horizontalAlignment, TextVerticalAlignment verticalAlignment, TextTrimming trimming, TextWrapping wrapping)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawTextAtRect(text, bounds, font, brush, horizontalAlignment, verticalAlignment, trimming, wrapping);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawImageAtPoint_(DrawingContext* obj, Image* image, PointD origin, c_bool useMask)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawImageAtPoint(image, origin, useMask);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawImageAtRect_(DrawingContext* obj, Image* image, RectD destinationRect, c_bool useMask)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawImageAtRect(image, destinationRect, useMask);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawImagePortionAtRect_(DrawingContext* obj, Image* image, RectD destinationRect, RectD sourceRect)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawImagePortionAtRect(image, destinationRect, sourceRect);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawImagePortionAtPixelRect_(DrawingContext* obj, Image* image, RectI destinationRect, RectI sourceRect)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawImagePortionAtPixelRect(image, destinationRect, sourceRect);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_Push_(DrawingContext* obj)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->Push();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_Pop_(DrawingContext* obj)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->Pop();
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawLine_(DrawingContext* obj, Pen* pen, PointD a, PointD b)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawLine(pen, a, b);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawLines_(DrawingContext* obj, Pen* pen, PointD* points, int pointsCount)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawLines(pen, points, pointsCount);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawArc_(DrawingContext* obj, Pen* pen, PointD center, double radius, double startAngle, double sweepAngle)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawArc(pen, center, radius, startAngle, sweepAngle);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_FillPie_(DrawingContext* obj, Brush* brush, PointD center, double radius, double startAngle, double sweepAngle)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->FillPie(brush, center, radius, startAngle, sweepAngle);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawPie_(DrawingContext* obj, Pen* pen, PointD center, double radius, double startAngle, double sweepAngle)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawPie(pen, center, radius, startAngle, sweepAngle);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawBezier_(DrawingContext* obj, Pen* pen, PointD startPoint, PointD controlPoint1, PointD controlPoint2, PointD endPoint)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawBezier(pen, startPoint, controlPoint1, controlPoint2, endPoint);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawBeziers_(DrawingContext* obj, Pen* pen, PointD* points, int pointsCount)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawBeziers(pen, points, pointsCount);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawPoint_(DrawingContext* obj, Pen* pen, double x, double y)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawPoint(pen, x, y);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawCircle_(DrawingContext* obj, Pen* pen, PointD center, double radius)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawCircle(pen, center, radius);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_FillCircle_(DrawingContext* obj, Brush* brush, PointD center, double radius)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->FillCircle(brush, center, radius);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawRoundedRectangle_(DrawingContext* obj, Pen* pen, RectD rect, double cornerRadius)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawRoundedRectangle(pen, rect, cornerRadius);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_FillRoundedRectangle_(DrawingContext* obj, Brush* brush, RectD rect, double cornerRadius)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->FillRoundedRectangle(brush, rect, cornerRadius);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawPolygon_(DrawingContext* obj, Pen* pen, PointD* points, int pointsCount)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawPolygon(pen, points, pointsCount);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_FillPolygon_(DrawingContext* obj, Brush* brush, PointD* points, int pointsCount, FillMode fillMode)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->FillPolygon(brush, points, pointsCount, fillMode);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_DrawRectangles_(DrawingContext* obj, Pen* pen, RectD* rects, int rectsCount)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->DrawRectangles(pen, rects, rectsCount);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_FillRectangles_(DrawingContext* obj, Brush* brush, RectD* rects, int rectsCount)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->FillRectangles(brush, rects, rectsCount);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API Color_C DrawingContext_GetPixel_(DrawingContext* obj, PointD p)
{
    #if !defined(__WXMSW__)
    return MarshalExceptions<Color_C>([&](){
    #endif
        return obj->GetPixel(p);
    #if !defined(__WXMSW__)
    });
    #endif
}

ALTERNET_UI_API void DrawingContext_SetPixel_(DrawingContext* obj, PointD p, Pen* pen)
{
    #if !defined(__WXMSW__)
    MarshalExceptions<void>([&](){
    #endif
        obj->SetPixel(p, pen);
    #if !defined(__WXMSW__)
    });
    #endif
}

