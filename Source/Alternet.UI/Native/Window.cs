// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2023.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal class Window : Control
    {
        static Window()
        {
            SetEventCallback();
        }
        
        public Window()
        {
            SetNativePointer(NativeApi.Window_Create_());
        }
        
        public Window(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public string Title
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetTitle_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetTitle_(NativePointer, value);
            }
        }
        
        public WindowStartLocation WindowStartLocation
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetWindowStartLocation_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetWindowStartLocation_(NativePointer, value);
            }
        }
        
        public bool ShowInTaskbar
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetShowInTaskbar_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetShowInTaskbar_(NativePointer, value);
            }
        }
        
        public bool MinimizeEnabled
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetMinimizeEnabled_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetMinimizeEnabled_(NativePointer, value);
            }
        }
        
        public bool MaximizeEnabled
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetMaximizeEnabled_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetMaximizeEnabled_(NativePointer, value);
            }
        }
        
        public bool CloseEnabled
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetCloseEnabled_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetCloseEnabled_(NativePointer, value);
            }
        }
        
        public bool AlwaysOnTop
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetAlwaysOnTop_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetAlwaysOnTop_(NativePointer, value);
            }
        }
        
        public bool IsToolWindow
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetIsToolWindow_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetIsToolWindow_(NativePointer, value);
            }
        }
        
        public bool Resizable
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetResizable_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetResizable_(NativePointer, value);
            }
        }
        
        public bool HasBorder
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetHasBorder_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetHasBorder_(NativePointer, value);
            }
        }
        
        public bool HasTitleBar
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetHasTitleBar_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetHasTitleBar_(NativePointer, value);
            }
        }
        
        public ModalResult ModalResult
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetModalResult_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetModalResult_(NativePointer, value);
            }
        }
        
        public Alternet.Drawing.Size MinimumSize
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetMinimumSize_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetMinimumSize_(NativePointer, value);
            }
        }
        
        public Alternet.Drawing.Size MaximumSize
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetMaximumSize_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetMaximumSize_(NativePointer, value);
            }
        }
        
        public bool Modal
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetModal_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool IsActive
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetIsActive_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public static Window ActiveWindow
        {
            get
            {
                var n = NativeApi.Window_GetActiveWindow_();
                var m = NativeObject.GetFromNativePointer<Window>(n, p => new Window(p))!;
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
        }
        
        public Window[] OwnedWindows
        {
            get
            {
                CheckDisposed();
                var array = NativeApi.Window_OpenOwnedWindowsArray_(NativePointer);
                try
                {
                    var count = NativeApi.Window_GetOwnedWindowsItemCount_(NativePointer, array);
                    var result = new System.Collections.Generic.List<Window>(count);
                    for (int i = 0; i < count; i++)
                    {
                        var n = NativeApi.Window_GetOwnedWindowsItemAt_(NativePointer, array, i);
                        var item = NativeObject.GetFromNativePointer<Window>(n, p => new Window(p));
                        ReleaseNativeObjectPointer(n);
                        result.Add(item ?? throw new System.Exception());
                    }
                    return result.ToArray();
                }
                finally
                {
                    NativeApi.Window_CloseOwnedWindowsArray_(NativePointer, array);
                }
            }
            
        }
        
        public WindowState State
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetState_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetState_(NativePointer, value);
            }
        }
        
        public ImageSet? Icon
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetIcon_(NativePointer);
                var m = NativeObject.GetFromNativePointer<ImageSet>(n, p => new ImageSet(p));
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetIcon_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public MainMenu? Menu
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetMenu_(NativePointer);
                var m = NativeObject.GetFromNativePointer<MainMenu>(n, p => new MainMenu(p));
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetMenu_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public Toolbar? Toolbar
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetToolbar_(NativePointer);
                var m = NativeObject.GetFromNativePointer<Toolbar>(n, p => new Toolbar(p));
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetToolbar_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public StatusBar? StatusBar
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Window_GetStatusBar_(NativePointer);
                var m = NativeObject.GetFromNativePointer<StatusBar>(n, p => new StatusBar(p));
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Window_SetStatusBar_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public void ShowModal()
        {
            CheckDisposed();
            NativeApi.Window_ShowModal_(NativePointer);
        }
        
        public void Close()
        {
            CheckDisposed();
            NativeApi.Window_Close_(NativePointer);
        }
        
        public void Activate()
        {
            CheckDisposed();
            NativeApi.Window_Activate_(NativePointer);
        }
        
        public void AddInputBinding(string managedCommandId, Key key, ModifierKeys modifiers)
        {
            CheckDisposed();
            NativeApi.Window_AddInputBinding_(NativePointer, managedCommandId, key, modifiers);
        }
        
        public void RemoveInputBinding(string managedCommandId)
        {
            CheckDisposed();
            NativeApi.Window_RemoveInputBinding_(NativePointer, managedCommandId);
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.WindowEventCallbackType((obj, e, parameter) =>
                UI.Application.HandleThreadExceptions(() =>
                {
                    var w = NativeObject.GetFromNativePointer<Window>(obj, p => new Window(p));
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                ));
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.Window_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.WindowEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.WindowEvent.Closing:
                {
                    {
                        var cea = new CancelEventArgs();
                        Closing?.Invoke(this, cea);
                        return cea.Cancel ? new IntPtr(1) : IntPtr.Zero;
                    }
                }
                case NativeApi.WindowEvent.SizeChanged:
                {
                    SizeChanged?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.WindowEvent.LocationChanged:
                {
                    LocationChanged?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.WindowEvent.Activated:
                {
                    Activated?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.WindowEvent.Deactivated:
                {
                    Deactivated?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.WindowEvent.StateChanged:
                {
                    StateChanged?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.WindowEvent.InputBindingCommandExecuted:
                {
                    var ea = new NativeEventArgs<CommandEventData>(MarshalEx.PtrToStructure<CommandEventData>(parameter));
                    InputBindingCommandExecuted?.Invoke(this, ea); return ea.Result;
                }
                default: throw new Exception("Unexpected WindowEvent value: " + e);
            }
        }
        
        public event EventHandler<CancelEventArgs>? Closing;
        public event EventHandler? SizeChanged;
        public event EventHandler? LocationChanged;
        public event EventHandler? Activated;
        public event EventHandler? Deactivated;
        public event EventHandler? StateChanged;
        public event NativeEventHandler<CommandEventData>? InputBindingCommandExecuted;
        
        [SuppressUnmanagedCodeSecurity]
        public class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr WindowEventCallbackType(IntPtr obj, WindowEvent e, IntPtr param);
            
            public enum WindowEvent
            {
                Closing,
                SizeChanged,
                LocationChanged,
                Activated,
                Deactivated,
                StateChanged,
                InputBindingCommandExecuted,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetEventCallback_(WindowEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Window_Create_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string Window_GetTitle_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetTitle_(IntPtr obj, string value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern WindowStartLocation Window_GetWindowStartLocation_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetWindowStartLocation_(IntPtr obj, WindowStartLocation value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Window_GetShowInTaskbar_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetShowInTaskbar_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Window_GetMinimizeEnabled_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetMinimizeEnabled_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Window_GetMaximizeEnabled_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetMaximizeEnabled_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Window_GetCloseEnabled_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetCloseEnabled_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Window_GetAlwaysOnTop_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetAlwaysOnTop_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Window_GetIsToolWindow_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetIsToolWindow_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Window_GetResizable_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetResizable_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Window_GetHasBorder_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetHasBorder_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Window_GetHasTitleBar_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetHasTitleBar_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern ModalResult Window_GetModalResult_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetModalResult_(IntPtr obj, ModalResult value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Size Window_GetMinimumSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetMinimumSize_(IntPtr obj, NativeApiTypes.Size value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Size Window_GetMaximumSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetMaximumSize_(IntPtr obj, NativeApiTypes.Size value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Window_GetModal_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Window_GetIsActive_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Window_GetActiveWindow_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern WindowState Window_GetState_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetState_(IntPtr obj, WindowState value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Window_GetIcon_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetIcon_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Window_GetMenu_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetMenu_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Window_GetToolbar_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetToolbar_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Window_GetStatusBar_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_SetStatusBar_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr Window_OpenOwnedWindowsArray_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int Window_GetOwnedWindowsItemCount_(IntPtr obj, System.IntPtr array);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Window_GetOwnedWindowsItemAt_(IntPtr obj, System.IntPtr array, int index);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_CloseOwnedWindowsArray_(IntPtr obj, System.IntPtr array);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_ShowModal_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_Close_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_Activate_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_AddInputBinding_(IntPtr obj, string managedCommandId, Key key, ModifierKeys modifiers);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Window_RemoveInputBinding_(IntPtr obj, string managedCommandId);
            
        }
    }
}
