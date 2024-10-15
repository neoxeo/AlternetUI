using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Alternet.Base.Collections;
using Alternet.Drawing;

namespace Alternet.UI
{
    /// <summary>
    /// Represents a window that makes up an application's user interface.
    /// </summary>
    /// <remarks>A <see cref="Window"/> is a representation of any window displayed in
    /// your application.</remarks>
    [DesignerCategory("Code")]
    [ControlCategory("Hidden")]
    public partial class Window : ContainerControl, IWindow
    {
        private static WindowKind? globalWindowKindOverride;
        private static RectD defaultBounds = new(100, 100, 400, 400);
        private static int incFontSizeHighDpi = 2;
        private static int incFontSize = 0;

        private readonly WindowInfo info = new();
        private readonly WindowKind? windowKindOverride;

        private IconSet? icon = null;
        private object? menu = null;
        private Window? owner;
        private bool needLayout = false;
        private Collection<InputBinding>? inputBindings;
        private int? oldDisplay;
        private bool loadedCalled;

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        public Window()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="windowKind">Window kind to use instead of default value.</param>
        /// <remarks>
        /// Fo example, this constructor allows to use window as control
        /// (specify <see cref="WindowKind.Control"/>) as a parameter.
        /// </remarks>
        public Window(WindowKind windowKind)
        {
            windowKindOverride = windowKind;
            Initialize();
        }

        /// <summary>
        /// Occurs before a window is displayed for the first time.
        /// </summary>
        [Category("Behavior")]
        public event EventHandler? Load;

        /// <summary>
        /// Occurs when window moves to another display.
        /// </summary>
        public event EventHandler? DisplayChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="Menu"/> property changes.
        /// </summary>
        public event EventHandler? MenuChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="Icon"/> property changes.
        /// </summary>
        public event EventHandler? IconChanged;

        /*/// <summary>
        /// Occurs when the value of the <see cref="ToolBar"/> property changes.
        /// </summary>
        public event EventHandler? ToolBarChanged;*/

        /// <summary>
        /// Occurs when the value of the <see cref="StatusBar"/> property changes.
        /// </summary>
        public event EventHandler? StatusBarChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="Owner"/> property changes.
        /// </summary>
        public event EventHandler? OwnerChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="ShowInTaskbar"/> property changes.
        /// </summary>
        public event EventHandler? ShowInTaskbarChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="State"/> property changes.
        /// </summary>
        public event EventHandler? StateChanged;

        /// <summary>
        /// Occurs before the window is closed.
        /// </summary>
        /// <remarks>
        /// The <see cref="Closing"/> event occurs as the window is being closed. When a
        /// window is closed, it is disposed,
        /// releasing all resources associated with the form. If you cancel this event, the
        /// window remains opened.
        /// To cancel the closure of a window, set the <see cref="CancelEventArgs.Cancel"/>
        /// property of the
        /// <see cref="WindowClosingEventArgs"/> passed to your event handler to <c>true</c>.
        /// </remarks>
        public event EventHandler<WindowClosingEventArgs>? Closing;

        /// <summary>
        /// Occurs when the window is closed.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="Closed"/> event occurs after the window has been closed by the user
        /// or programmatically.
        /// To prevent a window from closing, handle the <see cref="Closing"/> event and set
        /// the <see cref="CancelEventArgs.Cancel"/> property
        /// of the <see cref="WindowClosingEventArgs"/> passed to your event handler to true.
        /// </para>
        /// <para>
        /// You can use this event to perform tasks such as freeing resources used by the window
        /// and to save information entered in the form or to update its parent window.
        /// </para>
        /// </remarks>
        public event EventHandler? Closed;

        /// <summary>
        /// Occurs when the value of the <see cref="MaximizeEnabled"/> property changes.
        /// </summary>
        public event EventHandler? MaximizeEnabledChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="MinimizeEnabled"/> property changes.
        /// </summary>
        public event EventHandler? MinimizeEnabledChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="CloseEnabled"/> property changes.
        /// </summary>
        public event EventHandler? CloseEnabledChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="TopMost"/> property changes.
        /// </summary>
        public event EventHandler? AlwaysOnTopChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="IsToolWindow"/> property changes.
        /// </summary>
        public event EventHandler? IsToolWindowChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="HasSystemMenu"/> property changes.
        /// </summary>
        public event EventHandler? HasSystemMenuChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="Resizable"/> property changes.
        /// </summary>
        public event EventHandler? ResizableChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="HasBorder"/> property changes.
        /// </summary>
        public event EventHandler? HasBorderChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="HasTitleBar"/> property changes.
        /// </summary>
        public event EventHandler? HasTitleBarChanged;

