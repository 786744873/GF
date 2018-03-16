using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class TransferGlobalRemitSelector : BaseUc
    {
        public TransferGlobalRemitSelector()
        {
            InitializeComponent();

            dtpRemitDate.MinDate = DateTime.Today;
            dtpRemitDate.MaxDate = DateTime.Today.AddMonths(1);
            InitData();

            CommandCenter.Instance.OnTransferGlobalEventHandler += new EventHandler<TransferGlobalEventArgs>(CommandCenter_OnTransferGlobalEventHandler);
            CommandCenter.Instance.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnCashTypeChangedEventHandler += new EventHandler<CashTypeChangedEventArgs>(CommandCenter_OnCashTypeChangedEventHandler);
            this.Load += new EventHandler(TransferGlobalRemitEditor_Load);
            cmbRemitCashType.SelectedIndexChanged += new EventHandler(cmbRemitCashType_SelectedIndexChanged);
            tbRemitAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            tbSpotAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            tbPurchaseAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            tbOtherAmount.LostFocus += new EventHandler(tbAmount_LostFocus);
            cmbSpotAccount.LostFocus += new EventHandler(cmbAccount_LostFocus);
            cmbPurchaseAccount.LostFocus += new EventHandler(cmbAccount_LostFocus);
            cmbOtherAccount.LostFocus += new EventHandler(cmbAccount_LostFocus);
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


        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBox).Text.Trim()))
            {
                (sender as TextBox).Text = DataConvertHelper.Instance.FormatCash((sender as TextBox).Text.Trim(), GetCashTypeIsJap());
            }
        }

        void cmbRemitCashType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)m_appType > 0) return;
            cmbSpotAccount.Items.Clear();
            if (cmbRemitCashType.SelectedIndex >= 0)
            {
                List<PayerInfo> list = new List<PayerInfo>();
                list = SystemSettings.Instance.PayerList.FindAll(o => o.CashType == (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex]);
                cmbSpotAccount.Items.AddRange(list.ToArray());
                cmbSpotAccount.Tag = list;
                if (!isCallBack)
                    CommandCenter.Instance.ResolveCashTypeChanged(OperatorCommandType.CardTypeRequest, (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex], m_appType, false);
            }
            else cmbRemitCashType.SelectedIndex = 0;

            if (isCallBack) isCallBack = false;
        }

        void TransferGlobalRemitEditor_Load(object sender, EventArgs e)
        {
            List<PayerInfo> listCNY = SystemSettings.Instance.PayerList.FindAll(o => o.CashType == CashType.CNY);
            List<PayerInfo> list = new List<PayerInfo>();
            list.AddRange(SystemSettings.Instance.PayerList.ToArray());
            cmbPurchaseAccount.Items.AddRange(listCNY.ToArray());
            cmbPurchaseAccount.Tag = listCNY;
            cmbOtherAccount.Items.AddRange(list.ToArray());
            cmbOtherAccount.Tag = list;
            cmbPayFeeAccount.Items.AddRange(list.ToArray());
            cmbPayFeeAccount.Tag = list;
        }

        void CommandCenter_OnPayerInfoEventHandler(object sender, PayerEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler), sender, e); }
            else
            {
                if (e.PayerInfo == null || (e.PayerInfo.ServiceList & m_appType) != m_appType) return;
                if (e.Command == OperatorCommandType.Submit || e.Command == OperatorCommandType.Edit)
                {
                    int index = -1;
                    if (e.PayerInfo.CashType == CashType.CNY)
                    {
                        index = (cmbPurchaseAccount.Tag as List<PayerInfo>).FindIndex(o => o.ToString().Equals(e.PayerInfo.ToString()));
                        if (index < 0)
                        {
                            cmbPurchaseAccount.Items.Add(e.PayerInfo);
                            (cmbPurchaseAccount.Tag as List<PayerInfo>).Add(e.PayerInfo);
                            index = -1;

                        }
                    }
                    if (cmbRemitCashType.SelectedIndex >= 0 && e.PayerInfo.CashType == (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex])
                    {
                        index = (cmbSpotAccount.Tag as List<PayerInfo>).FindIndex(o => o.ToString().Equals(e.PayerInfo.ToString()));
                        if (index < 0)
                        {
                            cmbSpotAccount.Items.Add(e.PayerInfo);
                            (cmbSpotAccount.Tag as List<PayerInfo>).Add(e.PayerInfo);
                            index = -1;
                        }
                    }
                    index = (cmbOtherAccount.Tag as List<PayerInfo>).FindIndex(o => o.ToString().Equals(e.PayerInfo.ToString()));
                    if (index < 0)
                    {
                        if (m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferForeignMoney)
                        {
                            cmbOtherAccount.Items.Add(e.PayerInfo);
                            (cmbOtherAccount.Tag as List<PayerInfo>).Add(e.PayerInfo);
                            index = -1;
                        }
                    }
                    index = (cmbPayFeeAccount.Tag as List<PayerInfo>).FindIndex(o => o.ToString().Equals(e.PayerInfo.ToString()));
                    if (index < 0)
                    {
                        cmbPayFeeAccount.Items.Add(e.PayerInfo);
                        (cmbPayFeeAccount.Tag as List<PayerInfo>).Add(e.PayerInfo);
                        index = -1;
                    }
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    int index = -1;
                    if (e.PayerInfo.CashType == CashType.CNY)
                    {
                        index = (cmbPurchaseAccount.Tag as List<PayerInfo>).FindIndex(o => o.ToString().Equals(e.PayerInfo.ToString()));
                        if (index >= 0)
                        {
                            cmbPurchaseAccount.Items.RemoveAt(index);
                            (cmbPurchaseAccount.Tag as List<PayerInfo>).RemoveAt(index);
                            index = -1;
                        }
                    }
                    if (cmbRemitCashType.SelectedIndex >= 0 && e.PayerInfo.CashType == (cmbRemitCashType.Tag as List<CashType>)[cmbRemitCashType.SelectedIndex])
                    {
                        index = (cmbSpotAccount.Tag as List<PayerInfo>).FindIndex(o => o.ToString().Equals(e.PayerInfo.ToString()));
                        if (index >= 0)
                        {
                            cmbSpotAccount.Items.RemoveAt(index);
                            (cmbSpotAccount.Tag as List<PayerInfo>).RemoveAt(index);
                            index = -1;
                        }
                    }
                    index = (cmbOtherAccount.Tag as List<PayerInfo>).FindIndex(o => o.ToString().Equals(e.PayerInfo.ToString()));
                    if (index >= 0)
                    {
                        if (m_appType == AppliableFunctionType.TransferOverCountry || m_appType == AppliableFunctionType.TransferForeignMoney)
                        {
                            cmbOtherAccount.Items.RemoveAt(index);
                            (cmbOtherAccount.Tag as List<PayerInfo>).RemoveAt(index);
                            index = -1;
                        }
                    }
                    index = (cmbPayFeeAccount.Tag as List<PayerInfo>).FindIndex(o => o.ToString().Equals(e.PayerInfo.ToString()));
                    if (index >= 0)
                    {
                        cmbPayFeeAccount.Items.RemoveAt(index);
                        (cmbPayFeeAccount.Tag as List<PayerInfo>).RemoveAt(index);
                        index = -1;
                    }
                }
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
                        if (item is BOC_BATCH_TOOL.Controls.TextBoxCanValidate)
                        {
                            ((BOC_BATCH_TOOL.Controls.TextBoxCanValidate)item).CharacterCasing = CharacterCasing.Upper;
                        }
                    }
                }
                cmbSpotAccount.Items.Clear();
                List<PayerInfo> list = SystemSettings.Instance.PayerList.FindAll(o => true);
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
            ResultData rd = new ResultData();
            if (!string.IsNullOrEmpty(tbCustomerRef.Text.Trim()))
            {
                rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(tbCustomerRef, tbCustomerRef.Text.Trim(), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (cmbRemitCashType.SelectedIndex < 0)
            {
                MessageBoxExHelper.Instance.Show(string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, lbRemitCashType.Text.Substring(0, lbRemitCashType.Text.Length - 1)), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            rd = DataCheckCenter.Instance.CheckCash(tbRemitAmount, tbRemitAmount.Text.Trim(), lbRemitAmount.Text.Substring(0, lbRemitAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (m_appType != AppliableFunctionType.TransferForeignMoney4Bar || (m_appType == AppliableFunctionType.TransferForeignMoney4Bar && !string.IsNullOrEmpty(cmbSpotAccount.Text.Trim())))
            {
                if (string.IsNullOrEmpty(cmbSpotAccount.Text) && string.IsNullOrEmpty(cmbPurchaseAccount.Text) && string.IsNullOrEmpty(cmbOtherAccount.Text))
                {
                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.TransferGlobal_Select_One_of_Three_Account, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (!ChackAmount())
                {
                    MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.Information_Sum_Must_Equal_AllAmount, new string[]{
                                                                MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount,
                                                                MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount,
                                                                MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAmount,
                                                                MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAmount,})
                      , CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
                }
            }
            if (!string.IsNullOrEmpty(cmbSpotAccount.Text))
            {
                rd = DataCheckCenter.Instance.CheckPayerAccount(cmbSpotAccount, cmbSpotAccount.Text.Trim(), lbSpotAccount.Text.Substring(0, lbSpotAccount.Text.Length - 1), this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (string.IsNullOrEmpty(tbSpotAmount.Text))
                {
                    MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    rd = DataCheckCenter.Instance.CheckCash(tbSpotAmount, tbSpotAmount.Text.Trim(), lbSpotAmount.Text.Substring(0, lbSpotAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }
            if (!string.IsNullOrEmpty(cmbPurchaseAccount.Text))
            {
                rd = DataCheckCenter.Instance.CheckPayerAccount(cmbPurchaseAccount, cmbPurchaseAccount.Text.Trim(), lbPurchaseAccount.Text.Substring(0, lbPurchaseAccount.Text.Length - 1), this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (string.IsNullOrEmpty(tbPurchaseAmount.Text))
                {
                    MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    rd = DataCheckCenter.Instance.CheckCash(tbPurchaseAmount, tbPurchaseAmount.Text.Trim(), lbPurchaseAmount.Text.Substring(0, lbPurchaseAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }
            if (!string.IsNullOrEmpty(cmbOtherAccount.Text))
            {
                rd = DataCheckCenter.Instance.CheckPayerAccount(cmbOtherAccount, cmbOtherAccount.Text.Trim(), lbOtherAccount.Text.Substring(0, lbOtherAccount.Text.Length - 1), this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (string.IsNullOrEmpty(tbOtherAmount.Text))
                {
                    MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Input, MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAmount), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    rd = DataCheckCenter.Instance.CheckCash(tbOtherAmount, tbOtherAmount.Text.Trim(), lbOtherAmount.Text.Substring(0, lbOtherAmount.Text.Length - 1), 15, GetCashTypeIsJap(), this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }
            rd = DataCheckCenter.Instance.CheckOrgCode(tbOrgEnd, string.Format("{0}-{1}", tbOrgPre.Text.Trim(), tbOrgEnd.Text.Trim()), lbOrgCode.Text.Substring(0, lbOrgCode.Text.Length - 1), this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(tbRemittorName, tbRemittorName.Text.Trim(), tbRemittorAddress.Text.Trim(), lbRemittorName.Text.Substring(0, lbRemittorName.Text.Length - 1), lbRemittorAddress.Text.Substring(0, lbRemittorAddress.Text.Length - 1), 140, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if (m_appType == AppliableFunctionType.TransferOverCountry
                || m_appType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(tbRemittorName, tbRemittorName.Text.Trim(), lbRemittorName.Text.Substring(0, lbRemittorName.Text.Length - 1), 140, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (!string.IsNullOrEmpty(tbRemittorAddress.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(tbRemittorAddress, tbRemittorAddress.Text.Trim(), lbRemittorAddress.Text.Substring(0, lbRemittorAddress.Text.Length - 1), 140, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }

            else if (m_appType == AppliableFunctionType.TransferForeignMoney)
            {
                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(tbRemittorName, tbRemittorName.Text.Trim(), lbRemittorName.Text.Substring(0, lbRemittorName.Text.Length - 1), 70, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                if (!string.IsNullOrEmpty(tbRemittorAddress.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(tbRemittorAddress, tbRemittorAddress.Text.Trim(), lbRemittorAddress.Text.Substring(0, lbRemittorAddress.Text.Length - 1), 70, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }
            else if (m_appType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                if (!string.IsNullOrEmpty(tbRemittorAddress.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(tbRemittorAddress, tbRemittorAddress.Text.Trim(), lbRemittorAddress.Text.Substring(0, lbRemittorAddress.Text.Length - 1), 64, this.errorProvider1);
                    if (!rd.Result) return rd.Result;
                }
            }

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
            bool flag = false;
            double remitamount = double.Parse(tbRemitAmount.Text.Trim());
            double amount = 0.0d;
            if (!string.IsNullOrEmpty(tbSpotAmount.Text.Trim()))
                amount += double.Parse(tbSpotAmount.Text.Trim());
            if (!string.IsNullOrEmpty(tbPurchaseAmount.Text.Trim()))
                amount += double.Parse(tbPurchaseAmount.Text.Trim());
            if (!string.IsNullOrEmpty(tbOtherAmount.Text.Trim()))
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

                cmbRemitCashType.Text=
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
                            string tempDateTime = DataConvertHelper.Instance.FormatDateTimeFromInt(item.PayDate);
                            ResultData rd = DataCheckCenter.Instance.CheckPayDatetime(null, tempDateTime, lbRemitDate.Text.Substring(0, lbRemitDate.Text.Length - 1), null);
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
    }
}
