using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.CustomerForm
{
    /// <summary>
    /// 表单审核表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/06/06
    /// </summary>
    public partial class F_FormCheck
    {
        public F_FormCheck()
        { }
        #region Model
        public int _f_formcheck_id;
        public Guid? _f_formcheck_code;
        public Guid? _f_formcheck_business_flow_form_code;
        public string _f_formcheck_business_flow_form_name;
        public bool _f_formcheck_isfirstsubmit;
        public string _f_formcheck_submitinfo;
        public Guid? _f_formcheck_checkbusinessCode;
        public Guid? _f_formcheck_checkperson;
        public string _f_formcheck_checkPerson_name;
        public DateTime? _f_formcheck_checkdate;
        public int? _f_formcheck_state;
        public string _f_formcheck_content;
        public bool _f_formcheck_isdelete;
        public Guid? _f_formcheck_creator;
        public string _f_formcheck_creator_name;
        public DateTime? _f_formcheck_createtime;
        public string _f_form_chineseName;
        /// <summary>
        /// 主键，自增
        /// </summary>
        public int F_FormCheck_id
        {
            set { _f_formcheck_id = value; }
            get { return _f_formcheck_id; }
        }
        /// <summary>
        /// 表单审核表Guid
        /// </summary>
        public Guid? F_FormCheck_code
        {
            set { _f_formcheck_code = value; }
            get { return _f_formcheck_code; }
        }
        /// <summary>
        /// 业务流程表单关联GUID，外键
        /// </summary>
        public Guid? F_FormCheck_business_flow_form_code
        {
            set { _f_formcheck_business_flow_form_code = value; }
            get { return _f_formcheck_business_flow_form_code; }
        }
        /// <summary>
        /// 关联业务流程表单名称（虚拟字段）
        /// </summary>
        public string F_FormCheck_business_flow_form_name
        {
            get { return _f_formcheck_business_flow_form_name; }
            set { _f_formcheck_business_flow_form_name = value; }
        }        
        /// <summary>
        /// 是否首次提交；1为是，0为否
        /// </summary>
        public bool F_FormCheck_isFirstSubmit
        {
            set { _f_formcheck_isfirstsubmit = value; }
            get { return _f_formcheck_isfirstsubmit; }
        }
        /// <summary>
        /// 纪要内容
        /// </summary>
        public string F_FormCheck_submitInfo
        {
            set { _f_formcheck_submitinfo = value; }
            get { return _f_formcheck_submitinfo; }
        }
        /// <summary>
        /// 审核当前业务Guid(业务流程Guid或者案件Guid或客户Guid)
        /// </summary>
        public Guid? F_FormCheck_checkBusinessCode
        {
            set { _f_formcheck_checkbusinessCode = value; }
            get { return _f_formcheck_checkbusinessCode; }
        }

        /// <summary>
        /// 审核人Guid
        /// </summary>
        public Guid? F_FormCheck_checkPerson
        {
            set { _f_formcheck_checkperson = value; }
            get { return _f_formcheck_checkperson; }
        }
        /// <summary>
        /// 审核人名称（虚拟字段）
        /// </summary>
        public string F_FormCheck_checkPerson_name
        {
            get { return _f_formcheck_checkPerson_name; }
            set { _f_formcheck_checkPerson_name = value; }
        }
        
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? F_FormCheck_checkDate
        {
            set { _f_formcheck_checkdate = value; }
            get { return _f_formcheck_checkdate; }
        }
        /// <summary>
        /// 审核状态 通过、未通过，对应parameter表
        /// </summary>
        public int? F_FormCheck_state
        {
            set { _f_formcheck_state = value; }
            get { return _f_formcheck_state; }
        }
        /// <summary>
        /// 审核内容
        /// </summary>
        public string F_FormCheck_content
        {
            set { _f_formcheck_content = value; }
            get { return _f_formcheck_content; }
        }
        /// <summary>
        /// 是否删除;1为已删除；0为未删除
        /// </summary>
        public bool F_FormCheck_isDelete
        {
            set { _f_formcheck_isdelete = value; }
            get { return _f_formcheck_isdelete; }
        }
        /// <summary>
        /// 创建人(提交人)Guid
        /// </summary>
        public Guid? F_FormCheck_creator
        {
            set { _f_formcheck_creator = value; }
            get { return _f_formcheck_creator; }
        }
        /// <summary>
        /// 创建人(提交人)名称(虚拟属性)
        /// </summary>
        public string F_FormCheck_creator_name
        {
            set { _f_formcheck_creator_name = value; }
            get { return _f_formcheck_creator_name; }
        }

        /// <summary>
        /// 创建(提交)时间
        /// </summary>
        public DateTime? F_FormCheck_createTime
        {
            set { _f_formcheck_createtime = value; }
            get { return _f_formcheck_createtime; }
        }
        ///
        public string F_Form_chineseName {
            set { _f_form_chineseName = value; }
            get { return _f_form_chineseName; }
        
        }
        #endregion Model

    }
}
