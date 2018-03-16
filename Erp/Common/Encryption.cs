using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Common
{
    /// <summary>
    /// 加密操作类
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <returns>返回加密后的字符串</returns>
        public static string GetMd5(string str)
        {
            string password = "";
            MD5 md5 = MD5.Create();  //实例化一个md5对像
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(str));//加密后是一个字节类型的数组
            //将得到的字符串使用十六进制类型格式   
            for (int i = 0; i < bytes.Length; i++)
            {
                password = password + bytes[i].ToString();
            }
            return password;
        }

        /// <summary>
        /// 获取加密密钥
        /// </summary>
        /// <returns></returns>
        public static string GetSecretKey()
        {
            return "23sdfjonxvnwelxl.w0dg243saw31";
        }

        /// <summary>
        /// Base64转字符串
        /// </summary>
        /// <param name="base64Code">Base64码</param>
        /// <returns>转换后的字符串</returns>
        public static string Base64ToString(string base64Code)
        {
            byte[] bpath = Convert.FromBase64String(base64Code);
            return System.Text.ASCIIEncoding.Default.GetString(bpath);
        }

        /// <summary>
        /// 字符串转Base64码
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>转换后的Base64码</returns>
        public static string StringToBase64(string str)
        {
            System.Text.Encoding encode = System.Text.Encoding.ASCII;
            byte[] bytedata = encode.GetBytes(str);
            string strPath = Convert.ToBase64String(bytedata, 0, bytedata.Length);
            return strPath;
        }
    }
}
