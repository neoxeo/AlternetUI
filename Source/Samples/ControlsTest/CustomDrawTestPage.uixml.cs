﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Alternet.Drawing;
using Alternet.UI;

namespace ControlsTest
{
    internal partial class CustomDrawTestPage : Control
    {
        private static WxControlPainterHandler painter = new();

        private readonly CustomDrawControl customDrawControl = new()
        {
            VerticalAlignment = VerticalAlignment.Fill,
            Background = Brushes.White,
        };

        private readonly SplittedControlsPanel panel = new()
        {
            LeftVisible = false,
            TopVisible = false,
            BottomVisible = false,
        };

        static CustomDrawTestPage()
        {
        }

        public CustomDrawTestPage()
        {
            InitializeComponent();

            panel.ActionsControl.Required();
            panel.VerticalAlignment = VerticalAlignment.Fill;
            panel.Parent = mainPanel;

            customDrawControl.Parent = panel.FillPanel;

            panel.AddAction("Draw Native ComboBox", DrawNativeComboBox);
            panel.AddAction("Draw Native Checkbox", DrawNativeCheckbox);
            panel.AddAction("Test Bad Image Assert", TestBadImageAssert);
            panel.AddAction("Draw ScrollBar", DrawScrollBar);
        }

        public void DrawNativeComboBox()
        {
            customDrawControl.SetPaintAction((control, canvas, rect) =>
            {
                painter.DrawComboBox(
                    control,
                    canvas,
                    (50, 50, 150, 100),
                    WxControlPainterHandler.DrawFlags.None);
            });
        }

        public void DrawScrollBar()
        {
            var metrics = ScrollBar.DefaultMetrics;

            customDrawControl.SetPaintAction((control, canvas, rect) =>
            {
                var downSvgImage = KnownSvgImages.GetImgTriangleArrow(ArrowDirection.Down);
                var upSvgImage = KnownSvgImages.GetImgTriangleArrow(ArrowDirection.Up);
                var leftSvgImage = KnownSvgImages.GetImgTriangleArrow(ArrowDirection.Left);
                var rightSvgImage = KnownSvgImages.GetImgTriangleArrow(ArrowDirection.Right);

                DrawImage((50, 50), upSvgImage);
                DrawImage((50, 90), downSvgImage);
                DrawImage((20, 70), leftSvgImage);
                DrawImage((90, 70), rightSvgImage);

                void DrawImage(PointD coord, SvgImage svg)
                {
                    var img = svg.AsImage(32);
                    canvas.DrawImage(img, coord);
                }
            });
        }

        public void TestBadImageAssert()
        {
            customDrawControl.SetPaintAction((control, canvas, rect) =>
            {
                var image = new Bitmap();
                canvas.DrawImage(image, PointD.Empty);
            });
        }

        public void DrawNativeCheckbox()
        {
            customDrawControl.SetPaintAction((control, canvas, rect) =>
            {
                Fn((50, 50), CheckState.Unchecked, VisualControlState.Normal, "unchecked");

                Fn((150, 50), CheckState.Checked, VisualControlState.Normal, "checked");

                Fn(
                    (250, 50),
                    CheckState.Checked,
                    VisualControlState.Hovered,
                    "checked, current");

                Fn(
                    (50, 100),
                    CheckState.Checked,
                    VisualControlState.Disabled,
                    "disabled");

                Fn(
                    (150, 100),
                    CheckState.Indeterminate,
                    VisualControlState.Normal,
                    "undetermined");

                void Fn(
                    PointD location,
                    CheckState checkState,
                    VisualControlState controlState,
                    string title)
                {
                    var size = DrawingUtils.GetCheckBoxSize(control, checkState, controlState);
                    var rect = (location, size);
                    canvas.DrawCheckBox(
                        control,
                        rect,
                        checkState,
                        controlState);
                    location.Y += size.Height;
                    canvas.DrawText(title, location);
                }
            });
        }
    }
}