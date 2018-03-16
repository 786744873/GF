using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    [Serializable]
    public partial class R_ImplementationMeasures_Reporting
    {
        public R_ImplementationMeasures_Reporting()
        { }
        #region Model
        private int _id;
        private string _year;
        private string _month;
        private string _areaname;
        private string _hostname;
        private string _coname;
        private string _stagedevelopment;
        private string _total;
        private string _executivesubject;
        private string _documentincome;
        private string _overdueincome;
        private string _actualtotal;
        private string _actualexecutivesubject;
        private string _actualdocumentincome;
        private string _actualoverdueincome;
        private string _applicationtotal;
        private string _applicationexecutivesubject;
        private string _applicationdocumentincome;
        private string _applicationoverdueincome;
        private string _total_2;
        private string _completiontotal;
        private string _completionexecutivesubject;
        private string _completiondocumentincome;
        private string _completionoverdueincome;
        private string _normaltotal;
        private string _normalexecutivesubject;
        private string _normaldocumentincome;
        private string _normaloverdueincome;
        private string _bankdeposit;
        private string _vehicle;
        private string _houseproperty;
        private string _land;
        private string _detention;
        private string _other;
        private string _executionplan;
        private string _amount;
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
        /// 案件进展阶段
        /// </summary>
        public string StageDevelopment
        {
            set { _stagedevelopment = value; }
            get { return _stagedevelopment; }
        }
        /// <summary>
        /// 总数
        /// </summary>
        public string Total
        {
            set { _total = value; }
            get { return _total; }
        }
        /// <summary>
        /// 执行标的
        /// </summary>
        public string ExecutiveSubject
        {
            set { _executivesubject = value; }
            get { return _executivesubject; }
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
        /// 实际完成案件数
        /// </summary>
        public string ActualTotal
        {
            set { _actualtotal = value; }
            get { return _actualtotal; }
        }
        /// <summary>
        /// 执行标的
        /// </summary>
        public string ActualExecutiveSubject
        {
            set { _actualexecutivesubject = value; }
            get { return _actualexecutivesubject; }
        }
        /// <summary>
        /// 文书收入
        /// </summary>
        public string ActualDocumentIncome
        {
            set { _actualdocumentincome = value; }
            get { return _actualdocumentincome; }
        }
        /// <summary>
        /// 逾期收入
        /// </summary>
        public string ActualOverdueIncome
        {
            set { _actualoverdueincome = value; }
            get { return _actualoverdueincome; }
        }
        /// <summary>
        /// 申请延期案件数
        /// </summary>
        public string ApplicationTotal
        {
            set { _applicationtotal = value; }
            get { return _applicationtotal; }
        }
        /// <summary>
        /// 执行标的
        /// </summary>
        public string ApplicationExecutiveSubject
        {
            set { _applicationexecutivesubject = value; }
            get { return _applicationexecutivesubject; }
        }
        /// <summary>
        /// 文书收入
        /// </summary>
        public string ApplicationDocumentIncome
        {
            set { _applicationdocumentincome = value; }
            get { return _applicationdocumentincome; }
        }
        /// <summary>
        /// 逾期收入
        /// </summary>
        public string ApplicationOverdueIncome
        {
            set { _applicationoverdueincome = value; }
            get { return _applicationoverdueincome; }
        }
        /// <summary>
        /// 总数
        /// </summary>
        public string Total_2
        {
            set { _total_2 = value; }
            get { return _total_2; }
        }
        /// <summary>
        /// 超期完成案件数
        /// </summary>
        public string CompletionTotal
        {
            set { _completiontotal = value; }
            get { return _completiontotal; }
        }
        /// <summary>
        /// 执行标的
        /// </summary>
        public string CompletionExecutiveSubject
        {
            set { _completionexecutivesubject = value; }
            get { return _completionexecutivesubject; }
        }
        /// <summary>
        /// 文书收入
        /// </summary>
        public string CompletionDocumentIncome
        {
            set { _completiondocumentincome = value; }
            get { return _completiondocumentincome; }
        }
        /// <summary>
        /// 逾期收入
        /// </summary>
        public string CompletionOverdueIncome
        {
            set { _completionoverdueincome = value; }
            get { return _completionoverdueincome; }
        }
        /// <summary>
        /// 正常完成案件数
        /// </summary>
        public string NormalTotal
        {
            set { _normaltotal = value; }
            get { return _normaltotal; }
        }
        /// <summary>
        /// 执行标的
        /// </summary>
        public string NormalExecutiveSubject
        {
            set { _normalexecutivesubject = value; }
            get { return _normalexecutivesubject; }
        }
        /// <summary>
        /// 文书收入
        /// </summary>
        public string NormalDocumentIncome
        {
            set { _normaldocumentincome = value; }
            get { return _normaldocumentincome; }
        }
        /// <summary>
        /// 逾期收入
        /// </summary>
        public string NormalOverdueIncome
        {
            set { _normaloverdueincome = value; }
            get { return _normaloverdueincome; }
        }
        /// <summary>
        /// 银行存款
        /// </summary>
        public string BankDeposit
        {
            set { _bankdeposit = value; }
            get { return _bankdeposit; }
        }
        /// <summary>
        /// 车辆
        /// </summary>
        public string Vehicle
        {
            set { _vehicle = value; }
            get { return _vehicle; }
        }
        /// <summary>
        /// 房产
        /// </summary>
        public string HouseProperty
        {
            set { _houseproperty = value; }
            get { return _houseproperty; }
        }
        /// <summary>
        /// 土地
        /// </summary>
        public string Land
        {
            set { _land = value; }
            get { return _land; }
        }
        /// <summary>
        /// 拘留
        /// </summary>
        public string Detention
        {
            set { _detention = value; }
            get { return _detention; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Other
        {
            set { _other = value; }
            get { return _other; }
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
        /// 本次可销售回款额
        /// </summary>
        public string Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        #endregion Model

    }
}

