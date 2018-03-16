using ICommonService.KMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.KMS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“P_Business_flow”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 P_Business_flow.svc 或 P_Business_flow.svc.cs，然后开始调试。
    public class K_Comments : IK_Comments
    {
        CommonService.BLL.KMS.K_Comments bll = new CommonService.BLL.KMS.K_Comments();
        /// <summary>
        /// 获得最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该条记录
        /// </summary>
        /// <param name="K_Comments_id"></param>
        /// <returns></returns>
        public bool Exists(int K_Comments_id)
        {
            return bll.Exists(K_Comments_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(CommonService.Model.KMS.K_Comments model)
        {
            return bll.Add(model);
        }
        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="K_Comments_code"></param>
        /// <returns></returns>
        public Model.KMS.K_Comments GetModel(Guid K_Comments_code)
        {
            return bll.GetModel(K_Comments_code);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CommonService.Model.KMS.K_Comments model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="K_Comments_code"></param>
        /// <returns></returns>
        public bool Delete(Guid K_Comments_code)
        {
            return bll.Delete(K_Comments_code);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        public bool DeleteList(string K_Comments_idlist)
        {
            return bll.DeleteList(K_Comments_idlist);
        }
        /// <summary>
        /// 获得记录总数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(CommonService.Model.KMS.K_Comments model)
        {
            return bll.GetRecordCount(model);
        }
        /// <summary>
        /// 获得最大楼层数
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        public int GetFloors(Guid P_FK_code)
        {
            return bll.GetFloors(P_FK_code);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Comments> GetListByPage(CommonService.Model.KMS.K_Comments model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 分页获取资源评论列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Comments> GetResourcesCommentListByPage(CommonService.Model.KMS.K_Comments model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetResourcesCommentListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 分页获取问答回答列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Comments> GetProblemCommentListByPage(CommonService.Model.KMS.K_Comments model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetProblemCommentListByPage(model, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 根据外键guid获得评论列表
        /// </summary>
        /// <param name="P_FK_code"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Comments> GetCommentsListByCode(Guid P_FK_code)
        {
            return bll.GetCommentsListByCode(P_FK_code);
        }

        /// <summary>
        /// 风云榜
        /// </summary>
        /// <param name="K_Comments_type">评论类型</param>
        /// <returns></returns>
        public List<Model.KMS.K_Comments> GetListByHelpfulCount(int K_Comments_type)
        {
            return bll.GetListByHelpfulCount(K_Comments_type);
        }

        /// <summary>
        /// 用户未读评论列表
        /// </summary>
        /// <param name="K_Comments_creator">用户Guid</param>
        /// <param name="K_Comments_type">评论类型</param>
        /// <returns></returns>
        public List<Model.KMS.K_Comments> GetUnreadList(Guid K_Comments_creator, int K_Comments_type)
        {
            return bll.GetUnreadList(K_Comments_creator, K_Comments_type);
        }
    }
}
