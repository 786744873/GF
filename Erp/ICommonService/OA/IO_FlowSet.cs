using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.OA
{
    /// <summary>
    /// 流程预设契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_FlowSet
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.OA.O_FlowSet model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.OA.O_FlowSet model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid O_FlowSet_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="O_FlowSet_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.OA.O_FlowSet Get(Guid O_FlowSet_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.OA.O_FlowSet model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_FlowSet> GetListByPage(CommonService.Model.OA.O_FlowSet model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 修改或者添加流程预设和预审审批人信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool UpdateFlowSetAndAuditPerson(CommonService.Model.OA.O_FlowSet model, string userlists, int type);
    }
}
