using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// O_Email_user:实体类(属性说明自动提取数据库字段的描述信息)8.	邮件----收件人中间表
    /// cyj
    /// 2015年7月14日16:23:52
    /// </summary>
    [Serializable]
    public partial class O_Email_user
    {
        public O_Email_user()
        { }
        #region Model
        private int? _o_email_user_id;
        private Guid? _o_email_code;
        private Guid? _c_userinfo_code;
        private bool _o_email_user_isread;
        private int? _o_email_user_type;
        private Guid? _o_email_creator;
        private DateTime? _o_email_createtime;
        private bool _o_email_isdelete;
        private int? _o_email_state;//虚拟字段
        private string _o_email_title;//虚拟字段
        private string _o_email_content;//虚拟字段
        private DateTime? _o_email_createTime2;//虚拟字段
        private Guid? _o_email_sender;//虚拟字段
        private string _c_userinfo_name;//虚拟字段
        private string _c_userinfo_name2;//虚拟字段
        private string _list_name;//虚拟字段
        private int? _c_messages_id;//虚拟字段
        /// <summary>
        /// 邮件ID
        /// </summary>
        public int? O_Email_user_id
        {
            set { _o_email_user_id = value; }
            get { return _o_email_user_id; }
        }
        /// <summary>
        /// 虚拟字段  消息ID
        /// </summary>
        public int? C_Messages_id
        {
            set { _c_messages_id = value; }
            get { return _c_messages_id; }
        }
        /// <summary>
        /// 虚拟字段  草稿，已发送
        /// </summary>
        public int? O_Email_state
        {
            set { _o_email_state = value; }
            get { return _o_email_state; }
        }
        /// <summary>
        /// 虚拟字段  邮件标题
        /// </summary>
        public string O_Email_title
        {
            set { _o_email_title = value; }
            get { return _o_email_title; }
        }
        /// <summary>
        /// 虚拟字段  邮件内容
        /// </summary>
        public string O_Email_content
        {
            set { _o_email_content = value; }
            get { return _o_email_content; }
        }
        /// <summary>
        /// 虚拟字段   邮件的创建时间（不是发送的邮件）
        /// </summary>
        public DateTime? O_Email_createTime2
        {
            set { _o_email_createTime2 = value; }
            get { return _o_email_createTime2; }
        }
        /// <summary>
        /// 虚拟字段   邮件发送人 
        /// </summary>
        public Guid? O_Email_sender
        {
            set { _o_email_sender = value; }
            get { return _o_email_sender; }
        }
        /// <summary>
        /// 虚拟字段  发送人名称
        /// </summary>
        public string C_Userinfo_name
        {
            set { _c_userinfo_name = value; }
            get { return _c_userinfo_name; }
        }
        /// <summary>
        /// 虚拟字段  收件人名称
        /// </summary>
        public string C_Userinfo_name2
        {
            set { _c_userinfo_name2 = value; }
            get { return _c_userinfo_name2; }
        }
        /// <summary>
        /// 虚拟字段  收件名称集合
        /// </summary>
        public string Listname
        {
            set { _list_name = value; }
            get { return _list_name; }
        }
        /// <summary>
        /// 邮件GUID 
        /// </summary>
        public Guid? O_Email_code
        {
            set { _o_email_code = value; }
            get { return _o_email_code; }
        }
        /// <summary>
        /// 用户GUID
        /// </summary>
        public Guid? C_Userinfo_code
        {
            set { _c_userinfo_code = value; }
            get { return _c_userinfo_code; }
        }
        /// <summary>
        /// 是否已读 
        /// </summary>
        public bool O_Email_user_isRead
        {
            set { _o_email_user_isread = value; }
            get { return _o_email_user_isread; }
        }
        /// <summary>
        /// 外键，parameter表，收件人、抄送人 
        /// </summary>
        public int? O_Email_user_type
        {
            set { _o_email_user_type = value; }
            get { return _o_email_user_type; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? O_Email_creator
        {
            set { _o_email_creator = value; }
            get { return _o_email_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_Email_createTime
        {
            set { _o_email_createtime = value; }
            get { return _o_email_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool O_Email_isDelete
        {
            set { _o_email_isdelete = value; }
            get { return _o_email_isdelete; }
        }
        #endregion Model

    }
}
