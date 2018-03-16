using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.MatchFile;
using CommonClient.VisualParts;
using CommonClient.TemplateHelper;

namespace CommonClient.VisualParts2
{
    public partial class AgentExpressItemsPanel : BaseUc
    {
        public AgentExpressItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            this.Load += new EventHandler(AgentExpressItemsPanel_Load);
            CommandCenter.OnAgentExpressEventHandler += new EventHandler<AgentExpressEventArgs>(CommandCenter_OnAgentExpressEventHandler);
            CommandCenter.OnBankTypeChangedEventHandler += new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
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
                base.ApplyResource(typeof(AgentExpressItemsPanel), this);
                Init();
                ChangeUIStyle();
            }
        }

        void CommandCenter_OnQueryByRowIndexEventHandler(object sender, QueryByRowIndexEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler), sender, e); }
            else
            {
                if (e.AppType != m_AppType) return;
                if (e.RowIndex < 0 || e.RowIndex >= dgv.Rows.Count || dgv.Rows.Count == 0)
                {
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_NoMatch_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    return;
                }
                CommandCenter.ResolveAgentExpress(OperatorCommandType.View, (dgv.DataSource as List<AgentExpress>)[e.RowIndex], e.AppType, e.RowIndex);
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

        void CommandCenter_OnBankTypeChangedEventHandler(object sender, BankTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.AppType) return;
                if (e.Command == OperatorCommandType.BankTypeRequest)
                {
                    if (dgv.Rows.Count > 0)
                    {
                        if (m_AppType == AppliableFunctionType.AgentExpressOut)
                            MessageBoxPrime.Show("已存在收款行类型，同一批信息不能再修改", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        else
                            MessageBoxPrime.Show("已存在付款行类型，同一批信息不能再修改", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);

                        CommandCenter.ResolveBankTypeChanged(OperatorCommandType.BankTypeCallBack, m_AppType, e.BankType, true);
                    }
                    else
                    {
                        if (m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
                            clnBankName.Visible = true;// e.BankType == AgentTransferBankType.Other;
                        clnProvince.DataPropertyName = e.BankType == AgentTransferBankType.Other ? "BankNo" : "ProvinceString";
                        CommandCenter.ResolveBankTypeChanged(OperatorCommandType.BankTypeCallBack, m_AppType, e.BankType, false); m_BankType = e.BankType;
                    }
                }
                else if (e.Command == OperatorCommandType.BankTypeChanged)
                    m_BankType = e.BankType;
            }
        }

        void CommandCenter_OnAgentExpressEventHandler(object sender, AgentExpressEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AgentExpressEventArgs>(CommandCenter_OnAgentExpressEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.OwnerType != AppType) return;

                List<AgentExpress> list = new List<AgentExpress>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<AgentExpress>;
                #region Submit
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (null == list) list = new List<AgentExpress>();

                    if (list.Count >= SystemSettings.DefaultMaxCountAgentExpress)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    try
                    {
                        ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + double.Parse(e.AgentExpress.Amount), m_AppType == AppliableFunctionType.AgentExpressIn ? 15 : 14);
                        if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    }
                    catch { }
                    //if (e.RowIndex == -1 || e.RowIndex > list.Count)
                    //{
                    //    e.RowIndex = list.Count;
                    //    list.Add(e.AgentExpress);
                    //}
                    //else if (e.RowIndex > 0)
                    //    list.Insert(e.RowIndex - 1, e.AgentExpress);
                    list.Add(e.AgentExpress);
                    m_Amount += double.Parse(e.AgentExpress.Amount);
                }
                #endregion
                #region Edit
                else if (OperatorCommandType.Edit == e.Command)
                {
                    if (e.RowIndex < 1 || e.RowIndex > list.Count || dgv.Rows.Count == 0)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Record_Not_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + double.Parse(e.AgentExpress.Amount) - double.Parse(list[e.RowIndex - 1].Amount), m_AppType == AppliableFunctionType.AgentExpressIn ? 15 : 14);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    m_Amount += double.Parse(e.AgentExpress.Amount) - double.Parse(list[e.RowIndex - 1].Amount);
                    list[e.RowIndex - 1] = e.AgentExpress;
                }
                #endregion
                #region Delete
                else if (OperatorCommandType.Delete == e.Command)
                {
                    if (dgv.SelectedRows.Count == 0)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Please_Select_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_Record_By_ID, dgv.SelectedRows[0].Index + 1), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
                    m_Amount -= double.Parse(list[dgv.SelectedRows[0].Index].Amount);
                    list.RemoveAt(dgv.SelectedRows[0].Index);
                }
                #endregion
                #region Open
                else if (OperatorCommandType.Open == e.Command)
                {
                    m_BankType = e.BatchInfo.BankType;
                    clnProvince.DataPropertyName = e.BatchInfo.BankType == AgentTransferBankType.Other ? "BankNo" : "ProvinceString";
                    if (e.AgentExpressList.Count > SystemSettings.DefaultMaxCountAgentExpress)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.DefaultMaxCountAgentExpress), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        list = e.AgentExpressList.GetRange(0, SystemSettings.DefaultMaxCountAgentExpress);
                    }
                    else list = e.AgentExpressList;
                    ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + GetAmount(list), m_AppType == AppliableFunctionType.AgentExpressIn ? 15 : 14);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    m_Amount = GetAmount(list);
                    m_BankType = e.BatchInfo.BankType;
                    clnBankName.Visible = m_AppType == AppliableFunctionType.AgentExpressOut4Bar || m_BankType == AgentTransferBankType.Other;
                }
                #endregion
                #region CombeData
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    if (m_BankType != e.BatchInfo.BankType)
                    {
                        MessageBoxPrime.Show("数据中银行类型与现有银行类型不符", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    List<AgentExpress> tempList = new List<AgentExpress>();
                    int max = SystemSettings.DefaultMaxCountAgentExpress - dgv.Rows.Count;
                    if (e.AgentExpressList.Count > max)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, max), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        tempList = e.AgentExpressList.GetRange(0, max);
                    }
                    else tempList = e.AgentExpressList;
                    double amount = GetAmount(tempList);
                    ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + amount, m_AppType == AppliableFunctionType.AgentExpressIn ? 15 : 14);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    list.AddRange(tempList);
                    m_Amount += amount;
                }
                #endregion
                #region New
                else if (OperatorCommandType.New == e.Command)
                {
                    dgv.DataSource = null;
                    dgv.Refresh();
                    m_Amount = 0;
                    lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, 0, 0); return;
                }
                #endregion
                #region ErrorData
                else if (OperatorCommandType.ErrorData == e.Command)
                {
                    if (e.AgentExpressList != null && e.AgentExpressList.Count > 0)
                    {
                        if (e.AgentExpressList[e.AgentExpressList.Count - 1].RowIndex <= dgv.Rows.Count)
                        {
                            foreach (var item in e.AgentExpressList)
                                list[item.RowIndex - 1].ErrorReason = item.ErrorReason;
                        }
                        else
                        {
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_ErrorFile_NotMatch_SourceFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_NullErrorFile_Or_InvalidData, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                #endregion
                else if (OperatorCommandType.Print == e.Command)
                {
                    DataGridviewPrintHelper.PrintDataGridView(this, dgv, lblHeaderInfo.Text, new List<string>());
                }
                #region
                else if (OperatorCommandType.DataMoveUp == e.Command || OperatorCommandType.DataMoveDown == e.Command)
                {
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
                    AgentExpress ae = list[selectedindex];
                    list.RemoveAt(selectedindex);
                    list.Insert(selectedindex + moveindex, ae);
                    dgv.CurrentCell = dgv.Rows[selectedindex + moveindex].Cells[0];
                }
                #endregion
                else if (OperatorCommandType.Reset == e.Command) return;

                clnError.Visible = e.Command == OperatorCommandType.ErrorData || list.Exists(o => !string.IsNullOrEmpty(o.ErrorReason));
                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();
                if (e.Command == OperatorCommandType.Submit)
                    dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];
                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, DataConvertHelper.FormatCash(m_Amount.ToString(), false));

                if (e.Command == OperatorCommandType.Submit
                    || e.Command == OperatorCommandType.Edit
                    || e.Command == OperatorCommandType.Delete)
                    CommandCenter.ResolveAgentExpress(OperatorCommandType.Reset, e.OwnerType);
            }
        }

        void AgentExpressItemsPanel_Load(object sender, EventArgs e)
        {
            Init();
        }

        /// <summary>
        /// 操作功能类型
        /// AgentExpressIn-快捷代收,AgentExpressOut-快捷代发
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.AgentExpressIn == value || AppliableFunctionType.AgentExpressOut == value || AppliableFunctionType.AgentExpressOut4Bar == value)
                    m_AppType = value;
            }
        }
        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        AgentExpressFunctionType m_purpose = AgentExpressFunctionType.Empty;
        /// <summary>
        /// 是否有可用数据
        /// </summary>
        [Browsable(false)]
        public bool HasData
        {
            get { return dgv.DataSource != null && dgv.Rows.Count > 0; }
        }
        private double m_Amount = 0.00d;
        private AgentTransferBankType m_BankType = AgentTransferBankType.Boc;
        string querycontent = string.Empty;
        List<int> indexList = new List<int>();

        [Browsable(false)]
        public AgentExpress CurrentAgentExpress
        {
            get { return m_AgentExpress; }
            set { m_AgentExpress = value; }
        }
        private AgentExpress m_AgentExpress = new AgentExpress();

        private void Init()
        {
            if (AppliableFunctionType._Empty == m_AppType) return;
            bool flag = clnProtecolNo.Visible = m_AppType == AppliableFunctionType.AgentExpressIn;
            clnAmount.HeaderText = flag ? MultiLanguageConvertHelper.AgentExpressIn_Mappings_Amount : MultiLanguageConvertHelper.AgentExpressOut_Mappings_Amount;
            clnName.HeaderText = flag ? MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerName : MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeName;
            clnAccount.HeaderText = flag ? MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerAccount : MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeAccount;
            clnProvince.HeaderText = flag ? MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerOpenBankNoOrCNAPSNo : MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo;
            clnCertifyPaperyType.HeaderText = flag ? MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerCertifyCardType : MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyCardType;
            clnCertifyPayerNo.HeaderText = flag ? MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerCertifyNo : MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyNo;
            clnBankName.HeaderText = flag ? MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerOpenBankName : MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeOpenBankName;

            if (m_AppType == AppliableFunctionType.AgentExpressOut)
                CommandCenter.OnAgentExpressPurposeEventHandler += new EventHandler<AgentExpressPurposeEventArgs>(CommandCenter_OnAgentExpressPurposeEventHandler);
            if (m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
            {
                clnBankName.Visible = true;
                clnProvince.HeaderText = "收款行省行标识/人行行号";
            }
        }

        void CommandCenter_OnAgentExpressPurposeEventHandler(object sender, AgentExpressPurposeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AgentExpressPurposeEventArgs>(CommandCenter_OnAgentExpressPurposeEventHandler), sender, e); }
            else
            {
                if (e.Owner != m_AppType || e.Command != OperatorCommandType.UseTypeRequest) return;
                bool isroolback = false;
                if (dgv.RowCount > 0 && m_purpose != e.Purpose)
                {
                    isroolback = true;
                    MessageBoxPrime.Show("请先保存，然后在修改批信息中的用途", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                }
                else m_purpose = e.Purpose;
                CommandCenter.ResolveAgentExpressPurpose(OperatorCommandType.UseTypeCallBack, e.Owner, e.Purpose, isroolback);
            }
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            AgentExpress ae = (dgv.DataSource as List<AgentExpress>)[hitInfo.RowIndex];
            CommandCenter.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, m_AppType);
            CommandCenter.ResolveAgentExpress(OperatorCommandType.View, ae, m_AppType, hitInfo.RowIndex);
        }

        public bool SaveData(BatchHeader batch, bool isSaveOperator)
        {
            bool flag = false;
            if (dgv.Rows.Count > 0)
            {
                if (!isSaveOperator)
                {
                    DialogResult dr = MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Covered_Transaction_IsInformation, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OverCombineCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        dgv.DataSource = null;
                        m_Amount = 0;
                        lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, m_Amount);
                        return true;
                    }
                    else if (dr == DialogResult.No)
                    {
                        LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, m_AppType, true);
                        return false;
                    }
                    else if (dr == DialogResult.Cancel) return false;
                }
                if (dgv.Rows.Count > SystemSettings.DefaultMaxCountAgentExpress)
                {
                    if (MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.DefaultMaxCountAgentExpress), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }
                if (m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
                {
                    if (string.IsNullOrEmpty(SystemSettings.CustomerInfo.Group) || string.IsNullOrEmpty(SystemSettings.CustomerInfo.Code))
                    {
                        frmCustomerInfoMgr frm = new frmCustomerInfoMgr();
                        if (frm.ShowDialog() != DialogResult.OK) return false;
                    }
                }
                List<AgentExpress> list = dgv.DataSource as List<AgentExpress>;
                string messageStr = MatchFile.MatchFileDataHelper.CheckDataAvilidHigh(new List<object> { batch, list }, m_AppType);
                if (!string.IsNullOrEmpty(messageStr))
                {
                    MessageBoxPrime.Show(messageStr, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    flag = false;
                }
                else
                {
                    if (m_AppType == AppliableFunctionType.AgentExpressOut
                        || m_AppType == AppliableFunctionType.AgentExpressIn)
                    {
                        SaveFileDialog sfg = new SaveFileDialog();
                        string fileExtent = string.Empty;
                        if (m_AppType == AppliableFunctionType.AgentExpressOut
                            && (SystemSettings.IsMatchPassword4ShortProxyOut
                                && !string.IsNullOrEmpty(SystemSettings.ShortProxyOutPassword)))
                        { sfg.Filter = string.Format("{0}|*.sef", MultiLanguageConvertHelper.DesignMain_FileType_SEF); fileExtent = ".sef"; }
                        else
                        { sfg.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT); fileExtent = ".txt"; }
                        if (sfg.ShowDialog() == DialogResult.OK)
                        {
                            string filepath = DataConvertHelper.FormatFileName(sfg.FileName, fileExtent);

                            try
                            {
                                if (m_AppType == AppliableFunctionType.AgentExpressOut)
                                {
                                    int index = filepath.LastIndexOf(".");
                                    string temp = filepath.Substring(0, index);
                                    filepath = temp + ".txt";
                                }
                                TemplateHelper.BatchConsignDataTemplateHelper.CreateTxtDocument(m_AppType, list, batch, filepath);
                                if (m_AppType == AppliableFunctionType.AgentExpressOut)
                                {
                                    if (SystemSettings.IsMatchPassword4ShortProxyOut
                                        && !string.IsNullOrEmpty(SystemSettings.ShortProxyOutPassword))
                                    {
                                        ResultData rd = FileDataPasswordHelper.MakeToPWD(filepath, SystemSettings.ShortProxyOutPassword);
                                        if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return rd.Result; }
                                    }
                                }
                                MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Save_Succed_Please_Next, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                                flag = true;

                                dgv.DataSource = null;
                                m_Amount = 0;
                                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, m_Amount);

                            }
                            catch
                            {
                                MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeFile_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                            }
                        }
                        if (sfg != null)
                            sfg.Dispose();
                    }
                    else if (m_AppType == AppliableFunctionType.AgentExpressOut4Bar)
                    {
                        string filename = CommonInformations.GetBarFileName(m_AppType, batch.BankType);
                        FolderBrowserDialog fbd = new FolderBrowserDialog();
                        if (fbd.ShowDialog() != DialogResult.OK) return false;
                        string filepath = System.IO.Path.Combine(fbd.SelectedPath, filename);
                        frmBarPassword frm = new frmBarPassword();
                        if (frm.ShowDialog() != DialogResult.OK) return false;
                        string pwd = frm.Password;
                        try
                        {
                            bool result = TemplateHelper.BatchConsignDataTemplateHelper.CreateDATDocumentBar(m_AppType, batch, list, DataConvertHelper.FormatFileName(filepath, ".bar"), m_Amount);
                            if (!result) throw new Exception();
                            ResultData rd = FileDataPasswordBarHelper.EncodeAndZip(DataConvertHelper.FormatFileName(filepath, ".bar"), filepath, pwd);
                            if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return rd.Result; }

                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Submit_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                            flag = true;
                            dgv.DataSource = null;
                            dgv.Refresh();
                            m_Amount = 0;
                            lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, 0, m_Amount);
                            CommonInformations.SetNextOrderNo();
                        }
                        catch
                        {
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeFile_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        }
                    }
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
                (dgv.DataSource as List<AgentExpress>).ForEach(o =>
                {
                    int index = -1;
                    if (!string.IsNullOrEmpty(o.AccountName.ToString()) && o.AccountName.ToString().Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.AccountNo) && o.AccountNo.ToString().Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Amount.ToString()) && o.Amount.Contains(temp)) index = count;
                    if (m_BankType == AgentTransferBankType.Boc)
                    {
                        if (!string.IsNullOrEmpty(o.ProvinceString) && o.ProvinceString.Contains(temp)) index = count;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(o.BankName) && o.BankName.Contains(temp)) index = count;
                    }
                    if (!string.IsNullOrEmpty(o.CertifyPaperNo) && o.CertifyPaperNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CertifyPaperTypeString) && o.CertifyPaperTypeString.Contains(temp)) index = count;
                    if (AppliableFunctionType.AgentExpressIn == m_AppType)
                    {
                        if (!string.IsNullOrEmpty(o.ProtecolNo) && o.ProtecolNo.Contains(temp)) index = count;
                    }
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

        private double GetAmount(List<AgentExpress> list)
        {
            double d = 0.00d;
            foreach (var item in list)
            {
                d += double.Parse(item.Amount);
            }
            return d;
        }
    }
}
