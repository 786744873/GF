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
using CommonClient.Entities;
using System.IO;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_AGENTEXPRESSOUT
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_AGENTEXPRESSOUT", false, 5, "快捷代发", AppliableFunctionType.AgentExpressOut)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
        }
        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.AgentExpressOut) return;
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
            if (agentExpressPanel_Out.HasData)
            {
                if (!bchpnlFastAgentOut.HasData)
                {
                    if (MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_AllRecord, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        CommandCenter.ResolveAgentExpress(OperatorCommandType.New, AppliableFunctionType.AgentExpressOut);
                    else
                        return;
                }
                bchpnlFastAgentOut.GetItem();
                if (bchpnlFastAgentOut.HasData && !agentExpressPanel_Out.SaveData(bchpnlFastAgentOut.BatchInfo, false)) return;
            }
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveAgentExpress(command, AppliableFunctionType.AgentExpressOut);
                CommandCenter.ResolveAgentExpress(OperatorCommandType.Reset, AppliableFunctionType.AgentExpressOut);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.AgentExpressOut, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            if (srAgentExpressOut.CheckData())
            {
                srAgentExpressOut.GetItem();
                AgentExpress ae = srAgentExpressOut.AgentExpress;
                CommandCenter.ResolveAgentExpress(command, ae, srAgentExpressOut.AppType, rowIndexPanel_ExpressOut.RowIndex);
                //if (srAgentExpressOut.CanAdd)
                CommandCenter.ResolvePayee(OperatorCommandType.Submit, new PayeeInfo { Account = ae.AccountNo, Name = ae.AccountName, OpenBankName = string.IsNullOrEmpty(ae.BankNo) ? "中国银行" : ae.BankName, CNAPSNo = ae.BankNo, BankType = string.IsNullOrEmpty(ae.BankNo) ? AccountBankType.BocAccount : AccountBankType.OtherBankAccount, ProvinceType = string.IsNullOrEmpty(ae.BankNo) ? ae.Province : ChinaProvinceType.B0 }, srAgentExpressOut.AppType, int.MaxValue);
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.AgentExpressOut, rowIndexPanel_ExpressOut.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveAgentExpress(command, null, AppliableFunctionType.AgentExpressOut, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = agentExpressPanel_Out.HasData;
                if (flag)
                {
                    if (!bchpnlFastAgentOut.CheckData() || !bchpnlFastAgentOut.CheckValid()) return;
                    bchpnlFastAgentOut.GetItem();
                    BatchHeader batch = bchpnlFastAgentOut.BatchInfo;
                    this.agentExpressPanel_Out.SaveData(batch, true);
                    if (batch.CanAddPayer) CommandCenter.ResolvePayer(OperatorCommandType.Submit, batch.Payer, AppliableFunctionType.AgentExpressOut, int.MaxValue);
                    if (batch.CanAddNotice)
                    {
                        //if (SystemSettings.Notices.ContainsKey(AppliableFunctionType.AgentExpressIn) && SystemSettings.Notices[AppliableFunctionType.AgentExpressIn].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                        //    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Addition_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                        //else
                        CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = batch.Addtion }, AppliableFunctionType.AgentExpressOut);
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
        /// <summary>
        /// 匹配错误文件
        /// </summary>
        private void MergErrorFileClicked(object sender, EventArgs e)
        {
            if (!agentExpressPanel_Out.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.AgentExpressOut, true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.AgentExpressOut, true);
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
