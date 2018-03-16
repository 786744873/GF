using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    /// <summary>
    /// 登录日志统计表（虚拟实体）
    /// </summary>
    [Serializable]
    public partial class R_SystemLog_Reporting
    {
        public R_SystemLog_Reporting()
        { }
        #region Model
        private string _area;
        private string _organization;
        private string _userinfo;
        private int _totaltimes;
        private int _totaldays;
        private int _apptotaltimes;
        private int _apptotaldays;
        private int _pctotaltimes;
        private int _pctotaldays;
        private int _kmstotaltimes;
        private int _kmstotaldays;
        /// <summary>
        /// 区域
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string Organization
        {
            set { _organization = value; }
            get { return _organization; }
        }
        /// <summary>
        /// 人员
        /// </summary>
        public string Userinfo
        {
            set { _userinfo = value; }
            get { return _userinfo; }
        }
        /// <summary>
        /// 总访问次数
        /// </summary>
        public int TotalTimes
        {
            set { _totaltimes = value; }
            get { return _totaltimes; }
        }
        /// <summary>
        /// 总访问天数
        /// </summary>
        public int TotalDays
        {
            set { _totaldays = value; }
            get { return _totaldays; }
        }
        /// <summary>
        /// app访问次数
        /// </summary>
        public int AppTotalTimes
        {
            set { _apptotaltimes = value; }
            get { return _apptotaltimes; }
        }
        /// <summary>
        /// app访问天数
        /// </summary>
        public int AppTotalDays
        {
            set { _apptotaldays = value; }
            get { return _apptotaldays; }
        }
        /// <summary>
        /// pc访问次数
        /// </summary>
        public int PCTotalTimes
        {
            set { _pctotaltimes = value; }
            get { return _pctotaltimes; }
        }
        /// <summary>
        /// pc访问天数
        /// </summary>
        public int PCTotalDays
        {
            set { _pctotaldays = value; }
            get { return _pctotaldays; }
        }
        /// <summary>
        /// kms访问次数
        /// </summary>
        public int KmsTotalTimes
        {
            set { _kmstotaltimes = value; }
            get { return _kmstotaltimes; }
        }
        /// <summary>
        /// kms访问天数
        /// </summary>
        public int KmsTotalDays
        {
            set { _kmstotaldays = value; }
            get { return _kmstotaldays; }
        }
        #endregion Model
    }
}
