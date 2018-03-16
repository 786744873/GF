using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// 表单表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    [Serializable]
    public partial class O_Form
    {
        public O_Form()
        { }
        #region Model
        private int _o_form_id;
        private Guid? _o_form_code;
        private Guid? _o_form_f_form;
        private string _o_form_f_form_name;
        private Guid? _o_form_flow;
        private string _o_form_flow_name;
        private Guid? _o_form_businessflowform;
        private Guid? _o_form_applyperson;
        private string _o_form_applyperson_name;
        private DateTime? _o_form_applytime;
        private int? _o_form_applystatus;
        private string _o_form_applystatus_name;
        private bool _o_form_isdelete;
        private Guid? _o_form_creator;
        private DateTime? _o_form_createtime;
        private string _o_form_businessFlowform_name;
        private string _o_form_businessFlow_name;
        private string _o_form_relation_name;
        
        /// <summary>
        /// ID,标识列,自动增长
        /// </summary>
        public int O_Form_id
        {
            set { _o_form_id = value; }
            get { return _o_form_id; }
        }
        /// <summary>
        /// GUID,标识列
        /// </summary>
        public Guid? O_Form_code
        {
            set { _o_form_code = value; }
            get { return _o_form_code; }
        }
        /// <summary>
        /// 案件表单Guid,外键
        /// </summary>
        public Guid? O_Form_f_form
        {
            set { _o_form_f_form = value; }
            get { return _o_form_f_form; }
        }
        /// <summary>
        /// 表单名称(虚拟属性)
        /// </summary>
        public string O_Form_f_form_name
        {
            set { _o_form_f_form_name = value; }
            get { return _o_form_f_form_name; }
        }

        /// <summary>
        /// 所属流程Guid
        /// </summary>
        public Guid? O_Form_flow
        {
            set { _o_form_flow = value; }
            get { return _o_form_flow; }
        }

        /// <summary>
        /// 所属流程名称(虚拟属性)
        /// </summary>
        public string O_Form_flow_name
        {
            set { _o_form_flow_name = value; }
            get { return _o_form_flow_name; }
        }

        /// <summary>
        /// 业务流程表单关联Guid,外键
        /// </summary>
        public Guid? O_Form_businessFlowform
        {
            set { _o_form_businessflowform = value; }
            get { return _o_form_businessflowform; }
        }
        /// <summary>
        /// 申请人Guid,外键
        /// </summary>
        public Guid? O_Form_applyPerson
        {
            set { _o_form_applyperson = value; }
            get { return _o_form_applyperson; }
        }
        /// <summary>
        /// 申请人名称(虚拟属性)
        /// </summary>
        public string O_Form_applyPerson_name
        {
            set { _o_form_applyperson_name = value; }
            get { return _o_form_applyperson_name; }
        }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? O_Form_applyTime
        {
            set { _o_form_applytime = value; }
            get { return _o_form_applytime; }
        }
        /// <summary>
        /// 申请状态，对应C_Parameters表，值为未提交，已提交，未通过，已通过
        /// </summary>
        public int? O_Form_applyStatus
        {
            set { _o_form_applystatus = value; }
            get { return _o_form_applystatus; }
        }
        /// <summary>
        /// 申请状态名称(虚拟属性)
        /// </summary>
        public string O_Form_applyStatus_name
        {
            set { _o_form_applystatus_name = value; }
            get { return _o_form_applystatus_name; }
        }

        /// <summary>
        /// 是否删除,1为已删除,0为未删除
        /// </summary>
        public bool O_Form_isDelete
        {
            set { _o_form_isdelete = value; }
            get { return _o_form_isdelete; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? O_Form_creator
        {
            set { _o_form_creator = value; }
            get { return _o_form_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_Form_createTime
        {
            set { _o_form_createtime = value; }
            get { return _o_form_createtime; }
        }

        /// <summary>
        /// 所属表单名称（虚拟字段）
        /// </summary>
        public string O_Form_businessFlowform_name
        {
            get { return _o_form_businessFlowform_name; }
            set { _o_form_businessFlowform_name = value; }
        }
        /// <summary>
        /// 所属流程名称（虚拟字段）
        /// </summary>
        public string O_Form_businessFlow_name
        {
            get { return _o_form_businessFlow_name; }
            set { _o_form_businessFlow_name = value; }
        }
        /// <summary>
        /// 所属案件名称（虚拟字段）
        /// </summary>
        public string O_Form_relation_name
        {
            get { return _o_form_relation_name; }
            set { _o_form_relation_name = value; }
        }
        
        #endregion Model

    }
}
