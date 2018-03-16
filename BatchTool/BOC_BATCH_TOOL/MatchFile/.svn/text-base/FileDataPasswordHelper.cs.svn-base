using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using CommonClient.SysCoach;
using System.Security.Cryptography;
using CommonClient.FileIO;

namespace CommonClient.MatchFile
{
    public class FileDataPasswordHelper
    {
        #region
        static object lock_obj = new object();
        static FileDataPasswordHelper m_instance;
        /// <summary>
        /// 单例
        /// </summary>
        public static FileDataPasswordHelper Instance
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
                                m_instance = new FileDataPasswordHelper();
                            }
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        #region 加密
        static RandomNumberGenerator rand = new RNGCryptoServiceProvider();

        public ResultData MakeToPWD(string filepath, string pwd)
        {
            ResultData rd = new ResultData();
            try
            {
                int startindex = filepath.LastIndexOf(".");
                string targetzip = filepath.Substring(0, startindex) + ".zip";

                ZipOperatorHelper.Instance.ToZip(filepath, targetzip);

                if (File.Exists(filepath))
                    File.Delete(filepath);

                MakePWDFile(targetzip, pwd);

                if (File.Exists(targetzip))
                    File.Delete(targetzip);

                rd.Result = true;
            }
            catch (FileNotFoundException) { rd = new ResultData { Result = false, Message = "文件生成过程中出错" }; }
            catch (IOException) { rd = new ResultData { Result = false, Message = "文件生成过程中出错" }; }
            return rd;
        }

