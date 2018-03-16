using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.Utilities;
using CommonClient.Entities;
using CommonClient.ConvertHelper;
using CommonClient.Controls;
using CommonClient.VisualParts;
using CommonClient.Contract;

namespace CommonClient.VisualParts2
{
    public partial class TransferGlobalOtherSelector : BaseUc
    {
        public TransferGlobalOtherSelector()
        {
            InitializeComponent();
            InitData();

            tbDealSerialNoS.TextChanged += new EventHandler(tbDealSerialNoS_TextChanged);
            tbDealSerialNoF.TextChanged += new EventHandler(tbDealSerialNoF_TextChanged);
            tbAmountF.LostFocus += new EventHandler(tbAmount_LostFocus);
            tbAmountS.LostFocus += new EventHandler(tbAmount_LostFocus);

            CommandCenter.OnTransferGlobalEventHandler += new EventHandler<TransferGlobalEventArgs>(CommandCenter_OnTransferGlobalEventHandler);
            CommandCenter.OnCashTypeChangedEventHandler += new EventHandler<CashTypeChangedEventArgs>(CommandCenter_OnCashTypeChangedEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnNoticeEventHandler += new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler);
            CommandCenter.OnBankTypeChangedEventHandler += new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler);
            CommandCenter.OnOverCountryPayeeAccountTypeEventHandler += new EventHandler<OverCountryPayeeAccountTypeEventArgs>(CommandCenter_OnOverCountryPayeeAccountTypeEventHandler);
            CommandCenter.OnUnitivePaymentFCEventHandler += new EventHandler<UnitivePaymentFCEventArgs>(CommandCenter_OnUnitivePaymentFCEventHandler);
        }

