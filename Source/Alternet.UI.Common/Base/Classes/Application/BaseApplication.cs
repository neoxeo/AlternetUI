﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Alternet.Drawing;
using Alternet.UI.Localization;

namespace Alternet.UI
{
    /// <summary>
    /// Provides methods and properties to manage an application.
    /// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    public class BaseApplication : DisposableObject
    {
        /// <summary>
        /// Returns true if operating system is Windows.
        /// </summary>
        public static readonly bool IsWindowsOS;

        /// <summary>
        /// Returns true if operating system is Linux.
        /// </summary>
        public static readonly bool IsLinuxOS;

        /// <summary>
        /// Returns true if operating system is Apple macOS.
        /// </summary>
        public static readonly bool IsMacOS;

        /// <summary>
        /// Indicates whether the current application is running on Android.
        /// </summary>
        public static readonly bool IsAndroidOS;

        /// <summary>
        /// Indicates whether the current application is running on unknown OS.
        /// </summary>
        public static readonly bool IsUnknownOS;

        /// <summary>
        /// Indicates whether the current application is running on Apple iOS.
        /// </summary>
        public static readonly bool IsIOS;

        /// <summary>
        /// Gets a value that indicates whether the current operating system is
        /// a 64-bit operating system.
        /// </summary>
        public static readonly bool Is64BitOS;

        /// <summary>
        /// Gets a value that indicates whether the current process is a 64-bit process.
        /// </summary>
        public static readonly bool Is64BitProcess;

        /// <summary>
        /// Gets operating system as <see cref="OperatingSystems"/> enumeration.
        /// </summary>
        public static readonly OperatingSystems BackendOS;

        /// <summary>
        /// Gets or sets application exit code used when application terminates
        /// due to unhandled exception.
        /// </summary>
        public static int ThreadExceptionExitCode = 0;

        /// <summary>
        /// Gets or sets whether to log unhandled thread exception.
        /// </summary>
        public static bool LogUnhandledThreadException = true;

        /// <summary>
        /// Gets or sets whether calls to and from native code are wrapped in "try catch".
        /// </summary>
        /// <remarks>
        /// Under Windows default value is <c>true</c> and such wrapping is not needed.
        /// Under other systems default value is <c>false</c> and all calls are wrapped.
        /// </remarks>
        public static bool FastThreadExceptions;

        public static IApplicationHandler Handler = new NotImplementedApplicationHandler();

        public static CultureInfo InvariantEnglishUS = CultureInfo.InvariantCulture;

        internal static readonly Destructor MyDestructor = new();

        private static readonly ConcurrentQueue<(Action<object?> Action, object? Data)> IdleTasks = new();
        private static readonly ConcurrentQueue<(string Msg, LogItemKind Kind)> LogQueue = new();

        private static UnhandledExceptionMode unhandledExceptionMode
            = UnhandledExceptionMode.CatchException;

        private static UnhandledExceptionMode unhandledExceptionModeDebug
            = UnhandledExceptionMode.ThrowException;

        private static bool inOnThreadException;
        private static IconSet? icon;
        private static bool terminating = false;
        private static int logUpdateCount;
        private static bool logFileIsEnabled;
        private static BaseApplication? current;

        private readonly List<Window> windows = new();
        private Window? window;

        static BaseApplication()
        {
            Is64BitOS = Environment.Is64BitOperatingSystem;
            Is64BitProcess = Environment.Is64BitProcess;

#if NET5_0_OR_GREATER
            IsWindowsOS = OperatingSystem.IsWindows();

            if (IsWindowsOS)
            {
                FastThreadExceptions = true;

                BackendOS = OperatingSystems.Windows;
                return;
            }

            IsMacOS = OperatingSystem.IsMacOS();

            if (IsMacOS)
            {
                BackendOS = OperatingSystems.MacOs;
                return;
            }

            IsLinuxOS = OperatingSystem.IsLinux();

            if (IsLinuxOS)
            {
                BackendOS = OperatingSystems.Linux;
                return;
            }

            IsAndroidOS = OperatingSystem.IsAndroid();

            if (IsAndroidOS)
            {
                BackendOS = OperatingSystems.Android;
                return;
            }

            IsIOS = OperatingSystem.IsIOS();

            if (IsIOS)
            {
                BackendOS = OperatingSystems.IOS;
                return;
            }

            BackendOS = OperatingSystems.Unknown;
            IsUnknownOS = true;
#else
            BackendOS = OperatingSystems.Windows;
            IsWindowsOS = true;
#endif
        }

        public BaseApplication(IApplicationHandler handler)
        {
            Handler = handler;
            SynchronizationContext.InstallIfNeeded();
            BaseApplication.Current = this;

            Initialized = true;
            Window.UpdateDefaultFont();

#if DEBUG
            WebBrowser.CrtSetDbgFlag(0);
#endif
        }

        /// <summary>
        /// Occurs before native debug message needs to be displayed.
        /// </summary>
        public static event EventHandler<LogMessageEventArgs>? BeforeNativeLogMessage;

        /// <summary>
        ///  Occurs when an untrapped thread exception is thrown.
        /// </summary>
        /// <remarks>
        /// This event allows your application to handle otherwise
        /// unhandled exceptions that occur in UI threads. Attach
        /// your event handler to the <see cref="ThreadException"/> event
        /// to deal with these exceptions, which will
        /// leave your application in an unknown state. Where possible,
        /// exceptions should be handled by a structured
        /// exception handling block. You can change whether this callback
        /// is used for unhandled Windows Forms thread
        /// exceptions by setting <see cref="BaseApplication.SetUnhandledExceptionMode"/>.
        /// </remarks>
        public static event ThreadExceptionEventHandler? ThreadException;

        /// <summary>
        /// Occurs when controls which display log messages need to be refreshed.
        /// </summary>
        public static event EventHandler? LogRefresh;

        /// <summary>
        /// Occurs when debug message needs to be displayed.
        /// </summary>
        public static event EventHandler<LogMessageEventArgs>? LogMessage;

        /// <summary>
        /// Occurs when the application finishes processing events and is
        /// about to enter the idle state.
        /// </summary>
        public static event EventHandler? Idle;

        /// <summary>
        /// Allows the programmer to specify whether the application will exit when the
        /// top-level frame is deleted.
        /// Returns true if the application will exit when the top-level frame is deleted.
        /// </summary>
        public virtual bool ExitOnFrameDelete
        {
            get => Handler.ExitOnFrameDelete;
            set => Handler.ExitOnFrameDelete = value;
        }

        /// <summary>
        /// Gets whether the application is active, i.e. if one of its windows is currently in
        /// the foreground.
        /// </summary>
        public virtual bool IsActive => Handler.IsActive;

        /// <inheritdoc/>
        public virtual bool InUixmlPreviewerMode
        {
            get => Handler.InUixmlPreviewerMode;
            set => Handler.InUixmlPreviewerMode = value;
        }

        /// <summary>
        /// Gets or sets whether to call <see cref="Debug.WriteLine(string)"/> when\
        /// <see cref="Application.Log"/> is called. Default is <c>false</c>.
        /// </summary>
        public static bool DebugWriteLine { get; set; } = false;

        public static bool ThreadExceptionAssigned => ThreadException is not null;

        /// <summary>
        /// Gets currently used platform.
        /// </summary>
        public static UIPlatformKind PlatformKind => SystemSettings.Handler.GetPlatformKind();

        /// <summary>
        /// Gets the <see cref="Application"/> object for the currently
        /// runnning application.
        /// </summary>
        public static BaseApplication Current
        {
            get
            {
                // maybe make it thread static?
                // maybe move this to native?
                return current ?? throw new InvalidOperationException(
                    ErrorMessages.Default.CurrentApplicationIsNotSet);
            }

            protected set
            {
                current = value;
            }
        }

        /// <summary>
        /// Gets how the application responds to unhandled exceptions.
        /// Use <see cref="SetUnhandledExceptionMode"/> to change this property.
        /// </summary>
        public static UnhandledExceptionMode UnhandledExceptionMode => unhandledExceptionMode;

        /// <summary>
        /// Gets how the application responds to unhandled exceptions (if debugger is attached).
        /// Use <see cref="SetUnhandledExceptionModeIfDebugger"/> to change this property.
        /// </summary>
        public static UnhandledExceptionMode UnhandledExceptionModeIfDebugger
            => unhandledExceptionModeDebug;

        /// <summary>
        /// Gets a value that indicates whether a debugger is attached to the process.
        /// </summary>
        /// <value>
        /// true if a debugger is attached; otherwise, false.
        /// </value>
        public static bool IsDebuggerAttached
        {
            get
            {
                return System.Diagnostics.Debugger.IsAttached;
            }
        }

        /// <summary>
        /// Gets whether <see cref="Run"/> method execution is finished.
        /// </summary>
        public static bool Terminating
        {
            get => terminating;
            protected set => terminating = value;
        }

        /// <summary>
        /// Gets or sets application log file path.
        /// </summary>
        /// <remarks>
        /// Default value is exe file path and "Alternet.UI.log" file name.
        /// </remarks>
        public static string LogFilePath { get; set; } =
            Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, ".log");

