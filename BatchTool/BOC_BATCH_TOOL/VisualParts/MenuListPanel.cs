using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.SysCoach;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.Controls;

namespace BOC_BATCH_TOOL.VisualParts
{
    public partial class MenuListPanel : BaseUc
    {
        public MenuListPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            #region v307
            btnTransferInt.Tag = new List<object> { AppliableFunctionType.TransferWithIndiv, FunctionInSettingType.Empty };
            btnTransferEnt.Tag = new List<object> { AppliableFunctionType.TransferWithCorp, FunctionInSettingType.Empty };
            btnExpressIn.Tag = new List<object> { AppliableFunctionType.AgentExpressIn, FunctionInSettingType.Empty };
            btnExpressOut.Tag = new List<object> { AppliableFunctionType.AgentExpressOut, FunctionInSettingType.Empty };
            btnNormalIn.Tag = new List<object> { AppliableFunctionType.AgentNormalIn, FunctionInSettingType.Empty };
            btnNormalOut.Tag = new List<object> { AppliableFunctionType.AgentNormalOut, FunctionInSettingType.Empty };
            btnOverBankIn.Tag = new List<object> { AppliableFunctionType.TransferOverBankIn, FunctionInSettingType.Empty };
            btnOverBankOut.Tag = new List<object> { AppliableFunctionType.TransferOverBankOut, FunctionInSettingType.Empty };
            btnConvertFile.Tag = new List<object> { AppliableFunctionType._Empty, FunctionInSettingType.BatchConvert };
            #endregion
            #region v402
            btnElecTicketRemit.Tag = new List<object> { AppliableFunctionType.ElecTicketRemit, FunctionInSettingType.Empty };
            btnElecTickTipExchange.Tag = new List<object> { AppliableFunctionType.ElecTicketTipExchange, FunctionInSettingType.Empty };
            btnElecTicketBackNote.Tag = new List<object> { AppliableFunctionType.ElecTicketBackNote, FunctionInSettingType.Empty };
            btnElecTicketPayMoney.Tag = new List<object> { AppliableFunctionType.ElecTicketPayMoney, FunctionInSettingType.Empty };
            btnElecTicketPool.Tag = new List<object> { AppliableFunctionType.ElecTicketPool, FunctionInSettingType.Empty };
            btnTransferOverCountry.Tag = new List<object> { AppliableFunctionType.TransferOverCountry, FunctionInSettingType.Empty };
            btnTransferForeignMoney.Tag = new List<object> { AppliableFunctionType.TransferForeignMoney, FunctionInSettingType.Empty };
            btnInitiativeAllot.Tag = new List<object> { AppliableFunctionType.InitiativeAllot, FunctionInSettingType.Empty };
            btnPurchaserOrder.Tag = new List<object> { AppliableFunctionType.PurchaserOrder, FunctionInSettingType.Empty };
            btnSellerOrder.Tag = new List<object> { AppliableFunctionType.SellerOrder, FunctionInSettingType.Empty };
            btnPurchaserOrderMgr.Tag = new List<object> { AppliableFunctionType.PurchaserOrderMgr, FunctionInSettingType.Empty };
            btnSellerOrderMgr.Tag = new List<object> { AppliableFunctionType.SellerOrderMgr, FunctionInSettingType.Empty };
            btnBillofDebtReceivablePurchaser.Tag = new List<object> { AppliableFunctionType.BillofDebtReceivablePurchaser, FunctionInSettingType.Empty };
            btnBillofDebtReceivableSeller.Tag = new List<object> { AppliableFunctionType.BillofDebtReceivableSeller, FunctionInSettingType.Empty };
            btnPaymentofDebtReceivablePurchaser.Tag = new List<object> { AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser, FunctionInSettingType.Empty };
            btnApplyofFranchiserFinancing.Tag = new List<object> { AppliableFunctionType.ApplyofFranchiserFinancing, FunctionInSettingType.Empty };

