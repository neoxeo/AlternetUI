﻿using System;
using System.Linq;
using Alternet.UI;
using static System.Net.Mime.MediaTypeNames;

namespace ControlsSample
{
    internal partial class DateTimePage : Control
    {
        private IPageSite? site;

        public DateTimePage()
        {
            InitializeComponent();
            datePicker.Value = DateTime.Now;
            timePicker.Value = DateTime.Now;
        }

        public IPageSite? Site
        {
            get => site;

            set
            {
                site = value;
            }
        }

        private void DatePicker_DateChanged(object? sender, EventArgs e)
        {
            var v = datePicker.Value;
            var s = v.ToShortDateString();
            dateLabel.Text = $"Selected Value: {s}";
        }

        private void TimePicker_Changed(object? sender, EventArgs e)
        {
            var v = timePicker.Value;
            var s = v.ToLongTimeString();
            timeLabel.Text = $"Selected Value: {s}";
        }

        private void SetNow_Click(object? sender, EventArgs e)
        {
            datePicker.Value = DateTime.Now;
            timePicker.Value = DateTime.Now;
        }

        private void SetNowDate_Click(object? sender, EventArgs e)
        {
            datePicker.Value = DateTime.Today;
            timePicker.Value = DateTime.Today;
        }

        private void HasBorderButton_Click(object? sender, EventArgs e)
        {
            //datePicker.HasBorder = !datePicker.HasBorder;
            //timePicker.HasBorder = !timePicker.HasBorder;
        }

        private void Popup_CheckedChanged(object? sender, EventArgs e)
        {
            if (SpinRadioButton.IsChecked)
            {
                datePicker.PopupKind = DateTimePickerPopupKind.Spin;
                return;
            }

            if (DropDownRadioButton.IsChecked)
            {
                datePicker.PopupKind = DateTimePickerPopupKind.DropDown;
                return;
            }

            if (DefaultRadioButton.IsChecked)
            {
                datePicker.PopupKind = DateTimePickerPopupKind.Default;
                return;
            }
        }
    }
}