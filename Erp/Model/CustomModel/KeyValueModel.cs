using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.CustomModel
{
    /// <summary>
    /// 键值实体，App专用
    /// 作者：张东洋
    /// 日期：2015-11-25
    /// </summary>
    public partial class KeyValueModel
    {
        public KeyValueModel()
        {

        }

        public string id;


        public string key;
        public string values;

        /// <summary>
        /// 主键
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 键
        /// </summary>
        public string Key
        {
            set { key = value; }
            get { return key; }
        }
        /// <summary>
        /// 值
        /// </summary>
        public string Value
        {
            set { values = value; }
            get { return values; }
        }
    }
}
