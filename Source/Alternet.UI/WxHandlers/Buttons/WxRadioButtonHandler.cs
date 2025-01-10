using System;

namespace Alternet.UI
{
    internal class WxRadioButtonHandler
        : WxControlHandler<RadioButton, Native.RadioButton>, IRadioButtonHandler
    {
        public Action? CheckedChanged
        {
            get => NativeControl.CheckedChanged;
            set => NativeControl.CheckedChanged = value;
        }

        public bool IsChecked
        {
            get => NativeControl.IsChecked;
            set => NativeControl.IsChecked = value;
        }

        internal override Native.Control CreateNativeControl()
        {
            return new Native.RadioButton();
        }

        protected override void OnAttach()
        {
            base.OnAttach();
            NativeControl.CheckedChanged = Control.RaiseCheckedChanged;
        }

        protected override void OnDetach()
        {
            base.OnDetach();
            NativeControl.CheckedChanged = null;
        }
    }
}