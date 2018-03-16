using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    /// <summary>
    /// R_CustomerValue_Reporting:实体类(客户团队客户价值统计)
    /// </summary>
    [Serializable]
    public partial class R_CustomerValue_Reporting
    {
        public R_CustomerValue_Reporting()
        { }
        #region Model
        private int _id;
        private string _r_customervalue_reporting_year;
        private string _r_customervalue_reporting_month;
        private string _r_customervalue_reporting_area;
        private string _r_customervalue_reporting_customername;
        private string _r_customervalue_reporting_type;
        private string _r_customervalue_reporting_neworold;
        private string _r_customervalue_reporting_sect;
        private string _r_customervalue_reporting_level;
        private string _r_customervalue_reporting_loyalty;
        private string _r_customervalue_reporting_ftaketime;
        private string _r_customervalue_reporting_ntaketime;
        private string _r_customervalue_reporting_monthtakecount;
        private string _r_customervalue_reporting_monthexpected;
        private string _r_customervalue_reporting_takecount;
        private string _r_customervalue_reporting_expected;
        /// <summary>
        /// 自增长ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 接案年份
        /// </summary>
        public string R_CustomerValue_Reporting_year
        {
            set { _r_customervalue_reporting_year = value; }
            get { return _r_customervalue_reporting_year; }
        }
        /// <summary>
        /// 接案月份
        /// </summary>
        public string R_CustomerValue_Reporting_month
        {
            set { _r_customervalue_reporting_month = value; }
            get { return _r_customervalue_reporting_month; }
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string R_CustomerValue_Reporting_area
        {
            set { _r_customervalue_reporting_area = value; }
            get { return _r_customervalue_reporting_area; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string R_CustomerValue_Reporting_customerName
        {
            set { _r_customervalue_reporting_customername = value; }
            get { return _r_customervalue_reporting_customername; }
        }
        /// <summary>
        /// 客户业务类型
        /// </summary>
        public string R_CustomerValue_Reporting_type
        {
            set { _r_customervalue_reporting_type = value; }
            get { return _r_customervalue_reporting_type; }
        }
        /// <summary>
        /// 新老类型
        /// </summary>
        public string R_CustomerValue_Reporting_newOrOld
        {
            set { _r_customervalue_reporting_neworold = value; }
            get { return _r_customervalue_reporting_neworold; }
        }
        /// <summary>
        /// 客户流派
        /// </summary>
        public string R_CustomerValue_Reporting_sect
        {
            set { _r_customervalue_reporting_sect = value; }
            get { return _r_customervalue_reporting_sect; }
        }
        /// <summary>
        /// 客户级别
        /// </summary>
        public string R_CustomerValue_Reporting_level
        {
            set { _r_customervalue_reporting_level = value; }
            get { return _r_customervalue_reporting_level; }
        }
        /// <summary>
        /// 客户忠诚度
        /// </summary>
        public string R_CustomerValue_Reporting_loyalty
        {
            set { _r_customervalue_reporting_loyalty = value; }
            get { return _r_customervalue_reporting_loyalty; }
        }
        /// <summary>
        /// 首次交案时间
        /// </summary>
        public string R_CustomerValue_Reporting_fTakeTime
        {
            set { _r_customervalue_reporting_ftaketime = value; }
            get { return _r_customervalue_reporting_ftaketime; }
        }
        /// <summary>
        /// 最近一次交案时间
        /// </summary>
        public string R_CustomerValue_Reporting_nTakeTime
        {
            set { _r_customervalue_reporting_ntaketime = value; }
            get { return _r_customervalue_reporting_ntaketime; }
        }
        /// <summary>
        /// 本月交案数
        /// </summary>
        public string R_CustomerValue_Reporting_monthTakeCount
        {
            set { _r_customervalue_reporting_monthtakecount = value; }
            get { return _r_customervalue_reporting_monthtakecount; }
        }
        /// <summary>
        /// 本月预期收入
        /// </summary>
        public string R_CustomerValue_Reporting_monthExpected
        {
            set { _r_customervalue_reporting_monthexpected = value; }
            get { return _r_customervalue_reporting_monthexpected; }
        }
        /// <summary>
        /// 累计交案数
        /// </summary>
        public string R_CustomerValue_Reporting_takeCount
        {
            set { _r_customervalue_reporting_takecount = value; }
            get { return _r_customervalue_reporting_takecount; }
        }
        /// <summary>
        /// 累计预期收入
        /// </summary>
        public string R_CustomerValue_Reporting_Expected
        {
            set { _r_customervalue_reporting_expected = value; }
            get { return _r_customervalue_reporting_expected; }
        }
        #endregion Model

    }
}
