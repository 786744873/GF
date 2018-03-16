using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml;

namespace BOC_BATCH_TOOL.FileIO
{
    public class FileRWHelper
    {
        #region 单例
        private static object lock_obj = new object();
        private static FileRWHelper m_instance;
        /// <summary>
        /// 单一实例
        /// </summary>
        public static FileRWHelper Instance
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
                                m_instance = new FileRWHelper();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        /// <summary>
        /// 获取csv格式文件数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="startRowIndex"></param>
        /// <returns></returns>
        public List<string> GetCSVFieldsData(string filepath)
        {
            List<string> tempList = new List<string>();
            tempList.AddRange(File.ReadAllLines(filepath, GettxtEncoding(filepath)));
            return tempList;
        }

        /// <summary>
        /// 获取csv格式文件数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="startRowIndex"></param>
        /// <returns></returns>
        public List<List<string>> GetCSVFieldsData(string filepath, List<int> indexList, int maxcount, int startRowIndex)
        {
            List<List<string>> list = new List<List<string>>();

            int count = 0;
            List<string> tempList = GetCSVFieldsData(filepath);
            if (tempList.Count > 1)
            {
                tempList.RemoveAt(0);
                foreach (var data in tempList)
                {
                    if (count >= maxcount) break;
                    if (string.IsNullOrEmpty(data.Replace(",", ""))) continue;
                    string[] strList = data.Split(new string[] { "," }, StringSplitOptions.None);
                    List<string> obj = new List<string>();

                    //装载数据
                    foreach (int index in indexList)
                    {
                        if (index >= strList.Length) break;
                        obj.Add(strList[index].ToString());
                    }

                    list.Add(obj);
                    count++;
                }
            }

            return list;
        }

