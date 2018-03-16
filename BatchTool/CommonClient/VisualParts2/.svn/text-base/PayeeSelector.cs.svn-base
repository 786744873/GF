using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.VisualParts;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.Utilities;
using CommonClient.ConvertHelper;

namespace CommonClient.VisualParts2
{
    public partial class PayeeSelector : BaseUc
    {
        [Browsable(false)]
        public PayeeInfo CurrentPayee
        {
            get
            {
                return m_payee;
            }
            set { m_payee = value; }
        }
        [Browsable(true)]
        public AccountCategoryType AccountType
        {
            get { return m_AccountType; }
            set { m_AccountType = value; }
        }
        private PayeeInfo m_payee = new PayeeInfo();
        private AccountCategoryType m_AccountType = AccountCategoryType.Empty;
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                m_AppType = value;
                Init();
            }
        }
        private AppliableFunctionType m_AppType = EnumTypes.AppliableFunctionType._Empty;
        public bool isNew = false;
        private AccountBankType m_BankType = AccountBankType.Empty;
        [Browsable(true)]
        public AccountBankType BankType
        {
            get { return m_BankType; }
            set { m_BankType = value; }
        }

        private void Init()
        {
            lblPayeeEmail.Visible = edtPayeeEmail.Visible = false;
            tbcnaps.Enabled = tbcnaps.DvRequired = false;
            pbTip.Visible = m_AppType != AppliableFunctionType.TransferOverBankIn;
            if (m_AppType == EnumTypes.AppliableFunctionType.TransferOverBankIn || m_AppType == EnumTypes.AppliableFunctionType.TransferOverBankOut)
            {
                lbcnaps.Visible = tbcnaps.Visible = true;
                if (m_AppType == AppliableFunctionType.TransferOverBankOut)
                {
                    lblPayeeEmail.Visible = edtPayeeEmail.Visible = true;
                }
                bool flag = m_AppType == AppliableFunctionType.TransferWithIndiv
                    || m_AppType == AppliableFunctionType.TransferWithCorp
                    || m_AppType == AppliableFunctionType.TransferOverBankOut;
                lblPayeeAccount.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.DesignMain_PayeeAccount : MultiLanguageConvertHelper.DesignMain_PayerAccount, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                lblPayeeName.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.DesignMain_PayeeName : MultiLanguageConvertHelper.DesignMain_PayerName, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                //lbOpenBankType.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Transfer_Mappings_PayeeOpenBankName : MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayeeBankName, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                lblPayeeEmail.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_Email : string.Empty, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                if (m_AppType == AppliableFunctionType.TransferOverBankOut)
                {
                    if (SystemSettings.CurrentLanguage == UILang.CHS)
                        btnQueryBank.Location = new Point { X = btnQueryBank.Location.X, Y = tbcnaps.Location.Y - 2 };
                    edtPayeeBankName.Enabled =
                    lbpayeeName.Visible = false;
                    //edtPayeeBankName.DvRequired = false;
                    tbcnaps.Enabled =
                    tbcnaps.Visible = true;
                    //tbcnaps.DvRequired = false;
                }
                if (m_AppType == AppliableFunctionType.TransferOverBankIn)
                {
                    edtPayeeBankName.Enabled =
                    edtPayeeBankName.DvRequired = true;
                    chbSave.Visible = false;
                }
                lbOpenBankType.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayeeBankName : MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayerBank, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                lbcnaps.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayeeClearBankNo, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");

                if (SystemSettings.CurrentLanguage != UILang.CHS)
                {
                    if (lbOpenBankType.Location.X + lbOpenBankType.Width > lblPayeeName.Location.X + lblPayeeName.Width)
                    {
                        lbOpenBankType.AutoSize = false;
                        lbOpenBankType.Width = 110;
                        lbOpenBankType.Height = 26;
                        lbOpenBankType.Location = new Point { X = lblPayeeName.Location.X + lblPayeeName.Width - lbOpenBankType.Width, Y = lbOpenBankType.Location.Y };
                        lbOpenBank.Location = new Point { X = lbOpenBank.Location.X - 20, Y = lbOpenBank.Location.Y };
                    }
                    if (lbcnaps.Location.X + lbcnaps.Width > lblPayeeName.Location.X + lblPayeeName.Width)
                    {
                        lbcnaps.AutoSize = false;
                        lbcnaps.Width = 90;
                        lbcnaps.Height = 26;
                        lbcnaps.Location = new Point { X = lblPayeeName.Location.X + lblPayeeName.Width - lbcnaps.Width, Y = lbcnaps.Location.Y };
                        lblcnaps.Location = new Point { X = lblcnaps.Location.X - 20, Y = lblcnaps.Location.Y };
                    }
                    lblPayeeAccount.Location = new Point { X = lblPayeeName.Location.X + lblPayeeName.Width - lblPayeeAccount.Width, Y = lblPayeeAccount.Location.Y };
                }

            }
            else if (m_AppType == AppliableFunctionType.UnitivePaymentRMB)
            {
                tbcnaps.ReadOnly = edtPayeeBankName.ReadOnly = false;
            }
            cmbBankType.Items.Clear();
            if (m_AppType == AppliableFunctionType.TransferWithIndiv
                || m_AppType == AppliableFunctionType.TransferWithCorp)
            {
                List<AccountBankType> bankList = new List<AccountBankType> { AccountBankType.BocAccount, AccountBankType.ICBCAccount, AccountBankType.ABCAccount, AccountBankType.CCBBankAccount, AccountBankType.NCXYHZSAccount, AccountBankType.CMBAccount, AccountBankType.BOCCAccount, AccountBankType.NCSYBankAccount, AccountBankType.SHPDFZBankAccount, AccountBankType.ZXBankAccount, AccountBankType.CMBCAccount, AccountBankType.PABankAccount, AccountBankType.GDBankAccount, AccountBankType.XYBankAccount, AccountBankType.YZCXBankAccount/*, AccountBankType.GFBankAccount, AccountBankType.SHNSBankAccount, AccountBankType.HXBAccount, AccountBankType.HFBankAccount, AccountBankType.HQBankAccount, AccountBankType.ZDBankAccount, AccountBankType.HSBankAccount, AccountBankType.CZBankAccount, AccountBankType.SLDJRLBankAccount, AccountBankType.NYFZBankAccount*/, AccountBankType.OtherBankAccount };
                bankList.ForEach(o => cmbBankType.Items.Add(EnumNameHelper<AccountBankType>.GetEnumDescription(o)));
                cmbBankType.Tag = bankList;
            }
            else if (m_AppType == AppliableFunctionType.UnitivePaymentRMB
                || m_AppType == AppliableFunctionType.TheCentralGoverment)
            {
                cmbBankType.Items.Add(EnumNameHelper<AccountBankType>.GetEnumDescription(AccountBankType.BocAccount));
                cmbBankType.Items.Add(EnumNameHelper<AccountBankType>.GetEnumDescription(AccountBankType.OtherBankAccount));
                cmbBankType.Tag = new List<AccountBankType> { AccountBankType.BocAccount, AccountBankType.OtherBankAccount };
            }
            else if (m_AppType == AppliableFunctionType.TransferOverBankIn
                || m_AppType == AppliableFunctionType.TransferOverBankOut)
            {
                cmbBankType.Items.Add(EnumNameHelper<AccountBankType>.GetEnumDescription(AccountBankType.OtherBankAccount));
                cmbBankType.Tag = new List<AccountBankType> { AccountBankType.OtherBankAccount };
            }
            if (cmbBankType.Items.Count > 0)
                cmbBankType.SelectedIndex = 0;

            btnQueryAccount.Visible = m_AppType != AppliableFunctionType.TransferOverBankIn;
            cmbPayeeAccount.DropDownStyle = m_AppType != AppliableFunctionType.TransferOverBankIn ? ComboBoxStyle.DropDown : ComboBoxStyle.Simple;
            cmbPayeeAccount.Items.Clear();
            List<PayeeInfo> list = new List<PayeeInfo>();
            if (m_AppType == AppliableFunctionType.TransferOverBankOut)
                list = SystemSettings.PayeeList.FindAll(o => o.BankType == AccountBankType.OtherBankAccount);
            else if (m_AppType == AppliableFunctionType.TransferWithCorp)
                list = SystemSettings.PayeeList.FindAll(o => o.AccountType == AccountCategoryType.Corperation);
            else if (m_AppType == AppliableFunctionType.TransferWithIndiv)
                list = SystemSettings.PayeeList.FindAll(o => o.AccountType == AccountCategoryType.Personal);
            else if (m_AppType == AppliableFunctionType.UnitivePaymentRMB)
                list.AddRange(SystemSettings.PayeeList.ToArray());
            cmbPayeeAccount.Items.AddRange(list.ToArray());
            cmbPayeeAccount.Tag = list;
            ambiguityInputAgent1.ClearItems();
            list.ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));

            SetRegex();
        }

        private void SetRegex()
        {
            if (m_AppType == AppliableFunctionType.UnitivePaymentRMB)
            {
                cmbPayeeAccount.DvRegCode = "reg688";
                cmbPayeeAccount.DvMinLength = 1;
                cmbPayeeAccount.DvMaxLength = 32;
                cmbPayeeAccount.DvRequired = true;

                edtPayeeName.DvRegCode = "reg685";
                edtPayeeName.DvMinLength = 1;
                edtPayeeName.DvMaxLength = 76;
                edtPayeeName.DvRequired = true;
            }
            else
            {
                cmbPayeeAccount.DvRegCode = "Predefined4";
                cmbPayeeAccount.DvMinLength = 1;
                cmbPayeeAccount.DvMaxLength = 35;
                cmbPayeeAccount.DvRequired = true;
                edtPayeeName.DvRegCode = "reg685";
                edtPayeeName.DvMinLength = 1;
                edtPayeeName.DvMaxLength = m_AppType == AppliableFunctionType.TransferOverBankIn ? 70 : 76;
                edtPayeeName.DvRequired = m_AppType != AppliableFunctionType.TransferOverBankOut;

                if (lbOpenBank.Visible)
                {
                    if (m_AppType == AppliableFunctionType.TransferWithIndiv
                        || m_AppType == AppliableFunctionType.TransferWithCorp
                        || m_AppType == AppliableFunctionType.TransferOverBankIn
                    )
                    {
                        if ((cmbBankType.Tag as List<AccountBankType>)[cmbBankType.SelectedIndex] == AccountBankType.OtherBankAccount)
                        {
                            edtPayeeBankName.DvRegCode = "reg667";
                            edtPayeeBankName.DvMinLength = 1;
                            edtPayeeBankName.DvMaxLength = 70;
                            edtPayeeBankName.DvRequired = true;
                        }
                    }
                    else if (m_AppType == AppliableFunctionType.TransferOverBankOut)
                    {
                        tbcnaps.DvRegCode = "reg57";
                        tbcnaps.DvMinLength = 12;
                        tbcnaps.DvMaxLength = 12;
                        tbcnaps.DvRequired = true;
                    }
                }

            }
        }

        public PayeeSelector()
        {
            InitializeComponent();

            CommandCenter.OnPayeeInfoEventHandler += new EventHandler<PayeeEventArgs>(CommandCenter_OnPayeeInfoEventHandler);
            CommandCenter.OnTransferAccountEventHandler += new EventHandler<TransferEventArgs>(CommandCenter_OnTransferAccountEventHandler);
            CommandCenter.OnGovermentEventHandler += new EventHandler<GovermentEventArgs>(CommandCenter_OnGovermentEventHandler);
            CommandCenter.OnUnitivePaymentRMBEventHandler += new EventHandler<UnitivePaymentRMBEventArgs>(CommandCenter_OnUnitivePaymentRMBEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            cmbPayeeAccount.SelectedIndexChanged += new EventHandler(cmbPayeeAccount_SelectedIndexChanged);
            ambiguityInputAgent1.Selected += new EventHandler<CommonClient.Controls.SelectedEventParameter>(ambiguityInputAgent1_Selected);
            cmbBankType.SelectedIndexChanged += new EventHandler(cmbBankType_SelectedIndexChanged);
            cmbBankType.SelectedIndex = -1;
        }

        void ambiguityInputAgent1_Selected(object sender, Controls.SelectedEventParameter e)
        {
            if (ambiguityInputAgent1.SelectedItemIndex >= 0)
            {
                PayeeInfo payee = ambiguityInputAgent1.SelectedEntity as PayeeInfo;
                edtPayeeName.Text = payee.Name;
                cmbBankType.SelectedIndex = (cmbBankType.Tag as List<AccountBankType>).FindIndex(o => o == payee.BankType);
                edtPayeeBankName.Text = payee.OpenBankName;
                tbcnaps.Text = payee.CNAPSNo;
                edtPayeeEmail.Text = payee.Email;
                if (m_AppType == AppliableFunctionType.TransferOverBankOut)
                {
                    tbcnaps.Text = payee.CNAPSNoR;
                    edtPayeeBankName.Tag = new CommonClient.Types.CNAP { Name = payee.ClearBankName, Code = payee.CNAPSNoR };
                }
                else if (m_AppType == AppliableFunctionType.TransferOverBankIn)
                {
                    tbcnaps.Text = payee.CNAPSNo;
                    edtPayeeBankName.Tag = new CommonClient.Types.CNAP { Name = payee.OpenBankName, Code = payee.CNAPSNo };
                }
                else
                    edtPayeeBankName.Tag = payee.OpenBankName;
                CommandCenter.ResolvePayee(OperatorCommandType.Empty, payee, m_AppType, int.MaxValue);
            }
        }

        void CommandCenter_OnUnitivePaymentRMBEventHandler(object sender, UnitivePaymentRMBEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<UnitivePaymentRMBEventArgs>(CommandCenter_OnUnitivePaymentRMBEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                {
                    cmbPayeeAccount.Text = e.UnitivePaymentRMB.PayeeAccount;
                    edtPayeeName.Text = e.UnitivePaymentRMB.PayeeName;
                    cmbBankType.SelectedIndex = (cmbBankType.Tag as List<AccountBankType>).FindIndex(o => o == e.UnitivePaymentRMB.BankType);
                    if (e.UnitivePaymentRMB.BankType == AccountBankType.OtherBankAccount)
                    {
                        edtPayeeBankName.Text = e.UnitivePaymentRMB.PayeeOpenBankName;
                        tbcnaps.Text = e.UnitivePaymentRMB.PayeeCNAPS;
                    }
                }
                else if (e.Command == OperatorCommandType.Reset)
                {
                    cmbPayeeAccount.Text =
                    edtPayeeName.Text =
                    edtPayeeBankName.Text =
                    tbcnaps.Text = string.Empty;

                    if (edtPayeeEmail.Visible) edtPayeeEmail.Text = string.Empty;
                    if (m_AppType != AppliableFunctionType.TransferOverBankIn) edtPayeeBankName.Tag = null;
                }
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(PayeeSelector), this);
                Init();
            }
        }

        void cmbBankType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBankType.SelectedIndex < 0) return;
            AccountBankType abt = (cmbBankType.Tag as List<AccountBankType>)[cmbBankType.SelectedIndex];
            //edtPayeeBankName.Visible = btnQueryBank.Visible =
            //lblcnaps.Visible = tbcnaps.Visible = lbcnaps.Visible = 
            panel3.Visible = abt != AccountBankType.BocAccount;
            tbcnaps.Text =
            edtPayeeBankName.Text = string.Empty;
            edtPayeeBankName.Tag = null;
            if (m_AppType == AppliableFunctionType.TransferWithCorp
                || m_AppType == AppliableFunctionType.TransferWithIndiv
                 || m_AppType == AppliableFunctionType.TheCentralGoverment)
            {
                //lbcnaps.Text = "CNAPS号：";
                lbcnaps.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Transfer_Mappings_CNAPSNo, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                tbcnaps.ReadOnly =
                tbcnaps.Visible =
                lbcnaps.Visible = true;
                lblcnaps.Visible = false;
                edtPayeeBankName.ReadOnly = false;
                //edtPayeeBankName.DvRequired =

            }
            else if (m_AppType == AppliableFunctionType.TransferOverBankIn
                || m_AppType == AppliableFunctionType.TransferOverBankOut)
            {
                //lbcnaps.Text = "清算行号：";     
                lbcnaps.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayeeClearBankNo, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                bool flag = m_AppType == AppliableFunctionType.TransferOverBankIn;
                tbcnaps.ReadOnly = flag;
                //tbcnaps.DvRequired 
                lblcnaps.Visible = !flag;
                edtPayeeBankName.ReadOnly = !flag;
                //edtPayeeBankName.DvRequired = flag;
            }
            else if (m_AppType == AppliableFunctionType.UnitivePaymentRMB)
            {
                lbcnaps.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Transfer_Mappings_CNAPSNo, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                edtPayeeBankName.Visible =
                lbcnaps.Visible =
                tbcnaps.Visible = abt == AccountBankType.OtherBankAccount;

                tbcnaps.ReadOnly =
                lblcnaps.Visible = false;
            }
            if (m_AppType == AppliableFunctionType.UnitivePaymentRMB)
            {
                if ((cmbBankType.Tag as List<AccountBankType>)[cmbBankType.SelectedIndex] == AccountBankType.OtherBankAccount)
                {
                    edtPayeeBankName.DvRegCode = "reg662";
                    edtPayeeBankName.DvMinLength = 1;
                    edtPayeeBankName.DvMaxLength = 140;
                    tbcnaps.DvRegCode = "reg57";
                    tbcnaps.DvMinLength = 12;
                    tbcnaps.DvMaxLength = 12;
                }
            }
            else
            {
                if (lbOpenBank.Visible)
                {
                    if (m_AppType == AppliableFunctionType.TransferWithIndiv
                        || m_AppType == AppliableFunctionType.TransferWithCorp
                        || m_AppType == AppliableFunctionType.TransferOverBankIn)
                    {
                        if ((cmbBankType.Tag as List<AccountBankType>)[cmbBankType.SelectedIndex] == AccountBankType.OtherBankAccount)
                        {
                            edtPayeeBankName.DvRegCode = "reg667";
                            edtPayeeBankName.DvMinLength = 1;
                            edtPayeeBankName.DvMaxLength = 70;
                            edtPayeeBankName.DvRequired = true;
                        }
                        edtPayeeBankName.DvRequired = (cmbBankType.Tag as List<AccountBankType>)[cmbBankType.SelectedIndex] == AccountBankType.OtherBankAccount;
                    }
                }
            }
            //lbcnaps.Location = new Point { X = this.lbOpenBankType.Location.X + lbOpenBankType.Width - lbcnaps.Width, Y = lbcnaps.Location.Y };
            if (SystemSettings.CurrentLanguage != UILang.CHS)
            {
                if (lbcnaps.Location.X + lbcnaps.Width > lblPayeeName.Location.X + lblPayeeName.Width)
                {
                    lbcnaps.AutoSize = false;
                    lbcnaps.Width = 70;
                    lbcnaps.Height = 26;
                }
            }
            lbcnaps.Location = new Point { X = lblPayeeName.Location.X + lblPayeeName.Width - lbcnaps.Width - 3, Y = lbcnaps.Location.Y };
            //SetRegexbyBank();
        }

        //private void SetRegexbyBank()
        //{
        //    if (cmbBankType.SelectedIndex < 0) return;
        //    AccountBankType abt = (cmbBankType.Tag as List<AccountBankType>)[cmbBankType.SelectedIndex];

        //    if (abt == AccountBankType.BocAccount)
        //    {
        //        edtPayeeBankName.DvRegCode = string.Empty;
        //        edtPayeeBankName.DvMinLength =
        //        edtPayeeBankName.DvMaxLength = 0;

        //        tbcnaps.DvRegCode = string.Empty;
        //        tbcnaps.DvMinLength =
        //        tbcnaps.DvMaxLength = 0;
        //    }
        //    else
        //    {
        //        edtPayeeBankName.DvRegCode = string.Empty;
        //        edtPayeeBankName.DvMinLength = 1;
        //        edtPayeeBankName.DvMaxLength = m_AppType == AppliableFunctionType.UnitivePaymentRMB ? 140 : 70;

        //        tbcnaps.DvRegCode = "reg57";
        //        tbcnaps.DvMinLength = 12;
        //        tbcnaps.DvMaxLength = 12;
        //    }
        //}

        void cmbPayeeAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayeeAccount.SelectedIndex >= 0)
            {
                PayeeInfo payee = (cmbPayeeAccount.Tag as List<PayeeInfo>)[cmbPayeeAccount.SelectedIndex];
                edtPayeeName.Text = payee.Name;
                cmbBankType.SelectedIndex = (cmbBankType.Tag as List<AccountBankType>).FindIndex(o => o == payee.BankType);
                edtPayeeBankName.Text = payee.OpenBankName;
                tbcnaps.Text = payee.CNAPSNo;
                edtPayeeEmail.Text = payee.Email;
                if (m_AppType == AppliableFunctionType.TransferOverBankOut)
                {
                    tbcnaps.Text = payee.CNAPSNoR;
                    edtPayeeBankName.Tag = new CommonClient.Types.CNAP { Name = payee.ClearBankName, Code = payee.CNAPSNoR };
                }
                else if (m_AppType == AppliableFunctionType.TransferOverBankIn)
                {
                    tbcnaps.Text = payee.CNAPSNo;
                    edtPayeeBankName.Tag = new CommonClient.Types.CNAP { Name = payee.OpenBankName, Code = payee.CNAPSNo };
                }
                else
                {
                    edtPayeeBankName.Tag = payee.OpenBankName;
                }
                CommandCenter.ResolvePayee(OperatorCommandType.Empty, payee, m_AppType, int.MaxValue);
            }
            else
            {
                edtPayeeName.Text =
                edtPayeeBankName.Text =
                edtPayeeEmail.Text = string.Empty;
            }
        }

        void CommandCenter_OnTransferAccountEventHandler(object sender, TransferEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<TransferEventArgs>(CommandCenter_OnTransferAccountEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                {
                    cmbBankType.SelectedIndex = (cmbBankType.Tag as List<AccountBankType>).FindIndex(o => o == e.TransferAccount.AccountBankType);
                    cmbPayeeAccount.Text = e.TransferAccount.PayeeAccount;
                    edtPayeeName.Text = e.TransferAccount.PayeeName;
                    edtPayeeBankName.Text = e.TransferAccount.PayeeOpenBank;
                    if (m_AppType == AppliableFunctionType.TransferOverBankOut)
                    {
                        tbcnaps.Text = e.TransferAccount.PayBankNo;
                        edtPayeeBankName.Tag = new CommonClient.Types.CNAP { Name = e.TransferAccount.PayeeOpenBank, Code = e.TransferAccount.PayBankNo };
                    }
                    else if (m_AppType == AppliableFunctionType.TransferOverBankIn)
                    {
                        tbcnaps.Text = e.TransferAccount.CNAPSNo;
                        edtPayeeBankName.Tag = new CommonClient.Types.CNAP { Name = e.TransferAccount.PayeeOpenBank, Code = e.TransferAccount.CNAPSNo };
                    }
                    else
                    {
                        tbcnaps.Text = e.TransferAccount.CNAPSNo;
                        edtPayeeBankName.Tag = e.TransferAccount.PayeeOpenBank;
                    }
                    if (edtPayeeEmail.Visible) edtPayeeEmail.Text = e.TransferAccount.Email;
                }
                else if (e.Command == OperatorCommandType.Reset)
                {
                    cmbPayeeAccount.Text =
                    edtPayeeName.Text =
                    edtPayeeBankName.Text =
                    tbcnaps.Text = string.Empty;
                    if (edtPayeeEmail.Visible) edtPayeeEmail.Text = string.Empty;
                    if (m_AppType != AppliableFunctionType.TransferOverBankIn) edtPayeeBankName.Tag = null;
                    if (cmbBankType.Items.Count > 0) cmbBankType.SelectedIndex = 0;
                }
            }
        }

        void CommandCenter_OnPayeeInfoEventHandler(object sender, PayeeEventArgs e)
        {
            if (m_AppType != e.OwnerType && e.OwnerType != AppliableFunctionType._Empty) return;
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayeeEventArgs>(CommandCenter_OnPayeeInfoEventHandler), new object[] { sender, e }); }
            else
            {
                if (m_AppType == AppliableFunctionType.TransferOverBankIn) return;
                if (OperatorCommandType.Edit == e.Command || OperatorCommandType.Submit == e.Command)
                {
                    if ((m_AppType == AppliableFunctionType.TransferWithIndiv && e.PayeeInfo.AccountType != AccountCategoryType.Personal)
                        || (m_AppType == AppliableFunctionType.TransferWithCorp && e.PayeeInfo.AccountType != AccountCategoryType.Corperation)
                        || (m_AppType == AppliableFunctionType.TransferOverBankOut && e.PayeeInfo.BankType != AccountBankType.OtherBankAccount))
                        return;

                    List<PayeeInfo> list = cmbPayeeAccount.Tag as List<PayeeInfo>;
                    PayeeInfo payee = list.Find(o => o.Account == e.PayeeInfo.Account);
                    if (null == payee) list.Add(e.PayeeInfo);
                    else payee = e.PayeeInfo;

                    cmbPayeeAccount.Items.Clear();
                    cmbPayeeAccount.Items.AddRange(list.ToArray());
                    cmbPayeeAccount.Tag = list;
                }
                else if (OperatorCommandType.Delete == e.Command)
                {
                    List<PayeeInfo> list = cmbPayeeAccount.Tag as List<PayeeInfo>;
                    int index = list.FindIndex(o => o.Account == e.PayeeInfo.Account);
                    if (index < 0) return;
                    list.RemoveAt(index);

                    cmbPayeeAccount.Items.Clear();
                    cmbPayeeAccount.Items.AddRange(list.ToArray());
                    cmbPayeeAccount.Tag = list;
                }
                ambiguityInputAgent1.ClearItems();
                if (cmbPayeeAccount.Items.Count > 0) (cmbPayeeAccount.Tag as List<PayeeInfo>).ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            }
        }

        void CommandCenter_OnGovermentEventHandler(object sender, GovermentEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<GovermentEventArgs>(CommandCenter_OnGovermentEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                {
                    cmbBankType.SelectedIndex = (cmbBankType.Tag as List<AccountBankType>).FindIndex(o => o == e.GovermentInfo.AccountBankType);
                    cmbPayeeAccount.Text = e.GovermentInfo.PayeeAccount;
                    edtPayeeName.Text = e.GovermentInfo.PayeeName;
                    edtPayeeBankName.Text = e.GovermentInfo.PayeeOpenBank;
                    tbcnaps.Text = e.GovermentInfo.CNAPSNo;
                    edtPayeeBankName.Tag = new CommonClient.Types.CNAP { Name = e.GovermentInfo.PayeeOpenBank, Code = e.GovermentInfo.CNAPSNo };
                }
                else if (e.Command == OperatorCommandType.Reset)
                {
                    cmbPayeeAccount.Text =
                    edtPayeeName.Text =
                    edtPayeeBankName.Text =
                    tbcnaps.Text = string.Empty;
                    if (edtPayeeEmail.Visible) edtPayeeEmail.Text = string.Empty;
                    edtPayeeBankName.Tag = null;
                    if (cmbBankType.Items.Count > 0) cmbBankType.SelectedIndex = 0;
                }
            }
        }
        public void GetItem()
        {
            m_payee = new PayeeInfo();
            m_payee.Account = cmbPayeeAccount.Text.Trim();
            m_payee.Name = edtPayeeName.Text.Trim();

            string bocName = EnumNameHelper<AccountBankType>.GetEnumDescription(AccountBankType.BocAccount);
            m_payee.OpenBankName = GetBankName(bocName);
            m_payee.CNAPSNo = tbcnaps.Text.Trim();

            if (m_AppType == AppliableFunctionType.TransferOverBankOut)
            {
                m_payee.ClearBankName = edtPayeeBankName.Text.Trim();
                m_payee.CNAPSNoR = tbcnaps.Text.Trim();
                m_payee.Email = edtPayeeEmail.Text.Trim();
            }
            m_payee.AccountType = m_AccountType;
            m_payee.BankType = (cmbBankType.Tag as List<AccountBankType>)[cmbBankType.SelectedIndex];
            isNew = chbSave.Checked && m_AppType != AppliableFunctionType.TransferOverBankIn && !CommonInformations.IsExistPayeeInfo(m_payee);
        }
        private string GetBankName(string bocName)
        {
            string bankname = string.Empty;
            if (cmbBankType.SelectedItem.ToString().Equals(bocName))
            {
                //if (cmbPayeeAccount.SelectedIndex >= 0 && cmbPayeeAccount.SelectedItem.ToString().Equals(cmbPayeeAccount.Text))
                //{
                //    if (edtPayeeBankName.Tag != null && string.IsNullOrEmpty(edtPayeeBankName.Tag.ToString()))
                //    {
                //        bankname = edtPayeeBankName.Tag.ToString();
                //    }
                //    else bankname = bocName;
                //}
                //else bankname = bocName;
                bankname = string.Empty;
            }
            else
            {
                bankname = edtPayeeBankName.Text.Trim();
            }
            return bankname;
        }

        /// <summary>
        /// 设置收款人信息
        /// </summary>
        /// <param name="item"></param>
        public void SetItem(PayeeInfo item)
        {
            if (null == item)
            {
                cmbPayeeAccount.SelectedIndex = -1;
                edtPayeeName.Text =
                edtPayeeBankName.Text = string.Empty;
                if (m_AppType == AppliableFunctionType.TransferOverBankOut)
                {
                    edtPayeeEmail.Text = string.Empty;
                    edtPayeeBankName.Tag = null;
                }
                edtPayeeEmail.Text = string.Empty;
                cmbPayeeAccount.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbBankType.SelectedIndex = 0;
            }
            else
            {
                cmbPayeeAccount.SelectedItem = item.Account;
                cmbPayeeAccount.DropDownStyle = ComboBoxStyle.DropDownList;
                edtPayeeName.Text = item.Name;
                edtPayeeBankName.Text = item.OpenBankName;
                if (m_AppType == AppliableFunctionType.TransferOverBankOut)
                {
                    edtPayeeBankName.Text = item.ClearBankName;
                    tbcnaps.Text = item.CNAPSNoR;
                }
                else if (m_AppType == AppliableFunctionType.TransferOverBankIn)
                    tbcnaps.Text = item.CNAPSNoR;
                else if (m_AppType == AppliableFunctionType.TransferWithCorp
                    || m_AppType == AppliableFunctionType.TransferWithIndiv)
                {
                    if (item.BankType != AccountBankType.Empty && item.BankType != AccountBankType.BocAccount) cmbBankType.SelectedIndex = (cmbBankType.Tag as List<AccountBankType>).FindIndex(o => o == GetBankType(item.OpenBankName));
                    tbcnaps.Text = item.CNAPSNo;
                }
                edtPayeeEmail.Text = item.Email;
                cmbBankType.SelectedIndex = item.BankType == AccountBankType.BocAccount ? 0 : 1;
                if (item.BankType == AccountBankType.BocAccount)
                    edtPayeeBankName.Tag = item.OpenBankName;
            }
        }

        private AccountBankType GetBankType(string p)
        {
            AccountBankType bt = AccountBankType.OtherBankAccount;
            bt = PrequisiteDataProvideNode.InitialProvide.AccountBankTypeList.Find(o => !string.IsNullOrEmpty(p) && o != AccountBankType.Empty && p.Contains(EnumNameHelper<AccountBankType>.GetEnumDescription(o)));
            if (bt == null) bt = AccountBankType.OtherBankAccount;
            return bt;
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //if (m_AppType == AppliableFunctionType.UnitivePaymentRMB)
            //{
            //    rd = DataCheckCenter.CheckPayeeAccountUP(cmbPayeeAccount, cmbPayeeAccount.Text.Trim(), lblPayeeAccount.Text.Trim().Substring(0, lblPayeeAccount.Text.Length - 1), 32, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //    rd = DataCheckCenter.CheckPayeeNameAgentInOrUP(edtPayeeName, edtPayeeName.Text, lblPayeeName.Text.Substring(0, lblPayeeName.Text.Length - 1), 76, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //    if ((cmbBankType.Tag as List<AccountBankType>)[cmbBankType.SelectedIndex] == AccountBankType.OtherBankAccount)
            //    {
            //        rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(edtPayeeBankName, edtPayeeBankName.Text.Trim(), lbOpenBankType.Text.Substring(0, lbOpenBankType.Text.Length - 1), 140, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //        if (!string.IsNullOrEmpty(tbcnaps.Text.Trim()))
            //        {
            //            rd = DataCheckCenter.CheckCNAPSNo(tbcnaps, tbcnaps.Text.Trim(), this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //    }
            //}
            //else
            //{
            //    rd = DataCheckCenter.CheckPayeeAccount(cmbPayeeAccount, cmbPayeeAccount.Text.Trim(), lblPayeeAccount.Text.Trim().Substring(0, lblPayeeAccount.Text.Length - 1), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //    if (lbpayeeName.Visible)
            //    {
            //        rd = DataCheckCenter.CheckPayeeOrElecTicketPersonName(edtPayeeName, edtPayeeName.Text, lblPayeeName.Text.Substring(0, lblPayeeName.Text.Length - 1), m_AppType == AppliableFunctionType.TransferOverBankIn ? 70 : 76, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //if (lbOpenBank.Visible)
            //{
            //    if (m_AppType == AppliableFunctionType.TransferWithIndiv
            //        || m_AppType == AppliableFunctionType.TransferWithCorp
            //        || m_AppType == AppliableFunctionType.TransferOverBankIn
            //    )
            //    {
            //        if ((cmbBankType.Tag as List<AccountBankType>)[cmbBankType.SelectedIndex] == AccountBankType.OtherBankAccount)
            //        {
            //            rd = DataCheckCenter.CheckOpenBankName(edtPayeeBankName, edtPayeeBankName.Text.Trim(), lbOpenBankType.Text.Substring(0, lbOpenBankType.Text.Length - 1), this.errorProvider1);
            //            if (!rd.Result) return rd.Result;
            //        }
            //    }
            //    else if (m_AppType == AppliableFunctionType.TransferOverBankOut)
            //    {
            //        rd = DataCheckCenter.CheckCNAPSNo(tbcnaps, tbcnaps.Text.Trim(), this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //}
            //    if (m_AppType == AppliableFunctionType.TransferOverBankOut)
            //    {
            //        rd = DataCheckCenter.CheckEmail(edtPayeeEmail, edtPayeeEmail.Text, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //}

            return true;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        private void btnQueryAccount_Click(object sender, EventArgs e)
        {
            wndPayeeQuery frm = new wndPayeeQuery(m_AccountType, cmbPayeeAccount.Text, edtPayeeName.Text);

            if (m_AppType == AppliableFunctionType.TransferOverBankIn
               || m_AppType == AppliableFunctionType.TransferOverBankOut)
                frm = new wndPayeeQuery(m_AccountType, AccountBankType.OtherBankAccount, cmbPayeeAccount.Text, edtPayeeName.Text);

            if (frm.ShowDialog() != DialogResult.OK) return;
            cmbBankType.SelectedIndex = (cmbBankType.Tag as List<AccountBankType>).FindIndex(o => o == frm.Payee.BankType);
            cmbPayeeAccount.Text = frm.Payee.Account;
            edtPayeeName.Text = frm.Payee.Name;
            edtPayeeBankName.Text = m_AppType == AppliableFunctionType.TransferOverBankOut ? frm.Payee.ClearBankName : frm.Payee.OpenBankName;
            tbcnaps.Text = m_AppType == AppliableFunctionType.TransferOverBankOut ? frm.Payee.CNAPSNoR : frm.Payee.CNAPSNo;
            edtPayeeEmail.Text = frm.Payee.Email;

            cmbPayeeAccount.ManualValidate();
            edtPayeeName.ManualValidate();
            edtPayeeBankName.ManualValidate();
            tbcnaps.ManualValidate();
            edtPayeeEmail.ManualValidate();

            CommandCenter.ResolvePayee(OperatorCommandType.Empty, frm.Payee, m_AppType, int.MaxValue);
        }

        private void btnQueryBank_Click(object sender, EventArgs e)
        {
            wndOpenBankQuery frm = new wndOpenBankQuery(edtPayeeBankName.Text, tbcnaps.Text);
            frm.IsOpenBank = !(m_AppType == AppliableFunctionType.TransferOverBankOut || m_AppType == AppliableFunctionType.TransferOverBankIn);
            frm.BankType = (cmbBankType.Tag as List<AccountBankType>)[cmbBankType.SelectedIndex];
            frm.AppType = m_AppType;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                edtPayeeBankName.Text = frm.QueryDialogResult.Name;
                tbcnaps.Text = frm.QueryDialogResult.Code;

                edtPayeeBankName.ManualValidate();
                tbcnaps.ManualValidate();
            }

            if (null != frm)
                frm.Close();
        }

        private void pbTip_MouseHover(object sender, EventArgs e)
        {
            if (m_AppType != AppliableFunctionType.TransferOverBankIn)
                toolTip1.Show(MultiLanguageConvertHelper.Tips_Pyaee_6Numbers, pbTip);
        }
    }
}
