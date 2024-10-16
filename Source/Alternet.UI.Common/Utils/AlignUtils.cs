﻿using System;
using System.Collections.Generic;
using System.Text;

using Alternet.Drawing;

namespace Alternet.UI
{
    /// <summary>
    /// Contains static methods and properties related to the layout and align.
    /// </summary>
    public static class AlignUtils
    {
        /// <summary>
        /// Converts <see cref="TextHorizontalAlignment"/> to <see cref="HorizontalAlignment"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static HorizontalAlignment Convert(TextHorizontalAlignment value)
        {
            switch (value)
            {
                case TextHorizontalAlignment.Center:
                    return HorizontalAlignment.Center;
                case TextHorizontalAlignment.Right:
                    return HorizontalAlignment.Right;
                default:
                    return HorizontalAlignment.Left;
            }
        }

        /// <summary>
        /// Converts <see cref="TextVerticalAlignment"/> to <see cref="VerticalAlignment"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static VerticalAlignment Convert(TextVerticalAlignment value)
        {
            switch (value)
            {
                case TextVerticalAlignment.Center:
                    return VerticalAlignment.Center;
                case TextVerticalAlignment.Bottom:
                    return VerticalAlignment.Bottom;
                default:
                    return VerticalAlignment.Top;
            }
        }

        public static RectD AlignRectInRect(
            bool vert,
            RectD rect,
            RectD container,
            CoordAlignment alignment,
            bool shrinkSize = true)
        {
            if (shrinkSize)
                rect.Size = rect.Size.Shrink(vert, container.GetSize(vert));

            switch (alignment)
            {
                case CoordAlignment.Near:
                    rect.SetLocation(vert, container.GetLocation(vert));
                    break;
                case CoordAlignment.Center:
                    rect.SetCenter(vert, container.GetCenter(vert));
                    break;
                case CoordAlignment.Far:
                    rect.SetFarLocation(vert, container.GetFarLocation(vert));
                    break;
                case CoordAlignment.Stretch:
                case CoordAlignment.Fill:
                    rect.SetLocation(vert, container.GetLocation(vert));
                    rect.SetSize(vert, container.GetSize(vert));
                    break;
            }

            return rect;
        }

        /// <summary>
        /// Aligns the specified rectangle in the container using horizontal and vertical
        /// alignment options.
        /// </summary>
        /// <param name="rect">Rectangle to align.</param>
        /// <param name="container">Container rectangle.</param>
        /// <param name="horz">Horizontal alignment.</param>
        /// <param name="vert">Vertical alignment.</param>
        /// <param name="shrinkSize">Whether to shrink size of the rectangle
        /// to fit in the container. Optional. Default is <c>true</c>.</param>
        /// <returns></returns>
        public static RectD AlignRectInRect(
            RectD rect,
            RectD container,
            HorizontalAlignment? horz,
            VerticalAlignment? vert,
            bool shrinkSize = true)
        {
            if (shrinkSize)
                rect.Size = rect.Size.Shrink(container.Width, container.Height);

            if(horz is not null)
            {
                rect = AlignRectInRect(false, rect, container, (CoordAlignment)horz, false);
            }

            if (vert is not null)
            {
                rect = AlignRectInRect(true, rect, container, (CoordAlignment)vert, false);
            }

            return rect;
        }
    }
}
