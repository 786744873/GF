using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    [Serializable]
    public class TransferAccount : Object, ICloneable
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

        private string m_CustomerRef;
        /// <summary>
        /// 客户业务编号
        /// </summary>
        public string CustomerRef
        {
            get { return m_CustomerRef; }
            set { m_CustomerRef = value; }
        }

        private string m_PayProtecolNo;
        /// <summary>
        /// 支付协议号
        /// </summary>
        public string PayProtecolNo
        {
            get { return m_PayProtecolNo; }
            set { m_PayProtecolNo = value; }
        }

        private string m_PayerAccount;
        /// <summary>
        /// 付款人账号
        /// </summary>
        public string PayerAccount
        {
            get { return m_PayerAccount; }
            set { m_PayerAccount = value; }
        }

        private string m_PayerName;
        /// <summary>
        /// 付款人名称
        /// </summary>
        public string PayerName
        {
            get { return m_PayerName; }
            set { m_PayerName = value; }
        }
        /// <summary>
        /// 货币类型（字符）
        /// </summary>
        public string PayingCurr
        {
            get
            {
                string str = "人民币";
                //switch (PayCashType)
                //{
                //    case CashType.CNY: str = "￥"; break;
                //    case CashType.EUR: str = "€"; break;
                //    case CashType.Dollar: str = "$"; break;
                //}
                return str;
            }
        }
        /// <summary>
        /// 货币类型
        /// </summary>
        public CashType PayCashType;

        private string m_PayAmount;
        /// <summary>
        /// 付款金额
        /// </summary>
        public string PayAmount
        {
            get { return m_PayAmount; }
            set { m_PayAmount = value; }
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

        private string m_PayeeAccount;
        /// <summary>
        /// 收款人账号
        /// </summary>
        public string PayeeAccount
        {
            get { return m_PayeeAccount; }
            set { m_PayeeAccount = value; }
        }

        private string m_PayeeOpenBank;
        /// <summary>
        /// 收款人开户行
        /// </summary>
        public string PayeeOpenBank
        {
            get { return m_PayeeOpenBank; }
            set { m_PayeeOpenBank = value; }
        }

        private string m_PayBankNo;
        /// <summary>
        /// 收款清算行行号
        /// </summary>
        public string PayBankNo
        {
            get { return m_PayBankNo; }
            set { m_PayBankNo = value; }
        }

        private string m_PayeeAddress;
        /// <summary>
        /// 收款人地址
        /// </summary>
        public string PayeeAddress
        {
            get { return m_PayeeAddress; }
            set { m_PayeeAddress = value; }
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

        private string m_CNAPSNo;
        /// <summary>
        /// CNAPS行号
        /// </summary>
        public string CNAPSNo
        {
            get { return m_CNAPSNo; }
            set { m_CNAPSNo = value; }
        }
        /// <summary>
        /// 支付手续费账号
        /// </summary>
        public ChargingFeeAccountType PayFeeType;

        private string m_PayFeeNo;
        /// <summary>
        /// 支付手续费账号
        /// </summary>
        public string PayFeeNo
        {
            get { return m_PayFeeNo; }
            set { m_PayFeeNo = value; }
        }
        /// <summary>
        /// 业务种类
        /// </summary>
        public BusinessType BusinessType;
        /// <summary>
        /// 业务种类
        /// </summary>
        public string BusinessTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (BusinessType != EnumTypes.BusinessType.Empty)
                        str = EnumNameHelper<BusinessType>.GetEnumDescription(BusinessType);
                }
                catch { }
                return str;
            }
        }

        private string m_PayDatetime;
        /// <summary>
        /// 指定付款日期
        /// </summary>
        public string PayDatetime
        {
            get { return m_PayDatetime; }
            set { m_PayDatetime = value; }
        }

        private string m_Addition;
        /// <summary>
        /// 用途
        /// </summary>
        public string Addition
        {
            get { return m_Addition; }
            set { m_Addition = value; }
        }
        /// <summary>
        /// 处理优先级
        /// </summary>
        public TransferChanelType TChanel;
        /// <summary>
        /// 处理优先级
        /// </summary>
        public string TChanelString
        {
            get
            {
                return TransferChanelType.Normal == TChanel ? "普通" : "加急";
            }
        }
        /// <summary>
        /// 收款人账号类型
        /// </summary>
        public AccountBankType AccountBankType = AccountBankType.Empty;

        private string m_Email;
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

}