        void MakePWDFile(string targetzip, string pwd)
        {
            //获取文件信息
            List<string> targetSEFInfo = GetSEFFilePath(targetzip);

            #region 文件内容加密
            List<byte> bytefilecontent = new List<byte>();
            byte[] bytes = new byte[8];
            using (FileStream fs = File.Open(targetzip, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                int length = 0;
                while ((length = fs.Read(bytes, 0, bytes.Length)) > 0)
                {
                    List<byte> list = new List<byte>();
                    list.AddRange(bytes);
                    bytefilecontent.AddRange(list.GetRange(0, length).ToArray());
                    bytes = new byte[8];
                }
            }

            byte[] IV = GeneratorRandomBytes(8);
            SymmetricAlgorithm sma = CreateRijndael(pwd, IV);

            //if (bytefilecontent.Count % 8 != 0)
            //    for (int i = bytefilecontent.Count % 8; i < 8; i++)
            //        bytefilecontent.Add(0x08);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs;
            cs = new CryptoStream(ms, sma.CreateEncryptor(sma.Key, sma.IV), CryptoStreamMode.Write);
            cs.Write(bytefilecontent.ToArray(), 0, bytefilecontent.Count);
            //cs.Flush();
            cs.FlushFinalBlock();

            //cs.Close();
            #endregion

            List<byte> buffer = new List<byte>();

            #region sef文件组包
            //添加头
            buffer.AddRange(new byte[] { 0x53, 0x45, 0x46, 0x00, 0x00 });
            //添加分组段
            buffer.AddRange(new byte[] { 0x01, 0xFF, 0x02 });

            List<byte> bytefilename = new List<byte> { 0xE0 };
            bytefilename.AddRange(GetByte64C(System.Text.Encoding.UTF8.GetBytes(targetSEFInfo[1]).Length));
            bytefilename.AddRange(GetByte64(targetSEFInfo[1]));
            byte[] bytefiletype = new byte[] { 0xE1, 0x02, 0x00, 0x01 };
            List<byte> bytefilelength = new List<byte> { 0xE2 };
            List<byte> temp = new List<byte> { };
            temp.AddRange(GetByte64(bytefilecontent.Count));
            bytefilelength.AddRange(GetByte64C(temp.Count));
            bytefilelength.AddRange(temp);
            List<byte> bytefiletime = new List<byte> { 0xE3 };
            temp.Clear();
            temp.AddRange(GetByte64((Int64)(DateTime.Now - DateTime.Parse("1970/1/1")).TotalSeconds));
            bytefiletime.AddRange(GetByte64C(temp.Count));
            bytefiletime.AddRange(temp);
            byte[] byteIV = sma.IV;
            byte[] bytekey = sma.Key;
            byte[] bytepwddata = ms.ToArray();
            byte[] bytehasdata = GetHashData(bytefilecontent.ToArray(), sma.Key);

            #region 添加描述段
            //添加描述段
            buffer.Add(0x02);
            buffer.AddRange(GetByte64C(bytefilename.Count + bytefiletype.Length + bytefilelength.Count + bytefiletime.Count));
            //添加文件名称
            buffer.AddRange(bytefilename);
            //添加文件类型
            buffer.AddRange(bytefiletype);
            //添加文件长度
            buffer.AddRange(bytefilelength);
            //添加文件时间
            buffer.AddRange(bytefiletime);
            #endregion

            #region 添加加密段
            //添加加密段
            buffer.AddRange(new byte[] { 0x03, 0xFF, 0x07 });
            //添加对称加密算法
            buffer.AddRange(new byte[] { 0x51, 0x01, 0x04 });
            //添加MAC算法
            buffer.AddRange(new byte[] { 0x58, 0x01, 0x42 });
            //添加对称加密模式
            buffer.AddRange(new byte[] { 0x52, 0x01, 0x62 });
            //添加填充模式
            buffer.AddRange(new byte[] { 0x53, 0x01, 0x71 });
            //添加初始向量
            buffer.AddRange(new byte[] { 0x54, 0x08 });
            buffer.AddRange(byteIV);
            //添加密钥标记
            //buffer.Add(0x55);
            //buffer.AddRange(GetByte64C(bytekey.Length));
            //buffer.AddRange(bytekey);
            //添加加密数据
            buffer.Add(0x40);
            buffer.AddRange(GetByte64C(bytepwddata.Length));
            buffer.AddRange(bytepwddata);
            //添加散列数据
            buffer.Add(0x41);
            buffer.AddRange(GetByte64C(bytehasdata.Length));
            buffer.AddRange(bytehasdata);
            #endregion
            #endregion

            //生成加密文件
            File.WriteAllBytes(Path.Combine(targetSEFInfo[0], targetSEFInfo[2]), buffer.ToArray());
        }

        private byte[] GeneratorRandomBytes(int count)
        {
            byte[] bytes = new byte[count];
            rand.GetBytes(bytes);
            return bytes;
        }

        private SymmetricAlgorithm CreateRijndael(string passwod, byte[] iv)
        {
            byte[] tt = IV;
            for (int i = 0; i < 1024; i++)
            {
                List<byte> ll = new List<byte>();
                ll.AddRange(tt);
                ll.AddRange(System.Text.Encoding.UTF8.GetBytes(passwod));
                tt = new System.Security.Cryptography.SHA256Managed().ComputeHash(ll.ToArray());
            }

            List<byte> ltt = new List<byte>();
            ltt.AddRange(tt);

            SymmetricAlgorithm sma = new TripleDESCryptoServiceProvider();
            sma.Key = ltt.GetRange(0, 24).ToArray();//pdb.GetBytes(24);
            sma.Mode = CipherMode.CBC;
            sma.Padding = PaddingMode.PKCS7;
            sma.BlockSize = 64;
            sma.IV = IV;
            return sma;
        }

        /// <summary>
        /// 获取文件信息
        /// 
        /// return List content
        /// 0-父级路径
        /// 1-zip文件名称
        /// 2-sef文件名称
        /// </summary>
        /// <param name="targetzip"></param>
        /// <returns></returns>
        List<string> GetSEFFilePath(string targetzip)
        {
            List<string> strList = new List<string>();
            int index = targetzip.LastIndexOf("\\");
            strList.Add(targetzip.Substring(0, index));
            strList.Add(targetzip.Replace(strList[0] + "\\", ""));
            index = strList[1].LastIndexOf(".");
            strList.Add(strList[1].Substring(0, index) + ".sef");
            return strList;
        }

        byte[] GetByte64(string data)
        {
            return System.Text.Encoding.UTF8.GetBytes(data);
        }

        byte[] GetByte64C(Int64 data)
        {
            List<byte> bytes = new List<byte>();

            int count = 1;
            bool flag = true;
            while (flag)
            {
                Int64 tempdata = GetMiddleData(count);
                if (data > tempdata)
                {
                    data -= tempdata;
                    count++;
                }
                else flag = false;
            }

            string str = data.ToString("x");
            if (str.Length % 2 != 0)
                str = str.PadLeft(str.Length + 1, '0');
            char[] charList = str.ToCharArray();
            for (int i = 0; i < charList.Length; i += 2)
            {
                bytes.Add(Convert.ToByte(charList[i].ToString() + charList[i + 1].ToString(), 16));
            }

            bytes = ConvertData(count, bytes);

            return bytes.ToArray();
        }

        byte[] GetByte64(Int64 data)
        {
            List<byte> bytes = new List<byte>();

            string str = data.ToString("x");
            if (str.Length % 2 != 0)
                str = str.PadLeft(str.Length + 1, '0');
            char[] charList = str.ToCharArray();
            for (int i = 0; i < charList.Length; i += 2)
            {
                bytes.Add(Convert.ToByte(charList[i].ToString() + charList[i + 1].ToString(), 16));
            }

            return bytes.ToArray();
        }

        byte[] GetHashData(byte[] bytes, byte[] key)
        {
            HMAC hash = HMACSHA256.Create("HmacSHA256");
            hash.Key = key;
            return hash.ComputeHash(bytes);
        }

        private List<byte> ConvertData(int count, List<byte> bytes)
        {
            List<byte> temp = new List<byte>();
            switch (count)
            {
                case 1:
                    temp = new List<byte> { 0x00 };
                    break;
                case 2:
                    temp = new List<byte> { 0x80, 0x00 };
                    break;
                case 3:
                    temp = new List<byte> { 0xC0, 0x00, 0x00 };
                    break;
                case 4:
                    temp = new List<byte> { 0xE0, 0x00, 0x00, 0x00 };
                    break;
                case 5:
                    temp = new List<byte> { 0xF0, 0x00, 0x00, 0x00, 0x00 };
                    break;
            }
            for (int i = 1; i <= bytes.Count; i++)
                temp[temp.Count - i] += bytes[bytes.Count - i];
            return temp;
        }

        Int64 GetMiddleData(int count)
        {
            Int64 data = 0;
            switch (count)
            {
                case 1:
                    data = Int64.Parse("80", System.Globalization.NumberStyles.HexNumber);
                    break;
                case 2:
                    data = Int64.Parse("4080", System.Globalization.NumberStyles.HexNumber); break;
                case 3:
                    data = Int64.Parse("204080", System.Globalization.NumberStyles.HexNumber); break;
                case 4:
                    data = Int64.Parse("10204080", System.Globalization.NumberStyles.HexNumber); break;
                case 5:
                    data = Int64.Parse("0810204080", System.Globalization.NumberStyles.HexNumber); break;
            }
            return data;
        }
        #endregion

        #region 解密
        byte[] IV = new byte[8];
        byte[] Key = new byte[24];
        List<byte> datazipList = new List<byte>();

        public string MakeFromPWD(string filepath, string pwd)
        {
            string zipfilepath = UnPWDFile(filepath, pwd);

            string sourcefilepath = FileIO.ZipOperatorHelper.Instance.UnZip(zipfilepath)[0];

            //string targetFilePath = GetTargetFilePath(filepath, sourcefilepath);

            return sourcefilepath;//targetFilePath;
        }

        string GetTargetFilePath(string origalFilepath, string sourceFilePath)
        {
            string targetFilePath = origalFilepath;
            try
            {
                string targetFileName = sourceFilePath.Substring(sourceFilePath.LastIndexOf('\\') + 1);
                string targetParentPath = origalFilepath.Substring(0, origalFilepath.LastIndexOf('\\'));
                targetFilePath = Path.Combine(targetParentPath, targetFileName);
            }
            catch { }
            return targetFilePath;
        }

        string UnPWDFile(string filepath, string pwd)
        {
            string zipfilepath = string.Empty;

            List<byte> buffer = new List<byte>();

            using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] bytes = new byte[0x1000];
                int count = 0;
                while ((count = fs.Read(bytes, 0, bytes.Length)) > 0)
                {
                    List<byte> temp = new List<byte>();
                    temp.AddRange(bytes);
                    buffer.AddRange(temp.GetRange(0, count));
                }
            }

