// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class WxTreeViewFactory : NativeObject
    {
        static WxTreeViewFactory()
        {
        }
        
        public WxTreeViewFactory()
        {
            SetNativePointer(NativeApi.WxTreeViewFactory_Create_());
        }
        
        public WxTreeViewFactory(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public static void SetItemBold(System.IntPtr handle, System.IntPtr item, bool bold)
        {
            NativeApi.WxTreeViewFactory_SetItemBold_(handle, item, bold);
        }
        
        public static Alternet.Drawing.Color GetItemTextColor(System.IntPtr handle, System.IntPtr item)
        {
            return NativeApi.WxTreeViewFactory_GetItemTextColor_(handle, item);
        }
        
        public static Alternet.Drawing.Color GetItemBackgroundColor(System.IntPtr handle, System.IntPtr item)
        {
            return NativeApi.WxTreeViewFactory_GetItemBackgroundColor_(handle, item);
        }
        
        public static void SetItemTextColor(System.IntPtr handle, System.IntPtr item, Alternet.Drawing.Color color)
        {
            NativeApi.WxTreeViewFactory_SetItemTextColor_(handle, item, color);
        }
        
        public static void SetItemBackgroundColor(System.IntPtr handle, System.IntPtr item, Alternet.Drawing.Color color)
        {
            NativeApi.WxTreeViewFactory_SetItemBackgroundColor_(handle, item, color);
        }
        
        public static void ResetItemTextColor(System.IntPtr handle, System.IntPtr item)
        {
            NativeApi.WxTreeViewFactory_ResetItemTextColor_(handle, item);
        }
        
        public static void ResetItemBackgroundColor(System.IntPtr handle, System.IntPtr item)
        {
            NativeApi.WxTreeViewFactory_ResetItemBackgroundColor_(handle, item);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr WxTreeViewFactory_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WxTreeViewFactory_SetItemBold_(System.IntPtr handle, System.IntPtr item, bool bold);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Color WxTreeViewFactory_GetItemTextColor_(System.IntPtr handle, System.IntPtr item);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Color WxTreeViewFactory_GetItemBackgroundColor_(System.IntPtr handle, System.IntPtr item);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WxTreeViewFactory_SetItemTextColor_(System.IntPtr handle, System.IntPtr item, NativeApiTypes.Color color);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WxTreeViewFactory_SetItemBackgroundColor_(System.IntPtr handle, System.IntPtr item, NativeApiTypes.Color color);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WxTreeViewFactory_ResetItemTextColor_(System.IntPtr handle, System.IntPtr item);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void WxTreeViewFactory_ResetItemBackgroundColor_(System.IntPtr handle, System.IntPtr item);
            
        }
    }
}