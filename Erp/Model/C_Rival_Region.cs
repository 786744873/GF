using System;
namespace CommonService.Model
{
    /// <summary>
    /// 对手关联区域表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/06/24
    /// </summary>
	[Serializable]
	public partial class C_Rival_Region
	{
		public C_Rival_Region()
		{}
		#region Model
		private int _c_rival_region_id;
		private Guid? _c_rival_region_rival;
		private Guid? _c_rival_region_relregion;
		private int? _c_rival_region_isdelete;
		private Guid? _c_rival_region_creator;
		private DateTime? _c_rival_region_createtime;
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int C_Rival_Region_Id
		{
			set{ _c_rival_region_id=value;}
			get{return _c_rival_region_id;}
		}
		/// <summary>
		/// 对手GUID
		/// </summary>
		public Guid? C_Rival_Region_rival
		{
			set{ _c_rival_region_rival=value;}
			get{return _c_rival_region_rival;}
		}
		/// <summary>
		/// 关联区域GUID
		/// </summary>
		public Guid? C_Rival_Region_relRegion
		{
			set{ _c_rival_region_relregion=value;}
			get{return _c_rival_region_relregion;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Rival_Region_isDelete
		{
			set{ _c_rival_region_isdelete=value;}
			get{return _c_rival_region_isdelete;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public Guid? C_Rival_Region_creator
		{
			set{ _c_rival_region_creator=value;}
			get{return _c_rival_region_creator;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? C_Rival_Region_createTime
		{
			set{ _c_rival_region_createtime=value;}
			get{return _c_rival_region_createtime;}
		}
		#endregion Model

	}
}

