using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    [Serializable]
    public partial class R_CollectionSituation_Reporting
    {
        public R_CollectionSituation_Reporting()
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
        private string _handover;
        private string _expectedanddocumentincome;
        private string _actualnumbercases;
        private string _actualhandover;
        private string _actualexpectedanddocumentincome;
        private string _aextecases;
        private string _aextehandover;
        private string _aexteactualexpectedanddocumentincome;
        private string _completioncasesnumber;
        private string _completionhandover;
        private string _completionexpectedanddocumentincome;
        private string _normalcasenumber;
        private string _normalhandover;
        private string _normalexpectedanddocumentincome;
        private string _opponentcasenumber;
        private string _opponenthandover;
        private string _opponentexpectedanddocumentincome;
        private string _transferredcasenumber;
        private string _transferredhandover;
        private string _transferredexpectedanddocumentincome;
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
        /// 移交标的
        /// </summary>
        public string HandOver
        {
            set { _handover = value; }
            get { return _handover; }
        }
        /// <summary>
        /// 预期/文书收入
        /// </summary>
        public string ExpectedandDocumentIncome
        {
            set { _expectedanddocumentincome = value; }
            get { return _expectedanddocumentincome; }
        }
        /// <summary>
        /// 实际完成案件数
        /// </summary>
        public string ActualNumberCases
        {
            set { _actualnumbercases = value; }
            get { return _actualnumbercases; }
        }
        /// <summary>
        /// 移交标的
        /// </summary>
        public string ActualHandOver
        {
            set { _actualhandover = value; }
            get { return _actualhandover; }
        }
        /// <summary>
        /// 预期/文书收入
        /// </summary>
        public string ActualExpectedandDocumentIncome
        {
            set { _actualexpectedanddocumentincome = value; }
            get { return _actualexpectedanddocumentincome; }
        }
        /// <summary>
        /// 申请延期案件数
        /// </summary>
        public string AExteCases
        {
            set { _aextecases = value; }
            get { return _aextecases; }
        }
        /// <summary>
        /// 移交标的
        /// </summary>
        public string AExteHandOver
        {
            set { _aextehandover = value; }
            get { return _aextehandover; }
        }
        /// <summary>
        /// 预期/文书收入
        /// </summary>
        public string AExteActualExpectedandDocumentIncome
        {
            set { _aexteactualexpectedanddocumentincome = value; }
            get { return _aexteactualexpectedanddocumentincome; }
        }
        /// <summary>
        /// 超期完成案件数
        /// </summary>
        public string CompletionCasesNumber
        {
            set { _completioncasesnumber = value; }
            get { return _completioncasesnumber; }
        }
        /// <summary>
        /// 移交标的
        /// </summary>
        public string CompletionHandOver
        {
            set { _completionhandover = value; }
            get { return _completionhandover; }
        }
        /// <summary>
        /// 预期/文书收入
        /// </summary>
        public string CompletionExpectedandDocumentIncome
        {
            set { _completionexpectedanddocumentincome = value; }
            get { return _completionexpectedanddocumentincome; }
        }
        /// <summary>
        /// 正常完成案件数
        /// </summary>
        public string NormalCaseNumber
        {
            set { _normalcasenumber = value; }
            get { return _normalcasenumber; }
        }
        /// <summary>
        /// 移交标的
        /// </summary>
        public string NormalHandOver
        {
            set { _normalhandover = value; }
            get { return _normalhandover; }
        }
        /// <summary>
        /// 预期/文书收入
        /// </summary>
        public string NormalExpectedandDocumentIncome
        {
            set { _normalexpectedanddocumentincome = value; }
            get { return _normalexpectedanddocumentincome; }
        }
        /// <summary>
        /// 对手主动履行案件数
        /// </summary>
        public string OpponentCaseNumber
        {
            set { _opponentcasenumber = value; }
            get { return _opponentcasenumber; }
        }
        /// <summary>
        /// 移交标的
        /// </summary>
        public string OpponentHandOver
        {
            set { _opponenthandover = value; }
            get { return _opponenthandover; }
        }
        /// <summary>
        /// 预期/文书收入
        /// </summary>
        public string OpponentExpectedandDocumentIncome
        {
            set { _opponentexpectedanddocumentincome = value; }
            get { return _opponentexpectedanddocumentincome; }
        }
        /// <summary>
        /// 转执行案件数
        /// </summary>
        public string TransferredCaseNumber
        {
            set { _transferredcasenumber = value; }
            get { return _transferredcasenumber; }
        }
        /// <summary>
        /// 移交标的
        /// </summary>
        public string TransferredHandOver
        {
            set { _transferredhandover = value; }
            get { return _transferredhandover; }
        }
        /// <summary>
        /// 预期/文书收入
        /// </summary>
        public string TransferredExpectedandDocumentIncome
        {
            set { _transferredexpectedanddocumentincome = value; }
            get { return _transferredexpectedanddocumentincome; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SalesReturn
        {
            set { _salesreturn = value; }
            get { return _salesreturn; }
        }
        #endregion Model

    }
}

