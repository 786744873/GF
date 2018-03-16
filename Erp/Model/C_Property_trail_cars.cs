using System;
namespace CommonService.Model
{
    /// <summary>
    /// 财产线索车辆表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
	[Serializable]
	public partial class C_Property_trail_cars
	{
		public C_Property_trail_cars()
		{}
		#region Model
		private int _c_property_trail_cars_id;
		private int? _c_property_trail_cars_type;
		private Guid? _c_property_trail_cars_belongs;
		private string _c_property_trail_cars_code;
		private string _c_property_trail_cars_models;
		private string _c_property_trail_cars_recode;
		private decimal? _c_property_trail_cars_price;
		private string _c_property_trail_cars_license;
		private DateTime? _c_property_trail_cars_buydate;
		private Guid? _c_property_trail_cars_creator;
		private DateTime? _c_property_trail_cars_createtime;
		private int? _c_property_trail_cars_isdelete;
		/// <summary>
		/// 车辆财产线索ID
		/// </summary>
		public int C_Property_trail_cars_id
		{
			set{ _c_property_trail_cars_id=value;}
			get{return _c_property_trail_cars_id;}
		}
		/// <summary>
		/// 车辆财产线索类型，外键，关联parameter表，比如对手财产状况、法官财产状况
		/// </summary>
		public int? C_Property_trail_cars_type
		{
			set{ _c_property_trail_cars_type=value;}
			get{return _c_property_trail_cars_type;}
		}
		/// <summary>
		/// 车辆财产线索所属，比如联系人GUID、法官GUID等
		/// </summary>
		public Guid? C_Property_trail_cars_belongs
		{
			set{ _c_property_trail_cars_belongs=value;}
			get{return _c_property_trail_cars_belongs;}
		}
		/// <summary>
		/// 车辆线索编码
		/// </summary>
		public string C_Property_trail_cars_code
		{
			set{ _c_property_trail_cars_code=value;}
			get{return _c_property_trail_cars_code;}
		}
		/// <summary>
		/// 车型
		/// </summary>
		public string C_Property_trail_cars_models
		{
			set{ _c_property_trail_cars_models=value;}
			get{return _c_property_trail_cars_models;}
		}
		/// <summary>
		/// 车辆登记号
		/// </summary>
		public string C_Property_trail_cars_reCode
		{
			set{ _c_property_trail_cars_recode=value;}
			get{return _c_property_trail_cars_recode;}
		}
		/// <summary>
		/// 当日股价 
		/// </summary>
		public decimal? C_Property_trail_cars_price
		{
			set{ _c_property_trail_cars_price=value;}
			get{return _c_property_trail_cars_price;}
		}
		/// <summary>
		/// 车牌号
		/// </summary>
		public string C_Property_trail_cars_license
		{
			set{ _c_property_trail_cars_license=value;}
			get{return _c_property_trail_cars_license;}
		}
		/// <summary>
		/// 车辆购买时间
		/// </summary>
		public DateTime? C_Property_trail_cars_buyDate
		{
			set{ _c_property_trail_cars_buydate=value;}
			get{return _c_property_trail_cars_buydate;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Property_trail_cars_creator
		{
			set{ _c_property_trail_cars_creator=value;}
			get{return _c_property_trail_cars_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Property_trail_cars_createTime
		{
			set{ _c_property_trail_cars_createtime=value;}
			get{return _c_property_trail_cars_createtime;}
		}
		/// <summary>
		/// 是否 删除
		/// </summary>
		public int? C_Property_trail_cars_isDelete
		{
			set{ _c_property_trail_cars_isdelete=value;}
			get{return _c_property_trail_cars_isdelete;}
		}
		#endregion Model

	}
}

