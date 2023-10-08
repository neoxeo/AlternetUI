﻿using System;
using Alternet.Drawing;

namespace Alternet.UI
{
    internal partial class StackPanelHandler
    {
        private class VerticalLayout : OrientedLayout
        {
            public VerticalLayout(StackPanelHandler handler)
                : base(handler)
            {
            }

            public override Size GetPreferredSize(Size availableSize)
            {
                var stackPanelPadding = Control.Padding;

                double maxWidth = 0;
                double height = 0;
                foreach (var control in Handler.AllChildrenIncludedInLayout)
                {
                    var margin = control.Margin;
                    var preferredSize = control.GetPreferredSizeLimited(
                        new Size(availableSize.Width, availableSize.Height - height));
                    maxWidth = Math.Max(maxWidth, preferredSize.Width + margin.Horizontal);
                    height += preferredSize.Height + margin.Vertical;
                }

                return new Size(
                    double.IsNaN(Control.SuggestedWidth) ? maxWidth + stackPanelPadding.Horizontal
                        : Control.SuggestedWidth,
                    height + stackPanelPadding.Vertical);
            }

            public override void Layout()
            {
                var childrenLayoutBounds = Handler.ChildrenLayoutBounds;

                double y = childrenLayoutBounds.Top;
                foreach (var control in Handler.AllChildrenIncludedInLayout)
                {
                    var margin = control.Margin;
                    var verticalMargin = margin.Vertical;

                    var preferredSize = control.GetPreferredSizeLimited(
                        new Size(
                            childrenLayoutBounds.Width,
                            childrenLayoutBounds.Height - y - verticalMargin));
                    var alignedPosition =
                        AlignedLayout.AlignHorizontal(childrenLayoutBounds, control, preferredSize);
                    control.Handler.Bounds =
                        new Rect(
                            alignedPosition.Origin,
                            y + margin.Top,
                            alignedPosition.Size,
                            preferredSize.Height);
                    y += preferredSize.Height + verticalMargin;
                }
            }
        }
    }
}