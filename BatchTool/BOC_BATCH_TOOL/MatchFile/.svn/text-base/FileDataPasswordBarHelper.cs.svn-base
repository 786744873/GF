using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using CommonClient.SysCoach;
using System.Security.AccessControl;

namespace CommonClient.MatchFile
{
    public class FileDataPasswordBarHelper
    {
        //[System.Runtime.InteropServices.DllImport("kernel32")]
        //public extern static IntPtr LoadLibrary(string lpLibFileName);
        //[System.Runtime.InteropServices.DllImport("kernel32")]
        //public extern static bool FreeLibrary(IntPtr hLibModule);
        //[System.Runtime.InteropServices.DllImport("kernel32", CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        //public extern static IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        //[System.Runtime.InteropServices.DllImport("user32", EntryPoint = "CallWindowProc")]
        //public extern static int CallWindowProc(int lpPrevWndFunc, int hwnd, int MSG, int wParam, int lParam);

        //调用
        //int hmod=LoadLibrary("***.dll");
        //int pFname=GetProcAddress(hmod,"***");
        //CallWindowProc(pFname,0,0,0);
        //FreeLibrary(hmod);

        [System.Runtime.InteropServices.DllImport("BPS.dll")]
        public static extern int DecryptKey_ByFile(string infilename, string outfilename, int offset, string password);
        [System.Runtime.InteropServices.DllImport("BPS.dll")]
        public static extern int EncryptKey_ByFile(string infilename, string outfilename, int offset, string password);
        #region single
        private static object m_lock = new object();
        private static FileDataPasswordBarHelper m_instance;
        /// <summary>
        /// 实例
        /// </summary>
        public static FileDataPasswordBarHelper Instance
        {
            get
            {
                if (null == m_instance)
                {
                    lock (m_lock)
                    {
                        if (null == m_instance)
                        {
                            lock (m_lock)
                            {
                                m_instance = new FileDataPasswordBarHelper();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        public ResultData EncodeAndZip(string fromFile, string toFile, string password)
        {
            ResultData rd = new ResultData() { Result = true };

            // 压缩原始文件
            FileStream infile = new FileStream(fromFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] buffer = new byte[infile.Length];
            int count = infile.Read(buffer, 0, buffer.Length);
            if (count != buffer.Length) { rd = new ResultData { Result = false, Message = "读取原始文件失败" }; return rd; }
            infile.Close();

            string filezip = fromFile + ".ZIP";
            string filetmp = toFile + "TMP";

            try
            {
                if (File.Exists(filezip))
                    File.Delete(filezip);
                if (File.Exists(filetmp))
                    File.Delete(filetmp);
            }
            catch { }

            FileStream ms = new FileStream(filezip, FileMode.Create);
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
            compressedzipStream.Write(buffer, 0, buffer.Length);
            compressedzipStream.Close();
            byte[] t = new byte[5];
            t[0] = (byte)'$';
            //ms.Write(buffer, 0, count);
            ms.Write(t, 0, 1);
            ms.Close();

            // 加密文件02138973986
            int i = EncryptKey_ByFile(filezip, filetmp, 0, password);//返回-2？
            if (i != 0)
            {
                rd = new ResultData { Result = false, Message = "加密失败 " };
                return rd;
            }

            // 修改加密后的文件
            FileStream inDefile = new FileStream(filetmp, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream ouDefile = new FileStream(toFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
            byte[] Debuffer = new byte[inDefile.Length];
            int Decount = inDefile.Read(Debuffer, 0, Debuffer.Length);
            if (Decount != inDefile.Length) { rd = new ResultData { Result = false, Message = "读取加密后文件失败" }; return rd; }
            ouDefile.Write(buffer, 0, 374);
            ouDefile.Write(Debuffer, 0, Decount);

            inDefile.Close();
            ouDefile.Close();

            try
            {
                if (File.Exists(fromFile))
                    File.Delete(fromFile);
                if (File.Exists(filezip))
                    File.Delete(filezip);
                if (File.Exists(filetmp))
                    File.Delete(filetmp);
            }
            catch { }

            return rd;
        }

        public ResultData EncodeNoZip(string fromFile, string toFile, string password)
        {
            ResultData rd = new ResultData() { Result = true };
            int i = EncryptKey_ByFile(fromFile, toFile, 0, password);
            if (i != 0)
            {
                rd = new ResultData { Result = false, Message = "加密成功" };
            }
            return rd;
        }

        public ResultData DecodeAndUnzip(string fromFile, string toFile, string password)
        {
            ResultData rd = new ResultData { Result = true };

            string filename = fromFile.Substring(fromFile.LastIndexOf(@"\") + 1);

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\temp"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\temp");
            }
            string filetmpF = Path.Combine(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp"), filename + ".TMP");
            string filetmpT = Path.Combine(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp"), filename + ".TMP");
            string filezip = Path.Combine(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp"), filename + ".ZIP");

            try
            {
                if (File.Exists(filetmpF))
                    File.Delete(filetmpF);
                if (File.Exists(filetmpT))
                    File.Delete(filetmpT);//删除临时文件时异常，文件占用
                if (File.Exists(filezip))
                    File.Delete(filezip);
            }
            catch { }

            // 修改加密后的文件
            FileStream inDefile = new FileStream(fromFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream ouDefile = new FileStream(filetmpF, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
            byte[] Debuffer = new byte[inDefile.Length];
            int Decount = inDefile.Read(Debuffer, 0, Debuffer.Length);
            if (Decount != inDefile.Length) { rd = new ResultData { Result = false, Message = "读取加密后文件失败" }; }
            ouDefile.Write(Debuffer, 374, Decount - 374);

            inDefile.Close();
            ouDefile.Close();

            if (rd.Result)
            {
                // 解密文件
                int i = DecryptKey_ByFile(filetmpF, filetmpT, 0, password);
                if (i != 0)
                {
                    rd = new ResultData { Result = false, Message = "解密失败 " };
                }
            }

            if (rd.Result)
            {
                // 去掉'$'
                FileStream inZipfile = new FileStream(filetmpT, FileMode.Open, FileAccess.Read, FileShare.Read);
                FileStream ouZipfile = new FileStream(filezip, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
                try
                {
                    byte[] Zipbuffer = new byte[inZipfile.Length];
                    int zipCount = inZipfile.Read(Zipbuffer, 0, Zipbuffer.Length);
                    if (zipCount != inZipfile.Length) { rd = new ResultData { Result = false, Message = "读取加密后文件失败" }; return rd; }
                    int t;
                    for (t = zipCount - 1; t > 0; t--)
                    {
                        if (Zipbuffer[t] == '$')
                        {
                            break;
                        }
                    }
                    ouZipfile.Write(Zipbuffer, 0, t);
                }
                catch { rd = new ResultData { Result = false, Message = "读取加密后文件失败,请确认密码" }; }
                inZipfile.Close();
                ouZipfile.Close();
            }

            if (rd.Result)
            {
                // 解压文件
                FileStream oufile = new FileStream(filezip, FileMode.Open, FileAccess.Read, FileShare.Read);
                FileStream ms = new FileStream(toFile, FileMode.Create);
                GZipStream compressedzipStream = new GZipStream(oufile, CompressionMode.Decompress);
                try
                {
                    while (true)
                    {
                        byte[] out2 = new byte[128];
                        int bytesRead = compressedzipStream.Read(out2, 0, 128);
                        if (bytesRead == 0)
                        {
                            break;
                        }
                        ms.Write(out2, 0, bytesRead);
                    }
                }
                catch { rd = new ResultData { Result = false, Message = "文件解压失败,请确认密码" }; }

                compressedzipStream.Close();
                ms.Close();
                oufile.Close();
            }

            try
            {
                if (File.Exists(filetmpF))
                    File.Delete(filetmpF);
                if (File.Exists(filetmpT))
                    File.Delete(filetmpT);//删除临时文件时异常，文件占用
                if (File.Exists(filezip))
                    File.Delete(filezip);
            }
            catch { }

            return rd;
        }

        public ResultData DecodeNoUnzip(string fromFile, string toFile, string password)
        {
            ResultData rd = new ResultData { Result = true };
            int i = DecryptKey_ByFile(fromFile, toFile, 0, password);
            if (i != 0)
            {
                rd = new ResultData { Result = false, Message = "解密失败 " };
            }
            return rd;
        }
    }
}
