using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;
using CommonClient.ConvertHelper;
using CommonClient.EnumTypes;
using CommonClient.Types;

namespace CommonClient.Utilities
{

    public static class EnumNameHelper<T>
    {
        public static string TranslateNameFromValue(int aValue)
        {
            var result = string.Empty;
            var aType = typeof(T);
            foreach (MemberInfo mInfo in aType.GetMembers())
            {
                foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
                {
                    if (attr.GetType() == typeof(TranslatingKeyAttribute))
                    {
                        result = ((TranslatingKeyAttribute)attr).LanKey;
                        return result;
                    }
                }
            }
            return result;
        }

        public static string GetEnumDescription(Enum enumSubitem)
        {
            var strValue = enumSubitem.ToString();
            var fieldinfo = enumSubitem.GetType().GetField(strValue);
            var objs = fieldinfo.GetCustomAttributes(typeof(TranslatingKeyAttribute), false);
            if (objs.Length == 0)
                return strValue;
            var da = (TranslatingKeyAttribute)objs[0];
            return GetMultiLanguageDescription(da);
        }

        static string GetMultiLanguageDescription(TranslatingKeyAttribute data)
        {
            string result = string.Empty;
            switch (SysCoach.SystemSettings.CurrentLanguage)
            {
                case UILang.CHS: result = data.C; break;
                case UILang.CHT: result = data.T; break;
                case UILang.EN: result = data.E; break;
                //todo : 处理其他语种的情况
                default: break;
            }
            return result;
        }
    }

    public static class EnumNameValueHelper<T>
    {
        public static string GetNameFromValue(int value)
        {
            var result = Enum.GetName(typeof(T), value);
            return result;
        }

        public static T GetValueFromName(string name)
        {
            T result;
            var predefined = EnumListHelper<T>.GetNameList().Find(item => string.Equals(item, name, StringComparison.CurrentCultureIgnoreCase));
            if (string.Equals(predefined, name, StringComparison.CurrentCultureIgnoreCase))
                result = (T)Enum.Parse(typeof(T), name, true);
            else
                result = (T)Enum.Parse(typeof(T), Enum.GetNames(typeof(T))[0]);
            return result;
        }
    }

    public static class EnumListHelper<T>
    {
        public static List<T> GetValueList()
        {
            var result = new List<T>();
            var enumerator = Enum.GetValues(typeof(T)).GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add((T)enumerator.Current);
            }
            return result;
        }

