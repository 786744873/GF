using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class PreproccessTransfer : EntityBase
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
        ///   待处理账户名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string PreproccessName { get; set; }

        /// <summary>
        ///   待处理账号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string PreproccessAccount { get; set; }

        /// <summary>
        ///   待处理金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string PreproccessAmount { get; set; }

        /// <summary>
        ///   币种
        /// </summary>
        public CashType CashType { get; set; }

        /// <summary>
        ///   币种
        /// </summary>
        public string CashTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    str = EnumNameHelper<CashType>.GetEnumDescription(CashType);
                }
                catch
                {
                    CashType = CashType.Empty;
                }
                return str;
            }
        }

        /// <summary>
        ///   主账户账号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string MainAccount { get; set; }

        /// <summary>
        ///   交易流水号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string TradeSerialNo { get; set; }

        /// <summary>
        ///   交易流水子号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string BatchTradeSerialNo { get; set; }

        /// <summary>
        ///   对方账户名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string InvolvedName { get; set; }

        /// <summary>
        ///   对方账号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string InvolvedAccount { get; set; }

        /// <summary>
        ///   交易日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string TradeDate { get; set; }

        /// <summary>
        ///   摘要
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Content { get; set; }

        /// <summary>
        ///   虚拟账户账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 35, RegCode = "reg648", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 35, RegCode = "reg648", Required = false)]
        public string VirtualAccount { get; set; }

        /// <summary>
        ///   金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Amount { get; set; }
    }
}