﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alternet.Drawing;

namespace Alternet.UI
{
    public partial class Control
    {
        /// <summary>
        /// Enumerates known handler types.
        /// </summary>
        public enum HandlerType
        {
            /// <summary>
            /// Native handler type.
            /// </summary>
            Native,

            /// <summary>
            /// Generic type.
            /// </summary>
            Generic,
        }

        internal static void NotifyCaptureLost()
        {
            Native.Control.NotifyCaptureLost();
        }

        internal static void PerformDefaultLayout(
            Control container,
            RectD childrenLayoutBounds,
            IReadOnlyList<Control> childs)
        {
            foreach (var control in childs)
            {
                var preferredSize = control.GetPreferredSizeLimited(childrenLayoutBounds.Size);

                var horizontalPosition =
                    LayoutFactory.AlignHorizontal(
                        childrenLayoutBounds,
                        control,
                        preferredSize,
                        control.HorizontalAlignment);
                var verticalPosition =
                    LayoutFactory.AlignVertical(
                        childrenLayoutBounds,
                        control,
                        preferredSize,
                        control.VerticalAlignment);

                control.Bounds = new RectD(
                    horizontalPosition.Origin,
                    verticalPosition.Origin,
                    horizontalPosition.Size,
                    verticalPosition.Size);
            }
        }

        internal static SizeD GetPreferredSizeDefaultLayout(Control container, SizeD availableSize)
        {
            if (container.HasChildren)
                return container.GetSpecifiedOrChildrenPreferredSize(availableSize);
            return container.Handler.GetNativeControlSize(availableSize);
        }

        internal static Color GetClassDefaultAttributesBgColor(
            ControlTypeId controlType,
            ControlRenderSizeVariant renderSize = ControlRenderSizeVariant.Normal)
        {
            return Native.Control.GetClassDefaultAttributesBgColor(
                (int)controlType,
                (int)renderSize);
        }

        internal static Color GetClassDefaultAttributesFgColor(
            ControlTypeId controlType,
            ControlRenderSizeVariant renderSize = ControlRenderSizeVariant.Normal)
        {
            return Native.Control.GetClassDefaultAttributesFgColor(
                (int)controlType,
                (int)renderSize);
        }

        internal static Font? GetClassDefaultAttributesFont(
            ControlTypeId controlType,
            ControlRenderSizeVariant renderSize = ControlRenderSizeVariant.Normal)
        {
            var font = Native.Control.GetClassDefaultAttributesFont(
                (int)controlType,
                (int)renderSize);
            return Font.FromInternal(font);
        }

        internal void ReportBoundsChanged()
        {
            var newBounds = Bounds;

            var locationChanged = reportedBounds?.Location != newBounds.Location;
            var sizeChanged = reportedBounds?.Size != newBounds.Size;

            reportedBounds = newBounds;

            if (locationChanged)
                RaiseLocationChanged(EventArgs.Empty);

            if (sizeChanged)
                RaiseSizeChanged(EventArgs.Empty);

            if (sizeChanged)
                PerformLayout(true);
        }

        /// <summary>
        /// Creates a handler for the control.
        /// </summary>
        /// <remarks>
        /// You typically should not call the <see cref="CreateHandler"/>
        /// method directly.
        /// The preferred method is to call the
        /// <see cref="EnsureHandlerCreated"/> method, which forces a handler
        /// to be created for the control.
        /// </remarks>
        internal virtual ControlHandler CreateHandler()
        {
            return new GenericControlHandler();
        }

        internal void RaiseNativeSizeChanged()
        {
            OnNativeSizeChanged(EventArgs.Empty);
        }

