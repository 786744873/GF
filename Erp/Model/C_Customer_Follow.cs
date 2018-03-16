using System;
namespace CommonService.Model
{
    /// <summary>
    /// 客户跟进表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/08/7
    /// </summary>
	public partial class C_Customer_Follow
	{
		public C_Customer_Follow()
		{}
		#region Model
        public int _c_customer_follow_id;
        public Guid? _c_customer_follow_code;
        public Guid? _c_customer_code;
        public Guid? _c_customer_follow_contacter;
        public int? _c_customer_follow_contactinformation;
        public string _c_customer_follow_contactinformationname;
        public DateTime? _c_customer_follow_time;
        public string _c_customer_follow_result;
        public int? _c_customer_follow_stage;
        public string _c_customer_follow_stageName;
        public int? _c_customer_follow_isdelete;
        public Guid? _c_customer_follow_creator;
        public string _c_customer_follow_creatorName;
        public DateTime? _c_customer_follow_createtime;
        public string _c_customer_name;
        public string _c_customer_follow_contacter_name;
        public Guid? _c_customer_business_flow;
        public DateTime? _c_customer_createtime;
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int C_Customer_Follow_id
		{
			set{ _c_customer_follow_id=value;}
			get{return _c_customer_follow_id;}
		}
		/// <summary>
		/// GUID
		/// </summary>
		public Guid? C_Customer_Follow_code
		{
			set{ _c_customer_follow_code=value;}
			get{return _c_customer_follow_code;}
		}
		/// <summary>
		/// 客户GUID，关联客户表
		/// </summary>
		public Guid? C_Customer_code
		{
			set{ _c_customer_code=value;}
			get{return _c_customer_code;}
		}
		/// <summary>
		/// 联系人（客户中的联系人）
		/// </summary>
		public Guid? C_Customer_Follow_contacter
		{
			set{ _c_customer_follow_contacter=value;}
			get{return _c_customer_follow_contacter;}
		}
		/// <summary>
		/// 联系方式（parameter）
		/// </summary>
		public int? C_Customer_Follow_contactInformation
		{
			set{ _c_customer_follow_contactinformation=value;}
			get{return _c_customer_follow_contactinformation;}
		}
        /// <summary>
        /// 联系方式名称（虚拟字段）
        /// </summary>
        public string C_Customer_Follow_contactinformationName
        {
            get { return _c_customer_follow_contactinformationname; }
            set { _c_customer_follow_contactinformationname = value; }
        }        
		/// <summary>
		/// 跟进时间
		/// </summary>
		public DateTime? C_Customer_Follow_time
		{
			set{ _c_customer_follow_time=value;}
			get{return _c_customer_follow_time;}
		}
		/// <summary>
		/// 跟进结果
		/// </summary>
		public string C_Customer_Follow_Result
		{
			set{ _c_customer_follow_result=value;}
			get{return _c_customer_follow_result;}
		}
		/// <summary>
		/// 跟进阶段
		/// </summary>
		public int? C_Customer_Follow_Stage
		{
			set{ _c_customer_follow_stage=value;}
			get{return _c_customer_follow_stage;}
		}
        /// <summary>
        /// 跟进阶段名称（虚拟字段）
        /// </summary>
        public string C_Customer_Follow_stageName
        {
            get { return _c_customer_follow_stageName; }
            set { _c_customer_follow_stageName = value; }
        }        
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Customer_Follow_isDelete
		{
			set{ _c_customer_follow_isdelete=value;}
			get{return _c_customer_follow_isdelete;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Customer_Follow_creator
		{
			set{ _c_customer_follow_creator=value;}
			get{return _c_customer_follow_creator;}
		}
        /// <summary>
        /// 创建人名称（虚拟字段）
        /// </summary>
        public string C_Customer_Follow_creatorName
        {
            get { return _c_customer_follow_creatorName; }
            set { _c_customer_follow_creatorName = value; }
        }        
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Customer_Follow_createTime
		{
			set{ _c_customer_follow_createtime=value;}
			get{return _c_customer_follow_createtime;}
		}
        /// <summary>
        /// 客户名称（虚拟字段）
        /// </summary>
        public string C_Customer_name
        {
            get { return _c_customer_name; }
            set { _c_customer_name = value; }
        }
        /// <summary>
        /// 联系人名称（虚拟字段）
        /// </summary>
        public string C_Customer_follow_contacter_name
        {
            get { return _c_customer_follow_contacter_name; }
            set { _c_customer_follow_contacter_name = value; }
        }
        /// <summary>
        /// 跟进的客户正在进行的流程（生命周期）
        /// </summary>
        public Guid? C_Customer_Business_Flow
        {
            set { _c_customer_business_flow = value; }
            get { return _c_customer_business_flow; }
        }
        /// <summary>
        /// 客户创建时间(虚拟字段)
        /// </summary>
        public DateTime? C_Customer_createTime
        {
            set { _c_customer_createtime = value; }
            get { return _c_customer_createtime; }
        }
		#endregion Model

	}
}

