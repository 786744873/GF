using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.ConvertHelper;
using CommonClient.Utilities;

namespace CommonClient.MatchFile
{
    public class MatchFileDataHelper
    {
        #region 单例
        private static object lock_obj = new object();
        private static MatchFileDataHelper m_instance;
        /// <summary>
        /// 单一实例
        /// </summary>
        public static MatchFileDataHelper Instance
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
                                m_instance = new MatchFileDataHelper();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        /// <summary>
        /// 获取文件头信息，各列字段信息
        /// 默认读取第一行位列头信息
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public List<string> GetFileHeader(string filepath, string separator, int startrowindex)
        {
            return GetFileRowData(filepath, separator, startrowindex);
        }

        /// <summary>
        /// 获取文件头信息，各列字段信息
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public List<string> GetFileRowData(string filepath, string separator, int rowindex)
        {
            List<string> list = new List<string>();

            if (!System.IO.File.Exists(filepath)) return list;

            if (filepath.ToLower().EndsWith(".txt"))
            { list = FileIO.FileRWHelper.Instance.GetFileTXTHeader(filepath, separator, rowindex); }
            else if (filepath.ToLower().EndsWith(".csv"))
            { list = FileIO.FileRWHelper.Instance.GetFileCSVHeader(filepath, rowindex); }
            else if (filepath.ToLower().EndsWith(".xls") || filepath.ToLower().EndsWith(".xlsx"))
            { list = FileIO.FileRWHelper.Instance.GetFileExcelHeader(filepath, rowindex); }

            return list;
        }

        /// <summary>
        /// 获取文件数据
        /// List[0]==》错误信息
        /// List[1]==》对象列表
        /// </summary>
        /// <param name="aft"></param>
        /// <param name="filepath"></param>
        /// <param name="mrs"></param>
        /// <param name="batch"></param>
        /// <returns></returns>
        public List<object> GetFileData(AppliableFunctionType aft, FunctionInSettingType fst, string filepath, MappingsRelationSettings mrs, BatchHeader batch)
        {
            return GetFileData(aft, fst, filepath, mrs.SeperateChar, mrs.MaxCountPerOperation, mrs.BatchFieldsMappings, mrs.FieldsMappings, mrs.StartRowIndex, batch);
        }

        /// <summary>
        /// 获取文件中的数据信息，并返回相关数据对象列表
        /// </summary>
        /// <param name="aft"></param>
        /// <param name="filepath"></param>
        /// <param name="separator"></param>
        /// <param name="maxcount"></param>
        /// <returns></returns>
        public List<object> GetFileData(AppliableFunctionType aft, FunctionInSettingType fst, string filepath, string separator, int maxcount, Dictionary<string, string> dicbatch, Dictionary<string, string> dicfield, int startrowindex, BatchHeader batch)
        {
            List<object> result = new List<object>();
            object list = null;
            if (AppliableFunctionType._Empty == aft && FunctionInSettingType.Empty == fst)
            {
                result.Add(MultiLanguageConvertHelper.Instance.Information_Select_BusinessType);
                result.Add(list);
                return result;
            }
            try
            {
                bool flag = AppliableFunctionType.AgentExpressIn == aft
                || AppliableFunctionType.AgentExpressOut == aft
                || AppliableFunctionType.AgentNormalIn == aft
                || AppliableFunctionType.AgentNormalOut == aft
                || AppliableFunctionType.InitiativeAllot == aft
                || AppliableFunctionType.AgentExpressOut4Bar == aft;

                #region 获取文件中的列头信息
                //批信息
                //List<string> headerbatch = !flag ? new List<string>() : GetFileHeader(filepath, separator);
                //笔信息
                List<string> headersingal = new List<string>();
                try
                {
                    headersingal = GetFileHeader(filepath, separator, startrowindex); //!flag ? GetFileHeader(filepath, separator) : GetFileRowData(filepath, separator, 1);
                }
                catch (FileLoadException fle) { result.AddRange(new object[] { fle.Message, null }); return result; }
                #endregion

                #region 获取字段的匹配顺序列表
                //List<int> indexbatch = new List<int>();

                //批信息
                //if (flag)
                //{
                //indexbatch = MatchFieldIndex(dicbatch, headerbatch, separator);
                //}

                //笔信息
                List<int> indexsingal = MatchFieldIndex(dicfield, headersingal, separator);
                #endregion

                #region 检验匹配列表中是否有缺失的字段
                //if ((flag && indexbatch.FindAll(o => o == -1).Count > 0) || (indexsingal.FindAll(o => o == -1).Count > 0))
                if (indexsingal.FindAll(o => o == -1).Count > 0)
                {
                    result.Add(MultiLanguageConvertHelper.Instance.Information_DataFieldMissing_OpenFile_Fail);
                    result.Add(list);
                    return result;
                }
                #endregion

                #region 获取数据列表
                List<List<string>> fields = new List<List<string>>();
                try
                {
                    fields = MatchFieldsData(filepath, indexsingal, separator, maxcount, startrowindex + 1);
                }
                catch (FileLoadException fle) { result.AddRange(new object[] { fle.Message, null }); return result; }
                //List<string> batchs = new List<string>();
                //if (!flag)
                //    batchs = GetFileRowData(filepath, separator, 2);
                #endregion

                string ErrorMessage = string.Empty;
                try
                {
                    //获取数据对象列表
                    if (aft != AppliableFunctionType._Empty)
                        list = !flag ? MatchBusinessObject(aft, fields) : MatchBusinessObject(aft, fields, batch);
                    else if (aft == AppliableFunctionType._Empty && fst != FunctionInSettingType.Empty)
                        list = MatchBusinessObject(fst, fields);
                }
                catch { ErrorMessage = MultiLanguageConvertHelper.Instance.Information_DataFieldMissing_OpenFile_Fail; }

                //检验对象中是否存在缺失的必填数据项
                if (string.IsNullOrEmpty(ErrorMessage))
                {
                    if (aft != AppliableFunctionType._Empty)
                    {
                        if (aft == AppliableFunctionType.AgentExpressOut4Bar)
                        {
                            if (list != null)
                            {
                                List<object> lt = list as List<object>;
                                if (null != list)
                                {
                                    string str = CheckDataAvilidLow(lt[0], aft);
                                    if (!string.IsNullOrEmpty(str))
                                        ErrorMessage = string.Format("中行数据中：{0}", str);
                                    if (string.IsNullOrEmpty(ErrorMessage))
                                    {
                                        str = CheckDataAvilidLow(lt[1], aft);
                                        if (!string.IsNullOrEmpty(str))
                                            ErrorMessage = string.Format("他行数据中：{0}", str);
                                    }
                                }
                            }
                        }
                        else
                            ErrorMessage = CheckDataAvilidLow(list, aft);
                    }
                    else if (fst != FunctionInSettingType.Empty)
                        ErrorMessage = CheckDataAvilidHigh(list, fst);
                }

                result.Add(ErrorMessage);
                result.Add(list);
            }
            catch
            {
                result.Add(MultiLanguageConvertHelper.Instance.Information_OpenFile_Fail);
                result.Add(list);
            }
            return result;
        }

