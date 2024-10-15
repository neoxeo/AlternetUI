using System;
using System.ComponentModel;

namespace Alternet.UI
{
    /// <summary>
    /// Implements the basic functionality common to button controls.
    /// </summary>
    public abstract class ButtonBase : PlatformControl
    {
        private Action? clickAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonBase"/> class.
        /// </summary>
        /// <param name="parent">Parent of the control.</param>
        public ButtonBase(PlatformControl parent)
            : this()
        {
            Parent = parent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonBase"/> class.
        /// </summary>
        public ButtonBase()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control has a border.
        /// </summary>
        [Browsable(false)]
        public virtual bool HasBorder
        {
            get
            {
                return false;
            }

            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the text displayed on this button.
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                if (Text == value)
                    return;
                base.Text = value;
                PerformLayoutAndInvalidate();
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Action"/> which will be executed when
        /// this control is clicked by the user.
        /// </summary>
        [Browsable(false)]
        public virtual Action? ClickAction
        {
            get => clickAction;
            set
            {
                if (clickAction != null)
                    Click -= OnClickAction;
                clickAction = value;
                if (clickAction != null)
                    Click += OnClickAction;
            }
        }

        private void OnClickAction(object? sender, EventArgs e)
        {
            clickAction?.Invoke();
        }
    }
}