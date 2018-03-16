using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.EnumTypes;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class UnitivePaymentRMBPayerSelector : BaseUc
    {
        public UnitivePaymentRMBPayerSelector()
        {
            InitializeComponent();
            Init();

            CommandCenter.Instance.OnUnitivePaymentRMBEventHandler += new EventHandler<UnitivePaymentRMBEventArgs>(CommandCenter_OnUnitivePaymentRMBEventHandler);
        }

        void CommandCenter_OnUnitivePaymentRMBEventHandler(object sender, UnitivePaymentRMBEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<UnitivePaymentRMBEventArgs>(CommandCenter_OnUnitivePaymentRMBEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                { SetItem(e.UnitivePaymentRMB); }
                else if (e.Command == OperatorCommandType.Reset)
                { SetItem(null); }
            }
        }

        AppliableFunctionType m_AppType;

        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }
        UnitivePaymentRMB m_CurrentUnitivePaymentRMB = null;
        [Browsable(true)]
        public UnitivePaymentRMB CurrentUnitivePaymentRMB
        {
            get { return m_CurrentUnitivePaymentRMB; }
            set { m_CurrentUnitivePaymentRMB = value; }
        }

        void Init()
        { }

        public void GetItem()
        {
            m_CurrentUnitivePaymentRMB = new UnitivePaymentRMB();
            m_CurrentUnitivePaymentRMB.NominalPayerAccount = tbPayerAccount.Text.Trim();
            m_CurrentUnitivePaymentRMB.NominalPayerName = tbPayerName.Text.Trim();
            //m_CurrentUnitivePaymentRMB.NominalPayerBankLinkNo = tbBankLinkNo.Text.Trim();
            //m_CurrentUnitivePaymentRMB.NominalPayerOpenBankName = tbOpenBank.Text.Trim();
        }

        void SetItem(UnitivePaymentRMB item)
        {
            if (null == item)
            {
                tbPayerAccount.Text =
                tbPayerName.Text =
                tbBankLinkNo.Text =
                tbOpenBank.Text = string.Empty;
            }
            else
            {
                tbPayerAccount.Text = item.NominalPayerAccount;
                tbPayerName.Text = item.NominalPayerName;
                tbBankLinkNo.Text = item.NominalPayerBankLinkNo;
                tbOpenBank.Text = item.NominalPayerOpenBankName;
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData() { Result = true };
            rd = DataCheckCenter.Instance.CheckAccountUP(tbPayerAccount, tbPayerAccount.Text.Trim(), lbPayerAccount.Text.Substring(0, lbPayerAccount.Text.Length - 1), 35, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckPayeeNameAgentInOrUP(tbPayerName, tbPayerName.Text.Trim(), lbPayerName.Text.Substring(0, lbPayerName.Text.Length - 1), 76, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.Instance.CheckLinkBankNo(tbBankLinkNo, tbBankLinkNo.Text.Trim(), lbBankLinkNo.Text.Substring(0, lbBankLinkNo.Text.Length - 1), this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(tbOpenBank, tbOpenBank.Text.Trim(), lbOpenBank.Text.Substring(0, lbOpenBank.Text.Length - 1), 160, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            return rd.Result;
        }

        private void btnOpenBank_Click(object sender, EventArgs e)
        {
            wndOpenBankQuery frm = new wndOpenBankQuery();
            frm.IsOpenBank = !(m_AppType == AppliableFunctionType.TransferOverBankOut || m_AppType == AppliableFunctionType.TransferOverBankIn);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                tbOpenBank.Text = frm.QueryDialogResult.Name;
            }

            if (null != frm)
                frm.Close();
        }

        private void btnBankLinkNo_Click(object sender, EventArgs e)
        {

            wndLinkBankNo wnd = new wndLinkBankNo();
            if (wnd.ShowDialog() == DialogResult.OK)
                tbBankLinkNo.Text = wnd.BankInfo.LinkID;
            if (wnd != null)
                wnd.Close();
        }
    }
}
