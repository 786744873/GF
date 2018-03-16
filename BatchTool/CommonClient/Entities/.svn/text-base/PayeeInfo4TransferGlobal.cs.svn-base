using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class PayeeInfo4TransferGlobal : EntityBase
    {
        public int RowIndex { get; set; }
        /// <summary>
        ///   收款人类型
        /// </summary>
        public OverCountryPayeeAccountType AccountType { get; set; }

        /// <summary>
        ///   收款人类型
        /// </summary>
        public string AccountTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<OverCountryPayeeAccountType>.GetEnumDescription(AccountType);
                }
                catch
                {
                    AccountType = OverCountryPayeeAccountType.Empty;
                }
                return result;
            }
        }

        /// <summary>
        ///   收款人编号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string SerialNo { get; set; }

        /// <summary>
        ///   收款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Account { get; set; }

        /// <summary>
        ///   收款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Name { get; set; }

        /// <summary>
        ///   收款人地址
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Address { get; set; }

        /// <summary>
        ///   收款人常驻国家代码
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string CodeofCountry { get; set; }

        /// <summary>
        ///   收款人常驻国家名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string NameofCountry { get; set; }

        /// <summary>
        ///   收款人常驻国家名称及代码
        /// </summary>
        public string Country
        {
            get { return string.Format("{0} {1}", NameofCountry, CodeofCountry); }
        }

        /// <summary>
        ///   收款人开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string OpenBankName { get; set; }

        /// <summary>
        ///   收款人开户行地址
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string OpenBankAddress { get; set; }

        /// <summary>
        ///   收款人开户行类型
        /// </summary>
        public AccountBankType OpenBankType { get; set; }

        /// <summary>
        ///   收款人开户行类型
        /// </summary>
        public string OpenBankTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<AccountBankType>.GetEnumDescription(OpenBankType);
                }
                catch
                {
                    OpenBankType = AccountBankType.Empty;
                }
                return result;
            }
        }

        /// <summary>
        ///   收款行之代理行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string CorrespondentBankName { get; set; }

        /// <summary>
        ///   收款行之代理行地址
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string CorrespondentBankAddress { get; set; }

        /// <summary>
        ///   收款人开户行在其代理行账号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string AccountInCorrespondentBank { get; set; }

        /// <summary>
        ///   传真
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Fax { get; set; }

        /// <summary>
        ///   手机号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Telephone { get; set; }

        /// <summary>
        ///   email
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Email { get; set; }

        public override string ToString()
        {
            return Account;
        }
    }
}