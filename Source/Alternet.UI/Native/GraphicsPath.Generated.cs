// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2025 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class GraphicsPath : NativeObject
    {
        static GraphicsPath()
        {
        }
        
        public GraphicsPath()
        {
            SetNativePointer(NativeApi.GraphicsPath_Create_());
        }
        
        public GraphicsPath(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public Alternet.Drawing.FillMode FillMode
        {
            get
            {
                CheckDisposed();
                return NativeApi.GraphicsPath_GetFillMode_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.GraphicsPath_SetFillMode_(NativePointer, value);
            }
        }
        
        public void Initialize(DrawingContext dc)
        {
            CheckDisposed();
            NativeApi.GraphicsPath_Initialize_(NativePointer, dc.NativePointer);
        }
        
        public void AddLines(Alternet.Drawing.PointD[] points)
        {
            CheckDisposed();
            NativeApi.GraphicsPath_AddLines_(NativePointer, points, points.Length);
        }
        
        public void AddLine(Alternet.Drawing.PointD pt1, Alternet.Drawing.PointD pt2)
        {
            CheckDisposed();
            NativeApi.GraphicsPath_AddLine_(NativePointer, pt1, pt2);
        }
        
        public void AddLineTo(Alternet.Drawing.PointD pt)
        {
            CheckDisposed();
            NativeApi.GraphicsPath_AddLineTo_(NativePointer, pt);
        }
        
        public void AddEllipse(Alternet.Drawing.RectD rect)
        {
            CheckDisposed();
            NativeApi.GraphicsPath_AddEllipse_(NativePointer, rect);
        }
        
        public void AddBezier(Alternet.Drawing.PointD startPoint, Alternet.Drawing.PointD controlPoint1, Alternet.Drawing.PointD controlPoint2, Alternet.Drawing.PointD endPoint)
        {
            CheckDisposed();
            NativeApi.GraphicsPath_AddBezier_(NativePointer, startPoint, controlPoint1, controlPoint2, endPoint);
        }
        
        public void AddBezierTo(Alternet.Drawing.PointD controlPoint1, Alternet.Drawing.PointD controlPoint2, Alternet.Drawing.PointD endPoint)
        {
            CheckDisposed();
            NativeApi.GraphicsPath_AddBezierTo_(NativePointer, controlPoint1, controlPoint2, endPoint);
        }
        
        public void AddArc(Alternet.Drawing.PointD center, double radius, double startAngle, double sweepAngle)
        {
            CheckDisposed();
            NativeApi.GraphicsPath_AddArc_(NativePointer, center, radius, startAngle, sweepAngle);
        }
        
        public void AddRectangle(Alternet.Drawing.RectD rect)
        {
            CheckDisposed();
            NativeApi.GraphicsPath_AddRectangle_(NativePointer, rect);
        }
        
        public void AddRoundedRectangle(Alternet.Drawing.RectD rect, double cornerRadius)
        {
            CheckDisposed();
            NativeApi.GraphicsPath_AddRoundedRectangle_(NativePointer, rect, cornerRadius);
        }
        
        public Alternet.Drawing.RectD GetBounds()
        {
            CheckDisposed();
            return NativeApi.GraphicsPath_GetBounds_(NativePointer);
        }
        
        public void StartFigure(Alternet.Drawing.PointD point)
        {
            CheckDisposed();
            NativeApi.GraphicsPath_StartFigure_(NativePointer, point);
        }
        
        public void CloseFigure()
        {
            CheckDisposed();
            NativeApi.GraphicsPath_CloseFigure_(NativePointer);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GraphicsPath_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.Drawing.FillMode GraphicsPath_GetFillMode_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_SetFillMode_(IntPtr obj, Alternet.Drawing.FillMode value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_Initialize_(IntPtr obj, IntPtr dc);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_AddLines_(IntPtr obj, Alternet.Drawing.PointD[] points, int pointsCount);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_AddLine_(IntPtr obj, Alternet.Drawing.PointD pt1, Alternet.Drawing.PointD pt2);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_AddLineTo_(IntPtr obj, Alternet.Drawing.PointD pt);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_AddEllipse_(IntPtr obj, Alternet.Drawing.RectD rect);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_AddBezier_(IntPtr obj, Alternet.Drawing.PointD startPoint, Alternet.Drawing.PointD controlPoint1, Alternet.Drawing.PointD controlPoint2, Alternet.Drawing.PointD endPoint);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_AddBezierTo_(IntPtr obj, Alternet.Drawing.PointD controlPoint1, Alternet.Drawing.PointD controlPoint2, Alternet.Drawing.PointD endPoint);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_AddArc_(IntPtr obj, Alternet.Drawing.PointD center, double radius, double startAngle, double sweepAngle);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_AddRectangle_(IntPtr obj, Alternet.Drawing.RectD rect);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_AddRoundedRectangle_(IntPtr obj, Alternet.Drawing.RectD rect, double cornerRadius);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.Drawing.RectD GraphicsPath_GetBounds_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_StartFigure_(IntPtr obj, Alternet.Drawing.PointD point);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void GraphicsPath_CloseFigure_(IntPtr obj);
            
        }
    }
}
