using System;
using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
   public class GovermentInfo
    {
        /// <summary>
        ///   行号 供匹配错误文件使用
        /// </summary>
        public int RowIndex { get; set; }
        /// <summary>
        ///   错误原因 供匹配错误文件使用
        /// </summary>
        public string ErrorReason { get; set; }
        /// <summary>
        ///   收款人账号类型
        /// </summary>
        public AccountBankType AccountBankType = AccountBankType.Empty;
        /// <summary>
        ///   付款金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string PayAmount { get; set; }

        /// <summary>
        ///   指定付款日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string PayDatetime { get; set; }

        /// <summary>
        ///   用途
        /// </summary>
       [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 200, RegCode = "reg667", Required = false)]
        public string Addition { get; set; }

        /// <summary>
        ///   客户业务编号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 16, RegCode = "Predefined5", Required = false)]
        public string CustomerRef { get; set; }

        /// <summary>
        ///   支付令编码
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 16, RegCode = "Predefined5", Required = false)]
        public string PayeeCode { get; set; }

        /// <summary>
        ///   海关凭单号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 16, RegCode = "Predefined5", Required = false)]
        public string OddNumber { get; set; }
        /// <summary>
        ///   付款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert-Out", MinLength = 12, MaxLength = 18, RegCode = "reg57", Required = false)]
        public string PayerAccount { get; set; }

        /// <summary>
        ///   收款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 35, RegCode = "Predefined4", Required = true)]
        public string PayeeAccount { get; set; }
        /// <summary>
        ///   收款人开户行
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        public string PayeeOpenBank { get; set; }
        /// <summary>
        ///   收款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 76, RegCode = "reg685", Required = true)]
        public string PayeeName { get; set; }

        /// <summary>
        ///   CNAPS行号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 0, RegCode = "0", Required = false)]
        public string CNAPSNo { get; set; }
    }
}
