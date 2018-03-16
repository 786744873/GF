using System;
namespace CommonService.Model.FlowManager
{
    /// <summary>
    /// 流程--表单中间表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	public partial class P_Flow_form
	{
		public P_Flow_form()
		{}
		#region Model
		public int _p_flow_form_id;
		public Guid? _p_flow_code;
        public string _p_flow_name;
		public Guid? _f_form_code;
        public string _f_form_chineseName;
		public Guid? _p_flow_form_creator;
		public DateTime? _p_flow_form_createtime;
		public int? _p_flow_form_isdelete;
        public int? _p_flow_form_isDefault;
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int P_Flow_form_id
		{
			set{ _p_flow_form_id=value;}
			get{return _p_flow_form_id;}
		}
		/// <summary>
		/// 流程GUID
		/// </summary>
		public Guid? P_Flow_code
		{
			set{ _p_flow_code=value;}
			get{return _p_flow_code;}
		}
        /// <summary>
        /// 流程名称（虚拟字段）
        /// </summary>
        public string P_Flow_name
        {
            get { return _p_flow_name; }
            set { _p_flow_name = value; }
        }
		/// <summary>
		/// 表单GUID
		/// </summary>
		public Guid? F_Form_code
		{
			set{ _f_form_code=value;}
			get{return _f_form_code;}
		}
        /// <summary>
        /// 表单中文名称（虚拟字段）
        /// </summary>
        public string F_Form_chineseName
        {
            get { return _f_form_chineseName; }
            set { _f_form_chineseName = value; }
        }
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? P_Flow_form_creator
		{
			set{ _p_flow_form_creator=value;}
			get{return _p_flow_form_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? P_Flow_form_createTime
		{
			set{ _p_flow_form_createtime=value;}
			get{return _p_flow_form_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? P_Flow_form_isDelete
		{
			set{ _p_flow_form_isdelete=value;}
			get{return _p_flow_form_isdelete;}
		}
        /// <summary>
        /// 是否默认
        /// </summary>
        public int? P_Flow_form_isDefault
        {
            get { return _p_flow_form_isDefault; }
            set { _p_flow_form_isDefault = value; }
        }
		#endregion Model

	}
}

