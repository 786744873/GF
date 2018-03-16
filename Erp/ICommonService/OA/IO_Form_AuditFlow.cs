using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.OA
{

    /// <summary>
    /// 表单审批流程契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Form_AuditFlow
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.OA.O_Form_AuditFlow model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.OA.O_Form_AuditFlow model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid O_Form_AuditFlow_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="O_Form_AuditFlow_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.OA.O_Form_AuditFlow Get(Guid O_Form_AuditFlow_code);
        /// <summary>
        /// 得到一个顺序最大的对象实体
        /// </summary>
        [OperationContract]
        int GetMaxOrderModel(Guid O_Form_AuditFlow_code);

        /// <summary>
        /// 非自由流程驳回审核
        /// </summary>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="formAuditFlowCode">表单审批流程Guid</param>
        /// <param name="userCode">子用户Guid</param>
        /// <param name="auditContent">审批内容</param>
        /// <returns></returns>
        [OperationContract]
        bool NotFreeFlowRejectCheck(Guid oFormCode, Guid formAuditFlowCode, Guid userCode, string auditContent);

        /// <summary>
        /// 非自由流程通过审核
        /// </summary>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="formAuditFlowCode">表单审批流程Guid</param>
        /// <param name="userCode">子用户Guid</param>
        /// <param name="auditContent">审批内容</param>
        /// <param name="notShowFormAuditFlowCodes">不满足规则的表单审批流程Guid串</param>
        /// <returns></returns>
        [OperationContract]
        int NotFreeFlowPassCheck(Guid oFormCode, Guid formAuditFlowCode, Guid userCode, string auditContent, string notShowFormAuditFlowCodes);

        /// <summary>
        /// 通过表单Guid，获取表单审批流程集合
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.OA.O_Form_AuditFlow> GetFormAuditFlowsByFormCode(Guid formCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.OA.O_Form_AuditFlow model);
        /// <summary>
        /// 通过表单guid获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Form_AuditFlow> GetListByFormCode(Guid formCode);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Form_AuditFlow> GetListByPage(CommonService.Model.OA.O_Form_AuditFlow model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 通过审核人guid获得未读取的消息的数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Form_AuditFlow> GetListStatusByuserCode(Guid userCode);
        /// <summary>
        /// 通过流程预设guid获得数据信息
        /// </summary>
        [OperationContract]
        CommonService.Model.OA.O_Form_AuditFlow GetModelByAuditFlowcode(Guid flowCode, int type);
        /// <summary>
        /// 通过流程预设guid和表单guid和流程顺序获得数据列表获得数据信息
        /// </summary>
        [OperationContract]

        List<CommonService.Model.OA.O_Form_AuditFlow> GetModelByAuditFlowcodeAndformCodeAndOrder(int type, Guid formCode, int order);
        /// <summary>
        /// 通过审核人guid获得未审核的数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Form_AuditFlow> GetListByuserCode(Guid userCode);
    }
}
