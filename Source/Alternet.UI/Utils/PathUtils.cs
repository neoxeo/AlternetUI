﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    /// <summary>
    /// Contains <see cref="Path"/> related static methods.
    /// </summary>
    public static class PathUtils
    {
        /// <summary>
        /// Returns directory separator char which is used in given path.
        /// </summary>
        /// <param name="path">Path in which directory separator
        /// char is searched.</param>
        /// <returns><see cref="Path.DirectorySeparatorChar"/> or
        /// <see cref="Path.AltDirectorySeparatorChar"/>.</returns>
        public static char ExtractDirectorySeparatorChar(string? path)
        {
            if (string.IsNullOrEmpty(path))
                return Path.DirectorySeparatorChar;

            if (path.Contains(Path.AltDirectorySeparatorChar))
                return Path.AltDirectorySeparatorChar;
            return Path.DirectorySeparatorChar;
        }

        /// <summary>
        /// Returns boolean value indicating whether path ends with
        /// directory separator char.
        /// </summary>
        /// <param name="path">Path which will be checked.</param>
        /// <returns><c>true</c> if path ends with directory separator char;
        /// <c>false</c> otherwise.</returns>
        public static bool EndsWithDirectorySeparator(string? path)
        {
            if (string.IsNullOrEmpty(path))
                return false;
            int index = path.Length - 1;
            char c = path[index];
            if (c != Path.DirectorySeparatorChar)
                return c == Path.AltDirectorySeparatorChar;
            return true;
        }

        /// <summary>
        /// Returns path to the application folder.
        /// </summary>
        /// <returns><see cref="string"/> containing path to the application folder
        /// with directory separator char at the end.</returns>
        public static string GetAppFolder()
        {
            string location = Assembly.GetExecutingAssembly().Location;
            string s = Path.GetDirectoryName(location)!;
            return PathUtils.AddDirectorySeparatorChar(s);
        }

        /// <summary>
        /// Adds directory separator char to the path if it's needed. If path
        /// already has directory separator char at the end, no changes are
        /// performed.
        /// </summary>
        /// <param name="path">Path to which directory separator
        /// char will be added.</param>
        /// <returns><see cref="string"/> containing path with added
        /// directory separator char. </returns>
        /// <exception cref="ArgumentNullException">Path is null.</exception>
        public static string AddDirectorySeparatorChar(string? path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            path = path.TrimEnd();
            if (EndsWithDirectorySeparator(path))
                return path;
            return path + ExtractDirectorySeparatorChar(path);
        }
    }
}