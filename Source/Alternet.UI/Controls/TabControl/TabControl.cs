using System;
using System.Collections.Generic;
using System.ComponentModel;
using Alternet.Base.Collections;

namespace Alternet.UI
{
    /// <summary>
    /// Represents a control that manages a related set of tab pages.
    /// </summary>
    [DefaultProperty("Pages")]
    [DefaultEvent("SelectedPageChanged")]
    public class TabControl : Control
    {
        /// <summary>
        ///     An event fired when the selection changes.
        /// </summary>
        public static readonly RoutedEvent SelectedPageChangedEvent =
            EventManager.RegisterRoutedEvent(
            nameof(SelectedPageChanged),
            RoutingStrategy.Bubble,
            typeof(SelectedTabPageChangedEventHandler),
            typeof(TabControl));

        /// <summary>
        ///     SelectedItem DependencyProperty
        /// </summary>
        public static readonly DependencyProperty SelectedPageProperty =
                DependencyProperty.Register(
                        "SelectedPage",
                        typeof(TabPage),
                        typeof(TabControl),
                        new FrameworkPropertyMetadata(
                                null,
                                PropMetadataOption.BindsTwoWayByDefault,
                                new PropertyChangedCallback(OnSelectedPageChanged),
                                new CoerceValueCallback(CoerceSelectedPage)));

        /// <summary>
        /// Occurs when the <see cref="SelectedPage"/> property has changed.
        /// </summary>
        [Category("Behavior")]
        public event SelectedTabPageChangedEventHandler SelectedPageChanged
        {
            add { AddHandler(SelectedPageChangedEvent, value); }
            remove { RemoveHandler(SelectedPageChangedEvent, value); }
        }

        /// <summary>
        /// Gets a <see cref="TabControlHandler"/> associated with this class.
        /// </summary>
        [Browsable(false)]
        public new TabControlHandler Handler
        {
            get
            {
                CheckDisposed();
                return (TabControlHandler)base.Handler;
            }
        }

        // public event EventHandler<SelectedTabPageChangingEventArgs>? SelectedPageChanging;

        // public void RaiseSelectedPageChanging(SelectedTabPageChangingEventArgs e)
        // {
        //    OnSelectedPageChanging(e);
        //    SelectedPageChanging?.Invoke(this, e);
        // }

        // protected virtual void OnSelectedPageChanging(SelectedTabPageChangingEventArgs e)
        // {
        // }

        /// <summary>
        /// Gets or sets the area of the control (for example, along the top) where
        /// the tabs are aligned.
        /// </summary>
        /// <value>One of the <see cref="TabAlignment"/> values. The default is
        /// <see cref="TabAlignment.Top"/>.</value>
        public TabAlignment TabAlignment
        {
            get => Handler.TabAlignment;
            set
            {
               // Disabled Left and Right as under Windows they are buggy
                if (value == TabAlignment.Left || value == TabAlignment.Right)
                    return;
                Handler.TabAlignment = value;
            }
        }

        /// <inheritdoc/>
        public override ControlId ControlKind => ControlId.TabControl;

        /// <summary>
        /// Gets the collection of tab pages in this tab control.
        /// </summary>
        /// <value>A <see cref="Collection{TabPage}"/> that contains the <see cref="TabPage"/>
        /// objects in this <see cref="TabControl"/>.</value>
        /// <remarks>The order of tab pages in this collection reflects the order the tabs appear
        /// in the control.</remarks>
        [Content]
        public Collection<TabPage> Pages { get; } = new Collection<TabPage>();

        /// <inheritdoc/>
        public override IReadOnlyList<FrameworkElement> ContentElements => Pages;

        /// <summary>
        ///  Gets or sets the currently selected tab page.
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public TabPage? SelectedPage
        {
            get { return (TabPage?)GetValue(SelectedPageProperty); }
            set { SetValue(SelectedPageProperty, value); }
        }

        /// <inheritdoc />
        protected override IEnumerable<FrameworkElement> LogicalChildrenCollection => Pages;

        /// <summary>
        /// A virtual function that is called when the selection is changed. Default behavior
        /// is to raise a SelectedPageChangedEvent
        /// </summary>
        /// <param name="e">The inputs for this event. Can be raised (default behavior) or
        /// processed in some other way.</param>
        protected virtual void OnSelectedPageChanged(SelectedTabPageChangedEventArgs e)
        {
            RaiseEvent(e);
        }

        /// <inheritdoc/>
        protected override ControlHandler CreateHandler()
        {
            return GetEffectiveControlHandlerHactory().CreateTabControlHandler(this);
        }

        private static object CoerceSelectedPage(DependencyObject d, object value)
        {
            // Selector s = (Selector)d;
            // if (value == null || s.SkipCoerceSelectedItemCheck)
            //    return value;

            // int selectedIndex = s.SelectedIndex;

            // if ((selectedIndex > -1 && selectedIndex < s.Items.Count
            // && s.Items[selectedIndex] == value)
            //    || s.Items.Contains(value))
            // {
            //    return value;
            // }
            // return DependencyProperty.UnsetValue;
            return value;
        }

        private static void OnSelectedPageChanged(
           DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            ((TabControl)d).OnSelectedPageChanged(new SelectedTabPageChangedEventArgs(
                SelectedPageChangedEvent,
                d,
                (TabPage?)e.OldValue,
                (TabPage?)e.NewValue));
        }
    }
}