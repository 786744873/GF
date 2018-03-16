using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    public class ElecTicketPool
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
        private string m_ErrorReason;
        /// <summary>
        /// 错误原因
        /// 供匹配错误文件使用
        /// </summary>
        public string ErrorReason
        {
            get { return m_ErrorReason; }
            set { m_ErrorReason = value; }
        }
        private ElecTicketType m_elecTicketType;
        /// <summary>
        /// 票据类型
        /// </summary>
        public ElecTicketType ElecTicketType
        {
            get { return m_elecTicketType; }
            set { m_elecTicketType = value; }
        }
        /// <summary>
        /// 票据类型
        /// </summary>
        public string ElecTicketTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<ElecTicketType>.GetEnumDescription(m_elecTicketType);
                }
                catch { }
                return result;
            }
        }
        private string m_customerRef;
        /// <summary>
        /// 票据自定义编号
        /// </summary>
        public string CustomerRef
        {
            get { return m_customerRef; }
            set { m_customerRef = value; }
        }
        private string m_elecTicketSerialNo;
        /// <summary>
        /// 票据号码
        /// </summary>
        public string ElecTicketSerialNo
        {
            get { return m_elecTicketSerialNo; }
            set { m_elecTicketSerialNo = value; }
        }
        private string m_remitDate;
        /// <summary>
        /// 出票日期
        /// </summary>
        public string RemitDate
        {
            get { return m_remitDate; }
            set { m_remitDate = value; }
        }
        private string m_exchangeData;
        /// <summary>
        /// 承兑日期
        /// </summary>
        public string ExchangeDate
        {
            get { return m_exchangeData; }
            set { m_exchangeData = value; }
        }
        private string m_endDate;
        /// <summary>
        /// 到期日期
        /// </summary>
        public string EndDate
        {
            get { return m_endDate; }
            set { m_endDate = value; }
        }
        private AccountBankType m_bankType;
        /// <summary>
        /// 承兑行
        /// </summary>
        public AccountBankType BankType
        {
            get { return m_bankType; }
            set { m_bankType = value; }
        }
        /// <summary>
        /// 承兑行
        /// </summary>
        public string BankTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<AccountBankType>.GetEnumDescription(m_bankType);
                }
                catch { }
                return result;
            }
        }
        private string m_amount;
        /// <summary>
        /// 票据金额
        /// </summary>
        public string Amount
        {
            get { return m_amount; }
            set { m_amount = value; }
        }
        private string m_remitAccount;
        /// <summary>
        /// 出票人账号
        /// </summary>
        public string RemitAccount
        {
            get { return m_remitAccount; }
            set { m_remitAccount = value; }
        }
        private string m_remitName;
        /// <summary>
        /// 出票人名称
        /// </summary>
        public string RemitName
        {
            get { return m_remitName; }
            set { m_remitName = value; }
        }
        private string m_exchangeName;
        /// <summary>
        /// 承兑行名称/承兑人名称
        /// </summary>
        public string ExchangeName
        {
            get { return m_exchangeName; }
            set { m_exchangeName = value; }
        }
        private string m_exchangeAccount;
        /// <summary>
        /// 承兑人账号
        /// </summary>
        public string ExchangeAccount
        {
            get { return m_exchangeAccount; }
            set { m_exchangeAccount = value; }
        }
        private string m_exchangeBankNo;
        /// <summary>
        /// 承兑行行号/承兑人开户行号
        /// </summary>
        public string ExchangeBankNo
        {
            get { return m_exchangeBankNo; }
            set { m_exchangeBankNo = value; }
        }
        private string m_exchangeBankName;
        /// <summary>
        /// 承兑人开户行名称
        /// </summary>
        public string ExchangeBankName
        {
            get { return m_exchangeBankName; }
            set { m_exchangeBankName = value; }
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
        private string m_payeeName;
        /// <summary>
        /// 收款人名称
        /// </summary>
        public string PayeeName
        {
            get { return m_payeeName; }
            set { m_payeeName = value; }
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
        /// 收款人开户行名称
        /// </summary>
        public string PayeeOpenBankNo
        {
            get { return m_payeeOpenBankNo; }
            set { m_payeeOpenBankNo = value; }
        }
        private string m_preBackNotedPerson;
        /// <summary>
        /// 前一收背书人
        /// </summary>
        public string PreBackNotedPerson
        {
            get { return m_preBackNotedPerson; }
            set { m_preBackNotedPerson = value; }
        }
        private EndDateOperateType m_EndDateOperate;
        /// <summary>
        /// 到期操作
        /// </summary>
        public EndDateOperateType EndDateOperate
        {
            get { return m_EndDateOperate; }
            set { m_EndDateOperate = value; }
        }
        /// <summary>
        /// 到期操作
        /// </summary>
        public string EndDateOperateString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<EndDateOperateType>.GetEnumDescription(m_EndDateOperate);
                }
                catch { }
                return result;
            }
        }
        private ElecTicketPoolBusinessType m_businessType;
        /// <summary>
        /// 业务种类
        /// </summary>
        public ElecTicketPoolBusinessType BusinessType
        {
            get { return m_businessType; }
            set { m_businessType = value; }
        }
        /// <summary>
        /// 业务种类
        /// </summary>
        public string BusinessTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<ElecTicketPoolBusinessType>.GetEnumDescription(m_businessType); }
                catch { }
                return result;
            }
        }
    }
}
