using System;
using System.ComponentModel;
using System.Linq;

namespace Alternet.UI
{
    internal class NativeWindowHandler : NativeControlHandler<Window, Native.Window>
    {
        internal override Native.Control CreateNativeControl()
        {
            return new Native.Window();
        }

        protected override void OnAttach()
        {
            base.OnAttach();

            ApplyTitle();
            ApplyShowInTaskbar();
            ApplyOwner();
            ApplyMaximizeEnabled();
            ApplyMinimizeEnabled();
            ApplyCloseEnabled();
            ApplyAlwaysOnTop();
            ApplyIsToolWindow();
            ApplyResizable();
            ApplyHasBorder();
            ApplyHasTitleBar();
            ApplyState();
            ApplyIcon();

            Control.TitleChanged += Control_TitleChanged;

            Control.ShowInTaskbarChanged += Control_ShowInTaskbarChanged;
            Control.OwnerChanged += Control_OwnerChanged;
            Control.MinimizeEnabledChanged += Control_MinimizeEnabledChanged;
            Control.MaximizeEnabledChanged += Control_MaximizeEnabledChanged;
            Control.CloseEnabledChanged += Control_CloseEnabledChanged;
            Control.AlwaysOnTopChanged += Control_AlwaysOnTopChanged;
            Control.IsToolWindowChanged += Control_IsToolWindowChanged;
            Control.ResizableChanged += Control_ResizableChanged;
            Control.HasBorderChanged += Control_HasBorderChanged;
            Control.HasTitleBarChanged += Control_HasTitleBarChanged;

            Control.StateChanged += Control_StateChanged;
            Control.IconChanged += Control_IconChanged;

            NativeControl.Closing += Control_Closing;
            NativeControl.SizeChanged += NativeControl_SizeChanged;
            NativeControl.Activated += NativeControl_Activated;
            NativeControl.Deactivated += NativeControl_Deactivated;
            NativeControl.StateChanged += NativeControl_StateChanged;
        }

        private void Control_IconChanged(object? sender, EventArgs e)
        {
            ApplyIcon();
        }

        private void NativeControl_StateChanged(object? sender, EventArgs e)
        {
            Control.State = (WindowState)NativeControl.State;
        }

        private void Control_StateChanged(object? sender, EventArgs e)
        {
            ApplyState();
        }

        private void ApplyState()
        {
            NativeControl.State = (Native.WindowState)Control.State;
        }

        private void ApplyIcon()
        {
            NativeControl.Icon = Control.Icon?.NativeImageSet ?? null;
        }

        private void NativeControl_Deactivated(object? sender, EventArgs e)
        {
            Control.RaiseDeactivated();
        }

        private void NativeControl_Activated(object? sender, EventArgs e)
        {
            Control.RaiseActivated();
        }

        public void Activate()
        {
            NativeControl.Activate();
        }

        public bool IsActive => NativeControl.IsActive;

        public static Window? ActiveWindow
        {
            get
            {
                var activeWindow = Native.Window.ActiveWindow;
                if (activeWindow == null)
                    return null;

                var handler = TryGetHandlerByNativeControl(activeWindow) ?? throw new InvalidOperationException();
                return ((NativeWindowHandler)handler).Control;
            }
        }

        /// <summary>
        /// Gets an array of <see cref="Window"/> objects that represent all windows that are owned by this window.
        /// </summary>
        /// <value>
        /// A <see cref="Window"/> array that represents the owned windows for this window.
        /// </value>
        /// <remarks>
        /// This property returns an array that contains all windows that are owned by this window. To make a window owned by another window, set the <see cref="Window.Owner"/> property.
        /// </remarks>
        public Window[] OwnedWindows
        {
            get
            {
                return NativeControl.OwnedWindows.Select(
                    x => ((NativeWindowHandler)(TryGetHandlerByNativeControl(x) ?? throw new Exception())).Control).ToArray();
            }
        }

        private void Control_AlwaysOnTopChanged(object? sender, EventArgs e)
        {
            ApplyAlwaysOnTop();
        }
        
        private void Control_IsToolWindowChanged(object? sender, EventArgs e)
        {
            ApplyIsToolWindow();
        }
        
        private void Control_ResizableChanged(object? sender, EventArgs e)
        {
            ApplyResizable();
        }
        
        private void Control_HasBorderChanged(object? sender, EventArgs e)
        {
            ApplyHasBorder();
        }

        private void Control_HasTitleBarChanged(object? sender, EventArgs e)
        {
            ApplyHasTitleBar();
        }

