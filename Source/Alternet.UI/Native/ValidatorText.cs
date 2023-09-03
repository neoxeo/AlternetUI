// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class ValidatorText : Validator
    {
        static ValidatorText()
        {
        }
        
        public ValidatorText()
        {
            SetNativePointer(NativeApi.ValidatorText_Create_());
        }
        
        public ValidatorText(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public static void DeleteValidatorText(System.IntPtr handle)
        {
            NativeApi.ValidatorText_DeleteValidatorText_(handle);
        }
        
        public static System.IntPtr CreateValidatorText(long style)
        {
            var n = NativeApi.ValidatorText_CreateValidatorText_(style);
            return n;
        }
        
        public static long GetStyle(System.IntPtr handle)
        {
            var n = NativeApi.ValidatorText_GetStyle_(handle);
            return n;
        }
        
        public static void SetStyle(System.IntPtr handle, long style)
        {
            NativeApi.ValidatorText_SetStyle_(handle, style);
        }
        
        public static void SetCharIncludes(System.IntPtr handle, string chars)
        {
            NativeApi.ValidatorText_SetCharIncludes_(handle, chars);
        }
        
        public static void AddCharIncludes(System.IntPtr handle, string chars)
        {
            NativeApi.ValidatorText_AddCharIncludes_(handle, chars);
        }
        
        public static string GetCharIncludes(System.IntPtr handle)
        {
            var n = NativeApi.ValidatorText_GetCharIncludes_(handle);
            return n;
        }
        
        public static void AddInclude(System.IntPtr handle, string include)
        {
            NativeApi.ValidatorText_AddInclude_(handle, include);
        }
        
        public static void AddExclude(System.IntPtr handle, string exclude)
        {
            NativeApi.ValidatorText_AddExclude_(handle, exclude);
        }
        
        public static void SetCharExcludes(System.IntPtr handle, string chars)
        {
            NativeApi.ValidatorText_SetCharExcludes_(handle, chars);
        }
        
        public static void AddCharExcludes(System.IntPtr handle, string chars)
        {
            NativeApi.ValidatorText_AddCharExcludes_(handle, chars);
        }
        
        public static string GetCharExcludes(System.IntPtr handle)
        {
            var n = NativeApi.ValidatorText_GetCharExcludes_(handle);
            return n;
        }
        
        public static void ClearExcludes(System.IntPtr handle)
        {
            NativeApi.ValidatorText_ClearExcludes_(handle);
        }
        
        public static void ClearIncludes(System.IntPtr handle)
        {
            NativeApi.ValidatorText_ClearIncludes_(handle);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr ValidatorText_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ValidatorText_DeleteValidatorText_(System.IntPtr handle);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr ValidatorText_CreateValidatorText_(long style);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern long ValidatorText_GetStyle_(System.IntPtr handle);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ValidatorText_SetStyle_(System.IntPtr handle, long style);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ValidatorText_SetCharIncludes_(System.IntPtr handle, string chars);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ValidatorText_AddCharIncludes_(System.IntPtr handle, string chars);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string ValidatorText_GetCharIncludes_(System.IntPtr handle);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ValidatorText_AddInclude_(System.IntPtr handle, string include);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ValidatorText_AddExclude_(System.IntPtr handle, string exclude);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ValidatorText_SetCharExcludes_(System.IntPtr handle, string chars);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ValidatorText_AddCharExcludes_(System.IntPtr handle, string chars);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string ValidatorText_GetCharExcludes_(System.IntPtr handle);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ValidatorText_ClearExcludes_(System.IntPtr handle);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ValidatorText_ClearIncludes_(System.IntPtr handle);
            
        }
    }
}
