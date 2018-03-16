using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;

namespace CommonClient
{
    public partial class wndPayeeQuery : frmBase
    {
        public wndPayeeQuery()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            this.Load += new EventHandler(wndPayeeQuery_Load);
            dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            batchPagesPanel.GoToSomePageEventHandeler += new EventHandler<VisualParts.BatchPageEventArgs>(batchPagesPanel_GoToSomePageEventHandeler);
        }

        void wndPayeeQuery_Load(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(edtPayeeAccount.Text.Trim()) || !string.IsNullOrEmpty(edtPayeeName.Text.Trim()))
                btnQuery.PerformClick();
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

        public wndPayeeQuery(AccountCategoryType act, string accountno = "", string accountname = "")
            : this()
        {
            m_AccountType = act;
            m_payeeType = PayeeType.Payee;
            edtPayeeAccount.Text = accountno;
            edtPayeeName.Text = accountname;
        }

        public wndPayeeQuery(AccountBankType abt, string accountno = "", string accountname = "")
            : this()
        {
            m_AccountBankType = abt;
            m_payeeType = PayeeType.Payee;
            edtPayeeAccount.Text = accountno;
            edtPayeeName.Text = accountname;
        }

        public wndPayeeQuery(AccountCategoryType act, AccountBankType abt, string accountno = "", string accountname = "")
            : this()
        {
            m_AccountType = act;
            m_AccountBankType = abt;
            m_payeeType = PayeeType.Payee;
            edtPayeeAccount.Text = accountno;
            edtPayeeName.Text = accountname;
        }

        public wndPayeeQuery(OverCountryPayeeAccountType ocpat, string accountno = "",string accountname="")
            : this()
        {
            m_OverCountryPayeeAccountType = ocpat;
            m_payeeType = PayeeType.PayeeTransferCountry;
            edtPayeeAccount.Text = accountno;
            edtPayeeName.Text = accountname;
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
                List<PayeeInfo> list = CommonInformations.GetPayeeList(payeeNo, payeeAccount, payeeName, m_AccountType, m_AccountBankType);
                batchPagesPanel.Tag = list;
                batchPagesPanel.Init(list.Count);
            }
            else if (m_payeeType == PayeeType.PayeeTransferCountry)
            {
                List<PayeeInfo4TransferGlobal> list = CommonInformations.GetPayeeTransferGlobalList(payeeNo, payeeAccount, payeeName, m_OverCountryPayeeAccountType);
                batchPagesPanel.Tag = list;
                batchPagesPanel.Init(list.Count);
            }
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
            if (m_payeeType == PayeeType.Payee)
                m_payee = (dgv.DataSource as List<PayeeInfo>)[e.RowIndex];
            else if (m_payeeType == PayeeType.PayeeTransferCountry)
                m_payeeTransferCountry = (dgv.DataSource as List<PayeeInfo4TransferGlobal>)[e.RowIndex];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
    }

    enum PayeeType
    {
        Empty = 0,
        Payee = 1,
        PayeeTransferCountry = 2
    }
}
