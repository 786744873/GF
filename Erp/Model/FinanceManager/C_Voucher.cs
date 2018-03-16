using System;
namespace CommonService.Model.FinanceManager
{
    /// <summary>
    /// 凭证信息表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/08/25
    /// </summary>
	[Serializable]
	public partial class C_Voucher
	{
		public C_Voucher()
		{}
		#region Model
		private int _c_voucher_id;
		private Guid? _c_voucher_code;
		private string _c_voucher_number;
		private int? _c_voucher_state;
		private DateTime? _c_voucher_applicationtime;
        private DateTime? _c_voucher_applicationTime1;
		private Guid? _c_voucher_applicationperson;
		private int? _c_voucher_documenttype;
		private Guid? _c_voucher_department;
        private decimal? _c_voucher_amounts;
        private decimal? _c_voucher_amounts1;
		private Guid? _c_voucher_superiorauditperson;
        private string _c_voucher_superiorauditpersonName;
        private Guid? _c_voucher_financeconfirmperson;
        private string _c_voucher_financeConfirmPersonName;
        private DateTime? _c_voucher_confirmtime;
        private DateTime? _c_voucher_confirmTime1;
		private string _c_voucher_dismissedreasons;
		private int? _c_voucher_auditstatus;
		private int? _c_voucher_paymentmethod;
		private bool? _c_voucher_isdelete;
		private Guid? _c_voucher_creator;
		private DateTime? _c_voucher_createtime;
        private Guid? _c_voucher_region;
        private string _c_voucher_regionName;
        private string _c_voucher_applicationPersonName;
        private string _c_voucher_departmentName;
        private int? _c_voucher_type;
        private string _c_voucher_caseNumber;
        private string _c_voucher_caseName;
        private string _c_voucher_feeloanorfeereimbursementnumber;
        
		/// <summary>
		/// ID
		/// </summary>
		public int C_Voucher_id
		{
			set{ _c_voucher_id=value;}
			get{return _c_voucher_id;}
		}
		/// <summary>
		/// Guid
		/// </summary>
		public Guid? C_Voucher_code
		{
			set{ _c_voucher_code=value;}
			get{return _c_voucher_code;}
		}
		/// <summary>
		/// 编号
		/// </summary>
		public string C_Voucher_number
		{
			set{ _c_voucher_number=value;}
			get{return _c_voucher_number;}
		}
		/// <summary>
		/// 状态  未付、已付
		/// </summary>
		public int? C_Voucher_state
		{
			set{ _c_voucher_state=value;}
			get{return _c_voucher_state;}
		}
		/// <summary>
		/// 申请时间
		/// </summary>
		public DateTime? C_Voucher_applicationTime
		{
			set{ _c_voucher_applicationtime=value;}
			get{return _c_voucher_applicationtime;}
        }
        /// <summary>
        /// 申请时间1（虚拟字段）
        /// </summary>
        public DateTime? C_Voucher_applicationTime1
        {
            get { return _c_voucher_applicationTime1; }
            set { _c_voucher_applicationTime1 = value; }
        }
        
		/// <summary>
		/// 申请人Guid
		/// </summary>
		public Guid? C_Voucher_applicationPerson
		{
			set{ _c_voucher_applicationperson=value;}
			get{return _c_voucher_applicationperson;}
		}
        
        /// <summary>
        /// 申请人名称（虚拟字段）
        /// </summary>
        public string C_Voucher_applicationPersonName
        {
            get { return _c_voucher_applicationPersonName; }
            set { _c_voucher_applicationPersonName = value; }
        }
		/// <summary>
		/// 单据类型  借款、报销
		/// </summary>
		public int? C_Voucher_documentType
		{
			set{ _c_voucher_documenttype=value;}
			get{return _c_voucher_documenttype;}
		}
		/// <summary>
		/// 部门
		/// </summary>
		public Guid? C_Voucher_department
		{
			set{ _c_voucher_department=value;}
			get{return _c_voucher_department;}
		}
        /// <summary>
        /// 部门名称（虚拟字段）
        /// </summary>
        public string C_Voucher_departmentName
        {
            get { return _c_voucher_departmentName; }
            set { _c_voucher_departmentName = value; }
        }
		/// <summary>
		/// 金额
		/// </summary>
		public decimal? C_Voucher_amounts
		{
			set{ _c_voucher_amounts=value;}
			get{return _c_voucher_amounts;}
		}
        /// <summary>
        /// 金额1（虚拟字段）
        /// </summary>
        public decimal? C_Voucher_amounts1
        {
            get { return _c_voucher_amounts1; }
            set { _c_voucher_amounts1 = value; }
        }
        
