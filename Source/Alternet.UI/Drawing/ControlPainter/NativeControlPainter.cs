﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alternet.UI;

namespace Alternet.Drawing
{
    /// <summary>
    /// Draws control parts using native operating system visual style.
    /// </summary>
    public class NativeControlPainter : CustomControlPainter
    {
        /// <summary>
        /// Gets default instance of the <see cref="NativeControlPainter"/>.
        /// </summary>
        public static NativeControlPainter Default = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeControlPainter"/> class.
        /// </summary>
        public NativeControlPainter()
            : base()
        {
        }

        /// <summary>
        /// Control state flags used for control painting.
        /// </summary>
        [Flags]
        public enum DrawFlags
        {
            /// <summary>
            /// Absence of any other flags.
            /// </summary>
            None = 0x00000000,

            /// <summary>
            /// Control is disabled.
            /// </summary>
            Disabled = 0x00000001,

            /// <summary>
            /// Currently has keyboard focus.
            /// </summary>
            Focused = 0x00000002,

            /// <summary>
            /// Button is pressed.
            /// </summary>
            Pressed = 0x00000004,

            /// <summary>
            /// Control-specific bit.
            /// </summary>
            Special = 0x00000008,

            /// <summary>
            /// Only for the buttons.
            /// </summary>
            IsDefault = Special,

            /// <summary>
            /// Only for the menu items.
            /// </summary>
            IsSubMenu = Special,

            /// <summary>
            /// Only for the tree items.
            /// </summary>
            Expanded = Special,

            /// <summary>
            /// Only for the status bar panes.
            /// </summary>
            SizeGrip = Special,

            /// <summary>
            /// Checkboxes only: flat border.
            /// </summary>
            Flat = Special,

            /// <summary>
            /// Only for item selection rect.
            /// </summary>
            Cell = Special,

            /// <summary>
            /// Mouse is currently over the control.
            /// </summary>
            Current = 0x00000010,

            /// <summary>
            /// Selected item in e.g. ListBox.
            /// </summary>
            Selected = 0x00000020,

            /// <summary>
            /// Check or radio button is checked.
            /// </summary>
            Checked = 0x00000040,

            /// <summary>
            /// Menu item can be checked.
            /// </summary>
            Checkable = 0x00000080,

            /// <summary>
            /// Check undetermined state.
            /// </summary>
            Undetermined = Checkable,
        }

        /// <summary>
        /// Defines buttons that can be shown in the title bar.
        /// </summary>
        [Flags]
        public enum TitleBarButtonFlags
        {
            /// <summary>
            /// Button 'Close' is shown in the title bar.
            /// </summary>
            Close = 0x01000000,

            /// <summary>
            /// Button 'Maximize' is shown in the title bar.
            /// </summary>
            Maximize = 0x02000000,

            /// <summary>
            /// Button 'Iconize' is shown in the title bar.
            /// </summary>
            Iconize = 0x04000000,

            /// <summary>
            /// Button 'Restore' is shown in the title bar.
            /// </summary>
            Restore = 0x08000000,

            /// <summary>
            /// Button 'Help' is shown in the title bar.
            /// </summary>
            Help = 0x10000000,
        }

        /// <summary>
        /// Defines header sort icon types.
        /// </summary>
        public enum HeaderSortIconType
        {
            /// <summary>
            /// Header button has no sort arrow.
            /// </summary>
            None,

            /// <summary>
            /// Header button an up sort arrow icon.
            /// </summary>
            Up,

            /// <summary>
            /// Header button a down sort arrow icon.
            /// </summary>
            Down,
        }

        /// <summary>
        /// Draws the header control button (used, for example, by <see cref="ListView"/> like
        /// controls).
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <param name="sortArrow">Type of the sort icon.</param>
        /// <param name="headerButtonParams">Button parameters.</param>
        /// <returns>
        /// The optimal width to contain the unabbreviated label text or bitmap,
        /// the sort arrow if present, and internal margins.
        /// </returns>
        /// <remarks>
        /// Depending on platforms the flags parameter may support the
        /// <see cref="DrawFlags.Selected"/>, <see cref="DrawFlags.Disabled"/>
        /// and <see cref="DrawFlags.Current"/>.
        /// </remarks>
        public int DrawHeaderButton(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0,
            HeaderSortIconType sortArrow = HeaderSortIconType.None,
            object? headerButtonParams = null)
        {
            return Alternet.UI.Native.WxOtherFactory.RendererDrawHeaderButton(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags,
                (int)sortArrow,
                default);
        }

