using System;
namespace CommonService.Model.SysManager
{
	/// <summary>
    /// 角色表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	[Serializable]
	public partial class C_Roles
	{
		public C_Roles()
		{}
		#region Model
		private int _c_roles_id;
		private string _c_roles_name;
        private bool _c_roles_isRelated;
		private bool _c_roles_isdelete;
        private Guid? _c_roles_creator;
        private DateTime? _c_roles_createTime;


		/// <summary>
		/// 角色ID，主键，自增长
		/// </summary>
		public int C_Roles_id
		{
			set{ _c_roles_id=value;}
			get{return _c_roles_id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string C_Roles_name
		{
			set{ _c_roles_name=value;}
			get{return _c_roles_name;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool C_Roles_isDelete
		{
			set{ _c_roles_isdelete=value;}
			get{return _c_roles_isdelete;}
		}
        /// <summary>
        /// 是否已关联此角色(虚拟属性)
        /// </summary>
        public bool C_Roles_isRelated
        {
            set { _c_roles_isRelated = value; }
            get { return _c_roles_isRelated; }
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Roles_creator
        {
            get { return _c_roles_creator; }
            set { _c_roles_creator = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Roles_createTime
        {
            get { return _c_roles_createTime; }
            set { _c_roles_createTime = value; }
        }
		#endregion Model

	}
}

