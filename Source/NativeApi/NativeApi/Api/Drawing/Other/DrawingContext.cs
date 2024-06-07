﻿#pragma warning disable
using System;
using Alternet.Drawing;

namespace NativeApi.Api
{

    using Coord = double;

    public class DrawingContext
    {
        public bool IsOk { get; }
        public IntPtr WxWidgetDC { get; }
        public IntPtr GetHandle() => default; 

        public void DrawRotatedText(string text, PointD location, Font font,
            Color foreColor, Color backColor, Coord angle) {}

        public Image GetAsBitmapI(RectI subrect) => default;

        public bool Blit(PointD destPt, SizeD sz,
              DrawingContext source, PointD srcPt,
              int rop /*= wxCOPY RasterOperationMode*/, bool useMask /*= false*/,
              PointD srcPtMask /*= wxDefaultPosition*/) => default;

        public bool StretchBlit(PointD dstPt, SizeD dstSize,
                     DrawingContext source, PointD srcPt, SizeD srcSize,
                     int rop, bool useMask /*= false*/,
                     PointD srcMaskPt) => default;

        public RectD DrawLabel(string text, Font font,
            Color foreColor, Color backColor, Image? image, RectD rect,
            int alignment /*= wxALIGN_LEFT | wxALIGN_TOP*/,
            int indexAccel = -1) => default;

        public void DestroyClippingRegion() { }

        public void SetClippingRegion(RectD rect) { }

        public RectD GetClippingBox() => default;

        public void DrawText(string text, PointD location, Font font,
            Color foreColor, Color backColor) { }

        public SizeI GetDpi() => default;

        protected DrawingContext() { }

        public static void ImageFromDrawingContext(Image image, int width,
            int height, DrawingContext dc) { }

        public static void ImageFromGenericImageDC(Image image, IntPtr source,
            DrawingContext dc) { }

        // Fills the widths array with the widths from the beginning of text
        // to the corresponding character of text.
        // The generic version simply builds a running total of the widths of each character
        // using GetTextExtent(), however if the various platforms have a native API function
        // that is faster or more accurate than the generic implementation then it should be
        // used instead.
        public void GetPartialTextExtents(string text, double[]	widths, Font font, IntPtr control) { }

        //X wxDouble* width,
        //Y wxDouble* height,
        //W wxDouble* descent,
        //H wxDouble* externalLeading
        //text The text string to measure.
        //width Variable to store the total calculated width of the text.
        //height Variable to store the total calculated height of the text.
        //descent Variable to store the dimension from the baseline of the font to the bottom
        //of the descender.
        //externalLeading Any extra vertical space added to the font by the font designer
        //(usually is zero).
        //Gets the dimensions of the string using the currently selected font.
        //This function only works with single-line strings.
        public RectD GetTextExtent(string text, Font font, IntPtr control) => default;

        //text The text string to measure.
        //width Variable to store the total calculated width of the text.
        //height Variable to store the total calculated height of the text.
        //descent Variable to store the dimension from the baseline of the font to the
        //bottom of the descender.
        //externalLeading Any extra vertical space added to the font by the font designer
        //(usually is zero).
        //Gets the dimensions of the string using the currently selected font.
        //This function only works with single-line strings.
        public SizeD GetTextExtentSimple(string text, Font font, IntPtr control) => default;

        public SizeD MeasureText(
            string text,
            Font font,
            Coord maximumWidth,
            TextWrapping textWrapping) => throw new Exception();

        public static DrawingContext FromImage(Image image) => throw new Exception();

        public static DrawingContext FromScreen() => throw new Exception();

        public void RoundedRectangle(Pen pen, Brush brush, RectD rectangle,
            Coord cornerRadius) { }
        public void Rectangle(Pen pen, Brush brush, RectD rectangle) { }
        public void Ellipse(Pen pen, Brush brush, RectD rectangle) { }
        public void Path(Pen pen, Brush brush, GraphicsPath path) { }
        public void Pie(Pen pen, Brush brush, PointD center, Coord radius, Coord startAngle,
            Coord sweepAngle) { }
        public void Circle(Pen pen, Brush brush, PointD center, Coord radius) { }
        public void Polygon(Pen pen, Brush brush, PointD[] points, FillMode fillMode) { }

        public void FillRectangle(Brush brush, RectD rectangle) { }
        public void DrawRectangle(Pen pen, RectD rectangle) { }

        public void FillEllipse(Brush brush, RectD bounds) { }
        public void DrawEllipse(Pen pen, RectD bounds) { }

        public void FloodFill(Brush brush, PointD point) { }

        public void DrawPath(Pen pen, GraphicsPath path) { }
        public void FillPath(Brush brush, GraphicsPath path) { }

        public void DrawTextAtPoint(
            string text,
            PointD origin,
            Font font,
            Brush brush) {}

        public void DrawTextAtRect(
            string text,
            RectD bounds,
            Font font,
            Brush brush,
            TextHorizontalAlignment horizontalAlignment,
            TextVerticalAlignment verticalAlignment,
            TextTrimming trimming,
            TextWrapping wrapping) => throw new Exception();

        public void DrawImageAtPoint(Image image, PointD origin, bool useMask = false) => throw new Exception();

        public void DrawImageAtRect(Image image, RectD destinationRect, bool useMask = false) => throw new Exception();

        public void DrawImagePortionAtRect(Image image, RectD destinationRect,
            RectD sourceRect) { }

        public void DrawImagePortionAtPixelRect(Image image, RectI destinationRect,
            RectI sourceRect)
        { }

        public void Push() => throw new Exception();

        public void Pop() => throw new Exception();

        public TransformMatrix Transform { get; set; }

        public void DrawLine(Pen pen, PointD a, PointD b) => throw new Exception();

        public void DrawLines(Pen pen, PointD[] points) => throw new Exception();

        public void DrawArc(Pen pen, PointD center, Coord radius, Coord startAngle,
            Coord sweepAngle) => throw new Exception();

        public void FillPie(Brush brush, PointD center, Coord radius, Coord startAngle,
            Coord sweepAngle) => throw new Exception();
        
        public void DrawPie(Pen pen, PointD center, Coord radius, Coord startAngle,
            Coord sweepAngle) => throw new Exception();

        public void DrawBezier(Pen pen, PointD startPoint, PointD controlPoint1,
            PointD controlPoint2, PointD endPoint) => throw new Exception();

        public void DrawBeziers(Pen pen, PointD[] points) => throw new Exception();

        public void DrawPoint(Pen pen, Coord x, Coord y) { }

        public void DrawCircle(Pen pen, PointD center, Coord radius) => throw new Exception();

        public void FillCircle(Brush brush, PointD center, Coord radius) => throw new Exception();

        public void DrawRoundedRectangle(Pen pen, RectD rect, Coord cornerRadius)
            => throw new Exception();

        public void FillRoundedRectangle(Brush brush, RectD rect, Coord cornerRadius)
            => throw new Exception();

        public void DrawPolygon(Pen pen, PointD[] points) => throw new Exception();

        public void FillPolygon(Brush brush, PointD[] points, FillMode fillMode)
            => throw new Exception();

        public void DrawRectangles(Pen pen, RectD[] rects) => throw new Exception();

        public void FillRectangles(Brush brush, RectD[] rects) => throw new Exception();

        public Color GetPixel(PointD p) => throw new Exception();
        public void SetPixel(PointD p, Pen pen) { }

        public Region? Clip { get; set; }

        public InterpolationMode InterpolationMode { get; set; }
    }
}