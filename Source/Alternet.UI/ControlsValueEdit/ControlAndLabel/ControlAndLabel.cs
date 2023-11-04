﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    /// <summary>
    /// Implements labeled control.
    /// </summary>
    /// <remarks> This is an abstract class. You can use <see cref="TextBoxAndLabel"/>,
    /// <see cref="ComboBoxAndLabel"/> or derive from <see cref="ControlAndLabel"/>
    /// in order to implement your own custom labeled control.</remarks>
    public abstract class ControlAndLabel : StackPanel
    {
        private readonly Label label = new()
        {
            Margin = new Thickness(0, 0, 5, 0),
            VerticalAlignment = VerticalAlignment.Center,
        };

        private readonly PictureBox errorPicture = new()
        {
            Margin = new Thickness(5, 0, 0, 0),
        };
        private readonly Control mainControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlAndLabel"/> class.
        /// </summary>
        public ControlAndLabel()
            : base()
        {
            Orientation = StackPanelOrientation.Horizontal;
            label.Parent = this;
            mainControl = CreateControl();
            mainControl.VerticalAlignment = VerticalAlignment.Center;
            mainControl.Parent = this;
            TextBox.InitErrorPicture(errorPicture);
            errorPicture.Parent = this;
        }

        public double InnerSuggestedWidth
        {
            get => MainControl.SuggestedWidth;
            set => MainControl.SuggestedWidth = value;
        }

        public Label Label => label;

        public bool LabelVisible
        {
            get => Label.Visible;
            set => Label.Visible = value;
        }

        public bool ErrorPictureVisible
        {
            get => ErrorPicture.Visible;
            set => ErrorPicture.Visible = value;
        }

        public string Title
        {
            get => Label.Text;
            set => Label.Text = value;
        }

        public PictureBox ErrorPicture => errorPicture;

        public Control MainControl => mainControl;

        protected abstract Control CreateControl();
    }
}