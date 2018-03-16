using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model
{
    /// <summary>
    /// C_Messages:实体类(属性说明自动提取数据库字段的描述信息)消息表
    /// 作者：陈永俊
    /// 时间：2015年6月8日16:34:13
    /// </summary>
    [Serializable]
    public partial class C_Messages
    {
        public C_Messages()
        { }
        #region Model
        public int _c_messages_id;
        public int? _c_messages_ftype;
        public int? _c_messages_type;
        public string _c_messages_type_str;
        public string _c_messages_type_name;
        public Guid? _c_messages_link;
        public DateTime? _c_messages_createtime;
        public Guid? _c_messages_person;
        public int? _c_messages_isread;
        public string _c_messages_content;
        public string _c_messages_relationbusiness;
        public int? _c_messages_isvalidate;
        public int? _c_messages_type_category_type;
        public string _c_messages_code;

        /// <summary>
        /// 关联的编码（App专用）
        /// </summary>
        public string C_Messages_code
        {
            get { return _c_messages_code; }
            set { _c_messages_code = value; }
        }

        public string C_Messages_link_2 { get; set; }
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int C_Messages_id
        {
            set { _c_messages_id = value; }
            get { return _c_messages_id; }
        }
        /// <summary>
        /// 消息大类型，关联parameter表，如：案件消息、商机消息、客户消息
        /// </summary>
        public int? C_Messages_fType
        {
            set { _c_messages_ftype = value; }
            get { return _c_messages_ftype; }
        }
        /// <summary>
        /// 消息小类型，关联parameter表，如：新增案件、计划任务、任务指派等
        /// </summary>
        public int? C_Messages_type
        {
            set { _c_messages_type = value; }
            get { return _c_messages_type; }
        }

        /// <summary>
        /// 消息小类型，字符串(虚拟属性)
        /// </summary>
        public string C_Messages_type_str
        {
            set { _c_messages_type_str = value; }
            get { return _c_messages_type_str; }
        }

        /// <summary>
        /// 消息分类类型(虚拟属性)
        /// </summary>
        public int? C_Messages_Category_type
        {
            set { _c_messages_type_category_type = value; }
            get { return _c_messages_type_category_type; }
        }

        /// <summary>
        /// 消息小类型名称(虚拟属性)
        /// </summary>
        public string C_Messages_type_name
        {
            set { _c_messages_type_name = value; }
            get { return _c_messages_type_name; }
        }

        /// <summary>
        /// 关联GUID
        /// </summary>
        public Guid? C_Messages_link
        {
            set { _c_messages_link = value; }
            get { return _c_messages_link; }
        }
        /// <summary>
        /// 消息时间
        /// </summary>
        public DateTime? C_Messages_createTime
        {
            set { _c_messages_createtime = value; }
            get { return _c_messages_createtime; }
        }
        /// <summary>
        /// 消息人GUID（给谁的消息）
        /// </summary>
        public Guid? C_Messages_person
        {
            set { _c_messages_person = value; }
            get { return _c_messages_person; }
        }
        /// <summary>
        /// 是否已读
        /// </summary>
        public int? C_Messages_isRead
        {
            set { _c_messages_isread = value; }
            get { return _c_messages_isread; }
        }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string C_Messages_content
        {
            set { _c_messages_content = value; }
            get { return _c_messages_content; }
        }

        /// <summary>
        /// 关联业务标识(虚拟属性)
        /// </summary>
        public string C_Messages_relationBusiness
        {
            set { _c_messages_relationbusiness = value; }
            get { return _c_messages_relationbusiness; }
        }
        
        /// <summary>
        /// 是否有效
        /// </summary>
        public int? C_Messages_isValidate
        {
            set { _c_messages_isvalidate = value; }
            get { return _c_messages_isvalidate; }
        }
        #endregion Model

    }
}
