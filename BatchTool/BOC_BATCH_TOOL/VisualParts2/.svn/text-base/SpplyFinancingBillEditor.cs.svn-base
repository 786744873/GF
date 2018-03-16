using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.VisualParts
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

            CommandCenter.Instance.OnSpplyFinancingBillEventHandler += new EventHandler<SpplyFinancingBillEventArgs>(CommandCenter_OnSpplyFinancingBillEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
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
                tbAmount.Text = DataConvertHelper.Instance.FormatCash(tbAmount.Text.Trim(), GetCashTypeIsJap());
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
                lbCustomerName.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Seller, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
                lbCustomerNo.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Seller, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            }
            else if (m_AppType == AppliableFunctionType.BillofDebtReceivableSeller)
            {
                lbCustomerName.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Purchase, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
                lbCustomerNo.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Purchase, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            }
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
            ResultData rd = new ResultData();
            if (!string.IsNullOrEmpty(tbBillSerialNo.Text))
            {
                rd = DataCheckCenter.Instance.CheckBillSerialNoSF(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), 20, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (!string.IsNullOrEmpty(tbContractNo.Text))
            {
                rd = DataCheckCenter.Instance.CheckContractNoEx(tbContractNo, tbContractNo.Text.Trim(), lbContractNo.Text.Substring(0, lbContractNo.Text.Length - 1), 40, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            rd = DataCheckCenter.Instance.CheckBankCustomerNo(tbCustomerNo, tbCustomerNo.Text.Trim(), lbCustomerNo.Text.Substring(0, lbCustomerNo.Text.Length - 1), 16, this.errorProvider1);//允许输入字母
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckCustomerName(tbCustomerName, tbCustomerName.Text.Trim(), lbCustomerName.Text.Substring(0, lbCustomerName.Text.Length - 1), 80, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (cmbCashType.SelectedIndex < 0)
            { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CashType), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrEmpty(tbAmount.Text))
            { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.SpplyFinancingBill_Amount), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            else
            {
                rd = DataCheckCenter.Instance.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
                if (!rd.Result) return rd.Result;
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
    }
}
