using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.Reporting
{
    /// <summary>
    /// 接口层IR_SystemLog_Reporting
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IR_SystemLog_Reporting
    {
        /// <summary>
        /// 根据人员统计列表数量
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="organization"></param>
        /// <param name="userName"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        [OperationContract]
        int GetReportByUserCount(DateTime dateFrom, DateTime dateTo, string organization, string userName, string area);

        /// <summary>
        /// 根据人员统计系统使用情况
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="organization"></param>
        /// <param name="userName"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.Reporting.R_SystemLog_Reporting> GetReportByUser(DateTime dateFrom, DateTime dateTo, string organization, string userName, string area, int startIndex, int endIndex);
    }
}
