using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// 消息--分类中间表:实体类(属性说明自动提取数据库字段的描述信息)
    /// 作者：贺太玉
    /// 日期：2015/12/07
    [Serializable]
    public partial class C_Messages_Category
    {
        public C_Messages_Category()
        { }
        #region Model
        private int _c_messages_category_id;
        private Guid _c_messages_category_code;
        private int? _c_messages_category_bigclass;
        private int? _c_messages_category_smallclass;
        private int? _c_messages_category_type;
        private string _c_messages_category_type_name;
        private int? _c_messages_category_level;
        private bool _c_messages_category_isleaf;
        private Guid _c_messages_category_parent;
        private int? _c_messages_category_sort;
        private bool _c_messages_category_isdelete;
        private int? _c_messages_category_unreadcount;

        /// <summary>
        /// 消息分类流水号，自动增长
        /// </summary>
        public int C_Messages_Category_id
        {
            set { _c_messages_category_id = value; }
            get { return _c_messages_category_id; }
        }
        /// <summary>
        /// 消息分类Guid
        /// </summary>
        public Guid C_Messages_Category_code
        {
            set { _c_messages_category_code = value; }
            get { return _c_messages_category_code; }
        }
        /// <summary>
        /// 消息大类型，关联parameter表，如：案件消息、商机消息、客户消息
        /// </summary>
        public int? C_Messages_Category_bigClass
        {
            set { _c_messages_category_bigclass = value; }
            get { return _c_messages_category_bigclass; }
        }
        /// <summary>
        /// 消息小类型，关联parameter表，如：新增案件、计划任务、任务指派等
        /// </summary>
        public int? C_Messages_Category_smallClass
        {
            set { _c_messages_category_smallclass = value; }
            get { return _c_messages_category_smallclass; }
        }
        /// <summary>
        /// 消息类型，外键，关联C_Parameter表
        /// </summary>
        public int? C_Messages_Category_type
        {
            set { _c_messages_category_type = value; }
            get { return _c_messages_category_type; }
        }

        /// <summary>
        /// 消息类型名称(虚拟属性)
        /// </summary>
        public string C_Messages_Category_type_name
        {
            set { _c_messages_category_type_name = value; }
            get { return _c_messages_category_type_name; }
        }

        /// <summary>
        /// 消息级别
        /// </summary>
        public int? C_Messages_Category_level
        {
            set { _c_messages_category_level = value; }
            get { return _c_messages_category_level; }
        }
        /// <summary>
        /// 是否叶级消息
        /// </summary>
        public bool C_Messages_Category_isLeaf
        {
            set { _c_messages_category_isleaf = value; }
            get { return _c_messages_category_isleaf; }
        }
        /// <summary>
        /// 父级消息分类Guid，关联自己
        /// </summary>
        public Guid C_Messages_Category_parent
        {
            set { _c_messages_category_parent = value; }
            get { return _c_messages_category_parent; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? C_Messages_Category_sort
        {
            set { _c_messages_category_sort = value; }
            get { return _c_messages_category_sort; }
        }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool C_Messages_Category_isDelete
        {
            set { _c_messages_category_isdelete = value; }
            get { return _c_messages_category_isdelete; }
        }

        /// <summary>
        /// 分类消息未读数量(虚拟属性)
        /// </summary>
        public int? C_Messages_Category_unreadcount
        {
            set { _c_messages_category_unreadcount = value; }
            get { return _c_messages_category_unreadcount; }
        }

        #endregion Model

    }

}
