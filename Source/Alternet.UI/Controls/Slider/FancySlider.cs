﻿using Alternet.Drawing;

namespace Alternet.UI
{
    /// <summary>
    /// <see cref="Slider"/> with custom painted fancy look.
    /// </summary>
    public partial class FancySlider : Slider
    {
        private readonly SolidBrush gaugeBackgroundBrush = new((Color)"#484854");
        private readonly Pen gaugeBorderPen = new((Color)"#9EAABA", 2);
        private readonly Pen knobBorderPen = new(Color.Black, 2);
        private readonly Pen largeTickPen = new(Color.Black, 2);
        private readonly Pen smallTickPen = new((Color)"#FFFFFF", 2);
        private readonly Pen knobPointerPen1 = new((Color)"#FC4154", 3);
        private readonly Pen knobPointerPen2 = new((Color)"#FF827D", 1);

        internal new FancySliderHandler Handler => (FancySliderHandler)base.Handler;

        /// <inheritdoc/>
        public override SizeD GetPreferredSize(SizeD availableSize)
        {
            return new SizeD(100, 100);
        }

        /// <inheritdoc/>
        internal override ControlHandler CreateHandler()
        {
            return new FancySliderHandler();
        }

        internal double GetControlRadius()
        {
            var bounds = ClientRectangle;
            var gaugePadding = 10;
            return (Math.Min(bounds.Width, bounds.Height) / 2) - gaugePadding;
        }

        internal PointD GetControlCenter()
        {
            return ClientRectangle.Center;
        }

        /// <inheritdoc/>
        protected override void OnPaint(PaintEventArgs e)
        {
            var bounds = e.Bounds;
            var dc = e.DrawingContext;

            var gaugeBounds = bounds.InflatedBy(-2, -2);
            var scaleBounds = gaugeBounds.InflatedBy(-4, -4);

            dc.FillRectangle(gaugeBackgroundBrush, gaugeBounds);

            var gradientStops1 = new[]
            {
                new GradientStop((Color)"#1B222C", 0),
                new GradientStop((Color)"#80767E", 0.5),
                new GradientStop((Color)"#0C1013", 1),
            };

            using var scaleGradientBrush = new LinearGradientBrush(
                PointD.Empty,
                new PointD(0, scaleBounds.Height),
                gradientStops1);

            dc.FillRectangle(scaleGradientBrush, scaleBounds);

            dc.DrawRectangle(gaugeBorderPen, gaugeBounds);

            var center = GetControlCenter();
            double controlRadius = GetControlRadius();
            var largeTickLength = controlRadius * 0.1;
            var smallTickLength = largeTickLength * 0.5;
            var knobPadding = largeTickLength * 0.5;
            var knobRadius = controlRadius - largeTickLength - knobPadding;

            var gradientStops2 = new[]
            {
                    new GradientStop((Color)"#A9A9A9", 0),
                    new GradientStop((Color)"#676767", 0.5),
                    new GradientStop((Color)"#353535", 1),
            };

            using var knobGradientBrush = new LinearGradientBrush(
                PointD.Empty,
                new PointD(knobRadius * 2, knobRadius * 2),
                gradientStops2);

            dc.FillCircle(knobGradientBrush, center, knobRadius);
            dc.DrawCircle(knobBorderPen, center, knobRadius);

            var emptyScaleSectorAngle = 70.0;
            var emptyScaleSectorHalfAngle = emptyScaleSectorAngle / 2;

            var scaleStartAngle = 90 + emptyScaleSectorHalfAngle;
            var scaleRange = 360 - emptyScaleSectorAngle;
            var scaleEndAngle = scaleStartAngle + scaleRange;

            var pointerAngle = MapRanges(
                Value,
                Minimum,
                Maximum,
                scaleStartAngle,
                scaleEndAngle);

            const double DegreesToRadians = Math.PI / 180;

            PointD GetScalePoint(double angle, double radius)
            {
                var radians = angle * DegreesToRadians;
                return center + new SizeD(radius * Math.Cos(radians), radius * Math.Sin(radians));
            }

            var pointerEndPoint1 = GetScalePoint(pointerAngle, knobRadius * 0.95);
            var pointerEndPoint2 = GetScalePoint(pointerAngle, knobRadius * 0.5);
            dc.DrawLine(knobPointerPen1, pointerEndPoint1, pointerEndPoint2);
            dc.DrawLine(knobPointerPen2, pointerEndPoint1, pointerEndPoint2);

            void DrawTicks(Pen pen, double step, double tickLength)
            {
                for (var angle = scaleStartAngle; angle <= scaleEndAngle; angle += step)
                {
                    dc.DrawLine(
                        pen,
                        GetScalePoint(angle, controlRadius - tickLength),
                        GetScalePoint(angle, controlRadius));
                }
            }

            var largeTicksCount = 5;
            var smallTicksCount = largeTicksCount * 4;

            DrawTicks(smallTickPen, scaleRange / smallTicksCount, smallTickLength);
            DrawTicks(largeTickPen, scaleRange / largeTicksCount, largeTickLength);
        }

        internal static double MapRanges(
            double value,
            double from1,
            double to1,
            double from2,
            double to2) =>
            ((value - from1) / (to1 - from1) * (to2 - from2)) + from2;
    }
}