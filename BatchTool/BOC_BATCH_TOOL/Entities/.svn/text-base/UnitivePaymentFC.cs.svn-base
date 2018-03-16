using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    public class UnitivePaymentForeignMoney
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
        private OverCountryPayeeAccountType m_PayeeAccountType = OverCountryPayeeAccountType.Empty;
        /// <summary>
        /// 支付类型
        /// </summary>
        public OverCountryPayeeAccountType PayeeAccountType
        {
            get { return m_PayeeAccountType; }
            set { m_PayeeAccountType = value; }
        }
        public string PayeeAccountTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (m_PayeeAccountType != OverCountryPayeeAccountType.Empty)
                        str = EnumNameHelper<OverCountryPayeeAccountType>.GetEnumDescription(m_PayeeAccountType);
                }
                catch { }
                return str;
            }
        }
        private UnitiveFCPayeeAccountType m_FCPayeeAccountType = UnitiveFCPayeeAccountType.Empty;
        /// <summary>
        /// 跨境外币统一支付--收款人账号类型
        /// </summary>
        public UnitiveFCPayeeAccountType FCPayeeAccountType
        {
            get { return m_FCPayeeAccountType; }
            set { m_FCPayeeAccountType = value; }
        }
        /// <summary>
        /// 跨境外币统一支付--收款人账号类型
        /// </summary>
        public string FCPayeeAccountTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (m_FCPayeeAccountType != UnitiveFCPayeeAccountType.Empty)
                        str = EnumNameHelper<UnitiveFCPayeeAccountType>.GetEnumDescription(m_FCPayeeAccountType);
                }
                catch { }
                return str;
            }
        }
        private string m_PayerAccount;
        /// <summary>
        /// 实际付款人账号
        /// </summary>
        public string PayerAccount
        {
            get { return m_PayerAccount; }
            set { m_PayerAccount = value; }
        }
        private string m_PayerName;
        /// <summary>
        /// 实际付款人名称
        /// </summary>
        public string PayerName
        {
            get { return m_PayerName; }
            set { m_PayerName = value; }
        }
        private string m_nominalPayerName;
        /// <summary>
        /// 名义付款人名称
        /// </summary>
        public string NominalPayerName
        {
            get { return m_nominalPayerName; }
            set { m_nominalPayerName = value; }
        }
        private string m_nominalPayerAccount;
        /// <summary>
        /// 名义付款人账号
        /// </summary>
        public string NominalPayerAccount
        {
            get { return m_nominalPayerAccount; }
            set { m_nominalPayerAccount = value; }
        }
        private CashType m_cashtype;
        /// <summary>
        /// 货币类型
        /// </summary>
        public CashType CashType
        {
            get { return m_cashtype; }
            set { m_cashtype = value; }
        }
        /// <summary>
        /// 货币类型
        /// </summary>
        public string CashTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<CashType>.GetEnumDescription(m_cashtype); }
                catch { m_cashtype = EnumTypes.CashType.Empty; }
                return result;
            }
        }
        private string m_OrderPayDate;
        /// <summary>
        /// 指定付款日期
        /// </summary>
        public string OrderPayDate
        {
            get { return m_OrderPayDate; }
            set { m_OrderPayDate = value; }
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
        private string m_Amount;
        /// <summary>
        /// 汇款金额
        /// </summary>
        public string Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
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
        private string m_CustomerBusinissNo;
        /// <summary>
        /// 客户业务编号
        /// </summary>
        public string CustomerBusinissNo
        {
            get { return m_CustomerBusinissNo; }
            set { m_CustomerBusinissNo = value; }
        }
        private string m_Addtion;
        /// <summary>
        /// 附言
        /// </summary>
        public string Addtion
        {
            get { return m_Addtion; }
            set { m_Addtion = value; }
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
        private string m_Address;
        /// <summary>
        /// 收款人地址
        /// </summary>
        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
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
        private string m_openBankAddress;
        /// <summary>
        /// 收款人开户行地址
        /// </summary>
        public string OpenBankAddress
        {
            get { return m_openBankAddress; }
            set { m_openBankAddress = value; }
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
        private string m_payeeAccountInCorrespondentBank;
        /// <summary>
        /// 收款人开户行在其代理行账号
        /// </summary>
        public string PayeeAccountInCorrespondentBank
        {
            get { return m_payeeAccountInCorrespondentBank; }
            set { m_payeeAccountInCorrespondentBank = value; }
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
        private string m_CodeofCountry;
        /// <summary>
        /// 收款人常驻国家（地区）代码
        /// </summary>
        public string CodeofCountry
        {
            get { return m_CodeofCountry; }
            set { m_CodeofCountry = value; }
        }
        private string m_NameofCountry;
        /// <summary>
        /// 收款人常驻国家名称
        /// </summary>
        public string NameofCountry
        {
            get { return m_NameofCountry; }
            set { m_NameofCountry = value; }
        }
        /// <summary>
        /// 收款人国家（地区）名称及代码
        /// </summary>
        public string PayeeCountry
        {
            get { return m_NameofCountry + " " + m_CodeofCountry; }
        }
        private IsImportCancelAfterVerificationType m_IsImportCancelAfterVerificationType = IsImportCancelAfterVerificationType.Empty;
        /// <summary>
        /// 是否进口核销付款
        /// </summary>
        public IsImportCancelAfterVerificationType IsImportCancelAfterVerificationType
        {
            get { return m_IsImportCancelAfterVerificationType; }
            set { m_IsImportCancelAfterVerificationType = value; }
        }
        /// <summary>
        /// 是否进口核销付款
        /// </summary>
        public string IsImportCancelAfterVerificationTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (m_IsImportCancelAfterVerificationType != IsImportCancelAfterVerificationType.Empty)
                        str = EnumNameHelper<IsImportCancelAfterVerificationType>.GetEnumDescription(m_IsImportCancelAfterVerificationType);
                }
                catch { }
                return str;
            }
        }
        private PayFeeType m_UnitivePaymentType = PayFeeType.Empty;
        /// <summary>
        /// 付款方式
        /// </summary>
        public PayFeeType UnitivePaymentType
        {
            get { return m_UnitivePaymentType; }
            set { m_UnitivePaymentType = value; }
        }
        public string UnitivePaymentTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (m_UnitivePaymentType != EnumTypes.PayFeeType.Empty)
                        str = EnumNameHelper<EnumTypes.PayFeeType>.GetEnumDescription(m_UnitivePaymentType);
                }
                catch { }
                return str;
            }
        }
        private PaymentPropertyType m_PaymentPropertyType;
        /// <summary>
        /// 付款性质
        /// </summary>
        public PaymentPropertyType PaymentNature
        {
            get { return m_PaymentPropertyType; }
            set { m_PaymentPropertyType = value; }
        }
        public string PaymentNatureString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (m_PaymentPropertyType != EnumTypes.PaymentPropertyType.Empty)
                        str = EnumNameHelper<EnumTypes.PaymentPropertyType>.GetEnumDescription(m_PaymentPropertyType);
                }
                catch { }
                return str;
            }
        }
        private string m_TransactionCode1;
        /// <summary>
        /// 交易编码1
        /// </summary>
        public string TransactionCode1
        {
            get { return m_TransactionCode1; }
            set { m_TransactionCode1 = value; }
        }
        private string m_TransactionCode2;
        /// <summary>
        /// 交易编码2
        /// </summary>
        public string TransactionCode2
        {
            get { return m_TransactionCode2; }
            set { m_TransactionCode2 = value; }
        }
        private string m_IPPSMoneyTypeAmount1;
        /// <summary>
        /// 相应货币及金额1
        /// </summary>
        public string IPPSMoneyTypeAmount1
        {
            get { return m_IPPSMoneyTypeAmount1; }
            set { m_IPPSMoneyTypeAmount1 = value; }
        }
        private string m_IPPSMoneyTypeAmount2;
        /// <summary>
        /// 相应货币及金额2
        /// </summary>
        public string IPPSMoneyTypeAmount2
        {
            get { return m_IPPSMoneyTypeAmount2; }
            set { m_IPPSMoneyTypeAmount2 = value; }
        }
        private string m_TransactionAddtion1;
        /// <summary>
        /// 交易附言1
        /// </summary>
        public string TransactionAddtion1
        {
            get { return m_TransactionAddtion1; }
            set { m_TransactionAddtion1 = value; }
        }
        private string m_TransactionAddtion2;
        /// <summary>
        /// 交易附言2
        /// </summary>
        public string TransactionAddtion2
        {
            get { return m_TransactionAddtion2; }
            set { m_TransactionAddtion2 = value; }
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
        private string m_ContractNo;
        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNo
        {
            get { return m_ContractNo; }
            set { m_ContractNo = value; }
        }
        private string m_InvoiceNo;
        /// <summary>
        /// 发票号
        /// </summary>
        public string InvoiceNo
        {
            get { return m_InvoiceNo; }
            set { m_InvoiceNo = value; }
        }
        private string m_BatchNoOrTNoOrSerialNo;
        /// <summary>
        /// 外汇局批件号/备案表号/业务编号
        /// </summary>
        public string BatchNoOrTNoOrSerialNo
        {
            get { return m_BatchNoOrTNoOrSerialNo; }
            set { m_BatchNoOrTNoOrSerialNo = value; }
        }
        private string m_ApplicantName;
        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string ApplicantName
        {
            get { return m_ApplicantName; }
            set { m_ApplicantName = value; }
        }
        private string m_Contactnumber;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Contactnumber
        {
            get { return m_Contactnumber; }
            set { m_Contactnumber = value; }
        }
        private string m_purpose;
        /// <summary>
        /// 用途
        /// </summary>
        public string Purpose
        {
            get { return m_purpose; }
            set { m_purpose = value; }
        }
        private string m_realPayAddress;
        /// <summary>
        /// 实际付款人地址
        /// </summary>
        public string realPayAddress
        {
            get { return m_realPayAddress; }
            set { m_realPayAddress = value; }
        }
        private AccountBankType m_PayeeOpenBankType = AccountBankType.Empty;
        /// <summary>
        /// 收款人银行类型
        /// </summary>
        public AccountBankType PayeeOpenBankType
        {
            get { return m_PayeeOpenBankType; }
            set { m_PayeeOpenBankType = value; }
        }
        public string PayeeOpenBankTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (m_PayeeOpenBankType != AccountBankType.Empty)
                        str = EnumNameHelper<AccountBankType>.GetEnumDescription(m_PayeeOpenBankType);
                }
                catch { }
                return str;
            }
        }
        private Transfer2CountryType m_PaymentCountryOrArea;
        /// <summary>
        /// 汇往国家或地区
        /// </summary>
        public Transfer2CountryType PaymentCountryOrArea
        {
            get { return m_PaymentCountryOrArea; }
            set { m_PaymentCountryOrArea = value; }
        }
        /// <summary>
        /// 汇往国家或者地区
        /// </summary>
        public string PaymentCountryOrAreaString
        {
            get
            {
                string str = string.Empty;
                try { str = EnumNameHelper<Transfer2CountryType>.GetEnumDescription(m_PaymentCountryOrArea); }
                catch { }
                return str;
            }
        }
    }
}
