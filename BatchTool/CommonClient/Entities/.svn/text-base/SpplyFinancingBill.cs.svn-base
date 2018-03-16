using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class SpplyFinancingBill : EntityBase
    {
        public int RowIndex { get; set; }
        /// <summary>
        ///   发票号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 20, RegCode = "reg720", Required = false)]
        public string BillSerialNo { get; set; }

        /// <summary>
        ///   合同号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 40, RegCode = "reg641", Required = false)]
        public string ContractNo { get; set; }

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
                var result = string.Empty;
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
        ///   发票金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Amount { get; set; }

        /// <summary>
        ///   发票日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string BillDate { get; set; }

        /// <summary>
        ///   起算日
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string StartDate { get; set; }

        /// <summary>
        ///   到期日
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string EndDate { get; set; }
    }
}