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
    public partial class CheckBox : ButtonBase
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

        private bool allowAllStatesForUser;
        private bool alignRight;
        private bool threeState;
        private bool ignoreEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class with the specified text.
        /// </summary>
        /// <param name="text"></param>
        public CheckBox(string text)
            : this()
        {
            Text = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class.
        /// </summary>
        public CheckBox()
        {
            if (BaseApplication.IsWindowsOS && BaseApplication.PlatformKind == UIPlatformKind.WxWidgets)
                UserPaint = true;
        }

        /// <summary>
        /// Occurs when the value of the <see cref="IsChecked"/> property changes.
        /// </summary>
        public event EventHandler? CheckedChanged;

        /// <summary>
        /// Gets or sets the state of the <see cref="CheckBox" />.
        /// </summary>
        /// <returns>
        /// One of the <see cref="UI.CheckState"/> enumeration values. The default value
        /// is <see cref="CheckState.Unchecked"/>.
        /// </returns>
        [DefaultValue(CheckState.Unchecked)]
        [RefreshProperties(RefreshProperties.All)]
        public CheckState CheckState
        {
            get
            {
                return (CheckState)Handler.NativeControl.CheckState;
            }

            set
            {
                if (!threeState && value == CheckState.Indeterminate)
                    value = CheckState.Unchecked;
                if (CheckState == value)
                    return;
                Handler.NativeControl.CheckState = (int)value;
                RaiseCheckedChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="CheckBox" /> will
        /// allow three check states rather than two.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the <see cref="CheckBox" /> is able to display
        /// three check states; otherwise, <see langword="false" />. The default value
        /// is <see langword="false"/>.
        /// </returns>
        [DefaultValue(false)]
        public bool ThreeState
        {
            get
            {
                return threeState;
            }

            set
            {
                if (threeState == value)
                    return;
                if (!value && CheckState == CheckState.Indeterminate)
                {
                    CheckState = CheckState.Unchecked;
                }

                threeState = value;
                Handler.NativeControl.ThreeState = value;
            }
        }

        /// <summary>
        /// Gets or sets whether to align check box on the right side of the text.
        /// </summary>
        [DefaultValue(false)]
        public bool AlignRight
        {
            get
            {
                return alignRight;
            }

            set
            {
                if (alignRight == value)
                    return;
                alignRight = value;
                Handler.NativeControl.AlignRight = value;
            }
        }

        /// <summary>
        /// Gets or sets whether user can set the checkbox to
        /// the third state by clicking.
        /// </summary>
        /// <remarks>
        /// By default a user can't set a 3-state checkbox to the third state. It can only
        /// be done from code. Using this flags allows the user to set the checkbox to
        /// the third state by clicking.
        /// </remarks>
        [DefaultValue(false)]
        public bool AllowAllStatesForUser
        {
            get
            {
                return allowAllStatesForUser;
            }

            set
            {
                if (allowAllStatesForUser == value)
                    return;
                allowAllStatesForUser = value;
                Handler.NativeControl.AllowAllStatesForUser = value;
            }
        }

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
            get
            {
                return CheckState == CheckState.Checked;
            }

            set
            {
                if (value)
                    CheckState = CheckState.Checked;
                else
                    CheckState = CheckState.Unchecked;
            }
        }

        /// <inheritdoc/>
        public override ControlTypeId ControlKind => ControlTypeId.CheckBox;

        /// <summary>
        /// Gets a <see cref="WxControlHandler"/> associated with this class.
        /// </summary>
        [Browsable(false)]
        internal new CheckBoxHandler Handler => (CheckBoxHandler)base.Handler;

        /// <summary>
        /// Binds property specified with <paramref name="instance"/> and
        /// <paramref name="propName"/> to the <see cref="CheckBox"/>.
        /// After binding <see cref="CheckBox"/> will edit the specified property.
        /// </summary>
        /// <param name="instance">Object.</param>
        /// <param name="propName">Property name.</param>
        /// <remarks>Property must have the <see cref="bool"/> type. Value of the binded
        /// property will be changed automatically after <see cref="IsChecked"/> is changed.</remarks>
        public CheckBox BindBoolProp(object instance, string propName)
        {
            var propInfo = AssemblyUtils.GetPropInfo(instance, propName);
            if (propInfo is null)
                return this;
            object? result = propInfo?.GetValue(instance, null);
            IsChecked = result is true;

            CheckedChanged += Editor_CheckedChanged;

            void Editor_CheckedChanged(object? sender, EventArgs e)
            {
                var value = (sender as CheckBox)?.IsChecked;
                propInfo?.SetValue(instance, value);
            }

            return this;
        }

        /// <summary>
        /// Binds <see cref="IsChecked"/> to the specified property of the
        /// <see cref="FrameworkElement.DataContext"/>
        /// </summary>
        /// <param name="propName">Property name.</param>
        public void BindIsChecked(string propName)
        {
            Binding myBinding = new(propName) { Mode = BindingMode.TwoWay };
            BindingOperations.SetBinding(this, CheckBox.IsCheckedProperty, myBinding);
        }

        /// <summary>
        /// Raises the <see cref="CheckedChanged"/> event and calls
        /// <see cref="OnCheckedChanged(EventArgs)"/>.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the
        /// event data.</param>
        internal void RaiseCheckedChanged(EventArgs e)
        {
            OnCheckedChanged(e);
            CheckedChanged?.Invoke(this, e);
            ignoreEvent = true;
            try
            {
                SetValue(IsCheckedProperty, IsChecked);
            }
            finally
            {
                ignoreEvent = false;
            }
        }

        /// <inheritdoc/>
        protected override BaseControlHandler CreateHandler()
        {
            return new CheckBoxHandler();
        }

        /// <summary>
        /// Called when the value of the <see cref="IsChecked"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the
        /// event data.</param>
        protected virtual void OnCheckedChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Callback for changes to the IsChecked property
        /// </summary>
        private static void OnIsCheckedPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            CheckBox control = (CheckBox)d;
            if (control.ignoreEvent)
                return;
            control.IsChecked = (bool)e.NewValue;
        }

        private static object CoerceIsChecked(DependencyObject d, object value) => value;
    }
}