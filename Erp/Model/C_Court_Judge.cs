using System;
namespace CommonService.Model
{
    /// <summary>
    /// 法院法官关联表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/08
    /// </summary>
	[Serializable]
	public partial class C_Court_Judge
	{
		public C_Court_Judge()
		{}
		#region Model
		private int _c_court_judge_id;
		private Guid? _c_court_code;
		private Guid? _c_judge_code;
        private string _c_contacts_name;
		private string _c_court_judge_name;
		private string _c_court_judge_duty;
		private string _c_court_judge_type;
		private int? _c_court_judge_isdelete;
		private Guid? _c_court_judge_creator;
		private DateTime? _c_court_judge_createtime;
		/// <summary>
		/// 内码, 主键，自增
		/// </summary>
		public int C_Court_Judge_id
		{
			set{ _c_court_judge_id=value;}
			get{return _c_court_judge_id;}
		}
		/// <summary>
		/// 法院编码，外键，关联法院
		/// </summary>
		public Guid? C_Court_code
		{
			set{ _c_court_code=value;}
			get{return _c_court_code;}
		}
		/// <summary>
		/// 法官编码，外键，关联法官
		/// </summary>
		public Guid? C_Judge_code
		{
			set{ _c_judge_code=value;}
			get{return _c_judge_code;}
		}
        /// <summary>
        /// 法官姓名(虚拟字段)
        /// </summary>
        public string C_Contacts_name
        {
            get { return _c_contacts_name; }
            set { _c_contacts_name = value; }
        }
		/// <summary>
		/// 人员名称
		/// </summary>
		public string C_Court_Judge_name
		{
			set{ _c_court_judge_name=value;}
			get{return _c_court_judge_name;}
		}
		/// <summary>
		/// 职务
		/// </summary>
		public string C_Court_Judge_duty
		{
			set{ _c_court_judge_duty=value;}
			get{return _c_court_judge_duty;}
		}
		/// <summary>
		/// 负责类型
		/// </summary>
		public string C_Court_Judge_type
		{
			set{ _c_court_judge_type=value;}
			get{return _c_court_judge_type;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? C_Court_Judge_isdelete
		{
			set{ _c_court_judge_isdelete=value;}
			get{return _c_court_judge_isdelete;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? C_Court_Judge_creator
		{
			set{ _c_court_judge_creator=value;}
			get{return _c_court_judge_creator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? C_Court_Judge_createTime
		{
			set{ _c_court_judge_createtime=value;}
			get{return _c_court_judge_createtime;}
		}
		#endregion Model

	}
}

