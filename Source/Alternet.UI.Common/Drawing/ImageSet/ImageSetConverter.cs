using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using Alternet.UI;
using Alternet.UI.Markup;

namespace Alternet.Drawing
{
    /// <summary>Converts <see cref="ImageSet"/> from one data type to another. Access this
    /// class through the
    /// <see cref="System.ComponentModel.TypeDescriptor" />.</summary>
    public class ImageSetConverter : TypeConverter
    {
        /// <inheritdoc/>
        public override bool CanConvertFrom(
            ITypeDescriptorContext? context,
            Type? sourceType)
        {
            return sourceType == typeof(string);
        }

        /// <inheritdoc/>
        public override object? ConvertFrom(
            ITypeDescriptorContext? context,
            CultureInfo? culture,
            object? value)
        {
            var s = (string?)value;
            if (s == null)
                return null;

            return new ImageSet(s, ImageConverter.GetContextBaseUri(context));
        }
    }
}