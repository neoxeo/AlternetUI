using System;
using System.ComponentModel;

namespace Alternet.UI
{
    internal class NativeWindowHandler : NativeControlHandler<Window, Native.Window>
    {
        internal override Native.Control CreateNativeControl()
        {
            return new Native.Window();
        }

        protected override void OnAttach()
        {
            base.OnAttach();

            ApplyTitle();
            ApplyShowInTaskbar();

            Control.TitleChanged += Control_TitleChanged;
            Control.ShowInTaskbarChanged += Control_ShowInTaskbarChanged;
            NativeControl.Closing += Control_Closing;
            NativeControl.SizeChanged += NativeControl_SizeChanged;
        }

        private void Control_ShowInTaskbarChanged(object? sender, EventArgs e)
        {
            if (e is null)
                throw new System.ArgumentNullException(nameof(e));

            ApplyShowInTaskbar();
        }

        private void ApplyShowInTaskbar()
        {
            NativeControl.ShowInTaskbar = Control.ShowInTaskbar;
        }

        private void NativeControl_SizeChanged(object? sender, EventArgs e)
        {
            PerformLayout();
        }

        private void Control_Closing(object? sender, CancelEventArgs? e)
        {
            if (e is null)
                throw new System.ArgumentNullException(nameof(e));

            // todo: add close reason/force parameter (see wxCloseEvent.CanVeto()).
            var closingEventArgs = new WindowClosingEventArgs(e.Cancel);
            Control.RaiseClosing(closingEventArgs);
            if (closingEventArgs.Cancel)
                return;

            Control.RaiseClosed(new WindowClosedEventArgs());
            Control.Dispose();
        }

        protected override void OnDetach()
        {
            NativeControl.SizeChanged -= NativeControl_SizeChanged;
            NativeControl.Closing -= Control_Closing;
            Control.TitleChanged -= Control_TitleChanged;

            base.OnDetach();
        }

        private void Control_TitleChanged(object? sender, System.EventArgs? e)
        {
            if (e is null)
                throw new System.ArgumentNullException(nameof(e));

            ApplyTitle();
        }

        private void ApplyTitle()
        {
            NativeControl.Title = Control.Title;
        }
    }
}