// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class Popup : Control
    {
        static Popup()
        {
        }
        
        public Popup()
        {
            SetNativePointer(NativeApi.Popup_Create_());
        }
        
        public Popup(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public bool IsTransient
        {
            get
            {
                CheckDisposed();
                return NativeApi.Popup_GetIsTransient_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Popup_SetIsTransient_(NativePointer, value);
            }
        }
        
        public bool PuContainsControls
        {
            get
            {
                CheckDisposed();
                return NativeApi.Popup_GetPuContainsControls_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Popup_SetPuContainsControls_(NativePointer, value);
            }
        }
        
        public void DoPopup(System.IntPtr focus)
        {
            CheckDisposed();
            NativeApi.Popup_DoPopup_(NativePointer, focus);
        }
        
        public void Dismiss()
        {
            CheckDisposed();
            NativeApi.Popup_Dismiss_(NativePointer);
        }
        
        public void Position(Alternet.Drawing.PointI ptOrigin, Alternet.Drawing.SizeI sizePopup)
        {
            CheckDisposed();
            NativeApi.Popup_Position_(NativePointer, ptOrigin, sizePopup);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Popup_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Popup_GetIsTransient_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Popup_SetIsTransient_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Popup_GetPuContainsControls_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Popup_SetPuContainsControls_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Popup_DoPopup_(IntPtr obj, System.IntPtr focus);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Popup_Dismiss_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Popup_Position_(IntPtr obj, Alternet.Drawing.PointI ptOrigin, Alternet.Drawing.SizeI sizePopup);
            
        }
    }
}
