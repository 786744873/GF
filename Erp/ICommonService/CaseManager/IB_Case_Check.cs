using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    /// <summary>
    /// 案件结案审核契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_Case_Check
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_Case_Check model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_Case_Check model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid B_Case_Check_code);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case_Check GetModel(Guid B_Case_Check_code);

        /// <summary>
        /// 根据案件结案确认Guid获得数据
        /// </summary>
        /// <param name="caseCode">结案确认Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case_Check> GetListByConfirmCode(Guid B_Case_Confirm_code);
    }
}
