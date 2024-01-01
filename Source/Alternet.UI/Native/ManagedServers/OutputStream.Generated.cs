// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class OutputStream : ManagedServerObject
    {
        private static long GetLength_Trampoline(IntPtr obj)
        {
            return ((OutputStream)GCHandle.FromIntPtr(obj).Target).Length;
        }
        
        private static bool GetIsOK_Trampoline(IntPtr obj)
        {
            return ((OutputStream)GCHandle.FromIntPtr(obj).Target).IsOK;
        }
        
        private static bool GetIsSeekable_Trampoline(IntPtr obj)
        {
            return ((OutputStream)GCHandle.FromIntPtr(obj).Target).IsSeekable;
        }
        
        private static long GetPosition_Trampoline(IntPtr obj)
        {
            return ((OutputStream)GCHandle.FromIntPtr(obj).Target).Position;
        }
        private static void SetPosition_Trampoline(IntPtr obj, long value)
        {
            ((OutputStream)GCHandle.FromIntPtr(obj).Target).Position = value;
        }
        
        
        private static System.IntPtr Write_Trampoline(IntPtr obj, System.Byte[] buffer, System.IntPtr length)
        {
            return ((OutputStream)GCHandle.FromIntPtr(obj).Target).Write(buffer, length);
        }
        
        static GCHandle trampolineLocatorCallbackGCHandle;
        static readonly Dictionary<NativeApi.OutputStreamTrampoline, (GCHandle GCHandle, IntPtr Pointer)> trampolineHandles = new Dictionary<NativeApi.OutputStreamTrampoline, (GCHandle GCHandle, IntPtr Pointer)>();
        
        static OutputStream() { SetTrampolineLocatorCallback(); }
        static void SetTrampolineLocatorCallback()
        {
            if (!trampolineLocatorCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.OutputStreamTrampolineLocatorCallbackType(trampoline =>
                {
                    switch (trampoline)
                    {
                        case NativeApi.OutputStreamTrampoline.Write:
                        {
                            if (!trampolineHandles.TryGetValue(NativeApi.OutputStreamTrampoline.Write, out var handle))
                            {
                                var @delegate = (NativeApi.TWrite)Write_Trampoline;
                                handle = (GCHandle.Alloc(@delegate), Marshal.GetFunctionPointerForDelegate(@delegate));
                                trampolineHandles.Add(trampoline, handle);
                            }
                            return handle.Pointer;
                        }
                        case NativeApi.OutputStreamTrampoline.GetLength:
                        {
                            if (!trampolineHandles.TryGetValue(NativeApi.OutputStreamTrampoline.GetLength, out var handle))
                            {
                                var @delegate = (NativeApi.TGetLength)GetLength_Trampoline;
                                handle = (GCHandle.Alloc(@delegate), Marshal.GetFunctionPointerForDelegate(@delegate));
                                trampolineHandles.Add(trampoline, handle);
                            }
                            return handle.Pointer;
                        }
                        case NativeApi.OutputStreamTrampoline.GetIsOK:
                        {
                            if (!trampolineHandles.TryGetValue(NativeApi.OutputStreamTrampoline.GetIsOK, out var handle))
                            {
                                var @delegate = (NativeApi.TGetIsOK)GetIsOK_Trampoline;
                                handle = (GCHandle.Alloc(@delegate), Marshal.GetFunctionPointerForDelegate(@delegate));
                                trampolineHandles.Add(trampoline, handle);
                            }
                            return handle.Pointer;
                        }
                        case NativeApi.OutputStreamTrampoline.GetIsSeekable:
                        {
                            if (!trampolineHandles.TryGetValue(NativeApi.OutputStreamTrampoline.GetIsSeekable, out var handle))
                            {
                                var @delegate = (NativeApi.TGetIsSeekable)GetIsSeekable_Trampoline;
                                handle = (GCHandle.Alloc(@delegate), Marshal.GetFunctionPointerForDelegate(@delegate));
                                trampolineHandles.Add(trampoline, handle);
                            }
                            return handle.Pointer;
                        }
                        case NativeApi.OutputStreamTrampoline.GetPosition:
                        {
                            if (!trampolineHandles.TryGetValue(NativeApi.OutputStreamTrampoline.GetPosition, out var handle))
                            {
                                var @delegate = (NativeApi.TGetPosition)GetPosition_Trampoline;
                                handle = (GCHandle.Alloc(@delegate), Marshal.GetFunctionPointerForDelegate(@delegate));
                                trampolineHandles.Add(trampoline, handle);
                            }
                            return handle.Pointer;
                        }
                        case NativeApi.OutputStreamTrampoline.SetPosition:
                        {
                            if (!trampolineHandles.TryGetValue(NativeApi.OutputStreamTrampoline.SetPosition, out var handle))
                            {
                                var @delegate = (NativeApi.TSetPosition)SetPosition_Trampoline;
                                handle = (GCHandle.Alloc(@delegate), Marshal.GetFunctionPointerForDelegate(@delegate));
                                trampolineHandles.Add(trampoline, handle);
                            }
                            return handle.Pointer;
                        }
                        default: throw new Exception("Unexpected OutputStreamTrampoline value: " + trampoline);
                    }
                }
                );
                trampolineLocatorCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.OutputStream_SetTrampolineLocatorCallback(sink);
            }
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr OutputStreamTrampolineLocatorCallbackType(OutputStreamTrampoline value);
            
            public enum OutputStreamTrampoline
            {
                Write,
                GetLength,
                GetIsOK,
                GetIsSeekable,
                GetPosition,
                SetPosition,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OutputStream_SetTrampolineLocatorCallback(OutputStreamTrampolineLocatorCallbackType callback);
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            public delegate long TGetLength(IntPtr obj);
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            public delegate bool TGetIsOK(IntPtr obj);
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            public delegate bool TGetIsSeekable(IntPtr obj);
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            public delegate long TGetPosition(IntPtr obj);
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            public delegate void TSetPosition(IntPtr obj, long value);
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            public delegate System.IntPtr TWrite(IntPtr obj, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]System.Byte[] buffer, System.IntPtr length);
            
        }
    }
}
