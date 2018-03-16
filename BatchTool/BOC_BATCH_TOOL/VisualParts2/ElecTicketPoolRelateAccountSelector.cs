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
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class ElecTicketPoolRelateAccountSelector : BaseUc
    {
        public ElecTicketPoolRelateAccountSelector()
        {
            InitializeComponent();

            CommandCenter.Instance.OnElecTicketPoolEventHandler += new EventHandler<ElecTicketPoolEventArgs>(CommandCenter_OnElecTicketPoolEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnElecTicketRelateAccountEventHandler += new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler);
            CommandCenter.Instance.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
        }

        void CommandCenter_OnPayerInfoEventHandler(object sender, PayerEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler), sender, e); }
            else
            {
                List<PayerInfo> list = new List<PayerInfo>();
                if (cmbRemitAccount.Tag != null) list = cmbRemitAccount.Tag as List<PayerInfo>;

                if (e.Command == OperatorCommandType.Submit)
                {
                    if ((e.PayerInfo.ServiceList & AppliableFunctionType.ElecTicketRemit) != AppliableFunctionType.ElecTicketRemit) return;
                    if (list.Exists(o => o.Account == e.PayerInfo.Account)) return;
                    cmbRemitAccount.Items.Add(e.PayerInfo);
                    list.Add(e.PayerInfo);
                }
                else if (e.Command == OperatorCommandType.Edit)
                {
                    if ((e.PayerInfo.ServiceList & AppliableFunctionType.ElecTicketRemit) != AppliableFunctionType.ElecTicketRemit) return;
                    int index = list.FindIndex(o => o.Account == e.PayerInfo.Account);
                    if (index < 0) return;
                    cmbRemitAccount.Items[index] = e.PayerInfo;
                    list[index] = e.PayerInfo;
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    if ((e.PayerInfo.ServiceList & AppliableFunctionType.ElecTicketRemit) != AppliableFunctionType.ElecTicketRemit) return;
                    int index = list.FindIndex(o => o.Account == e.PayerInfo.Account);
                    if (index < 0) return;
                    cmbRemitAccount.Items.RemoveAt(index);
                    list.RemoveAt(index);
                }

                cmbRemitAccount.Tag = list;
            }
        }

        void CommandCenter_OnElecTicketRelateAccountEventHandler(object sender, ElecTicketRelateAccountEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler), sender, e); }
            else
            {
                List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
                if (cmbPayeeAccount.Items.Count > 0) list = cmbPayeeAccount.Tag as List<ElecTicketRelationAccount>;

                if (e.Command == OperatorCommandType.Submit)
                {
                    if ((e.RelationAccount.PersonType & RelatePersonType.Payee) != RelatePersonType.Payee) return;
                    int index = list.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                    if (index < 0)
                    {
                        cmbPayeeAccount.Items.Add(e.RelationAccount);
                        list.Add(e.RelationAccount);
                        cmbPayeeAccount.Tag = list;
                    }
                }
                else if (e.Command == OperatorCommandType.Edit)
                {
                    if ((e.RelationAccount.PersonType & RelatePersonType.Payee) != RelatePersonType.Payee) return;
                    int index = list.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                    if (index >= 0)
                    {
                        cmbPayeeAccount.Items[index] = e.RelationAccount;
                        list[index] = e.RelationAccount;
                        cmbPayeeAccount.Tag = list;
                    }
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    int index = list.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                    if (index >= 0)
                    {
                        cmbPayeeAccount.Items.RemoveAt(index);
                        list.RemoveAt(index);
                        cmbPayeeAccount.Tag = list;
                    }
                }
                else if (e.Command == OperatorCommandType.CombineData)
                {
                    foreach (var item in e.RelationAccountList)
                    {
                        if (item.PersonType != RelatePersonType.Payee) continue;
                        int index = list.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                        if (index < 0)
                        {
                            cmbPayeeAccount.Items.Add(e.RelationAccount);
                            list.Add(e.RelationAccount);
                        }
                    }
                    cmbPayeeAccount.Tag = list;
                }
                else return;
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

            lbExchangeAccount.Text = string.Format("{0}{1}", m_ElecTicketType == EnumTypes.ElecTicketType.AC01
                ? MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankNo
                : MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeAccount,
                SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbExchangeName.Text = string.Format("{0}{1}", m_ElecTicketType == EnumTypes.ElecTicketType.AC01
                ? MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankName
                : MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeName,
                SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");

            cmbPayeeAccount.Text =
            tbExcahngeName.Text = string.Empty;

            cmbPayeeAccount.Items.Clear();
            List<ElecTicketRelationAccount> list = SystemSettings.Instance.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & RelatePersonType.Payee) == RelatePersonType.Payee);
            cmbPayeeAccount.Items.AddRange(list.ToArray());
            cmbPayeeAccount.Tag = list;
            List<PayerInfo> plist = SystemSettings.Instance.PayerList.FindAll(o => (o.ServiceList & AppliableFunctionType.ElecTicketRemit) == AppliableFunctionType.ElecTicketRemit);
            cmbRemitAccount.Items.Clear();
            cmbRemitAccount.Items.AddRange(plist.ToArray());
            cmbRemitAccount.Tag = plist;
        }

        public bool CheckData()
        {
            ResultData rd = new ResultData();
            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(cmbRemitAccount, cmbRemitAccount.Text.Trim(), MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitAccount, 32, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(tbRemitName, tbRemitName.Text.Trim(), MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitName, 120, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(tbExcahngeName, tbExcahngeName.Text.Trim(), lbExchangeName.Text.Substring(0, lbExchangeName.Text.Length - 1), 120, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            if (m_ElecTicketType == EnumTypes.ElecTicketType.AC01)
            {
                rd = DataCheckCenter.Instance.CheckCNAPSNo(cmbExchangeAccount, cmbExchangeAccount.Text.Trim(), lbExchangeAccount.Text.Substring(0, lbExchangeAccount.Text.Length - 1), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            else if (m_ElecTicketType == EnumTypes.ElecTicketType.AC02)
            {
                rd = DataCheckCenter.Instance.CheckPayeeOrElecTicketPersonAccount(cmbExchangeAccount, cmbExchangeAccount.Text.Trim(), MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeAccount, 32, this.errorProvider1);
                if (!rd.Result) return rd.Result;
                rd = DataCheckCenter.Instance.CheckCNAPSNo(tbExchangeOpenBankNo, tbExchangeOpenBankNo.Text.Trim(), lbExchangeOpenBankNo.Text.Trim(), this.errorProvider1);
                if (!rd.Result) return rd.Result;
            }
            rd = DataCheckCenter.Instance.CheckPayeeOrElecTicketPersonAccount(cmbPayeeAccount, cmbPayeeAccount.Text.Trim(), MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeAccount, 32, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(tbPayeeName, tbPayeeName.Text.Trim(), MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeName, 120, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckOpenBankName(tbPayeeOpenBankName, tbPayeeOpenBankName.Text.Trim(), MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankName, 120, this.errorProvider1);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckCNAPSNo(tbPayeeOpenBankNo, tbPayeeOpenBankNo.Text.Trim(), MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankNo, this.errorProvider1);
            if (!rd.Result) return rd.Result;
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
            frmQueryRelateAccount frm = new frmQueryRelateAccount();
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
                wndOpenBankQuery frm = new wndOpenBankQuery();
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
                frmQueryRelateAccount frm = new frmQueryRelateAccount();
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
            wndOpenBankQuery frm = new wndOpenBankQuery();
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
            frmQueryRelateAccount frm = new frmQueryRelateAccount();
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
            wndOpenBankQuery frm = new wndOpenBankQuery();
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
