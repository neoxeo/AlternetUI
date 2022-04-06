// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class ProgressBar : Control
    {
        static ProgressBar()
        {
        }
        
        public ProgressBar()
        {
            SetNativePointer(NativeApi.ProgressBar_Create_());
        }
        
        public ProgressBar(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public int Minimum
        {
            get
            {
                CheckDisposed();
                return NativeApi.ProgressBar_GetMinimum_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ProgressBar_SetMinimum_(NativePointer, value);
            }
        }
        
        public int Maximum
        {
            get
            {
                CheckDisposed();
                return NativeApi.ProgressBar_GetMaximum_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ProgressBar_SetMaximum_(NativePointer, value);
            }
        }
        
        public int Value
        {
            get
            {
                CheckDisposed();
                return NativeApi.ProgressBar_GetValue_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ProgressBar_SetValue_(NativePointer, value);
            }
        }
        
        public bool IsIndeterminate
        {
            get
            {
                CheckDisposed();
                return NativeApi.ProgressBar_GetIsIndeterminate_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ProgressBar_SetIsIndeterminate_(NativePointer, value);
            }
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr ProgressBar_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int ProgressBar_GetMinimum_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ProgressBar_SetMinimum_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int ProgressBar_GetMaximum_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ProgressBar_SetMaximum_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int ProgressBar_GetValue_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ProgressBar_SetValue_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool ProgressBar_GetIsIndeterminate_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ProgressBar_SetIsIndeterminate_(IntPtr obj, bool value);
            
        }
    }
}
