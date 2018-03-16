using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.Utilities;
using CommonClient.ConvertHelper;

namespace CommonClient.Entities
{
    /// <summary>
    /// 国际结算
    /// </summary>
    public class TransferGlobal: EntityBase
    {
        /// <summary>
        /// 行号
        /// 供匹配错误文件使用
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 错误原因
        /// 供匹配错误文件使用
        /// </summary>
        public string ErrorReason { get; set; }

        /// <summary>
        /// 指定汇款日期
        /// </summary>
        public string PayDate { get; set; }

        /// <summary>
        /// 汇款方式
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// 发电等级
        /// </summary>
        public TransferChanelType SendPriority { get; set; }

        /// <summary>
        /// 发电等级
        /// </summary>
        public string SendPriorityString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<TransferChanelType>.GetEnumDescription(SendPriority); }
                catch { SendPriority = TransferChanelType.Normal; }
                return result;
            }
        }

        /// <summary>
        /// 汇款币种
        /// </summary>
        public CashType PaymentCashType { get; set; }

        /// <summary>
        /// 汇款币种
        /// </summary>
        public string PaymentCashTypeString
        {
            get
            {
                string result = string.Empty;
                result = EnumNameHelper<CashType>.GetEnumDescription(PaymentCashType);
                return result;
            }
        }

        /// <summary>
        /// 汇款金额
        /// </summary>
        public string RemitAmount { get; set; }

        public string RemitAmountString
        {
            get
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(RemitAmount))
                    str = DataConvertHelper.FormatCash(RemitAmount, PaymentCashType == CashType.JPY);
                return str;
            }
        }

        /// <summary>
        /// 现汇账户
        /// </summary>
        public string SpotAccount { get; set; }

        /// <summary>
        /// 现汇金额
        /// </summary>
        public string SpotAmount { get; set; }

        public string SpotAmountString
        {
            get
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(SpotAmount))
                    str = DataConvertHelper.FormatCash(SpotAmount, PaymentCashType == CashType.JPY);
                return str;
            }
        }

        /// <summary>
        /// 购汇账户
        /// </summary>
        public string PurchaseAccount { get; set; }

        /// <summary>
        /// 购汇金额
        /// </summary>
        public string PurchaseAmount { get; set; }

        public string PurchaseAmountString
        {
            get
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(PurchaseAmount))
                    str = DataConvertHelper.FormatCash(PurchaseAmount, PaymentCashType == CashType.JPY);
                return str;
            }
        }

        /// <summary>
        /// 其他账户
        /// </summary>
        public string OtherAccount { get; set; }

        /// <summary>
        /// 其他金额
        /// </summary>
        public string OtherAmount { get; set; }

        public string OtherAmountString
        {
            get
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(OtherAmount))
                    str = DataConvertHelper.FormatCash(OtherAmount.ToString(), PaymentCashType == CashType.JPY);
                return str;
            }
        }

        /// <summary>
        /// 付费账户
        /// </summary>
        public string PayFeeAccount { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OrgCode { get; set; }

        /// <summary>
        /// 汇款人名称
        /// </summary>
        public string RemitName { get; set; }

        /// <summary>
        /// 汇款人地址
        /// </summary>
        public string RemitAddress { get; set; }

        /// <summary>
        /// 客户业务编号
        /// </summary>
        public string CustomerRef { get; set; }

        /// <summary>
        /// 收款人账号
        /// </summary>
        public string PayeeAccount { get; set; }

        /// <summary>
        /// 收款人名称
        /// </summary>
        public string PayeeName { get; set; }

        /// <summary>
        /// 收款人地址
        /// </summary>
        public string PayeeAddress { get; set; }

        /// <summary>
        /// 收款人常驻国家代码
        /// </summary>
        public string PayeeCodeofCountry { get; set; }

        /// <summary>
        /// 收款人常驻国家名称
        /// </summary>
        public string PayeeNameofCountry { get; set; }

        /// <summary>
        /// 收款人国家（地区）名称及代码
        /// </summary>
        public string PayeeCountry
        {
            get { return PayeeNameofCountry + " " + PayeeCodeofCountry; }
        }

        /// <summary>
        /// 收款人开户行类型
        /// </summary>
        public AccountBankType PayeeOpenBankType { get; set; }

        /// <summary>
        /// 收款人开户行类型
        /// </summary>
        public string PayeeOpenBankTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<AccountBankType>.GetEnumDescription(PayeeOpenBankType); }
                catch { PayeeOpenBankType = AccountBankType.Empty; }
                return result;
            }
        }

        /// <summary>
        /// 收款人开户行名称
        /// </summary>
        public string PayeeOpenBankName { get; set; }

        /// <summary>
        /// 收款人开户行swift code
        /// </summary>
        public string PayeeOpenBankSwiftCode { get; set; }

        /// <summary>
        /// 收款人开户行地址
        /// </summary>
        public string PayeeOpenBankAddress { get; set; }

        /// <summary>
        /// 收款行之代理行名称
        /// </summary>
        public string CorrespondentBankName { get; set; }

        /// <summary>
        /// 收款行之代理行swift code
        /// </summary>
        public string CorrespondentBankSwiftCode { get; set; }

        /// <summary>
        /// 收款行之代理行地址
        /// </summary>
        public string CorrespondentBankAddress { get; set; }

        /// <summary>
        /// 收款人开户行在其代理行账号
        /// </summary>
        public string PayeeAccountInCorrespondentBank { get; set; }

        /// <summary>
        /// 汇款附言
        /// </summary>
        public string RemitNote { get; set; }

        /// <summary>
        /// 国内外费用承担
        /// </summary>
        public AssumeFeeType AssumeFeeType { get; set; }

        /// <summary>
        /// 国内外费用承担
        /// </summary>
        public string AssumeFeeTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<AssumeFeeType>.GetEnumDescription(AssumeFeeType); }
                catch { AssumeFeeType = EnumTypes.AssumeFeeType.Empty; }
                return result;
            }
        }

        /// <summary>
        /// 付款方式
        /// </summary>
        public PayFeeType PayFeeType { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public string PayFeeTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<PayFeeType>.GetEnumDescription(PayFeeType); }
                catch { PayFeeType = EnumTypes.PayFeeType.Empty; }
                return result;
            }
        }

        /// <summary>
        /// 交易编码1
        /// </summary>
        public string DealSerialNoF { get; set; }

        /// <summary>
        /// 金额1
        /// </summary>
        public string AmountF { get; set; }

        public string AmountFString
        {
            get
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(AmountF))
                    str = DataConvertHelper.FormatCash(AmountF.ToString(), PaymentCashType == CashType.JPY);
                return str;
            }
        }

        /// <summary>
        /// 交易附言1
        /// </summary>
        public string DealNoteF { get; set; }

        /// <summary>
        /// 交易编码2
        /// </summary>
        public string DealSerialNoS { get; set; }

        /// <summary>
        /// 金额2
        /// </summary>
        public string AmountS { get; set; }

        public string AmountSString
        {
            get
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(AmountS))
                    str = DataConvertHelper.FormatCash(AmountS.ToString(), PaymentCashType == CashType.JPY);
                return str;
            }
        }

        /// <summary>
        /// 交易附言2
        /// </summary>
        public string DealNoteS { get; set; }

        public bool IsPayOffLine { get; set; }

        /// <summary>
        /// 本笔款项是否为保税货物线下付款
        /// </summary>
        public string IsPayOffLineString
        {
            get
            {
                string result = string.Empty;
                result = IsPayOffLine ? "是" : "否";
                return result;
            }
        }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContactNo { get; set; }

        /// <summary>
        /// 发票号码
        /// </summary>
        public string BillSerialNo { get; set; }

        /// <summary>
        /// 外汇局批件号/备案表号/业务编号
        /// </summary>
        public string BatchNoOrTNoOrSerialNo { get; set; }

        /// <summary>
        /// 申请人名称
        /// </summary>
        public string ProposerName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }

        private PaymentPropertyType m_PaymentPropertyType;
        /// <summary>
        /// 付汇性质
        /// </summary>
        public PaymentPropertyType PaymentPropertyType
        {
            get { return m_PaymentPropertyType; }
            set { m_PaymentPropertyType = value; }
        }
        /// <summary>
        /// 付汇性质
        /// </summary>
        public string PaymentPropertyTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<PaymentPropertyType>.GetEnumDescription(m_PaymentPropertyType); }
                catch { m_PaymentPropertyType = EnumTypes.PaymentPropertyType.Empty; }
                return result;
            }
        }

        #region 403Bar

        /// <summary>
        /// 业务类型
        /// </summary>
        public BarBusinessType BarBusinessType { get; set; }

        public string BarBusinessTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (BarBusinessType != EnumTypes.BarBusinessType.Empty)
                        str = EnumNameHelper<BarBusinessType>.GetEnumDescription(BarBusinessType);
                }
                catch { }
                return str;
            }
        }

        /// <summary>
        /// 申报标识
        /// </summary>
        public BarApplyFlagType BarApplyFlagType { get; set; }

        public string BarApplyFlagTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (BarApplyFlagType != EnumTypes.BarApplyFlagType.Empty)
                        str = EnumNameHelper<BarApplyFlagType>.GetEnumDescription(BarApplyFlagType);
                }
                catch { }
                return str;
            }
        }

        /// <summary>
        /// 省份
        /// </summary>
        public ChinaProvinceType Province;
        /// <summary>
        /// 省份
        /// </summary>
        public string ProvinceString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (Province != ChinaProvinceType.B0)
                        str = EnumNameHelper<ChinaProvinceType>.GetEnumDescription(Province);
                }
                catch { }
                return str;
            }
        }
        /// <summary>
        /// 证件类型
        /// </summary>
        public AgentExpressCertifyPaperType CertifyPaperType;
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertifyPaperTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if ((int)CertifyPaperType > 0)
                        str = EnumNameHelper<AgentExpressCertifyPaperType>.GetEnumDescription(CertifyPaperType);
                }
                catch { }
                return str;
            }
        }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertifyPaperNo { get; set; }

        private AgentExpressFunctionType m_agentFunctionType_Express = AgentExpressFunctionType.Empty;
        /// <summary>
        /// 快捷用途
        /// </summary>
        public AgentExpressFunctionType AgentFunctionType_Express
        {
            get { return m_agentFunctionType_Express; }
            set { m_agentFunctionType_Express = value; }
        }
        public string AgentFunctionType_ExpressString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (m_agentFunctionType_Express != AgentExpressFunctionType.Empty)
                        str = EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(m_agentFunctionType_Express);
                }
                catch { }
                return str;
            }
        }

        public TransferGlobal()
        {
            DealNoteS = string.Empty;
            AmountS = string.Empty;
            DealSerialNoS = string.Empty;
            DealNoteF = string.Empty;
            AmountF = string.Empty;
            DealSerialNoF = string.Empty;
            PaymentCashType = CashType.Empty;
        }

        /// <summary>
        /// 柜台C1业务--附言
        /// </summary>
        public string Bar_Addition { get; set; }

        #endregion
    }
}
