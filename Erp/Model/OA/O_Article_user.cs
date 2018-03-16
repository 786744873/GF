using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{

    /// <summary>
    /// O_Article_user:实体类(属性说明自动提取数据库字段的描述信息)文章用户中间表
    /// cyj
    /// 2015年7月24日15:37:47
    /// </summary>
    [Serializable]
    public partial class O_Article_user
    {
        public O_Article_user()
        { }
        #region Model
        private int _o_article_user_id;
        private Guid? _o_article_code;
        private Guid? _c_userinfo_code;
        private bool _o_article_user_isread;
        private DateTime? _o_article_user_readtime;
        private Guid? _o_article_user_creator;
        private DateTime? _o_article_user_createtime;
        private int? _o_article_user_isdelete;
        private string _c_userinfo_name;//虚拟字段
        /// <summary>
        /// ID，自增
        /// </summary>
        public int O_Article_user_id
        {
            set { _o_article_user_id = value; }
            get { return _o_article_user_id; }
        }
        /// <summary>
        /// 虚拟字段  文章接收人名称
        /// </summary>
        public string C_Userinfo_name
        {
            set { _c_userinfo_name = value; }
            get { return _c_userinfo_name; }
        }
        /// <summary>
        /// 文章GUID
        /// </summary>
        public Guid? O_Article_code
        {
            set { _o_article_code = value; }
            get { return _o_article_code; }
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
        public bool O_Article_user_isRead
        {
            set { _o_article_user_isread = value; }
            get { return _o_article_user_isread; }
        }
        /// <summary>
        /// 读取日期
        /// </summary>
        public DateTime? O_Article_user_readTime
        {
            set { _o_article_user_readtime = value; }
            get { return _o_article_user_readtime; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? O_Article_user_creator
        {
            set { _o_article_user_creator = value; }
            get { return _o_article_user_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_Article_user_createTime
        {
            set { _o_article_user_createtime = value; }
            get { return _o_article_user_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? O_Article_user_isDelete
        {
            set { _o_article_user_isdelete = value; }
            get { return _o_article_user_isdelete; }
        }
        #endregion Model

    }

}
