using System;
namespace CommonService.Model.Feedback
{
    /// <summary>
    /// 意见反馈表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/10/14
    /// </summary>
	[Serializable]
	public partial class C_Feedback
	{
		public C_Feedback()
		{}
		#region Model
		private int _c_feedback_id;
		private Guid? _c_feedback_code;
		private string _c_feedback_thepage;
		private int? _c_feedback_wantfunction;
        private string _c_feedback_wantfunctionName;
		private string _c_feedback_description;
		private int? _c_feedback_state;
        private string _c_feedback_stateName;
		private Guid? _c_feedback_applicant;
        private string _c_feedback_applicantName;
		private DateTime? _c_feedback_datetime;
		private Guid? _c_feedback_audiperson;
        private string _c_feedback_audipersonName;
		private DateTime? _c_feedback_auditime;
        private string _c_feedback_replyContent;
        private int? _c_feedback_Integral;
        
		/// <summary>
		/// 
		/// </summary>
		public int C_Feedback_id
		{
			set{ _c_feedback_id=value;}
			get{return _c_feedback_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? C_Feedback_code
		{
			set{ _c_feedback_code=value;}
			get{return _c_feedback_code;}
		}
		/// <summary>
		/// 所属页面
		/// </summary>
		public string C_Feedback_thePage
		{
			set{ _c_feedback_thepage=value;}
			get{return _c_feedback_thepage;}
		}
		/// <summary>
		/// 想要的功能
		/// </summary>
		public int? C_Feedback_wantFunction
		{
			set{ _c_feedback_wantfunction=value;}
			get{return _c_feedback_wantfunction;}
		}
        /// <summary>
        /// 功能名称（虚拟字段）
        /// </summary>
        public string C_Feedback_wantfunctionName
        {
            get { return _c_feedback_wantfunctionName; }
            set { _c_feedback_wantfunctionName = value; }
        }
        
		/// <summary>
		/// 意见描述
		/// </summary>
		public string C_Feedback_Description
		{
			set{ _c_feedback_description=value;}
			get{return _c_feedback_description;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int? C_Feedback_state
		{
			set{ _c_feedback_state=value;}
			get{return _c_feedback_state;}
		}
        /// <summary>
        /// 状态Name（虚拟字段）
        /// </summary>
        public string C_Feedback_stateName
        {
            get { return _c_feedback_stateName; }
            set { _c_feedback_stateName = value; }
        }
        
		/// <summary>
		/// 申请人
		/// </summary>
		public Guid? C_Feedback_applicant
		{
			set{ _c_feedback_applicant=value;}
			get{return _c_feedback_applicant;}
		}
        /// <summary>
        /// 申请人名称（虚拟字段）
        /// </summary>
        public string C_Feedback_applicantName
        {
            get { return _c_feedback_applicantName; }
            set { _c_feedback_applicantName = value; }
        }
        
		/// <summary>
		/// 申请时间
		/// </summary>
		public DateTime? C_Feedback_dateTime
		{
			set{ _c_feedback_datetime=value;}
			get{return _c_feedback_datetime;}
		}
		/// <summary>
		/// 审核人
		/// </summary>
		public Guid? C_Feedback_audiPerson
		{
			set{ _c_feedback_audiperson=value;}
			get{return _c_feedback_audiperson;}
		}
        /// <summary>
        /// 审核人名称（虚拟字段）
        /// </summary>
        public string C_Feedback_audipersonName
        {
            get { return _c_feedback_audipersonName; }
            set { _c_feedback_audipersonName = value; }
        }
        
		/// <summary>
		/// 审核时间
		/// </summary>
		public DateTime? C_Feedback_audiTime
		{
			set{ _c_feedback_auditime=value;}
			get{return _c_feedback_auditime;}
		}
        /// <summary>
        /// 回复内容
        /// </summary>
        public string C_Feedback_replyContent
        {
            get { return _c_feedback_replyContent; }
            set { _c_feedback_replyContent = value; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int? C_Feedback_Integral
        {
            get { return _c_feedback_Integral; }
            set { _c_feedback_Integral = value; }
        }
		#endregion Model

	}
}

