using System;
namespace CommonService.Model.KMS
{
	/// <summary>
    /// K_Resources:资源表实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class K_Resources
	{
		public K_Resources()
		{}
		#region Model
		private int _k_resources_id;
		private Guid? _k_resources_code;
		private string _k_resources_name;
		private string _k_resources_url;
		private int? _k_resources_type;
        private string _k_resources_typeName;
		private string _k_resources_extension;
		private string _k_resources_description;
		private DateTime? _k_resources_createtime;
		private Guid? _k_resources_creator;
		private bool _k_resources_isdelete;
		private int? _k_resources_state;
        private string _k_resources_stateName;
		private string _k_resources_author;
		private int? _k_resources_zambiacount;
		private int? _k_resources_collectioncount;
        private string _k_resources_Knowledge;
        private string _k_resources_Keyword;
        private int? _k_resources_browseCount;
        private int? _k_resources_downloadCount;
        private string _k_resources_coverImage;
        private int? _k_resources_nouserCount;
        private string _k_resources_Knowledge_code;
        private string _k_resources_Knowledge_name;
        private string _k_resources_creatorName;
        private string _k_resources_Situation;
        private bool _k_resources_permissions;
        private string _k_resources_codeItems;
        private Guid? _k_resources_Knowledge_person;
        private int? _k_browse_logcount;
        private string _p_flow_name;
        private string _f_form_chineseName;
		/// <summary>
		/// ID，自增长
		/// </summary>
		public int K_Resources_id
		{
			set{ _k_resources_id=value;}
			get{return _k_resources_id;}
		}
		/// <summary>
		/// 资源code
		/// </summary>
		public Guid? K_Resources_code
		{
			set{ _k_resources_code=value;}
			get{return _k_resources_code;}
		}
		/// <summary>
		/// 资源名称
		/// </summary>
		public string K_Resources_name
		{
			set{ _k_resources_name=value;}
			get{return _k_resources_name;}
		}
		/// <summary>
		/// 资源地址
		/// </summary>
		public string K_Resources_url
		{
			set{ _k_resources_url=value;}
			get{return _k_resources_url;}
		}
		/// <summary>
		/// 资源类型，外键，关联parameter表，图片、word、视频、pdf、文章、excel等类型
		/// </summary>
		public int? K_Resources_type
		{
			set{ _k_resources_type=value;}
			get{return _k_resources_type;}
		}
        /// <summary>
        /// 资源类型名称（虚拟字段）
        /// </summary>
        public string K_Resources_typeName
        {
            get { return _k_resources_typeName; }
            set { _k_resources_typeName = value; }
        }        
		/// <summary>
		/// 资源扩展名jpg,docx,avi,mp4,pdf,excel等文件后缀
		/// </summary>
		public string K_Resources_Extension
		{
			set{ _k_resources_extension=value;}
			get{return _k_resources_extension;}
		}
		/// <summary>
		/// 资源描述
		/// </summary>
		public string K_Resources_description
		{
			set{ _k_resources_description=value;}
			get{return _k_resources_description;}
		}
		/// <summary>
		/// 资源上传日期
		/// </summary>
		public DateTime? K_Resources_createTime
		{
			set{ _k_resources_createtime=value;}
			get{return _k_resources_createtime;}
		}
		/// <summary>
		/// 资源上传人，外键，关联userinfo表
		/// </summary>
		public Guid? K_Resources_creator
		{
			set{ _k_resources_creator=value;}
			get{return _k_resources_creator;}
		}

        /// <summary>
        /// 上传人名称（虚拟字段）
        /// </summary>
        public string K_Resources_creatorName
        {
            set { _k_resources_creatorName = value; }
            get { return _k_resources_creatorName; }
        }
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool K_Resources_isDelete
		{
			set{ _k_resources_isdelete=value;}
			get{return _k_resources_isdelete;}
		}
		/// <summary>
		/// 资源状态，外键，关联parameter表
		/// </summary>
		public int? K_Resources_state
		{
			set{ _k_resources_state=value;}
			get{return _k_resources_state;}
		}
        /// <summary>
        /// 状态名称（虚拟字段）
        /// </summary>
        public string K_Resources_stateName
        {
            get { return _k_resources_stateName; }
            set { _k_resources_stateName = value; }
        }
        
		/// <summary>
		/// 作者
		/// </summary>
		public string K_Resources_author
		{
			set{ _k_resources_author=value;}
			get{return _k_resources_author;}
		}
		/// <summary>
		/// 被赞次数
		/// </summary>
		public int? K_Resources_zambiaCount
		{
			set{ _k_resources_zambiacount=value;}
			get{return _k_resources_zambiacount;}
		}
		/// <summary>
		/// 收藏次数
		/// </summary>
		public int? K_Resources_collectionCount
		{
			set{ _k_resources_collectioncount=value;}
			get{return _k_resources_collectioncount;}
		}
        /// <summary>
        /// 所属分类（虚拟字段）
        /// </summary>
        public string K_Resources_Knowledge
        {
            get { return _k_resources_Knowledge; }
            set { _k_resources_Knowledge = value; }
        }
        /// <summary>
        /// 关联关键字（虚拟字段）
        /// </summary>
        public string K_Resources_Keyword
        {
            get { return _k_resources_Keyword; }
            set { _k_resources_Keyword = value; }
        }
        /// <summary>
        /// 浏览次数(已无用，可删除)
        /// </summary>
        public int? K_Resources_browseCount
        {
            set { _k_resources_browseCount = value; }
            get { return _k_resources_browseCount; }
        }
        /// <summary>
        /// 浏览次数(虚拟字段)
        /// </summary>
        public int? K_Browse_LogCount
        {
            get { return _k_browse_logcount; }
            set { _k_browse_logcount = value; }
        }
        /// <summary>
        /// 下载次数
        /// </summary>
        public int? K_Resources_downloadCount
        {
            set { _k_resources_downloadCount = value; }
            get { return _k_resources_downloadCount; }
        }
        /// <summary>
        /// 资源封面图片
        /// </summary>
        public string K_Resources_coverImage
        {
            get { return _k_resources_coverImage; }
            set { _k_resources_coverImage = value; }
        }
        /// <summary>
        /// 是否具有下载权限
        /// </summary>
        public bool K_Resources_Permissions
        {
            get { return _k_resources_permissions; }
            set { _k_resources_permissions = value; }
        }
        /// <summary>
        /// 没用次数
        /// </summary>
        public int? K_Resources_nouserCount
        {
            set { _k_resources_nouserCount = value; }
            get { return _k_resources_nouserCount; }
        }
        /// <summary>
        /// 所属知识分类Guid（虚拟字段）
        /// </summary>
        public string K_Resources_Knowledge_code
        {
            get { return _k_resources_Knowledge_code; }
            set { _k_resources_Knowledge_code = value; }
        }
        /// <summary>
        /// 所属知识分类名称（虚拟字段）
        /// </summary>
        public string K_Resources_Knowledge_name
        {
            get { return _k_resources_Knowledge_name; }
            set { _k_resources_Knowledge_name = value; }
        }
        /// <summary>
        /// 资料情况（虚拟字段）
        /// </summary>
        public string K_Resources_Situation
        {
            get { return _k_resources_Situation; }
            set { _k_resources_Situation = value; }
        }
        public string K_Resources_codeItems
        {
            get { return _k_resources_codeItems; }
            set { _k_resources_codeItems = value; }
        }
        /// <summary>
        /// 所属知识分类负责人（虚拟字段）
        /// </summary>
        public Guid? K_Resources_Knowledge_person
        {
            get { return _k_resources_Knowledge_person; }
            set { _k_resources_Knowledge_person = value; }
        }
        /// <summary>
        /// 流程名称（虚拟字段）
        /// </summary>
        public string  P_Flow_name
        {
            get { return _p_flow_name; }
            set { _p_flow_name = value; }
        }
        /// <summary>
        /// 表单名称（虚拟字段）
        /// </summary>
        public string F_Form_chineseName
        {
            get { return _f_form_chineseName; }
            set { _f_form_chineseName = value; }
        }
		#endregion Model

	}
}

