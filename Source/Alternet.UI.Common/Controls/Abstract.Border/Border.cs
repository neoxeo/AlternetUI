using System;
using System.ComponentModel;
using Alternet.Drawing;

namespace Alternet.UI
{
    /// <summary>
    /// Draws a border, background, or both around another control.
    /// </summary>
    [ControlCategory("Containers")]
    public partial class Border : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        /// <param name="parent">Parent of the control.</param>
        public Border(Control parent)
            : this()
        {
            Parent = parent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        public Border()
        {
            RefreshOptions = ControlRefreshOptions.RefreshOnBorder
                | ControlRefreshOptions.RefreshOnBackground;
            Borders ??= new();
            var settings = CreateBorderSettings(BorderSettings.Default);
            Borders.SetAll(settings);
            UpdatePadding();
            Borders.Normal!.PropertyChanged += OnSettingsPropertyChanged;
        }

        /// <summary>
        /// Gets or sets the default border width for
        /// the <see cref="Border"/> control.
        /// </summary>
        /// <remarks>
        /// You can specify different widths for the left, top, bottom and right
        /// edges of the border.
        /// </remarks>
        public static Thickness DefaultBorderWidth
        {
            get => BorderSettings.Default.Width;
            set => BorderSettings.Default.Width = value;
        }

        /// <inheritdoc/>
        public override RectD ChildrenLayoutBounds
        {
            get
            {
                var bounds = base.ChildrenLayoutBounds;

                if (HasBorder)
                {
                    bounds.X += BorderWidth.Left;
                    bounds.Y += BorderWidth.Top;
                    if (bounds.Size == 0)
                        return bounds;
                    bounds.Width -= BorderWidth.Horizontal;
                    bounds.Height -= BorderWidth.Vertical;
                }

                return bounds;
            }
        }

        /// <summary>
        /// Gets or sets the border width for the <see cref="Border"/> control.
        /// </summary>
        /// <remarks>
        /// You can specify different widths for the left, top, bottom and right
        /// edges of the border.
        /// </remarks>
        public virtual Thickness BorderWidth
        {
            get => NormalBorder.Width;
            set
            {
                value.ApplyMin(0);
                if (NormalBorder.Width == value)
                    return;
                NormalBorder.SetWidth(value);
                UpdatePadding();
                PerformLayout();
                Refresh();
            }
        }

        /// <inheritdoc/>
        public override bool HasBorder
        {
            get => base.HasBorder;
            set
            {
                if (HasBorder == value)
                    return;
                base.HasBorder = value;
                UpdatePadding();
            }
        }

        /// <inheritdoc cref="BorderSettings.UniformCornerRadius"/>
        public virtual Coord? UniformCornerRadius
        {
            get
            {
                return NormalBorder.UniformCornerRadius;
            }

            set
            {
                if (NormalBorder.UniformCornerRadius == value)
                    return;
                NormalBorder.UniformCornerRadius = value;
                Refresh();
            }
        }

        /// <inheritdoc cref="BorderSettings.UniformRadiusIsPercent"/>
        public virtual bool? UniformRadiusIsPercent
        {
            get
            {
                return NormalBorder.UniformRadiusIsPercent;
            }

            set
            {
                if (NormalBorder.UniformRadiusIsPercent == value)
                    return;
                NormalBorder.UniformRadiusIsPercent = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the uniform border width for the <see cref="Border"/> control.
        /// </summary>
        /// <remarks>
        /// This value is applied to all the sides. If returned value is not null,
        /// all border sides
        /// have the same settings.
        /// </remarks>
#if DEBUG
        [Browsable(true)]
#else
        [Browsable(false)]
#endif
        public virtual Coord? UniformBorderWidth
        {
            get
            {
                if (NormalBorder.Width.IsUniform)
                    return NormalBorder.Width.Left;
                else
                    return null;
            }

            set
            {
                value ??= 0;
                var w = new Thickness(value.Value);
                BorderWidth = w;
            }
        }

        /// <inheritdoc cref="AbstractControl.Background"/>
        [Browsable(true)]
        public override Brush? Background
        {
            get => base.Background;
            set
            {
                base.Background = value;
            }
        }

        /// <summary>
        /// Gets whether bottom border is visible.
        /// </summary>
        [Browsable(false)]
        public virtual bool HasVisibleBorderBottom
        {
            get
            {
                return NormalBorder.Width.Bottom > 0 && HasBorder;
            }
        }

        /// <summary>
        /// Gets whether top border is visible.
        /// </summary>
        [Browsable(false)]
        public virtual bool HasVisibleBorderTop
        {
            get
            {
                return NormalBorder.Width.Top > 0 && HasBorder;
            }
        }

        /// <inheritdoc/>
        public override ControlTypeId ControlKind => ControlTypeId.Border;

        /// <summary>
        /// Gets or sets the border color for the <see cref="Border"/> control.
        /// </summary>
        /// <remarks>
        /// If this property is null, <see cref="BorderSettings.DefaultColor"/> is used
        /// for the border color.
        /// </remarks>
        public virtual Color? BorderColor
        {
            get
            {
                return NormalBorder.Color ?? ColorUtils.GetDefaultBorderColor(IsDarkBackground);
            }

            set
            {
                if (value == null)
                {
                    NormalBorder.Color = ColorUtils.GetDefaultBorderColor(IsDarkBackground);
                }
                else
                    NormalBorder.Color = (Color)value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets individual border side settings in the normal visual state.
        /// </summary>
        [Browsable(false)]
        public virtual BorderSettings NormalBorder
        {
            get
            {
                Borders ??= new();
                return Borders.Normal ??= new(BorderSettings.Default);
            }

            set
            {
                Borders ??= new();
                if (value == null)
                    Borders.Normal?.Assign(BorderSettings.Default);
                else
                    Borders.Normal?.Assign(value);
            }
        }

        /// <summary>
        /// Creates border filled with default settings.
        /// </summary>
        /// <returns></returns>
        public static BorderSettings CreateDefaultBorder(Color? color = null)
        {
            BorderSettings result = new(BorderSettings.Default);
            if (color is not null)
                result.Color = color;
            return result;
        }

        /// <inheritdoc cref="BorderSettings.SetColors"/>
        public virtual void SetBorderColors(Color left, Color top, Color right, Color bottom)
        {
            if (NormalBorder.SetColors(left, top, right, bottom))
                Refresh();
        }

        /// <inheritdoc/>
        public override SizeD GetPreferredSize(SizeD availableSize)
        {
            if (HasBorder)
            {
                var width = NormalBorder.Width;
                return base.GetPreferredSize(availableSize) + (width.Horizontal, width.Vertical);
            }
            else
            {
                return base.GetPreferredSize(availableSize);
            }
        }

        /// <inheritdoc/>
        public override void DefaultPaint(Graphics dc, RectD rect)
        {
            DrawDefaultBackground(dc, rect);
        }

        /// <summary>
        /// Configures border so only top border is visible and other borders are hidden.
        /// </summary>
        /// <param name="width">The width assigned to the border side.
        /// If Null, value from <see cref="DefaultBorderWidth"/> is used.</param>
        public virtual void OnlyTopBorder(Coord? width = null)
        {
            SetVisibleBorders(false, true, false, false, width);
        }

        /// <summary>
        /// Configures border so only bottom border is visible and other borders are hidden.
        /// </summary>
        /// <param name="width">The width assigned to the border side.
        /// If Null, value from <see cref="DefaultBorderWidth"/> is used.</param>
        public virtual void OnlyBottomBorder(Coord? width = null)
        {
            SetVisibleBorders(false, false, false, true, width);
        }

        /// <summary>
        /// Sets visible borders. Changes border side widths depending on the paramer values.
        /// </summary>
        /// <param name="left">Whether left border side is visible.</param>
        /// <param name="top">Whether top border side is visible.</param>
        /// <param name="right">Whether right border side is visible.</param>
        /// <param name="bottom">Whether bottom border side is visible.</param>
        /// <param name="width">The width assigned to the border side
        /// when side is visible. If Null, value from <see cref="DefaultBorderWidth"/> is used.</param>
        public virtual void SetVisibleBorders(
            bool left,
            bool top,
            bool right,
            bool bottom,
            Coord? width = null)
        {
            PerformLayoutAndInvalidate(() =>
            {
                Thickness borderWidth;

                if (width is null)
                    borderWidth = DefaultBorderWidth;
                else
                    borderWidth = width.Value;

                NormalBorder.Width = (
                    GetWidth(left, borderWidth.Left),
                    GetWidth(top, borderWidth.Top),
                    GetWidth(right, borderWidth.Right),
                    GetWidth(bottom, borderWidth.Bottom));

                HasBorder = left || top || right || bottom;

                Coord GetWidth(bool visible, Coord width)
                {
                    return visible ? width : 0;
                }
            });
        }

        /// <summary>
        /// Creates used <see cref="BorderSettings"/> instance. Override to use have border
        /// painting or non-default behavior.
        /// </summary>
        protected virtual BorderSettings CreateBorderSettings(BorderSettings defaultSettings)
        {
            return new(defaultSettings);
        }

        /// <summary>
        /// Updates <see cref="AbstractControl.Padding"/> with border size.
        /// </summary>
        protected virtual void UpdatePadding()
        {
            if (HasBorder)
            {
                Thickness borderPadding = NormalBorder.Width;
                var padding = Padding;
                padding.ApplyMin(borderPadding);
                Padding = padding;
            }
            else
            {
                if(Padding == NormalBorder.Width)
                    Padding = 0;
            }
        }

        private void OnSettingsPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Refresh();
        }
    }
}