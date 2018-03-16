using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    public class InitiativeAllot
    {
        private int m_RowIndex;
        /// <summary>
        /// 行号
        /// 供匹配错误文件使用
        /// </summary>
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }
        /// <summary>
        /// 错误原因
        /// 供匹配错误文件使用
        /// </summary>
        public string ErrorReason
        {
            get { return m_ErrorReason; }
            set { m_ErrorReason = value; }
        }
        private string m_ErrorReason;

        private string m_AccountOut;
        /// <summary>
        /// 转出账户账号
        /// </summary>
        public string AccountOut
        {
            get { return m_AccountOut; }
            set { m_AccountOut = value; }
        }
        private string m_NameOut;
        /// <summary>
        /// 转出账户名称
        /// </summary>
        public string NameOut
        {
            get { return m_NameOut; }
            set { m_NameOut = value; }
        }
        private string m_AccountIn;
        /// <summary>
        /// 转入账户账号
        /// </summary>
        public string AccountIn
        {
            get { return m_AccountIn; }
            set { m_AccountIn = value; }
        }
        private string m_NameIn;
        /// <summary>
        /// 转入账户名称
        /// </summary>
        public string NameIn
        {
            get { return m_NameIn; }
            set { m_NameIn = value; }
        }
        private string m_Amount;
        /// <summary>
        /// 金额
        /// </summary>
        public string Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
        }
        private string m_addition;
        /// <summary>
        /// 附言
        /// </summary>
        public string Addition
        {
            get { return m_addition; }
            set { m_addition = value; }
        }
        private CashType m_CashType;
        /// <summary>
        /// 币种
        /// </summary>
        public CashType CashType
        {
            get { return m_CashType; }
            set { m_CashType = value; }
        }
        /// <summary>
        /// 币种
        /// </summary>
        public string CashTypeString
        {
            get
            {
                string str = string.Empty;
                try { str = EnumNameHelper<CashType>.GetEnumDescription(m_CashType); }
                catch { m_CashType = EnumTypes.CashType.Empty; }
                return str;
            }
        }
    }
}
