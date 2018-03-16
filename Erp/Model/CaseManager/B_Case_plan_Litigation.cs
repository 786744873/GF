using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// B_Case_plan_Litigation:实体类
    /// 办案方案诉讼请求----和参数中间表
    /// 作者：陈永俊
    /// 时间：2015年6月19日
    /// </summary>
    [Serializable]
    public partial class B_Case_plan_Litigation
    {
        public B_Case_plan_Litigation()
        { }
        #region Model
        private int _b_case_plan_litigation_id;
        private Guid? _b_case_plan_litigation_code;
        private int? _b_case_plan_litigation_parameterid;
        private int? _b_case_plan_litigation_amount;
        private string _b_case_plan_litigation_description;
        private Guid? _b_case_plan_litigation_creator;
        private DateTime? _b_case_plan_litigation_createtime;
        private int? _b_case_plan_litigation_isdelete;
        private Guid? _b_case_code;
        private string _b_case_plan_litigation_parameter_name;
        private int? _c_parameter_id;
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int B_Case_plan_Litigation_id
        {
            set { _b_case_plan_litigation_id = value; }
            get { return _b_case_plan_litigation_id; }
        }
        /// <summary>
        /// GUID
        /// </summary>
        public Guid? B_Case_plan_Litigation_code
        {
            set { _b_case_plan_litigation_code = value; }
            get { return _b_case_plan_litigation_code; }
        }
        /// <summary>
        /// 所关联Parameter表ID
        /// </summary>
        public int? B_Case_plan_Litigation_ParameterId
        {
            set { _b_case_plan_litigation_parameterid = value; }
            get { return _b_case_plan_litigation_parameterid; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public int? B_Case_plan_Litigation_Amount
        {
            set { _b_case_plan_litigation_amount = value; }
            get { return _b_case_plan_litigation_amount; }
        }
        /// <summary>
        /// 策略说明
        /// </summary>
        public string B_Case_plan_Litigation_description
        {
            set { _b_case_plan_litigation_description = value; }
            get { return _b_case_plan_litigation_description; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? B_Case_plan_Litigation_creator
        {
            set { _b_case_plan_litigation_creator = value; }
            get { return _b_case_plan_litigation_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? B_Case_plan_Litigation_createTime
        {
            set { _b_case_plan_litigation_createtime = value; }
            get { return _b_case_plan_litigation_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? B_Case_plan_Litigation_isDelete
        {
            set { _b_case_plan_litigation_isdelete = value; }
            get { return _b_case_plan_litigation_isdelete; }
        }
        /// <summary>
        /// 关联案件GUID
        /// </summary>
        public Guid? B_Case_code
        {
            set { _b_case_code = value; }
            get { return _b_case_code; }
        }
        /// <summary>
        /// 虚拟属性（参数名称）
        /// </summary>
        public string B_Case_plan_litigation_parameter_name
        {
            set { _b_case_plan_litigation_parameter_name = value; }
            get { return _b_case_plan_litigation_parameter_name; }
        }
        /// <summary>
        /// 虚拟字段(参数ID)
        /// </summary>
        public int? C_Parameterid
        {
            set { _c_parameter_id = value; }
            get { return _c_parameter_id; }
        }
        #endregion Model

    }
}
