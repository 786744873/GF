using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// B_Case_plan_Evidence:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class B_Case_plan_Evidence
    {
        public B_Case_plan_Evidence()
        { }
        #region Model
        private int _b_case_plan_evidence_id;
        private Guid? _b_case_plan_evidence_code;
        private Guid? _b_case_plan_code;
        private int? _b_case_paln_evidence_type;
        private Guid? _b_case_plan_evidence_file_code;
        private Guid? _b_case_plan_evidence_creator;
        private DateTime? _b_case_plan_evidence_createtime;
        private int? _b_case_plan_evidence_isdelete;
        private int? _b_case_plan_evidence_parameters_id;
        private string _b_case_plan_Evidence_name;
        private string _b_case_plan_Evidence_Parameters_name;
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int B_Case_plan_Evidence_id
        {
            set { _b_case_plan_evidence_id = value; }
            get { return _b_case_plan_evidence_id; }
        }
        /// <summary>
        /// GUID
        /// </summary>
        public Guid? B_Case_plan_Evidence_code
        {
            set { _b_case_plan_evidence_code = value; }
            get { return _b_case_plan_evidence_code; }
        }
        /// <summary>
        /// 所关联案件GUID 
        /// </summary>
        public Guid? B_Case_plan_code
        {
            set { _b_case_plan_code = value; }
            get { return _b_case_plan_code; }
        }
        /// <summary>
        /// 证据类型1：立案提交的证据2：诉讼提交的证据3：需要补充的证据 
        /// </summary>
        public int? B_Case_paln_Evidence_type
        {
            set { _b_case_paln_evidence_type = value; }
            get { return _b_case_paln_evidence_type; }
        }
        /// <summary>
        /// 证据文件名称 
        /// </summary>
        public Guid? B_Case_plan_Evidence_file_code
        {
            set { _b_case_plan_evidence_file_code = value; }
            get { return _b_case_plan_evidence_file_code; }
        }
        /// <summary>
        /// 创建人 
        /// </summary>
        public Guid? B_Case_plan_Evidence_creator
        {
            set { _b_case_plan_evidence_creator = value; }
            get { return _b_case_plan_evidence_creator; }
        }
        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime? B_Case_plan_Evidence_createTime
        {
            set { _b_case_plan_evidence_createtime = value; }
            get { return _b_case_plan_evidence_createtime; }
        }
        /// <summary>
        /// 是否删除 
        /// </summary>
        public int? B_Case_plan_Evidence_isDelete
        {
            set { _b_case_plan_evidence_isdelete = value; }
            get { return _b_case_plan_evidence_isdelete; }
        }
        /// <summary>
        /// 证据类型是3时关联Parameters表ID 
        /// </summary>
        public int? B_Case_plan_Evidence_Parameters_id
        {
            set { _b_case_plan_evidence_parameters_id = value; }
            get { return _b_case_plan_evidence_parameters_id; }
        }
        /// <summary>
        /// 虚拟字段（文件名称）
        /// </summary>
        public string B_Case_plan_Evidence_name
        {
            set { _b_case_plan_Evidence_name = value; }
            get { return _b_case_plan_Evidence_name; }
        }
        /// <summary>
        /// 虚拟字段（证据类型为3时类型名称）
        /// </summary>
        public string B_Case_plan_Evidence_Parameters_name
        {
            set { _b_case_plan_Evidence_Parameters_name = value; }
            get { return _b_case_plan_Evidence_Parameters_name; }
        }
        #endregion Model

    }
}
