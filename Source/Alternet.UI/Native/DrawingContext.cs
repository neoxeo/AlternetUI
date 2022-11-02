// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class DrawingContext : NativeObject
    {
        static DrawingContext()
        {
        }
        
        private DrawingContext()
        {
        }
        
        public DrawingContext(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public TransformMatrix Transform
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.DrawingContext_GetTransform_(NativePointer);
                var m = NativeObject.GetFromNativePointer<TransformMatrix>(n, p => new TransformMatrix(p))!;
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.DrawingContext_SetTransform_(NativePointer, value.NativePointer);
            }
        }
        
        public Region? Clip
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.DrawingContext_GetClip_(NativePointer);
                var m = NativeObject.GetFromNativePointer<Region>(n, p => new Region(p));
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.DrawingContext_SetClip_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public static DrawingContext FromImage(Image image)
        {
            var n = NativeApi.DrawingContext_FromImage_(image.NativePointer);
            var m = NativeObject.GetFromNativePointer<DrawingContext>(n, p => new DrawingContext(p))!;
            ReleaseNativeObjectPointer(n);
            return m;
        }
        
        public void FillRectangle(Brush brush, Alternet.Drawing.Rect rectangle)
        {
            CheckDisposed();
            NativeApi.DrawingContext_FillRectangle_(NativePointer, brush.NativePointer, rectangle);
        }
        
        public void DrawRectangle(Pen pen, Alternet.Drawing.Rect rectangle)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawRectangle_(NativePointer, pen.NativePointer, rectangle);
        }
        
        public void FillEllipse(Brush brush, Alternet.Drawing.Rect bounds)
        {
            CheckDisposed();
            NativeApi.DrawingContext_FillEllipse_(NativePointer, brush.NativePointer, bounds);
        }
        
        public void DrawEllipse(Pen pen, Alternet.Drawing.Rect bounds)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawEllipse_(NativePointer, pen.NativePointer, bounds);
        }
        
        public void FloodFill(Brush brush, Alternet.Drawing.Point point)
        {
            CheckDisposed();
            NativeApi.DrawingContext_FloodFill_(NativePointer, brush.NativePointer, point);
        }
        
        public void DrawPath(Pen pen, GraphicsPath path)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawPath_(NativePointer, pen.NativePointer, path.NativePointer);
        }
        
        public void FillPath(Brush brush, GraphicsPath path)
        {
            CheckDisposed();
            NativeApi.DrawingContext_FillPath_(NativePointer, brush.NativePointer, path.NativePointer);
        }
        
        public void DrawTextAtPoint(string text, Alternet.Drawing.Point origin, Font font, Brush brush)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawTextAtPoint_(NativePointer, text, origin, font.NativePointer, brush.NativePointer);
        }
        
        public void DrawTextAtRect(string text, Alternet.Drawing.Rect bounds, Font font, Brush brush, TextHorizontalAlignment horizontalAlignment, TextVerticalAlignment verticalAlignment, TextTrimming trimming, TextWrapping wrapping)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawTextAtRect_(NativePointer, text, bounds, font.NativePointer, brush.NativePointer, horizontalAlignment, verticalAlignment, trimming, wrapping);
        }
        
        public void DrawImageAtPoint(Image image, Alternet.Drawing.Point origin)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawImageAtPoint_(NativePointer, image.NativePointer, origin);
        }
        
        public void DrawImageAtRect(Image image, Alternet.Drawing.Rect destinationRect)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawImageAtRect_(NativePointer, image.NativePointer, destinationRect);
        }
        
        public void DrawImagePortionAtRect(Image image, Alternet.Drawing.Rect destinationRect, Alternet.Drawing.Rect sourceRect)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawImagePortionAtRect_(NativePointer, image.NativePointer, destinationRect, sourceRect);
        }
        
        public Alternet.Drawing.Size MeasureText(string text, Font font, double maximumWidth, TextWrapping textWrapping)
        {
            CheckDisposed();
            var n = NativeApi.DrawingContext_MeasureText_(NativePointer, text, font.NativePointer, maximumWidth, textWrapping);
            var m = n;
            return m;
        }
        
        public void Push()
        {
            CheckDisposed();
            NativeApi.DrawingContext_Push_(NativePointer);
        }
        
        public void Pop()
        {
            CheckDisposed();
            NativeApi.DrawingContext_Pop_(NativePointer);
        }
        
        public void DrawLine(Pen pen, Alternet.Drawing.Point a, Alternet.Drawing.Point b)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawLine_(NativePointer, pen.NativePointer, a, b);
        }
        
        public void DrawLines(Pen pen, Alternet.Drawing.Point[] points)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawLines_(NativePointer, pen.NativePointer, Array.ConvertAll<Alternet.Drawing.Point, NativeApiTypes.Point>(points, x => x), points.Length);
        }
        
        public void DrawArc(Pen pen, Alternet.Drawing.Point center, double radius, double startAngle, double sweepAngle)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawArc_(NativePointer, pen.NativePointer, center, radius, startAngle, sweepAngle);
        }
        
        public void FillPie(Brush brush, Alternet.Drawing.Point center, double radius, double startAngle, double sweepAngle)
        {
            CheckDisposed();
            NativeApi.DrawingContext_FillPie_(NativePointer, brush.NativePointer, center, radius, startAngle, sweepAngle);
        }
        
        public void DrawPie(Pen pen, Alternet.Drawing.Point center, double radius, double startAngle, double sweepAngle)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawPie_(NativePointer, pen.NativePointer, center, radius, startAngle, sweepAngle);
        }
        
        public void DrawBezier(Pen pen, Alternet.Drawing.Point startPoint, Alternet.Drawing.Point controlPoint1, Alternet.Drawing.Point controlPoint2, Alternet.Drawing.Point endPoint)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawBezier_(NativePointer, pen.NativePointer, startPoint, controlPoint1, controlPoint2, endPoint);
        }
        
        public void DrawBeziers(Pen pen, Alternet.Drawing.Point[] points)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawBeziers_(NativePointer, pen.NativePointer, Array.ConvertAll<Alternet.Drawing.Point, NativeApiTypes.Point>(points, x => x), points.Length);
        }
        
        public void DrawCircle(Pen pen, Alternet.Drawing.Point center, double radius)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawCircle_(NativePointer, pen.NativePointer, center, radius);
        }
        
        public void FillCircle(Brush brush, Alternet.Drawing.Point center, double radius)
        {
            CheckDisposed();
            NativeApi.DrawingContext_FillCircle_(NativePointer, brush.NativePointer, center, radius);
        }
        
        public void DrawRoundedRectangle(Pen pen, Alternet.Drawing.Rect rect, double cornerRadius)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawRoundedRectangle_(NativePointer, pen.NativePointer, rect, cornerRadius);
        }
        
        public void FillRoundedRectangle(Brush brush, Alternet.Drawing.Rect rect, double cornerRadius)
        {
            CheckDisposed();
            NativeApi.DrawingContext_FillRoundedRectangle_(NativePointer, brush.NativePointer, rect, cornerRadius);
        }
        
        public void DrawPolygon(Pen pen, Alternet.Drawing.Point[] points)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawPolygon_(NativePointer, pen.NativePointer, Array.ConvertAll<Alternet.Drawing.Point, NativeApiTypes.Point>(points, x => x), points.Length);
        }
        
        public void FillPolygon(Brush brush, Alternet.Drawing.Point[] points, FillMode fillMode)
        {
            CheckDisposed();
            NativeApi.DrawingContext_FillPolygon_(NativePointer, brush.NativePointer, Array.ConvertAll<Alternet.Drawing.Point, NativeApiTypes.Point>(points, x => x), points.Length, fillMode);
        }
        
        public void DrawRectangles(Pen pen, Alternet.Drawing.Rect[] rects)
        {
            CheckDisposed();
            NativeApi.DrawingContext_DrawRectangles_(NativePointer, pen.NativePointer, Array.ConvertAll<Alternet.Drawing.Rect, NativeApiTypes.Rect>(rects, x => x), rects.Length);
        }
        
        public void FillRectangles(Brush brush, Alternet.Drawing.Rect[] rects)
        {
            CheckDisposed();
            NativeApi.DrawingContext_FillRectangles_(NativePointer, brush.NativePointer, Array.ConvertAll<Alternet.Drawing.Rect, NativeApiTypes.Rect>(rects, x => x), rects.Length);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr DrawingContext_GetTransform_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_SetTransform_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr DrawingContext_GetClip_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_SetClip_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr DrawingContext_FromImage_(IntPtr image);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_FillRectangle_(IntPtr obj, IntPtr brush, NativeApiTypes.Rect rectangle);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawRectangle_(IntPtr obj, IntPtr pen, NativeApiTypes.Rect rectangle);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_FillEllipse_(IntPtr obj, IntPtr brush, NativeApiTypes.Rect bounds);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawEllipse_(IntPtr obj, IntPtr pen, NativeApiTypes.Rect bounds);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_FloodFill_(IntPtr obj, IntPtr brush, NativeApiTypes.Point point);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawPath_(IntPtr obj, IntPtr pen, IntPtr path);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_FillPath_(IntPtr obj, IntPtr brush, IntPtr path);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawTextAtPoint_(IntPtr obj, string text, NativeApiTypes.Point origin, IntPtr font, IntPtr brush);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawTextAtRect_(IntPtr obj, string text, NativeApiTypes.Rect bounds, IntPtr font, IntPtr brush, TextHorizontalAlignment horizontalAlignment, TextVerticalAlignment verticalAlignment, TextTrimming trimming, TextWrapping wrapping);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawImageAtPoint_(IntPtr obj, IntPtr image, NativeApiTypes.Point origin);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawImageAtRect_(IntPtr obj, IntPtr image, NativeApiTypes.Rect destinationRect);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawImagePortionAtRect_(IntPtr obj, IntPtr image, NativeApiTypes.Rect destinationRect, NativeApiTypes.Rect sourceRect);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Size DrawingContext_MeasureText_(IntPtr obj, string text, IntPtr font, double maximumWidth, TextWrapping textWrapping);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_Push_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_Pop_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawLine_(IntPtr obj, IntPtr pen, NativeApiTypes.Point a, NativeApiTypes.Point b);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawLines_(IntPtr obj, IntPtr pen, NativeApiTypes.Point[] points, int pointsCount);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawArc_(IntPtr obj, IntPtr pen, NativeApiTypes.Point center, double radius, double startAngle, double sweepAngle);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_FillPie_(IntPtr obj, IntPtr brush, NativeApiTypes.Point center, double radius, double startAngle, double sweepAngle);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawPie_(IntPtr obj, IntPtr pen, NativeApiTypes.Point center, double radius, double startAngle, double sweepAngle);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawBezier_(IntPtr obj, IntPtr pen, NativeApiTypes.Point startPoint, NativeApiTypes.Point controlPoint1, NativeApiTypes.Point controlPoint2, NativeApiTypes.Point endPoint);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawBeziers_(IntPtr obj, IntPtr pen, NativeApiTypes.Point[] points, int pointsCount);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawCircle_(IntPtr obj, IntPtr pen, NativeApiTypes.Point center, double radius);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_FillCircle_(IntPtr obj, IntPtr brush, NativeApiTypes.Point center, double radius);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawRoundedRectangle_(IntPtr obj, IntPtr pen, NativeApiTypes.Rect rect, double cornerRadius);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_FillRoundedRectangle_(IntPtr obj, IntPtr brush, NativeApiTypes.Rect rect, double cornerRadius);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawPolygon_(IntPtr obj, IntPtr pen, NativeApiTypes.Point[] points, int pointsCount);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_FillPolygon_(IntPtr obj, IntPtr brush, NativeApiTypes.Point[] points, int pointsCount, FillMode fillMode);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_DrawRectangles_(IntPtr obj, IntPtr pen, NativeApiTypes.Rect[] rects, int rectsCount);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DrawingContext_FillRectangles_(IntPtr obj, IntPtr brush, NativeApiTypes.Rect[] rects, int rectsCount);
            
        }
    }
}
