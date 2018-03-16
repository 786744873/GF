using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    [Serializable]
    public class AgentNormal : Object, ICloneable
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

        private string m_BankNo;
        /// <summary>
        /// 联行号（或CNPAS行号）
        /// </summary>
        public string BankNo
        {
            get { return m_BankNo; }
            set { m_BankNo = value; }
        }

        private string m_BankName;
        /// <summary>
        /// 行名
        /// </summary>
        public string BankName
        {
            get { return m_BankName; }
            set { m_BankName = value; }
        }
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
                string str = string.Empty; try
                {
                    if (CertifyPaperType != AgentNormalCertifyPaperType.Empty)
                        str = EnumNameHelper<AgentNormalCertifyPaperType>.GetEnumDescription(CertifyPaperType);
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

        private AgentNormalFunctionType m_UseType;

        public AgentNormalFunctionType UseType
        {
            get { return m_UseType; }
            set { m_UseType = value; }
        }
        /// <summary>
        /// 用途
        /// </summary>
        public string UseTypeString
        {
            get
            {
                string str = string.Empty;
                try
                {
                    if (m_UseType != AgentNormalFunctionType.Empty)
                        str = EnumNameHelper<AgentNormalFunctionType>.GetEnumDescription(m_UseType);
                }
                catch { }
                return str;
            }
        }

        private string m_UseType_In;
        /// <summary>
        /// 用途
        /// </summary>
        public string UseType_In
        {
            get { return m_UseType_In; }
            set { m_UseType_In = value; }
        }

        private string m_ProtecolNo;
        /// <summary>
        /// 付款合同编号
        /// </summary>
        public string ProtecolNo
        {
            get { return m_ProtecolNo; }
            set { m_ProtecolNo = value; }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
