using System;
namespace CommonService.Model
{
    /// <summary>
    /// 个人教育背景表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/07
    /// </summary>
	[Serializable]
	public partial class C_PRival_education
	{
		public C_PRival_education()
		{}
		#region Model
		private int _c_prival_education_id;
		private Guid? _c_prival_code;
		private string _c_prival_education_number;
		private string _c_prival_education_degree;
		private DateTime? _c_prival_education_graduation_date;
		private string _c_prival_education_school;
		private string _c_prival_education_science;
		private Guid? _c_prival_education_creator;
		private DateTime? _c_prival_education_createtime;
		private int? _c_prival_education_isdelete;
		/// <summary>
		/// 个人对手教育背景ID
		/// </summary>
		public int C_PRival_education_id
		{
			set{ _c_prival_education_id=value;}
			get{return _c_prival_education_id;}
		}
		/// <summary>
		/// 外键，联系人GUID
		/// </summary>
		public Guid? C_PRival_code
		{
			set{ _c_prival_code=value;}
			get{return _c_prival_code;}
		}
		/// <summary>
		/// 教育背景编码，可定义规则添加（非GUID）
		/// </summary>
		public string C_PRival_education_number
		{
			set{ _c_prival_education_number=value;}
			get{return _c_prival_education_number;}
		}
		/// <summary>
		/// 教育程度
		/// </summary>
		public string C_PRival_education_degree
		{
			set{ _c_prival_education_degree=value;}
			get{return _c_prival_education_degree;}
		}
		/// <summary>
		/// 毕业时间
		/// </summary>
		public DateTime? C_PRival_education_graduation_date
		{
			set{ _c_prival_education_graduation_date=value;}
			get{return _c_prival_education_graduation_date;}
		}
		/// <summary>
		/// 毕业学院
		/// </summary>
		public string C_PRival_education_school
		{
			set{ _c_prival_education_school=value;}
			get{return _c_prival_education_school;}
		}
		/// <summary>
		/// 专业
		/// </summary>
		public string C_PRival_education_science
		{
			set{ _c_prival_education_science=value;}
			get{return _c_prival_education_science;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_PRival_education_creator
		{
			set{ _c_prival_education_creator=value;}
			get{return _c_prival_education_creator;}
		}
		/// <summary>
		/// 创建 时间
		/// </summary>
		public DateTime? C_PRival_education_createTime
		{
			set{ _c_prival_education_createtime=value;}
			get{return _c_prival_education_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_PRival_education_isDelete
		{
			set{ _c_prival_education_isdelete=value;}
			get{return _c_prival_education_isdelete;}
		}
		#endregion Model

	}
}

