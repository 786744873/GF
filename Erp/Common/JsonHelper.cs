﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Common
{
    /// <summary>
    /// 转化json
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// 实体转化json
        /// </summary>
        /// <param name="obj">要转换的实体对象</param>
        /// <returns></returns>
        public string EntityToJson(object obj)
        {
            StringBuilder jsonStr = new StringBuilder();
            PropertyInfo[] pInfos = obj.GetType().GetProperties();
            string pValue = string.Empty;
            jsonStr.Append("{");
            foreach (PropertyInfo p in pInfos)
            {
                if (!(p.GetValue(obj, null) == null))
                {
                    //转义掉Json格式特殊字符 ‘\’,‘"’
                    pValue = p.GetValue(obj, null).ToString().Replace("\\", "\\\\").Replace("\"", "\\\"");
                }
                else
                {
                    pValue = string.Empty;
                }
                jsonStr.Append(string.Format("\"{0}\":\"{1}\",", p.Name, pValue));

            }
            jsonStr.Remove(jsonStr.Length - 1, 1);
            jsonStr.Append("}");
            return jsonStr.ToString();
        }
    }
}
