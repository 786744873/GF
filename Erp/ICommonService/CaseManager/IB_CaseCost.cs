using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    /// <summary>
    /// 成本信息契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_CaseCost
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
        bool Exists(int B_CaseCost_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_CaseCost model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_CaseCost model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int B_CaseCost_id);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_CaseCost GetModel(Guid B_Case_code, int B_CaseCost_type);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CaseManager.B_CaseCost model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_CaseCost> GetListByPage(CommonService.Model.CaseManager.B_CaseCost model, string orderby, int startIndex, int endIndex);
    }
}
