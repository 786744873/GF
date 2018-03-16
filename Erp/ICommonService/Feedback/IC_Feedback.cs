using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.Feedback
{
    /// <summary>
    /// 意见反馈契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Feedback
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.Feedback.C_Feedback model);

        /// <summary>
        /// 修改一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.Feedback.C_Feedback model);

        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="FeedbackCode">意见反馈GUID</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.Feedback.C_Feedback GetModel(Guid FeedbackCode);

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="FeedbackList"></param>
        /// <returns></returns>
        [OperationContract]
        bool OperateList(List<CommonService.Model.Feedback.C_Feedback> FeedbackList);

        /// <summary>
        /// 根据申请人获得数据
        /// </summary>
        /// <param name="C_Feedback_applicant"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.Feedback.C_Feedback> GetListByApplicant(Guid C_Feedback_applicant);

        /// <summary>
        /// 获得所有数据
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.Feedback.C_Feedback> GetAllList();

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.Feedback.C_Feedback model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.Feedback.C_Feedback> GetListByPage(CommonService.Model.Feedback.C_Feedback model, string orderby, int startIndex, int endIndex);
    }
}
