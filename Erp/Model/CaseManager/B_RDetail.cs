using System;
namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// 案件--收款明细表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/06/06
    /// </summary>
	[Serializable]
	public partial class B_RDetail
	{
		public B_RDetail()
		{}
		#region Model
		private int _b_rdetail_id;
		private Guid? _b_rdetail_code;
		private Guid? _b_case_code;
		private DateTime? _b_rdetail_data;
		private decimal? _b_rdetail_limit;
		private int? _b_rdetail_rtype;
		private int? _b_rdetail_ptype;
		private Guid? _b_rdetail_creator;
		private DateTime? _b_rdetail_createtime;
		private int? _b_rdetail_isdelete;
        private int? _b_rdetail_relationid;
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int B_RDetail_id
		{
			set{ _b_rdetail_id=value;}
			get{return _b_rdetail_id;}
		}
		/// <summary>
		/// 编码GUID
		/// </summary>
		public Guid? B_RDetail_code
		{
			set{ _b_rdetail_code=value;}
			get{return _b_rdetail_code;}
		}
		/// <summary>
		/// 所关联案件GUID
		/// </summary>
		public Guid? B_Case_code
		{
			set{ _b_case_code=value;}
			get{return _b_case_code;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime? B_RDetail_data
		{
			set{ _b_rdetail_data=value;}
			get{return _b_rdetail_data;}
		}
		/// <summary>
		/// 额度
		/// </summary>
		public decimal? B_RDetail_limit
		{
			set{ _b_rdetail_limit=value;}
			get{return _b_rdetail_limit;}
		}
		/// <summary>
		/// 收款分类，关联parameter表
		/// </summary>
		public int? B_RDetail_rtype
		{
			set{ _b_rdetail_rtype=value;}
			get{return _b_rdetail_rtype;}
		}
		/// <summary>
		/// 付款方式，关联parameter表
		/// </summary>
		public int? B_RDetail_ptype
		{
			set{ _b_rdetail_ptype=value;}
			get{return _b_rdetail_ptype;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? B_RDetail_creator
		{
			set{ _b_rdetail_creator=value;}
			get{return _b_rdetail_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? B_RDetail_createTime
		{
			set{ _b_rdetail_createtime=value;}
			get{return _b_rdetail_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? B_RDetail_isDelete
		{
			set{ _b_rdetail_isdelete=value;}
			get{return _b_rdetail_isdelete;}
		}
        /// <summary>
        /// 关联ID（虚拟字段）
        /// </summary>
        public int? B_RDetail_relationid
        {
            get { return _b_rdetail_relationid; }
            set { _b_rdetail_relationid = value; }
        }
		#endregion Model

	}
}

