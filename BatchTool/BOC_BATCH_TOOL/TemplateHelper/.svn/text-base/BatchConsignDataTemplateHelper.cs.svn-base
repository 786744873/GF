using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.SysCoach;

namespace CommonClient.TemplateHelper
{
    /// <summary>
    /// 中行格式文件操作类
    /// </summary>
    public class BatchConsignDataTemplateHelper
    {
        #region 单例
        private static object lock_instance = new object();
        private static BatchConsignDataTemplateHelper m_instance;

        public static BatchConsignDataTemplateHelper Instance
        {
            get
            {
                if (null == m_instance)
                {
                    lock (lock_instance)
                    {
                        if (null == m_instance)
                        {
                            m_instance = new BatchConsignDataTemplateHelper();
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<TransferAccount> dataList, string filepath, double amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());
            //获取交易总额
            list.Add(amount.ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<ElecTicketRemit> dataList, string filepath, double amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());
            //获取交易总额
            list.Add(amount.ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<ElecTicketAutoTipExchange> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<ElecTicketPayMoney> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<ElecTicketBackNote> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<ElecTicketPool> dataList, string filepath, double amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());
            //获取交易总额
            list.Add(ConvertHelper.DataConvertHelper.Instance.FormatCash(amount.ToString(), false));

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<TransferGlobal> dataList, string filepath, double amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());
            //获取交易总额
            list.Add(amount.ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateDATDocumentBar(AppliableFunctionType appType, IList<TransferGlobal> dataList, string filepath, double amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());
            //获取交易总额
            list.Add(amount.ToString());

            if (dataList.Count == 0) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateFileHeaderInfoBar(appType, dataList[0], SystemSettings.Instance.BOCSeparator, amount, dataList.Count);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfoBar(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            //string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            //list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateDATDocumentBar(AppliableFunctionType appType, BatchHeader bh, IList<AgentExpress> dataList, string filepath, double amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());
            //获取交易总额
            list.Add(amount.ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateFileHeaderInfoBar(appType, bh, SystemSettings.Instance.BOCSeparator, amount, dataList.Count);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfoBar(appType, dataList, bh.BankType, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            //string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            //StringBuilder str = new StringBuilder();
            //str.Append(header);
            //foreach (var item in content)
            //{
            //    str.Append(item);
            //}
            //list.Add(str.ToString());
            list.Add(header);
            list.AddRange(content);
            //list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<SpplyFinancingApply> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add((dataList.Count + 1).ToString());
            //获取交易的字段数
            list.Add("15");

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易列头信息
            string columnsHeader = TemplateHeaderAndFooterHelper.Instance.GetTemplateTableColumnsHeader(appType);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.Add(columnsHeader);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<SpplyFinancingBill> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add((dataList.Count + 1).ToString());
            //获取交易的字段数
            list.Add("9");

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易列头信息
            string columnsHeader = TemplateHeaderAndFooterHelper.Instance.GetTemplateTableColumnsHeader(appType);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.Add(columnsHeader);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<SpplyFinancingPayOrReceipt> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add((dataList.Count + 1).ToString());
            //获取交易的字段数
            list.Add("5");

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易列头信息
            string columnsHeader = TemplateHeaderAndFooterHelper.Instance.GetTemplateTableColumnsHeader(appType);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.Add(columnsHeader);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<SpplyFinancingOrder> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add((dataList.Count + 1).ToString());
            //获取交易的字段数
            list.Add((appType == AppliableFunctionType.PurchaserOrderMgr || appType == AppliableFunctionType.SellerOrderMgr) ? "2" : appType == AppliableFunctionType.PurchaserOrder ? "6" : "5");

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易列头信息
            string columnsHeader = TemplateHeaderAndFooterHelper.Instance.GetTemplateTableColumnsHeader(appType);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.Add(columnsHeader);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<UnitivePaymentRMB> dataList, string filepath, string amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add((dataList.Count).ToString());
            //获取交易的字段数
            list.Add(amount);

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<UnitivePaymentForeignMoney> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            list.Add(((int)dataList[0].PayeeAccountType).ToString());
            //获取交易笔数
            list.Add((dataList.Count).ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, list, SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator, dataList[0].PayeeAccountType);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType, dataList[0].PayeeAccountType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">快捷数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<AgentExpress> dataList, BatchHeader batch, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, new List<string>(), SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, batch, SystemSettings.Instance.BOCSeparator, CommonInformations.Instance.GetAllAmount(dataList));

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<AgentNormal> dataList, BatchHeader batch, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, new List<string>(), SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, batch, SystemSettings.Instance.BOCSeparator, CommonInformations.Instance.GetAllAmount(dataList));

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<InitiativeAllot> dataList, BatchHeader batch, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, new List<string>(), SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, batch, SystemSettings.Instance.BOCSeparator, CommonInformations.Instance.GetAllAmount(dataList));

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }
        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(AppliableFunctionType appType, IList<VirtualAccount> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, new List<string>(), SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }
        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(FunctionInSettingType appType, IList<PayeeInfo> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, dataList.Count, SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(FunctionInSettingType appType, IList<ElecTicketRelationAccount> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, dataList.Count, SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public bool CreateTxtDocument(FunctionInSettingType appType, IList<PayeeInfo4TransferGlobal> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.Instance.CreateTemplateHeaderInfo(appType, dataList.Count, SystemSettings.Instance.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.Instance.CreateContentInfo(appType, dataList, SystemSettings.Instance.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.Instance.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 加载中行格式文件
        /// </summary>
        /// <param name="appType"></param>
        /// <param name="command"></param>
        /// <param name="filepath"></param>
        public ResultData LoadBOCDocument(AppliableFunctionType appType, OperatorCommandType command, string filepath, bool isBOC)
        {
            return LoadBOCDocument(appType, command, filepath, OverCountryPayeeAccountType.Empty, isBOC);
        }

        /// <summary>
        /// 加载中行格式文件
        /// </summary>
        /// <param name="appType"></param>
        /// <param name="command"></param>
        /// <param name="filepath"></param>
        public ResultData LoadBOCDocument(AppliableFunctionType appType, OperatorCommandType command, string filepath, OverCountryPayeeAccountType at, bool isBOC)
        {
            ResultData rd = new ResultData() { Result = true };
            List<string> fileContent = command == OperatorCommandType.ErrorData
                                                ? FileIO.FileRWHelper.Instance.ReadCSVFieldsData(filepath)
                                                : filepath.ToLower().EndsWith(".bar")
                                                    ? FileIO.FileRWHelper.Instance.ReadDATDocument(filepath)
                                                    : filepath.ToLower().EndsWith(".txt")
                                                        ? FileIO.FileRWHelper.Instance.ReadTXTDocument(filepath)
                                                        : FileIO.FileRWHelper.Instance.ReadDIFDocumnet(filepath);
            #region txt
            if (filepath.ToLower().EndsWith(".txt") || filepath.ToLower().EndsWith(".csv"))
            {
                if (fileContent.Count > 0 && (OperatorCommandType.ErrorData == command || CheckFileFormat(fileContent, appType) || CheckFileFormat(fileContent, appType, at)))
                {
                    #region 去除数据的头和尾
                    if (command == OperatorCommandType.ErrorData)
                    {
                        if (appType == AppliableFunctionType.AgentExpressIn
                              || appType == AppliableFunctionType.AgentExpressOut)
                        {
                            if (fileContent.Count > 9)
                                for (int i = 0; i < 9; i++)
                                    fileContent.RemoveAt(0);
                        }
                        else
                        {
                            if (fileContent.Count > 1)
                                fileContent.RemoveAt(0);
                        }
                    }
                    else
                    {
                        if (appType == AppliableFunctionType.UnitivePaymentFC)
                        {
                            if (at == OverCountryPayeeAccountType.Empty)
                            {
                                string typeStr = TemplateHeaderAndFooterHelper.Instance.GetTemplateHeaderStarts(appType, OverCountryPayeeAccountType.BocAccount);
                                if (fileContent[0].Contains(typeStr)) at = OverCountryPayeeAccountType.BocAccount;
                                else
                                {
                                    typeStr = TemplateHeaderAndFooterHelper.Instance.GetTemplateHeaderStarts(appType, OverCountryPayeeAccountType.OtherAccount);
                                    if (fileContent[0].Contains(typeStr)) at = OverCountryPayeeAccountType.OtherAccount;
                                    else
                                    {
                                        typeStr = TemplateHeaderAndFooterHelper.Instance.GetTemplateHeaderStarts(appType, OverCountryPayeeAccountType.ForeignAccount);
                                        if (fileContent[0].Contains(typeStr)) at = OverCountryPayeeAccountType.ForeignAccount;
                                    }
                                }
                            }
                        }
                        fileContent.RemoveAt(0);
                        fileContent.RemoveAt(fileContent.Count - 1);
                    }
                    #endregion
                    #region 明细数据操作
                    try
                    {
                        switch (appType)
                        {
                            case AppliableFunctionType.TransferWithIndiv:
                            case AppliableFunctionType.TransferWithCorp:
                                List<TransferAccount> listT = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetTransferAccountBOCErrorLog(fileContent, appType)
                                                             : isBOC ? TemplateContentHelper.Instance.GetTransferAccountBOC(fileContent, appType)
                                                                     : TemplateContentHelper.Instance.GetTransferAccount(fileContent, appType);
                                CommandCenter.Instance.ResolveTransferAccount(command, listT, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.AgentExpressIn:
                            case AppliableFunctionType.AgentExpressOut:
                                List<object> listE = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetAgentExpressBOCErrorLog(fileContent, appType)
                                                             : isBOC ? TemplateContentHelper.Instance.GetAgentExpressBOC(fileContent, appType)
                                                                     : TemplateContentHelper.Instance.GetAgentExpress(fileContent, appType);
                                CommandCenter.Instance.ResolveAgentExpress(command, (List<AgentExpress>)listE[1], (BatchHeader)listE[0], appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.AgentNormalIn:
                            case AppliableFunctionType.AgentNormalOut:
                                List<object> listN = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetAgentNormalBOCErrorLog(fileContent, appType)
                                                            : isBOC ? TemplateContentHelper.Instance.GetAgentNormalBOC(fileContent, appType)
                                                                    : TemplateContentHelper.Instance.GetAgentNormal(fileContent, appType);
                                CommandCenter.Instance.ResolveAgentNormal(command, (List<AgentNormal>)listN[1], (BatchHeader)listN[0], appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.TransferOverBankIn:
                            case AppliableFunctionType.TransferOverBankOut:
                                List<TransferAccount> listO = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetTransferOverBankBOCErrorLog(fileContent, appType)
                                                                    : isBOC ? TemplateContentHelper.Instance.GetTransferOverBankBOC(fileContent, appType)
                                                                            : TemplateContentHelper.Instance.GetTransferOverBank(fileContent, appType);
                                CommandCenter.Instance.ResolveTransferAccount(command, listO, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.ElecTicketRemit:
                                List<ElecTicketRemit> ListETT = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetElecTicketRemitBOCErrorLog(fileContent, appType)
                                                                    : isBOC ? TemplateContentHelper.Instance.GetElecTicketRemitBOC(fileContent, appType)
                                                                            : TemplateContentHelper.Instance.GetElecTicketRemit(fileContent, appType);
                                CommandCenter.Instance.ResolveElecTicketRemit(command, ListETT, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.ElecTicketBackNote:
                                List<ElecTicketBackNote> ListETBN = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetElecTicketBackNoteBOCErrorLog(fileContent, appType)
                                                                    : isBOC ? TemplateContentHelper.Instance.GetElecTicketBackNoteBOC(fileContent, appType)
                                                                            : TemplateContentHelper.Instance.GetElecTicketBackNote(fileContent, appType);
                                CommandCenter.Instance.ResolveElecTicketBackNote(command, ListETBN, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.ElecTicketPayMoney:
                                List<ElecTicketPayMoney> ListETPM = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetElecTicketPayMoneyBOCErrorLog(fileContent, appType)
                                                                    : isBOC ? TemplateContentHelper.Instance.GetElecTicketPayMoneyBOC(fileContent, appType)
                                                                            : TemplateContentHelper.Instance.GetElecTicketPayMoney(fileContent, appType);
                                CommandCenter.Instance.ResolveElecTicketPayMoney(command, ListETPM, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.ElecTicketTipExchange:
                                List<ElecTicketAutoTipExchange> ListETATE = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetElecTicketAutoTipExchangeBOCErrorLog(fileContent, appType)
                                                                    : isBOC ? TemplateContentHelper.Instance.GetElecTicketAutoTipExchangeBOC(fileContent, appType)
                                                                            : TemplateContentHelper.Instance.GetElecTicketAutoTipExchange(fileContent, appType);
                                CommandCenter.Instance.ResolveElecTicketAutoTipExchange(command, ListETATE, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.ElecTicketPool:
                                List<ElecTicketPool> ListETP = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetElecTicketPoolBOCErrorLog(fileContent, appType)
                                        : isBOC ? TemplateContentHelper.Instance.GetElecTicketPoolBOC(fileContent, appType)
                                                : TemplateContentHelper.Instance.GetElecTicketPool(fileContent, appType);
                                CommandCenter.Instance.ResolveElecTicketPool(command, ListETP, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.TransferOverCountry:
                            case AppliableFunctionType.TransferForeignMoney:
                                List<TransferGlobal> ListTG = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetTransferGlobalBOCErrorLog(fileContent, appType)
                                        : isBOC ? TemplateContentHelper.Instance.GetTransferGlobalBOC(fileContent, appType)
                                                : TemplateContentHelper.Instance.GetTransferGlobal(fileContent, appType);
                                CommandCenter.Instance.ResolveTransferGlobal(command, ListTG, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.InitiativeAllot:
                                List<object> ListIA = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetInitiativeAllotBOCErrorLog(fileContent, appType)
                                        : isBOC ? TemplateContentHelper.Instance.GetInitiativeAllotBOC(fileContent, appType)
                                                : TemplateContentHelper.Instance.GetInitiativeAllot(fileContent, appType);
                                CommandCenter.Instance.ResolveInitiativeAllot(command, (List<InitiativeAllot>)ListIA[1], (BatchHeader)ListIA[0], appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.UnitivePaymentRMB:
                                List<UnitivePaymentRMB> ListRMB = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetUnitivePaymentRMBBOCErrorLog(fileContent, appType)
                                        : isBOC ? TemplateContentHelper.Instance.GetUnitivePaymentRMBBOC(fileContent, appType)
                                                : TemplateContentHelper.Instance.GetUnitivePaymentRMB(fileContent, appType);
                                CommandCenter.Instance.ResolveUnitivePaymentRMB(command, ListRMB, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.UnitivePaymentFC:
                                List<UnitivePaymentForeignMoney> ListFC = command == OperatorCommandType.ErrorData ?TemplateContentHelper.Instance.GetUnitivePaymentFCBOCErrorLog(fileContent, appType) 
                                        : isBOC ? TemplateContentHelper.Instance.GetUnitivePaymentFCBOC(fileContent, appType, at)
                                                : TemplateContentHelper.Instance.GetUnitivePaymentFC(fileContent, appType, at);
                                CommandCenter.Instance.ResolveUnitivePaymentFC(command, ListFC, appType, at);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.VirtualAccountTransfer:
                                List<VirtualAccount> ListVA = command == OperatorCommandType.ErrorData ? TemplateContentHelper.Instance.GetVirtualAccount(fileContent, appType)
                                     : isBOC ? TemplateContentHelper.Instance.GetVirtualAccountBOC(fileContent, appType)
                                             : TemplateContentHelper.Instance.GetVirtualAccountBOCErrorLog(fileContent, appType);
                                CommandCenter.Instance.ResolveVirtualAccount(command, ListVA, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            default: rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_Unknow_AppType }; break;
                        }
                    }
                    catch { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_Data_Changing_Error }; }
                    #endregion
                }
                else if (fileContent.Count == 0)
                {
                    rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_Has_NoData_ChangeFile };
                }
                else { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_Unknow_AppType }; }
            }
            #endregion
            #region dif
            else if (filepath.ToLower().EndsWith(".dif"))
            {
                if (command != OperatorCommandType.ErrorData)
                {
                    try
                    {
                        List<List<string>> fileContentEx = GetRecordList(fileContent);
                        if (fileContentEx.Count > 0)
                        {
                            switch (appType)
                            {
                                case AppliableFunctionType.ApplyofFranchiserFinancing:
                                    List<SpplyFinancingApply> listSFAP = TemplateContentHelper.Instance.GetSpplyFinancingApplyBOC(fileContentEx, appType);
                                    CommandCenter.Instance.ResolveSpplyFinancingApply(command, listSFAP, appType);
                                    rd = new ResultData { Result = true, Message = string.Empty };
                                    break;
                                case AppliableFunctionType.PurchaserOrder:
                                    List<SpplyFinancingOrder> listSFP = TemplateContentHelper.Instance.GetSpplyFinancingOrderBOC(fileContentEx, appType);
                                    CommandCenter.Instance.ResolveSpplyFinancingOrder(command, listSFP, appType);
                                    rd = new ResultData { Result = true, Message = string.Empty };
                                    break;
                                case AppliableFunctionType.SellerOrder:
                                    List<SpplyFinancingOrder> listSFS = TemplateContentHelper.Instance.GetSpplyFinancingOrderBOC(fileContentEx, appType);
                                    CommandCenter.Instance.ResolveSpplyFinancingOrder(command, listSFS, appType);
                                    rd = new ResultData { Result = true, Message = string.Empty };
                                    break;
                                case AppliableFunctionType.PurchaserOrderMgr:
                                    List<SpplyFinancingOrder> listSFMP = TemplateContentHelper.Instance.GetSpplyFinancingOrderBOC(fileContentEx, appType);
                                    CommandCenter.Instance.ResolveSpplyFinancingOrder(command, listSFMP, appType);
                                    rd = new ResultData { Result = true, Message = string.Empty };
                                    break;
                                case AppliableFunctionType.SellerOrderMgr:
                                    List<SpplyFinancingOrder> listSFMS = TemplateContentHelper.Instance.GetSpplyFinancingOrderBOC(fileContentEx, appType);
                                    CommandCenter.Instance.ResolveSpplyFinancingOrder(command, listSFMS, appType);
                                    rd = new ResultData { Result = true, Message = string.Empty };
                                    break;
                                case AppliableFunctionType.BillofDebtReceivablePurchaser:
                                    List<SpplyFinancingBill> listSFBP = TemplateContentHelper.Instance.GetSpplyFinancingBillBOC(fileContentEx, appType);
                                    CommandCenter.Instance.ResolveSpplyFinancingBill(command, listSFBP, appType);
                                    rd = new ResultData { Result = true, Message = string.Empty };
                                    break;
                                case AppliableFunctionType.BillofDebtReceivableSeller:
                                    List<SpplyFinancingBill> listSFBS = TemplateContentHelper.Instance.GetSpplyFinancingBillBOC(fileContentEx, appType);
                                    CommandCenter.Instance.ResolveSpplyFinancingBill(command, listSFBS, appType);
                                    rd = new ResultData { Result = true, Message = string.Empty };
                                    break;
                                case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                                    List<SpplyFinancingPayOrReceipt> listSFPR = TemplateContentHelper.Instance.GetSpplyFinancingPayOrReceiptBOC(fileContentEx, appType);
                                    CommandCenter.Instance.ResolveSpplyFinancingPayOrReceipt(command, listSFPR, appType);
                                    rd = new ResultData { Result = true, Message = string.Empty };
                                    break;
                                default: rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_Unknow_AppType }; break;
                            }
                        }
                        else if (fileContentEx.Count == 0)
                        {
                            rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_Has_NoData_ChangeFile };
                        }
                        else { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_Unknow_AppType }; }
                    }
                    catch { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_Data_Changing_Error }; }
                }
            }
            #endregion
            #region
            else if (filepath.ToLower().EndsWith(".bar"))
            {
                if (command != OperatorCommandType.ErrorData)
                {
                    try
                    {
                        //List<string> fileContentEx = GetRecordListEx(fileContent);
                        if (fileContent.Count > 0)
                        {
                            switch (appType)
                            {
                                case AppliableFunctionType.TransferOverCountry4Bar:
                                case AppliableFunctionType.TransferForeignMoney4Bar:
                                    List<TransferGlobal> listC = TemplateContentHelper.Instance.GetTransferGlobalBarBOC(fileContent, appType);
                                    CommandCenter.Instance.ResolveTransferGlobal(command, listC, appType);
                                    rd = new ResultData { Result = true, Message = string.Empty };
                                    break;
                                case AppliableFunctionType.AgentExpressOut4Bar:
                                    List<object> listA = TemplateContentHelper.Instance.GetAgentExpressBarBOC(fileContent, appType);
                                    CommandCenter.Instance.ResolveAgentExpress(command, listA[1] as List<AgentExpress>, listA[0] as BatchHeader, appType);
                                    rd = new ResultData { Result = true, Message = string.Empty };
                                    break;
                                default: rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_Unknow_AppType }; break;
                            }
                        }
                        else if (fileContent.Count == 0)
                        {
                            rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_Has_NoData_ChangeFile };
                        }
                        else { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_Unknow_AppType }; }
                    }
                    catch { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_Data_Changing_Error }; }
                }
            }
            #endregion
            else { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_FileType_Unknow }; }
            return rd;
        }

        /// <summary>
        /// 加载中行格式文件
        /// </summary>
        /// <param name="appType"></param>
        /// <param name="command"></param>
        /// <param name="filepath"></param>
        public ResultData LoadBOCDocument(FunctionInSettingType appType, OperatorCommandType command, string filepath)
        {
            ResultData rd = new ResultData();
            List<string> fileContent = new List<string>();
            if (filepath.EndsWith(".txt"))
                fileContent = FileIO.FileRWHelper.Instance.ReadTXTDocument(filepath);
            else if (filepath.EndsWith(".csv"))
                fileContent = FileIO.FileRWHelper.Instance.ReadCSVFieldsData(filepath);

            if (filepath.EndsWith(".txt"))
            {
                if (CheckFileFormat(fileContent, appType))
                {
                    //取出数据的头和尾
                    fileContent.RemoveAt(0);
                    fileContent.RemoveAt(fileContent.Count - 1);

                    try
                    {
                        switch (appType)
                        {
                            case FunctionInSettingType.PayeeMg:
                                List<PayeeInfo> listT = TemplateContentHelper.Instance.GetPayee(fileContent, appType);
                                CommandCenter.Instance.ResolvePayee(command, listT, AppliableFunctionType._Empty);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case FunctionInSettingType.ElecTicketRelateAccountMg:
                                List<ElecTicketRelationAccount> listE = TemplateContentHelper.Instance.GetElecTicketRelateAccount(fileContent, true);
                                CommandCenter.Instance.ResolveElecTicketRelateAccount(command, listE);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case FunctionInSettingType.OverCountryPayeeMg:
                                List<PayeeInfo4TransferGlobal> listTG = TemplateContentHelper.Instance.GetPayeeInfo4TransferGlobal(fileContent, true);
                                CommandCenter.Instance.ResolvePayee4TransferGlobal(command, listTG, AppliableFunctionType._Empty);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case FunctionInSettingType.AgentExpressInPayerMg:
                                List<PayeeInfo> listPayer = TemplateContentHelper.Instance.GetPayee(fileContent, appType);
                                CommandCenter.Instance.ResolveAgentExpressPayer(command, listPayer, AppliableFunctionType._Empty);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            default:
                                rd = new ResultData { Result = false, Message = "未知文件格式" }; break;
                        }
                    }
                    catch { rd = new ResultData { Result = false, Message = "未知文件格式" }; }
                }
                else
                {
                    rd = new ResultData { Result = false, Message = "未知文件格式" };
                }
            }
            else if (filepath.EndsWith(".csv"))
            {
                if (fileContent.Count > 2)
                {
                    //取出数据的头和尾
                    fileContent.RemoveAt(0);
                    fileContent.RemoveAt(0);

                    try
                    {
                        switch (appType)
                        {
                            case FunctionInSettingType.PayeeMg:
                                List<PayeeInfo> listT = TemplateContentHelper.Instance.GetPayee(fileContent, appType);
                                CommandCenter.Instance.ResolvePayee(command, listT, AppliableFunctionType._Empty);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case FunctionInSettingType.ElecTicketRelateAccountMg:
                                List<ElecTicketRelationAccount> listE = TemplateContentHelper.Instance.GetElecTicketRelateAccount(fileContent, false);
                                CommandCenter.Instance.ResolveElecTicketRelateAccount(command, listE);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case FunctionInSettingType.OverCountryPayeeMg:
                                List<PayeeInfo4TransferGlobal> listTG = TemplateContentHelper.Instance.GetPayeeInfo4TransferGlobal(fileContent, false);
                                CommandCenter.Instance.ResolvePayee4TransferGlobal(command, listTG, AppliableFunctionType._Empty);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case FunctionInSettingType.AgentExpressInPayerMg:
                                List<PayeeInfo> listPayer = TemplateContentHelper.Instance.GetPayee(fileContent, appType);
                                CommandCenter.Instance.ResolveAgentExpressPayer(command, listPayer, AppliableFunctionType._Empty);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            default:
                                rd = new ResultData { Result = false, Message = "未知文件格式" }; break;
                        }
                    }
                    catch { rd = new ResultData { Result = false, Message = "未知文件格式" }; }
                }
                else
                {
                    rd = new ResultData { Result = false, Message = "未知文件格式" };
                }
            }
            return rd;
        }

        /// <summary>
        /// 校验文件头、尾数据格式
        /// </summary>
        /// <param name="content">文件内容</param>
        /// <param name="appType">功能类型</param>
        /// <returns></returns>
        private bool CheckFileFormat(List<string> content, AppliableFunctionType appType)
        {
            return CheckFileFormat(content, appType, OverCountryPayeeAccountType.Empty);
        }

        /// <summary>
        /// 校验文件头、尾数据格式
        /// </summary>
        /// <param name="content">文件内容</param>
        /// <param name="appType">功能类型</param>
        /// <returns></returns>
        private bool CheckFileFormat(List<string> content, AppliableFunctionType appType, OverCountryPayeeAccountType at)
        {
            bool flag = false;
            //检验模板文件头、尾信息
            if (appType != AppliableFunctionType.UnitivePaymentFC)
            {
                if (content[0].StartsWith(TemplateHeaderAndFooterHelper.Instance.GetTemplateHeaderStarts(appType)) && content[content.Count - 1].Equals(TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType, at)))
                    flag = true;
            }
            else//非法格式模板文件
            {
                if (at != OverCountryPayeeAccountType.Empty && content[0].StartsWith(TemplateHeaderAndFooterHelper.Instance.GetTemplateHeaderStarts(appType, at)) && content[content.Count - 1].Equals(TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType, at)))
                    flag = true;
                if (at == OverCountryPayeeAccountType.Empty
                   && ((content[0].StartsWith(TemplateHeaderAndFooterHelper.Instance.GetTemplateHeaderStarts(appType, OverCountryPayeeAccountType.BocAccount)) && content[content.Count - 1].Equals(TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType, OverCountryPayeeAccountType.BocAccount)))
                       || (content[0].StartsWith(TemplateHeaderAndFooterHelper.Instance.GetTemplateHeaderStarts(appType, OverCountryPayeeAccountType.OtherAccount)) && content[content.Count - 1].Equals(TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType, OverCountryPayeeAccountType.OtherAccount))
                       || (content[0].StartsWith(TemplateHeaderAndFooterHelper.Instance.GetTemplateHeaderStarts(appType, OverCountryPayeeAccountType.ForeignAccount)) && content[content.Count - 1].Equals(TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType, OverCountryPayeeAccountType.ForeignAccount))))))
                    flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 校验文件头、尾数据格式
        /// </summary>
        /// <param name="content">文件内容</param>
        /// <param name="appType">功能类型</param>
        /// <returns></returns>
        private bool CheckFileFormat(List<string> content, FunctionInSettingType appType)
        {
            bool flag = false;
            //检验模板文件头、尾信息
            if (content[0].StartsWith(TemplateHeaderAndFooterHelper.Instance.GetTemplateHeaderStarts(appType)) && content[content.Count - 1].Equals(TemplateHeaderAndFooterHelper.Instance.GetTemplateFooterInfo(appType)))
                flag = true;
            else//非法格式模板文件
            { }
            return flag;
        }

        /// <summary>
        /// 获取真实记录列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        List<List<string>> GetRecordList(List<string> list)
        {
            List<List<string>> result = new List<List<string>>();
            if (list[0].Equals("TABLE") && list[3].Equals("VECTORS") && list[6].Equals("TUPLES") && list[9].Equals("DATA") && list[12].Equals("-1,0"))
            {
                int index = list[4].IndexOf(',');
                int rowcount = int.Parse(list[4].Substring(index + 1, list[4].Length - index - 1));
                index = list[7].IndexOf(',');
                int columncount = int.Parse(list[7].Substring(index + 1, list[7].Length - index - 1));
                index = list.IndexOf("BOT") + 1;
                if (index > 0) index = list.IndexOf("BOT", index, list.Count - index);
                else return result;
                if (index <= 0) return result;
                else if (index > 0)
                {
                    List<string> record = new List<string>();
                    string temp = string.Empty;
                    for (int i = index; i < list.Count; i++)
                    {
                        switch (list[i])
                        {
                            case "BOT":
                                record = new List<string>();
                                break;
                            case "1,0":
                                temp = list[i + 1].Replace("\"", string.Empty);
                                record.Add(temp);
                                i++;
                                break;
                            case "V":
                                temp = list[i - 1];
                                int tindex = temp.IndexOf(',') + 1;
                                temp = temp.Substring(tindex, temp.Length - tindex);
                                record.Add(temp);
                                break;
                            case "-1,0":
                                if (record.Count == columncount)
                                    result.Add(record);
                                break;
                        }
                    }
                }
            }
            else { throw new Exception(CommonClient.ConvertHelper.MultiLanguageConvertHelper.Instance.DesignMain_FileType_Unknow); }
            return result;
        }

        List<string> GetRecordListEx(List<string> list)
        {
            List<string> result = new List<string>();
            foreach (var data in list)
            {
                result.AddRange(data.Split(new string[] { "|" }, StringSplitOptions.None));
            }
            return result;
        }
    }
}
