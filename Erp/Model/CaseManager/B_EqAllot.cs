using System;
namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// 案件--涉案合同权益分配表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/06/04
    /// </summary>
	[Serializable]
	public partial class B_EqAllot
	{
		public B_EqAllot()
		{}
		#region Model
		private int _b_eqallot_id;
		private Guid? _b_eqallot_code;
		private Guid? _b_case_code;
		private int? _b_eqallot_pright;
		private decimal? _b_eqallot_mvalue;
		private decimal? _b_eqallot_cusradio;
		private string _b_eqallot_explain;
		private Guid? _b_eqallot_creator;
		private DateTime? _b_eqallot_createtime;
		private int? _b_eqallot_isdelete;
        private string _b_eqallot_pright_name;
        private int? _b_case_type;
        private int? _b_eqallot_pright_id;
        private int? _b_eqallot_relationid;
        
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int B_EqAllot_id
		{
			set{ _b_eqallot_id=value;}
			get{return _b_eqallot_id;}
		}
		/// <summary>
		/// 编码GUID
		/// </summary>
		public Guid? B_EqAllot_code
		{
			set{ _b_eqallot_code=value;}
			get{return _b_eqallot_code;}
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
		/// 财产权利，关联parameter表
		/// </summary>
		public int? B_EqAllot_pright
		{
			set{ _b_eqallot_pright=value;}
			get{return _b_eqallot_pright;}
		}
		/// <summary>
		/// 金额/折合金额
		/// </summary>
		public decimal? B_EqAllot_mvalue
		{
			set{ _b_eqallot_mvalue=value;}
			get{return _b_eqallot_mvalue;}
		}
		/// <summary>
		/// 客户所得比例
		/// </summary>
		public decimal? B_EqAllot_cusradio
		{
			set{ _b_eqallot_cusradio=value;}
			get{return _b_eqallot_cusradio;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string B_EqAllot_explain
		{
			set{ _b_eqallot_explain=value;}
			get{return _b_eqallot_explain;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? B_EqAllot_creator
		{
			set{ _b_eqallot_creator=value;}
			get{return _b_eqallot_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? B_EqAllot_createTime
		{
			set{ _b_eqallot_createtime=value;}
			get{return _b_eqallot_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? B_EqAllot_isDelete
		{
			set{ _b_eqallot_isdelete=value;}
			get{return _b_eqallot_isdelete;}
		}
        /// <summary>
        /// 财产权利名称（虚拟属性）
        /// </summary>
        public string B_EqAllot_pright_name
        {
            get { return _b_eqallot_pright_name; }
            set { _b_eqallot_pright_name = value; }
        }
        /// <summary>
        /// 案件类型，关联parameter表(虚拟字段)
        /// </summary>
        public int? B_Case_type
        {
            get { return _b_case_type; }
            set { _b_case_type = value; }
        }
        /// <summary>
        /// 财产权利关联parameter表ID（虚拟字段）
        /// </summary>
        public int? B_EqAllot_pright_id
        {
            get { return _b_eqallot_pright_id; }
            set { _b_eqallot_pright_id = value; }
        }
        /// <summary>
        /// 关联ID（虚拟字段）
        /// </summary>
        public int? B_EqAllot_relationid
        {
            get { return _b_eqallot_relationid; }
            set { _b_eqallot_relationid = value; }
        }
		#endregion Model

	}
}

