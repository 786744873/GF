using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    public class SpplyFinancingPayOrReceipt
    {
        private string m_billSerialNo;
        /// <summary>
        /// 发票号
        /// </summary>
        public string BillSerialNo
        {
            get { return m_billSerialNo; }
            set { m_billSerialNo = value; }
        }
        private string m_customerNo;
        /// <summary>
        /// 卖/买方客户号
        /// </summary>
        public string CustomerNo
        {
            get { return m_customerNo; }
            set { m_customerNo = value; }
        }
        private string m_customerName;
        /// <summary>
        /// 卖/买方客户名称
        /// </summary>
        public string CustomerName
        {
            get { return m_customerName; }
            set { m_customerName = value; }
        }
        private CashType m_cashType;
        /// <summary>
        /// 订单币别
        /// </summary>
        public CashType CashType
        {
            get { return m_cashType; }
            set { m_cashType = value; }
        }
        /// <summary>
        /// 订单币别
        /// </summary>
        public string CashTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<CashType>.GetEnumDescription(m_cashType); }
                catch { m_cashType = EnumTypes.CashType.Empty; }
                return result;
            }
        }
        private string m_payAmountForThisTime;
        /// <summary>
        /// 本次收/付款金额
        /// </summary>
        public string PayAmountForThisTime
        {
            get { return m_payAmountForThisTime; }
            set { m_payAmountForThisTime = value; }
        }
    }
}
