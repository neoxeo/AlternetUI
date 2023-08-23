// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class SelectDirectoryDialog : NativeObject
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
                var n = NativeApi.SelectDirectoryDialog_GetInitialDirectory_(NativePointer);
                return n;
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
                var n = NativeApi.SelectDirectoryDialog_GetTitle_(NativePointer);
                return n;
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
                var n = NativeApi.SelectDirectoryDialog_GetDirectoryName_(NativePointer);
                return n;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.SelectDirectoryDialog_SetDirectoryName_(NativePointer, value);
            }
        }
        
        public ModalResult ShowModal(Window? owner)
        {
            CheckDisposed();
            var n = NativeApi.SelectDirectoryDialog_ShowModal_(NativePointer, owner?.NativePointer ?? IntPtr.Zero);
            return n;
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
            public static extern ModalResult SelectDirectoryDialog_ShowModal_(IntPtr obj, IntPtr owner);
            
        }
    }
}
