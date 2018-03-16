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
using CommonClient.ConvertHelper;
using System.IO;
using CommonClient;
using CommonClient.Entities;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_SPPLYFINANCING_BILLOFDEBTRECEIVABLESELLER
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_SPPLYFINANCING_BILLOFDEBTRECEIVABLESELLER", false, 24, "应收账款卖方发票(应收账款保理池融资)", AppliableFunctionType.BillofDebtReceivableSeller)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            this.fileOperatePanel23.ShowBtnMatchError(false);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
        }
        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.BillofDebtReceivableSeller) return;
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
            if (!spplyFinancingBillItemsPanel_Seller.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveSpplyFinancingBill(command, AppliableFunctionType.BillofDebtReceivableSeller);
                CommandCenter.ResolveSpplyFinancingBill(OperatorCommandType.Reset, AppliableFunctionType.BillofDebtReceivableSeller);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.BillofDebtReceivableSeller, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            SpplyFinancingBill sfbTemp = null;

            if (spplyFinancingBill_Seller.CheckData())
            {
                spplyFinancingBill_Seller.GetItem();
                sfbTemp = spplyFinancingBill_Seller.Bill;
            }

            if (null == sfbTemp) return;

            SpplyFinancingBill sfb = new SpplyFinancingBill();
            sfb.Amount = sfbTemp.Amount;
            sfb.BillDate = sfbTemp.BillDate;
            sfb.BillSerialNo = sfbTemp.BillSerialNo;
            sfb.CashType = sfbTemp.CashType;
            sfb.ContractNo = sfbTemp.ContractNo;
            sfb.CustomerName = sfbTemp.CustomerName;
            sfb.CustomerNo = sfbTemp.CustomerNo;
            sfb.EndDate = sfbTemp.EndDate;
            sfb.StartDate = sfbTemp.StartDate;

            int rowindex = rowIndexPanel_BillSeller.RowIndex;

            CommandCenter.ResolveSpplyFinancingBill(command, sfb, AppliableFunctionType.BillofDebtReceivableSeller, rowindex);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.BillofDebtReceivableSeller, rowIndexPanel_BillSeller.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveSpplyFinancingBill(command, null, AppliableFunctionType.BillofDebtReceivableSeller, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.spplyFinancingBillItemsPanel_Seller.HasData;
                if (flag) this.spplyFinancingBillItemsPanel_Seller.SaveData(true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.BillofDebtReceivableSeller, true);
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
