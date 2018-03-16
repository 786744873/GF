using System;
namespace WindowsFormsApplication2.Test
{
    public class ExcelLib
    {
        /// <summary> 获取Excel对象 </summary>
        /// <param name="filePath">Excel文件路径</param>
        /// <returns></returns>
        public static IExcel GetExcel(string filePath)
        {
            if (filePath.Trim() == "")
                throw new Exception("文件名不能为空");

            if (!filePath.Trim().ToLower().EndsWith("xls") && !filePath.Trim().ToLower().EndsWith("xlsx"))
                throw new Exception("不支持该文件类型");

            if (filePath.Trim().EndsWith("xls"))
            {
                IExcel res = new Excel03(filePath.Trim());
                return res;
            }
            else if (filePath.Trim().EndsWith("xlsx"))
            {
                IExcel res = new Excel07(filePath.Trim());
                return res;
            }
            else return null;
        }
    }
}