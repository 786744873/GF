using System;
namespace CommonService.Model.SysManager
{
	/// <summary>
    /// 角色----菜单中间表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	[Serializable]
	public partial class C_Role_menu
	{
		public C_Role_menu()
		{}
		#region Model
		private int? _c_roles_id;
		private int? _c_menu_id;
        private string _c_menu_name;
        private int? _c_menu_parent;
        
        
		/// <summary>
		/// 角色ID
		/// </summary>
		public int? C_Roles_id
		{
			set{ _c_roles_id=value;}
			get{return _c_roles_id;}
		}
		/// <summary>
		/// 菜单ID
		/// </summary>
		public int? C_Menu_id
		{
			set{ _c_menu_id=value;}
			get{return _c_menu_id;}
		}
        /// <summary>
        /// 菜单名称(虚拟属性)
        /// </summary>
        public string C_Menu_name
        {
            get { return _c_menu_name; }
            set { _c_menu_name = value; }
        }
        /// <summary>
        /// 父级菜单（虚拟属性）
        /// </summary>
        public int? C_Menu_parent
        {
            get { return _c_menu_parent; }
            set { _c_menu_parent = value; }
        }
		#endregion Model

	}
}

