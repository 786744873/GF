using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.FileIO;
using System.IO;
using CommonClient.Entities;
using CommonClient.Types;
using System.Xml;

namespace CommonClient.MatchFile
{
    public static class UpdateFileHelper
    {
        internal static SysCoach.ResultData Update(EnumTypes.UpdateFleType uft, string filepath)
        {
            SysCoach.ResultData rd = new SysCoach.ResultData { Result = true };
            List<string> fileList = new List<string>();
            fileList = ZipOperatorHelper.UnZip(filepath);
            if (!Directory.Exists("Data")) 
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Data");
            try
            {
                switch (uft)
                {
                    case EnumTypes.UpdateFleType.BankLinkNo:
                        UpdateBankLinkCode(fileList, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\BankInfo.xml"));
                        break;
                    case EnumTypes.UpdateFleType.OpenBankInfo:
                        UpdateCNAPSCode(fileList, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\CNAPS.xml"));
                        break;
                    case EnumTypes.UpdateFleType.ClearBankInfo:
                        UpdateClearBankCode(fileList, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\CNAPSC.xml"));
                        break;
                    case EnumTypes.UpdateFleType.ElecTicket:
                        UpdateElecTicket(fileList, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\CNAPSET.xml"));
                        break;
                    default: rd = new SysCoach.ResultData { Result = false, Message = "未知上传文件业务类型" }; break;
                }
            }
            catch { rd = new SysCoach.ResultData { Result = false, Message = "未知上传文件业务类型,或数据格式有误" }; }

            try
            {
                foreach (var item in fileList)
                {
                    if (string.IsNullOrEmpty(item)) continue;
                    if (File.Exists(item))
                        File.Delete(item);
                }
            }
            catch { }

            return rd;
        }

        static void UpdateBankLinkCode(List<string> fileList, string targetfilename)
        {
            List<BankInfo> list = new List<BankInfo>();

            foreach (var item in fileList)
            {
                if (string.IsNullOrEmpty(item)) continue;
                if (!File.Exists(item)) continue;

                list.AddRange(GetBankInfo(item));
            }

            ReWriteDataFile(list, targetfilename);
        }

        static List<BankInfo> GetBankInfo(string filepath)
        {
            List<BankInfo> list = new List<BankInfo>();
            List<string> filedata = FileRWHelper.ReadCSVFieldsData(filepath);
            if (filedata.Count > 2)
            {
                filedata.RemoveAt(0);
                filedata.RemoveAt(0);
                foreach (var item in filedata)
                {
                    string temp = item.Replace(@"\t", "");
                    temp = temp.Replace("\"", "");
                    string[] result = temp.Split(',');

                    list.Add(new BankInfo { BankName = result[1].Trim(), LinkID = result[2].Trim() });
                }
            }
            return list;
        }

        static void UpdateCNAPSCode(List<string> fileList, string targetfilename)
        {
            List<CNAP> list = new List<CNAP>();

            foreach (var item in fileList)
            {
                if (string.IsNullOrEmpty(item)) continue;
                if (!File.Exists(item)) continue;

                list.AddRange(GetCNAPS(item));
            }

            ReWriteDataFile(list, targetfilename);
        }

        static void UpdateClearBankCode(List<string> fileList, string targetfilename)
        {
            List<CNAP> list = new List<CNAP>();

            foreach (var item in fileList)
            {
                if (string.IsNullOrEmpty(item)) continue;
                if (!File.Exists(item)) continue;

                list.AddRange(GetCNAPS(item));
            }

            ReWriteDataFile(list, targetfilename);
        }

        static void UpdateElecTicket(List<string> fileList, string targetfilename)
        {
            List<CNAP> list = new List<CNAP>();

            foreach (var item in fileList)
            {
                if (string.IsNullOrEmpty(item)) continue;
                if (!File.Exists(item)) continue;

                list.AddRange(GetCNAPS(item));
            }

            ReWriteDataFile(list, targetfilename);
        }

        static List<CNAP> GetCNAPS(string filepath)
        {
            List<CNAP> list = new List<CNAP>();
            List<string> filedata = FileRWHelper.ReadCSVFieldsData(filepath);
            if (filedata.Count > 2)
            {
                filedata.RemoveAt(0);
                filedata.RemoveAt(0);
                foreach (var item in filedata)
                {
                    string temp = item.Replace(@"\t", "");
                    temp = temp.Replace("\"", "");
                    string[] result = temp.Split(',');

                    list.Add(new CNAP { Code = result[0].Trim(), Name = result[1].Trim() });
                }
            }
            return list;
        }

        static void ReWriteDataFile(List<BankInfo> list, string filepath)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declar = doc.CreateXmlDeclaration("1.0", "utf-8", "");
            doc.AppendChild(declar);
            XmlNode pnode = doc.CreateNode(XmlNodeType.Element, "BankInfos", "");

            XmlNode node;
            foreach (var item in list)
            {
                node = doc.CreateNode(XmlNodeType.Element, "BankInfo", "");

                XmlNode namenode = doc.CreateNode(XmlNodeType.Element, "BankName", "");
                namenode.InnerText = item.BankName;
                node.AppendChild(namenode);

                XmlNode codenode = doc.CreateNode(XmlNodeType.Element, "LinkID", "");
                codenode.InnerText = item.LinkID;
                node.AppendChild(codenode);

                pnode.AppendChild(node);
            }

            doc.AppendChild(pnode);
            doc.Save(filepath);
        }

        static void ReWriteDataFile(List<CNAP> list, string filepath)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declar = doc.CreateXmlDeclaration("1.0", "utf-8", "");
            doc.AppendChild(declar);
            XmlNode pnode = doc.CreateNode(XmlNodeType.Element, "CNAPS", "");

            XmlNode node;
            foreach (var item in list)
            {
                node = doc.CreateNode(XmlNodeType.Element, "CNAP", "");

                XmlNode codenode = doc.CreateNode(XmlNodeType.Element, "CODE", "");
                codenode.InnerText = item.Code;
                node.AppendChild(codenode);

                XmlNode namenode = doc.CreateNode(XmlNodeType.Element, "NAME", "");
                namenode.InnerText = item.Name;
                node.AppendChild(namenode);

                pnode.AppendChild(node);
            }

            doc.AppendChild(pnode);
            doc.Save(filepath);
        }
    }
}
