using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Alternet.Drawing;
using Alternet.UI;

namespace PropertyGridSample
{
    public partial class MainWindow : Window
    {
        private const string ResPrefix =
            "embres:PropertyGridSample.Resources.";
        private const string ResPrefixImage = $"{ResPrefix}logo-128x128.png";

        private static readonly Image DefaultImage = Image.FromUrl(ResPrefixImage);

        private static readonly Dictionary<Type, Action<Control>> Initializers = new();
        private readonly AuiManager manager = new();
        private readonly LayoutPanel panel = new();
        private readonly ListBox controlsListBox;
        private readonly PropertyGrid propertyGrid = new();
        private readonly ListBox logListBox;
        private readonly ContextMenu contextMenu2 = new();
        private readonly StackPanel controlPanel = new();

        static MainWindow()
        {
            TestLong();

            WebBrowser.CrtSetDbgFlag(0);

            Initializers.Add(typeof(Label), (c) => { (c as Label)!.Text = "Label"; });

            Initializers.Add(typeof(Border), (c) => { c.Height = 150; });

            Initializers.Add(typeof(Button), (c) => 
            { 
                (c as Button)!.Text = "Button"; 
            });

            Initializers.Add(typeof(CheckBox), (c) =>
            {
                (c as CheckBox)!.Text = "CheckBox";
            });

            Initializers.Add(typeof(RadioButton), (c) =>
            {
                (c as RadioButton)!.Text = "RadioButton";
            });

            Initializers.Add(typeof(LinkLabel), (c) =>
            {
                LinkLabel linkLabel = (c as LinkLabel)!;
                linkLabel.Text = "LinkLabel";
                linkLabel.Url = "https://www.google.com/";
            });

            Initializers.Add(typeof(GroupBox), (c) =>
            {
                GroupBox control = (c as GroupBox)!;
                control.Title = "GroupBox";
                control.Height = 150;
            });

            Initializers.Add(typeof(PictureBox), (c) =>
            {
                PictureBox control = (c as PictureBox)!;
                control.Image = DefaultImage;
            });
        }

        public Decimal DecimalValue { get; set; }
        public Font FontValue { get; set; } = Font.Default;
        public Brush BrushValue { get; set; } = Brush.Default;
        public Pen PenValue { get; set; } = Pen.Default;

        private ListBox CreateListBox(Control? parent = null)
        {
            ListBox listBox = new()
            {
                HasBorder = false
            };
            parent ??= panel;
            parent.Children.Add(listBox);
            listBox.SetBounds(0, 0, 200, 100, BoundsSpecified.Size);
            return listBox;
        }

