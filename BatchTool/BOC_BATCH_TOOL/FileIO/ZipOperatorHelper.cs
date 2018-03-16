using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace BOC_BATCH_TOOL.FileIO
{
    public class ZipOperatorHelper
    {
        #region 单例
        private static object lock_obj = new object();
        private static ZipOperatorHelper m_instance;
        /// <summary>
        /// 单例
        /// </summary>
        public static ZipOperatorHelper Instance
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
                                m_instance = new ZipOperatorHelper();
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        /// <summary>
        /// 生成zip文件
        /// </summary>
        /// <param name="filepath"></param>
        public void ToZip(string filepath, string targetzip)
        {
            if (!File.Exists(filepath)) return;
            try
            {
                // 'using' statements guarantee the stream is closed properly which is a big source
                // of problems otherwise.  Its exception safe as well which is great.
                using (ZipOutputStream s = new ZipOutputStream(File.Create(targetzip)))
                {
                    s.UseZip64 = UseZip64.Off;
                    s.SetLevel(5); // 0 - store only to 9 - means best compression

                    byte[] buffer = new byte[4096];

                    // Using GetFileName makes the result compatible with XP
                    // as the resulting path is not absolute.
                    ZipEntry entry = new ZipEntry(Path.GetFileName(filepath));

                    // Setup the entry data as required.

                    // Crc and size are handled by the library for seakable streams
                    // so no need to do them here.

                    // Could also use the last write time or similar for the file.
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(filepath))
                    {
                        // Using a fixed size buffer here makes no noticeable difference for output
                        // but keeps a lid on memory usage.
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }

                    // Finish/Close arent needed strictly as the using statement does this automatically

                    // Finish is important to ensure trailing information for a Zip file is appended.  Without this
                    // the created file would be invalid.
                    s.Finish();

                    // Close is important to wrap things up and unlock the file.
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during processing {0}", ex);

                // No need to rethrow the exception as for our purposes its handled.
            }
        }

        /// <summary>
        /// 解压zip压缩文件
        /// </summary>
        /// <param name="filepath"></param>
        public List<string> UnZip(string filepath)
        {
            // 要解压的zip文件中的文件列表
            List<string> m_FileFullNameInZip = new List<string>();

            // Perform simple parameter checking.
            if (string.IsNullOrEmpty(filepath) || !File.Exists(filepath)) return m_FileFullNameInZip;

            m_FileFullNameInZip.Clear();

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(filepath)))
            {
                string baseDir = filepath.Substring(0, filepath.LastIndexOf(@"\"));

                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);

                    // create directory
                    if (directoryName.Length > 0) Directory.CreateDirectory(directoryName);
                    //空文件名
                    if (string.IsNullOrEmpty(fileName)) continue;

                    using (FileStream streamWriter = File.Create(Path.Combine(baseDir, theEntry.Name)))
                    {
                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                                streamWriter.Write(data, 0, size);
                            else
                                break;
                        }
                    }
                    m_FileFullNameInZip.Add(Path.Combine(baseDir, theEntry.Name));
                }
            }
            return m_FileFullNameInZip;
        }
    }
}
