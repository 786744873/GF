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
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using System.IO;
using CommonClient.Entities;
using CommonClient.TemplateHelper;
using CommonClient.Controls;

namespace BOC_BATCH_TOOL_ELECTICKET_POOL
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_ELECTICKET_POOL", false, 15, "票据池", AppliableFunctionType.ElecTicketPool)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            CommandCenter.OnElecTicketPoolEventHandler += new EventHandler<ElecTicketPoolEventArgs>(CommandCenter_OnElecTicketPoolEventHandler);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
        }
        void CommandCenter_OnElecTicketPoolEventHandler(object sender, ElecTicketPoolEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ElecTicketPoolEventArgs>(CommandCenter_OnElecTicketPoolEventHandler), sender, e); }
            else
            {
                if (e.OwnerType != AppliableFunctionType._Empty) return; 
                if (e.Command == OperatorCommandType.View)
                {
                    rbElecTicketPool_Bank.Checked = e.ElecTicketPool.ElecTicketType == ElecTicketType.AC01;
                    rbElecTicketPool_Business.Checked = !rbElecTicketPool_Bank.Checked;
                    CommandCenter.ResolveElecTicketPool(e.Command, e.ElecTicketPool, AppliableFunctionType.ElecTicketPool, e.RowIndex);
                }
            }
        }
        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType.ElecTicketPool) return;
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
            if (!elecTicketPoolItemsPanel.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveElecTicketPool(command, AppliableFunctionType.ElecTicketPool);
                CommandCenter.ResolveElecTicketPool(OperatorCommandType.Reset, AppliableFunctionType.ElecTicketPool);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.ElecTicketPool, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
                ElecTicketPool etpBase = null;
                if (elecTicketPoolEdit.CheckData())
                {
                    elecTicketPoolEdit.GetItem();
                    etpBase = elecTicketPoolEdit.ElecTicketPool;
                }


                ElecTicketPool etpRelateAccount = null;
                if (elecTicketPoolRelateAccountSelector.CheckData())
                {
                    elecTicketPoolRelateAccountSelector.GetItem();
                    etpRelateAccount = elecTicketPoolRelateAccountSelector.ElecTicketPool;
                }


                ElecTicketPool etpOther = null;
                if (elecTicketPoolOtherPanel.CheckData())
                {
                    elecTicketPoolOtherPanel.GetItem();
                    etpOther = elecTicketPoolOtherPanel.ElecTicketPool;
                }
                if (null == etpBase) return;
                if (null == etpRelateAccount) return;
                if (null == etpOther) return;

                ElecTicketPool etp = new ElecTicketPool();
                etp.ElecTicketSerialNo = etpBase.ElecTicketSerialNo;
                etp.ElecTicketType = etpBase.ElecTicketType;
                etp.CustomerRef = etpBase.CustomerRef;
                etp.Amount = etpBase.Amount;
                etp.RemitDate = etpBase.RemitDate;
                etp.ExchangeDate = etpBase.ExchangeDate;
                etp.EndDate = etpBase.EndDate;
                etp.BankType = etpBase.BankType;
                etp.RemitAccount = etpRelateAccount.RemitAccount;
                etp.RemitName = etpRelateAccount.RemitName;
                etp.ExchangeBankNo = etpRelateAccount.ExchangeBankNo;
                etp.ExchangeName = etpRelateAccount.ExchangeName;
                etp.ExchangeAccount = etpRelateAccount.ExchangeAccount;
                etp.ExchangeBankName = etpRelateAccount.ExchangeBankName;
                etp.PayeeAccount = etpRelateAccount.PayeeAccount;
                etp.PayeeName = etpRelateAccount.PayeeName;
                etp.PayeeOpenBankName = etpRelateAccount.PayeeOpenBankName;
                etp.PayeeOpenBankNo = etpRelateAccount.PayeeOpenBankNo;
                etp.PreBackNotedPerson = etpOther.PreBackNotedPerson;
                etp.EndDateOperate = etpOther.EndDateOperate;
                etp.BusinessType = etpOther.BusinessType;

                CommandCenter.ResolveElecTicketPool(command, etp, AppliableFunctionType.ElecTicketPool, this.rowIndexPanel_Pool.RowIndex);

                //if (elecTicketPoolRelateAccountSelector.SaveRemit)
                CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, new ElecTicketRelationAccount { Account = etpRelateAccount.RemitAccount, Name = etpRelateAccount.RemitName, PersonType = RelatePersonType.Remittor }, int.MaxValue);

                if (etp.ElecTicketType == ElecTicketType.AC02)//&& elecTicketPoolRelateAccountSelector.SaveExchange)
                    CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, new ElecTicketRelationAccount { Account = etpRelateAccount.ExchangeAccount, Name = etpRelateAccount.ExchangeName, OpenBankName = etpRelateAccount.ExchangeBankName, OpenBankNo = etpRelateAccount.ExchangeBankNo, PersonType = RelatePersonType.Exchange }, int.MaxValue);

                //if (elecTicketPoolRelateAccountSelector.SavePayee)
                CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, new ElecTicketRelationAccount { Account = etpRelateAccount.PayeeAccount, Name = etpRelateAccount.PayeeName, OpenBankName = etpRelateAccount.PayeeOpenBankName, OpenBankNo = etpRelateAccount.PayeeOpenBankNo, PersonType = RelatePersonType.Payee }, int.MaxValue);

            }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.ElecTicketPool, rowIndexPanel_Pool.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveElecTicketPool(command, null, AppliableFunctionType.ElecTicketPool, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.elecTicketPoolItemsPanel.HasData;
                if (flag) this.elecTicketPoolItemsPanel.SaveData(true);
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
            if (!elecTicketPoolItemsPanel.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.ElecTicketPool, true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.ElecTicketPool, true);
        }

        private void rbElecTicketPool_CheckedChanged(object sender, EventArgs e)
        {
            ElecTicketType et = rbElecTicketPool_Bank.Checked ? ElecTicketType.AC01 : ElecTicketType.AC02;
            elecTicketPoolOtherPanel.ElecTicketType =
            elecTicketPoolEdit.ElecTicketType =
            elecTicketPoolRelateAccountSelector.ElecTicketType = et;

            if (et== ElecTicketType.AC01)
            {
                tableLayoutPanel13.RowStyles[0].Height += 25;
                tableLayoutPanel13.RowStyles[1].Height -= 25;

                elecTicketPoolEdit.Height += 25;
                elecTicketPoolRelateAccountSelector.Height -= 25;
            }
            else
            {
                tableLayoutPanel13.RowStyles[0].Height -= 25;
                tableLayoutPanel13.RowStyles[1].Height += 25;

                elecTicketPoolEdit.Height -= 25;
                elecTicketPoolRelateAccountSelector.Height += 25;
            }

            CommandCenter.ResolveElecTicketPool(OperatorCommandType.Reset, AppliableFunctionType.ElecTicketPool);
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
