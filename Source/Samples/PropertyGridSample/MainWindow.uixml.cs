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
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
        };

        private bool updatePropertyGrid = false;

        static MainWindow()
        {
#if DEBUG
            Application.LogFileIsEnabled = false;
#endif
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
            KnownColorStrings.Default.Black = "black";

            // Sample localization of Enum property values.
            var localizableEnum = PropertyGrid.GetChoices<BrushType>();
            localizableEnum.SetLabelForValue<BrushType>(BrushType.LinearGradient, "Linear Gradient");
            localizableEnum.SetLabelForValue<BrushType>(BrushType.RadialGradient, "Radial Gradient");
        }

        private static void InitIgnorePropNames(ICollection<string> items)
        {
            items.Add("Width");
            items.Add("Height");
            items.Add("Left");
            items.Add("Top");
        }

        public PropertyGrid PropGrid => panel.PropGrid;

        public MainWindow()
        {
            panel.BindApplicationLogMessage();

            PropGrid.ApplyFlags |= PropertyGridApplyFlags.PropInfoSetValue
                | PropertyGridApplyFlags.ReloadAfterSetValue;
            PropGrid.Features = PropertyGridFeature.QuestionCharInNullable;
            PropertyGridSettings.Default = new(this);
            PropGrid.ProcessException += PropertyGrid_ProcessException;
            InitIgnorePropNames(PropGrid.IgnorePropNames);
            PropGrid.CreateStyleEx = PropertyGridCreateStyleEx.AlwaysAllowFocus;

            Icon = ImageSet.FromUrlOrNull("embres:PropertyGridSample.Sample.ico");
            panel.InitLogContextMenu();

            InitializeComponent();

            Children.Add(panel);

            panel.LeftTreeView.SelectionChanged += ControlsListBox_SelectionChanged;

            // Center pane
            panel.Manager.AddPane(controlPanel, panel.CenterPane);

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

            static void SetPropertyGridDefaults(PropertyGrid pg)
            {
                pg.ApplyKnownColors(PropertyGridSettings.Default!.ColorScheme);
                pg.CenterSplitter();
                pg.SetVerticalSpacing();
            }

            SetPropertyGridDefaults(panel.PropGrid);
            SetPropertyGridDefaults(panel.EventGrid);

            panel.LeftTreeView.SelectedItem = panel.LeftTreeView.FirstItem;

            Application.Current.Idle += ApplicationIdle;
            RunTests();

            ComponentDesigner.InitDefault();
            ComponentDesigner.Default!.PropertyChanged += Default_PropertyChanged;

            controlPanel.MouseDown += ControlPanel_MouseDown;
            controlPanel.DragStart += ControlPanel_DragStart;

            panel.WriteWelcomeLogMessages();
        }

        private void Default_PropertyChanged(object? sender, PropertyChangeEventArgs e)
        {
            var item = panel.LeftTreeView.SelectedItem as ControlListBoxItem;
            var type = item?.InstanceType;
            if (type == typeof(WelcomeControl))
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
            UpdatePropertyGrid();
        }

        internal void UpdatePropertyGrid(object? instance = null)
        {
            if(instance != null)
            {
                if (PropGrid.FirstItemInstance == instance)
                    return;
                PropGrid.SetProps(instance, true);
                UpdateEventsPropertyGrid(instance);
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

                    control.Parent ??= controlPanel;
                    control.Visible = true;
                    Application.Current.ProcessPendingEvents();
                }

                if (type == typeof(WelcomeControl))
                {
                    InitDefaultPropertyGrid();
                    Application.Current.ProcessPendingEvents();
                    UpdateEventsPropertyGrid(null);
                }
                else
                {
                    UpdateEventsPropertyGrid(item?.EventInstance);
                    Application.Current.ProcessPendingEvents();
                    PropGrid.SetProps(item?.PropInstance, true);
                }
            }

            void UpdateEventsPropertyGrid(object? instance)
            {
                panel.EventGrid.DoInsideUpdate(() =>
                {
                    panel.EventGrid.Clear();
                    if (instance == null)
                        return;
                    var events = AssemblyUtils.EnumEvents(instance.GetType(), true);

                    foreach(var item in events)
                    {
                        var prop = panel.EventGrid.CreateBoolItem(item.Name, null, false);
                        panel.EventGrid.SetPropertyReadOnly(prop, true);
                        panel.EventGrid.Add(prop);
                    }
                });
            }

            //controlPanel.SuspendLayout();
            try
            {
                DoAction();
            }
            finally
            {
                //controlPanel.ResumeLayout();
            }
        }

        public class SettingsControl : Control
        {

        }
    }
}