        /// <summary>
        /// Gets or sets whether to write all log messages to file.
        /// </summary>
        /// <remarks>
        ///  Default value is <c>false</c>.
        /// </remarks>
        public static bool LogFileIsEnabled
        {
            get
            {
                return logFileIsEnabled;
            }

            set
            {
                if (logFileIsEnabled == value)
                    return;
                logFileIsEnabled = value;

                if (logFileIsEnabled)
                    LogUtils.LogToFileAppStarted();
            }
        }

        /// <summary>
        /// Returns true if between two <see cref="BeginBusyCursor"/> and
        /// <see cref="EndBusyCursor"/> calls.
        /// </summary>
        public static bool IsBusyCursor => NativePlatform.Default.IsBusyCursor();

        /// <summary>
        /// Allows to suppress some debug messages.
        /// </summary>
        /// <remarks>
        ///  Currently used to suppress GTK messages under Linux. Default
        ///  value is true.
        /// </remarks>
        public static bool SupressDiagnostics { get; set; } = true;

        /// <summary>
        /// Gets whether application was created and <see cref="Current"/> property is assigned.
        /// </summary>
        public static bool HasApplication => current is not null;

        /// <summary>
        /// Gets whether application was initialized;
        /// </summary>
        public static bool Initialized
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets or sets default icon for the application.
        /// </summary>
        /// <remarks>
        /// By default it returns icon of the the first <see cref="Window"/>.
        /// You can assing <see cref="IconSet"/> here to override default behavior.
        /// If you assing <c>null</c>, this property will again return icon of
        /// the the first <see cref="Window"/>. Change to this property doesn't
        /// update the icon of the the first <see cref="Window"/>.
        /// </remarks>
        public static IconSet? DefaultIcon
        {
            get
            {
                return icon ?? FirstWindow()?.Icon;
            }

            set
            {
                icon = value;
            }
        }

