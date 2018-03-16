using System;
namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// 案件--担保物约定表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/06/06
    /// </summary>
	[Serializable]
	public partial class B_Oppint
	{
		public B_Oppint()
		{}
		#region Model
		private int _b_oppint_id;
		private Guid? _b_oppint_code;
		private Guid? _b_case_code;
		private int? _b_oppint_guaranty;
		private decimal? _b_oppint_guarantyvalue;
		private string _b_oppint_coneed;
		private Guid? _b_oppint_creator;
		private DateTime? _b_oppint_createtime;
		private int? _b_oppint_isdelete;
        private string _b_oppint_guaranty_name;
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int B_Oppint_id
		{
			set{ _b_oppint_id=value;}
			get{return _b_oppint_id;}
		}
		/// <summary>
		/// 编码GUID
		/// </summary>
		public Guid? B_Oppint_code
		{
			set{ _b_oppint_code=value;}
			get{return _b_oppint_code;}
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
		/// 担保物,关联parameter表
		/// </summary>
		public int? B_Oppint_guaranty
		{
			set{ _b_oppint_guaranty=value;}
			get{return _b_oppint_guaranty;}
		}
		/// <summary>
		/// 担保物价值
		/// </summary>
		public decimal? B_Oppint_guarantyvalue
		{
			set{ _b_oppint_guarantyvalue=value;}
			get{return _b_oppint_guarantyvalue;}
		}
		/// <summary>
		/// 客户其他需求
		/// </summary>
		public string B_Oppint_coneed
		{
			set{ _b_oppint_coneed=value;}
			get{return _b_oppint_coneed;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? B_Oppint_creator
		{
			set{ _b_oppint_creator=value;}
			get{return _b_oppint_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? B_Oppint_createTime
		{
			set{ _b_oppint_createtime=value;}
			get{return _b_oppint_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? B_Oppint_isDelete
		{
			set{ _b_oppint_isdelete=value;}
			get{return _b_oppint_isdelete;}
		}
        /// <summary>
        /// 担保物名称（虚拟字段）
        /// </summary>
        public string B_Oppint_guaranty_name
        {
            get { return _b_oppint_guaranty_name; }
            set { _b_oppint_guaranty_name = value; }
        }
		#endregion Model

	}
}

