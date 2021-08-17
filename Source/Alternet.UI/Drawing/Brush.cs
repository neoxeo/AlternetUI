using System;

namespace Alternet.UI
{
    /// <summary>
    /// Defines objects used to fill the interiors of graphical shapes such as rectangles, ellipses, pies, polygons, and paths.
    /// </summary>
    /// <remarks>
    /// This is an abstract base class and cannot be instantiated. To create a brush object,
    /// use classes derived from <see cref="Brush" />, such as <see cref="SolidBrush" /> or <see cref="HatchBrush" />.
    /// </remarks>
    public abstract class Brush : IDisposable, IEquatable<Brush>
    {
        private bool isDisposed;

        internal Brush(Native.Brush nativeBrush)
        {
            NativeBrush = nativeBrush;
        }

        internal Native.Brush NativeBrush { get; private set; }

        /// <summary>
        /// Returns a value that indicates whether the two objects are equal.
        /// </summary>
        public static bool operator ==(Brush? a, Brush? b)
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
        public static bool operator !=(Brush? a, Brush? b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Releases all resources used by this <see cref="Brush"/>.
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
            return GetHashCodeCore();
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        public bool Equals(Brush? other)
        {
            if (other == null)
                return false;

            CheckDisposed();
            return EqualsCore(other);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string ToString()
        {
            CheckDisposed();
            return ToStringCore();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override bool Equals(object? obj)
        {
            var brush = obj as Brush;

            if (ReferenceEquals(brush, null))
                return false;

            if (GetType() != obj?.GetType())
                return false;

            return Equals(brush);
        }

        private protected abstract int GetHashCodeCore();

        private protected abstract bool EqualsCore(Brush other);

        private protected abstract string ToStringCore();

        /// <summary>
        /// Throws <see cref="ObjectDisposedException"/> if the object has been disposed.
        /// </summary>
        protected void CheckDisposed()
        {
            if (isDisposed)
                throw new ObjectDisposedException(null);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    NativeBrush.Dispose();
                    NativeBrush = null!;
                }

                isDisposed = true;
            }
        }
    }
}