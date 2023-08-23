// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class PropertyGrid : Control
    {
        static PropertyGrid()
        {
        }
        
        public PropertyGrid()
        {
            SetNativePointer(NativeApi.PropertyGrid_Create_());
        }
        
        public PropertyGrid(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public static string NameAsLabel
        {
            get
            {
                var n = NativeApi.PropertyGrid_GetNameAsLabel_();
                return n;
            }
            
        }
        
        public bool HasBorder
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.PropertyGrid_GetHasBorder_(NativePointer);
                return n;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.PropertyGrid_SetHasBorder_(NativePointer, value);
            }
        }
        
        public long CreateStyle
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.PropertyGrid_GetCreateStyle_(NativePointer);
                return n;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.PropertyGrid_SetCreateStyle_(NativePointer, value);
            }
        }
        
        public static System.IntPtr CreateEx(long styles)
        {
            var n = NativeApi.PropertyGrid_CreateEx_(styles);
            return n;
        }
        
        public System.IntPtr CreateStringProperty(string label, string name, string value)
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_CreateStringProperty_(NativePointer, label, name, value);
            return n;
        }
        
        public System.IntPtr CreateBoolProperty(string label, string name, bool value)
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_CreateBoolProperty_(NativePointer, label, name, value);
            return n;
        }
        
        public System.IntPtr CreateIntProperty(string label, string name, long value)
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_CreateIntProperty_(NativePointer, label, name, value);
            return n;
        }
        
        public System.IntPtr CreateFloatProperty(string label, string name, double value)
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_CreateFloatProperty_(NativePointer, label, name, value);
            return n;
        }
        
        public System.IntPtr CreateUIntProperty(string label, string name, ulong value)
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_CreateUIntProperty_(NativePointer, label, name, value);
            return n;
        }
        
        public System.IntPtr CreateLongStringProperty(string label, string name, string value)
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_CreateLongStringProperty_(NativePointer, label, name, value);
            return n;
        }
        
        public System.IntPtr CreateDateProperty(string label, string name, DateTime value)
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_CreateDateProperty_(NativePointer, label, name, value);
            return n;
        }
        
        public void Clear()
        {
            CheckDisposed();
            NativeApi.PropertyGrid_Clear_(NativePointer);
        }
        
        public System.IntPtr Append(System.IntPtr property)
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_Append_(NativePointer, property);
            return n;
        }
        
        public System.IntPtr CreateEnumProperty(string label, string name, System.IntPtr choices, int value)
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_CreateEnumProperty_(NativePointer, label, name, choices, value);
            return n;
        }
        
        public System.IntPtr CreateFlagsProperty(string label, string name, System.IntPtr choices, int value)
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_CreateFlagsProperty_(NativePointer, label, name, choices, value);
            return n;
        }
        
        public bool ClearSelection(bool validation)
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_ClearSelection_(NativePointer, validation);
            return n;
        }
        
        public void ClearModifiedStatus()
        {
            CheckDisposed();
            NativeApi.PropertyGrid_ClearModifiedStatus_(NativePointer);
        }
        
        public bool CollapseAll()
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_CollapseAll_(NativePointer);
            return n;
        }
        
        public bool EditorValidate()
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_EditorValidate_(NativePointer);
            return n;
        }
        
        public bool ExpandAll(bool expand)
        {
            CheckDisposed();
            var n = NativeApi.PropertyGrid_ExpandAll_(NativePointer, expand);
            return n;
        }
        
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr PropertyGrid_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string PropertyGrid_GetNameAsLabel_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool PropertyGrid_GetHasBorder_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PropertyGrid_SetHasBorder_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern long PropertyGrid_GetCreateStyle_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PropertyGrid_SetCreateStyle_(IntPtr obj, long value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr PropertyGrid_CreateEx_(long styles);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr PropertyGrid_CreateStringProperty_(IntPtr obj, string label, string name, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr PropertyGrid_CreateBoolProperty_(IntPtr obj, string label, string name, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr PropertyGrid_CreateIntProperty_(IntPtr obj, string label, string name, long value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr PropertyGrid_CreateFloatProperty_(IntPtr obj, string label, string name, double value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr PropertyGrid_CreateUIntProperty_(IntPtr obj, string label, string name, ulong value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr PropertyGrid_CreateLongStringProperty_(IntPtr obj, string label, string name, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr PropertyGrid_CreateDateProperty_(IntPtr obj, string label, string name, NativeApiTypes.DateTime value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PropertyGrid_Clear_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr PropertyGrid_Append_(IntPtr obj, System.IntPtr property);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr PropertyGrid_CreateEnumProperty_(IntPtr obj, string label, string name, System.IntPtr choices, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr PropertyGrid_CreateFlagsProperty_(IntPtr obj, string label, string name, System.IntPtr choices, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool PropertyGrid_ClearSelection_(IntPtr obj, bool validation);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PropertyGrid_ClearModifiedStatus_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool PropertyGrid_CollapseAll_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool PropertyGrid_EditorValidate_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool PropertyGrid_ExpandAll_(IntPtr obj, bool expand);
            
        }
    }
}