        /// <summary>
        /// Draws the contents of a header control button (label, sort arrows, etc.).
        /// Normally only called by <see cref="DrawHeaderButton"/>.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <param name="sortArrow">Type of the sort icon.</param>
        /// <param name="headerButtonParams">Button parameters.</param>
        /// <returns>
        /// The optimal width to contain the unabbreviated label text
        /// or bitmap, the sort arrow if present, and internal margins.
        /// </returns>
        /// <remarks>
        /// The flags parameter may support the
        /// <see cref="DrawFlags.Selected"/>, <see cref="DrawFlags.Disabled"/>
        /// and <see cref="DrawFlags.Current"/>.
        /// </remarks>
        public int DrawHeaderButtonContents(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0,
            HeaderSortIconType sortArrow = HeaderSortIconType.None,
            object? headerButtonParams = null)
        {
            return Alternet.UI.Native.WxOtherFactory.RendererDrawHeaderButtonContents(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags,
                (int)sortArrow,
                default);
        }

        /// <summary>
        /// Draws the expanded/collapsed icon for a tree control item.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        public void DrawTreeItemButton(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawTreeItemButton(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws the border for sash window: this border must be such that the sash
        /// drawn by <see cref="DrawSplitterSash"/> blends into it well.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        public void DrawSplitterBorder(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawSplitterBorder(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws a combobox dropdown button.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <remarks>
        /// The flags parameter may support the
        /// <see cref="DrawFlags.Pressed"/> and <see cref="DrawFlags.Current"/>.
        /// </remarks>
        public void DrawComboBoxDropButton(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawComboBoxDropButton(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws a dropdown arrow.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <remarks>
        /// The flags parameter may support the
        /// <see cref="DrawFlags.Pressed"/> and <see cref="DrawFlags.Current"/>.
        /// </remarks>
        public void DrawDropArrow(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawDropArrow(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws check button.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <remarks>
        /// The flags parameter may support the
        /// <see cref="DrawFlags.Checked"/>, <see cref="DrawFlags.Undetermined"/>
        /// and <see cref="DrawFlags.Current"/>.
        /// </remarks>
        public void DrawCheckBox(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawCheckBox(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws check mark.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <remarks>
        /// The flags parameter may support the
        /// <see cref="DrawFlags.Disabled"/>.
        /// </remarks>
        public void DrawCheckMark(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawCheckMark(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws blank button.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <remarks>
        /// The flags parameter may support the
        /// <see cref="DrawFlags.Pressed"/>, <see cref="DrawFlags.IsDefault"/>
        /// and <see cref="DrawFlags.Current"/>.
        /// </remarks>
        public void DrawPushButton(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawPushButton(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws collapse button.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <remarks>
        /// The flags parameter may support the
        /// <see cref="DrawFlags.Checked"/>, <see cref="DrawFlags.Undetermined"/>
        /// and <see cref="DrawFlags.Current"/>.
        /// </remarks>
        public void DrawCollapseButton(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawCollapseButton(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws rectangle indicating that an item in e.g. a list control
        /// has been selected or focused.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <remarks>
        /// The flags parameter may support the
        /// <see cref="DrawFlags.Selected"/> (item is selected, e.g. draw background),
        /// <see cref="DrawFlags.Focused"/> (the whole control has focus,
        /// e.g. blue background vs. grey otherwise)
        /// and <see cref="DrawFlags.Current"/> (item is the current item, e.g. dotted border).
        /// </remarks>
        public void DrawItemSelectionRect(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawItemSelectionRect(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws the focus rectangle around the label contained in the given rect.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <remarks>
        /// Only <see cref="DrawFlags.Selected"/> makes sense in flags here.
        /// </remarks>
        public void DrawFocusRect(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawFocusRect(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws a native choice control.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        public void DrawChoice(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawChoice(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws a native <see cref="ComboBox"/> frame.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        public void DrawComboBox(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawComboBox(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws a native <see cref="TextBox"/> frame.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        public void DrawTextCtrl(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawTextCtrl(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws a native <see cref="RadioButton"/> bitmap.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        public void DrawRadioBitmap(
            Control control,
            Graphics dc,
            RectD rect,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawRadioBitmap(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                (int)flags);
        }

        /// <summary>
        /// Draws a gauge with native style.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <param name="value">Current value.</param>
        /// <param name="max">Maximal value.</param>
        /// <remarks>
        /// <see cref="DrawFlags.Special"/> flag must be used for drawing vertical gauges.
        /// </remarks>
        public void DrawGauge(
            Control control,
            Graphics dc,
            RectD rect,
            int value,
            int max,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawGauge(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(rect),
                value,
                max,
                (int)flags);
        }

        /// <summary>
        /// Draws text using the appropriate color for normal and selected states.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="rect">Rectangle in which control is painted.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <param name="text">Text to draw.</param>
        /// <param name="align">Text alignment.</param>
        /// <param name="ellipsizeMode">Text ellipsize mode.</param>
        public void DrawItemText(
            Control control,
            Graphics dc,
            string text,
            RectD rect,
            GenericAlignment align = GenericAlignment.Left | GenericAlignment.Top,
            DrawFlags flags = 0,
            TextEllipsizeType ellipsizeMode = TextEllipsizeType.End)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawItemText(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                text,
                control.PixelFromDip(rect),
                (int)align,
                (int)flags,
                (int)ellipsizeMode);
        }

        /// <summary>
        /// Returns the default size of a check box in dips.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <returns></returns>
        /// <remarks>
        /// The only acceptable flag is <see cref="DrawFlags.Cell"/> which means that just the
        /// size of the checkbox itself is returned, without any margins that are
        /// included by default.
        /// </remarks>
        public SizeD GetCheckBoxSize(Control control, DrawFlags flags = 0)
        {
            var result = Alternet.UI.Native.WxOtherFactory.RendererGetCheckBoxSize(
                default,
                control.WxWidget,
                (int)flags);
            return control.PixelToDip(result);
        }

        /// <summary>
        /// Returns the default size of a check mark in dips.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <returns></returns>
        public SizeD GetCheckMarkSize(Control control)
        {
            var result = Alternet.UI.Native.WxOtherFactory.RendererGetCheckMarkSize(
                default,
                control.WxWidget);
            return control.PixelToDip(result);
        }

        /// <summary>
        /// Returns the default size of a expander in dips.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <returns></returns>
        public SizeD GetExpanderSize(Control control)
        {
            var result = Alternet.UI.Native.WxOtherFactory.RendererGetExpanderSize(
                default,
                control.WxWidget);
            return control.PixelToDip(result);
        }

        /// <summary>
        /// Returns the default height of a header button in dips, either a fixed platform
        /// height if available, or a generic height based on the window's font.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <returns></returns>
        public double GetHeaderButtonHeight(Control control)
        {
            var result = Alternet.UI.Native.WxOtherFactory.RendererGetHeaderButtonHeight(
                default,
                control.WxWidget);
            return control.PixelToDip(result);
        }

        /// <summary>
        /// Returns the margin on left and right sides of header button's label in dips.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <returns></returns>
        public double GetHeaderButtonMargin(Control control)
        {
            var result = Alternet.UI.Native.WxOtherFactory.RendererGetHeaderButtonMargin(
                default,
                control.WxWidget);
            return control.PixelToDip(result);
        }

        /// <summary>
        /// Returns the default size of a collapse button in dips.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <returns></returns>
        public SizeD GetCollapseButtonSize(Control control, Graphics dc)
        {
            var result = Alternet.UI.Native.WxOtherFactory.RendererGetCollapseButtonSize(
                default,
                control.WxWidget,
                dc.NativeDrawingContext);
            return control.PixelToDip(result);
        }

        /// <summary>
        /// Draw a (vertical) splitter sash.
        /// </summary>
        /// <param name="control">Control in which drawing will be performed.</param>
        /// <param name="dc">Drawing context.</param>
        /// <param name="flags">Drawing flags.</param>
        /// <param name="size">Splitter sash size.</param>
        /// <param name="position">Splitter position.</param>
        /// <param name="orientation">Defines whether the sash should be vertical or
        /// horizontal and how the position should be interpreted</param>
        public void DrawSplitterSash(
            Control control,
            Graphics dc,
            SizeD size,
            double position,
            GenericOrientation orientation,
            DrawFlags flags = 0)
        {
            Alternet.UI.Native.WxOtherFactory.RendererDrawSplitterSash(
                default,
                control.WxWidget,
                dc.NativeDrawingContext,
                control.PixelFromDip(size),
                control.PixelFromDip(position),
                (int)orientation,
                (int)flags);
        }

        /// <summary>
        /// Gets version of the renderer.
        /// </summary>
        public string GetVersion()
        {
            return Alternet.UI.Native.WxOtherFactory.RendererGetVersion(default);
        }
    }
}
