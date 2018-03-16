using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Involved_project_CU”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Involved_project_CU
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        [OperationContract]
        int GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int C_Involved_project_CU_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Involved_project_CU model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Involved_project_CU model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_Involved_project_CU_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Involved_project_CU GetModel(int C_Involved_project_CU_id);
        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_Involved_project_CU model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Involved_project_CU> GetListByPage(CommonService.Model.C_Involved_project_CU model, string orderby, int startIndex, int endIndex);
    }
}
