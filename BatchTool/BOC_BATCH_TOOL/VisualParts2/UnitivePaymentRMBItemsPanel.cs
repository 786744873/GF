using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.TemplateHelper;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class UnitivePaymentRMBItemsPanel : BaseUc
    {
        public UnitivePaymentRMBItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);

            CommandCenter.Instance.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.Instance.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnUnitivePaymentRMBEventHandler += new EventHandler<UnitivePaymentRMBEventArgs>(CommandCenter_OnUnitivePaymentRMBEventHandler);
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
                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_NoMatch_Record, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CommandCenter.Instance.ResolveUnitivePaymentRMB(OperatorCommandType.View, (dgv.DataSource as List<UnitivePaymentRMB>)[e.RowIndex], e.AppType, e.RowIndex);
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
                    if (dgv.Rows.Count >= SystemSettings.Instance.DefaultMaxCountUnitivePayment)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerBusinissNo) && o.CustomerBusinissNo == e.UnitivePaymentRMB.CustomerBusinissNo))
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Transfer_CustomerRef_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ResultData rd = DataCheckCenter.Instance.CheckAllCash(CommonInformations.Instance.BigAmountToString(e.UnitivePaymentRMB.Amount, m_AmountD, m_AmountS), 20);
                    if (!rd.Result) { MessageBoxExHelper.Instance.Show(rd.Message, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    if (e.RowIndex < 1) e.RowIndex = 1;
                    if (e.RowIndex > 0 && e.RowIndex <= dgv.Rows.Count)
                        list.Insert(e.RowIndex - 1, e.UnitivePaymentRMB);
                    else if (e.RowIndex > dgv.Rows.Count)
                        list.Add(e.UnitivePaymentRMB);
                    AddAmount(e.UnitivePaymentRMB.Amount);
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
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerBusinissNo) && o.CustomerBusinissNo == e.UnitivePaymentRMB.CustomerBusinissNo))
                    {
                        if (list[e.RowIndex - 1].CustomerBusinissNo != e.UnitivePaymentRMB.CustomerBusinissNo)
                        {
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Transfer_CustomerRef_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    ResultData rd = DataCheckCenter.Instance.CheckAllCash(AddAndReduceAmount(m_AmountD, m_AmountS, e.UnitivePaymentRMB.Amount, list[e.RowIndex - 1].Amount), 20);
                    if (!rd.Result) { MessageBoxExHelper.Instance.Show(rd.Message, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    AddAndReduceAmount(e.UnitivePaymentRMB.Amount, list[e.RowIndex - 1].Amount);
                    list[e.RowIndex - 1] = e.UnitivePaymentRMB;
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
                    if (MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_MakeSure_Delete_Record_By_ID, e.RowIndex), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    {
                        return;
                    }
                    ReduceAmount(list[e.RowIndex - 1].Amount);
                    list.RemoveAt(e.RowIndex - 1);
                    CommandCenter.Instance.ResolveUnitivePaymentRMB(OperatorCommandType.Reset, e.OwnerType);
                    #endregion
                }
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    #region
                    int max = SystemSettings.Instance.DefaultMaxCountUnitivePayment - dgv.Rows.Count;
                    List<UnitivePaymentRMB> tempList = new List<UnitivePaymentRMB>();
                    if (e.UnitivePaymentRMBList.Count > max)
                    {
                        MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.Instance.DefaultMaxCountUnitivePayment), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                    MessageBoxExHelper.Instance.Show("客户业务编号一致，合并失败", CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }

                    }
                    string amount = CommonInformations.Instance.BigAmountToString(GetAmount(tempList), m_AmountD, m_AmountS);
                    ResultData rd = DataCheckCenter.Instance.CheckAllCash(amount, 20);
                    if (!rd.Result) { MessageBoxExHelper.Instance.Show(rd.Message, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
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
                    if (e.UnitivePaymentRMBList.Count > SystemSettings.Instance.DefaultMaxCountUnitivePayment)
                    {
                        MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.Instance.DefaultMaxCountUnitivePayment), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        list = e.UnitivePaymentRMBList.GetRange(0, SystemSettings.Instance.DefaultMaxCountUnitivePayment);
                    }
                    else list = e.UnitivePaymentRMBList;
                    string amount = GetAmount(list);
                    ResultData rd = DataCheckCenter.Instance.CheckAllCash(CommonInformations.Instance.BigAmountToString(amount, m_AmountD, m_AmountS), 20);
                    if (!rd.Result) { MessageBoxExHelper.Instance.Show(rd.Message, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
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
                    CommandCenter.Instance.ResolveUnitivePaymentRMB(OperatorCommandType.Reset, e.OwnerType);

                clnError.Visible = e.Command == OperatorCommandType.ErrorData;
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();

                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, DataConvertHelper.Instance.FormatCash(AddAmount(m_AmountD, m_AmountS, "0.00"), false));

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
                CommandCenter.Instance.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, m_AppType);
                CommandCenter.Instance.ResolveUnitivePaymentRMB(OperatorCommandType.View, tob, m_AppType, hitInfo.RowIndex);
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
                        m_AmountD = 0;
                        m_AmountS = 0.0d;
                        lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, 0);
                        return true;
                    }
                    else if (dr == DialogResult.Cancel) return false;
                }
                if (dgv.Rows.Count > SystemSettings.Instance.DefaultMaxCountOverBank)
                {
                    if (MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.Instance.DefaultMaxCountOverBank), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }

                List<UnitivePaymentRMB> list = dgv.DataSource as List<UnitivePaymentRMB>;
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
                            TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(m_AppType, list, filepath, CommonInformations.Instance.BigAmountToString("0.00", m_AmountD, m_AmountS));
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Submit_Succeed, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            flag = true;
                            if (!isSaveOperator)
                            {
                                dgv.DataSource = null;
                                dgv.Refresh();
                                m_AmountD = 0;
                                m_AmountS = 0.0d;
                                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount_And_AllAmount, dgv.Rows.Count, 0);
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
                        m_AmountS += double.Parse(string.Format("0.{0}",str[1])) * -1;
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
                    if (!string.IsNullOrEmpty(o.NominalPayerBankLinkNo) && o.NominalPayerBankLinkNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.NominalPayerName) && o.NominalPayerName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.NominalPayerOpenBankName) && o.NominalPayerOpenBankName.Contains(temp)) index = count;
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
