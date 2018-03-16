using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.Entities;

namespace CommonClient.TemplateHelper
{
    public class TemplateHeaderAndFooterHelper
    {
        #region 单例
        private static object lock_instance = new object();
        private static TemplateHeaderAndFooterHelper m_instance;

        /// <summary>
        /// 单一实例
        /// </summary>
        public static TemplateHeaderAndFooterHelper Instance
        {
            get
            {
                if (null == m_instance)
                {
                    lock (lock_instance)
                    {
                        if (null == m_instance)
                        {
                            lock (lock_instance)
                            {
                                m_instance = new TemplateHeaderAndFooterHelper();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        /// <summary>
        /// 获取模板类型对应的模板头信息
        /// </summary>
        /// <param name="tempType">模板的类型</param>
        /// <returns></returns>
        public string CreateTemplateHeaderInfo(AppliableFunctionType tempType, IList<string> list, string separator)
        {
            string headerInfo = string.Empty;
            switch (tempType)
            {
                case AppliableFunctionType.TransferWithIndiv:
                case AppliableFunctionType.TransferWithCorp:
                case AppliableFunctionType.TransferOverBankIn:
                case AppliableFunctionType.TransferOverBankOut:
                case AppliableFunctionType.ElecTicketPool:
                    headerInfo = string.Format("OBSS{0}2{1}", separator, separator); break;
                case AppliableFunctionType.AgentNormalIn:
                    headerInfo = "PAYFEESTART"; break;
                case AppliableFunctionType.AgentNormalOut:
                case AppliableFunctionType.AgentExpressIn:
                case AppliableFunctionType.AgentExpressOut:
                    headerInfo = "PAYOFFSTART"; break;
                case AppliableFunctionType.ElecTicketRemit:
                    headerInfo = string.Format("DRAFTBOOK{0}{1}{2}{3}{4}", new string[] { separator, list[0], separator, list[1], separator }); list.Clear();break;
                case AppliableFunctionType.ElecTicketBackNote:
                    headerInfo = string.Format("DRAFTTRANSFER{0}{1}{2}", new string[] { separator, list[0], separator });  list.Clear();break;
                case AppliableFunctionType.ElecTicketPayMoney:
                    headerInfo = string.Format("RDSAPPLY{0}{1}{2}", new string[] { separator, list[0], separator });  list.Clear();break;
                case AppliableFunctionType.ElecTicketTipExchange:
                    headerInfo = string.Format("DRAFTREMIND{0}{1}{2}", new string[] { separator, list[0], separator });  list.Clear();break;
                case AppliableFunctionType.TransferForeignMoney:
                case AppliableFunctionType.TransferOverCountry:
                    headerInfo = string.Format("REMIT{0}2{1}", separator, separator); break;
                case AppliableFunctionType.InitiativeAllot:
                    headerInfo = "BATCHSTART"; break;
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                case AppliableFunctionType.PurchaserOrder:
                case AppliableFunctionType.SellerOrder:
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                case AppliableFunctionType.BillofDebtReceivableSeller:
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    headerInfo = string.Format("TABLE\r\n0,1\r\n\"EXCEL\"\r\nVECTORS\r\n0,{0}\r\n\"\"\r\nTUPLES\r\n0,{1}\r\n\"\"\r\nDATA\r\n0,0\r\n\"\"\r\n-1,0", new string[] { list[0], list[1] });
                    list.Clear();
                    break;
                case AppliableFunctionType.UnitivePaymentRMB:
                    headerInfo = string.Format("GCMSMP{0}{1}{2}{3}{4}", separator, list[0], separator, list[1], separator); list.Clear(); break;
                case AppliableFunctionType.UnitivePaymentFC:
                    OverCountryPayeeAccountType at = (OverCountryPayeeAccountType)int.Parse(list[0]);
                    if (at == OverCountryPayeeAccountType.BocAccount) headerInfo = "GCMSINBOC";
                    else if (at == OverCountryPayeeAccountType.OtherAccount) headerInfo = "GCMSOUTBOC";
                    else if (at == OverCountryPayeeAccountType.ForeignAccount) headerInfo = "GCMSOVERSEA";
                    headerInfo += string.Format("{0}{1}{2}", separator, list[1], separator);
                    list.Clear(); break;
                case AppliableFunctionType.TransferOverCountry4Bar:
                    foreach (var item in list)
                        headerInfo += item;
                    list.Clear();
                    break;
                case AppliableFunctionType.VirtualAccountTransfer:
                    headerInfo = "ITESTART|1|432|"; break;
                default: break;
            }

            foreach (var item in list)
            {
                headerInfo += item + separator;
            }

            return headerInfo;
        }

        /// <summary>
        /// 获取模板类型对应的模板头信息
        /// </summary>
        /// <param name="tempType">模板的类型</param>
        /// <returns></returns>
        public string CreateTemplateHeaderInfo(FunctionInSettingType tempType, int count, string separator)
        {
            string headerInfo = string.Empty;
            switch (tempType)
            {
                case FunctionInSettingType.PayeeMg:
                case FunctionInSettingType.OverCountryPayeeMg:
                    headerInfo = string.Format("PAYEE{0}{1}{2}", separator, count, separator); break;
                case FunctionInSettingType.ElecTicketRelateAccountMg:
                    headerInfo = string.Format("DRAFTACTOR{0}{1}{2}", separator, count, separator); break;
                case FunctionInSettingType.AgentExpressInPayerMg:
                    headerInfo = string.Format("PAYER{0}{1}{2}", separator, count, separator); break;
                default: break;
            }
            return headerInfo;
        }

        /// <summary>
        /// 获取模板头格式
        /// </summary>
        /// <param name="tempType">模板类型</param>
        /// <returns></returns>
        public string GetTemplateHeaderStarts(AppliableFunctionType tempType)
        { return GetTemplateHeaderStarts(tempType, OverCountryPayeeAccountType.Empty); }

        /// <summary>
        /// 获取模板头格式
        /// </summary>
        /// <param name="tempType">模板类型</param>
        /// <returns></returns>
        public string GetTemplateHeaderStarts(AppliableFunctionType tempType, OverCountryPayeeAccountType at)
        {
            string headerInfo = string.Empty;
            switch (tempType)
            {
                case AppliableFunctionType.TransferWithIndiv:
                case AppliableFunctionType.TransferWithCorp:
                case AppliableFunctionType.TransferOverBankIn:
                case AppliableFunctionType.TransferOverBankOut:
                case AppliableFunctionType.ElecTicketPool:
                    headerInfo = "OBSS|2|"; break;
                case AppliableFunctionType.AgentNormalIn:
                    headerInfo = "PAYFEESTART"; break;
                case AppliableFunctionType.AgentNormalOut:
                case AppliableFunctionType.AgentExpressIn:
                case AppliableFunctionType.AgentExpressOut:
                    headerInfo = "PAYOFFSTART"; break;
                case AppliableFunctionType.ElecTicketRemit:
                    headerInfo = "DRAFTBOOK"; break;
                case AppliableFunctionType.ElecTicketBackNote:
                    headerInfo = "DRAFTTRANSFER"; break;
                case AppliableFunctionType.ElecTicketPayMoney:
                    headerInfo = "RDSAPPLY"; break;
                case AppliableFunctionType.ElecTicketTipExchange:
                    headerInfo = "DRAFTREMIND"; break;
                case AppliableFunctionType.TransferForeignMoney:
                case AppliableFunctionType.TransferOverCountry:
                    headerInfo = "REMIT|2|"; break;
                case AppliableFunctionType.InitiativeAllot:
                    headerInfo = "BATCHSTART"; break;
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                case AppliableFunctionType.PurchaserOrder:
                case AppliableFunctionType.SellerOrder:
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                case AppliableFunctionType.BillofDebtReceivableSeller:
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    headerInfo = "ITESTART|1|432|"; break;
                case AppliableFunctionType.UnitivePaymentRMB:
                    headerInfo = "GCMSMP"; break;
                case AppliableFunctionType.UnitivePaymentFC:
                    if (at == OverCountryPayeeAccountType.BocAccount) headerInfo = "GCMSINBOC";
                    else if (at == OverCountryPayeeAccountType.OtherAccount) headerInfo = "GCMSOUTBOC";
                    else if (at == OverCountryPayeeAccountType.ForeignAccount) headerInfo = "GCMSOVERSEA";
                    break;
                default: break;
            }

            return headerInfo;
        }

        /// <summary>
        /// 获取DIF格式文件的列头信息
        /// </summary>
        /// <param name="tempType"></param>
        /// <returns></returns>
        public string GetTemplateTableColumnsHeader(AppliableFunctionType tempType)
        {
            StringBuilder sb = new StringBuilder();
            switch (tempType)
            {
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                    #region
                    sb.Append("BOT" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"合同/订单号(Contract/order number)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"订单日期(Order date)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"合同/订单币别(Contract/order currency)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"合同/订单金额(Contract/order amount)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"发货日期(Delivery date)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"结算方式(Settlement method)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"税务发票号(Tax invoice number)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"收货单号(Receipt number)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"风险承担函号(Risk-taking letter number)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"货物描述(Goods description)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"融资申请金额(Financing application amount)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"申请融资天数(Financing days applied)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"协议文本编号(Agreement No.)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"利率浮动方式(Interest floating method)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"利率浮动比例(Interest floating percentage)\"" + Environment.NewLine);
                    sb.Append("-1,0"); break;
                    #endregion
                case AppliableFunctionType.PurchaserOrder:
                    #region
                    sb.Append("BOT" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"订单编号(Order number)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"订单币别(Order currency)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"订单金额(Order amount)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"卖方ERP代码(Seller's ERP code)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"卖方银行客户号(Seller's bank customer number)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"预计付款日期(Estimated payment date)\"" + Environment.NewLine);
                    sb.Append("-1,0"); break;
                    #endregion
                case AppliableFunctionType.SellerOrder:
                    #region
                    sb.Append("BOT" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"订单编号(Order number)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"订单币别(Order currency)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"订单金额(Order amount)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"买方客户名称(Buyer customer name)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"预计买方付款日期(Estimated buyer's payment date)\"" + Environment.NewLine);
                    sb.Append("-1,0"); break;
                    #endregion
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                    #region
                    sb.Append("BOT" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"订单编号(Order number)\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"本次订单支付金额(Current order payment amount)\"" + Environment.NewLine);
                    sb.Append("-1,0"); break;
                    #endregion
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                    #region
                    sb.Append("BOT" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"发票号\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"合同号\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"卖方客户号\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"卖方客户名称\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"发票币别\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"发票金额\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"发票日期\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"起算日\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"到期日\"" + Environment.NewLine);
                    sb.Append("-1,0"); break;
                    #endregion
                case AppliableFunctionType.BillofDebtReceivableSeller:
                    #region
                    sb.Append("BOT" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"发票号\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"合同号\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"买方客户号\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"买方客户名称\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"发票币别\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"发票金额\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"发票日期\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"起算日\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"到期日\"" + Environment.NewLine);
                    sb.Append("-1,0"); break;
                    #endregion
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    #region
                    sb.Append("BOT" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"发票号\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"买/卖方客户号\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"买/卖方客户名称\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"发票币别\"" + Environment.NewLine);
                    sb.Append("1,0" + Environment.NewLine);
                    sb.Append("\"本次收/付款金额\"" + Environment.NewLine);
                    sb.Append("-1,0"); break;
                    #endregion
                default: break;
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取DAT格式文件头数据
        /// </summary>
        /// <param name="aft"></param>
        /// <param name="tg"></param>
        /// <param name="separactorChar"></param>
        /// <param name="amount"></param>
        /// <param name="maxcount"></param>
        /// <returns></returns>
        public string CreateFileHeaderInfoBar(AppliableFunctionType aft, TransferGlobal tg, string separactorChar, double amount, int maxcount)
        {
            StringBuilder header = new StringBuilder();

            if (aft == AppliableFunctionType.TransferOverCountry4Bar)
            {
                #region
                header.Append("C6");
                header.Append(SystemSettings.Instance.CustomerInfo.Code);
                header.Append((!string.IsNullOrEmpty(tg.PayFeeAccount) ? tg.PayFeeAccount : string.Empty).PadRight(25, ' '));
                header.Append((double.Parse(amount.ToString("0.00"))  * 100).ToString().PadLeft(16, ' '));
                header.Append(maxcount.ToString().PadRight(12, ' '));
                header.Append("NF");
                header.Append((tg.PaymentCashType != CashType.Empty ? tg.PaymentCashType.ToString() : string.Empty).PadLeft(3, '0'));
                header.Append("0000000001");
                header.Append(string.Empty.PadLeft(50, ' '));
                header.Append(string.Empty.PadLeft(7, ' '));
                header.Append("0");
                header.Append(string.Empty.PadLeft(16, ' '));
                header.Append((tg.SpotAccount == tg.PayFeeAccount ? 1 : 2).ToString().PadRight(25, ' '));
                header.Append(string.Empty.PadLeft(16, ' '));
                header.Append((!string.IsNullOrEmpty(tg.PayFeeAccount) ? tg.PayFeeAccount : string.Empty).PadRight(32, ' '));
                header.Append((tg.PayFeeAccount == tg.SpotAccount ? tg.PaymentCashType.ToString() : CashType.CNY.ToString()).PadRight(8, ' '));
                header.Append(string.Empty.PadLeft(32 + 8 + 32 + 8 + 32 + 8 + 24, ' '));
                header.Append(separactorChar);
                #endregion
            }
            else if (aft == AppliableFunctionType.TransferForeignMoney4Bar)
            {
                if (tg.PayeeOpenBankType == AccountBankType.BocAccount)
                {
                    #region
                    header.Append("C1");
                    header.Append(SystemSettings.Instance.CustomerInfo.Code);
                    header.Append((!string.IsNullOrEmpty(tg.SpotAccount) ? tg.SpotAccount.ToUpper() : string.Empty).PadLeft(25, ' '));
                    header.Append((double.Parse(amount.ToString("0.00"))  * 100).ToString().PadLeft(16, ' '));
                    header.Append(maxcount.ToString().PadRight(12, ' '));
                    header.Append((tg.AgentFunctionType_Express != AgentExpressFunctionType.Empty ? tg.AgentFunctionType_Express.ToString() : string.Empty).PadRight(2, ' '));
                    header.Append((tg.PaymentCashType == CashType.Empty ? string.Empty : tg.PaymentCashType.ToString()).PadRight(3, ' '));//币种
                    header.Append("0000000001");
                    header.Append(string.Empty.PadRight(50, ' '));//网银备注域
                    header.Append(string.Empty.PadLeft(7, ' '));//柜员号
                    header.Append(string.Empty.PadLeft(1, ' '));
                    header.Append(string.Empty.PadLeft(16, ' '));
                    header.Append(string.Empty.PadLeft(25, ' '));
                    header.Append(string.Empty.PadLeft(16, ' '));
                    header.Append(string.Empty.PadLeft(32 + 8 + 32 + 8 + 32 + 8 + 32 + 8 + 24, ' '));
                    header.Append(separactorChar);
                    #endregion
                }
                else
                {
                    #region
                    header.Append("C5");
                    header.Append(SystemSettings.Instance.CustomerInfo.Code);
                    header.Append((!string.IsNullOrEmpty(tg.PayFeeAccount) ? tg.PayFeeAccount : string.Empty).PadRight(25, ' '));
                    header.Append((double.Parse(amount.ToString("0.00")) * 100).ToString().PadLeft(16, ' '));
                    header.Append(maxcount.ToString().PadRight(12, ' '));
                    header.Append("NF");
                    header.Append((tg.PaymentCashType != CashType.Empty ? tg.PaymentCashType.ToString() : string.Empty).PadLeft(3, ' '));
                    header.Append("0000000001");
                    header.Append(string.Empty.PadLeft(50 + 7 + 58 + 32 + 8 + 32 + 8 + 32 + 8 + 32 + 8 + 24, ' '));
                    header.Append(separactorChar);
                    #endregion
                }
            }
            return header.ToString();
        }

        /// <summary>
        /// 获取DAT格式文件头数据
        /// </summary>
        /// <param name="aft"></param>
        /// <param name="bh"></param>
        /// <param name="separactorChar"></param>
        /// <param name="amount"></param>
        /// <param name="maxcount"></param>
        /// <returns></returns>
        public string CreateFileHeaderInfoBar(AppliableFunctionType aft, BatchHeader bh, string separactorChar, double amount, int maxcount)
        {
            StringBuilder header = new StringBuilder();
            if (aft == AppliableFunctionType.AgentExpressOut4Bar)
            {
                if (bh.BankType == AgentTransferBankType.Boc || bh.BankType == AgentTransferBankType.Other)
                {
                    if (bh.BankType == AgentTransferBankType.Boc)
                        header.Append("C1");
                    else
                        header.Append("C2");
                    header.Append(SystemSettings.Instance.CustomerInfo.Code);
                    header.Append(bh.Payer.Account.PadLeft(25, ' '));
                    header.Append((double.Parse(amount.ToString("0.00")) * 100).ToString().PadLeft(16, ' '));
                    header.Append(maxcount.ToString().PadRight(12, ' '));
                    header.Append((bh.AgentFunctionType_Express != AgentExpressFunctionType.Empty ? bh.AgentFunctionType_Express.ToString() : string.Empty).PadRight(2, ' '));//用途
                    header.Append(CashType.CNY.ToString().PadRight(3, ' '));//币种
                    header.Append("0000000001");
                    header.Append(string.Empty.PadRight(50, ' '));//网银备注域
                    header.Append(string.Empty.PadLeft(7, ' '));//柜员号
                    header.Append(string.Empty.PadLeft(1, ' '));
                    header.Append(string.Empty.PadLeft(16, ' '));
                    header.Append(string.Empty.PadLeft(25, ' '));
                    header.Append(string.Empty.PadLeft(16, ' '));
                    header.Append(string.Empty.PadLeft(32 + 8 + 32 + 8 + 32 + 8 + 32 + 8 + 24, ' '));
                    header.Append(separactorChar);
                }
            }
            return header.ToString();
        }

        /// <summary>
        /// 获取模板头格式
        /// </summary>
        /// <param name="tempType">模板类型</param>
        /// <returns></returns>
        public string GetTemplateHeaderStarts(FunctionInSettingType tempType)
        {
            string headerInfo = string.Empty;
            switch (tempType)
            {
                case FunctionInSettingType.PayeeMg:
                case FunctionInSettingType.OverCountryPayeeMg:
                    headerInfo = "PAYEE"; break;
                case FunctionInSettingType.ElecTicketRelateAccountMg:
                    headerInfo = "DRAFTACTOR"; break;
                case FunctionInSettingType.AgentExpressInPayerMg:
                    headerInfo = "PAYER"; break;
                default: break;
            }

            return headerInfo;
        }

        /// <summary>
        /// 获取模板类型对应的模板尾信息
        /// </summary>
        /// <param name="tempType">模板类型</param>
        /// <returns></returns>
        public string GetTemplateFooterInfo(AppliableFunctionType tempType)
        { return GetTemplateFooterInfo(tempType, OverCountryPayeeAccountType.Empty); }

        /// <summary>
        /// 获取模板类型对应的模板尾信息
        /// </summary>
        /// <param name="tempType">模板类型</param>
        /// <returns></returns>
        public string GetTemplateFooterInfo(AppliableFunctionType tempType, OverCountryPayeeAccountType at)
        {
            string footerInfo = string.Empty;
            switch (tempType)
            {
                case AppliableFunctionType.TransferWithIndiv:
                case AppliableFunctionType.TransferWithCorp:
                case AppliableFunctionType.TransferOverBankIn:
                case AppliableFunctionType.TransferOverBankOut:
                case AppliableFunctionType.ElecTicketPool:
                    footerInfo = "OBSSEND"; break;
                case AppliableFunctionType.AgentNormalIn:
                    footerInfo = "PAYFEEEND"; break;
                case AppliableFunctionType.AgentNormalOut:
                case AppliableFunctionType.AgentExpressIn:
                case AppliableFunctionType.AgentExpressOut:
                    footerInfo = "PAYOFFEND"; break;
                case AppliableFunctionType.ElecTicketRemit:
                    footerInfo = "DRAFTBOOKEND"; break;
                case AppliableFunctionType.ElecTicketBackNote:
                    footerInfo = "DRAFTTRANSFEREND"; break;
                case AppliableFunctionType.ElecTicketPayMoney:
                    footerInfo = "RDSAPPLYEND"; break;
                case AppliableFunctionType.ElecTicketTipExchange:
                    footerInfo = "DRAFTREMINDEND"; break;
                case AppliableFunctionType.TransferOverCountry:
                case AppliableFunctionType.TransferForeignMoney:
                    footerInfo = "REMITEND"; break;
                case AppliableFunctionType.InitiativeAllot:
                    footerInfo = "BATCHEND"; break;
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                case AppliableFunctionType.PurchaserOrder:
                case AppliableFunctionType.SellerOrder:
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                case AppliableFunctionType.BillofDebtReceivableSeller:
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    footerInfo = "EOD"; break;
                case AppliableFunctionType.UnitivePaymentRMB:
                    footerInfo = "GCMSMPEND"; break;
                case AppliableFunctionType.UnitivePaymentFC:
                    if (at == OverCountryPayeeAccountType.BocAccount) footerInfo = "GCMSINBOCEND";
                    else if (at == OverCountryPayeeAccountType.OtherAccount) footerInfo = "GCMSOUTBOCEND";
                    else if (at == OverCountryPayeeAccountType.ForeignAccount) footerInfo = "GCMSOVERSEAEND";
                    break;
                case AppliableFunctionType.VirtualAccountTransfer:
                    footerInfo = "ITEEND"; break;
                default: break;
            }
            return footerInfo;
        }

        /// <summary>
        /// 获取模板类型对应的模板尾信息
        /// </summary>
        /// <param name="tempType">模板类型</param>
        /// <returns></returns>
        public string GetTemplateFooterInfo(FunctionInSettingType tempType)
        {
            string headerInfo = string.Empty;
            switch (tempType)
            {
                case FunctionInSettingType.PayeeMg:
                case FunctionInSettingType.OverCountryPayeeMg:
                    headerInfo = "PAYEEEND"; break;
                case FunctionInSettingType.ElecTicketRelateAccountMg:
                    headerInfo = "DRAFTACTOREND"; break;
                case FunctionInSettingType.AgentExpressInPayerMg:
                    headerInfo = "PAYEREND"; break;
                default: break;
            }
            return headerInfo;
        }
    }
}
