using System;
namespace CommonService.Model.SysManager
{
    /// <summary>
    /// 组织架构--岗位中间表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	[Serializable]
	public partial class C_Organization_post
	{
		public C_Organization_post()
		{}
		#region Model
		private int _c_organization_post_id;
        private Guid? _c_organization_post_code;
		private Guid? _c_post_code;
        private string _c_post_name;
		private Guid? _c_organization_code;
        private string _c_organization_name;
		private Guid? _c_organization_post_creator;
		private DateTime? _c_organization_post_createtime;
		private int? _c_organization_post_isdelete;
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int C_Organization_post_id
		{
			set{ _c_organization_post_id=value;}
			get{return _c_organization_post_id;}
		}
        /// <summary>
        /// 组织机构-岗位关联Guid
        /// </summary>
        public Guid? C_Organization_post_code
        {
            get { return _c_organization_post_code; }
            set { _c_organization_post_code = value; }
        }
        
		/// <summary>
		/// 岗位GUID
		/// </summary>
		public Guid? C_Post_code
		{
			set{ _c_post_code=value;}
			get{return _c_post_code;}
		}
        /// <summary>
        /// 岗位名称(虚拟属性)
        /// </summary>
        public string C_Post_name
        {
            set { _c_post_name = value; }
            get { return _c_post_name; }
        }

		/// <summary>
		/// 组织架构GUID
		/// </summary>
		public Guid? C_Organization_code
		{
			set{ _c_organization_code=value;}
			get{return _c_organization_code;}
		}
        /// <summary>
        /// 组织机构名称(虚拟属性)
        /// </summary>
        public string C_Organization_name
        {
            set { _c_organization_name = value; }
            get { return _c_organization_name; }
        }

		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Organization_post_creator
		{
			set{ _c_organization_post_creator=value;}
			get{return _c_organization_post_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Organization_post_createTime
		{
			set{ _c_organization_post_createtime=value;}
			get{return _c_organization_post_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Organization_post_isDelete
		{
			set{ _c_organization_post_isdelete=value;}
			get{return _c_organization_post_isdelete;}
		}
		#endregion Model

	}
}

