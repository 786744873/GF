using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.MatchFile;
using CommonClient.Entities;
using CommonClient.ConvertHelper;

namespace CommonClient
{
    public partial class wndLinkBankNo : frmBase
    {
        public wndLinkBankNo()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            //dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            batchPagesPanel.GoToSomePageEventHandeler += new EventHandler<VisualParts.BatchPageEventArgs>(batchPagesPanel_GoToSomePageEventHandeler);
            this.Load += new EventHandler(wndLinkBankNo_Load);

        }

        void wndLinkBankNo_Load(object sender, EventArgs e)
        {
            btnQuery.PerformClick();
        }
        public wndLinkBankNo(string BankName)
            : this()
        {
            tbBankName.Text = BankName;
        }
        void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (hitInfo.RowIndex < 0) return;

            m_BankInfo = (dgv.DataSource as List<BankInfo>)[hitInfo.RowIndex];
            this.DialogResult = DialogResult.OK;
        }

        void batchPagesPanel_GoToSomePageEventHandeler(object sender, VisualParts.BatchPageEventArgs e)
        {
            if (e.CurrentPageNo == 0) { dgv.DataSource = null; return; }
            List<BankInfo> list = batchPagesPanel.Tag as List<BankInfo>;
            if (list == null)
            { dgv.DataSource = null; }
            else if (list.Count < e.PerPageRecordCount)
                dgv.DataSource = list;
            else
            {
                List<BankInfo> result = new List<BankInfo>();
                result = list.GetRange(e.StartRecordNo, e.ShowCount);
                dgv.DataSource = null;
                dgv.DataSource = result;
            }
            dgv.Refresh();
        }

        void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2 || e.RowIndex < 0) return;
            m_BankInfo = (dgv.DataSource as List<BankInfo>)[e.RowIndex];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private BankInfo m_BankInfo;
        /// <summary>
        /// 联行号和银行名称
        /// </summary>
        public BankInfo BankInfo
        {
            get { return m_BankInfo; }
            protected set { m_BankInfo = value; }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string bankName = tbBankName.Text.Trim();
            dgv.DataSource = null;
            dgv.Refresh();
            List<BankInfo> list = new List<BankInfo>();
            list = DataFileHelper.GetLinkBankNo(bankName);
            list = list.FindAll(o => o.LinkID.StartsWith("4"));
            batchPagesPanel.Tag = list;
            batchPagesPanel.Init(list.Count);

            if (string.IsNullOrEmpty(bankName) && (list == null || list.Count == 0))
                MessageBoxPrime.Show("可能系统数据文件已损坏或已丢失，\r\n请从网银下载中行联行号文件进行本地更新", CommonClient.SysCoach.CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
