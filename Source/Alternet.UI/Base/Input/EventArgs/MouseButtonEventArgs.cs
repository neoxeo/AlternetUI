#nullable disable
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


using Alternet.Drawing;
using System;

namespace Alternet.UI
{
    /// <summary>
    ///     The delegate to use for handlers that receive MouseButtonEventArgs.
    /// </summary>
    public delegate void MouseButtonEventHandler(object sender, MouseButtonEventArgs e);

    /// <summary>
    ///     The MouseButtonEventArgs describes the state of a Mouse button.
    /// </summary>
    public class MouseButtonEventArgs : MouseEventArgs
    {
        private MouseButton _button;
        private int _count;

        /// <summary>
        ///     Initializes a new instance of the MouseButtonEventArgs class.
        /// </summary>
        /// <param name="mouse">
        ///     The logical Mouse device associated with this event.
        /// </param>
        /// <param name="timestamp">
        ///     The time when the input occurred.
        /// </param>
        /// <param name="button">
        ///     The mouse button whose state is being described.
        /// </param>
        public MouseButtonEventArgs(MouseDevice mouse, long timestamp, MouseButton button)
            : base(mouse, timestamp)
        {
            MouseButtonUtilities.Validate(button);
            
            _button = button;
            _count = 1;
        }

        /// <summary>
        ///     Read-only access to the button being described.
        /// </summary>
        public MouseButton ChangedButton
        {
            get {return _button;}
        }

        /// <summary>
        ///     Read-only access to the button state.
        /// </summary>
        public MouseButtonState ButtonState
        {
            get
            {
                MouseButtonState state = MouseButtonState.Released;
                
                switch(_button)
                {
                    case MouseButton.Left:
                        state = this.MouseDevice.LeftButton;
                        break;
                        
                    case MouseButton.Right:
                        state = this.MouseDevice.RightButton;
                        break;
                        
                    case MouseButton.Middle:
                        state = this.MouseDevice.MiddleButton;
                        break;
                        
                    case MouseButton.XButton1:
                        state = this.MouseDevice.XButton1;
                        break;
                        
                    case MouseButton.XButton2:
                        state = this.MouseDevice.XButton2;
                        break;
                }

                return state;
            }
        }

        /// <summary>
        ///     Read access to the button click count.
        /// </summary>
        public int ClickCount
        {
            get {return _count;}
            internal set { _count = value;}
        }

        /// <summary>
        ///     The mechanism used to call the type-specific handler on the
        ///     target.
        /// </summary>
        /// <param name="genericHandler">
        ///     The generic handler to call in a type-specific way.
        /// </param>
        /// <param name="genericTarget">
        ///     The target to call the handler on.
        /// </param>
        protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
        {
            MouseButtonEventHandler handler = (MouseButtonEventHandler) genericHandler;
            handler(genericTarget, this);
        }
    }
}
