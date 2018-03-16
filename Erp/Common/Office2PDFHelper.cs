using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Diagnostics;
using System.Web;
using Microsoft.Office.Interop.Word;
using System.IO;
using iTextSharp.text.pdf;

namespace CommonService.Common
{
    /// <summary>
    /// Office2Pdf 将Office文档转化为pdf
    /// </summary>
    public class Office2PDFHelper : System.Web.UI.Page
    {
        public Office2PDFHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 文件格式转换
        /// </summary>
        /// <param name="type">文件类型</param>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        public void FileFormatConversion(string type, string sourcePath, string targetPath)
        {
            int index = targetPath.LastIndexOf("\\");
            string fileUrl = targetPath.Substring(0, index);
            if (Directory.Exists(fileUrl) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(fileUrl);
            }
            switch (type)
            {
                case "docx":
                    if (DOCConvertToPDF(sourcePath, targetPath))
                    {
                        string docxPathSwf = targetPath.Substring(0, targetPath.Length - 3) + "swf";
                        pdf2swf(targetPath, docxPathSwf);
                    }
                    break;
                case "doc":
                    if (DOCConvertToPDF(sourcePath, targetPath))
                    {
                        string docPathSwf = targetPath.Substring(0, targetPath.Length - 3) + "swf";
                        pdf2swf(targetPath, docPathSwf);
                    }
                    break;
                case "xlsx":
                    if (XLSConvertToPDF(sourcePath, targetPath))
                    {
                        string xlsxPathSwf = targetPath.Substring(0, targetPath.Length - 3) + "swf";
                        pdf2swf(targetPath, xlsxPathSwf);
                    }
                    break;
                case "xls":
                    if (XLSConvertToPDF(sourcePath, targetPath))
                    {
                        string xlsxPathSwf = targetPath.Substring(0, targetPath.Length - 3) + "swf";
                        pdf2swf(targetPath, xlsxPathSwf);
                    }
                    break;
                case "ppt":
                    if (PPTConvertToPDF(sourcePath, targetPath))
                    {
                        string pptPathSwf = targetPath.Substring(0, targetPath.Length - 3) + "swf";
                        pdf2swf(targetPath, pptPathSwf);
                    }
                    break;
                case "pptx":
                    if (PPTConvertToPDF(sourcePath, targetPath))
                    {
                        string pptPathSwf = targetPath.Substring(0, targetPath.Length - 3) + "swf";
                        pdf2swf(targetPath, pptPathSwf);
                    }
                    break;
                case "pps":
                    if (PPTConvertToPDF(sourcePath, targetPath))
                    {
                        string pptPathSwf = targetPath.Substring(0, targetPath.Length - 3) + "swf";
                        pdf2swf(targetPath, pptPathSwf);
                    }
                    break;
                case "ppsx":
                    if (PPTConvertToPDF(sourcePath, targetPath))
                    {
                        string pptPathSwf = targetPath.Substring(0, targetPath.Length - 3) + "swf";
                        pdf2swf(targetPath, pptPathSwf);
                    }
                    break;
                case "pdf":
                    string pdfPathSwf = targetPath.Substring(0, targetPath.Length - 3) + "swf";
                    pdf2swf(sourcePath, pdfPathSwf);
                    break;
                case "jpg":
                    if (ConvertJPG2PDF(sourcePath, targetPath))
                    {
                        string jpgPathSwf = targetPath.Substring(0, targetPath.Length - 3) + "swf";
                        pdf2swf(targetPath, jpgPathSwf);
                    }
                    break;
                case "png":
                    if (ConvertJPG2PDF(sourcePath, targetPath))
                    {
                        string pngPathSwf = targetPath.Substring(0, targetPath.Length - 3) + "swf";
                        pdf2swf(targetPath, pngPathSwf);
                    }
                    break;
                case "gif":
                    if (ConvertJPG2PDF(sourcePath, targetPath))
                    {
                        string gifPathSwf = targetPath.Substring(0, targetPath.Length - 3) + "swf";
                        pdf2swf(targetPath, gifPathSwf);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Word转换成pdf
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        public static bool DOCConvertToPDF(string sourcePath, string targetPath)
        {
            bool result = false;
            Word.WdExportFormat exportFormat = Word.WdExportFormat.wdExportFormatPDF;
            object paramMissing = Type.Missing;
            Word.ApplicationClass wordApplication = new Word.ApplicationClass();
            Word.Document wordDocument = null;
            try
            {
                object paramSourceDocPath = sourcePath;
                string paramExportFilePath = targetPath;
                Word.WdExportFormat paramExportFormat = exportFormat;
                bool paramOpenAfterExport = false;
                Word.WdExportOptimizeFor paramExportOptimizeFor = Word.WdExportOptimizeFor.wdExportOptimizeForPrint;
                Word.WdExportRange paramExportRange = Word.WdExportRange.wdExportAllDocument;
                int paramStartPage = 0;
                int paramEndPage = 0;
                Word.WdExportItem paramExportItem = Word.WdExportItem.wdExportDocumentContent;
                bool paramIncludeDocProps = true;
                bool paramKeepIRM = true;
                Word.WdExportCreateBookmarks paramCreateBookmarks = Word.WdExportCreateBookmarks.wdExportCreateWordBookmarks;
                bool paramDocStructureTags = true;
                bool paramBitmapMissingFonts = true;
                bool paramUseISO19005_1 = false;
                wordDocument = wordApplication.Documents.Open(
                ref paramSourceDocPath, ref paramMissing, ref paramMissing,
                ref paramMissing, ref paramMissing, ref paramMissing,
                ref paramMissing, ref paramMissing, ref paramMissing,
                ref paramMissing, ref paramMissing, ref paramMissing,
                ref paramMissing, ref paramMissing, ref paramMissing,
                ref paramMissing);
                if (wordDocument != null)
                    wordDocument.ExportAsFixedFormat(paramExportFilePath,
                    paramExportFormat, paramOpenAfterExport,
                    paramExportOptimizeFor, paramExportRange, paramStartPage,
                    paramEndPage, paramExportItem, paramIncludeDocProps,
                    paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
                    paramBitmapMissingFonts, paramUseISO19005_1,
                    ref paramMissing);
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (wordDocument != null)
                {
                    wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordDocument = null;
                }
                if (wordApplication != null)
                {
                    wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordApplication = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return result;
        }

        /// <summary>
        /// 把Excel文件转换成PDF格式文件 
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        public static bool XLSConvertToPDF(string sourcePath, string targetPath)
        {
            bool result = false;
            Microsoft.Office.Interop.Excel.XlFixedFormatType targetType = Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF;
            object missing = Type.Missing;
            Microsoft.Office.Interop.Excel.ApplicationClass application = null;
            Microsoft.Office.Interop.Excel.Workbook workBook = null;
            try
            {
                application = new Microsoft.Office.Interop.Excel.ApplicationClass();
                object target = targetPath;
                object type = targetType;
                workBook = application.Workbooks.Open(sourcePath, missing, missing, missing, missing, missing,
                missing, missing, missing, missing, missing, missing, missing, missing, missing);
                workBook.ExportAsFixedFormat(targetType, target, Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, true, false, missing, missing, missing, missing);
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.Close(true, missing, missing);
                    workBook = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return result;
        }
        ///<summary>       
        /// 把PowerPoint文件转换成PDF格式文件      
        ///</summary>       
        ///<param name="sourcePath">源文件路径</param>    
        ///<param name="targetPath">目标文件路径</param>
        ///<returns>true=转换成功</returns>
        public static bool PPTConvertToPDF(string sourcePath, string targetPath)
        {
            bool result;
            PowerPoint.PpSaveAsFileType targetFileType = PowerPoint.PpSaveAsFileType.ppSaveAsPDF;
            object missing = Type.Missing;
            PowerPoint.ApplicationClass application = null;
            PowerPoint.Presentation persentation = null;
            try
            {
                application = new PowerPoint.ApplicationClass();
                persentation = application.Presentations.Open(sourcePath, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
                persentation.SaveAs(targetPath, targetFileType, MsoTriState.msoTrue);
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (persentation != null)
                {
                    persentation.Close();
                    persentation = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return result;
        }
        /// <summary>
        /// 把图片文件转换成PDF格式文件
        /// </summary>
        /// <param name="jpgfile">源文件路径</param>
        /// <param name="pdf">目标文件路径</param>
        /// <returns></returns>
        public static bool ConvertJPG2PDF(string jpgfile, string pdf)
        {
            try
            {
                var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);

                using (var stream = new FileStream(pdf, FileMode.Create, FileAccess.Write, FileShare.None))
                {

                    PdfWriter.GetInstance(document, stream);

                    document.Open();

                    using (var imageStream = new FileStream(jpgfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {

                        var image = iTextSharp.text.Image.GetInstance(imageStream);

                        if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                        {

                            image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);

                        }

                        else if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                        {

                            image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);

                        }

                        image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;

                        document.Add(image);

                    }
                    document.Close();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// pdf转swf
        /// </summary>
        /// <param name="pdfpath">pdf地址</param>
        /// <param name="swfpath">转换后地址</param>
        /// <returns></returns>
        public static bool pdf2swf(string pdfpath, string swfpath)
        {
            try
            {
                using (Process p = new Process())
                {
                    string cmdStr = HttpContext.Current.Server.MapPath("../../flex/pdf2swf.exe");
                    
                    //string savePath = HttpContext.Current.Server.MapPath("SWF/");
                    // @"""" 相当于一个双引号，之所以要加@"""" 就是为了防止要转换的过程中，文件夹名字带有空格，导致失败
                    string sourcePath = @"""" + pdfpath + @"""";
                    string targetPath = @"""" + swfpath + @"""";
                    string argsStr = "  -t " + sourcePath + " -s flashversion=9 -o " + targetPath;
                    //调用新进程 进行转换
                    ProcessStartInfo psi = new ProcessStartInfo(cmdStr, argsStr);
                    p.StartInfo = psi;
                    p.Start();
                    p.WaitForExit();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
