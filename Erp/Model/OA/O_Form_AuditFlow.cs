using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// 表单审批流程表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    [Serializable]
    public partial class O_Form_AuditFlow
    {
        public O_Form_AuditFlow()
        { }
        #region Model
        private int _o_form_auditflow_id;
        private Guid? _o_form_auditflow_code;
        private Guid? _o_form_auditflow_o_form;
        private Guid? _o_form_auditflow_flowset;
        private string _o_form_auditflow_flowset_name;
        private int? _o_form_auditflow_flowset_order;
        private int? _o_form_auditflow_flowset_audittype;
        private string _o_form_auditflow_flowset_rule;
        private int? _o_form_auditflow_auditstatus;
        private string _o_form_auditflow_auditstatus_name;
        private DateTime? _o_form_auditflow_audittime;
        private bool _o_form_auditflow_isdelete;
        private Guid? _o_form_auditflow_creator;
        private DateTime? _o_form_auditflow_createtime;
        private Guid? _o_form_auditPerson_auditPerson;//虚拟字段  审批人
        private int? _o_form_auditPerson_status;//虚拟字段  审核状态
        private string _o_form_auditPerson_content;//虚拟字段 审批内容
        private string _o_form_auditPerson_auditPersonname;//虚拟字段  审批人名称
        private string _o_form_auditPerson_statusname;//虚拟字段  审核状态名称
        private DateTime? _o_form_auditPerson_auditTime;//虚拟字段   审批时间
        private Guid? _o_form_code;//虚拟字段    表单guid
        private int? _o_form_type;//虚拟字段    操作类型 1.通过  2.驳回
        private string _o_form_applyPersonname;//虚拟字段  申请人名称
        private Guid? _o_form_applyPerson;//虚拟字段  申请人guid
        private int? _c_messages_id;//虚拟字段  消息id
        private string _o_form_name;//虚拟字段 表单名称
        private string _o_form_auditPerson_auditPersonjob;//虚拟字段  审批人职位
        private List<CommonService.Model.OA.O_Form_AuditPerson> _o_form_auditflow_auditpersons;
        /// <summary>
        /// ID,标识列,自动增长
        /// </summary>
        public int O_Form_AuditFlow_id
        {
            set { _o_form_auditflow_id = value; }
            get { return _o_form_auditflow_id; }
        }
        /// <summary>
        /// （虚拟字段）   表单名称
        /// </summary>
        public string O_Form_name
        {
            set { _o_form_name = value; }
            get { return _o_form_name; }
        }
        /// <summary>
        /// 虚拟字段    操作类型 1.通过  2.驳回
        /// </summary>
        public int? O_Form_Type
        {
            set { _o_form_type = value; }
            get { return _o_form_type; }
        }
        /// <summary>
        /// （虚拟字段）   消息id
        /// </summary>
        public int? C_Messages_id
        {
            set { _c_messages_id = value; }
            get { return _c_messages_id; }
        }
        /// <summary>
        /// （虚拟字段）   申请人guid
        /// </summary>
        public Guid? O_Form_applyPerson
        {
            set { _o_form_applyPerson = value; }
            get { return _o_form_applyPerson; }
        }
        /// <summary>
        /// （虚拟字段）   表单guid
        /// </summary>
        public Guid? O_Form_code
        {
            set { _o_form_code = value; }
            get { return _o_form_code; }
        }
        /// <summary>
        /// （虚拟字段）   审批人guid
        /// </summary>
        public Guid? O_Form_AuditPerson_auditPerson
        {
            set { _o_form_auditPerson_auditPerson = value; }
            get { return _o_form_auditPerson_auditPerson; }
        }
        /// <summary>
        /// （虚拟字段）   审批人名称
        /// </summary>
        public string O_Form_AuditPerson_auditPersonname
        {
            set { _o_form_auditPerson_auditPersonname = value; }
            get { return _o_form_auditPerson_auditPersonname; }
        }
        /// <summary>
        /// （虚拟字段）   审批人职位
        /// </summary>
        public string O_Form_AuditPerson_auditPersonjob
        {
            set { _o_form_auditPerson_auditPersonjob = value; }
            get { return _o_form_auditPerson_auditPersonjob; }
        }
        /// <summary>
        /// （虚拟字段）  审核状态
        /// </summary>
        public int? O_Form_AuditPerson_status
        {
            set { _o_form_auditPerson_status = value; }
            get { return _o_form_auditPerson_status; }
        }
        /// <summary>
        /// （虚拟字段）   审核状态名称
        /// </summary>
        public string O_Form_AuditPerson_statusname
        {
            set { _o_form_auditPerson_statusname = value; }
            get { return _o_form_auditPerson_statusname; }
        }
        /// <summary>
        /// （虚拟字段）  审批内容
        /// </summary>
        public string O_Form_AuditPerson_content
        {
            set { _o_form_auditPerson_content = value; }
            get { return _o_form_auditPerson_content; }
        }
        /// <summary>
        /// （虚拟字段）  申请人名称
        /// </summary>
        public string O_Form_applyPersonname
        {
            set { _o_form_applyPersonname = value; }
            get { return _o_form_applyPersonname; }
        }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? O_Form_AuditPerson_auditTime
        {
            set { _o_form_auditPerson_auditTime = value; }
            get { return _o_form_auditPerson_auditTime; }
        }
        /// <summary>
        /// GUID,标识列
        /// </summary>
        public Guid? O_Form_AuditFlow_code
        {
            set { _o_form_auditflow_code = value; }
            get { return _o_form_auditflow_code; }
        }
        /// <summary>
        /// OA表单Guid,外键
        /// </summary>
        public Guid? O_Form_AuditFlow_o_form
        {
            set { _o_form_auditflow_o_form = value; }
            get { return _o_form_auditflow_o_form; }
        }
        /// <summary>
        /// 流程预设Guid,外键
        /// </summary>
        public Guid? O_Form_AuditFlow_flowSet
        {
            set { _o_form_auditflow_flowset = value; }
            get { return _o_form_auditflow_flowset; }
        }
        /// <summary>
        /// 流程预设名称(暂时没有用到)
        /// </summary>
        public string O_Form_AuditFlow_flowSet_name
        {
            set { _o_form_auditflow_flowset_name = value; }
            get { return _o_form_auditflow_flowset_name; }
        }
        /// <summary>
        /// 顺序
        /// </summary>
        public int? O_Form_AuditFlow_flowSet_order
        {
            set { _o_form_auditflow_flowset_order = value; }
            get { return _o_form_auditflow_flowset_order; }
        }
        /// <summary>
        /// 多人审核类型，对应C_Parameters表，值为”并且”或”或者”
        /// </summary>
        public int? O_Form_AuditFlow_flowSet_auditType
        {
            set { _o_form_auditflow_flowset_audittype = value; }
            get { return _o_form_auditflow_flowset_audittype; }
        }
        /// <summary>
        /// 规则
        /// </summary>
        public string O_Form_AuditFlow_flowSet_rule
        {
            set { _o_form_auditflow_flowset_rule = value; }
            get { return _o_form_auditflow_flowset_rule; }
        }
        /// <summary>
        /// 审批状态，对应C_Parameters表，值为未开始，已开始，未通过，已通过
        /// </summary>
        public int? O_Form_AuditFlow_auditStatus
        {
            set { _o_form_auditflow_auditstatus = value; }
            get { return _o_form_auditflow_auditstatus; }
        }
        /// <summary>
        /// 审批状态名称(虚拟属性)
        /// </summary>
        public string O_Form_AuditFlow_auditStatus_name
        {
            set { _o_form_auditflow_auditstatus_name = value; }
            get { return _o_form_auditflow_auditstatus_name; }
        }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? O_Form_AuditFlow_auditTime
        {
            set { _o_form_auditflow_audittime = value; }
            get { return _o_form_auditflow_audittime; }
        }
        /// <summary>
        /// 是否删除,1为已删除,0为未删除
        /// </summary>
        public bool O_Form_AuditFlow_isDelete
        {
            set { _o_form_auditflow_isdelete = value; }
            get { return _o_form_auditflow_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? O_Form_AuditFlow_creator
        {
            set { _o_form_auditflow_creator = value; }
            get { return _o_form_auditflow_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_Form_AuditFlow_createTime
        {
            set { _o_form_auditflow_createtime = value; }
            get { return _o_form_auditflow_createtime; }
        }
        /// <summary>
        /// 表单审批人集合(虚拟属性)
        /// </summary>
        public List<CommonService.Model.OA.O_Form_AuditPerson> O_Form_AuditFlow_AuditPersons
        {
            set { _o_form_auditflow_auditpersons = value; }
            get { return _o_form_auditflow_auditpersons; }
        }
        #endregion Model

    }
}