		/// <summary>
		/// 上级审核人
		/// </summary>
		public Guid? C_Voucher_superiorAuditPerson
		{
			set{ _c_voucher_superiorauditperson=value;}
			get{return _c_voucher_superiorauditperson;}
		}
        /// <summary>
        /// 上级审核人名称（虚拟字段）
        /// </summary>
        public string C_Voucher_superiorAuditPersonName
        {
            get { return _c_voucher_superiorauditpersonName; }
            set { _c_voucher_superiorauditpersonName = value; }
        }
        
		/// <summary>
		/// 财务确认人
		/// </summary>
		public Guid? C_Voucher_financeConfirmPerson
		{
			set{ _c_voucher_financeconfirmperson=value;}
			get{return _c_voucher_financeconfirmperson;}
		}
        /// <summary>
        /// 财务确认人名称（虚拟字段）
        /// </summary>
        public string C_Voucher_financeConfirmPersonName
        {
            get { return _c_voucher_financeConfirmPersonName; }
            set { _c_voucher_financeConfirmPersonName = value; }
        }
        
		/// <summary>
		/// 确认时间
		/// </summary>
		public DateTime? C_Voucher_confirmTime
		{
			set{ _c_voucher_confirmtime=value;}
			get{return _c_voucher_confirmtime;}
		}
        /// <summary>
        /// 确认时间1（虚拟字段）
        /// </summary>
        public DateTime? C_Voucher_confirmTime1
        {
            get { return _c_voucher_confirmTime1; }
            set { _c_voucher_confirmTime1 = value; }
        }
        
		/// <summary>
		/// 驳回理由
		/// </summary>
		public string C_Voucher_dismissedReasons
		{
			set{ _c_voucher_dismissedreasons=value;}
			get{return _c_voucher_dismissedreasons;}
		}
		/// <summary>
		/// 审核状态  未审核、通过、驳回
		/// </summary>
		public int? C_Voucher_auditStatus
		{
			set{ _c_voucher_auditstatus=value;}
			get{return _c_voucher_auditstatus;}
		}
		/// <summary>
		/// 付款方式 现金、支票、汇款
		/// </summary>
		public int? C_Voucher_paymentMethod
		{
			set{ _c_voucher_paymentmethod=value;}
			get{return _c_voucher_paymentmethod;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool? C_Voucher_isDelete
		{
			set{ _c_voucher_isdelete=value;}
			get{return _c_voucher_isdelete;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Voucher_creator
		{
			set{ _c_voucher_creator=value;}
			get{return _c_voucher_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Voucher_createTime
		{
			set{ _c_voucher_createtime=value;}
			get{return _c_voucher_createtime;}
		}
        /// <summary>
        /// 所属区域
        /// </summary>
        public Guid? C_Voucher_region
        {
            get { return _c_voucher_region; }
            set { _c_voucher_region = value; }
        }
        /// <summary>
        /// 所属区域名称（虚拟字段）
        /// </summary>
        public string C_Voucher_regionName
        {
            get { return _c_voucher_regionName; }
            set { _c_voucher_regionName = value; }
        }
        /// <summary>
        /// 表单所属(1,ERP  2,OA)
        /// </summary>
        public int? C_Voucher_type
        {
            set { _c_voucher_type = value; }
            get { return _c_voucher_type; }
        }
        /// <summary>
        /// 案号（虚拟字段）
        /// </summary>
        public string C_Voucher_CaseNumber
        {
            get { return _c_voucher_caseNumber; }
            set { _c_voucher_caseNumber = value; }
        }
        /// <summary>
        /// 案件名称（虚拟字段）
        /// </summary>
        public string C_Voucher_CaseName
        {
            get { return _c_voucher_caseName; }
            set { _c_voucher_caseName = value; }
        }
        /// <summary>
        /// 借款或报销单号(虚拟属性)
        /// </summary>
        public string C_Voucher_FeeLoanOrFeeReimbursementNumber
        {
            get { return _c_voucher_feeloanorfeereimbursementnumber; }
            set { _c_voucher_feeloanorfeereimbursementnumber = value; }
        }

		#endregion Model

	}
}

