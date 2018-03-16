using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class SpplyFinancingApplyEditor : BaseUc
    {
        public SpplyFinancingApplyEditor()
        {
            InitializeComponent();

            dtpOrderDate.MinDate = dtpDeliveryDate.MinDate = DateTime.Today;
            InitData();

            dtpOrderDate.MinDate =
            dtpDeliveryDate.MinDate = DateTime.Today;

            tbOrderAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            tbApplyAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            tbInterestFloatingPercent.LostFocus += new EventHandler(tbInterestFloatingPercent_LostFocus);
            cmbInterestFloatType.SelectedIndexChanged += new EventHandler(cmbInterestFloatType_SelectedIndexChanged);
            cmbSettlementType.SelectedIndexChanged += new EventHandler(cmbSettlementType_SelectedIndexChanged);

            CommandCenter.Instance.OnSpplyFinancingApplyEventHandler += new EventHandler<SpplyFinancingApplyEventArgs>(CommandCenter_OnSpplyFinancingApplyEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void cmbSettlementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSettlementType.SelectedIndex < 0)
            {
                lblTaxBillNo.Visible = lblGoodNo.Visible = false;
                return;
            }
            try
            {
                SettlementType st = (cmbSettlementType.Tag as List<SettlementType>)[cmbSettlementType.SelectedIndex];
                lblTaxBillNo.Visible = lblGoodNo.Visible = st == SettlementType.PayAfter;
            }
            catch { }
        }

        void cmbInterestFloatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInterestFloatType.SelectedIndex < 0) return;
            InterestFloatType ift = (cmbInterestFloatType.Tag as List<InterestFloatType>)[cmbInterestFloatType.SelectedIndex];
            if (ift == InterestFloatType.No)
                tbInterestFloatingPercent.Text = "0";
            tbInterestFloatingPercent.ReadOnly = ift == InterestFloatType.No;
        }

        void tbInterestFloatingPercent_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbInterestFloatingPercent.Text.Trim()))
                tbInterestFloatingPercent.Text = DataConvertHelper.Instance.FormatPayMoneyPercent(tbInterestFloatingPercent.Text.Trim(), false);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(SpplyFinancingApplyEditor), this);
                InitData();
            }
        }

        private void InitData()
        {
            cmbSettlementType.Items.Clear();
            foreach (var item in PrequisiteDataProvideNode.InitialProvide.SettlementTypeList)
            {
                if (item == SettlementType.Empty) continue;
                string value = EnumNameHelper<SettlementType>.GetEnumDescription(item);
                cmbSettlementType.Items.Add(value);
            }
            cmbSettlementType.Tag = PrequisiteDataProvideNode.InitialProvide.SettlementTypeList.FindAll(o => o != SettlementType.Empty);
            if (cmbSettlementType.Items.Count > 0) cmbSettlementType.SelectedIndex = 0;

            cmbInterestFloatType.Items.Clear();
            foreach (var item in PrequisiteDataProvideNode.InitialProvide.InterestFloatTypeList)
            {
                if (item == InterestFloatType.Empty) continue;
                string value = EnumNameHelper<InterestFloatType>.GetEnumDescription(item);
                cmbInterestFloatType.Items.Add(value);
            }
            cmbInterestFloatType.Tag = PrequisiteDataProvideNode.InitialProvide.InterestFloatTypeList.FindAll(o => o != InterestFloatType.Empty);

            cmbContractOrOrderCashType.Items.Clear();
            cmbContractOrOrderCashType.Items.Add(EnumNameHelper<CashType>.GetEnumDescription(CashType.CNY));
            cmbContractOrOrderCashType.SelectedIndex = 0;
        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBox).Text.Trim()))
            {
                (sender as TextBox).Text = DataConvertHelper.Instance.FormatCash((sender as TextBox).Text.Trim(), GetCashTypeIsJap());
            }
        }

        void CommandCenter_OnSpplyFinancingApplyEventHandler(object sender, SpplyFinancingApplyEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SpplyFinancingApplyEventArgs>(CommandCenter_OnSpplyFinancingApplyEventHandler), sender, e); }
            else
            {
                if (AppliableFunctionType.ApplyofFranchiserFinancing != e.OwnerType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View) SetItem(e.SpplyFinancingApply);
                else if (e.Command == OperatorCommandType.Reset)
                    SetItem(null);
            }
        }

        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        /// <summary>
        /// 所属功能模块
        /// ApplyofFranchiserFinancing
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.ApplyofFranchiserFinancing == value)
                    m_AppType = value;
            }
        }

        private SpplyFinancingApply m_Apply;
        /// <summary>
        /// 申请信息
        /// </summary>
        public SpplyFinancingApply Apply
        {
            get { return m_Apply; }
            protected set { m_Apply = value; }
        }

        public void GetItem()
        {
            m_Apply = new SpplyFinancingApply();
            m_Apply.ContractOrOrderNo = tbContractOrOrderNo.Text.Trim();
            m_Apply.OrderDate = dtpOrderDate.Value.ToShortDateString();
            m_Apply.ContractOrOrderCashType = CashType.CNY;
            m_Apply.ContractOrOrderAmount = tbOrderAmount.Text.Trim().Replace(",", "");
            m_Apply.DeliveryDate = dtpDeliveryDate.Value.ToShortDateString();
            m_Apply.SettlementType = (cmbSettlementType.Tag as List<SettlementType>)[cmbSettlementType.SelectedIndex];
            m_Apply.TaxInvoiceNo = tbTaxInvoiceNo.Text.Trim();
            m_Apply.ReceiptNo = tbReceiptNo.Text.Trim();
            m_Apply.RiskTakingLetterNo = tbRiskTakingLetterNo.Text.Trim();
            m_Apply.GoodsDesc = tbGoodsDesc.Text.Trim();
            m_Apply.ApplyAmount = tbApplyAmount.Text.Trim().Replace(",", "");
            m_Apply.ApplyDays = int.Parse(tbApplyDays.Text.Trim());
            m_Apply.AgreementNo = tbAgrementNo.Text.Trim();
            if (cmbInterestFloatType.SelectedIndex >= 0)
                m_Apply.InterestFloatType = (cmbInterestFloatType.Tag as List<InterestFloatType>)[cmbInterestFloatType.SelectedIndex];
            else m_Apply.InterestFloatType = InterestFloatType.Empty;
            m_Apply.InterestFloatingPercent = tbInterestFloatingPercent.Text.Trim();
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData();
            rd = DataCheckCenter.Instance.CheckContractOrOrderNo(tbContractOrOrderNo, tbContractOrOrderNo.Text.Trim(), lbContractOrOrderNo.Text.Substring(0, lbContractOrOrderNo.Text.Length - 1), 70, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckCash(tbOrderAmount, tbOrderAmount.Text.Trim(), lbOrderAmount.Text.Substring(0, lbOrderAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (cmbSettlementType.Items.Count > 0 && cmbSettlementType.SelectedIndex >= 0)
            {
                SettlementType st = (cmbSettlementType.Tag as List<SettlementType>)[cmbSettlementType.SelectedIndex];
                if (st == SettlementType.PayAfter)
                {
                    if (string.IsNullOrEmpty(tbTaxInvoiceNo.Text.Trim()))
                    { MessageBoxExHelper.Instance.Show(string.Format("{0}\r\n{1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, lbTaxInvoiceNo.Text.Substring(0, lbTaxInvoiceNo.Text.Length - 1)), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    if (string.IsNullOrEmpty(tbReceiptNo.Text.Trim()))
                    { MessageBoxExHelper.Instance.Show(string.Format("{0}\r\n{1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, lbReceiptNo.Text.Substring(0, lbReceiptNo.Text.Length - 1)), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                }
            }
            if (!string.IsNullOrEmpty(tbTaxInvoiceNo.Text))
            {
                rd = DataCheckCenter.Instance.CheckTaxBillSerialNo(tbTaxInvoiceNo, tbTaxInvoiceNo.Text.Trim(), lbTaxInvoiceNo.Text.Substring(0, lbTaxInvoiceNo.Text.Length - 1), 70, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (!string.IsNullOrEmpty(tbReceiptNo.Text))
            {
                rd = DataCheckCenter.Instance.CheckReceiptNo(tbReceiptNo, tbReceiptNo.Text.Trim(), lbReceiptNo.Text.Substring(0, lbReceiptNo.Text.Length - 1), 40, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            rd = DataCheckCenter.Instance.CheckRiskTakingLetterNo(tbRiskTakingLetterNo, tbRiskTakingLetterNo.Text.Trim(), lbRiskTakingLetterNo.Text.Substring(0, lbRiskTakingLetterNo.Text.Length - 1), 70, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (!string.IsNullOrEmpty(tbGoodsDesc.Text))
            {
                rd = DataCheckCenter.Instance.CheckGoodsDesc(tbGoodsDesc, tbGoodsDesc.Text.Trim(), lbGoodsDesc.Text.Substring(0, lbGoodsDesc.Text.Length - 1), 600, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            rd = DataCheckCenter.Instance.CheckCash(tbApplyAmount, tbApplyAmount.Text.Trim(), lbApplyAmount.Text.Substring(0, lbApplyAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckApplyDays(tbApplyDays, tbApplyDays.Text.Trim(), lbApplyDays.Text.Substring(0, lbApplyAmount.Text.Length - 1), 4, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (!string.IsNullOrEmpty(tbAgrementNo.Text))
            {
                rd = DataCheckCenter.Instance.CheckAgrementNo(tbAgrementNo, tbAgrementNo.Text.Trim(), lbAgrementNo.Text.Substring(0, lbAgrementNo.Text.Length - 1), 70, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            //if (!string.IsNullOrEmpty(tbInterestFloatingPercent.Text.Trim()))
            if (cmbInterestFloatType.SelectedIndex < 0)
            {
                MessageBoxExHelper.Instance.Show(string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.DesignMain_Please_Selection, lbInterestFloatType.Text.Substring(0, lbInterestFloatType.Text.Length - 1)), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbInterestFloatType.SelectedIndex >= 0)
            {
                if ((cmbInterestFloatType.Tag as List<InterestFloatType>)[cmbInterestFloatType.SelectedIndex] == InterestFloatType.No && tbInterestFloatingPercent.Text == "0") return true;
                rd = DataCheckCenter.Instance.CheckInterestFloatingPercent(tbInterestFloatingPercent, tbInterestFloatingPercent.Text.Trim(), lbInterestFloatingPercent.Text.Substring(0, lbInterestFloatingPercent.Text.Length - 1), 12, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            return rd.Result;
        }

        private bool GetCashTypeIsJap()
        {
            bool flag = false;
            if (cmbContractOrOrderCashType.SelectedIndex >= 0)
            {
                if (cmbContractOrOrderCashType.Tag != null)
                {
                    flag = (cmbContractOrOrderCashType.Tag as List<CashType>)[cmbContractOrOrderCashType.SelectedIndex] == CashType.JPY;
                }
            }
            return flag;
        }

        void SetItem(SpplyFinancingApply item)
        {
            if (null == item)
            {
                tbContractOrOrderNo.Text =
                tbOrderAmount.Text =
                tbTaxInvoiceNo.Text =
                tbReceiptNo.Text =
                tbRiskTakingLetterNo.Text =
                tbGoodsDesc.Text =
                tbApplyAmount.Text =
                tbApplyDays.Text =
                tbAgrementNo.Text =
                tbInterestFloatingPercent.Text =
                cmbContractOrOrderCashType.Text =
                cmbSettlementType.Text =
                cmbInterestFloatType.Text = string.Empty;
                if (cmbContractOrOrderCashType.Items.Count > 0) cmbContractOrOrderCashType.SelectedIndex = 0;
                if (cmbSettlementType.Items.Count > 0) cmbSettlementType.SelectedIndex = 0;
                if (cmbInterestFloatType.Items.Count > 0) cmbInterestFloatType.SelectedIndex = -1;
                dtpOrderDate.MinDate = DateTime.Today;
                dtpOrderDate.Value = dtpOrderDate.MinDate;
                dtpDeliveryDate.Value = dtpDeliveryDate.MinDate;
            }
            else
            {
                tbContractOrOrderNo.Text = item.ContractOrOrderNo;
                try { dtpOrderDate.Value = DateTime.Parse(item.OrderDate); }
                catch { dtpOrderDate.Value = dtpOrderDate.MinDate; }
                cmbContractOrOrderCashType.SelectedIndex = 0;//(cmbContractOrOrderCashType.Tag as List<CashType>).FindIndex(o => o == item.ContractOrOrderCashType);
                tbOrderAmount.Text = item.ContractOrOrderAmount.ToString();
                try { dtpDeliveryDate.Value = DateTime.Parse(item.DeliveryDate); }
                catch { dtpDeliveryDate.Value = dtpDeliveryDate.MinDate; }
                cmbSettlementType.SelectedIndex = (cmbSettlementType.Tag as List<SettlementType>).FindIndex(o => o == item.SettlementType);
                tbTaxInvoiceNo.Text = item.TaxInvoiceNo;
                tbReceiptNo.Text = item.ReceiptNo;
                tbRiskTakingLetterNo.Text = item.RiskTakingLetterNo;
                tbGoodsDesc.Text = item.GoodsDesc;
                tbApplyAmount.Text = item.ApplyAmount.ToString();
                tbApplyDays.Text = item.ApplyDays.ToString();
                tbAgrementNo.Text = item.AgreementNo;
                cmbInterestFloatType.SelectedIndex = (cmbInterestFloatType.Tag as List<InterestFloatType>).FindIndex(o => o == item.InterestFloatType);
                tbInterestFloatingPercent.Text = item.InterestFloatingPercent;
            }
        }
    }
}
