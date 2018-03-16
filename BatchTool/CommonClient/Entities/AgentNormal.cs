using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.Utilities;
using CommonClient.Controls;

namespace CommonClient.Entities
{
    [Serializable]
    public class AgentNormal : EntityBase, ICloneable
    {
        /// <summary>
        /// 行号
        /// 供匹配错误文件使用
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 错误原因
        /// 供匹配错误文件使用
        /// </summary>
        public string ErrorReason { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [DvValidatRule(CaseDescription = "普通代发", MinLength = 1, MaxLength = 14, RegCode = "reg43", Required = true)]
        [DvValidatRule(CaseDescription = "普通代发", MinLength = 1, MaxLength = 15, RegCode = "reg43", Required = true)]
        public string Amount { get; set; }

        /// <summary>
        /// 收（付）款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "普通代收", MinLength = 1, MaxLength = 30, RegCode = "Predefined5", Required = true)]
        [DvValidatRule(CaseDescription = "非普通代收", MinLength = 1, MaxLength = 20, RegCode = "Predefined5", Required = true)]
        public string AccountName { get; set; }

        /// <summary>
        /// 收（付）款人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "借记卡或者存折", MinLength = 1, MaxLength = 22, RegCode = "Predefined4", Required = true)]
        [DvValidatRule(CaseDescription = "QCC卡(QCC卡及信用卡)", MinLength = 1, MaxLength = 16, RegCode = "Predefined4", Required = true)]
        [DvValidatRule(CaseDescription = "他行卡", MinLength = 1, MaxLength = 35, RegCode = "Predefined4", Required = true)]
        public string AccountNo { get; set; }

        /// <summary>
        /// 联行号（或CNPAS行号）
        /// </summary>
        [DvValidatRule(CaseDescription = "他行卡", MinLength = 1, MaxLength = 70, RegCode = "reg667", Required = true)]
        [DvValidatRule(CaseDescription = "非他行卡", MinLength = 5, MaxLength = 5, RegCode = "reg654", Required = true)]
        public string BankNo { get; set; }

        /// <summary>
        /// 行名
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string BankName { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public AgentNormalCertifyPaperType CertifyPaperType;
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertifyPaperTypeString
        {
            get
            {
                var str = string.Empty;
                if (CertifyPaperType != AgentNormalCertifyPaperType.Empty)
                    str = EnumNameHelper<AgentNormalCertifyPaperType>.GetEnumDescription(CertifyPaperType);
                return str;
            }
        }

        /// <summary>
        /// 证件号码
        /// </summary>
        [DvValidatRule(CaseDescription = "身份证号码", MinLength = 15, MaxLength = 18, RegCode = "reg579", Required = true)]
        [DvValidatRule(CaseDescription = "其他号码", MinLength = 1, MaxLength = 32, RegCode = "Predefined5", Required = true)]
        public string CertifyPaperNo { get; set; }

        public AgentNormalFunctionType UseType { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public string UseTypeString
        {
            get
            {
                var str = string.Empty;
                if (UseType != AgentNormalFunctionType.Empty)
                    str = EnumNameHelper<AgentNormalFunctionType>.GetEnumDescription(UseType);
                return str;
            }
        }

        /// <summary>
        /// 用途
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string UseType_In { get; set; }

        /// <summary>
        /// 付款合同编号
        /// </summary>
        [DvValidatRule(CaseDescription = "付款合同编号", MinLength = 0, MaxLength = 60, RegCode = "Predefined5", Required = false)]
        public string ProtecolNo { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
