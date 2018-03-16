using System;
namespace CommonService.Model.KMS
{
	/// <summary>
	/// K_Resources_zambia:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class K_Resources_zambia
	{
		public K_Resources_zambia()
		{}
		#region Model
		private Guid? _k_resources_code;
		private Guid? _c_userinfo_code;
		private DateTime? _k_resources_zambia_createtime;
		private bool _k_resources_zambia_isdelete;
		private int? _k_resources_zambia_type;
		/// <summary>
		/// 
		/// </summary>
		public Guid? K_Resources_code
		{
			set{ _k_resources_code=value;}
			get{return _k_resources_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? C_Userinfo_code
		{
			set{ _c_userinfo_code=value;}
			get{return _c_userinfo_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? K_Resources_zambia_createTime
		{
			set{ _k_resources_zambia_createtime=value;}
			get{return _k_resources_zambia_createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool K_Resources_zambia_isDelete
		{
			set{ _k_resources_zambia_isdelete=value;}
			get{return _k_resources_zambia_isdelete;}
		}
		/// <summary>
		/// 类型，1支持，2反对
		/// </summary>
		public int? K_Resources_zambia_type
		{
			set{ _k_resources_zambia_type=value;}
			get{return _k_resources_zambia_type;}
		}
		#endregion Model

	}
}

