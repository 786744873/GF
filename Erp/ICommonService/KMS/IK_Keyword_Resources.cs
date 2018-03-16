using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.KMS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IP_Business_flow”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IK_Keyword_Resources
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.KMS.K_Keyword_Resources model);

        /// <summary>
        /// 批量操作
        /// </summary>
        [OperationContract]
        bool OperateList(List<CommonService.Model.KMS.K_Keyword_Resources> modelList);

        /// <summary>
        /// 根据资源Guid删除资源关连关系
        /// </summary>
        /// <param name="resourcesCode"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteByResourcesCode(Guid resourcesCode);
    }
}
