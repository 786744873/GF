using System;
namespace CommonService.Model.FlowManager
{
    /// <summary>
    /// 业务流程表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
    public partial class P_Business_flow
    {
        public P_Business_flow()
        { }
        #region Model
        public int _p_business_flow_id;
        public Guid? _p_business_flow_code;
        public Guid? _p_fk_code;
        public Guid? _p_flow_code;
        public string _p_flow_name;
        public int? _p_business_flow_level;
        public Guid? _p_flow_parent;
        public string _p_business_flow_name;
        public int? _p_business_flow_audittype;
        public string _p_business_flow_require;
        public int? _p_business_order;
        public string _p_business_remark;
        public bool _p_business_isdelete;
        public int? _p_business_state;
        public string _p_business_state_name;
        public Guid? _p_business_startperson;
        public string _p_business_startPerson_name;
        public string _p_business_startreason;
        public DateTime? _p_business_starttime;
        public Guid? _p_business_person;
        public string _p_business_person_name;
        public DateTime? _p_business_flow_planstarttime;
        public DateTime? _p_business_flow_planendtime;
        public DateTime? _p_business_flow_factstarttime;
        public DateTime? _p_business_flow_factendtime;
        public int? _p_business_flow_standardtimelength;
        public Decimal? _p_business_flow_fixPrice;
        public Guid? _p_business_creator;
        public DateTime? _p_business_createtime;
        public int? _p_business_flow_applicationStatus;
        public string _p_business_flow_applicationStatusName;
        public int isedit;
        public int? _p_flow_defaultDuration;
        
        /// <summary>
        /// 是否编辑（App专用）
        /// </summary>
        public int Isedit
        {
            get { return isedit; }
            set { isedit = value; }
        }

        /// <summary>
        /// 部门名称，虚拟字段
        /// </summary>
        public string P_Business_personDepName { get; set; }

        /// <summary>
        /// 业务流程ID，主键，自增
        /// </summary>
        public int P_Business_flow_id
        {
            set { _p_business_flow_id = value; }
            get { return _p_business_flow_id; }
        }
        /// <summary>
        /// 业务流程GUID
        /// </summary>
        public Guid? P_Business_flow_code
        {
            set { _p_business_flow_code = value; }
            get { return _p_business_flow_code; }
        }
        /// <summary>
        /// GUID，外键，关联比如案件、商机等
        /// </summary>
        public Guid? P_Fk_code
        {
            set { _p_fk_code = value; }
            get { return _p_fk_code; }
        }
        /// <summary>
        /// 流程GUID，外键，流程表
        /// </summary>
        public Guid? P_Flow_code
        {
            set { _p_flow_code = value; }
            get { return _p_flow_code; }
        }
        /// <summary>
        /// 流程名称(虚拟属性)
        /// </summary>
        public string P_Flow_name
        {
            set { _p_flow_name = value; }
            get { return _p_flow_name; }
        }
        /// <summary>
        /// 业务流程级别
        /// </summary>
        public int? P_Business_flow_level
        {
            set { _p_business_flow_level = value; }
            get { return _p_business_flow_level; }
        }
        /// <summary>
        /// 父级流程GUID，外键，本表
        /// </summary>
        public Guid? P_Flow_parent
        {
            set { _p_flow_parent = value; }
            get { return _p_flow_parent; }
        }
        /// <summary>
        /// 业务流程名称，如果为空则取流程名称
        /// </summary>
        public string P_Business_flow_name
        {
            set { _p_business_flow_name = value; }
            get { return _p_business_flow_name; }
        }
        /// <summary>
        /// 审核类型，外键，从parameter表中预设，包括”完全监控”，”仅监控当前预设流程”
        /// </summary>
        public int? P_Business_flow_auditType
        {
            set { _p_business_flow_audittype = value; }
            get { return _p_business_flow_audittype; }
        }
        /// <summary>
        /// 任务要求，为空则从流程表中取
        /// </summary>
        public string P_Business_flow_require
        {
            set { _p_business_flow_require = value; }
            get { return _p_business_flow_require; }
        }
        /// <summary>
        /// 流程顺序
        /// </summary>
        public int? P_Business_order
        {
            set { _p_business_order = value; }
            get { return _p_business_order; }
        }
        /// <summary>
        /// 流程备注
        /// </summary>
        public string P_Business_remark
        {
            set { _p_business_remark = value; }
            get { return _p_business_remark; }
        }
        /// <summary>
        /// 是否已删除(1为已删除，0为未删除)
        /// </summary>
        public bool P_Business_isdelete
        {
            set { _p_business_isdelete = value; }
            get { return _p_business_isdelete; }
        }

