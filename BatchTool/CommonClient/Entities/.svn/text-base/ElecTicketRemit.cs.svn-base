using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    /// <summary>
    ///   批量出票信息类
    /// </summary>
    public class ElecTicketRemit : EntityBase
    {
        /// <summary>
        ///   操作记录行号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        ///   错误原因
        /// </summary>
        public string ErrorReason { get; set; }

        /// <summary>
        ///   票据种类
        /// </summary>
        public ElecTicketType TicketType { get; set; }

        /// <summary>
        ///   票据种类
        /// </summary>
        public string TicketTypeString
        {
            get
            {
                var result = string.Empty;
                if (ElecTicketType.Empty != TicketType)
                    result = EnumNameHelper<ElecTicketType>.GetEnumDescription(TicketType);
                return result;
            }
        }

        /// <summary>
        ///   票据金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Amount { get; set; }

        /// <summary>
        ///   出票日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string RemitDate { get; set; }

        /// <summary>
        ///   票据到期日
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string EndDate { get; set; }

        /// <summary>
        ///   出票人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = false)]
        public string RemitAccount { get; set; }

        /// <summary>
        ///   承兑人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string ExchangeName { get; set; }

        /// <summary>
        ///   承兑人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = false)]
        public string ExchangeAccount { get; set; }

        /// <summary>
        ///   承兑人开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string ExchangeOpenBankName { get; set; }

        /// <summary>
        ///   承兑人开户行行号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = false)]
        public string ExchangeOpenBankNo { get; set; }

        /// <summary>
        ///   收款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string PayeeName { get; set; }

        /// <summary>
        ///   收款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = false)]
        public string PayeeAccount { get; set; }

        /// <summary>
        ///   收款人开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string PayeeOpenBankName { get; set; }

        /// <summary>
        ///   收款人开户行行号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = false)]
        public string PayeeOpenBankNo { get; set; }

        /// <summary>
        ///   可否转让
        /// </summary>
        public CanChangeType CanChange { get; set; }

        /// <summary>
        ///   可否转让
        /// </summary>
        public string CanChangeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<CanChangeType>.GetEnumDescription(CanChange);
                }
                catch
                {
                    CanChange = CanChangeType.Empty;
                }
                return result;
            }
        }

        /// <summary>
        ///   是否自动提示承兑
        /// </summary>
        public bool AutoTipExchange { get; set; }

        /// <summary>
        ///   是否自动提示承兑
        /// </summary>
        public string AutoTipExchangeString
        {
            get { return AutoTipExchange ? "是" : "否"; }
        }

        /// <summary>
        ///   是否自动提示收票
        /// </summary>
        public bool AutoTipReceiveTicket { get; set; }

        /// <summary>
        ///   是否自动提示收票
        /// </summary>
        public string AutoTipReceiveTicketString
        {
            get { return AutoTipReceiveTicket ? "是" : "否"; }
        }

        /// <summary>
        ///   备注
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 512, RegCode = "reg667", Required = false)]
        public string Note { get; set; }
    }
}