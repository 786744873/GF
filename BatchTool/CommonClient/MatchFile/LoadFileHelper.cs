using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient.SysCoach;
using System.IO;
using System.Windows.Forms;

namespace CommonClient.TemplateHelper
{
    public class LoadFileHelper
    {
        public static void LoadFiles(OperatorCommandType loadType, AppliableFunctionType aft, bool isBOC)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            string fileExtent = string.Empty;
            if (loadType == OperatorCommandType.ErrorData)
            { ofDialog.Filter = string.Format("{0}|*.csv", MultiLanguageConvertHelper.DesignMain_FileType_CSV); fileExtent = ".csv"; }
            else
            { ofDialog.Filter = string.Format("{0}|*.txt", MultiLanguageConvertHelper.DesignMain_FileType_TXT); fileExtent = ".txt"; }
            if ((aft == AppliableFunctionType.AgentExpressOut
                    && SystemSettings.IsMatchPassword4ShortProxyOut
                    && !string.IsNullOrEmpty(SystemSettings.ShortProxyOutPassword)))
            //|| (aft == AppliableFunctionType.TransferOverCountry
            //    && SystemSettings.IsMatchPassword4TransferOverCountry
            //    && !string.IsNullOrEmpty(SystemSettings.TransferOverCountryPassword))
            //|| (aft == AppliableFunctionType.TransferForeignMoney
            //    && SystemSettings.IsMatchPassword4TransferForeignMoney
            //    && !string.IsNullOrEmpty(SystemSettings.TransferForeignMoneyPassword)))
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
            else if (aft == AppliableFunctionType.PreproccessTransfer && loadType != OperatorCommandType.ErrorData)
            {
                ofDialog.Filter += string.Format("|{0}|*.csv", MultiLanguageConvertHelper.DesignMain_FileType_CSV);
            }
            else if (aft == AppliableFunctionType.TransferOverCountry4Bar
                || aft == AppliableFunctionType.TransferForeignMoney4Bar || aft == AppliableFunctionType.AgentExpressOut4Bar)
            {
                ofDialog.Filter = string.Format("{0}|*.dat", "柜台加密文件");
                fileExtent = ".dat";
            }
            if (ofDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileExtent = ofDialog.FilterIndex == 1 ? fileExtent : (aft == AppliableFunctionType.AgentExpressOut ? ".sef" : ".csv");
                string filepath = ofDialog.FileName;
                string pwd = string.Empty;
                //查看当前文件是否被占用
                try
                {
                    using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read)) { }
                }
                catch (System.IO.IOException)
                {
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.Settings_Mappings_File_Is_Open_Please_Close_First, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return;
                }

                if (!filepath.ToLower().EndsWith(fileExtent))
                {
                    MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Select_File_Agent, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return;
                }
                else filepath = DataConvertHelper.FormatFileName(filepath, fileExtent);
                ResultData rd = CommandCenter.ResolveOpenFile(filepath, loadType, aft, isBOC, pwd);
                if (!rd.Result) { MessageBoxPrime.Show(rd.Message, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); }

            }
            if (ofDialog != null)
                ofDialog.Dispose();
        }
    }
}
