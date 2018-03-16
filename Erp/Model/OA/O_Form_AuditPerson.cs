using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// 表单审批人表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    [Serializable]
    public partial class O_Form_AuditPerson
    {
        public O_Form_AuditPerson()
        { }
        #region Model
        private int _o_form_auditperson_id;
        private Guid? _o_form_auditperson_code;
        private Guid? _o_form_auditperson_auditperson;
        private string _o_form_auditperson_auditperson_name;
        private DateTime? _o_form_auditperson_audittime;
        private string _o_form_auditperson_status_name;
        private int? _o_form_auditperson_status;
        private string _o_form_auditperson_content;
        private Guid? _o_form_auditperson_formauditflow;
        private bool _o_form_auditperson_isdelete;
        private Guid? _o_form_auditperson_creator;
        private DateTime? _o_form_auditperson_createtime;
        private string _o_form_auditperson_auditperson_job;
        /// <summary>
        /// ID,标识列,自动增长
        /// </summary>
        public int O_Form_AuditPerson_id
        {
            set { _o_form_auditperson_id = value; }
            get { return _o_form_auditperson_id; }
        }
        /// <summary>
        /// GUID,标识列
        /// </summary>
        public Guid? O_Form_AuditPerson_code
        {
            set { _o_form_auditperson_code = value; }
            get { return _o_form_auditperson_code; }
        }
        /// <summary>
        /// 审批人Guid,外键
        /// </summary>
        public Guid? O_Form_AuditPerson_auditPerson
        {
            set { _o_form_auditperson_auditperson = value; }
            get { return _o_form_auditperson_auditperson; }
        }
        /// <summary>
        /// 审批人名称(虚拟属性)
        /// </summary>
        public string O_Form_AuditPerson_auditPerson_name
        {
            set { _o_form_auditperson_auditperson_name = value; }
            get { return _o_form_auditperson_auditperson_name; }
        }
        /// <summary>
        /// 审批人职位(虚拟属性)
        /// </summary>
        public string O_Form_AuditPerson_auditPerson_job
        {
            set { _o_form_auditperson_auditperson_job = value; }
            get { return _o_form_auditperson_auditperson_job; }
        }

        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime? O_Form_AuditPerson_auditTime
        {
            set { _o_form_auditperson_audittime = value; }
            get { return _o_form_auditperson_audittime; }
        }
        /// <summary>
        /// 状态, 对应C_Parameters表
        /// </summary>
        public int? O_Form_AuditPerson_status
        {
            set { _o_form_auditperson_status = value; }
            get { return _o_form_auditperson_status; }
        }
        /// <summary>
        /// 状态名称(虚拟属性)
        /// </summary>
        public string O_Form_AuditPerson_status_name
        {
            set { _o_form_auditperson_status_name = value; }
            get { return _o_form_auditperson_status_name; }
        }

        /// <summary>
        /// 审批内容
        /// </summary>
        public string O_Form_AuditPerson_content
        {
            set { _o_form_auditperson_content = value; }
            get { return _o_form_auditperson_content; }
        }
        /// <summary>
        /// 所属表单审批流程Guid,外键
        /// </summary>
        public Guid? O_Form_AuditPerson_formAuditFlow
        {
            set { _o_form_auditperson_formauditflow = value; }
            get { return _o_form_auditperson_formauditflow; }
        }
        /// <summary>
        /// 是否删除,1为已删除,0为未删除
        /// </summary>
        public bool O_Form_AuditPerson_isDelete
        {
            set { _o_form_auditperson_isdelete = value; }
            get { return _o_form_auditperson_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? O_Form_AuditPerson_creator
        {
            set { _o_form_auditperson_creator = value; }
            get { return _o_form_auditperson_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_Form_AuditPerson_createTime
        {
            set { _o_form_auditperson_createtime = value; }
            get { return _o_form_auditperson_createtime; }
        }
        #endregion Model

    }
}
