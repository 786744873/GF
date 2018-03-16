using System;
namespace CommonService.Model.KMS
{
    /// <summary>
    /// K_Comments:评论（回答）表实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class K_Comments
    {
        public K_Comments()
        { }
        #region Model
        private int _k_comments_id;
        private Guid? _k_comments_code;
        private int? _k_comments_type;
        private string _k_comments_typeName;
        private string _k_comments_content;
        private int? _k_comments_score;
        private Guid? _k_comments_parent;
        private string _k_comments_parentName;
        private DateTime? _k_comments_createtime;
        private Guid? _k_comments_creator;
        private bool _k_comments_isdelete;
        private bool _k_comments_helpfulcount;
        private int? _k_comments_uselesscount;
        private Guid? _p_fk_code;
        private string _p_fk_name;
        private string _c_userinfo_name;
        private string _c_userinfo_parentname;
        private int? _k_comments_adoptCount;
        private string _k_resources_url;
        private int? _k_resources_type;
        private int? _c_messages_id;
        private int? _k_comments_floors;
        private int? _k_comments_parentFloors;
        private DateTime? _k_comments_parentTime;

        /// <summary>
        /// ID，自增长
        /// </summary>
        public int K_Comments_id
        {
            set { _k_comments_id = value; }
            get { return _k_comments_id; }
        }
        /// <summary>
        /// 评论guid
        /// </summary>
        public Guid? K_Comments_code
        {
            set { _k_comments_code = value; }
            get { return _k_comments_code; }
        }
        /// <summary>
        /// 评论类型，外键，关联parament表 资源评论/问吧回答
        /// </summary>
        public int? K_Comments_type
        {
            set { _k_comments_type = value; }
            get { return _k_comments_type; }
        }
        /// <summary>
        /// 类型名称（虚拟字段）
        /// </summary>
        public string K_Comments_typeName
        {
            get { return _k_comments_typeName; }
            set { _k_comments_typeName = value; }
        }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string K_Comments_content
        {
            set { _k_comments_content = value; }
            get { return _k_comments_content; }
        }
        /// <summary>
        /// 评论分值
        /// </summary>
        public int? K_Comments_score
        {
            set { _k_comments_score = value; }
            get { return _k_comments_score; }
        }
        /// <summary>
        /// 所属父级评论guid
        /// </summary>
        public Guid? K_Comments_parent
        {
            set { _k_comments_parent = value; }
            get { return _k_comments_parent; }
        }
        /// <summary>
        /// 父级评论（虚拟字段）
        /// </summary>
        public string K_Comments_parentName
        {
            get { return _k_comments_parentName; }
            set { _k_comments_parentName = value; }
        }
        /// <summary>
        /// 父级评论时间（虚拟字段）
        /// </summary>
        public DateTime? K_Comments_parentTime
        {
            get { return _k_comments_parentTime; }
            set { _k_comments_parentTime = value; }
        }
        /// <summary>
        /// 父级楼层（虚拟字段）
        /// </summary>
        public int? K_Comments_parentFloors
        {
            get { return _k_comments_parentFloors; }
            set { _k_comments_parentFloors = value; }
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? K_Comments_createTime
        {
            set { _k_comments_createtime = value; }
            get { return _k_comments_createtime; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? K_Comments_creator
        {
            set { _k_comments_creator = value; }
            get { return _k_comments_creator; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool K_Comments_isDelete
        {
            set { _k_comments_isdelete = value; }
            get { return _k_comments_isdelete; }
        }
        /// <summary>
        /// 有用次数
        /// </summary>
        public bool K_Comments_helpfulCount
        {
            set { _k_comments_helpfulcount = value; }
            get { return _k_comments_helpfulcount; }
        }
        /// <summary>
        /// 无用次数
        /// </summary>
        public int? K_Comments_uselessCount
        {
            set { _k_comments_uselesscount = value; }
            get { return _k_comments_uselesscount; }
        }
        /// <summary>
        /// 评论楼层
        /// </summary>
        public int? K_Comments_floors
        {
            set { _k_comments_floors = value; }
            get { return _k_comments_floors; }
        }
        /// <summary>
        /// 外键guid（资源，问吧）
        /// </summary>
        public Guid? P_FK_code
        {
            set { _p_fk_code = value; }
            get { return _p_fk_code; }
        }
        /// <summary>
        /// 关联资源/问吧名称（虚拟字段）
        /// </summary>
        public string P_FK_name
        {
            get { return _p_fk_name; }
            set { _p_fk_name = value; }
        }
        /// <summary>
        /// (虚拟属性)评论人名
        /// </summary>
        public string C_Userinfo_name
        {
            set { _c_userinfo_name = value; }
            get { return _c_userinfo_name; }
        }
        /// <summary>
        /// (虚拟属性)评论人名
        /// </summary>
        public string C_Userinfo_parentname
        {
            set { _c_userinfo_parentname = value; }
            get { return _c_userinfo_parentname; }
        }
        /// <summary>
        /// 评论被采纳数（虚拟字段）
        /// </summary>
        public int? K_Comments_adoptCount
        {
            get { return _k_comments_adoptCount; }
            set { _k_comments_adoptCount = value; }
        }
        /// <summary>
        /// 资源Url（虚拟字段）
        /// </summary>
        public string K_Resources_url
        {
            get { return _k_resources_url; }
            set { _k_resources_url = value; }
        }
        /// <summary>
        /// 资源类型（虚拟字段）
        /// </summary>
        public int? K_Resources_type
        {
            get { return _k_resources_type; }
            set { _k_resources_type = value; }
        }
        /// <summary>
        /// 消息Id（虚拟字段）
        /// </summary>
        public int? C_Messages_id
        {
            get { return _c_messages_id; }
            set { _c_messages_id = value; }
        }
        #endregion Model

    }
}

