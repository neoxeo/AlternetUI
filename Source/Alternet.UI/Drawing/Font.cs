using System;

namespace Alternet.UI
{
    /// <summary>
    /// Defines a particular format for text, including font face, size, and style attributes. This class cannot be inherited.
    /// </summary>
    public sealed class Font : IDisposable, IEquatable<Font>
    {
        private bool isDisposed;

        private int? hashCode;

        /// <summary>
        /// Initializes a new <see cref="Font"/> using a specified font familty name and size in points.
        /// </summary>
        /// <param name="familyName">A string representation of the font family for the new Font.</param>
        /// <param name="emSize">The em-size, in points, of the new font.</param>
        /// <exception cref="ArgumentException"><c>emSize</c> is less than or equal to 0, evaluates to infinity or is not a valid number.</exception>
        public Font(string familyName, float emSize) : this(new FontFamily(familyName), emSize)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="Font"/> using a specified font family and size in points.
        /// </summary>
        /// <param name="family">The <see cref="FontFamily"/> of the new <see cref="Font"/>.</param>
        /// <param name="emSize">The em-size, in points, of the new font.</param>
        /// <exception cref="ArgumentException"><c>emSize</c> is less than or equal to 0, evaluates to infinity or is not a valid number.</exception>
        public Font(FontFamily family, float emSize)
        {
            if (emSize <= 0 || float.IsInfinity(emSize) || float.IsNaN(emSize))
                throw new ArgumentException(nameof(emSize));

            NativeFont = new Native.Font();
            NativeFont.Initialize(
                family.GenericFamily == null ? Native.GenericFontFamily.None : (Native.GenericFontFamily)family.GenericFamily,
                family.Name,
                emSize);
        }

        internal Font(Native.Font nativeFont)
        {
            NativeFont = nativeFont;
        }

        /// <summary>
        /// Gets the em-size, in points, of this <see cref="Font"/>.
        /// </summary>
        /// <value>The em-size, in points, of this <see cref="Font"/>.</value>
        public float SizeInPoints
        {
            get
            {
                CheckDisposed();
                return NativeFont.SizeInPoints;
            }
        }

        /// <summary>
        /// Gets the <see cref="FontFamily"/> associated with this <see cref="Font"/>.
        /// </summary>
        /// <value>The <see cref="FontFamily"/> associated with this <see cref="Font"/>.</value>
        public FontFamily FontFamily
        {
            get
            {
                CheckDisposed();
                return new FontFamily(NativeFont.Name);
            }
        }

        /// <summary>
        /// Gets the font family name of this <see cref="Font"/>.
        /// </summary>
        /// <value>A string representation of the font family name of this Font.</value>
        public string Name
        {
            get
            {
                CheckDisposed();
                return NativeFont.Name;
            }
        }

        internal Native.Font NativeFont { get; private set; }

        /// <summary>
        /// Returns a value that indicates whether the two objects are equal.
        /// </summary>
        public static bool operator ==(Font? a, Font? b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        /// <summary>
        /// Returns a value that indicates whether the two objects are not equal.
        /// </summary>
        public static bool operator !=(Font? a, Font? b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Releases all resources used by this <see cref="Font"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override int GetHashCode()
        {
            CheckDisposed();
            if (hashCode == null)
                hashCode = NativeFont.Serialize().GetHashCode();
            return hashCode.Value;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        public bool Equals(Font? other)
        {
            if (other == null)
                return false;

            CheckDisposed();
            return NativeFont.IsEqualTo(other.NativeFont);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string ToString()
        {
            CheckDisposed();
            return NativeFont.Description;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override bool Equals(object? obj)
        {
            var font = obj as Font;

            if (ReferenceEquals(font, null))
                return false;

            if (GetType() != obj?.GetType())
                return false;

            return Equals(font);
        }

        internal static Font CreateDefaultFont()
        {
            var nativeFont = new Native.Font();
            nativeFont.InitializeWithDefaultFont();
            return new Font(nativeFont);
        }

        private void CheckDisposed()
        {
            if (isDisposed)
                throw new ObjectDisposedException(null);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    NativeFont.Dispose();
                    NativeFont = null!;
                }

                isDisposed = true;
            }
        }
    }
}