        public static List<string> GetNameList()
        {
            var result = new List<string>();
            var enumerator = Enum.GetNames(typeof(T)).GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add((string)enumerator.Current);
            }
            return result;
        }
    }

    [Serializable]
    public class PrequisiteDataProvideNode
    {
        [XmlArrayItem("UILangList")]
        public List<UILang> UILangList { get; set; }

        [XmlArrayItem("CashTypeList")]
        public List<CashType> CashTypeList { get; set; }

        //[XmlArrayItem("CharingFeeAccountTypeList")]
        public List<ChargingFeeAccountType> CharingFeeAccountTypeList { get; set; }

        [XmlArrayItem("AgentBusinessTypeList")]
        public List<AgentBusinessType> AgentBusinessTypeList { get; set; }

        [XmlArrayItem("AgentTransferBankTypeList")]
        public List<AgentTransferBankType> AgentTransferBankTypeList { get; set; }

        [XmlArrayItem("AgentTransferUsageTypeList")]
        public List<AgentTransferUsageType> AgentTransferUsageTypeList { get; set; }

        [XmlArrayItem("AccountBankTypeList")]
        public List<AccountBankType> AccountBankTypeList { get; set; }

        [XmlArrayItem("AccountCategoryTypeList")]
        public List<AccountCategoryType> AccountCategoryTypeList { get; set; }

        [XmlArrayItem("AgentExpressCertifyPaperTypeList")]
        public List<AgentExpressCertifyPaperType> AgentExpressCertifyPaperTypeList { get; set; }

        [XmlArrayItem("PayeeCertifyPaperTypeList")]
        public List<PayeeCertifyPaperType> PayeeCertifyPaperTypeList { get; set; }

        [XmlArrayItem("AgentNormalCertifyPaperTypeListList")]
        public List<AgentNormalCertifyPaperType> AgentNormalCertifyPaperTypeList { get; set; }

        [XmlArrayItem("ChinaProvinceTypeList")]
        public List<ChinaProvinceType> ChinaProvinceTypeList { get; set; }

        [XmlArrayItem("AppliableFunctionTypeList")]
        public List<AppliableFunctionType> AppliableFunctionTypeList { get; set; }

        [XmlArrayItem("AgentCardTypeList")]
        public List<AgentCardType> AgentCardTypeList { get; set; }

        [XmlArrayItem("AgentNormalFunctionTypeList")]
        public List<AgentNormalFunctionType> AgentNormalFunctionTypeList { get; set; }

        [XmlArrayItem("AgentExpressFunctionTypeList")]
        public List<AgentExpressFunctionType> AgentExpressFunctionTypeList { get; set; }

        [XmlArrayItem("BusinessTypeList")]
        public List<BusinessType> BusinessTypeList { get; set; }

        [XmlArrayItem("UpdateFleTypeList")]
        public List<UpdateFleType> UpdateFleTypeList { get; set; }

        [XmlArrayItem("RelatePersonTypeList")]
        public List<RelatePersonType> RelatePersonTypeList { get; set; }

        [XmlArrayItem("ElecTicketTypeList")]
        public List<ElecTicketType> ElecTicketTypeList { get; set; }

        [XmlArrayItem("ClearMoneyTypeList")]
        public List<ClearMoneyType> ClearMoneyTypeList { get; set; }

        [XmlArrayItem("AssumeFeeTypeList")]
        public List<AssumeFeeType> AssumeFeeTypeList { get; set; }

        [XmlArrayItem("PayFeeTypeList")]
        public List<PayFeeType> PayFeeTypeList { get; set; }

        [XmlArrayItem("PaymentPropertyTypeList")]
        public List<PaymentPropertyType> PaymentPropertyTypeList { get; set; }

        [XmlArrayItem("PayFeeAccountTypeList")]
        public List<PayFeeAccountType> PayFeeAccountTypeList { get; set; }

        [XmlArrayItem("OverCountryPayeeAccountTypeList")]
        public List<OverCountryPayeeAccountType> OverCountryPayeeAccountTypeList { get; set; }

        [XmlArrayItem("SettlementTypeList")]
        public List<SettlementType> SettlementTypeList { get; set; }

        [XmlArrayItem("InterestFloatTypeList")]
        public List<InterestFloatType> InterestFloatTypeList { get; set; }

        [XmlArrayItem("CountryHelperList")]
        public List<CountryHelper> CountryHelperList { get; set; }

        [XmlArrayItem("PaymentTypeList")]
        public List<PaymentType> PaymentTypeList { get; set; }

        [XmlArrayItem("ProtocolMoneyTypeList")]
        public List<ProtocolMoneyType> ProtocolMoneyTypeList { get; set; }

        [XmlArrayItem("TransferChanelTypeList")]
        public List<TransferChanelType> TransferChanelTypeList { get; set; }

        [XmlArrayItem("UnitivePaymentTypeList")]
        public List<UnitivePaymentType> UnitivePaymentTypeList { get; set; }

        [XmlArrayItem("BarBusinessTypeList")]
        public List<BarBusinessType> BarBusinessTypeList { get; set; }

        [XmlArrayItem("BarApplyFlagTypeList")]
        public List<BarApplyFlagType> BarApplyFlagTypeList { get; set; }

        [XmlArrayItem("IsImportCancelAfterVerificationTypeList")]
        public List<IsImportCancelAfterVerificationType> IsImportCancelAfterVerificationTypeList { get; set; }

        [XmlArrayItem("Transfer2CountryTypeList")]
        public List<Transfer2CountryType> Transfer2CountryTypeList { get; set; }

        [XmlArrayItem("UnitiveFCPayeeAccountTypeList")]
        public List<UnitiveFCPayeeAccountType> UnitiveFCPayeeAccountTypeList { get; set; }

        private static PrequisiteDataProvideNode _prequisiteDataProvideNode;
        public static PrequisiteDataProvideNode InitialProvide
        {
            get
            {
                if (_prequisiteDataProvideNode == null)
                    _prequisiteDataProvideNode = new PrequisiteDataProvideNode
                    {
                        UILangList = EnumListHelper<UILang>.GetValueList(),
                        CashTypeList = EnumListHelper<CashType>.GetValueList(),
                        CharingFeeAccountTypeList = EnumListHelper<ChargingFeeAccountType>.GetValueList(),
                        AgentBusinessTypeList = EnumListHelper<AgentBusinessType>.GetValueList(),
                        AgentTransferBankTypeList = EnumListHelper<AgentTransferBankType>.GetValueList(),
                        AgentTransferUsageTypeList = EnumListHelper<AgentTransferUsageType>.GetValueList(),
                        AccountBankTypeList = EnumListHelper<AccountBankType>.GetValueList(),
                        AccountCategoryTypeList = EnumListHelper<AccountCategoryType>.GetValueList(),
                        PayeeCertifyPaperTypeList = EnumListHelper<PayeeCertifyPaperType>.GetValueList(),
                        AgentExpressCertifyPaperTypeList = EnumListHelper<AgentExpressCertifyPaperType>.GetValueList(),
                        AgentNormalCertifyPaperTypeList = EnumListHelper<AgentNormalCertifyPaperType>.GetValueList(),
                        ChinaProvinceTypeList = EnumListHelper<ChinaProvinceType>.GetValueList(),
                        AppliableFunctionTypeList = EnumListHelper<AppliableFunctionType>.GetValueList(),
                        AgentCardTypeList = EnumListHelper<AgentCardType>.GetValueList(),
                        AgentNormalFunctionTypeList = EnumListHelper<AgentNormalFunctionType>.GetValueList(),
                        AgentExpressFunctionTypeList = EnumListHelper<AgentExpressFunctionType>.GetValueList(),
                        BusinessTypeList = EnumListHelper<BusinessType>.GetValueList(),
                        UpdateFleTypeList = EnumListHelper<UpdateFleType>.GetValueList(),
                        RelatePersonTypeList = EnumListHelper<RelatePersonType>.GetValueList(),
                        ElecTicketTypeList = EnumListHelper<ElecTicketType>.GetValueList(),
                        ClearMoneyTypeList = EnumListHelper<ClearMoneyType>.GetValueList(),
                        AssumeFeeTypeList = EnumListHelper<AssumeFeeType>.GetValueList(),
                        PayFeeTypeList = EnumListHelper<PayFeeType>.GetValueList(),
                        PaymentPropertyTypeList = EnumListHelper<PaymentPropertyType>.GetValueList(),
                        PayFeeAccountTypeList = EnumListHelper<PayFeeAccountType>.GetValueList(),
                        OverCountryPayeeAccountTypeList = EnumListHelper<OverCountryPayeeAccountType>.GetValueList(),
                        SettlementTypeList = EnumListHelper<SettlementType>.GetValueList(),
                        InterestFloatTypeList = EnumListHelper<InterestFloatType>.GetValueList(),
                        CountryHelperList = EnumListHelper<CountryHelper>.GetValueList(),
                        PaymentTypeList = EnumListHelper<PaymentType>.GetValueList(),
                        ProtocolMoneyTypeList = EnumListHelper<ProtocolMoneyType>.GetValueList(),
                        TransferChanelTypeList = EnumListHelper<TransferChanelType>.GetValueList(),
                        UnitivePaymentTypeList = EnumListHelper<UnitivePaymentType>.GetValueList(),
                        BarBusinessTypeList = EnumListHelper<BarBusinessType>.GetValueList(),
                        BarApplyFlagTypeList = EnumListHelper<BarApplyFlagType>.GetValueList(),
                        IsImportCancelAfterVerificationTypeList = EnumListHelper<IsImportCancelAfterVerificationType>.GetValueList(),
                        Transfer2CountryTypeList = EnumListHelper<Transfer2CountryType>.GetValueList(),
                        UnitiveFCPayeeAccountTypeList = EnumListHelper<UnitiveFCPayeeAccountType>.GetValueList(),
                    };
                return _prequisiteDataProvideNode;
            }
        }
    }

    [Serializable]
    public class DynamicDataProvideNode
    {
    }

    public static class LocalStorageHelper<T>
    {
        public static T ReadFromText(string storageFileName)
        {
            T result;
            using (var stream = new FileStream(storageFileName, FileMode.Open, FileAccess.ReadWrite))
            {
                var ser = new XmlSerializer(typeof(T));
                result = ((T)(ser.Deserialize(stream)));
                stream.Flush();
            }
            return result;
        }

        public static void SaveToText(object thing, string storageFileName)
        {
            using (var stream = new FileStream(storageFileName, FileMode.Create, FileAccess.ReadWrite))
            {
                var ser = new XmlSerializer(typeof(T));
                ser.Serialize(stream, thing);
                stream.Flush();
            }
        }

        public static T ReadFromBinary(string storageFileName)
        {
            using (var fileStream = new FileStream(storageFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var b = new BinaryFormatter();
                var result = (T)b.Deserialize(fileStream);
                //fileStream.Close();
                return result;
            }
        }

        public static void SaveToBinary(object thing, string storageFileName)
        {
            using (var fileStream = new FileStream(storageFileName, FileMode.Create))
            {
                var b = new BinaryFormatter();
                b.Serialize(fileStream, thing);
                //fileStream.Close();
            }
        }


    }
}
