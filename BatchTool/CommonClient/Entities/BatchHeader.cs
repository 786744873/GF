using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.Utilities;
using CommonClient.Controls;

namespace CommonClient.Entities
{
    [Serializable]
    public class BatchHeader : EntityBase
    {
        /// <summary>
        /// 付款人信息
        /// </summary>
        public PayerInfo Payer { get; set; }

        /// <summary>
        /// 协议号或者客户业务编号
        /// </summary>
        [DvValidatRule(CaseDescription = "客户业务编号", MinLength = 0, MaxLength = 16, RegCode = "Predefined5", Required = false)]
        [DvValidatRule(CaseDescription = "主动调拨 客户业务编号", MinLength = 0, MaxLength = 16, RegCode = "reg8", Required = false)]
        public string ProtecolNo { get; set; }

        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime TransferDatetime { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        public string UseType { get; set; }

        /// <summary>
        /// 附言
        /// </summary>
        [DvValidatRule(CaseDescription = "附言", MinLength = 0, MaxLength = 80, RegCode = "reg667", Required = false)]
        public string Addtion { get; set; }

        public AgentCardType CardType { get; set; }
        /// <summary>
        /// 普通-代发卡类型
        /// </summary>
        [DvValidatRuleAttribute(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string CardType_Normal
        {
            get
            {
                var result = string.Empty;
                if (CardType == AgentCardType.MemoryCard || CardType == AgentCardType.OtherBankCard || CardType == AgentCardType.QCCCard)
                    result = EnumNameHelper<AgentCardType>.GetEnumDescription(CardType);
                return result;
            }
        }

        /// <summary>
        /// 银行联行号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 5, MaxLength = 5, RegCode = "reg654", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 5, MaxLength = 5, RegCode = "reg654", Required = false)]
        public string BankNo { get; set; }

        /// <summary>
        /// 快捷-银行名称
        /// </summary>
        public string Bank { get; set; }

        public AgentTransferBankType BankType { get; set; }

        /// <summary>
        /// 是否添加付款人信息
        /// </summary>
        public bool CanAddPayer { get; set; }

        /// <summary>
        /// 是否添加附言
        /// </summary>
        public bool CanAddNotice { get; set; }

        /// <summary>
        /// 支付手续费账号
        /// </summary>
        public string PayFeeNo { get; set; }

        /// <summary>
        /// 快捷用途
        /// </summary>
        public AgentExpressFunctionType AgentFunctionType_Express { get; set; }

        public BatchHeader()
        {
            AgentFunctionType_Express = AgentExpressFunctionType.Empty;
            Payer = new PayerInfo();
        }
    }
}
