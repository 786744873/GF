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
using CommonClient.ConvertHelper;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using System.IO;
using CommonClient.Entities;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_TRANSFER_INDIVIDUAL
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_TRANSFER_INDIVIDUAL", false, 2, "对私汇款", AppliableFunctionType.TransferWithIndiv)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
        }

        bool m_lockState = false;

        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.TransferWithIndiv) return;
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
            if (!transferItemsPanelInvid.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveTransferAccount(command, AppliableFunctionType.TransferWithIndiv);
                CommandCenter.ResolveTransferAccount(OperatorCommandType.Reset, AppliableFunctionType.TransferWithIndiv);
            }
            if (OperatorCommandType.Open == command)
            {
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.TransferWithIndiv, true);
            }
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
                PayerInfo payer = null;
                if (payerPnl_Ind.CheckData())
                {
                    payerPnl_Ind.GetItem();
                    payer = payerPnl_Ind.CurrentPayer;
                }

                PayeeInfo payee = null;
                if (payeePnl_P.CheckData())
                {
                    payeePnl_P.GetItem();
                    payee = payeePnl_P.CurrentPayee;
                }

                TransferAccount transfer = null;
                if (transferEditor_P.CheckData())
                {
                    transferEditor_P.GetItem();
                    transfer = transferEditor_P.Transfer;
                }
                if (null == payer) return;
                if (null == payee) return;
                if (null == transfer) return;

                //合并数据
                transfer.PayerAccount = payer.Account;
                transfer.PayerName = payer.Name;
                transfer.PayeeName = payee.Name;
                transfer.PayeeAccount = payee.Account;
                transfer.PayeeOpenBank = payee.OpenBankName;
                transfer.PayeeAddress = payee.Address;
                transfer.CNAPSNo = payee.CNAPSNo;
                transfer.AccountBankType = payee.BankType;
                if (string.IsNullOrEmpty(transfer.PayFeeNo) && ChargingFeeAccountType.SameAsPayingAccount == transfer.PayFeeType)
                    transfer.PayFeeNo = payer.Account;

                //转账汇款（对私）
                TransferOperation(payer, payee, transfer, rowIndexPanel_Ind.RowIndex, payerPnl_Ind.CanAdd, payeePnl_P.isNew, transferEditor_P.CanAddNotice, OperatorCommandType.Submit, AppliableFunctionType.TransferWithIndiv, AccountCategoryType.Personal, command);
                payerPnl_Ind.CurrentPayer = null;
                payeePnl_P.CurrentPayee = null;
                transferEditor_P.Transfer = null;

            
        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.TransferWithIndiv, rowIndexPanel_Ind.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveTransferAccount(command, null, AppliableFunctionType.TransferWithIndiv, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.transferItemsPanelInvid.HasData;
                if (flag) this.transferItemsPanelInvid.SaveData(true);
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
            if (!transferItemsPanelInvid.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.TransferWithIndiv, true);
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
                //if (SystemSettings.Notices.ContainsKey(aft) && SystemSettings.Notices[aft].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                //    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Usege_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                //else
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.TransferWithIndiv, true);
        }

        private void dataOperatePanel1_ButtonLockClicked(object sender, EventArgs e)
        {
            m_lockState = !m_lockState;
            CommandCenter.ResolveCommonData(m_lockState ? OperatorCommandType.CommonFieldLockShow : OperatorCommandType.CommonFieldLockHide, new Dictionary<AppliableFunctionType, CommonFieldType>() { { AppliableFunctionType.TransferWithIndiv, CommonFieldType.Empty } });
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
