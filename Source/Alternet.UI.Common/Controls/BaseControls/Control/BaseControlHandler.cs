﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    public abstract class BaseControlHandler : DisposableObject, IControlHandler
    {
        private Control? control;

        /// <summary>
        /// Gets a <see cref="Control"/> this handler provides the implementation for.
        /// </summary>
        public Control Control
        {
            get => control ?? throw new InvalidOperationException();
        }

        public abstract Action? Idle { get; set; }

        public abstract Action? Paint { get; set; }

        public abstract Action? MouseEnter { get; set; }

        public abstract Action? MouseLeave { get; set; }

        public abstract Action? MouseClick { get; set; }

        public abstract Action? VisibleChanged { get; set; }

        public abstract Action? MouseCaptureLost { get; set; }

        public abstract Action? GotFocus { get; set; }

        public abstract Action? LostFocus { get; set; }

        public abstract Action? DragLeave { get; set; }

        public abstract Action? VerticalScrollBarValueChanged { get; set; }

        public abstract Action? HorizontalScrollBarValueChanged { get; set; }

        public abstract Action? SizeChanged { get; set; }

        public abstract Action? Activated { get; set; }

        public abstract Action? Deactivated { get; set; }

        public abstract Action? HandleCreated { get; set; }

        public abstract Action? HandleDestroyed { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="WxControlHandler"/> is attached
        /// to a <see cref="Control"/>.
        /// </summary>
        public bool IsAttached => control != null;

        public abstract bool IsNativeControlCreated { get; }

        public abstract object GetNativeControl();

        public void RaiseChildInserted(Control childControl)
        {
            Control.RaiseChildInserted(childControl);
            OnChildInserted(childControl);
        }

        public void RaiseChildRemoved(Control childControl)
        {
            Control.RaiseChildRemoved(childControl);
            OnChildRemoved(childControl);
        }

        /// <summary>
        /// Attaches this handler to the specified <see cref="Control"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/> to attach this
        /// handler to.</param>
        public void Attach(Control control)
        {
            this.control = control;
            OnAttach();
        }

        /// <summary>
        /// Detaches this handler from the <see cref="Control"/> it is attached to.
        /// </summary>
        public virtual void Detach()
        {
            OnDetach();

            control = null;
        }

        /// <summary>
        /// This methods is called when the layout of the control changes.
        /// </summary>
        public virtual void OnLayoutChanged()
        {
        }

        /// <summary>
        /// Called when a <see cref="Control"/> is inserted into the
        /// <see cref="Control.Children"/> collection.
        /// </summary>
        protected virtual void OnChildInserted(Control childControl)
        {
        }

        /// <summary>
        /// Called when a <see cref="Control"/> is removed from the
        /// <see cref="Control.Children"/> collections.
        /// </summary>
        protected virtual void OnChildRemoved(Control childControl)
        {
        }

        /// <summary>
        /// Called after this handler has been detached from the <see cref="Control"/>.
        /// </summary>
        protected abstract void OnDetach();

        /// <summary>
        /// Called after this handler has been attached to a <see cref="Control"/>.
        /// </summary>
        protected abstract void OnAttach();
    }
}
