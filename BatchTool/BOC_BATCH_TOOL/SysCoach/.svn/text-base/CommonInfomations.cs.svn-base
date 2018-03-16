using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.Entities;
using CommonClient.EnumTypes;
using CommonClient.MatchFile;
using CommonClient.Utilities;

namespace CommonClient.SysCoach
{
    public class CommonInformations
    {
        #region 单例
        private static object lock_obj = new object();
        private static CommonInformations m_instance;
        /// <summary>
        /// 单一实例
        /// </summary>
        public static CommonInformations Instance
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
                                m_instance = new CommonInformations();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        public CommonInformations()
        { }

        public void Init()
        {
            InitEventHandler();
            InitBaseSettings();
        }

        private void InitEventHandler()
        {
            CommandCenter.Instance.OnAppliableEventHandler += new EventHandler<AppliableEventArgs>(CommandCenter_OnAppliableEventHandler);
            CommandCenter.Instance.OnPayerInfoEventHandler += new EventHandler<PayerEventArgs>(CommandCenter_OnPayerInfoEventHandler);
            CommandCenter.Instance.OnPayeeInfoEventHandler += new EventHandler<PayeeEventArgs>(CommandCenter_OnPayeeInfoEventHandler);
            CommandCenter.Instance.OnNoticeEventHandler += new EventHandler<NoticeEventArgs>(CommandCenter_OnNoticeEventHandler);
            CommandCenter.Instance.OnFieldMappingEventHandler += new EventHandler<FieldMappingEventArgs>(CommandCenter_OnFieldMappingEventHandler);
            CommandCenter.Instance.OnPayeeInfo4TransferGlobalEventHandler += new EventHandler<Payee4TransferGlobalEventArgs>(CommandCenter_OnPayeeInfo4TransferGlobalEventHandler);
            if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
            {
                CommandCenter.Instance.OnCommonDataEventHandler += new EventHandler<CommonDataEventArgs>(CommandCenter_OnCommonDataEventHandler);
                CommandCenter.Instance.OnEncryptionEventHandler += new EventHandler<EncryptionEventArgs>(CommandCenter_OnEncryptionEventHandler);
                CommandCenter.Instance.OnElecTicketRelateAccountEventHandler += new EventHandler<ElecTicketRelateAccountEventArgs>(CommandCenter_OnElecTicketRelateAccountEventHandler);
                CommandCenter.Instance.OnAgentExpressPayerEventHandler += new EventHandler<PayeeEventArgs>(CommandCenter_OnAgentExpressPayerEventHandler);
                CommandCenter.Instance.OnInitiativeAllotAccountEventHandler += new EventHandler<InitiativeAllotAccountEventArgs>(CommandCenter_OnInitiativeAllotAccountEventHandler);
                CommandCenter.Instance.OnVirtualAccountAllotEventEventHandler += new EventHandler<VirtualAccountAllotEventArgs>(CommandCenter_OnVirtualAllotAccountEventHandler);
            }
        }

        void CommandCenter_OnAgentExpressPayerEventHandler(object sender, PayeeEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                int index = SystemSettings.Instance.AgentExpressPayerList.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name);
                if (index >= 0) return;
                index = SystemSettings.Instance.AgentExpressPayerList.FindIndex(o => o.SerialNo == e.PayeeInfo.SerialNo && !string.IsNullOrEmpty(e.PayeeInfo.SerialNo));
                if (index >= 0) return;

