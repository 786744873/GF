using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.KMS
{
    /// <summary>
    /// 采集信息表:实体类(属性说明自动提取数据库字段的描述信息)
    /// author:cpp
    /// date:2016-3-1
    /// </summary>
    [Serializable]
    public partial class K_Exam_ExtInfos
    {
        public K_Exam_ExtInfos()
        { }
        #region Model
        private Guid _k_extinfos_code;
        private int? _k_extinfos_id;
        private string _k_extinfos_name;
        private string _k_extinfos_value;
        private string _k_extinfos_realvalue;
        /// <summary>
        /// 编码
        /// </summary>
        public Guid K_ExtInfos_code
        {
            set { _k_extinfos_code = value; }
            get { return _k_extinfos_code; }
        }
        /// <summary>
        /// 信息id
        /// </summary>
        public int? K_ExtInfos_id
        {
            set { _k_extinfos_id = value; }
            get { return _k_extinfos_id; }
        }
        /// <summary>
        /// 信息名称
        /// </summary>
        public string K_ExtInfos_name
        {
            set { _k_extinfos_name = value; }
            get { return _k_extinfos_name; }
        }
        /// <summary>
        /// 信息值编码
        /// </summary>
        public string K_ExtInfos_value
        {
            set { _k_extinfos_value = value; }
            get { return _k_extinfos_value; }
        }
        /// <summary>
        /// 信息值
        /// </summary>
        public string K_ExtInfos_realValue
        {
            set { _k_extinfos_realvalue = value; }
            get { return _k_extinfos_realvalue; }
        }
        #endregion Model

    }
}
