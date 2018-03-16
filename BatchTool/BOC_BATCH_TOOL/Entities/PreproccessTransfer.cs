using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    public class PreproccessTransfer
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
        private string m_preproccessName;
        /// <summary>
        /// 待处理账户名称
        /// </summary>
        public string PreproccessName
        {
            get { return m_preproccessName; }
            set { m_preproccessName = value; }
        }
        private string m_preproccessAccount;
        /// <summary>
        /// 待处理账号
        /// </summary>
        public string PreproccessAccount
        {
            get { return m_preproccessAccount; }
            set { m_preproccessAccount = value; }
        }
        private string m_preproccessAmount;
        /// <summary>
        /// 待处理金额
        /// </summary>
        public string PreproccessAmount
        {
            get { return m_preproccessAmount; }
            set { m_preproccessAmount = value; }
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
        private string m_mainAccount;
        /// <summary>
        /// 主账户账号
        /// </summary>
        public string MainAccount
        {
            get { return m_mainAccount; }
            set { m_mainAccount = value; }
        }
        private string m_tradeSerialNo;
        /// <summary>
        /// 交易流水号
        /// </summary>
        public string TradeSerialNo
        {
            get { return m_tradeSerialNo; }
            set { m_tradeSerialNo = value; }
        }
        private string m_BatchTradeSerialNo;
        /// <summary>
        /// 交易流水子号
        /// </summary>
        public string BatchTradeSerialNo
        {
            get { return m_BatchTradeSerialNo; }
            set { m_BatchTradeSerialNo = value; }
        }
        private string m_InvolvedName;
        /// <summary>
        /// 对方账户名称
        /// </summary>
        public string InvolvedName
        {
            get { return m_InvolvedName; }
            set { m_InvolvedName = value; }
        }
        private string m_InvolvedAccount;
        /// <summary>
        /// 对方账号
        /// </summary>
        public string InvolvedAccount
        {
            get { return m_InvolvedAccount; }
            set { m_InvolvedAccount = value; }
        }
        private string m_TradeDate;
        /// <summary>
        /// 交易日期
        /// </summary>
        public string TradeDate
        {
            get { return m_TradeDate; }
            set { m_TradeDate = value; }
        }
        private string m_content;
        /// <summary>
        /// 摘要
        /// </summary>
        public string Content
        {
            get { return m_content; }
            set { m_content = value; }
        }
        private string m_virtualAccount;
        /// <summary>
        /// 虚拟账户账号
        /// </summary>
        public string VirtualAccount
        {
            get { return m_virtualAccount; }
            set { m_virtualAccount = value; }
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
    }
}
