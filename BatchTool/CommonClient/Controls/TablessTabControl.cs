using System.Drawing;
using System.Windows.Forms;

namespace CommonClient.Controls
{
    /// <summary>
    /// 为了设计期方便，只运行期才隐藏TAB标签
    /// </summary>
    public class TablessTabControl : TabControl
    {
        public TablessTabControl()
            : base()
        {
            // proof arrow key
            this.TabStop = false;
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                if (!DesignMode)
                    return ClientRectangle;
                return base.DisplayRectangle;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.Tab):
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
