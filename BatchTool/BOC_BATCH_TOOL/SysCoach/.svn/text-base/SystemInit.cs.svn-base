using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.ConvertHelper;
using CommonClient.Entities;

namespace CommonClient.SysCoach
{
    public class SystemInit
    {
        #region 单例
        private static object lock_obj = new object();
        private static SystemInit m_instance;
        /// <summary>
        /// 单一实例
        /// </summary>
        public static SystemInit Instance
        {
            get
            {
                if (null == m_instance)
                {
                    lock (lock_obj)
                    {
                        if (null == m_instance)
                        {
                            lock (lock_obj)
                            {
                                m_instance = new SystemInit();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        public SystemInit()
        { }

        public void CheckInit()
        {
            foreach (var aft in Utilities.PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
            {
                if (aft == AppliableFunctionType._Empty) continue;
                Entities.MappingsRelationSettings mrs = GetMappingRelation(aft);
                foreach (var field in mrs.FieldsMappings)
                {
                    if (!SystemSettings.Instance.BatchMappingSettings.ContainsKey(aft))
                        SystemSettings.Instance.BatchMappingSettings.Add(aft, new Entities.MappingsRelationSettings());
                    if (!SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings.ContainsKey(field.Key) && !string.IsNullOrEmpty(field.Key))
                        SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings.Add(field.Key, field.Value);
                }
            }
        }

        public void InitBaseSetting()
        {
            if (null == SystemSettings.Instance.CurrentLanguage) SystemSettings.Instance.CurrentLanguage = EnumTypes.UILang.CHS;
            if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
                SystemSettings.Instance.AppliableTypes = EnumTypes.AppliableFunctionType.TransferWithCorp | EnumTypes.AppliableFunctionType.AgentExpressOut;
            SystemSettings.Instance.IsMatchPassword4ShortProxyOut = false;
            SystemSettings.Instance.ShortProxyOutPassword = string.Empty;
            SystemSettings.Instance.IsMatchPassword4TransferForeignMoney = false;
            SystemSettings.Instance.TransferForeignMoneyPassword = string.Empty;
            SystemSettings.Instance.IsMatchPassword4TransferOverCountry = false;
            SystemSettings.Instance.TransferOverCountryPassword = string.Empty;
        }

        public void InitCommonField()
        {
            SystemSettings.Instance.CommonFieldList = new Dictionary<EnumTypes.AppliableFunctionType, EnumTypes.CommonFieldType>();
            SystemSettings.Instance.CommonFieldList.Add(AppliableFunctionType.TransferWithIndiv, CommonFieldType.Empty);
        }

        public void InitMappingRelation()
        {
            if (null == SystemSettings.Instance.BatchMappingSettings)
                SystemSettings.Instance.BatchMappingSettings = new Dictionary<AppliableFunctionType, Entities.MappingsRelationSettings>();
            foreach (var item in Utilities.PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
            {
                if (item == AppliableFunctionType._Empty) continue;
                if (!SystemSettings.Instance.BatchMappingSettings.ContainsKey(item))
                    SystemSettings.Instance.BatchMappingSettings.Add(item, GetMappingRelation(item));
                else
                {
                    if (SystemSettings.Instance.BatchMappingSettings[item].FieldsMappings.Count == 0)
                        SystemSettings.Instance.BatchMappingSettings[item] = GetMappingRelation(item);
                    else
                    {
                        Entities.MappingsRelationSettings mrs = GetMappingRelation(item);
                        if (SystemSettings.Instance.BatchMappingSettings[item].FieldsMappings.Count != mrs.FieldsMappings.Count)
                            SystemSettings.Instance.BatchMappingSettings[item] = GetMappingRelation(item);
                    }
                }
            }

            if (!SystemSettings.Instance.BatchSettingsMappingSettings.ContainsKey(FunctionInSettingType.PayeeMg))
                SystemSettings.Instance.BatchSettingsMappingSettings.Add(FunctionInSettingType.PayeeMg, GetMappingRelation(FunctionInSettingType.PayeeMg));
            else
            {
                if (SystemSettings.Instance.BatchSettingsMappingSettings[FunctionInSettingType.PayeeMg].FieldsMappings.Count == 0)
                    SystemSettings.Instance.BatchSettingsMappingSettings[FunctionInSettingType.PayeeMg] = GetMappingRelation(FunctionInSettingType.PayeeMg);
                else
                {
                    Entities.MappingsRelationSettings mrs = GetMappingRelation(FunctionInSettingType.PayeeMg);
                    if (SystemSettings.Instance.BatchSettingsMappingSettings[FunctionInSettingType.PayeeMg].FieldsMappings.Count != mrs.FieldsMappings.Count)
                        SystemSettings.Instance.BatchSettingsMappingSettings[FunctionInSettingType.PayeeMg] = GetMappingRelation(FunctionInSettingType.PayeeMg);
                }
            }
        }

        public void InitDataFieldsDescription()
        {
            SystemSettings.Instance.BatchRegexDescriptions = new Dictionary<AppliableFunctionType, List<string>>();
            SystemSettings.Instance.RegexDescriptions = new Dictionary<AppliableFunctionType, List<string>>();

            foreach (var item in Utilities.PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
            {
                if (item == AppliableFunctionType._Empty) continue;
                if (!SystemSettings.Instance.BatchRegexDescriptions.ContainsKey(item))
                    SystemSettings.Instance.BatchRegexDescriptions.Add(item, GetBatchRegexDescription(item));
                if (!SystemSettings.Instance.RegexDescriptions.ContainsKey(item))
                    SystemSettings.Instance.RegexDescriptions.Add(item, GetRegexDescription(item));
            }

            if (!SystemSettings.Instance.BatchSettingsMappingSettings.ContainsKey(FunctionInSettingType.PayeeMg))
            {
                SystemSettings.Instance.BatchSettingsMappingSettings.Add(FunctionInSettingType.PayeeMg, GetMappingRelation(FunctionInSettingType.PayeeMg));
                SystemSettings.Instance.RegexSettingsDescriptions.Add(FunctionInSettingType.PayeeMg, GetRegexDescription(FunctionInSettingType.PayeeMg));
            }
        }

        public void InitMultiLanguageMsg()
        {

        }

        public Entities.MappingsRelationSettings GetMappingRelation(AppliableFunctionType aft)
        {
            Entities.MappingsRelationSettings mrs = new Entities.MappingsRelationSettings { MaxCountPerOperation = CommonInformations.Instance.GetFunctionMaximum(aft), SeperateChar = string.Empty };
            switch (aft)
            {
                case AppliableFunctionType.TransferWithIndiv:
                case AppliableFunctionType.TransferWithCorp:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_CNAPSNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayFeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_Addtion, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_OperateOrder, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_Email, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_IsBOCFlag, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_Mappings_CustomerRef, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.AgentExpressOut:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_PayeeBankName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_PayerName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_PayerAccount, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_Usege, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_PayDate, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_CutomerRef, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_Addtion, string.Empty);

                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Usage, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.AgentExpressIn:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Batch_PayerBankName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Batch_PayeeName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Batch_PayeeAccount, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Batch_Usege, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Batch_PayDate, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Batch_CutomerRef, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Batch_Addtion, string.Empty);

                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerOpenBankNoOrCNAPSNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_SerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Usage, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.AgentNormalOut:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_PayerName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_PayerAccount, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_CustomerRef, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_PayDate, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_CardType, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_BankLinkNo, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_Usege, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Batch_Addtion, string.Empty);

                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_BankLinkNoOrCNAPSNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeCertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeCertifyNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Usege, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.AgentNormalIn:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Batch_PayeeName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Batch_PayeeAccount, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Batch_CustomerRef, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Batch_PayDate, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Batch_CardType, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Batch_BankLinkNo, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Batch_Addtion, string.Empty);

                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_BankLinkNoOrCNAPSNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Usege, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_SerialNo, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.TransferOverBankOut:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeClearBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_CutomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayFeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_Addtion, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_Email, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_OperateOrder, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.TransferOverBankIn:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayProtecolNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_BusinessType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_CutomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_Addtion, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayDateTime, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.ElecTicketRemit:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_TicketType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_RemitDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_EndDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_RemitAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_CanChange, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_CanAutoTipExchange, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_CanAutoReceiveTicket, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_Note, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.ElecTicketBackNote:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Account, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_TicketSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Note, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.ElecTicketPayMoney:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Account, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_TicketSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ClearType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyPercent, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_IsContainMoney, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ProtocolMoneyPercent, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ContactNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Note, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.ElecTicketTipExchange:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Account, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_TicketSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ContactNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Note, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.ElecTicketPool:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_CustomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_ElecTicketSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_PreBackNotedPerson, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDateOperate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.ElecTicketPool_BusinessType, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.TransferOverCountry:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_SendPriority, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentCashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CutomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCodeofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeNameofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_AssumeFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_IsPayOffLine, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.TransferForeignMoney:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_SendPriority, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentCashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CutomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCodeofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeNameofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_AssumeFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentPropertyType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_IsPayOffLine, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ContractOrOrderNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_OrderDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_OrderAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_DeliveryDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_SettlementType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_TaxInvoiceNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ReceiptNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_RiskTakingLetterNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_GoodsDesc, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ApplyAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ApplyDays, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_AgrementNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_InterestFloatingPercent, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingApply_InterestFloatType, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.PurchaserOrder:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_ERPCode_Seller, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerNo_Seller, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_PayDate_Seller, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.SellerOrder:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerName_Purchase, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_PayDate_Purchase, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingOrderMgr_PayAmountForThisTime, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_ContractNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Seller, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Seller, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_EndDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_StartDate, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.BillofDebtReceivableSeller:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_ContractNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Purchase, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Purchase, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_EndDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingBill_StartDate, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_AmountThisTime, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.InitiativeAllot:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.InitiativeAllot_Batch_PayDate, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.InitiativeAllot_Batch_ProtecolNo, string.Empty);

                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountOut, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.InitiativeAllot_NameOut, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountIn, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.InitiativeAllot_NameIn, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.InitiativeAllot_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.InitiativeAllot_Addition, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.TransferOverCountry4Bar:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_SendPriority, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentCashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CutomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCodeofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeNameofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankSwiftCode_Bar_OC, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankSwiftCode_Bar_OC, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_AssumeFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentPropertyType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_IsPayOffLine, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.TransferForeignMoney4Bar:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_SendPriority, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentCashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAccount, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAmount, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CutomerRef, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCodeofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeNameofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankSwiftCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankSwiftCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_AssumeFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentPropertyType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_IsPayOffLine, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccountProvince, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Business, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_BarBusinessType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.TransferGlobal_BarApplyFlagType, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.AgentExpressOut4Bar:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_PayeeBankName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_PayerName, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_PayerAccount, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_Usege, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_PayDate, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_CutomerRef, string.Empty);
                    mrs.BatchFieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_Addtion, string.Empty);

                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Usage, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.UnitivePaymentRMB:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_BankType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeCNAPS, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_NominalPayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_NominalPayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_Purpose, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_UnitivePaymentType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_OrderPayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_CustomerBusinissNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_TransferChanelType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_IsTipPayee, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_TipPayeePhone, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.UnitivePaymentFC:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OrgCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OpenBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankSwiftCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankSwiftCode, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccountInCorrespondentBank, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Address, string.Empty);
                    //mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_AccountBankType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CustomerBusinissNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Purpose, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OrderPayDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Addtion, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CodeofCountry, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IsNoSavePay, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_UnitivePaymentType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PaymentNature, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode1, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode2, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion1, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion2, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IsPayOffLineString, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ContractNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_InvoiceNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_BatchNoOrTNoOrSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ApplicantName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Contactnumber, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_SendPriority, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_realPayAddress, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PaymentCountryOrArea, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccountType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.UnitivePaymentFC_FCPayeeAccountType, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.VirtualAccountTransfer:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Virtual_AccountOut, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Virtual_NameOut, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Virtual_AccountIn, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Virtual_NameIn, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Virtual_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Virtual_Amount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Virtual_Pursion, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Virtual_CustomerBusinissNo, string.Empty);
                    break;
                    #endregion
                case AppliableFunctionType.PreproccessTransfer:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_PreproccessName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_PreproccessAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_PreproccessAmount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_CashType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_MainAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_TradeSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_BatchTradeSerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_InvolvedName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_InvolvedAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_TradeDate, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_Content, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_VirtualAccount, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Preproccess_TradeAmount, string.Empty);
                    break;
                    #endregion
                default: break;
            }
            return mrs;
        }

