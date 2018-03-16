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
    public partial class ElecTicketPoolItemsPanel : BaseUc
    {
        public ElecTicketPoolItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.OnElecTicketPoolEventHandler += new EventHandler<ElecTicketPoolEventArgs>(CommandCenter_OnElecTicketPoolEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
        }

        void ChangeUIStyle()
        {
            lblTransferDetailHeader_P.Location = new Point { X = lblTransferDetailHeader_P.Location.X + this.Width - 925, Y = lblTransferDetailHeader_P.Location.Y };
            tbQueryContent.Location = new Point { X = tbQueryContent.Location.X + this.Width - 925, Y = tbQueryContent.Location.Y };
            btnQuery.Location = new Point { X = btnQuery.Location.X + this.Width - 925, Y = btnQuery.Location.Y };
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(ElecTicketPoolItemsPanel), this);
                ChangeUIStyle();
            }
        }

        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.ElecTicketPool) return;
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

        void CommandCenter_OnQueryByRowIndexEventHandler(object sender, QueryByRowIndexEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.AppType != AppliableFunctionType.ElecTicketPool) return;
                if (e.RowIndex < 0 || e.RowIndex > dgv.Rows.Count || dgv.Rows.Count == 0)
                {
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_NoMatch_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    return;
                }
                ElecTicketPool ta = new ElecTicketPool();
                ta = (dgv.DataSource as List<ElecTicketPool>)[e.RowIndex];
                CommandCenter.ResolveElecTicketPool(OperatorCommandType.View, ta, e.AppType, e.RowIndex);
            }
        }

        void CommandCenter_OnElecTicketPoolEventHandler(object sender, ElecTicketPoolEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketPoolEventArgs>(CommandCenter_OnElecTicketPoolEventHandler), sender, e); }
            else
            {
                if (AppliableFunctionType.ElecTicketPool != e.OwnerType) return;
                List<ElecTicketPool> list = new List<ElecTicketPool>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<ElecTicketPool>;
                #region submit
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (dgv.Rows.Count >= SystemSettings.DefaultMaxCountElecTicketPool)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerRef) && o.CustomerRef == e.ElecTicketPool.CustomerRef))
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.ElecTicketPool_CustomerRef_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //if (e.RowIndex < 1) e.RowIndex = 1;
                    //if (e.RowIndex > 0 && e.RowIndex <= dgv.Rows.Count)
                    //    list.Insert(e.RowIndex - 1, e.ElecTicketPool);
                    //else if (e.RowIndex > dgv.Rows.Count)
                    list.Add(e.ElecTicketPool);
                    AddAmount(e.ElecTicketPool.Amount);
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
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerRef) && o.CustomerRef == e.ElecTicketPool.CustomerRef))
                    {
                        if (list[e.RowIndex - 1].CustomerRef != e.ElecTicketPool.CustomerRef)
                        {
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.ElecTicketPool_CustomerRef_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    AddAndReduceAmount(e.ElecTicketPool.Amount, list[e.RowIndex - 1].Amount);
                    list[e.RowIndex - 1] = e.ElecTicketPool;
                }
                #endregion
                #region CombeData
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    int max = SystemSettings.DefaultMaxCountElecTicketPool - dgv.Rows.Count;
                    List<ElecTicketPool> tempList = new List<ElecTicketPool>();
                    if (e.ElecTicketPoolList.Count > max)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, max), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        tempList = e.ElecTicketPoolList.GetRange(0, max);
                    }
                    else tempList = e.ElecTicketPoolList;
                    //ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + amount, 15);
                    //if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    list.AddRange(tempList);
                    string amount = CommonInformations.BigAmountToString(GetAmount(tempList), m_AmountD, m_AmountS);
                    string[] str = amount.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    m_AmountD = long.Parse(str[0]);
                    m_AmountS = double.Parse(string.Format("0.{0}", str[1]));
                }
                #endregion
                #region Open
                else if (OperatorCommandType.Open == e.Command)
                {
                    if (e.ElecTicketPoolList.Count > SystemSettings.DefaultMaxCountElecTicketPool)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.DefaultMaxCountElecTicketPool), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        list = e.ElecTicketPoolList.GetRange(0, SystemSettings.DefaultMaxCountElecTicketPool);
                    }
                    else list = e.ElecTicketPoolList;
                    //ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + GetAmount(list), 15);
                    //if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    string amount = GetAmount(list);
                    string[] str = amount.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    m_AmountD = long.Parse(str[0]);
                    m_AmountS = double.Parse(string.Format("0.{0}", str[1]));
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
                    ReduceAmount(list[dgv.SelectedRows[0].Index].Amount);
                    list.RemoveAt(dgv.SelectedRows[0].Index);
                }
                #endregion
                #region ErrorData
                else if (OperatorCommandType.ErrorData == e.Command)
                {
                    if (e.ElecTicketPoolList != null && e.ElecTicketPoolList.Count > 0)
                    {
                        if (e.ElecTicketPoolList[e.ElecTicketPoolList.Count - 1].RowIndex <= dgv.Rows.Count)
                        {
                            foreach (var item in e.ElecTicketPoolList)
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
                    ElecTicketPool ae = list[selectedindex];
                    list.RemoveAt(selectedindex);
                    list.Insert(selectedindex + moveindex, ae);
                    dgv.CurrentCell = dgv.Rows[selectedindex + moveindex].Cells[0];
                    #endregion
                }
                else if (e.Command == OperatorCommandType.Reset) return;

                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();
                if (e.Command == OperatorCommandType.Submit)
                    dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];
                clnError.Visible = OperatorCommandType.ErrorData == e.Command;
                querycontent = string.Empty;
                indexList.Clear();
                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, list.Count, DataConvertHelper.FormatCash(AddAmount(m_AmountD, m_AmountS, "0.00"), false));

                if (e.Command == OperatorCommandType.Submit
                    || e.Command == OperatorCommandType.Edit
                    || e.Command == OperatorCommandType.Delete)
                    CommandCenter.ResolveElecTicketPool(OperatorCommandType.Reset, e.OwnerType);
            }
        }

        //private double m_Amount = 0.00d;
        long m_AmountD = 0;
        double m_AmountS = 0.00d;
        string querycontent = string.Empty;
        List<int> indexList = new List<int>();

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
                m_ElecTicketType = value;
                Init();
            }
        }
        /// <summary>
        /// 是否有可用数据
        /// </summary>
        [Browsable(false)]
        public bool HasData
        {
            get { return dgv.DataSource != null && dgv.Rows.Count > 0; }
        }

        void Init()
        {
            clnExchangeName.HeaderText = MultiLanguageConvertHelper.ElecTicketPool_ExchangeName + "/" + MultiLanguageConvertHelper.ElecTicketPool_ExchangeBankName;
            clnExchangeBankNo.HeaderText = MultiLanguageConvertHelper.ElecTicketPool_ExchangeOpenBankNo + "/" + MultiLanguageConvertHelper.ElecTicketPool_ExchangeBankNo;
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (hitInfo.RowIndex < 0) return;

            ElecTicketPool transfer = (dgv.DataSource as List<ElecTicketPool>)[hitInfo.RowIndex];
            if (null != transfer)
            {
                CommandCenter.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, AppliableFunctionType.ElecTicketPool);
                CommandCenter.ResolveElecTicketPool(OperatorCommandType.View, transfer, AppliableFunctionType._Empty, hitInfo.RowIndex);
            }
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
                        m_AmountD = 0;
                        m_AmountS = 0.0d;
                        lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, 0, 0);
                        return true;
                    }
                    else if (dr == DialogResult.No)
                    {
                        LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.ElecTicketPool, true);
                        return false;
                    }
                    else if (dr == DialogResult.Cancel) return false;
                }
                if (dgv.Rows.Count > SystemSettings.DefaultMaxCountElecTicketPool)
                {
                    if (MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.DefaultMaxCountElecTicketPool), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }

                List<ElecTicketPool> list = dgv.DataSource as List<ElecTicketPool>;
                string messageStr = MatchFile.MatchFileDataHelper.CheckDataAvilidHigh(list, AppliableFunctionType.ElecTicketPool);
                if (!string.IsNullOrEmpty(messageStr))
                {
                    MessageBoxPrime.Show(messageStr, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    flag = false;
                }
                else
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT);
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filepath = DataConvertHelper.FormatFileName(saveFileDialog.FileName, ".txt");
                        try
                        {
                            TemplateHelper.BatchConsignDataTemplateHelper.CreateTxtDocument(AppliableFunctionType.ElecTicketPool, list, filepath, CommonInformations.BigAmountToString("0.00", m_AmountD, m_AmountS));
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Save_Succed_Please_Next, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                            flag = true;

                            dgv.DataSource = null;
                            dgv.Refresh();
                            m_AmountD = 0;
                            m_AmountS = 0.0d;
                            lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, 0, 0);

                        }
                        catch
                        {
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeFile_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (saveFileDialog != null)
                        saveFileDialog.Dispose();
                }
            }
            else flag = true;
            return flag;
        }

        private string GetAmount(List<ElecTicketPool> list)
        {
            string result = string.Empty;
            long d = 0;
            double s = 0.0d;
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.Amount))
                {
                    string[] str = item.Amount.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length >= 1)
                    {
                        d += long.Parse(str[0]);
                    }
                    if (str.Length >= 2)
                    {
                        s += double.Parse(string.Format("0.{0}", str[1]));
                    }
                }
            }
            d += (int)s;
            int index = s.ToString("0.00").IndexOf('.');
            result = string.Format("{0}{1}", d, s.ToString("0.00").Substring(index, 3));
            return result;
        }

        string AddAmount(long amountd, double amounts, string amount)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(amount))
            {
                string[] str = amount.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length >= 1)
                {
                    amountd += long.Parse(str[0]);
                }
                if (str.Length >= 2)
                {
                    amounts += double.Parse(string.Format("0.{0}", str[1]));
                }
            }
            amountd += (int)amounts;
            int index = amounts.ToString("0.00").IndexOf('.');
            result = string.Format("{0}{1}", amountd, amounts.ToString("0.00").Substring(index, 3));
            return result;
        }

        void AddAmount(string amount)
        {
            if (!string.IsNullOrEmpty(amount))
            {
                string[] str = amount.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length >= 1)
                {
                    m_AmountD += long.Parse(str[0]);
                }
                if (str.Length >= 2)
                {
                    m_AmountS += double.Parse(string.Format("0.{0}", str[1]));
                }
            }
        }

        string ReduceAmount(long amountd, double amounts, string amount)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(amount))
            {
                if (!string.IsNullOrEmpty(amount))
                {
                    string[] str = amount.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length >= 1)
                    {
                        amountd += long.Parse(str[0]) * -1;
                    }
                    if (str.Length >= 2)
                    {
                        amounts += double.Parse(string.Format("0.{0}", str[1])) * -1;
                    }
                }
            }
            while (amounts < 0)
            {
                amountd--;
                amounts += 1.00d;
            }
            amountd += (int)amounts;
            int index = amounts.ToString("0.00").IndexOf('.');
            result = string.Format("{0}{1}", amountd, amounts.ToString("0.00").Substring(index, 3));
            return result;
        }

        void ReduceAmount(string amount)
        {
            if (!string.IsNullOrEmpty(amount))
            {
                if (!string.IsNullOrEmpty(amount))
                {
                    string[] str = amount.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length >= 1)
                    {
                        m_AmountD += long.Parse(str[0]) * -1;
                    }
                    if (str.Length >= 2)
                    {
                        m_AmountS += double.Parse(string.Format("0.{0}", str[1])) * -1;
                    }
                }
            }
            while (m_AmountS < 0)
            {
                m_AmountD--;
                m_AmountS += 1.00d;
            }
        }

        string AddAndReduceAmount(long amountd, double amounts, string amounta, string amountr)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(amounta))
            {
                if (!string.IsNullOrEmpty(amounta))
                {
                    string[] str = amounta.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length >= 1)
                    {
                        amountd += long.Parse(str[0]);
                    }
                    if (str.Length >= 2)
                    {
                        amounts += double.Parse(string.Format("0.{0}", str[1]));
                    }
                }
            }
            if (!string.IsNullOrEmpty(amountr))
            {
                if (!string.IsNullOrEmpty(amountr))
                {
                    string[] str = amountr.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length >= 1)
                    {
                        amountd += long.Parse(str[0]) * -1;
                    }
                    if (str.Length >= 2)
                    {
                        amounts += double.Parse(string.Format("0.{0}", str[1])) * -1;
                    }
                }
            }
            while (amounts < 0)
            {
                amountd -= 10;
                amounts += 10.00d;
            }
            amountd += (int)amounts;
            int index = amounts.ToString("0.00").IndexOf('.');
            result = string.Format("{0}{1}", amountd, amounts.ToString("0.00").Substring(index, 3));
            return result;
        }

        void AddAndReduceAmount(string amounta, string amountr)
        {
            if (!string.IsNullOrEmpty(amounta))
            {
                if (!string.IsNullOrEmpty(amounta))
                {
                    string[] str = amounta.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length >= 1)
                    {
                        m_AmountD += long.Parse(str[0]);
                    }
                    if (str.Length >= 2)
                    {
                        m_AmountS += double.Parse(string.Format("0.{0}", str[1]));
                    }
                }
            }
            if (!string.IsNullOrEmpty(amountr))
            {
                if (!string.IsNullOrEmpty(amountr))
                {
                    string[] str = amountr.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length >= 1)
                    {
                        m_AmountD += long.Parse(str[0]) * -1;
                    }
                    if (str.Length >= 2)
                    {
                        m_AmountS += double.Parse(string.Format("0.{0}", str[1])) * -1;
                    }
                }
            }
            while (m_AmountS < 0)
            {
                m_AmountD -= 10;
                m_AmountS += 10.00d;
            }
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
                bool flag = clnError.Visible;
                (dgv.DataSource as List<ElecTicketPool>).ForEach(o =>
                {
                    int index = -1;
                    if (!string.IsNullOrEmpty(o.Amount.ToString()) && o.Amount.Contains(temp)) index = count;
                    if (flag && !string.IsNullOrEmpty(o.ErrorReason) && o.ErrorReason.Contains(temp)) index = count;
                    if (m_ElecTicketType == ElecTicketType.AC01 && !string.IsNullOrEmpty(o.BankTypeString) && o.BankTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.BusinessTypeString) && o.BusinessTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CustomerRef) && o.CustomerRef.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ElecTicketSerialNo) && o.ElecTicketSerialNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ElecTicketTypeString) && o.ElecTicketTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.EndDate) && o.EndDate.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.EndDateOperateString) && o.EndDateOperateString.Contains(temp)) index = count;
                    if (m_ElecTicketType == ElecTicketType.AC02 && !string.IsNullOrEmpty(o.ExchangeAccount) && o.ExchangeAccount.Contains(temp)) index = count;
                    if (m_ElecTicketType == ElecTicketType.AC02 && !string.IsNullOrEmpty(o.ExchangeBankName) && o.ExchangeBankName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ExchangeBankNo) && o.ExchangeBankNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ExchangeDate) && o.ExchangeDate.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ExchangeName) && o.ExchangeName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeAccount) && o.PayeeAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeName) && o.PayeeName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeOpenBankName) && o.PayeeOpenBankName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeOpenBankNo) && o.PayeeOpenBankNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PreBackNotedPerson) && o.PreBackNotedPerson.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.RemitAccount) && o.RemitAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.RemitDate) && o.RemitDate.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.RemitName) && o.RemitName.Contains(temp)) index = count;
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
    }
}
