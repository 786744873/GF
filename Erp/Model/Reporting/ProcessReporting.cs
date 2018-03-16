using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    /// <summary>
    /// 进程报表虚拟实体
    /// </summary>
    [Serializable]
    public partial class ProcessReporting
    {
        public string 区域 { get; set; }

        public string 律师 { get; set; }

        public string 监控项 { get; set; }

        public string 应完成数 { get; set; }

        public string 实际完成数 { get; set; }

        public string 完成率 { get; set; }

        public string 超期数 { get; set; }

        public string 超期率 { get; set; }

        public string 延期数 { get; set; }

        public string 延期率 { get; set; }

        public string 平均延期时长 { get; set; }

        public string 平均超期时长 { get; set; }

        public string 超期预期收益 { get; set; }

        public string 超期移交标的 { get; set; }

        public string 延期预期收益 { get; set; }

        public string 延期移交标的 { get; set; }

        public string 实际预期收益 { get; set; }

        public string 实际移交标的 { get; set; }

        public string 营销部门 { get; set; }
        /// <summary>
        /// 地区查询条件GUID
        /// </summary>
        public string Query_area { get; set; }

        /// <summary>
        /// 监控查询条件GUID
        /// </summary>
        public string Query_entry { get; set; }

        /// <summary>
        /// 律师查询条件GUID
        /// </summary>
        public string Query_laywerCode { get; set; }

        /// <summary>
        /// 部门查询条件
        /// </summary>
        public string Query_organ { get; set; }

        /// <summary>
        /// 律师查询条件
        /// </summary>
        public string Query_laywer { get; set; }

        /// <summary>
        /// 案件编码查询条件
        /// </summary>
        public string Query_caseNum { get; set; }

        /// <summary>
        /// 工程查询条件
        /// </summary>
        public string Query_project { get; set; }

        /// <summary>
        /// 管辖法院查询条件
        /// </summary>
        public string Query_court { get; set; }

        /// <summary>
        /// 委托人查询条件
        /// </summary>
        public string Query_deleger { get; set; }

        /// <summary>
        /// 对方当事人查询条件
        /// </summary>
        public string Query_party { get; set; }

        /// <summary>
        /// 移交标的
        /// </summary>
        public string Query_subject { get; set; }

        /// <summary>
        /// 移交标的至
        /// </summary>
        public string Query_subjectZ { get; set; }


        /// <summary>
        /// 预期收益
        /// </summary>
        public string Query_income { get; set; }


        /// <summary>
        /// 预期收益至
        /// </summary>
        public string Query_incomeZ { get; set; }

        /// <summary>
        /// 收案时间
        /// </summary>
        public string Query_closedDate { get; set; }

        /// <summary>
        /// 收案时间至
        /// </summary>
        public string Query_closedDateZ { get; set; }

        /// <summary>
        /// 自定义时间
        /// </summary>
        public string Query_customDate { get; set; }


        /// <summary>
        /// 自定义时间至
        /// </summary>
        public string Query_customDateZ { get; set; }

        /// <summary>
        /// 营销部门
        /// </summary>
        public string Query_department { get; set; }
    }
}