            btnSettings.Tag = new List<object> { AppliableFunctionType._Empty, FunctionInSettingType.FunctionSetting };
            #endregion
            #region t42
            btnUnitivePaymentRMB.Tag = new List<object> { AppliableFunctionType.UnitivePaymentRMB, FunctionInSettingType.Empty };
            btnUnitivePaymentFC.Tag = new List<object> { AppliableFunctionType.UnitivePaymentFC, FunctionInSettingType.Empty };
            #endregion
            #region v403Bar
            btnExpressOutBar.Tag = new List<object> { AppliableFunctionType.AgentExpressOut4Bar, FunctionInSettingType.Empty };
            btnTransferOverCountryBar.Tag = new List<object> { AppliableFunctionType.TransferOverCountry4Bar, FunctionInSettingType.Empty };
            btnTransferForeignMoneyBar.Tag = new List<object> { AppliableFunctionType.TransferForeignMoney4Bar, FunctionInSettingType.Empty };
            #endregion
            #region v405
            btnVirtualAccountTransfer.Tag = new List<object> { AppliableFunctionType.VirtualAccountTransfer, FunctionInSettingType.Empty };
            btnPreproccessTransfer.Tag = new List<object> { AppliableFunctionType.PreproccessTransfer, FunctionInSettingType.Empty };
            #endregion
            Init();
            CommandCenter.Instance.OnMoveMenuEventHandler += new EventHandler<MoveMenuEventArgs>(CommandCenter_OnMoveMenuEventHandler);
            CommandCenter.Instance.OnShowPanelEventHandler += new EventHandler<ShowPanelEventArgs>(CommandCenter_OnShowPanelEventHandler);
            CommandCenter.Instance.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(MenuListPanel), this);
            }
        }

        void CommandCenter_OnShowPanelEventHandler(object sender, ShowPanelEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ShowPanelEventArgs>(CommandCenter_OnShowPanelEventHandler), sender, e); }
            else
            {
                if (e.Command != OperatorCommandType.View) return;
                if (e.AppType == AppliableFunctionType._Empty && e.BatchAppType != FunctionInSettingType.BatchConvert)
                {
                    foreach (Control ctl in this.Controls)
                        if (ctl is Button)
                            (ctl as ThemedButton).ThemeName = ThemeName.Corp_Gray;
                    if (e.AppType == AppliableFunctionType._Empty && e.BatchAppType == FunctionInSettingType.FunctionSetting)
                        btnSettings.ThemeName = ThemeName.Corp_Red;
                }
            }
        }

        void CommandCenter_OnMoveMenuEventHandler(object sender, MoveMenuEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<MoveMenuEventArgs>(CommandCenter_OnMoveMenuEventHandler), sender, e); }
            else
            {
                if (e.Command == OperatorCommandType.MoveMenuRequest)
                {
                    int driection = 0;
                    if (e.BatchCommand == OperatorCommandType.MoveMenuReduce)
                        driection = -1;
                    else if (e.BatchCommand == OperatorCommandType.MoveMenuRaise)
                        driection = 1;

                    foreach (Control ctl in this.Controls)
                    {
                        if (ctl is Button)
                            if ((ctl as Button).Visible)
                                ctl.Location = new Point { X = ctl.Location.X + driection * preMovePx, Y = ctl.Location.Y };
                    }
                    startposition += driection * preMovePx;
                    int endposition = startposition > 0 ? showWidth : showWidth - Math.Abs(startposition);
                    CommandCenter.Instance.ResolveMoveMenu(OperatorCommandType.MoveMenuCallBack, showIndex, showCount, 0, startposition, endposition, OperatorCommandType.MoveMenuCallBack);
                }
                else if (e.Command == OperatorCommandType.View)
                {
                    ReloadMenuList();
                }
            }
        }

        private void ReloadMenuList()
        {
            showWidth = startposition = 2;

            foreach (var afType in PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
            {
                if (afType == AppliableFunctionType._Empty) continue;
                if ((int)afType > 0)
                    ShowControl(afType, (SystemSettings.Instance.AppliableTypes & afType) == afType);
                else if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                    ShowControl(afType, (SystemSettings.Instance.AppliableTypes4Bar & (AppliableFunctionType)Math.Abs((int)afType)) == (AppliableFunctionType)Math.Abs((int)afType));
            }

            btnConvertFile.Location = new Point { X = showWidth - 1, Y = 4 };
            btnConvertFile.Visible = true;
            showWidth += btnConvertFile.Width;

            btnSettings.Location = new Point { X = showWidth - 1, Y = 4 };
            btnSettings.Visible = true;
            showWidth += btnSettings.Width;

            int endposition = startposition > 0 ? showWidth : showWidth - Math.Abs(startposition);
            CommandCenter.Instance.ResolveMoveMenu(OperatorCommandType.MoveMenuCallBack, showIndex, showCount, 0, startposition, endposition, OperatorCommandType.MoveMenuCallBack);
        }

        int showCount = 0;
        int showWidth = 2;
        int showIndex = 1;
        int startposition = 2;
        int preMovePx = 90;

        private void Init()
        {
            showCount = 0; showWidth = 2;

            btnConvertFile.Location = new Point { X = showWidth - 1, Y = 4 };
            btnConvertFile.Visible = true;
            showWidth += btnConvertFile.Width;

            btnSettings.Location = new Point { X = showWidth - 1, Y = 4 };
            btnSettings.Visible = true;
            showWidth += btnSettings.Width;
        }

        private void ShowControl(AppliableFunctionType aft, bool isShow)
        {
            if (!this.HasChildren) return;
            #region versioncontrol
            if ((SystemSettings.Instance.CurrentVersion & VersionType.v307) != VersionType.v307
                && (aft == AppliableFunctionType.TransferWithCorp
                    || aft == AppliableFunctionType.TransferWithIndiv
                    || aft == AppliableFunctionType.TransferOverBankOut
                    || aft == AppliableFunctionType.TransferOverBankIn
                    || aft == AppliableFunctionType.AgentExpressOut
                    || aft == AppliableFunctionType.AgentExpressIn
                    || aft == AppliableFunctionType.AgentNormalOut
                    || aft == AppliableFunctionType.AgentNormalIn))
                return;
            if ((SystemSettings.Instance.CurrentVersion & VersionType.v402) != VersionType.v402
                && (aft == AppliableFunctionType.ElecTicketRemit
                    || aft == AppliableFunctionType.ElecTicketTipExchange
                    || aft == AppliableFunctionType.ElecTicketBackNote
                    || aft == AppliableFunctionType.ElecTicketPayMoney
                    || aft == AppliableFunctionType.ElecTicketPool
                    || aft == AppliableFunctionType.InitiativeAllot
                    || aft == AppliableFunctionType.TransferOverCountry
                    || aft == AppliableFunctionType.TransferForeignMoney
                    || aft == AppliableFunctionType.PurchaserOrder
                    || aft == AppliableFunctionType.PurchaserOrderMgr
                    || aft == AppliableFunctionType.SellerOrder
                    || aft == AppliableFunctionType.SellerOrderMgr
                    || aft == AppliableFunctionType.BillofDebtReceivablePurchaser
                    || aft == AppliableFunctionType.BillofDebtReceivableSeller
                    || aft == AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser
                    || aft == AppliableFunctionType.ApplyofFranchiserFinancing))
                return;
            if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) != VersionType.v403bar
                && (aft == AppliableFunctionType.AgentExpressOut4Bar
                    || aft == AppliableFunctionType.TransferForeignMoney4Bar
                    || aft == AppliableFunctionType.TransferOverCountry4Bar))
                return;
            if ((SystemSettings.Instance.CurrentVersion & VersionType.t42) != VersionType.t42
                && (aft == AppliableFunctionType.UnitivePaymentRMB
                    || aft == AppliableFunctionType.UnitivePaymentFC))
                return;
            if ((SystemSettings.Instance.CurrentVersion & VersionType.v405) != VersionType.v405
                && (aft == AppliableFunctionType.VirtualAccountTransfer
                    || aft == AppliableFunctionType.PreproccessTransfer))
                return;
            #endregion
            foreach (Control ctl in this.Controls)
            {
                if (ctl is ThemedButton)
                {
                    if (null != ctl.Tag)
                    {
                        List<object> list = ctl.Tag as List<object>;
                        if (((AppliableFunctionType)list[0]) == aft)
                        {
                            if (isShow)
                            {
                                ctl.Location = new Point { X = showWidth - 1, Y = 4 };
                                showWidth += ctl.Width;
                            }
                            ctl.Visible = isShow;
                            break;
                        }
                    }
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is ThemedButton)
                {
                    if (ctl.Visible)
                    {
                        (ctl as ThemedButton).ThemeName = ThemeName.Corp_Gray;
                    }
                }
            }
            (sender as ThemedButton).ThemeName = BOC_BATCH_TOOL.Controls.ThemeName.Corp_Red;
            if ((sender as ThemedButton).Tag == null) return;
            List<object> list = (sender as ThemedButton).Tag as List<object>;
            CommandCenter.Instance.ResolveShowPanel(OperatorCommandType.View, (AppliableFunctionType)list[0], (FunctionInSettingType)list[1]);
        }
    }
}
