using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.MonitorManager
{
    /// <summary>
    /// 条目统计契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IM_Entry_Statistics
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
        bool Exists(int M_Entry_Statistics_id);

        /// <summary>
        /// 根据案件Guid，检查是否有延期条目统计信息
        /// </summary>
        /// <param name="pkCode">案件guid</param>
        /// <returns></returns>
        [OperationContract]
        bool ExistsDelayByPkCode(Guid pkCode);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.MonitorManager.M_Entry_Statistics model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.MonitorManager.M_Entry_Statistics model);

        /// <summary>
        /// 修改办案状态(手工结束)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateHandlingState(Guid M_Entry_Statistics_code);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int M_Entry_Statistics_id);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="C_Address_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.MonitorManager.M_Entry_Statistics GetModel(Guid M_Entry_Statistics_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.MonitorManager.M_Entry_Statistics model, CommonService.Model.CaseManager.B_Case casemodel, string orderby, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode, string tj);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.MonitorManager.M_Entry_Statistics> GetListByPage(CommonService.Model.MonitorManager.M_Entry_Statistics model, CommonService.Model.CaseManager.B_Case casemodel, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode, string tj);
    }
}
