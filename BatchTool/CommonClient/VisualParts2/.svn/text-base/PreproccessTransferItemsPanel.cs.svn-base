using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.VisualParts;
using CommonClient.TemplateHelper;

namespace CommonClient.VisualParts2
{
    public partial class PreproccessTransferItemsPanel : BaseUc
    {
        public PreproccessTransferItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            CommandCenter.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.OnPreproccessTransferEventHandler += new EventHandler<PreproccessTransferEventArgs>(CommandCenter_OnPreproccessTransferEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);

        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(PreproccessTransferItemsPanel), this);
            }
        }

        void CommandCenter_OnPreproccessTransferEventHandler(object sender, PreproccessTransferEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PreproccessTransferEventArgs>(CommandCenter_OnPreproccessTransferEventHandler), new object[] { sender, e }); }
            else
            {
                if (AppliableFunctionType.PreproccessTransfer != e.OwnerType) return;
                List<PreproccessTransfer> list = new List<PreproccessTransfer>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<PreproccessTransfer>;
                #region submit
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (dgv.Rows.Count >= SystemSettings.DefaultMaxCountPreproccessTransfer)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //if (e.RowIndex < 1) e.RowIndex = 1;
                    //if (e.RowIndex > 0 && e.RowIndex <= dgv.Rows.Count)
                    //    list.Insert(e.RowIndex - 1, e.PreproccessTransfer);
                    //else if (e.RowIndex > dgv.Rows.Count)
                    list.Add(e.PreproccessTransfer);
                }
                #endregion
                #region edit
                else if (OperatorCommandType.Edit == e.Command)
                {
                    if (e.RowIndex < 1 || e.RowIndex > list.Count)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Record_Not_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    list[e.RowIndex - 1] = e.PreproccessTransfer;
                }
                #endregion
                #region CombeData
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    List<PreproccessTransfer> tempList = new List<PreproccessTransfer>();
                    int max = SystemSettings.DefaultMaxCountPreproccessTransfer - dgv.Rows.Count;
                    if (e.PreproccessTransferList.Count > max)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, max), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        tempList = e.PreproccessTransferList.GetRange(0, max);
                    }
                    else
                        tempList = e.PreproccessTransferList;
                    list.AddRange(tempList);
                }
                #endregion
                #region Open
                else if (OperatorCommandType.Open == e.Command)
                {
                    if (e.PreproccessTransferList.Count > SystemSettings.DefaultMaxCountPreproccessTransfer)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.DefaultMaxCountPreproccessTransfer), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        list = e.PreproccessTransferList.GetRange(0, SystemSettings.DefaultMaxCountPreproccessTransfer);
                    }
                    else list = e.PreproccessTransferList;
                }
                #endregion
                #region delete
                else if (OperatorCommandType.Delete == e.Command)
                {
                    if (dgv.SelectedRows.Count == 0)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Please_Select_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_Record_By_ID, dgv.SelectedRows[0].Index + 1), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
                    list.RemoveAt(dgv.SelectedRows[0].Index);
                }
                #endregion
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
                    PreproccessTransfer ae = list[selectedindex];
                    list.RemoveAt(selectedindex);
                    list.Insert(selectedindex + moveindex, ae);
                    dgv.CurrentCell = dgv.Rows[selectedindex + moveindex].Cells[0];
                    #endregion
                }
                else if (OperatorCommandType.Reset == e.Command) return;

                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();
                if (e.Command == OperatorCommandType.Submit)
                    dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];
                clnError.Visible = OperatorCommandType.ErrorData == e.Command || list.Exists(o => !string.IsNullOrEmpty(o.ErrorReason));
                querycontent = string.Empty;
                indexList.Clear();

                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount, list.Count);

                if (e.Command == OperatorCommandType.Submit
                    || e.Command == OperatorCommandType.Edit
                    || e.Command == OperatorCommandType.Delete)
                    CommandCenter.ResolvePreproccessTransfer(OperatorCommandType.Reset, e.OwnerType);
            }
        }

        void CommandCenter_OnQueryByRowIndexEventHandler(object sender, QueryByRowIndexEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler), sender, e); }
            else
            {
                if (e.AppType != m_AppType) return;
                if (e.RowIndex < 0 || e.RowIndex > dgv.Rows.Count || dgv.Rows.Count == 0)
                {
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_NoMatch_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    return;
                }
                CommandCenter.ResolvePreproccessTransfer(OperatorCommandType.View, (dgv.DataSource as List<PreproccessTransfer>)[e.RowIndex], e.AppType, e.RowIndex);
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
        /// 
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
        private AppliableFunctionType m_AppType = AppliableFunctionType.PreproccessTransfer;
        /// <summary>
        /// 是否有可用数据
        /// </summary>
        [Browsable(false)]
        public bool HasData
        {
            get { return dgv.DataSource != null && dgv.Rows.Count > 0; }
        }
        string querycontent = string.Empty;
        List<int> indexList = new List<int>();

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            PreproccessTransfer ae = (dgv.DataSource as List<PreproccessTransfer>)[hitInfo.RowIndex];
            CommandCenter.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, m_AppType);
            CommandCenter.ResolvePreproccessTransfer(OperatorCommandType.View, ae, m_AppType, hitInfo.RowIndex);
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
                        lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount, dgv.Rows.Count);
                        return true;
                    }
                    else if (dr == DialogResult.No)
                    {
                        LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, m_AppType, true);
                        return false;
                    }
                    else if (dr == DialogResult.Cancel) return false;
                }

                List<PreproccessTransfer> list = dgv.DataSource as List<PreproccessTransfer>;
                string messageStr = MatchFile.MatchFileDataHelper.CheckDataAvilidHigh(list, m_AppType);
                if (!string.IsNullOrEmpty(messageStr))
                {
                    MessageBoxPrime.Show(messageStr, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    flag = false;
                }
                else
                {
                    ResultData rd = CheckMAmount(list);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return false; }
                    SaveFileDialog sfg = new SaveFileDialog();
                    sfg.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT);
                    if (sfg.ShowDialog() == DialogResult.OK)
                    {
                        string filepath = DataConvertHelper.FormatFileName(sfg.FileName, ".txt");
                        try
                        {
                            TemplateHelper.BatchConsignDataTemplateHelper.CreateTxtDocument(m_AppType, list, filepath);
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Save_Succed_Please_Next, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                            flag = true;
                            //if (!isSaveOperator)
                            //{
                            dgv.DataSource = null;
                            lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount, dgv.Rows.Count);
                            //}
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
                (dgv.DataSource as List<PreproccessTransfer>).ForEach(o =>
                {
                    int index = -1;
                    if (!string.IsNullOrEmpty(o.Amount) && o.Amount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.BatchTradeSerialNo) && o.BatchTradeSerialNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CashTypeString) && o.CashTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Content) && o.Content.Contains(temp)) index = count;
                    if (clnError.Visible && !string.IsNullOrEmpty(o.ErrorReason) && o.ErrorReason.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.InvolvedAccount) && o.InvolvedAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.InvolvedName) && o.InvolvedName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.MainAccount) && o.MainAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PreproccessAccount) && o.PreproccessAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PreproccessAmount) && o.PreproccessAmount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PreproccessName) && o.PreproccessName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.TradeDate) && o.TradeDate.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.TradeSerialNo) && o.TradeSerialNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.VirtualAccount) && o.VirtualAccount.Contains(temp)) index = count;
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

        private ResultData CheckMAmount(List<PreproccessTransfer> list)
        {
            ResultData rd = new ResultData() { Result = true };
            List<string> listts = new List<string>();
            foreach (var item in list)
            {
                if (listts.Exists(o => o.Equals(item.TradeSerialNo))) continue;
                listts.Add(item.TradeSerialNo);
            }

            foreach (var item in listts)
            {
                List<PreproccessTransfer> listgroup = list.FindAll(o => o.TradeSerialNo.Equals(item));
                if (listgroup == null || listgroup.Count == 0) continue;

                string temp = GetAllCash(listgroup);
                if (!listgroup[0].PreproccessAmount.Equals(temp))
                {
                    rd = new ResultData { Message = string.Format("待处理转账金额与转入虚拟账户金额不符") };

                    int index = list.FindIndex(o => o.TradeSerialNo.Equals(item));
                    dgv.Rows[index].Selected = true;
                    dgv.FirstDisplayedScrollingRowIndex = index;

                    break;
                }
            }
            return rd;
        }

        string GetAllCash(List<PreproccessTransfer> list)
        {
            string result = string.Empty;
            long amountl = 0;
            double amountd = 0.0d;

            foreach (var item in list)
            {
                string[] strlist = item.Amount.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if (strlist.Length > 0) amountl += long.Parse(strlist[0]);
                if (strlist.Length > 1) amountd += double.Parse(strlist[1]) / 100;
            }
            if (amountd > 1)
            {
                string[] tList = amountd.ToString("0.00").Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                amountl += int.Parse(tList[0]);
            }

            result = string.Format("{0}{1}", amountl.ToString(), list[0].CashType == CashType.JPY ? string.Empty : amountd.ToString("0.00").Substring(amountd.ToString("0.00").Length - 3));
            return result;
        }

    }
}
