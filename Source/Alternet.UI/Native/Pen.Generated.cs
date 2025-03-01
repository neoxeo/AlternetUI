// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2025 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class Pen : NativeObject
    {
        static Pen()
        {
        }
        
        public Pen()
        {
            SetNativePointer(NativeApi.Pen_Create_());
        }
        
        public Pen(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public void Initialize(Alternet.Drawing.DashStyle style, Alternet.Drawing.Color color, double width, Alternet.Drawing.LineCap lineCap, Alternet.Drawing.LineJoin lineJoin)
        {
            CheckDisposed();
            NativeApi.Pen_Initialize_(NativePointer, style, color, width, lineCap, lineJoin);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Pen_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Pen_Initialize_(IntPtr obj, Alternet.Drawing.DashStyle style, NativeApiTypes.Color color, double width, Alternet.Drawing.LineCap lineCap, Alternet.Drawing.LineJoin lineJoin);
            
        }
    }
}
