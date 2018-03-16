using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    public class SpplyFinancingApply
    {
        private string m_contractOrOrderNo;
        /// <summary>
        /// 合同/订单号 
        /// </summary>
        public string ContractOrOrderNo
        {
            get { return m_contractOrOrderNo; }
            set { m_contractOrOrderNo = value; }
        }
        private string m_orderDate;
        /// <summary>
        /// 订单日期
        /// </summary>
        public string OrderDate
        {
            get { return m_orderDate; }
            set { m_orderDate = value; }
        }
        private CashType m_contractOrOrderCashType;
        /// <summary>
        /// 合同/订单币种
        /// </summary>
        public CashType ContractOrOrderCashType
        {
            get { return m_contractOrOrderCashType; }
            set { m_contractOrOrderCashType = value; }
        }
        /// <summary>
        /// 合同/订单币种
        /// </summary>
        public string ContractOrOrderCashTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<CashType>.GetEnumDescription(m_contractOrOrderCashType); }
                catch { m_contractOrOrderCashType = CashType.Empty; }
                return result;
            }
        }
        private string m_contractOrOrderAmount;
        /// <summary>
        /// 合同/订单金额
        /// </summary>
        public string ContractOrOrderAmount
        {
            get { return m_contractOrOrderAmount; }
            set { m_contractOrOrderAmount = value; }
        }
        private string m_deliveryDate;
        /// <summary>
        /// 发货日期
        /// </summary>
        public string DeliveryDate
        {
            get { return m_deliveryDate; }
            set { m_deliveryDate = value; }
        }
        private SettlementType m_settlementType;
        public SettlementType SettlementType
        {
            get { return m_settlementType; }
            set { m_settlementType = value; }
        }
        /// <summary>
        /// 结算方式
        /// </summary>
        public string SettlementTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<SettlementType>.GetEnumDescription(m_settlementType); }
                catch { m_settlementType = EnumTypes.SettlementType.Empty; }
                return result;
            }
        }
        private string m_taxInvoiceNo;
        /// <summary>
        /// 税务发票号
        /// </summary>
        public string TaxInvoiceNo
        {
            get { return m_taxInvoiceNo; }
            set { m_taxInvoiceNo = value; }
        }
        private string m_receiptNo;
        /// <summary>
        /// 收货单号
        /// </summary>
        public string ReceiptNo
        {
            get { return m_receiptNo; }
            set { m_receiptNo = value; }
        }
        private string m_riskTakingLetterNo;
        /// <summary>
        /// 风险承担函号
        /// </summary>
        public string RiskTakingLetterNo
        {
            get { return m_riskTakingLetterNo; }
            set { m_riskTakingLetterNo = value; }
        }
        private string m_goodsDesc;
        /// <summary>
        /// 货物描述
        /// </summary>
        public string GoodsDesc
        {
            get { return m_goodsDesc; }
            set { m_goodsDesc = value; }
        }
        private string m_ApplyAmount;
        /// <summary>
        /// 融资申请金额
        /// </summary>
        public string ApplyAmount
        {
            get { return m_ApplyAmount; }
            set { m_ApplyAmount = value; }
        }
        private int m_applyDays;
        /// <summary>
        /// 申请融资天数
        /// </summary>
        public int ApplyDays
        {
            get { return m_applyDays; }
            set { m_applyDays = value; }
        }
        private string m_agrementNo;
        /// <summary>
        /// 协议文本编号
        /// </summary>
        public string AgreementNo
        {
            get { return m_agrementNo; }
            set { m_agrementNo = value; }
        }
        private InterestFloatType m_InterestFloatType;
        /// <summary>
        /// 利率浮动方式
        /// </summary>
        public InterestFloatType InterestFloatType
        {
            get { return m_InterestFloatType; }
            set { m_InterestFloatType = value; }
        }
        /// <summary>
        /// 利率浮动方式
        /// </summary>
        public string InterestFloatTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<InterestFloatType>.GetEnumDescription(m_InterestFloatType); }
                catch { m_InterestFloatType = EnumTypes.InterestFloatType.Empty; }
                return result;
            }
        }
        private string m_interestFloatingPercent;
        /// <summary>
        /// 利率浮动比例
        /// </summary>
        public string InterestFloatingPercent
        {
            get { return m_interestFloatingPercent; }
            set { m_interestFloatingPercent = value; }
        }
    }
}
