using System;
using System.ComponentModel.DataAnnotations;
namespace CommonService.Model.SysManager
{
    /// <summary>
    /// 用户表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：张东洋
    /// 日期：2015/04/18
    /// </summary
    public partial class C_Userinfo
    {
        public C_Userinfo()
        { }
        #region Model
        public int _c_userinfo_id;
        public Guid? _c_userinfo_code;
        public string _c_userinfo_name;
        public string _c_userinfo_loginid;
        public string _c_userinfo_password;
        public int? _c_userinfo_roleid;
        public bool _c_userinfo_isdelete = false;
        public Guid? _c_userinfo_parent;
        public string _c_userinfo_description;
        public int? _c_userinfo_state;
        public Guid? _c_userinfo_creator;
        public DateTime? _c_userinfo_createtime;
        public Guid? _c_userinfo_organization;
        public Guid? _c_userinfo_post;
        public string _c_userinfo_post_name;
        public string _c_userinfo_organization_name;
        public string _c_userinfo_organization_post_name;
        public string _c_userinfo_roles_name;
        public bool _c_userinfo_isdefault = false;
        public Guid? _c_userinfo_relationCode;
        public int? _c_userinfo_relationType;
        public string _c_region_abbreviation;
        public int? _c_region_Integral;
        public string _c_region_cellPhoneNumber;
        public string _c_region_mailbox;
        public string _c_region_pictureAddress;
        public Guid? _c_userinfo_regioncode;
        public string _c_userinfo_regioncode_name;
        public bool iscanplan;


        public bool Iscanplan {
            set { iscanplan = value; }
            get { return iscanplan; }
        }

