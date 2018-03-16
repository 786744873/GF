using System;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class UnitivePaymentFCRemitSelector : BaseUc
    {
        public UnitivePaymentFCRemitSelector()
        {
            InitializeComponent();
            dtpRemitDate.MaxDate = DateTime.Today.AddMonths(1);
            dtpRemitDate.MinDate = DateTime.Today;
            tbRemitAmount.LostFocus += new EventHandler(tbRemitAmount_LostFocus);
            CommandCenter.OnOverCountryPayeeAccountTypeEventHandler += new EventHandler<OverCountryPayeeAccountTypeEventArgs>(CommandCenter_OnOverCountryPayeeAccountTypeEventHandler);
            CommandCenter.OnUnitivePaymentFCEventHandler += new EventHandler<UnitivePaymentFCEventArgs>(CommandCenter_OnUnitivePaymentFCEventHandler);
            CommandCenter.OnBankTypeChangedEventHandler += new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler);
            CommandCenter.OnCashTypeChangedEventHandler += new EventHandler<CashTypeChangedEventArgs>(CommandCenter_OnCashTypeChangedEventHandler);
            SetRegex();
        }
        private void SetRegex()
        {
            //金额校验
            //tbRemitAmount.DvRegCode = "reg43";
            //tbRemitAmount.DvMinLength = 1;
            //tbRemitAmount.DvMaxLength = 15;
            //rd = DataCheckCenter.Instance.CheckCash(tbRemitAmount, tbRemitAmount.Text.Trim(), lbRemitAmount.Text.Substring(0, lbRemitAmount.Text.Length - 1), 15, m_cashType == CashType.JPY, this.errorProvider1);
            //if (!rd.Result) return rd.Result;

            tbOrgPre.DvRegCode = "reg57";
            tbOrgPre.DvMinLength = 8;
            tbOrgPre.DvMaxLength = 8;
            tbOrgPre.DvRequired = false;
            tbOrgEnd.DvRegCode = "reg57";
            tbOrgEnd.DvMinLength = 1;
            tbOrgEnd.DvMaxLength = 1;
            tbOrgEnd.DvRequired = false;
            tbRemittorAddress.DvRegCode = "reg702";
            tbRemittorAddress.DvMinLength = 0;
            tbRemittorAddress.DvMaxLength = 280;
            tbRemittorAddress.DvRequired = false;
            tbNominalPayerAddress.DvRegCode = "reg702";
            tbNominalPayerAddress.DvMinLength = 0;
            tbNominalPayerAddress.DvMaxLength = 280;
            tbNominalPayerAddress.DvRequired = false;
            tbCustomerRef.DvRegCode = "reg8";
            tbCustomerRef.DvMinLength = 0;
            tbCustomerRef.DvMaxLength = 16;
            tbCustomerRef.DvRequired = false;
        }
        void tbRemitAmount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbRemitAmount.Text.Trim()))
            {
                ResultData rd = DataCheckCenter.CheckCash(tbRemitAmount, tbRemitAmount.Text.Trim(), lbRemitAmount.Text.Substring(0, lbRemitAmount.Text.Length - 1), 15, m_cashType == CashType.JPY, this.errorProvider1);
                if (rd.Result)
                    tbRemitAmount.Text = DataConvertHelper.FormatCash(tbRemitAmount.Text.Trim(), m_cashType == CashType.JPY);
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
                SetRegex();
                panel1.Visible = tbOrgPre.DvRequired = tbOrgEnd.DvRequired = e.BankType == AgentTransferBankType.Other;
                lbNominalPayerAddress.Visible = tbNominalPayerAddress.Visible = false;
                m_AccountType = e.BankType == AgentTransferBankType.Boc ? OverCountryPayeeAccountType.BocAccount : OverCountryPayeeAccountType.OtherAccount;
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
                panel1.Visible = tbOrgPre.DvRequired = tbOrgEnd.DvRequired =
                lbNominalPayerAddress.Visible = tbNominalPayerAddress.Visible = e.AccountType == OverCountryPayeeAccountType.ForeignAccount;
                m_AccountType = e.AccountType;
            }
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

        CashType m_cashType = CashType.GBP;

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
                if (AccountType == OverCountryPayeeAccountType.ForeignAccount) m_unitivePFC.NominalPayerAddress = tbNominalPayerAddress.Text.Trim();
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
                tbRemittorAddress.Text =
                tbNominalPayerAddress.Text = string.Empty;
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
                    tbNominalPayerAddress.Text = item.NominalPayerAddress;
                }
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            rd.Result = rd.Result && DataCheckCenter.CheckCash(tbRemitAmount, tbRemitAmount.Text.Trim(), lbRemitAmount.Text.Substring(0, lbRemitAmount.Text.Length - 1), 15, m_cashType == CashType.JPY, this.errorProvider1).Result;
            //if (!rd.Result) return rd.Result;
            //if (!string.IsNullOrEmpty(tbCustomerRef.Text.Trim()))
            //{
            //    rd = DataCheckCenter.CheckCustomerRefNoGJOrUPEx(tbCustomerRef, tbCustomerRef.Text.Trim(), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            if (panel1.Visible)
            {
                rd.Result = rd.Result && DataCheckCenter.CheckOrgCode(tbOrgEnd, string.Format("{0}-{1}", tbOrgPre.Text.Trim(), tbOrgEnd.Text.Trim()), lbOrgCode.Text.Substring(0, lbOrgCode.Text.Length - 1), this.errorProvider1).Result;
                //if (!rd.Result) return rd.Result;
                //    if (!string.IsNullOrEmpty(tbRemittorAddress.Text.Trim()))
                //    {
                //        rd = DataCheckCenter.ChecktbRemittorAddress(tbRemittorAddress, tbRemittorAddress.Text.Trim(), this.errorProvider1);
                //        if (!rd.Result) return rd.Result;
                //    }
            }

            return rd.Result;
        }

        private void tbRemitAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDesc.Text = DataConvertHelper.ConvertA2CN(tbRemitAmount.Text.Trim(), 15, m_cashType == CashType.Empty ? CashType.CNY : m_cashType);
        }
    }
}
