// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class Mouse : NativeObject
    {
        static Mouse()
        {
            SetEventCallback();
        }
        
        public Mouse()
        {
            SetNativePointer(NativeApi.Mouse_Create_());
        }
        
        public Mouse(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public Alternet.Drawing.Point GetPosition()
        {
            CheckDisposed();
            return NativeApi.Mouse_GetPosition_(NativePointer);
        }
        
        public MouseButtonState GetButtonState(MouseButton button)
        {
            CheckDisposed();
            return NativeApi.Mouse_GetButtonState_(NativePointer, button);
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.MouseEventCallbackType((obj, e, parameter) =>
                {
                    var w = NativeObject.GetFromNativePointer<Mouse>(obj, p => new Mouse(p));
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                );
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.Mouse_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.MouseEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.MouseEvent.MouseMove:
                {
                    var ea = new NativeEventArgs<MouseEventData>(MarshalEx.PtrToStructure<MouseEventData>(parameter));
                    MouseMove?.Invoke(this, ea); return ea.Handled ? new IntPtr(1) : IntPtr.Zero;
                }
                default: throw new Exception("Unexpected MouseEvent value: " + e);
            }
        }
        
        public event NativeEventHandler<MouseEventData>? MouseMove;
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr MouseEventCallbackType(IntPtr obj, MouseEvent e, IntPtr param);
            
            public enum MouseEvent
            {
                MouseMove,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Mouse_SetEventCallback_(MouseEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Mouse_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Point Mouse_GetPosition_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern MouseButtonState Mouse_GetButtonState_(IntPtr obj, MouseButton button);
            
        }
    }
}
