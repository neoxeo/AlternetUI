// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class Image : NativeObject
    {
        static Image()
        {
        }
        
        public Image()
        {
            SetNativePointer(NativeApi.Image_Create_());
        }
        
        public Image(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public Alternet.Drawing.Size Size
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Image_GetSize_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public Alternet.Drawing.Int32Size PixelSize
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Image_GetPixelSize_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public void LoadFromStream(InputStream stream)
        {
            CheckDisposed();
            NativeApi.Image_LoadFromStream_(NativePointer, stream.NativePointer);
        }
        
        public void Initialize(Alternet.Drawing.Size size)
        {
            CheckDisposed();
            NativeApi.Image_Initialize_(NativePointer, size);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Image_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Size Image_GetSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Int32Size Image_GetPixelSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Image_LoadFromStream_(IntPtr obj, IntPtr stream);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Image_Initialize_(IntPtr obj, NativeApiTypes.Size size);
            
        }
    }
}
