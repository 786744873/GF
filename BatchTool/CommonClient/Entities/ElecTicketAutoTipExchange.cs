using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.Controls;

namespace CommonClient.Entities
{
    public class ElecTicketAutoTipExchange : EntityBase
    {
        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 错误原因
        /// </summary>
        public string ErrorReason { get; set; }

        /// <summary>
        /// 出票人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = false)]
        public string RemitAccount { get; set; }

        /// <summary>
        /// 票据号码
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 30, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 30, RegCode = "reg57", Required = false)]
        public string ElecTicketSerialNo { get; set; }

        /// <summary>
        /// 承兑人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = false)]
        public string ExchangeAccount { get; set; }

        /// <summary>
        /// 承兑人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string ExchangeName { get; set; }

        /// <summary>
        /// 承兑人开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string ExchangeOpenBankName { get; set; }

        /// <summary>
        /// 承兑人开户行行号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = false)]
        public string ExchangeOpenBankNo { get; set; }

        /// <summary>
        /// 发票号码
        /// </summary>
        [DvValidatRule(CaseDescription = "电票贴现，电票提示承兑", MinLength = 0, MaxLength = 60, RegCode = "reg57", Required = false)]
        public string BillSerialNo { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [DvValidatRule(CaseDescription = "电票贴现，电票提示承兑", MinLength = 0, MaxLength = 60, RegCode = "reg57", Required = false)]
        public string ContractNo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 512, RegCode = "reg667", Required = false)]
        public string Note { get; set; }
    }
}
