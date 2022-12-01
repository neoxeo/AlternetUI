using Alternet.Base.Collections;
using System.Collections.Generic;

namespace Alternet.UI
{
    /// <summary>
    /// Represents a toolbar control.
    /// </summary>
    public class Toolbar : Control
    {
        /// <inheritdoc/>
        public new ToolbarHandler Handler
        {
            get
            {
                CheckDisposed();
                return (ToolbarHandler)base.Handler;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Toolbar"/> class.
        /// </summary>
        public Toolbar()
        {
            Items.ItemInserted += Items_ItemInserted;
            Items.ItemRemoved += Items_ItemRemoved;
        }

        /// <summary>
        /// Gets or sets a boolean value indicating whether this toolbar item text is visible.
        /// </summary>
        public bool ItemTextVisible { get => Handler.ItemTextVisible; set => Handler.ItemTextVisible = value; }

        /// <summary>
        /// Gets or sets a boolean value indicating whether this toolbar item images are visible.
        /// </summary>
        public bool ItemImagesVisible { get => Handler.ItemImagesVisible; set => Handler.ItemImagesVisible = value; }

        private void Items_ItemInserted(object? sender, CollectionChangeEventArgs<ToolbarItem> e)
        {
            // This is required for data binding inheritance.
            Children.Add(e.Item);
        }

        private void Items_ItemRemoved(object? sender, CollectionChangeEventArgs<ToolbarItem> e)
        {
            Children.Remove(e.Item);
        }

        /// <summary>
        /// Gets a collection of <see cref="MenuItem"/> objects associated with the menu.
        /// </summary>
        [Content]
        public Collection<ToolbarItem> Items { get; } = new Collection<ToolbarItem>();

        /// <inheritdoc/>
        public override IReadOnlyList<FrameworkElement> ContentElements => Items;

        /// <inheritdoc />
        protected override IEnumerable<FrameworkElement> LogicalChildrenCollection => Items;
    }
}