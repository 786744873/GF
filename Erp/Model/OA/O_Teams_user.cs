using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// O_Teams_user:实体类(属性说明自动提取数据库字段的描述信息)分组用户中间表
    /// cyj
    /// 2015年7月14日16:06:00
    /// </summary>
    [Serializable]
    public partial class O_Teams_user
    {
        public O_Teams_user()
        { }
        #region Model
        private int? _o_teams_user_id;
        private Guid _o_teams_code;
        private Guid _c_userinfo_code;
        private bool _o_teams_user_ismanager;
        private DateTime? _o_teams_user_intime;
        private Guid _o_teams_user_creator;
        private DateTime? _o_teams_user_createtime;
        private bool _o_teams_user_isdelete;
        /// <summary>
        /// 分组ID
        /// </summary>
        public int? O_Teams_user_id
        {
            set { _o_teams_user_id = value; }
            get { return _o_teams_user_id; }
        }
        /// <summary>
        /// 分组GUID  
        /// </summary>
        public Guid O_Teams_code
        {
            set { _o_teams_code = value; }
            get { return _o_teams_code; }
        }
        /// <summary>
        /// 人员GUID 
        /// </summary>
        public Guid C_Userinfo_code
        {
            set { _c_userinfo_code = value; }
            get { return _c_userinfo_code; }
        }
        /// <summary>
        /// 是否管理员 
        /// </summary>
        public bool O_Teams_user_isManager
        {
            set { _o_teams_user_ismanager = value; }
            get { return _o_teams_user_ismanager; }
        }
        /// <summary>
        /// 加入日期 
        /// </summary>
        public DateTime? O_Teams_user_inTime
        {
            set { _o_teams_user_intime = value; }
            get { return _o_teams_user_intime; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid O_Teams_user_creator
        {
            set { _o_teams_user_creator = value; }
            get { return _o_teams_user_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_Teams_user_createTime
        {
            set { _o_teams_user_createtime = value; }
            get { return _o_teams_user_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool O_Teams_user_isDelete
        {
            set { _o_teams_user_isdelete = value; }
            get { return _o_teams_user_isdelete; }
        }
        #endregion Model

    }
}
