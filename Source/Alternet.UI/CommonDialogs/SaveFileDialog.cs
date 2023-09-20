using System;

namespace Alternet.UI
{
    /// <summary>
    /// Prompts the user to select a location for saving a file.
    /// </summary>
    [ControlCategory("Dialogs")]
    public class SaveFileDialog : FileDialog
    {
        private protected override Native.FileDialogMode Mode => Native.FileDialogMode.Save;
    }
}