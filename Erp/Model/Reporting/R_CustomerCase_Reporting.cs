﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    /// <summary>
    /// R_CustomerCase_Reporting:实体类(客户团队交案客户统计)
    /// </summary>
    [Serializable]
    public partial class R_CustomerCase_Reporting
    {
        public R_CustomerCase_Reporting()
        { }
        #region Model
        private int _id;
        private string _r_customercase_reporting_year;
        private string _r_customercase_reporting_month;
        private string _r_customercase_reporting_area;
        private string _r_customercase_reporting_customertype;
        private string _r_customercase_reporting_allcount;
        private string _r_customercase_reporting_typecount;
        private string _r_customercase_reporting_untypecount;
        private string _r_customercase_reporting_transfertarget;
        private string _r_customercase_reporting_typetransfertarget;
        private string _r_customercase_reporting_untypetransfertarget;
        private string _r_customercase_reporting_expectedreturn;
        private string _r_customercase_reporting_typeexpectedreturn;
        private string _r_customercase_reporting_untypeexpectedreturn;
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
        public string R_CustomerCase_Reporting_year
        {
            set { _r_customercase_reporting_year = value; }
            get { return _r_customercase_reporting_year; }
        }
        /// <summary>
        /// 接案月份
        /// </summary>
        public string R_CustomerCase_Reporting_month
        {
            set { _r_customercase_reporting_month = value; }
            get { return _r_customercase_reporting_month; }
        }
        /// <summary>
        /// 地区
        /// </summary>
        public string R_CustomerCase_Reporting_area
        {
            set { _r_customercase_reporting_area = value; }
            get { return _r_customercase_reporting_area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string R_CustomerCase_Reporting_customerType
        {
            set { _r_customercase_reporting_customertype = value; }
            get { return _r_customercase_reporting_customertype; }
        }
        /// <summary>
        /// 接案总数
        /// </summary>
        public string R_CustomerCase_Reporting_allCount
        {
            set { _r_customercase_reporting_allcount = value; }
            get { return _r_customercase_reporting_allcount; }
        }
        /// <summary>
        /// 类型案件数量
        /// </summary>
        public string R_CustomerCase_Reporting_typeCount
        {
            set { _r_customercase_reporting_typecount = value; }
            get { return _r_customercase_reporting_typecount; }
        }
        /// <summary>
        /// 非类型案件数量
        /// </summary>
        public string R_CustomerCase_Reporting_unTypeCount
        {
            set { _r_customercase_reporting_untypecount = value; }
            get { return _r_customercase_reporting_untypecount; }
        }
        /// <summary>
        /// 移交总标的
        /// </summary>
        public string R_CustomerCase_Reporting_transferTarget
        {
            set { _r_customercase_reporting_transfertarget = value; }
            get { return _r_customercase_reporting_transfertarget; }
        }
        /// <summary>
        /// 类型移交标的
        /// </summary>
        public string R_CustomerCase_Reporting_typeTransferTarget
        {
            set { _r_customercase_reporting_typetransfertarget = value; }
            get { return _r_customercase_reporting_typetransfertarget; }
        }
        /// <summary>
        /// 非类型移交标的
        /// </summary>
        public string R_CustomerCase_Reporting_unTypeTransferTarget
        {
            set { _r_customercase_reporting_untypetransfertarget = value; }
            get { return _r_customercase_reporting_untypetransfertarget; }
        }
        /// <summary>
        /// 预期总收益
        /// </summary>
        public string R_CustomerCase_Reporting_expectedReturn
        {
            set { _r_customercase_reporting_expectedreturn = value; }
            get { return _r_customercase_reporting_expectedreturn; }
        }
        /// <summary>
        /// 类型预期收益
        /// </summary>
        public string R_CustomerCase_Reporting_typeExpectedReturn
        {
            set { _r_customercase_reporting_typeexpectedreturn = value; }
            get { return _r_customercase_reporting_typeexpectedreturn; }
        }
        /// <summary>
        /// 非类型预期收益
        /// </summary>
        public string R_CustomerCase_Reporting_unTypeExpectedReturn
        {
            set { _r_customercase_reporting_untypeexpectedreturn = value; }
            get { return _r_customercase_reporting_untypeexpectedreturn; }
        }
        #endregion Model

    }
}