        public Entities.MappingsRelationSettings GetMappingRelation(FunctionInSettingType fst)
        {
            Entities.MappingsRelationSettings mrs = new Entities.MappingsRelationSettings { MaxCountPerOperation = int.MaxValue, SeperateChar = string.Empty };
            switch (fst)
            {
                case FunctionInSettingType.PayeeMg:
                    #region
                    mrs.BatchFieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings = new Dictionary<string, string>();
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_BankType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_SerialNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Account, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Select_AccountType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Name, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_OpenBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_ClearBankName, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_CertifyCardType, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_CertifyCardNo, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Address, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Email, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Telephone, string.Empty);
                    mrs.FieldsMappings.Add(MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Fax, string.Empty);
                    break;
                    #endregion
                default: break;
            }
            return mrs;
        }

        public List<string> GetRegexDescription(AppliableFunctionType item)
        {
            List<string> result = new List<string>();
            switch (item)
            {
                case AppliableFunctionType.TransferWithIndiv:
                case AppliableFunctionType.TransferWithCorp:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeOpenBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_CNAPSNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayerAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayFeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayDate_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_Addtion_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_OperateOrder_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_Email_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_IsBOCFlag_RegexDescription,
                        MultiLanguageConvertHelper.Instance.Transfer_Mappings_CustomerRef_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.AgentExpressOut:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyCardType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Usage_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.AgentExpressIn:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerOpenBankNoOrCNAPSNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyCardType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_SerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Usage_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.AgentNormalOut:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_BankLinkNoOrCNAPSNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeCertifyCardType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeCertifyNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Usege_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.AgentNormalIn:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayeeName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_BankLinkNoOrCNAPSNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayeeBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyCardType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Usege_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_SerialNo_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.TransferOverBankOut:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeClearBankNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayerAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_CutomerRef_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayFeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_Addtion_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayDate_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_Email_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_OperateOrder_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.TransferOverBankIn:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PaySerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_BusinessType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_CutomerRef_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_Addtion_RegexDescription,
                        MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayDateTime_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.ElecTicketRemit:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_TicketType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_Amount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_RemitDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_EndDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_RemitAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeOpenBankName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeOpenBankNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeOpenBankName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeOpenBankNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_CanChange_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_CanAutoTipExchange_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_CanAutoReceiveTicket_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_Note_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.ElecTicketBackNote:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Account_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_TicketSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedOpenBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedOpenBankNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Note_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.ElecTicketPayMoney:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Account_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_TicketSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ClearType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayDate_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyPercent_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_IsContainMoney_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ProtocolMoneyPercent_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_BillSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ContactNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Note_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.ElecTicketTipExchange:
                    #region
                    result = new List<string> { 
                        MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Account_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_TicketSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_BillSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ContactNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Note_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.ElecTicketPool:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_CustomerRef_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBank_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_ElecTicketSerialNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_Amount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeOpenBankName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeOpenBankNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_PreBackNotedPerson_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDateOperate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.ElecTicketPool_BusinessType_RegexDescription,}; break;
                    #endregion
                case AppliableFunctionType.TransferOverCountry:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_SendPriority_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentCashType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAmount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAmount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_CutomerRef_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCodeofCountry_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeNameofCountry_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName_RegexDescription.Replace("7","14").Replace("和中文","").Replace("非必输","必输"), 
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankSwiftCode,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankSwiftCode,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress_RegexDescription.Replace("7","14").Replace("和中文",""), 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote_RegexDescription.Replace("和中文","").Replace("50","140"), 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_AssumeFeeType_Country_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType_Country_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteF_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteS_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_IsPayOffLine_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo_RegexDescription.Replace("20","50"), 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone_RegexDescription }; break;
                    #endregion
                case AppliableFunctionType.TransferForeignMoney:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_SendPriority_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentCashType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAmount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAmount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_CutomerRef_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCodeofCountry_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeNameofCountry_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName_RegexDescription.Replace("非必输","必输"),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank_FM_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_AssumeFeeType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentPropertyType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_IsPayOffLine_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone_RegexDescription}; break;
                    #endregion
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ContractOrOrderNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_OrderDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_CashType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_OrderAmount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_DeliveryDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_SettlementType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_TaxInvoiceNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ReceiptNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_RiskTakingLetterNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_GoodsDesc_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ApplyAmount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ApplyDays_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_AgrementNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_InterestFloatingPercent_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingApply_InterestFloatType_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.PurchaserOrder:
                    #region
                    result = new List<string> { 
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CashType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_Amount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_ERPCode_Seller_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerNo_Seller_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_PayDate_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.SellerOrder:
                    #region
                    result = new List<string> { 
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CashType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_Amount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerName_Purchase_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_PayDate_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                    #region
                    result = new List<string> { 
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_Amount_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                case AppliableFunctionType.BillofDebtReceivableSeller:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.SpplyFinancingBill_Amount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillSerialNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CashType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingBill_ContractNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingBill_EndDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingBill_StartDate_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    #region
                    result = new List<string> { 
                        MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_BillSerialNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CashType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_AmountThisTime_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.InitiativeAllot:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountOut_RegexDescription,
                        MultiLanguageConvertHelper.Instance.InitiativeAllot_NameOut_RegexDescription,
                        MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountIn_RegexDescription,
                        MultiLanguageConvertHelper.Instance.InitiativeAllot_NameIn_RegexDescription,
                        MultiLanguageConvertHelper.Instance.InitiativeAllot_Amount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.InitiativeAllot_Addition_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.TransferOverCountry4Bar:
                    #region
                    result = new List<string>{ 
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_PayDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentType_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_SendPriority_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentCashType_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAmount_Bar_OC_RegexDescription,
                        string.Format("{0},{1}",MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount_Bar_OC_RegexDescription,"现汇账户与购汇账户二者选其一"),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount_Bar_OC_RegexDescription,
                        string.Format("{0},{1}",MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount_Bar_OC_RegexDescription,"现汇账户与购汇账户二者选其一"),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeAccount_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName_Bar_OC_RegexDescription.Replace("和中文",""),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress_Bar_OC_RegexDescription.Replace("和中文",""),
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_CutomerRef_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName_Bar_OC_RegexDescription.Replace("和中文",""),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress_Bar_OC_RegexDescription.Replace("和中文",""),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCodeofCountry_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeNameofCountry_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName_Bar_OC_RegexDescription.Replace("和中文","").Replace("非必输","必输"),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankSwiftCode_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress_Bar_OC_RegexDescription.Replace("和中文",""),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName_Bar_OC_RegexDescription.Replace("和中文",""),
                        string.Format("非{0}",MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankSwiftCode_Bar_OC_RegexDescription),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress_Bar_OC_RegexDescription.Replace("和中文",""),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote_Bar_OC_RegexDescription.Replace("和中文","").Replace("50","140"),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_AssumeFeeType_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType_RegexDescription,
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentPropertyType_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteF_Bar_OC_RegexDescription.Replace("100","50"),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteS_Bar_OC_RegexDescription.Replace("100","50"),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_IsPayOffLine_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo_Bar_OC_RegexDescription.Replace("20","35"),
                        MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName_Bar_OC_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone_Bar_OC_RegexDescription,};
                    break;
                    #endregion
                case AppliableFunctionType.TransferForeignMoney4Bar:
                    #region
                    result = new List<string> {
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_PayDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentType_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_SendPriority_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentCashType_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAmount_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount_Bar_FM_RegexDescription,
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount_RegexDescription,
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount_RegexDescription,
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAccount_RegexDescription,
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAmount_RegexDescription,
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode_Bar_FM_RegexDescription,
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName_RegexDescription,
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress_Bar_FM_RegexDescription.Replace("70","64")),
                        //MultiLanguageConvertHelper.Instance.TransferGlobal_CutomerRef_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount_Bar_FM_RegexDescription,
                        MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName_Bar_FM_RegexDescription.Replace("非必输","必输").Replace("70","64"),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress_Bar_FM_RegexDescription.Replace("70","64")),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCodeofCountry_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeNameofCountry_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName_Bar_FM_RegexDescription.Replace("非必输","必输")),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankSwiftCode_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName_Bar_FM_RegexDescription),
                        //string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankSwiftCode_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote_Bar_FM_RegexDescription.Replace("50","140")),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_AssumeFeeType_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentPropertyType_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_IsPayOffLine_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo_Bar_FM_RegexDescription.Replace("20","35")),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone_Bar_FM_RegexDescription),
                        string.Format("{0}{1}","中行时填写,",MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccountProvince_RegexDescription),
                        string.Format("{0}{1}","中行时填写,",MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyCardType_RegexDescription),
                        string.Format("{0}{1}","中行时填写,",MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo_RegexDescription),
                        string.Format("{0}{1}","中行时填写,",MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Usage_RegexDescription.Replace("非必输项","必输项")),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_BarBusinessType_RegexDescription),
                        string.Format("{0}{1}","他行时填写,",MultiLanguageConvertHelper.Instance.TransferGlobal_BarApplyFlagType_RegexDescription)}; break;
                    #endregion
                case AppliableFunctionType.AgentExpressOut4Bar:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeName_RegexDescription.Replace("20","58"), 
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankName_RegexDescription,
                        string.Format("{0}{1}","中行时",MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo_RegexDescription.Replace("必须","")), 
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyCardType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Usage_RegexDescription,}; break;
                    #endregion
                case AppliableFunctionType.UnitivePaymentRMB:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayerAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayerName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_BankType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeCNAPS_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeOpenBankName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_NominalPayerAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_NominalPayerName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_Amount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_Purpose_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_UnitivePaymentType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_OrderPayDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_CustomerBusinissNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_TransferChanelType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_IsTipPayee_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_TipPayeePhone_RegexDescription  }; break;
                    #endregion
                case AppliableFunctionType.UnitivePaymentFC:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerAccount_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CashType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankName_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OrgCode_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OpenBankAddress_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankSwiftCode_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankSwiftCode_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankAddress_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccountInCorrespondentBank_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Amount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Address_RegexDescription, 
                        //MultiLanguageConvertHelper.Instance.UnitivePaymentFC_AccountBankType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CustomerBusinissNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Purpose_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OrderPayDate_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Addtion_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CodeofCountry_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IsNoSavePay_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_UnitivePaymentType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PaymentNature_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode1_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode2_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion1_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion2_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IsPayOffLineString_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ContractNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_InvoiceNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_BatchNoOrTNoOrSerialNo_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ApplicantName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Contactnumber_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_SendPriority_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_realPayAddress_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PaymentCountryOrArea_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccountType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.UnitivePaymentFC_FCPayeeAccountType_RegexDescription
                    }; break;
                    #endregion
                case AppliableFunctionType.VirtualAccountTransfer:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.Virtual_AccountOut_RegexDescription,
                        MultiLanguageConvertHelper.Instance.Virtual_NameOut_RegexDescription,
                        MultiLanguageConvertHelper.Instance.Virtual_AccountIn_RegexDescription,
                        MultiLanguageConvertHelper.Instance.Virtual_NameIn_RegexDescription,
                        MultiLanguageConvertHelper.Instance.Virtual_CashType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.Virtual_Amount_RegexDescription,
                         MultiLanguageConvertHelper.Instance.Virtual_Pursion_RegexDescription,
                         MultiLanguageConvertHelper.Instance.Virtual_CustomerBusinissNo_RegexDescription,}; break;
                    #endregion
                case AppliableFunctionType.PreproccessTransfer:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.Preproccess_PreproccessName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Preproccess_PreproccessAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Preproccess_PreproccessAmount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Preproccess_CashType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Preproccess_MainAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Preproccess_TradeSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Preproccess_BatchTradeSerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Preproccess_InvolvedName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Preproccess_InvolvedAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Preproccess_TradeDate_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Preproccess_Content_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Preproccess_VirtualAccount_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Preproccess_TradeAmount_RegexDescription }; break;
                    #endregion
                default: break;
            }
            return result;
        }

        public List<string> GetRegexDescription(FunctionInSettingType item)
        {

            List<string> result = new List<string>();
            switch (item)
            {
                case FunctionInSettingType.PayeeMg:
                    #region
                    result = new List<string> {
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_BankType_RegexDescription,
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_SerialNo_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Account_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Select_AccountType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Name_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_OpenBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_ClearBankName_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_CadeType_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_CadeNumber_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Address_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Email_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Telephone_RegexDescription, 
                        MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Fax_RegexDescription,}; break;
                    #endregion
                default: break;
            }
            return result;
        }

        public List<string> GetBatchRegexDescription(AppliableFunctionType item)
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

        public void Init()
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
