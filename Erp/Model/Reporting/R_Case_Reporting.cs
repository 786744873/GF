using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    /// <summary>
    /// R_Case_Reporting:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class R_Case_Reporting
    {
        public R_Case_Reporting()
        { }
        #region Model
        private int _id;
        private Guid _b_case_code;
        private string _b_case_number;
        private string _b_plaintiff_name;
        private string _b_plaintiff_code;
        private string _b_defendant_name;
        private string _b_defendant_code;
        private string _b_project_name;
        private string _b_project_code;
        private string _b_case_type;
        private DateTime? _b_transfertime;
        private decimal? _b_transferprice;
        private string _b_case_currentstage;
        private string _b_case_allstage;
        private decimal? _b_expectedprice;
        private decimal? _b_documentprice;
        private decimal? _b_overdueprice;
        private decimal? _b_realprice;
        private decimal? _b_totaldisbursementprice;
        private decimal? _b_acceptanceprice;
        private decimal? _b_maintenanceprice;
        private decimal? _b_guaranteeprice;
        private decimal? _b_bondprice;
        private decimal? _b_travelprice;
        private decimal? _b_announcementprice;
        private decimal? _b_courtexecutiveprice;
        private decimal? _b_refundreceivableprice;
        private decimal? _b_courtreceivableprice;
        private decimal? _b_notreceivableprice;
        private decimal? _b_disbursementprice;
        private decimal? _b_totalreceivablesprice;
        private decimal? _b_totalrealprice;
        private decimal? _b_receivableprice;
        private decimal? _b_caseexpensesprice;
        private decimal? _b_caseproceedsprice;
        private string _b_earlywarning;
        private string _b_remark;
        private string _b_Case_cons;
        private string _b_Case_organ;

        /// <summary>
        /// 部门
        /// </summary>
        public string B_Case_organ
        {
            get { return _b_Case_organ; }
            set { _b_Case_organ = value; }
        }
       

        /// <summary>
        /// 专业顾问
        /// </summary>
        public string B_Case_cons
        {
            get { return _b_Case_cons; }
            set { _b_Case_cons = value; }
        }



        public string B_AreaName { get; set; }
        public string B_CaseStatus { get; set; }
        public decimal B_CaseYieldPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        public string B_Case_number
        {
            set { _b_case_number = value; }
            get { return _b_case_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Plaintiff_Name
        {
            set { _b_plaintiff_name = value; }
            get { return _b_plaintiff_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Plaintiff_Code
        {
            set { _b_plaintiff_code = value; }
            get { return _b_plaintiff_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Defendant_Name
        {
            set { _b_defendant_name = value; }
            get { return _b_defendant_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Defendant_Code
        {
            set { _b_defendant_code = value; }
            get { return _b_defendant_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Project_Name
        {
            set { _b_project_name = value; }
            get { return _b_project_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Project_Code
        {
            set { _b_project_code = value; }
            get { return _b_project_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Case_Type
        {
            set { _b_case_type = value; }
            get { return _b_case_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? B_TransferTime
        {
            set { _b_transfertime = value; }
            get { return _b_transfertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_TransferPrice
        {
            set { _b_transferprice = value; }
            get { return _b_transferprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Case_CurrentStage
        {
            set { _b_case_currentstage = value; }
            get { return _b_case_currentstage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Case_AllStage
        {
            set { _b_case_allstage = value; }
            get { return _b_case_allstage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_ExpectedPrice
        {
            set { _b_expectedprice = value; }
            get { return _b_expectedprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_DocumentPrice
        {
            set { _b_documentprice = value; }
            get { return _b_documentprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_OverduePrice
        {
            set { _b_overdueprice = value; }
            get { return _b_overdueprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_RealPrice
        {
            set { _b_realprice = value; }
            get { return _b_realprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_TotalDisbursementPrice
        {
            set { _b_totaldisbursementprice = value; }
            get { return _b_totaldisbursementprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_AcceptancePrice
        {
            set { _b_acceptanceprice = value; }
            get { return _b_acceptanceprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_MaintenancePrice
        {
            set { _b_maintenanceprice = value; }
            get { return _b_maintenanceprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_GuaranteePrice
        {
            set { _b_guaranteeprice = value; }
            get { return _b_guaranteeprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_BondPrice
        {
            set { _b_bondprice = value; }
            get { return _b_bondprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_TravelPrice
        {
            set { _b_travelprice = value; }
            get { return _b_travelprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_AnnouncementPrice
        {
            set { _b_announcementprice = value; }
            get { return _b_announcementprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_CourtExecutivePrice
        {
            set { _b_courtexecutiveprice = value; }
            get { return _b_courtexecutiveprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_RefundReceivablePrice
        {
            set { _b_refundreceivableprice = value; }
            get { return _b_refundreceivableprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_CourtReceivablePrice
        {
            set { _b_courtreceivableprice = value; }
            get { return _b_courtreceivableprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_NotReceivablePrice
        {
            set { _b_notreceivableprice = value; }
            get { return _b_notreceivableprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_DisbursementPrice
        {
            set { _b_disbursementprice = value; }
            get { return _b_disbursementprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_TotalReceivablesPrice
        {
            set { _b_totalreceivablesprice = value; }
            get { return _b_totalreceivablesprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_TotalRealPrice
        {
            set { _b_totalrealprice = value; }
            get { return _b_totalrealprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_ReceivablePrice
        {
            set { _b_receivableprice = value; }
            get { return _b_receivableprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_CaseExpensesPrice
        {
            set { _b_caseexpensesprice = value; }
            get { return _b_caseexpensesprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? B_CaseProceedsPrice
        {
            set { _b_caseproceedsprice = value; }
            get { return _b_caseproceedsprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_EarlyWarning
        {
            set { _b_earlywarning = value; }
            get { return _b_earlywarning; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Remark
        {
            set { _b_remark = value; }
            get { return _b_remark; }
        }
        #endregion Model
    }


    [Serializable]
    public partial class V_Case_Reporting
    {
        #region Model
        private string _id;
        private string _b_case_code;
        private string _b_case_number;
        private string _b_plaintiff_name;
        private string _b_plaintiff_code;
        private string _b_defendant_name;
        private string _b_defendant_code;
        private string _b_project_name;
        private string _b_project_code;
        private string _b_case_type;
        private string _b_transfertime;
        private string _b_transferprice;
        private string _b_case_currentstage;
        private string _b_case_allstage;
        private string _b_expectedprice;
        private string _b_documentprice;
        private string _b_overdueprice;
        private string _b_realprice;
        private string _b_totaldisbursementprice;
        private string _b_acceptanceprice;
        private string _b_maintenanceprice;
        private string _b_guaranteeprice;
        private string _b_bondprice;
        private string _b_travelprice;
        private string _b_announcementprice;
        private string _b_courtexecutiveprice;
        private string _b_refundreceivableprice;
        private string _b_courtreceivableprice;
        private string _b_notreceivableprice;
        private string _b_disbursementprice;
        private string _b_totalreceivablesprice;
        private string _b_totalrealprice;
        private string _b_receivableprice;
        private string _b_caseexpensesprice;
        private string _b_caseproceedsprice;
        private string _b_earlywarning;
        private string _b_remark;
        private string _b_Case_cons;

        /// <summary>
        /// 专业顾问
        /// </summary>
        public string B_Case_cons
        {
            get { return _b_Case_cons; }
            set { _b_Case_cons = value; }
        }
        private string _b_Case_organ;


        public string B_Case_organ
        {
            get { return _b_Case_organ; }
            set { _b_Case_organ = value; }
        }

        public string B_AreaName { get; set; }
        public string B_CaseStatus { get; set; }
        public string B_CaseYieldPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Case_code
        {
            set { _b_case_code = value; }
            get { return _b_case_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Case_number
        {
            set { _b_case_number = value; }
            get { return _b_case_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Plaintiff_Name
        {
            set { _b_plaintiff_name = value; }
            get { return _b_plaintiff_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Plaintiff_Code
        {
            set { _b_plaintiff_code = value; }
            get { return _b_plaintiff_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Defendant_Name
        {
            set { _b_defendant_name = value; }
            get { return _b_defendant_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Defendant_Code
        {
            set { _b_defendant_code = value; }
            get { return _b_defendant_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Project_Name
        {
            set { _b_project_name = value; }
            get { return _b_project_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Project_Code
        {
            set { _b_project_code = value; }
            get { return _b_project_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Case_Type
        {
            set { _b_case_type = value; }
            get { return _b_case_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_TransferTime
        {
            set { _b_transfertime = value; }
            get { return _b_transfertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_TransferPrice
        {
            set { _b_transferprice = value; }
            get { return _b_transferprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Case_CurrentStage
        {
            set { _b_case_currentstage = value; }
            get { return _b_case_currentstage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Case_AllStage
        {
            set { _b_case_allstage = value; }
            get { return _b_case_allstage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_ExpectedPrice
        {
            set { _b_expectedprice = value; }
            get { return _b_expectedprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_DocumentPrice
        {
            set { _b_documentprice = value; }
            get { return _b_documentprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_OverduePrice
        {
            set { _b_overdueprice = value; }
            get { return _b_overdueprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_RealPrice
        {
            set { _b_realprice = value; }
            get { return _b_realprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_TotalDisbursementPrice
        {
            set { _b_totaldisbursementprice = value; }
            get { return _b_totaldisbursementprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_AcceptancePrice
        {
            set { _b_acceptanceprice = value; }
            get { return _b_acceptanceprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_MaintenancePrice
        {
            set { _b_maintenanceprice = value; }
            get { return _b_maintenanceprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_GuaranteePrice
        {
            set { _b_guaranteeprice = value; }
            get { return _b_guaranteeprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_BondPrice
        {
            set { _b_bondprice = value; }
            get { return _b_bondprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_TravelPrice
        {
            set { _b_travelprice = value; }
            get { return _b_travelprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_AnnouncementPrice
        {
            set { _b_announcementprice = value; }
            get { return _b_announcementprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_CourtExecutivePrice
        {
            set { _b_courtexecutiveprice = value; }
            get { return _b_courtexecutiveprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_RefundReceivablePrice
        {
            set { _b_refundreceivableprice = value; }
            get { return _b_refundreceivableprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_CourtReceivablePrice
        {
            set { _b_courtreceivableprice = value; }
            get { return _b_courtreceivableprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_NotReceivablePrice
        {
            set { _b_notreceivableprice = value; }
            get { return _b_notreceivableprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_DisbursementPrice
        {
            set { _b_disbursementprice = value; }
            get { return _b_disbursementprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_TotalReceivablesPrice
        {
            set { _b_totalreceivablesprice = value; }
            get { return _b_totalreceivablesprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_TotalRealPrice
        {
            set { _b_totalrealprice = value; }
            get { return _b_totalrealprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_ReceivablePrice
        {
            set { _b_receivableprice = value; }
            get { return _b_receivableprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_CaseExpensesPrice
        {
            set { _b_caseexpensesprice = value; }
            get { return _b_caseexpensesprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_CaseProceedsPrice
        {
            set { _b_caseproceedsprice = value; }
            get { return _b_caseproceedsprice; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string B_EarlyWarning
        {
            set { _b_earlywarning = value; }
            get { return _b_earlywarning; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Remark
        {
            set { _b_remark = value; }
            get { return _b_remark; }
        }
        #endregion Model
    }
}