        /// <summary>
        /// Gets whether execution is inside the <see cref="Run"/> method.
        /// </summary>
        public static bool IsRunning { get; protected set; }

        /// <summary>
        /// Gets whether application has forms.
        /// </summary>
        public static bool HasForms => HasApplication && Current.Windows.Count > 0;

        /// <summary>
        /// Gets the instantiated windows in an application.
        /// </summary>
        /// <value>A <see cref="IReadOnlyList{Window}"/> that contains
        /// references to all window objects in the current application.</value>
        public IReadOnlyList<Window> Windows => windows;

        /// <summary>
        /// Gets all visible windows in an application.
        /// </summary>
        /// <value>A <see cref="IReadOnlyList{Window}"/> that contains
        /// references to all visible window objects in the current application.</value>
        public virtual IEnumerable<Window> VisibleWindows
        {
            get
            {
                var result = Windows.Where(x => x.Visible);
                return result;
            }
        }

        /// <summary>
        /// Gets or sets whether application will use the best visual on systems that
        /// support different visuals.
        /// </summary>
        public virtual bool UseBestVisual
        {
            get => SystemSettings.Handler.UseBestVisual;
            set => SystemSettings.Handler.UseBestVisual = value;
        }

        /// <summary>
        /// Gets or sets the application name.
        /// </summary>
        /// <remarks>
        /// It is used for paths, config, and other places the user doesn't see.
        /// By default it is set to the executable program name.
        /// </remarks>
        public virtual string Name
        {
            get => SystemSettings.Handler.AppName;
            set => SystemSettings.Handler.AppName = value;
        }

        /// <summary>
        /// Gets or sets the application display name.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The display name is the name shown to the user in titles, reports, etc.
        /// while the application name is used for paths, config, and other
        /// places the user doesn't see.
        /// </para>
        /// <para>
        /// By default the application display name is the same as application
        /// name or a capitalized version of the program if the application
        /// name was not set either.
        /// It's usually better to set it explicitly to something nicer.
        /// </para>
        /// </remarks>
        public virtual string DisplayName
        {
            get => SystemSettings.Handler.AppDisplayName;
            set => SystemSettings.Handler.AppDisplayName = value;
        }

        /// <summary>
        /// Gets or sets the application class name.
        /// </summary>
        /// <remarks>
        /// It should be set by the application itself, there are
        /// no reasonable defaults.
        /// </remarks>
        public virtual string AppClassName
        {
            get => SystemSettings.Handler.AppClassName;
            set => SystemSettings.Handler.AppClassName = value;
        }

        /// <summary>
        /// Gets or sets the vendor name.
        /// </summary>
        /// <remarks>
        /// It is used in some areas such as configuration, standard paths, etc.
        /// It should be set by the application itself, there are
        /// no reasonable defaults.
        /// </remarks>
        public virtual string VendorName
        {
            get => SystemSettings.Handler.VendorName;
            set => SystemSettings.Handler.VendorName = value;
        }

