using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.Utilities;
using CommonClient.ConvertHelper;
using CommonClient.Controls;
using CommonClient.VisualParts;
using System.Text.RegularExpressions;

namespace CommonClient.VisualParts2
{
    public partial class TransferGlobalRemitSelector : BaseUc
    {
        public TransferGlobalRemitSelector()
        {
            InitializeComponent();

            dtpRemitDate.MinDate = DateTime.Today;
            dtpRemitDate.MaxDate = DateTime.Today.AddMonths(1);

            CommandCenter.OnTransferGlobalEventHandler += new EventHandler<TransferGlobalEventArgs>(CommandCenter_OnTransferGlobalEventHandler);
            CommandCenter.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnCashTypeChangedEventHandler += new EventHandler<CashTypeChangedEventArgs>(CommandCenter_OnCashTypeChangedEventHandler);
            this.Load += new EventHandler(TransferGlobalRemitEditor_Load);
            cmbRemitCashType.SelectedIndexChanged += new EventHandler(cmbRemitCashType_SelectedIndexChanged);
            tbRemitAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            tbSpotAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            tbPurchaseAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            tbOtherAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            cmbSpotAccount.LostFocus += new EventHandler(cmbAccount_LostFocus);
            cmbPurchaseAccount.LostFocus += new EventHandler(cmbAccount_LostFocus);
            cmbOtherAccount.LostFocus += new EventHandler(cmbAccount_LostFocus);
            tbOrgPre.LostFocus += new EventHandler(tbOrgPre_LostFocus);
            tbOrgEnd.LostFocus += new EventHandler(tbOrgPre_LostFocus);
        }

