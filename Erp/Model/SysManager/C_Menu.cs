using System;
namespace CommonService.Model.SysManager
{
	/// <summary>
	/// 菜单表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	[Serializable]
	public partial class C_Menu
	{
		public C_Menu()
		{}
		#region Model
		private int _c_menu_id;
		private string _c_menu_name;
		private bool _c_menu_isdelete;
		private int? _c_menu_parent;
		private int? _c_menu_state;
		private string _c_menu_image;
		private int? _c_menu_type;
		private int? _c_menu_order;
		private string _c_menu_url;
        private Guid? _c_menu_creator;
        private DateTime? _c_menu_createTime;
        
        
		/// <summary>
		/// 菜单ID，主键，自增长
		/// </summary>
		public int C_Menu_id
		{
			set{ _c_menu_id=value;}
			get{return _c_menu_id;}
		}
		/// <summary>
		/// 菜单名称
		/// </summary>
		public string C_Menu_name
		{
			set{ _c_menu_name=value;}
			get{return _c_menu_name;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool C_Menu_isDelete
		{
			set{ _c_menu_isdelete=value;}
			get{return _c_menu_isdelete;}
		}
		/// <summary>
		/// 父级菜单
		/// </summary>
		public int? C_Menu_parent
		{
			set{ _c_menu_parent=value;}
			get{return _c_menu_parent;}
		}
		/// <summary>
		/// 0-未启用，1-启用，2-禁用
		/// </summary>
		public int? C_Menu_state
		{
			set{ _c_menu_state=value;}
			get{return _c_menu_state;}
		}
		/// <summary>
		/// 菜单图片
		/// </summary>
		public string C_Menu_image
		{
			set{ _c_menu_image=value;}
			get{return _c_menu_image;}
		}
		/// <summary>
		/// 菜单所属类型，比如：1-ERP，2-CRM
		/// </summary>
		public int? C_Menu_type
		{
			set{ _c_menu_type=value;}
			get{return _c_menu_type;}
		}
		/// <summary>
		/// 菜单顺序
		/// </summary>
		public int? C_Menu_order
		{
			set{ _c_menu_order=value;}
			get{return _c_menu_order;}
		}
		/// <summary>
		/// 菜单所指URL
		/// </summary>
		public string C_Menu_url
		{
			set{ _c_menu_url=value;}
			get{return _c_menu_url;}
		}
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Menu_creator
        {
            get { return _c_menu_creator; }
            set { _c_menu_creator = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Menu_createTime
        {
            get { return _c_menu_createTime; }
            set { _c_menu_createTime = value; }
        }
		#endregion Model

	}
}

