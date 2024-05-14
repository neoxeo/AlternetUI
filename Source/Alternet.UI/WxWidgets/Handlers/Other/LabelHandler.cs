using System;

namespace Alternet.UI
{
    internal class LabelHandler
        : NativeControlHandler<Label, Native.Label>, ILabelHandler
    {
        internal override Native.Control CreateNativeControl()
        {
            return new Native.Label() { Text = Control.Text };
        }

        protected override void OnAttach()
        {
            base.OnAttach();

            NativeControl.Text = Control.Text;

            Control.TextChanged += Control_TextChanged;
        }

        protected override void OnDetach()
        {
            base.OnDetach();
            Control.TextChanged -= Control_TextChanged;
        }

        private void Control_TextChanged(object? sender, EventArgs e)
        {
            if (NativeControl.Text != Control.Text)
                NativeControl.Text = Control.Text;
        }
    }
}