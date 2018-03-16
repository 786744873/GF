using System;
namespace CommonService.Model
{
    /// <summary>
    /// 企业负责人表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
	[Serializable]
	public partial class C_CRival_person
	{
		public C_CRival_person()
		{}
		#region Model
		private int _c_crival_person_id;
		private Guid? _c_crival_code;
		private int? _c_crival_person_sex;
		private string _c_crival_person_name;
		private DateTime? _c_crival_person_birthday;
		private DateTime? _c_crival_person_ptime;
		private string _c_crival_person_contact;
		private string _c_crival_person_education;
		private string _c_crival_person_post;
		private string _c_crival_person_experience;
		private string _c_crival_person_story;
		private string _c_crival_person_url;
		private string _c_crival_person_other_person;
		private DateTime? _c_crival_person_craetetime;
		private Guid? _c_crival_person_creator;
		private int? _c_crival_person_isdelete;
		/// <summary>
		/// 对手企业负责人ID
		/// </summary>
		public int C_CRival_person_id
		{
			set{ _c_crival_person_id=value;}
			get{return _c_crival_person_id;}
		}
		/// <summary>
		/// 外键，公司对手编码
		/// </summary>
		public Guid? C_CRival_code
		{
			set{ _c_crival_code=value;}
			get{return _c_crival_code;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public int? C_CRival_person_sex
		{
			set{ _c_crival_person_sex=value;}
			get{return _c_crival_person_sex;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string C_CRival_person_name
		{
			set{ _c_crival_person_name=value;}
			get{return _c_crival_person_name;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime? C_CRival_person_birthday
		{
			set{ _c_crival_person_birthday=value;}
			get{return _c_crival_person_birthday;}
		}
		/// <summary>
		/// 任职时间
		/// </summary>
		public DateTime? C_CRival_person_ptime
		{
			set{ _c_crival_person_ptime=value;}
			get{return _c_crival_person_ptime;}
		}
		/// <summary>
		/// 联系方式
		/// </summary>
		public string C_CRival_person_contact
		{
			set{ _c_crival_person_contact=value;}
			get{return _c_crival_person_contact;}
		}
		/// <summary>
		/// 教育背景
		/// </summary>
		public string C_CRival_person_education
		{
			set{ _c_crival_person_education=value;}
			get{return _c_crival_person_education;}
		}
		/// <summary>
		/// 职务
		/// </summary>
		public string C_CRival_person_post
		{
			set{ _c_crival_person_post=value;}
			get{return _c_crival_person_post;}
		}
		/// <summary>
		/// 工作经历
		/// </summary>
		public string C_CRival_person_experience
		{
			set{ _c_crival_person_experience=value;}
			get{return _c_crival_person_experience;}
		}
		/// <summary>
		/// 个人事迹
		/// </summary>
		public string C_CRival_person_story
		{
			set{ _c_crival_person_story=value;}
			get{return _c_crival_person_story;}
		}
		/// <summary>
		/// 网页链接
		/// </summary>
		public string C_CRival_person_url
		{
			set{ _c_crival_person_url=value;}
			get{return _c_crival_person_url;}
		}
		/// <summary>
		/// 其他负责人
		/// </summary>
		public string C_CRival_person_other_person
		{
			set{ _c_crival_person_other_person=value;}
			get{return _c_crival_person_other_person;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_CRival_person_craeteTime
		{
			set{ _c_crival_person_craetetime=value;}
			get{return _c_crival_person_craetetime;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_CRival_person_creator
		{
			set{ _c_crival_person_creator=value;}
			get{return _c_crival_person_creator;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_CRival_person_isDelete
		{
			set{ _c_crival_person_isdelete=value;}
			get{return _c_crival_person_isdelete;}
		}
		#endregion Model

	}
}

