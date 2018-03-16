using System;
namespace CommonService.Model
{
    /// <summary>
    /// 财产线索股票表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/06
    /// </summary>
	[Serializable]
	public partial class C_Property_trail_stock
	{
		public C_Property_trail_stock()
		{}
		#region Model
		private int _c_property_trail_stock_id;
		private int? _c_property_trail_stock_type;
		private Guid? _c_property_trail_stock_belongs;
		private string _c_property_trail_stock_code;
		private string _c_property_trail_stock_name;
		private int? _c_property_trail_stock_count;
		private decimal? _c_property_trail_stock_price;
		private Guid? _c_property_trail_stock_creator;
		private DateTime? _c_property_trail_stock_createtime;
		private int? _c_property_trail_stock_isdelete;
		/// <summary>
		/// 股票财产线索ID
		/// </summary>
		public int C_Property_trail_stock_id
		{
			set{ _c_property_trail_stock_id=value;}
			get{return _c_property_trail_stock_id;}
		}
		/// <summary>
		/// 股票财产线索类型，外键，关联parameter表，比如对手财产状况、法官财产状况
		/// </summary>
		public int? C_Property_trail_stock_type
		{
			set{ _c_property_trail_stock_type=value;}
			get{return _c_property_trail_stock_type;}
		}
		/// <summary>
		/// 股票财产线索所属，比如联系人GUID、法官GUID等
		/// </summary>
		public Guid? C_Property_trail_stock_belongs
		{
			set{ _c_property_trail_stock_belongs=value;}
			get{return _c_property_trail_stock_belongs;}
		}
		/// <summary>
		/// 股票线索编码
		/// </summary>
		public string C_Property_trail_stock_code
		{
			set{ _c_property_trail_stock_code=value;}
			get{return _c_property_trail_stock_code;}
		}
		/// <summary>
		/// 股票公司名称
		/// </summary>
		public string C_Property_trail_stock_name
		{
			set{ _c_property_trail_stock_name=value;}
			get{return _c_property_trail_stock_name;}
		}
		/// <summary>
		/// 股数
		/// </summary>
		public int? C_Property_trail_stock_count
		{
			set{ _c_property_trail_stock_count=value;}
			get{return _c_property_trail_stock_count;}
		}
		/// <summary>
		/// 当日股价
		/// </summary>
		public decimal? C_Property_trail_stock_price
		{
			set{ _c_property_trail_stock_price=value;}
			get{return _c_property_trail_stock_price;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Property_trail_stock_creator
		{
			set{ _c_property_trail_stock_creator=value;}
			get{return _c_property_trail_stock_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Property_trail_stock_createTime
		{
			set{ _c_property_trail_stock_createtime=value;}
			get{return _c_property_trail_stock_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Property_trail_stock_isDelete
		{
			set{ _c_property_trail_stock_isdelete=value;}
			get{return _c_property_trail_stock_isdelete;}
		}
		#endregion Model

	}
}

