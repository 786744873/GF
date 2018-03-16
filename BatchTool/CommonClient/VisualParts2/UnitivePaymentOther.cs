using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient.Utilities;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class UnitivePaymentOther : BaseUc
    {
        public UnitivePaymentOther()
        {
            InitializeComponent();

            Init();

            dtpPayDate.MinDate = DateTime.Today;
            dtpPayDate.MaxDate = DateTime.Today.AddMonths(1);

            if (cmbTime.Items.Count > 0)
                cmbTime.SelectedIndex = 0;

            tbAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            cmbPaymentType.SelectedIndexChanged += new EventHandler(cmbPaymentType_SelectedIndexChanged);

            CommandCenter.OnUnitivePaymentRMBEventHandler += new EventHandler<UnitivePaymentRMBEventArgs>(CommandCenter_OnUnitivePaymentRMBEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);

        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(UnitivePaymentOther), this);
                Init();
            }
        }

        void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentType.SelectedIndex < 0 || cmbPaymentType.Items.Count == 0) return;
            UnitivePaymentType upt = (cmbPaymentType.Tag as List<UnitivePaymentType>)[cmbPaymentType.SelectedIndex];
            dtpPayDate.Enabled = cmbTime.Enabled = upt == UnitivePaymentType.Order;
            if (upt == UnitivePaymentType.ActualTime)
            {
                cmbTime.Enabled = false;
                cmbTime.SelectedIndex = -1;
            }
            else
                cmbTime.Enabled = true;
            if (upt == UnitivePaymentType.Order)
                SetTimeList();
        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbAmount.Text.Trim()))
            {
                ResultData rd = new ResultData { Result = true };
                rd = DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, false, this.errorProvider1);
                if (!rd.Result) return;
                tbAmount.Text = DataConvertHelper.FormatCash(tbAmount.Text.Trim(), false);
            }
        }

        void CommandCenter_OnUnitivePaymentRMBEventHandler(object sender, UnitivePaymentRMBEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<UnitivePaymentRMBEventArgs>(CommandCenter_OnUnitivePaymentRMBEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                { SetItem(e.UnitivePaymentRMB); }
                else if (e.Command == OperatorCommandType.Reset)
                { SetItem(null); }
            }
        }

        AppliableFunctionType m_AppType;
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; }
        }

        UnitivePaymentRMB m_UnitivePaymentRMB;

        public UnitivePaymentRMB CurrentUnitivePaymentRMB
        {
            get { return m_UnitivePaymentRMB; }
            set { m_UnitivePaymentRMB = value; }
        }

        void Init()
        {
            cmbOperatorOrder.Items.Clear();
            foreach (var item in PrequisiteDataProvideNode.InitialProvide.TransferChanelTypeList)
            {
                string str = EnumNameHelper<TransferChanelType>.GetEnumDescription(item);
                cmbOperatorOrder.Items.Add(str);
            }
            cmbOperatorOrder.Tag = PrequisiteDataProvideNode.InitialProvide.TransferChanelTypeList;

            cmbPaymentType.Items.Clear();
            foreach (var item in PrequisiteDataProvideNode.InitialProvide.UnitivePaymentTypeList)
            {
                if (item == UnitivePaymentType.Empty) continue;
                string str = EnumNameHelper<UnitivePaymentType>.GetEnumDescription(item);
                cmbPaymentType.Items.Add(str);
            }
            cmbPaymentType.Tag = PrequisiteDataProvideNode.InitialProvide.UnitivePaymentTypeList.FindAll(o => o != UnitivePaymentType.Empty);
            SetRegex();
        }
        private void SetRegex()
        {
            //金额校验
            //tbAmount.DvRegCode = "reg43";
            //tbAmount.DvMinLength = 1;
            //tbAmount.DvMaxLength = 15;
            //rd = DataCheckCenter.Instance.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, false, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            tbPurpose.DvRegCode = "reg641";
            tbPurpose.DvMinLength = 0;
            tbPurpose.DvMaxLength = 20;
            tbPurpose.DvRequired = false;
            tbCustomerBusinessNo.DvRegCode = "reg8";
            tbCustomerBusinessNo.DvMinLength = 0;
            tbCustomerBusinessNo.DvMaxLength = 16;
            tbCustomerBusinessNo.DvRequired = false;


        }
        public void GetItem()
        {
            m_UnitivePaymentRMB = new UnitivePaymentRMB();
            m_UnitivePaymentRMB.Amount = tbAmount.Text.Trim().Replace(",", "");
            m_UnitivePaymentRMB.Purpose = tbPurpose.Text.Trim();
            m_UnitivePaymentRMB.UnitivePaymentType = cmbPaymentType.SelectedIndex < 0 ? UnitivePaymentType.Empty : (cmbPaymentType.Tag as List<UnitivePaymentType>)[cmbPaymentType.SelectedIndex];
            if (m_UnitivePaymentRMB.UnitivePaymentType == UnitivePaymentType.Order)
            {
                DateTime dt = dtpPayDate.Value;
                m_UnitivePaymentRMB.OrderPayDate = dt.Year.ToString() + "/" + dt.Month.ToString().PadLeft(2, '0') + "/" + dt.Day.ToString().PadLeft(2, '0');
                m_UnitivePaymentRMB.OrderPayTime = cmbTime.Text.ToString();
            }
            m_UnitivePaymentRMB.CustomerBusinissNo = tbCustomerBusinessNo.Text.Trim();
            m_UnitivePaymentRMB.TransferChanelType = cmbOperatorOrder.SelectedIndex < 0 ? TransferChanelType.Normal : (cmbOperatorOrder.Tag as List<TransferChanelType>)[cmbOperatorOrder.SelectedIndex];
            m_UnitivePaymentRMB.IsTipPayee = rbYes.Checked;
            m_UnitivePaymentRMB.TipPayeePhone = tbTipPayeePhone.Text.Trim();
        }

        void SetItem(UnitivePaymentRMB item)
        {
            if (null == item)
            {

                cmbTime.SelectedIndex = -1;
                cmbOperatorOrder.SelectedIndex =
                cmbPaymentType.SelectedIndex = -1;
                tbAmount.Text =
                tbCustomerBusinessNo.Text =
                tbPurpose.Text =
                tbTipPayeePhone.Text = string.Empty;
                rbYes.Checked = false;
                rbNo.Checked = !rbYes.Checked;
                dtpPayDate.Value = DateTime.Today;
                dtpPayDate.Enabled =
                cmbTime.Enabled = false;
            }
            else
            {
                cmbOperatorOrder.SelectedIndex = cmbOperatorOrder.Tag == null ? -1 : (cmbOperatorOrder.Tag as List<TransferChanelType>).FindIndex(o => o == item.TransferChanelType);
                cmbPaymentType.SelectedIndex = cmbPaymentType.Tag == null ? -1 : (cmbPaymentType.Tag as List<UnitivePaymentType>).FindIndex(o => o == item.UnitivePaymentType);
                tbAmount.Text = DataConvertHelper.FormatCash(item.Amount.ToString(), false);
                tbCustomerBusinessNo.Text = item.CustomerBusinissNo;
                tbPurpose.Text = item.Purpose;
                tbTipPayeePhone.Text = item.TipPayeePhone;
                rbYes.Checked = item.IsTipPayee;
                rbNo.Checked = !rbYes.Checked;
                if (!string.IsNullOrEmpty(item.OrderPayDate))
                {
                    try
                    {
                        string str = DataConvertHelper.FormatDateTimeFromInt(item.OrderPayDate);
                        if (!string.IsNullOrEmpty(str))
                        {
                            dtpPayDate.Value = DateTime.Parse(str);
                            cmbTime.Text = item.OrderPayTime;
                        }
                    }
                    catch { }
                }
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            rd.Result = rd.Result && DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, false, this.errorProvider1).Result;
            if (cmbPaymentType.SelectedIndex >= 0)
            {
                UnitivePaymentType tct = (cmbPaymentType.Tag as List<UnitivePaymentType>)[cmbPaymentType.SelectedIndex];
                if (tct == UnitivePaymentType.Order)
                {
                    if (cmbTime.SelectedIndex < 0) { cmbTime.DvErrorProvider.SetError(cmbTime, "请选择时间"); rd.Result = false; }
                    else { cmbTime.DvErrorProvider.SetError(cmbTime, ""); rd.Result = rd.Result & true; }
                }
            }
            //if (!rd.Result) return rd.Result;
            //if (!string.IsNullOrEmpty(tbPurpose.Text.Trim()))
            //{
            //    rd = DataCheckCenter.CheckAddtionExIAOrUP(tbPurpose, tbPurpose.Text.Trim(), lbPurpose.Text.Substring(0, lbPurpose.Text.Length - 1), 200, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (cmbPaymentType.SelectedIndex < 0)
            //{
            //    MessageBoxPrime.Show(string.Format("{0}{1}", MultiLanguageConvertHelper.DesignMain_Please_Selection, lbPaymentType.Text.Substring(0, lbPaymentType.Text.Length - 1)), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //if (!string.IsNullOrEmpty(tbCustomerBusinessNo.Text.Trim()))
            //{
            //    rd = DataCheckCenter.CheckCustomerRefNoGJOrUPEx(tbCustomerBusinessNo, tbCustomerBusinessNo.Text.Trim(), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (cmbOperatorOrder.SelectedIndex < 0)
            //{
            //    MessageBoxPrime.Show(string.Format("{0}{1}", MultiLanguageConvertHelper.DesignMain_Please_Selection, lbOperatorOrder.Text.Substring(0, lbOperatorOrder.Text.Length - 1)), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //if (rbYes.Checked || (rbNo.Checked && !string.IsNullOrEmpty(tbTipPayeePhone.Text.Trim())))
            //{
            //    rd = DataCheckCenter.CheckPayeePhone(tbTipPayeePhone, tbTipPayeePhone.Text.Trim(), 11, 15, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            rd.Result = rd.Result && DataCheckCenter.CheckCash(tbAmount, tbAmount.Text.Trim(), lbAmount.Text.Substring(0, lbAmount.Text.Length - 1), 15, false, this.errorProvider1).Result;
            return rd.Result;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked) return;
            lblPhone.Visible =
            lbTipPayeePhone.Visible =
            tbTipPayeePhone.Visible = rbYes.Checked;
            if (rbYes.Checked || (rbNo.Checked && !string.IsNullOrEmpty(tbTipPayeePhone.Text.Trim())))
            {
                tbTipPayeePhone.DvRegCode = "reg57";
                tbTipPayeePhone.DvMinLength = 11;
                tbTipPayeePhone.DvMaxLength = 15;
                tbTipPayeePhone.DvRequired = true;
            }
        }

        private void dtpPayDate_ValueChanged(object sender, EventArgs e)
        {
            SetTimeList();
        }

        private void SetTimeList()
        {
            cmbTime.Items.Clear();
            DateTime dt = DateTime.Now;
            if (dtpPayDate.Value.Date != dt.Date)
            {
                for (int i = 0; i <= dt.Hour; i++)
                    cmbTime.Items.Add(string.Format("{0}:00", i.ToString().PadLeft(2, '0')));
            }

            for (int i = dt.Hour + 1; i < 24; i++)
                cmbTime.Items.Add(string.Format("{0}:00", i.ToString().PadLeft(2, '0')));
            if (cmbTime.Items.Count > 0) cmbTime.SelectedIndex = -1;
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDesc.Text = DataConvertHelper.ConvertA2CN(tbAmount.Text.Trim());
        }
    }
}
