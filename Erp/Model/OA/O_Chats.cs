using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// O_Chats:实体类(属性说明自动提取数据库字段的描述信息)4.	聊天表
    /// cyj
    /// 2015年7月14日15:48:42
    /// </summary>
    [Serializable]
    public partial class O_Chats
    {
        public O_Chats()
        { }
        #region Model
        private int _o_chats_id;
        private Guid _o_chats_code;
        private string _o_chats_content;
        private Guid _o_chats_from;
        private Guid _o_chats_to;
        private bool _o_chats_isbulk;
        private DateTime? _o_chats_date;
        private bool _o_chats_isread;
        private Guid _o_chats_creator;
        private DateTime? _o_chats_createtime;
        private bool _o_chats_isdelete;
        /// <summary>
        /// ID，主键，自增
        /// </summary>
        public int O_Chats_id
        {
            set { _o_chats_id = value; }
            get { return _o_chats_id; }
        }
        /// <summary>
        /// GUID 
        /// </summary>
        public Guid O_Chats_code
        {
            set { _o_chats_code = value; }
            get { return _o_chats_code; }
        }
        /// <summary>
        /// 聊天内容
        /// </summary>
        public string O_Chats_content
        {
            set { _o_chats_content = value; }
            get { return _o_chats_content; }
        }
        /// <summary>
        /// 发送人
        /// </summary>
        public Guid O_Chats_from
        {
            set { _o_chats_from = value; }
            get { return _o_chats_from; }
        }
        /// <summary>
        /// 接收人，或者接收组，如果O_Chats_isBulk是群发，那么此处记录接收组的GUID，否则记录人员GUID
        /// </summary>
        public Guid O_Chats_to
        {
            set { _o_chats_to = value; }
            get { return _o_chats_to; }
        }
        /// <summary>
        /// 是否群发
        /// </summary>
        public bool O_Chats_isBulk
        {
            set { _o_chats_isbulk = value; }
            get { return _o_chats_isbulk; }
        }
        /// <summary>
        /// 发送日期 
        /// </summary>
        public DateTime? O_Chats_date
        {
            set { _o_chats_date = value; }
            get { return _o_chats_date; }
        }
        /// <summary>
        /// 是否已读 
        /// </summary>
        public bool O_Chats_isRead
        {
            set { _o_chats_isread = value; }
            get { return _o_chats_isread; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid O_Chats_creator
        {
            set { _o_chats_creator = value; }
            get { return _o_chats_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_Chats_createTime
        {
            set { _o_chats_createtime = value; }
            get { return _o_chats_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool O_Chats_isDelete
        {
            set { _o_chats_isdelete = value; }
            get { return _o_chats_isdelete; }
        }
        #endregion Model

    }
}
