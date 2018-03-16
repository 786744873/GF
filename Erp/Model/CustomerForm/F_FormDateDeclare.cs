using System;
namespace CommonService.Model.CustomerForm
{
    /// <summary>
    /// 表单时间声明表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/06/08
    /// </summary>
	[Serializable]
	public partial class F_FormDateDeclare
	{
		public F_FormDateDeclare()
		{}
		#region Model
		private int? _f_formdatedeclare_id;
		private Guid? _f_formdatedeclare_code;
		private Guid? _f_formdatedeclare_formcode;
		private string _f_formdatedeclare_column;
		private string _f_formdatedeclare_name;
        private int? _f_formdatedeclare_type;
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int? F_FormDateDeclare_id
		{
			set{ _f_formdatedeclare_id=value;}
			get{return _f_formdatedeclare_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? F_FormDateDeclare_code
		{
			set{ _f_formdatedeclare_code=value;}
			get{return _f_formdatedeclare_code;}
		}
		/// <summary>
		/// 所属表单GUID
		/// </summary>
		public Guid? F_FormDateDeclare_formCode
		{
			set{ _f_formdatedeclare_formcode=value;}
			get{return _f_formdatedeclare_formcode;}
		}
		/// <summary>
		/// 字段名
		/// </summary>
		public string F_FormDateDeclare_column
		{
			set{ _f_formdatedeclare_column=value;}
			get{return _f_formdatedeclare_column;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string F_FormDateDeclare_name
		{
			set{ _f_formdatedeclare_name=value;}
			get{return _f_formdatedeclare_name;}
		}
        /// <summary>
        /// 0表单 1流程
        /// </summary>
        public int? F_FormDateDeclare_type
        {
            get { return _f_formdatedeclare_type; }
            set { _f_formdatedeclare_type = value; }
        }
		#endregion Model

	}
}

