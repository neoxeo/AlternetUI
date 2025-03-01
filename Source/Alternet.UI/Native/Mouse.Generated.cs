// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2025 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class Mouse : NativeObject
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
        
        public static Alternet.Drawing.PointI GetPosition()
        {
            return NativeApi.Mouse_GetPosition_();
        }
        
        public static Alternet.UI.MouseButtonState GetButtonState(Alternet.UI.MouseButton button)
        {
            return NativeApi.Mouse_GetButtonState_(button);
        }
        
        static GCHandle eventCallbackGCHandle;
        public static Mouse? GlobalObject;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.MouseEventCallbackType((obj, e, parameter) =>
                    UI.Application.HandleThreadExceptions(() =>
                    {
                        var w = NativeObject.GetFromNativePointer<Mouse>(obj, p => new Mouse(p));
                        w ??= GlobalObject;
                        if (w == null) return IntPtr.Zero;
                        return w.OnEvent(e, parameter);
                    }
                    )
                );
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.Mouse_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.MouseEvent e, IntPtr parameter)
        {
            var ea = new NativeEventArgs<MouseEventData>(MarshalEx.PtrToStructure<MouseEventData>(parameter));
            MouseChanged?.Invoke(this, ea); return ea.Result;
        }
        
        public event NativeEventHandler<MouseEventData>? MouseChanged;
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr MouseEventCallbackType(IntPtr obj, MouseEvent e, IntPtr param);
            
            public enum MouseEvent
            {
                MouseChanged,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Mouse_SetEventCallback_(MouseEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Mouse_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.Drawing.PointI Mouse_GetPosition_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.UI.MouseButtonState Mouse_GetButtonState_(Alternet.UI.MouseButton button);
            
        }
    }
}
