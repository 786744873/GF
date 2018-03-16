using System;
namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// 案件级别变更记录表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/12/16
    /// </summary>
	[Serializable]
	public partial class B_CaseLevelChangeRecords
	{
		public B_CaseLevelChangeRecords()
		{}
		#region Model
		private int _b_caselevelchangerecords_id;
		private Guid? _b_caselevelchangerecords_code;
		private Guid? _b_case_code;
		private int? _b_caselevelchangerecords_type;
        private string _b_caselevelchangerecords_typeName;
		private DateTime? _b_caselevelchangerecords_applicationdata;
		private DateTime? _b_caselevelchangerecords_actualchangedate;
		private Guid? _b_caselevelchangerecords_applicationperson;
        private string _b_caselevelchangerecords_applicationpersonName;
		private Guid? _b_caselevelchangerecords_auditor;
        private string _b_caselevelchangerecords_auditorName;
		private string _b_caselevelchangerecords_conversionreasons;
		private bool _b_caselevelchangerecords_isaudit;
		private string _b_caselevelchangerecords_auditopinion;
		private Guid? _b_caseLevelchangeRecords_creator;
		private DateTime? _b_caseLevelchangeRecords_createTime;
        private bool _b_caseLevelchangeRecords_isDelete;
        private string _b_caseLevelchange_typeName;
        
		/// <summary>
		/// 
		/// </summary>
		public int B_CaseLevelChangeRecords_id
		{
			set{ _b_caselevelchangerecords_id=value;}
			get{return _b_caselevelchangerecords_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? B_CaseLevelChangeRecords_code
		{
			set{ _b_caselevelchangerecords_code=value;}
			get{return _b_caselevelchangerecords_code;}
		}
		/// <summary>
		/// 关联案件Guid
		/// </summary>
		public Guid? B_Case_code
		{
			set{ _b_case_code=value;}
			get{return _b_case_code;}
		}
		/// <summary>
		/// 类型，关联Parameter表，（手动、自动）
		/// </summary>
		public int? B_CaseLevelChangeRecords_type
		{
			set{ _b_caselevelchangerecords_type=value;}
			get{return _b_caselevelchangerecords_type;}
		}
        /// <summary>
        /// 类型名称（虚拟字段）
        /// </summary>
        public string B_CaseLevelChangeRecords_typeName
        {
            get { return _b_caselevelchangerecords_typeName; }
            set { _b_caselevelchangerecords_typeName = value; }
        }        
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime? B_CaseLevelChangeRecords_applicationData
		{
			set{ _b_caselevelchangerecords_applicationdata=value;}
			get{return _b_caselevelchangerecords_applicationdata;}
		}
		/// <summary>
		/// 实际变更日期
		/// </summary>
		public DateTime? B_CaseLevelChangeRecords_actualChangeDate
		{
			set{ _b_caselevelchangerecords_actualchangedate=value;}
			get{return _b_caselevelchangerecords_actualchangedate;}
		}
		/// <summary>
		/// 申请人
		/// </summary>
		public Guid? B_CaseLevelChangeRecords_applicationPerson
		{
			set{ _b_caselevelchangerecords_applicationperson=value;}
			get{return _b_caselevelchangerecords_applicationperson;}
		}
        /// <summary>
        /// 申请人名称（虚拟字段）
        /// </summary>
        public string B_CaseLevelChangeRecords_applicationPersonName
        {
            get { return _b_caselevelchangerecords_applicationpersonName; }
            set { _b_caselevelchangerecords_applicationpersonName = value; }
        }        
		/// <summary>
		/// 审核人
		/// </summary>
		public Guid? B_CaseLevelChangeRecords_auditor
		{
			set{ _b_caselevelchangerecords_auditor=value;}
			get{return _b_caselevelchangerecords_auditor;}
		}
        /// <summary>
        /// 审核人名称（虚拟字段）
        /// </summary>
        public string B_CaseLevelChangeRecords_auditorName
        {
            get { return _b_caselevelchangerecords_auditorName; }
            set { _b_caselevelchangerecords_auditorName = value; }
        }
        
		/// <summary>
		/// 转化原因
		/// </summary>
		public string B_CaseLevelChangeRecords_conversionReasons
		{
			set{ _b_caselevelchangerecords_conversionreasons=value;}
			get{return _b_caselevelchangerecords_conversionreasons;}
		}
		/// <summary>
		/// 是否审核
		/// </summary>
		public bool B_CaseLevelChangeRecords_isAudit
		{
			set{ _b_caselevelchangerecords_isaudit=value;}
			get{return _b_caselevelchangerecords_isaudit;}
		}
		/// <summary>
		/// 审核意见
		/// </summary>
		public string B_CaseLevelChangeRecords_auditOpinion
		{
			set{ _b_caselevelchangerecords_auditopinion=value;}
			get{return _b_caselevelchangerecords_auditopinion;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? B_CaseLevelChangeRecords_creator
		{
            set { _b_caseLevelchangeRecords_creator = value; }
            get { return _b_caseLevelchangeRecords_creator; }
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? B_CaseLevelChangeRecords_createTime
		{
            set { _b_caseLevelchangeRecords_createTime = value; }
            get { return _b_caseLevelchangeRecords_createTime; }
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool B_CaseLevelChangeRecords_isDelete
		{
			set{ _b_caseLevelchangeRecords_isDelete=value;}
			get{return _b_caseLevelchangeRecords_isDelete;}
		}
        /// <summary>
        /// 案件级别名称（虚拟字段）
        /// </summary>
        public string B_CaseLevelchange_typeName
        {
            get { return _b_caseLevelchange_typeName; }
            set { _b_caseLevelchange_typeName = value; }
        }
		#endregion Model

	}
}

