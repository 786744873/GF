using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    public class ElecTicketPayMoney
    {
        private int m_rowIndex;
        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex
        {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
        private string m_errorReason;
        /// <summary>
        /// 错误原因
        /// </summary>
        public string ErrorReason
        {
            get { return m_errorReason; }
            set { m_errorReason = value; }
        }
        private string m_remitAccount;
        /// <summary>
        /// 出票账号
        /// </summary>
        public string RemitAccount
        {
            get { return m_remitAccount; }
            set { m_remitAccount = value; }
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
        private string m_payMoneyType;
        /// <summary>
        /// 贴现种类
        /// </summary>
        public string PayMoneyType
        {
            get { return m_payMoneyType; }
            set { m_payMoneyType = value; }
        }
        private ClearMoneyType m_clearType;
        /// <summary>
        /// 清算方式
        /// </summary>
        public ClearMoneyType ClearType
        {
            get { return m_clearType; }
            set { m_clearType = value; }
        }
        /// <summary>
        /// 清算方式
        /// </summary>
        public string ClearTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<ClearMoneyType>.GetEnumDescription(m_clearType); }
                catch { m_clearType = ClearMoneyType.Empty; }
                return result;
            }
        }
        private string m_payMoneyDate;
        /// <summary>
        /// 贴现日期
        /// </summary>
        public string PayMoneyDate
        {
            get { return m_payMoneyDate; }
            set { m_payMoneyDate = value; }
        }
        private double m_payMoneyPercent;
        /// <summary>
        /// 贴现利率
        /// </summary>
        public double PayMoneyPercent
        {
            get { return m_payMoneyPercent; }
            set { m_payMoneyPercent = value; }
        }
        /// <summary>
        /// 贴现利率
        /// </summary>
        public string PayMoneyPercentString
        {
            get
            {
                string result = string.Empty;
                if (m_payMoneyPercent != 0.0d)
                    result = string.Format("{0}%", (m_payMoneyPercent * 100).ToString("0.0000"));
                return result;
            }
        }
        private string m_PayMoneyAccount;
        /// <summary>
        /// 贴现入账账号
        /// </summary>
        public string PayMoneyAccount
        {
            get { return m_PayMoneyAccount; }
            set { m_PayMoneyAccount = value; }
        }
        private string m_payMoneyOpenBankName;
        /// <summary>
        /// 贴现入账账号开户行名称
        /// </summary>
        public string PayMoneyOpenBankName
        {
            get { return m_payMoneyOpenBankName; }
            set { m_payMoneyOpenBankName = value; }
        }
        private string m_payMoneyOpenBankNo;
        /// <summary>
        /// 贴现入账行号
        /// </summary>
        public string PayMoneyOpenBankNo
        {
            get { return m_payMoneyOpenBankNo; }
            set { m_payMoneyOpenBankNo = value; }
        }
        private string m_StickOnAccount;
        /// <summary>
        /// 贴入人账号
        /// </summary>
        public string StickOnAccount
        {
            get { return m_StickOnAccount; }
            set { m_StickOnAccount = value; }
        }
        private string m_stickOnName;
        /// <summary>
        /// 贴入人名称
        /// </summary>
        public string StickOnName
        {
            get { return m_stickOnName; }
            set { m_stickOnName = value; }
        }
        private string m_stickOnOpenBankName;
        /// <summary>
        /// 贴入人开户行名称
        /// </summary>
        public string StickOnOpenBankName
        {
            get { return m_stickOnOpenBankName; }
            set { m_stickOnOpenBankName = value; }
        }
        private string m_stickOnOpenBankNo;
        /// <summary>
        /// 贴入人开户行行号
        /// </summary>
        public string StickOnOpenBankNo
        {
            get { return m_stickOnOpenBankNo; }
            set { m_stickOnOpenBankNo = value; }
        }
        private string m_billSerialNo;
        /// <summary>
        /// 发票号码
        /// </summary>
        public string BillSerialNo
        {
            get { return m_billSerialNo; }
            set { m_billSerialNo = value; }
        }
        private string m_contractNo;
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNo
        {
            get { return m_contractNo; }
            set { m_contractNo = value; }
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
        private ProtocolMoneyType m_protocolMoneyType;
        /// <summary>
        /// 付息方式
        /// </summary>
        public ProtocolMoneyType ProtocolMoneyType
        {
            get { return m_protocolMoneyType; }
            set { m_protocolMoneyType = value; }
        }
        /// <summary>
        /// 实收金额是否包含协议付息利息
        /// </summary>
        public string ProtocolMoneyTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<ProtocolMoneyType>.GetEnumDescription(m_protocolMoneyType); }
                catch { }
                return result;
            }
        }
        private double m_protocolMoneyPercent;
        /// <summary>
        /// 协议付息比例
        /// </summary>
        public double ProtocolMoneyPercent
        {
            get { return m_protocolMoneyPercent; }
            set { m_protocolMoneyPercent = value; }
        }
        /// <summary>
        /// 协议付息比例
        /// </summary>
        public string ProtocolMoneyPercentString
        {
            get
            {
                string result = string.Empty;
                if (m_protocolMoneyPercent != 0.0d)
                    result = string.Format("{0}%", m_protocolMoneyPercent.ToString("0.0"));
                return result;
            }
        }
    }
}
