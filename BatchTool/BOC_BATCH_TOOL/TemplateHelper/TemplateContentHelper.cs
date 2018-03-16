using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using CommonClient.Entities;
using CommonClient.SysCoach;
using CommonClient.Utilities;
using CommonClient.ConvertHelper;

namespace CommonClient.TemplateHelper
{
    public class TemplateContentHelper
    {
        #region 单例
        private static object lock_instance = new object();
        private static TemplateContentHelper m_instance;

        /// <summary>
        /// 单一实例
        /// </summary>
        public static TemplateContentHelper Instance
        {
            get
            {
                if (null == m_instance)
                {
                    lock (lock_instance)
                    {
                        if (null == m_instance)
                        {
                            lock (lock_instance)
                            {
                                m_instance = new TemplateContentHelper();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        #region CreateContentInfo
        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<TransferAccount> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            #region 说明
            if (AppliableFunctionType.TransferWithIndiv == aft || AppliableFunctionType.TransferWithCorp == aft)
            {
                //客户业务编号（客户应用系统自动产生的业务编号，或客户自己填写的号。字符数<=16）
                //付款行联行号（必填。付款账号的银行编号，由客户填写（4开头5位数字））
                //付款行机构号（非必填。付款账号的机构编号，由客户填写。4位）
                //付款人账号（必填。进行批量委托的操作员有委托权限的账号（12到18位数字），就账号填18位账号，新账号填实际位数，如果非18位账号，系统认为是新账号）
                //收款人账号（必填。1到35位数字或字母）
                //收款行联行号（---4开头5位数字）
                //收款行机构号（---4位数字，如果为中行收款且账号为14位时，不能为空）
                //收款行名称（中行收款必填。最大文本长度70位）
                //收款人名称（必填。最大文本长度76位）
                //收款人地址（非必填。最大文本长度70位）
                //付款货币（非必填。货币代码，3位）
                //付款金额（必填。数字，2位小数点，共15位）
                //支付手续费账号（非必填。必须是操作员有权限委托的账号。如果为空，默认为付款账号；如果填写，必须为不小于35位账号）
                //客户指定付款日期（必填。必须不小于系统当前日期且不能大于当前系统日期30天，格式：2008-01-01）
                //用途或附言（非必填。最多100个汉字）
                //优先级（非必填。0-普通，1-特急）
                //收款人e-mail（非必填。最大文本长度40位）
                //收款人手机（非必填。15位的数字）
                //收款人传真号（非必填。最大文本长度20位）
                //是否中行收款标志（必填。0-他行，1-中行）
                //CNAPS行号（非必填。12位数字）
                //客户优先级（非必填。0-普通，1-优先）
            }
            else if (AppliableFunctionType.TransferOverBankIn == aft || AppliableFunctionType.TransferOverBankOut == aft)
            {
                //客户业务编号	<=16位	非必输项	可由客户自行填写并避免重复；如输入项重复，将导致委托提交失败。			
                //付款行联行号	5	必输项	输入付款账户开户行的5位中行联行编号			
                //付款行机构号	4	非必输项	输入付款账户开户行的4位中行机构代码			
                //付款人账号	12—18位	必输项	需要输入提交为批量委托操作员有权操作的账号。			
                //收款人账号	<=35	必输项	可分别输入中行开户的收款人账号或他行收款人账号，可包含数字、字母或“*/-”。			
                //收款行联行号	5	非必输项	输入中行收款账户开户行的5位联行编号。			
                //收款行机构号	4	非必输项	输入中行收款账户开户行的4位机构代码，如为中行收款且收款账号为14位时，此数据项必输。			
                //收款行名称	70	非必输项	请输入他行收款行的清算行名称。			
                //收款人名称	76	必输项	请输入收款人的准确名称。			
                //收款人地址	70	非必输项				
                //付款货币	3	非必输项	请输入货币代码，如CNY、RMB等；如不填写，则系统将默认为人民币。			
                //付款金额	15，2	必输项	请输入数字，其中整数位最大输入13位，小数位最大2位。			
                //支付手续费账号	35	非必输项	请输入提交批量委托操作员有权操作的账号。如未输入，则系统默认以付款账户支付手续费。			
                //客户指定付款日期	8	必输项	日期格式为：YYYY-MM-DD。			
                //用途及附言	200	非必输项	可自行输入，最多可输入100个汉字。			
                //优先级	1	非必输项	请根据处理需要，选择输入0（普通）或1（特急）。如未输入，则系统默认为0（普通）。			
                //收款人E-MAIL	40	非必输项				
                //收款人手机号	15	非必输项	可输入收款人的手机号码。			
                //收款人传真号	20	非必输项	可输入收款人的传真号码。			
                //是否中行收款标志	1	必输项	必须输入0（他行收款）。			
                //收款行清算行号	12	必输项	必须输入他行收款行的清算行号。			
                //客户优先级	1	非必输项	请根据内部处理需要，选择输入0（普通）或1（优先）。如未输入，则系统默认为0（普通）。
            }
            #endregion

            //获取交易内容信息
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();

                if (aft == AppliableFunctionType.TransferWithIndiv || aft == AppliableFunctionType.TransferWithCorp)
                {
                    content.Append(data.CustomerRef + separatorChar);//客户业务编号（客户应用系统自动产生的业务编号，或客户自己填写的号。字符数<=16）
                    content.Append(string.Empty + separatorChar);//付款行联行号（必填。付款账号的银行编号，由客户填写（4开头5位数字））
                    content.Append(string.Empty + separatorChar);//付款行机构号（非必填。付款账号的机构编号，由客户填写。4位）
                    content.Append(data.PayerAccount + separatorChar);//付款人账号（必填。进行批量委托的操作员有委托权限的账号（12到18位数字），就账号填18位账号，新账号填实际位数，如果非18位账号，系统认为是新账号）
                    content.Append(data.PayeeAccount + separatorChar);//收款人账号（必填。1到35位数字或字母）
                    content.Append(string.Empty + separatorChar);//收款行联行号（---4开头5位数字）
                    content.Append(string.Empty + separatorChar);//收款行机构号（---4位数字，如果为中行收款且账号为14位时，不能为空）
                    content.Append(data.PayeeOpenBank + separatorChar);//收款行名称（中行收款必填。最大文本长度70位）
                    content.Append(data.PayeeName + separatorChar);//收款人名称（必填。最大文本长度76位）
                    content.Append(data.PayeeAddress + separatorChar);//收款人地址（非必填。最大文本长度70位）
                    content.Append(string.Empty + separatorChar);//付款货币（非必填。货币代码，3位）
                    content.Append(data.PayAmount + separatorChar);//付款金额（必填。数字，2位小数点，共15位）
                    content.Append(data.PayFeeNo + separatorChar);//支付手续费账号（非必填。必须是操作员有权限委托的账号。如果为空，默认为付款账号；如果填写，必须为不小于35位账号）
                    content.Append(data.PayDatetime + separatorChar);//客户指定付款日期（必填。必须不小于系统当前日期且不能大于当前系统日期30天，格式：2008-01-01）
                    content.Append(data.Addition + separatorChar);//用途或附言（非必填。最多100个汉字）
                    content.Append((int)data.TChanel + separatorChar);//优先级（非必填。0-普通，1-特急）
                    content.Append(data.Email + separatorChar);//收款人e-mail（非必填。最大文本长度40位）
                    content.Append(string.Empty + separatorChar);//收款人手机（非必填。15位的数字）
                    content.Append(string.Empty + separatorChar);//收款人传真号（非必填。最大文本长度20位）
                    content.Append(((int)data.AccountBankType + 1) % 2 + separatorChar);//是否中行收款标志（必填。0-他行，1-中行）
                    content.Append(data.CNAPSNo + separatorChar);//CNAPS行号（非必填。12位数字）
                    content.Append(string.Empty + separatorChar);//客户优先级（非必填。0-普通，1-优先）
                }
                else if (aft == AppliableFunctionType.TransferOverBankIn)
                {
                    content.Append(data.CustomerRef + separatorChar);//客户业务编号 <=16位,非必输项。可由客户自行填写并避免重复；如输入项重复，将导致委托提交失败。
                    content.Append(data.PayerName + separatorChar);//付款人名称	70,必输项。请输入付款人的准确名称。
                    content.Append(data.PayerAccount + separatorChar);//付款人账号	12—18位,必输项。需要输入提交为批量委托操作员有权操作的账号。
                    content.Append(data.PayeeName + separatorChar);//收款人名称	70,必输项。请输入收款人的准确名称。
                    content.Append(data.PayeeAccount + separatorChar);//收款人账号	<=35,必输项。可分别输入中行开户的收款人账号或他行收款人账号，可包含数字、字母或“*/-”。
                    content.Append(data.PayeeOpenBank + separatorChar);//收款行名称	70,非必输项。请输入他行收款行的清算行名称。
                    content.Append(data.PayAmount + separatorChar);//付款金额（元）	15，2,必输项。请输入数字，其中整数位最大输入13位，小数位最大2位。
                    content.Append(data.PayProtecolNo + separatorChar);//协议号	60,必输项。请输入准确的协议号。
                    if (data.BusinessType == BusinessType.Empty)
                        content.Append(separatorChar);
                    else
                        content.Append(((int)data.BusinessType).ToString().PadLeft(5, '0') + separatorChar);//业务种类	5,必输项。输入5为的业务种类编号
                    content.Append(data.PayFeeNo + separatorChar);//支付手续费账号	35,非必输项。请输入提交批量委托操作员有权操作的账号。如未输入，则系统默认以付款账户支付手续费。
                    content.Append(data.Addition + separatorChar);//用途	200,非必输项。可自行输入，最多可输入100个汉字。
                    content.Append(data.PayDatetime + separatorChar);
                }
                else if (aft == AppliableFunctionType.TransferOverBankOut)
                {
                    content.Append(data.CustomerRef + separatorChar);//客户业务编号 <=16位,非必输项。可由客户自行填写并避免重复；如输入项重复，将导致委托提交失败。
                    content.Append(string.Empty + separatorChar);//付款行联行号
                    content.Append(string.Empty + separatorChar);//付款行机构号
                    content.Append(data.PayerAccount + separatorChar);//付款人账号	12—18位,必输项。需要输入提交为批量委托操作员有权操作的账号。
                    content.Append(data.PayeeAccount + separatorChar);//收款人账号	<=35,必输项。可分别输入中行开户的收款人账号或他行收款人账号，可包含数字、字母或“*/-”。
                    content.Append(string.Empty + separatorChar);//收款行联行号
                    content.Append(string.Empty + separatorChar);//收款行联行号
                    content.Append(data.PayeeOpenBank + separatorChar);//收款行名称	70,非必输项。请输入他行收款行的清算行名称。
                    content.Append(data.PayeeName + separatorChar);//收款人名称	76,必输项。请输入收款人的准确名称。
                    content.Append(string.Empty + separatorChar);//收款人地址
                    content.Append(string.Empty + separatorChar);//付款货币
                    content.Append(data.PayAmount + separatorChar);//付款金额（元）	15，2,必输项。请输入数字，其中整数位最大输入13位，小数位最大2位。
                    content.Append(data.PayFeeNo + separatorChar);//付款行联行号
                    content.Append(data.PayDatetime + separatorChar);//指定付款日期	8,必输项。日期格式为：YYYY-MM-DD。
                    content.Append(data.Addition + separatorChar);//用途	200,非必输项。可自行输入，最多可输入100个汉字。
                    content.Append((int)data.TChanel + separatorChar);//处理优先级	1,非必输项。请根据处理需要，选择输入0（普通）或1（特急）。如未输入，则系统默认为0（普通）。
                    content.Append(data.Email + separatorChar);//收款人E-MAIL	40,非必输项。 
                    content.Append(string.Empty + separatorChar);//收款人手机号
                    content.Append(string.Empty + separatorChar);//收款人传真号
                    content.Append(((int)AccountBankType.OtherBankAccount + 1) % 2 + separatorChar);//是否中行收款标志
                    content.Append(data.PayBankNo + separatorChar);//收款行清算行号	12,必输项。必须输入他行收款行的清算行号。
                    content.Append(string.Empty + separatorChar);//客户优先级
                }
                contentList.Add(content.ToString());
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<ElecTicketRemit> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            if (aft == AppliableFunctionType.ElecTicketRemit)
            {
                //获取交易内容信息
                foreach (var data in dataList)
                {
                    StringBuilder content = new StringBuilder();

                    content.Append((data.TicketType == ElecTicketType.Empty ? string.Empty : data.TicketType.ToString()) + separatorChar);
                    content.Append(data.Amount.ToString() + separatorChar);
                    content.Append(data.RemitDate + separatorChar);
                    content.Append(data.EndDate + separatorChar);
                    content.Append(data.RemitAccount + separatorChar);
                    content.Append(data.ExchangeName + separatorChar);
                    content.Append(data.ExchangeAccount + separatorChar);
                    content.Append(data.ExchangeOpenBankName + separatorChar);
                    content.Append(data.ExchangeOpenBankNo + separatorChar);
                    content.Append(data.PayeeName + separatorChar);
                    content.Append(data.PayeeAccount + separatorChar);
                    content.Append(data.PayeeOpenBankName + separatorChar);
                    content.Append(data.PayeeOpenBankNo + separatorChar);
                    content.Append((data.CanChange == CanChangeType.Empty ? string.Empty : data.CanChange.ToString()) + separatorChar);
                    content.Append(Convert.ToInt32(data.AutoTipExchange).ToString() + separatorChar);
                    content.Append(Convert.ToInt32(data.AutoTipReceiveTicket).ToString() + separatorChar);
                    content.Append(data.Note + separatorChar);
                    contentList.Add(content.ToString());
                }
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<ElecTicketAutoTipExchange> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            if (aft == AppliableFunctionType.ElecTicketTipExchange)
            {
                //获取交易内容信息
                foreach (var data in dataList)
                {
                    StringBuilder content = new StringBuilder();

                    content.Append(data.RemitAccount + separatorChar);
                    content.Append(data.ElecTicketSerialNo + separatorChar);
                    content.Append(data.ExchangeName + separatorChar);
                    content.Append(data.ExchangeAccount + separatorChar);
                    content.Append(data.ExchangeOpenBankName + separatorChar);
                    content.Append(data.ExchangeOpenBankNo + separatorChar);
                    content.Append(data.BillSerialNo + separatorChar);
                    content.Append(data.ContractNo + separatorChar);
                    content.Append(data.Note + separatorChar);
                    contentList.Add(content.ToString());
                }
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<ElecTicketPayMoney> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            if (aft == AppliableFunctionType.ElecTicketPayMoney)
            {
                //获取交易内容信息
                foreach (var data in dataList)
                {
                    StringBuilder content = new StringBuilder();

                    content.Append(data.RemitAccount + separatorChar);
                    content.Append(data.ElecTicketSerialNo + separatorChar);
                    content.Append("RM00" + separatorChar);//data.PayMoneyType + separatorChar);
                    content.Append((data.ProtocolMoneyType == ProtocolMoneyType.Empty ? string.Empty : ((int)data.ProtocolMoneyType).ToString()) + separatorChar);
                    content.Append(data.ProtocolMoneyPercent.ToString() + separatorChar);
                    content.Append(data.ClearType.ToString() + separatorChar);
                    content.Append((string.IsNullOrEmpty(data.PayMoneyDate) ? string.Empty : DateTime.Parse(data.PayMoneyDate).ToString("yyyy/MM/dd")) + separatorChar);
                    content.Append(data.PayMoneyPercent.ToString() + separatorChar);
                    content.Append(data.PayMoneyAccount + separatorChar);
                    content.Append(data.PayMoneyOpenBankName + separatorChar);
                    content.Append(data.PayMoneyOpenBankNo + separatorChar);
                    content.Append(data.StickOnName + separatorChar);
                    content.Append(data.StickOnAccount + separatorChar);
                    content.Append(data.StickOnOpenBankName + separatorChar);
                    content.Append(data.StickOnOpenBankNo + separatorChar);
                    content.Append(data.BillSerialNo + separatorChar);
                    content.Append(data.ContractNo + separatorChar);
                    content.Append(data.Note + separatorChar);
                    contentList.Add(content.ToString());
                }
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<ElecTicketBackNote> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            if (aft == AppliableFunctionType.ElecTicketBackNote)
            {
                //获取交易内容信息
                foreach (var data in dataList)
                {
                    StringBuilder content = new StringBuilder();

                    content.Append(data.RemitAccount + separatorChar);
                    content.Append(data.ElecTicketSerialNo + separatorChar);
                    content.Append(data.BackNotedName + separatorChar);
                    content.Append(data.BackNotedAccount + separatorChar);
                    content.Append(data.BackNotedOpenBankName + separatorChar);
                    content.Append(data.BackNotedOpenBankNo + separatorChar);
                    content.Append(data.Note + separatorChar);
                    contentList.Add(content.ToString());
                }
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<ElecTicketPool> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            if (aft == AppliableFunctionType.ElecTicketPool)
            {
                //获取交易内容信息
                foreach (var data in dataList)
                {
                    StringBuilder content = new StringBuilder();

                    content.Append(data.CustomerRef + separatorChar);
                    content.Append((data.ElecTicketType == ElecTicketType.AC02 ? "03" : "01") + separatorChar);
                    content.Append((data.BankType == AccountBankType.BocAccount ? 1 : 2).ToString() + separatorChar);
                    content.Append(data.ElecTicketSerialNo + separatorChar);
                    content.Append((string.IsNullOrEmpty(data.Amount) ? string.Empty : data.Amount) + separatorChar);
                    content.Append(data.RemitDate + separatorChar);
                    content.Append(data.EndDate + separatorChar);
                    content.Append(data.RemitName + separatorChar);
                    content.Append(data.RemitAccount + separatorChar);
                    content.Append(data.ExchangeName + separatorChar);
                    content.Append(data.ExchangeAccount + separatorChar);
                    content.Append(data.ExchangeBankNo + separatorChar);
                    content.Append(data.ExchangeDate + separatorChar);
                    content.Append(data.PayeeName + separatorChar);
                    content.Append(data.PayeeAccount + separatorChar);
                    content.Append(data.PayeeOpenBankName + separatorChar);
                    content.Append(data.PayeeOpenBankNo + separatorChar);
                    content.Append(data.PreBackNotedPerson + separatorChar);
                    content.Append((data.EndDateOperate == EndDateOperateType.AutoTip ? 2 : 1).ToString() + separatorChar);
                    content.Append((data.BusinessType == ElecTicketPoolBusinessType.InPool2Mortgage ? 4 : 6).ToString() + separatorChar);
                    contentList.Add(content.ToString());
                }
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<TransferGlobal> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            #region 说明
            if (AppliableFunctionType.TransferForeignMoney == aft)
            {
                //客户业务编号（客户应用系统自动产生的业务编号，或客户自己填写的号。字符数<=16）
                //付款行联行号（必填。付款账号的银行编号，由客户填写（4开头5位数字））
                //付款行机构号（非必填。付款账号的机构编号，由客户填写。4位）
                //付款人账号（必填。进行批量委托的操作员有委托权限的账号（12到18位数字），就账号填18位账号，新账号填实际位数，如果非18位账号，系统认为是新账号）
                //收款人账号（必填。1到35位数字或字母）
                //收款行联行号（---4开头5位数字）
                //收款行机构号（---4位数字，如果为中行收款且账号为14位时，不能为空）
                //收款行名称（中行收款必填。最大文本长度70位）
                //收款人名称（必填。最大文本长度76位）
                //收款人地址（非必填。最大文本长度70位）
                //付款货币（非必填。货币代码，3位）
                //付款金额（必填。数字，2位小数点，共15位）
                //支付手续费账号（非必填。必须是操作员有权限委托的账号。如果为空，默认为付款账号；如果填写，必须为不小于35位账号）
                //客户指定付款日期（必填。必须不小于系统当前日期且不能大于当前系统日期30天，格式：2008-01-01）
                //用途或附言（非必填。最多100个汉字）
                //优先级（非必填。0-普通，1-特急）
                //收款人e-mail（非必填。最大文本长度40位）
                //收款人手机（非必填。15位的数字）
                //收款人传真号（非必填。最大文本长度20位）
                //是否中行收款标志（必填。0-他行，1-中行）
                //CNAPS行号（非必填。12位数字）
                //客户优先级（非必填。0-普通，1-优先）
            }
            else if (AppliableFunctionType.TransferOverCountry == aft)
            {
                //客户业务编号	<=16位	非必输项	可由客户自行填写并避免重复；如输入项重复，将导致委托提交失败。			
                //付款行联行号	5	必输项	输入付款账户开户行的5位中行联行编号			
                //付款行机构号	4	非必输项	输入付款账户开户行的4位中行机构代码			
                //付款人账号	12—18位	必输项	需要输入提交为批量委托操作员有权操作的账号。			
                //收款人账号	<=35	必输项	可分别输入中行开户的收款人账号或他行收款人账号，可包含数字、字母或“*/-”。			
                //收款行联行号	5	非必输项	输入中行收款账户开户行的5位联行编号。			
                //收款行机构号	4	非必输项	输入中行收款账户开户行的4位机构代码，如为中行收款且收款账号为14位时，此数据项必输。			
                //收款行名称	70	非必输项	请输入他行收款行的清算行名称。			
                //收款人名称	76	必输项	请输入收款人的准确名称。			
                //收款人地址	70	非必输项				
                //付款货币	3	非必输项	请输入货币代码，如CNY、RMB等；如不填写，则系统将默认为人民币。			
                //付款金额	15，2	必输项	请输入数字，其中整数位最大输入13位，小数位最大2位。			
                //支付手续费账号	35	非必输项	请输入提交批量委托操作员有权操作的账号。如未输入，则系统默认以付款账户支付手续费。			
                //客户指定付款日期	8	必输项	日期格式为：YYYY-MM-DD。			
                //用途及附言	200	非必输项	可自行输入，最多可输入100个汉字。			
                //优先级	1	非必输项	请根据处理需要，选择输入0（普通）或1（特急）。如未输入，则系统默认为0（普通）。			
                //收款人E-MAIL	40	非必输项				
                //收款人手机号	15	非必输项	可输入收款人的手机号码。			
                //收款人传真号	20	非必输项	可输入收款人的传真号码。			
                //是否中行收款标志	1	必输项	必须输入0（他行收款）。			
                //收款行清算行号	12	必输项	必须输入他行收款行的清算行号。			
                //客户优先级	1	非必输项	请根据内部处理需要，选择输入0（普通）或1（优先）。如未输入，则系统默认为0（普通）。
            }
            #endregion

            //获取交易内容信息
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();

                if (aft == AppliableFunctionType.TransferOverCountry || aft == AppliableFunctionType.TransferForeignMoney)
                {
                    content.Append(data.CustomerRef + separatorChar);
                    content.Append(data.PayDate + separatorChar);
                    content.Append("0" + separatorChar);//data.PaymentType + separatorChar);
                    content.Append((int)data.SendPriority + separatorChar);
                    content.Append((data.PaymentCashType == CashType.Empty ? string.Empty : data.PaymentCashType.ToString()) + separatorChar);
                    content.Append(data.RemitAmountString.Replace(",", "") + separatorChar);
                    content.Append(data.SpotAccount + separatorChar);
                    content.Append(data.SpotAmountString.Replace(",", "") + separatorChar);
                    content.Append(data.PurchaseAccount + separatorChar);
                    content.Append(data.PurchaseAmountString.Replace(",", "") + separatorChar);
                    content.Append(data.OtherAccount + separatorChar);
                    content.Append(data.OtherAmountString.Replace(",", "") + separatorChar);
                    content.Append(data.PayFeeAccount + separatorChar);
                    content.Append(data.RemitName + separatorChar);
                    content.Append(data.RemitAddress + separatorChar);
                    content.Append(data.OrgCode + separatorChar);
                    content.Append(data.CorrespondentBankName + separatorChar);
                    content.Append(data.CorrespondentBankAddress + separatorChar);
                    if (aft == AppliableFunctionType.TransferOverCountry)
                        content.Append(data.PayeeOpenBankName + separatorChar);
                    else if (aft == AppliableFunctionType.TransferForeignMoney)
                    {
                        content.Append((((int)data.PayeeOpenBankType + 1) % 2) + separatorChar);
                        content.Append(data.PayeeOpenBankName + separatorChar);
                    }
                    content.Append(data.PayeeOpenBankAddress + separatorChar);
                    content.Append(data.PayeeAccountInCorrespondentBank + separatorChar);
                    content.Append(data.PayeeName + separatorChar);
                    content.Append(data.PayeeAddress + separatorChar);
                    content.Append(data.PayeeAccount + separatorChar);
                    content.Append(data.RemitNote + separatorChar);
                    if (aft == AppliableFunctionType.TransferForeignMoney)
                        content.Append(data.AssumeFeeType.ToString() + separatorChar);
                    else if (aft == AppliableFunctionType.TransferOverCountry)
                        content.Append((int)data.AssumeFeeType + separatorChar);
                    content.Append(data.PayeeCodeofCountry + separatorChar);
                    content.Append(data.PayeeNameofCountry + separatorChar);
                    if (aft == AppliableFunctionType.TransferForeignMoney)
                        content.Append(data.PayFeeType.ToString() + separatorChar);
                    else if (aft == AppliableFunctionType.TransferOverCountry)
                        content.Append((int)data.PayFeeType + separatorChar);
                    if (aft == AppliableFunctionType.TransferForeignMoney)
                        content.Append((int)data.PaymentPropertyType + separatorChar);
                    content.Append(data.DealSerialNoF + separatorChar);
                    content.Append(data.AmountFString.Replace(",", "") + separatorChar);
                    if (aft == AppliableFunctionType.TransferOverCountry)
                        content.Append(data.DealNoteF + separatorChar);
                    content.Append(data.DealSerialNoS + separatorChar);
                    content.Append(data.AmountSString.Replace(",", "") + separatorChar);
                    if (aft == AppliableFunctionType.TransferOverCountry)
                        content.Append(data.DealNoteS + separatorChar);
                    if (aft == AppliableFunctionType.TransferForeignMoney)
                        content.Append((data.IsPayOffLine ? "Y" : "N") + separatorChar);
                    else if (aft == AppliableFunctionType.TransferOverCountry)
                        content.Append(Convert.ToInt16(data.IsPayOffLine) + separatorChar);
                    content.Append(data.ContactNo + separatorChar);
                    content.Append(data.BillSerialNo + separatorChar);
                    content.Append(data.BatchNoOrTNoOrSerialNo + separatorChar);
                    content.Append(data.ProposerName + separatorChar);
                    content.Append(data.Telephone + separatorChar);
                    if ((SystemSettings.Instance.CurrentVersion & VersionType.v405) == VersionType.v405)
                    {
                        if (aft == AppliableFunctionType.TransferOverCountry)
                        {
                            content.Append(data.CorrespondentBankSwiftCode + separatorChar);
                            content.Append(data.PayeeOpenBankSwiftCode + separatorChar);
                        }
                    }
                }
                contentList.Add(content.ToString());
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<UnitivePaymentRMB> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            #region 说明
            if (AppliableFunctionType.TransferForeignMoney == aft)
            {
                //客户业务编号（客户应用系统自动产生的业务编号，或客户自己填写的号。字符数<=16）
                //付款行联行号（必填。付款账号的银行编号，由客户填写（4开头5位数字））
                //付款行机构号（非必填。付款账号的机构编号，由客户填写。4位）
                //付款人账号（必填。进行批量委托的操作员有委托权限的账号（12到18位数字），就账号填18位账号，新账号填实际位数，如果非18位账号，系统认为是新账号）
                //收款人账号（必填。1到35位数字或字母）
                //收款行联行号（---4开头5位数字）
                //收款行机构号（---4位数字，如果为中行收款且账号为14位时，不能为空）
                //收款行名称（中行收款必填。最大文本长度70位）
                //收款人名称（必填。最大文本长度76位）
                //收款人地址（非必填。最大文本长度70位）
                //付款货币（非必填。货币代码，3位）
                //付款金额（必填。数字，2位小数点，共15位）
                //支付手续费账号（非必填。必须是操作员有权限委托的账号。如果为空，默认为付款账号；如果填写，必须为不小于35位账号）
                //客户指定付款日期（必填。必须不小于系统当前日期且不能大于当前系统日期30天，格式：2008-01-01）
                //用途或附言（非必填。最多100个汉字）
                //优先级（非必填。0-普通，1-特急）
                //收款人e-mail（非必填。最大文本长度40位）
                //收款人手机（非必填。15位的数字）
                //收款人传真号（非必填。最大文本长度20位）
                //是否中行收款标志（必填。0-他行，1-中行）
                //CNAPS行号（非必填。12位数字）
                //客户优先级（非必填。0-普通，1-优先）
            }
            else if (AppliableFunctionType.TransferOverCountry == aft)
            {
                //客户业务编号	<=16位	非必输项	可由客户自行填写并避免重复；如输入项重复，将导致委托提交失败。			
                //付款行联行号	5	必输项	输入付款账户开户行的5位中行联行编号			
                //付款行机构号	4	非必输项	输入付款账户开户行的4位中行机构代码			
                //付款人账号	12—18位	必输项	需要输入提交为批量委托操作员有权操作的账号。			
                //收款人账号	<=35	必输项	可分别输入中行开户的收款人账号或他行收款人账号，可包含数字、字母或“*/-”。			
                //收款行联行号	5	非必输项	输入中行收款账户开户行的5位联行编号。			
                //收款行机构号	4	非必输项	输入中行收款账户开户行的4位机构代码，如为中行收款且收款账号为14位时，此数据项必输。			
                //收款行名称	70	非必输项	请输入他行收款行的清算行名称。			
                //收款人名称	76	必输项	请输入收款人的准确名称。			
                //收款人地址	70	非必输项				
                //付款货币	3	非必输项	请输入货币代码，如CNY、RMB等；如不填写，则系统将默认为人民币。			
                //付款金额	15，2	必输项	请输入数字，其中整数位最大输入13位，小数位最大2位。			
                //支付手续费账号	35	非必输项	请输入提交批量委托操作员有权操作的账号。如未输入，则系统默认以付款账户支付手续费。			
                //客户指定付款日期	8	必输项	日期格式为：YYYY-MM-DD。			
                //用途及附言	200	非必输项	可自行输入，最多可输入100个汉字。			
                //优先级	1	非必输项	请根据处理需要，选择输入0（普通）或1（特急）。如未输入，则系统默认为0（普通）。			
                //收款人E-MAIL	40	非必输项				
                //收款人手机号	15	非必输项	可输入收款人的手机号码。			
                //收款人传真号	20	非必输项	可输入收款人的传真号码。			
                //是否中行收款标志	1	必输项	必须输入0（他行收款）。			
                //收款行清算行号	12	必输项	必须输入他行收款行的清算行号。			
                //客户优先级	1	非必输项	请根据内部处理需要，选择输入0（普通）或1（优先）。如未输入，则系统默认为0（普通）。
            }
            #endregion

            //获取交易内容信息
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();

                content.Append(data.PayerAccount + separatorChar);
                content.Append(data.PayerName + separatorChar);
                content.Append(data.PayeeAccount + separatorChar);
                content.Append(data.PayeeName + separatorChar);
                content.Append(((int)data.BankType + 1) % 2 + separatorChar);
                content.Append(data.PayeeCNAPS + separatorChar);
                content.Append(data.PayeeOpenBankName + separatorChar);
                content.Append(data.NominalPayerAccount + separatorChar);
                content.Append(data.NominalPayerName + separatorChar);
                //content.Append(data.NominalPayerBankLinkNo + separatorChar);
                //content.Append(data.NominalPayerOpenBankName + separatorChar);
                content.Append(data.Amount.Replace(",", "") + separatorChar);
                content.Append(data.Purpose + separatorChar);
                content.Append((int)data.UnitivePaymentType + separatorChar);
                content.Append(data.OrderPayDateTime + separatorChar);
                content.Append(data.CustomerBusinissNo + separatorChar);
                content.Append((int)data.TransferChanelType + separatorChar);
                content.Append((data.IsTipPayee ? 0 : 1) + separatorChar);
                content.Append(data.TipPayeePhone + separatorChar);

                contentList.Add(content.ToString());
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<SpplyFinancingApply> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            if (aft == AppliableFunctionType.ApplyofFranchiserFinancing)
            {
                //获取交易内容信息
                foreach (var data in dataList)
                {
                    StringBuilder content = new StringBuilder();

                    content.Append("BOT" + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.ContractOrOrderNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(DataConvertHelper.Instance.FormatDateTimeFromInt(data.OrderDate) + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(((int)data.ContractOrOrderCashType).ToString().PadLeft(3, '0') + Environment.NewLine);
                    content.Append(string.Format("0,{0}", data.ContractOrOrderAmount) + Environment.NewLine);
                    content.Append("V" + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(DataConvertHelper.Instance.FormatDateTimeFromInt(data.DeliveryDate) + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(((int)data.SettlementType).ToString() + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.TaxInvoiceNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.ReceiptNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.RiskTakingLetterNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.GoodsDesc + Environment.NewLine);
                    content.Append(string.Format("0,{0}", data.ApplyAmount) + Environment.NewLine);
                    content.Append("V" + Environment.NewLine);
                    content.Append(string.Format("0,{0}", data.ApplyDays) + Environment.NewLine);
                    content.Append("V" + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.AgreementNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append((data.InterestFloatType == InterestFloatType.Empty ? string.Empty : ((int)data.InterestFloatType).ToString()) + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.InterestFloatingPercent + Environment.NewLine);
                    content.Append("-1,0");

                    contentList.Add(content.ToString());
                }
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<SpplyFinancingOrder> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            //获取交易内容信息
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();

                if (aft == AppliableFunctionType.PurchaserOrder)
                {
                    content.Append("BOT" + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.OrderNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(((int)data.CashType).ToString().PadLeft(3, '0') + Environment.NewLine);
                    content.Append(string.Format("0,{0}", data.Amount) + Environment.NewLine);
                    content.Append("V" + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.ERPCode + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.CustomerApplyNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(DataConvertHelper.Instance.FormatDateTimeFromInt(data.PayDate) + Environment.NewLine);
                    content.Append("-1,0");
                }
                else if (aft == AppliableFunctionType.SellerOrder)
                {
                    content.Append("BOT" + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.OrderNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(((int)data.CashType).ToString().PadLeft(3, '0') + Environment.NewLine);
                    content.Append(string.Format("0,{0}", data.Amount) + Environment.NewLine);
                    content.Append("V" + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.CustomerName + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(DataConvertHelper.Instance.FormatDateTimeFromInt(data.PayDate) + Environment.NewLine);
                    content.Append("-1,0");
                }
                else if (aft == AppliableFunctionType.PurchaserOrderMgr
                    || aft == AppliableFunctionType.SellerOrderMgr)
                {
                    content.Append("BOT" + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.OrderNo + Environment.NewLine);
                    content.Append(string.Format("0,{0}", data.Amount) + Environment.NewLine);
                    content.Append("V" + Environment.NewLine);
                    content.Append("-1,0");
                }

                contentList.Add(content.ToString());
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<SpplyFinancingBill> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            //获取交易内容信息
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();

                if (aft == AppliableFunctionType.BillofDebtReceivablePurchaser
                    || aft == AppliableFunctionType.BillofDebtReceivableSeller)
                {
                    content.Append("BOT" + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.BillSerialNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.ContractNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.CustomerNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.CustomerName + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(((int)data.CashType).ToString().PadLeft(3, '0') + Environment.NewLine);
                    content.Append(string.Format("0,{0}", data.Amount) + Environment.NewLine);
                    content.Append("V" + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(DataConvertHelper.Instance.FormatDateTimeFromInt(data.BillDate) + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(DataConvertHelper.Instance.FormatDateTimeFromInt(data.StartDate) + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(DataConvertHelper.Instance.FormatDateTimeFromInt(data.EndDate) + Environment.NewLine);
                    content.Append("-1,0");
                }

                contentList.Add(content.ToString());
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<SpplyFinancingPayOrReceipt> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            //获取交易内容信息
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();

                if (aft == AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser)
                {
                    content.Append("BOT" + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.BillSerialNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.CustomerNo + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(data.CustomerName + Environment.NewLine);
                    content.Append("1,0" + Environment.NewLine);
                    content.Append(((int)data.CashType).ToString().PadLeft(3, '0') + Environment.NewLine);
                    content.Append(string.Format("0,{0}", data.PayAmountForThisTime) + Environment.NewLine);
                    content.Append("V" + Environment.NewLine);
                    content.Append("-1,0");
                }

                contentList.Add(content.ToString());
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<AgentExpress> dataList, BatchHeader batch, string separatorChar, double amount)
        {
            List<string> contentList = new List<string>();
            #region 批信息
            #region
            /*客户业务编号
                      付款行联行号（代收没有）
                      付款人账号
                      收款行（代收没有）
                      货币名称
                      批总金额
                      批总笔数
                      用途
                      付款日期
                      附言*/
            #endregion
            string str = string.Empty;
            str += batch.ProtecolNo + separatorChar;
            if (AppliableFunctionType.AgentExpressOut == aft)
                str += batch.BankNo + separatorChar;
            str += batch.Payer.Account + separatorChar;
            if (AppliableFunctionType.AgentExpressOut == aft)
                str += (int)batch.BankType + separatorChar;
            str += "CNY" + separatorChar;
            str += amount + separatorChar;
            str += dataList.Count.ToString() + separatorChar;
            str += batch.UseType + separatorChar;
            str += batch.TransferDatetime.Year + batch.TransferDatetime.Month.ToString().PadLeft(2, '0') + batch.TransferDatetime.Day.ToString().PadLeft(2, '0') + separatorChar;
            str += batch.Addtion + separatorChar;
            contentList.Add(str);
            #endregion

            #region 笔信息
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();
                #region 笔信息
                #region
                /*收款行行号(必填，中行卡时，必填写2位省行标识，他行卡时，必须填写12位CNAPS号。)
                      金额(必填,最长14位，含小数点及2位小数)
                      收款人账号(必填，如果卡类型为1，收款人账号有19位借记卡和最长22位存折账号；如果卡类型为4，收款人账号长度是16位。)
                      收款人姓名(必填,最长20位)
                      收款人证件类型("非必填，最长2位，同BANCS证件类型
                                                01－居民身份证
                                                02－临时身份证
                                                03－护照
                                                04－户口簿
                                                05－军人身份证
                                                06－武装警察身份证
                                                08－外交人员身份证
                                                09－外国人居留许可证
                                                10－边民出入境通行证
                                                11－对私其它
                                                21－企业法人营业执照 
                                                22－企业营业执照 
                                                30－驻华机构登记证
                                                31－个体工商户营业执照
                                                33－组织机构代码证
                                                47－港澳居民来往内地通行证（香港）
                                                48－港澳居民来往内地通行证（澳门）
                                                49－台湾居民来往大陆通行证"
                                                )
                      收款人证件号(非必填，最长32位)
                      协议号(付款行为中行时非必填，为他行时必填多方协议号。最长60位)(代收才有)*/
                #endregion
                if (batch.BankType == AgentTransferBankType.Boc)
                    content.Append((int)data.Province + separatorChar);
                else if (batch.BankType == AgentTransferBankType.Other)
                    content.Append(data.BankNo + separatorChar);
                content.Append(data.Amount + separatorChar);
                content.Append(data.AccountNo + separatorChar);
                content.Append(data.AccountName + separatorChar);
                if (data.CertifyPaperType == AgentExpressCertifyPaperType.Empty)
                    content.Append(separatorChar);
                else
                    content.Append(((int)data.CertifyPaperType).ToString().PadLeft(2, '0') + separatorChar);
                content.Append(data.CertifyPaperNo + separatorChar);

                if (AppliableFunctionType.AgentExpressIn == aft)
                {
                    content.Append(data.ProtecolNo + separatorChar);
                }
                content.Append(data.UsageType == AgentExpressFunctionType.Empty ? string.Empty : data.UsageType.ToString());
                if (aft == AppliableFunctionType.AgentExpressOut)
                    content.Append(separatorChar);
                #endregion
                contentList.Add(content.ToString());
            }
            #endregion
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<AgentNormal> dataList, BatchHeader batch, string separatorChar, double amount)
        {
            List<string> contentList = new List<string>();
            #region 批信息
            #region
            /*客户业务编号
                      付款行联行号（代收没有）
                      付款人账号
                      收款行（代收没有）
                      货币名称
                      批总金额
                      批总笔数
                      用途
                      付款日期
                      附言*/
            #endregion
            string str = string.Empty;
            str += batch.ProtecolNo + separatorChar;
            str += batch.BankNo + separatorChar;
            str += batch.Payer.Account + separatorChar;
            str += "CNY" + separatorChar;
            str += amount + separatorChar;
            str += dataList.Count.ToString() + separatorChar;
            str += (int)batch.CardType + separatorChar;
            str += (aft == AppliableFunctionType.AgentNormalIn ? "0" : batch.UseType) + separatorChar;
            str += batch.PayFeeNo + separatorChar;
            str += batch.TransferDatetime.Year + batch.TransferDatetime.Month.ToString().PadLeft(2, '0') + batch.TransferDatetime.Day.ToString().PadLeft(2, '0') + separatorChar;
            str += batch.Addtion + separatorChar;
            contentList.Add(str);
            #endregion

            #region 笔信息
            //获取交易内容信息
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();
                #region
                /* 收款行编号
                     * 收款行行名
                     * 货币名称
                     * 金额
                     * 收款人账号
                     * 收款人姓名
                     * 收款人证件类型
                     * 收款人证件号
                     * 用途
                     * 付款合同编号(代发没有)
                     */
                #endregion
                str = string.Empty;

                content.Append(data.BankNo + separatorChar);
                content.Append(data.BankName + separatorChar);
                content.Append("CNY" + separatorChar);
                content.Append(data.Amount + separatorChar);
                content.Append(data.AccountNo + separatorChar);
                content.Append(data.AccountName + separatorChar);
                if (data.CertifyPaperType == AgentNormalCertifyPaperType.Empty)
                    content.Append(separatorChar);
                else
                    content.Append(((int)data.CertifyPaperType).ToString().PadLeft(2, '0') + separatorChar);
                content.Append(data.CertifyPaperNo + separatorChar);
                if (aft == AppliableFunctionType.AgentNormalOut)
                {
                    if (data.UseType == AgentNormalFunctionType.Empty)
                        content.Append(separatorChar);
                    else
                        content.Append((int)data.UseType + separatorChar);
                }
                else content.Append(data.UseType_In + separatorChar);
                if (AppliableFunctionType.AgentNormalIn == aft)
                    content.Append(data.ProtecolNo + separatorChar);

                contentList.Add(content.ToString());
            }
            #endregion
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<InitiativeAllot> dataList, BatchHeader batch, string separatorChar, double amount)
        {
            List<string> contentList = new List<string>();
            #region 批信息
            #region
            /*客户业务编号
                      付款行联行号（代收没有）
                      付款人账号
                      收款行（代收没有）
                      货币名称
                      批总金额
                      批总笔数
                      用途
                      付款日期
                      附言*/
            #endregion
            string str = string.Empty;
            str += batch.ProtecolNo + separatorChar;
            str += amount.ToString() + separatorChar;
            str += dataList.Count.ToString() + separatorChar;
            str += batch.TransferDatetime.Year + batch.TransferDatetime.Month.ToString().PadLeft(2, '0') + batch.TransferDatetime.Day.ToString().PadLeft(2, '0') + separatorChar;
            str += CashType.CNY.ToString() + separatorChar;
            contentList.Add(str);
            #endregion

            #region 笔信息
            //获取交易内容信息
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();

                str = string.Empty;

                content.Append(data.AccountOut + separatorChar);
                content.Append(data.NameOut + separatorChar);
                content.Append(data.AccountIn + separatorChar);
                content.Append(data.NameIn + separatorChar);
                content.Append(CashType.CNY.ToString() + separatorChar);
                content.Append(data.Amount + separatorChar);
                content.Append(data.Addition + separatorChar);

                contentList.Add(content.ToString());
            }
            #endregion
            return contentList;
        }

        public List<string> CreateContentInfo(FunctionInSettingType fst, IList<PayeeInfo> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            //获取交易内容信息
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();

                if (fst == FunctionInSettingType.PayeeMg)
                {
                    if (data.BankType == AccountBankType.Empty)
                        content.Append(1 + separatorChar);
                    else
                        content.Append(((((int)data.BankType) + 1) % 2) + separatorChar);//收款行类型	1	"1-中行,0-他行"	必填
                    content.Append(data.SerialNo + separatorChar);//收款人编号	<=10	客户填写，客户自行填写。如果客户填写收款人编号，则在一个客户下不能允许重复	非必填
                    content.Append(data.Account + separatorChar);//收款人账号	<=35	"中行收款人账号为18位数字账号。他行不检查。"	必填
                    content.Append(data.Name + separatorChar);//收款人名称	<=76		必填
                    content.Append((data.BankType == AccountBankType.BocAccount ? string.Empty : data.OpenBankName) + separatorChar);//收款人开户行	<=70	客户填写，导入时不检查收款人开户行名称是否正确。	必填
                    content.Append(data.CNAPSNo + separatorChar);//收款行CNAPS行号	12	他行收款时，收款行CNAPS行号必须填写。	非必填
                    if (data.AccountType == AccountCategoryType.Empty)
                        content.Append(separatorChar);
                    else
                        content.Append(((int)data.AccountType).ToString().PadLeft(2, '0') + separatorChar);//收款账户类型	
                    content.Append(data.CNAPSNoR + separatorChar);//清算行号	11		非必填
                    content.Append(data.ClearBankName + separatorChar);///清算行名	3	
                    if (data.CertifyPaperType == AgentExpressCertifyPaperType.Empty)
                        content.Append(separatorChar);
                    else
                        content.Append(((int)data.CertifyPaperType).ToString().PadLeft(2, '0') + separatorChar);//证件类型	11		非必填
                    content.Append(data.CertifyPaperNo + separatorChar);///证件号码	3	
                    content.Append(data.Address + separatorChar);//收款人地址	<=70		非必填
                    content.Append(data.Email + separatorChar);//收款人e-mail	<=30		非必填
                    content.Append(data.Telephone + separatorChar);//收款人手机号	<=15		非必填
                    content.Append(data.Fax + separatorChar);//收款人传真号	<=20		非必填
                }
                else if (fst == FunctionInSettingType.AgentExpressInPayerMg)
                {
                    if (data.BankType == AccountBankType.Empty)
                        content.Append(1 + separatorChar);
                    else
                        content.Append(((((int)data.BankType) + 1) % 2) + separatorChar);//收款行类型	1	"1-中行,0-他行"	必填
                    content.Append(data.SerialNo + separatorChar);//收款人编号	<=10	客户填写，客户自行填写。如果客户填写收款人编号，则在一个客户下不能允许重复	非必填
                    content.Append(data.Account + separatorChar);//收款人账号	<=35	"中行收款人账号为18位数字账号。他行不检查。"	必填
                    content.Append(data.Name + separatorChar);//收款人名称	<=76		必填
                    content.Append(data.OpenBankName + separatorChar);//收款人开户行	<=70	客户填写，导入时不检查收款人开户行名称是否正确。	必填
                    content.Append(data.CNAPSNo + separatorChar);//收款行CNAPS行号	12	他行收款时，收款行CNAPS行号必须填写。	非必填
                    if (data.AccountType == AccountCategoryType.Empty)
                        content.Append(separatorChar);
                    else
                        content.Append(((int)data.AccountType).ToString().PadLeft(2, '0') + separatorChar);//收款账户类型	
                    if (data.CertifyPaperType == AgentExpressCertifyPaperType.Empty)
                        content.Append(separatorChar);
                    else
                        content.Append(((int)data.CertifyPaperType).ToString().PadLeft(2, '0') + separatorChar);//证件类型	11		非必填
                    content.Append(data.CertifyPaperNo + separatorChar);///证件号码	3	
                    content.Append(data.Address + separatorChar);//收款人地址	<=70		非必填
                    content.Append(data.Email + separatorChar);//收款人e-mail	<=30		非必填
                    content.Append(data.Telephone + separatorChar);//收款人手机号	<=15		非必填
                    content.Append(data.Fax + separatorChar);//收款人传真号	<=20		非必填
                    content.Append(data.ProtecolNo + separatorChar);//协议号
                }
                contentList.Add(content.ToString());
            }
            return contentList;
        }

        public List<string> CreateContentInfo(FunctionInSettingType fst, IList<ElecTicketRelationAccount> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            if (fst == FunctionInSettingType.ElecTicketRelateAccountMg)
            {
                //获取交易内容信息
                foreach (var data in dataList)
                {
                    StringBuilder content = new StringBuilder();

                    content.Append(data.Account + separatorChar);
                    content.Append(data.Name + separatorChar);
                    content.Append(data.OpenBankName + separatorChar);
                    content.Append(data.OpenBankNo + separatorChar);
                    content.Append(((int)data.PersonType).ToString() + separatorChar);
                    content.Append(data.SerialNo + separatorChar);
                    content.Append(data.Tel_First + separatorChar);
                    content.Append(data.Email_First + separatorChar);
                    content.Append(data.Tel_Second + separatorChar);
                    content.Append(data.Email_Second + separatorChar);
                    contentList.Add(content.ToString());
                }
            }
            return contentList;
        }

        public List<string> CreateContentInfo(FunctionInSettingType fst, IList<PayeeInfo4TransferGlobal> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            if (fst == FunctionInSettingType.OverCountryPayeeMg)
            {
                //获取交易内容信息
                foreach (var data in dataList)
                {
                    StringBuilder content = new StringBuilder();

                    content.Append(((int)data.AccountType) + separatorChar);
                    content.Append(data.Account + separatorChar);
                    content.Append(data.Name + separatorChar);
                    content.Append(data.Address + separatorChar);
                    content.Append(data.CodeofCountry + separatorChar);
                    content.Append(data.NameofCountry + separatorChar);
                    content.Append(data.OpenBankName + separatorChar);
                    content.Append(string.Empty + separatorChar);
                    content.Append(data.OpenBankAddress + separatorChar);
                    content.Append(data.CorrespondentBankName + separatorChar);
                    content.Append(string.Empty + separatorChar);
                    content.Append(data.CorrespondentBankAddress + separatorChar);
                    content.Append(data.AccountInCorrespondentBank + separatorChar);
                    content.Append(data.SerialNo + separatorChar);
                    content.Append(data.Telephone + separatorChar);
                    content.Append(data.Fax + separatorChar);
                    content.Append(data.Email);
                    contentList.Add(content.ToString());
                }
            }
            return contentList;
        }

        public List<string> CreateContentInfoBar(AppliableFunctionType aft, IList<TransferGlobal> dataList, string separactorChar)
        {
            List<string> contentList = new List<string>();
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();

                if (aft == AppliableFunctionType.TransferOverCountry4Bar)
                {
                    #region
                    content.Append(data.SendPriority == TransferChanelType.Express ? 2 : 1);
                    content.Append((!string.IsNullOrEmpty(data.RemitAmount) ? (double.Parse(data.RemitAmount) * 100).ToString() : string.Empty).PadLeft(16, ' '));
                    content.Append((!string.IsNullOrEmpty(data.RemitName) ? data.RemitName.Trim() : string.Empty).PadRight(140 - GetByteLength(data.RemitName) + (!string.IsNullOrEmpty(data.RemitName) ? data.RemitName.Length : 0), ' '));
                    content.Append((!string.IsNullOrEmpty(data.RemitAddress) ? data.RemitAddress.Trim() : string.Empty).PadRight(140 - GetByteLength(data.RemitAddress) + (!string.IsNullOrEmpty(data.RemitAddress) ? data.RemitAddress.Length : 0), ' '));
                    content.Append((!string.IsNullOrEmpty(data.OrgCode) ? data.OrgCode.Trim() : string.Empty).PadRight(10, ' '));
                    content.Append((!string.IsNullOrEmpty(data.CorrespondentBankSwiftCode) ? data.CorrespondentBankSwiftCode.Trim() : string.Empty).PadRight(11, ' '));
                    content.Append((!string.IsNullOrEmpty(data.CorrespondentBankName) ? data.CorrespondentBankName.Trim() : string.Empty).PadRight(140 - GetByteLength(data.CorrespondentBankName) + (!string.IsNullOrEmpty(data.CorrespondentBankName) ? data.CorrespondentBankName.Length : 0), ' '));
                    content.Append((!string.IsNullOrEmpty(data.CorrespondentBankAddress) ? data.CorrespondentBankAddress.Trim() : string.Empty).PadRight(140 - GetByteLength(data.CorrespondentBankAddress) + (!string.IsNullOrEmpty(data.CorrespondentBankAddress) ? data.CorrespondentBankAddress.Length : 0), ' '));
                    content.Append((!string.IsNullOrEmpty(data.PayeeOpenBankSwiftCode) ? data.PayeeOpenBankSwiftCode.Trim() : string.Empty).PadRight(11, ' '));
                    content.Append((!string.IsNullOrEmpty(data.PayeeOpenBankName) ? data.PayeeOpenBankName.Trim() : string.Empty).PadRight(140 - GetByteLength(data.PayeeOpenBankName) + (!string.IsNullOrEmpty(data.PayeeOpenBankName) ? data.PayeeOpenBankName.Length : 0), ' '));
                    content.Append((!string.IsNullOrEmpty(data.PayeeOpenBankAddress) ? data.PayeeOpenBankAddress.Trim() : string.Empty).PadRight(140 - GetByteLength(data.PayeeOpenBankAddress) + (!string.IsNullOrEmpty(data.PayeeOpenBankAddress) ? data.PayeeOpenBankAddress.Length : 0), ' '));
                    content.Append((!string.IsNullOrEmpty(data.PayeeAccountInCorrespondentBank) ? data.PayeeAccountInCorrespondentBank.Trim() : string.Empty).PadRight(34 - GetByteLength(data.PayeeAccountInCorrespondentBank) + (!string.IsNullOrEmpty(data.PayeeAccountInCorrespondentBank) ? data.PayeeAccountInCorrespondentBank.Length : 0), ' '));
                    content.Append((!string.IsNullOrEmpty(data.PayeeName) ? data.PayeeName.Trim() : string.Empty).PadRight(140, ' '));
                    content.Append((!string.IsNullOrEmpty(data.PayeeAddress) ? data.PayeeAddress.Trim() : string.Empty).PadRight(140, ' '));
                    content.Append((!string.IsNullOrEmpty(data.PayeeAccount) ? data.PayeeAccount.Trim() : string.Empty).PadRight(34, ' '));
                    content.Append((!string.IsNullOrEmpty(data.RemitNote) ? data.RemitNote.Trim() : string.Empty).PadRight(140, ' '));
                    content.Append((data.AssumeFeeType != AssumeFeeType.Empty ? ((int)data.AssumeFeeType).ToString() : string.Empty).PadRight(1, ' '));
                    content.Append((!string.IsNullOrEmpty(data.PayeeCodeofCountry) ? data.PayeeCodeofCountry.Trim() : string.Empty).PadRight(3, ' '));
                    content.Append((!string.IsNullOrEmpty(data.PayeeNameofCountry) ? data.PayeeNameofCountry.Trim() : string.Empty).PadRight(30 - GetByteLength(data.PayeeNameofCountry) + (!string.IsNullOrEmpty(data.PayeeNameofCountry) ? data.PayeeNameofCountry.Length : 0), ' '));
                    content.Append((data.PayFeeType != PayFeeType.Empty ? ((int)data.PayFeeType).ToString() : string.Empty).PadRight(1, ' '));
                    content.Append((!string.IsNullOrEmpty(data.DealSerialNoF) ? data.DealSerialNoF.Trim() : string.Empty).PadRight(6, ' '));
                    content.Append((string.IsNullOrEmpty(data.AmountF) ? string.Empty : (double.Parse(data.AmountFString) * 100).ToString()).PadLeft(15, ' '));
                    content.Append((!string.IsNullOrEmpty(data.DealNoteF) ? data.DealNoteF.Trim() : string.Empty).PadRight(50 - GetByteLength(data.DealNoteF) + data.DealNoteF.Length, ' '));
                    content.Append((!string.IsNullOrEmpty(data.DealSerialNoS) ? data.DealSerialNoS.Trim() : string.Empty).PadRight(6 - GetByteLength(data.DealSerialNoS) + (!string.IsNullOrEmpty(data.DealSerialNoS) ? data.DealSerialNoS.Length : 0), ' '));
                    content.Append((string.IsNullOrEmpty(data.AmountS) ? string.Empty : (double.Parse(data.AmountSString) * 100).ToString()).PadLeft(15, ' '));
                    content.Append((!string.IsNullOrEmpty(data.DealNoteS) ? data.DealNoteS.Trim() : string.Empty).PadRight(50 - GetByteLength(data.DealNoteS) + data.DealNoteS.Length, ' '));
                    content.Append((data.IsPayOffLine ? "Y" : "N"));
                    content.Append((!string.IsNullOrEmpty(data.ContactNo) ? data.ContactNo.Trim() : string.Empty).PadRight(20 - GetByteLength(data.ContactNo) + (!string.IsNullOrEmpty(data.ContactNo) ? data.ContactNo.Length : 0), ' '));
                    content.Append((!string.IsNullOrEmpty(data.BillSerialNo) ? data.BillSerialNo.Trim() : string.Empty).PadRight(35 - GetByteLength(data.BillSerialNo) + (!string.IsNullOrEmpty(data.BillSerialNo) ? data.BillSerialNo.Length : 0), ' '));
                    content.Append((!string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo) ? data.BatchNoOrTNoOrSerialNo.Trim() : string.Empty).PadRight(20 - GetByteLength(data.BatchNoOrTNoOrSerialNo) + (!string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo) ? data.BatchNoOrTNoOrSerialNo.Length : 0), ' '));
                    content.Append((!string.IsNullOrEmpty(data.ProposerName) ? data.ProposerName.Trim() : string.Empty).PadRight(20 - GetByteLength(data.ProposerName) + (!string.IsNullOrEmpty(data.ProposerName) ? data.ProposerName.Length : 0), ' '));
                    content.Append((!string.IsNullOrEmpty(data.Telephone) ? data.Telephone.Trim() : string.Empty).PadRight(15 - GetByteLength(data.Telephone) + (!string.IsNullOrEmpty(data.Telephone) ? data.Telephone.Length : 0), ' '));
                    content.Append(separactorChar);
                    #endregion
                }
                else if (aft == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    if (data.PayeeOpenBankType == AccountBankType.BocAccount)
                    {
                        #region
                        content.Append((!string.IsNullOrEmpty(data.PayeeAccount) ? data.PayeeAccount : string.Empty).PadRight(25, ' '));
                        content.Append((!string.IsNullOrEmpty(data.PayeeName) ? data.PayeeName : string.Empty).PadRight(58 - GetByteLength(data.PayeeName) + (!string.IsNullOrEmpty(data.PayeeName) ? data.PayeeName.Length : 0), ' '));
                        content.Append((!string.IsNullOrEmpty(data.RemitAmount) ? (double.Parse(data.RemitAmount) * 100).ToString() : string.Empty).PadLeft(16, ' '));
                        content.Append((data.PayeeOpenBankType == AccountBankType.BocAccount ? ((int)data.Province).ToString() : data.PayeeOpenBankSwiftCode).PadRight(14, ' '));
                        content.Append((data.PayeeOpenBankType == AccountBankType.BocAccount && data.CertifyPaperType != AgentExpressCertifyPaperType.Empty ? ((int)data.CertifyPaperType).ToString().PadLeft(2, '0') : string.Empty).PadRight(2, ' '));
                        content.Append((data.PayeeOpenBankType == AccountBankType.BocAccount && !string.IsNullOrEmpty(data.CertifyPaperNo) ? data.CertifyPaperNo : string.Empty).PadRight(32, ' '));
                        content.Append(string.Empty.PadRight(80, ' '));
                        content.Append(string.Empty.PadRight(60, ' '));
                        content.Append(string.Empty.PadRight(40, ' '));
                        content.Append(string.Empty.PadRight(1, ' '));
                        content.Append(string.Empty.PadLeft(16 + 16, ' '));
                        content.Append(string.Empty.PadRight(2 + 5 + 80 + 100, ' '));
                        content.Append(separactorChar);
                        #endregion
                    }
                    else
                    {
                        #region
                        content.Append(string.Empty.PadLeft(2, ' '));
                        content.Append((!string.IsNullOrEmpty(data.PayeeAccount) ? data.PayeeAccount.Trim() : string.Empty).PadRight(40, ' '));
                        content.Append((!string.IsNullOrEmpty(data.PayeeName) ? data.PayeeName.Trim() : string.Empty).PadRight(70 - GetByteLength(data.PayeeName) + (!string.IsNullOrEmpty(data.PayeeName) ? data.PayeeName.Length : 0), ' '));
                        content.Append((string.IsNullOrEmpty(data.RemitAmount) ? string.Empty : (double.Parse(data.RemitAmount) * 100).ToString()).PadLeft(16, ' '));
                        content.Append((!string.IsNullOrEmpty(data.PayeeOpenBankSwiftCode) ? data.PayeeOpenBankSwiftCode.Trim() : string.Empty).PadRight(12, ' '));
                        content.Append((!string.IsNullOrEmpty(data.PayeeOpenBankName) ? data.PayeeOpenBankName.Trim() : string.Empty).PadRight(140 - GetByteLength(data.PayeeOpenBankName) + (!string.IsNullOrEmpty(data.PayeeOpenBankName) ? data.PayeeOpenBankName.Length : 0), ' '));
                        content.Append(data.BarBusinessType == BarBusinessType.Empty ? "  " : ((int)data.BarBusinessType).ToString().PadLeft(2, '0'));// 业务种类
                        content.Append(data.BarApplyFlagType == BarApplyFlagType.Empty ? " " : data.BarApplyFlagType.ToString().Trim());// 申报标示
                        content.Append((!string.IsNullOrEmpty(data.RemitNote) ? data.RemitNote.Trim() : string.Empty).PadRight(140 - GetByteLength(data.RemitNote) + (!string.IsNullOrEmpty(data.RemitNote) ? data.RemitNote.Length : 0), ' '));
                        content.Append((!string.IsNullOrEmpty(data.CustomerRef) ? data.CustomerRef.Trim() : string.Empty).PadRight(16, ' '));
                        content.Append("0");
                        content.Append(data.SendPriority == TransferChanelType.Express ? 2 : 1);
                        content.Append((!string.IsNullOrEmpty(data.SpotAccount) ? data.SpotAccount.Trim() : string.Empty).PadRight(20, ' '));
                        content.Append((string.IsNullOrEmpty(data.SpotAmount) ? string.Empty : (double.Parse(data.SpotAmount) * 100).ToString()).PadLeft(16, ' '));
                        content.Append((!string.IsNullOrEmpty(data.PurchaseAccount) ? data.PurchaseAccount.Trim() : string.Empty).PadRight(20, ' '));
                        content.Append((string.IsNullOrEmpty(data.PurchaseAmount) ? "0" : (double.Parse(data.PurchaseAmount) * 100).ToString()).PadLeft(16, ' '));
                        content.Append((!string.IsNullOrEmpty(data.OtherAccount) ? data.OtherAccount.Trim() : string.Empty).PadRight(20, ' '));
                        content.Append((string.IsNullOrEmpty(data.OtherAmount) ? "0" : (double.Parse(data.OtherAmount) * 100).ToString()).PadLeft(16, ' '));
                        content.Append(string.Empty.PadRight(20, ' '));
                        content.Append((!string.IsNullOrEmpty(data.RemitAddress) ? data.RemitAddress.Trim() : string.Empty).PadRight(140 - GetByteLength(data.RemitAddress) + (!string.IsNullOrEmpty(data.RemitAddress) ? data.RemitAddress.Length : 0), ' '));
                        content.Append((!string.IsNullOrEmpty(data.OrgCode) ? data.OrgCode.Trim() : string.Empty).PadRight(10, ' '));
                        content.Append((!string.IsNullOrEmpty(data.CorrespondentBankName) ? data.CorrespondentBankName.Trim() : string.Empty).PadRight(140 - GetByteLength(data.CorrespondentBankName) + (!string.IsNullOrEmpty(data.CorrespondentBankName) ? data.CorrespondentBankName.Length : 0), ' '));
                        content.Append((!string.IsNullOrEmpty(data.CorrespondentBankAddress) ? data.CorrespondentBankAddress.Trim() : string.Empty).PadRight(140 - GetByteLength(data.CorrespondentBankAddress) + (!string.IsNullOrEmpty(data.CorrespondentBankAddress) ? data.CorrespondentBankAddress.Length : 0), ' '));
                        content.Append((!string.IsNullOrEmpty(data.PayeeOpenBankAddress) ? data.PayeeOpenBankAddress.Trim() : string.Empty).PadRight(140 - GetByteLength(data.PayeeOpenBankAddress) + (!string.IsNullOrEmpty(data.PayeeOpenBankAddress) ? data.PayeeOpenBankAddress.Length : 0), ' '));
                        content.Append((!string.IsNullOrEmpty(data.PayeeAccountInCorrespondentBank) ? data.PayeeAccountInCorrespondentBank.Trim() : string.Empty).PadRight(40 - GetByteLength(data.PayeeAccountInCorrespondentBank) + (!string.IsNullOrEmpty(data.PayeeAccountInCorrespondentBank) ? data.PayeeAccountInCorrespondentBank.Length : 0), ' '));
                        content.Append((!string.IsNullOrEmpty(data.PayeeAddress) ? data.PayeeAddress.Trim() : string.Empty).PadRight(140 - GetByteLength(data.PayeeAddress) + (!string.IsNullOrEmpty(data.PayeeAddress) ? data.PayeeAddress.Length : 0), ' '));
                        content.Append((data.AssumeFeeType != AssumeFeeType.Empty ? ((int)data.AssumeFeeType).ToString() : string.Empty).PadRight(1, ' '));
                        content.Append((!string.IsNullOrEmpty(data.PayeeCodeofCountry) ? data.PayeeCodeofCountry.Trim() : string.Empty).PadRight(3, ' '));
                        content.Append((!string.IsNullOrEmpty(data.PayeeNameofCountry) ? data.PayeeNameofCountry.Trim() : string.Empty).PadRight(30 - GetByteLength(data.PayeeNameofCountry) + (!string.IsNullOrEmpty(data.PayeeNameofCountry) ? data.PayeeNameofCountry.Length : 0), ' '));
                        content.Append(data.PayFeeType != PayFeeType.Empty ? ((int)data.PayFeeType).ToString() : string.Empty.PadLeft(1, ' '));
                        content.Append(data.PaymentPropertyType != PaymentPropertyType.Empty ? DataConvertHelper.Instance.GetPaymentPropertyTypeBarValue(data.PaymentPropertyType) : string.Empty.PadLeft(1, ' '));
                        content.Append((!string.IsNullOrEmpty(data.DealSerialNoF) ? data.DealSerialNoF.Trim() : string.Empty).PadRight(6, ' '));
                        content.Append((string.IsNullOrEmpty(data.AmountF) ? string.Empty : (double.Parse(data.AmountF) * 100).ToString()).PadLeft(16, ' '));
                        content.Append((!string.IsNullOrEmpty(data.DealSerialNoS) ? data.DealSerialNoS.Trim() : string.Empty).PadRight(6, ' '));
                        content.Append((string.IsNullOrEmpty(data.AmountS) ? string.Empty : (double.Parse(data.AmountS) * 100).ToString()).PadLeft(16, ' '));
                        content.Append((data.IsPayOffLine ? "Y" : "N"));
                        content.Append((!string.IsNullOrEmpty(data.ContactNo) ? data.ContactNo.Trim() : string.Empty).PadRight(20 - GetByteLength(data.ContactNo) + (!string.IsNullOrEmpty(data.ContactNo) ? data.ContactNo.Length : 0), ' '));
                        content.Append((!string.IsNullOrEmpty(data.BillSerialNo) ? data.BillSerialNo.Trim() : string.Empty).PadRight(35 - GetByteLength(data.BillSerialNo) + (!string.IsNullOrEmpty(data.BillSerialNo) ? data.BillSerialNo.Length : 0), ' '));
                        content.Append((!string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo) ? data.BatchNoOrTNoOrSerialNo.Trim() : string.Empty).PadRight(20 - GetByteLength(data.BatchNoOrTNoOrSerialNo) + (!string.IsNullOrEmpty(data.BatchNoOrTNoOrSerialNo) ? data.BatchNoOrTNoOrSerialNo.Length : 0), ' '));
                        content.Append((!string.IsNullOrEmpty(data.ProposerName) ? data.ProposerName.Trim() : string.Empty).PadRight(20 - GetByteLength(data.ProposerName) + (!string.IsNullOrEmpty(data.ProposerName) ? data.ProposerName.Length : 0), ' '));
                        content.Append((!string.IsNullOrEmpty(data.Telephone) ? data.Telephone.Trim() : string.Empty).PadRight(15 - GetByteLength(data.Telephone) + (!string.IsNullOrEmpty(data.Telephone) ? data.Telephone.Length : 0), ' '));
                        content.Append(separactorChar);
                        #endregion
                    }
                }
                contentList.Add(content.ToString());
            }
            return contentList;
        }

        public List<string> CreateContentInfoBar(AppliableFunctionType aft, IList<AgentExpress> dataList, AgentTransferBankType bankType, string separactorChar)
        {
            List<string> contentList = new List<string>();
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();
                if (aft == AppliableFunctionType.AgentExpressOut4Bar)
                {
                    content.Append((!string.IsNullOrEmpty(data.AccountNo) ? data.AccountNo.Trim() : string.Empty).PadRight(25, ' '));
                    content.Append((!string.IsNullOrEmpty(data.AccountName) ? data.AccountName.Trim() : string.Empty).PadRight(58 - GetByteLength(data.AccountName) + (!string.IsNullOrEmpty(data.AccountName) ? data.AccountName.Length : 0), ' '));
                    content.Append((!string.IsNullOrEmpty(data.Amount) ? (double.Parse(data.Amount) * 100).ToString().Trim() : string.Empty).PadLeft(16, ' '));
                    content.Append((bankType == AgentTransferBankType.Boc ? ((int)data.Province).ToString() : (!string.IsNullOrEmpty(data.BankNo) ? data.BankNo : string.Empty)).PadRight(14, ' '));
                    content.Append((bankType == AgentTransferBankType.Boc && data.CertifyPaperType != AgentExpressCertifyPaperType.Empty ? ((int)data.CertifyPaperType).ToString().PadLeft(2, '0') : string.Empty).PadRight(2, ' '));
                    content.Append((bankType == AgentTransferBankType.Boc && !string.IsNullOrEmpty(data.CertifyPaperNo) ? data.CertifyPaperNo : string.Empty).PadRight(32 - GetByteLength(data.CertifyPaperNo) + (!string.IsNullOrEmpty(data.CertifyPaperNo) ? data.CertifyPaperNo.Length : 0), ' '));
                    content.Append(string.Empty.PadRight(80, ' '));
                    content.Append(string.Empty.PadRight(60, ' '));
                    content.Append(string.Empty.PadRight(40, ' '));
                    content.Append(string.Empty.PadRight(1, ' '));
                    content.Append(string.Empty.PadLeft(16 + 16, ' '));
                    content.Append((data.UsageType != AgentExpressFunctionType.Empty ? data.UsageType.ToString() : string.Empty).PadRight(2, ' '));
                    content.Append(string.Empty.PadRight(5, ' '));
                    content.Append((!string.IsNullOrEmpty(data.BankName) ? data.BankName.Trim() : string.Empty).PadRight(80 - GetByteLength(data.BankName) + (!string.IsNullOrEmpty(data.BankName) ? data.BankName.Length : 0), ' '));
                    content.Append(string.Empty.PadRight(100, ' '));
                    content.Append(separactorChar);
                    contentList.Add(content.ToString());
                }
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<UnitivePaymentForeignMoney> dataList, string separatorChar, OverCountryPayeeAccountType type)
        {
            List<string> contentList = new List<string>();

            //获取交易内容信息
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();
                switch (type)
                {
                    case OverCountryPayeeAccountType.BocAccount:
                        #region
                        content.Append(data.PayerAccount + separatorChar);
                        content.Append(data.PayerName + separatorChar);
                        content.Append(data.NominalPayerName + separatorChar);
                        content.Append(data.NominalPayerAccount + separatorChar);
                        content.Append((data.CashType != CashType.Empty ? ((int)data.CashType).ToString().PadLeft(3, '0') : string.Empty) + separatorChar);
                        content.Append(data.PayeeAccount + separatorChar);
                        content.Append(data.PayeeName + separatorChar);
                        content.Append(data.PayeeOpenBankName + separatorChar);
                        content.Append((!string.IsNullOrEmpty(data.Amount) ? data.Amount.Replace(",", "") : string.Empty) + separatorChar);
                        content.Append(data.CustomerBusinissNo + separatorChar);
                        content.Append(data.Purpose + separatorChar);
                        content.Append(data.OrderPayDate + separatorChar);
                        content.Append(data.Addtion + separatorChar);
                        content.Append(data.CodeofCountry + separatorChar);
                        content.Append((data.IsImportCancelAfterVerificationType == IsImportCancelAfterVerificationType.Empty ? string.Empty : data.IsImportCancelAfterVerificationType.ToString()) + separatorChar);
                        content.Append((data.UnitivePaymentType == PayFeeType.Empty ? string.Empty : data.UnitivePaymentType.ToString()) + separatorChar);
                        content.Append(((int)data.PaymentNature).ToString() + separatorChar);
                        content.Append(data.TransactionCode1 + separatorChar);
                        content.Append(data.TransactionCode2 + separatorChar);
                        content.Append((!string.IsNullOrEmpty(data.IPPSMoneyTypeAmount1) ? data.IPPSMoneyTypeAmount1.Replace(",", "") : string.Empty) + separatorChar);
                        content.Append((!string.IsNullOrEmpty(data.IPPSMoneyTypeAmount2) ? data.IPPSMoneyTypeAmount2.Replace(",", "") : string.Empty) + separatorChar);
                        content.Append(data.ContractNo + separatorChar);
                        content.Append(data.InvoiceNo + separatorChar);
                        content.Append(data.BatchNoOrTNoOrSerialNo + separatorChar);
                        content.Append(data.ApplicantName + separatorChar);
                        content.Append(data.Contactnumber + separatorChar);
                        #endregion
                        break;
                    case OverCountryPayeeAccountType.OtherAccount:
                        #region
                        content.Append(data.PayerAccount + separatorChar);
                        content.Append(data.PayerName + separatorChar);
                        content.Append(data.NominalPayerName + separatorChar);
                        content.Append(data.NominalPayerAccount + separatorChar);
                        content.Append((data.CashType != CashType.Empty ? ((int)data.CashType).ToString().PadLeft(3, '0') : string.Empty) + separatorChar);
                        content.Append(data.OrderPayDate + separatorChar);
                        content.Append(((int)data.SendPriority).ToString() + separatorChar);
                        content.Append((!string.IsNullOrEmpty(data.Amount) ? data.Amount.Replace(",", "") : string.Empty) + separatorChar);
                        content.Append(data.OrgCode + separatorChar);
                        content.Append(data.CustomerBusinissNo + separatorChar);
                        content.Append(data.realPayAddress + separatorChar);
                        content.Append(data.Addtion + separatorChar);
                        content.Append(data.PayeeAccount + separatorChar);
                        content.Append(data.PayeeName + separatorChar);
                        content.Append(data.Address + separatorChar);
                        content.Append(data.PayeeOpenBankName + separatorChar);
                        content.Append(data.OpenBankAddress + separatorChar);
                        content.Append(data.PayeeOpenBankSwiftCode + separatorChar);
                        content.Append(data.CorrespondentBankName + separatorChar);
                        content.Append(data.CorrespondentBankSwiftCode + separatorChar);
                        content.Append(data.PayeeAccountInCorrespondentBank + separatorChar);
                        content.Append(data.CorrespondentBankAddress + separatorChar);
                        content.Append(data.CodeofCountry + separatorChar);
                        content.Append((data.IsImportCancelAfterVerificationType == IsImportCancelAfterVerificationType.Empty ? string.Empty : data.IsImportCancelAfterVerificationType.ToString()) + separatorChar);
                        content.Append(data.UnitivePaymentType.ToString() + separatorChar);
                        content.Append(((int)data.PaymentNature).ToString() + separatorChar);
                        content.Append(data.TransactionCode1 + separatorChar);
                        content.Append(data.TransactionCode2 + separatorChar);
                        content.Append((!string.IsNullOrEmpty(data.IPPSMoneyTypeAmount1) ? data.IPPSMoneyTypeAmount1.Replace(",", "") : string.Empty) + separatorChar);
                        content.Append((!string.IsNullOrEmpty(data.IPPSMoneyTypeAmount2) ? data.IPPSMoneyTypeAmount2.Replace(",", "") : string.Empty) + separatorChar);
                        content.Append(data.ContractNo + separatorChar);
                        content.Append(data.InvoiceNo + separatorChar);
                        content.Append(data.BatchNoOrTNoOrSerialNo + separatorChar);
                        content.Append(data.ApplicantName + separatorChar);
                        content.Append(data.Contactnumber + separatorChar);
                        #endregion
                        break;
                    case OverCountryPayeeAccountType.ForeignAccount:
                        #region
                        content.Append(data.PayerAccount + separatorChar);
                        content.Append(data.PayerName + separatorChar);
                        content.Append(data.NominalPayerName + separatorChar);
                        content.Append(data.NominalPayerAccount + separatorChar);
                        content.Append((data.CashType != CashType.Empty ? ((int)data.CashType).ToString().PadLeft(3, '0') : string.Empty) + separatorChar);
                        content.Append(data.OrderPayDate + separatorChar);
                        content.Append(((int)data.SendPriority).ToString() + separatorChar);
                        content.Append(data.UnitivePaymentType + separatorChar);
                        content.Append((!string.IsNullOrEmpty(data.Amount) ? data.Amount.Replace(",", "") : string.Empty) + separatorChar);
                        content.Append(data.realPayAddress + separatorChar);
                        content.Append(data.CustomerBusinissNo + separatorChar);
                        content.Append(data.OrgCode + separatorChar);
                        content.Append(data.Addtion + separatorChar);
                        content.Append(data.PayeeAccount + separatorChar);
                        content.Append(data.PayeeName + separatorChar);
                        content.Append(data.Address + separatorChar);
                        content.Append(data.PayeeOpenBankName + separatorChar);
                        content.Append(data.OpenBankAddress + separatorChar);
                        content.Append(data.PayeeOpenBankSwiftCode + separatorChar);
                        content.Append(data.CorrespondentBankName + separatorChar);
                        content.Append(data.CorrespondentBankSwiftCode + separatorChar);
                        content.Append(data.CorrespondentBankAddress + separatorChar);
                        content.Append(data.PayeeAccountInCorrespondentBank + separatorChar);
                        content.Append(data.CodeofCountry + separatorChar);
                        content.Append((data.FCPayeeAccountType != UnitiveFCPayeeAccountType.Empty ? data.FCPayeeAccountType.ToString() : string.Empty) + separatorChar);
                        content.Append((data.PaymentCountryOrArea != Transfer2CountryType.Empty ? data.PaymentCountryOrArea.ToString() : string.Empty) + separatorChar);
                        content.Append(data.TransactionCode1 + separatorChar);
                        content.Append(data.TransactionCode2 + separatorChar);
                        content.Append((!string.IsNullOrEmpty(data.IPPSMoneyTypeAmount1) ? data.IPPSMoneyTypeAmount1.Replace(",", "") : string.Empty) + separatorChar);
                        content.Append((!string.IsNullOrEmpty(data.IPPSMoneyTypeAmount2) ? data.IPPSMoneyTypeAmount2.Replace(",", "") : string.Empty) + separatorChar);
                        content.Append(data.TransactionAddtion1 + separatorChar);
                        content.Append(data.TransactionAddtion2 + separatorChar);
                        content.Append((data.IsPayOffLine ? 1 : 0) + separatorChar);
                        content.Append(data.ContractNo + separatorChar);
                        content.Append(data.InvoiceNo + separatorChar);
                        content.Append(data.BatchNoOrTNoOrSerialNo + separatorChar);
                        content.Append(data.ApplicantName + separatorChar);
                        content.Append(data.Contactnumber + separatorChar);
                        #endregion
                        break;
                }
                if (!string.IsNullOrEmpty(content.ToString()))
                    contentList.Add(content.ToString());
            }
            return contentList;
        }

        public List<string> CreateContentInfo(AppliableFunctionType aft, IList<VirtualAccount> dataList, string separatorChar)
        {
            List<string> contentList = new List<string>();

            //获取交易内容信息
            foreach (var data in dataList)
            {
                StringBuilder content = new StringBuilder();

                if (aft == AppliableFunctionType.VirtualAccountTransfer)
                {
                    content.Append(data.AccountOut + separatorChar);
                    content.Append(data.NameOut + separatorChar);
                    content.Append(data.AccountIn + separatorChar);
                    content.Append(data.NameIn + separatorChar);
                    content.Append(data.CashType + separatorChar);
                    content.Append(data.Amount + separatorChar);
                    content.Append(data.Purpose + separatorChar);
                    content.Append(data.CustomerBusinissNo + separatorChar);
                    contentList.Add(content.ToString());
                }
            }
            return contentList;
        }

        #endregion

        #region GetEntitiesList
        public List<TransferAccount> GetTransferAccount(List<string> contentData, AppliableFunctionType templateType)
        {
            List<TransferAccount> list = new List<TransferAccount>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BatchMappingSettings[templateType].SeperateChar };
            int count = 0;
            TransferAccount ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new TransferAccount();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.CustomerRef = strList[0];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.PayerAccount = strList[3];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "付款人账号为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.PayeeAccount = strList[4];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.PayeeOpenBank = strList[7];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款行名称为空";
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.PayeeName = strList[8];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人名称为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.PayeeAddress = strList[9];
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.PayAmount = strList[11];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "付款金额为空";
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.PayFeeNo = strList[12];
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.PayDatetime = strList[13];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "付款人账号为空";
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.Addition = strList[14];
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.TChanel = (TransferChanelType)int.Parse(strList[15]);
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.Email = strList[16];
                    if (!string.IsNullOrEmpty(strList[19]))
                        ta.AccountBankType = (AccountBankType)((int.Parse(strList[19]) + 1) % 2);
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "是否中行收款标志为空";
                    if (!string.IsNullOrEmpty(strList[20]))
                        ta.CNAPSNo = strList[20];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new TransferAccount();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.CustomerRef = strList[0];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.PayerAccount = strList[3];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "付款人账号为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.PayeeAccount = strList[4];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.PayeeOpenBank = strList[7];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款行名称为空";
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.PayeeName = strList[8];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人名称为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.PayeeAddress = strList[9];
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.PayAmount = strList[11];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "付款金额为空";
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.PayFeeNo = strList[12];
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.PayDatetime = strList[13];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "付款人账号为空";
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.Addition = strList[14];
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.TChanel = (TransferChanelType)int.Parse(strList[15]);
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.Email = strList[16];
                    if (!string.IsNullOrEmpty(strList[19]))
                        ta.AccountBankType = (AccountBankType)((int.Parse(strList[19]) + 1) % 2);
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "是否中行收款标志为空";
                    if (!string.IsNullOrEmpty(strList[20]))
                        ta.CNAPSNo = strList[20];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                }
            }

            return list;
        }

        public List<TransferAccount> GetTransferAccountBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<TransferAccount> list = new List<TransferAccount>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            TransferAccount ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new TransferAccount();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.CustomerRef = strList[0];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.PayerAccount = strList[3];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "付款人账号为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.PayeeAccount = strList[4];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.PayeeOpenBank = strList[7];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款行名称为空";
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.PayeeName = strList[8];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人名称为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.PayeeAddress = strList[9];
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.PayAmount = strList[11];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "付款金额为空";
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.PayFeeNo = strList[12];
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.PayDatetime = strList[13];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "付款人账号为空";
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.Addition = strList[14];
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.TChanel = DataConvertHelper.Instance.GetTransferChanelType(strList[15]);
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.Email = strList[16];
                    if (!string.IsNullOrEmpty(strList[19]))
                    {
                        try
                        {
                            ta.AccountBankType = DataConvertHelper.Instance.GetAccountBankTypeObject((int.Parse(strList[19]) + 1) % 2);
                        }
                        catch { }
                    }
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "是否中行收款标志为空";
                    if (!string.IsNullOrEmpty(strList[20]))
                        ta.CNAPSNo = strList[20];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new TransferAccount();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.CustomerRef = strList[0];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.PayerAccount = strList[3];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "付款人账号为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.PayeeAccount = strList[4];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.PayeeOpenBank = strList[7];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款行名称为空";
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.PayeeName = strList[8];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人名称为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.PayeeAddress = strList[9];
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.PayAmount = strList[11];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "付款金额为空";
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.PayFeeNo = strList[12];
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.PayDatetime = strList[13];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "付款人账号为空";
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.Addition = strList[14];
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.TChanel = DataConvertHelper.Instance.GetTransferChanelType(strList[15]);
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.Email = strList[16];
                    if (!string.IsNullOrEmpty(strList[19]))
                    {
                        try
                        {
                            ta.AccountBankType = DataConvertHelper.Instance.GetAccountBankTypeObject((int.Parse(strList[19]) + 1) % 2);
                        }
                        catch { }
                    }
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "是否中行收款标志为空";
                    if (!string.IsNullOrEmpty(strList[20]))
                        ta.CNAPSNo = strList[20];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<TransferAccount> GetTransferAccountBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<TransferAccount> list = new List<TransferAccount>();

            TransferAccount ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                ta = new TransferAccount();
                string[] strList = AnalyseBOCErrorCSVSytleData(data);
                try
                {
                    ta.RowIndex = int.Parse(strList[0]);
                    ta.ErrorReason = strList[strList.Length - 1];
                    list.Add(ta);
                }
                catch { }
            }

            return list;
        }

        public List<object> GetAgentExpress(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            BatchHeader batch = new BatchHeader();
            List<AgentExpress> list = new List<AgentExpress>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            string[] s = new string[] { SystemSettings.Instance.BatchMappingSettings[templateType].SeperateChar };
            int count = 0;
            AgentExpress ae;

            foreach (var data in contentData)
            {
                if (count > maxcount) break;

                ae = null;
                string[] strList = data.Split(s, StringSplitOptions.None);

                #region 批信息
                if (count == 0)
                {
                    #region
                    /*客户业务编号
                      付款行联行号（代收没有）
                      付款人账号
                      收款行（代收没有）
                      货币名称
                      批总金额
                      批总笔数
                      用途
                      付款日期
                      附言*/
                    #endregion
                    batch.ProtecolNo = strList[0];
                    //if (AppliableFunctionType.AgentExpressOut == templateType) ;
                    //str += "" + separatorChar;
                    batch.Payer.Account = strList[2];
                    if (AppliableFunctionType.AgentExpressOut == templateType)
                        batch.Bank = strList[3];
                    batch.UseType = strList[7];
                    batch.AgentFunctionType_Express = DataConvertHelper.Instance.GetAgentExpressFunctionType(strList[7]);
                    batch.TransferDatetime = DateTime.Parse(strList[8]);
                    batch.Addtion = strList[9];
                    count++;
                    continue;
                }
                #endregion

                #region 笔信息
                ae = new AgentExpress();
                try
                {
                    #region
                    /*收款行行号(必填，中行卡时，必填写2位省行标识，他行卡时，必须填写12位CNAPS号。)
                      金额(必填,最长14位，含小数点及2位小数)
                      收款人账号(必填，如果卡类型为1，收款人账号有19位借记卡和最长22位存折账号；如果卡类型为4，收款人账号长度是16位。)
                      收款人姓名(必填,最长20位)
                      收款人证件类型("非必填，最长2位，同BANCS证件类型
                                                01－居民身份证
                                                02－临时身份证
                                                03－护照
                                                04－户口簿
                                                05－军人身份证
                                                06－武装警察身份证
                                                08－外交人员身份证
                                                09－外国人居留许可证
                                                10－边民出入境通行证
                                                11－对私其它
                                                21－企业法人营业执照 
                                                22－企业营业执照 
                                                30－驻华机构登记证
                                                31－个体工商户营业执照
                                                33－组织机构代码证
                                                47－港澳居民来往内地通行证（香港）
                                                48－港澳居民来往内地通行证（澳门）
                                                49－台湾居民来往大陆通行证"
                                                )
                      收款人证件号(非必填，最长32位)
                      协议号(付款行为中行时非必填，为他行时必填多方协议号。最长60位)(代收才有)*/
                    #endregion
                    if (!string.IsNullOrEmpty(strList[0]))
                        ae.BankNo = strList[0];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款行行号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ae.Amount = strList[1];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "金额为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ae.AccountNo = strList[2];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[3]))
                        ae.AccountName = strList[3];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款人姓名为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ae.CertifyPaperType = (AgentExpressCertifyPaperType)int.Parse(strList[4]);
                    ae.CertifyPaperNo = strList[5];

                    if (AppliableFunctionType.AgentExpressIn == templateType)
                    {
                        ae.ProtecolNo = strList[6];
                        ae.UsageType = DataConvertHelper.Instance.GetAgentExpressFunctionType(strList[7]);
                    }
                    else if (AppliableFunctionType.AgentExpressOut == templateType)
                        ae.UsageType = DataConvertHelper.Instance.GetAgentExpressFunctionType(strList[6]);
                }
                catch { ae.ErrorReason = "数据格式错误，转换失败"; }
                finally { if (null != ae) list.Add(ae); count++; }
                #endregion
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ae = null;
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);

                #region 批信息
                if (count == 0)
                {
                    #region
                    /*客户业务编号
                      付款行联行号（代收没有）
                      付款人账号
                      收款行（代收没有）
                      货币名称
                      批总金额
                      批总笔数
                      用途
                      付款日期
                      附言*/
                    #endregion
                    batch.ProtecolNo = strList[0];
                    //if (AppliableFunctionType.AgentExpressOut == templateType) ;
                    //str += "" + separatorChar;
                    batch.Payer.Account = strList[2];
                    if (AppliableFunctionType.AgentExpressOut == templateType)
                        batch.Bank = strList[3];
                    batch.Addtion = strList[7];
                    batch.TransferDatetime = DateTime.Parse(strList[8]);
                    batch.Addtion = strList[9];
                }
                #endregion

                #region 笔信息
                ae = new AgentExpress();
                try
                {
                    #region
                    /*收款行行号(必填，中行卡时，必填写2位省行标识，他行卡时，必须填写12位CNAPS号。)
                      金额(必填,最长14位，含小数点及2位小数)
                      收款人账号(必填，如果卡类型为1，收款人账号有19位借记卡和最长22位存折账号；如果卡类型为4，收款人账号长度是16位。)
                      收款人姓名(必填,最长20位)
                      收款人证件类型("非必填，最长2位，同BANCS证件类型
                                                01－居民身份证
                                                02－临时身份证
                                                03－护照
                                                04－户口簿
                                                05－军人身份证
                                                06－武装警察身份证
                                                08－外交人员身份证
                                                09－外国人居留许可证
                                                10－边民出入境通行证
                                                11－对私其它
                                                21－企业法人营业执照 
                                                22－企业营业执照 
                                                30－驻华机构登记证
                                                31－个体工商户营业执照
                                                33－组织机构代码证
                                                47－港澳居民来往内地通行证（香港）
                                                48－港澳居民来往内地通行证（澳门）
                                                49－台湾居民来往大陆通行证"
                                                )
                      收款人证件号(非必填，最长32位)
                      协议号(付款行为中行时非必填，为他行时必填多方协议号。最长60位)(代收才有)*/
                    #endregion
                    if (!string.IsNullOrEmpty(strList[0]))
                        ae.BankNo = strList[0];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款行行号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ae.Amount = strList[1];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "金额为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ae.AccountNo = strList[2];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[3]))
                        ae.AccountName = strList[3];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款人姓名为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ae.CertifyPaperType = (AgentExpressCertifyPaperType)int.Parse(strList[4]);
                    ae.CertifyPaperNo = strList[5];

                    if (AppliableFunctionType.AgentExpressIn == templateType)
                    {
                        ae.ProtecolNo = strList[6];
                        ae.UsageType = DataConvertHelper.Instance.GetAgentExpressFunctionType(strList[7]);
                    }
                    else if (AppliableFunctionType.AgentExpressOut == templateType)
                        ae.UsageType = DataConvertHelper.Instance.GetAgentExpressFunctionType(strList[6]);
                }
                catch { ae.ErrorReason = "数据格式错误，转换失败"; }
                finally { if (null != ae) list.Add(ae); count++; }
                #endregion
            }

            result.Add(batch);
            result.Add(list);
            return result;
        }

        public List<object> GetAgentExpressBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            BatchHeader batch = new BatchHeader();
            List<AgentExpress> list = new List<AgentExpress>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            AgentExpress ae;

            foreach (var data in contentData)
            {
                if (count > maxcount) break;

                ae = null;
                string[] strList = data.Split(s, StringSplitOptions.None);

                #region 批信息
                if (count == 0)
                {
                    #region
                    /*客户业务编号
                      付款行联行号（代收没有）
                      付款人账号
                      收款行（代收没有）
                      货币名称
                      批总金额
                      批总笔数
                      用途
                      付款日期
                      附言*/
                    #endregion
                    batch.ProtecolNo = strList[0];
                    if (AppliableFunctionType.AgentExpressIn == templateType)
                    {
                        batch.Payer.Account = strList[1];
                        batch.UseType = strList[5];
                        batch.TransferDatetime = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(strList[6]));
                        batch.Addtion = strList[7];
                    }
                    try
                    {
                        if (AppliableFunctionType.AgentExpressOut == templateType)
                        {
                            batch.Bank = strList[1];
                            batch.Payer.Account = strList[2];
                            batch.BankType = (AgentTransferBankType)int.Parse(strList[3]);
                            batch.UseType = strList[7];
                            batch.TransferDatetime = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(strList[8]));
                            batch.Addtion = strList[9];
                        }
                    }
                    catch { };
                    batch.AgentFunctionType_Express = DataConvertHelper.Instance.GetAgentExpressFunctionType(batch.UseType);
                    //setBankType = batch.AgentFunctionType_Express != AgentExpressFunctionType.Empty;
                    count++;
                    continue;
                }
                #endregion

                #region 笔信息
                ae = new AgentExpress();
                try
                {
                    #region
                    /*收款行行号(必填，中行卡时，必填写2位省行标识，他行卡时，必须填写12位CNAPS号。)
                      金额(必填,最长14位，含小数点及2位小数)
                      收款人账号(必填，如果卡类型为1，收款人账号有19位借记卡和最长22位存折账号；如果卡类型为4，收款人账号长度是16位。)
                      收款人姓名(必填,最长20位)
                      收款人证件类型("非必填，最长2位，同BANCS证件类型
                                                01－居民身份证
                                                02－临时身份证
                                                03－护照
                                                04－户口簿
                                                05－军人身份证
                                                06－武装警察身份证
                                                08－外交人员身份证
                                                09－外国人居留许可证
                                                10－边民出入境通行证
                                                11－对私其它
                                                21－企业法人营业执照 
                                                22－企业营业执照 
                                                30－驻华机构登记证
                                                31－个体工商户营业执照
                                                33－组织机构代码证
                                                47－港澳居民来往内地通行证（香港）
                                                48－港澳居民来往内地通行证（澳门）
                                                49－台湾居民来往大陆通行证"
                                                )
                      收款人证件号(非必填，最长32位)
                      协议号(付款行为中行时非必填，为他行时必填多方协议号。最长60位)(代收才有)*/
                    #endregion
                    if (!string.IsNullOrEmpty(strList[0]))
                    {
                        if (strList[0].Length == 2)
                        {
                            if (count == 1 && templateType == AppliableFunctionType.AgentExpressIn)
                            {
                                batch.BankType = AgentTransferBankType.Boc;
                            }
                        }
                        if (batch.BankType == AgentTransferBankType.Boc)
                            ae.Province = DataConvertHelper.Instance.GetProvince(strList[0]);
                        else ae.BankNo = strList[0];
                    }
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款行行号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ae.Amount = strList[1];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "金额为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ae.AccountNo = strList[2];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[3]))
                        ae.AccountName = strList[3];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款人姓名为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ae.CertifyPaperType = (AgentExpressCertifyPaperType)int.Parse(strList[4]);
                    ae.CertifyPaperNo = strList[5];

                    if (AppliableFunctionType.AgentExpressIn == templateType)
                    {
                        ae.ProtecolNo = strList[6];
                        ae.UsageType = DataConvertHelper.Instance.GetAgentExpressFunctionType(strList[7]);
                    }
                    else if (AppliableFunctionType.AgentExpressOut == templateType)
                        ae.UsageType = DataConvertHelper.Instance.GetAgentExpressFunctionType(strList[6]);
                }
                catch { ae.ErrorReason = "数据格式错误，转换失败"; }
                finally { if (null != ae) list.Add(ae); count++; }
                #endregion
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ae = null;
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);

                #region 批信息
                //if (count == 0)
                //{
                //    #region
                //    /*客户业务编号
                //      付款行联行号（代收没有）
                //      付款人账号
                //      收款行（代收没有）
                //      货币名称
                //      批总金额
                //      批总笔数
                //      用途
                //      付款日期
                //      附言*/
                //    #endregion
                //    batch.ProtecolNo = strList[0];
                //    if (AppliableFunctionType.AgentExpressOut == templateType) ;
                //    //str += "" + separatorChar;
                //    batch.Payer.Account = strList[2];
                //    if (AppliableFunctionType.AgentExpressOut == templateType)
                //        batch.Bank = strList[3];
                //    batch.Addtion = strList[7];
                //    batch.TransferDatetime = DateTime.Parse(strList[8]);
                //    batch.Addtion = strList[9];
                //}
                #endregion

                #region 笔信息
                ae = new AgentExpress();
                try
                {
                    #region
                    /*收款行行号(必填，中行卡时，必填写2位省行标识，他行卡时，必须填写12位CNAPS号。)
                      金额(必填,最长14位，含小数点及2位小数)
                      收款人账号(必填，如果卡类型为1，收款人账号有19位借记卡和最长22位存折账号；如果卡类型为4，收款人账号长度是16位。)
                      收款人姓名(必填,最长20位)
                      收款人证件类型("非必填，最长2位，同BANCS证件类型
                                                01－居民身份证
                                                02－临时身份证
                                                03－护照
                                                04－户口簿
                                                05－军人身份证
                                                06－武装警察身份证
                                                08－外交人员身份证
                                                09－外国人居留许可证
                                                10－边民出入境通行证
                                                11－对私其它
                                                21－企业法人营业执照 
                                                22－企业营业执照 
                                                30－驻华机构登记证
                                                31－个体工商户营业执照
                                                33－组织机构代码证
                                                47－港澳居民来往内地通行证（香港）
                                                48－港澳居民来往内地通行证（澳门）
                                                49－台湾居民来往大陆通行证"
                                                )
                      收款人证件号(非必填，最长32位)
                      协议号(付款行为中行时非必填，为他行时必填多方协议号。最长60位)(代收才有)*/
                    #endregion
                    if (!string.IsNullOrEmpty(strList[0]))
                        ae.BankNo = strList[0];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款行行号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ae.Amount = strList[1];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "金额为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ae.AccountNo = strList[2];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[3]))
                        ae.AccountName = strList[3];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款人姓名为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ae.CertifyPaperType = (AgentExpressCertifyPaperType)int.Parse(strList[4]);
                    ae.CertifyPaperNo = strList[5];

                    if (AppliableFunctionType.AgentExpressIn == templateType)
                    {
                        ae.ProtecolNo = strList[6];
                        ae.UsageType = DataConvertHelper.Instance.GetAgentExpressFunctionType(strList[7]);
                    }
                    else if (AppliableFunctionType.AgentExpressOut == templateType)
                        ae.UsageType = DataConvertHelper.Instance.GetAgentExpressFunctionType(strList[6]);
                }
                catch { ae.ErrorReason = "数据格式错误，转换失败"; }
                finally { if (null != ae) list.Add(ae); count++; }
                #endregion
            }

            result.Add(batch);
            result.Add(list);
            return result;
        }

        public List<object> GetAgentExpressBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            BatchHeader batch = new BatchHeader();
            List<AgentExpress> list = new List<AgentExpress>();

            AgentExpress ae;

            foreach (var data in contentData)
            {
                string[] strList = AnalyseBOCErrorCSVSytleData(data);

                #region 批信息
                //if (count == 0)
                //{
                //    batch.ProtecolNo = strList[0];
                //    batch.Payer.Account = strList[2];
                //    if (AppliableFunctionType.AgentExpressOut == templateType)
                //        batch.Bank = strList[3];
                //    batch.UseType = strList[7];
                //    batch.AgentFunctionType_Express = DataConvertHelper.Instance.GetAgentExpressFunctionType(strList[7]);
                //    try { batch.TransferDatetime = DateTime.Parse(strList[8]); }
                //    catch { };
                //    batch.Addtion = strList[9];
                //    count++;
                //    continue;
                //}
                #endregion

                #region 笔信息
                ae = new AgentExpress();
                try
                {
                    ae.RowIndex = int.Parse(strList[0]);
                    ae.ErrorReason = strList[strList.Length - 1];
                    list.Add(ae);
                }
                catch { }
                #endregion
            }
            result.Add(batch);
            result.Add(list);
            return result;
        }

        public List<object> GetAgentNormal(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            BatchHeader batch = new BatchHeader();
            List<AgentNormal> list = new List<AgentNormal>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            string[] s = new string[] { SystemSettings.Instance.BatchMappingSettings[templateType].SeperateChar };
            int count = 0;
            AgentNormal an;

            foreach (var data in contentData)
            {
                if (count > maxcount) break;
                an = null;
                string[] strList = data.Split(s, StringSplitOptions.None);

                #region 批信息
                if (count == 0)
                {
                    //客户业务编号
                    //付款行联行号
                    //付款人账号
                    //货币名称
                    //批总金额
                    //批总笔数
                    //代发卡类型
                    //用途
                    //手续费账号
                    //付款日期
                    //附言
                    batch.ProtecolNo = strList[0];
                    batch.BankNo = strList[1];
                    batch.Payer.Account = strList[2];
                    batch.CardType = (AgentCardType)int.Parse(strList[6]);
                    batch.UseType = strList[7];
                    batch.PayFeeNo = strList[8];
                    batch.TransferDatetime = DateTime.Parse(strList[9]);
                    batch.Addtion = strList[10];
                    count++;
                    continue;
                }
                #endregion

                #region 笔信息
                an = new AgentNormal();
                try
                {
                    #region
                    /* 收款行编号
                     * 收款行行名
                     * 货币名称
                     * 金额
                     * 收款人账号
                     * 收款人姓名
                     * 收款人证件类型
                     * 收款人证件号
                     * 用途
                     * 付款合同编号(代发没有)
                     */
                    #endregion
                    an.BankNo = strList[0];
                    an.BankName = strList[1];
                    an.Amount = strList[3];
                    an.AccountNo = strList[4];
                    an.AccountName = strList[5];
                    an.CertifyPaperType = (AgentNormalCertifyPaperType)int.Parse(strList[6]);
                    an.CertifyPaperNo = strList[7];
                    if (templateType == AppliableFunctionType.AgentNormalOut)
                    {
                        try
                        {
                            an.UseType = (AgentNormalFunctionType)int.Parse(strList[8]);
                        }
                        catch { an.UseType = AgentNormalFunctionType.Empty; }
                    }
                    else an.UseType_In = strList[8];
                    if (AppliableFunctionType.AgentNormalIn == templateType)
                        an.ProtecolNo = strList[9];
                }
                catch { }
                finally { if (an != null) list.Add(an); count++; }
                #endregion
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                an = null;
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);

                #region 批信息
                if (count == 0)
                {
                    //客户业务编号
                    //付款行联行号
                    //付款人账号
                    //货币名称
                    //批总金额
                    //批总笔数
                    //代发卡类型
                    //用途
                    //手续费账号
                    //付款日期
                    //附言
                    batch.ProtecolNo = strList[0];
                    batch.BankNo = strList[1];
                    batch.Payer.Account = strList[2];
                    batch.CardType = (AgentCardType)int.Parse(strList[6]);
                    batch.UseType = strList[7];
                    batch.PayFeeNo = strList[8];
                    batch.TransferDatetime = DateTime.Parse(strList[9]);
                    batch.Addtion = strList[10];
                }
                #endregion

                #region 笔信息
                an = new AgentNormal();
                try
                {
                    #region
                    /* 收款行编号
                     * 收款行行名
                     * 货币名称
                     * 金额
                     * 收款人账号
                     * 收款人姓名
                     * 收款人证件类型
                     * 收款人证件号
                     * 用途
                     * 付款合同编号(代发没有)
                     */
                    #endregion
                    an.BankNo = strList[0];
                    an.BankName = strList[1];
                    an.Amount = strList[3];
                    an.AccountNo = strList[4];
                    an.AccountName = strList[5];
                    an.CertifyPaperType = (AgentNormalCertifyPaperType)int.Parse(strList[6]);
                    an.CertifyPaperNo = strList[7];
                    if (templateType == AppliableFunctionType.AgentNormalOut)
                    {
                        try
                        {
                            an.UseType = (AgentNormalFunctionType)int.Parse(strList[8]);
                        }
                        catch { an.UseType = AgentNormalFunctionType.Empty; }
                    }
                    else an.UseType_In = strList[8];
                    if (AppliableFunctionType.AgentNormalIn == templateType)
                        an.ProtecolNo = strList[9];
                }
                catch { }
                finally { if (an != null) list.Add(an); }
                #endregion
            }

            result.Add(batch);
            result.Add(list);
            return result;
        }

        public List<object> GetAgentNormalBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            BatchHeader batch = new BatchHeader();
            List<AgentNormal> list = new List<AgentNormal>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            AgentNormal an;

            foreach (var data in contentData)
            {
                if (count > maxcount) break;
                an = null;
                string[] strList = data.Split(s, StringSplitOptions.None);

                #region 批信息
                if (count == 0)
                {
                    //客户业务编号
                    //付款行联行号
                    //付款人账号
                    //货币名称
                    //批总金额
                    //批总笔数
                    //代发卡类型
                    //用途
                    //手续费账号
                    //付款日期
                    //附言
                    if (templateType == AppliableFunctionType.AgentNormalIn)
                    {
                        batch.ProtecolNo = strList[0];
                        batch.BankNo = strList[1];
                        batch.Payer.Account = strList[2];
                        batch.CardType = (AgentCardType)int.Parse(strList[6]);
                        batch.UseType = strList[7];
                        batch.PayFeeNo = strList[8];
                        try
                        {
                            batch.TransferDatetime = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(strList[9]));
                        }
                        catch { }
                        batch.Addtion = strList[10];
                    }
                    else if (templateType == AppliableFunctionType.AgentNormalOut)
                    {
                        batch.ProtecolNo = strList[0];
                        batch.BankNo = strList[1];
                        batch.Payer.Account = strList[2];
                        batch.CardType = (AgentCardType)int.Parse(strList[6]);
                        batch.UseType = strList[7];
                        try
                        {
                            batch.TransferDatetime = DateTime.Parse(strList[8]);
                        }
                        catch { }
                        batch.Addtion = strList[9];
                    }
                    count++;
                    continue;
                }
                #endregion

                #region 笔信息
                an = new AgentNormal();
                try
                {
                    #region
                    /* 收款行编号
                     * 收款行行名
                     * 货币名称
                     * 金额
                     * 收款人账号
                     * 收款人姓名
                     * 收款人证件类型
                     * 收款人证件号
                     * 用途
                     * 付款合同编号(代发没有)
                     */
                    #endregion
                    an.BankNo = strList[0];
                    an.BankName = strList[1];
                    an.Amount = strList[3];
                    an.AccountNo = strList[4];
                    an.AccountName = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        an.CertifyPaperType = DataConvertHelper.Instance.GetAgentNormalCertifyPaperType(strList[6]);
                    an.CertifyPaperNo = strList[7];
                    if (templateType == AppliableFunctionType.AgentNormalOut)
                    {
                        try
                        {
                            an.UseType = (AgentNormalFunctionType)int.Parse(strList[8]);
                        }
                        catch { an.UseType = AgentNormalFunctionType.Empty; }
                    }
                    else an.UseType_In = strList[8];
                    if (AppliableFunctionType.AgentNormalIn == templateType)
                        an.ProtecolNo = strList[9];
                }
                catch { }
                finally { if (an != null) list.Add(an); count++; }
                #endregion
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                an = null;
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);

                #region 批信息
                if (count == 0)
                {
                    //客户业务编号
                    //付款行联行号
                    //付款人账号
                    //货币名称
                    //批总金额
                    //批总笔数
                    //代发卡类型
                    //用途
                    //手续费账号
                    //付款日期
                    //附言
                    //if (templateType == AppliableFunctionType.AgentNormalIn)
                    //{
                    //    batch.ProtecolNo = strList[0];
                    //    batch.BankNo = strList[1];
                    //    batch.Payer.Account = strList[2];
                    //    batch.CardType = (AgentCardType)int.Parse(strList[6]);
                    //    batch.UseType = strList[7];
                    //    batch.PayFeeNo = strList[8];
                    //    batch.TransferDatetime = DateTime.Parse(strList[9]);
                    //    batch.Addtion = strList[10];
                    //}
                    //else if (templateType == AppliableFunctionType.AgentNormalOut)
                    //{
                    //    batch.ProtecolNo = strList[0];
                    //    batch.BankNo = strList[1];
                    //    batch.Payer.Account = strList[2];
                    //    batch.CardType = (AgentCardType)int.Parse(strList[6]);
                    //    batch.UseType = strList[7];
                    //    batch.TransferDatetime = DateTime.Parse(strList[8]);
                    //    batch.Addtion = strList[9];
                    //}
                }
                #endregion

                #region 笔信息
                an = new AgentNormal();
                try
                {
                    #region
                    /* 收款行编号
                     * 收款行行名
                     * 货币名称
                     * 金额
                     * 收款人账号
                     * 收款人姓名
                     * 收款人证件类型
                     * 收款人证件号
                     * 用途
                     * 付款合同编号(代发没有)
                     */
                    #endregion
                    an.BankNo = strList[0];
                    an.BankName = strList[1];
                    an.Amount = strList[3];
                    an.AccountNo = strList[4];
                    an.AccountName = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        an.CertifyPaperType = DataConvertHelper.Instance.GetAgentNormalCertifyPaperType(strList[6]);
                    an.CertifyPaperNo = strList[7];
                    if (templateType == AppliableFunctionType.AgentNormalOut)
                    {
                        try
                        {
                            an.UseType = (AgentNormalFunctionType)int.Parse(strList[8]);
                        }
                        catch { an.UseType = AgentNormalFunctionType.Empty; }
                    }
                    else an.UseType_In = strList[8];
                    if (AppliableFunctionType.AgentNormalIn == templateType)
                        an.ProtecolNo = strList[9];
                }
                catch { }
                finally { if (an != null) list.Add(an); }
                #endregion
            }

            result.Add(batch);
            result.Add(list);
            return result;
        }

        public List<object> GetAgentNormalBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            BatchHeader batch = new BatchHeader();
            List<AgentNormal> list = new List<AgentNormal>();

            AgentNormal an;

            foreach (var data in contentData)
            {
                //string[] strList = data.Split(',');

                #region 批信息
                //if (count == 0)
                //{
                //    if (templateType == AppliableFunctionType.AgentNormalIn)
                //    {
                //        batch.ProtecolNo = strList[0];
                //        batch.BankNo = strList[1];
                //        batch.Payer.Account = strList[2];
                //        batch.CardType = (AgentCardType)int.Parse(strList[6]);
                //        batch.UseType = strList[7];
                //        batch.PayFeeNo = strList[8];
                //        try
                //        {
                //            batch.TransferDatetime = DateTime.Parse(strList[9]);
                //        }
                //        catch { }
                //        batch.Addtion = strList[10];
                //    }
                //    else if (templateType == AppliableFunctionType.AgentNormalOut)
                //    {
                //        batch.ProtecolNo = strList[0];
                //        batch.BankNo = strList[1];
                //        batch.Payer.Account = strList[2];
                //        batch.CardType = (AgentCardType)int.Parse(strList[6]);
                //        batch.UseType = strList[7];
                //        try
                //        {
                //            batch.TransferDatetime = DateTime.Parse(strList[8]);
                //        }
                //        catch { }
                //        batch.Addtion = strList[9];
                //    }
                //    count++;
                //    continue;
                //}
                #endregion

                #region 笔信息
                an = new AgentNormal();
                string[] strList = AnalyseBOCErrorCSVSytleData(data);
                try
                {
                    an.RowIndex = int.Parse(strList[0]);
                    an.ErrorReason = strList[strList.Length - 1];
                    list.Add(an);
                }
                catch { }
                #endregion
            }

            result.Add(batch);
            result.Add(list);
            return result;
        }

