﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI
{
    /// <summary>
    /// Contains properties and methods which allow to work with clipboard.
    /// </summary>
    public interface IClipboardHandler : IDisposable
    {
        /// <inheritdoc cref="Clipboard.GetDataObject"/>
        IDataObject? GetData();

        /// <inheritdoc cref="Clipboard.SetDataObject(IDataObject?)"/>
        void SetData(IDataObject value);
    }
}
