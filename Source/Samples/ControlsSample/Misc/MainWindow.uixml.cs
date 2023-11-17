﻿using Alternet.UI;
using Alternet.Drawing;
using System;

namespace ControlsSample
{
    internal partial class MainWindow : Window, IPageSite
    {
        private readonly PageContainer pageContainer = new();
        private readonly LogListBox eventsControl = new()
        {
            HasBorder = false,
            Margin = new(0, 10, 0, 0),
            SuggestedHeight = 150,
        };        
        private readonly Grid mainGrid = new();
        private readonly Control mainGridParent = new();

        public MainWindow()
        {
            eventsControl.BindApplicationLog();

            Icon = ImageSet.FromUrlOrNull("embres:ControlsSample.Sample.ico");
            InitializeComponent();

            mainGrid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(100, GridUnitType.Star)
            }
            );
            mainGrid.AddAutoRow();
                
            mainGrid.Children.Add(pageContainer);
            mainGrid.Children.Add(eventsControl);
            Grid.SetRow(pageContainer, 0);
            Grid.SetRow(eventsControl, 1);

            var pages = pageContainer.Pages;

            void AddPage(string title, Func<Control> action)
            {
                var item = new PageContainer.Page(title, action);
                pages.Add(item);
            }

            AddPage("Welcome", CreateWelcomePage);
            AddPage("Text Input", CreateTextInputPage);
            AddPage("Tree View", CreateTreeViewPage);
            AddPage("List View", CreateListViewPage);
            AddPage("List Controls", CreateListBoxPage);
            //AddPage("Combo Box", CreateComboBoxPage);
            //AddPage("Check List Box", CreateCheckListBoxPage);
            AddPage("Progress Bar", CreateProgressBarPage);
            AddPage("Button", CreateButtonPage);
            AddPage("Slider", CreateSliderPage);
            AddPage("Grid", CreateGridPage);
            AddPage("Numeric Input", CreateNumericInputPage);
            AddPage("Radio Button", CreateRadioButtonsPage);
            AddPage("Check Box", CreateCheckBoxesPage);
            AddPage("Date Time", CreateDateTimePage);
            AddPage("Web Browser", CreateWebBrowserPage);
            AddPage("Splitter Panel", CreateSplitterPanelPage);
            AddPage("Layout Panel", CreateLayoutPanelPage);
            AddPage("Calendar", CreateCalendarPage);
            AddPage("Animation", CreateAnimationPage);
            AddPage("Notify & ToolTip", CreateNotifyIconPage);
            AddPage("Tab Control", CreateTabControlPage);
            AddPage("All Samples", CreateAllSamplesPage);

            pageContainer.SelectedIndex = 0;

            mainGridParent.Padding = 10;
            mainGridParent.Children.Add(mainGrid);
            Children.Add(mainGridParent);

            LogUtils.DebugLogVersion();

            if (pageContainer.PagesControl.CanAcceptFocus)
                pageContainer.PagesControl.SetFocus();
        }

        Control CreateCalendarPage() => new CalendarPage() { Site = this };
        Control CreateAnimationPage() => new AnimationPage() { Site = this };
        Control CreateTreeViewPage() => new TreeViewPage() { Site = this };
        Control CreateListViewPage() => new ListViewPage() { Site = this };
        Control CreateListBoxPage() => new ListBoxPage() { Site = this };
        //Control CreateComboBoxPage() => new ComboBoxPage() { Site = this };
        //Control CreateCheckListBoxPage() => new CheckListBoxPage() { Site = this };
        Control CreateTabControlPage() => new TabControlPage() { Site = this };
        Control CreateProgressBarPage() => new ProgressBarPage() { Site = this };
        Control CreateButtonPage() => new ButtonPage() { Site = this };
        Control CreateSliderPage() => new SliderPage() { Site = this };
        Control CreateGridPage() => new GridPage() { Site = this };
        Control CreateNumericInputPage() => new NumericInputPage() { Site = this };
        Control CreateRadioButtonsPage() => new RadioButtonsPage() { Site = this };
        Control CreateCheckBoxesPage() => new CheckBoxesPage() { Site = this };
        Control CreateTextInputPage()
        {
            return new TextInputPage() { Site = this };
        }
        Control CreateDateTimePage() => new DateTimePage() { Site = this };
        Control CreateNotifyIconPage() => new NotifyIconPage() { Site = this };
        Control CreateWebBrowserPage() => new WebBrowserPage() { Site = this };
        Control CreateSplitterPanelPage() => new SplitterPanelPage() { Site = this };
        Control CreateLayoutPanelPage() => new LayoutPanelPage() { Site = this };
        Control CreateAllSamplesPage() => new AllSamplesPage() { Site = this };
        Control CreateWelcomePage() => new WelcomePage() { Site = this };

        private void LinkLabel_LinkClicked(
            object? sender,
            System.ComponentModel.CancelEventArgs e)
        {
            if (sender is not LinkLabel linkLabel)
                return;
            LogEvent(linkLabel.Url);
        }

        public string? LastEventMessage => eventsControl.LastLogMessage;

        public void LogEventSmart(string? message, string? prefix)
        {
            eventsControl.LogReplace(message, prefix);
        }

        public void LogEvent(string? message)
        {
            eventsControl.Log(message);
        }
    }
}