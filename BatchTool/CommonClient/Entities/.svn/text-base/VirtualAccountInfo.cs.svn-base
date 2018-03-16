using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.Utilities;
using CommonClient.Controls;

namespace CommonClient.Entities
{
    public class VirtualAccountInfo : EntityBase
    {
        public int RowIndex { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        [DvValidatRule(CaseDescription = "Normal", MinLength = 1, MaxLength = 35, RegCode = "reg629", Required = true)]
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 1, MaxLength = 35, RegCode = "reg629", Required = false)]
        public string Account { get; set; }

        /// <summary>
        /// 账户名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 120, RegCode = "reg585", Required = false)]
        public string Name { get; set; }

        /// <summary>
        /// 货币类型
        /// </summary>
        public CashType CashType { get; set; }

        /// <summary>
        /// 货币类型
        /// </summary>
        public string CashTypeString
        {
            get
            {
                var result = string.Empty;
                try
                {
                    result = EnumNameHelper<CashType>.GetEnumDescription(CashType);
                }
                catch
                {
                    CashType = EnumTypes.CashType.Empty;
                }
                return result;
            }
        }

        /// <summary>
        /// 开户行
        /// </summary>
        public string OpenBankName { get; set; }

        public override string ToString()
        {
            return Account.ToString();
        }
    }
}
