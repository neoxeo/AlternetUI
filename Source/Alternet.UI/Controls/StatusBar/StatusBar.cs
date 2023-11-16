using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Alternet.Base.Collections;
using Alternet.Drawing;

namespace Alternet.UI
{
    /// <summary>
    /// Represents a status bar control.
    /// </summary>
    [ControlCategory("MenusAndToolbars")]
    public class StatusBar : FrameworkElement
    {
        private Window? window;
        private int updateCount = 0;
        private bool sizingGripVisible = true;
        private TextEllipsizeType textEllipsize = TextEllipsizeType.End;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusBar"/> class.
        /// </summary>
        public StatusBar()
        {
            Panels.ItemInserted += OnItemInserted;
            Panels.ItemRemoved += OnItemRemoved;
        }

        /// <summary>
        /// Gets a collection of <see cref="StatusBarPanel"/> objects associated with the control.
        /// </summary>
        [Content]
        public Collection<StatusBarPanel> Panels { get; } = new() { ThrowOnNullAdd = true };

        /// <summary>
        /// Gets or sets whether to ignore <see cref="Panels"/>.
        /// </summary>
        /// <remarks>
        /// When <see cref="Panels"/> are ignored, they are not automatically assigned to
        /// the native control. Default value is <c>false</c>.
        /// </remarks>
        public bool IgnorePanels { get; set; }

