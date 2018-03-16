using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.Entities;
using CommonClient.EnumTypes;

namespace CommonClient
{
    public partial class frmQueryRelateAccount : frmBase
    {
        public frmQueryRelateAccount()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            this.Load += new EventHandler(frmQueryRelateAccount_Load);
            batchPagesPanel.GoToSomePageEventHandeler += new EventHandler<VisualParts.BatchPageEventArgs>(batchPagesPanel_GoToSomePageEventHandeler);
            m_PersonType = RelatePersonType.Empty;
        }

        public frmQueryRelateAccount(string accountno = "", string accountname = "")
            : this()
        {
            edtPayeeAccount.Text = accountno;
            edtPayeeName.Text = accountname;
        }

        void frmQueryRelateAccount_Load(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(edtPayeeAccount.Text.Trim()) || !string.IsNullOrEmpty(edtPayeeName.Text.Trim()))
                btnQuery.PerformClick();
        }

        private ElecTicketRelationAccount m_relateAccount;
        /// <summary>
        /// 关系人信息
        /// </summary>
        public ElecTicketRelationAccount RelateAccount
        {
            get { return m_relateAccount; }
            protected set { m_relateAccount = value; }
        }

        private RelatePersonType m_PersonType;
        /// <summary>
        /// 关系人属性
        /// </summary>
        public RelatePersonType PersonType
        {
            get { return m_PersonType; }
            set { m_PersonType = value; }
        }

        void batchPagesPanel_GoToSomePageEventHandeler(object sender, VisualParts.BatchPageEventArgs e)
        {
            if (e.CurrentPageNo == 0)
            {
                dgv.DataSource = null; return;
            }
            List<ElecTicketRelationAccount> list = batchPagesPanel.Tag as List<ElecTicketRelationAccount>;
            if (list.Count < e.PerPageRecordCount)
                dgv.DataSource = list;
            else
            {
                List<ElecTicketRelationAccount> result = new List<ElecTicketRelationAccount>();
                result = list.GetRange(e.StartRecordNo, e.ShowCount);
                dgv.DataSource = null;
                dgv.DataSource = result;
            }
            dgv.Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            edtPayeeSerial.Text = string.Empty;
            edtPayeeAccount.Text = string.Empty;
            edtPayeeName.Text = string.Empty;
            dgv.DataSource = null;
            dgv.Refresh();
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (hitInfo.RowIndex < 0) return;

            m_relateAccount = (dgv.DataSource as List<ElecTicketRelationAccount>)[hitInfo.RowIndex];
            this.DialogResult = DialogResult.OK;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string payeeNo = edtPayeeSerial.Text.Trim();
            string payeeAccount = edtPayeeAccount.Text.Trim();
            string payeeName = edtPayeeName.Text.Trim();

            List<ElecTicketRelationAccount> list = CommonInformations.GetRelationAccountList(payeeNo, payeeAccount, payeeName, m_PersonType);
            dgv.DataSource = null;
            dgv.Refresh();
            batchPagesPanel.Tag = list;
            batchPagesPanel.Init(list.Count);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        /// <summary>
        /// 行 选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex != 4 || e.RowIndex < 0) return;
            m_relateAccount = (dgv.DataSource as List<ElecTicketRelationAccount>)[e.RowIndex];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;


        }
    }
}
