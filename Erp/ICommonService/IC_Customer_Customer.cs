using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    /// <summary>
    /// 客户委托人关系契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Customer_Customer
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Customer_Customer model);
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="relationCode">客户Guid</param>
        /// <param name="clientCode">关联委托人Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool Delete(Guid relationCode, Guid clientCode);
    }
}
