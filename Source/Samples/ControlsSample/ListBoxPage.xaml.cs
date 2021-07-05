﻿using Alternet.UI;
using System;

namespace ControlsSample
{
    internal class ListBoxPage : Control
    {
        private ListBox listBox;
        private CheckBox allowMultipleSelectionCheckBox;
        private readonly IPageSite site;

        public ListBoxPage(IPageSite site)
        {
            var xamlStream = typeof(MainWindow).Assembly.GetManifestResourceStream("ControlsSample.ListBoxPage.xaml");
            if (xamlStream == null)
                throw new InvalidOperationException();
            new XamlLoader().LoadExisting(xamlStream, this);

            listBox = (ListBox)FindControl("listBox");
            listBox.SelectionChanged += ListBox_SelectionChanged;

            listBox.Items.Add("One");
            listBox.Items.Add("Two");
            listBox.Items.Add("Three");

            ((Button)FindControl("addItemButton")).Click += AddItemButton_Click;
            ((Button)FindControl("removeItemButton")).Click += RemoveItemButton_Click;
            ((Button)FindControl("addManyItemsButton")).Click += AddManyItemsButton_Click;

            allowMultipleSelectionCheckBox = (CheckBox)FindControl("allowMultipleSelectionCheckBox");
            allowMultipleSelectionCheckBox.CheckedChanged += AllowMultipleSelectionCheckBox_CheckedChanged;
            this.site = site;
        }

        private void AddManyItemsButton_Click(object? sender, EventArgs e)
        {
            int start = listBox.Items.Count + 1;
            for (int i = start; i < start + 5000; i++)
                listBox.Items.Add("Item " + i);
        }

        private void ListBox_SelectionChanged(object? sender, EventArgs e)
        {
            site.LogEvent($"ListBox: SelectionChanged. SelectedIndices: ({string.Join(",", listBox.SelectedIndices)})");
        }

        private void AllowMultipleSelectionCheckBox_CheckedChanged(object? sender, EventArgs e)
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