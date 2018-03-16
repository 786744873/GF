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
using CommonClient;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.ConvertHelper;
using System.IO;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_TRANSFER_OVERBANKOUT
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_TRANSFER_OVERBANKOUT", false, 3, "跨行速汇(付款)", AppliableFunctionType.TransferOverBankOut)]
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
                if (e.AppType != AppliableFunctionType.TransferOverBankOut) return;
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
            if (!transferOverBankItemPanelOut.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveTransferAccount(command, AppliableFunctionType.TransferOverBankOut);
                CommandCenter.ResolveTransferAccount(OperatorCommandType.Reset, AppliableFunctionType.TransferOverBankOut);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.TransferOverBankOut, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            PayerInfo payer = null;
            if (payerPnl_OverBankOut.CheckData())
            {
                payerPnl_OverBankOut.GetItem();
                payer = payerPnl_OverBankOut.CurrentPayer;
            }

            PayeeInfo payee = null;
            if (payeePnl_OverBankOut.CheckData())
            {
                payeePnl_OverBankOut.GetItem();
                payee = payeePnl_OverBankOut.CurrentPayee;
            }

            TransferAccount transfer = null;
            if (transferEditor_OverBankOut.CheckData())
            {
                transferEditor_OverBankOut.GetItem();
                transfer = transferEditor_OverBankOut.Transfer;
            }
            if (null == payer) return;
            if (null == payee) return;
            if (null == transfer) return;

            //合并数据
            transfer.PayerAccount = payer.Account;
            transfer.PayerName = payer.Name;
            transfer.PayeeName = payee.Name;
            transfer.PayeeAccount = payee.Account;
            transfer.PayeeOpenBank = payee.ClearBankName;
            transfer.PayBankNo = payee.CNAPSNoR;
            transfer.PayeeAddress = payee.Address;
            transfer.Email = payee.Email;
            transfer.AccountBankType = payee.BankType;
            if (string.IsNullOrEmpty(transfer.PayFeeNo) && ChargingFeeAccountType.SameAsPayingAccount == transfer.PayFeeType)
                transfer.PayFeeNo = payer.Account;

            //跨行速汇（付款）
            TransferOperation(payer, payee, transfer, rowIndexPanel_OverBankOut.RowIndex, payerPnl_OverBankOut.CanAdd, payeePnl_OverBankOut.isNew, transferEditor_OverBankOut.CanAddNotice, OperatorCommandType.Submit, AppliableFunctionType.TransferOverBankOut, AccountCategoryType.Empty, command);
            payerPnl_OverBankOut.CurrentPayer = null;
            payeePnl_OverBankOut.CurrentPayee = null;
            transferEditor_OverBankOut.Transfer = null;

        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.TransferOverBankOut, rowIndexPanel_OverBankOut.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveTransferAccount(command, null, AppliableFunctionType.TransferOverBankOut, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.transferOverBankItemPanelOut.HasData;
                if (flag) this.transferOverBankItemPanelOut.SaveData(true);
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
            if (!transferOverBankItemPanelOut.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.TransferOverBankOut, true);
        }
        private void TransferOperation(PayerInfo payer, PayeeInfo payee, TransferAccount transfer, int rowindex, bool payerAdd, bool payeeAdd, bool noticeAdd, OperatorCommandType oc, AppliableFunctionType aft, AccountCategoryType act, OperatorCommandType batchCommand)
        {
            //转账汇款
            CommandCenter.ResolveTransferAccount(batchCommand, transfer, aft, rowindex);

            if (aft != AppliableFunctionType.TransferOverBankIn)
            {
                //付款人信息
                if (null != payer)//&& payerAdd)
                {
                    payer.CashType = CashType.CNY;
                    CommandCenter.ResolvePayer(oc, payer, aft, int.MaxValue);
                }

                //收款人信息
                if (null != payee)//&& payeeAdd)
                {
                    payee.AccountType = act;
                    CommandCenter.ResolvePayee(oc, payee, aft, int.MaxValue);
                }
            }

            //用途
            if (null != transfer && noticeAdd)
            {
                if (SystemSettings.Notices.ContainsKey(aft) && SystemSettings.Notices[aft].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Usege_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                else
                    CommandCenter.ResolveNotice(oc, new NoticeInfo { Content = transfer.Addition }, aft);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.TransferOverBankOut, true);
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
