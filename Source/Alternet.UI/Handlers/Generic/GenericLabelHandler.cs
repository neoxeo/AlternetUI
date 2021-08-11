using System.Drawing;

namespace Alternet.UI
{
    internal class GenericLabelHandler : ControlHandler<Label>
    {
        protected override bool NeedsPaint => true;

        public override void OnPaint(DrawingContext drawingContext)
        {
            if (Control.Text != null)
                drawingContext.DrawText(Control.Text, ChildrenLayoutBounds.Location, Control.Font ?? UI.Control.DefaultFont, Control.ForegroundColor ?? Color.Black);
        }

        public override SizeF GetPreferredSize(SizeF availableSize)
        {
            var text = Control.Text;
            if (text == null)
                return new SizeF();

            using (var dc = Control.CreateDrawingContext())
                return dc.MeasureText(text, Control.Font ?? UI.Control.DefaultFont) + Control.Padding.Size;
        }

        protected override void OnAttach()
        {
            base.OnAttach();
            Control.TextChanged += Control_TextChanged;
            Control.ForegroundColorChanged += Control_ForegroundColorChanged;
        }

        protected override void OnDetach()
        {
            Control.TextChanged -= Control_TextChanged;
            Control.ForegroundColorChanged -= Control_ForegroundColorChanged;
            base.OnDetach();
        }

        private void Control_ForegroundColorChanged(object? sender, System.EventArgs? e)
        {
            Update();
        }

        private void Control_TextChanged(object? sender, System.EventArgs? e)
        {
            Update();
        }
    }
}