        public MainWindow()
        {
            propertyGrid.CreateStyleEx = PropertyGridCreateStyleEx.AlwaysAllowFocus;

            Icon = ImageSet.FromUrlOrNull("embres:PropertyGridSample.Sample.ico");
            InitLogContextMenu();

            InitializeComponent();

            Children.Add(panel);

            manager.SetFlags(AuiManagerOption.Default);
            manager.SetManagedWindow(panel);

            // Left Pane
            var pane1 = manager.CreatePaneInfo();
            pane1.Name("pane1").Caption("Controls").Left().PaneBorder(false).CloseButton(false)
                .TopDockable(false).BottomDockable(false).Movable(false).Floatable(false)
                .CaptionVisible(false);
            controlsListBox = CreateListBox();
            manager.AddPane(controlsListBox, pane1);

            // Right Pane
            var pane2 = manager.CreatePaneInfo();
            pane2.Name("pane2").Caption("Properties").Right().PaneBorder(false)
                .CloseButton(false)
                .TopDockable(false).BottomDockable(false).Movable(false).Floatable(false)
                .BestSize(500, 200).CaptionVisible(false);
            propertyGrid.HasBorder = false;
            panel.Children.Add(propertyGrid);
            manager.AddPane(propertyGrid, pane2);

            // Bottom Pane    
            var pane3 = manager.CreatePaneInfo();
            pane3.Name("pane3").Caption("Output").Bottom().PaneBorder(false).CloseButton(false)
                .LeftDockable(false).RightDockable(false).Movable(false).Floatable(false);
            logListBox = CreateListBox();
            manager.AddPane(logListBox, pane3);

            // Notenook pane
            var pane5 = manager.CreatePaneInfo();
            pane5.Name("pane5").CenterPane().PaneBorder(false);

            controlPanel.HorizontalAlignment = HorizontalAlignment.Center;
            controlPanel.VerticalAlignment = VerticalAlignment.Center;

            panel.Children.Add(controlPanel);
            manager.AddPane(controlPanel, pane5);

            manager.Update();

            ControlListBoxItem item;

            item = new(typeof(SampleProps));
            controlsListBox.Add(item);

            Type[] badTypes = new Type[] 
            {
              typeof(WebBrowser),
              typeof(Panel),
              typeof(Control),
              typeof(AuiNotebook),
              typeof(AuiToolbar),
              typeof(SplitterPanel),
              typeof(Grid),
              typeof(StackPanel),
              typeof(HorizontalStackPanel),
              typeof(VerticalStackPanel),
              typeof(ScrollViewer),
              typeof(StatusBarPanel),
              typeof(LayoutPanel),
              typeof(MenuItem),
              typeof(UserPaintControl),
              typeof(StatusBar),
              typeof(Toolbar),
              typeof(TabPage),
              typeof(TabControl),
              typeof(Window),
              typeof(ToolbarItem),
              typeof(SampleProps),
            };

            IEnumerable<Type> result = AssemblyUtils.GetTypeDescendants(typeof(Control));
            foreach (Type type in result)
            {
                if (Array.IndexOf(badTypes, type) >= 0)
                    continue;
                item = new(type);
                controlsListBox.Add(item);
            }

            InitDefaultPropertyGrid();

            logListBox.MouseRightButtonUp += Log_MouseRightButtonUp;
            controlsListBox.SelectionChanged += ControlsListBox_SelectionChanged;

            propertyGrid.PropertySelected += PGPropertySelected;
            propertyGrid.PropertyChanged += PGPropertyChanged;
            propertyGrid.PropertyChanging += PGPropertyChanging;
            propertyGrid.PropertyHighlighted += PGPropertyHighlighted;
            propertyGrid.PropertyRightClick += PGPropertyRightClick;
            propertyGrid.PropertyDoubleClick += PGPropertyDoubleClick;
            propertyGrid.ItemCollapsed += PGItemCollapsed;
            propertyGrid.ItemExpanded += PGItemExpanded;
            propertyGrid.LabelEditBegin += PGLabelEditBegin;
            propertyGrid.LabelEditEnding += PGLabelEditEnding;
            propertyGrid.ColBeginDrag += PGColBeginDrag;
            propertyGrid.ColDragging += PGColDragging;
            propertyGrid.ColEndDrag += PGColEndDrag;
            propertyGrid.ButtonClick += PropertyGrid_ButtonClick;

            propertyGrid.AddActionTrigger(
            PropertyGridKeyboardAction.ActionNextProperty,
            Key.DownArrow,
            ModifierKeys.Control);

            propertyGrid.ApplyColors(PropertyGridColors.ColorSchemeWhite);
        }

