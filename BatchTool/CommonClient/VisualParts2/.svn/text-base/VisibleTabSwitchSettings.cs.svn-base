using System;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient.VisualParts;

namespace CommonClient.VisualParts2
{
    public partial class VisibleTabSwitchSettings : BaseUc
    {
        public VisibleTabSwitchSettings()
        {
            InitializeComponent();
            Init();
            CommandCenter.OnAppliableEventHandler += new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(VisibleTabSwitchSettings), this);
                Init();
            }
        }

        bool isInit = false;

        private void Init()
        {
            #region versioncontrol
            chbGolbalType.Visible = cbTransferForeignMoney.Visible = cbTransferOverCountry.Visible =
            chbElecTicket.Visible = cbElecTicketRemit.Visible = cbElecTicketTipExchange.Visible = cbElecTicketBackNote.Visible = cbElecTicketPayMoney.Visible = cbElecTicketPool.Visible =
            chbCashMgr.Visible = chbInitiativeAllot.Visible =
            chbApplyLine.Visible = chbPurchaserOrder.Visible = chbPurchaserOrderMgr.Visible = chbSellerOrder.Visible = chbSellerOrderMgr.Visible = chbBillofDebtReceivablePurchaser.Visible = chbBillofDebtReceivableSeller.Visible = chbPaymentofDebtReceivablePurchaser.Visible = chbApplyofFranchiserFinancing.Visible =
            (SystemSettings.CurrentVersion & VersionType.v402) == VersionType.v402;

            chbUnitivePayment.Visible = chbUnitivePaymentRMB.Visible = chbUnitivePaymentFC.Visible = (SystemSettings.CurrentVersion & VersionType.t42) == VersionType.t42;
            gbSwitchBar.Visible = (SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar;
            lblHeader.Visible = (SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar;
            chbPreProccessTransfer.Visible = chbVirtualAccount.Visible = (SystemSettings.CurrentVersion & VersionType.v405) == VersionType.v405;
            chbFinancialServerMgr.Visible = chbBatchReimbursement.Visible = (SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501;
            #endregion

            if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
            {
                gbSwitchBar.Location = gbSwitchNet.Location;
                gbSwitchNet.Visible = false;
            }

            if (AppliableFunctionType._Empty == SystemSettings.AppliableTypes
                && AppliableFunctionType._Empty == SystemSettings.AppliableTypes4Bar)
                return;

            isInit = true;
            #region v307
            cbTransferInd.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferWithIndiv) == AppliableFunctionType.TransferWithIndiv;
            cbTransferEnt.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferWithCorp) == AppliableFunctionType.TransferWithCorp;
            cbExpressAgentOut.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut;
            cbExpressAgentIn.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.AgentExpressIn) == AppliableFunctionType.AgentExpressIn;
            cbCommonAgentOut.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.AgentNormalOut) == AppliableFunctionType.AgentNormalOut;
            cbCommonAgentIn.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.AgentNormalIn) == AppliableFunctionType.AgentNormalIn;
            cbOverBankOut.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferOverBankOut) == AppliableFunctionType.TransferOverBankOut;
            cbOverBankIn.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferOverBankIn) == AppliableFunctionType.TransferOverBankIn;
            #endregion
            #region v402
            if ((SystemSettings.CurrentVersion & VersionType.v402) == VersionType.v402)
            {
                cbElecTicketRemit.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketRemit) == AppliableFunctionType.ElecTicketRemit;
                cbElecTicketBackNote.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketBackNote) == AppliableFunctionType.ElecTicketBackNote;
                cbElecTicketPayMoney.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketPayMoney) == AppliableFunctionType.ElecTicketPayMoney;
                cbElecTicketTipExchange.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketTipExchange) == AppliableFunctionType.ElecTicketTipExchange;
                cbElecTicketPool.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.ElecTicketPool) == AppliableFunctionType.ElecTicketPool;
                cbTransferOverCountry.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferOverCountry) == AppliableFunctionType.TransferOverCountry;
                cbTransferForeignMoney.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.TransferForeignMoney) == AppliableFunctionType.TransferForeignMoney;
                chbInitiativeAllot.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.InitiativeAllot) == AppliableFunctionType.InitiativeAllot;
                chbPurchaserOrder.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.PurchaserOrder) == AppliableFunctionType.PurchaserOrder;
                chbSellerOrder.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.SellerOrder) == AppliableFunctionType.SellerOrder;
                chbPurchaserOrderMgr.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.PurchaserOrderMgr) == AppliableFunctionType.PurchaserOrderMgr;
                chbSellerOrderMgr.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.SellerOrderMgr) == AppliableFunctionType.SellerOrderMgr;
                chbBillofDebtReceivablePurchaser.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.BillofDebtReceivablePurchaser) == AppliableFunctionType.BillofDebtReceivablePurchaser;
                chbBillofDebtReceivableSeller.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.BillofDebtReceivableSeller) == AppliableFunctionType.BillofDebtReceivableSeller;
                chbPaymentofDebtReceivablePurchaser.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser) == AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser;
                chbApplyofFranchiserFinancing.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.ApplyofFranchiserFinancing) == AppliableFunctionType.ApplyofFranchiserFinancing;
            }
            #endregion
            #region t42
            if ((SystemSettings.CurrentVersion & VersionType.t42) == VersionType.t42)
            {
                chbUnitivePaymentRMB.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.UnitivePaymentRMB) == AppliableFunctionType.UnitivePaymentRMB;
                chbUnitivePaymentFC.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.UnitivePaymentFC) == AppliableFunctionType.UnitivePaymentFC;
            }
            #endregion
            #region v403Bar
            if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
            {
                cbExpressAgentOutBar.Checked = (SystemSettings.AppliableTypes4Bar & (AppliableFunctionType)Math.Abs((long)AppliableFunctionType.AgentExpressOut4Bar)) == (AppliableFunctionType)Math.Abs((int)AppliableFunctionType.AgentExpressOut4Bar);
                chbTransfersCountryBar.Checked = (SystemSettings.AppliableTypes4Bar & (AppliableFunctionType)Math.Abs((long)AppliableFunctionType.TransferOverCountry4Bar)) == (AppliableFunctionType)Math.Abs((int)AppliableFunctionType.TransferOverCountry4Bar);
                cbTransferForeignMoneyBar.Checked = (SystemSettings.AppliableTypes4Bar & (AppliableFunctionType)Math.Abs((long)AppliableFunctionType.TransferForeignMoney4Bar)) == (AppliableFunctionType)Math.Abs((int)AppliableFunctionType.TransferForeignMoney4Bar);
            }
            #endregion
            #region v405
            if ((SystemSettings.CurrentVersion & VersionType.v405) == VersionType.v405)
            {
                chbVirtualAccount.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.VirtualAccountTransfer) == AppliableFunctionType.VirtualAccountTransfer;
                chbPreProccessTransfer.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.PreproccessTransfer) == AppliableFunctionType.PreproccessTransfer;
            }
            #endregion
            #region v501
            if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
                chbBatchReimbursement.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.BatchReimbursement) == AppliableFunctionType.BatchReimbursement;
            #endregion
            #region v502
            if ((SystemSettings.CurrentVersion & VersionType.v502) == VersionType.v502)
                chbTheCenttralGoverment.Checked = (SystemSettings.AppliableTypes & AppliableFunctionType.TheCentralGoverment) == AppliableFunctionType.TheCentralGoverment;
            #endregion
            isInit = false;
        }

        void CommandCenter_OnAppliableEventHandler(object sender, AppliableEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler), new object[] { sender, e }); }
            else
            {
                if (OperatorCommandType.AppVisiableRequest == e.Command)
                {
                    AppliableFunctionType types = AppliableFunctionType._Empty;
                    #region v307
                    if ((SystemSettings.CurrentVersion & VersionType.v307) == VersionType.v307)
                    {
                        types = cbTransferInd.Checked ? types | AppliableFunctionType.TransferWithIndiv : types;
                        types = cbTransferEnt.Checked ? types | AppliableFunctionType.TransferWithCorp : types;
                        types = cbExpressAgentOut.Checked ? types | AppliableFunctionType.AgentExpressOut : types;
                        types = cbExpressAgentIn.Checked ? types | AppliableFunctionType.AgentExpressIn : types;
                        types = cbCommonAgentOut.Checked ? types | AppliableFunctionType.AgentNormalOut : types;
                        types = cbCommonAgentIn.Checked ? types | AppliableFunctionType.AgentNormalIn : types;
                        types = cbOverBankOut.Checked ? types | AppliableFunctionType.TransferOverBankOut : types;
                        types = cbOverBankIn.Checked ? types | AppliableFunctionType.TransferOverBankIn : types;
                    }
                    #endregion
                    #region v402
                    if ((SystemSettings.CurrentVersion & VersionType.v402) == VersionType.v402)
                    {
                        types = cbElecTicketRemit.Checked ? types | AppliableFunctionType.ElecTicketRemit : types;
                        types = cbElecTicketBackNote.Checked ? types | AppliableFunctionType.ElecTicketBackNote : types;
                        types = cbElecTicketPayMoney.Checked ? types | AppliableFunctionType.ElecTicketPayMoney : types;
                        types = cbElecTicketTipExchange.Checked ? types | AppliableFunctionType.ElecTicketTipExchange : types;
                        types = cbElecTicketPool.Checked ? types | AppliableFunctionType.ElecTicketPool : types;
                        types = cbTransferOverCountry.Checked ? types | AppliableFunctionType.TransferOverCountry : types;
                        types = cbTransferForeignMoney.Checked ? types | AppliableFunctionType.TransferForeignMoney : types;
                        types = chbInitiativeAllot.Checked ? types | AppliableFunctionType.InitiativeAllot : types;
                        types = chbPurchaserOrder.Checked ? types | AppliableFunctionType.PurchaserOrder : types;
                        types = chbSellerOrder.Checked ? types | AppliableFunctionType.SellerOrder : types;
                        types = chbPurchaserOrderMgr.Checked ? types | AppliableFunctionType.PurchaserOrderMgr : types;
                        types = chbSellerOrderMgr.Checked ? types | AppliableFunctionType.SellerOrderMgr : types;
                        types = chbBillofDebtReceivablePurchaser.Checked ? types | AppliableFunctionType.BillofDebtReceivablePurchaser : types;
                        types = chbBillofDebtReceivableSeller.Checked ? types | AppliableFunctionType.BillofDebtReceivableSeller : types;
                        types = chbPaymentofDebtReceivablePurchaser.Checked ? types | AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser : types;
                        types = chbApplyofFranchiserFinancing.Checked ? types | AppliableFunctionType.ApplyofFranchiserFinancing : types;
                    }
                    #endregion

                    AppliableFunctionType typesBar = AppliableFunctionType._Empty;
                    #region v403Bar
                    if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                    {
                        typesBar = chbTransfersCountryBar.Checked ? typesBar | (AppliableFunctionType)Math.Abs((long)AppliableFunctionType.TransferOverCountry4Bar) : typesBar;
                        typesBar = cbExpressAgentOutBar.Checked ? typesBar | (AppliableFunctionType)Math.Abs((long)AppliableFunctionType.AgentExpressOut4Bar) : typesBar;
                        typesBar = cbTransferForeignMoneyBar.Checked ? typesBar | (AppliableFunctionType)Math.Abs((long)AppliableFunctionType.TransferForeignMoney4Bar) : typesBar;
                    }
                    #endregion

                    #region t42
                    if ((SystemSettings.CurrentVersion & VersionType.t42) == VersionType.t42)
                    {
                        types = chbUnitivePaymentRMB.Checked ? types | AppliableFunctionType.UnitivePaymentRMB : types;
                        types = chbUnitivePaymentFC.Checked ? types | AppliableFunctionType.UnitivePaymentFC : types;
                    }
                    #endregion
                    #region v405
                    if ((SystemSettings.CurrentVersion & VersionType.v405) == VersionType.v405)
                    {
                        types = chbVirtualAccount.Checked ? types | AppliableFunctionType.VirtualAccountTransfer : types;
                        types = chbPreProccessTransfer.Checked ? types | AppliableFunctionType.PreproccessTransfer : types;
                    }
                    #endregion
                    #region v501
                    if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
                        types = chbBatchReimbursement.Checked ? types | AppliableFunctionType.BatchReimbursement : types;
                    #endregion
                    #region v502
                    if ((SystemSettings.CurrentVersion & VersionType.v502) == VersionType.v502)
                        types = chbTheCenttralGoverment.Checked ? types | AppliableFunctionType.TheCentralGoverment : types;
                    #endregion
                    CommandCenter.ResolveAppliableFunction(OperatorCommandType.AppVisiableResolve, types, typesBar);
                }
            }
        }

        private void chb_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked && !isInit)
            {
                if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
                {
                    frmNetPassword frm = new frmNetPassword();
                    frm.AppType = AppliableFunctionType.AgentExpressOut;
                    frm.Show(this);
                }
                else
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_AppliableFunction_Wheathe_Setting_Password, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
            }
        }

        private void chbType_CheckedChanged(object sender, EventArgs e)
        {
            bool childChecked = ((CheckBox)sender).Checked;
            if (((CheckBox)sender).Name == chbTransferType.Name)
                cbTransferInd.Checked =
                cbTransferEnt.Checked =
                cbOverBankOut.Checked =
                cbOverBankIn.Checked = childChecked;
            else if (((CheckBox)sender).Name == chbAgentType.Name)
                cbExpressAgentOut.Checked =
                cbExpressAgentIn.Checked =
                cbCommonAgentOut.Checked =
                cbCommonAgentIn.Checked = childChecked;
            else if (((CheckBox)sender).Name == chbGolbalType.Name)
                cbTransferOverCountry.Checked =
                cbTransferForeignMoney.Checked = childChecked;
            else if (((CheckBox)sender).Name == chbElecTicket.Name)
                cbElecTicketRemit.Checked =
                cbElecTicketTipExchange.Checked =
                cbElecTicketBackNote.Checked =
                cbElecTicketPayMoney.Checked =
                cbElecTicketPool.Checked = childChecked;
            else if (((CheckBox)sender).Name == chbCashMgr.Name)
                chbInitiativeAllot.Checked =
                chbVirtualAccount.Checked =
                chbPreProccessTransfer.Checked = childChecked;
            else if (((CheckBox)sender).Name == chbApplyLine.Name)
                chbPurchaserOrder.Checked =
                chbSellerOrder.Checked =
                chbPurchaserOrderMgr.Checked =
                chbSellerOrderMgr.Checked =
                chbBillofDebtReceivablePurchaser.Checked =
                chbBillofDebtReceivableSeller.Checked =
                chbPaymentofDebtReceivablePurchaser.Checked =
                chbApplyofFranchiserFinancing.Checked = childChecked;
            else if (((CheckBox)sender).Name == chbUnitivePayment.Name)
                chbUnitivePaymentRMB.Checked =
                chbUnitivePaymentFC.Checked = childChecked;
            else if (((CheckBox)sender).Name == chbFinancialServerMgr.Name)
                chbBatchReimbursement.Checked = 
                chbTheCenttralGoverment.Checked=childChecked;
            else if (((CheckBox)sender).Name == chbBar.Name)
                chbTransfersCountryBar.Checked =
                cbExpressAgentOutBar.Checked =
                cbTransferForeignMoneyBar.Checked = childChecked;
        }

        private void btnCustomerInfo_Click(object sender, EventArgs e)
        {
            frmCustomerInfoMgr frm = new frmCustomerInfoMgr();
            if (frm.ShowDialog() != DialogResult.OK) return;
        }
    }
}
