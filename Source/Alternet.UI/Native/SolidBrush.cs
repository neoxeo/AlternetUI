// Auto generated code, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2021.

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class SolidBrush : Brush
    {
        public SolidBrush()
        {
            SetNativePointer(NativeApi.SolidBrush_Create_());
        }
        
        public SolidBrush(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public void Initialize(System.Drawing.Color color)
        {
            CheckDisposed();
            NativeApi.SolidBrush_Initialize_(NativePointer, color);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SolidBrush_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void SolidBrush_Initialize_(IntPtr obj, NativeApiTypes.Color color);
            
        }
    }
}