        internal void RaiseDeactivated()
        {
            Deactivated?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseHandleCreated()
        {
            OnHandleCreated(EventArgs.Empty);
            HandleCreated?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseHandleDestroyed()
        {
            OnHandleDestroyed(EventArgs.Empty);
            HandleDestroyed?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseActivated()
        {
            Activated?.Invoke(this, EventArgs.Empty);
        }

        internal Color? GetDefaultAttributesBgColor()
        {
            CheckDisposed();
            return GetNative().GetDefaultAttributesBgColor(this);
        }

        internal Color? GetDefaultAttributesFgColor()
        {
            CheckDisposed();
            return GetNative().GetDefaultAttributesFgColor(this);
        }

        internal Font? GetDefaultAttributesFont()
        {
            CheckDisposed();
            return GetNative().GetDefaultAttributesFont(this);
        }

        /// <summary>
        /// Forces the re-creation of the handler for the control.
        /// </summary>
        /// <remarks>
        /// The <see cref="RecreateHandler"/> method is called whenever
        /// re-execution of handler creation logic is needed.
        /// For example, this may happen when visual theme changes.
        /// </remarks>
        internal void RecreateHandler()
        {
            if (handler != null)
                DetachHandler();

            Invalidate();
        }

        /// <summary>
        /// Gets an <see cref="IControlHandlerFactory"/> to use when creating
        /// new control handlers for this control.
        /// </summary>
        internal IControlHandlerFactory GetEffectiveControlHandlerHactory() =>
            ControlHandlerFactory ??
                Application.Current.VisualTheme.ControlHandlerFactory;

        internal void RaiseKeyPress(KeyPressEventArgs e)
        {
            var control = this;
            var form = ParentWindow;
            if (form is not null && form.KeyPreview)
            {
                form.OnKeyPress(e);
                if (e.Handled)
                    return;
            }
            else
                form = null;

            while (control is not null && control != form)
            {
                control.OnKeyPress(e);

                if (e.Handled)
                    return;
                control = control.Parent;
            }
        }

        internal void RaiseMouseMove(MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        internal void RaiseMouseUp(MouseEventArgs e)
        {
            OnMouseUp(e);

            if (e.ChangedButton == MouseButton.Left)
            {
                OnMouseLeftButtonUp(e);
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                OnMouseRightButtonUp(e);
            }
        }

        internal void RaiseMouseDown(MouseEventArgs e)
        {
            /*Application.Log($"{GetType()}.RaiseMouseDown");*/
            OnMouseDown(e);
            /*Application.Log($"{GetType()}.RaiseMouseDown 2: {e}");*/

            if (e.ChangedButton == MouseButton.Left)
            {
                /*Application.Log($"{GetType()}.RaiseMouseDown 3");*/
                OnMouseLeftButtonDown(e);
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                OnMouseRightButtonDown(e);
            }
        }

        internal void RaiseProcessException(ControlExceptionEventArgs e)
        {
            OnProcessException(e);
            ProcessException?.Invoke(this, e);
        }

        internal void RaiseMouseWheel(MouseEventArgs e)
        {
            OnMouseWheel(e);
        }

        internal void RaiseMouseDoubleClick(MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        internal void RaiseKeyDown(KeyEventArgs e)
        {
            var control = this;
            var form = ParentWindow;
            if (form is not null)
            {
                if (form.KeyPreview)
                {
                    e.CurrentTarget = form;
                    form.OnKeyDown(e);
                    if (e.Handled)
                        return;
                }
                else
                    form = null;
            }

            while (control is not null && control != form)
            {
                e.CurrentTarget = control;
                control.OnKeyDown(e);

                if (e.Handled)
                    return;
                control = control.Parent;
            }
        }

        internal void RaiseKeyUp(KeyEventArgs e)
        {
            var control = this;
            var form = ParentWindow;
            if (form is not null && form.KeyPreview)
            {
                e.CurrentTarget = form;
                form.OnKeyUp(e);
                if (e.Handled)
                    return;
            }
            else
                form = null;

            while (control is not null && control != form)
            {
                e.CurrentTarget = control;
                control.OnKeyUp(e);
                if (e.Handled)
                    return;
                control = control.Parent;
            }
        }

        internal void RaiseTextChanged(EventArgs e) => OnTextChanged(e);

        internal void RaiseSizeChanged(EventArgs e) => OnSizeChanged(e);

        internal void RaiseScroll(ScrollEventArgs e) => OnScroll(e);

        internal void RaiseLocationChanged(EventArgs e) => OnLocationChanged(e);

        internal void RaiseMouseCaptureLost()
        {
            OnMouseCaptureLost(EventArgs.Empty);
            MouseCaptureLost?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseMouseEnter()
        {
            RaiseIsMouseOverChanged();
            OnMouseEnter(EventArgs.Empty);
            MouseEnter?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseCurrentStateChanged()
        {
            OnCurrentStateChanged(EventArgs.Empty);
            CurrentStateChanged?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseIsMouseOverChanged()
        {
            OnIsMouseOverChanged(EventArgs.Empty);
            IsMouseOverChanged?.Invoke(this, EventArgs.Empty);
            RaiseCurrentStateChanged();
        }

        internal void RaiseMouseLeave()
        {
            RaiseIsMouseOverChanged();
            OnMouseLeave(EventArgs.Empty);
            MouseLeave?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseChildInserted(Control childControl)
        {
            OnChildInserted(childControl);
            ChildInserted?.Invoke(this, new BaseEventArgs<Control>(childControl));
        }

        internal void RaiseChildRemoved(Control childControl)
        {
            OnChildInserted(childControl);
            ChildRemoved?.Invoke(this, new BaseEventArgs<Control>(childControl));
        }

        internal void RaisePaint(PaintEventArgs e)
        {
            OnPaint(e);
            Paint?.Invoke(this, e);
        }

        internal void RaiseGotFocus(EventArgs e)
        {
            OnGotFocus(e);
            GotFocus?.Invoke(this, e);
            Designer?.RaiseGotFocus(this);
            RaiseCurrentStateChanged();
        }

        internal void RaiseLostFocus(EventArgs e)
        {
            OnLostFocus(e);
            LostFocus?.Invoke(this, e);
            RaiseCurrentStateChanged();
        }

        internal void SetParentInternal(Control? value)
        {
            parent = value;
            LogicalParent = value;
        }

        internal virtual SizeD GetPreferredSizeLimited(SizeD availableSize)
        {
            var result = GetPreferredSize(availableSize);
            var minSize = MinimumSize;
            var maxSize = MaximumSize;
            var preferredSize = result.ApplyMinMax(minSize, maxSize);
            return preferredSize;
        }

        internal void RaiseDragStart(DragStartEventArgs e) => OnDragStart(e);

        internal void RaiseDragDrop(DragEventArgs e) => OnDragDrop(e);

        internal void RaiseDragOver(DragEventArgs e) => OnDragOver(e);

        internal void RaiseDragEnter(DragEventArgs e) => OnDragEnter(e);

        internal void RaiseDragLeave(EventArgs e) => OnDragLeave(e);

        internal void SendMouseDownEvent(int x, int y)
        {
            GetNative().SendMouseDownEvent(this, x, y);
        }

        internal void SendMouseUpEvent(int x, int y)
        {
            GetNative().SendMouseUpEvent(this, x, y);
        }

        internal bool BeginRepositioningChildren()
        {
            return GetNative().BeginRepositioningChildren(this);
        }

        internal void EndRepositioningChildren()
        {
            GetNative().EndRepositioningChildren(this);
        }

        internal Control? TryFindClosestParentWithNativeControl()
        {
            var control = this;
            if (control.NativeControl != null)
                return control;

            while (true)
            {
                control = control.Parent;
                if (control == null)
                    return null;

                if (control.NativeControl != null)
                    return control;
            }
        }

        internal void DoInsideRepositioningChildren(Action action)
        {
            var repositioning = BeginRepositioningChildren();
            if (repositioning)
            {
                try
                {
                    action();
                }
                finally
                {
                    EndRepositioningChildren();
                }
            }
            else
                action();
        }
    }
}
