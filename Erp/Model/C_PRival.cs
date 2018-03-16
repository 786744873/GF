using System;
namespace CommonService.Model
{
    /// <summary>
    /// (企业)法律对手个人信息表表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/07
    /// </summary>
	public partial class C_PRival
	{
		public C_PRival()
		{}
		#region Model
		public int _c_prival_id;
		public Guid? _c_prival_code;
        public Guid? _c_prival_pcode;
		public string _c_prival_number;
		public string _c_prival_name;
		public int? _c_prival_sex;
		public DateTime? _c_prival_birthday;
		public int? _c_prival_nation;
		public string _c_prival_hometown;
		public int? _c_prival_pa;
		public string _c_prival_address;
		public string _c_prival_cnumber;
		public string _c_prival_phone;
		public string _c_prival_traits;
		public string _c_prival_hobby;
		public int? _c_prival_type;
		public Guid? _c_prival_creator;
		public DateTime? _c_prival_createtime;
		public int? _c_prival_isdelete;
        public string _c_prival_region_code;
        public string _c_prival_region_name;
        public string _c_prival_nation_name;
        public string _c_prival_pa_name;

		/// <summary>
		/// 个人对手ID
		/// </summary>
		public int C_PRival_id
		{
			set{ _c_prival_id=value;}
			get{return _c_prival_id;}
		}
		/// <summary>
		/// 个人对手GUID
		/// </summary>
		public Guid? C_PRival_code
		{
			set{ _c_prival_code=value;}
			get{return _c_prival_code;}
		}
        /// <summary>
        /// 所属GUID
        /// </summary>
        public Guid? C_PRival_pcode
        {
            get { return _c_prival_pcode; }
            set { _c_prival_pcode = value; }
        }
        
		/// <summary>
		/// 对手编码，可定义规则添加
		/// </summary>
		public string C_PRival_number
		{
			set{ _c_prival_number=value;}
			get{return _c_prival_number;}
		}
		/// <summary>
		/// 对手名称
		/// </summary>
		public string C_PRival_name
		{
			set{ _c_prival_name=value;}
			get{return _c_prival_name;}
		}
		/// <summary>
		/// 性别1-男，0-女
		/// </summary>
		public int? C_PRival_sex
		{
			set{ _c_prival_sex=value;}
			get{return _c_prival_sex;}
		}
		/// <summary>
		/// 出生日期
		/// </summary>
		public DateTime? C_PRival_birthday
		{
			set{ _c_prival_birthday=value;}
			get{return _c_prival_birthday;}
		}
		/// <summary>
		/// 民族，外键，关联parameter表
		/// </summary>
		public int? C_PRival_nation
		{
			set{ _c_prival_nation=value;}
			get{return _c_prival_nation;}
		}
		/// <summary>
		/// 籍贯
		/// </summary>
		public string C_PRival_hometown
		{
			set{ _c_prival_hometown=value;}
			get{return _c_prival_hometown;}
		}
		/// <summary>
		/// 政治面貌，外键，关联parameter表
		/// </summary>
		public int? C_PRival_pa
		{
			set{ _c_prival_pa=value;}
			get{return _c_prival_pa;}
		}
		/// <summary>
		/// 住址
		/// </summary>
		public string C_PRival_address
		{
			set{ _c_prival_address=value;}
			get{return _c_prival_address;}
		}
		/// <summary>
		/// 身份证号
		/// </summary>
		public string C_PRival_cnumber
		{
			set{ _c_prival_cnumber=value;}
			get{return _c_prival_cnumber;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string C_PRival_phone
		{
			set{ _c_prival_phone=value;}
			get{return _c_prival_phone;}
		}
		/// <summary>
		/// 性格特征
		/// </summary>
		public string C_PRival_traits
		{
			set{ _c_prival_traits=value;}
			get{return _c_prival_traits;}
		}
		/// <summary>
		/// 兴趣爱好
		/// </summary>
		public string C_PRival_hobby
		{
			set{ _c_prival_hobby=value;}
			get{return _c_prival_hobby;}
		}
		/// <summary>
		/// 1本人 2配偶
		/// </summary>
		public int? C_PRival_type
		{
			set{ _c_prival_type=value;}
			get{return _c_prival_type;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_PRival_creator
		{
			set{ _c_prival_creator=value;}
			get{return _c_prival_creator;}
		}
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime? C_PRival_createTime
		{
			set{ _c_prival_createtime=value;}
			get{return _c_prival_createtime;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_PRival_isDelete
		{
			set{ _c_prival_isdelete=value;}
			get{return _c_prival_isdelete;}
		}
        /// <summary>
        /// 对手关联区域GUID（虚拟字段）
        /// </summary>
        public string C_PRival_region_code
        {
            get { return _c_prival_region_code; }
            set { _c_prival_region_code = value; }
        }
        /// <summary>
        /// 对手关联区域名称（虚拟字段）
        /// </summary>
        public string C_PRival_region_name
        {
            get { return _c_prival_region_name; }
            set { _c_prival_region_name = value; }
        }
        /// <summary>
        /// 民族名称（虚拟字段）
        /// </summary>
        public string C_PRival_nation_name
        {
            get { return _c_prival_nation_name; }
            set { _c_prival_nation_name = value; }
        }
        /// <summary>
        /// 政治面貌名称（虚拟字段）
        /// </summary>
        public string C_PRival_pa_name
        {
            get { return _c_prival_pa_name; }
            set { _c_prival_pa_name = value; }
        }
        
		#endregion Model

	}
}

