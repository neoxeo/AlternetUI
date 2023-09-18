using System;

namespace Alternet.UI
{
    /// <summary>
    /// Contains default property values for the control.
    /// </summary>
    public class ControlDefaults
    {
        private readonly object?[] props =
            new object[(int)ControlDefaultsId.MaxValue + 1];

        static ControlDefaults()
        {
        }

        /// <summary>
        /// Returns minimal margin value.
        /// </summary>
        public Thickness? MinMargin
        {
            get => (Thickness?)GetProp(ControlDefaultsId.MinMargin);
            set => SetProp(ControlDefaultsId.MinMargin, value);
        }

        /// <summary>
        /// Returns minimal padding value.
        /// </summary>
        public Thickness? MinPadding
        {
            get => (Thickness?)GetProp(ControlDefaultsId.MinPadding);
            set => SetProp(ControlDefaultsId.MinPadding, value);
        }

        /// <summary>
        /// Returns default property value.
        /// </summary>
        /// <param name="prop">Property identifier.</param>
        /// <returns></returns>
        public object? GetProp(ControlDefaultsId prop)
        {
            return props[(int)prop];
        }

        /// <summary>
        /// Sets default property value.
        /// </summary>
        /// <param name="prop">Property identifier.</param>
        /// <param name="value">New property value.</param>
        public void SetProp(ControlDefaultsId prop, object? value)
        {
            props[(int)prop] = value;
        }
    }
}