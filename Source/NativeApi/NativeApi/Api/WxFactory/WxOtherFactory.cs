﻿#pragma warning disable
using ApiCommon;
using Alternet.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alternet.Drawing;

namespace NativeApi.Api
{
    // https://docs.wxwidgets.org/3.2/classwx_rich_tool_tip.html
    // https://docs.wxwidgets.org/3.2/classwx_tool_tip.html
    // https://docs.wxwidgets.org/3.2/classwx_display.html
    // https://docs.wxwidgets.org/3.2/classwx_caret.html
    // https://docs.wxwidgets.org/3.2/classwx_cursor.html
    public class WxOtherFactory
    {
        // =================== RichToolTip

        // Ctor must specify the tooltip title and main message, additional
        // attributes can be set later.
        public static IntPtr CreateRichToolTip(string title, string message) => default;
        public static void DeleteRichToolTip(IntPtr handle) { }

        // Set the background color: if two colors are specified, the background
        // is drawn using a gradient from top to bottom, otherwise a single solid
        // color is used.
        public static void RichToolTipSetBkColor(IntPtr handle, Color color, Color endColor) { }

        public static void RichToolTipSetFgColor(IntPtr handle, Color color) { }

        public static void RichToolTipSetTitleFgColor(IntPtr handle, Color color) { }

        public static bool RichToolTipUseGeneric { get; set; }

        // Set the small icon to show: either one of the standard information/
        // warning/error ones(the question icon doesn't make sense for a tooltip)
        // or a custom icon.
        public static void RichToolTipSetIcon(IntPtr handle, ImageSet? bitmapBundle) { }
        public static void RichToolTipSetIcon2(IntPtr handle, int icon) { } // wxICON_* in defs.h

        // Set timeout after which the tooltip should disappear, in milliseconds.
        // By default the tooltip is hidden after system-dependent interval of time
        // elapses but this method can be used to change this or also disable
        // hiding the tooltip automatically entirely by passing 0 in this parameter
        //(but doing this can result in native version not being used).
        // Optionally specify a show delay.
        public static void RichToolTipSetTimeout(IntPtr handle, uint milliseconds,
            uint millisecondsShowdelay = 0)
        { }

        // Choose the tip kind, possibly none. By default the tip is positioned
        // automatically, as if wxTipKind_Auto was used.
        public static void RichToolTipSetTipKind(IntPtr handle, int tipKind) { } // wxTipKind

        // Set the title text font. By default it's emphasized using the font style
        // or colour appropriate for the current platform.
        public static void RichToolTipSetTitleFont(IntPtr handle, Font? font) { }

        // Show the tooltip for the given window and optionally a specified area.
        public static void RichToolTipShowFor(IntPtr handle, IntPtr window, Int32Rect rect) { }

        // =================== ToolTip

        public static IntPtr CreateToolTip(string tip) => default;
        public static void DeleteToolTip(IntPtr handle) { }
        public static string ToolTipGetTip(IntPtr handle) => default;
        public static IntPtr ToolTipGetWindow(IntPtr handle) => default;
        public static void ToolTipSetTip(IntPtr handle, string tip) { }

        // Enable or disable tooltips globally. 
        // May not be supported on all platforms(eg. wxCocoa).
        public static void ToolTipEnable(bool flag) { }

        // Set the delay after which the tooltip disappears or how long a tooltip remains visible. 	
        // May not be supported on all platforms(eg. wxCocoa, GTK).
        public static void ToolTipSetAutoPop(long msecs) { }

        // Set the delay after which the tooltip appears. 
        // May not be supported on all platforms.
        public static void ToolTipSetDelay(long msecs) { }

        // Set tooltip maximal width in pixels. By default, tooltips are wrapped at a suitably
        // chosen width. You can pass -1 as width to disable wrapping them completely,
        // 0 to restore the default behaviour or an arbitrary positive value to wrap
        // them at the given width. Notice that this function does not change the width of
        // the tooltips created before calling it. Currently this function is wxMSW-only.
        public static void ToolTipSetMaxWidth(int width) { }

        // Set the delay between subsequent tooltips to appear. 
        public static void ToolTipSetReshow(long msecs) { }

