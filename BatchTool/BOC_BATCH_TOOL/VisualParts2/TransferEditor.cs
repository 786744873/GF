using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.VisualParts;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.Utilities;
using System.Text.RegularExpressions;

namespace BOC_BATCH_TOOL.VisualElements
{
    public partial class TransferEditor : BaseUc
    {
        /// <summary>
        /// 交易信息
        /// </summary>
        public TransferAccount Transfer
        {
            get
            {
                return m_Transfer;
            }
            set { m_Transfer = value; }
        }
        private TransferAccount m_Transfer = new TransferAccount();
        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                m_AppType = value;
                Init();
            }
        }
        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        public bool CanAddNotice = false;

        public TransferEditor()
        {
            InitializeComponent();
            this.Load += new EventHandler(TransferEditor_Load);
            CommandCenter.Instance.OnTransferAccountEventHandler += new EventHandler<TransferEventArgs>(CommandCenter_OnTransferAccountEventHandler);
            CommandCenter.Instance.OnPayeeInfoEventHandler += new EventHandler<PayeeEventArgs>(CommandCenter_OnPayeeInfoEventHandler);
            CommandCenter.Instance.OnNoticeEventHandler += new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler);
            CommandCenter.Instance.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnCommonDataEventHandler += new EventHandler<CommonDataEventArgs>(CommandCenter_OnCommonDataEventHandler);

            dtDesignedPaymentDate.MinDate = DateTime.Today;
            dtDesignedPaymentDate.MaxDate = DateTime.Today.AddMonths(1);
            cmbFeeChargingAccountType.DropDownStyle = ComboBoxStyle.DropDown;
            edtPayAmount.LostFocus += new EventHandler(edtPayAmount_LostFocus);
        }

        void CommandCenter_OnCommonDataEventHandler(object sender, CommonDataEventArgs e)
        {
            if (e.CommonFields != null && e.CommonFields.Count > 0)
            {
                if (!e.CommonFields.ContainsKey(m_AppType)) return;
                p_lockPayDate.Visible =
                p_lockPayeFeeNo.Visible =
                p_lockOperateOrder.Visible =
                islockShow = e.Command == OperatorCommandType.CommonFieldLockShow;
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(TransferEditor), this);
                Init();
            }
        }

        void Init()
        {
            if (m_AppType == AppliableFunctionType._Empty) return;
            if (m_AppType == AppliableFunctionType.TransferWithIndiv
                || m_AppType == AppliableFunctionType.TransferWithCorp)
            {
                pOverBankIn.Visible = false;
                lblPayeeEmail.Visible = tbEmail.Visible = true;
                lblOperatorOrder.Visible = rbExpress.Visible = rbNormal.Visible = true;
            }
            else if (m_AppType == AppliableFunctionType.TransferOverBankIn)
            {
                pOverBankIn.Visible = true; pDateTime.Visible = false;
                lblPayeeEmail.Visible = tbEmail.Visible = false;
                lblOperatorOrder.Visible = rbExpress.Visible = rbNormal.Visible = false;

                lblDateTime.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayDateTime, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
                if (lblDateTime.Location.X + lblDateTime.Width > lblAddtion.Location.X + lblAddtion.Width)
                {
                    lblDateTime.AutoSize = false;
                    lblDateTime.Width = 120;
                    lblDateTime.Height = 26;
                    lblDateTime.Location = new Point { X = lblAddtion.Location.X + lblAddtion.Width - lblDateTime.Width, Y = lblDateTime.Location.Y };
                }

                cmbBusinessType.Items.Clear();
                foreach (BusinessType bt in PrequisiteDataProvideNode.InitialProvide.BusinessTypeList)
                {
                    if (bt == BusinessType.Empty) continue;
                    cmbBusinessType.Items.Add(EnumNameHelper<BusinessType>.GetEnumDescription(bt));
                }
                cmbBusinessType.Tag = PrequisiteDataProvideNode.InitialProvide.BusinessTypeList.FindAll(o => o != BusinessType.Empty);
            }
            else if (m_AppType == AppliableFunctionType.TransferOverBankOut)
            {
                pOverBankIn.Visible = false;
                lblPayeeEmail.Visible = tbEmail.Visible = false;
                lblOperatorOrder.Visible = rbExpress.Visible = rbNormal.Visible = true;
            }

            if (m_AppType != AppliableFunctionType.TransferOverBankIn)
            {
                cmbFeeChargingAccountType.Items.Clear();
                cmbFeeChargingAccountType.Items.Add(EnumNameHelper<ChargingFeeAccountType>.GetEnumDescription(ChargingFeeAccountType.SameAsPayingAccount));
                if (m_AppType != AppliableFunctionType._Empty)
                {
                    if (SystemSettings.Instance.Notices.ContainsKey(m_AppType))
                    {
                        cmbAdditionalComment.Items.Clear();
                        foreach (var item in SystemSettings.Instance.Notices[m_AppType])
                        {
                            if (string.IsNullOrEmpty(item.Content)) continue;
                            cmbAdditionalComment.Items.Add(item.Content);
                        }
                    }
                    List<PayerInfo> list = new List<PayerInfo>();
                    foreach (var item in SystemSettings.Instance.PayerList)
                    {
                        if ((item.ServiceList & m_AppType) == m_AppType)
                        {
                            cmbFeeChargingAccountType.Items.Add(item);
                            list.Add(item);
                        }
                    }
                    cmbFeeChargingAccountType.Tag = list;
                }
                if (cmbFeeChargingAccountType.Items.Count > 0 && !string.IsNullOrEmpty(cmbFeeChargingAccountType.Text))
                {
                    if (cmbFeeChargingAccountType.Tag != null && !(cmbFeeChargingAccountType.Tag as List<PayerInfo>).Exists(o => o.Account.Equals(cmbFeeChargingAccountType.Text.Trim())) && !cmbFeeChargingAccountType.Text.Trim().Equals(EnumNameHelper<ChargingFeeAccountType>.GetEnumDescription(ChargingFeeAccountType.SameAsPayingAccount)))
                        cmbFeeChargingAccountType.SelectedIndex = 0;
                }
            }
        }

        void edtPayAmount_LostFocus(object sender, EventArgs e)
        {
            FormatCash();
        }

        private void FormatCash()
        {
            if (!string.IsNullOrEmpty(edtPayAmount.Text))
            {
                edtPayAmount.Text = DataConvertHelper.Instance.FormatCash(edtPayAmount.Text.Trim(), false);
            }
        }

        void CommandCenter_OnPayerInfoEventHandler(object sender, PayerEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.OwnerType && e.Command != OperatorCommandType.Empty) return;
                if (null == e.PayerInfo || (null != e.PayerInfo && (e.PayerInfo.ServiceList & m_AppType) != m_AppType)) return;
                List<PayerInfo> list = cmbFeeChargingAccountType.Tag as List<PayerInfo>;
                if (null == list) list = new List<PayerInfo>();
                int index = list.FindIndex(o => o.Account == e.PayerInfo.Account);
                if (e.Command == OperatorCommandType.Submit || e.Command == OperatorCommandType.Edit)
                {
                    if (index >= 0)
                    {
                        list[index] = e.PayerInfo;
                        cmbFeeChargingAccountType.Items[index + 1] = e.PayerInfo;
                    }
                    else
                    {
                        list.Add(e.PayerInfo);
                        cmbFeeChargingAccountType.Items.Add(e.PayerInfo);
                    }
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    if (index >= 0)
                    {
                        cmbFeeChargingAccountType.Items.RemoveAt(index + 1);
                        list.RemoveAt(index);
                    }
                } cmbFeeChargingAccountType.Tag = list;
            }
        }

        void CommandCenter_OnNoticeEventHandler(object sender, NoticeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                if (e.Command == OperatorCommandType.Submit)
                {
                    if (e.Notice != null)
                    {
                        //if (cmbAdditionalComment.Items.Count > 9) return;
                        if (!cmbAdditionalComment.Items.Contains(e.Notice.Content))
                            cmbAdditionalComment.Items.Add(e.Notice.Content);
                    }
                    else if (e.NoticeList != null && e.NoticeList.Count > 0)
                    {
                        cmbAdditionalComment.Items.Clear();
                        foreach (var item in e.NoticeList)
                        {
                            if (string.IsNullOrEmpty(item.Content)) continue;
                            cmbAdditionalComment.Items.Add(item.Content);
                        }
                    }
                }
            }
        }

        void CommandCenter_OnPayeeInfoEventHandler(object sender, PayeeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayeeEventArgs>(CommandCenter_OnPayeeInfoEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != m_AppType
                    || m_AppType == AppliableFunctionType.TransferOverBankIn
                    || m_AppType == AppliableFunctionType.TransferOverBankOut)
                    return;
                if (e.Command == OperatorCommandType.Empty && e.BatchCommand == OperatorCommandType.Empty)
                {
                    tbEmail.Text = string.IsNullOrEmpty(e.PayeeInfo.Email) ? string.Empty : e.PayeeInfo.Email;
                }
            }
        }

        void CommandCenter_OnTransferAccountEventHandler(object sender, TransferEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<TransferEventArgs>(CommandCenter_OnTransferAccountEventHandler), new object[] { sender, e }); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                this.errorProvider1.Clear();
                if (OperatorCommandType.View == e.Command)
                {
                    m_Transfer = e.TransferAccount;
                    SetItem(e.TransferAccount);
                }
                else if (OperatorCommandType.Edit == e.Command)
                {
                    m_Transfer = null;
                    ClearItem(OperatorCommandType.Reset == e.Command || OperatorCommandType.Delete == e.Command);
                }
            }
        }

        void TransferEditor_Load(object sender, EventArgs e)
        {
            if (cmbFeeChargingAccountType.Items.Count > 0)
                cmbFeeChargingAccountType.SelectedIndex = 0;
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData();
            if (m_AppType == AppliableFunctionType.TransferOverBankIn)
            {
                rd = DataCheckCenter.Instance.CheckProtecolNo(tbProtecol, tbProtecol.Text, label4.Text.Substring(0, label4.Text.Length - 1), 60, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (cmbBusinessType.SelectedIndex < 0) { MessageBoxExHelper.Instance.Show("请选择业务种类", CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            }
            if (!string.IsNullOrEmpty(tbCustomerRef.Text))
            {
                rd = DataCheckCenter.Instance.CheckCustomerReferenceNo(tbCustomerRef, tbCustomerRef.Text.Trim(), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            rd = DataCheckCenter.Instance.CheckCash(edtPayAmount, edtPayAmount.Text.Trim(), lblAmount.Text.Substring(lblAmount.Text.Length - 1), 15, false, this.errorProvider1);
            if (!rd.Result) return rd.Result;

            if (!string.IsNullOrEmpty(cmbFeeChargingAccountType.Text) && (cmbFeeChargingAccountType.Items.Count > 0 && cmbFeeChargingAccountType.Items[0].ToString() != cmbFeeChargingAccountType.Text.Trim()))
            {
                bool flag = m_AppType == AppliableFunctionType.TransferOverBankIn;
                rd = DataCheckCenter.Instance.CheckPayFeeNo(cmbFeeChargingAccountType, cmbFeeChargingAccountType.Text.Trim(), flag ? 12 : 0, flag ? 18 : 35, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }

            rd = DataCheckCenter.Instance.CheckPayDatetime(dtDesignedPaymentDate, dtDesignedPaymentDate.Value, lblDateTime.Text.Substring(0, lblDateTime.Text.Length - 1), this.errorProvider1);
            if (!rd.Result) return rd.Result;

            rd = DataCheckCenter.Instance.CheckAddtion(cmbAdditionalComment, cmbAdditionalComment.Text.Trim(), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (m_AppType == AppliableFunctionType.TransferWithIndiv || m_AppType == AppliableFunctionType.TransferWithCorp)
            {
                if (string.IsNullOrEmpty(tbEmail.Text)) return true;
                rd = DataCheckCenter.Instance.CheckEmail(tbEmail, tbEmail.Text, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            return true;
        }

        public void GetItem()
        {
            m_Transfer = new TransferAccount();
            m_Transfer.CustomerRef = this.tbCustomerRef.Text.Trim();
            m_Transfer.PayAmount = this.edtPayAmount.Text.Trim().Replace(",", "");
            if (m_AppType != AppliableFunctionType.TransferOverBankIn)
                m_Transfer.PayFeeNo = cmbFeeChargingAccountType.SelectedIndex == 0 || (cmbFeeChargingAccountType.Text.Trim() == cmbFeeChargingAccountType.Items[0].ToString()) ? "" : cmbFeeChargingAccountType.Text;
            DateTime dt = dtDesignedPaymentDate.Value;
            m_Transfer.PayDatetime = dt.Year + dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0');
            m_Transfer.Addition = this.cmbAdditionalComment.Text.Trim();
            m_Transfer.TChanel = this.rbNormal.Checked ? TransferChanelType.Normal : TransferChanelType.Express;
            if (m_AppType == AppliableFunctionType.TransferWithIndiv || m_AppType == AppliableFunctionType.TransferWithCorp)
            {
                m_Transfer.Email = this.tbEmail.Text.Trim();
            }
            else if (m_AppType == AppliableFunctionType.TransferOverBankIn)
            {
                m_Transfer.PayProtecolNo = tbProtecol.Text.Trim();
                m_Transfer.BusinessType = (cmbBusinessType.Tag as List<BusinessType>)[cmbBusinessType.SelectedIndex];
            }
            CanAddNotice = cbSave.Checked;
        }

        public void SetItem(TransferAccount item)
        {
            this.tbCustomerRef.Text = m_Transfer.CustomerRef;
            this.edtPayAmount.Text = m_Transfer.PayAmount.ToString();
            if (!string.IsNullOrEmpty(m_Transfer.PayFeeNo))
            {
                if (m_Transfer.PayFeeNo == m_Transfer.PayerAccount)
                    this.cmbFeeChargingAccountType.SelectedItem = m_Transfer.PayFeeType;
                else
                {
                    cmbFeeChargingAccountType.SelectedIndex = -1;
                    cmbFeeChargingAccountType.Text = m_Transfer.PayFeeNo;
                }
            }
            else
            {
                this.cmbFeeChargingAccountType.SelectedItem = m_Transfer.PayFeeType;
            }
            try
            {
                if (!string.IsNullOrEmpty(m_Transfer.PayDatetime))
                {
                    string tempDateTime = DataConvertHelper.Instance.FormatDateTimeFromInt(m_Transfer.PayDatetime);
                    ResultData rd = DataCheckCenter.Instance.CheckPayDatetime(null, tempDateTime, lblDateTime.Text.Substring(0, lblDateTime.Text.Length - 1), null);
                    if (rd.Result)
                        this.dtDesignedPaymentDate.Value = DateTime.Parse(tempDateTime);
                }
            }
            catch { this.dtDesignedPaymentDate.Value = DateTime.Today; }
            this.cmbAdditionalComment.Text = m_Transfer.Addition;
            this.rbNormal.Checked = m_Transfer.TChanel == TransferChanelType.Normal;
            this.rbExpress.Checked = !rbNormal.Checked;
            tbEmail.Text = m_Transfer.Email;
            if (m_AppType == AppliableFunctionType.TransferWithCorp || m_AppType == AppliableFunctionType.TransferWithIndiv)
                this.tbEmail.Text = m_Transfer.Email;
            else if (m_AppType == AppliableFunctionType.TransferOverBankIn)
            {
                tbProtecol.Text = m_Transfer.PayProtecolNo;
                try
                {
                    if (m_Transfer.BusinessType != BusinessType.Empty)
                        cmbBusinessType.SelectedItem = EnumNameHelper<BusinessType>.GetEnumDescription(m_Transfer.BusinessType);
                    else cmbBusinessType.SelectedIndex = -1;
                }
                catch { }
            }
            FormatCash();
        }

        public void ClearItem(bool isResetOrDel)
        {
            this.tbCustomerRef.Text = string.Empty;
            this.edtPayAmount.Text = string.Empty;
            if (isResetOrDel || !(islockPayFeeNo && islockShow))//CommonInformations.Instance.CanClearItem(m_AppType, CommonFieldType.PayFeeNo))
            {
                this.cmbFeeChargingAccountType.SelectedIndex = -1;
                this.cmbFeeChargingAccountType.Text = string.Empty;
            }
            if (isResetOrDel || !(islockPayDate && islockShow))//CommonInformations.Instance.CanClearItem(m_AppType, CommonFieldType.PaidDate))
                this.dtDesignedPaymentDate.Value = DateTime.Today;
            this.cmbAdditionalComment.Text = string.Empty;
            if (isResetOrDel || !(islockOperateOrder && islockShow))//CommonInformations.Instance.CanClearItem(m_AppType, CommonFieldType.OperatorOrder))
                this.rbNormal.Checked = true;
            if (m_AppType == AppliableFunctionType.TransferWithCorp || m_AppType == AppliableFunctionType.TransferWithIndiv)
                this.tbEmail.Text = string.Empty;
            else if (m_AppType == AppliableFunctionType.TransferOverBankIn)
            {
                tbProtecol.Text = string.Empty;
                cmbBusinessType.SelectedIndex = -1;
            }
            cbSave.Checked = false;
        }

        private void p_lock_Click(object sender, EventArgs e)
        {
            if ((sender as Panel).Name.Equals(p_lockPayDate.Name))
            {
                if (p_lockPayDate.BackgroundImage == null)
                {
                    p_lockPayDate.BackgroundImage = Properties.Resources.unlocked;
                    islockPayDate = false;
                }
                else
                {
                    p_lockPayDate.BackgroundImage = islockPayDate ? Properties.Resources.unlocked : Properties.Resources.locked;
                    islockPayDate = !islockPayDate;
                }
            }
            else if ((sender as Panel).Name.Equals(p_lockPayeFeeNo.Name))
            {
                if (p_lockPayeFeeNo.BackgroundImage == null)
                {
                    p_lockPayeFeeNo.BackgroundImage = Properties.Resources.unlocked;
                    islockPayFeeNo = false;
                }
                else
                {
                    p_lockPayeFeeNo.BackgroundImage = islockPayFeeNo ? Properties.Resources.unlocked : Properties.Resources.locked;
                    islockPayFeeNo = !islockPayFeeNo;
                }
            }
            else if ((sender as Panel).Name.Equals(p_lockOperateOrder.Name))
            {
                if (p_lockOperateOrder.BackgroundImage == null)
                {
                    p_lockOperateOrder.BackgroundImage = Properties.Resources.unlocked;
                    islockOperateOrder = false;
                }
                else
                {
                    p_lockOperateOrder.BackgroundImage = islockOperateOrder ? Properties.Resources.unlocked : Properties.Resources.locked;
                    islockOperateOrder = !islockOperateOrder;
                }
            }
        }

        bool islockPayDate = false;
        bool islockPayFeeNo = false;
        bool islockOperateOrder = false;
        bool islockShow = false;

        private void pbTip_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show("自定义的单位内部交易编号，随交易信息保存，可在整个交易处理过程中随时查看", pbTip);
        }
    }
}
