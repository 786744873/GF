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
    public interface IK_Resources_zambia
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.KMS.K_Resources_zambia model);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(Guid K_Resources_code, Guid C_Userinfo_code);
        /// <summary>
        /// 根据条件得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.KMS.K_Resources_zambia GetModelByModel(CommonService.Model.KMS.K_Resources_zambia model);

    }
}
