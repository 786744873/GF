using System;
namespace CommonService.Model
{
    /// <summary>
    /// 区域表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	[Serializable]
	public partial class C_Region
	{
		public C_Region()
		{}
		#region Model
		private int _c_region_id;
		private Guid? _c_region_code;
		private string _c_region_name;
        private string _c_region_abbreviation;
		private Guid? _c_region_parent;
		private int? _c_region_level;
		private Guid? _c_region_creator;
		private DateTime? _c_region_createtime;
		private int? _c_region_isdelete;
        private int? _c_region_isSpecial;
        private bool _c_region_isRelated;
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int C_Region_Id
		{
			set{ _c_region_id=value;}
			get{return _c_region_id;}
		}
		/// <summary>
		/// 区域GUID
		/// </summary>
		public Guid? C_Region_code
		{
			set{ _c_region_code=value;}
			get{return _c_region_code;}
		}
		/// <summary>
		/// 区域名称
		/// </summary>
		public string C_Region_name
		{
			set{ _c_region_name=value;}
			get{return _c_region_name;}
		}
        /// <summary>
        /// 区域简称
        /// </summary>
        public string C_Region_abbreviation
        {
            get { return _c_region_abbreviation; }
            set { _c_region_abbreviation = value; }
        }
		/// <summary>
		/// 父级区域
		/// </summary>
		public Guid? C_Region_parent
		{
			set{ _c_region_parent=value;}
			get{return _c_region_parent;}
		}
		/// <summary>
		/// 区域级别
		/// </summary>
		public int? C_Region_level
		{
			set{ _c_region_level=value;}
			get{return _c_region_level;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public Guid? C_Region_creator
		{
			set{ _c_region_creator=value;}
			get{return _c_region_creator;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? C_Region_createTime
		{
			set{ _c_region_createtime=value;}
			get{return _c_region_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Region_isDelete
		{
			set{ _c_region_isdelete=value;}
			get{return _c_region_isdelete;}
		}
        /// <summary>
        /// 是否特殊
        /// </summary>
        public int? C_Region_isSpecial
        {
            get { return _c_region_isSpecial; }
            set { _c_region_isSpecial = value; }
        }
        /// <summary>
        /// 是否已关联了此区域(虚拟属性)
        /// </summary>
        public bool C_Region_isRelated
        {
            get { return _c_region_isRelated; }
            set { _c_region_isRelated = value; }
        }

		#endregion Model

	}
}

