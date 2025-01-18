// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2025 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class ColorDialog : NativeObject
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
                return NativeApi.ColorDialog_GetColor_(NativePointer);
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
                return NativeApi.ColorDialog_GetTitle_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ColorDialog_SetTitle_(NativePointer, value);
            }
        }
        
        public Alternet.UI.ModalResult ShowModal(Window? owner)
        {
            CheckDisposed();
            return NativeApi.ColorDialog_ShowModal_(NativePointer, owner?.NativePointer ?? IntPtr.Zero);
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
            public static extern Alternet.UI.ModalResult ColorDialog_ShowModal_(IntPtr obj, IntPtr owner);
            
        }
    }
}
