using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    /// <summary>
    /// 案件级别变更契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_CaseLevelchange
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_CaseLevelchange model);
        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="CaseLevelchangeList"></param>
        /// <returns></returns>
        [OperationContract]
        int OpreateList(List<CommonService.Model.CaseManager.B_CaseLevelchange> CaseLevelchangeList);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_CaseLevelchange model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="B_CaseLevelchange_code"></param>
        /// <returns></returns>
        [OperationContract]
        bool Delete(Guid B_CaseLevelchange_code);
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="B_CaseLevelchange_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_CaseLevelchange GetModel(Guid B_CaseLevelchange_code);
        /// <summary>
        /// 根据变更记录Guid获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_CaseLevelchange> GetListByChangeRecord(Guid B_CaseLevelchange_changeRecord);
        /// <summary>
        /// 根据案件Guid获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_CaseLevelchange> GetListByCaseCode(Guid B_Case_code, int type);
        /// <summary>
        /// 获得数据总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CaseManager.B_CaseLevelchange model);
        /// <summary>
        /// 分页获得数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_CaseLevelchange> GetListByPage(CommonService.Model.CaseManager.B_CaseLevelchange model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 根据案件Guid查询是否有未审核的变更数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool IsNotAudited(Guid caseCode);

        /// <summary>
        /// 根据案件Guid查询是否有变更记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool IsChange(Guid caseCode);
         /// <summary>
        /// 根据案件Guid查询是否有调整记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="B_CaseLevelchange_type">案件级别变更类型</param>
        /// <returns></returns>
        [OperationContract]
        bool IsHardToAdjust(Guid caseCode, int B_CaseLevelchange_type);
    }
}
