using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    public class UnitivePaymentRMB
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
        private string m_PayerAccount;
        /// <summary>
        /// 实际付款人账号
        /// </summary>
        public string PayerAccount
        {
            get { return m_PayerAccount; }
            set { m_PayerAccount = value; }
        }
        private string m_PayerName;
        /// <summary>
        /// 实际付款人名称
        /// </summary>
        public string PayerName
        {
            get { return m_PayerName; }
            set { m_PayerName = value; }
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
        private AccountBankType m_BankType;
        /// <summary>
        /// 收款账户是否中行账户
        /// </summary>
        public AccountBankType BankType
        {
            get { return m_BankType; }
            set { m_BankType = value; }
        }
        public string BankTypeString
        {
            get
            {
                string str = string.Empty;
                if (m_BankType == AccountBankType.BocAccount)
                    str = EnumNameHelper<AccountBankType>.GetEnumDescription(m_BankType);
                else str = m_payeeOpenBankName;
                return str;
            }
        }
        private string m_payeeCNAPS;
        /// <summary>
        /// 收款行CNAPS号
        /// </summary>
        public string PayeeCNAPS
        {
            get { return m_payeeCNAPS; }
            set { m_payeeCNAPS = value; }
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
        private string m_nominalPayerAccount;
        /// <summary>
        /// 名义付款人账号
        /// </summary>
        public string NominalPayerAccount
        {
            get { return m_nominalPayerAccount; }
            set { m_nominalPayerAccount = value; }
        }
        private string m_nominalPayerName;
        /// <summary>
        /// 名义付款人名称
        /// </summary>
        public string NominalPayerName
        {
            get { return m_nominalPayerName; }
            set { m_nominalPayerName = value; }
        }
        private string m_nominalPayerBankLinkNo;
        /// <summary>
        /// 名义付款人联行号
        /// </summary>
        public string NominalPayerBankLinkNo
        {
            get { return m_nominalPayerBankLinkNo; }
            set { m_nominalPayerBankLinkNo = value; }
        }
        private string m_nominalPayerOpenBankName;
        /// <summary>
        /// 名义付款人开户行
        /// </summary>
        public string NominalPayerOpenBankName
        {
            get { return m_nominalPayerOpenBankName; }
            set { m_nominalPayerOpenBankName = value; }
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
        private UnitivePaymentType m_UnitivePaymentType = UnitivePaymentType.Empty;
        /// <summary>
        /// 付款方式
        /// </summary>
        public UnitivePaymentType UnitivePaymentType
        {
            get { return m_UnitivePaymentType; }
            set { m_UnitivePaymentType = value; }
        }
        public string UnitivePaymentTypeString
        {
            get
            {
                string str = string.Empty;
                try { str = EnumNameHelper<UnitivePaymentType>.GetEnumDescription(m_UnitivePaymentType); }
                catch { m_UnitivePaymentType = EnumTypes.UnitivePaymentType.Empty; }
                return str;
            }
        }
        private string m_OrderPayDate;
        /// <summary>
        /// 预约付款日期
        /// </summary>
        public string OrderPayDate
        {
            get { return m_OrderPayDate; }
            set { m_OrderPayDate = value; }
        }
        private string m_OrderPayTime;
        /// <summary>
        ///预约付款时间
        /// </summary>
        public string OrderPayTime
        {
            get { return m_OrderPayTime; }
            set { m_OrderPayTime = value; }
        }
        public string OrderPayDateTime
        {
            get { return m_OrderPayDate + " " + (string.IsNullOrEmpty(m_OrderPayTime) ? m_OrderPayTime : m_OrderPayTime + ":00"); }
        }
        private string m_CustomerBusinissNo;
        /// <summary>
        /// 客户业务编号
        /// </summary>
        public string CustomerBusinissNo
        {
            get { return m_CustomerBusinissNo; }
            set { m_CustomerBusinissNo = value; }
        }
        private TransferChanelType m_TransferChanelType;
        /// <summary>
        /// 处理优先级
        /// </summary>
        public TransferChanelType TransferChanelType
        {
            get { return m_TransferChanelType; }
            set { m_TransferChanelType = value; }
        }
        public string TransferChanelTypeString
        {
            get
            {
                string str = string.Empty;
                try { str = EnumNameHelper<TransferChanelType>.GetEnumDescription(m_TransferChanelType); }
                catch { m_TransferChanelType = EnumTypes.TransferChanelType.Normal; }
                return str;
            }
        }
        private bool m_IsTipPayee;
        /// <summary>
        /// 短信提醒收款人
        /// </summary>
        public bool IsTipPayee
        {
            get { return m_IsTipPayee; }
            set { m_IsTipPayee = value; }
        }
        public string IsTipPayeeString
        {
            get { return m_IsTipPayee ? "是" : "否"; }
        }
        private string m_TipPayeePhone;
        /// <summary>
        /// 短信提醒收款人手机号
        /// </summary>
        public string TipPayeePhone
        {
            get { return m_TipPayeePhone; }
            set { m_TipPayeePhone = value; }
        }
        private string m_purpose;
        /// <summary>
        /// 用途
        /// </summary>
        public string Purpose
        {
            get { return m_purpose; }
            set { m_purpose = value; }
        }
    }
}
