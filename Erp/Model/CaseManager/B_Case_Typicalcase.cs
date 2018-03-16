using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.CaseManager
{
    /// <summary>
    ///  B_Case_Typicalcase:典型案例表
    ///  cyj
    ///  2016年1月19日16:04:35
    /// </summary>
    public class B_Case_Typicalcase
    {
        public B_Case_Typicalcase()
        { }
        #region Model
        private int _b_case_typicalcase_id;
        private Guid _b_case_typicalcase_code;
        private Guid? _b_case_code;
        private Guid? _p_business_flow_code;
        private Guid? _p_business_flow_form_code;
        private string _b_case_typicalcase_title;
        private string _b_case_typicalcase_description;
        private Guid? _b_case_typicalcase_creator;
        private DateTime? _b_case_typicalcase_createtime;
        private int? _b_case_typicalcase_isdelete;
        private string _b_case_name;
        private string _p_businessflow_name;
        private string _p_businessflow_form_name;
        private string _region_name;
        private string _b_case_court;
        private string _b_case_number;
        /// <summary>
        /// 主键
        /// </summary>
        public int B_Case_Typicalcase_id
        {
            set { _b_case_typicalcase_id = value; }
            get { return _b_case_typicalcase_id; }
        }
        /// <summary>
        /// guid
        /// </summary>
        public Guid B_Case_Typicalcase_code
        {
            set { _b_case_typicalcase_code = value; }
            get { return _b_case_typicalcase_code; }
        }
        /// <summary>
        /// 案件code
        /// </summary>
        public Guid? B_Case_code
        {
            set { _b_case_code = value; }
            get { return _b_case_code; }
        }
        /// <summary>
        /// 流程code
        /// </summary>
        public Guid? P_Business_flow_code
        {
            set { _p_business_flow_code = value; }
            get { return _p_business_flow_code; }
        }
        /// <summary>
        /// 表单code
        /// </summary>
        public Guid? P_Business_flow_form_code
        {
            set { _p_business_flow_form_code = value; }
            get { return _p_business_flow_form_code; }
        }
        /// <summary>
        /// 案例标题
        /// </summary>
        public string B_Case_Typicalcase_title
        {
            set { _b_case_typicalcase_title = value; }
            get { return _b_case_typicalcase_title; }
        }
        /// <summary>
        /// 案例分析
        /// </summary>
        public string B_Case_Typicalcase_description
        {
            set { _b_case_typicalcase_description = value; }
            get { return _b_case_typicalcase_description; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? B_Case_Typicalcase_creator
        {
            set { _b_case_typicalcase_creator = value; }
            get { return _b_case_typicalcase_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? B_Case_Typicalcase_createTime
        {
            set { _b_case_typicalcase_createtime = value; }
            get { return _b_case_typicalcase_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? B_Case_Typicalcase_isDelete
        {
            set { _b_case_typicalcase_isdelete = value; }
            get { return _b_case_typicalcase_isdelete; }
        }
        /// <summary>
        /// 案例名称(虚拟字段)
        /// </summary>
        public string B_Case_name
        {
            set { _b_case_name = value; }
            get { return _b_case_name; }
        }
        /// <summary>
        /// 业务流程名称（虚拟字段）
        /// </summary>
        public string P_Businessflow_name
        {
            set { _p_businessflow_name = value; }
            get { return _p_businessflow_name; }
        }
        /// <summary>
        /// 业务流程表单名称（虚拟字段）
        /// </summary>
        public string P_Businessflow_form_name
        {
            set { _p_businessflow_form_name = value; }
            get { return _p_businessflow_form_name; }
        }
        /// <summary>
        /// 区域名称（虚拟字段）
        /// </summary>
        public string Region_name
        {
            set { _region_name = value; }
            get { return _region_name; }
        }
        /// <summary>
        /// 法院(虚拟字段)
        /// </summary>
        public string B_Case_court
        {
            set { _b_case_court = value; }
            get { return _b_case_court; }
        }
        /// <summary>
        /// 案件编码(虚拟字段)
        /// </summary>
        public string B_Case_number
        {
            set { _b_case_number = value; }
            get { return _b_case_number; }
        }
        #endregion Model
    }
}
