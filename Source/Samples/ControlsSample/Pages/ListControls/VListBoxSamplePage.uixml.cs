﻿using System;
using System.Collections.Generic;
using System.Linq;
using Alternet.UI;
using Alternet.Drawing;

namespace ControlsSample
{
    internal partial class VListBoxSamplePage: Control
    {
        private readonly VListBox listBox = new()
        {
            SuggestedWidth = 200,
            Margin = (0,0,0,5),
        };

        public VListBoxSamplePage()
        {
            InitializeComponent();
            Title = "Virtual";

            findExactCheckBox.BindBoolProp(this, nameof(FindExact));
            findIgnoreCaseCheckBox.BindBoolProp(this, nameof(FindIgnoreCase));
            findText.TextChanged += FindText_TextChanged;
            PropertyGridSample.ObjectInit.InitVListBox(listBox);

            tab1.Children.Prepend(listBox);
            listBox.SelectionChanged += ListBox_SelectionChanged;
            listBox.MouseLeftButtonDown += ListBox_MouseLeftButtonDown;
            listBox.Search.UseContains = true;
            listBox.HandleCreated += ListBox_HandleCreated;
            roundSelectionCheckBox.CheckedChanged += RoundSelectionCheckBox_CheckedChanged; 

            SetSizeToContent();
        }

        private void RoundSelectionCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (roundSelectionCheckBox.IsChecked)
            {
                BorderSettings border = new();
                border.UniformRadiusIsPercent = true;
                border.UniformCornerRadius = 50;

                listBox.CurrentItemBorder = border;
                listBox.SelectionBorder = border;
            }
            else
            {
                listBox.CurrentItemBorder = null;
                listBox.SelectionBorder = null;
            }
        }

        private void ListBox_HandleCreated(object? sender, EventArgs e)
        {
            Application.LogIf("VListBox.HandleCreated", false);
        }

        private void FindText_TextChanged(object? sender, EventArgs e)
        {
            var text = findText.Text;
            if(text is null)
            {
                listBox.SelectedIndex = null;
                return;
            }
            var result = listBox.FindStringEx(text, null, FindExact, FindIgnoreCase);
            listBox.SelectedIndex = result;
        }

        public bool FindExact { get; set; } = false;

        public bool FindIgnoreCase { get; set; } = true;

        private void EditorButton_Click(object? sender, System.EventArgs e)
        {
            DialogFactory.EditItemsWithListEditor(listBox);
        }

        private void HasBorderButton_Click(object? sender, EventArgs e)
        {
            listBox.HasBorder = !listBox.HasBorder;
        }

        private void ListBox_MouseLeftButtonDown(
            object? sender, 
            MouseEventArgs e)
        {
            var result = listBox.HitTest(e.GetPosition(listBox));
            var item = (result == null ? "<none>" : listBox.GetItem(result.Value));

            item ??= result;

            Application.Log($"HitTest result: Item: '{item}'");
        }

        private static string IndicesToStr(IReadOnlyList<int> indices)
        {
            string result = indices.Count > 50 ?
                "too many indices to display" : string.Join(",", indices);
            return result;
        }

        private void ListBox_SelectionChanged(object? sender, EventArgs e)
        {
            string s = IndicesToStr(listBox.SelectedIndices);
            Application.Log($"ListBox: SelectionChanged. SelectedIndices: ({s})");
        }

        private void AllowMultipleSelectionCheckBox_CheckedChanged(
            object? sender, 
            EventArgs e)
        {
            listBox.Parent?.BeginUpdate();

            var b = allowMultipleSelectionCheckBox.IsChecked;

            listBox.SelectionMode = b ? ListBoxSelectionMode.Multiple : ListBoxSelectionMode.Single;

            selectItemAtIndices2And4Button.Enabled = b;

            listBox.Parent?.EndUpdate();
        }

        private void EnsureLastItemVisibleButton_Click(
            object? sender, 
            EventArgs e)
        {
            // do not need to check count as EnsureVisible does this.
            listBox.EnsureVisible(listBox.Count - 1);
        }

        private void SelectItemAtIndex2Button_Click(
            object? sender, 
            EventArgs e)
        {
            listBox.SelectItems(2);
        }

        private void DeselectAllButton_Click(object? sender, EventArgs e)
        {
            listBox.SelectedItem = null;
        }

        private void SelectItemAtIndices2And4Button_Click(
            object? sender, 
            EventArgs e)
        {
            listBox.SelectItems(2, 4);
        }
    }
}