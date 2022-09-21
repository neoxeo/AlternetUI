// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class Keyboard : NativeObject
    {
        static Keyboard()
        {
            SetEventCallback();
        }
        
        public Keyboard()
        {
            SetNativePointer(NativeApi.Keyboard_Create_());
        }
        
        public Keyboard(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public KeyStates GetKeyState(Key key)
        {
            CheckDisposed();
            var n = NativeApi.Keyboard_GetKeyState_(NativePointer, key);
            var m = n;
            return m;
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.KeyboardEventCallbackType((obj, e, parameter) =>
                {
                    var w = NativeObject.GetFromNativePointer<Keyboard>(obj, p => new Keyboard(p));
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                );
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.Keyboard_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.KeyboardEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.KeyboardEvent.KeyDown:
                {
                    var ea = new NativeEventArgs<KeyEventData>(MarshalEx.PtrToStructure<KeyEventData>(parameter));
                    KeyDown?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.KeyboardEvent.KeyUp:
                {
                    var ea = new NativeEventArgs<KeyEventData>(MarshalEx.PtrToStructure<KeyEventData>(parameter));
                    KeyUp?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.KeyboardEvent.TextInput:
                {
                    var ea = new NativeEventArgs<TextInputEventData>(MarshalEx.PtrToStructure<TextInputEventData>(parameter));
                    TextInput?.Invoke(this, ea); return ea.Result;
                }
                default: throw new Exception("Unexpected KeyboardEvent value: " + e);
            }
        }
        
        public event NativeEventHandler<KeyEventData>? KeyDown;
        public event NativeEventHandler<KeyEventData>? KeyUp;
        public event NativeEventHandler<TextInputEventData>? TextInput;
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr KeyboardEventCallbackType(IntPtr obj, KeyboardEvent e, IntPtr param);
            
            public enum KeyboardEvent
            {
                KeyDown,
                KeyUp,
                TextInput,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Keyboard_SetEventCallback_(KeyboardEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Keyboard_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern KeyStates Keyboard_GetKeyState_(IntPtr obj, Key key);
            
        }
    }
}
