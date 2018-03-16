using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.Entities;
using System.IO;
using CommonClient.Controls;

namespace CommonClient.VisualParts
{
    public partial class AppFunctionPanel : BaseUc
    {
        public AppFunctionPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            fileOperatePanel5.ShowBtnMatchError(false);
            fileOperatePanel6.ShowBtnMatchError(false);
            fileOperatePanel9.ShowBtnMatchError(false);
            fileOperatePanel10.ShowBtnMatchError(false);
            fileOperatePanel11.ShowBtnMatchError(false);
            fileOperatePanel12.ShowBtnMatchError(false);
            fileOperatePanel17.ShowBtnMatchError(false);
            fileOperatePanel18.ShowBtnMatchError(false);
            fileOperatePanel19.ShowBtnMatchError(false);
            fileOperatePanel20.ShowBtnMatchError(false);
            fileOperatePanel21.ShowBtnMatchError(false);
            fileOperatePanel22.ShowBtnMatchError(false);
            fileOperatePanel23.ShowBtnMatchError(false);
            fileOperatePanel24.ShowBtnMatchError(false);
            fileOperatePanel25.ShowBtnMatchError(false);
            fileOperatePanel26.ShowBtnMatchError(false);
            fileOperatePanel27.ShowBtnMatchError(false);
            fileOperatePanel28.ShowBtnMatchError(false);
            fileOperatePanel26.ShowBtnPrint(true);
            fileOperatePanel27.ShowBtnPrint(true);
            fileOperatePanel28.ShowBtnPrint(true);

            dataOperatePanel1.HasLock =
            dataOperatePanel2.HasLock = true;

            rbElecTicketPool_Bank.Checked = true;

