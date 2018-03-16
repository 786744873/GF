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
    public interface IK_Knowledge_Resources
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
        bool Exists(int K_Knowledge_Resources_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.KMS.K_Knowledge_Resources model);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="K_Knowledge_Resources_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.KMS.K_Knowledge_Resources GetModel(Guid K_Knowledge_Resources_code);
        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.KMS.K_Knowledge_Resources GetModelByFkCode(Guid P_FK_code);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_Knowledge_Resources model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid K_Knowledge_Resources_code);
         /// <summary>
        /// 根据关联Guid删除一条数据
        /// </summary>
        [OperationContract]
        bool DeleteByFkCode(Guid P_FK_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.KMS.K_Knowledge_Resources model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Knowledge_Resources> GetListByPage(CommonService.Model.KMS.K_Knowledge_Resources model, string orderby, int startIndex, int endIndex);
    }
}
