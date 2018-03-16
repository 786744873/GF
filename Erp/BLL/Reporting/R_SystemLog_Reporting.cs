using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Reporting
{
    public partial class R_SystemLog_Reporting
    {
        private readonly DAL.Reporting.R_SystemLog_Reporting dal = new DAL.Reporting.R_SystemLog_Reporting();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Reporting.R_SystemLog_Reporting> DataTableToList(DataTable dt)
        {
            List<Model.Reporting.R_SystemLog_Reporting> modelList = new List<Model.Reporting.R_SystemLog_Reporting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Reporting.R_SystemLog_Reporting model;
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
            return dal.GetReportByUserCount(dateFrom,dateTo,organization,userName,area);
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
            return DataTableToList(dal.GetReportByUser(dateFrom, dateTo, organization, userName, area, startIndex, endIndex).Tables[0]);
        }
    }
}
