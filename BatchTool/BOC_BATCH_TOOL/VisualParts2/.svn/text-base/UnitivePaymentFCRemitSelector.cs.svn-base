using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class UnitivePaymentFCRemitSelector : BaseUc
    {
        public UnitivePaymentFCRemitSelector()
        {
            InitializeComponent();
            dtpRemitDate.MaxDate = DateTime.Today.AddMonths(1);
            dtpRemitDate.MinDate = DateTime.Today;
            tbRemitAmount.LostFocus += new EventHandler(tbRemitAmount_LostFocus);
            CommandCenter.Instance.OnOverCountryPayeeAccountTypeEventHandler += new EventHandler<OverCountryPayeeAccountTypeEventArgs>(CommandCenter_OnOverCountryPayeeAccountTypeEventHandler);
            CommandCenter.Instance.OnUnitivePaymentFCEventHandler += new EventHandler<UnitivePaymentFCEventArgs>(CommandCenter_OnUnitivePaymentFCEventHandler);
            CommandCenter.Instance.OnBankTypeChangedEventHandler += new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler);
            CommandCenter.Instance.OnCashTypeChangedEventHandler += new EventHandler<CashTypeChangedEventArgs>(CommandCenter_OnCashTypeChangedEventHandler);
        }

        void tbRemitAmount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbRemitAmount.Text.Trim()))
            {
                tbRemitAmount.Text = DataConvertHelper.Instance.FormatCash(tbRemitAmount.Text.Trim(), m_cashType == CashType.JPY);
            }
        }

        void CommandCenter_OnCashTypeChangedEventHandler(object sender, CashTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<CashTypeChangedEventArgs>(CommandCenter_OnCashTypeChangedEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.UnitivePaymentFC) return;
                m_cashType = e.CashType;
            }
        }

        void CommandCenter_OnBankTypeChangedEventHandler(object sender, BankTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.UnitivePaymentFC) return;
                if (e.Command != OperatorCommandType.BankTypeChanged) return;
                panel1.Visible = e.BankType == AgentTransferBankType.Other;
            }
        }

        void CommandCenter_OnUnitivePaymentFCEventHandler(object sender, UnitivePaymentFCEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<UnitivePaymentFCEventArgs>(CommandCenter_OnUnitivePaymentFCEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != AppliableFunctionType.UnitivePaymentFC) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                    SetItem(e.UnitivePaymentFC);
                else if (e.Command == OperatorCommandType.Reset)
                    SetItem(null);
            }
        }

        void CommandCenter_OnOverCountryPayeeAccountTypeEventHandler(object sender, OverCountryPayeeAccountTypeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<OverCountryPayeeAccountTypeEventArgs>(CommandCenter_OnOverCountryPayeeAccountTypeEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.UnitivePaymentFC) return;
                if (e.Command != OperatorCommandType.PayeeAccountTypeCallBack) return;
                if (e.AccountType == OverCountryPayeeAccountType.ForeignAccount)
                    panel1.Visible = true;
            }
        }

        void Init()
        {
        }

        OverCountryPayeeAccountType m_AccountType = OverCountryPayeeAccountType.Empty;
        /// <summary>
        /// 收款人账号类型
        /// </summary>
        public OverCountryPayeeAccountType AccountType
        {
            get { return m_AccountType; }
            protected set { m_AccountType = value; }
        }

        UnitivePaymentForeignMoney m_unitivePFC;
        /// <summary>
        /// 付款人信息
        /// </summary>
        public UnitivePaymentForeignMoney CurrentUnitivePFC
        {
            get { return m_unitivePFC; }
            set { m_unitivePFC = value; }
        }

        CashType m_cashType = CashType.Empty;

        public void GetItem()
        {
            m_unitivePFC = new UnitivePaymentForeignMoney();
            DateTime dt = dtpRemitDate.Value;
            m_unitivePFC.OrderPayDate = dt.Year.ToString() + "/" + dt.Month.ToString().PadLeft(2, '0') + "/" + dt.Day.ToString().PadLeft(2, '0');
            m_unitivePFC.Amount = tbRemitAmount.Text.Trim();
            m_unitivePFC.CustomerBusinissNo = tbCustomerRef.Text.Trim();
            if (panel1.Visible)
            {
                m_unitivePFC.OrgCode = string.Format("{0}-{1}", tbOrgPre.Text.Trim(), tbOrgEnd.Text.Trim());
                m_unitivePFC.realPayAddress = tbRemittorAddress.Text.Trim();
                m_unitivePFC.SendPriority = rbNormal.Checked ? TransferChanelType.Normal : TransferChanelType.Express;
            }
        }

        void SetItem(UnitivePaymentForeignMoney item)
        {
            if (null == item)
            {
                dtpRemitDate.Value = DateTime.Today;
                tbRemitAmount.Text =
                tbOrgPre.Text =
                tbOrgEnd.Text =
                tbCustomerRef.Text =
                tbRemittorAddress.Text = string.Empty;
                rbNormal.Checked = true;
                rbExpress.Checked = !rbNormal.Checked;
            }
            else
            {
                try
                { dtpRemitDate.Value = DateTime.Parse(item.OrderPayDate); }
                catch { }
                tbRemitAmount.Text = item.Amount;
                tbCustomerRef.Text = item.CustomerBusinissNo;
                if (panel1.Visible)
                {
                    if (!string.IsNullOrEmpty(item.OrgCode))
                    {
                        string[] orgcode = item.OrgCode.Split('-');
                        tbOrgPre.Text = orgcode[0];
                        tbOrgEnd.Text = orgcode[1];
                    }
                    tbRemittorAddress.Text = item.realPayAddress;
                    rbNormal.Checked = item.SendPriority == TransferChanelType.Normal;
                    rbExpress.Checked = !rbNormal.Checked;
                }
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData();
            rd = DataCheckCenter.Instance.CheckCash(tbRemitAmount, tbRemitAmount.Text.Trim(), lbRemitAmount.Text.Substring(0, lbRemitAmount.Text.Length - 1), 15, m_cashType == CashType.JPY, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (!string.IsNullOrEmpty(tbCustomerRef.Text.Trim()))
            {
                rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(tbCustomerRef, tbCustomerRef.Text.Trim(), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (panel1.Visible)
            {
                rd = DataCheckCenter.Instance.CheckOrgCode(tbOrgEnd, string.Format("{0}-{1}", tbOrgPre.Text.Trim(), tbOrgEnd.Text.Trim()), lbOrgCode.Text.Substring(0, lbOrgCode.Text.Length - 1), this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (!string.IsNullOrEmpty(tbRemittorAddress.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.ChecktbRemittorAddress(tbRemittorAddress, tbRemittorAddress.Text.Trim(), this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }
            return rd.Result;
        }
    }
}
