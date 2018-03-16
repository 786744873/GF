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
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.ConvertHelper;
using System.IO;
using CommonClient;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_ELECTICKET_BACKEDNOTE
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_ELECTICKET_BACKEDNOTE", false, 12, "电票背书", AppliableFunctionType.ElecTicketBackNote)]
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
                if (e.AppType != AppliableFunctionType.ElecTicketBackNote) return;
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
            if (!elecTicketBackNoteItemsPanel.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveElecTicketBackNote(command, AppliableFunctionType.ElecTicketBackNote);
                CommandCenter.ResolveElecTicketBackNote(OperatorCommandType.Reset, AppliableFunctionType.ElecTicketBackNote);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.ElecTicketBackNote, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
                PayerInfo payer = null;
                if (payerPnl_BackNote.CheckData())
                {
                    payerPnl_BackNote.GetItem();
                    payer = payerPnl_BackNote.CurrentPayer;
                    payer.CashType = CashType.CNY;
                    payer.ServiceList = AppliableFunctionType.ElecTicketPayMoney | AppliableFunctionType.ElecTicketBackNote;
                }


                ElecTicketRelationAccount etra = null;
                if (elecTicketRealteAccount_BackNote.CheckData())
                {
                    elecTicketRealteAccount_BackNote.GetItem();
                    etra = elecTicketRealteAccount_BackNote.CurrentRelateAccount;
                }


                ElecTicketBackNote etbn = null;
                if (elecTicketOtherEditor_BackNote.CheckData())
                {
                    elecTicketOtherEditor_BackNote.GetItem();
                    etbn = elecTicketOtherEditor_BackNote.BackNote;
                }
                if (null == payer) return;
                if (null == etra) return;
                if (null == etbn) return;

                ElecTicketBackNote result = new ElecTicketBackNote();
                result.RemitAccount = payer.Account;
                result.ElecTicketSerialNo = payer.Name;
                result.BackNotedAccount = etra.Account;
                result.BackNotedName = etra.Name;
                result.BackNotedOpenBankName = etra.OpenBankName;
                result.BackNotedOpenBankNo = etra.OpenBankNo;
                result.Note = etbn.Note;

                CommandCenter.ResolveElecTicketBackNote(command, result, AppliableFunctionType.ElecTicketBackNote, rowIndexPanel_BackNote.RowIndex);

                //if (payerPnl_BackNote.CanAdd)
                payer.CashType = CashType.CNY;
                CommandCenter.ResolvePayer(OperatorCommandType.Submit, payer, AppliableFunctionType.ElecTicketBackNote, int.MaxValue);

                //if (elecTicketRealteAccount_BackNote.CanAdd)
                CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, etra, int.MaxValue);

                payerPnl_BackNote.CurrentPayer = null;
                elecTicketRealteAccount_BackNote.CurrentRelateAccount = null;
                elecTicketOtherEditor_BackNote.BackNote = null;

           
        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.ElecTicketBackNote, rowIndexPanel_BackNote.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveElecTicketBackNote(command, null, AppliableFunctionType.ElecTicketBackNote, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.elecTicketBackNoteItemsPanel.HasData;
                if (flag) this.elecTicketBackNoteItemsPanel.SaveData(true);
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
            if (!elecTicketBackNoteItemsPanel.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.ElecTicketBackNote, true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.ElecTicketBackNote, true);
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