        // =================== Cursor

        public static IntPtr CreateCursor() => default;

        //ructs a cursor using a cursor identifier.
        public static IntPtr CreateCursor2(int cursorId) => default; // wxStockCursor     

        //ructs a cursor by passing a string resource name or filename.
        public static IntPtr CreateCursor3(string cursorName, int type,
            int hotSpotX = 0, int hotSpotY = 0) => default; // =wxCURSOR_DEFAULT_TYPE

        //ructs a cursor from an image.
        public static IntPtr CreateCursor4(Image image) => default;

        public static void DeleteCursor(IntPtr handle) { }

        // Returns true if cursor data is present. 
        public static bool CursorIsOk(IntPtr handle) => default;

        public static Int32Point CursorGetHotSpot(IntPtr handle) => default;

        // =================== Caret

        // blink time is measured in milliseconds and is the time elapsed
        // between 2 inversions of the caret (blink time of the caret is common
        // to all carets in the application, so these functions are static)
        public static int CaretGetBlinkTime() => default;
        public static void CaretSetBlinkTime(int milliseconds) { }

        public static void DeleteCaret(IntPtr handle) { }

        // Get the caret position(in pixels).
        public static Int32Point CaretGetPosition(IntPtr handle) => default;

        // Get the caret size.
        public static Int32Size CaretGetSize(IntPtr handle) => default;

        // Move the caret to given position(in logical coordinates).
        public static void CaretMove(IntPtr handle, int x, int y) { }

        // Changes the size of the caret.
        public static void CaretSetSize(IntPtr handle, int width, int height) { }

        public static IntPtr CreateCaret() => default;

        // Creates a caret with the given size(in pixels) and associates it with the window.
        public static IntPtr CreateCaret2(IntPtr window, int width, int height) => default;

        // Get the window the caret is associated with.
        public static IntPtr CaretGetWindow(IntPtr handle) => default;

        // Hides the caret, same as Show(false).
        public static void CaretHide(IntPtr handle) { }

        // Returns true if the caret was created successfully.
        public static bool CaretIsOk(IntPtr handle) => default;

        // Returns true if the caret is visible and false if it
        // is permanently hidden(if it is blinking and not shown
        // currently but will be after the next blink, this method still returns true).
        public static bool CaretIsVisible(IntPtr handle) => default;

        // Shows or hides the caret.
        public static void CaretShow(IntPtr handle, bool show = true) { }

        // =================== Display

        // Defaultructor creating display object representing the primary display.
        public static IntPtr CreateDisplay() => default;

        //ructor, setting up a wxDisplay instance with the specified display.
        public static IntPtr CreateDisplay2(uint index) => default;

        //ructor creating the display object associated with the given window.
        public static IntPtr CreateDisplay3(IntPtr window) => default;

        public static void DeleteDisplay(IntPtr handle) { }

        // Returns the number of connected displays.
        public static uint DisplayGetCount() => default;

        // Returns the index of the display on which the given point lies,
        // or -1 if the point is not on any connected display.
        public static int DisplayGetFromPoint(Int32Point pt) => default;

        // Returns the index of the display on which the given window lies.
        public static int DisplayGetFromWindow(IntPtr win) => default;

        // Returns default display resolution for the current platform in pixels per inch. 
        public static int DisplayGetStdPPIValue() => default;

        // Returns default display resolution for the current platform as wxSize. 
        public static Int32Size DisplayGetStdPPI() => default;

        // Returns the display's name.
        public static string DisplayGetName(IntPtr handle) => default;

        // Returns display resolution in pixels per inch.
        public static Int32Size DisplayGetPPI(IntPtr handle) => default;

        // Returns scaling factor used by this display. 
        public static double DisplayGetScaleFactor(IntPtr handle) => default;

        // Returns true if the display is the primary display. 
        public static bool DisplayIsPrimary(IntPtr handle) => default;

        // Returns the client area of the display.
        public static Int32Rect DisplayGetClientArea(IntPtr handle) => default;

        // Returns the bounding rectangle of the display
        public static Int32Rect DisplayGetGeometry(IntPtr handle) => default;

