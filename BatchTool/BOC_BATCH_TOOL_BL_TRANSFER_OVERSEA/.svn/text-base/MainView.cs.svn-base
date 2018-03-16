using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonClient.VisualParts;
using CommonClient.SysCoach;
using CommonClient.Contract;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient;
using CommonClient.ConvertHelper;
using System.IO;
using CommonClient.TemplateHelper;
using CommonClient.Controls;
namespace BOC_BATCH_TOOL_BL_TRANSFER_OVERSEA
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_BL_TRANSFER_OVERSEA", false, 100, "跨境汇款", AppliableFunctionType.TransferOverCountry4Bar)]
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
                if (e.AppType != AppliableFunctionType.TransferOverCountry4Bar) return;
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
            if (!transferGlobalItemsPanel_CountryBar.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveTransferGlobal(command, AppliableFunctionType.TransferOverCountry4Bar);
                CommandCenter.ResolveTransferGlobal(OperatorCommandType.Reset, AppliableFunctionType.TransferOverCountry4Bar);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.TransferOverCountry4Bar, true);
            #endregion
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            #region tgRemit
            TransferGlobal tgRemit = null;

            if (transferGlobalRemitSelector_CountryBar.CheckData())
            {
                transferGlobalRemitSelector_CountryBar.GetItem();
                tgRemit = transferGlobalRemitSelector_CountryBar.TransferGlobal;
            }

            #endregion

            #region tgPayee
            TransferGlobal tgPayee = null;
            bool savePayee = false;

            if (transferGlobalPayeeSelector_CountryBar.CheckData())
            {
                transferGlobalPayeeSelector_CountryBar.GetItem();
                tgPayee = transferGlobalPayeeSelector_CountryBar.TransferGlobal;
                savePayee = transferGlobalPayeeSelector_CountryBar.SavePayee;
            }

            savePayee = true;
            #endregion

            #region tgOther
            TransferGlobal tgOther = null;
            bool saveNotice = false;

            if (transferGlobalOtherSelector_CountryBar.CheckData())
            {
                transferGlobalOtherSelector_CountryBar.GetItem();
                tgOther = transferGlobalOtherSelector_CountryBar.TransferGlobal;
                saveNotice = transferGlobalOtherSelector_CountryBar.SaveRemitNote;
            }

            #endregion
            if (null == tgRemit) return;
            if (null == tgPayee) return;
            if (null == tgOther) return;
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
            tg.PayeeOpenBankName = tgPayee.PayeeOpenBankName;
            tg.DealNoteF = tgOther.DealNoteF;
            tg.DealNoteS = tgOther.DealNoteS;
            #endregion

            double tamount = 0d;
            if (!string.IsNullOrEmpty(tg.AmountF)) tamount += double.Parse(tg.AmountF);
            if (!string.IsNullOrEmpty(tg.AmountS)) tamount += double.Parse(tg.AmountS);
            if (double.Parse(tg.RemitAmount) < tamount)
            {
                MessageBoxPrime.Show(string.Format("金额1和金额2之和不能大于汇款金额"), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowindex = int.MaxValue;
            rowindex = rowIndexPanel_CountryBar.RowIndex;

            CommandCenter.ResolveTransferGlobal(command, tg, AppliableFunctionType.TransferOverCountry4Bar, rowindex);

            //保存付款人信息
            {
                if (!string.IsNullOrEmpty(tg.PayFeeAccount))
                {
                    PayerInfo payer = new PayerInfo();
                    payer.Account = tg.PayFeeAccount;
                    payer.CashType = tg.PaymentCashType;
                    if ((int)AppliableFunctionType.TransferOverCountry4Bar > 0)
                        payer.ServiceList = AppliableFunctionType.TransferOverCountry4Bar;
                    else if ((int)AppliableFunctionType.TransferOverCountry4Bar < 0)
                        payer.ServiceListBar = (AppliableFunctionType)Math.Abs((int)AppliableFunctionType.TransferOverCountry4Bar);
                    payer.CashType = tg.PaymentCashType;
                    CommandCenter.ResolvePayer(OperatorCommandType.Submit, payer, AppliableFunctionType.TransferOverCountry4Bar, int.MaxValue);
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
                payee.AccountType = (AppliableFunctionType)(Math.Abs((int)AppliableFunctionType.TransferOverCountry4Bar)) == AppliableFunctionType.TransferOverCountry
                                    ? OverCountryPayeeAccountType.ForeignAccount
                                    : tgPayee.PayeeOpenBankType == AccountBankType.BocAccount ? OverCountryPayeeAccountType.BocAccount : OverCountryPayeeAccountType.OtherAccount;

                CommandCenter.ResolvePayee4TransferGlobal(OperatorCommandType.Submit, payee, AppliableFunctionType.TransferOverCountry4Bar, int.MaxValue);
            }

            if (saveNotice)
                CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = tgOther.RemitNote }, AppliableFunctionType.TransferOverCountry4Bar);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.TransferOverCountry4Bar, rowIndexPanel_CountryBar.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveTransferGlobal(command, null, AppliableFunctionType.TransferOverCountry4Bar, -1);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.transferGlobalItemsPanel_CountryBar.HasData;
                if (flag) this.transferGlobalItemsPanel_CountryBar.SaveData(true);
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
            if (!transferGlobalItemsPanel_CountryBar.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.TransferOverCountry4Bar, true);
        }
        /// <summary>
        /// 打印
        /// </summary>
        private void Print()
        {
            CommandCenter.ResolveTransferGlobal(OperatorCommandType.Print, AppliableFunctionType.TransferOverCountry4Bar);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.TransferOverCountry4Bar, true);
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
