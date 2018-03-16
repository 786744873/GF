using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    /// <summary>
    /// 批量出票信息类
    /// </summary>
    public class ElecTicketRemit
    {
        private int m_RowIndex;
        /// <summary>
        /// 操作记录行号
        /// </summary>
        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }
        private string m_ErrorReason;
        /// <summary>
        /// 错误原因
        /// </summary>
        public string ErrorReason
        {
            get { return m_ErrorReason; }
            set { m_ErrorReason = value; }
        }
        private ElecTicketType m_TicketType;
        /// <summary>
        /// 票据种类
        /// </summary>
        public ElecTicketType TicketType
        {
            get { return m_TicketType; }
            set { m_TicketType = value; }
        }
        /// <summary>
        /// 票据种类
        /// </summary>
        public string TicketTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    if (ElecTicketType.Empty != m_TicketType)
                        result = EnumNameHelper<ElecTicketType>.GetEnumDescription(m_TicketType);
                }
                catch { }
                return result;
            }
        }
        private string m_Amount;
        /// <summary>
        /// 票据金额
        /// </summary>
        public string Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
        }
        private string m_RemitDate;
        /// <summary>
        /// 出票日期
        /// </summary>
        public string RemitDate
        {
            get { return m_RemitDate; }
            set { m_RemitDate = value; }
        }
        private string m_EndDate;
        /// <summary>
        /// 票据到期日
        /// </summary>
        public string EndDate
        {
            get { return m_EndDate; }
            set { m_EndDate = value; }
        }
        private string m_RemitAccount;
        /// <summary>
        /// 出票人账号
        /// </summary>
        public string RemitAccount
        {
            get { return m_RemitAccount; }
            set { m_RemitAccount = value; }
        }
        private string m_ExchangeName;
        /// <summary>
        /// 承兑人名称
        /// </summary>
        public string ExchangeName
        {
            get { return m_ExchangeName; }
            set { m_ExchangeName = value; }
        }
        private string m_ExchangeAccount;
        /// <summary>
        /// 承兑人账号
        /// </summary>
        public string ExchangeAccount
        {
            get { return m_ExchangeAccount; }
            set { m_ExchangeAccount = value; }
        }
        private string m_ExchangeOpenBankName;
        /// <summary>
        /// 承兑人开户行名称
        /// </summary>
        public string ExchangeOpenBankName
        {
            get { return m_ExchangeOpenBankName; }
            set { m_ExchangeOpenBankName = value; }
        }
        private string m_ExchangeOpenBankNo;
        /// <summary>
        /// 承兑人开户行行号
        /// </summary>
        public string ExchangeOpenBankNo
        {
            get { return m_ExchangeOpenBankNo; }
            set { m_ExchangeOpenBankNo = value; }
        }
        private string m_PayeeName;
        /// <summary>
        /// 收款人名称
        /// </summary>
        public string PayeeName
        {
            get { return m_PayeeName; }
            set { m_PayeeName = value; }
        }
        private string m_payeeAccount;
        /// <summary>
        /// 收款人账号
        /// </summary>
        public string PayeeAccount
        {
            get { return m_payeeAccount; }
            set { m_payeeAccount = value; }
        }
        private string m_payeeOpenBankName;
        /// <summary>
        /// 收款人开户行名称
        /// </summary>
        public string PayeeOpenBankName
        {
            get { return m_payeeOpenBankName; }
            set { m_payeeOpenBankName = value; }
        }
        private string m_payeeOpenBankNo;
        /// <summary>
        /// 收款人开户行行号
        /// </summary>
        public string PayeeOpenBankNo
        {
            get { return m_payeeOpenBankNo; }
            set { m_payeeOpenBankNo = value; }
        }
        private CanChangeType m_CanChange;
        /// <summary>
        /// 可否转让
        /// </summary>
        public CanChangeType CanChange
        {
            get { return m_CanChange; }
            set { m_CanChange = value; }
        }
        /// <summary>
        /// 可否转让
        /// </summary>
        public string CanChangeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<CanChangeType>.GetEnumDescription(m_CanChange);
                }
                catch { m_CanChange = CanChangeType.Empty; }
                return result;
            }
        }
        private bool m_AutoTipExchange;
        /// <summary>
        /// 是否自动提示承兑
        /// </summary>
        public bool AutoTipExchange
        {
            get { return m_AutoTipExchange; }
            set { m_AutoTipExchange = value; }
        }
        /// <summary>
        /// 是否自动提示承兑
        /// </summary>
        public string AutoTipExchangeString
        {
            get { return m_AutoTipExchange ? "是" : "否"; }
        }
        private bool m_AutoTipReceiveTicket;
        /// <summary>
        /// 是否自动提示收票
        /// </summary>
        public bool AutoTipReceiveTicket
        {
            get { return m_AutoTipReceiveTicket; }
            set { m_AutoTipReceiveTicket = value; }
        }
        /// <summary>
        /// 是否自动提示收票
        /// </summary>
        public string AutoTipReceiveTicketString
        {
            get { return m_AutoTipReceiveTicket ? "是" : "否"; }
        }
        private string m_note;
        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            get { return m_note; }
            set { m_note = value; }
        }
    }
}
