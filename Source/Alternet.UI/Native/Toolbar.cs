// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class Toolbar : Control
    {
        static Toolbar()
        {
        }
        
        public Toolbar()
        {
            SetNativePointer(NativeApi.Toolbar_Create_());
        }
        
        public Toolbar(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public int ItemsCount
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Toolbar_GetItemsCount_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool ItemTextVisible
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Toolbar_GetItemTextVisible_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Toolbar_SetItemTextVisible_(NativePointer, value);
            }
        }
        
        public bool ItemImagesVisible
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Toolbar_GetItemImagesVisible_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Toolbar_SetItemImagesVisible_(NativePointer, value);
            }
        }
        
        public ToolbarItemImageToTextDisplayMode ImageToTextDisplayMode
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Toolbar_GetImageToTextDisplayMode_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Toolbar_SetImageToTextDisplayMode_(NativePointer, value);
            }
        }
        
        public void InsertItemAt(int index, ToolbarItem item)
        {
            CheckDisposed();
            NativeApi.Toolbar_InsertItemAt_(NativePointer, index, item.NativePointer);
        }
        
        public void RemoveItemAt(int index)
        {
            CheckDisposed();
            NativeApi.Toolbar_RemoveItemAt_(NativePointer, index);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Toolbar_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int Toolbar_GetItemsCount_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Toolbar_GetItemTextVisible_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Toolbar_SetItemTextVisible_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Toolbar_GetItemImagesVisible_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Toolbar_SetItemImagesVisible_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern ToolbarItemImageToTextDisplayMode Toolbar_GetImageToTextDisplayMode_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Toolbar_SetImageToTextDisplayMode_(IntPtr obj, ToolbarItemImageToTextDisplayMode value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Toolbar_InsertItemAt_(IntPtr obj, int index, IntPtr item);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Toolbar_RemoveItemAt_(IntPtr obj, int index);
            
        }
    }
}