        /// <summary>
        /// 状态，外键，从parameter表中预设，包含“未开始”，“正在进行”，“已结束”
        /// </summary>
        public int? P_Business_state
        {
            set { _p_business_state = value; }
            get { return _p_business_state; }
        }
        /// <summary>
        /// 状态名称(虚拟属性)
        /// </summary>
        public string P_Business_state_name
        {
            set { _p_business_state_name = value; }
            get { return _p_business_state_name; }
        }
        /// <summary>
        /// 启动人Guid
        /// </summary>
        public Guid? P_Business_startPerson
        {
            set { _p_business_startperson = value; }
            get { return _p_business_startperson; }
        }
        /// <summary>
        /// 启动人名称（虚拟字段）
        /// </summary>
        public string P_Business_startPerson_name
        {
            get { return _p_business_startPerson_name; }
            set { _p_business_startPerson_name = value; }
        }
        /// <summary>
        /// 启动理由
        /// </summary>
        public string P_Business_startReason
        {
            set { _p_business_startreason = value; }
            get { return _p_business_startreason; }
        }

        /// <summary>
        /// 启动时间
        /// </summary>
        public DateTime? P_Business_startTime
        {
            set { _p_business_starttime = value; }
            get { return _p_business_starttime; }
        }
        /// <summary>
        /// 负责人
        /// </summary>
        public Guid? P_Business_person
        {
            set { _p_business_person = value; }
            get { return _p_business_person; }
        }
        /// <summary>
        /// 负责人名称(虚拟属性)
        /// </summary>
        public string P_Business_person_name
        {
            set { _p_business_person_name = value; }
            get { return _p_business_person_name; }
        }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? P_Business_flow_planStartTime
        {
            set { _p_business_flow_planstarttime = value; }
            get { return _p_business_flow_planstarttime; }
        }
        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime? P_Business_flow_planEndTime
        {
            set { _p_business_flow_planendtime = value; }
            get { return _p_business_flow_planendtime; }
        }
        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? P_Business_flow_factStartTime
        {
            set { _p_business_flow_factstarttime = value; }
            get { return _p_business_flow_factstarttime; }
        }
        /// <summary>
        /// 实际结束时间
        /// </summary>
        public DateTime? P_Business_flow_factEndTime
        {
            set { _p_business_flow_factendtime = value; }
            get { return _p_business_flow_factendtime; }
        }
        /// <summary>
        /// 标准时长
        /// </summary>
        public int? P_Business_flow_standardTimeLength
        {
            set { _p_business_flow_standardtimelength = value; }
            get { return _p_business_flow_standardtimelength; }
        }
        /// <summary>
        /// 定价
        /// </summary>
        public decimal? P_Business_flow_fixPrice
        {
            set { _p_business_flow_fixPrice = value; }
            get { return _p_business_flow_fixPrice; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? P_Business_creator
        {
            set { _p_business_creator = value; }
            get { return _p_business_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? P_Business_createTime
        {
            set { _p_business_createtime = value; }
            get { return _p_business_createtime; }
        }
        /// <summary>
        /// 申请状态
        /// </summary>
        public int? P_Business_flow_applicationStatus
        {
            get { return _p_business_flow_applicationStatus; }
            set { _p_business_flow_applicationStatus = value; }
        }
        /// <summary>
        /// 申请状态名称（虚拟字段）
        /// </summary>
        public string P_Business_flow_applicationStatusName
        {
            get { return _p_business_flow_applicationStatusName; }
            set { _p_business_flow_applicationStatusName = value; }
        }
        /// <summary>
        /// 流程默认时长（虚拟字段）
        /// </summary>
        public int? P_Flow_defaultDuration
        {
            get { return _p_flow_defaultDuration; }
            set { _p_flow_defaultDuration = value; }
        }
        #endregion Model

    }
}

