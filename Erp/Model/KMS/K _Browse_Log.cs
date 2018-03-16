using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.KMS
{
    /// <summary>
	/// K _Browse_Log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class K_Browse_Log
	{
		public K_Browse_Log()
		{}
		#region Model
		private int _k_browse_log_id;
		private Guid? _k_browse_log_usercode;
		private Guid? _p_fk_code;
		private DateTime? _k_browse_log_datetime;
        private string _k_browse_log_ip;
		/// <summary>
		/// Id自增列
		/// </summary>
		public int K_Browse_Log_id
		{
			set{ _k_browse_log_id=value;}
			get{return _k_browse_log_id;}
		}
		/// <summary>
		/// 用户code
		/// </summary>
		public Guid? K_Browse_Log_usercode
		{
			set{ _k_browse_log_usercode=value;}
			get{return _k_browse_log_usercode;}
		}
		/// <summary>
		/// 资源/问吧code
		/// </summary>
		public Guid? P_FK_code
		{
			set{ _p_fk_code=value;}
			get{return _p_fk_code;}
		}
		/// <summary>
		/// 记录生成时间
		/// </summary>
		public DateTime? K_Browse_Log_datetime
		{
			set{ _k_browse_log_datetime=value;}
			get{return _k_browse_log_datetime;}
		}
        /// <summary>
        /// 记录访问ip
        /// </summary>
        public string K_Browse_Log_ip
        {
            set { _k_browse_log_ip = value; }
            get { return _k_browse_log_ip; }
        }
		#endregion Model
    }
}
