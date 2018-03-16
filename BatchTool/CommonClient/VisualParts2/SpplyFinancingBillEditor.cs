using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CommonClient.ConvertHelper;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.Utilities;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class SpplyFinancingBillEditor : BaseUc
    {
        public SpplyFinancingBillEditor()
        {
            InitializeComponent();

            InitData();

            dtpBillDate.MinDate =
            dtpStartDate.MinDate =
            dtpEndDate.MinDate = DateTime.Today;
            dtpBillDate.ValueChanged += new EventHandler(dtpBillDate_ValueChanged);
            dtpStartDate.ValueChanged += new EventHandler(dtpStartDate_ValueChanged);
            tbAmount.LostFocus += new EventHandler(tbAmount_LostFocus);

            CommandCenter.OnSpplyFinancingBillEventHandler += new EventHandler<SpplyFinancingBillEventArgs>(CommandCenter_OnSpplyFinancingBillEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        private void InitData()
        {
            cmbCashType.Items.Clear();
            List<CashType> list = new List<CashType> { CashType.CNY, CashType.GBP, CashType.HKD, CashType.USD, CashType.CHF, CashType.SGD, CashType.SEK, CashType.DKK, CashType.NOK, CashType.JPY, CashType.CAD, CashType.AUD, CashType.EUR, CashType.MOP, CashType.PHP, CashType.THB, CashType.NZD, CashType.RUB, CashType.KZT };
            foreach (var item in list)
            {
                string value = EnumNameHelper<CashType>.GetEnumDescription(item);
                cmbCashType.Items.Add(value);
            }
            cmbCashType.Tag = list;
            cmbCashType.SelectedIndex = 0;
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(SpplyFinancingBillEditor), this);
                Init();
                InitData();
            }
        }

        void CommandCenter_OnSpplyFinancingBillEventHandler(object sender, SpplyFinancingBillEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SpplyFinancingBillEventArgs>(CommandCenter_OnSpplyFinancingBillEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View) SetItem(e.SpplyFinancingBill);
                else if (e.Command == OperatorCommandType.Reset)
                    SetItem(null);
            }
        }

        void dtpBillDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Value.Date < dtpBillDate.Value.Date)
                dtpStartDate.Value = dtpBillDate.Value;
            dtpStartDate.MinDate = dtpBillDate.Value;
        }

        void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
                dtpEndDate.Value = dtpStartDate.Value;
            dtpEndDate.MinDate = dtpStartDate.Value;
        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbAmount.Text))
            {
                ResultData rd = new ResultData { Result = true };
                rd = DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, false, this.errorProvider1);
                if (!rd.Result) return;
                tbAmount.Text = DataConvertHelper.FormatCash(tbAmount.Text.Trim(), GetCashTypeIsJap());
            }
        }

        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        /// <summary>
        /// 所属功能模块
        /// BillofDebtReceivablePurchaser-，BillofDebtReceivableSeller-
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.BillofDebtReceivablePurchaser == value || AppliableFunctionType.BillofDebtReceivableSeller == value)
                {
                    m_AppType = value;
                    Init();
                }
            }
        }

        private SpplyFinancingBill m_bill;
        /// <summary>
        /// 订单信息
        /// </summary>
        public SpplyFinancingBill Bill
        {
            get { return m_bill; }
            protected set { m_bill = value; }
        }

        private void Init()
        {
            if (m_AppType == AppliableFunctionType.BillofDebtReceivablePurchaser)
            {
                lbCustomerName.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.SpplyFinancingBill_CustomerName_Seller, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                lbCustomerNo.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.SpplyFinancingBill_CustomerNo_Seller, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
            }
            else if (m_AppType == AppliableFunctionType.BillofDebtReceivableSeller)
            {
                lbCustomerName.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.SpplyFinancingBill_CustomerName_Purchase, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                lbCustomerNo.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.SpplyFinancingBill_CustomerNo_Purchase, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
            }
            SetRegex();
        }
        private void SetRegex()
        {
            tbBillSerialNo.DvRegCode = "reg720";
            tbBillSerialNo.DvMinLength = 0;
            tbBillSerialNo.DvMaxLength = 20;
            tbBillSerialNo.DvRequired = true;
            tbContractNo.DvRegCode = "reg641";
            tbContractNo.DvMinLength = 0;
            tbContractNo.DvMaxLength = 40;
            tbContractNo.DvRequired = false;
            tbCustomerNo.DvRegCode = "reg697";
            tbCustomerNo.DvMinLength = 1;
            tbCustomerNo.DvMaxLength = 16;
            tbCustomerNo.DvRequired = true;
            tbCustomerName.DvRegCode = "reg721";
            tbCustomerName.DvMinLength = 1;
            tbCustomerName.DvMaxLength = 80;
            tbCustomerName.DvRequired = true;
            //金额校验
            //tbAmount.DvRegCode = "reg43";
            //tbAmount.DvMinLength = 1;
            //tbAmount.DvMaxLength = 15;
            //rd = DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
            //if (!rd.Result) return rd.Result;


        }
        public void GetItem()
        {
            m_bill = new SpplyFinancingBill();
            m_bill.Amount = tbAmount.Text.Trim();
            m_bill.BillSerialNo = tbBillSerialNo.Text.Trim();
            m_bill.ContractNo = tbContractNo.Text.Trim();
            m_bill.CustomerName = tbCustomerName.Text.Trim();
            m_bill.CustomerNo = tbCustomerNo.Text.Trim();
            m_bill.CashType = (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex];
            m_bill.BillDate = dtpBillDate.Value.ToString("yyyy/MM/dd");
            m_bill.StartDate = dtpStartDate.Value.ToString("yyyy/MM/dd");
            m_bill.EndDate = dtpEndDate.Value.ToString("yyyy/MM/dd");
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //if (!string.IsNullOrEmpty(tbBillSerialNo.Text))
            //{
            //    rd = DataCheckCenter.CheckBillSerialNoSF(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), 20, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (!string.IsNullOrEmpty(tbContractNo.Text))
            //{
            //    rd = DataCheckCenter.CheckContractNoEx(tbContractNo, tbContractNo.Text.Trim(), lbContractNo.Text.Substring(0, lbContractNo.Text.Length - 1), 40, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //rd = DataCheckCenter.CheckBankCustomerNo(tbCustomerNo, tbCustomerNo.Text.Trim(), lbCustomerNo.Text.Substring(0, lbCustomerNo.Text.Length - 1), 16, this.errorProvider1);//允许输入字母
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckCustomerName(tbCustomerName, tbCustomerName.Text.Trim(), lbCustomerName.Text.Substring(0, lbCustomerName.Text.Length - 1), 80, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //if (cmbCashType.SelectedIndex < 0)
            //{ MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.SpplyFinancingBill_CashType), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrEmpty(tbAmount.Text))
            { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.SpplyFinancingBill_Amount), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); rd.Result = false; }
            else
            {
                rd.Result = rd.Result && DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1).Result;
                //if (!rd.Result) return rd.Result;
            }
            return rd.Result;
        }

        private bool GetCashTypeIsJap()
        {
            bool flag = false;
            if (this.cmbCashType.SelectedIndex >= 0)
            {
                if (cmbCashType.Tag != null)
                {
                    flag = (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex] == CashType.JPY;
                }
            }
            return flag;
        }

        private void SetItem(SpplyFinancingBill item)
        {
            if (null == item)
            {
                tbBillSerialNo.Text =
                tbContractNo.Text =
                tbCustomerName.Text =
                tbCustomerNo.Text =
                tbAmount.Text =
                cmbCashType.Text = string.Empty;
                cmbCashType.SelectedIndex = 0;
                dtpBillDate.Value = dtpBillDate.MinDate;
                dtpStartDate.Value = dtpStartDate.MinDate;
                dtpEndDate.Value = dtpEndDate.MinDate;
            }
            else
            {
                tbBillSerialNo.Text = item.BillSerialNo;
                tbContractNo.Text = item.ContractNo;
                tbCustomerName.Text = item.CustomerName;
                tbCustomerNo.Text = item.CustomerNo;
                tbAmount.Text = item.Amount.ToString();
                cmbCashType.SelectedIndex = (cmbCashType.Tag as List<CashType>).FindIndex(o => o == item.CashType);
                if (cmbCashType.SelectedIndex < 0) cmbCashType.SelectedIndex = 0;
                try { dtpBillDate.Value = DateTime.Parse(item.BillDate); }
                catch { }
                try { dtpStartDate.Value = DateTime.Parse(item.StartDate); }
                catch { }
                try { dtpEndDate.Value = DateTime.Parse(item.EndDate); }
                catch { }
            }
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDesc.Text = DataConvertHelper.ConvertA2CN(tbAmount.Text.Trim(), 15, this.cmbCashType.SelectedIndex == -1 ? CashType.CNY : (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex]);
        }
    }
}