        // =================== SystemSettings

        // Returns true if the port has certain feature.
        public static bool SystemSettingsHasFeature(int index) => default;

        // get a standard system font
        public static Font SystemSettingsGetFont(int index) => default;

        // Gets a standard system color
        public static Color SystemSettingsGetColor(int index) => default;

        // Gets a system-dependent metric.
        public static int SystemSettingsGetMetric(int index, IntPtr win = default) => default;

        // Returns the name if available or empty string otherwise.
        public static string SystemAppearanceGetName() => default;

        // Return true if the current system there is explicitly recognized as
        // being a dark theme or if the default window background is dark.
        public static bool SystemAppearanceIsDark() => default;

        // Return true if the background is darker than foreground. This is used by
        // IsDark() if there is no platform-specific way to determine whether a
        // dark mode is being used.
        public static bool SystemAppearanceIsUsingDarkBackground() => default;

        // ===================

        public static bool IsBusyCursor() => default;

        public static void BeginBusyCursor() { }

        public static void EndBusyCursor() { }

        // Ring the system bell.
        // This function is categorized as a GUI one and so is not thread-safe.
        // #include <wx/utils.h> 
        public static void Bell() { }

        public static string GetTextFromUser(string message, string caption, string defaultValue,
            IntPtr parent, int x = -1, int y = -1, bool centre = true) => default;

        public static long GetNumberFromUser(string message, string prompt, string caption,
            long value, long min, long max, IntPtr parent, Int32Point pos) => default;
        // ===================

        public static int RendererDrawHeaderButton(IntPtr renderer, IntPtr win,
            IntPtr dc,
            Int32Rect rect,
            int flags /*= 0*/,
            int sortArrow /*= wxHDR_SORT_ICON_NONE*/,
            IntPtr headerButtonParams /*= NULL*/) => default;

        // Draw the contents of a header control button (label, sort arrows, etc.)
        // Normally only called by DrawHeaderButton.
        public static int RendererDrawHeaderButtonContents(IntPtr renderer, IntPtr win,
            IntPtr dc,
            Int32Rect rect,
            int flags /*= 0*/,
            int sortArrow /*= wxHDR_SORT_ICON_NONE*/,
            IntPtr headerButtonParams /*= NULL*/) => default;

        // Returns the default height of a header button, either a fixed platform
        // height if available, or a generic height based on the window's font.
        public static int RendererGetHeaderButtonHeight(IntPtr renderer, IntPtr win) => default;

        // Returns the margin on left and right sides of header button's label
        public static int RendererGetHeaderButtonMargin(IntPtr renderer, IntPtr win) => default;

        // draw the expanded/collapsed icon for a tree control item
        public static void RendererDrawTreeItemButton(IntPtr renderer, IntPtr win, IntPtr dc, Int32Rect rect, int flags = 0) { }

        // draw the border for sash window: this border must be such that the sash
        // drawn by DrawSash() blends into it well
        public static void RendererDrawSplitterBorder(IntPtr renderer, IntPtr win, IntPtr dc, Int32Rect rect, int flags = 0) { }

        // draw a (vertical) sash
        public static void DrawSplitterSash(IntPtr renderer, IntPtr win,
            IntPtr dcReal,
            Int32Size sizeReal,
            int position,
            int orientation,
            int flags = 0)
        {
        }

        // draw a combobox dropdown button
        // flags may use wxCONTROL_PRESSED and wxCONTROL_CURRENT
        public static void RendererDrawComboBoxDropButton(IntPtr renderer, IntPtr win,
            IntPtr dc,
            Int32Rect rect,
            int flags = 0)
        {
        }

        // draw a dropdown arrow
        // flags may use wxCONTROL_PRESSED and wxCONTROL_CURRENT
        public static void RendererDrawDropArrow(IntPtr renderer, IntPtr win,
            IntPtr dc,
                Int32Rect rect,
            int flags = 0)
        {
        }

        // draw check button
        // flags may use wxCONTROL_CHECKED, wxCONTROL_UNDETERMINED and wxCONTROL_CURRENT
        public static void RendererDrawCheckBox(IntPtr renderer, IntPtr win,
            IntPtr dc,
                Int32Rect rect,
            int flags = 0)
        {
        }

