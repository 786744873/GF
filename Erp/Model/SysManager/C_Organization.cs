using System;
namespace CommonService.Model.SysManager
{
	/// <summary>
	/// 组织架构表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	[Serializable]
	public partial class C_Organization
	{
		public C_Organization()
		{}
		#region Model
		private int _c_organization_id;
		private Guid? _c_organization_code;
		private string _c_organization_name;
		private bool _c_organization_isdelete;
		private Guid? _c_organization_parent;
        private string _c_organization_parent_name;
		private Guid? _c_organization_creator;
		private DateTime? _c_organization_createtime;
		private string _c_organization_phone;
		private string _c_organization_fax;
		private string _c_organization_address;
		private string _c_organization_remark;
		private int? _c_organization_order;
		private int? _c_organization_level;
		private int? _c_organization_state;
        private Guid? _c_organization_Area;
        private bool _c_Organization_isMarketing;//是否营销团队
		/// <summary>
		/// 组织架构ID，主键，自增长
		/// </summary>
		public int C_Organization_id
		{
			set{ _c_organization_id=value;}
			get{return _c_organization_id;}
		}
		/// <summary>
		/// 组织架构编码GUID
		/// </summary>
		public Guid? C_Organization_code
		{
			set{ _c_organization_code=value;}
			get{return _c_organization_code;}
		}
		/// <summary>
		/// 组织架构名称
		/// </summary>
		public string C_Organization_name
		{
			set{ _c_organization_name=value;}
			get{return _c_organization_name;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool C_Organization_isDelete
		{
			set{ _c_organization_isdelete=value;}
			get{return _c_organization_isdelete;}
		}
		/// <summary>
		/// 父级组织架构
		/// </summary>
		public Guid? C_Organization_parent
		{
			set{ _c_organization_parent=value;}
			get{return _c_organization_parent;}
		}
        /// <summary>
        /// 父级组织架构名称
        /// </summary>
        public string C_Organization_parent_name
        {
            set { _c_organization_parent_name = value; }
            get { return _c_organization_parent_name; }
        }
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Organization_creator
		{
			set{ _c_organization_creator=value;}
			get{return _c_organization_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Organization_createTime
		{
			set{ _c_organization_createtime=value;}
			get{return _c_organization_createtime;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string C_Organization_phone
		{
			set{ _c_organization_phone=value;}
			get{return _c_organization_phone;}
		}
		/// <summary>
		/// 传真
		/// </summary>
		public string C_Organization_fax
		{
			set{ _c_organization_fax=value;}
			get{return _c_organization_fax;}
		}
		/// <summary>
		/// 联系地址
		/// </summary>
		public string C_Organization_address
		{
			set{ _c_organization_address=value;}
			get{return _c_organization_address;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string C_Organization_remark
		{
			set{ _c_organization_remark=value;}
			get{return _c_organization_remark;}
		}
		/// <summary>
		/// 显示顺序
		/// </summary>
		public int? C_Organization_order
		{
			set{ _c_organization_order=value;}
			get{return _c_organization_order;}
		}
		/// <summary>
		/// 级别
		/// </summary>
		public int? C_Organization_level
		{
			set{ _c_organization_level=value;}
			get{return _c_organization_level;}
		}
		/// <summary>
		/// 0-未启用，1-启用，2-禁用
		/// </summary>
		public int? C_Organization_state
		{
			set{ _c_organization_state=value;}
			get{return _c_organization_state;}
		}
        public Guid? C_Organization_Area {
            set { _c_organization_Area = value; }
            get { return _c_organization_Area; }
        }
        /// <summary>
        /// 是否营销团队
        /// </summary>
        public bool C_Organization_isMarketing
        {
            set { _c_Organization_isMarketing = value; }
            get { return _c_Organization_isMarketing; }
        }
		#endregion Model

	}
}

