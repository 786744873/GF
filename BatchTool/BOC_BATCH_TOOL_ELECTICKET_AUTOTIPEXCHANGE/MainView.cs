﻿using System;
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
using CommonClient.Entities;
using System.IO;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_ELECTICKET_AUTOTIPEXCHANGE
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_ELECTICKET_AUTOTIPEXCHANGE", false, 14, "电票提示承兑", AppliableFunctionType.ElecTicketTipExchange)]
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
                if (e.AppType != AppliableFunctionType.ElecTicketTipExchange) return;
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
            if (!elecTicketTipExchangeItemsPanel.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveElecTicketAutoTipExchange(command, AppliableFunctionType.ElecTicketTipExchange);
                CommandCenter.ResolveElecTicketAutoTipExchange(OperatorCommandType.Reset, AppliableFunctionType.ElecTicketTipExchange);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.ElecTicketTipExchange, true);
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
                if (payerPnl_TipExchange.CheckData())
                {
                    payerPnl_TipExchange.GetItem();
                    payer = payerPnl_TipExchange.CurrentPayer;
                    payer.CashType = CashType.CNY;
                    payer.ServiceList = AppliableFunctionType.ElecTicketRemit | AppliableFunctionType.ElecTicketTipExchange;
                }


                ElecTicketRelationAccount etra = null;
                elecTicketRealteAccount_TipExchange.GetItem();
                etra = elecTicketRealteAccount_TipExchange.CurrentRelateAccount;


                ElecTicketAutoTipExchange etateO = null;
                if (elecTicketOtherEditor_TipExchange.CheckData())
                {
                    elecTicketOtherEditor_TipExchange.GetItem();
                    etateO = elecTicketOtherEditor_TipExchange.TipExchange;
                }
                if (null == payer) return;
                if (null == etra) return;
                if (null == etateO) return;
                ElecTicketAutoTipExchange etate = new ElecTicketAutoTipExchange();
                etate.RemitAccount = payer.Account;
                etate.ElecTicketSerialNo = payer.Name;
                etate.ExchangeAccount = etra.Account;
                etate.ExchangeName = etra.Name;
                etate.ExchangeOpenBankName = etra.OpenBankName;
                etate.ExchangeOpenBankNo = etra.OpenBankNo;
                etate.BillSerialNo = etateO.BillSerialNo;
                etate.ContractNo = etateO.ContractNo;
                etate.Note = etateO.Note;

                payer.CashType = CashType.CNY;
                CommandCenter.ResolveElecTicketAutoTipExchange(command, etate, AppliableFunctionType.ElecTicketTipExchange, rowIndexPanel_TipExchange.RowIndex);

                //if (payerPnl_TipExchange.CanAdd)
                CommandCenter.ResolvePayer(OperatorCommandType.Submit, payer, AppliableFunctionType.ElecTicketTipExchange, int.MaxValue);

                //if (elecTicketRealteAccount_TipExchange.CanAdd)
                CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, etra, int.MaxValue);

                payerPnl_TipExchange.CurrentPayer = null;
                elecTicketRealteAccount_TipExchange.CurrentRelateAccount = null;
            }
            #endregion


        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.ElecTicketTipExchange, rowIndexPanel_TipExchange.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveElecTicketAutoTipExchange(command, null, AppliableFunctionType.ElecTicketTipExchange, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.elecTicketTipExchangeItemsPanel.HasData;
                if (flag) this.elecTicketTipExchangeItemsPanel.SaveData(true);
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
            if (!elecTicketTipExchangeItemsPanel.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.ElecTicketTipExchange, true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.ElecTicketTipExchange, true);
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
