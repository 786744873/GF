using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.Customer
{
    /// <summary>
    /// 虚拟稽查契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IV_CheckAuthority
    {
        /// <summary>
        /// 根据业务Guid，获取简要稽查信息
        /// </summary>
        /// <param name="pkCode">业务Guid,比如案件Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.Customer.V_CheckAuthority> GetBriefCheckAuthorityByPkCode(Guid pkCode);
    }
}
