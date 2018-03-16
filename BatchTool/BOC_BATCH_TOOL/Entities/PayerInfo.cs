using System;
using System.Collections.Generic;
using System.Text;
using BOC_BATCH_TOOL.EnumTypes;
using BOC_BATCH_TOOL.Utilities;

namespace BOC_BATCH_TOOL.Entities
{
    /// <summary>
    /// 付款人名册类
    /// </summary>
    [Serializable]
    public class PayerInfo
    {
        public PayerInfo() { }
        /// <summary>
        /// 付款人名称
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        private string m_Name;
        /// <summary>
        /// 付款账号
        /// </summary>
        public string Account
        {
            get { return m_Account; }
            set { m_Account = value; }
        }
        private CashType m_cashtype;
        /// <summary>
        /// 货币类型
        /// </summary>
        public CashType CashType
        {
            get { return m_cashtype; }
            set { m_cashtype = value; }
        }
        /// <summary>
        /// 货币类型
        /// </summary>
        public string CashTypeString
        {
            get
            {
                string result = string.Empty;
                try { result = EnumNameHelper<CashType>.GetEnumDescription(m_cashtype); }
                catch { m_cashtype = EnumTypes.CashType.Empty; }
                return result;
            }
        }
        /// <summary>
        /// 扩展字段
        /// </summary>
        public object Tag
        {
            get;
            set;
        }
        private string m_Account;
        /// <summary>
        /// 获取服务范围
        /// </summary>
        public AppliableFunctionType ServiceList;
        /// <summary>
        /// 获取服务范围
        /// </summary>
        public string ServiceString
        {
            get
            {
                string str = string.Empty;
                if ((BOC_BATCH_TOOL.SysCoach.SystemSettings.Instance.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
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
                    if ((ServiceListBar & (AppliableFunctionType)(Math.Abs((int)AppliableFunctionType.AgentExpressOut4Bar))) == AppliableFunctionType.AgentExpressOut)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.AgentExpressOut4Bar));
                    if ((ServiceListBar & (AppliableFunctionType)(Math.Abs((int)AppliableFunctionType.TransferOverCountry4Bar))) == AppliableFunctionType.TransferOverCountry)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.TransferOverCountry4Bar));
                    if ((ServiceListBar & (AppliableFunctionType)(Math.Abs((int)AppliableFunctionType.TransferForeignMoney4Bar))) == AppliableFunctionType.TransferForeignMoney)
                        CombeString(ref str, EnumNameHelper<AppliableFunctionType>.GetEnumDescription(AppliableFunctionType.TransferForeignMoney4Bar));
                }
                return str;
            }
        }
        public AppliableFunctionType ServiceListBar;

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
