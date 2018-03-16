using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using CommonClient.Controls;

namespace CommonClient.Entities
{
    [Serializable]
    public class BankInfo : EntityBase
    {
        [DvValidatRuleAttribute(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string BankName { get; set; }

        [DvValidatRuleAttribute(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string LinkID { get; set; }
    }
}
