using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Alternet.Base.Collections;
using Alternet.Drawing;

namespace Alternet.UI
{
    /// <summary>
    /// Defines the base class for controls, which are components with
    /// visual representation.
    /// </summary>
    [DesignerCategory("Code")]
    [DefaultProperty("Text")]
    [DefaultEvent("Click")]
    public class Control : FrameworkElement, ISupportInitialize, IDisposable,
        IControl
    {
        /// <summary>
        /// Identifies the <see cref="ToolTip"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ToolTipProperty =
        DependencyProperty.Register(
                nameof(ToolTip),
                typeof(string),
                typeof(Control),
                new FrameworkPropertyMetadata(
                        null,
                        FrameworkPropertyMetadataOptions.None,
                        new PropertyChangedCallback(OnToolTipPropertyChanged),
                        null,
                        true,
                        UpdateSourceTrigger.PropertyChanged));

        /// <summary>
        /// Identifies the <see cref="Enabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.Register(
                    "Enabled",
                    typeof(bool),
                    typeof(Control),
                    new FrameworkPropertyMetadata(
                            true,
                            FrameworkPropertyMetadataOptions.AffectsPaint,
                            new PropertyChangedCallback(OnEnabledPropertyChanged),
                            null,
                            isAnimationProhibited: true,
                            UpdateSourceTrigger.PropertyChanged));

        private static readonly Size DefaultSize = new(double.NaN, double.NaN);

        private Color? backgroundColor;
        private Color? foregroundColor;
        private Collection<Control>? children;
        private Size size = DefaultSize;
        private Thickness margin;
        private Thickness padding;
        private ControlHandler? handler;
        private Brush? background;
        private Brush? foreground;
        private Font? font;
        private Brush? borderBrush;
        private VerticalAlignment verticalAlignment = VerticalAlignment.Stretch;
        private HorizontalAlignment horizontalAlignment = HorizontalAlignment.Stretch;
        private ControlExtendedProps? extendedProps = null;
        private Thickness? minMargin;
        private Thickness? minPadding;
        private bool visible = true;
        private Control? parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="Control"/> class.
        /// </summary>
        public Control()
        {
            margin.ApplyMin(MinMargin);
            padding.ApplyMin(MinPadding);
        }

        /// <summary>
        /// Occurs when the <see cref="ToolTip"/> property value changes.
        /// </summary>
        public event EventHandler? ToolTipChanged;

        /// <summary>
        /// Occurs when the control is clicked.
        /// </summary>
        public event EventHandler? Click;

        /// <summary>
        /// Occurs when the value of the <see cref="BorderBrush"/> property changes.
        /// </summary>
        public event EventHandler? BorderBrushChanged;

        /// <summary>
        /// Occurs when the control is redrawn.
        /// </summary>
        /// <remarks>
        /// The <see cref="Paint"/> event is raised when the control is redrawn.
        /// It passes an instance of <see cref="PaintEventArgs"/> to the method(s)
        /// that handles the <see cref="Paint"/> event.
        /// </remarks>
        public event EventHandler<PaintEventArgs>? Paint;

        /// <summary>
        /// Occurs when the value of the <see cref="Margin"/> property changes.
        /// </summary>
        public event EventHandler? MarginChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="Padding"/> property changes.
        /// </summary>
        public event EventHandler? PaddingChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="Visible"/> property changes.
        /// </summary>
        public event EventHandler? VisibleChanged;

        /// <summary>
        /// Occurs when the control loses mouse capture.
        /// </summary>
        /// <remarks>
        /// In rare scenarios, you might need to detect unexpected input.
        /// For example, consider the following scenarios.
        /// <list type="bullet">
        /// <item>During a mouse operation, the user opens the Start menu by
        /// pressing the Windows key or CTRL+ESC.</item>
        /// <item>During a mouse operation, the user switches to another program
        /// by pressing ALT+TAB.</item>
        /// <item>During a mouse operation, another program displays a window or
        /// a message box that takes focus away from the current application.</item>
        /// </list>
        /// Mouse operations can include clicking and holding the mouse on a form
        /// or a control, or performing a mouse drag operation.
        /// If you have to detect when a form or a control loses mouse capture
        /// for these and related unexpected scenarios, you can use the
        /// <see cref="MouseCaptureLost"/> event.
        /// </remarks>
        public event EventHandler? MouseCaptureLost;

        /// <summary>
        /// Occurs when the mouse pointer enters the control.
        /// </summary>
        public event EventHandler? MouseEnter;

        /// <summary>
        /// Occurs when the mouse pointer leaves the control.
        /// </summary>
        public event EventHandler? MouseLeave;

        /// <summary>
        /// Occurs when control is disposed.
        /// </summary>
        public event EventHandler? Disposed;

        /// <summary>
        /// Occurs when the value of the <see cref="Enabled"/> property changes.
        /// </summary>
        public event EventHandler? EnabledChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="Background"/> property changes.
        /// </summary>
        public event EventHandler? BackgroundChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="Foreground"/> property changes.
        /// </summary>
        public event EventHandler? ForegroundChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="Font"/> property changes.
        /// </summary>
        public event EventHandler? FontChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="VerticalAlignment"/>
        /// property changes.
        /// </summary>
        public event EventHandler? VerticalAlignmentChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="HorizontalAlignment"/>
        /// property changes.
        /// </summary>
        public event EventHandler? HorizontalAlignmentChanged;

        /// <summary>
        /// Occurs when the control's size is changed.
        /// </summary>
        public event EventHandler? SizeChanged;

        /// <summary>
        /// Occurs when the control's location is changed.
        /// </summary>
        public event EventHandler? LocationChanged;

        /// <summary>
        /// Occurs when a drag-and-drop operation is completed.
        /// </summary>
        public event EventHandler<DragEventArgs>? DragDrop;

        /// <summary>
        /// Occurs when an object is dragged over the control's bounds.
        /// </summary>
        public event EventHandler<DragEventArgs>? DragOver;

        /// <summary>
        /// Occurs when an object is dragged into the control's bounds.
        /// </summary>
        public event EventHandler<DragEventArgs>? DragEnter;

        /// <summary>
        /// Occurs when an object is dragged out of the control's bounds.
        /// </summary>
        public event EventHandler? DragLeave;

        /// <summary>
        /// Gets the default font used for controls.
        /// </summary>
        /// <value>
        /// The default <see cref="Font"/> for UI controls. The value returned will
        /// vary depending on the user's operating system and the local settings
        /// of their system.
        /// </value>
        public static Font DefaultFont => Font.Default;

        /// <summary>
        /// Gets or sets size of the <see cref="Control"/>'s client area, in
        /// device-independent units (1/96th inch per unit).
        /// </summary>
        [Browsable(false)]
        public virtual Size ClientSize
        {
            get => Handler.ClientSize;
            set => Handler.ClientSize = value;
        }

