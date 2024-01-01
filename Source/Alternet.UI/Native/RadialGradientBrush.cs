// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class RadialGradientBrush : Brush
    {
        static RadialGradientBrush()
        {
        }
        
        public RadialGradientBrush()
        {
            SetNativePointer(NativeApi.RadialGradientBrush_Create_());
        }
        
        public RadialGradientBrush(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public void Initialize(Alternet.Drawing.PointD center, double radius, Alternet.Drawing.PointD gradientOrigin, Alternet.Drawing.Color[] gradientStopsColors, System.Double[] gradientStopsOffsets)
        {
            CheckDisposed();
            NativeApi.RadialGradientBrush_Initialize_(NativePointer, center, radius, gradientOrigin, Array.ConvertAll<Alternet.Drawing.Color, NativeApiTypes.Color>(gradientStopsColors, x => x), gradientStopsColors.Length, gradientStopsOffsets, gradientStopsOffsets.Length);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr RadialGradientBrush_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void RadialGradientBrush_Initialize_(IntPtr obj, Alternet.Drawing.PointD center, double radius, Alternet.Drawing.PointD gradientOrigin, NativeApiTypes.Color[] gradientStopsColors, int gradientStopsColorsCount, System.Double[] gradientStopsOffsets, int gradientStopsOffsetsCount);
            
        }
    }
}
