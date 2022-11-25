// <auto-generated>This code was generated by a tool, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2022.</auto-generated>
#nullable enable

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal abstract class Control : NativeObject
    {
        static Control()
        {
            SetEventCallback();
        }
        
        protected Control()
        {
        }
        
        public Control(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public Control? ParentRefCounted
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetParentRefCounted_(NativePointer);
                var m = NativeObject.GetFromNativePointer<Control>(n, null);
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
        }
        
        public string? ToolTip
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetToolTip_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetToolTip_(NativePointer, value);
            }
        }
        
        public bool AllowDrop
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetAllowDrop_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetAllowDrop_(NativePointer, value);
            }
        }
        
        public Alternet.Drawing.Size Size
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetSize_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetSize_(NativePointer, value);
            }
        }
        
        public Alternet.Drawing.Point Location
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetLocation_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetLocation_(NativePointer, value);
            }
        }
        
        public Alternet.Drawing.Rect Bounds
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetBounds_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetBounds_(NativePointer, value);
            }
        }
        
        public Alternet.Drawing.Size ClientSize
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetClientSize_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetClientSize_(NativePointer, value);
            }
        }
        
        public Alternet.UI.Thickness IntrinsicLayoutPadding
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetIntrinsicLayoutPadding_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public Alternet.UI.Thickness IntrinsicPreferredSizePadding
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetIntrinsicPreferredSizePadding_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool Visible
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetVisible_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetVisible_(NativePointer, value);
            }
        }
        
        public bool Enabled
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetEnabled_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetEnabled_(NativePointer, value);
            }
        }
        
        public bool UserPaint
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetUserPaint_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetUserPaint_(NativePointer, value);
            }
        }
        
        public bool IsMouseOver
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetIsMouseOver_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public bool HasWindowCreated
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetHasWindowCreated_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public Alternet.Drawing.Color BackgroundColor
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetBackgroundColor_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetBackgroundColor_(NativePointer, value);
            }
        }
        
        public Alternet.Drawing.Color ForegroundColor
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetForegroundColor_(NativePointer);
                var m = n;
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetForegroundColor_(NativePointer, value);
            }
        }
        
        public Font? Font
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetFont_(NativePointer);
                var m = NativeObject.GetFromNativePointer<Font>(n, p => new Font(p));
                ReleaseNativeObjectPointer(n);
                return m;
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetFont_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
            }
        }
        
        public bool IsMouseCaptured
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetIsMouseCaptured_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public System.IntPtr Handle
        {
            get
            {
                CheckDisposed();
                var n = NativeApi.Control_GetHandle_(NativePointer);
                var m = n;
                return m;
            }
            
        }
        
        public void SetMouseCapture(bool value)
        {
            CheckDisposed();
            NativeApi.Control_SetMouseCapture_(NativePointer, value);
        }
        
        public void AddChild(Control control)
        {
            CheckDisposed();
            NativeApi.Control_AddChild_(NativePointer, control.NativePointer);
        }
        
        public void RemoveChild(Control control)
        {
            CheckDisposed();
            NativeApi.Control_RemoveChild_(NativePointer, control.NativePointer);
        }
        
        public void Invalidate()
        {
            CheckDisposed();
            NativeApi.Control_Invalidate_(NativePointer);
        }
        
        public void Update()
        {
            CheckDisposed();
            NativeApi.Control_Update_(NativePointer);
        }
        
        public Alternet.Drawing.Size GetPreferredSize(Alternet.Drawing.Size availableSize)
        {
            CheckDisposed();
            var n = NativeApi.Control_GetPreferredSize_(NativePointer, availableSize);
            var m = n;
            return m;
        }
        
        public DragDropEffects DoDragDrop(UnmanagedDataObject data, DragDropEffects allowedEffects)
        {
            CheckDisposed();
            var n = NativeApi.Control_DoDragDrop_(NativePointer, data.NativePointer, allowedEffects);
            var m = n;
            return m;
        }
        
        public DrawingContext OpenPaintDrawingContext()
        {
            CheckDisposed();
            var n = NativeApi.Control_OpenPaintDrawingContext_(NativePointer);
            var m = NativeObject.GetFromNativePointer<DrawingContext>(n, p => new DrawingContext(p))!;
            ReleaseNativeObjectPointer(n);
            return m;
        }
        
        public DrawingContext OpenClientDrawingContext()
        {
            CheckDisposed();
            var n = NativeApi.Control_OpenClientDrawingContext_(NativePointer);
            var m = NativeObject.GetFromNativePointer<DrawingContext>(n, p => new DrawingContext(p))!;
            ReleaseNativeObjectPointer(n);
            return m;
        }
        
        public void BeginUpdate()
        {
            CheckDisposed();
            NativeApi.Control_BeginUpdate_(NativePointer);
        }
        
        public void EndUpdate()
        {
            CheckDisposed();
            NativeApi.Control_EndUpdate_(NativePointer);
        }
        
        public static Control? GetFocusedControl()
        {
            var n = NativeApi.Control_GetFocusedControl_();
            var m = NativeObject.GetFromNativePointer<Control>(n, null);
            ReleaseNativeObjectPointer(n);
            return m;
        }
        
        public static Control? HitTest(Alternet.Drawing.Point screenPoint)
        {
            var n = NativeApi.Control_HitTest_(screenPoint);
            var m = NativeObject.GetFromNativePointer<Control>(n, null);
            ReleaseNativeObjectPointer(n);
            return m;
        }
        
        public Alternet.Drawing.Point ClientToScreen(Alternet.Drawing.Point point)
        {
            CheckDisposed();
            var n = NativeApi.Control_ClientToScreen_(NativePointer, point);
            var m = n;
            return m;
        }
        
        public Alternet.Drawing.Point ScreenToClient(Alternet.Drawing.Point point)
        {
            CheckDisposed();
            var n = NativeApi.Control_ScreenToClient_(NativePointer, point);
            var m = n;
            return m;
        }
        
        public Alternet.Drawing.Int32Point ScreenToDevice(Alternet.Drawing.Point point)
        {
            CheckDisposed();
            var n = NativeApi.Control_ScreenToDevice_(NativePointer, point);
            var m = n;
            return m;
        }
        
        public Alternet.Drawing.Point DeviceToScreen(Alternet.Drawing.Int32Point point)
        {
            CheckDisposed();
            var n = NativeApi.Control_DeviceToScreen_(NativePointer, point);
            var m = n;
            return m;
        }
        
        public bool Focus()
        {
            CheckDisposed();
            var n = NativeApi.Control_Focus_(NativePointer);
            var m = n;
            return m;
        }
        
        public void BeginInit()
        {
            CheckDisposed();
            NativeApi.Control_BeginInit_(NativePointer);
        }
        
        public void EndInit()
        {
            CheckDisposed();
            NativeApi.Control_EndInit_(NativePointer);
        }
        
        public void Destroy()
        {
            CheckDisposed();
            NativeApi.Control_Destroy_(NativePointer);
        }
        
        public void SaveScreenshot(string fileName)
        {
            CheckDisposed();
            NativeApi.Control_SaveScreenshot_(NativePointer, fileName);
        }
        
        public void SendSizeEvent()
        {
            CheckDisposed();
            NativeApi.Control_SendSizeEvent_(NativePointer);
        }
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.ControlEventCallbackType((obj, e, parameter) =>
                UI.Application.HandleThreadExceptions(() =>
                {
                    var w = NativeObject.GetFromNativePointer<Control>(obj, null);
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                ));
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.Control_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.ControlEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.ControlEvent.Paint:
                {
                    Paint?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.ControlEvent.MouseEnter:
                {
                    MouseEnter?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.ControlEvent.MouseLeave:
                {
                    MouseLeave?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.ControlEvent.MouseClick:
                {
                    MouseClick?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.ControlEvent.VisibleChanged:
                {
                    VisibleChanged?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.ControlEvent.MouseCaptureLost:
                {
                    MouseCaptureLost?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.ControlEvent.Destroyed:
                {
                    Destroyed?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                case NativeApi.ControlEvent.DragDrop:
                {
                    var ea = new NativeEventArgs<DragEventData>(MarshalEx.PtrToStructure<DragEventData>(parameter));
                    DragDrop?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.ControlEvent.DragOver:
                {
                    var ea = new NativeEventArgs<DragEventData>(MarshalEx.PtrToStructure<DragEventData>(parameter));
                    DragOver?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.ControlEvent.DragEnter:
                {
                    var ea = new NativeEventArgs<DragEventData>(MarshalEx.PtrToStructure<DragEventData>(parameter));
                    DragEnter?.Invoke(this, ea); return ea.Result;
                }
                case NativeApi.ControlEvent.DragLeave:
                {
                    DragLeave?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                }
                default: throw new Exception("Unexpected ControlEvent value: " + e);
            }
        }
        
        public event EventHandler? Paint;
        public event EventHandler? MouseEnter;
        public event EventHandler? MouseLeave;
        public event EventHandler? MouseClick;
        public event EventHandler? VisibleChanged;
        public event EventHandler? MouseCaptureLost;
        public event EventHandler? Destroyed;
        public event NativeEventHandler<DragEventData>? DragDrop;
        public event NativeEventHandler<DragEventData>? DragOver;
        public event NativeEventHandler<DragEventData>? DragEnter;
        public event EventHandler? DragLeave;
        
        [SuppressUnmanagedCodeSecurity]
        private class NativeApi : NativeApiProvider
        {
            static NativeApi() => Initialize();
            
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr ControlEventCallbackType(IntPtr obj, ControlEvent e, IntPtr param);
            
            public enum ControlEvent
            {
                Paint,
                MouseEnter,
                MouseLeave,
                MouseClick,
                VisibleChanged,
                MouseCaptureLost,
                Destroyed,
                DragDrop,
                DragOver,
                DragEnter,
                DragLeave,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetEventCallback_(ControlEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Control_GetParentRefCounted_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern string? Control_GetToolTip_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetToolTip_(IntPtr obj, string? value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Control_GetAllowDrop_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetAllowDrop_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Size Control_GetSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetSize_(IntPtr obj, NativeApiTypes.Size value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Point Control_GetLocation_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetLocation_(IntPtr obj, NativeApiTypes.Point value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Rect Control_GetBounds_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetBounds_(IntPtr obj, NativeApiTypes.Rect value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Size Control_GetClientSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetClientSize_(IntPtr obj, NativeApiTypes.Size value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Thickness Control_GetIntrinsicLayoutPadding_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Thickness Control_GetIntrinsicPreferredSizePadding_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Control_GetVisible_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetVisible_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Control_GetEnabled_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetEnabled_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Control_GetUserPaint_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetUserPaint_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Control_GetIsMouseOver_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Control_GetHasWindowCreated_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Color Control_GetBackgroundColor_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetBackgroundColor_(IntPtr obj, NativeApiTypes.Color value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Color Control_GetForegroundColor_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetForegroundColor_(IntPtr obj, NativeApiTypes.Color value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Control_GetFont_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetFont_(IntPtr obj, IntPtr value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Control_GetIsMouseCaptured_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern System.IntPtr Control_GetHandle_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetMouseCapture_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_AddChild_(IntPtr obj, IntPtr control);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_RemoveChild_(IntPtr obj, IntPtr control);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_Invalidate_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_Update_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Size Control_GetPreferredSize_(IntPtr obj, NativeApiTypes.Size availableSize);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern DragDropEffects Control_DoDragDrop_(IntPtr obj, IntPtr data, DragDropEffects allowedEffects);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Control_OpenPaintDrawingContext_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Control_OpenClientDrawingContext_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_BeginUpdate_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_EndUpdate_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Control_GetFocusedControl_();
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Control_HitTest_(NativeApiTypes.Point screenPoint);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Point Control_ClientToScreen_(IntPtr obj, NativeApiTypes.Point point);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Point Control_ScreenToClient_(IntPtr obj, NativeApiTypes.Point point);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Int32Point Control_ScreenToDevice_(IntPtr obj, NativeApiTypes.Point point);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Point Control_DeviceToScreen_(IntPtr obj, NativeApiTypes.Int32Point point);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Control_Focus_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_BeginInit_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_EndInit_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_Destroy_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SaveScreenshot_(IntPtr obj, string fileName);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SendSizeEvent_(IntPtr obj);
            
        }
    }
}
