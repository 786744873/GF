using ICommonService.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Reporting
{
    public class ProcessReporting : IProcessReporting
    {
        private readonly BLL.Reporting.ProcessReporting bll = new BLL.Reporting.ProcessReporting();

        /// <summary>
        /// 获取统计报表总数
        /// </summary>
        /// <param name="model">查询条件实体</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <param name="type">类型：1 根据区域统计  2 根据区域、律师统计</param>
        /// <returns>数量</returns>
        public int GetProcessReportingCount(Model.Reporting.ProcessReporting model, int startIndex, int endIndex, int type)
        {
            return bll.GetProcessReportingCount(model,startIndex,endIndex,type);
        }
        /// <summary>
        /// 获取统计报表
        /// </summary>
        /// <param name="model">查询条件实体</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <param name="type">类型：1 根据区域统计  2 根据区域、律师统计</param>
        /// <returns>数据集</returns>
        public List<Model.Reporting.ProcessReporting> GetProcessReporting(Model.Reporting.ProcessReporting model, int startIndex, int endIndex, int type)
        {
            return bll.GetProcessReporting(model,startIndex,endIndex,type);
        }
        /// <summary>
        /// 查询详细统计信息总数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.MonitorManager.M_Entry_Statistics> GetProcessDetails(Model.Reporting.ProcessReporting model, int startIndex, int endIndex)
        {
            return bll.GetProcessDetails(model,startIndex,endIndex);
        }
        /// <summary>
        /// 查询详细统计信息总数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetProcessDetailsCount(Model.Reporting.ProcessReporting model, int startIndex, int endIndex)
        {
            return bll.GetProcessDetailsCount(model,startIndex,endIndex);
        }
    }
}
