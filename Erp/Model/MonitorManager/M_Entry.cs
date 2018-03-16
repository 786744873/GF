using System;
namespace CommonService.Model.MonitorManager
{
    /// <summary>
    /// 条目表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/06/08
    /// </summary>
	[Serializable]
	public partial class M_Entry
	{
		public M_Entry()
		{}
		#region Model
		private int _m_entry_id;
		private Guid? _m_entry_code;
		private string _m_entry_name;
		private string _m_entry_sname;
		private string _m_entry_ename;
		private Guid? _m_entry_sflow;
		private Guid? _m_entry_eflow;
		private Guid? _m_entry_sform;
		private Guid? _m_entry_eform;
		private Guid? _m_entry_stime;
		private Guid? _m_entry_etime;
		private int? _m_entry_duration;
		private int? _m_entry_warningtype;
		private int? _m_entry_warningduration;
        private Guid? _m_entry_parent;
		private int? _m_entry_isdelete;
		private Guid? _m_entry_creator;
		private DateTime? _m_entry_createtime;
        private string _m_entry_scodes;
        private string _m_entry_ecodes;
        private string _m_entry_court;
        private string _m_entry_courtName;
        private int? _m_entry_processType;
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int M_Entry_id
		{
			set{ _m_entry_id=value;}
			get{return _m_entry_id;}
		}
		/// <summary>
		/// 条目编码GUID
		/// </summary>
		public Guid? M_Entry_code
		{
			set{ _m_entry_code=value;}
			get{return _m_entry_code;}
		}
		/// <summary>
		/// 条目名称
		/// </summary>
		public string M_Entry_name
		{
			set{ _m_entry_name=value;}
			get{return _m_entry_name;}
		}
		/// <summary>
		/// 起点名称
		/// </summary>
		public string M_Entry_sname
		{
			set{ _m_entry_sname=value;}
			get{return _m_entry_sname;}
		}
		/// <summary>
		/// 结点名称
		/// </summary>
		public string M_Entry_ename
		{
			set{ _m_entry_ename=value;}
			get{return _m_entry_ename;}
		}
		/// <summary>
		/// 起点流程
		/// </summary>
		public Guid? M_Entry_sFlow
		{
			set{ _m_entry_sflow=value;}
			get{return _m_entry_sflow;}
		}
		/// <summary>
		/// 结点流程
		/// </summary>
		public Guid? M_Entry_eFlow
		{
			set{ _m_entry_eflow=value;}
			get{return _m_entry_eflow;}
		}
		/// <summary>
		/// 起点表单
		/// </summary>
		public Guid? M_Entry_sForm
		{
			set{ _m_entry_sform=value;}
			get{return _m_entry_sform;}
		}
		/// <summary>
		/// 结点表单
		/// </summary>
		public Guid? M_Entry_eForm
		{
			set{ _m_entry_eform=value;}
			get{return _m_entry_eform;}
		}
		/// <summary>
		/// 起点时间
		/// </summary>
		public Guid? M_Entry_sTime
		{
			set{ _m_entry_stime=value;}
			get{return _m_entry_stime;}
		}
		/// <summary>
		/// 结点时间
		/// </summary>
		public Guid? M_Entry_eTime
		{
			set{ _m_entry_etime=value;}
			get{return _m_entry_etime;}
		}
		/// <summary>
		/// 标准时长
		/// </summary>
		public int? M_Entry_Duration
		{
			set{ _m_entry_duration=value;}
			get{return _m_entry_duration;}
		}
		/// <summary>
		/// 预警类型：条目发生前、条目发生后、条目标准时长结束前、条目标准时长结束后，parameter表
		/// </summary>
		public int? M_Entry_warningType
		{
			set{ _m_entry_warningtype=value;}
			get{return _m_entry_warningtype;}
		}
		/// <summary>
		/// 预警时长
		/// </summary>
		public int? M_Entry_warningDuration
		{
			set{ _m_entry_warningduration=value;}
			get{return _m_entry_warningduration;}
		}
        /// <summary>
        /// 父亲条目Guid，外键，本表
        /// </summary>
        public Guid? M_Entry_parent
        {
            set { _m_entry_parent = value; }
            get { return _m_entry_parent; }
        }
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? M_Entry_isDelete
		{
			set{ _m_entry_isdelete=value;}
			get{return _m_entry_isdelete;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? M_Entry_creator
		{
			set{ _m_entry_creator=value;}
			get{return _m_entry_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? M_Entry_createTime
		{
			set{ _m_entry_createtime=value;}
			get{return _m_entry_createtime;}
		}
        /// <summary>
        /// 起点时间关联GUID（虚拟字段）
        /// </summary>
        public string M_Entry_scodes
        {
            get { return _m_entry_scodes; }
            set { _m_entry_scodes = value; }
        }
        /// <summary>
        /// 结点时间关联GUID（虚拟字段）
        /// </summary>
        public string M_Entry_ecodes
        {
            get { return _m_entry_ecodes; }
            set { _m_entry_ecodes = value; }
        }
        /// <summary>
        /// 法院
        /// </summary>
        public string M_Entry_court
        {
            get { return _m_entry_court; }
            set { _m_entry_court = value; }
        }
        /// <summary>
        /// 法院名称（虚拟字段）
        /// </summary>
        public string M_Entry_courtName
        {
            get { return _m_entry_courtName; }
            set { _m_entry_courtName = value; }
        }
        /// <summary>
        /// 进程类型
        /// </summary>
        public int? M_Entry_processType
        {
            get { return _m_entry_processType; }
            set { _m_entry_processType = value; }
        }
        
		#endregion Model

	}
}