        /// <summary>
        /// Gets or sets the vendor display name.
        /// </summary>
        /// <remarks>
        /// It is shown in titles, reports, dialogs to the user, while
        /// the vendor name is used in some areas such as configuration,
        /// standard paths, etc.
        /// It should be set by the application itself, there are
        /// no reasonable defaults.
        /// </remarks>
        public virtual string VendorDisplayName
        {
            get => SystemSettings.Handler.VendorDisplayName;
            set => SystemSettings.Handler.VendorDisplayName = value;
        }

        /// <summary>
        /// Gets the layout direction for the current locale or <see cref="LangDirection.Default"/>
        /// if it's unknown.
        /// </summary>
        public virtual LangDirection LangDirection
        {
            get
            {
                return SystemSettings.Handler.GetLangDirection();
            }
        }

        protected internal virtual bool InvokeRequired => Handler.InvokeRequired;

        protected Window? MainWindow
        {
            get => window;
            set => window = value;
        }

        /// <summary>
        /// Informs all message pumps that they must terminate, and then closes
        /// all application windows after the messages have been processed.
        /// </summary>
        public static void Exit()
        {
            if (HasApplication)
                Handler.Exit();
        }

        /// <summary>
        /// Calls <see cref="Exit"/> and after that terminates this process and returns an
        /// exit code to the operating system.
        /// </summary>
        /// <param name="exitCode">
        /// The exit code to return to the operating system. Use 0 (zero) to indicate that
        /// the process completed successfully.
        /// </param>
        public static void ExitAndTerminate(int exitCode = 0)
        {
            Exit();
            Environment.Exit(exitCode);
        }


        /// <summary>
        /// Executes the specified delegate on the thread that owns the application.
        /// </summary>
        /// <param name="method">A delegate that contains a method to be called
        /// in the control's thread context.</param>
        /// <returns>An <see cref="object"/> that contains the return value from
        /// the delegate being invoked, or <c>null</c> if the delegate has no
        /// return value.</returns>
        public static object? Invoke(Delegate? method)
        {
            if (method == null)
                return null;
            return Invoke(method, Array.Empty<object?>());
        }

        /// <summary>
        /// Executes the specified action on the thread that owns the application.
        /// </summary>
        /// <param name="action">An action to be called in the control's
        /// thread context.</param>
        public static void Invoke(Action? action)
        {
            if (action == null)
                return;
            Invoke(action, Array.Empty<object?>());
        }

        /// <summary>
        /// Executes the specified delegate, on the thread that owns the application,
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
        public static object? Invoke(Delegate method, object?[] args)
            => SynchronizationService.Invoke(method, args);

        /// <summary>
        /// Executes <see cref="BaseApplication.IdleLog"/> using <see cref="Invoke(Action?)"/>.
        /// </summary>
        /// <param name="obj">Message text or object to log.</param>
        /// <param name="kind">Message kind.</param>
        public static void InvokeIdleLog(object? obj, LogItemKind kind = LogItemKind.Information)
        {
            Invoke(() =>
            {
                BaseApplication.IdleLog(obj, kind);
            });
        }

        /// <summary>
        /// Executes action in the application idle state using <see cref="Invoke(Action?)"/>.
        /// </summary>
        /// <param name="action">Action to execute.</param>
        public static void InvokeIdle(Action? action)
        {
            Invoke(() =>
            {
                AddIdleTask(action);
            });
        }

        /// <summary>
        /// Instructs the application to display a dialog with an optional
        /// <paramref name="message"/>,
        /// and to wait until the user dismisses the dialog.
        /// </summary>
        /// <param name="message">A string you want to display in the alert dialog, or,
        /// alternatively, an object that is converted into a string and displayed.</param>
        public static void Alert(object? message = null)
        {
            MessageBox.Show(
                FirstWindow(),
                message,
                CommonStrings.Default.WindowTitleApplicationAlert,
                MessageBoxButtons.OK,
                MessageBoxIcon.None);
        }

        /// <summary>
        /// Logs name and value pair as "{name} = {value}".
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
        /// <param name="kind">Item kind.</param>
        public static void LogNameValue(
            string name,
            object? value,
            LogItemKind kind = LogItemKind.Information)
        {
            Log($"{name} = {value}", kind);
        }

        /// <summary>
        /// Logs name and value pair as "{name} = {value}" if <paramref name="condition"/>
        /// is <c>true</c>.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
        /// <param name="condition">Log if <c>true</c>.</param>
        /// <param name="kind">Item kind.</param>
        public static void LogNameValueIf(
            string name,
            object? value,
            bool condition,
            LogItemKind kind = LogItemKind.Information)
        {
            if (condition)
                LogNameValue(name, value, kind);
        }

