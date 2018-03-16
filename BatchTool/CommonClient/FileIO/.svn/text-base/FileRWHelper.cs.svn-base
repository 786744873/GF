using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Xml;
using WindowsFormsApplication2.Test;

namespace CommonClient.FileIO
{
    public static class FileRWHelper
    {
        /// <summary>
        /// 获取csv格式文件数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="startRowIndex"></param>
        /// <returns></returns>
        public static List<string> ReadCSVFieldsData(string filepath)
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
        public static List<List<string>> GetCSVFieldsData(string filepath, List<int> indexList, int maxcount, int startRowIndex, int endRowIndex = 65535)
        {
            List<List<string>> list = new List<List<string>>();

            int count = 0;
            List<string> tempList = ReadCSVFieldsData(filepath);
            if (tempList.Count > startRowIndex)
            {
                while (tempList.Count > endRowIndex)
                    tempList.RemoveAt(endRowIndex);
                while (count < startRowIndex - 1)
                {
                    tempList.RemoveAt(0);
                    count++;
                }
                count = 0;
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
                        obj.Add(FilterWhiteChars(strList[index].ToString()));
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
        public static List<List<string>> GetExcelFieldsData(string filepath, List<int> indexList, int maxcount, int startRowIndex, int endRowIndex = 65535)
        {
            List<List<string>> list = new List<List<string>>();
            List<string> strList;

            IExcel tmp = ExcelLib.GetExcel(filepath);
            if (tmp == null) return list;
            try
            {
                if (!tmp.Open()) return list;
                tmp.CurrentSheetIndex = 0;
                int columncount = tmp.GetColumnCount();
                if (maxcount == int.MaxValue) maxcount -= startRowIndex;
                for (int i = startRowIndex - 1; i <= maxcount + startRowIndex - 1 && i <= endRowIndex; i++)
                {
                    strList = new List<string>();
                    foreach (int index in indexList)
                        strList.Add(FilterWhiteChars(tmp.GetCellValue(i, index)));
                    if (strList.FindAll(o => !string.IsNullOrEmpty(o)).Count == 0) break;
                    list.Add(strList);
                }
                tmp.Close();
                Console.ReadLine();
            }
            catch (Exception ex) { }

            #region
            //Excel.Application xlsApp = new Excel.ApplicationClass();
            //Excel.Workbook wb;
            //IExcel tmp = ExcelLib.GetExcel(filepath);

            //try
            //{
            //wb = xlsApp.Workbooks.Open(filepath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;

            //int columncount = sheet.Cells.Columns.Count;
            //if (maxcount == int.MaxValue) maxcount -= startRowIndex;
            //for (int i = startRowIndex; i <= maxcount + startRowIndex - 1 && i <= endRowIndex; i++)
            //{
            //    strList = new List<string>();
            //    foreach (int index in indexList)
            //        strList.Add(((Excel.Range)sheet.Cells[i, index + 1]).Formula.ToString().Trim());
            //    //strList.Add(tmp.GetCellValue(i, index).Trim());
            //    if (strList.FindAll(o => !string.IsNullOrEmpty(o)).Count == 0) break;
            //    list.Add(strList);
            //}

            //xlsApp.Visible = false;
            //wb.Close();
            //xlsApp.Quit();
            //if (xlsApp != null)
            //{
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
            //}
            //GC.Collect(System.GC.GetGeneration(sheet));
            //GC.Collect(System.GC.GetGeneration(wb));
            //GC.Collect(System.GC.GetGeneration(xlsApp));

            //tmp.Close();
            //}
            //catch { }
            //finally { GC.Collect(); }
            #endregion
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
        //public static List<string> ReadExcelFieldsData(string filepath, int maxcount, int startRowIndex, int endRowIndex = 65535)
        //{
        //    List<string> strList = new List<string>();

        //    //Excel.Application xlsApp = new Excel.ApplicationClass();
        //    //Excel.Workbook wb;
        //    IExcel tmp = ExcelLib.GetExcel(filepath);

        //    try
        //    {
        //        //wb = xlsApp.Workbooks.Open(filepath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //        //Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;
        //        tmp.CurrentSheetIndex = 0;
        //        int columncount = tmp.GetColumnCount(); //sheet.Cells.Columns.Count;
        //        for (int i = startRowIndex; i <= maxcount + startRowIndex - 1 && i <= endRowIndex; i++)
        //        {
        //            StringBuilder temp = new StringBuilder();
        //            for (int j = 1; j < columncount; j++)
        //            {
        //                //if (string.IsNullOrEmpty(((Excel.Range)sheet.Cells[i, j]).Text.ToString())) break;
        //                //temp.Append(((Excel.Range)sheet.Cells[i, j]).Formula.ToString() + SysCoach.SystemSettings.BOCSeparator);
        //                strList.Add(tmp.GetCellValue(i, j).Trim());
        //            }
        //            strList.Add(temp.ToString());
        //        }

        //        //xlsApp.Visible = false;
        //        //wb.Close();
        //        //xlsApp.Quit();
        //        //if (xlsApp != null)
        //        //{
        //        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
        //        //    xlsApp = null;
        //        //}
        //        //GC.Collect(System.GC.GetGeneration(sheet));
        //        //GC.Collect(System.GC.GetGeneration(wb));
        //        //GC.Collect(System.GC.GetGeneration(xlsApp));
        //        tmp.Close();
        //    }
        //    catch { }
        //    finally { GC.Collect(); }
        //    return strList;
        //}

        /// <summary>
        /// 获取txt文件数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="indexList"></param>
        /// <param name="separator"></param>
        /// <param name="maxcount"></param>
        /// <param name="startRowIndex"></param>
        /// <returns></returns>
        public static List<List<string>> GetTXTFieldsData(string filepath, List<int> indexList, string separator, int maxcount, int startRowIndex, int endRowIndex = 65535)
        {
            List<List<string>> list = new List<List<string>>();

            int count = 1;

            List<string> templist = ReadTXTDocument(filepath);
            if (templist.Count > startRowIndex)
            {
                while (count < startRowIndex)
                {
                    templist.RemoveAt(0);
                    count++;
                }
                count = 0;
                while (count < maxcount && count < endRowIndex)
                {
                    if (templist.Count <= count || string.IsNullOrEmpty(templist[count]) || string.IsNullOrEmpty(templist[count].Replace(separator, ""))) break;
                    string[] strList = templist[count].Split(new string[] { separator }, StringSplitOptions.None);
                    List<string> obj = new List<string>();

                    //装载数据
                    foreach (int index in indexList)
                        obj.Add(FilterWhiteChars(strList[index].ToString()));

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
        public static List<string> GetFileExcelHeader(string filepath, int rowindex)
        {
            List<string> list = new List<string>();

            //Excel.Application xlsApp = new Excel.ApplicationClass();
            //Excel.Workbook wb;
            //wb = xlsApp.Workbooks.Open(filepath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;
            IExcel tmp = ExcelLib.GetExcel(filepath);
            if (!tmp.Open()) return list;
            tmp.CurrentSheetIndex = 0;
            int columncount = tmp.GetColumnCount();
            for (int i = 0; i < columncount; i++)
            {
                //if (string.IsNullOrEmpty(((Excel.Range)sheet.Cells[rowindex, i]).Text.ToString())) break;
                //list.Add(((Excel.Range)sheet.Cells[rowindex, i]).Formula.ToString());

                if (string.IsNullOrEmpty(tmp.GetCellValue(rowindex - 1, i))) break;
                list.Add(tmp.GetCellValue(rowindex - 1, i).Trim());
            }

            //xlsApp.Visible = false;
            //wb.Close();
            //xlsApp.Quit();
            //xlsApp = null;
            tmp.Close();

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
        public static List<string> GetFileTXTHeader(string filepath, string separator, int rowindex)
        {
            List<string> list = new List<string>();
            try
            {
                List<string> allList = ReadTXTDocument(filepath);
                if (allList.Count > 0 && allList.Count >= rowindex)
                    list.AddRange(allList[rowindex - 1].Split(new string[] { separator }, StringSplitOptions.None));
                list = list.FindAll(o => !string.IsNullOrEmpty(o));
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
        public static List<string> GetFileTXTUTF8Header(string filepath, string separator, int rowindex)
        {
            List<string> list = new List<string>();
            int count = 1;
            using (StreamReader sr = File.OpenText(filepath))
            {
                while (count < rowindex) { sr.ReadLine(); break; }
                string data = sr.ReadLine();
                list.AddRange(data.Split(new string[] { separator }, StringSplitOptions.None));
                list = list.FindAll(o => !string.IsNullOrEmpty(o));
            }

            return list;
        }

        /// <summary>
        /// 获取CSV表头
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="rowindex"></param>
        /// <returns></returns>
        public static List<string> GetFileCSVHeader(string filepath, int rowindex)
        {
            List<string> list = new List<string>();
            List<string> tempList = new List<string>();
            tempList.AddRange(ReadCSVFieldsData(filepath));
            if (tempList.Count > 0 && tempList.Count >= rowindex)
                list.AddRange(tempList[rowindex - 1].Split(','));
            list = list.FindAll(o => !string.IsNullOrEmpty(o));
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="separactor"></param>
        /// <returns></returns>
        public static List<List<string>> GetFileBOCAllData(string filepath, string separactor)
        {
            List<List<string>> list = new List<List<string>>();

            List<string> tempL = new List<string>();
            if (filepath.EndsWith(".csv")) tempL = ReadCSVFieldsData(filepath);
            else if (filepath.EndsWith(".txt")) tempL = ReadTXTDocument(filepath);

            int newblockIndex = 0;
            int index = 0;
            foreach (var item in tempL)
            {
                if (string.IsNullOrEmpty(item)) { list.Add(new List<string> { string.Empty }); newblockIndex = ++index; continue; }
                List<string> tl = new List<string>();
                if (list.Count >= newblockIndex + 7 && separactor.Equals(","))
                {
                    string ts = "\",\"";
                    string[] tsl = item.Split(new string[] { ts }, StringSplitOptions.None);
                    for (int i = 0; i < tsl.Length; i++)
                    {
                        if (string.IsNullOrEmpty(tsl[i].Trim())) tsl[i] = "\"" + tsl[i] + "\"";
                        else
                        {
                            if (!tsl[i].StartsWith("\"")) tsl[i] = "\"" + tsl[i];
                            if (!tsl[i].EndsWith("\"")) tsl[i] = tsl[i] + "\"";
                        }
                    }
                    tl.AddRange(tsl);
                }
                else
                    tl.AddRange(item.Split(new string[] { separactor }, StringSplitOptions.None));
                list.Add(tl);
                index++;
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
        public static bool ExportTXTDocument(List<string> content, string filepath)
        {
            bool flag = false;

            try
            {
                File.WriteAllLines(filepath, content.ToArray(), Encoding.GetEncoding("GBK"));
                flag = true;
            }
            catch { }

            return flag;
        }

        /// <summary>
        /// 读取中行文件格式TXT数据
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public static List<string> ReadTXTDocument(string filepath)
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

        /// <summary>
        /// 导出DIF文档
        /// </summary>
        /// <param name="header">文档头信息</param>
        /// <param name="content">文档内容</param>
        /// <param name="footer">文档尾信息</param>
        /// <returns></returns>
        public static bool ExportDIFDocument(List<string> content, string filepath)
        {
            bool flag = false;

            try
            {
                File.WriteAllLines(filepath, content.ToArray(), Encoding.GetEncoding("GBK"));
            }
            catch { }

            return flag;
        }

        public static List<string> ReadDIFDocumnet(string filepath)
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

        public static bool ExportDATDocument(List<string> content, string filepath)
        {
            bool flag = false;

            try
            {
                File.WriteAllLines(filepath, content.ToArray(), Encoding.GetEncoding("GBK"));
                flag = true;
            }
            catch { }

            return flag;
        }

        public static List<string> ReadDATDocument(string filepath)
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

        public static bool ExportBOCDocument(List<string> content, string originalFilepath, string filepath)
        {
            bool flag = false;

            try
            {
                File.WriteAllLines(filepath, content.ToArray(), GettxtEncoding(originalFilepath));
                flag = true;
            }
            catch { }

            return flag;
        }

        #region 本地数据操作
        public static List<Dictionary<string, string>> ReadSingalxmlFile(string filepath)
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

        public static Dictionary<string, List<Dictionary<string, string>>> ReadTwicexmlFile(string filepath)
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

        public static Dictionary<string, List<Dictionary<string, object>>> ReadMultixmlFile(string filepath)
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

        public static Dictionary<string, List<Dictionary<string, List<string>>>> ReadSpecalxmlFile(string filepath)
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

        private static Dictionary<string, string> ReaderElement(XmlNode node)
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

        private static Dictionary<string, string> ReaderTwiceElement(XmlNode node)
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

        private static Dictionary<string, object> ReaderMultiDeepElement(XmlNode node)
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

        private static Dictionary<string, List<string>> ReaderSpecalDeepElement(XmlNode node)
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

        private static string GetFileInnerXml(string filepath)
        {
            string innerxml = string.Empty;
            if (!File.Exists(filepath)) return innerxml;

            List<byte> dataList = new List<byte>();
            using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] buffer = new byte[0x1000];
                int length = 0;
                while ((length = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    List<byte> temp = new List<byte>();
                    temp.AddRange(buffer);
                    dataList.AddRange(temp.GetRange(0, length));
                }
            }
            innerxml = System.Text.Encoding.UTF8.GetString(dataList.ToArray(), 0, dataList.Count);

            return innerxml;
        }
        #endregion

        /// <summary>
        /// 获取文件编码格式
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private static Encoding GettxtEncoding(string filepath)
        {
            Encoding encode = Encoding.Default;
            using (System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
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
            return encode;
        }

        private static string FilterWhiteChars(string data)
        {
            if (!string.IsNullOrEmpty(data))
                SysCoach.SystemSettings.FilterChars.ForEach(o => data = !string.IsNullOrEmpty(data) ? data.Replace(o, string.Empty) : string.Empty);
            else data = string.Empty;
            return data;
        }
    }
}
