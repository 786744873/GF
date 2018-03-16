using System;
namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// 案件表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/12
    /// </summary>
	public partial class B_Case
	{
		public B_Case()
		{}
		#region Model
		public int _b_case_id;
		public string _b_case_name;
		public string _b_case_number;
		public Guid? _b_case_code;
		public string _b_case_contractno;
		public int? _b_case_type;
        public string _b_case_type_name;
		public int? _b_case_nature;
		public int? _b_case_customertype;
		public DateTime? _b_case_registertime;
        public DateTime? _b_case_registertime2;
		public string _b_case_remark;
		public int? _b_case_state;
        public string _b_case_state_name;
		public decimal? _b_case_transfertargetmoney;
		public string _b_case_transfertargetother;
		public decimal? _b_case_expectedgrant;
        public decimal? _b_case_expectedgrant2;
		public decimal? _b_case_execmoney;
        public decimal? _b_case_execmoney2;
        public decimal? _b_case_wenshuincome;
        public decimal? _b_case_yuqiincome;
		public string _b_case_execother;
        public Guid? _b_case_courtFirst;
        public string _b_case_courtFirstName;
        public Guid? _b_case_courtSecond;
        public string _b_case_courtSecondName;
        public Guid? _b_case_courtExec;
        public string _b_case_courtExecName;
        public Guid? _b_case_Trial;
        public string _b_case_TrialName;
        public string _b_case_Requirement;
        public string _b_case_Remarks;
        public Guid? _b_case_person;
        public string _b_case_personName;
        public Guid? _b_case_firstClassResponsiblePerson;
        public string _b_case_firstClassResponsiblePersonName;
        public DateTime? _b_case_planStartTime;
        public DateTime? _b_case_planEndTime;
        public DateTime? _b_case_factStartTime;
        public DateTime? _b_case_factEndTime;
		public Guid? _b_case_creator;
		public DateTime? _b_case_createtime;
		public int? _b_case_isdelete;
        public Guid? _b_case_businessChance_Code;
        public string _b_case_businessChance_Name;
        public string _c_customer_code;
        public string _c_customer_name;
        public string _c_client_code;
        public string _c_client_name;
        public string _c_person_code;
        public string _c_person_name;
        public string _c_person_type;
        public string _c_executer_code;
        public string _c_executer_name;
        public string _c_executer_type;
        public string _c_region_code;
        public string _c_region_name;
        public string _c_project_code;
        public string _c_project_name;
        public int? _b_case_oprationtype;
        public Guid? _b_case_relationCode;
        public Guid? _b_case_lawyerCode;
        public string _b_case_lawyerName;
        public string _b_base_btage;
        public string _b_base_rival_code;
        public Guid? _b_case_consultant_code;
        public string _b_base_btage_name;
        public string _b_base_rival_name;
        public string _b_consultant_code;
        public string  _b_case_consultant_name;
        public int? _b_case_levelType;
        public string _b_case_organizationCode;
        public string _b_case_organizationName;
        public string _p_business_flow_name;
        public string _f_form_name;
        public int? _ischeck;
        public string _ischeck2;
        public string _ischeck3;
        public int? _m_Entry_Statistics_Management;
        public int? _b_case_delay_entry_statistics_count;
        public int? _b_case_handlingstate_entry_statistics_count;
        public int? _b_case_warningsituation_entry_statistics_count;
        public bool _b_case_ischeckauthority;
        public DateTime? _b_case_suredateend;
        public DateTime? _b_case_suredate;
        public bool _b_case_issure;

        public Guid? _flow_code;
        private string _b_case_caseGrade;
        private int? _b_case_isNotAudited;
        private int? _b_case_Majordifficult;
        
        /// <summary>
        /// 监控中心的查询条件（App专用查询条件）
        /// </summary>
        public Guid? Flow_code
        {
            get { return _flow_code; }
            set { _flow_code = value; }
        }

        public DateTime? B_Case_sureDateEnd
        {
            get { return _b_case_suredateend; }
            set { _b_case_suredateend = value; }
        }
        /// <summary>
        /// 确认时间（首席确认案件时间）
        /// </summary>
        public DateTime? B_Case_sureDate
        {
            get { return _b_case_suredate; }
            set { _b_case_suredate = value; }
        }
        
        /// <summary>
        /// 是否确认（首席是否已确认案件）
        /// </summary>
        public bool B_Case_isSure
        {
            get { return _b_case_issure; }
            set { _b_case_issure = value; }
        }

		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int B_Case_id
		{
			set{ _b_case_id=value;}
			get{return _b_case_id;}
		}
		/// <summary>
		/// 案件名称
		/// </summary>
		public string B_Case_name
		{
			set{ _b_case_name=value;}
			get{return _b_case_name;}
		}
		/// <summary>
		/// 案件编码，按照规则定义
		/// </summary>
		public string B_Case_number
		{
			set{ _b_case_number=value;}
			get{return _b_case_number;}
		}
        /// <summary>
        /// 销售顾问
        /// </summary>
        public Guid? B_Case_consultant_code
        {
           	set{ _b_case_consultant_code=value;}
			get{return _b_case_consultant_code;}
        }
        /// <summary>
        /// 销售顾问Guid（虚拟字段）
        /// </summary>
        public string B_Consultant_code
        {
            get { return _b_consultant_code; }
            set { _b_consultant_code = value; }
        }
        
        /// <summary>
        /// 销售顾问名称（虚拟字段）
        /// </summary>
        public string B_Case_consultant_name
        {
            set { _b_case_consultant_name = value; }
            get { return _b_case_consultant_name; }
        }
		/// <summary>
		/// 案件GUID
		/// </summary>
		public Guid? B_Case_code
		{
			set{ _b_case_code=value;}
			get{return _b_case_code;}
		}
		/// <summary>
		/// 合同编号
		/// </summary>
		public string B_Case_contractNo
		{
			set{ _b_case_contractno=value;}
			get{return _b_case_contractno;}
		}
		/// <summary>
		/// 案件类型，外键，parameter表，比如钢材、架管、混凝土
		/// </summary>
		public int? B_Case_type
		{
			set{ _b_case_type=value;}
			get{return _b_case_type;}
		}
        /// <summary>
        /// 案件类型名称(虚拟属性)
        /// </summary>
        public string B_Case_type_name
        {
            set { _b_case_type_name = value; }
            get { return _b_case_type_name; }
        }

		/// <summary>
		/// 案件性质，外键，parameter表，比如类型案件、非类型案件
		/// </summary>
		public int? B_Case_nature
		{
			set{ _b_case_nature=value;}
			get{return _b_case_nature;}
		}
		/// <summary>
		/// 客户类型，外键，parameter表，比如新客户、老客户
		/// </summary>
		public int? B_Case_customerType
		{
			set{ _b_case_customertype=value;}
			get{return _b_case_customertype;}
		}
		/// <summary>
		/// 预收案时间，默认当前
		/// </summary>
		public DateTime? B_Case_registerTime
		{
			set{ _b_case_registertime=value;}
			get{return _b_case_registertime;}
		}
        /// <summary>
        /// 预收案时间，默认当前(虚拟字段)
        /// </summary>
        public DateTime? B_Case_registerTime2
        {
            set { _b_case_registertime2 = value; }
            get { return _b_case_registertime2; }
        }
		/// <summary>
		/// 案件备注
		/// </summary>
		public string B_Case_remark
		{
			set{ _b_case_remark=value;}
			get{return _b_case_remark;}
		}
		/// <summary>
		/// 案件状态，取参数表
		/// </summary>
		public int? B_Case_state
		{
			set{ _b_case_state=value;}
			get{return _b_case_state;}
		}

        /// <summary>
        /// 案件状态名称(虚拟属性)
        /// </summary>
        public string B_Case_state_name
        {
            set { _b_case_state_name = value; }
            get { return _b_case_state_name; }
        }

		/// <summary>
		/// 移交标的，金额
		/// </summary>
		public decimal? B_Case_transferTargetMoney
		{
			set{ _b_case_transfertargetmoney=value;}
			get{return _b_case_transfertargetmoney;}
		}
		/// <summary>
		/// 移交标的其他
		/// </summary>
		public string B_Case_transferTargetOther
		{
			set{ _b_case_transfertargetother=value;}
			get{return _b_case_transfertargetother;}
		}
		/// <summary>
		/// 业务预期收益
		/// </summary>
		public decimal? B_Case_expectedGrant
		{
			set{ _b_case_expectedgrant=value;}
			get{return _b_case_expectedgrant;}
		}
        /// <summary>
        /// 业务预期收益
        /// </summary>
        public decimal? B_Case_expectedGrant2
        {
            set { _b_case_expectedgrant2 = value; }
            get { return _b_case_expectedgrant2; }
        }
		/// <summary>
		/// 执行标的金额
		/// </summary>
		public decimal? B_Case_execMoney
		{
			set{ _b_case_execmoney=value;}
			get{return _b_case_execmoney;}
		}
        /// <summary>
        /// 执行标的金额2(虚拟字段)
        /// </summary>
        public decimal? B_Case_execMoney2
        {
            set { _b_case_execmoney2 = value; }
            get { return _b_case_execmoney2; }
        }
        /// <summary>
        /// 案件文书收入(虚拟属性)
        /// </summary>
        public decimal? B_Case_wenshuInCome
        {
            set { _b_case_wenshuincome = value; }
            get { return _b_case_wenshuincome; }
        }
        /// <summary>
        /// 案件逾期收入(虚拟属性)
        /// </summary>
        public decimal? B_Case_yuqiInCome
        {
            set { _b_case_yuqiincome = value; }
            get { return _b_case_yuqiincome; }
        }

		/// <summary>
		/// 执行标的其他
		/// </summary>
		public string B_Case_execOther
		{
			set{ _b_case_execother=value;}
			get{return _b_case_execother;}
		}
        /// <summary>
        /// 一审管辖法院
        /// </summary>
        public Guid? B_Case_courtFirst
        {
            get { return _b_case_courtFirst; }
            set { _b_case_courtFirst = value; }
        }
        /// <summary>
        /// 一审管辖法院名称(虚拟字段)
        /// </summary>
        public string B_Case_courtFirstName
        {
            get { return _b_case_courtFirstName; }
            set { _b_case_courtFirstName = value; }
        }
        /// <summary>
        /// 二审管辖法院
        /// </summary>
        public Guid? B_Case_courtSecond
        {
            get { return _b_case_courtSecond; }
            set { _b_case_courtSecond = value; }
        }
        /// <summary>
        /// 二审管辖法院名称(虚拟字段)
        /// </summary>
        public string B_Case_courtSecondName
        {
            get { return _b_case_courtSecondName; }
            set { _b_case_courtSecondName = value; }
        }
        /// <summary>
        /// 执行管辖法院
        /// </summary>
        public Guid? B_Case_courtExec
        {
            get { return _b_case_courtExec; }
            set { _b_case_courtExec = value; }
        }
        /// <summary>
        /// 执行管辖法院名称(虚拟字段)
        /// </summary>
        public string B_Case_courtExecName
        {
            get { return _b_case_courtExecName; }
            set { _b_case_courtExecName = value; }
        }
        /// <summary>
        /// 审判监督法院
        /// </summary>
        public Guid? B_Case_Trial
        {
            get { return _b_case_Trial; }
            set { _b_case_Trial = value; }
        }
        /// <summary>
        /// 审判监督法院名称(虚拟字段)
        /// </summary>
        public string B_Case_TrialName
        {
            get { return _b_case_TrialName; }
            set { _b_case_TrialName = value; }
        }
        /// <summary>
        /// 其他要求
        /// </summary>
        public string B_Case_Requirement
        {
            get { return _b_case_Requirement; }
            set { _b_case_Requirement = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string B_Case_Remarks
        {
            get { return _b_case_Remarks; }
            set { _b_case_Remarks = value; }
        }
        /// <summary>
        /// 负责人
        /// </summary>
        public Guid? B_Case_person
        {
            get { return _b_case_person; }
            set { _b_case_person = value; }
        }
        /// <summary>
        /// 一级负责人
        /// </summary>
        public Guid? B_Case_firstClassResponsiblePerson
        {
            get { return _b_case_firstClassResponsiblePerson; }
            set { _b_case_firstClassResponsiblePerson = value; }
        }
        
        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? B_Case_planStartTime
        {
            get { return _b_case_planStartTime; }
            set { _b_case_planStartTime = value; }
        }
        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime? B_Case_planEndTime
        {
            get { return _b_case_planEndTime; }
            set { _b_case_planEndTime = value; }
        }
        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? B_Case_factStartTime
        {
            get { return _b_case_factStartTime; }
            set { _b_case_factStartTime = value; }
        }
        /// <summary>
        /// 实际结束时间
        /// </summary>
        public DateTime? B_Case_factEndTime
        {
            get { return _b_case_factEndTime; }
            set { _b_case_factEndTime = value; }
        }
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? B_Case_creator
		{
			set{ _b_case_creator=value;}
			get{return _b_case_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? B_Case_createTime
		{
			set{ _b_case_createtime=value;}
			get{return _b_case_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? B_Case_isDelete
		{
			set{ _b_case_isdelete=value;}
			get{return _b_case_isdelete;}
		}
        /// <summary>
        /// 所属商机
        /// </summary>
        public Guid? B_Case_businessChance_Code
        {
            get { return _b_case_businessChance_Code; }
            set { _b_case_businessChance_Code = value; }
        }
        /// <summary>
        /// 所属商机名称（虚拟字段）
        /// </summary>
        public string B_Case_businessChance_Name
        {
            get { return _b_case_businessChance_Name; }
            set { _b_case_businessChance_Name = value; }
        }        
        /// <summary>
        /// 客户编码（虚拟字段）
        /// </summary>
        public string C_Customer_code
        {
            get { return _c_customer_code; }
            set { _c_customer_code = value; }
        }
        /// <summary>
        /// 客户名称（虚拟字段）
        /// </summary>
        public string C_Customer_name
        {
            get { return _c_customer_name; }
            set { _c_customer_name = value; }
        }
        /// <summary>
        /// 委托人编码（虚拟字段）
        /// </summary>
        public string C_Client_code
        {
            get { return _c_client_code; }
            set { _c_client_code = value; }
        }
        /// <summary>
        /// 委托人名称（虚拟字段）
        /// </summary>
        public string C_Client_name
        {
            get { return _c_client_name; }
            set { _c_client_name = value; }
        }
        /// <summary>
        /// 对方当事人编码（虚拟字段）
        /// </summary>
        public string C_Person_code
        {
            get { return _c_person_code; }
            set { _c_person_code = value; }
        }
        /// <summary>
        /// 对方当事人名称（虚拟字段）
        /// </summary>
        public string C_Person_name
        {
            get { return _c_person_name; }
            set { _c_person_name = value; }
        }
        /// <summary>
        /// 对方当事人类型（虚拟字段）
        /// </summary>
        public string C_Person_type
        {
            get { return _c_person_type; }
            set { _c_person_type = value; }
        }
        /// <summary>
        /// 被执行人Guid（虚拟字段）
        /// </summary>
        public string C_Executer_code
        {
            get { return _c_executer_code; }
            set { _c_executer_code = value; }
        }
        /// <summary>
        /// 被执行人名称（虚拟字段）
        /// </summary>
        public string C_Executer_name
        {
            get { return _c_executer_name; }
            set { _c_executer_name = value; }
        }
        /// <summary>
        /// 被执行人类型（虚拟字段）
        /// </summary>
        public string C_Executer_type
        {
            get { return _c_executer_type; }
            set { _c_executer_type = value; }
        }
        /// <summary>
        /// 区域Guid（虚拟字段）
        /// </summary>
        public string C_Region_code
        {
            get { return _c_region_code; }
            set { _c_region_code = value; }
        }
        /// <summary>
        /// 区域名称（虚拟字段）
        /// </summary>
        public string C_Region_name
        {
            get { return _c_region_name; }
            set { _c_region_name = value; }
        }
        /// <summary>
        /// 工程Guid（虚拟字段）
        /// </summary>
        public string C_Project_code
        {
            get { return _c_project_code; }
            set { _c_project_code = value; }
        }
        /// <summary>
        /// 工程名称（虚拟字段）
        /// </summary>
        public string C_Project_name
        {
            get { return _c_project_name; }
            set { _c_project_name = value; }
        }
        /// <summary>
        /// 操作类型（虚拟字段）1.案件列表页面  2.其他页面
        /// </summary>
        public int? B_Case_oprationtype
        {
            get { return _b_case_oprationtype; }
            set { _b_case_oprationtype = value; }
        }
        /// <summary>
        /// 关联GUID（虚拟字段）
        /// </summary>
        public Guid? B_Case_relationCode
        {
            get { return _b_case_relationCode; }
            set { _b_case_relationCode = value; }
        }
        /// <summary>
        /// 律师Guid（虚拟字段）
        /// </summary>
        public Guid? B_Case_lawyerCode
        {
            get { return _b_case_lawyerCode; }
            set { _b_case_lawyerCode = value; }
        }
        /// <summary>
        /// 律师名称（虚拟字段）
        /// </summary>
        public string B_Case_lawyerName
        {
            get { return _b_case_lawyerName; }
            set { _b_case_lawyerName = value; }
        }
        
        /// <summary>
        /// 办案阶段（虚拟字段）
        /// </summary>
        public string B_Case_Stage
        {
            get { return _b_base_btage; }
            set { _b_base_btage = value; }
        }
        /// <summary>
        /// 办案阶段名称（虚拟字段）
        /// </summary>
        public string B_Case_StageName
        {
            get { return _b_base_btage_name; }
            set { _b_base_btage_name = value; }
        }
        /// <summary>
        /// 对方当事人（虚拟字段）
        /// </summary>
        public string B_Case_Rival_code
        {
            get { return _b_base_rival_code; }
            set { _b_base_rival_code = value; }
        }
        /// <summary>
        /// 对方当事人名称（虚拟字段）
        /// </summary>
        public string B_Case_Rival_name
        {
            get { return _b_base_rival_name; }
            set { _b_base_rival_name = value; }
        }
        /// <summary>
        /// 级别 1、指挥级 2、策划级
        /// </summary>
        public int? B_Case_levelType
        {
            get { return _b_case_levelType; }
            set { _b_case_levelType = value; }
        }
        /// <summary>
        /// 部门（虚拟字段）
        /// </summary>
        public string B_Case_organizationCode
        {
            get { return _b_case_organizationCode; }
            set { _b_case_organizationCode = value; }
        }
        /// <summary>
        /// 部门名称（虚拟字段）
        /// </summary>
        public string B_Case_organizationName
        {
            get { return _b_case_organizationName; }
            set { _b_case_organizationName = value; }
        }
        /// <summary>
        /// 流程名称（虚拟字段）
        /// </summary>
        public string P_business_flow_name
        {
            get { return _p_business_flow_name; }
            set { _p_business_flow_name = value; }
        }
        /// <summary>
        /// 表单名称（虚拟字段）
        /// </summary>
        public string F_form_name
        {
            get { return _f_form_name; }
            set { _f_form_name = value; }
        }
        /// <summary>
        /// 部长名称
        /// </summary>
        public string B_Case_personName
        {
            get { return _b_case_personName; }
            set { _b_case_personName = value; }
        }
        /// <summary>
        /// 首席专家名称
        /// </summary>
        public string C_Case_firstClassResponsiblePersonName
        {
            get { return _b_case_firstClassResponsiblePersonName; }
            set { _b_case_firstClassResponsiblePersonName = value; }
        }

        /// <summary>
        /// 案件性质，外键，parameter表，比如类型案件、非类型案件
        /// </summary>
        public int? Ischeck
        {
            set { _ischeck = value; }
            get { return _ischeck; }
        }
        public string  Ischeck2
        {
            set { _ischeck2 = value; }
            get { return _ischeck2; }
        }
        public string Ischeck3
        {
            set { _ischeck3 = value; }
            get { return _ischeck3; }
        }
        public int? M_Entry_Statistics_Management
        {
            set { _m_Entry_Statistics_Management = value; }
            get { return _m_Entry_Statistics_Management; }
        }
        /// <summary>
        /// 延期进程条目统计数量(虚拟属性)
        /// </summary>
        public int? B_Case_Delay_Entry_Statistics_Count
        {
            set { _b_case_delay_entry_statistics_count = value; }
            get { return _b_case_delay_entry_statistics_count; }
        }
        /// <summary>
        /// 办理状态条目统计数量(虚拟属性)(这里专指办理状态为：已超时)
        /// </summary>
        public int? B_Case_HandlingState_Entry_Statistics_Count
        {
            set { _b_case_handlingstate_entry_statistics_count = value; }
            get { return _b_case_handlingstate_entry_statistics_count; }
        }
        /// <summary>
        /// 预警情况条目统计数量(虚拟属性)(这里专指预警情况为：预警)
        /// </summary>
        public int? B_Case_WarningSituation_Entry_Statistics_Count
        {
            set { _b_case_warningsituation_entry_statistics_count = value; }
            get { return _b_case_warningsituation_entry_statistics_count; }
        }

        /// <summary>
        /// 案件是否被稽查过(虚拟属性)
        /// </summary>
        public bool B_Case_IsCheckAuthority
        {
            set { _b_case_ischeckauthority = value; }
            get { return _b_case_ischeckauthority; }
        }
        /// <summary>
        /// 案件级别（虚拟字段）
        /// </summary>
        public string B_Case_caseGrade
        {
            get { return _b_case_caseGrade; }
            set { _b_case_caseGrade = value; }
        }
        /// <summary>
        /// 案件是否有级别变更信息（虚拟字段）
        /// </summary>
        public int? B_Case_isNotAudited
        {
            get { return _b_case_isNotAudited; }
            set { _b_case_isNotAudited = value; }
        }
        /// <summary>
        /// 重大难案标识（虚拟字段）
        /// </summary>
        public int? B_Case_Majordifficult
        {
            get { return _b_case_Majordifficult; }
            set { _b_case_Majordifficult = value; }
        }
        
		#endregion Model

	}
}

