using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.Utilities;
using CommonClient.VisualParts;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.Controls;
using CommonClient.Contract;

namespace CommonClient.VisualParts2
{
    public partial class BatchAgentExpressHeader : BaseUc
    {
        public BatchAgentExpressHeader()
        {
            InitializeComponent();
            InitData();
            cmbBankType.SelectedIndex = 0;
            cbNoticeType.SelectedIndex = 0;

            this.Load += new EventHandler(BatchAgentNormalHeader_Load);
            CommandCenter.OnBankTypeChangedEventHandler += new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler);
            CommandCenter.OnAgentExpressEventHandler += new EventHandler<AgentExpressEventArgs>(CommandCenter_OnAgentExpressEventHandler);
            CommandCenter.OnNoticeEventHandler += new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler);
            CommandCenter.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);

            cmbBankType.SelectedIndexChanged += new EventHandler(cmbBankType_SelectedIndexChanged);
            cbAccount.SelectedIndexChanged += new EventHandler(cbAccount_SelectedIndexChanged);
            ambiguityInputAgent1.Selected += new EventHandler<CommonClient.Controls.SelectedEventParameter>(ambiguityInputAgent1_Selected);
            dtpDate.MinDate = DateTime.Today;
            dtpDate.MaxDate = DateTime.Today.AddMonths(1);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                ApplyResource();
            }
        }

        private void InitData()
        {
            int index = cmbBankType.Items.Count > 0 ? cmbBankType.SelectedIndex : -1;
            cmbBankType.Items.Clear();
            this.cmbBankType.Items.Add(EnumNameHelper<AgentTransferBankType>.GetEnumDescription(AgentTransferBankType.Boc));
            this.cmbBankType.Items.Add(EnumNameHelper<AgentTransferBankType>.GetEnumDescription(AgentTransferBankType.Other));
            cmbBankType.Tag = new List<AgentTransferBankType> { AgentTransferBankType.Boc, AgentTransferBankType.Other };
            cmbBankType.SelectedIndex = index;
            cbNotice.Items.Clear();
            index = cbNoticeType.Items.Count > 0 ? cmbBankType.SelectedIndex : -1;
            cbNoticeType.Items.Clear();
            List<AgentExpressFunctionType> templist = new List<AgentExpressFunctionType>();
            cbNoticeType.Items.Add(EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(AgentExpressFunctionType.EV));
            templist.Add(AgentExpressFunctionType.EV);
            foreach (AgentExpressFunctionType agentExpressFunctionType in PrequisiteDataProvideNode.InitialProvide.AgentExpressFunctionTypeList)
            {
                if (agentExpressFunctionType == AgentExpressFunctionType.Empty || agentExpressFunctionType == AgentExpressFunctionType.EV) continue;
                if ((SystemSettings.CurrentVersion & VersionType.v405) != VersionType.v405 && (int)agentExpressFunctionType > 40) continue;
                if ((SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar && (int)agentExpressFunctionType > 900) continue;
                var value = EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(agentExpressFunctionType);
                if ((SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
                    value = string.Format("{0} {1}", value, agentExpressFunctionType.ToString());
                this.cbNoticeType.Items.Add(value);
                templist.Add(agentExpressFunctionType);
            }
            cbNoticeType.Tag = templist;
            cbNoticeType.SelectedIndex = index;
        }

        void CommandCenter_OnPayerInfoEventHandler(object sender, PayerEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler), sender, e); }
            else
            {
                //if (m_AppType == AppliableFunctionType.AgentExpressIn) return;
                if (e.OwnerType != m_AppType && e.OwnerType != AppliableFunctionType._Empty) return;
                if (null == e.PayerInfo
                    || (null != e.PayerInfo
                        && (((e.PayerInfo.ServiceList & m_AppType) != m_AppType && m_AppType > 0)
                            || (e.PayerInfo.ServiceListBar & ((AppliableFunctionType)Math.Abs((long)m_AppType))) != ((AppliableFunctionType)Math.Abs((long)m_AppType)) && m_AppType < 0))) return;
                List<PayerInfo> list = cbAccount.Tag as List<PayerInfo>;
                if (null == list) list = new List<PayerInfo>();
                int index = list.FindIndex(o => o.Account == e.PayerInfo.Account);
                if (e.Command == OperatorCommandType.Submit)
                {
                    if (index < 0) list.Add(e.PayerInfo);
                    else list[index] = e.PayerInfo;
                }
                else if (e.Command == OperatorCommandType.Delete || e.Command == OperatorCommandType.Edit)
                    list = SystemSettings.PayerList.FindAll(o => (m_AppType > 0 && (o.ServiceList & m_AppType) == m_AppType) || (m_AppType < 0 && (o.ServiceListBar & (AppliableFunctionType)Math.Abs((long)m_AppType)) == (AppliableFunctionType)Math.Abs((long)m_AppType)));
                cbAccount.Items.Clear();
                cbAccount.Items.AddRange(list.ToArray());
                cbAccount.Tag = list;
                ambiguityInputAgent1.ClearItems();
                list.ForEach(o => ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            }
        }

        void CommandCenter_OnNoticeEventHandler(object sender, NoticeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                if (e.Command == OperatorCommandType.Submit)
                {
                    if (e.Notice != null)
                    {
                        //if (cbNotice.Items.Count > 9) return;
                        if (!string.IsNullOrEmpty(e.Notice.Content) && !cbNotice.Items.Contains(e.Notice.Content))
                            cbNotice.Items.Add(e.Notice.Content);
                    }
                    else if (e.NoticeList != null && e.NoticeList.Count > 0)
                    {
                        cbNotice.Items.Clear();
                        foreach (var item in e.NoticeList)
                        {
                            if (string.IsNullOrEmpty(item.Content)) continue;
                            cbNotice.Items.Add(item.Content);
                        }
                    }
                    else if (e.NoticeList != null && e.NoticeList.Count == 0 && cbNotice.Items.Count > 0)
                    {
                        cbNotice.Items.Clear();
                    }
                }
            }
        }

        void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAccount.SelectedIndex < 0 || m_isNewOrOpen) return;
            PayerInfo payer = (cbAccount.Tag as List<PayerInfo>)[cbAccount.SelectedIndex];
            tbName.Text = payer.Name;
        }

        void CommandCenter_OnBankTypeChangedEventHandler(object sender, BankTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.AppType) return;
                if (IsFileConvert) return;
                if (e.Command == OperatorCommandType.BankTypeCallBack)
                {
                    if (e.IsRollBack)
                    {
                        m_isCallBack = e.IsRollBack;
                        cmbBankType.SelectedIndex = (cmbBankType.SelectedIndex + 1) % 2;
                    }
                    else
                    {
                        m_BankType = e.BankType;
                        CommandCenter.ResolveBankTypeChanged(OperatorCommandType.BankTypeChanged, m_AppType, e.BankType, false);
                    }
                    m_isCallBack = false;
                }
            }
        }

        void CommandCenter_OnAgentExpressEventHandler(object sender, AgentExpressEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AgentExpressEventArgs>(CommandCenter_OnAgentExpressEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                if (OperatorCommandType.New == e.Command)
                {
                    m_isNewOrOpen = true;
                    cbAccount.SelectedIndex = -1;
                    cbAccount.Text = string.Empty;
                    tbName.Text = string.Empty;
                    dtpDate.Value = DateTime.Today;
                    cmbBankType.SelectedIndex = 0;
                    cbNoticeType.SelectedIndex = 0;
                    tbCustomerNo.Text = string.Empty;
                    cbNotice.SelectedIndex = -1;
                    cbNotice.Text = string.Empty;
                    this.errorProvider1.Clear();
                }
                else if (OperatorCommandType.Open == e.Command)
                {
                    m_isNewOrOpen = true;
                    cbAccount.Text = e.BatchInfo.Payer.Account;
                    tbName.Text = e.BatchInfo.Payer.Name;
                    try { dtpDate.Value = e.BatchInfo.TransferDatetime; }
                    catch { }
                    cmbBankType.SelectedIndex = (cmbBankType.Tag as List<AgentTransferBankType>).FindIndex(o => o == e.BatchInfo.BankType);
                    try
                    {
                        cbNoticeType.Text = EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(e.BatchInfo.AgentFunctionType_Express);
                    }
                    catch { }
                    tbCustomerNo.Text = e.BatchInfo.ProtecolNo;
                    cbNotice.Text = e.BatchInfo.Addtion;
                }
                m_isNewOrOpen = false;
            }
        }

        void BatchAgentNormalHeader_Load(object sender, EventArgs e)
        {
            //List<PayerInfo> list = SystemSettings.PayerList.FindAll(o => (o.ServiceList & m_AppType) == m_AppType);
            //if (null == list || list.Count == 0) { cbAccount.Items.Clear(); cbAccount.Tag = null; }
            //else
            //{
            //    cbAccount.Items.AddRange(list.ToArray());
            //    cbAccount.Tag = list;
            //}
        }

        private void Init()
        {
            linkConent.Visible = (SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501;
            bool flag = (m_AppType & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut || (m_AppType & AppliableFunctionType.AgentExpressOut4Bar) == AppliableFunctionType.AgentExpressOut4Bar;
            lbAccount.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_PayerAccount : MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_PayeeAccount, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbName.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_PayerName : MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_PayeeName, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbBank.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_PayeeBankName : MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_PayerBankName, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbDatetime.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_PayDate : MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_PayDate, SystemSettings.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbTip.Visible = (m_AppType & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut;

            //chbSavePayerAccount.Visible = m_AppType != AppliableFunctionType.AgentExpressIn;
            cbAccount.DropDownStyle = ComboBoxStyle.DropDown;
            chbSavePayerAccount.Checked = true;

            if (m_AppType == AppliableFunctionType.AgentExpressOut)
            {
                cbNoticeType.SelectedIndexChanged += new EventHandler(cbNoticeType_SelectedIndexChanged);
                CommandCenter.OnAgentExpressPurposeEventHandler += new EventHandler<AgentExpressPurposeEventArgs>(CommandCenter_OnAgentExpressPurposeEventHandler);
            }

            if (m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
            {
                label12.Visible =
                tbName.Enabled =
                dtpDate.Enabled =
                cbNotice.Enabled =
                tbCustomerNo.Enabled = false;
                cmbBankType.SelectedIndex = IsFileConvert ? -1 : 0;
                cbAccount.Items.Clear();
                List<PayerInfo> list = SystemSettings.PayerList.FindAll(o => ((m_AppType > 0 && (o.ServiceList & m_AppType) == AppliableFunctionType.AgentExpressOut4Bar) || (m_AppType < 0 && (o.ServiceListBar & (AppliableFunctionType)Math.Abs((long)m_AppType)) == (AppliableFunctionType)Math.Abs((long)m_AppType))));
                cbAccount.Items.AddRange(list.ToArray());
                cbAccount.Tag = list;
            }

            if (m_AppType != AppliableFunctionType._Empty)
            {
                List<PayerInfo> list = SystemSettings.PayerList.FindAll(o => ((long)m_AppType > 0 && (o.ServiceList & m_AppType) == m_AppType) || ((long)m_AppType < 0 && (o.ServiceListBar & (AppliableFunctionType)Math.Abs((long)m_AppType)) == (AppliableFunctionType)Math.Abs((long)m_AppType)));
                cbAccount.Items.Clear();
                cbAccount.Items.AddRange(list.ToArray());
                cbAccount.Tag = list;
                ambiguityInputAgent1.ClearItems();
                list.ForEach(o => ambiguityInputAgent1.AddItem(new SubstringAmbiguityInfoItem(o.Account) { Entity = o }));
            }

            cbNotice.Items.Clear();
            if (SystemSettings.Notices.ContainsKey(m_AppType))
                cbNotice.Items.AddRange(SystemSettings.Notices[m_AppType].FindAll(o => !string.IsNullOrEmpty(o.Content)).ToArray());

            labBank.Text = string.Format("该{0}代表批信息中所有的收款行，且一批信息只能有一种{1}类型。", lbBank.Text.Substring(0, lbBank.Text.Length - 1), lbBank.Text.Substring(0, lbBank.Text.Length - 1));
            SetRegex();
        }
        private void SetRegex()
        {
            //if (!(m_AppType == AppliableFunctionType.AgentExpressOut4Bar && IsFileConvert))
            //{
            //    if (cmbBankType.SelectedIndex < 0)
            //    {
            //        this.errorProvider1.SetError(cmbBankType, string.Format("{0}{1}", MultiLanguageConvertHelper.DesignMain_Please_Selection, lbBank.Text.Substring(0, lbBank.Text.Length - 1)));
            //        return;
            //    }
            //}
            if (m_AppType != AppliableFunctionType.AgentExpressOut4Bar)
            {
                cbAccount.DvRegCode = "Predefined5";
                cbAccount.DvMinLength = 1;
                cbAccount.DvMaxLength = 25;

                //if (cbNoticeType.SelectedIndex < 0) { MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_Usege), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                tbCustomerNo.DvRegCode = "Predefined5";
                tbCustomerNo.DvMinLength = 0;
                tbCustomerNo.DvMaxLength = 16;
                cbNotice.DvRegCode = "reg650";
                cbNotice.DvMinLength = 0;
                cbNotice.DvMaxLength = 80;
                if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
                    cbNotice.DvMaxLength = 200;
            }
            else
            {
                //if (!string.IsNullOrEmpty(cbAccount.Text))
                //{
                cbAccount.DvRegCode = "Predefined5";
                cbAccount.DvMinLength = 1;
                cbAccount.DvMaxLength = 25;
                //}
            }

        }

        void cbNoticeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNoticeType.SelectedIndex < 0) return;
            AgentExpressFunctionType aeft = AgentExpressFunctionType.Empty;
            if (cbNoticeType.Items.Count > 0)
                aeft = (cbNoticeType.Tag as List<AgentExpressFunctionType>)[cbNoticeType.SelectedIndex];
            CommandCenter.ResolveAgentExpressPurpose(OperatorCommandType.UseTypeRequest, m_AppType, aeft, false);
        }

        void CommandCenter_OnAgentExpressPurposeEventHandler(object sender, AgentExpressPurposeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AgentExpressPurposeEventArgs>(CommandCenter_OnAgentExpressPurposeEventHandler), sender, e); }
            else
            {
                if (e.Owner != m_AppType) return;
                if (e.Command != OperatorCommandType.UseTypeCallBack) return;
                if (e.IsRollBack)
                {
                    if (cmbBankType.Items.Count > 0)
                        cmbBankType.SelectedIndex = (cmbBankType.Tag as List<AgentExpressFunctionType>).FindIndex(o => o == m_Purpose);
                }
                else
                {
                    m_Purpose = e.Purpose;
                    CommandCenter.ResolveAgentExpressPurpose(OperatorCommandType.UseTypeChanged, e.Owner, e.Purpose, false);
                }
            }
        }

        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.AgentExpressIn == value
                    || AppliableFunctionType.AgentExpressOut == value
                    || AppliableFunctionType.AgentExpressOut4Bar == value)
                {
                    m_AppType = value; Init();
                }
            }
        }
        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        /// <summary>
        /// 是否有可用数据
        /// </summary>
        [Browsable(false)]
        public bool HasData
        {
            get { return CheckData(false); }
        }
        private bool m_isCallBack = false;
        [Browsable(true)]
        public bool IsFileConvert { get; set; }
        private bool m_isNewOrOpen = false;
        AgentTransferBankType m_BankType = AgentTransferBankType.Boc;
        AgentExpressFunctionType m_Purpose = AgentExpressFunctionType.Empty;

        [Browsable(false)]
        public BatchHeader BatchInfo
        {
            get
            {
                if (CheckData(false))
                    GetItem();
                return m_batchInfo;
            }
        }
        private BatchHeader m_batchInfo;

        public void GetItem()
        {
            m_batchInfo = new BatchHeader();
            if (m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
            {
                if (cmbBankType.SelectedIndex >= 0)
                    m_batchInfo.BankType = (cmbBankType.Tag as List<AgentTransferBankType>)[cmbBankType.SelectedIndex];
                m_batchInfo.Payer.Account = cbAccount.Text.Trim();
                m_batchInfo.AgentFunctionType_Express = (cbNoticeType.Tag as List<AgentExpressFunctionType>)[cbNoticeType.SelectedIndex];
            }
            else if (m_AppType == AppliableFunctionType.AgentExpressIn
                || m_AppType == AppliableFunctionType.AgentExpressOut)
            {
                m_batchInfo.CanAddPayer = chbSavePayerAccount.Checked;
                m_batchInfo.CanAddNotice = true;
                if (cbAccount.SelectedIndex < 0 && !string.IsNullOrEmpty(cbAccount.Text))
                    m_batchInfo.Payer = new PayerInfo { Account = cbAccount.Text.Trim(), Name = tbName.Text.Trim(), ServiceList = m_AppType };
                else if (cbAccount.SelectedIndex >= 0)
                {
                    PayerInfo payer = cbAccount.SelectedItem as PayerInfo;
                    if (payer.Account == cbAccount.Text.Trim() && payer.Name == tbName.Text.Trim())
                    {
                        m_batchInfo.Payer = payer;
                        m_batchInfo.Payer.CashType = CashType.CNY;
                    }
                }
                m_batchInfo.TransferDatetime = dtpDate.Value;
                m_batchInfo.ProtecolNo = tbCustomerNo.Text.Trim();
                m_batchInfo.AgentFunctionType_Express = (cbNoticeType.Tag as List<AgentExpressFunctionType>)[cbNoticeType.SelectedIndex];
                m_batchInfo.UseType = m_batchInfo.AgentFunctionType_Express.ToString();
                m_batchInfo.Bank = cmbBankType.Text.Trim();
                m_batchInfo.BankType = (cmbBankType.Tag as List<AgentTransferBankType>)[cmbBankType.SelectedIndex];
                m_batchInfo.Addtion = cbNotice.Text.Trim();
            }
        }
        private bool CheckData(bool flag)
        {
            ResultData rd = new ResultData { Result = true };
            rd.Result = base.CheckValid();
            //if (!(m_AppType == AppliableFunctionType.AgentExpressOut4Bar && IsFileConvert))
            //{
            //    if (cmbBankType.SelectedIndex < 0)
            //    {
            //        this.errorProvider1.SetError(cmbBankType, string.Format("{0}{1}", MultiLanguageConvertHelper.DesignMain_Please_Selection, lbBank.Text.Substring(0, lbBank.Text.Length - 1)));
            //        return false;
            //    }
            //}
            //if (m_AppType != AppliableFunctionType.AgentExpressOut4Bar)
            //{
            //    rd = DataCheckCenter.CheckPayerAccount(cbAccount, cbAccount.Text.Trim(), lbAccount.Text.Trim().Substring(0, lbAccount.Text.Length - 1), 25, flag ? this.errorProvider1 : null);
            //    if (!rd.Result) return rd.Result;
            //    if (cbNoticeType.SelectedIndex < 0) { if (flag) MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_Usege), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
            //    rd = DataCheckCenter.CheckCustomerReferenceNo(tbCustomerNo, tbCustomerNo.Text.Trim(), flag ? this.errorProvider1 : null);
            //    if (!rd.Result) return rd.Result;
            //rd = DataCheckCenter.CheckAddtion(cbNotice, cbNotice.Text.Trim(), 80, flag ? this.errorProvider1 : null);
            //if (!rd.Result) return rd.Result;
            //}
            //else
            //{
            //    if (!string.IsNullOrEmpty(cbAccount.Text))
            //    {
            //        rd = DataCheckCenter.CheckPayerAccount(cbAccount, cbAccount.Text.Trim(), lbAccount.Text.Trim().Substring(0, lbAccount.Text.Length - 1), 25, flag ? this.errorProvider1 : null);
            //        if (!rd.Result) return rd.Result;
            //    }
            //}
            return rd.Result;
        }
        public bool CheckData()
        {
            return CheckData(true);
        }

        private void cmbBankType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsFileConvert) return;
            if (m_isCallBack) { m_isCallBack = false; return; }
            if (m_isNewOrOpen)
            {
                m_isNewOrOpen = false;
                if (cmbBankType.SelectedIndex < 0) return;
                AgentTransferBankType atbt = (cmbBankType.Tag as List<AgentTransferBankType>)[cmbBankType.SelectedIndex];
                if (atbt != m_BankType)
                {
                    m_BankType = atbt;
                    CommandCenter.ResolveBankTypeChanged(OperatorCommandType.BankTypeChanged, m_AppType, m_BankType, false);
                }
                return;
            }
            if (cmbBankType.SelectedIndex < 0) return;
            AgentTransferBankType bankType = (cmbBankType.Tag as List<AgentTransferBankType>)[cmbBankType.SelectedIndex];
            if (bankType != m_BankType)
            {
                CommandCenter.ResolveBankTypeChanged(OperatorCommandType.BankTypeRequest, m_AppType, bankType, false);
            }

            if (m_AppType != AppliableFunctionType.AgentExpressOut4Bar)
            {
                if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501 && m_BankType == AgentTransferBankType.Boc)
                    cbNotice.DvMaxLength = 200;
                else cbNotice.DvMaxLength = 80;
            }
        }

        public void DisplayBankType(bool flag)
        {
            lbBank.Enabled = cmbBankType.Enabled = flag;
        }
        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            base.ApplyResource(typeof(BatchAgentExpressHeader), this);

            Init();
            InitData();
        }

        //private void pbTip_MouseHover(object sender, EventArgs e)
        //{
        //    if (m_AppType == AppliableFunctionType.AgentExpressOut)
        //        this.toolTip1.Show("该收款行代表批信息中所有的收款行，且一批信息只能有一种收款行类型。", pbTip);
        //    else
        //        this.toolTip1.Show("该付款行代表批信息中所有的付款行，且一批信息只能有一种付款行类型。", pbTip);
        //}

        void ambiguityInputAgent1_Selected(object sender, Controls.SelectedEventParameter paras)
        {
            if (this.ambiguityInputAgent1.SelectedItemIndex < 0 || m_isNewOrOpen) return;
            PayerInfo payer = (PayerInfo)this.ambiguityInputAgent1.SelectedEntity;
            tbName.Text = payer.Name;
        }

        private void linkConent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModuleWorkSpaceLoader.BroadcastApplicationBringToFront("BOC_BATCH_TOOL_SETTINGS", FunctionInSettingType.AddtionMg, m_AppType);
        }
    }
}
