﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    /// <summary>
    /// General application utility methods.
    /// </summary>
    public static class AppUtils
    {
        /// <summary>
        /// Repeats <paramref name="action"/> specified number of <paramref name="times"/>.
        /// </summary>
        /// <param name="times">Repeat count.</param>
        /// <param name="action">Action to repeat</param>
        public static void RepeatAction(int times, Action action)
        {
            for (int i = 0; i < times; i++)
                action();
        }

        /// <summary>
        /// Gets this application target framework in the form like 'net8.0' or 'net462'.
        /// </summary>
        /// <returns></returns>
        public static string GetMyTargetFrameworkName()
        {
            var version = Environment.Version;
#if NETFRAMEWORK
            var result = $"net{version.Major}{version.Minor}";
#else
            var result = $"net{version.Major}.{version.Minor}";
#endif
            return result;
        }

        /// <summary>
        /// Executes terminal command redirecting output and error streams
        /// to <see cref="Application.Log"/>.
        /// </summary>
        /// <param name="command">Terminal command.</param>
        /// <param name="folder">Value of <see cref="ProcessStartInfo.WorkingDirectory"/>.</param>
        public static void ExecuteTerminalCommand(string command, string? folder = null)
        {
            void ExecuteOnWindows()
            {
                Execute("cmd.exe", "/c " + command);
            }

            void Execute(string fileName, string arguments)
            {
                Process process = new();
                Application.Log("Run: " + fileName + " " + arguments);
                ProcessStartInfo processInfo = new(fileName, arguments)
                {
                    // If the UseShellExecute property is true,
                    // the CreateNoWindow property value is ignored
                    // and a new window is created.
                    // .NET Core does not support creating windows directly
                    // on Unix/Linux/macOS and the property is ignored.
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardError = true,
                };
                if (folder != null)
                    processInfo.WorkingDirectory = folder;
                process.StartInfo = processInfo;
                process.OutputDataReceived += (x, y) => Application.IdleLog($"Output> {y.Data}");
                process.ErrorDataReceived += (x, y) =>
                {
                    if (string.IsNullOrWhiteSpace(y.Data))
                        return;
                    Application.IdleLog($"Error> {y.Data}");
                };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
            }

            void ExecuteOnOther()
            {
                Execute("/bin/bash", "-c \" " + command + " \"");
            }

            if (Application.IsWindowsOS)
                ExecuteOnWindows();
            else
                ExecuteOnOther();
        }

        /// <summary>
        /// Uses <see cref="Process"/> to start the application.
        /// </summary>
        /// <param name="filePath">Path to the application.</param>
        /// <param name="args">Set of command-line arguments to use when starting the application.
        /// See <see cref="ProcessStartInfo.Arguments"/></param>
        /// <param name="folder">Initial directory.
        /// See <see cref="ProcessStartInfo.WorkingDirectory"/></param>
        /// <returns><c>true</c> if operation is successful; <c> false</c> otherwise.</returns>
        public static bool ProcessStart(string filePath, string? args = null, string? folder = null)
        {
            using Process process = new();
            process.StartInfo.Verb = "open";
            process.StartInfo.FileName = filePath;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            if (args is not null)
                process.StartInfo.Arguments = args;
            if (folder != null)
                process.StartInfo.WorkingDirectory = folder;
            try
            {
                process.Start();
                return true;
            }
            catch (Exception e)
            {
                LogUtils.LogException(e);
                return false;
            }
        }

        /// <summary>
        /// Opens url in the default browser.
        /// </summary>
        /// <param name="url">Url to open.</param>
        /// <returns><c>true</c> if operation is successful; <c> false</c> otherwise.</returns>
        public static bool OpenUrl(string url)
        {
            var result = ShellExecute(url);
            return result;
        }

        /// <inheritdoc cref="ProcessStart"/>
        /// <remarks>
        /// Uses shell execute to start the process.
        /// </remarks>
        public static bool ShellExecute(string filePath, string? args = null, string? folder = null)
        {
            using Process process = new();
            process.StartInfo.Verb = "open";
            process.StartInfo.FileName = filePath;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = true;
            if(args is not null)
                process.StartInfo.Arguments = args;
            if (folder != null)
                process.StartInfo.WorkingDirectory = folder;
            try
            {
                process.Start();
                return true;
            }
            catch (Exception e)
            {
                LogUtils.LogException(e);
                return false;
            }
        }

        /// <summary>
        /// Uses <see cref="Process"/> to start the application.
        /// </summary>
        /// <param name="startInfo">Process start parameters.</param>
        /// <returns></returns>
        public static bool ProcessStartEx(ProcessStartInfo startInfo)
        {
            using Process process = new();
            process.StartInfo = startInfo;
            try
            {
                process.Start();
                return true;
            }
            catch (Exception e)
            {
                LogUtils.LogException(e);
                return false;
            }
        }
    }
}
