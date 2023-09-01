﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alternet.UI;
using Alternet.Drawing;

namespace PropertyGridSample
{
    internal class WelcomeControl : Control
    {
        private readonly VerticalStackPanel stackPanel = new()
        {
            Padding = new(10),
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
        };
        private const string descText = "Specialized grid for editing properties.";
        private readonly Label header = new()
        {
            Text = "PropertyGrid",
            Font = new Font(Font.Default.Name, Font.Default.SizeInPoints * 2, FontStyle.Bold),
        };
        private readonly Label desc = new()
        {
            Text = descText,
            Margin = new(0,5,0,5),
        };
        private readonly PropertyGrid propertyGrid = new()
        {
            Height = 350,
            Width = 300,
            HasBorder = false,
        };

        public WelcomeControl()
        {
            propertyGrid.ApplyColors(PropertyGridColors.ColorSchemeWhite);

            Children.Add(stackPanel);
            stackPanel.Children.Add(header);
            stackPanel.Children.Add(desc);
            propertyGrid.Visible = false;
            stackPanel.Children.Add(propertyGrid);
        }
    }
}