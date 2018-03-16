using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.SysManager
{
    /// <summary>
    /// 登陆记录:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：陈永俊
    /// 时间：2015-06-03 14:23:06
    /// </summary>
    [Serializable]
    public partial class C_Log
    {
        public C_Log()
        { }
        #region Model
        private int _c_id;
        private Guid _c_log_code;
        private string _c_userinfo_post;
        private string _c_operate;
        private string _c_log_ip;
        private DateTime? _c_datatime;
        private string _c_userinfo_name;
        private Guid _c_userinfo_code;
        private int? _c_log_type;
        private string _c_log_typename;
        /// <summary>
        /// 
        /// </summary>
        public int C_id
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 登陆记录GUID
        /// </summary>
        public Guid C_Log_code
        {
            set { _c_log_code = value; }
            get { return _c_log_code; }
        }
        /// <summary>
        /// 所属岗位
        /// </summary>
        public string C_Userinfo_post
        {
            set { _c_userinfo_post = value; }
            get { return _c_userinfo_post; }
        }
        /// <summary>
        /// 操作
        /// </summary>
        public string C_Operate
        {
            set { _c_operate = value; }
            get { return _c_operate; }
        }
        /// <summary>
        /// 登录IP
        /// </summary>
        public string C_Log_ip
        {
            set { _c_log_ip = value; }
            get { return _c_log_ip; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? C_Datatime
        {
            set { _c_datatime = value; }
            get { return _c_datatime; }
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
        /// 登录者GUID
        /// </summary>
        public Guid C_Userinfo_code
        {
            set { _c_userinfo_code = value; }
            get { return _c_userinfo_code; }
        }
        /// <summary>
        /// 登录类型  PC端登录/APP端登录
        /// </summary>
        public int? C_Log_Type
        {
            set { _c_log_type = value; }
            get { return _c_log_type; }
        }
        /// <summary>
        /// 登录类型名称（虚拟字段）
        /// </summary>
        public string C_Log_Typename
        {
            set { _c_log_typename = value; }
            get { return _c_log_typename; }
        }
        #endregion Model

    }
}
