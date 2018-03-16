using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.ConvertHelper;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class PayerItemsPanel : BaseUc
    {
        public PayerItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            this.colPayerAccount.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            CommandCenter.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnSettingsOperateEventHandler += new EventHandler<SettingsOperateEventArgs>(CommandCenter_OnSettingsOperateEventHandler);
            if (SystemSettings.PayerList.Count > 0)
            {
                List<PayerInfo> list = new List<PayerInfo>();
                list.AddRange(SystemSettings.PayerList.GetRange(0, SystemSettings.PayerList.Count));
                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = list;
                dgv.Refresh();
            }

            this.dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            dgv.CellContentClick += new DataGridViewCellEventHandler(dgv_CellContentClick);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(PayerItemsPanel), this);
            }
        }

        void CommandCenter_OnSettingsOperateEventHandler(object sender, SettingsOperateEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SettingsOperateEventArgs>(CommandCenter_OnSettingsOperateEventHandler), sender, e); }
            else
            {
                if (e.FunctionType != FunctionInSettingType.PayerMg) return;
                if (e.Command == OperatorCommandType.SelectAll)
                {
                    if (dgv.Rows.Count == 0) return;
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = true;
                    }
                }
                else if (e.Command == OperatorCommandType.SelectRe)
                {
                    if (dgv.Rows.Count == 0) return;
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells[0].Value = dgv.Rows[i].Cells[0].Value == null ? true : !((bool)dgv.Rows[i].Cells[0].Value);
                    }
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    if (dgv.RowCount == 0 || dgv.SelectedRows.Count == 0)
                    { MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_No_Selected_Records, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Question); return; }
                    else
                    {
                        if (MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Make_Sure_Delete_Selected_Records, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                            return;
                    }

                    List<PayerInfo> list = new List<PayerInfo>();
                    if (dgv.DataSource != null) list = dgv.DataSource as List<PayerInfo>;
                    List<int> indexs = new List<int>();
                    for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dgv.Rows[i].Cells[0].Value == null) continue;
                        if ((bool)dgv.Rows[i].Cells[0].Value)
                        {
                            indexs.Add(i);
                        }
                    }
                    foreach (var item in indexs)
                    {
                        CommandCenter.ResolvePayer(OperatorCommandType.Delete, list[item], AppliableFunctionType._Empty, item);
                    }
                }
            }
        }

        void CommandCenter_OnPayerInfoEventHandler(object sender, PayerEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler), new object[] { sender, e }); }
            else
            {
                List<PayerInfo> list = new List<PayerInfo>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<PayerInfo>;
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (null == list) list = new List<PayerInfo>();
                    if (e.OwnerType != AppliableFunctionType._Empty)
                    {
                        if (e.PayerInfo.ServiceList == AppliableFunctionType._Empty && e.OwnerType > 0) e.PayerInfo.ServiceList = e.OwnerType;
                        else if (e.PayerInfo.ServiceListBar == AppliableFunctionType._Empty && e.OwnerType < 0) e.PayerInfo.ServiceListBar = (AppliableFunctionType)Math.Abs((long)e.OwnerType);
                        int index = list.FindIndex(o => o.Account == e.PayerInfo.Account);
                        if (index < 0)
                            list.Add(e.PayerInfo);
                        else
                        {
                            list[index].ServiceList = list[index].ServiceList | e.PayerInfo.ServiceList;
                            list[index].ServiceListBar = list[index].ServiceListBar | e.PayerInfo.ServiceListBar;
                        }
                    }
                    else
                    {
                        if (list.Exists(o => o.Account == e.PayerInfo.Account && o.Name == e.PayerInfo.Name))
                        {
                            if (e.OwnerType == AppliableFunctionType._Empty)
                                MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_PayerMsg_Payer_Exist_Add_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //if (e.RowIndex > 0 && e.RowIndex < list.Count)
                        //    list.Insert(e.RowIndex - 1, e.PayerInfo);
                        //else
                            list.Add(e.PayerInfo);
                    }
                }
                else if (OperatorCommandType.Edit == e.Command)
                {
                    if (dgv.Rows.Count == 0 || (e.RowIndex < 1 || e.RowIndex > dgv.Rows.Count))
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Record_Not_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int index = list.FindIndex(o => o.Account == e.PayerInfo.Account && o.Name == e.PayerInfo.Name);
                    if (index == -1 && e.OwnerType != AppliableFunctionType._Empty) index = e.RowIndex;
                    if (index != e.RowIndex - 1 && index != -1)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_PayerMsg_Payer_Exist_Update_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        return;
                    }
                    list[e.RowIndex - 1] = e.PayerInfo;
                }
                else if (OperatorCommandType.Delete == e.Command)
                {
                    if (e.RowIndex >= 0 && e.RowIndex < list.Count)
                        list.RemoveAt(e.RowIndex);
                }
                else if (OperatorCommandType.Load == e.Command)
                { list = e.PayerList; }
                else return;
                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();
            }
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            PayerInfo payer = (dgv.DataSource as List<PayerInfo>)[hitInfo.RowIndex];
            CommandCenter.ResolvePayer(OperatorCommandType.View, payer, AppliableFunctionType._Empty, hitInfo.RowIndex + 1);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns.Count - 1) return;

            if (MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            List<PayerInfo> list = dgv.DataSource as List<PayerInfo>;
            PayerInfo payer = list[e.RowIndex];

            CommandCenter.ResolvePayer(OperatorCommandType.Delete, payer, AppliableFunctionType._Empty, e.RowIndex);
        }
    }
}
