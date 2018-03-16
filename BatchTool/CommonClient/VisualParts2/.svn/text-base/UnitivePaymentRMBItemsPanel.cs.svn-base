using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient.Utilities;
using CommonClient.VisualParts;
using CommonClient.TemplateHelper;

namespace CommonClient.VisualParts2
{
    public partial class UnitivePaymentRMBItemsPanel : BaseUc
    {
        public UnitivePaymentRMBItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);

            CommandCenter.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnUnitivePaymentRMBEventHandler += new EventHandler<UnitivePaymentRMBEventArgs>(CommandCenter_OnUnitivePaymentRMBEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(UnitivePaymentRMBItemsPanel), this);
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
                CommandCenter.ResolveUnitivePaymentRMB(OperatorCommandType.View, (dgv.DataSource as List<UnitivePaymentRMB>)[e.RowIndex], e.AppType, e.RowIndex);
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

        //private double m_Amount = 0.00d;
        long m_AmountD = 0;
        double m_AmountS = 0.00d;
        string querycontent = string.Empty;
        List<int> indexList = new List<int>();

        void CommandCenter_OnUnitivePaymentRMBEventHandler(object sender, UnitivePaymentRMBEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<UnitivePaymentRMBEventArgs>(CommandCenter_OnUnitivePaymentRMBEventHandler), new object[] { sender, e }); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                List<UnitivePaymentRMB> list = new List<UnitivePaymentRMB>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<UnitivePaymentRMB>;
                if (OperatorCommandType.Submit == e.Command)
                {
                    #region
                    if (dgv.Rows.Count >= SystemSettings.DefaultMaxCountUnitivePayment)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerBusinissNo) && o.CustomerBusinissNo == e.UnitivePaymentRMB.CustomerBusinissNo))
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.Transfer_CustomerRef_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ResultData rd = DataCheckCenter.CheckAllCash(CommonInformations.BigAmountToString(e.UnitivePaymentRMB.Amount, m_AmountD, m_AmountS), 20);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    //if (e.RowIndex < 1) e.RowIndex = 1;
                    //if (e.RowIndex > 0 && e.RowIndex <= dgv.Rows.Count)
                    //    list.Insert(e.RowIndex - 1, e.UnitivePaymentRMB);
                    //else if (e.RowIndex > dgv.Rows.Count)
                    list.Add(e.UnitivePaymentRMB);
                    AddAmount(e.UnitivePaymentRMB.Amount);
                    #endregion
                }
                else if (OperatorCommandType.Edit == e.Command)
                {
                    #region
                    if (e.RowIndex < 1 || e.RowIndex > dgv.Rows.Count)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Record_Not_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (null == list) return;
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerBusinissNo) && o.CustomerBusinissNo == e.UnitivePaymentRMB.CustomerBusinissNo))
                    {
                        if (list[e.RowIndex - 1].CustomerBusinissNo != e.UnitivePaymentRMB.CustomerBusinissNo)
                        {
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Transfer_CustomerRef_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    ResultData rd = DataCheckCenter.CheckAllCash(AddAndReduceAmount(m_AmountD, m_AmountS, e.UnitivePaymentRMB.Amount, list[e.RowIndex - 1].Amount), 20);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    AddAndReduceAmount(e.UnitivePaymentRMB.Amount, list[e.RowIndex - 1].Amount);
                    list[e.RowIndex - 1] = e.UnitivePaymentRMB;
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
                    ReduceAmount(list[dgv.SelectedRows[0].Index ].Amount);
                    list.RemoveAt(dgv.SelectedRows[0].Index );
                    #endregion
                }
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    #region
                    int max = SystemSettings.DefaultMaxCountUnitivePayment - dgv.Rows.Count;
                    List<UnitivePaymentRMB> tempList = new List<UnitivePaymentRMB>();
                    if (e.UnitivePaymentRMBList.Count > max)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, max), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        tempList = e.UnitivePaymentRMBList.GetRange(0, max);
                    }
                    else tempList = e.UnitivePaymentRMBList;
                    if (m_AppType == AppliableFunctionType.UnitivePaymentRMB)
                    {
                        string CustomerNo = string.Empty;
                        if (dgv.RowCount > 0)
                        {
                            for (int i = 0; i < dgv.RowCount; i++)
                            {
                                CustomerNo = (dgv.DataSource as List<UnitivePaymentRMB>)[i].CustomerBusinissNo;
                                if (tempList.Exists(o => (!string.IsNullOrEmpty(o.CustomerBusinissNo) && !string.IsNullOrEmpty(CustomerNo) && o.CustomerBusinissNo == CustomerNo)))
                                {
                                    MessageBoxPrime.Show("客户业务编号一致，合并失败", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }

                    }
                    string amount = CommonInformations.BigAmountToString(GetAmount(tempList), m_AmountD, m_AmountS);
                    ResultData rd = DataCheckCenter.CheckAllCash(amount, 20);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    clnError.Visible = false;
                    string[] str = amount.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    m_AmountD = long.Parse(str[0]);
                    m_AmountS = double.Parse(string.Format("0.{0}", str[1]));
                    list.AddRange(tempList);
                    #endregion
                }
                else if (OperatorCommandType.Open == e.Command)
                {
                    #region
                    if (e.UnitivePaymentRMBList.Count > SystemSettings.DefaultMaxCountUnitivePayment)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.DefaultMaxCountUnitivePayment), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        list = e.UnitivePaymentRMBList.GetRange(0, SystemSettings.DefaultMaxCountUnitivePayment);
                    }
                    else list = e.UnitivePaymentRMBList;
                    string amount = GetAmount(list);
                    ResultData rd = DataCheckCenter.CheckAllCash(CommonInformations.BigAmountToString(amount, m_AmountD, m_AmountS), 20);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    string[] str = amount.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    m_AmountD = long.Parse(str[0]);
                    m_AmountS = double.Parse(string.Format("0.{0}", str[1]));
                    clnError.Visible = false;
                    #endregion
                }
                else if (OperatorCommandType.ErrorData == e.Command)
                {
                    #region
                    if (e.UnitivePaymentRMBList != null && e.UnitivePaymentRMBList.Count > 0)
                    {
                        if (e.UnitivePaymentRMBList[e.UnitivePaymentRMBList.Count - 1].RowIndex <= dgv.Rows.Count)
                        {
                            foreach (var item in e.UnitivePaymentRMBList)
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
                    clnError.Visible = true;
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
                    UnitivePaymentRMB ae = list[selectedindex];
                    list.RemoveAt(selectedindex);
                    list.Insert(selectedindex + moveindex, ae);
                    dgv.CurrentCell = dgv.Rows[selectedindex + moveindex].Cells[0];
                    #endregion
                }
                else if (OperatorCommandType.Reset == e.Command) return;

                clnError.Visible = e.Command == OperatorCommandType.ErrorData;
                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();
                if (e.Command == OperatorCommandType.Submit)
                    dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];
                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, DataConvertHelper.FormatCash(AddAmount(m_AmountD, m_AmountS, "0.00"), false));

                if (e.Command == OperatorCommandType.Submit
                    || e.Command == OperatorCommandType.Edit
                    || e.Command == OperatorCommandType.Delete)
                    CommandCenter.ResolveUnitivePaymentRMB(OperatorCommandType.Reset, e.OwnerType);
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

            List<UnitivePaymentRMB> list = dgv.DataSource as List<UnitivePaymentRMB>;
            UnitivePaymentRMB tob = list[hitInfo.RowIndex];
            if (null != tob)
            {
                CommandCenter.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, m_AppType);
                CommandCenter.ResolveUnitivePaymentRMB(OperatorCommandType.View, tob, m_AppType, hitInfo.RowIndex);
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
                        lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, 0);
                        return true;
                    }
                    else if (dr == DialogResult.No)
                    {
                        LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, m_AppType, true);
                        return false;
                    }
                    else if (dr == DialogResult.Cancel) return false;
                }
                if (dgv.Rows.Count > SystemSettings.DefaultMaxCountOverBank)
                {
                    if (MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.DefaultMaxCountOverBank), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }

                List<UnitivePaymentRMB> list = dgv.DataSource as List<UnitivePaymentRMB>;
                string messageStr = MatchFile.MatchFileDataHelper.CheckDataAvilidHigh(list, m_AppType);
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
                            TemplateHelper.BatchConsignDataTemplateHelper.CreateTxtDocument(m_AppType, list, filepath, CommonInformations.BigAmountToString("0.00", m_AmountD, m_AmountS));
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Save_Succed_Please_Next, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                            flag = true;
                            //if (!isSaveOperator)
                            //{
                                dgv.DataSource = null;
                                dgv.Refresh();
                                m_AmountD = 0;
                                m_AmountS = 0.0d;
                                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, 0);
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

        private string GetAmount(List<UnitivePaymentRMB> list)
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
                (dgv.DataSource as List<UnitivePaymentRMB>).ForEach(o =>
                {
                    int index = -1;
                    if (!string.IsNullOrEmpty(o.Amount.ToString()) && o.Amount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeName) && o.PayeeName.ToString().Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeAccount) && o.PayeeAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.BankTypeString) && o.BankTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CustomerBusinissNo) && o.CustomerBusinissNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.IsTipPayeeString) && o.IsTipPayeeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayerAccount) && o.PayerAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayerName) && o.PayerName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.NominalPayerAccount) && o.NominalPayerAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.NominalPayerName) && o.NominalPayerName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.OrderPayDate) && o.OrderPayDate.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeCNAPS) && o.PayeeCNAPS.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeOpenBankName) && o.PayeeOpenBankName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Purpose) && o.Purpose.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.TipPayeePhone) && o.TipPayeePhone.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.TransferChanelTypeString) && o.TransferChanelTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.UnitivePaymentTypeString) && o.UnitivePaymentTypeString.Contains(temp)) index = count;
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
