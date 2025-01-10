﻿using System;
using System.Collections.Generic;
using System.Text;

using Alternet.Base.Collections;

namespace Alternet.UI
{
    /// <summary>
    /// Implements panel with settings. Each settings panel item is
    /// a labeled control which allows to edit individual setting.
    /// Items are declared using logical definitions (for example, boolean setting or
    /// string setting) and are not bound to the specific controls.
    /// </summary>
    public partial class PanelSettings : HiddenBorder
    {
        private static EnumArray<PanelSettingsItemKind, ItemToControlDelegate?> itemToControl = new();

        private readonly Collection<PanelSettingsItem> items;

        static PanelSettings()
        {
            Fn(RegisterConversion);

            void Fn(RegisterConversionDelegate register)
            {
                T? ConvertWithLabel<T>(PanelSettingsItem item, object? control)
                    where T : AbstractControl, new()
                {
                    var text = item.Label?.ToString() ?? string.Empty;
                    var isEmpty = string.IsNullOrEmpty(text);

                    if (control is T typedControl)
                    {
                        typedControl.Text = text;
                        typedControl.Visible = !isEmpty;
                        return typedControl;
                    }
                    else
                    {
                        if (isEmpty)
                            return null;
                        var created = new T();
                        created.Text = text;
                        return created;
                    }
                }

                register(
                    PanelSettingsItemKind.Spacer,
                    (item, control) =>
                    {
                        return null;
                    });

                register(
                    PanelSettingsItemKind.Label,
                    (item, control) =>
                    {
                        return ConvertWithLabel<Label>(item, control);
                    });

                register(
                    PanelSettingsItemKind.Value,
                    (item, control) =>
                    {
                        return null;
                    });

                register(
                    PanelSettingsItemKind.Button,
                    (item, control) =>
                    {
                        var result = ConvertWithLabel<Button>(item, control);

                        if (result is not null)
                        {
                            result.ClickAction = () =>
                            {
                                item.ClickAction?.Invoke(item, EventArgs.Empty);
                            };
                        }

                        return result;
                    });

                register(
                    PanelSettingsItemKind.Selector,
                    (item, control) =>
                    {
                        return null;
                    });

                register(
                    PanelSettingsItemKind.EditableSelector,
                    (item, control) =>
                    {
                        return null;
                    });
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PanelSettings"/> class.
        /// </summary>
        public PanelSettings()
        {
            items = new();
            items.ThrowOnNullAdd = true;
            items.ItemInserted += ItemInserted;
            items.ItemRemoved += ItemRemoved;
        }

        /// <summary>
        /// Encapsulates a method that is invoked when item is clicked, changed
        /// or in the similar places.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <param name="e">Event arguments.</param>
        public delegate void ItemActionDelegate(PanelSettingsItem item, EventArgs e);

        /// <summary>
        /// Encapsulates a method that is used when item is converted to the control.
        /// </summary>
        /// <param name="item">Item for the conversion.</param>
        /// <param name="createdControl">If not Null, contains previously created control.
        /// In this case you need only to update control's properties. If passed control is not
        /// of the desired type, just create new control.</param>
        /// <returns></returns>
        public delegate object? ItemToControlDelegate(
            PanelSettingsItem item,
            object? createdControl);

        /// <summary>
        /// Encapsulates a method that is used when convertion from item
        /// to control is registered.
        /// </summary>
        /// <param name="kind">Item kind.</param>
        /// <param name="conversion">Conversion function.</param>
        /// <param name="platform">Platform kind for which registration is done.</param>
        public delegate void RegisterConversionDelegate(
            PanelSettingsItemKind kind,
            ItemToControlDelegate? conversion,
            UIPlatformKind platform = UIPlatformKind.Platformless);

        /// <summary>
        /// Gets collection of the items. Each of the items defines individual
        /// setting with label, value and style options.
        /// </summary>
        public virtual Collection<PanelSettingsItem> Items
        {
            get
            {
                return items;
            }
        }

        /// <summary>
        /// Gets or sets whether controls are automatically created and updated
        /// when items are changed.
        /// </summary>
        public virtual bool AutoCreate { get; set; } = false;

        /// <summary>
        /// Registers function which is called when item is converted to the control.
        /// </summary>
        /// <param name="platform">Platform kind.</param>
        /// <param name="kind">Item kind.</param>
        /// <param name="func">Function which is called when item
        /// is converted to the control.</param>
        public static void RegisterConversion(
            PanelSettingsItemKind kind,
            ItemToControlDelegate? func,
            UIPlatformKind platform = UIPlatformKind.Platformless)
        {
            itemToControl[kind] = func;
        }

        /// <summary>
        /// Adds item with the generic text label.
        /// </summary>
        /// <param name="label">Text label.</param>
        /// <returns></returns>
        public PanelSettingsItem AddLabel(object? label)
        {
            PanelSettingsItem item = new();
            item.Label = label;
            item.Kind = PanelSettingsItemKind.Label;
            return item;
        }

        /// <summary>
        /// Adds item with the button.
        /// </summary>
        /// <param name="label">Text label which will be shown next to the editor.</param>
        /// <param name="clickAction">Action which is invoked when button is clicked.</param>
        /// <returns></returns>
        public PanelSettingsItem AddButton(
            object? label,
            ItemActionDelegate? clickAction)
        {
            PanelSettingsItem item = new();
            item.Label = label;
            item.Kind = PanelSettingsItemKind.Button;
            item.ClickAction = clickAction;
            return item;
        }

        /// <summary>
        /// Adds item with the editor for the nullable value of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of the value.</typeparam>
        /// <param name="label">Text label which will be shown next to the editor.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="onChange">Action which is called when value is changed. Optional</param>
        /// <returns></returns>
        public PanelSettingsItem AddNullableValue<T>(
            object label,
            T? defaultValue,
            ItemActionDelegate? onChange = null)
        {
            PanelSettingsItem item = new();
            item.Label = label;
            item.Kind = PanelSettingsItemKind.Value;
            item.ValueType = typeof(T);
            item.IsNullable = true;
            item.Value = defaultValue;
            item.ValueChangedAction = onChange;
            return item;
        }

        /// <summary>
        /// Adds item with the editor for the nullable value of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of the value.</typeparam>
        /// <param name="label">Text label which will be shown next to the editor.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="pickList">Collection of possible values.</param>
        /// <param name="onChange">Action which is called when value is changed. Optional</param>
        /// <returns></returns>
        public PanelSettingsItem AddSelector<T>(
            object label,
            T? defaultValue,
            IEnumerable<T> pickList,
            ItemActionDelegate? onChange = null)
        {
            PanelSettingsItem item = new();
            item.Label = label;
            item.Kind = PanelSettingsItemKind.Selector;
            item.ValueType = typeof(T);
            item.IsNullable = false;
            item.Value = defaultValue;
            item.ValueChangedAction = onChange;
            return item;
        }

        /// <summary>
        /// Adds item with the editor for the not null value of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of the value.</typeparam>
        /// <param name="label">Text label which will be shown next to the editor.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="onChange">Action which is called when value is changed. Optional</param>
        /// <returns></returns>
        public PanelSettingsItem AddValue<T>(
            object label,
            T defaultValue,
            ItemActionDelegate? onChange = null)
        {
            PanelSettingsItem item = new();
            item.Label = label;
            item.Kind = PanelSettingsItemKind.Value;
            item.ValueType = typeof(T);
            item.IsNullable = false;
            item.Value = defaultValue;
            item.ValueChangedAction = onChange;
            return item;
        }

        /// <summary>
        /// Called when item is removed from the <see cref="Items"/> collection.
        /// </summary>
        protected virtual void ItemRemoved(object? sender, int index, PanelSettingsItem item)
        {
        }

        /// <summary>
        /// Called when item is added to the <see cref="Items"/> collection.
        /// </summary>
        protected virtual void ItemInserted(object? sender, int index, PanelSettingsItem item)
        {
        }
    }
}
