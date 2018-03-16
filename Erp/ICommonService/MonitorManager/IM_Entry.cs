using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.MonitorManager
{
    /// <summary>
    /// 条目契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IM_Entry
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
        bool Exists(int M_Entry_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.MonitorManager.M_Entry model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.MonitorManager.M_Entry model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int M_Entry_id);

        /// <summary>
        /// 获取全部数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.MonitorManager.M_Entry> GetAllList();

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.MonitorManager.M_Entry GetModel(int M_Entry_id);
        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.MonitorManager.M_Entry GetModelByCode(Guid M_Entry_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.MonitorManager.M_Entry model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.MonitorManager.M_Entry> GetListByPage(CommonService.Model.MonitorManager.M_Entry model, string orderby, int startIndex, int endIndex);
    }
}
