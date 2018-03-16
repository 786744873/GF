using System;
using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    [Serializable]
    public class TransferAccount : EntityBase, ICloneable
    {
        /// <summary>
        ///   收款人账号类型
        /// </summary>
        public AccountBankType AccountBankType = AccountBankType.Empty;

        /// <summary>
        ///   业务种类
        /// </summary>
        public BusinessType BusinessType { get; set; }

        /// <summary>
        ///   货币类型
        /// </summary>
        public CashType PayCashType { get; set; }

        /// <summary>
        ///   支付手续费账号
        /// </summary>
        public ChargingFeeAccountType PayFeeType { get; set; }

        /// <summary>
        ///   处理优先级
        /// </summary>
        public TransferChanelType TChanel { get; set; }

        /// <summary>
        ///   行号 供匹配错误文件使用
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        ///   客户业务编号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 16, RegCode = "Predefined5", Required = false)]
        public string CustomerRef { get; set; }

        /// <summary>
        ///   支付协议号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-In", MinLength = 1, MaxLength = 60, RegCode = "Predefined5", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 60, RegCode = "Predefined5", Required = false)]
        public string PayProtecolNo { get; set; }

        /// <summary>
        ///   付款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-IOC", MinLength = 1, MaxLength = 35, RegCode = "reg666", Required = true)]
        [DvValidatRule(CaseDescription = "Normal-Out", MinLength = 12, MaxLength = 18, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert-IOC", MinLength = 1, MaxLength = 35, RegCode = "reg666", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert-Out", MinLength = 12, MaxLength = 18, RegCode = "reg57", Required = false)]
        public string PayerAccount { get; set; }

        /// <summary>
        ///   付款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-In", MinLength = 0, MaxLength = 70, RegCode = "Predefined5", Required = true)]
        [DvValidatRule(CaseDescription = "Normal-Out", MinLength = 0, MaxLength = 76, RegCode = "Predefined5", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert-In", MinLength = 0, MaxLength = 70, RegCode = "Predefined5", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert-Out", MinLength = 0, MaxLength = 76, RegCode = "Predefined5", Required = false)]
        public string PayerName { get; set; }

        /// <summary>
        ///   货币类型（字符）
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
        ///   付款金额
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string PayAmount { get; set; }

        /// <summary>
        ///   收款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 76, RegCode = "reg685", Required = true)]
        [DvValidatRule(CaseDescription = "Normal-In", MinLength = 1, MaxLength = 70, RegCode = "reg685", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 76, RegCode = "reg685", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert-In", MinLength = 1, MaxLength = 70, RegCode = "reg685", Required = true)]
        public string PayeeName { get; set; }

        /// <summary>
        ///   收款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 35, RegCode = "Predefined4", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 35, RegCode = "Predefined4", Required = false)]
        public string PayeeAccount { get; set; }

        /// <summary>
        ///   收款人开户行
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 1, MaxLength = 70, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 70, RegCode = "reg667", Required = false)]
        public string PayeeOpenBank { get; set; }

        /// <summary>
        ///   收款清算行行号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 0, RegCode = "0", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 1, MaxLength = 18, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 18, RegCode = "reg57", Required = false)]
        public string PayBankNo { get; set; }

        /// <summary>
        ///   收款人地址
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        public string PayeeAddress { get; set; }

        /// <summary>
        ///   错误原因 供匹配错误文件使用
        /// </summary>
        public string ErrorReason { get; set; }

        /// <summary>
        ///   CNAPS行号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 0, RegCode = "0", Required = false)]
        [DvValidatRule(CaseDescription = "Normal-Other", MinLength = 1, MaxLength = 18, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 18, RegCode = "reg57", Required = false)]
        public string CNAPSNo { get; set; }

        /// <summary>
        ///   支付手续费账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal-IOC", MinLength = 1, MaxLength = 35, RegCode = "reg666", Required = true)]
        [DvValidatRule(CaseDescription = "Normal-Out", MinLength = 12, MaxLength = 18, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert-IOC", MinLength = 1, MaxLength = 35, RegCode = "reg666", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert-Out", MinLength = 12, MaxLength = 18, RegCode = "reg57", Required = false)]
        public string PayFeeNo { get; set; }

        /// <summary>
        ///   业务种类
        /// </summary>
        public string BusinessTypeString
        {
            get
            {
                string str = string.Empty;
                    if (BusinessType != BusinessType.Empty)
                        str = EnumNameHelper<BusinessType>.GetEnumDescription(BusinessType);
                return str;
            }
        }

        /// <summary>
        ///   指定付款日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string PayDatetime { get; set; }

        /// <summary>
        ///   用途
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 200, RegCode = "reg667", Required = false)]
        public string Addition { get; set; }

        /// <summary>
        ///   处理优先级
        /// </summary>
        public string TChanelString
        {
            get { return TransferChanelType.Normal == TChanel ? "普通" : "加急"; }
        }

        /// <summary>
        ///   电子邮箱
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 40, RegCode = "reg539", Required = false)]
        public string Email { get; set; }

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}