                if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.Instance.AgentExpressPayerList.Count)
                    SystemSettings.Instance.AgentExpressPayerList.Insert(e.RowIndex - 1, e.PayeeInfo);
                else
                    SystemSettings.Instance.AgentExpressPayerList.Add(e.PayeeInfo);
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                int index = SystemSettings.Instance.AgentExpressPayerList.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName);
                if (index >= 0 && index != e.RowIndex - 1) return;
                index = SystemSettings.Instance.AgentExpressPayerList.FindIndex(o => o.SerialNo == e.PayeeInfo.SerialNo && !string.IsNullOrEmpty(e.PayeeInfo.SerialNo));
                if (index >= 0 && index != e.RowIndex - 1) return;

                SystemSettings.Instance.AgentExpressPayerList[e.RowIndex - 1] = e.PayeeInfo;
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.Instance.AgentExpressPayerList.FindAll(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName).Count > 0)
                {
                    SystemSettings.Instance.AgentExpressPayerList.RemoveAt(e.RowIndex);
                }
            }
            else if (OperatorCommandType.CombineData == e.Command)
            {
                foreach (var item in e.PayeeList)
                {
                    if (SystemSettings.Instance.AgentExpressPayerList.FindIndex(o => o.Account == item.Account && o.Name == item.Name && o.OpenBankName == e.PayeeInfo.OpenBankName) >= 0)
                        continue;
                    if (SystemSettings.Instance.AgentExpressPayerList.Exists(o => o.SerialNo == item.SerialNo && !string.IsNullOrEmpty(item.SerialNo)))
                        continue;
                    SystemSettings.Instance.AgentExpressPayerList.Add(item);
                }
            }
        }

        void CommandCenter_OnPayeeInfo4TransferGlobalEventHandler(object sender, Payee4TransferGlobalEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                int index = SystemSettings.Instance.PayeeInfo4TransferGlobalList.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name);
                if (index >= 0) return;

                if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.Instance.PayeeInfo4TransferGlobalList.Count)
                    SystemSettings.Instance.PayeeInfo4TransferGlobalList.Insert(e.RowIndex - 1, e.PayeeInfo);
                else
                    SystemSettings.Instance.PayeeInfo4TransferGlobalList.Add(e.PayeeInfo);
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                int index = SystemSettings.Instance.PayeeInfo4TransferGlobalList.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name);
                if (index >= 0 && index != e.RowIndex - 1) return;

                SystemSettings.Instance.PayeeInfo4TransferGlobalList[e.RowIndex - 1] = e.PayeeInfo;
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.Instance.PayeeInfo4TransferGlobalList.FindAll(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name).Count > 0)
                {
                    SystemSettings.Instance.PayeeInfo4TransferGlobalList.RemoveAt(e.RowIndex);
                }
            }
            else if (OperatorCommandType.CombineData == e.Command)
            {
                foreach (var item in e.PayeeList)
                {
                    if (SystemSettings.Instance.PayeeInfo4TransferGlobalList.FindIndex(o => o.Account == item.Account && o.Name == item.Name) >= 0)
                        continue;
                    SystemSettings.Instance.PayeeInfo4TransferGlobalList.Add(item);
                }
            }
        }

        void CommandCenter_OnElecTicketRelateAccountEventHandler(object sender, ElecTicketRelateAccountEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                int index = SystemSettings.Instance.ElecTicketRelationAccountList.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                if (index >= 0) return;

                if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.Instance.ElecTicketRelationAccountList.Count)
                    SystemSettings.Instance.ElecTicketRelationAccountList.Insert(e.RowIndex - 1, e.RelationAccount);
                else
                    SystemSettings.Instance.ElecTicketRelationAccountList.Add(e.RelationAccount);
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                int index = SystemSettings.Instance.ElecTicketRelationAccountList.FindIndex(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name);
                if (index >= 0 && index != e.RowIndex - 1) return;

                SystemSettings.Instance.ElecTicketRelationAccountList[e.RowIndex - 1] = e.RelationAccount;
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.Instance.ElecTicketRelationAccountList.FindAll(o => o.Account == e.RelationAccount.Account && o.Name == e.RelationAccount.Name).Count > 0)
                {
                    SystemSettings.Instance.ElecTicketRelationAccountList.RemoveAt(e.RowIndex);
                }
            }
            else if (OperatorCommandType.CombineData == e.Command)
            {
                foreach (var item in e.RelationAccountList)
                {
                    if (SystemSettings.Instance.ElecTicketRelationAccountList.FindIndex(o => o.Account == item.Account && o.Name == item.Name) >= 0)
                        continue;
                    SystemSettings.Instance.ElecTicketRelationAccountList.Add(item);
                }
            }
        }

        private void InitBaseSettings()
        {
            SystemSettings.Instance.PayerList = DataFileHelper.Instance.GetPayerList();
            SystemSettings.Instance.PayeeList = DataFileHelper.Instance.GetPayeeList();
            SystemSettings.Instance.Notices = DataFileHelper.Instance.GetNoteList();
            SystemSettings.Instance.PayeeInfo4TransferGlobalList = DataFileHelper.Instance.GetPayeeTransferGlobalList();
            if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
            {
                SystemSettings.Instance.ElecTicketRelationAccountList = DataFileHelper.Instance.GetElecTicketRelationAccountList();
                SystemSettings.Instance.InitiativeAllotAccountList = DataFileHelper.Instance.GetInitiativeAllotAccountList();
                SystemSettings.Instance.VirtualAllotAccountList = DataFileHelper.Instance.GetVirtualAllotAccountList();
                SystemSettings.Instance.CommonFieldList = DataFileHelper.Instance.GetCommonFieldList();
            }
            if (SystemSettings.Instance.CommonFieldList.Count == 0) SystemInit.Instance.InitCommonField();

            SystemSettings.Instance.BatchMappingSettings = DataFileHelper.Instance.GetBatchMappingSetting();
            if (SystemSettings.Instance.BatchMappingSettings.Count != PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList.Count) SystemInit.Instance.InitMappingRelation();

            DataFileHelper.Instance.GetBaseSettings();
            SystemInit.Instance.InitDataFieldsDescription();

            if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
            {
                DataFileHelper.Instance.GetCity2ProvinceBarList();
            }
        }

        void CommandCenter_OnFieldMappingEventHandler(object sender, FieldMappingEventArgs e)
        {
            if (OperatorCommandType.MappingSettingResolve == e.Command)
            {
                if (e.AppType == AppliableFunctionType._Empty)
                {
                    if (e.BatchAppType == FunctionInSettingType.PayeeMg)
                    {
                        if (!SystemSettings.Instance.BatchSettingsMappingSettings.ContainsKey(e.BatchAppType)) SystemSettings.Instance.BatchSettingsMappingSettings.Add(e.BatchAppType, e.Mappings);
                        else SystemSettings.Instance.BatchSettingsMappingSettings[e.BatchAppType] = e.Mappings;
                    }
                }
                else
                {
                    if (!SystemSettings.Instance.BatchMappingSettings.ContainsKey(e.AppType)) SystemSettings.Instance.BatchMappingSettings.Add(e.AppType, e.Mappings);
                    else SystemSettings.Instance.BatchMappingSettings[e.AppType] = e.Mappings;
                }
            }
        }

        void CommandCenter_OnEncryptionEventHandler(object sender, EncryptionEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                switch (e.AppType)
                {
                    case AppliableFunctionType.AgentExpressOut:
                        SystemSettings.Instance.IsMatchPassword4ShortProxyOut = e.IsSetPassword;
                        SystemSettings.Instance.ShortProxyOutPassword = e.Password;
                        break;
                    case AppliableFunctionType.TransferOverCountry:
                        SystemSettings.Instance.IsMatchPassword4TransferOverCountry = e.IsSetPassword;
                        SystemSettings.Instance.TransferOverCountryPassword = e.Password;
                        break;
                    case AppliableFunctionType.TransferForeignMoney:
                        SystemSettings.Instance.IsMatchPassword4TransferForeignMoney = e.IsSetPassword;
                        SystemSettings.Instance.TransferForeignMoneyPassword = e.Password;
                        break;
                }
            }
        }

        void CommandCenter_OnCommonDataEventHandler(object sender, CommonDataEventArgs e)
        {
            if (OperatorCommandType.CommonFieldResolve == e.Command)
            {
                //SystemSettings.Instance.CommonFieldList = e.CommonFields;

                foreach (var item in e.CommonFields)
                {
                    if (!SystemSettings.Instance.CommonFieldList.ContainsKey(item.Key))
                        SystemSettings.Instance.CommonFieldList.Add(item.Key, item.Value);
                    else
                    {
                        if ((SystemSettings.Instance.CommonFieldList[item.Key] & item.Value) != item.Value)
                            SystemSettings.Instance.CommonFieldList[item.Key] = SystemSettings.Instance.CommonFieldList[item.Key] | item.Value;
                    }
                }
            }
            else if (OperatorCommandType.CommonFieldLockHide == e.Command)
            {
                foreach (var item in e.CommonFields)
                {
                    if (SystemSettings.Instance.CommonFieldList.ContainsKey(item.Key) && SystemSettings.Instance.CommonFieldList[item.Key] != CommonFieldType.Empty)
                        SystemSettings.Instance.CommonFieldList[item.Key] = CommonFieldType.Empty;
                }
            }
        }

        void CommandCenter_OnNoticeEventHandler(object sender, NoticeEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command || OperatorCommandType.Edit == e.Command)
            {
                if (null != e.Notice)
                {
                    if (!SystemSettings.Instance.Notices.ContainsKey(e.OwnerType))
                        SystemSettings.Instance.Notices.Add(e.OwnerType, new List<NoticeInfo>());
                    if (SystemSettings.Instance.Notices[e.OwnerType].FindAll(o => o.Content == e.Notice.Content).Count > 0)
                    {
                        NoticeInfo notice = SystemSettings.Instance.Notices[e.OwnerType].Find(o => o.Content == e.Notice.Content);
                        notice.Content = e.Notice.Content;
                    }
                    else if (SystemSettings.Instance.Notices[e.OwnerType].FindAll(o => string.IsNullOrEmpty(o.Content)).Count > 0)
                    {
                        int index = SystemSettings.Instance.Notices[e.OwnerType].FindIndex(o => string.IsNullOrEmpty(o.Content));
                        if (index >= 0)
                        {
                            e.Notice.RowIndex = index + 1;
                            SystemSettings.Instance.Notices[e.OwnerType][index] = e.Notice;
                        }
                    }
                    else if (SystemSettings.Instance.Notices[e.OwnerType].Count < 10)
                    {
                        e.Notice.RowIndex = SystemSettings.Instance.Notices[e.OwnerType].Count;
                        SystemSettings.Instance.Notices[e.OwnerType].Add(e.Notice);
                    }
                }
                else if (e.NoticeList.Count >= 0)
                {
                    if (!SystemSettings.Instance.Notices.ContainsKey(e.OwnerType))
                        SystemSettings.Instance.Notices.Add(e.OwnerType, new List<NoticeInfo>());
                    SystemSettings.Instance.Notices[e.OwnerType] = e.NoticeList;
                }
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.Instance.PayeeList.FindAll(o => o.Account == e.Notice.Content).Count > 0)
                {
                    int index = SystemSettings.Instance.Notices[e.OwnerType].FindIndex(o => o.Content == e.Notice.Content);
                    SystemSettings.Instance.Notices[e.OwnerType][index].Content = string.Empty;
                }
            }
        }

        void CommandCenter_OnPayeeInfoEventHandler(object sender, PayeeEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                int index = SystemSettings.Instance.PayeeList.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName);
                if (index >= 0) return;

                if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.Instance.PayeeList.Count)
                    SystemSettings.Instance.PayeeList.Insert(e.RowIndex - 1, e.PayeeInfo);
                else
                    SystemSettings.Instance.PayeeList.Add(e.PayeeInfo);
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                int index = SystemSettings.Instance.PayeeList.FindIndex(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName);
                if (index >= 0 && index != e.RowIndex - 1) return;

                SystemSettings.Instance.PayeeList[e.RowIndex - 1] = e.PayeeInfo;
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.Instance.PayeeList.FindAll(o => o.Account == e.PayeeInfo.Account && o.Name == e.PayeeInfo.Name && o.OpenBankName == e.PayeeInfo.OpenBankName).Count > 0)
                {
                    SystemSettings.Instance.PayeeList.RemoveAt(e.RowIndex);
                }
            }
            else if (OperatorCommandType.CombineData == e.Command)
            {
                foreach (var item in e.PayeeList)
                {
                    if (SystemSettings.Instance.PayeeList.FindIndex(o => o.Account == item.Account && o.Name == item.Name && o.OpenBankName == item.OpenBankName) >= 0)
                        continue;
                    SystemSettings.Instance.PayeeList.Add(item);
                }
            }
        }

        void CommandCenter_OnPayerInfoEventHandler(object sender, PayerEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                if (SystemSettings.Instance.PayerList.FindAll(o => o.Account == e.PayerInfo.Account && o.Name == e.PayerInfo.Name).Count > 0)
                {
                    PayerInfo payer = SystemSettings.Instance.PayerList.Find(o => o.Account == e.PayerInfo.Account && o.Name == e.PayerInfo.Name);
                    payer = e.PayerInfo;
                }
                else
                {
                    if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.Instance.PayerList.Count)
                        SystemSettings.Instance.PayerList.Insert(e.RowIndex - 1, e.PayerInfo);
                    else
                        SystemSettings.Instance.PayerList.Add(e.PayerInfo);
                }
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                if (SystemSettings.Instance.PayerList.Count >= e.RowIndex)
                {
                    SystemSettings.Instance.PayerList[e.RowIndex - 1] = e.PayerInfo;
                }
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.Instance.PayerList.FindAll(o => o.Account == e.PayerInfo.Account && o.Name == e.PayerInfo.Name).Count > 0)
                {
                    PayerInfo payer = SystemSettings.Instance.PayerList.Find(o => o.Account == e.PayerInfo.Account && o.Name == e.PayerInfo.Name);
                    SystemSettings.Instance.PayerList.Remove(payer);
                }
            }
        }

        void CommandCenter_OnAppliableEventHandler(object sender, AppliableEventArgs e)
        {
            if (OperatorCommandType.AppVisiableResolve == e.Command)
            {
                SystemSettings.Instance.AppliableTypes = e.AppVisiable;
                SystemSettings.Instance.AppliableTypes4Bar = e.AppVisiableBar;
                CommandCenter.Instance.ResolveMoveMenu(OperatorCommandType.View, 0, 0, 0, 0, 0, OperatorCommandType.Empty);
            }
        }

        void CommandCenter_OnInitiativeAllotAccountEventHandler(object sender, InitiativeAllotAccountEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                if (SystemSettings.Instance.InitiativeAllotAccountList.FindAll(o => o.Account == e.InitiativeAllotAccount.Account).Count > 0)
                {
                    InitiativeAllotAccount payer = SystemSettings.Instance.InitiativeAllotAccountList.Find(o => o.Account == e.InitiativeAllotAccount.Account);
                    payer = e.InitiativeAllotAccount;
                }
                else
                {
                    if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.Instance.InitiativeAllotAccountList.Count)
                        SystemSettings.Instance.InitiativeAllotAccountList.Insert(e.RowIndex - 1, e.InitiativeAllotAccount);
                    else
                        SystemSettings.Instance.InitiativeAllotAccountList.Add(e.InitiativeAllotAccount);
                }
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                if (SystemSettings.Instance.InitiativeAllotAccountList.Count >= e.RowIndex)
                {
                    SystemSettings.Instance.InitiativeAllotAccountList[e.RowIndex - 1] = e.InitiativeAllotAccount;
                }
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.Instance.InitiativeAllotAccountList.FindAll(o => o.Account == e.InitiativeAllotAccount.Account).Count > 0)
                {
                    InitiativeAllotAccount payer = SystemSettings.Instance.InitiativeAllotAccountList.Find(o => o.Account == e.InitiativeAllotAccount.Account);
                    SystemSettings.Instance.InitiativeAllotAccountList.Remove(payer);
                }
            }
        }

        void CommandCenter_OnVirtualAllotAccountEventHandler(object sender, VirtualAccountAllotEventArgs e)
        {
            if (OperatorCommandType.Submit == e.Command)
            {
                if (SystemSettings.Instance.InitiativeAllotAccountList.FindAll(o => o.Account == e.VirtualAllotAccount.Account).Count > 0)
                {
                    VirtualAccountInfo payer = SystemSettings.Instance.VirtualAllotAccountList.Find(o => o.Account == e.VirtualAllotAccount.Account);
                    payer = e.VirtualAllotAccount;
                }
                else
                {
                    if (e.RowIndex > 0 && e.RowIndex <= SystemSettings.Instance.InitiativeAllotAccountList.Count)
                        SystemSettings.Instance.VirtualAllotAccountList.Insert(e.RowIndex - 1, e.VirtualAllotAccount);
                    else
                        SystemSettings.Instance.VirtualAllotAccountList.Add(e.VirtualAllotAccount);
                }
            }
            else if (OperatorCommandType.Edit == e.Command)
            {
                if (SystemSettings.Instance.VirtualAllotAccountList.Count >= e.RowIndex)
                {
                    SystemSettings.Instance.VirtualAllotAccountList[e.RowIndex - 1] = e.VirtualAllotAccount;
                }
            }
            else if (OperatorCommandType.Delete == e.Command)
            {
                if (SystemSettings.Instance.VirtualAllotAccountList.FindAll(o => o.Account == e.VirtualAllotAccount.Account).Count > 0)
                {
                    VirtualAccountInfo payer = SystemSettings.Instance.VirtualAllotAccountList.Find(o => o.Account == e.VirtualAllotAccount.Account);
                    SystemSettings.Instance.VirtualAllotAccountList.Remove(payer);
                }
            }
        }

        public bool CanClearItem(AppliableFunctionType aft, CommonFieldType cft)
        {
            return !(SystemSettings.Instance.CommonFieldList.ContainsKey(aft) && ((SystemSettings.Instance.CommonFieldList[aft] & cft) == cft));
        }

        public bool CheckMappingSetting(AppliableFunctionType aft, FunctionInSettingType fst)
        {
            bool flag = false;
            if (aft != AppliableFunctionType._Empty)
                flag = SystemSettings.Instance.BatchMappingSettings[aft].IsSetFields;
            else if (aft == AppliableFunctionType._Empty && fst == FunctionInSettingType.PayeeMg)
                flag = SystemSettings.Instance.BatchSettingsMappingSettings[fst].IsSetFields;

            return flag;
        }

        public double GetAllAmount(object list)
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
            return d;
        }

        public string BigAmountToString(string data, long ldata, double sdata)
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

        public List<PayeeInfo> GetPayeeList(string pno, string account, string name)
        {
            List<PayeeInfo> list = new List<PayeeInfo>();
            if (string.IsNullOrEmpty(pno) && string.IsNullOrEmpty(account) && string.IsNullOrEmpty(name)) list = SystemSettings.Instance.PayeeList;
            else list = SystemSettings.Instance.PayeeList.FindAll(o => (!string.IsNullOrEmpty(pno) && o.SerialNo.Contains(pno)) || (!string.IsNullOrEmpty(account) && o.Account.Contains(account)) || (!string.IsNullOrEmpty(name) && o.Name.Contains(name)));
            return list;
        }

        public List<PayeeInfo> GetPayeeList(string pno, string account, string name, AccountCategoryType act)
        {
            if (act == AccountCategoryType.Empty) return GetPayeeList(pno, account, name);

            List<PayeeInfo> list = new List<PayeeInfo>();
            if (null != SystemSettings.Instance.PayeeList)
                list = SystemSettings.Instance.PayeeList.FindAll(o => o.AccountType == act);
            if (!string.IsNullOrEmpty(pno) && (list != null && list.Count > 0)) list = list.FindAll(o => o.SerialNo.Contains(pno));
            if (!string.IsNullOrEmpty(account) && (list != null && list.Count > 0)) list = list.FindAll(o => o.Account.Contains(account));
            if (!string.IsNullOrEmpty(name) && (list != null && list.Count > 0)) list = list.FindAll(o => o.Name.Contains(name));
            return list;
        }

        public List<PayeeInfo> GetPayeeList(string pno, string account, string name, AccountBankType abt)
        {
            if (abt == AccountBankType.Empty) return GetPayeeList(pno, account, name);

            List<PayeeInfo> list = new List<PayeeInfo>();
            list = SystemSettings.Instance.PayeeList.FindAll(o => o.BankType == abt);
            if (!string.IsNullOrEmpty(pno) && (list != null && list.Count > 0)) list = list.FindAll(o => o.SerialNo.Contains(pno));
            if (!string.IsNullOrEmpty(account) && (list != null && list.Count > 0)) list = list.FindAll(o => o.Account.Contains(account));
            if (!string.IsNullOrEmpty(name) && (list != null && list.Count > 0)) list = list.FindAll(o => o.Name.Contains(name));
            return list;
        }

        public List<PayeeInfo> GetPayeeList(string pno, string account, string name, AccountCategoryType act, AccountBankType abt)
        {
            List<PayeeInfo> list = new List<PayeeInfo>();
            if (act != AccountCategoryType.Empty) list = GetPayeeList(pno, account, name, act);
            else if (abt != AccountBankType.Empty) list = GetPayeeList(pno, account, name, abt);
            else list = GetPayeeList(pno, account, name);
            return list;
        }

        public List<ElecTicketRelationAccount> GetRelationAccountList(string pno, string account, string name, RelatePersonType rpt)
        {
            List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();
            if (rpt == RelatePersonType.Empty) return list;
            list = SystemSettings.Instance.ElecTicketRelationAccountList.FindAll(o => (o.PersonType & rpt) == rpt);
            if (!string.IsNullOrEmpty(pno)) list = list.FindAll(o => o.SerialNo.Contains(pno));
            if (!string.IsNullOrEmpty(account)) list = list.FindAll(o => o.Account.Contains(account));
            if (!string.IsNullOrEmpty(name)) list = list.FindAll(o => o.Name.Contains(name));
            return list;
        }

        public List<PayeeInfo4TransferGlobal> GetPayeeTransferGlobalList(string pno, string account, string name, OverCountryPayeeAccountType ocpat)
        {
            List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();
            if (ocpat == OverCountryPayeeAccountType.Empty) return list;
            list = SystemSettings.Instance.PayeeInfo4TransferGlobalList.FindAll(o => o.AccountType == ocpat);
            if (!string.IsNullOrEmpty(pno)) list = list.FindAll(o => !string.IsNullOrEmpty(o.SerialNo) && o.SerialNo.Contains(pno));
            if (!string.IsNullOrEmpty(account)) list = list.FindAll(o => o.Account.Contains(account));
            if (!string.IsNullOrEmpty(name)) list = list.FindAll(o => !string.IsNullOrEmpty(o.Name) && o.Name.Contains(name));
            return list;
        }

        public void SaveLocationData()
        {
            string direct = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!System.IO.Directory.Exists(direct)) System.IO.Directory.CreateDirectory(direct);
            DataFileHelper.Instance.SaveBaseSettings();
            DataFileHelper.Instance.SaveBatchChangeSetting(SystemSettings.Instance.BatchMappingSettings);
            DataFileHelper.Instance.SaveNoteList(SystemSettings.Instance.Notices);
            DataFileHelper.Instance.SavePayeeList(SystemSettings.Instance.PayeeList);
            DataFileHelper.Instance.SavePayerList(SystemSettings.Instance.PayerList);
            DataFileHelper.Instance.SavePayeeTransferGlobalList(SystemSettings.Instance.PayeeInfo4TransferGlobalList);
            if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) != VersionType.v403bar)
            {
                DataFileHelper.Instance.SaveCommonFieldList(SystemSettings.Instance.CommonFieldList);
                DataFileHelper.Instance.SaveElecTicketRelationAccountList(SystemSettings.Instance.ElecTicketRelationAccountList);
                DataFileHelper.Instance.SaveInitiativeAllotAccountList(SystemSettings.Instance.InitiativeAllotAccountList);
                DataFileHelper.Instance.SaveVirtualAllotAccountList(SystemSettings.Instance.VirtualAllotAccountList);
            }
        }

        public int GetFunctionMaximum(AppliableFunctionType aft)
        {
            int maximum = 0;
            switch (aft)
            {
                case AppliableFunctionType.TransferWithIndiv:
                case AppliableFunctionType.TransferWithCorp: maximum = SystemSettings.Instance.DefaultMaxCountTransfer; break;
                case AppliableFunctionType.AgentExpressIn:
                case AppliableFunctionType.AgentExpressOut: maximum = SystemSettings.Instance.DefaultMaxCountAgentExpress; break;
                case AppliableFunctionType.AgentNormalIn: maximum = SystemSettings.Instance.DefaultMaxCountAgentNormalInBOC; break;
                case AppliableFunctionType.AgentNormalOut: maximum = SystemSettings.Instance.DefaultMaxCountAgentNormalOutBOC; break;
                case AppliableFunctionType.TransferOverBankIn:
                case AppliableFunctionType.TransferOverBankOut: maximum = SystemSettings.Instance.DefaultMaxCountOverBank; break;
                case AppliableFunctionType.ElecTicketRemit:
                case AppliableFunctionType.ElecTicketTipExchange:
                case AppliableFunctionType.ElecTicketBackNote:
                case AppliableFunctionType.ElecTicketPayMoney: maximum = SystemSettings.Instance.DefaultMaxCountElecTicket; break;
                case AppliableFunctionType.ElecTicketPool: maximum = SystemSettings.Instance.DefaultMaxCountElecTicketPool; break;
                case AppliableFunctionType.TransferOverCountry:
                case AppliableFunctionType.TransferForeignMoney: maximum = SystemSettings.Instance.DefaultMaxCountTransferGlobal; break;
                case AppliableFunctionType.InitiativeAllot: maximum = SystemSettings.Instance.DefaultMaxCountInitiativeAllot; break;
                case AppliableFunctionType.PurchaserOrder:
                case AppliableFunctionType.SellerOrder:
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                case AppliableFunctionType.BillofDebtReceivableSeller:
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser: maximum = SystemSettings.Instance.DefaultMaxCountSpplyFinancing; break;
                case AppliableFunctionType.ApplyofFranchiserFinancing: maximum = SystemSettings.Instance.DefaultMaxCountApply; break;
                default: maximum = int.MaxValue; break;
            }
            return maximum;
        }

        public bool IsExistPayeeInfo(PayeeInfo payee)
        {
            return SystemSettings.Instance.PayeeList.FindAll(o => o.Account == payee.Account && o.Name == payee.Name && o.OpenBankName == payee.OpenBankName).Count > 0;
        }

        public void ClearTempFile()
        {
            string dirpath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
            try
            {
                if (System.IO.Directory.Exists(dirpath))
                    System.IO.Directory.Delete(dirpath, true);
            }
            catch { }
        }

        public string GetBarFileName(AppliableFunctionType aft, AgentTransferBankType bankType)
        {
            StringBuilder filename = new StringBuilder();
            filename.Append(SystemSettings.Instance.CustomerInfo.Group);
            filename.Append("-");
            filename.Append(GetBusinessType(aft, bankType));
            filename.Append("-");
            DateTime dt = DateTime.Today;
            filename.Append(dt.Year.ToString() + dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0'));
            filename.Append("-");
            filename.Append(SystemSettings.Instance.CustomerInfo.Code.PadLeft(3, '0'));
            filename.Append(".DAT");
            return filename.ToString();
        }

        public string GetBusinessType(AppliableFunctionType aft, AgentTransferBankType bankType)
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

        public void SetNextOrderNo()
        {
            if (SystemSettings.Instance.CustomerInfo != null && !string.IsNullOrEmpty(SystemSettings.Instance.CustomerInfo.Code))
            {
                try { SystemSettings.Instance.CustomerInfo.Code = ((int.Parse(SystemSettings.Instance.CustomerInfo.Code) + 1) % 1000).ToString().PadLeft(3, '0'); }
                catch { }
            }
        }

        public string GetFormMainTextByVersion()
        {
            return ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) != VersionType.v403bar) ? ConvertHelper.MultiLanguageConvertHelper.Instance.FrmMain_Text : ConvertHelper.MultiLanguageConvertHelper.Instance.FrmMain_Bar_Text;
        }
    }

    public class ResultData
    {
        public bool Result = false;
        public string Message = string.Empty;
    }
}
