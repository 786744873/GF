using ICommonService.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Feedback
{
    /// <summary>
    /// 意见反馈服务
    /// </summary>
    public class C_Feedback : IC_Feedback
    {
        CommonService.BLL.Feedback.C_Feedback bll = new CommonService.BLL.Feedback.C_Feedback();

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.Feedback.C_Feedback model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.Feedback.C_Feedback model)
        {
            return bll.GetRecordCount(model);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.Feedback.C_Feedback> GetListByPage(Model.Feedback.C_Feedback model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="FeedbackCode"></param>
        /// <returns></returns>
        public Model.Feedback.C_Feedback GetModel(Guid FeedbackCode)
        {
            return bll.GetModel(FeedbackCode);
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="FeedbackList"></param>
        /// <returns></returns>
        public bool OperateList(List<Model.Feedback.C_Feedback> FeedbackList)
        {
            return bll.OperateList(FeedbackList);
        }

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.Feedback.C_Feedback model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 根据申请人获得数据
        /// </summary>
        /// <param name="C_Feedback_applicant"></param>
        /// <returns></returns>
        public List<Model.Feedback.C_Feedback> GetListByApplicant(Guid C_Feedback_applicant)
        {
            return bll.GetListByApplicant(C_Feedback_applicant);
        }

        /// <summary>
        /// 获得所有数据
        /// </summary>
        /// <returns></returns>
        public List<Model.Feedback.C_Feedback> GetAllList()
        {
            return bll.GetAllList();
        }
    }
}
