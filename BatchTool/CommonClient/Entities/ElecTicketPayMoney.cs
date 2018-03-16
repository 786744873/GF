using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class ElecTicketPayMoney : EntityBase
    {
        /// <summary>
        ///   行号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        ///   错误原因
        /// </summary>
        public string ErrorReason { get; set; }

        /// <summary>
        ///   出票账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = false)]
        public string RemitAccount { get; set; }

        /// <summary>
        ///   票据号码
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 30, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 30, RegCode = "reg57", Required = false)]
        public string ElecTicketSerialNo { get; set; }

        /// <summary>
        ///   贴现种类
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "", Required = false)]
        public string PayMoneyType { get; set; }

        /// <summary>
        ///   清算方式
        /// </summary>
        public ClearMoneyType ClearType { get; set; }

        /// <summary>
        ///   清算方式
        /// </summary>
        public string ClearTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<ClearMoneyType>.GetEnumDescription(ClearType);
                }
                catch
                {
                    ClearType = ClearMoneyType.Empty;
                }
                return result;
            }
        }

        /// <summary>
        ///   贴现日期
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string PayMoneyDate { get; set; }

        /// <summary>
        ///   贴现利率
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public double PayMoneyPercent { get; set; }

        /// <summary>
        ///   贴现利率
        /// </summary>
        public string PayMoneyPercentString
        {
            get
            {
                string result = string.Empty;
                if (PayMoneyPercent != 0.0d)
                    result = string.Format("{0}%", (PayMoneyPercent * 100).ToString("0.0000"));
                return result;
            }
        }

        /// <summary>
        ///   贴现入账账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = false)]
        public string PayMoneyAccount { get; set; }

        /// <summary>
        ///   贴现入账账号开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string PayMoneyOpenBankName { get; set; }

        /// <summary>
        ///   贴现入账行号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = false)]
        public string PayMoneyOpenBankNo { get; set; }

        /// <summary>
        ///   贴入人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 32, RegCode = "reg629", Required = false)]
        public string StickOnAccount { get; set; }

        /// <summary>
        ///   贴入人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string StickOnName { get; set; }

        /// <summary>
        ///   贴入人开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 120, RegCode = "reg667", Required = false)]
        public string StickOnOpenBankName { get; set; }

        /// <summary>
        ///   贴入人开户行行号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 12, MaxLength = 12, RegCode = "reg57", Required = false)]
        public string StickOnOpenBankNo { get; set; }

        /// <summary>
        ///   发票号码
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 60, RegCode = "reg57", Required = false)]
        public string BillSerialNo { get; set; }

        /// <summary>
        ///   合同编号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 60, RegCode = "reg57", Required = false)]
        public string ContractNo { get; set; }

        /// <summary>
        ///   备注
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 512, RegCode = "reg667", Required = false)]
        public string Note { get; set; }

        /// <summary>
        ///   付息方式
        /// </summary>
        public ProtocolMoneyType ProtocolMoneyType { get; set; }

        /// <summary>
        ///   实收金额是否包含协议付息利息
        /// </summary>
        public string ProtocolMoneyTypeString
        {
            get
            {
                var result = string.Empty;
                result = EnumNameHelper<ProtocolMoneyType>.GetEnumDescription(ProtocolMoneyType);
                return result;
            }
        }

        /// <summary>
        ///   协议付息比例
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public double ProtocolMoneyPercent { get; set; }

        /// <summary>
        ///   协议付息比例
        /// </summary>
        public string ProtocolMoneyPercentString
        {
            get
            {
                string result = string.Empty;
                if (ProtocolMoneyPercent != 0.0d)
                    result = string.Format("{0}%", ProtocolMoneyPercent.ToString("0.0"));
                return result;
            }
        }
    }
}