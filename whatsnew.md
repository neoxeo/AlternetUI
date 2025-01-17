# 0.9.703 (2025 January 17)

- PanelSettings control is finished.
- ControlAndLabel: LabelToControl property which allow to specify horizontal or vertical layout between label and control.
- Return ICommandSource.CommandTarget and add Command.CurrentTarget property.
- Create FontComboBox, PanelListBoxAndCards.
- Maui: Add CheckBoxWithLabelView.
- Maui: Update to the new nuget versions.
- Maui: Update used WinRT version.
- Clipboard: Flush, HasFormat.
- IDataObject.HasFormat.
- ListControlItem: TextHasBold, SetLabelFlag.
- Fixed VirtualListBox.FindFirstVisibleFromLast for 0 item.
- PictureBox: IsImageCentered, GetImagePreferredSize().
- ColorComboBox and ColorListBox: Value property setter is fixed. Find(Color? value) method is fixed.
- Fixed some issues in scroll layout.
- PanelSettings: Color value editors.
- PanelSettings: Fixed text and selector editor creation.
- Set HorizontalAlignment = Left in constructor for some controls.
- Clipboard formats handling improvement.
- Clipboard: Fixed exception macos.
- Calendar: Added update theme after handle created.
- PopupCalendar: more correct initial size.
- PopupWindow: By default title bar made visible as allows to move popup.
- TabControl: Fixed not to create invisible pages on dispose.
- Border.ResetBorders(), ScrollViewer.CreateWithChild.
- Control: Fixed MinimumSize, MaximumSize setters.
- Redo native controls events handling.
- List editor now is non-modal.
- BaseComponent merged into FrameworkElement.

# 0.9.702 (2025 January 12)

- VirtualListBox: Fixed not repatined after EndUpdate in some cases.
- VirtualListBox: Fixed some selection related bugs.
- VirtualListBox: Added RemoveSelectedAndUpdateSelection, SelectItemsAndScroll, SelectLastItemAndScroll.
- VirtualListBox: Redo EnsureVisible internally without using native control.
- Add SystemColorsLight and used them in Calendar and PlessSystemColors. SystemColorsLight contains predefined RGB values for system colors when light theme is selected.
- ObjectUniqueId: precalculate HashCode.
- IndexedValues.GetLockedItemCached.
- ListControlItem: Selected state is saved per container.
- Exclude invisible on screen controls from TAB traversal.
- Set CanSelect and TabStop in constructor for some controls.
- TextBox: Fixed WantTab behavior.
- Fixed Tab traversal behavior.
- Fixed: Invisible controls don't receive key down anymore.
- ColorComboBox: Fixed colors were not filled by default.
- RichToolTip: redesigned to work without creating internal controls.
- Demo: Return design corners to PropertyGrid sample.
- RichToolTip: ToolTipAlignment, ToolTipHorizontalAlignment,  ToolTipVerticalAlignment.
- RichToolTip: ToolTipVisibleChanged event.
- RichToolTip is now derived from ScrollViewer and can be scrollable.
- Improved exception handling. Stack frame is now correctly shown for the exceptions raised in the library.
- UnhandledExceptionMode: CatchWithDialog, CatchWithDialogAndThrow, CatchWithThrow.
- Create focus event arguments and pass them to GorFocus and LostFocus events.
- Maui: Fixed AbstractControl.FocusedControl behavior.
- Maui: OnHandleCreated and OnHandleDestroyed are called by ControlView.
- Maui: Maui: Clipboard now keeps non text data.
- Set ParentBackColor/ParentForeColor = true in constructor for different panel like controls.
- Create ErrorPictureBox, ComboBoxAndButton, BaseEventArgsWithAttr.
- Fixed ParentBackColor and ParentForeColor behavior.
- Fixed layout when LayoutStyle.Scroll.
- ListControlItem.ImageIndex, AbstractControl.GetErrorsCollection.
- Clipboard: Fix to allow SetData for multiple formats in the same DataObject.
- UnmanagedDataObjectAdapter: Do not raise exception on unknown data formats.
- Add PanelSettings control (unfinished).
- TextBox.TextAlign type changed to TextHorizontalAlignment.
- ControlAndButton: TextChanged, DelayedTextChanged events.
- ComboBoxAndLabel.SelectedIndexChanged event.
- ControlAndLabel: TextChanged, DelayedTextChanged events.
- BaseException: Tag, IntFlags, IntFlagsAndAttributes, FlagsAndAttributes, CustomFlags, CustomAttr.
- App.LogError: Fixed behavior in case when parameters is null.

