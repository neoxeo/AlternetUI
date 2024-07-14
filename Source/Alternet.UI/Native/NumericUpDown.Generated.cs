// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class NumericUpDown : Control
    {
        static NumericUpDown()
        {
            SetEventCallback();
        }
        
        public NumericUpDown()
        {
            SetNativePointer(NativeApi.NumericUpDown_Create_());
        }
        
        public NumericUpDown(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public bool HasBorder
        {
            get
            {
                CheckDisposed();
                return NativeApi.NumericUpDown_GetHasBorder_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.NumericUpDown_SetHasBorder_(NativePointer, value);
            }
        }
        
        public int Minimum
        {
            get
            {
                CheckDisposed();
                return NativeApi.NumericUpDown_GetMinimum_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.NumericUpDown_SetMinimum_(NativePointer, value);
            }
        }
        
        public int Maximum
        {
            get
            {
                CheckDisposed();
                return NativeApi.NumericUpDown_GetMaximum_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.NumericUpDown_SetMaximum_(NativePointer, value);
            }
        }
        
        public int Value
        {
            get
            {
                CheckDisposed();
                return NativeApi.NumericUpDown_GetValue_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.NumericUpDown_SetValue_(NativePointer, value);
            }
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.NumericUpDownEventCallbackType((obj, e, parameter) =>
                    UI.Application.HandleThreadExceptions(() =>
                    {
                        var w = NativeObject.GetFromNativePointer<NumericUpDown>(obj, p => new NumericUpDown(p));
                        if (w == null) return IntPtr.Zero;
                        return w.OnEvent(e, parameter);
                    }
                    )
                );
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.NumericUpDown_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.NumericUpDownEvent e, IntPtr parameter)
        {
            ValueChanged?.Invoke(); return IntPtr.Zero;
        }
        
        public Action? ValueChanged;
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr NumericUpDownEventCallbackType(IntPtr obj, NumericUpDownEvent e, IntPtr param);
            
            public enum NumericUpDownEvent
            {
                ValueChanged,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void NumericUpDown_SetEventCallback_(NumericUpDownEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr NumericUpDown_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool NumericUpDown_GetHasBorder_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void NumericUpDown_SetHasBorder_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int NumericUpDown_GetMinimum_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void NumericUpDown_SetMinimum_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int NumericUpDown_GetMaximum_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void NumericUpDown_SetMaximum_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int NumericUpDown_GetValue_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void NumericUpDown_SetValue_(IntPtr obj, int value);
            
        }
    }
}
