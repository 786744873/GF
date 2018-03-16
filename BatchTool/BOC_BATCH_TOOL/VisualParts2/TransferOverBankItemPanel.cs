using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Entities;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class TransferOverBankItemPanel : BaseUc
    {
        public TransferOverBankItemPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            CommandCenter.Instance.OnTransferAccountEventHandler += new EventHandler<TransferEventArgs>(CommandCenter_OnTransferOverBankEventHandler);
            CommandCenter.Instance.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.Instance.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
        }

        void ChangeUIStyle()
        {
            lblTransferDetailHeader_P.Location = new Point { X = lblTransferDetailHeader_P.Location.X + this.Width - 800, Y = lblTransferDetailHeader_P.Location.Y };
            tbQueryContent.Location = new Point { X = tbQueryContent.Location.X + this.Width - 800, Y = tbQueryContent.Location.Y };
            btnQuery.Location = new Point { X = btnQuery.Location.X + this.Width - 800, Y = btnQuery.Location.Y };
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(TransferOverBankItemPanel), this);
                ChangeUIStyle();
                InitFieldList();
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
                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_NoMatch_Record, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CommandCenter.Instance.ResolveTransferAccount(OperatorCommandType.View, (dgv.DataSource as List<TransferAccount>)[e.RowIndex], e.AppType, e.RowIndex);
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
        string querycontent = string.Empty;
        List<int> indexList = new List<int>();

        void CommandCenter_OnTransferOverBankEventHandler(object sender, TransferEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<TransferEventArgs>(CommandCenter_OnTransferOverBankEventHandler), new object[] { sender, e }); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                List<TransferAccount> list = new List<TransferAccount>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<TransferAccount>;
                if (OperatorCommandType.Submit == e.Command)
                {
                    #region
                    if (dgv.Rows.Count >= SystemSettings.Instance.DefaultMaxCountOverBank)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerRef) && o.CustomerRef == e.TransferAccount.CustomerRef))
                    {
                        CommandCenter.Instance.ResolveTransferAccount(OperatorCommandType.View, e.TransferAccount, e.OwnerType, e.RowIndex);
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Transfer_CustomerRef_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ResultData rd = DataCheckCenter.Instance.CheckAllCash(m_Amount + e.TransferAccount.PayAmount, 15);
                    if (!rd.Result) { MessageBoxExHelper.Instance.Show(rd.Message, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    if (e.RowIndex < 1) e.RowIndex = 1;
                    if (e.RowIndex > 0 && e.RowIndex <= dgv.Rows.Count)
                        list.Insert(e.RowIndex - 1, e.TransferAccount);
                    else if (e.RowIndex > dgv.Rows.Count)
                        list.Add(e.TransferAccount);
                    m_Amount += double.Parse(e.TransferAccount.PayAmount);
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
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerRef) && o.CustomerRef == e.TransferAccount.CustomerRef))
                    {
                        if (list[e.RowIndex - 1].CustomerRef != e.TransferAccount.CustomerRef)
                        {
                            CommandCenter.Instance.ResolveTransferAccount(OperatorCommandType.View, e.TransferAccount, e.OwnerType, e.RowIndex);
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Transfer_CustomerRef_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    ResultData rd = DataCheckCenter.Instance.CheckAllCash(m_Amount + double.Parse(e.TransferAccount.PayAmount) - double.Parse(list[e.RowIndex - 1].PayAmount), 15);
                    if (!rd.Result) { MessageBoxExHelper.Instance.Show(rd.Message, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    m_Amount += double.Parse(e.TransferAccount.PayAmount) - double.Parse(list[e.RowIndex - 1].PayAmount);
                    list[e.RowIndex - 1] = e.TransferAccount;
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
                    m_Amount -= double.Parse(list[e.RowIndex - 1].PayAmount);
                    list.RemoveAt(e.RowIndex - 1);
                    #endregion
                }
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    #region
                    int max = SystemSettings.Instance.DefaultMaxCountTransfer - dgv.Rows.Count;
                    List<TransferAccount> tempList = new List<TransferAccount>();
                    if (e.TransferAccountList.Count > max)
                    {
                        MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Only_View_Some_Record, max), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tempList = e.TransferAccountList.GetRange(0, max);
                    }
                    else tempList = e.TransferAccountList;
                    double amount = GetAmount(tempList);
                    ResultData rd = DataCheckCenter.Instance.CheckAllCash(m_Amount + amount, 15);
                    if (!rd.Result) { MessageBoxExHelper.Instance.Show(rd.Message, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    clnError.Visible = false;
                    m_Amount += amount;
                    list.AddRange(e.TransferAccountList);
                    #endregion
                }
                else if (OperatorCommandType.Open == e.Command)
                {
                    #region
                    if (e.TransferAccountList.Count > SystemSettings.Instance.DefaultMaxCountTransfer)
                    {
                        MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.Instance.DefaultMaxCountTransfer), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        list = e.TransferAccountList.GetRange(0, SystemSettings.Instance.DefaultMaxCountTransfer);
                    }
                    else list = e.TransferAccountList;
                    double amount = GetAmount(list);
                    ResultData rd = DataCheckCenter.Instance.CheckAllCash(amount, 15);
                    if (!rd.Result) { MessageBoxExHelper.Instance.Show(rd.Message, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    m_Amount = amount;
                    clnError.Visible = false;
                    #endregion
                }
                else if (OperatorCommandType.ErrorData == e.Command)
                {
                    #region
                    if (e.TransferAccountList != null && e.TransferAccountList.Count > 0)
                    {
                        if (e.TransferAccountList[e.TransferAccountList.Count - 1].RowIndex <= dgv.Rows.Count)
                        {
                            foreach (var item in e.TransferAccountList)
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

                if(e.Command== OperatorCommandType.Submit
                    ||e.Command== OperatorCommandType.Edit
                    ||e.Command== OperatorCommandType.Delete)
                    CommandCenter.Instance.ResolveTransferAccount(OperatorCommandType.Reset, e.OwnerType);

                clnError.Visible = e.Command == OperatorCommandType.ErrorData;
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();

                lblTransferDetailHeaderInfo_P.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, DataConvertHelper.Instance.FormatCash(m_Amount.ToString(), false));

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
                if (AppliableFunctionType.TransferOverBankIn == value || AppliableFunctionType.TransferOverBankOut == value)
                {
                    m_AppType = value;
                    InitFieldList();
                }
            }
        }
        /// <summary>
        /// 是否有可用数据
        /// </summary>
        [Browsable(false)]
        public bool HasData
        {
            get { return dgv.Rows.Count > 0; }
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            List<TransferAccount> list = dgv.DataSource as List<TransferAccount>;
            TransferAccount tob = list[hitInfo.RowIndex];
            if (null != tob)
            {
                CommandCenter.Instance.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, m_AppType);
                CommandCenter.Instance.ResolveTransferAccount(OperatorCommandType.View, tob, m_AppType, hitInfo.RowIndex);
            }
        }

        private void InitFieldList()
        {
            bool flag = m_AppType == AppliableFunctionType.TransferOverBankOut;
            clnProtecolNo.Visible = clnBusinessType.Visible = !flag;
            clnClearBankNo.Visible = clnDateTime.Visible = flag;
            clnOperatorOrder.Visible = flag;
            //clnDateTime.Visible = flag;
            clnEmail.Visible = flag;

            clnAmount.HeaderText = flag ? MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_Amount : MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_Amount;//款金额", flag ? "付" : "收");
            clnPayeeAcount.HeaderText = flag ? MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeAccount : MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerAccount;//款人账号", flag ? "收" : "付");
            clnPayeeBankName.HeaderText = MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeBankName;//flag ? "收款清算行名" : "付款开户行名";
            clnPayeeName.HeaderText = flag ? MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeName : MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerName;//款人名称", flag ? "收" : "付");
            clnPayerAccount.HeaderText = flag ? MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayerAccount : MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayeeAccount;//string.Format("{0}款人账号", flag ? "付" : "收");
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
                        lblTransferDetailHeaderInfo_P.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, m_Amount);
                        return true;
                    }
                    else if (dr == DialogResult.Cancel) return false;
                }
                if (dgv.Rows.Count > SystemSettings.Instance.DefaultMaxCountOverBank)
                {
                    if (MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.Instance.DefaultMaxCountOverBank), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }

                List<TransferAccount> list = dgv.DataSource as List<TransferAccount>;
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
                            TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(m_AppType, list, filepath, m_Amount);
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Submit_Succeed, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            flag = true;
                            if (!isSaveOperator)
                            {
                                dgv.DataSource = null;
                                dgv.Refresh();
                                m_Amount = 0;
                                lblTransferDetailHeaderInfo_P.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, m_Amount);
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

        private double GetAmount(List<TransferAccount> list)
        {
            double d = 0.00d;
            foreach (var item in list)
            {
                d += double.Parse(item.PayAmount);
            }
            return d;
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
                (dgv.DataSource as List<TransferAccount>).ForEach(o =>
                {
                    int index = -1;
                    if (!string.IsNullOrEmpty(o.PayAmount.ToString()) && o.PayAmount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeName) && o.PayeeName.ToString().Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeAccount) && o.PayeeAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.BusinessTypeString) && o.BusinessTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeOpenBank) && o.PayeeOpenBank.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CNAPSNo) && o.CNAPSNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayerAccount) && o.PayerAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayFeeNo) && o.PayFeeNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayDatetime) && o.PayDatetime.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Addition) && o.Addition.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.TChanelString) && o.TChanelString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Email) && o.Email.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CustomerRef) && o.CustomerRef.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayerName) && o.PayerName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayingCurr) && o.PayingCurr.Contains(temp)) index = count;
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

        private void tbQueryContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTransferDetailHeader_P_Click(object sender, EventArgs e)
        {

        }
    }
}
