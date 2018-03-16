using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.FlowManager
{
    /// <summary>
    /// 业务流程申请记录服务接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IP_Business_flow_applyRecord
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.FlowManager.P_Business_flow_applyRecord model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.FlowManager.P_Business_flow_applyRecord model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid businessFlowApplyRecordCode);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.FlowManager.P_Business_flow_applyRecord Get(Guid businessFlowApplyRecordCode);

        /// <summary>
        /// 根据业务Guid(商机Guid)，获取业务流程申请记录集合
        /// </summary>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> GetListByKpCode(Guid pkCode);

    }
}
