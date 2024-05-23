﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alternet.Drawing;
using Alternet.Drawing.Printing;

namespace Alternet.UI
{
    public class MauiApplicationHandler : DisposableObject, IApplicationHandler
    {
        /// <inheritdoc/>
        public bool ExitOnFrameDelete
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool IsActive
        {
            get => throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool InUixmlPreviewerMode
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool InvokeRequired
        {
            get => throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IPenHandler CreatePenHandler(Pen pen)
        {
            return new MauiPenHandler(pen);
        }

        /// <inheritdoc/>
        public IFontFactoryHandler CreateFontFactoryHandler()
        {
            return new MauiFontFactoryHandler();
        }

        /// <inheritdoc/>
        public IBrushHandler CreateTransparentBrushHandler(Brush brush)
        {
            return new MauiTransparentBrushHandler(brush);
        }

        /// <inheritdoc/>
        public ISolidBrushHandler CreateSolidBrushHandler(SolidBrush brush)
        {
            return new MauiSolidBrushHandler(brush);
        }

        /// <inheritdoc/>
        public IHatchBrushHandler CreateHatchBrushHandler(HatchBrush brush)
        {
            return new MauiHatchBrushHandler(brush);
        }

        /// <inheritdoc/>
        public ILinearGradientBrushHandler CreateLinearGradientBrushHandler(LinearGradientBrush brush)
        {
            return new MauiLinearGradientBrushHandler(brush);
        }

        /// <inheritdoc/>
        public IRadialGradientBrushHandler CreateRadialGradientBrushHandler(RadialGradientBrush brush)
        {
            return new MauiRadialGradientBrushHandler(brush);
        }

        /// <inheritdoc/>
        public void ExitMainLoop()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public ITextureBrushHandler CreateTextureBrushHandler(TextureBrush brush)
        {
            return new MauiTextureBrushHandler(brush);
        }

        /// <inheritdoc/>
        public void ProcessPendingEvents()
        {
            throw new NotImplementedException();
        }

        public Window? GetActiveWindow()
        {
            throw new NotImplementedException();
        }

        public Control? GetFocusedControl()
        {
            throw new NotImplementedException();
        }

        public void NotifyCaptureLost()
        {
            throw new NotImplementedException();
        }

        public ISelectDirectoryDialogHandler CreateSelectDirectoryDialogHandler(SelectDirectoryDialog dialog)
        {
            throw new NotImplementedException();
        }

        public IOpenFileDialogHandler CreateOpenFileDialogHandler(OpenFileDialog dialog)
        {
            throw new NotImplementedException();
        }

        public ISaveFileDialogHandler CreateSaveFileDialogHandler(SaveFileDialog dialog)
        {
            throw new NotImplementedException();
        }

        public IFontDialogHandler CreateFontDialogHandler(FontDialog dialog)
        {
            throw new NotImplementedException();
        }

        public IColorDialogHandler CreateColorDialogHandler(ColorDialog dialog)
        {
            throw new NotImplementedException();
        }

        public IRichTextBoxHandler CreateRichTextBoxHandler(RichTextBox editor)
        {
            throw new NotImplementedException();
        }

        public ISystemSettingsHandler CreateSystemSettingsHandler()
        {
            throw new NotImplementedException();
        }

        public ILinkLabelHandler CreateLinkLabelHandler(LinkLabel control)
        {
            throw new NotImplementedException();
        }

        public IAnimationPlayerHandler CreateAnimationPlayerHandler(AnimationPlayer control)
        {
            throw new NotImplementedException();
        }

        public ICalendarHandler CreateCalendarHandler(Calendar control)
        {
            throw new NotImplementedException();
        }

        public IListViewHandler CreateListViewHandler(ListView control)
        {
            throw new NotImplementedException();
        }

        public IDateTimePickerHandler CreateDateTimePickerHandler(DateTimePicker control)
        {
            throw new NotImplementedException();
        }

        public INumericUpDownHandler CreateNumericUpDownHandler(NumericUpDown control)
        {
            throw new NotImplementedException();
        }

        public IWebBrowserHandler CreateWebBrowserHandler(WebBrowser control)
        {
            throw new NotImplementedException();
        }

        public IWebBrowserFactoryHandler CreateWebBrowserFactoryHandler()
        {
            throw new NotImplementedException();
        }

        public IPropertyGridHandler CreatePropertyGridHandler(PropertyGrid control)
        {
            throw new NotImplementedException();
        }

        public IPropertyGridVariant CreateVariant()
        {
            throw new NotImplementedException();
        }

        public ICheckBoxHandler CreateCheckBoxHandler(CheckBox control)
        {
            throw new NotImplementedException();
        }

        public IButtonHandler CreateButtonHandler(Button control)
        {
            throw new NotImplementedException();
        }

        public IColorPickerHandler CreateColorPickerHandler(ColorPicker control)
        {
            throw new NotImplementedException();
        }

        public ISliderHandler CreateSliderHandler(Slider control)
        {
            throw new NotImplementedException();
        }

        public IProgressBarHandler CreateProgressBarHandler(ProgressBar control)
        {
            throw new NotImplementedException();
        }

        public IGroupBoxHandler CreateGroupBoxHandler(GroupBox control)
        {
            throw new NotImplementedException();
        }

        public IRadioButtonHandler CreateRadioButtonHandler(RadioButton control)
        {
            throw new NotImplementedException();
        }

        public ITextBoxHandler CreateTextBoxHandler(TextBox control)
        {
            throw new NotImplementedException();
        }

        public IComboBoxHandler CreateComboBoxHandler(ComboBox control)
        {
            throw new NotImplementedException();
        }

        public ILabelHandler CreateLabelHandler(Label control)
        {
            throw new NotImplementedException();
        }

        public IScrollBarHandler CreateScrollBarHandler(ScrollBar control)
        {
            throw new NotImplementedException();
        }

        public IMenuItemHandler CreateMenuItemHandler(MenuItem control)
        {
            throw new NotImplementedException();
        }

        public IContextMenuHandler CreateContextMenuHandler(ContextMenu control)
        {
            throw new NotImplementedException();
        }

        public IMainMenuHandler CreateMainMenuHandler(MainMenu control)
        {
            throw new NotImplementedException();
        }

        public IListBoxHandler CreateListBoxHandler(ListBox control)
        {
            throw new NotImplementedException();
        }

        public IWindowHandler CreateWindowHandler(Window window)
        {
            throw new NotImplementedException();
        }

        public IScrollViewerHandler CreateScrollViewerHandler(ScrollViewer control)
        {
            throw new NotImplementedException();
        }

        public ITreeViewHandler CreateTreeViewHandler(TreeView control)
        {
            throw new NotImplementedException();
        }

        public IStatusBarHandler CreateStatusBarHandler(StatusBar control)
        {
            throw new NotImplementedException();
        }

        public IControlHandler CreateControlHandler(Control control)
        {
            return new MauiControlHandler();
        }

        public ICheckListBoxHandler CreateCheckListBoxHandler(CheckListBox control)
        {
            throw new NotImplementedException();
        }

        public IVListBoxHandler CreateVListBoxHandler(VListBox control)
        {
            throw new NotImplementedException();
        }

        public IPropertyGridChoices CreateChoices()
        {
            throw new NotImplementedException();
        }

        public IPrintDocumentHandler CreatePrintDocumentHandler()
        {
            throw new NotImplementedException();
        }

        public IPrinterSettingsHandler CreatePrinterSettingsHandler()
        {
            throw new NotImplementedException();
        }

        public IPrintDialogHandler CreatePrintDialogHandler()
        {
            throw new NotImplementedException();
        }

        public IPageSettingsHandler CreatePageSettingsHandler()
        {
            throw new NotImplementedException();
        }

        public IValueValidatorText CreateValueValidatorText(ValueValidatorTextStyle style)
        {
            throw new NotImplementedException();
        }

        public IValueValidatorText CreateValueValidatorNum(ValueValidatorNumStyle numericType, int valueBase = 10)
        {
            throw new NotImplementedException();
        }

        public IPageSetupDialogHandler CreatePageSetupDialogHandler()
        {
            throw new NotImplementedException();
        }

        public IPrintPreviewDialogHandler CreatePrintPreviewDialogHandler()
        {
            throw new NotImplementedException();
        }

        public IRichToolTipHandler CreateRichToolTipHandler(string title, string message, bool useGeneric)
        {
            throw new NotImplementedException();
        }

        public ISoundFactoryHandler CreateSoundFactoryHandler()
        {
            throw new NotImplementedException();
        }

        public ITimerHandler CreateTimerHandler(Timer timer)
        {
            throw new NotImplementedException();
        }

        public void Run(Window window)
        {
            throw new NotImplementedException();
        }

        public void SetTopWindow(Window window)
        {
            throw new NotImplementedException();
        }

        public void WakeUpIdle()
        {
            throw new NotImplementedException();
        }

        public void BeginInvoke(Action action)
        {
            throw new NotImplementedException();
        }

        public bool HasPendingEvents()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
