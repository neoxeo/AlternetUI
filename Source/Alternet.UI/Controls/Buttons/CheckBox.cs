using System;
using System.ComponentModel;

namespace Alternet.UI
{
    /// <summary>
    /// Represents a check box control.
    /// </summary>
    /// <remarks>
    /// Use a <see cref="CheckBox"/> to give the user an option, such as true/false
    /// or yes/no.
    /// The <see cref="CheckBox"/> control can display an image or text or both.
    /// <see cref="CheckBox"/> and <see cref="RadioButton"/> controls have a
    /// similar function: they allow the user to
    /// choose from a list of options. <see cref="CheckBox"/> controls let the user
    /// pick a combination of options.
    /// In contrast, <see cref="RadioButton"/> controls allow a user to choose
    /// from mutually exclusive options.
    /// </remarks>
    [ControlCategory("Common")]
    public class CheckBox : ButtonBase
    {
        /// <summary>
        /// Identifies the <see cref="IsChecked"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register(
                    "IsChecked",
                    typeof(bool),
                    typeof(CheckBox),
                    new FrameworkPropertyMetadata(
                            false,
                            PropMetadataOption.BindsTwoWayByDefault | PropMetadataOption.AffectsPaint,
                            new PropertyChangedCallback(OnIsCheckedPropertyChanged),
                            new CoerceValueCallback(CoerceIsChecked),
                            isAnimationProhibited: true,
                            UpdateSourceTrigger.PropertyChanged));

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class with the specified text.
        /// </summary>
        /// <param name="text"></param>
        public CheckBox(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class.
        /// </summary>
        public CheckBox()
        {
        }

        /// <summary>
        /// Occurs when the value of the <see cref="IsChecked"/> property changes.
        /// </summary>
        public event EventHandler? CheckedChanged;

        /// <summary>
        /// Gets or set a value indicating whether the <see cref="CheckBox"/> is
        /// in the checked state.
        /// </summary>
        /// <value><c>true</c> if the <see cref="CheckBox"/> is in the checked
        /// state; otherwise, <c>false</c>.
        /// The default value is <c>false</c>.</value>
        /// <remarks>When the value is <c>true</c>, the <see cref="CheckBox"/>
        /// portion of the control displays a check mark.</remarks>
        [DefaultValue(false)]
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        /// <inheritdoc/>
        public override ControlId ControlKind => ControlId.CheckBox;

        /// <summary>
        /// Called when the value of the <see cref="IsChecked"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the
        /// event data.</param>
        protected virtual void OnCheckedChanged(EventArgs e)
        {
        }

        /// <inheritdoc/>
        protected override ControlHandler CreateHandler()
        {
            return GetEffectiveControlHandlerHactory().CreateCheckBoxHandler(this);
        }

        /// <summary>
        /// Callback for changes to the IsChecked property
        /// </summary>
        private static void OnIsCheckedPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            CheckBox control = (CheckBox)d;
            control.OnIsCheckedPropertyChanged((bool)e.OldValue, (bool)e.NewValue);
        }

        private static object CoerceIsChecked(DependencyObject d, object value) => value;

#pragma warning disable IDE0060 // Remove unused parameter
        private void OnIsCheckedPropertyChanged(bool oldValue, bool newValue)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            RaiseCheckedChanged(EventArgs.Empty);
        }

        /// <summary>
        /// Raises the <see cref="CheckedChanged"/> event and calls
        /// <see cref="OnCheckedChanged(EventArgs)"/>.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the
        /// event data.</param>
        private void RaiseCheckedChanged(EventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            OnCheckedChanged(e);
            CheckedChanged?.Invoke(this, e);
        }
    }
}