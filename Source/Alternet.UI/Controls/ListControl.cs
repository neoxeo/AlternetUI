using System;
using System.Globalization;
using Alternet.Base.Collections;

namespace Alternet.UI
{
    /// <summary>
    /// Provides a common implementation of members for the ListBox and
    /// ComboBox classes.
    /// </summary>
    public abstract class ListControl : Control
    {
        // todo: copy DataSource, DisplayMember, ValueMember etc implementation
        // from WinForms

        /// <summary>
        /// Gets or sets the currently selected item in the control.
        /// </summary>
        /// <value>An object that represents the current selection in the
        /// control, or <c>null</c> if no item is selected.</value>
        public abstract object? SelectedItem { get; set; }

        /// <summary>
        /// Gets or sets the zero-based index of the currently selected item in
        /// the control/>.
        /// </summary>
        /// <value>A zero-based index of the currently selected item. A value
        /// of <c>null</c> is returned if no item is selected.</value>
        public abstract int? SelectedIndex { get; set; }

        /// <summary>
        /// Gets the items of the <see cref="ListControl"/>.
        /// </summary>
        /// <value>An <see cref="Collection{Object}"/> representing the items
        /// in the <see cref="ListControl"/>.</value>
        /// <remarks>This property enables you to obtain a reference to the list
        /// of items that are currently stored in the <see cref="ListControl"/>.
        /// With this reference, you can add items, remove items, and obtain
        /// a count of the items in the collection.</remarks>
        [Content]
        public Collection<object> Items { get; } =
            new Collection<object> { ThrowOnNullItemAddition = true };

        /// <summary>
        /// Returns the text representation of the specified item.
        /// </summary>
        /// <param name="item">The object from which to get the contents to
        /// display.</param>
        public virtual string GetItemText(object item)
        {
            return item switch
            {
                null => string.Empty,
                string s => s,
                _ => Convert.ToString(item, CultureInfo.CurrentCulture) ?? string.Empty
            };
        }

        /// <summary>
        /// Adds enum values to <see cref="Items"/> property of the control.
        /// </summary>
        /// <param name="type">Type of the enum which values are added.</param>
        /// <param name="selectValue">New <see cref="SelectedItem"/> value.</param>
        public virtual void AddEnumValues(Type type, object? selectValue = null)
        {
            foreach (var item in Enum.GetValues(type))
                Items.Add(item);
            SelectedItem = selectValue;
        }
    }
}