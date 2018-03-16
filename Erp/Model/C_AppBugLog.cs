using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    public partial class C_AppBugLog
    {
        public C_AppBugLog()
        { }
        #region Model
        public int _c_appbuglog_id;
        public Guid _c_appbuglog_usercode;
        public string _c_appbuglog_username;
        public string _c_appbuglog_crashcontent;
        public DateTime? _c_appbuglog_createtime;
        public string _c_appbuglog_phonemodel;
        public string _c_appbuglog_androidversions;
        public string _c_appbuglog_sdk;
        /// <summary>
        /// id
        /// </summary>
        public int C_AppBugLog_id
        {
            set { _c_appbuglog_id = value; }
            get { return _c_appbuglog_id; }
        }
        /// <summary>
        /// 用户GUID
        /// </summary>
        public Guid C_AppBugLog_userCode
        {
            set { _c_appbuglog_usercode = value; }
            get { return _c_appbuglog_usercode; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string C_AppBugLog_userName
        {
            set { _c_appbuglog_username = value; }
            get { return _c_appbuglog_username; }
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string C_AppBugLog_crashContent
        {
            set { _c_appbuglog_crashcontent = value; }
            get { return _c_appbuglog_crashcontent; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_AppBugLog_createTime
        {
            set { _c_appbuglog_createtime = value; }
            get { return _c_appbuglog_createtime; }
        }
        /// <summary>
        /// 手机型号
        /// </summary>
        public string C_AppBugLog_phoneModel
        {
            set { _c_appbuglog_phonemodel = value; }
            get { return _c_appbuglog_phonemodel; }
        }
        /// <summary>
        /// 安卓版本
        /// </summary>
        public string C_AppBugLog_androidVersions
        {
            set { _c_appbuglog_androidversions = value; }
            get { return _c_appbuglog_androidversions; }
        }
        /// <summary>
        /// SDK
        /// </summary>
        public string C_AppBugLog_sdk
        {
            set { _c_appbuglog_sdk = value; }
            get { return _c_appbuglog_sdk; }
        }
        #endregion Model

    }
}
