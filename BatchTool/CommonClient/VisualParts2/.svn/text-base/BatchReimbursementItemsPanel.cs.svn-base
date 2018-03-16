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
    public partial class BatchReimbursementItemsPanel : BaseUc
    {
        public BatchReimbursementItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnBatchReimbursementEventHandler += new EventHandler<BatchReimbursementEventArgs>(CommandCenter_OnBatchReimbursementEventHandler);
        }

        void CommandCenter_OnBatchReimbursementEventHandler(object sender, BatchReimbursementEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<BatchReimbursementEventArgs>(CommandCenter_OnBatchReimbursementEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != AppType) return;

                List<BatchReimbursement> list = new List<BatchReimbursement>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<BatchReimbursement>;
                #region Submit
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (null == list) list = new List<BatchReimbursement>();

                    if (list.Count >= SystemSettings.DefaultMaxCountBatchReimbursement)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //try
                    //{
                    //    ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + double.Parse(e.BatchReimbursement.ReimburseAmount), m_AppType == AppliableFunctionType.AgentExpressIn ? 15 : 14);
                    //    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    //}
                    //catch { }
                    list.Add(e.BatchReimbursement);
                    m_Amount += double.Parse(e.BatchReimbursement.ReimburseAmount);
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
                    //ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + double.Parse(e.BatchReimbursement.ReimburseAmount) - double.Parse(list[e.RowIndex - 1].ReimburseAmount), 15);
                    //if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    m_Amount += double.Parse(e.BatchReimbursement.ReimburseAmount) - double.Parse(list[e.RowIndex - 1].ReimburseAmount);
                    list[e.RowIndex - 1] = e.BatchReimbursement;
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
                    m_Amount -= double.Parse(list[dgv.SelectedRows[0].Index].ReimburseAmount);
                    list.RemoveAt(dgv.SelectedRows[0].Index);
                }
                #endregion
                #region Open
                else if (OperatorCommandType.Open == e.Command)
                {
                    if (e.BatchReimbursementList.Count > SystemSettings.DefaultMaxCountBatchReimbursement)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.DefaultMaxCountBatchReimbursement), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        list = e.BatchReimbursementList.GetRange(0, SystemSettings.DefaultMaxCountBatchReimbursement);
                    }
                    else list = e.BatchReimbursementList;
                    //ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + GetAmount(list), m_AppType == AppliableFunctionType.AgentExpressIn ? 15 : 14);
                    //if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    m_Amount = GetAmount(list);
                }
                #endregion
                #region CombeData
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    List<BatchReimbursement> tempList = new List<BatchReimbursement>();
                    int max = SystemSettings.DefaultMaxCountBatchReimbursement - dgv.Rows.Count;
                    if (e.BatchReimbursementList.Count > max)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, max), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        tempList = e.BatchReimbursementList.GetRange(0, max);
                    }
                    else tempList = e.BatchReimbursementList;
                    double amount = GetAmount(tempList);
                    //ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + amount, m_AppType == AppliableFunctionType.AgentExpressIn ? 15 : 14);
                    //if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
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
                    if (e.BatchReimbursementList != null && e.BatchReimbursementList.Count > 0)
                    {
                        if (e.BatchReimbursementList[e.BatchReimbursementList.Count - 1].RowIndex <= dgv.Rows.Count)
                        {
                            foreach (var item in e.BatchReimbursementList)
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
                    BatchReimbursement ae = list[selectedindex];
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
                    CommandCenter.ResolveBatchReimbursement(OperatorCommandType.Reset, e.OwnerType);
            }
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
                base.ApplyResource(typeof(BatchReimbursement), this);
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
                CommandCenter.ResolveBatchReimbursement(OperatorCommandType.View, (dgv.DataSource as List<BatchReimbursement>)[e.RowIndex], e.AppType, e.RowIndex);
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
                m_AppType = value;
            }
        }
        private AppliableFunctionType m_AppType = AppliableFunctionType.BatchReimbursement;
        /// <summary>
        /// 是否有可用数据
        /// </summary>
        [Browsable(false)]
        public bool HasData
        {
            get { return dgv.DataSource != null && dgv.Rows.Count > 0; }
        }
        private double m_Amount = 0.00d;
        string querycontent = string.Empty;
        List<int> indexList = new List<int>();

        [Browsable(false)]
        public BatchReimbursement CurrentBatchReimbursement
        {
            get { return m_BatchReimbursement; }
            set { m_BatchReimbursement = value; }
        }
        private BatchReimbursement m_BatchReimbursement = new BatchReimbursement();

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            BatchReimbursement ae = (dgv.DataSource as List<BatchReimbursement>)[hitInfo.RowIndex];
            CommandCenter.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, m_AppType);
            CommandCenter.ResolveBatchReimbursement(OperatorCommandType.View, ae, m_AppType, hitInfo.RowIndex);
        }

        public bool SaveData(bool isSaveOperator)
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
                if (dgv.Rows.Count > SystemSettings.DefaultMaxCountBatchReimbursement)
                {
                    if (MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.DefaultMaxCountAgentExpress), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }
                List<BatchReimbursement> list = dgv.DataSource as List<BatchReimbursement>;
                string messageStr = MatchFile.MatchFileDataHelper.CheckDataAvilidHigh(list, m_AppType);
                if (!string.IsNullOrEmpty(messageStr))
                {
                    MessageBoxPrime.Show(messageStr, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    flag = false;
                }
                else
                {
                    SaveFileDialog sfg = new SaveFileDialog();
                    string fileExtent = string.Empty;
                    sfg.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT);
                    fileExtent = ".txt";
                    if (sfg.ShowDialog() == DialogResult.OK)
                    {
                        string filepath = DataConvertHelper.FormatFileName(sfg.FileName, fileExtent);
                        try
                        {
                            TemplateHelper.BatchConsignDataTemplateHelper.CreateTxtDocument(m_AppType, list, filepath, m_Amount.ToString());
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
                (dgv.DataSource as List<BatchReimbursement>).ForEach(o =>
                {
                    int index = -1;
                    if (!string.IsNullOrEmpty(o.CardNo) && o.CardNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayAmount) && o.PayAmount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayDateTime) && o.PayDateTime.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayPassword) && o.PayPassword.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ReimburseAmount) && o.ReimburseAmount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Usage) && o.Usage.Contains(temp)) index = count;
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

        private double GetAmount(List<BatchReimbursement> list)
        {
            double d = 0.00d;
            foreach (var item in list)
            {
                d += double.Parse(item.ReimburseAmount);
            }
            return d;
        }
    }
}
