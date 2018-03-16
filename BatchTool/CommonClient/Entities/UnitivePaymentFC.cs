using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class UnitivePaymentForeignMoney
    {
        public UnitivePaymentForeignMoney()
        {
            IsImportCancelAfterVerificationType = IsImportCancelAfterVerificationType.Empty;
            PayeeOpenBankType = AccountBankType.Empty;
            UnitivePaymentType = PayFeeType.Empty;
            FCPayeeAccountType = UnitiveFCPayeeAccountType.Empty;
            PayeeAccountType = OverCountryPayeeAccountType.Empty;
            PaymentNature = PaymentPropertyType.Empty;
        }

        /// <summary>
        ///   行号 供匹配错误文件使用
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        ///   错误原因 供匹配错误文件使用
        /// </summary>
        public string ErrorReason { get; set; }

        /// <summary>
        ///   支付类型
        /// </summary>
        public OverCountryPayeeAccountType PayeeAccountType { get; set; }

        public string PayeeAccountTypeString
        {
            get
            {
                string str = string.Empty;
                if (PayeeAccountType != OverCountryPayeeAccountType.Empty)
                    str = EnumNameHelper<OverCountryPayeeAccountType>.GetEnumDescription(PayeeAccountType);
                return str;
            }
        }

        /// <summary>
        ///   跨境外币统一支付--收款人账号类型
        /// </summary>
        public UnitiveFCPayeeAccountType FCPayeeAccountType { get; set; }

        /// <summary>
        ///   跨境外币统一支付--收款人账号类型
        /// </summary>
        public string FCPayeeAccountTypeString
        {
            get
            {
                string str = string.Empty;
                if (FCPayeeAccountType != UnitiveFCPayeeAccountType.Empty)
                    str = EnumNameHelper<UnitiveFCPayeeAccountType>.GetEnumDescription(FCPayeeAccountType);
                return str;
            }
        }

        /// <summary>
        ///   实际付款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 12, MaxLength = 18, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 12, MaxLength = 18, RegCode = "reg57", Required = false)]
        public string PayerAccount { get; set; }

        /// <summary>
        ///   实际付款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Out", MinLength = 0, MaxLength = 140, RegCode = "reg661", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-In", MinLength = 0, MaxLength = 140, RegCode = "reg702", Required = false)]
        public string PayerName { get; set; }

        /// <summary>
        ///   名义付款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Out", MinLength = 1, MaxLength = 140, RegCode = "reg702", Required = true)]
        [DvValidatRule(CaseDescription = "Normal-In", MinLength = 1, MaxLength = 200, RegCode = "reg661", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert-Out", MinLength = 1, MaxLength = 140, RegCode = "reg702", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert-In", MinLength = 1, MaxLength = 200, RegCode = "reg661", Required = false)]
        public string NominalPayerName { get; set; }

        /// <summary>
        ///   名义付款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Out", MinLength = 1, MaxLength = 35, RegCode = "reg702", Required = true)]
        [DvValidatRule(CaseDescription = "Normal-In", MinLength = 1, MaxLength = 35, RegCode = "reg766", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert-Out", MinLength = 1, MaxLength = 35, RegCode = "reg702", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert-In", MinLength = 1, MaxLength = 35, RegCode = "reg766", Required = false)]
        public string NominalPayerAccount { get; set; }

        /// <summary>
        /// 名义付款人地址
        /// </summary>
        public string NominalPayerAddress { get; set; }

        /// <summary>
        ///   货币类型
        /// </summary>
        public CashType CashType { get; set; }

        /// <summary>
        ///   货币类型
        /// </summary>
        public string CashTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<CashType>.GetEnumDescription(CashType);
                }
                catch
                {
                    CashType = CashType.Empty;
                }
                return result;
            }
        }

        /// <summary>
        ///   指定付款日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string OrderPayDate { get; set; }

        /// <summary>
        ///   发电等级
        /// </summary>
        public TransferChanelType SendPriority { get; set; }

        /// <summary>
        ///   发电等级
        /// </summary>
        public string SendPriorityString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<TransferChanelType>.GetEnumDescription(SendPriority);
                }
                catch
                {
                    SendPriority = TransferChanelType.Normal;
                }
                return result;
            }
        }

        /// <summary>
        ///   汇款金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Amount { get; set; }

        /// <summary>
        ///   组织机构代码
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Boc", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 10, MaxLength = 10, RegCode = "reg698", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 10, MaxLength = 10, RegCode = "reg698", Required = false)]
        public string OrgCode { get; set; }

        /// <summary>
        ///   客户业务编号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 16, RegCode = "reg8", Required = false)]
        public string CustomerBusinissNo { get; set; }

        /// <summary>
        ///   附言
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Addtion { get; set; }

        /// <summary>
        ///   收款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-In", MinLength = 1, MaxLength = 35, RegCode = "reg648", Required = true)]
        [DvValidatRule(CaseDescription = "Normal-Out", MinLength = 1, MaxLength = 34, RegCode = "reg702", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert-In", MinLength = 1, MaxLength = 35, RegCode = "reg648", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert-Out", MinLength = 1, MaxLength = 34, RegCode = "reg702", Required = false)]
        public string PayeeAccount { get; set; }

        /// <summary>
        ///   收款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Boc", MinLength = 1, MaxLength = 240, RegCode = "reg685", Required = true)]
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 1, MaxLength = 70, RegCode = "reg662", Required = true)]
        [DvValidatRule(CaseDescription = "Normal-Foreign", MinLength = 1, MaxLength = 140, RegCode = "Predefined5", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert-Boc", MinLength = 1, MaxLength = 240, RegCode = "reg685", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert-Other", MinLength = 1, MaxLength = 70, RegCode = "reg662", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert-Foreign", MinLength = 1, MaxLength = 140, RegCode = "reg702", Required = false)]
        public string PayeeName { get; set; }

        /// <summary>
        ///   收款人地址
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Boc", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 1, MaxLength = 140, RegCode = "reg662", Required = true)]
        [DvValidatRule(CaseDescription = "Normal-Foreign", MinLength = 1, MaxLength = 140, RegCode = "reg702", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert-Other", MinLength = 1, MaxLength = 140, RegCode = "reg662", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert-Foreign", MinLength = 1, MaxLength = 140, RegCode = "reg702", Required = false)]
        public string Address { get; set; }

        /// <summary>
        ///   收款人开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Boc", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 1, MaxLength = 140, RegCode = "reg662", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert-Other", MinLength = 1, MaxLength = 140, RegCode = "reg662", Required = false)]
        public string PayeeOpenBankName { get; set; }

        /// <summary>
        ///   收款人开户行地址
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Boc", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 0, MaxLength = 70, RegCode = "reg662", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Foreign", MinLength = 0, MaxLength = 140, RegCode = "reg662", Required = false)]
        public string OpenBankAddress { get; set; }

        /// <summary>
        ///   收款人开户行swift code
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 18, RegCode = "reg24", Required = false)]
        public string PayeeOpenBankSwiftCode { get; set; }

        /// <summary>
        ///   收款行之代理行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 140, RegCode = "reg662", Required = false)]
        public string CorrespondentBankName { get; set; }

        /// <summary>
        ///   收款行之代理行swift code
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 18, RegCode = "reg24", Required = false)]
        public string CorrespondentBankSwiftCode { get; set; }

        /// <summary>
        ///   收款人开户行在其代理行账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 0, MaxLength = 35, RegCode = "reg648", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Foreign", MinLength = 0, MaxLength = 35, RegCode = "reg688", Required = false)]
        public string PayeeAccountInCorrespondentBank { get; set; }

        /// <summary>
        ///   收款行之代理行地址
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 0, MaxLength = 280, RegCode = "reg630", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Foreign", MinLength = 0, MaxLength = 140, RegCode = "reg630", Required = false)]
        public string CorrespondentBankAddress { get; set; }

        /// <summary>
        ///   收款人常驻国家（地区）代码
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 3, MaxLength = 3, RegCode = "reg57", Required = true), DvValidatRule(CaseDescription = "FileConvert", MinLength = 3, MaxLength = 3, RegCode = "reg57", Required = false)]
        public string CodeofCountry { get; set; }

        /// <summary>
        ///   收款人常驻国家名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Boc", MinLength = 0, MaxLength = 0, RegCode = "", Required = false), DvValidatRule(CaseDescription = "Normal-Other", MinLength = 1, MaxLength = 140, RegCode = "reg630", Required = true), DvValidatRule(CaseDescription = "Normal-Foreign", MinLength = 1, MaxLength = 280, RegCode = "reg630", Required = false), DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 140, RegCode = "reg630", Required = false), DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 280, RegCode = "reg630", Required = false)]
        public string NameofCountry { get; set; }

        /// <summary>
        ///   收款人国家（地区）名称及代码
        /// </summary>
        public string PayeeCountry
        {
            get { return NameofCountry + " " + CodeofCountry; }
        }

        /// <summary>
        ///   是否进口核销付款
        /// </summary>
        public IsImportCancelAfterVerificationType IsImportCancelAfterVerificationType { get; set; }

        /// <summary>
        ///   是否进口核销付款
        /// </summary>
        public string IsImportCancelAfterVerificationTypeString
        {
            get
            {
                string str = string.Empty;
                if (IsImportCancelAfterVerificationType != IsImportCancelAfterVerificationType.Empty)
                    str = EnumNameHelper<IsImportCancelAfterVerificationType>.GetEnumDescription(IsImportCancelAfterVerificationType);
                return str;
            }
        }

        /// <summary>
        ///   付款方式
        /// </summary>
        public PayFeeType UnitivePaymentType { get; set; }

        public string UnitivePaymentTypeString
        {
            get
            {
                string str = string.Empty;
                if (UnitivePaymentType != PayFeeType.Empty)
                    str = EnumNameHelper<PayFeeType>.GetEnumDescription(UnitivePaymentType);
                return str;
            }
        }

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
        ///   付款性质
        /// </summary>
        public PaymentPropertyType PaymentNature { get; set; }

        public string PaymentNatureString
        {
            get
            {
                string str = string.Empty;
                if (PaymentNature != PaymentPropertyType.Empty)
                    str = EnumNameHelper<PaymentPropertyType>.GetEnumDescription(PaymentNature);
                return str;
            }
        }

        /// <summary>
        ///   交易编码1
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Boc", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 6, MaxLength = 6, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 6, MaxLength = 6, RegCode = "reg57", Required = false)]
        public string TransactionCode1 { get; set; }

        /// <summary>
        ///   交易编码2
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Boc", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 6, MaxLength = 6, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 6, MaxLength = 6, RegCode = "reg57", Required = false)]
        public string TransactionCode2 { get; set; }

        /// <summary>
        ///   相应货币及金额1
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string IPPSMoneyTypeAmount1 { get; set; }

        /// <summary>
        ///   相应货币及金额2
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string IPPSMoneyTypeAmount2 { get; set; }

        /// <summary>
        ///   交易附言1
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Foreign", MinLength = 0, MaxLength = 50, RegCode = "reg108", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 50, RegCode = "reg108", Required = false)]
        public string TransactionAddtion1 { get; set; }

        /// <summary>
        ///   交易附言2
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Foreign", MinLength = 0, MaxLength = 50, RegCode = "reg108", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 50, RegCode = "reg108", Required = false)]
        public string TransactionAddtion2 { get; set; }

        public bool IsPayOffLine { get; set; }

        /// <summary>
        ///   本笔款项是否为保税货物线下付款
        /// </summary>
        public string IsPayOffLineString
        {
            get
            {
                string result = IsPayOffLine ? "是" : "否";
                return result;
            }
        }

        /// <summary>
        ///   合同号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 20, RegCode = "Predefined5", Required = false)]
        public string ContractNo { get; set; }

        /// <summary>
        ///   发票号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert-Other", MinLength = 0, MaxLength = 35, RegCode = "reg702", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 50, RegCode = "reg702", Required = false)]
        public string InvoiceNo { get; set; }

        /// <summary>
        ///   外汇局批件号/备案表号/业务编号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 20, RegCode = "Predefined5", Required = false)]
        public string BatchNoOrTNoOrSerialNo { get; set; }

        /// <summary>
        ///   申请人姓名
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 70, RegCode = "reg540", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 70, RegCode = "reg540", Required = false)]
        public string ApplicantName { get; set; }

        /// <summary>
        ///   联系电话
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 15, RegCode = "reg699", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 15, RegCode = "reg699", Required = false)]
        public string Contactnumber { get; set; }

        /// <summary>
        ///   用途
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Boc", MinLength = 0, MaxLength = 400, RegCode = "reg108", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 400, RegCode = "reg108", Required = false)]
        public string Purpose { get; set; }

        /// <summary>
        ///   实际付款人地址
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Boc", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 0, MaxLength = 280, RegCode = "reg630", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 280, RegCode = "reg630", Required = false)]
        public string realPayAddress { get; set; }

        /// <summary>
        ///   收款人银行类型
        /// </summary>
        public AccountBankType PayeeOpenBankType { get; set; }

        public string PayeeOpenBankTypeString
        {
            get
            {
                string str = string.Empty;
                if (PayeeOpenBankType != AccountBankType.Empty)
                    str = EnumNameHelper<AccountBankType>.GetEnumDescription(PayeeOpenBankType);
                return str;
            }
        }

        /// <summary>
        ///   汇往国家或地区
        /// </summary>
        public Transfer2CountryType PaymentCountryOrArea { get; set; }

        /// <summary>
        ///   汇往国家或者地区
        /// </summary>
        public string PaymentCountryOrAreaString
        {
            get
            {
                string str = EnumNameHelper<Transfer2CountryType>.GetEnumDescription(PaymentCountryOrArea);
                return str;
            }
        }
    }
}