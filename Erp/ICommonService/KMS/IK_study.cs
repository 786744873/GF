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
    public interface IK_study
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
        bool Exists(int K_study_id);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool ExistsStudy(Guid K_study_creator, Guid K_Resources_code);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.KMS.K_study model);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.KMS.K_study GetModel(Guid K_study_code);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_study model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid K_study_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.KMS.K_study model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_study> GetListByPage(CommonService.Model.KMS.K_study model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 用户最近收藏
        /// </summary>
        /// <param name="K_study_creator">用户Guid</param>
        /// <param name="pageSize">展示条数</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_study> GetListByCreatorTime(Guid K_study_creator,int pageSize);
    }
}
