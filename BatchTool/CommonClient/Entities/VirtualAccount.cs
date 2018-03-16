using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class VirtualAccount : EntityBase
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
        ///   转出账户账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 35, RegCode = "reg629", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 35, RegCode = "reg629", Required = false)]
        public string AccountOut { get; set; }

        /// <summary>
        ///   转出账户名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg585", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 120, RegCode = "reg585", Required = false)]
        public string NameOut { get; set; }

        /// <summary>
        ///   转入账户账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 35, RegCode = "reg629", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 35, RegCode = "reg629", Required = false)]
        public string AccountIn { get; set; }

        /// <summary>
        ///   转入账户名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 120, RegCode = "reg585", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 120, RegCode = "reg585", Required = false)]
        public string NameIn { get; set; }

        /// <summary>
        ///   金额
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 14, RegCode = "reg", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 14, RegCode = "reg", Required = false)]
        public string Amount { get; set; }

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
        ///   客户业务编号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 16, RegCode = "reg8", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 16, RegCode = "reg8", Required = false)]
        public string CustomerBusinissNo { get; set; }

        /// <summary>
        ///   用途
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 200, RegCode = "reg641", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 200, RegCode = "reg641", Required = false)]
        public string Purpose { get; set; }
    }
}