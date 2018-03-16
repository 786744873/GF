using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class ElecTicketPoolRelateAccountSelector : BaseUc
    {
        public ElecTicketPoolRelateAccountSelector()
        {
            InitializeComponent();

            CommandCenter.OnElecTicketPoolEventHandler += new EventHandler<ElecTicketPoolEventArgs>(CommandCenter_OnElecTicketPoolEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnElecTicketRelateAccountEventHandler += new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler);

            ambiguityInputAgent1.Selected += new EventHandler<CommonClient.Controls.SelectedEventParameter>(ambiguityInputAgent1_Selected);
            ambiguityInputAgent2.Selected += new EventHandler<CommonClient.Controls.SelectedEventParameter>(ambiguityInputAgent2_Selected);
            ambiguityInputAgent3.Selected += new EventHandler<CommonClient.Controls.SelectedEventParameter>(ambiguityInputAgent3_Selected);
        }

        void ambiguityInputAgent3_Selected(object sender, Controls.SelectedEventParameter e)
        {
            if (ambiguityInputAgent3.SelectedItemIndex >= 0)
            {
                ElecTicketRelationAccount etra = ambiguityInputAgent3.SelectedEntity as ElecTicketRelationAccount;
                tbPayeeName.Text = etra.Name;
                tbPayeeOpenBankName.Text = etra.OpenBankName;
                tbPayeeOpenBankNo.Text = etra.OpenBankNo;
            }
        }

        void ambiguityInputAgent2_Selected(object sender, Controls.SelectedEventParameter e)
        {
            if (ambiguityInputAgent2.SelectedItemIndex >= 0)
            {
                ElecTicketRelationAccount etra = ambiguityInputAgent2.SelectedEntity as ElecTicketRelationAccount;
                tbExcahngeName.Text = etra.Name;
                tbExchangeOpenBankName.Text = etra.OpenBankName;
                tbExchangeOpenBankNo.Text = etra.OpenBankNo;
            }
        }

        void ambiguityInputAgent1_Selected(object sender, Controls.SelectedEventParameter e)
        {
            if (ambiguityInputAgent1.SelectedItemIndex >= 0)
            {
                ElecTicketRelationAccount etra = ambiguityInputAgent1.SelectedEntity as ElecTicketRelationAccount;
                tbRemitName.Text = etra.Name;
            }
        }

        void CommandCenter_OnElecTicketRelateAccountEventHandler(object sender, ElecTicketRelateAccountEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler), sender, e); }
            else
            {
                List<ElecTicketRelationAccount> listR = new List<ElecTicketRelationAccount>();
                List<ElecTicketRelationAccount> listE = new List<ElecTicketRelationAccount>();
                List<ElecTicketRelationAccount> listP = new List<ElecTicketRelationAccount>();

                if (e.Command == OperatorCommandType.Submit)
                {
                    if ((e.RelationAccount.PersonType & RelatePersonType.Remittor) == RelatePersonType.Remittor)
                    {
                        if (cmbRemitAccount.Items.Count > 0) listR = cmbRemitAccount.Tag as List<ElecTicketRelationAccount>;
                        int index = listR.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                        if (index < 0)
                        {
                            cmbRemitAccount.Items.Add(e.RelationAccount);
                            listR.Add(e.RelationAccount);
                            cmbRemitAccount.Tag = listR;
                        }
                    }
                    if ((e.RelationAccount.PersonType & RelatePersonType.Payee) == RelatePersonType.Payee)
                    {
                        if (cmbPayeeAccount.Items.Count > 0) listP = cmbPayeeAccount.Tag as List<ElecTicketRelationAccount>;
                        int index = listP.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                        if (index < 0)
                        {
                            cmbPayeeAccount.Items.Add(e.RelationAccount);
                            listP.Add(e.RelationAccount);
                            cmbPayeeAccount.Tag = listP;
                        }
                    }
                    if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
                    {
                        if ((e.RelationAccount.PersonType & RelatePersonType.Exchange) == RelatePersonType.Exchange)
                        {
                            if (cmbExchangeAccount.Items.Count > 0) listE = cmbExchangeAccount.Tag as List<ElecTicketRelationAccount>;
                            int index = listP.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                            if (index < 0)
                            {
                                cmbExchangeAccount.Items.Add(e.RelationAccount);
                                listE.Add(e.RelationAccount);
                                cmbExchangeAccount.Tag = listE;
                            }
                        }
                    }
                }
                else if (e.Command == OperatorCommandType.Edit)
                {
                    if ((e.RelationAccount.PersonType & RelatePersonType.Payee) == RelatePersonType.Payee)
                    {
                        listP.AddRange(SystemSettings.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & RelatePersonType.Payee) == RelatePersonType.Payee));
                        cmbPayeeAccount.Items.AddRange(listP.ToArray());
                        cmbPayeeAccount.Tag = listP;
                    }
                    if ((e.RelationAccount.PersonType & RelatePersonType.Remittor) == RelatePersonType.Remittor)
                    {
                        listR.AddRange(SystemSettings.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & RelatePersonType.Remittor) == RelatePersonType.Remittor));
                        cmbRemitAccount.Items.AddRange(listR.ToArray());
                        cmbRemitAccount.Tag = listR;
                    }
                    if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
                    {
                        if ((e.RelationAccount.PersonType & RelatePersonType.Exchange) == RelatePersonType.Exchange)
                        {
                            listE.AddRange(SystemSettings.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & RelatePersonType.Exchange) == RelatePersonType.Exchange));
                            cmbExchangeAccount.Items.AddRange(listE.ToArray());
                            cmbExchangeAccount.Tag = listE;
                        }
                    }
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    listR.AddRange(SystemSettings.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & RelatePersonType.Remittor) == RelatePersonType.Remittor));
                    cmbRemitAccount.Items.AddRange(listR.ToArray());
                    cmbRemitAccount.Tag = listR;
                    listP.AddRange(SystemSettings.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & RelatePersonType.Payee) == RelatePersonType.Payee));
                    cmbPayeeAccount.Items.AddRange(listR.ToArray());
                    cmbPayeeAccount.Tag = listP;
                    if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
                    {
                        listE.AddRange(SystemSettings.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & RelatePersonType.Exchange) == RelatePersonType.Exchange));
                        cmbExchangeAccount.Items.AddRange(listE.ToArray());
                        cmbExchangeAccount.Tag = listE;
                    }
                }
                else if (e.Command == OperatorCommandType.CombineData)
                {
                    e.RelationAccountList.ForEach(o =>
                    {
                        if ((o.PersonType & RelatePersonType.Payee) == RelatePersonType.Payee)
                        {
                            int index = listP.FindIndex(p => p.Account == o.Account && p.Name == o.Name);
                            if (index < 0) listP.Add(o);
                        }
                        if ((o.PersonType & RelatePersonType.Remittor) == RelatePersonType.Remittor)
                        {
                            int index = listR.FindIndex(p => p.Account == o.Account && p.Name == o.Name);
                            if (index < 0) listE.Add(o);
                        }
                        if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
                        {
                            if ((o.PersonType & RelatePersonType.Exchange) == RelatePersonType.Exchange)
                            {
                                int index = listE.FindIndex(p => p.Account == o.Account && p.Name == o.Name);
                                if (index < 0) listE.Add(o);
                            }
                        }
                    });
                    cmbRemitAccount.Items.AddRange(listR.ToArray());
                    cmbRemitAccount.Tag = listR;
                    cmbPayeeAccount.Items.AddRange(listP.ToArray());
                    cmbPayeeAccount.Tag = listP;
                    if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
                    {
                        cmbExchangeAccount.Items.AddRange(listE.ToArray());
                        cmbExchangeAccount.Tag = listE;
                    }
                }
                else return;
                ambiguityInputAgent1.ClearItems();
                ambiguityInputAgent3.ClearItems();
                listR.ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
                listP.ForEach(o => ambiguityInputAgent3.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
                if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
                {
                    ambiguityInputAgent2.ClearItems();
                    listE.ForEach(o => ambiguityInputAgent2.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
                }
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(ElecTicketPoolRelateAccountSelector), this);
                Init();
            }
        }

        void CommandCenter_OnElecTicketPoolEventHandler(object sender, ElecTicketPoolEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketPoolEventArgs>(CommandCenter_OnElecTicketPoolEventHandler), sender, e); }
            else
            {
                if (AppliableFunctionType.ElecTicketPool != e.OwnerType) return;
                if (e.Command == OperatorCommandType.View)
                    SetItem(e.ElecTicketPool);
                else if (e.Command == OperatorCommandType.Reset)
                    SetItem(null);
                this.errorProvider1.Clear();
            }
        }

        private ElecTicketType m_ElecTicketType = ElecTicketType.Empty;
        /// <summary>
        /// 所属功能模块
        /// ElecTicketPoolBank-票据池(银承)，ElecTicketPoolBusiness-票据池(商承)
        /// </summary>
        [Browsable(true)]
        public ElecTicketType ElecTicketType
        {
            get { return m_ElecTicketType; }
            set
            {
                if (ElecTicketType.AC01 == value || ElecTicketType.AC02 == value)
                {
                    m_ElecTicketType = value;
                    Init();
                }
            }
        }
        private ElecTicketPool m_elecTicketPool;
        /// <summary>
        /// 票据池信息
        /// </summary>
        public ElecTicketPool ElecTicketPool
        {
            get
            {
                return m_elecTicketPool;
            }
        }
        public bool SaveRemit = false;
        public bool SaveExchange = false;
        public bool SavePayee = false;

        void Init()
        {
            panel2.Visible =
                //chbExchange.Visible =
                m_ElecTicketType != EnumTypes.ElecTicketType.AC01;
            cmbExchangeAccount.DropDownStyle = m_ElecTicketType == EnumTypes.ElecTicketType.AC01 ? ComboBoxStyle.Simple : ComboBoxStyle.DropDown;
            ambiguityInputAgent2.ClearItems();
            if (m_ElecTicketType == EnumTypes.ElecTicketType.AC01)
            {
                if (cmbExchangeAccount.Tag != null)
                    (cmbExchangeAccount.Tag as List<ElecTicketRelationAccount>).ForEach(o => ambiguityInputAgent2.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            }

            lbExchangeAccount.Text = string.Format("{0}{1}", m_ElecTicketType == EnumTypes.ElecTicketType.AC01
                ? MultiLanguageConvertHelper.ElecTicketPool_ExchangeBankNo
                : MultiLanguageConvertHelper.ElecTicketPool_ExchangeAccount,
                SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbExchangeName.Text = string.Format("{0}{1}", m_ElecTicketType == EnumTypes.ElecTicketType.AC01
                ? MultiLanguageConvertHelper.ElecTicketPool_ExchangeBankName
                : MultiLanguageConvertHelper.ElecTicketPool_ExchangeName,
                SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");

            cmbPayeeAccount.Text =
            tbExcahngeName.Text = string.Empty;

            cmbPayeeAccount.Items.Clear();
            List<ElecTicketRelationAccount> list = SystemSettings.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & RelatePersonType.Payee) == RelatePersonType.Payee);
            cmbPayeeAccount.Items.AddRange(list.ToArray());
            cmbPayeeAccount.Tag = list;
            ambiguityInputAgent3.ClearItems();
            list.ForEach(o => ambiguityInputAgent3.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
            {
                List<ElecTicketRelationAccount> elist = SystemSettings.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & RelatePersonType.Exchange) == RelatePersonType.Exchange);
                cmbExchangeAccount.Items.Clear();
                cmbExchangeAccount.Items.AddRange(elist.ToArray());
                cmbExchangeAccount.Tag = elist;
                ambiguityInputAgent2.ClearItems();
                elist.ForEach(o => ambiguityInputAgent2.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            }
            List<ElecTicketRelationAccount> plist = SystemSettings.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & RelatePersonType.Remittor) == RelatePersonType.Remittor);
            cmbRemitAccount.Items.Clear();
            cmbRemitAccount.Items.AddRange(plist.ToArray());
            cmbRemitAccount.Tag = plist;
            ambiguityInputAgent1.ClearItems();
            plist.ForEach(o => ambiguityInputAgent1.AddItem(new Controls.SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            SetRegex();
        }
        private void SetRegex()
        {
            cmbRemitAccount.DvRegCode = "reg629";
            cmbRemitAccount.DvMinLength = 1;
            cmbRemitAccount.DvMaxLength = 32;
            cmbRemitAccount.DvRequired = true;
            tbRemitName.DvRegCode = "reg667";
            tbRemitName.DvMinLength = 1;
            tbRemitName.DvMaxLength = 120;
            tbRemitName.DvRequired = true;
            tbExcahngeName.DvRegCode = "reg667";
            tbExcahngeName.DvMinLength = 1;
            tbExcahngeName.DvMaxLength = 120;
            tbExcahngeName.DvRequired = true;

            if (m_ElecTicketType == EnumTypes.ElecTicketType.AC01)
            {
                cmbExchangeAccount.DvRegCode = "reg57";
                cmbExchangeAccount.DvMinLength = 12;
                cmbExchangeAccount.DvMaxLength = 12;
                cmbExchangeAccount.DvRequired = true;
                tbExchangeOpenBankNo.DvRequired = false;
                tbExchangeOpenBankNo.DvRegCode = "";
                tbExchangeOpenBankNo.DvMinLength = 12;
                tbExchangeOpenBankNo.DvMaxLength = 12;
            }
            else if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
            {
                cmbExchangeAccount.DvRegCode = "Predefined4";
                cmbExchangeAccount.DvMinLength = 1;
                cmbExchangeAccount.DvMaxLength = 32;
                cmbExchangeAccount.DvRequired = true;
                tbExchangeOpenBankNo.DvRegCode = "reg57";
                tbExchangeOpenBankNo.DvMinLength = 12;
                tbExchangeOpenBankNo.DvMaxLength = 12;
                tbExchangeOpenBankNo.DvRequired = true;
            }
            cmbPayeeAccount.DvRegCode = "Predefined4";
            cmbPayeeAccount.DvMinLength = 1;
            cmbPayeeAccount.DvMaxLength = 32;
            cmbPayeeAccount.DvRequired = true;
            tbPayeeName.DvRegCode = "reg667";
            tbPayeeName.DvMinLength = 1;
            tbPayeeName.DvMaxLength = 120;
            tbPayeeName.DvRequired = true;
            tbPayeeOpenBankName.DvRegCode = "reg667";
            tbPayeeOpenBankName.DvMinLength = 1;
            tbPayeeOpenBankName.DvMaxLength = 120;
            tbPayeeOpenBankName.DvRequired = true;
            tbPayeeOpenBankNo.DvRegCode = "reg57";
            tbPayeeOpenBankNo.DvMinLength = 12;
            tbPayeeOpenBankNo.DvMaxLength = 12;
            tbPayeeOpenBankNo.DvRequired = true;

        }
        public bool CheckData()
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //rd = DataCheckCenter.CheckElecTicketPersonAccount(cmbRemitAccount, cmbRemitAccount.Text.Trim(), MultiLanguageConvertHelper.ElecTicketPool_RemitAccount, 32, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckElecTicketPersonNameOrBankName(tbRemitName, tbRemitName.Text.Trim(), MultiLanguageConvertHelper.ElecTicketPool_RemitName, 120, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckElecTicketPersonNameOrBankName(tbExcahngeName, tbExcahngeName.Text.Trim(), lbExchangeName.Text.Substring(0, lbExchangeName.Text.Length - 1), 120, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //if (m_ElecTicketType == EnumTypes.ElecTicketType.AC01)
            //{
            //    rd = DataCheckCenter.CheckCNAPSNo(cmbExchangeAccount, cmbExchangeAccount.Text.Trim(), lbExchangeAccount.Text.Substring(0, lbExchangeAccount.Text.Length - 1), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //else if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
            //{
            //    rd = DataCheckCenter.CheckPayeeOrElecTicketPersonAccount(cmbExchangeAccount, cmbExchangeAccount.Text.Trim(), MultiLanguageConvertHelper.ElecTicketPool_ExchangeAccount, 32, this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //    rd = DataCheckCenter.CheckCNAPSNo(tbExchangeOpenBankNo, tbExchangeOpenBankNo.Text.Trim(), lbExchangeOpenBankNo.Text.Trim(), this.errorProvider1);
            //    if (!rd.Result) return rd.Result;
            //}
            //rd = DataCheckCenter.CheckPayeeOrElecTicketPersonAccount(cmbPayeeAccount, cmbPayeeAccount.Text.Trim(), MultiLanguageConvertHelper.ElecTicketPool_PayeeAccount, 32, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckElecTicketPersonNameOrBankName(tbPayeeName, tbPayeeName.Text.Trim(), MultiLanguageConvertHelper.ElecTicketPool_PayeeName, 120, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckOpenBankName(tbPayeeOpenBankName, tbPayeeOpenBankName.Text.Trim(), MultiLanguageConvertHelper.ElecTicketPool_PayeeOpenBankName, 120, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckCNAPSNo(tbPayeeOpenBankNo, tbPayeeOpenBankNo.Text.Trim(), MultiLanguageConvertHelper.ElecTicketPool_PayeeOpenBankNo, this.errorProvider1);
            //if (!rd.Result) return rd.Result;
            return rd.Result;
        }

        public void GetItem()
        {
            m_elecTicketPool = new ElecTicketPool();
            m_elecTicketPool.RemitAccount = cmbRemitAccount.Text.Trim();
            m_elecTicketPool.RemitName = tbRemitName.Text.Trim();
            m_elecTicketPool.ExchangeName = tbExcahngeName.Text.Trim();
            m_elecTicketPool.ExchangeBankNo = m_ElecTicketType == EnumTypes.ElecTicketType.AC01 ? cmbExchangeAccount.Text.Trim() : tbExchangeOpenBankNo.Text.Trim();
            if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
            {
                m_elecTicketPool.ExchangeAccount = cmbExchangeAccount.Text.Trim();
                m_elecTicketPool.ExchangeBankName = tbExchangeOpenBankName.Text.Trim();
            }
            else if (m_ElecTicketType == EnumTypes.ElecTicketType.AC01)
            {
                m_elecTicketPool.ExchangeAccount = "0";
            }
            m_elecTicketPool.PayeeAccount = cmbPayeeAccount.Text.Trim();
            m_elecTicketPool.PayeeName = tbPayeeName.Text.Trim();
            m_elecTicketPool.PayeeOpenBankName = tbPayeeOpenBankName.Text.Trim();
            m_elecTicketPool.PayeeOpenBankNo = tbPayeeOpenBankNo.Text.Trim();
            SaveRemit = chbSaveRemit.Checked;
            SaveExchange = chbExchange.Checked;
            SavePayee = chbSavePayee.Checked;
        }

        void SetItem(ElecTicketPool item)
        {
            if (null == item)
            {
                cmbRemitAccount.SelectedIndex = -1;
                cmbExchangeAccount.SelectedIndex = -1;
                cmbPayeeAccount.SelectedIndex = -1;
                cmbRemitAccount.Text =
                tbRemitName.Text =
                cmbExchangeAccount.Text =
                tbExcahngeName.Text =
                tbExchangeOpenBankName.Text =
                tbExchangeOpenBankNo.Text =
                cmbPayeeAccount.Text =
                tbPayeeName.Text =
                tbPayeeOpenBankName.Text =
                tbPayeeOpenBankNo.Text = string.Empty;
                this.errorProvider1.Clear();
            }
            else
            {
                cmbRemitAccount.Text = item.RemitAccount;
                tbRemitName.Text = item.RemitName;
                tbExcahngeName.Text = item.ExchangeName;
                if (m_ElecTicketType == EnumTypes.ElecTicketType.AC01)
                {
                    cmbExchangeAccount.Text = item.ExchangeBankNo;
                }
                else if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
                {
                    cmbExchangeAccount.Text = item.ExchangeAccount;
                    tbExchangeOpenBankName.Text = item.ExchangeBankName;
                    tbExchangeOpenBankNo.Text = item.ExchangeBankNo;
                }
                //cmbExchangeAccount.Text = item.ExchangeAccount;
                //tbExchangeOpenBankName.Text = item.ExchangeBankName;
                cmbPayeeAccount.Text = item.PayeeAccount;
                tbPayeeName.Text = item.PayeeName;
                tbPayeeOpenBankName.Text = item.PayeeOpenBankName;
                tbPayeeOpenBankNo.Text = item.PayeeOpenBankNo;
            }
            chbSaveRemit.Checked =
            chbExchange.Checked =
            chbSavePayee.Checked = false;
        }

        private void btnQueryRemit_Click(object sender, EventArgs e)
        {
            frmQueryRelateAccount frm = new frmQueryRelateAccount(cmbRemitAccount.Text, tbRemitName.Text);
            frm.PersonType = RelatePersonType.Remittor;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cmbRemitAccount.Text = frm.RelateAccount.Account;
                tbRemitName.Text = frm.RelateAccount.Name;
            }
            if (frm != null)
                frm.Close();
        }

        private void btnQueryExchange_Click(object sender, EventArgs e)
        {
            if (m_ElecTicketType == EnumTypes.ElecTicketType.AC01)
            {
                wndOpenBankQuery frm = new wndOpenBankQuery(tbExcahngeName.Text,cmbExchangeAccount.Text);
                frm.IsOpenBank = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    cmbExchangeAccount.Text = frm.QueryDialogResult.Code;
                    tbExcahngeName.Text = frm.QueryDialogResult.Name;
                }
                if (frm != null)
                    frm.Close();
            }
            else if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
            {
                frmQueryRelateAccount frm = new frmQueryRelateAccount(cmbExchangeAccount.Text, tbExcahngeName.Text);
                frm.PersonType = RelatePersonType.Exchange;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    cmbExchangeAccount.Text = frm.RelateAccount.Account;
                    tbExcahngeName.Text = frm.RelateAccount.Name;
                    tbExchangeOpenBankName.Text = frm.RelateAccount.OpenBankName;
                    tbExchangeOpenBankNo.Text = frm.RelateAccount.OpenBankNo;
                }
                if (frm != null)
                    frm.Close();
            }
        }

        private void btnQueryExchangeOpenBank_Click(object sender, EventArgs e)
        {
            wndOpenBankQuery frm = new wndOpenBankQuery(tbExchangeOpenBankName.Text, tbExchangeOpenBankNo.Text);
            frm.IsOpenBank = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                tbExchangeOpenBankName.Text = frm.QueryDialogResult.Name;
                tbExchangeOpenBankNo.Text = frm.QueryDialogResult.Code;
            }
            if (frm != null)
                frm.Close();
        }

        private void btnQueryPayee_Click(object sender, EventArgs e)
        {
            frmQueryRelateAccount frm = new frmQueryRelateAccount(cmbPayeeAccount.Text, tbPayeeName.Text);
            frm.PersonType = RelatePersonType.Payee;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cmbPayeeAccount.Text = frm.RelateAccount.Account;
                tbPayeeName.Text = frm.RelateAccount.Name;
                tbPayeeOpenBankName.Text = frm.RelateAccount.OpenBankName;
                tbPayeeOpenBankNo.Text = frm.RelateAccount.OpenBankNo;
            }
            if (frm != null)
                frm.Close();
        }

        private void btnQueryPayeeOpenBank_Click(object sender, EventArgs e)
        {
            wndOpenBankQuery frm = new wndOpenBankQuery(tbPayeeOpenBankName.Text, tbPayeeOpenBankNo.Text);
            frm.IsOpenBank = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                tbPayeeOpenBankName.Text = frm.QueryDialogResult.Name;
                tbPayeeOpenBankNo.Text = frm.QueryDialogResult.Code;
            }
            if (frm != null)
                frm.Close();
        }

        private void cmbRemitAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == cmbRemitAccount.Tag) return;
            if (cmbRemitAccount.SelectedIndex == -1)
                tbRemitName.Text = string.Empty;
            else
            {
                ElecTicketRelationAccount etra = (cmbRemitAccount.Tag as List<ElecTicketRelationAccount>)[cmbRemitAccount.SelectedIndex];
                tbRemitName.Text = etra.Name;
            }
        }

        private void cmbExchangeAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == cmbExchangeAccount.Tag) return;
            if (cmbExchangeAccount.SelectedIndex == -1)
            {
                tbExcahngeName.Text =
                tbExchangeOpenBankName.Text =
                tbExchangeOpenBankNo.Text = string.Empty;
            }
            else
            {
                ElecTicketRelationAccount etra = (cmbExchangeAccount.Tag as List<ElecTicketRelationAccount>)[cmbExchangeAccount.SelectedIndex];
                tbExcahngeName.Text = etra.Name;
                tbExchangeOpenBankName.Text = etra.OpenBankName;
                tbExchangeOpenBankNo.Text = etra.OpenBankNo;
            }
        }

        private void cmbPayeeAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == cmbPayeeAccount.Tag) return;
            if (cmbPayeeAccount.SelectedIndex == -1)
            {
                tbPayeeName.Text =
                tbPayeeOpenBankName.Text =
                tbPayeeOpenBankNo.Text = string.Empty;
            }
            else
            {
                ElecTicketRelationAccount etra = (cmbPayeeAccount.Tag as List<ElecTicketRelationAccount>)[cmbPayeeAccount.SelectedIndex];
                tbPayeeName.Text = etra.Name;
                tbPayeeOpenBankName.Text = etra.OpenBankName;
                tbPayeeOpenBankNo.Text = etra.OpenBankNo;
            }
        }
    }
}
