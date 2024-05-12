﻿using Alternet.Drawing;
using Alternet.UI;
using System;
using System.Linq;

namespace DrawingSample
{
    partial class BrushesAndPensPageSettings : Control
    {
        private readonly Label dashStyleLabel = new("Dash Style:");
        private readonly Label lineCapLabel = new("Line Cap:");
        private readonly Label lineJoinLabel = new("Line Join:");
        private readonly ComboBox dashStyleComboBox = new();
        private readonly ComboBox lineCapComboBox = new();
        private readonly ComboBox lineJoinComboBox = new();
        private BrushesAndPensPage? page;

        public BrushesAndPensPageSettings()
        {
            DoInsideLayout(() =>
            {
                InitializeComponent();

                ControlSet labels = new(dashStyleLabel, lineCapLabel, lineJoinLabel);
                ControlSet comboBoxes = new(dashStyleComboBox, lineCapComboBox, lineJoinComboBox);
                labels.Margin(new(0, 5, 10, 5)).VerticalAlignment(VerticalAlignment.Center);
                comboBoxes.Margin(new(0, 5, 0, 5)).IsEditable(false);
                var gridControls = ControlSet.GridFromColumns(labels, comboBoxes);

                propGrid.Setup(gridControls);
            });
        }

        public void Initialize(BrushesAndPensPage page)
        {
            DataContext = page;
            this.page = page;
            brushComboBox.AddEnumValues<BrushesAndPensPage.BrushType>();
            hatchStyleComboBox.AddEnumValues<BrushHatchStyle>();
            dashStyleComboBox.AddEnumValues<DashStyle>();
            lineJoinComboBox.AddEnumValues<LineJoin>();
            lineCapComboBox.AddEnumValues<LineCap>();

            dashStyleComboBox.BindSelectedItem(nameof(BrushesAndPensPage.PenDashStyle));
            lineCapComboBox.BindSelectedItem(nameof(BrushesAndPensPage.LineCap));
            lineJoinComboBox.BindSelectedItem(nameof(BrushesAndPensPage.LineJoin));
            hatchStyleComboBox.BindSelectedItem(nameof(BrushesAndPensPage.HatchStyle));
            brushComboBox.BindSelectedItem(nameof(BrushesAndPensPage.Brush));

            shapeCountSlider.Value = page.ShapeCount;
            shapeCountSlider.ValueChanged += (s, e) =>
            {
                page.ShapeCount = shapeCountSlider.Value;
            };

            brushColorHueSlider.Value = page.BrushColorHue;
            brushColorHueSlider.ValueChanged += (s, e) =>
            {
                page.BrushColorHue = brushColorHueSlider.Value;
            };

            penColorHueSlider.Value = page.PenColorHue;
            penColorHueSlider.ValueChanged += (s, e) =>
            {
                page.PenColorHue = penColorHueSlider.Value;
            };

            penWidthSlider.Value = page.PenWidth;
            penWidthSlider.ValueChanged += (s, e) =>
            {
                page.PenWidth = penWidthSlider.Value;
            };

            rectanglesIncludedCheckBox.IsChecked = page.RectanglesIncluded;
            rectanglesIncludedCheckBox.CheckedChanged += (s, e) =>
            {
                page.RectanglesIncluded = rectanglesIncludedCheckBox.IsChecked;
            };

            ellipsesIncludedCheckBox.IsChecked = page.EllipsesIncluded;
            ellipsesIncludedCheckBox.CheckedChanged += (s, e) =>
            {
                page.EllipsesIncluded = ellipsesIncludedCheckBox.IsChecked;
            };
        }

        private void BrushComboBox_SelectedItemChanged(object? sender, EventArgs e)
        {
            hatchStylePanel.Visible = page!.Brush == BrushesAndPensPage.BrushType.Hatch;
        }
    }
}