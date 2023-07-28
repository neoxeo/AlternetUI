// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class FontDialog : NativeObject
    {
        static FontDialog()
        {
        }
        
        public FontDialog()
        {
            SetNativePointer(NativeApi.FontDialog_Create_());
        }
        
        public FontDialog(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public bool AllowSymbols
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FontDialog_GetAllowSymbols_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FontDialog_SetAllowSymbols_(NativePointer, value);
            }
        }
        
        public bool ShowHelp
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FontDialog_GetShowHelp_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FontDialog_SetShowHelp_(NativePointer, value);
            }
        }
        
        public bool EnableEffects
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FontDialog_GetEnableEffects_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FontDialog_SetEnableEffects_(NativePointer, value);
            }
        }
        
        public int RestrictSelection
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FontDialog_GetRestrictSelection_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FontDialog_SetRestrictSelection_(NativePointer, value);
            }
        }
        
        public Alternet.Drawing.Color Color
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FontDialog_GetColor_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FontDialog_SetColor_(NativePointer, value);
            }
        }
        
        public Font Font
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FontDialog_GetFont_(NativePointer);
                var m = NativeObject.GetFromNativePointer<Font>(n, p => new Font(p))!;
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FontDialog_SetFont_(NativePointer, value.NativePointer);
            }
        }
        
        public string? Title
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.FontDialog_GetTitle_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.FontDialog_SetTitle_(NativePointer, value);
            }
        }
        
        public ModalResult ShowModal(Window? owner)
        {
            CheckDisposed();
            var n = NativeApi.FontDialog_ShowModal_(NativePointer, owner?.NativePointer ?? IntPtr.Zero);
            var m = n;
            return m;
        }
        
        public void SetRange(int minRange, int maxRange)
        {
            CheckDisposed();
            NativeApi.FontDialog_SetRange_(NativePointer, minRange, maxRange);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr FontDialog_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool FontDialog_GetAllowSymbols_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FontDialog_SetAllowSymbols_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool FontDialog_GetShowHelp_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FontDialog_SetShowHelp_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool FontDialog_GetEnableEffects_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FontDialog_SetEnableEffects_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int FontDialog_GetRestrictSelection_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FontDialog_SetRestrictSelection_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Color FontDialog_GetColor_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FontDialog_SetColor_(IntPtr obj, NativeApiTypes.Color value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr FontDialog_GetFont_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FontDialog_SetFont_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string? FontDialog_GetTitle_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FontDialog_SetTitle_(IntPtr obj, string? value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern ModalResult FontDialog_ShowModal_(IntPtr obj, IntPtr owner);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FontDialog_SetRange_(IntPtr obj, int minRange, int maxRange);
            
        }
    }
}
