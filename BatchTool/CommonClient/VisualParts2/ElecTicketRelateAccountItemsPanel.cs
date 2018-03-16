using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class ElecTicketRelateAccountItemsPanel : BaseUc
    {
        public ElecTicketRelateAccountItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            CommandCenter.OnElecTicketRelateAccountEventHandler += new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.OnSettingsOperateEventHandler += new EventHandler<SettingsOperateEventArgs>(CommandCenter_OnSettingsOperateEventHandler);
            if (SystemSettings.ElecTicketRelationAccountList.Count > 0)
            {
                List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
                list.AddRange(SystemSettings.ElecTicketRelationAccountList.GetRange(0, SystemSettings.ElecTicketRelationAccountList.Count));
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
                base.ApplyResource(typeof(ElecTicketRelateAccountItemsPanel), this);
            }
        }

        void CommandCenter_OnSettingsOperateEventHandler(object sender, SettingsOperateEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SettingsOperateEventArgs>(CommandCenter_OnSettingsOperateEventHandler), sender, e); }
            else
            {
                if (e.FunctionType != FunctionInSettingType.ElecTicketRelateAccountMg) return;
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

                    List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
                    if (dgv.DataSource != null) list = dgv.DataSource as List<ElecTicketRelationAccount>;
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
                        CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Delete, list[item], item);
                    }
                }
            }
        }

        void CommandCenter_OnElecTicketRelateAccountEventHandler(object sender, ElecTicketRelateAccountEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler), sender, e); }
            else
            {
                List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<ElecTicketRelationAccount>;
                if (list == null) list = new List<ElecTicketRelationAccount>();
                if (e.Command == OperatorCommandType.Submit)
                {
                    if (null == e.RelationAccount) return;
                    if (list.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name) >= 0)
                    {
                        if (e.RowIndex != int.MaxValue)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_RelateAccountMsg_Person_Exist_Add_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return;
                    }
                    //if (list.Count >= e.RowIndex)
                    //    list.Insert(e.RowIndex - 1, e.RelationAccount);
                    //else
                        list.Add(e.RelationAccount);
                }
                else if (e.Command == OperatorCommandType.Edit)
                {
                    int index = list.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                    if (index >= 0 && index != e.RowIndex - 1)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_RelateAccountMsg_Person_Exist_Update_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return;
                    }
                    if (e.RowIndex < 1 || e.RowIndex > list.Count || dgv.Rows.Count == 0)
                    {
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Record_Not_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    list[e.RowIndex - 1] = e.RelationAccount;
                }
                else if (e.Command == OperatorCommandType.CombineData)
                {
                    foreach (var item in e.RelationAccountList)
                    {
                        if (list.FindIndex(o => o.Account == item.Account && o.Name == item.Name) >= 0)
                            continue;
                        list.Add(item);
                    }
                }
                else if (e.Command == OperatorCommandType.Delete)
                {
                    if (e.RowIndex >= 0 && e.RowIndex < list.Count)
                        list.RemoveAt(e.RowIndex);
                }
                else if (e.Command == OperatorCommandType.Load)
                { list = e.RelationAccountList; }
                else return;

                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();
            }
        }

        void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns.Count - 1) return;

            if (MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
            if (dgv.Rows.Count > 0) list = dgv.DataSource as List<ElecTicketRelationAccount>;

            ElecTicketRelationAccount etra = list[e.RowIndex];
            CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Delete, etra, e.RowIndex);
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0 || hitInfo.ColumnIndex == dgv.Columns.Count - 1) return;

            ElecTicketRelationAccount etra = (dgv.DataSource as List<ElecTicketRelationAccount>)[hitInfo.RowIndex];
            CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.View, etra, hitInfo.RowIndex + 1);
        }

        public bool SaveData()
        {
            bool flag = false;
            if (dgv.Rows.Count > 0)
            {
                if (dgv.Rows.Count > SystemSettings.DefaultMaxCountElecTicket)
                {
                    if (MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.DefaultMaxCountElecTicket), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }
                SaveFileDialog sfg = new SaveFileDialog();
                sfg.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT);
                if (sfg.ShowDialog() == DialogResult.OK)
                {
                    string filepath = DataConvertHelper.FormatFileName(sfg.FileName, ".txt");

                    List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
                    if (dgv.Rows.Count > SystemSettings.DefaultMaxCountElecTicket) list = (dgv.DataSource as List<ElecTicketRelationAccount>).GetRange(0, SystemSettings.DefaultMaxCountElecTicket);
                    else list = dgv.DataSource as List<ElecTicketRelationAccount>;
                    try
                    {
                        TemplateHelper.BatchConsignDataTemplateHelper.CreateTxtDocument(FunctionInSettingType.ElecTicketRelateAccountMg, list, filepath);
                        flag = true;
                    }
                    catch
                    {
                        flag = false;
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeFile_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                    }
                }
                if (sfg != null)
                    sfg.Dispose();
            }
            return flag;
        }
    }
}