        /// <summary>
        /// Executes assigned action immediately.
        /// </summary>
        [Browsable(false)]
        public virtual Action<Control>? InitAction
        {
            get
            {
                return null;
            }

            set
            {
                value?.Invoke(this);
            }
        }

        /// <summary>
        /// Gets or sets <see cref="IComponentDesigner"/> instance which
        /// connects control with the designer.
        /// </summary>
        [Browsable(false)]
        public IComponentDesigner? Designer { get; set; }

        /// <summary>
        /// Gets a value indicating whether the mouse is captured to this control.
        /// </summary>
        [Browsable(false)]
        public virtual bool IsMouseCaptured => Handler.IsMouseCaptured;

        /// <summary>
        /// Gets whether this control itself can have focus.
        /// </summary>
        [Browsable(false)]
        public virtual bool IsFocusable => Handler.IsFocusable;

        /// <summary>
        /// Gets whether this control can have focus right now.
        /// </summary>
        /// <remarks>
        /// If this property returns true, it means that calling <see cref="SetFocus"/> will put
        /// focus either to this control or one of its children. If you need to know whether
        /// this control accepts focus itself, use <see cref="IsFocusable"/>.
        /// </remarks>
        [Browsable(false)]
        public virtual bool CanAcceptFocus => Handler.CanAcceptFocus;

