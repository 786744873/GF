using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Customer
{
    /// <summary>
    /// 律师条件(虚拟实体)
    /// </summary>
    public class V_LawyerCondition
    {
        /// <summary>
        /// 律师Guid(当前操作人Guid)
        /// </summary>
        public Guid? LawyerCode { get; set; }
        /// <summary>
        /// 律师类型(0代表默认；1代表主办律师；2代表协办律师)
        /// </summary>
        public int? LawyerType { get; set; }
        /// <summary>
        /// 操作状态
        /// </summary>
        public int? OperateStatus { get; set; }
    }
}
