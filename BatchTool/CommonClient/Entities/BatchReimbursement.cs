using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClient.Entities
{
    public class BatchReimbursement
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorReason { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 消费金额
        /// </summary>
        public string PayAmount { get; set; }

        /// <summary>
        /// 消费日期
        /// </summary>
        public string PayDateTime { get; set; }

        /// <summary>
        /// 支付令
        /// </summary>
        public string PayPassword { get; set; }

        /// <summary>
        /// 报销金额
        /// </summary>
        public string ReimburseAmount { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public string Usage { get; set; }
    }
}
