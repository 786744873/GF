using System;
namespace CommonService.Model.BusinessChanceManager
{
    /// <summary>
    /// 商机表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/07/27
    /// </summary>
	[Serializable]
	public partial class B_BusinessChance
	{
		public B_BusinessChance()
		{}
		#region Model
		private int _b_businesschance_id;
		private string _b_businesschance_name;
		private string _b_businesschance_number;
		private Guid? _b_businesschance_code;
		private int? _b_businesschance_type;
		private int? _b_businesschance_case_nature;
		private int? _b_businesschance_customertype;
		private Guid? _b_businesschance_competitor;
		private DateTime? _b_businesschance_registertime;
        private DateTime? _b_businesschance_registerTime2;
		private DateTime? _b_businesschance_obtaintime;
		private decimal? _b_businesschance_expectedtarget;
		private string _b_businesschance_successprobability;
		private string _b_businesschance_outline;
		private string _b_businesschance_remark;
		private int? _b_businesschance_state;
        private int? _b_businesschance_checkstatus;
        private string _b_businesschance_checkstatus_name;
		private decimal? _b_businesschance_transfertargetmoney;
		private string _b_businesschance_transfertargetother;
		private decimal? _b_businesschance_execmoney;
        private decimal? _b_businesschance_execMoney2;
		private string _b_businesschance_execother;
		private decimal? _b_businesschance_expectedgrant;
		private Guid? _b_businesschance_courtfirst;
		private Guid? _b_businesschance_courtsecond;
		private Guid? _b_businesschance_courtexec;
		private Guid? _b_businesschance_trial;
		private string _b_businesschance_requirement;
		private Guid? _b_businesschance_person;
        private string _b_businesschance_personName;
		private DateTime? _b_businesschance_planstarttime;
		private DateTime? _b_businesschance_planendtime;
		private DateTime? _b_businesschance_factstarttime;
		private DateTime? _b_businesschance_factendtime;
		private Guid? _b_businesschance_creator;
		private DateTime? _b_businesschance_createtime;
		private int? _b_businesschance_isdelete;
        private string _b_businesschance_remarks;
        private Guid? _b_businesschance_firstClassResponsiblePerson;
        private string _b_businesschance_firstClassResponsiblePerson_name;
		private string _b_businesschance_consultant_code;
        private string _b_businessChance_consultant_name;
        private string _b_businessChance_customerTypeName;
        private string _b_businessChance_Customer_code;
        private string _b_businessChance_Customer_name;
        private string _b_businessChance_Competitor_name;
        private string _b_businessChance_Region_code;
        private string _b_businessChance_Region_name;
        private string _b_businessChance_Client_code;
        private string _b_businessChance_Client_name;
        private string _b_businessChance_courtFirstName;
        private string _b_businessChance_courtSecondName;
        private string _b_businessChance_courtExecName;
        private string _b_businessChance_Person_code;
        private string _b_businessChance_Person_name;
        private string _b_businessChance_Person_type;
        private string _b_businesschance_Project_code;
        private string _b_businesschance_Project_name;
        private string _b_businesschance_type_name;
        private string _b_businesschance_stage;
        private int _b_businesschance_oprationtype;
        private Guid? _b_businesschance_case_code;
        private string _b_businesschance_case_number;
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int B_BusinessChance_id
		{
			set{ _b_businesschance_id=value;}
			get{return _b_businesschance_id;}
		}
		/// <summary>
		/// 商机名称
		/// </summary>
		public string B_BusinessChance_name
		{
			set{ _b_businesschance_name=value;}
			get{return _b_businesschance_name;}
		}
		/// <summary>
		/// 商机编码，按照规则定义
		/// </summary>
		public string B_BusinessChance_number
		{
			set{ _b_businesschance_number=value;}
			get{return _b_businesschance_number;}
		}
		/// <summary>
		/// 商机GUID
		/// </summary>
		public Guid? B_BusinessChance_code
		{
			set{ _b_businesschance_code=value;}
			get{return _b_businesschance_code;}
		}
		/// <summary>
		/// 商机类型，外键，parameter表，比如钢材、架管、混凝土
		/// </summary>
		public int? B_BusinessChance_type
		{
			set{ _b_businesschance_type=value;}
			get{return _b_businesschance_type;}
		}
		/// <summary>
		/// 案件性质，外键，parameter表，比如类型案件、非类型案件
		/// </summary>
		public int? B_BusinessChance_Case_nature
		{
			set{ _b_businesschance_case_nature=value;}
			get{return _b_businesschance_case_nature;}
		}
		/// <summary>
		/// 客户类型，外键，parameter表，比如新客户、老客户
		/// </summary>
		public int? B_BusinessChance_customerType
		{
			set{ _b_businesschance_customertype=value;}
			get{return _b_businesschance_customertype;}
		}
		/// <summary>
		/// 竞争对手，关联竞争对手表
		/// </summary>
		public Guid? B_BusinessChance_Competitor
		{
			set{ _b_businesschance_competitor=value;}
			get{return _b_businesschance_competitor;}
		}
		/// <summary>
		/// 预收案时间，默认当前
		/// </summary>
		public DateTime? B_BusinessChance_registerTime
		{
			set{ _b_businesschance_registertime=value;}
			get{return _b_businesschance_registertime;}
		}
        /// <summary>
        /// 预收案时间2（虚拟字段）
        /// </summary>
        public DateTime? B_BusinessChance_registerTime2
        {
            get { return _b_businesschance_registerTime2; }
            set { _b_businesschance_registerTime2 = value; }
        }
		/// <summary>
		/// 商机获取时间
		/// </summary>
		public DateTime? B_BusinessChance_obtainTime
		{
			set{ _b_businesschance_obtaintime=value;}
			get{return _b_businesschance_obtaintime;}
		}
		/// <summary>
		/// 预期标的
		/// </summary>
		public decimal? B_BusinessChance_expectedTarget
		{
			set{ _b_businesschance_expectedtarget=value;}
			get{return _b_businesschance_expectedtarget;}
		}
		/// <summary>
		/// 成功概率
		/// </summary>
		public string B_BusinessChance_successProbability
		{
			set{ _b_businesschance_successprobability=value;}
			get{return _b_businesschance_successprobability;}
		}
		/// <summary>
		/// 商机概述
		/// </summary>
		public string B_BusinessChance_Outline
		{
			set{ _b_businesschance_outline=value;}
			get{return _b_businesschance_outline;}
		}
		/// <summary>
		/// 商机备注
		/// </summary>
		public string B_BusinessChance_remark
		{
			set{ _b_businesschance_remark=value;}
			get{return _b_businesschance_remark;}
		}
		/// <summary>
		/// 商机状态，外键，parameter表，比如未开始、正在进行、已超时、已完成
		/// </summary>
		public int? B_BusinessChance_state
		{
			set{ _b_businesschance_state=value;}
			get{return _b_businesschance_state;}
		}
        /// <summary>
        /// 商机审查状态,parameter表:审查中、已流失、已转案件
        /// </summary>
        public int? B_BusinessChance_checkStatus
        {
            set { _b_businesschance_checkstatus = value; }
            get { return _b_businesschance_checkstatus; }
        }

