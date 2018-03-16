﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Reporting
{
    public class R_CaseType_Reporting
    {
        public string 年份 { get; set; }

        public string 月份 { get; set; }

        public string 地区 { get; set; }

        public string 案件类型 { get; set; }

        public string 收案总数 { get; set; }

        public string 类型收案数 { get; set; }

        public string 非类型收案数 { get; set; }

        public string 移交总标的 { get; set; }

        public string 类型移交标的 { get; set; }

        public string 非类型移交标的 { get; set; }

        public string 预期总收益 { get; set; }

        public string 类型预期收益 { get; set; }

        public string 非类型预期收益 { get; set; }

        /// <summary>
        /// 区域查询条件
        /// </summary>
        public Guid? QueryArea { get; set; }

        /// <summary>
        /// 开始收案时间查询条件
        /// </summary>
        public DateTime? QueryStartTime { get; set; }

        /// <summary>
        /// 结束收案时间查询条件
        /// </summary>
        public DateTime? QueryEndTime { get; set; }

        /// <summary>
        /// 案件类型查询条件
        /// </summary>
        public int? QueryCaseType { get; set; }

        /// <summary>
        /// 案件性质查询条件
        /// </summary>
        public int? QueryNature { get; set; }

        /// <summary>
        /// 开始移交标的查询条件
        /// </summary>
        public decimal? QueryStartTransferTargetMoney { get; set; }

        /// <summary>
        /// 结束移交标的查询条件
        /// </summary>
        public decimal? QueryEndTransferTargetMoney { get; set; }

        /// <summary>
        /// 开始预期收益查询条件
        /// </summary>
        public decimal? QueryStartExpectedGrant { get; set; }

        /// <summary>
        /// 结束预期收益查询条件
        /// </summary>
        public decimal? QueryEndExpectedGrant { get; set; }

    }
}
