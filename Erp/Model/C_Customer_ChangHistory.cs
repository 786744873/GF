using System;
namespace CommonService.Model
{
    /// <summary>
    /// 客户变更记录表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/11/24
	[Serializable]
	public partial class C_Customer_ChangHistory
	{
		public C_Customer_ChangHistory()
		{}
		#region Model
		private int _c_customer_changhistory_id;
		private Guid? _c_customer_changhistory_code;
		private Guid? _c_customer_changhistory_customer;
		private string _c_customer_changhistory_field;
		private string _c_customer_changhistory_fieldname;
		private string _c_customer_changhistory_oldvalue;
        private string _c_customer_changhistory_oldLdentification;
		private string _c_customer_changhistory_newvalue;
        private string _c_customer_changhistory_newLdentification;
		private Guid? _c_customer_changhistory_submitperson;
		private DateTime? _c_customer_changhistory_submitdate;
		private Guid? _c_customer_changhistory_checkperson;
		private DateTime? _c_customer_changhistory_checkdate;
		private int? _c_customer_changhistory_state;
		private bool? _c_customer_changhistory_isdelete;
		private Guid? _c_customer_changhistory_creator;
		private DateTime? _c_customer_changhistory_createtime;
        private string _c_customer_changhistory_customerName;
        private string _c_customer_changhistory_stateName;
        private string _c_customer_changhistory_submitpersonName;
        private string _c_customer_changhistory_checkpersonName;
        private int? _c_customer_changhistory_type;
        private string _c_customer_changhistory_typeName;
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int C_Customer_ChangHistory_id
		{
			set{ _c_customer_changhistory_id=value;}
			get{return _c_customer_changhistory_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? C_Customer_ChangHistory_code
		{
			set{ _c_customer_changhistory_code=value;}
			get{return _c_customer_changhistory_code;}
		}
		/// <summary>
		/// 关联客户GUID
		/// </summary>
		public Guid? C_Customer_ChangHistory_customer
		{
			set{ _c_customer_changhistory_customer=value;}
			get{return _c_customer_changhistory_customer;}
		}
		/// <summary>
		/// 字段名
		/// </summary>
		public string C_Customer_ChangHistory_field
		{
			set{ _c_customer_changhistory_field=value;}
			get{return _c_customer_changhistory_field;}
		}
		/// <summary>
		/// 字段名称（存字段的中文名即可）
		/// </summary>
		public string C_Customer_ChangHistory_fieldName
		{
			set{ _c_customer_changhistory_fieldname=value;}
			get{return _c_customer_changhistory_fieldname;}
		}
		/// <summary>
		/// 旧值
		/// </summary>
		public string C_Customer_ChangHistory_oldValue
		{
			set{ _c_customer_changhistory_oldvalue=value;}
			get{return _c_customer_changhistory_oldvalue;}
		}
        /// <summary>
        /// 旧值标识
        /// </summary>
        public string C_Customer_ChangHistory_oldLdentification
        {
            get { return _c_customer_changhistory_oldLdentification; }
            set { _c_customer_changhistory_oldLdentification = value; }
        }        
		/// <summary>
		/// 新值
		/// </summary>
		public string C_Customer_ChangHistory_newValue
		{
			set{ _c_customer_changhistory_newvalue=value;}
			get{return _c_customer_changhistory_newvalue;}
		}
        /// <summary>
        /// 新值标识
        /// </summary>
        public string C_Customer_ChangHistory_newLdentification
        {
            get { return _c_customer_changhistory_newLdentification; }
            set { _c_customer_changhistory_newLdentification = value; }
        }
        
		/// <summary>
		/// 提交人
		/// </summary>
		public Guid? C_Customer_ChangHistory_submitPerson
		{
			set{ _c_customer_changhistory_submitperson=value;}
			get{return _c_customer_changhistory_submitperson;}
		}
		/// <summary>
		/// 提交时间
		/// </summary>
		public DateTime? C_Customer_ChangHistory_submitDate
		{
			set{ _c_customer_changhistory_submitdate=value;}
			get{return _c_customer_changhistory_submitdate;}
		}
		/// <summary>
		/// 审核人
		/// </summary>
		public Guid? C_Customer_ChangHistory_checkPerson
		{
			set{ _c_customer_changhistory_checkperson=value;}
			get{return _c_customer_changhistory_checkperson;}
		}
		/// <summary>
		/// 审核时间
		/// </summary>
		public DateTime? C_Customer_ChangHistory_checkDate
		{
			set{ _c_customer_changhistory_checkdate=value;}
			get{return _c_customer_changhistory_checkdate;}
		}
		/// <summary>
		/// 审核状态，存parameter表中，值有：待审核、已通过、未通过
		/// </summary>
		public int? C_Customer_ChangHistory_state
		{
			set{ _c_customer_changhistory_state=value;}
			get{return _c_customer_changhistory_state;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool? C_Customer_ChangHistory_isDelete
		{
			set{ _c_customer_changhistory_isdelete=value;}
			get{return _c_customer_changhistory_isdelete;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Customer_ChangHistory_creator
		{
			set{ _c_customer_changhistory_creator=value;}
			get{return _c_customer_changhistory_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Customer_ChangHistory_createTime
		{
			set{ _c_customer_changhistory_createtime=value;}
			get{return _c_customer_changhistory_createtime;}
		}
        /// <summary>
        /// 客户名称（虚拟字段）
        /// </summary>
        public string C_Customer_ChangHistory_customerName
        {
            get { return _c_customer_changhistory_customerName; }
            set { _c_customer_changhistory_customerName = value; }
        }
        /// <summary>
        /// 审核状态名称（虚拟字段）
        /// </summary>
        public string C_Customer_ChangHistory_stateName
        {
            get { return _c_customer_changhistory_stateName; }
            set { _c_customer_changhistory_stateName = value; }
        }
        /// <summary>
        /// 提交人名称（虚拟字段）
        /// </summary>
        public string C_Customer_ChangHistory_submitpersonName
        {
            get { return _c_customer_changhistory_submitpersonName; }
            set { _c_customer_changhistory_submitpersonName = value; }
        }
        /// <summary>
        /// 审核人名称（虚拟字段）
        /// </summary>
        public string C_Customer_ChangHistory_checkpersonName
        {
            get { return _c_customer_changhistory_checkpersonName; }
            set { _c_customer_changhistory_checkpersonName = value; }
        }
        /// <summary>
        /// 变更记录类型
        /// </summary>
        public int? C_Customer_ChangHistory_type
        {
            get { return _c_customer_changhistory_type; }
            set { _c_customer_changhistory_type = value; }
        }
        /// <summary>
        /// 变更记录类型名称（虚拟字段）
        /// </summary>
        public string C_Customer_changhistory_typeName
        {
            get { return _c_customer_changhistory_typeName; }
            set { _c_customer_changhistory_typeName = value; }
        }
		#endregion Model

	}
}

