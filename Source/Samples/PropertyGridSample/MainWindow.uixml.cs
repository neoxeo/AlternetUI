using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Alternet.Drawing;
using Alternet.UI;
using Alternet.Base.Collections;
using Alternet.UI.Localization;

namespace PropertyGridSample
{
    public partial class MainWindow : Window
    {
        internal readonly PanelAuiManager panel = new();

        private readonly StackPanel controlPanel = new()
        {
            Padding = new(15, 15, 15, 15),
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
        };

        private bool updatePropertyGrid = false;

        static MainWindow()
        {
            InitSampleLocalization();

            AuiNotebook.DefaultCreateStyle = AuiNotebookCreateStyle.Top;

            // Registers known collection property editors.
            PropertyGrid.RegisterCollectionEditors();
        }

        private static void InitSampleLocalization()
        {
            // Sample localization of "Custom" color item (which calls color dialog)
            KnownColorStrings.Default.Custom = "Custom...";

            // Sample localization of color name
            KnownColorStrings.Default.Azure = "Azure color";

            // Sample localization of Enum property values
            var brushTypeChoices = PropertyGrid.GetChoices<BrushType>();
            brushTypeChoices.SetLabelForValue<BrushType>(BrushType.LinearGradient, "Linear Gradient");
            brushTypeChoices.SetLabelForValue<BrushType>(BrushType.RadialGradient, "Radial Gradient");

            // Sample of hiding Enum value in PropertyGrid
            var knownColorsChoices = PropertyGrid.GetChoices<PropertyGridKnownColors>();
            knownColorsChoices.RemoveValue<PropertyGridKnownColors>(PropertyGridKnownColors.Custom);
            knownColorsChoices.RemoveValue<PropertyGridKnownColors>(PropertyGridKnownColors.Black);

            // Sample localization of the property label
            var prm = PropertyGrid.GetNewItemParams(typeof(Control), "Name");
            prm.Label = "(name)";
        }

        private static void InitIgnorePropNames(ICollection<string> items)
        {
            if (Application.IsLinuxOS)
                return;
            items.Add("Width");
            items.Add("Height");
            items.Add("Left");
            items.Add("Top");
            items.Add("SuggestedWidth");
            items.Add("SuggestedHeight");
        }

        public PropertyGrid PropGrid => panel.PropGrid;

        public MainWindow()
        {
            panel.BindApplicationLog();

            PropGrid.ApplyFlags |= PropertyGridApplyFlags.PropInfoSetValue
                | PropertyGridApplyFlags.ReloadAfterSetValue;
            PropGrid.Features = PropertyGridFeature.QuestionCharInNullable;
            PropertyGridSettings.Default = new(this);
            PropGrid.ProcessException += PropertyGrid_ProcessException;
            InitIgnorePropNames(PropGrid.IgnorePropNames);
            PropGrid.CreateStyleEx = PropertyGridCreateStyleEx.AlwaysAllowFocus;

            Icon = ImageSet.FromUrlOrNull("embres:PropertyGridSample.Sample.ico");

            InitializeComponent();

            Children.Add(panel);

            panel.LeftTreeView.SelectionChanged += ControlsListBox_SelectionChanged;
            panel.LogControl.Required();
            panel.PropGrid.Required();

            panel.CenterNotebook.AddPage(controlPanel, "Preview", true);

            panel.CenterNotebook.SizeChanged += CenterNotebook_SizeChanged;
            panel.CenterNotebook.LayoutUpdated += CenterNotebook_LayoutUpdated;
            panel.LeftTreeView.SizeChanged += LeftTreeView_SizeChanged;

            panel.Manager.Update();

            InitToolBox();

            PropGrid.PropertySelected += PGPropertySelected;
            PropGrid.PropertyChanged += PGPropertyChanged;
            PropGrid.PropertyChanging += PGPropertyChanging;
            PropGrid.PropertyHighlighted += PGPropertyHighlighted;
            PropGrid.PropertyRightClick += PGPropertyRightClick;
            PropGrid.PropertyDoubleClick += PGPropertyDoubleClick;
            PropGrid.ItemCollapsed += PGItemCollapsed;
            PropGrid.ItemExpanded += PGItemExpanded;
            PropGrid.LabelEditBegin += PGLabelEditBegin;
            PropGrid.LabelEditEnding += PGLabelEditEnding;
            PropGrid.ColBeginDrag += PGColBeginDrag;
            PropGrid.ColDragging += PGColDragging;
            PropGrid.ColEndDrag += PGColEndDrag;
            PropGrid.ButtonClick += PropertyGrid_ButtonClick;

            // Ctrl+Down moves to next property in PropertyGrid
            PropGrid.AddActionTrigger(
                PropertyGridKeyboardAction.ActionNextProperty,
                Key.DownArrow,
                ModifierKeys.Control);

            panel.PropGrid.SuggestedInitDefaults();

            panel.LeftTreeView.SelectedItem = panel.LeftTreeView.FirstItem;

            Application.Current.Idle += ApplicationIdle;
            RunTests();

            ComponentDesigner.InitDefault();
            ComponentDesigner.Default!.PropertyChanged += Default_PropertyChanged;

            controlPanel.MouseDown += ControlPanel_MouseDown;
            controlPanel.DragStart += ControlPanel_DragStart;

            panel.WriteWelcomeLogMessages();

            panel.RightNotebook.PageChanged += RightNotebook_PageChanged;
        }

