using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.Entities;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.EnumTypes;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class SpplyFinancingBillItemsPanel : BaseUc
    {
        public SpplyFinancingBillItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            CommandCenter.Instance.OnSpplyFinancingBillEventHandler += new EventHandler<SpplyFinancingBillEventArgs>(CommandCenter_OnSpplyFinancingBillEventHandler);
            CommandCenter.Instance.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.Instance.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
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
                base.ApplyResource(typeof(SpplyFinancingBillItemsPanel), this);
                Init();
                ChangeUIStyle();
            }
        }

        void CommandCenter_OnSpplyFinancingBillEventHandler(object sender, SpplyFinancingBillEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SpplyFinancingBillEventArgs>(CommandCenter_OnSpplyFinancingBillEventHandler), new object[] { sender, e }); }
            else
            {
                if (AppType != e.OwnerType) return;
                List<SpplyFinancingBill> list = new List<SpplyFinancingBill>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<SpplyFinancingBill>;
                #region submit
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (dgv.Rows.Count >= SystemSettings.Instance.DefaultMaxCountSpplyFinancing)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (list.Exists(o => o.BillSerialNo == e.SpplyFinancingBill.BillSerialNo && !string.IsNullOrEmpty(e.SpplyFinancingBill.BillSerialNo)))
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillSerialNo_Exist_Add_Failed, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (e.RowIndex < 1) e.RowIndex = 1;
                    if (e.RowIndex > 0 && e.RowIndex <= dgv.Rows.Count)
                        list.Insert(e.RowIndex - 1, e.SpplyFinancingBill);
                    else if (e.RowIndex > dgv.Rows.Count)
                        list.Add(e.SpplyFinancingBill);
                }
                #endregion
                #region edit
                else if (OperatorCommandType.Edit == e.Command)
                {
                    if (e.RowIndex < 1 || e.RowIndex > list.Count)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Record_Not_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int index = list.FindIndex(o => o.BillSerialNo == e.SpplyFinancingBill.BillSerialNo && !string.IsNullOrEmpty(e.SpplyFinancingBill.BillSerialNo));
                    if (index >= 0 && index != e.RowIndex - 1)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillSerialNo_Exist_Edit_Failed, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    list[e.RowIndex - 1] = e.SpplyFinancingBill;
                }
                #endregion
                #region CombeData
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    List<SpplyFinancingBill> tempList = new List<SpplyFinancingBill>();
                    int max = SystemSettings.Instance.DefaultMaxCountSpplyFinancing - dgv.Rows.Count;
                    if (e.SpplyFinancingBillList.Count > max)
                    {
                        MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Only_View_Some_Record, max), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tempList = e.SpplyFinancingBillList.GetRange(0, max);
                    }
                    else tempList = e.SpplyFinancingBillList;
                    list.AddRange(tempList.FindAll(o => !list.Exists(p => p.BillSerialNo == o.BillSerialNo && !string.IsNullOrEmpty(o.BillSerialNo))));
                }
                #endregion
                #region Open
                else if (OperatorCommandType.Open == e.Command)
                {
                    if (e.SpplyFinancingBillList.Count > SystemSettings.Instance.DefaultMaxCountSpplyFinancing)
                    {
                        MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.Instance.DefaultMaxCountSpplyFinancing), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        list = e.SpplyFinancingBillList.GetRange(0, SystemSettings.Instance.DefaultMaxCountSpplyFinancing);
                    }
                    else list = e.SpplyFinancingBillList;
                }
                #endregion
                #region delete
                else if (OperatorCommandType.Delete == e.Command)
                {
                    if (e.RowIndex < 1 || e.RowIndex > list.Count)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Record_Not_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_MakeSure_Delete_Record_By_ID, e.RowIndex), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
                    list.RemoveAt(e.RowIndex - 1);
                }
                #endregion
                else if (OperatorCommandType.Reset == e.Command) return;

                if(e.Command== OperatorCommandType.Submit
                    ||e.Command== OperatorCommandType.Edit
                    ||e.Command== OperatorCommandType.Delete)
                    CommandCenter.Instance.ResolveSpplyFinancingBill(OperatorCommandType.Reset, e.OwnerType);

                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();

                querycontent = string.Empty;
                indexList.Clear();

                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Gather_AllCount, list.Count);
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[0].Value = i + 1;
                }
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
                CommandCenter.Instance.ResolveSpplyFinancingBill(OperatorCommandType.View, (dgv.DataSource as List<SpplyFinancingBill>)[e.RowIndex], e.AppType, e.RowIndex);
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

        /// <summary>
        /// 操作功能类型
        /// SpplyFinancingBillIn-快捷代收,SpplyFinancingBillOut-快捷代发
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.BillofDebtReceivablePurchaser == value || AppliableFunctionType.BillofDebtReceivableSeller == value)
                {
                    m_AppType = value;
                    Init();
                }
            }
        }
        private AppliableFunctionType m_AppType = AppliableFunctionType._Empty;
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

        void Init()
        {
            if (m_AppType == AppliableFunctionType.BillofDebtReceivablePurchaser)
            {
                clnCustomerNo.HeaderText = MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Seller;
                clnCustomerName.HeaderText = MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Seller;
            }
            else if (m_AppType == AppliableFunctionType.BillofDebtReceivableSeller)
            {
                clnCustomerNo.HeaderText = MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Purchase;
                clnCustomerName.HeaderText = MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Purchase;
            }
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            SpplyFinancingBill ae = (dgv.DataSource as List<SpplyFinancingBill>)[hitInfo.RowIndex];
            CommandCenter.Instance.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, m_AppType);
            CommandCenter.Instance.ResolveSpplyFinancingBill(OperatorCommandType.View, ae, m_AppType, hitInfo.RowIndex);
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

                List<SpplyFinancingBill> list = dgv.DataSource as List<SpplyFinancingBill>;
                string messageStr = MatchFile.MatchFileDataHelper.Instance.CheckDataAvilidHigh(list, m_AppType);
                if (!string.IsNullOrEmpty(messageStr))
                {
                    MessageBoxExHelper.Instance.Show(messageStr, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    flag = false;
                }
                else
                {
                    SaveFileDialog sfg = new SaveFileDialog();
                    sfg.Filter = string.Format("{0}|*.dif", MultiLanguageConvertHelper.Instance.DesignMain_FileType_DIF);
                    if (sfg.ShowDialog() == DialogResult.OK)
                    {
                        string filepath = DataConvertHelper.Instance.FormatFileName(sfg.FileName, ".dif");
                        try
                        {
                            TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(m_AppType, list, filepath);
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Submit_Succeed, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            flag = true;
                            if (!isSaveOperator)
                            {
                                dgv.DataSource = null;
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
                (dgv.DataSource as List<SpplyFinancingBill>).ForEach(o =>
                {
                    int index = -1;
                    if (!string.IsNullOrEmpty(o.Amount) && o.Amount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.BillDate) && o.BillDate.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.BillSerialNo) && o.BillSerialNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CashTypeString) && o.CashTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ContractNo) && o.ContractNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CustomerName) && o.CustomerName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CustomerNo) && o.CustomerNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.EndDate) && o.EndDate.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.StartDate) && o.StartDate.Contains(temp)) index = count;
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
