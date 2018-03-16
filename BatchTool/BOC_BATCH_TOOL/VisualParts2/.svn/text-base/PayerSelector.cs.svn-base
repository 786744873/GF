using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.VisualParts;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualElements
{
    public partial class PayerSelector : BaseUc
    {
        public PayerSelector()
        {
            InitializeComponent();
            this.Load += new EventHandler(PayerSelector_Load);
            CommandCenter.Instance.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.Instance.OnTransferAccountEventHandler += new EventHandler<TransferEventArgs>(CommandCenter_OnTransferAccountEventHandler);
            CommandCenter.Instance.OnElecTicketRemitEvenHnadler += new EventHandler<ElecTicketRemitEventArgs>(CommandCenter_OnElecTicketRemitEvenHnadler);
            CommandCenter.Instance.OnElecTicketAutoTipExchangeEventHandler += new EventHandler<ElecTicketAutoTipExchangeEventArgs>(CommandCenter_OnElecTicketAutoTipExchangeEventHandler);
            CommandCenter.Instance.OnElecTicketBackNoteEventHandler += new EventHandler<ElecTicketBackNoteEventArgs>(CommandCenter_OnElecTicketBackNoteEventHandler);
            CommandCenter.Instance.OnElecTicketPayMoneyEventHandler += new EventHandler<ElecTicketPayMoneyEventArgs>(CommandCenter_OnElecTicketPayMoneyEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnCommonDataEventHandler += new EventHandler<CommonDataEventArgs>(CommandCenter_OnCommonDataEventHandler);
            CommandCenter.Instance.OnUnitivePaymentRMBEventHandler += new EventHandler<UnitivePaymentRMBEventArgs>(CommandCenter_OnUnitivePaymentRMBEventHandler);
            //CommandCenter.Instance.OnElecTicketRelateAccountEventHandler += new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler);
            cbAccount.TextChanged += new EventHandler(cbAccount_TextChanged);
        }

        void CommandCenter_OnUnitivePaymentRMBEventHandler(object sender, UnitivePaymentRMBEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<UnitivePaymentRMBEventArgs>(CommandCenter_OnUnitivePaymentRMBEventHandler), sender, e); }
            else
            {
                if (AppType != e.OwnerType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.Reset)
                {
                    cbAccount.SelectedIndex = -1;
                    cbAccount.Text =
                    tbName.Text = string.Empty;
                }
                else if (e.Command == OperatorCommandType.View)
                {
                    cbAccount.MatchStrFlag = false;
                    cbAccount.Text = e.UnitivePaymentRMB.PayerAccount;
                    tbName.Text = e.UnitivePaymentRMB.PayerName;
                    cbAccount.MatchStrFlag = true;
                }
            }
        }

        void CommandCenter_OnElecTicketRelateAccountEventHandler(object sender, ElecTicketRelateAccountEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler), sender, e); }
            else
            {
                if (m_AppType != AppliableFunctionType.ElecTicketRemit
                    && m_AppType != AppliableFunctionType.ElecTicketTipExchange
                    && m_AppType != AppliableFunctionType.ElecTicketBackNote
                    && m_AppType != AppliableFunctionType.ElecTicketPayMoney)
                    return;
                if (e.Command == OperatorCommandType.Edit)
                {
                    if ((e.RelationAccount.PersonType & RelatePersonType.Remittor) != RelatePersonType.Remittor) return;
                    cbAccount.Items.Add(e.RelationAccount);
                    List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
                    if (cbAccount.Tag != null) list = cbAccount.Tag as List<ElecTicketRelationAccount>;
                    list.Add(e.RelationAccount);
                    cbAccount.Tag = list;
                }
                else if (e.Command == OperatorCommandType.Edit)
                {
                    List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
                    if (cbAccount.Tag != null) list = cbAccount.Tag as List<ElecTicketRelationAccount>;
                    int index = list.FindIndex(o => o.Account == e.RelationAccount.Account);
                    if (index != -1)
                    {
                        list[index] = e.RelationAccount;
                        cbAccount.Items[index] = e.RelationAccount;
                    }
                    cbAccount.Tag = list;
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    if ((e.RelationAccount.PersonType & RelatePersonType.Remittor) != RelatePersonType.Remittor) return;
                    cbAccount.Items.Add(e.RelationAccount);
                    List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
                    if (cbAccount.Tag != null) list = cbAccount.Tag as List<ElecTicketRelationAccount>;
                    int index = list.FindIndex(o => o.Account == e.RelationAccount.Account);
                    if (index != -1)
                    {
                        cbAccount.Items.RemoveAt(index);
                        list.RemoveAt(index);
                    }
                    cbAccount.Tag = list;
                }
                else if (e.Command == OperatorCommandType.Load)
                {
                    List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
                    list = e.RelationAccountList.FindAll(o => (o.PersonType & RelatePersonType.Remittor) == RelatePersonType.Remittor);
                    cbAccount.Items.Clear();
                    cbAccount.Items.AddRange(list.ToArray());
                    cbAccount.Tag = list;
                }
            }
        }

        void CommandCenter_OnCommonDataEventHandler(object sender, CommonDataEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<CommonDataEventArgs>(CommandCenter_OnCommonDataEventHandler), sender, e); }
            else
            {
                if (!e.CommonFields.ContainsKey(m_AppType)) return;
                p_lockPayerAccount.Visible =
                p_lockPayerName.Visible =
                islockShow = e.Command == OperatorCommandType.CommonFieldLockShow;
            }
        }

        void cbAccount_TextChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            string matchstr = cbAccount.Text.Trim();
            bool flag = m_AppType == AppliableFunctionType.ElecTicketRemit
                || m_AppType == AppliableFunctionType.ElecTicketTipExchange
                || m_AppType == AppliableFunctionType.ElecTicketBackNote
                || m_AppType == AppliableFunctionType.ElecTicketPayMoney;
            //(cbAccount.Tag as List<ElecTicketRelationAccount>).FindAll(o => o.ToString().Contains(matchstr));
            //(cbAccount.Tag as List<PayerInfo>).FindAll(o => o.ToString().Contains(matchstr));
            List<PayerInfo> temp = (cbAccount.Tag as List<PayerInfo>).FindAll(o => o.ToString().Contains(matchstr));
            foreach (var item in temp)
            {
                acsc.Add(item.ToString());
            }
            cbAccount.AutoCompleteCustomSource = acsc;
            cbAccount.Text = matchstr;
            cbAccount.Select(cbAccount.Text.Trim().Length, 0);
        }

        void CommandCenter_OnElecTicketPayMoneyEventHandler(object sender, ElecTicketPayMoneyEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketPayMoneyEventArgs>(CommandCenter_OnElecTicketPayMoneyEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                {
                    cbAccount.MatchStrFlag = false;
                    cbAccount.Text = e.ElecTicketPayMoney.RemitAccount;
                    tbName.Text = e.ElecTicketPayMoney.ElecTicketSerialNo;
                    cbAccount.MatchStrFlag = true;
                }
                else if (e.Command == OperatorCommandType.Reset
                    || OperatorCommandType.Submit == e.Command
                    //|| OperatorCommandType.Delete == e.Command
                    || OperatorCommandType.Edit == e.Command)
                {
                    tbName.Text = string.Empty;
                }
                chbSave.Checked = false;
            }
        }

        void CommandCenter_OnElecTicketBackNoteEventHandler(object sender, ElecTicketBackNoteEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketBackNoteEventArgs>(CommandCenter_OnElecTicketBackNoteEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                {
                    cbAccount.MatchStrFlag = false;
                    cbAccount.Text = e.ElecTicketBackNote.RemitAccount;
                    tbName.Text = e.ElecTicketBackNote.ElecTicketSerialNo;
                    cbAccount.MatchStrFlag = true;
                }
                else if (e.Command == OperatorCommandType.Reset
                    || OperatorCommandType.Submit == e.Command
                    //|| OperatorCommandType.Delete == e.Command
                    || OperatorCommandType.Edit == e.Command)
                {
                    cbAccount.Text =
                    tbName.Text = string.Empty;
                }
                chbSave.Checked = false;
            }
        }

        void CommandCenter_OnElecTicketAutoTipExchangeEventHandler(object sender, ElecTicketAutoTipExchangeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketAutoTipExchangeEventArgs>(CommandCenter_OnElecTicketAutoTipExchangeEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                {
                    cbAccount.MatchStrFlag = false;
                    cbAccount.Text = e.ElecTicketAutoTipExchange.RemitAccount;
                    tbName.Text = e.ElecTicketAutoTipExchange.ElecTicketSerialNo;
                    cbAccount.MatchStrFlag = true;
                }
                else if (e.Command == OperatorCommandType.Reset
                    || OperatorCommandType.Submit == e.Command
                    //|| OperatorCommandType.Delete == e.Command
                    || OperatorCommandType.Edit == e.Command)
                {
                    cbAccount.Text =
                    tbName.Text = string.Empty;
                }
                chbSave.Checked = false;
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(PayerSelector), this);
                Init();
            }
        }

        void CommandCenter_OnElecTicketRemitEvenHnadler(object sender, ElecTicketRemitEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketRemitEventArgs>(CommandCenter_OnElecTicketRemitEvenHnadler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                {
                    cbAccount.MatchStrFlag = false;
                    cbAccount.Text = e.ElecTicketRemit.RemitAccount;
                    cbAccount.MatchStrFlag = true;
                }
                else if (e.Command == OperatorCommandType.Reset
                    || OperatorCommandType.Submit == e.Command
                    //|| OperatorCommandType.Delete == e.Command
                    || OperatorCommandType.Edit == e.Command)
                {
                    cbAccount.Text = string.Empty;
                    tbName.Tag = null;
                }
                chbSave.Checked = false;
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
                    cbAccount.MatchStrFlag = false;
                    cbAccount.Text = e.TransferAccount.PayerAccount;
                    tbName.Text = e.TransferAccount.PayerName;
                    cbAccount.MatchStrFlag = true;
                }
                else if (e.Command == OperatorCommandType.Reset
                    || OperatorCommandType.Submit == e.Command
                    || OperatorCommandType.Edit == e.Command)
                {
                    if (!(islockPayer && islockShow))//CommonInformations.Instance.CanClearItem(m_AppType, CommonFieldType.PayerInfo))
                    {
                        cbAccount.Text =
                        tbName.Text = string.Empty;
                    }
                }
                chbSave.Checked = false;
            }
        }

        void CommandCenter_OnPayerInfoEventHandler(object sender, PayerEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != m_AppType && e.OwnerType != AppliableFunctionType._Empty) return;
                if (e.OwnerType == m_AppType || (e.OwnerType == AppliableFunctionType._Empty && (null != e.PayerInfo && ((e.PayerInfo.ServiceList & m_AppType) == m_AppType))))
                {
                    if (e.Command == OperatorCommandType.Submit || e.Command == OperatorCommandType.Edit)
                    {
                        if (null != e.PayerInfo && (e.PayerInfo.ServiceList & m_AppType) != m_AppType) return;
                        if (!(cbAccount.Tag as List<PayerInfo>).Exists(o => o.Account == e.PayerInfo.Account))
                        {
                            cbAccount.Items.Add(e.PayerInfo);
                            (cbAccount.Tag as List<PayerInfo>).Add(e.PayerInfo);
                        }
                        else
                        {
                            int index = (cbAccount.Tag as List<PayerInfo>).FindIndex(o => o.Account == e.PayerInfo.Account);
                            (cbAccount.Tag as List<PayerInfo>)[index] = e.PayerInfo;
                        }
                    }
                    else if (e.Command == OperatorCommandType.Delete)
                    {
                        int index = (cbAccount.Tag as List<PayerInfo>).FindIndex(o => o.Account == e.PayerInfo.Account);
                        if (index >= 0)
                        {
                            cbAccount.Items.RemoveAt(index);
                            (cbAccount.Tag as List<PayerInfo>).RemoveAt(index);
                        }
                    }
                }
            }
        }

        void PayerSelector_Load(object sender, EventArgs e)
        {
        }
        [Browsable(false)]
        public PayerInfo CurrentPayer
        {
            get { return m_Payer; }
            set { m_Payer = value; }
        }
        public bool CanAdd = true;
        [Browsable(true)]
        public AccountCategoryType AccountType
        {
            get { return m_AccountType; }
            set { m_AccountType = value; }
        }
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

        private PayerInfo m_Payer = new PayerInfo();

        private void Init()
        {
            cbAccount.Items.Clear();
            List<PayerInfo> list = SystemSettings.Instance.PayerList.FindAll(o => (o.ServiceList & this.m_AppType) == this.m_AppType);
            cbAccount.Items.AddRange(list.ToArray());
            cbAccount.Tag = list;
            cbAccount.SelectedIndex = -1;
            cbAccount.Text = string.Empty;
            if (m_AppType == AppliableFunctionType.TransferWithIndiv
                || m_AppType == AppliableFunctionType.TransferWithCorp
                || m_AppType == AppliableFunctionType.TransferOverBankOut
                || m_AppType == AppliableFunctionType.TransferOverBankIn)
            {
                bool flag = m_AppType == AppliableFunctionType.TransferOverBankIn;
                lbPayerAccount.Text = string.Format("{0}{1}", !flag ? MultiLanguageConvertHelper.Instance.DesignMain_PayerAccount : MultiLanguageConvertHelper.Instance.DesignMain_PayeeAccount, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
                lbPayerName.Text = string.Format("{0}{1}", !flag ? MultiLanguageConvertHelper.Instance.DesignMain_PayerName : MultiLanguageConvertHelper.Instance.DesignMain_PayeeName, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");

                cbAccount.DropDownStyle = !flag ? ComboBoxStyle.DropDown : ComboBoxStyle.Simple;
                //tbName.ValidateRule.Required =
                lblPayerName.Visible = m_AppType == AppliableFunctionType.TransferOverBankIn;// || m_AppType == AppliableFunctionType.TransferOverBankOut;
            }
            else if (m_AppType == AppliableFunctionType.ElecTicketRemit
                || m_AppType == AppliableFunctionType.ElecTicketBackNote
                || m_AppType == AppliableFunctionType.ElecTicketPayMoney
                || m_AppType == AppliableFunctionType.ElecTicketTipExchange)
            {
                lbPayerAccount.Text = string.Format("{0}{1}", (m_AppType == AppliableFunctionType.ElecTicketRemit || m_AppType == AppliableFunctionType.ElecTicketTipExchange) ? MultiLanguageConvertHelper.Instance.DesignMain_RemitAccount : MultiLanguageConvertHelper.Instance.DesignMain_Account, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
                bool flag = m_AppType != AppliableFunctionType.ElecTicketRemit;
                //tbName.ValidateRule.Required =
                //lbPayerName.Visible =
                lblPayerName.Visible = lbPayerName.Visible = tbName.Visible = flag;
                if (flag)
                {
                    lbPayerName.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.DesignMain_ElecTicket_SerialNo, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
                    tbName.Text = string.Empty;
                    if (lbPayerName.Width < lbPayerAccount.Width)
                    {
                        lbPayerName.Location = new Point { X = lbPayerName.Location.X + lbPayerAccount.Width - lbPayerName.Width, Y = lbPayerName.Location.Y };
                    }
                    else if (lbPayerName.Width > lbPayerAccount.Width)
                    {
                        lbPayerAccount.Location = new Point { X = lbPayerAccount.Location.X - lbPayerAccount.Width + lbPayerName.Width, Y = lbPayerAccount.Location.Y };
                    }
                }
            }
            else if (m_AppType == AppliableFunctionType.UnitivePaymentRMB)
            {
                lbPayerAccount.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.DesignMain_PayerAccount_Real, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
                lbPayerName.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.Instance.DesignMain_PayerName_Real, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            }
        }

        public void GetItem()
        {
            m_Payer = new PayerInfo();
            //PayerInfo payer = (cbAccount.Tag as List<PayerInfo>).Find(o => o.Account == cbAccount.Text.Trim());
            //if (null == payer || string.IsNullOrEmpty(payer.Account))
            //{
            m_Payer.Account = cbAccount.Text.Trim();
            m_Payer.Name = tbName.Text.Trim();
            m_Payer.Tag = tbName.Tag;
            //}
            //else m_Payer = payer;
            m_Payer.ServiceList = m_AppType;
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData();
            if (m_AppType == AppliableFunctionType.ElecTicketRemit
                || m_AppType == AppliableFunctionType.ElecTicketBackNote
                || m_AppType == AppliableFunctionType.ElecTicketPayMoney
                || m_AppType == AppliableFunctionType.ElecTicketTipExchange)
            {
                rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(cbAccount, cbAccount.Text.Trim(), lbPayerAccount.Text.Substring(0, lbPayerAccount.Text.Length - 1), 32, this.errorProvider1);
                if (!rd.Result) { m_Payer = null; return rd.Result; }
            }
            else if (m_AppType == AppliableFunctionType.UnitivePaymentRMB)
            {
                rd = DataCheckCenter.Instance.CheckPayerAccountUP(cbAccount, cbAccount.Text.Trim(), lbPayerAccount.Text.Substring(0, lbPayerAccount.Text.Length - 1), 12, 18, this.errorProvider1);
                if (!rd.Result) { m_Payer = null; return rd.Result; }
                if (!string.IsNullOrEmpty(tbName.Text.Trim()))
                {
                    rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(tbName, tbName.Text.Trim(), lbPayerName.Text.Substring(0, lbPayerName.Text.Length - 1), 200, this.errorProvider1);
                    if (!rd.Result) { m_Payer = null; return rd.Result; }
                }
            }
            else
            {
                rd = DataCheckCenter.Instance.CheckPayerAccount(cbAccount, cbAccount.Text.Trim(), lbPayerAccount.Text.Substring(0, lbPayerAccount.Text.Length - 1), this.errorProvider1);
                if (!rd.Result) { m_Payer = null; return rd.Result; }
            }
            if (m_AppType == AppliableFunctionType.TransferOverBankIn || (m_AppType == AppliableFunctionType.TransferOverBankOut && !string.IsNullOrEmpty(tbName.Text.Trim())))
            {
                rd = DataCheckCenter.Instance.CheckPayerName(tbName, tbName.Text.Trim(), lbPayerName.Text.Replace("：", ""), m_AppType == AppliableFunctionType.TransferOverBankIn ? 70 : 76, this.errorProvider1);
                if (!rd.Result) { m_Payer = null; return rd.Result; }
            }
            else if (m_AppType == AppliableFunctionType.ElecTicketBackNote
                || m_AppType == AppliableFunctionType.ElecTicketPayMoney
                || m_AppType == AppliableFunctionType.ElecTicketTipExchange)
            {
                rd = DataCheckCenter.Instance.CheckElecTicketSerialNo(tbName, tbName.Text.Trim(), lbPayerName.Text.Substring(0, lbPayerName.Text.Length - 1), 30, false, this.errorProvider1);
                if (!rd.Result) { m_Payer = null; return rd.Result; }
            }
            return true;
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            PayerInfo p = cbAccount.SelectedItem as PayerInfo;
            if (m_AppType == AppliableFunctionType.TransferWithIndiv
                || m_AppType == AppliableFunctionType.TransferWithCorp
                || m_AppType == AppliableFunctionType.TransferOverBankOut
                || m_AppType == AppliableFunctionType.TransferOverBankIn
                ||m_AppType== AppliableFunctionType.UnitivePaymentRMB)
            {
                if (null != p)
                { tbName.Text = p.Name; }
            }
            else if (m_AppType == AppliableFunctionType.ElecTicketRemit
                || m_AppType == AppliableFunctionType.ElecTicketBackNote
                || m_AppType == AppliableFunctionType.ElecTicketPayMoney
                || m_AppType == AppliableFunctionType.ElecTicketTipExchange
                || m_AppType == AppliableFunctionType.UnitivePaymentRMB)
            {
                if (null != p) tbName.Tag = p.Name;
            }
        }

        private void chbSave_CheckedChanged(object sender, EventArgs e)
        {
            CanAdd = chbSave.Checked;
        }

        private void pbTip_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show(MultiLanguageConvertHelper.Instance.Tips_Pyaee_6Numbers, pbTip);
        }

        private void p_lockPayer_Click(object sender, EventArgs e)
        {
            if (p_lockPayerAccount.BackgroundImage == null || p_lockPayerName.BackgroundImage == null)
            {
                p_lockPayerAccount.BackgroundImage =
                p_lockPayerName.BackgroundImage = Properties.Resources.unlocked;
                islockPayer = false;
            }
            else
            {
                p_lockPayerAccount.BackgroundImage =
                p_lockPayerName.BackgroundImage = islockPayer ? Properties.Resources.unlocked : Properties.Resources.locked;
                islockPayer = !islockPayer;
            }
        }

        bool islockPayer = false;
        bool islockShow = false;
    }
}
