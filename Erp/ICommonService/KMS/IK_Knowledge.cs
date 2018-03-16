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
    public interface IK_Knowledge
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
        bool Exists(int K_Knowledge_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.KMS.K_Knowledge model);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.KMS.K_Knowledge GetModel(Guid K_Knowledge_code);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_Knowledge model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid K_Knowledge_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.KMS.K_Knowledge model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Knowledge> GetListByPage(CommonService.Model.KMS.K_Knowledge model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 获取全部数据
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Knowledge> GetAllList();
        /// <summary>
        /// 根据负责人获取全部数据
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Knowledge> GetAllListByPerson(Guid K_Knowledge_Person);
        /// <summary>
        /// 移动资源
        /// </summary>
        /// <param name="knowledgeCode">知识分类Guid</param>
        /// <param name="resourcesCode">资源Guid</param>
        /// <returns></returns>
        [OperationContract]
        bool MobileResource(Guid knowledgeCode,Guid resourcesCode);
    }
}
