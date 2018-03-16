using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.EnumTypes;

namespace BOC_BATCH_TOOL
{
    public partial class frmQueryRelateAccount : Form
    {
        public frmQueryRelateAccount()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            batchPagesPanel.GoToSomePageEventHandeler += new EventHandler<VisualParts.BatchPageEventArgs>(batchPagesPanel_GoToSomePageEventHandeler);
            m_PersonType = RelatePersonType.Empty;
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
            {
                dgv.DataSource = list;
            }
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
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string payeeNo = edtPayeeSerial.Text.Trim();
            string payeeAccount = edtPayeeAccount.Text.Trim();
            string payeeName = edtPayeeName.Text.Trim();

            List<ElecTicketRelationAccount> list = CommonInformations.Instance.GetRelationAccountList(payeeNo, payeeAccount, payeeName, m_PersonType);
            dgv.DataSource = null;
            dgv.Refresh();
            batchPagesPanel.Tag = list;
            batchPagesPanel.Init(list.Count);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
