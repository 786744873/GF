using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient.SysCoach;
using CommonClient.Entities;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class AgentExpressPayerItemsPanel : BaseUc
    {
        public AgentExpressPayerItemsPanel()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            CommandCenter.OnAgentExpressPayerEventHandler += new EventHandler<PayeeEventArgs>(CommandCenter_OnAgentExpressPayerEventHandler);
            CommandCenter.OnSettingsOperateEventHandler += new EventHandler<SettingsOperateEventArgs>(CommandCenter_OnSettingsOperateEventHandler);
            if (SystemSettings.AgentExpressPayerList.Count > 0)
            {
                List<PayeeInfo> list = new List<PayeeInfo>();
                list.AddRange(SystemSettings.AgentExpressPayerList.GetRange(0, SystemSettings.AgentExpressPayerList.Count));
                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = list;
            }
            dgv.MouseDoubleClick += new MouseEventHandler(dgv_MouseDoubleClick);
            dgv.CellContentClick += new DataGridViewCellEventHandler(dgv_CellContentClick);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
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
                    if (dgv.RowCount == 0 || dgv.SelectedRows.Count == 0)
                    { MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_No_Selected_Records, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Question); return; }
                    else
                    {
                        if (MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Make_Sure_Delete_Selected_Records, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
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
                    if (indexs.Count == 0)
                    { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Please_Select_Delete_Row, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Question); return; }
                    foreach (var item in indexs)
                    {
                        CommandCenter.ResolveAgentExpressPayer(OperatorCommandType.Delete, list[item], AppliableFunctionType._Empty, item);
                    }
                }
            }
        }

        void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns.Count - 1) return;

            if (MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_Record, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            List<PayeeInfo> list = new List<PayeeInfo>();
            if (dgv.Rows.Count > 0) list = dgv.DataSource as List<PayeeInfo>;

            PayeeInfo payee = list[e.RowIndex];
            CommandCenter.ResolveAgentExpressPayer(OperatorCommandType.Delete, payee, AppliableFunctionType._Empty, e.RowIndex);
        }

        private bool isLoad = false;

        void CommandCenter_OnAgentExpressPayerEventHandler(object sender, PayeeEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<PayeeEventArgs>(CommandCenter_OnAgentExpressPayerEventHandler), new object[] { sender, e }); }
            else
            {
                List<PayeeInfo> list = new List<PayeeInfo>();
                if (dgv.Rows.Count > 0) list = dgv.DataSource as List<PayeeInfo>;
                if (list == null) list = new List<PayeeInfo>();
                #region Submit
                if (OperatorCommandType.Submit == e.Command)
                {
                    if (list.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName) >= 0)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_AgentExpressInPayerMg_Payee_Exist_Add_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (list.Exists(o => o.SerialNo == e.PayeeInfo.SerialNo && !string.IsNullOrEmpty(e.PayeeInfo.SerialNo)))
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_AgentExpressInPayerMg_Payee_SerialNo_Exist_Add_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        //CommandCenter.ResolveAgentExpressPayer(OperatorCommandType.View, e.PayeeInfo, e.OwnerType, e.RowIndex);
                        return;
                    }
                    //if (list.Count >= e.RowIndex)
                    //    list.Insert(e.RowIndex - 1, e.PayeeInfo);
                    //else
                    list.Add(e.PayeeInfo);
                }
                #endregion
                #region Edit
                else if (OperatorCommandType.Edit == e.Command)
                {
                    int index = list.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName);
                    if (e.RowIndex < 1 || e.RowIndex > list.Count || dgv.Rows.Count == 0)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Record_Not_Exist, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                        return;
                    } 
                    if (index >= 0 && index != e.RowIndex - 1)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_AgentExpressInPayerMg_Payee_Exist_Update_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        return;
                    }
                    index = list.FindIndex(o => o.SerialNo == e.PayeeInfo.SerialNo && !string.IsNullOrEmpty(e.PayeeInfo.SerialNo));
                    if (index >= 0 && index != e.RowIndex - 1)
                    {
                        if (e.OwnerType == AppliableFunctionType._Empty)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_AgentExpressInPayerMg_Payee_SerialNo_Exist_Update_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        //else CommandCenter.ResolveAgentExpressPayer(OperatorCommandType.View, e.PayeeInfo, e.OwnerType, e.RowIndex);
                        return;
                    }
                    list[e.RowIndex - 1] = e.PayeeInfo;
                }
                #endregion
                #region Delete
                else if (OperatorCommandType.Delete == e.Command)
                {
                    if (e.RowIndex >= 0 && e.RowIndex < dgv.RowCount)
                    {
                        list.RemoveAt(e.RowIndex);
                    }
                }
                #endregion
                #region CombineData
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
                #endregion
                int count = 0;
                list.ForEach(o => o.RowIndex = ++count);
                dgv.DataSource = null;
                dgv.DataSource = list;
            }
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            if (null == hitInfo || hitInfo.RowIndex < 0) return;

            PayeeInfo payee = (dgv.DataSource as List<PayeeInfo>)[hitInfo.RowIndex];
            CommandCenter.ResolveAgentExpressPayer(OperatorCommandType.View, payee, AppliableFunctionType._Empty, hitInfo.RowIndex + 1);
        }

        public bool SaveData()
        {
            bool flag = false;
            if (dgv.Rows.Count > 0)
            {
                if (dgv.Rows.Count > SystemSettings.DefaultMaxCountPayeeMgr)
                {
                    if (MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.DesignMain_Over_MaxCount_Whether_Continue, SystemSettings.DefaultMaxCountPayeeMgr), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                }
                SaveFileDialog sfg = new SaveFileDialog();
                sfg.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT);
                if (sfg.ShowDialog() == DialogResult.OK)
                {
                    string filepath = DataConvertHelper.FormatFileName(sfg.FileName, ".txt");

                    List<PayeeInfo> list = new List<PayeeInfo>();
                    if (dgv.Rows.Count > SystemSettings.DefaultMaxCountPayeeMgr) list = (dgv.DataSource as List<PayeeInfo>).GetRange(0, SystemSettings.DefaultMaxCountPayeeMgr);
                    else list = dgv.DataSource as List<PayeeInfo>;
                    try
                    {
                        TemplateHelper.BatchConsignDataTemplateHelper.CreateTxtDocument(FunctionInSettingType.AgentExpressInPayerMg, list, filepath);
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
