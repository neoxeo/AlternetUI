﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alternet.Drawing;

namespace Alternet.UI
{
    /// <summary>
    /// Provides data for the <see cref="IComboBoxItemPainter.Paint"/> event.
    /// </summary>
    public class ComboBoxItemPaintEventArgs
        : PaintEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxItemPaintEventArgs"/> class.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="graphics"></param>
        /// <param name="bounds"></param>
        public ComboBoxItemPaintEventArgs(ComboBox control, Graphics graphics, RectD bounds)
            : base(graphics, bounds)
        {
            ComboBox = control;
        }

        /// <summary>
        /// Gets whether item is selected
        /// </summary>
        public bool IsSelected { get; internal set; }

        /// <summary>
        /// Gets whether painting is done inside <see cref="ComboBox"/> (<c>true</c>)
        /// or in the popup control (<c>false</c>).
        /// </summary>
        public bool IsPaintingControl { get; internal set; }

        /// <summary>
        /// Get whether item index is not found.
        /// </summary>
        public bool IsIndexNotFound { get; internal set; }

        /// <summary>
        /// Gets index of the item.
        /// </summary>
        public int ItemIndex { get; internal set; }

        /// <summary>
        /// Gets whether background painting need to be performed.
        /// </summary>
        public bool IsPaintingBackground { get; internal set; }

        internal ComboBox ComboBox { get; set; }

        /// <summary>
        /// Default drawing method.
        /// </summary>
        public void DefaultPaint()
        {
            if (IsPaintingBackground)
                ComboBox.NativeControl.DefaultOnDrawBackground();
            else
                ComboBox.NativeControl.DefaultOnDrawItem();
        }
    }
}
