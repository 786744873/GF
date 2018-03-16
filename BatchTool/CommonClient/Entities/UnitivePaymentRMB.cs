using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class UnitivePaymentRMB
    {
        public UnitivePaymentRMB()
        {
            UnitivePaymentType = UnitivePaymentType.Empty;
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
        ///   实际付款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 12, MaxLength = 18, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 18, RegCode = "reg57", Required = false)]
        public string PayerAccount { get; set; }

        /// <summary>
        ///   实际付款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 200, RegCode = "reg661", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 200, RegCode = "reg661", Required = false)]
        public string PayerName { get; set; }

        /// <summary>
        ///   收款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 32, RegCode = "reg688", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 32, RegCode = "reg688", Required = false)]
        public string PayeeAccount { get; set; }

        /// <summary>
        ///   收款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 76, RegCode = "reg685", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 76, RegCode = "reg685", Required = false)]
        public string PayeeName { get; set; }

        /// <summary>
        ///   收款账户是否中行账户
        /// </summary>
        public AccountBankType BankType { get; set; }

        public string BankTypeString
        {
            get
            {
                string str = string.Empty;
                if (BankType == AccountBankType.BocAccount)
                    str = EnumNameHelper<AccountBankType>.GetEnumDescription(BankType);
                else str = PayeeOpenBankName;
                return str;
            }
        }

        /// <summary>
        ///   收款行CNAPS号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Boc", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = false)]
        public string PayeeCNAPS { get; set; }

        /// <summary>
        ///   收款人开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-Boc", MinLength = 0, MaxLength = 0, RegCode = "", Required = false), DvValidatRule(CaseDescription = "Normal-Other", MinLength = 1, MaxLength = 140, RegCode = "Predefined5", Required = true), DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 140, RegCode = "Predefined5", Required = false)]
        public string PayeeOpenBankName { get; set; }

        /// <summary>
        ///   名义付款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 35, RegCode = "reg766", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 35, RegCode = "reg766", Required = false)]
        public string NominalPayerAccount { get; set; }

        /// <summary>
        ///   名义付款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 76, RegCode = "reg685", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 76, RegCode = "reg685", Required = false)]
        public string NominalPayerName { get; set; }

        //private string m_nominalPayerBankLinkNo;
        /// <summary>
        ///   金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Amount { get; set; }

        /// <summary>
        ///   付款方式
        /// </summary>
        public UnitivePaymentType UnitivePaymentType { get; set; }

        public string UnitivePaymentTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = EnumNameHelper<UnitivePaymentType>.GetEnumDescription(UnitivePaymentType);
                }
                catch
                {
                    UnitivePaymentType = UnitivePaymentType.Empty;
                }
                return str;
            }
        }

        /// <summary>
        ///   预约付款日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string OrderPayDate { get; set; }

        ///<summary>
        ///  预约付款时间
        ///</summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string OrderPayTime { get; set; }

        public string OrderPayDateTime
        {
            get { return OrderPayDate + " " + (string.IsNullOrEmpty(OrderPayTime) ? OrderPayTime : OrderPayTime + ":00"); }
        }

        /// <summary>
        ///   客户业务编号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 16, RegCode = "reg8", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 16, RegCode = "reg8", Required = false)]
        public string CustomerBusinissNo { get; set; }

        /// <summary>
        ///   处理优先级
        /// </summary>
        public TransferChanelType TransferChanelType { get; set; }

        public string TransferChanelTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = EnumNameHelper<TransferChanelType>.GetEnumDescription(TransferChanelType);
                }
                catch
                {
                    TransferChanelType = TransferChanelType.Normal;
                }
                return str;
            }
        }

        /// <summary>
        ///   短信提醒收款人
        /// </summary>
        public bool IsTipPayee { get; set; }

        public string IsTipPayeeString
        {
            get { return IsTipPayee ? "是" : "否"; }
        }

        /// <summary>
        ///   短信提醒收款人手机号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-NoTip", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Tip", MinLength = 11, MaxLength = 15, RegCode = "reg8", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 11, MaxLength = 15, RegCode = "reg8", Required = false)]
        public string TipPayeePhone { get; set; }

        /// <summary>
        ///   用途
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 200, RegCode = "reg641", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 200, RegCode = "reg641", Required = false)]
        public string Purpose { get; set; }
    }
}