        /// <summary>
        /// 用户ID，主键，自增长
        /// </summary>
        public int C_Userinfo_id
        {
            set { _c_userinfo_id = value; }
            get { return _c_userinfo_id; }
        }
        /// <summary>
        /// 虚拟字段（区域）
        /// </summary>
        public string C_Region_abbreviation
        {
            set { _c_region_abbreviation = value; }
            get { return _c_region_abbreviation; }
        }
        /// <summary>
        /// (虚拟字段)用户所在区域guid
        /// </summary>
        public Guid? C_Userinfo_Regioncode
        {
            set { _c_userinfo_regioncode = value; }
            get { return _c_userinfo_regioncode; }
        }
        /// <summary>
        /// (虚拟字段)用户所在区域名称
        /// </summary>
        public string C_Userinfo_Regioncode_Name
        {
            set { _c_userinfo_regioncode_name = value; }
            get { return _c_userinfo_regioncode_name; }
        }
        /// <summary>
        /// 用户编码GUID
        /// </summary>
        public Guid? C_Userinfo_code
        {
            set { _c_userinfo_code = value; }
            get { return _c_userinfo_code; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string C_Userinfo_name
        {
            set { _c_userinfo_name = value; }
            get { return _c_userinfo_name; }
        }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string C_Userinfo_loginID
        {
            set { _c_userinfo_loginid = value; }
            get { return _c_userinfo_loginid; }
        }
        /// <summary>
        /// 用户密码，MD5存储
        /// </summary>
        public string C_Userinfo_password
        {
            set { _c_userinfo_password = value; }
            get { return _c_userinfo_password; }
        }
        /// <summary>
        /// 角色ID(已废弃)
        /// </summary>
        public int? C_Userinfo_roleID
        {
            set { _c_userinfo_roleid = value; }
            get { return _c_userinfo_roleid; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool C_Userinfo_isDelete
        {
            set { _c_userinfo_isdelete = value; }
            get { return _c_userinfo_isdelete; }
        }
        /// <summary>
        /// 父级用户，关联本身(已废弃)
        /// </summary>
        public Guid? C_Userinfo_parent
        {
            set { _c_userinfo_parent = value; }
            get { return _c_userinfo_parent; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string C_Userinfo_description
        {
            set { _c_userinfo_description = value; }
            get { return _c_userinfo_description; }
        }
        /// <summary>
        /// 0-禁用，1-启用
        /// </summary>
        public int? C_Userinfo_state
        {
            set { _c_userinfo_state = value; }
            get { return _c_userinfo_state; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Userinfo_creator
        {
            set { _c_userinfo_creator = value; }
            get { return _c_userinfo_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Userinfo_createTime
        {
            set { _c_userinfo_createtime = value; }
            get { return _c_userinfo_createtime; }
        }
        /// <summary>
        /// 所属组织架构编码(已废弃)
        /// </summary>
        public Guid? C_Userinfo_Organization
        {
            set { _c_userinfo_organization = value; }
            get { return _c_userinfo_organization; }
        }
        /// <summary>
        /// 所属组织机构名称(虚拟属性)(已废弃)
        /// </summary>
        public string C_Userinfo_Organization_name
        {
            set { _c_userinfo_organization_name = value; }
            get { return _c_userinfo_organization_name; }
        }

        /// <summary>
        /// 所属岗位编码(已废弃)
        /// </summary>
        public Guid? C_Userinfo_post
        {
            set { _c_userinfo_post = value; }
            get { return _c_userinfo_post; }
        }
        /// <summary>
        /// 所属岗位名称(虚拟属性)(已废弃)
        /// </summary>
        public string C_Userinfo_post_name
        {
            set { _c_userinfo_post_name = value; }
            get { return _c_userinfo_post_name; }
        }
        /// <summary>
        /// 所属组织机构岗位名称(虚拟属性)
        /// </summary>
        public string C_Userinfo_Organization_Post_name
        {
            set { _c_userinfo_organization_post_name = value; }
            get { return _c_userinfo_organization_post_name; }
        }
        /// <summary>
        /// 角色名称(虚拟属性)(已废弃)
        /// </summary>
        public string C_Userinfo_Roles_name
        {
            set { _c_userinfo_roles_name = value; }
            get { return _c_userinfo_roles_name; }
        }
        /// <summary>
        /// 是否是默认岗位(已废弃)
        /// </summary>
        public bool C_Userinfo_isDefault
        {
            set { _c_userinfo_isdefault = value; }
            get { return _c_userinfo_isdefault; }
        }
        /// <summary>
        /// 关联类型（虚拟字段）
        /// </summary>
        public int? C_Userinfo_relationType
        {
            get { return _c_userinfo_relationType; }
            set { _c_userinfo_relationType = value; }
        }

        /// <summary>
        /// 关联Guid（虚拟字段）
        /// </summary>
        public Guid? C_Userinfo_relationCode
        {
            get { return _c_userinfo_relationCode; }
            set { _c_userinfo_relationCode = value; }
        }
        /// <summary>
        /// 用户积分
        /// </summary>
        public int? C_Userinfo_Integral
        {
            get { return _c_region_Integral; }
            set { _c_region_Integral = value; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string C_Userinfo_cellPhoneNumber
        {
            get { return _c_region_cellPhoneNumber; }
            set { _c_region_cellPhoneNumber = value; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string C_Userinfo_mailbox
        {
            get { return _c_region_mailbox; }
            set { _c_region_mailbox = value; }
        }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string C_Userinfo_pictureAddress
        {
            get { return _c_region_pictureAddress; }
            set { _c_region_pictureAddress = value; }
        }

        

        #endregion Model


        #region App专用
        public int _c_Userinfo_loginState;

        public int C_Userinfo_loginState
        {
            get { return _c_Userinfo_loginState; }
            set { _c_Userinfo_loginState = value; }
        }

        public string _dept_name;

        public string Dept_name
        {
            get { return _dept_name; }
            set { _dept_name = value; }
        }
        public string _post_name;

        public string Post_name
        {
            get { return _post_name; }
            set { _post_name = value; }
        }
        ///// <summary>
        ///// 登陆状态（专供手机App使用）
        ///// 1 成功
        ///// 2 用户名或密码错误
        ///// 3 您的账户未设定默认岗位，请联系管理员处理
        ///// </summary>
        //public int C_Userinfo_loginState { get; set; }

        ///// <summary>
        ///// 主用户的所有子用户的部门（专供手机App使用）
        ///// </summary>
        //public string Dept_name { get; set; }

        ///// <summary>
        ///// 主用户的所有子用户的岗位（专供手机App使用）
        ///// </summary>
        //public string Post_name { get; set; }



        #endregion

    }
}

