﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class ElecTicketRelateAccountSelector : BaseUc
    {
        public ElecTicketRelateAccountSelector()
        {
            InitializeComponent();
            CommandCenter.Instance.OnElecTicketRelateAccountEventHandler += new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler);
            CommandCenter.Instance.OnElecTicketRemitEvenHnadler += new EventHandler<ElecTicketRemitEventArgs>(CommandCenter_OnElecTicketRemitEvenHnadler);
            CommandCenter.Instance.OnElecTicketBackNoteEventHandler += new EventHandler<ElecTicketBackNoteEventArgs>(CommandCenter_OnElecTicketBackNoteEventHandler);
            CommandCenter.Instance.OnElecTicketPayMoneyEventHandler += new EventHandler<ElecTicketPayMoneyEventArgs>(CommandCenter_OnElecTicketPayMoneyEventHandler);
            CommandCenter.Instance.OnElecTicketAutoTipExchangeEventHandler += new EventHandler<ElecTicketAutoTipExchangeEventArgs>(CommandCenter_OnElecTicketAutoTipExchangeEventHandler);
            CommandCenter.Instance.OnElecTicketTypeChangedEventHandler += new EventHandler<ElecTicketTypeChangedEventArgs>(CommandCenter_OnElecTicketTypeChangedEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            cmbAccount.SelectedIndexChanged += new EventHandler(cmbAccount_SelectedIndexChanged);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(ElecTicketRelateAccountSelector), this);
                InitData();
                InitDescription();
            }
        }

        void CommandCenter_OnElecTicketTypeChangedEventHandler(object sender, ElecTicketTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketTypeChangedEventArgs>(CommandCenter_OnElecTicketTypeChangedEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != m_appType || m_relateType != RelatePersonType.Exchange || e.TicketType != ElecTicketType.AC01) return;
                cmbAccount.MatchStrFlag = false;
                cmbAccount.SelectedIndex = -1;
                cmbAccount.Text = "0";
                tbName.Text =
                tbOpenBankName.Text =
                tbOpenBankNo.Text = string.Empty;
                cmbAccount.MatchStrFlag = true;
            }
        }

        void CommandCenter_OnElecTicketAutoTipExchangeEventHandler(object sender, ElecTicketAutoTipExchangeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketAutoTipExchangeEventArgs>(CommandCenter_OnElecTicketAutoTipExchangeEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != m_appType) return;
                if (RelatePersonType.Exchange == m_relateType)
                {
                    if (e.Command == OperatorCommandType.View)
                    {
                        cmbAccount.Text = e.ElecTicketAutoTipExchange.ExchangeAccount;
                        tbName.Text = e.ElecTicketAutoTipExchange.ExchangeName;
                        tbOpenBankName.Text = e.ElecTicketAutoTipExchange.ExchangeOpenBankName;
                        tbOpenBankNo.Text = e.ElecTicketAutoTipExchange.ExchangeOpenBankNo;
                    }
                    else if (e.Command == OperatorCommandType.Reset)
                        ClearItem();
                }
            }
        }

        void CommandCenter_OnElecTicketPayMoneyEventHandler(object sender, ElecTicketPayMoneyEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketPayMoneyEventArgs>(CommandCenter_OnElecTicketPayMoneyEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != m_appType) return;
                if (RelatePersonType.StickOn == m_relateType)
                {
                    if (e.Command == OperatorCommandType.View)
                    {
                        cmbAccount.Text = e.ElecTicketPayMoney.StickOnAccount;
                        tbName.Text = e.ElecTicketPayMoney.StickOnName;
                        tbOpenBankName.Text = e.ElecTicketPayMoney.StickOnOpenBankName;
                        tbOpenBankNo.Text = e.ElecTicketPayMoney.StickOnOpenBankNo;
                    }
                    else if (e.Command == OperatorCommandType.Reset)
                        ClearItem();
                }
            }
        }

        void CommandCenter_OnElecTicketBackNoteEventHandler(object sender, ElecTicketBackNoteEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketBackNoteEventArgs>(CommandCenter_OnElecTicketBackNoteEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != m_appType) return;
                if (RelatePersonType.BackNoted == m_relateType)
                {
                    if (e.Command == OperatorCommandType.View)
                    {
                        cmbAccount.Text = e.ElecTicketBackNote.BackNotedAccount;
                        tbName.Text = e.ElecTicketBackNote.BackNotedName;
                        tbOpenBankName.Text = e.ElecTicketBackNote.BackNotedOpenBankName;
                        tbOpenBankNo.Text = e.ElecTicketBackNote.BackNotedOpenBankNo;
                    }
                    else if (e.Command == OperatorCommandType.Reset)
                        ClearItem();
                }
            }
        }

        void CommandCenter_OnElecTicketRemitEvenHnadler(object sender, ElecTicketRemitEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketRemitEventArgs>(CommandCenter_OnElecTicketRemitEvenHnadler), sender, e); }
            else
            {
                if (e.OwnerType != m_appType) return;
                if (e.Command == OperatorCommandType.View)
                {
                    if (m_relateType == RelatePersonType.Exchange)
                    {
                        cmbAccount.Text = e.ElecTicketRemit.ExchangeAccount;
                        tbName.Text = e.ElecTicketRemit.ExchangeName;
                        tbOpenBankName.Text = e.ElecTicketRemit.ExchangeOpenBankName;
                        tbOpenBankNo.Text = e.ElecTicketRemit.ExchangeOpenBankNo;
                    }
                    else if (m_relateType == RelatePersonType.Payee)
                    {
                        cmbAccount.Text = e.ElecTicketRemit.PayeeAccount;
                        tbName.Text = e.ElecTicketRemit.PayeeName;
                        tbOpenBankName.Text = e.ElecTicketRemit.PayeeOpenBankName;
                        tbOpenBankNo.Text = e.ElecTicketRemit.PayeeOpenBankNo;
                    }
                }
                else if (e.Command == OperatorCommandType.Reset)
                    ClearItem();
            }
        }

        void CommandCenter_OnElecTicketRelateAccountEventHandler(object sender, ElecTicketRelateAccountEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler), sender, e); }
            else
            {
                List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
                if (cmbAccount.Items.Count > 0) list = cmbAccount.Tag as List<ElecTicketRelationAccount>;

                if (e.Command == OperatorCommandType.Submit)
                {
                    if ((e.RelationAccount.PersonType & m_relateType) != m_relateType) return;
                    int index = list.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                    if (index < 0)
                    {
                        cmbAccount.Items.Add(e.RelationAccount);
                        list.Add(e.RelationAccount);
                        cmbAccount.Tag = list;
                    }
                }
                else if (e.Command == OperatorCommandType.Edit)
                {
                    if ((e.RelationAccount.PersonType & m_relateType) != m_relateType) return;
                    int index = list.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                    if (index >= 0)
                    {
                        cmbAccount.Items[index] = e.RelationAccount;
                        list[index] = e.RelationAccount;
                        cmbAccount.Tag = list;
                    }
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    int index = list.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                    if (index >= 0)
                    {
                        cmbAccount.Items.RemoveAt(index);
                        list.RemoveAt(index);
                        cmbAccount.Tag = list;
                    }
                }
                else if (e.Command == OperatorCommandType.CombineData)
                {
                    foreach (var item in e.RelationAccountList)
                    {
                        if (item.PersonType != m_relateType) continue;
                        int index = list.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                        if (index < 0)
                        {
                            cmbAccount.Items.Add(e.RelationAccount);
                            list.Add(e.RelationAccount);
                        }
                    }
                    cmbAccount.Tag = list;
                }
                else return;
            }
        }

        private ElecTicketRelationAccount m_relateAccount;
        /// <summary>
        /// 当前关系人信息
        /// </summary>
        [Browsable(false)]
        public ElecTicketRelationAccount CurrentRelateAccount
        {
            get { return m_relateAccount; }
            set { m_relateAccount = value; }
        }

        private AppliableFunctionType m_appType = AppliableFunctionType._Empty;
        /// <summary>
        /// 所属业务类型
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_appType; }
            set
            {
                m_appType = value;
                InitData();
            }
        }

        private RelatePersonType m_relateType = RelatePersonType.Empty;
        /// <summary>
        /// 关系人属性
        /// </summary>
        [Browsable(true)]
        public RelatePersonType RelateType
        {
            get { return m_relateType; }
            set
            {
                m_relateType = value;
                InitDescription();
            }
        }
        [Browsable(false)]
        public bool CanAdd = false;
        bool isload = false;

        void InitData()
        {
            if (m_appType == AppliableFunctionType._Empty) return;
            if (m_relateType == RelatePersonType.Empty) return;

            if (!isload)
            {
                isload = true;
                tbOpenBankName.LostFocus += new EventHandler(tbOpenBank_LostFocus);
                tbOpenBankNo.LostFocus += new EventHandler(tbOpenBank_LostFocus);
            }

            List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
            list = SysCoach.SystemSettings.Instance.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & m_relateType) == m_relateType);//.GetRange(0, SysCoach.SystemSettings.Instance.ElecTicketRelationAccountList.Count);

            cmbAccount.Items.Clear();
            cmbAccount.Items.AddRange(list.ToArray());
            cmbAccount.Tag = list;

            pbTip.Visible = m_appType == AppliableFunctionType.ElecTicketRemit && m_relateType == RelatePersonType.Payee;

            lblAccount.Visible =
            lblName.Visible =
            lblOpenBankName.Visible =
            lblOpenBankNo.Visible =
                //cmbAccount.ValidateRule.Required =
                //tbName.ValidateRule.Required =
                //tbOpenBankName.ValidateRule.Required =
                //tbOpenBankNo.ValidateRule.Required = 
            (m_relateType != RelatePersonType.Exchange || m_appType != AppliableFunctionType.ElecTicketTipExchange);
        }

        void tbOpenBank_LostFocus(object sender, EventArgs e)
        {
            CheckBankInfo();
        }

        private void CheckBankInfo()
        {
            if (m_appType != AppliableFunctionType.ElecTicketPayMoney) return;
            if (string.IsNullOrEmpty(tbOpenBankName.Text.Trim()) || string.IsNullOrEmpty(tbOpenBankNo.Text.Trim())) return;

            CommandCenter.Instance.ResolveStickOnBankInfo(tbOpenBankName.Text.Trim(), tbOpenBankNo.Text.Trim());
        }
        void InitDescription()
        {
            if (m_relateType == RelatePersonType.Empty) return;

            string str = string.Empty;
            try
            {
                str = EnumNameHelper<RelatePersonType>.GetEnumDescription(m_relateType);
            }
            catch { }
            lbAccount.Text = string.Format("{0}账号：", str);
            lbName.Text = string.Format("{0}名称：", str);
            lbOpenBankName.Text = string.Format("{0}开户行名称：", str);
            lbOpenBankNo.Text = string.Format("{0}开户行行号：", str);

            if (m_relateType == RelatePersonType.Exchange && m_appType == AppliableFunctionType.ElecTicketRemit)
            {
                cmbAccount.Text = "0";
                tbName.Text =
                tbOpenBankName.Text =
                tbOpenBankNo.Text = string.Empty;
            }

            if (m_appType != AppliableFunctionType._Empty) InitData();
        }

        void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccount.SelectedIndex < 0)
            {
                tbName.Text =
                tbOpenBankName.Text =
                tbOpenBankNo.Text = string.Empty;
                return;
            }

            ElecTicketRelationAccount relateAccount = (cmbAccount.Tag as List<ElecTicketRelationAccount>)[cmbAccount.SelectedIndex];
            tbName.Text = relateAccount.Name;
            tbOpenBankName.Text = relateAccount.OpenBankName;
            tbOpenBankNo.Text = relateAccount.OpenBankNo;

            CheckBankInfo();
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            if ((m_appType == AppliableFunctionType.ElecTicketTipExchange && m_relateType == RelatePersonType.Exchange && !string.IsNullOrEmpty(cmbAccount.Text.Trim())) || m_appType != AppliableFunctionType.ElecTicketTipExchange)
            {
                rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(cmbAccount, cmbAccount.Text.Trim(), lbAccount.Text.Substring(0, lbAccount.Text.Length - 1), 32, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if ((m_appType == AppliableFunctionType.ElecTicketTipExchange && m_relateType == RelatePersonType.Exchange && !string.IsNullOrEmpty(cmbAccount.Text.Trim())) || m_appType != AppliableFunctionType.ElecTicketTipExchange)
            {
                rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(tbName, tbName.Text.Trim(), lbName.Text.Substring(0, lbName.Text.Length - 1), 120, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if ((m_appType == AppliableFunctionType.ElecTicketTipExchange && m_relateType == RelatePersonType.Exchange && !string.IsNullOrEmpty(cmbAccount.Text.Trim())) || m_appType != AppliableFunctionType.ElecTicketTipExchange)
            {
                rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(tbOpenBankName, tbOpenBankName.Text.Trim(), lbOpenBankName.Text.Substring(0, lbOpenBankName.Text.Length - 1), 120, this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            if ((m_appType == AppliableFunctionType.ElecTicketTipExchange && m_relateType == RelatePersonType.Exchange && !string.IsNullOrEmpty(cmbAccount.Text.Trim())) || m_appType != AppliableFunctionType.ElecTicketTipExchange)
            {
                rd = DataCheckCenter.Instance.CheckCNAPSNo(tbOpenBankNo, tbOpenBankNo.Text.Trim(), lbOpenBankNo.Text.Substring(0, lbOpenBankNo.Text.Length - 1), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            return rd.Result;
        }

        public void GetItem()
        {
            if (CheckData())
            {
                m_relateAccount = new ElecTicketRelationAccount();
                m_relateAccount.Account = cmbAccount.Text.Trim();
                m_relateAccount.Name = tbName.Text.Trim();
                m_relateAccount.OpenBankName = tbOpenBankName.Text.Trim();
                m_relateAccount.OpenBankNo = tbOpenBankNo.Text.Trim();
                CanAdd = chbSave.Checked;// SystemSettings.Instance.ElecTicketRelationAccountList.FindAll(o => o.Account == CurrentRelateAccount.Account && o.Name == CurrentRelateAccount.Name).Count == 0;
                if (CanAdd) m_relateAccount.PersonType = m_relateType;
            }
        }

        private void ClearItem()
        {
            cmbAccount.Text =
            tbName.Text =
            tbOpenBankName.Text =
            tbOpenBankNo.Text = string.Empty;
            this.errorProvider1.Clear();
        }

        private void btnQueryAccount_Click(object sender, EventArgs e)
        {
            frmQueryRelateAccount frm = new frmQueryRelateAccount();
            frm.PersonType = m_relateType;
            if (frm.ShowDialog() != DialogResult.OK) return;

            cmbAccount.Text = frm.RelateAccount.Account;
            tbName.Text = frm.RelateAccount.Name;
            tbOpenBankName.Text = frm.RelateAccount.OpenBankName;
            tbOpenBankNo.Text = frm.RelateAccount.OpenBankNo;

            CheckBankInfo();

            if (frm != null)
                frm.Close();
        }

        private void btnOpenBank_Click(object sender, EventArgs e)
        {
            wndOpenBankQuery frm = new wndOpenBankQuery();
            frm.IsOpenBank = true;
            if (frm.ShowDialog() != DialogResult.OK) return;
            tbOpenBankName.Text = frm.QueryDialogResult.Name;
            tbOpenBankNo.Text = frm.QueryDialogResult.Code;

            CheckBankInfo();

            if (frm != null)
                frm.Close();
        }

        private void pbTip_Click(object sender, EventArgs e)
        {
            this.toolTip1.Show(MultiLanguageConvertHelper.Instance.Tips_Pyaee_6NumbersEx, pbTip);
        }
    }
}
