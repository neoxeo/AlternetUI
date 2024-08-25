﻿using System;
using System.Collections.Generic;
using System.Text;

using Alternet.UI;

namespace Alternet.Drawing
{
    /// <summary>
    /// Implements scroll bar drawing.
    /// </summary>
    public class ScrollBarDrawable : BaseDrawable
    {
        /// <summary>
        /// Gets or sets background element.
        /// </summary>
        public ControlStateObjects<RectangleDrawable>? Background;

        /// <summary>
        /// Gets or sets scroll thumb element.
        /// </summary>
        public ControlStateObjects<RectangleDrawable>? Thumb;

        /// <summary>
        /// Gets or sets up button element.
        /// </summary>
        public ControlStateObjects<RectangleDrawable>? UpButton;

        /// <summary>
        /// Gets or sets down button element.
        /// </summary>
        public ControlStateObjects<RectangleDrawable>? DownButton;

        /// <summary>
        /// Gets or sets left button element.
        /// </summary>
        public ControlStateObjects<RectangleDrawable>? LeftButton;

        /// <summary>
        /// Gets or sets right button element.
        /// </summary>
        public ControlStateObjects<RectangleDrawable>? RightButton;

        /// <summary>
        /// Gets or sets up arrow element.
        /// </summary>
        public ControlStateObjects<RectangleDrawable>? UpArrow;

        /// <summary>
        /// Gets or sets down arrow element.
        /// </summary>
        public ControlStateObjects<RectangleDrawable>? DownArrowPainter;

        /// <summary>
        /// Gets or sets primitive painter for the left arrow.
        /// </summary>
        public ControlStateObjects<RectangleDrawable>? LeftArrowPainter;

        /// <summary>
        /// Gets or sets primitive painter for the right arrow.
        /// </summary>
        public ControlStateObjects<RectangleDrawable>? RightArrowPainter;

        /// <summary>
        /// Gets of sets whether scroll bar is vertical.
        /// </summary>
        public bool IsVertical = true;

        private ScrollBar.MetricsInfo? metrics;

        /// <inheritdoc/>
        public override RectD Bounds
        {
            get
            {
                return Bounds;
            }

            set
            {
                if (Bounds == value)
                    return;
                Bounds = value;
            }
        }

        /// <summary>
        /// Gets or sets scroll bar metrics.
        /// </summary>
        public virtual ScrollBar.MetricsInfo? Metrics
        {
            get
            {
                return metrics;
            }

            set
            {
                metrics = value;
            }
        }

        /// <summary>
        /// Gets real scroll bar metrics. If <see cref="Metrics"/> is not specified, returns
        /// <see cref="ScrollBar.DefaultMetrics"/>.
        /// </summary>
        /// <returns></returns>
        public virtual ScrollBar.MetricsInfo GetRealMetrics()
        {
            return metrics ?? ScrollBar.DefaultMetrics;
        }

        /// <inheritdoc/>
        public override void Draw(Control control, Graphics dc)
        {
            if (!Visible)
                return;

            Background?.GetObjectOrNormal(VisualState)?.Draw(control, dc);

            var startButton = GetStartButton();
            var endButton = GetEndButton();
            var startArrow = GetStartArrow();
            var endArrow = GetEndArrow();

            startButton?.Draw(control, dc);
            startArrow?.Draw(control, dc);
            endButton?.Draw(control, dc);
            endArrow?.Draw(control, dc);
        }

        private RectangleDrawable? GetEndArrow()
        {
            if (IsVertical)
                return DownArrowPainter?.GetObjectOrNormal(VisualState);
            return RightArrowPainter?.GetObjectOrNormal(VisualState);
        }

        private RectangleDrawable? GetStartArrow()
        {
            if (IsVertical)
                return UpArrow?.GetObjectOrNormal(VisualState);
            return LeftArrowPainter?.GetObjectOrNormal(VisualState);
        }

        private RectangleDrawable? GetStartButton()
        {
            if (IsVertical)
                return UpButton?.GetObjectOrNormal(VisualState);
            return LeftButton?.GetObjectOrNormal(VisualState);
        }

        private RectangleDrawable? GetEndButton()
        {
            if (IsVertical)
                return DownButton?.GetObjectOrNormal(VisualState);
            return RightButton?.GetObjectOrNormal(VisualState);
        }
    }
}
