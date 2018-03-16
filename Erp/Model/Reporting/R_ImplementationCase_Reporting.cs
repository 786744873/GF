﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    [Serializable]
    public partial class R_ImplementationCase_Reporting
    {
        public R_ImplementationCase_Reporting()
        { }
        #region Model
        private int _id;
        private string _year;
        private string _month;
        private string _areaname;
        private string _hostname;
        private string _coname;
        private string _case_number;
        private string _b_plaintiff_name;
        private string _b_defendant_name;
        private string _b_project_name;
        private string _acceptancetime;
        private string _b_transferprice;
        private string _b_expectedprice;
        private string _jurisdictioncourt;
        private string _documentincome;
        private string _overdueincome;
        private string _dateexecution;
        private string _progresscasemonth;
        private string _progresscompletiontime;
        private string _implementation;
        private string _executionplan;
        private string _salesreturn;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 年份
        /// </summary>
        public string Year
        {
            set { _year = value; }
            get { return _year; }
        }
        /// <summary>
        /// 月份
        /// </summary>
        public string Month
        {
            set { _month = value; }
            get { return _month; }
        }
        /// <summary>
        /// 地区
        /// </summary>
        public string AreaName
        {
            set { _areaname = value; }
            get { return _areaname; }
        }
        /// <summary>
        /// 主办/独立律师
        /// </summary>
        public string HostName
        {
            set { _hostname = value; }
            get { return _hostname; }
        }
        /// <summary>
        /// 协办/助理律师
        /// </summary>
        public string CoName
        {
            set { _coname = value; }
            get { return _coname; }
        }
        /// <summary>
        /// 案号
        /// </summary>
        public string Case_Number
        {
            set { _case_number = value; }
            get { return _case_number; }
        }
        /// <summary>
        /// 原告
        /// </summary>
        public string B_Plaintiff_Name
        {
            set { _b_plaintiff_name = value; }
            get { return _b_plaintiff_name; }
        }
        /// <summary>
        /// 被告
        /// </summary>
        public string B_Defendant_Name
        {
            set { _b_defendant_name = value; }
            get { return _b_defendant_name; }
        }
        /// <summary>
        /// 项目
        /// </summary>
        public string B_Project_Name
        {
            set { _b_project_name = value; }
            get { return _b_project_name; }
        }
        /// <summary>
        /// 收案时间
        /// </summary>
        public string AcceptanceTime
        {
            set { _acceptancetime = value; }
            get { return _acceptancetime; }
        }
        /// <summary>
        /// 移交标的
        /// </summary>
        public string B_TransferPrice
        {
            set { _b_transferprice = value; }
            get { return _b_transferprice; }
        }
        /// <summary>
        /// 预期收入
        /// </summary>
        public string B_ExpectedPrice
        {
            set { _b_expectedprice = value; }
            get { return _b_expectedprice; }
        }
        /// <summary>
        /// 管辖法院
        /// </summary>
        public string JurisdictionCourt
        {
            set { _jurisdictioncourt = value; }
            get { return _jurisdictioncourt; }
        }
        /// <summary>
        /// 文书收入
        /// </summary>
        public string DocumentIncome
        {
            set { _documentincome = value; }
            get { return _documentincome; }
        }
        /// <summary>
        /// 逾期收入
        /// </summary>
        public string OverdueIncome
        {
            set { _overdueincome = value; }
            get { return _overdueincome; }
        }
        /// <summary>
        /// 执行条件成就日期
        /// </summary>
        public string DateExecution
        {
            set { _dateexecution = value; }
            get { return _dateexecution; }
        }
        /// <summary>
        /// 本月案件进展
        /// </summary>
        public string ProgressCaseMonth
        {
            set { _progresscasemonth = value; }
            get { return _progresscasemonth; }
        }
        /// <summary>
        /// 进展完成时间
        /// </summary>
        public string ProgressCompletionTime
        {
            set { _progresscompletiontime = value; }
            get { return _progresscompletiontime; }
        }
        /// <summary>
        /// 执行措施种类
        /// </summary>
        public string Implementation
        {
            set { _implementation = value; }
            get { return _implementation; }
        }
        /// <summary>
        /// 执行划款
        /// </summary>
        public string ExecutionPlan
        {
            set { _executionplan = value; }
            get { return _executionplan; }
        }
        /// <summary>
        /// 可销售回款额
        /// </summary>
        public string SalesReturn
        {
            set { _salesreturn = value; }
            get { return _salesreturn; }
        }
        #endregion Model

    }
}
