// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

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
                var n = NativeApi.ToolbarItem_GetManagedCommandId_(NativePointer);
                var m = n;
                return m;
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
                var n = NativeApi.ToolbarItem_GetText_(NativePointer);
                var m = n;
                return m;
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
                var n = NativeApi.ToolbarItem_GetChecked_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ToolbarItem_SetChecked_(NativePointer, value);
            }
        }
        
        public Menu? Submenu
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ToolbarItem_GetSubmenu_(NativePointer);
                var m = NativeObject.GetFromNativePointer<Menu>(n, p => new Menu(p));
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ToolbarItem_SetSubmenu_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.ToolbarItemEventCallbackType((obj, e, parameter) =>
                UI.Application.HandleThreadExceptions(() =>
                {
                    var w = NativeObject.GetFromNativePointer<ToolbarItem>(obj, p => new ToolbarItem(p));
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                ));
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
        private class NativeApi : NativeApiProvider
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
            public static extern IntPtr ToolbarItem_GetSubmenu_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ToolbarItem_SetSubmenu_(IntPtr obj, IntPtr value);
            
        }
    }
}
