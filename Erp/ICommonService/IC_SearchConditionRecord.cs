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
    public interface IC_SearchConditionRecord
    { 
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool OperateList(List<CommonService.Model.C_SearchConditionRecord> C_SearchConditionRecord);
        /// <summary>
        /// 根据所属分组得到列表
        /// </summary>
        /// <param name="C_SearchConditionRecord_group">所属分组Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.C_SearchConditionRecord> GetListByGroup(Guid C_SearchConditionRecord_group);
    }
}
