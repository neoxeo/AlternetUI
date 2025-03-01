using System;
using Alternet.Base.Collections;

namespace Alternet.UI
{
    internal class MenuItemHandler
        : WxControlHandler<MenuItem, Native.MenuItem>, IMenuItemHandler
    {
        public MenuItemHandler()
        {
        }

        internal static IntPtr GetMenuHandle(IControl control)
        {
            var ncontrol = (UI.Native.Menu)control.NativeControl;
            return ncontrol.MenuHandle;
        }

        internal Native.Menu EnsureNativeSubmenuCreated()
        {
            if (NativeControl.Submenu == null)
            {
                NativeControl.Submenu = new Native.Menu();
                NativeControl.Submenu.OwnerHandler = this;
            }

            return NativeControl.Submenu;
        }

        internal override Native.Control CreateNativeControl()
        {
            return new Native.MenuItem();
        }

        protected override void OnDetach()
        {
            base.OnDetach();

            if (Control is null)
                return;
            Control.CheckedChanged -= Control_CheckedChanged;
            Control.TextChanged -= Control_TextChanged;
            Control.ShortcutChanged -= Control_ShortcutChanged;
            Control.RoleChanged -= Control_RoleChanged;
            Control.ImageChanged -= Control_ImageChanged;
            Control.DisabledImageChanged -= Control_DisabledImageChanged;
            Control.Items.ItemInserted -= Items_ItemInserted;
            Control.Items.ItemRemoved -= Items_ItemRemoved;
        }

        protected override void OnAttach()
        {
            base.OnAttach();

            if (Control is null)
                return;
            ApplyText();
            ApplyChecked();
            ApplyItems();
            ApplyShortcut();
            ApplyRole();
            ApplyImage();
            ApplyDisabledImage();

            Control.TextChanged += Control_TextChanged;
            Control.CheckedChanged += Control_CheckedChanged;
            Control.ShortcutChanged += Control_ShortcutChanged;
            Control.RoleChanged += Control_RoleChanged;
            Control.ImageChanged += Control_ImageChanged;
            Control.DisabledImageChanged += Control_DisabledImageChanged;

            Control.Items.ItemInserted += Items_ItemInserted;
            Control.Items.ItemRemoved += Items_ItemRemoved;
        }

        private void ApplyDisabledImage()
        {
            if (Control is null)
                return;
            var image = Control.GetRealImage(VisualControlState.Disabled);
            NativeControl.DisabledImage = (UI.Native.ImageSet?)image?.Handler;
        }

        private void ApplyImage()
        {
            if (Control is null)
                return;
            var image = Control.GetRealImage(VisualControlState.Normal);
            NativeControl.NormalImage = (UI.Native.ImageSet?)image?.Handler;
        }

        private void Control_DisabledImageChanged(object? sender, EventArgs e)
        {
            ApplyDisabledImage();
        }

        private void Control_ImageChanged(object? sender, EventArgs e)
        {
            ApplyImage();
        }

        private void Control_RoleChanged(object? sender, EventArgs e)
        {
            ApplyRole();
        }

        private void Control_ShortcutChanged(object? sender, EventArgs e)
        {
            ApplyShortcut();
        }

        private void Control_CheckedChanged(object? sender, EventArgs e)
        {
            ApplyChecked();
        }

        private void ApplyItems()
        {
            if (Control is null)
                return;
            for (var i = 0; i < Control.Items.Count; i++)
                InsertItem(Control.Items[i], i);
        }

        private void ApplyText()
        {
            if (Control is null)
                return;
            NativeControl.Text = Control.Text;
        }

        private void ApplyShortcut()
        {
            if (Control is null)
                return;
            if (!Control.IsShortcutEnabled)
            {
                NativeControl.SetShortcut(Key.None, ModifierKeys.None);
                return;
            }

            var shortcut = Control.Shortcut;

            Key key;
            ModifierKeys modifierKeys;

            if (shortcut == null)
            {
                key = Key.None;
                modifierKeys = ModifierKeys.None;
            }
            else
            {
                key = shortcut.Key;
                modifierKeys = shortcut.Modifiers;
            }

            NativeControl.SetShortcut(key, modifierKeys);
        }

        private void ApplyRole()
        {
            if (Control is null)
                return;
            NativeControl.Role = Control.Role?.Name ?? string.Empty;
        }

        private void ApplyChecked()
        {
            if (Control is null)
                return;
            NativeControl.Checked = Control.Checked;
        }

        private void Items_ItemInserted(object? sender, int index, MenuItem item)
        {
            InsertItem(item, index);
        }

        private void Items_ItemRemoved(object? sender, int index, MenuItem item)
        {
            (NativeControl.Submenu ?? throw new Exception()).RemoveItemAt(index);
        }

        private void InsertItem(MenuItem item, int index)
        {
            if (item.Handler is not MenuItemHandler handler)
                throw new InvalidOperationException();

            EnsureNativeSubmenuCreated().InsertItemAt(index, handler.NativeControl);
        }

        private void Control_TextChanged(object? sender, EventArgs e)
        {
            ApplyText();
        }

        protected override void DisposeManaged()
        {
            if(NativeControl.Submenu is not null)
            {
                NativeControl.Submenu.OwnerHandler = null;
            }

            base.DisposeManaged();
        }
    }
}