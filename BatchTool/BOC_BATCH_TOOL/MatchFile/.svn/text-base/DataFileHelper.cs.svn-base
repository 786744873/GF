using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using CommonClient.Entities;
using CommonClient.EnumTypes;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.Types;
using CommonClient.Utilities;

namespace CommonClient.MatchFile
{
    public class DataFileHelper
    {
        private static object lock_obj = new object();
        private static DataFileHelper m_instance;
        /// <summary>
        /// 单例
        /// </summary>
        public static DataFileHelper Instance
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
                                m_instance = new DataFileHelper();
                        }
                    }
                }
                return m_instance;
            }
        }

        public List<BankInfo> GetLinkBankNo(string bankName)
        {
            List<BankInfo> result = new List<BankInfo>();
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\BankInfo.xml");
            if (!File.Exists(filepath)) return result;
            List<Dictionary<string, string>> list = FileIO.FileRWHelper.Instance.ReadSingalxmlFile(filepath);
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(bankName) && !item["BankName"].Contains(bankName)) continue;
                result.Add(new BankInfo { LinkID = item["LinkID"], BankName = item["BankName"] });
            }
            return result;
        }

        public CNAPS GetCNAPS(string filepath, string bankName, string cno)
        {
            CNAPS result = new CNAPS();
            Dictionary<string, List<Dictionary<string, string>>> list = FileIO.FileRWHelper.Instance.ReadTwicexmlFile(filepath);
            foreach (var kv in list.Values)
            {
                foreach (var item in kv)
                {
                    if (result.Items == null) result.Items = new List<CNAP>();
                    CNAP c = new CNAP { Code = item["CODE"], Name = item["NAME"] };
                    if (item.ContainsKey("ADDR"))
                        c.Addr = item["ADDR"];
                    result.Items.Add(c);
                }
            }
            if (!string.IsNullOrEmpty(cno))
                result.Items = result.Items.FindAll(o => (!string.IsNullOrEmpty(cno) && o.Code.Contains(cno)));
            if (!string.IsNullOrEmpty(bankName))
            {
                string[] bnList = bankName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in bnList)
                    result.Items = result.Items.FindAll(o => o.Name.Contains(item));
            }
            return result;
        }

        public List<CNAP> GetDealSerialNos(string filepath, AppliableFunctionType aft)
        {
            List<CNAP> result = new List<CNAP>();
            Dictionary<string, List<Dictionary<string, string>>> list = FileIO.FileRWHelper.Instance.ReadTwicexmlFile(filepath);
            foreach (var kv in list.Values)
            {
                foreach (var item in kv)
                {
                    if (result == null) result = new List<CNAP>();
                    result.Add(new CNAP { Code = item["CODE"], Name = item["NAME"], Group = item["GROUP"], Usage = item["USAGE"] });
                }
            }
            //result = result.FindAll(o => o.Addr == (aft == AppliableFunctionType.TransferForeignMoney ? "2" : "1"));
            return result;
        }

        #region 读文件数据

        public List<PayerInfo> GetPayerList()
        {
            List<PayerInfo> result = new List<PayerInfo>();
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\PayerInfo.xml");
            if (!File.Exists(filepath)) return result;
            List<Dictionary<string, string>> list = FileIO.FileRWHelper.Instance.ReadSingalxmlFile(filepath);
            foreach (var item in list)
            {
                PayerInfo payer = new PayerInfo();
                if (item.ContainsKey("Account"))
                    payer.Account = item["Account"];
                if (item.ContainsKey("Name"))
                    payer.Name = item["Name"];
                if (item.ContainsKey("CashType"))
                    payer.CashType = DataConvertHelper.GetCashType(item["CashType"]);
                if (item.ContainsKey("ServiceList"))
                    payer.ServiceList = (AppliableFunctionType)int.Parse(item["ServiceList"]);
                if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                {
                    if (item.ContainsKey("ServiceListBar"))
                        payer.ServiceListBar = (AppliableFunctionType)int.Parse(item["ServiceListBar"]);
                }
                result.Add(payer);
            }
            return result;
        }

        public List<PayeeInfo> GetPayeeList()
        {
            List<PayeeInfo> result = new List<PayeeInfo>();
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\PayeeInfo.xml");
            if (!File.Exists(filepath)) return result;
            List<Dictionary<string, string>> list = FileIO.FileRWHelper.Instance.ReadSingalxmlFile(filepath);
            foreach (var item in list)
            {
                result.Add(new PayeeInfo
                {
                    Account = item["Account"],
                    Name = item["Name"],
                    Address = item["Address"],
                    OpenBankName = item["BankName"],
                    ClearBankName = item["BankNameR"],
                    CNAPSNo = item["CNAPSNo"],
                    CNAPSNoR = item["CNAPANoR"],
                    Email = item["Email"],
                    Fax = item["Fax"],
                    CertifyPaperType = DataConvertHelper.GetAgentExpressCertifyPaperType(item["CertifyPaperType"].PadLeft(2, '0')),
                    CertifyPaperNo = item["CertifyPaperNo"],
                    SerialNo = item["PNo"],
                    Telephone = item["Telephone"],
                    AccountType = DataConvertHelper.GetAccountCategoryTypeObject(int.Parse(item["AccountType"])),
                    BankType = DataConvertHelper.GetAccountBankTypeObject(int.Parse(item["BankType"]))
                });
            }
            return result;
        }

        public List<ElecTicketRelationAccount> GetElecTicketRelationAccountList()
        {
            List<ElecTicketRelationAccount> result = new List<ElecTicketRelationAccount>();
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\ElecTicketRelationAccount.xml");
            if (!File.Exists(filepath)) return result;
            List<Dictionary<string, string>> list = FileIO.FileRWHelper.Instance.ReadSingalxmlFile(filepath);
            foreach (var item in list)
            {
                result.Add(new ElecTicketRelationAccount
                {
                    Account = item["Account"],
                    Name = item["Name"],
                    OpenBankName = item["OpenBankName"],
                    OpenBankNo = item["OpenBankNo"],
                    PersonType = (RelatePersonType)int.Parse(item["PersonType"]),
                    SerialNo = item["SerialNo"],
                    Tel_First = item["Tel_First"],
                    Email_First = item["Email_First"],
                    Tel_Second = item["Tel_Second"],
                    Email_Second = item["Email_Second"]
                });
            }
            return result;
        }

        public List<PayeeInfo4TransferGlobal> GetPayeeTransferGlobalList()
        {
            List<PayeeInfo4TransferGlobal> result = new List<PayeeInfo4TransferGlobal>();
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\PayeeTransferGlobalInfo.xml");
            if (!File.Exists(filepath)) return result;
            List<Dictionary<string, string>> list = FileIO.FileRWHelper.Instance.ReadSingalxmlFile(filepath);
            foreach (var item in list)
            {
                result.Add(new PayeeInfo4TransferGlobal
                {
                    AccountType = DataConvertHelper.GetOverCountryPayeeAccountTypeObject(int.Parse(item["AccountType"])),
                    Account = item["Account"],
                    Name = item["Name"],
                    Address = item["Address"],
                    NameofCountry = item["NameofCountry"],
                    CodeofCountry = item["CodeofCountry"],
                    OpenBankName = item["OpenBankName"],
                    OpenBankAddress = item["OpenBankAddress"],
                    OpenBankType = DataConvertHelper.GetAccountBankTypeObject(int.Parse(item["OpenBankType"])),
                    CorrespondentBankName = item["CorrespondentBankName"],
                    CorrespondentBankAddress = item["CorrespondentBankAddress"],
                    AccountInCorrespondentBank = item["AccountInCorrespondentBank"],
                    SerialNo = item["SerialNo"],
                    Email = item["Email"],
                    Fax = item["Fax"],
                    Telephone = item["Telephone"]
                });
            }
            return result;
        }

        public List<InitiativeAllotAccount> GetInitiativeAllotAccountList()
        {
            List<InitiativeAllotAccount> result = new List<InitiativeAllotAccount>();
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\InitiativeAllotAccount.xml");
            if (!File.Exists(filepath)) return result;
            List<Dictionary<string, string>> list = FileIO.FileRWHelper.Instance.ReadSingalxmlFile(filepath);
            foreach (var item in list)
            {
                result.Add(new InitiativeAllotAccount
                {
                    Account = item["Account"],
                    Name = item["Name"]
                });
            }
            return result;
        }

        public Dictionary<AppliableFunctionType, List<NoticeInfo>> GetNoteList()
        {
            Dictionary<AppliableFunctionType, List<NoticeInfo>> dic = new Dictionary<AppliableFunctionType, List<NoticeInfo>>();

            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\NoticeInfo.xml");
            if (!File.Exists(filepath)) return dic;

            Dictionary<string, List<Dictionary<string, List<string>>>> list = FileIO.FileRWHelper.Instance.ReadSpecalxmlFile(filepath);
            foreach (var kv in list)
            {
                AppliableFunctionType aft = DataConvertHelper.GetAppliableFunctionType(kv.Key);
                if (aft == AppliableFunctionType._Empty) continue;
                if (!dic.ContainsKey(aft)) dic.Add(aft, new List<NoticeInfo>());
                foreach (var item in kv.Value)
                {
                    if (!item.ContainsKey("Notice")) continue;
                    foreach (var content in item["Notice"])
                    {
                        dic[aft].Add(new NoticeInfo
                                        {
                                            RowIndex = dic[aft].Count + 1,
                                            Content = !string.IsNullOrEmpty(content) ? content : string.Empty
                                        });
                    }
                }
            }
            return dic;
        }

        public Dictionary<AppliableFunctionType, CommonFieldType> GetCommonFieldList()
        {
            Dictionary<AppliableFunctionType, CommonFieldType> dic = new Dictionary<AppliableFunctionType, CommonFieldType>();

            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\CommonField.xml");
            if (!File.Exists(filepath)) return dic;
            Dictionary<string, List<Dictionary<string, string>>> list = FileIO.FileRWHelper.Instance.ReadTwicexmlFile(filepath);
            foreach (var kv in list)
            {
                AppliableFunctionType aft = DataConvertHelper.GetAppliableFunctionType(kv.Key);
                if (aft == AppliableFunctionType._Empty) continue;
                if (!dic.ContainsKey(aft)) dic.Add(aft, CommonFieldType.Empty);
                foreach (var item in kv.Value)
                {
                    dic[aft] = (CommonFieldType)int.Parse(item["CommonFieldType"]);
                }
            }

            return dic;
        }

        public Dictionary<AppliableFunctionType, MappingsRelationSettings> GetBatchMappingSetting()
        {
            Dictionary<AppliableFunctionType, MappingsRelationSettings> dic = new Dictionary<AppliableFunctionType, MappingsRelationSettings>();

            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\MappingsRelation.xml");
            if (!File.Exists(filepath)) return dic;
            Dictionary<string, List<Dictionary<string, object>>> list = FileIO.FileRWHelper.Instance.ReadMultixmlFile(filepath);
            foreach (var kv in list)
            {
                AppliableFunctionType aft = DataConvertHelper.GetAppliableFunctionType(kv.Key);
                if (aft == AppliableFunctionType._Empty) continue;
                if (!dic.ContainsKey(aft)) dic.Add(aft, new MappingsRelationSettings());
                foreach (var item in kv.Value)
                {
                    int count = 1;
                    dic[aft].SeperateChar = string.IsNullOrEmpty(item["SeperateChar"].ToString()) ? item["SeperateChar"].ToString() : ((Dictionary<string, object>)item["SeperateChar"])["#text"].ToString();
                    dic[aft].MaxCountPerOperation = int.Parse(((Dictionary<string, object>)item["MaxCountPerOperation"])["#text"].ToString());
                    if (item["BatchFieldsMappings"] != null)
                    {
                        Dictionary<string, object> dicBatch = item["BatchFieldsMappings"] as Dictionary<string, object>;
                        if (dicBatch != null && dicBatch.Count > 0)
                        {
                            foreach (KeyValuePair<string, object> bfm in dicBatch)
                            {
                                if (bfm.Value is string)
                                    //dic[aft].BatchFieldsMappings.Add(bfm.Key, bfm.Value.ToString());
                                    dic[aft].BatchFieldsMappings.Add("a" + count.ToString(), bfm.Value.ToString());
                                else if (bfm.Value is Dictionary<string, object>)
                                    //dic[aft].BatchFieldsMappings.Add(bfm.Key, ((Dictionary<string, object>)bfm.Value)["#text"].ToString());
                                    dic[aft].BatchFieldsMappings.Add("a" + count.ToString(), ((Dictionary<string, object>)bfm.Value)["#text"].ToString());
                                count++;
                            }
                        }
                    }
                    if (item["FieldsMappings"] != null)
                    {
                        count = 1;
                        Dictionary<string, object> dicfield = item["FieldsMappings"] as Dictionary<string, object>;
                        if (null == dicfield) continue;
                        foreach (var fm in dicfield)
                        {
                            if (fm.Value is string)
                                //dic[aft].FieldsMappings.Add(fm.Key, fm.Value.ToString());
                                dic[aft].FieldsMappings.Add("a" + count.ToString(), fm.Value.ToString());
                            else if (fm.Value is Dictionary<string, object>)
                                //dic[aft].FieldsMappings.Add(fm.Key, ((Dictionary<string, object>)fm.Value)["#text"].ToString());
                                dic[aft].FieldsMappings.Add("a" + count.ToString(), ((Dictionary<string, object>)fm.Value)["#text"].ToString());
                            count++;
                        }
                    }
                }
            }

            return dic;
        }

        public void GetBaseSettings()
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\BaseSetting.xml");
            if (!File.Exists(filepath)) { SystemInit.Instance.InitBaseSetting(); return; }
            List<Dictionary<string, string>> list = FileIO.FileRWHelper.Instance.ReadSingalxmlFile(filepath);
            foreach (var item in list)
            {
                if (item.ContainsKey("AppliableTypes"))
                    SystemSettings.Instance.AppliableTypes = (AppliableFunctionType)int.Parse(item["AppliableTypes"]);
                else if (item.ContainsKey("AppliableTypesBar"))
                    SystemSettings.Instance.AppliableTypes4Bar = (AppliableFunctionType)int.Parse(item["AppliableTypesBar"]);
                else if (item.ContainsKey("IsMatchPassword4ShortProxyOut"))
                    SystemSettings.Instance.IsMatchPassword4ShortProxyOut = bool.Parse(item["IsMatchPassword4ShortProxyOut"]);
                else if (item.ContainsKey("ShortProxyOutPassword"))
                    SystemSettings.Instance.ShortProxyOutPassword = item["ShortProxyOutPassword"];
                else if (item.ContainsKey("IsMatchPassword4TransferOverCountry"))
                    SystemSettings.Instance.IsMatchPassword4TransferOverCountry = bool.Parse(item["IsMatchPassword4TransferOverCountry"]);
                else if (item.ContainsKey("TransferOverCountryPassword"))
                    SystemSettings.Instance.TransferOverCountryPassword = item["TransferOverCountryPassword"];
                else if (item.ContainsKey("IsMatchPassword4TransferForeignMoney"))
                    SystemSettings.Instance.IsMatchPassword4TransferForeignMoney = bool.Parse(item["IsMatchPassword4TransferForeignMoney"]);
                else if (item.ContainsKey("TransferForeignMoneyPassword"))
                    SystemSettings.Instance.TransferForeignMoneyPassword = item["TransferForeignMoneyPassword"];
                else if (item.ContainsKey("CureentLanguage"))
                    SystemSettings.Instance.CurrentLanguage = (UILang)int.Parse(item["CureentLanguage"]);
            }
        }

        public void GetCity2ProvinceBarList()
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\C2PBar.xml");
            if (!File.Exists(filepath)) return;

            if (SystemSettings.Instance.City2ProvinceBar == null) SystemSettings.Instance.City2ProvinceBar = new List<CNAP>();
            Dictionary<string, List<Dictionary<string, string>>> list = FileIO.FileRWHelper.Instance.ReadTwicexmlFile(filepath);
            foreach (var kv in list.Values)
            {
                foreach (var item in kv)
                    SystemSettings.Instance.City2ProvinceBar.Add(new CNAP { Code = item["CODE"], Name = item["NAME"] });
            }
        }

        private string OringalKey(string key)
        {
            if (key.Contains("/"))
            {
                key.Replace('/', '(');
                key += ")";
            }
            return key;
        }
        public List<VirtualAccountInfo> GetVirtualAllotAccountList()
        {
            List<VirtualAccountInfo> result = new List<VirtualAccountInfo>();
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\VirtualAllotAccount.xml");
            if (!File.Exists(filepath)) return result;
            List<Dictionary<string, string>> list = FileIO.FileRWHelper.Instance.ReadSingalxmlFile(filepath);
            foreach (var item in list)
            {
                result.Add(new VirtualAccountInfo
                {
                    Account = item["Account"],
                    Name = item["Name"],
                    CashType = DataConvertHelper.GetCashType(item["CashType"]),
                    OpenBankName = item["OpenBankName"]
                });
            }
            return result;
        }
        #endregion

        #region 保存文件
        public void SaveBaseSettings()
        {
            try
            {
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\BaseSetting.xml");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration declar = doc.CreateXmlDeclaration("1.0", "utf-8", "");
                doc.AppendChild(declar);
                XmlNode pnode = doc.CreateNode(XmlNodeType.Element, "BaseSettings", "");

                XmlNode node = doc.CreateNode(XmlNodeType.Element, "AppliableTypes", "");
                node.InnerText = ((int)SystemSettings.Instance.AppliableTypes).ToString();
                pnode.AppendChild(node);
                node = doc.CreateNode(XmlNodeType.Element, "AppliableTypesBar", "");
                node.InnerText = ((int)SystemSettings.Instance.AppliableTypes4Bar).ToString();
                pnode.AppendChild(node);
                node = doc.CreateNode(XmlNodeType.Element, "IsMatchPassword4ShortProxyOut", "");
                node.InnerText = SystemSettings.Instance.IsMatchPassword4ShortProxyOut.ToString();
                pnode.AppendChild(node);
                node = doc.CreateNode(XmlNodeType.Element, "ShortProxyOutPassword", "");
                node.InnerText = SystemSettings.Instance.ShortProxyOutPassword;
                pnode.AppendChild(node);
                node = doc.CreateNode(XmlNodeType.Element, "IsMatchPassword4TransferOverCountry", "");
                node.InnerText = SystemSettings.Instance.IsMatchPassword4TransferOverCountry.ToString();
                pnode.AppendChild(node);
                node = doc.CreateNode(XmlNodeType.Element, "TransferOverCountryPassword", "");
                node.InnerText = SystemSettings.Instance.TransferOverCountryPassword;
                pnode.AppendChild(node);
                node = doc.CreateNode(XmlNodeType.Element, "IsMatchPassword4TransferForeignMoney", "");
                node.InnerText = SystemSettings.Instance.IsMatchPassword4TransferForeignMoney.ToString();
                pnode.AppendChild(node);
                node = doc.CreateNode(XmlNodeType.Element, "TransferForeignMoneyPassword", "");
                node.InnerText = SystemSettings.Instance.TransferForeignMoneyPassword;
                pnode.AppendChild(node);
                node = doc.CreateNode(XmlNodeType.Element, "CureentLanguage", "");
                node.InnerText = ((int)SystemSettings.Instance.CurrentLanguage).ToString();
                pnode.AppendChild(node);

                doc.AppendChild(pnode);
                doc.Save(filepath);
            }
            catch { }
        }

        public void SaveBatchChangeSetting(Dictionary<AppliableFunctionType, MappingsRelationSettings> dic)
        {
            try
            {
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\MappingsRelation.xml");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration declar = doc.CreateXmlDeclaration("1.0", "utf-8", "");
                doc.AppendChild(declar);
                XmlNode pnode = doc.CreateNode(XmlNodeType.Element, "MappingsRelations", "");
                foreach (var kv in dic)
                {
                    string nodeName = DataConvertHelper.GetAppliableFunctionTypeString(kv.Key);
                    if (string.IsNullOrEmpty(nodeName)) continue;
                    XmlNode node = doc.CreateNode(XmlNodeType.Element, nodeName, "");

                    XmlNode n = doc.CreateNode(XmlNodeType.Element, "SeperateChar", "");
                    n.InnerText = kv.Value.SeperateChar.ToString();
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "MaxCountPerOperation", "");
                    n.InnerText = kv.Value.MaxCountPerOperation.ToString();
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "BatchFieldsMappings", "");
                    if (null != kv.Value.BatchFieldsMappings)
                    {
                        int count = 1;
                        foreach (var item in kv.Value.BatchFieldsMappings)
                        {
                            //string name = CheckKey(item.Key);
                            //XmlNode cn = doc.CreateNode(XmlNodeType.Element, name, "");
                            XmlNode cn = doc.CreateNode(XmlNodeType.Element, "a" + count.ToString(), "");
                            cn.InnerText = null == item.Value ? string.Empty : item.Value.ToString();
                            n.AppendChild(cn);
                            count++;
                        }
                    }
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "FieldsMappings", "");
                    if (null != kv.Value.FieldsMappings)
                    {
                        int count = 1;
                        foreach (var item in kv.Value.FieldsMappings)
                        {
                            //string name = CheckKey(item.Key);
                            //XmlNode cn = doc.CreateNode(XmlNodeType.Element, name, "");
                            XmlNode cn = doc.CreateNode(XmlNodeType.Element, "a" + count.ToString(), "");
                            cn.InnerText = null == item.Value ? string.Empty : item.Value.ToString();
                            n.AppendChild(cn);
                            count++;
                        }
                    }
                    node.AppendChild(n);

                    pnode.AppendChild(node);
                }
                doc.AppendChild(pnode);
                doc.Save(filepath);
            }
            catch { }
        }

        public void SaveCommonFieldList(Dictionary<AppliableFunctionType, CommonFieldType> dic)
        {
            try
            {
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\CommonField.xml");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration declar = doc.CreateXmlDeclaration("1.0", "utf-8", "");
                doc.AppendChild(declar);
                XmlNode pnode = doc.CreateNode(XmlNodeType.Element, "CommonFields", "");
                foreach (var kv in dic)
                {
                    string name = DataConvertHelper.GetAppliableFunctionTypeString(kv.Key);
                    if (string.IsNullOrEmpty(name)) continue;
                    XmlNode node = doc.CreateNode(XmlNodeType.Element, name, "");

                    XmlNode n = doc.CreateNode(XmlNodeType.Element, "CommonFieldType", "");
                    n.InnerText = ((int)kv.Value).ToString();
                    node.AppendChild(n);

                    pnode.AppendChild(node);
                }
                doc.AppendChild(pnode);
                doc.Save(filepath);
            }
            catch { }
        }

        public void SaveNoteList(Dictionary<AppliableFunctionType, List<NoticeInfo>> dic)
        {
            try
            {
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\NoticeInfo.xml");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration declar = doc.CreateXmlDeclaration("1.0", "utf-8", "");
                doc.AppendChild(declar);
                XmlNode pnode = doc.CreateNode(XmlNodeType.Element, "NoticeInfos", "");
                foreach (var kv in dic)
                {
                    XmlNode node = doc.CreateNode(XmlNodeType.Element, DataConvertHelper.GetAppliableFunctionTypeString(kv.Key), "");

                    foreach (var item in kv.Value)
                    {
                        XmlNode n = doc.CreateNode(XmlNodeType.Element, "Notice", "");
                        n.InnerText = item.Content;
                        node.AppendChild(n);
                    }
                    pnode.AppendChild(node);
                }
                doc.AppendChild(pnode);
                doc.Save(filepath);
            }
            catch { }
        }

        public void SavePayeeList(List<PayeeInfo> list)
        {
            try
            {
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\PayeeInfo.xml");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration declar = doc.CreateXmlDeclaration("1.0", "utf-8", "");
                doc.AppendChild(declar);
                XmlNode pnode = doc.CreateNode(XmlNodeType.Element, "PayeeInfos", "");
                foreach (var item in list)
                {
                    XmlNode node = doc.CreateNode(XmlNodeType.Element, "PayeeInfo", "");

                    XmlNode n = doc.CreateNode(XmlNodeType.Element, "Account", "");
                    n.InnerText = item.Account;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "AccountType", "");
                    n.InnerText = ((int)item.AccountType).ToString();
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Address", "");
                    n.InnerText = item.Address;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "BankName", "");
                    n.InnerText = item.OpenBankName;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "BankNameR", "");
                    n.InnerText = item.ClearBankName;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "BankType", "");
                    n.InnerText = ((int)item.BankType).ToString();
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "CNAPSNo", "");
                    n.InnerText = item.CNAPSNo;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "CNAPANoR", "");
                    n.InnerText = item.CNAPSNoR;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Email", "");
                    n.InnerText = item.Email;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Fax", "");
                    n.InnerText = item.Fax;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Name", "");
                    n.InnerText = item.Name;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "CertifyPaperType", "");
                    n.InnerText = ((int)item.CertifyPaperType).ToString();
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "CertifyPaperNo", "");
                    n.InnerText = item.CertifyPaperNo;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "PNo", "");
                    n.InnerText = item.SerialNo;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Telephone", "");
                    n.InnerText = item.Telephone;
                    node.AppendChild(n);

                    pnode.AppendChild(node);
                }
                doc.AppendChild(pnode);
                doc.Save(filepath);
            }
            catch { }
        }

        public void SaveElecTicketRelationAccountList(List<ElecTicketRelationAccount> list)
        {
            try
            {
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\ElecTicketRelationAccount.xml");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration declar = doc.CreateXmlDeclaration("1.0", "utf-8", "");
                doc.AppendChild(declar);
                XmlNode pnode = doc.CreateNode(XmlNodeType.Element, "ElecTicketRelationAccounts", "");
                foreach (var item in list)
                {
                    XmlNode node = doc.CreateNode(XmlNodeType.Element, "ElecTicketRelationAccount", "");

                    XmlNode n = doc.CreateNode(XmlNodeType.Element, "Account", "");
                    n.InnerText = item.Account;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Name", "");
                    n.InnerText = item.Name;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "OpenBankName", "");
                    n.InnerText = item.OpenBankName;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "OpenBankNo", "");
                    n.InnerText = item.OpenBankNo;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "PersonType", "");
                    n.InnerText = ((int)item.PersonType).ToString();
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "SerialNo", "");
                    n.InnerText = item.SerialNo;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Tel_First", "");
                    n.InnerText = item.Tel_First;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Email_First", "");
                    n.InnerText = item.Email_First;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Tel_Second", "");
                    n.InnerText = item.Tel_Second;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Email_Second", "");
                    n.InnerText = item.Email_Second;
                    node.AppendChild(n);

                    pnode.AppendChild(node);
                }
                doc.AppendChild(pnode);
                doc.Save(filepath);
            }
            catch { }
        }

        public void SaveInitiativeAllotAccountList(List<InitiativeAllotAccount> list)
        {
            try
            {
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\InitiativeAllotAccount.xml");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration declar = doc.CreateXmlDeclaration("1.0", "utf-8", "");
                doc.AppendChild(declar);
                XmlNode pnode = doc.CreateNode(XmlNodeType.Element, "InitiativeAllotAccounts", "");
                foreach (var item in list)
                {
                    XmlNode node = doc.CreateNode(XmlNodeType.Element, "InitiativeAllotAccount", "");

                    XmlNode n = doc.CreateNode(XmlNodeType.Element, "Account", "");
                    n.InnerText = item.Account;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Name", "");
                    n.InnerText = item.Name;
                    node.AppendChild(n);

                    pnode.AppendChild(node);
                }
                doc.AppendChild(pnode);
                doc.Save(filepath);
            }
            catch { }
        }

        public void SavePayeeTransferGlobalList(List<PayeeInfo4TransferGlobal> list)
        {
            try
            {
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\PayeeTransferGlobalInfo.xml");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration declar = doc.CreateXmlDeclaration("1.0", "utf-8", "");
                doc.AppendChild(declar);
                XmlNode pnode = doc.CreateNode(XmlNodeType.Element, "PayeeTransferGlobalInfos", "");
                foreach (var item in list)
                {
                    XmlNode node = doc.CreateNode(XmlNodeType.Element, "PayeeTransferGlobalInfo", "");

                    XmlNode n = doc.CreateNode(XmlNodeType.Element, "Account", "");
                    n.InnerText = item.Account;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "AccountType", "");
                    n.InnerText = ((int)item.AccountType).ToString();
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Address", "");
                    n.InnerText = item.Address;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "OpenBankName", "");
                    n.InnerText = item.OpenBankName;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "OpenBankAddress", "");
                    n.InnerText = item.OpenBankAddress;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "OpenBankType", "");
                    n.InnerText = ((int)item.OpenBankType).ToString();
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "NameofCountry", "");
                    n.InnerText = item.NameofCountry;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "CodeofCountry", "");
                    n.InnerText = item.CodeofCountry;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Email", "");
                    n.InnerText = item.Email;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Fax", "");
                    n.InnerText = item.Fax;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Name", "");
                    n.InnerText = item.Name;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "CorrespondentBankName", "");
                    n.InnerText = item.CorrespondentBankName;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "CorrespondentBankAddress", "");
                    n.InnerText = item.CorrespondentBankAddress;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "AccountInCorrespondentBank", "");
                    n.InnerText = item.AccountInCorrespondentBank;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "SerialNo", "");
                    n.InnerText = item.SerialNo;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Telephone", "");
                    n.InnerText = item.Telephone;
                    node.AppendChild(n);

                    pnode.AppendChild(node);
                }
                doc.AppendChild(pnode);
                doc.Save(filepath);
            }
            catch { }
        }

        public void SavePayerList(List<PayerInfo> list)
        {
            try
            {
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\PayerInfo.xml");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration declar = doc.CreateXmlDeclaration("1.0", "utf-8", "");
                doc.AppendChild(declar);
                XmlNode pnode = doc.CreateNode(XmlNodeType.Element, "PayerInfos", "");
                foreach (var item in list)
                {
                    XmlNode node = doc.CreateNode(XmlNodeType.Element, "PayerInfo", "");

                    XmlNode n = doc.CreateNode(XmlNodeType.Element, "Account", "");
                    n.InnerText = item.Account;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Name", "");
                    n.InnerText = item.Name;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "CashType", "");
                    n.InnerText = ((int)item.CashType).ToString();
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "ServiceList", "");
                    n.InnerText = ((int)item.ServiceList).ToString();
                    node.AppendChild(n);


                    if ((SystemSettings.Instance.CurrentVersion & VersionType.v403bar) == VersionType.v403bar)
                    {
                        n = doc.CreateNode(XmlNodeType.Element, "ServiceListBar", "");
                        n.InnerText = ((int)item.ServiceListBar).ToString();
                        node.AppendChild(n);
                    }

                    pnode.AppendChild(node);
                }
                doc.AppendChild(pnode);
                doc.Save(filepath);
            }
            catch { }
        }
        public void SaveVirtualAllotAccountList(List<VirtualAccountInfo> list)
        {
            try
            {
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\VirtualAllotAccount.xml");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration declar = doc.CreateXmlDeclaration("1.0", "utf-8", "");
                doc.AppendChild(declar);
                XmlNode pnode = doc.CreateNode(XmlNodeType.Element, "VirtualAllotAccounts", "");
                foreach (var item in list)
                {
                    XmlNode node = doc.CreateNode(XmlNodeType.Element, "VirtualAllotAccount", "");

                    XmlNode n = doc.CreateNode(XmlNodeType.Element, "Account", "");
                    n.InnerText = item.Account;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "Name", "");
                    n.InnerText = item.Name;
                    node.AppendChild(n);

                    n = doc.CreateNode(XmlNodeType.Element, "CashType", "");
                    n.InnerText = item.CashType.ToString();
                    node.AppendChild(n);
                    pnode.AppendChild(node);

                    n = doc.CreateNode(XmlNodeType.Element, "OpenBankName", "");
                    n.InnerText = item.OpenBankName;
                    node.AppendChild(n);
                    pnode.AppendChild(node);
                }
                doc.AppendChild(pnode);
                doc.Save(filepath);
            }
            catch { }
        }
        private string CheckKey(string key)
        {
            if (key.Contains("(") && key.Contains(")"))
            {
                key.Remove(key.Length - 1);
                key.Replace("(", "");
            }
            return key;
        }
        #endregion

        public void SaveAllMappingSettings()
        {
            try
            {
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\MS.txt");

                List<string> content = new List<string>();

                foreach (var item in PrequisiteDataProvideNode.InitialProvide.AppliableFunctionTypeList)
                {
                    if (item == AppliableFunctionType._Empty) continue;
                    content.Add(EnumNameHelper<AppliableFunctionType>.GetEnumDescription(item));
                    content.Add("Field  Desc");

                    MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(item);
                    List<string> list = SystemInit.Instance.GetRegexDescription(item);
                    int index = 0;
                    foreach (var field in mrs.FieldsMappings.Keys)
                    {
                        content.Add(field + "    " + list[index++]);
                    }
                }

                FileIO.FileRWHelper.Instance.ExportTXTDocument(content, filepath);
            }
            catch { }
        }
    }
}
