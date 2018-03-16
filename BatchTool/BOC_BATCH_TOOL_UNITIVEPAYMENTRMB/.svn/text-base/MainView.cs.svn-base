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
using System.IO;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.TemplateHelper;
using CommonClient.Controls;
namespace BOC_BATCH_TOOL_UNITIVEPAYMENTRMB
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_UNITIVEPAYMENTRMB", false, 27, "人民币统一支付", AppliableFunctionType.UnitivePaymentRMB)]
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
                if (e.AppType != AppliableFunctionType.UnitivePaymentRMB) return;
                if (e.Command == OperatorCommandType.EditOperatorCallBack)
                    SubmitData(OperatorCommandType.Edit);
            }
        }
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="command"></param>
        private void OpenOrCreateData(OperatorCommandType command)
        {
            if (!unitivePaymentItemsPanel_UnitivePaymentRMB.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveUnitivePaymentRMB(command, AppliableFunctionType.UnitivePaymentRMB);
                CommandCenter.ResolveUnitivePaymentRMB(OperatorCommandType.Reset, AppliableFunctionType.UnitivePaymentRMB);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.UnitivePaymentRMB, true);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            PayerInfo payer = null;
            if (payerSelector_UnitivePaymentRMB.CheckData())
            {
                payerSelector_UnitivePaymentRMB.GetItem();
                payer = payerSelector_UnitivePaymentRMB.CurrentPayer;
            }

            PayeeInfo payee = null;
            if (payeeSelector_UnitivePaymentRMB.CheckData())
            {
                payeeSelector_UnitivePaymentRMB.GetItem();
                payee = payeeSelector_UnitivePaymentRMB.CurrentPayee;
            }

            UnitivePaymentRMB payerUp = null;
            if (unitivePaymentPayerSelector_RMB.CheckData())
            {
                unitivePaymentPayerSelector_RMB.GetItem();
                payerUp = unitivePaymentPayerSelector_RMB.CurrentUnitivePaymentRMB;
            }

            UnitivePaymentRMB otherUp = null;
            if (unitivePaymentOther_RMB.CheckData())
            {
                unitivePaymentOther_RMB.GetItem();
                otherUp = unitivePaymentOther_RMB.CurrentUnitivePaymentRMB;
            }
            if (null == payer) return;
            if (null == payee) return;
            if (null == payerUp) return;
            if (null == otherUp) return;

            UnitivePaymentRMB UPItem = new UnitivePaymentRMB();
            UPItem.PayerAccount = payer.Account;
            UPItem.PayerName = payer.Name;
            UPItem.PayeeAccount = payee.Account;
            UPItem.PayeeName = payee.Name;
            UPItem.BankType = payee.BankType;
            if (payee.BankType == AccountBankType.OtherBankAccount)
            {
                UPItem.PayeeOpenBankName = payee.OpenBankName;
                UPItem.PayeeCNAPS = payee.CNAPSNo;
            }
            UPItem.BankType = payee.BankType;
            UPItem.NominalPayerAccount = payerUp.NominalPayerAccount;
            UPItem.NominalPayerName = payerUp.NominalPayerName;
            UPItem.Amount = otherUp.Amount;
            UPItem.Purpose = otherUp.Purpose;
            UPItem.UnitivePaymentType = otherUp.UnitivePaymentType;
            UPItem.OrderPayDate = otherUp.OrderPayDate;
            UPItem.OrderPayTime = otherUp.OrderPayTime;
            UPItem.CustomerBusinissNo = otherUp.CustomerBusinissNo;
            UPItem.TransferChanelType = otherUp.TransferChanelType;
            UPItem.IsTipPayee = otherUp.IsTipPayee;
            UPItem.TipPayeePhone = otherUp.TipPayeePhone;

            CommandCenter.ResolveUnitivePaymentRMB(command, UPItem, AppliableFunctionType.UnitivePaymentRMB, rowIndexPanel_UnitivePaymentRMB.RowIndex);
            payer.CashType = CashType.CNY;
            CommandCenter.ResolvePayer(OperatorCommandType.Submit, payer, AppliableFunctionType.UnitivePaymentRMB, int.MaxValue);
            CommandCenter.ResolvePayee(OperatorCommandType.Submit, payee, AppliableFunctionType.UnitivePaymentRMB, int.MaxValue);

            payerSelector_UnitivePaymentRMB.CurrentPayer = null;
            payeeSelector_UnitivePaymentRMB.CurrentPayee = null;
            unitivePaymentPayerSelector_RMB.CurrentUnitivePaymentRMB = null;
            unitivePaymentOther_RMB.CurrentUnitivePaymentRMB = null;
        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.UnitivePaymentRMB, rowIndexPanel_UnitivePaymentRMB.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveUnitivePaymentRMB(command, null, AppliableFunctionType.UnitivePaymentRMB, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.unitivePaymentItemsPanel_UnitivePaymentRMB.HasData;
                if (flag) this.unitivePaymentItemsPanel_UnitivePaymentRMB.SaveData(true);
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
            if (!unitivePaymentItemsPanel_UnitivePaymentRMB.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.UnitivePaymentRMB, true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.UnitivePaymentRMB, true);
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
