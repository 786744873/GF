using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.Utilities;
using CommonClient.ConvertHelper;
using CommonClient.SysCoach;
using CommonClient.Entities;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class SpplyFinancingPayReceiptEditor : BaseUc
    {
        public SpplyFinancingPayReceiptEditor()
        {
            InitializeComponent();
            InitData();

            tbPayAmountForThisTime.LostFocus += new EventHandler(tbAmount_LostFocus);

            CommandCenter.OnSpplyFinancingPayOrReceiptEventHandler += new EventHandler<SpplyFinancingPayOrReceiptEventArgs>(CommandCenter_OnSpplyFinancingPayOrReceiptEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            SetRegex();
        }
        private void SetRegex()
        {
            tbBillSerialNo.DvRegCode = "reg720";
            tbBillSerialNo.DvMinLength = 0;
            tbBillSerialNo.DvMaxLength = 20;
            tbBillSerialNo.DvRequired = false;
            tbCutomerNo.DvRegCode = "reg697";
            tbCutomerNo.DvMinLength = 1;
            tbCutomerNo.DvMaxLength = 16;
            tbCutomerNo.DvRequired = true;
            tbCustomerName.DvRegCode = "reg721";
            tbCustomerName.DvMinLength = 1;
            tbCustomerName.DvMaxLength = 80;
            tbCustomerName.DvRequired = true;
            //金额校验
            //tbPayAmountForThisTime.DvRegCode = "reg43";
            //tbPayAmountForThisTime.DvMinLength = 1;
            //tbPayAmountForThisTime.DvMaxLength = 15;
            //rd = DataCheckCenter.CheckCash(tbPayAmountForThisTime, tbPayAmountForThisTime.Text.Trim(), lbPayAmountForThisTime.Text.Substring(0, lbPayAmountForThisTime.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
            //if (!rd.Result) return rd.Result;


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
                ResultData rd = new ResultData { Result = true };
                rd = DataCheckCenter.CheckCash(tbPayAmountForThisTime, tbPayAmountForThisTime.Text.Trim(), lbPayAmountForThisTime.Text.Substring(0, lbPayAmountForThisTime.Text.Length - 1), 15, false, this.errorProvider1);
                if (!rd.Result) return;
                (sender as TextBox).Text = DataConvertHelper.FormatCash((sender as TextBox).Text.Trim(), GetCashTypeIsJap());
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
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //if (!string.IsNullOrEmpty(tbBillSerialNo.Text))
            //{
            //    rd = DataCheckCenter.CheckBillSerialNoSF(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), 20, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //rd = DataCheckCenter.CheckBankCustomerNo(tbCutomerNo, tbCutomerNo.Text.Trim(), lbCustomerNo.Text.Substring(0, lbCustomerNo.Text.Length - 1), 16, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckCustomerName(tbCustomerName, tbCustomerName.Text.Trim(), lbCustomerName.Text.Substring(0, lbCustomerName.Text.Length - 1), 80, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            if (string.IsNullOrEmpty(tbPayAmountForThisTime.Text))
            { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, lbPayAmountForThisTime.Text.Substring(0, lbPayAmountForThisTime.Text.Length - 1)), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); rd.Result = false; }
            else
            {
                rd.Result = rd.Result && DataCheckCenter.CheckCash(tbPayAmountForThisTime, tbPayAmountForThisTime.Text.Trim(), lbPayAmountForThisTime.Text.Substring(0, lbPayAmountForThisTime.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1).Result;
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

        private void tbPayAmountForThisTime_TextChanged(object sender, EventArgs e)
        {
            lbAmountDesc.Text = DataConvertHelper.ConvertA2CN(tbPayAmountForThisTime.Text.Trim(), 15, cmbCashType.SelectedIndex == -1 ? CashType.CNY : (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex]);
        }
    }
}
