using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.Controls;
using CommonClient.ConvertHelper;
using CommonClient.Types;
using CommonClient.SysCoach;
using CommonClient.Utilities;
using CommonClient.EnumTypes;

namespace CommonClient
{
    public partial class frmCountryQuery : frmBase
    {
        public frmCountryQuery()
        {
            InitializeComponent();
            this.gb_Group.Controls.Clear();
            InitGroup();
        }

        public CNAP QueryResult = new CNAP();

        Point m_firstLocation = new Point() { X = 40, Y = 30 };

        int columnwidth = 60;
        int rowheight = 30;

        private void InitGroup()
        {
            List<string> list = new List<string>();
            switch (SystemSettings.CurrentLanguage)
            {
                case EnumTypes.UILang.CHS:
                    list.AddRange(new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "W", "X", "Y", "Z" });
                    break;
                case EnumTypes.UILang.EN:
                    list.AddRange(new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
                    break;
            }
            if (list.Count < 1) return;

            LinkLabel ll;

            for (int i = 0; i < list.Count; i++)
            {
                ll = new LinkLabel();

                ll.AutoSize = true;
                ll.Location = new System.Drawing.Point(m_firstLocation.X + columnwidth * (i % 9), m_firstLocation.Y + rowheight * ((int)(i / 9)));
                ll.Name = "linkLabel" + i.ToString();
                ll.Size = new System.Drawing.Size(11, 12);
                ll.TabIndex = i + 1;
                ll.TabStop = true;
                ll.Text = list[i];

                ll.LinkClicked += new LinkLabelLinkClickedEventHandler(ll_LinkClicked);

                gb_Group.Controls.Add(ll);
            }

            InitGroupVisiable(list);

            InitGroupData(list);
        }

        void ll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string groupname = ((LinkLabel)sender).Text;
            GroupBox gb = null;
            foreach (var item in this.panel2.Controls)
            {
                if (!(item is GroupBox))
                    continue;

                if (((GroupBox)item).Text.Equals(groupname))
                {
                    gb = (GroupBox)item;
                    break;
                }
            }
            panel2.ScrollControlIntoView(gb);
        }

        private void InitGroupVisiable(List<string> list)
        {
            foreach (var item in this.panel2.Controls)
            {
                if (!(item is GroupBox))
                    continue;

                ((GroupBox)item).Visible = list.Exists(o => o.Equals(((GroupBox)item).Text));
            }
        }

        private void InitGroupData(List<string> list)
        {
            List<CNAP> clist = new List<CNAP>();
            foreach (var item in PrequisiteDataProvideNode.InitialProvide.CountryHelperList)
            {
                string value = EnumNameHelper<CountryHelper>.GetEnumDescription(item);
                if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                    clist.Add(new CNAP { Name = value, Code = item.ToString() });
                else
                    clist.Add(new CNAP { Name = value, Code = ((int)item).ToString().PadLeft(3, '0') });
            }

            foreach (var item in list)
            {
                SetData(item, GetCNAPList(item, clist));
            }
        }
        private List<CNAP> GetCNAPList(string groupName, List<CNAP> templist)
        {
            List<CNAP> rlist = new List<CNAP>();
            switch (SystemSettings.CurrentLanguage)
            {
                case UILang.CHS:
                    rlist = templist.FindAll(o => CNSpellTranslator.GetSpellCode(o.Name).StartsWith(groupName.ToUpper()));
                    break;
                case UILang.EN:
                    rlist = templist.FindAll(o => o.Name.ToUpper().StartsWith(groupName.ToUpper()));
                    break;
            }
            return rlist;
        }

        private void SetData(string groupName, List<CNAP> templist)
        {
            GroupBox gb = null;
            foreach (var item in this.panel2.Controls)
            {
                if (!(item is GroupBox))
                    continue;

                if (((GroupBox)item).Text.Equals(groupName))
                {
                    gb = (GroupBox)item;
                    break;
                }
            }

            if (gb == null) return;

            foreach (var item in gb.Controls)
            {
                if (!(item is ThemedDataGridView)) continue;

                ((ThemedDataGridView)item).AutoGenerateColumns = false;
                ((ThemedDataGridView)item).DataSource = templist;
                ((ThemedDataGridView)item).MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
                ((ThemedDataGridView)item).CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
                if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                    ((ThemedDataGridView)item).Columns[1].HeaderText = "国家代码";
                else
                    ((ThemedDataGridView)item).Columns[1].HeaderText = "数字代码";
            }
        }

        void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = ((DataGridView)sender).HitTest(e.X, e.Y);
            if (hitInfo.RowIndex < 0) return;

            QueryResult = (((DataGridView)sender).DataSource as List<CNAP>)[hitInfo.RowIndex];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        /// <summary>
        /// 行 选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2 || e.RowIndex < 0) return;
            QueryResult = (((DataGridView)sender).DataSource as List<CNAP>)[e.RowIndex];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
