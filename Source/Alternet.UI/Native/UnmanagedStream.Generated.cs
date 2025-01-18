// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2025 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class UnmanagedStream : NativeObject
    {
        static UnmanagedStream()
        {
        }
        
        public UnmanagedStream()
        {
            SetNativePointer(NativeApi.UnmanagedStream_Create_());
        }
        
        public UnmanagedStream(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public long Length
        {
            get
            {
                CheckDisposed();
                return NativeApi.UnmanagedStream_GetLength_(NativePointer);
            }
            
        }
        
        public bool IsOK
        {
            get
            {
                CheckDisposed();
                return NativeApi.UnmanagedStream_GetIsOK_(NativePointer);
            }
            
        }
        
        public bool IsSeekable
        {
            get
            {
                CheckDisposed();
                return NativeApi.UnmanagedStream_GetIsSeekable_(NativePointer);
            }
            
        }
        
        public long Position
        {
            get
            {
                CheckDisposed();
                return NativeApi.UnmanagedStream_GetPosition_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.UnmanagedStream_SetPosition_(NativePointer, value);
            }
        }
        
        public System.IntPtr Read(System.Byte[] buffer, System.IntPtr length)
        {
            CheckDisposed();
            return NativeApi.UnmanagedStream_Read_(NativePointer, buffer, buffer.Length, length);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr UnmanagedStream_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern long UnmanagedStream_GetLength_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool UnmanagedStream_GetIsOK_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool UnmanagedStream_GetIsSeekable_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern long UnmanagedStream_GetPosition_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void UnmanagedStream_SetPosition_(IntPtr obj, long value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr UnmanagedStream_Read_(IntPtr obj, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]System.Byte[] buffer, int bufferCount, System.IntPtr length);
            
        }
    }
}
