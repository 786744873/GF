using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// O_Email:实体类(属性说明自动提取数据库字段的描述信息)邮件表
    /// cyj
    /// 2015年7月14日16:15:12
    /// </summary>
    [Serializable]
    public partial class O_Email
    {
        public O_Email()
        { }
        #region Model
        private int _o_email_id;
        private Guid? _o_email_code;
        private string _o_email_title;
        private string _o_email_content;
        private Guid? _o_email_sender;
        private DateTime? _o_email_sendtime;
        private int? _o_email_state;
        private Guid? _o_email_creator;
        private DateTime? _o_email_createtime;
        private bool _o_email_isdelete;
        private Guid? _c_userinfo_code;//虚拟字段  收件人  
        private Guid? _c_userinfo_code2;//虚拟字段 抄送人
        private string _o_email_userList;//虚拟字段
        private string _o_email_userListname;//虚拟字段
        private string _o_email_sendername;//虚拟字段
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int O_Email_id
        {
            set { _o_email_id = value; }
            get { return _o_email_id; }
        }
        /// <summary>
        /// GUID 
        /// </summary>
        public Guid? O_Email_code
        {
            set { _o_email_code = value; }
            get { return _o_email_code; }
        }
        /// <summary>
        /// 虚拟字段（收件人 ）GUID 
        /// </summary>
        public Guid? C_Userinfo_code
        {
            set { _c_userinfo_code = value; }
            get { return _c_userinfo_code; }
        }
        /// <summary>
        /// 虚拟字段（抄送人）GUID 
        /// </summary>
        public Guid? C_Userinfo_code2
        {
            set { _c_userinfo_code2 = value; }
            get { return _c_userinfo_code2; }
        }
        /// <summary>
        /// 虚拟字段   收件人集合
        /// </summary>
        public string O_Email_userList
        {
            set { _o_email_userList = value; }
            get { return _o_email_userList; }
        }
        /// <summary>
        /// 虚拟字段   收件人名字集合
        /// </summary>
        public string O_Email_userListname
        {
            set { _o_email_userListname = value; }
            get { return _o_email_userListname; }
        }
        /// <summary>
        /// 组名
        /// </summary>
        public string O_Email_title
        {
            set { _o_email_title = value; }
            get { return _o_email_title; }
        }
        /// <summary>
        /// 邮件内容 
        /// </summary>
        public string O_Email_content
        {
            set { _o_email_content = value; }
            get { return _o_email_content; }
        }
        /// <summary>
        /// 发送人 
        /// </summary>
        public Guid? O_Email_sender
        {
            set { _o_email_sender = value; }
            get { return _o_email_sender; }
        }
        /// <summary>
        /// 虚拟字段   发送人名称
        /// </summary>
        public string O_Email_sendername
        {
            set { _o_email_sendername = value; }
            get { return _o_email_sendername; }
        }
        /// <summary>
        /// 发送日期 
        /// </summary>
        public DateTime? O_Email_sendTime
        {
            set { _o_email_sendtime = value; }
            get { return _o_email_sendtime; }
        }
        /// <summary>
        /// 外键，parameter表，草稿、已发送 
        /// </summary>
        public int? O_Email_state
        {
            set { _o_email_state = value; }
            get { return _o_email_state; }
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
