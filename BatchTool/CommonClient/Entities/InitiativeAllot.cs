using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class InitiativeAllot : EntityBase
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
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 22, RegCode = "reg646", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 22, RegCode = "reg646", Required = false)]
        public string AccountOut { get; set; }

        /// <summary>
        ///   转出账户名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 76, RegCode = "reg641", Required = false)]
        public string NameOut { get; set; }

        /// <summary>
        ///   转入账户账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 22, RegCode = "reg646", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 22, RegCode = "reg646", Required = false)]
        public string AccountIn { get; set; }

        /// <summary>
        ///   转入账户名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 76, RegCode = "reg641", Required = false)]
        public string NameIn { get; set; }

        /// <summary>
        ///   金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Amount { get; set; }

        /// <summary>
        ///   附言
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 200, RegCode = "reg641", Required = false)]
        public string Addition { get; set; }

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
    }
}