// Auto generated code, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2021.

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal abstract class MessageBox : NativeObject
    {
        private MessageBox()
        {
        }
        
        public MessageBox(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public static void Show(string text, string? caption)
        {
            NativeApi.MessageBox__Show(text, caption);
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void MessageBox__Show(string text, string? caption);
            
        }
    }
}
