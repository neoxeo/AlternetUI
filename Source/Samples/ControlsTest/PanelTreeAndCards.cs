﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    public class PanelTreeAndCards : PanelAuiManager
    {
        private readonly CardPanel cardPanel = new();

        public PanelTreeAndCards()
        {
            LeftTreeView.Required();
            Manager.AddPane(cardPanel, CenterPane);

            LeftTreeView.SelectionChanged += LeftTreeView_SelectionChanged;
            Manager.Update();
        }

        public CardPanel CardPanel => cardPanel;

        public int Add(string title, Func<Control> fn)
        {
            var index = cardPanel.Add(title, fn);
            var item = LeftTreeView.Add(title);
            item.Tag = index;
            return index;
        }

        public int Add(string title, Control control)
        {
            var index = cardPanel.Add(title, control);
            var item = LeftTreeView.Add(title);
            item.Tag = index;
            return index;
        }

        private void LeftTreeView_SelectionChanged(object? sender, System.EventArgs e)
        {
            var tag = LeftTreeView.SelectedItem?.Tag;
            cardPanel.SetActiveCard(tag as int?);
        }
    }
}