using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    public class ElecTicketRelationAccount
    {
        private string m_PersonName;
        /// <summary>
        /// 关系人名称
        /// </summary>
        public string Name
        {
            get { return m_PersonName; }
            set { m_PersonName = value; }
        }
        private string m_PersonAccount;
        /// <summary>
        /// 关系人账号
        /// </summary>
        public string Account
        {
            get { return m_PersonAccount; }
            set { m_PersonAccount = value; }
        }
        private string m_OpenBankName;
        /// <summary>
        /// 关系人开户行名称
        /// </summary>
        public string OpenBankName
        {
            get { return m_OpenBankName; }
            set { m_OpenBankName = value; }
        }
        private string m_OpenBankNo;
        /// <summary>
        /// 关系人开户行行号
        /// </summary>
        public string OpenBankNo
        {
            get { return m_OpenBankNo; }
            set { m_OpenBankNo = value; }
        }
        private RelatePersonType m_personType;
        /// <summary>
        /// 关系人属性
        /// </summary>
        public RelatePersonType PersonType
        {
            get { return m_personType; }
            set { m_personType = value; }
        }
        /// <summary>
        /// 关系人属性
        /// </summary>
        public string PersonTypeString
        {
            get
            {
                string str = string.Empty;
                foreach (var item in PrequisiteDataProvideNode.InitialProvide.RelatePersonTypeList)
                {
                    if ((m_personType & item) == item)
                    {
                        if (!string.IsNullOrEmpty(str)) str += ",";
                        str += EnumNameHelper<RelatePersonType>.GetEnumDescription(item);
                    }
                }
                return str;
            }
        }
        private string m_SerialNo;
        /// <summary>
        /// 关系人编号
        /// </summary>
        public string SerialNo
        {
            get { return m_SerialNo; }
            set { m_SerialNo = value; }
        }
        private string m_TelFirst;
        /// <summary>
        /// 关系人手机号1
        /// </summary>
        public string Tel_First
        {
            get { return m_TelFirst; }
            set { m_TelFirst = value; }
        }
        private string m_Tel_Second;
        /// <summary>
        /// 关系人手机号2
        /// </summary>
        public string Tel_Second
        {
            get { return m_Tel_Second; }
            set { m_Tel_Second = value; }
        }
        private string m_Email_First;
        /// <summary>
        /// 关系人Email1
        /// </summary>
        public string Email_First
        {
            get { return m_Email_First; }
            set { m_Email_First = value; }
        }
        private string m_Email_Second;
        /// <summary>
        /// 关系人Email2
        /// </summary>
        public string Email_Second
        {
            get { return m_Email_Second; }
            set { m_Email_Second = value; }
        }

        public override string ToString()
        {
            return m_PersonAccount.ToString();
        }
    }
}
