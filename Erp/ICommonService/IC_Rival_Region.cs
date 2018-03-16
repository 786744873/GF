using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Rival_Region”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Rival_Region
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.C_Rival_Region model);

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        [OperationContract]
        bool OperateList(List<CommonService.Model.C_Rival_Region> B_Rival_Regions);
    }
}
