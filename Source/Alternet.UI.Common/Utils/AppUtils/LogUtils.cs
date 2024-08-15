﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Alternet.Drawing;
using Alternet.UI.Localization;

using SkiaSharp;

namespace Alternet.UI
{
    /// <summary>
    /// Contains static methods for log handling.
    /// </summary>
    public static partial class LogUtils
    {
        /// <summary>
        /// Gets or sets whether to show debug welcome message
        /// with version number and other information.
        /// </summary>
        public static bool ShowDebugWelcomeMessage = false;

        /// <summary>
        /// Log related flags.
        /// </summary>
        public static LogFlags Flags;

        private static readonly ICustomFlags EventLoggedFlags = Factory.CreateFlags();

        private static List<(string Name, Action Action)>? registeredLogActions;
        private static int id;
        private static int logUseMaxLength;

        /// <summary>
        /// Enumerates log related flags.
        /// </summary>
        [Flags]
        public enum LogFlags
        {
            /// <summary>
            /// Message on application start were logged.
            /// </summary>
            AppStartLogged = 1,

            /// <summary>
            /// Message on application finish were logged.
            /// </summary>
            AppFinishLogged = 2,

            /// <summary>
            /// Application welcome message were logged.
            /// </summary>
            VersionLogged = 4,
        }

        /// <summary>
        /// Gets or sets <see cref="string"/> which is logged before and after log section.
        /// </summary>
        public static string SectionSeparator { get; set; } = "=========";

        /// <summary>
        /// Gets or sets max property value length for the <see cref="LogPropLimitLength"/>
        /// </summary>
        public static int LogPropMaxLength { get; set; } = 80;

        /// <summary>
        /// Gets unique id for debug purposes.
        /// </summary>
        public static int GenNewId()
        {
            return id++;
        }

        /// <summary>
        /// Returns whether specified event is logged.
        /// </summary>
        /// <param name="eventId">Event id.</param>
        /// <returns></returns>
        public static bool IsEventLogged(string eventId) => EventLoggedFlags.HasFlag(eventId);

        /// <summary>
        /// Gets event key.
        /// </summary>
        /// <param name="type">Type of the object.</param>
        /// <param name="evt">Event information.</param>
        /// <returns>Event id.</returns>
        public static string? GetEventKey(Type? type, EventInfo? evt)
        {
            if (type is null || evt is null)
                return null;
            var key = type.Name + "." + evt.Name;
            return key;
        }

        /// <summary>
        /// Returns whether specified event is logged.
        /// </summary>
        /// <param name="type">Type of the object.</param>
        /// <param name="evt">Event information.</param>
        /// <returns></returns>
        public static bool IsEventLogged(Type? type, EventInfo? evt)
        {
            var key = GetEventKey(type, evt);
            if (key is null)
                return false;
            var result = EventLoggedFlags.HasFlag(key);
            return result;
        }

        /// <summary>
        /// Sets whether to log specified event.
        /// </summary>
        /// <param name="type">Type of the object.</param>
        /// <param name="evt">Event information.</param>
        /// <param name="logged">Flag which enables/disables event logging.</param>
        public static void SetEventLogged(Type? type, EventInfo? evt, bool logged)
        {
            var key = GetEventKey(type, evt);
            if (key is null)
                return;
            EventLoggedFlags.SetFlag(key, logged);
        }

        /// <summary>
        /// Logs <see cref="IEnumerable"/>.
        /// </summary>
        public static void LogEnumerable(IEnumerable? items, LogItemKind kind = LogItemKind.Information)
        {
            if (items is null)
                return;
            foreach (var item in items)
                App.Log(item, kind);
        }

        /// <summary>
        /// Logs <see cref="IEnumerable"/> as section.
        /// </summary>
        public static void LogAsSection(IEnumerable? items, LogItemKind kind = LogItemKind.Information)
        {
            if (items is null)
                return;
            App.LogBeginSection();
            LogEnumerable(items, kind);
            App.LogEndSection();
        }

