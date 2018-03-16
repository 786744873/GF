using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.VisualParts;
using CommonClient.Contract;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient;
using CommonClient.SysCoach;
using System.IO;
using CommonClient.Entities;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_AGENTNORMALIN
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_AGENTNORMALIN", false, 8, "普通代收", AppliableFunctionType.AgentNormalIn)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            fileOperatePanel6.ShowBtnMatchError(false);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
        }
        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.AgentNormalIn) return;
                if (e.Command == OperatorCommandType.EditOperatorCallBack)
                    SubmitData(OperatorCommandType.Edit);
            }
        }
        /// <summary>
        /// 新建 打开
        /// </summary>
        /// <param name="command"></param>
        private void OpenOrCreateData(OperatorCommandType command)
        {
            #region
            if (agentNormalPanel_In.HasData)
            {
                if (!bchpnlNormalAgentIn.HasData)
                {
                    if (MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_AllRecord, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        CommandCenter.ResolveAgentNormal(OperatorCommandType.New, AppliableFunctionType.AgentNormalIn);
                    else
                        return;
                }
                bchpnlNormalAgentIn.GetItem();
                if (bchpnlNormalAgentIn.HasData && !agentNormalPanel_In.SaveData(bchpnlNormalAgentIn.BatchInfo, false)) return;
            }
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveAgentNormal(command, AppliableFunctionType.AgentNormalIn);
                CommandCenter.ResolveAgentNormal(OperatorCommandType.Reset, AppliableFunctionType.AgentNormalIn);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.AgentNormalIn, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            if (srAgentNormalIn.CheckData())
            {
                srAgentNormalIn.GetItem();
                AgentNormal an = srAgentNormalIn.AgentNormal;
                CommandCenter.ResolveAgentNormal(command, an, srAgentNormalIn.AppType, rowIndexPanel_NormalIn.RowIndex);
            }

        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.AgentNormalIn, rowIndexPanel_NormalIn.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveAgentNormal(command, null, AppliableFunctionType.AgentNormalIn, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.agentNormalPanel_In.HasData;
                if (flag)
                {
                    if (!bchpnlNormalAgentIn.CheckData() || !bchpnlNormalAgentIn.CheckValid()) return;
                    bchpnlNormalAgentIn.GetItem();
                    BatchHeader batch = bchpnlNormalAgentIn.BatchInfo;
                    this.agentNormalPanel_In.SaveData(batch, true);
                    //if (batch.CanAddPayer) CommandCenter.ResolvePayer(OperatorCommandType.Submit, batch.Payer, m_CurrentAppType, int.MaxValue);
                    if (batch.CanAddNotice)
                    {
                        if (SystemSettings.Notices.ContainsKey(AppliableFunctionType.AgentNormalIn) && SystemSettings.Notices[AppliableFunctionType.AgentNormalIn].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Addition_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                        else
                            CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = batch.Addtion }, AppliableFunctionType.AgentNormalIn);
                    }
                }
                if (!flag)
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_NoData_Save, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Submit_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
            }
        }
        private void dataOperatePanel1_ButtonAddClicked(object sender, EventArgs e)
        {
            SubmitData(OperatorCommandType.Submit);
        }

        private void dataOperatePanel1_ButtonEditClicked(object sender, EventArgs e)
        {
            EditOperatorRequest();
        }

        private void dataOperatePanel1_ButtonDeleteClicked(object sender, EventArgs e)
        {
            DeleteOrReloadData(OperatorCommandType.Delete);
        }

        private void dataOperatePanel1_ButtonResetClicked(object sender, EventArgs e)
        {
            DeleteOrReloadData(OperatorCommandType.Reset);
        }

        private void fileOperatePanel1_ButtonNewClicked(object sender, EventArgs e)
        {
            OpenOrCreateData(OperatorCommandType.New);
        }

        private void fileOperatePanel1_ButtonOpenClicked(object sender, EventArgs e)
        {
            OpenOrCreateData(OperatorCommandType.Open);
        }

        private void fileOperatePanel1_ButtonSaveClicked(object sender, EventArgs e)
        {
            SaveTXTFile();
        }

        private void fileOperatePanel1_ButtonMergFromFileClicked(object sender, EventArgs e)
        {
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.AgentNormalIn, true);
        }
        private void fileOperatePanel1_ButtonUpClicked(object sender, EventArgs e)
        {
            DeleteOrReloadData(OperatorCommandType.DataMoveUp);
        }

        private void fileOperatePanel1_ButtonDownClicked(object sender, EventArgs e)
        {
            DeleteOrReloadData(OperatorCommandType.DataMoveDown);
        }

    }
}
