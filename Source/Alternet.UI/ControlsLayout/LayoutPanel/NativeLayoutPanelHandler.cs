using System.Collections.Generic;
using System.Linq;

namespace Alternet.UI
{
    internal class NativeLayoutPanelHandler : ControlHandler
    {
        public new LayoutPanel Control => (LayoutPanel)base.Control;

        public override IEnumerable<Control> AllChildrenIncludedInLayout
            => Enumerable.Empty<Control>();

        public override void OnLayout()
        {
            if (Control.Layout == GenericLayoutStyle.Default)
                LayoutPanel.PerformDockStyleLayout(Control);
        }

        internal override Native.Control CreateNativeControl()
        {
            return new Native.Panel();
        }
    }
}