        public List<TransferAccount> GetTransferOverBank(List<string> contentData, AppliableFunctionType templateType)
        {
            List<TransferAccount> list = new List<TransferAccount>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            string[] s = new string[] { SystemSettings.Instance.BatchMappingSettings[templateType].SeperateChar };
            int count = 0;
            TransferAccount ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new TransferAccount();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (templateType == AppliableFunctionType.TransferOverBankIn)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            ta.PayerName = strList[1];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人名称为空";
                        if (!string.IsNullOrEmpty(strList[2]))
                            ta.PayerAccount = strList[2];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人账号为空";
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.PayeeName = strList[3];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人名称为空";
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PayeeAccount = strList[4];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人账号为空";
                        if (!string.IsNullOrEmpty(strList[5]))
                            ta.PayeeOpenBank = strList[5];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人开户行为空";
                        if (!string.IsNullOrEmpty(strList[6]))
                            ta.PayAmount = strList[6];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款金额不能为空";
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.PayProtecolNo = strList[7];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "协议号为空";
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.BusinessType = (BusinessType)int.Parse(strList[8]);
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "业务种类为空";
                        if (!string.IsNullOrEmpty(strList[9]))
                            ta.PayFeeNo = strList[9];
                        if (!string.IsNullOrEmpty(strList[10]))
                            ta.Addition = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.PayDatetime = strList[11];
                    }
                    else if (templateType == AppliableFunctionType.TransferOverBankOut)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "客户业务编号为空";
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.PayerAccount = strList[3];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人账号为空";
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PayeeAccount = strList[4];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人账号为空";
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.PayeeOpenBank = strList[7];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款行名称为空";
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.PayeeName = strList[8];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人名称为空";
                        ta.PayeeAddress = strList[9];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.PayAmount = strList[11];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款金额为空";
                        ta.PayFeeNo = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            ta.PayDatetime = strList[13];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人账号为空";
                        ta.Addition = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            ta.TChanel = (TransferChanelType)int.Parse(strList[15]);
                        if (!string.IsNullOrEmpty(strList[16]))
                            ta.Email = strList[16];
                        if (!string.IsNullOrEmpty(strList[19]))
                            ta.AccountBankType = (AccountBankType)((int.Parse(strList[19]) + 1) % 2);
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "是否中行收款标志为空";
                        ta.CNAPSNo = strList[20];
                    }
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new TransferAccount();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (templateType == AppliableFunctionType.TransferOverBankIn)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            ta.PayerName = strList[1];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人名称为空";
                        if (!string.IsNullOrEmpty(strList[2]))
                            ta.PayerAccount = strList[2];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人账号为空";
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.PayeeName = strList[3];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人名称为空";
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PayeeAccount = strList[4];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人账号为空";
                        if (!string.IsNullOrEmpty(strList[5]))
                            ta.PayeeOpenBank = strList[5];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人开户行为空";
                        if (!string.IsNullOrEmpty(strList[6]))
                            ta.PayAmount = strList[6];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款金额不能为空";
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.PayProtecolNo = strList[7];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "协议号为空";
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.BusinessType = (BusinessType)int.Parse(strList[8]);
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "业务种类为空";
                        if (!string.IsNullOrEmpty(strList[9]))
                            ta.PayFeeNo = strList[9];
                        if (!string.IsNullOrEmpty(strList[10]))
                            ta.Addition = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.PayDatetime = strList[11];
                    }
                    else if (templateType == AppliableFunctionType.TransferOverBankOut)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "客户业务编号为空";
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.PayerAccount = strList[3];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人账号为空";
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PayeeAccount = strList[4];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人账号为空";
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.PayeeOpenBank = strList[7];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款行名称为空";
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.PayeeName = strList[8];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人名称为空";
                        ta.PayeeAddress = strList[9];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.PayAmount = strList[11];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款金额为空";
                        ta.PayFeeNo = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            ta.PayDatetime = strList[13];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人账号为空";
                        ta.Addition = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            ta.TChanel = (TransferChanelType)int.Parse(strList[15]);
                        if (!string.IsNullOrEmpty(strList[16]))
                            ta.Email = strList[16];
                        if (!string.IsNullOrEmpty(strList[19]))
                            ta.AccountBankType = (AccountBankType)((int.Parse(strList[19]) + 1) % 2);
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "是否中行收款标志为空";
                        ta.CNAPSNo = strList[20];
                    }
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                }
            }

            return list;
        }

        public List<TransferAccount> GetTransferOverBankBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<TransferAccount> list = new List<TransferAccount>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            TransferAccount ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new TransferAccount();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (templateType == AppliableFunctionType.TransferOverBankIn)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            ta.PayerName = strList[1];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人名称为空";
                        if (!string.IsNullOrEmpty(strList[2]))
                            ta.PayerAccount = strList[2];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人账号为空";
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.PayeeName = strList[3];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人名称为空";
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PayeeAccount = strList[4];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人账号为空";
                        if (!string.IsNullOrEmpty(strList[5]))
                            ta.PayeeOpenBank = strList[5];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人开户行为空";
                        if (!string.IsNullOrEmpty(strList[6]))
                            ta.PayAmount = strList[6];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款金额不能为空";
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.PayProtecolNo = strList[7];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "协议号为空";
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.BusinessType = DataConvertHelper.Instance.GetBusinessType(strList[8]);
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "业务种类为空";
                        if (!string.IsNullOrEmpty(strList[9]))
                            ta.PayFeeNo = strList[9];
                        if (!string.IsNullOrEmpty(strList[10]))
                            ta.Addition = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.PayDatetime = strList[11];
                        ta.AccountBankType = AccountBankType.OtherBankAccount;
                    }
                    else if (templateType == AppliableFunctionType.TransferOverBankOut)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "客户业务编号为空";
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.PayerAccount = strList[3];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人账号为空";
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PayeeAccount = strList[4];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人账号为空";
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.PayeeOpenBank = strList[7];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款行名称为空";
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.PayeeName = strList[8];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人名称为空";
                        ta.PayeeAddress = strList[9];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.PayAmount = strList[11];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款金额为空";
                        ta.PayFeeNo = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            ta.PayDatetime = strList[13];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人账号为空";
                        ta.Addition = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            ta.TChanel = DataConvertHelper.Instance.GetTransferChanelType(strList[15]);
                        if (!string.IsNullOrEmpty(strList[16]))
                            ta.Email = strList[16];
                        if (!string.IsNullOrEmpty(strList[19]))
                            ta.AccountBankType = (AccountBankType)((int.Parse(strList[19]) + 1) % 2);
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "是否中行收款标志为空";
                        ta.PayBankNo = strList[20];
                    }
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new TransferAccount();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (templateType == AppliableFunctionType.TransferOverBankIn)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            ta.PayerName = strList[1];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人名称为空";
                        if (!string.IsNullOrEmpty(strList[2]))
                            ta.PayerAccount = strList[2];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人账号为空";
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.PayeeName = strList[3];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人名称为空";
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PayeeAccount = strList[4];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人账号为空";
                        if (!string.IsNullOrEmpty(strList[5]))
                            ta.PayeeOpenBank = strList[5];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人开户行为空";
                        if (!string.IsNullOrEmpty(strList[6]))
                            ta.PayAmount = strList[6];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款金额不能为空";
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.PayProtecolNo = strList[7];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "协议号为空";
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.BusinessType = (BusinessType)int.Parse(strList[8]);
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "业务种类为空";
                        if (!string.IsNullOrEmpty(strList[9]))
                            ta.PayFeeNo = strList[9];
                        if (!string.IsNullOrEmpty(strList[10]))
                            ta.Addition = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.PayDatetime = strList[11];
                        ta.AccountBankType = AccountBankType.OtherBankAccount;
                    }
                    else if (templateType == AppliableFunctionType.TransferOverBankOut)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "客户业务编号为空";
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.PayerAccount = strList[3];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人账号为空";
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PayeeAccount = strList[4];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人账号为空";
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.PayeeOpenBank = strList[7];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款行名称为空";
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.PayeeName = strList[8];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "收款人名称为空";
                        ta.PayeeAddress = strList[9];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.PayAmount = strList[11];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款金额为空";
                        ta.PayFeeNo = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            ta.PayDatetime = strList[13];
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "付款人账号为空";
                        ta.Addition = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            ta.TChanel = (TransferChanelType)int.Parse(strList[15]);
                        if (!string.IsNullOrEmpty(strList[16]))
                            ta.Email = strList[16];
                        if (!string.IsNullOrEmpty(strList[19]))
                            ta.AccountBankType = (AccountBankType)((int.Parse(strList[19]) + 1) % 2);
                        else if (string.IsNullOrEmpty(ta.ErrorReason))
                            ta.ErrorReason = "是否中行收款标志为空";
                        ta.CNAPSNo = strList[20];
                    }
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<TransferAccount> GetTransferOverBankBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<TransferAccount> list = new List<TransferAccount>();

            TransferAccount ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                ta = new TransferAccount();

                string[] strList = AnalyseBOCErrorCSVSytleData(data);
                try
                {
                    ta.RowIndex = int.Parse(strList[0]);
                    ta.ErrorReason = strList[strList.Length - 1];
                    list.Add(ta);
                }
                catch { }
            }

            return list;
        }

        public List<PayeeInfo> GetPayee(List<string> contentData, FunctionInSettingType fst)
        {
            List<PayeeInfo> list = new List<PayeeInfo>();

            int maxcount = SystemSettings.Instance.DefaultMaxCountPayeeMgr;
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            PayeeInfo payee;

            //获取内容信息
            foreach (var data in contentData)
            {
                //if (count >= maxcount) break;
                payee = new PayeeInfo();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (fst == FunctionInSettingType.PayeeMg)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            payee.BankType = (AccountBankType)((int.Parse(strList[0]) + 1) % 2);
                        else throw new Exception();
                        if (!string.IsNullOrEmpty(strList[1]))
                            payee.SerialNo = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            payee.Account = strList[2];
                        if (!string.IsNullOrEmpty(strList[3]))
                            payee.Name = strList[3];
                        if (!string.IsNullOrEmpty(strList[4]))
                            payee.OpenBankName = strList[4];
                        if (!string.IsNullOrEmpty(strList[5]))
                            payee.CNAPSNo = strList[5];
                        if (!string.IsNullOrEmpty(strList[6]))
                            payee.AccountType = (AccountCategoryType)(int.Parse(strList[6]));
                        if (!string.IsNullOrEmpty(strList[7]))
                            payee.CNAPSNoR = strList[7];
                        if (!string.IsNullOrEmpty(strList[8]))
                            payee.ClearBankName = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            payee.CertifyPaperType = (AgentExpressCertifyPaperType)(int.Parse(strList[9]));
                        if (!string.IsNullOrEmpty(strList[10]))
                            payee.CertifyPaperNo = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            payee.Address = strList[11];
                        if (!string.IsNullOrEmpty(strList[12]))
                            payee.Email = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            payee.Telephone = strList[13];
                        if (!string.IsNullOrEmpty(strList[14]))
                            payee.Fax = strList[14];
                    }
                    else if (fst == FunctionInSettingType.AgentExpressInPayerMg)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            payee.BankType = (AccountBankType)((int.Parse(strList[0]) + 1) % 2);
                        else throw new Exception();
                        if (!string.IsNullOrEmpty(strList[1]))
                            payee.SerialNo = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            payee.Account = strList[2];
                        if (!string.IsNullOrEmpty(strList[3]))
                            payee.Name = strList[3];
                        if (!string.IsNullOrEmpty(strList[4]) && payee.BankType != AccountBankType.BocAccount)
                            payee.OpenBankName = strList[4];
                        else if (payee.BankType == AccountBankType.BocAccount)
                            payee.OpenBankName = "中国银行";
                        if (!string.IsNullOrEmpty(strList[5]))
                            payee.CNAPSNo = strList[5];
                        if (!string.IsNullOrEmpty(strList[6]))
                            payee.AccountType = (AccountCategoryType)(int.Parse(strList[6]));
                        if (!string.IsNullOrEmpty(strList[7]))
                            payee.CertifyPaperType = (AgentExpressCertifyPaperType)(int.Parse(strList[7]));
                        if (!string.IsNullOrEmpty(strList[8]))
                            payee.CertifyPaperNo = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            payee.Address = strList[9];
                        if (!string.IsNullOrEmpty(strList[10]))
                            payee.Email = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            payee.Telephone = strList[11];
                        if (!string.IsNullOrEmpty(strList[12]))
                            payee.Fax = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            payee.ProtecolNo = strList[13];
                    }
                }
                catch { throw new Exception(MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail); }
                finally { count++; }
                list.Add(payee);
            }

            return list;
        }

        public List<ElecTicketRelationAccount> GetElecTicketRelateAccount(List<string> contentData, bool flag)
        {
            List<ElecTicketRelationAccount> list = new List<ElecTicketRelationAccount>();

            int maxcount = SystemSettings.Instance.DefaultMaxCountPayeeMgr;
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            ElecTicketRelationAccount payee;

            //获取内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;
                payee = new ElecTicketRelationAccount();
                string[] strList = flag ? data.Split(s, StringSplitOptions.None) : AnalyseBOCCSVSytleData(data);
                try
                {
                    if (flag)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            payee.Account = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            payee.Name = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            payee.OpenBankName = strList[2];
                        if (!string.IsNullOrEmpty(strList[3]))
                            payee.OpenBankNo = strList[3];
                        if (!string.IsNullOrEmpty(strList[4]))
                            payee.PersonType = (RelatePersonType)(int.Parse(strList[4]));
                        if (!string.IsNullOrEmpty(strList[5]))
                            payee.SerialNo = strList[5];
                        if (!string.IsNullOrEmpty(strList[6]))
                            payee.Tel_First = strList[6];
                        if (!string.IsNullOrEmpty(strList[7]))
                            payee.Email_First = strList[7];
                        if (!string.IsNullOrEmpty(strList[8]))
                            payee.Tel_Second = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            payee.Email_Second = strList[9];
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            payee.SerialNo = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            payee.Name = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            payee.Account = strList[2];
                        if (!string.IsNullOrEmpty(strList[3]))
                            payee.OpenBankName = strList[3];
                        if (!string.IsNullOrEmpty(strList[4]))
                            payee.OpenBankNo = strList[4];
                        if (!string.IsNullOrEmpty(strList[5]))
                            payee.PersonType = DataConvertHelper.Instance.GetRelatePersonType(strList[5]);
                        if (!string.IsNullOrEmpty(strList[6]))
                            payee.Tel_First = strList[6];
                        if (!string.IsNullOrEmpty(strList[7]))
                            payee.Email_First = strList[7];
                        if (!string.IsNullOrEmpty(strList[8]))
                            payee.Tel_Second = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            payee.Email_Second = strList[9];
                    }
                }
                catch { throw new Exception(MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail); }
                finally { count++; }
                list.Add(payee);
            }

            return list;
        }

        public List<PayeeInfo4TransferGlobal> GetPayeeInfo4TransferGlobal(List<string> contentData, bool flag)
        {
            List<PayeeInfo4TransferGlobal> list = new List<PayeeInfo4TransferGlobal>();

            int maxcount = SystemSettings.Instance.DefaultMaxCountPayeeMgr;
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            PayeeInfo4TransferGlobal payee;

            //获取内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;
                payee = new PayeeInfo4TransferGlobal();
                string[] strList = flag ? data.Split(s, StringSplitOptions.None) : AnalyseBOCCSVSytleData(data);
                try
                {
                    if (flag)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            payee.AccountType = (OverCountryPayeeAccountType)(int.Parse(strList[0]));
                        if (!string.IsNullOrEmpty(strList[1]))
                            payee.Account = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            payee.Name = strList[2];
                        if (!string.IsNullOrEmpty(strList[3]))
                            payee.Address = strList[3];
                        if (!string.IsNullOrEmpty(strList[4]))
                            payee.CodeofCountry = strList[4];
                        if (!string.IsNullOrEmpty(strList[5]))
                            payee.NameofCountry = strList[5];
                        if (!string.IsNullOrEmpty(strList[6]))
                            payee.OpenBankName = strList[6];
                        if (!string.IsNullOrEmpty(strList[8]))
                            payee.OpenBankAddress = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            payee.CorrespondentBankName = strList[9];
                        if (!string.IsNullOrEmpty(strList[11]))
                            payee.CorrespondentBankAddress = strList[11];
                        if (!string.IsNullOrEmpty(strList[12]))
                            payee.AccountInCorrespondentBank = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            payee.SerialNo = strList[13];
                        if (!string.IsNullOrEmpty(strList[14]))
                            payee.Telephone = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            payee.Fax = strList[15];
                        if (!string.IsNullOrEmpty(strList[16]))
                            payee.Email = strList[16];
                    }
                    else
                    {
                        //if (!string.IsNullOrEmpty(strList[0]))
                        //    payee.AccountType = (OverCountryPayeeAccountType)(int.Parse(strList[0]));
                        //if (!string.IsNullOrEmpty(strList[1]))
                        //    payee.Account = strList[1];
                        //if (!string.IsNullOrEmpty(strList[2]))
                        //    payee.Name = strList[2];
                        //if (!string.IsNullOrEmpty(strList[3]))
                        //    payee.Address = strList[3];
                        //if (!string.IsNullOrEmpty(strList[4]))
                        //    payee.CodeofCountry = strList[4];
                        //if (!string.IsNullOrEmpty(strList[5]))
                        //    payee.NameofCountry = strList[5];
                        //if (!string.IsNullOrEmpty(strList[6]))
                        //    payee.OpenBankName = strList[6];
                        //if (!string.IsNullOrEmpty(strList[7]))
                        //    payee.OpenBankAddress = strList[7];
                        //if (!string.IsNullOrEmpty(strList[8]))
                        //    payee.CorrespondentBankName = strList[8];
                        //if (!string.IsNullOrEmpty(strList[9]))
                        //    payee.CorrespondentBankAddress = strList[9];
                        //if (!string.IsNullOrEmpty(strList[10]))
                        //    payee.AccountInCorrespondentBank = strList[10];
                        //if (!string.IsNullOrEmpty(strList[11]))
                        //    payee.SerialNo = strList[11];
                        //if (!string.IsNullOrEmpty(strList[12]))
                        //    payee.Telephone = strList[12];
                        //if (!string.IsNullOrEmpty(strList[13]))
                        //    payee.Fax = strList[13];
                        //if (!string.IsNullOrEmpty(strList[14]))
                        //    payee.Email = strList[14];
                    }
                }
                catch { throw new Exception(MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail); }
                finally { count++; }
                list.Add(payee);
            }
            return list;
        }

        public List<ElecTicketRemit> GetElecTicketRemit(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketRemit> list = new List<ElecTicketRemit>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            ElecTicketRemit ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new ElecTicketRemit();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.TicketType = DataConvertHelper.Instance.GetElecTicketType(strList[0], templateType);
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.Amount = strList[1].Replace(",", "");
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.RemitDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[2]);
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.EndDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[3]);
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.RemitAccount = strList[4];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.ExchangeName = strList[5];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人名称为空";
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.ExchangeAccount = strList[6];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人账号为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.ExchangeOpenBankName = strList[7];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人开户行名称为空";
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.ExchangeOpenBankNo = strList[8];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.PayeeName = strList[9];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人名称为空";
                    if (!string.IsNullOrEmpty(strList[10]))
                        ta.PayeeAccount = strList[10];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.PayeeOpenBankName = strList[11];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人开户行名称为空";
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.PayeeOpenBankNo = strList[12];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.CanChange = DataConvertHelper.Instance.GetCanChangeType(strList[13]);
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.AutoTipExchange = Convert.ToBoolean(int.Parse(strList[14]));
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.AutoTipReceiveTicket = Convert.ToBoolean(int.Parse(strList[15]));
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.Note = strList[16];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new ElecTicketRemit();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.TicketType = DataConvertHelper.Instance.GetElecTicketType(strList[0], templateType);
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.Amount = strList[1].Replace(",", "");
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.RemitDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[2]);
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.EndDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[3]);
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.RemitAccount = strList[4];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.ExchangeName = strList[5];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人名称为空";
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.ExchangeAccount = strList[6];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人账号为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.ExchangeOpenBankName = strList[7];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人开户行名称为空";
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.ExchangeOpenBankNo = strList[8];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.PayeeName = strList[9];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人名称为空";
                    if (!string.IsNullOrEmpty(strList[10]))
                        ta.PayeeAccount = strList[10];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.PayeeOpenBankName = strList[11];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人开户行名称为空";
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.PayeeOpenBankNo = strList[12];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.CanChange = DataConvertHelper.Instance.GetCanChangeType(strList[13]);
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.AutoTipExchange = Convert.ToBoolean(int.Parse(strList[14]) % 2);
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.AutoTipReceiveTicket = Convert.ToBoolean(int.Parse(strList[15]) % 2);
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.Note = strList[16];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<ElecTicketRemit> GetElecTicketRemitBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketRemit> list = new List<ElecTicketRemit>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            ElecTicketRemit ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new ElecTicketRemit();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.TicketType = DataConvertHelper.Instance.GetElecTicketType(strList[0], templateType);
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.Amount = strList[1].Replace(",", "");
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.RemitDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[2]);
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.EndDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[3]);
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.RemitAccount = strList[4];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.ExchangeName = strList[5];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人名称为空";
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.ExchangeAccount = strList[6];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人账号为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.ExchangeOpenBankName = strList[7];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人开户行名称为空";
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.ExchangeOpenBankNo = strList[8];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.PayeeName = strList[9];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人名称为空";
                    if (!string.IsNullOrEmpty(strList[10]))
                        ta.PayeeAccount = strList[10];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.PayeeOpenBankName = strList[11];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人开户行名称为空";
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.PayeeOpenBankNo = strList[12];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.CanChange = DataConvertHelper.Instance.GetCanChangeType(strList[13]);
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.AutoTipExchange = Convert.ToBoolean(int.Parse(strList[14]) % 2);
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.AutoTipReceiveTicket = Convert.ToBoolean(int.Parse(strList[15]) % 2);
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.Note = strList[16];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new ElecTicketRemit();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.TicketType = DataConvertHelper.Instance.GetElecTicketType(strList[0], templateType);
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.Amount = strList[1].Replace(",", "");
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.RemitDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[2]);
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.EndDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[3]);
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.RemitAccount = strList[4];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.ExchangeName = strList[5];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人名称为空";
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.ExchangeAccount = strList[6];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人账号为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.ExchangeOpenBankName = strList[7];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人开户行名称为空";
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.ExchangeOpenBankNo = strList[8];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "承兑人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.PayeeName = strList[9];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人名称为空";
                    if (!string.IsNullOrEmpty(strList[10]))
                        ta.PayeeAccount = strList[10];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.PayeeOpenBankName = strList[11];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人开户行名称为空";
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.PayeeOpenBankNo = strList[12];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "收款人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.CanChange = DataConvertHelper.Instance.GetCanChangeType(strList[13]);
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.AutoTipExchange = Convert.ToBoolean(int.Parse(strList[14]) % 2);
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.AutoTipReceiveTicket = Convert.ToBoolean(int.Parse(strList[15]) % 2);
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.Note = strList[16];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<ElecTicketRemit> GetElecTicketRemitBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketRemit> list = new List<ElecTicketRemit>();

            ElecTicketRemit ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                ta = new ElecTicketRemit();

                string[] strList = AnalyseBOCErrorCSVSytleData(data);
                try
                {
                    ta.RowIndex = int.Parse(strList[0]);
                    ta.ErrorReason = strList[1];//strList[strList.Length - 1];
                    list.Add(ta);
                }
                catch { }
            }

            return list;
        }

        public List<ElecTicketBackNote> GetElecTicketBackNote(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketBackNote> list = new List<ElecTicketBackNote>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            ElecTicketBackNote ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new ElecTicketBackNote();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.RemitAccount = strList[0];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketSerialNo = strList[1];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "票据编号为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.BackNotedName = strList[2];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人名称为空";
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.BackNotedAccount = strList[3];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人账号为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.BackNotedOpenBankName = strList[4];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人开户行名称为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.BackNotedOpenBankNo = strList[5];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.Note = strList[6];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new ElecTicketBackNote();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.RemitAccount = strList[0];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketSerialNo = strList[1];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "票据编号为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.BackNotedName = strList[2];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人名称为空";
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.BackNotedAccount = strList[3];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人账号为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.BackNotedOpenBankName = strList[4];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人开户行名称为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.BackNotedOpenBankNo = strList[5];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.Note = strList[6];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<ElecTicketBackNote> GetElecTicketBackNoteBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketBackNote> list = new List<ElecTicketBackNote>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            ElecTicketBackNote ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new ElecTicketBackNote();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.RemitAccount = strList[0];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketSerialNo = strList[1];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "票据编号为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.BackNotedName = strList[2];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人名称为空";
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.BackNotedAccount = strList[3];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人账号为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.BackNotedOpenBankName = strList[4];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人开户行名称为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.BackNotedOpenBankNo = strList[5];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.Note = strList[6];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new ElecTicketBackNote();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.RemitAccount = strList[0];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketSerialNo = strList[1];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "票据编号为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.BackNotedName = strList[2];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人名称为空";
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.BackNotedAccount = strList[3];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人账号为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.BackNotedOpenBankName = strList[4];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人开户行名称为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.BackNotedOpenBankNo = strList[5];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "被背书人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.Note = strList[6];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<ElecTicketBackNote> GetElecTicketBackNoteBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketBackNote> list = new List<ElecTicketBackNote>();

            ElecTicketBackNote ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                ta = new ElecTicketBackNote();

                string[] strList = AnalyseBOCErrorCSVSytleData(data);
                try
                {
                    ta.RowIndex = int.Parse(strList[0]);
                    ta.ErrorReason = strList[1];//[strList.Length - 1];
                    list.Add(ta);
                }
                catch { }
            }

            return list;
        }

        public List<ElecTicketAutoTipExchange> GetElecTicketAutoTipExchange(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketAutoTipExchange> list = new List<ElecTicketAutoTipExchange>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            ElecTicketAutoTipExchange ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new ElecTicketAutoTipExchange();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.RemitAccount = strList[0];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketSerialNo = strList[1];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "票据编号为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.ExchangeName = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.ExchangeAccount = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.ExchangeOpenBankName = strList[4];
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.ExchangeOpenBankNo = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.ContractNo = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.BillSerialNo = strList[7];
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.Note = strList[8];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new ElecTicketAutoTipExchange();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.RemitAccount = strList[0];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketSerialNo = strList[1];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "票据编号为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.ExchangeName = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.ExchangeAccount = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.ExchangeOpenBankName = strList[4];
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.ExchangeOpenBankNo = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.ContractNo = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.BillSerialNo = strList[7];
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.Note = strList[8];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<ElecTicketAutoTipExchange> GetElecTicketAutoTipExchangeBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketAutoTipExchange> list = new List<ElecTicketAutoTipExchange>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            ElecTicketAutoTipExchange ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new ElecTicketAutoTipExchange();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.RemitAccount = strList[0];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketSerialNo = strList[1];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "票据编号为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.ExchangeName = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.ExchangeAccount = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.ExchangeOpenBankName = strList[4];
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.ExchangeOpenBankNo = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.ContractNo = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.BillSerialNo = strList[7];
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.Note = strList[8];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new ElecTicketAutoTipExchange();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.RemitAccount = strList[0];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketSerialNo = strList[1];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "票据编号为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.ExchangeName = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.ExchangeAccount = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.ExchangeOpenBankName = strList[4];
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.ExchangeOpenBankNo = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.ContractNo = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.BillSerialNo = strList[7];
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.Note = strList[8];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<ElecTicketAutoTipExchange> GetElecTicketAutoTipExchangeBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketAutoTipExchange> list = new List<ElecTicketAutoTipExchange>();

            ElecTicketAutoTipExchange ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                ta = new ElecTicketAutoTipExchange();

                string[] strList = AnalyseBOCErrorCSVSytleData(data);
                try
                {
                    ta.RowIndex = int.Parse(strList[0]);
                    ta.ErrorReason = strList[1];//[strList.Length - 1];
                    list.Add(ta);
                }
                catch { }
            }

            return list;
        }

        public List<ElecTicketPayMoney> GetElecTicketPayMoney(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketPayMoney> list = new List<ElecTicketPayMoney>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            ElecTicketPayMoney ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new ElecTicketPayMoney();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.RemitAccount = strList[0];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketSerialNo = strList[1];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "票据编号为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.PayMoneyType = "买断式";//strList[2];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现种类为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.ClearType = DataConvertHelper.Instance.GetClearType(strList[5]);
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "清算方式为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.ProtocolMoneyType = DataConvertHelper.Instance.GetProtocolMoneyType(strList[3]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.PayMoneyDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[6]);
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现日期为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.PayMoneyPercent = double.Parse(strList[7]);
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.PayMoneyAccount = strList[8];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现入账账号为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.PayMoneyOpenBankName = strList[9];
                    if (!string.IsNullOrEmpty(strList[10]))
                        ta.PayMoneyOpenBankNo = strList[10];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现入账行号为空";
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.StickOnName = strList[11];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人名称为空";
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.StickOnAccount = strList[12];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人账号为空";
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.StickOnOpenBankName = strList[13];
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.StickOnOpenBankNo = strList[14];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.ContractNo = strList[15];
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.BillSerialNo = strList[16];
                    if (!string.IsNullOrEmpty(strList[17]))
                        ta.Note = strList[17];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new ElecTicketPayMoney();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.RemitAccount = strList[0];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketSerialNo = strList[1];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "票据编号为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.PayMoneyType = "买断式";//strList[2];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现种类为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.ClearType = DataConvertHelper.Instance.GetClearType(strList[5]);
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "清算方式为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.ProtocolMoneyType = DataConvertHelper.Instance.GetProtocolMoneyType(strList[3]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.PayMoneyDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[6]);
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现日期为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.PayMoneyPercent = double.Parse(strList[7]);
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.PayMoneyAccount = strList[8];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现入账账号为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.PayMoneyOpenBankName = strList[9];
                    if (!string.IsNullOrEmpty(strList[10]))
                        ta.PayMoneyOpenBankNo = strList[10];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现入账行号为空";
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.StickOnName = strList[11];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人名称为空";
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.StickOnAccount = strList[12];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人账号为空";
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.StickOnOpenBankName = strList[13];
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.StickOnOpenBankNo = strList[14];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.ContractNo = strList[15];
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.BillSerialNo = strList[16];
                    if (!string.IsNullOrEmpty(strList[17]))
                        ta.Note = strList[17];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<ElecTicketPayMoney> GetElecTicketPayMoneyBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketPayMoney> list = new List<ElecTicketPayMoney>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            ElecTicketPayMoney ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new ElecTicketPayMoney();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.RemitAccount = strList[0];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketSerialNo = strList[1];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "票据编号为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.PayMoneyType = "买断式";//strList[2];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现种类为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.ClearType = DataConvertHelper.Instance.GetClearType(strList[5]);
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "清算方式为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.ProtocolMoneyType = DataConvertHelper.Instance.GetProtocolMoneyType(strList[3]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.PayMoneyDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[6]);
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现日期为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.PayMoneyPercent = double.Parse(strList[7]);
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.PayMoneyAccount = strList[8];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现入账账号为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.PayMoneyOpenBankName = strList[9];
                    if (!string.IsNullOrEmpty(strList[10]))
                        ta.PayMoneyOpenBankNo = strList[10];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现入账行号为空";
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.StickOnName = strList[11];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人名称为空";
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.StickOnAccount = strList[12];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人账号为空";
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.StickOnOpenBankName = strList[13];
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.StickOnOpenBankNo = strList[14];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.ContractNo = strList[15];
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.BillSerialNo = strList[16];
                    if (!string.IsNullOrEmpty(strList[17]))
                        ta.Note = strList[17];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new ElecTicketPayMoney();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.RemitAccount = strList[0];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "出票人账号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketSerialNo = strList[1];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "票据编号为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.PayMoneyType = "买断式";//strList[2];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现种类为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.ClearType = DataConvertHelper.Instance.GetClearType(strList[5]);
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "清算方式为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.ProtocolMoneyType = DataConvertHelper.Instance.GetProtocolMoneyType(strList[3]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.PayMoneyDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[6]);
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现日期为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.PayMoneyPercent = double.Parse(strList[7]);
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.PayMoneyAccount = strList[8];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现入账账号为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.PayMoneyOpenBankName = strList[9];
                    if (!string.IsNullOrEmpty(strList[10]))
                        ta.PayMoneyOpenBankNo = strList[10];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴现入账行号为空";
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.StickOnName = strList[11];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人名称为空";
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.StickOnAccount = strList[12];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人账号为空";
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.StickOnOpenBankName = strList[13];
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.StickOnOpenBankNo = strList[14];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.ContractNo = strList[15];
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.BillSerialNo = strList[16];
                    if (!string.IsNullOrEmpty(strList[17]))
                        ta.Note = strList[17];
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<ElecTicketPayMoney> GetElecTicketPayMoneyBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketPayMoney> list = new List<ElecTicketPayMoney>();

            ElecTicketPayMoney ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                ta = new ElecTicketPayMoney();

                string[] strList = AnalyseBOCErrorCSVSytleData(data);
                try
                {
                    ta.RowIndex = int.Parse(strList[0]);
                    ta.ErrorReason = strList[1];//[strList.Length - 1];
                    list.Add(ta);
                }
                catch { }
            }

            return list;
        }

        public List<ElecTicketPool> GetElecTicketPool(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketPool> list = new List<ElecTicketPool>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            ElecTicketPool ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new ElecTicketPool();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.CustomerRef = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketType = DataConvertHelper.Instance.GetElecTicketType(strList[1], templateType);
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.BankType = DataConvertHelper.Instance.GetAccountBankTypeObject(strList[2], templateType);
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.ElecTicketSerialNo = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.Amount = DataConvertHelper.Instance.FormatCash(strList[4], false);
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.RemitDate = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.EndDate = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.RemitName = strList[7];
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.RemitAccount = strList[8];
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.ExchangeName = strList[9];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人名称为空";
                    if (!string.IsNullOrEmpty(strList[10]))
                        ta.ExchangeAccount = strList[10];
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.ExchangeBankNo = strList[11];
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.ExchangeDate = strList[12];
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.PayeeName = strList[13];
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.PayeeAccount = strList[14];
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.PayeeOpenBankName = strList[15];
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.PayeeOpenBankNo = strList[16];
                    if (!string.IsNullOrEmpty(strList[17]))
                        ta.PreBackNotedPerson = strList[17];
                    if (!string.IsNullOrEmpty(strList[18]))
                        ta.EndDateOperate = DataConvertHelper.Instance.GetEndDateOperateType(strList[18]);
                    if (!string.IsNullOrEmpty(strList[19]))
                        ta.BusinessType = DataConvertHelper.Instance.GetElecTicketPoolBusinessType(strList[19]);
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new ElecTicketPool();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.CustomerRef = strList[0];
                    //else if (string.IsNullOrEmpty(ta.ErrorReason))
                    //    ta.ErrorReason = "";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketType = DataConvertHelper.Instance.GetElecTicketType(strList[1], templateType);
                    //else if (string.IsNullOrEmpty(ta.ErrorReason))
                    //    ta.ErrorReason = "";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.BankType = DataConvertHelper.Instance.GetAccountBankTypeObject(strList[2], templateType);
                    //else if (string.IsNullOrEmpty(ta.ErrorReason))
                    //    ta.ErrorReason = "";
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.ElecTicketSerialNo = strList[3];
                    //else if (string.IsNullOrEmpty(ta.ErrorReason))
                    //    ta.ErrorReason = "清算方式为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.Amount = DataConvertHelper.Instance.FormatCash(strList[4], false);
                    //else if (string.IsNullOrEmpty(ta.ErrorReason))
                    //    ta.ErrorReason = "贴现日期为空";
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.RemitDate = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.EndDate = strList[6];
                    //else if (string.IsNullOrEmpty(ta.ErrorReason))
                    //    ta.ErrorReason = "贴现入账账号为空";
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.RemitName = strList[7];
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.RemitAccount = strList[8];
                    //else if (string.IsNullOrEmpty(ta.ErrorReason))
                    //    ta.ErrorReason = "贴现入账行号为空";
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.ExchangeName = strList[9];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人名称为空";
                    if (!string.IsNullOrEmpty(strList[10]))
                        ta.ExchangeAccount = strList[10];
                    //else if (string.IsNullOrEmpty(ta.ErrorReason))
                    //    ta.ErrorReason = "贴入人账号为空";
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.ExchangeBankNo = strList[11];
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.ExchangeDate = strList[12];
                    //else if (string.IsNullOrEmpty(ta.ErrorReason))
                    //    ta.ErrorReason = "贴入人开户行行号为空";
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.PayeeName = strList[13];
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.PayeeAccount = strList[14];
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.PayeeOpenBankName = strList[15];
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.PayeeOpenBankNo = strList[16];
                    if (!string.IsNullOrEmpty(strList[17]))
                        ta.PreBackNotedPerson = strList[17];
                    if (!string.IsNullOrEmpty(strList[18]))
                        ta.EndDateOperate = DataConvertHelper.Instance.GetEndDateOperateType(strList[18]);
                    if (!string.IsNullOrEmpty(strList[19]))
                        ta.BusinessType = DataConvertHelper.Instance.GetElecTicketPoolBusinessType(strList[19]);
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<ElecTicketPool> GetElecTicketPoolBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketPool> list = new List<ElecTicketPool>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            ElecTicketPool ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new ElecTicketPool();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.CustomerRef = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketType = DataConvertHelper.Instance.GetElecTicketType(strList[1], templateType);
                    if (!string.IsNullOrEmpty(strList[2]) && ta.ElecTicketType == ElecTicketType.AC01)
                        ta.BankType = DataConvertHelper.Instance.GetAccountBankTypeObject(strList[2], templateType);
                    else ta.BankType = AccountBankType.Empty;
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.ElecTicketSerialNo = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.Amount = DataConvertHelper.Instance.FormatCash(strList[4], false);
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.RemitDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[5]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.EndDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[6]);
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.RemitName = strList[7];
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.RemitAccount = strList[8];
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.ExchangeName = strList[9];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人名称为空";
                    if (!string.IsNullOrEmpty(strList[10]))
                        ta.ExchangeAccount = strList[10];
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.ExchangeBankNo = strList[11];
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.ExchangeDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[12]);
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.PayeeName = strList[13];
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.PayeeAccount = strList[14];
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.PayeeOpenBankName = strList[15];
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.PayeeOpenBankNo = strList[16];
                    if (!string.IsNullOrEmpty(strList[17]))
                        ta.PreBackNotedPerson = strList[17];
                    if (!string.IsNullOrEmpty(strList[18]))
                        ta.EndDateOperate = DataConvertHelper.Instance.GetEndDateOperateType(strList[18]);
                    if (!string.IsNullOrEmpty(strList[19]))
                        ta.BusinessType = DataConvertHelper.Instance.GetElecTicketPoolBusinessType(strList[19]);
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new ElecTicketPool();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ta.CustomerRef = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        ta.ElecTicketType = DataConvertHelper.Instance.GetElecTicketType(strList[1], templateType);
                    if (!string.IsNullOrEmpty(strList[2]))
                        ta.BankType = DataConvertHelper.Instance.GetAccountBankTypeObject(strList[2], templateType);
                    if (!string.IsNullOrEmpty(strList[3]))
                        ta.ElecTicketSerialNo = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ta.Amount = DataConvertHelper.Instance.FormatCash(strList[4], false);
                    if (!string.IsNullOrEmpty(strList[5]))
                        ta.RemitDate = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        ta.EndDate = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        ta.RemitName = strList[7];
                    if (!string.IsNullOrEmpty(strList[8]))
                        ta.RemitAccount = strList[8];
                    if (!string.IsNullOrEmpty(strList[9]))
                        ta.ExchangeName = strList[9];
                    else if (string.IsNullOrEmpty(ta.ErrorReason))
                        ta.ErrorReason = "贴入人名称为空";
                    if (!string.IsNullOrEmpty(strList[10]))
                        ta.ExchangeAccount = strList[10];
                    if (!string.IsNullOrEmpty(strList[11]))
                        ta.ExchangeBankNo = strList[11];
                    if (!string.IsNullOrEmpty(strList[12]))
                        ta.ExchangeDate = strList[12];
                    if (!string.IsNullOrEmpty(strList[13]))
                        ta.PayeeName = strList[13];
                    if (!string.IsNullOrEmpty(strList[14]))
                        ta.PayeeAccount = strList[14];
                    if (!string.IsNullOrEmpty(strList[15]))
                        ta.PayeeOpenBankName = strList[15];
                    if (!string.IsNullOrEmpty(strList[16]))
                        ta.PayeeOpenBankNo = strList[16];
                    if (!string.IsNullOrEmpty(strList[17]))
                        ta.PreBackNotedPerson = strList[17];
                    if (!string.IsNullOrEmpty(strList[18]))
                        ta.EndDateOperate = DataConvertHelper.Instance.GetEndDateOperateType(strList[18]);
                    if (!string.IsNullOrEmpty(strList[19]))
                        ta.BusinessType = DataConvertHelper.Instance.GetElecTicketPoolBusinessType(strList[19]);
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<ElecTicketPool> GetElecTicketPoolBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<ElecTicketPool> list = new List<ElecTicketPool>();

            ElecTicketPool ta;
            if (templateType == AppliableFunctionType.ElecTicketPool)
            {
                //获取交易内容信息
                foreach (var data in contentData)
                {
                    ta = new ElecTicketPool();

                    string[] strList = AnalyseBOCErrorCSVSytleData(data);
                    try
                    {
                        ta.RowIndex = int.Parse(strList[0]);
                        ta.ErrorReason = strList[strList.Length - 1];
                        list.Add(ta);
                    }
                    catch { }
                }
            }

            return list;
        }

        public List<TransferGlobal> GetTransferGlobal(List<string> contentData, AppliableFunctionType templateType)
        {
            List<TransferGlobal> list = new List<TransferGlobal>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            TransferGlobal ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new TransferGlobal();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.TransferOverCountry)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            ta.PayDate = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            ta.PaymentType = "电汇";
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[3]);
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PaymentCashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                        if (!string.IsNullOrEmpty(strList[5]))
                            ta.RemitAmount = DataConvertHelper.Instance.FormatCash(strList[5], false);
                        if (!string.IsNullOrEmpty(strList[6]))
                            ta.SpotAccount = strList[6];
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.SpotAmount = DataConvertHelper.Instance.FormatCash(strList[7], false);
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.PurchaseAccount = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            ta.PurchaseAmount = DataConvertHelper.Instance.FormatCash(strList[9], false);
                        if (!string.IsNullOrEmpty(strList[10]))
                            ta.OtherAccount = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.OtherAmount = DataConvertHelper.Instance.FormatCash(strList[11], false);
                        if (!string.IsNullOrEmpty(strList[12]))
                            ta.PayFeeAccount = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            ta.RemitName = strList[13];
                        if (!string.IsNullOrEmpty(strList[14]))
                            ta.RemitAddress = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            ta.OrgCode = strList[15];
                        if (!string.IsNullOrEmpty(strList[16]))
                            ta.CorrespondentBankName = strList[16];
                        if (!string.IsNullOrEmpty(strList[17]))
                            ta.CorrespondentBankAddress = strList[17];
                        if (!string.IsNullOrEmpty(strList[18]))
                            ta.PayeeOpenBankName = strList[18];
                        if (!string.IsNullOrEmpty(strList[19]))
                            ta.PayeeOpenBankAddress = strList[19];
                        if (!string.IsNullOrEmpty(strList[20]))
                            ta.PayeeAccountInCorrespondentBank = strList[20];
                        if (!string.IsNullOrEmpty(strList[21]))
                            ta.PayeeName = strList[21];
                        if (!string.IsNullOrEmpty(strList[22]))
                            ta.PayeeAddress = strList[22];
                        if (!string.IsNullOrEmpty(strList[23]))
                            ta.PayeeAccount = strList[23];
                        if (!string.IsNullOrEmpty(strList[24]))
                            ta.RemitNote = strList[24];
                        if (!string.IsNullOrEmpty(strList[25]))
                            ta.AssumeFeeType = DataConvertHelper.Instance.GetAssumeFeeType(strList[25]);
                        if (!string.IsNullOrEmpty(strList[26]))
                            ta.PayeeCodeofCountry = strList[26];
                        if (!string.IsNullOrEmpty(strList[27]))
                            ta.PayeeNameofCountry = strList[27];
                        if (!string.IsNullOrEmpty(strList[28]))
                            ta.PayFeeType = DataConvertHelper.Instance.GetPayFeeType(strList[28]);
                        if (!string.IsNullOrEmpty(strList[29]))
                            ta.DealSerialNoF = strList[29];
                        if (!string.IsNullOrEmpty(strList[30]))
                            ta.AmountF = DataConvertHelper.Instance.FormatCash(strList[30], false);
                        if (!string.IsNullOrEmpty(strList[31]))
                            ta.DealNoteF = strList[31];
                        if (!string.IsNullOrEmpty(strList[32]))
                            ta.DealSerialNoS = strList[32];
                        if (!string.IsNullOrEmpty(strList[33]))
                            ta.AmountS = DataConvertHelper.Instance.FormatCash(strList[33], false);
                        if (!string.IsNullOrEmpty(strList[34]))
                            ta.DealNoteS = strList[34];
                        if (!string.IsNullOrEmpty(strList[35]))
                            ta.IsPayOffLine = DataConvertHelper.Instance.GetIsPayOffLine(strList[35]);
                        if (!string.IsNullOrEmpty(strList[36]))
                            ta.ContactNo = strList[36];
                        if (!string.IsNullOrEmpty(strList[37]))
                            ta.BillSerialNo = strList[37];
                        if (!string.IsNullOrEmpty(strList[38]))
                            ta.BatchNoOrTNoOrSerialNo = strList[38];
                        if (!string.IsNullOrEmpty(strList[39]))
                            ta.ProposerName = strList[39];
                        if (!string.IsNullOrEmpty(strList[40]))
                            ta.Telephone = strList[40];
                    }
                    else if (templateType == AppliableFunctionType.TransferForeignMoney)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            ta.PayDate = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            ta.PaymentType = strList[2];
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[3]);
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PaymentCashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                        if (!string.IsNullOrEmpty(strList[5]))
                            ta.RemitAmount = DataConvertHelper.Instance.FormatCash(strList[5], false);
                        if (!string.IsNullOrEmpty(strList[6]))
                            ta.SpotAccount = strList[6];
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.SpotAmount = DataConvertHelper.Instance.FormatCash(strList[7], false);
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.PurchaseAccount = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            ta.PurchaseAmount = DataConvertHelper.Instance.FormatCash(strList[9], false);
                        if (!string.IsNullOrEmpty(strList[10]))
                            ta.OtherAccount = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.OtherAmount = DataConvertHelper.Instance.FormatCash(strList[11], false);
                        if (!string.IsNullOrEmpty(strList[12]))
                            ta.PayFeeAccount = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            ta.RemitName = strList[13];
                        if (!string.IsNullOrEmpty(strList[14]))
                            ta.RemitAddress = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            ta.OrgCode = strList[15];
                        if (!string.IsNullOrEmpty(strList[16]))
                            ta.CorrespondentBankName = strList[16];
                        if (!string.IsNullOrEmpty(strList[17]))
                            ta.CorrespondentBankAddress = strList[17];
                        if (!string.IsNullOrEmpty(strList[18]))
                            ta.PayeeOpenBankType = (AccountBankType)((int.Parse(strList[18]) + 1) % 2);
                        if (!string.IsNullOrEmpty(strList[19]))
                            ta.PayeeOpenBankName = strList[19];
                        if (!string.IsNullOrEmpty(strList[20]))
                            ta.PayeeOpenBankAddress = strList[20];
                        if (!string.IsNullOrEmpty(strList[21]))
                            ta.PayeeAccountInCorrespondentBank = strList[21];
                        if (!string.IsNullOrEmpty(strList[22]))
                            ta.PayeeName = strList[22];
                        if (!string.IsNullOrEmpty(strList[23]))
                            ta.PayeeAddress = strList[23];
                        if (!string.IsNullOrEmpty(strList[24]))
                            ta.PayeeAccount = strList[24];
                        if (!string.IsNullOrEmpty(strList[25]))
                            ta.RemitNote = strList[25];
                        if (!string.IsNullOrEmpty(strList[26]))
                            ta.AssumeFeeType = DataConvertHelper.Instance.GetAssumeFeeType(strList[26]);
                        if (!string.IsNullOrEmpty(strList[27]))
                            ta.PayeeCodeofCountry = strList[27];
                        if (!string.IsNullOrEmpty(strList[28]))
                            ta.PayeeNameofCountry = strList[28];
                        if (!string.IsNullOrEmpty(strList[29]))
                            ta.PayFeeType = DataConvertHelper.Instance.GetPayFeeType(strList[29]);
                        if (!string.IsNullOrEmpty(strList[30]))
                            ta.PaymentPropertyType = DataConvertHelper.Instance.GetPaymentPropertyType(strList[30]);
                        if (!string.IsNullOrEmpty(strList[31]))
                            ta.DealSerialNoF = strList[31];
                        if (!string.IsNullOrEmpty(strList[32]))
                            ta.AmountF = DataConvertHelper.Instance.FormatCash(strList[32], false);
                        if (!string.IsNullOrEmpty(strList[33]))
                            ta.DealSerialNoS = strList[33];
                        if (!string.IsNullOrEmpty(strList[34]))
                            ta.AmountS = DataConvertHelper.Instance.FormatCash(strList[34], false);
                        if (!string.IsNullOrEmpty(strList[35]))
                            ta.IsPayOffLine = DataConvertHelper.Instance.GetIsPayOffLine(strList[35]);
                        if (!string.IsNullOrEmpty(strList[36]))
                            ta.ContactNo = strList[36];
                        if (!string.IsNullOrEmpty(strList[37]))
                            ta.BillSerialNo = strList[37];
                        if (!string.IsNullOrEmpty(strList[38]))
                            ta.BatchNoOrTNoOrSerialNo = strList[38];
                        if (!string.IsNullOrEmpty(strList[39]))
                            ta.ProposerName = strList[39];
                        if (!string.IsNullOrEmpty(strList[40]))
                            ta.Telephone = strList[40];
                    }
                    #endregion
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new TransferGlobal();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.TransferOverCountry)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            ta.PayDate = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            ta.PaymentType = "电汇";
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[3]);
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PaymentCashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                        if (!string.IsNullOrEmpty(strList[5]))
                            ta.RemitAmount = DataConvertHelper.Instance.FormatCash(strList[5], false);
                        if (!string.IsNullOrEmpty(strList[6]))
                            ta.SpotAccount = strList[6];
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.SpotAmount = DataConvertHelper.Instance.FormatCash(strList[7], false);
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.PurchaseAccount = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            ta.PurchaseAmount = DataConvertHelper.Instance.FormatCash(strList[9], false);
                        if (!string.IsNullOrEmpty(strList[10]))
                            ta.OtherAccount = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.OtherAmount = DataConvertHelper.Instance.FormatCash(strList[11], false);
                        if (!string.IsNullOrEmpty(strList[12]))
                            ta.PayFeeAccount = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            ta.RemitName = strList[13];
                        if (!string.IsNullOrEmpty(strList[14]))
                            ta.RemitAddress = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            ta.OrgCode = strList[15];
                        if (!string.IsNullOrEmpty(strList[16]))
                            ta.CorrespondentBankName = strList[16];
                        if (!string.IsNullOrEmpty(strList[17]))
                            ta.CorrespondentBankAddress = strList[17];
                        if (!string.IsNullOrEmpty(strList[18]))
                            ta.PayeeOpenBankName = strList[18];
                        if (!string.IsNullOrEmpty(strList[19]))
                            ta.PayeeOpenBankAddress = strList[19];
                        if (!string.IsNullOrEmpty(strList[20]))
                            ta.PayeeAccountInCorrespondentBank = strList[20];
                        if (!string.IsNullOrEmpty(strList[21]))
                            ta.PayeeName = strList[21];
                        if (!string.IsNullOrEmpty(strList[22]))
                            ta.PayeeAddress = strList[22];
                        if (!string.IsNullOrEmpty(strList[23]))
                            ta.PayeeAccount = strList[23];
                        if (!string.IsNullOrEmpty(strList[24]))
                            ta.RemitNote = strList[24];
                        if (!string.IsNullOrEmpty(strList[25]))
                            ta.AssumeFeeType = DataConvertHelper.Instance.GetAssumeFeeType(strList[25]);
                        if (!string.IsNullOrEmpty(strList[26]))
                            ta.PayeeCodeofCountry = strList[26];
                        if (!string.IsNullOrEmpty(strList[27]))
                            ta.PayeeNameofCountry = strList[27];
                        if (!string.IsNullOrEmpty(strList[28]))
                            ta.PayFeeType = DataConvertHelper.Instance.GetPayFeeType(strList[28]);
                        if (!string.IsNullOrEmpty(strList[29]))
                            ta.DealSerialNoF = strList[29];
                        if (!string.IsNullOrEmpty(strList[30]))
                            ta.AmountF = DataConvertHelper.Instance.FormatCash(strList[30], false);
                        if (!string.IsNullOrEmpty(strList[31]))
                            ta.DealNoteF = strList[31];
                        if (!string.IsNullOrEmpty(strList[32]))
                            ta.DealSerialNoS = strList[32];
                        if (!string.IsNullOrEmpty(strList[33]))
                            ta.AmountS = DataConvertHelper.Instance.FormatCash(strList[33], false);
                        if (!string.IsNullOrEmpty(strList[34]))
                            ta.DealNoteS = strList[34];
                        if (!string.IsNullOrEmpty(strList[35]))
                            ta.IsPayOffLine = DataConvertHelper.Instance.GetIsPayOffLine(strList[35]);
                        if (!string.IsNullOrEmpty(strList[36]))
                            ta.ContactNo = strList[36];
                        if (!string.IsNullOrEmpty(strList[37]))
                            ta.BillSerialNo = strList[37];
                        if (!string.IsNullOrEmpty(strList[38]))
                            ta.BatchNoOrTNoOrSerialNo = strList[38];
                        if (!string.IsNullOrEmpty(strList[39]))
                            ta.ProposerName = strList[39];
                        if (!string.IsNullOrEmpty(strList[40]))
                            ta.Telephone = strList[40];
                    }
                    else if (templateType == AppliableFunctionType.TransferForeignMoney)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            ta.PayDate = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            ta.PaymentType = strList[2];
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[3]);
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PaymentCashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                        if (!string.IsNullOrEmpty(strList[5]))
                            ta.RemitAmount = DataConvertHelper.Instance.FormatCash(strList[5], false);
                        if (!string.IsNullOrEmpty(strList[6]))
                            ta.SpotAccount = strList[6];
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.SpotAmount = DataConvertHelper.Instance.FormatCash(strList[7], false);
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.PurchaseAccount = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            ta.PurchaseAmount = DataConvertHelper.Instance.FormatCash(strList[9], false);
                        if (!string.IsNullOrEmpty(strList[10]))
                            ta.OtherAccount = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.OtherAmount = DataConvertHelper.Instance.FormatCash(strList[11], false);
                        if (!string.IsNullOrEmpty(strList[12]))
                            ta.PayFeeAccount = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            ta.RemitName = strList[13];
                        if (!string.IsNullOrEmpty(strList[14]))
                            ta.RemitAddress = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            ta.OrgCode = strList[15];
                        if (!string.IsNullOrEmpty(strList[16]))
                            ta.CorrespondentBankName = strList[16];
                        if (!string.IsNullOrEmpty(strList[17]))
                            ta.CorrespondentBankAddress = strList[17];
                        if (!string.IsNullOrEmpty(strList[18]))
                            ta.PayeeOpenBankType = (AccountBankType)((int.Parse(strList[18]) + 1) % 2);
                        if (!string.IsNullOrEmpty(strList[19]))
                            ta.PayeeOpenBankName = strList[19];
                        if (!string.IsNullOrEmpty(strList[20]))
                            ta.PayeeOpenBankAddress = strList[20];
                        if (!string.IsNullOrEmpty(strList[21]))
                            ta.PayeeAccountInCorrespondentBank = strList[21];
                        if (!string.IsNullOrEmpty(strList[22]))
                            ta.PayeeName = strList[22];
                        if (!string.IsNullOrEmpty(strList[23]))
                            ta.PayeeAddress = strList[23];
                        if (!string.IsNullOrEmpty(strList[24]))
                            ta.PayeeAccount = strList[24];
                        if (!string.IsNullOrEmpty(strList[25]))
                            ta.RemitNote = strList[25];
                        if (!string.IsNullOrEmpty(strList[26]))
                            ta.AssumeFeeType = DataConvertHelper.Instance.GetAssumeFeeType(strList[26]);
                        if (!string.IsNullOrEmpty(strList[27]))
                            ta.PayeeCodeofCountry = strList[27];
                        if (!string.IsNullOrEmpty(strList[28]))
                            ta.PayeeNameofCountry = strList[28];
                        if (!string.IsNullOrEmpty(strList[29]))
                            ta.PayFeeType = DataConvertHelper.Instance.GetPayFeeType(strList[29]);
                        if (!string.IsNullOrEmpty(strList[30]))
                            ta.PaymentPropertyType = DataConvertHelper.Instance.GetPaymentPropertyType(strList[30]);
                        if (!string.IsNullOrEmpty(strList[31]))
                            ta.DealSerialNoF = strList[31];
                        if (!string.IsNullOrEmpty(strList[32]))
                            ta.AmountF = DataConvertHelper.Instance.FormatCash(strList[32], false);
                        if (!string.IsNullOrEmpty(strList[33]))
                            ta.DealSerialNoS = strList[33];
                        if (!string.IsNullOrEmpty(strList[34]))
                            ta.AmountS = DataConvertHelper.Instance.FormatCash(strList[34], false);
                        if (!string.IsNullOrEmpty(strList[35]))
                            ta.IsPayOffLine = DataConvertHelper.Instance.GetIsPayOffLine(strList[35]);
                        if (!string.IsNullOrEmpty(strList[36]))
                            ta.ContactNo = strList[36];
                        if (!string.IsNullOrEmpty(strList[37]))
                            ta.BillSerialNo = strList[37];
                        if (!string.IsNullOrEmpty(strList[38]))
                            ta.BatchNoOrTNoOrSerialNo = strList[38];
                        if (!string.IsNullOrEmpty(strList[39]))
                            ta.ProposerName = strList[39];
                        if (!string.IsNullOrEmpty(strList[40]))
                            ta.Telephone = strList[40];
                    }
                    #endregion
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<TransferGlobal> GetTransferGlobalBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<TransferGlobal> list = new List<TransferGlobal>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            TransferGlobal ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                ta = new TransferGlobal();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.TransferOverCountry)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            ta.PayDate = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            ta.PaymentType = "电汇";
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[3]);
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PaymentCashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                        if (!string.IsNullOrEmpty(strList[5]))
                            ta.RemitAmount = DataConvertHelper.Instance.FormatCash(strList[5], false);
                        if (!string.IsNullOrEmpty(strList[6]))
                            ta.SpotAccount = strList[6];
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.SpotAmount = DataConvertHelper.Instance.FormatCash(strList[7], false);
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.PurchaseAccount = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            ta.PurchaseAmount = DataConvertHelper.Instance.FormatCash(strList[9], false);
                        if (!string.IsNullOrEmpty(strList[10]))
                            ta.OtherAccount = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.OtherAmount = DataConvertHelper.Instance.FormatCash(strList[11], false);
                        if (!string.IsNullOrEmpty(strList[12]))
                            ta.PayFeeAccount = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            ta.RemitName = strList[13];
                        if (!string.IsNullOrEmpty(strList[14]))
                            ta.RemitAddress = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            ta.OrgCode = strList[15];
                        if (!string.IsNullOrEmpty(strList[16]))
                            ta.CorrespondentBankName = strList[16];
                        if (!string.IsNullOrEmpty(strList[17]))
                            ta.CorrespondentBankAddress = strList[17];
                        if (!string.IsNullOrEmpty(strList[18]))
                            ta.PayeeOpenBankName = strList[18];
                        if (!string.IsNullOrEmpty(strList[19]))
                            ta.PayeeOpenBankAddress = strList[19];
                        if (!string.IsNullOrEmpty(strList[20]))
                            ta.PayeeAccountInCorrespondentBank = strList[20];
                        if (!string.IsNullOrEmpty(strList[21]))
                            ta.PayeeName = strList[21];
                        if (!string.IsNullOrEmpty(strList[22]))
                            ta.PayeeAddress = strList[22];
                        if (!string.IsNullOrEmpty(strList[23]))
                            ta.PayeeAccount = strList[23];
                        if (!string.IsNullOrEmpty(strList[24]))
                            ta.RemitNote = strList[24];
                        if (!string.IsNullOrEmpty(strList[25]))
                            ta.AssumeFeeType = DataConvertHelper.Instance.GetAssumeFeeType(strList[25]);
                        if (!string.IsNullOrEmpty(strList[26]))
                            ta.PayeeCodeofCountry = strList[26];
                        if (!string.IsNullOrEmpty(strList[27]))
                            ta.PayeeNameofCountry = strList[27];
                        if (!string.IsNullOrEmpty(strList[28]))
                            ta.PayFeeType = DataConvertHelper.Instance.GetPayFeeType(strList[28]);
                        if (!string.IsNullOrEmpty(strList[29]))
                            ta.DealSerialNoF = strList[29];
                        if (!string.IsNullOrEmpty(strList[30]))
                            ta.AmountF = DataConvertHelper.Instance.FormatCash(strList[30], false);
                        if (!string.IsNullOrEmpty(strList[31]))
                            ta.DealNoteF = strList[31];
                        if (!string.IsNullOrEmpty(strList[32]))
                            ta.DealSerialNoS = strList[32];
                        if (!string.IsNullOrEmpty(strList[33]))
                            ta.AmountS = DataConvertHelper.Instance.FormatCash(strList[33], false);
                        if (!string.IsNullOrEmpty(strList[34]))
                            ta.DealNoteS = strList[34];
                        if (!string.IsNullOrEmpty(strList[35]))
                            ta.IsPayOffLine = DataConvertHelper.Instance.GetIsPayOffLine(strList[35]);
                        if (!string.IsNullOrEmpty(strList[36]))
                            ta.ContactNo = strList[36];
                        if (!string.IsNullOrEmpty(strList[37]))
                            ta.BillSerialNo = strList[37];
                        if (!string.IsNullOrEmpty(strList[38]))
                            ta.BatchNoOrTNoOrSerialNo = strList[38];
                        if (!string.IsNullOrEmpty(strList[39]))
                            ta.ProposerName = strList[39];
                        if (!string.IsNullOrEmpty(strList[40]))
                            ta.Telephone = strList[40];
                        if ((SystemSettings.Instance.CurrentVersion & VersionType.v405) == VersionType.v405)
                        {
                            if (!string.IsNullOrEmpty(strList[41]))
                                ta.CorrespondentBankSwiftCode = strList[41];
                            if (!string.IsNullOrEmpty(strList[42]))
                                ta.PayeeOpenBankSwiftCode = strList[42];
                        }
                    }
                    else if (templateType == AppliableFunctionType.TransferForeignMoney)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            ta.PayDate = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            ta.PaymentType = strList[2];
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[3]);
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PaymentCashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                        if (!string.IsNullOrEmpty(strList[5]))
                            ta.RemitAmount = DataConvertHelper.Instance.FormatCash(strList[5], false);
                        if (!string.IsNullOrEmpty(strList[6]))
                            ta.SpotAccount = strList[6];
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.SpotAmount = DataConvertHelper.Instance.FormatCash(strList[7], false);
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.PurchaseAccount = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            ta.PurchaseAmount = DataConvertHelper.Instance.FormatCash(strList[9], false);
                        if (!string.IsNullOrEmpty(strList[10]))
                            ta.OtherAccount = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.OtherAmount = DataConvertHelper.Instance.FormatCash(strList[11], false);
                        if (!string.IsNullOrEmpty(strList[12]))
                            ta.PayFeeAccount = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            ta.RemitName = strList[13];
                        if (!string.IsNullOrEmpty(strList[14]))
                            ta.RemitAddress = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            ta.OrgCode = strList[15];
                        if (!string.IsNullOrEmpty(strList[16]))
                            ta.CorrespondentBankName = strList[16];
                        if (!string.IsNullOrEmpty(strList[17]))
                            ta.CorrespondentBankAddress = strList[17];
                        if (!string.IsNullOrEmpty(strList[18]))
                            ta.PayeeOpenBankType = (AccountBankType)((int.Parse(strList[18]) + 1) % 2);
                        if (!string.IsNullOrEmpty(strList[19]))
                            ta.PayeeOpenBankName = strList[19];
                        if (!string.IsNullOrEmpty(strList[20]))
                            ta.PayeeOpenBankAddress = strList[20];
                        if (!string.IsNullOrEmpty(strList[21]))
                            ta.PayeeAccountInCorrespondentBank = strList[21];
                        if (!string.IsNullOrEmpty(strList[22]))
                            ta.PayeeName = strList[22];
                        if (!string.IsNullOrEmpty(strList[23]))
                            ta.PayeeAddress = strList[23];
                        if (!string.IsNullOrEmpty(strList[24]))
                            ta.PayeeAccount = strList[24];
                        if (!string.IsNullOrEmpty(strList[25]))
                            ta.RemitNote = strList[25];
                        if (!string.IsNullOrEmpty(strList[26]))
                            ta.AssumeFeeType = DataConvertHelper.Instance.GetAssumeFeeType(strList[26]);
                        if (!string.IsNullOrEmpty(strList[27]))
                            ta.PayeeCodeofCountry = strList[27];
                        if (!string.IsNullOrEmpty(strList[28]))
                            ta.PayeeNameofCountry = strList[28];
                        if (!string.IsNullOrEmpty(strList[29]))
                            ta.PayFeeType = DataConvertHelper.Instance.GetPayFeeType(strList[29]);
                        if (!string.IsNullOrEmpty(strList[30]))
                            ta.PaymentPropertyType = DataConvertHelper.Instance.GetPaymentPropertyType(strList[30]);
                        if (!string.IsNullOrEmpty(strList[31]))
                            ta.DealSerialNoF = strList[31];
                        if (!string.IsNullOrEmpty(strList[32]))
                            ta.AmountF = DataConvertHelper.Instance.FormatCash(strList[32], false);
                        if (!string.IsNullOrEmpty(strList[33]))
                            ta.DealSerialNoS = strList[33];
                        if (!string.IsNullOrEmpty(strList[34]))
                            ta.AmountS = DataConvertHelper.Instance.FormatCash(strList[34], false);
                        if (!string.IsNullOrEmpty(strList[35]))
                            ta.IsPayOffLine = DataConvertHelper.Instance.GetIsPayOffLine(strList[35]);
                        if (!string.IsNullOrEmpty(strList[36]))
                            ta.ContactNo = strList[36];
                        if (!string.IsNullOrEmpty(strList[37]))
                            ta.BillSerialNo = strList[37];
                        if (!string.IsNullOrEmpty(strList[38]))
                            ta.BatchNoOrTNoOrSerialNo = strList[38];
                        if (!string.IsNullOrEmpty(strList[39]))
                            ta.ProposerName = strList[39];
                        if (!string.IsNullOrEmpty(strList[40]))
                            ta.Telephone = strList[40];
                    }
                    #endregion
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally
                {
                    list.Add(ta);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ta = new TransferGlobal();
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.TransferOverCountry)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            ta.PayDate = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            ta.PaymentType = "电汇";
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[3]);
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PaymentCashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                        if (!string.IsNullOrEmpty(strList[5]))
                            ta.RemitAmount = DataConvertHelper.Instance.FormatCash(strList[5], false);
                        if (!string.IsNullOrEmpty(strList[6]))
                            ta.SpotAccount = strList[6];
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.SpotAmount = DataConvertHelper.Instance.FormatCash(strList[7], false);
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.PurchaseAccount = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            ta.PurchaseAmount = DataConvertHelper.Instance.FormatCash(strList[9], false);
                        if (!string.IsNullOrEmpty(strList[10]))
                            ta.OtherAccount = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.OtherAmount = DataConvertHelper.Instance.FormatCash(strList[11], false);
                        if (!string.IsNullOrEmpty(strList[12]))
                            ta.PayFeeAccount = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            ta.RemitName = strList[13];
                        if (!string.IsNullOrEmpty(strList[14]))
                            ta.RemitAddress = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            ta.OrgCode = strList[15];
                        if (!string.IsNullOrEmpty(strList[16]))
                            ta.CorrespondentBankName = strList[16];
                        if (!string.IsNullOrEmpty(strList[17]))
                            ta.CorrespondentBankAddress = strList[17];
                        if (!string.IsNullOrEmpty(strList[18]))
                            ta.PayeeOpenBankName = strList[18];
                        if (!string.IsNullOrEmpty(strList[19]))
                            ta.PayeeOpenBankAddress = strList[19];
                        if (!string.IsNullOrEmpty(strList[20]))
                            ta.PayeeAccountInCorrespondentBank = strList[20];
                        if (!string.IsNullOrEmpty(strList[21]))
                            ta.PayeeName = strList[21];
                        if (!string.IsNullOrEmpty(strList[22]))
                            ta.PayeeAddress = strList[22];
                        if (!string.IsNullOrEmpty(strList[23]))
                            ta.PayeeAccount = strList[23];
                        if (!string.IsNullOrEmpty(strList[24]))
                            ta.RemitNote = strList[24];
                        if (!string.IsNullOrEmpty(strList[25]))
                            ta.AssumeFeeType = DataConvertHelper.Instance.GetAssumeFeeType(strList[25]);
                        if (!string.IsNullOrEmpty(strList[26]))
                            ta.PayeeCodeofCountry = strList[26];
                        if (!string.IsNullOrEmpty(strList[27]))
                            ta.PayeeNameofCountry = strList[27];
                        if (!string.IsNullOrEmpty(strList[28]))
                            ta.PayFeeType = DataConvertHelper.Instance.GetPayFeeType(strList[28]);
                        if (!string.IsNullOrEmpty(strList[29]))
                            ta.DealSerialNoF = strList[29];
                        if (!string.IsNullOrEmpty(strList[30]))
                            ta.AmountF = DataConvertHelper.Instance.FormatCash(strList[30], false);
                        if (!string.IsNullOrEmpty(strList[31]))
                            ta.DealNoteF = strList[31];
                        if (!string.IsNullOrEmpty(strList[32]))
                            ta.DealSerialNoS = strList[32];
                        if (!string.IsNullOrEmpty(strList[33]))
                            ta.AmountS = DataConvertHelper.Instance.FormatCash(strList[33], false);
                        if (!string.IsNullOrEmpty(strList[34]))
                            ta.DealNoteS = strList[34];
                        if (!string.IsNullOrEmpty(strList[35]))
                            ta.IsPayOffLine = DataConvertHelper.Instance.GetIsPayOffLine(strList[35]);
                        if (!string.IsNullOrEmpty(strList[36]))
                            ta.ContactNo = strList[36];
                        if (!string.IsNullOrEmpty(strList[37]))
                            ta.BillSerialNo = strList[37];
                        if (!string.IsNullOrEmpty(strList[38]))
                            ta.BatchNoOrTNoOrSerialNo = strList[38];
                        if (!string.IsNullOrEmpty(strList[39]))
                            ta.ProposerName = strList[39];
                        if (!string.IsNullOrEmpty(strList[40]))
                            ta.Telephone = strList[40];
                        if ((SystemSettings.Instance.CurrentVersion & VersionType.v405) == VersionType.v405)
                        {
                            if (!string.IsNullOrEmpty(strList[41]))
                                ta.CorrespondentBankSwiftCode = strList[41];
                            if (!string.IsNullOrEmpty(strList[42]))
                                ta.PayeeOpenBankSwiftCode = strList[42];
                        }
                    }
                    else if (templateType == AppliableFunctionType.TransferForeignMoney)
                    {
                        if (!string.IsNullOrEmpty(strList[0]))
                            ta.CustomerRef = strList[0];
                        if (!string.IsNullOrEmpty(strList[1]))
                            ta.PayDate = strList[1];
                        if (!string.IsNullOrEmpty(strList[2]))
                            ta.PaymentType = strList[2];
                        if (!string.IsNullOrEmpty(strList[3]))
                            ta.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[3]);
                        if (!string.IsNullOrEmpty(strList[4]))
                            ta.PaymentCashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                        if (!string.IsNullOrEmpty(strList[5]))
                            ta.RemitAmount = DataConvertHelper.Instance.FormatCash(strList[5], false);
                        if (!string.IsNullOrEmpty(strList[6]))
                            ta.SpotAccount = strList[6];
                        if (!string.IsNullOrEmpty(strList[7]))
                            ta.SpotAmount = DataConvertHelper.Instance.FormatCash(strList[7], false);
                        if (!string.IsNullOrEmpty(strList[8]))
                            ta.PurchaseAccount = strList[8];
                        if (!string.IsNullOrEmpty(strList[9]))
                            ta.PurchaseAmount = DataConvertHelper.Instance.FormatCash(strList[9], false);
                        if (!string.IsNullOrEmpty(strList[10]))
                            ta.OtherAccount = strList[10];
                        if (!string.IsNullOrEmpty(strList[11]))
                            ta.OtherAmount = DataConvertHelper.Instance.FormatCash(strList[11], false);
                        if (!string.IsNullOrEmpty(strList[12]))
                            ta.PayFeeAccount = strList[12];
                        if (!string.IsNullOrEmpty(strList[13]))
                            ta.RemitName = strList[13];
                        if (!string.IsNullOrEmpty(strList[14]))
                            ta.RemitAddress = strList[14];
                        if (!string.IsNullOrEmpty(strList[15]))
                            ta.OrgCode = strList[15];
                        if (!string.IsNullOrEmpty(strList[16]))
                            ta.CorrespondentBankName = strList[16];
                        if (!string.IsNullOrEmpty(strList[17]))
                            ta.CorrespondentBankAddress = strList[17];
                        if (!string.IsNullOrEmpty(strList[18]))
                            ta.PayeeOpenBankType = (AccountBankType)((int.Parse(strList[18]) + 1) % 2);
                        if (!string.IsNullOrEmpty(strList[19]))
                            ta.PayeeOpenBankName = strList[19];
                        if (!string.IsNullOrEmpty(strList[20]))
                            ta.PayeeOpenBankAddress = strList[20];
                        if (!string.IsNullOrEmpty(strList[21]))
                            ta.PayeeAccountInCorrespondentBank = strList[21];
                        if (!string.IsNullOrEmpty(strList[22]))
                            ta.PayeeName = strList[22];
                        if (!string.IsNullOrEmpty(strList[23]))
                            ta.PayeeAddress = strList[23];
                        if (!string.IsNullOrEmpty(strList[24]))
                            ta.PayeeAccount = strList[24];
                        if (!string.IsNullOrEmpty(strList[25]))
                            ta.RemitNote = strList[25];
                        if (!string.IsNullOrEmpty(strList[26]))
                            ta.AssumeFeeType = DataConvertHelper.Instance.GetAssumeFeeType(strList[26]);
                        if (!string.IsNullOrEmpty(strList[27]))
                            ta.PayeeCodeofCountry = strList[27];
                        if (!string.IsNullOrEmpty(strList[28]))
                            ta.PayeeNameofCountry = strList[28];
                        if (!string.IsNullOrEmpty(strList[29]))
                            ta.PayFeeType = DataConvertHelper.Instance.GetPayFeeType(strList[29]);
                        if (!string.IsNullOrEmpty(strList[30]))
                            ta.PaymentPropertyType = DataConvertHelper.Instance.GetPaymentPropertyType(strList[30]);
                        if (!string.IsNullOrEmpty(strList[31]))
                            ta.DealSerialNoF = strList[31];
                        if (!string.IsNullOrEmpty(strList[32]))
                            ta.AmountF = DataConvertHelper.Instance.FormatCash(strList[32], false);
                        if (!string.IsNullOrEmpty(strList[33]))
                            ta.DealSerialNoS = strList[33];
                        if (!string.IsNullOrEmpty(strList[34]))
                            ta.AmountS = DataConvertHelper.Instance.FormatCash(strList[34], false);
                        if (!string.IsNullOrEmpty(strList[35]))
                            ta.IsPayOffLine = DataConvertHelper.Instance.GetIsPayOffLine(strList[35]);
                        if (!string.IsNullOrEmpty(strList[36]))
                            ta.ContactNo = strList[36];
                        if (!string.IsNullOrEmpty(strList[37]))
                            ta.BillSerialNo = strList[37];
                        if (!string.IsNullOrEmpty(strList[38]))
                            ta.BatchNoOrTNoOrSerialNo = strList[38];
                        if (!string.IsNullOrEmpty(strList[39]))
                            ta.ProposerName = strList[39];
                        if (!string.IsNullOrEmpty(strList[40]))
                            ta.Telephone = strList[40];
                    }
                    #endregion
                }
                catch { ta.ErrorReason = MultiLanguageConvertHelper.Instance.DesignMain_InvalidDta_ChangeFile_Fail; }
                finally { list.Add(ta); }
            }

            return list;
        }

        public List<TransferGlobal> GetTransferGlobalBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<TransferGlobal> list = new List<TransferGlobal>();

            TransferGlobal ta;
            if (templateType == AppliableFunctionType.TransferOverCountry
                || templateType == AppliableFunctionType.TransferForeignMoney)
            {
                //获取交易内容信息
                foreach (var data in contentData)
                {
                    ta = new TransferGlobal();

                    string[] strList = AnalyseBOCErrorCSVSytleData(data);
                    try
                    {
                        ta.RowIndex = int.Parse(strList[0]);
                        ta.ErrorReason = strList[strList.Length - 1];
                        list.Add(ta);
                    }
                    catch { }
                }
            }

            return list;
        }

        public List<SpplyFinancingApply> GetSpplyFinancingApply(List<List<string>> contentData, AppliableFunctionType templateType)
        {
            List<SpplyFinancingApply> list = new List<SpplyFinancingApply>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            SpplyFinancingApply sfa;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                sfa = new SpplyFinancingApply();

                try
                {
                    #region
                    if (!string.IsNullOrEmpty(data[0]))
                        sfa.ContractOrOrderNo = data[0];
                    if (!string.IsNullOrEmpty(data[1]))
                        sfa.OrderDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[1])).ToString("yyyy/MM/dd");
                    if (!string.IsNullOrEmpty(data[2]))
                        sfa.ContractOrOrderCashType = DataConvertHelper.Instance.GetCashType(data[2]);
                    if (!string.IsNullOrEmpty(data[3]))
                        sfa.ContractOrOrderAmount = DataConvertHelper.Instance.FormatNum(data[3]);
                    if (!string.IsNullOrEmpty(data[4]))
                        sfa.DeliveryDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[4])).ToString("yyyy/MM/dd");
                    if (!string.IsNullOrEmpty(data[5]))
                        sfa.SettlementType = DataConvertHelper.Instance.GetSettlementType(data[5]);
                    if (!string.IsNullOrEmpty(data[6]))
                        sfa.TaxInvoiceNo = data[6];
                    if (!string.IsNullOrEmpty(data[7]))
                        sfa.ReceiptNo = data[7];
                    if (!string.IsNullOrEmpty(data[8]))
                        sfa.RiskTakingLetterNo = data[8];
                    if (!string.IsNullOrEmpty(data[9]))
                        sfa.GoodsDesc = data[9];
                    if (!string.IsNullOrEmpty(data[10]))
                        sfa.ApplyAmount = DataConvertHelper.Instance.FormatNum(data[10]);
                    if (!string.IsNullOrEmpty(data[11]))
                        sfa.ApplyDays = int.Parse(DataConvertHelper.Instance.FormatNum(data[11]));
                    if (!string.IsNullOrEmpty(data[12]))
                        sfa.AgreementNo = data[12];
                    if (!string.IsNullOrEmpty(data[13]))
                        sfa.InterestFloatType = DataConvertHelper.Instance.GetInterestFloatType(data[13]);
                    if (!string.IsNullOrEmpty(data[14]))
                        sfa.InterestFloatingPercent = data[14];
                    #endregion
                }
                catch { }
                finally
                {
                    list.Add(sfa);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                sfa = new SpplyFinancingApply();
                List<string> data = contentData[maxcount];
                try
                {
                    #region
                    if (!string.IsNullOrEmpty(data[0]))
                        sfa.ContractOrOrderNo = data[0];
                    if (!string.IsNullOrEmpty(data[1]))
                        sfa.OrderDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[1])).ToString("yyyy/MM/dd");
                    if (!string.IsNullOrEmpty(data[2]))
                        sfa.ContractOrOrderCashType = DataConvertHelper.Instance.GetCashType(data[2]);
                    if (!string.IsNullOrEmpty(data[3]))
                        sfa.ContractOrOrderAmount = DataConvertHelper.Instance.FormatNum(data[3]);
                    if (!string.IsNullOrEmpty(data[4]))
                        sfa.DeliveryDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[4])).ToString("yyyy/MM/dd");
                    if (!string.IsNullOrEmpty(data[5]))
                        sfa.SettlementType = DataConvertHelper.Instance.GetSettlementType(data[5]);
                    if (!string.IsNullOrEmpty(data[6]))
                        sfa.TaxInvoiceNo = data[6];
                    if (!string.IsNullOrEmpty(data[7]))
                        sfa.ReceiptNo = data[7];
                    if (!string.IsNullOrEmpty(data[8]))
                        sfa.RiskTakingLetterNo = data[8];
                    if (!string.IsNullOrEmpty(data[9]))
                        sfa.GoodsDesc = data[9];
                    if (!string.IsNullOrEmpty(data[10]))
                        sfa.ApplyAmount = DataConvertHelper.Instance.FormatNum(data[10]);
                    if (!string.IsNullOrEmpty(data[11]))
                        sfa.ApplyDays = int.Parse(DataConvertHelper.Instance.FormatNum(data[11]));
                    if (!string.IsNullOrEmpty(data[12]))
                        sfa.AgreementNo = data[12];
                    if (!string.IsNullOrEmpty(data[13]))
                        sfa.InterestFloatType = DataConvertHelper.Instance.GetInterestFloatType(data[13]);
                    if (!string.IsNullOrEmpty(data[14]))
                        sfa.InterestFloatingPercent = data[14];
                    #endregion
                }
                catch { }
                finally { list.Add(sfa); }
            }

            return list;
        }

        public List<SpplyFinancingApply> GetSpplyFinancingApplyBOC(List<List<string>> contentData, AppliableFunctionType templateType)
        {
            List<SpplyFinancingApply> list = new List<SpplyFinancingApply>();

            int maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            SpplyFinancingApply sfa;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (count >= maxcount) break;

                sfa = new SpplyFinancingApply();

                try
                {
                    #region
                    sfa.ContractOrOrderNo = data[0];
                    if (!string.IsNullOrEmpty(data[1]))
                        sfa.OrderDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[1])).ToString("yyyy/MM/dd");
                    sfa.ContractOrOrderCashType = DataConvertHelper.Instance.GetCashType(data[2]);
                    sfa.ContractOrOrderAmount = DataConvertHelper.Instance.FormatNum(data[3]);
                    if (!string.IsNullOrEmpty(data[4]))
                        sfa.DeliveryDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[4])).ToString("yyyy/MM/dd");
                    sfa.SettlementType = DataConvertHelper.Instance.GetSettlementType(data[5]);
                    if (!string.IsNullOrEmpty(data[6]))
                        sfa.TaxInvoiceNo = data[6];
                    if (!string.IsNullOrEmpty(data[7]))
                        sfa.ReceiptNo = data[7];
                    sfa.RiskTakingLetterNo = data[8];
                    if (!string.IsNullOrEmpty(data[9]))
                        sfa.GoodsDesc = data[9];
                    sfa.ApplyAmount = DataConvertHelper.Instance.FormatNum(data[10]);
                    sfa.ApplyDays = int.Parse(DataConvertHelper.Instance.FormatNum(data[11]));
                    if (!string.IsNullOrEmpty(data[12]))
                        sfa.AgreementNo = data[12];
                    if (!string.IsNullOrEmpty(data[13]))
                        sfa.InterestFloatType = DataConvertHelper.Instance.GetInterestFloatType(data[13]);
                    if (!string.IsNullOrEmpty(data[14]))
                        sfa.InterestFloatingPercent = data[14];
                    #endregion
                }
                catch { }
                finally
                {
                    list.Add(sfa);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                sfa = new SpplyFinancingApply();
                List<string> data = contentData[maxcount];
                try
                {
                    #region
                    sfa.ContractOrOrderNo = data[0];
                    if (!string.IsNullOrEmpty(data[1]))
                        sfa.OrderDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[1])).ToString("yyyy/MM/dd");
                    sfa.ContractOrOrderCashType = DataConvertHelper.Instance.GetCashType(data[2]);
                    sfa.ContractOrOrderAmount = DataConvertHelper.Instance.FormatNum(data[3]);
                    if (!string.IsNullOrEmpty(data[4]))
                        sfa.DeliveryDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[4])).ToString("yyyy/MM/dd");
                    sfa.SettlementType = DataConvertHelper.Instance.GetSettlementType(data[5]);
                    if (!string.IsNullOrEmpty(data[6]))
                        sfa.TaxInvoiceNo = data[6];
                    if (!string.IsNullOrEmpty(data[7]))
                        sfa.ReceiptNo = data[7];
                    sfa.RiskTakingLetterNo = data[8];
                    if (!string.IsNullOrEmpty(data[9]))
                        sfa.GoodsDesc = data[9];
                    sfa.ApplyAmount = DataConvertHelper.Instance.FormatNum(data[10]);
                    sfa.ApplyDays = int.Parse(DataConvertHelper.Instance.FormatNum(data[11]));
                    if (!string.IsNullOrEmpty(data[12]))
                        sfa.AgreementNo = data[12];
                    if (!string.IsNullOrEmpty(data[13]))
                        sfa.InterestFloatType = DataConvertHelper.Instance.GetInterestFloatType(data[13]);
                    if (!string.IsNullOrEmpty(data[14]))
                        sfa.InterestFloatingPercent = data[14];
                    #endregion
                }
                catch { }
                finally { list.Add(sfa); }
            }

            return list;
        }

        public List<SpplyFinancingOrder> GetSpplyFinancingOrder(List<List<string>> contentData, AppliableFunctionType templateType)
        {
            List<SpplyFinancingOrder> list = new List<SpplyFinancingOrder>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            SpplyFinancingOrder sfo;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                sfo = new SpplyFinancingOrder();
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.PurchaserOrder)
                    {
                        if (!string.IsNullOrEmpty(data[0]))
                            sfo.OrderNo = data[0];
                        if (!string.IsNullOrEmpty(data[1]))
                            sfo.CashType = DataConvertHelper.Instance.GetCashType(data[1]);
                        if (!string.IsNullOrEmpty(data[2]))
                            sfo.Amount = DataConvertHelper.Instance.FormatNum(data[2]);
                        if (!string.IsNullOrEmpty(data[3]))
                            sfo.ERPCode = data[3];
                        if (!string.IsNullOrEmpty(data[4]))
                            sfo.CustomerApplyNo = data[4];
                        if (!string.IsNullOrEmpty(data[5]))
                            sfo.PayDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[5])).ToString("yyyy/MM/dd");
                    }
                    else if (templateType == AppliableFunctionType.SellerOrder)
                    {
                        if (!string.IsNullOrEmpty(data[0]))
                            sfo.OrderNo = data[0];
                        if (!string.IsNullOrEmpty(data[1]))
                            sfo.CashType = DataConvertHelper.Instance.GetCashType(data[1]);
                        if (!string.IsNullOrEmpty(data[2]))
                            sfo.Amount = DataConvertHelper.Instance.FormatNum(data[2]);
                        if (!string.IsNullOrEmpty(data[3]))
                            sfo.CustomerName = data[3];
                        if (!string.IsNullOrEmpty(data[4]))
                            sfo.PayDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[4])).ToString("yyyy/MM/dd");
                    }
                    else if (templateType == AppliableFunctionType.PurchaserOrderMgr
                        || templateType == AppliableFunctionType.SellerOrderMgr)
                    {
                        if (!string.IsNullOrEmpty(data[0]))
                            sfo.OrderNo = data[0];
                        if (!string.IsNullOrEmpty(data[1]))
                            sfo.Amount = DataConvertHelper.Instance.FormatNum(data[1]);
                    }
                    #endregion
                }
                catch { }
                finally
                {
                    list.Add(sfo);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                sfo = new SpplyFinancingOrder();
                List<string> data = contentData[maxcount];
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.PurchaserOrder)
                    {
                        if (!string.IsNullOrEmpty(data[0]))
                            sfo.OrderNo = data[0];
                        if (!string.IsNullOrEmpty(data[1]))
                            sfo.CashType = DataConvertHelper.Instance.GetCashType(data[1]);
                        if (!string.IsNullOrEmpty(data[2]))
                            sfo.Amount = DataConvertHelper.Instance.FormatNum(data[2]);
                        if (!string.IsNullOrEmpty(data[3]))
                            sfo.ERPCode = data[3];
                        if (!string.IsNullOrEmpty(data[4]))
                            sfo.CustomerApplyNo = data[4];
                        if (!string.IsNullOrEmpty(data[5]))
                            sfo.PayDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[5])).ToString("yyyy/MM/dd");
                    }
                    else if (templateType == AppliableFunctionType.SellerOrder)
                    {
                        if (!string.IsNullOrEmpty(data[0]))
                            sfo.OrderNo = data[0];
                        if (!string.IsNullOrEmpty(data[1]))
                            sfo.CashType = DataConvertHelper.Instance.GetCashType(data[1]);
                        if (!string.IsNullOrEmpty(data[2]))
                            sfo.Amount = DataConvertHelper.Instance.FormatNum(data[2]);
                        if (!string.IsNullOrEmpty(data[3]))
                            sfo.CustomerName = data[3];
                        if (!string.IsNullOrEmpty(data[4]))
                            sfo.PayDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[4])).ToString("yyyy/MM/dd");
                    }
                    else if (templateType == AppliableFunctionType.PurchaserOrderMgr
                        || templateType == AppliableFunctionType.SellerOrderMgr)
                    {
                        if (!string.IsNullOrEmpty(data[0]))
                            sfo.OrderNo = data[0];
                        if (!string.IsNullOrEmpty(data[1]))
                            sfo.Amount = DataConvertHelper.Instance.FormatNum(data[1]);
                    }
                    #endregion
                }
                catch { }
                finally { list.Add(sfo); }
            }

            return list;
        }

        public List<SpplyFinancingOrder> GetSpplyFinancingOrderBOC(List<List<string>> contentData, AppliableFunctionType templateType)
        {
            List<SpplyFinancingOrder> list = new List<SpplyFinancingOrder>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            SpplyFinancingOrder sfo;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                sfo = new SpplyFinancingOrder();
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.PurchaserOrder)
                    {
                        sfo.OrderNo = data[0];
                        sfo.CashType = DataConvertHelper.Instance.GetCashType(data[1]);
                        sfo.Amount = DataConvertHelper.Instance.FormatNum(data[2]);
                        if (!string.IsNullOrEmpty(data[3]))
                            sfo.ERPCode = data[3];
                        if (!string.IsNullOrEmpty(data[4]))
                            sfo.CustomerApplyNo = data[4];
                        sfo.PayDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[5])).ToString("yyyy/MM/dd");
                    }
                    else if (templateType == AppliableFunctionType.SellerOrder)
                    {
                        sfo.OrderNo = data[0];
                        sfo.CashType = DataConvertHelper.Instance.GetCashType(data[1]);
                        sfo.Amount = DataConvertHelper.Instance.FormatNum(data[2]);
                        sfo.CustomerName = data[3];
                        sfo.PayDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[4])).ToString("yyyy/MM/dd");
                    }
                    else if (templateType == AppliableFunctionType.PurchaserOrderMgr
                        || templateType == AppliableFunctionType.SellerOrderMgr)
                    {
                        sfo.OrderNo = data[0];
                        sfo.Amount = DataConvertHelper.Instance.FormatNum(data[1]);
                    }
                    #endregion
                }
                catch { }
                finally
                {
                    list.Add(sfo);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                sfo = new SpplyFinancingOrder();
                List<string> data = contentData[maxcount];
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.PurchaserOrder)
                    {
                        sfo.OrderNo = data[0];
                        sfo.CashType = DataConvertHelper.Instance.GetCashType(data[1]);
                        sfo.Amount = DataConvertHelper.Instance.FormatNum(data[2]);
                        if (!string.IsNullOrEmpty(data[3]))
                            sfo.ERPCode = data[3];
                        if (!string.IsNullOrEmpty(data[4]))
                            sfo.CustomerApplyNo = data[4];
                        sfo.PayDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[5])).ToString("yyyy/MM/dd");
                    }
                    else if (templateType == AppliableFunctionType.SellerOrder)
                    {
                        sfo.OrderNo = data[0];
                        sfo.CashType = DataConvertHelper.Instance.GetCashType(data[1]);
                        sfo.Amount = DataConvertHelper.Instance.FormatNum(data[2]);
                        sfo.CustomerName = data[3];
                        sfo.PayDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[4])).ToString("yyyy/MM/dd");
                    }
                    else if (templateType == AppliableFunctionType.PurchaserOrderMgr
                        || templateType == AppliableFunctionType.SellerOrderMgr)
                    {
                        sfo.OrderNo = data[0];
                        sfo.Amount = DataConvertHelper.Instance.FormatNum(data[1]);
                    }
                    #endregion
                }
                catch { }
                finally { list.Add(sfo); }
            }

            return list;
        }

        public List<SpplyFinancingBill> GetSpplyFinancingBill(List<List<string>> contentData, AppliableFunctionType templateType)
        {
            List<SpplyFinancingBill> list = new List<SpplyFinancingBill>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            SpplyFinancingBill sfb;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                sfb = new SpplyFinancingBill();
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.BillofDebtReceivablePurchaser
                        || templateType == AppliableFunctionType.BillofDebtReceivableSeller)
                    {
                        if (!string.IsNullOrEmpty(data[0]))
                            sfb.BillSerialNo = data[0];
                        if (!string.IsNullOrEmpty(data[1]))
                            sfb.ContractNo = data[1];
                        if (!string.IsNullOrEmpty(data[2]))
                            sfb.CustomerNo = data[2];
                        if (!string.IsNullOrEmpty(data[3]))
                            sfb.CustomerName = data[3];
                        if (!string.IsNullOrEmpty(data[4]))
                            sfb.CashType = DataConvertHelper.Instance.GetCashType(data[4]);
                        if (!string.IsNullOrEmpty(data[5]))
                            sfb.Amount = DataConvertHelper.Instance.FormatNum(data[5]);
                        if (!string.IsNullOrEmpty(data[6]))
                            sfb.BillDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[6])).ToString("yyyy/MM/dd");
                        if (!string.IsNullOrEmpty(data[7]))
                            sfb.StartDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[7])).ToString("yyyy/MM/dd");
                        if (!string.IsNullOrEmpty(data[8]))
                            sfb.EndDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[8])).ToString("yyyy/MM/dd");
                    }
                    #endregion
                }
                catch { }
                finally
                {
                    list.Add(sfb);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                sfb = new SpplyFinancingBill();
                List<string> data = contentData[maxcount];
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.BillofDebtReceivablePurchaser
                        || templateType == AppliableFunctionType.BillofDebtReceivableSeller)
                    {
                        if (!string.IsNullOrEmpty(data[0]))
                            sfb.BillSerialNo = data[0];
                        if (!string.IsNullOrEmpty(data[1]))
                            sfb.ContractNo = data[1];
                        if (!string.IsNullOrEmpty(data[2]))
                            sfb.CustomerNo = data[2];
                        if (!string.IsNullOrEmpty(data[3]))
                            sfb.CustomerName = data[3];
                        if (!string.IsNullOrEmpty(data[4]))
                            sfb.CashType = DataConvertHelper.Instance.GetCashType(data[4]);
                        if (!string.IsNullOrEmpty(data[5]))
                            sfb.Amount = DataConvertHelper.Instance.FormatNum(data[5]);
                        if (!string.IsNullOrEmpty(data[6]))
                            sfb.BillDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[6])).ToString("yyyy/MM/dd");
                        if (!string.IsNullOrEmpty(data[7]))
                            sfb.StartDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[7])).ToString("yyyy/MM/dd");
                        if (!string.IsNullOrEmpty(data[8]))
                            sfb.EndDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[8])).ToString("yyyy/MM/dd");
                    }
                    #endregion
                }
                catch { }
                finally { list.Add(sfb); }
            }

            return list;
        }

        public List<SpplyFinancingBill> GetSpplyFinancingBillBOC(List<List<string>> contentData, AppliableFunctionType templateType)
        {
            List<SpplyFinancingBill> list = new List<SpplyFinancingBill>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            SpplyFinancingBill sfb;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                sfb = new SpplyFinancingBill();
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.BillofDebtReceivablePurchaser
                        || templateType == AppliableFunctionType.BillofDebtReceivableSeller)
                    {
                        if (!string.IsNullOrEmpty(data[0]))
                            sfb.BillSerialNo = data[0];
                        if (!string.IsNullOrEmpty(data[1]))
                            sfb.ContractNo = data[1];
                        sfb.CustomerNo = data[2];
                        sfb.CustomerName = data[3];
                        sfb.CashType = DataConvertHelper.Instance.GetCashType(data[4]);
                        sfb.Amount = DataConvertHelper.Instance.FormatNum(data[5]);
                        sfb.BillDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[6])).ToString("yyyy/MM/dd");
                        sfb.StartDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[7])).ToString("yyyy/MM/dd");
                        sfb.EndDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[8])).ToString("yyyy/MM/dd");
                    }
                    #endregion
                }
                catch { }
                finally
                {
                    list.Add(sfb);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                sfb = new SpplyFinancingBill();
                List<string> data = contentData[maxcount];
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.BillofDebtReceivablePurchaser
                        || templateType == AppliableFunctionType.BillofDebtReceivableSeller)
                    {
                        if (!string.IsNullOrEmpty(data[0]))
                            sfb.BillSerialNo = data[0];
                        if (!string.IsNullOrEmpty(data[1]))
                            sfb.ContractNo = data[1];
                        sfb.CustomerNo = data[2];
                        sfb.CustomerName = data[3];
                        sfb.CashType = DataConvertHelper.Instance.GetCashType(data[4]);
                        sfb.Amount = DataConvertHelper.Instance.FormatNum(data[5]);
                        sfb.BillDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[6])).ToString("yyyy/MM/dd");
                        sfb.StartDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[7])).ToString("yyyy/MM/dd");
                        sfb.EndDate = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(data[8])).ToString("yyyy/MM/dd");
                    }
                    #endregion
                }
                catch { }
                finally { list.Add(sfb); }
            }

            return list;
        }

        public List<SpplyFinancingPayOrReceipt> GetSpplyFinancingPayOrReceipt(List<List<string>> contentData, AppliableFunctionType templateType)
        {
            List<SpplyFinancingPayOrReceipt> list = new List<SpplyFinancingPayOrReceipt>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            SpplyFinancingPayOrReceipt sfpor;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                sfpor = new SpplyFinancingPayOrReceipt();
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser)
                    {
                        if (!string.IsNullOrEmpty(data[0]))
                            sfpor.BillSerialNo = data[0];
                        if (!string.IsNullOrEmpty(data[1]))
                            sfpor.CustomerNo = data[1];
                        if (!string.IsNullOrEmpty(data[2]))
                            sfpor.CustomerName = data[2];
                        if (!string.IsNullOrEmpty(data[3]))
                            sfpor.CashType = DataConvertHelper.Instance.GetCashType(data[3]);
                        if (!string.IsNullOrEmpty(data[4]))
                            sfpor.PayAmountForThisTime = DataConvertHelper.Instance.FormatNum(data[4]);
                    }
                    #endregion
                }
                catch { }
                finally
                {
                    list.Add(sfpor);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                sfpor = new SpplyFinancingPayOrReceipt();
                List<string> data = contentData[maxcount];
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser)
                    {
                        if (!string.IsNullOrEmpty(data[0]))
                            sfpor.BillSerialNo = data[0];
                        if (!string.IsNullOrEmpty(data[1]))
                            sfpor.CustomerNo = data[1];
                        if (!string.IsNullOrEmpty(data[2]))
                            sfpor.CustomerName = data[2];
                        if (!string.IsNullOrEmpty(data[3]))
                            sfpor.CashType = DataConvertHelper.Instance.GetCashType(data[3]);
                        if (!string.IsNullOrEmpty(data[4]))
                            sfpor.PayAmountForThisTime = DataConvertHelper.Instance.FormatNum(data[4]);
                    }
                    #endregion
                }
                catch { }
                finally { list.Add(sfpor); }
            }

            return list;
        }

        public List<SpplyFinancingPayOrReceipt> GetSpplyFinancingPayOrReceiptBOC(List<List<string>> contentData, AppliableFunctionType templateType)
        {
            List<SpplyFinancingPayOrReceipt> list = new List<SpplyFinancingPayOrReceipt>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            SpplyFinancingPayOrReceipt sfpor;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                sfpor = new SpplyFinancingPayOrReceipt();
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser)
                    {
                        sfpor.BillSerialNo = data[0];
                        sfpor.CustomerNo = data[1];
                        sfpor.CustomerName = data[2];
                        sfpor.CashType = DataConvertHelper.Instance.GetCashType(data[3]);
                        sfpor.PayAmountForThisTime = DataConvertHelper.Instance.FormatNum(data[4]);
                    }
                    #endregion
                }
                catch { }
                finally
                {
                    list.Add(sfpor);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                sfpor = new SpplyFinancingPayOrReceipt();
                List<string> data = contentData[maxcount];
                try
                {
                    #region
                    if (templateType == AppliableFunctionType.PaymentOrReceiptofDebtReceivablePurchaser)
                    {
                        sfpor.BillSerialNo = data[0];
                        sfpor.CustomerNo = data[1];
                        sfpor.CustomerName = data[2];
                        sfpor.CashType = DataConvertHelper.Instance.GetCashType(data[3]);
                        sfpor.PayAmountForThisTime = DataConvertHelper.Instance.FormatNum(data[4]);
                    }
                    #endregion
                }
                catch { }
                finally { list.Add(sfpor); }
            }

            return list;
        }

        public List<object> GetInitiativeAllot(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            BatchHeader batch = new BatchHeader();
            List<InitiativeAllot> list = new List<InitiativeAllot>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            string[] s = new string[] { SystemSettings.Instance.BatchMappingSettings[templateType].SeperateChar };
            int count = 0;
            InitiativeAllot ae;

            foreach (var data in contentData)
            {
                if (count > maxcount) break;

                ae = null;
                string[] strList = data.Split(s, StringSplitOptions.None);

                #region 批信息
                if (count == 0)
                {
                    batch.ProtecolNo = strList[0];
                    batch.TransferDatetime = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(strList[3]));
                    count++;
                    continue;
                }
                #endregion

                #region 笔信息
                ae = new InitiativeAllot();
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ae.AccountOut = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        ae.NameOut = strList[1];
                    if (!string.IsNullOrEmpty(strList[2]))
                        ae.AccountIn = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ae.NameIn = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ae.CashType = CashType.CNY;
                    ae.Amount = DataConvertHelper.Instance.FormatNum(strList[5]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ae.Addition = strList[6];
                }
                catch { ae.ErrorReason = "数据格式错误，转换失败"; }
                finally { if (null != ae) list.Add(ae); count++; }
                #endregion
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ae = null;
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);

                #region 笔信息
                ae = new InitiativeAllot();
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ae.AccountOut = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        ae.NameOut = strList[1];
                    if (!string.IsNullOrEmpty(strList[2]))
                        ae.AccountIn = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ae.NameIn = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ae.CashType = CashType.CNY;
                    ae.Amount = DataConvertHelper.Instance.FormatNum(strList[5]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ae.Addition = strList[6];
                }
                catch { ae.ErrorReason = "数据格式错误，转换失败"; }
                finally { if (null != ae) list.Add(ae); count++; }
                #endregion
            }

            result.Add(batch);
            result.Add(list);
            return result;
        }

        public List<object> GetInitiativeAllotBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            BatchHeader batch = new BatchHeader();
            List<InitiativeAllot> list = new List<InitiativeAllot>();

            int maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            InitiativeAllot ae;

            foreach (var data in contentData)
            {
                if (count > maxcount) break;

                ae = null;
                string[] strList = data.Split(s, StringSplitOptions.None);

                #region 批信息
                if (count == 0)
                {
                    batch.ProtecolNo = strList[0];
                    batch.TransferDatetime = DateTime.Parse(DataConvertHelper.Instance.FormatDateTimeFromInt(strList[3]));
                    count++;
                    continue;
                }
                #endregion

                #region 笔信息
                ae = new InitiativeAllot();
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ae.AccountOut = strList[0];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款行行号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ae.NameOut = strList[1];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "金额为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ae.AccountIn = strList[2];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[3]))
                        ae.NameIn = strList[3];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款人姓名为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ae.CashType = CashType.CNY;
                    ae.Amount = DataConvertHelper.Instance.FormatNum(strList[5]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ae.Addition = strList[6];
                }
                catch { ae.ErrorReason = "数据格式错误，转换失败"; }
                finally { if (null != ae) list.Add(ae); count++; }
                #endregion
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ae = null;
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);

                #region 笔信息
                ae = new InitiativeAllot();
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ae.AccountOut = strList[0];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款行行号为空";
                    if (!string.IsNullOrEmpty(strList[1]))
                        ae.NameOut = strList[1];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "金额为空";
                    if (!string.IsNullOrEmpty(strList[2]))
                        ae.AccountIn = strList[2];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款人账号为空";
                    if (!string.IsNullOrEmpty(strList[3]))
                        ae.NameIn = strList[3];
                    else if (string.IsNullOrEmpty(ae.ErrorReason))
                        ae.ErrorReason = "收款人姓名为空";
                    if (!string.IsNullOrEmpty(strList[4]))
                        ae.CashType = CashType.CNY;
                    ae.Amount = DataConvertHelper.Instance.FormatNum(strList[5]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ae.Addition = strList[6];
                }
                catch { ae.ErrorReason = "数据格式错误，转换失败"; }
                finally { if (null != ae) list.Add(ae); count++; }
                #endregion
            }

            result.Add(batch);
            result.Add(list);
            return result;
        }

        public List<object> GetInitiativeAllotBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            BatchHeader batch = new BatchHeader();
            List<InitiativeAllot> list = new List<InitiativeAllot>();

            InitiativeAllot ae;

            foreach (var data in contentData)
            {
                string[] strList = AnalyseBOCErrorCSVSytleData(data);

                #region 笔信息
                ae = new InitiativeAllot();
                try
                {
                    ae.RowIndex = int.Parse(strList[0]);
                    ae.ErrorReason = strList[strList.Length - 1];
                    list.Add(ae);
                }
                catch { }
                #endregion
            }
            result.Add(batch);
            result.Add(list);
            return result;
        }

        public List<UnitivePaymentRMB> GetUnitivePaymentRMB(List<string> contentData, AppliableFunctionType templateType)
        {
            List<UnitivePaymentRMB> list = new List<UnitivePaymentRMB>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            UnitivePaymentRMB up;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                up = new UnitivePaymentRMB();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    #region
                    if (!string.IsNullOrEmpty(strList[0]))
                        up.PayerAccount = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        up.PayerName = strList[1];
                    if (!string.IsNullOrEmpty(strList[2]))
                        up.PayeeAccount = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        up.PayeeName = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        up.BankType = DataConvertHelper.Instance.GetAccountBankTypeObject(int.Parse(strList[4]));
                    if (!string.IsNullOrEmpty(strList[5]))
                        up.PayeeCNAPS = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        up.PayeeOpenBankName = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        up.NominalPayerAccount = strList[7];
                    if (!string.IsNullOrEmpty(strList[8]))
                        up.NominalPayerName = strList[8];
                    if (!string.IsNullOrEmpty(strList[9]))
                        //    up.NominalPayerBankLinkNo = strList[9];
                        //if (!string.IsNullOrEmpty(strList[10]))
                        //    up.NominalPayerOpenBankName = strList[10];
                        //if (!string.IsNullOrEmpty(strList[11]))
                        up.Amount = DataConvertHelper.Instance.FormatCash(strList[9], false).Replace(",", "");
                    if (!string.IsNullOrEmpty(strList[10]))
                        up.Purpose = strList[10];
                    if (!string.IsNullOrEmpty(strList[11]))
                        up.UnitivePaymentType = DataConvertHelper.Instance.GetUnitivePaymentType(strList[11]);
                    if (!string.IsNullOrEmpty(strList[12]))
                    {
                        string[] temp = strList[12].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(temp[0]);
                        up.OrderPayTime = temp.Length < 2 ? "00:00" : DataConvertHelper.Instance.FormatTime(temp[1]);
                    }
                    if (!string.IsNullOrEmpty(strList[13]))
                        up.CustomerBusinissNo = strList[13];
                    if (!string.IsNullOrEmpty(strList[14]))
                        up.TransferChanelType = DataConvertHelper.Instance.GetTransferChanelType(strList[14]);
                    if (!string.IsNullOrEmpty(strList[15]))
                        up.IsTipPayee = DataConvertHelper.Instance.GetIsTipPayee(strList[15]);
                    if (!string.IsNullOrEmpty(strList[16]))
                        up.TipPayeePhone = strList[16];
                    #endregion
                }
                catch { }
                finally
                {
                    list.Add(up);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                up = new UnitivePaymentRMB();
                string data = contentData[maxcount];
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    #region
                    if (!string.IsNullOrEmpty(strList[0]))
                        up.PayerAccount = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        up.PayerName = strList[1];
                    if (!string.IsNullOrEmpty(strList[2]))
                        up.PayeeAccount = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        up.PayeeName = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        up.BankType = DataConvertHelper.Instance.GetAccountBankTypeObject(int.Parse(strList[4]));
                    if (!string.IsNullOrEmpty(strList[5]))
                        up.PayeeCNAPS = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        up.PayeeOpenBankName = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        up.NominalPayerAccount = strList[7];
                    if (!string.IsNullOrEmpty(strList[8]))
                        up.NominalPayerName = strList[8];
                    if (!string.IsNullOrEmpty(strList[9]))
                        //    up.NominalPayerBankLinkNo = strList[9];
                        //if (!string.IsNullOrEmpty(strList[10]))
                        //    up.NominalPayerOpenBankName = strList[10];
                        //if (!string.IsNullOrEmpty(strList[11]))
                        up.Amount = DataConvertHelper.Instance.FormatCash(strList[9], false).Replace(",", "");
                    if (!string.IsNullOrEmpty(strList[10]))
                        up.Purpose = strList[10];
                    if (!string.IsNullOrEmpty(strList[11]))
                        up.UnitivePaymentType = DataConvertHelper.Instance.GetUnitivePaymentType(strList[11]);
                    if (!string.IsNullOrEmpty(strList[12]))
                    {
                        string[] temp = strList[12].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(temp[0]);
                        up.OrderPayTime = temp.Length < 2 ? "00:00" : DataConvertHelper.Instance.FormatTime(temp[1]);
                    }
                    if (!string.IsNullOrEmpty(strList[13]))
                        up.CustomerBusinissNo = strList[13];
                    if (!string.IsNullOrEmpty(strList[14]))
                        up.TransferChanelType = DataConvertHelper.Instance.GetTransferChanelType(strList[14]);
                    if (!string.IsNullOrEmpty(strList[15]))
                        up.IsTipPayee = DataConvertHelper.Instance.GetIsTipPayee(strList[15]);
                    if (!string.IsNullOrEmpty(strList[16]))
                        up.TipPayeePhone = strList[16];
                    #endregion
                }
                catch { }
                finally { list.Add(up); }
            }

            return list;
        }

        public List<UnitivePaymentRMB> GetUnitivePaymentRMBBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<UnitivePaymentRMB> list = new List<UnitivePaymentRMB>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            UnitivePaymentRMB up;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                up = new UnitivePaymentRMB();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    #region
                    if (!string.IsNullOrEmpty(strList[0]))
                        up.PayerAccount = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        up.PayerName = strList[1];
                    if (!string.IsNullOrEmpty(strList[2]))
                        up.PayeeAccount = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        up.PayeeName = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        up.BankType = (AccountBankType)((int.Parse(strList[4]) + 1) % 2);
                    if (!string.IsNullOrEmpty(strList[5]))
                        up.PayeeCNAPS = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        up.PayeeOpenBankName = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        up.NominalPayerAccount = strList[7];
                    if (!string.IsNullOrEmpty(strList[8]))
                        up.NominalPayerName = strList[8];
                    if (!string.IsNullOrEmpty(strList[9]))
                        //    up.NominalPayerBankLinkNo = strList[9];
                        //if (!string.IsNullOrEmpty(strList[10]))
                        //    up.NominalPayerOpenBankName = strList[10];
                        //if (!string.IsNullOrEmpty(strList[11]))
                        up.Amount = DataConvertHelper.Instance.FormatCash(strList[9], false).Replace(",", "");
                    if (!string.IsNullOrEmpty(strList[10]))
                        up.Purpose = strList[10];
                    if (!string.IsNullOrEmpty(strList[11]))
                        up.UnitivePaymentType = DataConvertHelper.Instance.GetUnitivePaymentType(strList[11]);
                    if (strList[12] != null && !string.IsNullOrEmpty(strList[12].Trim()))
                    {
                        string[] temp = strList[12].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(temp[0]);
                        up.OrderPayTime = temp.Length < 2 ? "00:00" : DataConvertHelper.Instance.FormatTime(temp[1]);
                    }
                    if (!string.IsNullOrEmpty(strList[13]))
                        up.CustomerBusinissNo = strList[13];
                    if (!string.IsNullOrEmpty(strList[14]))
                        up.TransferChanelType = DataConvertHelper.Instance.GetTransferChanelType(strList[14]);
                    if (!string.IsNullOrEmpty(strList[15]))
                        up.IsTipPayee = DataConvertHelper.Instance.GetIsTipPayee(strList[15]);
                    if (!string.IsNullOrEmpty(strList[16]))
                        up.TipPayeePhone = strList[16];
                    #endregion
                }
                catch { }
                finally
                {
                    list.Add(up);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                up = new UnitivePaymentRMB();
                string data = contentData[maxcount];
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    #region
                    if (!string.IsNullOrEmpty(strList[0]))
                        up.PayerAccount = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        up.PayerName = strList[1];
                    if (!string.IsNullOrEmpty(strList[2]))
                        up.PayeeAccount = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        up.PayeeName = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        up.BankType = DataConvertHelper.Instance.GetAccountBankTypeObject(int.Parse(strList[4]));
                    if (!string.IsNullOrEmpty(strList[5]))
                        up.PayeeCNAPS = strList[5];
                    if (!string.IsNullOrEmpty(strList[6]))
                        up.PayeeOpenBankName = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        up.NominalPayerAccount = strList[7];
                    if (!string.IsNullOrEmpty(strList[8]))
                        up.NominalPayerName = strList[8];
                    if (!string.IsNullOrEmpty(strList[9]))
                        //    up.NominalPayerBankLinkNo = strList[9];
                        //if (!string.IsNullOrEmpty(strList[10]))
                        //    up.NominalPayerOpenBankName = strList[10];
                        //if (!string.IsNullOrEmpty(strList[11]))
                        up.Amount = DataConvertHelper.Instance.FormatCash(strList[9], false).Replace(",", "");
                    if (!string.IsNullOrEmpty(strList[10]))
                        up.Purpose = strList[10];
                    if (!string.IsNullOrEmpty(strList[11]))
                        up.UnitivePaymentType = DataConvertHelper.Instance.GetUnitivePaymentType(strList[11]);
                    if (!string.IsNullOrEmpty(strList[12]))
                    {
                        string[] temp = strList[12].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(temp[0]);
                        up.OrderPayTime = temp.Length < 2 ? "00:00" : DataConvertHelper.Instance.FormatTime(temp[1]);
                    }
                    if (!string.IsNullOrEmpty(strList[13]))
                        up.CustomerBusinissNo = strList[13];
                    if (!string.IsNullOrEmpty(strList[14]))
                        up.TransferChanelType = DataConvertHelper.Instance.GetTransferChanelType(strList[14]);
                    if (!string.IsNullOrEmpty(strList[15]))
                        up.IsTipPayee = DataConvertHelper.Instance.GetIsTipPayee(strList[15]);
                    if (!string.IsNullOrEmpty(strList[16]))
                        up.TipPayeePhone = strList[16];
                    #endregion
                }
                catch { }
                finally { list.Add(up); }
            }

            return list;
        }

        public List<UnitivePaymentRMB> GetUnitivePaymentRMBBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<UnitivePaymentRMB> list = new List<UnitivePaymentRMB>();

            UnitivePaymentRMB ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                ta = new UnitivePaymentRMB();

                string[] strList = AnalyseBOCErrorCSVSytleData(data);
                try
                {
                    ta.RowIndex = int.Parse(strList[0]);
                    ta.ErrorReason = strList[strList.Length - 1];
                    list.Add(ta);
                }
                catch { }
            }

            return list;
        }

        public List<UnitivePaymentForeignMoney> GetUnitivePaymentFC(List<string> contentData, AppliableFunctionType templateType, OverCountryPayeeAccountType type)
        {
            List<UnitivePaymentForeignMoney> list = new List<UnitivePaymentForeignMoney>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            UnitivePaymentForeignMoney up;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                up = new UnitivePaymentForeignMoney();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    switch (type)
                    {
                        case OverCountryPayeeAccountType.BocAccount:
                            #region
                            if (!string.IsNullOrEmpty(strList[0]))
                                up.PayerAccount = strList[0];
                            if (!string.IsNullOrEmpty(strList[1]))
                                up.PayerName = strList[1];
                            if (!string.IsNullOrEmpty(strList[2]))
                                up.NominalPayerName = strList[2];
                            if (!string.IsNullOrEmpty(strList[3]))
                                up.NominalPayerAccount = strList[3];
                            if (!string.IsNullOrEmpty(strList[4]))
                                up.CashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                            if (!string.IsNullOrEmpty(strList[5]))
                                up.PayeeAccount = strList[5];
                            if (!string.IsNullOrEmpty(strList[6]))
                                up.PayeeName = strList[6];
                            if (!string.IsNullOrEmpty(strList[7]))
                                up.PayeeOpenBankName = strList[7];
                            if (!string.IsNullOrEmpty(strList[8]))
                                up.Amount = DataConvertHelper.Instance.FormatCash(strList[8], false).Replace(",", "");
                            if (!string.IsNullOrEmpty(strList[9]))
                                up.CustomerBusinissNo = strList[9];
                            if (!string.IsNullOrEmpty(strList[10]))
                                up.Purpose = strList[10];
                            if (!string.IsNullOrEmpty(strList[11]))
                                up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[11]);
                            if (!string.IsNullOrEmpty(strList[12]))
                                up.Addtion = strList[12];
                            if (!string.IsNullOrEmpty(strList[13]))
                                up.CodeofCountry = strList[13];
                            if (!string.IsNullOrEmpty(strList[14]))
                                up.IsImportCancelAfterVerificationType = DataConvertHelper.Instance.GetIsImportCancelAfterVerificationType(strList[14]);
                            if (!string.IsNullOrEmpty(strList[15]))
                                up.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(strList[15]);
                            if (!string.IsNullOrEmpty(strList[16]))
                                up.PaymentNature = DataConvertHelper.Instance.GetPaymentPropertyType(strList[16]);
                            if (!string.IsNullOrEmpty(strList[17]))
                                up.TransactionCode1 = strList[17];
                            if (!string.IsNullOrEmpty(strList[18]))
                                up.TransactionCode2 = strList[18];
                            if (!string.IsNullOrEmpty(strList[19]))
                                up.IPPSMoneyTypeAmount1 = strList[19];
                            if (!string.IsNullOrEmpty(strList[20]))
                                up.IPPSMoneyTypeAmount2 = strList[20];
                            if (!string.IsNullOrEmpty(strList[21]))
                                up.ContractNo = strList[21];
                            if (!string.IsNullOrEmpty(strList[22]))
                                up.InvoiceNo = strList[22];
                            if (!string.IsNullOrEmpty(strList[23]))
                                up.BatchNoOrTNoOrSerialNo = strList[23];
                            if (!string.IsNullOrEmpty(strList[24]))
                                up.ApplicantName = strList[24];
                            if (!string.IsNullOrEmpty(strList[25]))
                                up.Contactnumber = strList[25];
                            up.PayeeOpenBankType = AccountBankType.BocAccount;
                            #endregion
                            break;
                        case OverCountryPayeeAccountType.OtherAccount:
                            #region
                            if (!string.IsNullOrEmpty(strList[0]))
                                up.PayerAccount = strList[0];
                            if (!string.IsNullOrEmpty(strList[1]))
                                up.PayerName = strList[1];
                            if (!string.IsNullOrEmpty(strList[2]))
                                up.NominalPayerName = strList[2];
                            if (!string.IsNullOrEmpty(strList[3]))
                                up.NominalPayerAccount = strList[3];
                            if (!string.IsNullOrEmpty(strList[4]))
                                up.CashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                            if (!string.IsNullOrEmpty(strList[5]))
                                up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[5]);
                            if (!string.IsNullOrEmpty(strList[6]))
                                up.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[6]);
                            if (!string.IsNullOrEmpty(strList[7]))
                                up.Amount = DataConvertHelper.Instance.FormatCash(strList[7], false).Replace(",", "");
                            if (!string.IsNullOrEmpty(strList[8]))
                                up.OrgCode = strList[8];
                            if (!string.IsNullOrEmpty(strList[9]))
                                up.CustomerBusinissNo = strList[9];
                            if (!string.IsNullOrEmpty(strList[10]))
                                up.realPayAddress = strList[10];
                            if (!string.IsNullOrEmpty(strList[11]))
                                up.Addtion = strList[11];
                            if (!string.IsNullOrEmpty(strList[12]))
                                up.PayeeAccount = strList[12];
                            if (!string.IsNullOrEmpty(strList[13]))
                                up.PayeeName = strList[13];
                            if (!string.IsNullOrEmpty(strList[14]))
                                up.Address = strList[14];
                            if (!string.IsNullOrEmpty(strList[15]))
                                up.PayeeOpenBankName = strList[15];
                            if (!string.IsNullOrEmpty(strList[16]))
                                up.OpenBankAddress = strList[16];
                            if (!string.IsNullOrEmpty(strList[17]))
                                up.PayeeOpenBankSwiftCode = strList[17];
                            if (!string.IsNullOrEmpty(strList[18]))
                                up.CorrespondentBankName = strList[18];
                            if (!string.IsNullOrEmpty(strList[19]))
                                up.CorrespondentBankSwiftCode = strList[19];
                            if (!string.IsNullOrEmpty(strList[20]))
                                up.PayeeAccountInCorrespondentBank = strList[20];
                            if (!string.IsNullOrEmpty(strList[21]))
                                up.CorrespondentBankAddress = strList[21];
                            if (!string.IsNullOrEmpty(strList[22]))
                                up.CodeofCountry = strList[22];
                            if (!string.IsNullOrEmpty(strList[23]))
                                up.IsImportCancelAfterVerificationType = DataConvertHelper.Instance.GetIsImportCancelAfterVerificationType(strList[23]);
                            if (!string.IsNullOrEmpty(strList[24]))
                                up.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(strList[24]);
                            if (!string.IsNullOrEmpty(strList[25]))
                                up.PaymentNature = DataConvertHelper.Instance.GetPaymentPropertyType(strList[25]);
                            if (!string.IsNullOrEmpty(strList[26]))
                                up.TransactionCode1 = strList[26];
                            if (!string.IsNullOrEmpty(strList[27]))
                                up.TransactionCode2 = strList[27];
                            if (!string.IsNullOrEmpty(strList[28]))
                                up.IPPSMoneyTypeAmount1 = strList[28];
                            if (!string.IsNullOrEmpty(strList[29]))
                                up.IPPSMoneyTypeAmount2 = strList[29];
                            if (!string.IsNullOrEmpty(strList[30]))
                                up.ContractNo = strList[30];
                            if (!string.IsNullOrEmpty(strList[31]))
                                up.InvoiceNo = strList[31];
                            if (!string.IsNullOrEmpty(strList[32]))
                                up.BatchNoOrTNoOrSerialNo = strList[32];
                            if (!string.IsNullOrEmpty(strList[33]))
                                up.ApplicantName = strList[33];
                            if (!string.IsNullOrEmpty(strList[34]))
                                up.Contactnumber = strList[34];
                            up.PayeeOpenBankType = AccountBankType.OtherBankAccount;
                            #endregion
                            break;
                        case OverCountryPayeeAccountType.ForeignAccount:
                            #region
                            if (!string.IsNullOrEmpty(strList[0]))
                                up.PayerAccount = strList[0];
                            if (!string.IsNullOrEmpty(strList[1]))
                                up.PayerName = strList[1];
                            if (!string.IsNullOrEmpty(strList[2]))
                                up.NominalPayerName = strList[2];
                            if (!string.IsNullOrEmpty(strList[3]))
                                up.NominalPayerAccount = strList[3];
                            if (!string.IsNullOrEmpty(strList[4]))
                                up.CashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                            if (!string.IsNullOrEmpty(strList[5]))
                                up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[5]);
                            if (!string.IsNullOrEmpty(strList[6]))
                                up.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[6]);
                            if (!string.IsNullOrEmpty(strList[7]))
                                up.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(strList[7]);
                            if (!string.IsNullOrEmpty(strList[8]))
                                up.Amount = DataConvertHelper.Instance.FormatCash(strList[8], false).Replace(",", "");
                            if (!string.IsNullOrEmpty(strList[9]))
                                up.realPayAddress = strList[9];
                            if (!string.IsNullOrEmpty(strList[10]))
                                up.CustomerBusinissNo = strList[10];
                            if (!string.IsNullOrEmpty(strList[11]))
                                up.OrgCode = strList[11];
                            if (!string.IsNullOrEmpty(strList[12]))
                                up.Addtion = strList[12];
                            if (!string.IsNullOrEmpty(strList[13]))
                                up.PayeeAccount = strList[13];
                            if (!string.IsNullOrEmpty(strList[14]))
                                up.PayeeName = strList[14];
                            if (!string.IsNullOrEmpty(strList[15]))
                                up.Address = strList[15];
                            if (!string.IsNullOrEmpty(strList[16]))
                                up.PayeeOpenBankName = strList[16];
                            if (!string.IsNullOrEmpty(strList[17]))
                                up.OpenBankAddress = strList[17];
                            if (!string.IsNullOrEmpty(strList[18]))
                                up.PayeeOpenBankSwiftCode = strList[18];
                            if (!string.IsNullOrEmpty(strList[19]))
                                up.CorrespondentBankName = strList[19];
                            if (!string.IsNullOrEmpty(strList[20]))
                                up.CorrespondentBankSwiftCode = strList[20];
                            if (!string.IsNullOrEmpty(strList[21]))
                                up.CorrespondentBankAddress = strList[21];
                            if (!string.IsNullOrEmpty(strList[22]))
                                up.PayeeAccountInCorrespondentBank = strList[22];
                            if (!string.IsNullOrEmpty(strList[23]))
                                up.CodeofCountry = strList[23];
                            if (!string.IsNullOrEmpty(strList[24]))
                                up.FCPayeeAccountType = DataConvertHelper.Instance.GetUnitiveFCPayeeAccountType(strList[24]);
                            if (!string.IsNullOrEmpty(strList[25]))
                                up.PaymentCountryOrArea = DataConvertHelper.Instance.GetTransfer2CountryType(strList[25]);
                            if (!string.IsNullOrEmpty(strList[26]))
                                up.TransactionCode1 = strList[26];
                            if (!string.IsNullOrEmpty(strList[27]))
                                up.TransactionCode2 = strList[27];
                            if (!string.IsNullOrEmpty(strList[28]))
                                up.IPPSMoneyTypeAmount1 = strList[28];
                            if (!string.IsNullOrEmpty(strList[29]))
                                up.IPPSMoneyTypeAmount2 = strList[29];
                            if (!string.IsNullOrEmpty(strList[30]))
                                up.TransactionAddtion1 = strList[30];
                            if (!string.IsNullOrEmpty(strList[31]))
                                up.TransactionAddtion2 = strList[31];
                            if (!string.IsNullOrEmpty(strList[32]))
                                up.IsPayOffLine = Convert.ToBoolean(strList[32]);
                            if (!string.IsNullOrEmpty(strList[33]))
                                up.ContractNo = strList[33];
                            if (!string.IsNullOrEmpty(strList[34]))
                                up.InvoiceNo = strList[34];
                            if (!string.IsNullOrEmpty(strList[35]))
                                up.CustomerBusinissNo = strList[35];
                            if (!string.IsNullOrEmpty(strList[36]))
                                up.ApplicantName = strList[36];
                            if (!string.IsNullOrEmpty(strList[37]))
                                up.Contactnumber = strList[37];
                            #endregion
                            break;
                    }
                    up.PayeeAccountType = type;
                }
                catch { }
                finally
                {
                    list.Add(up);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                up = new UnitivePaymentForeignMoney();
                string data = contentData[maxcount];
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    switch (type)
                    {
                        case OverCountryPayeeAccountType.BocAccount:
                            #region
                            if (!string.IsNullOrEmpty(strList[0]))
                                up.PayerAccount = strList[0];
                            if (!string.IsNullOrEmpty(strList[1]))
                                up.PayerName = strList[1];
                            if (!string.IsNullOrEmpty(strList[2]))
                                up.NominalPayerName = strList[2];
                            if (!string.IsNullOrEmpty(strList[3]))
                                up.NominalPayerAccount = strList[3];
                            if (!string.IsNullOrEmpty(strList[4]))
                                up.CashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                            if (!string.IsNullOrEmpty(strList[5]))
                                up.PayeeAccount = strList[5];
                            if (!string.IsNullOrEmpty(strList[6]))
                                up.PayeeName = strList[6];
                            if (!string.IsNullOrEmpty(strList[7]))
                                up.PayeeOpenBankName = strList[7];
                            if (!string.IsNullOrEmpty(strList[8]))
                                up.Amount = DataConvertHelper.Instance.FormatCash(strList[8], false).Replace(",", "");
                            if (!string.IsNullOrEmpty(strList[9]))
                                up.CustomerBusinissNo = strList[9];
                            if (!string.IsNullOrEmpty(strList[10]))
                                up.Purpose = strList[10];
                            if (!string.IsNullOrEmpty(strList[11]))
                                up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[11]);
                            if (!string.IsNullOrEmpty(strList[12]))
                                up.Addtion = strList[12];
                            if (!string.IsNullOrEmpty(strList[13]))
                                up.CodeofCountry = strList[13];
                            if (!string.IsNullOrEmpty(strList[14]))
                                up.IsImportCancelAfterVerificationType = DataConvertHelper.Instance.GetIsImportCancelAfterVerificationType(strList[14]);
                            if (!string.IsNullOrEmpty(strList[15]))
                                up.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(strList[15]);
                            if (!string.IsNullOrEmpty(strList[16]))
                                up.PaymentNature = DataConvertHelper.Instance.GetPaymentPropertyType(strList[16]);
                            if (!string.IsNullOrEmpty(strList[17]))
                                up.TransactionCode1 = strList[17];
                            if (!string.IsNullOrEmpty(strList[18]))
                                up.TransactionCode2 = strList[18];
                            if (!string.IsNullOrEmpty(strList[19]))
                                up.IPPSMoneyTypeAmount1 = strList[19];
                            if (!string.IsNullOrEmpty(strList[20]))
                                up.IPPSMoneyTypeAmount2 = strList[20];
                            if (!string.IsNullOrEmpty(strList[21]))
                                up.ContractNo = strList[21];
                            if (!string.IsNullOrEmpty(strList[22]))
                                up.InvoiceNo = strList[22];
                            if (!string.IsNullOrEmpty(strList[23]))
                                up.BatchNoOrTNoOrSerialNo = strList[23];
                            if (!string.IsNullOrEmpty(strList[24]))
                                up.ApplicantName = strList[24];
                            if (!string.IsNullOrEmpty(strList[25]))
                                up.Contactnumber = strList[25];
                            up.PayeeOpenBankType = AccountBankType.BocAccount;
                            #endregion
                            break;
                        case OverCountryPayeeAccountType.OtherAccount:
                            #region
                            if (!string.IsNullOrEmpty(strList[0]))
                                up.PayerAccount = strList[0];
                            if (!string.IsNullOrEmpty(strList[1]))
                                up.PayerName = strList[1];
                            if (!string.IsNullOrEmpty(strList[2]))
                                up.NominalPayerName = strList[2];
                            if (!string.IsNullOrEmpty(strList[3]))
                                up.NominalPayerAccount = strList[3];
                            if (!string.IsNullOrEmpty(strList[4]))
                                up.CashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                            if (!string.IsNullOrEmpty(strList[5]))
                                up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[5]);
                            if (!string.IsNullOrEmpty(strList[6]))
                                up.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[6]);
                            if (!string.IsNullOrEmpty(strList[7]))
                                up.Amount = DataConvertHelper.Instance.FormatCash(strList[7], false).Replace(",", "");
                            if (!string.IsNullOrEmpty(strList[8]))
                                up.OrgCode = strList[8];
                            if (!string.IsNullOrEmpty(strList[9]))
                                up.CustomerBusinissNo = strList[9];
                            if (!string.IsNullOrEmpty(strList[10]))
                                up.realPayAddress = strList[10];
                            if (!string.IsNullOrEmpty(strList[11]))
                                up.Addtion = strList[11];
                            if (!string.IsNullOrEmpty(strList[12]))
                                up.PayeeAccount = strList[12];
                            if (!string.IsNullOrEmpty(strList[13]))
                                up.PayeeName = strList[13];
                            if (!string.IsNullOrEmpty(strList[14]))
                                up.Address = strList[14];
                            if (!string.IsNullOrEmpty(strList[15]))
                                up.PayeeOpenBankName = strList[15];
                            if (!string.IsNullOrEmpty(strList[16]))
                                up.OpenBankAddress = strList[16];
                            if (!string.IsNullOrEmpty(strList[17]))
                                up.PayeeOpenBankSwiftCode = strList[17];
                            if (!string.IsNullOrEmpty(strList[18]))
                                up.CorrespondentBankName = strList[18];
                            if (!string.IsNullOrEmpty(strList[19]))
                                up.CorrespondentBankSwiftCode = strList[19];
                            if (!string.IsNullOrEmpty(strList[20]))
                                up.PayeeAccountInCorrespondentBank = strList[20];
                            if (!string.IsNullOrEmpty(strList[21]))
                                up.CorrespondentBankAddress = strList[21];
                            if (!string.IsNullOrEmpty(strList[22]))
                                up.CodeofCountry = strList[22];
                            if (!string.IsNullOrEmpty(strList[23]))
                                up.IsImportCancelAfterVerificationType = DataConvertHelper.Instance.GetIsImportCancelAfterVerificationType(strList[23]);
                            if (!string.IsNullOrEmpty(strList[24]))
                                up.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(strList[24]);
                            if (!string.IsNullOrEmpty(strList[25]))
                                up.PaymentNature = DataConvertHelper.Instance.GetPaymentPropertyType(strList[25]);
                            if (!string.IsNullOrEmpty(strList[26]))
                                up.TransactionCode1 = strList[26];
                            if (!string.IsNullOrEmpty(strList[27]))
                                up.TransactionCode2 = strList[27];
                            if (!string.IsNullOrEmpty(strList[28]))
                                up.IPPSMoneyTypeAmount1 = strList[28];
                            if (!string.IsNullOrEmpty(strList[29]))
                                up.IPPSMoneyTypeAmount2 = strList[29];
                            if (!string.IsNullOrEmpty(strList[30]))
                                up.ContractNo = strList[30];
                            if (!string.IsNullOrEmpty(strList[31]))
                                up.InvoiceNo = strList[31];
                            if (!string.IsNullOrEmpty(strList[32]))
                                up.BatchNoOrTNoOrSerialNo = strList[32];
                            if (!string.IsNullOrEmpty(strList[33]))
                                up.ApplicantName = strList[33];
                            if (!string.IsNullOrEmpty(strList[34]))
                                up.Contactnumber = strList[34];
                            up.PayeeOpenBankType = AccountBankType.OtherBankAccount;
                            #endregion
                            break;
                        case OverCountryPayeeAccountType.ForeignAccount:
                            #region
                            if (!string.IsNullOrEmpty(strList[0]))
                                up.PayerAccount = strList[0];
                            if (!string.IsNullOrEmpty(strList[1]))
                                up.PayerName = strList[1];
                            if (!string.IsNullOrEmpty(strList[2]))
                                up.NominalPayerName = strList[2];
                            if (!string.IsNullOrEmpty(strList[3]))
                                up.NominalPayerAccount = strList[3];
                            if (!string.IsNullOrEmpty(strList[4]))
                                up.CashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                            if (!string.IsNullOrEmpty(strList[5]))
                                up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[5]);
                            if (!string.IsNullOrEmpty(strList[6]))
                                up.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[6]);
                            if (!string.IsNullOrEmpty(strList[7]))
                                up.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(strList[7]);
                            if (!string.IsNullOrEmpty(strList[8]))
                                up.Amount = DataConvertHelper.Instance.FormatCash(strList[8], false).Replace(",", "");
                            if (!string.IsNullOrEmpty(strList[9]))
                                up.realPayAddress = strList[9];
                            if (!string.IsNullOrEmpty(strList[10]))
                                up.CustomerBusinissNo = strList[10];
                            if (!string.IsNullOrEmpty(strList[11]))
                                up.OrgCode = strList[11];
                            if (!string.IsNullOrEmpty(strList[12]))
                                up.Addtion = strList[12];
                            if (!string.IsNullOrEmpty(strList[13]))
                                up.PayeeAccount = strList[13];
                            if (!string.IsNullOrEmpty(strList[14]))
                                up.PayeeName = strList[14];
                            if (!string.IsNullOrEmpty(strList[15]))
                                up.Address = strList[15];
                            if (!string.IsNullOrEmpty(strList[16]))
                                up.PayeeOpenBankName = strList[16];
                            if (!string.IsNullOrEmpty(strList[17]))
                                up.OpenBankAddress = strList[17];
                            if (!string.IsNullOrEmpty(strList[18]))
                                up.PayeeOpenBankSwiftCode = strList[18];
                            if (!string.IsNullOrEmpty(strList[19]))
                                up.CorrespondentBankName = strList[19];
                            if (!string.IsNullOrEmpty(strList[20]))
                                up.CorrespondentBankSwiftCode = strList[20];
                            if (!string.IsNullOrEmpty(strList[21]))
                                up.CorrespondentBankAddress = strList[21];
                            if (!string.IsNullOrEmpty(strList[22]))
                                up.PayeeAccountInCorrespondentBank = strList[22];
                            if (!string.IsNullOrEmpty(strList[23]))
                                up.CodeofCountry = strList[23];
                            if (!string.IsNullOrEmpty(strList[24]))
                                up.FCPayeeAccountType = DataConvertHelper.Instance.GetUnitiveFCPayeeAccountType(strList[24]);
                            if (!string.IsNullOrEmpty(strList[25]))
                                up.PaymentCountryOrArea = DataConvertHelper.Instance.GetTransfer2CountryType(strList[25]);
                            if (!string.IsNullOrEmpty(strList[26]))
                                up.TransactionCode1 = strList[26];
                            if (!string.IsNullOrEmpty(strList[27]))
                                up.TransactionCode2 = strList[27];
                            if (!string.IsNullOrEmpty(strList[28]))
                                up.IPPSMoneyTypeAmount1 = strList[28];
                            if (!string.IsNullOrEmpty(strList[29]))
                                up.IPPSMoneyTypeAmount2 = strList[29];
                            if (!string.IsNullOrEmpty(strList[30]))
                                up.TransactionAddtion1 = strList[30];
                            if (!string.IsNullOrEmpty(strList[31]))
                                up.TransactionAddtion2 = strList[31];
                            if (!string.IsNullOrEmpty(strList[32]))
                                up.IsPayOffLine = Convert.ToBoolean(strList[32]);
                            if (!string.IsNullOrEmpty(strList[33]))
                                up.ContractNo = strList[33];
                            if (!string.IsNullOrEmpty(strList[34]))
                                up.InvoiceNo = strList[34];
                            if (!string.IsNullOrEmpty(strList[35]))
                                up.CustomerBusinissNo = strList[35];
                            if (!string.IsNullOrEmpty(strList[36]))
                                up.ApplicantName = strList[36];
                            if (!string.IsNullOrEmpty(strList[37]))
                                up.Contactnumber = strList[37];
                            #endregion
                            break;
                    }
                    up.PayeeAccountType = type;
                }
                catch { }
                finally { list.Add(up); }
            }

            return list;
        }

        public List<UnitivePaymentForeignMoney> GetUnitivePaymentFCBOC(List<string> contentData, AppliableFunctionType templateType, OverCountryPayeeAccountType type)
        {
            List<UnitivePaymentForeignMoney> list = new List<UnitivePaymentForeignMoney>();

            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            if (maxcount == 0) maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            UnitivePaymentForeignMoney up;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                up = new UnitivePaymentForeignMoney();
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    switch (type)
                    {
                        case OverCountryPayeeAccountType.BocAccount:
                            #region
                            if (!string.IsNullOrEmpty(strList[0]))
                                up.PayerAccount = strList[0];
                            if (!string.IsNullOrEmpty(strList[1]))
                                up.PayerName = strList[1];
                            if (!string.IsNullOrEmpty(strList[2]))
                                up.NominalPayerName = strList[2];
                            if (!string.IsNullOrEmpty(strList[3]))
                                up.NominalPayerAccount = strList[3];
                            if (!string.IsNullOrEmpty(strList[4]))
                                up.CashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                            if (!string.IsNullOrEmpty(strList[5]))
                                up.PayeeAccount = strList[5];
                            if (!string.IsNullOrEmpty(strList[6]))
                                up.PayeeName = strList[6];
                            if (!string.IsNullOrEmpty(strList[7]))
                                up.PayeeOpenBankName = strList[7];
                            if (!string.IsNullOrEmpty(strList[8]))
                                up.Amount = DataConvertHelper.Instance.FormatCash(strList[8], up.CashType == CashType.JPY).Replace(",", "");
                            if (!string.IsNullOrEmpty(strList[9]))
                                up.CustomerBusinissNo = strList[9];
                            if (!string.IsNullOrEmpty(strList[10]))
                                up.Purpose = strList[10];
                            if (!string.IsNullOrEmpty(strList[11]))
                                up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[11]);
                            if (!string.IsNullOrEmpty(strList[12]))
                                up.Addtion = strList[12];
                            if (!string.IsNullOrEmpty(strList[13]))
                                up.CodeofCountry = strList[13];
                            if (!string.IsNullOrEmpty(strList[14]))
                                up.IsImportCancelAfterVerificationType = DataConvertHelper.Instance.GetIsImportCancelAfterVerificationType(strList[14]);
                            if (!string.IsNullOrEmpty(strList[15]))
                                up.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(strList[15]);
                            if (!string.IsNullOrEmpty(strList[16]))
                                up.PaymentNature = DataConvertHelper.Instance.GetPaymentPropertyType(strList[16]);
                            if (!string.IsNullOrEmpty(strList[17]))
                                up.TransactionCode1 = strList[17];
                            if (!string.IsNullOrEmpty(strList[18]))
                                up.TransactionCode2 = strList[18];
                            if (!string.IsNullOrEmpty(strList[19]))
                                up.IPPSMoneyTypeAmount1 = DataConvertHelper.Instance.FormatCash(strList[19], up.CashType == CashType.JPY);
                            if (!string.IsNullOrEmpty(strList[20]))
                                up.IPPSMoneyTypeAmount2 = DataConvertHelper.Instance.FormatCash(strList[20], up.CashType == CashType.JPY);
                            if (!string.IsNullOrEmpty(strList[21]))
                                up.ContractNo = strList[21];
                            if (!string.IsNullOrEmpty(strList[22]))
                                up.InvoiceNo = strList[22];
                            if (!string.IsNullOrEmpty(strList[23]))
                                up.BatchNoOrTNoOrSerialNo = strList[23];
                            if (!string.IsNullOrEmpty(strList[24]))
                                up.ApplicantName = strList[24];
                            if (!string.IsNullOrEmpty(strList[25]))
                                up.Contactnumber = strList[25];
                            up.PayeeOpenBankType = AccountBankType.BocAccount;
                            #endregion
                            break;
                        case OverCountryPayeeAccountType.OtherAccount:
                            #region
                            if (!string.IsNullOrEmpty(strList[0]))
                                up.PayerAccount = strList[0];
                            if (!string.IsNullOrEmpty(strList[1]))
                                up.PayerName = strList[1];
                            if (!string.IsNullOrEmpty(strList[2]))
                                up.NominalPayerName = strList[2];
                            if (!string.IsNullOrEmpty(strList[3]))
                                up.NominalPayerAccount = strList[3];
                            if (!string.IsNullOrEmpty(strList[4]))
                                up.CashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                            if (!string.IsNullOrEmpty(strList[5]))
                                up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[5]);
                            if (!string.IsNullOrEmpty(strList[6]))
                                up.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[6]);
                            if (!string.IsNullOrEmpty(strList[7]))
                                up.Amount = DataConvertHelper.Instance.FormatCash(strList[7], up.CashType == CashType.JPY).Replace(",", "");
                            if (!string.IsNullOrEmpty(strList[8]))
                                up.OrgCode = strList[8];
                            if (!string.IsNullOrEmpty(strList[9]))
                                up.CustomerBusinissNo = strList[9];
                            if (!string.IsNullOrEmpty(strList[10]))
                                up.realPayAddress = strList[10];
                            if (!string.IsNullOrEmpty(strList[11]))
                                up.Addtion = strList[11];
                            if (!string.IsNullOrEmpty(strList[12]))
                                up.PayeeAccount = strList[12];
                            if (!string.IsNullOrEmpty(strList[13]))
                                up.PayeeName = strList[13];
                            if (!string.IsNullOrEmpty(strList[14]))
                                up.Address = strList[14];
                            if (!string.IsNullOrEmpty(strList[15]))
                                up.PayeeOpenBankName = strList[15];
                            if (!string.IsNullOrEmpty(strList[16]))
                                up.OpenBankAddress = strList[16];
                            if (!string.IsNullOrEmpty(strList[17]))
                                up.PayeeOpenBankSwiftCode = strList[17];
                            if (!string.IsNullOrEmpty(strList[18]))
                                up.CorrespondentBankName = strList[18];
                            if (!string.IsNullOrEmpty(strList[19]))
                                up.CorrespondentBankSwiftCode = strList[19];
                            if (!string.IsNullOrEmpty(strList[20]))
                                up.PayeeAccountInCorrespondentBank = strList[20];
                            if (!string.IsNullOrEmpty(strList[21]))
                                up.CorrespondentBankAddress = strList[21];
                            if (!string.IsNullOrEmpty(strList[22]))
                                up.CodeofCountry = strList[22];
                            if (!string.IsNullOrEmpty(strList[23]))
                                up.IsImportCancelAfterVerificationType = DataConvertHelper.Instance.GetIsImportCancelAfterVerificationType(strList[23]);
                            if (!string.IsNullOrEmpty(strList[24]))
                                up.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(strList[24]);
                            if (!string.IsNullOrEmpty(strList[25]))
                                up.PaymentNature = DataConvertHelper.Instance.GetPaymentPropertyType(strList[25]);
                            if (!string.IsNullOrEmpty(strList[26]))
                                up.TransactionCode1 = strList[26];
                            if (!string.IsNullOrEmpty(strList[27]))
                                up.TransactionCode2 = strList[27];
                            if (!string.IsNullOrEmpty(strList[28]))
                                up.IPPSMoneyTypeAmount1 = DataConvertHelper.Instance.FormatCash(strList[28], up.CashType == CashType.JPY);
                            if (!string.IsNullOrEmpty(strList[29]))
                                up.IPPSMoneyTypeAmount2 = DataConvertHelper.Instance.FormatCash(strList[29], up.CashType == CashType.JPY);
                            if (!string.IsNullOrEmpty(strList[30]))
                                up.ContractNo = strList[30];
                            if (!string.IsNullOrEmpty(strList[31]))
                                up.InvoiceNo = strList[31];
                            if (!string.IsNullOrEmpty(strList[32]))
                                up.BatchNoOrTNoOrSerialNo = strList[32];
                            if (!string.IsNullOrEmpty(strList[33]))
                                up.ApplicantName = strList[33];
                            if (!string.IsNullOrEmpty(strList[34]))
                                up.Contactnumber = strList[34];
                            up.PayeeOpenBankType = AccountBankType.OtherBankAccount;
                            #endregion
                            break;
                        case OverCountryPayeeAccountType.ForeignAccount:
                            #region
                            if (!string.IsNullOrEmpty(strList[0]))
                                up.PayerAccount = strList[0];
                            if (!string.IsNullOrEmpty(strList[1]))
                                up.PayerName = strList[1];
                            if (!string.IsNullOrEmpty(strList[2]))
                                up.NominalPayerName = strList[2];
                            if (!string.IsNullOrEmpty(strList[3]))
                                up.NominalPayerAccount = strList[3];
                            if (!string.IsNullOrEmpty(strList[4]))
                                up.CashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                            if (!string.IsNullOrEmpty(strList[5]))
                                up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[5]);
                            if (!string.IsNullOrEmpty(strList[6]))
                                up.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[6]);
                            if (!string.IsNullOrEmpty(strList[7]))
                                up.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(strList[7]);
                            if (!string.IsNullOrEmpty(strList[8]))
                                up.Amount = DataConvertHelper.Instance.FormatCash(strList[8], up.CashType == CashType.JPY).Replace(",", "");
                            if (!string.IsNullOrEmpty(strList[9]))
                                up.realPayAddress = strList[9];
                            if (!string.IsNullOrEmpty(strList[10]))
                                up.CustomerBusinissNo = strList[10];
                            if (!string.IsNullOrEmpty(strList[11]))
                                up.OrgCode = strList[11];
                            if (!string.IsNullOrEmpty(strList[12]))
                                up.Addtion = strList[12];
                            if (!string.IsNullOrEmpty(strList[13]))
                                up.PayeeAccount = strList[13];
                            if (!string.IsNullOrEmpty(strList[14]))
                                up.PayeeName = strList[14];
                            if (!string.IsNullOrEmpty(strList[15]))
                                up.Address = strList[15];
                            if (!string.IsNullOrEmpty(strList[16]))
                                up.PayeeOpenBankName = strList[16];
                            if (!string.IsNullOrEmpty(strList[17]))
                                up.OpenBankAddress = strList[17];
                            if (!string.IsNullOrEmpty(strList[18]))
                                up.PayeeOpenBankSwiftCode = strList[18];
                            if (!string.IsNullOrEmpty(strList[19]))
                                up.CorrespondentBankName = strList[19];
                            if (!string.IsNullOrEmpty(strList[20]))
                                up.CorrespondentBankSwiftCode = strList[20];
                            if (!string.IsNullOrEmpty(strList[21]))
                                up.CorrespondentBankAddress = strList[21];
                            if (!string.IsNullOrEmpty(strList[22]))
                                up.PayeeAccountInCorrespondentBank = strList[22];
                            if (!string.IsNullOrEmpty(strList[23]))
                                up.CodeofCountry = strList[23];
                            if (!string.IsNullOrEmpty(strList[24]))
                                up.FCPayeeAccountType = DataConvertHelper.Instance.GetUnitiveFCPayeeAccountType(strList[24]);
                            if (!string.IsNullOrEmpty(strList[25]))
                                up.PaymentCountryOrArea = DataConvertHelper.Instance.GetTransfer2CountryType(strList[25]);
                            if (!string.IsNullOrEmpty(strList[26]))
                                up.TransactionCode1 = strList[26];
                            if (!string.IsNullOrEmpty(strList[27]))
                                up.TransactionCode2 = strList[27];
                            if (!string.IsNullOrEmpty(strList[28]))
                                up.IPPSMoneyTypeAmount1 = DataConvertHelper.Instance.FormatCash(strList[28], up.CashType == CashType.JPY);
                            if (!string.IsNullOrEmpty(strList[29]))
                                up.IPPSMoneyTypeAmount2 = DataConvertHelper.Instance.FormatCash(strList[29], up.CashType == CashType.JPY);
                            if (!string.IsNullOrEmpty(strList[30]))
                                up.TransactionAddtion1 = strList[30];
                            if (!string.IsNullOrEmpty(strList[31]))
                                up.TransactionAddtion2 = strList[31];
                            if (!string.IsNullOrEmpty(strList[32]))
                                up.IsPayOffLine = !DataConvertHelper.Instance.GetIsPayOffLine(strList[32]);
                            if (!string.IsNullOrEmpty(strList[33]))
                                up.ContractNo = strList[33];
                            if (!string.IsNullOrEmpty(strList[34]))
                                up.InvoiceNo = strList[34];
                            if (!string.IsNullOrEmpty(strList[35]))
                                up.BatchNoOrTNoOrSerialNo = strList[35];
                            if (!string.IsNullOrEmpty(strList[36]))
                                up.ApplicantName = strList[36];
                            if (!string.IsNullOrEmpty(strList[37]))
                                up.Contactnumber = strList[37];
                            #endregion
                            break;
                    }
                    up.PayeeAccountType = type;
                }
                catch { }
                finally
                {
                    list.Add(up);
                    count++;
                }
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                up = new UnitivePaymentForeignMoney();
                string data = contentData[maxcount];
                string[] strList = data.Split(s, StringSplitOptions.None);
                try
                {
                    switch (type)
                    {
                        case OverCountryPayeeAccountType.BocAccount:
                            #region
                            if (!string.IsNullOrEmpty(strList[0]))
                                up.PayerAccount = strList[0];
                            if (!string.IsNullOrEmpty(strList[1]))
                                up.PayerName = strList[1];
                            if (!string.IsNullOrEmpty(strList[2]))
                                up.NominalPayerName = strList[2];
                            if (!string.IsNullOrEmpty(strList[3]))
                                up.NominalPayerAccount = strList[3];
                            if (!string.IsNullOrEmpty(strList[4]))
                                up.CashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                            if (!string.IsNullOrEmpty(strList[5]))
                                up.PayeeAccount = strList[5];
                            if (!string.IsNullOrEmpty(strList[6]))
                                up.PayeeName = strList[6];
                            if (!string.IsNullOrEmpty(strList[7]))
                                up.PayeeOpenBankName = strList[7];
                            if (!string.IsNullOrEmpty(strList[8]))
                                up.Amount = DataConvertHelper.Instance.FormatCash(strList[8], false).Replace(",", "");
                            if (!string.IsNullOrEmpty(strList[9]))
                                up.CustomerBusinissNo = strList[9];
                            if (!string.IsNullOrEmpty(strList[10]))
                                up.Purpose = strList[10];
                            if (!string.IsNullOrEmpty(strList[11]))
                                up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[11]);
                            if (!string.IsNullOrEmpty(strList[12]))
                                up.Addtion = strList[12];
                            if (!string.IsNullOrEmpty(strList[13]))
                                up.CodeofCountry = strList[13];
                            if (!string.IsNullOrEmpty(strList[14]))
                                up.IsImportCancelAfterVerificationType = DataConvertHelper.Instance.GetIsImportCancelAfterVerificationType(strList[14]);
                            if (!string.IsNullOrEmpty(strList[15]))
                                up.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(strList[15]);
                            if (!string.IsNullOrEmpty(strList[16]))
                                up.PaymentNature = DataConvertHelper.Instance.GetPaymentPropertyType(strList[16]);
                            if (!string.IsNullOrEmpty(strList[17]))
                                up.TransactionCode1 = strList[17];
                            if (!string.IsNullOrEmpty(strList[18]))
                                up.TransactionCode2 = strList[18];
                            if (!string.IsNullOrEmpty(strList[19]))
                                up.IPPSMoneyTypeAmount1 = strList[19];
                            if (!string.IsNullOrEmpty(strList[20]))
                                up.IPPSMoneyTypeAmount2 = strList[20];
                            if (!string.IsNullOrEmpty(strList[21]))
                                up.ContractNo = strList[21];
                            if (!string.IsNullOrEmpty(strList[22]))
                                up.InvoiceNo = strList[22];
                            if (!string.IsNullOrEmpty(strList[23]))
                                up.BatchNoOrTNoOrSerialNo = strList[23];
                            if (!string.IsNullOrEmpty(strList[24]))
                                up.ApplicantName = strList[24];
                            if (!string.IsNullOrEmpty(strList[25]))
                                up.Contactnumber = strList[25];
                            up.PayeeOpenBankType = AccountBankType.BocAccount;
                            #endregion
                            break;
                        case OverCountryPayeeAccountType.OtherAccount:
                            #region
                            if (!string.IsNullOrEmpty(strList[0]))
                                up.PayerAccount = strList[0];
                            if (!string.IsNullOrEmpty(strList[1]))
                                up.PayerName = strList[1];
                            if (!string.IsNullOrEmpty(strList[2]))
                                up.NominalPayerName = strList[2];
                            if (!string.IsNullOrEmpty(strList[3]))
                                up.NominalPayerAccount = strList[3];
                            if (!string.IsNullOrEmpty(strList[4]))
                                up.CashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                            if (!string.IsNullOrEmpty(strList[5]))
                                up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[5]);
                            if (!string.IsNullOrEmpty(strList[6]))
                                up.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[6]);
                            if (!string.IsNullOrEmpty(strList[7]))
                                up.Amount = DataConvertHelper.Instance.FormatCash(strList[7], false).Replace(",", "");
                            if (!string.IsNullOrEmpty(strList[8]))
                                up.OrgCode = strList[8];
                            if (!string.IsNullOrEmpty(strList[9]))
                                up.CustomerBusinissNo = strList[9];
                            if (!string.IsNullOrEmpty(strList[10]))
                                up.realPayAddress = strList[10];
                            if (!string.IsNullOrEmpty(strList[11]))
                                up.Addtion = strList[11];
                            if (!string.IsNullOrEmpty(strList[12]))
                                up.PayeeAccount = strList[12];
                            if (!string.IsNullOrEmpty(strList[13]))
                                up.PayeeName = strList[13];
                            if (!string.IsNullOrEmpty(strList[14]))
                                up.Address = strList[14];
                            if (!string.IsNullOrEmpty(strList[15]))
                                up.PayeeOpenBankName = strList[15];
                            if (!string.IsNullOrEmpty(strList[16]))
                                up.OpenBankAddress = strList[16];
                            if (!string.IsNullOrEmpty(strList[17]))
                                up.PayeeOpenBankSwiftCode = strList[17];
                            if (!string.IsNullOrEmpty(strList[18]))
                                up.CorrespondentBankName = strList[18];
                            if (!string.IsNullOrEmpty(strList[19]))
                                up.CorrespondentBankSwiftCode = strList[19];
                            if (!string.IsNullOrEmpty(strList[20]))
                                up.PayeeAccountInCorrespondentBank = strList[20];
                            if (!string.IsNullOrEmpty(strList[21]))
                                up.CorrespondentBankAddress = strList[21];
                            if (!string.IsNullOrEmpty(strList[22]))
                                up.CodeofCountry = strList[22];
                            if (!string.IsNullOrEmpty(strList[23]))
                                up.IsImportCancelAfterVerificationType = DataConvertHelper.Instance.GetIsImportCancelAfterVerificationType(strList[23]);
                            if (!string.IsNullOrEmpty(strList[24]))
                                up.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(strList[24]);
                            if (!string.IsNullOrEmpty(strList[25]))
                                up.PaymentNature = DataConvertHelper.Instance.GetPaymentPropertyType(strList[25]);
                            if (!string.IsNullOrEmpty(strList[26]))
                                up.TransactionCode1 = strList[26];
                            if (!string.IsNullOrEmpty(strList[27]))
                                up.TransactionCode2 = strList[27];
                            if (!string.IsNullOrEmpty(strList[28]))
                                up.IPPSMoneyTypeAmount1 = strList[28];
                            if (!string.IsNullOrEmpty(strList[29]))
                                up.IPPSMoneyTypeAmount2 = strList[29];
                            if (!string.IsNullOrEmpty(strList[30]))
                                up.ContractNo = strList[30];
                            if (!string.IsNullOrEmpty(strList[31]))
                                up.InvoiceNo = strList[31];
                            if (!string.IsNullOrEmpty(strList[32]))
                                up.BatchNoOrTNoOrSerialNo = strList[32];
                            if (!string.IsNullOrEmpty(strList[33]))
                                up.ApplicantName = strList[33];
                            if (!string.IsNullOrEmpty(strList[34]))
                                up.Contactnumber = strList[34];
                            up.PayeeOpenBankType = AccountBankType.OtherBankAccount;
                            #endregion
                            break;
                        case OverCountryPayeeAccountType.ForeignAccount:
                            #region
                            if (!string.IsNullOrEmpty(strList[0]))
                                up.PayerAccount = strList[0];
                            if (!string.IsNullOrEmpty(strList[1]))
                                up.PayerName = strList[1];
                            if (!string.IsNullOrEmpty(strList[2]))
                                up.NominalPayerName = strList[2];
                            if (!string.IsNullOrEmpty(strList[3]))
                                up.NominalPayerAccount = strList[3];
                            if (!string.IsNullOrEmpty(strList[4]))
                                up.CashType = DataConvertHelper.Instance.GetCashType(strList[4]);
                            if (!string.IsNullOrEmpty(strList[5]))
                                up.OrderPayDate = DataConvertHelper.Instance.FormatDateTimeFromInt(strList[5]);
                            if (!string.IsNullOrEmpty(strList[6]))
                                up.SendPriority = DataConvertHelper.Instance.GetTransferChanelType(strList[6]);
                            if (!string.IsNullOrEmpty(strList[7]))
                                up.UnitivePaymentType = DataConvertHelper.Instance.GetPayFeeType(strList[7]);
                            if (!string.IsNullOrEmpty(strList[8]))
                                up.Amount = DataConvertHelper.Instance.FormatCash(strList[8], false).Replace(",", "");
                            if (!string.IsNullOrEmpty(strList[9]))
                                up.realPayAddress = strList[9];
                            if (!string.IsNullOrEmpty(strList[10]))
                                up.CustomerBusinissNo = strList[10];
                            if (!string.IsNullOrEmpty(strList[11]))
                                up.OrgCode = strList[11];
                            if (!string.IsNullOrEmpty(strList[12]))
                                up.Addtion = strList[12];
                            if (!string.IsNullOrEmpty(strList[13]))
                                up.PayeeAccount = strList[13];
                            if (!string.IsNullOrEmpty(strList[14]))
                                up.PayeeName = strList[14];
                            if (!string.IsNullOrEmpty(strList[15]))
                                up.Address = strList[15];
                            if (!string.IsNullOrEmpty(strList[16]))
                                up.PayeeOpenBankName = strList[16];
                            if (!string.IsNullOrEmpty(strList[17]))
                                up.OpenBankAddress = strList[17];
                            if (!string.IsNullOrEmpty(strList[18]))
                                up.PayeeOpenBankSwiftCode = strList[18];
                            if (!string.IsNullOrEmpty(strList[19]))
                                up.CorrespondentBankName = strList[19];
                            if (!string.IsNullOrEmpty(strList[20]))
                                up.CorrespondentBankSwiftCode = strList[20];
                            if (!string.IsNullOrEmpty(strList[21]))
                                up.CorrespondentBankAddress = strList[21];
                            if (!string.IsNullOrEmpty(strList[22]))
                                up.PayeeAccountInCorrespondentBank = strList[22];
                            if (!string.IsNullOrEmpty(strList[23]))
                                up.CodeofCountry = strList[23];
                            if (!string.IsNullOrEmpty(strList[24]))
                                up.FCPayeeAccountType = DataConvertHelper.Instance.GetUnitiveFCPayeeAccountType(strList[24]);
                            if (!string.IsNullOrEmpty(strList[25]))
                                up.PaymentCountryOrArea = DataConvertHelper.Instance.GetTransfer2CountryType(strList[25]);
                            if (!string.IsNullOrEmpty(strList[26]))
                                up.TransactionCode1 = strList[26];
                            if (!string.IsNullOrEmpty(strList[27]))
                                up.TransactionCode2 = strList[27];
                            if (!string.IsNullOrEmpty(strList[28]))
                                up.IPPSMoneyTypeAmount1 = strList[28];
                            if (!string.IsNullOrEmpty(strList[29]))
                                up.IPPSMoneyTypeAmount2 = strList[29];
                            if (!string.IsNullOrEmpty(strList[30]))
                                up.TransactionAddtion1 = strList[30];
                            if (!string.IsNullOrEmpty(strList[31]))
                                up.TransactionAddtion2 = strList[31];
                            if (!string.IsNullOrEmpty(strList[32]))
                                up.IsPayOffLine = Convert.ToBoolean(strList[32]);
                            if (!string.IsNullOrEmpty(strList[33]))
                                up.ContractNo = strList[33];
                            if (!string.IsNullOrEmpty(strList[34]))
                                up.InvoiceNo = strList[34];
                            if (!string.IsNullOrEmpty(strList[35]))
                                up.CustomerBusinissNo = strList[35];
                            if (!string.IsNullOrEmpty(strList[36]))
                                up.ApplicantName = strList[36];
                            if (!string.IsNullOrEmpty(strList[37]))
                                up.Contactnumber = strList[37];
                            #endregion
                            break;
                    }
                    up.PayeeAccountType = type;
                }
                catch { }
                finally { list.Add(up); }
            }

            return list;
        }

        public List<UnitivePaymentForeignMoney> GetUnitivePaymentFCBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<UnitivePaymentForeignMoney> list = new List<UnitivePaymentForeignMoney>();

            UnitivePaymentForeignMoney ta;

            //获取交易内容信息
            foreach (var data in contentData)
            {
                ta = new UnitivePaymentForeignMoney();

                string[] strList = AnalyseBOCErrorCSVSytleData(data);
                try
                {
                    ta.RowIndex = int.Parse(strList[0]);
                    ta.ErrorReason = strList[strList.Length - 1];
                    list.Add(ta);
                }
                catch { }
            }

            return list;
        }

        public List<TransferGlobal> GetTransferGlobalBarBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<TransferGlobal> list = new List<TransferGlobal>();
            int index = 0;
            int maxcount = 0;
            TransferGlobal tg;
            AccountBankType bankType = AccountBankType.Empty;
            List<string> fileHeaders = new List<string>();

            //templateType== AppliableFunctionType.TransferOverCountry4Bar

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (templateType == AppliableFunctionType.TransferOverCountry4Bar)
                {
                    #region
                    if (index == 0)
                    {
                        fileHeaders = AnalyseBarStyleData(data, new List<int> { 2, 3, 25, 16, 12, 2, 3, 10, 50, 7, 1, 16, 25, 16, 32, 8, 32, 8, 32, 8, 32, 8, 24 });
                        if (templateType == AppliableFunctionType.TransferOverCountry4Bar && fileHeaders[0] != "C6") break;
                        maxcount = int.Parse(fileHeaders[4]);
                        index++;
                    }
                    else if (index <= maxcount)
                    {
                        tg = new TransferGlobal();
                        List<string> details = AnalyseBarStyleData(data, new List<int> { 1, 16, 140, 140, 10, 11, 140, 140, 11, 140, 140, 34, 140, 140, 34, 140, 1, 3, 30, 1, 6, 15, 50, 6, 15, 50, 1, 20, 35, 20, 20, 15 });
                        if (details.Count < 32) { index++; continue; }
                        tg.PaymentCashType = DataConvertHelper.Instance.GetCashType(fileHeaders[6]);
                        tg.PayFeeAccount = fileHeaders[2];

                        tg.PaymentType = "电汇";
                        try
                        {
                            tg.SendPriority = DataConvertHelper.Instance.GetTransferChanelType((int.Parse(details[0]) - 1).ToString());
                        }
                        catch { }
                        tg.RemitAmount = DataConvertHelper.Instance.FormatCash((double.Parse(details[1]) / 100).ToString(), tg.PaymentCashType == CashType.JPY);

                        if (fileHeaders[12].Trim() == "1")
                        {
                            tg.SpotAccount = tg.PayFeeAccount;
                            tg.SpotAmount = tg.RemitAmount;
                        }
                        else if (fileHeaders[12].Trim() == "2")
                        {
                            tg.PurchaseAccount = tg.PayFeeAccount;
                            tg.PurchaseAmount = tg.RemitAmount;
                        }

                        tg.RemitName = details[2];
                        tg.RemitAddress = details[3];
                        tg.OrgCode = details[4];
                        tg.CorrespondentBankSwiftCode = details[5];
                        tg.CorrespondentBankName = details[6];
                        tg.CorrespondentBankAddress = details[7];
                        tg.PayeeOpenBankSwiftCode = details[8];
                        tg.PayeeOpenBankName = details[9];
                        tg.PayeeOpenBankAddress = details[10];
                        tg.PayeeAccountInCorrespondentBank = details[11];
                        tg.PayeeName = details[12];
                        tg.PayeeAddress = details[13];
                        tg.PayeeAccount = details[14];
                        tg.RemitNote = details[15];
                        tg.AssumeFeeType = DataConvertHelper.Instance.GetAssumeFeeType(details[16]);
                        tg.PayeeCodeofCountry = details[17];
                        tg.PayeeNameofCountry = details[18];
                        tg.PayFeeType = DataConvertHelper.Instance.GetPayFeeType(details[19]);
                        tg.DealSerialNoF = details[20];
                        if (!string.IsNullOrEmpty(details[21].Trim()))
                            tg.AmountF = (double.Parse(details[21]) / 100).ToString();
                        tg.DealNoteF = details[22];
                        tg.DealSerialNoS = details[23];
                        if (!string.IsNullOrEmpty(details[24].Trim()))
                            tg.AmountS = (double.Parse(details[24]) / 100).ToString();
                        tg.DealNoteS = details[25];
                        tg.IsPayOffLine = DataConvertHelper.Instance.GetIsPayOffLine(details[26]);
                        tg.ContactNo = details[27];
                        tg.BillSerialNo = details[28];
                        tg.BatchNoOrTNoOrSerialNo = details[29];
                        tg.ProposerName = details[30];
                        tg.Telephone = details[31];
                        list.Add(tg);
                    }
                    #endregion
                }
                else if (templateType == AppliableFunctionType.TransferForeignMoney4Bar)
                {
                    #region
                    if (index == 0)
                    {
                        if (data.StartsWith("C5"))
                        {
                            fileHeaders = AnalyseBarStyleData(data, new List<int> { 2, 3, 25, 16, 12, 2, 3, 10, 50, 7, 58, 32, 8, 32, 8, 32, 8, 32, 8, 24, 1 });
                            if (templateType == AppliableFunctionType.TransferForeignMoney4Bar && fileHeaders[0] != "C5") break;
                            maxcount = int.Parse(fileHeaders[4]);
                            bankType = AccountBankType.OtherBankAccount;
                        }
                        else if (data.StartsWith("C1"))
                        {
                            fileHeaders = AnalyseBarStyleData(data, new List<int> { 2, 3, 25, 16, 12, 2, 3, 10, 50, 7, 1, 16, 25, 16, 32, 8, 32, 8, 32, 8, 32, 8, 24 });
                            if (templateType == AppliableFunctionType.TransferForeignMoney4Bar && fileHeaders[0] != "C1") break;
                            maxcount = int.Parse(fileHeaders[4]);
                            bankType = AccountBankType.BocAccount;
                        }
                        index++;
                    }
                    else if (index <= maxcount)
                    {
                        tg = new TransferGlobal();
                        List<string> details = new List<string>();
                        if (bankType == AccountBankType.BocAccount)
                        {
                            details = AnalyseBarStyleData(data, new List<int> { 25, 58, 16, 14, 2, 32, 80, 60, 40, 1, 16, 16, 2, 5, 80, 100 });
                            if (details.Count < 16) { index++; continue; }
                            tg.SpotAccount = fileHeaders[2];
                            tg.PaymentCashType = DataConvertHelper.Instance.GetCashType(fileHeaders[6]);
                            tg.PayeeOpenBankType = AccountBankType.BocAccount;
                            tg.PayeeAccount = details[0];
                            tg.PayeeName = details[1];
                            tg.RemitAmount = string.IsNullOrEmpty(details[2]) ? "" : (double.Parse(details[2]) / 100).ToString();
                            tg.Province = DataConvertHelper.Instance.GetProvince(details[3]);
                            tg.CertifyPaperType = DataConvertHelper.Instance.GetAgentExpressCertifyPaperType(details[4]);
                            tg.CertifyPaperNo = details[5];
                            tg.AgentFunctionType_Express = DataConvertHelper.Instance.GetAgentExpressFunctionType(fileHeaders[5]);
                            tg.PayFeeAccount = fileHeaders[2];
                        }
                        else if (bankType == AccountBankType.OtherBankAccount)
                        {
                            details = AnalyseBarStyleData(data, new List<int> { 2, 40, 70, 16, 12, 140, 2, 1, 140, 16, 1, 1, 20, 16, 20, 16, 20, 16, 20, 140, 10, 140, 140, 140, 40, 140, 1, 3, 30, 1, 1, 6, 16, 6, 16, 1, 20, 35, 20, 20, 15 });
                            if (details.Count < 41) { index++; continue; }
                            tg.PaymentCashType = DataConvertHelper.Instance.GetCashType(fileHeaders[6]);
                            tg.PayeeAccount = details[1];
                            tg.PayeeName = details[2];
                            tg.RemitAmount = string.IsNullOrEmpty(details[3]) ? "" : (double.Parse(details[3]) / 100).ToString();
                            tg.PayeeOpenBankSwiftCode = details[4];
                            tg.PayeeOpenBankName = details[5];
                            tg.BarBusinessType = DataConvertHelper.Instance.GetBarBusinessType(details[6]);//业务种类
                            tg.BarApplyFlagType = DataConvertHelper.Instance.GetBarApplyFlagType(details[7]);//申报标示
                            tg.RemitNote = details[8];
                            tg.CustomerRef = details[9];
                            tg.PaymentType = "电汇";
                            tg.PayeeOpenBankType = AccountBankType.OtherBankAccount;
                            try
                            {
                                tg.SendPriority = DataConvertHelper.Instance.GetTransferChanelType((int.Parse(details[11]) - 1).ToString());
                            }
                            catch { }
                            tg.SpotAccount = details[12];
                            if (!string.IsNullOrEmpty(details[13].Trim()))
                                tg.SpotAmount = (double.Parse(details[13]) / 100).ToString();
                            tg.PurchaseAccount = details[14];
                            if (!string.IsNullOrEmpty(details[15].Trim()))
                                tg.PurchaseAmount = (double.Parse(details[15]) / 100).ToString();
                            tg.OtherAccount = details[16];
                            if (!string.IsNullOrEmpty(details[17].Trim()))
                                tg.OtherAmount = (double.Parse(details[17]) / 100).ToString();
                            tg.PayFeeAccount = !string.IsNullOrEmpty(tg.PurchaseAccount) ? tg.PurchaseAccount : tg.SpotAccount;
                            tg.RemitAddress = details[19];
                            tg.OrgCode = details[20];
                            tg.CorrespondentBankName = details[21];
                            tg.CorrespondentBankAddress = details[22];
                            tg.PayeeOpenBankAddress = details[23];
                            tg.PayeeAccountInCorrespondentBank = details[24];
                            tg.PayeeAddress = details[25];
                            tg.AssumeFeeType = DataConvertHelper.Instance.GetAssumeFeeType(details[26]);
                            tg.PayeeCodeofCountry = details[27];
                            tg.PayeeNameofCountry = details[28];
                            tg.PayFeeType = DataConvertHelper.Instance.GetPayFeeType(details[29]);
                            tg.PaymentPropertyType = DataConvertHelper.Instance.GetPaymentPropertyTypeBar(details[30]);
                            tg.DealSerialNoF = details[31];
                            if (!string.IsNullOrEmpty(details[32].Trim()))
                                tg.AmountF = (double.Parse(details[32]) / 100).ToString();
                            tg.DealSerialNoS = details[33];
                            if (!string.IsNullOrEmpty(details[34].Trim()))
                                tg.AmountS = (double.Parse(details[34]) / 100).ToString();
                            tg.IsPayOffLine = DataConvertHelper.Instance.GetIsPayOffLine(details[35]);
                            tg.ContactNo = details[36];
                            tg.BillSerialNo = details[37];
                            tg.BatchNoOrTNoOrSerialNo = details[38];
                            tg.ProposerName = details[39];
                            tg.Telephone = details[40];
                        }
                        else break;
                        list.Add(tg);

                    }
                    #endregion
                }
            }
            return list;
        }

        public List<object> GetAgentExpressBarBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            List<AgentExpress> list = new List<AgentExpress>();
            int index = 0;
            int maxcount = 0;
            BatchHeader bh = new BatchHeader();
            AgentExpress tg;
            List<string> fileHeaders = new List<string>();
            AgentTransferBankType bankType = AgentTransferBankType.Other;

            //templateType== AppliableFunctionType.TransferOverCountry4Bar

            //获取交易内容信息
            foreach (var data in contentData)
            {
                if (templateType == AppliableFunctionType.AgentExpressOut4Bar)
                {
                    if (index == 0)
                    {
                        fileHeaders = AnalyseBarStyleData(data, new List<int> { 2, 3, 25, 16, 12, 2, 3, 10, 50, 7, 1, 16, 25, 16, 32, 8, 32, 8, 32, 8, 32, 8, 24 });
                        //if ((bankType == AgentTransferBankType.Boc && fileHeaders[0] != "C1") || (bankType == AgentTransferBankType.Other && fileHeaders[0] != "C2")) break;
                        bh.BankType = fileHeaders[0] == "C1" ? AgentTransferBankType.Boc : AgentTransferBankType.Other;
                        bh.Payer.Account = fileHeaders[2];
                        maxcount = int.Parse(fileHeaders[4]);
                        index++;
                    }
                    else if (index <= maxcount)
                    {
                        tg = new AgentExpress();
                        List<string> details = AnalyseBarStyleData(data, new List<int> { 25, 58, 16, 14, 2, 32, 80, 60, 40, 1, 16, 16, 2, 5, 80, 100 });
                        if (details.Count < 16) { index++; continue; }
                        tg.AccountNo = details[0];
                        tg.AccountName = details[1];
                        try
                        {
                            tg.Amount = (double.Parse(details[2]) / 100).ToString("0.00");
                        }
                        catch { }
                        if (fileHeaders[0] == "C1")
                        {
                            tg.Province = DataConvertHelper.Instance.GetProvince(details[3]);
                            tg.CertifyPaperType = DataConvertHelper.Instance.GetAgentExpressCertifyPaperType(details[4]);
                        }
                        else if (fileHeaders[0] == "C2")
                        {
                            tg.BankNo = details[3];
                            tg.CertifyPaperType = AgentExpressCertifyPaperType.Empty;
                        }
                        tg.CertifyPaperNo = details[5];
                        if (!string.IsNullOrEmpty(details[12]))
                            tg.UsageType = DataConvertHelper.Instance.GetAgentExpressFunctionType(details[12]);
                        tg.BankName = details[14];
                        list.Add(tg);
                    }
                }
            }
            result.Add(bh);
            result.Add(list);

            return result;
        }

        public List<VirtualAccount> GetVirtualAccount(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            List<VirtualAccount> list = new List<VirtualAccount>();
            int maxcount = SystemSettings.Instance.BatchMappingSettings[templateType].MaxCountPerOperation;
            string[] s = new string[] { SystemSettings.Instance.BatchMappingSettings[templateType].SeperateChar };
            int count = 0;
            VirtualAccount ae;

            foreach (var data in contentData)
            {
                if (count > maxcount) break;

                ae = null;
                string[] strList = data.Split(s, StringSplitOptions.None);

                #region 笔信息
                ae = new VirtualAccount();
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ae.AccountOut = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        ae.NameOut = strList[1];
                    if (!string.IsNullOrEmpty(strList[2]))
                        ae.AccountIn = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ae.NameIn = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ae.CashType = CashType.CNY;
                    ae.Amount = DataConvertHelper.Instance.FormatNum(strList[5]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ae.Purpose = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        ae.CustomerBusinissNo = strList[7];
                }
                catch { ae.ErrorReason = "数据格式错误，转换失败"; }
                finally { if (null != ae) list.Add(ae); count++; }
                #endregion
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ae = null;
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);

                #region 笔信息
                ae = new VirtualAccount();
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ae.AccountOut = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        ae.NameOut = strList[1];
                    if (!string.IsNullOrEmpty(strList[2]))
                        ae.AccountIn = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ae.NameIn = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ae.CashType = CashType.CNY;
                    ae.Amount = DataConvertHelper.Instance.FormatNum(strList[5]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ae.Purpose = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        ae.CustomerBusinissNo = strList[7];
                }
                catch { ae.ErrorReason = "数据格式错误，转换失败"; }
                finally { if (null != ae) list.Add(ae); count++; }
                #endregion
            }
            result.Add(list);
            return list;
        }

        public List<VirtualAccount> GetVirtualAccountBOC(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            BatchHeader batch = new BatchHeader();
            List<VirtualAccount> list = new List<VirtualAccount>();

            int maxcount = CommonInformations.Instance.GetFunctionMaximum(templateType);
            string[] s = new string[] { SystemSettings.Instance.BOCSeparator };
            int count = 0;
            VirtualAccount ae;

            foreach (var data in contentData)
            {
                if (count > maxcount) break;

                ae = null;
                string[] strList = data.Split(s, StringSplitOptions.None);


                #region 笔信息
                ae = new VirtualAccount();
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ae.AccountOut = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        ae.NameOut = strList[1];
                    if (!string.IsNullOrEmpty(strList[2]))
                        ae.AccountIn = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ae.NameIn = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ae.CashType = CashType.CNY;
                    ae.Amount = DataConvertHelper.Instance.FormatNum(strList[5]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ae.Purpose = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        ae.CustomerBusinissNo = strList[7];
                }
                catch { ae.ErrorReason = "数据格式错误，转换失败"; }
                finally { if (null != ae) list.Add(ae); count++; }
                #endregion
            }

            if (list.Count == maxcount && contentData.Count > maxcount)
            {
                ae = null;
                string[] strList = contentData[maxcount].Split(s, StringSplitOptions.None);

                #region 笔信息
                ae = new VirtualAccount();
                try
                {
                    if (!string.IsNullOrEmpty(strList[0]))
                        ae.AccountOut = strList[0];
                    if (!string.IsNullOrEmpty(strList[1]))
                        ae.NameOut = strList[1];
                    if (!string.IsNullOrEmpty(strList[2]))
                        ae.AccountIn = strList[2];
                    if (!string.IsNullOrEmpty(strList[3]))
                        ae.NameIn = strList[3];
                    if (!string.IsNullOrEmpty(strList[4]))
                        ae.CashType = CashType.CNY;
                    ae.Amount = DataConvertHelper.Instance.FormatNum(strList[5]);
                    if (!string.IsNullOrEmpty(strList[6]))
                        ae.Purpose = strList[6];
                    if (!string.IsNullOrEmpty(strList[7]))
                        ae.CustomerBusinissNo = strList[7];
                }
                catch { ae.ErrorReason = "数据格式错误，转换失败"; }
                finally { if (null != ae) list.Add(ae); count++; }
                #endregion
            }

            result.Add(batch);
            result.Add(list);
            return list;
        }

        public List<VirtualAccount> GetVirtualAccountBOCErrorLog(List<string> contentData, AppliableFunctionType templateType)
        {
            List<object> result = new List<object>();
            BatchHeader batch = new BatchHeader();
            List<VirtualAccount> list = new List<VirtualAccount>();

            VirtualAccount ae;

            foreach (var data in contentData)
            {
                string[] strList = AnalyseBOCErrorCSVSytleData(data);

                #region 笔信息
                ae = new VirtualAccount();
                try
                {
                    ae.RowIndex = int.Parse(strList[0]);
                    ae.ErrorReason = strList[strList.Length - 1];
                    list.Add(ae);
                }
                catch { }
                #endregion
            }
            result.Add(batch);
            result.Add(list);
            return list;
        }


        private static string[] AnalyseBOCCSVSytleData(string data)
        {
            string temp = data.Replace("\t\"\t", "\t");
            if (temp.StartsWith("\"")) temp = temp.Substring(1, temp.Length - 1);
            if (temp.EndsWith("\t\"")) temp = temp.Substring(0, temp.Length - 2);
            temp = temp.Replace("\t\"", "\t");
            string[] strList = temp.Split(new string[] { "\t" }, StringSplitOptions.None);
            return strList;
        }

        private static string[] AnalyseBOCErrorCSVSytleData(string data)
        {
            string temp = data.Replace("\t\"\t", "\t");
            if (temp.StartsWith("\"")) temp = temp.Substring(1, temp.Length - 1);
            if (temp.EndsWith("\t\"")) temp = temp.Substring(0, temp.Length - 2);
            temp = temp.Replace("\t\"", "\t");
            string[] strList = temp.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
            return strList;
        }

        private List<string> AnalyseBarStyleData(string data, List<int> dataLengths)
        {
            List<string> list = new List<string>();
            int index = 0;
            for (int i = 0; i < dataLengths.Count; i++)
            {
                if (GetByteLength(data) <= index + dataLengths[i]) break;
                string item = string.Empty;
                list.Add(GetStringByBtyeLenght(data, index, dataLengths[i]).Trim());
                index += dataLengths[i];
            }
            return list;
        }
        #endregion

        private string GetStringByBtyeLenght(string data, int sindex, int length)
        {
            string result = string.Empty;
            try { result = Encoding.Default.GetString(Encoding.Default.GetBytes(data), sindex, length); }
            catch { }
            return result;
        }

        private int GetByteLength(string data)
        {
            int lenght = 0;
            if (!string.IsNullOrEmpty(data))
                lenght = Encoding.Default.GetBytes(data).Length;
            return lenght;
        }
    }
}
