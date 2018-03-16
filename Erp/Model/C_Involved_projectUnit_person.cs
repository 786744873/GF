using System;
namespace CommonService.Model
{
    /// <summary>
    /// 涉案工程人表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
	[Serializable]
	public partial class C_Involved_projectUnit_person
	{
		public C_Involved_projectUnit_person()
		{}
		#region Model
		private int _c_involved_projectunit_person_id;
		private Guid? _c_involved_projectunit_code;
		private Guid? _c_involved_projectunit_person_contacts;
		private Guid? _c_involved_projectunit_person_creator;
		private DateTime? _c_involved_projectunit_person_createtime;
		private int? _c_involved_projectunit_person_isdelete;
		/// <summary>
		/// 主键，自增长，ID
		/// </summary>
		public int C_Involved_projectUnit_person_id
		{
			set{ _c_involved_projectunit_person_id=value;}
			get{return _c_involved_projectunit_person_id;}
		}
		/// <summary>
		/// 关联单位GUID
		/// </summary>
		public Guid? C_Involved_projectUnit_code
		{
			set{ _c_involved_projectunit_code=value;}
			get{return _c_involved_projectunit_code;}
		}
		/// <summary>
		/// 关联联系人
		/// </summary>
		public Guid? C_Involved_projectUnit_person_contacts
		{
			set{ _c_involved_projectunit_person_contacts=value;}
			get{return _c_involved_projectunit_person_contacts;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Involved_projectUnit_person_creator
		{
			set{ _c_involved_projectunit_person_creator=value;}
			get{return _c_involved_projectunit_person_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Involved_projectUnit_person_createTime
		{
			set{ _c_involved_projectunit_person_createtime=value;}
			get{return _c_involved_projectunit_person_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Involved_projectUnit_person_isDelete
		{
			set{ _c_involved_projectunit_person_isdelete=value;}
			get{return _c_involved_projectunit_person_isdelete;}
		}
		#endregion Model

	}
}

