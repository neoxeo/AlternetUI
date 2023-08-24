using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    /// <summary>
    /// Specialized grid for editing properties - in other words name = value pairs.
    /// </summary>
    /// <remarks>
    /// List of ready-to-use property classes include strings, numbers, flag sets, fonts,
    /// colors and many others. It is possible, for example, to categorize properties,
    /// set up a complete tree-hierarchy, add more than two columns, and set
    /// arbitrary per-property attributes.
    /// </remarks>
    public class PropertyGrid : Control
    {
        internal static readonly string NameAsLabel = Native.PropertyGrid.NameAsLabel;
        private static Dictionary<Type, IPropertyGridChoices>? choicesCache = null;

        /// <summary>
        /// Defines default visual style for the newly created
        /// <see cref="PropertyGrid"/> controls.
        /// </summary>
        public static PropertyGridCreateStyle DefaultCreateStyle { get; set; }
            = PropertyGridCreateStyle.DefaultStyle;

        /// <summary>
        /// Defines visual style and behavior of the <see cref="PropertyGrid"/> control.
        /// </summary>
        /// <remarks>
        /// When this property is changed, control is recreated.
        /// </remarks>
        public PropertyGridCreateStyle CreateStyle
        {
            get
            {
                return (PropertyGridCreateStyle)Handler.CreateStyle;
            }

            set
            {
                Handler.CreateStyle = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control has a border.
        /// </summary>
        public bool HasBorder
        {
            get
            {
                return NativeControl.HasBorder;
            }

            set
            {
                NativeControl.HasBorder = value;
            }
        }

        /// <inheritdoc/>
        public override ControlId ControlKind => ControlId.PropertyGrid;

        internal new NativePropertyGridHandler Handler
        {
            get
            {
                CheckDisposed();
                return (NativePropertyGridHandler)base.Handler;
            }
        }

        internal Native.PropertyGrid NativeControl => Handler.NativeControl;

        /// <summary>
        /// Creates <see cref="string"/> property.
        /// </summary>
        /// <param name="label">Property label.</param>
        /// <param name="name">Property name.</param>
        /// <param name="value">Default property value.</param>
        /// <returns>Property declaration for use with <see cref="PropertyGrid.Add"/>.</returns>
        public IPropertyGridItem CreateStringProperty(
            string label,
            string? name = null,
            string? value = null)
        {
            value ??= string.Empty;
            var handle = NativeControl.CreateStringProperty(label, CorrectPropName(name), value!);
            return new PropertyGridItem(handle, label, name, value);
        }

        /// <summary>
        /// Creates <see cref="bool"/> property.
        /// </summary>
        /// <param name="label">Property label.</param>
        /// <param name="name">Property name.</param>
        /// <param name="value">Default property value.</param>
        /// <returns>Property declaration for use with <see cref="PropertyGrid.Add"/>.</returns>
        public IPropertyGridItem CreateBoolProperty(
            string label,
            string? name = null,
            bool value = false)
        {
            var handle = NativeControl.CreateBoolProperty(label, CorrectPropName(name), value);
            return new PropertyGridItem(handle, label, name, value);
        }

        /// <summary>
        /// Creates <see cref="int"/> property. Supports also <see cref="long"/> values.
        /// </summary>
        /// <param name="label">Property label.</param>
        /// <param name="name">Property name.</param>
        /// <param name="value">Default property value.</param>
        /// <returns>Property declaration for use with <see cref="PropertyGrid.Add"/>.</returns>
        public IPropertyGridItem CreateIntProperty(
            string label,
            string? name = null,
            long value = 0)
        {
            var handle = NativeControl.CreateIntProperty(label, CorrectPropName(name), value);
            return new PropertyGridItem(handle, label, name, value);
        }

        /// <summary>
        /// Creates <see cref="double"/> property.
        /// </summary>
        /// <param name="label">Property label.</param>
        /// <param name="name">Property name.</param>
        /// <param name="value">Default property value.</param>
        /// <returns>Property declaration for use with <see cref="PropertyGrid.Add"/>.</returns>
        public IPropertyGridItem CreateFloatProperty(
            string label,
            string? name = null,
            double value = 0.0)
        {
            var handle = NativeControl.CreateFloatProperty(label, CorrectPropName(name), value);
            return new PropertyGridItem(handle, label, name, value);
        }

        /// <summary>
        /// Creates <see cref="uint"/> property. Supports also <see cref="ulong"/> values.
        /// </summary>
        /// <param name="label">Property label.</param>
        /// <param name="name">Property name.</param>
        /// <param name="value">Default property value.</param>
        /// <returns>Property declaration for use with <see cref="PropertyGrid.Add"/>.</returns>
        public IPropertyGridItem CreateUIntProperty(
            string label,
            string? name = null,
            ulong value = 0)
        {
            var handle = NativeControl.CreateUIntProperty(label, CorrectPropName(name), value);
            return new PropertyGridItem(handle, label, name, value);
        }

        /// <summary>
        /// Creates <see cref="string"/> property with additional edit dialog for
        /// entering long values.
        /// </summary>
        /// <param name="label">Property label.</param>
        /// <param name="name">Property name.</param>
        /// <param name="value">Default property value.</param>
        /// <returns>Property declaration for use with <see cref="PropertyGrid.Add"/>.</returns>
        public IPropertyGridItem CreateLongStringProperty(
            string label,
            string? name = null,
            string? value = null)
        {
            value ??= string.Empty;
            var handle = NativeControl.CreateLongStringProperty(
                label,
                CorrectPropName(name),
                value);
            return new PropertyGridItem(handle, label, name, value);
        }

        /// <summary>
        /// Creates <see cref="DateTime"/> property.
        /// </summary>
        /// <param name="label">Property label.</param>
        /// <param name="name">Property name.</param>
        /// <param name="value">Default property value.</param>
        /// <returns>Property declaration for use with <see cref="PropertyGrid.Add"/>.</returns>
        public IPropertyGridItem CreateDateProperty(
            string label,
            string? name = null,
            DateTime? value = null)
        {
            DateTime dt;

            if (value == null)
                dt = DateTime.Now;
            else
                dt = value.Value;

            var handle = NativeControl.CreateDateProperty(
                label,
                CorrectPropName(name),
                dt);
            return new PropertyGridItem(handle, label, name, value);
        }

        /// <summary>
        /// Creates enumeration property.
        /// </summary>
        /// <param name="label">Property label.</param>
        /// <param name="name">Property name.</param>
        /// <param name="choices">Enumeration elements.</param>
        /// <param name="value">Default property value.</param>
        /// <returns>Property declaration for use with <see cref="PropertyGrid.Add"/>.</returns>
        public IPropertyGridItem CreateEnumProperty(
            string label,
            string? name,
            IPropertyGridChoices choices,
            object? value = null)
        {
            value ??= 0;
            var handle = NativeControl.CreateEnumProperty(
                label,
                CorrectPropName(name),
                choices.Handle,
                (int)value);
            return new PropertyGridItem(handle, label, name, value);
        }

        /// <summary>
        /// Creates flags property (like enumeration with Flags attribute).
        /// </summary>
        /// <param name="label">Property label.</param>
        /// <param name="name">Property name.</param>
        /// <param name="choices">Elements.</param>
        /// <param name="value">Default property value.</param>
        /// <returns>Property declaration for use with <see cref="PropertyGrid.Add"/>.</returns>
        public IPropertyGridItem CreateFlagsProperty(
            string label,
            string? name,
            IPropertyGridChoices choices,
            object? value = null)
        {
            value ??= 0;
            var handle = NativeControl.CreateFlagsProperty(
                label,
                CorrectPropName(name),
                choices.Handle,
                (int)value);
            return new PropertyGridItem(handle, label, name, value);
        }

        /// <summary>
        /// Creates property choices list for use with <see cref="CreateFlagsProperty"/> and
        /// <see cref="CreateEnumProperty"/>.
        /// </summary>
#pragma warning disable CA1822 // Mark members as static
        public IPropertyGridChoices CreateChoices()
#pragma warning restore CA1822 // Mark members as static
        {
            return new PropertyGridChoices();
        }

        /// <summary>
        /// Creates property choices list for the given enumeration type or returns it from
        /// the internal cache if it was previously created.
        /// </summary>
        /// <remarks>
        /// Result can be used in <see cref="CreateFlagsProperty"/> and
        /// <see cref="CreateEnumProperty"/>.
        /// </remarks>
        public IPropertyGridChoices CreateChoicesOnce(Type enumType)
        {
            choicesCache ??= new();
            if (choicesCache.TryGetValue(enumType, out IPropertyGridChoices? result))
                return result;
            result = CreateChoices(enumType);
            choicesCache.Add(enumType, result);
            return result;
        }

        /// <summary>
        /// Creates property choices list for the given enumeration type.
        /// </summary>
        /// <remarks>
        /// Result can be used in <see cref="CreateFlagsProperty"/> and
        /// <see cref="CreateEnumProperty"/>.
        /// </remarks>
        public IPropertyGridChoices CreateChoices(Type enumType)
        {
            var result = CreateChoices();

            if (!enumType.IsEnum)
                return result;

            var values = Enum.GetValues(enumType);
            var names = Enum.GetNames(enumType);

            for(int i = 0; i < values.Length; i++)
            {
                var value = values.GetValue(i);
                result.Add(names[i], (int)value!);
            }

            return result;
        }

        /// <summary>
        /// Deletes all items from the property grid.
        /// </summary>
        public void Clear()
        {
            NativeControl.Clear();
        }

        /// <summary>
        /// Adds item to the property grid.
        /// </summary>
        /// <param name="prop">Item to add.</param>
        public void Add(IPropertyGridItem prop)
        {
            NativeControl.Append(prop.Handle);
        }

        public IPropertyGridItem CreatePropCategory(string label, string? name = null)
        {
            var handle = NativeControl.CreatePropCategory(
                label,
                CorrectPropName(name));
            var result = new PropertyGridItem(handle, label, name, null)
            {
                IsCategory = true,
            };
            return result;
        }

        internal static void InitAllTypeHandlers()
        {
            Native.PropertyGrid.InitAllTypeHandlers();
        }

        internal static void RegisterAdditionalEditors()
        {
            Native.PropertyGrid.RegisterAdditionalEditors();
        }

        internal static void SetBoolChoices(string trueChoice, string falseChoice)
        {
            Native.PropertyGrid.SetBoolChoices(trueChoice, falseChoice);
        }

        // !!
        internal IntPtr GetFirst(int flags)
        {
            var result = NativeControl.GetFirst(flags);
            return result;
        }

        // !!
        internal IntPtr GetProperty(string name)
        {
            var result = NativeControl.GetProperty(name);
            return result;
        }

        // !!
        internal IntPtr GetPropertyByLabel(string label)
        {
            var result = NativeControl.GetPropertyByLabel(label);
            return result;
        }

        // !!
        internal IntPtr GetPropertyByName(string name)
        {
            var result = NativeControl.GetPropertyByName(name);
            return result;
        }

        // !!
        internal IntPtr GetPropertyByNameAndSubName(string name, string subname)
        {
            var result = NativeControl.GetPropertyByNameAndSubName(name, subname);
            return result;
        }

        // !!
        internal IntPtr GetSelection()
        {
            var result = NativeControl.GetSelection();
            return result;
        }

        // !!
        internal string GetPropertyName(IntPtr property)
        {
            return NativeControl.GetPropertyName(property);
        }

        // !!
        internal bool RestoreEditableState(string src, int restoreStates)
        {
            return NativeControl.RestoreEditableState(src, restoreStates);
        }

        // !!
        internal string SaveEditableState(int includedStates)
        {
            return NativeControl.SaveEditableState(includedStates);
        }

        // !!
        internal bool SetColumnProportion(uint column, int proportion)
        {
            return NativeControl.SetColumnProportion(column, proportion);
        }

        internal int GetColumnProportion(uint column)
        {
            return NativeControl.GetColumnProportion(column);
        }

        // !!
        internal void Sort(int flags = 0)
        {
            NativeControl.Sort(flags);
        }

        // !!
        internal void RefreshProperty(IntPtr p)
        {
            NativeControl.RefreshProperty(p);
        }

        /// <inheritdoc/>
        protected override ControlHandler CreateHandler()
        {
            return GetEffectiveControlHandlerHactory().CreatePropertyGridHandler(this);
        }

        private string CorrectPropName(string? name)
        {
            if (name is null)
                return NameAsLabel;
            return name;
        }
    }
}