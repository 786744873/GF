using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    public class PayeeInfo4TransferGlobal
    {
        private OverCountryPayeeAccountType m_AccountType;
        /// <summary>
        /// 收款人类型
        /// </summary>
        public OverCountryPayeeAccountType AccountType
        {
            get { return m_AccountType; }
            set { m_AccountType = value; }
        }
        /// <summary>
        /// 收款人类型
        /// </summary>
        public string AccountTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<OverCountryPayeeAccountType>.GetEnumDescription(m_AccountType); }
                catch { m_AccountType = OverCountryPayeeAccountType.Empty; }
                return result;
            }
        }
        private string m_SerialNo;
        /// <summary>
        /// 收款人编号
        /// </summary>
        public string SerialNo
        {
            get { return m_SerialNo; }
            set { m_SerialNo = value; }
        }
        private string m_Account;
        /// <summary>
        /// 收款人账号
        /// </summary>
        public string Account
        {
            get { return m_Account; }
            set { m_Account = value; }
        }
        private string m_Name;
        /// <summary>
        /// 收款人名称
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        private string m_address;
        /// <summary>
        /// 收款人地址
        /// </summary>
        public string Address
        {
            get { return m_address; }
            set { m_address = value; }
        }
        private string m_codeOfCountry;
        /// <summary>
        /// 收款人常驻国家代码
        /// </summary>
        public string CodeofCountry
        {
            get { return m_codeOfCountry; }
            set { m_codeOfCountry = value; }
        }
        private string m_nameOfCountry;
        /// <summary>
        /// 收款人常驻国家名称
        /// </summary>
        public string NameofCountry
        {
            get { return m_nameOfCountry; }
            set { m_nameOfCountry = value; }
        }
        /// <summary>
        /// 收款人常驻国家名称及代码
        /// </summary>
        public string Country
        {
            get { return string.Format("{0} {1}", m_nameOfCountry, m_codeOfCountry); }
        }
        private string m_openBankName;
        /// <summary>
        /// 收款人开户行名称
        /// </summary>
        public string OpenBankName
        {
            get { return m_openBankName; }
            set { m_openBankName = value; }
        }
        private string m_openBankAddress;
        /// <summary>
        /// 收款人开户行地址
        /// </summary>
        public string OpenBankAddress
        {
            get { return m_openBankAddress; }
            set { m_openBankAddress = value; }
        }
        private AccountBankType m_openBankType;
        /// <summary>
        /// 收款人开户行类型
        /// </summary>
        public AccountBankType OpenBankType
        {
            get { return m_openBankType; }
            set { m_openBankType = value; }
        }
        /// <summary>
        /// 收款人开户行类型
        /// </summary>
        public string OpenBankTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<AccountBankType>.GetEnumDescription(m_openBankType); }
                catch { m_openBankType = AccountBankType.Empty; }
                return result;
            }
        }
        private string m_correspondentBankName;
        /// <summary>
        /// 收款行之代理行名称
        /// </summary>
        public string CorrespondentBankName
        {
            get { return m_correspondentBankName; }
            set { m_correspondentBankName = value; }
        }
        private string m_correspondentBankAddress;
        /// <summary>
        /// 收款行之代理行地址
        /// </summary>
        public string CorrespondentBankAddress
        {
            get { return m_correspondentBankAddress; }
            set { m_correspondentBankAddress = value; }
        }
        private string m_AccountInCorrespondentBank;
        /// <summary>
        /// 收款人开户行在其代理行账号
        /// </summary>
        public string AccountInCorrespondentBank
        {
            get { return m_AccountInCorrespondentBank; }
            set { m_AccountInCorrespondentBank = value; }
        }
        private string m_fax;
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get { return m_fax; }
            set { m_fax = value; }
        }
        private string m_telephone;
        /// <summary>
        /// 手机号
        /// </summary>
        public string Telephone
        {
            get { return m_telephone; }
            set { m_telephone = value; }
        }
        private string m_email;
        /// <summary>
        /// email
        /// </summary>
        public string Email
        {
            get { return m_email; }
            set { m_email = value; }
        }
        public override string ToString()
        {
            return m_Account;
        }
    }
}
