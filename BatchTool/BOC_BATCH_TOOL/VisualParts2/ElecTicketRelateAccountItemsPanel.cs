using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Entities;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class ElecTicketRelateAccountItemsPanel : BaseUc
    {
        public ElecTicketRelateAccountItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            this.Load += new EventHandler(ElecTicketRelateAccountItemsPanel_Load);
            CommandCenter.Instance.OnElecTicketRelateAccountEventHandler += new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnSettingsOperateEventHandler += new EventHandler<SettingsOperateEventArgs>(CommandCenter_OnSettingsOperateEventHandler);
            if (SystemSettings.Instance.ElecTicketRelationAccountList.Count > 0)
            {
                List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
                list.AddRange(SystemSettings.Instance.ElecTicketRelationAccountList.GetRange(0, SystemSettings.Instance.ElecTicketRelationAccountList.Count));
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
                SetIndex();
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
                    if (dgv.RowCount == 0)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_No_Selected_Records, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Question); return; }
                    else
                    {
                        if (MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_Make_Sure_Delete_Selected_Records, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
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
                        CommandCenter.Instance.ResolveElecTicketRelateAccount(OperatorCommandType.Delete, list[item], item);
                    }
                }
            }
        }

        void ElecTicketRelateAccountItemsPanel_Load(object sender, EventArgs e)
        {
            isLoad = true;
            SetIndex();
        }

        private bool isLoad = false;

        private void SetIndex()
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells[1].Value = i + 1;
            }
            dgv.Refresh();
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
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_RelateAccountMsg_Person_Exist_Add_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                    }
                    if (list.Count >= e.RowIndex)
                        list.Insert(e.RowIndex - 1, e.RelationAccount);
                    else
                        list.Add(e.RelationAccount);
                }
                else if (e.Command == OperatorCommandType.Edit)
                {
                    int index = list.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                    if (index >= 0 && index != e.RowIndex - 1)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_RelateAccountMsg_Person_Exist_Update_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                    }
                    if (e.RowIndex < 1 || e.RowIndex > list.Count || dgv.Rows.Count == 0)
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Record_Not_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();
                if (isLoad)
                    SetIndex();
            }
        }

        void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns.Count - 1) return;

            if (MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_MakeSure_Delete_Record, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
            if (dgv.Rows.Count > 0) list = dgv.DataSource as List<ElecTicketRelationAccount>;

            ElecTicketRelationAccount etra = list[e.RowIndex];
            CommandCenter.Instance.ResolveElecTicketRelateAccount(OperatorCommandType.Delete, etra, e.RowIndex);
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0 || hitInfo.ColumnIndex == dgv.Columns.Count - 1) return;

            ElecTicketRelationAccount etra = (dgv.DataSource as List<ElecTicketRelationAccount>)[hitInfo.RowIndex];
            CommandCenter.Instance.ResolveElecTicketRelateAccount(OperatorCommandType.View, etra, hitInfo.RowIndex + 1);
        }

        public bool SaveData()
        {
            bool flag = false;
            if (dgv.Rows.Count > 0)
            {
                if (dgv.Rows.Count > SystemSettings.Instance.DefaultMaxCountElecTicket)
                {
                    if (MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.Instance.DefaultMaxCountElecTicket), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }
                SaveFileDialog sfg = new SaveFileDialog();
                sfg.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.Instance.DesignMain_FileType_TXT);
                if (sfg.ShowDialog() == DialogResult.OK)
                {
                    string filepath = DataConvertHelper.Instance.FormatFileName(sfg.FileName, ".txt");

                    List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
                    if (dgv.Rows.Count > SystemSettings.Instance.DefaultMaxCountElecTicket) list = (dgv.DataSource as List<ElecTicketRelationAccount>).GetRange(0, SystemSettings.Instance.DefaultMaxCountElecTicket);
                    else list = dgv.DataSource as List<ElecTicketRelationAccount>;
                    try
                    {
                        TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(FunctionInSettingType.ElecTicketRelateAccountMg, list, filepath);
                        flag = true;
                    }
                    catch
                    {
                        flag = false;
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_MakeFile_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (sfg != null)
                    sfg.Dispose();
            }
            return flag;
        }
    }
}
