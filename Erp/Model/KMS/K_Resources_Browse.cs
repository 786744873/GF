using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.KMS
{
    /// <summary>
    /// K_Resources_Browse:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class K_Resources_Browse
    {
        public K_Resources_Browse()
        { }
        #region Model
        private int _k_resources_browse_id;
        private Guid _k_resources_code;
        private Guid _k_resources_browse_usercode;
        private DateTime? _k_resources_browse_createtime;
        private bool _k_resources_browse_isdelete;
        private string _k_resources_name;
        private int? _k_resources_type;
        private string _k_resources_typeName;
        private string _k_resources_url;
        private string _k_resources_coverImage;
        private string _k_resources_knowledgeName;

        /// <summary>
        /// 浏览记录id
        /// </summary>
        public int K_Resources_Browse_id
        {
            set { _k_resources_browse_id = value; }
            get { return _k_resources_browse_id; }
        }
        /// <summary>
        /// 资源code
        /// </summary>
        public Guid K_Resources_code
        {
            set { _k_resources_code = value; }
            get { return _k_resources_code; }
        }
        /// <summary>
        /// 用户code
        /// </summary>
        public Guid Userinfo_code
        {
            set { _k_resources_browse_usercode = value; }
            get { return _k_resources_browse_usercode; }
        }
        /// <summary>
        /// 浏览时间
        /// </summary>
        public DateTime? K_Resources_Browse_createTime
        {
            set { _k_resources_browse_createtime = value; }
            get { return _k_resources_browse_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool K_Resources_Browse_isDelete
        {
            set { _k_resources_browse_isdelete = value; }
            get { return _k_resources_browse_isdelete; }
        }
        /// <summary>
        /// 资源名称（虚拟字段）
        /// </summary>
        public string K_Resources_name
        {
            set { _k_resources_name = value; }
            get { return _k_resources_name; }
        }
        /// <summary>
        /// 资源类型（虚拟字段）
        /// </summary>
        public int? K_Resources_type
        {
            set { _k_resources_type = value; }
            get { return _k_resources_type; }
        }
        /// <summary>
        /// 资源类型名称（虚拟字段）
        /// </summary>
        public string K_Resources_typeName
        {
            set { _k_resources_typeName = value; }
            get { return _k_resources_typeName; }
        }
        /// <summary>
        /// 资源地址（虚拟字段）
        /// </summary>
        public string K_Resources_url
        {
            set { _k_resources_url = value; }
            get { return _k_resources_url; }
        }
        /// <summary>
        /// 资源封面图（虚拟字段）
        /// </summary>
        public string K_Resources_coverImage
        {
            set { _k_resources_coverImage = value; }
            get { return _k_resources_coverImage; }
        }
        /// <summary>
        /// 知识所属分类（虚拟字段）
        /// </summary>
        public string K_Resources_KnowledgeName
        {
            set { _k_resources_knowledgeName = value; }
            get { return _k_resources_knowledgeName; }
        }
        #endregion Model

    }
}
