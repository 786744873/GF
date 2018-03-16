using System;
using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    /// <summary>
    ///   收款人名册类
    /// </summary>
    [Serializable]
    public class PayeeInfo : EntityBase, ICloneable
    {
        public int RowIndex { get; set; }
        /// <summary>
        ///   收款人账户类型
        /// </summary>
        public AccountCategoryType AccountType { get; set; }

        /// <summary>
        ///   是否中行
        /// </summary>
        public AccountBankType BankType { get; set; }

        public PayeeInfo()
        {
        }

        /// <summary>
        ///   收款人编号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string SerialNo { get; set; }
        /// <summary>
        /// 收款账号所属省份编号
        /// </summary>
        public ChinaProvinceType ProvinceType { get; set; }
        /// <summary>
        /// 收款账号所属省份
        /// </summary>
        public string ProvinceTypeName { get { try { return ProvinceType != ChinaProvinceType.B0 ? EnumNameHelper<ChinaProvinceType>.GetEnumDescription(ProvinceType) : string.Empty; } catch { return string.Empty; } } }
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
        ///   收款人账户类型
        /// </summary>
        public string AccountTypeString
        {
            get { return AccountCategoryType.Empty == AccountType ? string.Empty : (AccountCategoryType.Corperation == AccountType ? "对公" : "对私"); }
        }

        /// <summary>
        ///   开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string OpenBankName { get; set; }

        /// <summary>
        ///   CNAPS行号（开户）
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string CNAPSNo { get; set; }

        /// <summary>
        ///   开户行全名
        /// </summary>
        public string FullBankName
        {
            get { return OpenBankName + "-" + CNAPSNo; }
        }

        /// <summary>
        ///   清算行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string ClearBankName { get; set; }

        /// <summary>
        ///   CNAPS行号（清算）
        /// </summary>
        public string CNAPSNoR { get; set; }

        /// <summary>
        ///   清算行全名
        /// </summary>
        public string FullBankNameR
        {
            get { return ClearBankName + "-" + CNAPSNoR; }
        }

        /// <summary>
        ///   收款人地址
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Address { get; set; }

        /// <summary>
        ///   收款人e-mail
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Email { get; set; }

        /// <summary>
        ///   收款人手机号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Telephone { get; set; }

        /// <summary>
        ///   收款人传真号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Fax { get; set; }

        public PayeeCertifyPaperType CertifyPaperType { get; set; }

        public string CertifyPaperTypeString
        {
            get
            {
                string str = string.Empty;
                if (CertifyPaperType != PayeeCertifyPaperType.Empty)
                    str = EnumNameHelper<PayeeCertifyPaperType>.GetEnumDescription(CertifyPaperType);
                return str;
            }
        }

        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string CertifyPaperNo { get; set; }

        public string AccountBankTypeString
        {
            get
            {
                string str = string.Empty;
                if (BankType != AccountBankType.Empty)
                    str = EnumNameHelper<AccountBankType>.GetEnumDescription(BankType);
                return str;
            }
        }

        /// <summary>
        ///   协议号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string ProtecolNo { get; set; }

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public override string ToString()
        {
            return Account;
        }
    }
}