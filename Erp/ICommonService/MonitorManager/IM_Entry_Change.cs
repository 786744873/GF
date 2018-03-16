using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.MonitorManager
{
    /// <summary>
    /// 条目变更契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IM_Entry_Change
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
        bool Exists(int M_Entry_Change_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.MonitorManager.M_Entry_Change model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.MonitorManager.M_Entry_Change model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]

        bool Delete(int M_Entry_Change_id);
        //根据进程Code获取所有的变更信息
       
        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.MonitorManager.M_Entry_Change GetModel(Guid M_Entry_Change_code);

        /// <summary>
        /// 根据案件Guid，获取条目变更记录
        /// </summary>
        /// <param name="pkCode">案件Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.MonitorManager.M_Entry_Change> GetEntryChangeRecordByPkCode(Guid pkCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.MonitorManager.M_Entry_Change model, string orderby, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.MonitorManager.M_Entry_Change> GetListByPage(CommonService.Model.MonitorManager.M_Entry_Change model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode, string tj);
        [OperationContract]
        List<CommonService.Model.MonitorManager.M_Entry_Change> GetModelList(string strWhere);
    
    }
}
