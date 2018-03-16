using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CommonClient.Controls
{
    public partial class AccountComboBox : ComboBox
    {
        public AccountComboBox()
        {
            InitializeComponent();

            lbox.SelectedIndexChanged += new EventHandler(lbox_SelectedIndexChanged);
            lbox.Visible = false;

            this.LostFocus += new EventHandler(AccountComboBox_LostFocus);
        }

        void AccountComboBox_LostFocus(object sender, EventArgs e)
        {
            lbox.Visible = false;
        }

        void lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbox.SelectedIndex >= 0)
            {
                string matchstr = this.Text.Trim();
                object obj = lbox.SelectedItem;
                int index = lbox.SelectedIndex;
                lbox.Visible = false;
                this.Text = obj.ToString();
                int tempindex = 0;
                int m_index = 0;
                foreach (var item in Items)
                {
                    if (item.ToString().Contains(matchstr))
                    {
                        if (item.ToString().Equals(obj.ToString()))
                        {
                            if (tempindex.Equals(index)) break;
                        }
                        tempindex++;
                    }
                    m_index++;
                }
                if (m_index == Items.Count) m_index = -1;
                SelectedIndex = m_index;
                if (m_index == -1) this.Text = obj.ToString();
            }
        }

        private ListBox lbox = new ListBox();

        bool flag = false;

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (Items.Count > 0)
            {
                if (this.Parent != null)
                {
                    string matchstr = this.Text.Trim();
                    List<object> list = new List<object>();
                    foreach (var item in Items)
                    {
                        list.Add(item);
                    }
                    if (string.IsNullOrEmpty(matchstr) || list.FindIndex(o => o.ToString().Equals(matchstr)) >= 0)
                    {
                        lbox.SendToBack();
                        lbox.Visible = false;
                        return;
                    }
                    if (!flag)
                    {
                        this.Parent.Controls.Add(lbox);
                        this.Parent.MouseClick += new MouseEventHandler(Parent_MouseClick);
                        flag = true;
                    }
                    lbox.BringToFront();
                    lbox.Items.Clear();
                    lbox.Visible = true;
                    lbox.Items.AddRange(list.FindAll(o => o.ToString().Contains(matchstr)).ToArray());
                    lbox.Location = new Point { X = this.Location.X, Y = this.Location.Y + this.Height };

                }
            }
        }

        void Parent_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            Rectangle rect = this.RectangleToScreen(this.ClientRectangle);
            if (!(p.X >= rect.Left && p.X <= rect.Left + rect.Width) || !(p.Y >= rect.Top && p.Y <= rect.Top + rect.Height))
                lbox.Visible = false;
        }
    }
}
