using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class ElecTicketPool : EntityBase
    {
        /// <summary>
        ///   行号 供匹配错误文件使用
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        ///   错误原因 供匹配错误文件使用
        /// </summary>
        public string ErrorReason { get; set; }

        /// <summary>
        ///   票据类型
        /// </summary>
        public ElecTicketType ElecTicketType { get; set; }

        /// <summary>
        ///   票据类型
        /// </summary>
        public string ElecTicketTypeString
        {
            get
            {
                var result = EnumNameHelper<ElecTicketType>.GetEnumDescription(ElecTicketType);
                return result;
            }
        }

        /// <summary>
        ///   票据自定义编号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 14, RegCode = "reg718", Required = false)]
        public string CustomerRef { get; set; }

        /// <summary>
        ///   票据号码
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 30, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 30, RegCode = "reg57", Required = false)]
        public string ElecTicketSerialNo { get; set; }

        /// <summary>
        ///   出票日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string RemitDate { get; set; }

        /// <summary>
        ///   承兑日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string ExchangeDate { get; set; }

        /// <summary>
        ///   到期日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string EndDate { get; set; }

        /// <summary>
        ///   承兑行
        /// </summary>
        public AccountBankType BankType { get; set; }

        /// <summary>
        ///   承兑行
        /// </summary>
        public string BankTypeString
        {
            get
            {
                var result = string.Empty;
                result = EnumNameHelper<AccountBankType>.GetEnumDescription(BankType);
                return result;
            }
        }

        /// <summary>
        ///   票据金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Amount { get; set; }

        /// <summary>
        ///   出票人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = false)]
        public string RemitAccount { get; set; }

        /// <summary>
        ///   出票人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string RemitName { get; set; }

        /// <summary>
        ///   承兑行名称/承兑人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string ExchangeName { get; set; }

        /// <summary>
        ///   承兑人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 32, RegCode = "Predefined4", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 32, RegCode = "Predefined4", Required = false)]
        public string ExchangeAccount { get; set; }

        /// <summary>
        ///   承兑行行号/承兑人开户行号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = false)]
        public string ExchangeBankNo { get; set; }

        /// <summary>
        ///   承兑人开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        public string ExchangeBankName { get; set; }

        /// <summary>
        ///   收款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 32, RegCode = "Predefined4", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 32, RegCode = "Predefined4", Required = false)]
        public string PayeeAccount { get; set; }

        /// <summary>
        ///   收款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string PayeeName { get; set; }

        /// <summary>
        ///   收款人开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string PayeeOpenBankName { get; set; }

        /// <summary>
        ///   收款人开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = false)]
        public string PayeeOpenBankNo { get; set; }

        /// <summary>
        ///   前一收背书人
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 120, RegCode = "reg540", Required = false)]
        public string PreBackNotedPerson { get; set; }

        /// <summary>
        ///   到期操作
        /// </summary>
        public EndDateOperateType EndDateOperate { get; set; }

        /// <summary>
        ///   到期操作
        /// </summary>
        public string EndDateOperateString
        {
            get
            {
                var result = EnumNameHelper<EndDateOperateType>.GetEnumDescription(EndDateOperate);
                return result;
            }
        }

        /// <summary>
        ///   业务种类
        /// </summary>
        public ElecTicketPoolBusinessType BusinessType { get; set; }

        /// <summary>
        ///   业务种类
        /// </summary>
        public string BusinessTypeString
        {
            get
            {
                var result = EnumNameHelper<ElecTicketPoolBusinessType>.GetEnumDescription(BusinessType);
                return result;
            }
        }
    }
}