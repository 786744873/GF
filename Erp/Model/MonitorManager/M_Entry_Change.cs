using System;
namespace CommonService.Model.MonitorManager
{
    /// <summary>
    /// 条目变更表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/06/12
    /// </summary>
	[Serializable]
	public partial class M_Entry_Change
	{
		public M_Entry_Change()
		{}
		#region Model
		private int _m_entry_change_id;
		private Guid? _m_entry_change_code;
		private Guid? _m_entry_statistics_code;
        private string _m_entry_statistics_handlingstate_name;
        private string _m_entry_statistics_warningsituation_name;
        private int? _m_entry_statistics_management;
		private string _m_entry_change_proposer;
		private DateTime? _m_entry_change_applicationtime;
		private int? _m_entry_change_applicationduration;
		private string _m_entry_change_applicationreason;
		private string _m_entry_change_approvalperson;
		private DateTime? _m_entry_change_approvaltime;
		private int? _m_entry_change_approvalduration;
        private int? _m_entry_change_approvalduration2;
		private string _m_entry_change_approvalreason;
        private int? _m_entry_change_IsThrough;
		private int? _m_entry_change_isdelete;
		private Guid? _m_entry_change_creator;
		private DateTime? _m_entry_change_createtime;
        private string _m_case_name;
        private string _m_case_number;
        private string _m_entry_name;
        private Guid? _m_Case_code;
        private Guid? _m_entry_change_Applicant;
        private Guid? _m_entry_change_Approval;
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int M_Entry_Change_id
		{
			set{ _m_entry_change_id=value;}
			get{return _m_entry_change_id;}
		}
		/// <summary>
		/// 编码GUID
		/// </summary>
		public Guid? M_Entry_Change_code
		{
			set{ _m_entry_change_code=value;}
			get{return _m_entry_change_code;}
		}
		/// <summary>
		/// 条目统计GUID
		/// </summary>
		public Guid? M_Entry_Statistics_code
		{
			set{ _m_entry_statistics_code=value;}
			get{return _m_entry_statistics_code;}
		}
        /// <summary>
        /// 条目统计办案状态名称(虚拟属性)
        /// </summary>
        public string M_Entry_Statistics_HandlingState_name
        {
            set { _m_entry_statistics_handlingstate_name = value; }
            get { return _m_entry_statistics_handlingstate_name; }
        }
        /// <summary>
        /// 条目统计预警情况名称(虚拟属性)
        /// </summary>
        public string M_Entry_Statistics_warningSituation_name
        {
            set { _m_entry_statistics_warningsituation_name = value; }
            get { return _m_entry_statistics_warningsituation_name; }
        }
        /// <summary>
        /// 条目统计办理情况(虚拟属性)
        /// </summary>
        public int? M_Entry_Statistics_Management
        {
            set { _m_entry_statistics_management = value; }
            get { return _m_entry_statistics_management; }
        }

		/// <summary>
		/// 变更申请人
		/// </summary>
		public string M_Entry_Change_proposer
		{
			set{ _m_entry_change_proposer=value;}
			get{return _m_entry_change_proposer;}
		}
		/// <summary>
		/// 变更申请时间
		/// </summary>
		public DateTime? M_Entry_Change_applicationTime
		{
			set{ _m_entry_change_applicationtime=value;}
			get{return _m_entry_change_applicationtime;}
		}
		/// <summary>
		/// 变更申请时长
		/// </summary>
		public int? M_Entry_Change_applicationDuration
		{
			set{ _m_entry_change_applicationduration=value;}
			get{return _m_entry_change_applicationduration;}
		}
		/// <summary>
		/// 变更理由
		/// </summary>
		public string M_Entry_Change_applicationReason
		{
			set{ _m_entry_change_applicationreason=value;}
			get{return _m_entry_change_applicationreason;}
		}
		/// <summary>
		/// 变更审批人
		/// </summary>
		public string M_Entry_Change_approvalPerson
		{
			set{ _m_entry_change_approvalperson=value;}
			get{return _m_entry_change_approvalperson;}
		}
		/// <summary>
		/// 变更审批时间
		/// </summary>
		public DateTime? M_Entry_Change_approvalTime
		{
			set{ _m_entry_change_approvaltime=value;}
			get{return _m_entry_change_approvaltime;}
		}
		/// <summary>
		/// 变更审批时长
		/// </summary>
		public int? M_Entry_Change_approvalDuration
		{
			set{ _m_entry_change_approvalduration=value;}
			get{return _m_entry_change_approvalduration;}
		}
        /// <summary>
        /// 变更审批时长
        /// </summary>
        public int? M_Entry_Change_approvalDuration2
        {
            set { _m_entry_change_approvalduration2 = value; }
            get { return _m_entry_change_approvalduration2; }
        }
		/// <summary>
		/// 审批理由
		/// </summary>
		public string M_Entry_Change_approvalReason
		{
			set{ _m_entry_change_approvalreason=value;}
			get{return _m_entry_change_approvalreason;}
		}
        /// <summary>
        /// 变更情况  未审批，通过，未通过  关联parameter表
        /// </summary>
        public int? M_Entry_Change_IsThrough
        {
            get { return _m_entry_change_IsThrough; }
            set { _m_entry_change_IsThrough = value; }
        }
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? M_Entry_Change_isDelete
		{
			set{ _m_entry_change_isdelete=value;}
			get{return _m_entry_change_isdelete;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? M_Entry_Change_creator
		{
			set{ _m_entry_change_creator=value;}
			get{return _m_entry_change_creator;}
		}
        ///案件Code
        public Guid? M_Case_code
        {
            set { _m_Case_code = value; }
            get { return _m_Case_code; }
        }
        
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? M_Entry_Change_createTime
		{
			set{ _m_entry_change_createtime=value;}
			get{return _m_entry_change_createtime;}
		}
        /// <summary>
        /// 案件名称（虚拟字段）
        /// </summary>
        public string M_Case_name
        {
            get { return _m_case_name; }
            set { _m_case_name = value; }
        }
        /// <summary>
        /// 案件编码（虚拟字段）
        /// </summary>
        public string M_Case_number
        {
            get { return _m_case_number; }
            set { _m_case_number = value; }
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
        /// 案件状态
        /// </summary>

        /// <summary>
        /// 变更申请人
        /// </summary>
        public Guid? M_Entry_Change_Applicant
        {
            get { return _m_entry_change_Applicant; }
            set { _m_entry_change_Applicant = value; }
        }
        /// <summary>
        /// 变更审批人
        /// </summary>
        public Guid? M_Entry_Change_Approval
        {
            get { return _m_entry_change_Approval; }
            set { _m_entry_change_Approval = value; }
        }
		#endregion Model

	}
}

