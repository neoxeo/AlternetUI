// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2023 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class PageSettings : NativeObject
    {
        static PageSettings()
        {
        }
        
        public PageSettings()
        {
            SetNativePointer(NativeApi.PageSettings_Create_());
        }
        
        public PageSettings(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public bool Color
        {
            get
            {
                CheckDisposed();
                return NativeApi.PageSettings_GetColor_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.PageSettings_SetColor_(NativePointer, value);
            }
        }
        
        public bool Landscape
        {
            get
            {
                CheckDisposed();
                return NativeApi.PageSettings_GetLandscape_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.PageSettings_SetLandscape_(NativePointer, value);
            }
        }
        
        public Alternet.UI.Thickness Margins
        {
            get
            {
                CheckDisposed();
                return NativeApi.PageSettings_GetMargins_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.PageSettings_SetMargins_(NativePointer, value);
            }
        }
        
        public Alternet.Drawing.SizeD CustomPaperSize
        {
            get
            {
                CheckDisposed();
                return NativeApi.PageSettings_GetCustomPaperSize_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.PageSettings_SetCustomPaperSize_(NativePointer, value);
            }
        }
        
        public bool UseCustomPaperSize
        {
            get
            {
                CheckDisposed();
                return NativeApi.PageSettings_GetUseCustomPaperSize_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.PageSettings_SetUseCustomPaperSize_(NativePointer, value);
            }
        }
        
        public PaperKind PaperSize
        {
            get
            {
                CheckDisposed();
                return NativeApi.PageSettings_GetPaperSize_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.PageSettings_SetPaperSize_(NativePointer, value);
            }
        }
        
        public PrinterResolutionKind PrinterResolution
        {
            get
            {
                CheckDisposed();
                return NativeApi.PageSettings_GetPrinterResolution_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.PageSettings_SetPrinterResolution_(NativePointer, value);
            }
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr PageSettings_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool PageSettings_GetColor_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PageSettings_SetColor_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool PageSettings_GetLandscape_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PageSettings_SetLandscape_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.UI.Thickness PageSettings_GetMargins_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PageSettings_SetMargins_(IntPtr obj, Alternet.UI.Thickness value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.Drawing.SizeD PageSettings_GetCustomPaperSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PageSettings_SetCustomPaperSize_(IntPtr obj, Alternet.Drawing.SizeD value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool PageSettings_GetUseCustomPaperSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PageSettings_SetUseCustomPaperSize_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern PaperKind PageSettings_GetPaperSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PageSettings_SetPaperSize_(IntPtr obj, PaperKind value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern PrinterResolutionKind PageSettings_GetPrinterResolution_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PageSettings_SetPrinterResolution_(IntPtr obj, PrinterResolutionKind value);
            
        }
    }
}
