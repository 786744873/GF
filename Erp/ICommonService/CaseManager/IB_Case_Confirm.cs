using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    /// <summary>
    /// 案件结案确认契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_Case_Confirm
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_Case_Confirm model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_Case_Confirm model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid B_Case_Confirm_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case_Confirm GetModel(Guid B_Case_Confirm_code);

        /// <summary>
        /// 当前用户是否有“确认结案”按钮权限
        /// </summary>
        /// <param name="B_Case_code">案件Guid</param>
        /// <param name="personCode">当前用户Guid</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case_Confirm GetModelByCaseAndPerson(Guid B_Case_code,Guid personCode);

        /// <summary>
        /// 根据案件Guid和业务流程Guid获取数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case_Confirm> GetListByCaseAndBusinessFlow(Guid caseCode, Guid businessFlowCode);

        /// <summary>
        /// 根据案件Guid获取数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case_Confirm> GetListByCaseCode(Guid caseCode);
    }
}
