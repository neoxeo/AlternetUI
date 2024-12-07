﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Alternet.UI
{
    /// <summary>
    /// An empty implementation of the <see cref="IControlNotification"/> interface.
    /// </summary>
    public class ControlNotification : DisposableObject, IControlNotification
    {
        /// <inheritdoc/>
        public virtual void AfterLongTap(AbstractControl sender, LongTapEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterSetScrollBarInfo(
            AbstractControl sender,
            bool isVertical,
            ScrollBarInfo value)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterScroll(AbstractControl sender, ScrollEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterActivated(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterCreate(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterCellChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterChildInserted(AbstractControl sender, int index, AbstractControl childControl)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterChildRemoved(AbstractControl sender, AbstractControl childControl)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterClick(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterDeactivated(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterDpiChanged(AbstractControl sender, DpiChangedEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterDragDrop(AbstractControl sender, DragEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterDragEnter(AbstractControl sender, DragEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterDragLeave(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterDragOver(AbstractControl sender, DragEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterDragStart(AbstractControl sender, DragStartEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterEnabledChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterFontChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterGotFocus(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterHandleCreated(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterHandleDestroyed(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterHandlerAttached(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterHandlerDetaching(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterContainerLocationChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterHandlerSizeChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterHelpRequested(AbstractControl sender, HelpEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterIdle(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterIsMouseOverChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterKeyDown(AbstractControl sender, KeyEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterKeyPress(AbstractControl sender, KeyPressEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterKeyUp(AbstractControl sender, KeyEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterLocationChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterLostFocus(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMarginChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMouseCaptureLost(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMouseDoubleClick(AbstractControl sender, MouseEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMouseDown(AbstractControl sender, MouseEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMouseEnter(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMouseLeave(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMouseLeftButtonDown(AbstractControl sender, MouseEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMouseLeftButtonUp(AbstractControl sender, MouseEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMouseMove(AbstractControl sender, MouseEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMouseRightButtonDown(AbstractControl sender, MouseEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMouseRightButtonUp(AbstractControl sender, MouseEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMouseUp(AbstractControl sender, MouseEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterMouseWheel(AbstractControl sender, MouseEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterPaddingChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterPaint(AbstractControl sender, PaintEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterPaintBackground(AbstractControl sender, PaintEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterParentChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterProcessException(AbstractControl sender, ThrowExceptionEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterQueryContinueDrag(AbstractControl sender, QueryContinueDragEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterResize(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterSizeChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterSystemColorsChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterTextChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterTitleChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterToolTipChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterTouch(AbstractControl sender, TouchEventArgs e)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterVisibleChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterVisualStateChanged(AbstractControl sender)
        {
        }

        /// <inheritdoc/>
        public virtual void AfterPreviewKeyDown(
            AbstractControl sender,
            Key key,
            ModifierKeys modifiers,
            ref bool isInputKey)
        {
        }
    }
}