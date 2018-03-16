using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Customer
{
    /// <summary>
    /// 用户(虚拟实体)
    /// </summary>
    public class V_User
    {
        /// <summary>
        /// 用户Guid
        /// </summary>
        public Guid? UserCode { get; set; }
        /// <summary>
        /// 业务流程表单关联Guid
        /// </summary>
        public Guid? BusinessFlowFormCode { get; set; }
    }
}
