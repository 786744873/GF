using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.ConvertHelper;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Entities;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class AgentExpressPayerItemsPanel : BaseUc
    {
        public AgentExpressPayerItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            CommandCenter.Instance.OnAgentExpressPayerEventHandler += new EventHandler<PayeeEventArgs>(CommandCenter_OnAgentExpressPayerEventHandler);
            CommandCenter.Instance.OnSettingsOperateEventHandler += new EventHandler<SettingsOperateEventArgs>(CommandCenter_OnSettingsOperateEventHandler);
            this.Load += new EventHandler(PayeeItemsPanel_Load);
            if (SystemSettings.Instance.AgentExpressPayerList.Count > 0)
            {
                List<PayeeInfo> list = new List<PayeeInfo>();
                list.AddRange(SystemSettings.Instance.AgentExpressPayerList.GetRange(0, SystemSettings.Instance.AgentExpressPayerList.Count));
                dgv.DataSource = list;
            }
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            dgv.CellContentClick += new DataGridViewCellEventHandler(dgv_CellContentClick);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                ApplyResource();
            }
        }

        void CommandCenter_OnSettingsOperateEventHandler(object sender, SettingsOperateEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<SettingsOperateEventArgs>(CommandCenter_OnSettingsOperateEventHandler), sender, e); }
            else
            {
                if (e.FunctionType != FunctionInSettingType.AgentExpressInPayerMg) return;
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
                    List<PayeeInfo> list = new List<PayeeInfo>();
                    if (dgv.DataSource != null) list = dgv.DataSource as List<PayeeInfo>;
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
                        CommandCenter.Instance.ResolveAgentExpressPayer(OperatorCommandType.Delete, list[item], AppliableFunctionType._Empty, item);
                    }
                }
            }
        }

        void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns.Count - 1) return;

            if (MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_MakeSure_Delete_Record, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            List<PayeeInfo> list = new List<PayeeInfo>();
            if (dgv.Rows.Count > 0) list = dgv.DataSource as List<PayeeInfo>;

            PayeeInfo payee = list[e.RowIndex];
            CommandCenter.Instance.ResolveAgentExpressPayer(OperatorCommandType.Delete, payee, AppliableFunctionType._Empty, e.RowIndex);
        }

        private bool isLoad = false;

        void PayeeItemsPanel_Load(object sender, EventArgs e)
        {
            isLoad = true;
            SetIndex();
        }

        private void SetIndex()
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells[1].Value = i + 1;
            }
        }

        void CommandCenter_OnAgentExpressPayerEventHandler(object sender, PayeeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayeeEventArgs>(CommandCenter_OnAgentExpressPayerEventHandler), new object[] { sender, e }); }
            else
            {
                List<PayeeInfo> list = new List<PayeeInfo>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<PayeeInfo>;
                if (list == null) list = new List<PayeeInfo>();
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (list.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName) >= 0)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_AgentExpressInPayerMg_Payee_Exist_Add_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (list.Exists(o => o.SerialNo == e.PayeeInfo.SerialNo && !string.IsNullOrEmpty(e.PayeeInfo.SerialNo)))
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_AgentExpressInPayerMg_Payee_SerialNo_Exist_Add_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //CommandCenter.Instance.ResolveAgentExpressPayer(OperatorCommandType.View, e.PayeeInfo, e.OwnerType, e.RowIndex);
                        return;
                    }
                    if (list.Count >= e.RowIndex)
                        list.Insert(e.RowIndex - 1, e.PayeeInfo);
                    else
                        list.Add(e.PayeeInfo);
                }
                else if (OperatorCommandType.Edit == e.Command)
                {
                    int index = list.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName);
                    if (index >= 0 && index != e.RowIndex - 1)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_AgentExpressInPayerMg_Payee_Exist_Update_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (e.RowIndex < 1 || e.RowIndex > list.Count || dgv.Rows.Count == 0)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.DesignMain_Record_Not_Exist, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    index = list.FindIndex(o => o.SerialNo == e.PayeeInfo.SerialNo && !string.IsNullOrEmpty(e.PayeeInfo.SerialNo));
                    if (index >= 0 && index != e.RowIndex - 1)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Instance.Settings_AgentExpressInPayerMg_Payee_SerialNo_Exist_Update_Fail, CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //else CommandCenter.Instance.ResolveAgentExpressPayer(OperatorCommandType.View, e.PayeeInfo, e.OwnerType, e.RowIndex);
                        return;
                    }
                    list[e.RowIndex - 1] = e.PayeeInfo;
                }
                else if (OperatorCommandType.Delete == e.Command)
                {
                    if (e.RowIndex >= 0 && e.RowIndex < dgv.RowCount)
                    {
                        list.RemoveAt(e.RowIndex);
                    }
                }
                else if (OperatorCommandType.CombineData == e.Command)
                {
                    foreach (var item in e.PayeeList)
                    {
                        if (list.FindIndex(o => o.Account == item.Account && o.Name == item.Name && o.OpenBankName == item.OpenBankName) >= 0)
                            continue;
                        if (list.Exists(o => o.SerialNo == item.SerialNo && !string.IsNullOrEmpty(item.SerialNo)))
                            continue;
                        list.Add(item);
                    }
                }
                dgv.DataSource = null;
                dgv.DataSource = list;
                if (isLoad)
                    SetIndex();
            }
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            PayeeInfo payee = (dgv.DataSource as List<PayeeInfo>)[hitInfo.RowIndex];
            CommandCenter.Instance.ResolveAgentExpressPayer(OperatorCommandType.View, payee, AppliableFunctionType._Empty, hitInfo.RowIndex + 1);
        }

        public bool SaveData()
        {
            bool flag = false;
            if (dgv.Rows.Count > 0)
            {
                if (dgv.Rows.Count > SystemSettings.Instance.DefaultMaxCountPayeeMgr)
                {
                    if (MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Instance.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.Instance.DefaultMaxCountPayeeMgr), CommonInformations.Instance.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }
                SaveFileDialog sfg = new SaveFileDialog();
                sfg.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.Instance.DesignMain_FileType_TXT);
                if (sfg.ShowDialog() == DialogResult.OK)
                {
                    string filepath = DataConvertHelper.Instance.FormatFileName(sfg.FileName, ".txt");

                    List<PayeeInfo> list = new List<PayeeInfo>();
                    if (dgv.Rows.Count > SystemSettings.Instance.DefaultMaxCountPayeeMgr) list = (dgv.DataSource as List<PayeeInfo>).GetRange(0, SystemSettings.Instance.DefaultMaxCountPayeeMgr);
                    else list = dgv.DataSource as List<PayeeInfo>;
                    try
                    {
                        TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(FunctionInSettingType.AgentExpressInPayerMg, list, filepath);
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

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource()
        {
            base.ApplyResource(typeof(AgentExpressPayerItemsPanel), this);
        }
    }
}
