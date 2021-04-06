namespace Alternet.UI
{
    internal class NativeWindowHandler : NativeControlHandler<Window, Native.Window>
    {
        public NativeWindowHandler(Window control) : base(control)
        {
            Control.TitleChanged += Control_TitleChanged;
        }

        protected override Native.Control CreateNativeControl()
        {
            return new Native.Window();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.TitleChanged -= Control_TitleChanged;
            }

            base.Dispose(disposing);
        }

        private void Control_TitleChanged(object? sender, System.EventArgs? e)
        {
            if (e is null)
                throw new System.ArgumentNullException(nameof(e));

            NativeControl.Title = Control.Title;
        }
    }
}