using System;
namespace CommonService.Model.BusinessChanceManager
{
    /// <summary>
    /// 商机关联表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/07/27
    /// </summary>
	[Serializable]
	public partial class B_BusinessChance_link
	{
		public B_BusinessChance_link()
		{}
		#region Model
		private int _b_businesschance_link_id;
		private Guid? _b_businesschance_code;
		private Guid? _c_fk_code;
		private int? _b_businesschance_link_type;
		private Guid? _b_businesschance_link_creator;
		private DateTime? _b_businesschance_link_createtime;
		private int? _b_businesschance_link_isdelete;
        private string _c_customer_name;
        private string _c_crival_name;
        private string _c_prival_name;
        private string _c_involved_project_name;
        private string _c_userinfo_name;
        private string _c_region_name;
        
		/// <summary>
		/// ID，主键，自增
		/// </summary>
		public int B_BusinessChance_link_id
		{
			set{ _b_businesschance_link_id=value;}
			get{return _b_businesschance_link_id;}
		}
		/// <summary>
		/// 商机编码GUID
		/// </summary>
		public Guid? B_BusinessChance_code
		{
			set{ _b_businesschance_code=value;}
			get{return _b_businesschance_code;}
		}
		/// <summary>
		/// 所关联GUID
		/// </summary>
		public Guid? C_FK_code
		{
			set{ _c_fk_code=value;}
			get{return _c_fk_code;}
		}
		/// <summary>
		/// 关联类型
		/// </summary>
		public int? B_BusinessChance_link_type
		{
			set{ _b_businesschance_link_type=value;}
			get{return _b_businesschance_link_type;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? B_BusinessChance_link_creator
		{
			set{ _b_businesschance_link_creator=value;}
			get{return _b_businesschance_link_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? B_BusinessChance_link_createTime
		{
			set{ _b_businesschance_link_createtime=value;}
			get{return _b_businesschance_link_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? B_BusinessChance_link_isDelete
		{
			set{ _b_businesschance_link_isdelete=value;}
			get{return _b_businesschance_link_isdelete;}
		}
        /// <summary>
        /// 客户，委托人名称（虚拟字段）
        /// </summary>
        public string C_Customer_name
        {
            get { return _c_customer_name; }
            set { _c_customer_name = value; }
        }
        /// <summary>
        /// 对方当事人,被执行人(公司)名称（虚拟字段）
        /// </summary>
        public string C_CRival_name
        {
            get { return _c_crival_name; }
            set { _c_crival_name = value; }
        }
        /// <summary>
        /// 对方当事人,被执行人(个人)名称（虚拟字段）
        /// </summary>
        public string C_PRival_name
        {
            get { return _c_prival_name; }
            set { _c_prival_name = value; }
        }

        /// <summary>
        /// 工程名称（虚拟字段）
        /// </summary>
        public string C_Involved_project_name
        {
            get { return _c_involved_project_name; }
            set { _c_involved_project_name = value; }
        }
        /// <summary>
        /// 销售顾问名称（虚拟字段）
        /// </summary>
        public string C_Userinfo_name
        {
            get { return _c_userinfo_name; }
            set { _c_userinfo_name = value; }
        }
        /// <summary>
        /// 关联区域名称（虚拟字段）
        /// </summary>
        public string C_Region_name
        {
            get { return _c_region_name; }
            set { _c_region_name = value; }
        }
		#endregion Model

	}
}