        void CommandCenter_OnCashTypeChangedEventHandler(object sender, CashTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<CashTypeChangedEventArgs>(CommandCenter_OnCashTypeChangedEventHandler), sender, e); }
            else
            {
                if (m_appType != e.AppType) return;
                if (e.Command != OperatorCommandType.CardTypeCallBack) return;
                if (e.IsRollBack)
                {
                    isCallBack = true;
                    cmbRemitCashType.SelectedIndex = (cmbRemitCashType.Tag as List<CashType>).FindIndex(o => o == e.CashType);
                }
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(TransferGlobalRemitSelector), this);
                Init();
                InitData();
            }
        }

        private void InitData()
        {
            tbPaymentType.Text = EnumNameHelper<PaymentType>.GetEnumDescription(PaymentType.Telegraphic);
            if (cmbPayFeeAccount.Items.Count < 4)
            {
                cmbPayFeeAccount.Items.Clear();
                cmbPayFeeAccount.Items.Add(EnumNameHelper<PayFeeAccountType>.GetEnumDescription(PayFeeAccountType.SpotAccount));
                cmbPayFeeAccount.Items.Add(EnumNameHelper<PayFeeAccountType>.GetEnumDescription(PayFeeAccountType.PurchaseAccount));
                if (m_appType != AppliableFunctionType.TransferOverCountry4Bar && m_appType != AppliableFunctionType.TransferForeignMoney4Bar) cmbPayFeeAccount.Items.Add(EnumNameHelper<PayFeeAccountType>.GetEnumDescription(PayFeeAccountType.OtherAccount));
                cmbPayFeeAccount.SelectedIndex = 0;
            }
            else
            {
                cmbPayFeeAccount.Items.RemoveAt(0);
                cmbPayFeeAccount.Items.RemoveAt(0);
                if (m_appType != AppliableFunctionType.TransferOverCountry4Bar && m_appType != AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    cmbPayFeeAccount.Items.RemoveAt(0);
                    cmbPayFeeAccount.Items.Insert(0, EnumNameHelper<PayFeeAccountType>.GetEnumDescription(PayFeeAccountType.OtherAccount));
                }
                cmbPayFeeAccount.Items.Insert(0, EnumNameHelper<PayFeeAccountType>.GetEnumDescription(PayFeeAccountType.PurchaseAccount));
                cmbPayFeeAccount.Items.Insert(0, EnumNameHelper<PayFeeAccountType>.GetEnumDescription(PayFeeAccountType.SpotAccount));
            }

            List<CashType> list = new List<CashType>();
            if (m_appType == AppliableFunctionType.TransferOverCountry)
                list.AddRange(new List<CashType> { CashType.GBP, CashType.HKD, CashType.USD, CashType.CHF, CashType.SGD, CashType.SEK, CashType.DKK, CashType.NOK, CashType.JPY, CashType.CAD, CashType.AUD, CashType.EUR, CashType.MOP, CashType.NZD, CashType.CNY });
            else if (m_appType == AppliableFunctionType.TransferForeignMoney)
                list.AddRange(new List<CashType> { CashType.GBP, CashType.HKD, CashType.USD, CashType.CHF, CashType.SGD, CashType.SEK, CashType.DKK, CashType.NOK, CashType.JPY, CashType.CAD, CashType.AUD, CashType.EUR, CashType.MOP, CashType.PHP, CashType.THB, CashType.NZD, CashType.KRW });
            else if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                list.AddRange(new List<CashType> { CashType.GBP, CashType.HKD, CashType.USD, CashType.CHF, CashType.SGD, CashType.SEK, CashType.DKK, CashType.NOK, CashType.JPY, CashType.CAD, CashType.AUD, CashType.EUR, CashType.MOP, CashType.NZD });
            else if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
                list.AddRange(new List<CashType> { CashType.USD, CashType.AUD, CashType.EUR, CashType.GBP, CashType.CAD, CashType.CHF, CashType.JPY, CashType.HKD });
            cmbRemitCashType.Items.Clear();
            foreach (var item in list)
            {
                string value = EnumNameHelper<CashType>.GetEnumDescription(item);
                cmbRemitCashType.Items.Add(value);
            }
            cmbRemitCashType.Tag = list;
            if (cmbRemitCashType.Items.Count > 0) cmbRemitCashType.SelectedIndex = 0;
            if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                lblsendtype.Visible = true;
        }

        void cmbAccount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbSpotAccount.Text))
                cmbPayFeeAccount.SelectedIndex = 0;
            else if (!string.IsNullOrEmpty(cmbPurchaseAccount.Text))
                cmbPayFeeAccount.SelectedIndex = 1;
            else if (!string.IsNullOrEmpty(cmbOtherAccount.Text))
                cmbPayFeeAccount.SelectedIndex = 2;
            else cmbPayFeeAccount.SelectedIndex = 0;

            tbPurchaseAmount.ReadOnly = string.IsNullOrEmpty(cmbPurchaseAccount.Text);
            tbSpotAmount.ReadOnly = string.IsNullOrEmpty(cmbSpotAccount.Text);
            tbOtherAmount.ReadOnly = string.IsNullOrEmpty(cmbOtherAccount.Text);

            if (tbPurchaseAmount.ReadOnly) tbPurchaseAmount.Text = string.Empty;
            if (tbSpotAmount.ReadOnly) tbSpotAmount.Text = string.Empty;
            if (tbOtherAmount.ReadOnly) tbOtherAmount.Text = string.Empty;
        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBox).Text.Trim()))
            {
                ResultData rd = new ResultData { Result = true };
                rd = DataCheckCenter.CheckCash((sender as TextBox), (sender as TextBox).Text.Trim(), (sender as TextBoxCanValidate).DvLinkedLabel.Text.Substring(0, (sender as TextBoxCanValidate).DvLinkedLabel.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
                if (!rd.Result) return;
                (sender as TextBox).Text = DataConvertHelper.FormatCash((sender as TextBox).Text.Trim(), GetCashTypeIsJap());
            }
        }

        void cmbRemitCashType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if ((int)m_appType > 0 && cmbRemitCashType.SelectedIndex >= 0)
            //{
            //    CommandCenter.ResolveCashTypeChanged(OperatorCommandType.CardTypeRequest, (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex], m_appType, false);
            //    return;
            //}
            cmbSpotAccount.Items.Clear();
            if (cmbRemitCashType.SelectedIndex >= 0)
            {
                List<PayerInfo> list = new List<PayerInfo>();
                list = SystemSettings.PayerList.FindAll(o => o.CashType == (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex]);
                cmbSpotAccount.Items.AddRange(list.ToArray());
                cmbSpotAccount.Tag = list;
                ambiguityInputAgent1.ClearItems();
                list.ForEach(o => ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
                if (!isCallBack)
                    CommandCenter.ResolveCashTypeChanged(OperatorCommandType.CardTypeRequest, (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex], m_appType, false);
            }
            else cmbRemitCashType.SelectedIndex = 0;

            if (isCallBack) isCallBack = false;
        }

        void TransferGlobalRemitEditor_Load(object sender, EventArgs e)
        {
            List<PayerInfo> listCNY = SystemSettings.PayerList.FindAll(o => o.CashType == CashType.CNY);
            List<PayerInfo> list = new List<PayerInfo>();
            list.AddRange(SystemSettings.PayerList.ToArray());
            cmbPurchaseAccount.Items.AddRange(listCNY.ToArray());
            cmbPurchaseAccount.Tag = listCNY;
            cmbOtherAccount.Items.AddRange(list.ToArray());
            cmbOtherAccount.Tag = list;
            cmbPayFeeAccount.Items.AddRange(list.ToArray());
            cmbPayFeeAccount.Tag = list;

            listCNY.ForEach(o => ambiguityInputAgent2.AddItem(new SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            list.ForEach(o => ambiguityInputAgent3.AddItem(new SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
        }

        void CommandCenter_OnPayerInfoEventHandler(object sender, PayerEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler), sender, e); }
            else
            {
                if (e.PayerInfo == null || (e.PayerInfo.ServiceList & m_appType) != m_appType) return;
                if (e.Command == OperatorCommandType.Submit)
                {
                    #region
                    int index = -1;
                    if (e.PayerInfo.CashType == CashType.CNY)
                    {
                        List<PayerInfo> payerList = new List<PayerInfo>();
                        payerList = SystemSettings.PayerList.FindAll(o => o.CashType == CashType.CNY);
                        cmbPurchaseAccount.Items.Clear();
                        cmbPurchaseAccount.Items.AddRange(payerList.ToArray());
                        cmbPurchaseAccount.Tag = payerList;
                        index = -1;
                    }
                    if (cmbSpotAccount.Items.Count != 0)
                    {
                        List<PayerInfo> payerList = new List<PayerInfo>();
                        payerList = SystemSettings.PayerList.FindAll(o => o.CashType == (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex]);
                        cmbSpotAccount.Items.Clear();
                        cmbSpotAccount.Items.AddRange(payerList.ToArray());
                        cmbSpotAccount.Tag = payerList;
                        index = -1;
                    }
                    List<PayerInfo> OtherpayerList = new List<PayerInfo>();
                    OtherpayerList = SystemSettings.PayerList.FindAll(o => (m_appType > 0 && (o.ServiceList & m_appType) == m_appType) || (m_appType < 0 && (o.ServiceListBar & (AppliableFunctionType)Math.Abs((int)m_appType)) == (AppliableFunctionType)Math.Abs((int)m_appType)));
                    cmbOtherAccount.Items.Clear();
                    cmbOtherAccount.Items.AddRange(OtherpayerList.ToArray());
                    cmbOtherAccount.Tag = OtherpayerList;

                    while (cmbPayFeeAccount.Items.Count > 3) { cmbPayFeeAccount.Items.RemoveAt(3); }
                    List<PayerInfo> listall = SystemSettings.PayerList.FindAll(o => (m_appType > 0 && (o.ServiceList & m_appType) == m_appType) || (m_appType < 0 && (o.ServiceListBar & (AppliableFunctionType)Math.Abs((int)m_appType)) == (AppliableFunctionType)Math.Abs((int)m_appType)));
                    cmbPayFeeAccount.Items.AddRange(listall.ToArray());
                    cmbPayFeeAccount.Tag = listall;
                    #endregion
                }
                else if (e.Command == OperatorCommandType.Edit || e.Command == OperatorCommandType.Delete)
                {
                    #region
                    if (e.PayerInfo.CashType == CashType.CNY)
                    {
                        List<PayerInfo> list = SystemSettings.PayerList.FindAll(o => o.CashType == CashType.CNY && ((m_appType > 0 && (o.ServiceList & m_appType) == m_appType) || (m_appType < 0 && (o.ServiceListBar & (AppliableFunctionType)Math.Abs((int)m_appType)) == (AppliableFunctionType)Math.Abs((int)m_appType))));
                        cmbPurchaseAccount.Items.AddRange(list.ToArray());
                        cmbPurchaseAccount.Tag = list;
                    }
                    if (cmbRemitCashType.SelectedIndex >= 0 && e.PayerInfo.CashType == (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex])
                    {
                        List<PayerInfo> list = SystemSettings.PayerList.FindAll(o => o.CashType == e.PayerInfo.CashType && ((m_appType > 0 && (o.ServiceList & m_appType) == m_appType) || (m_appType < 0 && (o.ServiceListBar & (AppliableFunctionType)Math.Abs((int)m_appType)) == (AppliableFunctionType)Math.Abs((int)m_appType))));
                        cmbSpotAccount.Items.Add(list.ToArray());
                        cmbSpotAccount.Tag = list;
                    }
                    if (m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferForeignMoney)
                    {
                        List<PayerInfo> list = SystemSettings.PayerList.FindAll(o => (m_appType > 0 && (o.ServiceList & m_appType) == m_appType) || (m_appType < 0 && (o.ServiceListBar & (AppliableFunctionType)Math.Abs((int)m_appType)) == (AppliableFunctionType)Math.Abs((int)m_appType)));
                        cmbOtherAccount.Items.Add(e.PayerInfo);
                        cmbOtherAccount.Tag = list;
                    }
                    while (cmbPayFeeAccount.Items.Count > 3) { cmbPayFeeAccount.Items.RemoveAt(3); }
                    List<PayerInfo> listall = SystemSettings.PayerList.FindAll(o => (m_appType > 0 && (o.ServiceList & m_appType) == m_appType) || (m_appType < 0 && (o.ServiceListBar & (AppliableFunctionType)Math.Abs((int)m_appType)) == (AppliableFunctionType)Math.Abs((int)m_appType)));
                    cmbPayFeeAccount.Items.AddRange(listall.ToArray());
                    cmbPayFeeAccount.Tag = listall;
                    #endregion
                }

                ambiguityInputAgent1.ClearItems();
                ambiguityInputAgent2.ClearItems();
                ambiguityInputAgent3.ClearItems();
                if (cmbSpotAccount.Items.Count > 0) (cmbSpotAccount.Tag as List<PayerInfo>).ForEach(o => ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
                if (cmbPurchaseAccount.Items.Count > 0) (cmbPurchaseAccount.Tag as List<PayerInfo>).ForEach(o => ambiguityInputAgent2.AddItem(new SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
                if (cmbOtherAccount.Items.Count > 0) (cmbOtherAccount.Tag as List<PayerInfo>).ForEach(o => ambiguityInputAgent3.AddItem(new SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
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
                    || value == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    m_appType = value;
                    Init();
                }
            }
        }

        private TransferGlobal m_TransferGlobal = null;
        /// <summary>
        /// 国际结算信息
        /// </summary>
        public TransferGlobal TransferGlobal
        {
            get { return m_TransferGlobal; }
            set { m_TransferGlobal = value; }
        }
        bool isCallBack = false;

        private void Init()
        {
            InitData();
            if (m_appType == AppliableFunctionType.TransferOverCountry)
            {
                if (!(cmbRemitCashType.Tag as List<CashType>).Exists(o => o == CashType.CNY))
                {
                    cmbRemitCashType.Items.Add(CashType.CNY);
                    (cmbRemitCashType.Tag as List<CashType>).Add(CashType.CNY);
                }
            }
            if (m_appType == AppliableFunctionType.TransferOverCountry4Bar
                || m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                {
                    foreach (var item in this.Controls)
                    {
                        if (item is TextBoxCanValidate)
                        {
                            ((TextBoxCanValidate)item).CharacterCasing = CharacterCasing.Upper;
                        }
                    }
                }
                cmbSpotAccount.Items.Clear();
                List<PayerInfo> list = SystemSettings.PayerList.FindAll(o => true);
                cmbSpotAccount.Items.AddRange(list.ToArray());
                cmbSpotAccount.Tag = list;
                tbCustomerRef.Enabled = false;
            }

            if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                cmbSpotAccount.TextChanged += new EventHandler(cmbSpotAccount_TextChanged);
                cmbPurchaseAccount.TextChanged += new EventHandler(cmbPurchaseAccount_TextChanged);
            }
            else if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                cmbPurchaseAccount.Enabled =
                tbPurchaseAmount.Enabled =
                tbRemittorName.Enabled =
                label19.Visible = false;
            }
            cmbPayFeeAccount.Enabled = m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferForeignMoney;
            cmbOtherAccount.Enabled = tbOtherAmount.Enabled = dtpRemitDate.Enabled = m_appType == AppliableFunctionType.TransferForeignMoney || m_appType == AppliableFunctionType.TransferOverCountry;
            SetRegex();
        }
        private void SetRegex()
        {
            tbCustomerRef.DvRegCode = "reg8";
            tbCustomerRef.DvMinLength = 0;
            tbCustomerRef.DvMaxLength = 16;
            tbCustomerRef.DvRequired = false;

            //金额校验
            //tbRemitAmount.DvRegCode = "reg43";
            //tbRemitAmount.DvMinLength = 1;
            //tbRemitAmount.DvMaxLength = 15;
            //rd = DataCheckCenter.Instance.CheckCash(tbRemitAmount, tbRemitAmount.Text.Trim(), lbRemitAmount.Text.Substring(0, lbRemitAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                tbRemittorName.DvRegCode = "Predefined5";
                tbRemittorName.DvMinLength = 1;
                tbRemittorName.DvMaxLength = 140;
                tbRemittorName.DvRequired = true;
            }
            if (m_appType == AppliableFunctionType.TransferOverCountry
                || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                tbRemittorName.DvRegCode = "reg702";
                tbRemittorName.DvMinLength = 1;
                tbRemittorName.DvMaxLength = 140;
                tbRemittorName.DvRequired = true;
                tbRemittorAddress.DvRegCode = "reg702";
                tbRemittorAddress.DvMinLength = 0;
                tbRemittorAddress.DvMaxLength = 140;
                tbRemittorAddress.DvRequired = false;
            }

            else if (m_appType == AppliableFunctionType.TransferForeignMoney)
            {
                tbRemittorName.DvRegCode = "reg662";
                tbRemittorName.DvMinLength = 1;
                tbRemittorName.DvMaxLength = 70;
                tbRemittorName.DvRequired = true;
                tbRemittorAddress.DvRegCode = "reg662";
                tbRemittorAddress.DvMinLength = 0;
                tbRemittorAddress.DvRequired = false;
                tbRemittorAddress.DvMaxLength = 70;
            }
            else if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                tbRemittorAddress.DvRegCode = "reg662";
                tbRemittorAddress.DvMinLength = 0;
                tbRemittorAddress.DvMaxLength = 64;
                tbRemittorAddress.DvRequired = false;
            }

        }
        void cmbPurchaseAccount_TextChanged(object sender, EventArgs e)
        {
            if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                cmbSpotAccount.Enabled = tbSpotAmount.Enabled = string.IsNullOrEmpty(cmbPurchaseAccount.Text.Trim());
                if (!cmbSpotAccount.Enabled)
                    tbSpotAmount.Text = string.Empty;
            }

        }

        void cmbSpotAccount_TextChanged(object sender, EventArgs e)
        {
            if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                cmbPurchaseAccount.Enabled = tbPurchaseAmount.Enabled = string.IsNullOrEmpty(cmbSpotAccount.Text.Trim());
                if (!cmbPurchaseAccount.Enabled)
                    tbPurchaseAmount.Text = string.Empty;
            }
        }

        public void GetItem()
        {
            bool flag = m_appType == AppliableFunctionType.TransferOverCountry4Bar;

            m_TransferGlobal = new TransferGlobal();
            m_TransferGlobal.CustomerRef = tbCustomerRef.Text.Trim();
            if (m_appType == AppliableFunctionType.TransferForeignMoney
                || m_appType == AppliableFunctionType.TransferOverCountry)
            {
                DateTime dt = dtpRemitDate.Value;
                m_TransferGlobal.PayDate = dt.Year + dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0');
            }
            m_TransferGlobal.PaymentType = tbPaymentType.Text.Trim();
            m_TransferGlobal.SendPriority = rbNormal.Checked ? TransferChanelType.Normal : TransferChanelType.Express;
            m_TransferGlobal.PaymentCashType = (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex];
            if (!string.IsNullOrEmpty(tbRemitAmount.Text))
                m_TransferGlobal.RemitAmount = tbRemitAmount.Text.Trim();
            m_TransferGlobal.SpotAccount = cmbSpotAccount.Text.Trim();
            if (!string.IsNullOrEmpty(tbSpotAmount.Text))
                m_TransferGlobal.SpotAmount = tbSpotAmount.Text.Trim();
            m_TransferGlobal.PurchaseAccount = cmbPurchaseAccount.Text.Trim();
            if (!string.IsNullOrEmpty(tbPurchaseAmount.Text))
                m_TransferGlobal.PurchaseAmount = tbPurchaseAmount.Text.Trim();
            m_TransferGlobal.OtherAccount = cmbOtherAccount.Text.Trim();
            if (!string.IsNullOrEmpty(tbOtherAmount.Text))
                m_TransferGlobal.OtherAmount = tbOtherAmount.Text.Trim();
            m_TransferGlobal.PayFeeAccount = GetPayFeeAccount();
            m_TransferGlobal.OrgCode = string.Format("{0}-{1}", tbOrgPre.Text.Trim(), tbOrgEnd.Text.Trim());
            m_TransferGlobal.RemitName = tbRemittorName.Text.Trim();
            m_TransferGlobal.RemitAddress = tbRemittorAddress.Text.Trim();
        }

        private string GetPayFeeAccount()
        {
            string account = string.Empty;
            int index = cmbPayFeeAccount.SelectedIndex;
            account = (index == 0 || EnumNameHelper<PayFeeAccountType>.GetEnumDescription(PayFeeAccountType.SpotAccount).Equals(cmbPayFeeAccount.Text.Trim()))
                ? cmbSpotAccount.Text.Trim()
                : (index == 1 || EnumNameHelper<PayFeeAccountType>.GetEnumDescription(PayFeeAccountType.PurchaseAccount).Equals(cmbPayFeeAccount.Text.Trim()))
                    ? cmbPurchaseAccount.Text.Trim()
                    : (index == 2 || EnumNameHelper<PayFeeAccountType>.GetEnumDescription(PayFeeAccountType.SpotAccount).Equals(cmbPayFeeAccount.Text.Trim()))
                        ? cmbOtherAccount.Text.Trim()
                        : cmbPayFeeAccount.Text.Trim();
            return account;
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData() { Result = true };
            rd.Result = base.CheckValid();
            //if (!string.IsNullOrEmpty(tbCustomerRef.Text.Trim()))
            //{
            //    rd = DataCheckCenter.CheckCustomerRefNoGJOrUPEx(tbCustomerRef, tbCustomerRef.Text.Trim(), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (cmbRemitCashType.SelectedIndex < 0)
            //{
            //    MessageBoxPrime.Show(string.Format("{0}{1}", MultiLanguageConvertHelper.Information_Please_Input, lbRemitCashType.Text.Substring(0, lbRemitCashType.Text.Length - 1)), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            rd.Result = rd.Result & DataCheckCenter.CheckCash(tbRemitAmount, tbRemitAmount.Text.Trim(), lbRemitAmount.Text.Substring(0, lbRemitAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1).Result;
            //if (!rd.Result) return rd.Result;
            if (m_appType != AppliableFunctionType.TransferForeignMoney4Bar || (m_appType == AppliableFunctionType.TransferForeignMoney4Bar && !string.IsNullOrEmpty(cmbSpotAccount.Text.Trim())))
            {
                if (string.IsNullOrEmpty(cmbSpotAccount.Text) && string.IsNullOrEmpty(cmbPurchaseAccount.Text) && string.IsNullOrEmpty(cmbOtherAccount.Text))
                {
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.TransferGlobal_Select_One_of_Three_Account, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    rd.Result = false;
                }

                if (!ChackAmount())
                {
                    MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.Information_Sum_Must_Equal_AllAmount, new string[]{
                                                                MultiLanguageConvertHelper.TransferGlobal_SpotAmount,
                                                                MultiLanguageConvertHelper.TransferGlobal_PurchaseAmount,
                                                                MultiLanguageConvertHelper.TransferGlobal_OtherAmount,
                                                                MultiLanguageConvertHelper.TransferGlobal_RemitAmount,})
                      , CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); rd.Result = false;
                }
            }
            if (!string.IsNullOrEmpty(cmbSpotAccount.Text))
            {
                if (string.IsNullOrEmpty(tbSpotAmount.Text))
                {
                    MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_SpotAmount), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    rd.Result = false;
                }
                else
                {
                    rd.Result = rd.Result & DataCheckCenter.CheckCash(tbSpotAmount, tbSpotAmount.Text.Trim(), lbSpotAmount.Text.Substring(0, lbSpotAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1).Result;
                    //if (!rd.Result) return rd.Result;
                }
            }
            if (!string.IsNullOrEmpty(cmbPurchaseAccount.Text))
            {
                if (string.IsNullOrEmpty(tbPurchaseAmount.Text))
                {
                    MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_PurchaseAmount), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    rd.Result = false;
                }
                else
                {
                    rd.Result = rd.Result & DataCheckCenter.CheckCash(tbPurchaseAmount, tbPurchaseAmount.Text.Trim(), lbPurchaseAmount.Text.Substring(0, lbPurchaseAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1).Result;
                    //if (!rd.Result) return rd.Result;
                }
            }
            if (!string.IsNullOrEmpty(cmbOtherAccount.Text))
            {
                if (string.IsNullOrEmpty(tbOtherAmount.Text))
                {
                    MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Input, MultiLanguageConvertHelper.TransferGlobal_OtherAmount), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    rd.Result = false;
                }
                else
                {
                    rd.Result = rd.Result & DataCheckCenter.CheckCash(tbOtherAmount, tbOtherAmount.Text.Trim(), lbOtherAmount.Text.Substring(0, lbOtherAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1).Result;
                    //if (!rd.Result) return rd.Result;
                }
            }
            //rd = DataCheckCenter.CheckOrgCode(tbOrgEnd, string.Format("{0}-{1}", tbOrgPre.Text.Trim(), tbOrgEnd.Text.Trim()), lbOrgCode.Text.Substring(0, lbOrgCode.Text.Length - 1), this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            //{
            //    rd = DataCheckCenter.CheckNameAndAddressLengthGJ(tbRemittorName, tbRemittorName.Text.Trim(), tbRemittorAddress.Text.Trim(), lbRemittorName.Text.Substring(0, lbRemittorName.Text.Length - 1), lbRemittorAddress.Text.Substring(0, lbRemittorAddress.Text.Length - 1), 140, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //if (m_appType == AppliableFunctionType.TransferOverCountry
            //    || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            //{
            //    rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbRemittorName, tbRemittorName.Text.Trim(), lbRemittorName.Text.Substring(0, lbRemittorName.Text.Length - 1), 140, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //    if (!string.IsNullOrEmpty(tbRemittorAddress.Text.Trim()))
            //    {
            //        rd = DataCheckCenter.CheckPayeeNameOrAddressGJEx(tbRemittorAddress, tbRemittorAddress.Text.Trim(), lbRemittorAddress.Text.Substring(0, lbRemittorAddress.Text.Length - 1), 140, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //}

            //else if (m_appType == AppliableFunctionType.TransferForeignMoney)
            //{
            //    rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbRemittorName, tbRemittorName.Text.Trim(), lbRemittorName.Text.Substring(0, lbRemittorName.Text.Length - 1), 70, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //    if (!string.IsNullOrEmpty(tbRemittorAddress.Text.Trim()))
            //    {
            //        rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbRemittorAddress, tbRemittorAddress.Text.Trim(), lbRemittorAddress.Text.Substring(0, lbRemittorAddress.Text.Length - 1), 70, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //}
            //else if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            //{
            //    if (!string.IsNullOrEmpty(tbRemittorAddress.Text.Trim()))
            //    {
            //        rd = DataCheckCenter.CheckPayeeNameOrAddressGJ(tbRemittorAddress, tbRemittorAddress.Text.Trim(), lbRemittorAddress.Text.Substring(0, lbRemittorAddress.Text.Length - 1), 64, this.errorProvider1);
            //        if (!rd.Result) return rd.Result;
            //    }
            //}
            //rd.Result = rd.Result & DataCheckCenter.CheckOrgCode(tbOrgEnd, string.Format("{0}-{1}", tbOrgPre.Text.Trim(), tbOrgEnd.Text.Trim()), lbOrgCode.Text.Substring(0, lbOrgCode.Text.Length - 1), this.errorProvider1).Result;
            //if (!rd.Result) return rd.Result;
            return rd.Result;
        }

        private bool GetCashTypeIsJap()
        {
            bool flag = false;
            if (this.cmbRemitCashType.SelectedIndex >= 0)
            {
                if (cmbRemitCashType.Tag != null)
                {
                    flag = (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex] == CashType.JPY;
                }
            }
            return flag;
        }

        private bool ChackAmount()
        {
            if (string.IsNullOrEmpty(tbRemitAmount.Text) || !Regex.IsMatch(tbRemitAmount.Text.Trim(), @"^[0-9,]{1,}(\.([0-9]*)?)?$", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
            {
                tbRemitAmount.DvErrorProvider.SetError(tbRemitAmount, "请输入金额！"); return false;
            }
            bool flag = false;
            double remitamount = double.Parse(tbRemitAmount.Text.Trim());
            double amount = 0.0d;
            if (!string.IsNullOrEmpty(tbSpotAmount.Text.Trim()) || Regex.IsMatch(tbSpotAmount.Text.Trim(), @"^[0-9]{1,}(\.([0-9]*)?)?$", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                amount += double.Parse(tbSpotAmount.Text.Trim());
            if (!string.IsNullOrEmpty(tbPurchaseAmount.Text.Trim()) || Regex.IsMatch(tbPurchaseAmount.Text.Trim(), @"^[0-9]{1,}(\.([0-9]*)?)?$", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                amount += double.Parse(tbPurchaseAmount.Text.Trim());
            if (!string.IsNullOrEmpty(tbOtherAmount.Text.Trim()) || Regex.IsMatch(tbOtherAmount.Text.Trim(), @"^[0-9]{1,}(\.([0-9]*)?)?$", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                amount += double.Parse(tbOtherAmount.Text.Trim());
            if (remitamount == amount) flag = true;
            return flag;
        }

        private void SetItem(TransferGlobal item)
        {
            if (null == item)
            {
                if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar
                   || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
                {
                    tbCustomerRef.Text =
                    tbRemitAmount.Text =
                    tbSpotAmount.Text =
                    tbPurchaseAmount.Text = string.Empty;
                    return;
                }

                dtpRemitDate.Value = dtpRemitDate.MinDate;

                cmbRemitCashType.SelectedIndex = -1;
                cmbPurchaseAccount.SelectedIndex =
                cmbOtherAccount.SelectedIndex =
                cmbPayFeeAccount.SelectedIndex = -1;

                cmbRemitCashType.Text =
                cmbSpotAccount.Text =
                cmbPurchaseAccount.Text =
                cmbOtherAccount.Text =
                cmbPayFeeAccount.Text =
                tbSpotAmount.Text =
                tbCustomerRef.Text =
                tbRemitAmount.Text =
                cmbSpotAccount.Text =
                tbSpotAmount.Text =
                tbPurchaseAmount.Text =
                tbOtherAmount.Text =
                tbOrgPre.Text =
                tbOrgEnd.Text =
                tbRemittorName.Text =
                tbRemittorAddress.Text = string.Empty;

                rbNormal.Checked = true;
                rbExpress.Checked = !rbNormal.Checked;
            }
            else
            {
                if (m_appType == AppliableFunctionType.TransferForeignMoney
                    || m_appType == AppliableFunctionType.TransferOverCountry)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(item.PayDate))
                        {
                            string tempDateTime = DataConvertHelper.FormatDateTimeFromInt(item.PayDate);
                            ResultData rd = DataCheckCenter.CheckPayDatetime(null, tempDateTime, lbRemitDate.Text.Substring(0, lbRemitDate.Text.Length - 1), null);
                            if (rd.Result)
                                this.dtpRemitDate.Value = DateTime.Parse(tempDateTime);
                        }
                    }
                    catch { dtpRemitDate.Value = dtpRemitDate.MinDate; }
                }
                tbCustomerRef.Text = item.CustomerRef;
                rbNormal.Checked = item.SendPriority == TransferChanelType.Normal;
                rbExpress.Checked = !rbNormal.Checked;
                cmbRemitCashType.SelectedIndex = (cmbRemitCashType.Tag as List<CashType>).FindIndex(o => o == item.PaymentCashType);
                tbRemitAmount.Text = item.RemitAmountString;
                cmbSpotAccount.Text = item.SpotAccount;
                tbSpotAmount.Text = item.SpotAmountString;
                cmbPurchaseAccount.Text = item.PurchaseAccount;
                tbPurchaseAmount.Text = item.PurchaseAmountString;
                cmbOtherAccount.Text = item.OtherAccount;
                tbOtherAmount.Text = item.OtherAmountString;
                cmbPayFeeAccount.Text = item.PayFeeAccount;
                if (!string.IsNullOrEmpty(item.OrgCode))
                {
                    string[] orgcode = item.OrgCode.Split('-');
                    tbOrgPre.Text = orgcode[0];
                    tbOrgEnd.Text = orgcode[1];
                }
                tbRemittorName.Text = item.RemitName;
                tbRemittorAddress.Text = item.RemitAddress;
            }
        }

        private void cmbSpotAccount_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbSpotAccount.Text))
            {
                cmbSpotAccount.DvRegCode = "reg57";
                cmbSpotAccount.DvMinLength = 12;
                cmbSpotAccount.DvMaxLength = 18;
                cmbSpotAccount.DvRequired = true;

                //金额校验
                //rd = DataCheckCenter.Instance.CheckCash(tbSpotAmount, tbSpotAmount.Text.Trim(), lbSpotAmount.Text.Substring(0, lbSpotAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
                //if (!rd.Result) return rd.Result;

            }
            else
            {
                cmbSpotAccount.DvRegCode = "";
                cmbSpotAccount.DvMinLength = 0;
                cmbSpotAccount.DvMaxLength = 0;
                cmbSpotAccount.DvRequired = false;
            }
        }

        private void cmbPurchaseAccount_TextChanged_1(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(cmbPurchaseAccount.Text))
            {
                cmbPurchaseAccount.DvRegCode = "reg57";
                cmbPurchaseAccount.DvMinLength = 12;
                cmbPurchaseAccount.DvMaxLength = 18;
                cmbPurchaseAccount.DvRequired = true;
                //金额校验
                //rd = DataCheckCenter.Instance.CheckCash(tbPurchaseAmount, tbPurchaseAmount.Text.Trim(), lbPurchaseAmount.Text.Substring(0, lbPurchaseAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
                //if (!rd.Result) return rd.Result;

            }
            else
            {
                cmbPurchaseAccount.DvRegCode = "";
                cmbPurchaseAccount.DvMinLength = 0;
                cmbPurchaseAccount.DvMaxLength = 0;
                cmbPurchaseAccount.DvRequired = false;
            }
        }

        private void cmbOtherAccount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbOtherAccount.Text))
            {
                cmbOtherAccount.DvRegCode = "reg57";
                cmbOtherAccount.DvMinLength = 12;
                cmbOtherAccount.DvMaxLength = 18;
                cmbOtherAccount.DvRequired = true;
                //金额校验
                //rd = DataCheckCenter.Instance.CheckCash(tbOtherAmount, tbOtherAmount.Text.Trim(), lbOtherAmount.Text.Substring(0, lbOtherAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
                //if (!rd.Result) return rd.Result;

            }
            else
            {
                cmbOtherAccount.DvRegCode = "";
                cmbOtherAccount.DvMinLength = 0;
                cmbOtherAccount.DvMaxLength = 0;
                cmbOtherAccount.DvRequired = false;
            }

        }

        void tbOrgPre_LostFocus(object sender, EventArgs e)
        {
            DataCheckCenter.CheckOrgCode(tbOrgEnd, string.Format("{0}-{1}", tbOrgPre.Text.Trim(), tbOrgEnd.Text.Trim()), lbOrgCode.Text.Substring(0, lbOrgCode.Text.Length - 1), this.errorProvider1);
        }

        private void tbRemitAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDescR.Text = DataConvertHelper.ConvertA2CN(tbRemitAmount.Text.Trim(), 15, cmbRemitCashType.SelectedIndex == -1 ? CashType.CNY : (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex]);
        }

        private void tbSpotAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDescS.Text = DataConvertHelper.ConvertA2CN(tbSpotAmount.Text.Trim(), 15, cmbRemitCashType.SelectedIndex == -1 ? CashType.CNY : (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex]);
        }

        private void tbPurchaseAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDescP.Text = DataConvertHelper.ConvertA2CN(tbPurchaseAmount.Text.Trim(), 15, cmbRemitCashType.SelectedIndex == -1 ? CashType.CNY : (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex]);
        }

        private void tbOtherAmount_TextChanged(object sender, EventArgs e)
        {
            lbAmountDescO.Text = DataConvertHelper.ConvertA2CN(tbOtherAmount.Text.Trim(), 15, cmbRemitCashType.SelectedIndex == -1 ? CashType.CNY : (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex]);
        }

        private void cmbPayFeeAccount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbPayFeeAccount.Text))
            {
                if (!(cmbPayFeeAccount.Text == "同现汇账户" || cmbPayFeeAccount.Text == "同购汇账户" || cmbPayFeeAccount.Text == "同其他账户"))
                {
                    cmbPayFeeAccount.DvRegCode = "reg57";
                    cmbPayFeeAccount.DvMinLength = 12;
                    cmbPayFeeAccount.DvMaxLength = 18;
                    cmbPayFeeAccount.DvRequired = true;
                }
                else
                {
                    cmbPayFeeAccount.DvRegCode = "";
                    cmbPayFeeAccount.DvMinLength = 0;
                    cmbPayFeeAccount.DvMaxLength = 0;
                    cmbPayFeeAccount.DvRequired = false;
                }
                //金额校验
                //rd = DataCheckCenter.Instance.CheckCash(tbOtherAmount, tbOtherAmount.Text.Trim(), lbOtherAmount.Text.Substring(0, lbOtherAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
                //if (!rd.Result) return rd.Result;

            }
            else
            {
                cmbPayFeeAccount.DvRegCode = "";
                cmbPayFeeAccount.DvMinLength = 0;
                cmbPayFeeAccount.DvMaxLength = 0;
                cmbPayFeeAccount.DvRequired = false;
            }

        }
    }
}
