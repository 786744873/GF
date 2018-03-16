using System;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    [Serializable]
    public class AgentExpress : Object, ICloneable
    {
        /// <summary>
        ///   证件类型
        /// </summary>
        public AgentExpressCertifyPaperType CertifyPaperType;

        /// <summary>
        ///   省份
        /// </summary>
        public ChinaProvinceType Province;

        public AgentExpress()
        {
            UsageType = AgentExpressFunctionType.Empty;
        }

        /// <summary>
        ///   行号 供匹配错误文件使用
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        ///   错误原因 供匹配错误文件使用
        /// </summary>
        public string ErrorReason { get; set; }

        /// <summary>
        ///   金额
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        ///   收（付）款人名称
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        ///   收（付）款人账号
        /// </summary>
        public string AccountNo { get; set; }

        /// <summary>
        ///   省份
        /// </summary>
        public string ProvinceString
        {
            get
            {
                string str = string.Empty;
                if (Province != ChinaProvinceType.B0)
                    str = EnumNameHelper<ChinaProvinceType>.GetEnumDescription(Province);
                return str;
            }
        }

        /// <summary>
        ///   证件类型
        /// </summary>
        public string CertifyPaperTypeString
        {
            get
            {
                string str = string.Empty;
                if ((int)CertifyPaperType > 0)
                    str = EnumNameHelper<AgentExpressCertifyPaperType>.GetEnumDescription(CertifyPaperType);
                return str;
            }
        }

        /// <summary>
        ///   证件号码
        /// </summary>
        public string CertifyPaperNo { get; set; }

        /// <summary>
        ///   协议号
        /// </summary>
        public string ProtecolNo { get; set; }

        /// <summary>
        ///   收（付）款行行号
        /// </summary>
        public string BankNo { get; set; }

        /// <summary>
        ///   收（付）款人开户行
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        ///   用途
        /// </summary>
        public AgentExpressFunctionType UsageType { get; set; }

        /// <summary>
        ///   用途
        /// </summary>
        public string UsageTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    if (UsageType != AgentExpressFunctionType.Empty)
                        result = EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(UsageType);
                }
                catch
                {
                    UsageType = AgentExpressFunctionType.Empty;
                }
                return result;
            }
        }

        /// <summary>
        ///   柜台业务的附言
        /// </summary>
        public string Bar_Addition { get; set; }

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}