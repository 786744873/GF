using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.FlowManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Parameters”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IP_Flow
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
        bool Exists(int P_Flow_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.FlowManager.P_Flow model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.FlowManager.P_Flow model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid P_Flow_code);


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.FlowManager.P_Flow GetModel(Guid P_Flow_code);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Flow> GetAllList();

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="type">流程类型</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Flow> GetListByFlowType(int type);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.FlowManager.P_Flow model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Flow> GetListByPage(CommonService.Model.FlowManager.P_Flow model, string orderby, int startIndex, int endIndex);
    }
}
