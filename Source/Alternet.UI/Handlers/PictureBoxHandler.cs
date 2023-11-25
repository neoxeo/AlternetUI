using Alternet.Drawing;

namespace Alternet.UI
{
    internal class PictureBoxHandler : NativeControlHandler<PictureBox, Native.Panel>
    {
        protected override bool NeedsPaint => true;

        public override void OnPaint(DrawingContext drawingContext)
        {
            Control.DefaultPaint(drawingContext, Control.DrawClientRectangle);
        }

        public override Size GetPreferredSize(Size availableSize)
        {
            if (Control.Image == null)
                return base.GetPreferredSize(availableSize);

            var specifiedWidth = Control.SuggestedWidth;
            var specifiedHeight = Control.SuggestedHeight;
            if (!double.IsNaN(specifiedWidth) && !double.IsNaN(specifiedHeight))
                return new Size(specifiedWidth, specifiedHeight);

            return Control.Image.Size;
        }

        internal override Native.Control CreateNativeControl()
        {
            var result = new Native.Panel
            {
                AcceptsFocusAll = false,
            };
            return result;
        }
    }
}