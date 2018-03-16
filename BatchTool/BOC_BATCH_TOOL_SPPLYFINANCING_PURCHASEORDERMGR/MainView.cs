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
using System.IO;
using CommonClient.ConvertHelper;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_SPPLYFINANCING_PURCHASEORDERMGR
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_SPPLYFINANCING_PURCHASEORDERMGR", false, 21, "买方订单管理(订单融资)", AppliableFunctionType.PurchaserOrderMgr)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            this.fileOperatePanel20.ShowBtnMatchError(false);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
        }
        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.PurchaserOrderMgr) return;
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
            if (!spplyFinancingPurchaseOrderMgrItemsPanel.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveSpplyFinancingOrder(command, AppliableFunctionType.PurchaserOrderMgr);
                CommandCenter.ResolveSpplyFinancingOrder(OperatorCommandType.Reset, AppliableFunctionType.PurchaserOrderMgr);
            }
            if (OperatorCommandType.Open == command)
                //LoadFiles(command, AppliableFunctionType.PurchaserOrderMgr, true);
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.PurchaserOrderMgr, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            SpplyFinancingOrder sfoTemp = null;

            if (spplyFinancingOrderMgr_Purchase.CheckData())
            {
                spplyFinancingOrderMgr_Purchase.GetItem();
                sfoTemp = spplyFinancingOrderMgr_Purchase.Order;
            }

            if (null == sfoTemp) return;

            SpplyFinancingOrder sfo = new SpplyFinancingOrder();
            sfo.OrderNo = sfoTemp.OrderNo;
            sfo.Amount = sfoTemp.Amount;

            int rowindex = rowIndexPanel_OrderMgrPurchase.RowIndex;

            CommandCenter.ResolveSpplyFinancingOrder(command, sfo, AppliableFunctionType.PurchaserOrderMgr, rowindex);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.PurchaserOrderMgr, rowIndexPanel_OrderMgrPurchase.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveSpplyFinancingOrder(command, null, AppliableFunctionType.PurchaserOrderMgr, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.spplyFinancingPurchaseOrderMgrItemsPanel.HasData;
                if (flag) this.spplyFinancingPurchaseOrderMgrItemsPanel.SaveData(true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.PurchaserOrderMgr, true);
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
