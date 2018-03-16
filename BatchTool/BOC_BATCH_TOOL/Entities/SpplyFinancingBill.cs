using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    public class SpplyFinancingBill
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
        private string m_contractNo;
        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNo
        {
            get { return m_contractNo; }
            set { m_contractNo = value; }
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
        private string m_amount;
        /// <summary>
        /// 发票金额
        /// </summary>
        public string Amount
        {
            get { return m_amount; }
            set { m_amount = value; }
        }
        private string m_billDate;
        /// <summary>
        /// 发票日期
        /// </summary>
        public string BillDate
        {
            get { return m_billDate; }
            set { m_billDate = value; }
        }
        private string m_startDate;
        /// <summary>
        /// 起算日
        /// </summary>
        public string StartDate
        {
            get { return m_startDate; }
            set { m_startDate = value; }
        }
        private string m_endDate;
        /// <summary>
        /// 到期日
        /// </summary>
        public string EndDate
        {
            get { return m_endDate; }
            set { m_endDate = value; }
        }
    }
}