        private void InitDefaultPropertyGrid()
        {
            propertyGrid.BeginUpdate();
            try
            {
                propertyGrid.Clear();

                var prop = propertyGrid.CreatePropCategory("Category 1");
                propertyGrid.Add(prop);

                prop = propertyGrid.CreateBoolProperty("Bool");
                propertyGrid.Add(prop);
                propertyGrid.SetPropertyKnownAttribute(
                    prop,
                    PropertyGridItemAttrId.UseCheckbox,
                    false);

                prop = propertyGrid.CreateBoolProperty("Bool 2");
                propertyGrid.Add(prop);
                propertyGrid.SetPropertyKnownAttribute(prop, PropertyGridItemAttrId.UseCheckbox, true);

                prop = propertyGrid.CreateIntProperty("Int");
                propertyGrid.Add(prop);

                prop = propertyGrid.CreateFloatProperty("Float");
                propertyGrid.Add(prop);

                prop = propertyGrid.CreateUIntProperty("UInt");
                propertyGrid.Add(prop);

                prop = propertyGrid.CreateStringProperty("String");
                propertyGrid.Add(prop);

                prop = propertyGrid.CreateLongStringProperty("Long string");
                propertyGrid.Add(prop);

                // Date
                prop = propertyGrid.CreateDateProperty("Date");
                propertyGrid.Add(prop);
                // If none Date is selected (if checkbox next to date editor is unchecked)
                // DateTime.MinValue is returned.
                propertyGrid.SetPropertyKnownAttribute(
                    prop,
                    PropertyGridItemAttrId.PickerStyle,
                    (int)(DatePickerStyleFlags.DropDown | DatePickerStyleFlags.ShowCentury
                    | DatePickerStyleFlags.AllowNone));

                // Category 2
                prop = propertyGrid.CreatePropCategory("Category 2");
                propertyGrid.Add(prop);

                var choices1 = PropertyGrid.CreateChoicesOnce(typeof(PropertyGridCreateStyle));
                prop = propertyGrid.CreateFlagsProperty("Flags", null, choices1,
                    PropertyGrid.DefaultCreateStyle);
                propertyGrid.Add(prop);

                var choices2 = PropertyGrid.CreateChoicesOnce(typeof(HorizontalAlignment));
                prop = propertyGrid.CreateEnumProperty("Enum", null, choices2,
                    HorizontalAlignment.Center);
                propertyGrid.Add(prop);

                prop = propertyGrid.CreateColorProperty("Color", null, Color.Red);
                propertyGrid.Add(prop);

                prop = propertyGrid.CreateColorProperty("Color with alpha", null, Color.Yellow);
                propertyGrid.SetPropertyKnownAttribute(prop, PropertyGridItemAttrId.HasAlpha, true);
                propertyGrid.Add(prop);

                prop = propertyGrid.CreateStringProperty(
                    "Readonly prop",
                    null,
                    "Some Text");
                propertyGrid.SetPropertyReadOnly(prop, true, false);
                propertyGrid.Add(prop);

                prop = CreateProperty(new Border(), "BorderColor");
                propertyGrid.Add(prop!);

                prop = CreateProperty(this, "DecimalValue");
                propertyGrid.Add(prop!);

                prop = CreateProperty(this, "FontValue");
                propertyGrid.Add(prop!);

                prop = CreateProperty(this, "BrushValue");
                propertyGrid.Add(prop!);

                prop = CreateProperty(this, "PenValue");
                propertyGrid.Add(prop!);

                prop = propertyGrid.CreateStringProperty(
                                    "Error if changed",
                                    null,
                                    "Some Text");
                propertyGrid.Add(prop);

                // Filename
                prop = propertyGrid.CreateFilenameProperty(
                    "Filename",
                    null,
                    PathUtils.GetAppFolder());
                propertyGrid.SetPropertyKnownAttribute(
                    prop,
                    PropertyGridItemAttrId.Wildcard,
                    "Text Files (*.txt)|*.txt");
                propertyGrid.SetPropertyKnownAttribute(
                    prop,
                    PropertyGridItemAttrId.DialogTitle,
                    "Custom File Dialog Title");
                propertyGrid.SetPropertyKnownAttribute(
                    prop,
                    PropertyGridItemAttrId.ShowFullPath,
                    false);
                propertyGrid.Add(prop);

                // Dir
                prop = propertyGrid.CreateDirProperty("Dir", null, PathUtils.GetAppFolder());
                propertyGrid.SetPropertyKnownAttribute(
                    prop,
                    PropertyGridItemAttrId.DialogTitle,
                    "This is a custom dir dialog title");
                propertyGrid.Add(prop);

                // Image filename
                prop = propertyGrid.CreateImageFilenameProperty(
                    "Image Filename",
                    null,
                    PathUtils.GetAppFolder());
                propertyGrid.Add(prop);

                // System color
                prop = propertyGrid.CreateSystemColorProperty(
                    "System color",
                    null,
                    Color.FromKnownColor(KnownColor.Window));
                propertyGrid.Add(prop);

                // Color with ComboBox
                prop = propertyGrid.CreateColorProperty(
                    "Color with ComboBox",
                    null,
                    Color.Black);
                propertyGrid.SetPropertyEditorByName(prop, "ComboBox");
                propertyGrid.Add(prop);

                // Password
                prop = propertyGrid.CreateStringProperty("Password");
                propertyGrid.Add(prop);
                // Password attribute must be set after adding property to PropertyGrid
                propertyGrid.SetPropertyKnownAttribute(prop, PropertyGridItemAttrId.Password, true);

                // String with button
                prop = propertyGrid.CreateStringProperty("Str and button");
                propertyGrid.SetPropertyEditorByName(prop, "TextCtrlAndButton");
                propertyGrid.Add(prop);

                // Editable enum. Can have values which are not in choices.
                var choices = PropertyGrid.CreateChoices();
                choices.Add("Item 1");
                choices.Add("Item 2");
                choices.Add("Item 3");
                prop = propertyGrid.CreateEditEnumProperty("Editable enum", null, choices, "Item 2");
                propertyGrid.Add(prop);

                //Font Name
                choices = FontNameChoices;
                prop = propertyGrid.CreateEnumProperty(
                    "Font name", 
                    null, 
                    choices, 
                    choices.GetValue(Font.Default.Name));
                propertyGrid.Add(prop);
            }
            finally
            {
                propertyGrid.EndUpdate();
            }
        }

