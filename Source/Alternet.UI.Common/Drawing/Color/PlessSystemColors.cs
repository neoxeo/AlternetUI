﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkiaSharp;

using Alternet.UI;
using System.Runtime.CompilerServices;

namespace Alternet.Drawing
{
    public static class PlessSystemColors
    {
        private static readonly ColorStruct[] Colors;

        static PlessSystemColors()
        {
            Colors = new ColorStruct[(int)KnownSystemColor.MenuHighlight + 1];
            ResetFromConsts();
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color
        /// of the active window's border.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the
        /// active window's border.</returns>
        public static ColorStruct ActiveBorder
        {
            get => GetColor(KnownSystemColor.ActiveBorder);
            set => SetColor(KnownSystemColor.ActiveBorder, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color
        /// of the background of the active window's title bar.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the
        /// active window's title bar.</returns>
        public static ColorStruct ActiveCaption
        {
            get => GetColor(KnownSystemColor.ActiveCaption);
            set => SetColor(KnownSystemColor.ActiveCaption, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color
        /// of the text in the active window's title bar.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the text in
        /// the active window's title bar.</returns>
        public static ColorStruct ActiveCaptionText
        {
            get => GetColor(KnownSystemColor.ActiveCaptionText);
            set => SetColor(KnownSystemColor.ActiveCaptionText, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color
        /// of the application workspace. </summary>
        /// <returns>A <see cref="Color" /> that is the color of the
        /// application workspace.</returns>
        public static ColorStruct AppWorkspace
        {
            get => GetColor(KnownSystemColor.AppWorkspace);
            set => SetColor(KnownSystemColor.AppWorkspace, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the face
        /// color of a 3-D element.</summary>
        /// <returns>A <see cref="Color" /> that is the face color of
        /// a 3-D element.</returns>
        public static ColorStruct ButtonFace
        {
            get => GetColor(KnownSystemColor.ButtonFace);
            set => SetColor(KnownSystemColor.ButtonFace, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the
        /// highlight color of a 3-D element. </summary>
        /// <returns>A <see cref="Color" /> that is the highlight color
        /// of a 3-D element.</returns>
        public static ColorStruct ButtonHighlight
        {
            get => GetColor(KnownSystemColor.ButtonHighlight);
            set => SetColor(KnownSystemColor.ButtonHighlight, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the shadow
        /// color of a 3-D element. </summary>
        /// <returns>A <see cref="Color" /> that is the shadow color of
        /// a 3-D element.</returns>
        public static ColorStruct ButtonShadow
        {
            get => GetColor(KnownSystemColor.ButtonShadow);
            set => SetColor(KnownSystemColor.ButtonShadow, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the
        /// face color of a 3-D element.</summary>
        /// <returns>A <see cref="Color" /> that is the face color of
        /// a 3-D element.</returns>
        public static ColorStruct Control
        {
            get => GetColor(KnownSystemColor.Control);
            set => SetColor(KnownSystemColor.Control, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the shadow color of a 3-D
        /// element. </summary>
        /// <returns>A <see cref="Color" /> that is the shadow color of a 3-D element.</returns>
        public static ColorStruct ControlDark
        {
            get => GetColor(KnownSystemColor.ControlDark);
            set => SetColor(KnownSystemColor.ControlDark, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the dark shadow color
        /// of a 3-D element. </summary>
        /// <returns>A <see cref="Color" /> that is the dark shadow color of a 3-D element.</returns>
        public static ColorStruct ControlDarkDark
        {
            get => GetColor(KnownSystemColor.ControlDarkDark);
            set => SetColor(KnownSystemColor.ControlDarkDark, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the light color of a 3-D
        /// element. </summary>
        /// <returns>A <see cref="Color" /> that is the light color of a 3-D element.</returns>
        public static ColorStruct ControlLight
        {
            get => GetColor(KnownSystemColor.ControlLight);
            set => SetColor(KnownSystemColor.ControlLight, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the highlight color of
        /// a 3-D element. </summary>
        /// <returns>A <see cref="Color" /> that is the highlight color of a 3-D element.</returns>
        public static ColorStruct ControlLightLight
        {
            get => GetColor(KnownSystemColor.ControlLightLight);
            set => SetColor(KnownSystemColor.ControlLightLight, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of the desktop.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the desktop.</returns>
        public static ColorStruct Desktop
        {
            get => GetColor(KnownSystemColor.Desktop);
            set => SetColor(KnownSystemColor.Desktop, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the lightest color in the
        /// color gradient of an active window's title bar.</summary>
        /// <returns>A <see cref="Color" /> that is the lightest color in the color gradient
        /// of an active window's title bar.</returns>
        public static ColorStruct GradientActiveCaption
        {
            get => GetColor(KnownSystemColor.GradientActiveCaption);
            set => SetColor(KnownSystemColor.GradientActiveCaption, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the lightest color in the
        /// color gradient of an inactive window's title bar.</summary>
        /// <returns>A <see cref="Color" /> that is the lightest color in the color gradient
        /// of an inactive window's title bar.</returns>
        public static ColorStruct GradientInactiveCaption
        {
            get => GetColor(KnownSystemColor.GradientInactiveCaption);
            set => SetColor(KnownSystemColor.GradientInactiveCaption, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of dimmed
        /// text. </summary>
        /// <returns>A <see cref="Color" /> that is the color of dimmed text.</returns>
        public static ColorStruct GrayText
        {
            get => GetColor(KnownSystemColor.GrayText);
            set => SetColor(KnownSystemColor.GrayText, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of the background
        /// of selected items.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the background of selected
        /// items.</returns>
        public static ColorStruct Highlight
        {
            get => GetColor(KnownSystemColor.Highlight);
            set => SetColor(KnownSystemColor.Highlight, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of the text of
        /// selected items.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the text of selected
        /// items.</returns>
        public static ColorStruct HighlightText
        {
            get => GetColor(KnownSystemColor.HighlightText);
            set => SetColor(KnownSystemColor.HighlightText, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color used to designate
        /// a hot-tracked item. </summary>
        /// <returns>A <see cref="Color" /> that is the color used to designate a hot-tracked
        /// item.</returns>
        public static ColorStruct HotTrack
        {
            get => GetColor(KnownSystemColor.HotTrack);
            set => SetColor(KnownSystemColor.HotTrack, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of an inactive
        /// window's border.</summary>
        /// <returns>A <see cref="Color" /> that is the color of an inactive window's
        /// border.</returns>
        public static ColorStruct InactiveBorder
        {
            get => GetColor(KnownSystemColor.InactiveBorder);
            set => SetColor(KnownSystemColor.InactiveBorder, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of the background
        /// of an inactive window's title bar.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the background of an
        /// inactive window's title bar.</returns>
        public static ColorStruct InactiveCaption
        {
            get => GetColor(KnownSystemColor.InactiveCaption);
            set => SetColor(KnownSystemColor.InactiveCaption, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of the text
        /// in an inactive window's title bar.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the text in an inactive
        /// window's title bar.</returns>
        public static ColorStruct InactiveCaptionText
        {
            get => GetColor(KnownSystemColor.InactiveCaptionText);
            set => SetColor(KnownSystemColor.InactiveCaptionText, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of the background
        /// of a ToolTip.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the background of a
        /// ToolTip.</returns>
        public static ColorStruct Info
        {
            get => GetColor(KnownSystemColor.Info);
            set => SetColor(KnownSystemColor.Info, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of the text
        /// of a ToolTip.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the text of a ToolTip.</returns>
        public static ColorStruct InfoText
        {
            get => GetColor(KnownSystemColor.InfoText);
            set => SetColor(KnownSystemColor.InfoText, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of a menu's
        /// background.</summary>
        /// <returns>A <see cref="Color" /> that is the color of a menu's background.</returns>
        public static ColorStruct Menu
        {
            get => GetColor(KnownSystemColor.Menu);
            set => SetColor(KnownSystemColor.Menu, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of the
        /// background of a menu bar.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the background of a menu
        /// bar.</returns>
        public static ColorStruct MenuBar
        {
            get => GetColor(KnownSystemColor.MenuBar);
            set => SetColor(KnownSystemColor.MenuBar, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color used to highlight
        /// menu items when the menu appears as a flat menu.</summary>
        /// <returns>A <see cref="Color" /> that is the color used to highlight menu items
        /// when the menu appears as a flat menu.</returns>
        public static ColorStruct MenuHighlight
        {
            get => GetColor(KnownSystemColor.MenuHighlight);
            set => SetColor(KnownSystemColor.MenuHighlight, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of a menu's
        /// text.</summary>
        /// <returns>A <see cref="Color" /> that is the color of a menu's text.</returns>
        public static ColorStruct MenuText
        {
            get => GetColor(KnownSystemColor.MenuText);
            set => SetColor(KnownSystemColor.MenuText, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of the background
        /// of a scroll bar.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the background of a scroll
        /// bar.</returns>
        public static ColorStruct ScrollBar
        {
            get => GetColor(KnownSystemColor.ScrollBar);
            set => SetColor(KnownSystemColor.ScrollBar, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of
        /// a window frame.</summary>
        /// <returns>A <see cref="Color" /> that is the color of a window frame.</returns>
        public static ColorStruct WindowFrame
        {
            get => GetColor(KnownSystemColor.WindowFrame);
            set => SetColor(KnownSystemColor.WindowFrame, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of the background
        /// in the client area of a window.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the background in the client
        /// area of a window.</returns>
        public static ColorStruct Window
        {
            get => GetColor(KnownSystemColor.Window);
            set => SetColor(KnownSystemColor.Window, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of the text in the
        /// client area of a window.</summary>
        /// <returns>A <see cref="Color" /> that is the color of the text in the client area
        /// of a window.</returns>
        public static ColorStruct WindowText
        {
            get => GetColor(KnownSystemColor.WindowText);
            set => SetColor(KnownSystemColor.WindowText, value);
        }

        /// <summary>Gets a <see cref="Color" /> structure that is the color of text in a
        /// 3-D element.</summary>
        /// <returns>A <see cref="Color" /> that is the color of text in a 3-D element.</returns>
        public static ColorStruct ControlText
        {
            get => GetColor(KnownSystemColor.ControlText);
            set => SetColor(KnownSystemColor.ControlText, value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ColorStruct GetColor(KnownSystemColor id)
        {
            return Colors[(int)id];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetColor(KnownSystemColor id, ColorStruct value)
        {
            Colors[(int)id] = value;
        }

        public static void ResetFromPlatform()
        {
            if(SystemSettings.Handler.GetColor(KnownSystemColor.Window) is null)
            {
                ResetFromConsts();
                return;
            }

            ResetColor(KnownSystemColor.ActiveBorder);
            ResetColor(KnownSystemColor.ActiveCaption);
            ResetColor(KnownSystemColor.ActiveCaptionText);
            ResetColor(KnownSystemColor.AppWorkspace);
            ResetColor(KnownSystemColor.ButtonFace);
            ResetColor(KnownSystemColor.ButtonHighlight);
            ResetColor(KnownSystemColor.ButtonShadow);
            ResetColor(KnownSystemColor.Control);
            ResetColor(KnownSystemColor.ControlDark);
            ResetColor(KnownSystemColor.ControlDarkDark);
            ResetColor(KnownSystemColor.ControlLight);
            ResetColor(KnownSystemColor.ControlLightLight);
            ResetColor(KnownSystemColor.Desktop);
            ResetColor(KnownSystemColor.GradientActiveCaption);
            ResetColor(KnownSystemColor.GradientInactiveCaption);
            ResetColor(KnownSystemColor.GrayText);
            ResetColor(KnownSystemColor.Highlight);
            ResetColor(KnownSystemColor.HighlightText);
            ResetColor(KnownSystemColor.HotTrack);
            ResetColor(KnownSystemColor.InactiveBorder);
            ResetColor(KnownSystemColor.InactiveCaption);
            ResetColor(KnownSystemColor.InactiveCaptionText);
            ResetColor(KnownSystemColor.Info);
            ResetColor(KnownSystemColor.InfoText);
            ResetColor(KnownSystemColor.Menu);
            ResetColor(KnownSystemColor.MenuBar);
            ResetColor(KnownSystemColor.MenuHighlight);
            ResetColor(KnownSystemColor.MenuText);
            ResetColor(KnownSystemColor.ScrollBar);
            ResetColor(KnownSystemColor.WindowFrame);
            ResetColor(KnownSystemColor.Window);
            ResetColor(KnownSystemColor.WindowText);
            ResetColor(KnownSystemColor.ControlText);

            void ResetColor(KnownSystemColor color)
            {
                SetColor(color, SystemSettings.Handler.GetColor(color)!.Value);
            }
        }

        public static void ResetFromConsts()
        {
            SetColor(KnownSystemColor.ActiveBorder, (255, 180, 180, 180));
            SetColor(KnownSystemColor.ActiveCaption, (255, 153, 180, 209));
            SetColor(KnownSystemColor.ActiveCaptionText, (255, 0, 0, 0));
            SetColor(KnownSystemColor.AppWorkspace, (255, 171, 171, 171));
            SetColor(KnownSystemColor.ButtonFace, (255, 240, 240, 240));
            SetColor(KnownSystemColor.ButtonHighlight, (255, 255, 255, 255));
            SetColor(KnownSystemColor.ButtonShadow, (255, 160, 160, 160));
            SetColor(KnownSystemColor.Control, (255, 240, 240, 240));
            SetColor(KnownSystemColor.ControlDark, (255, 160, 160, 160));
            SetColor(KnownSystemColor.ControlDarkDark, (255, 105, 105, 105));
            SetColor(KnownSystemColor.ControlLight, (255, 227, 227, 227));
            SetColor(KnownSystemColor.ControlLightLight, (255, 255, 255, 255));
            SetColor(KnownSystemColor.Desktop, (255, 0, 0, 0));
            SetColor(KnownSystemColor.GradientActiveCaption, (255, 185, 209, 234));
            SetColor(KnownSystemColor.GradientInactiveCaption, (255, 215, 228, 242));
            SetColor(KnownSystemColor.GrayText, (255, 109, 109, 109));
            SetColor(KnownSystemColor.Highlight, (255, 0, 120, 215));
            SetColor(KnownSystemColor.HighlightText, (255, 255, 255, 255));
            SetColor(KnownSystemColor.HotTrack, (255, 0, 102, 204));
            SetColor(KnownSystemColor.InactiveBorder, (255, 244, 247, 252));
            SetColor(KnownSystemColor.InactiveCaption, (255, 191, 205, 219));
            SetColor(KnownSystemColor.InactiveCaptionText, (255, 0, 0, 0));
            SetColor(KnownSystemColor.Info, (255, 255, 255, 225));
            SetColor(KnownSystemColor.InfoText, (255, 0, 0, 0));
            SetColor(KnownSystemColor.Menu, (255, 240, 240, 240));
            SetColor(KnownSystemColor.MenuBar, (255, 240, 240, 240));
            SetColor(KnownSystemColor.MenuHighlight, (255, 0, 120, 215));
            SetColor(KnownSystemColor.MenuText, (255, 0, 0, 0));
            SetColor(KnownSystemColor.ScrollBar, (255, 200, 200, 200));
            SetColor(KnownSystemColor.WindowFrame, (255, 100, 100, 100));
            SetColor(KnownSystemColor.Window, (255, 255, 255, 255));
            SetColor(KnownSystemColor.WindowText, (255, 0, 0, 0));
            SetColor(KnownSystemColor.ControlText, (255, 0, 0, 0));
        }
    }
}