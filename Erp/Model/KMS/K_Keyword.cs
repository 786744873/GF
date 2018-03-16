using System;
namespace CommonService.Model.KMS
{
	/// <summary>
    /// K_Keyword:关键字表实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class K_Keyword
	{
		public K_Keyword()
		{}
		#region Model
		private int _k_keyword_id;
		private Guid? _k_keyword_code;
		private string _k_keyword_name;
        private DateTime? _k_keyword_createtime;
        private Guid? _k_keyword_creator;
        private bool _k_keyword_isdelete;
        private int _k_keyword_counts;
		/// <summary>
		/// ID，自增长
		/// </summary>
		public int K_Keyword_id
		{
			set{ _k_keyword_id=value;}
			get{return _k_keyword_id;}
		}
		/// <summary>
		/// 关键字guid
		/// </summary>
		public Guid? K_Keyword_code
		{
			set{ _k_keyword_code=value;}
			get{return _k_keyword_code;}
		}
		/// <summary>
		/// 关键字名称
		/// </summary>
		public string K_Keyword_name
		{
			set{ _k_keyword_name=value;}
			get{return _k_keyword_name;}
		}
		/// <summary>
		/// 创建日期
		/// </summary>
        public DateTime? K_Keyword_createTime
		{
            set { _k_keyword_createtime = value; }
            get { return _k_keyword_createtime; }
		}
		/// <summary>
		/// 创建人
		/// </summary>
        public Guid? K_Keyword_creator
		{
            set { _k_keyword_creator = value; }
            get { return _k_keyword_creator; }
		}
		/// <summary>
		/// 是否删除
		/// </summary>
        public bool K_Keyword_isDelete
		{
            set { _k_keyword_isdelete = value; }
            get { return _k_keyword_isdelete; }
		}
        /// <summary>
        ///虚拟字段（关键字个数）
        /// </summary>
        public int K_Keyword_counts
        {
            set { _k_keyword_counts = value; }
            get { return _k_keyword_counts; }
        }
		#endregion Model

	}
}

