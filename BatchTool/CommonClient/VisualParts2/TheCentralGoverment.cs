using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.VisualParts;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.Utilities;
using System.Text.RegularExpressions;
using CommonClient.Contract;
namespace CommonClient.VisualParts2
{
    public partial class TheCentralGoverment : BaseUc
    {
               /// <summary>
        /// 交易信息
        /// </summary>
        public GovermentInfo Goverment
        {
            get
            {
                return m_Goverment;
            }
            set { m_Goverment = value; }
        }
        private GovermentInfo m_Goverment = new GovermentInfo();
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

        public TheCentralGoverment()
        {
            InitializeComponent();
            this.Load += new EventHandler(TheCentralGoverment_Load);
            CommandCenter.OnGovermentEventHandler += new EventHandler<GovermentEventArgs>(CommandCenter_OnGovermentEventHandler);
            //CommandCenter.OnPayeeInfoEventHandler += new EventHandler<PayeeEventArgs>(CommandCenter_OnPayeeInfoEventHandler);
            CommandCenter.OnNoticeEventHandler += new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler);
            //CommandCenter.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
           // CommandCenter.OnCommonDataEventHandler += new EventHandler<CommonDataEventArgs>(CommandCenter_OnCommonDataEventHandler);

            dtDesignedPaymentDate.MinDate = DateTime.Today;
            dtDesignedPaymentDate.MaxDate = DateTime.Today.AddMonths(1);
            edtPayAmount.LostFocus += new EventHandler(edtPayAmount_LostFocus);
            

        }

