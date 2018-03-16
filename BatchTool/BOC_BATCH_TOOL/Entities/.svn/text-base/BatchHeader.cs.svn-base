using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    [Serializable]
    public class BatchHeader
    {
        /// <summary>
        /// 付款人信息
        /// </summary>
        public PayerInfo Payer
        {
            get { return m_payer; }
            set { m_payer = value; }
        }
        private PayerInfo m_payer;
        private string m_protecolNo;
        /// <summary>
        /// 协议号或者客户业务编号
        /// </summary>
        public string ProtecolNo
        {
            get { return m_protecolNo; }
            set { m_protecolNo = value; }
        }
        private DateTime m_transferDatetime;
        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime TransferDatetime
        {
            get { return m_transferDatetime; }
            set { m_transferDatetime = value; }
        }
        private string m_useType;
        /// <summary>
        /// 用途
        /// </summary>
        public string UseType
        {
            get { return m_useType; }
            set { m_useType = value; }
        }
        private string m_addtion;
        /// <summary>
        /// 附言
        /// </summary>
        public string Addtion
        {
            get { return m_addtion; }
            set { m_addtion = value; }
        }
        public AgentCardType CardType { get; set; }
        private string m_cardType_Normal;
        /// <summary>
        /// 普通-代发卡类型
        /// </summary>
        public string CardType_Normal
        {
            get
            {
                m_cardType_Normal = string.Empty;
                try
                {
                    if (CardType == AgentCardType.MemoryCard
                        || CardType == AgentCardType.OtherBankCard
                        || CardType == AgentCardType.QCCCard)
                        m_cardType_Normal = EnumNameHelper<AgentCardType>.GetEnumDescription(CardType);
                }
                catch { }
                return m_cardType_Normal;
            }
        }
        private string m_bankNo;
        /// <summary>
        /// 银行联行号
        /// </summary>
        public string BankNo
        {
            get { return m_bankNo; }
            set { m_bankNo = value; }
        }
        private string m_bank;
        /// <summary>
        /// 快捷-银行名称
        /// </summary>
        public string Bank
        {
            get { return m_bank; }
            set { m_bank = value; }
        }
        public AgentTransferBankType BankType { get; set; }
        private bool m_canAddPayer;
        /// <summary>
        /// 是否添加付款人信息
        /// </summary>
        public bool CanAddPayer
        {
            get { return m_canAddPayer; }
            set { m_canAddPayer = value; }
        }
        private bool m_canAddNotice;
        /// <summary>
        /// 是否添加附言
        /// </summary>
        public bool CanAddNotice
        {
            get { return m_canAddNotice; }
            set { m_canAddNotice = value; }
        }
        private string m_payFeeNo;
        /// <summary>
        /// 支付手续费账号
        /// </summary>
        public string PayFeeNo
        {
            get { return m_payFeeNo; }
            set { m_payFeeNo = value; }
        }
        private AgentExpressFunctionType m_agentFunctionType_Express = AgentExpressFunctionType.Empty;
        /// <summary>
        /// 快捷用途
        /// </summary>
        public AgentExpressFunctionType AgentFunctionType_Express
        {
            get { return m_agentFunctionType_Express; }
            set { m_agentFunctionType_Express = value; }
        }

        public BatchHeader()
        {
            Payer = new PayerInfo();
        }
    }
}
