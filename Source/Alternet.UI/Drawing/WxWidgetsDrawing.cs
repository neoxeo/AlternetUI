﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alternet.UI;

namespace Alternet.Drawing
{
    internal class WxWidgetsDrawing : NativeDrawing
    {
        private static bool initialized;

        public static void Initialize()
        {
            if (initialized)
                return;
            NativeDrawing.Default = new WxWidgetsDrawing();
            initialized = true;
        }

        /// <inheritdoc/>
        public override object CreateTransparentBrush() => new UI.Native.Brush();

        /// <inheritdoc/>
        public override object CreateHatchBrush() => new UI.Native.HatchBrush();

        /// <inheritdoc/>
        public override object CreateLinearGradientBrush() => new UI.Native.LinearGradientBrush();

        /// <inheritdoc/>
        public override object CreateRadialGradientBrush() => new UI.Native.RadialGradientBrush();

        /// <inheritdoc/>
        public override object CreateSolidBrush() => new UI.Native.SolidBrush();

        /// <inheritdoc/>
        public override object CreateTextureBrush() => new UI.Native.TextureBrush();

        /// <inheritdoc/>
        public override object CreatePen() => new UI.Native.Pen();

        public virtual void UpdateHatchBrush(HatchBrush brush)
        {
            ((UI.Native.HatchBrush)brush.NativeObject).Initialize(
                (UI.Native.BrushHatchStyle)brush.HatchStyle,
                brush.Color);
        }

        public virtual void UpdateLinearGradientBrush(LinearGradientBrush brush)
        {
            ((UI.Native.LinearGradientBrush)brush.NativeObject).Initialize(
                brush.StartPoint,
                brush.EndPoint,
                brush.GradientStops.Select(x => x.Color).ToArray(),
                brush.GradientStops.Select(x => x.Offset).ToArray());
        }

        public virtual void UpdateRadialGradientBrush(RadialGradientBrush brush)
        {
            ((UI.Native.RadialGradientBrush)brush.NativeObject).Initialize(
                brush.Center,
                brush.Radius,
                brush.GradientOrigin,
                brush.GradientStops.Select(x => x.Color).ToArray(),
                brush.GradientStops.Select(x => x.Offset).ToArray());
        }

        public virtual void UpdateSolidBrush(SolidBrush brush)
        {
            ((UI.Native.SolidBrush)brush.NativeObject).Initialize(brush.Color);
        }

        public virtual void UpdateTextureBrush(TextureBrush brush)
        {
            ((UI.Native.TextureBrush)brush.NativeObject).Initialize(brush.Image.NativeImage);
        }

        public virtual void UpdatePen(Pen pen)
        {
            ((UI.Native.Pen)pen.NativeObject).Initialize(
                (UI.Native.PenDashStyle)pen.DashStyle,
                pen.Color,
                pen.Width,
                (UI.Native.LineCap)pen.LineCap,
                (UI.Native.LineJoin)pen.LineJoin);
        }
    }
}