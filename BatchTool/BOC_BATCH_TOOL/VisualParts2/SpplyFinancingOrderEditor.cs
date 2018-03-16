using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class SpplyFinancingOrderEditor : BaseUc
    {
        public SpplyFinancingOrderEditor()
        {
            InitializeComponent();

            InitData();

            dtpPayDate.MinDate = dtpPayDatePurchase.MinDate = DateTime.Today;
            dtpPayDate.Value = dtpPayDatePurchase.Value = DateTime.Today;
            tbAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            CommandCenter.Instance.OnSpplyFinancingOrderEventHandler += new EventHandler<SpplyFinancingOrderEventArgs>(CommandCenter_OnSpplyFinancingOrderEventHandler);
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
                base.ApplyResource(typeof(SpplyFinancingOrderEditor), this);
                InitData();
            }
        }

        void CommandCenter_OnSpplyFinancingOrderEventHandler(object sender, SpplyFinancingOrderEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SpplyFinancingOrderEventArgs>(CommandCenter_OnSpplyFinancingOrderEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                    SetItem(e.SpplyFinancingOrder);
                else if (e.Command == OperatorCommandType.Reset)
                    SetItem(null);
            }
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
        /// PurchaserOrder-，SellerOrder-
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.PurchaserOrder == value || AppliableFunctionType.SellerOrder == value)
                {
                    m_AppType = value;
                    Init();
                }
            }
        }

        private SpplyFinancingOrder m_order;
        /// <summary>
        /// 订单信息
        /// </summary>
        public SpplyFinancingOrder Order
        {
            get { return m_order; }
            protected set { m_order = value; }
        }

        void Init()
        {
            pPurchase.Visible = m_AppType == AppliableFunctionType.PurchaserOrder;
            pSeller.Visible = m_AppType == AppliableFunctionType.SellerOrder;
        }

        public void GetItem()
        {
            m_order = new SpplyFinancingOrder();
            m_order.OrderNo = tbOrderNo.Text.Trim();
            m_order.CashType = (cmbCashType.Tag as List<CashType>)[cmbCashType.SelectedIndex];
            m_order.Amount = tbAmount.Text.Trim().Replace(",", "");
            if (m_AppType == AppliableFunctionType.PurchaserOrder)
            {
                m_order.ERPCode = tbERPCode.Text.Trim();
                m_order.CustomerApplyNo = tbCustomerApplyNo.Text.Trim();
                m_order.PayDate = dtpPayDate.Value.ToString("yyyy/MM/dd");
            }
            else if (m_AppType == AppliableFunctionType.SellerOrder)
            {
                m_order.CustomerName = tbCustomerName.Text.Trim();
                m_order.PayDate = dtpPayDatePurchase.Value.ToString("yyyy/MM/dd");
            }
        }

        void SetItem(SpplyFinancingOrder item)
        {
            if (null == item)
            {
                tbOrderNo.Text =
                tbAmount.Text =
                tbERPCode.Text =
                tbCustomerApplyNo.Text =
                tbCustomerName.Text = string.Empty;
                dtpPayDate.Value =
                dtpPayDatePurchase.Value = DateTime.Today;
            }
            else
            {
                tbOrderNo.Text = item.OrderNo;
                cmbCashType.SelectedIndex = (cmbCashType.Tag as List<CashType>).FindIndex(o => o == item.CashType);
                tbAmount.Text = item.Amount.ToString();
                if (m_AppType == AppliableFunctionType.PurchaserOrder)
                {
                    tbERPCode.Text = item.ERPCode;
                    tbCustomerApplyNo.Text = item.CustomerApplyNo;
                    try { dtpPayDate.Value = DateTime.Parse(item.PayDate); }
                    catch { dtpPayDate.Value = DateTime.Today; }
                }
                else if (m_AppType == AppliableFunctionType.SellerOrder)
                {
                    tbCustomerName.Text = item.CustomerName;
                    try { dtpPayDatePurchase.Value = DateTime.Parse(item.PayDate); }
                    catch { dtpPayDatePurchase.Value = DateTime.Today; }
                }
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData();
            rd = DataCheckCenter.Instance.CheckOrderNo(tbOrderNo, tbOrderNo.Text.Trim(), lbOrderNo.Text.Substring(0, lbOrderNo.Text.Length - 1), 70, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (cmbCashType.SelectedIndex < 0)
            { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_Amount), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            rd = DataCheckCenter.Instance.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (m_AppType == AppliableFunctionType.PurchaserOrder)
            {
                if (string.IsNullOrEmpty(tbERPCode.Text) && string.IsNullOrEmpty(tbCustomerApplyNo.Text))
                {
                    MessageBoxExHelper.Instance.Show(string.Format("{0} {1} {2} {3}", new string[]{
                                                                        MultiLanguageConvertHelper.Instance.Information_Please_Input,
                                                                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerNo_Seller,
                                                                        MultiLanguageConvertHelper.Instance.Information_Or,
                                                                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_ERPCode_Seller}),
                                                     CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (!string.IsNullOrEmpty(tbERPCode.Text))
                {
                    rd = DataCheckCenter.Instance.CheckERPCode(tbERPCode, tbERPCode.Text.Trim(), lbERPCode.Text.Substring(0, lbERPCode.Text.Length - 1), 40, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                if (!string.IsNullOrEmpty(tbCustomerApplyNo.Text))
                {
                    rd = DataCheckCenter.Instance.CheckBankCustomerNo(tbCustomerApplyNo, tbCustomerApplyNo.Text.Trim(), lbCustomerApplyNo.Text.Substring(0, lbCustomerApplyNo.Text.Length - 1), 40, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }
            else if (m_AppType == AppliableFunctionType.SellerOrder)
            {
                rd = DataCheckCenter.Instance.CheckCustomerNamePurchase(tbCustomerName, tbCustomerName.Text.Trim(), lbCustomerName.Text.Substring(0, lbCustomerName.Text.Length - 1), 80, this.errorProvider1);
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
