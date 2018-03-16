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
    public interface IK_Keyword
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
        bool Exists(int K_Keyword_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.KMS.K_Keyword model);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.KMS.K_Keyword GetModel(Guid K_Keyword_code);
        /// <summary>
        /// 根据关键字得到一个对象Guid
        /// </summary>
        [OperationContract]
        string GetModelByKey(string K_Keyword_name);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_Keyword model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid K_Keyword_code);

        /// <summary>
        /// 批量操作
        /// </summary>
        [OperationContract]
        bool OperateList(List<CommonService.Model.KMS.K_Keyword> modelList);


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.KMS.K_Keyword model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Keyword> GetListByPage(CommonService.Model.KMS.K_Keyword model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 获取全部数据
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Keyword> GetAllList();
        /// <summary>
        /// 根据资源guid获得资源的关键字列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Keyword> GetKeywordList(Guid K_Resources_code);
        /// <summary>
        /// 获得热门标签前10条数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Keyword> GetTagList();
    }
}
