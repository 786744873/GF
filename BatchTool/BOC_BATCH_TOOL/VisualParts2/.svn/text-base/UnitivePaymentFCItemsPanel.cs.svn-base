using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.TemplateHelper;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class UnitivePaymentFCItemsPanel : BaseUc
    {
        public UnitivePaymentFCItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            btnQuery.Click += new EventHandler(btnQuery_Click);

            CommandCenter.Instance.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.Instance.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnUnitivePaymentFCEventHandler += new EventHandler<UnitivePaymentFCEventArgs>(CommandCenter_OnUnitivePaymentFCEventHandler);
            CommandCenter.Instance.OnOverCountryPayeeAccountTypeEventHandler += new EventHandler<OverCountryPayeeAccountTypeEventArgs>(CommandCenter_OnOverCountryPayeeAccountTypeEventHandler);
            CommandCenter.Instance.OnBankTypeChangedEventHandler += new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler);
        }

        void CommandCenter_OnBankTypeChangedEventHandler(object sender, BankTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.AppType) return;
                if (e.Command != OperatorCommandType.BankTypeRequest) return;
                if (dgv.RowCount > 0 && m_AccountType == OverCountryPayeeAccountType.ForeignAccount)
                    CommandCenter.Instance.ResolveOverCountryPayeeAccountTypeChanged(OperatorCommandType.PayeeAccountTypeCallBack, m_AppType, m_AccountType, true);
                else
                {
                    if (dgv.RowCount == 0) e.IsRollBack = false;
                    else if (m_bankType != e.BankType)
                    {
                        e.BankType = m_bankType;
                        e.IsRollBack = true;
                    }
                    m_bankType = e.BankType;
                    CommandCenter.Instance.ResolveBankTypeChanged(OperatorCommandType.BankTypeCallBack, m_AppType, e.BankType, e.IsRollBack);
                    if (!e.IsRollBack) ChangeUI();
                }
            }
        }

        void CommandCenter_OnOverCountryPayeeAccountTypeEventHandler(object sender, OverCountryPayeeAccountTypeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<OverCountryPayeeAccountTypeEventArgs>(CommandCenter_OnOverCountryPayeeAccountTypeEventHandler), sender, e); }
            else
            {
                if (e.AppType != m_AppType) return;
                if (e.Command == OperatorCommandType.PayeeAccountTypeRequest)
                {
                    if (dgv.RowCount == 0) e.IsRollBack = false;
                    else
                    {
                        if (e.AccountType == OverCountryPayeeAccountType.ForeignAccount)
                        {
                            if (m_AccountType != OverCountryPayeeAccountType.Empty && m_AccountType != OverCountryPayeeAccountType.ForeignAccount)
                            {
                                e.IsRollBack = true;
                                e.AccountType = m_AccountType;
                            }
                        }
                        else
                        {
                            if (m_AccountType == OverCountryPayeeAccountType.ForeignAccount)
                            {
                                e.IsRollBack = true;
                                e.AccountType = m_AccountType;
                            }
                        }
                    }
                    CommandCenter.Instance.ResolveOverCountryPayeeAccountTypeChanged(OperatorCommandType.PayeeAccountTypeCallBack, m_AppType, e.AccountType, e.IsRollBack);
                }
                else if (e.Command == OperatorCommandType.PayeeAccountTypeChanged)
                {
                    m_AccountType = e.AccountType;
                    ChangeUI();
                }
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(UnitivePaymentFCItemsPanel), this);
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
                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_NoMatch_Record, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UnitivePaymentForeignMoney ufc = (dgv.DataSource as List<UnitivePaymentForeignMoney>)[e.RowIndex];
                CommandCenter.Instance.ResolveUnitivePaymentFC(OperatorCommandType.View, ufc, e.AppType, e.RowIndex, ufc.PayeeAccountType);
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
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Record_Not_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else CommandCenter.Instance.ResolveEditOperator(OperatorCommandType.EditOperatorCallBack, e.AppType, e.RowIndex);
                }
            }
        }

        private double m_Amount = 0.00d;
        long m_AmountD = 0;
        double m_AmountS = 0.00d;
        string querycontent = string.Empty;
        List<int> indexList = new List<int>();

        void CommandCenter_OnUnitivePaymentFCEventHandler(object sender, UnitivePaymentFCEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<UnitivePaymentFCEventArgs>(CommandCenter_OnUnitivePaymentFCEventHandler), new object[] { sender, e }); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                List<UnitivePaymentForeignMoney> list = new List<UnitivePaymentForeignMoney>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<UnitivePaymentForeignMoney>;
                if (OperatorCommandType.Submit == e.Command)
                {
                    #region
                    if (dgv.RowCount == 0)
                    {
                        m_AccountType = e.UnitivePaymentFC.PayeeAccountType;
                        if (e.UnitivePaymentFC.PayeeAccountType != OverCountryPayeeAccountType.ForeignAccount)
                            m_bankType = e.UnitivePaymentFC.PayeeOpenBankType == EnumTypes.AccountBankType.BocAccount ? AgentTransferBankType.Boc : AgentTransferBankType.Other;
                    }
                    if (dgv.Rows.Count >= SystemSettings.Instance.DefaultMaxCountUnitivePayment)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerBusinissNo) && o.CustomerBusinissNo == e.UnitivePaymentFC.CustomerBusinissNo))
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Transfer_CustomerRef_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (e.RowIndex < 1) e.RowIndex = 1;
                    if (e.RowIndex > 0 && e.RowIndex <= dgv.Rows.Count)
                        list.Insert(e.RowIndex - 1, e.UnitivePaymentFC);
                    else if (e.RowIndex > dgv.Rows.Count)
                        list.Add(e.UnitivePaymentFC);
                    #endregion
                }
                else if (OperatorCommandType.Edit == e.Command)
                {
                    #region
                    if (e.RowIndex < 1 || e.RowIndex > dgv.Rows.Count)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Record_Not_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (null == list) return;
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerBusinissNo) && o.CustomerBusinissNo == e.UnitivePaymentFC.CustomerBusinissNo))
                    {
                        if (list[e.RowIndex - 1].CustomerBusinissNo != e.UnitivePaymentFC.CustomerBusinissNo)
                        {
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Transfer_CustomerRef_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    list[e.RowIndex - 1] = e.UnitivePaymentFC;
                    #endregion
                }
                else if (OperatorCommandType.Delete == e.Command)
                {
                    #region
                    if (e.RowIndex < 1 || e.RowIndex > dgv.Rows.Count)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Record_Not_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_MakeSure_Delete_Record_By_ID, e.RowIndex), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
                    list.RemoveAt(e.RowIndex - 1);
                    CommandCenter.Instance.ResolveUnitivePaymentFC(OperatorCommandType.Reset, e.OwnerType);
                    #endregion
                }
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    #region
                    if (dgv.RowCount == 0 && e.UnitivePaymentFCList.Count > 0)
                    {
                        m_AccountType = e.UnitivePaymentFCList[0].PayeeAccountType;
                        if (m_AccountType != OverCountryPayeeAccountType.ForeignAccount)
                            m_bankType = e.UnitivePaymentFCList[0].PayeeOpenBankType == AccountBankType.BocAccount ? AgentTransferBankType.Boc : AgentTransferBankType.Other;
                        ChangeUI();
                        CommandCenter.Instance.ResolveOverCountryPayeeAccountTypeChanged(OperatorCommandType.PayeeAccountTypeCallBack, m_AppType, m_AccountType, true);
                        if (m_AccountType != OverCountryPayeeAccountType.ForeignAccount)
                            CommandCenter.Instance.ResolveBankTypeChanged(OperatorCommandType.BankTypeCallBack, m_AppType, m_bankType, true);
                    }
                    else if (dgv.RowCount > 0 && e.UnitivePaymentFCList.Count > 0)
                    {
                        if (m_AccountType != e.UnitivePaymentFCList[0].PayeeAccountType)
                        {
                            MessageBoxExHelper.Instance.Show("请选择相同业务类型的数据文件", CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    int max = SystemSettings.Instance.DefaultMaxCountUnitivePayment - dgv.Rows.Count;
                    List<UnitivePaymentForeignMoney> tempList = new List<UnitivePaymentForeignMoney>();
                    if (e.UnitivePaymentFCList.Count > max)
                    {
                        MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Only_View_Some_Record, max), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tempList = e.UnitivePaymentFCList.GetRange(0, max);
                    }
                    else tempList = e.UnitivePaymentFCList;
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerBusinissNo) && tempList.Exists(p => p.CustomerBusinissNo == o.CustomerBusinissNo)))
                    {
                        CommandCenter.Instance.ResolveUnitivePaymentFC(OperatorCommandType.View, e.UnitivePaymentFC, e.OwnerType, e.RowIndex, e.AccountType);
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Transfer_CustomerRef_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    clnError.Visible = false;
                    list.AddRange(tempList);
                    #endregion
                }
                else if (OperatorCommandType.Open == e.Command)
                {
                    #region
                    if (dgv.RowCount == 0 && e.UnitivePaymentFCList.Count > 0)
                    {
                        m_AccountType = e.UnitivePaymentFCList[0].PayeeAccountType;
                        if (m_AccountType != OverCountryPayeeAccountType.ForeignAccount)
                            m_bankType = e.UnitivePaymentFCList[0].PayeeOpenBankType == AccountBankType.BocAccount ? AgentTransferBankType.Boc : AgentTransferBankType.Other;
                        ChangeUI();
                        CommandCenter.Instance.ResolveOverCountryPayeeAccountTypeChanged(OperatorCommandType.PayeeAccountTypeCallBack, m_AppType, m_AccountType, true);
                        if (m_AccountType != OverCountryPayeeAccountType.ForeignAccount)
                            CommandCenter.Instance.ResolveBankTypeChanged(OperatorCommandType.BankTypeCallBack, m_AppType, e.UnitivePaymentFCList[0].PayeeOpenBankType == AccountBankType.BocAccount ? AgentTransferBankType.Boc : AgentTransferBankType.Other, true);
                    }
                    if (e.UnitivePaymentFCList.Count > SystemSettings.Instance.DefaultMaxCountUnitivePayment)
                    {
                        MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.Instance.DefaultMaxCountUnitivePayment), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        list = e.UnitivePaymentFCList.GetRange(0, SystemSettings.Instance.DefaultMaxCountUnitivePayment);
                    }
                    else list = e.UnitivePaymentFCList;
                    m_AccountType = e.AccountType;
                    clnError.Visible = false;
                    #endregion
                }
                else if (OperatorCommandType.ErrorData == e.Command)
                {
                    #region
                    if (e.UnitivePaymentFCList != null && e.UnitivePaymentFCList.Count > 0)
                    {
                        if (e.UnitivePaymentFCList[e.UnitivePaymentFCList.Count - 1].RowIndex <= dgv.Rows.Count)
                        {
                            foreach (var item in e.UnitivePaymentFCList)
                                list[item.RowIndex - 1].ErrorReason = item.ErrorReason;
                        }
                        else
                        {
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_ErrorFile_NotMatch_SourceFile, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_NullErrorFile_Or_InvalidData, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    clnError.Visible = true;
                    #endregion
                }
                else if (OperatorCommandType.Reset == e.Command) return;

                if (e.Command == OperatorCommandType.Submit
                    || e.Command == OperatorCommandType.Edit
                    || e.Command == OperatorCommandType.Delete)
                    CommandCenter.Instance.ResolveUnitivePaymentFC(OperatorCommandType.Reset, e.OwnerType);

                clnError.Visible = e.Command == OperatorCommandType.ErrorData;
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();

                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount, dgv.Rows.Count);

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[0].Value = i + 1;
                }
            }
        }

        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
        /// <summary>
        /// 所属功能模块
        /// </summary>
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                m_AppType = value;
            }
        }

        AgentTransferBankType m_bankType = AgentTransferBankType.Boc;
        OverCountryPayeeAccountType m_AccountType = OverCountryPayeeAccountType.Empty;
        /// <summary>
        /// 是否有可用数据
        /// </summary>
        [Browsable(false)]
        public bool HasData
        {
            get { return dgv.Rows.Count > 0; }
        }

        void ChangeUI()
        {
            clnIsPayOffLine.Visible =
            clnDealNoteF.Visible =
            clnDealNoteS.Visible =
            clnAccountBankType.Visible =
            clnPaymentCountryOrArea.Visible = m_AccountType == OverCountryPayeeAccountType.ForeignAccount;
            clnIsNoSavePay.Visible =
            clnPaymentPropertyType.Visible = m_AccountType != OverCountryPayeeAccountType.ForeignAccount;
            clnPurpose.Visible = m_AccountType != OverCountryPayeeAccountType.ForeignAccount && m_bankType == AgentTransferBankType.Boc;
            clnSendPriority.Visible =
            clnrealPayAddress.Visible =
            clnOrgCode.Visible =
            clnPayeeAddress.Visible =
            clnPayeeOpenBankAddress.Visible =
            clnFSwiftCode.Visible =
            clnCSwiftCode.Visible =
            clnCorrespendentBankName.Visible =
            clnCorrespendentBankAddress.Visible =
            clnPayeeAccountInCorrespondentBank.Visible = m_AccountType == OverCountryPayeeAccountType.ForeignAccount || (m_AccountType != OverCountryPayeeAccountType.ForeignAccount && m_bankType == AgentTransferBankType.Other);
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            List<UnitivePaymentForeignMoney> list = dgv.DataSource as List<UnitivePaymentForeignMoney>;
            UnitivePaymentForeignMoney tob = list[hitInfo.RowIndex];
            if (null != tob)
            {
                CommandCenter.Instance.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, m_AppType);
                CommandCenter.Instance.ResolveUnitivePaymentFC(OperatorCommandType.View, tob, m_AppType, hitInfo.RowIndex, tob.PayeeAccountType);
            }
        }

        public bool SaveData(bool isSaveOperator)
        {
            bool flag = false;
            if (dgv.Rows.Count > 0)
            {
                if (!isSaveOperator)
                {
                    DialogResult dr = MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Whether_Save_Record, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.No)
                    {
                        dgv.DataSource = null;
                        m_Amount = 0;
                        lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, m_Amount);
                        return true;
                    }
                    else if (dr == DialogResult.Cancel) return false;
                }
                if (dgv.Rows.Count > SystemSettings.Instance.DefaultMaxCountOverBank)
                {
                    if (MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.Instance.DefaultMaxCountOverBank), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }

                List<UnitivePaymentForeignMoney> list = dgv.DataSource as List<UnitivePaymentForeignMoney>;
                string messageStr = MatchFile.MatchFileDataHelper.Instance.CheckDataAvilidHigh(list, m_AppType);
                if (!string.IsNullOrEmpty(messageStr))
                {
                    MessageBoxExHelper.Instance.Show(messageStr, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    flag = false;
                }
                else
                {
                    SaveFileDialog sfg = new SaveFileDialog();
                    sfg.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.Instance.DesignMain_FileType_TXT);
                    if (sfg.ShowDialog() == DialogResult.OK)
                    {
                        string filepath = DataConvertHelper.Instance.FormatFileName(sfg.FileName, ".txt");

                        try
                        {
                            TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(m_AppType, list, filepath);
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Submit_Succeed, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            flag = true;
                            if (!isSaveOperator)
                            {
                                dgv.DataSource = null;
                                dgv.Refresh();
                                m_Amount = 0;
                                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, m_Amount);
                            }
                        }
                        catch
                        {
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_MakeFile_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dgv.Rows.Count == 0) return;
            string str = lblTransferDetailHeader_P.Text.Trim();
            str = str.Substring(0, str.Length - 1);
            ResultData rd = DataCheckCenter.Instance.CheckQuickQeuryContent(tbQueryContent, tbQueryContent.Text, str, this.errorProvider1);
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
                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Reach_DocumentEnd, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string temp = tbQueryContent.Text.Trim();
                indexList.Clear();
                int count = 0;
                (dgv.DataSource as List<UnitivePaymentForeignMoney>).ForEach(o =>
                {
                    int index = -1;
                    if (!string.IsNullOrEmpty(o.Amount.ToString()) && o.Amount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeName) && o.PayeeName.ToString().Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeAccount) && o.PayeeAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Address) && o.Address.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CustomerBusinissNo) && o.CustomerBusinissNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Addtion) && o.Addtion.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayerAccount) && o.PayerAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayerName) && o.PayerName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.NominalPayerAccount) && o.NominalPayerAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ApplicantName) && o.ApplicantName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.NominalPayerName) && o.NominalPayerName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.BatchNoOrTNoOrSerialNo) && o.BatchNoOrTNoOrSerialNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.OrderPayDate) && o.OrderPayDate.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CashTypeString) && o.CashTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeOpenBankName) && o.PayeeOpenBankName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Purpose) && o.Purpose.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeCountry) && o.PayeeCountry.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Contactnumber) && o.Contactnumber.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ContractNo) && o.ContractNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CorrespondentBankAddress) && o.CorrespondentBankAddress.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CorrespondentBankName) && o.CorrespondentBankName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CorrespondentBankSwiftCode) && o.CorrespondentBankSwiftCode.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CustomerBusinissNo) && o.CustomerBusinissNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.InvoiceNo) && o.InvoiceNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.IPPSMoneyTypeAmount1) && o.IPPSMoneyTypeAmount1.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.IsImportCancelAfterVerificationTypeString) && o.IsImportCancelAfterVerificationTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.IsPayOffLineString) && o.IsPayOffLineString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.NominalPayerAccount) && o.NominalPayerAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.NominalPayerName) && o.NominalPayerName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.OpenBankAddress) && o.OpenBankAddress.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.OrderPayDate) && o.OrderPayDate.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.OrgCode) && o.OrgCode.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeAccountInCorrespondentBank) && o.PayeeAccountInCorrespondentBank.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeAccountTypeString) && o.PayeeAccountTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeName) && o.PayeeName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeOpenBankSwiftCode) && o.PayeeOpenBankSwiftCode.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PaymentCountryOrAreaString) && o.PaymentCountryOrAreaString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PaymentNatureString) && o.PaymentNatureString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.realPayAddress) && o.realPayAddress.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.SendPriorityString) && o.SendPriorityString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.TransactionAddtion1) && o.TransactionAddtion1.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.TransactionAddtion2) && o.TransactionAddtion2.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.TransactionCode1) && o.TransactionCode1.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.TransactionCode2) && o.TransactionCode2.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.UnitivePaymentTypeString) && o.UnitivePaymentTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PaymentCountryOrAreaString) && o.PaymentCountryOrAreaString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.FCPayeeAccountTypeString) && o.FCPayeeAccountTypeString.Contains(temp)) index = count;
                    if (index == count) indexList.Add(count);
                    count++;
                });
                if (indexList.Count == 0)
                {
                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_NoMatch_Record, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                querycontent = temp;
                dgv.Rows[indexList[0]].Selected = true;
                dgv.FirstDisplayedScrollingRowIndex = indexList[0];
                indexList.RemoveAt(0);
            }
        }
    }
}
