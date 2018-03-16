using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Reporting
{
    /// <summary>
    /// ProcessReporting
    /// </summary>
    public partial class ProcessReporting
    {
        private readonly DAL.Reporting.ProcessReporting dal = new DAL.Reporting.ProcessReporting();
        private readonly BLL.MonitorManager.M_Entry_Statistics MentryStatisticsBll = new BLL.MonitorManager.M_Entry_Statistics();
        public ProcessReporting()
        { }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.ProcessReporting> DataTableToList(DataTable dt)
        {
            List<Model.Reporting.ProcessReporting> modelList = new List<Model.Reporting.ProcessReporting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Reporting.ProcessReporting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

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
            return dal.GetProcessReportingCount(model,startIndex,endIndex,type);
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
            return DataTableToList(dal.GetProcessReporting(model, startIndex, endIndex, type).Tables[0]);
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
            return MentryStatisticsBll.DataTableToList(dal.GetProcessDetails(model, startIndex, endIndex).Tables[0]);
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
            return dal.GetProcessDetailsCount(model,startIndex,endIndex);
        }
    }
}