        /// <summary>
        /// Gets the currently active window for this application.
        /// </summary>
        /// <value>A <see cref="Window"/> that represents the currently active window,
        /// or <see langword="null"/> if there is no active window.</value>
        public static Window? ActiveWindow => App.Handler.GetActiveWindow();

        /// <summary>
        /// Gets or sets default location and position of the window.
        /// </summary>
        public static RectD DefaultBounds
        {
            get
            {
                return defaultBounds;
            }

            set
            {
                defaultBounds = value;
            }
        }

        /// <summary>
        /// Gets or sets default control font size increment
        /// (in points) on high dpi displays (DPI greater than 96).
        /// Default value is 2.
        /// </summary>
        public static int IncFontSizeHighDpi
        {
            get => incFontSizeHighDpi;

            set
            {
                if (incFontSizeHighDpi == value)
                    return;
                incFontSizeHighDpi = value;
                UpdateDefaultFont();
            }
        }

        /// <summary>
        /// Gets or sets default control font size increment (in points) on normal
        /// dpi displays (DPI less or equal to 96).
        /// Default value is 0.
        /// </summary>
        public static int IncFontSize
        {
            get => incFontSize;
            set
            {
                if (incFontSize == value)
                    return;
                incFontSize = value;
                UpdateDefaultFont();
            }
        }

        /// <summary>
        /// Gets DPI of the first created window.
        /// </summary>
        public static SizeD? DefaultDPI => App.FirstWindow()?.GetDPI();

        /// <summary>
        /// Gets a value indicating whether the window is the currently active window for
        /// this application.
        /// </summary>
        [Browsable(false)]
        public virtual bool IsActive => Handler.IsActive;

        /// <summary>
        /// Gets window handler.
        /// </summary>
        [Browsable(false)]
        public new IWindowHandler Handler => (IWindowHandler)base.Handler;

