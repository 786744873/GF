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
    public class TemplateReadFileHelper
    {
        #region 单例
        private static object lock_instance = new object();
        private static TemplateReadFileHelper m_instance;

        public static TemplateReadFileHelper Instance
        {
            get
            {
                if (null == m_instance)
                {
                    lock (lock_instance)
                    {
                        if (null == m_instance)
                        {
                            m_instance = new TemplateReadFileHelper();
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion

        /// <summary>
        /// 加载模板格式文件
        /// </summary>
        /// <param name="appType">功能模块</param>
        /// <param name="command">操作命令</param>
        /// <param name="fileName">文件全名称</param>
        public void LoadTemplateFile(AppliableFunctionType appType, OperatorCommandType command, string fileName)
        {
            //文件是否存在
            if (!File.Exists(fileName)) { return; }

            string[] dataList = File.ReadAllLines(fileName,Encoding.UTF8);
        }
    }
}
