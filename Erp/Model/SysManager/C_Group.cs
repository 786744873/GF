using System;
namespace CommonService.Model.SysManager
{
    /// <summary>
    /// 分组表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/28
    /// </summary>
	[Serializable]
	public partial class C_Group
	{
		public C_Group()
		{}
		#region Model
		private int _c_group_id;
        private Guid? _c_group_code;
		private int? _c_roles_id;
		private string _c_group_name;
		private Guid? _c_group_parent;
		private int? _c_group_isdelete;
		private Guid? _c_group_creator;
		private DateTime? _c_group_createtime;
		/// <summary>
		/// ID，自增，主键
		/// </summary>
		public int C_Group_id
		{
			set{ _c_group_id=value;}
			get{return _c_group_id;}
		}
        /// <summary>
        /// 分组表GUID
        /// </summary>
        public Guid? C_Group_code
        {
            get { return _c_group_code; }
            set { _c_group_code = value; }
        }
        
		/// <summary>
		/// 角色ID，关联角色
		/// </summary>
		public int? C_Roles_id
		{
			set{ _c_roles_id=value;}
			get{return _c_roles_id;}
		}
		/// <summary>
		/// 组名称
		/// </summary>
		public string C_Group_name
		{
			set{ _c_group_name=value;}
			get{return _c_group_name;}
		}
		/// <summary>
		/// 父级分组
		/// </summary>
		public Guid? C_Group_parent
		{
			set{ _c_group_parent=value;}
			get{return _c_group_parent;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Group_isDelete
		{
			set{ _c_group_isdelete=value;}
			get{return _c_group_isdelete;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Group_creator
		{
			set{ _c_group_creator=value;}
			get{return _c_group_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Group_createTime
		{
			set{ _c_group_createtime=value;}
			get{return _c_group_createtime;}
		}
		#endregion Model

	}
}

