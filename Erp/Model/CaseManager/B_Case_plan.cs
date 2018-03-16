using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// B_Case_plan:实体类(属性说明自动提取数据库字段的描述信息)办案方案表
    /// 作者：陈永俊
    /// 时间：2015年6月9日11:11:22
    /// </summary>
    [Serializable]
    public partial class B_Case_plan
    {
        public B_Case_plan()
        { }
        #region Model
        private int _b_case_plan_id;
        private Guid? _b_case_plan_code;
        private Guid? _b_case_code;
        private string _b_case_plan_evidence;
        private string _b_case_plan_plaintiffreason;
        private string _b_case_plan_defendantreason;
        private string _b_case_plan_qualitycontrol;
        private string _b_case_plan_schedulecontrol;
        private string _b_case_plan_incomeccontrol;
        private string _b_case_plan_costcontrol;
        private Guid? _b_case_plan_creator;
        private DateTime? _b_case_plan_createtime;
        private int? _b_case_plan_isdelete;
        private Guid? _b_case_plan_court_code;
        private string _b_case_plan_court_name;
        private string _b_case_plan_plaintiff_customer_code;
        private string _b_case_plan_defendant_customer_code;
        private string _b_case_plan_plaintiff_customer_name;
        private string _b_case_plan_defendant_customer_name;
        private string _b_case_plan_defendant_customer_type;
        private string _b_case_plan_Evidencesubmitted_name;
        private string _b_case_plan_Evidencesubmitted_code;
        private string _b_case_plan_proceedings_name;
        private string _b_case_plan_proceedings_code;
        private int? _b_case_plan_Evidence_type;
        private string _b_case_plan_Evidence_Parameters_name;
        private string _b_case_plan_Evidence_Parameters_code;
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int B_Case_plan_id
        {
            set { _b_case_plan_id = value; }
            get { return _b_case_plan_id; }
        }
        /// <summary>
        /// GUID
        /// </summary>
        public Guid? B_Case_plan_code
        {
            set { _b_case_plan_code = value; }
            get { return _b_case_plan_code; }
        }
        /// <summary>
        /// 所关联案件GUID
        /// </summary>
        public Guid? B_Case_code
        {
            set { _b_case_code = value; }
            get { return _b_case_code; }
        }
        /// <summary>
        /// 对证据的分析
        /// </summary>
        public string B_Case_plan_evidence
        {
            set { _b_case_plan_evidence = value; }
            get { return _b_case_plan_evidence; }
        }
        /// <summary>
        /// 确定原告理由
        /// </summary>
        public string B_Case_plan_plaintiffReason
        {
            set { _b_case_plan_plaintiffreason = value; }
            get { return _b_case_plan_plaintiffreason; }
        }
        /// <summary>
        /// 确定被告理由
        /// </summary>
        public string B_Case_plan_defendantReason
        {
            set { _b_case_plan_defendantreason = value; }
            get { return _b_case_plan_defendantreason; }
        }
        /// <summary>
        /// 办案质量控制
        /// </summary>
        public string B_Case_plan_qualityControl
        {
            set { _b_case_plan_qualitycontrol = value; }
            get { return _b_case_plan_qualitycontrol; }
        }
        /// <summary>
        /// 办案进度控制
        /// </summary>
        public string B_Case_plan_scheduleControl
        {
            set { _b_case_plan_schedulecontrol = value; }
            get { return _b_case_plan_schedulecontrol; }
        }
        /// <summary>
        /// 办案收入控制
        /// </summary>
        public string B_Case_plan_incomecControl
        {
            set { _b_case_plan_incomeccontrol = value; }
            get { return _b_case_plan_incomeccontrol; }
        }
        /// <summary>
        /// 办案成本控制
        /// </summary>
        public string B_Case_plan_costControl
        {
            set { _b_case_plan_costcontrol = value; }
            get { return _b_case_plan_costcontrol; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? B_Case_plan_creator
        {
            set { _b_case_plan_creator = value; }
            get { return _b_case_plan_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? B_Case_plan_createTime
        {
            set { _b_case_plan_createtime = value; }
            get { return _b_case_plan_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? B_Case_plan_isDelete
        {
            set { _b_case_plan_isdelete = value; }
            get { return _b_case_plan_isdelete; }
        }
        /// <summary>
        /// 关联法院GUID
        /// </summary>
        public Guid? B_Case_plan_Court_code
        {
            set { _b_case_plan_court_code = value; }
            get { return _b_case_plan_court_code; }
        }
        /// <summary>
        /// 法院名称（虚拟属性）
        /// </summary>
        public string B_Case_plan_Court_name
        {
            set { _b_case_plan_court_name = value; }
            get { return _b_case_plan_court_name; }
        }
        /// <summary>
        /// 确定原告
        /// </summary>
        public string B_Case_plan_plaintiff_Customer_code
        {
            set { _b_case_plan_plaintiff_customer_code = value; }
            get { return _b_case_plan_plaintiff_customer_code; }
        }
        /// <summary>
        /// 确定被告
        /// </summary>
        public string B_Case_plan_defendant_Customer_code
        {
            set { _b_case_plan_defendant_customer_code = value; }
            get { return _b_case_plan_defendant_customer_code; }
        }
        /// <summary>
        /// 确定原告名称（虚拟属性）
        /// </summary>
        public string B_Case_plan_plaintiff_Customer_name
        {
            set { _b_case_plan_plaintiff_customer_name= value; }
            get { return _b_case_plan_plaintiff_customer_name; }
        }
        /// <summary>
        /// 确定被告名称（虚拟属性）
        /// </summary>
        public string B_Case_plan_defendant_Customer_name
        {
            set { _b_case_plan_defendant_customer_name = value; }
            get { return _b_case_plan_defendant_customer_name; }
        }
        /// <summary>
        /// 确定被告类型（虚拟属性）
        /// </summary>
        public string B_Case_plan_defendant_Customer_type
        {
            set { _b_case_plan_defendant_customer_type = value; }
            get { return _b_case_plan_defendant_customer_type; }
        }
        /// <summary>
        /// 虚拟字段（立案提交证据名称）
        /// </summary>
        public string B_Case_plan_Evidencesubmitted_name
        {
            set { _b_case_plan_Evidencesubmitted_name = value; }
            get { return _b_case_plan_Evidencesubmitted_name; }
        }
        /// <summary>
        /// 虚拟字段（立案提交证据code）
        /// </summary>
        public string B_Case_plan_Evidencesubmitted_code
        {
            set { _b_case_plan_Evidencesubmitted_code = value; }
            get { return _b_case_plan_Evidencesubmitted_code; }
        }
        /// <summary>
        /// 虚拟字段（诉讼提交的证据名称）
        /// </summary>
        public string B_Case_plan_Proceedings_name
        {
            set { _b_case_plan_proceedings_name = value; }
            get { return _b_case_plan_proceedings_name; }
        }
        /// <summary>
        /// 虚拟字段（诉讼提交的证据code）
        /// </summary>
        public string B_Case_plan_Proceedings_code
        {
            set { _b_case_plan_proceedings_code = value; }
            get { return _b_case_plan_proceedings_code; }
        }
        /// <summary>
        /// 虚拟字段（证据类型）
        /// </summary>
        public int? B_Case_plan_Evidence_type
        {
            set { _b_case_plan_Evidence_type = value; }
            get { return _b_case_plan_Evidence_type; }
        }
        /// <summary>
        /// 虚拟字段（证据类型为3时关联Parameters表）
        /// </summary>
        public string B_Case_plan_Evidence_Parameters_name
        {
            set { _b_case_plan_Evidence_Parameters_name = value; }
            get { return _b_case_plan_Evidence_Parameters_name; }
        }
        /// <summary>
        /// 虚拟字段（证据类型为3时关联Parameters表）
        /// </summary>
        public string B_Case_plan_Evidence_Parameters_code
        {
            set { _b_case_plan_Evidence_Parameters_code = value; }
            get { return _b_case_plan_Evidence_Parameters_code; }
        }
        #endregion Model

    }
}
