using System;

namespace Alternet.UI
{
    /// <summary>
    /// Arranges child controls into a single line that can be oriented
    /// horizontally or vertically.
    /// </summary>
    [ControlCategory("Containers")]
    public class StackPanel : Control
    {
        private StackPanelOrientation orientation;

        /// <summary>
        /// Occurs when the value of the <see cref="Orientation"/> property changes.
        /// </summary>
        public event EventHandler? OrientationChanged;

        /// <summary>
        /// Gets or sets a value that indicates the dimension by which child
        /// controls are stacked.
        /// </summary>
        public virtual StackPanelOrientation Orientation
        {
            get => orientation;

            set
            {
                if (orientation == value)
                    return;

                orientation = value;

                OnOrientationChanged(EventArgs.Empty);
                PerformLayout();
            }
        }

        /// <inheritdoc/>
        public override ControlTypeId ControlKind => ControlTypeId.StackPanel;

        /// <summary>
        /// Called when the value of the <see cref="Orientation"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains
        /// the event data.</param>
        protected virtual void OnOrientationChanged(EventArgs e) =>
            OrientationChanged?.Invoke(this, e);

        /// <inheritdoc/>
        protected override ControlHandler CreateHandler()
        {
            return GetEffectiveControlHandlerHactory().CreateStackPanelHandler(this);
        }
    }
}