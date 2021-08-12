// Auto generated code, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2021.

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class Font : NativeObject
    {
        public Font()
        {
            SetNativePointer(NativeApi.Font_Create_());
        }
        
        public Font(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public static System.String[] Families
        {
            get
            {
                var array = NativeApi.Font_OpenFamiliesArray_();
                try
                {
                    var count = NativeApi.Font_GetFamiliesItemCount_(array);
                    var result = new System.Collections.Generic.List<string>(count);
                    for (int i = 0; i < count; i++)
                    {
                        var item = NativeApi.Font_GetFamiliesItemAt_(array, i);
                        result.Add(item);
                    }
                    return result.ToArray();
                }
                finally
                {
                    NativeApi.Font_CloseFamiliesArray_(array);
                }
            }
            
        }
        
        public string Name
        {
            get
            {
                CheckDisposed();
                return NativeApi.Font_GetName_(NativePointer);
            }
            
        }
        
        public float Size
        {
            get
            {
                CheckDisposed();
                return NativeApi.Font_GetSize_(NativePointer);
            }
            
        }
        
        public void Initialize(GenericFontFamily genericFamily, string? familyName, float emSize)
        {
            CheckDisposed();
            NativeApi.Font_Initialize_(NativePointer, genericFamily, familyName, emSize);
        }
        
        public void InitializeWithDefaultFont()
        {
            CheckDisposed();
            NativeApi.Font_InitializeWithDefaultFont_(NativePointer);
        }
        
        public static bool IsFamilyValid(string fontFamily)
        {
            return NativeApi.Font_IsFamilyValid_(fontFamily);
        }
        
        public static string GetGenericFamilyName(GenericFontFamily genericFamily)
        {
            return NativeApi.Font_GetGenericFamilyName_(genericFamily);
        }
        
        public string ToString_()
        {
            CheckDisposed();
            return NativeApi.Font_ToString__(NativePointer);
        }
        
        public bool IsEqualTo(Font other)
        {
            CheckDisposed();
            return NativeApi.Font_IsEqualTo_(NativePointer, other.NativePointer);
        }
        
        public int GetHashCode_()
        {
            CheckDisposed();
            return NativeApi.Font_GetHashCode__(NativePointer);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Font_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string Font_GetName_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern float Font_GetSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr Font_OpenFamiliesArray_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int Font_GetFamiliesItemCount_(System.IntPtr array);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string Font_GetFamiliesItemAt_(System.IntPtr array, int index);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Font_CloseFamiliesArray_(System.IntPtr array);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Font_Initialize_(IntPtr obj, GenericFontFamily genericFamily, string? familyName, float emSize);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Font_InitializeWithDefaultFont_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Font_IsFamilyValid_(string fontFamily);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string Font_GetGenericFamilyName_(GenericFontFamily genericFamily);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string Font_ToString__(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Font_IsEqualTo_(IntPtr obj, IntPtr other);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int Font_GetHashCode__(IntPtr obj);
            
        }
    }
}
