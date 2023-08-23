// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>
#nullable enable
#pragma warning disable

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
                return n;
            }
            
        }
        
        public Alternet.Drawing.Int32Size PixelSize
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Image_GetPixelSize_(NativePointer);
                return n;
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
        
        public void CopyFrom(Image otherImage)
        {
            CheckDisposed();
            NativeApi.Image_CopyFrom_(NativePointer, otherImage.NativePointer);
        }
        
        public void SaveToStream(OutputStream stream, string format)
        {
            CheckDisposed();
            NativeApi.Image_SaveToStream_(NativePointer, stream.NativePointer, format);
        }
        
        public void SaveToFile(string fileName)
        {
            CheckDisposed();
            NativeApi.Image_SaveToFile_(NativePointer, fileName);
        }
        
        public bool GrayScale()
        {
            CheckDisposed();
            var n = NativeApi.Image_GrayScale_(NativePointer);
            return n;
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Image_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.Drawing.Size Image_GetSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.Drawing.Int32Size Image_GetPixelSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Image_LoadFromStream_(IntPtr obj, IntPtr stream);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Image_Initialize_(IntPtr obj, Alternet.Drawing.Size size);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Image_CopyFrom_(IntPtr obj, IntPtr otherImage);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Image_SaveToStream_(IntPtr obj, IntPtr stream, string format);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Image_SaveToFile_(IntPtr obj, string fileName);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Image_GrayScale_(IntPtr obj);
            
        }
    }
}
