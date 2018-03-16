using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maticsoft.Common
{
    /// <summary>
    /// 字符串的截取 高俊
    /// </summary>
    public class Cutout
    {
        public static string Cut(string cutstring, int cutlength)
        {
            if (cutstring != "" && cutstring!=null && cutstring.Length > 0)
            {
                if (cutstring.Length >= cutlength)
                {
                    return cutstring.Substring(0, cutlength);
                }
                else
                {
                    return cutstring;
                }
            }
            else
            {
                return "";
            }
        }
    }
}