        //void CommandCenter_OnCommonDataEventHandler(object sender, CommonDataEventArgs e)
        //{
        //    if (e.CommonFields != null && e.CommonFields.Count > 0)
        //    {
        //        if (!e.CommonFields.ContainsKey(m_AppType)) return;
        //        p_lockPayDate.Visible =
        //        p_lockPayeFeeNo.Visible =
        //        p_lockOperateOrder.Visible =
        //        islockShow = e.Command == OperatorCommandType.CommonFieldLockShow;
        //    }
        //}

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(TheCentralGoverment), this);
                Init();
            }
        }

        void Init()
        {
            if (m_AppType == AppliableFunctionType._Empty) return;
            //if (m_AppType == AppliableFunctionType.TransferWithIndiv
            //    || m_AppType == AppliableFunctionType.TransferWithCorp)
            //{
            //    pOverBankIn.Visible = false;
            //    lblPayeeEmail.Visible = tbEmail.Visible = true;
            //    lblOperatorOrder.Visible = rbExpress.Visible = rbNormal.Visible = true;
            //}
            //else if (m_AppType == AppliableFunctionType.TransferOverBankIn)
            //{
            //    pOverBankIn.Visible = true; pDateTime.Visible = false;
            //    lblPayeeEmail.Visible = tbEmail.Visible = false;
            //    lblOperatorOrder.Visible = rbExpress.Visible = rbNormal.Visible = false;

            //    lblDateTime.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayDateTime, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
            //    if (lblDateTime.Location.X + lblDateTime.Width > lblAddtion.Location.X + lblAddtion.Width)
            //    {
            //        lblDateTime.AutoSize = false;
            //        lblDateTime.Width = 120;
            //        lblDateTime.Height = 26;
            //        lblDateTime.Location = new Point { X = lblAddtion.Location.X + lblAddtion.Width - lblDateTime.Width, Y = lblDateTime.Location.Y };
            //    }

            //    cmbBusinessType.Items.Clear();
            //    foreach (BusinessType bt in PrequisiteDataProvideNode.InitialProvide.BusinessTypeList)
            //    {
            //        if (bt == BusinessType.Empty) continue;
            //        cmbBusinessType.Items.Add(EnumNameHelper<BusinessType>.GetEnumDescription(bt));
            //    }
            //    cmbBusinessType.Tag = PrequisiteDataProvideNode.InitialProvide.BusinessTypeList.FindAll(o => o != BusinessType.Empty);
            //}
            //else if (m_AppType == AppliableFunctionType.TransferOverBankOut)
            //{
            //    pOverBankIn.Visible = false;
            //    lblPayeeEmail.Visible = tbEmail.Visible = false;
            //    lblOperatorOrder.Visible = rbExpress.Visible = rbNormal.Visible = true;
            //}

            //cmbFeeChargingAccountType.Items.Clear();
            //if (m_AppType != AppliableFunctionType.TransferOverBankIn)
            //    cmbFeeChargingAccountType.Items.Add(EnumNameHelper<ChargingFeeAccountType>.GetEnumDescription(ChargingFeeAccountType.SameAsPayingAccount));
            //else
            //    cmbFeeChargingAccountType.Items.Add(EnumNameHelper<ChargingFeeAccountType>.GetEnumDescription(ChargingFeeAccountType.SameAsPayingAccount).Replace("付", "收"));
            if (m_AppType != AppliableFunctionType._Empty)
            {
                if (SystemSettings.Notices.ContainsKey(m_AppType))
                {
                    cmbAdditionalComment.Items.Clear();
                    foreach (var item in SystemSettings.Notices[m_AppType])
                    {
                        if (string.IsNullOrEmpty(item.Content)) continue;
                        cmbAdditionalComment.Items.Add(item.Content);
                    }
                }
                //List<PayerInfo> list = new List<PayerInfo>();
                //foreach (var item in SystemSettings.PayerList)
                //{
                //    if ((item.ServiceList & m_AppType) == m_AppType)
                //    {
                //        //cmbFeeChargingAccountType.Items.Add(item);
                //        list.Add(item);
                //    }
                //}
                //cmbFeeChargingAccountType.Tag = list;
                //ambiguityInputAgent1.ClearItems();
                //list.ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            }
            //if (cmbFeeChargingAccountType.Items.Count > 0 && !string.IsNullOrEmpty(cmbFeeChargingAccountType.Text))
            //{
            //    if (cmbFeeChargingAccountType.Tag != null && !(cmbFeeChargingAccountType.Tag as List<PayerInfo>).Exists(o => o.Account.Equals(cmbFeeChargingAccountType.Text.Trim())) && !cmbFeeChargingAccountType.Text.Trim().Equals(EnumNameHelper<ChargingFeeAccountType>.GetEnumDescription(ChargingFeeAccountType.SameAsPayingAccount)))
            //        cmbFeeChargingAccountType.SelectedIndex = 0;
            //}

            //lblpurpose.Visible = m_AppType == AppliableFunctionType.TransferWithIndiv;
            //linkContent.Visible = (SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501;
            SetRegex();
        }
        private void SetRegex()
        {

            cmbAdditionalComment.DvRegCode = "reg667";
            cmbAdditionalComment.DvMinLength = 0;
            cmbAdditionalComment.DvMaxLength = 200;
            cmbAdditionalComment.DvRequired = true;



        }
        void edtPayAmount_LostFocus(object sender, EventArgs e)
        {
            FormatCash();
        }

        private void FormatCash()
        {
            if (!string.IsNullOrEmpty(edtPayAmount.Text))
            {
                ResultData rd = new ResultData { Result = true };
                rd = DataCheckCenter.CheckCash(edtPayAmount, edtPayAmount.Text.Trim(), lblAmount.Text.Substring(0, lblAmount.Text.Length - 1), 15, false, this.errorProvider1);
                if (!rd.Result) return;
                edtPayAmount.Text = DataConvertHelper.FormatCash(edtPayAmount.Text.Trim(), false);
            }
        }

        //void CommandCenter_OnPayerInfoEventHandler(object sender, PayerEventArgs e)
        //{
        //    if (this.InvokeRequired) { this.Invoke(new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler), sender, e); }
        //    else
        //    {
                //if (m_AppType != e.OwnerType && e.Command != OperatorCommandType.Empty) return;
                //if (null == e.PayerInfo || (null != e.PayerInfo && (e.PayerInfo.ServiceList & m_AppType) != m_AppType)) return;
                //List<PayerInfo> list = cmbFeeChargingAccountType.Tag as List<PayerInfo>;
                //if (null == list) list = new List<PayerInfo>();
                //int index = list.FindIndex(o => o.Account == e.PayerInfo.Account);
                //if (cmbFeeChargingAccountType.Items.Count <= index + 1) return;
                //if (e.Command == OperatorCommandType.Submit || e.Command == OperatorCommandType.Edit)
                //{
                //    if (index >= 0)
                //    {
                //        list[index] = e.PayerInfo;
                //        cmbFeeChargingAccountType.Items[index + 1] = e.PayerInfo;
                //    }
                //    else
                //    {
                //        list.Add(e.PayerInfo);
                //        cmbFeeChargingAccountType.Items.Add(e.PayerInfo);
                //    }
                //}
                //else if (e.Command == OperatorCommandType.Delete)
                //{
                //    if (index >= 0)
                //    {

                //        cmbFeeChargingAccountType.Items.RemoveAt(index + 1);
                //        list.RemoveAt(index);
                //    }
                //} cmbFeeChargingAccountType.Tag = list;
                //ambiguityInputAgent1.ClearItems();
                //list.ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
        //    }
        //}

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
                    else if (e.NoticeList != null && e.NoticeList.Count == 0 && cmbAdditionalComment.Items.Count > 0)
                    {
                        cmbAdditionalComment.Items.Clear();
                    }
                }
            }
        }

        //void CommandCenter_OnPayeeInfoEventHandler(object sender, PayeeEventArgs e)
        //{
        //    if (this.InvokeRequired) { this.Invoke(new EventHandler<PayeeEventArgs>(CommandCenter_OnPayeeInfoEventHandler), sender, e); }
        //    else
        //    {
        //        if (e.OwnerType != m_AppType
        //            || m_AppType == AppliableFunctionType.TransferOverBankIn
        //            || m_AppType == AppliableFunctionType.TransferOverBankOut)
        //            return;
        //        if (e.Command == OperatorCommandType.Empty && e.BatchCommand == OperatorCommandType.Empty)
        //        {
        //            tbEmail.Text = string.IsNullOrEmpty(e.PayeeInfo.Email) ? string.Empty : e.PayeeInfo.Email;
        //        }
        //    }
        //}

        void CommandCenter_OnGovermentEventHandler(object sender, GovermentEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<GovermentEventArgs>(CommandCenter_OnGovermentEventHandler), new object[] { sender, e }); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                this.errorProvider1.Clear();
                if (OperatorCommandType.View == e.Command)
                {
                    m_Goverment = e.GovermentInfo;
                    SetItem(e.GovermentInfo);
                }
                else if (OperatorCommandType.Edit == e.Command
                    || OperatorCommandType.Reset == e.Command
                    || OperatorCommandType.Delete == e.Command)
                {
                    m_Goverment = null;
                    ClearItem();
                }
            }
        }

        void TheCentralGoverment_Load(object sender, EventArgs e)
        {
            //if (cmbFeeChargingAccountType.Items.Count > 0)
            //    cmbFeeChargingAccountType.SelectedIndex = 0;
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //if (m_AppType == AppliableFunctionType.TransferOverBankIn)
            //{
            //    rd = DataCheckCenter.CheckProtecolNo(tbProtecol, tbProtecol.Text, label4.Text.Substring(0, label4.Text.Length - 1), 60, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //    if (cmbBusinessType.SelectedIndex < 0) { MessageBoxPrime.Show("请选择业务种类", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //}
            //if (!string.IsNullOrEmpty(tbCustomerRef.Text))
            //{
            //    rd = DataCheckCenter.CheckCustomerReferenceNo(tbCustomerRef, tbCustomerRef.Text.Trim(), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //rd = DataCheckCenter.CheckCash(edtPayAmount, edtPayAmount.Text.Trim(), lblAmount.Text.Substring(lblAmount.Text.Length - 1), 15, false, this.errorProvider1);
            //if (!rd.Result) return rd.Result;

            //if (!string.IsNullOrEmpty(cmbFeeChargingAccountType.Text) && (cmbFeeChargingAccountType.Items.Count > 0 && cmbFeeChargingAccountType.Items[0].ToString() != cmbFeeChargingAccountType.Text.Trim()))
            //{
            //    bool flag = m_AppType == AppliableFunctionType.TransferOverBankIn;
            //    rd = DataCheckCenter.CheckPayFeeNo(cmbFeeChargingAccountType, cmbFeeChargingAccountType.Text.Trim(), flag ? 12 : 0, flag ? 18 : 35, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}

            //rd = DataCheckCenter.CheckPayDatetime(dtDesignedPaymentDate, dtDesignedPaymentDate.Value, lblDateTime.Text.Substring(0, lblDateTime.Text.Length - 1), this.errorProvider1);
            //if (!rd.Result) return rd.Result;

            //rd = DataCheckCenter.CheckAddtion(cmbAdditionalComment, cmbAdditionalComment.Text.Trim(), this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //if (m_AppType == AppliableFunctionType.TransferWithIndiv || m_AppType == AppliableFunctionType.TransferWithCorp)
            //{
            //    if (string.IsNullOrEmpty(tbEmail.Text)) return true;
            //    rd = DataCheckCenter.CheckEmail(tbEmail, tbEmail.Text, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            rd.Result = rd.Result & DataCheckCenter.CheckCash(edtPayAmount, edtPayAmount.Text.Trim(), lblAmount.Text.Substring(0, lblAmount.Text.Length - 1), 15, false, this.errorProvider1).Result;

            return rd.Result;
        }

        public void GetItem()
        {
            m_Goverment = new GovermentInfo();
            m_Goverment.CustomerRef = this.txtcustomer.Text.Trim();
            m_Goverment.PayAmount = this.edtPayAmount.Text.Trim().Replace(",", "");
            DateTime dt = dtDesignedPaymentDate.Value;
            m_Goverment.PayDatetime = dt.Year + dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0');
            m_Goverment.Addition = this.cmbAdditionalComment.Text.Trim();
            m_Goverment.OddNumber = this.txtoddnumber.Text.Trim();
            m_Goverment.PayeeCode = this.txtcode.Text.Trim();
            CanAddNotice = true;
        }

        public void SetItem(GovermentInfo item)
        {
            this.txtcustomer.Text = m_Goverment.CustomerRef;
            this.edtPayAmount.Text = m_Goverment.PayAmount.ToString();
            try
            {
                if (!string.IsNullOrEmpty(m_Goverment.PayDatetime))
                {
                    string tempDateTime = DataConvertHelper.FormatDateTimeFromInt(m_Goverment.PayDatetime);
                    ResultData rd = DataCheckCenter.CheckPayDatetime(null, tempDateTime, lblDateTime.Text.Substring(0, lblDateTime.Text.Length - 1), null);
                    if (rd.Result)
                        this.dtDesignedPaymentDate.Value = DateTime.Parse(tempDateTime);
                }
            }
            catch { this.dtDesignedPaymentDate.Value = DateTime.Today; }
            this.cmbAdditionalComment.Text = m_Goverment.Addition;
            this.txtcode.Text = m_Goverment.PayeeCode;
            this.txtoddnumber.Text = m_Goverment.OddNumber;
            FormatCash();
        }

        public void ClearItem()
        {
            this.txtcustomer.Text =
                this.txtoddnumber.Text =
                this.txtcode.Text =
                this.edtPayAmount.Text =
                this.cmbAdditionalComment.Text = string.Empty;
            if (!(islockPayDate && islockShow))//CommonInformations.CanClearItem(m_AppType, CommonFieldType.PaidDate))
                this.dtDesignedPaymentDate.Value = DateTime.Today;

        }

        //private void p_lock_Click(object sender, EventArgs e)
        //{
        //    if ((sender as Panel).Name.Equals(p_lockPayDate.Name))
        //    {
        //        if (p_lockPayDate.BackgroundImage == null)
        //        {
        //            p_lockPayDate.BackgroundImage = Properties.Resources.unlocked;
        //            islockPayDate = false;
        //        }
        //        else
        //        {
        //            p_lockPayDate.BackgroundImage = islockPayDate ? Properties.Resources.unlocked : Properties.Resources.locked;
        //            islockPayDate = !islockPayDate;
        //        }
        //    }
        //    else if ((sender as Panel).Name.Equals(p_lockPayeFeeNo.Name))
        //    {
        //        if (p_lockPayeFeeNo.BackgroundImage == null)
        //        {
        //            p_lockPayeFeeNo.BackgroundImage = Properties.Resources.unlocked;
        //            islockPayFeeNo = false;
        //        }
        //        else
        //        {
        //            p_lockPayeFeeNo.BackgroundImage = islockPayFeeNo ? Properties.Resources.unlocked : Properties.Resources.locked;
        //            islockPayFeeNo = !islockPayFeeNo;
        //        }
        //    }
        //    else if ((sender as Panel).Name.Equals(p_lockOperateOrder.Name))
        //    {
        //        if (p_lockOperateOrder.BackgroundImage == null)
        //        {
        //            p_lockOperateOrder.BackgroundImage = Properties.Resources.unlocked;
        //            islockOperateOrder = false;
        //        }
        //        else
        //        {
        //            p_lockOperateOrder.BackgroundImage = islockOperateOrder ? Properties.Resources.unlocked : Properties.Resources.locked;
        //            islockOperateOrder = !islockOperateOrder;
        //        }
        //    }
        //}

        bool islockPayDate = false;
        bool islockPayFeeNo = false;
        bool islockOperateOrder = false;
        bool islockShow = false;
        private void pbTip_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show("自定义的单位内部交易编号，随交易信息保存，可在整个交易处理过程中随时查看", pbTip);
        }

        private void edtPayAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDesc.Text = DataConvertHelper.ConvertA2CN(edtPayAmount.Text.Trim());
        }

        private void linkConent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModuleWorkSpaceLoader.BroadcastApplicationBringToFront("BOC_BATCH_TOOL_SETTINGS", FunctionInSettingType.AddtionMg, m_AppType);
        }
    }
}
