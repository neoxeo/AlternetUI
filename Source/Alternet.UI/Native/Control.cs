// Auto generated code, DO NOT MODIFY MANUALLY. Copyright AlterNET, 2021.

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;
namespace Alternet.UI.Native
{
    internal abstract class Control : NativeObject
    {
        protected Control()
        {
            SetEventCallback();
        }
        
        public Control(IntPtr nativePointer) : base(nativePointer)
        {
        }
        
        public Control? Parent
        {
            get
            {
                CheckDisposed();
                return NativeObject.GetFromNativePointer<Control>(NativeApi.Control_GetParent_(NativePointer), null);
            }
            
        }
        
        public System.Drawing.SizeF Size
        {
            get
            {
                CheckDisposed();
                return NativeApi.Control_GetSize_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetSize_(NativePointer, value);
            }
        }
        
        public System.Drawing.PointF Location
        {
            get
            {
                CheckDisposed();
                return NativeApi.Control_GetLocation_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetLocation_(NativePointer, value);
            }
        }
        
        public System.Drawing.RectangleF Bounds
        {
            get
            {
                CheckDisposed();
                return NativeApi.Control_GetBounds_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetBounds_(NativePointer, value);
            }
        }
        
        public System.Drawing.SizeF ClientSize
        {
            get
            {
                CheckDisposed();
                return NativeApi.Control_GetClientSize_(NativePointer);
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
                return NativeApi.Control_GetIntrinsicLayoutPadding_(NativePointer);
            }
            
        }
        
        public Alternet.UI.Thickness IntrinsicPreferredSizePadding
        {
            get
            {
                CheckDisposed();
                return NativeApi.Control_GetIntrinsicPreferredSizePadding_(NativePointer);
            }
            
        }
        
        public bool Visible
        {
            get
            {
                CheckDisposed();
                return NativeApi.Control_GetVisible_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetVisible_(NativePointer, value);
            }
        }
        
        public bool IsMouseOver
        {
            get
            {
                CheckDisposed();
                return NativeApi.Control_GetIsMouseOver_(NativePointer);
            }
            
        }
        
        public System.Drawing.Color BackgroundColor
        {
            get
            {
                CheckDisposed();
                return NativeApi.Control_GetBackgroundColor_(NativePointer);
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetBackgroundColor_(NativePointer, value);
            }
        }
        
        public System.Drawing.Color ForegroundColor
        {
            get
            {
                CheckDisposed();
                return NativeApi.Control_GetForegroundColor_(NativePointer);
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
                return NativeObject.GetFromNativePointer<Font>(NativeApi.Control_GetFont_(NativePointer), p => new Font(p));
            }
            
            set
            {
                CheckDisposed();
                NativeApi.Control_SetFont_(NativePointer, value?.NativePointer ?? IntPtr.Zero);
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
        
        public void Update()
        {
            CheckDisposed();
            NativeApi.Control_Update_(NativePointer);
        }
        
        public System.Drawing.SizeF GetPreferredSize(System.Drawing.SizeF availableSize)
        {
            CheckDisposed();
            return NativeApi.Control_GetPreferredSize_(NativePointer, availableSize);
        }
        
        public DrawingContext OpenPaintDrawingContext()
        {
            CheckDisposed();
            return NativeObject.GetFromNativePointer<DrawingContext>(NativeApi.Control_OpenPaintDrawingContext_(NativePointer), p => new DrawingContext(p))!;
        }
        
        public DrawingContext OpenClientDrawingContext()
        {
            CheckDisposed();
            return NativeObject.GetFromNativePointer<DrawingContext>(NativeApi.Control_OpenClientDrawingContext_(NativePointer), p => new DrawingContext(p))!;
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
        
        static GCHandle eventCallbackGCHandle;
        
        static void SetEventCallback()
        {
            if (!eventCallbackGCHandle.IsAllocated)
            {
                var sink = new NativeApi.ControlEventCallbackType((obj, e, parameter) =>
                {
                    var w = NativeObject.GetFromNativePointer<Control>(obj, null);
                    if (w == null) return IntPtr.Zero;
                    return w.OnEvent(e, parameter);
                }
                );
                eventCallbackGCHandle = GCHandle.Alloc(sink);
                NativeApi.Control_SetEventCallback_(sink);
            }
        }
        
        IntPtr OnEvent(NativeApi.ControlEvent e, IntPtr parameter)
        {
            switch (e)
            {
                case NativeApi.ControlEvent.Paint:
                Paint?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                case NativeApi.ControlEvent.MouseEnter:
                MouseEnter?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                case NativeApi.ControlEvent.MouseLeave:
                MouseLeave?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                case NativeApi.ControlEvent.MouseMove:
                MouseMove?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                case NativeApi.ControlEvent.MouseLeftButtonDown:
                MouseLeftButtonDown?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                case NativeApi.ControlEvent.MouseLeftButtonUp:
                MouseLeftButtonUp?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                case NativeApi.ControlEvent.MouseClick:
                MouseClick?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                case NativeApi.ControlEvent.VisibleChanged:
                VisibleChanged?.Invoke(this, EventArgs.Empty); return IntPtr.Zero;
                default: throw new Exception("Unexpected ControlEvent value: " + e);
            }
        }
        
        public event EventHandler? Paint;
        public event EventHandler? MouseEnter;
        public event EventHandler? MouseLeave;
        public event EventHandler? MouseMove;
        public event EventHandler? MouseLeftButtonDown;
        public event EventHandler? MouseLeftButtonUp;
        public event EventHandler? MouseClick;
        public event EventHandler? VisibleChanged;
        
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
                MouseMove,
                MouseLeftButtonDown,
                MouseLeftButtonUp,
                MouseClick,
                VisibleChanged,
            }
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetEventCallback_(ControlEventCallbackType callback);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Control_GetParent_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.SizeF Control_GetSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetSize_(IntPtr obj, NativeApiTypes.SizeF value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.PointF Control_GetLocation_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetLocation_(IntPtr obj, NativeApiTypes.PointF value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.RectangleF Control_GetBounds_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetBounds_(IntPtr obj, NativeApiTypes.RectangleF value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.SizeF Control_GetClientSize_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetClientSize_(IntPtr obj, NativeApiTypes.SizeF value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Thickness Control_GetIntrinsicLayoutPadding_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.Thickness Control_GetIntrinsicPreferredSizePadding_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Control_GetVisible_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_SetVisible_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern bool Control_GetIsMouseOver_(IntPtr obj);
            
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
            public static extern void Control_SetMouseCapture_(IntPtr obj, bool value);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_AddChild_(IntPtr obj, IntPtr control);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_RemoveChild_(IntPtr obj, IntPtr control);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_Update_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern NativeApiTypes.SizeF Control_GetPreferredSize_(IntPtr obj, NativeApiTypes.SizeF availableSize);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Control_OpenPaintDrawingContext_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Control_OpenClientDrawingContext_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_BeginUpdate_(IntPtr obj);
            
            [DllImport(NativeModuleName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Control_EndUpdate_(IntPtr obj);
            
        }
    }
}
