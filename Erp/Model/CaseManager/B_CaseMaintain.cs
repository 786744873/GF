using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.CaseManager
{
    public class B_CaseMaintain
    {
        #region Model
        public int _b_casemaintain_id;
        public Guid _b_casemaintain_code;
        public Guid _b_case_code;
        public Guid _b_flow_code;
        public string _b_flow_name;
        public Guid _f_form_code;
        public string _f_form_name;
        public DateTime? _b_casemaintain_date;
        public string _b_casemaintain_name;
        public string _b_casemaintain_content;
        public string _b_casemaintain_suggest;
        public string _b_casecost_remarks;
        public Guid _b_casecost_creator;
        public string _b_casecost_creatorName;
        public DateTime? _b_casecost_createtime;
        public int? _b_casecost_isdelete;
        public string _b_case_name;


        public string B_Case_Name 
        {
            set { _b_case_name = value; }
            get { return _b_case_name; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int B_CaseMaintain_id
        {
            set { _b_casemaintain_id = value; }
            get { return _b_casemaintain_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid B_CaseMaintain_code
        {
            set { _b_casemaintain_code = value; }
            get { return _b_casemaintain_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid B_Case_code
        {
            set { _b_case_code = value; }
            get { return _b_case_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid B_Flow_code
        {
            set { _b_flow_code = value; }
            get { return _b_flow_code; }
        }
        /// <summary>
        /// 关联流程名称（虚拟字段）
        /// </summary>
        public string B_Flow_name
        {
            get { return _b_flow_name; }
            set { _b_flow_name = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid F_Form_code
        {
            set { _f_form_code = value; }
            get { return _f_form_code; }
        }
        /// <summary>
        /// 关联表单名称（虚拟字段）
        /// </summary>
        public string F_Form_name
        {
            get { return _f_form_name; }
            set { _f_form_name = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? B_CaseMaintain_Date
        {
            set { _b_casemaintain_date = value; }
            get { return _b_casemaintain_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_CaseMaintain_Name
        {
            set { _b_casemaintain_name = value; }
            get { return _b_casemaintain_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_CaseMaintain_Content
        {
            set { _b_casemaintain_content = value; }
            get { return _b_casemaintain_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_CaseMaintain_Suggest
        {
            set { _b_casemaintain_suggest = value; }
            get { return _b_casemaintain_suggest; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_CaseCost_remarks
        {
            set { _b_casecost_remarks = value; }
            get { return _b_casecost_remarks; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid B_CaseCost_creator
        {
            set { _b_casecost_creator = value; }
            get { return _b_casecost_creator; }
        }
        /// <summary>
        /// 创建人名称（虚拟字段）
        /// </summary>
        public string B_CaseCost_creatorName
        {
            get { return _b_casecost_creatorName; }
            set { _b_casecost_creatorName = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? B_CaseCost_createTime
        {
            set { _b_casecost_createtime = value; }
            get { return _b_casecost_createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? B_CaseCost_isDelete
        {
            set { _b_casecost_isdelete = value; }
            get { return _b_casecost_isdelete; }
        }
        #endregion Model
    }
}
