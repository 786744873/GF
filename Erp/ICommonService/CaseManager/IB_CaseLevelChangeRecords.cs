using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    /// <summary>
    /// 案件级别变更记录契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_CaseLevelChangeRecords
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_CaseLevelChangeRecords model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_CaseLevelChangeRecords model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_CaseLevelChangeRecords_code"></param>
        /// <returns></returns>
        [OperationContract]
        bool Delete(Guid B_CaseLevelChangeRecords_code);
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="B_CaseLevelChangeRecords_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_CaseLevelChangeRecords GetModel(Guid B_CaseLevelChangeRecords_code); 
        /// <summary>
        /// 根据案件Guid获得记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_CaseLevelChangeRecords GetModelByCaseCode(Guid caseCode);
        /// <summary>
        /// 根据案件Guid获得未审核的记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_CaseLevelChangeRecords GetModelByCaseCodeIsNotAudit(Guid caseCode);
        /// <summary>
        /// 获得数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CaseManager.B_CaseLevelChangeRecords model);
        /// <summary>
        /// 分页获得数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_CaseLevelChangeRecords> GetListByPage(CommonService.Model.CaseManager.B_CaseLevelChangeRecords model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据案件Guid获得数据
        /// </summary>
        /// <param name="CaseCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_CaseLevelChangeRecords> GetListByCaseCode(Guid CaseCode);
    }
}
