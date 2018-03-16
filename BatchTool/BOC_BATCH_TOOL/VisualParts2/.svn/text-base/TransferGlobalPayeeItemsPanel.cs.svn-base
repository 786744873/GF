using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.Entities;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class TransferGlobalPayeeItemsPanel : BaseUc
    {
        public TransferGlobalPayeeItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            CommandCenter.Instance.OnPayeeInfo4TransferGlobalEventHandler += new EventHandler<Payee4TransferGlobalEventArgs>(CommandCenter_OnPayeeInfo4TransferGlobalEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
            CommandCenter.Instance.OnSettingsOperateEventHandler += new EventHandler<SettingsOperateEventArgs>(CommandCenter_OnSettingsOperateEventHandler);
            this.Load += new EventHandler(TransferGlobalPayeeItemsPanel_Load);
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            dgv.CellContentClick += new DataGridViewCellEventHandler(dgv_CellContentClick);

            if (SystemSettings.Instance.PayeeInfo4TransferGlobalList.Count > 0)
            {
                List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
                list.AddRange(SystemSettings.Instance.PayeeInfo4TransferGlobalList.GetRange(0, SystemSettings.Instance.PayeeInfo4TransferGlobalList.Count));
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
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_No_Selected_Records, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Question); return; }
                    else
                    {
                        if (MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_Make_Sure_Delete_Selected_Records, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
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
                            //CommandCenter.Instance.ResolvePayee4TransferGlobal(OperatorCommandType.Delete, list[i], AppliableFunctionType._Empty, i);
                            //list.RemoveAt(i);
                        }
                    }

                    foreach (var item in indexs)
                    {
                        CommandCenter.Instance.ResolvePayee4TransferGlobal(OperatorCommandType.Delete, list[item], AppliableFunctionType._Empty, item);
                    }
                }
            }
        }

        void TransferGlobalPayeeItemsPanel_Load(object sender, EventArgs e)
        {
            isLoad = true;

            SetIndex();
        }

        bool isLoad = false;

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
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Exist_Add_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (e.RowIndex > 0 && e.RowIndex < list.Count)
                    {
                        list.Insert(e.RowIndex - 1, e.PayeeInfo);
                    }
                    else
                    {
                        list.Add(e.PayeeInfo);
                    }
                }
                else if (OperatorCommandType.Edit == e.Command)
                {
                    if (dgv.Rows.Count == 0 || (e.RowIndex < 1 || e.RowIndex > dgv.Rows.Count))
                    {
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Record_Not_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int index = list.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && ((o.OpenBankType == e.PayeeInfo.OpenBankType && e.PayeeInfo.OpenBankType == AccountBankType.BocAccount) || (o.OpenBankType != AccountBankType.BocAccount && e.PayeeInfo.OpenBankType != AccountBankType.BocAccount && o.OpenBankName == e.PayeeInfo.OpenBankName)));
                    if (index != e.RowIndex - 1 && index >= 0)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Exist_Update_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dgv.DataSource = null;
                dgv.DataSource = list;
                dgv.Refresh();
                if (isLoad)
                    SetIndex();
            }
        }

        void SetIndex()
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells[1].Value = i + 1;
            }
            dgv.Refresh();
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            PayeeInfo4TransferGlobal payee = (dgv.DataSource as List<PayeeInfo4TransferGlobal>)[hitInfo.RowIndex];
            CommandCenter.Instance.ResolvePayee4TransferGlobal(OperatorCommandType.View, payee, AppliableFunctionType._Empty, hitInfo.RowIndex + 1);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns.Count - 1) return;

            if (MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_MakeSure_Delete_Record, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
            if (dgv.Rows.Count > 0) list = dgv.DataSource as List<PayeeInfo4TransferGlobal>;
            PayeeInfo4TransferGlobal payee = list[e.RowIndex];
            CommandCenter.Instance.ResolvePayee4TransferGlobal(OperatorCommandType.Delete, payee, AppliableFunctionType._Empty, e.RowIndex);
        }

        public bool SaveData()
        {
            bool flag = false;
            if (dgv.Rows.Count > 0)
            {
                if (dgv.Rows.Count > SystemSettings.Instance.DefaultMaxCountPayeeTransferGlobalMgr)
                {
                    if (MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.Instance.DefaultMaxCountPayeeTransferGlobalMgr), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }
                SaveFileDialog sfg = new SaveFileDialog();
                sfg.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.Instance.DesignMain_FileType_TXT);
                if (sfg.ShowDialog() == DialogResult.OK)
                {
                    string filepath = DataConvertHelper.Instance.FormatFileName(sfg.FileName, ".txt");

                    List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
                    if (dgv.Rows.Count > SystemSettings.Instance.DefaultMaxCountPayeeTransferGlobalMgr) list = (dgv.DataSource as List<PayeeInfo4TransferGlobal>).GetRange(0, SystemSettings.Instance.DefaultMaxCountPayeeTransferGlobalMgr);
                    else list = dgv.DataSource as List<PayeeInfo4TransferGlobal>;
                    try
                    {
                        TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(FunctionInSettingType.OverCountryPayeeMg, list, filepath);
                        flag = true;
                    }
                    catch
                    {
                        flag = false;
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_MakeFile_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                sfg.Dispose();
            }
            return flag;
        }
    }
}
