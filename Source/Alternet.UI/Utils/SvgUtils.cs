﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alternet.Drawing;

namespace Alternet.UI
{
    /// <summary>
    /// Contains static methods related to Svg image handling.
    /// </summary>
    public static class SvgUtils
    {
        private const string ResTemplate =
            "embres:Alternet.UI.Resources.Svg.{0}.svg?assembly=Alternet.UI";

        /// <summary>
        /// Gets or sets url used to load "plus" svg image used in "Add" toolbar buttons.
        /// </summary>
        public static string UrlImagePlus { get; set; } = GetImageUrl("plus");

        /// <summary>
        /// Gets or sets url used to load "minus" svg image used in "Remove" toolbar buttons.
        /// </summary>
        public static string UrlImageMinus { get; set; } = GetImageUrl("minus");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Ok" toolbar buttons.
        /// </summary>
        public static string UrlImageOk { get; set; } = GetImageUrl("check");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Cancel" toolbar buttons.
        /// </summary>
        public static string UrlImageCancel { get; set; } = GetImageUrl("xmark");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Add child" toolbar buttons.
        /// </summary>
        public static string UrlImageAddChild { get; set; } = GetImageUrl("alternet-add-child");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Remove All" toolbar buttons.
        /// </summary>
        public static string UrlImageRemoveAll { get; set; } = GetImageUrl("eraser");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Apply" toolbar buttons.
        /// </summary>
        public static string UrlImageApply { get; set; } = GetImageUrl("square-check");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Back" toolbar buttons
        /// for the <see cref="WebBrowser"/>.
        /// </summary>
        public static string UrlImageWebBrowserBack { get; set; } = GetImageUrl("arrow-left");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Home" toolbar buttons
        /// for the <see cref="WebBrowser"/>.
        /// </summary>
        public static string UrlImageWebBrowserHome { get; set; } = GetImageUrl("house");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Forward" toolbar buttons
        /// for the <see cref="WebBrowser"/>.
        /// </summary>
        public static string UrlImageWebBrowserForward { get; set; } = GetImageUrl("arrow-right");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Zoom In" toolbar buttons.
        /// </summary>
        public static string UrlImageZoomIn { get; set; } = GetImageUrl("alternet-zoomin");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Zoom Out" toolbar buttons.
        /// </summary>
        public static string UrlImageZoomOut { get; set; } = GetImageUrl("alternet-zoomout");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Go" toolbar buttons
        /// for the <see cref="WebBrowser"/>.
        /// </summary>
        public static string UrlImageWebBrowserGo { get; set; } = GetImageUrl("caret-right");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Refresh" toolbar buttons
        /// for the <see cref="WebBrowser"/>.
        /// </summary>
        public static string UrlImageWebBrowserRefresh { get; set; } = GetImageUrl("rotate-right");

        /// <summary>
        /// Gets or sets url used to load svg image used in "Stop" toolbar buttons
        /// for the <see cref="WebBrowser"/>.
        /// </summary>
        public static string UrlImageWebBrowserStop { get; set; } = GetImageUrl("xmark");

        private static string GetImageUrl(string name) => string.Format(ResTemplate, name);
    }
}