        /// <summary>
        /// 保存成TXT文件
        /// </summary>
        /// <param name="list"></param>
        /// <param name="aft"></param>
        /// <param name="filepath"></param>
        public bool SaveDataToTXT(object list, AppliableFunctionType aft, string filepath)
        {
            bool flag = false;
            switch (aft)
            {
                case AppliableFunctionType.TransferOverBankIn:
                case AppliableFunctionType.TransferOverBankOut:
                case AppliableFunctionType.TransferWithCorp:
                case AppliableFunctionType.TransferWithIndiv:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, list as List<TransferAccount>, filepath, CommonInformations.Instance.GetAllAmount(list));
                    break;
                case AppliableFunctionType.AgentExpressIn:
                case AppliableFunctionType.AgentExpressOut:
                    List<object> tempE = list as List<object>;
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, tempE[1] as List<AgentExpress>, tempE[0] as BatchHeader, filepath);
                    break;
                case AppliableFunctionType.AgentNormalIn:
                case AppliableFunctionType.AgentNormalOut:
                    List<object> tempN = list as List<object>;
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, tempN[1] as List<AgentNormal>, tempN[0] as BatchHeader, filepath);
                    break;
                case AppliableFunctionType.TransferOverCountry:
                case AppliableFunctionType.TransferForeignMoney:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, list as List<TransferGlobal>, filepath, CommonInformations.Instance.GetAllAmount(list));
                    break;
                case AppliableFunctionType.ElecTicketRemit:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, list as List<ElecTicketRemit>, filepath, CommonInformations.Instance.GetAllAmount(list));
                    break;
                case AppliableFunctionType.ElecTicketBackNote:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, list as List<ElecTicketBackNote>, filepath);
                    break;
                case AppliableFunctionType.ElecTicketPayMoney:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, list as List<ElecTicketPayMoney>, filepath);
                    break;
                case AppliableFunctionType.ElecTicketTipExchange:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, list as List<ElecTicketAutoTipExchange>, filepath);
                    break;
                case AppliableFunctionType.PurchaserOrder:
                case AppliableFunctionType.SellerOrder:
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, list as List<SpplyFinancingOrder>, filepath);
                    break;
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                case AppliableFunctionType.BillofDebtReceivableSeller:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, list as List<SpplyFinancingBill>, filepath);
                    break;
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, list as List<SpplyFinancingPayOrReceipt>, filepath);
                    break;
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, list as List<SpplyFinancingApply>, filepath);
                    break;
                case AppliableFunctionType.InitiativeAllot:
                    List<object> tempI = list as List<object>;
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, tempI[1] as List<InitiativeAllot>, tempI[0] as BatchHeader, filepath);
                    break;
                case AppliableFunctionType.ElecTicketPool:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, list as List<ElecTicketPool>, filepath, CommonInformations.Instance.GetAllAmount(list));
                    break;
                case AppliableFunctionType.TransferOverCountry4Bar:
                case AppliableFunctionType.TransferForeignMoney4Bar:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateDATDocumentBar(aft, list as List<TransferGlobal>, filepath, CommonInformations.Instance.GetAllAmount(list));
                    break;
                case AppliableFunctionType.AgentExpressOut4Bar:
                    List<object> tempEB = list as List<object>;
                    if (tempEB.Count > 0)
                    {
                        string filepathc1 = filepath.Replace("-C2-", "-C1-");
                        string filepathc2 = filepath.Replace("-C1-", "-C2-");
                        foreach (var item in tempEB)
                        {
                            List<object> tempEBB = item as List<object>;
                            AgentTransferBankType banktype = (tempEBB[0] as BatchHeader).BankType;
                            if ((tempEBB[1] as List<AgentExpress>).Count > 0)
                            {
                                if (banktype == AgentTransferBankType.Boc)
                                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateDATDocumentBar(aft, tempEBB[0] as BatchHeader, tempEBB[1] as List<AgentExpress>, filepathc1, CommonInformations.Instance.GetAllAmount(tempEBB[1])) || flag;
                                else flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateDATDocumentBar(aft, tempEBB[0] as BatchHeader, tempEBB[1] as List<AgentExpress>, filepathc2, CommonInformations.Instance.GetAllAmount(tempEBB[1])) || flag;
                            }
                        }
                    }
                    else flag = false;
                    break;
                case AppliableFunctionType.UnitivePaymentFC:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(aft, list as List<UnitivePaymentForeignMoney>, filepath);
                    break;
            }
            return flag;
        }

        public bool SaveDataToTXT(object list, FunctionInSettingType fst, string filepath)
        {
            bool flag = false;
            switch (fst)
            {
                case FunctionInSettingType.PayeeMg:
                    flag = TemplateHelper.BatchConsignDataTemplateHelper.Instance.CreateTxtDocument(fst, list as List<PayeeInfo>, filepath);
                    break;
            }
            return flag;
        }

        private string CreateFilePath(string filepath)
        {
            string file = string.Empty;
            int startindex = filepath.LastIndexOf('/') + 1;
            int endindex = filepath.LastIndexOf('.');
            file = filepath.Substring(startindex, endindex - startindex) + DateTime.Now.ToLongDateString() + ".txt";
            return file;
        }

        /// <summary>
        /// 匹配列顺序
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<int> MatchFieldIndex(string filepath, List<string> list, string separator, int startrowindex)
        {
            List<int> intlist = new List<int>();
            List<string> strlist = new List<string>();
            list = GetFileHeader(filepath, separator, startrowindex);

            foreach (string item in list)
            {
                int index = -1;
                if (strlist.Exists(o => o == item))
                    index = strlist.FindIndex(0, o => o == item);
                intlist.Add(index);
            }

            return intlist;
        }

        /// <summary>
        /// 匹配列顺序
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<int> MatchFieldIndex(Dictionary<string, string> dic, List<string> flist, string separator)
        {
            List<int> intlist = new List<int>();
            List<string> mlist = new List<string>();
            foreach (var item in dic.Values)
            {
                mlist.Add(item.ToString());
            }

            foreach (string item in mlist)
            {
                if (string.IsNullOrEmpty(item)) continue;
                int index = -1;
                if (flist.Exists(o => o == item))
                    index = flist.FindIndex(0, o => o == item);
                intlist.Add(index);
            }

            return intlist;
        }

        /// <summary>
        /// 获取各字段数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="indexList"></param>
        /// <param name="separator"></param>
        /// <param name="maxcount"></param>
        /// <returns></returns>
        private List<List<string>> MatchFieldsData(string filepath, List<int> indexList, string separator, int maxcount)
        {
            return MatchFieldsData(filepath, indexList, separator, maxcount, 2);
        }

        /// <summary>
        /// 获取各字段数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="indexList"></param>
        /// <param name="separator"></param>
        /// <param name="maxcount"></param>
        /// <returns></returns>
        private List<List<string>> MatchFieldsData(string filepath, List<int> indexList, string separator, int maxcount, int startRowIndex)
        {
            List<List<string>> list = new List<List<string>>();

            if (!System.IO.File.Exists(filepath)) return list;

            if (filepath.ToLower().EndsWith(".txt"))
            { list = FileIO.FileRWHelper.Instance.GetTXTFieldsData(filepath, indexList, separator, maxcount, startRowIndex); }
            else if (filepath.ToLower().EndsWith(".csv"))
            { list = FileIO.FileRWHelper.Instance.GetCSVFieldsData(filepath, indexList, maxcount, startRowIndex); }
            else if (filepath.ToLower().EndsWith(".xls") || filepath.ToLower().EndsWith(".xlsx"))
            { list = FileIO.FileRWHelper.Instance.GetExcelFieldsData(filepath, indexList, maxcount, startRowIndex); }

            return list;
        }

        /// <summary>
        /// 获取匹配业务对象
        /// </summary>
        /// <param name="aft"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        private object MatchBusinessObject(AppliableFunctionType aft, List<List<string>> fields)
        {
            object list = null;

            switch (aft)
            {
                case AppliableFunctionType.TransferWithIndiv:
                case AppliableFunctionType.TransferWithCorp:
                    list = MatchTransferAccounts(aft, fields); break;
                case AppliableFunctionType.AgentExpressIn:
                case AppliableFunctionType.AgentExpressOut:
                case AppliableFunctionType.AgentExpressOut4Bar:
                    list = MatchAgentExpress(aft, fields); break;
                case AppliableFunctionType.AgentNormalIn:
                case AppliableFunctionType.AgentNormalOut:
                    list = MatchAgentNormals(aft, fields); break;
                case AppliableFunctionType.TransferOverBankIn:
                case AppliableFunctionType.TransferOverBankOut:
                    list = MatchOverBankTransfers(aft, fields); break;
                case AppliableFunctionType.ElecTicketRemit:
                    list = MatchElecTicketRemits(aft, fields); break;
                case AppliableFunctionType.ElecTicketBackNote:
                    list = MatchElecTicketBackNotes(aft, fields); break;
                case AppliableFunctionType.ElecTicketPayMoney:
                    list = MatchElecTicketPayMoneys(aft, fields); break;
                case AppliableFunctionType.ElecTicketTipExchange:
                    list = MatchElecTicketAutoTipExchanges(aft, fields); break;
                case AppliableFunctionType.ElecTicketPool:
                    list = MatchElecTicketPools(aft, fields); break;
                case AppliableFunctionType.TransferOverCountry:
                case AppliableFunctionType.TransferForeignMoney:
                case AppliableFunctionType.TransferForeignMoney4Bar:
                case AppliableFunctionType.TransferOverCountry4Bar:
                    list = MatchTransferGlobals(aft, fields); break;
                case AppliableFunctionType.PurchaserOrder:
                case AppliableFunctionType.SellerOrder:
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                    list = MatchSpplyFinancingOrders(aft, fields); break;
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                case AppliableFunctionType.BillofDebtReceivableSeller:
                    list = MatchSpplyFinancingBills(aft, fields); break;
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    list = MatchSpplyFinancingPayOrReceipts(aft, fields); break;
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                    list = MatchSpplyFinancingApplys(aft, fields); break;
                case AppliableFunctionType.UnitivePaymentRMB:
                    list = MatchUnitivePaymentRMB(aft, fields); break;
                case AppliableFunctionType.UnitivePaymentFC:
                    list = MatchUnitivePaymentForeignMoney(aft, fields); break;
            }
            return list;
        }

        /// <summary>
        /// 获取匹配业务对象
        /// </summary>
        /// <param name="fst"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        private object MatchBusinessObject(FunctionInSettingType fst, List<List<string>> fields)
        {
            object list = null;
            switch (fst)
            {
                case FunctionInSettingType.PayeeMg:
                    list = MatchPayee(fst, fields); break;
                default: break;
            }
            return list;
        }

        /// <summary>
        /// 获取匹配业务对象
        /// </summary>
        /// <param name="aft"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        private object MatchBusinessObject(AppliableFunctionType aft, List<List<string>> fields, List<string> batch)
        {
            object list = null;

            switch (aft)
            {
                //case AppliableFunctionType.TransferWithIndiv:
                //case AppliableFunctionType.TransferWithCorp:
                //    list = MatchTransferAccounts(aft, fields); break;
                case AppliableFunctionType.AgentExpressIn:
                case AppliableFunctionType.AgentExpressOut:
                    list = MatchAgentExpress(aft, fields); break;
                case AppliableFunctionType.AgentNormalIn:
                case AppliableFunctionType.AgentNormalOut:
                    list = MatchAgentNormals(aft, fields); break;
                //case AppliableFunctionType.TransferOverBankIn:
                //case AppliableFunctionType.TransferOverBankOut:
                //    list = MatchOverBankTransfers(aft, fields); break;
            }
            return list;
        }

        /// <summary>
        /// 获取匹配业务对象
        /// </summary>
        /// <param name="aft"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        private object MatchBusinessObject(AppliableFunctionType aft, List<List<string>> fields, BatchHeader batch)
        {
            object list = null;

            switch (aft)
            {
                //case AppliableFunctionType.TransferWithIndiv:
                //case AppliableFunctionType.TransferWithCorp:
                //    list = MatchTransferAccounts(aft, fields); break;
                case AppliableFunctionType.AgentExpressIn:
                case AppliableFunctionType.AgentExpressOut:
                    list = MatchAgentExpress(aft, fields, batch); break;
                case AppliableFunctionType.AgentExpressOut4Bar:
                    batch.BankType = AgentTransferBankType.Boc;
                    List<object> listboc = MatchAgentExpress(aft, fields, batch);
                    BatchHeader bhother = new BatchHeader() { BankType = AgentTransferBankType.Other, Payer = batch.Payer, AgentFunctionType_Express = batch.AgentFunctionType_Express };
                    List<object> listother = MatchAgentExpress(aft, fields, bhother);
                    list = new List<object> { listboc, listother };
                    break;
                case AppliableFunctionType.AgentNormalIn:
                case AppliableFunctionType.AgentNormalOut:
                    list = MatchAgentNormals(aft, fields, batch); break;
                //case AppliableFunctionType.TransferOverBankIn:
                //case AppliableFunctionType.TransferOverBankOut:
                //    list = MatchOverBankTransfers(aft, fields); break;
                case AppliableFunctionType.InitiativeAllot:
                    list = MatchInitiativeAllots(aft, fields, batch); break;
                case AppliableFunctionType.VirtualAccountTransfer:
                    list = MatchVirtualAccount(aft, fields); break;
            }
            return list;
        }

        #region
        private List<TransferAccount> MatchTransferAccounts(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<TransferAccount> list = new List<TransferAccount>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            TransferAccount ta = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                ta = new TransferAccount();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }

                    if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_Amount.Equals(fieldNames[findex]))
                    { if (!string.IsNullOrEmpty(data[dindex]))ta.PayAmount = DataConvertHelper.Instance.FormatNum(data[dindex]); }
                    else if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeName.Equals(fieldNames[findex]))
                        ta.PayeeName = data[dindex].ToString();
                    else if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeAccount.Equals(fieldNames[findex]))
                        ta.PayeeAccount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                    else if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeOpenBankName.Equals(fieldNames[findex]))
                        ta.PayeeOpenBank = data[dindex].ToString();
                    else if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_CNAPSNo.Equals(fieldNames[findex]))
                        ta.CNAPSNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                    else if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayerAccount.Equals(fieldNames[findex]))
                        ta.PayerAccount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                    else if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayFeeAccount.Equals(fieldNames[findex]))
                    { if (!string.IsNullOrEmpty(data[dindex])) ta.PayFeeNo = DataConvertHelper.Instance.FormatNum(data[dindex]); }
                    else if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_Addtion.Equals(fieldNames[findex]))
                        ta.Addition = data[dindex].ToString();
                    else if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_OperateOrder.Equals(fieldNames[findex]))
                        ta.TChanel = DataConvertHelper.Instance.GetTransferChanelType(data[dindex].ToString());
                    else if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_Email.Equals(fieldNames[findex]))
                        ta.Email = data[dindex].ToString();
                    else if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_CustomerRef.Equals(fieldNames[findex]))
                        ta.CustomerRef = data[dindex].ToString();
                    //    case "付款人名称": ta.PayerName = data[dindex].ToString(); break;
                    //    case "付款货币": ta.PayCashType = CashType.CNY; break;
                    else if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayDate.Equals(fieldNames[findex]))
                        ta.PayDatetime = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex].ToString()).Replace("/", "");
                    else if (MultiLanguageConvertHelper.Instance.Transfer_Mappings_IsBOCFlag.Equals(fieldNames[findex]))
                        ta.AccountBankType = DataConvertHelper.Instance.GetAccountBankTypeObject(data[dindex], aft);
                    findex++;
                    dindex++;
                }
                if (ta.PayFeeNo == ta.PayerAccount) ta.PayFeeType = ChargingFeeAccountType.SameAsPayingAccount;
                if (ta.AccountBankType == AccountBankType.Empty && !string.IsNullOrEmpty(ta.CNAPSNo))
                {
                    ResultData rd = DataCheckCenter.Instance.CheckCNAPSNo(null, ta.CNAPSNo, null);
                    if (rd.Result)
                        ta.AccountBankType = ta.CNAPSNo.StartsWith("104") ? AccountBankType.BocAccount : AccountBankType.OtherBankAccount;
                }
                list.Add(ta);
            }

            return list;
        }

        private List<object> MatchAgentExpress(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<object> list = new List<object>();
            List<AgentExpress> aelist = new List<AgentExpress>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            BatchHeader batch = new BatchHeader();
            AgentExpress ae;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                ae = new AgentExpress();
                foreach (string fieldname in flist)
                {
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (AppliableFunctionType.AgentExpressOut == aft)
                    {
                        if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_CutomerRef.Equals(fieldNames[findex]))
                        {
                            if (string.IsNullOrEmpty(batch.ProtecolNo))
                                batch.ProtecolNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        }
                        //    case "付款行联行号": break;
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_PayerAccount.Equals(fieldNames[findex]))
                        {
                            if (string.IsNullOrEmpty(batch.Payer.Account))
                                batch.Payer.Account = data[dindex].ToString();
                        }
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_PayeeBankName.Equals(fieldNames[findex]))
                        {
                            if (string.IsNullOrEmpty(batch.Bank))
                                batch.Bank = data[dindex].ToString();
                        }
                        //    case "代发卡类型": if (string.IsNullOrEmpty(batch.CardType_Normal)) batch.CardType = (AgentCardType)int.Parse(data[dindex].ToString()); break;
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_Usege.Equals(fieldNames[findex]))
                        {
                            if (string.IsNullOrEmpty(batch.UseType))
                                batch.UseType = data[dindex].ToString();
                        }
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_PayDate.Equals(fieldNames[findex]))
                            batch.TransferDatetime = DateTime.Parse(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Batch_Addtion.Equals(fieldNames[findex]))
                        {
                            if (string.IsNullOrEmpty(batch.Addtion))
                                batch.Addtion = data[dindex].ToString();
                        }

                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Amount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))ae.Amount = data[dindex].ToString(); }
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeName.Equals(fieldNames[findex]))
                            ae.AccountName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccount.Equals(fieldNames[findex]))
                            ae.AccountNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo.Equals(fieldNames[findex]))
                            ae.Province = DataConvertHelper.Instance.GetProvince(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyCardType.Equals(fieldNames[findex]))
                            ae.CertifyPaperType = DataConvertHelper.Instance.GetAgentExpressCertifyPaperType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo.Equals(fieldNames[findex]))
                            ae.CertifyPaperNo = data[dindex].ToString();
                    }
                    else
                    {
                        if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Batch_CutomerRef.Equals(fieldNames[findex]))
                        {
                            if (string.IsNullOrEmpty(batch.ProtecolNo))
                                batch.ProtecolNo = data[dindex].ToString();
                        }
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Batch_PayeeAccount.Equals(fieldNames[findex]))
                        {
                            if (string.IsNullOrEmpty(batch.ProtecolNo)) batch.Payer.Account = data[dindex].ToString();
                        }
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Batch_Usege.Equals(fieldNames[findex]))
                        {
                            if (string.IsNullOrEmpty(batch.UseType))
                                batch.UseType = data[dindex].ToString();
                        }
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Batch_PayDate.Equals(fieldNames[findex]))
                            batch.TransferDatetime = DateTime.Parse(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Batch_Addtion.Equals(fieldNames[findex]))
                        {
                            if (string.IsNullOrEmpty(batch.Addtion))
                                batch.Addtion = data[dindex].ToString();
                        }

                        else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Amount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))ae.Amount = data[dindex].ToString(); }
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerName.Equals(fieldNames[findex]))
                            ae.AccountName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerAccount.Equals(fieldNames[findex]))
                            ae.AccountNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerOpenBankNoOrCNAPSNo.Equals(fieldNames[findex]))
                            ae.Province = DataConvertHelper.Instance.GetProvince(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyCardType.Equals(fieldNames[findex]))
                            ae.CertifyPaperType = DataConvertHelper.Instance.GetAgentExpressCertifyPaperType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyNo.Equals(fieldNames[findex]))
                            ae.CertifyPaperNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_SerialNo.Equals(fieldNames[findex]))
                            ae.ProtecolNo = data[dindex].ToString();
                    }
                    findex++;
                    dindex++;
                }
                aelist.Add(ae);
            }
            list.Add(batch);
            list.Add(aelist);

            return list;
        }

        private List<object> MatchAgentExpress(AppliableFunctionType aft, List<List<string>> fields, BatchHeader batch)
        {
            List<object> list = new List<object>();
            List<AgentExpress> aelist = new List<AgentExpress>();

            Dictionary<string, string> dicbatch = SystemSettings.Instance.BatchMappingSettings[aft].BatchFieldsMappings;
            Dictionary<string, string> dicsingal = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dicbatch.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            flist = new List<string>();
            flist.AddRange(dicsingal.Keys);
            AgentExpress ae = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                try
                {
                    ae = new AgentExpress();
                    foreach (string fieldname in flist)
                    {
                        if (findex >= flist.Count) break;
                        if (string.IsNullOrEmpty(dicsingal[fieldname].ToString())) { findex++; continue; }
                        if (AppliableFunctionType.AgentExpressOut == aft)
                        {
                            #region
                            if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Amount.Equals(fieldNames[findex]))
                            { if (!string.IsNullOrEmpty(data[dindex]))    ae.Amount = DataConvertHelper.Instance.FormatNum(data[dindex]); }
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeName.Equals(fieldNames[findex]))
                                ae.AccountName = data[dindex];
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccount.Equals(fieldNames[findex]))
                                ae.AccountNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo.Equals(fieldNames[findex]))
                            {
                                if (batch.BankType == AgentTransferBankType.Boc)
                                {
                                    ae.Province = DataConvertHelper.Instance.GetProvince(data[dindex].ToString());
                                    ResultData rd = DataCheckCenter.Instance.CheckProvince(null, data[dindex], null);
                                    if (!rd.Result) throw new Exception(rd.Message);
                                }
                                else if (batch.BankType == AgentTransferBankType.Other)
                                {
                                    ae.BankNo = data[dindex].ToString();
                                    ResultData rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data[dindex], null);
                                    if (!rd.Result) throw new Exception(rd.Message);
                                }
                            }
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyCardType.Equals(fieldNames[findex]))
                                ae.CertifyPaperType = DataConvertHelper.Instance.GetAgentExpressCertifyPaperType(data[dindex].ToString());
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo.Equals(fieldNames[findex]))
                                ae.CertifyPaperNo = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Usage.Equals(fieldNames[findex]))
                                ae.UsageType = DataConvertHelper.Instance.GetAgentExpressFunctionType(data[dindex].ToString());
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankName.Equals(fieldNames[findex]))
                                ae.BankName = data[dindex].ToString();
                            #endregion
                        }
                        else if (AppliableFunctionType.AgentExpressOut4Bar == aft)
                        {
                            #region
                            if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Amount.Equals(fieldNames[findex]))
                            { if (!string.IsNullOrEmpty(data[dindex]))    ae.Amount = DataConvertHelper.Instance.FormatNum(data[dindex]); }
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeName.Equals(fieldNames[findex]))
                                ae.AccountName = data[dindex];
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccount.Equals(fieldNames[findex]))
                                ae.AccountNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo.Equals(fieldNames[findex]))
                            {
                                if (batch.BankType == AgentTransferBankType.Boc)
                                    ae.Province = DataConvertHelper.Instance.GetProvince(data[dindex].ToString());
                                else if (batch.BankType == AgentTransferBankType.Other)
                                    ae.BankNo = data[dindex].ToString();
                            }
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyCardType.Equals(fieldNames[findex]))
                                ae.CertifyPaperType = DataConvertHelper.Instance.GetAgentExpressCertifyPaperType(data[dindex].ToString());
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo.Equals(fieldNames[findex]))
                                ae.CertifyPaperNo = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Usage.Equals(fieldNames[findex]))
                                ae.UsageType = DataConvertHelper.Instance.GetAgentExpressFunctionType(data[dindex].ToString());
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankName.Equals(fieldNames[findex]))
                                ae.BankName = data[dindex].ToString();
                            #endregion
                        }
                        else if (aft == AppliableFunctionType.AgentExpressIn)
                        {
                            #region
                            if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Amount.Equals(fieldNames[findex]))
                            { if (!string.IsNullOrEmpty(data[dindex]))ae.Amount = DataConvertHelper.Instance.FormatNum(data[dindex]); }
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerName.Equals(fieldNames[findex]))
                                ae.AccountName = data[dindex];
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerAccount.Equals(fieldNames[findex]))
                                ae.AccountNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerOpenBankNoOrCNAPSNo.Equals(fieldNames[findex]))
                            {
                                if (batch.BankType == AgentTransferBankType.Boc)
                                {
                                    ae.Province = DataConvertHelper.Instance.GetProvince(data[dindex].ToString());
                                    ResultData rd = DataCheckCenter.Instance.CheckProvince(null, data[dindex], null);
                                    if (!rd.Result) throw new Exception(rd.Message);
                                }
                                else if (batch.BankType == AgentTransferBankType.Other)
                                {
                                    ae.BankNo = data[dindex].ToString();
                                    ResultData rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data[dindex], null);
                                    if (!rd.Result) throw new Exception(rd.Message);
                                }
                            }
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyCardType.Equals(fieldNames[findex]))
                                ae.CertifyPaperType = DataConvertHelper.Instance.GetAgentExpressCertifyPaperType(data[dindex].ToString());
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyNo.Equals(fieldNames[findex]))
                                ae.CertifyPaperNo = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_SerialNo.Equals(fieldNames[findex]))
                                ae.ProtecolNo = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Usage.Equals(fieldNames[findex]))
                                ae.UsageType = DataConvertHelper.Instance.GetAgentExpressFunctionType(data[dindex].ToString());
                            #endregion
                        }
                        findex++;
                        dindex++;
                    }
                    if (aft == AppliableFunctionType.AgentExpressOut4Bar)
                    {
                        if (!string.IsNullOrEmpty(ae.BankName))
                        {
                            AgentTransferBankType banktype = DataConvertHelper.Instance.GetAgentTransferBankType(ae.BankName);
                            if (batch.BankType != banktype) continue;
                            if (banktype == AgentTransferBankType.Boc)
                            {
                                if (ae.Province == ChinaProvinceType.B0)
                                {
                                    ae.Province = DataConvertHelper.Instance.GetProvinceFOpenBankName(ae.BankName);
                                }
                            }
                        }
                        else if (batch.BankType == AgentTransferBankType.Boc) continue;
                    }
                }
                catch { }
                aelist.Add(ae);
            }
            list.Add(batch);
            list.Add(aelist);

            return list;
        }

        private List<object> MatchAgentNormals(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<object> list = new List<object>();
            List<AgentNormal> anlist = new List<AgentNormal>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            BatchHeader batch = new BatchHeader();
            AgentNormal an = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                an = new AgentNormal();
                foreach (string fieldname in flist)
                {
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (AppliableFunctionType.AgentNormalOut == aft)
                    {
                        //case "客户业务编号": batch.ProtecolNo = data[dindex].ToString(); break;
                        //case "付款行联行号": break;
                        //case "付款人账号": batch.Payer.Account = data[dindex].ToString(); break;
                        //case "货币名称": break;
                        //case "代发卡类型": batch.CardType = (AgentCardType)int.Parse(data[dindex].ToString()); break;
                        //case "用途类型": batch.UseType = data[dindex].ToString(); break;
                        //case "手续费账号": batch.PayFeeNo = data[dindex].ToString(); break;
                        //case "付款日期": batch.TransferDatetime = DateTime.Parse(data[dindex].ToString()); break;
                        //case "附言": batch.Addtion = data[dindex].ToString(); break;

                        if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Amount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))an.Amount = DataConvertHelper.Instance.FormatNum(data[dindex]); }
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeName.Equals(fieldNames[findex]))
                            an.AccountName = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeAccount.Equals(fieldNames[findex]))
                            an.AccountNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_BankLinkNoOrCNAPSNo.Equals(fieldNames[findex]))
                            an.BankNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeBankName.Equals(fieldNames[findex]))
                            an.BankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeCertifyCardType.Equals(fieldNames[findex]))
                            an.CertifyPaperType = DataConvertHelper.Instance.GetAgentNormalCertifyPaperType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeCertifyNo.Equals(fieldNames[findex]))
                            an.CertifyPaperNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Usege.Equals(fieldNames[findex]))
                        {
                            try
                            {
                                an.UseType = (AgentNormalFunctionType)int.Parse(data[dindex]);
                                if (string.IsNullOrEmpty(an.UseTypeString))
                                    an.UseType = AgentNormalFunctionType.Empty;
                            }
                            catch { an.UseType = AgentNormalFunctionType.Empty; } break;
                        }
                    }
                    else if (AppliableFunctionType.AgentNormalIn == aft)
                    {
                        //case "客户业务编号": if (string.IsNullOrEmpty(batch.ProtecolNo)) batch.ProtecolNo = data[dindex].ToString(); break;
                        //case "收款行联行号": break;
                        //case "收款人账号": if (string.IsNullOrEmpty(batch.ProtecolNo)) batch.Payer.Account = data[dindex].ToString(); break;
                        //case "货币名称": break;
                        //case "代发卡类型": if (string.IsNullOrEmpty(batch.CardType_Normal)) batch.CardType = (AgentCardType)int.Parse(data[dindex].ToString()); break;
                        //case "用途类型": if (string.IsNullOrEmpty(batch.UseType)) batch.UseType = data[dindex].ToString(); break;
                        //case "手续费账号": if (string.IsNullOrEmpty(batch.PayFeeNo)) batch.PayFeeNo = data[dindex].ToString(); break;
                        //case "收款日期": if (null == batch.TransferDatetime) batch.TransferDatetime = DateTime.Parse(data[dindex].ToString()); break;
                        //case "附言": if (string.IsNullOrEmpty(batch.Addtion)) batch.Addtion = data[dindex].ToString(); break;


                        if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Amount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))    an.Amount = DataConvertHelper.Instance.FormatNum(data[dindex]); }
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerName.Equals(fieldNames[findex]))
                            an.AccountName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerAccount.Equals(fieldNames[findex]))
                            an.AccountNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_BankLinkNoOrCNAPSNo.Equals(fieldNames[findex]))
                            an.BankNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerBankName.Equals(fieldNames[findex]))
                            an.BankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyCardType.Equals(fieldNames[findex]))
                            an.CertifyPaperType = DataConvertHelper.Instance.GetAgentNormalCertifyPaperType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyNo.Equals(fieldNames[findex]))
                            an.CertifyPaperNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Usege.Equals(fieldNames[findex]))
                            an.UseType_In = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_SerialNo.Equals(fieldNames[findex]))
                            an.ProtecolNo = data[dindex].ToString();
                    }
                    findex++;
                    dindex++;
                }
                anlist.Add(an);
            }
            list.Add(batch);
            list.Add(anlist);

            return list;
        }

        private List<object> MatchAgentNormals(AppliableFunctionType aft, List<List<string>> fields, BatchHeader batch)
        {
            List<object> list = new List<object>();
            List<AgentNormal> anlist = new List<AgentNormal>();

            Dictionary<string, string> dicbatch = SystemSettings.Instance.BatchMappingSettings[aft].BatchFieldsMappings;
            Dictionary<string, string> dicsingal = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dicbatch.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            flist = new List<string>();
            flist.AddRange(dicsingal.Keys);
            AgentNormal an = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                an = new AgentNormal();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dicsingal[fieldname].ToString())) { findex++; continue; }
                    if (AppliableFunctionType.AgentNormalOut == aft)
                    {
                        if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Amount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))  an.Amount = DataConvertHelper.Instance.FormatNum(data[dindex]); }
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeName.Equals(fieldNames[findex]))
                            an.AccountName = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeAccount.Equals(fieldNames[findex]))
                            an.AccountNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_BankLinkNoOrCNAPSNo.Equals(fieldNames[findex]))
                            an.BankNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeBankName.Equals(fieldNames[findex]))
                            an.BankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeCertifyCardType.Equals(fieldNames[findex]))
                            an.CertifyPaperType = DataConvertHelper.Instance.GetAgentNormalCertifyPaperType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeCertifyNo.Equals(fieldNames[findex]))
                            an.CertifyPaperNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Usege.Equals(fieldNames[findex]))
                        {
                            try
                            {
                                an.UseType = (AgentNormalFunctionType)int.Parse(data[dindex]);
                                if (string.IsNullOrEmpty(an.UseTypeString))
                                    an.UseType = AgentNormalFunctionType.Empty;
                            }
                            catch { an.UseType = AgentNormalFunctionType.Empty; } break;
                        }
                    }
                    else
                    {
                        if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Amount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))an.Amount = DataConvertHelper.Instance.FormatNum(data[dindex]); }
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerName.Equals(fieldNames[findex]))
                            an.AccountName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerAccount.Equals(fieldNames[findex]))
                            an.AccountNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_BankLinkNoOrCNAPSNo.Equals(fieldNames[findex]))
                            an.BankNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerBankName.Equals(fieldNames[findex]))
                            an.BankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyCardType.Equals(fieldNames[findex]))
                            an.CertifyPaperType = DataConvertHelper.Instance.GetAgentNormalCertifyPaperType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyNo.Equals(fieldNames[findex]))
                            an.CertifyPaperNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Usege.Equals(fieldNames[findex]))
                            an.UseType_In = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_SerialNo.Equals(fieldNames[findex]))
                            an.ProtecolNo = data[dindex].ToString();
                    }
                    findex++;
                    dindex++;
                }
                anlist.Add(an);
            }
            list.Add(batch);
            list.Add(anlist);

            return list;
        }

        private List<TransferAccount> MatchOverBankTransfers(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<TransferAccount> list = new List<TransferAccount>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            TransferAccount ta = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                ta = new TransferAccount();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.TransferOverBankIn)
                    {
                        if (MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_Amount.Equals(fieldNames[findex]))
                        {
                            if (!string.IsNullOrEmpty(data[dindex])) ta.PayAmount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        }
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayProtecolNo.Equals(fieldNames[findex]))
                            ta.PayProtecolNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_BusinessType.Equals(fieldNames[findex]))
                            ta.BusinessType = DataConvertHelper.Instance.GetBusinessType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerName.Equals(fieldNames[findex]))
                            ta.PayeeName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerAccount.Equals(fieldNames[findex]))
                            ta.PayeeAccount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerBankName.Equals(fieldNames[findex]))
                            ta.PayeeOpenBank = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayeeAccount.Equals(fieldNames[findex]))
                            ta.PayerAccount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_CutomerRef.Equals(fieldNames[findex]))
                            ta.CustomerRef = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_Addtion.Equals(fieldNames[findex]))
                            ta.Addition = data[dindex].ToString();
                    }
                    else if (aft == AppliableFunctionType.TransferOverBankOut)
                    {
                        if (MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_Amount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex])) ta.PayAmount = DataConvertHelper.Instance.FormatNum(data[dindex]); }
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeName.Equals(fieldNames[findex]))
                            ta.PayeeName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeAccount.Equals(fieldNames[findex]))
                            ta.PayeeAccount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeBankName.Equals(fieldNames[findex]))
                            ta.PayeeOpenBank = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeClearBankNo.Equals(fieldNames[findex]))
                            ta.PayBankNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayerAccount.Equals(fieldNames[findex]))
                            ta.PayerAccount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_CutomerRef.Equals(fieldNames[findex]))
                            ta.CustomerRef = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayFeeAccount.Equals(fieldNames[findex]))
                            ta.PayFeeNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_Addtion.Equals(fieldNames[findex]))
                            ta.Addition = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_Email.Equals(fieldNames[findex]))
                            ta.Email = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_OperateOrder.Equals(fieldNames[findex]))
                            ta.TChanel = DataConvertHelper.Instance.GetTransferChanelType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayDate.Equals(fieldNames[findex]))
                            ta.PayDatetime = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex].ToString());
                    }
                    findex++;
                    dindex++;
                }
                list.Add(ta);
            }

            return list;
        }

        private List<ElecTicketRemit> MatchElecTicketRemits(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<ElecTicketRemit> list = new List<ElecTicketRemit>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            ElecTicketRemit etr = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                etr = new ElecTicketRemit();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.ElecTicketRemit)
                    {
                        if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_Amount.Equals(fieldNames[findex]))
                        {
                            if (!string.IsNullOrEmpty(data[dindex]))
                                etr.Amount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        }
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_CanAutoTipExchange.Equals(fieldNames[findex]))
                            etr.AutoTipExchange = DataConvertHelper.Instance.GetAutoTipExchange(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_CanAutoReceiveTicket.Equals(fieldNames[findex]))
                            etr.AutoTipReceiveTicket = DataConvertHelper.Instance.GetAutoReceiveTicket(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_CanChange.Equals(fieldNames[findex]))
                            etr.CanChange = DataConvertHelper.Instance.GetCanChangeType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_EndDate.Equals(fieldNames[findex]))
                            etr.EndDate = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeAccount.Equals(fieldNames[findex]))
                            etr.ExchangeAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeName.Equals(fieldNames[findex]))
                            etr.ExchangeName = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeOpenBankName.Equals(fieldNames[findex]))
                            etr.ExchangeOpenBankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeOpenBankNo.Equals(fieldNames[findex]))
                            etr.ExchangeOpenBankNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_Note.Equals(fieldNames[findex]))
                            etr.Note = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeAccount.Equals(fieldNames[findex]))
                            etr.PayeeAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeName.Equals(fieldNames[findex]))
                            etr.PayeeName = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeOpenBankName.Equals(fieldNames[findex]))
                            etr.PayeeOpenBankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeOpenBankNo.Equals(fieldNames[findex]))
                            etr.PayeeOpenBankNo = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_RemitAccount.Equals(fieldNames[findex]))
                            etr.RemitAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_RemitDate.Equals(fieldNames[findex]))
                            etr.RemitDate = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_TicketType.Equals(fieldNames[findex]))
                            etr.TicketType = DataConvertHelper.Instance.GetElecTicketType(data[dindex].ToString(), aft);
                        findex++;
                        dindex++;
                    }
                }
                list.Add(etr);
            }

            return list;
        }

        private List<ElecTicketBackNote> MatchElecTicketBackNotes(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<ElecTicketBackNote> list = new List<ElecTicketBackNote>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            ElecTicketBackNote etr = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                etr = new ElecTicketBackNote();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.ElecTicketBackNote)
                    {
                        if (MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedAccount.Equals(fieldNames[findex]))
                            etr.BackNotedAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedName.Equals(fieldNames[findex]))
                            etr.BackNotedName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedOpenBankName.Equals(fieldNames[findex]))
                            etr.BackNotedOpenBankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedOpenBankNo.Equals(fieldNames[findex]))
                            etr.BackNotedOpenBankNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_TicketSerialNo.Equals(fieldNames[findex]))
                            etr.ElecTicketSerialNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Note.Equals(fieldNames[findex]))
                            etr.Note = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Account.Equals(fieldNames[findex]))
                            etr.RemitAccount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        findex++;
                        dindex++;
                    }
                }
                list.Add(etr);
            }

            return list;
        }

        private List<ElecTicketAutoTipExchange> MatchElecTicketAutoTipExchanges(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<ElecTicketAutoTipExchange> list = new List<ElecTicketAutoTipExchange>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            ElecTicketAutoTipExchange etr = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                etr = new ElecTicketAutoTipExchange();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.ElecTicketTipExchange)
                    {
                        if (MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_BillSerialNo.Equals(fieldNames[findex]))
                            etr.BillSerialNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ContactNo.Equals(fieldNames[findex]))
                            etr.ContractNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_TicketSerialNo.Equals(fieldNames[findex]))
                            etr.ElecTicketSerialNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeAccount.Equals(fieldNames[findex]))
                            etr.ExchangeAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeName.Equals(fieldNames[findex]))
                            etr.ExchangeName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankName.Equals(fieldNames[findex]))
                            etr.ExchangeOpenBankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankNo.Equals(fieldNames[findex]))
                            etr.ExchangeOpenBankNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Note.Equals(fieldNames[findex]))
                            etr.Note = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Account.Equals(fieldNames[findex]))
                            etr.RemitAccount = data[dindex].ToString();
                        findex++;
                        dindex++;
                    }
                }
                list.Add(etr);
            }

            return list;
        }

        private List<ElecTicketPayMoney> MatchElecTicketPayMoneys(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<ElecTicketPayMoney> list = new List<ElecTicketPayMoney>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            ElecTicketPayMoney etr = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                etr = new ElecTicketPayMoney() { PayMoneyType = MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Buyout };
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.ElecTicketPayMoney)
                    {
                        if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_BillSerialNo.Equals(fieldNames[findex]))
                            etr.BillSerialNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ClearType.Equals(fieldNames[findex]))
                            etr.ClearType = DataConvertHelper.Instance.GetClearType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ContactNo.Equals(fieldNames[findex]))
                            etr.ContractNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_TicketSerialNo.Equals(fieldNames[findex]))
                            etr.ElecTicketSerialNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_IsContainMoney.Equals(fieldNames[findex]))
                            etr.ProtocolMoneyType = DataConvertHelper.Instance.GetProtocolMoneyType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Note.Equals(fieldNames[findex]))
                            etr.Note = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyAccount.Equals(fieldNames[findex]))
                            etr.PayMoneyAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayDate.Equals(fieldNames[findex]))
                            etr.PayMoneyDate = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankName.Equals(fieldNames[findex]))
                            etr.PayMoneyOpenBankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankNo.Equals(fieldNames[findex]))
                            etr.PayMoneyOpenBankNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyPercent.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))   etr.PayMoneyPercent = double.Parse(DataConvertHelper.Instance.FormatPayMoneyPercent(data[dindex].ToString(), false)); }
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyType.Equals(fieldNames[findex]))
                            etr.PayMoneyType = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ProtocolMoneyPercent.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))etr.ProtocolMoneyPercent = double.Parse(DataConvertHelper.Instance.FormatPayMoneyPercent(data[dindex].ToString(), false)); }
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Account.Equals(fieldNames[findex]))
                            etr.RemitAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnccount.Equals(fieldNames[findex]))
                            etr.StickOnAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnName.Equals(fieldNames[findex]))
                            etr.StickOnName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankName.Equals(fieldNames[findex]))
                            etr.StickOnOpenBankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankNo.Equals(fieldNames[findex]))
                            etr.StickOnOpenBankNo = data[dindex].ToString();
                        findex++;
                        dindex++;
                    }
                }
                list.Add(etr);
            }

            return list;
        }

        private List<ElecTicketPool> MatchElecTicketPools(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<ElecTicketPool> list = new List<ElecTicketPool>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            ElecTicketPool etp = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                etp = new ElecTicketPool();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.ElecTicketPool)
                    {
                        if (MultiLanguageConvertHelper.Instance.ElecTicketPool_Amount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex])) etp.Amount = DataConvertHelper.Instance.FormatNum(data[dindex].ToString()); }
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBank.Equals(fieldNames[findex]))
                            etp.BankType = DataConvertHelper.Instance.GetAccountBankTypeObject(data[dindex].ToString(), aft);
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_BusinessType.Equals(fieldNames[findex]))
                            etp.BusinessType = DataConvertHelper.Instance.GetElecTicketPoolBusinessType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_CustomerRef.Equals(fieldNames[findex]))
                            etp.CustomerRef = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_ElecTicketSerialNo.Equals(fieldNames[findex]))
                            etp.ElecTicketSerialNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_ElecTicketType.Equals(fieldNames[findex]))
                            etp.ElecTicketType = DataConvertHelper.Instance.GetElecTicketType(data[dindex].ToString(), aft);
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDate.Equals(fieldNames[findex]))
                            etp.EndDate = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDateOperate.Equals(fieldNames[findex]))
                            etp.EndDateOperate = DataConvertHelper.Instance.GetEndDateOperateType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeAccount.Equals(fieldNames[findex]))
                            etp.ExchangeAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeOpenBankName.Equals(fieldNames[findex]))
                            etp.ExchangeBankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankNo.Equals(fieldNames[findex])
                            || MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeOpenBankNo.Equals(fieldNames[findex]))
                            etp.ExchangeBankNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeDate.Equals(fieldNames[findex]))
                            etp.ExchangeDate = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeName.Equals(fieldNames[findex])
                            || MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankName.Equals(fieldNames[findex]))
                            etp.ExchangeName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeAccount.Equals(fieldNames[findex]))
                            etp.PayeeAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeName.Equals(fieldNames[findex]))
                            etp.PayeeName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankName.Equals(fieldNames[findex]))
                            etp.PayeeOpenBankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankNo.Equals(fieldNames[findex]))
                            etp.PayeeOpenBankNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_PreBackNotedPerson.Equals(fieldNames[findex]))
                            etp.PreBackNotedPerson = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitAccount.Equals(fieldNames[findex]))
                            etp.RemitAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitDate.Equals(fieldNames[findex]))
                            etp.RemitDate = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitName.Equals(fieldNames[findex]))
                            etp.RemitName = data[dindex].ToString();
                        findex++;
                        dindex++;
                    }
                }
                list.Add(etp);
            }

            return list;
        }

        private List<TransferGlobal> MatchTransferGlobals(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<TransferGlobal> list = new List<TransferGlobal>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            TransferGlobal etp = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                etp = new TransferGlobal();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.TransferOverCountry
                        || aft == AppliableFunctionType.TransferForeignMoney
                        || aft == AppliableFunctionType.TransferOverCountry4Bar
                        || aft == AppliableFunctionType.TransferForeignMoney4Bar)
                    {
                        if (MultiLanguageConvertHelper.Instance.TransferGlobal_PayDate.Equals(fieldNames[findex]))
                            etp.PayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentType.Equals(fieldNames[findex]))
                            etp.PaymentType = "电汇";
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_SendPriority.Equals(fieldNames[findex]))
                            etp.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentCashType.Equals(fieldNames[findex]))
                            etp.PaymentCashType = DataConvertHelper.Instance.GetCashType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAmount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))  etp.RemitAmount = DataConvertHelper.Instance.FormatCash(data[dindex].ToString(), etp.PaymentCashType == CashType.JPY); }
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount.Equals(fieldNames[findex]))
                            etp.SpotAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex])) etp.SpotAmount = DataConvertHelper.Instance.FormatCash(data[dindex].ToString(), etp.PaymentCashType == CashType.JPY); }
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount.Equals(fieldNames[findex]))
                            etp.PurchaseAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))  etp.PurchaseAmount = DataConvertHelper.Instance.FormatCash(data[dindex].ToString(), etp.PaymentCashType == CashType.JPY); }
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAccount.Equals(fieldNames[findex]))
                            etp.OtherAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAmount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))  etp.OtherAmount = DataConvertHelper.Instance.FormatCash(data[dindex].ToString(), etp.PaymentCashType == CashType.JPY); }
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeAccount.Equals(fieldNames[findex]))
                            etp.PayFeeAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode.Equals(fieldNames[findex]))
                            etp.OrgCode = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName.Equals(fieldNames[findex]))
                            etp.RemitName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress.Equals(fieldNames[findex]))
                            etp.RemitAddress = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_CutomerRef.Equals(fieldNames[findex]))
                            etp.CustomerRef = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount.Equals(fieldNames[findex]))
                            etp.PayeeAccount = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName.Equals(fieldNames[findex]))
                            etp.PayeeName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress.Equals(fieldNames[findex]))
                            etp.PayeeAddress = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCodeofCountry.Equals(fieldNames[findex]))
                            etp.PayeeCodeofCountry = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeNameofCountry.Equals(fieldNames[findex]))
                            etp.PayeeNameofCountry = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankType.Equals(fieldNames[findex]))
                        {
                            if (aft == AppliableFunctionType.TransferForeignMoney || aft == AppliableFunctionType.TransferForeignMoney4Bar)
                            {
                                etp.PayeeOpenBankType = DataConvertHelper.Instance.GetAccountBankTypeObject(data[dindex].ToString(), aft);
                                if (etp.PayeeOpenBankType == AccountBankType.Empty) etp.PayeeOpenBankType = AccountBankType.OtherBankAccount;
                                if (aft == AppliableFunctionType.TransferForeignMoney4Bar) etp.PayeeOpenBankName = data[dindex];
                            }
                            else if (aft == AppliableFunctionType.TransferOverCountry || aft == AppliableFunctionType.TransferOverCountry4Bar)
                                etp.PayeeOpenBankName = data[dindex].ToString();
                        }
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress.Equals(fieldNames[findex]))
                            etp.PayeeOpenBankAddress = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName.Equals(fieldNames[findex]))
                            etp.CorrespondentBankName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress.Equals(fieldNames[findex]))
                            etp.CorrespondentBankAddress = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank.Equals(fieldNames[findex]))
                            etp.PayeeAccountInCorrespondentBank = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote.Equals(fieldNames[findex]))
                            etp.RemitNote = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_AssumeFeeType.Equals(fieldNames[findex]))
                            etp.AssumeFeeType = DataConvertHelper.Instance.GetAssumeFeeType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeType.Equals(fieldNames[findex]))
                            etp.PayFeeType = DataConvertHelper.Instance.GetPayFeeType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF.Equals(fieldNames[findex]))
                            etp.DealSerialNoF = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))    etp.AmountF = DataConvertHelper.Instance.FormatCash(data[dindex].ToString(), etp.PaymentCashType == CashType.JPY); }
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteF.Equals(fieldNames[findex]))
                            etp.DealNoteF = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS.Equals(fieldNames[findex]))
                            etp.DealSerialNoS = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))etp.AmountS = DataConvertHelper.Instance.FormatCash(data[dindex].ToString(), etp.PaymentCashType == CashType.JPY); }
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteS.Equals(fieldNames[findex]))
                            etp.DealNoteS = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_IsPayOffLine.Equals(fieldNames[findex]))
                            etp.IsPayOffLine = DataConvertHelper.Instance.GetIsPayOffLine(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo.Equals(fieldNames[findex]))
                            etp.ContactNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo.Equals(fieldNames[findex]))
                            etp.BillSerialNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo.Equals(fieldNames[findex]))
                            etp.BatchNoOrTNoOrSerialNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName.Equals(fieldNames[findex]))
                            etp.ProposerName = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone.Equals(fieldNames[findex]))
                            etp.Telephone = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentPropertyType.Equals(fieldNames[findex]))
                            etp.PaymentPropertyType = aft == AppliableFunctionType.TransferForeignMoney4Bar
                                ? DataConvertHelper.Instance.GetPaymentPropertyTypeBar(data[dindex])
                                : DataConvertHelper.Instance.GetPaymentPropertyType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankSwiftCode.Equals(fieldNames[findex]))
                            etp.PayeeOpenBankSwiftCode = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankSwiftCode.Equals(fieldNames[findex]))
                            etp.CorrespondentBankSwiftCode = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccountProvince.Equals(fieldNames[findex]))
                            etp.Province = DataConvertHelper.Instance.GetProvince(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyCardType.Equals(fieldNames[findex]))
                            etp.CertifyPaperType = DataConvertHelper.Instance.GetAgentExpressCertifyPaperType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo.Equals(fieldNames[findex]))
                            etp.CertifyPaperNo = data[dindex].ToString();
                        else if (MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Business.Equals(fieldNames[findex]))
                            etp.AgentFunctionType_Express = DataConvertHelper.Instance.GetAgentExpressFunctionType(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_BarApplyFlagType.Equals(fieldNames[findex]))
                            etp.BarApplyFlagType = DataConvertHelper.Instance.GetBarApplyFlagType(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.TransferGlobal_BarBusinessType.Equals(fieldNames[findex]))
                            etp.BarBusinessType = DataConvertHelper.Instance.GetBarBusinessType(data[dindex]);
                        findex++;
                        dindex++;
                    }
                }
                if (aft == AppliableFunctionType.TransferForeignMoney4Bar
                    || aft == AppliableFunctionType.TransferOverCountry4Bar)
                {
                    etp.PayFeeAccount = etp.SpotAccount;
                    if (!string.IsNullOrEmpty(etp.PurchaseAccount))
                        etp.PayFeeAccount = etp.PurchaseAccount;
                }
                list.Add(etp);
            }

            return list;
        }

        private List<SpplyFinancingApply> MatchSpplyFinancingApplys(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<SpplyFinancingApply> list = new List<SpplyFinancingApply>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            SpplyFinancingApply sfa = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                sfa = new SpplyFinancingApply();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.ApplyofFranchiserFinancing)
                    {
                        if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_AgrementNo.Equals(fieldNames[findex]))
                            sfa.AgreementNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ApplyAmount.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex])) sfa.ApplyAmount = DataConvertHelper.Instance.FormatNum(data[dindex]); }
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ApplyDays.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex]))    sfa.ApplyDays = int.Parse(DataConvertHelper.Instance.FormatNum(data[dindex])); }
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_CashType.EndsWith(fieldNames[findex]))
                            sfa.ContractOrOrderCashType = DataConvertHelper.Instance.GetCashType(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ContractOrOrderNo.EndsWith(fieldNames[findex]))
                            sfa.ContractOrOrderNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_DeliveryDate.Equals(fieldNames[findex]))
                            sfa.DeliveryDate = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_GoodsDesc.Equals(fieldNames[findex]))
                            sfa.GoodsDesc = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_InterestFloatingPercent.Equals(fieldNames[findex]))
                            sfa.InterestFloatingPercent = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_InterestFloatType.Equals(fieldNames[findex]))
                            sfa.InterestFloatType = DataConvertHelper.Instance.GetInterestFloatType(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_OrderAmount.Equals(fieldNames[findex]))
                            sfa.ContractOrOrderAmount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_OrderDate.Equals(fieldNames[findex]))
                            sfa.OrderDate = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ReceiptNo.Equals(fieldNames[findex]))
                            sfa.ReceiptNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_RiskTakingLetterNo.Equals(fieldNames[findex]))
                            sfa.RiskTakingLetterNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_SettlementType.Equals(fieldNames[findex]))
                            sfa.SettlementType = DataConvertHelper.Instance.GetSettlementType(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingApply_TaxInvoiceNo.Equals(fieldNames[findex]))
                            sfa.TaxInvoiceNo = data[dindex];
                        findex++;
                        dindex++;
                    }
                }
                list.Add(sfa);
            }

            return list;
        }

        private List<SpplyFinancingOrder> MatchSpplyFinancingOrders(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<SpplyFinancingOrder> list = new List<SpplyFinancingOrder>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            SpplyFinancingOrder sfo = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                sfo = new SpplyFinancingOrder();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.PurchaserOrder
                        || aft == AppliableFunctionType.SellerOrder
                        || aft == AppliableFunctionType.PurchaserOrderMgr
                        || aft == AppliableFunctionType.SellerOrderMgr)
                    {
                        if (MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo.Equals(fieldNames[findex]))
                            sfo.OrderNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_Amount.Equals(fieldNames[findex])
                            || MultiLanguageConvertHelper.Instance.SpplyFinancingOrderMgr_PayAmountForThisTime.Equals(fieldNames[findex]))
                        { if (!string.IsNullOrEmpty(data[dindex])) sfo.Amount = DataConvertHelper.Instance.FormatNum(data[dindex]); }
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CashType.Equals(fieldNames[findex]))
                            sfo.CashType = DataConvertHelper.Instance.GetCashType(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerNo_Seller.Equals(fieldNames[findex]))
                            sfo.CustomerApplyNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_ERPCode_Seller.Equals(fieldNames[findex]))
                            sfo.ERPCode = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_PayDate_Seller.Equals(fieldNames[findex])
                            || MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_PayDate_Purchase.Equals(fieldNames[findex]))
                            sfo.PayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerName_Purchase.Equals(fieldNames[findex]))
                            sfo.CustomerName = data[dindex];
                    }
                    findex++;
                    dindex++;
                }
                list.Add(sfo);
            }

            return list;
        }

        private List<SpplyFinancingBill> MatchSpplyFinancingBills(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<SpplyFinancingBill> list = new List<SpplyFinancingBill>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            SpplyFinancingBill sfb = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                sfb = new SpplyFinancingBill();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.BillofDebtReceivablePurchaser || aft == AppliableFunctionType.BillofDebtReceivableSeller)
                    {
                        if (MultiLanguageConvertHelper.Instance.SpplyFinancingBill_Amount.Equals(fieldNames[findex]))
                        {
                            if (!string.IsNullOrEmpty(data[dindex]))
                                sfb.Amount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        }
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillDate.Equals(fieldNames[findex]))
                            sfb.BillDate = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillSerialNo.Equals(fieldNames[findex]))
                            sfb.BillSerialNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CashType.Equals(fieldNames[findex]))
                            sfb.CashType = DataConvertHelper.Instance.GetCashType(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingBill_ContractNo.Equals(fieldNames[findex]))
                            sfb.ContractNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Purchase.Equals(fieldNames[findex])
                            || MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Seller.Equals(fieldNames[findex]))
                            sfb.CustomerName = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Purchase.Equals(fieldNames[findex])
                            || MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Seller.Equals(fieldNames[findex]))
                            sfb.CustomerNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingBill_EndDate.Equals(fieldNames[findex]))
                            sfb.EndDate = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingBill_StartDate.Equals(fieldNames[findex]))
                            sfb.StartDate = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex]);
                        findex++;
                        dindex++;
                    }
                }
                list.Add(sfb);
            }

            return list;
        }

        private List<SpplyFinancingPayOrReceipt> MatchSpplyFinancingPayOrReceipts(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<SpplyFinancingPayOrReceipt> list = new List<SpplyFinancingPayOrReceipt>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            SpplyFinancingPayOrReceipt sfpr = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                sfpr = new SpplyFinancingPayOrReceipt();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser)
                    {
                        if (MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_AmountThisTime.Equals(fieldNames[findex]))
                        {
                            if (!string.IsNullOrEmpty(data[dindex]))
                                sfpr.PayAmountForThisTime = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        }
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_BillSerialNo.Equals(fieldNames[findex]))
                            sfpr.BillSerialNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CashType.Equals(fieldNames[findex]))
                            sfpr.CashType = DataConvertHelper.Instance.GetCashType(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerName.Equals(fieldNames[findex]))
                            sfpr.CustomerName = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerNo.Equals(fieldNames[findex]))
                            sfpr.CustomerNo = data[dindex];
                        findex++;
                        dindex++;
                    }
                }
                list.Add(sfpr);
            }

            return list;
        }

        private List<UnitivePaymentRMB> MatchUnitivePaymentRMB(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<UnitivePaymentRMB> list = new List<UnitivePaymentRMB>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            UnitivePaymentRMB sfpr = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                sfpr = new UnitivePaymentRMB();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser)
                    {
                        if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_Amount.Equals(fieldNames[findex]))
                        {
                            if (!string.IsNullOrEmpty(data[dindex]))
                                sfpr.Amount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        }
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_BankType.Equals(fieldNames[findex]))
                            sfpr.BankType = DataConvertHelper.Instance.GetAccountBankTypeObject(data[dindex], aft);
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_CustomerBusinissNo.Equals(fieldNames[findex]))
                            sfpr.CustomerBusinissNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_IsTipPayee.Equals(fieldNames[findex]))
                            sfpr.IsTipPayee = DataConvertHelper.Instance.GetIsTipPayee(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_NominalPayerAccount.Equals(fieldNames[findex]))
                            sfpr.NominalPayerAccount = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_NominalPayerName.Equals(fieldNames[findex]))
                            sfpr.NominalPayerName = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_OrderPayDate.Equals(fieldNames[findex]))
                            sfpr.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeAccount.Equals(fieldNames[findex]))
                            sfpr.PayeeAccount = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeCNAPS.Equals(fieldNames[findex]))
                            sfpr.PayeeCNAPS = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeName.Equals(fieldNames[findex]))
                            sfpr.PayeeName = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeOpenBankName.Equals(fieldNames[findex]))
                            sfpr.PayeeOpenBankName = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayerAccount.Equals(fieldNames[findex]))
                            sfpr.PayerAccount = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayerName.Equals(fieldNames[findex]))
                            sfpr.PayerName = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_Purpose.Equals(fieldNames[findex]))
                            sfpr.Purpose = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_TipPayeePhone.Equals(fieldNames[findex]))
                            sfpr.TipPayeePhone = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_TransferChanelType.Equals(fieldNames[findex]))
                            sfpr.TransferChanelType = DataConvertHelper.Instance.GetTransferChanelType(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_UnitivePaymentType.Equals(fieldNames[findex]))
                            sfpr.UnitivePaymentType = DataConvertHelper.Instance.GetUnitivePaymentType(data[dindex]);
                        findex++;
                        dindex++;
                    }
                }
                list.Add(sfpr);
            }

            return list;
        }

        private List<object> MatchInitiativeAllots(AppliableFunctionType aft, List<List<string>> fields, BatchHeader batch)
        {
            List<object> list = new List<object>();
            List<InitiativeAllot> anlist = new List<InitiativeAllot>();

            Dictionary<string, string> dicbatch = SystemSettings.Instance.BatchMappingSettings[aft].BatchFieldsMappings;
            Dictionary<string, string> dicsingal = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dicbatch.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            flist = new List<string>();
            flist.AddRange(dicsingal.Keys);
            InitiativeAllot an = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                an = new InitiativeAllot();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dicsingal[fieldname].ToString())) { findex++; continue; }
                    if (AppliableFunctionType.InitiativeAllot == aft)
                    {
                        if (MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountIn.Equals(fieldNames[findex]))
                            an.AccountIn = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountOut.Equals(fieldNames[findex]))
                            an.AccountOut = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.InitiativeAllot_Addition.Equals(fieldNames[findex]))
                            an.Addition = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.InitiativeAllot_Amount.Equals(fieldNames[findex]))
                            an.Amount = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.InitiativeAllot_CashType.Equals(fieldNames[findex]))
                            an.CashType = DataConvertHelper.Instance.GetCashType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.InitiativeAllot_NameIn.Equals(fieldNames[findex]))
                            an.NameIn = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.InitiativeAllot_NameOut.Equals(fieldNames[findex]))
                            an.NameOut = data[dindex];
                    }
                    findex++;
                    dindex++;
                }
                anlist.Add(an);
            }
            list.Add(batch);
            list.Add(anlist);

            return list;
        }

        private List<VirtualAccount> MatchVirtualAccount(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<VirtualAccount> list = new List<VirtualAccount>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            VirtualAccount sfpr = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                sfpr = new VirtualAccount();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (aft == AppliableFunctionType.VirtualAccountTransfer)
                    {
                        if (MultiLanguageConvertHelper.Instance.Virtual_AccountOut.Equals(fieldNames[findex]))
                            sfpr.AccountOut = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Virtual_NameOut.Equals(fieldNames[findex]))
                            sfpr.NameOut = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Virtual_AccountIn.Equals(fieldNames[findex]))
                            sfpr.AccountIn = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Virtual_NameIn.Equals(fieldNames[findex]))
                            sfpr.NameIn = DataConvertHelper.Instance.FormatNum(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.Virtual_CashType.Equals(fieldNames[findex]))
                            sfpr.CashType = DataConvertHelper.Instance.GetCashType(data[dindex].ToString());
                        else if (MultiLanguageConvertHelper.Instance.Virtual_Amount.Equals(fieldNames[findex]))
                            sfpr.Amount = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Virtual_Pursion.Equals(fieldNames[findex]))
                            sfpr.Purpose = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Virtual_CustomerBusinissNo.Equals(fieldNames[findex]))
                            sfpr.CustomerBusinissNo = data[dindex];
                        findex++;
                        dindex++;
                    }
                }
                list.Add(sfpr);
            }

            return list;
        }

        private List<PayeeInfo> MatchPayee(FunctionInSettingType fst, List<List<string>> fields)
        {
            List<PayeeInfo> list = new List<PayeeInfo>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchSettingsMappingSettings[fst].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(fst);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            PayeeInfo payee = null;
            foreach (List<string> data in fields)
            {
                int findex = 0;
                int dindex = 0;
                payee = new PayeeInfo();
                foreach (string fieldname in flist)
                {
                    if (findex >= flist.Count) break;
                    if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                    if (fst == FunctionInSettingType.PayeeMg)
                    {
                        if (MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Account.Equals(fieldNames[findex]))
                            payee.Account = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Address.Equals(fieldNames[findex]))
                            payee.Address = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_CertifyCardNo.Equals(fieldNames[findex]))
                            payee.CertifyPaperNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_CertifyCardType.Equals(fieldNames[findex]))
                            payee.CertifyPaperType = DataConvertHelper.Instance.GetAgentExpressCertifyPaperType(data[dindex]);
                        else if (MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_ClearBankName.Equals(fieldNames[findex]))
                            payee.ClearBankName = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Email.Equals(fieldNames[findex]))
                            payee.Email = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Fax.Equals(fieldNames[findex]))
                            payee.Fax = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Name.Equals(fieldNames[findex]))
                            payee.Name = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_OpenBankName.Equals(fieldNames[findex]))
                            payee.OpenBankName = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_SerialNo.Equals(fieldNames[findex]))
                            payee.SerialNo = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Telephone.Equals(fieldNames[findex]))
                            payee.Telephone = data[dindex];
                        else if (MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Select_AccountType.Equals(fieldNames[findex]))
                            payee.AccountType = DataConvertHelper.Instance.GetAccountCategoryTypeObject(data[dindex]);
                    }
                    findex++;
                    dindex++;
                }
                list.Add(payee);
            }

            return list;
        }

        private List<UnitivePaymentForeignMoney> MatchUnitivePaymentForeignMoney(AppliableFunctionType aft, List<List<string>> fields)
        {
            List<UnitivePaymentForeignMoney> list = new List<UnitivePaymentForeignMoney>();

            Dictionary<string, string> dic = SystemSettings.Instance.BatchMappingSettings[aft].FieldsMappings;
            List<string> flist = new List<string>();
            flist.AddRange(dic.Keys);
            MappingsRelationSettings mrs = SystemInit.Instance.GetMappingRelation(aft);
            string[] fieldNames = new string[mrs.FieldsMappings.Count];
            mrs.FieldsMappings.Keys.CopyTo(fieldNames, 0);

            UnitivePaymentForeignMoney etr = null;
            try
            {
                foreach (List<string> data in fields)
                {
                    int findex = 0;
                    int dindex = 0;
                    etr = new UnitivePaymentForeignMoney();
                    foreach (string fieldname in flist)
                    {
                        if (findex >= flist.Count) break;
                        if (string.IsNullOrEmpty(dic[fieldname].ToString())) { findex++; continue; }
                        if (aft == AppliableFunctionType.UnitivePaymentFC)
                        {
                            if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerAccount.Equals(fieldNames[findex]))
                                etr.PayerAccount = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerName.Equals(fieldNames[findex]))
                                etr.PayerName = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerName.Equals(fieldNames[findex]))
                                etr.NominalPayerName = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerAccount.Equals(fieldNames[findex]))
                                etr.NominalPayerAccount = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CashType.Equals(fieldNames[findex]))
                                etr.CashType = DataConvertHelper.Instance.GetCashType(data[dindex].ToString());
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccount.Equals(fieldNames[findex]))
                                etr.PayeeAccount = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeName.Equals(fieldNames[findex]))
                                etr.PayeeName = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankName.Equals(fieldNames[findex]))
                                etr.PayeeOpenBankName = DataConvertHelper.Instance.FormatDateTimeFromInt(data[dindex].ToString());
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OrgCode.Equals(fieldNames[findex]))
                                etr.OrgCode = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OpenBankAddress.Equals(fieldNames[findex]))
                                etr.OpenBankAddress = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankSwiftCode.Equals(fieldNames[findex]))
                                etr.PayeeOpenBankSwiftCode = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankName.Equals(fieldNames[findex]))
                                etr.CorrespondentBankName = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankSwiftCode.Equals(fieldNames[findex]))
                                etr.CorrespondentBankSwiftCode = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankAddress.Equals(fieldNames[findex]))
                                etr.CorrespondentBankAddress = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccountInCorrespondentBank.Equals(fieldNames[findex]))
                                etr.PayeeAccountInCorrespondentBank = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Amount.Equals(fieldNames[findex]))
                                etr.Amount = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Address.Equals(fieldNames[findex]))
                                etr.Address = data[dindex].ToString();
                            //else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_AccountBankType.Equals(fieldNames[findex]))
                            //    etr.PayeeOpenBankType = DataConvertHelper.Instance.GetAccountBankTypeObject(Convert.ToInt32(data[dindex].ToString()));
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CustomerBusinissNo.Equals(fieldNames[findex]))
                                etr.CustomerBusinissNo = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Purpose.Equals(fieldNames[findex]))
                                etr.Purpose = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OrderPayDate.Equals(fieldNames[findex]))
                                etr.OrderPayDate = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Addtion.Equals(fieldNames[findex]))
                                etr.Addtion = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CodeofCountry.Equals(fieldNames[findex]))
                                etr.CodeofCountry = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IsNoSavePay.Equals(fieldNames[findex]))
                                etr.IsImportCancelAfterVerificationType = DataConvertHelper.Instance.GetIsImportCancelAfterVerificationType(data[dindex].ToString());
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_UnitivePaymentType.Equals(fieldNames[findex]))
                                etr.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(data[dindex].ToString());
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PaymentNature.Equals(fieldNames[findex]))
                                etr.PaymentNature = DataConvertHelper.Instance.GetPaymentPropertyType(data[dindex].ToString());
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode1.Equals(fieldNames[findex]))
                                etr.TransactionCode1 = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode2.Equals(fieldNames[findex]))
                                etr.TransactionCode2 = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1.Equals(fieldNames[findex]))
                                etr.IPPSMoneyTypeAmount1 = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2.Equals(fieldNames[findex]))
                                etr.IPPSMoneyTypeAmount2 = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion1.Equals(fieldNames[findex]))
                                etr.TransactionAddtion1 = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion2.Equals(fieldNames[findex]))
                                etr.TransactionAddtion2 = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IsPayOffLineString.Equals(fieldNames[findex]))
                                etr.IsPayOffLine = data[dindex].ToString() == "是" ? true : false;
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ContractNo.Equals(fieldNames[findex]))
                                etr.ContractNo = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_InvoiceNo.Equals(fieldNames[findex]))
                                etr.InvoiceNo = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_BatchNoOrTNoOrSerialNo.Equals(fieldNames[findex]))
                                etr.BatchNoOrTNoOrSerialNo = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ApplicantName.Equals(fieldNames[findex]))
                                etr.ApplicantName = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Contactnumber.Equals(fieldNames[findex]))
                                etr.Contactnumber = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_SendPriority.Equals(fieldNames[findex]))
                                etr.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(data[dindex].ToString());
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_realPayAddress.Equals(fieldNames[findex]))
                                etr.realPayAddress = data[dindex].ToString();
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PaymentCountryOrArea.Equals(fieldNames[findex]))
                                etr.PaymentCountryOrArea = DataConvertHelper.Instance.GetTransfer2CountryType(data[dindex].ToString());
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccountType.Equals(fieldNames[findex]))
                                etr.PayeeAccountType = DataConvertHelper.Instance.GetOverCountryPayeeAccountTypeObject(Convert.ToInt32(data[dindex].ToString()));
                            else if (MultiLanguageConvertHelper.Instance.UnitivePaymentFC_FCPayeeAccountType.Equals(fieldNames[findex]))
                                etr.FCPayeeAccountType = DataConvertHelper.Instance.GetUnitiveFCPayeeAccountType(data[dindex].ToString() == "普通账号" ? "A" : "B");

                            findex++;
                            dindex++;
                        }
                    }
                    list.Add(etr);
                }
            }
            catch { }


            return list;
        }

        #endregion

        /// <summary>
        /// 弱校验
        /// </summary>
        /// <param name="list"></param>
        /// <param name="aft"></param>
        /// <returns></returns>
        public string CheckDataAvilidLow(object list, AppliableFunctionType aft)
        {
            int count = 1;
            string result = string.Empty;
            ResultData rd;
            if (AppliableFunctionType.TransferOverBankIn == aft
                || AppliableFunctionType.TransferOverBankOut == aft
                || AppliableFunctionType.TransferWithCorp == aft
                || AppliableFunctionType.TransferWithIndiv == aft)
            {
                #region
                List<TransferAccount> dataList = list as List<TransferAccount>;
                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.PayerAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckPayerAccount(null, data.PayerAccount, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.TransferOverBankIn ? MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayerAccount : MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeAccount(null, data.PayeeAccount, "收/付款人账号", null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.TransferOverBankIn ? MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayerAccount : MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeAccount); break; }
                    }
                    if (aft == AppliableFunctionType.TransferWithCorp
                        || aft == AppliableFunctionType.TransferWithIndiv
                        || aft == AppliableFunctionType.TransferOverBankIn)
                    {
                        if (!string.IsNullOrEmpty(data.PayeeOpenBank))
                        {
                            if (data.AccountBankType == AccountBankType.OtherBankAccount)
                            {
                                rd = DataCheckCenter.Instance.CheckOpenBankName(null, data.PayeeOpenBank, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.TransferWithIndiv || aft == AppliableFunctionType.TransferWithCorp ? MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeOpenBankName : MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeBankName); break; }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeName))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeOrElecTicketPersonName(null, data.PayeeName, "", aft == AppliableFunctionType.TransferOverBankIn ? 70 : 76, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.TransferOverBankIn ? MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeName : MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayAmount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.PayAmount, "", 15, false, null);
                        if (!rd.Result)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_Amount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayFeeNo))
                    {
                        rd = DataCheckCenter.Instance.CheckPayFeeNo(null, data.PayFeeNo, false, null);
                        if (!rd.Result)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayFeeAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayDatetime))
                    {
                        rd = DataCheckCenter.Instance.CheckPayDatetime(null, data.PayDatetime, null);
                        if (!rd.Result)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.TransferOverBankIn ? MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayDate : MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayDateTime); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Addition))
                    {
                        rd = DataCheckCenter.Instance.CheckAddtion(null, data.Addition, null);
                        if (!rd.Result)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_Addtion); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Email))
                    {
                        rd = DataCheckCenter.Instance.CheckEmail(null, data.Email, null);
                        if (!rd.Result)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_Email); break; }
                    }
                    if (AppliableFunctionType.TransferOverBankOut == aft)
                    {
                        if (!string.IsNullOrEmpty(data.PayBankNo))
                        {
                            rd = DataCheckCenter.Instance.CheckClearBankNo(null, data.PayBankNo, null);
                            if (!rd.Result)
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeClearBankNo); break; }
                        }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.AgentExpressIn == aft
                || AppliableFunctionType.AgentExpressOut == aft
                || AppliableFunctionType.AgentExpressOut4Bar == aft)
            {
                #region
                List<object> temp = list as List<object>;
                BatchHeader batch = temp[0] as BatchHeader;
                List<AgentExpress> dataList = temp[1] as List<AgentExpress>;

                #region 检验批信息
                //ResultData rd = DataCheckCenter.Instance.CheckCustomerReferenceNo(batch.ProtecolNo);
                //if (!rd.Result) { return "批信息中数据格式有误"; }
                //rd = DataCheckCenter.Instance.CheckPayerAccount(batch.Payer.Account);
                //if (!rd.Result) { return "批信息中数据格式有误"; }
                //rd = DataCheckCenter.Instance.CheckPayDatetime(batch.TransferDatetime);
                //if (!rd.Result) { return "批信息中数据格式有误"; }
                //rd = DataCheckCenter.Instance.CheckAddtion(batch.Addtion, 80);
                //if (!rd.Result) { return "批信息中数据格式有误"; }
                //if (AppliableFunctionType.AgentNormalOut == aft)
                //{
                //    rd = DataCheckCenter.Instance.CheckLinkBankNo(batch.BankNo);
                //    if (!rd.Result) { return "批信息中数据格式有误"; }
                //}
                //else if (AppliableFunctionType.AgentNormalIn == aft)
                //{
                //    rd = DataCheckCenter.Instance.CheckUseType(batch.UseType);
                //    if (!rd.Result) { return "批信息中数据格式有误"; }
                //}
                #endregion

                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.AccountNo))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeAccount(null, data.AccountNo, "收/付款人账号", null);
                        if (!rd.Result)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.AgentExpressOut || aft == AppliableFunctionType.AgentExpressOut4Bar ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccount : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.AccountName))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeOrElecTicketPersonName(null, data.AccountName, "", 58, null);
                        if (!rd.Result)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.AgentExpressOut || aft == AppliableFunctionType.AgentExpressOut4Bar ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeName : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Amount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount.Trim(), "", 15, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.AgentExpressOut || aft == AppliableFunctionType.AgentExpressOut4Bar ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Amount : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Amount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.BankNo))
                    {
                        if (batch.BankType == AgentTransferBankType.Boc)
                        {
                            rd = DataCheckCenter.Instance.CheckProvince(null, data.BankNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.AgentExpressOut || aft == AppliableFunctionType.AgentExpressOut4Bar ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccountProvince : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerAccountProvince); break; }
                        }
                        else if (batch.BankType == AgentTransferBankType.Other)
                        {
                            rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.BankNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.AgentExpressIn ? MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerOpenBankNo : MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankNo); break; }
                        }
                    }
                    if (aft == AppliableFunctionType.AgentExpressIn)
                    {
                        if (!string.IsNullOrEmpty(data.ProtecolNo))
                        {
                            rd = DataCheckCenter.Instance.CheckProtecolNo(null, data.ProtecolNo, "", 60, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_SerialNo); break; }
                        }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.AgentNormalIn == aft
                || AppliableFunctionType.AgentNormalOut == aft)
            {
                #region
                List<object> temp = list as List<object>;
                BatchHeader batch = temp[0] as BatchHeader;
                List<AgentNormal> dataList = temp[1] as List<AgentNormal>;
                bool isIn = aft == AppliableFunctionType.AgentNormalIn;

                #region 检验批信息
                //ResultData rd = DataCheckCenter.Instance.CheckCustomerReferenceNo(batch.ProtecolNo);
                //if (!rd.Result) { return "批信息中数据格式有误"; }
                //rd = DataCheckCenter.Instance.CheckPayerAccount(batch.Payer.Account);
                //if (!rd.Result) { return "批信息中数据格式有误"; }
                //rd = DataCheckCenter.Instance.CheckAgentCardType(batch.CardType_Normal);
                //if (!rd.Result) { return "批信息中数据格式有误"; }
                //rd = DataCheckCenter.Instance.CheckAddtion(batch.Addtion, 80);
                //if (!rd.Result) { return "批信息中数据格式有误"; }
                //rd = DataCheckCenter.Instance.CheckPayFeeNo(batch.PayFeeNo, false);
                //if (!rd.Result) { return "批信息中数据格式有误"; }
                //if (AppliableFunctionType.AgentNormalOut == aft)
                //{
                //    rd = DataCheckCenter.Instance.CheckUseType(batch.UseType, true);
                //    if (!rd.Result) { return "批信息中数据格式有误"; }
                //    rd = DataCheckCenter.Instance.CheckPayDatetime(batch.TransferDatetime);
                //    if (!rd.Result) { return "批信息中数据格式有误"; }
                //}
                //else if (AppliableFunctionType.AgentNormalIn == aft)
                //{
                //    rd = DataCheckCenter.Instance.CheckLinkBankNo(batch.BankNo);
                //    if (!rd.Result) { return "批信息中数据格式有误"; }
                //    rd = DataCheckCenter.Instance.CheckAgentCardType(batch.CardType_Normal);
                //    if (!rd.Result) { return "批信息中数据格式有误"; }
                //    rd = DataCheckCenter.Instance.CheckUseType(batch.UseType, false);
                //    if (!rd.Result) { return "批信息中数据格式有误"; }
                //}
                #endregion

                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.BankNo))
                    {
                        if (batch.CardType == AgentCardType.OtherBankCard)
                        {
                            rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.BankNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.AgentNormalOut ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_BankLinkNoOrCNAPSNo : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_BankLinkNoOrCNAPSNo); break; }
                        }
                        else
                        {
                            rd = DataCheckCenter.Instance.CheckLinkBankNo(null, data.BankNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.AgentNormalOut ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_BankLinkNoOrCNAPSNo : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_BankLinkNoOrCNAPSNo); break; }
                        }
                    }
                    if (!string.IsNullOrEmpty(data.AccountNo))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeOrElecTicketPersonName(null, data.AccountNo, "", isIn ? 30 : 20, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.AgentNormalOut ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeAccount : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.AccountName))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeName(null, data.AccountName, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.AgentNormalOut ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeName : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Amount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount, "", 14, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.AgentNormalOut ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Amount : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Amount); break; }
                    }
                    if (isIn && !string.IsNullOrEmpty(data.UseType_In))
                    {
                        rd = DataCheckCenter.Instance.CheckAddtion(null, data.UseType_In, 60, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Usege); break; }
                    }
                    else if (!isIn)
                    {
                        if (data.UseType != AgentNormalFunctionType.Empty)
                        {
                            if (string.IsNullOrEmpty(data.UseTypeString)) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Usege); break; }
                            else if (!string.IsNullOrEmpty(data.UseTypeString))
                            {
                                if (batch.UseType.Equals("0") && data.UseType != AgentNormalFunctionType.A10) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Usege); break; }
                                else if (batch.UseType.Equals("1") && (data.UseType == AgentNormalFunctionType.A10)) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Usege); break; }
                            }
                        }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.ElecTicketRemit == aft)
            {
                #region
                List<ElecTicketRemit> dataList = list as List<ElecTicketRemit>;
                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.Amount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount, "", 18, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_Amount); break; }
                    } if (!string.IsNullOrEmpty(data.RemitDate))
                    {
                        rd = DataCheckCenter.Instance.CheckPayDatetime(null, data.RemitDate, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_RemitDate); break; }
                    }
                    if (!string.IsNullOrEmpty(data.EndDate) && !string.IsNullOrEmpty(data.RemitDate))
                    {
                        rd = DataCheckCenter.Instance.CheckEndDatetime(null, data.EndDate, data.RemitDate, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_EndDate, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_EndDate); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ExchangeAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.ExchangeAccount, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ExchangeName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.ExchangeName, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ExchangeOpenBankName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.ExchangeOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeOpenBankName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeOpenBankName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ExchangeOpenBankNo))
                    {
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.ExchangeOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeOpenBankNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Note))
                    {
                        rd = DataCheckCenter.Instance.CheckAddtion(null, data.Note, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_Note, 256, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_Note); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.PayeeAccount, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.PayeeName, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeOpenBankName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.PayeeOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeOpenBankName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeOpenBankName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeOpenBankNo))
                    {
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.PayeeOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeOpenBankNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.RemitAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.RemitAccount, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_RemitAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_RemitAccount); break; }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.ElecTicketBackNote == aft)
            {
                #region
                List<ElecTicketBackNote> dataList = list as List<ElecTicketBackNote>;
                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.BackNotedAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.BackNotedAccount, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.BackNotedName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.BackNotedName, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.BackNotedOpenBankName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.BackNotedOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedOpenBankName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedOpenBankName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.BackNotedOpenBankNo))
                    {
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.BackNotedOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedOpenBankNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ElecTicketSerialNo))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketSerialNo(null, data.ElecTicketSerialNo, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_TicketSerialNo, 30, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_TicketSerialNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Note))
                    {
                        rd = DataCheckCenter.Instance.CheckAddtion(null, data.Note, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Note, 256, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Note); break; }
                    }
                    if (!string.IsNullOrEmpty(data.RemitAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.RemitAccount, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Account, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Account); break; }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.ElecTicketPayMoney == aft)
            {
                #region
                List<ElecTicketPayMoney> dataList = list as List<ElecTicketPayMoney>;
                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.BillSerialNo))
                    {
                        rd = DataCheckCenter.Instance.CheckBillSerialNo(null, data.BillSerialNo, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_BillSerialNo, 60, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_BillSerialNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ContractNo))
                    {
                        rd = DataCheckCenter.Instance.CheckContractNo(null, data.ContractNo, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ContactNo, 60, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ContactNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ElecTicketSerialNo))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketSerialNo(null, data.ElecTicketSerialNo, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_TicketSerialNo, 30, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_TicketSerialNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Note))
                    {
                        rd = DataCheckCenter.Instance.CheckAddtion(null, data.Note, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Note, 512, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Note); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayMoneyAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.PayMoneyAccount, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayMoneyOpenBankName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.PayMoneyOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayMoneyOpenBankNo))
                    {
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.PayMoneyOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayMoneyDate))
                    {
                        rd = DataCheckCenter.Instance.CheckPayDatetime(null, data.PayMoneyDate, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayDate, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayDate); break; }
                    }
                    if (data.PayMoneyPercent != 0d)
                    {
                        rd = DataCheckCenter.Instance.CheckPayMoneyPercent(null, data.PayMoneyPercent.ToString(), MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyPercent, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyPercent); break; }
                    }
                    if (data.ProtocolMoneyPercent != 0d)
                    {
                        rd = DataCheckCenter.Instance.CheckProtocolPercent(null, data.ProtocolMoneyPercent.ToString(), MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ProtocolMoneyPercent, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ProtocolMoneyPercent); break; }
                    }
                    if (!string.IsNullOrEmpty(data.RemitAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.RemitAccount, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Account, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Account); break; }
                    }
                    if (!string.IsNullOrEmpty(data.StickOnAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.StickOnAccount, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.StickOnName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.StickOnName, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.StickOnOpenBankName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.StickOnOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.StickOnOpenBankNo))
                    {
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.StickOnOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankNo); break; }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.ElecTicketTipExchange == aft)
            {
                #region
                List<ElecTicketAutoTipExchange> dataList = list as List<ElecTicketAutoTipExchange>;
                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.BillSerialNo))
                    {
                        rd = DataCheckCenter.Instance.CheckBillSerialNo(null, data.BillSerialNo, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_BillSerialNo, 60, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_BillSerialNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ContractNo))
                    {
                        rd = DataCheckCenter.Instance.CheckContractNo(null, data.ContractNo, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ContactNo, 60, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ContactNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ElecTicketSerialNo))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketSerialNo(null, data.ElecTicketSerialNo, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_TicketSerialNo, 30, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_TicketSerialNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ExchangeAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.ExchangeAccount, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ExchangeName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.ExchangeName, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ExchangeOpenBankName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.ExchangeOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ExchangeOpenBankNo))
                    {
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.ExchangeOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankNo_RegexDescription); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Note))
                    {
                        rd = DataCheckCenter.Instance.CheckAddtion(null, data.Note, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Note, 512, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Note); break; }
                    }
                    if (!string.IsNullOrEmpty(data.RemitAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.RemitAccount, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Account, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Account); break; }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.ElecTicketPool == aft)
            {
                #region
                List<ElecTicketPool> dataList = list as List<ElecTicketPool>;
                foreach (var data in dataList)
                {
                    //if (string.IsNullOrEmpty(data.ElecTicketTypeString))
                    //{ result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                    if (!string.IsNullOrEmpty(data.CustomerRef))
                    {
                        rd = DataCheckCenter.Instance.CheckCustomerRefNo(null, data.CustomerRef, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_CustomerRef); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ElecTicketSerialNo))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketSerialNo(null, data.ElecTicketSerialNo, MultiLanguageConvertHelper.Instance.ElecTicketPool_ElecTicketSerialNo, 30, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ElecTicketSerialNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.RemitDate))
                    {
                        try { DateTime.Parse(data.RemitDate); }
                        catch { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitDate); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ExchangeDate))
                    {
                        try { DateTime.Parse(data.ExchangeDate); }
                        catch { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeDate); break; }
                        if (!string.IsNullOrEmpty(data.RemitDate) && DateTime.Parse(data.RemitDate).Date > DateTime.Parse(data.ExchangeDate).Date)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeDate); break; }
                    }
                    if (!string.IsNullOrEmpty(data.EndDate))
                    {
                        try { DateTime.Parse(data.EndDate); }
                        catch { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDate); break; }
                        if (!string.IsNullOrEmpty(data.RemitDate) && DateTime.Parse(data.RemitDate).Date > DateTime.Parse(data.EndDate).Date)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDate); break; }
                        if (!string.IsNullOrEmpty(data.ExchangeDate) && DateTime.Parse(data.ExchangeDate).Date > DateTime.Parse(data.EndDate).Date)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDate); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Amount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount, "", 16, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_Amount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.RemitAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.RemitAccount, MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.RemitName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.RemitName, MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitName); break; }
                    }
                    if (data.ElecTicketType == ElecTicketType.AC01)
                    {
                        if (!string.IsNullOrEmpty(data.ExchangeName))
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.ExchangeName, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankName, 120, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ExchangeBankNo))
                        {
                            rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.ExchangeBankNo, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankNo); break; }
                        }
                    }
                    else if (data.ElecTicketType == ElecTicketType.AC02)
                    {
                        if (!string.IsNullOrEmpty(data.ExchangeAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.ExchangeAccount, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeAccount, 32, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeAccount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ExchangeName))
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.ExchangeName, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeName, 120, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ExchangeBankNo))
                        {
                            rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.ExchangeBankNo, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeOpenBankNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeOpenBankNo); break; }
                        }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.PayeeAccount, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.PayeeName, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeOpenBankName))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.PayeeOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeOpenBankNo))
                    {
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.PayeeOpenBankNo, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PreBackNotedPerson))
                    {
                        rd = DataCheckCenter.Instance.CheckPreBackNotedPerson(null, data.PreBackNotedPerson, MultiLanguageConvertHelper.Instance.ElecTicketPool_PreBackNotedPerson, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_PreBackNotedPerson); break; }
                    }
                    if (!string.IsNullOrEmpty(data.BusinessTypeString))
                    {
                        if (data.BusinessType != ElecTicketPoolBusinessType.InPool2Struste && data.ElecTicketType == ElecTicketType.AC02)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_BusinessType); break; }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.TransferOverCountry == aft
                || AppliableFunctionType.TransferForeignMoney == aft
                || AppliableFunctionType.TransferForeignMoney4Bar == aft
                || AppliableFunctionType.TransferOverCountry4Bar == aft)
            {
                #region
                List<TransferGlobal> dataList = list as List<TransferGlobal>;
                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.PayDate))
                    {
                        try { DateTime.Parse(data.PayDate); }
                        catch { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayDate); break; }
                    }
                    if (!string.IsNullOrEmpty(data.CustomerRef))
                    {
                        rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(null, data.CustomerRef, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CutomerRef); break; }
                    }
                    if (!string.IsNullOrEmpty(data.RemitAmount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.RemitAmount, "", 15, data.PaymentCashType == CashType.JPY, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAmount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.SpotAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckPayerAccount(null, data.SpotAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.SpotAmount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.SpotAmount.ToString(), "", 15, data.PaymentCashType == CashType.JPY, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PurchaseAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckPayerAccount(null, data.PurchaseAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PurchaseAmount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.PurchaseAmount.ToString(), "", 15, data.PaymentCashType == CashType.JPY, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.OtherAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckPayerAccount(null, data.OtherAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAccount, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.OtherAmount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.OtherAmount.ToString(), "", 15, data.PaymentCashType == CashType.JPY, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAmount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.OrgCode) && !data.Equals("-"))
                    {
                        rd = DataCheckCenter.Instance.CheckOrgCode(null, data.OrgCode, MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode); break; }
                    }
                    if (!string.IsNullOrEmpty(data.RemitName))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.RemitName, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName, 70, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.RemitAddress))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.RemitAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress, aft == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.OtherBankAccount ? 64 : 70, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeOpenBankSwiftCode))
                    {
                        rd = DataCheckCenter.Instance.CheckSwiftCode(null, data.PayeeOpenBankSwiftCode, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankSwiftCode, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankSwiftCode); break; }
                    }
                    if (!string.IsNullOrEmpty(data.CorrespondentBankSwiftCode))
                    {
                        rd = DataCheckCenter.Instance.CheckSwiftCode(null, data.CorrespondentBankSwiftCode, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankSwiftCode, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankSwiftCode); break; }
                    }
                    if (aft == AppliableFunctionType.TransferOverCountry4Bar)
                    {
                        if (!string.IsNullOrEmpty(data.RemitAddress + data.RemitName))
                        {

                        }
                        rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(null, data.RemitAddress, data.RemitName, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName, 140, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress + "和" + MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName); break; }
                    }
                    if (aft == AppliableFunctionType.TransferOverCountry
                        || aft == AppliableFunctionType.TransferOverCountry4Bar)
                    {
                        if (!string.IsNullOrEmpty(data.PayeeAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeAccountGJ(null, data.PayeeAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount, 35, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.PayeeName, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.PayeeAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeName) || !string.IsNullOrEmpty(data.PayeeAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(null, data.PayeeName, data.PayeeAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName + "和" + MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeOpenBankName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.PayeeOpenBankName, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeOpenBankAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.PayeeOpenBankAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeOpenBankName) || !string.IsNullOrEmpty(data.PayeeOpenBankAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(null, data.PayeeOpenBankName, data.PayeeOpenBankAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName + "和" + MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.CorrespondentBankName, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.CorrespondentBankAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankName) || !string.IsNullOrEmpty(data.CorrespondentBankAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(null, data.CorrespondentBankName, data.CorrespondentBankAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName + "和" + MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeAccountInCorrespondentBank))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeAccountInCorrespondentBankGJ(null, data.PayeeAccountInCorrespondentBank, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank, 34, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank); break; }
                        }
                    }
                    else if (aft == AppliableFunctionType.TransferForeignMoney
                        || aft == AppliableFunctionType.TransferForeignMoney4Bar)
                    {
                        if (!string.IsNullOrEmpty(data.PayeeAccount))
                        {
                            if (data.PayeeOpenBankType == AccountBankType.BocAccount)
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeAccountGJEx(null, data.PayeeAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount, 20, true, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount); break; }
                            }
                            else if (data.PayeeOpenBankType == AccountBankType.OtherBankAccount)
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeAccountGJEx(null, data.PayeeAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount, 35, false, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount); break; }
                            }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeName, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName, aft == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.OtherBankAccount ? 64 : 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress, aft == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.OtherBankAccount ? 64 : 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress); break; }
                        }
                        if (data.PayeeOpenBankType == AccountBankType.OtherBankAccount)
                        {
                            if (!string.IsNullOrEmpty(data.PayeeOpenBankName))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeOpenBankName, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName, 70, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName); break; }
                            }
                            if (!string.IsNullOrEmpty(data.PayeeOpenBankSwiftCode))
                            {
                                rd = DataCheckCenter.Instance.CheckSwiftCode(null, data.PayeeOpenBankSwiftCode, MultiLanguageConvertHelper.Instance.DesignMain_Swift_Code, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.DesignMain_Swift_Code); break; }
                            }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeOpenBankAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeOpenBankAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress, 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.CorrespondentBankName, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName, 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankSwiftCode))
                        {
                            rd = DataCheckCenter.Instance.CheckSwiftCode(null, data.CorrespondentBankSwiftCode, MultiLanguageConvertHelper.Instance.DesignMain_Swift_Code, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.DesignMain_Swift_Code); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.CorrespondentBankAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress, 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeAccountInCorrespondentBank))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeAccountInCorrespondentBankGJ(null, data.PayeeAccountInCorrespondentBank, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank, 32, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank); break; }
                        }
                        if (aft == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.BocAccount)
                        {
                            if (!string.IsNullOrEmpty(data.CertifyPaperNo))
                            {
                                bool flag = data.CertifyPaperType == AgentExpressCertifyPaperType.IDCard;
                                if (flag) rd = DataCheckCenter.Instance.CheckCertifyCardNo(null, data.CertifyPaperNo, "", flag, null);
                                else rd = DataCheckCenter.Instance.CheckCertifyCardNo(null, data.CertifyPaperNo, "", null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo); break; }
                            }
                        }
                    }
                    //if (string.IsNullOrEmpty(data.PayeeNameofCountry) || string.IsNullOrEmpty(data.PayeeCodeofCountry))
                    //{ result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                    if (!string.IsNullOrEmpty(data.PayeeNameofCountry))
                    {
                        rd = DataCheckCenter.Instance.CheckCountryName(null, data.PayeeNameofCountry, "", 30, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeNameofCountry); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeCodeofCountry))
                    {
                        rd = DataCheckCenter.Instance.CheckCountryCode(null, data.PayeeCodeofCountry, "", 3, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCodeofCountry); break; }
                    }
                    if (!string.IsNullOrEmpty(data.RemitNote))
                    {
                        if (aft == AppliableFunctionType.TransferOverCountry
                           || aft == AppliableFunctionType.TransferOverCountry4Bar)
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.RemitNote, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote); break; }
                        }
                        else if (aft == AppliableFunctionType.TransferForeignMoney
                            || aft == AppliableFunctionType.TransferForeignMoney4Bar)
                        {
                            rd = DataCheckCenter.Instance.CheckAddtion(null, data.RemitNote, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote, aft == AppliableFunctionType.TransferForeignMoney4Bar ? 140 : 50, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote); break; }
                        }
                    }
                    if (!string.IsNullOrEmpty(data.DealSerialNoF))
                    {
                        rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.DealSerialNoF, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF, 6, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF); break; }
                        if (!string.IsNullOrEmpty(data.AmountF))
                        {
                            rd = DataCheckCenter.Instance.CheckCash(null, data.AmountF.ToString(), "", 15, data.PaymentCashType == CashType.JPY, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF); break; }
                        }
                        if (aft == AppliableFunctionType.TransferOverCountry
                            || aft == AppliableFunctionType.TransferOverCountry4Bar)
                        {
                            if (!string.IsNullOrEmpty(data.DealNoteF))
                            {
                                rd = DataCheckCenter.Instance.CheckAddtion(null, data.DealNoteF, MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteF, 100, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteF); break; }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(data.DealSerialNoS))
                    {
                        rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.DealSerialNoS, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS, 6, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS); break; }
                        if (!string.IsNullOrEmpty(data.AmountS))
                        {
                            rd = DataCheckCenter.Instance.CheckCash(null, data.AmountS.ToString(), "", 15, data.PaymentCashType == CashType.JPY, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS); break; }
                        }
                        if (aft == AppliableFunctionType.TransferOverCountry
                            || aft == AppliableFunctionType.TransferOverCountry4Bar)
                        {
                            if (!string.IsNullOrEmpty(data.DealNoteS))
                            {
                                rd = DataCheckCenter.Instance.CheckAddtion(null, data.DealNoteS, MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteS, 100, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteS); break; }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(data.ContactNo))
                    {
                        rd = DataCheckCenter.Instance.CheckSerialNoEx(null, data.ContactNo, MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo, 20, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.BillSerialNo))
                    {
                        rd = DataCheckCenter.Instance.CheckSerialNoEx(null, data.BillSerialNo, MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo, aft == AppliableFunctionType.TransferForeignMoney ? 20 : aft == AppliableFunctionType.TransferOverCountry ? 50 : 35, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo))
                    {
                        rd = DataCheckCenter.Instance.CheckSerialNoEx(null, data.BatchNoOrTNoOrSerialNo, MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo, 20, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ProposerName))
                    {
                        rd = DataCheckCenter.Instance.CheckProposerName(null, data.ProposerName, MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName, 20, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Telephone))
                    {
                        rd = DataCheckCenter.Instance.CheckTelePhone(null, data.Telephone, MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone, 20, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone); break; }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.InitiativeAllot == aft)
            {
                #region
                List<object> temp = list as List<object>;
                BatchHeader batch = temp[0] as BatchHeader;
                List<InitiativeAllot> dataList = temp[1] as List<InitiativeAllot>;

                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.AccountOut))
                    {
                        rd = DataCheckCenter.Instance.CheckAccountExIA(null, data.AccountOut.Trim(), MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountOut, 22, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountOut); break; }
                    }
                    if (!string.IsNullOrEmpty(data.NameOut))
                    {
                        rd = DataCheckCenter.Instance.CheckNameExIA(null, data.NameOut.Trim(), MultiLanguageConvertHelper.Instance.InitiativeAllot_NameOut, 76, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.InitiativeAllot_NameOut); break; }
                    }
                    if (!string.IsNullOrEmpty(data.AccountIn))
                    {
                        rd = DataCheckCenter.Instance.CheckAccountExIA(null, data.AccountIn.Trim(), MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountIn, 22, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountIn); break; }
                    }
                    if (!string.IsNullOrEmpty(data.NameIn))
                    {
                        rd = DataCheckCenter.Instance.CheckNameExIA(null, data.NameIn.Trim(), MultiLanguageConvertHelper.Instance.InitiativeAllot_NameIn, 76, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.InitiativeAllot_NameIn); break; }
                    }
                    rd = DataCheckCenter.Instance.CheckCash(null, data.Amount.ToString().Trim(), MultiLanguageConvertHelper.Instance.InitiativeAllot_Amount, 14, false, null);
                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.InitiativeAllot_Amount); break; }
                    if (!string.IsNullOrEmpty(data.Addition))
                    {
                        rd = DataCheckCenter.Instance.CheckAddtionExIAOrUP(null, data.Addition.Trim(), MultiLanguageConvertHelper.Instance.InitiativeAllot_Addition, 200, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.InitiativeAllot_Addition); break; }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.ApplyofFranchiserFinancing == aft)
            {
                #region
                List<SpplyFinancingApply> dataList = list as List<SpplyFinancingApply>;
                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.ContractOrOrderNo))
                    {
                        rd = DataCheckCenter.Instance.CheckContractOrOrderNo(null, data.ContractOrOrderNo, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ContractOrOrderNo, 70, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ContractOrOrderNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ContractOrOrderAmount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.ContractOrOrderAmount, "", 15, data.ContractOrOrderCashType == CashType.JPY, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_OrderAmount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.TaxInvoiceNo))
                    {
                        rd = DataCheckCenter.Instance.CheckTaxBillSerialNo(null, data.TaxInvoiceNo, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_TaxInvoiceNo, 70, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_TaxInvoiceNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ReceiptNo))
                    {
                        rd = DataCheckCenter.Instance.CheckReceiptNo(null, data.ReceiptNo, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ReceiptNo, 40, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ReceiptNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.RiskTakingLetterNo))
                    {
                        rd = DataCheckCenter.Instance.CheckRiskTakingLetterNo(null, data.RiskTakingLetterNo, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_RiskTakingLetterNo, 70, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_RiskTakingLetterNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.GoodsDesc))
                    {
                        rd = DataCheckCenter.Instance.CheckGoodsDesc(null, data.GoodsDesc, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_GoodsDesc, 600, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_GoodsDesc); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ApplyAmount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.ApplyAmount, "", 15, data.ContractOrOrderCashType == CashType.JPY, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ApplyAmount); break; }
                    }
                    if (data.ApplyDays != 0)
                    {
                        rd = DataCheckCenter.Instance.CheckApplyDays(null, data.ApplyDays.ToString(), MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ApplyDays, 4, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ApplyDays); break; }
                    }
                    if (!string.IsNullOrEmpty(data.AgreementNo))
                    {
                        rd = DataCheckCenter.Instance.CheckAgrementNo(null, data.AgreementNo, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_AgrementNo, 70, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_AgrementNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.InterestFloatingPercent))
                    {
                        rd = DataCheckCenter.Instance.CheckInterestFloatingPercent(null, data.InterestFloatingPercent, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_InterestFloatingPercent, 12, null);
                        if (!rd.Result)
                        {
                            if (data.InterestFloatType == InterestFloatType.No && data.InterestFloatingPercent.Equals("0"))
                                result = string.Empty;
                            else
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_InterestFloatingPercent); break; }
                        }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.PurchaserOrder == aft
                || AppliableFunctionType.SellerOrder == aft)
            {
                #region
                List<SpplyFinancingOrder> dataList = list as List<SpplyFinancingOrder>;
                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.OrderNo))
                    {
                        rd = DataCheckCenter.Instance.CheckOrderNo(null, data.OrderNo, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo, 70, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo); break; }
                    }
                    rd = DataCheckCenter.Instance.CheckCash(null, data.Amount.ToString(), "", 15, data.CashType == CashType.JPY, null);
                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_Amount); break; }
                    if (aft == AppliableFunctionType.PurchaserOrder)
                    {
                        if (!string.IsNullOrEmpty(data.ERPCode))
                        {
                            rd = DataCheckCenter.Instance.CheckERPCode(null, data.ERPCode, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_ERPCode_Seller, 40, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_ERPCode_Seller); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CustomerApplyNo))
                        {
                            rd = DataCheckCenter.Instance.CheckBankCustomerNo(null, data.CustomerApplyNo, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerNo_Seller, 40, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerNo_Seller); break; }
                        }
                    }
                    else if (aft == AppliableFunctionType.SellerOrder)
                    {
                        rd = DataCheckCenter.Instance.CheckCustomerNamePurchase(null, data.CustomerName, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerName_Purchase, 80, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerName_Purchase); break; }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.PurchaserOrderMgr == aft
                || AppliableFunctionType.SellerOrderMgr == aft)
            {
                #region
                List<SpplyFinancingOrder> dataList = list as List<SpplyFinancingOrder>;
                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.OrderNo))
                    {
                        rd = DataCheckCenter.Instance.CheckOrderNo(null, data.OrderNo, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo, 70, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo); break; }
                    }
                    rd = DataCheckCenter.Instance.CheckCash(null, data.Amount, "", 15, false, null);
                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_Amount); break; }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.BillofDebtReceivablePurchaser == aft
                || AppliableFunctionType.BillofDebtReceivableSeller == aft)
            {
                #region
                List<SpplyFinancingBill> dataList = list as List<SpplyFinancingBill>;
                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.BillSerialNo))
                    {
                        rd = DataCheckCenter.Instance.CheckBillSerialNoSF(null, data.BillSerialNo.Trim(), MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillSerialNo, 20, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillSerialNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.ContractNo))
                    {
                        rd = DataCheckCenter.Instance.CheckContractNoEx(null, data.ContractNo.Trim(), MultiLanguageConvertHelper.Instance.SpplyFinancingBill_ContractNo, 40, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingBill_ContractNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.CustomerNo))
                    {
                        rd = DataCheckCenter.Instance.CheckBankCustomerNo(null, data.CustomerNo.Trim(), aft == AppliableFunctionType.BillofDebtReceivableSeller ? MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Purchase : MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Seller, 16, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.BillofDebtReceivableSeller ? MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Purchase : MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Seller); break; }
                    }
                    if (!string.IsNullOrEmpty(data.CustomerName))
                    {
                        rd = DataCheckCenter.Instance.CheckCustomerName(null, data.CustomerName.Trim(), aft == AppliableFunctionType.BillofDebtReceivableSeller ? MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Purchase : MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Seller, 80, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.BillofDebtReceivableSeller ? MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Purchase : MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Seller); break; }
                    }
                    //if (data.CashType == CashType.Empty) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                    if (!string.IsNullOrEmpty(data.Amount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount.ToString(), "", 15, data.CashType == CashType.JPY, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingBill_Amount); break; }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser == aft)
            {
                #region
                List<SpplyFinancingPayOrReceipt> dataList = list as List<SpplyFinancingPayOrReceipt>;
                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.BillSerialNo))
                    {
                        rd = DataCheckCenter.Instance.CheckBillSerialNoSF(null, data.BillSerialNo.Trim(), MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_BillSerialNo, 20, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_BillSerialNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.CustomerNo))
                    {
                        rd = DataCheckCenter.Instance.CheckBankCustomerNo(null, data.CustomerNo, MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerNo, 16, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerNo); break; }
                    }
                    if (!string.IsNullOrEmpty(data.CustomerName))
                    {
                        rd = DataCheckCenter.Instance.CheckCustomerName(null, data.CustomerName.Trim(), MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerName, 80, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerName); break; }
                    }
                    rd = DataCheckCenter.Instance.CheckCash(null, data.PayAmountForThisTime.ToString(), "", 17, data.CashType == CashType.JPY, null);
                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_AmountThisTime); break; }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.UnitivePaymentRMB == aft)
            {
                #region
                List<UnitivePaymentRMB> dataList = list as List<UnitivePaymentRMB>;
                foreach (var data in dataList)
                {
                    if (!string.IsNullOrEmpty(data.PayerAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckPayerAccountUP(null, data.PayerAccount, "", 12, 18, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayerAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayerName))
                    {
                        rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.PayerName, "", 200, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayerName); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeAccountUP(null, data.PayeeAccount, "", 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeAccount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.PayeeName))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeNameAgentInOrUP(null, data.PayeeName, "", 76, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeName); break; }
                    }
                    if (data.BankType == AccountBankType.OtherBankAccount)
                    {
                        if (!string.IsNullOrEmpty(data.PayeeOpenBankName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeOpenBankName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeOpenBankName); break; }
                        } if (!string.IsNullOrEmpty(data.PayeeCNAPS))
                        {
                            rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.PayeeCNAPS, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeCNAPS); break; }
                        }
                    }
                    if (!string.IsNullOrEmpty(data.NominalPayerAccount))
                    {
                        rd = DataCheckCenter.Instance.CheckAccountUP(null, data.NominalPayerAccount, "", 35, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_NominalPayerAccount); break; }
                    } if (!string.IsNullOrEmpty(data.NominalPayerName))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeNameAgentInOrUP(null, data.NominalPayerName, "", 76, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_NominalPayerName); break; }
                    }
                    //if (!string.IsNullOrEmpty(data.NominalPayerBankLinkNo))
                    //{
                    //    rd = DataCheckCenter.Instance.CheckLinkBankNo(null, data.NominalPayerBankLinkNo, "", null);
                    //    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                    //} if (!string.IsNullOrEmpty(data.NominalPayerOpenBankName))
                    //{
                    //    rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.NominalPayerOpenBankName, "", 160, null);
                    //    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                    //}
                    if (!string.IsNullOrEmpty(data.Amount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount.ToString(), "", 15, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_Amount); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Purpose))
                    {
                        rd = DataCheckCenter.Instance.CheckAddtionExIAOrUP(null, data.Purpose, "", 200, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_Purpose); break; }
                    }
                    if (!string.IsNullOrEmpty(data.CustomerBusinissNo))
                    {
                        rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(null, data.CustomerBusinissNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_CustomerBusinissNo); break; }
                    }
                    if (!data.IsTipPayee || (data.IsTipPayee && !string.IsNullOrEmpty(data.TipPayeePhone)))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeePhone(null, data.TipPayeePhone, 11, 15, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_TipPayeePhone); break; }
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.UnitivePaymentFC == aft)
            {
                #region
                List<UnitivePaymentForeignMoney> dataList = list as List<UnitivePaymentForeignMoney>;
                foreach (var data in dataList)
                {
                    if (data.PayeeAccountType == OverCountryPayeeAccountType.BocAccount)
                    {
                        #region
                        if (!string.IsNullOrEmpty(data.PayerAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerAccountUP(null, data.PayerAccount, "", 12, 18, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerAccount); break; }

                        }
                        if (!string.IsNullOrEmpty(data.PayerName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.PayerName, "", 200, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.NominalPayerAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(null, data.NominalPayerAccount, "", 35, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerAccount); break; }

                        }
                        if (!string.IsNullOrEmpty(data.NominalPayerName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.NominalPayerName, "", 200, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerName); break; }

                        }
                        if (!string.IsNullOrEmpty(data.PayeeAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(null, data.PayeeAccount, "", 35, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccount); break; }

                        }
                        if (!string.IsNullOrEmpty(data.PayeeName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameAgentInOrUP(null, data.PayeeName, "", 240, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeName); break; }

                        }
                        if (!string.IsNullOrEmpty(data.PayeeOpenBankName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeOpenBankName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankName); break; }

                        }
                        if (!string.IsNullOrEmpty(data.CodeofCountry))
                        {
                            rd = DataCheckCenter.Instance.CheckCountryCode(null, data.CodeofCountry, "", 3, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CodeofCountry); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CustomerBusinissNo))
                        {
                            rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(null, data.CustomerBusinissNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CustomerBusinissNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Amount))
                        {
                            rd = DataCheckCenter.Instance.CheckCash(null, Convert.ToDouble(data.Amount), 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Amount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Addtion))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeAddtion(null, data.Addtion, "", 120, true, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Addtion); break; }
                        }
                        if (!string.IsNullOrEmpty(data.TransactionCode1))
                        {
                            rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.TransactionCode1, "", 6, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode1); break; }
                            if (string.IsNullOrEmpty(data.IPPSMoneyTypeAmount1))
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1); break; }
                            else
                            {
                                rd = DataCheckCenter.Instance.CheckCash(null, data.IPPSMoneyTypeAmount1, "", 15, data.CashType == CashType.JPY, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1); break; }
                            }
                            if (!string.IsNullOrEmpty(data.TransactionAddtion1))
                            {
                                rd = DataCheckCenter.Instance.CheckAddtion(null, data.TransactionAddtion1, "", 100, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion1); break; }
                            }
                        }
                        if (!string.IsNullOrEmpty(data.TransactionCode2))
                        {
                            rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.TransactionCode2, "", 6, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode2); break; }
                            if (string.IsNullOrEmpty(data.IPPSMoneyTypeAmount2))
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2); break; }
                            else
                            {
                                rd = DataCheckCenter.Instance.CheckCash(null, data.IPPSMoneyTypeAmount2, "", 15, data.CashType == CashType.JPY, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2); break; }
                            }
                            if (!string.IsNullOrEmpty(data.TransactionAddtion2))
                            {
                                rd = DataCheckCenter.Instance.CheckAddtion(null, data.TransactionAddtion2, "", 100, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion2); break; }
                            }
                        }
                        if (!string.IsNullOrEmpty(data.ContractNo))
                        {
                            rd = DataCheckCenter.Instance.CheckLength(null, data.ContractNo, "", 20, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ContractNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo))
                        {
                            rd = DataCheckCenter.Instance.CheckLength(null, data.BatchNoOrTNoOrSerialNo, "", 20, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_BatchNoOrTNoOrSerialNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.InvoiceNo))
                        {
                            rd = DataCheckCenter.Instance.CheckBillSerialNoSF(null, data.InvoiceNo, "", 50, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_InvoiceNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ApplicantName))
                        {
                            rd = DataCheckCenter.Instance.CheckProposerName(null, data.ApplicantName, "", 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ApplicantName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ApplicantName))
                        {
                            rd = DataCheckCenter.Instance.CheckTelePhone(null, data.Contactnumber, "", 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Contactnumber); break; }
                        }
                        #endregion
                    }
                    else if (data.PayeeAccountType == OverCountryPayeeAccountType.OtherAccount)
                    {
                        #region
                        if (!string.IsNullOrEmpty(data.PayerAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerAccountUP(null, data.PayerAccount, "", 12, 18, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerAccount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayerName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.PayerName, "", 200, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.NominalPayerAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(null, data.NominalPayerAccount, "", 35, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerAccount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.NominalPayerName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.NominalPayerName, "", 200, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(null, data.PayeeAccount, "", 35, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeName, "", 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Address))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.Address, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Address); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CodeofCountry))
                        {
                            rd = DataCheckCenter.Instance.CheckCountryCode(null, data.CodeofCountry, "", 3, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CodeofCountry); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeOpenBankName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeOpenBankName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeOpenBankSwiftCode))
                        {
                            rd = DataCheckCenter.Instance.CheckSwiftCode(null, data.PayeeOpenBankSwiftCode, "", null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankSwiftCode); break; }
                        }
                        if (!string.IsNullOrEmpty(data.OpenBankAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.OpenBankAddress, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OpenBankAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.CorrespondentBankName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankSwiftCode))
                        {
                            rd = DataCheckCenter.Instance.CheckSwiftCode(null, data.CorrespondentBankSwiftCode, "", null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankSwiftCode); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckCountryName(null, data.CorrespondentBankAddress, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeAccountInCorrespondentBank))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeAccountInCorrespondentBankGJ(null, data.PayeeAccountInCorrespondentBank, "", 35, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccountInCorrespondentBank); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CodeofCountry))
                        {
                            rd = DataCheckCenter.Instance.CheckCountryCode(null, data.CodeofCountry, "", 3, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CodeofCountry); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Amount))
                        {
                            rd = DataCheckCenter.Instance.CheckCash(null, Convert.ToDouble(data.Amount), 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Amount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.OrgCode))
                        {
                            rd = DataCheckCenter.Instance.CheckOrgCode(null, data.OrgCode, "", null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OrgCode); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CustomerBusinissNo))
                        {
                            rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(null, data.CustomerBusinissNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CustomerBusinissNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.realPayAddress))
                        {
                            rd = DataCheckCenter.Instance.ChecktbRemittorAddress(null, data.realPayAddress, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_realPayAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Addtion))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeAddtion(null, data.Addtion, "", 120, false, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Addtion); break; }
                        }
                        if (!string.IsNullOrEmpty(data.TransactionCode1))
                        {
                            rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.TransactionCode1, "", 6, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode1); break; }
                            if (!string.IsNullOrEmpty(data.IPPSMoneyTypeAmount1))
                            {
                                rd = DataCheckCenter.Instance.CheckCash(null, data.IPPSMoneyTypeAmount1, "", 15, data.CashType == CashType.JPY, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1); break; }
                            }
                            if (!string.IsNullOrEmpty(data.TransactionAddtion1))
                            {
                                rd = DataCheckCenter.Instance.CheckAddtion(null, data.TransactionAddtion1, "", 100, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion1); break; }
                            }
                        }
                        if (!string.IsNullOrEmpty(data.TransactionCode2))
                        {
                            rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.TransactionCode2, "", 6, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode2); break; }
                            if (!string.IsNullOrEmpty(data.IPPSMoneyTypeAmount2))
                            {
                                rd = DataCheckCenter.Instance.CheckCash(null, data.IPPSMoneyTypeAmount2, "", 15, data.CashType == CashType.JPY, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2); break; }
                            }
                            if (!string.IsNullOrEmpty(data.TransactionAddtion2))
                            {
                                rd = DataCheckCenter.Instance.CheckAddtion(null, data.TransactionAddtion2, "", 100, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion2); break; }
                            }
                        }
                        if (!string.IsNullOrEmpty(data.ContractNo))
                        {
                            rd = DataCheckCenter.Instance.CheckLength(null, data.ContractNo, "", 20, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ContractNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo))
                        {
                            rd = DataCheckCenter.Instance.CheckLength(null, data.BatchNoOrTNoOrSerialNo, "", 40, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_BatchNoOrTNoOrSerialNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.InvoiceNo))
                        {
                            rd = DataCheckCenter.Instance.CheckLength(null, data.InvoiceNo, "", 35, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_InvoiceNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ApplicantName))
                        {
                            rd = DataCheckCenter.Instance.CheckProposerName(null, data.ApplicantName, "", 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ApplicantName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Contactnumber))
                        {
                            rd = DataCheckCenter.Instance.CheckTelePhone(null, data.Contactnumber, "", 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Contactnumber); break; }
                        }
                        #endregion
                    }
                    else if (data.PayeeAccountType == OverCountryPayeeAccountType.ForeignAccount)
                    {
                        #region
                        if (!string.IsNullOrEmpty(data.PayerAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerAccountUP(null, data.PayerAccount, "", 12, 18, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerAccount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayerName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.PayerName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.NominalPayerAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckAccountUP(null, data.NominalPayerAccount, "", 35, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerAccount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.NominalPayerName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.NominalPayerName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.PayeeAccount, "", 34, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.PayeeName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Address))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.Address, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Address); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeOpenBankName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeOpenBankName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeOpenBankSwiftCode))
                        {
                            rd = DataCheckCenter.Instance.CheckSwiftCodeFC(null, data.PayeeOpenBankSwiftCode, "", null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankSwiftCode); break; }
                        }
                        if (!string.IsNullOrEmpty(data.OpenBankAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.OpenBankAddress, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OpenBankAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.CorrespondentBankName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankSwiftCode))
                        {
                            rd = DataCheckCenter.Instance.CheckSwiftCodeFC(null, data.CorrespondentBankSwiftCode, "", null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankSwiftCode); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankAddress))
                        {
                            rd = DataCheckCenter.Instance.CheckCountryName(null, data.CorrespondentBankAddress, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeAccountInCorrespondentBank))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeAccountInCorrespondentBankGJ(null, data.PayeeAccountInCorrespondentBank, "", 35, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccountInCorrespondentBank); break; }
                        }
                        //if (string.IsNullOrEmpty(data.CodeofCountry))
                        //{ result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                        if (!string.IsNullOrEmpty(data.CodeofCountry))
                        {
                            rd = DataCheckCenter.Instance.CheckCountryCode(null, data.CodeofCountry, "", 3, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CodeofCountry); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Amount))
                        {
                            rd = DataCheckCenter.Instance.CheckCash(null, Convert.ToDouble(data.Amount), 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Amount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.OrgCode))
                        {
                            rd = DataCheckCenter.Instance.CheckOrgCode(null, data.OrgCode, "", null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OrgCode); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CustomerBusinissNo))
                        {
                            rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(null, data.CustomerBusinissNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CustomerBusinissNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.realPayAddress))
                        {
                            rd = DataCheckCenter.Instance.ChecktbRemittorAddress(null, data.realPayAddress, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_realPayAddress); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Addtion))
                        {
                            rd = DataCheckCenter.Instance.CheckAddtionFCForeign(null, data.Addtion, "", 120, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Addtion); break; }
                        }
                        if (!string.IsNullOrEmpty(data.TransactionCode1))
                        {
                            rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.TransactionCode1, "", 6, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode1); break; }
                            if (!string.IsNullOrEmpty(data.IPPSMoneyTypeAmount1))
                            {
                                rd = DataCheckCenter.Instance.CheckCash(null, data.IPPSMoneyTypeAmount1, "", 15, data.CashType == CashType.JPY, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1); break; }
                            }
                            if (!string.IsNullOrEmpty(data.TransactionAddtion1))
                            {
                                rd = DataCheckCenter.Instance.CheckAddtionFCForeign(null, data.TransactionAddtion1, "", 50, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion1); break; }
                            }
                        }
                        if (!string.IsNullOrEmpty(data.TransactionCode2))
                        {
                            rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.TransactionCode2, "", 6, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode2); break; }
                            if (!string.IsNullOrEmpty(data.IPPSMoneyTypeAmount2))
                            {
                                rd = DataCheckCenter.Instance.CheckCash(null, data.IPPSMoneyTypeAmount2, "", 15, data.CashType == CashType.JPY, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2); break; }
                            }
                            if (!string.IsNullOrEmpty(data.TransactionAddtion2))
                            {
                                rd = DataCheckCenter.Instance.CheckAddtionFCForeign(null, data.TransactionAddtion2, "", 50, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion2); break; }
                            }
                        }
                        if (!string.IsNullOrEmpty(data.ContractNo))
                        {
                            rd = DataCheckCenter.Instance.CheckLength(null, data.ContractNo, "", 20, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ContractNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo))
                        {
                            rd = DataCheckCenter.Instance.CheckLength(null, data.BatchNoOrTNoOrSerialNo, "", 20, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_BatchNoOrTNoOrSerialNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.InvoiceNo))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.InvoiceNo, "", 50, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_InvoiceNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ApplicantName))
                        {
                            rd = DataCheckCenter.Instance.CheckProposerName(null, data.ApplicantName, "", 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ApplicantName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Contactnumber))
                        {
                            rd = DataCheckCenter.Instance.CheckTelePhone(null, data.Contactnumber, "", 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Contactnumber); break; }
                        }
                        #endregion
                    }
                    count++;
                }
                #endregion
            }
            else if (AppliableFunctionType.VirtualAccountTransfer == aft)
            {
                #region
                List<VirtualAccount> dataListV = list as List<VirtualAccount>;
                foreach (var data in dataListV)
                {
                    if (!string.IsNullOrEmpty(data.AccountOut))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(null, data.AccountOut.Trim(), MultiLanguageConvertHelper.Instance.Virtual_AccountOut, 35, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }
                    }
                    if (!string.IsNullOrEmpty(data.NameOut))
                    {
                        rd = DataCheckCenter.Instance.CheckVirtualAccountName(null, data.NameOut.Trim(), MultiLanguageConvertHelper.Instance.Virtual_NameOut, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }
                    }
                    if (!string.IsNullOrEmpty(data.AccountIn))
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(null, data.AccountIn.Trim(), MultiLanguageConvertHelper.Instance.Virtual_AccountIn, 35, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }
                    }
                    if (!string.IsNullOrEmpty(data.NameIn))
                    {
                        rd = DataCheckCenter.Instance.CheckVirtualAccountName(null, data.NameIn.Trim(), MultiLanguageConvertHelper.Instance.Virtual_NameIn, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Amount))
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount.ToString().Trim(), MultiLanguageConvertHelper.Instance.Virtual_Amount, 14, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }
                    }
                    if (!string.IsNullOrEmpty(data.Purpose))
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeAddtion(null, data.Purpose.Trim(), MultiLanguageConvertHelper.Instance.Virtual_Pursion, 200, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }
                    }
                    if (!string.IsNullOrEmpty(data.CustomerBusinissNo))
                    {
                        rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(null, data.CustomerBusinissNo.Trim(), null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }
                    }
                    count++;
                }
                #endregion
            }
            return result;
        }

        /// <summary>
        /// 强校验
        /// </summary>
        /// <param name="list"></param>
        /// <param name="aft"></param>
        /// <returns></returns>
        public string CheckDataAvilidHigh(object list, AppliableFunctionType aft)
        {
            int count = 1;
            string result = string.Empty;
            ResultData rd = new ResultData();
            switch (aft)
            {
                case AppliableFunctionType.TransferWithCorp:
                case AppliableFunctionType.TransferWithIndiv:
                    #region
                    List<TransferAccount> dataTAList = list as List<TransferAccount>;
                    foreach (var data in dataTAList)
                    {
                        rd = DataCheckCenter.Instance.CheckPayerAccount(null, data.PayerAccount, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayerAccount); break; }
                        rd = DataCheckCenter.Instance.CheckPayeeAccount(null, data.PayeeAccount, "", null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeAccount); break; }
                        if (data.AccountBankType == AccountBankType.OtherBankAccount)
                        {
                            rd = DataCheckCenter.Instance.CheckOpenBankName(null, data.PayeeOpenBank, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeOpenBankName); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckPayeeOrElecTicketPersonName(null, data.PayeeName, "", 76, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeName); break; }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.PayAmount, "", 15, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_Amount); break; }
                        rd = DataCheckCenter.Instance.CheckPayFeeNo(null, data.PayFeeNo, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayFeeAccount); break; }
                        rd = DataCheckCenter.Instance.CheckPayDatetime(null, data.PayDatetime, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayDate); break; }
                        rd = DataCheckCenter.Instance.CheckAddtion(null, data.Addition, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_Addtion); break; }
                        if (!string.IsNullOrEmpty(data.Email))
                        {
                            rd = DataCheckCenter.Instance.CheckEmail(null, data.Email, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_Email); break; }
                        }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.TransferOverBankIn:
                case AppliableFunctionType.TransferOverBankOut:
                    #region
                    List<TransferAccount> dataTOList = list as List<TransferAccount>;
                    foreach (var data in dataTOList)
                    {
                        if (!string.IsNullOrEmpty(data.CustomerRef))
                        {
                            rd = DataCheckCenter.Instance.CheckCustomerReferenceNo(null, data.CustomerRef, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_Mappings_CustomerRef); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckPayerAccount(null, data.PayerAccount, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.TransferOverBankIn ? MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayerAccount : MultiLanguageConvertHelper.Instance.Transfer_Mappings_PayeeAccount); break; }
                        rd = DataCheckCenter.Instance.CheckPayeeAccount(null, data.PayeeAccount, "", null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.TransferOverBankIn ? MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeAccount : MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerAccount); break; }
                        if (aft == AppliableFunctionType.TransferOverBankIn || (aft == AppliableFunctionType.TransferOverBankOut && !string.IsNullOrEmpty(data.PayeeName)))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeOrElecTicketPersonName(null, data.PayeeName, "", aft == AppliableFunctionType.TransferOverBankIn ? 70 : 76, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.TransferOverBankIn ? MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeName : MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerName); break; }
                        }
                        if (aft == AppliableFunctionType.TransferOverBankIn || (aft == AppliableFunctionType.TransferOverBankOut && !string.IsNullOrEmpty(data.PayerName)))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerName(null, data.PayerName, "", aft == AppliableFunctionType.TransferOverBankIn ? 70 : 76, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.TransferOverBankIn ? MultiLanguageConvertHelper.Instance.DesignMain_PayerName : MultiLanguageConvertHelper.Instance.DesignMain_PayeeName); break; }
                        }
                        if (aft == AppliableFunctionType.TransferOverBankIn)
                        {
                            rd = DataCheckCenter.Instance.CheckOpenBankName(null, data.PayeeOpenBank, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayerBankName); break; }
                            rd = DataCheckCenter.Instance.CheckProtecolNo(null, data.PayProtecolNo, "", 60, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayProtecolNo); break; }
                            rd = DataCheckCenter.Instance.CheckBusinessType(data.BusinessType);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_BusinessType); break; }
                        }
                        else if (aft == AppliableFunctionType.TransferOverBankOut)
                        {
                            rd = DataCheckCenter.Instance.CheckClearBankNo(null, data.PayBankNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayeeClearBankNo); break; }
                            //rd = DataCheckCenter.Instance.CheckClearBankNo(null, data.PayBankNo, null);
                            //if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckPayDatetime(null, data.PayDatetime, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.TransferOverBankIn ? MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayDate : MultiLanguageConvertHelper.Instance.Transfer_OverBankIn_Mappings_PayDateTime); break; }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.PayAmount, "", 15, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_Amount); break; }
                        if (!string.IsNullOrEmpty(data.PayFeeNo))
                        {
                            rd = DataCheckCenter.Instance.CheckPayFeeNo(null, data.PayFeeNo, true, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_PayFeeAccount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Addition))
                        {
                            rd = DataCheckCenter.Instance.CheckAddtion(null, data.Addition, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.Transfer_OverBankOut_Mappings_Addtion); break; }
                        }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.AgentExpressIn:
                case AppliableFunctionType.AgentExpressOut:
                case AppliableFunctionType.AgentExpressOut4Bar:
                    #region
                    List<object> tempAE = list as List<object>;
                    BatchHeader batchAE = tempAE[0] as BatchHeader;
                    List<AgentExpress> dataAEList = tempAE[1] as List<AgentExpress>;

                    #region 检验批信息
                    //ResultData rd = DataCheckCenter.Instance.CheckCustomerReferenceNo(batch.ProtecolNo);
                    //if (!rd.Result) { return "批信息中数据格式有误"; }
                    //rd = DataCheckCenter.Instance.CheckPayerAccount(batch.Payer.Account);
                    //if (!rd.Result) { return "批信息中数据格式有误"; }
                    //rd = DataCheckCenter.Instance.CheckPayDatetime(batch.TransferDatetime);
                    //if (!rd.Result) { return "批信息中数据格式有误"; }
                    //rd = DataCheckCenter.Instance.CheckAddtion(batch.Addtion, 80);
                    //if (!rd.Result) { return "批信息中数据格式有误"; }
                    //if (AppliableFunctionType.AgentNormalOut :
                    //{
                    //    rd = DataCheckCenter.Instance.CheckLinkBankNo(batch.BankNo);
                    //    if (!rd.Result) { return "批信息中数据格式有误"; }
                    //}
                    //case AppliableFunctionType.AgentNormalIn :
                    //{
                    //    rd = DataCheckCenter.Instance.CheckUseType(batch.UseType);
                    //    if (!rd.Result) { return "批信息中数据格式有误"; }
                    //}
                    #endregion

                    foreach (var data in dataAEList)
                    {
                        rd = DataCheckCenter.Instance.CheckPayeeAccount(null, data.AccountNo, "", null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentExpressIn ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccount : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerAccount); break; }
                        rd = DataCheckCenter.Instance.CheckPayeeOrElecTicketPersonName(null, data.AccountName, "", 58, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentExpressIn ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeName : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerName); break; }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount, "", 14, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentExpressIn ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Amount : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_Amount); break; }

                        if (batchAE.BankType == AgentTransferBankType.Boc)
                        {
                            rd = DataCheckCenter.Instance.CheckProvince(null, ((int)data.Province).ToString(), null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentExpressIn ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeAccountProvince : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerAccountProvince); break; }
                        }
                        else if (batchAE.BankType == AgentTransferBankType.Other)
                        {
                            if (aft == AppliableFunctionType.AgentExpressOut4Bar)
                            {
                                if (null != data.BankName && !string.IsNullOrEmpty(data.BankName.Trim()))
                                {
                                    rd = DataCheckCenter.Instance.CheckClearBankName(null, data.BankName, "", 80, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankName); break; }
                                }
                                else { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankName); break; }
                                if (!string.IsNullOrEmpty(data.BankNo))
                                {
                                    rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.BankNo, "", null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankNo); break; }
                                }
                            }
                            else
                            {
                                rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.BankNo, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentExpressIn ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeOpenBankNoOrCNAPSNo : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerOpenBankNoOrCNAPSNo); break; }
                            }
                        }
                        if (data.CertifyPaperType != AgentExpressCertifyPaperType.Empty && string.IsNullOrEmpty(data.CertifyPaperTypeString))
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentExpressIn ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyCardType : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyCardType); break; }
                        if (!string.IsNullOrEmpty(data.CertifyPaperNo))
                        {
                            rd = DataCheckCenter.Instance.CheckCertifyCardNo(null, data.CertifyPaperNo, MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentExpressIn ? MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo : MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_PayerCertifyNo); break; }
                        }
                        if (aft == AppliableFunctionType.AgentExpressIn)
                        {
                            if (!string.IsNullOrEmpty(data.ProtecolNo))
                            {
                                rd = DataCheckCenter.Instance.CheckProtecolNo(null, data.ProtecolNo, "", 60, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentExpressIn_Mappings_SerialNo); break; }
                            }
                        }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.AgentNormalIn:
                case AppliableFunctionType.AgentNormalOut:
                    #region
                    List<object> tempAN = list as List<object>;
                    BatchHeader batchAN = tempAN[0] as BatchHeader;
                    List<AgentNormal> dataANList = tempAN[1] as List<AgentNormal>;
                    bool isIn = aft == AppliableFunctionType.AgentNormalIn;

                    #region 检验批信息
                    //ResultData rd = DataCheckCenter.Instance.CheckCustomerReferenceNo(batch.ProtecolNo);
                    //if (!rd.Result) { return "批信息中数据格式有误"; }
                    //rd = DataCheckCenter.Instance.CheckPayerAccount(batch.Payer.Account);
                    //if (!rd.Result) { return "批信息中数据格式有误"; }
                    //rd = DataCheckCenter.Instance.CheckAgentCardType(batch.CardType_Normal);
                    //if (!rd.Result) { return "批信息中数据格式有误"; }
                    //rd = DataCheckCenter.Instance.CheckAddtion(batch.Addtion, 80);
                    //if (!rd.Result) { return "批信息中数据格式有误"; }
                    //rd = DataCheckCenter.Instance.CheckPayFeeNo(batch.PayFeeNo, false);
                    //if (!rd.Result) { return "批信息中数据格式有误"; }
                    //if (AppliableFunctionType.AgentNormalOut :
                    //{
                    //    rd = DataCheckCenter.Instance.CheckUseType(batch.UseType, true);
                    //    if (!rd.Result) { return "批信息中数据格式有误"; }
                    //    rd = DataCheckCenter.Instance.CheckPayDatetime(batch.TransferDatetime);
                    //    if (!rd.Result) { return "批信息中数据格式有误"; }
                    //}
                    //case AppliableFunctionType.AgentNormalIn :
                    //{
                    //    rd = DataCheckCenter.Instance.CheckLinkBankNo(batch.BankNo);
                    //    if (!rd.Result) { return "批信息中数据格式有误"; }
                    //    rd = DataCheckCenter.Instance.CheckAgentCardType(batch.CardType_Normal);
                    //    if (!rd.Result) { return "批信息中数据格式有误"; }
                    //    rd = DataCheckCenter.Instance.CheckUseType(batch.UseType, false);
                    //    if (!rd.Result) { return "批信息中数据格式有误"; }
                    //}
                    #endregion

                    foreach (var data in dataANList)
                    {
                        if (batchAN.CardType == AgentCardType.OtherBankCard)
                        {
                            rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.BankNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentNormalIn ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeOpenBankNo : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerOpenBankNo); break; }
                        }
                        else
                        {
                            rd = DataCheckCenter.Instance.CheckLinkBankNo(null, data.BankNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentNormalIn ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeOpenBankNo : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerOpenBankNo); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckPayerAccount(null, data.AccountNo, 35, null);
                        if (!rd.Result)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentNormalIn ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeAccount : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerAccount); break; }
                        rd = DataCheckCenter.Instance.CheckPayeeName(null, data.AccountName, null);
                        if (!rd.Result)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentNormalIn ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeName : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerName); break; }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount, "", aft == AppliableFunctionType.AgentNormalIn ? 14 : 15, false, null);
                        if (!rd.Result)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentNormalIn ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Amount : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Amount); break; }
                        if (data.CertifyPaperType != AgentNormalCertifyPaperType.Empty && string.IsNullOrEmpty(data.CertifyPaperTypeString))
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentNormalIn ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeCertifyCardType : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyCardType); break; }
                        if (!string.IsNullOrEmpty(data.CertifyPaperNo))
                        {
                            rd = DataCheckCenter.Instance.CheckCertifyCardNo(null, data.CertifyPaperNo, MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft != AppliableFunctionType.AgentNormalIn ? MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_PayeeCertifyNo : MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_PayerCertifyNo); break; }
                        }
                        if (isIn)
                        {
                            rd = DataCheckCenter.Instance.CheckAddtion(null, data.UseType_In, 60, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_Usege); break; }
                            if (!string.IsNullOrEmpty(data.ProtecolNo))
                            {
                                rd = DataCheckCenter.Instance.CheckProtecolNo(null, data.ProtecolNo, "", 60, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentNormalIn_Mappings_SerialNo); break; }
                            }
                        }
                        else if (!isIn)
                        {
                            if (data.UseType != AgentNormalFunctionType.Empty)
                            {
                                if (string.IsNullOrEmpty(data.UseTypeString)) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Usege); break; }
                                else if (!string.IsNullOrEmpty(data.UseTypeString))
                                {
                                    if (batchAN.UseType.Equals("0") && data.UseType != AgentNormalFunctionType.A10) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Usege); break; }
                                    else if (batchAN.UseType.Equals("1") && (data.UseType == AgentNormalFunctionType.A10)) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Usege); break; }
                                }
                            }
                            else { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentNormalOut_Mappings_Usege); break; }
                        }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.ElecTicketRemit:
                    #region
                    List<ElecTicketRemit> dataERList = list as List<ElecTicketRemit>;
                    foreach (var data in dataERList)
                    {
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount, "", 18, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_Amount); break; }
                        if (data.CanChange == CanChangeType.Empty) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_CanChange); break; }
                        rd = DataCheckCenter.Instance.CheckPayDatetime(null, data.RemitDate, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_RemitDate); break; }
                        rd = DataCheckCenter.Instance.CheckEndDatetime(null, data.EndDate, data.RemitDate, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_EndDate, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_EndDate); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.ExchangeAccount, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeAccount); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.ExchangeName, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeName); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.ExchangeOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeOpenBankName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeOpenBankName); break; }
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.ExchangeOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_ExchangeOpenBankNo); break; }
                        if (!string.IsNullOrEmpty(data.Note))
                        {
                            rd = DataCheckCenter.Instance.CheckAddtion(null, data.Note, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_Note, 256, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_Note); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.PayeeAccount, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeAccount); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.PayeeName, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeName); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.PayeeOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeOpenBankName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeOpenBankName); break; }
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.PayeeOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_PayeeOpenBankNo); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.RemitAccount, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_RemitAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_RemitAccount); break; }
                        if (data.TicketType == ElecTicketType.Empty) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_Remit_Mappings_TicketType); break; }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.ElecTicketBackNote:
                    #region
                    List<ElecTicketBackNote> dataEBList = list as List<ElecTicketBackNote>;
                    foreach (var data in dataEBList)
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.BackNotedAccount, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedAccount); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.BackNotedName, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedName); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.BackNotedOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedOpenBankName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedOpenBankName); break; }
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.BackNotedOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_BackNotedOpenBankNo); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketSerialNo(null, data.ElecTicketSerialNo, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_TicketSerialNo, 30, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_TicketSerialNo); break; }
                        if (!string.IsNullOrEmpty(data.Note))
                        {
                            rd = DataCheckCenter.Instance.CheckAddtion(null, data.Note, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Note, 256, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Note); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.RemitAccount, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Account, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_BackNoted_Mappings_Account); break; }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.ElecTicketPayMoney:
                    #region
                    List<ElecTicketPayMoney> dataEPMList = list as List<ElecTicketPayMoney>;
                    foreach (var data in dataEPMList)
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.RemitAccount, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Account, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Account); break; }
                        if (!string.IsNullOrEmpty(data.BillSerialNo))
                        {
                            rd = DataCheckCenter.Instance.CheckBillSerialNo(null, data.BillSerialNo, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_BillSerialNo, 60, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_BillSerialNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ContractNo))
                        {
                            rd = DataCheckCenter.Instance.CheckContractNo(null, data.ContractNo, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ContactNo, 60, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ContactNo); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckElecTicketSerialNo(null, data.ElecTicketSerialNo, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_TicketSerialNo, 30, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_TicketSerialNo); break; }
                        if (!string.IsNullOrEmpty(data.Note))
                        {
                            rd = DataCheckCenter.Instance.CheckAddtion(null, data.Note, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Note, 512, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_Note); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.PayMoneyAccount, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyAccount); break; }
                        if (!string.IsNullOrEmpty(data.PayMoneyOpenBankName))
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.PayMoneyOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankName, 120, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankName); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.PayMoneyOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankNo); break; }
                        rd = DataCheckCenter.Instance.CheckPayDatetime(null, data.PayMoneyDate, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayDate, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayDate); break; }
                        rd = DataCheckCenter.Instance.CheckPayMoneyPercent(null, data.PayMoneyPercent.ToString(), MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyPercent, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyPercent); break; }
                        if (data.ProtocolMoneyType == ProtocolMoneyType.NegotiatedInterestPayment)
                        {
                            rd = DataCheckCenter.Instance.CheckProtocolPercent(null, data.ProtocolMoneyPercent.ToString(), MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ProtocolMoneyPercent, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_ProtocolMoneyPercent); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.StickOnAccount, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnccount); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.StickOnName, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnName); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.StickOnOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankName); break; }
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.StickOnOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankNo); break; }
                        if (data.StickOnOpenBankNo.StartsWith("104") && !data.PayMoneyOpenBankNo.StartsWith("104"))
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_StickOnOpenBankNo + "和" + MultiLanguageConvertHelper.Instance.ElecTicket_PayMoney_Mappings_PayMoneyOpenBankNo); break; }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.ElecTicketTipExchange:
                    #region
                    List<ElecTicketAutoTipExchange> dataETList = list as List<ElecTicketAutoTipExchange>;
                    foreach (var data in dataETList)
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.RemitAccount, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Account, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Account); break; }
                        if (!string.IsNullOrEmpty(data.BillSerialNo))
                        {
                            rd = DataCheckCenter.Instance.CheckBillSerialNo(null, data.BillSerialNo, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_BillSerialNo, 630, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_BillSerialNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ContractNo))
                        {
                            rd = DataCheckCenter.Instance.CheckContractNo(null, data.ContractNo, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ContactNo, 60, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ContactNo); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckElecTicketSerialNo(null, data.ElecTicketSerialNo, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_TicketSerialNo, 30, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_TicketSerialNo); break; }
                        if (!string.IsNullOrEmpty(data.ExchangeAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.ExchangeAccount, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeAccount, 32, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeAccount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ExchangeName))
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.ExchangeName, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeName, 120, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ExchangeOpenBankName))
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.ExchangeOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankName, 120, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankName); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ExchangeOpenBankNo))
                        {
                            rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.ExchangeOpenBankNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_ExchangeOpenBankNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Note))
                        {
                            rd = DataCheckCenter.Instance.CheckAddtion(null, data.Note, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Note, 512, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicket_AutoTipExchange_Mappings_Note); break; }
                        }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.ElecTicketPool:
                    #region
                    List<ElecTicketPool> dataEPList = list as List<ElecTicketPool>;
                    foreach (var data in dataEPList)
                    {
                        if (string.IsNullOrEmpty(data.ElecTicketTypeString))
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ElecTicketType); break; }
                        if (!string.IsNullOrEmpty(data.CustomerRef))
                        {
                            rd = DataCheckCenter.Instance.CheckCustomerRefNo(null, data.CustomerRef, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_CustomerRef); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckElecTicketSerialNo(null, data.ElecTicketSerialNo, MultiLanguageConvertHelper.Instance.ElecTicketPool_ElecTicketSerialNo, 30, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ElecTicketSerialNo); break; }
                        try { DateTime.Parse(data.RemitDate); }
                        catch { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitDate); break; }
                        try { DateTime.Parse(data.ExchangeDate); }
                        catch { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeDate); break; }
                        if (DateTime.Parse(data.RemitDate).Date > DateTime.Parse(data.ExchangeDate).Date)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeDate); break; }
                        try { DateTime.Parse(data.EndDate); }
                        catch { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDate); break; }
                        if (DateTime.Parse(data.RemitDate).Date > DateTime.Parse(data.EndDate).Date)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDate); break; }
                        if (DateTime.Parse(data.ExchangeDate).Date >= DateTime.Parse(data.EndDate).Date)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDate); break; }
                        if (DateTime.Parse(data.EndDate).Date > DateTime.Parse(data.RemitDate).AddMonths(6).Date)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_EndDate); break; }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount, "", 16, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_Amount); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.RemitAccount, MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitAccount); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.RemitName, MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_RemitName); break; }
                        if (data.ElecTicketType == ElecTicketType.AC01)
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.ExchangeName, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankName, 120, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankName); break; }
                            rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.ExchangeBankNo, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeBankNo); break; }
                        }
                        else if (data.ElecTicketType == ElecTicketType.AC02)
                        {
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.ExchangeAccount, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeAccount, 32, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeAccount); break; }
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.ExchangeName, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeName, 120, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeName); break; }
                            rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.ExchangeBankNo, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeOpenBankNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_ExchangeOpenBankNo); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccount(null, data.PayeeAccount, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeAccount, 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeAccount); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.PayeeName, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeName); break; }
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonNameOrBankName(null, data.PayeeOpenBankName, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankName, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankName); break; }
                        rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.PayeeOpenBankNo, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankNo, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_PayeeOpenBankNo); break; }
                        rd = DataCheckCenter.Instance.CheckPreBackNotedPerson(null, data.PreBackNotedPerson, MultiLanguageConvertHelper.Instance.ElecTicketPool_PreBackNotedPerson, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_PreBackNotedPerson); break; }
                        if (data.BusinessType == ElecTicketPoolBusinessType.Empty || (data.BusinessType != ElecTicketPoolBusinessType.InPool2Struste && data.ElecTicketType == ElecTicketType.AC02))
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.ElecTicketPool_BusinessType); break; }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.TransferOverCountry:
                case AppliableFunctionType.TransferForeignMoney:
                case AppliableFunctionType.TransferForeignMoney4Bar:
                case AppliableFunctionType.TransferOverCountry4Bar:
                    #region
                    List<TransferGlobal> dataTGList = list as List<TransferGlobal>;
                    foreach (var data in dataTGList)
                    {
                        if (!string.IsNullOrEmpty(data.PayDate))
                        {
                            rd = DataCheckCenter.Instance.CheckPayDatetime(null, data.PayDate, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayDate); break; }
                        }
                        if (aft == AppliableFunctionType.TransferOverCountry4Bar)
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.RemitAddress + data.RemitName, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName + "和" + MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress); break; }
                        }
                        //else if (AppliableFunctionType.TransferForeignMoney == aft
                        //|| AppliableFunctionType.TransferOverBankOut == aft)
                        //{ result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                        if (string.IsNullOrEmpty(data.PayFeeAccount))
                        {
                            if (aft == AppliableFunctionType.TransferForeignMoney || aft == AppliableFunctionType.TransferOverCountry)
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, string.Format("{0}、{1}和{2}必输其一", MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAccount)); break; }
                            else if (aft == AppliableFunctionType.TransferOverCountry4Bar)
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, string.Format("{0}和{1}必输其一", MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount)); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CustomerRef))
                        {
                            rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(null, data.CustomerRef, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CutomerRef); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.RemitAmount.ToString(), "", 15, data.PaymentCashType == CashType.JPY, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAmount); break; }
                        if (aft != AppliableFunctionType.TransferForeignMoney4Bar || (aft == AppliableFunctionType.TransferForeignMoney4Bar && !string.IsNullOrEmpty(data.PurchaseAccount)))
                        {
                            if (string.IsNullOrEmpty(data.SpotAccount) && string.IsNullOrEmpty(data.PurchaseAccount) && string.IsNullOrEmpty(data.OtherAccount))
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, "账户信息"); break; }
                            if ((string.IsNullOrEmpty(data.RemitAmount) ? 0 : Convert.ToDouble(data.RemitAmount.ToString())) != (string.IsNullOrEmpty(data.SpotAmount) ? 0 : Convert.ToDouble(data.SpotAmount.ToString())) + (string.IsNullOrEmpty(data.PurchaseAmount) ? 0 : Convert.ToDouble(data.PurchaseAmount.ToString())) + (string.IsNullOrEmpty(data.OtherAmount) ? 0 : Convert.ToDouble(data.OtherAmount.ToString())))
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, "金额信息"); break; }
                        }
                        if (!string.IsNullOrEmpty(data.SpotAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerAccount(null, data.SpotAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAccount); break; }
                            rd = DataCheckCenter.Instance.CheckCash(null, data.SpotAmount.ToString(), "", 15, data.PaymentCashType == CashType.JPY, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_SpotAmount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PurchaseAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerAccount(null, data.PurchaseAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAccount); break; }
                            rd = DataCheckCenter.Instance.CheckCash(null, data.PurchaseAmount.ToString(), "", 15, data.PaymentCashType == CashType.JPY, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PurchaseAmount); break; }
                        }
                        if (!string.IsNullOrEmpty(data.OtherAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerAccount(null, data.OtherAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAccount, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAccount); break; }
                            rd = DataCheckCenter.Instance.CheckCash(null, data.OtherAmount.ToString(), "", 15, data.PaymentCashType == CashType.JPY, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_OtherAmount); break; }
                        }
                        if (aft != AppliableFunctionType.TransferForeignMoney4Bar || (aft == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.OtherBankAccount))
                        {
                            rd = DataCheckCenter.Instance.CheckOrgCode(null, data.OrgCode, MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_OrgCode); break; }
                        }
                        if (!string.IsNullOrEmpty(data.PayeeOpenBankSwiftCode))
                        {
                            if (aft == AppliableFunctionType.TransferForeignMoney4Bar)
                                rd = DataCheckCenter.Instance.CheckSwiftCodeFMBar(null, data.PayeeOpenBankSwiftCode, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankSwiftCode, null);
                            else
                                rd = DataCheckCenter.Instance.CheckSwiftCode(null, data.PayeeOpenBankSwiftCode, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankSwiftCode, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankSwiftCode); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CorrespondentBankSwiftCode))
                        {
                            rd = DataCheckCenter.Instance.CheckSwiftCode(null, data.CorrespondentBankSwiftCode, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankSwiftCode, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankSwiftCode); break; }
                        }
                        if (aft == AppliableFunctionType.TransferOverCountry || aft == AppliableFunctionType.TransferOverCountry4Bar)
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.RemitName, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName); break; }
                            if (!string.IsNullOrEmpty(data.RemitAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.RemitAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress, 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckPayeeAccountGJ(null, data.PayeeAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount, 35, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount); break; }
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.PayeeName, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName); break; }
                            if (!string.IsNullOrEmpty(data.PayeeAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.PayeeAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress, 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(null, data.PayeeName, data.PayeeAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName + "和" + MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress); break; }
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.PayeeOpenBankName, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName); break; }
                            if (!string.IsNullOrEmpty(data.PayeeOpenBankSwiftCode))
                            {
                                rd = DataCheckCenter.Instance.CheckSwiftCode(null, data.PayeeOpenBankSwiftCode, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName); break; }
                            }
                            if (!string.IsNullOrEmpty(data.PayeeOpenBankAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.PayeeOpenBankAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress, 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(null, data.PayeeOpenBankName, data.PayeeOpenBankAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress, 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankName + "和" + MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress); break; }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankName))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.CorrespondentBankName, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName, 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName); break; }
                            }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.CorrespondentBankAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress, 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress); break; }
                            }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankName + data.CorrespondentBankAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(null, data.CorrespondentBankName, data.CorrespondentBankAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress, 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName + "和" + MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress); break; }
                            }
                            if (!string.IsNullOrEmpty(data.PayeeAccountInCorrespondentBank))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeAccountInCorrespondentBankGJ(null, data.PayeeAccountInCorrespondentBank, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank, 34, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank); break; }
                            }
                        }
                        else if (aft == AppliableFunctionType.TransferForeignMoney || aft == AppliableFunctionType.TransferForeignMoney4Bar)
                        {
                            if (aft == AppliableFunctionType.TransferForeignMoney)
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.RemitName, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName, 70, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitName); break; }
                            }
                            if (!string.IsNullOrEmpty(data.RemitAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.RemitAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress, aft == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.OtherBankAccount ? 64 : 70, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitAddress); break; }
                            }
                            if (data.PayeeOpenBankType == AccountBankType.Empty)
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankType); break; }
                            if (data.PayeeOpenBankType == AccountBankType.BocAccount)
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeAccountGJEx(null, data.PayeeAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount, 20, true, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount); break; }
                            }
                            else if (data.PayeeOpenBankType == AccountBankType.OtherBankAccount)
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeAccountGJEx(null, data.PayeeAccount, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount, 35, false, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccount); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeName, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName, aft == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.OtherBankAccount ? 64 : 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeName); break; }
                            if (!string.IsNullOrEmpty(data.PayeeAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress, aft == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.OtherBankAccount ? 64 : 70, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAddress); break; }
                            }
                            if (!string.IsNullOrEmpty(data.PayeeOpenBankAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeOpenBankAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress, 70, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeOpenBankAddress); break; }
                            }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankName))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.CorrespondentBankName, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName, 70, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankName); break; }
                            }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.CorrespondentBankAddress, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress, 70, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_CorrespondentBankAddress); break; }
                            }
                            if (!string.IsNullOrEmpty(data.PayeeAccountInCorrespondentBank))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeAccountInCorrespondentBankGJ(null, data.PayeeAccountInCorrespondentBank, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank, 70, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeAccountInCorrespondentBank); break; }
                            }
                        }
                        if (aft != AppliableFunctionType.TransferForeignMoney4Bar || (aft == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.OtherBankAccount))
                        {
                            if (string.IsNullOrEmpty(data.PayeeNameofCountry) || string.IsNullOrEmpty(data.PayeeCodeofCountry))
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, "收款人常驻国家信息"); break; }
                            rd = DataCheckCenter.Instance.CheckCountryName(null, data.PayeeCodeofCountry, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeNameofCountry, 30, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeNameofCountry); break; }
                            rd = DataCheckCenter.Instance.CheckCountryCode(null, data.PayeeCodeofCountry, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCodeofCountry, 3, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayeeCodeofCountry); break; }
                        }
                        else if (aft == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.BocAccount)
                        {
                            if (data.AgentFunctionType_Express == AgentExpressFunctionType.Empty)
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_Usage); break; }
                            if (data.CertifyPaperType != AgentExpressCertifyPaperType.Empty)
                            {
                                if (data.CertifyPaperType == AgentExpressCertifyPaperType.IDCard)
                                    rd = DataCheckCenter.Instance.CheckCertifyCardNo(null, data.CertifyPaperNo, "", true, null);
                                else
                                    rd = DataCheckCenter.Instance.CheckCertifyCardNo(null, data.CertifyPaperNo, "", null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.AgentExpressOut_Mappings_PayeeCertifyNo); break; }
                            }
                        }
                        if (!string.IsNullOrEmpty(data.RemitNote))
                        {
                            if (aft == AppliableFunctionType.TransferOverCountry
                               || aft == AppliableFunctionType.TransferOverCountry4Bar)
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.RemitNote, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote, 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote); break; }
                            }
                            else if (aft == AppliableFunctionType.TransferForeignMoney
                                || aft == AppliableFunctionType.TransferForeignMoney4Bar)
                            {
                                if (aft != AppliableFunctionType.TransferForeignMoney4Bar || (aft == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.OtherBankAccount))
                                {
                                    rd = DataCheckCenter.Instance.CheckAddtion(null, data.RemitNote, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote, aft == AppliableFunctionType.TransferForeignMoney4Bar ? 140 : 50, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_RemitNote); break; }
                                }
                            }
                        }
                        if (aft != AppliableFunctionType.TransferForeignMoney4Bar || (aft == AppliableFunctionType.TransferForeignMoney4Bar && data.PayeeOpenBankType == AccountBankType.OtherBankAccount))
                        {
                            if (string.IsNullOrEmpty(data.AssumeFeeTypeString))
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_AssumeFeeType); break; }
                            if (aft != AppliableFunctionType.TransferForeignMoney4Bar || (aft == AppliableFunctionType.TransferForeignMoney4Bar && !string.IsNullOrEmpty(data.PayFeeAccount)))
                            {
                                if (string.IsNullOrEmpty(data.PayFeeAccount))
                                { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PayFeeAccount); break; }
                            }
                            if (aft == AppliableFunctionType.TransferForeignMoney)
                            {
                                if (string.IsNullOrEmpty(data.PaymentPropertyTypeString))
                                { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_PaymentPropertyType); break; }
                            }
                            if (aft == AppliableFunctionType.TransferForeignMoney)
                            {
                                if (string.IsNullOrEmpty(data.DealSerialNoF) && string.IsNullOrEmpty(data.DealSerialNoS))
                                { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, "交易编码信息"); break; }
                            }
                            if (!string.IsNullOrEmpty(data.DealSerialNoF))
                            {
                                rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.DealSerialNoF, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF, 6, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoF); break; }
                                rd = DataCheckCenter.Instance.CheckCash(null, data.AmountF.ToString(), "", 15, data.PaymentCashType == CashType.JPY, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_AmountF); break; }
                                if (aft == AppliableFunctionType.TransferOverCountry || aft == AppliableFunctionType.TransferOverCountry4Bar)
                                {
                                    rd = DataCheckCenter.Instance.CheckAddtionExIAOrUP(null, data.DealNoteF, MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteF, aft == AppliableFunctionType.TransferOverCountry ? 100 : 50, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteF); break; }
                                }
                            }
                            if (!string.IsNullOrEmpty(data.DealSerialNoS))
                            {
                                rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.DealSerialNoS, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS, 6, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_DealSerialNoS); break; }
                                rd = DataCheckCenter.Instance.CheckCash(null, data.AmountS.ToString(), "", 15, data.PaymentCashType == CashType.JPY, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_AmountS); break; }
                                if (aft == AppliableFunctionType.TransferOverCountry || aft == AppliableFunctionType.TransferOverCountry4Bar)
                                {
                                    rd = DataCheckCenter.Instance.CheckAddtionExIAOrUP(null, data.DealNoteS, MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteS, aft == AppliableFunctionType.TransferOverCountry ? 100 : 50, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_DealNoteS); break; }
                                }
                            }
                            //if (data.IsPayOffLine)
                            //{
                            //    if (string.IsNullOrEmpty(data.ContactNo))
                            //    { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                            //    if (string.IsNullOrEmpty(data.BillSerialNo))
                            //    { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                            //    if (string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo))
                            //    { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                            //}
                            if (!string.IsNullOrEmpty(data.ContactNo))
                            {
                                rd = DataCheckCenter.Instance.CheckSerialNoEx(null, data.ContactNo, MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo, 20, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_ContactNo); break; }
                            }
                            if (!string.IsNullOrEmpty(data.BillSerialNo))
                            {
                                rd = DataCheckCenter.Instance.CheckSerialNoEx(null, data.BillSerialNo, MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo, aft == AppliableFunctionType.TransferForeignMoney ? 20 : aft == AppliableFunctionType.TransferOverCountry ? 50 : 35, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_BillSerialNo); break; }
                            }
                            if (!string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo))
                            {
                                rd = DataCheckCenter.Instance.CheckSerialNoEx(null, data.BatchNoOrTNoOrSerialNo, MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo, 20, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_BatchNoOrTNoOrSerialNo); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckProposerName(null, data.ProposerName, MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName, 20, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_ProposerName); break; }
                            rd = DataCheckCenter.Instance.CheckTelePhone(null, data.Telephone, MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone, 20, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.TransferGlobal_Telephone); break; }
                        }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.InitiativeAllot:
                    #region
                    List<object> temp = list as List<object>;
                    BatchHeader batch = temp[0] as BatchHeader;
                    List<InitiativeAllot> dataList = temp[1] as List<InitiativeAllot>;

                    foreach (var data in dataList)
                    {
                        rd = DataCheckCenter.Instance.CheckAccountExIA(null, data.AccountOut.Trim(), MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountOut, 22, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountOut); break; }
                        if (!string.IsNullOrEmpty(data.NameOut))
                        {
                            rd = DataCheckCenter.Instance.CheckNameExIA(null, data.NameOut.Trim(), MultiLanguageConvertHelper.Instance.InitiativeAllot_NameOut, 76, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.InitiativeAllot_NameOut); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckAccountExIA(null, data.AccountIn.Trim(), MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountIn, 22, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.InitiativeAllot_AccountIn); break; }
                        if (!string.IsNullOrEmpty(data.NameIn))
                        {
                            rd = DataCheckCenter.Instance.CheckNameExIA(null, data.NameIn.Trim(), MultiLanguageConvertHelper.Instance.InitiativeAllot_NameIn, 76, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.InitiativeAllot_NameIn); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount.ToString().Trim(), MultiLanguageConvertHelper.Instance.InitiativeAllot_Amount, 14, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.InitiativeAllot_Amount); break; }
                        if (!string.IsNullOrEmpty(data.Addition))
                        {
                            rd = DataCheckCenter.Instance.CheckAddtionExIAOrUP(null, data.Addition.Trim(), MultiLanguageConvertHelper.Instance.InitiativeAllot_Addition, 200, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.InitiativeAllot_Addition); break; }
                        }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.ApplyofFranchiserFinancing:
                    #region
                    List<SpplyFinancingApply> dataSFList = list as List<SpplyFinancingApply>;
                    foreach (var data in dataSFList)
                    {
                        rd = DataCheckCenter.Instance.CheckContractOrOrderNo(null, data.ContractOrOrderNo, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ContractOrOrderNo, 70, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ContractOrOrderNo); break; }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.ContractOrOrderAmount, "", 15, data.ContractOrOrderCashType == CashType.JPY, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_OrderAmount); break; }
                        if (!string.IsNullOrEmpty(data.TaxInvoiceNo))
                        {
                            rd = DataCheckCenter.Instance.CheckTaxBillSerialNo(null, data.TaxInvoiceNo, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_TaxInvoiceNo, 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_TaxInvoiceNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ReceiptNo))
                        {
                            rd = DataCheckCenter.Instance.CheckReceiptNo(null, data.ReceiptNo, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ReceiptNo, 40, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ReceiptNo); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckRiskTakingLetterNo(null, data.RiskTakingLetterNo, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_RiskTakingLetterNo, 70, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_RiskTakingLetterNo); break; }
                        if (!string.IsNullOrEmpty(data.GoodsDesc))
                        {
                            rd = DataCheckCenter.Instance.CheckGoodsDesc(null, data.GoodsDesc, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_GoodsDesc, 600, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_GoodsDesc); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.ApplyAmount, "", 15, data.ContractOrOrderCashType == CashType.JPY, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ApplyAmount); break; }
                        rd = DataCheckCenter.Instance.CheckApplyDays(null, data.ApplyDays.ToString(), MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ApplyDays, 4, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_ApplyDays); break; }
                        if (!string.IsNullOrEmpty(data.AgreementNo))
                        {
                            rd = DataCheckCenter.Instance.CheckAgrementNo(null, data.AgreementNo, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_AgrementNo, 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_AgrementNo); break; }
                        }
                        if (data.InterestFloatType == InterestFloatType.Empty)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_InterestFloatType); break; }
                        if (data.InterestFloatType != InterestFloatType.No)
                        {
                            rd = DataCheckCenter.Instance.CheckInterestFloatingPercent(null, data.InterestFloatingPercent, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_InterestFloatingPercent, 12, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_InterestFloatingPercent); break; }
                        }
                        else if (data.InterestFloatType == InterestFloatType.No && data.InterestFloatingPercent != "0")
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingApply_InterestFloatingPercent); break; }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.PurchaserOrder:
                case AppliableFunctionType.SellerOrder:
                    #region
                    List<SpplyFinancingOrder> dataSFOList = list as List<SpplyFinancingOrder>;
                    foreach (var data in dataSFOList)
                    {
                        rd = DataCheckCenter.Instance.CheckOrderNo(null, data.OrderNo, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo, 70, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo); break; }
                        if (data.CashType == CashType.Empty)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CashType); break; }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount.ToString(), "", 15, data.CashType == CashType.JPY, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_Amount); break; }
                        if (aft == AppliableFunctionType.PurchaserOrder)
                        {
                            if (string.IsNullOrEmpty(data.ERPCode) && string.IsNullOrEmpty(data.CustomerApplyNo))
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_ERPCode_Seller + "和" + MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerNo_Seller); break; }
                            if (!string.IsNullOrEmpty(data.ERPCode))
                            {
                                rd = DataCheckCenter.Instance.CheckERPCode(null, data.ERPCode, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_ERPCode_Seller, 40, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_ERPCode_Seller); break; }
                            }
                            if (!string.IsNullOrEmpty(data.CustomerApplyNo))
                            {
                                rd = DataCheckCenter.Instance.CheckBankCustomerNo(null, data.CustomerApplyNo, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerNo_Seller, 40, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerNo_Seller); break; }
                            }
                        }
                        else if (aft == AppliableFunctionType.SellerOrder)
                        {
                            rd = DataCheckCenter.Instance.CheckCustomerNamePurchase(null, data.CustomerName, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerName_Purchase, 80, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_CustomerName_Purchase); break; }
                        }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.PurchaserOrderMgr:
                case AppliableFunctionType.SellerOrderMgr:
                    #region
                    List<SpplyFinancingOrder> dataSFOMList = list as List<SpplyFinancingOrder>;
                    foreach (var data in dataSFOMList)
                    {
                        rd = DataCheckCenter.Instance.CheckOrderNo(null, data.OrderNo, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo, 70, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_OrderNo); break; }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount, "", 15, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingOrder_Amount); break; }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                case AppliableFunctionType.BillofDebtReceivableSeller:
                    #region
                    List<SpplyFinancingBill> dataSFBList = list as List<SpplyFinancingBill>;
                    foreach (var data in dataSFBList)
                    {
                        if (!string.IsNullOrEmpty(data.BillSerialNo))
                        {
                            rd = DataCheckCenter.Instance.CheckBillSerialNoSF(null, data.BillSerialNo.Trim(), MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillSerialNo, 20, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingBill_BillSerialNo); break; }
                        }
                        if (!string.IsNullOrEmpty(data.ContractNo))
                        {
                            rd = DataCheckCenter.Instance.CheckContractNoEx(null, data.ContractNo.Trim(), MultiLanguageConvertHelper.Instance.SpplyFinancingBill_ContractNo, 40, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingBill_ContractNo); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckBankCustomerNo(null, data.CustomerNo.Trim(), aft == AppliableFunctionType.BillofDebtReceivableSeller ? MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Purchase : MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Seller, 16, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.BillofDebtReceivableSeller ? MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Purchase : MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerNo_Seller); break; }
                        rd = DataCheckCenter.Instance.CheckCustomerName(null, data.CustomerName.Trim(), aft == AppliableFunctionType.BillofDebtReceivableSeller ? MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Purchase : MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Seller, 80, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, aft == AppliableFunctionType.BillofDebtReceivableSeller ? MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Purchase : MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CustomerName_Seller); break; }
                        if (data.CashType == CashType.Empty)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingBill_CashType); break; }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount, "", 15, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingBill_Amount); break; }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                    #region
                    List<SpplyFinancingPayOrReceipt> dataSFPRList = list as List<SpplyFinancingPayOrReceipt>;
                    foreach (var data in dataSFPRList)
                    {
                        if (!string.IsNullOrEmpty(data.BillSerialNo))
                        {
                            rd = DataCheckCenter.Instance.CheckBillSerialNoSF(null, data.BillSerialNo.Trim(), MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_BillSerialNo, 20, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_BillSerialNo); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckBankCustomerNo(null, data.CustomerNo, MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerNo, 16, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerNo); break; }
                        rd = DataCheckCenter.Instance.CheckCustomerName(null, data.CustomerName.Trim(), MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerName, 80, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CustomerName); break; }
                        if (data.CashType == CashType.Empty) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_CashType); break; }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.PayAmountForThisTime.ToString(), "", 17, data.CashType == CashType.JPY, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.SpplyFinancingPayOrReceipt_AmountThisTime); break; }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.UnitivePaymentRMB:
                    #region
                    List<UnitivePaymentRMB> dataUPRMBList = list as List<UnitivePaymentRMB>;
                    foreach (var data in dataUPRMBList)
                    {
                        rd = DataCheckCenter.Instance.CheckPayerAccountUP(null, data.PayerAccount, "", 12, 18, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayerAccount); break; }
                        if (!string.IsNullOrEmpty(data.PayerName))
                        {
                            rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.PayerName, "", 200, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayerName); break; }
                        }
                        rd = DataCheckCenter.Instance.CheckPayeeAccountUP(null, data.PayeeAccount, "", 32, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeAccount); break; }
                        rd = DataCheckCenter.Instance.CheckPayeeNameAgentInOrUP(null, data.PayeeName, "", 76, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeName); break; }
                        if (data.BankType == AccountBankType.OtherBankAccount)
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeOpenBankName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeOpenBankName); break; }
                            if (!string.IsNullOrEmpty(data.PayeeCNAPS))
                            {
                                rd = DataCheckCenter.Instance.CheckCNAPSNo(null, data.PayeeCNAPS, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_PayeeCNAPS); break; }
                            }
                        }
                        rd = DataCheckCenter.Instance.CheckAccountUP(null, data.NominalPayerAccount, "", 35, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_NominalPayerAccount); break; }
                        rd = DataCheckCenter.Instance.CheckPayeeNameAgentInOrUP(null, data.NominalPayerName, "", 76, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_NominalPayerName); break; }
                        //rd = DataCheckCenter.Instance.CheckLinkBankNo(null, data.NominalPayerBankLinkNo, "", null);
                        //if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                        //rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.NominalPayerOpenBankName, "", 160, null);
                        //if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount.ToString(), "", 15, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_Amount); break; }
                        if (!string.IsNullOrEmpty(data.Purpose))
                        {
                            rd = DataCheckCenter.Instance.CheckAddtionExIAOrUP(null, data.Purpose, "", 200, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_Purpose); break; }
                        }
                        if (data.UnitivePaymentType == UnitivePaymentType.Empty)
                        { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_UnitivePaymentType); break; }
                        if (!string.IsNullOrEmpty(data.CustomerBusinissNo))
                        {
                            rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(null, data.CustomerBusinissNo, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_CustomerBusinissNo); break; }
                        }
                        if (data.IsTipPayee || (!data.IsTipPayee && !string.IsNullOrEmpty(data.TipPayeePhone)))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeePhone(null, data.TipPayeePhone, 11, 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentRMB_TipPayeePhone); break; }
                        }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.UnitivePaymentFC:
                    #region
                    List<UnitivePaymentForeignMoney> dataUPFCList = list as List<UnitivePaymentForeignMoney>;
                    foreach (var data in dataUPFCList)
                    {
                        if (data.PayeeAccountType == OverCountryPayeeAccountType.BocAccount)
                        {
                            #region
                            if (!string.IsNullOrEmpty(data.PayerAccount))
                            {
                                rd = DataCheckCenter.Instance.CheckPayerAccountUP(null, data.PayerAccount, "", 12, 18, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerAccount); break; }
                            }
                            if (!string.IsNullOrEmpty(data.PayerName))
                            {
                                rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.PayerName, "", 200, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerName); break; }
                            }
                            if (!string.IsNullOrEmpty(data.NominalPayerAccount))
                            {
                                rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(null, data.NominalPayerAccount, "", 35, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerAccount); break; }
                            }
                            if (!string.IsNullOrEmpty(data.NominalPayerName))
                            {
                                rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.NominalPayerName, "", 200, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerName); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(null, data.PayeeAccount, "", 35, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccount); break; }
                            rd = DataCheckCenter.Instance.CheckPayeeNameAgentInOrUP(null, data.PayeeName, "", 240, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeName); break; }
                            if (string.IsNullOrEmpty(data.CodeofCountry))
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CodeofCountry); break; }
                            if (!string.IsNullOrEmpty(data.CustomerBusinissNo))
                            {
                                rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(null, data.CustomerBusinissNo, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CustomerBusinissNo); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckCash(null, Convert.ToDouble(data.Amount), 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Amount); break; }
                            if (!string.IsNullOrEmpty(data.Addtion))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeAddtion(null, data.Addtion, "", 120, true, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Addtion); break; }
                            }
                            if (!string.IsNullOrEmpty(data.TransactionCode1))
                            {
                                rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.TransactionCode1, "", 6, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode1); break; }
                                if (string.IsNullOrEmpty(data.IPPSMoneyTypeAmount1))
                                { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1); break; }
                                else
                                {
                                    rd = DataCheckCenter.Instance.CheckCash(null, data.IPPSMoneyTypeAmount1, "", 15, data.CashType == CashType.JPY, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1); break; }
                                }
                            }
                            if (!string.IsNullOrEmpty(data.TransactionCode2))
                            {
                                rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.TransactionCode2, "", 6, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode2); break; }
                                if (string.IsNullOrEmpty(data.IPPSMoneyTypeAmount2))
                                { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2); break; }
                                else
                                {
                                    rd = DataCheckCenter.Instance.CheckCash(null, data.IPPSMoneyTypeAmount2, "", 15, data.CashType == CashType.JPY, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2); break; }
                                }
                            }
                            if (!string.IsNullOrEmpty(data.ContractNo))
                            {
                                rd = DataCheckCenter.Instance.CheckLength(null, data.ContractNo, "", 20, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ContractNo); break; }
                            }
                            if (!string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo))
                            {
                                rd = DataCheckCenter.Instance.CheckLength(null, data.BatchNoOrTNoOrSerialNo, "", 20, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_BatchNoOrTNoOrSerialNo); break; }
                            }
                            if (!string.IsNullOrEmpty(data.InvoiceNo))
                            {
                                rd = DataCheckCenter.Instance.CheckBillSerialNoSF(null, data.InvoiceNo, "", 50, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_InvoiceNo); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckProposerName(null, data.ApplicantName, "", 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ApplicantName); break; }
                            rd = DataCheckCenter.Instance.CheckTelePhone(null, data.Contactnumber, "", 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Contactnumber); break; }
                            #endregion
                        }
                        else if (data.PayeeAccountType == OverCountryPayeeAccountType.OtherAccount)
                        {
                            #region
                            if (!string.IsNullOrEmpty(data.PayerAccount))
                            {
                                rd = DataCheckCenter.Instance.CheckPayerAccountUP(null, data.PayerAccount, "", 12, 18, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerAccount); break; }
                            }
                            if (!string.IsNullOrEmpty(data.PayerName))
                            {
                                rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.PayerName, "", 200, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerName); break; }
                            }
                            if (!string.IsNullOrEmpty(data.NominalPayerAccount))
                            {
                                rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(null, data.NominalPayerAccount, "", 35, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerAccount); break; }
                            }
                            if (!string.IsNullOrEmpty(data.NominalPayerName))
                            {
                                rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.NominalPayerName, "", 200, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerName); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(null, data.PayeeAccount, "", 35, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccount); break; }
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeName, "", 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeName); break; }
                            if (!string.IsNullOrEmpty(data.Address))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.Address, "", 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Address); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeOpenBankName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankName); break; }
                            if (!string.IsNullOrEmpty(data.PayeeOpenBankSwiftCode))
                            {
                                rd = DataCheckCenter.Instance.CheckSwiftCode(null, data.PayeeOpenBankSwiftCode, "", null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankSwiftCode); break; }
                            }
                            if (!string.IsNullOrEmpty(data.OpenBankAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.OpenBankAddress, "", 70, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OpenBankAddress); break; }
                            }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankName))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.CorrespondentBankName, "", 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankName); break; }
                            }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankSwiftCode))
                            {
                                rd = DataCheckCenter.Instance.CheckSwiftCode(null, data.CorrespondentBankSwiftCode, "", null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankSwiftCode); break; }
                            }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckCountryName(null, data.CorrespondentBankAddress, "", 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankAddress); break; }
                            }
                            if (!string.IsNullOrEmpty(data.PayeeAccountInCorrespondentBank))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeAccountInCorrespondentBankGJ(null, data.PayeeAccountInCorrespondentBank, "", 35, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccountInCorrespondentBank); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(null, data.PayeeName, data.Address, "", "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeName + "和" + MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Address); break; }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankName) || !string.IsNullOrEmpty(data.CorrespondentBankAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(null, data.CorrespondentBankName, data.CorrespondentBankAddress, "", "", 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankName + "和" + MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankAddress); break; }
                            }
                            if (string.IsNullOrEmpty(data.CodeofCountry))
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CodeofCountry); break; }
                            rd = DataCheckCenter.Instance.CheckCash(null, Convert.ToDouble(data.Amount), 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CashType); break; }
                            rd = DataCheckCenter.Instance.CheckOrgCode(null, data.OrgCode, "", null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OrgCode); break; }
                            if (!string.IsNullOrEmpty(data.CustomerBusinissNo))
                            {
                                rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(null, data.CustomerBusinissNo, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CustomerBusinissNo); break; }
                            }
                            if (!string.IsNullOrEmpty(data.realPayAddress))
                            {
                                rd = DataCheckCenter.Instance.ChecktbRemittorAddress(null, data.realPayAddress, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_realPayAddress); break; }
                            }
                            if (!string.IsNullOrEmpty(data.Addtion))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeAddtion(null, data.Addtion, "", 120, false, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Addtion); break; }
                            }
                            if (!string.IsNullOrEmpty(data.TransactionCode1))
                            {
                                rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.TransactionCode1, "", 6, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode1); break; }
                                if (string.IsNullOrEmpty(data.IPPSMoneyTypeAmount1))
                                { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1); break; }
                                else
                                {
                                    rd = DataCheckCenter.Instance.CheckCash(null, data.IPPSMoneyTypeAmount1, "", 15, data.CashType == CashType.JPY, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1); break; }
                                }
                            }
                            if (!string.IsNullOrEmpty(data.TransactionCode2))
                            {
                                rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.TransactionCode2, "", 6, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode2); break; }
                                if (string.IsNullOrEmpty(data.IPPSMoneyTypeAmount2))
                                { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2); break; }
                                else
                                {
                                    rd = DataCheckCenter.Instance.CheckCash(null, data.IPPSMoneyTypeAmount2, "", 15, data.CashType == CashType.JPY, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2); break; }
                                }
                            }
                            if (!string.IsNullOrEmpty(data.ContractNo))
                            {
                                rd = DataCheckCenter.Instance.CheckLength(null, data.ContractNo, "", 20, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ContractNo); break; }
                            }
                            if (!string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo))
                            {
                                rd = DataCheckCenter.Instance.CheckLength(null, data.BatchNoOrTNoOrSerialNo, "", 40, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_BatchNoOrTNoOrSerialNo); break; }
                            }
                            if (!string.IsNullOrEmpty(data.InvoiceNo))
                            {
                                rd = DataCheckCenter.Instance.CheckLength(null, data.InvoiceNo, "", 35, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_InvoiceNo); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckProposerName(null, data.ApplicantName, "", 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ApplicantName); break; }
                            rd = DataCheckCenter.Instance.CheckTelePhone(null, data.Contactnumber, "", 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Contactnumber); break; }
                            #endregion
                        }
                        else if (data.PayeeAccountType == OverCountryPayeeAccountType.ForeignAccount)
                        {
                            #region
                            if (!string.IsNullOrEmpty(data.PayerAccount))
                            {
                                rd = DataCheckCenter.Instance.CheckPayerAccountUP(null, data.PayerAccount, "", 12, 18, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerAccount); break; }
                            }
                            if (!string.IsNullOrEmpty(data.PayerName))
                            {
                                rd = DataCheckCenter.Instance.CheckPayerNameOrBankNameUP(null, data.PayerName, "", 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayerName); break; }
                            }
                            if (!string.IsNullOrEmpty(data.NominalPayerAccount))
                            {
                                rd = DataCheckCenter.Instance.CheckAccountUP(null, data.NominalPayerAccount, "", 35, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerAccount); break; }
                            }
                            if (!string.IsNullOrEmpty(data.NominalPayerName))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.NominalPayerName, "", 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_NominalPayerName); break; }

                            }
                            if (data.PaymentCountryOrArea == Transfer2CountryType.Empty)
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PaymentCountryOrArea); break; }
                            if (data.FCPayeeAccountType == UnitiveFCPayeeAccountType.Empty)
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, "收款人账户类型"); break; }
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.PayeeAccount, "", 34, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccount); break; }
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.PayeeName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeName); break; }
                            if (!string.IsNullOrEmpty(data.Address))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.Address, "", 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Address); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.PayeeOpenBankName, "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankName); break; }
                            if (!string.IsNullOrEmpty(data.PayeeOpenBankSwiftCode))
                            {
                                rd = DataCheckCenter.Instance.CheckSwiftCodeFC(null, data.PayeeOpenBankSwiftCode, "", null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeOpenBankSwiftCode); break; }
                            }
                            if (!string.IsNullOrEmpty(data.OpenBankAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.OpenBankAddress, "", 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OpenBankAddress); break; }
                            }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankName))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJ(null, data.CorrespondentBankName, "", 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankName); break; }
                            }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankSwiftCode))
                            {
                                rd = DataCheckCenter.Instance.CheckSwiftCodeFC(null, data.CorrespondentBankSwiftCode, "", null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankSwiftCode); break; }
                            }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckCountryName(null, data.CorrespondentBankAddress, "", 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankAddress); break; }
                            }
                            if (!string.IsNullOrEmpty(data.PayeeAccountInCorrespondentBank))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeAccountInCorrespondentBankGJ(null, data.PayeeAccountInCorrespondentBank, "", 35, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeAccountInCorrespondentBank); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(null, data.PayeeName, data.Address, "", "", 140, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_PayeeName + " 和" + MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Address); break; }
                            if (!string.IsNullOrEmpty(data.CorrespondentBankName) || !string.IsNullOrEmpty(data.CorrespondentBankAddress))
                            {
                                rd = DataCheckCenter.Instance.CheckNameAndAddressLengthGJ(null, data.CorrespondentBankName, data.CorrespondentBankAddress, "", "", 140, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankName + "和" + MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CorrespondentBankAddress); break; }
                            }
                            if (string.IsNullOrEmpty(data.CodeofCountry))
                            { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CodeofCountry); break; }
                            rd = DataCheckCenter.Instance.CheckCash(null, Convert.ToDouble(data.Amount), 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Amount); break; }
                            rd = DataCheckCenter.Instance.CheckOrgCode(null, data.OrgCode, "", null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_OrgCode); break; }
                            if (!string.IsNullOrEmpty(data.CustomerBusinissNo))
                            {
                                rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(null, data.CustomerBusinissNo, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_CustomerBusinissNo); break; }
                            }
                            if (!string.IsNullOrEmpty(data.realPayAddress))
                            {
                                rd = DataCheckCenter.Instance.ChecktbRemittorAddress(null, data.realPayAddress, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_realPayAddress); break; }
                            }
                            if (!string.IsNullOrEmpty(data.Addtion))
                            {
                                rd = DataCheckCenter.Instance.CheckAddtionFCForeign(null, data.Addtion, "", 120, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Addtion); break; }
                            }
                            if (!string.IsNullOrEmpty(data.TransactionCode1))
                            {
                                rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.TransactionCode1, "", 6, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode1); break; }
                                if (string.IsNullOrEmpty(data.IPPSMoneyTypeAmount1))
                                { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1); break; }
                                else
                                {
                                    rd = DataCheckCenter.Instance.CheckCash(null, data.IPPSMoneyTypeAmount1, "", 15, data.CashType == CashType.JPY, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount1); break; }
                                }
                                if (string.IsNullOrEmpty(data.TransactionAddtion1))
                                { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion1); break; }
                                else
                                {
                                    rd = DataCheckCenter.Instance.CheckAddtionFCForeign(null, data.TransactionAddtion1, "", 50, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion1); break; }
                                }
                            }
                            if (!string.IsNullOrEmpty(data.TransactionCode2))
                            {
                                rd = DataCheckCenter.Instance.CheckDealSerialNo(null, data.TransactionCode2, "", 6, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionCode2); break; }
                                if (string.IsNullOrEmpty(data.IPPSMoneyTypeAmount2))
                                { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2); break; }
                                else
                                {
                                    rd = DataCheckCenter.Instance.CheckCash(null, data.IPPSMoneyTypeAmount2, "", 15, data.CashType == CashType.JPY, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_IPPSMoneyTypeAmount2); break; }
                                }
                                if (string.IsNullOrEmpty(data.TransactionAddtion2))
                                { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion2); break; }
                                else
                                {
                                    rd = DataCheckCenter.Instance.CheckAddtionFCForeign(null, data.TransactionAddtion2, "", 50, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_TransactionAddtion2); break; }
                                }
                            }
                            if (!string.IsNullOrEmpty(data.ContractNo))
                            {
                                rd = DataCheckCenter.Instance.CheckLength(null, data.ContractNo, "", 20, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ContractNo); break; }
                            }
                            if (!string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo))
                            {
                                rd = DataCheckCenter.Instance.CheckLength(null, data.BatchNoOrTNoOrSerialNo, "", 20, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_BatchNoOrTNoOrSerialNo); break; }
                            }
                            if (!string.IsNullOrEmpty(data.InvoiceNo))
                            {
                                rd = DataCheckCenter.Instance.CheckPayeeNameOrAddressGJEx(null, data.InvoiceNo, "", 50, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_InvoiceNo); break; }
                            }
                            rd = DataCheckCenter.Instance.CheckProposerName(null, data.ApplicantName, "", 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_ApplicantName); break; }
                            rd = DataCheckCenter.Instance.CheckTelePhone(null, data.Contactnumber, "", 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count, MultiLanguageConvertHelper.Instance.UnitivePaymentFC_Contactnumber); break; }
                            #endregion
                        }
                        count++;
                    }
                    #endregion
                    break;
                case AppliableFunctionType.VirtualAccountTransfer:
                    #region
                    List<VirtualAccount> dataListV = list as List<VirtualAccount>;
                    foreach (var data in dataListV)
                    {
                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(null, data.AccountOut.Trim(), MultiLanguageConvertHelper.Instance.Virtual_AccountOut, 35, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }

                        rd = DataCheckCenter.Instance.CheckVirtualAccountName(null, data.NameOut.Trim(), MultiLanguageConvertHelper.Instance.Virtual_NameOut, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }

                        rd = DataCheckCenter.Instance.CheckElecTicketPersonAccountFC(null, data.AccountIn.Trim(), MultiLanguageConvertHelper.Instance.Virtual_AccountIn, 35, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }

                        rd = DataCheckCenter.Instance.CheckVirtualAccountName(null, data.NameIn.Trim(), MultiLanguageConvertHelper.Instance.Virtual_NameIn, 120, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }

                        rd = DataCheckCenter.Instance.CheckCash(null, data.Amount.ToString().Trim(), MultiLanguageConvertHelper.Instance.Virtual_Amount, 14, false, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }
                        if (!string.IsNullOrEmpty(data.Purpose))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeAddtion(null, data.Purpose.Trim(), MultiLanguageConvertHelper.Instance.Virtual_Pursion, 200, false, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }
                        }
                        if (!string.IsNullOrEmpty(data.CustomerBusinissNo))
                        {
                            rd = DataCheckCenter.Instance.CheckCustomerRefNoGJOrUPEx(null, data.CustomerBusinissNo.Trim(), null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_SomeInvalidData_InRow, count); break; }
                        }
                        count++;
                    }
                    #endregion
                    break;
            }
            return result;
        }

        public string CheckDataAvilidHigh(object list, FunctionInSettingType fst)
        {
            int count = 1;
            string result = string.Empty;
            switch (fst)
            {
                case FunctionInSettingType.PayeeMg:
                    #region
                    List<PayeeInfo> dataList = list as List<PayeeInfo>;
                    foreach (var data in dataList)
                    {
                        ResultData rd = DataCheckCenter.Instance.CheckSerialNoGJ(null, data.SerialNo, "", 10, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count,MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_SerialNo); break; }
                        rd = DataCheckCenter.Instance.CheckPayeeAccount(null, data.Account, "", null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count,MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Account); break; }
                        rd = DataCheckCenter.Instance.CheckPayeeOrElecTicketPersonName(null, data.Name, "", 76, null);
                        if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count,MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Name); break; }
                        //if (data.CertifyPaperType == AgentExpressCertifyPaperType.Empty)
                        //{ result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count); break; }
                        if (data.BankType == AccountBankType.OtherBankAccount)
                        {
                            if (!string.IsNullOrEmpty(data.OpenBankName))
                            {
                                rd = DataCheckCenter.Instance.CheckOpenBankName(null, data.OpenBankName, "", null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count,MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_OpenBankName); break; }
                            }
                            if (!string.IsNullOrEmpty(data.ClearBankName))
                            {
                                rd = DataCheckCenter.Instance.CheckClearBankName(null, data.ClearBankName, "", 70, null);
                                if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count,MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_ClearBankName); break; }
                            }
                        }
                        if (data.BankType == AccountBankType.BocAccount)
                        {
                            if (data.CertifyPaperType != AgentExpressCertifyPaperType.Empty)
                            {
                                if (!string.IsNullOrEmpty(data.CertifyPaperNo))
                                {
                                    rd = DataCheckCenter.Instance.CheckCertifyCardNo(null, data.CertifyPaperNo, "", true, null);
                                    if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count,MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_CertifyCardNo); break; }
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(data.Email))
                        {
                            rd = DataCheckCenter.Instance.CheckEmail(null, data.Email, 30, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count,MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Email); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Address))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeAddress(null, data.Address, 70, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count,MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Address); break; }
                        }
                        if (!string.IsNullOrEmpty(data.Fax))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeeFax(null, data.Fax, "", 20, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count,MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Fax); break; }
                        } if (!string.IsNullOrEmpty(data.Telephone))
                        {
                            rd = DataCheckCenter.Instance.CheckPayeePhone(null, data.Telephone, 11, 15, null);
                            if (!rd.Result) { result = string.Format(MultiLanguageConvertHelper.Instance.Information_Field_InvalidData_InRow, count,MultiLanguageConvertHelper.Instance.Settings_PayeeMsg_Payee_Telephone); break; }
                        }
                        count++;
                    }
                    #endregion
                    break;
            }
            return result;
        }
    }
}
