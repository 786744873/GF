using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.VisualParts;
using CommonClient.Contract;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient;
using CommonClient.ConvertHelper;
using System.IO;
using CommonClient.Entities;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_BL_AGENTEXPRESSOUT
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_BL_AGENTEXPRESSOUT", false, 102, "境内人民币汇划", AppliableFunctionType.AgentExpressOut4Bar)]
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
                if (e.AppType != AppliableFunctionType.AgentExpressOut4Bar) return;
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
            if (agentExpressItemsPanel_outBar.HasData)
            {
                if (!bchpnlFastAgent_OutBar.HasData)
                {
                    if (MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_AllRecord, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        CommandCenter.ResolveAgentExpress(OperatorCommandType.New, AppliableFunctionType.AgentExpressOut4Bar);
                    else
                        return;
                }
                bchpnlFastAgent_OutBar.GetItem();
                if (bchpnlFastAgent_OutBar.HasData && !agentExpressItemsPanel_outBar.SaveData(bchpnlFastAgent_OutBar.BatchInfo, false))
                    return;
            }
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveAgentExpress(command, AppliableFunctionType.AgentExpressOut4Bar);
                CommandCenter.ResolveAgentExpress(OperatorCommandType.Reset, AppliableFunctionType.AgentExpressOut4Bar);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.AgentExpressOut4Bar, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            if (agentExpressEditor_outBar.CheckData())
            {
                agentExpressEditor_outBar.GetItem();
                AgentExpress ae = agentExpressEditor_outBar.AgentExpress;
                CommandCenter.ResolveAgentExpress(command, ae, agentExpressEditor_outBar.AppType, rowIndexPanel_outBar.RowIndex);
                //if (srAgentExpressOut.CanAdd)
                CommandCenter.ResolvePayee(OperatorCommandType.Submit, new PayeeInfo { Account = ae.AccountNo, Name = ae.AccountName, OpenBankName = ae.BankName, CNAPSNo = ae.BankNo }, AppliableFunctionType.AgentExpressOut4Bar, int.MaxValue);
            }

        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.AgentExpressOut4Bar, rowIndexPanel_outBar.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveAgentExpress(command, null, AppliableFunctionType.AgentExpressOut4Bar, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = agentExpressItemsPanel_outBar.HasData;
                if (flag)
                {
                    if (!bchpnlFastAgent_OutBar.CheckData() || bchpnlFastAgent_OutBar.CheckValid()) return;
                    bchpnlFastAgent_OutBar.GetItem();
                    BatchHeader batch = bchpnlFastAgent_OutBar.BatchInfo;
                    this.agentExpressItemsPanel_outBar.SaveData(batch, true);
                    if (batch.CanAddPayer)
                    {
                        batch.Payer.CashType = CashType.CNY;
                        CommandCenter.ResolvePayer(OperatorCommandType.Submit, batch.Payer, AppliableFunctionType.AgentExpressOut4Bar, int.MaxValue);
                    }
                    if (batch.CanAddNotice)
                    {
                        if (SystemSettings.Notices.ContainsKey(AppliableFunctionType.AgentExpressOut4Bar) && SystemSettings.Notices[AppliableFunctionType.AgentExpressOut4Bar].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Addition_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Error);
                        else
                            CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = batch.Addtion }, AppliableFunctionType.AgentExpressOut4Bar);
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
            if (!agentExpressItemsPanel_outBar.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.AgentExpressOut4Bar, true);
        }
        /// <summary>
        /// 打印
        /// </summary>
        private void Print()
        {
            CommandCenter.ResolveTransferGlobal(OperatorCommandType.Print, AppliableFunctionType.AgentExpressOut4Bar);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.AgentExpressOut4Bar, true);
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
