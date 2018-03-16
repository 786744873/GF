using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.KMS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IP_Business_flow”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IK_Problem
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
        bool Exists(int K_Problem_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.KMS.K_Problem model);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.KMS.K_Problem GetModel(Guid K_Problem_code);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_Problem model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid K_Problem_code);
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="K_Problem_idlist"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteList(string K_Problem_idlist);
        /// <summary>
        /// 问题审核
        /// </summary>
        /// <param name="problemCode">问题Guid</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        [OperationContract]
        bool ProblemAudit(Guid problemCode, int state);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.KMS.K_Problem model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Problem> GetListByPage(CommonService.Model.KMS.K_Problem model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 获取当月记录总数
        /// </summary>
        [OperationContract]
        int GetRecordCountByMonth(CommonService.Model.KMS.K_Problem model);
        /// <summary>
        /// 获取热门问题
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Problem> GetListByBrowseCount();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="list">要查询的列表</param>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Problem> SearchResources(string path, string keyWord, int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 获得要查询的数据列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Problem> GetSearchList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 查询数据返回对应的问题code集合
        /// </summary>
        /// <param name="path">索引路径</param>
        /// <param name="keyWord">关键字</param>
        /// <returns></returns>
        [OperationContract]
        string GetProblemCodeItems(string path, string keyWord);
        /// <summary>
        /// 根据code集合获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Problem> GetListByCodeList(string codeList);


    }
}
