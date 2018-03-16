using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class SpplyFinancingPayOrReceipt : EntityBase
    {
        public int RowIndex { get; set; }
        /// <summary>
        ///   发票号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 20, RegCode = "reg720", Required = false)]
        public string BillSerialNo { get; set; }

        /// <summary>
        ///   卖/买方客户号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 16, RegCode = "reg697", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 16, RegCode = "reg697", Required = false)]
        public string CustomerNo { get; set; }

        /// <summary>
        ///   卖/买方客户名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 80, RegCode = "reg721", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 80, RegCode = "reg721", Required = false)]
        public string CustomerName { get; set; }

        /// <summary>
        ///   订单币别
        /// </summary>
        public CashType CashType { get; set; }

        /// <summary>
        ///   订单币别
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
        ///   本次收/付款金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string PayAmountForThisTime { get; set; }
    }
}