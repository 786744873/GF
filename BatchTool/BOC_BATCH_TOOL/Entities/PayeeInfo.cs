using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    /// <summary>
    /// 收款人名册类
    /// </summary>
    [Serializable]
    public class PayeeInfo : Object, ICloneable
    {
        public PayeeInfo()
        { }
        /// <summary>
        /// 收款人编号
        /// </summary>
        public string SerialNo
        {
            get { return m_SerialNo; }
            set { m_SerialNo = value; }
        }
        private string m_SerialNo;
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
        /// <summary>
        /// 是否中行
        /// </summary>
        public AccountBankType BankType;
        /// <summary>
        /// 收款人账户类型
        /// </summary>
        public AccountCategoryType AccountType;
        /// <summary>
        /// 收款人账户类型
        /// </summary>
        public string AccountTypeString
        {
            get
            {
                return AccountCategoryType.Empty == AccountType ? string.Empty : (AccountCategoryType.Corperation == AccountType ? "对公" : "对私");
            }
        }
        private string m_OpenBankName;
        /// <summary>
        /// 开户行名称
        /// </summary>
        public string OpenBankName
        {
            get { return m_OpenBankName; }
            set { m_OpenBankName = value; }
        }
        private string m_CNAPSNo;
        /// <summary>
        /// CNAPS行号（开户）
        /// </summary>
        public string CNAPSNo
        {
            get { return m_CNAPSNo; }
            set { m_CNAPSNo = value; }
        }
        /// <summary>
        /// 开户行全名
        /// </summary>
        public string FullBankName
        {
            get
            {
                return OpenBankName + "-" + CNAPSNo;
            }
        }
        private string m_ClearBankName;
        /// <summary>
        /// 清算行名称
        /// </summary>
        public string ClearBankName
        {
            get { return m_ClearBankName; }
            set { m_ClearBankName = value; }
        }
        private string m_CNAPANoR;
        /// <summary>
        /// CNAPS行号（清算）
        /// </summary>
        public string CNAPSNoR
        {
            get { return m_CNAPANoR; }
            set { m_CNAPANoR = value; }
        }
        /// <summary>
        /// 清算行全名
        /// </summary>
        public string FullBankNameR
        {
            get
            {
                return ClearBankName + "-" + CNAPSNoR;
            }
        }
        private string m_Address;
        /// <summary>
        /// 收款人地址
        /// </summary>
        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }
        private string m_Email;
        /// <summary>
        /// 收款人e-mail
        /// </summary>
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }
        private string m_Telephone;
        /// <summary>
        /// 收款人手机号
        /// </summary>
        public string Telephone
        {
            get { return m_Telephone; }
            set { m_Telephone = value; }
        }
        private string m_Fax;
        /// <summary>
        /// 收款人传真号
        /// </summary>
        public string Fax
        {
            get { return m_Fax; }
            set { m_Fax = value; }
        }
        public AgentExpressCertifyPaperType CertifyPaperType { get; set; }
        public string CertifyPaperTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (CertifyPaperType != EnumTypes.AgentExpressCertifyPaperType.Empty)
                        str = EnumNameHelper<AgentExpressCertifyPaperType>.GetEnumDescription(CertifyPaperType);
                }
                catch { }
                return str;
            }
        }
        public string CertifyPaperNo { get; set; }
        public string AccountBankTypeString
        {
            get
            {
                string str = string.Empty;
                if (BankType != EnumTypes.AccountBankType.Empty)
                {
                    try { str = EnumNameHelper<AccountBankType>.GetEnumDescription(BankType); }
                    catch { }
                }
                return str;
            }
        }
        private string m_protecolNo;
        /// <summary>
        /// 协议号
        /// </summary>
        public string ProtecolNo
        {
            get { return m_protecolNo; }
            set { m_protecolNo = value; }
        }

        public override string ToString()
        {
            return m_Account;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
