﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternet.UI;

/// <summary>
/// Base class for WxWidgets controls.
/// </summary>
public class WxBaseControl : Control
{
    /// <summary>
    /// Gets <see cref="NativeControl"/> attached to this control.
    /// </summary>
    internal Native.Control NativeControl => ((WxControlHandler)Handler).NativeControl;

    internal new WxControlHandler Handler => (WxControlHandler)base.Handler;

    internal IControlHandlerFactory? ControlHandlerFactory { get; set; }

    /// <summary>
    /// Gets an <see cref="IControlHandlerFactory"/> to use when creating
    /// new control handlers for this control.
    /// </summary>
    internal IControlHandlerFactory GetEffectiveControlHandlerHactory() =>
        ControlHandlerFactory ??
            Application.Current.VisualTheme.ControlHandlerFactory;

    /// <inheritdoc/>
    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
#if DEBUG
        KeyInfo.Run(KnownKeys.ShowDeveloperTools, e, DebugUtils.ShowDeveloperTools);
#endif
    }
}