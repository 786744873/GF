using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    /// <summary>
    /// R_AreaCase_Reporting:实体类(客户团队地区接案统计)
    /// </summary>
    [Serializable]
    public partial class R_AreaCase_Reporting
    {
        public R_AreaCase_Reporting()
        { }
        #region Model
        private int _id;
        private string _r_areacase_reporting_year;
        private string _r_areacase_reporting_month;
        private string _r_areacase_reporting_area;
        private string _r_areacase_reporting_allcount;
        private string _r_areacase_reporting_typecount;
        private string _r_areacase_reporting_untypecount;
        private string _r_areacase_reporting_customercount;
        private string _r_areacase_reporting_newcustomer;
        private string _r_areacase_reporting_oldcustomer;
        private string _r_areacase_reporting_transfertarget;
        private string _r_areacase_reporting_typetransfertarget;
        private string _r_areacase_reporting_untypetransfertarget;
        private string _r_areacase_reporting_expectedreturn;
        private string _r_areacase_reporting_typeexpectedreturn;
        private string _r_areacase_reporting_untypeexpectedreturn;
        private string _r_areacase_reporting_monthcount;
        private string _r_areacase_reporting_ccompletion;
        private string _r_areacase_reporting_nextmonthcount;
        private string _r_areacase_reporting_monthexpected;
        private string _r_areacase_reporting_ecompletion;
        private string _r_areacase_reporting_nextmonthexpected;
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
        public string R_AreaCase_Reporting_year
        {
            set { _r_areacase_reporting_year = value; }
            get { return _r_areacase_reporting_year; }
        }
        /// <summary>
        /// 接案月份
        /// </summary>
        public string R_AreaCase_Reporting_month
        {
            set { _r_areacase_reporting_month = value; }
            get { return _r_areacase_reporting_month; }
        }
        /// <summary>
        /// 地区
        /// </summary>
        public string R_AreaCase_Reporting_area
        {
            set { _r_areacase_reporting_area = value; }
            get { return _r_areacase_reporting_area; }
        }
        /// <summary>
        /// 接案总数
        /// </summary>
        public string R_AreaCase_Reporting_allCount
        {
            set { _r_areacase_reporting_allcount = value; }
            get { return _r_areacase_reporting_allcount; }
        }
        /// <summary>
        /// 类型案件数量
        /// </summary>
        public string R_AreaCase_Reporting_typeCount
        {
            set { _r_areacase_reporting_typecount = value; }
            get { return _r_areacase_reporting_typecount; }
        }
        /// <summary>
        /// 非类型案件数量
        /// </summary>
        public string R_AreaCase_Reporting_unTypeCount
        {
            set { _r_areacase_reporting_untypecount = value; }
            get { return _r_areacase_reporting_untypecount; }
        }
        /// <summary>
        /// 客户总数
        /// </summary>
        public string R_AreaCase_Reporting_customerCount
        {
            set { _r_areacase_reporting_customercount = value; }
            get { return _r_areacase_reporting_customercount; }
        }
        /// <summary>
        /// 新客户数量
        /// </summary>
        public string R_AreaCase_Reporting_newCustomer
        {
            set { _r_areacase_reporting_newcustomer = value; }
            get { return _r_areacase_reporting_newcustomer; }
        }
        /// <summary>
        /// 老客户数量
        /// </summary>
        public string R_AreaCase_Reporting_oldCustomer
        {
            set { _r_areacase_reporting_oldcustomer = value; }
            get { return _r_areacase_reporting_oldcustomer; }
        }
        /// <summary>
        /// 移交总标的
        /// </summary>
        public string R_AreaCase_Reporting_transferTarget
        {
            set { _r_areacase_reporting_transfertarget = value; }
            get { return _r_areacase_reporting_transfertarget; }
        }
        /// <summary>
        /// 类型移交标的
        /// </summary>
        public string R_AreaCase_Reporting_typeTransferTarget
        {
            set { _r_areacase_reporting_typetransfertarget = value; }
            get { return _r_areacase_reporting_typetransfertarget; }
        }
        /// <summary>
        /// 非类型移交标的
        /// </summary>
        public string R_AreaCase_Reporting_unTypeTransferTarget
        {
            set { _r_areacase_reporting_untypetransfertarget = value; }
            get { return _r_areacase_reporting_untypetransfertarget; }
        }
        /// <summary>
        /// 预期总收益
        /// </summary>
        public string R_AreaCase_Reporting_expectedReturn
        {
            set { _r_areacase_reporting_expectedreturn = value; }
            get { return _r_areacase_reporting_expectedreturn; }
        }
        /// <summary>
        /// 类型预期收益
        /// </summary>
        public string R_AreaCase_Reporting_typeExpectedReturn
        {
            set { _r_areacase_reporting_typeexpectedreturn = value; }
            get { return _r_areacase_reporting_typeexpectedreturn; }
        }
        /// <summary>
        /// 非类型预期收益
        /// </summary>
        public string R_AreaCase_Reporting_unTypeExpectedReturn
        {
            set { _r_areacase_reporting_untypeexpectedreturn = value; }
            get { return _r_areacase_reporting_untypeexpectedreturn; }
        }
        /// <summary>
        /// 本月计划接案数
        /// </summary>
        public string R_AreaCase_Reporting_monthCount
        {
            set { _r_areacase_reporting_monthcount = value; }
            get { return _r_areacase_reporting_monthcount; }
        }
        /// <summary>
        /// 完成率
        /// </summary>
        public string R_AreaCase_Reporting_cCompletion
        {
            set { _r_areacase_reporting_ccompletion = value; }
            get { return _r_areacase_reporting_ccompletion; }
        }
        /// <summary>
        /// 下月计划接案数
        /// </summary>
        public string R_AreaCase_Reporting_nextMonthCount
        {
            set { _r_areacase_reporting_nextmonthcount = value; }
            get { return _r_areacase_reporting_nextmonthcount; }
        }
        /// <summary>
        /// 本月计划预期收益
        /// </summary>
        public string R_AreaCase_Reporting_monthExpected
        {
            set { _r_areacase_reporting_monthexpected = value; }
            get { return _r_areacase_reporting_monthexpected; }
        }
        /// <summary>
        /// 完成率
        /// </summary>
        public string R_AreaCase_Reporting_eCompletion
        {
            set { _r_areacase_reporting_ecompletion = value; }
            get { return _r_areacase_reporting_ecompletion; }
        }
        /// <summary>
        /// 下月计划预期收益
        /// </summary>
        public string R_AreaCase_Reporting_nextMonthExpected
        {
            set { _r_areacase_reporting_nextmonthexpected = value; }
            get { return _r_areacase_reporting_nextmonthexpected; }
        }
        #endregion Model

    }
}
