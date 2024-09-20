﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if IOS || MACCATALYST
using Foundation;

using SkiaSharp;

using UIKit;

namespace Alternet.UI
{
    /// <summary>
    /// Adds additional functionality to the <see cref="SkiaSharp.Views.iOS.SKCanvasView"/> control.
    /// </summary>
    public partial class SKCanvasViewAdv : SkiaSharp.Views.iOS.SKCanvasView
    {
        /// <summary>
        /// Raised when <see cref="PressesBegan"/> is called.
        /// </summary>
        public Action<SKCanvasViewAdv, PressesEventArgs>? OnPressesBegan;

        /// <summary>
        /// Raised when <see cref="PressesCancelled"/> is called.
        /// </summary>
        public Action<SKCanvasViewAdv, PressesEventArgs>? OnPressesCancelled;

        /// <summary>
        /// Raised when <see cref="UIHoverGestureRecognizer"/> state is changed.
        /// </summary>
        public Action<SKCanvasViewAdv, UIHoverGestureRecognizer>? OnHoverGestureRecognizer;

        /// <summary>
        /// Raised when <see cref="ShouldUpdateFocus"/> is called.
        /// </summary>
        public Func<SKCanvasViewAdv, UIFocusUpdateContext, bool>? OnShouldUpdateFocus;

        /// <summary>
        /// Raised when <see cref="DidUpdateFocus"/> is called.
        /// </summary>
        public Action<SKCanvasViewAdv, UIFocusUpdateContext>? OnDidUpdateFocus;

        /// <summary>
        /// Raised when <see cref="PressesChanged"/> is called.
        /// </summary>
        public Action<SKCanvasViewAdv, PressesEventArgs>? OnPressesChanged;

        /// <summary>
        /// Raised when <see cref="BecomeFirstResponder"/> is called.
        /// </summary>
        public Action<SKCanvasViewAdv>? OnBecomeFirstResponder;

        /// <summary>
        /// Raised when <see cref="ResignFirstResponder"/> is called.
        /// </summary>
        public Action<SKCanvasViewAdv>? OnResignFirstResponder;

        /// <summary>
        /// Raised when <see cref="PressesEnded"/> is called.
        /// </summary>
        public Action<SKCanvasViewAdv, PressesEventArgs>? OnPressesEnded;

        private static readonly Lazy<bool> isValidEnvironment = new(() =>
        {
            try
            {
                SKPMColor.PreMultiply(SKColors.Black);
                return true;
            }
            catch (DllNotFoundException)
            {
                return false;
            }
        });

