using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Customer
{
    /// <summary>
    /// 表单计划(虚拟实体)
    /// </summary>
    public class V_FormPlan
    {
        /// <summary>
        /// 业务流程Guid
        /// </summary>
        public Guid? BusinessFlowCode { set;get; }
        /// <summary>
        /// 业务流程表单关联Guid
        /// </summary>
        public Guid? BusinessFlowFormCode { set;get; }
        /// <summary>
        /// 主律师Guid
        /// </summary>
        public Guid? MainLawyerCode {set;get;}
        /// <summary>
        /// 主律师名称
        /// </summary>
        public string MainLawyerName{set;get;}
        /// <summary>
        /// 协办律师Codes
        /// </summary>
        public string AssistLawyerCodes { get; set; }
        /// <summary>
        /// 协办律师名称
        /// </summary>
        public string AssistLawyerNames { get; set; }
        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? PlanStartTime { get; set; }
        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime? PlanEndTime { get; set;}
        /// <summary>
        /// 任务要求
        /// </summary>
        public string Require { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public Guid? Creator { get; set; }
        /// <summary>
        /// 多个业务流程表单关联Guid
        /// </summary>
        public string MulityBusinessFlowFormCode { get; set; }
    }
}
