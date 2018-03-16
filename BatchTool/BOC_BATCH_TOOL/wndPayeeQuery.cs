using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.EnumTypes;

namespace BOC_BATCH_TOOL
{
    public partial class wndPayeeQuery : Form
    {
        public wndPayeeQuery()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            batchPagesPanel.GoToSomePageEventHandeler += new EventHandler<VisualParts.BatchPageEventArgs>(batchPagesPanel_GoToSomePageEventHandeler);
        }

        void batchPagesPanel_GoToSomePageEventHandeler(object sender, VisualParts.BatchPageEventArgs e)
        {
            if (e.CurrentPageNo == 0) return;
            dgv.DataSource = null;
            if (m_payeeType == PayeeType.Payee)
            {
                List<PayeeInfo> list = batchPagesPanel.Tag as List<PayeeInfo>;
                List<PayeeInfo> result = new List<PayeeInfo>();
                if (list.Count < e.PerPageRecordCount)
                    result = batchPagesPanel.Tag as List<PayeeInfo>;
                else
                    result = list.GetRange(e.StartRecordNo, e.ShowCount);

                dgv.DataSource = result;
            }
            else if (m_payeeType == PayeeType.PayeeTransferCountry)
            {
                List<PayeeInfo4TransferGlobal> list = batchPagesPanel.Tag as List<PayeeInfo4TransferGlobal>;
                List<PayeeInfo4TransferGlobal> result = new List<PayeeInfo4TransferGlobal>();
                if (list.Count < e.PerPageRecordCount)
                    result = batchPagesPanel.Tag as List<PayeeInfo4TransferGlobal>;
                else
                    result = list.GetRange(e.StartRecordNo, e.ShowCount);
                dgv.DataSource = result;
            }
            dgv.Refresh();
        }

        public wndPayeeQuery(AccountCategoryType act)
            : this()
        {
            m_AccountType = act;
            m_payeeType = PayeeType.Payee;
        }

        public wndPayeeQuery(AccountBankType abt)
            : this()
        {
            m_AccountBankType = abt;
            m_payeeType = PayeeType.Payee;
        }

        public wndPayeeQuery(AccountCategoryType act, AccountBankType abt)
            : this()
        {
            m_AccountType = act;
            m_AccountBankType = abt;
            m_payeeType = PayeeType.Payee;
        }

        public wndPayeeQuery(OverCountryPayeeAccountType ocpat)
            : this()
        {
            m_OverCountryPayeeAccountType = ocpat;
            m_payeeType = PayeeType.PayeeTransferCountry;
        }

        private PayeeInfo m_payee;
        /// <summary>
        /// 付收款人信息
        /// </summary>
        public PayeeInfo Payee
        {
            get { return m_payee; }
            protected set { m_payee = value; }
        }
        private PayeeInfo4TransferGlobal m_payeeTransferCountry;
        /// <summary>
        /// 国际结算收款人信息
        /// </summary>
        public PayeeInfo4TransferGlobal PayeeTransferCountry
        {
            get { return m_payeeTransferCountry; }
            protected set { m_payeeTransferCountry = value; }
        }
        AccountCategoryType m_AccountType = AccountCategoryType.Empty;
        AccountBankType m_AccountBankType = AccountBankType.Empty;
        OverCountryPayeeAccountType m_OverCountryPayeeAccountType = OverCountryPayeeAccountType.Empty;
        PayeeType m_payeeType = PayeeType.Empty;

        private void btnReset_Click(object sender, EventArgs e)
        {
            batchPagesPanel.Init(0);
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

            if (m_payeeType == PayeeType.Payee)
                m_payee = (dgv.DataSource as List<PayeeInfo>)[hitInfo.RowIndex];
            else if (m_payeeType == PayeeType.PayeeTransferCountry)
                m_payeeTransferCountry = (dgv.DataSource as List<PayeeInfo4TransferGlobal>)[hitInfo.RowIndex];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string payeeNo = edtPayeeSerial.Text.Trim();
            string payeeAccount = edtPayeeAccount.Text.Trim();
            string payeeName = edtPayeeName.Text.Trim();

            dgv.DataSource = null;
            dgv.Refresh();
            if (m_payeeType == PayeeType.Payee)
            {
                List<PayeeInfo> list = CommonInformations.Instance.GetPayeeList(payeeNo, payeeAccount, payeeName, m_AccountType, m_AccountBankType);
                batchPagesPanel.Tag = list;
                batchPagesPanel.Init(list.Count);
            }
            else if (m_payeeType == PayeeType.PayeeTransferCountry)
            {
                List<PayeeInfo4TransferGlobal> list = CommonInformations.Instance.GetPayeeTransferGlobalList(payeeNo, payeeAccount, payeeName, m_OverCountryPayeeAccountType);
                batchPagesPanel.Tag = list;
                batchPagesPanel.Init(list.Count);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }

    enum PayeeType
    {
        Empty = 0,
        Payee = 1,
        PayeeTransferCountry = 2
    }
}
