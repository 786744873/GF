using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.VisualParts;
using CommonClient.Contract;
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.Entities;
using CommonClient.ConvertHelper;
using System.IO;
using CommonClient;
using CommonClient.TemplateHelper;
using CommonClient.Utilities;
using CommonClient.Controls;
using CommonClient.MatchFile;

namespace BOC_BATCH_TOOL_SETTINGSANDCHANGE
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_SETTINGS", false, 0, "设置", FunctionInSettingType.Empty, ModuleWorkSpaceType.SettingsModule)]
    public partial class MainView : _BaseModule
    {
        public MainView()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
                tabControl2.TabPages.Remove(tpFilePWD);

            p_Settings.BringToFront();
            LoadBatchChangeType(SystemSettings.AppliableTypes, SystemSettings.AppliableTypes4Bar);

            this.cmbFunctionTypeForBatchMap.SelectedIndex = -1;
            this.cmbFunctionTypeForComments.SelectedIndex = -1;

            this.Load += new EventHandler(SettingsPanel_Load);
            CommandCenter.OnAppliableEventHandler += new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler);
            CommandCenter.OnShowPanelEventHandler += new EventHandler<ShowPanelEventArgs>(CommandCenter_OnShowPanelEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);

            tabControl2.TabPages.Remove(tpMapSetting);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(BOC_BATCH_TOOL_SETTINGSANDCHANGE.MainView), this);
                LoadBatchChangeType(SystemSettings.AppliableTypes, SystemSettings.AppliableTypes4Bar);
                btnSaveVisibleTabs.Location = new Point { X = btnSaveVisibleTabs.Location.X, Y = visibleTabSwitcher1.Location.Y + visibleTabSwitcher1.Height + 20 };
                tabControl2.TabPages.RemoveAt(tabControl2.TabPages.Count - 1);

                if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                {
                    tabControl2.TabPages.Remove(tpVirtualAccount);
                    tabControl2.TabPages.Remove(tpInitiativeAllot);
                    tabControl2.TabPages.Remove(tpAgentExpressIn);
                    tabControl2.TabPages.Remove(tpElecTicketRelateAccount);
                    tabControl2.TabPages.Remove(tpFilePWD);
                    panel8.Visible = false;
                    //visibleTabSwitcher1.Height += 100;
                    //btnSaveVisibleTabs.Location = new Point { X = btnSaveVisibleTabs.Location.X, Y = btnSaveVisibleTabs.Location.Y + 100 };
                }
            }
        }

        void SettingsPanel_Load(object sender, EventArgs e)
        {
            List<PayerInfo> listR = new List<PayerInfo>();
            listR.AddRange(SystemSettings.PayerList);
            List<PayeeInfo> listE = new List<PayeeInfo>();
            listE.AddRange(SystemSettings.PayeeList);
            List<ElecTicketRelationAccount> listER = new List<ElecTicketRelationAccount>();
            listER.AddRange(SystemSettings.ElecTicketRelationAccountList);
            CommandCenter.ResolveAppliableFunction(OperatorCommandType.AppVisiableResolve, SystemSettings.AppliableTypes, SystemSettings.AppliableTypes4Bar);
            CommandCenter.ResolvePayer(OperatorCommandType.Load, listR, AppliableFunctionType._Empty);
            CommandCenter.ResolvePayee(OperatorCommandType.Load, listE, AppliableFunctionType._Empty);
            CommandCenter.ResolveElecTicketRelateAccount(OperatorCommandType.Load, listER);
            //CommandCenter.ResolveMoveMenu(OperatorCommandType.View, 0, 0, 0, 0, 0, OperatorCommandType.View);
            tpPayeeManagement.Show();
            tpPayerManagement.Show();
            listR = null;
            listE = null;
            cmbFunctionTypeForBatchMap.Items.Add(EnumNameHelper<FunctionInSettingType>.GetEnumDescription(FunctionInSettingType.PayeeMg));

            btnImport.Tag = btnExport.Tag = FunctionInSettingType.PayeeMg;
            btnElecImport.Tag = btnElecExport.Tag = FunctionInSettingType.ElecTicketRelateAccountMg;
            btnImportTransferGlobalPayee.Tag = btnExportTransferGlobalPayee.Tag = FunctionInSettingType.OverCountryPayeeMg;
            btnImportAgentExpressPayer.Tag = btnExportAgentExpressPayer.Tag = FunctionInSettingType.AgentExpressInPayerMg;

            if ((SystemSettings.CurrentVersion & VersionType.v405) != VersionType.v405)
                tabControl2.TabPages.RemoveAt(8);

            if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
            {
                this.payerEditor1.Dock = DockStyle.Right;
                this.payeeEditor2.Dock = DockStyle.Right;
                this.elecTicketRealteAccountEdit1.Dock = DockStyle.Right;
                this.transferGlobalPayeeEditor1.Dock = DockStyle.Right;
                this.agentExpressPayerEditor.Dock = DockStyle.Right;
                this.initiativeAllotAccountEditor.Dock = DockStyle.Right;
                this.virtualAllotAccountEditor1.Dock = DockStyle.Right;
                this.snapSplitter1.Dock = DockStyle.Right;
                this.snapSplitter2.Dock = DockStyle.Right;
                this.snapSplitter4.Dock = DockStyle.Right;
                this.snapSplitter5.Dock = DockStyle.Right;
                this.snapSplitter6.Dock = DockStyle.Right;
                this.snapSplitter7.Dock = DockStyle.Right;
                this.snapSplitter8.Dock = DockStyle.Right;
                this.snapSplitter9.Dock = DockStyle.Right;
            }
        }

        void CommandCenter_OnAppliableEventHandler(object sender, AppliableEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler), new object[] { sender, e }); }
            else
            {
                if (OperatorCommandType.AppVisiableResolve != e.Command) return;
                LoadBatchChangeType(e.AppVisiable, e.AppVisiableBar);
            }
        }

        void CommandCenter_OnShowPanelEventHandler(object sender, ShowPanelEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<ShowPanelEventArgs>(CommandCenter_OnShowPanelEventHandler), sender, e); }
            else
            {
                if (e.AppType != AppliableFunctionType._Empty) return;
                else
                {
                    p_Settings.BringToFront();
                    switch (e.BatchAppType)
                    {
                        case FunctionInSettingType.FunctionSetting: tabControl2.SelectedTab = tpFunctionSetting; break;
                        case FunctionInSettingType.FilePwd: tabControl2.SelectedTab = tpFilePWD; break;
                        case FunctionInSettingType.PayerMg: tabControl2.SelectedTab = tpPayerManagement; break;
                        case FunctionInSettingType.PayeeMg: tabControl2.SelectedTab = tpPayeeManagement; break;
                        case FunctionInSettingType.AddtionMg: tabControl2.SelectedTab = tpAddition; break;
                        case FunctionInSettingType.MapSetting: tabControl2.SelectedTab = tpMapSetting; break;
                        case FunctionInSettingType.ElecTicketRelateAccountMg: tabControl2.SelectedTab = tpElecTicketRelateAccount; break;
                        default: break;
                    }
                }
            }
        }

        private void btnSaveVisibleTabs_Click(object sender, EventArgs e)
        {
            CommandCenter.ResolveAppliableFunction(OperatorCommandType.AppVisiableRequest, AppliableFunctionType._Empty, AppliableFunctionType._Empty);
            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Submit_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
            CommandCenter.ResolveShowPanel(OperatorCommandType.View, AppliableFunctionType._Empty, FunctionInSettingType.FunctionSetting);
        }

        private void btnMappingSave_Click(object sender, EventArgs e)
        {
            if (cmbFunctionTypeForBatchMap.SelectedIndex < 0) return;
            FunctionInSettingType fst = FunctionInSettingType.Empty;
            AppliableFunctionType aft = AppliableFunctionType._Empty;
            if (cmbFunctionTypeForBatchMap.SelectedIndex == 0) fst = FunctionInSettingType.PayeeMg;
            else aft = (cmbFunctionTypeForBatchMap.Tag as List<AppliableFunctionType>)[cmbFunctionTypeForBatchMap.SelectedIndex - 1];
            CommandCenter.ResolveFieldMapping(OperatorCommandType.MappingSettingRequest, aft, null, fst, FunctionInSettingType.MapSetting);
        }

        private void btnSetFixedInfo_Click(object sender, EventArgs e)
        {
            CommandCenter.ResolveCommonData(OperatorCommandType.CommonFieldRequest, null);
        }

        bool flag = false;

        private void cmbFunctionTypeForBatchMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag) return;
            if (cmbFunctionTypeForBatchMap.SelectedIndex < 0 || cmbFunctionTypeForBatchMap.SelectedIndex >= cmbFunctionTypeForBatchMap.Items.Count) return;
            FunctionInSettingType fst = FunctionInSettingType.Empty;
            AppliableFunctionType aft = AppliableFunctionType._Empty;
            if (cmbFunctionTypeForBatchMap.SelectedIndex == 0) fst = FunctionInSettingType.PayeeMg;
            else aft = (cmbFunctionTypeForBatchMap.Tag as List<AppliableFunctionType>)[cmbFunctionTypeForBatchMap.SelectedIndex - 1];
            CommandCenter.ResolveFieldMapping(OperatorCommandType.View, aft, null, fst, FunctionInSettingType.MapSetting);
        }

        private void cmbFunctionTypeForComments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag) return;
            if (cmbFunctionTypeForComments.SelectedIndex < 0 || cmbFunctionTypeForComments.SelectedIndex >= cmbFunctionTypeForComments.Items.Count) return;
            AppliableFunctionType aft = (cmbFunctionTypeForComments.Tag as List<AppliableFunctionType>)[cmbFunctionTypeForComments.SelectedIndex];
            CommandCenter.ResolveNotice(OperatorCommandType.View, SystemSettings.Notices[aft], aft);
        }

        public void LoadBatchChangeType(AppliableFunctionType aft, AppliableFunctionType aftBar)
        {
            cmbFunctionTypeForBatchMap.Items.Clear();
            cmbFunctionTypeForComments.Items.Clear();
            cmbFunctionTypeForBatchMap.Items.Add(EnumNameHelper<FunctionInSettingType>.GetEnumDescription(FunctionInSettingType.PayeeMg));
            List<AppliableFunctionType> listM = new List<AppliableFunctionType>();
            List<AppliableFunctionType> listN = new List<AppliableFunctionType>();
            foreach (AppliableFunctionType appliableFunctionType in PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
            {
                if (appliableFunctionType == AppliableFunctionType._Empty) continue;
                if (((int)appliableFunctionType > 0 && (appliableFunctionType & aft) != appliableFunctionType)
                    || ((int)appliableFunctionType < 0 && ((AppliableFunctionType)Math.Abs((int)appliableFunctionType) & aftBar) != (AppliableFunctionType)Math.Abs((int)appliableFunctionType))) continue;
                var value = EnumNameHelper<AppliableFunctionType>.GetEnumDescription(appliableFunctionType);
                listM.Add(appliableFunctionType);
                this.cmbFunctionTypeForBatchMap.Items.Add(value);
                if (appliableFunctionType == AppliableFunctionType.AgentExpressIn
                    || appliableFunctionType == AppliableFunctionType.AgentExpressOut
                    || appliableFunctionType == AppliableFunctionType.AgentNormalIn
                    || appliableFunctionType == AppliableFunctionType.AgentNormalOut
                    || appliableFunctionType == AppliableFunctionType.TransferOverBankIn
                    || appliableFunctionType == AppliableFunctionType.TransferOverBankOut
                    || appliableFunctionType == AppliableFunctionType.TransferWithCorp
                    || appliableFunctionType == AppliableFunctionType.TransferWithIndiv
                    || appliableFunctionType == AppliableFunctionType.TransferOverCountry
                    || appliableFunctionType == AppliableFunctionType.TransferForeignMoney
                    || appliableFunctionType == AppliableFunctionType.UnitivePaymentFC
                    || appliableFunctionType == AppliableFunctionType.TransferForeignMoney4Bar
                    || appliableFunctionType == AppliableFunctionType.TransferOverCountry4Bar
                    || appliableFunctionType == AppliableFunctionType.BatchReimbursement)
                {
                    this.cmbFunctionTypeForComments.Items.Add(value);
                    listN.Add(appliableFunctionType);
                }
            }

            cmbFunctionTypeForBatchMap.Tag = listM;
            cmbFunctionTypeForComments.Tag = listN;
            #region 501界面控制
            if ((SystemSettings.CurrentVersion & VersionType.v501) == VersionType.v501)
            {
                bool flag_TransferMoney = false; //境内人民币收款人
                bool flag_ElecTicket = false;//票据关系人
                bool flag_TransferGlobal = false; //国际结算收款人
                bool flag_AgentExpressIn = false; //快捷代收付款人
                bool flag_InitiativeAllot = false; //主动调拨服务
                bool flag_VirtualAccountTransfer = false;//虚拟账户
                foreach (AppliableFunctionType type in listM)
                {
                    if (type == AppliableFunctionType.TransferWithCorp || type == AppliableFunctionType.TransferWithIndiv || type == AppliableFunctionType.AgentExpressOut || type == AppliableFunctionType.UnitivePaymentRMB || type == AppliableFunctionType.AgentNormalIn || type == AppliableFunctionType.AgentExpressOut || type == AppliableFunctionType.AgentNormalOut||type==AppliableFunctionType.TransferOverBankOut  )
                        flag_TransferMoney = true;
                    else if (type == AppliableFunctionType.ElecTicketBackNote || type == AppliableFunctionType.ElecTicketPayMoney || type == AppliableFunctionType.ElecTicketPool || type == AppliableFunctionType.ElecTicketRemit || type == AppliableFunctionType.ElecTicketTipExchange)
                        flag_ElecTicket = true;
                    else if (type == AppliableFunctionType.TransferForeignMoney || type == AppliableFunctionType.TransferOverCountry || type == AppliableFunctionType.UnitivePaymentFC)
                        flag_TransferGlobal = true;
                    else if (type == AppliableFunctionType.AgentExpressIn)
                        flag_AgentExpressIn = true;
                    else if (type == AppliableFunctionType.InitiativeAllot)
                        flag_InitiativeAllot = true;
                    else if (type == AppliableFunctionType.VirtualAccountTransfer || type == AppliableFunctionType.PreproccessTransfer)
                        flag_VirtualAccountTransfer = true;
                }
                if (!flag_TransferMoney && tabControl2.TabPages.Contains(tpPayeeManagement)) tabControl2.TabPages.Remove(tpPayeeManagement);
                else if (flag_TransferMoney && !tabControl2.TabPages.Contains(tpPayeeManagement)) tabControl2.TabPages.Add(tpPayeeManagement);
                if (!flag_ElecTicket && tabControl2.TabPages.Contains(tpElecTicketRelateAccount)) tabControl2.TabPages.Remove(tpElecTicketRelateAccount);
                else if (flag_ElecTicket && !tabControl2.TabPages.Contains(tpElecTicketRelateAccount)) tabControl2.TabPages.Add(tpElecTicketRelateAccount);
                if (!flag_TransferGlobal && tabControl2.TabPages.Contains(tpOverCountryPayeeManagement)) tabControl2.TabPages.Remove(tpOverCountryPayeeManagement);
                else if (flag_TransferGlobal && !tabControl2.TabPages.Contains(tpOverCountryPayeeManagement)) tabControl2.TabPages.Add(tpOverCountryPayeeManagement);
                if (!flag_AgentExpressIn && tabControl2.TabPages.Contains(tpAgentExpressIn)) tabControl2.TabPages.Remove(tpAgentExpressIn);
                else if (flag_AgentExpressIn && !tabControl2.TabPages.Contains(tpAgentExpressIn)) tabControl2.TabPages.Add(tpAgentExpressIn);
                if (!flag_InitiativeAllot && tabControl2.TabPages.Contains(tpInitiativeAllot)) tabControl2.TabPages.Remove(tpInitiativeAllot);
                else if (flag_InitiativeAllot && !tabControl2.TabPages.Contains(tpInitiativeAllot)) tabControl2.TabPages.Add(tpInitiativeAllot);
                if (!flag_VirtualAccountTransfer && tabControl2.TabPages.Contains(tpVirtualAccount)) tabControl2.TabPages.Remove(tpVirtualAccount);
                else if (flag_VirtualAccountTransfer && !tabControl2.TabPages.Contains(tpVirtualAccount)) tabControl2.TabPages.Add(tpVirtualAccount);
            }
            #endregion
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (null == ((CommonClient.Controls.ThemedButton)sender).Tag) return;
            FunctionInSettingType fst = (FunctionInSettingType)((CommonClient.Controls.ThemedButton)sender).Tag;
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT);
            if (fst == FunctionInSettingType.ElecTicketRelateAccountMg) ofDialog.Filter += string.Format("|{0}|*.csv", MultiLanguageConvertHelper.DesignMain_FileType_CSV);
            if (ofDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string endstr = ofDialog.FilterIndex == 1 ? ".txt" : ".csv";
                string filepath = ofDialog.FileName;
                if (!filepath.ToLower().EndsWith(endstr)) { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Select_File_Agent, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
                else filepath = DataConvertHelper.FormatFileName(filepath, endstr);

                //查看当前文件是否被占用
                try
                {
                    using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read)) { }
                }
                catch (System.IO.IOException)
                {
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_File_Is_Open_Please_Close_First, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return;
                }

                ResultData rd = BatchConsignDataTemplateHelper.LoadBOCDocument(fst, OperatorCommandType.CombineData, filepath);
                if (!rd.Result)
                    MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (null == ((CommonClient.Controls.ThemedButton)sender).Tag) return;
            FunctionInSettingType fst = (FunctionInSettingType)((CommonClient.Controls.ThemedButton)sender).Tag;
            bool flag = false;
            if (fst == FunctionInSettingType.PayeeMg) flag = payeeItemsPanel2.SaveData();
            else if (fst == FunctionInSettingType.ElecTicketRelateAccountMg) flag = elecTicketRelateAccountItemsPanel1.SaveData();
            else if (fst == FunctionInSettingType.AgentExpressInPayerMg) flag = agentExpressPayerItemsPanel1.SaveData();
            else if (fst == FunctionInSettingType.OverCountryPayeeMg) flag = transferGlobalPayeeItemsPanel1.SaveData();
            if (flag)
                MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Submit_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
            else
                MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Submit_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
        }

        private void llOpenMapSetting_Click(object sender, EventArgs e)
        {
            CommandCenter.ResolveShowPanel(OperatorCommandType.View, AppliableFunctionType._Empty, FunctionInSettingType.MapSetting);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            FunctionInSettingType fst = FunctionInSettingType.Empty;
            if ((sender as ThemedButton).Name.Equals(btnSelectAllPayer.Name))
                fst = FunctionInSettingType.PayerMg;
            else if ((sender as ThemedButton).Name.Equals(btnSelectAllPayee.Name))
                fst = FunctionInSettingType.PayeeMg;
            else if ((sender as ThemedButton).Name.Equals(btnSelectAllElecTicketRelation.Name))
                fst = FunctionInSettingType.ElecTicketRelateAccountMg;
            else if ((sender as ThemedButton).Name.Equals(btnSelectAllGlobalPayee.Name))
                fst = FunctionInSettingType.OverCountryPayeeMg;
            else if ((sender as ThemedButton).Name.Equals(btnSelectAllExpressOutPayer.Name))
                fst = FunctionInSettingType.AgentExpressInPayerMg;
            CommandCenter.ResolveSettingsOperate(OperatorCommandType.SelectAll, fst);
        }

        private void btnSelectRe_Click(object sender, EventArgs e)
        {
            FunctionInSettingType fst = FunctionInSettingType.Empty;
            if ((sender as ThemedButton).Name.Equals(btnSelectRePayer.Name))
                fst = FunctionInSettingType.PayerMg;
            else if ((sender as ThemedButton).Name.Equals(btnSelectRePayee.Name))
                fst = FunctionInSettingType.PayeeMg;
            else if ((sender as ThemedButton).Name.Equals(btnSelectReElecTicketRelation.Name))
                fst = FunctionInSettingType.ElecTicketRelateAccountMg;
            else if ((sender as ThemedButton).Name.Equals(btnSelectReGlobalPayee.Name))
                fst = FunctionInSettingType.OverCountryPayeeMg;
            else if ((sender as ThemedButton).Name.Equals(btnSelectReExpressOutPayer.Name))
                fst = FunctionInSettingType.AgentExpressInPayerMg;
            CommandCenter.ResolveSettingsOperate(OperatorCommandType.SelectRe, fst);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FunctionInSettingType fst = FunctionInSettingType.Empty;
            if ((sender as ThemedButton).Name.Equals(btnDeletePayer.Name))
                fst = FunctionInSettingType.PayerMg;
            else if ((sender as ThemedButton).Name.Equals(btnDeletePayee.Name))
                fst = FunctionInSettingType.PayeeMg;
            else if ((sender as ThemedButton).Name.Equals(btnDeleteElecTicketRelation.Name))
                fst = FunctionInSettingType.ElecTicketRelateAccountMg;
            else if ((sender as ThemedButton).Name.Equals(btnDeleteGlobalPayee.Name))
                fst = FunctionInSettingType.OverCountryPayeeMg;
            else if ((sender as ThemedButton).Name.Equals(btnDeleteExpressOutPayer.Name))
                fst = FunctionInSettingType.AgentExpressInPayerMg;
            CommandCenter.ResolveSettingsOperate(OperatorCommandType.Delete, fst);
        }

        private void btnImport_MouseHover(object sender, EventArgs e)
        {
            string tips = string.Empty;
            if ((sender as ThemedButton).Name == btnElecImport.Name)
                tips = "支持导入的文件如下：从网银端下载的关系人文件(csv格式)和从本工具导出的关系人文件(txt格式)";
            else tips = "支持导入的文件如下：从本工具导出的关系人文件(txt格式)";
            this.toolTip1.Show(tips, (sender as ThemedButton));
        }

        public override void BringToFrontEx(string plugName, FunctionInSettingType fst, AppliableFunctionType aft)
        {
            if (fst == FunctionInSettingType.AddtionMg)
            {
                this.tabControl2.SelectedTab = tpAddition;
                cmbFunctionTypeForComments.SelectedIndex = (cmbFunctionTypeForComments.Tag as List<AppliableFunctionType>).FindIndex(o => o == aft);
            }
            else if (fst == FunctionInSettingType.FunctionSetting)
            {
                this.tabControl2.SelectedTab = tpFunctionSetting;
            }
        }
    }
}
