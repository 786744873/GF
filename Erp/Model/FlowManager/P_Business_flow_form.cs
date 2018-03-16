using System;
namespace CommonService.Model.FlowManager
{
    /// <summary>
    /// 业务流程--表单中间表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
	public partial class P_Business_flow_form
	{
		public P_Business_flow_form()
		{}
		#region Model
		public int _p_business_flow_form_id;
        public Guid? _p_business_flow_form_code;
		public Guid? _p_business_flow_code;
		public Guid? _f_form_code;
        public int? _p_business_flow_form_order;
        public Guid? _p_business_flow_form_person;
        public string _p_business_flow_form_person_name;
        public int? _p_business_flow_form_isdefault;
        public int? _p_business_flow_form_status;
		public int? _p_business_flow_form_isdelete;
		public Guid? _p_business_flow_form_creator;
		public DateTime? _p_business_flow_form_createtime;
        public int? _p_business_flow_form_type;
        public Guid? _p_business_flow_form_propertyCode;
        public int? _p_business_flow_form_state;
        public string _f_form_chinesename;
        public string _responsiblepersonguids;
        public DateTime? _P_Business_flow_planStartTime;
        public DateTime? _P_Business_flow_planEndTime;
        public bool _p_Business_flow_form_isPlan;
        public bool isvalidate;

        /// <summary>
        /// 是否验证通过，App专用
        /// </summary>
        public bool Isvalidate
        {
            get { return isvalidate; }
            set { isvalidate = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? P_Business_flow_planStartTime
        {
            set { _P_Business_flow_planStartTime = value; }
            get { return _P_Business_flow_planStartTime; }
        }
        public DateTime? P_Business_flow_planEndTime
        {
            set { _P_Business_flow_planEndTime = value; }
            get { return _P_Business_flow_planEndTime; }
        }
        /// <summary>
		/// ID，主键，自增
		/// </summary>
		public int P_Business_flow_form_id
		{
			set{ _p_business_flow_form_id=value;}
			get{return _p_business_flow_form_id;}
		}
        /// <summary>
        /// 业务流程表单关联Guid
        /// </summary>
        public Guid? P_Business_flow_form_code
        {
            set { _p_business_flow_form_code = value; }
            get { return _p_business_flow_form_code; }
        }
		/// <summary>
		/// 业务流程GUID
		/// </summary>
		public Guid? P_Business_flow_code
		{
			set{ _p_business_flow_code=value;}
			get{return _p_business_flow_code;}
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
        /// 排序列
        /// </summary>
        public int? P_Business_flow_form_order
        {
            set { _p_business_flow_form_order = value; }
            get { return _p_business_flow_form_order; }
        }
        /// <summary>
        /// 表单负责人
        /// </summary>
        public Guid? P_Business_flow_form_person
        {
            set { _p_business_flow_form_person = value; }
            get { return _p_business_flow_form_person; }
        }

        /// <summary>
        /// 主办律师名称（虚拟字段）
        /// </summary>
        public string P_Business_flow_form_person_name
        {
            get { return _p_business_flow_form_person_name; }
            set { _p_business_flow_form_person_name = value; }
        }
        /// <summary>
        /// 是否默认表单
        /// </summary>
        public int? P_Business_flow_form_isDefault
        {
            get { return _p_business_flow_form_isdefault; }
            set { _p_business_flow_form_isdefault = value; }
        }
        /// <summary>
        /// 表单状态枚举，C_Parameters参数表
        /// </summary>
        public int? P_Business_flow_form_status
        {
            get { return _p_business_flow_form_status; }
            set { _p_business_flow_form_status = value; }
        }
        
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? P_Business_flow_form_isdelete
		{
			set{ _p_business_flow_form_isdelete=value;}
			get{return _p_business_flow_form_isdelete;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? P_Business_flow_form_creator
		{
			set{ _p_business_flow_form_creator=value;}
			get{return _p_business_flow_form_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? P_Business_flow_form_createTime
		{
			set{ _p_business_flow_form_createtime=value;}
			get{return _p_business_flow_form_createtime;}
		}
        /// <summary>
        /// 表单中文名称(虚拟属性)
        /// </summary>
        public string F_Form_chineseName
        {
            set { _f_form_chinesename = value; }
            get { return _f_form_chinesename; }
        }
        /// <summary>
        /// 表单类型(虚拟属性),目前支持类型：1代表普通编辑表单；2代表tab容器；3代表含有主子结构的表单；4代表含有子明细表单(暂时没有实现)
        /// </summary>
        public int? P_Business_flow_form_type
        {
            set { _p_business_flow_form_type = value; }
            get { return _p_business_flow_form_type; }
        }
        /// <summary>
        /// 表单一复合属性Guid(虚拟属性)比如："Tab容器"属性
        /// </summary>
        public Guid? P_Business_flow_form_propertyCode
        {
            set { _p_business_flow_form_propertyCode = value; }
            get { return _p_business_flow_form_propertyCode; }
        }


        /// <summary>
        /// 进行状态，关联parameter表
        /// </summary>
        public int? P_Business_flow_form_state
        {
            get { return _p_business_flow_form_state; }
            set { _p_business_flow_form_state = value; }
        }
        /// <summary>
        /// 表单负责人Guid串(虚拟属性)
        /// </summary>
        public string ResponsiblePersonGuids
        {
            get { return _responsiblepersonguids; }
            set { _responsiblepersonguids = value; }
        }
        public bool P_Business_flow_form_isPlan {
            get { return _p_Business_flow_form_isPlan; }
            set { _p_Business_flow_form_isPlan = value; }
        }
		#endregion Model

	}
}

