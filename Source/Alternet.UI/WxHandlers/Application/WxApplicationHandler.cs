﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alternet.Drawing;
using Alternet.Drawing.Printing;

namespace Alternet.UI
{
    internal class WxApplicationHandler : DisposableObject, IApplicationHandler
    {
        private static readonly int[] eventIdentifiers = new int[(int)WxEventIdentifiers.Max + 1];
        private static readonly int minEventIdentifier;
        private static readonly WxEventIdentifiers[] eventIdentifierToEnum;
        private static Native.Application nativeApplication;
        private static readonly KeyboardInputProvider keyboardInputProvider;
        private static readonly MouseInputProvider mouseInputProvider;

        static WxApplicationHandler()
        {
            Native.Application.GetEventIdentifiers(eventIdentifiers);

            minEventIdentifier = eventIdentifiers.Min();
            var maxEventIdentifier = eventIdentifiers.Max();
            var length = maxEventIdentifier - minEventIdentifier + 1;
            eventIdentifierToEnum = new WxEventIdentifiers[length];
            for (int i = 0; i < eventIdentifiers.Length; i++)
                eventIdentifierToEnum[eventIdentifiers[i] - minEventIdentifier] = (WxEventIdentifiers)i;

            if (App.SupressDiagnostics)
                Native.Application.SuppressDiagnostics(-1);

            nativeApplication = new Native.Application();
            nativeApplication.Idle = App.RaiseIdle;
            nativeApplication.LogMessage += NativeApplication_LogMessage;
            nativeApplication.Name = Path.GetFileNameWithoutExtension(
                Process.GetCurrentProcess()?.MainModule?.FileName!);

            keyboardInputProvider = new KeyboardInputProvider(
                nativeApplication.Keyboard);
            mouseInputProvider = new MouseInputProvider(nativeApplication.Mouse);

            Keyboard.PrimaryDevice = InputManager.UnsecureCurrent.PrimaryKeyboardDevice;
            Mouse.PrimaryDevice = InputManager.UnsecureCurrent.PrimaryMouseDevice;
        }

        public WxApplicationHandler()
        {
            LogUtils.RegisterLogAction("Use Pless Caret", () => { UsePlessCaret = true; });
        }

        public static bool UsePlessCaret { get; set; } = false;

        public static WxEventIdentifiers MapToEventIdentifier(int eventId)
        {
            var id = eventId - minEventIdentifier;

            if (id < 0 || id >= eventIdentifierToEnum.Length)
                return WxEventIdentifiers.None;

            return eventIdentifierToEnum[id];
        }

        public static int MinEventIdentifier => minEventIdentifier;

        /// <summary>
        /// Allows the programmer to specify whether the application will exit when the
        /// top-level frame is deleted.
        /// Returns true if the application will exit when the top-level frame is deleted.
        /// </summary>
        public bool ExitOnFrameDelete
        {
            get => nativeApplication.GetExitOnFrameDelete();
            set => nativeApplication.SetExitOnFrameDelete(value);
        }

        /// <summary>
        /// Gets whether the application is active, i.e. if one of its windows is currently in
        /// the foreground.
        /// </summary>
        public bool IsActive => nativeApplication.IsActive();

        /// <inheritdoc/>
        public bool InUixmlPreviewerMode
        {
            get => nativeApplication.InUixmlPreviewerMode;
            set => nativeApplication.InUixmlPreviewerMode = value;
        }

        internal static Native.Clipboard NativeClipboard => nativeApplication.Clipboard;

        internal static Native.Keyboard NativeKeyboard => nativeApplication.Keyboard;

        internal static Native.Application NativeApplication => nativeApplication;

        internal static Native.Mouse NativeMouse => nativeApplication.Mouse;

        internal static string EventArgString => nativeApplication.EventArgString;

        public static IntPtr WxWidget(IControl? control)
        {
            if (control is null)
                return default;
            return ((UI.Native.Control)control.NativeControl).WxWidget;
        }

        /// <summary>
        /// Informs all message pumps that they must terminate, and then closes
        /// all application windows after the messages have been processed.
        /// </summary>
        public void Exit()
        {
            nativeApplication.Exit();
        }

        public IControlFactoryHandler CreateControlFactoryHandler()
        {
            return new WxControlFactoryHandler();
        }

        public bool HasPendingEvents()
        {
            return nativeApplication.HasPendingEvents();
        }

        public void Run(Window window)
        {
            nativeApplication.Run(
                ((WindowHandler)window.Handler).NativeControl);
        }

        public IDialogFactoryHandler CreateDialogFactoryHandler()
        {
            return new WxDialogFactoryHandler();
        }

        public IClipboardHandler CreateClipboardHandler()
        {
            return new WxClipboardHandler();
        }


        public void ProcessPendingEvents()
        {
            nativeApplication.ProcessPendingEvents();
        }

