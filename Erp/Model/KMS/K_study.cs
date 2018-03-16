using System;
namespace CommonService.Model.KMS
{
	/// <summary>
    /// K_study:.学习表实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class K_study
	{
		public K_study()
		{}
		#region Model
		private int _k_study_id;
		private Guid? _k_study_code;
		private Guid? _k_resources_code;
        private string _k_resources_name;
		private DateTime? _k_study_createtime;
		private Guid? _k_study_creator;
		private bool _k_study_isdelete;
        private int? _k_resources_type;
        private string _k_resources_url;
        
		/// <summary>
		/// ID，自增长
		/// </summary>
		public int K_study_id
		{
			set{ _k_study_id=value;}
			get{return _k_study_id;}
		}
		/// <summary>
		/// guid
		/// </summary>
		public Guid? K_study_code
		{
			set{ _k_study_code=value;}
			get{return _k_study_code;}
		}
		/// <summary>
		/// 外键，关联资源表，所学资源guid
		/// </summary>
		public Guid? K_Resources_code
		{
			set{ _k_resources_code=value;}
			get{return _k_resources_code;}
		}
        /// <summary>
        /// 关联资源名称（虚拟字段）
        /// </summary>
        public string K_Resources_name
        {
            get { return _k_resources_name; }
            set { _k_resources_name = value; }
        }        
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime? K_study_createTime
		{
			set{ _k_study_createtime=value;}
			get{return _k_study_createtime;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? K_study_creator
		{
			set{ _k_study_creator=value;}
			get{return _k_study_creator;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool K_study_isDelete
		{
			set{ _k_study_isdelete=value;}
			get{return _k_study_isdelete;}
		}
        /// <summary>
        /// 资源类型（虚拟字段）
        /// </summary>
        public int? K_Resources_type
        {
            get { return _k_resources_type; }
            set { _k_resources_type = value; }
        }
        /// <summary>
        /// 资源Url（虚拟字段）
        /// </summary>
        public string K_Resources_url
        {
            get { return _k_resources_url; }
            set { _k_resources_url = value; }
        }
		#endregion Model

	}
}