        /// <summary>
        /// Gets <see cref="Window"/> to which this control is attached.
        /// </summary>
        public Window? Window
        {
            get => window;
            internal set
            {
                if (window == value)
                    return;
                window = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a sizing grip is displayed in the
        /// lower-right corner of the control.
        /// </summary>
        public bool SizingGripVisible
        {
            get => sizingGripVisible;

            set
            {
                if (sizingGripVisible == value)
                    return;
                sizingGripVisible = value;
                RecreateWidget();
            }
        }

        /// <summary>
        /// Gets or sets status texts replacement method when the text widths exceed the
        /// container's widths.
        /// </summary>
        public TextEllipsizeType TextEllipsize
        {
            get
            {
                return textEllipsize;
            }

            set
            {
                if (textEllipsize == value)
                    return;
                textEllipsize = value;
                RecreateWidget();
            }
        }

        /// <inheritdoc cref="Control.InUpdates"/>
        public bool InUpdates => updateCount > 0;

        /// <inheritdoc/>
        public override IReadOnlyList<FrameworkElement> ContentElements => Panels;

        /// <summary>
        /// Gets whether control is fully active and is attached to the window.
        /// </summary>
        public bool IsOk => StatusBarHandle != IntPtr.Zero && !IsDisposed;

        internal IntPtr StatusBarHandle
        {
            get
            {
                if (window is null || window.IsDisposed)
                {
                    window = null;
                    return default;
                }

                return window.Handler.NativeControl.WxStatusBar;
            }
        }

        /// <inheritdoc />
        protected override IEnumerable<FrameworkElement> LogicalChildrenCollection => Panels;

        /// <inheritdoc cref="Control.BeginUpdate"/>
        public virtual void BeginUpdate()
        {
            updateCount++;
        }

        /// <inheritdoc cref="Control.EndUpdate"/>
        public virtual void EndUpdate()
        {
            updateCount--;
            if(updateCount == 0)
                ApplyPanels();
        }

        /// <summary>
        /// Applies <see cref="Panels"/> to the native control.
        /// </summary>
        public virtual void ApplyPanels()
        {
            if (IgnorePanels)
                return;
            ApplyPanels(Panels);
        }

        /// <summary>
        /// Adds new item to <see cref="Panels"/>.
        /// </summary>
        /// <param name="text">The text displayed in the status bar panel.</param>
        public virtual StatusBarPanel Add(string text)
        {
            var result = new StatusBarPanel(text);
            Panels.Add(result);
            return result;
        }

        /// <summary>
        /// Appllies <paramref name="panels"/> to the native control.
        /// </summary>
        /// <param name="panels">Collection of the panels.</param>
        public virtual void ApplyPanels(Collection<StatusBarPanel> panels)
        {
            if (InUpdates || !IsOk)
                return;
            var count = panels.Count;
            var widths = new int[count];
            var styles = new StatusBarPanelStyle[count];

            for(int i = 0; i < count; i++)
            {
                widths[i] = panels[i].Width;
                styles[i] = panels[i].Style;
            }

            if(count == 0)
            {
                SetFieldsCount(1);
                SetStatusText(null);
                return;
            }

            SetFieldsCount(count);
            SetStatusWidths(widths);
            SetStatusStyles(styles);

            for (int i = 0; i < count; i++)
            {
                SetStatusText(panels[i].Text, i);
            }
        }

        /// <summary>
        /// Returns number of the panels in the native control.
        /// </summary>
        /// <returns>
        /// number of the panels in the native control if success;
        /// <c>null</c> otherwise.
        /// </returns>
        public virtual int? GetFieldsCount()
        {
            if (!IsOk)
                return null;
            return Native.WxStatusBarFactory.GetFieldsCount(StatusBarHandle);
        }

        /// <summary>
        /// Sets the status text for the specified panel in the native control.
        /// </summary>
        /// <param name="text">The text to be set. Use an empty string or <c>null</c>
        /// to clear the panel.</param>
        /// <param name="index">Panel index, starting from zero.</param>
        /// <returns><c>true</c> if success; <c>false</c> otherwise.</returns>
        /// <remarks>
        /// The given text will replace the current text. The display of the status bar is
        /// updated immediately.
        /// </remarks>
        /// <remarks>
        /// If <see cref="PushStatusText"/> had been called before the new text will
        /// also replace the last saved value to make sure that the next call to
        /// <see cref="PopStatusText"/> doesn't restore the old value, which was overwritten
        /// by the call to this function.
        /// </remarks>
        /// <remarks>
        /// This method doesn't affect <see cref="Panels"/>, it wortks with the native control.
        /// </remarks>
        public virtual bool SetStatusText(string? text = null, int index = 0)
        {
            if (!IsOk)
                return false;
            text ??= string.Empty;
            Native.WxStatusBarFactory.SetStatusText(StatusBarHandle, text, index);
            return true;
        }

        /// <summary>
        /// Gets the status text for the specified panel in the native control.
        /// </summary>
        /// <param name="index">Panel index, starting from zero.</param>
        /// <returns>
        /// <see cref="string"/> with the status text if success; <c>null</c> otherwise.
        /// </returns>
        /// <remarks>
        /// This method doesn't affect <see cref="Panels"/>, it wortks with the native control.
        /// </remarks>
        public virtual string? GetStatusText(int index = 0)
        {
            if (!IsOk)
                return null;
            return Native.WxStatusBarFactory.GetStatusText(StatusBarHandle, index);
        }

        /// <summary>
        /// Saves the current status text in a per-panel stack, and sets the
        /// status text to the string passed as argument.
        /// </summary>
        /// <param name="text">New panel status text.</param>
        /// <param name="index">Panel index, starting from zero.</param>
        /// <returns><c>true</c> if success; <c>false</c> otherwise.</returns>
        /// <remarks>
        /// This method doesn't affect <see cref="Panels"/>, it wortks with the native control.
        /// </remarks>
        /// <seealso cref="PopStatusText"/>
        public virtual bool PushStatusText(string? text = null, int index = 0)
        {
            if (!IsOk)
                return false;
            text ??= string.Empty;
            Native.WxStatusBarFactory.PushStatusText(StatusBarHandle, text, index);
            return true;
        }

        /// <summary>
        /// Restores the text to the value it had before the last call to <see cref="PushStatusText"/>.
        /// </summary>
        /// <param name="index">Panel index, starting from zero.</param>
        /// <returns><c>true</c> if success; <c>false</c> otherwise.</returns>
        /// <remarks>
        /// This method doesn't affect <see cref="Panels"/>, it wortks with the native control.
        /// </remarks>
        /// <seealso cref="PushStatusText"/>
        /// <remarks>
        /// Notice that if <see cref="SetStatusText"/> had been called in the meanwhile,
        /// <see cref="PopStatusText"/> will not change the text, i.e. it does not override
        /// explicit changes to status text but only restores the saved text
        /// if it hadn't been changed since.
        /// </remarks>
        public virtual bool PopStatusText(int index = 0)
        {
            if (!IsOk)
                return false;
            Native.WxStatusBarFactory.PopStatusText(StatusBarHandle, index);
            return true;
        }

        /// <summary>
        /// Sets the widths of the panels in the native control.
        /// </summary>
        /// <param name="widths">Contains an array of integers, each of which is either an
        /// absolute status panel width in pixels if positive or indicates a variable width
        /// panel if negative. </param>
        /// <returns><c>true</c> if success; <c>false</c> otherwise.</returns>
        /// <remarks>
        /// This method doesn't affect <see cref="Panels"/>, it wortks with the native control.
        /// </remarks>
        /// <remarks>
        /// There are two types of panels: fixed widths and variable width panels. For the fixed
        /// width panels you should specify their(constant) width in pixels. For the variable width
        /// panels, specify a negative number which indicates how the panels should expand:
        /// the space left for all variable width panels is divided between them according
        /// to the absolute value of this number. A variable width panels with width
        /// of (-2) gets twice as much of it as a panels with width (-1) and so on.
        /// </remarks>
        /// <remarks>
        /// For example, to create one fixed width panels of width 100 in the right part
        /// of the status bar and two more panels which get 66% and 33% of the
        /// remaining space correspondingly, you should use an array containing (-2), (-1) and 100.
        /// </remarks>
        /// <remarks>
        /// Size of the <paramref name="widths"/> array must be equal to the number passed to
        /// <see cref="SetFieldsCount"/> the last time it was called.
        /// </remarks>
        /// <remarks>
        /// The widths of the variable panels are calculated from the total width of all panels,
        /// minus the sum of widths of the non-variable panels, divided by the number of
        /// variable panels.
        /// </remarks>
        public virtual bool SetStatusWidths(int[] widths)
        {
            if (!IsOk || widths.Length == 0)
                return false;
            Native.WxStatusBarFactory.SetStatusWidths(StatusBarHandle, widths);
            return true;
        }

        /// <summary>
        /// Sets the number of panels in the native control.
        /// </summary>
        /// <param name="count">New number of panels. Must be greater than zero.</param>
        /// <returns><c>true</c> if success; <c>false</c> otherwise.</returns>
        /// <remarks>
        /// This method doesn't affect <see cref="Panels"/>, it wortks with the native control.
        /// </remarks>
        /// <remarks>
        /// If <paramref name="count"/> is greater than the previous number of panels,
        /// then new panels with empty strings will be added to the status bar.
        /// </remarks>
        public virtual bool SetFieldsCount(int count)
        {
            if (!IsOk || count < 1)
                return false;
            Native.WxStatusBarFactory.SetFieldsCount(StatusBarHandle, count);
            return true;
        }

        /// <summary>
        /// Gets the width of the specified panel in the native control.
        /// </summary>
        /// <param name="index">Panel index, starting from zero.</param>
        /// <returns>
        /// <see cref="int"/> with the panel width if success; <c>null</c> otherwise.
        /// </returns>
        /// <remarks>
        /// This method doesn't affect <see cref="Panels"/>, it wortks with the native control.
        /// </remarks>
        public virtual int? GetStatusWidth(int index)
        {
            if (!IsOk)
                return null;
            return Native.WxStatusBarFactory.GetStatusWidth(StatusBarHandle, index);
        }

        /// <summary>
        /// Gets the style of the specified panel in the native control.
        /// </summary>
        /// <param name="index">Panel index, starting from zero.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method doesn't affect <see cref="Panels"/>, it wortks with the native control.
        /// </remarks>
        public virtual StatusBarPanelStyle? GetStatusStyle(int index)
        {
            if (!IsOk)
                return null;
            return
                (StatusBarPanelStyle)Native.WxStatusBarFactory.GetStatusStyle(StatusBarHandle, index);
        }

        /// <summary>
        /// Sets the styles of the panels in the status line which can make panels appear
        /// flat or raised instead of the standard sunken 3D border.
        /// </summary>
        /// <param name="styles">Contains an array of <see cref="StatusBarPanelStyle"/> with
        /// the styles for each panel.</param>
        /// <returns><c>true</c> if success; <c>false</c> otherwise.</returns>
        /// <remarks>
        /// This method doesn't affect <see cref="Panels"/>, it wortks with the native control.
        /// </remarks>
        /// <remarks>
        /// Size of the <paramref name="styles"/> array must be equal to the number passed to
        /// <see cref="SetFieldsCount"/> the last time it was called.
        /// </remarks>
        public virtual bool SetStatusStyles(StatusBarPanelStyle[] styles)
        {
            if (!IsOk || styles.Length == 0)
                return false;
            var result = styles.Cast<int>().ToArray();
            Native.WxStatusBarFactory.SetStatusStyles(StatusBarHandle, result);
            return true;
        }

        /// <summary>
        /// Gets the size and position of a panels's internal bounding rectangle in the
        /// native control.
        /// </summary>
        /// <param name="index">Panel index, starting from zero.</param>
        /// <returns><see cref="Int32Rect"/> with the size and position of a panels's
        /// internal bounding rectangle on success; <c>null</c> otherwise.</returns>
        /// <remarks>
        /// This method doesn't affect <see cref="Panels"/>, it wortks with the native control.
        /// </remarks>
        public virtual Int32Rect? GetFieldRect(int index)
        {
            if (!IsOk)
                return null;
            var result = Native.WxStatusBarFactory.GetFieldRect(StatusBarHandle, index);
            if (result == Int32Rect.Empty)
                return null;
            return result;
        }

        /// <summary>
        /// Sets the minimal possible height for the status bar.
        /// </summary>
        /// <param name="height">New height value.</param>
        /// <returns><c>true</c> if success; <c>false</c> otherwise.</returns>
        /// <remarks>
        /// The real height may be bigger than the height specified here depending
        /// on the size of the font used by the status bar.
        /// </remarks>
        public virtual bool SetMinHeight(int height)
        {
            if (!IsOk)
                return false;
            Native.WxStatusBarFactory.SetMinHeight(StatusBarHandle, height);
            return true;
        }

        /// <summary>
        /// Gets the horizontal border used when rendering the panel text inside the panel area.
        /// </summary>
        /// <returns><see cref="int"/> with the horizontal border on success;
        /// <c>null</c> otherwise.</returns>
        /// <remarks>
        /// Note that the rect returned by <see cref="GetFieldRect"/> already accounts for
        /// the presence of horizontal and vertical border returned by this function.
        /// </remarks>
        public virtual int? GetBorderX()
        {
            if (!IsOk)
                return null;
            return Native.WxStatusBarFactory.GetBorderX(StatusBarHandle);
        }

        /// <summary>
        /// Gets the vertical border used when rendering the panel text inside the panel area.
        /// </summary>
        /// <returns><see cref="int"/> with the vertical border on success;
        /// <c>null</c> otherwise.</returns>
        /// <remarks>
        /// Note that the rect returned by <see cref="GetFieldRect"/> already accounts for
        /// the presence of horizontal and vertical border returned by this function.
        /// </remarks>
        public virtual int? GetBorderY()
        {
            if (!IsOk)
                return null;
            return Native.WxStatusBarFactory.GetBorderY(StatusBarHandle);
        }

        /// <summary>
        /// Clears <see cref="Panels"/>.
        /// </summary>
        public virtual void Clear()
        {
            Panels.Clear();
        }

        /// <summary>
        /// Called when item was inserted in the <see cref="Panels"/>.
        /// </summary>
        internal virtual void OnItemInserted(object? sender, int index, StatusBarPanel item)
        {
            item.PropertyChanged += OnItemPropertyChanged;
            ApplyPanels();
        }

        internal virtual void OnItemPropertyChanged(object? sender, EventArgs e)
        {
            ApplyPanels();
        }

        internal virtual void OnControlRecreated(object? sender, EventArgs e)
        {
            ApplyPanels();
        }

        internal virtual void OnItemRemoved(object? sender, int index, StatusBarPanel item)
        {
            item.PropertyChanged -= OnItemPropertyChanged;
            ApplyPanels();
        }

        internal void RecreateWidget()
        {
            const int SIZEGRIP = 0x0010;
            const int SHOWTIPS = 0x0020;
            const int ELLIPSIZESTART = 0x0040;
            const int ELLIPSIZEMIDDLE = 0x0080;
            const int ELLIPSIZEEND = 0x0100;
            const int FULLREPAINTONRESIZE = 0x00010000;

            var handle = StatusBarHandle;
            if (window != null)
            {
                window.Handler.NativeControl.WxStatusBar = default;
                if(handle != default)
                    Native.WxStatusBarFactory.DeleteStatusBar(handle);

                window.Handler.NativeControl.WxStatusBar =
                    Native.WxStatusBarFactory.CreateStatusBar(
                        window.Handler.NativeControl.WxWidget,
                        GetStyle());
                ApplyPanels();
            }

            long GetStyle()
            {
                long ellipsizeStyle = 0;
                switch (textEllipsize)
                {
                    case TextEllipsizeType.End:
                        ellipsizeStyle = ELLIPSIZEEND;
                        break;
                    case TextEllipsizeType.Start:
                        ellipsizeStyle = ELLIPSIZESTART;
                        break;
                    case TextEllipsizeType.Middle:
                        ellipsizeStyle = ELLIPSIZEMIDDLE;
                        break;
                    default:
                        break;
                }

                var result = ellipsizeStyle | SHOWTIPS | FULLREPAINTONRESIZE;
                if (sizingGripVisible)
                    result |= SIZEGRIP;
                return result;
            }
        }

        /// <inheritdoc/>
        protected override void DisposeUnmanagedResources()
        {
        }
    }
}