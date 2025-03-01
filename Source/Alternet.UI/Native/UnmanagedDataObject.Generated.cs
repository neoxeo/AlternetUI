// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2025 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class UnmanagedDataObject : NativeObject
    {
        static UnmanagedDataObject()
        {
        }
        
        public UnmanagedDataObject()
        {
            SetNativePointer(NativeApi.UnmanagedDataObject_Create_());
        }
        
        public UnmanagedDataObject(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public System.String[] Formats
        {
            get
            {
                CheckDisposed();
                var array = NativeApi.UnmanagedDataObject_OpenFormatsArray_(NativePointer);
                try
                {
                    var count = NativeApi.UnmanagedDataObject_GetFormatsItemCount_(NativePointer, array);
                    var result = new System.Collections.Generic.List<string>(count);
                    for (int i = 0; i < count; i++)
                    {
                        var n = NativeApi.UnmanagedDataObject_GetFormatsItemAt_(NativePointer, array, i);
                        var item = n;
                        result.Add(item);
                    }
                    return result.ToArray();
                }
                finally
                {
                    NativeApi.UnmanagedDataObject_CloseFormatsArray_(NativePointer, array);
                }
            }
            
        }
        
        public string GetStringData(string format)
        {
            CheckDisposed();
            return NativeApi.UnmanagedDataObject_GetStringData_(NativePointer, format);
        }
        
        public string GetFileNamesData(string format)
        {
            CheckDisposed();
            return NativeApi.UnmanagedDataObject_GetFileNamesData_(NativePointer, format);
        }
        
        public UnmanagedStream GetStreamData(string format)
        {
            CheckDisposed();
            var _nnn = NativeApi.UnmanagedDataObject_GetStreamData_(NativePointer, format);
            var _mmm = NativeObject.GetFromNativePointer<UnmanagedStream>(_nnn, p => new UnmanagedStream(p))!;
            ReleaseNativeObjectPointer(_nnn);
            return _mmm;
        }
        
        public void SetStringData(string format, string value)
        {
            CheckDisposed();
            NativeApi.UnmanagedDataObject_SetStringData_(NativePointer, format, value);
        }
        
        public void SetFileNamesData(string format, string value)
        {
            CheckDisposed();
            NativeApi.UnmanagedDataObject_SetFileNamesData_(NativePointer, format, value);
        }
        
        public void SetStreamData(string format, InputStream value)
        {
            CheckDisposed();
            NativeApi.UnmanagedDataObject_SetStreamData_(NativePointer, format, value.NativePointer);
        }
        
        public bool GetDataPresent(string format)
        {
            CheckDisposed();
            return NativeApi.UnmanagedDataObject_GetDataPresent_(NativePointer, format);
        }
        
        public bool GetNativeDataPresent(int format)
        {
            CheckDisposed();
            return NativeApi.UnmanagedDataObject_GetNativeDataPresent_(NativePointer, format);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr UnmanagedDataObject_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr UnmanagedDataObject_OpenFormatsArray_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int UnmanagedDataObject_GetFormatsItemCount_(IntPtr obj, System.IntPtr array);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string UnmanagedDataObject_GetFormatsItemAt_(IntPtr obj, System.IntPtr array, int index);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void UnmanagedDataObject_CloseFormatsArray_(IntPtr obj, System.IntPtr array);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string UnmanagedDataObject_GetStringData_(IntPtr obj, string format);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string UnmanagedDataObject_GetFileNamesData_(IntPtr obj, string format);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr UnmanagedDataObject_GetStreamData_(IntPtr obj, string format);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void UnmanagedDataObject_SetStringData_(IntPtr obj, string format, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void UnmanagedDataObject_SetFileNamesData_(IntPtr obj, string format, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void UnmanagedDataObject_SetStreamData_(IntPtr obj, string format, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool UnmanagedDataObject_GetDataPresent_(IntPtr obj, string format);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool UnmanagedDataObject_GetNativeDataPresent_(IntPtr obj, int format);
            
        }
    }
}
