using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.SysManager
{
    /// <summary>
    /// 组织机构—岗位—人员表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2016/01/20
    /// </summary>
    [Serializable]
    public partial class C_Organization_post_user
    {
        public C_Organization_post_user()
        { }
        #region Model
        private int _c_organization_post_user_id;
        private Guid? _c_organization_code;
        private string _org_name;
        private Guid? _org_region_code;
        private string _org_region_name;
        private Guid? _c_post_code;
        private string _c_post_name;
        private Guid? _c_post_group_code;
        private string _c_post_group_name;
        private Guid? _c_user_code;
        private bool _c_organization_post_user_isdelete;
        private DateTime? _c_organization_post_user_deletetime;
        private Guid? _c_organization_post_user_creator;
        private DateTime? _c_organization_post_user_createtime;
        /// <summary>
        /// 
        /// </summary>
        public int C_Organization_post_user_id
        {
            set { _c_organization_post_user_id = value; }
            get { return _c_organization_post_user_id; }
        }
        /// <summary>
        /// 组织架构GUID
        /// </summary>
        public Guid? C_Organization_code
        {
            set { _c_organization_code = value; }
            get { return _c_organization_code; }
        }
        /// <summary>
        /// 组织机构名称(虚拟属性)
        /// </summary>
        public string Org_name
        {
            set { _org_name = value; }
            get { return _org_name; }
        }

        /// <summary>
        /// 组织架构区域GUID(虚拟属性)
        /// </summary>
        public Guid? Org_region_code
        {
            set { _org_region_code = value; }
            get { return _org_region_code; }
        }
        /// <summary>
        /// 组织机构区域名称(虚拟属性)
        /// </summary>
        public string Org_region_name
        {
            set { _org_region_name = value; }
            get { return _org_region_name; }
        }

        /// <summary>
        /// 岗位GUID
        /// </summary>
        public Guid? C_Post_code
        {
            set { _c_post_code = value; }
            get { return _c_post_code; }
        }

        /// <summary>
        /// 岗位名称(虚拟属性)
        /// </summary>
        public string C_Post_name
        {
            set { _c_post_name = value; }
            get { return _c_post_name; }
        }
        /// <summary>
        /// 岗位组GUID(虚拟属性)
        /// </summary>
        public Guid? C_Post_group_code
        {
            set { _c_post_group_code = value; }
            get { return _c_post_group_code; }
        }
        /// <summary>
        /// 岗位组名称(虚拟属性)
        /// </summary>
        public string C_Post_group_name
        {
            set { _c_post_group_name = value; }
            get { return _c_post_group_name; }
        }

        /// <summary>
        /// 用户GUID
        /// </summary>
        public Guid? C_User_code
        {
            set { _c_user_code = value; }
            get { return _c_user_code; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool C_Organization_post_user_isDelete
        {
            set { _c_organization_post_user_isdelete = value; }
            get { return _c_organization_post_user_isdelete; }
        }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? C_Organization_post_user_deleteTime
        {
            set { _c_organization_post_user_deletetime = value; }
            get { return _c_organization_post_user_deletetime; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Organization_post_user_creator
        {
            set { _c_organization_post_user_creator = value; }
            get { return _c_organization_post_user_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Organization_post_user_createTime
        {
            set { _c_organization_post_user_createtime = value; }
            get { return _c_organization_post_user_createtime; }
        }
        #endregion Model
    }
}