        /// <summary>
        /// 读取Excel文件数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="indexList"></param>
        /// <param name="maxcount"></param>
        /// <param name="startRowIndex"></param>
        /// <returns></returns>
        public List<List<string>> GetExcelFieldsData(string filepath, List<int> indexList, int maxcount, int startRowIndex)
        {
            List<List<string>> list = new List<List<string>>();
            List<string> strList;

            Excel.Application xlsApp = new Excel.ApplicationClass();
            Excel.Workbook wb;

            try
            {
                wb = xlsApp.Workbooks.Open(filepath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;

                int columncount = sheet.Cells.Columns.Count;
                for (int i = startRowIndex; i <= maxcount + startRowIndex - 1; i++)
                {
                    strList = new List<string>();
                    foreach (int index in indexList)
                        strList.Add(((Excel.Range)sheet.Cells[i, index + 1]).Formula.ToString());
                    if (strList.FindAll(o => !string.IsNullOrEmpty(o)).Count == 0) break;
                    list.Add(strList);
                }

                xlsApp.Visible = false;
                wb.Close();
                xlsApp.Quit();
                if (xlsApp != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
                    xlsApp = null;
                }
                GC.Collect(System.GC.GetGeneration(sheet));
                GC.Collect(System.GC.GetGeneration(wb));
                GC.Collect(System.GC.GetGeneration(xlsApp));
            }
            catch { }
            finally { GC.Collect(); }
            return list;
        }

        /// <summary>
        /// 获取txt文件数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="indexList"></param>
        /// <param name="separator"></param>
        /// <param name="maxcount"></param>
        /// <param name="startRowIndex"></param>
        /// <returns></returns>
        public List<List<string>> GetTXTFieldsData(string filepath, List<int> indexList, string separator, int maxcount, int startRowIndex)
        {
            List<List<string>> list = new List<List<string>>();

            int count = 1;
            using (StreamReader sr = File.OpenText(filepath))
            {
                while (count < startRowIndex)
                {
                    sr.ReadLine();
                    count++;
                }
                count = 0;
                while (count < maxcount)
                {
                    string data = sr.ReadLine();
                    if (string.IsNullOrEmpty(data.Replace(separator, ""))) break;
                    string[] strList = data.Split(new string[] { separator }, StringSplitOptions.None);
                    List<string> obj = new List<string>();

                    //装载数据
                    foreach (int index in indexList)
                        obj.Add(strList[index].ToString());

                    list.Add(obj);
                    count++;
                }
            }

            return list;
        }

        /// <summary>
        /// 获取Excel表头
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="rowindex"></param>
        /// <returns></returns>
        public List<string> GetFileExcelHeader(string filepath, int rowindex)
        {
            List<string> list = new List<string>();

            Excel.Application xlsApp = new Excel.ApplicationClass();
            Excel.Workbook wb;
            wb = xlsApp.Workbooks.Open(filepath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;

            int columncount = sheet.Cells.Columns.Count;
            for (int i = 1; i < columncount; i++)
            {
                if (string.IsNullOrEmpty(((Excel.Range)sheet.Cells[rowindex, i]).Text.ToString())) break;
                list.Add(((Excel.Range)sheet.Cells[rowindex, i]).Formula.ToString());
            }

            xlsApp.Visible = false;
            wb.Close();
            xlsApp.Quit();
            xlsApp = null;

            return list;
        }

        /// <summary>
        /// 获取TXT表头
        /// 任意编码格式
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="separator"></param>
        /// <param name="rowindex"></param>
        /// <returns></returns>
        public List<string> GetFileTXTHeader(string filepath, string separator, int rowindex)
        {
            List<string> list = new List<string>();
            try
            {
                List<string> allList = ReadTXTDocument(filepath);
                if (allList.Count > 0)
                    list.AddRange(allList[0].Split(new string[] { separator }, StringSplitOptions.None));
            }
            catch { }

            return list;
        }

        /// <summary>
        /// 获取TXT表头
        /// utf-8
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="separator"></param>
        /// <param name="rowindex"></param>
        /// <returns></returns>
        public List<string> GetFileTXTUTF8Header(string filepath, string separator, int rowindex)
        {
            List<string> list = new List<string>();
            int count = 1;
            using (StreamReader sr = File.OpenText(filepath))
            {
                while (count < rowindex) { sr.ReadLine(); break; }
                string data = sr.ReadLine();
                list.AddRange(data.Split(new string[] { separator }, StringSplitOptions.None));
            }

            return list;
        }

        /// <summary>
        /// 获取CSV表头
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="rowindex"></param>
        /// <returns></returns>
        public List<string> GetFileCSVHeader(string filepath, int rowindex)
        {
            List<string> list = new List<string>();
            List<string> tempList = new List<string>();
            tempList.AddRange(GetCSVFieldsData(filepath));
            if (tempList.Count > 0)
            {
                list.AddRange(tempList[0].Split(','));
            }
            return list;
        }

        /// <summary>
        /// 导出TXT文档
        /// </summary>
        /// <param name="header">文档头信息</param>
        /// <param name="content">文档内容</param>
        /// <param name="footer">文档尾信息</param>
        /// <returns></returns>
        public bool ExportTXTDocument(List<string> content, string filepath)
        {
            bool flag = false;

            try
            {
                File.WriteAllLines(filepath, content.ToArray(), Encoding.GetEncoding("GBK"));
            }
            catch { }

            return flag;
        }

        /// <summary>
        /// 读取中行文件格式TXT数据
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public List<string> ReadTXTDocument(string filepath)
        {
            List<string> list = new List<string>();
            try
            {
                Encoding encode = GettxtEncoding(filepath);
                list.AddRange(File.ReadAllLines(filepath, encode));
            }
            catch { }
            return list;
        }

        #region 本地数据操作
        public List<Dictionary<string, string>> ReadSingalxmlFile(string filepath)
        {
            if (!File.Exists(filepath)) throw new Exception("系统数据文件丢失！");
            XmlDocument doc = new XmlDocument();
            doc.Load(new XmlTextReader(filepath));
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            foreach (XmlNode node in doc.ChildNodes)
            {
                if (node.NodeType != XmlNodeType.Element) continue;
                foreach (XmlNode cn in node.ChildNodes)
                {
                    list.Add(ReaderElement(cn));
                }
            }
            return list;
        }

        public Dictionary<string, List<Dictionary<string, string>>> ReadTwicexmlFile(string filepath)
        {
            if (!File.Exists(filepath)) throw new Exception("系统数据文件丢失！");

            XmlDocument doc = new XmlDocument();
            doc.Load(new XmlTextReader(filepath));
            Dictionary<string, List<Dictionary<string, string>>> list = new Dictionary<string, List<Dictionary<string, string>>>();

            foreach (XmlNode node in doc.ChildNodes)
            {
                if (node.NodeType != XmlNodeType.Element) continue;
                foreach (XmlNode cn in node.ChildNodes)
                {
                    if (!list.ContainsKey(cn.Name)) list.Add(cn.Name, new List<Dictionary<string, string>>());
                    list[cn.Name].Add(ReaderTwiceElement(cn));
                }
            }
            return list;
        }

        public Dictionary<string, List<Dictionary<string, object>>> ReadMultixmlFile(string filepath)
        {
            if (!File.Exists(filepath)) throw new Exception("系统数据文件丢失！");

            XmlDocument doc = new XmlDocument();
            doc.Load(new XmlTextReader(filepath));
            Dictionary<string, List<Dictionary<string, object>>> list = new Dictionary<string, List<Dictionary<string, object>>>();

            foreach (XmlNode node in doc.ChildNodes)
            {
                if (node.NodeType != XmlNodeType.Element) continue;
                foreach (XmlNode cn in node.ChildNodes)
                {
                    if (!list.ContainsKey(cn.Name)) list.Add(cn.Name, new List<Dictionary<string, object>>());
                    list[cn.Name].Add(ReaderMultiDeepElement(cn));
                }
            }
            return list;
        }

        public Dictionary<string, List<Dictionary<string, List<string>>>> ReadSpecalxmlFile(string filepath)
        {
            if (!File.Exists(filepath)) throw new Exception("系统数据文件丢失！");

            XmlDocument doc = new XmlDocument();
            doc.Load(new XmlTextReader(filepath));
            Dictionary<string, List<Dictionary<string, List<string>>>> list = new Dictionary<string, List<Dictionary<string, List<string>>>>();

            foreach (XmlNode node in doc.ChildNodes)
            {
                if (node.NodeType != XmlNodeType.Element) continue;
                foreach (XmlNode cn in node.ChildNodes)
                {
                    if (!list.ContainsKey(cn.Name)) list.Add(cn.Name, new List<Dictionary<string, List<string>>>());
                    list[cn.Name].Add(ReaderSpecalDeepElement(cn));
                }
            }
            return list;
        }

        private Dictionary<string, string> ReaderElement(XmlNode node)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            if (!node.HasChildNodes) { list.Add(node.Name, ""); return list; }
            else
            {
                foreach (XmlNode n in node.ChildNodes)
                {
                    if (n is XmlText)
                        list.Add(n.ParentNode.Name, n.InnerText);
                    else if (n is XmlNode)
                        list.Add(n.Name, n.InnerText);
                }
            }
            return list;
        }

        private Dictionary<string, string> ReaderTwiceElement(XmlNode node)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            if (!node.HasChildNodes) return list;
            else
            {
                foreach (XmlNode n in node.ChildNodes)
                {
                    if (n is XmlText)
                        list.Add(n.ParentNode.Name, n.InnerText);
                    else if (n is XmlNode)
                        list.Add(n.Name, n.InnerText);
                }
            }
            return list;
        }

