using System;
namespace CommonService.Model
{
	/// <summary>
    /// 联系人工作经历:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_Contacts_experience
	{
		public C_Contacts_experience()
		{}
		#region Model
		private int _c_contacts_experience_id;
		private Guid? _c_contacts_code;
		private string _c_contacts_experience_number;
		private string _c_contacts_experience_post;
		private DateTime? _c_contacts_experience_date;
		private string _c_contacts_experience_content;
		private Guid? _c_contacts_experience_creator;
		private DateTime? _c_contacts_experience_createtime;
		private int? _c_contacts_experience_isdelete;
		/// <summary>
		/// 工作经历ID
		/// </summary>
		public int C_Contacts_experience_id
		{
			set{ _c_contacts_experience_id=value;}
			get{return _c_contacts_experience_id;}
		}
		/// <summary>
		/// 外键，联系人GUID
		/// </summary>
		public Guid? C_Contacts_code
		{
			set{ _c_contacts_code=value;}
			get{return _c_contacts_code;}
		}
		/// <summary>
		/// 工作经历编码，可定义规则添加（非GUID）
		/// </summary>
		public string C_Contacts_experience_number
		{
			set{ _c_contacts_experience_number=value;}
			get{return _c_contacts_experience_number;}
		}
		/// <summary>
		/// 担任职务
		/// </summary>
		public string C_Contacts_experience_post
		{
			set{ _c_contacts_experience_post=value;}
			get{return _c_contacts_experience_post;}
		}
		/// <summary>
		/// 任职时间
		/// </summary>
		public DateTime? C_Contacts_experience_date
		{
			set{ _c_contacts_experience_date=value;}
			get{return _c_contacts_experience_date;}
		}
		/// <summary>
		/// 工作内容
		/// </summary>
		public string C_Contacts_experience_content
		{
			set{ _c_contacts_experience_content=value;}
			get{return _c_contacts_experience_content;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Contacts_experience_creator
		{
			set{ _c_contacts_experience_creator=value;}
			get{return _c_contacts_experience_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Contacts_experience_createTime
		{
			set{ _c_contacts_experience_createtime=value;}
			get{return _c_contacts_experience_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Contacts_experience_isDelete
		{
			set{ _c_contacts_experience_isdelete=value;}
			get{return _c_contacts_experience_isdelete;}
		}
		#endregion Model

	}
}

