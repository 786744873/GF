using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient.Entities;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class TransferGlobalPayeeItemsPanel : BaseUc
    {
        public TransferGlobalPayeeItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            CommandCenter.OnPayeeInfo4TransferGlobalEventHandler += new EventHandler<Payee4TransferGlobalEventArgs>(CommandCenter_OnPayeeInfo4TransferGlobalEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnSettingsOperateEventHandler += new EventHandler<SettingsOperateEventArgs>(CommandCenter_OnSettingsOperateEventHandler);
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            dgv.CellContentClick += new DataGridViewCellEventHandler(dgv_CellContentClick);

            if (SystemSettings.PayeeInfo4TransferGlobalList.Count > 0)
            {
                List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
                list.AddRange(SystemSettings.PayeeInfo4TransferGlobalList.GetRange(0, SystemSettings.PayeeInfo4TransferGlobalList.Count));
                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = list;
                dgv.Refresh();
            }
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(TransferGlobalPayeeItemsPanel), this);
            }
        }

        void CommandCenter_OnSettingsOperateEventHandler(object sender, SettingsOperateEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SettingsOperateEventArgs>(CommandCenter_OnSettingsOperateEventHandler), sender, e); }
            else
            {
                if (e.FunctionType != FunctionInSettingType.OverCountryPayeeMg) return;
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
                    if (dgv.RowCount == 0)
                    { MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_No_Selected_Records, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Question); return; }
                    else
                    {
                        if (MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Make_Sure_Delete_Selected_Records, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                            return;
                    }

                    List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
                    if (dgv.DataSource != null) list = dgv.DataSource as List<PayeeInfo4TransferGlobal>;
                    List<int> indexs = new List<int>();

                    for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dgv.Rows[i].Cells[0].Value == null) continue;
                        if ((bool)dgv.Rows[i].Cells[0].Value)
                        {
                            indexs.Add(i);
                            //CommandCenter.ResolvePayee4TransferGlobal(OperatorCommandType.Delete, list[i], AppliableFunctionType._Empty, i);
                            //list.RemoveAt(i);
                        }
                    }

                    foreach (var item in indexs)
                    {
                        CommandCenter.ResolvePayee4TransferGlobal(OperatorCommandType.Delete, list[item], AppliableFunctionType._Empty, item);
                    }
                }
            }
        }

        void CommandCenter_OnPayeeInfo4TransferGlobalEventHandler(object sender, Payee4TransferGlobalEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<Payee4TransferGlobalEventArgs>(CommandCenter_OnPayeeInfo4TransferGlobalEventHandler), new object[] { sender, e }); }
            else
            {
                List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<PayeeInfo4TransferGlobal>;
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (null == list) list = new List<PayeeInfo4TransferGlobal>();
                    if (list.Exists(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && ((o.OpenBankType == e.PayeeInfo.OpenBankType && e.PayeeInfo.OpenBankType == AccountBankType.BocAccount) || (o.OpenBankType != AccountBankType.BocAccount && e.PayeeInfo.OpenBankType != AccountBankType.BocAccount && o.OpenBankName == e.PayeeInfo.OpenBankName))))
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Exist_Add_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //if (e.RowIndex > 0 && e.RowIndex < list.Count)
                    //    list.Insert(e.RowIndex - 1, e.PayeeInfo);
                    //else
                        list.Add(e.PayeeInfo);
                }
                else if (OperatorCommandType.Edit == e.Command)
                {
                    if (dgv.Rows.Count == 0 || (e.RowIndex < 1 || e.RowIndex > dgv.Rows.Count))
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Record_Not_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int index = list.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && ((o.OpenBankType == e.PayeeInfo.OpenBankType && e.PayeeInfo.OpenBankType == AccountBankType.BocAccount) || (o.OpenBankType != AccountBankType.BocAccount && e.PayeeInfo.OpenBankType != AccountBankType.BocAccount && o.OpenBankName == e.PayeeInfo.OpenBankName)));
                    if (index != e.RowIndex - 1 && index >= 0)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Exist_Update_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        return;
                    }
                    list[e.RowIndex - 1] = e.PayeeInfo;
                }
                else if (OperatorCommandType.Delete == e.Command)
                {
                    if (e.RowIndex >= 0 && e.RowIndex < list.Count)
                        list.RemoveAt(e.RowIndex);
                }
                else if (OperatorCommandType.Load == e.Command)
                { list = e.PayeeList; }
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    foreach (var item in e.PayeeList)
                    {
                        if (list.FindIndex(o => o.Account == item.Account && o.Name == item.Name && o.OpenBankName == item.OpenBankName) >= 0)
                            continue;
                        list.Add(item);
                    }
                }
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

            PayeeInfo4TransferGlobal payee = (dgv.DataSource as List<PayeeInfo4TransferGlobal>)[hitInfo.RowIndex];
            CommandCenter.ResolvePayee4TransferGlobal(OperatorCommandType.View, payee, AppliableFunctionType._Empty, hitInfo.RowIndex + 1);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns.Count - 1) return;

            if (MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
            if (dgv.Rows.Count > 0) list = dgv.DataSource as List<PayeeInfo4TransferGlobal>;
            PayeeInfo4TransferGlobal payee = list[e.RowIndex];
            CommandCenter.ResolvePayee4TransferGlobal(OperatorCommandType.Delete, payee, AppliableFunctionType._Empty, e.RowIndex);
        }

        public bool SaveData()
        {
            bool flag = false;
            if (dgv.Rows.Count > 0)
            {
                if (dgv.Rows.Count > SystemSettings.DefaultMaxCountPayeeTransferGlobalMgr)
                {
                    if (MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.DefaultMaxCountPayeeTransferGlobalMgr), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }
                SaveFileDialog sfg = new SaveFileDialog();
                sfg.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT);
                if (sfg.ShowDialog() == DialogResult.OK)
                {
                    string filepath = DataConvertHelper.FormatFileName(sfg.FileName, ".txt");

                    List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
                    if (dgv.Rows.Count > SystemSettings.DefaultMaxCountPayeeTransferGlobalMgr) list = (dgv.DataSource as List<PayeeInfo4TransferGlobal>).GetRange(0, SystemSettings.DefaultMaxCountPayeeTransferGlobalMgr);
                    else list = dgv.DataSource as List<PayeeInfo4TransferGlobal>;
                    try
                    {
                        TemplateHelper.BatchConsignDataTemplateHelper.CreateTxtDocument(FunctionInSettingType.OverCountryPayeeMg, list, filepath);
                        flag = true;
                    }
                    catch
                    {
                        flag = false;
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeFile_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                    }
                }

                sfg.Dispose();
            }
            return flag;
        }
    }
}
