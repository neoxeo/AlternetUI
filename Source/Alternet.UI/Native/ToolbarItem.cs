// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class ToolbarItem : Control
    {
        static ToolbarItem()
        {
            SetEventCallback();
        }
        
        public ToolbarItem()
        {
            SetNativePointer(NativeApi.ToolbarItem_Create_());
        }
        
        public ToolbarItem(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public string ManagedCommandId
        {
            get
            {
                CheckDisposed();
                return NativeApi.ToolbarItem_GetManagedCommandId_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ToolbarItem_SetManagedCommandId_(NativePointer, value);
            }
        }
        
        public string Text
        {
            get
            {
                CheckDisposed();
                return NativeApi.ToolbarItem_GetText_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ToolbarItem_SetText_(NativePointer, value);
            }
        }
        
        public bool Checked
        {
            get
            {
                CheckDisposed();
                return NativeApi.ToolbarItem_GetChecked_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ToolbarItem_SetChecked_(NativePointer, value);
            }
        }
        
        public Menu? DropDownMenu
        {
            get
            {
                CheckDisposed();
                var _nnn = NativeApi.ToolbarItem_GetDropDownMenu_(NativePointer);
                var _mmm = NativeObject.GetFromNativePointer<Menu>(_nnn, p => new Menu(p));
                ReleaseNativeObjectPointer(_nnn);
                return _mmm;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ToolbarItem_SetDropDownMenu_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public bool IsCheckable
        {
            get
            {
                CheckDisposed();
                return NativeApi.ToolbarItem_GetIsCheckable_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ToolbarItem_SetIsCheckable_(NativePointer, value);
            }
        }
        
        public ImageSet? DisabledImage
        {
            get
            {
                CheckDisposed();
                var _nnn = NativeApi.ToolbarItem_GetDisabledImage_(NativePointer);
                var _mmm = NativeObject.GetFromNativePointer<ImageSet>(_nnn, p => new ImageSet(p));
                ReleaseNativeObjectPointer(_nnn);
                return _mmm;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ToolbarItem_SetDisabledImage_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public ImageSet? Image
        {
            get
            {
                CheckDisposed();
                var _nnn = NativeApi.ToolbarItem_GetImage_(NativePointer);
                var _mmm = NativeObject.GetFromNativePointer<ImageSet>(_nnn, p => new ImageSet(p));
                ReleaseNativeObjectPointer(_nnn);
                return _mmm;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ToolbarItem_SetImage_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.ToolbarItemEventCallbackType((obj, e, parameter) =>
                {
                    var w = NativeObject.GetFromNativePointer<ToolbarItem>(obj, p => new ToolbarItem(p));
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                );
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.ToolbarItem_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.ToolbarItemEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.ToolbarItemEvent.Click:
                {
                    Click?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                default: throw new Exception("Unexpected ToolbarItemEvent value: " + e);
            }
        }
        
        public event EventHandler? Click;
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr ToolbarItemEventCallbackType(IntPtr obj, ToolbarItemEvent e, IntPtr param);
            
            public enum ToolbarItemEvent
            {
                Click,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ToolbarItem_SetEventCallback_(ToolbarItemEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr ToolbarItem_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string ToolbarItem_GetManagedCommandId_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ToolbarItem_SetManagedCommandId_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string ToolbarItem_GetText_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ToolbarItem_SetText_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool ToolbarItem_GetChecked_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ToolbarItem_SetChecked_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr ToolbarItem_GetDropDownMenu_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ToolbarItem_SetDropDownMenu_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool ToolbarItem_GetIsCheckable_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ToolbarItem_SetIsCheckable_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr ToolbarItem_GetDisabledImage_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ToolbarItem_SetDisabledImage_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr ToolbarItem_GetImage_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ToolbarItem_SetImage_(IntPtr obj, IntPtr value);
            
        }
    }
}
