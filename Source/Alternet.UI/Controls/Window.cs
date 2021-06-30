using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace Alternet.UI
{
    [System.ComponentModel.DesignerCategory("Code")]
    public class Window : Control
    {
        private string title = "";

        public Window()
        {
            Application.Current.RegisterWindow(this);
            SetVisibleValue(false);
            Bounds = new RectangleF(100, 100, 400, 400);
        }

        public event EventHandler? TitleChanged;

        public event CancelEventHandler? Closing;

        public event EventHandler? Closed;

        protected virtual void OnClosing(CancelEventArgs e) => Closing?.Invoke(this, e);
        protected virtual void OnClosed(EventArgs e) => Closed?.Invoke(this, e);

        internal void InvokeClosing(CancelEventArgs e) => OnClosing(e);
        internal void InvokeClosed(EventArgs e) => OnClosed(e);

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
                Application.Current.UnregisterWindow(this);
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                TitleChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public WindowStartPosition StartPosition { get; set;} = WindowStartPosition.SystemDefaultLocation;

        public SizeF Size
        {
            get
            {
                return Bounds.Size;
            }

            set
            {
                Handler.Bounds = new RectangleF(Bounds.Location, value);
            }
        }

        public override float Width { get => Size.Width; set => Size = new SizeF(value, Height); }

        public override float Height { get => Size.Height; set => Size = new SizeF(Width, value); }

        public PointF Location
        {
            get
            {
                return Bounds.Location;
            }

            set
            {
                Bounds = new RectangleF(value, Bounds.Size);
            }
        }

        public RectangleF Bounds
        {
            get
            {
                return Handler.Bounds;
            }

            set
            {
                Handler.Bounds = value;
            }
        }

        internal void RecreateAllHandlers()
        {
            void GetAllChildren(Control control, List<Control> result)
            {
                foreach (var child in control.Children)
                    GetAllChildren(child, result);

                if (control != this)
                    result.Add(control);
            }

            var children = new List<Control>();
            GetAllChildren(this, children);

            foreach (var child in children)
                child.DetachHandler();

            foreach (var child in children.AsEnumerable().Reverse())
                child.EnsureHandlerCreated();
        }

        protected override ControlHandler CreateHandler() => new NativeWindowHandler();
    }
}