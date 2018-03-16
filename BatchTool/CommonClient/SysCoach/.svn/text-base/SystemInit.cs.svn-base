using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient.Entities;

namespace CommonClient.SysCoach
{
    public static class SystemInit
    {
        public static void CheckInit()
        {
            foreach (var aft in Utilities.PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
            {
                if (aft == AppliableFunctionType._Empty) continue;
                Entities.MappingsRelationSettings mrs = GetMappingRelation(aft);
            }
        }

        public static void InitBaseSetting()
        {
            //if (null == SystemSettings.CurrentLanguage) SystemSettings.CurrentLanguage = EnumTypes.UILang.CHS;
            if ((SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
            {
                SystemSettings.AppliableTypes = EnumTypes.AppliableFunctionType._Empty; //EnumTypes.AppliableFunctionType.TransferWithCorp | EnumTypes.AppliableFunctionType.AgentExpressOut;
                SystemSettings.AppliableTypes4Bar = AppliableFunctionType._Empty;
            }
            else
            {
                SystemSettings.AppliableTypes = AppliableFunctionType._Empty;
                SystemSettings.AppliableTypes4Bar = (AppliableFunctionType)Math.Abs((long)AppliableFunctionType.AgentExpressOut4Bar)
                                                          | (AppliableFunctionType)Math.Abs((long)AppliableFunctionType.TransferForeignMoney4Bar)
                                                          | (AppliableFunctionType)Math.Abs((long)AppliableFunctionType.TransferOverCountry4Bar);
            }
            SystemSettings.IsMatchPassword4ShortProxyOut = false;
            SystemSettings.ShortProxyOutPassword = string.Empty;
            SystemSettings.IsMatchPassword4TransferForeignMoney = false;
            SystemSettings.TransferForeignMoneyPassword = string.Empty;
            SystemSettings.IsMatchPassword4TransferOverCountry = false;
            SystemSettings.TransferOverCountryPassword = string.Empty;
        }

        public static void InitCommonField()
        {
            SystemSettings.CommonFieldList = new Dictionary<EnumTypes.AppliableFunctionType, EnumTypes.CommonFieldType>();
            SystemSettings.CommonFieldList.Add(AppliableFunctionType.TransferWithIndiv, CommonFieldType.Empty);
        }

        public static void InitMappingRelation()
        {
            if (null == SystemSettings.BatchMappingSettings)
                SystemSettings.BatchMappingSettings = new Dictionary<AppliableFunctionType, Entities.MappingsRelationSettings>();
            foreach (var item in Utilities.PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
            {
                if (item == AppliableFunctionType._Empty) continue;
                if (!SystemSettings.BatchMappingSettings.ContainsKey(item))
                    SystemSettings.BatchMappingSettings.Add(item, GetMappingRelation(item));
                else
                {
                    if (SystemSettings.BatchMappingSettings[item].FieldsMappings.Count == 0)
                        SystemSettings.BatchMappingSettings[item] = GetMappingRelation(item);
                    else
                    {
                        Entities.MappingsRelationSettings mrs = GetMappingRelation(item);
                        if (SystemSettings.BatchMappingSettings[item].FieldsMappings.Count != mrs.FieldsMappings.Count)
                            SystemSettings.BatchMappingSettings[item] = GetMappingRelation(item);
                    }
                }
            }

            if (!SystemSettings.BatchSettingsMappingSettings.ContainsKey(FunctionInSettingType.PayeeMg))
                SystemSettings.BatchSettingsMappingSettings.Add(FunctionInSettingType.PayeeMg, GetMappingRelation(FunctionInSettingType.PayeeMg));
            else
            {
                if (SystemSettings.BatchSettingsMappingSettings[FunctionInSettingType.PayeeMg].FieldsMappings.Count == 0)
                    SystemSettings.BatchSettingsMappingSettings[FunctionInSettingType.PayeeMg] = GetMappingRelation(FunctionInSettingType.PayeeMg);
                else
                {
                    Entities.MappingsRelationSettings mrs = GetMappingRelation(FunctionInSettingType.PayeeMg);
                    if (SystemSettings.BatchSettingsMappingSettings[FunctionInSettingType.PayeeMg].FieldsMappings.Count != mrs.FieldsMappings.Count)
                        SystemSettings.BatchSettingsMappingSettings[FunctionInSettingType.PayeeMg] = GetMappingRelation(FunctionInSettingType.PayeeMg);
                }
            }
        }

        public static void InitDataFieldsDescription()
        {
            SystemSettings.BatchRegexDescriptions = new Dictionary<AppliableFunctionType, List<string>>();
            SystemSettings.RegexDescriptions = new Dictionary<AppliableFunctionType, List<string>>();

            foreach (var item in Utilities.PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
            {
                if (item == AppliableFunctionType._Empty) continue;
                if (!SystemSettings.BatchRegexDescriptions.ContainsKey(item))
                    SystemSettings.BatchRegexDescriptions.Add(item, GetBatchRegexDescription(item));
                if (!SystemSettings.RegexDescriptions.ContainsKey(item))
                    SystemSettings.RegexDescriptions.Add(item, GetRegexDescription(item));
            }

            if (!SystemSettings.BatchSettingsMappingSettings.ContainsKey(FunctionInSettingType.PayeeMg))
            {
                SystemSettings.BatchSettingsMappingSettings.Add(FunctionInSettingType.PayeeMg, GetMappingRelation(FunctionInSettingType.PayeeMg));
                SystemSettings.RegexSettingsDescriptions.Add(FunctionInSettingType.PayeeMg, GetRegexDescription(FunctionInSettingType.PayeeMg));
            }
        }

        public static void InitMultiLanguageMsg()
        {

        }

        public static Entities.MappingsRelationSettings GetMappingRelation(AppliableFunctionType aft)
        {
            Entities.MappingsRelationSettings mrs = new Entities.MappingsRelationSettings { MaxCountPerOperation = CommonInformations.GetFunctionMaximum(aft), SeperateChar = string.Empty };
            switch (aft)
            {
                case AppliableFunctionType.TransferWithIndiv:
                case AppliableFunctionType.TransferWithCorp:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_CNAPSNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_PayFeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_Addtion, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_OperateOrder, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_Email, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_IsBOCFlag, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_Mappings_CustomerRef, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.AgentExpressOut:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_PayeeBankName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_PayerName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_PayerAccount, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_Usege, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_PayDate, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_CutomerRef, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_Addtion, string.Empty);

                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeAccountProvince, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeOpenBankNo, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Usage, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.AgentExpressIn:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_PayerBankName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_PayeeName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_PayeeAccount, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_Usege, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_PayDate, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_CutomerRef, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_Batch_Addtion, string.Empty);

                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerAccountProvince, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerOpenBankNo, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerOpenBankNoOrCNAPSNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerCertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerCertifyNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressIn_Mappings_SerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Usage, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.AgentNormalOut:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_Batch_PayerName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_Batch_PayerAccount, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_Batch_CustomerRef, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_Batch_PayDate, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_Batch_CardType, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_Batch_BankLinkNo, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_Batch_Usege, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_Batch_Addtion, string.Empty);

                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_BankLinkNoOrCNAPSNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeCertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeCertifyNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalOut_Mappings_Usege, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.AgentNormalIn:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_Batch_PayeeName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_Batch_PayeeAccount, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_Batch_CustomerRef, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_Batch_PayDate, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_Batch_CardType, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_Batch_BankLinkNo, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_Batch_Addtion, string.Empty);

                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_BankLinkNoOrCNAPSNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayerBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayerCertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayerCertifyNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_Usege, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentNormalIn_Mappings_SerialNo, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.TransferOverBankOut:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayeeBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayeeClearBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_CutomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayFeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_Addtion, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_Email, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_OperateOrder, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.TransferOverBankIn:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayProtecolNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_BusinessType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayerBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_CutomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_Addtion, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayDateTime, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.ElecTicketRemit:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_TicketType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_RemitDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_EndDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_RemitAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_ExchangeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_ExchangeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_ExchangeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_ExchangeOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_PayeeOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_CanChange, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_CanAutoTipExchange, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_CanAutoReceiveTicket, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_Note, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.ElecTicketBackNote:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_Account, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_TicketSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_BackNotedName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_BackNotedAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_BackNotedOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_BackNotedOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_Note, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.ElecTicketPayMoney:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_Account, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_TicketSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_PayMoneyType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_ClearType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_PayMoneyPercent, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_PayMoneyAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_StickOnName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_StickOnccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_StickOnOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_StickOnOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_IsContainMoney, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_ProtocolMoneyPercent, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_ContactNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_Note, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.ElecTicketTipExchange:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_Account, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_TicketSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_ExchangeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_ExchangeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_ContactNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_Note, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.ElecTicketPool:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_CustomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_ExchangeBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_ElecTicketSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_RemitDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_EndDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_RemitName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_RemitAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_ExchangeBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_ExchangeBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_ExchangeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_ExchangeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_ExchangeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_ExchangeOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_ExchangeDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_PayeeOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_PreBackNotedPerson, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_EndDateOperate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.ElecTicketPool_BusinessType, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.TransferOverCountry:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PaymentType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_SendPriority, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PaymentCashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_SpotAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_SpotAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PurchaseAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PurchaseAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_OtherAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_OtherAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayFeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_OrgCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CutomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeCodeofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeNameofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankSwiftCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankSwiftCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeAccountInCorrespondentBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitNote, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AmountF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_DealNoteF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AmountS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_DealNoteS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_IsPayOffLine, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_ContactNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_BatchNoOrTNoOrSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_ProposerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_Telephone, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.TransferForeignMoney:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PaymentType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_SendPriority, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PaymentCashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_SpotAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_SpotAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PurchaseAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PurchaseAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_OtherAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_OtherAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayFeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_OrgCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CutomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeCodeofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeNameofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeAccountInCorrespondentBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitNote, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PaymentPropertyType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AmountF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AmountS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_IsPayOffLine, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_ContactNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_BatchNoOrTNoOrSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_ProposerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_Telephone, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_ContractOrOrderNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_OrderDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_OrderAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_DeliveryDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_SettlementType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_TaxInvoiceNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_ReceiptNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_RiskTakingLetterNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_GoodsDesc, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_ApplyAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_ApplyDays, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_AgrementNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_InterestFloatingPercent, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingApply_InterestFloatType, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.PurchaserOrder:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrder_OrderNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrder_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrder_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrder_ERPCode_Seller, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrder_CustomerNo_Seller, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrder_PayDate_Seller, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.SellerOrder:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrder_OrderNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrder_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrder_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrder_CustomerName_Purchase, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrder_PayDate_Purchase, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrder_OrderNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingOrderMgr_PayAmountForThisTime, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_BillDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_ContractNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_CustomerName_Seller, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_CustomerNo_Seller, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_EndDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_StartDate, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.BillofDebtReceivableSeller:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_BillDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_ContractNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_CustomerName_Purchase, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_CustomerNo_Purchase, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_EndDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingBill_StartDate, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingPayOrReceipt_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingPayOrReceipt_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingPayOrReceipt_CustomerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingPayOrReceipt_CustomerNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.SpplyFinancingPayOrReceipt_AmountThisTime, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.InitiativeAllot:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.InitiativeAllot_Batch_PayDate, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.InitiativeAllot_Batch_ProtecolNo, string.Empty);

                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.InitiativeAllot_AccountOut, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.InitiativeAllot_NameOut, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.InitiativeAllot_AccountIn, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.InitiativeAllot_NameIn, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.InitiativeAllot_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.InitiativeAllot_Addition, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.TransferOverCountry4Bar:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PaymentType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_SendPriority, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PaymentCashType, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_SpotAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_SpotAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PurchaseAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PurchaseAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayFeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_OrgCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitAddress, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CutomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeCodeofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeNameofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankSwiftCode_Bar_OC, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankSwiftCode_Bar_OC, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeAccountInCorrespondentBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitNote, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayFeeType, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PaymentPropertyType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AmountF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_DealNoteF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AmountS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_DealNoteS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_IsPayOffLine, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_ContactNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_BatchNoOrTNoOrSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_ProposerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_Telephone, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.TransferForeignMoney4Bar:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PaymentType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_SendPriority, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PaymentCashType, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_SpotAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_SpotAmount, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PurchaseAccount, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PurchaseAmount, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_OtherAccount, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_OtherAmount, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayFeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_OrgCode, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitAddress, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CutomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeCodeofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeNameofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankSwiftCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankName, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankSwiftCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeAccountInCorrespondentBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_RemitNote, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PayFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_PaymentPropertyType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AmountF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AmountS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_IsPayOffLine, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_ContactNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_BatchNoOrTNoOrSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_ProposerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_Telephone, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeAccountProvince, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Business, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Bar_Addition, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_BarBusinessType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_BarApplyFlagType, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.AgentExpressOut4Bar:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_PayeeBankName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_PayerName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_PayerAccount, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_Usege, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_PayDate, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_CutomerRef, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Batch_Addtion, string.Empty);

                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Usage, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.AgentExpressOut_Mappings_Bar_Addition, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.UnitivePaymentRMB:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_PayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_BankType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_PayeeCNAPS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_NominalPayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_NominalPayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_Purpose, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_UnitivePaymentType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_OrderPayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_CustomerBusinissNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_TransferChanelType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_IsTipPayee, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentRMB_TipPayeePhone, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.UnitivePaymentFC:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_PayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_NominalPayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_NominalPayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_OrgCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_OpenBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_PayeeOpenBankSwiftCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_CorrespondentBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_CorrespondentBankSwiftCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_CorrespondentBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_PayeeAccountInCorrespondentBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_Address, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_AccountBankType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_CustomerBusinissNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_NominalPayerAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_Purpose, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_OrderPayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_Addtion, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_CodeofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_IsNoSavePay, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_UnitivePaymentType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_PaymentNature, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_TransactionCode1, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_TransactionCode2, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_IPPSMoneyTypeAmount1, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_IPPSMoneyTypeAmount2, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_TransactionAddtion1, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_TransactionAddtion2, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_IsPayOffLineString, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_ContractNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_InvoiceNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_BatchNoOrTNoOrSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_ApplicantName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_Contactnumber, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_SendPriority, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_realPayAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_PaymentCountryOrArea, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_PayeeAccountType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.UnitivePaymentFC_FCPayeeAccountType, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.VirtualAccountTransfer:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Virtual_AccountOut, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Virtual_NameOut, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Virtual_AccountIn, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Virtual_NameIn, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Virtual_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Virtual_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Virtual_Pursion, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Virtual_CustomerBusinissNo, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.PreproccessTransfer:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_PreproccessName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_PreproccessAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_PreproccessAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_MainAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_TradeSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_BatchTradeSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_InvolvedName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_InvolvedAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_TradeDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_Content, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_VirtualAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Preproccess_TradeAmount, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.BatchReimbursement:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.BatchReimbursement_CardNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.BatchReimbursement_PayAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.BatchReimbursement_PayDateTime, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.BatchReimbursement_PayPassword, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.BatchReimbursement_ReimburseAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.BatchReimbursement_Usage, string.Empty);
                    break;
                    #endregion
                default: break;
            }
            return mrs;
        }

        public static Entities.MappingsRelationSettings GetMappingRelation(FunctionInSettingType fst)
        {
            Entities.MappingsRelationSettings mrs = new Entities.MappingsRelationSettings { MaxCountPerOperation = int.MaxValue, SeperateChar = string.Empty };
            switch (fst)
            {
                case FunctionInSettingType.PayeeMg:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_BankType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_SerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Account, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Select_AccountType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Name, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_OpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_OpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_ClearBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_ClearBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_CertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_CertifyCardNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Address, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Email, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Telephone, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Fax, string.Empty);
                    break;
                    #endregion
                default: break;
            }
            return mrs;
        }

        public static List<string> GetRegexDescription(AppliableFunctionType item)
        {
            List<string> result = new List<string>();
            switch (item)
            {
                case AppliableFunctionType.TransferWithIndiv:
                case AppliableFunctionType.TransferWithCorp:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Transfer_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_Mappings_PayeeName_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_Mappings_PayeeOpenBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_Mappings_CNAPSNo_RegexDescription, 
                        (SystemSettings.CurrentVersion& VersionType.v405)!= VersionType.v405
                        ?MultiLanguageConvertHelper.Transfer_Mappings_PayerAccount_RegexDescription
                        :MultiLanguageConvertHelper.Transfer_Mappings_PayerAccount_RegexDescription.Replace("12","1").Replace("18","35"), 
                        (SystemSettings.CurrentVersion& VersionType.v405)!= VersionType.v405
                        ?MultiLanguageConvertHelper.Transfer_Mappings_PayFeeAccount_RegexDescription
                        :MultiLanguageConvertHelper.Transfer_Mappings_PayFeeAccount_RegexDescription.Replace("12","1").Replace("18","35"),
                        MultiLanguageConvertHelper.Transfer_Mappings_PayDate_RegexDescription, 
                        item== AppliableFunctionType.TransferWithIndiv
                            ? MultiLanguageConvertHelper.Transfer_Mappings_Addtion_RegexDescription.Replace("非必输","必输")
                            : MultiLanguageConvertHelper.Transfer_Mappings_Addtion_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_Mappings_OperateOrder_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_Mappings_Email_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_Mappings_IsBOCFlag_RegexDescription,
                        MultiLanguageConvertHelper.Transfer_Mappings_CustomerRef_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.AgentExpressOut:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeName_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeAccountProvince_RegexDescription,
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeOpenBankNo_RegexDescription,
                        //MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyCardType_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyNo_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_Usage_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.AgentExpressIn:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.AgentExpressIn_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerName_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerAccount_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeAccountProvince_RegexDescription,
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeOpenBankNo_RegexDescription,
                        //MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerOpenBankNoOrCNAPSNo_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerCertifyCardType_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressIn_Mappings_PayerCertifyNo_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressIn_Mappings_SerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressIn_Mappings_Usage_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.AgentNormalOut:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.AgentNormalOut_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeName_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalOut_Mappings_BankLinkNoOrCNAPSNo_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeBankName_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeCertifyCardType_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalOut_Mappings_PayeeCertifyNo_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalOut_Mappings_Usege_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.AgentNormalIn:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.AgentNormalIn_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayeeName_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalIn_Mappings_BankLinkNoOrCNAPSNo_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayeeBankName_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayerCertifyCardType_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalIn_Mappings_PayerCertifyNo_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalIn_Mappings_Usege_RegexDescription, 
                        MultiLanguageConvertHelper.AgentNormalIn_Mappings_SerialNo_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.TransferOverBankOut:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayeeName_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayeeBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayeeClearBankNo_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayerAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_CutomerRef_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayFeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_Addtion_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_PayDate_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_Email_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankOut_Mappings_OperateOrder_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.TransferOverBankIn:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PaySerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_BusinessType_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayerName_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayerAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayerBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayeeName_RegexDescription,
                        MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_CutomerRef_RegexDescription, 
                        MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_Addtion_RegexDescription,
                        MultiLanguageConvertHelper.Transfer_OverBankIn_Mappings_PayDateTime_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.ElecTicketRemit:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_TicketType_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_Amount_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_RemitDate_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_EndDate_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_RemitAccount_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_ExchangeName_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_ExchangeAccount_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_ExchangeOpenBankName_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_ExchangeOpenBankNo_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_PayeeName_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_PayeeAccount_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_PayeeOpenBankName_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_PayeeOpenBankNo_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_CanChange_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_CanAutoTipExchange_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_CanAutoReceiveTicket_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicket_Remit_Mappings_Note_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.ElecTicketBackNote:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_Account_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_TicketSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_BackNotedName_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_BackNotedAccount_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_BackNotedOpenBankName_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_BackNotedOpenBankNo_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_BackNoted_Mappings_Note_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.ElecTicketPayMoney:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_Account_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_TicketSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_PayMoneyType_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_ClearType_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_PayDate_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_PayMoneyPercent_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_PayMoneyAccount_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankName_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankNo_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_StickOnName_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_StickOnccount_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_StickOnOpenBankName_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_StickOnOpenBankNo_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_IsContainMoney_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_ProtocolMoneyPercent_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_BillSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_ContactNo_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_PayMoney_Mappings_Note_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.ElecTicketTipExchange:
                    #region
                    result = new List<string> { 
                        MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_Account_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_TicketSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_ExchangeName_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_ExchangeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankName_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankNo_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_BillSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_ContactNo_RegexDescription, 
                        MultiLanguageConvertHelper.ElecTicket_AutoTipExchange_Mappings_Note_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.ElecTicketPool:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.ElecTicketPool_CustomerRef_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_ExchangeBank_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_ElecTicketSerialNo_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_Amount_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_RemitDate_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_EndDate_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_RemitName_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_RemitAccount_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_ExchangeBankName_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_ExchangeBankNo_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_ExchangeName_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_ExchangeAccount_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_ExchangeOpenBankName_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_ExchangeOpenBankNo_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_ExchangeDate_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_PayeeName_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_PayeeAccount_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_PayeeOpenBankName_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_PayeeOpenBankNo_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_PreBackNotedPerson_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_EndDateOperate_RegexDescription,
                        MultiLanguageConvertHelper.ElecTicketPool_BusinessType_RegexDescription,}; break;
                    #endregion
                case AppliableFunctionType.TransferOverCountry:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.TransferGlobal_PayDate_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PaymentType_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_SendPriority_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_PaymentCashType_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_RemitAmount_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_SpotAccount_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_SpotAmount_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_PurchaseAccount_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_PurchaseAmount_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_OtherAccount_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_OtherAmount_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_PayFeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_OrgCode_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_RemitName_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.TransferGlobal_RemitAddress_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.TransferGlobal_CutomerRef_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_PayeeName_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.TransferGlobal_PayeeAddress_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.TransferGlobal_PayeeCodeofCountry_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_PayeeNameofCountry_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankName_RegexDescription.Replace("7","14").Replace("和中文","").Replace("非必输","必输"), 
                        MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankSwiftCode_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankAddress_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankName_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankSwiftCode_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankAddress_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.TransferGlobal_PayeeAccountInCorrespondentBank_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_RemitNote_RegexDescription.Replace("和中文","").Replace("50","140"), 
                        MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType_Country_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_PayFeeType_Country_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_AmountF_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_DealNoteF_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_AmountS_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_DealNoteS_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_IsPayOffLine_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_ContactNo_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_BillSerialNo_RegexDescription.Replace("20","50"), 
                        MultiLanguageConvertHelper.TransferGlobal_BatchNoOrTNoOrSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_ProposerName_RegexDescription, 
                        MultiLanguageConvertHelper.TransferGlobal_Telephone_RegexDescription }; break;
                    #endregion
                case AppliableFunctionType.TransferForeignMoney:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.TransferGlobal_PayDate_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PaymentType_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_SendPriority_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PaymentCashType_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_RemitAmount_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_SpotAccount_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_SpotAmount_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PurchaseAccount_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PurchaseAmount_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_OtherAccount_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_OtherAmount_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayFeeAccount_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_OrgCode_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_RemitName_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_RemitAddress_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_CutomerRef_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeAccount_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeName_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeAddress_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeCodeofCountry_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeNameofCountry_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankName_RegexDescription.Replace("非必输","必输"),};
                    if ((SystemSettings.CurrentVersion & VersionType.t43) == VersionType.t43)
                        result.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankAddress_RegexDescription.Replace("非必输", "必输"));
                    else
                        result.Add(MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankAddress_RegexDescription);
                    result.AddRange(new string[]{
                        //MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankAddress_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankName_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankAddress_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeAccountInCorrespondentBank_FM_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_RemitNote_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayFeeType_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PaymentPropertyType_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_AmountF_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_AmountS_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_IsPayOffLine_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_ContactNo_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_BillSerialNo_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_BatchNoOrTNoOrSerialNo_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_ProposerName_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_Telephone_RegexDescription}); break;
                    #endregion
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.SpplyFinancingApply_ContractOrOrderNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_OrderDate_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_CashType_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_OrderAmount_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_DeliveryDate_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_SettlementType_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_TaxInvoiceNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_ReceiptNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_RiskTakingLetterNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_GoodsDesc_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_ApplyAmount_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_ApplyDays_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_AgrementNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_InterestFloatingPercent_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingApply_InterestFloatType_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.PurchaserOrder:
                    #region
                    result = new List<string> { 
                        MultiLanguageConvertHelper.SpplyFinancingOrder_OrderNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingOrder_CashType_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingOrder_Amount_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingOrder_ERPCode_Seller_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingOrder_CustomerNo_Seller_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingOrder_PayDate_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.SellerOrder:
                    #region
                    result = new List<string> { 
                        MultiLanguageConvertHelper.SpplyFinancingOrder_OrderNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingOrder_CashType_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingOrder_Amount_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingOrder_CustomerName_Purchase_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingOrder_PayDate_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                    #region
                    result = new List<string> { 
                        MultiLanguageConvertHelper.SpplyFinancingOrder_OrderNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingOrder_Amount_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                case AppliableFunctionType.BillofDebtReceivableSeller:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.SpplyFinancingBill_Amount_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingBill_BillDate_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingBill_BillSerialNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingBill_CashType_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingBill_ContractNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingBill_CustomerName_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingBill_CustomerNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingBill_EndDate_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingBill_StartDate_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    #region
                    result = new List<string> { 
                        MultiLanguageConvertHelper.SpplyFinancingPayOrReceipt_BillSerialNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingPayOrReceipt_CashType_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingPayOrReceipt_CustomerName_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingPayOrReceipt_CustomerNo_RegexDescription,
                        MultiLanguageConvertHelper.SpplyFinancingPayOrReceipt_AmountThisTime_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.InitiativeAllot:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.InitiativeAllot_AccountOut_RegexDescription,
                        MultiLanguageConvertHelper.InitiativeAllot_NameOut_RegexDescription,
                        MultiLanguageConvertHelper.InitiativeAllot_AccountIn_RegexDescription,
                        MultiLanguageConvertHelper.InitiativeAllot_NameIn_RegexDescription,
                        MultiLanguageConvertHelper.InitiativeAllot_Amount_RegexDescription,
                        MultiLanguageConvertHelper.InitiativeAllot_Addition_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.TransferOverCountry4Bar:
                    #region
                    result = new List<string>{ 
                        //MultiLanguageConvertHelper.TransferGlobal_PayDate_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PaymentType_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_SendPriority_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PaymentCashType_Bar_OC_RegexDescription,
                        //MultiLanguageConvertHelper.TransferGlobal_RemitAmount_Bar_OC_RegexDescription,
                        string.Format("{0},{1}",MultiLanguageConvertHelper.TransferGlobal_SpotAccount_Bar_OC_RegexDescription,"现汇账户与购汇账户二者选其一"),
                        MultiLanguageConvertHelper.TransferGlobal_SpotAmount_Bar_OC_RegexDescription,
                        string.Format("{0},{1}",MultiLanguageConvertHelper.TransferGlobal_PurchaseAccount_Bar_OC_RegexDescription,"现汇账户与购汇账户二者选其一"),
                        MultiLanguageConvertHelper.TransferGlobal_PurchaseAmount_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayFeeAccount_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_OrgCode_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_RemitName_Bar_OC_RegexDescription.Replace("和中文",""),
                        MultiLanguageConvertHelper.TransferGlobal_RemitAddress_Bar_OC_RegexDescription.Replace("和中文",""),
                        //MultiLanguageConvertHelper.TransferGlobal_CutomerRef_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeAccount_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeName_Bar_OC_RegexDescription.Replace("和中文",""),
                        MultiLanguageConvertHelper.TransferGlobal_PayeeAddress_Bar_OC_RegexDescription.Replace("和中文",""),
                        MultiLanguageConvertHelper.TransferGlobal_PayeeCodeofCountry_Bar_OC_RegexDescription.Replace("数字","大写字母"),
                        MultiLanguageConvertHelper.TransferGlobal_PayeeNameofCountry_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankName_Bar_OC_RegexDescription.Replace("和中文","").Replace("非必输","必输"),
                        MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankSwiftCode_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankAddress_Bar_OC_RegexDescription.Replace("和中文",""),
                        MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankName_Bar_OC_RegexDescription.Replace("和中文",""),
                        string.Format("非{0}",MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankSwiftCode_Bar_OC_RegexDescription),
                        MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankAddress_Bar_OC_RegexDescription.Replace("和中文",""),
                        MultiLanguageConvertHelper.TransferGlobal_PayeeAccountInCorrespondentBank_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_RemitNote_Bar_OC_RegexDescription.Replace("和中文","").Replace("50","140"),
                        MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayFeeType_RegexDescription,
                        //MultiLanguageConvertHelper.TransferGlobal_PaymentPropertyType_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_AmountF_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_DealNoteF_Bar_OC_RegexDescription.Replace("100","50"),
                        MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_AmountS_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_DealNoteS_Bar_OC_RegexDescription.Replace("100","50"),
                        MultiLanguageConvertHelper.TransferGlobal_IsPayOffLine_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_ContactNo_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_BillSerialNo_Bar_OC_RegexDescription.Replace("20","35"),
                        MultiLanguageConvertHelper.TransferGlobal_BatchNoOrTNoOrSerialNo_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_ProposerName_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_Telephone_Bar_OC_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.TransferForeignMoney4Bar:
                    #region
                    result = new List<string> {
                        //MultiLanguageConvertHelper.TransferGlobal_PayDate_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PaymentType_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_SendPriority_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PaymentCashType_Bar_FM_RegexDescription,
                        //MultiLanguageConvertHelper.TransferGlobal_RemitAmount_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_SpotAccount_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_SpotAmount_Bar_FM_RegexDescription,
                        //MultiLanguageConvertHelper.TransferGlobal_PurchaseAccount_RegexDescription,
                        //MultiLanguageConvertHelper.TransferGlobal_PurchaseAmount_RegexDescription,
                        //MultiLanguageConvertHelper.TransferGlobal_OtherAccount_RegexDescription,
                        //MultiLanguageConvertHelper.TransferGlobal_OtherAmount_RegexDescription,
                        //MultiLanguageConvertHelper.TransferGlobal_PayFeeAccount_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_OrgCode_Bar_FM_RegexDescription,
                        //MultiLanguageConvertHelper.TransferGlobal_RemitName_RegexDescription,
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_RemitAddress_Bar_FM_RegexDescription.Replace("70","64")),
                        //MultiLanguageConvertHelper.TransferGlobal_CutomerRef_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeAccount_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.TransferGlobal_PayeeName_Bar_FM_RegexDescription.Replace("非必输","必输").Replace("70","64"),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_PayeeAddress_Bar_FM_RegexDescription.Replace("70","64")),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_PayeeCodeofCountry_Bar_FM_RegexDescription).Replace("数字","大写字母"),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_PayeeNameofCountry_Bar_FM_RegexDescription),
                        MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankName_Bar_FM_RegexDescription.Replace("非必输","必输"),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankSwiftCode_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_PayeeOpenBankAddress_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankName_Bar_FM_RegexDescription),
                        //string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankSwiftCode_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_CorrespondentBankAddress_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_PayeeAccountInCorrespondentBank_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_RemitNote_Bar_FM_RegexDescription.Replace("50","140")),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_AssumeFeeType_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_PayFeeType_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_PaymentPropertyType_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_DealSerialNoF_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_AmountF_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_DealSerialNoS_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_AmountS_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_IsPayOffLine_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_ContactNo_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_BillSerialNo_Bar_FM_RegexDescription.Replace("20","35")),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_BatchNoOrTNoOrSerialNo_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_ProposerName_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_Telephone_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","中行时填写,",MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeAccountProvince_RegexDescription),
                        string.Format("{0}{1}","中行时填写,",MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyCardType_RegexDescription),
                        string.Format("{0}{1}","中行时填写,",MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyNo_RegexDescription),
                        string.Format("{0}{1}","中行时填写,",MultiLanguageConvertHelper.AgentExpressOut_Mappings_Usage_RegexDescription.Replace("非必输项","必输项")),
                        string.Format("{0}{1}","中行时填写,",MultiLanguageConvertHelper.AgentExpressOut_Mappings_Bar_Addition_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_BarBusinessType_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.TransferGlobal_BarApplyFlagType_RegexDescription)}; break;
                    #endregion
                case AppliableFunctionType.AgentExpressOut4Bar:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeName_RegexDescription.Replace("20","58"), 
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeOpenBankName_RegexDescription.Replace("他行时",""),
                        string.Format("{0}{1}","中行时",MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo_RegexDescription.Replace("必须","")), 
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyCardType_RegexDescription, 
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_PayeeCertifyNo_RegexDescription,
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_Usage_RegexDescription,
                        MultiLanguageConvertHelper.AgentExpressOut_Mappings_Bar_Addition_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.UnitivePaymentRMB:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.UnitivePaymentRMB_PayerAccount_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentRMB_PayerName_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentRMB_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentRMB_PayeeName_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentRMB_BankType_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentRMB_PayeeCNAPS_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentRMB_PayeeOpenBankName_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentRMB_NominalPayerAccount_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentRMB_NominalPayerName_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentRMB_Amount_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentRMB_Purpose_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentRMB_UnitivePaymentType_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentRMB_OrderPayDate_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentRMB_CustomerBusinissNo_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentRMB_TransferChanelType_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentRMB_IsTipPayee_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentRMB_TipPayeePhone_RegexDescription  }; break;
                    #endregion
                case AppliableFunctionType.UnitivePaymentFC:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.UnitivePaymentFC_PayerAccount_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_PayerName_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_NominalPayerName_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_NominalPayerAccount_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_CashType_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_PayeeName_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_PayeeOpenBankName_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_OrgCode_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_OpenBankAddress_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_PayeeOpenBankSwiftCode_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_CorrespondentBankName_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_CorrespondentBankSwiftCode_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_CorrespondentBankAddress_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_PayeeAccountInCorrespondentBank_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_Address_RegexDescription, 
                        //MultiLanguageConvertHelper.UnitivePaymentFC_AccountBankType_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_CustomerBusinissNo_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_NominalPayerAddress_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_AssumeFeeType_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_Purpose_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_OrderPayDate_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_Addtion_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_CodeofCountry_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_IsNoSavePay_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_UnitivePaymentType_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_PaymentNature_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_TransactionCode1_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_TransactionCode2_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_IPPSMoneyTypeAmount1_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_IPPSMoneyTypeAmount2_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_TransactionAddtion1_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_TransactionAddtion2_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_IsPayOffLineString_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_ContractNo_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_InvoiceNo_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_BatchNoOrTNoOrSerialNo_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_ApplicantName_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_Contactnumber_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_SendPriority_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_realPayAddress_RegexDescription, 
                        MultiLanguageConvertHelper.UnitivePaymentFC_PaymentCountryOrArea_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_PayeeAccountType_RegexDescription,
                        MultiLanguageConvertHelper.UnitivePaymentFC_FCPayeeAccountType_RegexDescription
                    }; break;
                    #endregion
                case AppliableFunctionType.VirtualAccountTransfer:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Virtual_AccountOut_RegexDescription,
                        MultiLanguageConvertHelper.Virtual_NameOut_RegexDescription,
                        MultiLanguageConvertHelper.Virtual_AccountIn_RegexDescription,
                        MultiLanguageConvertHelper.Virtual_NameIn_RegexDescription,
                        MultiLanguageConvertHelper.Virtual_CashType_RegexDescription,
                        MultiLanguageConvertHelper.Virtual_Amount_RegexDescription,
                         MultiLanguageConvertHelper.Virtual_Pursion_RegexDescription,
                         MultiLanguageConvertHelper.Virtual_CustomerBusinissNo_RegexDescription,}; break;
                    #endregion
                case AppliableFunctionType.PreproccessTransfer:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Preproccess_PreproccessName_RegexDescription, 
                        MultiLanguageConvertHelper.Preproccess_PreproccessAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Preproccess_PreproccessAmount_RegexDescription, 
                        MultiLanguageConvertHelper.Preproccess_CashType_RegexDescription, 
                        MultiLanguageConvertHelper.Preproccess_MainAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Preproccess_TradeSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Preproccess_BatchTradeSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Preproccess_InvolvedName_RegexDescription, 
                        MultiLanguageConvertHelper.Preproccess_InvolvedAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Preproccess_TradeDate_RegexDescription, 
                        MultiLanguageConvertHelper.Preproccess_Content_RegexDescription, 
                        MultiLanguageConvertHelper.Preproccess_VirtualAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Preproccess_TradeAmount_RegexDescription }; break;
                    #endregion
                case AppliableFunctionType.BatchReimbursement:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.BatchReimbursement_CardNo_RegexDescription, 
                        MultiLanguageConvertHelper.BatchReimbursement_PayAmount_RegexDescription, 
                        MultiLanguageConvertHelper.BatchReimbursement_PayDateTime_RegexDescription, 
                        MultiLanguageConvertHelper.BatchReimbursement_PayPassword_RegexDescription, 
                        MultiLanguageConvertHelper.BatchReimbursement_ReimburseAmount_RegexDescription, 
                        MultiLanguageConvertHelper.BatchReimbursement_Usage_RegexDescription }; break;
                    #endregion
                default: break;
            }
            return result;
        }

        public static List<string> GetRegexDescription(FunctionInSettingType item)
        {

            List<string> result = new List<string>();
            switch (item)
            {
                case FunctionInSettingType.PayeeMg:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_BankType_RegexDescription,
                        string.Format("非{0}",MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_SerialNo_RegexDescription), 
                        MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Account_RegexDescription, 
                        MultiLanguageConvertHelper.Settings_PayeeMsg_Select_AccountType_RegexDescription, 
                        MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Name_RegexDescription, 
                        MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_OpenBankName_RegexDescription, 
                        string.Format("非{0}",MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_OpenBankNo_RegexDescription),
                        MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_ClearBankName_RegexDescription, 
                        string.Format("非{0}",MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_ClearBankNo_RegexDescription),
                        MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_CadeType_RegexDescription, 
                        MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_CadeNumber_RegexDescription, 
                        MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Address_RegexDescription, 
                        MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Email_RegexDescription, 
                        MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Telephone_RegexDescription, 
                        MultiLanguageConvertHelper.Settings_PayeeMsg_Payee_Fax_RegexDescription,}; break;
                    #endregion
                default: break;
            }
            return result;
        }

        public static List<string> GetBatchRegexDescription(AppliableFunctionType item)
        {
            List<string> result = new List<string>();
            switch (item)
            {
                case AppliableFunctionType.AgentExpressOut:
                    result = new List<string> {
                        @"必输项.格式：长度=1位",
                        @"",
                        @"必输项.格式：长度<=25位",
                        @"必输项.格式：长度=2位",
                        @"必输项.格式：长度=8位，日期格式为：YYYYMMDD.此日期须大于当前日期且不能超过提交委托日期起一个月.",
                        @"非必输.格式：长度<=16位，客户应用系统自己产生的业务编号，或客户自己填写的号.如果不为空判断是否重复.",
                        @"非必输.格式：长度<=80位"
                    };
                    break;
                case AppliableFunctionType.AgentExpressIn:
                    result = new List<string> {
                        @"",
                        @"",
                        @"必输项.格式：长度<=25位",
                        @"必输项.格式：长度=2位",
                        @"必输项.格式：长度=8位，日期格式为：YYYY-MM-DD.此日期须大于当前日期且不能超过提交委托日期起一个月.",
                        @"非必输.格式：长度<=16位，客户应用系统自己产生的业务编号，或客户自己填写的号.如果不为空判断是否重复.",
                        @"非必输.格式：长度<=80位"
                    };
                    break;
                case AppliableFunctionType.AgentNormalOut:
                    result = new List<string> {
                        @"",
                        @"必输项.格式：长度<=35位.",
                        @"非必输.格式：长度<=16位，客户应用系统自己产生的业务编号，或客户自己填写的号.如果不为空判断是否重复.",
                        @"必输项.格式：长度=8位，日期格式为：YYYY-MM-DD.此日期须大于当前日期且不能超过提交委托日期起一个月.",
                        @"必输项.格式：长度=1位.1 - 借记卡或存折，4 - QCC（其他代发业务4-QCC及信用卡），6-他行卡.",
                        @"必输项.格式：长度=5位,数字，且4打头",
                        @"必输项.格式：长度=1位.0 – 工资类（代发工资业务必填写0）,1 - 其他类（其他代发业务必填写1）.",
                        @"非必输.格式：长度<=80位"
                    };
                    break;
                case AppliableFunctionType.AgentNormalIn:
                    result = new List<string> {
                        @"",
                        @"必输项.格式：长度<=35位.",
                        @"非必输.格式：长度<=16位，客户应用系统自己产生的业务编号，或客户自己填写的号.如果不为空判断是否重复.",
                        @"必输项.格式：长度=8位，日期格式为：YYYY-MM-DD.此日期须大于当前日期且不能超过提交委托日期起一个月.",
                        @"必输项.格式：长度=1位.1 - 借记卡或存折，6-他行卡.",
                        @"必输项.格式：长度=5位,数字，且4打头",
                        @"非必输.格式：长度<=80位"
                    };
                    break;
                default: break;
            }
            return result;
        }

        public static void Init()
        {
            try
            {
                InitBaseSetting();
                InitCommonField();
                InitMappingRelation();
                InitDataFieldsDescription();
                InitMultiLanguageMsg();
            }
            catch { }
        }
    }
}
