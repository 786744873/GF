using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.EnumTypes;
using System.IO;

namespace CommonClient.TemplateHelper
{
    /// <summary>
    /// 读取模板文件数据类
    /// </summary>
    public static class TemplateReadFileHelper
    {
        /// <summary>
        /// 加载模板格式文件
        /// </summary>
        /// <param name="appType">功能模块</param>
        /// <param name="command">操作命令</param>
        /// <param name="fileName">文件全名称</param>
        public static void LoadTemplateFile(AppliableFunctionType appType, OperatorCommandType command, string fileName)
        {
            //文件是否存在
            if (!File.Exists(fileName)) { return; }

            string[] dataList = File.ReadAllLines(fileName,Encoding.UTF8);
        }
    }
}
