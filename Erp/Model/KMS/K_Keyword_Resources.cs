using System;
namespace CommonService.Model.KMS
{
	/// <summary>
    /// K_Keyword_Resources:关键字和资源中间表实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class K_Keyword_Resources
	{
		public K_Keyword_Resources()
		{}
		#region Model
		private Guid? _k_keyword_code;
		private Guid? _k_resources_code;
		/// <summary>
		/// 关键字guid
		/// </summary>
		public Guid? K_Keyword_code
		{
			set{ _k_keyword_code=value;}
			get{return _k_keyword_code;}
		}
		/// <summary>
		/// 资源code
		/// </summary>
		public Guid? K_Resources_code
		{
			set{ _k_resources_code=value;}
			get{return _k_resources_code;}
		}
		#endregion Model

	}
}

