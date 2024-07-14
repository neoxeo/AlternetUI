// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class Label : Control
    {
        static Label()
        {
        }
        
        public Label()
        {
            SetNativePointer(NativeApi.Label_Create_());
        }
        
        public Label(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public bool IsEllipsized()
        {
            CheckDisposed();
            return NativeApi.Label_IsEllipsized_(NativePointer);
        }
        
        public void Wrap(int width)
        {
            CheckDisposed();
            NativeApi.Label_Wrap_(NativePointer, width);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Label_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Label_IsEllipsized_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Label_Wrap_(IntPtr obj, int width);
            
        }
    }
}
