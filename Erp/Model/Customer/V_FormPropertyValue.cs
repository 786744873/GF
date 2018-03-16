using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Customer
{
    /// <summary>
    /// 表单属性值(虚拟实体)
    /// </summary>
    public class V_FormPropertyValue
    {
        /// <summary>
        /// 表单属性值Id
        /// </summary>
        public int? FormPropertyValue_Id { get; set; }
        /// <summary>
        /// 表单属性值Guid
        /// </summary>
        public Guid? FormPropertyValue_Code { get; set; }
        /// <summary>
        /// 表单属性值
        /// </summary>
        public string FormPropertyValue_Value { get; set; }
    }
}
