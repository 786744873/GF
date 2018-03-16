using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.KMS
{
    /// <summary>
    /// K_Kms_Log:实体类(属性说明自动提取数据库字段的描述信息)
    /// 陈盼盼
    /// </summary>
    [Serializable]
    public partial class K_Kms_Log
    {
        public K_Kms_Log()
        { }
        #region Model
        private int _k_kms_log_id;
        private Guid? _k_kms_log_usercode;
        private DateTime? _k_kms_log_datetime;
        private string _k_kms_log_ip;
        private string _k_kms_log_type;
        private string _k_kms_log_username;
        /// <summary>
        /// id自增
        /// </summary>
        public int K_Kms_Log_id
        {
            set { _k_kms_log_id = value; }
            get { return _k_kms_log_id; }
        }
        /// <summary>
        /// 登录用户code
        /// </summary>
        public Guid? K_Kms_Log_usercode
        {
            set { _k_kms_log_usercode = value; }
            get { return _k_kms_log_usercode; }
        }
        /// <summary>
        /// 登录日期
        /// </summary>
        public DateTime? K_Kms_Log_datetime
        {
            set { _k_kms_log_datetime = value; }
            get { return _k_kms_log_datetime; }
        }
        /// <summary>
        /// 访问者ip
        /// </summary>
        public string K_Kms_Log_ip
        {
            set { _k_kms_log_ip = value; }
            get { return _k_kms_log_ip; }
        }
        /// <summary>
        /// 系统登录 or 知识库登录
        /// </summary>
        public string K_Kms_Log_type
        {
            set { _k_kms_log_type = value; }
            get { return _k_kms_log_type; }
        }
        /// <summary>
        /// 登录用户名称（虚拟字段）
        /// </summary>
        public string K_Kms_Log_username
        {
            set { _k_kms_log_username = value; }
            get { return _k_kms_log_username; }
        }
        #endregion Model

    }
}