        /// <summary>
        /// Calls <see cref="LogMessage"/> event if <paramref name="condition"/>
        /// is <c>true</c>.
        /// </summary>
        /// <param name="obj">Message text or object to log.</param>
        /// <param name="condition">Log if <c>true</c>.</param>
        /// <param name="kind">Item kind.</param>
        public static void LogIf(
            object? obj,
            bool condition,
            LogItemKind kind = LogItemKind.Information)
        {
            if (condition)
                Log(obj, kind);
        }

        [return: MaybeNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T HandleThreadExceptions<T>(Func<T> func)
        {
            if (FastThreadExceptions)
                return func();

            return HandleThreadExceptionsCore(func);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HandleThreadExceptions(Action action)
        {
            if (FastThreadExceptions)
                action();
            else
                HandleThreadExceptionsCore(action);
        }

        /// <summary>
        /// Adds <paramref name="task"/> which will be executed one time
        /// when the application finished processing events and is
        /// about to enter the idle state.
        /// </summary>
        /// <param name="task">Task action.</param>
        /// <param name="param">Task parameter.</param>
        public static void AddIdleTask(Action<object?> task, object? param = null)
        {
            IdleTasks.Enqueue((task, param));
        }

        /// <summary>
        /// Adds <paramref name="task"/> which will be executed one time
        /// when the application finished processing events and is
        /// about to enter the idle state.
        /// </summary>
        /// <param name="task">Task action.</param>
        public static void AddIdleTask(Action? task)
        {
            if (task is null)
                return;
            AddIdleTask((object? param) => task());
        }

        /// <summary>
        /// Logs warning message.
        /// </summary>
        /// <param name="obj">Message text or object to log.</param>
        public static void LogWarning(object? obj)
        {
            Log($"Warning: {obj}", LogItemKind.Warning);
        }

        /// <summary>
        /// Logs error message.
        /// </summary>
        /// <param name="obj">Message text or object to log.</param>
        public static void LogError(object? obj)
        {
            Log($"Error: {obj}", LogItemKind.Error);
        }

        /// <summary>
        /// Calls <see cref="LogMessage"/> event.
        /// </summary>
        /// <param name="obj">Message text or object to log.</param>
        /// <param name="kind">Message kind.</param>
        public static void Log(object? obj, LogItemKind kind = LogItemKind.Information)
        {
            IdleLog(obj, kind);

            if (LogMessage is null || LogInUpdates())
                return;
            ProcessLogQueue(true);
        }

        public static void LogNativeMessage(string s)
        {
            if (BeforeNativeLogMessage is not null)
            {
                LogMessageEventArgs e = new(s);
                BeforeNativeLogMessage(current, e);
                if (e.Cancel)
                    return;
            }

            Log(s);
        }

        /// <summary>
        /// Checks if the Android version (returned by the Linux command uname) is greater than
        /// or equal to the specified version. This method can be used to guard APIs that were
        /// added in the specified version.
        /// </summary>
        /// <param name="major">The major release number.</param>
        /// <param name="minor">The minor release number.</param>
        /// <param name="build">The build release number.</param>
        /// <param name="revision">The revision release number.</param>
        /// <returns><c>true</c> if the current application is running on an Android version that
        /// is at least what was specified in the parameters; <c>false</c> otherwise.</returns>
        public static bool IsAndroidVersionAtLeast(
            int major,
            int minor = 0,
            int build = 0,
            int revision = 0)
        {
#if NET5_0_OR_GREATER
            return OperatingSystem.IsAndroidVersionAtLeast(major, minor, build, revision);
#else
            return false;
#endif
        }

        /// <summary>
        /// Sets system option value by name.
        /// </summary>
        /// <param name="name">Option name.</param>
        /// <param name="value">Option value.</param>
        public static void SetSystemOption(string name, int value)
        {
            SystemSettings.Handler.SetSystemOption(name, value);
        }

        /// <summary>
        /// Logs an empty string.
        /// </summary>
        public static void LogEmptyLine()
        {
            Log(" ");
        }

        /// <inheritdoc cref="Log"/>
        /// <remarks>
        /// Works only if DEBUG conditional is defined.
        /// </remarks>
        [Conditional("DEBUG")]
        public static void DebugLog(object? msg)
        {
            Log(msg);
        }

        /// <inheritdoc cref="LogIf"/>
        /// <remarks>
        /// Works only if DEBUG conditional is defined.
        /// </remarks>
        [Conditional("DEBUG")]
        public static void DebugLogIf(object? obj, bool condition)
        {
            if (condition)
                Log(obj);
        }

        /// <summary>
        /// Returns first window or <c>null</c> if there are no windows or window is not
        /// of the <typeparamref name="T"/> type.
        /// </summary>
        /// <typeparam name="T">Type of the window to return.</typeparam>
        public static T? FirstWindow<T>()
            where T : class
        {
            var windows = Current.Windows;

            if (windows.Count == 0)
                return null;
            return windows[0] as T;
        }

        /// <summary>
        /// Returns first window or <c>null</c> if there are no windows.
        /// </summary>
        public static Window? FirstWindow()
        {
            return FirstWindow<Window>();
        }

        /// <summary>
        /// Calls <see cref="LogMessage"/> event to add or replace log message.
        /// </summary>
        /// <param name="obj">Message text.</param>
        /// <param name="prefix">Message text prefix.</param>
        /// <param name="kind">Message kind.</param>
        /// <remarks>
        /// If last logged message
        /// contains <paramref name="prefix"/>, last log item is replaced with
        /// <paramref name="obj"/> instead of adding new log item.
        /// </remarks>
        public static void LogReplace(
            object? obj,
            string? prefix = null,
            LogItemKind kind = LogItemKind.Information)
        {
            var msg = obj?.ToString();
            if (msg is null || msg.Length == 0)
                return;
            WriteToLogFileIfAllowed(msg);
            if (DebugWriteLine)
                Debug.WriteLine(msg);
            prefix ??= msg;

            var args = new LogMessageEventArgs(msg, prefix, true);
            args.Kind = kind;

            LogMessage?.Invoke(null, args);
        }

        /// <summary>
        /// Gets whether massive log outputs are performed and controls attached to log
        /// should not refresh.
        /// </summary>
        /// <returns></returns>
        public static bool LogInUpdates()
        {
            return logUpdateCount > 0;
        }

        /// <summary>
        /// Runs idle tasks if they are present.
        /// </summary>
        public static void ProcessIdleTasks()
        {
            while (true)
            {
                if (IdleTasks.TryDequeue(out var task))
                    task.Action(task.Data);
                else
                    break;
            }
        }

        /// <summary>
        /// Changes the cursor to the given cursor for all windows in the application.
        /// </summary>
        /// <remarks>
        /// Use <see cref="IsBusyCursor"/> to get current busy cursor state.
        /// Use <see cref="EndBusyCursor"/> to revert the cursor back to its previous state.
        /// These two calls can be nested, and a counter ensures that only the outer calls take effect.
        /// </remarks>
        public static void BeginBusyCursor() => NativePlatform.Default.BeginBusyCursor();

        /// <summary>
        /// Changes the cursor back to the original cursor, for all windows in the application.
        /// </summary>
        /// <remarks>
        /// Use with <see cref="BeginBusyCursor"/> and <see cref="IsBusyCursor"/>.
        /// </remarks>
        public static void EndBusyCursor() => NativePlatform.Default.EndBusyCursor();

        /// <summary>
        /// Executes <paramref name="action"/> between calls to <see cref="BeginBusyCursor"/>
        /// and <see cref="EndBusyCursor"/>.
        /// </summary>
        /// <param name="action">Action that will be executed.</param>
        public static void DoInsideBusyCursor(Action action)
        {
            BeginBusyCursor();
            try
            {
                action();
            }
            finally
            {
                EndBusyCursor();
            }
        }

        /// <summary>
        /// Begins log section.
        /// </summary>
        public static void LogBeginSection(string? title = null, LogItemKind kind = LogItemKind.Information)
        {
            Log(LogUtils.SectionSeparator, kind);

            if (title is not null)
            {
                Log(title, kind);
                Log(LogUtils.SectionSeparator, kind);
            }
        }

        /// <summary>
        /// Logs separator.
        /// </summary>
        public static void LogSeparator(LogItemKind kind = LogItemKind.Information)
        {
            Log(LogUtils.SectionSeparator, kind);
        }

        /// <summary>
        /// Ends log section.
        /// </summary>
        public static void LogEndSection(LogItemKind kind = LogItemKind.Information)
        {
            Log(LogUtils.SectionSeparator, kind);
        }

        public static void RaiseThreadException(object sender, ThreadExceptionEventArgs args)
        {
            ThreadException?.Invoke(sender, args);
        }

        /// <summary>
        /// Calls <see cref="Log"/> method with <paramref name="obj"/> parameter
        /// when application becomes idle.
        /// </summary>
        /// <param name="obj">Message text or object to log.</param>
        /// <param name="kind">Message kind.</param>
        /// <remarks>
        /// This method is thread safe and can be called from non-ui threads.
        /// </remarks>
        public static void IdleLog(object? obj, LogItemKind kind = LogItemKind.Information)
        {
            if (Terminating)
                return;

            var msg = obj?.ToString();

            if (msg is null)
                return;

            WriteToLogFileIfAllowed(msg);

            string[] result = msg.Split(
                StringUtils.StringSplitToArrayChars,
                StringSplitOptions.RemoveEmptyEntries);

            if (DebugWriteLine || LogMessage is null)
            {
                foreach (string s2 in result)
                {
                    Debug.WriteLine(s2);

                    try
                    {
                        Console.WriteLine(s2);
                    }
                    catch
                    {
                    }
                }
            }

            foreach (string s2 in result)
                LogQueue.Enqueue((s2, kind));
        }

        /// <inheritdoc cref="LogReplace"/>
        /// <remarks>
        /// Works only if DEBUG conditional is defined.
        /// </remarks>
        [Conditional("DEBUG")]
        public static void DebugLogReplace(object? obj, string? prefix = null)
        {
            LogReplace(obj, prefix);
        }

        /// <summary>
        /// Shows <see cref="ThreadExceptionWindow"/> on the screen.
        /// </summary>
        /// <param name="exception">Exception information.</param>
        /// <param name="additionalInfo">Additional information.</param>
        /// <param name="canContinue">Whether continue button is visible.</param>
        /// <returns><c>true</c> if continue pressed, <c>false</c> otherwise.</returns>
        public static bool ShowExceptionWindow(
            Exception exception,
            string? additionalInfo = null,
            bool canContinue = true)
        {
            return NativePlatform.Default.ShowExceptionWindow(exception, additionalInfo, canContinue);
        }

        /// <summary>
        /// Can be called before massive outputs to log. Pairs with <see cref="LogEndUpdate"/>.
        /// </summary>
        public static void LogBeginUpdate()
        {
            logUpdateCount++;
        }

        /// <summary>
        /// Must be called after massive outputs to log,
        /// if <see cref="LogBeginUpdate"/> was previously called.
        /// </summary>
        public static void LogEndUpdate()
        {
            logUpdateCount--;
            if (logUpdateCount == 0)
                OnLogRefresh();
        }

        /// <summary>Processes all messages currently in the message queue.</summary>
        public static void DoEvents()
        {
            Current?.ProcessPendingEvents();
        }

        /// <summary>
        /// Checks whether there are any pending events in the queue.
        /// </summary>
        /// <returns><c>true</c> if there are any pending events in the queue,
        /// <c>false</c> otherwise.</returns>
        public bool HasPendingEvents()
        {
            return Handler.HasPendingEvents();
        }

        /// <summary>
        /// Starts an application UI event loop and makes the specified window
        /// visible.
        /// Begins running a UI event processing loop on the current thread.
        /// </summary>
        /// <param name="window">A <see cref="Window"/> that opens automatically
        /// when an application starts.</param>
        /// <remarks>Typically, the main function of an application calls this
        /// method and passes to it the main window of the application.</remarks>
        public void Run(Window window)
        {
            IsRunning = true;

            try
            {
                this.MainWindow = window ?? throw new ArgumentNullException(nameof(window));
                CheckDisposed();
                window.Show();

                while (true)
                {
                    try
                    {
                        Handler.Run(window);
                        break;
                    }
                    catch (Exception e)
                    {
                        OnThreadException(e);
                    }
                }

                SynchronizationContext.Uninstall();
                this.MainWindow = null;
            }
            finally
            {
                Terminating = true;
                IsRunning = false;
            }
        }

        public static void OnThreadException(Exception exception)
        {
            if (inOnThreadException)
                return;

            inOnThreadException = true;
            try
            {
                if (LogUnhandledThreadException)
                {
                    LogUtils.LogException(exception, "Application.OnThreadException");
                }

                if (GetUnhandledExceptionMode() == UnhandledExceptionMode.ThrowException)
                    throw exception;

                if (ThreadExceptionAssigned)
                {
                    var args = new ThreadExceptionEventArgs(exception);
                    RaiseThreadException(Thread.CurrentThread, args);
                }
                else
                {
                    var td = new ThreadExceptionWindow(exception);
                    var result = ModalResult.Accepted;

                    try
                    {
                        result = td.ShowModal();
                    }
                    finally
                    {
                        td.Dispose();
                    }

                    if (result == ModalResult.Canceled)
                    {
                        ExitAndTerminate(ThreadExceptionExitCode);
                    }
                }
            }
            finally
            {
                inOnThreadException = false;
            }
        }

        [return: MaybeNull]
        private static T HandleThreadExceptionsCore<T>(Func<T> func)
        {
            if (GetUnhandledExceptionMode() == UnhandledExceptionMode.ThrowException)
                return func();

            try
            {
                return func();
            }
            catch (Exception e)
            {
                OnThreadException(e);
                return default!;
            }
        }

        private static void HandleThreadExceptionsCore(Action action)
        {
            if (GetUnhandledExceptionMode() == UnhandledExceptionMode.ThrowException)
            {
                action();
                return;
            }

            try
            {
                action();
            }
            catch (Exception e)
            {
                OnThreadException(e);
            }
        }

        /// <summary>
        /// Processes all pending events.
        /// </summary>
        public virtual void ProcessPendingEvents()
        {
            BaseApplication.Handler.ProcessPendingEvents();
        }

        /// <summary>
        /// Instructs the application how to respond to unhandled exceptions.
        /// </summary>
        /// <param name="mode">An <see cref="UnhandledExceptionMode"/>
        /// value describing how the application should
        /// behave if an exception is thrown without being caught.</param>
        public virtual void SetUnhandledExceptionMode(UnhandledExceptionMode mode)
        {
            unhandledExceptionMode = mode;
        }

        /// <summary>
        /// Allows runtime switching of the UI environment theme.
        /// </summary>
        /// <param name="theme">Theme name</param>
        /// <returns><c>true</c> if operation was successful, <c>false</c> otherwise.</returns>
        public virtual bool SetNativeTheme(string theme)
        {
            return SystemSettings.Handler.SetNativeTheme(theme);
        }

        /// <summary>
        /// Allows the programmer to specify whether the application will use the best
        /// visual on systems that support several visual on the same display.
        /// </summary>
        public virtual void SetUseBestVisual(bool flag, bool forceTrueColour = false)
        {
            SystemSettings.Handler.SetUseBestVisual(flag, forceTrueColour);
        }

        /// <summary>
        /// Raises <see cref="Idle"/> event.
        /// </summary>
        public static void RaiseIdle()
        {
            if (HasForms)
            {
                ProcessLogQueue(true);
                ProcessIdleTasks();
            }

            Idle?.Invoke(current, EventArgs.Empty);
        }

        public void BeginInvoke(Action action)
        {
            Handler.BeginInvoke(action);
        }

        /// <summary>
        /// Instructs the application how to respond to unhandled exceptions in debug mode.
        /// </summary>
        /// <param name="mode">An <see cref="UnhandledExceptionMode"/>
        /// value describing how the application should
        /// behave if an exception is thrown without being caught.</param>
        public virtual void SetUnhandledExceptionModeIfDebugger(UnhandledExceptionMode mode)
        {
            unhandledExceptionModeDebug = mode;
        }

        internal void RegisterWindow(Window window)
        {
            windows.Add(window);
        }

        internal void UnregisterWindow(Window window)
        {
            if (this.window == window)
                this.window = null;
            windows.Remove(window);
        }

        /// <summary>
        /// Sets the 'top' window.
        /// </summary>
        /// <param name="window">New 'top' window.</param>
        internal virtual void SetTopWindow(Window window)
        {
            Handler.SetTopWindow(window);
        }

        public void WakeUpIdle()
        {
            Handler.WakeUpIdle();
        }

        internal void RecreateAllHandlers()
        {
            foreach (var window in Windows)
                window.RecreateAllHandlers();
        }

        protected override void DisposeManaged()
        {
            BaseApplication.Current = null!;
        }

        /// <summary>
        /// Gets current unhandled exception mode.
        /// </summary>
        /// <returns></returns>
        protected static UnhandledExceptionMode GetUnhandledExceptionMode()
        {
            if (IsDebuggerAttached)
                return unhandledExceptionModeDebug;
            else
                return unhandledExceptionMode;
        }

        protected static void ProcessLogQueue(bool refresh)
        {
            if (LogQueue.IsEmpty || LogInUpdates())
                return;

            LogBeginUpdate();
            try
            {
                while (true)
                {
                    if (LogQueue.TryDequeue(out var queueItem))
                        LogToEvent(queueItem.Kind, queueItem.Msg);
                    else
                        break;
                }
            }
            finally
            {
                LogEndUpdate();
            }
        }

        private static void OnLogRefresh()
        {
            LogRefresh?.Invoke(null, EventArgs.Empty);
        }

        private static void LogToEvent(LogItemKind kind, params string[] items)
        {
            if (LogMessage is null)
                return;

            LogMessageEventArgs? args = new();
            args.Kind = kind;

            foreach (string s2 in items)
            {
                args.Message = s2;
                LogMessage(null, args);
            }
        }

        private static void WriteToLogFileIfAllowed(string? msg)
        {
            if (!LogFileIsEnabled || msg is null)
                return;
            try
            {
                LogUtils.LogToFile(msg);
            }
            catch
            {
            }
        }

        internal sealed class Destructor
        {
            ~Destructor()
            {
                if (LogFileIsEnabled)
                    LogUtils.LogToFileAppFinished();
            }
        }

        /// <summary>
        /// Build counter for the test purposes.
        /// </summary>
#pragma warning disable
        public static int BuildCounter = 6;
#pragma warning restore
    }
}