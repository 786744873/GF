using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.KMS
{
    /// <summary>
    /// K_Resources_Cover:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class K_Resources_Cover
    {
        public K_Resources_Cover()
        { }
        #region Model
        private int _k_resources_cover_id;
        private Guid _k_resources_cover_code;
        private string _k_resources_cover_url;
        private bool _k_resources_cover_state;
        private DateTime? _k_resources_cover_createtime;
        private bool _k_resources_cover_isdelete;
        private Guid _k_resources_cover_creater;
        /// <summary>
        /// 自增长 ID
        /// </summary>
        public int K_Resources_cover_id
        {
            set { _k_resources_cover_id = value; }
            get { return _k_resources_cover_id; }
        }
        /// <summary>
        /// 默认封面guid
        /// </summary>
        public Guid K_Resources_cover_code
        {
            set { _k_resources_cover_code = value; }
            get { return _k_resources_cover_code; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string K_Resources_cover_url
        {
            set { _k_resources_cover_url = value; }
            get { return _k_resources_cover_url; }
        }
        /// <summary>
        /// 是否启用   0未启用，1启用
        /// </summary>
        public bool K_Resources_cover_state
        {
            set { _k_resources_cover_state = value; }
            get { return _k_resources_cover_state; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? K_Resources_cover_createTime
        {
            set { _k_resources_cover_createtime = value; }
            get { return _k_resources_cover_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool K_Resources_cover_isDelete
        {
            set { _k_resources_cover_isdelete = value; }
            get { return _k_resources_cover_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid K_Resources_cover_creater
        {
            set { _k_resources_cover_creater = value; }
            get { return _k_resources_cover_creater; }
        }
        #endregion Model

    }
}
