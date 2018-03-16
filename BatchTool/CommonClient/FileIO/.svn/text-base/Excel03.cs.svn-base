using NPOI.HSSF.UserModel;
using System.IO;
using System;

namespace WindowsFormsApplication2.Test
{
    public class Excel03 : IExcel
    {
        public Excel03()
        { }

        public Excel03(string path)
        { filePath = path; }

        private FileStream file = null;
        private string filePath = "";
        private HSSFWorkbook book = null;
        private int sheetCount = 0;
        private bool ifOpen = false;
        private int currentSheetIndex = 0;
        private HSSFSheet currentSheet = null;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public bool Open()
        {
            try
            {
                file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                book = new HSSFWorkbook(file);

                if (book == null) return false;
                sheetCount = book.NumberOfSheets;
                currentSheetIndex = 0;
                currentSheet = (HSSFSheet)book.GetSheetAt(0);
                ifOpen = true;
            }
            catch (Exception ex)
            {
                throw new Exception("打开文件失败，详细信息：" + ex.Message);
            }
            return true;
        }

        public void Close()
        {
            if (!ifOpen) return;
            file.Close();
        }

        public ExcelVersion Version
        { get { return ExcelVersion.Excel03; } }

        public bool IfOpen
        { get { return ifOpen; } }

        public int SheetCount
        { get { return sheetCount; } }

        public int CurrentSheetIndex
        {
            get { return currentSheetIndex; }
            set
            {
                if (value != currentSheetIndex)
                {
                    if (value >= sheetCount)
                        throw new Exception("工作表序号超出范围");
                    currentSheetIndex = value;
                    currentSheet = (HSSFSheet)book.GetSheetAt(currentSheetIndex);
                }
            }
        }

        public int GetRowCount()
        {
            if (currentSheet == null) return 0;
            return currentSheet.LastRowNum + 1;
        }

        public int GetColumnCount()
        {
            if (currentSheet == null) return 0;
            int colCount = 0;
            for (int i = 0; i <= currentSheet.LastRowNum; i++)
            {
                if (currentSheet.GetRow(i) != null && currentSheet.GetRow(i).LastCellNum + 1 > colCount)
                    colCount = currentSheet.GetRow(i).LastCellNum + 1;
            }
            return colCount;
        }

        public int GetCellCountInRow(int Row)
        {
            if (currentSheet == null) return 0;
            if (Row > currentSheet.LastRowNum) return 0;
            if (currentSheet.GetRow(Row) == null) return 0;

            return currentSheet.GetRow(Row).LastCellNum + 1;
        }

        public string GetCellValue(int Row, int Col)
        {
            if (Row > currentSheet.LastRowNum) return "";
            if (currentSheet.GetRow(Row) == null) return "";
            HSSFRow r = (HSSFRow)currentSheet.GetRow(Row);

            if (Col > r.LastCellNum) return "";
            if (r.GetCell(Col) == null) return "";
            string result = string.Empty;
            switch (r.GetCell(Col).CellType)
            {
                case NPOI.SS.UserModel.CellType.Blank:
                case NPOI.SS.UserModel.CellType.Error:
                case NPOI.SS.UserModel.CellType.Unknown:
                    result = string.Empty; break;
                case NPOI.SS.UserModel.CellType.Boolean:
                    result = (Convert.ToInt32(r.GetCell(Col).BooleanCellValue)).ToString(); break;
                case NPOI.SS.UserModel.CellType.Formula:
                    result = r.GetCell(Col).CellFormula; break;
                case NPOI.SS.UserModel.CellType.Numeric:
                    result = r.GetCell(Col).NumericCellValue.ToString(); break;
                case NPOI.SS.UserModel.CellType.String:
                    result = r.GetCell(Col).StringCellValue; break;
            }
            return result;
        }
    }
}