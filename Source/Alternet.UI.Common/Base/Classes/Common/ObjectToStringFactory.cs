﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    /// <summary>
    /// Contains properties and methods related to <see cref="IObjectToString"/>.
    /// </summary>
    public class ObjectToStringFactory : BaseObject
    {
        /// <summary>
        /// Gets <see cref="Type"/> to <see cref="TypeConverter"/> dictionary.
        /// </summary>
        public static readonly IndexedValues<Type, TypeConverter> Converters = new();

        /// <summary>
        /// Gets or sets whether to handle <see cref="TypeDescriptor.Refreshed"/> event.
        /// Default is False.
        /// </summary>
        public static bool HandleTypeDescriptorRefreshed = true;

        static ObjectToStringFactory()
        {
            TypeDescriptor.Refreshed += TypeDescriptorRefreshed;

            void TypeDescriptorRefreshed(RefreshEventArgs e)
            {
                if(HandleTypeDescriptorRefreshed)
                    Converters.Clear();
            }
        }

        /// <summary>
        /// Gets or sets default <see cref="ObjectToStringFactory"/> implementation.
        /// </summary>
        public static ObjectToStringFactory Default { get; set; } = new();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="sbyte"/> type.
        /// </summary>
        public virtual IObjectToString SByteToString { get; set; } = new SByteToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="byte"/> type.
        /// </summary>
        public virtual IObjectToString ByteToString { get; set; } = new ByteToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="short"/> type.
        /// </summary>
        public virtual IObjectToString Int16ToString { get; set; } = new Int16ToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="ushort"/> type.
        /// </summary>
        public virtual IObjectToString UInt16ToString { get; set; } = new UInt16ToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="int"/> type.
        /// </summary>
        public virtual IObjectToString Int32ToString { get; set; } = new Int32ToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="uint"/> type.
        /// </summary>
        public virtual IObjectToString UInt32ToString { get; set; } = new UInt32ToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="long"/> type.
        /// </summary>
        public virtual IObjectToString Int64ToString { get; set; } = new Int64ToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="ulong"/> type.
        /// </summary>
        public virtual IObjectToString UInt64ToString { get; set; } = new UInt64ToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="float"/> type.
        /// </summary>
        public virtual IObjectToString SingleToString { get; set; } = new SingleToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="double"/> type.
        /// </summary>
        public virtual IObjectToString DoubleToString { get; set; } = new DoubleToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/>
        /// implementation for the <see cref="decimal"/> type.
        /// </summary>
        public virtual IObjectToString DecimalToString { get; set; } = new DecimalToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/>
        /// implementation for the <see cref="DateTime"/> type.
        /// </summary>
        public virtual IObjectToString DateTimeToString { get; set; } = new DateTimeToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the case if
        /// type is <see cref="TypeCode.Empty"/>.
        /// </summary>
        public virtual IObjectToString EmptyToString { get; set; } = new EmptyToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the case if
        /// type is <see cref="TypeCode.DBNull"/>.
        /// </summary>
        public virtual IObjectToString DBNullToString { get; set; } = new DBNullToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="object"/> type.
        /// </summary>
        public virtual IObjectToString ObjectToString { get; set; } = new ObjectToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="bool"/> type.
        /// </summary>
        public virtual IObjectToString BooleanToString { get; set; } = new BooleanToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="char"/> type.
        /// </summary>
        public virtual IObjectToString CharToString { get; set; } = new CharToStringConverter();

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the <see cref="string"/> type.
        /// </summary>
        public virtual IObjectToString StringToString { get; set; } = new StringToStringConverter();

        /// <summary>
        /// Gets <see cref="TypeConverter"/> object for the specified type.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="toString">Whether conversion is from object to string. If not Null,
        /// type converter is quieried whether it can convert to/from string.
        /// If Null, no such check is performed.</param>
        public virtual TypeConverter? GetTypeConverter(Type type, bool? toString = true)
        {
            if (type is null)
                return null;

            var typeConverter = Converters.GetValue(type, Internal);

            TypeConverter? Internal()
            {
                var result = TypeDescriptor.GetConverter(type);
                return result;
            }

            if (typeConverter is null)
                return null;

            if(toString is not null)
            {
                var canConvert = toString.Value
                    ? typeConverter.CanConvertTo(typeof(string))
                    : typeConverter.CanConvertFrom(typeof(string));
                if (!canConvert)
                    return null;
            }

            return typeConverter;
        }

        /// <summary>
        /// Creates <see cref="IObjectToString"/> implementation
        /// for the specified type converter.
        /// </summary>
        /// <param name="converter">Type converter.</param>
        /// <returns></returns>
        public virtual IObjectToString? CreateAdapter(TypeConverter? converter)
        {
            if (converter is null)
                return null;
            return new TypeConverterAdapter(converter);
        }

        /// <summary>
        /// Gets <see cref="IObjectToString"/> implementation
        /// for the specified type using adapted <see cref="TypeConverter"/>
        /// which is obtained using <see cref="GetTypeConverter"/>.
        /// </summary>
        /// <param name="type">Type.</param>
        public virtual IObjectToString? CreateAdapterForTypeConverter(Type type)
        {
            var typeConverter = GetTypeConverter(type);
            var result = CreateAdapter(typeConverter);
            return result;
        }

        /// <summary>
        /// Gets default <see cref="IObjectToString"/> implementation for the
        /// specified <see cref="TypeCode"/>.
        /// </summary>
        /// <param name="code">Type code.</param>
        public virtual IObjectToString? GetConverter(TypeCode code)
        {
            switch (code)
            {
                case TypeCode.Empty:
                    return Default.EmptyToString;
                case TypeCode.Object:
                default:
                    return Default.ObjectToString;
                case TypeCode.DBNull:
                    return Default.DBNullToString;
                case TypeCode.Boolean:
                    return Default.BooleanToString;
                case TypeCode.Char:
                    return Default.CharToString;
                case TypeCode.SByte:
                    return Default.SByteToString;
                case TypeCode.Byte:
                    return Default.ByteToString;
                case TypeCode.Int16:
                    return Default.Int16ToString;
                case TypeCode.UInt16:
                    return Default.UInt16ToString;
                case TypeCode.Int32:
                    return Default.Int32ToString;
                case TypeCode.UInt32:
                    return Default.UInt32ToString;
                case TypeCode.Int64:
                    return Default.Int64ToString;
                case TypeCode.UInt64:
                    return Default.UInt64ToString;
                case TypeCode.Single:
                    return Default.SingleToString;
                case TypeCode.Double:
                    return Default.DoubleToString;
                case TypeCode.Decimal:
                    return Default.DecimalToString;
                case TypeCode.DateTime:
                    return Default.DateTimeToString;
                case TypeCode.String:
                    return Default.StringToString;
            }
        }

        internal abstract class BaseToStringConverter : IObjectToString
        {
            public virtual string? ToString(object value)
            {
                return value.ToString();
            }

            public virtual string? ToString(object value, IFormatProvider? provider)
            {
                return ToString();
            }

            public virtual string? ToString(object value, string? format)
            {
                return ToString();
            }

            public virtual string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ToString();
            }

            public virtual string? ToString(
                object value,
                ITypeDescriptorContext? context,
                CultureInfo? culture,
                bool useInvariantConversion)
            {
                return ToString(value);
            }
        }

        internal class SByteToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((sbyte)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((sbyte)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((sbyte)value).ToString(format);
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((sbyte)value).ToString(format, provider);
            }
        }

        internal class ByteToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((byte)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((byte)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((byte)value).ToString(format);
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((byte)value).ToString(format, provider);
            }
        }

        internal class Int16ToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((short)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((short)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((short)value).ToString(format);
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((short)value).ToString(format, provider);
            }
        }

        internal class UInt16ToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((ushort)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((ushort)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((ushort)value).ToString(format);
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((ushort)value).ToString(format, provider);
            }
        }

        internal class Int32ToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((int)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((int)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((int)value).ToString(format);
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((int)value).ToString(format, provider);
            }
        }

        internal class UInt32ToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((uint)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((uint)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((uint)value).ToString(format);
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((uint)value).ToString(format, provider);
            }
        }

        internal class Int64ToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((long)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((long)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((long)value).ToString(format);
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((long)value).ToString(format, provider);
            }
        }

        internal class UInt64ToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((ulong)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((ulong)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((ulong)value).ToString(format);
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((ulong)value).ToString(format, provider);
            }
        }

        internal class SingleToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((float)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((float)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((float)value).ToString(format);
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((float)value).ToString(format, provider);
            }
        }

        internal class DoubleToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((double)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((double)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((double)value).ToString(format);
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((double)value).ToString(format, provider);
            }
        }

        internal class DecimalToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((decimal)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((decimal)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((decimal)value).ToString(format);
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((decimal)value).ToString(format, provider);
            }
        }

        internal class DateTimeToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((DateTime)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((DateTime)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((DateTime)value).ToString(format);
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((DateTime)value).ToString(format, provider);
            }
        }

        internal class EmptyToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return value.ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return value.ToString();
            }

            public override string? ToString(object value, string? format)
            {
                return value.ToString();
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return value.ToString();
            }
        }

        internal class DBNullToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return value.ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return value.ToString();
            }

            public override string? ToString(object value, string? format)
            {
                return value.ToString();
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return value.ToString();
            }
        }

        internal class ObjectToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return value.ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return value.ToString();
            }

            public override string? ToString(object value, string? format)
            {
                return value.ToString();
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return value.ToString();
            }
        }

        internal class BooleanToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((bool)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((bool)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((bool)value).ToString();
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((bool)value).ToString(provider);
            }
        }

        internal class CharToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return ((char)value).ToString();
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return ((char)value).ToString(provider);
            }

            public override string? ToString(object value, string? format)
            {
                return ((char)value).ToString();
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ((char)value).ToString(provider);
            }
        }

        internal class TypeConverterAdapter : IObjectToString
        {
            private readonly TypeConverter converter;

            public TypeConverterAdapter(TypeConverter converter)
            {
                this.converter = converter;
            }

            public string? ToString(
                object value,
                ITypeDescriptorContext? context,
                CultureInfo? culture,
                bool useInvariantConversion)
            {
                string? result;

                if (useInvariantConversion)
                    result = InvariantConversion();
                else
                    result = Conversion();

                string? InvariantConversion()
                {
                    if (context is not null)
                    {
                        return converter.ConvertToInvariantString(context, value);
                    }
                    else
                    {
                        return converter.ConvertToInvariantString(value);
                    }
                }

                string? Conversion()
                {
                    if (context is null)
                    {
                        if (culture is null)
                        {
                            return converter.ConvertToString(value);
                        }
                        else
                        {
                            return converter.ConvertToString(null, culture, value);
                        }
                    }
                    else
                    {
                        if (culture is null)
                        {
                            return converter.ConvertToString(context, value);
                        }
                        else
                        {
                            return converter.ConvertToString(context, culture, value);
                        }
                    }
                }

                return result;
            }

            public string? ToString(object value)
            {
                return ToString(value, null, null, false);
            }

            public string? ToString(object value, IFormatProvider? provider)
            {
                return ToString(value);
            }

            public string? ToString(object value, string? format)
            {
                return ToString(value);
            }

            public string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return ToString(value);
            }
        }

        internal class StringToStringConverter : BaseToStringConverter, IObjectToString
        {
            public override string? ToString(object value)
            {
                return (string)value;
            }

            public override string? ToString(object value, IFormatProvider? provider)
            {
                return (string)value;
            }

            public override string? ToString(object value, string? format)
            {
                return (string)value;
            }

            public override string? ToString(object value, string? format, IFormatProvider? provider)
            {
                return (string)value;
            }
        }
    }
}