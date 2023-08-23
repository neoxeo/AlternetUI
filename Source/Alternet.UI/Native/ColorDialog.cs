// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class ColorDialog : NativeObject
    {
        static ColorDialog()
        {
        }
        
        public ColorDialog()
        {
            SetNativePointer(NativeApi.ColorDialog_Create_());
        }
        
        public ColorDialog(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public Alternet.Drawing.Color Color
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ColorDialog_GetColor_(NativePointer);
                return n;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ColorDialog_SetColor_(NativePointer, value);
            }
        }
        
        public string? Title
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ColorDialog_GetTitle_(NativePointer);
                return n;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ColorDialog_SetTitle_(NativePointer, value);
            }
        }
        
        public ModalResult ShowModal(Window? owner)
        {
            CheckDisposed();
            var n = NativeApi.ColorDialog_ShowModal_(NativePointer, owner?.NativePointer ?? IntPtr.Zero);
            return n;
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr ColorDialog_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Color ColorDialog_GetColor_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ColorDialog_SetColor_(IntPtr obj, NativeApiTypes.Color value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string? ColorDialog_GetTitle_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ColorDialog_SetTitle_(IntPtr obj, string? value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern ModalResult ColorDialog_ShowModal_(IntPtr obj, IntPtr owner);
            
        }
    }
}