        private Dictionary<string, object> ReaderMultiDeepElement(XmlNode node)
        {
            Dictionary<string, object> list = new Dictionary<string, object>();
            if (!node.HasChildNodes) { list.Add(node.Name, node.Value); return list; }
            else
            {
                foreach (XmlNode n in node.ChildNodes)
                {
                    if (n.HasChildNodes)
                        list.Add(n.Name, ReaderMultiDeepElement(n));
                    else
                        list.Add(n.Name, n.InnerText as object);
                }
            }
            return list;
        }

        private Dictionary<string, List<string>> ReaderSpecalDeepElement(XmlNode node)
        {
            Dictionary<string, List<string>> list = new Dictionary<string, List<string>>();
            if (!node.HasChildNodes) { list.Add(node.Name, new List<string> { node.Value }); return list; }
            else
            {
                foreach (XmlNode n in node.ChildNodes)
                {
                    if (n.HasChildNodes)
                    {
                        if (!list.ContainsKey(n.Name))
                            list.Add(n.Name, new List<string>());
                        list[n.Name].Add(n.InnerText);
                    }
                }
            }
            return list;
        }
        #endregion

        /// <summary>
        /// 获取文件编码格式
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private Encoding GettxtEncoding(string filepath)
        {
            Encoding encode = Encoding.Default;
            using (System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (System.IO.BinaryReader br = new System.IO.BinaryReader(fs))
                {
                    Byte[] buffer = br.ReadBytes(2);
                    if (buffer.Length > 0)
                    {
                        if (buffer[0] >= 0xEF)
                        {
                            if (buffer[0] == 0xEF && buffer[1] == 0xBB)
                            {
                                encode = System.Text.Encoding.UTF8;
                            }
                            else if (buffer[0] == 0xFE) { encode = System.Text.Encoding.Unicode; }
                            else encode = System.Text.Encoding.Default;
                        }
                        else encode = System.Text.Encoding.Default;
                    }
                }
            }
            return encode;
        }
    }
}
