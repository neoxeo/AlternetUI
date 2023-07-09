using Alternet.Drawing;

namespace Alternet.UI
{
    internal class GenericBorderHandler : ControlHandler<Border>
    {
        protected override bool NeedsPaint => true;

        public override Rect ChildrenLayoutBounds
        {
            get
            {
                var bounds = base.ChildrenLayoutBounds;
                bounds.X++;
                bounds.Y++;
                bounds.Width -= 2;
                bounds.Height -= 2;
                return bounds; // todo: border thickness.
            }
        }

        public override void OnPaint(DrawingContext drawingContext)
        {
            if (Control.Background != null)
                drawingContext.FillRectangle(Control.Background, DrawClientRectangle);

            if (Control.BorderBrush != null)
                drawingContext.DrawRectangle(Control.BorderBrush.AsPen, DrawClientRectangle);
        }

        public override Size GetPreferredSize(Size availableSize)
        {
            return base.GetPreferredSize(availableSize) + new Size(2, 2);
        }
    }
}