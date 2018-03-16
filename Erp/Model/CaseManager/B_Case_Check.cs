using System;
namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// 案件结案审核表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/12/24
    /// </summary>
	[Serializable]
	public partial class B_Case_Check
	{
		public B_Case_Check()
		{}
		#region Model
		private int _b_case_check_id;
		private Guid? _b_case_check_code;
		private Guid? _b_case_confirm_code;
		private int? _b_case_check_state;
		private int? _b_case_check_type;
        private string _b_case_check_typeName;
		private Guid? _b_case_check_checkperson;
        private string _b_case_check_checkpersonName;
		private DateTime? _b_case_check_checktime;
		private string _b_case_check_suggestcontent;
		private int? _b_case_check_order;
		private Guid? _b_case_check_creator;
        private string _b_case_check_creatorName;
		private DateTime? _b_case_check_createtime;
		private bool _b_case_check_isdelete;
		/// <summary>
		/// 
		/// </summary>
		public int B_Case_Check_id
		{
			set{ _b_case_check_id=value;}
			get{return _b_case_check_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? B_Case_Check_code
		{
			set{ _b_case_check_code=value;}
			get{return _b_case_check_code;}
		}
		/// <summary>
		/// 关联结案确认GUID
		/// </summary>
		public Guid? B_Case_Confirm_code
		{
			set{ _b_case_confirm_code=value;}
			get{return _b_case_confirm_code;}
		}
		/// <summary>
		/// 状态（未开始、已开始、已通过、未通过）
		/// </summary>
		public int? B_Case_Check_State
		{
			set{ _b_case_check_state=value;}
			get{return _b_case_check_state;}
		}
		/// <summary>
		/// 类型（部长意见、首席意见、行政意见、财务意见、财务意见、人资意见）
		/// </summary>
		public int? B_Case_Check_Type
		{
			set{ _b_case_check_type=value;}
			get{return _b_case_check_type;}
		}
        /// <summary>
        /// 类型名称（虚拟字段）
        /// </summary>
        public string B_Case_Check_typeName
        {
            get { return _b_case_check_typeName; }
            set { _b_case_check_typeName = value; }
        }        
		/// <summary>
		/// 审核人
		/// </summary>
		public Guid? B_Case_Check_checkPerson
		{
			set{ _b_case_check_checkperson=value;}
			get{return _b_case_check_checkperson;}
		}
        /// <summary>
        /// 审核人名称（虚拟字段）
        /// </summary>
        public string B_Case_Check_checkpersonName
        {
            get { return _b_case_check_checkpersonName; }
            set { _b_case_check_checkpersonName = value; }
        }
        
		/// <summary>
		/// 审核时间
		/// </summary>
		public DateTime? B_Case_Check_checkTime
		{
			set{ _b_case_check_checktime=value;}
			get{return _b_case_check_checktime;}
		}
		/// <summary>
		/// 意见
		/// </summary>
		public string B_Case_Check_SuggestContent
		{
			set{ _b_case_check_suggestcontent=value;}
			get{return _b_case_check_suggestcontent;}
		}
		/// <summary>
		/// 顺序
		/// </summary>
		public int? B_Case_Check_order
		{
			set{ _b_case_check_order=value;}
			get{return _b_case_check_order;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? B_Case_Check_creator
		{
			set{ _b_case_check_creator=value;}
			get{return _b_case_check_creator;}
		}
        /// <summary>
        /// 创建人名称（虚拟字段）
        /// </summary>
        public string B_Case_Check_creatorName
        {
            get { return _b_case_check_creatorName; }
            set { _b_case_check_creatorName = value; }
        }        
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? B_Case_Check_createTime
		{
			set{ _b_case_check_createtime=value;}
			get{return _b_case_check_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool B_Case_Check_isDelete
		{
			set{ _b_case_check_isdelete=value;}
			get{return _b_case_check_isdelete;}
		}
		#endregion Model

	}
}

