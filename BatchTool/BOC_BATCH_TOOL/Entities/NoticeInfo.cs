using System;
using System.Collections.Generic;
using System.Text;

namespace BOC_BATCH_TOOL.Entities
{
    /// <summary>
    /// 附言及用途类
    /// </summary>
    [Serializable]
    public class NoticeInfo : Object, ICloneable
    {
        /// <summary>
        /// 行号
        /// </summary>
        public int RowIndex { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get
            {
                return m_title;
            }
            set
            {
                m_title = value;
            }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get
            {
                return m_content;
            }
            set
            {
                m_content = value;
            }
        }

        private string m_title;
        private string m_content;

        public override string ToString()
        {
            return m_content.ToString();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
