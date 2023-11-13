﻿using System;
using Alternet.Base.Collections;
using Alternet.Drawing;
using Alternet.UI;

namespace ControlsSample
{
    public class PageContainer : Control
    {
        private readonly TreeView pagesControl = new()
        {
            HasBorder = false,
            SuggestedWidth = 140,
            MaxHeight = 400,
        };

        private readonly Control activePageHolder = new()
        {
        };

        private readonly Grid grid;
        private readonly VerticalStackPanel waitLabelContainer = new()
        {
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            Size = new Size(400, 400),
        };
        private readonly Label waitLabel = new()
        {
            Text = "Page is loading...",
            Margin = new Thickness(100, 100, 0, 0),
        };

        public PageContainer()
        {
            grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            Children.Add(grid);

            pagesControl.MakeAsListBox();

            pagesControl.SelectionChanged += PagesListBox_SelectionChanged;
            grid.Children.Add(pagesControl);
            Grid.SetColumn(pagesControl, 0);

            grid.Children.Add(activePageHolder);
            Grid.SetColumn(activePageHolder, 1);

            waitLabel.Parent = waitLabelContainer;

            Pages.ItemInserted += Pages_ItemInserted;
        }

        public int? SelectedIndex
        {
            get => pagesControl?.SelectedItem?.Index;
            set
            {
                pagesControl.SelectedItem = pagesControl.Items[(int)value!];
                SetActivePageControl();
            }
        }

        public TreeView PagesControl => pagesControl;

        public Collection<Page> Pages { get; } = new Collection<Page>();

        private void PagesListBox_SelectionChanged(object? sender, System.EventArgs e)
        {
            SetActivePageControl();
        }

        private void Pages_ItemInserted(object? sender, int index, Page item)
        {
            pagesControl.Items.Insert(index, new TreeViewItem(item.Title));
        }

        private void SetActivePageControl()
        {
            if (SelectedIndex == null)
                return;

            var busyCursor = false;
            activePageHolder.SuspendLayout();
            try
            {
                activePageHolder.GetVisibleChildOrNull()?.Hide();
                var page = Pages[SelectedIndex.Value];
                var loaded = page.ControlCreated;

                if (!loaded)
                {
                    Application.BeginBusyCursor();
                    busyCursor = true;
                    waitLabelContainer.Parent = activePageHolder;
                    waitLabelContainer.Visible = true;
                    waitLabelContainer.Update();
                    Application.DoEvents();
                }

                var control = page.Control;
                control.Parent = activePageHolder;
                control.Visible = true;
                control.PerformLayout();
                waitLabelContainer.Visible = false;
            }
            finally
            {
                if (busyCursor)
                    Application.EndBusyCursor();
                activePageHolder.ResumeLayout();
            }
        }

        public class Page
        {
            private readonly Func<Control>? action;
            private Control? control;
            private Lazy<Control>? lazyControl;

            public Page(string title, Func<Control> action)
            {
                Title = title;
                this.action = action;
            }

            public Page(string title,  Lazy<Control> lazyControl)
            {
                Title = title;
                this.lazyControl = lazyControl;
            }

            public string Title { get; }

            public bool ControlCreated => control != null;

            public Control Control
            {
                get
                {
                    if(control is null)
                    {
                        if (lazyControl is not null)
                            control = lazyControl.Value;
                        else
                        if (action is not null)
                            control = action();
                        else
                            control = new();
                    }
                    return control;
                }
            }
        }
    }
}