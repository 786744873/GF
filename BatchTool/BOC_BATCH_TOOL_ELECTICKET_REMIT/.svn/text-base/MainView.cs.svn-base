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
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.Entities;
using CommonClient.ConvertHelper;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_ELECTICKET_REMIT
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_ELECTICKET_REMIT", false, 11, "电票出票", AppliableFunctionType.ElecTicketRemit)]
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
                if (e.AppType != AppliableFunctionType.ElecTicketRemit) return;
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
            if (!elecTicketRemitItemsPanel.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveElecTicketRemit(command, AppliableFunctionType.ElecTicketRemit);
                CommandCenter.ResolveElecTicketRemit(OperatorCommandType.Reset, AppliableFunctionType.ElecTicketRemit);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.ElecTicketRemit, true);
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
                if (payerPnl_Remit.CheckData())
                {
                    payerPnl_Remit.GetItem();
                    payer = payerPnl_Remit.CurrentPayer;
                    payer.CashType = CashType.CNY;
                    payer.ServiceList = AppliableFunctionType.ElecTicketRemit | AppliableFunctionType.ElecTicketTipExchange;
                }


                ElecTicketRemit etRemit = null;
                if (ettiRemit.CheckData())
                {
                    ettiRemit.GetItem();
                    etRemit = ettiRemit.Remit;
                }


                ElecTicketRelationAccount etraExchange = null;
                if (etrasExchange.CheckData())
                {
                    etrasExchange.GetItem();
                    etraExchange = etrasExchange.CurrentRelateAccount;
                }


                ElecTicketRelationAccount etraPayee = null;
                if (etrasPayee.CheckData())
                {
                    etrasPayee.GetItem();
                    etraPayee = etrasPayee.CurrentRelateAccount;
                }


                ElecTicketRemit etRemitEx = null;
                if (etoeRemit.CheckData())
                {
                    etoeRemit.GetItem();
                    etRemitEx = etoeRemit.Remit;
                }
                if (null == payer) return;
                if (null == etRemit) return;
                if (null == etraExchange) return;
                if (null == etraPayee) return;
                if (null == etRemitEx) return;

                ElecTicketRemit remit = new ElecTicketRemit();

                remit.RemitAccount = payer.Account;
                remit.TicketType = etRemit.TicketType;
                remit.Amount = etRemit.Amount;
                remit.RemitDate = etRemit.RemitDate;
                remit.EndDate = etRemit.EndDate;
                remit.ExchangeAccount = etraExchange.Account;
                remit.ExchangeName = etraExchange.Name;
                remit.ExchangeOpenBankName = etraExchange.OpenBankName;
                remit.ExchangeOpenBankNo = etraExchange.OpenBankNo;
                remit.PayeeAccount = etraPayee.Account;
                remit.PayeeName = etraPayee.Name;
                remit.PayeeOpenBankName = etraPayee.OpenBankName;
                remit.PayeeOpenBankNo = etraPayee.OpenBankNo;
                remit.CanChange = etRemitEx.CanChange;
                remit.AutoTipExchange = etRemitEx.AutoTipExchange;
                remit.AutoTipReceiveTicket = etRemitEx.AutoTipReceiveTicket;
                remit.Note = etRemitEx.Note;

                CommandCenter.ResolveElecTicketRemit(command, remit, AppliableFunctionType.ElecTicketRemit, rowIndexPanel_Remit.RowIndex);

                //if (payerPnl_Remit.CanAdd)
                payer.CashType = CashType.CNY;
                CommandCenter.ResolvePayer(OperatorCommandType.Submit, payer, AppliableFunctionType.ElecTicketRemit, int.MaxValue);

                //if (etrasExchange.CanAdd)
                CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, etraExchange, int.MaxValue);

                //if (etrasPayee.CanAdd)
                CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, etraPayee, int.MaxValue);

                payerPnl_Remit.CurrentPayer = null;
                etrasExchange.CurrentRelateAccount = null;
                etrasPayee.CurrentRelateAccount = null;

            #endregion
        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.ElecTicketRemit, rowIndexPanel_Remit.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveElecTicketRemit(command, null, AppliableFunctionType.ElecTicketRemit, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.elecTicketRemitItemsPanel.HasData;
                if (flag) this.elecTicketRemitItemsPanel.SaveData(true);
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
            if (!elecTicketRemitItemsPanel.HasData)
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.ElecTicketRemit, true);
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
