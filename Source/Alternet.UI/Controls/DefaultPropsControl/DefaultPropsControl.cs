using System;

namespace Alternet.UI
{
    /// <summary>
    /// Contains default property values for the control.
    /// </summary>
    public class DefaultPropsControl
    {
        private readonly object?[] props = new object[(int)AllControlProps.MaxValue + 1];

        static DefaultPropsControl()
        {
        }

        /// <summary>
        /// Returns minimal margin value.
        /// </summary>
        public Thickness? MinMargin
        {
            get => (Thickness?)GetProp(AllControlProps.MinMargin);
            set => SetProp(AllControlProps.MinMargin, value);
        }

        /// <summary>
        /// Returns minimal padding value.
        /// </summary>
        public Thickness? MinPadding
        {
            get => (Thickness?)GetProp(AllControlProps.MinPadding);
            set => SetProp(AllControlProps.MinPadding, value);
        }

        /// <summary>
        /// Returns default property value.
        /// </summary>
        /// <param name="prop">Property identifier.</param>
        /// <returns></returns>
        public object? GetProp(AllControlProps prop)
        {
            return props[(int)prop];
        }

        /// <summary>
        /// Sets default property value.
        /// </summary>
        /// <param name="prop">Property identifier.</param>
        /// <param name="value">New property value.</param>
        public void SetProp(AllControlProps prop, object? value)
        {
            props[(int)prop] = value;
        }
    }
}