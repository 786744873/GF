using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.VisualParts;
using CommonClient.ConvertHelper;
using CommonClient.SysCoach;
using CommonClient.EnumTypes;
using CommonClient.Utilities;
using CommonClient.Entities;
using System.IO;
using CommonClient.MatchFile;
using System.Text.RegularExpressions;

namespace CommonClient.VisualParts2
{
    public partial class FileConverter : BaseUc
    {
        public FileConverter()
        {
            InitializeComponent();

            btnNextStep.Tag = FileConvertSteps.Second;
            btnPreStep.Tag = FileConvertSteps.First;
            btnReturn.Tag = FileConvertSteps.Finish;
            btnSaveSetting.Tag = FileConvertSteps.Finish;

            RefreshStep();
            CommandCenter.OnAppliableEventHandler += new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler);
            InitData();
        }

        void CommandCenter_OnAppliableEventHandler(object sender, AppliableEventArgs e)
        {
            if (this.InvokeRequired) { this.Invoke(new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler), new object[] { sender, e }); }
            else
            {
                if (e.Command != OperatorCommandType.AppVisiableResolve) return;
                InitData();
            }
        }

        private void InitData()
        {
            cmbType.Items.Clear();
            List<AppliableFunctionType> listM = new List<AppliableFunctionType>();
            List<AppliableFunctionType> listN = new List<AppliableFunctionType>();
            cmbType.Items.Add(EnumNameHelper<FunctionInSettingType>.GetEnumDescription(FunctionInSettingType.PayeeMg));
            foreach (AppliableFunctionType appliableFunctionType in PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
            {
                if (appliableFunctionType == AppliableFunctionType._Empty) continue;
                if (((int)appliableFunctionType > 0 && (appliableFunctionType & SystemSettings.AppliableTypes) != appliableFunctionType)
                    || ((int)appliableFunctionType < 0 && ((AppliableFunctionType)Math.Abs((int)appliableFunctionType) & SystemSettings.AppliableTypes4Bar) != (AppliableFunctionType)Math.Abs((int)appliableFunctionType))) continue;
                var value = EnumNameHelper<AppliableFunctionType>.GetEnumDescription(appliableFunctionType);
                this.cmbType.Items.Add(value);
                listM.Add(appliableFunctionType);
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
                    listN.Add(appliableFunctionType);
                }
            }

            if ((SystemSettings.CurrentVersion & VersionType.v405) == VersionType.v405)
            {
                cmbType.Items.Add(EnumNameHelper<FunctionInSettingType>.GetEnumDescription(FunctionInSettingType.TodayOrHistoryTransferMg));
            }

            cmbType.Tag = listM;
            fcs = FileConvertSteps.Finish;
            this.fileConverterFieldsSetting1.ResetFields(null);
            RefreshStep();
        }

        FileConvertSteps fcs = FileConvertSteps.Finish;

        void RefreshStep()
        {
            llModify.Visible = fcs == FileConvertSteps.Finish;
            switch (fcs)
            {
                case FileConvertSteps.First:
                    #region
                    btnConvertFile.Visible =
                    btnSaveSetting.Visible =
                    btnReturn.Visible =
                    btnPreStep.Visible = false;
                    btnNextStep.Visible = true;

                    p_Steps.Visible =
                    p_FileSelecter.Visible =
                    p_ArgumentsSetting.Visible = true;
                    p_FieldsSetting.Visible =
                    p_Tip.Visible = false;

                    p_second.BackgroundImage = Properties.Resources.second;
                    p_third.BackgroundImage = Properties.Resources.third;
                    lbsecond.ForeColor = lbthird.ForeColor = SystemColors.ControlText;
                    break;
                    #endregion
                case FileConvertSteps.Second:
                    #region
                    fileConverterFieldsSetting1.ShowType = ShowType.Modify;
                    btnSaveSetting.Visible =
                    btnPreStep.Visible = true;
                    btnConvertFile.Visible =
                    btnNextStep.Visible =
                    btnReturn.Visible = false;

                    p_FileSelecter.Visible =
                    p_ArgumentsSetting.Visible = false;
                    p_Steps.Visible =
                    p_FieldsSetting.Visible =
                    p_Tip.Visible = true;

                    p_second.BackgroundImage = Properties.Resources.second_cur;
                    p_third.BackgroundImage = Properties.Resources.third;
                    lbsecond.ForeColor = Color.White;
                    lbthird.ForeColor = SystemColors.ControlText;
                    break;
                    #endregion
                case FileConvertSteps.Modify:
                    #region
                    fileConverterFieldsSetting1.ShowType = ShowType.Modify;
                    btnSaveSetting.Visible =
                    btnReturn.Visible = true;
                    btnConvertFile.Visible =
                    btnPreStep.Visible =
                    btnNextStep.Visible = false;

                    p_Steps.Visible =
                    p_FileSelecter.Visible = false;
                    p_ArgumentsSetting.Visible =
                    p_FieldsSetting.Visible =
                    p_Tip.Visible = true;
                    break;
                    #endregion
                case FileConvertSteps.Finish:
                    #region
                    fileConverterFieldsSetting1.ShowType = ShowType.View;
                    btnConvertFile.Visible = true;
                    btnReturn.Visible =
                    btnSaveSetting.Visible =
                    btnPreStep.Visible =
                    btnNextStep.Visible = false;

                    p_Steps.Visible =
                    p_FileSelecter.Visible =
                    p_ArgumentsSetting.Visible =
                    p_FieldsSetting.Visible =
                    p_Tip.Visible = true;

                    p_second.BackgroundImage = Properties.Resources.second_cur;
                    p_third.BackgroundImage = Properties.Resources.third_cur;
                    lbsecond.ForeColor = lbthird.ForeColor = Color.White;
                    break;
                    #endregion
                default: fcs = FileConvertSteps.Finish; RefreshStep(); break;
            }

            tbSeparator.ReadOnly = tbStartRowIndex.ReadOnly = tbEndRowIndex.ReadOnly = fcs == FileConvertSteps.Finish;
            if (fcs == FileConvertSteps.Second || fcs == FileConvertSteps.Modify)
                fileConverterFieldsSetting1.LoadFiledsInFile(cmbDataFile.Text.Trim(), tbSeparator.Text.Trim(), tbStartRowIndex.Text.Trim());
        }

        private void btnSelectFileToConvert_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = string.Format("{0}|*.txt|{1}|*.csv", MultiLanguageConvertHelper.DesignMain_FileType_TXT, MultiLanguageConvertHelper.DesignMain_FileType_CSV);
            if (!((SystemSettings.CurrentVersion & VersionType.v405) == VersionType.v405 && cmbType.SelectedIndex > (cmbType.Tag as List<AppliableFunctionType>).Count))
                ofDialog.Filter += string.Format("|{0}|*.xls;*.xlsx", MultiLanguageConvertHelper.DesignMain_FileType_Excel);
            if (ofDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            cmbDataFile.Text = ofDialog.FileName;
        }

        private void btnConvertFile_Click(object sender, EventArgs e)
        {
            #region 判断业务类型和文件路径
            if (cmbType.SelectedIndex < 0)
            {
                MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.Settings_Convert_Data_Type), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(cmbDataFile.Text))
            {
                MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.Settings_Convert_Data_File), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            string filepath = cmbDataFile.Text.Trim();
            AppliableFunctionType aft = AppliableFunctionType._Empty;
            FunctionInSettingType fst = FunctionInSettingType.Empty;
            if (cmbType.SelectedIndex == 0) fst = FunctionInSettingType.PayeeMg;
            else
            {
                #region 今日和历史交易
                int index = cmbType.SelectedIndex - (cmbType.Tag as List<AppliableFunctionType>).Count;
                if (index > 0)
                {
                    if (index == 1)
                        fst = FunctionInSettingType.TodayOrHistoryTransferMg;
                }
                if (fst == FunctionInSettingType.Empty)
                    aft = (cmbType.Tag as List<AppliableFunctionType>)[cmbType.SelectedIndex - 1];
                #endregion
            }
            bool convertTypeFlag = false;
            if ((SystemSettings.CurrentVersion & VersionType.v405) == VersionType.v405)
            {
                convertTypeFlag = aft == AppliableFunctionType._Empty && fst != FunctionInSettingType.Empty && fst != FunctionInSettingType.PayeeMg;
            }
            if (!convertTypeFlag)
            {
                #region 检查映射关系
                if (!CommonInformations.CheckMappingSetting(aft, fst))
                {
                    MessageBoxPrime.Show(string.Format(MultiLanguageConvertHelper.Settings_Set_No_Mapping, cmbType.SelectedItem.ToString()), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return;
                }
                else if (!(filepath.ToLower().EndsWith(".xls") || filepath.ToLower().EndsWith(".xlsx")))
                {
                    if ((aft != AppliableFunctionType._Empty && string.IsNullOrEmpty(SystemSettings.BatchMappingSettings[aft].SeperateChar.Trim())) || (fst != FunctionInSettingType.Empty && string.IsNullOrEmpty(SystemSettings.BatchSettingsMappingSettings[fst].SeperateChar.Trim())))
                    {
                        MessageBoxPrime.Show(string.Format("{0}{1}", MultiLanguageConvertHelper.Information_Please_Input, "分隔符"), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return;
                    }
                }
                #endregion
            }
            BatchHeader batch = null;
            MappingsRelationSettings mrs = new MappingsRelationSettings();

            #region 获取映射关系
            if (!convertTypeFlag)
            {
                #region
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
                #endregion
            }
            else
            {
                #region 今日和历史交易
                mrs.SeperateChar = filepath.EndsWith(".csv") ? "," : filepath.EndsWith(".txt") ? "|" : string.Empty;
                mrs.StartRowIndex = 1;
                mrs.MaxCountPerOperation = 1000;
                #endregion
            }
            #endregion

            #region 查看当前文件是否被占用
            try
            {
                using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read)) { }
            }
            catch (System.IO.IOException)
            {
                MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_File_Is_Open_Please_Close_First, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return;
            }
            #endregion

            #region 文件转换
            frmConvertWaiting frmWaiting = new frmConvertWaiting();
            frmWaiting.Show(this);
            btnSelectFileToConvert.Enabled = false;
            //转换开始
            List<object> list = MatchFileDataHelper.GetFileData(aft, fst, filepath, mrs, batch);
            //转换结束
            frmWaiting.Close();
            btnSelectFileToConvert.Enabled = true;
            #endregion

            #region 生成文件
            if (list[0] is string && !string.IsNullOrEmpty(list[0] as string))
            {
                MessageBoxPrime.Show(list[0].ToString(), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
            }
            else
            {
                //网银业务
                if (aft != AppliableFunctionType.AgentExpressOut4Bar
                    && aft != AppliableFunctionType.TransferForeignMoney4Bar
                    && aft != AppliableFunctionType.TransferOverCountry4Bar)
                {
                    #region
                    //今日交易、历史交易
                    if (fst == FunctionInSettingType.TodayOrHistoryTransferMg)
                    {
                        SaveFileDialog sfg = new SaveFileDialog();
                        string fileType = ".txt";
                        if (filepath.EndsWith(".txt"))
                            sfg.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT);
                        else if (filepath.EndsWith(".csv"))
                        {
                            sfg.Filter = string.Format("{0}|*.csv", MultiLanguageConvertHelper.DesignMain_FileType_CSV);
                            fileType = ".csv";
                        }
                        if (sfg.ShowDialog() != DialogResult.OK) return;

                        string newfilepath = DataConvertHelper.FormatFileName(sfg.FileName.Trim(), fileType);
                        MatchFileDataHelper.SaveDataToBOCFile((List<string>)list[1], fst, filepath, newfilepath);
                        MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Convert_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                    }
                    else//转换业务
                    {
                        #region
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
                        if (sfDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            filepath = DataConvertHelper.FormatFileName(sfDialog.FileName, fileType);
                            if (aft != AppliableFunctionType._Empty)
                                MatchFileDataHelper.SaveDataToTXT(list[1], aft, filepath);
                            else if (fst == FunctionInSettingType.PayeeMg)
                                MatchFileDataHelper.SaveDataToTXT(list[1], fst, filepath);
                            MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Convert_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                        }
                        #endregion
                    }
                    #endregion
                }
                else//柜台业务
                {
                    #region
                    if (string.IsNullOrEmpty(SystemSettings.CustomerInfo.Group) || string.IsNullOrEmpty(SystemSettings.CustomerInfo.Code))
                    {
                        frmCustomerInfoMgr frm = new frmCustomerInfoMgr();
                        if (frm.ShowDialog() != DialogResult.OK) return;
                    }

                    AgentTransferBankType bankType = AgentTransferBankType.Boc;//batch != null ? batch.BankType : AgentTransferBankType.Other;
                    //if (aft == AppliableFunctionType.AgentExpressOut4Bar)
                    //bankType = batch != null ? batch.BankType : AgentTransferBankType.Other;
                    //else 
                    //if (aft == AppliableFunctionType.TransferForeignMoney4Bar)
                    //{
                    //    if ((list[1] as List<TransferGlobal>) != null && (list[1] as List<TransferGlobal>).Count > 0)
                    //        bankType = (list[1] as List<TransferGlobal>)[0].PayeeOpenBankType == AccountBankType.BocAccount ? AgentTransferBankType.Boc : AgentTransferBankType.Other;
                    //}
                    string filename = CommonInformations.GetBarFileName(aft, bankType);
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() != DialogResult.OK) return;
                    filepath = System.IO.Path.Combine(fbd.SelectedPath, filename);
                    frmBarPassword frmpwd = new frmBarPassword();
                    if (frmpwd.ShowDialog() != DialogResult.OK) return;
                    string pwd = frmpwd.Password;

                    string filebar = DataConvertHelper.FormatFileName(filepath, ".bar");
                    bool result = MatchFileDataHelper.SaveDataToTXT(list[1], aft, filebar);
                    if (!result) { MessageBoxPrime.Show("文件中无数据或者文件生成失败", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }

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
                    else if (aft == AppliableFunctionType.TransferForeignMoney4Bar)
                    {
                        string fpc1 = filepath.Replace("-C5-", "-C1-");
                        string fpc2 = filepath.Replace("-C1-", "-C5-");
                        string fpbarc1 = filebar.Replace("-C5-", "-C1-");
                        string fpbarc2 = filebar.Replace("-C1-", "-C5-");

                        if (File.Exists(fpbarc1))
                            rd = FileDataPasswordBarHelper.EncodeAndZip(fpbarc1, fpc1, pwd);
                        if (File.Exists(fpbarc2))
                            rd = FileDataPasswordBarHelper.EncodeAndZip(fpbarc2, fpc2, pwd);
                    }
                    else
                        rd = FileDataPasswordBarHelper.EncodeAndZip(filebar, filepath, pwd);
                    if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }

                    CommonInformations.SetNextOrderNo();

                    MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Convert_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                    #endregion
                }
            }
            #endregion
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            string btnname = (sender as CommonClient.Controls.ThemedButton).Name;
            if (btnNextStep.Name.Equals(btnname))
            { if (!CheckArguments()) return; }
            else if (btnSaveSetting.Name.Equals(btnname))
            {
                if (fcs == FileConvertSteps.Modify && !CheckArguments()) return;
                if (!fileConverterFieldsSetting1.GetFieldsMapping()) return;
                SaveSettings();
            }
            fcs = (FileConvertSteps)(sender as CommonClient.Controls.ThemedButton).Tag;
            RefreshStep();
        }

        bool CheckArguments()
        {
            #region 判断业务类型和文件路径
            if (cmbType.SelectedIndex < 0)
            {
                MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.Settings_Convert_Data_Type), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(cmbDataFile.Text))
            {
                MessageBoxPrime.Show(string.Format("{0} {1}", MultiLanguageConvertHelper.Information_Please_Select, MultiLanguageConvertHelper.Settings_Convert_Data_File), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                return false;
            }
            #endregion

            if (cmbDataFile.Text.Trim().ToLower().EndsWith(".txt") || cmbDataFile.Text.Trim().ToLower().EndsWith(".csv"))
            {
                if (string.IsNullOrEmpty(tbSeparator.Text.Trim()))
                {
                    tbSeparator.DvRequired = true;
                    tbSeparator.ManualValidate();
                }
            }
            else tbSeparator.DvRequired = false;
            return tbSeparator.DvValidatePassed && tbStartRowIndex.DvValidatePassed && (((cmbDataFile.Text.Trim().ToLower().EndsWith(".txt") || cmbDataFile.Text.Trim().ToLower().EndsWith(".csv")) && !string.IsNullOrEmpty(tbSeparator.Text.Trim())) || (cmbDataFile.Text.Trim().ToLower().EndsWith(".xls") || cmbDataFile.Text.Trim().ToLower().EndsWith(".xlsx")));
        }

        void SaveSettings()
        {
            AppliableFunctionType aft = AppliableFunctionType._Empty;
            FunctionInSettingType fst = FunctionInSettingType.Empty;
            if (cmbType.SelectedIndex == 0 || cmbType.SelectedIndex > (cmbType.Tag as List<AppliableFunctionType>).Count)
            {
                if (cmbType.SelectedIndex == 0) fst = FunctionInSettingType.PayeeMg;
                else if (cmbType.SelectedIndex == (cmbType.Tag as List<AppliableFunctionType>).Count + 1) fst = FunctionInSettingType.TodayOrHistoryTransferMg;
            }
            else
                aft = (cmbType.Tag as List<AppliableFunctionType>)[cmbType.SelectedIndex - 1];

            MappingsRelationSettings mrs = new MappingsRelationSettings();
            mrs.SeperateChar = tbSeparator.Text.Trim();
            if (!string.IsNullOrEmpty(tbStartRowIndex.Text.Trim()))
                mrs.StartRowIndex = int.Parse(tbStartRowIndex.Text.Trim());
            else
                mrs.StartRowIndex = 1;
            if (!string.IsNullOrEmpty(tbEndRowIndex.Text.Trim()))
                mrs.EndRowIndex = int.Parse(tbEndRowIndex.Text.Trim());
            mrs.MaxCountPerOperation = fst == FunctionInSettingType.PayeeMg ? SystemSettings.DefaultMaxCountPayeeMgr : CommonInformations.GetFunctionMaximum(aft);
            mrs.FieldsMappings = fileConverterFieldsSetting1.Mappings.FieldsMappings;
            mrs.BatchFieldsMappings = fileConverterFieldsSetting1.Mappings.BatchFieldsMappings;

            CommandCenter.ResolveFieldMapping(OperatorCommandType.MappingSettingResolve, aft, mrs, fst, FunctionInSettingType.MapSetting);
            MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Submit_Succeed, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex < 0) return;
            AppliableFunctionType aft = AppliableFunctionType._Empty;
            FunctionInSettingType fst = FunctionInSettingType.Empty;
            if (cmbType.SelectedIndex == 0)
            {
                label7.Text = string.Format("每批次转换最大笔数为{0}笔", 200);
                label7.Visible = true;
                fst = FunctionInSettingType.PayeeMg;
            }
            else
            {
                if (cmbType.SelectedIndex <= (cmbType.Tag as List<AppliableFunctionType>).Count) aft = (cmbType.Tag as List<AppliableFunctionType>)[cmbType.SelectedIndex - 1];
                if (aft != AppliableFunctionType._Empty) label7.Text = string.Format("每批次转换最大笔数为{0}笔", CommonInformations.GetFunctionMaximum(aft));
                label7.Visible = aft != AppliableFunctionType._Empty;
            }
            if (aft != AppliableFunctionType._Empty || fst != FunctionInSettingType.Empty)
            {
                fileConverterFieldsSetting1.AppType = aft;
                fileConverterFieldsSetting1.FunType = fst;
                if (!CommonInformations.CheckMappingSetting(aft, fst))
                {
                    fcs = FileConvertSteps.First;
                    RefreshStep();
                }
                else
                {
                    fcs = FileConvertSteps.Finish;
                    RefreshStep();
                }

                MappingsRelationSettings mrs = fst != FunctionInSettingType.Empty ? SystemSettings.BatchSettingsMappingSettings[fst] : SystemSettings.BatchMappingSettings[aft];

                tbStartRowIndex.Text = mrs.StartRowIndex.ToString();
                if (mrs.EndRowIndex != null) tbEndRowIndex.Text = mrs.EndRowIndex.ToString();
                tbSeparator.Text = mrs.SeperateChar;
                fileConverterFieldsSetting1.Mappings = mrs;
            }
            else
            {
                if (fcs != FileConvertSteps.Finish)
                {
                    fcs = FileConvertSteps.Finish;
                    RefreshStep();
                }
                p_ArgumentsSetting.Visible = p_FieldsSetting.Visible = false;
            }
        }

        private void llModify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmbType.SelectedIndex < 0 || cmbType.SelectedIndex > (cmbType.Tag as List<AppliableFunctionType>).Count)
            {
                MessageBoxPrime.Show("请选择需要做映射关系的业务类型", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(cmbDataFile.Text.Trim()))
            {
                MessageBoxPrime.Show("请选择拟转换的文件", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbDataFile.Text.Trim().ToLower().EndsWith(".txt") || cmbDataFile.Text.Trim().ToLower().EndsWith(".csv"))
            {
                if (string.IsNullOrEmpty(tbSeparator.Text.Trim()))
                {
                    MessageBoxPrime.Show("请填写拟转换的文件中的分隔符", CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OKCancel, MessageBoxIcon.Information);
                    tbSeparator.ReadOnly = false;
                    return;
                }
            }
            fcs = FileConvertSteps.Modify;
            RefreshStep();
        }

        private void tbEndRowIndex_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbEndRowIndex.Text.Trim()))
            {
                if (!Regex.IsMatch(tbEndRowIndex.Text.Trim(), @"^[0-9]*$", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                    tbEndRowIndex.Text = string.Empty;
            }
        }
    }

    enum FileConvertSteps
    {
        First = 1,
        Second = 2,
        Finish = 3,
        Modify = 4,
    }
}
