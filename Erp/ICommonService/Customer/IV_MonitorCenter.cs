using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.Customer
{
    /// <summary>
    /// 虚拟监控中心契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IV_MonitorCenter
    {
        /// <summary>
        /// 获取监控中心流程集合(执行存储过程)
        /// </summary>
        /// <param name="flowType">流程类型</param>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.Customer.V_MonitorCenter> GetMonitorCenterFlows(int flowType, CommonService.Model.CaseManager.B_Case casemodel);
    }
}
