using ICommonService.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Customer
{
    /// <summary>
    /// 虚拟稽查服务
    /// </summary>
    public class V_CheckAuthority : IV_CheckAuthority
    {
        CommonService.BLL.Customer.V_CheckAuthority oBLL = new CommonService.BLL.Customer.V_CheckAuthority();

        /// <summary>
        /// 根据业务Guid，获取简要稽查信息
        /// </summary>
        /// <param name="pkCode">业务Guid,比如案件Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.Customer.V_CheckAuthority> GetBriefCheckAuthorityByPkCode(Guid pkCode)
        {
            return oBLL.GetBriefCheckAuthorityByPkCode(pkCode);
        }
    }
}
