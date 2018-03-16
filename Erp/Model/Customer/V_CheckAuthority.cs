using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Customer
{
    /// <summary>
    /// 稽查(虚拟实体)
    /// </summary>
    public class V_CheckAuthority
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string AuthorityName { get; set; }
        /// <summary>
        /// 稽查类型(1:一审稽查、2:二审稽查、3:执行里程碑、4:非里程碑)
        /// </summary>
        public int? AuthorityType { get; set; }
        /// <summary>
        /// 次数
        /// </summary>
        public int? AuthorityTime { get; set; }
    }
}