        /// <summary>
        /// 商机审查状态名称(虚拟属性),parameter表:审查中、已流失、已转案件
        /// </summary>
        public string B_BusinessChance_checkStatus_name
        {
            set { _b_businesschance_checkstatus_name = value; }
            get { return _b_businesschance_checkstatus_name; }
        }

		/// <summary>
		/// 移交标的，金额
		/// </summary>
		public decimal? B_BusinessChance_transferTargetMoney
		{
			set{ _b_businesschance_transfertargetmoney=value;}
			get{return _b_businesschance_transfertargetmoney;}
		}
		/// <summary>
		/// 移交标的其他
		/// </summary>
		public string B_BusinessChance_transferTargetOther
		{
			set{ _b_businesschance_transfertargetother=value;}
			get{return _b_businesschance_transfertargetother;}
		}
		/// <summary>
		/// 执行标的金额
		/// </summary>
		public decimal? B_BusinessChance_execMoney
		{
			set{ _b_businesschance_execmoney=value;}
			get{return _b_businesschance_execmoney;}
		}
        /// <summary>
        /// 执行标的金额2（虚拟字段）
        /// </summary>
        public decimal? B_BusinessChance_execMoney2
        {
            get { return _b_businesschance_execMoney2; }
            set { _b_businesschance_execMoney2 = value; }
        }        
		/// <summary>
		/// 执行标的其他
		/// </summary>
		public string B_BusinessChance_execOther
		{
			set{ _b_businesschance_execother=value;}
			get{return _b_businesschance_execother;}
		}
		/// <summary>
		/// 案件预期收益
		/// </summary>
		public decimal? B_BusinessChance_expectedGrant
		{
			set{ _b_businesschance_expectedgrant=value;}
			get{return _b_businesschance_expectedgrant;}
		}
		/// <summary>
		/// 一审管辖法院
		/// </summary>
		public Guid? B_BusinessChance_courtFirst
		{
			set{ _b_businesschance_courtfirst=value;}
			get{return _b_businesschance_courtfirst;}
		}
		/// <summary>
		/// 二审管辖法院
		/// </summary>
		public Guid? B_BusinessChance_courtSecond
		{
			set{ _b_businesschance_courtsecond=value;}
			get{return _b_businesschance_courtsecond;}
		}
		/// <summary>
		/// 执行管辖法院
		/// </summary>
		public Guid? B_BusinessChance_courtExec
		{
			set{ _b_businesschance_courtexec=value;}
			get{return _b_businesschance_courtexec;}
		}
		/// <summary>
		/// 审判监督法院
		/// </summary>
		public Guid? B_BusinessChance_Trial
		{
			set{ _b_businesschance_trial=value;}
			get{return _b_businesschance_trial;}
		}
		/// <summary>
		/// 其他要求
		/// </summary>
		public string B_BusinessChance_Requirement
		{
			set{ _b_businesschance_requirement=value;}
			get{return _b_businesschance_requirement;}
		}
		/// <summary>
		/// 负责人
		/// </summary>
		public Guid? B_BusinessChance_person
		{
			set{ _b_businesschance_person=value;}
			get{return _b_businesschance_person;}
		}
        /// <summary>
        /// 负责人名称（虚拟字段）
        /// </summary>
        public string B_Businesschance_personName
        {
            get { return _b_businesschance_personName; }
            set { _b_businesschance_personName = value; }
        }        
		/// <summary>
		/// 计划开始时间
		/// </summary>
		public DateTime? B_BusinessChance_planStartTime
		{
			set{ _b_businesschance_planstarttime=value;}
			get{return _b_businesschance_planstarttime;}
		}
		/// <summary>
		/// 计划结束时间
		/// </summary>
		public DateTime? B_BusinessChance_planEndTime
		{
			set{ _b_businesschance_planendtime=value;}
			get{return _b_businesschance_planendtime;}
		}
		/// <summary>
		/// 实际开始时间
		/// </summary>
		public DateTime? B_BusinessChance_factStartTime
		{
			set{ _b_businesschance_factstarttime=value;}
			get{return _b_businesschance_factstarttime;}
		}
		/// <summary>
		/// 实际结束时间
		/// </summary>
		public DateTime? B_BusinessChance_factEndTime
		{
			set{ _b_businesschance_factendtime=value;}
			get{return _b_businesschance_factendtime;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? B_BusinessChance_creator
		{
			set{ _b_businesschance_creator=value;}
			get{return _b_businesschance_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? B_BusinessChance_createTime
		{
			set{ _b_businesschance_createtime=value;}
			get{return _b_businesschance_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? B_BusinessChance_isDelete
		{
			set{ _b_businesschance_isdelete=value;}
			get{return _b_businesschance_isdelete;}
		}
        /// <summary>
        /// 备注
        /// </summary>
        public string B_BusinessChance_remarks
        {
            get { return _b_businesschance_remarks; }
            set { _b_businesschance_remarks = value; }
        }
        /// <summary>
        /// 一级负责人
        /// </summary>
        public Guid? B_BusinessChance_firstClassResponsiblePerson
        {
            get { return _b_businesschance_firstClassResponsiblePerson; }
            set { _b_businesschance_firstClassResponsiblePerson = value; }
        }
        /// <summary>
        /// 一级负责人名称（虚拟字段）
        /// </summary>
        public string B_BusinessChance_firstClassResponsiblePerson_name
        {
            get { return _b_businesschance_firstClassResponsiblePerson_name; }
            set { _b_businesschance_firstClassResponsiblePerson_name = value; }
        }        
		/// <summary>
		/// 销售顾问  外联用户表
		/// </summary>
		public string B_BusinessChance_consultant_code
		{
			set{ _b_businesschance_consultant_code=value;}
			get{return _b_businesschance_consultant_code;}
		}
        /// <summary>
        /// 专业顾问名称（虚拟字段）
        /// </summary>
        public string B_BusinessChance_consultant_name
        {
            get { return _b_businessChance_consultant_name; }
            set { _b_businessChance_consultant_name = value; }
        }
        /// <summary>
        /// 客户类型名称（虚拟字段）
        /// </summary>
        public string B_BusinessChance_customerTypeName
        {
            get { return _b_businessChance_customerTypeName; }
            set { _b_businessChance_customerTypeName = value; }
        }
        /// <summary>
        /// 关联客户Guid(虚拟字段)
        /// </summary>
        public string B_BusinessChance_Customer_code
        {
            get { return _b_businessChance_Customer_code; }
            set { _b_businessChance_Customer_code = value; }
        }
        /// <summary>
        /// 关联客户名称（虚拟字段）
        /// </summary>
        public string B_BusinessChance_Customer_name
        {
            get { return _b_businessChance_Customer_name; }
            set { _b_businessChance_Customer_name = value; }
        }
        /// <summary>
        /// 竞争对手名称（虚拟字段）
        /// </summary>
        public string B_BusinessChance_Competitor_name
        {
            get { return _b_businessChance_Competitor_name; }
            set { _b_businessChance_Competitor_name = value; }
        }
        /// <summary>
        /// 关联区域Guid（虚拟字段）
        /// </summary>
        public string B_BusinessChance_Region_code
        {
            get { return _b_businessChance_Region_code; }
            set { _b_businessChance_Region_code = value; }
        }
        /// <summary>
        /// 关联区域名称（虚拟字段）
        /// </summary>
        public string B_BusinessChance_Region_name
        {
            get { return _b_businessChance_Region_name; }
            set { _b_businessChance_Region_name = value; }
        }
        /// <summary>
        /// 关联委托人Guid（虚拟字段）
        /// </summary>
        public string B_BusinessChance_Client_code
        {
            get { return _b_businessChance_Client_code; }
            set { _b_businessChance_Client_code = value; }
        }
        /// <summary>
        /// 关联委托人名称（虚拟字段）
        /// </summary>
        public string B_BusinessChance_Client_name
        {
            get { return _b_businessChance_Client_name; }
            set { _b_businessChance_Client_name = value; }
        }
        /// <summary>
        /// 一审管辖法院名称(虚拟字段)
        /// </summary>
        public string B_BusinessChance_courtFirstName
        {
            get { return _b_businessChance_courtFirstName; }
            set { _b_businessChance_courtFirstName = value; }
        }
        /// <summary>
        /// 二审管辖法院名称(虚拟字段)
        /// </summary>
        public string B_BusinessChance_courtSecondName
        {
            get { return _b_businessChance_courtSecondName; }
            set { _b_businessChance_courtSecondName = value; }
        }
        /// <summary>
        /// 执行管辖法院名称(虚拟字段)
        /// </summary>
        public string B_BusinessChance_courtExecName
        {
            get { return _b_businessChance_courtExecName; }
            set { _b_businessChance_courtExecName = value; }
        }
        /// <summary>
        /// 关联当事人Guid（虚拟字段）
        /// </summary>
        public string B_BusinessChance_Person_code
        {
            get { return _b_businessChance_Person_code; }
            set { _b_businessChance_Person_code = value; }
        }
        /// <summary>
        /// 关联当事人名称（虚拟字段）
        /// </summary>
        public string B_BusinessChance_Person_name
        {
            get { return _b_businessChance_Person_name; }
            set { _b_businessChance_Person_name = value; }
        }
        /// <summary>
        /// 关联当事人类型（虚拟字段）
        /// </summary>
        public string B_BusinessChance_Person_type
        {
            get { return _b_businessChance_Person_type; }
            set { _b_businessChance_Person_type = value; }
        }
        /// <summary>
        /// 关联工程Guid（虚拟字段）
        /// </summary>
        public string B_BusinessChance_Project_code
        {
            get { return _b_businesschance_Project_code; }
            set { _b_businesschance_Project_code = value; }
        }
        /// <summary>
        /// 关联工程名称（虚拟字段）
        /// </summary>
        public string B_BusinessChance_Project_name
        {
            get { return _b_businesschance_Project_name; }
            set { _b_businesschance_Project_name = value; }
        }
        /// <summary>
        /// 商机类型名称（虚拟字段）
        /// </summary>
        public string B_BusinessChance_type_name
        {
            get { return _b_businesschance_type_name; }
            set { _b_businesschance_type_name = value; }
        }
        /// <summary>
        /// 办案阶段（虚拟字段）
        /// </summary>
        public string B_BusinessChance_stage
        {
            get { return _b_businesschance_stage; }
            set { _b_businesschance_stage = value; }
        }
        /// <summary>
        /// 操作类型（虚拟字段） 1、商机列表页面 2、其他页面
        /// </summary>
        public int B_BusinessChance_oprationtype
        {
            get { return _b_businesschance_oprationtype; }
            set { _b_businesschance_oprationtype = value; }
        }
        /// <summary>
        /// 所属案件Guid（虚拟字段）
        /// </summary>
        public Guid? B_BusinessChance_case_code
        {
            get { return _b_businesschance_case_code; }
            set { _b_businesschance_case_code = value; }
        }
        /// <summary>
        /// 所属案件编码（虚拟字段）
        /// </summary>
        public string B_BusinessChance_case_number
        {
            get { return _b_businesschance_case_number; }
            set { _b_businesschance_case_number = value; }
        }  
		#endregion Model

	}
}

