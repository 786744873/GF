using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;
using BOC_BATCH_TOOL.ConvertHelper;

namespace BOC_BATCH_TOOL.Entities
{
    /// <summary>
    /// 国际结算
    /// </summary>
    public class TransferGlobal
    {
        private int m_RowIndex;
        /// <summary>
        /// 行号
        /// 供匹配错误文件使用
        /// </summary>
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }
        private string m_ErrorReason;
        /// <summary>
        /// 错误原因
        /// 供匹配错误文件使用
        /// </summary>
        public string ErrorReason
        {
            get { return m_ErrorReason; }
            set { m_ErrorReason = value; }
        }
        private string m_payDate;
        /// <summary>
        /// 指定汇款日期
        /// </summary>
        public string PayDate
        {
            get { return m_payDate; }
            set { m_payDate = value; }
        }
        private string m_PaymentType;
        /// <summary>
        /// 汇款方式
        /// </summary>
        public string PaymentType
        {
            get { return m_PaymentType; }
            set { m_PaymentType = value; }
        }
        private TransferChanelType m_sendPriority;
        /// <summary>
        /// 发电等级
        /// </summary>
        public TransferChanelType SendPriority
        {
            get { return m_sendPriority; }
            set { m_sendPriority = value; }
        }
        /// <summary>
        /// 发电等级
        /// </summary>
        public string SendPriorityString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<TransferChanelType>.GetEnumDescription(m_sendPriority); }
                catch { m_sendPriority = TransferChanelType.Normal; }
                return result;
            }
        }
        private CashType m_PaymentCashType = CashType.Empty;
        /// <summary>
        /// 汇款币种
        /// </summary>
        public CashType PaymentCashType
        {
            get { return m_PaymentCashType; }
            set { m_PaymentCashType = value; }
        }
        /// <summary>
        /// 汇款币种
        /// </summary>
        public string PaymentCashTypeString
        {
            get
            {
                string result = string.Empty;
                result = EnumNameHelper<CashType>.GetEnumDescription(m_PaymentCashType);
                return result;
            }
        }
        private string m_remitAmount;
        /// <summary>
        /// 汇款金额
        /// </summary>
        public string RemitAmount
        {
            get { return m_remitAmount; }
            set { m_remitAmount = value; }
        }
        public string RemitAmountString
        {
            get
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(m_remitAmount))
                    str = DataConvertHelper.Instance.FormatCash(m_remitAmount, m_PaymentCashType == CashType.JPY);
                return str;
            }
        }
        private string m_spotAccount;
        /// <summary>
        /// 现汇账户
        /// </summary>
        public string SpotAccount
        {
            get { return m_spotAccount; }
            set { m_spotAccount = value; }
        }
        private string m_spotAmount;
        /// <summary>
        /// 现汇金额
        /// </summary>
        public string SpotAmount
        {
            get { return m_spotAmount; }
            set { m_spotAmount = value; }
        }
        public string SpotAmountString
        {
            get
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(m_spotAmount))
                    str = DataConvertHelper.Instance.FormatCash(m_spotAmount, m_PaymentCashType == CashType.JPY);
                return str;
            }
        }
        private string m_purchaseAccount;
        /// <summary>
        /// 购汇账户
        /// </summary>
        public string PurchaseAccount
        {
            get { return m_purchaseAccount; }
            set { m_purchaseAccount = value; }
        }
        private string m_purchaseAmount;
        /// <summary>
        /// 购汇金额
        /// </summary>
        public string PurchaseAmount
        {
            get { return m_purchaseAmount; }
            set { m_purchaseAmount = value; }
        }
        public string PurchaseAmountString
        {
            get
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(m_purchaseAmount))
                    str = DataConvertHelper.Instance.FormatCash(m_purchaseAmount, m_PaymentCashType == CashType.JPY);
                return str;
            }
        }
        private string m_otherAccount;
        /// <summary>
        /// 其他账户
        /// </summary>
        public string OtherAccount
        {
            get { return m_otherAccount; }
            set { m_otherAccount = value; }
        }
        private string m_otherAmount;
        /// <summary>
        /// 其他金额
        /// </summary>
        public string OtherAmount
        {
            get { return m_otherAmount; }
            set { m_otherAmount = value; }
        }
        public string OtherAmountString
        {
            get
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(m_otherAmount))
                    str = DataConvertHelper.Instance.FormatCash(m_otherAmount.ToString(), m_PaymentCashType == CashType.JPY);
                return str;
            }
        }
        private string m_payFeeAccount;
        /// <summary>
        /// 付费账户
        /// </summary>
        public string PayFeeAccount
        {
            get { return m_payFeeAccount; }
            set { m_payFeeAccount = value; }
        }
        private string m_orgCode;
        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OrgCode
        {
            get { return m_orgCode; }
            set { m_orgCode = value; }
        }
        private string m_remitName;
        /// <summary>
        /// 汇款人名称
        /// </summary>
        public string RemitName
        {
            get { return m_remitName; }
            set { m_remitName = value; }
        }
        private string m_remitAddress;
        /// <summary>
        /// 汇款人地址
        /// </summary>
        public string RemitAddress
        {
            get { return m_remitAddress; }
            set { m_remitAddress = value; }
        }
        private string m_cutomerRef;
        /// <summary>
        /// 客户业务编号
        /// </summary>
        public string CustomerRef
        {
            get { return m_cutomerRef; }
            set { m_cutomerRef = value; }
        }
        private string m_payeeAccount;
        /// <summary>
        /// 收款人账号
        /// </summary>
        public string PayeeAccount
        {
            get { return m_payeeAccount; }
            set { m_payeeAccount = value; }
        }
        private string m_payeeName;
        /// <summary>
        /// 收款人名称
        /// </summary>
        public string PayeeName
        {
            get { return m_payeeName; }
            set { m_payeeName = value; }
        }
        private string m_payeeAddress;
        /// <summary>
        /// 收款人地址
        /// </summary>
        public string PayeeAddress
        {
            get { return m_payeeAddress; }
            set { m_payeeAddress = value; }
        }
        private string m_payeeCodeofCountry;
        /// <summary>
        /// 收款人常驻国家代码
        /// </summary>
        public string PayeeCodeofCountry
        {
            get { return m_payeeCodeofCountry; }
            set { m_payeeCodeofCountry = value; }
        }
        private string m_payeeNameofCountry;
        /// <summary>
        /// 收款人常驻国家名称
        /// </summary>
        public string PayeeNameofCountry
        {
            get { return m_payeeNameofCountry; }
            set { m_payeeNameofCountry = value; }
        }
        /// <summary>
        /// 收款人国家（地区）名称及代码
        /// </summary>
        public string PayeeCountry
        {
            get { return m_payeeNameofCountry + " " + m_payeeCodeofCountry; }
        }
        private AccountBankType m_PayeeOpenBankType;
        /// <summary>
        /// 收款人开户行类型
        /// </summary>
        public AccountBankType PayeeOpenBankType
        {
            get { return m_PayeeOpenBankType; }
            set { m_PayeeOpenBankType = value; }
        }
        /// <summary>
        /// 收款人开户行类型
        /// </summary>
        public string PayeeOpenBankTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<AccountBankType>.GetEnumDescription(m_PayeeOpenBankType); }
                catch { m_PayeeOpenBankType = AccountBankType.Empty; }
                return result;
            }
        }
        private string m_payeeOpenBankName;
        /// <summary>
        /// 收款人开户行名称
        /// </summary>
        public string PayeeOpenBankName
        {
            get { return m_payeeOpenBankName; }
            set { m_payeeOpenBankName = value; }
        }
        private string m_payeeOpenBankSwiftCode;
        /// <summary>
        /// 收款人开户行swift code
        /// </summary>
        public string PayeeOpenBankSwiftCode
        {
            get { return m_payeeOpenBankSwiftCode; }
            set { m_payeeOpenBankSwiftCode = value; }
        }
        private string m_payeeOpenBankAddress;
        /// <summary>
        /// 收款人开户行地址
        /// </summary>
        public string PayeeOpenBankAddress
        {
            get { return m_payeeOpenBankAddress; }
            set { m_payeeOpenBankAddress = value; }
        }
        private string m_correspondentBankName;
        /// <summary>
        /// 收款行之代理行名称
        /// </summary>
        public string CorrespondentBankName
        {
            get { return m_correspondentBankName; }
            set { m_correspondentBankName = value; }
        }
        private string m_CorrespondentBankSwiftCode;
        /// <summary>
        /// 收款行之代理行swift code
        /// </summary>
        public string CorrespondentBankSwiftCode
        {
            get { return m_CorrespondentBankSwiftCode; }
            set { m_CorrespondentBankSwiftCode = value; }
        }
        private string m_correspondentBankAddress;
        /// <summary>
        /// 收款行之代理行地址
        /// </summary>
        public string CorrespondentBankAddress
        {
            get { return m_correspondentBankAddress; }
            set { m_correspondentBankAddress = value; }
        }
        private string m_payeeAccountInCorrespondentBank;
        /// <summary>
        /// 收款人开户行在其代理行账号
        /// </summary>
        public string PayeeAccountInCorrespondentBank
        {
            get { return m_payeeAccountInCorrespondentBank; }
            set { m_payeeAccountInCorrespondentBank = value; }
        }
        private string m_remitNote;
        /// <summary>
        /// 汇款附言
        /// </summary>
        public string RemitNote
        {
            get { return m_remitNote; }
            set { m_remitNote = value; }
        }
        private AssumeFeeType m_AssumeFeeType;
        /// <summary>
        /// 国内外费用承担
        /// </summary>
        public AssumeFeeType AssumeFeeType
        {
            get { return m_AssumeFeeType; }
            set { m_AssumeFeeType = value; }
        }
        /// <summary>
        /// 国内外费用承担
        /// </summary>
        public string AssumeFeeTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<AssumeFeeType>.GetEnumDescription(m_AssumeFeeType); }
                catch { m_AssumeFeeType = EnumTypes.AssumeFeeType.Empty; }
                return result;
            }
        }
        private PayFeeType m_PayFeeType;
        /// <summary>
        /// 付款方式
        /// </summary>
        public PayFeeType PayFeeType
        {
            get { return m_PayFeeType; }
            set { m_PayFeeType = value; }
        }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string PayFeeTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<PayFeeType>.GetEnumDescription(m_PayFeeType); }
                catch { m_PayFeeType = EnumTypes.PayFeeType.Empty; }
                return result;
            }
        }
        private string m_dealSerialNoF = string.Empty;
        /// <summary>
        /// 交易编码1
        /// </summary>
        public string DealSerialNoF
        {
            get { return m_dealSerialNoF; }
            set { m_dealSerialNoF = value; }
        }
        private string m_amountF = string.Empty;
        /// <summary>
        /// 金额1
        /// </summary>
        public string AmountF
        {
            get { return m_amountF; }
            set { m_amountF = value; }
        }
        public string AmountFString
        {
            get
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(m_amountF))
                    str = DataConvertHelper.Instance.FormatCash(m_amountF.ToString(), m_PaymentCashType == CashType.JPY);
                return str;
            }
        }
        private string m_dealNoteF = string.Empty;
        /// <summary>
        /// 交易附言1
        /// </summary>
        public string DealNoteF
        {
            get { return m_dealNoteF; }
            set { m_dealNoteF = value; }
        }
        private string m_dealSerialNoS = string.Empty;
        /// <summary>
        /// 交易编码2
        /// </summary>
        public string DealSerialNoS
        {
            get { return m_dealSerialNoS; }
            set { m_dealSerialNoS = value; }
        }
        private string m_amountS = string.Empty;
        /// <summary>
        /// 金额2
        /// </summary>
        public string AmountS
        {
            get { return m_amountS; }
            set { m_amountS = value; }
        }
        public string AmountSString
        {
            get
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(m_amountS))
                    str = DataConvertHelper.Instance.FormatCash(m_amountS.ToString(), m_PaymentCashType == CashType.JPY);
                return str;
            }
        }
        private string m_dealNoteS = string.Empty;
        /// <summary>
        /// 交易附言2
        /// </summary>
        public string DealNoteS
        {
            get { return m_dealNoteS; }
            set { m_dealNoteS = value; }
        }
        private bool m_isPayOffLine;
        public bool IsPayOffLine
        {
            get { return m_isPayOffLine; }
            set { m_isPayOffLine = value; }
        }
        /// <summary>
        /// 本笔款项是否为保税货物线下付款
        /// </summary>
        public string IsPayOffLineString
        {
            get
            {
                string result = string.Empty;
                result = m_isPayOffLine ? "是" : "否";
                return result;
            }
        }
        private string m_contactNo;
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContactNo
        {
            get { return m_contactNo; }
            set { m_contactNo = value; }
        }
        private string m_billSerialNo;
        /// <summary>
        /// 发票号码
        /// </summary>
        public string BillSerialNo
        {
            get { return m_billSerialNo; }
            set { m_billSerialNo = value; }
        }
        private string m_batchNoOrTNoOrSerialNo;
        /// <summary>
        /// 外汇局批件号/备案表号/业务编号
        /// </summary>
        public string BatchNoOrTNoOrSerialNo
        {
            get { return m_batchNoOrTNoOrSerialNo; }
            set { m_batchNoOrTNoOrSerialNo = value; }
        }
        private string m_proposerName;
        /// <summary>
        /// 申请人名称
        /// </summary>
        public string ProposerName
        {
            get { return m_proposerName; }
            set { m_proposerName = value; }
        }
        private string m_telephone;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone
        {
            get { return m_telephone; }
            set { m_telephone = value; }
        }
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
        private BarBusinessType m_BarBusinessType;
        /// <summary>
        /// 业务类型
        /// </summary>
        public BarBusinessType BarBusinessType
        {
            get { return m_BarBusinessType; }
            set { m_BarBusinessType = value; }
        }
        public string BarBusinessTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (m_BarBusinessType != EnumTypes.BarBusinessType.Empty)
                        str = EnumNameHelper<BarBusinessType>.GetEnumDescription(m_BarBusinessType);
                }
                catch { }
                return str;
            }
        }
        private BarApplyFlagType m_BarApplyFlagType;
        /// <summary>
        /// 申报标识
        /// </summary>
        public BarApplyFlagType BarApplyFlagType
        {
            get { return m_BarApplyFlagType; }
            set { m_BarApplyFlagType = value; }
        }
        public string BarApplyFlagTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (m_BarApplyFlagType != EnumTypes.BarApplyFlagType.Empty)
                        str = EnumNameHelper<BarApplyFlagType>.GetEnumDescription(m_BarApplyFlagType);
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
        private string m_CertifyPaperNo;
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertifyPaperNo
        {
            get { return m_CertifyPaperNo; }
            set { m_CertifyPaperNo = value; }
        }
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
        #endregion
    }
}
