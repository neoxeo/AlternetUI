﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    /// <summary>
    /// Arranges child controls into a single line that can be oriented vertically.
    /// </summary>
    [ControlCategory("Containers")]
    public class VerticalStackPanel : StackPanel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VerticalStackPanel"/> class.
        /// </summary>
        public VerticalStackPanel()
            : base()
        {
        }

        /// <summary>
        /// Gets a value that indicates the dimension by which child
        /// controls are stacked.
        /// </summary>
        [Browsable(false)]
        public override StackPanelOrientation Orientation
        {
            get => StackPanelOrientation.Vertical;

            set
            {
            }
        }
    }
}
