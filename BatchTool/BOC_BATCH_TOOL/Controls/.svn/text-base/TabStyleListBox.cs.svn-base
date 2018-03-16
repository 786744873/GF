using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.Properties;
using BOC_BATCH_TOOL.Types;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Controls
{
    public class TabStyleListBox : ListBox
    {
        public static readonly int DropDownItemHeight = 32;

        public TabStyleListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.ItemHeight = DropDownItemHeight;
            this.DrawItem += ListBox_DrawItem;
            this.DoubleBuffered = true;
            this.SizeChanged += new EventHandler(TabStyleListBox_SizeChanged);
        }

        void TabStyleListBox_SizeChanged(object sender, EventArgs e)
        {
            this.RefreshItems();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if (e.Index > -1 && e.Index < this.Items.Count)
                {
                    var description = this.Items[e.Index].ToString();
                    var frameBound = e.Bounds;
                    var textBound = e.Bounds;
                    textBound.Inflate(-32, -5);
                    textBound.Offset(9 + 3, 1);

                    frameBound.Inflate(-9, -1);
                    Brush brush1 = null;
                    Brush brush2 = null;
                    DrawingHelper.DrawRoundRectangle(e.Graphics, new Pen(Brushes.LightGray), frameBound, 3);
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        DrawingHelper.FillRoundRectangle(e.Graphics, Brushes.SteelBlue, frameBound, 3);
                        brush1 = Brushes.White;
                        brush2 = Brushes.Wheat;
                    }
                    else
                    {
                        DrawingHelper.FillRoundRectangle(e.Graphics, Brushes.White, frameBound, 3);
                        brush1 = Brushes.Navy;
                        brush2 = Brushes.Gray;
                    }
                    if (Resources.business != null)
                        e.Graphics.DrawImage(Resources.document, 13, frameBound.Y + 5, (int)this.ItemHeight - 11, (int)this.ItemHeight - 13);
                    var format = new StringFormat { Trimming = StringTrimming.EllipsisPath };
                    e.Graphics.DrawString(description, e.Font, brush1, new RectangleF(frameBound.X + 35, frameBound.Y + 12, frameBound.Width - 45, 18), format);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
