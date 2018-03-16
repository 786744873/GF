using System;
namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// 收入信息表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/06/19
    /// </summary>
	public partial class B_CaseRevenue
	{
		public B_CaseRevenue()
		{}
		#region Model
		private int _b_caserevenue_id;
		private Guid? _b_caserevenue_code;
        private Guid? _b_case_code;
		private int? _b_caserevenue_type;
        private string _b_caserevenue_type_name;
		private decimal? _b_caserevenue_amount;
		private DateTime? _b_caserevenue_incometime;
		private string _b_caserevenue_remarks;
		private Guid? _b_caserevenue_creator;
		private DateTime? _b_caserevenue_createtime;
		private int? _b_caserevenue_isdelete;
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int B_CaseRevenue_id
		{
			set{ _b_caserevenue_id=value;}
			get{return _b_caserevenue_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? B_CaseRevenue_code
		{
			set{ _b_caserevenue_code=value;}
			get{return _b_caserevenue_code;}
		}
        /// <summary>
        /// 关联案件GUID
        /// </summary>
        public Guid? B_Case_code
        {
            get { return _b_case_code; }
            set { _b_case_code = value; }
        }
		/// <summary>
		/// 收入类型，关联parameter表
		/// </summary>
		public int? B_CaseRevenue_type
		{
			set{ _b_caserevenue_type=value;}
			get{return _b_caserevenue_type;}
		}
        /// <summary>
        /// 收入类型名称（虚拟字段）
        /// </summary>
        public string B_CaseRevenue_type_name
        {
            get { return _b_caserevenue_type_name; }
            set { _b_caserevenue_type_name = value; }
        }
		/// <summary>
		/// 收入金额
		/// </summary>
		public decimal? B_CaseRevenue_amount
		{
			set{ _b_caserevenue_amount=value;}
			get{return _b_caserevenue_amount;}
		}
		/// <summary>
		/// 收入时间
		/// </summary>
		public DateTime? B_CaseRevenue_incomeTime
		{
			set{ _b_caserevenue_incometime=value;}
			get{return _b_caserevenue_incometime;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string B_CaseRevenue_remarks
		{
			set{ _b_caserevenue_remarks=value;}
			get{return _b_caserevenue_remarks;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? B_CaseRevenue_creator
		{
			set{ _b_caserevenue_creator=value;}
			get{return _b_caserevenue_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? B_CaseRevenue_createTime
		{
			set{ _b_caserevenue_createtime=value;}
			get{return _b_caserevenue_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? B_CaseRevenue_isDelete
		{
			set{ _b_caserevenue_isdelete=value;}
			get{return _b_caserevenue_isdelete;}
		}
		#endregion Model

	}
}