        /// <inheritdoc/>
        [Browsable(false)]
        public override bool ProcessIdle
        {
            get
            {
                return base.ProcessIdle;
            }

            set
            {
                if (base.ProcessIdle == true)
                    return;
                base.ProcessIdle = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the form will receive key events
        /// before the event is passed to the control that has focus.</summary>
        /// <returns>
        /// <see langword="true" /> if the form will receive all
        /// key events; <see langword="false" /> if the currently selected
        /// control on the form receives key events.
        /// The default is <see langword="false" />.
        /// </returns>
        [DefaultValue(false)]
        public virtual bool KeyPreview
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether to supress 'Esc' key.
        /// </summary>
        /// <remarks>
        /// When 'Esc' key is not handled by the application, operating system beeps when it
        /// is pressed. Set <c>true</c> to this property in order to handle 'Esc' key
        /// so no sound will be played.
        /// </remarks>
        public virtual bool SupressEsc { get; set; }

        /// <summary>
        /// Gets or sets a boolean value indicating whether window has title bar.
        /// </summary>
        /// <remarks>
        /// On some operating systems additional properties need to be set in order to hide
        /// the title bar. For example, <see cref="CloseEnabled"/>, <see cref="MinimizeEnabled"/>,
        /// <see cref="MaximizeEnabled"/>, <see cref="HasSystemMenu"/>, <see cref="HasBorder"/>
        /// and some other properties can affect on the title bar
        /// visibility.
        /// </remarks>
        public virtual bool HasTitleBar
        {
            get => info.HasTitleBar;

            set
            {
                if (info.HasTitleBar == value)
                    return;
                info.HasTitleBar = value;
                OnHasTitleBarChanged(EventArgs.Empty);
                HasTitleBarChanged?.Invoke(this, EventArgs.Empty);
                Handler.HasTitleBar = value;
            }
        }

        /// <summary>
        /// Gets or sets border style of the window.
        /// </summary>
        public new ControlBorderStyle BorderStyle
        {
            get => base.BorderStyle;
            set => base.BorderStyle = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the window has a border.
        /// </summary>
        public virtual bool HasBorder
        {
            get => info.HasBorder;

            set
            {
                if (info.HasBorder == value)
                    return;
                info.HasBorder = value;
                OnHasBorderChanged(EventArgs.Empty);
                HasBorderChanged?.Invoke(this, EventArgs.Empty);
                Handler.HasBorder = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the window can be resized by user.
        /// </summary>
        public virtual bool Resizable
        {
            get => info.Resizable;

            set
            {
                if (info.Resizable == value)
                    return;
                info.Resizable = value;
                OnResizableChanged(EventArgs.Empty);
                ResizableChanged?.Invoke(this, EventArgs.Empty);
                Handler.Resizable = value;
            }
        }

        /// <inheritdoc/>
        public override string Title
        {
            get => base.Title;

            set
            {
                if (Title == value)
                    return;
                base.Title = value;
                Handler.Title = value;
            }
        }

        /// <summary>
        /// A tool window does not appear in the Windows taskbar or in the window that appears
        /// when the user presses ALT+TAB.
        /// On Windows, a tool window doesn't have minimize and maximize buttons.
        /// </summary>
        public virtual bool IsToolWindow
        {
            get => info.IsToolWindow;

            set
            {
                if (info.IsToolWindow == value)
                    return;
                info.IsToolWindow = value;
                OnIsToolWindowChanged(EventArgs.Empty);
                IsToolWindowChanged?.Invoke(this, EventArgs.Empty);
                Handler.IsToolWindow = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to create a special popup window.
        /// </summary>
        /// <remarks>
        /// Set this flag to create a special popup window: it will be always shown
        /// on top of other windows, will capture the mouse and will be dismissed when
        /// the mouse is clicked outside of it or if it loses focus in any other way.
        /// </remarks>
        [Browsable(false)]
        public virtual bool IsPopupWindow
        {
            get => info.IsPopupWindow;

            set
            {
                if (info.IsPopupWindow == value)
                    return;
                info.IsPopupWindow = value;
                Handler.IsPopupWindow = value;
            }
        }

        /// <summary>
        /// Gets or sets whether system menu is visible for this window.
        /// </summary>
        public virtual bool HasSystemMenu
        {
            get
            {
                return info.HasSystemMenu;
            }

            set
            {
                if (info.HasSystemMenu == value)
                    return;
                info.HasSystemMenu = value;
                OnHasSystemMenuChanged(EventArgs.Empty);
                HasSystemMenuChanged?.Invoke(this, EventArgs.Empty);
                Handler.HasSystemMenu = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the window should be placed above all
        /// non-topmost windows and
        /// should stay above them, even when the window is deactivated.
        /// </summary>
        public virtual bool TopMost
        {
            get => info.AlwaysOnTop;

            set
            {
                if (info.AlwaysOnTop == value)
                    return;
                info.AlwaysOnTop = value;
                OnAlwaysOnTopChanged(EventArgs.Empty);
                AlwaysOnTopChanged?.Invoke(this, EventArgs.Empty);
                Handler.AlwaysOnTop = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the window has an enabled close button.
        /// </summary>
        public virtual bool CloseEnabled
        {
            get => info.CloseEnabled;

            set
            {
                if (info.CloseEnabled == value)
                    return;
                info.CloseEnabled = value;
                OnCloseEnabledChanged(EventArgs.Empty);
                CloseEnabledChanged?.Invoke(this, EventArgs.Empty);
                Handler.CloseEnabled = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the window has an enabled maximize button.
        /// </summary>
        public virtual bool MaximizeEnabled
        {
            get => info.MaximizeEnabled;

            set
            {
                if (info.MaximizeEnabled == value)
                    return;
                info.MaximizeEnabled = value;
                OnMaximizeEnabledChanged(EventArgs.Empty);
                MaximizeEnabledChanged?.Invoke(this, EventArgs.Empty);
                Handler.MaximizeEnabled = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the form is displayed in the Windows or
        /// Linux taskbar.
        /// </summary>
        /// <value>
        /// <see langword="true"/> to display the form in the Windows taskbar at run time;
        /// otherwise, <see langword="false"/>. The default is <see langword="true"/>.
        /// </value>
        /// <remarks>
        /// You can use this property to prevent users from selecting your form through the taskbar.
        /// For example, if you display a Find and Replace tool window in your application,
        /// you might want to prevent that window from being selected through the taskbar
        /// because you would need both the application's main window and the Find and Replace
        /// tool window displayed in order to process searches appropriately.
        /// </remarks>
        public virtual bool ShowInTaskbar
        {
            get => info.ShowInTaskbar;

            set
            {
                if (info.ShowInTaskbar == value)
                    return;
                info.ShowInTaskbar = value;
                OnShowInTaskbarChanged(EventArgs.Empty);
                ShowInTaskbarChanged?.Invoke(this, EventArgs.Empty);
                Handler.ShowInTaskbar = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the window has an enabled minimize button.
        /// </summary>
        public virtual bool MinimizeEnabled
        {
            get => info.MinimizeEnabled;

            set
            {
                if (info.MinimizeEnabled == value)
                    return;
                info.MinimizeEnabled = value;
                OnMinimizeEnabledChanged(EventArgs.Empty);
                MinimizeEnabledChanged?.Invoke(this, EventArgs.Empty);
                Handler.MinimizeEnabled = value;
            }
        }

        /// <summary>
        /// Gets or sets the window that owns this window.
        /// </summary>
        /// <value>
        /// A <see cref="Window"/> that represents the window that is the owner of this window.
        /// </value>
        /// <remarks>
        /// When a window is owned by another window, it is closed or hidden with the owner window.
        /// </remarks>
        [Browsable(false)]
        public virtual Window? Owner
        {
            get => owner;

            set
            {
                if (owner == value)
                    return;
                owner = value;
                OnOwnerChanged(EventArgs.Empty);
                OwnerChanged?.Invoke(this, EventArgs.Empty);
                Handler.SetOwner(value);
            }
        }

        /// <summary>
        /// Gets or sets the position of the window when first shown.
        /// </summary>
        /// <value>A <see cref="WindowStartLocation"/> that represents the starting position
        /// of the window.</value>
        /// <remarks>
        /// This property enables you to set the starting position of the window when it is
        /// first shown.
        /// This property should be set before the window is shown.
        /// </remarks>
        public virtual WindowStartLocation StartLocation
        {
            get => info.StartLocation;
            set
            {
                if (info.StartLocation == value)
                    return;
                info.StartLocation = value;
                Handler.StartLocation = value;
            }
        }

        /// <summary>
        /// Gets an array of <see cref="Window"/> objects that represent all windows that are
        /// owned by this window.
        /// </summary>
        /// <value>
        /// A <see cref="Window"/> array that represents the owned windows for this window.
        /// </value>
        /// <remarks>
        /// This property returns an array that contains all windows that are owned by this
        /// window. To make a window owned by another window, set the
        /// <see cref="Owner"/> property.
        /// When a window is owned by another window, it is closed or hidden
        /// with the owner window.
        /// </remarks>
        [Browsable(false)]
        public virtual Window[] OwnedWindows
        {
            get
            {
                return Handler.OwnedWindows;
            }
        }

        /// <summary>
        /// Gets or sets whether this window is maximized.
        /// </summary>
        [Browsable(false)]
        public bool IsMaximized
        {
            get => State == WindowState.Maximized;

            set
            {
                if (value)
                    State = WindowState.Maximized;
                else
                    State = WindowState.Normal;
            }
        }

        /// <summary>
        /// Gets or sets whether this window is minimized.
        /// </summary>
        [Browsable(false)]
        public bool IsMinimized
        {
            get => State == WindowState.Minimized;

            set
            {
                if (value)
                    State = WindowState.Minimized;
                else
                    State = WindowState.Normal;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether window is minimized,
        /// maximized, or normal.
        /// </summary>
        public virtual WindowState State
        {
            get => Handler.State;

            set
            {
                if (State == value)
                    return;

                if (IsDisposed)
                    return;
                Handler.State = value;
                RaiseStateChanged();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="StatusBar"/> that is displayed in the window.
        /// </summary>
        /// <value>
        /// A <see cref="StatusBar"/> that represents the status bar to display in the window.
        /// </value>
        /// <remarks>
        /// You can use this property to switch between complete status bar sets at run time.
        /// </remarks>
        [Browsable(false)]
        public virtual object? StatusBar
        {
            get => Handler.StatusBar;

            set
            {
                if (StatusBar == value)
                    return;
                Handler.StatusBar = value;
                OnStatusBarChanged(EventArgs.Empty);
                StatusBarChanged?.Invoke(this, EventArgs.Empty);
                PerformLayout();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this window is displayed modally.
        /// </summary>
        [Browsable(false)]
        public virtual bool Modal
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MainMenu"/> that is displayed in the window.
        /// </summary>
        /// <value>
        /// A <see cref="MainMenu"/> that represents the menu to display in the window.
        /// </value>
        /// <remarks>
        /// You can use this property to switch between complete menu sets at run time.
        /// </remarks>
        public virtual object? Menu
        {
            get => menu;

            set
            {
                if (menu == value)
                    return;

                var oldValue = menu;
                menu = value;

                if (GetWindowKind() == WindowKind.Dialog)
                    return;

                (oldValue as Control)?.SetParentInternal(null);
                (menu as Control)?.SetParentInternal(this);

                OnMenuChanged(EventArgs.Empty);
                MenuChanged?.Invoke(this, EventArgs.Empty);
                Handler.SetMenu(value);
                PerformLayout();
            }
        }

        /// <summary>
        /// Gets or sets the icon for the window.
        /// </summary>
        /// <value>
        /// An <see cref="ImageSet"/> that represents the icon for the window.
        /// </value>
        /// <remarks>
        /// A window's icon designates the picture that represents the window in the taskbar
        /// as well as the icon that is displayed for the control box of the window.
        /// If images of several sizes are contained within the <see cref="ImageSet"/>, the
        /// most fitting size is selected automatically.
        /// </remarks>
        public virtual IconSet? Icon
        {
            get => icon;

            set
            {
                if (icon == value)
                    return;

                icon = value;
                Handler.SetIcon(value);
                OnIconChanged(EventArgs.Empty);
                IconChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <inheritdoc/>
        public override bool Visible
        {
            get
            {
                return base.Visible;
            }

            set
            {
                if (Visible == value)
                    return;
                if (value)
                {
                    ApplyStartLocationOnce(Owner);
                    RaiseLoadedOnce();
                }

                base.Visible = value;
            }
        }

        /// <summary>
        /// Gets the collection of input bindings associated with this window.
        /// </summary>
        [Browsable(false)]
        public virtual Collection<InputBinding> InputBindings
        {
            get
            {
                if (inputBindings is null)
                {
                    inputBindings = new();

                    inputBindings.ItemRemoved += (sender, index, item) =>
                    {
                        Port.InheritanceContextHelper.RemoveContextFromObject(this, item);
                        Handler.RemoveInputBinding(item);
                    };

                    inputBindings.ItemInserted += (sender, index, item) =>
                    {
                        Handler.AddInputBinding(item);
                        Port.InheritanceContextHelper.ProvideContextForObject(this, item);
                    };
                }

                return inputBindings;
            }
        }

        /// <inheritdoc/>
        public override ControlTypeId ControlKind => ControlTypeId.Window;

        /// <inheritdoc />
        internal override IEnumerable<FrameworkElement> LogicalChildrenCollection
        {
            get
            {
                foreach (var item in base.LogicalChildrenCollection)
                    yield return item;

                if (Menu is FrameworkElement m)
                    yield return m;

                if (StatusBar is FrameworkElement s)
                    yield return s;
            }
        }

        /// <summary>
        /// Creates window with specified type and window kind.
        /// </summary>
        /// <typeparam name="T">Type of the window to create.</typeparam>
        /// <param name="windowKind">Window kind to use when window is created.</param>
        /// <returns></returns>
        public static T CreateAs<T>(WindowKind windowKind)
            where T : Window
        {
            globalWindowKindOverride = windowKind;
            try
            {
                var result = Activator.CreateInstance<T>();
                return result;
            }
            finally
            {
                globalWindowKindOverride = null;
            }
        }

        /// <summary>
        /// Updates default control font after changes in <see cref="IncFontSizeHighDpi"/>
        /// or <see cref="IncFontSize"/>. You should not call this method directly.
        /// </summary>
        public static void UpdateDefaultFont()
        {
            if (!App.Initialized)
                return;

            var dpi = Display.Primary.DPI;
            var incFont = (dpi.Width > 96) ? Window.IncFontSizeHighDpi : Window.IncFontSize;

            if (incFont > 0)
            {
                FontInfo info = Font.Default;
                info.SizeInPoints += incFont;
                Font font = info;
                Control.DefaultFont = font;
            }
        }

        /// <summary>
        /// Raises the window to the top of the window hierarchy (Z-order).
        /// This function only works for top level windows.
        /// </summary>
        /// <remarks>
        /// Notice that this function only requests the window manager to raise this window
        /// to the top of Z-order. Depending on its configuration, the window manager may
        /// raise the window, not do it at all or indicate that a window requested to be
        /// raised in some other way, e.g.by flashing its icon if it is minimized.
        /// </remarks>
        public virtual void Raise() => Handler.Raise();

        /// <summary>
        /// Shows window and focuses it.
        /// </summary>
        /// <param name="useIdle">Whether to use <see cref="App.Idle"/>
        /// event to show the window.</param>
        public virtual void ShowAndFocus(bool useIdle = false)
        {
            if (useIdle)
                App.AddIdleTask(Fn);
            else
                Fn();

            void Fn()
            {
                Show();
                Raise();
                if (CanFocus)
                    SetFocus();
            }
        }

        /// <summary>
        /// Activates the window.
        /// </summary>
        /// <remarks>
        /// Activating a window brings it to the front if this is the active application,
        /// or it flashes the window caption if this is not the active application.
        /// </remarks>
        public virtual void Activate() => Handler.Activate();

        /// <summary>
        /// Gets default bounds assigned to the window.
        /// </summary>
        /// <returns></returns>
        public virtual RectD GetDefaultBounds()
        {
            return DefaultBounds;
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <remarks>
        /// When a window is closed, all resources created within the object are closed and the
        /// window is disposed.
        /// You can prevent the closing of a window at run time by handling the
        /// <see cref="Window.Closing"/> event and
        /// setting the <c>Cancel</c> property of the <see cref="CancelEventArgs"/> passed as
        /// a parameter to your event handler.
        /// If the window you are closing is the last open window of your application,
        /// your application ends.
        /// The window is not disposed on <see cref="Close"/> when you have displayed the
        /// window using <see cref="DialogWindow.ShowModal()"/>.
        /// In this case, you will need to call <see cref="IDisposable.Dispose"/> manually.
        /// </remarks>
        public virtual void Close()
        {
            Visible = false;

            CheckDisposed();

            Handler.Close();
        }

        /// <summary>
        /// Raises <see cref="StateChanged"/> event and <see cref="OnStateChanged"/> method.
        /// </summary>
        public void RaiseStateChanged()
        {
            OnStateChanged(EventArgs.Empty);
            StateChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Raises <see cref="Closing"/> event and <see cref="OnClosing"/> method.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        public void RaiseClosing(WindowClosingEventArgs e)
        {
            OnClosing(e);
            Closing?.Invoke(this, e);
        }

        /// <summary>
        /// Raises <see cref="Closed"/> event and <see cref="OnClosed"/> method.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        public void RaiseClosed(WindowClosedEventArgs e)
        {
            OnClosed(e);
            Closed?.Invoke(this, e);
        }

        /// <summary>
        /// Sets relative location of this window on the specified display.
        /// </summary>
        /// <param name="relativePosition">New location of the window in pixels. This value is relative
        /// to the top-left corner of the display's client area.</param>
        /// <param name="display">Display which client area is used as a container for the window.</param>
        public virtual void SetLocationOnDisplay(PointI relativePosition, Display? display = null)
        {
            display = Display.SafeDisplay(display);
            var clientArea = display.ClientArea;
            var position = clientArea.Location;
            position.Offset(relativePosition);
            LocationInPixels = position;
        }

        /// <summary>
        /// Aligns control location inside the specified rectangle using given
        /// horizontal and vertical alignment.
        /// </summary>
        /// <param name="horz">Horizontal alignment of the control inside container.</param>
        /// <param name="vert">Vertical alignment of the window inside container.</param>
        /// <param name="shrinkSize">Whether to shrink size of the control
        /// to fit in the rectangle. Optional. Default is <c>true</c>.</param>
        /// <param name="containerRect">Container rectangle.</param>
        public virtual void SetLocationInRectI(
            HorizontalAlignment? horz,
            VerticalAlignment? vert,
            RectI containerRect,
            bool shrinkSize = true)
        {
            var newBounds = AlignUtils.AlignRectInRect(
                BoundsInPixels,
                containerRect,
                horz,
                vert,
                shrinkSize);
            BoundsInPixels = newBounds.ToRect();
        }

        /// <summary>
        /// Aligns control location inside the specified rectangle using given
        /// horizontal and vertical alignment.
        /// </summary>
        /// <param name="horz">Horizontal alignment of the control inside container.</param>
        /// <param name="vert">Vertical alignment of the window inside container.</param>
        /// <param name="shrinkSize">Whether to shrink size of the control
        /// to fit in the rectangle. Optional. Default is <c>true</c>.</param>
        /// <param name="window">Window which bounds are used as a container rectangle.</param>
        public virtual void SetLocationInWindow(
            HorizontalAlignment? horz,
            VerticalAlignment? vert,
            Control? window,
            bool shrinkSize = true)
        {
            if (window is null)
                SetLocationOnDisplay(horz, vert, null, shrinkSize);
            else
            {
                SetLocationInRectI(
                            horz,
                            vert,
                            window.BoundsInPixels,
                            shrinkSize);
            }
        }

        /// <summary>
        /// Aligns window location inside the specified display's client area using given
        /// horizontal and vertical alignment.
        /// </summary>
        /// <param name="horz">Horizontal alignment of the window inside display's client area.</param>
        /// <param name="vert">Vertical alignment of the window inside display's client area.</param>
        /// <param name="display">Display which client area is used as a container for the window.</param>
        /// <param name="shrinkSize">Whether to shrink size of the window
        /// to fit in the display client area. Optional. Default is <c>true</c>.</param>
        public virtual void SetLocationOnDisplay(
            HorizontalAlignment? horz,
            VerticalAlignment? vert,
            Display? display = null,
            bool shrinkSize = true)
        {
            display = Display.SafeDisplay(display);
            var clientArea = display.ClientArea;
            SetLocationInRectI(horz, vert, clientArea, shrinkSize);
        }

        /// <summary>
        /// Raised by the handler when it is going to be closed.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        public virtual void OnHandlerClosing(CancelEventArgs e)
        {
            // todo: add close reason/force parameter (see wxCloseEvent.CanVeto()).
            var closingEventArgs = new WindowClosingEventArgs(e.Cancel);
            RaiseClosing(closingEventArgs);
            if (closingEventArgs.Cancel)
            {
                e.Cancel = true;
                return;
            }

            RaiseClosed(new WindowClosedEventArgs());

            if (!Modal)
                Dispose();
        }

        /// <summary>
        /// Gets window kind (window, dialog, etc.).
        /// </summary>
        /// <returns></returns>
        public virtual WindowKind GetWindowKind() => GetWindowKindOverride() ?? WindowKind.Window;

        /// <summary>
        /// Lowers the window to the bottom of the window hierarchy (Z-order).
        /// This function only works for top level windows.
        /// </summary>
        public virtual void Lower() => Handler.Lower();

        /// <summary>
        /// Recreates all native controls in all windows.
        /// </summary>
        public virtual void RecreateAllHandlers()
        {
            void GetAllChildren(Control control, List<Control> result)
            {
                foreach (var child in control.Children)
                    GetAllChildren(child, result);

                if (control != this)
                    result.Add(control);
            }

            var children = new List<Control>();
            GetAllChildren(this, children);

            foreach (var child in children)
            {
                (child as PlatformControl)?.DetachHandler();
            }

            foreach (var child in children.AsEnumerable().Reverse())
            {
                (child as PlatformControl)?.EnsureHandlerCreated();
            }
        }

        internal static Window? GetParentWindow(object dp)
        {
            if (dp is Window w)
                return w;

            if (dp is not Control c)
                return null;

            if (c.Parent == null)
                return null;

            return GetParentWindow(c.Parent);
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;

            Visible = false;

            base.Dispose(disposing);

            if (disposing)
            {
                App.Current.UnregisterWindow(this);
                if (!App.Current.VisibleWindows.Any())
                    App.Handler.ExitMainLoop();
            }
        }

        /// <inheritdoc/>
        protected override IControlHandler CreateHandler()
            => ControlFactory.Handler.CreateWindowHandler(this);

        /// <summary>
        /// Applies <see cref="StartLocation"/> to the window position
        /// if <see cref="Control.StateFlags"/> has no
        /// <see cref="ControlFlags.StartLocationApplied"/> flag.
        /// </summary>
        /// <param name="owner"></param>
        protected virtual void ApplyStartLocationOnce(Control? owner)
        {
            if (!StateFlags.HasFlag(ControlFlags.StartLocationApplied))
            {
                StateFlags |= ControlFlags.StartLocationApplied;
                ApplyStartLocation(owner);
            }
        }

        /// <summary>
        /// Raises the <see cref="Closing"/> event and calls
        /// <see cref="OnClosing(WindowClosingEventArgs)"/>.
        /// See <see cref="Closing"/> event description for more details.
        /// </summary>
        /// <param name="e">An <see cref="WindowClosingEventArgs"/> that contains the event
        /// data.</param>
        protected virtual void OnClosing(WindowClosingEventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="CloseEnabled"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnCloseEnabledChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="ShowInTaskbar"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnShowInTaskbarChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="TopMost"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnAlwaysOnTopChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="MaximizeEnabled"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnMaximizeEnabledChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="MinimizeEnabled"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnMinimizeEnabledChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Raises the <see cref="Closed"/> event and calls
        /// <see cref="OnClosed(EventArgs)"/>.
        /// See <see cref="Closed"/> event description for more details.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event
        /// data.</param>
        protected virtual void OnClosed(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="Owner"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnOwnerChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="IsToolWindow"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnIsToolWindowChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="HasSystemMenu"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnHasSystemMenuChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="Resizable"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnResizableChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="HasTitleBar"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnHasTitleBarChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="HasBorder"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnHasBorderChanged(EventArgs e)
        {
        }

        /// <inheritdoc/>
        protected override void OnIdle(EventArgs e)
        {
            base.OnIdle(e);

            if (needLayout)
            {
                PerformLayout();
                needLayout = false;
            }
        }

        /// <inheritdoc/>
        protected override void OnHandlerSizeChanged(EventArgs e)
        {
            base.OnHandlerSizeChanged(e);
            PerformLayout();
            needLayout = true;
        }

        /// <inheritdoc/>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Escape && SupressEsc)
            {
                e.Handled = true;
                return;
            }

            ProcessShortcuts(e);
        }

        /// <summary>
        /// Iterates through all child control's shortcuts and
        /// calls shortcut action if its key is pressed.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void ProcessShortcuts(KeyEventArgs e)
        {
            var shortcuts = GetShortcuts();
            if (shortcuts is null)
                return;
            foreach (var (shortcut, action) in shortcuts)
            {
                var keys = shortcut.KeyInfo;
                if (keys is null)
                    continue;
                if (KeyInfo.Run(keys, e, action, setHandled: true))
                    break;
            }
        }

        /// <summary>
        /// Called when the value of the <see cref="Icon"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnIconChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="Menu"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnMenuChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="ToolBar"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnToolBarChanged(EventArgs e)
        {
        }

        /// <inheritdoc/>
        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
            SystemSettings.ResetColors();
        }

        /// <inheritdoc/>
        protected override void OnDpiChanged(DpiChangedEventArgs e)
        {
            base.OnDpiChanged(e);
            Display.Reset();
            PerformLayoutAndInvalidate();
        }

        /// <summary>
        /// Applies <see cref="Window.StartLocation"/> to the location of the window.
        /// </summary>
        protected virtual void ApplyStartLocation(Control? owner)
        {
            switch (StartLocation)
            {
                case WindowStartLocation.Default:
                case WindowStartLocation.Manual:
                    SetLocationOnDisplay(null, null);
                    break;
                case WindowStartLocation.ScreenTopRight:
                    SetLocationOnDisplay(HorizontalAlignment.Right, VerticalAlignment.Top);
                    break;
                case WindowStartLocation.ScreenBottomRight:
                    SetLocationOnDisplay(HorizontalAlignment.Right, VerticalAlignment.Bottom);
                    break;
                case WindowStartLocation.CenterScreen:
                    SetLocationOnDisplay(HorizontalAlignment.Center, VerticalAlignment.Center);
                    break;
                case WindowStartLocation.CenterOwner:
                    SetLocationInWindow(HorizontalAlignment.Center, VerticalAlignment.Center, owner);
                    break;
                case WindowStartLocation.CenterActiveWindow:
                    SetLocationInWindow(
                        HorizontalAlignment.Center,
                        VerticalAlignment.Center,
                        ActiveWindow);
                    break;
                case WindowStartLocation.CenterMainWindow:
                    SetLocationInWindow(
                        HorizontalAlignment.Center,
                        VerticalAlignment.Center,
                        App.MainWindow);
                    break;
            }

            /*
                        RectD displayRect = new Display(this).ClientAreaDip;
                        RectD parentRect = RectD.Empty;
                        bool center = true;

                        if (StartLocation == WindowStartLocation.CenterScreen)
                        {
                            parentRect = displayRect;
                        }
                        else
                        if (StartLocation == WindowStartLocation.CenterOwner)
                        {
                            if (owner is null)
                                parentRect = displayRect;
                            else
                                parentRect = new(owner.ClientToScreen((0, 0)), owner.ClientSize);
                        }
                        else
                            center = false;

                        var bounds = Bounds;

                        var newWidth = Math.Min(bounds.Width, displayRect.Width);
                        var newHeight = Math.Min(bounds.Height, displayRect.Height);

                        bounds.Width = newWidth;
                        bounds.Height = newHeight;

                        if (center)
                            bounds = bounds.CenterIn(parentRect);

                        Bounds = bounds;
            */
        }

        /// <summary>
        /// Called when the value of the <see cref="StatusBar"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnStatusBarChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="State"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnStateChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Default <see cref="IWindowHandler.InputBindingCommandExecuted"/> event implementation.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnHandlerInputBindingCommandExecuted(HandledEventArgs<string> e)
        {
            var binding = InputBindings.First(x => x.ManagedCommandId == e.Value);

            e.Handled = false;

            var command = binding.Command;
            if (command == null)
                return;

            if (!command.CanExecute(binding.CommandParameter))
                return;

            command.Execute(binding.CommandParameter);
            e.Handled = true;
        }

        /// <inheritdoc/>
        protected override void BindHandlerEvents()
        {
            base.BindHandlerEvents();
            Handler.StateChanged = RaiseStateChanged;
            Handler.Closing = OnHandlerClosing;
            Handler.InputBindingCommandExecuted = OnHandlerInputBindingCommandExecuted;
        }

        /// <summary>
        /// Gets window kind used instead of the default value.
        /// </summary>
        /// <returns></returns>
        protected WindowKind? GetWindowKindOverride() => globalWindowKindOverride ?? windowKindOverride;

        /// <inheritdoc/>
        protected override void UnbindHandlerEvents()
        {
            base.UnbindHandlerEvents();
            Handler.StateChanged = null;
            Handler.Closing = null;
            Handler.InputBindingCommandExecuted = null;
        }

        /// <inheritdoc/>
        protected override void OnHandlerLocationChanged(EventArgs e)
        {
            base.OnHandlerLocationChanged(e);

            InsideTryCatch(RaiseDisplayChanged);
        }

        private void RaiseDisplayChanged()
        {
            if (DisplayChanged is null)
                return;

            var newDisplay = Display.GetFromControl(this);

            if (oldDisplay is null)
            {
                oldDisplay = newDisplay;
                return;
            }

            if (oldDisplay == newDisplay)
                return;

            DisplayChanged?.Invoke(this, EventArgs.Empty);

            oldDisplay = newDisplay;
        }

        private void RaiseLoadedOnce()
        {
            if (loadedCalled)
                return;
            loadedCalled = true;
            Load?.Invoke(this, EventArgs.Empty);
        }

        private void Initialize()
        {
            SetVisibleValue(false);
            ProcessIdle = true;

            if(GetWindowKind() != WindowKind.Control)
                App.Current.RegisterWindow(this);

            Bounds = GetDefaultBounds();

            if (Control.DefaultFont != Font.Default)
                Font = Control.DefaultFont;
        }
    }
}