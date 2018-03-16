using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
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

            CommandCenter.Instance.OnTransferGlobalEventHandler += new EventHandler<TransferGlobalEventArgs>(CommandCenter_OnTransferGlobalEventHandler);
            CommandCenter.Instance.OnCashTypeChangedEventHandler += new EventHandler<CashTypeChangedEventArgs>(CommandCenter_OnCashTypeChangedEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnNoticeEventHandler += new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler);
            CommandCenter.Instance.OnBankTypeChangedEventHandler += new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler);
            CommandCenter.Instance.OnOverCountryPayeeAccountTypeEventHandler += new EventHandler<OverCountryPayeeAccountTypeEventArgs>(CommandCenter_OnOverCountryPayeeAccountTypeEventHandler);
            CommandCenter.Instance.OnUnitivePaymentFCEventHandler += new EventHandler<UnitivePaymentFCEventArgs>(CommandCenter_OnUnitivePaymentFCEventHandler);
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
            if (flag)
                tbAmountS.Text =
                tbDealNoteS.Text = string.Empty;
        }

        void tbDealSerialNoF_TextChanged(object sender, EventArgs e)
        {
            bool flag = string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim());
            tbAmountF.ReadOnly =
            tbDealNoteF.ReadOnly = flag;
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
                    if (isForeigner)
                        lbAssumeFeeType.Visible = cmbAssumeFeeType.Visible = false;
                    lbIsOffLine.Visible = rbYes.Visible = rbNo.Visible = isForeigner;
                    lblIsImport.Visible = lbIsImport.Visible = cmbIsImport.Visible = e.AccountType != OverCountryPayeeAccountType.ForeignAccount;
                    opat = e.AccountType;
                }
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
                    lbAssumeFeeType.Visible = cmbAssumeFeeType.Visible = e.BankType == AgentTransferBankType.Boc;
                    banktype = e.BankType;
                }
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
                        if (!SystemSettings.Instance.Notices.ContainsKey(m_appType)) return;
                        foreach (var item in SystemSettings.Instance.Notices[m_appType])
                        {
                            if (string.IsNullOrEmpty(item.Content)) continue;
                            cmbRemitNote.Items.Add(item.Content);
                        }
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

            if (m_appType != AppliableFunctionType.UnitivePaymentFC)
            {
                foreach (var item in PrequisiteDataProvideNode.InitialProvide.AssumeFeeTypeList)
                {
                    if (item == AssumeFeeType.Empty) continue;
                    string value = EnumNameHelper<AssumeFeeType>.GetEnumDescription(item);
                    cmbAssumeFeeType.Items.Add(value);
                }
                cmbAssumeFeeType.Tag = PrequisiteDataProvideNode.InitialProvide.AssumeFeeTypeList.FindAll(o => o != AssumeFeeType.Empty);
            }
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
                (sender as TextBox).Text = DataConvertHelper.Instance.FormatCash((sender as TextBox).Text.Trim(), m_Cash == CashType.JPY);
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
        private CashType m_Cash = CashType.Empty;
        AgentTransferBankType banktype = AgentTransferBankType.Boc;

        public bool SaveRemitNote { get; set; }

        AgentTransferBankType bankTypeBarOrFC = AgentTransferBankType.Other;

        private void Init()
        {
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                #region
                pDealNote.Visible =
                lbIsOffLine.Visible = rbYes.Visible = rbNo.Visible = false;
                lblIsImport.Visible = lbIsImport.Visible = cmbIsImport.Visible =
                pPaymentProperty.Visible = lbPaymentPropertyType.Visible =
                lblPaymentType.Visible = lbPayType.Visible = cmbPayFeeType.Visible =
                lbAssumeFeeType.Visible = cmbAssumeFeeType.Visible = true;
                cmbAssumeFeeType.DropDownStyle = ComboBoxStyle.Simple;
                lblPaymentPropertyType.Visible = true;
                lbAssumeFeeType.Text = string.Format("用途：");
                lbAssumeFeeType.Location = new Point { X = lbRmitNote.Location.X + lbRmitNote.Width - lbAssumeFeeType.Width, Y = lbAssumeFeeType.Location.Y };
                cmbAssumeFeeType.Items.Clear();
                cmbAssumeFeeType.Text = string.Empty;
                cmbAssumeFeeType.Enabled = true;
                cmbAssumeFeeType.DropDownStyle = ComboBoxStyle.Simple;

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
                        if (item is BOC_BATCH_TOOL.Controls.TextBoxCanValidate)
                            ((BOC_BATCH_TOOL.Controls.TextBoxCanValidate)item).CharacterCasing = CharacterCasing.Upper;
                        else if (item is Panel)
                        {
                            foreach (var citem in ((Panel)item).Controls)
                            {
                                if (citem is BOC_BATCH_TOOL.Controls.TextBoxCanValidate)
                                    ((BOC_BATCH_TOOL.Controls.TextBoxCanValidate)citem).CharacterCasing = CharacterCasing.Upper;
                            }
                        }
                    }

                    cmbRemitNote.KeyPress += new KeyPressEventHandler(cmbRemitNote_KeyPress);
                }
                #endregion
            }
            cmbRemitNote.Items.Clear();
            if (SystemSettings.Instance.Notices.ContainsKey(m_appType))
            {
                foreach (var item in SystemSettings.Instance.Notices[m_appType])
                    if (!string.IsNullOrEmpty(item.Content))
                        cmbRemitNote.Items.Add(item.Content);
                cmbRemitNote.Tag = SystemSettings.Instance.Notices[m_appType].FindAll(o => !string.IsNullOrEmpty(o.Content));
            }
            cmbRemitNote.SelectedIndex = -1;

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            frmDealCodeQuery frm = new frmDealCodeQuery(m_appType);
            if (frm.ShowDialog() != DialogResult.OK) return;
            if ((sender as BOC_BATCH_TOOL.Controls.ThemedButton).Name == btnQueryF.Name)
            {
                tbDealSerialNoF.Text = frm.QueryResult.Code;
            }
            else if ((sender as BOC_BATCH_TOOL.Controls.ThemedButton).Name == btnQueryS.Name)
            {
                tbDealSerialNoS.Text = frm.QueryResult.Code;
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
                if (opat != OverCountryPayeeAccountType.ForeignAccount && banktype == AgentTransferBankType.Boc)
                    m_UnitivePaymentForeignMoney.Purpose = cmbAssumeFeeType.Text.Trim();
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
                if (opat != OverCountryPayeeAccountType.ForeignAccount && banktype == AgentTransferBankType.Boc)
                    m_UnitivePaymentForeignMoney.Purpose = cmbAssumeFeeType.Text.Trim();
                SaveRemitNote = chbSave.Checked;
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
                SaveRemitNote = chbSave.Checked;

                if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    m_TransferGlobal.BarBusinessType = cmbBarBusinessType.SelectedIndex < 0 ? BarBusinessType.Empty : (cmbBarBusinessType.Tag as List<BarBusinessType>)[cmbBarBusinessType.SelectedIndex];
                    m_TransferGlobal.BarApplyFlagType = cmbBarApplyFlagType.SelectedIndex < 0 ? BarApplyFlagType.Empty : (cmbBarApplyFlagType.Tag as List<BarApplyFlagType>)[cmbBarApplyFlagType.SelectedIndex];
                }
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData();
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                #region
                if (opat == OverCountryPayeeAccountType.ForeignAccount)
                {
                    #region
                    if (!string.IsNullOrEmpty(cmbRemitNote.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckAddtionFCForeign(cmbRemitNote, cmbRemitNote.Text.Trim(), lbRmitNote.Text.Substring(0, lbRmitNote.Text.Length - 1), 120, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    if (cmbPayFeeType.SelectedIndex < 0)
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    if (cmbPaymentPropertyType.SelectedIndex < 0)
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentPropertyType), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    if (string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()) && string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1} {2} {3}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF, MultiLanguageConvertHelper.Instance.Information_Or, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    if (!string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckDealSerialNo(tbDealSerialNoF, tbDealSerialNoF.Text.Trim(), lbDealSerialNoF.Text.Substring(0, lbDealSerialNoF.Text.Length - 1), 6, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                        if (string.IsNullOrEmpty(tbAmountF.Text.Trim()))
                        { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                        else
                        {
                            rd = DataCheckCenter.Instance.CheckCash(tbAmountF, tbAmountF.Text.Trim(), lbAmountF.Text.Substring(0, lbAmountF.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
                            if (!rd.Result) return rd.Result;
                        }
                        if (string.IsNullOrEmpty(tbDealNoteF.Text.Trim()))
                        { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteF), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                        else
                        {
                            rd = DataCheckCenter.Instance.CheckAddtionFCForeign(tbDealNoteF, tbDealNoteF.Text.Trim(), lbDealNoteF.Text.Substring(0, lbDealNoteF.Text.Length - 1), 50, this.errorProvider1);
                            if (!rd.Result) return rd.Result;
                        }
                    }
                    if (!string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckDealSerialNo(tbDealSerialNoS, tbDealSerialNoS.Text.Trim(), lbDealSerialNoS.Text.Substring(0, lbDealSerialNoS.Text.Length - 1), 6, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                        if (string.IsNullOrEmpty(tbAmountS.Text.Trim()))
                        { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                        else
                        {
                            rd = DataCheckCenter.Instance.CheckCash(tbAmountS, tbAmountS.Text.Trim(), lbAmountS.Text.Substring(0, lbAmountS.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
                            if (!rd.Result) return rd.Result;
                        }
                        if (string.IsNullOrEmpty(tbDealNoteS.Text.Trim()))
                        { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteS), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                        else
                        {
                            rd = DataCheckCenter.Instance.CheckAddtionFCForeign(tbDealNoteS, tbDealNoteS.Text.Trim(), lbDealNoteS.Text.Substring(0, lbDealNoteS.Text.Length - 1), 50, this.errorProvider1);
                            if (!rd.Result) return rd.Result;
                        }
                    }
                    if (!string.IsNullOrEmpty(tbContactNo.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckLength(tbContactNo, tbContactNo.Text.Trim(), lbContactNo.Text.Substring(0, lbContactNo.Text.Length - 1), 20, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    if (!string.IsNullOrEmpty(tbBillSerialNo.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), 50, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    if (!string.IsNullOrEmpty(tbSerialNos.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckLength(tbSerialNos, tbSerialNos.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), 20, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    rd = DataCheckCenter.Instance.CheckProposerName(tbProposerName, tbProposerName.Text.Trim(), lbProposerName.Text.Substring(0, lbProposerName.Text.Length - 1), 70, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                    rd = DataCheckCenter.Instance.CheckTelePhone(tbTelephone, tbTelephone.Text.Trim(), lbTelephone.Text.Substring(0, lbTelephone.Text.Length - 1), 15, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                    #endregion
                }
                else if (banktype == AgentTransferBankType.Boc)
                {
                    #region
                    if (!string.IsNullOrEmpty(cmbRemitNote.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeAddtion(cmbRemitNote, cmbRemitNote.Text.Trim(), lbRmitNote.Text.Substring(0, lbRmitNote.Text.Length - 1), 120, true, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    if (!string.IsNullOrEmpty(cmbAssumeFeeType.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckAddtionFCForeign(cmbAssumeFeeType, cmbAssumeFeeType.Text.Trim(), lbAssumeFeeType.Text.Substring(0, lbAssumeFeeType.Text.Length - 1), 400, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    if (cmbPayFeeType.SelectedIndex < 0)
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    if (cmbPaymentPropertyType.SelectedIndex < 0)
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentPropertyType), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    if (string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()) && string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1} {2} {3}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF, MultiLanguageConvertHelper.Instance.Information_Or, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    if (!string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckDealSerialNo(tbDealSerialNoF, tbDealSerialNoF.Text.Trim(), lbDealSerialNoF.Text.Substring(0, lbDealSerialNoF.Text.Length - 1), 6, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                        if (string.IsNullOrEmpty(tbAmountF.Text.Trim()))
                        { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                        else
                        {
                            rd = DataCheckCenter.Instance.CheckCash(tbAmountF, tbAmountF.Text.Trim(), lbAmountF.Text.Substring(0, lbAmountF.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
                            if (!rd.Result) return rd.Result;
                        }
                    }
                    if (!string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckDealSerialNo(tbDealSerialNoS, tbDealSerialNoS.Text.Trim(), lbDealSerialNoS.Text.Substring(0, lbDealSerialNoS.Text.Length - 1), 6, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                        if (string.IsNullOrEmpty(tbAmountS.Text.Trim()))
                        { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                        else
                        {
                            rd = DataCheckCenter.Instance.CheckCash(tbAmountS, tbAmountS.Text.Trim(), lbAmountS.Text.Substring(0, lbAmountS.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
                            if (!rd.Result) return rd.Result;
                        }
                    }
                    if (!string.IsNullOrEmpty(tbContactNo.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckLength(tbContactNo, tbContactNo.Text.Trim(), lbContactNo.Text.Substring(0, lbContactNo.Text.Length - 1), 20, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    if (!string.IsNullOrEmpty(tbSerialNos.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckLength(tbSerialNos, tbSerialNos.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), 20, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    if (!string.IsNullOrEmpty(tbBillSerialNo.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckBillSerialNoSF(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), 50, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    rd = DataCheckCenter.Instance.CheckProposerName(tbProposerName, tbProposerName.Text.Trim(), lbProposerName.Text.Substring(0, lbProposerName.Text.Length - 1), 70, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                    rd = DataCheckCenter.Instance.CheckTelePhone(tbTelephone, tbTelephone.Text.Trim(), lbTelephone.Text.Substring(0, lbTelephone.Text.Length - 1), 15, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                    #endregion
                }
                else if (banktype == AgentTransferBankType.Other)
                {
                    #region
                    if (!string.IsNullOrEmpty(cmbRemitNote.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeAddtion(cmbRemitNote, cmbRemitNote.Text.Trim(), lbRmitNote.Text.Substring(0, lbRmitNote.Text.Length - 1), 120, false, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    if (cmbPayFeeType.SelectedIndex < 0)
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    if (cmbPaymentPropertyType.SelectedIndex < 0)
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentPropertyType), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    if (string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()) && string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1} {2} {3}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF, MultiLanguageConvertHelper.Instance.Information_Or, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    if (!string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckDealSerialNo(tbDealSerialNoF, tbDealSerialNoF.Text.Trim(), lbDealSerialNoF.Text.Substring(0, lbDealSerialNoF.Text.Length - 1), 6, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                        if (string.IsNullOrEmpty(tbAmountF.Text.Trim()))
                        { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                        else
                        {
                            rd = DataCheckCenter.Instance.CheckCash(tbAmountF, tbAmountF.Text.Trim(), lbAmountF.Text.Substring(0, lbAmountF.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
                            if (!rd.Result) return rd.Result;
                        }
                    }
                    if (!string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckDealSerialNo(tbDealSerialNoS, tbDealSerialNoS.Text.Trim(), lbDealSerialNoS.Text.Substring(0, lbDealSerialNoS.Text.Length - 1), 6, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                        if (string.IsNullOrEmpty(tbAmountS.Text.Trim()))
                        { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                        else
                        {
                            rd = DataCheckCenter.Instance.CheckCash(tbAmountS, tbAmountS.Text.Trim(), lbAmountS.Text.Substring(0, lbAmountS.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
                            if (!rd.Result) return rd.Result;
                        }
                    }
                    if (!string.IsNullOrEmpty(tbContactNo.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckLength(tbContactNo, tbContactNo.Text.Trim(), lbContactNo.Text.Substring(0, lbContactNo.Text.Length - 1), 20, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    if (!string.IsNullOrEmpty(tbBillSerialNo.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckLength(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), 35, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    if (!string.IsNullOrEmpty(tbSerialNos.Text.Trim()))
                    {
                        rd = DataCheckCenter.Instance.CheckLength(tbSerialNos, tbSerialNos.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), 40, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    rd = DataCheckCenter.Instance.CheckProposerName(tbProposerName, tbProposerName.Text.Trim(), lbProposerName.Text.Substring(0, lbProposerName.Text.Length - 1), 70, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                    rd = DataCheckCenter.Instance.CheckTelePhone(tbTelephone, tbTelephone.Text.Trim(), lbTelephone.Text.Substring(0, lbTelephone.Text.Length - 1), 15, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                    #endregion
                }
                #endregion
            }
            else //国结和柜台
            {
                #region
                if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar && bankTypeBarOrFC == AgentTransferBankType.Boc) return true;
                if (!string.IsNullOrEmpty(cmbRemitNote.Text))
                {
                    if (m_appType == AppliableFunctionType.TransferOverCountry
                        || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(cmbRemitNote, cmbRemitNote.Text.Trim(), lbRmitNote.Text.Substring(0, lbRmitNote.Text.Length - 1), 140, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    else
                    {
                        rd = DataCheckCenter.Instance.CheckAddtion(cmbRemitNote, cmbRemitNote.Text.Trim(), lbRmitNote.Text.Substring(0, lbRmitNote.Text.Length - 1), m_appType == AppliableFunctionType.TransferForeignMoney4Bar ? 140 : 50, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                }
                if (cmbAssumeFeeType.SelectedIndex < 0)
                { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, MultiLanguageConvertHelper.Instance.TransferGlobal_AssumeFeeType), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                if (cmbPayFeeType.SelectedIndex < 0)
                { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                if (m_appType == AppliableFunctionType.TransferForeignMoney
                    || m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    if (cmbPaymentPropertyType.SelectedIndex < 0)
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentPropertyType), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    if (string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()) && string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1} {2} {3}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF, MultiLanguageConvertHelper.Instance.Information_Or, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                }
                if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                {
                    if (string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()) && string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1} {2} {3}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF, MultiLanguageConvertHelper.Instance.Information_Or, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                }
                if (!string.IsNullOrEmpty(tbDealSerialNoF.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckDealSerialNo(tbDealSerialNoF, tbDealSerialNoF.Text.Trim(), lbDealSerialNoF.Text.Substring(0, lbDealSerialNoF.Text.Length - 1), 6, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                    if (string.IsNullOrEmpty(tbAmountF.Text.Trim()))
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    else
                    {
                        rd = DataCheckCenter.Instance.CheckCash(tbAmountF, tbAmountF.Text.Trim(), lbAmountF.Text.Substring(0, lbAmountF.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    if (m_appType == AppliableFunctionType.TransferOverCountry
                        || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                    {
                        if (!string.IsNullOrEmpty(tbDealNoteF.Text.Trim()))
                        {
                            rd = DataCheckCenter.Instance.CheckAddtionExIAOrUP(tbDealNoteF, tbDealNoteF.Text.Trim(), lbDealNoteF.Text.Substring(0, lbDealNoteF.Text.Length - 1), m_appType == AppliableFunctionType.TransferOverCountry ? 100 : 50, this.errorProvider1);
                            if (!rd.Result) return rd.Result;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(tbDealSerialNoS.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckDealSerialNo(tbDealSerialNoS, tbDealSerialNoS.Text.Trim(), lbDealSerialNoS.Text.Substring(0, lbDealSerialNoS.Text.Length - 1), 6, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                    if (string.IsNullOrEmpty(tbAmountS.Text.Trim()))
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    else
                    {
                        rd = DataCheckCenter.Instance.CheckCash(tbAmountS, tbAmountS.Text.Trim(), lbAmountS.Text.Substring(0, lbAmountS.Text.Length - 1), 15, m_Cash == CashType.JPY, this.errorProvider1);
                        if (!rd.Result) return rd.Result;
                    }
                    if (m_appType == AppliableFunctionType.TransferOverCountry
                        || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                    {
                        if (!string.IsNullOrEmpty(tbDealNoteS.Text.Trim()))
                        {
                            rd = DataCheckCenter.Instance.CheckAddtionExIAOrUP(tbDealNoteS, tbDealNoteS.Text.Trim(), lbDealNoteS.Text.Substring(0, lbDealNoteS.Text.Length - 1), m_appType == AppliableFunctionType.TransferOverCountry ? 100 : 50, this.errorProvider1);
                            if (!rd.Result) return rd.Result;
                        }
                    }
                }
                if (m_appType != AppliableFunctionType.TransferOverCountry4Bar
                    && m_appType != AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    //if (rbYes.Checked)  //不需要判断
                    //{
                    //    if (!string.IsNullOrEmpty(tbContactNo.Text.Trim()))
                    //    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    //    if (!string.IsNullOrEmpty(tbBillSerialNo.Text.Trim()))
                    //    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    //    if (!string.IsNullOrEmpty(tbSerialNos.Text.Trim()))
                    //    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    //}
                }
                if (!string.IsNullOrEmpty(tbContactNo.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckSerialNoEx(tbContactNo, tbContactNo.Text.Trim(), lbContactNo.Text.Substring(0, lbContactNo.Text.Length - 1), 20, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                if (!string.IsNullOrEmpty(tbBillSerialNo.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckSerialNoEx(tbBillSerialNo, tbBillSerialNo.Text.Trim(), lbBillSerialNo.Text.Substring(0, lbBillSerialNo.Text.Length - 1), m_appType == AppliableFunctionType.TransferForeignMoney ? 20 : m_appType == AppliableFunctionType.TransferOverCountry ? 50 : 35, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                if (!string.IsNullOrEmpty(tbSerialNos.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckSerialNoEx(tbSerialNos, tbSerialNos.Text.Trim(), lbSerialNo.Text.Substring(0, lbSerialNo.Text.Length - 1), 20, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
                rd = DataCheckCenter.Instance.CheckProposerName(tbProposerName, tbProposerName.Text.Trim(), lbProposerName.Text.Substring(0, lbProposerName.Text.Length - 1), 20, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                rd = DataCheckCenter.Instance.CheckTelePhone(tbTelephone, tbTelephone.Text.Trim(), lbTelephone.Text.Substring(0, lbTelephone.Text.Length - 1), 15, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    if (cmbBarBusinessType.SelectedIndex < 0)
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.DesignMain_Please_Selection, label2.Text.Substring(0, label2.Text.Length - 1)), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    if (cmbBarApplyFlagType.SelectedIndex < 0)
                    { MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.DesignMain_Please_Selection, label1.Text.Substring(0, label1.Text.Length - 1)), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                }
                #endregion
            }
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

                tbDealSerialNoF.Text =
                tbDealSerialNoS.Text =
                tbDealNoteF.Text =
                tbDealNoteS.Text =
                tbAmountF.Text =
                tbAmountS.Text =
                tbContactNo.Text =
                tbBillSerialNo.Text = string.Empty;
                if (m_appType != AppliableFunctionType.TransferForeignMoney4Bar && m_appType != AppliableFunctionType.TransferOverCountry4Bar)
                    tbProposerName.Text =
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
                        cmbRemitNote.Text = items.Addtion;
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
                        cmbAssumeFeeType.Text = items.Purpose;
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
            chbSave.Checked = false;
        }

        private void cmbRemitNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (m_appType != AppliableFunctionType.TransferOverCountry4Bar) return;
            if ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)
            {
                e.KeyChar = (char)((int)e.KeyChar - 32);
            }
        }
    }
}
