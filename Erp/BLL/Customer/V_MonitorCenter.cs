using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Customer
{
    /// <summary>
    /// 虚拟监控中心表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/06/29
    /// </summary>
    public class V_MonitorCenter
    {
        private readonly CommonService.DAL.Customer.V_MonitorCenter dal = new CommonService.DAL.Customer.V_MonitorCenter();
        
        /// <summary>
        /// 获取监控中心流程集合(执行存储过程)
        /// </summary>
        /// <param name="flowType">流程类型</param>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_MonitorCenter> GetMonitorCenterFlows(int flowType, CommonService.Model.CaseManager.B_Case casemodel)
        {
            string CacheKey = "V_MonitorCenterList-" + flowType;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DataTableToList(dal.GetMonitorCenterFlows(flowType, casemodel).Tables[0]);
                    if (objModel != null)
                    {
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (List<CommonService.Model.Customer.V_MonitorCenter>)objModel;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.Customer.V_MonitorCenter> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.Customer.V_MonitorCenter> modelList = new List<CommonService.Model.Customer.V_MonitorCenter>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.Customer.V_MonitorCenter model;
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
    }
}
