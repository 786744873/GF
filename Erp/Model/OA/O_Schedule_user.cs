using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// O_Schedule_user:2.	日程----用户中间表
    /// cyj
    /// 2015年7月14日15:24:33
    /// </summary>
    public partial class O_Schedule_user
    {
        public O_Schedule_user()
        { }
        #region Model
        public Guid? _o_schedule_code;
        public Guid? _c_userinfo_code;
        public Guid? _o_schedule_creator;
        public DateTime? _o_schedule_createtime;
        public bool _o_schedule_isdelete;
        public string _c_userinfo_name;//虚拟字段
        /// <summary>
        /// 日程GUID
        /// </summary>
        public Guid? O_Schedule_code
        {
            set { _o_schedule_code = value; }
            get { return _o_schedule_code; }
        }
        /// <summary>
        /// 虚拟字段  参与者名称
        /// </summary>
        public string C_Userinfo_name
        {
            set { _c_userinfo_name = value; }
            get { return _c_userinfo_name; }
        }
        /// <summary>
        /// 用户GUID 
        /// </summary>
        public Guid? C_userinfo_code
        {
            set { _c_userinfo_code = value; }
            get { return _c_userinfo_code; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? O_Schedule_creator
        {
            set { _o_schedule_creator = value; }
            get { return _o_schedule_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_Schedule_createTime
        {
            set { _o_schedule_createtime = value; }
            get { return _o_schedule_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool O_Schedule_isDelete
        {
            set { _o_schedule_isdelete = value; }
            get { return _o_schedule_isdelete; }
        }
        #endregion Model

    }
}