        private static IPropertyGridChoices? fontNameChoices;

        public static IPropertyGridChoices FontNameChoices
        { 
            get 
            {
                if (fontNameChoices != null)
                    return fontNameChoices;
                fontNameChoices = PropertyGrid.CreateChoices();
                string[] names = FontFamily.FamiliesNamesAscending;
                fontNameChoices.AddRange(names);
                return fontNameChoices;
            } 
        }

        public IPropertyGridItem CreateFontProperty(
            string label,
            string? name,
            object instance,
            PropertyInfo p)
        {
            PropertyGridAdapterFont adapter = new()
            {
                Instance = instance,
                PropInfo = p
            };
            var result = propertyGrid.CreateStringProperty(label, name, "(Font)");
            propertyGrid.SetPropertyReadOnly(result, true, false);

            var itemName = CreateProperty(adapter, "Name");
            var itemSizeInPoints = CreateProperty(adapter, "SizeInPoints");
            var itemIsBold = CreateProperty(adapter, "IsBold");
            var itemIsItalic = CreateProperty(adapter, "IsItalic");
            var itemIsStrikethrough = CreateProperty(adapter, "IsStrikethrough");
            var itemIsUnderlined = CreateProperty(adapter, "IsUnderlined");
        
            result.Children.Add(itemName!);
            result.Children.Add(itemSizeInPoints!);
            result.Children.Add(itemIsBold!);
            result.Children.Add(itemIsItalic!);
            result.Children.Add(itemIsStrikethrough!);
            result.Children.Add(itemIsUnderlined!);
            return result;
        }

        private static void TestLong()
        {
            IPropertyGridVariant variant = PropertyGrid.CreateVariant();

            long minLong = long.MinValue;
            long maxLong = long.MaxValue;
            ulong minULong = ulong.MinValue;
            ulong maxULong = ulong.MaxValue;

            variant.AsLong = minLong;
            long minLong2 = variant.AsLong;

            variant.AsLong = maxLong;
            long maxLong2 = variant.AsLong;



        }

