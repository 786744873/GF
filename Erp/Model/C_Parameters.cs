using System;
namespace CommonService.Model
{
	/// <summary>
	/// 参数表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：张东洋
    /// 日期：2015/04/18
	/// </summary>
	[Serializable]
	public partial class C_Parameters
	{
		public C_Parameters()
		{}
		#region Model
		private int _c_parameters_id;
		private string _c_parameters_name;
        private string _c_parameters_abbreviation;
		private int? _c_parameters_order;
        private int? _c_parameters_parent;
        private string _c_parameters_parent_name;
		private int? _c_parameters_isdelete;
		/// <summary>
		/// 参数ID
		/// </summary>
		public int C_Parameters_id
		{
			set{ _c_parameters_id=value;}
			get{return _c_parameters_id;}
		}
		/// <summary>
		/// 参数名称
		/// </summary>
		public string C_Parameters_name
		{
			set{ _c_parameters_name=value;}
			get{return _c_parameters_name;}
		}
        /// <summary>
        /// 参数简称
        /// </summary>
        public string C_Parameters_abbreviation
        {
            get { return _c_parameters_abbreviation; }
            set { _c_parameters_abbreviation = value; }
        }
		/// <summary>
		/// 参数排序
		/// </summary>
		public int? C_Parameters_order
		{
			set{ _c_parameters_order=value;}
			get{return _c_parameters_order;}
		}
		/// <summary>
		/// 父级参数ID
		/// </summary>
		public int? C_Parameters_parent
		{
			set{ _c_parameters_parent=value;}
			get{return _c_parameters_parent;}
		}
        /// <summary>
        /// 父级参数名称
        /// </summary>
        public string C_Parameters_parent_name
        {
            get { return _c_parameters_parent_name; }
            set { _c_parameters_parent_name = value; }
        }
        
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Parameters_isDelete
		{
			set{ _c_parameters_isdelete=value;}
			get{return _c_parameters_isdelete;}
		}
		#endregion Model

	}
}