            AnalizaData(buffer);

            byte[] tt = IV;
            for (int i = 0; i < 1024; i++)
            {
                List<byte> ll = new List<byte>();
                ll.AddRange(tt);
                ll.AddRange(System.Text.Encoding.UTF8.GetBytes(pwd));
                tt = new System.Security.Cryptography.SHA256Managed().ComputeHash(ll.ToArray());
            }

            List<byte> ltt = new List<byte>();
            ltt.AddRange(tt);
            TripleDES sma = new TripleDESCryptoServiceProvider();
            sma.Key = ltt.GetRange(0, 24).ToArray();//pdb.GetBytes(24);
            sma.Mode = CipherMode.CBC;
            sma.Padding = PaddingMode.PKCS7;
            sma.BlockSize = 64;
            sma.IV = IV;
            //TripleDES sma = CreateRijndael(pwd, IV);
            //TripleDES sma = new TripleDESCryptoServiceProvider();
            //sma.Key = pdb.GetBytes(24);
            //sma.Mode = CipherMode.CBC;
            //sma.Padding = PaddingMode.PKCS7;
            //sma.BlockSize = 64;
            //sma.IV = IV;

            MemoryStream ms = new MemoryStream(datazipList.ToArray());
            CryptoStream cs;
            cs = new CryptoStream(ms, sma.CreateDecryptor(sma.Key, sma.IV), CryptoStreamMode.Read);
            byte[] zipdata = new byte[datazipList.Count];
            cs.Read(zipdata, 0, datazipList.Count);
            cs.Close();
            ms.Close();

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\temp"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\temp");
            }

            using (FileStream fs = File.Create("temp\\1.zip"))
            {
                fs.Write(zipdata, 0, zipdata.Length);
            }

            zipfilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp\\1.zip");
            return zipfilepath;
        }

        void AnalizaData(List<byte> buffer)
        {
            int position = 9;
            int temp = position;
            int findIndex = FindNextIndex(buffer, position, 0xe0, 15);
            int lengthcount = findIndex - position;
            int firstGroupLength = GetLength(buffer.GetRange(position, lengthcount));
            position += firstGroupLength + 1;
            #region firstgroup
            //if (buffer[position].ToString().Equals("E0"))
            //{
            //    temp++;
            //    if (buffer[temp] > 0) fileName = Encoding.UTF8.GetString(buffer.ToArray(), temp + 1, buffer[temp]);
            //    temp += buffer[temp];
            //}
            //if (buffer[temp].ToString().Equals("E1"))
            //{
            //    temp++;
            //    temp += buffer[temp];
            //}
            //if (buffer[temp].ToString().Equals("E2"))
            //{
            //    temp++;
            //    position += buffer[temp];
            //}
            //if (buffer[temp].ToString().Equals("E3"))
            //{
            //    temp++;
            //    temp += buffer[temp];
            //}
            #endregion
            #region secondgroup
            position += 2;
            int secondgroupcount = buffer[position];
            position += 3;
            int pwdType = buffer[position];
            position += 3;
            int mactype = buffer[position];
            position += 3;
            int pwdmode = buffer[position];
            position += 3;
            int paddingmode = buffer[position];

            position += 2;
            findIndex = FindNextIndex(buffer, position, 0x40, secondgroupcount * 3);
            lengthcount = findIndex - position;
            int grouplength = GetGroupLength(buffer.GetRange(position, lengthcount));
            IV = buffer.GetRange(position + grouplength, lengthcount - grouplength).ToArray();
            position = findIndex;

            //position++;
            //findIndex = FindNextIndex(buffer, position, 0x40, 3 * 3);
            //lengthcount = findIndex - position;
            //position = findIndex + 1;
            //Key = buffer.GetRange(position - lengthcount, lengthcount).ToArray();

            //position = FindNextIndex(buffer, position, 0x40, 3 * 3);
            //position++;

            position++;
            findIndex = FindNextIndex(buffer, position, 0x41, 2 * 3);
            lengthcount = findIndex - position;
            grouplength = GetGroupLength(buffer.GetRange(position, lengthcount));
            while (grouplength == -1)
            {
                findIndex = FindNextIndex(buffer, findIndex + 1, 0x41, 2 * 3);
                lengthcount = findIndex - position;
                grouplength = GetGroupLength(buffer.GetRange(position, lengthcount));
            }
            datazipList = buffer.GetRange(position + grouplength, lengthcount - grouplength);
            position = findIndex;

            #endregion
        }

        private int FindNextIndex(List<byte> buffer, int position, int nextStart, int minlength)
        {
            int index = position;
            index = buffer.FindIndex(position, o => o == nextStart);
            return index;
        }

        int GetGroupLength(List<byte> list)
        {
            int maxlength = 0;
            if (list.Count > 2)
            {
                maxlength = GetLengthCount(list.Count);
                while (maxlength >= 0)
                {
                    int dataLength = GetLength(list.GetRange(0, maxlength));
                    if (dataLength == list.Count - maxlength) break;
                    else maxlength--;
                }
            }
            return maxlength;
        }

        int GetLengthCount(Int64 length)
        {
            int count = 0;
            if (length < 0x80) count = 1;
            else if (length < 0x4080) count = 2;
            else if (length < 0x204080) count = 3;
            else if (length < 0x10204080) count = 4;
            else if (length < 0x0810204080) count = 5;
            else if (length < 0x040810204080) count = 6;
            else if (length < 0x02040810204080) count = 7;
            else if (length < 0x0102040810204080) count = 8;
            return count;
        }

        private int GetLength(List<byte> list)
        {
            int length = 0;
            switch (list.Count)
            {
                case 1:
                    length = list[0];
                    break;
                case 2:
                    list[0] -= 0x80;
                    length = list[0] * 256 + list[1] + 0x80;
                    break;
                case 3:
                    list[0] -= 0xc0;
                    length = (list[0] * 256 + list[1]) * 256 + list[2] + 0x4080 + 0x80;
                    break;
                case 4:
                    list[0] -= 0xe0;
                    length = ((list[0] * 256 + list[1]) * 256 + list[2]) * 256 + list[3] + 0x204080 + 0x4080 + 0x80;
                    break;
                case 5:
                    list[0] -= 0xf0;
                    length = (((list[0] * 256 + list[1]) * 256 + list[2]) * 256 + list[3]) * 256 + list[4] + 0x10204080 + 0x204080 + 0x4080 + 0x80;
                    break;
                //case 6:
                //    list[0] -= 0xf0;
                //    length = ((((list[0] * 256 + list[1]) * 256 + list[2]) * 256 + list[3]) * 256 + list[4]) * 256 + 0x0810204080 + 0x10204080 + 0x204080 + 0x4080 + 0x80;
                //    break;
            }
            return length;
        }
        #endregion
    }
}
