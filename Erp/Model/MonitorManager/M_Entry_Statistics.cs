using System;
namespace CommonService.Model.MonitorManager
{
    /// <summary>
    /// 条目统计表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/06/11
    /// </summary>
	public partial class M_Entry_Statistics
	{
		public M_Entry_Statistics()
		{}
		#region Model
		public int _m_entry_statistics_id;
		public Guid? _m_entry_statistics_code;
		public Guid? _m_case_code;
		public string _m_case_name;
        public int? _m_case_type;
        public string _m_case_number;
		public Guid? _m_entry_code;
		public int? _m_entry_statistics_changeduration;
		public DateTime? _m_entry_statistics_entrystime;
		public DateTime? _m_entry_statistics_entryetime;
        public int? _m_entry_statistics_status;
        public int? _m_entry_statistics_warningSituation;
        public int? _m_entry_statistics_HandlingState;
        public int? _m_entry_statistics_Management;
        public int? _m_entry_statistics_Management1;
		public int? _m_entry_statistics_isdelete;
		public Guid? _m_entry_statistics_creator;
		public DateTime? _m_entry_statistics_createtime;
        public string _m_entry_name;
        public int? _m_entry_Duration;
        public int? _m_entry_warningType;
        public int? _m_entry_warningDuration;
        public string m_Case_type_name;
        public string m_Entry_Statistics_HandlingState_name;
        public string m_Entry_Statistics_warningSituation_name;
        public string m_Entry_warningType_name;

        /// <summary>
        /// 预警类型名称
        /// </summary>
        public string M_Entry_warningType_name
        {
            get { return m_Entry_warningType_name; }
            set { m_Entry_warningType_name = value; }
        }

        /// <summary>
        /// 预警情况名称
        /// </summary>
        public string M_Entry_Statistics_warningSituation_name
        {
            get { return m_Entry_Statistics_warningSituation_name; }
            set { m_Entry_Statistics_warningSituation_name = value; }
        }

        /// <summary>
        /// 办理状态名称
        /// </summary>
        public string M_Entry_Statistics_HandlingState_name
        {
            get { return m_Entry_Statistics_HandlingState_name; }
            set { m_Entry_Statistics_HandlingState_name = value; }
        }

        /// <summary>
        /// 案件类型名称
        /// </summary>
        public string M_Case_type_name
        {
            get { return m_Case_type_name; }
            set { m_Case_type_name = value; }
        }
        
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int M_Entry_Statistics_id
		{
			set{ _m_entry_statistics_id=value;}
			get{return _m_entry_statistics_id;}
		}
		/// <summary>
		/// 编码GUID
		/// </summary>
		public Guid? M_Entry_Statistics_code
		{
			set{ _m_entry_statistics_code=value;}
			get{return _m_entry_statistics_code;}
		}
		/// <summary>
		/// 案件GUID
		/// </summary>
		public Guid? M_Case_code
		{
			set{ _m_case_code=value;}
			get{return _m_case_code;}
		}
		/// <summary>
		/// 案件名称
		/// </summary>
		public string M_Case_name
		{
			set{ _m_case_name=value;}
			get{return _m_case_name;}
		}
        /// <summary>
        /// 案件类型
        /// </summary>
        public int? M_Case_type
        {
            get { return _m_case_type; }
            set { _m_case_type = value; }
        }
        /// <summary>
        /// 案件编码
        /// </summary>
        public string M_Case_number
        {
            get { return _m_case_number; }
            set { _m_case_number = value; }
        }
		/// <summary>
		/// 条目GUID
		/// </summary>
		public Guid? M_Entry_code
		{
			set{ _m_entry_code=value;}
			get{return _m_entry_code;}
		}
		/// <summary>
		/// 变更时长
		/// </summary>
		public int? M_Entry_Statistics_changeDuration
		{
			set{ _m_entry_statistics_changeduration=value;}
			get{return _m_entry_statistics_changeduration;}
		}
		/// <summary>
		/// 条目开始时间
		/// </summary>
		public DateTime? M_Entry_Statistics_entrySTime
		{
			set{ _m_entry_statistics_entrystime=value;}
			get{return _m_entry_statistics_entrystime;}
		}
		/// <summary>
		/// 条目结束时间
		/// </summary>
		public DateTime? M_Entry_Statistics_entryETime
		{
			set{ _m_entry_statistics_entryetime=value;}
			get{return _m_entry_statistics_entryetime;}
		}
        /// <summary>
        /// 条目统计状态，对应parameter表
        /// </summary>
        public int? M_Entry_Statistics_status
        {
            get { return _m_entry_statistics_status; }
            set { _m_entry_statistics_status = value; }
        }
        /// <summary>
        /// 预警情况：预警、非预警、手工结束
        /// </summary>
        public int? M_Entry_Statistics_warningSituation
        {
            get { return _m_entry_statistics_warningSituation; }
            set { _m_entry_statistics_warningSituation = value; }
        }

        /// <summary>
        /// 办案状态：“未开始”、“正进行”、“已超时”、“已结束”
        /// </summary>
        public int? M_Entry_Statistics_HandlingState
        {
            get { return _m_entry_statistics_HandlingState; }
            set { _m_entry_statistics_HandlingState = value; }
        }
        /// <summary>
        /// 办理情况
        /// </summary>
        public int? M_Entry_Statistics_Management
        {
            get { return _m_entry_statistics_Management; }
            set { _m_entry_statistics_Management = value; }
        }
        /// <summary>
        /// 办理情况1（虚拟字段）
        /// </summary>
        public int? M_Entry_Statistics_Management1
        {
            get { return _m_entry_statistics_Management1; }
            set { _m_entry_statistics_Management1 = value; }
        }
        
        
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? M_Entry_Statistics_isDelete
		{
			set{ _m_entry_statistics_isdelete=value;}
			get{return _m_entry_statistics_isdelete;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? M_Entry_Statistics_creator
		{
			set{ _m_entry_statistics_creator=value;}
			get{return _m_entry_statistics_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? M_Entry_Statistics_createTime
		{
			set{ _m_entry_statistics_createtime=value;}
			get{return _m_entry_statistics_createtime;}
		}
        /// <summary>
        /// 条目名称（虚拟字段）
        /// </summary>
        public string M_Entry_name
        {
            get { return _m_entry_name; }
            set { _m_entry_name = value; }
        }
        /// <summary>
        /// 标准时长（虚拟字段）
        /// </summary>
        public int? M_Entry_Duration
        {
            get { return _m_entry_Duration; }
            set { _m_entry_Duration = value; }
        }
        /// <summary>
        /// 预警类型（虚拟字段）
        /// </summary>
        public int? M_Entry_warningType
        {
            get { return _m_entry_warningType; }
            set { _m_entry_warningType = value; }
        }
        /// <summary>
        /// 预警时长（虚拟字段）
        /// </summary>
        public int? M_Entry_warningDuration
        {
            get { return _m_entry_warningDuration; }
            set { _m_entry_warningDuration = value; }
        }
        
		#endregion Model

	}
}

