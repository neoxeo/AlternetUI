// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using Alternet.Drawing;

#pragma warning disable
#pragma warning disable 1634, 1691  // suppressing PreSharp warnings
#pragma warning restore

// There's a choice of where to send MouseWheel events - to the element under
// the mouse (like IE does) or to the element with keyboard focus (like Win32
// does).  The latter choice lets you move the mouse away from the area you're
// scrolling and still use the wheel.  
namespace Alternet.UI
{
    /// <summary>
    ///     The MouseDevice class represents the mouse device to the
    ///     members of a context.
    /// </summary>
    public class MouseDevice : DisposableObject
    {
        public static MouseDevice Default = new();

        protected MouseDevice()
        {
        }

        /// <summary>
        ///     The state of the left button.
        /// </summary>
        public MouseButtonState LeftButton
        {
            get
            {
                return GetButtonState(MouseButton.Left);
            }
        }

        /// <summary>
        ///     The state of the right button.
        /// </summary>
        public MouseButtonState RightButton
        {
            get
            {
                return GetButtonState(MouseButton.Right);
            }
        }

        /// <summary>
        ///     The state of the middle button.
        /// </summary>
        public MouseButtonState MiddleButton
        {
            get
            {
                return GetButtonState(MouseButton.Middle);
            }
        }

        /// <summary>
        ///     The state of the first extended button.
        /// </summary>
        public MouseButtonState XButton1
        {
            get
            {
                return GetButtonState(MouseButton.XButton1);
            }
        }

        /// <summary>
        ///     The state of the second extended button.
        /// </summary>
        public MouseButtonState XButton2
        {
            get
            {
                return GetButtonState(MouseButton.XButton2);
            }
        }

        /// <summary>
        ///     Gets the current position of the mouse in screen co-ords from either
        ///     the underlying system or the StylusDevice
        /// </summary>
        /// <returns>
        ///     The current mouse location in screen co-ords
        /// </returns>
        public virtual PointD GetScreenPosition()
        {
            var resultI = App.Handler.GetMousePositionFromSystem();
            var index = Display.GetFromPoint(resultI);
            var display = Display.AllScreens[index];
            var result = display.PixelToDip(resultI);
            return result;
        }

        /// <summary>
        ///     Gets the current state of the specified button from the device
        ///     from either the underlying system or the StylusDevice
        /// </summary>
        /// <param name="mouseButton">
        ///     The mouse button to get the state of
        /// </param>
        /// <returns>
        ///     The state of the specified mouse button
        /// </returns>
        protected virtual MouseButtonState GetButtonState(MouseButton mouseButton)
        {
            return App.Handler.GetMouseButtonStateFromSystem(mouseButton);;
        }
    }
}