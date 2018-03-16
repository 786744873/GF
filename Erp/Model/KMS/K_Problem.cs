using System;
namespace CommonService.Model.KMS
{
	/// <summary>
    /// K_Problem:问题表实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class K_Problem
	{
		public K_Problem()
		{}
		#region Model
		private int _k_problem_id;
		private Guid? _k_problem_code;
		private string _k_problem_content;
		private int? _k_problem_statue;
        private string _k_problem_statueName;
		private DateTime? _k_problem_createtime;
		private Guid? _k_problem_creator;
        private string _k_problem_creatorName;
		private bool _k_problem_isdelete;
        private int? _k_problem_auditStatue;
        private string _k_problem_auditStatueName;
        private int? _k_problem_browseCount;
        private Guid? _k_problem_Knowledge_code;
        private string _k_problem_Knowledge_name;
        private Guid? _k_problem_Knowledge_person;
        private int? _k_problem_AnswerCount;
        private string _k_problem_codeiems;
        private int? _k_browse_logcount;
        private string _p_flow_name;
        private string _f_form_chineseName;
		/// <summary>
		/// ID，自增长
		/// </summary>
		public int K_Problem_id
		{
			set{ _k_problem_id=value;}
			get{return _k_problem_id;}
		}
		/// <summary>
		/// 问题guid
		/// </summary>
		public Guid? K_Problem_code
		{
			set{ _k_problem_code=value;}
			get{return _k_problem_code;}
		}
		/// <summary>
		/// 问题内容
		/// </summary>
		public string K_Problem_content
		{
			set{ _k_problem_content=value;}
			get{return _k_problem_content;}
		}
		/// <summary>
		/// 问题状态 外键，关联parament，未审核，已审核，未解决，已解决。
		/// </summary>
		public int? K_Problem_statue
		{
			set{ _k_problem_statue=value;}
			get{return _k_problem_statue;}
		}
        /// <summary>
        /// 问题状态名称（虚拟字段）
        /// </summary>
        public string K_Problem_statueName
        {
            get { return _k_problem_statueName; }
            set { _k_problem_statueName = value; }
        }        
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime? K_Problem_createTime
		{
			set{ _k_problem_createtime=value;}
			get{return _k_problem_createtime;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid? K_Problem_creator
		{
			set{ _k_problem_creator=value;}
			get{return _k_problem_creator;}
		}
        /// <summary>
        /// 创建人名称（虚拟字段）
        /// </summary>
        public string K_Problem_creatorName
        {
            get { return _k_problem_creatorName; }
            set { _k_problem_creatorName = value; }
        }        
		/// <summary>
		/// 是否删除
		/// </summary>
		public bool K_Problem_isDelete
		{
			set{ _k_problem_isdelete=value;}
			get{return _k_problem_isdelete;}
		}
        /// <summary>
        /// 问题审核状态
        /// </summary>
        public int? K_Problem_auditStatue
        {
            get { return _k_problem_auditStatue; }
            set { _k_problem_auditStatue = value; }
        }
        /// <summary>
        /// 问题审核状态名称（虚拟字段）
        /// </summary>
        public string K_Problem_auditStatueName
        {
            get { return _k_problem_auditStatueName; }
            set { _k_problem_auditStatueName = value; }
        }
        /// <summary>
        /// 浏览次数(暂时无用，可删除)
        /// </summary>
        public int? K_Problem_browseCount
        {
            get { return _k_problem_browseCount; }
            set { _k_problem_browseCount = value; }
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
        /// 所属知识分类Guid（虚拟字段）
        /// </summary>
        public Guid? K_Problem_Knowledge_code
        {
            get { return _k_problem_Knowledge_code; }
            set { _k_problem_Knowledge_code = value; }
        }
        /// <summary>
        /// 所属知识分类名称（虚拟字段）
        /// </summary>
        public string K_Problem_Knowledge_name
        {
            get { return _k_problem_Knowledge_name; }
            set { _k_problem_Knowledge_name = value; }
        }
        /// <summary>
        /// 所属知识分类负责人（虚拟字段）
        /// </summary>
        public Guid? K_Problem_Knowledge_person
        {
            get { return _k_problem_Knowledge_person; }
            set { _k_problem_Knowledge_person = value; }
        }        
        /// <summary>
        /// 回答次数（虚拟字段）
        /// </summary>
        public int? K_Problem_AnswerCount
        {
            get { return _k_problem_AnswerCount; }
            set { _k_problem_AnswerCount = value; }
        }
        /// <summary>
        /// 虚拟字段（索引查询后的数据code集合）
        /// </summary>
        public string K_Problem_codeItems
        {
            get { return _k_problem_codeiems; }
            set { _k_problem_codeiems = value; }
        }
        /// <summary>
        /// 流程名称（虚拟字段）
        /// </summary>
        public string P_Flow_name
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

