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

namespace BOC_BATCH_TOOL_ELECTICKET_STICKON
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_ELECTICKET_STICKON", false, 13, "电票贴现", AppliableFunctionType.ElecTicketPayMoney)]
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
                if (e.AppType != AppliableFunctionType.ElecTicketPayMoney) return;
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
            if (!elecTicketPayMoneyItemsPanel.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveElecTicketPayMoney(command, AppliableFunctionType.ElecTicketPayMoney);
                CommandCenter.ResolveElecTicketPayMoney(OperatorCommandType.Reset, AppliableFunctionType.ElecTicketPayMoney);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.ElecTicketPayMoney, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            #region
                PayerInfo payer = null;
                if (payerPnl_PayMoney.CheckValid())
                {
                    payerPnl_PayMoney.GetItem();
                    payer = payerPnl_PayMoney.CurrentPayer;
                    payer.CashType = CashType.CNY;
                    payer.ServiceList = AppliableFunctionType.ElecTicketPayMoney | AppliableFunctionType.ElecTicketBackNote;
                }

                ElecTicketPayMoney etpmStickOn = null;
                if (elecTicketStickOn_PayMoney.CheckData())
                {
                    elecTicketStickOn_PayMoney.GetItem();
                    etpmStickOn = elecTicketStickOn_PayMoney.PayMoney;
                }

                ElecTicketRelationAccount etra = null;
                if (elecTicketRelateAccount_PayMoney.CheckData())
                {
                    elecTicketRelateAccount_PayMoney.GetItem();
                    etra = elecTicketRelateAccount_PayMoney.CurrentRelateAccount;
                }


                ElecTicketPayMoney etpmOther = null;
                if (elecTicketOther_PayMoney.CheckData())
                {
                    elecTicketOther_PayMoney.GetItem();
                    etpmOther = elecTicketOther_PayMoney.PayMoney;
                }
                if (null == payer) return;
                if (null == etpmStickOn) return;
                if (null == etra) return;
                if (null == etpmOther) return;

                ElecTicketPayMoney etpm = new ElecTicketPayMoney();
                etpm.RemitAccount = payer.Account;
                etpm.ElecTicketSerialNo = payer.Name;
                etpm.PayMoneyType =
                etpm.PayMoneyType = etpmStickOn.PayMoneyType;
                etpm.ClearType = etpmStickOn.ClearType;
                etpm.PayMoneyDate = etpmStickOn.PayMoneyDate;
                etpm.PayMoneyPercent = etpmStickOn.PayMoneyPercent;
                etpm.PayMoneyAccount = etpmStickOn.PayMoneyAccount;
                etpm.PayMoneyOpenBankName = etpmStickOn.PayMoneyOpenBankName;
                etpm.PayMoneyOpenBankNo = etpmStickOn.PayMoneyOpenBankNo;
                etpm.ProtocolMoneyType = etpmStickOn.ProtocolMoneyType;
                etpm.ProtocolMoneyPercent = etpmStickOn.ProtocolMoneyPercent;
                etpm.StickOnAccount = etra.Account;
                etpm.StickOnName = etra.Name;
                etpm.StickOnOpenBankName = etra.OpenBankName;
                etpm.StickOnOpenBankNo = etra.OpenBankNo;
                etpm.BillSerialNo = etpmOther.BillSerialNo;
                etpm.ContractNo = etpmOther.ContractNo;
                etpm.Note = etpmOther.Note;

                CommandCenter.ResolveElecTicketPayMoney(command, etpm, AppliableFunctionType.ElecTicketPayMoney, rowIndexPanel_PayMoney.RowIndex);

                //if (payerPnl_PayMoney.CanAdd)
                payer.CashType = CashType.CNY;
                CommandCenter.ResolvePayer(OperatorCommandType.Submit, payer, AppliableFunctionType.ElecTicketPayMoney, int.MaxValue);

                //if (elecTicketRelateAccount_PayMoney.CanAdd)
                CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, etra, int.MaxValue);

                payerPnl_PayMoney.CurrentPayer = null;
                elecTicketRelateAccount_PayMoney.CurrentRelateAccount = null;

            
            #endregion
        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.ElecTicketPayMoney, rowIndexPanel_PayMoney.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveElecTicketPayMoney(command, null, AppliableFunctionType.ElecTicketPayMoney, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.elecTicketPayMoneyItemsPanel.HasData;
                if (flag) this.elecTicketPayMoneyItemsPanel.SaveData(true);
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
            if (!elecTicketPayMoneyItemsPanel.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.ElecTicketRemit, true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.ElecTicketPayMoney, true);
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
