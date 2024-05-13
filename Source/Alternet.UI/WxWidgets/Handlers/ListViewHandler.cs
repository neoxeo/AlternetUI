using System;
using System.Collections.Generic;
using Alternet.Base.Collections;
using Alternet.Drawing;

namespace Alternet.UI
{
    internal class ListViewHandler : WxControlHandler, IListViewHandler
    {
        private int receivingSelection = 0;
        private int applyingSelection = 0;
        private int clearing = 0;

        /// <summary>
        /// Tells <see cref="ListView"/> to use the generic control even
        /// when it is capable of using the native control instead.
        /// </summary>
        public static bool UseGenericOnMacOs
        {
            set
            {
                int v = value ? 1 : 0;

                BaseApplication.SetSystemOption("mac.listctrl.always_use_generic", v);
            }
        }

        public bool ColumnHeaderVisible
        {
            get => NativeControl.ColumnHeaderVisible;
            set => NativeControl.ColumnHeaderVisible = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control has a border.
        /// </summary>
        public bool HasBorder
        {
            get
            {
                CheckDisposed();
                return NativeControl.HasBorder;
            }

            set
            {
                CheckDisposed();
                NativeControl.HasBorder = value;
            }
        }

        public long[] SelectedIndices => NativeControl.SelectedIndices;

        public long? FocusedItemIndex
        {
            get
            {
                var i = NativeControl.FocusedItemIndex;
                return i == -1 ? null : i;
            }

            set => NativeControl.FocusedItemIndex = value ?? -1;
        }

        public new Native.ListView NativeControl =>
            (Native.ListView)base.NativeControl!;

        public bool AllowLabelEdit
        {
            get => NativeControl.AllowLabelEdit;
            set => NativeControl.AllowLabelEdit = value;
        }

        public ListViewItem? TopItem
        {
            get
            {
                var i = NativeControl.TopItemIndex;
                return i < 0 || i >= Control.Items.Count ? null : Control.Items[(int)i];
            }
        }

        public ListViewGridLinesDisplayMode GridLinesDisplayMode
        {
            get => (ListViewGridLinesDisplayMode)NativeControl.GridLinesDisplayMode;
            set => NativeControl.GridLinesDisplayMode =
                (Native.ListViewGridLinesDisplayMode)value;
        }

        /// <summary>
        /// Gets a <see cref="ListView"/> this handler provides the implementation for.
        /// </summary>
        public new ListView Control => (ListView)base.Control;

        public ListViewHitTestInfo HitTest(PointD point)
        {
            var result = NativeControl.ItemHitTest(point);
            if (result == IntPtr.Zero)
                throw new Exception();

            try
            {
                var itemIndex = NativeControl.GetHitTestResultItemIndex(result);
                var columnIndex = NativeControl.GetHitTestResultColumnIndex(result);

                var item = itemIndex == -1 ? null : Control.Items[(int)itemIndex];
                var cell = item == null || columnIndex == -1 ? null :
                    item.Cells[(int)columnIndex];
                var location =
                    (ListViewHitTestLocations)NativeControl
                        .GetHitTestResultLocations(result);

                return new ListViewHitTestInfo(location, item, cell);
            }
            finally
            {
                NativeControl.FreeHitTestResult(result);
            }
        }

        public void BeginLabelEdit(long itemIndex) =>
            NativeControl.BeginLabelEdit(itemIndex);

        public RectD GetItemBounds(
            long itemIndex,
            ListViewItemBoundsPortion portion) =>
            NativeControl.GetItemBounds(
                itemIndex,
                (Native.ListViewItemBoundsPortion)portion);

        public void Clear()
        {
            clearing++;
            try
            {
                NativeControl.Clear();
                Control.Items.Clear();
                Control.Columns.Clear();
            }
            finally
            {
                clearing--;
            }
        }

        public void EnsureItemVisible(long itemIndex) =>
            NativeControl.EnsureItemVisible(itemIndex);

        public void SetColumnWidth(
            long columnIndex,
            double width,
            ListViewColumnWidthMode widthMode)
        {
            NativeControl.SetColumnWidth(
                columnIndex,
                width,
                (Native.ListViewColumnWidthMode)widthMode);
        }

        public void SetColumnTitle(long columnIndex, string title)
        {
            NativeControl.SetColumnTitle(columnIndex, title);
        }

        public void SetItemText(long itemIndex, long columnIndex, string text)
        {
            NativeControl.SetItemText(itemIndex, columnIndex, text);
        }

        public void SetItemImageIndex(
            long itemIndex,
            long columnIndex,
            int? imageIndex)
        {
            NativeControl.SetItemImageIndex(itemIndex, columnIndex, imageIndex ?? -1);
        }

        internal override Native.Control CreateNativeControl()
        {
            return new Native.ListView();
        }

        protected override void OnAttach()
        {
            base.OnAttach();

            ApplyItems();
            ApplyView();
            ApplySmallImageList();
            ApplyLargeImageList();
            ApplySelectionMode();
            ApplySelection();

            Control.Items.ItemInserted += Items_ItemInserted;
            Control.Items.ItemRemoved += Items_ItemRemoved;
            Control.Columns.ItemInserted += Columns_ItemInserted;
            Control.Columns.ItemRemoved += Columns_ItemRemoved;
            Control.ViewChanged += Control_ViewChanged;
            Control.SmallImageListChanged += Control_SmallImageListChanged;
            Control.LargeImageListChanged += Control_LargeImageListChanged;
            Control.SelectionModeChanged += Control_SelectionModeChanged;

            Control.SelectionChanged += Control_SelectionChanged;

            NativeControl.SelectionChanged = NativeControl_SelectionChanged;
            NativeControl.ColumnClick += NativeControl_ColumnClick;
            NativeControl.BeforeItemLabelEdit += NativeControl_BeforeItemLabelEdit;
            NativeControl.AfterItemLabelEdit += NativeControl_AfterItemLabelEdit;
            NativeControl.ControlRecreated = NativeControl_ControlRecreated;
        }

        protected override void OnDetach()
        {
            Control.Items.ItemInserted -= Items_ItemInserted;
            Control.Items.ItemRemoved -= Items_ItemRemoved;
            Control.ViewChanged -= Control_ViewChanged;
            Control.Columns.ItemInserted -= Columns_ItemInserted;
            Control.Columns.ItemRemoved -= Columns_ItemRemoved;
            Control.SmallImageListChanged -= Control_SmallImageListChanged;
            Control.LargeImageListChanged -= Control_LargeImageListChanged;
            Control.SelectionModeChanged -= Control_SelectionModeChanged;

            Control.SelectionChanged -= Control_SelectionChanged;

            NativeControl.SelectionChanged = null;
            NativeControl.ColumnClick -= NativeControl_ColumnClick;
            NativeControl.BeforeItemLabelEdit -= NativeControl_BeforeItemLabelEdit;
            NativeControl.AfterItemLabelEdit -= NativeControl_AfterItemLabelEdit;
            NativeControl.ControlRecreated = null;

            base.OnDetach();
        }

        private void NativeControl_ControlRecreated()
        {
            NativeControl.BeginUpdate();
            ApplyColumns();
            ApplyItems();
            ApplySelection();
            NativeControl.EndUpdate();
        }

        private void NativeControl_BeforeItemLabelEdit(
            object? sender,
            Native.NativeEventArgs<Native.ListViewItemLabelEditEventData> e)
        {
            var ea = new ListViewItemLabelEditEventArgs(
                e.Data.itemIndex,
                e.Data.editCancelled ? null : e.Data.label);
            Control.RaiseBeforeLabelEdit(ea);
            e.Result = ea.Cancel ? (IntPtr)1 : IntPtr.Zero;
        }

        private void NativeControl_AfterItemLabelEdit(
            object? sender,
            Native.NativeEventArgs<Native.ListViewItemLabelEditEventData> e)
        {
            var ea = new ListViewItemLabelEditEventArgs(
                e.Data.itemIndex,
                e.Data.editCancelled ? null : e.Data.label);

            Control.RaiseAfterLabelEdit(ea);

            if (!e.Data.editCancelled && !ea.Cancel)
            {
                /*skipSetItemText = true;*/
                Control.Items[(int)e.Data.itemIndex].Text = e.Data.label;
                /*skipSetItemText = false;*/
            }

            e.Result = ea.Cancel ? (IntPtr)1 : IntPtr.Zero;
        }

        private void NativeControl_ColumnClick(
            object? sender,
            Native.NativeEventArgs<Native.ListViewColumnEventData> e)
        {
            Control.RaiseColumnClick(new ListViewColumnEventArgs(e.Data.columnIndex));
        }

        private void Control_ViewChanged(object? sender, EventArgs e)
        {
            ApplyView();
        }

        private void Control_SmallImageListChanged(object? sender, EventArgs e)
        {
            ApplySmallImageList();
        }

        private void Control_LargeImageListChanged(object? sender, EventArgs e)
        {
            ApplyLargeImageList();
        }

        private void NativeControl_SelectionChanged()
        {
            if (applyingSelection > 0)
                return;

            ReceiveSelection();
        }

        private void Control_SelectionChanged(object? sender, EventArgs e)
        {
            if (receivingSelection > 0)
                return;

            ApplySelection();
        }

        private void Control_SelectionModeChanged(object? sender, EventArgs e)
        {
            ApplySelectionMode();
        }

        private void ApplySelectionMode()
        {
            NativeControl.SelectionMode =
                (Native.ListViewSelectionMode)Control.SelectionMode;
        }

        private void ApplySelection()
        {
            applyingSelection++;

            try
            {
                var nativeControl = NativeControl;
                nativeControl.ClearSelected();

                var control = Control;
                var indices = control.SelectedIndices;

                for (var i = 0; i < indices.Count; i++)
                    NativeControl.SetSelected(indices[i], true);
            }
            finally
            {
                applyingSelection--;
            }
        }

        private void ReceiveSelection()
        {
            receivingSelection++;

            try
            {
                Control.SelectedIndicesAreDirty();
            }
            finally
            {
                receivingSelection--;
            }
        }

        private void ApplyView()
        {
            NativeControl.CurrentView = (Native.ListViewView)Control.View;
        }

        private void ApplySmallImageList()
        {
            NativeControl.SmallImageList = (UI.Native.ImageList?)Control.SmallImageList?.Handler;
        }

        private void ApplyLargeImageList()
        {
            NativeControl.LargeImageList = (UI.Native.ImageList?)Control.LargeImageList?.Handler;
        }

        private void ApplyItems()
        {
            var nativeControl = NativeControl;
            nativeControl.ClearItems();

            var control = Control;
            var items = control.Items;

            for (var itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var item = control.Items[itemIndex];
                InsertItem(itemIndex, item);
            }
        }

        private void InsertItem(long itemIndex, ListViewItem item)
        {
            item.InternalSetListViewAndIndex(Control, itemIndex);
            for (var columnIndex = 0; columnIndex < item.Cells.Count; columnIndex++)
            {
                var cell = item.Cells[columnIndex];

                int imageIndex;
                if (columnIndex == 0)
                    imageIndex = item.ImageIndex ?? -1;
                else
                    imageIndex = cell.ImageIndex ?? -1;

                NativeControl.InsertItemAt(itemIndex, cell.Text, columnIndex, imageIndex);
            }
        }

        private void Items_ItemInserted(object? sender, int index, ListViewItem item)
        {
            InsertItem(index, item);
            UpdateItemIndices(index + 1);
        }

        private void UpdateItemIndices(int startIndex)
        {
            for (int i = startIndex; i < Control.Items.Count; i++)
                Control.Items[i].InternalSetListViewAndIndex(Control, i);
        }

        private void Items_ItemRemoved(object? sender, int index, ListViewItem item)
        {
            if (clearing == 0)
                NativeControl.RemoveItemAt(index);
            item.InternalSetListViewAndIndex(null, null);

            UpdateItemIndices(index);
        }

        private void ApplyColumns()
        {
            for (int i = 0; i < Control.Columns.Count; i++)
            {
                var col = Control.Columns[i];
                NativeControl.InsertColumnAt(
                    i,
                    col.Title,
                    col.Width,
                    (Native.ListViewColumnWidthMode)col.WidthMode);
            }
        }

        private void Columns_ItemInserted(object? sender, int index, ListViewColumn item)
        {
            if (clearing == 0)
            {
                NativeControl.InsertColumnAt(
                    index,
                    item.Title,
                    item.Width,
                    (Native.ListViewColumnWidthMode)item.WidthMode);

                ApplyColumnsChangeToItems();
            }

            item.InternalSetListViewAndIndex(Control, index);
        }

        private void Columns_ItemRemoved(object? sender, int index, ListViewColumn item)
        {
            if (clearing == 0)
            {
                NativeControl.RemoveColumnAt(item.Index ?? throw new Exception());
                ApplyColumnsChangeToItems();
            }

            item.InternalSetListViewAndIndex(null, null);
        }

        private void ApplyColumnsChangeToItems()
        {
            foreach (var item in Control.Items)
                item.ApplyColumns();
        }
    }
}