        public IPropertyGridItem CreateBrushProperty(
            string label,
            string? name,
            object instance,
            PropertyInfo p)
        {
            PropertyGridAdapterBrush adapter = new()
            {
                Instance = instance,
                PropInfo = p
            };
            var result = propertyGrid.CreateStringProperty(label, name, "(Brush)");
            propertyGrid.SetPropertyReadOnly(result, true, false);

            var itemBrushType = CreateProperty(adapter, "BrushType");
            var itemColor = CreateProperty(adapter, "Color");
            var itemLinearGradientStart = CreateProperty(adapter, "LinearGradientStart");
            var itemLinearGradientEnd = CreateProperty(adapter, "LinearGradientEnd");
            var itemRadialGradientCenter = CreateProperty(adapter, "RadialGradientCenter");
            var itemRadialGradientOrigin = CreateProperty(adapter, "RadialGradientOrigin");
            var itemRadialGradientRadius = CreateProperty(adapter, "RadialGradientRadius");
            var itemGradientStops = CreateProperty(adapter, "GradientStops");
            var itemHatchStyle = CreateProperty(adapter, "HatchStyle");

            result.Children.Add(itemBrushType!);
            result.Children.Add(itemColor!);
            result.Children.Add(itemLinearGradientStart!);
            result.Children.Add(itemLinearGradientEnd!);
            result.Children.Add(itemRadialGradientCenter!);
            result.Children.Add(itemRadialGradientOrigin!);
            result.Children.Add(itemRadialGradientRadius!);
            result.Children.Add(itemGradientStops!);
            result.Children.Add(itemHatchStyle!);

            return result;
        }

        public IPropertyGridItem CreatePenProperty(
            string label,
            string? name,
            object instance,
            PropertyInfo p)
        {
            PropertyGridAdapterPen adapter = new()
            {
                Instance = instance,
                PropInfo = p
            };
            IPropertyGridItem result =
                propertyGrid.CreateStringProperty(label, name, "(Pen)");
            propertyGrid.SetPropertyReadOnly(result, true, false);

            var itemColor = CreateProperty(adapter, "Color");
            var itemDashStyle = CreateProperty(adapter, "DashStyle");
            var itemLineCap = CreateProperty(adapter, "LineCap");
            var itemLineJoin = CreateProperty(adapter, "LineJoin");
            var itemWidth = CreateProperty(adapter, "Width");

            result.Children.Add(itemColor!);
            result.Children.Add(itemDashStyle!);
            result.Children.Add(itemLineCap!);
            result.Children.Add(itemLineJoin!);
            result.Children.Add(itemWidth!);

            return result;
        }

        public IPropertyGridItem? CreateProperty(object instance, string name)
        {
            if (instance == null)
                return null;
            var type = instance.GetType();
            var propInfo = type.GetProperty(name);
            if (propInfo == null)
                return null;
            return CreateProperty(instance, propInfo);
        }

