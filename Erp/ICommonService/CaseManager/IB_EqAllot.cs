using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    /// <summary>
    /// 案件--涉案合同权益分配契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_EqAllot
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
        bool Exists(int B_EqAllot_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_EqAllot model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_EqAllot model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int B_EqAllot_id);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.CaseManager.B_EqAllot GetModel(Guid B_Case_code, int B_EqAllot_pright);

         /// <summary>
		/// 获得数据列表
		/// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_EqAllot> GetAllList(Guid B_Case_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CaseManager.B_EqAllot model,int type);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_EqAllot> GetListByPage(CommonService.Model.CaseManager.B_EqAllot model, string orderby, int startIndex, int endIndex, int type);
    }
}