        /// <summary>
        /// Gets or sets the object that contains data about the control.
        /// </summary>
        /// <value>An <see cref="object"/> that contains data about the control.
        /// The default is <c>null</c>.</value>
        /// <remarks>
        /// Any type derived from the <see cref="object"/> class can be assigned
        /// to this property.
        /// A common use for the <see cref="Tag"/> property is to store data that
        /// is closely associated with the control.
        /// </remarks>
        [Browsable(false)]
        public object? Tag
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the tool-tip object that is displayed for this element
        /// in the user interface.
        /// </summary>
        [DefaultValue(null)]
        [Localizability(LocalizationCategory.ToolTip)]
        public virtual string? ToolTip
        {
            get { return (string?)GetValue(ToolTipProperty); }
            set { SetValue(ToolTipProperty, value); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Control"/> bounds relative to the parent,
        /// in device-independent units (1/96th inch per unit).
        /// </summary>
        [Browsable(false)]
        public virtual Rect Bounds
        {
            get => Handler.Bounds;
            set => Handler.Bounds = value;
        }

        /// <summary>
        /// Gets or sets the distance between the left edge of the control
        /// and the left edge of its container's client area.
        /// </summary>
        public virtual double Left
        {
            get
            {
                return Bounds.Left;
            }

            set
            {
                var bounds = Bounds;
                if (bounds.Left == value)
                    return;
                Bounds = new Rect(value, bounds.Top, bounds.Width, bounds.Height);
            }
        }

        /// <summary>
        /// Gets or sets the distance between the top edge of the control
        /// and the top edge of its container's client area.
        /// </summary>
        public virtual double Top
        {
            get
            {
                return Bounds.Top;
            }

            set
            {
                var bounds = Bounds;
                if (bounds.Top == value)
                    return;
                Bounds = new Rect(bounds.Left, value, bounds.Width, bounds.Height);
            }
        }

        /// <summary>
        /// Gets or sets the location of upper-left corner of the control, in
        /// device-independent units (1/96th inch per unit).
        /// </summary>
        /// <value>The position of the control's upper-left corner, in logical
        /// units (1/96th of an inch).</value>
        [Browsable(false)]
        public virtual Point Location
        {
            get
            {
                return Bounds.Location;
            }

            set
            {
                Bounds = new Rect(value, Bounds.Size);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control and all its
        /// child controls are displayed.
        /// </summary>
        /// <value><c>true</c> if the control and all its child controls are
        /// displayed; otherwise, <c>false</c>. The default is <c>true</c>.</value>
        public virtual bool Visible
        {
            get => visible;

            set
            {
                if (visible == value)
                    return;

                visible = value;
                OnVisibleChanged(EventArgs.Empty);
                VisibleChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control can respond
        /// to user interaction.
        /// </summary>
        /// <value><c>true</c> if the control can respond to user
        /// interaction; otherwise, <c>false</c>. The default is <c>true</c>.</value>
        /// <remarks>
        /// With the <see cref="Enabled"/> property, you can enable or disable
        /// controls at run time.
        /// For example, you can disable controls that do not apply to the
        /// current state of the application.
        /// You can also disable a control to restrict its use. For example, a
        /// button can be disabled to prevent the user from clicking it.
        /// </remarks>
        public virtual bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        // todo: Do we need border property for all the controls at all?

        /// <summary>
        /// Gets or sets the border brush of the control.
        /// </summary>
        [Browsable(false)]
        public virtual Brush? BorderBrush
        {
            get => borderBrush;
            set
            {
                if (borderBrush == value)
                    return;

                borderBrush = value;
                BorderBrushChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets a <see cref="ControlHandler"/> associated with this class.
        /// </summary>
        [Browsable(false)]
        public virtual ControlHandler Handler
        {
            get
            {
                EnsureHandlerCreated();
                return handler ?? throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets whether <see cref="Dispose(bool)"/> has been called.
        /// </summary>
        [Browsable(false)]
        public virtual bool IsDisposed { get; private set; }

        /// <summary>
        /// Gets the collection of child controls contained within the control.
        /// </summary>
        /// <value>A <see cref="Collection{T}"/> representing the collection
        /// of controls contained within the control.</value>
        /// <remarks>
        /// A Control can act as a parent to a collection of controls.
        /// For example, when several controls are added to a
        /// <see cref="Window"/>, each of the controls is a member
        /// of the <see cref="Collection{T}"/> assigned to the
        /// <see cref="Children"/> property of the window, which is derived
        /// from the <see cref="Control"/> class.
        /// <para>You can manipulate the controls in the
        /// <see cref="Collection{T}"/> assigned to the <see cref="Children"/>
        /// property by using the methods available in the
        /// <see cref="Collection{T}"/> class.</para>
        /// <para>When adding several controls to a parent control, it
        /// is recommended that you call the <see cref="SuspendLayout"/> method
        /// before initializing the controls to be added.
        /// After adding the controls to the parent control, call the
        /// <see cref="ResumeLayout"/> method. Doing so will increase the
        /// performance of applications with many controls.</para>
        /// </remarks>
        [Content]
        [Browsable(false)]
        public virtual Collection<Control> Children
        {
            get
            {
                if(children == null)
                {
                    children = new Collection<Control>() { ThrowOnNullAdd = true };
                    children.ItemInserted += Children_ItemInserted;
                    children.ItemRemoved += Children_ItemRemoved;
                }

                return children;
            }
        }

        /// <summary>
        /// Gets whether there are any items in the <see cref="Children"/> list.
        /// </summary>
        [Browsable(false)]
        public bool HasChildren
        {
            get
            {
                return children != null && children.Count > 0;
            }
        }

        /// <inheritdoc/>
        [Browsable(false)]
        public override IReadOnlyList<FrameworkElement> ContentElements
        {
            get
            {
                if (children == null)
                    return Array.Empty<FrameworkElement>();
                return children;
            }
        }

        /// <summary>
        /// Gets or sets the parent container of the control.
        /// </summary>
        [Browsable(false)]
        public virtual Control? Parent
        {
            get => parent;
            set
            {
                if (parent == value)
                    return;
                parent?.Children.Remove(this);
                value?.Children.Add(this);
            }
        }

        /// <summary>
        /// Gets the parent window of the control).
        /// </summary>
        [Browsable(false)]
        public virtual Window? ParentWindow
        {
            get
            {
                var result = Parent;
                while (true)
                {
                    if (result == null)
                        return null;
                    if (result is Window)
                        return (Window?)result;
                    result = result.Parent;
                }
            }
        }

        /// <summary>
        /// Gets or sets the suggested size of the control.
        /// </summary>
        /// <value>The suggested size of the control, in device-independent
        /// units (1/96th inch per unit).
        /// The default value is <see cref="Drawing.Size"/>
        /// (<see cref="double.NaN"/>, <see cref="double.NaN"/>)/>.
        /// </value>
        /// <remarks>
        /// This property specifies the suggested size of the control. An actual
        /// size is calculated by the layout system.
        /// Set this property to <see cref="Drawing.Size"/>
        /// (<see cref="double.NaN"/>, <see cref="double.NaN"/>) to specify auto
        /// sizing behavior.
        /// The value of this property is always the same as the value that was
        /// set to it and is not changed by the layout system.
        /// </remarks>
        [Browsable(false)]
        public virtual Size Size
        {
            get
            {
                return size;
            }

            set
            {
                if (size == value)
                    return;

                size = value;
            }
        }

        /// <summary>
        /// Gets or sets the suggested width of the control.
        /// </summary>
        /// <value>The suggested width of the control, in device-independent
        /// units (1/96th inch per unit).
        /// The default value is <see cref="double.NaN"/>.
        /// </value>
        /// <remarks>
        /// This property specifies the suggested width of the control. An
        /// actual width is calculated by the layout system.
        /// Set this property to <see cref="double.NaN"/> to specify auto
        /// sizing behavior.
        /// The value of this property is always the same as the value that was
        /// set to it and is not changed by the layout system.
        /// </remarks>
        public virtual double Width
        {
            get => size.Width;

            set
            {
                Size = new(value, Size.Height);
            }
        }

        /// <summary>
        /// Gets or sets the suggested height of the control.
        /// </summary>
        /// <value>The suggested height of the control, in device-independent
        /// units (1/96th inch per unit).
        /// The default value is <see cref="double.NaN"/>.
        /// </value>
        /// <remarks>
        /// This property specifies the suggested height of the control. An
        /// actual height is calculated by the layout system.
        /// Set this property to <see cref="double.NaN"/> to specify auto
        /// sizing behavior.
        /// The value of this property is always the same as the value that was
        /// set to it and is not changed by the layout system.
        /// </remarks>
        public virtual double Height
        {
            get => size.Height;

            set
            {
                Size = new(Size.Width, value);
            }
        }

        /// <summary>
        /// Gets or set a value indicating whether the control paints itself
        /// rather than the operating system doing so.
        /// </summary>
        /// <value>If <c>true</c>, the control paints itself rather than the
        /// operating system doing so.
        /// If <c>false</c>, the <see cref="Paint"/> event is not raised.</value>
        [Browsable(false)]
        public virtual bool UserPaint
        {
            get => Handler.UserPaint;
            set => Handler.UserPaint = value;
        }

        /// <summary>
        /// Gets or sets the outer margin of an control.
        /// </summary>
        /// <value>Provides margin values for the control. The default value is a
        /// <see cref="Thickness"/> with all properties equal to 0 (zero).</value>
        /// <remarks>
        /// The margin is the space between this control and the adjacent control.
        /// Margin is set as a <see cref="Thickness"/> structure rather than as
        /// a number so that the margin can be set asymmetrically.
        /// The <see cref="Thickness"/> structure itself supports string
        /// type conversion so that you can specify an asymmetric <see cref="Margin"/>
        /// in UIXML attribute syntax also.
        /// </remarks>
        public virtual Thickness Margin
        {
            get => margin;
            set
            {
                value.ApplyMin(MinMargin);
                if (margin == value)
                    return;

                margin = value;

                OnMarginChanged(EventArgs.Empty);
                MarginChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the padding inside a control.
        /// </summary>
        /// <value>Provides padding values for the control. The default value is
        /// a <see cref="Thickness"/> with all properties equal to 0 (zero).</value>
        /// <remarks>
        /// The padding is the amount of space between the content of a
        /// <see cref="Control"/> and its border.
        /// Padding is set as a <see cref="Thickness"/> structure rather than as
        /// a number so that the padding can be set asymmetrically.
        /// The <see cref="Thickness"/> structure itself supports string
        /// type conversion so that you can specify an asymmetric <see cref="Padding"/>
        /// in UIXML attribute syntax also.
        /// </remarks>
        public virtual Thickness Padding
        {
            get => padding;
            set
            {
                value.ApplyMin(MinPadding);
                if (padding == value)
                    return;

                padding = value;

                OnPaddingChanged(EventArgs.Empty);
                PaddingChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        public virtual Color? BackgroundColor
        {
            get
            {
                return backgroundColor;
            }

            set
            {
                if (backgroundColor == value)
                    return;
                backgroundColor = value;

                if (Handler.NativeControl is not null)
                {
                    if (backgroundColor is null)
                        Handler.NativeControl.ResetBackgroundColor();
                    else
                        Handler.NativeControl.BackgroundColor = backgroundColor.Value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the foreground color for the control.
        /// </summary>
        public virtual Color? ForegroundColor
        {
            get
            {
                return foregroundColor;
            }

            set
            {
                if (foregroundColor == value)
                    return;
                foregroundColor = value;

                if (Handler.NativeControl is not null)
                {
                    if (foregroundColor is null)
                        Handler.NativeControl.ResetForegroundColor();
                    else
                        Handler.NativeControl.ForegroundColor = foregroundColor.Value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the background brush for the control.
        /// </summary>
        [Browsable(false)]
        public virtual Brush? Background
        {
            get => background;
            set
            {
                if (background == value)
                    return;

                background = value;
                BackgroundChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the foreground brush for the control.
        /// </summary>
        [Browsable(false)]
        public virtual Brush? Foreground
        {
            get => foreground;
            set
            {
                if (foreground == value)
                    return;

                foreground = value;
                ForegroundChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The <see cref="Font"/> to apply to the text displayed by
        /// the control. The default is the value of <c>null</c>.</value>
        public virtual Font? Font
        {
            get => font;
            set
            {
                if (font == value)
                    return;

                font = value;
                FontChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the vertical alignment applied to this control when it
        /// is positioned within a parent control.
        /// </summary>
        /// <value>A vertical alignment setting. The default is
        /// <see cref="VerticalAlignment.Stretch"/>.</value>
        public virtual VerticalAlignment VerticalAlignment
        {
            get => verticalAlignment;
            set
            {
                if (verticalAlignment == value)
                    return;

                verticalAlignment = value;
                VerticalAlignmentChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the horizontal alignment applied to this control when
        /// it is positioned within a parent control.
        /// </summary>
        /// <value>A horizontal alignment setting. The default is
        /// <see cref="HorizontalAlignment.Stretch"/>.</value>
        public virtual HorizontalAlignment HorizontalAlignment
        {
            get => horizontalAlignment;
            set
            {
                if (horizontalAlignment == value)
                    return;

                horizontalAlignment = value;
                HorizontalAlignmentChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the user can give the focus to this control
        /// using the TAB key.
        /// </summary>
        public virtual bool TabStop
        {
            get => Handler.TabStop;
            set => Handler.TabStop = value;
        }

        /// <summary>
        /// Returns rectangle in which custom drawing need to be performed.
        /// Useful for custom draw controls
        /// </summary>
        [Browsable(false)]
        public virtual Rect DrawClientRectangle
        {
            get
            {
                var size = ClientSize;
                return new(0, 0, size.Width - 1, size.Height - 1);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control can accept data
        /// that the user drags onto it.
        /// </summary>
        /// <value><c>true</c> if drag-and-drop operations are allowed in the
        /// control; otherwise, <c>false</c>. The default is <c>false</c>.</value>
        [Browsable(false)]
        public virtual bool AllowDrop
        {
            get
            {
                return Handler.AllowDrop;
            }

            set
            {
                Handler.AllowDrop = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the control has input focus.
        /// </summary>
        [Browsable(false)]
        public virtual bool IsFocused => Handler.IsFocused;

        /// <summary>
        /// Returns control identifier.
        /// </summary>
        [Browsable(false)]
        public virtual ControlId ControlKind => ControlId.Control;

        internal static int ScreenShotCounter { get; set; } = 0;

        internal IntPtr WxWidget => Handler.NativeControl!.WxWidget;

        internal virtual bool IsDummy => false;

        internal Thickness MinMargin
        {
            get
            {
                if (minMargin == null)
                {
                    minMargin = AllPlatformDefaults.
                        GetAsThickness(ControlKind, ControlDefaultsId.MinMargin);
                }

                return minMargin.Value;
            }
        }

        internal Thickness MinPadding
        {
            get
            {
                if (minPadding == null)
                {
                    minPadding = AllPlatformDefaults.
                        GetAsThickness(ControlKind, ControlDefaultsId.MinPadding);
                }

                return minPadding.Value;
            }
        }

        internal bool HasExtendedProps => extendedProps != null;

        internal ControlExtendedProps ExtendedProps
        {
            get
            {
                extendedProps ??= new();
                return extendedProps;
            }
        }

        /// <inheritdoc />
        protected override IEnumerable<FrameworkElement> LogicalChildrenCollection
            => HasChildren ? Children : Array.Empty<FrameworkElement>();

        private IControlHandlerFactory? ControlHandlerFactory { get; set; }

        /// <summary>
        /// Returns the currently focused control, or <see langword="null"/> if
        /// no control is focused.
        /// </summary>
        public static Control? GetFocusedControl()
        {
            return ControlHandler.GetFocusedControl();
        }

        /// <summary>
        /// Gets the subset of <see cref="Children"/> collection with
        /// child controls of specific type.
        /// </summary>
        /// <remarks>
        /// This method is useful, for example, when you need to get
        /// all <see cref="Button"/> or <see cref="CheckBox"/> child controls.
        /// </remarks>
        public IEnumerable<T> ChildrenOfType<T>()
        {
            if(HasChildren)
                return Children.OfType<T>();
            return Array.Empty<T>();
        }

        /// <summary>
        /// Executes a delegate asynchronously on the thread that the control
        /// was created on.
        /// </summary>
        /// <param name="method">A delegate to a method that takes parameters
        /// of the same number and type that are contained in the args parameter.</param>
        /// <param name="args">An array of objects to pass as arguments to the
        /// given method. This can be <c>null</c> if no arguments are needed.</param>
        /// <returns>An <see cref="IAsyncResult"/> that represents the result
        /// of the operation.</returns>
        public IAsyncResult BeginInvoke(Delegate method, object?[] args)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            return SynchronizationService.BeginInvoke(method, args);
        }

        /// <summary>
        /// Executes a delegate asynchronously on the thread that the control
        /// was created on.
        /// </summary>
        /// <param name="method">A delegate to a method that takes no
        /// parameters.</param>
        /// <returns>An <see cref="IAsyncResult"/> that represents the result of
        /// the operation.</returns>
        public IAsyncResult BeginInvoke(Delegate method)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            return BeginInvoke(method, Array.Empty<object>());
        }

        /// <summary>
        /// Executes an action asynchronously on the thread that the control
        /// was created on.
        /// </summary>
        /// <param name="action">An action to execute.</param>
        /// <returns>An <see cref="IAsyncResult"/> that represents the result
        /// of the operation.</returns>
        public IAsyncResult BeginInvoke(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            return BeginInvoke(action, Array.Empty<object>());
        }

        /// <summary>
        /// Retrieves the return value of the asynchronous operation represented
        /// by the <see cref="IAsyncResult"/> passed.
        /// </summary>
        /// <param name="result">The <see cref="IAsyncResult"/> that represents
        /// a specific invoke asynchronous operation, returned when calling
        /// <see cref="BeginInvoke(Delegate)"/>.</param>
        /// <returns>The <see cref="object"/> generated by the
        /// asynchronous operation.</returns>
        public object? EndInvoke(IAsyncResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            return SynchronizationService.EndInvoke(result);
        }

        /// <summary>
        /// Executes the specified delegate, on the thread that owns the control,
        /// with the specified list of arguments.
        /// </summary>
        /// <param name="method">A delegate to a method that takes parameters of
        /// the same number and type that are contained in the
        /// <c>args</c> parameter.</param>
        /// <param name="args">An array of objects to pass as arguments to
        /// the specified method. This parameter can be <c>null</c> if the
        /// method takes no arguments.</param>
        /// <returns>An <see cref="object"/> that contains the return value
        /// from the delegate being invoked, or <c>null</c> if the delegate has
        /// no return value.</returns>
        public object? Invoke(Delegate method, object?[] args)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            return SynchronizationService.Invoke(method, args);
        }

        /// <summary>
        /// Executes the specified delegate on the thread that owns the control.
        /// </summary>
        /// <param name="method">A delegate that contains a method to be called
        /// in the control's thread context.</param>
        /// <returns>An <see cref="object"/> that contains the return value from
        /// the delegate being invoked, or <c>null</c> if the delegate has no
        /// return value.</returns>
        public object? Invoke(Delegate method)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            return Invoke(method, Array.Empty<object>());
        }

        /// <summary>
        /// Executes the specified action on the thread that owns the control.
        /// </summary>
        /// <param name="action">An action to be called in the control's
        /// thread context.</param>
        public void Invoke(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            Invoke(action, Array.Empty<object>());
        }

        /// <summary>
        /// Captures the mouse to the control.
        /// </summary>
        public void CaptureMouse()
        {
            Handler?.CaptureMouse();
        }

        /// <summary>
        /// Releases the mouse capture, if the control held the capture.
        /// </summary>
        public void ReleaseMouseCapture()
        {
            Handler?.ReleaseMouseCapture();
        }

        /// <summary>
        /// Raises the <see cref="Click"/> event and calls
        /// <see cref="OnClick(EventArgs)"/>.
        /// See <see cref="Click"/> event description for more details.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event
        /// data.</param>
        public virtual void RaiseClick(EventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            OnClick(e);
            Click?.Invoke(this, e);
        }

        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        /// <remarks>Showing the control is equivalent to setting the
        /// <see cref="Visible"/> property to <c>true</c>.
        /// After the <see cref="Show"/> method is called, the
        /// <see cref="Visible"/> property
        /// returns a value of <c>true</c> until the <see cref="Hide"/> method
        /// is called.</remarks>
        public void Show() => Visible = true;

        /// <summary>
        /// Gets the child control at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the child control
        /// to get.</param>
        /// <returns>The child control at the specified index in the
        /// <see cref="Children"/> list.</returns>
        public Control? GetChildOrNull(int index = 0)
        {
            if (!HasChildren)
                return null;
            if (index >= Children.Count || index < 0)
                return null;
            return Children[index];
        }

        /// <summary>
        /// Returns enumeration with the list of visible child controls.
        /// </summary>
        /// <seealso cref="GetVisibleChildOrNull"/>
        public IEnumerable<Control> GetVisibleChildren()
        {
            if(HasChildren)
                return Children.Where(x => x.Visible);
            return Array.Empty<Control>();
        }

        /// <summary>
        /// Gets the child control at the specified index in the
        /// list of visible child controls.
        /// </summary>
        /// <param name="index">The zero-based index of the child control
        /// to get.</param>
        /// <returns>The child control at the specified index in the
        /// visible child controls list.</returns>
        /// <seealso cref="GetVisibleChildren"/>
        public Control? GetVisibleChildOrNull(int index = 0)
        {
            var childs = GetVisibleChildren();
            foreach (Control control in childs)
            {
                if (!control.Visible)
                    continue;
                if(index == 0)
                    return control;
                index--;
            }

            return null;
        }

        /// <summary>
        /// Conceals the control from the user.
        /// </summary>
        /// <remarks>
        /// Hiding the control is equivalent to setting the
        /// <see cref="Visible"/> property to <c>false</c>.
        /// After the <see cref="Hide"/> method is called, the
        /// <see cref="Visible"/> property
        /// returns a value of <c>false</c> until the <see cref="Show"/> method
        /// is called.
        /// </remarks>
        public void Hide() => Visible = false;

        /// <summary>
        /// Creates the <see cref="DrawingContext"/> for the control.
        /// </summary>
        /// <returns>The <see cref="DrawingContext"/> for the control.</returns>
        /// <remarks>
        /// The <see cref="DrawingContext"/> object that you retrieve through the
        /// <see cref="CreateDrawingContext"/> method should not normally
        /// be retained after the current UI event has been processed,
        /// because anything painted
        /// with that object will be erased with the next paint event. Therefore
        /// you cannot cache
        /// the <see cref="DrawingContext"/> object for reuse, except to use
        /// non-visual methods like
        /// <see cref="DrawingContext.MeasureText(string, Font)"/>.
        /// Instead, you must call <see cref="CreateDrawingContext"/> every time
        /// that you want to use the <see cref="DrawingContext"/> object,
        /// and then call <see cref="Dispose()"/> when you are finished using it.
        /// </remarks>
        public DrawingContext CreateDrawingContext() =>
            Handler.CreateDrawingContext();

        /// <summary>
        /// Invalidates the control and causes a paint message to be sent to
        /// the control.
        /// </summary>
        public void Invalidate() => Handler?.Invalidate();

        /// <summary>
        /// Causes the control to redraw the invalidated regions.
        /// </summary>
        public void Update() => Handler?.Update();

        /// <summary>
        /// Sets the specified bounds of the control to the specified
        /// location and size.
        /// </summary>
        /// <param name="x">The new <see cref="Left"/> property value of
        /// the control.</param>
        /// <param name="y">The new <see cref="Top"/> property value
        /// of the control.</param>
        /// <param name="width">The new <see cref="Width"/> property value
        /// of the control.</param>
        /// <param name="height">The new <see cref="Height"/> property value
        /// of the control.</param>
        /// <param name="specified">The new Width property value
        /// of the control.</param>
        public void SetBounds(
            double x,
            double y,
            double width,
            double height,
            BoundsSpecified specified)
        {
            var bounds = Bounds;
            Rect result = new(x, y, width, height);

            if ((specified & BoundsSpecified.X) == 0)
                result.X = bounds.X;

            if ((specified & BoundsSpecified.Y) == 0)
                result.Y = bounds.Y;

            if ((specified & BoundsSpecified.Width) == 0)
                result.Width = bounds.Width;

            if ((specified & BoundsSpecified.Height) == 0)
                result.Height = bounds.Height;

            if (result != bounds)
                Handler.Bounds = result;
        }

        /// <summary>
        /// Forces the control to invalidate itself and immediately redraw itself
        /// and any child controls.
        /// </summary>
        public virtual void Refresh() => Handler?.Refresh();

        /// <summary>
        /// Temporarily suspends the layout logic for the control.
        /// </summary>
        /// <remarks>
        /// The layout logic of the control is suspended until the
        /// <see cref="ResumeLayout"/> method is called.
        /// <para>
        /// The <see cref="SuspendLayout"/> and <see cref="ResumeLayout"/>
        /// methods are used in tandem to suppress
        /// multiple layouts while you adjust multiple attributes of the control.
        /// For example, you would typically call the
        /// <see cref="SuspendLayout"/> method, then set some
        /// properties of the control, or add child controls to it, and then
        /// call the <see cref="ResumeLayout"/>
        /// method to enable the changes to take effect.
        /// </para>
        /// </remarks>
        public void SuspendLayout()
        {
            Handler?.SuspendLayout();
        }

        /// <summary>
        /// Converts the screen coordinates of a specified point on the screen
        /// to client-area coordinates.
        /// </summary>
        /// <param name="point">A <see cref="Point"/> that specifies the
        /// screen coordinates to be converted.</param>
        /// <returns>The converted cooridnates.</returns>
        public Point ScreenToClient(Point point)
        {
            return Handler.ScreenToClient(point);
        }

        /// <summary>
        /// Converts the client-area coordinates of a specified point to
        /// screen coordinates.
        /// </summary>
        /// <param name="point">A <see cref="Point"/> that contains the
        /// client coordinates to be converted.</param>
        /// <returns>The converted cooridnates.</returns>
        public Point ClientToScreen(Point point)
        {
            return Handler.ClientToScreen(point);
        }

        /// <summary>
        /// Converts the screen coordinates of a specified point in
        /// device-independent units (1/96th inch per unit) to device (pixel) coordinates.
        /// </summary>
        /// <param name="point">A <see cref="Point"/> that specifies the
        /// screen device-independent coordinates to be converted.</param>
        /// <returns>The converted cooridnates.</returns>
        public Int32Point ScreenToDevice(Point point)
        {
            return Handler.ScreenToDevice(point);
        }

        /// <summary>
        /// Converts the device (pixel) coordinates of a specified point
        /// to coordinates in device-independent units (1/96th inch per unit).
        /// </summary>
        /// <param name="point">A <see cref="Point"/> that contains the coordinates
        /// in device-independent units (1/96th inch per unit) to be converted.</param>
        /// <returns>The converted cooridnates.</returns>
        public Point DeviceToScreen(Int32Point point)
        {
            return Handler.DeviceToScreen(point);
        }

        /// <summary>
        /// Resumes the usual layout logic.
        /// </summary>
        /// <param name="performLayout"><c>true</c> to execute pending
        /// layout requests; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// Resumes the usual layout logic after <see cref="SuspendLayout"/> has
        /// been called.
        /// When the <c>performLayout</c> parameter is set to <c>true</c>,
        /// an immediate layout occurs.
        /// <para>
        /// The <see cref="SuspendLayout"/> and <see cref="ResumeLayout"/> methods
        /// are used in tandem to suppress
        /// multiple layouts while you adjust multiple attributes of the control.
        /// For example, you would typically call the
        /// <see cref="SuspendLayout"/> method, then set some
        /// properties of the control, or add child controls to it, and then call
        /// the <see cref="ResumeLayout"/>
        /// method to enable the changes to take effect.
        /// </para>
        /// </remarks>
        public void ResumeLayout(bool performLayout = true)
        {
            Handler?.ResumeLayout(performLayout);
            if (performLayout)
                PerformLayout();
        }

        /// <summary>
        /// Maintains performance while performing slow operations on a control
        /// by preventing the control from
        /// drawing until the <see cref="EndUpdate"/> method is called.
        /// </summary>
        public void BeginUpdate()
        {
            Handler?.BeginUpdate();
        }

        /// <summary>
        /// Resumes painting the control after painting is suspended by the
        /// <see cref="BeginUpdate"/> method.
        /// </summary>
        public void EndUpdate()
        {
            Handler?.EndUpdate();
        }

        /// <summary>
        /// Forces the control to apply layout logic to child controls.
        /// </summary>
        /// <remarks>
        /// If the <see cref="SuspendLayout"/> method was called before calling
        /// the <see cref="PerformLayout"/> method,
        /// the layout is suppressed.
        /// </remarks>
        public void PerformLayout()
        {
            Handler?.PerformLayout();
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can
        /// be fitted, in device-independent units (1/96th inch per unit).
        /// </summary>
        /// <param name="availableSize">The available space that a parent element
        /// can allocate a child control.</param>
        /// <returns>A <see cref="Size"/> representing the width and height of
        /// a rectangle, in device-independent units (1/96th inch per unit).</returns>
        public virtual Size GetPreferredSize(Size availableSize)
        {
            return Handler.GetPreferredSize(availableSize);
        }

        /// <summary>
        /// Starts the initialization process for this control.
        /// </summary>
        /// <remarks>
        /// Runtime environments and design tools can use this method to start
        /// the initialization of a control.
        /// The <see cref="EndInit"/> method ends the initialization. Using the
        /// <see cref="BeginInit"/> and <see cref="EndInit"/> methods
        /// prevents the control from being used before it is fully initialized.
        /// </remarks>
        public virtual void BeginInit()
        {
            SuspendLayout();
            Handler?.BeginInit();
        }

        /// <summary>
        /// Ends the initialization process for this control.
        /// </summary>
        /// <remarks>
        /// Runtime environments and design tools can use this method to end
        /// the initialization of a control.
        /// The <see cref="BeginInit"/> method starts the initialization. Using
        /// the <see cref="BeginInit"/> and <see cref="EndInit"/> methods
        /// prevents the control from being used before it is fully initialized.
        /// </remarks>
        public virtual void EndInit()
        {
            Handler?.EndInit();
            ResumeLayout();
        }

        /// <summary>
        /// Sets input focus to the control.
        /// </summary>
        /// <returns><see langword="true"/> if the input focus request was
        /// successful; otherwise, <see langword="false"/>.</returns>
        /// <remarks>The <see cref="SetFocus"/> method returns true if the
        /// control successfully received input focus.</remarks>
        public bool SetFocus()
        {
            return Handler.SetFocus();
        }

        /// <summary>
        /// Saves screenshot of this control.
        /// </summary>
        /// <param name="fileName">Name of the file to which screenshot
        /// will be saved.</param>
        /// <remarks>This function works only on Windows.</remarks>
        public void SaveScreenshot(string fileName)
        {
            Handler?.SaveScreenshot(fileName);
        }

        /// <summary>
        /// Pops up the given menu at the specified coordinates, relative to this window,
        /// and returns control when the user has dismissed the menu.
        /// </summary>
        /// <remarks>
        /// If a menu item is selected, the corresponding menu event is generated and will
        /// be processed as usual. If coordinates are not specified (-1,-1), the current
        /// mouse cursor position is used.
        /// </remarks>
        /// <remarks>
        /// It is recommended to not explicitly specify coordinates when calling PopupMenu
        /// in response to mouse click, because some of the ports(namely, on Linux)
        /// can do a better job of positioning the menu in that case.
        /// </remarks>
        /// <param name="menu">The menu to pop up.</param>
        /// <param name="x">The X position where the menu will appear.</param>
        /// <param name="y">The Y position where the menu will appear.</param>
        public void ShowPopupMenu(Menu menu, int x = -1, int y = -1)
        {
            Handler.ShowPopupMenu(menu, x, y);
        }

        /// <summary>
        /// Focuses the next control.
        /// </summary>
        /// <param name="forward"><see langword="true"/> to move forward in the
        /// tab order; <see langword="false"/> to move backward in the tab
        /// order.</param>
        /// <param name="nested"><see langword="true"/> to include nested
        /// (children of child controls) child controls; otherwise,
        /// <see langword="false"/>.</param>
        public void FocusNextControl(bool forward = true, bool nested = true)
        {
            Handler?.FocusNextControl(forward, nested);
        }

        /// <summary>
        /// Releases all resources used by the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Begins a drag-and-drop operation.
        /// </summary>
        /// <remarks>
        /// Begins a drag operation. The <paramref name="allowedEffects"/>
        /// determine which drag operations can occur.
        /// </remarks>
        /// <param name="data">The data to drag.</param>
        /// <param name="allowedEffects">One of the
        /// <see cref="DragDropEffects"/> values.</param>
        /// <returns>
        /// A value from the <see cref="DragDropEffects"/> enumeration that
        /// represents the final effect that was
        /// performed during the drag-and-drop operation.
        /// </returns>
        public DragDropEffects DoDragDrop(object data, DragDropEffects allowedEffects)
        {
            return Handler.DoDragDrop(data, allowedEffects);
        }

        /// <summary>
        /// Forces the re-creation of the underlying native control.
        /// </summary>
        public void RecreateWindow()
        {
            Handler?.NativeControl?.RecreateWindow();
        }

        /// <summary>
        /// Returns the DPI of the display used by this control.
        /// </summary>
        /// <remarks>
        /// The returned value is different for different windows on
        /// systems with support for per-monitor DPI values,
        /// such as Microsoft Windows.
        /// </remarks>
        /// <returns>
        /// A <see cref="Size"/> value that represents DPI of the display
        /// used by this control. If the DPI is not available,
        /// returns Size(0,0) object.
        /// </returns>
        public Size GetDPI()
        {
            if(Handler != null)
                return Handler.GetDPI();
            if (Parent != null)
                return Parent.GetDPI();
            throw new NotSupportedException();
        }

        /// <summary>
        /// Performs some action for the each child of the control.
        /// </summary>
        /// <typeparam name="T">Specifies type of the child control.</typeparam>
        /// <param name="action">Specifies action which will be called for the
        /// each child.</param>
        public void ForEachChild<T>(Action<T> action)
        {
            foreach (var child in ChildrenOfType<T>())
                action(child);
        }

        /// <summary>
        /// Disable control recreate when properties that require control
        /// recreation are changed.
        /// </summary>
        public void BeginIgnoreRecreate()
        {
            Handler?.BeginIgnoreRecreate();
        }

        /// <summary>
        /// Enable control recreate if it's required after it was previously
        /// disabled by <see cref="BeginIgnoreRecreate"/>
        /// </summary>
        public void EndIgnoreRecreate()
        {
            Handler?.EndIgnoreRecreate();
        }

        internal static void NotifyCaptureLost()
        {
            Native.Control.NotifyCaptureLost();
        }

        internal static void OnVisualStatePropertyChanged(
            Control control,
            DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException(); // yezo
        }

        /// <summary>
        /// Forces the re-creation of the handler for the control.
        /// </summary>
        /// <remarks>
        /// The <see cref="RecreateHandler"/> method is called whenever
        /// re-execution of handler creation logic is needed.
        /// For example, this may happen when visual theme changes.
        /// </remarks>
        internal void RecreateHandler()
        {
            if (handler != null)
                DetachHandler();

            Invalidate();
        }

        internal void RaiseSizeChanged(EventArgs e) => OnSizeChanged(e);

        internal void RaiseLocationChanged(EventArgs e) => OnLocationChanged(e);

        internal void RaiseMouseCaptureLost()
        {
            OnMouseCaptureLost();
            MouseCaptureLost?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseMouseEnter()
        {
            OnMouseEnter();
            MouseEnter?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseMouseLeave()
        {
            OnMouseLeave();
            MouseLeave?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseChildInserted(Control childControl) =>
            OnChildInserted(childControl);

        internal void RaiseChildRemoved(Control childControl) =>
            OnChildInserted(childControl);

        internal void InvokeOnLayout()
        {
            OnLayout();
        }

        internal void RaisePaint(PaintEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            OnPaint(e);
            Paint?.Invoke(this, e);
        }

        internal void SetParentInternal(Control? value)
        {
            parent = value;
            LogicalParent = value;
        }

        internal void RaiseDragDrop(DragEventArgs e) => OnDragDrop(e);

        internal void RaiseDragOver(DragEventArgs e) => OnDragOver(e);

        internal void RaiseDragEnter(DragEventArgs e) => OnDragEnter(e);

        internal void RaiseDragLeave(EventArgs e) => OnDragLeave(e);

        internal void SendMouseDownEvent(int x, int y)
        {
            Handler?.NativeControl?.SendMouseDownEvent(x, y);
        }

        internal void SendMouseUpEvent(int x, int y)
        {
            Handler?.NativeControl?.SendMouseUpEvent(x, y);
        }

        /// <summary>
        /// Ensures that the control <see cref="Handler"/> is created,
        /// creating and attaching it if necessary.
        /// </summary>
        protected internal void EnsureHandlerCreated()
        {
            if (handler == null)
            {
                CreateAndAttachHandler();
            }
        }

        /// <summary>
        /// Disconnects the current control <see cref="Handler"/> from
        /// the control.
        /// This method calls <see cref="ControlHandler.Detach"/>.
        /// </summary>
        protected internal void DetachHandler()
        {
            if (handler == null)
                throw new InvalidOperationException();
            OnHandlerDetaching(EventArgs.Empty);
            handler.Detach();
            handler = null;
        }

        /// <summary>
        /// Raises the <see cref="SizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event
        /// data.</param>
        protected virtual void OnSizeChanged(EventArgs e) =>
            SizeChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the <see cref="LocationChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the
        /// event data.</param>
        protected virtual void OnLocationChanged(EventArgs e) =>
            LocationChanged?.Invoke(this, e);

        /// <summary>
        /// Called when the control should reposition the child controls of
        /// the control.
        /// </summary>
        protected virtual void OnLayout()
        {
            Handler?.OnLayout();
            RaiseLayoutUpdated();
        }

        /// <summary>
        /// Called when a <see cref="Control"/> is inserted into
        /// the <see cref="Control.Children"/> or
        /// <see cref="ControlHandler.VisualChildren"/> collection.
        /// </summary>
        protected virtual void OnChildInserted(Control childControl)
        {
        }

        /// <summary>
        /// Called when a <see cref="Control"/> is removed from the
        /// <see cref="Control.Children"/> or
        /// <see cref="ControlHandler.VisualChildren"/> collections.
        /// </summary>
        protected virtual void OnChildRemoved(Control childControl)
        {
        }

        /// <summary>
        /// Called when the control is clicked.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event
        /// data.</param>
        protected virtual void OnClick(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="Visible"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event
        /// data.</param>
        protected virtual void OnVisibleChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the control loses mouse capture.
        /// </summary>
        protected virtual void OnMouseCaptureLost()
        {
        }

        /// <summary>
        /// Called when the mouse pointer enters the control.
        /// </summary>
        protected virtual void OnMouseEnter()
        {
        }

        /// <summary>
        /// Called when the mouse pointer leaves the control.
        /// </summary>
        protected virtual void OnMouseLeave()
        {
        }

        /// <summary>
        /// Called before the current control handler is detached.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the
        /// event data.</param>
        protected virtual void OnHandlerDetaching(EventArgs e)
        {
        }

        /// <summary>
        /// Gets an <see cref="IControlHandlerFactory"/> to use when creating
        /// new control handlers for this control.
        /// </summary>
        protected IControlHandlerFactory GetEffectiveControlHandlerHactory() =>
            ControlHandlerFactory ??
                Application.Current.VisualTheme.ControlHandlerFactory;

        /// <summary>
        /// Creates a handler for the control.
        /// </summary>
        /// <remarks>
        /// You typically should not call the <see cref="CreateHandler"/>
        /// method directly.
        /// The preferred method is to call the
        /// <see cref="EnsureHandlerCreated"/> method, which forces a handler
        /// to be created for the control.
        /// </remarks>
        protected virtual ControlHandler CreateHandler()
        {
            return new GenericControlHandler();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the object and
        /// optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and
        /// unmanaged resources; <c>false</c> to release only unmanaged
        /// resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                Disposed?.Invoke(this, EventArgs.Empty);

                if (disposing)
                {
                    /*var children = Handler.AllChildren.ToArray();*/

                    SuspendLayout();
                    if(HasChildren)
                        Children.Clear();
                    if(Handler.HasVisualChildren)
                        Handler.VisualChildren.Clear();
                    ResumeLayout(performLayout: false);

                    // TODO
                    /* foreach (var child in children) child.Dispose();*/

                    DetachHandler();
                }

                IsDisposed = true;
            }
        }

        /// <summary>
        /// Throws <see cref="ObjectDisposedException"/> if
        /// <see cref="IsDisposed"/> is <c>true</c>.
        /// </summary>
        protected void CheckDisposed()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(null);
        }

        /// <summary>
        /// Called when the value of the <see cref="Margin"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the
        /// event data.</param>
        protected virtual void OnMarginChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the value of the <see cref="Padding"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event
        /// data.</param>
        protected virtual void OnPaddingChanged(EventArgs e)
        {
        }

        /// <summary>
        /// Called when the control is redrawn. See <see cref="Paint"/> for details.
        /// </summary>
        /// <param name="e">An <see cref="PaintEventArgs"/> that contains the
        /// event data.</param>
        protected virtual void OnPaint(PaintEventArgs e)
        {
        }

        /// <summary>
        /// Called after a new control handler is attached.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event
        /// data.</param>
        protected virtual void OnHandlerAttached(EventArgs e)
        {
        }

        /// <summary>
        /// Raises the <see cref="DragDrop"/> event.
        /// </summary>
        /// <param name="e">The <see cref="DragEventArgs"/> that contains the
        /// event data.</param>
        protected virtual void OnDragDrop(DragEventArgs e) =>
            DragDrop?.Invoke(this, e);

        /// <summary>
        /// Raises the <see cref="DragOver"/> event.
        /// </summary>
        /// <param name="e">The <see cref="DragEventArgs"/> that contains the
        /// event data.</param>
        protected virtual void OnDragOver(DragEventArgs e) =>
            DragOver?.Invoke(this, e);

        /// <summary>
        /// Raises the <see cref="DragEnter"/> event.
        /// </summary>
        /// <param name="e">The <see cref="DragEventArgs"/>
        /// that contains the event data.</param>
        protected virtual void OnDragEnter(DragEventArgs e) =>
            DragEnter?.Invoke(this, e);

        /// <summary>
        /// Raises the <see cref="DragLeave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> that
        /// contains the event data.</param>
        protected virtual void OnDragLeave(EventArgs e) => DragLeave?.Invoke(this, e);

        /// <summary>
        /// Raises the <see cref="ToolTipChanged"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnToolTipChanged(EventArgs e)
        {
            ToolTipChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Called when the enabled of the <see cref="Enabled"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the
        /// event data.</param>
        protected virtual void OnEnabledChanged(EventArgs e)
        {
        }

        private protected override bool GetIsEnabled() => Enabled;

        private protected void SetVisibleValue(bool value) => visible = value;

        /// <summary>
        /// Callback for changes to the Enabled property
        /// </summary>
        private static void OnEnabledPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            Control control = (Control)d;
            control?.OnEnabledPropertyChanged((bool)e.OldValue, (bool)e.NewValue);
        }

        /// <summary>
        /// Callback for changes to the ToolTip property
        /// </summary>
        private static void OnToolTipPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            Control c = (Control)d;
            c?.OnToolTipPropertyChanged((string)e.OldValue, (string)e.NewValue);
        }

        private void CreateAndAttachHandler()
        {
            handler = CreateHandler();
            handler?.Attach(this);
            OnHandlerAttached(EventArgs.Empty);
        }

        private void Children_ItemInserted(object? sender, int index, Control item)
        {
            item.SetParentInternal(this);
        }

        private void Children_ItemRemoved(object? sender, int index, Control item)
        {
            item.SetParentInternal(null);
        }

#pragma warning disable
        private void OnToolTipPropertyChanged(string oldToolTip, string newToolTip)
#pragma warning restore
        {
            OnToolTipChanged(EventArgs.Empty);
        }

        /// <summary>
        /// Raises the <see cref="EnabledChanged"/> event and calls
        /// <see cref="OnEnabledChanged(EventArgs)"/>.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the
        /// event data.</param>
        private void RaiseEnabledChanged(EventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            OnEnabledChanged(e);
            EnabledChanged?.Invoke(this, e);
        }

#pragma warning disable IDE0060 // Remove unused parameter
        private void OnEnabledPropertyChanged(bool oldValue, bool newValue)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            RaiseEnabledChanged(EventArgs.Empty);
        }
    }
}