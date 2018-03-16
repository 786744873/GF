using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.Types;
using CommonClient.ConvertHelper;
using CommonClient.Utilities;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.MatchFile;
using CommonClient.Controls;

namespace CommonClient
{
    public partial class frmDealCodeQuery : frmBase
    {
        public frmDealCodeQuery()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDealCodeQuery_Load);
            dgv1.MouseDoubleClick += new MouseEventHandler(dgv_DoubleClick);
            dgv2.MouseDoubleClick += new MouseEventHandler(dgv_DoubleClick);
            dgv3.MouseDoubleClick += new MouseEventHandler(dgv_DoubleClick);
            dgv4.MouseDoubleClick += new MouseEventHandler(dgv_DoubleClick);
            dgv5.MouseDoubleClick += new MouseEventHandler(dgv_DoubleClick);
            dgv6.MouseDoubleClick += new MouseEventHandler(dgv_DoubleClick);
            dgv7.MouseDoubleClick += new MouseEventHandler(dgv_DoubleClick);
            dgv8.MouseDoubleClick += new MouseEventHandler(dgv_DoubleClick);
            dgv9.MouseDoubleClick += new MouseEventHandler(dgv_DoubleClick);
            dgv1.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            dgv2.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            dgv3.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            dgv4.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            dgv5.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            dgv6.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            dgv7.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            dgv8.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            dgv9.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
        }

        void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3 || e.RowIndex < 0) return;
            m_QueryResult = (((ThemedDataGridView)sender).DataSource as List<CNAP>)[e.RowIndex];
            this.DialogResult = DialogResult.OK;
        }

        public frmDealCodeQuery(AppliableFunctionType aft)
            : this()
        { m_appType = aft; }

        private AppliableFunctionType m_appType = AppliableFunctionType._Empty;

        void dgv_DoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = ((ThemedDataGridView)sender).HitTest(e.X, e.Y);
            if (hitInfo.RowIndex < 0) return;

            m_QueryResult = (((ThemedDataGridView)sender).DataSource as List<CNAP>)[hitInfo.RowIndex];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        void frmDealCodeQuery_Load(object sender, EventArgs e)
        {
            List<CNAP> Alllist = new List<CNAP>();
            string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\TTC.xml");
            if (!System.IO.File.Exists(filepath))
            {
                MessageBoxPrime.Show("可能系统数据文件已损坏或已丢失", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                return;
            }
            Alllist = DataFileHelper.GetDealSerialNos(filepath, m_appType);

            List<CNAP> templist;

            for (int i = 1401; i < 1410; i++)
            {
                string groupName = EnumNameHelper<DealSerialNoStringHelper>.GetEnumDescription((DealSerialNoStringHelper)i);
                templist = new List<CNAP>();
                templist = Alllist.FindAll(o => o.Group.Trim().Equals(groupName.Trim()));
                SetData(groupName, templist);
            }
        }

        private void SetData(string groupName, List<CNAP> templist)
        {
            GroupBox gb = null;
            foreach (var item in this.panel1.Controls)
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
            }
        }

        private CNAP m_QueryResult;
        /// <summary>
        /// 查询结果
        /// </summary>
        public CNAP QueryResult
        {
            get { return m_QueryResult; }
            set { m_QueryResult = value; }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string groupname = ((LinkLabel)sender).Text;
            GroupBox gb = null;
            foreach (var item in this.panel1.Controls)
            {
                if (!(item is GroupBox))
                    continue;

                if (((GroupBox)item).Text.Equals(groupname))
                {
                    gb = (GroupBox)item;
                    break;
                }
            }
            panel1.ScrollControlIntoView(gb);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