        /// <summary>
        /// Initializes a new instance of the <see cref="SKCanvasViewAdv"/> class.
        /// </summary>
        /// <param name="handle"></param>
        public SKCanvasViewAdv(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SKCanvasViewAdv"/> class.
        /// </summary>
        public SKCanvasViewAdv()
        {
            Initialize();
        }

        /// <inheritdoc/>
        public override bool CanResignFirstResponder => true;

        /// <inheritdoc/>
        public override bool CanBecomeFirstResponder => true;

        /// <inheritdoc/>
        public override bool CanBecomeFocused
        {
            get
            {
                return true;
            }
        }

        internal static bool IsValidEnvironment => isValidEnvironment.Value;

        /// <inheritdoc/>
        public override void PressesBegan(NSSet<UIPress> presses, UIPressesEvent evt)
        {
            CallAction(presses, evt, OnPressesBegan, base.PressesBegan);
        }

        /// <inheritdoc/>
        public override bool BecomeFirstResponder()
        {
            return base.BecomeFirstResponder();
        }

        /// <inheritdoc/>
        public override bool ResignFirstResponder()
        {
            return base.ResignFirstResponder();
        }

        /// <inheritdoc/>
        public override void DidUpdateFocus(
            UIFocusUpdateContext context,
            UIFocusAnimationCoordinator coordinator)
        {
            if(OnDidUpdateFocus is not null)
            {
                OnDidUpdateFocus(this, context);
            }

            base.DidUpdateFocus(context, coordinator);
        }

        /// <inheritdoc/>
        public override bool ShouldUpdateFocus(UIFocusUpdateContext context)
        {
            if(OnShouldUpdateFocus is not null)
            {
                return OnShouldUpdateFocus(this, context);
            }

            return true;
        }

        /// <inheritdoc/>
        public override void PressesCancelled(NSSet<UIPress> presses, UIPressesEvent evt)
        {
            CallAction(presses, evt, OnPressesCancelled, base.PressesCancelled);
        }

        /// <inheritdoc/>
        public override void PressesChanged(NSSet<UIPress> presses, UIPressesEvent evt)
        {
            CallAction(presses, evt, OnPressesChanged, base.PressesChanged);
        }

        /// <inheritdoc/>
        public override void PressesEnded(NSSet<UIPress> presses, UIPressesEvent evt)
        {
            CallAction(presses, evt, OnPressesEnded, base.PressesEnded);
        }

        internal static void SamplePressesBegan(NSSet<UIPress> presses, UIPressesEvent evt)
        {
            foreach (UIPress press in presses)
            {
                var pressType = press.Type;

                // Was the Touch Surface clicked?
                if (press.Type == UIPressType.Select)
                {
                }

                if (press.Key is null)
                    continue;

                /*
                    public enum UIKeyModifierFlags : long
                    {
                        AlphaShift = 65536,
                        Shift = 131072,
                        Control = 262144,
                        Alternate = 524288,
                        Command = 1048576,
                        NumericPad = 2097152
                    }

                    static var alphaShift: UIKeyModifierFlags
                        A modifier flag that indicates the user pressed the Caps Lock key.
                    static var shift: UIKeyModifierFlags
                        A modifier flag that indicates the user pressed the Shift key.
                    static var control: UIKeyModifierFlags
                        A modifier flag that indicates the user pressed the Control key.
                    static var alternate: UIKeyModifierFlags
                        A modifier flag that indicates the user pressed the Option key.
                    static var command: UIKeyModifierFlags
                        A modifier flag that indicates the user pressed the Command key.
                    static var numericPad: UIKeyModifierFlags
                        A modifier flag that indicates the user pressed a key located on the numeric keypad.
                */

                var shift =
                    press.Key.ModifierFlags.HasFlag(UIKeyModifierFlags.AlphaShift) ||
                    press.Key.ModifierFlags.HasFlag(UIKeyModifierFlags.Shift);

                var keyCode = press.Key.KeyCode;

                if (keyCode == UIKeyboardHidUsage.KeyboardTab)
                {
                }
            }
        }

        /// <summary>
        /// Common initialization method which is called from the constructors.
        /// </summary>
        protected virtual void Initialize()
        {
            var recognizer = new UIHoverGestureRecognizer((g) =>
            {
                OnHoverGestureRecognizer?.Invoke(this, g);
            });

            AddGestureRecognizer(recognizer);
        }

        private void CallAction(
            NSSet<UIPress> presses,
            UIPressesEvent evt,
            Action<SKCanvasViewAdv, PressesEventArgs>? action,
            Action<NSSet<UIPress>, UIPressesEvent> baseAction)
        {
            var handled = false;

            if (action is not null)
            {
                PressesEventArgs e = new(presses, evt);
                action(this, e);
                handled = e.Handled;
            }

            if (!handled)
            {
                baseAction(presses, evt);
            }
        }

        /// <summary>
        /// Contains presses information.
        /// </summary>
        public class PressesEventArgs : HandledEventArgs
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PressesEventArgs"/> class.
            /// </summary>
            /// <param name="presses">Presses information.</param>
            /// <param name="evt"></param>
            public PressesEventArgs(NSSet<UIPress> presses, UIPressesEvent evt)
            {
                Presses = presses;
                Event = evt;
            }

            /// <summary>
            /// Gets or sets presses information.
            /// </summary>
            public NSSet<UIPress> Presses { get; set; }

            /// <summary>
            /// Gets or sets event object.
            /// </summary>
            public UIPressesEvent Event { get; set; }

            /// <inheritdoc/>
            public override string? ToString()
            {
                return base.ToString();
            }
        }
    }
}
#endif
