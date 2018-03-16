using ICommonService.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Customer
{
    /// <summary>
    /// 虚拟监控中心服务
    /// </summary>
    public class V_MonitorCenter : IV_MonitorCenter
    {
        CommonService.BLL.Customer.V_MonitorCenter bll = new CommonService.BLL.Customer.V_MonitorCenter();
        /// <summary>
        /// 获取监控中心流程集合(执行存储过程)
        /// </summary>
        /// <param name="flowType">流程类型</param>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        public List<Model.Customer.V_MonitorCenter> GetMonitorCenterFlows(int flowType, CommonService.Model.CaseManager.B_Case casemodel)
        {
            return bll.GetMonitorCenterFlows(flowType, casemodel);
        }
    }
}
