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

namespace BOC_BATCH_TOOL_SPPLYFINANCING_APPLYOFFRANCHISERFINANCING
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_SPPLYFINANCING_APPLYOFFRANCHISERFINANCING", false, 26, "融资申请(经销商融资)", AppliableFunctionType.ApplyofFranchiserFinancing)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            this.fileOperatePanel25.ShowBtnMatchError(false);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
        }
        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.ApplyofFranchiserFinancing) return;
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
            if (!spplyFinancingApplyItemsPanel.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveSpplyFinancingApply(command, AppliableFunctionType.ApplyofFranchiserFinancing);
                CommandCenter.ResolveSpplyFinancingApply(OperatorCommandType.Reset, AppliableFunctionType.ApplyofFranchiserFinancing);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.ApplyofFranchiserFinancing, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
                SpplyFinancingApply sfaTemp = null;
                if (spplyFinancingApply.CheckData())
                {
                    spplyFinancingApply.GetItem();

                    sfaTemp = spplyFinancingApply.Apply;
                }
                if (null == sfaTemp) return;

                SpplyFinancingApply sfa = new SpplyFinancingApply();
                sfa.AgreementNo = sfaTemp.AgreementNo;
                sfa.ApplyAmount = sfaTemp.ApplyAmount;
                sfa.ApplyDays = sfaTemp.ApplyDays;
                sfa.ContractOrOrderAmount = sfaTemp.ContractOrOrderAmount;
                sfa.ContractOrOrderCashType = sfaTemp.ContractOrOrderCashType;
                sfa.ContractOrOrderNo = sfaTemp.ContractOrOrderNo;
                sfa.DeliveryDate = sfaTemp.DeliveryDate;
                sfa.GoodsDesc = sfaTemp.GoodsDesc;
                sfa.InterestFloatingPercent = sfaTemp.InterestFloatingPercent;
                sfa.InterestFloatType = sfaTemp.InterestFloatType;
                sfa.OrderDate = sfaTemp.OrderDate;
                sfa.ReceiptNo = sfaTemp.ReceiptNo;
                sfa.RiskTakingLetterNo = sfaTemp.RiskTakingLetterNo;
                sfa.SettlementType = sfaTemp.SettlementType;
                sfa.TaxInvoiceNo = sfaTemp.TaxInvoiceNo;

                CommandCenter.ResolveSpplyFinancingApply(command, sfa, AppliableFunctionType.ApplyofFranchiserFinancing, rowIndexPanel_Apply.RowIndex);

            }

        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.ApplyofFranchiserFinancing, rowIndexPanel_Apply.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveSpplyFinancingApply(command, null, AppliableFunctionType.ApplyofFranchiserFinancing, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.spplyFinancingApplyItemsPanel.HasData;
                if (flag) this.spplyFinancingApplyItemsPanel.SaveData(true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.ApplyofFranchiserFinancing, true);
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
