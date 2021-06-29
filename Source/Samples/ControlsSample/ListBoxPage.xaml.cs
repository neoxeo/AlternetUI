﻿using Alternet.UI;
using System;

namespace ControlsSample
{
    internal class ListBoxPage : Control
    {
        private ListBox listBox;
        private CheckBox allowMultipleSelectionCheckBox;

        public ListBoxPage()
        {
            var xamlStream = typeof(MainWindow).Assembly.GetManifestResourceStream("ControlsSample.ListBoxPage.xaml");
            if (xamlStream == null)
                throw new InvalidOperationException();
            new XamlLoader().LoadExisting(xamlStream, this);

            listBox = (ListBox)FindControl("listBox");

            listBox.Items.Add("One");
            listBox.Items.Add("Two");
            listBox.Items.Add("Three");

            ((Button)FindControl("addItemButton")).Click += AddItemButton_Click;
            ((Button)FindControl("removeItemButton")).Click += RemoveItemButton_Click;
            
            allowMultipleSelectionCheckBox = (CheckBox)FindControl("allowMultipleSelectionCheckBox");
            allowMultipleSelectionCheckBox.CheckedChanged += ListBoxPage_CheckedChanged;
        }

        private void ListBoxPage_CheckedChanged(object? sender, EventArgs e)
        {
            listBox.SelectionMode = allowMultipleSelectionCheckBox.IsChecked ? ListBoxSelectionMode.Multiple : ListBoxSelectionMode.Single;
        }

        private void RemoveItemButton_Click(object? sender, EventArgs e)
        {
            if (listBox.Items.Count > 0)
                listBox.Items.RemoveAt(listBox.Items.Count - 1);
        }

        private void AddItemButton_Click(object? sender, EventArgs e)
        {
            listBox.Items.Add("Item " + (listBox.Items.Count + 1));
        }
    }
}