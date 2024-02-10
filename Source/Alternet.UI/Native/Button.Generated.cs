// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class Button : Control
    {
        static Button()
        {
            SetEventCallback();
        }
        
        public Button()
        {
            SetNativePointer(NativeApi.Button_Create_());
        }
        
        public Button(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public static bool ImagesEnabled
        {
            get
            {
                return NativeApi.Button_GetImagesEnabled_();
            }
            
            set
            {
                NativeApi.Button_SetImagesEnabled_(value);
            }
        }
        
        public string Text
        {
            get
            {
                CheckDisposed();
                return NativeApi.Button_GetText_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Button_SetText_(NativePointer, value);
            }
        }
        
        public bool ExactFit
        {
            get
            {
                CheckDisposed();
                return NativeApi.Button_GetExactFit_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Button_SetExactFit_(NativePointer, value);
            }
        }
        
        public bool IsDefault
        {
            get
            {
                CheckDisposed();
                return NativeApi.Button_GetIsDefault_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Button_SetIsDefault_(NativePointer, value);
            }
        }
        
        public bool HasBorder
        {
            get
            {
                CheckDisposed();
                return NativeApi.Button_GetHasBorder_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Button_SetHasBorder_(NativePointer, value);
            }
        }
        
        public bool IsCancel
        {
            get
            {
                CheckDisposed();
                return NativeApi.Button_GetIsCancel_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Button_SetIsCancel_(NativePointer, value);
            }
        }
        
        public Image? NormalImage
        {
            get
            {
                CheckDisposed();
                var _nnn = NativeApi.Button_GetNormalImage_(NativePointer);
                var _mmm = NativeObject.GetFromNativePointer<Image>(_nnn, p => new Image(p));
                ReleaseNativeObjectPointer(_nnn);
                return _mmm;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Button_SetNormalImage_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public Image? HoveredImage
        {
            get
            {
                CheckDisposed();
                var _nnn = NativeApi.Button_GetHoveredImage_(NativePointer);
                var _mmm = NativeObject.GetFromNativePointer<Image>(_nnn, p => new Image(p));
                ReleaseNativeObjectPointer(_nnn);
                return _mmm;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Button_SetHoveredImage_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public Image? PressedImage
        {
            get
            {
                CheckDisposed();
                var _nnn = NativeApi.Button_GetPressedImage_(NativePointer);
                var _mmm = NativeObject.GetFromNativePointer<Image>(_nnn, p => new Image(p));
                ReleaseNativeObjectPointer(_nnn);
                return _mmm;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Button_SetPressedImage_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public Image? DisabledImage
        {
            get
            {
                CheckDisposed();
                var _nnn = NativeApi.Button_GetDisabledImage_(NativePointer);
                var _mmm = NativeObject.GetFromNativePointer<Image>(_nnn, p => new Image(p));
                ReleaseNativeObjectPointer(_nnn);
                return _mmm;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Button_SetDisabledImage_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public Image? FocusedImage
        {
            get
            {
                CheckDisposed();
                var _nnn = NativeApi.Button_GetFocusedImage_(NativePointer);
                var _mmm = NativeObject.GetFromNativePointer<Image>(_nnn, p => new Image(p));
                ReleaseNativeObjectPointer(_nnn);
                return _mmm;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Button_SetFocusedImage_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public bool TextVisible
        {
            get
            {
                CheckDisposed();
                return NativeApi.Button_GetTextVisible_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Button_SetTextVisible_(NativePointer, value);
            }
        }
        
        public int TextAlign
        {
            get
            {
                CheckDisposed();
                return NativeApi.Button_GetTextAlign_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Button_SetTextAlign_(NativePointer, value);
            }
        }
        
        public void SetImagePosition(int dir)
        {
            CheckDisposed();
            NativeApi.Button_SetImagePosition_(NativePointer, dir);
        }
        
        public void SetImageMargins(double x, double y)
        {
            CheckDisposed();
            NativeApi.Button_SetImageMargins_(NativePointer, x, y);
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.ButtonEventCallbackType((obj, e, parameter) =>
                {
                    var w = NativeObject.GetFromNativePointer<Button>(obj, p => new Button(p));
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                );
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.Button_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.ButtonEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.ButtonEvent.Click:
                {
                    Click?.Invoke(); return IntPtr.Zero;
                }
                default: throw new Exception("Unexpected ButtonEvent value: " + e);
            }
        }
        
        public Action? Click;
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr ButtonEventCallbackType(IntPtr obj, ButtonEvent e, IntPtr param);
            
            public enum ButtonEvent
            {
                Click,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetEventCallback_(ButtonEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Button_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Button_GetImagesEnabled_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetImagesEnabled_(bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string Button_GetText_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetText_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Button_GetExactFit_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetExactFit_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Button_GetIsDefault_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetIsDefault_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Button_GetHasBorder_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetHasBorder_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Button_GetIsCancel_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetIsCancel_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Button_GetNormalImage_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetNormalImage_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Button_GetHoveredImage_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetHoveredImage_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Button_GetPressedImage_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetPressedImage_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Button_GetDisabledImage_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetDisabledImage_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Button_GetFocusedImage_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetFocusedImage_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Button_GetTextVisible_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetTextVisible_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int Button_GetTextAlign_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetTextAlign_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetImagePosition_(IntPtr obj, int dir);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Button_SetImageMargins_(IntPtr obj, double x, double y);
            
        }
    }
}