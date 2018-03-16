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
using CommonClient.SysCoach;
using CommonClient.Entities;
using CommonClient.ConvertHelper;
using System.IO;
using CommonClient;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_INITIATIVEALLOT
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_INITIATIVEALLOT", false, 16, "批量主动调拨", AppliableFunctionType.InitiativeAllot)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            this.fileOperatePanel17.ShowBtnMatchError(false);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
        }
        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.InitiativeAllot) return;
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
            if (initiativeAllotItemsPanel.HasData)
            {
                if (!this.batchInitiativeAllotHeader.HasData)
                {
                    if (MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_AllRecord, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        CommandCenter.ResolveInitiativeAllot(OperatorCommandType.New, AppliableFunctionType.InitiativeAllot);
                    else
                        return;
                }
                batchInitiativeAllotHeader.GetItem();
                if (batchInitiativeAllotHeader.HasData && !initiativeAllotItemsPanel.SaveData(batchInitiativeAllotHeader.BatchInfo, false)) return;
            }
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveInitiativeAllot(command, AppliableFunctionType.InitiativeAllot);
                CommandCenter.ResolveInitiativeAllot(OperatorCommandType.Reset, AppliableFunctionType.InitiativeAllot);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.InitiativeAllot, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            if (this.initiativeAllotEditor.CheckData())
            {
                initiativeAllotEditor.GetItem();
                InitiativeAllot ia = initiativeAllotEditor.InitiativeAllot;
                CommandCenter.ResolveInitiativeAllot(command, ia, initiativeAllotEditor.AppType, rowIndexPanel_InitiativeAllot.RowIndex);
                if (initiativeAllotEditor.CanAddOut)
                    CommandCenter.ResolveInitiativeAllotAccount(OperatorCommandType.Submit, new InitiativeAllotAccount { Account = ia.AccountOut, Name = ia.NameOut }, initiativeAllotEditor.AppType, int.MaxValue);
                if (initiativeAllotEditor.CanAddIn)
                    CommandCenter.ResolveInitiativeAllotAccount(OperatorCommandType.Submit, new InitiativeAllotAccount { Account = ia.AccountIn, Name = ia.NameIn }, initiativeAllotEditor.AppType, int.MaxValue);
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.InitiativeAllot, rowIndexPanel_InitiativeAllot.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveInitiativeAllot(command, null, AppliableFunctionType.InitiativeAllot, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.initiativeAllotItemsPanel.HasData;
                if (flag)
                {
                    if (!batchInitiativeAllotHeader.CheckData() && batchInitiativeAllotHeader.CheckValid()) return;
                    batchInitiativeAllotHeader.GetItem();
                    BatchHeader batch = batchInitiativeAllotHeader.BatchInfo;
                    this.initiativeAllotItemsPanel.SaveData(batch, true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.InitiativeAllot, true);
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