        // draw check mark
        // flags may use wxCONTROL_DISABLED
        public static void RendererDrawCheckMark(IntPtr renderer, IntPtr win,
            IntPtr dc,
                Int32Rect rect,
            int flags = 0)
        {
        }

        // Returns the default size of a check box.
        public static Int32Size RendererGetCheckBoxSize(IntPtr renderer, IntPtr win, int flags = 0) => default;

        // Returns the default size of a check mark.
        public static Int32Size RendererGetCheckMarkSize(IntPtr renderer, IntPtr win) => default;

        // Returns the default size of a expander.
        public static Int32Size RendererGetExpanderSize(IntPtr renderer, IntPtr win) => default;

        // draw blank button
        //
        // flags may use wxCONTROL_PRESSED, wxCONTROL_CURRENT and wxCONTROL_ISDEFAULT
        public static void RendererDrawPushButton(IntPtr renderer, IntPtr win,
            IntPtr dc,
            Int32Rect rect,
            int flags = 0)
        {
        }

        // draw collapse button
        //
        // flags may use wxCONTROL_CHECKED, wxCONTROL_UNDETERMINED and wxCONTROL_CURRENT
        public static void RendererDrawCollapseButton(IntPtr renderer, IntPtr win,
            IntPtr dc,
                Int32Rect rect,
            int flags = 0)
        {
        }

        // Returns the default size of a collapse button
        public static Int32Size RendererGetCollapseButtonSize(IntPtr renderer, IntPtr win, IntPtr dc) => default;

        // draw rectangle indicating that an item in e.g. a list control
        // has been selected or focused
        //
        // flags may use
        // wxCONTROL_SELECTED (item is selected, e.g. draw background)
        // wxCONTROL_CURRENT (item is the current item, e.g. dotted border)
        // wxCONTROL_FOCUSED (the whole control has focus, e.g. blue background vs. grey otherwise)
        public static void RendererDrawItemSelectionRect(IntPtr renderer, IntPtr win,
            IntPtr dc,
                Int32Rect rect,
            int flags = 0)
        {
        }

        // draw the focus rectangle around the label contained in the given rect
        //
        // only wxCONTROL_SELECTED makes sense in flags here
        public static void RendererDrawFocusRect(IntPtr renderer, IntPtr win,
            IntPtr dc,
                Int32Rect rect,
            int flags = 0)
        {
        }

        // Draw a native wxChoice
        public static void RendererDrawChoice(IntPtr renderer, IntPtr win,
            IntPtr dc,
                Int32Rect rect,
            int flags = 0)
        {
        }

        // Draw a native wxComboBox
        public static void RendererDrawComboBox(IntPtr renderer, IntPtr win,
            IntPtr dc,
                Int32Rect rect,
            int flags = 0)
        {
        }

        // Draw a native wxTextCtrl frame
        public static void RendererDrawTextCtrl(IntPtr renderer, IntPtr win,
            IntPtr dc,
                Int32Rect rect,
            int flags = 0)
        {
        }

        // Draw a native wxRadioButton bitmap
        public static void RendererDrawRadioBitmap(IntPtr renderer, IntPtr win,
            IntPtr dc,
                Int32Rect rect,
            int flags = 0)
        {
        }

        // Draw a gauge with native style like a wxGauge would display.
        // wxCONTROL_SPECIAL flag must be used for drawing vertical gauges.
        public static void RendererDrawGauge(IntPtr renderer, IntPtr win,
            IntPtr dc,
                Int32Rect rect,
            int value,
            int max,
            int flags = 0)
        {
        }

        // Draw text using the appropriate color for normal and selected states.
        public static void RendererDrawItemText(IntPtr renderer, IntPtr win,
            IntPtr dc,
            string text,
            Int32Rect rect,
            int align /*= wxALIGN_LEFT | wxALIGN_TOP*/,
            int flags /*= 0*/,
            int ellipsizeMode /*= wxELLIPSIZE_END*/)
        { }

        public static string RendererGetVersion(IntPtr renderer) => default;
    }
}

/*

 
 */