﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.Utilities;
using CommonClient.VisualParts;
using CommonClient.TemplateHelper;

namespace CommonClient.VisualParts2
{
    public partial class SpplyFinancingOrderItemsPanel : BaseUc
    {
        public SpplyFinancingOrderItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            CommandCenter.OnSpplyFinancingOrderEventHandler += new EventHandler<SpplyFinancingOrderEventArgs>(CommandCenter_OnSpplyFinancingOrderEventHandler);
            CommandCenter.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
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
                base.ApplyResource(typeof(SpplyFinancingOrderItemsPanel), this);
                ChangeUIStyle();
            }
        }

        void CommandCenter_OnSpplyFinancingOrderEventHandler(object sender, SpplyFinancingOrderEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SpplyFinancingOrderEventArgs>(CommandCenter_OnSpplyFinancingOrderEventHandler), new object[] { sender, e }); }
            else
            {
                if (AppType != e.OwnerType) return;
                List<SpplyFinancingOrder> list = new List<SpplyFinancingOrder>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<SpplyFinancingOrder>;
                #region submit
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (dgv.Rows.Count >= SystemSettings.DefaultMaxCountSpplyFinancing)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (list.Exists(o => o.OrderNo.Equals(e.SpplyFinancingOrder.OrderNo)))
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_OrderNo_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //if (e.RowIndex < 1) e.RowIndex = 1;
                    //if (e.RowIndex > 0 && e.RowIndex <= dgv.Rows.Count)
                    //    list.Insert(e.RowIndex - 1, e.SpplyFinancingOrder);
                    //else if (e.RowIndex > dgv.Rows.Count)
                    list.Add(e.SpplyFinancingOrder);
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
                    int index = list.FindIndex(o => o.OrderNo.Equals(e.SpplyFinancingOrder.OrderNo));
                    if (index >= 0 && index != e.RowIndex - 1)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_OrderNo_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    list[e.RowIndex - 1] = e.SpplyFinancingOrder;
                }
                #endregion
                #region CombeData
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    List<SpplyFinancingOrder> tempList = new List<SpplyFinancingOrder>();
                    int max = SystemSettings.DefaultMaxCountSpplyFinancing - dgv.Rows.Count;
                    if (e.SpplyFinancingOrderList.Count > max)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, max), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        tempList = e.SpplyFinancingOrderList.GetRange(0, max);
                    }
                    else tempList = e.SpplyFinancingOrderList;
                    list.AddRange(tempList);
                }
                #endregion
                #region Open
                else if (OperatorCommandType.Open == e.Command)
                {
                    if (e.SpplyFinancingOrderList.Count > SystemSettings.DefaultMaxCountSpplyFinancing)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.DefaultMaxCountSpplyFinancing), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        list = e.SpplyFinancingOrderList.GetRange(0, SystemSettings.DefaultMaxCountSpplyFinancing);
                    }
                    else list = e.SpplyFinancingOrderList;
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
                    list.RemoveAt(dgv.SelectedRows[0].Index );
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
                    SpplyFinancingOrder ae = list[selectedindex];
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
                querycontent = string.Empty;
                indexList.Clear();
                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount, list.Count);

                if (e.Command == OperatorCommandType.Submit
                    || e.Command == OperatorCommandType.Edit
                    || e.Command == OperatorCommandType.Delete)
                    CommandCenter.ResolveSpplyFinancingOrder(OperatorCommandType.Reset, e.OwnerType);
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
                CommandCenter.ResolveSpplyFinancingOrder(OperatorCommandType.View, (dgv.DataSource as List<SpplyFinancingOrder>)[e.RowIndex], e.AppType, e.RowIndex);
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
        /// PurchaserOrder-,SellerOrder-
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.PurchaserOrder == value || AppliableFunctionType.SellerOrder == value)
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
            clnERPCode.Visible =
            clnBankCustomerNo.Visible = m_AppType == AppliableFunctionType.PurchaserOrder;
            clnCustomerName.Visible = m_AppType == AppliableFunctionType.SellerOrder;
            clnPayDate.HeaderText = m_AppType == AppliableFunctionType.PurchaserOrder ? MultiLanguageConvertHelper.SpplyFinancingOrder_PayDate_Seller : MultiLanguageConvertHelper.SpplyFinancingOrder_PayDate_Purchase;
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            SpplyFinancingOrder ae = (dgv.DataSource as List<SpplyFinancingOrder>)[hitInfo.RowIndex];
            CommandCenter.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, m_AppType);
            CommandCenter.ResolveSpplyFinancingOrder(OperatorCommandType.View, ae, m_AppType, hitInfo.RowIndex);
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

                List<SpplyFinancingOrder> list = dgv.DataSource as List<SpplyFinancingOrder>;
                string messageStr = MatchFile.MatchFileDataHelper.CheckDataAvilidHigh(list, m_AppType);
                if (!string.IsNullOrEmpty(messageStr))
                {
                    MessageBoxPrime.Show(messageStr, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    flag = false;
                }
                else
                {
                    SaveFileDialog sfg = new SaveFileDialog();
                    sfg.Filter = string.Format("{0}|*.dif", MultiLanguageConvertHelper.DesignMain_FileType_DIF);
                    if (sfg.ShowDialog() == DialogResult.OK)
                    {
                        string filepath = DataConvertHelper.FormatFileName(sfg.FileName, ".dif");
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
                (dgv.DataSource as List<SpplyFinancingOrder>).ForEach(o =>
                {
                    int index = -1;
                    if (!string.IsNullOrEmpty(o.OrderNo) && o.OrderNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CashTypeString) && o.CashTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Amount.ToString()) && o.Amount.Contains(temp)) index = count;
                    if (m_AppType == AppliableFunctionType.PurchaserOrder)
                    {
                        if (!string.IsNullOrEmpty(o.CustomerApplyNo) && o.CustomerApplyNo.Contains(temp)) index = count;
                        if (!string.IsNullOrEmpty(o.ERPCode) && o.ERPCode.Contains(temp)) index = count;
                    }
                    else if (m_AppType == AppliableFunctionType.SellerOrder)
                        if (!string.IsNullOrEmpty(o.CustomerName) && o.CustomerName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayDate) && o.PayDate.Contains(temp)) index = count;
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
