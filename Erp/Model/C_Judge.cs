using System;
namespace CommonService.Model
{
	/// <summary>
	/// 法官表单:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：崔慧栋
    /// 日期：2015/05/04
	/// </summary>
	[Serializable]
	public partial class C_Judge
	{
		public C_Judge()
		{}
		#region Model
		private int _c_judge_id;
		private Guid? _c_judge_code;
        private string _c_contacts_name;
		private string _c_judge_number;
		private Guid? _c_judge_contactscode;
        private bool _c_judge_isdelete;
        private Guid? _c_judge_creator;
        private DateTime? _c_judge_createTime;
        
        
		/// <summary>
		/// 法官内码, 主键，自增
		/// </summary>
		public int C_Judge_id
		{
			set{ _c_judge_id=value;}
			get{return _c_judge_id;}
		}
		/// <summary>
		/// 法官编码
		/// </summary>
		public Guid? C_Judge_code
		{
			set{ _c_judge_code=value;}
			get{return _c_judge_code;}
		}
        /// <summary>
        /// 法官姓名
        /// </summary>
        public string C_Contacts_name
        {
            get { return _c_contacts_name; }
            set { _c_contacts_name = value; }
        }
        
		/// <summary>
		/// 法官代码
		/// </summary>
		public string C_Judge_number
		{
			set{ _c_judge_number=value;}
			get{return _c_judge_number;}
		}
		/// <summary>
		/// 联系人GUID
		/// </summary>
		public Guid? C_Judge_contactscode
		{
			set{ _c_judge_contactscode=value;}
			get{return _c_judge_contactscode;}
		}
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool C_Judge_isdelete
        {
            get { return _c_judge_isdelete; }
            set { _c_judge_isdelete = value; }
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? C_Judge_creator
        {
            get { return _c_judge_creator; }
            set { _c_judge_creator = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_Judge_createTime
        {
            get { return _c_judge_createTime; }
            set { _c_judge_createTime = value; }
        }
		#endregion Model

	}
}

