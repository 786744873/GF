using System;
namespace CommonService.Model.KMS
{
	/// <summary>
    /// K_Knowledge:知识分类表实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class K_Knowledge
	{
		public K_Knowledge()
		{}
		#region Model
		private int _k_knowledge_id;
		private Guid? _k_knowledge_code;
		private string _k_knowledge_name;
		private Guid? _k_knowledge_parent;
        private string _k_knowledge_parentName;
		private DateTime? _k_knowledge_createtime;
		private Guid? _k_knowledge_creator;
        private string _k_knowledge_creatorName;
		private bool _k_knowledge_isdelete;
        private Guid? _k_knowledge_Person;
        private string _k_knowledge_PersonName;
        
		/// <summary>
		/// ID
		/// </summary>
		public int K_Knowledge_id
		{
			set{ _k_knowledge_id=value;}
			get{return _k_knowledge_id;}
		}
		/// <summary>
		/// 知识类型code
		/// </summary>
		public Guid? K_Knowledge_code
		{
			set{ _k_knowledge_code=value;}
			get{return _k_knowledge_code;}
		}
		/// <summary>
		/// 知识类型名称
		/// </summary>
		public string K_Knowledge_name
		{
			set{ _k_knowledge_name=value;}
			get{return _k_knowledge_name;}
		}
		/// <summary>
		/// 知识类型父级id
		/// </summary>
		public Guid? K_Knowledge_parent
		{
			set{ _k_knowledge_parent=value;}
			get{return _k_knowledge_parent;}
		}
        /// <summary>
        /// 父级名称（虚拟字段）
        /// </summary>
        public string K_Knowledge_parentName
        {
            get { return _k_knowledge_parentName; }
            set { _k_knowledge_parentName = value; }
        }        
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime? K_Knowledge_createTime
		{
			set{ _k_knowledge_createtime=value;}
			get{return _k_knowledge_createtime;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? K_Knowledge_creator
		{
			set{ _k_knowledge_creator=value;}
			get{return _k_knowledge_creator;}
		}
        /// <summary>
        /// 创建人名称（虚拟字段）
        /// </summary>
        public string K_Knowledge_creatorName
        {
            get { return _k_knowledge_creatorName; }
            set { _k_knowledge_creatorName = value; }
        }        
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool K_Knowledge_isDelete
		{
			set{ _k_knowledge_isdelete=value;}
			get{return _k_knowledge_isdelete;}
		}
        /// <summary>
        /// 负责人
        /// </summary>
        public Guid? K_Knowledge_Person
        {
            get { return _k_knowledge_Person; }
            set { _k_knowledge_Person = value; }
        }
        /// <summary>
        /// 负责人名称（虚拟字段）
        /// </summary>
        public string K_Knowledge_PersonName
        {
            get { return _k_knowledge_PersonName; }
            set { _k_knowledge_PersonName = value; }
        }
		#endregion Model

	}
}

