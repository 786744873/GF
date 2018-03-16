using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonClient.VisualParts;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;

namespace CommonClient.VisualParts2
{
    public partial class PayerSelector : BaseUc
    {
        public PayerSelector()
        {
            InitializeComponent();
            this.Load += new EventHandler(PayerSelector_Load);
            CommandCenter.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.OnTransferAccountEventHandler += new EventHandler<TransferEventArgs>(CommandCenter_OnTransferAccountEventHandler);
            CommandCenter.OnGovermentEventHandler += new EventHandler<GovermentEventArgs>(CommandCenter_OnGovermentEventHandler);
            CommandCenter.OnElecTicketRemitEvenHnadler += new EventHandler<ElecTicketRemitEventArgs>(CommandCenter_OnElecTicketRemitEvenHnadler);
            CommandCenter.OnElecTicketAutoTipExchangeEventHandler += new EventHandler<ElecTicketAutoTipExchangeEventArgs>(CommandCenter_OnElecTicketAutoTipExchangeEventHandler);
            CommandCenter.OnElecTicketBackNoteEventHandler += new EventHandler<ElecTicketBackNoteEventArgs>(CommandCenter_OnElecTicketBackNoteEventHandler);
            CommandCenter.OnElecTicketPayMoneyEventHandler += new EventHandler<ElecTicketPayMoneyEventArgs>(CommandCenter_OnElecTicketPayMoneyEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnCommonDataEventHandler += new EventHandler<CommonDataEventArgs>(CommandCenter_OnCommonDataEventHandler);
            CommandCenter.OnUnitivePaymentRMBEventHandler += new EventHandler<UnitivePaymentRMBEventArgs>(CommandCenter_OnUnitivePaymentRMBEventHandler);
            ambiguityInputAgent1.Selected += new EventHandler<CommonClient.Controls.SelectedEventParameter>(ambiguityInputAgent1_Selected);
        }

        void ambiguityInputAgent1_Selected(object sender, Controls.SelectedEventParameter e)
        {
            if (ambiguityInputAgent1.SelectedItemIndex == -1) return;
            PayerInfo p = ambiguityInputAgent1.SelectedEntity as PayerInfo;
            if (m_AppType == AppliableFunctionType.TransferWithIndiv
                || m_AppType == AppliableFunctionType.TransferWithCorp
                || m_AppType == AppliableFunctionType.TransferOverBankOut
                || m_AppType == AppliableFunctionType.TransferOverBankIn
                || m_AppType == AppliableFunctionType.UnitivePaymentRMB)
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
                    cbAccount.Text = e.UnitivePaymentRMB.PayerAccount;
                    tbName.Text = e.UnitivePaymentRMB.PayerName;
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

        void CommandCenter_OnElecTicketPayMoneyEventHandler(object sender, ElecTicketPayMoneyEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketPayMoneyEventArgs>(CommandCenter_OnElecTicketPayMoneyEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                {
                    cbAccount.Text = e.ElecTicketPayMoney.RemitAccount;
                    tbName.Text = e.ElecTicketPayMoney.ElecTicketSerialNo;
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

        void CommandCenter_OnElecTicketBackNoteEventHandler(object sender, ElecTicketBackNoteEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketBackNoteEventArgs>(CommandCenter_OnElecTicketBackNoteEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                this.errorProvider1.Clear();
                if (e.Command == OperatorCommandType.View)
                {
                    cbAccount.Text = e.ElecTicketBackNote.RemitAccount;
                    tbName.Text = e.ElecTicketBackNote.ElecTicketSerialNo;
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
                    cbAccount.Text = e.ElecTicketAutoTipExchange.RemitAccount;
                    tbName.Text = e.ElecTicketAutoTipExchange.ElecTicketSerialNo;
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
                    cbAccount.Text = e.ElecTicketRemit.RemitAccount;
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
                    cbAccount.Text = e.TransferAccount.PayerAccount;
                    tbName.Text = e.TransferAccount.PayerName;
                }
                else if (e.Command == OperatorCommandType.Reset)
                {
                    if (!(islockPayer && islockShow))//CommonInformations.CanClearItem(m_AppType, CommonFieldType.PayerInfo))
                    {
                        cbAccount.Text =
                        tbName.Text = string.Empty;
                    }
                }
                chbSave.Checked = false;
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
                    cbAccount.Text = e.GovermentInfo.PayerAccount;
                    //tbName.Text = e.GovermentInfo.PayerName;
                }
                else if (e.Command == OperatorCommandType.Reset)
                {
                    if (!(islockPayer && islockShow))//CommonInformations.CanClearItem(m_AppType, CommonFieldType.PayerInfo))
                    {
                        cbAccount.Text = string.Empty;
                       
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
                    if (cbAccount.Items.Count > 0)
                    {
                        ambiguityInputAgent1.ClearItems();
                        (cbAccount.Tag as List<PayerInfo>).ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
                    }
                    ambiguityInputAgent1.ClearItems();
                    if (cbAccount.Items.Count > 0) (cbAccount.Tag as List<PayerInfo>).ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
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
            List<PayerInfo> list = SystemSettings.PayerList.FindAll(o => (o.ServiceList & this.m_AppType) == this.m_AppType);
            cbAccount.Items.AddRange(list.ToArray());
            cbAccount.Tag = list;
            cbAccount.SelectedIndex = -1;
            cbAccount.Text = string.Empty;
            ambiguityInputAgent1.ClearItems();
            list.ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            if (m_AppType == AppliableFunctionType.TransferWithIndiv
                || m_AppType == AppliableFunctionType.TransferWithCorp
                || m_AppType == AppliableFunctionType.TransferOverBankOut
                || m_AppType == AppliableFunctionType.TransferOverBankIn)
            {
                bool flag = m_AppType == AppliableFunctionType.TransferOverBankIn;
                lbPayerAccount.Text = string.Format("{0}{1}", !flag ? MultiLanguageConvertHelper.DesignMain_PayerAccount : MultiLanguageConvertHelper.DesignMain_PayeeAccount, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                lbPayerName.Text = string.Format("{0}{1}", !flag ? MultiLanguageConvertHelper.DesignMain_PayerName : MultiLanguageConvertHelper.DesignMain_PayeeName, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");

                cbAccount.DropDownStyle = !flag ? ComboBoxStyle.DropDown : ComboBoxStyle.Simple;
                //tbName.DvRequired =
                lblPayerName.Visible = m_AppType == AppliableFunctionType.TransferOverBankIn;// || m_AppType == AppliableFunctionType.TransferOverBankOut;
            }
            else if (m_AppType == AppliableFunctionType.ElecTicketRemit
                || m_AppType == AppliableFunctionType.ElecTicketBackNote
                || m_AppType == AppliableFunctionType.ElecTicketPayMoney
                || m_AppType == AppliableFunctionType.ElecTicketTipExchange)
            {
                lbPayerAccount.Text = string.Format("{0}{1}", (m_AppType == AppliableFunctionType.ElecTicketRemit || m_AppType == AppliableFunctionType.ElecTicketTipExchange) ? MultiLanguageConvertHelper.DesignMain_RemitAccount : MultiLanguageConvertHelper.DesignMain_Account, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                bool flag = m_AppType != AppliableFunctionType.ElecTicketRemit;
                //tbName.DvRequired =
                //lbPayerName.Visible =
                lblPayerName.Visible = lbPayerName.Visible = tbName.Visible = flag;
                if (flag)
                {
                    lbPayerName.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.DesignMain_ElecTicket_SerialNo, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
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
                lbPayerAccount.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.DesignMain_PayerAccount_Real, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
                lbPayerName.Text = string.Format("{0}{1}", MultiLanguageConvertHelper.DesignMain_PayerName_Real, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
            }
            else if (m_AppType == AppliableFunctionType.TheCentralGoverment)
            {
                lbPayerName.Visible = tbName.Visible = tbName.DvRequired=false;
            }
            SetRegex();
        }
        private void SetRegex()
        {
            if (m_AppType == AppliableFunctionType.ElecTicketRemit
                || m_AppType == AppliableFunctionType.ElecTicketBackNote
                || m_AppType == AppliableFunctionType.ElecTicketPayMoney
                || m_AppType == AppliableFunctionType.ElecTicketTipExchange)
            {
                cbAccount.DvRegCode = "reg629";
                cbAccount.DvMinLength = 1;
                cbAccount.DvMaxLength = 32;
            }
            else if (m_AppType == AppliableFunctionType.UnitivePaymentRMB)
            {
                cbAccount.DvRegCode = "reg57";
                cbAccount.DvMinLength = 12;
                cbAccount.DvMaxLength = 18;
                tbName.DvRegCode = "reg661";
                tbName.DvMinLength = 0;
                tbName.DvMaxLength = 200;
            }
            else if (m_AppType == AppliableFunctionType.TransferWithIndiv
                || m_AppType == AppliableFunctionType.TransferWithCorp)
            {
                cbAccount.DvRegCode = "reg666";
                cbAccount.DvMinLength = 1;
                cbAccount.DvMaxLength = 35;
            }
            else
            {
                cbAccount.DvRegCode = "reg57";
                cbAccount.DvMinLength = 12;
                cbAccount.DvMaxLength = 18;
            }
            if (m_AppType == AppliableFunctionType.TransferOverBankIn)
            {
                tbName.DvRegCode = "Predefined5";
                tbName.DvMinLength = 1;
                tbName.DvMaxLength = 70;
            }
            else if (m_AppType == AppliableFunctionType.TransferOverBankOut)
            {
                tbName.DvRegCode = "Predefined5";
                tbName.DvMinLength = 0;
                tbName.DvMaxLength = 76;
            }
            else if (m_AppType == AppliableFunctionType.ElecTicketBackNote
                || m_AppType == AppliableFunctionType.ElecTicketPayMoney
                || m_AppType == AppliableFunctionType.ElecTicketTipExchange)
            {
                tbName.DvRegCode = "reg57";
                tbName.DvMinLength = 1;
                tbName.DvMaxLength = 30;
                tbName.DvRequired = true;
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
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //if (m_AppType == AppliableFunctionType.ElecTicketRemit
            //    || m_AppType == AppliableFunctionType.ElecTicketBackNote
            //    || m_AppType == AppliableFunctionType.ElecTicketPayMoney
            //    || m_AppType == AppliableFunctionType.ElecTicketTipExchange)
            //{
            //    cbAccount.DvRegCode = "reg629";
            //    //rd = DataCheckCenter.CheckElecTicketPersonAccount(cbAccount, cbAccount.Text.Trim(), lbPayerAccount.Text.Substring(0, lbPayerAccount.Text.Length - 1), 32, this.errorProvider1);
            //    //if (!rd.Result) { m_Payer = null; return rd.Result; }
            //}
            //else if (m_AppType == AppliableFunctionType.UnitivePaymentRMB)
            //{
            //    cbAccount.DvRegCode = "reg57";
            //    //rd = DataCheckCenter.CheckPayerAccountUP(cbAccount, cbAccount.Text.Trim(), lbPayerAccount.Text.Substring(0, lbPayerAccount.Text.Length - 1), 12, 18, this.errorProvider1);
            //    //if (!rd.Result) { m_Payer = null; return rd.Result; }
            //    if (!string.IsNullOrEmpty(tbName.Text.Trim()))
            //    {
            //        tbName.DvRegCode = "reg661";
            //        //rd = DataCheckCenter.CheckPayerNameOrBankNameUP(tbName, tbName.Text.Trim(), lbPayerName.Text.Substring(0, lbPayerName.Text.Length - 1), 200, this.errorProvider1);
            //        //if (!rd.Result) { m_Payer = null; return rd.Result; }
            //    }
            //}
            //else
            //{
            //    cbAccount.DvRegCode = "reg57";
            //    rd = DataCheckCenter.CheckPayerAccount(cbAccount, cbAccount.Text.Trim(), lbPayerAccount.Text.Substring(0, lbPayerAccount.Text.Length - 1), this.errorProvider1);
            //    if (!rd.Result) { m_Payer = null; return rd.Result; }
            //}
            //if (m_AppType == AppliableFunctionType.TransferOverBankIn || (m_AppType == AppliableFunctionType.TransferOverBankOut && !string.IsNullOrEmpty(tbName.Text.Trim())))
            //{
            //    rd = DataCheckCenter.CheckPayerName(tbName, tbName.Text.Trim(), lbPayerName.Text.Replace("：", ""), m_AppType == AppliableFunctionType.TransferOverBankIn ? 70 : 76, this.errorProvider1);
            //    if (!rd.Result) { m_Payer = null; return rd.Result; }
            //}
            //else if (m_AppType == AppliableFunctionType.ElecTicketBackNote
            //    || m_AppType == AppliableFunctionType.ElecTicketPayMoney
            //    || m_AppType == AppliableFunctionType.ElecTicketTipExchange)
            //{
            //    rd = DataCheckCenter.CheckElecTicketSerialNo(tbName, tbName.Text.Trim(), lbPayerName.Text.Substring(0, lbPayerName.Text.Length - 1), 30, false, this.errorProvider1);
            //    if (!rd.Result) { m_Payer = null; return rd.Result; }
            //}
            return rd.Result;
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            PayerInfo p = cbAccount.SelectedItem as PayerInfo;
            if (m_AppType == AppliableFunctionType.TransferWithIndiv
                || m_AppType == AppliableFunctionType.TransferWithCorp
                || m_AppType == AppliableFunctionType.TransferOverBankOut
                || m_AppType == AppliableFunctionType.TransferOverBankIn
                || m_AppType == AppliableFunctionType.UnitivePaymentRMB)
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
            this.toolTip1.Show(MultiLanguageConvertHelper.Tips_Pyaee_6Numbers, pbTip);
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
