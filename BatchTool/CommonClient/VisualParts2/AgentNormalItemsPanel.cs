using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.Utilities;
using CommonClient.VisualParts;
using CommonClient.TemplateHelper;

namespace CommonClient.VisualParts2
{
    public partial class AgentNormalItemsPanel : BaseUc
    {
        public AgentNormalItemsPanel()
        {
            InitializeComponent();
            this.Load += new EventHandler(AgentItemsPanel_Load);
            dgv.AutoGenerateColumns = false;
            CommandCenter.OnAgentNormalEventHandler += new EventHandler<AgentNormalEventArgs>(CommandCenter_OnAgentNormalEventHandler);
            CommandCenter.OnCardTypeChangedEventHandler += new EventHandler<CardTypeChangedEventArgs>(CommandCenter_OnCardTypeChangedEventHandler);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.OnUseTypeChangedEventHandler += new EventHandler<UseTypeChangedEventArgs>(CommandCenter_OnUseTypeChangedEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        void ChangeUIStyle()
        {
            lblTransferDetailHeader_P.Location = new Point { X = lblTransferDetailHeader_P.Location.X + this.Width - 500, Y = lblTransferDetailHeader_P.Location.Y };
            tbQueryContent.Location = new Point { X = tbQueryContent.Location.X + this.Width - 500, Y = tbQueryContent.Location.Y };
            btnQuery.Location = new Point { X = btnQuery.Location.X + this.Width - 500, Y = btnQuery.Location.Y };
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

        void CommandCenter_OnUseTypeChangedEventHandler(object sender, UseTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<UseTypeChangedEventArgs>(CommandCenter_OnUseTypeChangedEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.AppType) return;
                if (e.Command == OperatorCommandType.UseTypeRequest)
                {
                    if (dgv.Rows.Count > 0)
                    {
                        if (m_UseType != e.UseType)
                        {
                            MessageBoxPrime.Show("已存在相关数据记录，不能修改用途类型", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                            CommandCenter.ResolveUseTypeChanged(OperatorCommandType.UseTypeCallBack, e.UseType, e.AppType, true);
                            return;
                        }
                    }
                    CommandCenter.ResolveUseTypeChanged(OperatorCommandType.UseTypeCallBack, e.UseType, e.AppType, false);
                    m_UseType = e.UseType;
                }
                else if (e.Command == OperatorCommandType.UseTypeChanged)
                    m_UseType = e.UseType;
            }
        }

        void CommandCenter_OnQueryByRowIndexEventHandler(object sender, QueryByRowIndexEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler), sender, e); }
            else
            {
                if (e.AppType != m_AppType) return;
                if (e.RowIndex <= 0 || e.RowIndex > dgv.Rows.Count || dgv.Rows.Count == 0)
                {
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_NoMatch_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    return;
                }
                CommandCenter.ResolveAgentNormal(OperatorCommandType.View, (dgv.DataSource as List<AgentNormal>)[e.RowIndex], e.AppType, e.RowIndex);
            }
        }

        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != m_AppType) return;
                if (e.Command == OperatorCommandType.EditOperatorRequest)
                {
                    if (dgv.Rows.Count == 0 || dgv.Rows.Count < e.RowIndex)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Record_Not_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorCallBack, e.AppType, e.RowIndex);
                }
            }
        }

        void CommandCenter_OnCardTypeChangedEventHandler(object sender, CardTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<CardTypeChangedEventArgs>(CommandCenter_OnCardTypeChangedEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.AppType) return;
                if (e.Command == OperatorCommandType.CardTypeRequest)
                {
                    if (dgv.Rows.Count > 0)
                    {
                        if (m_CardType != e.CardType && (m_CardType == AgentCardType.OtherBankCard || e.CardType == AgentCardType.OtherBankCard))
                        {
                            MessageBoxPrime.Show("已存在相关数据记录，不能修改卡类型", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                            CommandCenter.ResolveCardTypeChanged(OperatorCommandType.CardTypeCallBack, m_AppType, e.CardType, true);
                            return;
                        }
                    }
                    CommandCenter.ResolveCardTypeChanged(OperatorCommandType.CardTypeCallBack, m_AppType, e.CardType, false);
                    m_CardType = e.CardType;
                }
                else if (e.Command == OperatorCommandType.CardTypeChanged)
                    m_CardType = e.CardType;
            }
        }

        void CommandCenter_OnAgentNormalEventHandler(object sender, AgentNormalEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AgentNormalEventArgs>(CommandCenter_OnAgentNormalEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != AppType) return;
                List<AgentNormal> list = new List<AgentNormal>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<AgentNormal>;
                if (OperatorCommandType.Submit == e.Command)
                {
                    #region
                    int max = m_CardType == AgentCardType.OtherBankCard
                        ? SystemSettings.DefaultMaxCountAgentNormal
                        : m_AppType == AppliableFunctionType.AgentNormalIn
                            ? SystemSettings.DefaultMaxCountAgentNormalInBOC
                            : SystemSettings.DefaultMaxCountAgentNormalOutBOC;
                    if (list.Count >= max)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + double.Parse(e.AgentNormal.Amount), m_AppType == AppliableFunctionType.AgentNormalIn ? 14 : 15);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    //if (e.RowIndex == -1 || e.RowIndex > list.Count)
                    list.Add(e.AgentNormal);
                    //else if (e.RowIndex > 0)
                    //    list.Insert(e.RowIndex - 1, e.AgentNormal);
                    m_Amount += double.Parse(e.AgentNormal.Amount);
                    #endregion
                }
                else if (OperatorCommandType.Edit == e.Command)
                {
                    #region
                    if (e.RowIndex < 1 || e.RowIndex > list.Count)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Record_Not_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + double.Parse(e.AgentNormal.Amount) - double.Parse(list[e.RowIndex - 1].Amount), m_AppType == AppliableFunctionType.AgentNormalIn ? 14 : 15);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    m_Amount += double.Parse(e.AgentNormal.Amount) - double.Parse(list[e.RowIndex - 1].Amount);
                    list[e.RowIndex - 1] = e.AgentNormal;
                    #endregion
                }
                else if (OperatorCommandType.Delete == e.Command)
                {
                    #region
                    if (dgv.SelectedRows.Count == 0)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Please_Select_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_Record_By_ID, dgv.SelectedRows[0].Index + 1), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
                    m_Amount -= double.Parse(list[dgv.SelectedRows[0].Index].Amount);
                    list.RemoveAt(dgv.SelectedRows[0].Index);
                    #endregion
                }
                else if (OperatorCommandType.Reset == e.Command) return;
                else if (OperatorCommandType.Open == e.Command)
                {
                    #region
                    m_CardType = e.BatchInfo.CardType;
                    int max = m_CardType == AgentCardType.OtherBankCard
                          ? SystemSettings.DefaultMaxCountAgentNormal
                          : m_AppType == AppliableFunctionType.AgentNormalIn
                              ? SystemSettings.DefaultMaxCountAgentNormalInBOC
                              : SystemSettings.DefaultMaxCountAgentNormalOutBOC;
                    if (list.Count + e.AgentNormalList.Count > max)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, max - list.Count), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        list = e.AgentNormalList.GetRange(0, max);
                    }
                    else list = e.AgentNormalList;
                    ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + GetAmount(list), m_AppType == AppliableFunctionType.AgentNormalIn ? 14 : 15);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    m_Amount = GetAmount(list);
                    m_UseType = AgentBusinessType.Salary;
                    int index = CommonClient.Utilities.PrequisiteDataProvideNode.InitialProvide.AgentBusinessTypeList.FindIndex(o => o.ToString() == e.BatchInfo.UseType);
                    if (index >= 0) m_UseType = CommonClient.Utilities.PrequisiteDataProvideNode.InitialProvide.AgentBusinessTypeList[index];
                    m_CardType = e.BatchInfo.CardType;
                    index = CommonClient.Utilities.PrequisiteDataProvideNode.InitialProvide.AgentCardTypeList.FindIndex(o => e.BatchInfo.CardType == o && o != AgentCardType.Empty);
                    if (index >= 0) m_CardType = CommonClient.Utilities.PrequisiteDataProvideNode.InitialProvide.AgentCardTypeList[index];
                    #endregion
                }
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    #region
                    int index = CommonClient.Utilities.PrequisiteDataProvideNode.InitialProvide.AgentCardTypeList.FindIndex(o => e.BatchInfo.CardType == o && o != AgentCardType.Empty);
                    if (dgv.Rows.Count == 0) { m_CardType = index < 0 ? AgentCardType.MemoryCard : CommonClient.Utilities.PrequisiteDataProvideNode.InitialProvide.AgentCardTypeList[index]; }
                    else
                    {
                        AgentCardType act = index < 0 ? AgentCardType.Empty : CommonClient.Utilities.PrequisiteDataProvideNode.InitialProvide.AgentCardTypeList[index];
                        if ((m_CardType != act && (m_CardType == AgentCardType.OtherBankCard || act == AgentCardType.OtherBankCard)) || act == AgentCardType.Empty)
                        { MessageBoxPrime.Show("数据中卡类型与现有卡类型不符", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    }
                    index = CommonClient.Utilities.PrequisiteDataProvideNode.InitialProvide.AgentBusinessTypeList.FindIndex(o => o.ToString() == e.BatchInfo.UseType);
                    if (dgv.Rows.Count == 0) { m_UseType = index < 0 ? AgentBusinessType.Salary : CommonClient.Utilities.PrequisiteDataProvideNode.InitialProvide.AgentBusinessTypeList[index]; }
                    else
                    {
                        AgentBusinessType abt = index < 0 ? AgentBusinessType.Salary : CommonClient.Utilities.PrequisiteDataProvideNode.InitialProvide.AgentBusinessTypeList[index];
                        if (m_UseType != abt)
                        { MessageBoxPrime.Show("数据中用途与现有用途不符", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    }
                    int max = m_CardType == AgentCardType.OtherBankCard
                             ? SystemSettings.DefaultMaxCountAgentNormal
                             : m_AppType == AppliableFunctionType.AgentNormalIn
                                 ? SystemSettings.DefaultMaxCountAgentNormalInBOC
                                 : SystemSettings.DefaultMaxCountAgentNormalOutBOC;
                    List<AgentNormal> tempList = new List<AgentNormal>();
                    if (e.AgentNormalList.Count > max - dgv.Rows.Count)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, max - dgv.Rows.Count), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        tempList = e.AgentNormalList.GetRange(0, max - dgv.Rows.Count);
                    }
                    else tempList = e.AgentNormalList;
                    double amount = GetAmount(tempList);
                    ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + amount, m_AppType == AppliableFunctionType.AgentNormalIn ? 14 : 15);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    list.AddRange(tempList);
                    m_Amount += amount;
                    #endregion
                }
                else if (OperatorCommandType.New == e.Command)
                {
                    #region
                    dgv.DataSource = null;
                    dgv.Refresh();
                    m_Amount = 0;
                    lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, 0, 0); return;
                    #endregion
                }
                else if (OperatorCommandType.DataMoveUp == e.Command || OperatorCommandType.DataMoveDown == e.Command)
                {
                    #region
                    if (dgv.RowCount == 0)
                    {
                        this.dgv.ShowNoDataTip();
                        return;
                    }
                    else if (dgv.SelectedRows.Count == 0)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Please_Select_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (dgv.RowCount == 1)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_No_Data_Can_Move, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int selectedindex = dgv.SelectedRows[0].Index;
                    int moveindex = OperatorCommandType.DataMoveUp == e.Command ? -1 : 1;
                    if (selectedindex + moveindex >= dgv.RowCount || selectedindex + moveindex < 0) return;
                    AgentNormal ae = list[selectedindex];
                    list.RemoveAt(selectedindex);
                    list.Insert(selectedindex + moveindex, ae);
                    dgv.CurrentCell = dgv.Rows[selectedindex + moveindex].Cells[0];
                    #endregion
                }

                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();
                if (e.Command == OperatorCommandType.Submit)
                    dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];
                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, list.Count, DataConvertHelper.FormatCash(m_Amount.ToString(), false));

                if (e.Command == OperatorCommandType.Submit
                    || e.Command == OperatorCommandType.Edit
                    || e.Command == OperatorCommandType.Delete)
                    CommandCenter.ResolveAgentNormal(OperatorCommandType.Reset, e.OwnerType);
            }
        }

        void AgentItemsPanel_Load(object sender, EventArgs e)
        {
            Init();
        }

        /// <summary>
        /// 操作功能类型
        /// AgentNormalIn-普通代收,AgentNormalOut-快捷代发
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.AgentNormalIn == value || AppliableFunctionType.AgentNormalOut == value)
                    m_AppType = value;
            }
        }
        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        private double m_Amount = 0.0d;
        private AgentCardType m_CardType = AgentCardType.MemoryCard;
        string querycontent = string.Empty;
        List<int> indexList = new List<int>();
        private AgentBusinessType m_UseType = AgentBusinessType.Salary;
        /// <summary>
        /// 是否有可用数据
        /// </summary>
        [Browsable(false)]
        public bool HasData
        {
            get { return dgv.DataSource != null && dgv.Rows.Count > 0; }
        }

        private void Init()
        {
            if (AppliableFunctionType._Empty == m_AppType) return;
            bool flag = clnProtecolNo.Visible = (AppliableFunctionType.AgentNormalIn & m_AppType) == AppliableFunctionType.AgentNormalIn;
            clnAmount.HeaderText = flag ? MultiLanguageConvertHelper.AgentNormalIn_Mappings_Amount : MultiLanguageConvertHelper.AgentNormalOut_Mappings_Amount;//款金额", flag ? "收" : "付");
            clnName.HeaderText = flag ? MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayerName : MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeName;//款人名称", firstStr);
            clnAccount.HeaderText = flag ? MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayerAccount : MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeAccount;//款人账号", firstStr);
            clnBankNo.HeaderText = flag ? MultiLanguageConvertHelper.AgentNormalIn_Mappings_BankLinkNoOrCNAPSNo : MultiLanguageConvertHelper.AgentNormalOut_Mappings_BankLinkNoOrCNAPSNo;//款行联行号（或CNAPS行号）", firstStr);
            clnBankName.HeaderText = flag ? MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayerBankName : MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeBankName;//款行行名", firstStr);
            clnCertifyPaperyType.HeaderText = flag ? MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayerCertifyCardType : MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeCertifyCardType;//款人证件类型", firstStr);
            clnCertifyPayerNo.HeaderText = flag ? MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayerCertifyNo : MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeCertifyNo;//款人证件号码", firstStr);
            clnFunc.DataPropertyName = flag ? "UseType_In" : "UseTypeString";
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            AgentNormal an = (dgv.DataSource as List<AgentNormal>)[hitInfo.RowIndex];
            CommandCenter.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, m_AppType);
            CommandCenter.ResolveAgentNormal(OperatorCommandType.View, an, m_AppType, hitInfo.RowIndex);
        }

        public bool SaveData(BatchHeader batch, bool isSaveOperator)
        {
            bool flag = false;
            if (dgv.Rows.Count > 0)
            {
                int maxExportCount = m_CardType == AgentCardType.OtherBankCard
                                    ? SystemSettings.DefaultMaxCountAgentNormal
                                    : m_AppType == AppliableFunctionType.AgentNormalIn
                                        ? SystemSettings.DefaultMaxCountAgentNormalInBOC
                                        : SystemSettings.DefaultMaxCountAgentNormalOutBOC;
                if (!isSaveOperator)
                {
                    DialogResult dr = MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Covered_Transaction_IsInformation, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OverCombineCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        dgv.DataSource = null;
                        m_Amount = 0;
                        lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, 0, m_Amount);
                        return true;
                    }
                    else if (dr == DialogResult.No)
                    {
                        LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, m_AppType, true);
                        return false;
                    }
                    else if (dr == DialogResult.Cancel) return false;
                }
                if (dgv.Rows.Count > maxExportCount)
                {
                    if (MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Whether_Continue, maxExportCount), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }
                List<AgentNormal> list = dgv.DataSource as List<AgentNormal>;
                string messageStr = MatchFile.MatchFileDataHelper.CheckDataAvilidHigh(new List<object> { batch, list }, m_AppType);
                if (!string.IsNullOrEmpty(messageStr))
                {
                    MessageBoxPrime.Show(messageStr, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    flag = false;
                }
                else
                {
                    SaveFileDialog sfg = new SaveFileDialog();
                    sfg.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT);
                    if (sfg.ShowDialog() == DialogResult.OK)
                    {
                        string filepath = DataConvertHelper.FormatFileName(sfg.FileName, ".txt");

                        try
                        {
                            TemplateHelper.BatchConsignDataTemplateHelper.CreateTxtDocument(m_AppType, list, batch, filepath);
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Save_Succed_Please_Next, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                            flag = true;

                            dgv.DataSource = null;
                            m_Amount = 0;
                            lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, list.Count, m_Amount);

                        }
                        catch
                        {
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeFile_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (sfg != null)
                        sfg.Dispose();
                }
            }
            else flag = true;
            return flag;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                this.dgv.ShowNoDataTip();
                return;
            }
            string str = lblTransferDetailHeader_P.Text.Trim();
            str = str.Substring(0, str.Length - 1);
            ResultData rd = DataCheckCenter.CheckQuickQeuryContent(tbQueryContent, tbQueryContent.Text, str, this.errorProvider1);
            if (!rd.Result) return;

            for (int i = 0; i < dgv.SelectedRows.Count; i++)
            {
                dgv.SelectedRows[i].Selected = false;
            }

            if (querycontent.Equals(tbQueryContent.Text.Trim()))
            {
                if (indexList.Count > 0)
                {
                    dgv.Rows[indexList[0]].Selected = true;
                    dgv.FirstDisplayedScrollingRowIndex = indexList[0];
                    indexList.RemoveAt(0);
                }
                if (indexList.Count == 0)
                {
                    querycontent = string.Empty;
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Reach_DocumentEnd, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string temp = tbQueryContent.Text.Trim();
                indexList.Clear();
                int count = 0;
                (dgv.DataSource as List<AgentNormal>).ForEach(o =>
                {
                    int index = -1;
                    if (!string.IsNullOrEmpty(o.AccountName.ToString()) && o.AccountName.ToString().Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.AccountNo) && o.AccountNo.ToString().Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Amount.ToString()) && o.Amount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.BankName) && o.BankName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.BankNo) && o.BankNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CertifyPaperNo) && o.CertifyPaperNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CertifyPaperTypeString) && o.CertifyPaperTypeString.Contains(temp)) index = count;
                    if (AppliableFunctionType.AgentNormalIn == m_AppType)
                    {
                        if (!string.IsNullOrEmpty(o.ProtecolNo) && o.ProtecolNo.Contains(temp)) index = count;
                    }
                    if (!string.IsNullOrEmpty(o.UseTypeString) && o.UseTypeString.Contains(temp)) index = count;
                    if (index == count) indexList.Add(count);
                    count++;
                });
                if (indexList.Count == 0)
                {
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_NoMatch_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                    return;
                }
                querycontent = temp;
                dgv.Rows[indexList[0]].Selected = true;
                dgv.FirstDisplayedScrollingRowIndex = indexList[0];
                indexList.RemoveAt(0);
            }
        }

        private double GetAmount(List<AgentNormal> list)
        {
            double d = 0.00d;
            foreach (var item in list)
            {
                d += double.Parse(item.Amount);
            }
            return d;
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            base.ApplyResource(typeof(AgentNormalItemsPanel), this);

            Init();
            ChangeUIStyle();
        }
    }
}
