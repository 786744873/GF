using System;
namespace CommonService.Model.SysManager
{
    /// <summary>
    /// 岗位表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	[Serializable]
	public partial class C_Post
	{
		public C_Post()
		{}
		#region Model
		private int _c_post_id;
		private Guid? _c_post_code;
        private Guid? _c_post_group;
		private string _c_post_name;
		private Guid? _c_post_creator;
		private DateTime? _c_post_createtime;
		private int? _c_post_isdelete;
        private bool _c_post_ischeckted;
        private int? _c_post_roles_id;
		/// <summary>
		/// 岗位ID，主键，自增
		/// </summary>
		public int C_Post_id
		{
			set{ _c_post_id=value;}
			get{return _c_post_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? C_Post_code
		{
			set{ _c_post_code=value;}
			get{return _c_post_code;}
		}
        /// <summary>
        /// 所属分组，关联C_Group表
        /// </summary>
        public Guid? C_Post_group
        {
            get { return _c_post_group; }
            set { _c_post_group = value; }
        }
		/// <summary>
		/// 岗位名称（虚拟字段）
		/// </summary>
		public string C_Post_name
		{
			set{ _c_post_name=value;}
			get{return _c_post_name;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Post_creator
		{
			set{ _c_post_creator=value;}
			get{return _c_post_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Post_createTime
		{
			set{ _c_post_createtime=value;}
			get{return _c_post_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Post_isDelete
		{
			set{ _c_post_isdelete=value;}
			get{return _c_post_isdelete;}
		}
        /// <summary>
        /// 是否选中（虚拟字段）
        /// </summary>
        public bool C_Post_ischeckted
        {
            get { return _c_post_ischeckted; }
            set { _c_post_ischeckted = value; }
        }
        /// <summary>
        /// 虚拟字段（角色id）
        /// </summary>
        public int? C_Post_Roles_id
        {
            get { return _c_post_roles_id; }
            set { _c_post_roles_id = value; }
        }
		#endregion Model

	}
}

