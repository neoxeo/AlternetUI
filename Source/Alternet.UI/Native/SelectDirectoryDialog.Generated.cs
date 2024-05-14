// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class SelectDirectoryDialog : NativeObject
    {
        static SelectDirectoryDialog()
        {
        }
        
        public SelectDirectoryDialog()
        {
            SetNativePointer(NativeApi.SelectDirectoryDialog_Create_());
        }
        
        public SelectDirectoryDialog(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public string? InitialDirectory
        {
            get
            {
                CheckDisposed();
                return NativeApi.SelectDirectoryDialog_GetInitialDirectory_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.SelectDirectoryDialog_SetInitialDirectory_(NativePointer, value);
            }
        }
        
        public string? Title
        {
            get
            {
                CheckDisposed();
                return NativeApi.SelectDirectoryDialog_GetTitle_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.SelectDirectoryDialog_SetTitle_(NativePointer, value);
            }
        }
        
        public string? DirectoryName
        {
            get
            {
                CheckDisposed();
                return NativeApi.SelectDirectoryDialog_GetDirectoryName_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.SelectDirectoryDialog_SetDirectoryName_(NativePointer, value);
            }
        }
        
        public Alternet.UI.ModalResult ShowModal(Window? owner)
        {
            CheckDisposed();
            return NativeApi.SelectDirectoryDialog_ShowModal_(NativePointer, owner?.NativePointer ?? IntPtr.Zero);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SelectDirectoryDialog_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string? SelectDirectoryDialog_GetInitialDirectory_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void SelectDirectoryDialog_SetInitialDirectory_(IntPtr obj, string? value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string? SelectDirectoryDialog_GetTitle_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void SelectDirectoryDialog_SetTitle_(IntPtr obj, string? value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string? SelectDirectoryDialog_GetDirectoryName_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void SelectDirectoryDialog_SetDirectoryName_(IntPtr obj, string? value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.UI.ModalResult SelectDirectoryDialog_ShowModal_(IntPtr obj, IntPtr owner);
            
        }
    }
}
