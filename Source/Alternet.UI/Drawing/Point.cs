// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using Alternet.UI;
using Alternet.UI.Localization;
using Alternet.UI.Markup;

namespace Alternet.Drawing
{
    /*
        Please do not remove StructLayout(LayoutKind.Sequential) atrtribute.
        Also do not change order of the fields.
    */

    /// <summary>
    /// Represents an ordered pair of x and y coordinates that define a point in a
    /// two-dimensional plane.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Point : IEquatable<Point>
    {
        /// <summary>
        /// Gets an empty point with (0, 0) ccordinates.
        /// </summary>
        public static readonly Point Empty;

        /// <summary>
        /// Gets a point with (-1, -1) ccordinates.
        /// </summary>
        public static readonly Point MinusOne = new(-1d, -1d);

        /// <summary>
        /// Gets a point with (1, 1) ccordinates.
        /// </summary>
        public static readonly Point One = new(1d, 1d);

        private double x; // Do not rename (binary serialization)
        private double y; // Do not rename (binary serialization)

        /// <summary>
        /// Initializes a new instance of the <see cref='Drawing.Point'/> class with the
        /// specified coordinates.
        /// </summary>
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='Drawing.Point'/> struct from the specified
        /// <see cref="System.Numerics.Vector2"/>.
        /// </summary>
        public Point(Vector2 vector)
        {
            x = vector.X;
            y = vector.Y;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref='Drawing.Point'/> is empty.
        /// </summary>
        [Browsable(false)]
        public readonly bool IsEmpty => x == 0f && y == 0f;

        /// <summary>
        /// Gets the x-coordinate of this <see cref='Drawing.Point'/>.
        /// </summary>
        public double X
        {
            readonly get => x;
            set => x = value;
        }

        /// <summary>
        /// Gets the y-coordinate of this <see cref='Drawing.Point'/>.
        /// </summary>
        public double Y
        {
            readonly get => y;
            set => y = value;
        }

        /* TODO: uncommment when Double System.Numerics is availble.
         * See https://github.com/dotnet/runtime/issues/24168
        /// <summary>
        /// Creates a new <see cref="System.Numerics.Vector2"/> from
        /// this <see cref="System.Drawing.PointF"/>.
        /// </summary>
        public Vector2 ToVector2() => new Vector2(x, y);

        /// <summary>
        /// Converts the specified <see cref="Drawing.Point"/> to a
        /// <see cref="System.Numerics.Vector2"/>.
        /// </summary>
        public static explicit operator Vector2(Point point) => point.ToVector2();*/

        /// <summary>
        /// Converts the specified <see cref="System.Numerics.Vector2"/> to a
        /// <see cref="Drawing.Point"/>.
        /// </summary>
        public static explicit operator Point(Vector2 vector) => new(vector);

        /// <summary>
        /// Translates a <see cref='Drawing.Point'/> by a given <see cref='Drawing.Int32Size'/>.
        /// </summary>
        public static Point operator +(Point pt, Int32Size sz) => Add(pt, sz);

        /// <summary>
        /// Translates a <see cref='Drawing.Point'/> by the negative of a given
        /// <see cref='Drawing.Int32Size'/>.
        /// </summary>
        public static Point operator -(Point pt, Int32Size sz) => Subtract(pt, sz);

        /// <summary>
        /// Translates a <see cref='Drawing.Point'/> by a given <see cref='Drawing.Size'/>.
        /// </summary>
        public static Point operator +(Point pt, Size sz) => Add(pt, sz);

        /// <summary>
        /// Moves a <see cref='Point'/> by a given value.
        /// </summary>
        public static Point operator +(Point pt, double offset) =>
            new(pt.X + offset, pt.Y + offset);

        /// <summary>
        /// Translates a <see cref='Drawing.Point'/> by the negative of a given
        /// <see cref='Drawing.Size'/>.
        /// </summary>
        public static Point operator -(Point pt, Size sz) => Subtract(pt, sz);

        /// <summary>
        /// Compares two <see cref='Drawing.Point'/> objects. The result specifies whether
        /// the values of the
        /// <see cref='Drawing.Point.X'/> and <see cref='Drawing.Point.Y'/> properties of the two
        /// <see cref='Drawing.Point'/> objects are equal.
        /// </summary>
        public static bool operator ==(Point left, Point right) => left.X == right.X &&
            left.Y == right.Y;

        /// <summary>
        /// Compares two <see cref='Drawing.Point'/> objects. The result specifies whether
        /// the values of the
        /// <see cref='Drawing.Point.X'/> or <see cref='Drawing.Point.Y'/> properties of the two
        /// <see cref='Drawing.Point'/> objects are unequal.
        /// </summary>
        public static bool operator !=(Point left, Point right) => !(left == right);

        /// <summary>
        /// Translates a <see cref='Drawing.Point'/> by a given <see cref='Drawing.Int32Size'/>.
        /// </summary>
        public static Point Add(Point pt, Int32Size sz) => new(pt.X + sz.Width, pt.Y + sz.Height);

        /// <summary>
        /// Translates a <see cref='Drawing.Point'/> by the negative of a given
        /// <see cref='Drawing.Int32Size'/>.
        /// </summary>
        public static Point Subtract(Point pt, Int32Size sz) =>
            new(pt.X - sz.Width, pt.Y - sz.Height);

        /// <summary>
        /// Translates a <see cref='Drawing.Point'/> by a given <see cref='Drawing.Size'/>.
        /// </summary>
        public static Point Add(Point pt, Size sz) => new(pt.X + sz.Width, pt.Y + sz.Height);

        /// <summary>
        /// Translates a <see cref='Drawing.Point'/> by the negative of a given
        /// <see cref='Drawing.Size'/>.
        /// </summary>
        public static Point Subtract(Point pt, Size sz) => new(pt.X - sz.Width, pt.Y - sz.Height);

        /// <summary>
        /// Parse - returns an instance converted from the provided string using
        /// the culture "en-US"
        /// <param name="source"> string with Point data </param>
        /// </summary>
        public static Point Parse(string source)
        {
            IFormatProvider formatProvider = TypeConverterHelper.InvariantEnglishUS;

            TokenizerHelper th = new(source, formatProvider);

            Point value;

            string firstToken = th.NextTokenRequired();

            value = new Point(
                Convert.ToDouble(firstToken, formatProvider),
                Convert.ToDouble(th.NextTokenRequired(), formatProvider));

            // There should be no more tokens in this string.
            th.LastTokenRequired();

            return value;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object;
        /// otherwise, <c>false</c>.</returns>
        public override readonly bool Equals([NotNullWhen(true)] object? obj) =>
            obj is Point point && Equals(point);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><c>true</c> if the current object is equal to other; otherwise,
        /// <c>false</c>.</returns>
        public readonly bool Equals(Point other) => this == other;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override readonly int GetHashCode() =>
            HashCode.Combine(X.GetHashCode(), Y.GetHashCode());

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override readonly string ToString()
        {
            string[] names = [PropNameStrings.Default.X, PropNameStrings.Default.Y];
            double[] values = [x, y];

            return StringUtils.ToString<double>(names, values);
        }

        /// <summary>
        /// Creates a string representation of this object based on the format string
        /// and IFormatProvider passed in.
        /// If the provider is null, the CurrentCulture is used.
        /// See the documentation for IFormattable for more information.
        /// </summary>
        /// <returns>
        /// A string representation of this object.
        /// </returns>
        internal readonly string ConvertToString(string format, IFormatProvider provider)
        {
            // Helper to get the numeric list separator for a given culture.
            char separator = TokenizerHelper.GetNumericListSeparator(provider);
            return string.Format(
                provider,
                "{1:" + format + "}{0}{2:" + format + "}",
                separator,
                X,
                Y);
        }
    }
}