        private void Control_CloseEnabledChanged(object? sender, EventArgs e)
        {
            ApplyCloseEnabled();
        }

        private void Control_MaximizeEnabledChanged(object? sender, EventArgs e)
        {
            ApplyMaximizeEnabled();
        }

        private void Control_MinimizeEnabledChanged(object? sender, EventArgs e)
        {
            ApplyMinimizeEnabled();
        }

        private void ApplyOwner()
        {
            var newOwner = Control.Owner?.Handler?.NativeControl;
            var oldOwner = NativeControl.ParentRefCounted;
            if (newOwner == oldOwner)
                return;

            if (oldOwner != null)
                oldOwner.RemoveChild(NativeControl);

            if (newOwner == null)
                return;

            newOwner.AddChild(NativeControl);
        }

        private void Control_OwnerChanged(object? sender, EventArgs e)
        {
            ApplyOwner();
        }

        private void Control_ShowInTaskbarChanged(object? sender, EventArgs e)
        {
            if (e is null)
                throw new System.ArgumentNullException(nameof(e));

            ApplyShowInTaskbar();
        }

        private void ApplyShowInTaskbar()
        {
            NativeControl.ShowInTaskbar = Control.ShowInTaskbar;
        }

        private void ApplyMinimizeEnabled()
        {
            NativeControl.MinimizeEnabled = Control.MinimizeEnabled;
        }

        private void ApplyMaximizeEnabled()
        {
            NativeControl.MaximizeEnabled = Control.MaximizeEnabled;
        }

        private void ApplyCloseEnabled()
        {
            NativeControl.CloseEnabled = Control.CloseEnabled;
        }

        private void ApplyAlwaysOnTop()
        {
            NativeControl.AlwaysOnTop = Control.AlwaysOnTop;
        }
        private void ApplyIsToolWindow()
        {
            NativeControl.IsToolWindow = Control.IsToolWindow;
        }
        private void ApplyResizable()
        {
            NativeControl.Resizable = Control.Resizable;
        }
        private void ApplyHasBorder()
        {
            NativeControl.HasBorder = Control.HasBorder;
        }
        private void ApplyHasTitleBar()
        {
            NativeControl.HasTitleBar = Control.HasTitleBar;
        }

        private void NativeControl_SizeChanged(object? sender, EventArgs e)
        {
            PerformLayout();
        }

        private void Control_Closing(object? sender, CancelEventArgs? e)
        {
            if (e is null)
                throw new System.ArgumentNullException(nameof(e));

            // todo: add close reason/force parameter (see wxCloseEvent.CanVeto()).
            var closingEventArgs = new WindowClosingEventArgs(e.Cancel);
            Control.RaiseClosing(closingEventArgs);
            if (closingEventArgs.Cancel)
                return;

            Control.RaiseClosed(new WindowClosedEventArgs());
            Control.Dispose();
        }

        protected override void OnDetach()
        {
            NativeControl.SizeChanged -= NativeControl_SizeChanged;
            NativeControl.Closing -= Control_Closing;
            NativeControl.Activated -= NativeControl_Activated;
            NativeControl.Deactivated -= NativeControl_Deactivated;

            Control.OwnerChanged -= Control_OwnerChanged;
            Control.TitleChanged -= Control_TitleChanged;
            Control.ShowInTaskbarChanged -= Control_ShowInTaskbarChanged;
            Control.MinimizeEnabledChanged -= Control_MinimizeEnabledChanged;
            Control.MaximizeEnabledChanged -= Control_MaximizeEnabledChanged;
            Control.CloseEnabledChanged -= Control_CloseEnabledChanged;
            Control.AlwaysOnTopChanged -= Control_AlwaysOnTopChanged;
            Control.IsToolWindowChanged -= Control_IsToolWindowChanged;
            Control.ResizableChanged -= Control_ResizableChanged;
            Control.HasBorderChanged -= Control_HasBorderChanged;
            Control.HasTitleBarChanged -= Control_HasTitleBarChanged;
            Control.StateChanged -= Control_StateChanged;
            Control.IconChanged -= Control_IconChanged;

            base.OnDetach();
        }

        private void Control_TitleChanged(object? sender, System.EventArgs? e)
        {
            if (e is null)
                throw new System.ArgumentNullException(nameof(e));

            ApplyTitle();
        }

        private void ApplyTitle()
        {
            NativeControl.Title = Control.Title;
        }
    }
}