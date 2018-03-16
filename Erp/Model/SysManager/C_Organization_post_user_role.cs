using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.SysManager
{
    /// <summary>
    /// 组织机构—岗位—人员—角色表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2016/01/20
    /// </summary>
    [Serializable]
    public partial class C_Organization_post_user_role
    {
        public C_Organization_post_user_role()
        { }
        #region Model
        private int _c_organization_post_user_role_id;
        private Guid? _c_organization_code;
        private Guid? _c_post_code;
        private Guid? _c_user_code;
        private int? _c_role_id;
        private bool _c_organization_post_user_role_isdelete;
        private DateTime? _c_organization_post_user_role_deletetime;
        private Guid? _c_organization_post_user_role_creator;
        private DateTime? _c_organization_post_user_role_createtime;
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int C_Organization_post_user_role_id
        {
            set { _c_organization_post_user_role_id = value; }
            get { return _c_organization_post_user_role_id; }
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
        /// 岗位GUID
        /// </summary>
        public Guid? C_Post_code
        {
            set { _c_post_code = value; }
            get { return _c_post_code; }
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
        /// 角色ID
        /// </summary>
        public int? C_Role_id
        {
            set { _c_role_id = value; }
            get { return _c_role_id; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool C_Organization_post_user_role_isDelete
        {
            set { _c_organization_post_user_role_isdelete = value; }
            get { return _c_organization_post_user_role_isdelete; }
        }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? C_Organization_post_user_role_deleteTime
        {
            set { _c_organization_post_user_role_deletetime = value; }
            get { return _c_organization_post_user_role_deletetime; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Organization_post_user_role_creator
        {
            set { _c_organization_post_user_role_creator = value; }
            get { return _c_organization_post_user_role_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Organization_post_user_role_createTime
        {
            set { _c_organization_post_user_role_createtime = value; }
            get { return _c_organization_post_user_role_createtime; }
        }
        #endregion Model
    }
}
