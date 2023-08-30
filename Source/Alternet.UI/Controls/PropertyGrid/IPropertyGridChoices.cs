﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    /// <summary>
    /// Choices used in <see cref="PropertyGrid"/> items for enum and flags properties.
    /// </summary>
    public interface IPropertyGridChoices
    {
        /// <summary>
        /// Gets <see cref="IPropertyGridChoices"/> object handle.
        /// </summary>
        IntPtr Handle { get; }

        /// <summary>
        /// Adds new item.
        /// </summary>
        /// <param name="text">Item title.</param>
        /// <param name="value">Item value or id.</param>
        /// <param name="bitmap">Item image.</param>
        public void Add(string text, int value, ImageSet? bitmap = null);

        /// <summary>
        /// Adds new item with autogenerated id.
        /// </summary>
        /// <param name="text">Item title.</param>
        /// <returns>Item id.</returns>
        public int Add(string text);

        /// <summary>
        /// Adds the elements of the specified collection to the end.
        /// </summary>
        /// <param name="items">The collection whose elements should be added to the end.</param>
        public void AddRange(IEnumerable<string> items);

        /// <summary>
        /// Adds the elements of the specified collection to the end.
        /// </summary>
        /// <param name="items">The collection whose elements should be added to the end.</param>
        public void AddRange(IEnumerable<object> items);

        public int? GetValue(string text);

        public string? GetText(int value);

        public int Count { get; }
    }
}
