﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alternet.Drawing;

namespace Alternet.UI
{
    public class SkiaSampleControl : UserControl
    {
        private static Font? sampleFont;

        public SkiaSampleControl()
        {
            Font = SampleFont;
        }

        public static Font SampleFont => sampleFont ??= Control.DefaultFont
                .Scaled(2).GetWithStyle(FontStyle.Underline | FontStyle.Bold | FontStyle.Strikeout);

        protected override void OnPaint(PaintEventArgs e)
        {
            var dc = e.Graphics;

            dc.FillRectangle(Color.LightGoldenrodYellow.AsBrush, e.ClipRectangle);

            var font = Font ?? Control.DefaultFont;

            dc.DrawText(
                $"Hello:! {font.SizeInPoints}",
                (5, 0),
                font,
                Color.Black,
                Color.LightGreen);

            dc.DrawText(
                $"; hello text: {font.SizeInPoints}",
                (160, 0),
                font,
                Color.Navy,
                Color.LightGreen);

            font = font.Base;

            dc.DrawText(
                $"Hello:! {font.SizeInPoints}",
                (50, 150),
                font,
                Color.Red,
                Color.LightGreen);

            dc.SetPixel(5, 0, Color.Red);
            dc.SetPixel(160, 0, Color.Red);
            dc.SetPixel(50, 150, Color.Red);
        }
    }
}
