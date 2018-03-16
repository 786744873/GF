using CommonClient.Controls;

namespace CommonClient.Entities
{
    public class InitiativeAllotAccount : EntityBase
    {
        public int RowIndex { get; set; }
        /// <summary>
        ///   账号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Account { get; set; }

        /// <summary>
        ///   名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Name { get; set; }

        public override string ToString()
        {
            return Account.ToString();
        }
    }
}