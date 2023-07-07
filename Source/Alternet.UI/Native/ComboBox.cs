// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class ComboBox : Control
    {
        static ComboBox()
        {
            SetEventCallback();
        }
        
        public ComboBox()
        {
            SetNativePointer(NativeApi.ComboBox_Create_());
        }
        
        public ComboBox(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public int ItemsCount
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ComboBox_GetItemsCount_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool IsEditable
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ComboBox_GetIsEditable_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ComboBox_SetIsEditable_(NativePointer, value);
            }
        }
        
        public int SelectedIndex
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ComboBox_GetSelectedIndex_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ComboBox_SetSelectedIndex_(NativePointer, value);
            }
        }
        
        public string Text
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ComboBox_GetText_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.ComboBox_SetText_(NativePointer, value);
            }
        }
        
        public int TextSelectionStart
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ComboBox_GetTextSelectionStart_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public int TextSelectionLength
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.ComboBox_GetTextSelectionLength_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public void InsertItem(int index, string value)
        {
            CheckDisposed();
            NativeApi.ComboBox_InsertItem_(NativePointer, index, value);
        }
        
        public System.IntPtr CreateItemsInsertion()
        {
            CheckDisposed();
            var n = NativeApi.ComboBox_CreateItemsInsertion_(NativePointer);
            var m = n;
            return m;
        }
        
        public void AddItemToInsertion(System.IntPtr insertion, string item)
        {
            CheckDisposed();
            NativeApi.ComboBox_AddItemToInsertion_(NativePointer, insertion, item);
        }
        
        public void CommitItemsInsertion(System.IntPtr insertion, int index)
        {
            CheckDisposed();
            NativeApi.ComboBox_CommitItemsInsertion_(NativePointer, insertion, index);
        }
        
        public void RemoveItemAt(int index)
        {
            CheckDisposed();
            NativeApi.ComboBox_RemoveItemAt_(NativePointer, index);
        }
        
        public void ClearItems()
        {
            CheckDisposed();
            NativeApi.ComboBox_ClearItems_(NativePointer);
        }
        
        public void SelectTextRange(int start, int length)
        {
            CheckDisposed();
            NativeApi.ComboBox_SelectTextRange_(NativePointer, start, length);
        }
        
        public void SelectAllText()
        {
            CheckDisposed();
            NativeApi.ComboBox_SelectAllText_(NativePointer);
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.ComboBoxEventCallbackType((obj, e, parameter) =>
                UI.Application.HandleThreadExceptions(() =>
                {
                    var w = NativeObject.GetFromNativePointer<ComboBox>(obj, p => new ComboBox(p));
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                ));
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.ComboBox_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.ComboBoxEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.ComboBoxEvent.SelectedItemChanged:
                {
                    SelectedItemChanged?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.ComboBoxEvent.TextChanged:
                {
                    TextChanged?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                default: throw new Exception("Unexpected ComboBoxEvent value: " + e);
            }
        }
        
        public event EventHandler? SelectedItemChanged;
        public event EventHandler? TextChanged;
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr ComboBoxEventCallbackType(IntPtr obj, ComboBoxEvent e, IntPtr param);
            
            public enum ComboBoxEvent
            {
                SelectedItemChanged,
                TextChanged,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ComboBox_SetEventCallback_(ComboBoxEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr ComboBox_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int ComboBox_GetItemsCount_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool ComboBox_GetIsEditable_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ComboBox_SetIsEditable_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int ComboBox_GetSelectedIndex_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ComboBox_SetSelectedIndex_(IntPtr obj, int value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string ComboBox_GetText_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ComboBox_SetText_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int ComboBox_GetTextSelectionStart_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int ComboBox_GetTextSelectionLength_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ComboBox_InsertItem_(IntPtr obj, int index, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr ComboBox_CreateItemsInsertion_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ComboBox_AddItemToInsertion_(IntPtr obj, System.IntPtr insertion, string item);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ComboBox_CommitItemsInsertion_(IntPtr obj, System.IntPtr insertion, int index);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ComboBox_RemoveItemAt_(IntPtr obj, int index);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ComboBox_ClearItems_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ComboBox_SelectTextRange_(IntPtr obj, int start, int length);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ComboBox_SelectAllText_(IntPtr obj);
            
        }
    }
}
