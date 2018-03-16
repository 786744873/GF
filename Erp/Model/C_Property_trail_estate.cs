using System;
namespace CommonService.Model
{
    /// <summary>
    /// 财产线索房产表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
	[Serializable]
	public partial class C_Property_trail_estate
	{
		public C_Property_trail_estate()
		{}
		#region Model
		private int _c_property_trail_estate_id;
		private int? _c_property_trail_estate_type;
		private Guid? _c_property_trail_estate_belongs;
		private string _c_property_trail_estate_code;
		private string _c_property_trail_estate_license;
		private Guid? _c_property_trail_estate_creator;
		private DateTime? _c_property_trail_estate_createtime;
		private int? _c_property_trail_estate_isdelete;
		/// <summary>
		/// 房产财产线索ID
		/// </summary>
		public int C_Property_trail_estate_id
		{
			set{ _c_property_trail_estate_id=value;}
			get{return _c_property_trail_estate_id;}
		}
		/// <summary>
		/// 房产财产线索类型，外键，关联parameter表，比如对手财产状况、法官财产状况
		/// </summary>
		public int? C_Property_trail_estate_type
		{
			set{ _c_property_trail_estate_type=value;}
			get{return _c_property_trail_estate_type;}
		}
		/// <summary>
		/// 房产财产线索所属，比如联系人GUID、法官GUID等
		/// </summary>
		public Guid? C_Property_trail_estate_belongs
		{
			set{ _c_property_trail_estate_belongs=value;}
			get{return _c_property_trail_estate_belongs;}
		}
		/// <summary>
		/// 房产线索编码
		/// </summary>
		public string C_Property_trail_estate_code
		{
			set{ _c_property_trail_estate_code=value;}
			get{return _c_property_trail_estate_code;}
		}
		/// <summary>
		/// 房产证号
		/// </summary>
		public string C_Property_trail_estate_license
		{
			set{ _c_property_trail_estate_license=value;}
			get{return _c_property_trail_estate_license;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Property_trail_estate_creator
		{
			set{ _c_property_trail_estate_creator=value;}
			get{return _c_property_trail_estate_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Property_trail_estate_createTime
		{
			set{ _c_property_trail_estate_createtime=value;}
			get{return _c_property_trail_estate_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Property_trail_estate_isDelete
		{
			set{ _c_property_trail_estate_isdelete=value;}
			get{return _c_property_trail_estate_isdelete;}
		}
		#endregion Model

	}
}

