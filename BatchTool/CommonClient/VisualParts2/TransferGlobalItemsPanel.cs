using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.Entities;
using CommonClient.MatchFile;
using CommonClient.Utilities;
using CommonClient.VisualParts;
using CommonClient.TemplateHelper;

namespace CommonClient.VisualParts2
{
    public partial class TransferGlobalItemsPanel : BaseUc
    {
        public TransferGlobalItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            CommandCenter.OnQueryByRowIndexEventHandler += new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.OnTransferGlobalEventHandler += new EventHandler<TransferGlobalEventArgs>(CommandCenter_OnTransferGlobalEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnBankTypeChangedEventHandler += new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler);
            CommandCenter.OnCashTypeChangedEventHandler += new EventHandler<CashTypeChangedEventArgs>(CommandCenter_OnCashTypeChangedEventHandler);
            dgv.Paint += new PaintEventHandler(dgv_Paint);
        }

        void CommandCenter_OnCashTypeChangedEventHandler(object sender, CashTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<CashTypeChangedEventArgs>(CommandCenter_OnCashTypeChangedEventHandler), sender, e); }
            else
            {
                if (m_AppType != e.AppType || m_AppType > 0) return;
                if (e.Command != OperatorCommandType.CardTypeRequest) return;
                if (dgv.RowCount == 0) { e.IsRollBack = false; }
                else if (dgv.RowCount > 0 && dgv.DataSource != null) { if ((dgv.DataSource as List<TransferGlobal>) != null && (dgv.DataSource as List<TransferGlobal>).Count > 0 && (dgv.DataSource as List<TransferGlobal>)[0].PaymentCashType != e.CashType && (dgv.DataSource as List<TransferGlobal>)[0].PaymentCashType != CashType.Empty) { e.IsRollBack = true; e.CashType = (dgv.DataSource as List<TransferGlobal>)[0].PaymentCashType; } }
                CommandCenter.ResolveCashTypeChanged(OperatorCommandType.CardTypeCallBack, e.CashType, m_AppType, e.IsRollBack);
            }
        }

        void CommandCenter_OnBankTypeChangedEventHandler(object sender, BankTypeChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<BankTypeChangedEventArgs>(CommandCenter_OnBankTypeChangedEventHandler), sender, e); }
            else
            {
                if (e.AppType != m_AppType) return;
                if (e.Command != OperatorCommandType.BankTypeRequest) return;
                if (dgv.RowCount == 0) { e.IsRollBack = false; m_bankType = e.BankType; }
                if (dgv.RowCount > 0)
                {
                    AgentTransferBankType bt = (dgv.DataSource as List<TransferGlobal>)[0].PayeeOpenBankType == AccountBankType.BocAccount ? AgentTransferBankType.Boc : AgentTransferBankType.Other;
                    if (bt != e.BankType) { e.BankType = bt; e.IsRollBack = true; }
                }
                CommandCenter.ResolveBankTypeChanged(OperatorCommandType.BankTypeCallBack, m_AppType, e.BankType, e.IsRollBack);
            }
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
                base.ApplyResource(typeof(TransferGlobalItemsPanel), this);
                Init();
                ChangeUIStyle();
            }
        }

        void CommandCenter_OnTransferGlobalEventHandler(object sender, TransferGlobalEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<TransferGlobalEventArgs>(CommandCenter_OnTransferGlobalEventHandler), new object[] { sender, e }); }
            else
            {
                if (AppType != e.OwnerType) return;
                List<TransferGlobal> list = new List<TransferGlobal>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<TransferGlobal>;
                #region submit
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (dgv.Rows.Count >= SystemSettings.DefaultMaxCountTransferGlobal)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Reach_MaxCount_CanNot_Add, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + e.TransferGlobal.RemitAmount, 15);
                    //if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerRef) && o.CustomerRef == e.TransferGlobal.CustomerRef))
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.Transfer_CustomerRef_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if ((m_AppType == AppliableFunctionType.TransferOverCountry4Bar || m_AppType == AppliableFunctionType.TransferForeignMoney4Bar) && dgv.Rows.Count > 0)
                    {
                        if (!list.Exists(o => o.PayFeeAccount == e.TransferGlobal.PayFeeAccount))
                        {
                            MessageBoxPrime.Show("一批次只允许单一汇款账户", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (list.Exists(o => ((!string.IsNullOrEmpty(o.SpotAccount) || !string.IsNullOrEmpty(e.TransferGlobal.SpotAccount)) && o.SpotAccount != e.TransferGlobal.SpotAccount) || ((!string.IsNullOrEmpty(o.PurchaseAccount) || !string.IsNullOrEmpty(e.TransferGlobal.PurchaseAccount)) && o.PurchaseAccount != e.TransferGlobal.PurchaseAccount)))
                        {
                            MessageBoxPrime.Show("一批次只允许单一汇款账户类型", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    //if (e.RowIndex < 1) e.RowIndex = 1;
                    //if (e.RowIndex > 0 && e.RowIndex <= dgv.Rows.Count)
                    //    list.Insert(e.RowIndex - 1, e.TransferGlobal);
                    //else if (e.RowIndex > dgv.Rows.Count)
                    list.Add(e.TransferGlobal);
                    m_Amount += double.Parse(e.TransferGlobal.RemitAmount);
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
                    //ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + e.TransferGlobal.RemitAmount - list[e.RowIndex - 1].RemitAmount, 15);
                    //if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    if (list.Exists(o => !string.IsNullOrEmpty(o.CustomerRef) && o.CustomerRef == e.TransferGlobal.CustomerRef))
                    {
                        if (list[e.RowIndex - 1].CustomerRef != e.TransferGlobal.CustomerRef)
                        {
                            CommandCenter.ResolveTransferGlobal(OperatorCommandType.View, e.TransferGlobal, e.OwnerType, e.RowIndex);
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Transfer_CustomerRef_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    if ((m_AppType == AppliableFunctionType.TransferOverCountry4Bar || m_AppType == AppliableFunctionType.TransferForeignMoney4Bar) && dgv.Rows.Count > 1)
                    {
                        if (!list.Exists(o => o.PayFeeAccount == e.TransferGlobal.PayFeeAccount))
                        {
                            CommandCenter.ResolveTransferGlobal(OperatorCommandType.View, e.TransferGlobal, e.OwnerType, e.RowIndex);
                            MessageBoxPrime.Show("一批次只允许单一汇款账户", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (list.Exists(o => ((!string.IsNullOrEmpty(o.SpotAccount) || !string.IsNullOrEmpty(e.TransferGlobal.SpotAccount)) && o.SpotAccount != e.TransferGlobal.SpotAccount) || ((!string.IsNullOrEmpty(o.PurchaseAccount) || !string.IsNullOrEmpty(e.TransferGlobal.PurchaseAccount)) && o.PurchaseAccount != e.TransferGlobal.PurchaseAccount)))
                        {
                            MessageBoxPrime.Show("一批次只允许单一汇款账户类型", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    m_Amount += double.Parse(e.TransferGlobal.RemitAmount) - double.Parse(list[e.RowIndex - 1].RemitAmount);
                    list[e.RowIndex - 1] = e.TransferGlobal;
                }
                #endregion
                #region CombeData
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    int max = SystemSettings.DefaultMaxCountTransferGlobal - dgv.Rows.Count;
                    List<TransferGlobal> tempList = new List<TransferGlobal>();
                    if (e.TransferGlobalList.Count > max)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, max), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        tempList = e.TransferGlobalList.GetRange(0, max);
                    }
                    else tempList = e.TransferGlobalList;
                    if (m_AppType == AppliableFunctionType.TransferForeignMoney4Bar || m_AppType == AppliableFunctionType.TransferOverCountry4Bar)
                    {
                        string account = string.Empty;
                        CashType ct = CashType.Empty;
                        if (dgv.RowCount > 0)
                        {
                            account = (dgv.DataSource as List<TransferGlobal>)[0].PayFeeAccount;
                            ct = (dgv.DataSource as List<TransferGlobal>)[0].PaymentCashType;
                        }
                        if (tempList.Exists(o => (!string.IsNullOrEmpty(o.PayFeeAccount) && !string.IsNullOrEmpty(account) && o.PayFeeAccount != account) || (o.PaymentCashType != CashType.Empty && ct != CashType.Empty && o.PaymentCashType != ct)))
                        {
                            MessageBoxPrime.Show("付费账户或者币种不一致，合并失败", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    double amount = GetAmount(tempList);
                    //ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + amount, 15);
                    //if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    list.AddRange(tempList);
                    m_Amount += amount;
                }
                #endregion
                #region Open
                else if (OperatorCommandType.Open == e.Command)
                {
                    if (e.TransferGlobalList.Count > SystemSettings.DefaultMaxCountTransferGlobal)
                    {
                        MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Only_View_Some_Record, SystemSettings.DefaultMaxCountTransferGlobal), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        list = e.TransferGlobalList.GetRange(0, SystemSettings.DefaultMaxCountTransferGlobal);
                    }
                    else list = e.TransferGlobalList;
                    //ResultData rd = DataCheckCenter.CheckAllCash(m_Amount + GetAmount(list), 15);
                    //if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                    m_Amount = GetAmount(e.TransferGlobalList);
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
                    m_Amount -= double.Parse(list[dgv.SelectedRows[0].Index].RemitAmount);
                    list.RemoveAt(dgv.SelectedRows[0].Index);
                }
                #endregion
                #region ErrorData
                else if (OperatorCommandType.ErrorData == e.Command)
                {
                    if (e.TransferGlobalList != null && e.TransferGlobalList.Count > 0)
                    {
                        if (e.TransferGlobalList[e.TransferGlobalList.Count - 1].RowIndex <= dgv.Rows.Count)
                        {
                            foreach (var item in e.TransferGlobalList)
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
                    TransferGlobal ae = list[selectedindex];
                    list.RemoveAt(selectedindex);
                    list.Insert(selectedindex + moveindex, ae);
                    dgv.CurrentCell = dgv.Rows[selectedindex + moveindex].Cells[0];
                    #endregion
                }
                else if (OperatorCommandType.Print == e.Command)
                {
                    List<string> sclist = new List<string>();
                    if (m_AppType == AppliableFunctionType.TransferOverCountry4Bar || (m_AppType == AppliableFunctionType.TransferForeignMoney4Bar && m_bankType == AgentTransferBankType.Other))
                        sclist = new List<string> { dgv.Columns[0].HeaderText, dgv.Columns[5].HeaderText, dgv.Columns[6].HeaderText, dgv.Columns[7].HeaderText, dgv.Columns[18].HeaderText, dgv.Columns[19].HeaderText, dgv.Columns[29].HeaderText, dgv.Columns[38].HeaderText, dgv.Columns[39].HeaderText, dgv.Columns[41].HeaderText, dgv.Columns[42].HeaderText, dgv.Columns[48].HeaderText, dgv.Columns[49].HeaderText, dgv.Columns[50].HeaderText };

                    DataGridviewPrintHelper.PrintDataGridView(this, dgv, lblHeaderInfo.Text, sclist);
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

                if (m_AppType == AppliableFunctionType.TransferForeignMoney || m_AppType == AppliableFunctionType.TransferOverCountry)
                    lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount, list.Count);
                else if (m_AppType == AppliableFunctionType.TransferForeignMoney4Bar || m_AppType == AppliableFunctionType.TransferOverCountry4Bar)
                    lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount_And_CashType, list.Count, DataConvertHelper.FormatCash(m_Amount.ToString(), (dgv.RowCount > 0 ? (dgv.DataSource as List<TransferGlobal>)[0].PaymentCashType == CashType.JPY : false)), GetCashTypeString());

                if (e.Command == OperatorCommandType.Submit
                    || e.Command == OperatorCommandType.Edit
                    || e.Command == OperatorCommandType.Delete)
                    CommandCenter.ResolveTransferGlobal(OperatorCommandType.Reset, e.OwnerType);
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

        void CommandCenter_OnQueryByRowIndexEventHandler(object sender, QueryByRowIndexEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<QueryByRowIndexEventArgs>(CommandCenter_OnQueryByRowIndexEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.AppType != m_AppType) return;
                if (e.RowIndex < 0 || e.RowIndex >= dgv.Rows.Count || dgv.Rows.Count == 0)
                {
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_NoMatch_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    return;
                }
                TransferGlobal ta = new TransferGlobal();
                ta = (dgv.DataSource as List<TransferGlobal>)[e.RowIndex];
                CommandCenter.ResolveTransferGlobal(OperatorCommandType.View, ta, e.AppType, e.RowIndex);
            }
        }

        //PayFeeAccountType m_pft = PayFeeAccountType.Empty;
        AgentTransferBankType m_bankType = AgentTransferBankType.Other;
        private double m_Amount = 0.00d;
        string querycontent = string.Empty;
        List<int> indexList = new List<int>();

        /// <summary>
        /// 操作功能类型
        /// TransferOverCountry-跨境汇款,TransferForeignMoney-境内外币汇款
        /// </summary>
        [Browsable(true)]
        public AppliableFunctionType AppType
        {
            get { return m_AppType; }
            set
            {
                if (AppliableFunctionType.TransferForeignMoney == value
                    || AppliableFunctionType.TransferOverCountry == value
                    || AppliableFunctionType.TransferOverCountry4Bar == value
                    || AppliableFunctionType.TransferForeignMoney4Bar == value)
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

        private void Init()
        {
            clnPayeeOpenBankType.Visible = false;
            clnPaymentPropertyType.Visible = m_AppType == AppliableFunctionType.TransferForeignMoney || m_AppType == AppliableFunctionType.TransferForeignMoney4Bar;
            clnFSwiftCode.Visible =
            clnCSwiftCode.Visible = m_AppType == AppliableFunctionType.TransferOverCountry4Bar || m_AppType == AppliableFunctionType.TransferOverCountry;
            clnPayeeOpenBankName.Visible = true;
            clnDealNoteF.Visible =
            clnDealNoteS.Visible = m_AppType != AppliableFunctionType.TransferForeignMoney && m_AppType != AppliableFunctionType.TransferForeignMoney4Bar;
            clnBarApplyType.Visible =
            clnBarBusinessType.Visible =
            clnProvince.Visible =
            clnCertifyCardType.Visible =
            clnCertifyCardNo.Visible =
            clnNoticeType.Visible = m_AppType == AppliableFunctionType.TransferForeignMoney4Bar;

            if (m_AppType == AppliableFunctionType.TransferForeignMoney4Bar || m_AppType == AppliableFunctionType.TransferOverCountry4Bar)
                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount_And_CashType, 0, m_Amount, string.Empty);
            else if (m_AppType == AppliableFunctionType.TransferForeignMoney || m_AppType == AppliableFunctionType.TransferOverCountry)
                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount, 0);

            if (m_AppType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                clnFSwiftCode.HeaderText = MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankSwiftCode_Bar_OC;
                clnCSwiftCode.HeaderText = MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankSwiftCode_Bar_OC;
            }
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (hitInfo.RowIndex < 0) return;

            TransferGlobal transfer = (dgv.DataSource as List<TransferGlobal>)[hitInfo.RowIndex];
            if (null != transfer)
            {
                CommandCenter.ResolveRowIndex(OperatorCommandType.View, hitInfo.RowIndex + 1, m_AppType);
                CommandCenter.ResolveTransferGlobal(OperatorCommandType.View, transfer, m_AppType, hitInfo.RowIndex);
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
                        m_Amount = 0;
                        lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount_And_CashType, 0, m_Amount, string.Empty);
                        return true;
                    }
                    else if (dr == DialogResult.No)
                    {
                        LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, m_AppType, true);
                        return false;
                    }
                    else if (dr == DialogResult.Cancel) return false;
                }
                if (dgv.Rows.Count > SystemSettings.DefaultMaxCountTransferGlobal)
                {
                    if (MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.DefaultMaxCountTransferGlobal), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }

                if (m_AppType == AppliableFunctionType.TransferForeignMoney4Bar
                    || m_AppType == AppliableFunctionType.TransferOverCountry4Bar)
                {
                    if (string.IsNullOrEmpty(SystemSettings.CustomerInfo.Group) || string.IsNullOrEmpty(SystemSettings.CustomerInfo.Code))
                    {
                        frmCustomerInfoMgr frm = new frmCustomerInfoMgr();
                        if (frm.ShowDialog() != DialogResult.OK) return false;
                    }
                }

                List<TransferGlobal> list = dgv.DataSource as List<TransferGlobal>;
                string messageStr = MatchFile.MatchFileDataHelper.CheckDataAvilidHigh(list, m_AppType);
                if (!string.IsNullOrEmpty(messageStr))
                {
                    MessageBoxPrime.Show(messageStr, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                    flag = false;
                }
                else
                {
                    if (m_AppType == AppliableFunctionType.TransferOverCountry
                       || m_AppType == AppliableFunctionType.TransferForeignMoney)
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        string fileExtent = string.Empty;
                        if ((m_AppType == AppliableFunctionType.TransferOverCountry
                            && (SystemSettings.IsMatchPassword4TransferOverCountry
                                && !string.IsNullOrEmpty(SystemSettings.TransferOverCountryPassword)))
                             || (m_AppType == AppliableFunctionType.TransferForeignMoney
                            && (SystemSettings.IsMatchPassword4TransferForeignMoney
                                && !string.IsNullOrEmpty(SystemSettings.TransferForeignMoneyPassword))))
                        { saveFileDialog.Filter = string.Format("{0}|*.sef", MultiLanguageConvertHelper.DesignMain_FileType_SEF); fileExtent = ".sef"; }
                        else
                        { saveFileDialog.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT); fileExtent = ".txt"; }
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filepath = DataConvertHelper.FormatFileName(saveFileDialog.FileName, fileExtent);
                            try
                            {
                                TemplateHelper.BatchConsignDataTemplateHelper.CreateTxtDocument(m_AppType, list, filepath, m_Amount);
                                MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Save_Succed_Please_Next, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                                flag = true;
                                //if (!isSaveOperator)
                                //{
                                dgv.DataSource = null;
                                dgv.Refresh();
                                m_Amount = 0;
                                lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount_And_CashType, 0, m_Amount, string.Empty);
                                //}
                            }
                            catch
                            {
                                MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeFile_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                            }
                        }
                        if (saveFileDialog != null)
                            saveFileDialog.Dispose();
                    }
                    else if (m_AppType == AppliableFunctionType.TransferOverCountry4Bar
                        || m_AppType == AppliableFunctionType.TransferForeignMoney4Bar)
                    {
                        string filename = CommonInformations.GetBarFileName(m_AppType, m_AppType == AppliableFunctionType.TransferOverCountry4Bar ? AgentTransferBankType.Other : (list[0].PayeeOpenBankType == AccountBankType.BocAccount ? AgentTransferBankType.Boc : AgentTransferBankType.Other));
                        FolderBrowserDialog fbd = new FolderBrowserDialog();
                        if (fbd.ShowDialog() != DialogResult.OK) return false;
                        string filepath = System.IO.Path.Combine(fbd.SelectedPath, filename);
                        frmBarPassword frm = new frmBarPassword();
                        if (frm.ShowDialog() != DialogResult.OK) return false;
                        string pwd = frm.Password;

                        try
                        {
                            bool result = TemplateHelper.BatchConsignDataTemplateHelper.CreateDATDocumentBar(m_AppType, list, DataConvertHelper.FormatFileName(filepath, ".bar"), m_Amount);
                            if (!result) throw new Exception();
                            ResultData rd = FileDataPasswordBarHelper.EncodeAndZip(DataConvertHelper.FormatFileName(filepath, ".bar"), filepath, pwd);
                            if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return rd.Result; }

                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Submit_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                            flag = true;
                            //if (!isSaveOperator)
                            //{
                            dgv.DataSource = null;
                            dgv.Refresh();
                            m_Amount = 0;
                            lblHeaderInfo.Text = string.Format(MultiLanguageConvertHelper.DesignMain_Gather_AllCount_And_AllAmount, 0, m_Amount);
                            //}

                            CommonInformations.SetNextOrderNo();
                        }
                        catch
                        {
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeFile_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else flag = true;
            return flag;
        }

        private double GetAmount(List<TransferGlobal> list)
        {
            double d = 0.00d;
            foreach (var item in list)
            {
                d += double.Parse(item.RemitAmount);
            }
            return d;
        }

        string GetCashTypeString()
        {
            string cashString = string.Empty;
            if ((int)m_AppType < 0)
            {
                if (dgv.RowCount > 0)
                {
                    cashString = (dgv.DataSource as List<TransferGlobal>)[0].PaymentCashTypeString;
                }
            }
            return cashString;
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
                (dgv.DataSource as List<TransferGlobal>).ForEach(o =>
                {
                    int index = -1;
                    if (!string.IsNullOrEmpty(o.RemitAmount.ToString()) && o.RemitAmountString.Contains(temp)) index = count;
                    if (flag && !string.IsNullOrEmpty(o.ErrorReason) && o.ErrorReason.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.AmountF.ToString()) && o.AmountFString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.AmountS.ToString()) && o.AmountSString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.AssumeFeeTypeString) && o.AssumeFeeTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.BatchNoOrTNoOrSerialNo) && o.BatchNoOrTNoOrSerialNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.BillSerialNo) && o.BillSerialNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ContactNo) && o.ContactNo.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CorrespondentBankAddress) && o.CorrespondentBankAddress.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CorrespondentBankName) && o.CorrespondentBankName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.CustomerRef) && o.CustomerRef.Contains(temp)) index = count;
                    if (clnDealNoteF.Visible && !string.IsNullOrEmpty(o.DealNoteF) && o.DealNoteF.Contains(temp)) index = count;
                    if (clnDealNoteS.Visible && !string.IsNullOrEmpty(o.DealNoteS) && o.DealNoteS.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.DealSerialNoF) && o.DealSerialNoF.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.DealSerialNoS) && o.DealSerialNoS.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.IsPayOffLineString) && o.IsPayOffLineString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.OrgCode) && o.OrgCode.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.OtherAccount) && o.OtherAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.OtherAmountString) && o.OtherAmountString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayDate) && o.PayDate.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeAccount) && o.PayeeAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeAccountInCorrespondentBank) && o.PayeeAccountInCorrespondentBank.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeAddress) && o.PayeeAddress.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeCodeofCountry) && o.PayeeCodeofCountry.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeName) && o.PayeeName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeNameofCountry) && o.PayeeNameofCountry.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayeeOpenBankAddress) && o.PayeeOpenBankAddress.Contains(temp)) index = count;
                    if (clnPayeeOpenBankName.Visible && !string.IsNullOrEmpty(o.PayeeOpenBankName) && o.PayeeOpenBankName.Contains(temp)) index = count;
                    if (clnPayeeOpenBankType.Visible && !string.IsNullOrEmpty(o.PayeeOpenBankTypeString) && o.PayeeOpenBankTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayFeeAccount) && o.PayFeeAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PayFeeTypeString) && o.PayFeeTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PaymentCashTypeString) && o.PaymentCashTypeString.Contains(temp)) index = count;
                    if (clnPaymentPropertyType.Visible && !string.IsNullOrEmpty(o.PaymentPropertyTypeString) && o.PaymentPropertyTypeString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PaymentType) && o.PaymentType.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.ProposerName) && o.ProposerName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PurchaseAccount) && o.PurchaseAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.PurchaseAmountString) && o.PurchaseAmountString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.RemitAddress) && o.RemitAddress.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.RemitAmount.ToString()) && o.RemitAmountString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.RemitName) && o.RemitName.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.RemitNote) && o.RemitNote.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.SendPriorityString) && o.SendPriorityString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.SpotAccount) && o.SpotAccount.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.SpotAmountString) && o.SpotAmountString.Contains(temp)) index = count;
                    if (!string.IsNullOrEmpty(o.Telephone) && o.Telephone.Contains(temp)) index = count;
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
        private void dgv_Paint(object sender, PaintEventArgs e)
        {
            if (m_AppType == AppliableFunctionType.TransferOverCountry4Bar || m_AppType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                dgv.Columns[2].Visible = false;
            }
        }
    }
}
