using System;
namespace CommonService.Model.KMS
{
	/// <summary>
    /// K_Knowledge_Resources:知识分类和（资源，问吧）中间表实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class K_Knowledge_Resources
	{
		public K_Knowledge_Resources()
		{}
		#region Model
		private int _k_knowledge_resources_id;
		private Guid? _k_knowledge_resources_code;
		private int? _k_knowledge_resources_type;
		private Guid? _p_fk_code;
		private Guid? _k_knowledge_code;
		private Guid? _k_knowledge_resources_creator;
		private bool _k_knowledge_resources_isdelete;
		private DateTime? _k_knowledge_resources_createtime;
		/// <summary>
		/// 
		/// </summary>
		public int K_Knowledge_Resources_id
		{
			set{ _k_knowledge_resources_id=value;}
			get{return _k_knowledge_resources_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? K_Knowledge_Resources_code
		{
			set{ _k_knowledge_resources_code=value;}
			get{return _k_knowledge_resources_code;}
		}
		/// <summary>
		/// 外键,parament表，资源/问吧
		/// </summary>
		public int? K_Knowledge_Resources_type
		{
			set{ _k_knowledge_resources_type=value;}
			get{return _k_knowledge_resources_type;}
		}
		/// <summary>
		/// 外键，资源guid，问题guid
		/// </summary>
		public Guid? P_FK_code
		{
			set{ _p_fk_code=value;}
			get{return _p_fk_code;}
		}
		/// <summary>
		/// 知识类型guid
		/// </summary>
		public Guid? K_Knowledge_code
		{
			set{ _k_knowledge_code=value;}
			get{return _k_knowledge_code;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? K_Knowledge_Resources_creator
		{
			set{ _k_knowledge_resources_creator=value;}
			get{return _k_knowledge_resources_creator;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool K_Knowledge_Resources_isDelete
		{
			set{ _k_knowledge_resources_isdelete=value;}
			get{return _k_knowledge_resources_isdelete;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? K_Knowledge_Resources_createTime
		{
			set{ _k_knowledge_resources_createtime=value;}
			get{return _k_knowledge_resources_createtime;}
		}
		#endregion Model

	}
}

