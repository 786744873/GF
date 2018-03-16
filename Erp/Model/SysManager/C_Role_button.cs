using System;
namespace CommonService.Model.SysManager
{
	/// <summary>
    /// 角色----按钮中间表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	[Serializable]
	public partial class C_Role_button
	{
		public C_Role_button()
		{}
		#region Model
		private int? _c_roles_id;
		private int? _c_menu_buttons_id;
        private string _c_menu_buttons_name;
        
		/// <summary>
		/// 角色ID
		/// </summary>
		public int? C_Roles_id
		{
			set{ _c_roles_id=value;}
			get{return _c_roles_id;}
		}
		/// <summary>
		/// 按钮ID
		/// </summary>
		public int? C_Menu_buttons_id
		{
			set{ _c_menu_buttons_id=value;}
			get{return _c_menu_buttons_id;}
		}
        /// <summary>
        /// 按钮名称(虚拟属性)
        /// </summary>
        public string C_Menu_buttons_name
        {
            get { return _c_menu_buttons_name; }
            set { _c_menu_buttons_name = value; }
        }
		#endregion Model

	}
}

