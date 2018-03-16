using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Customer
{
    /// <summary>
    /// 律师管理—律师（虚拟实体）
    /// </summary>
    public class V_Lawyer
    {
        private int lawyerId;
        /// <summary>
        /// ID
        /// </summary>
        public int LawyerId
        {
            get { return lawyerId; }
            set { lawyerId = value; }
        }
        private Guid? _c_userinfo_code;
        /// <summary>
        /// 律师Guid
        /// </summary>
        public Guid? C_Userinfo_code
        {
            get { return _c_userinfo_code; }
            set { _c_userinfo_code = value; }
        }
        private string _c_userinfo_name;
        /// <summary>
        /// 律师名称
        /// </summary>
        public string C_Userinfo_name
        {
            get { return _c_userinfo_name; }
            set { _c_userinfo_name = value; }
        }
        private int? _c_userinfo_roleID;
        /// <summary>
        /// 角色ID
        /// </summary>
        public int? C_Userinfo_roleID
        {
            get { return _c_userinfo_roleID; }
            set { _c_userinfo_roleID = value; }
        }
        private Guid? _c_userinfo_parent;
        /// <summary>
        /// 父级Guid
        /// </summary>
        public Guid? C_Userinfo_parent
        {
            get { return _c_userinfo_parent; }
            set { _c_userinfo_parent = value; }
        }
        private string _c_userinfo_description;
        /// <summary>
        /// 描述
        /// </summary>
        public string C_Userinfo_description
        {
            get { return _c_userinfo_description; }
            set { _c_userinfo_description = value; }
        }
        private int? _c_userinfo_state;
        /// <summary>
        /// 状态
        /// </summary>
        public int? C_Userinfo_state
        {
            get { return _c_userinfo_state; }
            set { _c_userinfo_state = value; }
        }
        private Guid? _c_userinfo_Organization;
        /// <summary>
        /// 所属组织架构
        /// </summary>
        public Guid? C_Userinfo_Organization
        {
            get { return _c_userinfo_Organization; }
            set { _c_userinfo_Organization = value; }
        }
        private string _c_userinfo_Organization_name;
        /// <summary>
        /// 所属组织架构名称（虚拟字段）
        /// </summary>
        public string C_Userinfo_Organization_name
        {
            get { return _c_userinfo_Organization_name; }
            set { _c_userinfo_Organization_name = value; }
        }
        private Guid? _c_userinfo_post;
        /// <summary>
        /// 岗位
        /// </summary>
        public Guid? C_Userinfo_post
        {
            get { return _c_userinfo_post; }
            set { _c_userinfo_post = value; }
        }
        private string _c_userinfo_post_name;
        /// <summary>
        /// 岗位名称（虚拟字段）
        /// </summary>
        public string C_Userinfo_post_name
        {
            get { return _c_userinfo_post_name; }
            set { _c_userinfo_post_name = value; }
        }
        
        private bool _c_userinfo_isDefault;
        /// <summary>
        /// 是否默认岗位
        /// </summary>
        public bool C_Userinfo_isDefault
        {
            get { return _c_userinfo_isDefault; }
            set { _c_userinfo_isDefault = value; }
        }
        
    }
}
