using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    /// <summary>
    /// R_TakeCase_Reporting:实体类(客户团队接案统计)
    /// </summary>
    [Serializable]
    public partial class R_TakeCase_Reporting
    {
        public R_TakeCase_Reporting()
        { }
        #region Model
        private int _id;
        private string _r_takecase_reporting_year;
        private string _r_takecase_reporting_month;
        private string _r_takecase_reporting_area;
        private string _r_takeCase_reporting_dept;
        private string _r_takecase_reporting_minister;
        private string _b_takecase_reporting_consultant;
        private string _b_takecase_reporting_customer;
        private string _b_takecase_reporting_neworold;
        private string _b_takecase_reporting_level;
        private string _b_takecase_reporting_loyalty;
        private string _b_takecase_reporting_sect;
        private string _b_takecase_reporting_casenumber;
        private string _b_takecase_reporting_relcustomer;
        private string _b_takecase_reporting_rival;
        private string _b_takecase_reporting_project;
        private string _b_takecase_reporting_plate;
        private string _b_takecase_reporting_property;
        private string _b_takecase_reporting_transfertarget;
        private string _b_takecase_reporting_expectedreturn;
        private string _b_takecase_reporting_court;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 接案年份
        /// </summary>
        public string R_TakeCase_Reporting_year
        {
            set { _r_takecase_reporting_year = value; }
            get { return _r_takecase_reporting_year; }
        }
        /// <summary>
        /// 接案月份
        /// </summary>
        public string R_TakeCase_Reporting_month
        {
            set { _r_takecase_reporting_month = value; }
            get { return _r_takecase_reporting_month; }
        }
        /// <summary>
        /// 地区
        /// </summary>
        public string R_TakeCase_Reporting_area
        {
            set { _r_takecase_reporting_area = value; }
            get { return _r_takecase_reporting_area; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string R_TakeCase_Reporting_dept
        {
            set { _r_takeCase_reporting_dept = value; }
            get { return _r_takeCase_reporting_dept; }
        }
        /// <summary>
        /// 部长/组长
        /// </summary>
        public string R_TakeCase_Reporting_minister
        {
            set { _r_takecase_reporting_minister = value; }
            get { return _r_takecase_reporting_minister; }
        }
        /// <summary>
        /// 专业顾问
        /// </summary>
        public string B_TakeCase_Reporting_consultant
        {
            set { _b_takecase_reporting_consultant = value; }
            get { return _b_takecase_reporting_consultant; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string B_TakeCase_Reporting_customer
        {
            set { _b_takecase_reporting_customer = value; }
            get { return _b_takecase_reporting_customer; }
        }
        /// <summary>
        /// 新老客户
        /// </summary>
        public string B_TakeCase_Reporting_newOrOld
        {
            set { _b_takecase_reporting_neworold = value; }
            get { return _b_takecase_reporting_neworold; }
        }
        /// <summary>
        /// 客户级别
        /// </summary>
        public string B_TakeCase_Reporting_level
        {
            set { _b_takecase_reporting_level = value; }
            get { return _b_takecase_reporting_level; }
        }
        /// <summary>
        /// 客户忠诚度
        /// </summary>
        public string B_TakeCase_Reporting_loyalty
        {
            set { _b_takecase_reporting_loyalty = value; }
            get { return _b_takecase_reporting_loyalty; }
        }
        /// <summary>
        /// 客户流派
        /// </summary>
        public string B_TakeCase_Reporting_sect
        {
            set { _b_takecase_reporting_sect = value; }
            get { return _b_takecase_reporting_sect; }
        }
        /// <summary>
        /// 案号
        /// </summary>
        public string B_TakeCase_Reporting_caseNumber
        {
            set { _b_takecase_reporting_casenumber = value; }
            get { return _b_takecase_reporting_casenumber; }
        }
        /// <summary>
        /// 案件委托人（原告）
        /// </summary>
        public string B_TakeCase_Reporting_relCustomer
        {
            set { _b_takecase_reporting_relcustomer = value; }
            get { return _b_takecase_reporting_relcustomer; }
        }
        /// <summary>
        /// 对手（被告）
        /// </summary>
        public string B_TakeCase_Reporting_rival
        {
            set { _b_takecase_reporting_rival = value; }
            get { return _b_takecase_reporting_rival; }
        }
        /// <summary>
        /// 项目
        /// </summary>
        public string B_TakeCase_Reporting_project
        {
            set { _b_takecase_reporting_project = value; }
            get { return _b_takecase_reporting_project; }
        }
        /// <summary>
        /// 板块
        /// </summary>
        public string B_TakeCase_Reporting_plate
        {
            set { _b_takecase_reporting_plate = value; }
            get { return _b_takecase_reporting_plate; }
        }
        /// <summary>
        /// 性质
        /// </summary>
        public string B_TakeCase_Reporting_property
        {
            set { _b_takecase_reporting_property = value; }
            get { return _b_takecase_reporting_property; }
        }
        /// <summary>
        /// 移交标的
        /// </summary>
        public string B_TakeCase_Reporting_transferTarget
        {
            set { _b_takecase_reporting_transfertarget = value; }
            get { return _b_takecase_reporting_transfertarget; }
        }
        /// <summary>
        /// 预期收益
        /// </summary>
        public string B_TakeCase_Reporting_expectedReturn
        {
            set { _b_takecase_reporting_expectedreturn = value; }
            get { return _b_takecase_reporting_expectedreturn; }
        }
        /// <summary>
        /// 管辖法院
        /// </summary>
        public string B_TakeCase_Reporting_court
        {
            set { _b_takecase_reporting_court = value; }
            get { return _b_takecase_reporting_court; }
        }
        #endregion Model

    }
}
