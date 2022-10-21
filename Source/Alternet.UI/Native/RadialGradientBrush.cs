// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

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
        
        public void Initialize(Alternet.Drawing.Point center, double radius, Alternet.Drawing.Point gradientOrigin, Alternet.Drawing.Color[] gradientStopsColors, System.Double[] gradientStopsOffsets)
        {
            CheckDisposed();
            NativeApi.RadialGradientBrush_Initialize_(NativePointer, center, radius, gradientOrigin, Array.ConvertAll<Alternet.Drawing.Color, NativeApiTypes.Color>(gradientStopsColors, x => x), gradientStopsColors.Length, gradientStopsOffsets, gradientStopsOffsets.Length);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr RadialGradientBrush_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void RadialGradientBrush_Initialize_(IntPtr obj, NativeApiTypes.Point center, double radius, NativeApiTypes.Point gradientOrigin, NativeApiTypes.Color[] gradientStopsColors, int gradientStopsColorsCount, System.Double[] gradientStopsOffsets, int gradientStopsOffsetsCount);
            
        }
    }
}
