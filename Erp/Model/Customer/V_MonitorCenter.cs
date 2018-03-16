using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Customer
{
    /// <summary>
    /// 案件_监控中心(虚拟实体)
    /// </summary>
    public class V_MonitorCenter
    {
        /// <summary>
        /// 流程GUID
        /// </summary>
        public Guid? FlowCode { get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        public string FlowName { get; set; }
        /// <summary>
        /// 案件数量
        /// </summary>
        public int? CaseNumber { get; set; }
        
    }
}