# 0.9.701 (2025 January 8)

- ListBox and CheckListBox are now derived from VirtualListBox. As a result they work much faster with large number of items and has less platform specific problems.
- VirtualListBox: Optimized operations inside BeginUpdate/EndUpdate. As a result Items.AddRange and other operations works much faster.
- VirtualListBox: Fixed incorrect measure item in some cases. Implement more features internally without using platform control. Add FindAndSelect method. Ctrl+A select all items in the multuselect mode.
- VirtualListBox: Implement selection internally without using platform control.
- VirtualListBox: Fixed SelectedIndex prop setter.
- RichToolTip: Message can be multiline and is word wrapped now.
- ListControlItem: SvgImageWidth, SvgImageHeight, HorizontalAlignment, VerticalAlignment.
- CharValidator: Fix didn't allow Delete key on Linux.
- KnownSvgImages: ImgSearch, Search.
- Add classes: EmptyTextHints.
- PictureBox: Fixed GetPreferredSize.
- ControlAndButton.IsButtonLeft.
- TextBoxAndButton: InitFilterEdit, InitSearchEdit, SetSingleButton.
- TextBoxAndButton: Removed InitErrorAndBorder as we have InnerOuterBorder.
- ControlAndLabel: Do not create error picture if not requested.
- TextBoxAndLabel.AutoShowError.
- CustomTextBox: use idle event for errorPicture show.
- Use DisposingOrDisposed in some controls for more safety.
- CharValidator.AlwaysValidControlChars, AbstractControl.IgnoreCharValidator.
- Value editors: set UseCharValidator = false by default.
- Collection editor: Fixed look on Linux. Updated to work with new ListBox and CheckListBox. Allows to specify item attributes (like color, font, etc.) for list controls. Added reload of all properties after value is edited in PropertyGrid.
- ThreadExceptionWindow: Do not show label about 'Quit' button if it is hidden. Show BaseException.AdditionalInformation if it is specified.
- Calendar: MarkAll, ResetAttrAll, DefaultUseGeneric, SetColorThemeToLight, SetThemeInConstructor, DefaultShowWeekNumbers, DefaultSequentalMonthSelect, DefaultShowHolidays.
- WindowSizeToContentMode: new enum members.
- WindowWebBrowserSearch: Fixed search behavior.
- ToolbarSet: Fixed layout when HasBorder = true.
- Toolbar: AddRightSpeedBtn, AddSpeedBtnCore (many overloads with diff params).
- FindReplaceControl: Fix layout, add OptionsVisible, ToggleReplaceVisible.
- ImmutableObject: IsPropertyChangedSuspended, SuspendPropertyChanged, ResumePropertyChanged, DoInsideSuspendedPropertyChanged.
- ScrollBar: setter for PosInfo property.
- ScrollBar.PositionInfo: Assign, Record.
- CardPanelItem: SupressException, DefaultSupressException.
- UIXmlLoader: better error handling when uixml is loaded.
- Fixed Control.ClientSize setter so it uses minimum and maximum sizes.
- AbstractControl: Do not layout if added/removed control is hidden or ignored in layout.
- LogUtils: Better exception logging.
- Fixed AbstractControl.ChildrenLayoutBounds.
- Fix exception on app exit in some cases.

# 0.9.700 (2025 January 1)

Summary:

- AlterNET UI now supports .NET 9, MAUI 9, and SkiaSharp 3.
- Improved MAUI support across the library alongside with WxWidgets.
- New controls: TextBoxAndButton (TextBox with buttons and image on the right side), RichToolTip (reimplemented inside the library), PopupControl (popups inside the parent control), and others.
- Generic controls (can be used as parts of native controls and are handled internally in the library without operating system resources allocation) and Template controls that can be rendered to Graphics or Bitmap.
- VirtualListView: Improved painting in owner-draw mode, with different methods for thread-safe operations that allow fast loading of a large number of items.