        public IPropertyGridItem? CreateProperty(object instance, PropertyInfo p)
        {
            if (!p.CanRead)
                return null;
            ParameterInfo[] paramInfo = p.GetIndexParameters();
            if (paramInfo.Length > 0)
                return null;
            if (!AssemblyUtils.GetBrowsable(p))
                return null;

            var setPropReadonly = false;
            string propName = p.Name;
            var propType = p.PropertyType;
            object? propValue = p.GetValue(instance, null);
            TypeCode typeCode = Type.GetTypeCode(propType);
            IPropertyGridItem? prop = null;

            var underlyingType = Nullable.GetUnderlyingType(propType);
            var isNullable = underlyingType != null;
            var realType = underlyingType ?? propType;

            if (propType.IsEnum)
            {
                var flagsAttr = propType.GetCustomAttribute(typeof(FlagsAttribute));
                var choices = PropertyGrid.CreateChoicesOnce(propType);
                if (flagsAttr == null)
                {
                    prop = propertyGrid.CreateEnumProperty(
                        propName,
                        null,
                        choices,
                        propValue!);
                }
                else
                {
                    prop = propertyGrid.CreateFlagsProperty(
                        propName,
                        null,
                        choices,
                        propValue!);
                }
            }
            else
                switch (typeCode)
                {
                    case TypeCode.Empty:
                    case TypeCode.DBNull:
                        return null;
                    case TypeCode.Object:
                        if(realType  == typeof(Color))
                        {
                            propValue ??= Color.Black;

                            prop = propertyGrid.CreateColorProperty(
                                propName,
                                null,
                                (Color)propValue);
                            break;
                        }
                        if (realType == typeof(Font))
                        {
                            prop = CreateFontProperty(propName, null, instance, p);
                            setPropReadonly = true;
                            break;
                        }
                        if (realType == typeof(Brush))
                        {
                            prop = CreateBrushProperty(propName, null, instance, p);
                            setPropReadonly = true;
                            break;
                        }
                        if (realType == typeof(Pen))
                        {
                            prop = CreatePenProperty(propName,null, instance, p);
                            setPropReadonly = true;
                            break;
                        }
                        prop = propertyGrid.CreateStringProperty(
                            propName,
                            null,
                            propValue?.ToString());
                        setPropReadonly = true;
                        break;
                    case TypeCode.Boolean:
                        propValue ??= false;
                        prop = propertyGrid.CreateBoolProperty(propName, null, (bool)propValue!);
                        break;
                    case TypeCode.SByte:
                        propValue ??= 0;
                        prop = propertyGrid.CreateIntProperty(propName, null, (sbyte)propValue!);
                        break;
                    case TypeCode.Int16:
                        propValue ??= 0;
                        prop = propertyGrid.CreateIntProperty(propName, null, (Int16)propValue!);
                        break;
                    case TypeCode.Int32:
                        propValue ??= 0;
                        prop = propertyGrid.CreateIntProperty(propName, null, (int)propValue!);
                        break;
                    case TypeCode.Int64:
                        propValue ??= 0;
                        prop = propertyGrid.CreateIntProperty(propName, null, (long)propValue!);
                        break;
                    case TypeCode.Byte:
                        propValue ??= 0;
                        prop = propertyGrid.CreateUIntProperty(propName, null, (byte)propValue!);
                        break;
                    case TypeCode.UInt32:
                        propValue ??= 0;
                        prop = propertyGrid.CreateUIntProperty(propName, null, (uint)propValue!);
                        break;
                    case TypeCode.UInt16:
                        propValue ??= 0;
                        prop = propertyGrid.CreateUIntProperty(propName, null, (ushort)propValue!);
                        break;
                    case TypeCode.UInt64:
                        propValue ??= 0;
                        prop = propertyGrid.CreateUIntProperty(propName, null, (ulong)propValue!);
                        break;
                    case TypeCode.Single:
                        propValue ??= (float)0;
                        prop = propertyGrid.CreateFloatProperty(propName, null, (float)propValue!);
                        break;
                    case TypeCode.Double:
                        propValue ??= (double)0;
                        prop = propertyGrid.CreateFloatProperty(propName, null, (double)propValue!);
                        break;
                    case TypeCode.Decimal:
                        propValue ??= (decimal)0;
                        Int64 asDecimal = Convert.ToInt64((decimal)propValue);
                        try
                        {
                            prop = propertyGrid.CreateIntProperty(
                                propName,
                                null,
                                (long)asDecimal!);
                            break;
                        }
                        catch
                        {
                            return null;
                        }
                    case TypeCode.DateTime:
                        propValue ??= DateTime.Now;
                        prop = propertyGrid.CreateDateProperty(
                            propName,
                            null,
                            (DateTime)propValue);
                        break;
                    case TypeCode.Char:
                    case TypeCode.String:
                        prop = propertyGrid.CreateStringProperty(
                            propName,
                            null,
                            propValue?.ToString());
                        break;
                }

            if (!p.CanWrite || setPropReadonly)
                propertyGrid.SetPropertyReadOnly(prop!, true);
            return prop;
        }

        public void AddProps(object instance)
        {
            Type myType = instance.GetType();
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;

            IList<PropertyInfo> props =
                new List<PropertyInfo>(myType.GetProperties(bindingFlags));

            SortedList<string, PropertyInfo> addedNames = new();

            foreach (PropertyInfo p in props)
            {
                if (addedNames.ContainsKey(p.Name))
                    continue;
                IPropertyGridItem? prop = CreateProperty(instance, p);
                if (prop == null)
                    continue;
                propertyGrid.Add(prop!);
                addedNames.Add(p.Name, p);
            }
        }

        public void SetProps(object? instance)
        {
            propertyGrid.BeginUpdate();
            try
            {
                propertyGrid.Clear();
                if (instance == null)
                    return;
                AddProps(instance);
            }
            finally
            {
                propertyGrid.EndUpdate();
            }
        }

