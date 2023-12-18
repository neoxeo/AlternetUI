using System;

namespace Alternet.Drawing
{
    /// <summary>
    /// Describes the interior of a graphics shape composed of rectangles and paths. This class cannot be inherited.
    /// </summary>
    public sealed class Region : IDisposable
    {
        private bool isDisposed;

        /// <summary>
        /// This constructor creates an invalid (empty, null) <see cref="Region"/>.
        /// </summary>
        public Region()
        {
            NativeRegion = new UI.Native.Region();
        }

        /// <summary>
        /// Initializes a new <see cref="Region"/> from the specified <see cref="Rect"/> structure.
        /// </summary>
        /// <param name="rect">A <see cref="Rect"/> structure that defines the interior
        /// of the new <see cref="Region"/>.</param>
        public Region(Rect rect)
        {
            NativeRegion = new UI.Native.Region();
            NativeRegion.InitializeWithRect(rect);
        }

        /// <summary>
        /// Initializes a new <see cref="Region"/> from the specified <see cref="Region"/>.
        /// </summary>
        /// <param name="region">A <see cref="Region"/> that defines the interior
        /// of the new <see cref="Region"/>.</param>
        public Region(Region region)
        {
            NativeRegion = new UI.Native.Region();
            NativeRegion.InitializeWithRegion(region.NativeRegion);
        }

        /// <summary>
        /// Initializes a new <see cref="Region"/> from the polygon specified by the
        /// <paramref name="points"/> array.
        /// </summary>
        /// <param name="points">A <see cref="Point"/> structures array
        /// describing the polygon.</param>
        /// <param name="fillMode">The polygon fill mode.</param>
        public Region(Point[] points, FillMode fillMode = FillMode.Alternate)
        {
            NativeRegion = new UI.Native.Region();
            NativeRegion.InitializeWithPolygon(points, (UI.Native.FillMode)fillMode);
        }

        internal Region(UI.Native.Region region)
        {
            NativeRegion = region;
        }

        /// <summary>
        /// Returns true if the region is empty, false otherwise.
        /// </summary>
        public bool IsEmpty => isDisposed || NativeRegion.IsEmpty();

        /// <summary>
        /// Returns true if the region is ok, false otherwise.
        /// </summary>
        public bool IsOk => !isDisposed && NativeRegion.IsOk();

        internal UI.Native.Region NativeRegion { get; private set; }

        /// <summary>
        /// Clears the region.
        /// </summary>
        public void Clear()
        {
            CheckDisposed();
            NativeRegion.Clear();
        }

        /// <summary>
        /// Returns a value indicating whether the given point is contained within the region.
        /// </summary>
        /// <param name="pt">Point to check.</param>
        /// <returns></returns>
        public RegionContain Contains(Point pt)
        {
            CheckDisposed();
            return (RegionContain)NativeRegion.ContainsPoint(pt);
        }

        /// <summary>
        /// Returns a value indicating whether the given rectangle is contained within the region.
        /// </summary>
        /// <param name="rect">Rectangle to check.</param>
        /// <returns></returns>
        public RegionContain Contains(Rect rect)
        {
            CheckDisposed();
            return (RegionContain)NativeRegion.ContainsRect(rect);
        }

        /// <summary>
        /// Updates this <see cref="Region"/> to the intersection of itself with the
        /// specified <see cref="Rect"/> structure.
        /// </summary>
        /// <param name="rect">The <see cref="Rect"/> structure to intersect with this
        /// <see cref="Region"/>.</param>
        public void Intersect(Rect rect)
        {
            CheckDisposed();
            NativeRegion.IntersectWithRect(rect);
        }

        /// <summary>
        /// Updates this <see cref="Region"/> to the intersection of itself with the
        /// specified <see cref="Region"/>.
        /// </summary>
        /// <param name="region">The <see cref="Region"/> to intersect with this <see cref="Region"/>.</param>
        public void Intersect(Region region)
        {
            CheckDisposed();
            NativeRegion.IntersectWithRegion(region.NativeRegion);
        }

        /// <summary>
        /// Updates this <see cref="Region"/> to the union of itself with the
        /// specified <see cref="Rect"/> structure.
        /// </summary>
        /// <param name="rect">The <see cref="Rect"/> structure to union with
        /// this <see cref="Region"/>.</param>
        public void Union(Rect rect)
        {
            CheckDisposed();
            NativeRegion.UnionWithRect(rect);
        }

        /// <summary>
        /// Updates this <see cref="Region"/> to the union of itself with the
        /// specified <see cref="Region"/>.
        /// </summary>
        /// <param name="region">The <see cref="Region"/> to union with this
        /// <see cref="Region"/>.</param>
        public void Union(Region region)
        {
            CheckDisposed();
            NativeRegion.UnionWithRegion(region.NativeRegion);
        }

        /// <summary>
        /// Updates this <see cref="Region"/> to the xor of itself with the
        /// specified <see cref="Region"/>.
        /// </summary>
        /// <param name="region">The <see cref="Region"/> to xor with this
        /// <see cref="Region"/>.</param>
        public void Xor(Region region)
        {
            CheckDisposed();
            NativeRegion.XorWithRegion(region.NativeRegion);
        }

        /// <summary>
        /// Updates this <see cref="Region"/> to the xor of itself with the
        /// specified <see cref="Rect"/> structure.
        /// </summary>
        /// <param name="rect">The <see cref="Rect"/> structure to xor with
        /// this <see cref="Region"/>.</param>
        public void Xor(Rect rect)
        {
            CheckDisposed();
            NativeRegion.XorWithRect(rect);
        }

        /// <summary>
        /// Updates this <see cref="Region"/> to the result of subtraction
        /// of the specified <see cref="Rect"/> structure from itself.
        /// </summary>
        /// <param name="rect">The <see cref="Rect"/> structure to subtract
        /// from this <see cref="Region"/>.</param>
        public void Subtract(Rect rect)
        {
            CheckDisposed();
            NativeRegion.SubtractRect(rect);
        }

        /// <summary>
        /// Updates this <see cref="Region"/> to the result of subtraction
        /// of the specified <see cref="Region"/> from itself.
        /// </summary>
        /// <param name="region">The <see cref="Region"/> to subtract from
        /// this <see cref="Region"/>.</param>
        public void Subtract(Region region)
        {
            CheckDisposed();
            NativeRegion.SubtractRegion(region.NativeRegion);
        }

        /// <summary>
        /// Offsets the coordinates of this <see cref="Region"/> by the specified amount.
        /// </summary>
        /// <param name="dx">The amount to offset this <see cref="Region"/> horizontally.</param>
        /// <param name="dy">The amount to offset this <see cref="Region"/> vertically.</param>
        public void Translate(double dx, double dy)
        {
            CheckDisposed();
            NativeRegion.Translate(dx, dy);
        }

        /// <summary>
        /// Gets a <see cref="Rect"/> structure that represents a rectangle that
        /// bounds this <see cref="Region"/>.
        /// </summary>
        public Rect GetBounds()
        {
            CheckDisposed();
            return NativeRegion.GetBounds();
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            CheckDisposed();

            if (obj is not Region region)
                return false;

            return NativeRegion.IsEqualTo(region.NativeRegion);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return NativeRegion.GetHashCode_();
        }

        /// <summary>
        /// Releases all resources used by this <see cref="TransformMatrix"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Throws <see cref="ObjectDisposedException"/> if the object has been disposed.
        /// </summary>
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
                    NativeRegion.Dispose();
                    NativeRegion = null!;
                }

                isDisposed = true;
            }
        }
    }
}