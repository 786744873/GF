using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Entities;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class SpplyFinancingPayReceiptEditor : BaseUc
    {
        public SpplyFinancingPayReceiptEditor()
        {
            InitializeComponent();
            InitData();

            tbPayAmountForThisTime.LostFocus += new EventHandler(tbAmount_LostFocus);

            CommandCenter.Instance.OnSpplyFinancingPayOrReceiptEventHandler += new EventHandler<SpplyFinancingPayOrReceiptEventArgs>(CommandCenter_OnSpplyFinancingPayOrReceiptEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(SpplyFinancingPayReceiptEditor), this);
                InitData();
            }
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

        void CommandCenter_OnSpplyFinancingPayOrReceiptEventHandler(object sender, SpplyFinancingPayOrReceiptEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SpplyFinancingPayOrReceiptEventArgs>(CommandCenter_OnSpplyFinancingPayOrReceiptEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                    SetItem(e.SpplyFinancingPayOrReceipt);
                else if (e.Command == OperatorCommandType.Reset)
                    SetItem(null);
            }
        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBox).Text.Trim()))
            {
                (sender as TextBox).Text = DataConvertHelper.Instance.FormatCash((sender as TextBox).Text.Trim(), GetCashTypeIsJap());
            }
        }

        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        /// <summary>
        /// 所属功能模块
        /// ReceiptofDebtReceivableSeller,PaymentofDebtReceivablePurchaser
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser == value)
                {
                    m_AppType = value;
                }
            }
        }

        private SpplyFinancingPayOrReceipt m_payOrReceipt;
        /// <summary>
        /// 收付款信息
        /// </summary>
        public SpplyFinancingPayOrReceipt PayOrReceipt
        {
            get { return m_payOrReceipt; }
            protected set { m_payOrReceipt = value; }
        }

        public void GetItem()
        {
            m_payOrReceipt = new SpplyFinancingPayOrReceipt();
            m_payOrReceipt.BillSerialNo = tbBillSerialNo.Text.Trim();
            m_payOrReceipt.CustomerNo = tbCutomerNo.Text.Trim();
            m_payOrReceipt.CustomerName = tbCustomerName.Text.Trim();
            m_payOrReceipt.CashType = (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex];
            m_payOrReceipt.PayAmountForThisTime = tbPayAmountForThisTime.Text.Trim().Replace(",", "");
        }

        void SetItem(SpplyFinancingPayOrReceipt item)
        {
            if (null == item)
            {
                tbBillSerialNo.Text =
                tbCutomerNo.Text =
                tbCustomerName.Text =
                tbPayAmountForThisTime.Text = string.Empty;
                if (cmbCashType.Items.Count > 0) cmbCashType.SelectedIndex = 0;
                else cmbCashType.SelectedIndex = -1;
            }
            else
            {
                tbBillSerialNo.Text = item.BillSerialNo;
                tbCutomerNo.Text = item.CustomerNo;
                tbCustomerName.Text = item.CustomerName;
                tbPayAmountForThisTime.Text = item.PayAmountForThisTime.ToString();
                if (cmbCashType.Items.Count > 0) cmbCashType.SelectedIndex = (cmbCashType.Tag as List<CashType>).FindIndex(o => o == item.CashType);
                else cmbCashType.SelectedIndex = -1;
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData();
            if (!string.IsNullOrEmpty(tbBillSerialNo.Text))
            {
                rd = DataCheckCenter.Instance.CheckBillSerialNoSF(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), 20, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            rd = DataCheckCenter.Instance.CheckBankCustomerNo(tbCutomerNo, tbCutomerNo.Text.Trim(), lbCustomerNo.Text.Substring(0, lbCustomerNo.Text.Length - 1), 16, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckCustomerName(tbCustomerName, tbCustomerName.Text.Trim(), lbCustomerName.Text.Substring(0, lbCustomerName.Text.Length - 1), 80, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (string.IsNullOrEmpty(tbPayAmountForThisTime.Text))
            { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, lbPayAmountForThisTime.Text.Substring(0, lbPayAmountForThisTime.Text.Length - 1)), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            else
            {
                rd = DataCheckCenter.Instance.CheckCash(tbPayAmountForThisTime, tbPayAmountForThisTime.Text.Trim(), lbPayAmountForThisTime.Text.Substring(0, lbPayAmountForThisTime.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
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
    }
}
