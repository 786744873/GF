using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    [Serializable]
    public class AgentExpress : Object, ICloneable
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
        /// <summary>
        /// 错误原因
        /// 供匹配错误文件使用
        /// </summary>
        public string ErrorReason
        {
            get { return m_ErrorReason; }
            set { m_ErrorReason = value; }
        }
        private string m_ErrorReason;
        private string m_Amount;
        /// <summary>
        /// 金额
        /// </summary>
        public string Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
        }

        private string m_AccountName;
        /// <summary>
        /// 收（付）款人名称
        /// </summary>
        public string AccountName
        {
            get { return m_AccountName; }
            set { m_AccountName = value; }
        }

        private string m_AccountNo;
        /// <summary>
        /// 收（付）款人账号
        /// </summary>
        public string AccountNo
        {
            get { return m_AccountNo; }
            set { m_AccountNo = value; }
        }
        /// <summary>
        /// 省份
        /// </summary>
        public ChinaProvinceType Province;
        /// <summary>
        /// 省份
        /// </summary>
        public string ProvinceString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (Province != ChinaProvinceType.B0)
                        str = EnumNameHelper<ChinaProvinceType>.GetEnumDescription(Province);
                }
                catch { }
                return str;
            }
        }
        /// <summary>
        /// 证件类型
        /// </summary>
        public AgentExpressCertifyPaperType CertifyPaperType;
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertifyPaperTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if ((int)CertifyPaperType > 0)
                        str = EnumNameHelper<AgentExpressCertifyPaperType>.GetEnumDescription(CertifyPaperType);
                }
                catch { }
                return str;
            }
        }

        private string m_CertifyPaperNo;
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertifyPaperNo
        {
            get { return m_CertifyPaperNo; }
            set { m_CertifyPaperNo = value; }
        }

        private string m_ProtecolNo;
        /// <summary>
        /// 协议号
        /// </summary>
        public string ProtecolNo
        {
            get { return m_ProtecolNo; }
            set { m_ProtecolNo = value; }
        }

        private string m_BankNo;
        /// <summary>
        /// 收（付）款行行号
        /// </summary>
        public string BankNo
        {
            get { return m_BankNo; }
            set { m_BankNo = value; }
        }

        private string m_BankName;
        /// <summary>
        /// 收（付）款人开户行
        /// </summary>
        public string BankName
        {
            get { return m_BankName; }
            set { m_BankName = value; }
        }

        private AgentExpressFunctionType m_UsageType = AgentExpressFunctionType.Empty;
        /// <summary>
        /// 用途
        /// </summary>
        public AgentExpressFunctionType UsageType
        {
            get { return m_UsageType; }
            set { m_UsageType = value; }
        }
        /// <summary>
        /// 用途
        /// </summary>
        public string UsageTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    if (m_UsageType != AgentExpressFunctionType.Empty)
                        result = EnumNameHelper<AgentExpressFunctionType>.GetEnumDescription(m_UsageType);
                }
                catch { m_UsageType = AgentExpressFunctionType.Empty; }
                return result;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
