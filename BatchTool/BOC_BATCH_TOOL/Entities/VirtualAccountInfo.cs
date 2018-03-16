using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
   public class VirtualAccountInfo
    {
        private string m_account;
        /// <summary>
        /// 账号
        /// </summary>
        public string Account
        {
            get { return m_account; }
            set { m_account = value; }
        }
        private string m_name;
        /// <summary>
        /// 账户名称
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        private CashType m_cashtype;
        /// <summary>
        /// 货币类型
        /// </summary>
        public CashType CashType
        {
            get { return m_cashtype; }
            set { m_cashtype = value; }
        }
        /// <summary>
        /// 货币类型
        /// </summary>
        public string CashTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<CashType>.GetEnumDescription(m_cashtype); }
                catch { m_cashtype = EnumTypes.CashType.Empty; }
                return result;
            }
        }
        private string m_OpenBankName;
        /// <summary>
        /// 开户行
        /// </summary>
        public string OpenBankName
        {
            get { return m_OpenBankName; }
            set { m_OpenBankName = value; }
        }
        public override string ToString()
        {
            return m_account.ToString();
        }
    }
}
