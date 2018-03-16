using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class UnitivePaymentFCPayerSelector : BaseUc
    {
        public UnitivePaymentFCPayerSelector()
        {
            InitializeComponent();
            Init();

            cmbCashType.SelectedIndexChanged += new EventHandler(cmbCashType_SelectedIndexChanged);

            CommandCenter.Instance.OnUnitivePaymentFCEventHandler += new EventHandler<UnitivePaymentFCEventArgs>(CommandCenter_OnUnitivePaymentFCEventHandler);
            CommandCenter.Instance.OnOverCountryPayeeAccountTypeEventHandler += new EventHandler<OverCountryPayeeAccountTypeEventArgs>(CommandCenter_OnOverCountryPayeeAccountTypeEventHandler);
        }

        void cmbCashType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCashType.SelectedIndex < 0) return;
            CommandCenter.Instance.ResolveCashTypeChanged(OperatorCommandType.CardTypeChanged, (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex], AppliableFunctionType.UnitivePaymentFC, false);
        }

        void CommandCenter_OnOverCountryPayeeAccountTypeEventHandler(object sender, OverCountryPayeeAccountTypeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<OverCountryPayeeAccountTypeEventArgs>(CommandCenter_OnOverCountryPayeeAccountTypeEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.UnitivePaymentFC) return;
                if (e.Command != OperatorCommandType.PayeeAccountTypeCallBack) return;
                if (e.IsRollBack)
                {
                    m_isCallBack = true;
                    rbOut.Checked = e.AccountType == OverCountryPayeeAccountType.ForeignAccount;
                    rbIn.Checked = !rbOut.Checked;
                    m_isCallBack = false;
                }
                CommandCenter.Instance.ResolveOverCountryPayeeAccountTypeChanged(OperatorCommandType.PayeeAccountTypeChanged, e.AppType, e.AccountType, false);
            }
        }

        void CommandCenter_OnUnitivePaymentFCEventHandler(object sender, UnitivePaymentFCEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<UnitivePaymentFCEventArgs>(CommandCenter_OnUnitivePaymentFCEventHandler), sender, e); }
            else
            {
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                    SetItem(e.UnitivePaymentFC);
                else if (e.Command == OperatorCommandType.Reset)
                    SetItem(null);
            }
        }

        void Init()
        {
            List<CashType> list = new List<CashType>() { CashType.GBP, CashType.HKD, CashType.USD, CashType.CHF, CashType.SGD, CashType.SEK, CashType.JPY, CashType.CAD, CashType.AUD, CashType.EUR, CashType.MOP, CashType.PHP, CashType.THB, CashType.NZD, CashType.KRW };
            cmbCashType.Items.Clear();
            foreach (var item in list)
                cmbCashType.Items.Add(EnumNameHelper<CashType>.GetEnumDescription(item));
            cmbCashType.Tag = list;
            //if (cmbCashType.Items.Count > 0) cmbCashType.SelectedIndex = 0;
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

        bool m_isCallBack = false;

        public void GetItem()
        {
            m_unitivePFC = new UnitivePaymentForeignMoney();
            m_unitivePFC.PayerAccount = tbRealPayerAccount.Text.Trim();
            m_unitivePFC.PayerName = tbRealPayerName.Text.Trim();
            m_unitivePFC.NominalPayerAccount = tbNominalPayerAccount.Text.Trim();
            m_unitivePFC.NominalPayerName = tbNominalPayerName.Text.Trim();
            m_unitivePFC.CashType = cmbCashType.SelectedIndex == -1 ? CashType.Empty : (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex];
            m_unitivePFC.PayeeAccountType = rbOut.Checked ? OverCountryPayeeAccountType.ForeignAccount : OverCountryPayeeAccountType.Empty;
        }

        void SetItem(UnitivePaymentForeignMoney item)
        {
            if (null == item)
            {
                tbRealPayerName.Text =
                tbRealPayerAccount.Text =
                tbNominalPayerAccount.Text =
                tbNominalPayerName.Text = string.Empty;
                m_AccountType = OverCountryPayeeAccountType.Empty;
                cmbCashType.SelectedIndex = cmbCashType.Items.Count > 0 ? 0 : -1;
            }
            else
            {
                tbRealPayerName.Text = item.PayerName;
                tbRealPayerAccount.Text = item.PayerAccount;
                tbNominalPayerAccount.Text = item.NominalPayerAccount;
                tbNominalPayerName.Text = item.NominalPayerName;
                m_AccountType = item.PayeeAccountType;
                cmbCashType.SelectedIndex = (cmbCashType.Tag as List<CashType>).FindIndex(o => o == item.CashType);
                rbIn.Checked = item.PayeeAccountType != OverCountryPayeeAccountType.ForeignAccount;
                rbOut.Checked = !rbIn.Checked;
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData();
            rd = DataCheckCenter.Instance.CheckPayerAccountUP(tbRealPayerAccount, tbRealPayerAccount.Text.Trim(), lbRealPayerAccount.Text.Substring(0, lbRealPayerAccount.Text.Length - 1), 12, 18, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (rbOut.Checked)
            {
                if (!string.IsNullOrEmpty(tbRealPayerName.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(tbRealPayerName, tbRealPayerName.Text.Trim(), lbRealPayerName.Text.Substring(0, lbRealPayerName.Text.Length - 1), 140, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(tbNominalPayerAccount, tbNominalPayerAccount.Text.Trim(), LblNominalPayerAccount.Text.Substring(0, LblNominalPayerAccount.Text.Length - 1), 35, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(tbNominalPayerName, tbNominalPayerName.Text.Trim(), LblNominalPayerName.Text.Substring(0, LblNominalPayerName.Text.Length - 1), 140, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            else
            {
                if (!string.IsNullOrEmpty(tbRealPayerName.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(tbRealPayerName, tbRealPayerName.Text.Trim(), lbRealPayerName.Text.Substring(0, lbRealPayerName.Text.Length - 1), 200, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                rd = DataCheckCenter.Instance.CheckAccountUP(tbNominalPayerAccount, tbNominalPayerAccount.Text.Trim(), LblNominalPayerAccount.Text.Substring(0, LblNominalPayerAccount.Text.Length - 1), 35, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(tbNominalPayerName, tbNominalPayerName.Text.Trim(), LblNominalPayerName.Text.Substring(0, LblNominalPayerName.Text.Length - 1), 200, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (cmbCashType.SelectedIndex < 0)
            { this.errorProvider1.SetError(cmbCashType, string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.DesignMain_Please_Selection, lbCashType.Text.Substring(0, lbCashType.Text.Length - 1))); return false; }
            return rd.Result;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_isCallBack)
                CommandCenter.Instance.ResolveOverCountryPayeeAccountTypeChanged(OperatorCommandType.PayeeAccountTypeRequest, AppliableFunctionType.UnitivePaymentFC, rbOut.Checked ? OverCountryPayeeAccountType.ForeignAccount : OverCountryPayeeAccountType.BocAccount | OverCountryPayeeAccountType.OtherAccount, false);
        }
    }
}
