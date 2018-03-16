using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.OA
{
    /// <summary>
    /// 流程预设审批人契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_FlowSet_AuditPerson
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.OA.O_FlowSet_AuditPerson model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.OA.O_FlowSet_AuditPerson model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid O_FlowSet_auditPerson_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="O_FlowSet_auditPerson_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.OA.O_FlowSet_AuditPerson Get(Guid O_FlowSet_auditPerson_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.OA.O_FlowSet_AuditPerson model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_FlowSet_AuditPerson> GetListByPage(CommonService.Model.OA.O_FlowSet_AuditPerson model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据预设流程GUID获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_FlowSet_AuditPerson> GetListByflowSetCode(Guid flowsetCode);

        /// <summary>
        /// 根据所属流程GUID获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_FlowSet_AuditPerson> GetListByflowCode(Guid flowCode);
    }
}
