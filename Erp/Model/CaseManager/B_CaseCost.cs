using System;
namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// 成本信息表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/06/23
    /// </summary>
	[Serializable]
	public partial class B_CaseCost
	{
		public B_CaseCost()
		{}
		#region Model
		private int _b_casecost_id;
		private Guid? _b_casecost_code;
		private Guid? _b_case_code;
		private int? _b_casecost_type;
        private int? _b_casecost_type_id;
        private string _b_casecost_type_name;
		private decimal? _b_casecost_amount;
		private DateTime? _b_casecost_time;
		private string _b_casecost_remarks;
		private Guid? _b_casecost_creator;
		private DateTime? _b_casecost_createtime;
		private int? _b_casecost_isdelete;
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int B_CaseCost_id
		{
			set{ _b_casecost_id=value;}
			get{return _b_casecost_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? B_CaseCost_code
		{
			set{ _b_casecost_code=value;}
			get{return _b_casecost_code;}
		}
		/// <summary>
		/// 关联案件GUID
		/// </summary>
		public Guid? B_Case_code
		{
			set{ _b_case_code=value;}
			get{return _b_case_code;}
		}
		/// <summary>
		/// 成本类型，关联parameter表
		/// </summary>
		public int? B_CaseCost_type
		{
			set{ _b_casecost_type=value;}
			get{return _b_casecost_type;}
		}
        /// <summary>
        /// 成本类型ID（虚拟字段）
        /// </summary>
        public int? B_CaseCost_type_id
        {
            get { return _b_casecost_type_id; }
            set { _b_casecost_type_id = value; }
        }
        /// <summary>
        /// 成本类型名称（虚拟字段）
        /// </summary>
        public string B_CaseCost_type_name
        {
            get { return _b_casecost_type_name; }
            set { _b_casecost_type_name = value; }
        }
		/// <summary>
		/// 金额
		/// </summary>
		public decimal? B_CaseCost_amount
		{
			set{ _b_casecost_amount=value;}
			get{return _b_casecost_amount;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime? B_CaseCost_Time
		{
			set{ _b_casecost_time=value;}
			get{return _b_casecost_time;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string B_CaseCost_remarks
		{
			set{ _b_casecost_remarks=value;}
			get{return _b_casecost_remarks;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? B_CaseCost_creator
		{
			set{ _b_casecost_creator=value;}
			get{return _b_casecost_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? B_CaseCost_createTime
		{
			set{ _b_casecost_createtime=value;}
			get{return _b_casecost_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? B_CaseCost_isDelete
		{
			set{ _b_casecost_isdelete=value;}
			get{return _b_casecost_isdelete;}
		}
		#endregion Model

	}
}

