using System;
namespace CommonService.Model.SysManager
{
	/// <summary>
    /// 菜单按钮表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	[Serializable]
	public partial class C_Menu_buttons
	{
		public C_Menu_buttons()
		{}
		#region Model
		private int _c_menu_buttons_id;
		private string _c_menu_buttons_name;
		private int? _c_menu_id;
		private int? _c_menu_buttons_order;
        private string _c_menu_buttons_url;
        private int? _c_menu_buttons_isdelete;
        private Guid? _c_menu_buttons_creator;
        private DateTime? _c_menu_buttons_createTime;
        
        
		/// <summary>
		/// 菜单ID，主键，自增长
		/// </summary>
		public int C_Menu_buttons_id
		{
			set{ _c_menu_buttons_id=value;}
			get{return _c_menu_buttons_id;}
		}
		/// <summary>
		/// 菜单按钮名称
		/// </summary>
		public string C_Menu_buttons_name
		{
			set{ _c_menu_buttons_name=value;}
			get{return _c_menu_buttons_name;}
		}
		/// <summary>
		/// 所属菜单
		/// </summary>
		public int? C_Menu_id
		{
			set{ _c_menu_id=value;}
			get{return _c_menu_id;}
		}
		/// <summary>
		/// 菜单顺序
		/// </summary>
		public int? C_Menu_buttons_order
		{
			set{ _c_menu_buttons_order=value;}
			get{return _c_menu_buttons_order;}
		}
        /// <summary>
        /// 菜单按钮所指url
        /// </summary>
        public string C_Menu_Buttons_url
        {
            get { return _c_menu_buttons_url; }
            set { _c_menu_buttons_url = value; }
        }
        
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? C_Menu_buttons_isdelete
        {
            get { return _c_menu_buttons_isdelete; }
            set { _c_menu_buttons_isdelete = value; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Menu_buttons_creator
        {
            get { return _c_menu_buttons_creator; }
            set { _c_menu_buttons_creator = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Menu_buttons_createTime
        {
            get { return _c_menu_buttons_createTime; }
            set { _c_menu_buttons_createTime = value; }
        }
		#endregion Model

	}
}