        /// <summary>
        /// Gets logging method based on the <paramref name="toFile"/> parameter value.
        /// </summary>
        /// <param name="toFile">If <c>true</c>, <see cref="LogToFile"/> is returned;
        /// otherwise <see cref="App.Log"/> is returned.</param>
        /// <returns></returns>
        /// <param name="kind">Log item kind.</param>
        public static Action<object?> GetLogMethod(
            bool toFile,
            LogItemKind kind = LogItemKind.Information)
        {
            static void ToFile(object? value)
            {
                LogToFile(value?.ToString());
            }

            void ToLog(object? value)
            {
                App.Log(value, kind);
            }

            if (toFile)
                return ToFile;
            else
                return ToLog;
        }

        /// <summary>
        /// Logs <see cref="Exception"/> information.
        /// </summary>
        /// <param name="e">Exception to log.</param>
        /// <param name="info">Additional info.</param>
        public static void LogException(Exception e, string? info = default)
        {
            try
            {
                App.Log(SectionSeparator, LogItemKind.Error);
                App.Log($"Exception: {info}", LogItemKind.Error);
                App.Log(e.ToString(), LogItemKind.Error);
                App.Log(SectionSeparator, LogItemKind.Error);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Logs <see cref="Exception"/> information to file.
        /// </summary>
        /// <param name="e">Exception to log.</param>
        /// <param name="filename">Log file path. <see cref="App.LogFilePath"/> is used
        /// when this parameter is <c>null</c>.</param>
        public static void LogExceptionToFile(Exception e, string? filename = null)
        {
            try
            {
                LogToFile(SectionSeparator, filename);
                LogToFile($"Exception:", filename);
                LogToFile(e.ToString(), filename);
                LogToFile(SectionSeparator, filename);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Logs <see cref="Exception"/> information if DEBUG is defined.
        /// </summary>
        /// <param name="e">Exception to log.</param>
        [Conditional("DEBUG")]
        public static void LogExceptionIfDebug(Exception e)
        {
            LogException(e);
        }

        /// <summary>
        /// Writes to log property value of the specified object.
        /// </summary>
        /// <param name="obj">Object instance.</param>
        /// <param name="propName">Property name.</param>
        /// <param name="prefix">Object name.</param>
        /// <param name="kind">Log item kind.</param>
        public static void LogProp(
            object? obj,
            string propName,
            string? prefix = null,
            LogItemKind kind = LogItemKind.Information)
        {
            var s = prefix;
            if (s != null)
                s += ".";

            PropertyInfo? propInfo = obj?.GetType().GetProperty(propName);
            if (propInfo == null)
                return;
            string? propValue = propInfo?.GetValue(obj)?.ToString();

            if (logUseMaxLength > 0)
                propValue = StringUtils.LimitLength(propValue, LogPropMaxLength);

            App.Log(s + propName + " = " + propValue, kind);
        }

        /// <summary>
        /// Writes to log property value of the specified object.
        /// </summary>
        /// <param name="obj">Object instance.</param>
        /// <param name="propName">Property name.</param>
        /// <param name="prefix">Object name.</param>
        /// <remarks>
        /// Uses <see cref="LogPropMaxLength"/> to limit max length of the property value.
        /// </remarks>
        public static void LogPropLimitLength(object? obj, string propName, string? prefix = null)
        {
            logUseMaxLength++;
            try
            {
                LogProp(obj, propName, prefix);
            }
            finally
            {
                logUseMaxLength--;
            }
        }

        /// <summary>
        /// Deletes application log file (specified in <see cref="App.LogFilePath"/>).
        /// </summary>
        public static void DeleteLog()
        {
            try
            {
                if (File.Exists(App.LogFilePath))
                    File.Delete(App.LogFilePath);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Logs to file pair of name and value as "{name} = {value}".
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
        /// <param name="filename">Log file path. <see cref="App.LogFilePath"/> is used
        /// when this parameter is <c>null</c>.</param>
        public static void LogNameValueToFile(
            object name,
            object? value,
            string? filename = null)
        {
            LogToFile($"{name} = {value}", filename);
        }

        /// <summary>
        /// Begins log to file section.
        /// </summary>
        /// <param name="filename">Log file path. <see cref="App.LogFilePath"/> is used
        /// when this parameter is <c>null</c>.</param>
        /// <param name="title">Section title. Optional.</param>
        public static void LogBeginSectionToFile(string? title = null, string? filename = null)
        {
            LogToFile(SectionSeparator, filename);

            if (title is not null)
            {
                LogToFile(title, filename);
                LogToFile(SectionSeparator, filename);
            }
        }

        /// <summary>
        /// Ends log to file section.
        /// </summary>
        /// <param name="filename">Log file path. <see cref="App.LogFilePath"/> is used
        /// when this parameter is <c>null</c>.</param>
        public static void LogEndSectionToFile(string? filename = null)
        {
            LogToFile(LogUtils.SectionSeparator, filename);
        }

        /// <summary>
        /// Logs section using <see cref="LogBeginSectionToFile"/>, <see cref="LogEndSectionToFile"/>
        /// and logging <paramref name="obj"/> between these calls.
        /// </summary>
        /// <param name="obj">Object to log.</param>
        /// <param name="title">Section title (optional).</param>
        /// <param name="filename">Log file path. <see cref="App.LogFilePath"/> is used
        /// when this parameter is <c>null</c>.</param>
        public static void LogSectionToFile(
            object? obj,
            string? title = null,
            string? filename = null)
        {
            LogBeginSectionToFile(title, filename);
            try
            {
                LogToFile(obj, filename);
            }
            finally
            {
                LogEndSectionToFile(filename);
            }
        }

        /// <summary>
        /// Logs section using <see cref="LogBeginSectionToFile"/>, <see cref="LogEndSectionToFile"/>
        /// and calling <paramref name="action"/> between these calls.
        /// </summary>
        /// <param name="action">Action which is called inside begin/end tags of the section.</param>
        /// <param name="title">Section title (optional).</param>
        /// <param name="filename">Log file path. <see cref="App.LogFilePath"/> is used
        /// when this parameter is <c>null</c>.</param>
        public static void LogActionToFile(
            Action action,
            string? title = null,
            string? filename = null)
        {
            LogBeginSectionToFile(title, filename);
            try
            {
                action();
            }
            finally
            {
                LogEndSectionToFile(filename);
            }
        }

        /// <summary>
        /// Logs message to the specified file or to default application log file.
        /// </summary>
        /// <param name="obj">Log message or object.</param>
        /// <param name="filename">Log file path. <see cref="App.LogFilePath"/> is used
        /// when this parameter is <c>null</c>.</param>
        public static void LogToFile(object? obj = null, string? filename = null)
        {
            var msg = obj?.ToString() ?? string.Empty;
            filename ??= App.LogFilePath;

            string dt = System.DateTime.Now.ToString("HH:mm:ss");
            string[] result = msg.Split(StringUtils.StringSplitToArrayChars, StringSplitOptions.None);

            string contents = string.Empty;

            foreach (string s2 in result)
                contents += $"{dt} :: {s2}{Environment.NewLine}";
            File.AppendAllText(filename, contents);
        }

        /// <summary>
        /// Same as <see cref="LogToFile"/> but writes message to file only under debug environment
        /// (DEBUG conditional is defined).
        /// </summary>
        /// <param name="obj">Log message or object.</param>
        /// <param name="filename">Log file path. <see cref="App.LogFilePath"/> is used
        /// when this parameter is <c>null</c>.</param>
        [Conditional("DEBUG")]
        public static void DebugLogToFile(object? obj = null, string? filename = null)
        {
            LogToFile(obj, filename);
        }

        /// <summary>
        /// Logs <see cref="Color"/> value.
        /// </summary>
        /// <param name="title">Color label.</param>
        /// <param name="value">Color value.</param>
        public static void LogColor(string? title, Color? value)
        {
            if (value is not null)
                value = ColorUtils.FindKnownColor(value);
            title ??= "Color";
            App.Log($"{title} = {value?.ToDebugString()}");
        }

        /// <summary>
        /// Logs <see cref="Color"/> and <see cref="RectD"/> values.
        /// </summary>
        /// <param name="title">Log label.</param>
        /// <param name="value">Color value.</param>
        /// <param name="rect">Rectangle value.</param>
        public static void LogColorAndRect(Color? value, RectD rect, string? title = null)
        {
            if (value is not null)
                value = ColorUtils.FindKnownColor(value);
            title ??= "ColorAndRect";
            App.Log($"{title} = {value?.ToDebugString()}, {rect}");
        }

        /// <summary>
        /// Logs <see cref="IEnumerable"/>.
        /// </summary>
        /// <param name="kind">Log item kind.</param>
        /// <param name="items">Items to log.</param>
        public static void LogRange(IEnumerable items, LogItemKind kind = LogItemKind.Information)
        {
            foreach (var item in items)
                App.Log(item, kind);
        }

        /// <summary>
        /// Logs error 'InvalidBoundArgument'.
        /// </summary>
        /// <param name="name">Name of the field or property.</param>
        /// <param name="value">Value.</param>
        /// <param name="minBound">Minimum value.</param>
        /// <param name="maxBound">Maximum value.</param>
        public static void LogInvalidBoundArgument(
            string name,
            object value,
            object minBound,
            object maxBound)
        {
            var s = string.Format(
                ErrorMessages.Default.InvalidBoundArgument,
                name,
                value.ToString(),
                minBound.ToString(),
                maxBound.ToString());
            App.LogError(s);
        }

        /// <summary>
        /// Logs error 'InvalidBoundArgument' for unsigned <see cref="int"/> values.
        /// </summary>
        /// <param name="name">Name of the field or property.</param>
        /// <param name="value">Value.</param>
        public static void LogInvalidBoundArgumentUInt(string name, int value)
        {
            LogInvalidBoundArgument(name, value, 0, int.MaxValue);
        }

        /// <summary>
        /// Writes to log file "Application started" header text.
        /// </summary>
        public static void LogAppStartedToFile()
        {
            if (Flags.HasFlag(LogFlags.AppStartLogged))
                return;
            try
            {
                Flags |= LogFlags.AppStartLogged;
                LogToFile();
                LogToFile();
                LogToFile(SectionSeparator);
                LogToFile("Application log started");
                LogToFile(SectionSeparator);
                LogToFile();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Writes to log file "Application finished" header text.
        /// </summary>
        public static void LogAppFinishedToFile()
        {
            if (Flags.HasFlag(LogFlags.AppFinishLogged))
                return;
            try
            {
                Flags |= LogFlags.AppFinishLogged;
                LogToFile();
                LogToFile();
                LogToFile(SectionSeparator);
                LogToFile("Application log finished");
                LogToFile(SectionSeparator);
                LogToFile();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Registers log action which will be shown in the Developer Tools window.
        /// </summary>
        /// <param name="name">Action name.</param>
        /// <param name="action">Action.</param>
        public static void RegisterLogAction(string name, Action action)
        {
            registeredLogActions ??= new();
            registeredLogActions.Add((name, action));
        }

        /// <summary>
        /// Logs <see cref="IEnumerable"/> to file.
        /// </summary>
        /// <param name="items">Range of items.</param>
        /// <param name="filename">Log file path. <see cref="App.LogFilePath"/> is used
        /// when this parameter is <c>null</c>.</param>
        /// <param name="title">Section title. Optional.</param>
        public static void LogRangeToFile(IEnumerable items, string? title = null, string? filename = null)
        {
            LogBeginSectionToFile(title, filename);
            try
            {
                foreach (var item in items)
                {
                    LogUtils.LogToFile(item, filename);
                }
            }
            finally
            {
                LogEndSectionToFile(filename);
            }
        }
    }
}