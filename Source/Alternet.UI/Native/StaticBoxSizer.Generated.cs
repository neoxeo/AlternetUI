// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class StaticBoxSizer : BoxSizer
    {
        static StaticBoxSizer()
        {
        }
        
        public StaticBoxSizer()
        {
            SetNativePointer(NativeApi.StaticBoxSizer_Create_());
        }
        
        public StaticBoxSizer(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr StaticBoxSizer_Create_();
            
        }
    }
}