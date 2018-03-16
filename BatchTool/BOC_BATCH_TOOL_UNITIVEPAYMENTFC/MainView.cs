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
using CommonClient.SysCoach;
using System.IO;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.TemplateHelper;
using CommonClient.Controls;
namespace BOC_BATCH_TOOL_UNITIVEPAYMENTFC
{
    [DesignTimeVisibleAttribute(false)]
    [ModuleWorkSpaceInfo("BOC_BATCH_TOOL_UNITIVEPAYMENTFC", false, 28, "外币统一支付", AppliableFunctionType.UnitivePaymentFC)]
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
                if (e.AppType != AppliableFunctionType.UnitivePaymentFC) return;
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
            if (!unitivePaymentFCItemsPanel1.SaveData(false)) return;
            if (OperatorCommandType.New == command)
            {
                CommandCenter.ResolveUnitivePaymentFC(command, AppliableFunctionType.UnitivePaymentFC);
                CommandCenter.ResolveUnitivePaymentFC(OperatorCommandType.Reset, AppliableFunctionType.UnitivePaymentFC);
            }
            if (OperatorCommandType.Open == command)
                LoadFileHelper.LoadFiles(command, AppliableFunctionType.UnitivePaymentFC, true);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        private void SubmitData(OperatorCommandType command)
        {
            UnitivePaymentForeignMoney UnitiveFor = null;
            if (unitivePaymentFCPayerSelector1.CheckData())
            {
                unitivePaymentFCPayerSelector1.GetItem();
                UnitiveFor = unitivePaymentFCPayerSelector1.CurrentUnitivePFC;
            }

            UnitivePaymentForeignMoney upPayee = null;
            if (transferGlobalPayeeSelector1.CheckData())
            {
                transferGlobalPayeeSelector1.GetItem();
                upPayee = transferGlobalPayeeSelector1._UnitivePaymentForeignMoney;
            }

            UnitivePaymentForeignMoney upRemit = null;
            if (unitivePaymentFCRemitSelector1.CheckData())
            {
                unitivePaymentFCRemitSelector1.GetItem();
                upRemit = unitivePaymentFCRemitSelector1.CurrentUnitivePFC;
            }

            UnitivePaymentForeignMoney upOther = null;
            if (transferGlobalOtherSelector1.CheckData())
            {
                transferGlobalOtherSelector1.GetItem();
                upOther = transferGlobalOtherSelector1._UnitivePaymentForeignMoney;
            }
            if (null == UnitiveFor) return;
            if (null == upPayee) return;
            if (null == upRemit) return;
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
            UPItem.NominalPayerAddress = upRemit.NominalPayerAddress;
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
            UPItem.AssumeFeeType = upOther.AssumeFeeType;
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
                MessageBoxPrime.Show(string.Format("金额1和金额2之和不能大于汇款金额"), CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            CommandCenter.ResolveUnitivePaymentFC(command, UPItem, AppliableFunctionType.UnitivePaymentFC, rowIndexPanel_FC.RowIndex, UPItem.PayeeAccountType);

            CommandCenter.ResolvePayer(OperatorCommandType.Submit, new PayerInfo { Account = UPItem.PayerAccount, Name = UPItem.PayerName, CashType = UPItem.CashType, ServiceList = AppliableFunctionType.UnitivePaymentFC }, AppliableFunctionType.UnitivePaymentFC, int.MaxValue);
            CommandCenter.ResolvePayee4TransferGlobal(OperatorCommandType.Submit, new PayeeInfo4TransferGlobal { Account = UPItem.PayeeAccount, Name = UPItem.PayeeName, Address = UPItem.Address, AccountType = UPItem.PayeeAccountType, OpenBankType = UPItem.PayeeOpenBankType, OpenBankName = UPItem.PayeeOpenBankName, OpenBankAddress = UPItem.OpenBankAddress, CorrespondentBankName = UPItem.CorrespondentBankName, CorrespondentBankAddress = UPItem.CorrespondentBankAddress, CodeofCountry = UPItem.CodeofCountry, NameofCountry = UPItem.NameofCountry }, AppliableFunctionType.UnitivePaymentFC, rowIndexPanel_FC.RowIndex);
            if (transferGlobalOtherSelector1.SaveRemitNote)
                CommandCenter.ResolveNotice(OperatorCommandType.Submit, new NoticeInfo { Content = UPItem.Addtion }, AppliableFunctionType.UnitivePaymentFC);

            unitivePaymentFCPayerSelector1.CurrentUnitivePFC = null;
            transferGlobalPayeeSelector1._UnitivePaymentForeignMoney = null;
            unitivePaymentFCRemitSelector1.CurrentUnitivePFC = null;
            transferGlobalOtherSelector1._UnitivePaymentForeignMoney = null;

        }
        /// <summary>
        /// 编辑
        /// </summary>
        private void EditOperatorRequest()
        {
            CommandCenter.ResolveEditOperator(OperatorCommandType.EditOperatorRequest, AppliableFunctionType.UnitivePaymentFC, rowIndexPanel_FC.RowIndex);
        }
        /// <summary>
        /// 删除 重置
        /// </summary>
        /// <param name="command"></param>
        private void DeleteOrReloadData(OperatorCommandType command)
        {
            CommandCenter.ResolveUnitivePaymentFC(command, null, AppliableFunctionType.UnitivePaymentFC, -1, OverCountryPayeeAccountType.Empty);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private void SaveTXTFile()
        {
            bool flag = false;
            try
            {
                flag = this.unitivePaymentFCItemsPanel1.HasData;
                if (flag) this.unitivePaymentFCItemsPanel1.SaveData(true);
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
            if (!unitivePaymentFCItemsPanel1.HasData)
            { MessageBoxPrime.Show(MultiLanguageConvertHelper.DesignMain_Open_SourceFile_Then_Match_ErrorFile, CommonInformations.GetFormMainTextByVersion(), MessageBoxButtonsEx.OK, MessageBoxIcon.Warning); return; }
            LoadFileHelper.LoadFiles(OperatorCommandType.ErrorData, AppliableFunctionType.UnitivePaymentFC, true);
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
            LoadFileHelper.LoadFiles(OperatorCommandType.CombineData, AppliableFunctionType.UnitivePaymentFC, true);
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
