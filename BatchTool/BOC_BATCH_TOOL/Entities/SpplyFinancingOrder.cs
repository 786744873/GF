using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    public class SpplyFinancingOrder
    {
        private string m_OrderNo;
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo
        {
            get { return m_OrderNo; }
            set { m_OrderNo = value; }
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
        private string m_amount;
        /// <summary>
        /// 订单金额
        /// </summary>
        public string Amount
        {
            get { return m_amount; }
            set { m_amount = value; }
        }
        private string m_ERPCode;
        /// <summary>
        /// 卖方ERP代码
        /// </summary>
        public string ERPCode
        {
            get { return m_ERPCode; }
            set { m_ERPCode = value; }
        }
        private string m_CustomerApplyNo;
        /// <summary>
        /// 卖方银行客户号
        /// </summary>
        public string CustomerApplyNo
        {
            get { return m_CustomerApplyNo; }
            set { m_CustomerApplyNo = value; }
        }
        private string m_CustomerName;
        /// <summary>
        /// 买方客户名称
        /// </summary>
        public string CustomerName
        {
            get { return m_CustomerName; }
            set { m_CustomerName = value; }
        }
        private string m_payDate;
        /// <summary>
        /// 预计(买方)付款日期
        /// </summary>
        public string PayDate
        {
            get { return m_payDate; }
            set { m_payDate = value; }
        }
    }
}
