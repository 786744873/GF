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
using CommonClient;
using System.IO;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_SPPLYFINANCING_PAYMENTORRECEIPTOFDEBTRECEIVABLE
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_SPPLYFINANCING_PAYMENTORRECEIPTOFDEBTRECEIVABLE", false, 25, "收付款信息提交(应收账款保理池融资)", AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            this.fileOperatePanel24.ShowBtnMatchError(false);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
        }
        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser) return;
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
            if (!spplyFinancingItemsPanel_Payment.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveSpplyFinancingPayOrReceipt(command, AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser);
                CommandCenter.ResolveSpplyFinancingPayOrReceipt(OperatorCommandType.Reset, AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            SpplyFinancingPayOrReceipt sfprTemp = null;

            if (spplyFinancing_Payment.CheckData())
            {
                spplyFinancing_Payment.GetItem();
                sfprTemp = spplyFinancing_Payment.PayOrReceipt;
            }
            if (null == sfprTemp) return;

            SpplyFinancingPayOrReceipt sfpr = new SpplyFinancingPayOrReceipt();
            sfpr.BillSerialNo = sfprTemp.BillSerialNo;
            sfpr.CashType = sfprTemp.CashType;
            sfpr.CustomerName = sfprTemp.CustomerName;
            sfpr.CustomerNo = sfprTemp.CustomerNo;
            sfpr.PayAmountForThisTime = sfprTemp.PayAmountForThisTime;

            int rowindex = rowIndexPanel_Payment.RowIndex;

            CommandCenter.ResolveSpplyFinancingPayOrReceipt(command, sfpr, AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser, rowindex);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser, rowIndexPanel_Payment.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveSpplyFinancingPayOrReceipt(command, null, AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.spplyFinancingItemsPanel_Payment.HasData;
                if (flag) this.spplyFinancingItemsPanel_Payment.SaveData(true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser, true);
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
