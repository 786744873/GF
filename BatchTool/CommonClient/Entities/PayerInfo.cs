using System;
using CommonClient.Controls;
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.Utilities;

namespace CommonClient.Entities
{
    /// <summary>
    ///   付款人名册类
    /// </summary>
    [Serializable]
    public class PayerInfo : EntityBase
    {
        public int RowIndex { get; set; }
        /// <summary>
        ///   获取服务范围
        /// </summary>
        public AppliableFunctionType ServiceList { get; set; }

        public AppliableFunctionType ServiceListBar { get; set; }

        public PayerInfo()
        {
        }

        /// <summary>
        ///   付款人名称
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Name { get; set; }

        /// <summary>
        ///   付款账号
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string Account { get; set; }

        /// <summary>
        ///   货币类型
        /// </summary>
        public CashType CashType { get; set; }

        /// <summary>
        ///   货币类型
        /// </summary>
        public string CashTypeString
        {
            get
            {
                string result = string.Empty;
                try
                {
                    result = EnumNameHelper<CashType>.GetEnumDescription(CashType);
                }
                catch
                {
                    CashType = CashType.Empty;
                }
                return result;
            }
        }

        /// <summary>
        ///   扩展字段
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        ///   获取服务范围
        /// </summary>
        public string ServiceString
        {
            get
            {
                string str = string.Empty;
                if ((SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
                {
                    if ((ServiceList & AppliableFunctionType.TransferWithIndiv) == AppliableFunctionType.TransferWithIndiv)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.TransferWithIndiv));
                    if ((ServiceList & AppliableFunctionType.TransferWithCorp) == AppliableFunctionType.TransferWithCorp)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.TransferWithCorp));
                    if ((ServiceList & AppliableFunctionType.AgentExpressOut) == AppliableFunctionType.AgentExpressOut)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.AgentExpressOut));
                    if ((ServiceList & AppliableFunctionType.AgentExpressIn) == AppliableFunctionType.AgentExpressIn)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.AgentExpressIn));
                    if ((ServiceList & AppliableFunctionType.AgentNormalOut) == AppliableFunctionType.AgentNormalOut)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.AgentNormalOut));
                    if ((ServiceList & AppliableFunctionType.AgentNormalIn) == AppliableFunctionType.AgentNormalIn)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.AgentNormalIn));
                    if ((ServiceList & AppliableFunctionType.TransferOverBankOut) == AppliableFunctionType.TransferOverBankOut)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.TransferOverBankOut));
                    if ((ServiceList & AppliableFunctionType.TransferOverBankIn) == AppliableFunctionType.TransferOverBankIn)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.TransferOverBankIn));
                    if ((ServiceList & AppliableFunctionType.ElecTicketRemit) == AppliableFunctionType.ElecTicketRemit)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.ElecTicketRemit));
                    if ((ServiceList & AppliableFunctionType.ElecTicketTipExchange) == AppliableFunctionType.ElecTicketTipExchange)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.ElecTicketTipExchange));
                    if ((ServiceList & AppliableFunctionType.ElecTicketBackNote) == AppliableFunctionType.ElecTicketBackNote)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.ElecTicketBackNote));
                    if ((ServiceList & AppliableFunctionType.ElecTicketPayMoney) == AppliableFunctionType.ElecTicketPayMoney)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.ElecTicketPayMoney));
                    if ((ServiceList & AppliableFunctionType.TransferForeignMoney) == AppliableFunctionType.TransferForeignMoney)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.TransferForeignMoney));
                    if ((ServiceList & AppliableFunctionType.TransferOverCountry) == AppliableFunctionType.TransferOverCountry)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.TransferOverCountry));
                }
                else
                {
                    if ((ServiceListBar & (AppliableFunctionType)(Math.Abs((long)AppliableFunctionType.AgentExpressOut4Bar))) == AppliableFunctionType.AgentExpressOut)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.AgentExpressOut4Bar));
                    if ((ServiceListBar & (AppliableFunctionType)(Math.Abs((long)AppliableFunctionType.TransferOverCountry4Bar))) == AppliableFunctionType.TransferOverCountry)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.TransferOverCountry4Bar));
                    if ((ServiceListBar & (AppliableFunctionType)(Math.Abs((long)AppliableFunctionType.TransferForeignMoney4Bar))) == AppliableFunctionType.TransferForeignMoney)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.TransferForeignMoney4Bar));
                }
                return str;
            }
        }

        private void CombeString(ref string resource, string temp)
        {
            if (!string.IsNullOrEmpty(resource))
                resource += ",";
            resource += temp;
        }

        public override string ToString()
        {
            return this.Account;
        }
    }
}