using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.KMS
{
    /// <summary>
    /// K_Token:获取视频Token表(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class K_Token
    {
        public K_Token()
        { }
        #region Model
        private int _k_token_id;
        private string _k_token_access_token;
        private int? _k_token_expires_in;
        private string _k_token_refresh_token;
        private DateTime? _k_token_zambia_createtime;
        private bool _k_token_zambia_isdelete;
        /// <summary>
        /// 自增长id
        /// </summary>
        public int K_Token_id
        {
            set { _k_token_id = value; }
            get { return _k_token_id; }
        }
        /// <summary>
        /// 新的access_token
        /// </summary>
        public string K_Token_Access_Token
        {
            set { _k_token_access_token = value; }
            get { return _k_token_access_token; }
        }
        /// <summary>
        /// Token时长（秒）
        /// </summary>
        public int? K_Token_expires_in
        {
            set { _k_token_expires_in = value; }
            get { return _k_token_expires_in; }
        }
        /// <summary>
        /// 刷新token用于获取新的access_token
        /// </summary>
        public string K_Token_refresh_token
        {
            set { _k_token_refresh_token = value; }
            get { return _k_token_refresh_token; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? K_Token_zambia_createTime
        {
            set { _k_token_zambia_createtime = value; }
            get { return _k_token_zambia_createtime; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool K_Token_zambia_isDelete
        {
            set { _k_token_zambia_isdelete = value; }
            get { return _k_token_zambia_isdelete; }
        }
        #endregion Model
    }
}
