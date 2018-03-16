using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.EnumTypes;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class ElecTicketPayMoneyItemsPanel : BaseUc
    {
        public ElecTicketPayMoneyItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            CommandCenter.Instance.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.Instance.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.Instance.OnElecTicketPayMoneyEventHandler += new EventHandler<ElecTicketPayMoneyEventArgs>(CommandCenter_OnElecTicketPayMoneyEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
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
                base.ApplyResource(typeof(ElecTicketPayMoneyItemsPanel), this);
                ChangeUIStyle();
            }
        }

        void CommandCenter_OnElecTicketPayMoneyEventHandler(object sender, ElecTicketPayMoneyEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketPayMoneyEventArgs>(CommandCenter_OnElecTicketPayMoneyEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.OwnerType) return;
                List<ElecTicketPayMoney> list = new List<ElecTicketPayMoney>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<ElecTicketPayMoney>;
                if (OperatorCommandType.Submit == e.Command)
                {
                    #region
                    if (dgv.Rows.Count >= SystemSettings.Instance.DefaultMaxCountElecTicket)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (e.RowIndex < 1) e.RowIndex = 1;
                    if (e.RowIndex > 0 && e.RowIndex <= dgv.Rows.Count)
                        list.Insert(e.RowIndex - 1, e.ElecTicketPayMoney);
                    else if (e.RowIndex > dgv.Rows.Count)
                        list.Add(e.ElecTicketPayMoney);
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
                    list[e.RowIndex - 1] = e.ElecTicketPayMoney;
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
                    #endregion
                }
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    #region
                    int max = SystemSettings.Instance.DefaultMaxCountElecTicket - dgv.Rows.Count;
                    List<ElecTicketPayMoney> tempList = new List<ElecTicketPayMoney>();
                    if (e.ElecTicketPayMoneyList.Count > max)
                    {
                        MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Only_View_Some_Record, max), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tempList = e.ElecTicketPayMoneyList.GetRange(0, max);
                    }
                    else tempList = e.ElecTicketPayMoneyList;
                    list.AddRange(tempList);
                    #endregion
                }
                else if (OperatorCommandType.Open == e.Command)
                {
                    #region
                    if (e.ElecTicketPayMoneyList.Count > SystemSettings.Instance.DefaultMaxCountElecTicket)
                    {
                        MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.Instance.DefaultMaxCountElecTicket), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        list = e.ElecTicketPayMoneyList.GetRange(0, SystemSettings.Instance.DefaultMaxCountElecTicket);
                    }
                    else list = e.ElecTicketPayMoneyList;
                    #endregion
                }
                else if (OperatorCommandType.ErrorData == e.Command)
                {
                    #region
                    if (e.ElecTicketPayMoneyList != null && e.ElecTicketPayMoneyList.Count > 0)
                    {
                        if (e.ElecTicketPayMoneyList[e.ElecTicketPayMoneyList.Count - 1].RowIndex <= dgv.Rows.Count)
                        {
                            foreach (var item in e.ElecTicketPayMoneyList)
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
                    #endregion
                }
                else return;

                if(e.Command== OperatorCommandType.Submit
                    ||e.Command== OperatorCommandType.Edit
                    ||e.Command== OperatorCommandType.Delete)
                    CommandCenter.Instance.ResolveElecTicketPayMoney(OperatorCommandType.Reset, e.OwnerType);

                clnError.Visible = e.Command == OperatorCommandType.ErrorData;
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[0].Value = i + 1;
                }

                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount, dgv.Rows.Count);
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
                CommandCenter.Instance.ResolveElecTicketPayMoney(OperatorCommandType.View, (dgv.DataSource as List<ElecTicketPayMoney>)[e.RowIndex], e.AppType, e.RowIndex);
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

        string querycontent = string.Empty;
        List<int> indexList = new List<int>();

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

            List<ElecTicketPayMoney> list = dgv.DataSource as List<ElecTicketPayMoney>;
            ElecTicketPayMoney etpm = list[hitInfo.RowIndex];
            if (null != etpm)
            {
                CommandCenter.Instance.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, m_AppType);
                CommandCenter.Instance.ResolveElecTicketPayMoney(OperatorCommandType.View, etpm, m_AppType, hitInfo.RowIndex);
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
                        lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount, dgv.Rows.Count);
                        return true;
                    }
                    else if (dr == DialogResult.Cancel) return false;
                }
                if (dgv.Rows.Count > SystemSettings.Instance.DefaultMaxCountOverBank)
                {
                    if (MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.Instance.DefaultMaxCountOverBank), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }

                List<ElecTicketPayMoney> list = dgv.DataSource as List<ElecTicketPayMoney>;
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
                                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount, dgv.Rows.Count);
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
                (dgv.DataSource as List<ElecTicketPayMoney>).ForEach(o =>
                {
                    int index = -1;
                    if (!string.IsNullOrEmpty(o.BillSerialNo) && o.BillSerialNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ClearTypeString) && o.ClearTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ContractNo) && o.ContractNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ElecTicketSerialNo) && o.ElecTicketSerialNo.Contains(temp)) index = count;
                    if (clnError.Visible && !string.IsNullOrEmpty(o.ErrorReason) && o.ErrorReason.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Note) && o.Note.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayMoneyAccount) && o.PayMoneyAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayMoneyDate) && o.PayMoneyDate.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayMoneyOpenBankName) && o.PayMoneyOpenBankName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayMoneyOpenBankNo) && o.PayMoneyOpenBankNo.ToString().Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayMoneyPercent.ToString()) && o.PayMoneyPercent.ToString().Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayMoneyType) && o.PayMoneyType.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.RemitAccount) && o.RemitAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.StickOnAccount) && o.StickOnAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.StickOnName) && o.StickOnName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.StickOnOpenBankName) && o.StickOnOpenBankName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.StickOnOpenBankNo) && o.StickOnOpenBankNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ProtocolMoneyTypeString) && o.ProtocolMoneyTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ProtocolMoneyPercentString) && o.ProtocolMoneyPercentString.Contains(temp)) index = count;
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
