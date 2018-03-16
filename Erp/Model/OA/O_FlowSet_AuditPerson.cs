using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// 流程预设审批人表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    [Serializable]
    public partial class O_FlowSet_AuditPerson
    {
        public O_FlowSet_AuditPerson()
        { }
        #region Model
        private int _o_flowset_auditperson_id;
        private Guid? _o_flowset_auditperson_code;
        private Guid? _o_flowset_auditperson_flowset;
        private Guid? _o_flowset_auditperson_auditperson;
        private bool _o_flowset_auditperson_isdelete;
        private Guid? _o_flowset_auditperson_creator;
        private DateTime? _o_flowset_auditperson_createtime;
        private Guid? _o_form_auditflow_code;
        private int? _o_flowset_order;//虚拟字段
        /// <summary>
        /// ID,标识列,自动增长
        /// </summary>
        public int O_FlowSet_auditPerson_id
        {
            set { _o_flowset_auditperson_id = value; }
            get { return _o_flowset_auditperson_id; }
        }
        /// <summary>
        /// (虚拟字段)  顺序 
        /// </summary>
        public int? O_FlowSet_order
        {
            set { _o_flowset_order = value; }
            get { return _o_flowset_order; }
        }
        /// <summary>
        /// 虚拟字段(表单审批流程表GUID)
        /// </summary>
        public Guid? O_Form_AuditFlow_code
        {
            set { _o_form_auditflow_code = value; }
            get { return _o_form_auditflow_code; }
        }
        /// <summary>
        /// GUID,标识列
        /// </summary>
        public Guid? O_FlowSet_auditPerson_code
        {
            set { _o_flowset_auditperson_code = value; }
            get { return _o_flowset_auditperson_code; }
        }
        /// <summary>
        /// 流程预设Guid,外键
        /// </summary>
        public Guid? O_FlowSet_auditPerson_flowSet
        {
            set { _o_flowset_auditperson_flowset = value; }
            get { return _o_flowset_auditperson_flowset; }
        }
        /// <summary>
        /// 审批人Guid
        /// </summary>
        public Guid? O_FlowSet_auditPerson_auditPerson
        {
            set { _o_flowset_auditperson_auditperson = value; }
            get { return _o_flowset_auditperson_auditperson; }
        }
        /// <summary>
        /// 是否删除,1为已删除,0为未删除
        /// </summary>
        public bool O_FlowSet_auditPerson_isDelete
        {
            set { _o_flowset_auditperson_isdelete = value; }
            get { return _o_flowset_auditperson_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? O_FlowSet_auditPerson_creator
        {
            set { _o_flowset_auditperson_creator = value; }
            get { return _o_flowset_auditperson_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_FlowSet_auditPerson_createTime
        {
            set { _o_flowset_auditperson_createtime = value; }
            get { return _o_flowset_auditperson_createtime; }
        }
        #endregion Model

    }
}
