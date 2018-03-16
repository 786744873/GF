using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// O_Schedule:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public partial class O_Schedule
    {
        public O_Schedule()
        { }
        #region Model
        public int _o_schedule_id;
        public Guid? _o_schedule_code;
        public string _o_schedule_title;
        public string _o_schedule_content;
        public DateTime? _o_schedule_starttime;
        public DateTime? _o_schedule_endtime;
        public string _o_schedule_startriqi;
        public string _o_schedule_endriqi;
        public string _o_schedule_startshijian;
        public string _o_schedule_endshijian;
        public int? _o_schedule_remindtype;
        public int? _o_schedule_repeattype;
        public int? _o_schedule_endcondition;
        public DateTime? _o_schedule_endrepeatdate;
        public Guid? _o_schedule_creator;
        public DateTime? _o_schedule_createtime;
        public bool _o_schedule_isdelete;
        public int? _scheduleBelongType;
        public bool _o_schedule_isallday;
        public bool _o_schedule_isrepeat;
        public string _o_schedule_remindtypename;//虚拟字段
        public string _o_schedule_repeattypename;//虚拟字段
        public string _o_schedule_endconditionname;//虚拟字段
        public string _c_userinfo_name;//虚拟字段
        public DateTime? _c_message_createtime;//虚拟字段
        public int? _c_messages_id;//虚拟字段
        public string _o_schedule_calendarid;//虚拟字段
        public bool _o_schedule_isread;//是否已读（虚拟属性，App专用）

        /// <summary>
        /// 是否已读（虚拟属性，App专用）
        /// </summary>
        public bool O_schedule_isread
        {
            get { return _o_schedule_isread; }
            set { _o_schedule_isread = value; }
        }
        /// <summary>
        /// 自动增长标识
        /// </summary>
        public int O_Schedule_id
        {
            set { _o_schedule_id = value; }
            get { return _o_schedule_id; }
        }
        /// <summary>
        /// 日程表格id
        /// </summary>
        public string O_Schedule_calendarid
        {
            set { _o_schedule_calendarid = value; }
            get { return _o_schedule_calendarid; }
        }
        /// <summary>
        /// 虚拟字段（消息id）
        /// </summary>
        public int? C_Messages_id
        {
            set { _c_messages_id = value; }
            get { return _c_messages_id; }
        }
        /// <summary>
        /// 日程消息提示时间
        /// </summary>
        public DateTime? C_Message_createtime
        {
            set { _c_message_createtime = value; }
            get { return _c_message_createtime; }
        }
        /// <summary>
        /// 日程GUID
        /// </summary>
        public Guid? O_Schedule_code
        {
            set { _o_schedule_code = value; }
            get { return _o_schedule_code; }
        }
        /// <summary>
        /// 日程标题
        /// </summary>
        public string O_Schedule_title
        {
            set { _o_schedule_title = value; }
            get { return _o_schedule_title; }
        }
        /// <summary>
        /// 日程内容
        /// </summary>
        public string O_Schedule_content
        {
            set { _o_schedule_content = value; }
            get { return _o_schedule_content; }
        }
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? O_Schedule_startTime
        {
            set { _o_schedule_starttime = value; }
            get { return _o_schedule_starttime; }
        }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? O_Schedule_endTime
        {
            set { _o_schedule_endtime = value; }
            get { return _o_schedule_endtime; }
        }

        /// <summary>
        /// 开始日期(只有日期部分)(虚拟属性)
        /// </summary>
        public string O_Schedule_startRiQi
        {
            set { _o_schedule_startriqi = value; }
            get { return _o_schedule_startriqi; }
        }

        /// <summary>
        /// 结束日期(只有日期部分)(虚拟属性)
        /// </summary>
        public string O_Schedule_endRiQi
        {
            set { _o_schedule_endriqi = value; }
            get { return _o_schedule_endriqi; }
        }

        /// <summary>
        /// 开始日期(只有时间部分)(虚拟属性)
        /// </summary>
        public string O_Schedule_startShiJian
        {
            set { _o_schedule_startshijian = value; }
            get { return _o_schedule_startshijian; }
        }

        /// <summary>
        /// 结束日期(只有时间部分)(虚拟属性)
        /// </summary>
        public string O_Schedule_endShiJian
        {
            set { _o_schedule_endshijian = value; }
            get { return _o_schedule_endshijian; }
        }

        /// <summary>
        /// 提醒类型，外键，关联parameter表，不提醒、准时、提前10分钟、提前30分钟、提前1小时、提前2小时、提前3小时、提前一天
        /// </summary>
        public int? O_Schedule_remindType
        {
            set { _o_schedule_remindtype = value; }
            get { return _o_schedule_remindtype; }
        }
        /// <summary>
        /// (虚拟字段)提醒类型名称，外键，关联parameter表，不提醒、准时、提前10分钟、提前30分钟、提前1小时、提前2小时、提前3小时、提前一天
        /// </summary>
        public string O_Schedule_remindTypename
        {
            set { _o_schedule_remindtypename = value; }
            get { return _o_schedule_remindtypename; }
        }
        /// <summary>
        /// 重复类型，外键，关联parameter表，每日重复、每周重复、每月重复
        /// </summary>
        public int? O_Schedule_repeatType
        {
            set { _o_schedule_repeattype = value; }
            get { return _o_schedule_repeattype; }
        }
        /// <summary>
        /// （虚拟字段）重复类型，外键，关联parameter表，每日重复、每周重复、每月重复
        /// </summary>
        public string O_Schedule_repeatTypename
        {
            set { _o_schedule_repeattypename = value; }
            get { return _o_schedule_repeattypename; }
        }
        /// <summary>
        /// 结束条件，外键，关联parameter表，永不结束，结束日期
        /// </summary>
        public int? O_Schedule_endCondition
        {
            set { _o_schedule_endcondition = value; }
            get { return _o_schedule_endcondition; }
        }
        /// <summary>
        /// （虚拟字段）结束条件，外键，关联parameter表，永不结束，结束日期
        /// </summary>
        public string O_Schedule_endConditionname
        {
            set { _o_schedule_endconditionname = value; }
            get { return _o_schedule_endconditionname; }
        }
        /// <summary>
        /// 结束重复日期
        /// </summary>
        public DateTime? O_Schedule_endRepeatDate
        {
            set { _o_schedule_endrepeatdate = value; }
            get { return _o_schedule_endrepeatdate; }
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

        /// <summary>
        /// 日程所属类型(1为个人日程;0为部门日程)(虚拟属性)
        /// </summary>
        public int? ScheduleBelongType
        {
            set { _scheduleBelongType = value; }
            get { return _scheduleBelongType; }
        }
        /// <summary>
        /// 是否全天事件：1为是；0为否
        /// </summary>
        public bool O_Schedule_isAllDay
        {
            set { _o_schedule_isallday = value; }
            get { return _o_schedule_isallday; }
        }
        /// <summary>
        /// 是否重复,1为重复，0为不重复
        /// </summary>
        public bool O_Schedule_isRepeat
        {
            set { _o_schedule_isrepeat = value; }
            get { return _o_schedule_isrepeat; }
        }
        /// <summary>
        /// （虚拟字段）参与人
        /// </summary>
        public string C_Userinfo_name
        {
            set { _c_userinfo_name = value; }
            get { return _c_userinfo_name; }
        }
        #endregion Model

    }
}
