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
    public interface IK_Comments
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
        bool Exists(int K_Comments_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.KMS.K_Comments model);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_code"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.KMS.K_Comments GetModel(Guid K_Comments_code);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_Comments model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid K_Comments_code);
        /// <summary>
        /// 批量删除
        /// </summary>
        [OperationContract]
        bool DeleteList(string K_Comments_idlist);

        /// <summary>
        /// 获得最大楼层数
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        [OperationContract]
        int GetFloors(Guid P_FK_code);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.KMS.K_Comments model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.KMS.K_Comments> GetListByPage(CommonService.Model.KMS.K_Comments model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 分页获取资源评论列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Comments> GetResourcesCommentListByPage(CommonService.Model.KMS.K_Comments model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 分页获取问答回答列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Comments> GetProblemCommentListByPage(CommonService.Model.KMS.K_Comments model, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 根据外键guid获得评论列表
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Comments> GetCommentsListByCode(Guid P_FK_code);
        /// <summary>
        /// 风云榜
        /// </summary>
        /// <param name="K_Comments_type">评论类型</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_Comments> GetListByHelpfulCount(int K_Comments_type);
        /// <summary>
        /// 用户未读评论列表
        /// </summary>
        /// <param name="K_Comments_creator">用户Guid</param>
        /// <param name="K_Comments_type">评论类型</param>
        /// <returns></returns>
        [OperationContract] 
        List<CommonService.Model.KMS.K_Comments> GetUnreadList(Guid K_Comments_creator, int K_Comments_type);
    }
}
