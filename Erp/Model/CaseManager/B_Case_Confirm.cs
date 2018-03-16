using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.CaseManager
{
    /// <summary>
    /// 案件结案确认表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/09/22
    /// </summary>
    [Serializable]
    public partial class B_Case_Confirm
    {
        public B_Case_Confirm()
        { }
        #region Model
        private int _b_case_confirm_id;
        private Guid? _b_case_confirm_code;
        private Guid? _b_case_code;
        private Guid? _p_business_flow_code;
        private string _p_business_flow_name;
        private int? _b_case_Confirm_checkState;
        private string _b_case_Confirm_checkStateName;
        private string _b_case_confirm_suggestcontent;
        private string _b_case_confirm_remarks;
        private Guid? _b_case_confirm_creator;
        private string _b_case_confirm_creator_name;
        private DateTime? _b_case_confirm_createtime;
        private bool _b_case_confirm_isdelete;
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int B_Case_Confirm_id
        {
            set { _b_case_confirm_id = value; }
            get { return _b_case_confirm_id; }
        }
        /// <summary>
        /// 结案确认GUID
        /// </summary>
        public Guid? B_Case_Confirm_code
        {
            set { _b_case_confirm_code = value; }
            get { return _b_case_confirm_code; }
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
        /// 关联业务流程GUID
        /// </summary>
        public Guid? P_Business_Flow_code
        {
            set { _p_business_flow_code = value; }
            get { return _p_business_flow_code; }
        }
        /// <summary>
        /// 关联业务流程名称（虚拟字段）
        /// </summary>
        public string P_Business_Flow_name
        {
            get { return _p_business_flow_name; }
            set { _p_business_flow_name = value; }
        }
        
        /// <summary>
        /// 审核状态，（在审核、已通过、未通过）
        /// </summary>
        public int? B_Case_Confirm_checkState
        {
            set { _b_case_Confirm_checkState = value; }
            get { return _b_case_Confirm_checkState; }
        }
        /// <summary>
        /// 审核状态名称（虚拟字段）
        /// </summary>
        public string B_Case_Confirm_checkStateName
        {
            get { return _b_case_Confirm_checkStateName; }
            set { _b_case_Confirm_checkStateName = value; }
        }
        
        /// <summary>
        /// 意见建议
        /// </summary>
        public string B_Case_Confirm_SuggestContent
        {
            set { _b_case_confirm_suggestcontent = value; }
            get { return _b_case_confirm_suggestcontent; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string B_Case_Confirm_remarks
        {
            set { _b_case_confirm_remarks = value; }
            get { return _b_case_confirm_remarks; }
        }
        /// <summary>
        /// 创建人(操作人)
        /// </summary>
        public Guid? B_Case_Confirm_creator
        {
            set { _b_case_confirm_creator = value; }
            get { return _b_case_confirm_creator; }
        }

        /// <summary>
        /// 创建人(操作人)名称(虚拟属性)
        /// </summary>
        public string B_Case_Confirm_creator_name
        {
            set { _b_case_confirm_creator_name = value; }
            get { return _b_case_confirm_creator_name; }
        }

        /// <summary>
        /// 创建时间(操作时间)
        /// </summary>
        public DateTime? B_Case_Confirm_createTime
        {
            set { _b_case_confirm_createtime = value; }
            get { return _b_case_confirm_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool B_Case_Confirm_isDelete
        {
            set { _b_case_confirm_isdelete = value; }
            get { return _b_case_confirm_isdelete; }
        }
        #endregion Model

    }
}
