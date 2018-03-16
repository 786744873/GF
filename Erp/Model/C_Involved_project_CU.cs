using System;
namespace CommonService.Model
{
    /// <summary>
    /// 涉案项目--建设单位关联表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
	[Serializable]
	public partial class C_Involved_project_CU
	{
		public C_Involved_project_CU()
		{}
		#region Model
		private int _c_involved_project_cu_id;
		private Guid? _c_involved_project_code;
		private Guid? _c_rival_code;
        private string _c_rival_name;
		private int? _c_rival_type;
		private int? _c_involved_project_cu_situation;
		private int? _c_involved_project_cu_bagstyle;
		private int? _c_involved_project_cu_fundssource;
		private int? _c_involved_project_cu_isdelete;
		private Guid? _c_involved_project_cu_creator;
		private DateTime? _c_involved_project_cu_createtime;
		/// <summary>
		/// 主键，自增长
		/// </summary>
		public int C_Involved_project_CU_id
		{
			set{ _c_involved_project_cu_id=value;}
			get{return _c_involved_project_cu_id;}
		}
		/// <summary>
		/// 涉案项目GUID
		/// </summary>
		public Guid? C_Involved_project_code
		{
			set{ _c_involved_project_code=value;}
			get{return _c_involved_project_code;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? C_Rival_code
		{
			set{ _c_rival_code=value;}
			get{return _c_rival_code;}
		}
        /// <summary>
        /// 建设单位名称(虚拟属性)
        /// </summary>
        public string Rival_name
        {
            get { return _c_rival_name; }
            set { _c_rival_name = value; }
        }
		/// <summary>
		/// 对手类型，此处不关联parameter，0-公司 1-个人
		/// </summary>
		public int? C_Rival_type
		{
			set{ _c_rival_type=value;}
			get{return _c_rival_type;}
		}
		/// <summary>
		/// 报建情况，关联parameter表，包含：合法、非法
		/// </summary>
		public int? C_Involved_project_CU_situation
		{
			set{ _c_involved_project_cu_situation=value;}
			get{return _c_involved_project_cu_situation;}
		}
		/// <summary>
		/// 发包形式，外键，parameter表，包含：业主直营、挂靠、项目承包、不详
		/// </summary>
		public int? C_Involved_project_CU_bagStyle
		{
			set{ _c_involved_project_cu_bagstyle=value;}
			get{return _c_involved_project_cu_bagstyle;}
		}
		/// <summary>
		/// 建设资金来源，外键，parameter表，包含：自筹、合资、国有投资、外资
		/// </summary>
		public int? C_Involved_project_CU_fundsSource
		{
			set{ _c_involved_project_cu_fundssource=value;}
			get{return _c_involved_project_cu_fundssource;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Involved_project_CU_isDelete
		{
			set{ _c_involved_project_cu_isdelete=value;}
			get{return _c_involved_project_cu_isdelete;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Involved_project_CU_creator
		{
			set{ _c_involved_project_cu_creator=value;}
			get{return _c_involved_project_cu_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Involved_project_CU_createTime
		{
			set{ _c_involved_project_cu_createtime=value;}
			get{return _c_involved_project_cu_createtime;}
		}
		#endregion Model

	}
}

