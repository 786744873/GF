using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.VisualParts;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualElements
{
    public partial class BatchAgentNormalHeader : BaseUc
    {
        public BatchAgentNormalHeader()
        {
            InitializeComponent();

            m_BatchInfo = null;
            InitData();

            dtpDate.MinDate = DateTime.Today;
            dtpDate.MaxDate = DateTime.Today.AddMonths(1);

            this.Load += new EventHandler(BatchAgentNormalHeader_Load);
            cbAccount.SelectedIndexChanged += new EventHandler(cbAccount_SelectedIndexChanged);
            CommandCenter.Instance.OnAgentNormalEventHandler += new EventHandler<AgentNormalEventArgs>(CommandCenter_OnAgentNormalEventHandler);
            CommandCenter.Instance.OnCardTypeChangedEventHandler += new EventHandler<CardTypeChangedEventArgs>(CommandCenter_OnCardTypeChangedEventHandler);
            CommandCenter.Instance.OnUseTypeChangedEventHandler += new EventHandler<UseTypeChangedEventArgs>(CommandCenter_OnUseTypeChangedEventHandler);
            CommandCenter.Instance.OnNoticeEventHandler += new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler);
            CommandCenter.Instance.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
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
            cmbAgentBusinessType.Items.Clear();
            foreach (AgentBusinessType agentBusinessType in PrequisiteDataProvideNode.InitialProvide.AgentBusinessTypeList)
            {
                var value = EnumNameHelper<AgentBusinessType>.GetEnumDescription(agentBusinessType);
                this.cmbAgentBusinessType.Items.Add(value);
            }
            cmbAgentBusinessType.Tag = PrequisiteDataProvideNode.InitialProvide.AgentBusinessTypeList;
        }

        void CommandCenter_OnPayerInfoEventHandler(object sender, PayerEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler), sender, e); }
            else
            {
                if (m_AppType == AppliableFunctionType.AgentNormalIn) return;
                if (m_AppType != e.OwnerType && e.OwnerType != AppliableFunctionType._Empty) return;
                if (null == e.PayerInfo || (null != e.PayerInfo && (e.PayerInfo.ServiceList & m_AppType) != m_AppType)) return;
                if (e.Command == OperatorCommandType.Submit || e.Command == OperatorCommandType.Edit)
                {
                    if (e.PayerInfo != null && (e.PayerInfo.ServiceList & m_AppType) == m_AppType)
                    {
                        int index = cbAccount.Items.Count == 0 ? -1 : (cbAccount.Tag as List<PayerInfo>).FindIndex(o => o.Account == e.PayerInfo.Account);
                        if (index >= 0)
                        {
                            cbAccount.Items[index] = e.PayerInfo;
                            (cbAccount.Tag as List<PayerInfo>)[index] = e.PayerInfo;
                        }
                        else
                        {
                            cbAccount.Items.Add(e.PayerInfo);
                            if (cbAccount.Tag != null)
                                (cbAccount.Tag as List<PayerInfo>).Add(e.PayerInfo);
                            else cbAccount.Tag = new List<PayerInfo> { e.PayerInfo };
                        }
                    }
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    if (cbAccount.Items.Count > 0 && e.PayerInfo != null)
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

        void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAccount.SelectedIndex >= 0)
            {
                tbName.Text = (cbAccount.Tag as List<PayerInfo>)[cbAccount.SelectedIndex].Name;
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
                        if (cbNotice.Items.Count > 9) return;
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
                }
            }
        }

        void CommandCenter_OnUseTypeChangedEventHandler(object sender, UseTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<UseTypeChangedEventArgs>(CommandCenter_OnUseTypeChangedEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.AppType) return;
                if (IsFileConvert) return;
                if (e.Command == OperatorCommandType.UseTypeCallBack)
                {
                    if (e.IsRollBack)
                    {
                        m_isCallBack = e.IsRollBack;
                        cmbAgentBusinessType.SelectedIndex = m_UseType_index;
                    }
                    else
                    {
                        CommandCenter.Instance.ResolveUseTypeChanged(OperatorCommandType.UseTypeChanged, e.UseType, m_AppType, false);
                        m_UseType_index = cmbAgentBusinessType.SelectedIndex;
                    }
                    m_isCallBack = false;
                }
            }
        }

        void CommandCenter_OnCardTypeChangedEventHandler(object sender, CardTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<CardTypeChangedEventArgs>(CommandCenter_OnCardTypeChangedEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.AppType) return;
                if (IsFileConvert) return;
                if (e.Command == OperatorCommandType.CardTypeCallBack)
                {
                    if (e.IsRollBack)
                    {
                        m_isCallBack = e.IsRollBack;
                        cmbBusinesstype.SelectedIndex = m_CardType_index;
                    }
                    else
                    {
                        CommandCenter.Instance.ResolveCardTypeChanged(OperatorCommandType.CardTypeChanged, m_AppType, e.CardType, false);
                        m_CardType_index = cmbBusinesstype.SelectedIndex;
                    }
                    m_isCallBack = false;
                }
            }
        }

        void CommandCenter_OnAgentNormalEventHandler(object sender, AgentNormalEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AgentNormalEventArgs>(CommandCenter_OnAgentNormalEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != m_AppType) return;
                try
                {
                    if (OperatorCommandType.New == e.Command)
                    {
                        m_isNewOrOpen = true;
                        cbAccount.SelectedIndex = cbAccount.Items.Count > 0 ? 0 : -1;
                        cbAccount.Text = string.Empty;
                        tbName.Text = string.Empty;
                        dtpDate.Value = DateTime.Today;
                        tbBankNo.Text = string.Empty;
                        cmbAgentBusinessType.SelectedIndex = 0;
                        tbCustomerNo.Text = string.Empty;
                        cbNotice.SelectedIndex = -1;
                        cbNotice.Text = string.Empty;
                        cmbBusinesstype.SelectedIndex = 0;
                        chbSaveNotice.Checked = chbSavePayer.Checked = false;
                        this.errorProvider1.Clear();
                    }
                    else if (OperatorCommandType.Open == e.Command)
                    {
                        m_isNewOrOpen = true;
                        cbAccount.Text = e.BatchInfo.Payer.Account;
                        tbName.Text = e.BatchInfo.Payer.Name;
                        tbBankNo.Text = e.BatchInfo.BankNo;
                        if (cmbBusinesstype.Visible)
                            cmbAgentBusinessType.Text = EnumNameHelper<AgentBusinessType>.GetEnumDescription((AgentBusinessType)int.Parse(e.BatchInfo.UseType));
                        tbCustomerNo.Text = e.BatchInfo.ProtecolNo;
                        cbNotice.Text = e.BatchInfo.Addtion;
                        cmbBusinesstype.SelectedItem = EnumNameHelper<AgentCardType>.GetEnumDescription(e.BatchInfo.CardType);
                        chbSaveNotice.Checked = chbSavePayer.Checked = false;
                        dtpDate.Value = e.BatchInfo.TransferDatetime;
                    }
                }
                catch { }
                finally
                {
                    m_CardType_index = cmbBusinesstype.SelectedIndex;
                    m_isNewOrOpen = false;
                }
            }
        }

        void BatchAgentNormalHeader_Load(object sender, EventArgs e)
        {
            if (cmbBusinesstype.Items.Count > 0)
                cmbBusinesstype.SelectedIndex = 0;
            List<PayerInfo> list = SystemSettings.Instance.PayerList.FindAll(o => (o.ServiceList & m_AppType) == m_AppType);
            if (null != list && list.Count > 0)
            {
                cbAccount.Items.AddRange(list.ToArray());
                cbAccount.Tag = list;
            }
            if (m_AppType == AppliableFunctionType.AgentNormalOut)
                cmbAgentBusinessType.SelectedIndex = 0;

            if (SystemSettings.Instance.Notices.ContainsKey(m_AppType))
            {
                List<NoticeInfo> nlist = SystemSettings.Instance.Notices[m_AppType];
                cbNotice.Items.Clear();
                foreach (var item in nlist)
                {
                    if (!string.IsNullOrEmpty(item.Content))
                        cbNotice.Items.Add(item.Content);
                }
            }
        }

        private void Init()
        {
            bool flag = m_AppType == AppliableFunctionType.AgentNormalOut;
            lbAccount.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_PayerAccount : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Batch_PayeeAccount, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbName.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_PayerName : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Batch_PayeeName, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbDatetime.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_PayDate : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Batch_PayDate, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbCardType.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_CardType : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Batch_CardType, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbBankNo.Text = string.Format("{0}{1}", flag ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_BankLinkNo : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Batch_BankLinkNo, SystemSettings.Instance.CurrentLanguage == UILang.CHS ? "：" : ":");
            lbTip.Visible = lbUseType.Visible = cmbAgentBusinessType.Visible = flag;

            this.cmbBusinesstype.Items.Clear();
            foreach (AgentCardType agentCardType in PrequisiteDataProvideNode.InitialProvide.AgentCardTypeList)
            {
                if (agentCardType == AgentCardType.Empty) continue;
                if (m_AppType == AppliableFunctionType.AgentNormalIn && agentCardType == AgentCardType.QCCCard) continue;
                var value = EnumNameHelper<AgentCardType>.GetEnumDescription(agentCardType);
                this.cmbBusinesstype.Items.Add(value);
            }
            cmbBusinesstype.Tag = m_AppType == AppliableFunctionType.AgentNormalOut
                                ? PrequisiteDataProvideNode.InitialProvide.AgentCardTypeList.FindAll(o => o != AgentCardType.Empty)
                                : PrequisiteDataProvideNode.InitialProvide.AgentCardTypeList.FindAll(o => o != AgentCardType.QCCCard && o != AgentCardType.Empty);

            chbSavePayer.Checked = m_AppType != AppliableFunctionType.AgentNormalIn;
            cbAccount.DropDownStyle = m_AppType != AppliableFunctionType.AgentNormalIn ? ComboBoxStyle.DropDown : ComboBoxStyle.Simple;
        }

        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set { m_AppType = value; Init(); }
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
        int m_CardType_index = 0;
        int m_UseType_index = 0;
        private bool m_isNewOrOpen = false;
        public bool CanAddPayer { get; set; }
        public bool CanAddAddition { get; set; }

        private BatchHeader m_BatchInfo;
        [Browsable(false)]
        public BatchHeader BatchInfo
        {
            get { return m_BatchInfo; }
            set { m_BatchInfo = value; }
        }

        public bool CheckData(bool flag)
        {
            ResultData rd = DataCheckCenter.Instance.CheckPayerAccount(cbAccount, cbAccount.Text.Trim(), lbAccount.Text.Substring(0, lbAccount.Text.Length - 1), 35, flag ? this.errorProvider1 : null);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckPayDatetime(dtpDate, dtpDate.Value, lbDatetime.Text.Substring(0, lbDatetime.Text.Length - 1), flag ? this.errorProvider1 : null);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckLinkBankNo(tbBankNo, tbBankNo.Text.Trim(), lbBankNo.Text.Substring(0, lbBankNo.Text.Length - 1), flag ? this.errorProvider1 : null);
            if (!rd.Result) return rd.Result;
            if (cmbBusinesstype.SelectedIndex < 0)
            { if (flag) MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, lbCardType.Text.Substring(0, lbCardType.Text.Length - 1)), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (cmbAgentBusinessType.Visible && cmbAgentBusinessType.SelectedIndex < 0)
            { if (flag) MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Instance.Information_Please_Select, lbUseType.Text.Substring(0, lbUseType.Text.Length - 1)), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            rd = DataCheckCenter.Instance.CheckAddtion(cbNotice, cbNotice.Text.Trim(), 80, flag ? this.errorProvider1 : null);
            if (!rd.Result) return rd.Result;
            rd = DataCheckCenter.Instance.CheckCustomerReferenceNo(tbCustomerNo, tbCustomerNo.Text.Trim(), flag ? this.errorProvider1 : null);
            if (!rd.Result) return rd.Result;
            return true;
        }

        public bool CheckData()
        {
            return CheckData(true);
        }

        public void GetItem()
        {
            m_BatchInfo = new BatchHeader();
            m_BatchInfo.Payer.Account = cbAccount.SelectedIndex < 0 ? cbAccount.Text.Trim() : (cbAccount.Tag as List<PayerInfo>)[cbAccount.SelectedIndex].Account;
            m_BatchInfo.Payer.Name = tbName.Text.Trim();
            m_BatchInfo.Payer.ServiceList = m_AppType;
            m_BatchInfo.CanAddPayer = chbSavePayer.Checked;
            m_BatchInfo.ProtecolNo = tbCustomerNo.Text.Trim();
            m_BatchInfo.TransferDatetime = dtpDate.Value;
            try
            {
                if (cmbBusinesstype.SelectedIndex >= 0)
                    m_BatchInfo.CardType = (cmbBusinesstype.Tag as List<AgentCardType>)[cmbBusinesstype.SelectedIndex];
                if (m_AppType == AppliableFunctionType.AgentNormalOut)
                    m_BatchInfo.UseType = ((int)(cmbAgentBusinessType.Tag as List<AgentBusinessType>)[cmbAgentBusinessType.SelectedIndex]).ToString();
            }
            catch { }
            m_BatchInfo.BankNo = tbBankNo.Text.Trim();
            m_BatchInfo.Addtion = cbNotice.Text.Trim();
            m_BatchInfo.CanAddNotice = chbSaveNotice.Checked;
            if (cbAccount.SelectedIndex >= 0)
            {
                PayerInfo payer = cbAccount.SelectedItem as PayerInfo;
                if (payer.Account == cbAccount.Text.Trim() && payer.Name == tbName.Text.Trim())
                {
                    m_BatchInfo.Payer = payer;
                    m_BatchInfo.Payer.CashType = CashType.CNY;
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            wndLinkBankNo wnd = new wndLinkBankNo();
            if (wnd.ShowDialog() == DialogResult.OK)
                tbBankNo.Text = wnd.BankInfo.LinkID;
            if (wnd != null)
                wnd.Close();
        }

        private void cmbTransferUsageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsFileConvert) return;
            if (m_isCallBack) { m_isCallBack = false; return; }
            if (m_isNewOrOpen)
            {
                m_isNewOrOpen = false;
                if (cmbAgentBusinessType.SelectedIndex < 0) return;
                CommandCenter.Instance.ResolveUseTypeChanged(OperatorCommandType.UseTypeChanged, (cmbAgentBusinessType.Tag as List<AgentBusinessType>)[cmbAgentBusinessType.SelectedIndex], m_AppType, false);
                return;
            }
            if (cmbAgentBusinessType.SelectedIndex < 0) return;
            AgentBusinessType abt = (cmbAgentBusinessType.Tag as List<AgentBusinessType>)[cmbAgentBusinessType.SelectedIndex];
            CommandCenter.Instance.ResolveUseTypeChanged(OperatorCommandType.UseTypeRequest, abt, m_AppType, false);
        }

        private void cmbBusinesstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsFileConvert) return;
            if (m_isCallBack) { m_isCallBack = false; return; }
            if (m_isNewOrOpen)
            {
                m_isNewOrOpen = false;
                if (cmbBusinesstype.SelectedIndex < 0) return;
                CommandCenter.Instance.ResolveCardTypeChanged(OperatorCommandType.CardTypeChanged, m_AppType, (cmbBusinesstype.Tag as List<AgentCardType>)[cmbBusinesstype.SelectedIndex], false);
                return;
            }
            if (this.cmbBusinesstype.SelectedIndex < 0) return;
            AgentCardType abt = (cmbBusinesstype.Tag as List<AgentCardType>)[cmbBusinesstype.SelectedIndex];
            CommandCenter.Instance.ResolveCardTypeChanged(OperatorCommandType.CardTypeRequest, m_AppType, abt, false);
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            base.ApplyResource(typeof(BatchAgentNormalHeader), this);

            Init();
            InitData();
        }
    }
}
