﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Alternet.Drawing;
using Alternet.UI.Localization;

namespace Alternet.UI
{
    /// <summary>
    /// Contains static methods which call standard dialogs.
    /// </summary>
    public static class DialogFactory
    {
        /// <summary>
        /// Shows developer tools window.
        /// </summary>
        public static void ShowDeveloperTools()
        {
            DeveloperToolsPanel.ShowDeveloperTools();
        }

        /// <summary>
        /// Used as event handler.
        /// </summary>
        /// <param name="sender">Must implement <see cref="IPropInfoAndInstance"/>.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// Calls <see cref="DialogFactory.EditPropertyWithListEditor(object,string)"/> for
        /// the <paramref name="sender"/>,
        /// if it implements <see cref="IPropInfoAndInstance"/> interface.
        /// </remarks>
        public static void EditWithListEdit(object? sender, EventArgs e)
        {
            if (sender is not IPropInfoAndInstance prop)
                return;
            var instance = prop.Instance;
            var propInfo = prop.PropInfo;

            DialogFactory.EditPropertyWithListEditor(instance, propInfo);
        }

        /// <summary>
        /// Edits property with list editor.
        /// </summary>
        /// <param name="instance">Object which contains the property.</param>
        /// <param name="propInfo">Property information.</param>
        /// <remarks>
        /// List editor must support editing of the property.
        /// </remarks>
        /// <returns><c>null</c> if property editing is not supported; <c>true</c> if editing
        /// was performed and user pressed 'Ok' button; <c>false</c> if user pressed
        /// 'Cancel' button.</returns>
        public static bool? EditPropertyWithListEditor(object? instance, PropertyInfo? propInfo)
        {
            PropertyGrid.RegisterCollectionEditors();

            var source = ListEditSource.CreateEditSource(instance, propInfo);
            if (source == null)
                return null;

            using ListEditDialogWindow dialog = new(source);
            var result = dialog.ShowModal(Window.ActiveWindow) == ModalResult.Accepted;
            return result;
        }

        /// <summary>
        /// Edits property with list editor.
        /// </summary>
        /// <param name="instance">Object which contains the property.</param>
        /// <param name="propName">Property name.</param>
        /// <remarks>
        /// List editor must support editing of the property.
        /// </remarks>
        /// <returns><c>null</c> if property editing is not supported; <c>true</c> if editing
        /// was performed and user pressed 'Ok' button; <c>false</c> if user pressed
        /// 'Cancel' button.</returns>
        public static bool? EditPropertyWithListEditor(object? instance, string propName)
        {
            var propInfo = AssemblyUtils.GetPropInfo(instance, propName);
            var result = EditPropertyWithListEditor(instance, propInfo);
            return result;
        }

        /// <summary>
        /// Edits <see cref="ListView.Columns"/> with list editor.
        /// </summary>
        /// <param name="control">Control which columns will be edited.</param>
        public static bool? EditColumnsWithListEditor(ListView control) =>
            EditPropertyWithListEditor(control, nameof(ListView.Columns));

        /// <summary>
        /// Edits <see cref="ListView.Items"/> with list editor.
        /// </summary>
        /// <param name="control">Control which items will be edited.</param>
        public static bool? EditItemsWithListEditor(ListView control) =>
            EditPropertyWithListEditor(control, nameof(ListView.Items));

        /// <summary>
        /// Edits <see cref="StatusBar.Panels"/> with list editor.
        /// </summary>
        /// <param name="control">Control which items will be edited.</param>
        public static bool? EditItemsWithListEditor(StatusBar? control)
        {
            return EditPropertyWithListEditor(control, nameof(StatusBar.Panels));
        }

        /// <summary>
        /// Edits <see cref="TreeView.Items"/> with list editor.
        /// </summary>
        /// <param name="control">Control which items will be edited.</param>
        public static bool? EditItemsWithListEditor(TreeView control) =>
            EditPropertyWithListEditor(control, nameof(TreeView.Items));

        /// <summary>
        /// Edits <see cref="ListControl.Items"/> with list editor.
        /// </summary>
        /// <param name="control">Control which items will be edited.</param>
        public static bool? EditItemsWithListEditor(ListControl control) =>
            EditPropertyWithListEditor(control, nameof(ListControl.Items));
    }
}
