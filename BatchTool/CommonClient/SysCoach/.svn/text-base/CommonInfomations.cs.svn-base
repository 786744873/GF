using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.Entities;
using CommonClient.EnumTypes;
using CommonClient.MatchFile;
using CommonClient.Utilities;
using System.IO;

namespace CommonClient.SysCoach
{
    public static class CommonInformations
    {
        public static void Init()
        {
            InitEventHandler();
            InitBaseSettings();
        }

        private static void InitEventHandler()
        {
            CommandCenter.OnAppliableEventHandler += new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler);
            CommandCenter.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.OnPayeeInfoEventHandler += new EventHandler<PayeeEventArgs>(CommandCenter_OnPayeeInfoEventHandler);
            CommandCenter.OnNoticeEventHandler += new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler);
            CommandCenter.OnFieldMappingEventHandler += new EventHandler<FieldMappingEventArgs>(CommandCenter_OnFieldMappingEventHandler);
            CommandCenter.OnPayeeInfo4TransferGlobalEventHandler += new EventHandler<Payee4TransferGlobalEventArgs>(CommandCenter_OnPayeeInfo4TransferGlobalEventHandler);
            if ((SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
            {
                CommandCenter.OnCommonDataEventHandler += new EventHandler<CommonDataEventArgs>(CommandCenter_OnCommonDataEventHandler);
                CommandCenter.OnEncryptionEventHandler += new EventHandler<EncryptionEventArgs>(CommandCenter_OnEncryptionEventHandler);
                CommandCenter.OnElecTicketRelateAccountEventHandler += new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler);
                CommandCenter.OnAgentExpressPayerEventHandler += new EventHandler<PayeeEventArgs>(CommandCenter_OnAgentExpressPayerEventHandler);
                CommandCenter.OnInitiativeAllotAccountEventHandler += new EventHandler<InitiativeAllotAccountEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler);
                CommandCenter.OnVirtualAccountAllotEventHandler += new EventHandler<VirtualAccountAllotEventArgs>(CommandCenter_OnVirtualAllotAccountEventHandler);
            }
        }

        static void CommandCenter_OnAgentExpressPayerEventHandler(object sender, PayeeEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                int index = SystemSettings.AgentExpressPayerList.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name);
                if (index >= 0) return;
                index = SystemSettings.AgentExpressPayerList.FindIndex(o => o.SerialNo == e.PayeeInfo.SerialNo && !string.IsNullOrEmpty(e.PayeeInfo.SerialNo));
                if (index >= 0) return;

                if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.AgentExpressPayerList.Count)
                    SystemSettings.AgentExpressPayerList.Insert(e.RowIndex - 1, e.PayeeInfo);
                else
                    SystemSettings.AgentExpressPayerList.Add(e.PayeeInfo);
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                int index = SystemSettings.AgentExpressPayerList.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName);
                if (index >= 0 && index != e.RowIndex - 1) return;
                index = SystemSettings.AgentExpressPayerList.FindIndex(o => o.SerialNo == e.PayeeInfo.SerialNo && !string.IsNullOrEmpty(e.PayeeInfo.SerialNo));
                if (index >= 0 && index != e.RowIndex - 1) return;

                SystemSettings.AgentExpressPayerList[e.RowIndex - 1] = e.PayeeInfo;
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.AgentExpressPayerList.FindAll(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName).Count > 0)
                {
                    SystemSettings.AgentExpressPayerList.RemoveAt(e.RowIndex);
                }
            }
            else if (OperatorCommandType.CombineData == e.Command)
            {
                foreach (var item in e.PayeeList)
                {
                    if (SystemSettings.AgentExpressPayerList.FindIndex(o => o.Account == item.Account && o.Name == item.Name && o.OpenBankName == e.PayeeInfo.OpenBankName) >= 0)
                        continue;
                    if (SystemSettings.AgentExpressPayerList.Exists(o => o.SerialNo == item.SerialNo && !string.IsNullOrEmpty(item.SerialNo)))
                        continue;
                    SystemSettings.AgentExpressPayerList.Add(item);
                }
            }
        }

        static void CommandCenter_OnPayeeInfo4TransferGlobalEventHandler(object sender, Payee4TransferGlobalEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                int index = SystemSettings.PayeeInfo4TransferGlobalList.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name);
                if (index >= 0) return;

                if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.PayeeInfo4TransferGlobalList.Count)
                    SystemSettings.PayeeInfo4TransferGlobalList.Insert(e.RowIndex - 1, e.PayeeInfo);
                else
                    SystemSettings.PayeeInfo4TransferGlobalList.Add(e.PayeeInfo);
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                int index = SystemSettings.PayeeInfo4TransferGlobalList.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name);
                if (index >= 0 && index != e.RowIndex - 1) return;

                SystemSettings.PayeeInfo4TransferGlobalList[e.RowIndex - 1] = e.PayeeInfo;
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.PayeeInfo4TransferGlobalList.FindAll(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name).Count > 0)
                {
                    SystemSettings.PayeeInfo4TransferGlobalList.RemoveAt(e.RowIndex);
                }
            }
            else if (OperatorCommandType.CombineData == e.Command)
            {
                foreach (var item in e.PayeeList)
                {
                    if (SystemSettings.PayeeInfo4TransferGlobalList.FindIndex(o => o.Account == item.Account && o.Name == item.Name) >= 0)
                        continue;
                    SystemSettings.PayeeInfo4TransferGlobalList.Add(item);
                }
            }
        }

        static void CommandCenter_OnElecTicketRelateAccountEventHandler(object sender, ElecTicketRelateAccountEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                int index = SystemSettings.ElecTicketRelationAccountList.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                if (index >= 0) return;

                if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.ElecTicketRelationAccountList.Count)
                    SystemSettings.ElecTicketRelationAccountList.Insert(e.RowIndex - 1, e.RelationAccount);
                else
                    SystemSettings.ElecTicketRelationAccountList.Add(e.RelationAccount);
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                int index = SystemSettings.ElecTicketRelationAccountList.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                if (index >= 0 && index != e.RowIndex - 1) return;

                SystemSettings.ElecTicketRelationAccountList[e.RowIndex - 1] = e.RelationAccount;
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.ElecTicketRelationAccountList.FindAll(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name).Count > 0)
                {
                    SystemSettings.ElecTicketRelationAccountList.RemoveAt(e.RowIndex);
                }
            }
            else if (OperatorCommandType.CombineData == e.Command)
            {
                foreach (var item in e.RelationAccountList)
                {
                    if (SystemSettings.ElecTicketRelationAccountList.FindIndex(o => o.Account == item.Account && o.Name == item.Name) >= 0)
                        continue;
                    SystemSettings.ElecTicketRelationAccountList.Add(item);
                }
            }
        }

        private static void InitBaseSettings()
        {
            SystemSettings.PayerList = DataFileHelper.GetPayerList();
            SystemSettings.PayeeList = DataFileHelper.GetPayeeList(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\PayeeInfo.xml"));
            SystemSettings.AgentExpressPayerList = DataFileHelper.GetPayeeList(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\AgentExpressPayerList.xml"));
            SystemSettings.Notices = DataFileHelper.GetNoteList();
            SystemSettings.PayeeInfo4TransferGlobalList = DataFileHelper.GetPayeeTransferGlobalList();
            if ((SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
            {
                SystemSettings.ElecTicketRelationAccountList = DataFileHelper.GetElecTicketRelationAccountList();
                SystemSettings.InitiativeAllotAccountList = DataFileHelper.GetInitiativeAllotAccountList();
                SystemSettings.VirtualAllotAccountList = DataFileHelper.GetVirtualAllotAccountList();
                SystemSettings.CommonFieldList = DataFileHelper.GetCommonFieldList();
            }
            if (SystemSettings.CommonFieldList.Count == 0) SystemInit.InitCommonField();

            SystemSettings.BatchMappingSettings = DataFileHelper.GetBatchMappingSetting();
            if (SystemSettings.BatchMappingSettings.Count != PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList.Count) SystemInit.InitMappingRelation();

            DataFileHelper.GetBaseSettings();
            SystemInit.InitDataFieldsDescription();

            if ((SystemSettings.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
            {
                DataFileHelper.GetCity2ProvinceBarList();
            }
        }

        static void CommandCenter_OnFieldMappingEventHandler(object sender, FieldMappingEventArgs e)
        {
            if (OperatorCommandType.MappingSettingResolve == e.Command)
            {
                if (e.AppType == AppliableFunctionType._Empty)
                {
                    if (e.BatchAppType == FunctionInSettingType.PayeeMg)
                    {
                        if (!SystemSettings.BatchSettingsMappingSettings.ContainsKey(e.BatchAppType)) SystemSettings.BatchSettingsMappingSettings.Add(e.BatchAppType, e.Mappings);
                        else SystemSettings.BatchSettingsMappingSettings[e.BatchAppType] = e.Mappings;
                    }
                }
                else
                {
                    if (!SystemSettings.BatchMappingSettings.ContainsKey(e.AppType)) SystemSettings.BatchMappingSettings.Add(e.AppType, e.Mappings);
                    else SystemSettings.BatchMappingSettings[e.AppType] = e.Mappings;
                }
            }
        }

        static void CommandCenter_OnEncryptionEventHandler(object sender, EncryptionEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                switch (e.AppType)
                {
                    case AppliableFunctionType.AgentExpressOut:
                        SystemSettings.IsMatchPassword4ShortProxyOut = e.IsSetPassword;
                        SystemSettings.ShortProxyOutPassword = e.Password;
                        break;
                    case AppliableFunctionType.TransferOverCountry:
                        SystemSettings.IsMatchPassword4TransferOverCountry = e.IsSetPassword;
                        SystemSettings.TransferOverCountryPassword = e.Password;
                        break;
                    case AppliableFunctionType.TransferForeignMoney:
                        SystemSettings.IsMatchPassword4TransferForeignMoney = e.IsSetPassword;
                        SystemSettings.TransferForeignMoneyPassword = e.Password;
                        break;
                }
            }
        }

        static void CommandCenter_OnCommonDataEventHandler(object sender, CommonDataEventArgs e)
        {
            if (OperatorCommandType.CommonFieldResolve == e.Command)
            {
                //SystemSettings.CommonFieldList = e.CommonFields;

                foreach (var item in e.CommonFields)
                {
                    if (!SystemSettings.CommonFieldList.ContainsKey(item.Key))
                        SystemSettings.CommonFieldList.Add(item.Key, item.Value);
                    else
                    {
                        if ((SystemSettings.CommonFieldList[item.Key] & item.Value) != item.Value)
                            SystemSettings.CommonFieldList[item.Key] = SystemSettings.CommonFieldList[item.Key] | item.Value;
                    }
                }
            }
            else if (OperatorCommandType.CommonFieldLockHide == e.Command)
            {
                foreach (var item in e.CommonFields)
                {
                    if (SystemSettings.CommonFieldList.ContainsKey(item.Key) && SystemSettings.CommonFieldList[item.Key] != CommonFieldType.Empty)
                        SystemSettings.CommonFieldList[item.Key] = CommonFieldType.Empty;
                }
            }
        }

        static void CommandCenter_OnNoticeEventHandler(object sender, NoticeEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command || OperatorCommandType.Edit == e.Command)
            {
                if (null != e.Notice)
                {
                    if (!SystemSettings.Notices.ContainsKey(e.OwnerType))
                        SystemSettings.Notices.Add(e.OwnerType, new List<NoticeInfo>());
                    if (SystemSettings.Notices[e.OwnerType].FindAll(o => o.Content == e.Notice.Content).Count > 0)
                    {
                        NoticeInfo notice = SystemSettings.Notices[e.OwnerType].Find(o => o.Content == e.Notice.Content);
                        notice.Content = e.Notice.Content;
                    }
                    else if (SystemSettings.Notices[e.OwnerType].FindAll(o => string.IsNullOrEmpty(o.Content)).Count > 0)
                    {
                        int index = SystemSettings.Notices[e.OwnerType].FindIndex(o => string.IsNullOrEmpty(o.Content));
                        if (index >= 0)
                        {
                            e.Notice.RowIndex = index + 1;
                            SystemSettings.Notices[e.OwnerType][index] = e.Notice;
                        }
                    }
                    else if (SystemSettings.Notices[e.OwnerType].Count < 10)
                    {
                        e.Notice.RowIndex = SystemSettings.Notices[e.OwnerType].Count;
                        SystemSettings.Notices[e.OwnerType].Add(e.Notice);
                    }
                }
                else if (e.NoticeList.Count >= 0)
                {
                    if (!SystemSettings.Notices.ContainsKey(e.OwnerType))
                        SystemSettings.Notices.Add(e.OwnerType, new List<NoticeInfo>());
                    SystemSettings.Notices[e.OwnerType] = e.NoticeList;
                }
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.PayeeList.FindAll(o => o.Account == e.Notice.Content).Count > 0)
                {
                    int index = SystemSettings.Notices[e.OwnerType].FindIndex(o => o.Content == e.Notice.Content);
                    SystemSettings.Notices[e.OwnerType][index].Content = string.Empty;
                }
            }
        }

        static void CommandCenter_OnPayeeInfoEventHandler(object sender, PayeeEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                int index = SystemSettings.PayeeList.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName);
                if (index >= 0) return;

                if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.PayeeList.Count)
                    SystemSettings.PayeeList.Insert(e.RowIndex - 1, e.PayeeInfo);
                else
                    SystemSettings.PayeeList.Add(e.PayeeInfo);
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                int index = SystemSettings.PayeeList.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName);
                if (index >= 0 && index != e.RowIndex - 1) return;

                SystemSettings.PayeeList[e.RowIndex - 1] = e.PayeeInfo;
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.PayeeList.FindAll(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName).Count > 0)
                {
                    SystemSettings.PayeeList.RemoveAt(e.RowIndex);
                }
            }
            else if (OperatorCommandType.CombineData == e.Command)
            {
                foreach (var item in e.PayeeList)
                {
                    if (SystemSettings.PayeeList.FindIndex(o => o.Account == item.Account && o.Name == item.Name && o.OpenBankName == item.OpenBankName) >= 0)
                        continue;
                    SystemSettings.PayeeList.Add(item);
                }
            }
        }

        static void CommandCenter_OnPayerInfoEventHandler(object sender, PayerEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                if (SystemSettings.PayerList.FindAll(o => o.Account == e.PayerInfo.Account && o.Name == e.PayerInfo.Name).Count > 0)
                {
                    PayerInfo payer = SystemSettings.PayerList.Find(o => o.Account == e.PayerInfo.Account && o.Name == e.PayerInfo.Name);
                    payer = e.PayerInfo;
                }
                else
                {
                    if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.PayerList.Count)
                        SystemSettings.PayerList.Insert(e.RowIndex - 1, e.PayerInfo);
                    else
                        SystemSettings.PayerList.Add(e.PayerInfo);
                }
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                if (SystemSettings.PayerList.Count >= e.RowIndex)
                {
                    SystemSettings.PayerList[e.RowIndex - 1] = e.PayerInfo;
                }
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.PayerList.FindAll(o => o.Account == e.PayerInfo.Account && o.Name == e.PayerInfo.Name).Count > 0)
                {
                    PayerInfo payer = SystemSettings.PayerList.Find(o => o.Account == e.PayerInfo.Account && o.Name == e.PayerInfo.Name);
                    SystemSettings.PayerList.Remove(payer);
                }
            }
        }

        static void CommandCenter_OnAppliableEventHandler(object sender, AppliableEventArgs e)
        {
            if (OperatorCommandType.AppVisiableResolve == e.Command)
            {
                SystemSettings.AppliableTypes = e.AppVisiable;
                SystemSettings.AppliableTypes4Bar = e.AppVisiableBar;
                //CommandCenter.ResolveMoveMenu(OperatorCommandType.View, 0, 0, 0, 0, 0, OperatorCommandType.Empty);
            }
        }

        static void CommandCenter_OnInitiativeAllotAccountEventHandler(object sender, InitiativeAllotAccountEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                if (SystemSettings.InitiativeAllotAccountList.FindAll(o => o.Account == e.InitiativeAllotAccount.Account).Count > 0)
                {
                    InitiativeAllotAccount payer = SystemSettings.InitiativeAllotAccountList.Find(o => o.Account == e.InitiativeAllotAccount.Account);
                    payer = e.InitiativeAllotAccount;
                }
                else
                {
                    if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.InitiativeAllotAccountList.Count)
                        SystemSettings.InitiativeAllotAccountList.Insert(e.RowIndex - 1, e.InitiativeAllotAccount);
                    else
                        SystemSettings.InitiativeAllotAccountList.Add(e.InitiativeAllotAccount);
                }
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                if (SystemSettings.InitiativeAllotAccountList.Count >= e.RowIndex)
                {
                    SystemSettings.InitiativeAllotAccountList[e.RowIndex - 1] = e.InitiativeAllotAccount;
                }
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.InitiativeAllotAccountList.FindAll(o => o.Account == e.InitiativeAllotAccount.Account).Count > 0)
                {
                    InitiativeAllotAccount payer = SystemSettings.InitiativeAllotAccountList.Find(o => o.Account == e.InitiativeAllotAccount.Account);
                    SystemSettings.InitiativeAllotAccountList.Remove(payer);
                }
            }
        }

        static void CommandCenter_OnVirtualAllotAccountEventHandler(object sender, VirtualAccountAllotEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                if (SystemSettings.VirtualAllotAccountList.FindAll(o => o.Account == e.VirtualAllotAccount.Account).Count > 0)
                {
                    VirtualAccountInfo payer = SystemSettings.VirtualAllotAccountList.Find(o => o.Account == e.VirtualAllotAccount.Account);
                    payer = e.VirtualAllotAccount;
                }
                else
                {
                    if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.InitiativeAllotAccountList.Count)
                        SystemSettings.VirtualAllotAccountList.Insert(e.RowIndex - 1, e.VirtualAllotAccount);
                    else
                        SystemSettings.VirtualAllotAccountList.Add(e.VirtualAllotAccount);
                }
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                if (SystemSettings.VirtualAllotAccountList.Count >= e.RowIndex)
                {
                    SystemSettings.VirtualAllotAccountList[e.RowIndex - 1] = e.VirtualAllotAccount;
                }
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.VirtualAllotAccountList.FindAll(o => o.Account == e.VirtualAllotAccount.Account).Count > 0)
                {
                    VirtualAccountInfo payer = SystemSettings.VirtualAllotAccountList.Find(o => o.Account == e.VirtualAllotAccount.Account);
                    SystemSettings.VirtualAllotAccountList.Remove(payer);
                }
            }
        }

        public static bool CanClearItem(AppliableFunctionType aft, CommonFieldType cft)
        {
            return !(SystemSettings.CommonFieldList.ContainsKey(aft) && ((SystemSettings.CommonFieldList[aft] & cft) == cft));
        }

        public static bool CheckMappingSetting(AppliableFunctionType aft, FunctionInSettingType fst)
        {
            bool flag = false;
            if (aft != AppliableFunctionType._Empty)
                flag = SystemSettings.BatchMappingSettings[aft].IsSetFields;
            else if (aft == AppliableFunctionType._Empty && fst == FunctionInSettingType.PayeeMg)
                flag = SystemSettings.BatchSettingsMappingSettings[fst].IsSetFields;

            return flag;
        }

        public static double GetAllAmount(object list)
        {
            double d = 0.00d;
            if (list is IList<AgentExpress>)
            {
                IList<AgentExpress> l = list as IList<AgentExpress>;

                foreach (var data in l)
                    if (!string.IsNullOrEmpty(data.Amount))
                        d += double.Parse(data.Amount);
            }
            else if (list is IList<AgentNormal>)
            {
                IList<AgentNormal> l = list as IList<AgentNormal>;

                foreach (var data in l)
                    if (!string.IsNullOrEmpty(data.Amount))
                        d += double.Parse(data.Amount);
            }
            else if (list is IList<TransferGlobal>)
            {
                IList<TransferGlobal> l = list as List<TransferGlobal>;
                foreach (var data in l)
                    if (!string.IsNullOrEmpty(data.RemitAmount))
                        d += double.Parse(data.RemitAmount);
            }
            else if (list is IList<TransferAccount>)
            {
                IList<TransferAccount> l = list as IList<TransferAccount>;

                foreach (var data in l)
                    if (!string.IsNullOrEmpty(data.PayAmount))
                        d += double.Parse(data.PayAmount);
            }
            else if (list is IList<ElecTicketRemit>)
            {
                IList<ElecTicketRemit> l = list as IList<ElecTicketRemit>;
                foreach (var data in l)
                    if (!string.IsNullOrEmpty(data.Amount))
                        d += double.Parse(data.Amount);
            }
            else if (list is IList<InitiativeAllot>)
            {
                IList<InitiativeAllot> l = list as IList<InitiativeAllot>;
                foreach (var data in l)
                    if (!string.IsNullOrEmpty(data.Amount))
                        d += double.Parse(data.Amount);
            }
            else if (list is IList<ElecTicketPool>)
            {
                IList<ElecTicketPool> l = list as IList<ElecTicketPool>;
                foreach (var data in l)
                {
                    if (!string.IsNullOrEmpty(data.Amount))
                        d += double.Parse(data.Amount);
                }
            }
            else if (list is IList<InitiativeAllot>)
            {
                IList<InitiativeAllot> l = list as IList<InitiativeAllot>;
                foreach (var data in l)
                    if (!string.IsNullOrEmpty(data.Amount))
                        d += double.Parse(data.Amount);
            }
            else if (list is IList<UnitivePaymentRMB>)
            {
                IList<UnitivePaymentRMB> l = list as IList<UnitivePaymentRMB>;
                foreach (var data in l)
                    if (!string.IsNullOrEmpty(data.Amount))
                        d += double.Parse(data.Amount);
            }
            else if (list is IList<BatchReimbursement>)
            {
                IList<BatchReimbursement> l = list as IList<BatchReimbursement>;
                foreach (var data in l)
                    if (!string.IsNullOrEmpty(data.ReimburseAmount))
                        d += double.Parse(data.ReimburseAmount);
            }
            return d;
        }

        public static string BigAmountToString(string data, long ldata, double sdata)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(data))
            {
                string[] strlist = data.Replace(",", "").Split(new string[] { "." }, StringSplitOptions.None);
                long l = long.Parse(strlist[0]);
                ldata += l;
                sdata += double.Parse(string.Format("0.{0}", strlist[1]));
                ldata += (long)sdata;
            }
            int index = sdata.ToString("0.00").IndexOf('.');
            result = string.Format("{0}{1}", ldata, sdata.ToString("0.00").Substring(index, 3));
            return result;
        }

        public static List<PayeeInfo> GetPayeeList(string pno, string account, string name)
        {
            List<PayeeInfo> list = new List<PayeeInfo>();
            if (string.IsNullOrEmpty(pno) && string.IsNullOrEmpty(account) && string.IsNullOrEmpty(name)) list = SystemSettings.PayeeList;
            else list = SystemSettings.PayeeList.FindAll(o => (!string.IsNullOrEmpty(pno) && o.SerialNo.Contains(pno)) || (!string.IsNullOrEmpty(account) && o.Account.Contains(account)) || (!string.IsNullOrEmpty(name) && o.Name.Contains(name)));
            return list;
        }

        public static List<PayeeInfo> GetPayeeList(string pno, string account, string name, AccountCategoryType act)
        {
            if (act == AccountCategoryType.Empty) return GetPayeeList(pno, account, name);

            List<PayeeInfo> list = new List<PayeeInfo>();
            if (null != SystemSettings.PayeeList)
                list = SystemSettings.PayeeList.FindAll(o => o.AccountType == act);
            if (!string.IsNullOrEmpty(pno) && (list != null && list.Count > 0)) list = list.FindAll(o => o.SerialNo.Contains(pno));
            if (!string.IsNullOrEmpty(account) && (list != null && list.Count > 0)) list = list.FindAll(o => o.Account.Contains(account));
            if (!string.IsNullOrEmpty(name) && (list != null && list.Count > 0)) list = list.FindAll(o => o.Name.Contains(name));
            return list;
        }

        public static List<PayeeInfo> GetPayeeList(string pno, string account, string name, AccountBankType abt)
        {
            if (abt == AccountBankType.Empty) return GetPayeeList(pno, account, name);

            List<PayeeInfo> list = new List<PayeeInfo>();
            list = SystemSettings.PayeeList.FindAll(o => o.BankType == abt);
            if (!string.IsNullOrEmpty(pno) && (list != null && list.Count > 0)) list = list.FindAll(o => o.SerialNo.Contains(pno));
            if (!string.IsNullOrEmpty(account) && (list != null && list.Count > 0)) list = list.FindAll(o => o.Account.Contains(account));
            if (!string.IsNullOrEmpty(name) && (list != null && list.Count > 0)) list = list.FindAll(o => o.Name.Contains(name));
            return list;
        }

        public static List<PayeeInfo> GetPayeeList(string pno, string account, string name, AccountCategoryType act, AccountBankType abt)
        {
            List<PayeeInfo> list = new List<PayeeInfo>();
            if (act != AccountCategoryType.Empty) list = GetPayeeList(pno, account, name, act);
            else if (abt != AccountBankType.Empty) list = GetPayeeList(pno, account, name, abt);
            else list = GetPayeeList(pno, account, name);
            return list;
        }

        public static List<ElecTicketRelationAccount> GetRelationAccountList(string pno, string account, string name, RelatePersonType rpt)
        {
            List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
            if (rpt == RelatePersonType.Empty) return list;
            list = SystemSettings.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & rpt) == rpt);
            if (!string.IsNullOrEmpty(pno)) list = list.FindAll(o => !string.IsNullOrEmpty(o.SerialNo) && o.SerialNo.Contains(pno));
            if (!string.IsNullOrEmpty(account)) list = list.FindAll(o => o.Account.Contains(account));
            if (!string.IsNullOrEmpty(name)) list = list.FindAll(o => o.Name.Contains(name));
            return list;
        }

        public static List<PayeeInfo4TransferGlobal> GetPayeeTransferGlobalList(string pno, string account, string name, OverCountryPayeeAccountType ocpat)
        {
            List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
            if (ocpat == OverCountryPayeeAccountType.Empty) return list;
            list = SystemSettings.PayeeInfo4TransferGlobalList.FindAll(o => o.AccountType == ocpat);
            if (!string.IsNullOrEmpty(pno)) list = list.FindAll(o => !string.IsNullOrEmpty(o.SerialNo) && o.SerialNo.Contains(pno));
            if (!string.IsNullOrEmpty(account)) list = list.FindAll(o => o.Account.Contains(account));
            if (!string.IsNullOrEmpty(name)) list = list.FindAll(o => !string.IsNullOrEmpty(o.Name) && o.Name.Contains(name));
            return list;
        }

        public static void SaveLocationData()
        {
            string direct = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!System.IO.Directory.Exists(direct)) System.IO.Directory.CreateDirectory(direct);
            DataFileHelper.SaveBaseSettings();
            DataFileHelper.SaveBatchChangeSetting(SystemSettings.BatchMappingSettings);
            DataFileHelper.SaveNoteList(SystemSettings.Notices);
            DataFileHelper.SavePayeeList(SystemSettings.PayeeList, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\PayeeInfo.xml"));
            DataFileHelper.SavePayerList(SystemSettings.PayerList);
            DataFileHelper.SavePayeeList(SystemSettings.AgentExpressPayerList, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\AgentExpressPayerList.xml"));
            DataFileHelper.SavePayeeTransferGlobalList(SystemSettings.PayeeInfo4TransferGlobalList);
            if ((SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
            {
                DataFileHelper.SaveCommonFieldList(SystemSettings.CommonFieldList);
                DataFileHelper.SaveElecTicketRelationAccountList(SystemSettings.ElecTicketRelationAccountList);
                DataFileHelper.SaveInitiativeAllotAccountList(SystemSettings.InitiativeAllotAccountList);
                DataFileHelper.SaveVirtualAllotAccountList(SystemSettings.VirtualAllotAccountList);
            }
        }

        public static int GetFunctionMaximum(AppliableFunctionType aft)
        {
            int maximum = 0;
            switch (aft)
            {
                case AppliableFunctionType.TransferWithIndiv:
                case AppliableFunctionType.TransferWithCorp: maximum = SystemSettings.DefaultMaxCountTransfer; break;
                case AppliableFunctionType.AgentExpressIn:
                case AppliableFunctionType.AgentExpressOut: maximum = SystemSettings.DefaultMaxCountAgentExpress; break;
                case AppliableFunctionType.AgentNormalIn:
                case AppliableFunctionType.TheCentralGoverment: maximum = SystemSettings.DefaultMaxCountAgentNormalInBOC; break;
                case AppliableFunctionType.AgentNormalOut: maximum = SystemSettings.DefaultMaxCountAgentNormalOutBOC; break;
                case AppliableFunctionType.TransferOverBankIn:
                case AppliableFunctionType.TransferOverBankOut: maximum = SystemSettings.DefaultMaxCountOverBank; break;
                case AppliableFunctionType.ElecTicketRemit:
                case AppliableFunctionType.ElecTicketTipExchange:
                case AppliableFunctionType.ElecTicketBackNote:
                case AppliableFunctionType.ElecTicketPayMoney: maximum = SystemSettings.DefaultMaxCountElecTicket; break;
                case AppliableFunctionType.ElecTicketPool: maximum = SystemSettings.DefaultMaxCountElecTicketPool; break;
                case AppliableFunctionType.TransferOverCountry:
                case AppliableFunctionType.TransferForeignMoney: maximum = SystemSettings.DefaultMaxCountTransferGlobal; break;
                case AppliableFunctionType.InitiativeAllot: maximum = SystemSettings.DefaultMaxCountInitiativeAllot; break;
                case AppliableFunctionType.PurchaserOrder:
                case AppliableFunctionType.SellerOrder:
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                case AppliableFunctionType.BillofDebtReceivableSeller:
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser: maximum = SystemSettings.DefaultMaxCountSpplyFinancing; break;
                case AppliableFunctionType.ApplyofFranchiserFinancing: maximum = SystemSettings.DefaultMaxCountApply; break;
                case AppliableFunctionType.UnitivePaymentRMB:
                case AppliableFunctionType.UnitivePaymentFC: maximum = SystemSettings.DefaultMaxCountUnitivePayment; break;
                case AppliableFunctionType.VirtualAccountTransfer: maximum = SystemSettings.DefaultMaxCountVirtualTransfer; break;
                case AppliableFunctionType.PreproccessTransfer: maximum = SystemSettings.DefaultMaxCountPreproccessTransfer; break;
                case AppliableFunctionType.BatchReimbursement: maximum = SystemSettings.DefaultMaxCountBatchReimbursement; break;
                default: maximum = int.MaxValue; break;
            }
            return maximum;
        }

        public static bool IsExistPayeeInfo(PayeeInfo payee)
        {
            return SystemSettings.PayeeList.FindAll(o => o.Account == payee.Account && o.Name == payee.Name && o.OpenBankName == payee.OpenBankName).Count > 0;
        }

        public static void ClearTempFile()
        {
            string dirpath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
            try
            {
                if (System.IO.Directory.Exists(dirpath))
                    System.IO.Directory.Delete(dirpath, true);
            }
            catch { }
        }

        public static string GetBarFileName(AppliableFunctionType aft, AgentTransferBankType bankType)
        {
            StringBuilder filename = new StringBuilder();
            filename.Append(SystemSettings.CustomerInfo.Group);
            filename.Append("-");
            filename.Append(GetBusinessType(aft, bankType));
            filename.Append("-");
            DateTime dt = DateTime.Today;
            filename.Append(dt.Year.ToString() + dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0'));
            filename.Append("-");
            filename.Append(SystemSettings.CustomerInfo.Code.PadLeft(3, '0'));
            filename.Append(".DAT");
            return filename.ToString();
        }

        public static string GetBusinessType(AppliableFunctionType aft, AgentTransferBankType bankType)
        {
            string bt = string.Empty;
            switch (aft)
            {
                case AppliableFunctionType.TransferOverCountry4Bar:
                    bt = "C6"; break;
                case AppliableFunctionType.TransferForeignMoney4Bar:
                    bt = bankType == AgentTransferBankType.Boc ? "C1" : "C5"; break;
                case AppliableFunctionType.AgentExpressOut4Bar:
                    bt = bankType == AgentTransferBankType.Boc ? "C1" : "C2"; break;
            }
            return bt;
        }

        public static void SetNextOrderNo()
        {
            if (SystemSettings.CustomerInfo != null && !string.IsNullOrEmpty(SystemSettings.CustomerInfo.Code))
            {
                try { SystemSettings.CustomerInfo.Code = ((int.Parse(SystemSettings.CustomerInfo.Code) + 1) % 1000).ToString().PadLeft(3, '0'); }
                catch { }
            }
        }

        public static string GetFormMainTextByVersion()
        {
            return ((SystemSettings.CurrentVersion & VersionType.v403bar) != VersionType.v403bar) ? ConvertHelper.MultiLanguageConvertHelper.FrmMain_Text : ConvertHelper.MultiLanguageConvertHelper.FrmMain_Bar_Text;
        }
    }

    public class ResultData
    {
        public bool Result = false;
        public string Message = string.Empty;
    }

    public class ValidationResult
    {
        public ValidateErrorType ValidationDetail { get; set; }
        public bool Pass { get { return ValidationDetail == ValidateErrorType.Succeed; } }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string Message { get; set; }
    }

    public class ValidationResults
    {
        public bool Pass { get; set; }
        public readonly List<ValidationResult> Results = new List<ValidationResult>();
    }

    public struct DataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Chs { get; set; }
        public string En { get; set; }
        public string Cht { get; set; }
        public string Jap { get; set; }
        public string Kor { get; set; }
        public string Ger { get; set; }
        public string Fra { get; set; }
        public string Rus { get; set; }
        public string Pol { get; set; }
    }
}