        public void ExitMainLoop()
        {
            nativeApplication.ExitMainLoop();
        }

        public void SetTopWindow(Window window)
        {
            nativeApplication.SetTopWindow(WxApplicationHandler.WxWidget(window));
        }

        public void WakeUpIdle()
        {
            nativeApplication.WakeUpIdle();
        }

        public void BeginInvoke(Action action)
        {
            nativeApplication.BeginInvoke(action);
        }

        private static void NativeApplication_LogMessage()
        {
            var s = nativeApplication.EventArgString;

            App.LogNativeMessage(s);
        }

        public ISystemSettingsHandler CreateSystemSettingsHandler()
        {
            return new WxSystemSettingsHandler();
        }

        /// <inheritdoc/>
        public void NotifyCaptureLost()
        {
            Native.Control.NotifyCaptureLost();
        }

        /// <inheritdoc/>
        public Control? GetFocusedControl()
        {
            var focusedNativeControl = Native.Control.GetFocusedControl();
            if (focusedNativeControl == null)
                return null;

            var handler = WxControlHandler.NativeControlToHandler(focusedNativeControl);
            if (handler == null || !handler.IsAttached)
                return null;

            return handler.Control;
        }

        /// <inheritdoc/>
        public Window? GetActiveWindow()
        {
            var activeWindow = Native.Window.ActiveWindow;
            if (activeWindow == null)
                return null;

            var handler = WxControlHandler.NativeControlToHandler(activeWindow) ??
                throw new InvalidOperationException();
            return ((WindowHandler)handler).Control;
        }

        public IPrintingHandler CreatePrintingHandler()
        {
            return new WxPrintingHandler();
        }

        public IGraphicsFactoryHandler CreateGraphicsFactoryHandler()
        {
            return new WxGraphicsFactoryHandler();
        }

        public ICaretHandler CreateCaretHandler()
        {
            if (UsePlessCaret)
                return new PlessCaretHandler();
            return new WxCaretHandler();
        }

        public ICaretHandler CreateCaretHandler(Control control, int width, int height)
        {
            if (UsePlessCaret)
                return new PlessCaretHandler(control, width, height);
            return new WxCaretHandler(control, width, height);
        }

        /// <inheritdoc/>
        public ISoundFactoryHandler CreateSoundFactoryHandler()
        {
            return new WxSoundFactoryHandler();
        }

        /// <inheritdoc/>
        public bool InvokeRequired => nativeApplication.InvokeRequired;

        /// <inheritdoc/>
        public IControlPainterHandler CreateControlPainterHandler()
        {
            return new WxControlPainterHandler();
        }

        /// <inheritdoc/>
        public IMemoryHandler CreateMemoryHandler()
        {
            return new WxMemoryHandler();
        }

        /// <inheritdoc/>
        public ICursorFactoryHandler CreateCursorFactoryHandler()
        {
            return new WxCursorFactoryHandler();
        }

        /// <inheritdoc/>
        public IToolTipFactoryHandler CreateToolTipFactoryHandler()
        {
            return new WxToolTipFactoryHandler();
        }

        public object? GetAttributeValue(string name)
        {
            if(name == "NotifyIcon.IsAvailable")
            {
                return Native.NotifyIcon.IsAvailable;
            }

            return null;
        }

        /// <inheritdoc/>
        public INotifyIconHandler CreateNotifyIconHandler()
        {
            return new UI.Native.NotifyIcon();
        }

        /// <inheritdoc/>
        public ITimerHandler CreateTimerHandler(Timer timer)
        {
            return new UI.Native.Timer();
        }

        /// <inheritdoc/>
        public void CrtSetDbgFlag(int value)
        {
            WebBrowserHandlerApi.WebBrowser_CrtSetDbgFlag_(value);
        }

        public MouseButtonState GetMouseButtonStateFromSystem(MouseButton mouseButton)
        {
            return WxApplicationHandler.NativeMouse.GetButtonState(mouseButton);
        }

        public PointI GetMousePositionFromSystem()
        {
            return WxApplicationHandler.NativeMouse.GetPosition();
        }

        public KeyStates GetKeyStatesFromSystem(Key key)
        {
            return WxApplicationHandler.NativeKeyboard.GetKeyState(key);
        }

        /// <inheritdoc/>
        protected override void DisposeManaged()
        {
            base.DisposeManaged();
            nativeApplication.Idle = null;
            nativeApplication.LogMessage = null;
            keyboardInputProvider.Dispose();
            mouseInputProvider.Dispose();
            nativeApplication.Dispose();
            nativeApplication = null!;
        }

        private static void LogEventIdentifiers()
        {
            App.LogSeparator();

            foreach(var item in Enum.GetValues(typeof(WxEventIdentifiers)))
            {
                App.LogNameValue(item, eventIdentifiers[(int)item]);
            }

            App.LogSeparator();
        }
    }
}
