using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class SpplyFinancingOrder : EntityBase
    {
        public int RowIndex { get; set; }
        /// <summary>
        ///   订单编号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 70, RegCode = "reg717", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 70, RegCode = "reg717", Required = false)]
        public string OrderNo { get; set; }

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
        ///   订单金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Amount { get; set; }

        /// <summary>
        ///   卖方ERP代码
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 40, RegCode = "reg717", Required = false)]
        public string ERPCode { get; set; }

        /// <summary>
        ///   卖方银行客户号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 40, RegCode = "reg697", Required = false)]
        public string CustomerApplyNo { get; set; }

        /// <summary>
        ///   买方客户名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 80, RegCode = "reg717", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 80, RegCode = "reg717", Required = false)]
        public string CustomerName { get; set; }

        /// <summary>
        ///   预计(买方)付款日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string PayDate { get; set; }
    }
}