        private void ControlsListBox_SelectionChanged(object? sender, EventArgs e)
        {
            controlPanel.Children.Clear();
            var item = controlsListBox.SelectedItem as ControlListBoxItem;
            var type = item?.ControlType;

            if(type == typeof(SampleProps))
            {
                InitDefaultPropertyGrid();
                return;
            }

            var control = item?.ControlInstance;
            if(control != null)
            {
                controlPanel.Padding = new(25, 100, 25, 100);
                if (control.Parent == null)
                    controlPanel.Children.Add(control);
            }
            SetProps(control);
        }

        private void Log_MouseRightButtonUp(object? sender, MouseButtonEventArgs e)
        {
            logListBox.ShowPopupMenu(contextMenu2);
        }

        internal void Log(string s)
        {
            logListBox.Add(s);
            logListBox.SelectLastItem();
        }

        private void InitLogContextMenu()
        {
            MenuItem menuItem1 = new()
            {
                Text = "Clear",
            };
            menuItem1.Click += (sender, e) => { logListBox.Items.Clear(); };

            contextMenu2.Items.Add(menuItem1);
        }

        private void LogEvent(string name)
        {
            var propValue = propertyGrid.EventPropValue;
            if (propValue is null)
                propValue = "NULL";
            string propName = propertyGrid.EventPropName;
            string s = $"Event: {name}. PropName: <{propName}>. Value: <{propValue}>";
            if(logListBox.LastItem?.ToString() != s)
                Log(s);
        }

        private void PGPropertySelected(object? sender, EventArgs e)
        { 
            LogEvent("PropertySelected"); 
        }

        private void PGPropertyChanged(object? sender, EventArgs e)
        {
            LogEvent("PropertyChanged");
        }

        private void PGPropertyChanging(object? sender, CancelEventArgs e)
        {
            LogEvent("PropertyChanging");
            if(propertyGrid.EventPropName == "Error if changed")
                e.Cancel = true;
        }

        private void PGPropertyHighlighted(object? sender, EventArgs e)
        {
            /*LogEvent("PropertyHighlighted");*/
        }

        private void PGPropertyRightClick(object? sender, EventArgs e)
        {
            LogEvent("PropertyRightClick");
        }

        private void PGPropertyDoubleClick(object? sender, EventArgs e)
        {
            LogEvent("PropertyDoubleClick");
        }

        private void PGItemCollapsed(object? sender, EventArgs e)
        {
            LogEvent("ItemCollapsed");
        }

        private void PGItemExpanded(object? sender, EventArgs e)
        {
            LogEvent("ItemExpanded");
        }

        private void PGLabelEditBegin(object? sender, CancelEventArgs e)
        {
            LogEvent("LabelEditBegin");
        }

        private void PGLabelEditEnding(object? sender, CancelEventArgs e)
        {
            LogEvent("LabelEditEnding");
        }

        private void PGColBeginDrag(object? sender, CancelEventArgs e)
        {
            LogEvent("ColBeginDrag");
        }

        private void PGColDragging(object? sender, EventArgs e)
        {
            LogEvent("ColDragging");
        }

        private void PGColEndDrag(object? sender, EventArgs e)
        {
            LogEvent("ColEndDrag");
        }

        private void PropertyGrid_ButtonClick(object sender, EventArgs e)
        {
            LogEvent("ButtonClick");
        }

        public class SampleProps : Control
        {
        }

        private class ControlListBoxItem
        {
            private Control? instance;
            private readonly Type type;

            public ControlListBoxItem(Type type)
            {
                this.type = type;
            }

            public Type ControlType => type;

            public Control ControlInstance
            {
                get
                {
                    if(instance == null)
                    {
                        instance = (Control?)Activator.CreateInstance(type);
                        if (!Initializers.TryGetValue(
                            instance!.GetType(),
                            out Action<Control>? action))
                            return instance;
                        action(instance);
                    }
                    
                    return instance;
                }
            }

            public override string ToString()
            {
                return type.Name;
            }
        }
    }
}