        void CommandCenter_OnUnitivePaymentFCEventHandler(object sender, UnitivePaymentFCEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<UnitivePaymentFCEventArgs>(CommandCenter_OnUnitivePaymentFCEventHandler), sender, e); }
            else
            {
                if (m_appType != e.OwnerType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                    SetItem(e.UnitivePaymentFC);
                else if (e.Command == OperatorCommandType.Reset)
                    SetItem(null);
            }
        }

        void tbDealSerialNoS_TextChanged(object sender, EventArgs e)
        {
            bool flag = string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim());
            tbAmountS.ReadOnly =
            tbDealNoteS.ReadOnly = flag;
            tbAmountS.DvRequired =
            tbDealNoteS.DvRequired = !flag;
            if (flag)
                tbAmountS.Text =
                tbDealNoteS.Text = string.Empty;
        }

        void tbDealSerialNoF_TextChanged(object sender, EventArgs e)
        {
            bool flag = string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim());
            tbAmountF.ReadOnly =
            tbDealNoteF.ReadOnly = flag;
            tbAmountF.DvRequired =
            tbDealNoteF.DvRequired = !flag;
            if (flag)
                tbAmountF.Text =
                tbDealNoteF.Text = string.Empty;

        }

        void CommandCenter_OnOverCountryPayeeAccountTypeEventHandler(object sender, OverCountryPayeeAccountTypeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<OverCountryPayeeAccountTypeEventArgs>(CommandCenter_OnOverCountryPayeeAccountTypeEventHandler), sender, e); }
            else
            {
                if (m_appType != e.AppType) return;
                if (e.Command != OperatorCommandType.PayeeAccountTypeChanged) return;
                if (m_appType == AppliableFunctionType.UnitivePaymentFC)
                {
                    bool isForeigner = e.AccountType == OverCountryPayeeAccountType.ForeignAccount;
                    pDealNote.Visible = isForeigner;
                    pPaymentProperty.Visible = !isForeigner;
                    //if (isForeigner)
                    //    lbAssumeFeeType.Visible = cmbAssumeFeeType.Visible = false;
                    if (isForeigner)
                    {
                        tbAssumeFeeType.Text = string.Empty;
                        tbAssumeFeeType.DvErrorProvider.SetError(tbAssumeFeeType, string.Empty);
                        lbAssumeFeeType.Text = string.Format("{0}：", MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType);
                        lbAssumeFeeType.Location = new Point { X = lbRmitNote.Location.X + lbRmitNote.Width - lbAssumeFeeType.Width, Y = lbAssumeFeeType.Location.Y };
                        cmbAssumeFeeType.Visible = true;
                        InitData();
                    }
                    lbIsOffLine.Visible = rbYes.Visible = rbNo.Visible = isForeigner;
                    lblIsImport.Visible = lbIsImport.Visible = cmbIsImport.Visible = e.AccountType != OverCountryPayeeAccountType.ForeignAccount;
                    opat = e.AccountType;
                }
                SetRegex();
            }
        }

        void CommandCenter_OnBankTypeChangedEventHandler(object sender, BankTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler), sender, e); }
            else
            {
                if (m_appType != e.AppType) return;
                if (e.Command != OperatorCommandType.BankTypeChanged) return;
                bankTypeBarOrFC = e.BankType;
                if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    #region
                    foreach (var item in this.flowLayoutPanel1.Controls)
                    {
                        if (item is Panel)
                        {
                            foreach (var ctl in ((Panel)item).Controls)
                            {
                                ((Control)ctl).Enabled = e.BankType == AgentTransferBankType.Other;
                            }
                        }
                    }
                    #endregion
                }
                else if (m_appType == AppliableFunctionType.UnitivePaymentFC)
                {
                    bool flag = e.BankType == AgentTransferBankType.Boc;
                    lbAssumeFeeType.Text = string.Format("{0}：", flag ? MultiLanguageConvertHelper.UnitivePaymentFC_Purpose : MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType);
                    lbAssumeFeeType.Location = new Point { X = lbRmitNote.Location.X + lbRmitNote.Width - lbAssumeFeeType.Width, Y = lbAssumeFeeType.Location.Y };
                    cmbAssumeFeeType.Visible = !flag;
                    banktype = e.BankType;
                    if (!flag) InitData();
                    else
                    {
                        tbAssumeFeeType.Text = string.Empty;
                        tbAssumeFeeType.DvErrorProvider.SetError(tbAssumeFeeType, string.Empty);
                    }
                }
                SetRegex();
            }
        }

        void CommandCenter_OnNoticeEventHandler(object sender, NoticeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler), sender, e); }
            else
            {
                if (e.Command == OperatorCommandType.Submit)
                {
                    if (e.Notice != null)
                    {
                        //if (cmbAdditionalComment.Items.Count > 9) return;
                        if (!cmbRemitNote.Items.Contains(e.Notice.Content))
                            cmbRemitNote.Items.Add(e.Notice.Content);
                    }
                    else if (e.NoticeList != null && e.NoticeList.Count > 0)
                    {
                        cmbRemitNote.Items.Clear();
                        if (!SystemSettings.Notices.ContainsKey(m_appType)) return;
                        foreach (var item in SystemSettings.Notices[m_appType])
                        {
                            if (string.IsNullOrEmpty(item.Content)) continue;
                            cmbRemitNote.Items.Add(item.Content);
                        }
                    }
                    else if (e.NoticeList != null && e.NoticeList.Count == 0 && cmbRemitNote.Items.Count > 0)
                    {
                        cmbRemitNote.Items.Clear();
                    }
                }
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(TransferGlobalOtherSelector), this);
                Init();
                InitData();
            }
        }

        private void InitData()
        {
            cmbAssumeFeeType.Items.Clear();
            cmbPayFeeType.Items.Clear();
            if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                LblAssumeFeeType.Visible = true;
                lblIsnoPayee.Visible = true;
            }

            foreach (var item in PrequisiteDataProvideNode.InitialProvide.AssumeFeeTypeList)
            {
                if (item == AssumeFeeType.Empty) continue;
                string value = EnumNameHelper<AssumeFeeType>.GetEnumDescription(item);
                cmbAssumeFeeType.Items.Add(value);
            }
            cmbAssumeFeeType.Tag = PrequisiteDataProvideNode.InitialProvide.AssumeFeeTypeList.FindAll(o => o != AssumeFeeType.Empty);
            foreach (var item in PrequisiteDataProvideNode.InitialProvide.PayFeeTypeList)
            {
                if (item == PayFeeType.Empty) continue;
                string value = EnumNameHelper<PayFeeType>.GetEnumDescription(item);
                cmbPayFeeType.Items.Add(value);
            }
            cmbPayFeeType.Tag = PrequisiteDataProvideNode.InitialProvide.PayFeeTypeList.FindAll(o => o != PayFeeType.Empty);

            if (cmbAssumeFeeType.Items.Count > 0) cmbAssumeFeeType.SelectedIndex = 0;
            if (cmbPayFeeType.Items.Count > 0) cmbPayFeeType.SelectedIndex = 0;
        }

        void CommandCenter_OnCashTypeChangedEventHandler(object sender, CashTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<CashTypeChangedEventArgs>(CommandCenter_OnCashTypeChangedEventHandler), sender, e); }
            else
            {
                if (m_appType != e.AppType) return;
                lbCashType1.Text = lbCashType2.Text = EnumNameHelper<CashType>.GetEnumDescription(e.CashType);
                m_Cash = e.CashType;
            }
        }

        void CommandCenter_OnTransferGlobalEventHandler(object sender, TransferGlobalEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<TransferGlobalEventArgs>(CommandCenter_OnTransferGlobalEventHandler), sender, e); }
            else
            {
                if (m_appType != e.OwnerType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                    SetItem(e.TransferGlobal);
                else if (e.Command == OperatorCommandType.Reset)
                    SetItem(null);
            }
        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBox).Text.Trim()))
            {
                ResultData rd = new ResultData { Result = true };
                rd = DataCheckCenter.CheckCash((sender as TextBox), (sender as TextBox).Text.Trim(), (sender as TextBoxCanValidate).DvLinkedLabel.Text.Substring(0, (sender as TextBoxCanValidate).DvLinkedLabel.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
                if (!rd.Result) return;
                (sender as TextBox).Text = DataConvertHelper.FormatCash((sender as TextBox).Text.Trim(), m_Cash == CashType.JPY);
            }
        }

        private AppliableFunctionType m_appType = AppliableFunctionType._Empty;
        /// <summary>
        /// 操作功能类型
        /// TransferOverCountry-跨境汇款,TransferForeignMoney-境内外币汇款
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_appType; }
            set
            {
                if (value == AppliableFunctionType.TransferOverCountry
                    || value == AppliableFunctionType.TransferForeignMoney
                    || value == AppliableFunctionType.TransferOverCountry4Bar
                    || value == AppliableFunctionType.TransferForeignMoney4Bar
                    || value == AppliableFunctionType.UnitivePaymentFC)
                {
                    m_appType = value;
                    Init();
                }
            }
        }

        private TransferGlobal m_TransferGlobal = null;
        /// <summary>
        /// 当前国际结算信息
        /// </summary>
        public TransferGlobal TransferGlobal
        {
            get { return m_TransferGlobal; }
            set { m_TransferGlobal = value; }
        }
        private UnitivePaymentForeignMoney m_UnitivePaymentForeignMoney = null;
        public UnitivePaymentForeignMoney _UnitivePaymentForeignMoney
        {
            get { return m_UnitivePaymentForeignMoney; }
            set { m_UnitivePaymentForeignMoney = value; }
        }
        /// <summary>
        /// 外币统一支付-收款人账户类型
        /// </summary>
        OverCountryPayeeAccountType opat = OverCountryPayeeAccountType.BocAccount;
        private CashType m_Cash = CashType.GBP;
        AgentTransferBankType banktype = AgentTransferBankType.Boc;

        public bool SaveRemitNote { get; set; }

        AgentTransferBankType bankTypeBarOrFC = AgentTransferBankType.Other;

        private void Init()
        {
            linkContent.Visible = (SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501;
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                #region
                pDealNote.Visible =
                lbIsOffLine.Visible = rbYes.Visible = rbNo.Visible = false;
                lblIsImport.Visible = lbIsImport.Visible = cmbIsImport.Visible =
                pPaymentProperty.Visible = lbPaymentPropertyType.Visible =
                lblPaymentType.Visible = lbPayType.Visible = cmbPayFeeType.Visible =
                lbAssumeFeeType.Visible = cmbAssumeFeeType.Visible = true;
                //cmbAssumeFeeType.DropDownStyle = ComboBoxStyle.Simple;
                lblPaymentPropertyType.Visible = true;
                lbAssumeFeeType.Text = string.Format("{0}：", opat == OverCountryPayeeAccountType.BocAccount ? MultiLanguageConvertHelper.UnitivePaymentFC_Purpose : MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType);
                lbAssumeFeeType.Location = new Point { X = lbRmitNote.Location.X + lbRmitNote.Width - lbAssumeFeeType.Width, Y = lbAssumeFeeType.Location.Y };
                cmbAssumeFeeType.Items.Clear();
                cmbAssumeFeeType.Text = string.Empty;
                cmbAssumeFeeType.Enabled = true;
                cmbAssumeFeeType.Visible = opat != OverCountryPayeeAccountType.BocAccount;

                cmbPaymentPropertyType.Items.Clear();
                foreach (var item in PrequisiteDataProvideNode.InitialProvide.PaymentPropertyTypeList)
                {
                    if (item == PaymentPropertyType.Empty) continue;
                    string value = EnumNameHelper<PaymentPropertyType>.GetEnumDescription(item);
                    cmbPaymentPropertyType.Items.Add(value);
                }
                cmbPaymentPropertyType.Tag = PrequisiteDataProvideNode.InitialProvide.PaymentPropertyTypeList.FindAll(o => o != PaymentPropertyType.Empty);
                if (cmbPaymentPropertyType.Items.Count > 0) cmbPaymentPropertyType.SelectedIndex = 0;

                cmbIsImport.Items.Clear();
                foreach (var item in PrequisiteDataProvideNode.InitialProvide.IsImportCancelAfterVerificationTypeList)
                {
                    if (item == IsImportCancelAfterVerificationType.Empty) continue;
                    string value = EnumNameHelper<IsImportCancelAfterVerificationType>.GetEnumDescription(item);
                    cmbIsImport.Items.Add(value);
                }
                cmbIsImport.Tag = PrequisiteDataProvideNode.InitialProvide.IsImportCancelAfterVerificationTypeList.FindAll(o => o != IsImportCancelAfterVerificationType.Empty);
                if (cmbIsImport.Items.Count > 0) cmbIsImport.SelectedIndex = 0;
                #endregion
            }
            else
            {
                #region
                p_Bar.Visible = m_appType == AppliableFunctionType.TransferForeignMoney4Bar;
                pPaymentProperty.Visible = m_appType == AppliableFunctionType.TransferForeignMoney || m_appType == AppliableFunctionType.TransferForeignMoney4Bar;
                pDealNote.Visible = m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferOverCountry4Bar;

                if (m_appType == AppliableFunctionType.TransferForeignMoney
                    || m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    cmbPaymentPropertyType.Items.Clear();
                    foreach (var item in PrequisiteDataProvideNode.InitialProvide.PaymentPropertyTypeList)
                    {
                        if (item == PaymentPropertyType.Empty) continue;
                        string value = EnumNameHelper<PaymentPropertyType>.GetEnumDescription(item);
                        cmbPaymentPropertyType.Items.Add(value);
                    }
                    cmbPaymentPropertyType.Tag = PrequisiteDataProvideNode.InitialProvide.PaymentPropertyTypeList.FindAll(o => o != PaymentPropertyType.Empty);
                    if (cmbPaymentPropertyType.Items.Count > 0) cmbPaymentPropertyType.SelectedIndex = 0;

                    if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                    {
                        cmbBarBusinessType.Items.Clear();
                        foreach (var item in PrequisiteDataProvideNode.InitialProvide.BarBusinessTypeList)
                        {
                            if (item == BarBusinessType.Empty) continue;
                            string str = EnumNameHelper<BarBusinessType>.GetEnumDescription(item);
                            cmbBarBusinessType.Items.Add(str);
                        }
                        cmbBarBusinessType.Tag = PrequisiteDataProvideNode.InitialProvide.BarBusinessTypeList.FindAll(o => o != BarBusinessType.Empty);

                        cmbBarApplyFlagType.Items.Clear();
                        foreach (var item in PrequisiteDataProvideNode.InitialProvide.BarApplyFlagTypeList)
                        {
                            if (item == BarApplyFlagType.Empty) continue;
                            string str = EnumNameHelper<BarApplyFlagType>.GetEnumDescription(item);
                            cmbBarApplyFlagType.Items.Add(str);
                        }
                        cmbBarApplyFlagType.Tag = PrequisiteDataProvideNode.InitialProvide.BarApplyFlagTypeList.FindAll(o => o != BarApplyFlagType.Empty);
                    }
                }
                if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                //|| m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    foreach (var item in this.flowLayoutPanel1.Controls)
                    {
                        if (item is TextBoxCanValidate)
                            ((TextBoxCanValidate)item).CharacterCasing = CharacterCasing.Upper;
                        else if (item is Panel)
                        {
                            foreach (var citem in ((Panel)item).Controls)
                            {
                                if (citem is TextBoxCanValidate)
                                    ((TextBoxCanValidate)citem).CharacterCasing = CharacterCasing.Upper;
                            }
                        }
                    }

                    cmbRemitNote.KeyPress += new KeyPressEventHandler(cmbRemitNote_KeyPress);
                }
                #endregion
            }
            cmbRemitNote.Items.Clear();
            if (SystemSettings.Notices.ContainsKey(m_appType))
            {
                foreach (var item in SystemSettings.Notices[m_appType])
                    if (!string.IsNullOrEmpty(item.Content))
                        cmbRemitNote.Items.Add(item.Content);
                cmbRemitNote.Tag = SystemSettings.Notices[m_appType].FindAll(o => !string.IsNullOrEmpty(o.Content));
            }
            cmbRemitNote.SelectedIndex = -1;
            SetRegex();
        }
        private void SetRegex()
        {
            tbDealSerialNoF.DvRegCode = "reg57";
            tbDealSerialNoF.DvMinLength = 6;
            tbDealSerialNoF.DvMaxLength = 6;
            tbDealSerialNoS.DvRegCode = "reg57";
            tbDealSerialNoS.DvMinLength = 6;
            tbDealSerialNoS.DvMaxLength = 6;
            tbDealSerialNoF.DvRequired =
            tbDealSerialNoS.DvRequired = false;
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                #region
                if (opat == OverCountryPayeeAccountType.ForeignAccount)
                {
                    #region
                    cmbRemitNote.DvRegCode = "reg108";
                    cmbRemitNote.DvMinLength = 0;
                    cmbRemitNote.DvMaxLength = 120;
                    cmbRemitNote.DvRequired = false;
                    tbContactNo.DvRegCode = "Predefined5";
                    tbContactNo.DvMinLength = 0;
                    tbContactNo.DvMaxLength = 20;
                    tbContactNo.DvRequired = false;
                    tbBillSerialNo.DvRegCode = "reg702";
                    tbBillSerialNo.DvMinLength = 0;
                    tbBillSerialNo.DvMaxLength = 50;
                    tbBillSerialNo.DvRequired = false;
                    tbSerialNos.DvRegCode = "Predefined5";
                    tbSerialNos.DvMinLength = 0;
                    tbSerialNos.DvMaxLength = 20;
                    tbSerialNos.DvRequired = false;
                    tbProposerName.DvRegCode = "reg540";
                    tbProposerName.DvMinLength = 1;
                    tbProposerName.DvMaxLength = 70;
                    tbProposerName.DvRequired = true;
                    tbTelephone.DvRegCode = "reg699";
                    tbTelephone.DvMinLength = 1;
                    tbTelephone.DvMaxLength = 15;
                    tbTelephone.DvRequired = true;
                    cmbPayFeeType.DvRequired = false;
                    cmbPaymentPropertyType.DvRequired = false;

                    tbDealNoteF.DvRegCode = tbDealNoteS.DvRegCode = "reg108";
                    tbDealNoteF.DvMinLength = tbDealNoteS.DvMinLength = 1;
                    tbDealNoteF.DvMaxLength = tbDealNoteS.DvMaxLength = 50;
                    tbDealNoteF.DvRequired = tbDealNoteS.DvRequired = false;
                    #endregion
                }
                else if (banktype == AgentTransferBankType.Boc)
                {
                    #region
                    cmbRemitNote.DvRegCode = "reg108";
                    cmbRemitNote.DvMinLength = 0;
                    cmbRemitNote.DvMaxLength = 120;
                    cmbRemitNote.DvRequired = false;
                    tbAssumeFeeType.DvRegCode = "reg108";
                    tbAssumeFeeType.DvMinLength = 0;
                    tbAssumeFeeType.DvMaxLength = 20;
                    tbAssumeFeeType.DvRequired = false;
                    cmbAssumeFeeType.Visible = false;
                    cmbAssumeFeeType.DvRequired = false;
                    tbContactNo.DvRegCode = "Predefined5";
                    tbContactNo.DvMinLength = 0;
                    tbContactNo.DvMaxLength = 20;
                    tbContactNo.DvRequired = false;
                    tbSerialNos.DvRegCode = "Predefined5";
                    tbSerialNos.DvMinLength = 0;
                    tbSerialNos.DvMaxLength = 20;
                    tbSerialNos.DvRequired = false;
                    tbBillSerialNo.DvRegCode = "reg720";
                    tbBillSerialNo.DvMinLength = 0;
                    tbBillSerialNo.DvMaxLength = 50;
                    tbBillSerialNo.DvRequired = false;
                    tbProposerName.DvRegCode = "reg540";
                    tbProposerName.DvMinLength = 1;
                    tbProposerName.DvMaxLength = 70;
                    tbProposerName.DvRequired = true;
                    tbTelephone.DvRegCode = "reg699";
                    tbTelephone.DvMinLength = 1;
                    tbTelephone.DvMaxLength = 15;
                    tbTelephone.DvRequired = true;
                    tbProposerName.DvRequired = true;
                    cmbPayFeeType.DvRequired = true;
                    cmbPaymentPropertyType.DvRequired = true;

                    tbDealNoteF.DvRegCode = tbDealNoteS.DvRegCode = null;
                    tbDealNoteF.DvMinLength = tbDealNoteS.DvMinLength = 0;
                    tbDealNoteF.DvMaxLength = tbDealNoteS.DvMaxLength = 0;
                    tbDealNoteF.DvRequired = tbDealNoteS.DvRequired = false;
                    #endregion
                }
                else if (banktype == AgentTransferBankType.Other)
                {
                    #region
                    cmbRemitNote.DvRegCode = "reg641";
                    cmbRemitNote.DvMinLength = 0;
                    cmbRemitNote.DvMaxLength = 120;
                    cmbRemitNote.DvRequired = false;
                    tbContactNo.DvRegCode = "Predefined5";
                    tbContactNo.DvMinLength = 0;
                    tbContactNo.DvMaxLength = 20;
                    tbContactNo.DvRequired = false;
                    tbBillSerialNo.DvRegCode = "Predefined5";
                    tbBillSerialNo.DvMinLength = 0;
                    tbBillSerialNo.DvMaxLength = 35;
                    tbBillSerialNo.DvRequired = false;
                    tbSerialNos.DvRegCode = "Predefined5";
                    tbSerialNos.DvMinLength = 0;
                    tbSerialNos.DvMaxLength = 40;
                    tbSerialNos.DvRequired = false;
                    tbProposerName.DvRegCode = "reg540";
                    tbProposerName.DvMinLength = 1;
                    tbProposerName.DvMaxLength = 70;
                    tbProposerName.DvRequired = true;
                    tbTelephone.DvRegCode = "reg699";
                    tbTelephone.DvMinLength = 1;
                    tbTelephone.DvMaxLength = 15;
                    tbTelephone.DvRequired =
                    cmbPayFeeType.DvRequired =
                    cmbPaymentPropertyType.DvRequired = true;
                    tbDealNoteF.DvRegCode = tbDealNoteS.DvRegCode = null;
                    tbDealNoteF.DvMinLength = tbDealNoteS.DvMinLength = 0;
                    tbDealNoteF.DvMaxLength = tbDealNoteS.DvMaxLength = 0;
                    tbDealNoteF.DvRequired = tbDealNoteS.DvRequired = false;
                    #endregion
                }
                #endregion
            }
            else //国结和柜台
            {
                #region
                if (m_appType == AppliableFunctionType.TransferOverCountry
                    || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                {
                    cmbRemitNote.DvRegCode = "reg702";
                    cmbRemitNote.DvMinLength = 0;
                    cmbRemitNote.DvMaxLength = 140;
                    cmbRemitNote.DvRequired = false;

                    tbDealNoteF.DvRegCode = tbDealNoteS.DvRegCode = "reg641";
                    tbDealNoteF.DvMinLength = tbDealNoteS.DvMinLength = 0;
                    tbDealNoteF.DvMaxLength = tbDealNoteS.DvMaxLength = m_appType == AppliableFunctionType.TransferOverCountry ? 100 : 50;
                    tbDealNoteF.DvRequired = tbDealNoteS.DvRequired = false;
                }
                else
                {
                    cmbRemitNote.DvRegCode = "reg667";
                    cmbRemitNote.DvMinLength = 0;
                    cmbRemitNote.DvMaxLength = m_appType == AppliableFunctionType.TransferForeignMoney4Bar ? 140 : 50;
                    cmbRemitNote.DvRequired = false;
                }
                tbContactNo.DvRegCode = "Predefined5";
                tbContactNo.DvMinLength = 0;
                tbContactNo.DvMaxLength = 20;
                tbContactNo.DvRequired = false;
                tbBillSerialNo.DvRegCode = "Predefined5";
                tbBillSerialNo.DvMinLength = 0;
                tbBillSerialNo.DvMaxLength = m_appType == AppliableFunctionType.TransferForeignMoney ? 20 : m_appType == AppliableFunctionType.TransferOverCountry ? 50 : 35;
                tbBillSerialNo.DvRequired = false;
                tbSerialNos.DvRegCode = "Predefined5";
                tbSerialNos.DvMinLength = 0;
                tbSerialNos.DvMaxLength = 20;
                tbSerialNos.DvRequired = false;
                tbProposerName.DvRegCode = "reg540";
                tbProposerName.DvMinLength = 1;
                tbProposerName.DvMaxLength = 20;
                tbProposerName.DvRequired = true;
                tbTelephone.DvRegCode = "reg699";
                tbTelephone.DvMinLength = 1;
                tbTelephone.DvMaxLength = 15;
                tbTelephone.DvRequired = true;
                cmbAssumeFeeType.DvRequired = true; cmbPayFeeType.DvRequired = true;
                if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                    cmbBarBusinessType.DvRequired = cmbBarBusinessType.DvRequired = true;
                #endregion
            }

        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            frmDealCodeQuery frm = new frmDealCodeQuery(m_appType);
            if (frm.ShowDialog() != DialogResult.OK) return;
            if ((sender as ThemedButton).Name == btnQueryF.Name)
            {
                tbDealSerialNoF.Text = frm.QueryResult.Code;
                tbDealSerialNoF.ManualValidate();
            }
            else if ((sender as ThemedButton).Name == btnQueryS.Name)
            {
                tbDealSerialNoS.Text = frm.QueryResult.Code;
                tbDealSerialNoS.ManualValidate();
            }

            if (null != frm)
                frm.Close();
        }

        public void GetItem()
        {
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                m_UnitivePaymentForeignMoney = new UnitivePaymentForeignMoney();
                m_UnitivePaymentForeignMoney.Addtion = cmbRemitNote.Text.Trim();
                m_UnitivePaymentForeignMoney.UnitivePaymentType = (cmbPayFeeType.Tag as List<PayFeeType>)[cmbPayFeeType.SelectedIndex];
                if (opat != OverCountryPayeeAccountType.ForeignAccount)
                    m_UnitivePaymentForeignMoney.PaymentNature = (cmbPaymentPropertyType.Tag as List<PaymentPropertyType>)[cmbPaymentPropertyType.SelectedIndex];
                if (opat != OverCountryPayeeAccountType.ForeignAccount)
                {
                    if (banktype == AgentTransferBankType.Boc) m_UnitivePaymentForeignMoney.Purpose = tbAssumeFeeType.Text.Trim();
                    else if (banktype == AgentTransferBankType.Other) m_UnitivePaymentForeignMoney.AssumeFeeType = cmbAssumeFeeType.SelectedIndex < 0 ? AssumeFeeType.Empty : (cmbAssumeFeeType.Tag as List<AssumeFeeType>)[cmbAssumeFeeType.SelectedIndex];
                }
                else m_UnitivePaymentForeignMoney.AssumeFeeType = cmbAssumeFeeType.SelectedIndex < 0 ? AssumeFeeType.Empty : (cmbAssumeFeeType.Tag as List<AssumeFeeType>)[cmbAssumeFeeType.SelectedIndex];
                m_UnitivePaymentForeignMoney.IsImportCancelAfterVerificationType = cmbIsImport.SelectedIndex < 0 ? IsImportCancelAfterVerificationType.Empty : (cmbIsImport.Tag as List<IsImportCancelAfterVerificationType>)[cmbIsImport.SelectedIndex];
                m_UnitivePaymentForeignMoney.TransactionCode1 = tbDealSerialNoF.Text.Trim();
                if (!string.IsNullOrEmpty(m_UnitivePaymentForeignMoney.TransactionCode1))
                {
                    m_UnitivePaymentForeignMoney.IPPSMoneyTypeAmount1 = tbAmountF.Text.Trim();
                    if (opat == OverCountryPayeeAccountType.ForeignAccount)
                        m_UnitivePaymentForeignMoney.TransactionAddtion1 = tbDealNoteF.Text.Trim();
                }
                m_UnitivePaymentForeignMoney.TransactionCode2 = tbDealSerialNoS.Text.Trim();
                if (!string.IsNullOrEmpty(m_UnitivePaymentForeignMoney.TransactionCode2))
                {
                    m_UnitivePaymentForeignMoney.IPPSMoneyTypeAmount2 = tbAmountS.Text.Trim();
                    if (opat == OverCountryPayeeAccountType.ForeignAccount)
                        m_UnitivePaymentForeignMoney.TransactionAddtion2 = tbDealNoteS.Text.Trim();
                }
                if (opat == OverCountryPayeeAccountType.ForeignAccount)
                    m_UnitivePaymentForeignMoney.IsPayOffLine = rbYes.Checked;
                m_UnitivePaymentForeignMoney.ContractNo = tbContactNo.Text.Trim();
                m_UnitivePaymentForeignMoney.InvoiceNo = tbBillSerialNo.Text.Trim();
                m_UnitivePaymentForeignMoney.BatchNoOrTNoOrSerialNo = tbSerialNos.Text.Trim();
                m_UnitivePaymentForeignMoney.ApplicantName = tbProposerName.Text.Trim();
                m_UnitivePaymentForeignMoney.Contactnumber = tbTelephone.Text.Trim();
                //if (opat != OverCountryPayeeAccountType.ForeignAccount && banktype == AgentTransferBankType.Boc)
                //    m_UnitivePaymentForeignMoney.Purpose = cmbAssumeFeeType.Text.Trim();
                SaveRemitNote = true;
            }
            else
            {
                m_TransferGlobal = new TransferGlobal();
                if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar && bankTypeBarOrFC == AgentTransferBankType.Boc) return;

                m_TransferGlobal.RemitNote = cmbRemitNote.Text.Trim();
                m_TransferGlobal.AssumeFeeType = (cmbAssumeFeeType.Tag as List<AssumeFeeType>)[cmbAssumeFeeType.SelectedIndex];
                m_TransferGlobal.PayFeeType = (cmbPayFeeType.Tag as List<PayFeeType>)[cmbPayFeeType.SelectedIndex];
                if (m_appType == AppliableFunctionType.TransferForeignMoney || m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                    m_TransferGlobal.PaymentPropertyType = (cmbPaymentPropertyType.Tag as List<PaymentPropertyType>)[cmbPaymentPropertyType.SelectedIndex];
                m_TransferGlobal.DealSerialNoF = tbDealSerialNoF.Text.Trim();
                if (!string.IsNullOrEmpty(m_TransferGlobal.DealSerialNoF))
                {
                    m_TransferGlobal.AmountF = tbAmountF.Text.Trim();
                    if (m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                        m_TransferGlobal.DealNoteF = tbDealNoteF.Text.Trim();
                }
                m_TransferGlobal.DealSerialNoS = tbDealSerialNoS.Text.Trim();
                if (!string.IsNullOrEmpty(m_TransferGlobal.DealSerialNoS))
                {
                    m_TransferGlobal.AmountS = tbAmountS.Text.Trim();
                    if (m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                        m_TransferGlobal.DealNoteS = tbDealNoteS.Text.Trim();
                }
                m_TransferGlobal.IsPayOffLine = rbYes.Checked;
                m_TransferGlobal.ContactNo = tbContactNo.Text.Trim();
                m_TransferGlobal.BillSerialNo = tbBillSerialNo.Text.Trim();
                m_TransferGlobal.BatchNoOrTNoOrSerialNo = tbSerialNos.Text.Trim();
                m_TransferGlobal.ProposerName = tbProposerName.Text.Trim();
                m_TransferGlobal.Telephone = tbTelephone.Text.Trim();
                SaveRemitNote = true;

                if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    m_TransferGlobal.BarBusinessType = cmbBarBusinessType.SelectedIndex < 0 ? BarBusinessType.Empty : (cmbBarBusinessType.Tag as List<BarBusinessType>)[cmbBarBusinessType.SelectedIndex];
                    m_TransferGlobal.BarApplyFlagType = cmbBarApplyFlagType.SelectedIndex < 0 ? BarApplyFlagType.Empty : (cmbBarApplyFlagType.Tag as List<BarApplyFlagType>)[cmbBarApplyFlagType.SelectedIndex];
                }
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                if (string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()) && string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                { MessageBoxPrime.Show(string.Format("{0} {1} {2} {3}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF, MultiLanguageConvertHelper.Information_Or, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); rd.Result = false; }
            }
            else
            {
                if (m_appType == AppliableFunctionType.TransferForeignMoney
                    || m_appType == AppliableFunctionType.TransferForeignMoney4Bar
                    || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                {
                    if (string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()) && string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                    { MessageBoxPrime.Show(string.Format("{0} {1} {2} {3}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF, MultiLanguageConvertHelper.Information_Or, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); rd.Result = false; }
                }
            }
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                if (!string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()))
                {
                    //金额校验
                    if (string.IsNullOrEmpty(tbAmountF.Text.Trim()))
                    { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_AmountF), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); rd.Result = false; }
                    else
                    {
                        rd.Result = rd.Result & DataCheckCenter.CheckCash(tbAmountF, tbAmountF.Text.Trim(), lbAmountF.Text.Substring(0, lbAmountF.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1).Result;
                        //if (!rd.Result) return rd.Result;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()))
                {
                    //金额校验
                    rd.Result = rd.Result & DataCheckCenter.CheckCash(tbAmountF, tbAmountF.Text.Trim(), lbAmountF.Text.Substring(0, lbAmountF.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1).Result;
                    //if (!rd.Result) return rd.Result;
                }
            }
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                if (!string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                {
                    //金额校验
                    if (string.IsNullOrEmpty(tbAmountS.Text.Trim()))
                    { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_AmountS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); rd.Result = false; }
                    else
                    {
                        rd.Result = rd.Result && DataCheckCenter.CheckCash(tbAmountS, tbAmountS.Text.Trim(), lbAmountS.Text.Substring(0, lbAmountS.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1).Result;
                        //if (!rd.Result) return rd.Result;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                {
                    //金额校验
                    if (string.IsNullOrEmpty(tbAmountS.Text.Trim()))
                    { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_AmountS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); rd.Result = false; }
                    else
                    {
                        rd.Result = rd.Result && DataCheckCenter.CheckCash(tbAmountS, tbAmountS.Text.Trim(), lbAmountS.Text.Substring(0, lbAmountS.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1).Result;
                        //if (!rd.Result) return rd.Result;
                    }
                }

            }
            #region
            //if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            //{
            //    #region
            //    if (opat == OverCountryPayeeAccountType.ForeignAccount)
            //    {
            //        #region
            //        if (!string.IsNullOrEmpty(cmbRemitNote.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckAddtionFCForeign(cmbRemitNote, cmbRemitNote.Text.Trim(), lbRmitNote.Text.Substring(0, lbRmitNote.Text.Length - 1), 120, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (cmbPayFeeType.SelectedIndex < 0)
            //        { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.TransferGlobal_PayFeeType), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        if (cmbPaymentPropertyType.SelectedIndex < 0)
            //        { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.TransferGlobal_PaymentPropertyType), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        if (string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()) && string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
            //        { MessageBoxPrime.Show(string.Format("{0} {1} {2} {3}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF, MultiLanguageConvertHelper.Information_Or, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        if (!string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckDealSerialNo(tbDealSerialNoF, tbDealSerialNoF.Text.Trim(), lbDealSerialNoF.Text.Substring(0, lbDealSerialNoF.Text.Length - 1), 6, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //            if (string.IsNullOrEmpty(tbAmountF.Text.Trim()))
            //            { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_AmountF), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //            else
            //            {
            //                rd = DataCheckCenter.CheckCash(tbAmountF, tbAmountF.Text.Trim(), lbAmountF.Text.Substring(0, lbAmountF.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //            if (string.IsNullOrEmpty(tbDealNoteF.Text.Trim()))
            //            { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_DealNoteF), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //            else
            //            {
            //                rd = DataCheckCenter.CheckAddtionFCForeign(tbDealNoteF, tbDealNoteF.Text.Trim(), lbDealNoteF.Text.Substring(0, lbDealNoteF.Text.Length - 1), 50, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //        }
            //        if (!string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckDealSerialNo(tbDealSerialNoS, tbDealSerialNoS.Text.Trim(), lbDealSerialNoS.Text.Substring(0, lbDealSerialNoS.Text.Length - 1), 6, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //            if (string.IsNullOrEmpty(tbAmountS.Text.Trim()))
            //            { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_AmountS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //            else
            //            {
            //                rd = DataCheckCenter.CheckCash(tbAmountS, tbAmountS.Text.Trim(), lbAmountS.Text.Substring(0, lbAmountS.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //            if (string.IsNullOrEmpty(tbDealNoteS.Text.Trim()))
            //            { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_DealNoteS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //            else
            //            {
            //                rd = DataCheckCenter.CheckAddtionFCForeign(tbDealNoteS, tbDealNoteS.Text.Trim(), lbDealNoteS.Text.Substring(0, lbDealNoteS.Text.Length - 1), 50, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //        }
            //        if (!string.IsNullOrEmpty(tbContactNo.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckLength(tbContactNo, tbContactNo.Text.Trim(), lbContactNo.Text.Substring(0, lbContactNo.Text.Length - 1), 20, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbBillSerialNo.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), 50, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbSerialNos.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckLength(tbSerialNos, tbSerialNos.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), 20, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        rd = DataCheckCenter.CheckProposerName(tbProposerName, tbProposerName.Text.Trim(), lbProposerName.Text.Substring(0, lbProposerName.Text.Length - 1), 70, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        rd = DataCheckCenter.CheckTelePhone(tbTelephone, tbTelephone.Text.Trim(), lbTelephone.Text.Substring(0, lbTelephone.Text.Length - 1), 15, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        #endregion
            //    }
            //    else if (banktype == AgentTransferBankType.Boc)
            //    {
            //        #region
            //        if (!string.IsNullOrEmpty(cmbRemitNote.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeAddtion(cmbRemitNote, cmbRemitNote.Text.Trim(), lbRmitNote.Text.Substring(0, lbRmitNote.Text.Length - 1), 120, true, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(cmbAssumeFeeType.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckAddtionFCForeign(cmbAssumeFeeType, cmbAssumeFeeType.Text.Trim(), lbAssumeFeeType.Text.Substring(0, lbAssumeFeeType.Text.Length - 1), 400, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (cmbPayFeeType.SelectedIndex < 0)
            //        { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.TransferGlobal_PayFeeType), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        if (cmbPaymentPropertyType.SelectedIndex < 0)
            //        { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.TransferGlobal_PaymentPropertyType), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        if (string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()) && string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
            //        { MessageBoxPrime.Show(string.Format("{0} {1} {2} {3}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF, MultiLanguageConvertHelper.Information_Or, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        if (!string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckDealSerialNo(tbDealSerialNoF, tbDealSerialNoF.Text.Trim(), lbDealSerialNoF.Text.Substring(0, lbDealSerialNoF.Text.Length - 1), 6, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //            if (string.IsNullOrEmpty(tbAmountF.Text.Trim()))
            //            { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_AmountF), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //            else
            //            {
            //                rd = DataCheckCenter.CheckCash(tbAmountF, tbAmountF.Text.Trim(), lbAmountF.Text.Substring(0, lbAmountF.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //        }
            //        if (!string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckDealSerialNo(tbDealSerialNoS, tbDealSerialNoS.Text.Trim(), lbDealSerialNoS.Text.Substring(0, lbDealSerialNoS.Text.Length - 1), 6, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //            if (string.IsNullOrEmpty(tbAmountS.Text.Trim()))
            //            { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_AmountS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //            else
            //            {
            //                rd = DataCheckCenter.CheckCash(tbAmountS, tbAmountS.Text.Trim(), lbAmountS.Text.Substring(0, lbAmountS.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //        }
            //        if (!string.IsNullOrEmpty(tbContactNo.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckLength(tbContactNo, tbContactNo.Text.Trim(), lbContactNo.Text.Substring(0, lbContactNo.Text.Length - 1), 20, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbSerialNos.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckLength(tbSerialNos, tbSerialNos.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), 20, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbBillSerialNo.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckBillSerialNoSF(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), 50, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        rd = DataCheckCenter.CheckProposerName(tbProposerName, tbProposerName.Text.Trim(), lbProposerName.Text.Substring(0, lbProposerName.Text.Length - 1), 70, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        rd = DataCheckCenter.CheckTelePhone(tbTelephone, tbTelephone.Text.Trim(), lbTelephone.Text.Substring(0, lbTelephone.Text.Length - 1), 15, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        #endregion
            //    }
            //    else if (banktype == AgentTransferBankType.Other)
            //    {
            //        #region
            //        if (!string.IsNullOrEmpty(cmbRemitNote.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeAddtion(cmbRemitNote, cmbRemitNote.Text.Trim(), lbRmitNote.Text.Substring(0, lbRmitNote.Text.Length - 1), 120, false, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (cmbPayFeeType.SelectedIndex < 0)
            //        { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.TransferGlobal_PayFeeType), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        if (cmbPaymentPropertyType.SelectedIndex < 0)
            //        { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.TransferGlobal_PaymentPropertyType), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        if (string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()) && string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
            //        { MessageBoxPrime.Show(string.Format("{0} {1} {2} {3}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF, MultiLanguageConvertHelper.Information_Or, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        if (!string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckDealSerialNo(tbDealSerialNoF, tbDealSerialNoF.Text.Trim(), lbDealSerialNoF.Text.Substring(0, lbDealSerialNoF.Text.Length - 1), 6, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //            if (string.IsNullOrEmpty(tbAmountF.Text.Trim()))
            //            { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_AmountF), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //            else
            //            {
            //                rd = DataCheckCenter.CheckCash(tbAmountF, tbAmountF.Text.Trim(), lbAmountF.Text.Substring(0, lbAmountF.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //        }
            //        if (!string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckDealSerialNo(tbDealSerialNoS, tbDealSerialNoS.Text.Trim(), lbDealSerialNoS.Text.Substring(0, lbDealSerialNoS.Text.Length - 1), 6, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //            if (string.IsNullOrEmpty(tbAmountS.Text.Trim()))
            //            { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_AmountS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //            else
            //            {
            //                rd = DataCheckCenter.CheckCash(tbAmountS, tbAmountS.Text.Trim(), lbAmountS.Text.Substring(0, lbAmountS.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //        }
            //        if (!string.IsNullOrEmpty(tbContactNo.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckLength(tbContactNo, tbContactNo.Text.Trim(), lbContactNo.Text.Substring(0, lbContactNo.Text.Length - 1), 20, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbBillSerialNo.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckLength(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), 35, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbSerialNos.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckLength(tbSerialNos, tbSerialNos.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), 40, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        rd = DataCheckCenter.CheckProposerName(tbProposerName, tbProposerName.Text.Trim(), lbProposerName.Text.Substring(0, lbProposerName.Text.Length - 1), 70, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        rd = DataCheckCenter.CheckTelePhone(tbTelephone, tbTelephone.Text.Trim(), lbTelephone.Text.Substring(0, lbTelephone.Text.Length - 1), 15, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        #endregion
            //    }
            //    #endregion
            //}
            //else //国结和柜台
            //{
            //    #region
            //    if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar && bankTypeBarOrFC == AgentTransferBankType.Boc) return true;
            //    if (!string.IsNullOrEmpty(cmbRemitNote.Text))
            //    {
            //        if (m_appType == AppliableFunctionType.TransferOverCountry
            //            || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(cmbRemitNote, cmbRemitNote.Text.Trim(), lbRmitNote.Text.Substring(0, lbRmitNote.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        else
            //        {
            //            rd = DataCheckCenter.CheckAddtion(cmbRemitNote, cmbRemitNote.Text.Trim(), lbRmitNote.Text.Substring(0, lbRmitNote.Text.Length - 1), m_appType == AppliableFunctionType.TransferForeignMoney4Bar ? 140 : 50, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //    }
            //    if (cmbAssumeFeeType.SelectedIndex < 0)
            //    { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //    if (cmbPayFeeType.SelectedIndex < 0)
            //    { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.TransferGlobal_PayFeeType), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //    if (m_appType == AppliableFunctionType.TransferForeignMoney
            //        || m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            //    {
            //        if (cmbPaymentPropertyType.SelectedIndex < 0)
            //        { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.TransferGlobal_PaymentPropertyType), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        if (string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()) && string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
            //        { MessageBoxPrime.Show(string.Format("{0} {1} {2} {3}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF, MultiLanguageConvertHelper.Information_Or, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //    }
            //    if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            //    {
            //        if (string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()) && string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
            //        { MessageBoxPrime.Show(string.Format("{0} {1} {2} {3}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF, MultiLanguageConvertHelper.Information_Or, MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //    }
            //    if (!string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()))
            //    {
            //        rd = DataCheckCenter.CheckDealSerialNo(tbDealSerialNoF, tbDealSerialNoF.Text.Trim(), lbDealSerialNoF.Text.Substring(0, lbDealSerialNoF.Text.Length - 1), 6, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        if (string.IsNullOrEmpty(tbAmountF.Text.Trim()))
            //        { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_AmountF), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        else
            //        {
            //            rd = DataCheckCenter.CheckCash(tbAmountF, tbAmountF.Text.Trim(), lbAmountF.Text.Substring(0, lbAmountF.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (m_appType == AppliableFunctionType.TransferOverCountry
            //            || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            //        {
            //            if (!string.IsNullOrEmpty(tbDealNoteF.Text.Trim()))
            //            {
            //                rd = DataCheckCenter.CheckAddtionExIAOrUP(tbDealNoteF, tbDealNoteF.Text.Trim(), lbDealNoteF.Text.Substring(0, lbDealNoteF.Text.Length - 1), m_appType == AppliableFunctionType.TransferOverCountry ? 100 : 50, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
            //    {
            //        rd = DataCheckCenter.CheckDealSerialNo(tbDealSerialNoS, tbDealSerialNoS.Text.Trim(), lbDealSerialNoS.Text.Substring(0, lbDealSerialNoS.Text.Length - 1), 6, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        if (string.IsNullOrEmpty(tbAmountS.Text.Trim()))
            //        { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_AmountS), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        else
            //        {
            //            rd = DataCheckCenter.CheckCash(tbAmountS, tbAmountS.Text.Trim(), lbAmountS.Text.Substring(0, lbAmountS.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (m_appType == AppliableFunctionType.TransferOverCountry
            //            || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            //        {
            //            if (!string.IsNullOrEmpty(tbDealNoteS.Text.Trim()))
            //            {
            //                rd = DataCheckCenter.CheckAddtionExIAOrUP(tbDealNoteS, tbDealNoteS.Text.Trim(), lbDealNoteS.Text.Substring(0, lbDealNoteS.Text.Length - 1), m_appType == AppliableFunctionType.TransferOverCountry ? 100 : 50, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //        }
            //    }
            //    if (m_appType != AppliableFunctionType.TransferOverCountry4Bar
            //        && m_appType != AppliableFunctionType.TransferForeignMoney4Bar)
            //    {
            //        //if (rbYes.Checked)  //不需要判断
            //        //{
            //        //    if (!string.IsNullOrEmpty(tbContactNo.Text.Trim()))
            //        //    { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_ContactNo), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        //    if (!string.IsNullOrEmpty(tbBillSerialNo.Text.Trim()))
            //        //    { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_BillSerialNo), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        //    if (!string.IsNullOrEmpty(tbSerialNos.Text.Trim()))
            //        //    { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_BatchNoOrTNoOrSerialNo), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        //}
            //    }
            //    if (!string.IsNullOrEmpty(tbContactNo.Text.Trim()))
            //    {
            //        rd = DataCheckCenter.CheckSerialNoEx(tbContactNo, tbContactNo.Text.Trim(), lbContactNo.Text.Substring(0, lbContactNo.Text.Length - 1), 20, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //    if (!string.IsNullOrEmpty(tbBillSerialNo.Text.Trim()))
            //    {
            //        rd = DataCheckCenter.CheckSerialNoEx(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), m_appType == AppliableFunctionType.TransferForeignMoney ? 20 : m_appType == AppliableFunctionType.TransferOverCountry ? 50 : 35, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //    if (!string.IsNullOrEmpty(tbSerialNos.Text.Trim()))
            //    {
            //        rd = DataCheckCenter.CheckSerialNoEx(tbSerialNos, tbSerialNos.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), 20, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //    rd = DataCheckCenter.CheckProposerName(tbProposerName, tbProposerName.Text.Trim(), lbProposerName.Text.Substring(0, lbProposerName.Text.Length - 1), 20, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //    rd = DataCheckCenter.CheckTelePhone(tbTelephone, tbTelephone.Text.Trim(), lbTelephone.Text.Substring(0, lbTelephone.Text.Length - 1), 15, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //    if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            //    {
            //        if (cmbBarBusinessType.SelectedIndex < 0)
            //        { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.DesignMain_Please_Selection, label2.Text.Substring(0, label2.Text.Length - 1)), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        if (cmbBarApplyFlagType.SelectedIndex < 0)
            //        { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.DesignMain_Please_Selection, label1.Text.Substring(0, label1.Text.Length - 1)), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //    }
            //    #endregion
            //}
            #endregion
            return rd.Result;
        }

        private void SetItem(object item)
        {
            if (item == null)
            {
                cmbRemitNote.SelectedIndex = -1;
                if (cmbAssumeFeeType.Items.Count > 0) cmbAssumeFeeType.SelectedIndex = 0;
                if (cmbPayFeeType.Items.Count > 0) cmbPayFeeType.SelectedIndex = 0;
                if (cmbPaymentPropertyType.Items.Count > 0) cmbPaymentPropertyType.SelectedIndex = 0;
                cmbRemitNote.Text =
                tbAssumeFeeType.Text =
                tbDealSerialNoF.Text =
                tbDealSerialNoS.Text =
                tbDealNoteF.Text =
                tbDealNoteS.Text =
                tbAmountF.Text =
                tbAmountS.Text =
                tbContactNo.Text =
                tbBillSerialNo.Text = string.Empty;
                if (m_appType != AppliableFunctionType.TransferForeignMoney4Bar && m_appType != AppliableFunctionType.TransferOverCountry4Bar)
                    tbProposerName.Text = tbTelephone.Text =
                    tbSerialNos.Text = string.Empty;

                rbNo.Checked = true;
                rbYes.Checked = !rbNo.Checked;

                if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    cmbBarBusinessType.SelectedIndex = cmbBarApplyFlagType.SelectedIndex = -1;
                    cmbBarApplyFlagType.Text = cmbBarBusinessType.Text = string.Empty;
                }
                if (m_appType == AppliableFunctionType.UnitivePaymentFC)
                {
                    tbTelephone.Text = cmbAssumeFeeType.Text = string.Empty;
                    if (cmbIsImport.Items.Count > 0) cmbIsImport.SelectedIndex = 0;
                    else cmbIsImport.SelectedIndex = -1;
                }
            }
            else
            {
                if (m_appType == AppliableFunctionType.UnitivePaymentFC)
                {
                    UnitivePaymentForeignMoney items = item as UnitivePaymentForeignMoney;
                    if (items.PayeeAccountType == OverCountryPayeeAccountType.ForeignAccount)
                    {
                        cmbAssumeFeeType.SelectedIndex = (cmbAssumeFeeType.Tag as List<AssumeFeeType>).FindIndex(o => o == items.AssumeFeeType);
                        cmbRemitNote.Text = items.Addtion;
                    }
                    else
                    {
                        if (items.PayeeAccountType == OverCountryPayeeAccountType.BocAccount) tbAssumeFeeType.Text = items.Purpose;
                        else cmbAssumeFeeType.SelectedIndex = (cmbAssumeFeeType.Tag as List<AssumeFeeType>).FindIndex(o => o == items.AssumeFeeType);
                    }
                    cmbPayFeeType.SelectedIndex = cmbPayFeeType.Tag == null ? -1 : (cmbPayFeeType.Tag as List<PayFeeType>).FindIndex(o => o == items.UnitivePaymentType);
                    if (items.PayeeAccountType != OverCountryPayeeAccountType.ForeignAccount)
                        cmbPaymentPropertyType.SelectedIndex = cmbPaymentPropertyType.Tag == null ? -1 : (cmbPaymentPropertyType.Tag as List<PaymentPropertyType>).FindIndex(o => o == items.PaymentNature);
                    cmbRemitNote.Text = items.Addtion;
                    tbDealSerialNoF.Text = items.TransactionCode1;
                    tbDealSerialNoS.Text = items.TransactionCode2;
                    if (items.PayeeAccountType == OverCountryPayeeAccountType.ForeignAccount)
                    {
                        tbDealNoteF.Text = items.TransactionAddtion1;
                        tbDealNoteS.Text = items.TransactionAddtion2;
                    }
                    tbAmountF.Text = items.IPPSMoneyTypeAmount1;
                    tbAmountS.Text = items.IPPSMoneyTypeAmount2;
                    tbContactNo.Text = items.ContractNo;
                    tbBillSerialNo.Text = items.InvoiceNo;
                    tbProposerName.Text = items.ApplicantName;
                    tbTelephone.Text = items.Contactnumber;
                    tbSerialNos.Text = items.BatchNoOrTNoOrSerialNo;
                    rbYes.Checked = items.IsPayOffLine;
                    rbNo.Checked = !rbYes.Checked;
                    if (items.PayeeAccountType == OverCountryPayeeAccountType.BocAccount)
                        tbAssumeFeeType.Text = items.Purpose;
                }
                else
                {
                    TransferGlobal items = item as TransferGlobal;
                    cmbRemitNote.SelectedIndex = cmbRemitNote.Tag == null ? -1 : (cmbRemitNote.Tag as List<NoticeInfo>).FindIndex(o => o.Content.Equals(items.RemitNote));
                    cmbAssumeFeeType.SelectedIndex = cmbAssumeFeeType.Tag == null ? -1 : (cmbAssumeFeeType.Tag as List<AssumeFeeType>).FindIndex(o => o == items.AssumeFeeType);
                    cmbPayFeeType.SelectedIndex = cmbPayFeeType.Tag == null ? -1 : (cmbPayFeeType.Tag as List<PayFeeType>).FindIndex(o => o == items.PayFeeType);
                    cmbPaymentPropertyType.SelectedIndex = cmbPaymentPropertyType.Tag == null ? -1 : (cmbPaymentPropertyType.Tag as List<PaymentPropertyType>).FindIndex(o => o == items.PaymentPropertyType);
                    cmbRemitNote.Text = items.RemitNote;
                    tbDealSerialNoF.Text = items.DealSerialNoF;
                    tbDealSerialNoS.Text = items.DealSerialNoS;
                    tbDealNoteF.Text = items.DealNoteF;
                    tbDealNoteS.Text = items.DealNoteS;
                    tbAmountF.Text = items.AmountFString;
                    tbAmountS.Text = items.AmountSString;
                    tbContactNo.Text = items.ContactNo;
                    tbBillSerialNo.Text = items.BillSerialNo;
                    tbProposerName.Text = items.ProposerName;
                    tbTelephone.Text = items.Telephone;
                    tbSerialNos.Text = items.BatchNoOrTNoOrSerialNo;
                    rbYes.Checked = items.IsPayOffLine;
                    rbNo.Checked = !rbYes.Checked;

                    if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                    {
                        cmbBarBusinessType.SelectedIndex = (cmbBarBusinessType.Tag as List<BarBusinessType>).FindIndex(o => o == items.BarBusinessType);
                        cmbBarApplyFlagType.SelectedIndex = (cmbBarApplyFlagType.Tag as List<BarApplyFlagType>).FindIndex(o => o == items.BarApplyFlagType);
                    }
                }

            }

        }

        private void cmbRemitNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (m_appType != AppliableFunctionType.TransferOverCountry4Bar) return;
            if ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)
            {
                e.KeyChar = (char)((int)e.KeyChar - 32);
            }
        }

        private void tbAmountF_TextChanged(object sender, EventArgs e)
        {
            lbAmountDescF.Text = DataConvertHelper.ConvertA2CN(tbAmountF.Text.Trim(), 15, m_Cash == CashType.Empty ? CashType.CNY : m_Cash);
        }

        private void tbAmountS_TextChanged(object sender, EventArgs e)
        {
            lbAmountDescS.Text = DataConvertHelper.ConvertA2CN(tbAmountS.Text.Trim(), 15, m_Cash == CashType.Empty ? CashType.CNY : m_Cash);
        }

        private void linkConent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModuleWorkSpaceLoader.BroadcastApplicationBringToFront("BOC_BATCH_TOOL_SETTINGS", FunctionInSettingType.AddtionMg, m_appType);
        }

    }
}
