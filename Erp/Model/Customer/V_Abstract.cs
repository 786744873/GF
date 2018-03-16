using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Customer
{
    /// <summary>
    /// 财务单据生成摘要虚拟类
    /// </summary>
    public class V_Abstract
    {
        private string  number;
        /// <summary>
        /// 案号
        /// </summary>
        public string  Number
        {
            get { return number; }
            set { number = value; }
        }
        private string invoiceType;
        /// <summary>
        /// 发票种类
        /// </summary>
        public string InvoiceType
        {
            get { return invoiceType; }
            set { invoiceType = value; }
        }
        private decimal? invoiceValue;
        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal? InvoiceValue
        {
            get { return invoiceValue; }
            set { invoiceValue = value; }
        }
        
    }
}
