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
    public static class BatchConsignDataTemplateHelper
    {
        #region 生成中行格式文件
        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<TransferAccount> dataList, string filepath, double amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());
            //获取交易总额
            list.Add(amount.ToString("0.00"));

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<ElecTicketRemit> dataList, string filepath, double amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());
            //获取交易总额
            list.Add(amount.ToString("0.00"));

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<ElecTicketAutoTipExchange> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<ElecTicketPayMoney> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<ElecTicketBackNote> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<ElecTicketPool> dataList, string filepath, string amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());
            //获取交易总额
            list.Add(ConvertHelper.DataConvertHelper.FormatCash(amount, false));

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<TransferGlobal> dataList, string filepath, double amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());
            //获取交易总额
            list.Add(amount.ToString("0.00"));

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateDATDocumentBar(AppliableFunctionType appType, IList<TransferGlobal> dataList, string filepath, double amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());
            //获取交易总额
            list.Add(amount.ToString("0.00"));

            if (dataList.Count == 0) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateFileHeaderInfoBar(appType, dataList[0], SystemSettings.BOCSeparator, amount, dataList.Count);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfoBar(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            //string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            //list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateDATDocumentBar(AppliableFunctionType appType, BatchHeader bh, IList<AgentExpress> dataList, string filepath, double amount)
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
            string header = TemplateHeaderAndFooterHelper.CreateFileHeaderInfoBar(appType, bh, SystemSettings.BOCSeparator, amount, dataList.Count);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfoBar(appType, dataList, bh.BankType, SystemSettings.BOCSeparator);

            //获取交易尾信息
            //string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

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
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<SpplyFinancingApply> dataList, string filepath)
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
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易列头信息
            string columnsHeader = TemplateHeaderAndFooterHelper.GetTemplateTableColumnsHeader(appType);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.Add(columnsHeader);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<SpplyFinancingBill> dataList, string filepath)
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
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易列头信息
            string columnsHeader = TemplateHeaderAndFooterHelper.GetTemplateTableColumnsHeader(appType);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.Add(columnsHeader);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<SpplyFinancingPayOrReceipt> dataList, string filepath)
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
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易列头信息
            string columnsHeader = TemplateHeaderAndFooterHelper.GetTemplateTableColumnsHeader(appType);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.Add(columnsHeader);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<SpplyFinancingOrder> dataList, string filepath)
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
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易列头信息
            string columnsHeader = TemplateHeaderAndFooterHelper.GetTemplateTableColumnsHeader(appType);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.Add(columnsHeader);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<UnitivePaymentRMB> dataList, string filepath, string amount)
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
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<UnitivePaymentForeignMoney> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            list.Add(((int)dataList[0].PayeeAccountType).ToString());
            //获取交易笔数
            list.Add((dataList.Count).ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator, dataList[0].PayeeAccountType);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType, dataList[0].PayeeAccountType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">快捷数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<AgentExpress> dataList, BatchHeader batch, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, new List<string>(), SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, batch, SystemSettings.BOCSeparator, CommonInformations.GetAllAmount(dataList));

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<AgentNormal> dataList, BatchHeader batch, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, new List<string>(), SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, batch, SystemSettings.BOCSeparator, CommonInformations.GetAllAmount(dataList));

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<InitiativeAllot> dataList, BatchHeader batch, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, new List<string>(), SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, batch, SystemSettings.BOCSeparator, CommonInformations.GetAllAmount(dataList));

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }
        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<VirtualAccount> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> listt = new List<string>();
            //获取交易笔数
            listt.Add((dataList.Count).ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, listt, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }
        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<PreproccessTransfer> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> listt = new List<string>();
            //获取交易笔数
            listt.Add((dataList.Count).ToString());

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, listt, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<BatchReimbursement> dataList, string filepath, string amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> listt = new List<string>();
            //获取交易笔数
            listt.Add((dataList.Count).ToString());
            //获取报销金额
            listt.Add(amount);

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, listt, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(FunctionInSettingType appType, IList<PayeeInfo> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, dataList.Count, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(FunctionInSettingType appType, IList<ElecTicketRelationAccount> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, dataList.Count, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">普通数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(FunctionInSettingType appType, IList<PayeeInfo4TransferGlobal> dataList, string filepath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, dataList.Count, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            List<string> list = new List<string>();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 创建中行格式文件
        /// </summary>
        /// <param name="appType">功能模块类型</param>
        /// <param name="dataList">转账数据</param>
        /// <param name="filepath">文件全名称</param>
        /// <param name="hasCount">是否需要统计</param>
        /// <returns>true-成功，false-失败</returns>
        public static bool CreateTxtDocument(AppliableFunctionType appType, IList<GovermentInfo> dataList, string filepath, double amount)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;
            //头部附加信息
            List<string> list = new List<string>();
            //获取交易笔数
            list.Add(dataList.Count.ToString());
            //获取交易总额
            list.Add(amount.ToString("0.00"));

            //获取交易头信息
            string header = TemplateHeaderAndFooterHelper.CreateTemplateHeaderInfo(appType, list, SystemSettings.BOCSeparator);

            //获取交易内容信息
            List<string> content = TemplateContentHelper.CreateContentInfo(appType, dataList, SystemSettings.BOCSeparator);

            //获取交易尾信息
            string footer = TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType);

            list.Clear();
            list.Add(header);
            list.AddRange(content);
            list.Add(footer);

            //导出TXT文档
            return FileIO.FileRWHelper.ExportTXTDocument(list, filepath);
        }

        /// <summary>
        /// 生成交易文件
        /// </summary>
        /// <param name="appType"></param>
        /// <param name="dataList"></param>
        /// <param name="fileath"></param>
        /// <returns></returns>
        public static bool CreateBOCDocument(FunctionInSettingType appType, List<string> dataList, string originalFilepath, string fileath)
        {
            //当数据列表为空时，直接返回不做任何操作。----后续可以考虑记录相关异常信息
            if (null == dataList) return false;

            return FileIO.FileRWHelper.ExportBOCDocument(dataList, originalFilepath, fileath);
        }
        #endregion

        #region 加载文件
        /// <summary>
        /// 加载中行格式文件
        /// </summary>
        /// <param name="appType"></param>
        /// <param name="command"></param>
        /// <param name="filepath"></param>
        public static ResultData LoadBOCDocument(AppliableFunctionType appType, OperatorCommandType command, string filepath, bool isBOC)
        {
            return LoadBOCDocument(appType, command, filepath, OverCountryPayeeAccountType.Empty, isBOC);
        }

        /// <summary>
        /// 加载中行格式文件
        /// </summary>
        /// <param name="appType"></param>
        /// <param name="command"></param>
        /// <param name="filepath"></param>
        public static ResultData LoadBOCDocument(AppliableFunctionType appType, OperatorCommandType command, string filepath, OverCountryPayeeAccountType at, bool isBOC)
        {
            ResultData rd = new ResultData() { Result = true };
            List<string> fileContent = command == OperatorCommandType.ErrorData || filepath.ToLower().EndsWith(".csv")
                                                ? FileIO.FileRWHelper.ReadCSVFieldsData(filepath)
                                                : filepath.ToLower().EndsWith(".bar")
                                                    ? FileIO.FileRWHelper.ReadDATDocument(filepath)
                                                    : filepath.ToLower().EndsWith(".txt")
                                                        ? FileIO.FileRWHelper.ReadTXTDocument(filepath)
                                                        : FileIO.FileRWHelper.ReadDIFDocumnet(filepath);
            #region txt/csv
            if (filepath.ToLower().EndsWith(".txt") || filepath.ToLower().EndsWith(".csv"))
            {
                if (fileContent.Count > 0 && ((OperatorCommandType.ErrorData == command || (OperatorCommandType.ErrorData != command && filepath.ToLower().EndsWith(".csv"))) || CheckFileFormat(fileContent, appType) || CheckFileFormat(fileContent, appType, at)))
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
                                string typeStr = TemplateHeaderAndFooterHelper.GetTemplateHeaderStarts(appType, OverCountryPayeeAccountType.BocAccount);
                                if (fileContent[0].Contains(typeStr)) at = OverCountryPayeeAccountType.BocAccount;
                                else
                                {
                                    typeStr = TemplateHeaderAndFooterHelper.GetTemplateHeaderStarts(appType, OverCountryPayeeAccountType.OtherAccount);
                                    if (fileContent[0].Contains(typeStr)) at = OverCountryPayeeAccountType.OtherAccount;
                                    else
                                    {
                                        typeStr = TemplateHeaderAndFooterHelper.GetTemplateHeaderStarts(appType, OverCountryPayeeAccountType.ForeignAccount);
                                        if (fileContent[0].Contains(typeStr)) at = OverCountryPayeeAccountType.ForeignAccount;
                                    }
                                }
                            }
                        }
                        fileContent.RemoveAt(0);
                        if (!filepath.EndsWith(".csv"))
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
                                List<TransferAccount> listT = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetTransferAccountBOCErrorLog(fileContent, appType)
                                                             : isBOC ? TemplateContentHelper.GetTransferAccountBOC(fileContent, appType)
                                                                     : TemplateContentHelper.GetTransferAccount(fileContent, appType);
                                CommandCenter.ResolveTransferAccount(command, listT, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.AgentExpressIn:
                            case AppliableFunctionType.AgentExpressOut:
                                List<object> listE = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetAgentExpressBOCErrorLog(fileContent, appType)
                                                             : isBOC ? TemplateContentHelper.GetAgentExpressBOC(fileContent, appType)
                                                                     : TemplateContentHelper.GetAgentExpress(fileContent, appType);
                                CommandCenter.ResolveAgentExpress(command, (List<AgentExpress>)listE[1], (BatchHeader)listE[0], appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.AgentNormalIn:
                            case AppliableFunctionType.AgentNormalOut:
                                List<object> listN = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetAgentNormalBOCErrorLog(fileContent, appType)
                                                            : isBOC ? TemplateContentHelper.GetAgentNormalBOC(fileContent, appType)
                                                                    : TemplateContentHelper.GetAgentNormal(fileContent, appType);
                                CommandCenter.ResolveAgentNormal(command, (List<AgentNormal>)listN[1], (BatchHeader)listN[0], appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.TransferOverBankIn:
                            case AppliableFunctionType.TransferOverBankOut:
                                List<TransferAccount> listO = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetTransferOverBankBOCErrorLog(fileContent, appType)
                                                                    : isBOC ? TemplateContentHelper.GetTransferOverBankBOC(fileContent, appType)
                                                                            : TemplateContentHelper.GetTransferOverBank(fileContent, appType);
                                CommandCenter.ResolveTransferAccount(command, listO, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.ElecTicketRemit:
                                List<ElecTicketRemit> ListETT = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetElecTicketRemitBOCErrorLog(fileContent, appType)
                                                                    : isBOC ? TemplateContentHelper.GetElecTicketRemitBOC(fileContent, appType)
                                                                            : TemplateContentHelper.GetElecTicketRemit(fileContent, appType);
                                CommandCenter.ResolveElecTicketRemit(command, ListETT, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.ElecTicketBackNote:
                                List<ElecTicketBackNote> ListETBN = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetElecTicketBackNoteBOCErrorLog(fileContent, appType)
                                                                    : isBOC ? TemplateContentHelper.GetElecTicketBackNoteBOC(fileContent, appType)
                                                                            : TemplateContentHelper.GetElecTicketBackNote(fileContent, appType);
                                CommandCenter.ResolveElecTicketBackNote(command, ListETBN, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.ElecTicketPayMoney:
                                List<ElecTicketPayMoney> ListETPM = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetElecTicketPayMoneyBOCErrorLog(fileContent, appType)
                                                                    : isBOC ? TemplateContentHelper.GetElecTicketPayMoneyBOC(fileContent, appType)
                                                                            : TemplateContentHelper.GetElecTicketPayMoney(fileContent, appType);
                                CommandCenter.ResolveElecTicketPayMoney(command, ListETPM, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.ElecTicketTipExchange:
                                List<ElecTicketAutoTipExchange> ListETATE = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetElecTicketAutoTipExchangeBOCErrorLog(fileContent, appType)
                                                                    : isBOC ? TemplateContentHelper.GetElecTicketAutoTipExchangeBOC(fileContent, appType)
                                                                            : TemplateContentHelper.GetElecTicketAutoTipExchange(fileContent, appType);
                                CommandCenter.ResolveElecTicketAutoTipExchange(command, ListETATE, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.ElecTicketPool:
                                List<ElecTicketPool> ListETP = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetElecTicketPoolBOCErrorLog(fileContent, appType)
                                        : isBOC ? TemplateContentHelper.GetElecTicketPoolBOC(fileContent, appType)
                                                : TemplateContentHelper.GetElecTicketPool(fileContent, appType);
                                CommandCenter.ResolveElecTicketPool(command, ListETP, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.TransferOverCountry:
                            case AppliableFunctionType.TransferForeignMoney:
                                List<TransferGlobal> ListTG = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetTransferGlobalBOCErrorLog(fileContent, appType)
                                        : isBOC ? TemplateContentHelper.GetTransferGlobalBOC(fileContent, appType)
                                                : TemplateContentHelper.GetTransferGlobal(fileContent, appType);
                                CommandCenter.ResolveTransferGlobal(command, ListTG, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.InitiativeAllot:
                                List<object> ListIA = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetInitiativeAllotBOCErrorLog(fileContent, appType)
                                        : isBOC ? TemplateContentHelper.GetInitiativeAllotBOC(fileContent, appType)
                                                : TemplateContentHelper.GetInitiativeAllot(fileContent, appType);
                                CommandCenter.ResolveInitiativeAllot(command, (List<InitiativeAllot>)ListIA[1], (BatchHeader)ListIA[0], appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.UnitivePaymentRMB:
                                List<UnitivePaymentRMB> ListRMB = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetUnitivePaymentRMBBOCErrorLog(fileContent, appType)
                                        : isBOC ? TemplateContentHelper.GetUnitivePaymentRMBBOC(fileContent, appType)
                                                : TemplateContentHelper.GetUnitivePaymentRMB(fileContent, appType);
                                CommandCenter.ResolveUnitivePaymentRMB(command, ListRMB, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.UnitivePaymentFC:
                                List<UnitivePaymentForeignMoney> ListFC = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetUnitivePaymentFCBOCErrorLog(fileContent, appType)
                                        : isBOC ? TemplateContentHelper.GetUnitivePaymentFCBOC(fileContent, appType, at)
                                                : TemplateContentHelper.GetUnitivePaymentFC(fileContent, appType, at);
                                CommandCenter.ResolveUnitivePaymentFC(command, ListFC, appType, at);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.VirtualAccountTransfer:
                                List<VirtualAccount> ListVA = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetVirtualAccount(fileContent, appType)
                                     : isBOC ? TemplateContentHelper.GetVirtualAccountBOC(fileContent, appType)
                                             : TemplateContentHelper.GetVirtualAccountBOCErrorLog(fileContent, appType);
                                CommandCenter.ResolveVirtualAccount(command, ListVA, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.PreproccessTransfer:
                                List<PreproccessTransfer> ListP = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetPreproccessTransfer(fileContent, appType)
                                     : isBOC ? (filepath.ToLower().EndsWith(".txt") ? TemplateContentHelper.GetPreproccessTransferBOC(fileContent, appType)
                                                    : TemplateContentHelper.GetPreproccessTransferBOCCSV(fileContent, appType))
                                             : TemplateContentHelper.GetPreproccessTransferBOCErrorLog(fileContent, appType);
                                CommandCenter.ResolvePreproccessTransfer(command, ListP, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.BatchReimbursement:
                                List<BatchReimbursement> ListBR = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetBatchReimbursement(fileContent, appType)
                                     : isBOC ? TemplateContentHelper.GetBatchReimbursementBOC(fileContent, appType)
                                             : TemplateContentHelper.GetBatchReimbursementBOCErrorLog(fileContent, appType);
                                CommandCenter.ResolveBatchReimbursement(command, ListBR, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case AppliableFunctionType.TheCentralGoverment:
                                List<GovermentInfo> ListGo = command == OperatorCommandType.ErrorData ? TemplateContentHelper.GetGovermentBOCErrorLog(fileContent, appType)
                                        : isBOC ? TemplateContentHelper.GetGovermentBOC(fileContent, appType)
                                                : TemplateContentHelper.GetGoverment(fileContent, appType);
                                CommandCenter.ResolveGoverment(command, ListGo, appType);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            default: rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_Unknow_AppType }; break;
                        }
                    }
                    catch { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_Data_Changing_Error }; }
                    #endregion
                }
                else if (fileContent.Count == 0)
                {
                    rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_Has_NoData_ChangeFile };
                }
                else { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_Unknow_AppType }; }
            }
            #endregion
            #region dif
            else if (filepath.ToLower().EndsWith(".dif"))
            {
                if (command != OperatorCommandType.ErrorData)
                {
                    try
                    {
                        if (!CheckFileFormatDIF(fileContent, appType))
                            rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_Unknow_AppType };
                        else
                        {
                            List<List<string>> fileContentEx = GetRecordList(fileContent);
                            if (fileContentEx.Count > 0)
                            {
                                switch (appType)
                                {
                                    case AppliableFunctionType.ApplyofFranchiserFinancing:
                                        List<SpplyFinancingApply> listSFAP = TemplateContentHelper.GetSpplyFinancingApplyBOC(fileContentEx, appType);
                                        CommandCenter.ResolveSpplyFinancingApply(command, listSFAP, appType);
                                        rd = new ResultData { Result = true, Message = string.Empty };
                                        break;
                                    case AppliableFunctionType.PurchaserOrder:
                                        List<SpplyFinancingOrder> listSFP = TemplateContentHelper.GetSpplyFinancingOrderBOC(fileContentEx, appType);
                                        CommandCenter.ResolveSpplyFinancingOrder(command, listSFP, appType);
                                        rd = new ResultData { Result = true, Message = string.Empty };
                                        break;
                                    case AppliableFunctionType.SellerOrder:
                                        List<SpplyFinancingOrder> listSFS = TemplateContentHelper.GetSpplyFinancingOrderBOC(fileContentEx, appType);
                                        CommandCenter.ResolveSpplyFinancingOrder(command, listSFS, appType);
                                        rd = new ResultData { Result = true, Message = string.Empty };
                                        break;
                                    case AppliableFunctionType.PurchaserOrderMgr:
                                        List<SpplyFinancingOrder> listSFMP = TemplateContentHelper.GetSpplyFinancingOrderBOC(fileContentEx, appType);
                                        CommandCenter.ResolveSpplyFinancingOrder(command, listSFMP, appType);
                                        rd = new ResultData { Result = true, Message = string.Empty };
                                        break;
                                    case AppliableFunctionType.SellerOrderMgr:
                                        List<SpplyFinancingOrder> listSFMS = TemplateContentHelper.GetSpplyFinancingOrderBOC(fileContentEx, appType);
                                        CommandCenter.ResolveSpplyFinancingOrder(command, listSFMS, appType);
                                        rd = new ResultData { Result = true, Message = string.Empty };
                                        break;
                                    case AppliableFunctionType.BillofDebtReceivablePurchaser:
                                        List<SpplyFinancingBill> listSFBP = TemplateContentHelper.GetSpplyFinancingBillBOC(fileContentEx, appType);
                                        CommandCenter.ResolveSpplyFinancingBill(command, listSFBP, appType);
                                        rd = new ResultData { Result = true, Message = string.Empty };
                                        break;
                                    case AppliableFunctionType.BillofDebtReceivableSeller:
                                        List<SpplyFinancingBill> listSFBS = TemplateContentHelper.GetSpplyFinancingBillBOC(fileContentEx, appType);
                                        CommandCenter.ResolveSpplyFinancingBill(command, listSFBS, appType);
                                        rd = new ResultData { Result = true, Message = string.Empty };
                                        break;
                                    case AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser:
                                        List<SpplyFinancingPayOrReceipt> listSFPR = TemplateContentHelper.GetSpplyFinancingPayOrReceiptBOC(fileContentEx, appType);
                                        CommandCenter.ResolveSpplyFinancingPayOrReceipt(command, listSFPR, appType);
                                        rd = new ResultData { Result = true, Message = string.Empty };
                                        break;
                                    default: rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_Unknow_AppType }; break;
                                }
                            }
                            else if (fileContentEx.Count == 0)
                            {
                                rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_Has_NoData_ChangeFile };
                            }
                        }
                    }
                    catch { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_Data_Changing_Error }; }
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
                                    List<TransferGlobal> listC = TemplateContentHelper.GetTransferGlobalBarBOC(fileContent, appType);
                                    CommandCenter.ResolveTransferGlobal(command, listC, appType);
                                    rd = new ResultData { Result = true, Message = string.Empty };
                                    break;
                                case AppliableFunctionType.AgentExpressOut4Bar:
                                    List<object> listA = TemplateContentHelper.GetAgentExpressBarBOC(fileContent, appType);
                                    CommandCenter.ResolveAgentExpress(command, listA[1] as List<AgentExpress>, listA[0] as BatchHeader, appType);
                                    rd = new ResultData { Result = true, Message = string.Empty };
                                    break;
                                default: rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_Unknow_AppType }; break;
                            }
                        }
                        else if (fileContent.Count == 0)
                        {
                            rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_Has_NoData_ChangeFile };
                        }
                        else { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_Unknow_AppType }; }
                    }
                    catch { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_Data_Changing_Error }; }
                }
            }
            #endregion
            else { rd = new ResultData { Result = false, Message = CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_FileType_Unknow }; }
            return rd;
        }

        /// <summary>
        /// 加载中行格式文件
        /// </summary>
        /// <param name="appType"></param>
        /// <param name="command"></param>
        /// <param name="filepath"></param>
        public static ResultData LoadBOCDocument(FunctionInSettingType appType, OperatorCommandType command, string filepath)
        {
            ResultData rd = new ResultData();
            List<string> fileContent = new List<string>();
            if (filepath.EndsWith(".txt"))
                fileContent = FileIO.FileRWHelper.ReadTXTDocument(filepath);
            else if (filepath.EndsWith(".csv"))
                fileContent = FileIO.FileRWHelper.ReadCSVFieldsData(filepath);

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
                                List<PayeeInfo> listT = TemplateContentHelper.GetPayee(fileContent, appType);
                                CommandCenter.ResolvePayee(command, listT, AppliableFunctionType._Empty);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case FunctionInSettingType.ElecTicketRelateAccountMg:
                                List<ElecTicketRelationAccount> listE = TemplateContentHelper.GetElecTicketRelateAccount(fileContent, true);
                                CommandCenter.ResolveElecTicketRelateAccount(command, listE);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case FunctionInSettingType.OverCountryPayeeMg:
                                List<PayeeInfo4TransferGlobal> listTG = TemplateContentHelper.GetPayeeInfo4TransferGlobal(fileContent, true);
                                CommandCenter.ResolvePayee4TransferGlobal(command, listTG, AppliableFunctionType._Empty);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case FunctionInSettingType.AgentExpressInPayerMg:
                                List<PayeeInfo> listPayer = TemplateContentHelper.GetPayee(fileContent, appType);
                                CommandCenter.ResolveAgentExpressPayer(command, listPayer, AppliableFunctionType._Empty);
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
                                List<PayeeInfo> listT = TemplateContentHelper.GetPayee(fileContent, appType);
                                CommandCenter.ResolvePayee(command, listT, AppliableFunctionType._Empty);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case FunctionInSettingType.ElecTicketRelateAccountMg:
                                List<ElecTicketRelationAccount> listE = TemplateContentHelper.GetElecTicketRelateAccount(fileContent, false);
                                CommandCenter.ResolveElecTicketRelateAccount(command, listE);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case FunctionInSettingType.OverCountryPayeeMg:
                                List<PayeeInfo4TransferGlobal> listTG = TemplateContentHelper.GetPayeeInfo4TransferGlobal(fileContent, false);
                                CommandCenter.ResolvePayee4TransferGlobal(command, listTG, AppliableFunctionType._Empty);
                                rd = new ResultData { Result = true, Message = string.Empty };
                                break;
                            case FunctionInSettingType.AgentExpressInPayerMg:
                                List<PayeeInfo> listPayer = TemplateContentHelper.GetPayee(fileContent, appType);
                                CommandCenter.ResolveAgentExpressPayer(command, listPayer, AppliableFunctionType._Empty);
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
        #endregion

        #region 校验文件头数据
        /// <summary>
        /// 校验文件头、尾数据格式
        /// </summary>
        /// <param name="content">文件内容</param>
        /// <param name="appType">功能类型</param>
        /// <returns></returns>
        private static bool CheckFileFormat(List<string> content, AppliableFunctionType appType)
        {
            return CheckFileFormat(content, appType, OverCountryPayeeAccountType.Empty);
        }

        /// <summary>
        /// 校验文件头、尾数据格式
        /// </summary>
        /// <param name="content">文件内容</param>
        /// <param name="appType">功能类型</param>
        /// <returns></returns>
        private static bool CheckFileFormatDIF(List<string> content, AppliableFunctionType appType)
        {
            bool result = false;
            if (content != null && content.Count > 0)
            {
                StringBuilder strFile = new StringBuilder(string.Empty);
                foreach (var item in content)
                    strFile.Append(item);

                string header = TemplateHeaderAndFooterHelper.GetTemplateTableColumnsHeader(appType);
                result = strFile.ToString().Contains(header.Replace("\r\n", ""));
            }
            return result;
        }

        /// <summary>
        /// 校验文件头、尾数据格式
        /// </summary>
        /// <param name="content">文件内容</param>
        /// <param name="appType">功能类型</param>
        /// <returns></returns>
        private static bool CheckFileFormat(List<string> content, AppliableFunctionType appType, OverCountryPayeeAccountType at)
        {
            bool flag = false;
            //检验模板文件头、尾信息
            if (appType != AppliableFunctionType.UnitivePaymentFC)
            {
                if (content[0].StartsWith(TemplateHeaderAndFooterHelper.GetTemplateHeaderStarts(appType)) && content[content.Count - 1].Equals(TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType, at)))
                    flag = true;
            }
            else//非法格式模板文件
            {
                if (at != OverCountryPayeeAccountType.Empty && content[0].StartsWith(TemplateHeaderAndFooterHelper.GetTemplateHeaderStarts(appType, at)) && content[content.Count - 1].Equals(TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType, at)))
                    flag = true;
                if (at == OverCountryPayeeAccountType.Empty
                   && ((content[0].StartsWith(TemplateHeaderAndFooterHelper.GetTemplateHeaderStarts(appType, OverCountryPayeeAccountType.BocAccount)) && content[content.Count - 1].Equals(TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType, OverCountryPayeeAccountType.BocAccount)))
                       || (content[0].StartsWith(TemplateHeaderAndFooterHelper.GetTemplateHeaderStarts(appType, OverCountryPayeeAccountType.OtherAccount)) && content[content.Count - 1].Equals(TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType, OverCountryPayeeAccountType.OtherAccount))
                       || (content[0].StartsWith(TemplateHeaderAndFooterHelper.GetTemplateHeaderStarts(appType, OverCountryPayeeAccountType.ForeignAccount)) && content[content.Count - 1].Equals(TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType, OverCountryPayeeAccountType.ForeignAccount))))))
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
        private static bool CheckFileFormat(List<string> content, FunctionInSettingType appType)
        {
            bool flag = false;
            //检验模板文件头、尾信息
            if (content[0].StartsWith(TemplateHeaderAndFooterHelper.GetTemplateHeaderStarts(appType)) && content[content.Count - 1].Equals(TemplateHeaderAndFooterHelper.GetTemplateFooterInfo(appType)))
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
        static List<List<string>> GetRecordList(List<string> list)
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
            else { throw new Exception(CommonClient.ConvertHelper.MultiLanguageConvertHelper.DesignMain_FileType_Unknow); }
            return result;
        }

        static List<string> GetRecordListEx(List<string> list)
        {
            List<string> result = new List<string>();
            foreach (var data in list)
            {
                result.AddRange(data.Split(new string[] { "|" }, StringSplitOptions.None));
            }
            return result;
        }
        #endregion
    }
}
