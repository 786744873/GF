using System;
namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// 案件级别变更表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/12/16
    /// </summary>
	[Serializable]
	public partial class B_CaseLevelchange
	{
		public B_CaseLevelchange()
		{}
		#region Model
		private int _b_caselevelchange_id;
		private Guid? _b_caselevelchange_code;
		private Guid? _b_case_code;
		private int? _b_caselevelchange_type;
        private string _b_caselevelchange_typeName;
		private Guid? _b_caselevelchange_changerecord;
		private int? _b_caselevelchange_state;
		private bool _b_caselevelchange_isvalid;
		private Guid? _b_caselevelchange_creator;
        private string _b_caselevelchange_creatorName;
		private DateTime? _b_caselevelchange_createtime;
		private bool _b_caselevelchange_isdelete;
		/// <summary>
		/// 
		/// </summary>
		public int B_CaseLevelchange_id
		{
			set{ _b_caselevelchange_id=value;}
			get{return _b_caselevelchange_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? B_CaseLevelchange_code
		{
			set{ _b_caselevelchange_code=value;}
			get{return _b_caselevelchange_code;}
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
		/// 案件级别类型，关联Parameter表，（重案、大案、难案）
		/// </summary>
		public int? B_CaseLevelchange_type
		{
			set{ _b_caselevelchange_type=value;}
			get{return _b_caselevelchange_type;}
		}
        /// <summary>
        /// 案件级别类型名称（虚拟字段）
        /// </summary>
        public string B_CaseLevelchange_typeName
        {
            get { return _b_caselevelchange_typeName; }
            set { _b_caselevelchange_typeName = value; }
        }        
		/// <summary>
		/// 变更记录GUID
		/// </summary>
		public Guid? B_CaseLevelchange_changeRecord
		{
			set{ _b_caselevelchange_changerecord=value;}
			get{return _b_caselevelchange_changerecord;}
		}
		/// <summary>
		/// 状态，关联Parameter表，（通过、未通过、待审核）
		/// </summary>
		public int? B_CaseLevelchange_state
		{
			set{ _b_caselevelchange_state=value;}
			get{return _b_caselevelchange_state;}
		}
		/// <summary>
		/// 是否有效
		/// </summary>
		public bool B_CaseLevelchange_IsValid
		{
			set{ _b_caselevelchange_isvalid=value;}
			get{return _b_caselevelchange_isvalid;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? B_CaseLevelchange_creator
		{
			set{ _b_caselevelchange_creator=value;}
			get{return _b_caselevelchange_creator;}
		}
        /// <summary>
        /// 创建人名称（虚拟字段）
        /// </summary>
        public string B_CaseLevelchange_creatorName
        {
            get { return _b_caselevelchange_creatorName; }
            set { _b_caselevelchange_creatorName = value; }
        }        
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? B_CaseLevelchange_createTime
		{
			set{ _b_caselevelchange_createtime=value;}
			get{return _b_caselevelchange_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool B_CaseLevelchange_isDelete
		{
			set{ _b_caselevelchange_isdelete=value;}
			get{return _b_caselevelchange_isdelete;}
		}
		#endregion Model

	}
}