More details:

## CONTROLS AND WINDOWS

- Window and its descendants can be created and used as controls. We have added additional constructors and static CreateAs method with WindowKind parameter, which can override window kind. For example, this technology allows inserting a window as a child of another window or control. 
- Separated platform control from abstract control. So now we have AbstractControl and GenericControl, which are not bound to the OS control.
- Control now notifies subscribers (GlobalNotifications and Notifications properties) about its events. You can use AddGlobalNotification, RemoveGlobalNotification, AddNotification, and RemoveNotification methods to register/unregister for notifications.
- Moved InputBindings property and related methods from Window to AbstractControl to specify input bindings for any control.
- Improved FrameworkElement (the parent class of the control) made it much simpler and more efficient.
- Dispose is now called for all child controls.
- DelayedTextChanged and DelayedSelectionChanged events allow for the implementation of more user-friendly applications.
- Simplify and speed up native keyboard, mouse, and application events. Optimize scroll notifications.

## NEW FEATURES IN CONTROLS

- Many controls are now derived from Border, so it is possible to specify custom borders with any color and width.
- Command and CommandParameter properties are added to different controls, so now it�s possible to specify ICommand (or its name) in the UIXML, and the command will be executed. We have added a NamedCommand class, which handles command execution.
- The new CharValidator property is implementing character validation on the input.
- TextBox new feature: Use events and/or type converter for text to/from value conversion.
- Improved ComboBox and VirtualListView painting in owner-draw mode.
- VirtuaListBox now has methods that allow loading items to the control very fast. Additionally, there are methods that can load items from another thread.
- All controls have many new properties and methods.

## LAYOUT

- Stack layout bug fixes. Also added support for HorizontalLayout.Fill when Layout = Horizontal.
- LayoutStyle.Scroll - The new control layout style is as in ScrollViewer.
- PerformLayout method speed optimization.
- ScrollViewer: Fixed incorrect layout in some cases.

## NEW CONTROLS

- New ControlAndButton and TextBoxAndButton controls. They have unlimited buttons and an optional error image on the right side of the control.
- RichToolTip completely reimplemented. Now, it is derived from Control and shows tooltips inside itself. It supports showing tooltips with images only (without title and message text).
- Added control templates painting. Related classes: TemplateControl, TemplateUtils, TemplateControls.
- Created PopupControl - Allows popups inside the client area of the parent control.

## NEW LIBRARIES

- .Net 9 support added
- AlterNET UI updated to use the latest WxWidgets 3.2.6.
- WebBrowser control now uses the newest Edge library.
- MAUI 9 is now used.
- SkiaSharp 3 is now used, as the previous version had MAUI-related issues introduced by the latest Visual Studio update.
- NuGet packages used in the library are updated to the latest versions.

## MAUI

- Optimized control painting and caret movement.
- Scrollbars are now painted in the ControlView.
- SkiaGraphics: Implemented some of the drawing methods that were not previously implemented.
- SVG images are now supported.

## CLASSES

- AdvDictionary is now derived from ConcurrentDictionary.
- PlessVariant struct made public. It implements a variant structure that can contain data of different types.
- IndexedValues - a fast and simple container for the index/value pairs.
- Optimized FlagsAndAttributes.
- New base classes: BaseObjectWithAttr and BaseObjectWithId. Most of the other classes are derived from them.

## GRAPHICS

- The DrawLabel method has been completely rewritten to support additional features.
- New DrawElements, DrawTextWithBoldTags, and DrawTextWithFontStyle methods.
- RequireMeasure - fast methods to get text measure canvas.
- Color now has a virtual method to get ARGB, which allows the implementation of color themes in the application.
- DrawText method now includes the TextFormat parameter. It has been completely rewritten and is now not specific to WxWidgets as it was implemented inside the library.
- Transform and HasTransform properties have been optimized

## CROSS-PLATFORM

- Added iOS, Android, and MacCatalyst to TargetFrameworks of MAUI-related libraries and projects.
- Fixed installation on macOS Sonoma and newer versions.
- Fixed caret behavior on Linux and macOS.

---

Older items can be found [here](Documents/Whatsnew.History/whatsnew-2024.md)