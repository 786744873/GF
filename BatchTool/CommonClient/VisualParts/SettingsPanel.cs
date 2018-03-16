using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.EnumTypes;
using CommonClient.Utilities;
using CommonClient.Entities;
using CommonClient.MatchFile;
using System.IO;
using CommonClient.Controls;

namespace CommonClient.VisualParts
{
    public partial class SettingsPanel : BaseUc
    {
        public SettingsPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            p_Settings.BringToFront();
            LoadBatchChangeType(SystemSettings.AppliableTypes, SystemSettings.AppliableTypes4Bar);

            this.cmbFunctionTypeForBatchMap.SelectedIndex = -1;
            this.cmbFunctionTypeForComments.SelectedIndex = -1;
            cmbType.SelectedIndex = -1;

            this.Load += new EventHandler(SettingsPanel_Load);
            CommandCenter.OnAppliableEventHandler += new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler);
            CommandCenter.OnShowPanelEventHandler += new EventHandler<ShowPanelEventArgs>(CommandCenter_OnShowPanelEventHandler);
            CommandCenter.OnLanguageChangedEventHandler += new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler);
        }

        void CommandCenter_OnLanguageChangedEventHandler(object sender, LanguageChangedEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<LanguageChangedEventArgs>(CommandCenter_OnLanguageChangedEventHandler), sender, e); }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(base.GetLanguageString(e.Language));
                base.ApplyResource(typeof(SettingsPanel), this);
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
            CommandCenter.ResolveMoveMenu(OperatorCommandType.View, 0, 0, 0, 0, 0, OperatorCommandType.View);
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
                if (e.BatchAppType == FunctionInSettingType.BatchConvert)
                    p_FileConvert.BringToFront();
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
                        case FunctionInSettingType.CommonInfoMg: tabControl2.SelectedTab = tpCommandFields; break;
                        case FunctionInSettingType.ElecTicketRelateAccountMg: tabControl2.SelectedTab = tpElecTicketRelateAccount; break;
                        default: break;
                    }
                }
            }
        }

        private void btnSaveVisibleTabs_Click(object sender, EventArgs e)
        {
            CommandCenter.ResolveAppliableFunction(OperatorCommandType.AppVisiableRequest, AppliableFunctionType._Empty, AppliableFunctionType._Empty);
            MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Submit_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cmbType.Items.Clear();
            cmbFunctionTypeForBatchMap.Items.Clear();
            cmbFunctionTypeForComments.Items.Clear();
            cmbFunctionTypeForBatchMap.Items.Add(EnumNameHelper<FunctionInSettingType>.GetEnumDescription(FunctionInSettingType.PayeeMg));
            List<AppliableFunctionType> listM = new List<AppliableFunctionType>();
            List<AppliableFunctionType> listN = new List<AppliableFunctionType>();
            cmbType.Items.Add(EnumNameHelper<FunctionInSettingType>.GetEnumDescription(FunctionInSettingType.PayeeMg));
            foreach (AppliableFunctionType appliableFunctionType in PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
            {
                if (appliableFunctionType == AppliableFunctionType._Empty) continue;
                if (((long)appliableFunctionType > 0 && (appliableFunctionType & aft) != appliableFunctionType)
                    || ((long)appliableFunctionType < 0 && ((AppliableFunctionType)Math.Abs((long)appliableFunctionType) & aftBar) != (AppliableFunctionType)Math.Abs((long)appliableFunctionType))) continue;
                var value = EnumNameHelper<AppliableFunctionType>.GetEnumDescription(appliableFunctionType);
                this.cmbType.Items.Add(value);
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
                    || appliableFunctionType == AppliableFunctionType.TransferOverCountry4Bar)
                {
                    this.cmbFunctionTypeForComments.Items.Add(value);
                    listN.Add(appliableFunctionType);
                }
            }
            cmbType.Tag =
            cmbFunctionTypeForBatchMap.Tag = listM;
            cmbFunctionTypeForComments.Tag = listN;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (null == ((ThemedButton)sender).Tag) return;
            FunctionInSettingType fst = (FunctionInSettingType)((ThemedButton)sender).Tag;
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT);
            if (fst == FunctionInSettingType.ElecTicketRelateAccountMg) ofDialog.Filter += string.Format("|{0}|*.csv", MultiLanguageConvertHelper.DesignMain_FileType_CSV);
            if (ofDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string endstr = ofDialog.FilterIndex == 1 ? ".txt" : ".csv";
                string filepath = ofDialog.FileName;
                if (!filepath.ToLower().EndsWith(endstr)) { MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Select_File_Agent, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                else filepath = DataConvertHelper.FormatFileName(filepath, endstr);

                //查看当前文件是否被占用
                try
                {
                    using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read)) { }
                }
                catch (System.IO.IOException)
                {
                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Settings_Mappings_File_Is_Open_Please_Close_First, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }

                TemplateHelper.BatchConsignDataTemplateHelper.LoadBOCDocument(fst, OperatorCommandType.CombineData, filepath);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (null == ((ThemedButton)sender).Tag) return;
            FunctionInSettingType fst = (FunctionInSettingType)((ThemedButton)sender).Tag;
            bool flag = false;
            if (fst == FunctionInSettingType.PayeeMg) flag = payeeItemsPanel2.SaveData();
            else if (fst == FunctionInSettingType.ElecTicketRelateAccountMg) flag = elecTicketRelateAccountItemsPanel1.SaveData();
            else if (fst == FunctionInSettingType.AgentExpressInPayerMg) flag = agentExpressPayerItemsPanel1.SaveData();
            else if (fst == FunctionInSettingType.OverCountryPayeeMg) flag = transferGlobalPayeeItemsPanel1.SaveData();
            if (flag)
                MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Submit_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.DesignMain_Submit_Fail, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void llOpenMapSetting_Click(object sender, EventArgs e)
        {
            CommandCenter.ResolveShowPanel(OperatorCommandType.View, AppliableFunctionType._Empty, FunctionInSettingType.MapSetting);
        }

        private void btnTypeConvert_Click(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex < 0)
            {
                MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.Settings_Convert_Data_Type), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(cmbDataFile.Text))
            {
                MessageBoxExHelper.Instance.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.Settings_Convert_Data_File), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filepath = cmbDataFile.Text.Trim();
            AppliableFunctionType aft = AppliableFunctionType._Empty;
            FunctionInSettingType fst = FunctionInSettingType.Empty;
            if (cmbType.SelectedIndex == 0) fst = FunctionInSettingType.PayeeMg;
            else aft = (cmbType.Tag as List<AppliableFunctionType>)[cmbType.SelectedIndex - 1];
            if (!CommonInformations.CheckMappingSetting(aft, fst))
            {
                MessageBoxExHelper.Instance.Show(string.Format(MultiLanguageConvertHelper.Settings_Set_No_Mapping, cmbType.SelectedItem.ToString()), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            else if (!(filepath.ToLower().EndsWith(".xls") || filepath.ToLower().EndsWith(".xlsx")))
            {
                if ((aft != AppliableFunctionType._Empty && string.IsNullOrEmpty(SystemSettings.BatchMappingSettings[aft].SeperateChar.Trim())) || (fst != FunctionInSettingType.Empty && string.IsNullOrEmpty(SystemSettings.BatchSettingsMappingSettings[fst].SeperateChar.Trim())))
                {
                    MessageBoxExHelper.Instance.Show(string.Format("{0}{1}", MultiLanguageConvertHelper.Information_Please_Input, "分隔符"), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
            }
            BatchHeader batch = null;
            MappingsRelationSettings mrs = new MappingsRelationSettings();
            if (aft != AppliableFunctionType._Empty)
                mrs = SystemSettings.BatchMappingSettings[aft];
            else if (fst != FunctionInSettingType.Empty)
                mrs = SystemSettings.BatchSettingsMappingSettings[fst];

            if (aft == AppliableFunctionType.AgentExpressIn
                || aft == AppliableFunctionType.AgentExpressOut
                || aft == AppliableFunctionType.AgentNormalIn
                || aft == AppliableFunctionType.AgentNormalOut
                || aft == AppliableFunctionType.InitiativeAllot
                || aft == AppliableFunctionType.AgentExpressOut4Bar)
            {
                frmBatchHeader frm = new frmBatchHeader(aft);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                batch = frm.Batch;
                if ((aft == AppliableFunctionType.AgentNormalIn
                        || aft == AppliableFunctionType.AgentNormalOut)
                    && batch.CardType == AgentCardType.OtherBankCard)
                    mrs.MaxCountPerOperation = SystemSettings.DefaultMaxCountAgentNormal;
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

            frmConvertWaiting frmWaiting = new frmConvertWaiting();
            frmWaiting.Show(this);
            //转换开始
            List<object> list = MatchFileDataHelper.GetFileData(aft, fst, filepath, mrs, batch);
            //转换结束
            frmWaiting.Close();
            if (list[0] is string && !string.IsNullOrEmpty(list[0] as string))
            {
                MessageBoxExHelper.Instance.Show(list[0].ToString(), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (aft != AppliableFunctionType.AgentExpressOut4Bar
                    && aft != AppliableFunctionType.TransferForeignMoney4Bar
                    && aft != AppliableFunctionType.TransferOverCountry4Bar)
                {
                    SaveFileDialog sfDialog = new SaveFileDialog();
                    string fileType = string.Empty;
                    if (aft == AppliableFunctionType.PurchaserOrder
                        || aft == AppliableFunctionType.SellerOrder
                        || aft == AppliableFunctionType.PurchaserOrderMgr
                        || aft == AppliableFunctionType.SellerOrderMgr
                        || aft == AppliableFunctionType.BillofDebtReceivablePurchaser
                        || aft == AppliableFunctionType.BillofDebtReceivableSeller
                        || aft == AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser
                        || aft == AppliableFunctionType.ApplyofFranchiserFinancing)
                    {
                        sfDialog.Filter = string.Format("{0}|*.dif", MultiLanguageConvertHelper.DesignMain_FileType_DIF);
                        fileType = ".dif";
                    }
                    else
                    {
                        sfDialog.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT);
                        fileType = ".txt";
                    }
                    if (sfDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        filepath = DataConvertHelper.FormatFileName(sfDialog.FileName, fileType);
                        if (aft != AppliableFunctionType._Empty)
                            MatchFileDataHelper.SaveDataToTXT(list[1], aft, filepath);
                        else if (fst != FunctionInSettingType.Empty)
                            MatchFileDataHelper.SaveDataToTXT(list[1], fst, filepath);
                        MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Settings_Convert_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(SystemSettings.CustomerInfo.Group) || string.IsNullOrEmpty(SystemSettings.CustomerInfo.Code))
                    {
                        frmCustomerInfoMgr frm = new frmCustomerInfoMgr();
                        if (frm.ShowDialog() != DialogResult.OK) return;
                    }

                    AgentTransferBankType bankType = AgentTransferBankType.Boc;//batch != null ? batch.BankType : AgentTransferBankType.Other;
                    //if (aft == AppliableFunctionType.AgentExpressOut4Bar)
                    //bankType = batch != null ? batch.BankType : AgentTransferBankType.Other;
                    //else 
                    if (aft == AppliableFunctionType.TransferForeignMoney4Bar)
                    {
                        if ((list[1] as List<TransferGlobal>) != null && (list[1] as List<TransferGlobal>).Count > 0)
                            bankType = (list[1] as List<TransferGlobal>)[0].PayeeOpenBankType == AccountBankType.BocAccount ? AgentTransferBankType.Boc : AgentTransferBankType.Other;
                    }
                    string filename = CommonInformations.GetBarFileName(aft, bankType);
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() != DialogResult.OK) return;
                    filepath = System.IO.Path.Combine(fbd.SelectedPath, filename);
                    frmBarPassword frmpwd = new frmBarPassword();
                    if (frmpwd.ShowDialog() != DialogResult.OK) return;
                    string pwd = frmpwd.Password;

                    string filebar = DataConvertHelper.FormatFileName(filepath, ".bar");
                    bool result = MatchFileDataHelper.SaveDataToTXT(list[1], aft, filebar);
                    if (!result) { MessageBoxExHelper.Instance.Show("文件中无数据或者文件生成失败", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                    ResultData rd = new ResultData();
                    if (aft == AppliableFunctionType.AgentExpressOut4Bar)
                    {
                        string fpc1 = filepath.Replace("-C2-", "-C1-");
                        string fpc2 = filepath.Replace("-C1-", "-C2-");
                        string fpbarc1 = filebar.Replace("-C2-", "-C1-");
                        string fpbarc2 = filebar.Replace("-C1-", "-C2-");

                        if (File.Exists(fpbarc1))
                            rd = FileDataPasswordBarHelper.EncodeAndZip(fpbarc1, fpc1, pwd);
                        if (File.Exists(fpbarc2))
                            rd = FileDataPasswordBarHelper.EncodeAndZip(fpbarc2, fpc2, pwd);
                    }
                    else
                        rd = FileDataPasswordBarHelper.EncodeAndZip(filebar, filepath, pwd);
                    if (!rd.Result) { MessageBoxExHelper.Instance.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                    CommonInformations.SetNextOrderNo();

                    MessageBoxExHelper.Instance.Show(MultiLanguageConvertHelper.Settings_Convert_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSelectFileToConvert_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = string.Format("{0}|*.txt|{1}|*.csv|{2}|*.xls;*.xlsx", MultiLanguageConvertHelper.DesignMain_FileType_TXT, MultiLanguageConvertHelper.DesignMain_FileType_CSV, MultiLanguageConvertHelper.DesignMain_FileType_Excel);
            if (ofDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            cmbDataFile.Text = ofDialog.FileName;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            FunctionInSettingType fst = FunctionInSettingType.Empty;
            if ((sender as Controls.ThemedButton).Name.Equals(btnSelectAllPayer.Name))
                fst = FunctionInSettingType.PayerMg;
            else if ((sender as Controls.ThemedButton).Name.Equals(btnSelectAllPayee.Name))
                fst = FunctionInSettingType.PayeeMg;
            else if ((sender as Controls.ThemedButton).Name.Equals(btnSelectAllElecTicketRelation.Name))
                fst = FunctionInSettingType.ElecTicketRelateAccountMg;
            else if ((sender as Controls.ThemedButton).Name.Equals(btnSelectAllGlobalPayee.Name))
                fst = FunctionInSettingType.OverCountryPayeeMg;
            else if ((sender as Controls.ThemedButton).Name.Equals(btnSelectAllExpressOutPayer.Name))
                fst = FunctionInSettingType.AgentExpressInPayerMg;
            CommandCenter.ResolveSettingsOperate(OperatorCommandType.SelectAll, fst);
        }

        private void btnSelectRe_Click(object sender, EventArgs e)
        {
            FunctionInSettingType fst = FunctionInSettingType.Empty;
            if ((sender as Controls.ThemedButton).Name.Equals(btnSelectRePayer.Name))
                fst = FunctionInSettingType.PayerMg;
            else if ((sender as Controls.ThemedButton).Name.Equals(btnSelectRePayee.Name))
                fst = FunctionInSettingType.PayeeMg;
            else if ((sender as Controls.ThemedButton).Name.Equals(btnSelectReElecTicketRelation.Name))
                fst = FunctionInSettingType.ElecTicketRelateAccountMg;
            else if ((sender as Controls.ThemedButton).Name.Equals(btnSelectReGlobalPayee.Name))
                fst = FunctionInSettingType.OverCountryPayeeMg;
            else if ((sender as Controls.ThemedButton).Name.Equals(btnSelectReExpressOutPayer.Name))
                fst = FunctionInSettingType.AgentExpressInPayerMg;
            CommandCenter.ResolveSettingsOperate(OperatorCommandType.SelectRe, fst);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FunctionInSettingType fst = FunctionInSettingType.Empty;
            if ((sender as Controls.ThemedButton).Name.Equals(btnDeletePayer.Name))
                fst = FunctionInSettingType.PayerMg;
            else if ((sender as Controls.ThemedButton).Name.Equals(btnDeletePayee.Name))
                fst = FunctionInSettingType.PayeeMg;
            else if ((sender as Controls.ThemedButton).Name.Equals(btnDeleteElecTicketRelation.Name))
                fst = FunctionInSettingType.ElecTicketRelateAccountMg;
            else if ((sender as Controls.ThemedButton).Name.Equals(btnDeleteGlobalPayee.Name))
                fst = FunctionInSettingType.OverCountryPayeeMg;
            else if ((sender as Controls.ThemedButton).Name.Equals(btnDeleteExpressOutPayer.Name))
                fst = FunctionInSettingType.AgentExpressInPayerMg;
            CommandCenter.ResolveSettingsOperate(OperatorCommandType.Delete, fst);
        }

        private void btnImport_MouseHover(object sender, EventArgs e)
        {
            string tips = string.Empty;
            if ((sender as Controls.ThemedButton).Name == btnElecImport.Name)
                tips = "支持导入的文件如下：从网银端下载的关系人文件(csv格式)和从本工具导出的关系人文件(txt格式)";
            else tips = "支持导入的文件如下：从本工具导出的关系人文件(txt格式)";
            this.toolTip1.Show(tips, (sender as Controls.ThemedButton));
        }
    }
}
