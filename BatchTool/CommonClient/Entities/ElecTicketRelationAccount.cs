using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    public class ElecTicketRelationAccount : EntityBase
    {
        public int RowIndex { get; set; }
        /// <summary>
        ///   关系人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Name { get; set; }

        /// <summary>
        ///   关系人账号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Account { get; set; }

        /// <summary>
        ///   关系人开户行名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string OpenBankName { get; set; }

        /// <summary>
        ///   关系人开户行行号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string OpenBankNo { get; set; }

        /// <summary>
        ///   关系人属性
        /// </summary>
        public RelatePersonType PersonType { get; set; }

        /// <summary>
        ///   关系人属性
        /// </summary>
        public string PersonTypeString
        {
            get
            {
                string str = string.Empty;
                foreach (var item in PrequisiteDataProvideNode.InitialProvide.RelatePersonTypeList)
                {
                    if ((PersonType & item) == item)
                    {
                        if (!string.IsNullOrEmpty(str))
                            str += ",";
                        str += EnumNameHelper<RelatePersonType>.GetEnumDescription(item);
                    }
                }
                return str;
            }
        }

        /// <summary>
        ///   关系人编号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string SerialNo { get; set; }

        /// <summary>
        ///   关系人手机号1
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Tel_First { get; set; }

        /// <summary>
        ///   关系人手机号2
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Tel_Second { get; set; }

        /// <summary>
        ///   关系人Email1
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Email_First { get; set; }

        /// <summary>
        ///   关系人Email2
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Email_Second { get; set; }

        public override string ToString()
        {
            return Account.ToString();
        }
    }
}