using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class SpplyFinancingApply : EntityBase
    {
        public int RowIndex { get; set; }
        /// <summary>
        ///   合同/订单号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 70, RegCode = "reg641", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 70, RegCode = "reg641", Required = false)]
        public string ContractOrOrderNo { get; set; }

        /// <summary>
        ///   订单日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string OrderDate { get; set; }

        /// <summary>
        ///   合同/订单币种
        /// </summary>
        public CashType ContractOrOrderCashType { get; set; }

        /// <summary>
        ///   合同/订单币种
        /// </summary>
        public string ContractOrOrderCashTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<CashType>.GetEnumDescription(ContractOrOrderCashType);
                }
                catch
                {
                    ContractOrOrderCashType = CashType.Empty;
                }
                return result;
            }
        }

        /// <summary>
        ///   合同/订单金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string ContractOrOrderAmount { get; set; }

        /// <summary>
        ///   发货日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string DeliveryDate { get; set; }

        public SettlementType SettlementType { get; set; }

        /// <summary>
        ///   结算方式
        /// </summary>
        public string SettlementTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<SettlementType>.GetEnumDescription(SettlementType);
                }
                catch
                {
                    SettlementType = SettlementType.Empty;
                }
                return result;
            }
        }

        /// <summary>
        ///   税务发票号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 70, RegCode = "reg641", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 70, RegCode = "reg641", Required = false)]
        public string TaxInvoiceNo { get; set; }

        /// <summary>
        ///   收货单号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 40, RegCode = "reg641", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 40, RegCode = "reg641", Required = false)]
        public string ReceiptNo { get; set; }

        /// <summary>
        ///   风险承担函号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 70, RegCode = "reg641", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 70, RegCode = "reg641", Required = false)]
        public string RiskTakingLetterNo { get; set; }

        /// <summary>
        ///   货物描述
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 600, RegCode = "reg641", Required = false)]
        public string GoodsDesc { get; set; }

        /// <summary>
        ///   融资申请金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string ApplyAmount { get; set; }

        /// <summary>
        ///   申请融资天数
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 4, RegCode = "reg714", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 4, RegCode = "reg714", Required = false)]
        public int ApplyDays { get; set; }

        /// <summary>
        ///   协议文本编号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 70, RegCode = "reg641", Required = false)]
        public string AgreementNo { get; set; }

        /// <summary>
        ///   利率浮动方式
        /// </summary>
        public InterestFloatType InterestFloatType { get; set; }

        /// <summary>
        ///   利率浮动方式
        /// </summary>
        public string InterestFloatTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<InterestFloatType>.GetEnumDescription(InterestFloatType);
                }
                catch
                {
                    InterestFloatType = InterestFloatType.Empty;
                }
                return result;
            }
        }

        /// <summary>
        ///   利率浮动比例
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 13, RegCode = "Predefined6", Required = false)]
        public string InterestFloatingPercent { get; set; }
    }
}