        private void LeftTreeView_SizeChanged(object? sender, EventArgs e)
        {
            Application.Log("LeftTreeView_SizeChanged");
        }

        private void CenterNotebook_LayoutUpdated(object? sender, EventArgs e)
        {
            Application.Log("CenterNotebook_LayoutUpdated");
        }

        private void CenterNotebook_SizeChanged(object? sender, EventArgs e)
        {
            Application.Log("CenterNotebook_SizeChanged");
        }

        private void RightNotebook_PageChanged(object? sender, EventArgs e)
        {
            updatePropertyGrid = true;
        }

        private void Default_PropertyChanged(object? sender, PropertyChangeEventArgs e)
        {
            var item = panel.LeftTreeView.SelectedItem as ControlListBoxItem;
            var type = item?.InstanceType;
            if (type == typeof(WelcomePage))
                return;
            if(item?.Instance == e.Instance)
                updatePropertyGrid = true;
        }

        private void PropertyGrid_ProcessException(object? sender, PropertyGridExceptionEventArgs e)
        {
            Application.LogFileIsEnabled = true;
            LogUtils.LogException(e.InnerException);
        }

        private void ControlsListBox_SelectionChanged(object? sender, EventArgs e)
        {
            updatePropertyGrid = true;
        }

        internal void UpdatePropertyGrid(object? instance = null)
        {
            if(instance != null)
            {
                if (PropGrid.FirstItemInstance == instance)
                    return;
                PropGrid.SetProps(instance, true);
                return;
            }

            void DoAction()
            {
                controlPanel.GetVisibleChildOrNull()?.Hide();
                var item = panel.LeftTreeView.SelectedItem as ControlListBoxItem;
                var type = item?.InstanceType;

                if (item?.Instance is Control control)
                {
                    if(control.Name == null)
                    {
                        var s = control.GetType().ToString();
                        var splitted = s.Split('.');
                        control.Name = splitted[splitted.Length - 1] + LogUtils.GenNewId().ToString();
                    }

                    if(control.Parent == null)
                    {
                        control.VerticalAlignment = VerticalAlignment.Top;
                        control.MinWidth = 100;
                        control.Parent = controlPanel;
                    }

                    control.Visible = true;
			        control.PerformLayout();
                    Application.Current.ProcessPendingEvents();
                }

                if (type == typeof(WelcomePage))
                {
                    controlPanel.BackgroundColor = SystemColors.Window;
                    InitDefaultPropertyGrid();
                }
                else
                {
                    controlPanel.BackgroundColor = SystemColors.Control;
                    var selection = panel.RightNotebook.GetSelection();
                    if (selection == panel.PropGridPage?.Index)
                    {
                        PropGrid.SetProps(item?.PropInstance, true);
                    }
                    else
                    {
                        PropGrid.Clear();
                    }
                }
            }

            controlPanel.SuspendLayout();
            try
            {
                DoAction();
            }
            finally
            {
                controlPanel.ResumeLayout();
            }
        }

        public class SettingsControl : Control
        {

        }
    }
}