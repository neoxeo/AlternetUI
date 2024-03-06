// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2024 AlterNET Software.</auto-generated>
#nullable enable
#pragma warning disable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal partial class VListBox : Control
    {
        static VListBox()
        {
            SetEventCallback();
        }
        
        public VListBox()
        {
            SetNativePointer(NativeApi.VListBox_Create_());
        }
        
        public VListBox(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public System.IntPtr EventDc
        {
            get
            {
                CheckDisposed();
                return NativeApi.VListBox_GetEventDc_(NativePointer);
            }
            
        }
        
        public Alternet.Drawing.RectI EventRect
        {
            get
            {
                CheckDisposed();
                return NativeApi.VListBox_GetEventRect_(NativePointer);
            }
            
        }
        
        public int EventItem
        {
            get
            {
                CheckDisposed();
                return NativeApi.VListBox_GetEventItem_(NativePointer);
            }
            
        }
        
        public int EventHeight
        {
            get
            {
                CheckDisposed();
                return NativeApi.VListBox_GetEventHeight_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.VListBox_SetEventHeight_(NativePointer, value);
            }
        }
        
        public bool HasBorder
        {
            get
            {
                CheckDisposed();
                return NativeApi.VListBox_GetHasBorder_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.VListBox_SetHasBorder_(NativePointer, value);
            }
        }
        
        public int ItemsCount
        {
            get
            {
                CheckDisposed();
                return NativeApi.VListBox_GetItemsCount_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.VListBox_SetItemsCount_(NativePointer, value);
            }
        }
        
        public ListBoxSelectionMode SelectionMode
        {
            get
            {
                CheckDisposed();
                return NativeApi.VListBox_GetSelectionMode_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.VListBox_SetSelectionMode_(NativePointer, value);
            }
        }
        
        public static System.IntPtr CreateEx(long styles)
        {
            return NativeApi.VListBox_CreateEx_(styles);
        }
        
        public void ClearItems()
        {
            CheckDisposed();
            NativeApi.VListBox_ClearItems_(NativePointer);
        }
        
        public void ClearSelected()
        {
            CheckDisposed();
            NativeApi.VListBox_ClearSelected_(NativePointer);
        }
        
        public void SetSelected(int index, bool value)
        {
            CheckDisposed();
            NativeApi.VListBox_SetSelected_(NativePointer, index, value);
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.VListBoxEventCallbackType((obj, e, parameter) =>
                {
                    var w = NativeObject.GetFromNativePointer<VListBox>(obj, p => new VListBox(p));
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                );
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.VListBox_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.VListBoxEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.VListBoxEvent.SelectionChanged:
                {
                    SelectionChanged?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.VListBoxEvent.MeasureItem:
                {
                    MeasureItem?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.VListBoxEvent.DrawItem:
                {
                    DrawItem?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.VListBoxEvent.DrawItemBackground:
                {
                    DrawItemBackground?.Invoke(); return IntPtr.Zero;
                }
                case NativeApi.VListBoxEvent.ControlRecreated:
                {
                    ControlRecreated?.Invoke(); return IntPtr.Zero;
                }
                default: throw new Exception("Unexpected VListBoxEvent value: " + e);
            }
        }
        
        public Action? SelectionChanged;
        public Action? MeasureItem;
        public Action? DrawItem;
        public Action? DrawItemBackground;
        public Action? ControlRecreated;
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr VListBoxEventCallbackType(IntPtr obj, VListBoxEvent e, IntPtr param);
            
            public enum VListBoxEvent
            {
                SelectionChanged,
                MeasureItem,
                DrawItem,
                DrawItemBackground,
                ControlRecreated,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void VListBox_SetEventCallback_(VListBoxEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr VListBox_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr VListBox_GetEventDc_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern Alternet.Drawing.RectI VListBox_GetEventRect_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int VListBox_GetEventItem_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int VListBox_GetEventHeight_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void VListBox_SetEventHeight_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool VListBox_GetHasBorder_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void VListBox_SetHasBorder_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int VListBox_GetItemsCount_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void VListBox_SetItemsCount_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern ListBoxSelectionMode VListBox_GetSelectionMode_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void VListBox_SetSelectionMode_(IntPtr obj, ListBoxSelectionMode value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr VListBox_CreateEx_(long styles);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void VListBox_ClearItems_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void VListBox_ClearSelected_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void VListBox_SetSelected_(IntPtr obj, int index, bool value);
            
        }
    }
}