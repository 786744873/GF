using System;

namespace CommonClient.Entities
{
    /// <summary>
    ///   附言及用途类
    /// </summary>
    [Serializable]
    public class NoticeInfo : EntityBase, ICloneable
    {
        /// <summary>
        ///   行号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        ///   标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///   内容
        /// </summary>
        public string Content { get; set; }

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public override string ToString()
        {
            return Content.ToString();
        }
    }
}