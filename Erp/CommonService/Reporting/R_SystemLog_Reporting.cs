using ICommonService.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Reporting
{
    public class R_SystemLog_Reporting : IR_SystemLog_Reporting
    {
        private readonly BLL.Reporting.R_SystemLog_Reporting bll = new BLL.Reporting.R_SystemLog_Reporting();

        /// <summary>
        /// 根据人员统计列表数量
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="organization"></param>
        /// <param name="userName"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public int GetReportByUserCount(DateTime dateFrom, DateTime dateTo, string organization, string userName, string area)
        {
            return bll.GetReportByUserCount(dateFrom, dateTo, organization, userName, area);
        }

        /// <summary>
        /// 根据人员统计系统使用情况
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="organization"></param>
        /// <param name="userName"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public List<Model.Reporting.R_SystemLog_Reporting> GetReportByUser(DateTime dateFrom, DateTime dateTo, string organization, string userName, string area, int startIndex, int endIndex)
        {
            return bll.GetReportByUser(dateFrom, dateTo, organization, userName, area, startIndex, endIndex);
        }
    }
}
