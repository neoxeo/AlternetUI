using System;
using System.Collections.Generic;
using Alternet.Base.Collections;

namespace Alternet.UI
{
    /// <summary>
    /// Represents the base functionality for all menus.
    /// </summary>
    public abstract class Menu : NonVisualControl
    {
        private Collection<MenuItem>? items;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        protected Menu()
        {
        }

        /// <summary>
        /// Gets a collection of <see cref="MenuItem"/> objects associated with the menu.
        /// </summary>
        [Content]
        public Collection<MenuItem> Items
        {
            get
            {
                if(items == null)
                {
                    items = new() { ThrowOnNullAdd = true };
                    items.ItemInserted += Items_ItemInserted;
                    items.ItemRemoved += Items_ItemRemoved;
                }

                return items;
            }
        }

        /// <inheritdoc/>
        public override ControlTypeId ControlKind => ControlTypeId.Menu;

        /// <inheritdoc/>
        public override IReadOnlyList<FrameworkElement> ContentElements
        {
            get
            {
                if (items == null)
                    return Array.Empty<FrameworkElement>();
                return items;
            }
        }

        internal IntPtr MenuHandle => (Handler.NativeControl as Native.Menu)!.MenuHandle;

        internal override bool IsDummy => true;

        /// <inheritdoc />
        protected override IEnumerable<FrameworkElement> LogicalChildrenCollection => ContentElements;

        /// <summary>
        /// Adds item to <see cref="Items"/>.
        /// </summary>
        /// <param name="item">Menu item.</param>
        public MenuItem Add(MenuItem item)
        {
            Items.Add(item);
            return Items.Last!;
        }

        private void Items_ItemInserted(object? sender, int index, MenuItem item)
        {
            // This is required for data binding inheritance.
            Children.Add(item);
        }

        private void Items_ItemRemoved(object? sender, int index, MenuItem item)
        {
            Children.Remove(item);
        }
    }
}