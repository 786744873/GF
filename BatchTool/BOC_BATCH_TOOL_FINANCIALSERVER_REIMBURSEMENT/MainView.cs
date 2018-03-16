using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.VisualParts;
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.TemplateHelper;
using CommonClient.Entities;
using CommonClient;
using CommonClient.ConvertHelper;
using CommonClient.Contract;

namespace BOC_BATCH_TOOL_FINANCIALSERVER_REIMBURSEMENT
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_FINANCIALSERVER_REIMBURSEMENT", false, 29, "批量报销", AppliableFunctionType.BatchReimbursement)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            fileOperatePanel1.ShowBtnMatchError(false);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
        }
        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.BatchReimbursement) return;
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
            if (!batchReimbursementItemsPanel1.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveBatchReimbursement(command, AppliableFunctionType.BatchReimbursement);
                CommandCenter.ResolveBatchReimbursement(OperatorCommandType.Reset, AppliableFunctionType.BatchReimbursement);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.BatchReimbursement, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            BatchReimbursement sfaTemp = null;
            if (batchReimbursementSelector1.CheckData())
            {
                batchReimbursementSelector1.GetItem();
                sfaTemp = batchReimbursementSelector1.Reimbursement;
            }
            if (null == sfaTemp) return;

            BatchReimbursement sfa = new BatchReimbursement();
            sfa.CardNo = sfaTemp.CardNo;
            sfa.PayAmount = sfaTemp.PayAmount;
            sfa.PayDateTime = sfaTemp.PayDateTime;
            sfa.PayPassword = sfaTemp.PayPassword;
            sfa.ReimburseAmount = sfaTemp.ReimburseAmount;
            sfa.Usage = sfaTemp.Usage;

            CommandCenter.ResolveBatchReimbursement(command, sfa, AppliableFunctionType.BatchReimbursement, rowIndexPanel_BatchReimbursement.RowIndex);

            if (!string.IsNullOrEmpty(sfa.Usage))
            {
                //if (SystemSettings.Notices.ContainsKey(AppliableFunctionType.BatchReimbursement) && SystemSettings.Notices[AppliableFunctionType.BatchReimbursement].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                //    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Usege_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                //else
                CommandCenter.ResolveNotice(command, new NoticeInfo { Content = sfa.Usage }, AppliableFunctionType.BatchReimbursement);
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.BatchReimbursement, rowIndexPanel_BatchReimbursement.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveBatchReimbursement(command, null, AppliableFunctionType.BatchReimbursement, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.batchReimbursementItemsPanel1.HasData;
                if (flag) this.batchReimbursementItemsPanel1.SaveData(true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.BatchReimbursement, true);
        }

        private void fileOperatePanel1_ButtonUpClicked(object sender, EventArgs e)
        {
            DeleteOrReloadData(OperatorCommandType.DataMoveUp);
        }

        private void fileOperatePanel1_ButtonDownClicked(object sender, EventArgs e)
        {
            DeleteOrReloadData(OperatorCommandType.DataMoveDown);
        }

        private void fileOperatePanel1_ButtonMergErrorFileClicked(object sender, EventArgs e)
        {
            if (!batchReimbursementItemsPanel1.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.BatchReimbursement, true);
        }
    }
}
