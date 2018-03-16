using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.OA
{
    /// <summary>
    /// O_Article:实体类(属性说明自动提取数据库字段的描述信息)文章表
    /// cyj 
    /// 2015年7月14日16:40:42
    /// </summary>

    public partial class O_Article
    {
        public O_Article()
        { }
        #region Model
        public int o_article_id;
        public Guid? o_article_code;
        public string o_article_title;
        public string o_article_content;
        public Guid? o_article_publisher;
        public string o_article_publisher_name;
        public DateTime? o_article_publishtime;
        public int? o_article_state;
        public string o_article_state_name;
        public Guid? o_article_creator;
        public DateTime? o_article_createtime;
        public bool o_article_isdelete;
        public Guid? c_userinfo_code;//虚拟字段
        public string c_userinfo_name;//虚拟字段
        public bool o_article_isread;//虚拟字段

        public bool O_article_isread
        {
            get { return o_article_isread; }
            set { o_article_isread = value; }
        }
        /// <summary>
        /// 文章ID
        /// </summary>
        public int O_Article_id
        {
            set { o_article_id = value; }
            get { return o_article_id; }
        }
        /// <summary>
        /// 虚拟字段（用户GUID）
        /// </summary>
        public Guid? C_Userinfo_code
        {
            set { c_userinfo_code = value; }
            get { return c_userinfo_code; }
        }
        /// <summary>
        /// 虚拟字段（用户名称）
        /// </summary>
        public string  C_Userinfo_name
        {
            set { c_userinfo_name = value; }
            get { return c_userinfo_name; }
        }
        /// <summary>
        /// 文章GUID
        /// </summary>
        public Guid? O_Article_code
        {
            set { o_article_code = value; }
            get { return o_article_code; }
        }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string O_Article_title
        {
            set { o_article_title = value; }
            get { return o_article_title; }
        }
        /// <summary>
        /// 文章内容 
        /// </summary>
        public string O_Article_content
        {
            set { o_article_content = value; }
            get { return o_article_content; }
        }
        /// <summary>
        /// 发布人
        /// </summary>
        public Guid? O_Article_publisher
        {
            set { o_article_publisher = value; }
            get { return o_article_publisher; }
        }
        /// <summary>
        /// 发布人名称(虚拟属性)
        /// </summary>
        public string O_Article_publisher_name
        {
            set { o_article_publisher_name = value; }
            get { return o_article_publisher_name; }
        }
        /// <summary>
        /// 发布日期 
        /// </summary>
        public DateTime? O_Article_publishTime
        {
            set { o_article_publishtime = value; }
            get { return o_article_publishtime; }
        }
        /// <summary>
        /// 外键，parameter表，未提交、已提交、审核通过、审核未通过 
        /// </summary>
        public int? O_Article_state
        {
            set { o_article_state = value; }
            get { return o_article_state; }
        }

        /// <summary>
        /// 文章状态名称(虚拟属性)
        /// </summary>
        public string O_Article_state_name
        {
            set { o_article_state_name = value; }
            get { return o_article_state_name; }
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? O_Article_creator
        {
            set { o_article_creator = value; }
            get { return o_article_creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? O_Article_createTime
        {
            set { o_article_createtime = value; }
            get { return o_article_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool O_Article_isDelete
        {
            set { o_article_isdelete = value; }
            get { return o_article_isdelete; }
        }
        #endregion Model

    }
}
