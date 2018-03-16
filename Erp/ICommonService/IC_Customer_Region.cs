using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    /// <summary>
    /// 客户区域关系契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Customer_Region
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Customer_Region model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_Customer_Region_customer"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteByCustomerCode(Guid C_Customer_Region_customer);

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        [OperationContract]
        bool OperateList(List<CommonService.Model.C_Customer_Region> B_Customer_Regions);
    }
}
