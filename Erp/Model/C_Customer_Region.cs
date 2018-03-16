using System;
namespace CommonService.Model
{
    /// <summary>
    /// 客户区域关系表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/06/24
	[Serializable]
	public partial class C_Customer_Region
	{
		public C_Customer_Region()
		{}
		#region Model
		private int _c_customer_region_id;
		private Guid? _c_customer_region_customer;
		private Guid? _c_customer_region_relregion;
		private int? _c_customer_region_isdelete;
		private Guid? _c_customer_region_creator;
		private DateTime? _c_customer_region_createtime;
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int C_Customer_Region_Id
		{
			set{ _c_customer_region_id=value;}
			get{return _c_customer_region_id;}
		}
		/// <summary>
		/// 客户GUID
		/// </summary>
		public Guid? C_Customer_Region_customer
		{
			set{ _c_customer_region_customer=value;}
			get{return _c_customer_region_customer;}
		}
		/// <summary>
		/// 关联区域GUID
		/// </summary>
		public Guid? C_Customer_Region_relRegion
		{
			set{ _c_customer_region_relregion=value;}
			get{return _c_customer_region_relregion;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Customer_Region_isDelete
		{
			set{ _c_customer_region_isdelete=value;}
			get{return _c_customer_region_isdelete;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public Guid? C_Customer_Region_creator
		{
			set{ _c_customer_region_creator=value;}
			get{return _c_customer_region_creator;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? C_Customer_Region_createTime
		{
			set{ _c_customer_region_createtime=value;}
			get{return _c_customer_region_createtime;}
		}
		#endregion Model

	}
}

