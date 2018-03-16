using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.Reporting
{
    /// <summary>
    /// 接口层IProcessReporting
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IProcessReporting
    {
        /// <summary>
        /// 获取统计报表总数
        /// </summary>
        /// <param name="model">查询条件实体</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <param name="type">类型：1 根据区域统计  2 根据区域、律师统计</param>
        /// <returns>数量</returns>
        [OperationContract]
        int GetProcessReportingCount(CommonService.Model.Reporting.ProcessReporting model, int startIndex, int endIndex, int type);
        /// <summary>
        /// 获取统计报表
        /// </summary>
        /// <param name="model">查询条件实体</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <param name="type">类型：1 根据区域统计  2 根据区域、律师统计</param>
        /// <returns>数据集</returns>
        [OperationContract]
        List<CommonService.Model.Reporting.ProcessReporting> GetProcessReporting(CommonService.Model.Reporting.ProcessReporting model, int startIndex, int endIndex, int type);
        /// <summary>
        /// 查询详细统计信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.MonitorManager.M_Entry_Statistics> GetProcessDetails(CommonService.Model.Reporting.ProcessReporting model, int startIndex, int endIndex);
        /// <summary>
        /// 查询详细统计信息总数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        int GetProcessDetailsCount(CommonService.Model.Reporting.ProcessReporting model, int startIndex, int endIndex);
    }
}
