using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.VisualParts;
using CommonClient.SysCoach;
using CommonClient.Contract;
using CommonClient.Entities;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient;
using System.IO;
using CommonClient.TemplateHelper;
using CommonClient.Controls;
using CommonClient.Utilities;

namespace BOC_BATCH_TOOL_AGENTEXPRESSIN
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_AGENTEXPRESSIN", true, 6, "快捷代收", AppliableFunctionType.AgentExpressIn)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            this.panel3.BackgroundImage = CommonClient.Properties.Resources.pin;
        }
        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.AgentExpressIn) return;
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
            if (agentExpressPanel_In.HasData)
            {
                if (!bchpnlFastAgentIn.HasData)
                {
                    if (MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_AllRecord, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        CommandCenter.ResolveAgentExpress(OperatorCommandType.New, AppliableFunctionType.AgentExpressIn);
                    else
                        return;
                }
                bchpnlFastAgentIn.GetItem();
                if (bchpnlFastAgentIn.HasData && !agentExpressPanel_In.SaveData(bchpnlFastAgentIn.BatchInfo, false)) return;
            }
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveAgentExpress(command, AppliableFunctionType.AgentExpressIn);
                CommandCenter.ResolveAgentExpress(OperatorCommandType.Reset, AppliableFunctionType.AgentExpressIn);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.AgentExpressIn, true);

            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            if (srAgentExpressIn.CheckData())
            {
                srAgentExpressIn.GetItem();
                AgentExpress ae = srAgentExpressIn.AgentExpress;
                CommandCenter.ResolveAgentExpress(command, ae, srAgentExpressIn.AppType, rowIndexPanel_ExpressIn.RowIndex);
                //if (srAgentExpressIn.CanAdd)
                AccountBankType banktype = ae.Province == ChinaProvinceType.B0 ? AccountBankType.OtherBankAccount : AccountBankType.BocAccount;

                //CommandCenter.ResolveAgentExpressPayer(OperatorCommandType.Submit, new PayeeInfo { BankType = banktype, OpenBankName = banktype == AccountBankType.OtherBankAccount ? string.Empty : EnumNameHelper<AccountBankType>.GetEnumDescription(banktype), Account = ae.AccountNo, Name = ae.AccountName, CertifyPaperType = ae.CertifyPaperType, CertifyPaperNo = ae.CertifyPaperNo, ProtecolNo = ae.ProtecolNo, ProvinceType = ae.Province, }, srAgentExpressIn.AppType, int.MaxValue);
                CommandCenter.ResolveAgentExpressPayer(OperatorCommandType.Submit, new PayeeInfo { BankType = banktype, OpenBankName = banktype == AccountBankType.OtherBankAccount ? ae.BankName : EnumNameHelper<AccountBankType>.GetEnumDescription(banktype), CNAPSNo = ae.BankNo, Account = ae.AccountNo, Name = ae.AccountName, ProtecolNo = ae.ProtecolNo, ProvinceType = string.IsNullOrEmpty(ae.BankNo) ? ae.Province : ChinaProvinceType.B0, }, srAgentExpressIn.AppType, int.MaxValue);
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.AgentExpressIn, rowIndexPanel_ExpressIn.RowIndex);
        }

        /// <summary>
        /// 删除 重置 上移 下移
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveAgentExpress(command, null, AppliableFunctionType.AgentExpressIn, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            try
            {
                if (agentExpressPanel_In.HasData)
                {
                    if (!bchpnlFastAgentIn.CheckData() || !bchpnlFastAgentIn.CheckValid()) return;
                    bchpnlFastAgentIn.GetItem();
                    BatchHeader batch = bchpnlFastAgentIn.BatchInfo;
                    this.agentExpressPanel_In.SaveData(batch, true);
                    if (batch.CanAddPayer) CommandCenter.ResolvePayer(OperatorCommandType.Submit, batch.Payer, AppliableFunctionType.AgentExpressIn, int.MaxValue);
                    if (batch.CanAddNotice)
                    {
                        //if (SystemSettings.Notices.ContainsKey(AppliableFunctionType.AgentExpressIn) && SystemSettings.Notices[AppliableFunctionType.AgentExpressIn].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                        //    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Addition_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                        //else
                        CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = batch.Addtion }, AppliableFunctionType.AgentExpressIn);
                    }
                }
                else
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
            if (!agentExpressPanel_In.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.AgentExpressIn, true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.AgentExpressIn, true);
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