            CommandCenter.OnShowPanelEventHandler += new EventHandler<ShowPanelEventArgs>(CommandCenter_OnShowPanelEventHandler);
            CommandCenter.OnEditEventHandler += new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler);
            CommandCenter.OnElecTicketPoolEventHandler += new EventHandler<ElecTicketPoolEventArgs>(CommandCenter_OnElecTicketPoolEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(AppFunctionPanel), this);
                ChangeUIStyle();
                rbElecTicketPool_Bank.Text = CommonClient.Utilities.EnumNameHelper<ElecTicketType>.GetEnumDescription(ElecTicketType.AC01);
                rbElecTicketPool_Business.Text = CommonClient.Utilities.EnumNameHelper<ElecTicketType>.GetEnumDescription(ElecTicketType.AC02);
            }
        }

        private void ChangeUIStyle()
        {
            dataOperatePanel1.Height =
            dataOperatePanel2.Height =
            dataOperatePanel3.Height =
            dataOperatePanel4.Height =
            dataOperatePanel5.Height =
            dataOperatePanel6.Height =
            dataOperatePanel7.Height =
            dataOperatePanel8.Height =
            dataOperatePanel9.Height =
            dataOperatePanel10.Height =
            dataOperatePanel11.Height =
            dataOperatePanel12.Height =
            dataOperatePanel14.Height =
            dataOperatePanel15.Height =
            dataOperatePanel16.Height =
            dataOperatePanel17.Height =
            dataOperatePanel18.Height =
            dataOperatePanel19.Height =
            dataOperatePanel20.Height =
            dataOperatePanel21.Height =
            dataOperatePanel22.Height =
            dataOperatePanel23.Height =
            dataOperatePanel24.Height =
            dataOperatePanel26.Height = 50;
            batchInitiativeAllotHeader.Height =
            bchpnlFastAgentIn.Height =
            bchpnlFastAgentOut.Height =
            bchpnlNormalAgentIn.Height =
            bchpnlNormalAgentOut.Height = 90;

            //dataOperatePanel1.HasLock =
            //dataOperatePanel2.HasLock = true;

        }

        bool m_lockState = false;

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

        private AppliableFunctionType m_CurrentAppType = AppliableFunctionType._Empty;

        void CommandCenter_OnShowPanelEventHandler(object sender, ShowPanelEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ShowPanelEventArgs>(CommandCenter_OnShowPanelEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType._Empty)
                {
                    m_CurrentAppType = e.AppType;
                    switch (e.AppType)
                    {
                        case AppliableFunctionType.TransferWithIndiv: p_Ind.BringToFront(); break;
                        case AppliableFunctionType.TransferWithCorp: p_Ent.BringToFront(); break;
                        case AppliableFunctionType.AgentExpressOut: p_ExpressOut.BringToFront(); break;
                        case AppliableFunctionType.AgentExpressIn: p_ExpressIn.BringToFront(); break;
                        case AppliableFunctionType.AgentNormalOut: p_NormalOut.BringToFront(); break;
                        case AppliableFunctionType.AgentNormalIn: p_NormalIn.BringToFront(); break;
                        case AppliableFunctionType.TransferOverBankOut: p_OverBankOut.BringToFront(); break;
                        case AppliableFunctionType.TransferOverBankIn: p_OverBankIn.BringToFront(); break;
                        case AppliableFunctionType.ElecTicketBackNote: p_ElecTicketBackNote.BringToFront(); break;
                        case AppliableFunctionType.ElecTicketPayMoney: p_ElecTicketPayMoney.BringToFront(); break;
                        case AppliableFunctionType.ElecTicketRemit: p_ElecTicketRemit.BringToFront(); break;
                        case AppliableFunctionType.ElecTicketTipExchange: p_ElecticketTipExchange.BringToFront(); break;
                        case AppliableFunctionType.ElecTicketPool: p_ElecTicketPool.BringToFront(); break;
                        case AppliableFunctionType.TransferOverCountry: p_TransferOverCountry.BringToFront(); break;
                        case AppliableFunctionType.TransferForeignMoney: p_TransferForeignMoney.BringToFront(); break;
                        case AppliableFunctionType.InitiativeAllot: p_InitiativeAllot.BringToFront(); break;
                        case AppliableFunctionType.PurchaserOrder: p_PurchaserOrder.BringToFront(); break;
                        case AppliableFunctionType.SellerOrder: p_SellerOrder.BringToFront(); break;
                        case AppliableFunctionType.PurchaserOrderMgr: p_PurchaserOrderMgr.BringToFront(); break;
                        case AppliableFunctionType.SellerOrderMgr: p_SellerOrderMgr.BringToFront(); break;
                        case AppliableFunctionType.BillofDebtReceivablePurchaser: p_BillofDebtReceivablePurchaser.BringToFront(); break;
                        case AppliableFunctionType.BillofDebtReceivableSeller: p_BillofDebtReceivableSeller.BringToFront(); break;
                        case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser: p_PaymentReceiptofDebtReceivablePurchaser.BringToFront(); break;
                        case AppliableFunctionType.ApplyofFranchiserFinancing: p_ApplyofFranchiserFinancing.BringToFront(); break;
                        case AppliableFunctionType.UnitivePaymentRMB: p_UnitivePaymentRMB.BringToFront(); break;
                        case AppliableFunctionType.UnitivePaymentFC: p_UnitivePaymentFC.BringToFront(); break;
                        case AppliableFunctionType.TransferOverCountry4Bar: p_TransferOverCountry_Bar.BringToFront(); break;
                        case AppliableFunctionType.TransferForeignMoney4Bar: p_TransferForeignMoney_Bar.BringToFront(); break;
                        case AppliableFunctionType.AgentExpressOut4Bar: p_ExpressOutBar.BringToFront(); break;
                        case AppliableFunctionType.VirtualAccountTransfer: p_VirtualAccountSelector.BringToFront(); break;
                        default: break;
                    }
                }
            }
        }

        void CommandCenter_OnEditEventHandler(object sender, EditEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<EditEventArgs>(CommandCenter_OnEditEventHandler), sender, e); }
            else
            {
                if (e.Command == OperatorCommandType.EditOperatorCallBack)
                    SubmitData(OperatorCommandType.Edit);
            }
        }

        //新建
        private void ButtonPanel_ButtonNewClicked(object sender, EventArgs e)
        {
            OpenOrCreateData(OperatorCommandType.New);
        }

        //打开
        private void ButtonPanel_ButtonOpenClicked(object sender, EventArgs e)
        {
            OpenOrCreateData(OperatorCommandType.Open);
        }

        //增加
        private void ButtonPanel_ButtonAddClicked(object sender, EventArgs e)
        {
            SubmitData(OperatorCommandType.Submit);
        }

        //编辑
        private void ButtonPanel_ButtonEditClicked(object sender, EventArgs e)
        {
            EditOperatorRequest();
        }

        //删除
        private void ButtonPanel_ButtonDeleteClicked(object sender, EventArgs e)
        {
            DeleteOrReloadData(OperatorCommandType.Delete);
        }

        //重置
        private void ButtonPanel_ButtonResetClicked(object sender, EventArgs e)
        {
            DeleteOrReloadData(OperatorCommandType.Reset);
        }

        //合并文件
        private void ButtonPanel_ButtonMergFileClicked(object sender, EventArgs e)
        {
            LoadFiles(OperatorCommandType.CombineData, m_CurrentAppType, true);
        }

        //打开匹配错误的数据
        private void ButtonPanel_ButtonMergErrorFileClicked(object sender, EventArgs e)
        {
            switch (m_CurrentAppType)
            {
                case AppliableFunctionType.TransferWithIndiv:
                    if (!transferItemsPanelInvid.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.TransferWithCorp:
                    if (!transferItemsPanelCrop.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.AgentExpressOut:
                    if (!agentExpressPanel_Out.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.AgentExpressOut4Bar:
                    if (!agentExpressItemsPanel_outBar.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.AgentExpressIn:
                    if (!agentExpressPanel_In.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.AgentNormalOut:
                    //if (!agentNormalPanel_Out.HasData)
                    //{ MessageBoxExHelper.Instance.Show( MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.AgentNormalIn:
                    //if (!agentNormalPanel_In.HasData)
                    //{ MessageBoxExHelper.Instance.Show( MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.TransferOverBankOut:
                    if (!transferOverBankItemPanelOut.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.TransferOverBankIn:
                    if (!transferOverBankItemPanelIn.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.ElecTicketRemit:
                    if (!elecTicketRemitItemsPanel.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.ElecTicketBackNote:
                    if (!elecTicketBackNoteItemsPanel.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.ElecTicketPayMoney:
                    if (!elecTicketPayMoneyItemsPanel.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.ElecTicketTipExchange:
                    if (!elecTicketTipExchangeItemsPanel.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.ElecTicketPool:
                    if (!elecTicketPoolItemsPanel.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
                case AppliableFunctionType.InitiativeAllot:
                    if (!initiativeAllotItemsPanel.HasData)
                    { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    break;
            }
                    if (m_CurrentAppType != AppliableFunctionType.AgentNormalIn && m_CurrentAppType != AppliableFunctionType.AgentNormalOut)
                LoadFiles(OperatorCommandType.ErrorData, m_CurrentAppType, true);
        }

        //保存
        private void ButtonPanel_ButtonSaveClicked(object sender, EventArgs e)
        {
            SaveTXTFile();
        }

        //锁定
        private void ButtonPanel_ButtonLockClicked(object sender, EventArgs e)
        {
            m_lockState = !m_lockState;
            CommandCenter.ResolveCommonData(m_lockState ? OperatorCommandType.CommonFieldLockShow : OperatorCommandType.CommonFieldLockHide, new Dictionary<AppliableFunctionType, CommonFieldType>() { { m_CurrentAppType, CommonFieldType.Empty } });
        }

        //打印
        private void ButtonPanel_ButtonPrintClicked(object sender, EventArgs e)
        {
            switch (m_CurrentAppType)
            {
                case AppliableFunctionType.AgentExpressOut4Bar:
                    CommandCenter.ResolveAgentExpress(OperatorCommandType.Print, m_CurrentAppType);
                    break;
                case AppliableFunctionType.TransferForeignMoney4Bar:
                case AppliableFunctionType.TransferOverCountry4Bar:
                    CommandCenter.ResolveTransferGlobal(OperatorCommandType.Print, m_CurrentAppType);
                    break;
            }
        }

        private void OpenOrCreateData(OperatorCommandType command)
        {
            switch (m_CurrentAppType)
            {
                case AppliableFunctionType.TransferWithIndiv:
                    #region
                    if (!transferItemsPanelInvid.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveTransferAccount(command, m_CurrentAppType);
                        CommandCenter.ResolveTransferAccount(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.TransferWithCorp:
                    #region
                    if (!transferItemsPanelCrop.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveTransferAccount(command, m_CurrentAppType);
                        CommandCenter.ResolveTransferAccount(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.AgentExpressOut:
                    #region
                    if (agentExpressPanel_Out.HasData)
                    {
                        if (!bchpnlFastAgentOut.HasData)
                        {
                            if (MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_AllRecord, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                                CommandCenter.ResolveAgentExpress(OperatorCommandType.New, m_CurrentAppType);
                            else
                                return;
                        }
                        bchpnlFastAgentOut.GetItem();
                        if (bchpnlFastAgentOut.HasData && !agentExpressPanel_Out.SaveData(bchpnlFastAgentOut.BatchInfo, false)) return;
                    }
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveAgentExpress(command, m_CurrentAppType);
                        CommandCenter.ResolveAgentExpress(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.AgentExpressOut4Bar:
                    #region
                    if (agentExpressItemsPanel_outBar.HasData)
                    {
                        if (!bchpnlFastAgent_OutBar.HasData)
                        {
                            if (MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_AllRecord, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                                CommandCenter.ResolveAgentExpress(OperatorCommandType.New, m_CurrentAppType);
                            else
                                return;
                        }
                        bchpnlFastAgent_OutBar.GetItem();
                        if (bchpnlFastAgent_OutBar.HasData && !agentExpressItemsPanel_outBar.SaveData(bchpnlFastAgent_OutBar.BatchInfo, false)) return;
                    }
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveAgentExpress(command, m_CurrentAppType);
                        CommandCenter.ResolveAgentExpress(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.AgentExpressIn:
                    #region
                    if (agentExpressPanel_In.HasData)
                    {
                        if (!bchpnlFastAgentIn.HasData)
                        {
                            if (MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_AllRecord, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                                CommandCenter.ResolveAgentExpress(OperatorCommandType.New, m_CurrentAppType);
                            else
                                return;
                        }
                        bchpnlFastAgentIn.GetItem();
                        if (bchpnlFastAgentIn.HasData && !agentExpressPanel_In.SaveData(bchpnlFastAgentIn.BatchInfo, false)) return;
                    }
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveAgentExpress(command, m_CurrentAppType);
                        CommandCenter.ResolveAgentExpress(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.AgentNormalOut:
                    #region
                    if (agentNormalPanel_Out.HasData)
                    {
                        if (!bchpnlNormalAgentOut.HasData)
                        {
                            if (MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_AllRecord, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                                CommandCenter.ResolveAgentNormal(OperatorCommandType.New, m_CurrentAppType);
                            else
                                return;
                        }
                        bchpnlNormalAgentOut.GetItem();
                        if (bchpnlNormalAgentOut.HasData && !agentNormalPanel_Out.SaveData(bchpnlNormalAgentOut.BatchInfo, false)) return;
                    }
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveAgentNormal(command, m_CurrentAppType);
                        CommandCenter.ResolveAgentNormal(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.AgentNormalIn:
                    #region
                    if (agentNormalPanel_In.HasData)
                    {
                        if (!bchpnlNormalAgentIn.HasData)
                        {
                            if (MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_AllRecord, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                                CommandCenter.ResolveAgentNormal(OperatorCommandType.New, m_CurrentAppType);
                            else
                                return;
                        }
                        bchpnlNormalAgentIn.GetItem();
                        if (bchpnlNormalAgentIn.HasData && !agentNormalPanel_In.SaveData(bchpnlNormalAgentIn.BatchInfo, false)) return;
                    }
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveAgentNormal(command, m_CurrentAppType);
                        CommandCenter.ResolveAgentNormal(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.TransferOverBankOut:
                    #region
                    if (!transferOverBankItemPanelOut.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveTransferAccount(command, m_CurrentAppType);
                        CommandCenter.ResolveTransferAccount(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.TransferOverBankIn:
                    #region
                    if (!transferOverBankItemPanelIn.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveTransferAccount(command, m_CurrentAppType);
                        CommandCenter.ResolveTransferAccount(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.ElecTicketRemit:
                    #region
                    if (!elecTicketRemitItemsPanel.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveElecTicketRemit(command, m_CurrentAppType);
                        CommandCenter.ResolveElecTicketRemit(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.ElecTicketBackNote:
                    #region
                    if (!elecTicketBackNoteItemsPanel.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveElecTicketBackNote(command, m_CurrentAppType);
                        CommandCenter.ResolveElecTicketBackNote(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.ElecTicketPayMoney:
                    #region
                    if (!elecTicketPayMoneyItemsPanel.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveElecTicketPayMoney(command, m_CurrentAppType);
                        CommandCenter.ResolveElecTicketPayMoney(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.ElecTicketTipExchange:
                    #region
                    if (!elecTicketTipExchangeItemsPanel.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveElecTicketAutoTipExchange(command, m_CurrentAppType);
                        CommandCenter.ResolveElecTicketAutoTipExchange(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.ElecTicketPool:
                    #region
                    if (!elecTicketPoolItemsPanel.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveElecTicketPool(command, m_CurrentAppType);
                        CommandCenter.ResolveElecTicketPool(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.TransferOverCountry:
                    #region
                    if (!transferGlobalItemsPanel_Country.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveTransferGlobal(command, m_CurrentAppType);
                        CommandCenter.ResolveTransferGlobal(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.TransferForeignMoney:
                    #region
                    if (!transferGlobalItemsPanel_ForeignMoney.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveTransferGlobal(command, m_CurrentAppType);
                        CommandCenter.ResolveTransferGlobal(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.PurchaserOrder:
                    #region
                    if (!spplyFinancingOrderItemsPanel_Purchase.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveSpplyFinancingOrder(command, m_CurrentAppType);
                        CommandCenter.ResolveSpplyFinancingOrder(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.SellerOrder:
                    #region
                    if (!spplyFinancingOrderItemsPanel_Seller.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveSpplyFinancingOrder(command, m_CurrentAppType);
                        CommandCenter.ResolveSpplyFinancingOrder(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.PurchaserOrderMgr:
                    #region
                    if (!spplyFinancingPurchaseOrderMgrItemsPanel.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveSpplyFinancingOrder(command, m_CurrentAppType);
                        CommandCenter.ResolveSpplyFinancingOrder(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.SellerOrderMgr:
                    #region
                    if (!spplyFinancingSellerOrderMgrItemsPanel.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveSpplyFinancingOrder(command, m_CurrentAppType);
                        CommandCenter.ResolveSpplyFinancingOrder(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                    #region
                    if (!spplyFinancingBillItemsPanel_Purchase.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveSpplyFinancingBill(command, m_CurrentAppType);
                        CommandCenter.ResolveSpplyFinancingBill(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.BillofDebtReceivableSeller:
                    #region
                    if (!spplyFinancingBillItemsPanel_Seller.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveSpplyFinancingBill(command, m_CurrentAppType);
                        CommandCenter.ResolveSpplyFinancingBill(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    #region
                    if (!spplyFinancingItemsPanel_Payment.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveSpplyFinancingPayOrReceipt(command, m_CurrentAppType);
                        CommandCenter.ResolveSpplyFinancingPayOrReceipt(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                    #region
                    if (!spplyFinancingApplyItemsPanel.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveSpplyFinancingApply(command, m_CurrentAppType);
                        CommandCenter.ResolveSpplyFinancingApply(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.InitiativeAllot:
                    #region
                    if (initiativeAllotItemsPanel.HasData)
                    {
                        if (!this.batchInitiativeAllotHeader.HasData)
                        {
                            if (MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_MakeSure_Delete_AllRecord, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                                CommandCenter.ResolveInitiativeAllot(OperatorCommandType.New, m_CurrentAppType);
                            else
                                return;
                        }
                        batchInitiativeAllotHeader.GetItem();
                        if (batchInitiativeAllotHeader.HasData && !initiativeAllotItemsPanel.SaveData(batchInitiativeAllotHeader.BatchInfo, false)) return;
                    }
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveInitiativeAllot(command, m_CurrentAppType);
                        CommandCenter.ResolveInitiativeAllot(OperatorCommandType.Reset, m_CurrentAppType);
                    }
                    break;
                    #endregion
                case AppliableFunctionType.UnitivePaymentRMB:
                    #region
                    if (!unitivePaymentItemsPanel_UnitivePaymentRMB.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveUnitivePaymentRMB(command, m_CurrentAppType);
                        CommandCenter.ResolveUnitivePaymentRMB(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.TransferOverCountry4Bar:
                    #region
                    if (!transferGlobalItemsPanel_CountryBar.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveTransferGlobal(command, m_CurrentAppType);
                        CommandCenter.ResolveTransferGlobal(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.TransferForeignMoney4Bar:
                    #region
                    if (!transferGlobalItemsPanel_ForeignMoneyBar.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveTransferGlobal(command, m_CurrentAppType);
                        CommandCenter.ResolveTransferGlobal(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.UnitivePaymentFC:
                    #region
                    if (!unitivePaymentFCItemsPanel1.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveUnitivePaymentFC(command, m_CurrentAppType);
                        CommandCenter.ResolveUnitivePaymentFC(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
                case AppliableFunctionType.VirtualAccountTransfer:
                    #region
                    if (!virtualAccountItemsPanel1.SaveData(false)) return;
                    if (OperatorCommandType.New == command)
                    {
                        CommandCenter.ResolveVirtualAccount(command, m_CurrentAppType);
                        CommandCenter.ResolveVirtualAccount(OperatorCommandType.Reset, m_CurrentAppType);
                    } break;
                    #endregion
            }
            if (OperatorCommandType.Open == command)
                LoadFiles(command, m_CurrentAppType, true);
        }

        private void SubmitData(OperatorCommandType command)
        {
            switch (m_CurrentAppType)
            {
                case AppliableFunctionType.TransferWithIndiv:
                    TransferIndOperator(command);
                    break;
                case AppliableFunctionType.TransferWithCorp:
                    TransferEntOperator(command);
                    break;
                case AppliableFunctionType.AgentExpressOut:
                    if (srAgentExpressOut.CheckData())
                    {
                        srAgentExpressOut.GetItem();
                        AgentExpress ae = srAgentExpressOut.AgentExpress;
                        CommandCenter.ResolveAgentExpress(command, ae, srAgentExpressOut.AppType, rowIndexPanel_ExpressOut.RowIndex);
                        //if (srAgentExpressOut.CanAdd)
                        CommandCenter.ResolvePayee(OperatorCommandType.Submit, new PayeeInfo { Account = ae.AccountNo, Name = ae.AccountName, OpenBankName = ae.BankName, CNAPSNo = ae.BankNo }, srAgentExpressOut.AppType, int.MaxValue);
                    } break;
                case AppliableFunctionType.AgentExpressOut4Bar:
                    if (agentExpressEditor_outBar.CheckData())
                    {
                        agentExpressEditor_outBar.GetItem();
                        AgentExpress ae = agentExpressEditor_outBar.AgentExpress;
                        CommandCenter.ResolveAgentExpress(command, ae, agentExpressEditor_outBar.AppType, rowIndexPanel_outBar.RowIndex);
                        //if (srAgentExpressOut.CanAdd)
                        CommandCenter.ResolvePayee(OperatorCommandType.Submit, new PayeeInfo { Account = ae.AccountNo, Name = ae.AccountName, OpenBankName = ae.BankName, CNAPSNo = ae.BankNo }, m_CurrentAppType, int.MaxValue);
                    } break;
                case AppliableFunctionType.AgentExpressIn:
                    if (srAgentExpressIn.CheckData())
                    {
                        srAgentExpressIn.GetItem();
                        AgentExpress ae = srAgentExpressIn.AgentExpress;
                        CommandCenter.ResolveAgentExpress(command, ae, srAgentExpressIn.AppType, rowIndexPanel_ExpressIn.RowIndex);
                        //if (srAgentExpressIn.CanAdd)
                        CommandCenter.ResolveAgentExpressPayer(OperatorCommandType.Submit, new PayeeInfo { Account = ae.AccountNo, Name = ae.AccountName, CertifyPaperType = ae.CertifyPaperType, CertifyPaperNo = ae.CertifyPaperNo, ProtecolNo = ae.ProtecolNo, }, srAgentExpressOut.AppType, int.MaxValue);
                    } break;
                case AppliableFunctionType.AgentNormalOut:
                    if (srAgentNormalOut.CheckData())
                    {
                        srAgentNormalOut.GetItem();
                        AgentNormal an = srAgentNormalOut.AgentNormal;
                        CommandCenter.ResolveAgentNormal(command, an, srAgentNormalOut.AppType, rowIndexPanel_NormalOut.RowIndex);
                        //if (srAgentNormalOut.CanAdd)
                        CommandCenter.ResolvePayee(OperatorCommandType.Submit, new PayeeInfo { Account = an.AccountNo, Name = an.AccountName, OpenBankName = an.BankName, BankType = string.IsNullOrEmpty(an.BankNo) ? AccountBankType.OtherBankAccount : AccountBankType.BocAccount }, srAgentNormalOut.AppType, int.MaxValue);
                    } break;
                case AppliableFunctionType.AgentNormalIn:
                    if (srAgentNormalIn.CheckData())
                    {
                        srAgentNormalIn.GetItem();
                        AgentNormal an = srAgentNormalIn.AgentNormal;
                        CommandCenter.ResolveAgentNormal(command, an, srAgentNormalIn.AppType, rowIndexPanel_NormalIn.RowIndex);
                        //if (srAgentNormalIn.CanAdd)
                        //    CommandCenter.ResolvePayee(OperatorCommandType.Submit, new PayeeInfo { Account = an.AccountNo, Name = an.AccountName, BankName = an.BankName, BankType = string.IsNullOrEmpty(an.BankNo) ? AccountBankType.OtherBankAccount : AccountBankType.BocAccount }, srAgentNormalIn.AppType, int.MaxValue);
                    } break;
                case AppliableFunctionType.TransferOverBankOut:
                    TransferOverBankOutOperator(command);
                    break;
                case AppliableFunctionType.TransferOverBankIn:
                    TransferOverBankInOperator(command);
                    break;
                case AppliableFunctionType.ElecTicketRemit:
                    ElecTicketRemitOperator(command);
                    break;
                case AppliableFunctionType.ElecTicketBackNote:
                    ElecTicketBackNoteOperator(command);
                    break;
                case AppliableFunctionType.ElecTicketPayMoney:
                    ElecTicketPayMoneyOperator(command);
                    break;
                case AppliableFunctionType.ElecTicketTipExchange:
                    ElecTicketAutoTipExchangeOperator(command);
                    break;
                case AppliableFunctionType.ElecTicketPool:
                    ElecTicketPoolOperator(command);
                    break;
                case AppliableFunctionType.TransferOverCountry:
                case AppliableFunctionType.TransferForeignMoney:
                case AppliableFunctionType.TransferForeignMoney4Bar:
                case AppliableFunctionType.TransferOverCountry4Bar:
                    TransferGlobalOperator(command);
                    break;
                case AppliableFunctionType.PurchaserOrder:
                case AppliableFunctionType.SellerOrder:
                    SpplyFinancingOrderOperator(command);
                    break;
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                    SpplyFinancingOrderMgrOperator(command);
                    break;
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                case AppliableFunctionType.BillofDebtReceivableSeller:
                    SpplyFinancingBillOperator(command);
                    break;
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    SpplyFinancingPayOrReceiptOperator(command);
                    break;
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                    SpplyFinancingApplyOperator(command);
                    break;
                case AppliableFunctionType.InitiativeAllot:
                    if (this.initiativeAllotEditor.CheckData())
                    {
                        initiativeAllotEditor.GetItem();
                        InitiativeAllot ia = initiativeAllotEditor.InitiativeAllot;
                        CommandCenter.ResolveInitiativeAllot(command, ia, initiativeAllotEditor.AppType, rowIndexPanel_InitiativeAllot.RowIndex);
                        if (initiativeAllotEditor.CanAddOut)
                            CommandCenter.ResolveInitiativeAllotAccount(OperatorCommandType.Submit, new InitiativeAllotAccount { Account = ia.AccountOut, Name = ia.NameOut }, initiativeAllotEditor.AppType, int.MaxValue);
                        if (initiativeAllotEditor.CanAddIn)
                            CommandCenter.ResolveInitiativeAllotAccount(OperatorCommandType.Submit, new InitiativeAllotAccount { Account = ia.AccountIn, Name = ia.NameIn }, initiativeAllotEditor.AppType, int.MaxValue);
                    } break;
                case AppliableFunctionType.UnitivePaymentRMB:
                    UnitivePaymentRMBOperator(command);
                    break;
                case AppliableFunctionType.UnitivePaymentFC:
                    UnitivePaymentFCOperator(command);
                    break;
                case AppliableFunctionType.VirtualAccountTransfer:
                    if (this.virtualAccountSelector1.CheckData())
                    {
                        virtualAccountSelector1.GetItem();
                        VirtualAccount iv = virtualAccountSelector1.InitiativeAllot;
                        CommandCenter.ResolveVirtualAccount(command, iv, virtualAccountSelector1.AppType, rowIndexPanel_VirtualAccount.RowIndex);
                        CommandCenter.ResolveVirtualAllotAccount(OperatorCommandType.Submit, new VirtualAccountInfo { Account = iv.AccountOut, Name = iv.NameOut, CashType = iv.CashType }, virtualAccountSelector1.AppType, int.MaxValue);
                        CommandCenter.ResolveVirtualAllotAccount(OperatorCommandType.Submit, new VirtualAccountInfo { Account = iv.AccountIn, Name = iv.NameIn, CashType = iv.CashType }, virtualAccountSelector1.AppType, int.MaxValue);
                    } break;
                default: break;
            }
        }

        private void DeleteOrReloadData(OperatorCommandType command)
        {
            int rowindex = -1;
            switch (m_CurrentAppType)
            {
                case AppliableFunctionType.TransferWithIndiv:
                    rowindex = rowIndexPanel_Ind.RowIndex;
                    CommandCenter.ResolveTransferAccount(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.TransferWithCorp:
                    rowindex = rowIndexPanel_Crop.RowIndex;
                    CommandCenter.ResolveTransferAccount(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.AgentExpressOut:
                    rowindex = rowIndexPanel_ExpressOut.RowIndex;
                    CommandCenter.ResolveAgentExpress(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.AgentExpressOut4Bar:
                    rowindex = rowIndexPanel_outBar.RowIndex;
                    CommandCenter.ResolveAgentExpress(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.AgentExpressIn:
                    rowindex = rowIndexPanel_ExpressIn.RowIndex;
                    CommandCenter.ResolveAgentExpress(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.AgentNormalOut:
                    rowindex = rowIndexPanel_NormalOut.RowIndex;
                    CommandCenter.ResolveAgentNormal(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.AgentNormalIn:
                    rowindex = rowIndexPanel_NormalIn.RowIndex;
                    CommandCenter.ResolveAgentNormal(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.TransferOverBankOut:
                    rowindex = rowIndexPanel_OverBankOut.RowIndex;
                    CommandCenter.ResolveTransferAccount(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.TransferOverBankIn:
                    rowindex = rowIndexPanel_OverBankIn.RowIndex;
                    CommandCenter.ResolveTransferAccount(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.ElecTicketRemit:
                    rowindex = rowIndexPanel_Remit.RowIndex;
                    CommandCenter.ResolveElecTicketRemit(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.ElecTicketBackNote:
                    rowindex = rowIndexPanel_BackNote.RowIndex;
                    CommandCenter.ResolveElecTicketBackNote(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.ElecTicketPayMoney:
                    rowindex = rowIndexPanel_PayMoney.RowIndex;
                    CommandCenter.ResolveElecTicketPayMoney(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.ElecTicketTipExchange:
                    rowindex = rowIndexPanel_TipExchange.RowIndex;
                    CommandCenter.ResolveElecTicketAutoTipExchange(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.ElecTicketPool:
                    rowindex = rowIndexPanel_Pool.RowIndex;
                    CommandCenter.ResolveElecTicketPool(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.TransferOverCountry:
                    rowindex = rowIndexPanel_OverCountry.RowIndex;
                    CommandCenter.ResolveTransferGlobal(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.TransferForeignMoney:
                    rowindex = rowIndexPanel_ForeignMoney.RowIndex;
                    CommandCenter.ResolveTransferGlobal(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.PurchaserOrder:
                    rowindex = rowIndexPanel_OrderPurchase.RowIndex;
                    CommandCenter.ResolveSpplyFinancingOrder(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.SellerOrder:
                    rowindex = rowIndexPanel_OrderSeller.RowIndex;
                    CommandCenter.ResolveSpplyFinancingOrder(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.PurchaserOrderMgr:
                    rowindex = rowIndexPanel_OrderMgrPurchase.RowIndex;
                    CommandCenter.ResolveSpplyFinancingOrder(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.SellerOrderMgr:
                    rowindex = rowIndexPanel_OrderMgrSeller.RowIndex;
                    CommandCenter.ResolveSpplyFinancingOrder(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                    rowindex = rowIndexPanel_BillPurchase.RowIndex;
                    CommandCenter.ResolveSpplyFinancingBill(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.BillofDebtReceivableSeller:
                    rowindex = rowIndexPanel_BillSeller.RowIndex;
                    CommandCenter.ResolveSpplyFinancingBill(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    rowindex = rowIndexPanel_Payment.RowIndex;
                    CommandCenter.ResolveSpplyFinancingPayOrReceipt(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                    rowindex = rowIndexPanel_Apply.RowIndex;
                    CommandCenter.ResolveSpplyFinancingApply(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.InitiativeAllot:
                    rowindex = rowIndexPanel_InitiativeAllot.RowIndex;
                    CommandCenter.ResolveInitiativeAllot(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.UnitivePaymentRMB:
                    rowindex = rowIndexPanel_UnitivePaymentRMB.RowIndex;
                    CommandCenter.ResolveUnitivePaymentRMB(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.UnitivePaymentFC:
                    rowindex = rowIndexPanel_FC.RowIndex;
                    CommandCenter.ResolveUnitivePaymentFC(command, null, m_CurrentAppType, rowindex, OverCountryPayeeAccountType.Empty);
                    break;
                case AppliableFunctionType.TransferOverCountry4Bar:
                    rowindex = rowIndexPanel_CountryBar.RowIndex;
                    CommandCenter.ResolveTransferGlobal(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.TransferForeignMoney4Bar:
                    rowindex = rowIndexPanel_ForeignMoneyBar.RowIndex;
                    CommandCenter.ResolveTransferGlobal(command, null, m_CurrentAppType, rowindex);
                    break;
                case AppliableFunctionType.VirtualAccountTransfer:
                    rowindex = rowIndexPanel_VirtualAccount.RowIndex;
                    CommandCenter.ResolveVirtualAccount(command, null, m_CurrentAppType, rowindex);
                    break;
                default: break;
            }
        }

        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                switch (m_CurrentAppType)
                {
                    case AppliableFunctionType.TransferWithIndiv:
                        flag = this.transferItemsPanelInvid.HasData;
                        if (flag) this.transferItemsPanelInvid.SaveData(true);
                        break;
                    case AppliableFunctionType.TransferWithCorp:
                        flag = this.transferItemsPanelCrop.HasData;
                        if (flag) this.transferItemsPanelCrop.SaveData(true);
                        break;
                    case AppliableFunctionType.AgentExpressOut:
                        #region
                        flag = agentExpressPanel_Out.HasData;
                        if (flag)
                        {
                            if (!bchpnlFastAgentOut.CheckData()) return;
                            bchpnlFastAgentOut.GetItem();
                            BatchHeader batch = bchpnlFastAgentOut.BatchInfo;
                            this.agentExpressPanel_Out.SaveData(batch, true);
                            if (batch.CanAddPayer)
                            {
                                batch.Payer.CashType = CashType.CNY;
                                CommandCenter.ResolvePayer(OperatorCommandType.Submit, batch.Payer, m_CurrentAppType, int.MaxValue);
                            }
                            if (batch.CanAddNotice)
                            {
                                if (SystemSettings.Notices.ContainsKey(m_CurrentAppType) && SystemSettings.Notices[m_CurrentAppType].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Addition_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = batch.Addtion }, m_CurrentAppType);
                            }
                        } break;
                        #endregion
                    case AppliableFunctionType.AgentExpressOut4Bar:
                        #region
                        flag = agentExpressItemsPanel_outBar.HasData;
                        if (flag)
                        {
                            if (!bchpnlFastAgent_OutBar.CheckData()) return;
                            bchpnlFastAgent_OutBar.GetItem();
                            BatchHeader batch = bchpnlFastAgent_OutBar.BatchInfo;
                            this.agentExpressItemsPanel_outBar.SaveData(batch, true);
                            if (batch.CanAddPayer)
                            {
                                batch.Payer.CashType = CashType.CNY;
                                CommandCenter.ResolvePayer(OperatorCommandType.Submit, batch.Payer, m_CurrentAppType, int.MaxValue);
                            }
                            if (batch.CanAddNotice)
                            {
                                if (SystemSettings.Notices.ContainsKey(m_CurrentAppType) && SystemSettings.Notices[m_CurrentAppType].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Addition_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = batch.Addtion }, m_CurrentAppType);
                            }
                        } break;
                        #endregion
                    case AppliableFunctionType.AgentExpressIn:
                        #region
                        flag = agentExpressPanel_In.HasData;
                        if (flag)
                        {
                            if (!bchpnlFastAgentIn.CheckData()) return;
                            bchpnlFastAgentIn.GetItem();
                            BatchHeader batch = bchpnlFastAgentIn.BatchInfo;
                            this.agentExpressPanel_In.SaveData(batch, true);
                            //if (batch.CanAddPayer) CommandCenter.ResolvePayer(OperatorCommandType.Submit, batch.Payer, m_CurrentAppType, int.MaxValue);
                            if (batch.CanAddNotice)
                            {
                                if (SystemSettings.Notices.ContainsKey(m_CurrentAppType) && SystemSettings.Notices[m_CurrentAppType].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Addition_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = batch.Addtion }, m_CurrentAppType);
                            }
                        } break;
                        #endregion
                    case AppliableFunctionType.AgentNormalOut:
                        #region
                        flag = this.agentNormalPanel_Out.HasData;
                        if (flag)
                        {
                            if (!bchpnlNormalAgentOut.CheckData()) return;
                            bchpnlNormalAgentOut.GetItem();
                            BatchHeader batch = bchpnlNormalAgentOut.BatchInfo;
                            this.agentNormalPanel_Out.SaveData(batch, true);
                            if (batch.CanAddPayer)
                            {
                                batch.Payer.CashType = CashType.CNY;
                                CommandCenter.ResolvePayer(OperatorCommandType.Submit, batch.Payer, m_CurrentAppType, int.MaxValue);
                            }
                            if (batch.CanAddNotice)
                            {
                                if (SystemSettings.Notices.ContainsKey(m_CurrentAppType) && SystemSettings.Notices[m_CurrentAppType].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Addition_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = batch.Addtion }, m_CurrentAppType);
                            }
                        } break;
                        #endregion
                    case AppliableFunctionType.AgentNormalIn:
                        #region
                        flag = this.agentNormalPanel_In.HasData;
                        if (flag)
                        {
                            if (!bchpnlNormalAgentIn.CheckData()) return;
                            bchpnlNormalAgentIn.GetItem();
                            BatchHeader batch = bchpnlNormalAgentIn.BatchInfo;
                            this.agentNormalPanel_In.SaveData(batch, true);
                            //if (batch.CanAddPayer) CommandCenter.ResolvePayer(OperatorCommandType.Submit, batch.Payer, m_CurrentAppType, int.MaxValue);
                            if (batch.CanAddNotice)
                            {
                                if (SystemSettings.Notices.ContainsKey(m_CurrentAppType) && SystemSettings.Notices[m_CurrentAppType].FindAll(o => !string.IsNullOrEmpty(o.Content)).Count > 9)
                                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Addition_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = batch.Addtion }, m_CurrentAppType);
                            }
                        } break;
                        #endregion
                    case AppliableFunctionType.TransferOverBankOut:
                        flag = this.transferOverBankItemPanelOut.HasData;
                        if (flag) this.transferOverBankItemPanelOut.SaveData(true);
                        break;
                    case AppliableFunctionType.TransferOverBankIn:
                        flag = this.transferOverBankItemPanelIn.HasData;
                        if (flag) this.transferOverBankItemPanelIn.SaveData(true);
                        break;
                    case AppliableFunctionType.ElecTicketRemit:
                        flag = this.elecTicketRemitItemsPanel.HasData;
                        if (flag) this.elecTicketRemitItemsPanel.SaveData(true);
                        break;
                    case AppliableFunctionType.ElecTicketBackNote:
                        flag = this.elecTicketBackNoteItemsPanel.HasData;
                        if (flag) this.elecTicketBackNoteItemsPanel.SaveData(true);
                        break;
                    case AppliableFunctionType.ElecTicketPayMoney:
                        flag = this.elecTicketPayMoneyItemsPanel.HasData;
                        if (flag) this.elecTicketPayMoneyItemsPanel.SaveData(true);
                        break;
                    case AppliableFunctionType.ElecTicketTipExchange:
                        flag = this.elecTicketTipExchangeItemsPanel.HasData;
                        if (flag) this.elecTicketTipExchangeItemsPanel.SaveData(true);
                        break;
                    case AppliableFunctionType.ElecTicketPool:
                        flag = this.elecTicketPoolItemsPanel.HasData;
                        if (flag) this.elecTicketPoolItemsPanel.SaveData(true);
                        break;
                    case AppliableFunctionType.TransferOverCountry:
                        flag = this.transferGlobalItemsPanel_Country.HasData;
                        if (flag) this.transferGlobalItemsPanel_Country.SaveData(true);
                        break;
                    case AppliableFunctionType.TransferForeignMoney:
                        flag = this.transferGlobalItemsPanel_ForeignMoney.HasData;
                        if (flag) this.transferGlobalItemsPanel_ForeignMoney.SaveData(true);
                        break;
                    case AppliableFunctionType.PurchaserOrder:
                        flag = this.spplyFinancingOrderItemsPanel_Purchase.HasData;
                        if (flag) this.spplyFinancingOrderItemsPanel_Purchase.SaveData(true);
                        break;
                    case AppliableFunctionType.SellerOrder:
                        flag = this.spplyFinancingOrderItemsPanel_Seller.HasData;
                        if (flag) this.spplyFinancingOrderItemsPanel_Seller.SaveData(true);
                        break;
                    case AppliableFunctionType.PurchaserOrderMgr:
                        flag = this.spplyFinancingPurchaseOrderMgrItemsPanel.HasData;
                        if (flag) this.spplyFinancingPurchaseOrderMgrItemsPanel.SaveData(true);
                        break;
                    case AppliableFunctionType.SellerOrderMgr:
                        flag = this.spplyFinancingSellerOrderMgrItemsPanel.HasData;
                        if (flag) this.spplyFinancingSellerOrderMgrItemsPanel.SaveData(true);
                        break;
                    case AppliableFunctionType.BillofDebtReceivablePurchaser:
                        flag = this.spplyFinancingBillItemsPanel_Purchase.HasData;
                        if (flag) this.spplyFinancingBillItemsPanel_Purchase.SaveData(true);
                        break;
                    case AppliableFunctionType.BillofDebtReceivableSeller:
                        flag = this.spplyFinancingBillItemsPanel_Seller.HasData;
                        if (flag) this.spplyFinancingBillItemsPanel_Seller.SaveData(true);
                        break;
                    case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                        flag = this.spplyFinancingItemsPanel_Payment.HasData;
                        if (flag) this.spplyFinancingItemsPanel_Payment.SaveData(true);
                        break;
                    case AppliableFunctionType.ApplyofFranchiserFinancing:
                        flag = this.spplyFinancingApplyItemsPanel.HasData;
                        if (flag) this.spplyFinancingApplyItemsPanel.SaveData(true);
                        break;
                    case AppliableFunctionType.InitiativeAllot:
                        #region
                        flag = this.initiativeAllotItemsPanel.HasData;
                        if (flag)
                        {
                            if (!batchInitiativeAllotHeader.CheckData()) return;
                            batchInitiativeAllotHeader.GetItem();
                            BatchHeader batch = batchInitiativeAllotHeader.BatchInfo;
                            this.initiativeAllotItemsPanel.SaveData(batch, true);
                        }
                        break;
                        #endregion
                    case AppliableFunctionType.UnitivePaymentRMB:
                        flag = this.unitivePaymentItemsPanel_UnitivePaymentRMB.HasData;
                        if (flag) this.unitivePaymentItemsPanel_UnitivePaymentRMB.SaveData(true);
                        break;
                    case AppliableFunctionType.UnitivePaymentFC:
                        flag = this.unitivePaymentFCItemsPanel1.HasData;
                        if (flag) this.unitivePaymentFCItemsPanel1.SaveData(true);
                        break;
                    case AppliableFunctionType.TransferOverCountry4Bar:
                        flag = this.transferGlobalItemsPanel_CountryBar.HasData;
                        if (flag) this.transferGlobalItemsPanel_CountryBar.SaveData(true);
                        break;
                    case AppliableFunctionType.TransferForeignMoney4Bar:
                        flag = this.transferGlobalItemsPanel_ForeignMoneyBar.HasData;
                        if (flag) this.transferGlobalItemsPanel_ForeignMoneyBar.SaveData(true);
                        break;
                    case AppliableFunctionType.VirtualAccountTransfer:
                        flag = this.virtualAccountItemsPanel1.HasData;
                        if (flag) this.virtualAccountItemsPanel1.SaveData(true);
                        break;
                }
            }
            catch
            {
                MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Submit_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!flag)
                MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_NoData_Save, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditOperatorRequest()
        {
            int index = 0;
            switch (m_CurrentAppType)
            {
                case AppliableFunctionType.TransferWithIndiv:
                    index = rowIndexPanel_Ind.RowIndex; break;
                case AppliableFunctionType.TransferWithCorp:
                    index = rowIndexPanel_Crop.RowIndex; break;
                case AppliableFunctionType.AgentExpressOut:
                    index = rowIndexPanel_ExpressOut.RowIndex; break;
                case AppliableFunctionType.AgentExpressOut4Bar:
                    index = rowIndexPanel_outBar.RowIndex; break;
                case AppliableFunctionType.AgentExpressIn:
                    index = rowIndexPanel_ExpressIn.RowIndex; break;
                case AppliableFunctionType.AgentNormalOut:
                    index = rowIndexPanel_NormalOut.RowIndex; break;
                case AppliableFunctionType.AgentNormalIn:
                    index = rowIndexPanel_NormalIn.RowIndex; break;
                case AppliableFunctionType.TransferOverBankOut:
                    index = rowIndexPanel_OverBankOut.RowIndex; break;
                case AppliableFunctionType.TransferOverBankIn:
                    index = rowIndexPanel_OverBankIn.RowIndex; break;
                case AppliableFunctionType.ElecTicketRemit:
                    index = rowIndexPanel_Remit.RowIndex; break;
                case AppliableFunctionType.ElecTicketBackNote:
                    index = rowIndexPanel_BackNote.RowIndex; break;
                case AppliableFunctionType.ElecTicketPayMoney:
                    index = rowIndexPanel_PayMoney.RowIndex; break;
                case AppliableFunctionType.ElecTicketTipExchange:
                    index = rowIndexPanel_TipExchange.RowIndex; break;
                case AppliableFunctionType.ElecTicketPool:
                    index = rowIndexPanel_Pool.RowIndex; break;
                case AppliableFunctionType.TransferOverCountry:
                    index = rowIndexPanel_OverCountry.RowIndex; break;
                case AppliableFunctionType.TransferForeignMoney:
                    index = rowIndexPanel_ForeignMoney.RowIndex; break;
                case AppliableFunctionType.PurchaserOrder:
                    index = rowIndexPanel_OrderPurchase.RowIndex; break;
                case AppliableFunctionType.SellerOrder:
                    index = rowIndexPanel_OrderSeller.RowIndex; break;
                case AppliableFunctionType.PurchaserOrderMgr:
                    index = rowIndexPanel_OrderMgrPurchase.RowIndex; break;
                case AppliableFunctionType.SellerOrderMgr:
                    index = rowIndexPanel_OrderMgrSeller.RowIndex; break;
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                    index = rowIndexPanel_BillPurchase.RowIndex; break;
                case AppliableFunctionType.BillofDebtReceivableSeller:
                    index = rowIndexPanel_BillSeller.RowIndex; break;
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    index = rowIndexPanel_Payment.RowIndex; break;
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                    index = rowIndexPanel_Apply.RowIndex; break;
                case AppliableFunctionType.InitiativeAllot:
                    index = rowIndexPanel_InitiativeAllot.RowIndex; break;
                case AppliableFunctionType.UnitivePaymentRMB:
                    index = rowIndexPanel_UnitivePaymentRMB.RowIndex; break;
                case AppliableFunctionType.UnitivePaymentFC:
                    index = rowIndexPanel_FC.RowIndex; break;
                case AppliableFunctionType.TransferOverCountry4Bar:
                    index = rowIndexPanel_CountryBar.RowIndex; break;
                case AppliableFunctionType.TransferForeignMoney4Bar:
                    index = rowIndexPanel_ForeignMoneyBar.RowIndex; break;
                default: index = 0; break;
            }
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, m_CurrentAppType, index);
        }

        /// <summary>
        /// 转账汇款
        /// </summary>
        /// <param name="payer">付款人信息</param>
        /// <param name="payee">收款人信息</param>
        /// <param name="transfer">转账信息</param>
        /// <param name="oc">操作类型</param>
        /// <param name="aft">功能类型</param>
        /// <param name="act">收款人账号类型</param>
        /// <param name="batchCommand">子命令类型</param>
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
                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Usege_Is_Full, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    CommandCenter.ResolveNotice(oc, new NoticeInfo { Content = transfer.Addition }, aft);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void TransferIndOperator(OperatorCommandType batchCommand)
        {
            PayerInfo payer = null;
            if (payerPnl_Ind.CheckData())
            {
                payerPnl_Ind.GetItem();
                payer = payerPnl_Ind.CurrentPayer;
            }
            if (null == payer) return;

            PayeeInfo payee = null;
            if (payeePnl_P.CheckData())
            {
                payeePnl_P.GetItem();
                payee = payeePnl_P.CurrentPayee;
            }
            if (null == payee) return;

            TransferAccount transfer = null;
            if (transferEditor_P.CheckData())
            {
                transferEditor_P.GetItem();
                transfer = transferEditor_P.Transfer;
            }
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
            TransferOperation(payer, payee, transfer, rowIndexPanel_Ind.RowIndex, payerPnl_Ind.CanAdd, payeePnl_P.isNew, transferEditor_P.CanAddNotice, OperatorCommandType.Submit, AppliableFunctionType.TransferWithIndiv, AccountCategoryType.Personal, batchCommand);
            payerPnl_Ind.CurrentPayer = null;
            payeePnl_P.CurrentPayee = null;
            transferEditor_P.Transfer = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void TransferEntOperator(OperatorCommandType batchCommand)
        {
            PayerInfo payer = null;
            if (payerPnl_Ent.CheckData())
            {
                payerPnl_Ent.GetItem();
                payer = payerPnl_Ent.CurrentPayer;
            }
            if (null == payer) return;

            PayeeInfo payee = null;
            if (payeePnl_E.CheckData())
            {
                payeePnl_E.GetItem();
                payee = payeePnl_E.CurrentPayee;
            }
            if (null == payee) return;

            TransferAccount transfer = null;
            if (transferEditor_E.CheckData())
            {
                transferEditor_E.GetItem();
                transfer = transferEditor_E.Transfer;
            }
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

            //转账汇款（对公）
            TransferOperation(payer, payee, transfer, rowIndexPanel_Crop.RowIndex, payerPnl_Ent.CanAdd, payeePnl_E.isNew, transferEditor_E.CanAddNotice, OperatorCommandType.Submit, AppliableFunctionType.TransferWithCorp, AccountCategoryType.Corperation, batchCommand);
            payerPnl_Ent.CurrentPayer = null;
            payeePnl_E.CurrentPayee = null;
            transferEditor_E.Transfer = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void TransferOverBankOutOperator(OperatorCommandType batchCommand)
        {
            PayerInfo payer = null;
            if (payerPnl_OverBankOut.CheckData())
            {
                payerPnl_OverBankOut.GetItem();
                payer = payerPnl_OverBankOut.CurrentPayer;
            }
            if (null == payer) return;

            PayeeInfo payee = null;
            if (payeePnl_OverBankOut.CheckData())
            {
                payeePnl_OverBankOut.GetItem();
                payee = payeePnl_OverBankOut.CurrentPayee;
            }
            if (null == payee) return;

            TransferAccount transfer = null;
            if (transferEditor_OverBankOut.CheckData())
            {
                transferEditor_OverBankOut.GetItem();
                transfer = transferEditor_OverBankOut.Transfer;
            }
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
            TransferOperation(payer, payee, transfer, rowIndexPanel_OverBankOut.RowIndex, payerPnl_OverBankOut.CanAdd, payeePnl_OverBankOut.isNew, transferEditor_OverBankOut.CanAddNotice, OperatorCommandType.Submit, AppliableFunctionType.TransferOverBankOut, AccountCategoryType.Empty, batchCommand);
            payerPnl_OverBankOut.CurrentPayer = null;
            payeePnl_OverBankOut.CurrentPayee = null;
            transferEditor_OverBankOut.Transfer = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void TransferOverBankInOperator(OperatorCommandType batchCommand)
        {
            PayerInfo payer = null;
            if (payerPnl_OverBankIn.CheckData())
            {
                payerPnl_OverBankIn.GetItem();
                payer = payerPnl_OverBankIn.CurrentPayer;
            }
            if (null == payer) return;

            PayeeInfo payee = null;
            if (payeePnl_OverBankIn.CheckData())
            {
                payeePnl_OverBankIn.GetItem();
                payee = payeePnl_OverBankIn.CurrentPayee;
            }
            if (null == payee) return;

            TransferAccount transfer = null;
            if (transferEditor_OverBankIn.CheckData())
            {
                transferEditor_OverBankIn.GetItem();
                transfer = transferEditor_OverBankIn.Transfer;
            }
            if (null == transfer) return;

            //合并数据
            transfer.PayerAccount = payer.Account;
            transfer.PayerName = payer.Name;
            transfer.PayeeName = payee.Name;
            transfer.PayeeAccount = payee.Account;
            transfer.PayeeOpenBank = payee.OpenBankName;
            transfer.PayeeAddress = payee.Address;
            transfer.Email = payee.Email;
            transfer.CNAPSNo = payee.CNAPSNo;
            transfer.AccountBankType = payee.BankType;
            if (string.IsNullOrEmpty(transfer.PayFeeNo) && ChargingFeeAccountType.SameAsPayingAccount == transfer.PayFeeType)
                transfer.PayFeeNo = payer.Account;

            //跨行速汇（收款）
            TransferOperation(payer, payee, transfer, rowIndexPanel_OverBankIn.RowIndex, payerPnl_OverBankIn.CanAdd, payeePnl_OverBankIn.isNew, transferEditor_OverBankIn.CanAddNotice, OperatorCommandType.Submit, AppliableFunctionType.TransferOverBankIn, AccountCategoryType.Empty, batchCommand);
            payerPnl_OverBankIn.CurrentPayer = null;
            payeePnl_OverBankIn.CurrentPayee = null;
            transferEditor_OverBankIn.Transfer = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void ElecTicketRemitOperator(OperatorCommandType batchCommand)
        {
            PayerInfo payer = null;
            if (payerPnl_Remit.CheckData())
            {
                payerPnl_Remit.GetItem();
                payer = payerPnl_Remit.CurrentPayer;
                payer.CashType = CashType.CNY;
                payer.ServiceList = AppliableFunctionType.ElecTicketRemit | AppliableFunctionType.ElecTicketTipExchange;
            }
            if (null == payer) return;

            ElecTicketRemit etRemit = null;
            if (ettiRemit.CheckData())
            {
                ettiRemit.GetItem();
                etRemit = ettiRemit.Remit;
            }
            if (null == etRemit) return;

            ElecTicketRelationAccount etraExchange = null;
            if (etrasExchange.CheckData())
            {
                etrasExchange.GetItem();
                etraExchange = etrasExchange.CurrentRelateAccount;
            }
            if (null == etraExchange) return;

            ElecTicketRelationAccount etraPayee = null;
            if (etrasPayee.CheckData())
            {
                etrasPayee.GetItem();
                etraPayee = etrasPayee.CurrentRelateAccount;
            }
            if (null == etraPayee) return;

            ElecTicketRemit etRemitEx = null;
            if (etoeRemit.CheckData())
            {
                etoeRemit.GetItem();
                etRemitEx = etoeRemit.Remit;
            }
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

            CommandCenter.ResolveElecTicketRemit(batchCommand, remit, AppliableFunctionType.ElecTicketRemit, rowIndexPanel_Remit.RowIndex);

            //if (payerPnl_Remit.CanAdd)
            payer.CashType = CashType.CNY;
            CommandCenter.ResolvePayer(OperatorCommandType.Submit, payer, m_CurrentAppType, int.MaxValue);

            //if (etrasExchange.CanAdd)
            CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, etraExchange, int.MaxValue);

            //if (etrasPayee.CanAdd)
            CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, etraPayee, int.MaxValue);

            payerPnl_Remit.CurrentPayer = null;
            etrasExchange.CurrentRelateAccount = null;
            etrasPayee.CurrentRelateAccount = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void ElecTicketBackNoteOperator(OperatorCommandType batchCommand)
        {
            PayerInfo payer = null;
            if (payerPnl_BackNote.CheckData())
            {
                payerPnl_BackNote.GetItem();
                payer = payerPnl_BackNote.CurrentPayer;
                payer.CashType = CashType.CNY;
                payer.ServiceList = AppliableFunctionType.ElecTicketPayMoney | AppliableFunctionType.ElecTicketBackNote;
            }
            if (null == payer) return;

            ElecTicketRelationAccount etra = null;
            if (elecTicketRealteAccount_BackNote.CheckData())
            {
                elecTicketRealteAccount_BackNote.GetItem();
                etra = elecTicketRealteAccount_BackNote.CurrentRelateAccount;
            }
            if (null == etra) return;

            ElecTicketBackNote etbn = null;
            if (elecTicketOtherEditor_BackNote.CheckData())
            {
                elecTicketOtherEditor_BackNote.GetItem();
                etbn = elecTicketOtherEditor_BackNote.BackNote;
            }
            if (null == etbn) return;

            ElecTicketBackNote result = new ElecTicketBackNote();
            result.RemitAccount = payer.Account;
            result.ElecTicketSerialNo = payer.Name;
            result.BackNotedAccount = etra.Account;
            result.BackNotedName = etra.Name;
            result.BackNotedOpenBankName = etra.OpenBankName;
            result.BackNotedOpenBankNo = etra.OpenBankNo;
            result.Note = etbn.Note;

            CommandCenter.ResolveElecTicketBackNote(batchCommand, result, m_CurrentAppType, rowIndexPanel_BackNote.RowIndex);

            //if (payerPnl_BackNote.CanAdd)
            payer.CashType = CashType.CNY;
            CommandCenter.ResolvePayer(OperatorCommandType.Submit, payer, m_CurrentAppType, int.MaxValue);

            //if (elecTicketRealteAccount_BackNote.CanAdd)
            CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, etra, int.MaxValue);

            payerPnl_BackNote.CurrentPayer = null;
            elecTicketRealteAccount_BackNote.CurrentRelateAccount = null;
            elecTicketOtherEditor_BackNote.BackNote = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void ElecTicketPayMoneyOperator(OperatorCommandType batchCommand)
        {
            PayerInfo payer = null;
            if (payerPnl_PayMoney.CheckData())
            {
                payerPnl_PayMoney.GetItem();
                payer = payerPnl_PayMoney.CurrentPayer;
                payer.CashType = CashType.CNY;
                payer.ServiceList = AppliableFunctionType.ElecTicketPayMoney | AppliableFunctionType.ElecTicketBackNote;
            }
            if (null == payer) return;

            ElecTicketPayMoney etpmStickOn = null;
            if (elecTicketStickOn_PayMoney.CheckData())
            {
                elecTicketStickOn_PayMoney.GetItem();
                etpmStickOn = elecTicketStickOn_PayMoney.PayMoney;
            }
            if (null == etpmStickOn) return;

            ElecTicketRelationAccount etra = null;
            if (elecTicketRelateAccount_PayMoney.CheckData())
            {
                elecTicketRelateAccount_PayMoney.GetItem();
                etra = elecTicketRelateAccount_PayMoney.CurrentRelateAccount;
            }
            if (null == etra) return;

            ElecTicketPayMoney etpmOther = null;
            if (elecTicketOther_PayMoney.CheckData())
            {
                elecTicketOther_PayMoney.GetItem();
                etpmOther = elecTicketOther_PayMoney.PayMoney;
            }
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

            CommandCenter.ResolveElecTicketPayMoney(batchCommand, etpm, m_CurrentAppType, rowIndexPanel_PayMoney.RowIndex);

            //if (payerPnl_PayMoney.CanAdd)
            payer.CashType = CashType.CNY;
            CommandCenter.ResolvePayer(OperatorCommandType.Submit, payer, m_CurrentAppType, int.MaxValue);

            //if (elecTicketRelateAccount_PayMoney.CanAdd)
            CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, etra, int.MaxValue);

            payerPnl_PayMoney.CurrentPayer = null;
            elecTicketRelateAccount_PayMoney.CurrentRelateAccount = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void ElecTicketAutoTipExchangeOperator(OperatorCommandType batchCommand)
        {
            PayerInfo payer = null;
            if (payerPnl_TipExchange.CheckData())
            {
                payerPnl_TipExchange.GetItem();
                payer = payerPnl_TipExchange.CurrentPayer;
                payer.CashType = CashType.CNY;
                payer.ServiceList = AppliableFunctionType.ElecTicketRemit | AppliableFunctionType.ElecTicketTipExchange;
            }
            if (null == payer) return;

            ElecTicketRelationAccount etra = null;
            elecTicketRealteAccount_TipExchange.GetItem();
            etra = elecTicketRealteAccount_TipExchange.CurrentRelateAccount;
            if (null == etra) return;

            ElecTicketAutoTipExchange etateO = null;
            if (elecTicketOtherEditor_TipExchange.CheckData())
            {
                elecTicketOtherEditor_TipExchange.GetItem();
                etateO = elecTicketOtherEditor_TipExchange.TipExchange;
            }
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
            CommandCenter.ResolveElecTicketAutoTipExchange(batchCommand, etate, m_CurrentAppType, rowIndexPanel_TipExchange.RowIndex);

            //if (payerPnl_TipExchange.CanAdd)
            CommandCenter.ResolvePayer(OperatorCommandType.Submit, payer, m_CurrentAppType, int.MaxValue);

            //if (elecTicketRealteAccount_TipExchange.CanAdd)
            CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, etra, int.MaxValue);

            payerPnl_TipExchange.CurrentPayer = null;
            elecTicketRealteAccount_TipExchange.CurrentRelateAccount = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void ElecTicketPoolOperator(OperatorCommandType batchCommand)
        {
            ElecTicketPool etpBase = null;
            if (elecTicketPoolEdit.CheckData())
            {
                elecTicketPoolEdit.GetItem();
                etpBase = elecTicketPoolEdit.ElecTicketPool;
            }
            if (null == etpBase) return;

            ElecTicketPool etpRelateAccount = null;
            if (elecTicketPoolRelateAccountSelector.CheckData())
            {
                elecTicketPoolRelateAccountSelector.GetItem();
                etpRelateAccount = elecTicketPoolRelateAccountSelector.ElecTicketPool;
            }
            if (null == etpRelateAccount) return;

            ElecTicketPool etpOther = null;
            if (elecTicketPoolOtherPanel.CheckData())
            {
                elecTicketPoolOtherPanel.GetItem();
                etpOther = elecTicketPoolOtherPanel.ElecTicketPool;
            }
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

            CommandCenter.ResolveElecTicketPool(batchCommand, etp, m_CurrentAppType, this.rowIndexPanel_Pool.RowIndex);

            //if (elecTicketPoolRelateAccountSelector.SaveRemit)
            CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, new ElecTicketRelationAccount { Account = etpRelateAccount.RemitAccount, Name = etpRelateAccount.RemitName, PersonType = RelatePersonType.Remittor }, int.MaxValue);

            if (etp.ElecTicketType == ElecTicketType.AC02)//&& elecTicketPoolRelateAccountSelector.SaveExchange)
                CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, new ElecTicketRelationAccount { Account = etpRelateAccount.ExchangeAccount, Name = etpRelateAccount.ExchangeName, OpenBankName = etpRelateAccount.ExchangeBankName, OpenBankNo = etpRelateAccount.ExchangeBankNo, PersonType = RelatePersonType.Exchange }, int.MaxValue);

            //if (elecTicketPoolRelateAccountSelector.SavePayee)
            CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Submit, new ElecTicketRelationAccount { Account = etpRelateAccount.PayeeAccount, Name = etpRelateAccount.PayeeName, OpenBankName = etpRelateAccount.PayeeOpenBankName, OpenBankNo = etpRelateAccount.PayeeOpenBankNo, PersonType = RelatePersonType.Payee }, int.MaxValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void TransferGlobalOperator(OperatorCommandType batchCommand)
        {
            #region tgRemit
            TransferGlobal tgRemit = null;
            if (m_CurrentAppType == AppliableFunctionType.TransferOverCountry)
            {
                if (transferGlobalRemitEditor_OverCountry.CheckData())
                {
                    transferGlobalRemitEditor_OverCountry.GetItem();
                    tgRemit = transferGlobalRemitEditor_OverCountry.TransferGlobal;
                }
            }
            else if (m_CurrentAppType == AppliableFunctionType.TransferForeignMoney)
            {
                if (transferGlobalRemitEditor_ForeignMoney.CheckData())
                {
                    transferGlobalRemitEditor_ForeignMoney.GetItem();
                    tgRemit = transferGlobalRemitEditor_ForeignMoney.TransferGlobal;
                }
            }
            else if (m_CurrentAppType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                if (transferGlobalRemitSelector_CountryBar.CheckData())
                {
                    transferGlobalRemitSelector_CountryBar.GetItem();
                    tgRemit = transferGlobalRemitSelector_CountryBar.TransferGlobal;
                }
            }
            else if (m_CurrentAppType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                if (transferGlobalRemitSelector_ForeignMoneyBar.CheckData())
                {
                    transferGlobalRemitSelector_ForeignMoneyBar.GetItem();
                    tgRemit = transferGlobalRemitSelector_ForeignMoneyBar.TransferGlobal;
                }
            }
            if (null == tgRemit) return;
            #endregion

            #region tgPayee
            TransferGlobal tgPayee = null;
            bool savePayee = false;
            if (m_CurrentAppType == AppliableFunctionType.TransferOverCountry)
            {
                if (transferGlobalPayeeEditor_OverCountry.CheckData())
                {
                    transferGlobalPayeeEditor_OverCountry.GetItem();
                    tgPayee = transferGlobalPayeeEditor_OverCountry.TransferGlobal;
                    savePayee = transferGlobalPayeeEditor_OverCountry.SavePayee;
                }
            }
            else if (m_CurrentAppType == AppliableFunctionType.TransferForeignMoney)
            {
                if (transferGlobalPayeeEditor_ForeignMoney.CheckData())
                {
                    transferGlobalPayeeEditor_ForeignMoney.GetItem();
                    tgPayee = transferGlobalPayeeEditor_ForeignMoney.TransferGlobal;
                    savePayee = transferGlobalPayeeEditor_ForeignMoney.SavePayee;
                }
            }
            else if (m_CurrentAppType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                if (transferGlobalPayeeSelector_CountryBar.CheckData())
                {
                    transferGlobalPayeeSelector_CountryBar.GetItem();
                    tgPayee = transferGlobalPayeeSelector_CountryBar.TransferGlobal;
                    savePayee = transferGlobalPayeeSelector_CountryBar.SavePayee;
                }
            }
            else if (m_CurrentAppType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                if (transferGlobalPayeeSelector_ForeignMoneyBar.CheckData())
                {
                    transferGlobalPayeeSelector_ForeignMoneyBar.GetItem();
                    tgPayee = transferGlobalPayeeSelector_ForeignMoneyBar.TransferGlobal;
                    savePayee = transferGlobalPayeeSelector_ForeignMoneyBar.SavePayee;
                }
            }
            if (null == tgPayee) return;
            savePayee = true;
            #endregion

            #region tgOther
            TransferGlobal tgOther = null;
            bool saveNotice = false;
            if (m_CurrentAppType == AppliableFunctionType.TransferOverCountry)
            {
                if (transferGlobalOtherEditor_OverCountry.CheckData())
                {
                    transferGlobalOtherEditor_OverCountry.GetItem();
                    tgOther = transferGlobalOtherEditor_OverCountry.TransferGlobal;
                    saveNotice = transferGlobalOtherEditor_OverCountry.SaveRemitNote;
                }
            }
            else if (m_CurrentAppType == AppliableFunctionType.TransferForeignMoney)
            {
                if (transferGlobalOtherEditor_ForeignMoney.CheckData())
                {
                    transferGlobalOtherEditor_ForeignMoney.GetItem();
                    tgOther = transferGlobalOtherEditor_ForeignMoney.TransferGlobal;
                    saveNotice = transferGlobalOtherEditor_ForeignMoney.SaveRemitNote;
                }
            }
            else if (m_CurrentAppType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                if (transferGlobalOtherSelector_CountryBar.CheckData())
                {
                    transferGlobalOtherSelector_CountryBar.GetItem();
                    tgOther = transferGlobalOtherSelector_CountryBar.TransferGlobal;
                    saveNotice = transferGlobalOtherSelector_CountryBar.SaveRemitNote;
                }
            }
            else if (m_CurrentAppType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                if (transferGlobalOtherSelector_ForeignMoneyBar.CheckData())
                {
                    transferGlobalOtherSelector_ForeignMoneyBar.GetItem();
                    tgOther = transferGlobalOtherSelector_ForeignMoneyBar.TransferGlobal;
                    saveNotice = transferGlobalOtherSelector_ForeignMoneyBar.SaveRemitNote;
                }
            }
            if (null == tgOther) return;
            #endregion

            #region tg
            TransferGlobal tg = new TransferGlobal();
            tg.PayDate = tgRemit.PayDate;
            tg.CustomerRef = tgRemit.CustomerRef;
            tg.PaymentType = tgRemit.PaymentType;
            tg.SendPriority = tgRemit.SendPriority;
            tg.PaymentCashType = tgRemit.PaymentCashType;
            tg.RemitAmount = tgRemit.RemitAmount;
            tg.SpotAccount = tgRemit.SpotAccount;
            tg.SpotAmount = tgRemit.SpotAmount;
            tg.PurchaseAccount = tgRemit.PurchaseAccount;
            tg.PurchaseAmount = tgRemit.PurchaseAmount;
            tg.OtherAccount = tgRemit.OtherAccount;
            tg.OtherAmount = tgRemit.OtherAmount;
            tg.PayFeeAccount = tgRemit.PayFeeAccount;
            tg.OrgCode = tgRemit.OrgCode;
            tg.RemitName = tgRemit.RemitName;
            tg.RemitAddress = tgRemit.RemitAddress;
            tg.PayeeAccount = tgPayee.PayeeAccount;
            tg.PayeeName = tgPayee.PayeeName;
            tg.PayeeAddress = tgPayee.PayeeAddress;
            tg.PayeeCodeofCountry = tgPayee.PayeeCodeofCountry;
            tg.PayeeNameofCountry = tgPayee.PayeeNameofCountry;
            tg.PayeeOpenBankName = tgPayee.PayeeOpenBankName;
            tg.PayeeOpenBankAddress = tgPayee.PayeeOpenBankAddress;
            tg.PayeeOpenBankSwiftCode = tgPayee.PayeeOpenBankSwiftCode;
            tg.CorrespondentBankName = tgPayee.CorrespondentBankName;
            tg.CorrespondentBankAddress = tgPayee.CorrespondentBankAddress;
            tg.CorrespondentBankSwiftCode = tgPayee.CorrespondentBankSwiftCode;
            tg.PayeeAccountInCorrespondentBank = tgPayee.PayeeAccountInCorrespondentBank;
            tg.RemitNote = tgOther.RemitNote;
            tg.AssumeFeeType = tgOther.AssumeFeeType;
            tg.PayFeeType = tgOther.PayFeeType;
            tg.DealSerialNoF = tgOther.DealSerialNoF;
            tg.DealSerialNoS = tgOther.DealSerialNoS;
            tg.AmountF = tgOther.AmountF;
            tg.AmountS = tgOther.AmountS;
            tg.DealNoteF = tgOther.DealNoteF;
            tg.DealNoteS = tgOther.DealNoteS;
            tg.IsPayOffLine = tgOther.IsPayOffLine;
            tg.ContactNo = tgOther.ContactNo;
            tg.BillSerialNo = tgOther.BillSerialNo;
            tg.BatchNoOrTNoOrSerialNo = tgOther.BatchNoOrTNoOrSerialNo;
            tg.ProposerName = tgOther.ProposerName;
            tg.Telephone = tgOther.Telephone;
            if (m_CurrentAppType == AppliableFunctionType.TransferForeignMoney
                || m_CurrentAppType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                tg.PayeeOpenBankType = tgPayee.PayeeOpenBankType;
                if (tg.PayeeOpenBankType == AccountBankType.BocAccount)
                {
                    tg.PayeeOpenBankName = tgPayee.PayeeOpenBankTypeString;
                    tg.Province = tgPayee.Province;
                    tg.CertifyPaperType = tgPayee.CertifyPaperType;
                    tg.CertifyPaperNo = tgPayee.CertifyPaperNo;
                    tg.AgentFunctionType_Express = tgPayee.AgentFunctionType_Express;
                }
                tg.PaymentPropertyType = tgOther.PaymentPropertyType;
            }
            else if (m_CurrentAppType == AppliableFunctionType.TransferOverCountry
                || m_CurrentAppType == AppliableFunctionType.TransferOverCountry4Bar)
            {
                tg.PayeeOpenBankName = tgPayee.PayeeOpenBankName;
                tg.DealNoteF = tgOther.DealNoteF;
                tg.DealNoteS = tgOther.DealNoteS;
            }
            if (m_CurrentAppType == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                tg.BarBusinessType = tgOther.BarBusinessType;
                tg.BarApplyFlagType = tgOther.BarApplyFlagType;
            }
            #endregion

            if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
            {
                if ((int)m_CurrentAppType < 0)
                {
                    double tamount = 0d;
                    if (!string.IsNullOrEmpty(tg.AmountF)) tamount += double.Parse(tg.AmountF);
                    if (!string.IsNullOrEmpty(tg.AmountS)) tamount += double.Parse(tg.AmountS);
                    if (double.Parse(tg.RemitAmount) < tamount)
                    {
                        MessageBoxExHelper.Instance.Show(string.Format("金额1和金额2之和不能大于汇款金额"), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            int rowindex = int.MaxValue;
            if (m_CurrentAppType == AppliableFunctionType.TransferOverCountry)
                rowindex = rowIndexPanel_OverCountry.RowIndex;
            else if (m_CurrentAppType == AppliableFunctionType.TransferOverCountry4Bar)
                rowindex = rowIndexPanel_CountryBar.RowIndex;
            else if (m_CurrentAppType == AppliableFunctionType.TransferForeignMoney)
                rowindex = rowIndexPanel_ForeignMoney.RowIndex;
            else if (m_CurrentAppType == AppliableFunctionType.TransferForeignMoney4Bar)
                rowindex = rowIndexPanel_ForeignMoneyBar.RowIndex;

            CommandCenter.ResolveTransferGlobal(batchCommand, tg, m_CurrentAppType, rowindex);

            //保存付款人信息
            {
                if (!string.IsNullOrEmpty(tg.PayFeeAccount))
                {
                    PayerInfo payer = new PayerInfo();
                    payer.Account = tg.PayFeeAccount;
                    payer.CashType = tg.PaymentCashType;
                    if ((int)m_CurrentAppType > 0)
                        payer.ServiceList = m_CurrentAppType;
                    else if ((int)m_CurrentAppType < 0)
                        payer.ServiceListBar = (AppliableFunctionType)Math.Abs((int)m_CurrentAppType);
                    payer.CashType = tg.PaymentCashType;
                    CommandCenter.ResolvePayer(OperatorCommandType.Submit, payer, m_CurrentAppType, int.MaxValue);
                }
            }

            //if (savePayee)
            {
                PayeeInfo4TransferGlobal payee = new PayeeInfo4TransferGlobal();
                payee.Account = tgPayee.PayeeAccount;
                payee.Name = tgPayee.PayeeName;
                payee.Address = tgPayee.PayeeAddress;
                payee.NameofCountry = tgPayee.PayeeNameofCountry;
                payee.CodeofCountry = tgPayee.PayeeCodeofCountry;
                payee.CorrespondentBankName = tgPayee.CorrespondentBankName;
                payee.CorrespondentBankAddress = tgPayee.CorrespondentBankAddress;
                payee.AccountInCorrespondentBank = tgPayee.PayeeAccountInCorrespondentBank;
                payee.AccountType = (AppliableFunctionType)(Math.Abs((int)m_CurrentAppType)) == AppliableFunctionType.TransferOverCountry
                                    ? OverCountryPayeeAccountType.ForeignAccount
                                    : tgPayee.PayeeOpenBankType == AccountBankType.BocAccount ? OverCountryPayeeAccountType.BocAccount : OverCountryPayeeAccountType.OtherAccount;

                CommandCenter.ResolvePayee4TransferGlobal(OperatorCommandType.Submit, payee, m_CurrentAppType, int.MaxValue);
            }

            if (saveNotice)
                CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = tgOther.RemitNote }, m_CurrentAppType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void SpplyFinancingOrderOperator(OperatorCommandType batchCommand)
        {
            SpplyFinancingOrder sfoTemp = null;
            if (m_CurrentAppType == AppliableFunctionType.PurchaserOrder)
            {
                if (spplyFinancingOrder_Purchase.CheckData())
                {
                    spplyFinancingOrder_Purchase.GetItem();
                    sfoTemp = spplyFinancingOrder_Purchase.Order;
                }
            }
            else if (m_CurrentAppType == AppliableFunctionType.SellerOrder)
            {
                if (spplyFinancingOrder_Seller.CheckData())
                {
                    spplyFinancingOrder_Seller.GetItem();
                    sfoTemp = spplyFinancingOrder_Seller.Order;
                }
            }
            if (null == sfoTemp) return;

            SpplyFinancingOrder sfo = new SpplyFinancingOrder();
            sfo.OrderNo = sfoTemp.OrderNo;
            sfo.CashType = sfoTemp.CashType;
            sfo.Amount = sfoTemp.Amount;
            sfo.PayDate = sfoTemp.PayDate;
            if (m_CurrentAppType == AppliableFunctionType.PurchaserOrder)
            {
                sfo.ERPCode = sfoTemp.ERPCode;
                sfo.CustomerApplyNo = sfoTemp.CustomerApplyNo;
            }
            else if (m_CurrentAppType == AppliableFunctionType.SellerOrder)
            { sfo.CustomerName = sfoTemp.CustomerName; }

            int rowindex = m_CurrentAppType == AppliableFunctionType.PurchaserOrder ? rowIndexPanel_OrderPurchase.RowIndex : rowIndexPanel_OrderSeller.RowIndex;

            CommandCenter.ResolveSpplyFinancingOrder(batchCommand, sfo, m_CurrentAppType, rowindex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void SpplyFinancingOrderMgrOperator(OperatorCommandType batchCommand)
        {
            SpplyFinancingOrder sfoTemp = null;
            if (m_CurrentAppType == AppliableFunctionType.PurchaserOrderMgr)
            {
                if (spplyFinancingOrderMgr_Purchase.CheckData())
                {
                    spplyFinancingOrderMgr_Purchase.GetItem();
                    sfoTemp = spplyFinancingOrderMgr_Purchase.Order;
                }
            }
            else if (m_CurrentAppType == AppliableFunctionType.SellerOrderMgr)
            {
                if (spplyFinancingOrderMgr_Seller.CheckData())
                {
                    spplyFinancingOrderMgr_Seller.GetItem();
                    sfoTemp = spplyFinancingOrderMgr_Seller.Order;
                }
            }
            if (null == sfoTemp) return;

            SpplyFinancingOrder sfo = new SpplyFinancingOrder();
            sfo.OrderNo = sfoTemp.OrderNo;
            sfo.Amount = sfoTemp.Amount;

            int rowindex = m_CurrentAppType == AppliableFunctionType.SellerOrderMgr ? rowIndexPanel_OrderMgrSeller.RowIndex : rowIndexPanel_OrderMgrPurchase.RowIndex;

            CommandCenter.ResolveSpplyFinancingOrder(batchCommand, sfo, m_CurrentAppType, rowindex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void SpplyFinancingBillOperator(OperatorCommandType batchCommand)
        {
            SpplyFinancingBill sfbTemp = null;
            if (m_CurrentAppType == AppliableFunctionType.BillofDebtReceivablePurchaser)
            {
                if (spplyFinancingBill_Purchase.CheckData())
                {
                    spplyFinancingBill_Purchase.GetItem();
                    sfbTemp = spplyFinancingBill_Purchase.Bill;
                }
            }
            else if (m_CurrentAppType == AppliableFunctionType.BillofDebtReceivableSeller)
            {
                if (spplyFinancingBill_Seller.CheckData())
                {
                    spplyFinancingBill_Seller.GetItem();
                    sfbTemp = spplyFinancingBill_Seller.Bill;
                }
            }
            if (null == sfbTemp) return;

            SpplyFinancingBill sfb = new SpplyFinancingBill();
            sfb.Amount = sfbTemp.Amount;
            sfb.BillDate = sfbTemp.BillDate;
            sfb.BillSerialNo = sfbTemp.BillSerialNo;
            sfb.CashType = sfbTemp.CashType;
            sfb.ContractNo = sfbTemp.ContractNo;
            sfb.CustomerName = sfbTemp.CustomerName;
            sfb.CustomerNo = sfbTemp.CustomerNo;
            sfb.EndDate = sfbTemp.EndDate;
            sfb.StartDate = sfbTemp.StartDate;

            int rowindex = m_CurrentAppType == AppliableFunctionType.BillofDebtReceivablePurchaser ? rowIndexPanel_BillPurchase.RowIndex : rowIndexPanel_BillSeller.RowIndex;

            CommandCenter.ResolveSpplyFinancingBill(batchCommand, sfb, m_CurrentAppType, rowindex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void SpplyFinancingPayOrReceiptOperator(OperatorCommandType batchCommand)
        {
            SpplyFinancingPayOrReceipt sfprTemp = null;
            if (m_CurrentAppType == AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser)
            {
                if (spplyFinancing_Payment.CheckData())
                {
                    spplyFinancing_Payment.GetItem();
                    sfprTemp = spplyFinancing_Payment.PayOrReceipt;
                }
            }
            if (null == sfprTemp) return;

            SpplyFinancingPayOrReceipt sfpr = new SpplyFinancingPayOrReceipt();
            sfpr.BillSerialNo = sfprTemp.BillSerialNo;
            sfpr.CashType = sfprTemp.CashType;
            sfpr.CustomerName = sfprTemp.CustomerName;
            sfpr.CustomerNo = sfprTemp.CustomerNo;
            sfpr.PayAmountForThisTime = sfprTemp.PayAmountForThisTime;

            int rowindex = rowIndexPanel_Payment.RowIndex;

            CommandCenter.ResolveSpplyFinancingPayOrReceipt(batchCommand, sfpr, m_CurrentAppType, rowindex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void SpplyFinancingApplyOperator(OperatorCommandType batchCommand)
        {
            SpplyFinancingApply sfaTemp = null;
            if (spplyFinancingApply.CheckData())
            {
                spplyFinancingApply.GetItem();

                sfaTemp = spplyFinancingApply.Apply;
            }
            if (null == sfaTemp) return;

            SpplyFinancingApply sfa = new SpplyFinancingApply();
            sfa.AgreementNo = sfaTemp.AgreementNo;
            sfa.ApplyAmount = sfaTemp.ApplyAmount;
            sfa.ApplyDays = sfaTemp.ApplyDays;
            sfa.ContractOrOrderAmount = sfaTemp.ContractOrOrderAmount;
            sfa.ContractOrOrderCashType = sfaTemp.ContractOrOrderCashType;
            sfa.ContractOrOrderNo = sfaTemp.ContractOrOrderNo;
            sfa.DeliveryDate = sfaTemp.DeliveryDate;
            sfa.GoodsDesc = sfaTemp.GoodsDesc;
            sfa.InterestFloatingPercent = sfaTemp.InterestFloatingPercent;
            sfa.InterestFloatType = sfaTemp.InterestFloatType;
            sfa.OrderDate = sfaTemp.OrderDate;
            sfa.ReceiptNo = sfaTemp.ReceiptNo;
            sfa.RiskTakingLetterNo = sfaTemp.RiskTakingLetterNo;
            sfa.SettlementType = sfaTemp.SettlementType;
            sfa.TaxInvoiceNo = sfaTemp.TaxInvoiceNo;

            CommandCenter.ResolveSpplyFinancingApply(batchCommand, sfa, m_CurrentAppType, rowIndexPanel_Apply.RowIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void UnitivePaymentRMBOperator(OperatorCommandType batchCommand)
        {
            PayerInfo payer = null;
            if (payerSelector_UnitivePaymentRMB.CheckData())
            {
                payerSelector_UnitivePaymentRMB.GetItem();
                payer = payerSelector_UnitivePaymentRMB.CurrentPayer;
            }
            if (null == payer) return;

            PayeeInfo payee = null;
            if (payeeSelector_UnitivePaymentRMB.CheckData())
            {
                payeeSelector_UnitivePaymentRMB.GetItem();
                payee = payeeSelector_UnitivePaymentRMB.CurrentPayee;
            }
            if (null == payee) return;

            UnitivePaymentRMB payerUp = null;
            if (unitivePaymentPayerSelector_RMB.CheckData())
            {
                unitivePaymentPayerSelector_RMB.GetItem();
                payerUp = unitivePaymentPayerSelector_RMB.CurrentUnitivePaymentRMB;
            }
            if (null == payerUp) return;

            UnitivePaymentRMB otherUp = null;
            if (unitivePaymentOther_RMB.CheckData())
            {
                unitivePaymentOther_RMB.GetItem();
                otherUp = unitivePaymentOther_RMB.CurrentUnitivePaymentRMB;
            }
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

            CommandCenter.ResolveUnitivePaymentRMB(batchCommand, UPItem, m_CurrentAppType, rowIndexPanel_UnitivePaymentRMB.RowIndex);
            payer.CashType = CashType.CNY;
            CommandCenter.ResolvePayer(OperatorCommandType.Submit, payer, m_CurrentAppType, int.MaxValue);
            CommandCenter.ResolvePayee(OperatorCommandType.Submit, payee, m_CurrentAppType, int.MaxValue);

            payerSelector_UnitivePaymentRMB.CurrentPayer = null;
            payeeSelector_UnitivePaymentRMB.CurrentPayee = null;
            unitivePaymentPayerSelector_RMB.CurrentUnitivePaymentRMB = null;
            unitivePaymentOther_RMB.CurrentUnitivePaymentRMB = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchCommand"></param>
        private void UnitivePaymentFCOperator(OperatorCommandType batchCommand)
        {
            UnitivePaymentForeignMoney UnitiveFor = null;
            if (unitivePaymentFCPayerSelector1.CheckData())
            {
                unitivePaymentFCPayerSelector1.GetItem();
                UnitiveFor = unitivePaymentFCPayerSelector1.CurrentUnitivePFC;
            }
            if (null == UnitiveFor) return;

            UnitivePaymentForeignMoney upPayee = null;
            if (transferGlobalPayeeSelector1.CheckData())
            {
                transferGlobalPayeeSelector1.GetItem();
                upPayee = transferGlobalPayeeSelector1._UnitivePaymentForeignMoney;
            }
            if (null == upPayee) return;

            UnitivePaymentForeignMoney upRemit = null;
            if (unitivePaymentFCRemitSelector1.CheckData())
            {
                unitivePaymentFCRemitSelector1.GetItem();
                upRemit = unitivePaymentFCRemitSelector1.CurrentUnitivePFC;
            }
            if (null == upRemit) return;

            UnitivePaymentForeignMoney upOther = null;
            if (transferGlobalOtherSelector1.CheckData())
            {
                transferGlobalOtherSelector1.GetItem();
                upOther = transferGlobalOtherSelector1._UnitivePaymentForeignMoney;
            }
            if (null == upOther) return;

            UnitivePaymentForeignMoney UPItem = new UnitivePaymentForeignMoney();
            UPItem.PayerAccount = UnitiveFor.PayerAccount;
            UPItem.PayerName = UnitiveFor.PayerName;
            UPItem.NominalPayerName = UnitiveFor.NominalPayerName;
            UPItem.NominalPayerAccount = UnitiveFor.NominalPayerAccount;
            UPItem.CashType = UnitiveFor.CashType;
            UPItem.PayeeAccount = upPayee.PayeeAccount;
            UPItem.PayeeName = upPayee.PayeeName;
            UPItem.PayeeAccountType = upPayee.PayeeAccountType;
            UPItem.Address = upPayee.Address;
            UPItem.CodeofCountry = upPayee.CodeofCountry;
            UPItem.NameofCountry = upPayee.NameofCountry;
            UPItem.PayeeOpenBankType = upPayee.PayeeOpenBankType;
            UPItem.PayeeOpenBankName = upPayee.PayeeOpenBankName;
            UPItem.PayeeOpenBankSwiftCode = upPayee.PayeeOpenBankSwiftCode;
            UPItem.OpenBankAddress = upPayee.OpenBankAddress;
            UPItem.PayeeAccountInCorrespondentBank = upPayee.PayeeAccountInCorrespondentBank;
            UPItem.CorrespondentBankName = upPayee.CorrespondentBankName;
            UPItem.CorrespondentBankSwiftCode = upPayee.CorrespondentBankSwiftCode;
            UPItem.CorrespondentBankAddress = upPayee.CorrespondentBankAddress;
            UPItem.FCPayeeAccountType = upPayee.FCPayeeAccountType;
            UPItem.PaymentCountryOrArea = upPayee.PaymentCountryOrArea;
            UPItem.Amount = upRemit.Amount;
            UPItem.OrgCode = upRemit.OrgCode;
            UPItem.SendPriority = upRemit.SendPriority;
            UPItem.CustomerBusinissNo = upRemit.CustomerBusinissNo;
            UPItem.realPayAddress = upRemit.realPayAddress;
            UPItem.OrderPayDate = upRemit.OrderPayDate;
            UPItem.Addtion = upOther.Addtion;
            UPItem.IsImportCancelAfterVerificationType = upOther.IsImportCancelAfterVerificationType;
            UPItem.UnitivePaymentType = upOther.UnitivePaymentType;
            UPItem.PaymentNature = upOther.PaymentNature;
            UPItem.TransactionCode1 = upOther.TransactionCode1;
            UPItem.IPPSMoneyTypeAmount1 = upOther.IPPSMoneyTypeAmount1;
            UPItem.TransactionAddtion1 = upOther.TransactionAddtion1;
            UPItem.TransactionCode2 = upOther.TransactionCode2;
            UPItem.IPPSMoneyTypeAmount2 = upOther.IPPSMoneyTypeAmount2;
            UPItem.TransactionAddtion2 = upOther.TransactionAddtion2;
            UPItem.IsPayOffLine = upOther.IsPayOffLine;
            UPItem.ContractNo = upOther.ContractNo;
            UPItem.InvoiceNo = upOther.InvoiceNo;
            UPItem.BatchNoOrTNoOrSerialNo = upOther.BatchNoOrTNoOrSerialNo;
            UPItem.ApplicantName = upOther.ApplicantName;
            UPItem.Contactnumber = upOther.Contactnumber;
            UPItem.Purpose = upOther.Purpose;
            UPItem.PayeeAccountType = UnitiveFor.PayeeAccountType == OverCountryPayeeAccountType.ForeignAccount
                                        ? OverCountryPayeeAccountType.ForeignAccount
                                        : upPayee.PayeeOpenBankType == AccountBankType.BocAccount ? OverCountryPayeeAccountType.BocAccount : OverCountryPayeeAccountType.OtherAccount;

            #region 判断交易金额是否大于汇款金额
            double tamount = 0.00d;
            if (!string.IsNullOrEmpty(UPItem.IPPSMoneyTypeAmount1))
                tamount += double.Parse(UPItem.IPPSMoneyTypeAmount1);
            if (!string.IsNullOrEmpty(UPItem.IPPSMoneyTypeAmount2))
                tamount += double.Parse(UPItem.IPPSMoneyTypeAmount2);
            if (double.Parse(UPItem.Amount) < tamount)
            {
                MessageBoxExHelper.Instance.Show(string.Format("金额1和金额2之和不能大于汇款金额"), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            CommandCenter.ResolveUnitivePaymentFC(batchCommand, UPItem, m_CurrentAppType, rowIndexPanel_FC.RowIndex, UPItem.PayeeAccountType);

            CommandCenter.ResolvePayer(OperatorCommandType.Submit, new PayerInfo { Account = UPItem.PayerAccount, Name = UPItem.PayerName, CashType = UPItem.CashType, ServiceList = m_CurrentAppType }, m_CurrentAppType, int.MaxValue);
            CommandCenter.ResolvePayee4TransferGlobal(OperatorCommandType.Submit, new PayeeInfo4TransferGlobal { Account = UPItem.PayeeAccount, Name = UPItem.PayeeName, Address = UPItem.Address, AccountType = UPItem.PayeeAccountType, OpenBankType = UPItem.PayeeOpenBankType, OpenBankName = UPItem.PayeeOpenBankName, OpenBankAddress = UPItem.OpenBankAddress, CorrespondentBankName = UPItem.CorrespondentBankName, CorrespondentBankAddress = UPItem.CorrespondentBankAddress, CodeofCountry = UPItem.CodeofCountry, NameofCountry = UPItem.NameofCountry }, m_CurrentAppType, rowIndexPanel_FC.RowIndex);
            if (transferGlobalOtherSelector1.SaveRemitNote)
                CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = UPItem.Addtion }, m_CurrentAppType);

            unitivePaymentFCPayerSelector1.CurrentUnitivePFC = null;
            transferGlobalPayeeSelector1._UnitivePaymentForeignMoney = null;
            unitivePaymentFCRemitSelector1.CurrentUnitivePFC = null;
            transferGlobalOtherSelector1._UnitivePaymentForeignMoney = null;

        }
        /// <summary>
        /// 加载文件数据
        /// </summary>
        /// <param name="loadType"></param>
        /// <param name="aft"></param>
        private void LoadFiles(OperatorCommandType loadType, AppliableFunctionType aft, bool isBOC)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            string fileExtent = string.Empty;
            if (loadType == OperatorCommandType.ErrorData)
            { ofDialog.Filter = string.Format("{0}|*.csv", MultiLanguageConvertHelper.DesignMain_FileType_CSV); fileExtent = ".csv"; }
            else
            { ofDialog.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT); fileExtent = ".txt"; }
            if ((aft == AppliableFunctionType.AgentExpressOut
                    && SystemSettings.IsMatchPassword4ShortProxyOut
                    && !string.IsNullOrEmpty(SystemSettings.ShortProxyOutPassword))
                || (aft == AppliableFunctionType.TransferOverCountry
                    && SystemSettings.IsMatchPassword4TransferOverCountry
                    && !string.IsNullOrEmpty(SystemSettings.TransferOverCountryPassword))
                || (aft == AppliableFunctionType.TransferForeignMoney
                    && SystemSettings.IsMatchPassword4TransferForeignMoney
                    && !string.IsNullOrEmpty(SystemSettings.TransferForeignMoneyPassword)))
            { ofDialog.Filter += string.Format("|{0}|*.sef", MultiLanguageConvertHelper.DesignMain_FileType_SEF); }
            else if (aft == AppliableFunctionType.ApplyofFranchiserFinancing
                || aft == AppliableFunctionType.PurchaserOrder
                || aft == AppliableFunctionType.SellerOrder
                || aft == AppliableFunctionType.PurchaserOrderMgr
                || aft == AppliableFunctionType.SellerOrderMgr
                || aft == AppliableFunctionType.BillofDebtReceivablePurchaser
                || aft == AppliableFunctionType.BillofDebtReceivableSeller
                || aft == AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser)
            {
                ofDialog.Filter = string.Format("{0}|*.dif", MultiLanguageConvertHelper.DesignMain_FileType_DIF);
                fileExtent = ".dif";
            }
            else if (aft == AppliableFunctionType.TransferOverCountry4Bar
                || aft == AppliableFunctionType.TransferForeignMoney4Bar || aft == AppliableFunctionType.AgentExpressOut4Bar)
            {
                ofDialog.Filter = string.Format("{0}|*.dat", "柜台加密文件");
                fileExtent = ".dat";
            }
            if (ofDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileExtent = ofDialog.FilterIndex != 1 ? ".sef" : fileExtent;
                string filepath = ofDialog.FileName;

                string pwd = string.Empty;
                if (m_CurrentAppType == AppliableFunctionType.TransferOverCountry4Bar
                    || m_CurrentAppType == AppliableFunctionType.TransferForeignMoney4Bar
                    || m_CurrentAppType == AppliableFunctionType.AgentExpressOut4Bar)
                {
                    frmBarPassword frm = new frmBarPassword();
                    if (frm.ShowDialog() != DialogResult.OK) return;
                    pwd = frm.Password;
                }

                //查看当前文件是否被占用
                try
                {
                    using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read)) { }
                }
                catch (System.IO.IOException)
                {
                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Settings_Mappings_File_Is_Open_Please_Close_First, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }

                if (!filepath.ToLower().EndsWith(fileExtent))
                {
                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Select_File_Agent, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
                else filepath = DataConvertHelper.FormatFileName(filepath, fileExtent);
                ResultData rd = CommandCenter.ResolveOpenFile(filepath, loadType, aft, isBOC, pwd);
                if (!rd.Result) { MessageBoxExHelper.Instance.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            if (ofDialog != null)
                ofDialog.Dispose();
        }

        private void rbElecTicketType_Pool_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Name == rbElecTicketPool_Bank.Name && rbElecTicketPool_Bank.Checked)
            {
                tableLayoutPanel13.RowStyles[0].Height += 25;
                tableLayoutPanel13.RowStyles[1].Height -= 25;

                elecTicketPoolEdit.Height += 25;
                elecTicketPoolRelateAccountSelector.Height -= 25;

                elecTicketPoolEdit.ElecTicketType =
                elecTicketPoolRelateAccountSelector.ElecTicketType =
                elecTicketPoolOtherPanel.ElecTicketType = ElecTicketType.AC01;
            }
            else if ((sender as RadioButton).Name == rbElecTicketPool_Business.Name && rbElecTicketPool_Business.Checked)
            {
                tableLayoutPanel13.RowStyles[0].Height -= 25;
                tableLayoutPanel13.RowStyles[1].Height += 25;

                elecTicketPoolEdit.Height -= 25;
                elecTicketPoolRelateAccountSelector.Height += 25;

                elecTicketPoolEdit.ElecTicketType =
                elecTicketPoolRelateAccountSelector.ElecTicketType =
                elecTicketPoolOtherPanel.ElecTicketType = ElecTicketType.AC02;
            }
            if (m_CurrentAppType == AppliableFunctionType.ElecTicketPool)
            {
                CommandCenter.ResolveElecTicketPool(OperatorCommandType.Reset, m_CurrentAppType);
            }
        }
    }
}
