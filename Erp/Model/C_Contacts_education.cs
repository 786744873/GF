using System;
namespace CommonService.Model
{
	/// <summary>
    /// 联系人教育背景:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_Contacts_education
	{
		public C_Contacts_education()
		{}
		#region Model
		private int _c_contacts_education_id;
		private Guid? _c_contacts_code;
		private string _c_contacts_education_number;
		private string _c_contacts_education_degree;
		private DateTime? _c_contacts_education_graduation_date;
		private string _c_contacts_education_school;
		private string _c_contacts_education_science;
		private Guid? _c_contacts_education_creator;
		private DateTime? _c_contacts_education_createtime;
		private int? _c_contacts_education_isdelete;
		/// <summary>
		/// 联系人教育背景ID
		/// </summary>
		public int C_Contacts_education_id
		{
			set{ _c_contacts_education_id=value;}
			get{return _c_contacts_education_id;}
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
		/// 教育背景编码，可定义规则添加（非GUID）
		/// </summary>
		public string C_Contacts_education_number
		{
			set{ _c_contacts_education_number=value;}
			get{return _c_contacts_education_number;}
		}
		/// <summary>
		/// 教育程度
		/// </summary>
		public string C_Contacts_education_degree
		{
			set{ _c_contacts_education_degree=value;}
			get{return _c_contacts_education_degree;}
		}
		/// <summary>
		/// 毕业时间
		/// </summary>
		public DateTime? C_Contacts_education_graduation_date
		{
			set{ _c_contacts_education_graduation_date=value;}
			get{return _c_contacts_education_graduation_date;}
		}
		/// <summary>
		/// 毕业学院
		/// </summary>
		public string C_Contacts_education_school
		{
			set{ _c_contacts_education_school=value;}
			get{return _c_contacts_education_school;}
		}
		/// <summary>
		/// 专业
		/// </summary>
		public string C_Contacts_education_science
		{
			set{ _c_contacts_education_science=value;}
			get{return _c_contacts_education_science;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Contacts_education_creator
		{
			set{ _c_contacts_education_creator=value;}
			get{return _c_contacts_education_creator;}
		}
		/// <summary>
		/// 创建 时间
		/// </summary>
		public DateTime? C_Contacts_education_createTime
		{
			set{ _c_contacts_education_createtime=value;}
			get{return _c_contacts_education_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Contacts_education_isDelete
		{
			set{ _c_contacts_education_isdelete=value;}
			get{return _c_contacts_education_isdelete;}
		}
		#endregion Model

	}
}

