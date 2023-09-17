﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    /// <summary>
    /// Default <see cref="IComponentDesigner"/> implementation.
    /// </summary>
    public class ComponentDesigner : IComponentDesigner
    {
        /// <summary>
        /// Occurs when the property value changes.
        /// </summary>
        public event EventHandler<PropertyChangeEventArgs>? PropertyChanged;

        /// <summary>
        /// Gets or sets default <see cref="IComponentDesigner"/>.
        /// </summary>
        public static IComponentDesigner? Default { get; set; }

        /// <summary>
        /// Initializes <see cref="Default"/> if it wasn't assigned previously.
        /// </summary>
        public static void InitDefault()
        {
            Default ??= new ComponentDesigner();
        }

        /// <inheritdoc/>
        public virtual void RaisePropertyChanged(object? instance, string? propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangeEventArgs(instance, propName));
        }
    }
}
