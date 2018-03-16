using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.Entities;
using CommonClient.ConvertHelper;
using CommonClient.Utilities;
using CommonClient.Controls;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class TransferGlobalPayeeSelector : BaseUc
    {
        public TransferGlobalPayeeSelector()
        {
            InitializeComponent();

            rbBOC.CheckedChanged += new EventHandler(rbBank_CheckedChanged);
            rbOther.CheckedChanged += new EventHandler(rbBank_CheckedChanged);
            cmbPayeeAccount.SelectedIndexChanged += new EventHandler(cmbPayeeAccount_SelectedIndexChanged);
            ambiguityInputAgent1.Selected += new EventHandler<SelectedEventParameter>(ambiguityInputAgent1_Selected);

            CommandCenter.OnTransferGlobalEventHandler += new EventHandler<TransferGlobalEventArgs>(CommandCenter_OnTransferGlobalEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnPayeeInfo4TransferGlobalEventHandler += new EventHandler<Payee4TransferGlobalEventArgs>(CommandCenter_OnPayeeInfo4TransferGlobalEventHandler);
            CommandCenter.OnBankTypeChangedEventHandler += new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler);
            CommandCenter.OnOverCountryPayeeAccountTypeEventHandler += new EventHandler<OverCountryPayeeAccountTypeEventArgs>(CommandCenter_OnOverCountryPayeeAccountTypeEventHandler);
            CommandCenter.OnUnitivePaymentFCEventHandler += new EventHandler<UnitivePaymentFCEventArgs>(CommandCenter_OnUnitivePaymentFCEventHandler);
            p_BankCode.LocationChanged += new EventHandler(p_BankCode_LocationChanged);
        }

        void ambiguityInputAgent1_Selected(object sender, SelectedEventParameter e)
        {
            if (ambiguityInputAgent1.SelectedItemIndex == -1) return;
            tbPayeeName.Text = (ambiguityInputAgent1.SelectedEntity as PayeeInfo4TransferGlobal).Name;
            tbPayeeAddress.Text = (ambiguityInputAgent1.SelectedEntity as PayeeInfo4TransferGlobal).Address;
        }

        void p_BankCode_LocationChanged(object sender, EventArgs e)
        {
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                if (m_AccountType == OverCountryPayeeAccountType.ForeignAccount)
                {
                    p_BankCode.Location = new Point { X = 0, Y = p_FC.Location.Y + p_FC.Height + panel2.Height };
                    panel3.Location = new Point { X = 0, Y = p_BankCode.Location.Y + p_BankCode.Height };
                    lblAccountType.Visible = true;
                }
                else if (rbOther.Checked)
                {
                    p_OtherBank.Location = new Point { X = 0, Y = panel2.Location.Y + panel2.Height };
                    p_BankCode.Location = new Point { X = 0, Y = p_OtherBank.Location.Y + p_OtherBank.Height };
                    panel3.Location = new Point { X = 0, Y = p_BankCode.Location.Y + p_BankCode.Height };
                }
            }
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

        void CommandCenter_OnOverCountryPayeeAccountTypeEventHandler(object sender, OverCountryPayeeAccountTypeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<OverCountryPayeeAccountTypeEventArgs>(CommandCenter_OnOverCountryPayeeAccountTypeEventHandler), sender, e); }
            else
            {
                if (m_appType != e.AppType) return;
                if (e.Command != OperatorCommandType.PayeeAccountTypeChanged) return;

                m_AccountType = e.AccountType;
                p_FC.Visible = e.AccountType == OverCountryPayeeAccountType.ForeignAccount;
                if (e.AccountType != OverCountryPayeeAccountType.ForeignAccount)
                {
                    m_AccountType = rbBOC.Checked ? OverCountryPayeeAccountType.BocAccount : OverCountryPayeeAccountType.OtherAccount;
                    CommandCenter.ResolveBankTypeChanged(OperatorCommandType.BankTypeRequest, m_appType, rbBOC.Checked ? AgentTransferBankType.Boc : AgentTransferBankType.Other, false);
                    p_ForeignMoney.Visible = true;
                    p_OverCountry.Visible = false;
                    p_BankCode.Visible = rbOther.Checked;
                    panel3.Visible = rbOther.Checked;
                    p_OtherBank.Visible = rbOther.Checked;
                    p_swiftc.Visible = rbOther.Checked;
                    lbPayeeAddress.Visible = tbPayeeAddress.Visible = rbOther.Checked;
                    cmbPayeeAccount.Items.Clear();
                    List<PayeeInfo4TransferGlobal> list = SystemSettings.PayeeInfo4TransferGlobalList.FindAll(o => o.AccountType == m_AccountType);
                    cmbPayeeAccount.Items.AddRange(list.ToArray());
                    cmbPayeeAccount.Tag = list;
                    ambiguityInputAgent1.ClearItems();
                    list.ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
                }
                else
                {
                    p_OtherBank.Visible =
                    panel3.Visible =
                    p_ForeignMoney.Visible = false;
                    p_BankCode.Visible = true;
                    p_OverCountry.Visible = true;
                    panel3.Visible = true;
                    p_swiftc.Visible = true;
                    lbPayeeAddress.Visible = tbPayeeAddress.Visible = true;
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
                if (e.Command != OperatorCommandType.BankTypeCallBack) return;
                if (e.IsRollBack)
                {
                    isCallBack = true;
                    rbBOC.Checked = e.BankType == AgentTransferBankType.Boc;
                    rbOther.Checked = e.BankType == AgentTransferBankType.Other;

                    p_BankCode.Visible =
                    p_swiftc.Visible = rbOther.Checked;
                    lbPayeeAddress.Visible = tbPayeeAddress.Visible = e.BankType == AgentTransferBankType.Other;

                    cmbPayeeAccount.Items.Clear();
                    List<PayeeInfo4TransferGlobal> list = SystemSettings.PayeeInfo4TransferGlobalList.FindAll(o => (rbBOC.Checked && o.AccountType == OverCountryPayeeAccountType.BocAccount) || (rbOther.Checked && o.AccountType == OverCountryPayeeAccountType.OtherAccount));
                    cmbPayeeAccount.Items.AddRange(list.ToArray());
                    cmbPayeeAccount.Tag = list;
                }
                else CommandCenter.ResolveBankTypeChanged(OperatorCommandType.BankTypeChanged, m_appType, rbBOC.Checked ? AgentTransferBankType.Boc : AgentTransferBankType.Other, false);
                SetRegex();
            }
        }

        void cmbPayeeAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayeeAccount.SelectedIndex < 0) return;
            tbPayeeName.Text = (cmbPayeeAccount.Tag as List<PayeeInfo4TransferGlobal>)[cmbPayeeAccount.SelectedIndex].Name;
            tbPayeeAddress.Text = (cmbPayeeAccount.Tag as List<PayeeInfo4TransferGlobal>)[cmbPayeeAccount.SelectedIndex].Address;
        }

        void CommandCenter_OnPayeeInfo4TransferGlobalEventHandler(object sender, Payee4TransferGlobalEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<Payee4TransferGlobalEventArgs>(CommandCenter_OnPayeeInfo4TransferGlobalEventHandler), sender, e); }
            else
            {
                if (e.Command == OperatorCommandType.Submit)
                {
                    if (((m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferOverCountry4Bar) && e.PayeeInfo.AccountType != OverCountryPayeeAccountType.ForeignAccount) || ((m_appType == AppliableFunctionType.TransferForeignMoney || m_appType == AppliableFunctionType.TransferForeignMoney4Bar) && e.PayeeInfo.AccountType == OverCountryPayeeAccountType.ForeignAccount)) return;
                    List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
                    if (cmbPayeeAccount.Tag != null) list = cmbPayeeAccount.Tag as List<PayeeInfo4TransferGlobal>;
                    if (list.Exists(o => o.Account == e.PayeeInfo.Account)) return;
                    cmbPayeeAccount.Items.Add(e.PayeeInfo);
                    list.Add(e.PayeeInfo);
                    cmbPayeeAccount.Tag = list;
                }
                else if (e.Command == OperatorCommandType.Edit)
                {
                    if (((m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferOverCountry4Bar) && e.PayeeInfo.AccountType != OverCountryPayeeAccountType.ForeignAccount) || ((m_appType == AppliableFunctionType.TransferForeignMoney || m_appType == AppliableFunctionType.TransferForeignMoney4Bar) && e.PayeeInfo.AccountType == OverCountryPayeeAccountType.ForeignAccount)) return;
                    List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
                    if (cmbPayeeAccount.Tag != null) list = cmbPayeeAccount.Tag as List<PayeeInfo4TransferGlobal>;
                    int index = list.FindIndex(o => o.Account == e.PayeeInfo.Account);
                    if (index != -1)
                    {
                        cmbPayeeAccount.Items[index] = e.PayeeInfo;
                        list[index] = e.PayeeInfo;
                    }
                    else
                    {
                        cmbPayeeAccount.Items.Add(e.PayeeInfo);
                        list.Add(e.PayeeInfo);
                    }
                    cmbPayeeAccount.Tag = list;
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    if (((m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferOverCountry4Bar) && e.PayeeInfo.AccountType != OverCountryPayeeAccountType.ForeignAccount) || ((m_appType == AppliableFunctionType.TransferForeignMoney || m_appType == AppliableFunctionType.TransferForeignMoney4Bar) && e.PayeeInfo.AccountType == OverCountryPayeeAccountType.ForeignAccount)) return;
                    List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
                    if (cmbPayeeAccount.Tag != null) list = cmbPayeeAccount.Tag as List<PayeeInfo4TransferGlobal>;
                    int index = list.FindIndex(o => o.Account == e.PayeeInfo.Account);
                    if (index != -1)
                    {
                        cmbPayeeAccount.Items.RemoveAt(index);
                        list.RemoveAt(index);
                        cmbPayeeAccount.Tag = list;
                    }
                }
                ambiguityInputAgent1.ClearItems();
                if (cmbPayeeAccount.Items.Count > 0)
                    (cmbPayeeAccount.Tag as List<PayeeInfo4TransferGlobal>).ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            }
        }

        void rbBank_CheckedChanged(object sender, EventArgs e)
        {
            if (isCallBack) { isCallBack = false; return; }
            if (!((RadioButton)sender).Checked) return;
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                if (m_AccountType != OverCountryPayeeAccountType.Empty && m_AccountType != OverCountryPayeeAccountType.ForeignAccount)
                {
                    cmbRemitCountry.DvRequired = false;
                    p_OtherBank.Visible = p_BankCode.Visible = rbOther.Checked;
                    p_swiftc.Visible = panel3.Visible = rbOther.Checked;
                    CommandCenter.ResolveBankTypeChanged(OperatorCommandType.BankTypeRequest, m_appType, rbBOC.Checked ? AgentTransferBankType.Boc : AgentTransferBankType.Other, false);
                }
                else if (m_AccountType == OverCountryPayeeAccountType.ForeignAccount) { p_BankCode.Visible = p_swiftc.Visible = true; cmbRemitCountry.DvRequired = true; cmbPayeeAccountType.DvRequired = true; }
                p_OverCountry.Visible = m_AccountType == OverCountryPayeeAccountType.ForeignAccount;
                p_ForeignMoney.Visible = !p_OverCountry.Visible;
                if (rbOther.Checked)
                {
                    m_AccountType = OverCountryPayeeAccountType.OtherAccount;
                    cmbRemitCountry.DvRequired = false;
                    cmbPayeeAccountType.DvRequired = false;
                }
                else
                {
                    m_AccountType = OverCountryPayeeAccountType.BocAccount;
                    cmbRemitCountry.DvRequired = false;
                    cmbPayeeAccountType.DvRequired = false;
                }
                lbPayeeAddress.Visible = tbPayeeAddress.Visible = rbOther.Checked;
                if (rbBOC.Checked)
                {
                    #region
                    cmbPayeeAccount.DvRegCode = "reg648";
                    cmbPayeeAccount.DvMinLength = 1;
                    cmbPayeeAccount.DvMaxLength = 35;
                    tbPayeeName.DvRegCode = "reg685";
                    tbPayeeName.DvMinLength = 1;
                    tbPayeeName.DvMaxLength = 240;
                    #endregion
                }
                else if (rbOther.Checked)
                {
                    #region
                    cmbPayeeAccount.DvRegCode = "reg648";
                    cmbPayeeAccount.DvMinLength = 1;
                    cmbPayeeAccount.DvMaxLength = 35;
                    tbPayeeName.DvRegCode = "reg662";
                    tbPayeeName.DvMinLength = 1;
                    tbPayeeName.DvMaxLength = 70;
                    tbPayeeAddress.DvRegCode = "reg662";
                    tbPayeeAddress.DvMinLength = 0;
                    tbPayeeAddress.DvMaxLength = 140;
                    tbFPayeeOpenBankName.DvRegCode = "reg662";
                    tbFPayeeOpenBankName.DvMinLength = 1;
                    tbFPayeeOpenBankName.DvMaxLength = 140;
                    tbOSwiftCode.DvRegCode = "reg24";
                    tbOSwiftCode.DvMinLength = 0;
                    tbOSwiftCode.DvMaxLength = 11;
                    tbPayeeOpenBankAddress.DvRegCode = "reg662";
                    tbPayeeOpenBankAddress.DvMinLength = 0;
                    tbPayeeOpenBankAddress.DvMaxLength = 70;
                    tbCorrespondentBankName.DvRegCode = "reg662";
                    tbCorrespondentBankName.DvMinLength = 0;
                    tbCorrespondentBankName.DvMaxLength = 140;
                    tbCSwiftCode.DvRegCode = "reg24";
                    tbCSwiftCode.DvMinLength = 0;
                    tbCSwiftCode.DvMaxLength = 11;
                    tbCorrespondentBankAddress.DvRegCode = "reg630";
                    tbCorrespondentBankAddress.DvMinLength = 0;
                    tbCorrespondentBankAddress.DvMaxLength = 280;
                    tbCorrespondentBankName.DvRegCode = "reg662";
                    tbCorrespondentBankName.DvMinLength = 0;
                    tbCorrespondentBankName.DvMaxLength = 140;
                    tbPayeeAccountInCorrespondentBank.DvRegCode = "reg648";
                    tbPayeeAccountInCorrespondentBank.DvMinLength = 0;
                    tbPayeeAccountInCorrespondentBank.DvMaxLength = 35;

                    #endregion
                }
            }
            else
            {
                //p_BankCode.Visible = rbOther.Checked;
                p_OtherBank.Visible =
                tbFPayeeOpenBankName.DvRequired = ((m_appType == AppliableFunctionType.TransferForeignMoney || m_appType == AppliableFunctionType.TransferForeignMoney4Bar) && rbOther.Checked);
                p_BankCode.Visible = m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferOverCountry4Bar || (m_appType == AppliableFunctionType.TransferForeignMoney4Bar && rbOther.Checked);
                p_swiftc.Visible = m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferOverCountry4Bar;
                if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    p_ForeignMoneyBar.Visible = rbBOC.Checked;
                    panel3.Visible = rbOther.Checked;
                    CommandCenter.ResolveBankTypeChanged(OperatorCommandType.BankTypeRequest, m_appType, rbBOC.Checked ? AgentTransferBankType.Boc : AgentTransferBankType.Other, false);
                }
                if (m_appType == AppliableFunctionType.TransferForeignMoney
                    || m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    if (rbBOC.Checked)
                    {
                        cmbPayeeAccount.DvRegCode = "reg687";
                        cmbPayeeAccount.DvMinLength = 1;
                        cmbPayeeAccount.DvMaxLength = 20;
                    }
                    else if (rbOther.Checked)
                    {
                        cmbPayeeAccount.DvRegCode = "reg688";
                        cmbPayeeAccount.DvMinLength = 1;
                        cmbPayeeAccount.DvMaxLength = 32;
                        tbFPayeeOpenBankName.DvRegCode = "reg662";
                        tbFPayeeOpenBankName.DvMinLength = 1;
                        tbFPayeeOpenBankName.DvMaxLength = 70;
                        if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                        {
                            tbOSwiftCode.DvRegCode = "reg24";
                            tbOSwiftCode.DvMinLength = 0;
                            tbOSwiftCode.DvMaxLength = 11;
                        }
                        if (m_appType != AppliableFunctionType.TransferForeignMoney4Bar || (m_appType == AppliableFunctionType.TransferForeignMoney4Bar && rbOther.Checked))
                        {
                            tbPayeeOpenBankAddress.DvRegCode = "reg662";
                            tbPayeeOpenBankAddress.DvMinLength = 0;
                            tbPayeeOpenBankAddress.DvMaxLength = 70;
                            tbCorrespondentBankName.DvRegCode = "reg662";
                            tbCorrespondentBankName.DvMinLength = 0;
                            tbCorrespondentBankName.DvMaxLength = 70;
                        }
                    }
                    if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                    {
                        if (rbBOC.Checked)
                        {
                            if (cmbPayeeCertPaperType.SelectedIndex == 1)
                            {
                                edtCertPaperNo.DvRegCode = "reg579";
                                edtCertPaperNo.DvMinLength = 15;
                                edtCertPaperNo.DvMaxLength = 18;
                            }
                            else if (cmbPayeeCertPaperType.SelectedIndex > 1)
                            {
                                edtCertPaperNo.DvRegCode = "Predefined5";
                                edtCertPaperNo.DvMinLength = 1;
                                edtCertPaperNo.DvMaxLength = 32;
                            }
                        }
                        else if (rbOther.Checked)
                        {
                            tbCSwiftCode.DvRegCode = "reg24";
                            tbCSwiftCode.DvMinLength = 0;
                            tbCSwiftCode.DvMaxLength = 18;
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
                base.ApplyResource(typeof(TransferGlobalPayeeSelector), this);
                Init();
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
        /// <summary>
        /// 外币统一支付收款人账号类型
        /// </summary>
        OverCountryPayeeAccountType m_AccountType = OverCountryPayeeAccountType.BocAccount;
        bool isCallBack = false;

        private TransferGlobal m_TransferGlobal = null;
        /// <summary>
        /// 国际结算信息
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
        public bool SavePayee;

        private void Init()
        {
            lblOpenBankAddress.Visible = (SystemSettings.CurrentVersion & VersionType.t43) == VersionType.t43 && m_appType == AppliableFunctionType.TransferForeignMoney;
            p_ForeignMoney.Visible = m_appType == AppliableFunctionType.TransferForeignMoney || m_appType == AppliableFunctionType.TransferForeignMoney4Bar;
            p_OverCountry.Visible = m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferOverCountry4Bar;
            p_OtherBank.Visible = ((m_appType == AppliableFunctionType.TransferForeignMoney || m_appType == AppliableFunctionType.TransferForeignMoney4Bar) && rbOther.Checked);
            p_BankCode.Visible = !((m_appType == AppliableFunctionType.TransferForeignMoney || m_appType == AppliableFunctionType.TransferForeignMoney4Bar) && rbBOC.Checked);
            p_swiftc.Visible = m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferOverCountry4Bar;

            cmbPayeeAccount.Items.Clear();
            List<PayeeInfo4TransferGlobal> list = SystemSettings.PayeeInfo4TransferGlobalList.FindAll(o => ((m_appType == AppliableFunctionType.TransferForeignMoney || m_appType == AppliableFunctionType.TransferForeignMoney4Bar) && o.AccountType != OverCountryPayeeAccountType.ForeignAccount)
                                                                                                                || ((m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferOverCountry4Bar) && o.AccountType == OverCountryPayeeAccountType.ForeignAccount));
            cmbPayeeAccount.Items.AddRange(list.ToArray());
            cmbPayeeAccount.Tag = list;
            ambiguityInputAgent1.ClearItems();
            list.ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                #region
                tbCountry.Text = EnumNameHelper<CountryHelper>.GetEnumDescription(CountryHelper.CHN) + " " + CountryHelper.CHN.ToString();
                rbBOC.Enabled = m_appType == AppliableFunctionType.TransferForeignMoney4Bar;
                rbBOC.Checked = false;
                rbOther.Checked = !rbBOC.Checked;
                lblOpenBankAddress.Visible = false;

                cmbPayeeCertPaperType.Items.Clear();
                cmbPayeeCertPaperType.Items.Add(MultiLanguageConvertHelper.DesignMain_Please_Selection);
                foreach (AgentExpressCertifyPaperType certifyPaperType in PrequisiteDataProvideNode.InitialProvide.AgentExpressCertifyPaperTypeList)
                {
                    if (certifyPaperType == AgentExpressCertifyPaperType.Empty) continue;
                    var value = EnumNameHelper<AgentTransferBankType>.GetEnumDescription(certifyPaperType);
                    this.cmbPayeeCertPaperType.Items.Add(value);
                }
                cmbPayeeCertPaperType.Tag = PrequisiteDataProvideNode.InitialProvide.AgentExpressCertifyPaperTypeList.FindAll(o => o != AgentExpressCertifyPaperType.Empty);
                cmbPayeeCertPaperType.SelectedIndex = 0;
                cmbPayeeAccountProvince.Items.Clear();
                foreach (ChinaProvinceType chinaProvinceType in PrequisiteDataProvideNode.InitialProvide.ChinaProvinceTypeList)
                {
                    if (chinaProvinceType == ChinaProvinceType.B0) continue;
                    var value = EnumNameHelper<ChinaProvinceType>.GetEnumDescription(chinaProvinceType);
                    this.cmbPayeeAccountProvince.Items.Add(value);
                }
                cmbPayeeAccountProvince.Tag = PrequisiteDataProvideNode.InitialProvide.ChinaProvinceTypeList.FindAll(o => o != ChinaProvinceType.B0);

                cbNoticeType.Items.Clear();
                List<AgentExpressFunctionType> templist = new List<AgentExpressFunctionType>();
                cbNoticeType.Items.Add(EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(AgentExpressFunctionType.EV));
                templist.Add(AgentExpressFunctionType.EV);
                foreach (AgentExpressFunctionType agentExpressFunctionType in PrequisiteDataProvideNode.InitialProvide.AgentExpressFunctionTypeList)
                {
                    if (agentExpressFunctionType == AgentExpressFunctionType.Empty || agentExpressFunctionType == AgentExpressFunctionType.EV) continue;
                    var value = EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(agentExpressFunctionType);
                    this.cbNoticeType.Items.Add(value);
                    templist.Add(agentExpressFunctionType);
                }
                cbNoticeType.Tag = templist;
                #endregion
            }

            if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                lbFSwiftCode.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankSwiftCode_Bar_OC, "：");
                lbCSwiftCode.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankSwiftCode_Bar_OC, "：");
                lbFSwiftCode.Location = new Point { X = lbPayeeAccount.Location.X + lbPayeeAccount.Width - lbFSwiftCode.Width, Y = lbFSwiftCode.Location.Y };
                lbCSwiftCode.Location = new Point { X = lbPayeeAccount.Location.X + lbPayeeAccount.Width - lbCSwiftCode.Width, Y = lbCSwiftCode.Location.Y };
            }

            if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            //|| m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                #region
                foreach (var item in this.Controls)
                {
                    if (item is TextBoxCanValidate)
                        ((TextBoxCanValidate)item).CharacterCasing = CharacterCasing.Upper;
                    else if (item is Panel)
                    {
                        foreach (var citem in ((Panel)item).Controls)
                        {
                            if (citem is TextBoxCanValidate)
                                ((TextBoxCanValidate)citem).CharacterCasing = CharacterCasing.Upper;
                            if (citem is Panel)
                            {
                                foreach (var ccitem in ((Panel)citem).Controls)
                                {
                                    if (citem is TextBoxCanValidate)
                                        ((TextBoxCanValidate)citem).CharacterCasing = CharacterCasing.Upper;
                                }
                            }
                        }
                    }
                }

                cmbPayeeAccount.KeyPress += new KeyPressEventHandler(cmbPayeeAccount_KeyPress);
                #endregion
            }
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                #region
                cmbRemitCountry.Items.Clear();
                foreach (var item in PrequisiteDataProvideNode.InitialProvide.Transfer2CountryTypeList)
                {
                    if (item == Transfer2CountryType.Empty) continue;
                    string value = EnumNameHelper<Transfer2CountryType>.GetEnumDescription(item);
                    cmbRemitCountry.Items.Add(value);
                }
                cmbRemitCountry.Tag = PrequisiteDataProvideNode.InitialProvide.Transfer2CountryTypeList.FindAll(o => o != Transfer2CountryType.Empty);
                cmbPayeeAccountType.Items.Clear();
                foreach (var item in PrequisiteDataProvideNode.InitialProvide.UnitiveFCPayeeAccountTypeList)
                {
                    if (item == UnitiveFCPayeeAccountType.Empty) continue;
                    string value = EnumNameHelper<UnitiveFCPayeeAccountType>.GetEnumDescription(item);
                    cmbPayeeAccountType.Items.Add(value);
                }
                cmbPayeeAccountType.Tag = PrequisiteDataProvideNode.InitialProvide.UnitiveFCPayeeAccountTypeList.FindAll(o => o != UnitiveFCPayeeAccountType.Empty);

                lbPayeeAddress.Visible = tbPayeeAddress.Visible = false;
                p_ForeignMoney.Visible = true;
                p_OverCountry.Visible =
                p_BankCode.Visible =
                panel3.Visible = false;

                cmbPayeeAccount.Items.Clear();
                List<PayeeInfo4TransferGlobal> listP = SystemSettings.PayeeInfo4TransferGlobalList.FindAll(o => o.AccountType == OverCountryPayeeAccountType.BocAccount);
                cmbPayeeAccount.Items.AddRange(listP.ToArray());
                cmbPayeeAccount.Tag = listP;
                #endregion
            }
            SetRegex();
        }
        private void SetRegex()
        {
            cmbPayeeAccount.DvRegCode = null;
            tbPayeeName.DvRegCode = null;
            tbPayeeAddress.DvRegCode = null;
            tbCountry.DvRegCode = null;
            tbPayeeOpenBankName.DvRegCode = null;
            tbFPayeeOpenBankName.DvRegCode = null;
            tbOSwiftCode.DvRegCode = null;
            tbPayeeOpenBankAddress.DvRegCode = null;
            tbPayeeAccountInCorrespondentBank.DvRegCode = null;
            tbCorrespondentBankName.DvRegCode = null;
            tbCorrespondentBankAddress.DvRegCode = null;
            tbCSwiftCode.DvRegCode = null;
            tbPayeeOpenBankAddress.DvRequired = lblOpenBankAddress.Visible;
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                #region
                if (m_AccountType == OverCountryPayeeAccountType.ForeignAccount)
                {
                    #region
                    cmbPayeeAccount.DvRegCode = "reg702";
                    cmbPayeeAccount.DvMinLength = 1;
                    cmbPayeeAccount.DvMaxLength = 34;
                    cmbPayeeAccount.DvRequired = true;
                    tbPayeeName.DvRegCode = "reg702";
                    tbPayeeName.DvMinLength = 1;
                    tbPayeeName.DvMaxLength = 140;
                    tbPayeeName.DvRequired = true;
                    tbPayeeAddress.DvRegCode = "reg702";
                    tbPayeeAddress.DvMinLength = 0;
                    tbPayeeAddress.DvMaxLength = 140;
                    tbPayeeAddress.DvRequired = false;
                    tbPayeeOpenBankName.DvRegCode = "reg662";
                    tbPayeeOpenBankName.DvMinLength = 1;
                    tbPayeeOpenBankName.DvMaxLength = 140;
                    tbPayeeOpenBankName.DvRequired = true;
                    tbOSwiftCode.DvRegCode = "reg24";
                    tbOSwiftCode.DvMinLength = 0;
                    tbOSwiftCode.DvMaxLength = 18;
                    tbOSwiftCode.DvRequired = false;
                    tbPayeeOpenBankAddress.DvRegCode = "reg662";
                    tbPayeeOpenBankAddress.DvMinLength = 0;
                    tbPayeeOpenBankAddress.DvMaxLength = 140;

                    tbCorrespondentBankName.DvRegCode = "reg662";
                    tbCorrespondentBankName.DvMinLength = 0;
                    tbCorrespondentBankName.DvMaxLength = 140;
                    tbCorrespondentBankName.DvRequired = false;
                    tbCSwiftCode.DvRegCode = "reg24";
                    tbCSwiftCode.DvMinLength = 0;
                    tbCSwiftCode.DvMaxLength = 18;
                    tbCSwiftCode.DvRequired = false;
                    tbCorrespondentBankAddress.DvRegCode = "reg630";
                    tbCorrespondentBankAddress.DvMinLength = 0;
                    tbCorrespondentBankAddress.DvMaxLength = 140;
                    tbCorrespondentBankAddress.DvRequired = false;
                    tbCorrespondentBankName.DvRegCode = "reg662";
                    tbCorrespondentBankName.DvMinLength = 0;
                    tbCorrespondentBankName.DvMaxLength = 140;
                    tbCorrespondentBankName.DvRequired = false;
                    tbPayeeAccountInCorrespondentBank.DvRegCode = "reg688";
                    tbPayeeAccountInCorrespondentBank.DvMinLength = 0;
                    tbPayeeAccountInCorrespondentBank.DvMaxLength = 35;
                    tbPayeeAccountInCorrespondentBank.DvRequired = false;
                    tbPayeeName.DvRegCode = "Predefined5";
                    tbPayeeName.DvMinLength = 1;
                    tbPayeeName.DvMaxLength = 140;
                    tbPayeeName.DvRequired = true;
                    cmbRemitCountry.DvRequired = true;
                    cmbPayeeAccountType.DvRequired = true;
                    #endregion
                }
                else if (rbBOC.Checked)
                {
                    #region
                    cmbPayeeAccount.DvRegCode = "reg648";
                    cmbPayeeAccount.DvMinLength = 1;
                    cmbPayeeAccount.DvMaxLength = 35;
                    cmbPayeeAccount.DvRequired = true;
                    tbPayeeName.DvRegCode = "reg685";
                    tbPayeeName.DvMinLength = 1;
                    tbPayeeName.DvMaxLength = 240;
                    tbPayeeName.DvRequired = true;
                    cmbRemitCountry.DvRequired = false;
                    cmbPayeeAccountType.DvRequired = false;
                    #endregion
                }
                else if (rbOther.Checked)
                {
                    #region
                    cmbPayeeAccount.DvRegCode = "reg648";
                    cmbPayeeAccount.DvMinLength = 1;
                    cmbPayeeAccount.DvMaxLength = 35;
                    cmbPayeeAccount.DvRequired = true;
                    tbPayeeName.DvRegCode = "reg662";
                    tbPayeeName.DvMinLength = 1;
                    tbPayeeName.DvMaxLength = 70;
                    tbPayeeName.DvRequired = true;
                    tbPayeeAddress.DvRegCode = "reg662";
                    tbPayeeAddress.DvMinLength = 0;
                    tbPayeeAddress.DvMaxLength = 140;
                    tbPayeeAddress.DvRequired = false;
                    tbFPayeeOpenBankName.DvRegCode = "reg662";
                    tbFPayeeOpenBankName.DvMinLength = 1;
                    tbFPayeeOpenBankName.DvMaxLength = 140;
                    tbFPayeeOpenBankName.DvRequired = true;
                    tbOSwiftCode.DvRegCode = "reg24";
                    tbOSwiftCode.DvMinLength = 0;
                    tbOSwiftCode.DvMaxLength = 18;
                    tbOSwiftCode.DvRequired = false;
                    tbPayeeOpenBankAddress.DvRegCode = "reg662";
                    tbPayeeOpenBankAddress.DvMinLength = 0;
                    tbPayeeOpenBankAddress.DvMaxLength = 70;

                    tbCorrespondentBankName.DvRegCode = "reg662";
                    tbCorrespondentBankName.DvMinLength = 0;
                    tbCorrespondentBankName.DvMaxLength = 140;
                    tbCorrespondentBankName.DvRequired = false;
                    tbCSwiftCode.DvRegCode = "reg24";
                    tbCSwiftCode.DvMinLength = 0;
                    tbCSwiftCode.DvMaxLength = 18;
                    tbCSwiftCode.DvRequired = false;
                    tbCorrespondentBankAddress.DvRegCode = "reg630";
                    tbCorrespondentBankAddress.DvMinLength = 0;
                    tbCorrespondentBankAddress.DvMaxLength = 280;
                    tbCorrespondentBankAddress.DvRequired = false;
                    tbCorrespondentBankName.DvRegCode = "reg662";
                    tbCorrespondentBankName.DvMinLength = 0;
                    tbCorrespondentBankName.DvMaxLength = 140;
                    tbCorrespondentBankName.DvRequired = false;
                    tbPayeeAccountInCorrespondentBank.DvRegCode = "reg648";
                    tbPayeeAccountInCorrespondentBank.DvMinLength = 0;
                    tbPayeeAccountInCorrespondentBank.DvMaxLength = 35;
                    tbPayeeAccountInCorrespondentBank.DvRequired = false;
                    cmbRemitCountry.DvRequired = false;
                    cmbPayeeAccountType.DvRequired = false;
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
                    cmbPayeeAccount.DvRegCode = "reg705";
                    cmbPayeeAccount.DvMinLength = 1;
                    cmbPayeeAccount.DvMaxLength = 34;
                    cmbPayeeAccount.DvRequired = true;
                    tbPayeeName.DvRegCode = "reg702";
                    tbPayeeName.DvMinLength = 1;
                    tbPayeeName.DvMaxLength = 140;
                    tbPayeeName.DvRequired = true;
                    tbPayeeAddress.DvRegCode = "reg702";
                    tbPayeeAddress.DvMinLength = 0;
                    tbPayeeAddress.DvMaxLength = 140;
                    tbPayeeAddress.DvRequired = false;
                    tbPayeeName.DvRegCode = "Predefined5";
                    tbPayeeName.DvMinLength = 1;
                    tbPayeeName.DvMaxLength = 140;
                    tbPayeeName.DvRequired = true;
                    tbPayeeOpenBankName.DvRegCode = "reg702";
                    tbPayeeOpenBankName.DvMinLength = 1;
                    tbPayeeOpenBankName.DvMaxLength = 140;
                    tbPayeeOpenBankName.DvRequired = true;
                    tbOSwiftCode.DvRegCode = "reg24";
                    tbOSwiftCode.DvMinLength = 0;
                    tbOSwiftCode.DvMaxLength = 18;
                    tbOSwiftCode.DvRequired = false;
                    if (m_appType == AppliableFunctionType.TransferOverCountry)
                    {
                        tbPayeeOpenBankAddress.DvRegCode = "reg702";
                        tbPayeeOpenBankAddress.DvMinLength = 1;
                        tbPayeeOpenBankAddress.DvMaxLength = 140;

                    }
                    else if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                    {
                        tbPayeeOpenBankAddress.DvRegCode = "reg702";
                        tbPayeeOpenBankAddress.DvMinLength = 0;
                        tbPayeeOpenBankAddress.DvMaxLength = 140;

                    }
                    tbCorrespondentBankName.DvRegCode = "reg702";
                    tbCorrespondentBankName.DvMinLength = 0;
                    tbCorrespondentBankName.DvMaxLength = 140;
                    tbCorrespondentBankName.DvRequired = false;
                    tbCSwiftCode.DvRegCode = "reg24";
                    tbCSwiftCode.DvMinLength = 0;
                    tbCSwiftCode.DvMaxLength = 18;
                    tbCSwiftCode.DvRequired = false;
                    tbCorrespondentBankAddress.DvRegCode = "reg702";
                    tbCorrespondentBankAddress.DvMinLength = 0;
                    tbCorrespondentBankAddress.DvMaxLength = 140;
                    tbCorrespondentBankAddress.DvRequired = false;
                    tbPayeeAccountInCorrespondentBank.DvRegCode = "reg702";
                    tbPayeeAccountInCorrespondentBank.DvMinLength = 0;
                    tbPayeeAccountInCorrespondentBank.DvMaxLength = 34;
                    tbPayeeAccountInCorrespondentBank.DvRequired = false;

                }
                else if (m_appType == AppliableFunctionType.TransferForeignMoney
                    || m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    if (rbBOC.Checked)
                    {
                        cmbPayeeAccount.DvRegCode = "reg687";
                        cmbPayeeAccount.DvMinLength = 1;
                        cmbPayeeAccount.DvMaxLength = 20;
                        cmbPayeeAccount.DvRequired = true;
                    }
                    else if (rbOther.Checked)
                    {
                        cmbPayeeAccount.DvRegCode = "reg688";
                        cmbPayeeAccount.DvMinLength = 1;
                        cmbPayeeAccount.DvMaxLength = 32;
                        cmbPayeeAccount.DvRequired = true;
                        tbFPayeeOpenBankName.DvRegCode = "reg662";
                        tbFPayeeOpenBankName.DvMinLength = 1;
                        tbFPayeeOpenBankName.DvMaxLength = 70;
                        tbFPayeeOpenBankName.DvRequired = true;
                        if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                        {
                            tbOSwiftCode.DvRegCode = "reg24";
                            tbOSwiftCode.DvMinLength = 0;
                            tbOSwiftCode.DvMaxLength = 11;
                            tbOSwiftCode.DvRequired = true;
                        }
                    }
                    tbPayeeName.DvRegCode = "reg662";
                    tbPayeeName.DvMinLength = 1;
                    tbPayeeName.DvMaxLength = m_appType == AppliableFunctionType.TransferForeignMoney ? 70 : 64;
                    tbPayeeName.DvRequired = true;
                    tbPayeeAddress.DvRegCode = "reg662";
                    tbPayeeAddress.DvMinLength = 0;
                    tbPayeeAddress.DvMaxLength = m_appType == AppliableFunctionType.TransferForeignMoney ? 70 : 64;
                    tbPayeeAddress.DvRequired = false;
                    if (m_appType != AppliableFunctionType.TransferForeignMoney4Bar || (m_appType == AppliableFunctionType.TransferForeignMoney4Bar && rbOther.Checked))
                    {
                        tbPayeeOpenBankAddress.DvRegCode = "reg662";
                        tbPayeeOpenBankAddress.DvMinLength = 0;
                        tbPayeeOpenBankAddress.DvMaxLength = 70;

                        tbCorrespondentBankName.DvRegCode = "reg662";
                        tbCorrespondentBankName.DvMinLength = 0;
                        tbCorrespondentBankName.DvMaxLength = 70;
                        tbCorrespondentBankName.DvRequired = false;
                    }
                    if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                    {
                        if (rbBOC.Checked)
                        {
                            if (cmbPayeeCertPaperType.SelectedIndex == 1)
                            {
                                edtCertPaperNo.DvRegCode = "reg579";
                                edtCertPaperNo.DvMinLength = 15;
                                edtCertPaperNo.DvMaxLength = 18;
                                edtCertPaperNo.DvRequired = true;
                            }
                            else if (cmbPayeeCertPaperType.SelectedIndex > 1)
                            {
                                edtCertPaperNo.DvRegCode = "Predefined5";
                                edtCertPaperNo.DvMinLength = 1;
                                edtCertPaperNo.DvMaxLength = 32;
                                edtCertPaperNo.DvRequired = true;
                            }
                        }
                        else if (rbOther.Checked)
                        {
                            tbCSwiftCode.DvRegCode = "reg24";
                            tbCSwiftCode.DvMinLength = 0;
                            tbCSwiftCode.DvMaxLength = 18;
                            tbCSwiftCode.DvRequired = false;
                        }
                    }
                    tbCorrespondentBankAddress.DvRegCode = "reg662";
                    tbCorrespondentBankAddress.DvMinLength = 0;
                    tbCorrespondentBankAddress.DvMaxLength = 70;
                    tbCorrespondentBankAddress.DvRequired = false;
                    tbPayeeAccountInCorrespondentBank.DvRegCode = "reg648";
                    tbPayeeAccountInCorrespondentBank.DvMinLength = 0;
                    tbPayeeAccountInCorrespondentBank.DvMaxLength = m_appType == AppliableFunctionType.TransferForeignMoney4Bar ? 34 : 70;
                    tbPayeeAccountInCorrespondentBank.DvRequired = false;
                }
                #endregion
            }
        }
        public void GetItem()
        {
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                #region
                m_UnitivePaymentForeignMoney = new UnitivePaymentForeignMoney();
                if (m_AccountType == OverCountryPayeeAccountType.ForeignAccount)
                {
                    m_UnitivePaymentForeignMoney.FCPayeeAccountType = cmbPayeeAccountType.SelectedIndex == -1 ? UnitiveFCPayeeAccountType.Empty : (cmbPayeeAccountType.Tag as List<UnitiveFCPayeeAccountType>)[cmbPayeeAccountType.SelectedIndex];
                    m_UnitivePaymentForeignMoney.PaymentCountryOrArea = (cmbRemitCountry.Tag as List<Transfer2CountryType>)[cmbRemitCountry.SelectedIndex];
                }
                m_UnitivePaymentForeignMoney.PayeeAccount = cmbPayeeAccount.Text.Trim();
                m_UnitivePaymentForeignMoney.PayeeName = tbPayeeName.Text.Trim();
                m_UnitivePaymentForeignMoney.Address = tbPayeeAddress.Text.Trim();
                m_UnitivePaymentForeignMoney.PayeeAccountType = m_AccountType;
                string str = tbCountry.Text.Trim();
                int index = str.LastIndexOf(" ");
                if (index >= 0)
                {
                    m_UnitivePaymentForeignMoney.NameofCountry = str.Substring(0, index);
                    m_UnitivePaymentForeignMoney.CodeofCountry = str.Substring(index + 1, str.Length - index - 1);
                }
                else
                {
                    m_UnitivePaymentForeignMoney.CodeofCountry = str.Substring(0, str.Length);
                }

                if (m_AccountType == OverCountryPayeeAccountType.ForeignAccount || (m_AccountType != OverCountryPayeeAccountType.ForeignAccount && rbOther.Checked))
                {
                    if (m_AccountType == OverCountryPayeeAccountType.ForeignAccount)
                        m_UnitivePaymentForeignMoney.PayeeOpenBankName = tbPayeeOpenBankName.Text.Trim();
                    else
                        m_UnitivePaymentForeignMoney.PayeeOpenBankName = tbFPayeeOpenBankName.Text.Trim();
                    m_UnitivePaymentForeignMoney.PayeeOpenBankSwiftCode = tbOSwiftCode.Text.Trim();
                    m_UnitivePaymentForeignMoney.OpenBankAddress = tbPayeeOpenBankAddress.Text.Trim();
                    m_UnitivePaymentForeignMoney.CorrespondentBankName = tbCorrespondentBankName.Text.Trim();
                    m_UnitivePaymentForeignMoney.CorrespondentBankSwiftCode = tbCSwiftCode.Text.Trim();
                    m_UnitivePaymentForeignMoney.CorrespondentBankAddress = tbCorrespondentBankAddress.Text.Trim();
                    m_UnitivePaymentForeignMoney.PayeeAccountInCorrespondentBank = tbPayeeAccountInCorrespondentBank.Text.Trim();
                }
                if (m_AccountType != OverCountryPayeeAccountType.ForeignAccount)
                {
                    m_UnitivePaymentForeignMoney.PayeeOpenBankType = rbBOC.Checked ? AccountBankType.BocAccount : AccountBankType.OtherBankAccount;
                    if (rbBOC.Checked) m_UnitivePaymentForeignMoney.PayeeOpenBankName = m_UnitivePaymentForeignMoney.PayeeOpenBankTypeString;
                }
                #endregion
            }
            else
            {
                #region
                m_TransferGlobal = new TransferGlobal();
                m_TransferGlobal.PayeeAccount = cmbPayeeAccount.Text.Trim();
                m_TransferGlobal.PayeeName = tbPayeeName.Text.Trim();
                m_TransferGlobal.PayeeAddress = tbPayeeAddress.Text.Trim();

                string str = tbCountry.Text.Trim();
                int index = str.LastIndexOf(" ");
                if (index >= 0)
                {
                    m_TransferGlobal.PayeeNameofCountry = str.Substring(0, index);
                    m_TransferGlobal.PayeeCodeofCountry = str.Substring(index + 1, str.Length - index - 1);
                }

                if (m_appType == AppliableFunctionType.TransferOverCountry
                    || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                    m_TransferGlobal.PayeeOpenBankName = tbPayeeOpenBankName.Text.Trim();
                else if (m_appType == AppliableFunctionType.TransferForeignMoney
                    || m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    m_TransferGlobal.PayeeOpenBankType = rbBOC.Checked ? AccountBankType.BocAccount : AccountBankType.OtherBankAccount;
                    if (rbBOC.Checked)
                    {
                        m_TransferGlobal.PayeeOpenBankName = m_TransferGlobal.PayeeOpenBankTypeString;
                        if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                        {
                            m_TransferGlobal.Province = (cmbPayeeAccountProvince.Tag as List<ChinaProvinceType>)[cmbPayeeAccountProvince.SelectedIndex];
                            m_TransferGlobal.CertifyPaperType = cmbPayeeCertPaperType.SelectedIndex <= 0 ? AgentExpressCertifyPaperType.Empty : (cmbPayeeCertPaperType.Tag as List<AgentExpressCertifyPaperType>)[cmbPayeeCertPaperType.SelectedIndex - 1];
                            if (m_TransferGlobal.CertifyPaperType != AgentExpressCertifyPaperType.Empty)
                                m_TransferGlobal.CertifyPaperNo = edtCertPaperNo.Text.Trim();
                            m_TransferGlobal.AgentFunctionType_Express = cbNoticeType.SelectedIndex < 0 ? AgentExpressFunctionType.Empty : (cbNoticeType.Tag as List<AgentExpressFunctionType>)[cbNoticeType.SelectedIndex];
                        }
                    }
                    else m_TransferGlobal.PayeeOpenBankName = tbFPayeeOpenBankName.Text.Trim();
                }
                m_TransferGlobal.PayeeOpenBankSwiftCode = tbOSwiftCode.Text.Trim();
                m_TransferGlobal.PayeeOpenBankAddress = tbPayeeOpenBankAddress.Text.Trim();
                m_TransferGlobal.CorrespondentBankName = tbCorrespondentBankName.Text.Trim();
                m_TransferGlobal.CorrespondentBankSwiftCode = tbCSwiftCode.Text.Trim();
                m_TransferGlobal.CorrespondentBankAddress = tbCorrespondentBankAddress.Text.Trim();
                m_TransferGlobal.PayeeAccountInCorrespondentBank = tbPayeeAccountInCorrespondentBank.Text.Trim();

                SavePayee = chbSave.Checked;
                #endregion
            }
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                if (string.IsNullOrEmpty(tbCountry.Text.Trim()))
                { tbCountry.DvErrorProvider.SetError(tbCountry, MultiLanguageConvertHelper.Information_Please_Input); rd.Result = false; }
            }
            else
            {
                if (m_appType != AppliableFunctionType.TransferForeignMoney4Bar || (m_appType == AppliableFunctionType.TransferForeignMoney4Bar && rbOther.Checked))
                {
                    if (string.IsNullOrEmpty(tbCountry.Text.Trim()))
                    { tbCountry.DvErrorProvider.SetError(tbCountry, MultiLanguageConvertHelper.Information_Please_Input); rd.Result = false; }
                }
            }
            //if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            //{

            //    if (m_AccountType == OverCountryPayeeAccountType.ForeignAccount)
            //    {
            //        #region
            //        if (cmbRemitCountry.SelectedIndex < 0)
            //        { this.errorProvider1.SetError(cmbRemitCountry, string.Format("{0} {1}", MultiLanguageConvertHelper.DesignMain_Please_Selection, lbRemitCountry.Text.Substring(0, lbRemitCountry.Text.Length - 1))); return false; }
            //        if (cmbPayeeAccountType.SelectedIndex < 0)
            //        { this.errorProvider1.SetError(cmbPayeeAccountType, string.Format("{0} {1}", MultiLanguageConvertHelper.DesignMain_Please_Selection, lbPayeeAccountType.Text.Substring(0, lbPayeeAccountType.Text.Length - 1))); return false; }

            //        rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(cmbPayeeAccount, cmbPayeeAccount.Text.Trim(), lbPayeeAccount.Text.Substring(0, lbPayeeAccount.Text.Length - 1), 34, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbPayeeName, tbPayeeName.Text.Trim(), lbPayeeName.Text.Substring(0, lbPayeeName.Text.Length - 1), 140, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        if (!string.IsNullOrEmpty(tbPayeeAddress.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbPayeeAddress, tbPayeeAddress.Text.Trim(), lbPayeeAddress.Text.Substring(0, lbPayeeAddress.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbPayeeOpenBankName, tbPayeeOpenBankName.Text.Trim(), lbPayeeOpenBankName.Text.Substring(0, lbPayeeOpenBankName.Text.Length - 1), 140, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        if (!string.IsNullOrEmpty(tbOSwiftCode.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckSwiftCodeFC(tbOSwiftCode, tbOSwiftCode.Text.Trim(), lbFSwiftCode.Text.Substring(0, lbFSwiftCode.Text.Length - 1), this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbPayeeOpenBankAddress.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbPayeeOpenBankAddress, tbPayeeOpenBankAddress.Text.Trim(), lbPayeeOpenBankAddress.Text.Substring(0, lbPayeeOpenBankAddress.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCorrespondentBankName.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbCorrespondentBankName, tbCorrespondentBankName.Text.Trim(), lbCorrespondentBankName.Text.Substring(0, lbCorrespondentBankName.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCSwiftCode.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckSwiftCodeFC(tbCSwiftCode, tbCSwiftCode.Text.Trim(), lbCSwiftCode.Text.Substring(0, lbCSwiftCode.Text.Length - 1), this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCorrespondentBankAddress.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckCountryName(tbCorrespondentBankAddress, tbCorrespondentBankAddress.Text.Trim(), lbCorrespondentBankAddress.Text.Substring(0, lbCorrespondentBankAddress.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCorrespondentBankName.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbCorrespondentBankName, tbCorrespondentBankName.Text.Trim(), lbCorrespondentBankName.Text.Substring(0, lbCorrespondentBankName.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbPayeeAccountInCorrespondentBank.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeAccountUP(tbPayeeAccountInCorrespondentBank, tbPayeeAccountInCorrespondentBank.Text.Trim(), lbPayeeAccountInCorrespondentBank.Text.Substring(0, lbPayeeAccountInCorrespondentBank.Text.Length - 1), 35, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //}
            //if (string.IsNullOrEmpty(tbCountry.Text.Trim()))
            //{ MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_PayeeCountry), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        rd = DataCheckCenter.CheckNameAndAddressLengthGJ(tbPayeeName, tbPayeeName.Text.Trim(), tbPayeeAddress.Text.Trim(), lbPayeeName.Text.Substring(0, lbPayeeName.Text.Length - 1), lbPayeeAddress.Text.Substring(0, lbPayeeAddress.Text.Length - 1), 140, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        if (!string.IsNullOrEmpty(tbCorrespondentBankName.Text) || !string.IsNullOrEmpty(tbCorrespondentBankAddress.Text))
            //        {
            //            rd = DataCheckCenter.CheckNameAndAddressLengthGJ(tbCorrespondentBankName, tbCorrespondentBankName.Text.Trim(), tbCorrespondentBankAddress.Text.Trim(), lbCorrespondentBankName.Text.Substring(0, lbCorrespondentBankName.Text.Length - 1), lbCorrespondentBankAddress.Text.Substring(0, lbCorrespondentBankAddress.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        #endregion
            //}
            //else if (rbBOC.Checked)
            //{
            //        #region
            //        rd = DataCheckCenter.CheckElecTicketPersonAccountFC(cmbPayeeAccount, cmbPayeeAccount.Text.Trim(), lbPayeeAccount.Text.Substring(0, lbPayeeAccount.Text.Length - 1), 35, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        rd = DataCheckCenter.CheckPayeeNameAgentInOrUP(tbPayeeName, tbPayeeName.Text.Trim(), lbPayeeName.Text.Substring(0, lbPayeeName.Text.Length - 1), 240, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //if (string.IsNullOrEmpty(tbCountry.Text.Trim()))
            //{ MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_PayeeCountry), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        #endregion
            //}
            //else if (rbOther.Checked)
            //{
            //        #region
            //        rd = DataCheckCenter.CheckElecTicketPersonAccountFC(cmbPayeeAccount, cmbPayeeAccount.Text.Trim(), lbPayeeAccount.Text.Substring(0, lbPayeeAccount.Text.Length - 1), 35, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbPayeeName, tbPayeeName.Text.Trim(), lbPayeeName.Text.Substring(0, lbPayeeName.Text.Length - 1), 70, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        if (!string.IsNullOrEmpty(tbPayeeAddress.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbPayeeAddress, tbPayeeAddress.Text.Trim(), lbPayeeAddress.Text.Substring(0, lbPayeeAddress.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbFPayeeOpenBankName, tbFPayeeOpenBankName.Text.Trim(), lbPayeeOpenBankName.Text.Substring(0, lbPayeeOpenBankName.Text.Length - 1), 140, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        if (!string.IsNullOrEmpty(tbOSwiftCode.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckSwiftCode(tbOSwiftCode, tbOSwiftCode.Text.Trim(), lbFSwiftCode.Text.Substring(0, lbFSwiftCode.Text.Length - 1), this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbPayeeOpenBankAddress.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbPayeeOpenBankAddress, tbPayeeOpenBankAddress.Text.Trim(), lbPayeeOpenBankAddress.Text.Substring(0, lbPayeeOpenBankAddress.Text.Length - 1), 70, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCorrespondentBankName.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbCorrespondentBankName, tbCorrespondentBankName.Text.Trim(), lbCorrespondentBankName.Text.Substring(0, lbCorrespondentBankName.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCSwiftCode.Text))
            //        {
            //            rd = DataCheckCenter.CheckSwiftCode(tbCSwiftCode, tbCSwiftCode.Text.Trim(), lbCSwiftCode.Text.Substring(0, lbCSwiftCode.Text.Length - 1), this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCorrespondentBankAddress.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckCountryName(tbCorrespondentBankAddress, tbCorrespondentBankAddress.Text.Trim(), lbCorrespondentBankAddress.Text.Substring(0, lbCorrespondentBankAddress.Text.Length - 1), 280, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCorrespondentBankName.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbCorrespondentBankName, tbCorrespondentBankName.Text.Trim(), lbCorrespondentBankName.Text.Substring(0, lbCorrespondentBankName.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbPayeeAccountInCorrespondentBank.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeAccountInCorrespondentBankGJ(tbPayeeAccountInCorrespondentBank, tbPayeeAccountInCorrespondentBank.Text.Trim(), lbPayeeAccountInCorrespondentBank.Text.Substring(0, lbPayeeAccountInCorrespondentBank.Text.Length - 1), 35, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //if (string.IsNullOrEmpty(tbCountry.Text.Trim()))
            //{ MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_PayeeCountry), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //        if (!string.IsNullOrEmpty(tbPayeeName.Text.Trim()) || !string.IsNullOrEmpty(tbPayeeAddress.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckNameAndAddressLengthGJ(tbPayeeName, tbPayeeName.Text.Trim(), tbPayeeAddress.Text.Trim(), lbPayeeName.Text.Substring(0, lbPayeeName.Text.Length - 1), lbPayeeAddress.Text.Substring(0, lbPayeeAddress.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCorrespondentBankName.Text.Trim()) || !string.IsNullOrEmpty(tbCorrespondentBankAddress.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckNameAndAddressLengthGJ(tbCorrespondentBankName, tbCorrespondentBankName.Text.Trim(), tbCorrespondentBankAddress.Text.Trim(), lbCorrespondentBankName.Text.Substring(0, lbCorrespondentBankName.Text.Length - 1), lbCorrespondentBankAddress.Text.Substring(0, lbCorrespondentBankAddress.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            // }
            //        #endregion
            //}
            //    #endregion
            //}
            //else //国结和柜台
            //{
            //    #region
            //if (m_appType == AppliableFunctionType.TransferOverCountry
            //    || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            //{
            //        rd = DataCheckCenter.CheckPayeeAccountGJ(cmbPayeeAccount, cmbPayeeAccount.Text.Trim(), lbPayeeAccount.Text.Substring(0, lbPayeeAccount.Text.Length - 1), 34, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbPayeeName, tbPayeeName.Text.Trim(), lbPayeeName.Text.Substring(0, lbPayeeName.Text.Length - 1), 140, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        if (!string.IsNullOrEmpty(tbPayeeAddress.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbPayeeAddress, tbPayeeAddress.Text.Trim(), lbPayeeAddress.Text.Substring(0, lbPayeeAddress.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        rd = DataCheckCenter.CheckNameAndAddressLengthGJ(tbPayeeName, tbPayeeName.Text.Trim(), tbPayeeAddress.Text.Trim(), lbPayeeName.Text.Substring(0, lbPayeeName.Text.Length - 1), lbPayeeAddress.Text.Substring(0, lbPayeeAddress.Text.Length - 1), 140, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbPayeeOpenBankName, tbPayeeOpenBankName.Text.Trim(), lbPayeeOpenBankName.Text.Substring(0, lbPayeeOpenBankName.Text.Length - 1), 140, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //        if (!string.IsNullOrEmpty(tbOSwiftCode.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckSwiftCode(tbOSwiftCode, tbOSwiftCode.Text.Trim(), lbFSwiftCode.Text.Substring(0, lbFSwiftCode.Text.Length - 1), this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (m_appType == AppliableFunctionType.TransferOverCountry)
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbPayeeOpenBankAddress, tbPayeeOpenBankAddress.Text.Trim(), lbPayeeOpenBankAddress.Text.Substring(0, lbPayeeOpenBankAddress.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        else if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            //        {
            //            if (!string.IsNullOrEmpty(tbPayeeOpenBankAddress.Text))
            //            {
            //                rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbPayeeOpenBankAddress, tbPayeeOpenBankAddress.Text.Trim(), lbPayeeOpenBankAddress.Text.Substring(0, lbPayeeOpenBankAddress.Text.Length - 1), 140, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //        }
            //        if (!string.IsNullOrEmpty(tbPayeeOpenBankName.Text) || !string.IsNullOrEmpty(tbPayeeOpenBankAddress.Text))
            //        {
            //            rd = DataCheckCenter.CheckNameAndAddressLengthGJ(tbPayeeOpenBankName, tbPayeeOpenBankName.Text.Trim(), tbPayeeOpenBankAddress.Text.Trim(), lbPayeeOpenBankName.Text.Substring(0, lbPayeeOpenBankName.Text.Length - 1), lbPayeeOpenBankAddress.Text.Substring(0, lbPayeeOpenBankAddress.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCorrespondentBankName.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbCorrespondentBankName, tbCorrespondentBankName.Text.Trim(), lbCorrespondentBankName.Text.Substring(0, lbCorrespondentBankName.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCSwiftCode.Text))
            //        {
            //            rd = DataCheckCenter.CheckSwiftCode(tbCSwiftCode, tbCSwiftCode.Text.Trim(), lbCSwiftCode.Text.Substring(0, lbCSwiftCode.Text.Length - 1), this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCorrespondentBankAddress.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbCorrespondentBankAddress, tbCorrespondentBankAddress.Text.Trim(), lbCorrespondentBankAddress.Text.Substring(0, lbCorrespondentBankAddress.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbCorrespondentBankName.Text) || !string.IsNullOrEmpty(tbCorrespondentBankAddress.Text))
            //        {
            //            rd = DataCheckCenter.CheckNameAndAddressLengthGJ(tbCorrespondentBankName, tbCorrespondentBankName.Text.Trim(), tbCorrespondentBankAddress.Text.Trim(), lbCorrespondentBankName.Text.Substring(0, lbCorrespondentBankName.Text.Length - 1), lbCorrespondentBankAddress.Text.Substring(0, lbCorrespondentBankAddress.Text.Length - 1), 140, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (!string.IsNullOrEmpty(tbPayeeAccountInCorrespondentBank.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbPayeeAccountInCorrespondentBank, tbPayeeAccountInCorrespondentBank.Text.Trim(), lbPayeeAccountInCorrespondentBank.Text.Substring(0, lbPayeeAccountInCorrespondentBank.Text.Length - 1), 34, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }

            //}
            //    else if (m_appType == AppliableFunctionType.TransferForeignMoney
            //        || m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            //    {
            //        if (rbBOC.Checked)
            //        {
            //            rd = DataCheckCenter.CheckPayeeAccountGJEx(cmbPayeeAccount, cmbPayeeAccount.Text.Trim(), lbPayeeAccount.Text.Substring(0, lbPayeeAccount.Text.Length - 1), 20, true, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        else if (rbOther.Checked)
            //        {
            //            rd = DataCheckCenter.CheckPayeeAccountGJEx(cmbPayeeAccount, cmbPayeeAccount.Text.Trim(), lbPayeeAccount.Text.Substring(0, lbPayeeAccount.Text.Length - 1), 32, false, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbPayeeName, tbPayeeName.Text.Trim(), lbPayeeName.Text.Substring(0, lbPayeeName.Text.Length - 1), m_appType == AppliableFunctionType.TransferForeignMoney ? 70 : 64, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;

            //        if (!string.IsNullOrEmpty(tbPayeeAddress.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbPayeeAddress, tbPayeeAddress.Text.Trim(), lbPayeeAddress.Text.Substring(0, lbPayeeAddress.Text.Length - 1), m_appType == AppliableFunctionType.TransferForeignMoney ? 70 : 64, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //        if (rbOther.Checked)
            //        {
            //            rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbFPayeeOpenBankName, tbFPayeeOpenBankName.Text.Trim(), lbPayeeOpenBankName.Text.Substring(0, lbPayeeOpenBankName.Text.Length - 1), 70, this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //            if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            //            {
            //                if (!string.IsNullOrEmpty(tbOSwiftCode.Text))
            //                {
            //                    rd = DataCheckCenter.CheckSwiftCodeFMBar(tbOSwiftCode, tbOSwiftCode.Text.Trim(), lbFSwiftCode.Text.Substring(0, lbFSwiftCode.Text.Length - 1), this.errorProvider1);
            //                    if (!rd.Result) return rd.Result;
            //                }
            //            }
            //        }
            //        if (m_appType != AppliableFunctionType.TransferForeignMoney4Bar || (m_appType == AppliableFunctionType.TransferForeignMoney4Bar && rbOther.Checked))
            //        {
            //            if (!string.IsNullOrEmpty(tbPayeeOpenBankAddress.Text))
            //            {
            //                rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbPayeeOpenBankAddress, tbPayeeOpenBankAddress.Text.Trim(), lbPayeeOpenBankAddress.Text.Substring(0, lbPayeeOpenBankAddress.Text.Length - 1), 70, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }

            //            if (!string.IsNullOrEmpty(tbCorrespondentBankName.Text.Trim()))
            //            {
            //                rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbCorrespondentBankName, tbCorrespondentBankName.Text.Trim(), lbCorrespondentBankName.Text.Substring(0, lbCorrespondentBankName.Text.Length - 1), 70, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //        }
            //        if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            //        {
            //            if (rbBOC.Checked)
            //            {
            //                if (cmbPayeeAccountProvince.SelectedIndex < 0)
            //                { this.errorProvider1.SetError(cmbPayeeAccountProvince, string.Format("{0}{1}", MultiLanguageConvertHelper.DesignMain_Please_Selection, lbProvince.Text.Substring(0, lbProvince.Text.Length - 1))); return false; }
            //                if (cmbPayeeCertPaperType.SelectedIndex == 1)
            //                {
            //                    rd = DataCheckCenter.CheckCertifyCardNo(edtCertPaperNo, edtCertPaperNo.Text.Trim(), cmbPayeeCertPaperType.Text.Trim(), true, this.errorProvider1);
            //                    if (!rd.Result) return rd.Result;
            //                }
            //                else if (cmbPayeeCertPaperType.SelectedIndex > 1)
            //                {
            //                    rd = DataCheckCenter.CheckCertifyCardNo(edtCertPaperNo, edtCertPaperNo.Text, cmbPayeeCertPaperType.Text.Trim(), this.errorProvider1);
            //                    if (!rd.Result) return rd.Result;
            //                }
            //                if (cbNoticeType.SelectedIndex < 0)
            //                {
            //                    this.errorProvider1.SetError(cbNoticeType, string.Format("{0}{1}", MultiLanguageConvertHelper.DesignMain_Please_Selection, lbNoticeType.Text.Substring(0, lbNoticeType.Text.Length - 1))); return false;
            //                }
            //            }
            //            else if (rbOther.Checked)
            //            {
            //                if (!string.IsNullOrEmpty(tbCSwiftCode.Text))
            //                {
            //                    rd = DataCheckCenter.CheckSwiftCode(tbCSwiftCode, tbCSwiftCode.Text.Trim(), lbCSwiftCode.Text.Substring(0, lbCSwiftCode.Text.Length - 1), this.errorProvider1);
            //                    if (!rd.Result) return rd.Result;
            //                }
            //            }
            //            if (!string.IsNullOrEmpty(tbCorrespondentBankAddress.Text.Trim()))
            //            {
            //                rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbCorrespondentBankAddress, tbCorrespondentBankAddress.Text.Trim(), lbCorrespondentBankAddress.Text.Substring(0, lbCorrespondentBankAddress.Text.Length - 1), 70, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //            if (!string.IsNullOrEmpty(tbPayeeAccountInCorrespondentBank.Text.Trim()))
            //            {
            //                rd = DataCheckCenter.CheckPayeeAccountInCorrespondentBankGJ(tbPayeeAccountInCorrespondentBank, tbPayeeAccountInCorrespondentBank.Text.Trim(), lbPayeeAccountInCorrespondentBank.Text.Substring(0, lbPayeeAccountInCorrespondentBank.Text.Length - 1), m_appType == AppliableFunctionType.TransferForeignMoney4Bar ? 34 : 70, this.errorProvider1);
            //                if (!rd.Result) return rd.Result;
            //            }
            //        }
            //    }
            //    if (m_appType != AppliableFunctionType.TransferForeignMoney4Bar || (m_appType == AppliableFunctionType.TransferForeignMoney4Bar && rbOther.Checked))
            //    {
            //        if (string.IsNullOrEmpty(tbCountry.Text.Trim()))
            //        { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_PayeeCountry), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //    }
            //    #endregion
            //}
            return rd.Result;
        }

        private void SetItem(object item)
        {
            if (null == item)
            {
                #region
                cmbPayeeAccount.SelectedIndex = -1;
                cmbPayeeAccount.Text = string.Empty;
                //if (cmbPayeeAccount.Items.Count > 0) cmbPayeeAccount.SelectedIndex = 0;
                tbPayeeName.Text =
                tbPayeeAddress.Text =
                tbPayeeOpenBankName.Text =
                tbPayeeOpenBankAddress.Text =
                tbFPayeeOpenBankName.Text =
                tbOSwiftCode.Text =
                tbCountry.Text =
                tbCorrespondentBankName.Text =
                tbCorrespondentBankAddress.Text =
                tbPayeeAccountInCorrespondentBank.Text =
                tbCSwiftCode.Text = string.Empty;
                if (m_appType != AppliableFunctionType.TransferForeignMoney4Bar && m_appType != AppliableFunctionType.UnitivePaymentFC)
                {
                    rbBOC.Checked = true;
                    rbOther.Checked = !rbBOC.Checked;
                }

                if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                {
                    if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                        tbCountry.Text = EnumNameHelper<CountryHelper>.GetEnumDescription(CountryHelper.CHN) + " " + CountryHelper.CHN.ToString();
                    else tbCountry.Text = string.Empty;
                    rbBOC.Enabled = m_appType == AppliableFunctionType.TransferForeignMoney4Bar;
                    if (cmbPayeeAccountProvince.Items.Count > 0) cmbPayeeAccountProvince.SelectedIndex = 0;
                    edtCertPaperNo.Text = string.Empty;
                }
                else if (m_appType == AppliableFunctionType.UnitivePaymentFC)
                {
                    cmbRemitCountry.SelectedIndex = cmbPayeeAccountType.SelectedIndex = -1;
                }
                #endregion
            }
            else
            {
                if (m_appType == AppliableFunctionType.UnitivePaymentFC)
                {
                    #region
                    UnitivePaymentForeignMoney data = (UnitivePaymentForeignMoney)item;
                    cmbPayeeAccount.Text = data.PayeeAccount;
                    tbPayeeName.Text = data.PayeeName;
                    tbPayeeAddress.Text = data.Address;
                    tbCountry.Text = data.PayeeCountry;

                    if (data.PayeeAccountType == OverCountryPayeeAccountType.ForeignAccount)
                    {
                        tbPayeeOpenBankName.Text = data.PayeeOpenBankName;
                        tbOSwiftCode.Text = data.PayeeOpenBankSwiftCode;
                        tbPayeeOpenBankAddress.Text = data.OpenBankAddress;
                        tbCorrespondentBankName.Text = data.CorrespondentBankName;
                        tbCSwiftCode.Text = data.CorrespondentBankSwiftCode;
                        tbCorrespondentBankAddress.Text = data.CorrespondentBankAddress;
                        tbPayeeAccountInCorrespondentBank.Text = data.PayeeAccountInCorrespondentBank;
                        cmbRemitCountry.SelectedIndex = cmbRemitCountry.Items.Count > 0 ? (cmbRemitCountry.Tag as List<Transfer2CountryType>).FindIndex(o => o == data.PaymentCountryOrArea) : -1;
                        cmbPayeeAccountType.SelectedIndex = cmbPayeeAccountType.Items.Count > 0 ? (cmbPayeeAccountType.Tag as List<UnitiveFCPayeeAccountType>).FindIndex(o => o == data.FCPayeeAccountType) : -1;
                    }
                    else
                    {
                        rbBOC.Checked = data.PayeeAccountType == OverCountryPayeeAccountType.BocAccount;
                        rbOther.Checked = !rbBOC.Checked;
                        if (rbOther.Checked)
                        {
                            tbFPayeeOpenBankName.Text = data.PayeeOpenBankName;
                            tbOSwiftCode.Text = data.PayeeOpenBankSwiftCode;
                            tbPayeeOpenBankAddress.Text = data.OpenBankAddress;
                            tbCorrespondentBankName.Text = data.CorrespondentBankName;
                            tbCSwiftCode.Text = data.CorrespondentBankSwiftCode;
                            tbCorrespondentBankAddress.Text = data.CorrespondentBankAddress;
                            tbPayeeAccountInCorrespondentBank.Text = data.PayeeAccountInCorrespondentBank;
                        }
                    }
                    #endregion
                }
                else
                {
                    #region
                    TransferGlobal data = (TransferGlobal)item;
                    cmbPayeeAccount.Text = data.PayeeAccount;
                    tbPayeeName.Text = data.PayeeName;
                    tbPayeeAddress.Text = data.PayeeAddress;
                    if (m_appType == AppliableFunctionType.TransferOverCountry
                        || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                        tbPayeeOpenBankName.Text = data.PayeeOpenBankName;
                    else if (m_appType == AppliableFunctionType.TransferForeignMoney
                        || m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                    {
                        rbBOC.Checked = data.PayeeOpenBankType == AccountBankType.BocAccount;
                        rbOther.Checked = !rbBOC.Checked;
                        tbFPayeeOpenBankName.Text = data.PayeeOpenBankName;
                        if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.BocAccount)
                        {
                            cmbPayeeAccountProvince.SelectedIndex = (cmbPayeeAccountProvince.Tag as List<ChinaProvinceType>).FindIndex(o => o == data.Province);
                            cmbPayeeCertPaperType.SelectedIndex = (cmbPayeeCertPaperType.Tag as List<AgentExpressCertifyPaperType>).FindIndex(o => o == data.CertifyPaperType) + 1;
                            edtCertPaperNo.Text = data.CertifyPaperNo;
                            int index = (cbNoticeType.Tag as List<AgentExpressFunctionType>).FindIndex(o => o == data.AgentFunctionType_Express);
                            cbNoticeType.SelectedIndex = index;
                        }
                    }
                    tbOSwiftCode.Text = data.PayeeOpenBankSwiftCode;
                    tbPayeeOpenBankAddress.Text = data.PayeeOpenBankAddress;
                    tbCountry.Text = data.PayeeCountry;
                    tbCorrespondentBankName.Text = data.CorrespondentBankName;
                    tbCSwiftCode.Text = data.CorrespondentBankSwiftCode;
                    tbCorrespondentBankAddress.Text = data.CorrespondentBankAddress;
                    tbPayeeAccountInCorrespondentBank.Text = data.PayeeAccountInCorrespondentBank;
                    #endregion
                }
            }
        }

        private void btnQueryPayee_Click(object sender, EventArgs e)
        {
            OverCountryPayeeAccountType pat = (m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferOverCountry4Bar) ? OverCountryPayeeAccountType.ForeignAccount : (m_appType == AppliableFunctionType.TransferForeignMoney || m_appType == AppliableFunctionType.TransferForeignMoney4Bar) ? rbBOC.Checked ? OverCountryPayeeAccountType.BocAccount : OverCountryPayeeAccountType.OtherAccount : OverCountryPayeeAccountType.Empty;
            if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                if (m_AccountType == OverCountryPayeeAccountType.ForeignAccount) pat = m_AccountType;
                else pat = rbBOC.Checked ? OverCountryPayeeAccountType.BocAccount : OverCountryPayeeAccountType.OtherAccount;
            }
            wndPayeeQuery frm = new wndPayeeQuery(pat, cmbPayeeAccount.Text, tbPayeeName.Text);
            if (frm.ShowDialog() != DialogResult.OK) return;
            cmbPayeeAccount.Text = frm.PayeeTransferCountry.Account;
            tbPayeeName.Text = frm.PayeeTransferCountry.Name;
            tbPayeeAddress.Text = frm.PayeeTransferCountry.Address;
            tbCountry.Text = frm.PayeeTransferCountry.Country;

            cmbPayeeAccount.ManualValidate();
            tbPayeeName.ManualValidate();
            tbPayeeAddress.ManualValidate();

            if (m_appType == AppliableFunctionType.TransferOverCountry
                || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                tbPayeeOpenBankName.Text = frm.PayeeTransferCountry.OpenBankName;
                tbPayeeOpenBankName.ManualValidate();
            }
            else if (m_appType == AppliableFunctionType.TransferForeignMoney
                || m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                rbBOC.Checked = frm.PayeeTransferCountry.OpenBankType == AccountBankType.BocAccount;
                rbOther.Checked = !rbBOC.Checked;
            }
            else if (m_appType == AppliableFunctionType.UnitivePaymentFC)
            {
                if (m_AccountType == OverCountryPayeeAccountType.ForeignAccount)
                {
                    tbPayeeOpenBankName.Text = frm.PayeeTransferCountry.OpenBankName;
                    tbPayeeOpenBankName.ManualValidate();
                }
                else if (rbOther.Checked)
                {
                    tbFPayeeOpenBankName.Text = frm.PayeeTransferCountry.OpenBankName;
                    tbFPayeeOpenBankName.ManualValidate();
                }
            }
            tbPayeeOpenBankAddress.Text = frm.PayeeTransferCountry.OpenBankAddress;
            tbCorrespondentBankName.Text = frm.PayeeTransferCountry.CorrespondentBankName;
            tbCorrespondentBankAddress.Text = frm.PayeeTransferCountry.CorrespondentBankAddress;
            tbPayeeAccountInCorrespondentBank.Text = frm.PayeeTransferCountry.AccountInCorrespondentBank;

            tbPayeeOpenBankAddress.ManualValidate();
            tbCorrespondentBankName.ManualValidate();
            tbCorrespondentBankAddress.ManualValidate();
            tbPayeeAccountInCorrespondentBank.ManualValidate();

            if (null != frm)
                frm.Close();
        }

        private void btnQueryBank_Click(object sender, EventArgs e)
        {
            string bankname = ((ThemedButton)sender).Name.Equals(btnQueryOpenBank.Name)
                            ? tbPayeeOpenBankName.Text
                            : ((ThemedButton)sender).Name.Equals(btnFPayeeOpenBankName.Name)
                                ? tbFPayeeOpenBankName.Text
                                : ((ThemedButton)sender).Name.Equals(btnQueryCorrespondentBank.Name)
                                    ? tbCorrespondentBankName.Text
                                    : string.Empty;
            string bankno = ((ThemedButton)sender).Name.Equals(btnQueryOpenBank.Name) || ((ThemedButton)sender).Name.Equals(btnFPayeeOpenBankName.Name)
                                ? tbOSwiftCode.Text
                                : ((ThemedButton)sender).Name.Equals(btnQueryCorrespondentBank.Name)
                                    ? tbCSwiftCode.Text
                                    : string.Empty;
            frmOpenBankQuery frm = new frmOpenBankQuery(bankname, bankno);
            if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                frm.AppType = m_appType;
                frm.IsOpenBank = ((ThemedButton)sender).Name.Equals(btnFPayeeOpenBankName.Name) || ((ThemedButton)sender).Name.Equals(btnQueryOpenBank.Name);
            }
            if (frm.ShowDialog() != DialogResult.OK) return;
            if (((ThemedButton)sender).Name.Equals(btnQueryOpenBank.Name))
            {
                tbPayeeOpenBankName.Text = frm.QueryDialogResult.Name;
                tbOSwiftCode.Text = frm.QueryDialogResult.Code;
                tbPayeeOpenBankAddress.Text = frm.QueryDialogResult.Addr;

                tbPayeeOpenBankName.ManualValidate();
                tbOSwiftCode.ManualValidate();
                tbPayeeOpenBankAddress.ManualValidate();
            }
            else if (((ThemedButton)sender).Name.Equals(btnFPayeeOpenBankName.Name))
            {
                tbFPayeeOpenBankName.Text = frm.QueryDialogResult.Name;
                tbOSwiftCode.Text = frm.QueryDialogResult.Code;
                tbPayeeOpenBankAddress.Text = frm.QueryDialogResult.Addr;

                tbFPayeeOpenBankName.ManualValidate();
                tbOSwiftCode.ManualValidate();
                tbPayeeOpenBankAddress.ManualValidate();
            }
            else if (((ThemedButton)sender).Name.Equals(btnQueryCorrespondentBank.Name))
            {
                tbCorrespondentBankName.Text = frm.QueryDialogResult.Name;
                tbCSwiftCode.Text = frm.QueryDialogResult.Code;
                tbCorrespondentBankAddress.Text = frm.QueryDialogResult.Addr;

                tbCorrespondentBankName.ManualValidate();
                tbCSwiftCode.ManualValidate();
                tbCorrespondentBankAddress.ManualValidate();
            }

            if (null != frm)
                frm.Close();
        }

        private void btnQueryCountry_Click(object sender, EventArgs e)
        {
            frmCountryQuery frm = new frmCountryQuery();
            if (frm.ShowDialog() != DialogResult.OK) return;
            tbCountry.Text = string.Format("{0} {1}", frm.QueryResult.Name, frm.QueryResult.Code);

            if (null != frm)
                frm.Close();
        }

        private void cmbPayeeAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (m_appType != AppliableFunctionType.TransferOverCountry4Bar) return;
            if ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)
            {
                e.KeyChar = (char)((int)e.KeyChar - 32);
            }
        }
    }
}
