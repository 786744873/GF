using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.VisualParts;
using CommonClient.Contract;
using CommonClient;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient.SysCoach;
using CommonClient.Entities;
using System.IO;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_AGENTNORMALOUT
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_AGENTNORMALOUT", false, 7, "普通代发", AppliableFunctionType.AgentNormalOut)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            fileOperatePanel5.ShowBtnMatchError(false);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
        }
        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.AgentNormalOut) return;
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
            if (agentNormalPanel_Out.HasData)
            {
                if (!bchpnlNormalAgentOut.HasData)
                {
                    if (MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_AllRecord, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        CommandCenter.ResolveAgentNormal(OperatorCommandType.New, AppliableFunctionType.AgentNormalOut);
                    else
                        return;
                }
                bchpnlNormalAgentOut.GetItem();
                if (bchpnlNormalAgentOut.HasData && !agentNormalPanel_Out.SaveData(bchpnlNormalAgentOut.BatchInfo, false)) return;
            }
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveAgentNormal(command, AppliableFunctionType.AgentNormalOut);
                CommandCenter.ResolveAgentNormal(OperatorCommandType.Reset, AppliableFunctionType.AgentNormalOut);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.AgentNormalOut, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            if (srAgentNormalOut.CheckData())
            {
                srAgentNormalOut.GetItem();
                AgentNormal an = srAgentNormalOut.AgentNormal;
                CommandCenter.ResolveAgentNormal(command, an, srAgentNormalOut.AppType, rowIndexPanel_NormalOut.RowIndex);
                //if (srAgentNormalOut.CanAdd)
                CommandCenter.ResolvePayee(OperatorCommandType.Submit, new PayeeInfo { Account = an.AccountNo, Name = an.AccountName, OpenBankName = an.BankName, BankType = string.IsNullOrEmpty(an.BankNo) ? AccountBankType.OtherBankAccount : AccountBankType.BocAccount }, srAgentNormalOut.AppType, int.MaxValue);
            }

        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.AgentNormalOut, rowIndexPanel_NormalOut.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveAgentNormal(command, null, AppliableFunctionType.AgentNormalOut, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.agentNormalPanel_Out.HasData;
                if (flag)
                {
                    if (!bchpnlNormalAgentOut.CheckData() || !bchpnlNormalAgentOut.CheckValid()) return;
                    bchpnlNormalAgentOut.GetItem();
                    BatchHeader batch = bchpnlNormalAgentOut.BatchInfo;
                    this.agentNormalPanel_Out.SaveData(batch, true);
                    if (batch.CanAddPayer)
                    {
                        batch.Payer.CashType = CashType.CNY;
                        CommandCenter.ResolvePayer(OperatorCommandType.Submit, batch.Payer, AppliableFunctionType.AgentNormalOut, int.MaxValue);
                    }
                    if (batch.CanAddNotice)
                    {
                        //if (SystemSettings.Notices.ContainsKey(AppliableFunctionType.AgentNormalOut))//&& SystemSettings.Notices[AppliableFunctionType.AgentNormalOut].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                        //    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Addition_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                        //else
                        CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = batch.Addtion }, AppliableFunctionType.AgentNormalOut);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.AgentNormalOut, true);
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
