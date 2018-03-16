using CommonService.Model.OA;
using ICommonService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    /// <summary>
    /// C_Messages
    /// </summary>
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“C_Messages”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 C_Messages.svc 或 C_Messages.svc.cs，然后开始调试。
    public class Messages : IMessages
    {

        CommonService.BLL.C_Messages messageBLL = new CommonService.BLL.C_Messages();
        private readonly CommonService.BLL.OA.O_Article articleBll = new CommonService.BLL.OA.O_Article();
        CommonService.BLL.OA.O_Article_user blluser = new CommonService.BLL.OA.O_Article_user();
        public Messages()
        { }
        #region App专用
        /// <summary>
        /// 根据用户GUID获取该用户的消息数量
        /// </summary>
        /// <param name="guid">主用户GUID</param>
        /// <returns>消息数量集合</returns>
        public List<CommonService.Model.CustomModel.KeyValueModel> AppGetMessageList(string guid)
        {
            return messageBLL.GetMessageList(Guid.Parse(guid));
        }

        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="startIndex">开始条数</param>
        /// <param name="endIndex">结尾条数</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="model">文章实体（查询条件）</param>
        /// <returns>返回值通知公告列表</returns>
        public List<CommonService.Model.OA.O_Article> AppGetArticle(int startIndex, int endIndex, string orderBy, CommonService.Model.OA.O_Article model)
        {
            List<CommonService.Model.OA.O_Article> list = articleBll.AppGetArticle(startIndex, endIndex, orderBy, model);
            return list;
        }

        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public O_Article AppArticle(string guid)
        {
            return articleBll.GetModel(Guid.Parse(guid));
        }


        /// <summary>
        /// 根据GUID使公告已读
        /// </summary>
        public bool AppIsRead(string articleguid, string userguid)
        {
            O_Article_user oau = blluser.GetModelByAcodeAndCcode(Guid.Parse(articleguid), Guid.Parse(userguid));
            if (oau == null)
            {
                return false;
            }
            oau.O_Article_user_isRead = true;
            return blluser.IsRead(oau);
        }

        /// <summary>
        /// 获取消息列表
        /// </summary>
        /// <param name="bigType">消息大类型</param>
        /// <param name="smallType">消息小类型</param>
        /// <returns>消息列表</returns>
        public List<CommonService.Model.C_Messages> AppGetMessages(string bigType, string msgType, string guid, string startIndex, string endIndex)
        {
            CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
            message.C_Messages_fType = Convert.ToInt32(bigType);
            message.C_Messages_Category_type = Convert.ToInt32(msgType);
            message.C_Messages_person = Guid.Parse(guid);
            return messageBLL.GetListByPage(message, "C_Messages_isRead,C_Messages_createTime desc", Convert.ToInt32(startIndex), Convert.ToInt32(endIndex));
        }

        /// <summary>
        /// 获取消息数量集合
        /// </summary>
        /// <param name="messageCategoryBigClass">消息大类型</param>
        /// <param name="messageCategoryLevel">消息级别</param>
        /// <param name="loginChildrenUser">用户GUID</param>
        public List<CommonService.Model.C_Messages_Category> GetMessagesCount(string messageCategoryBigClass, string messageCategoryLevel, string loginChildrenUser)
        {
            CommonService.BLL.C_Messages_Category cmcBLL = new CommonService.BLL.C_Messages_Category();
            return cmcBLL.GetMessageHeads(Convert.ToInt32(messageCategoryBigClass), Convert.ToInt32(messageCategoryLevel), false, new Guid(loginChildrenUser));
        }

        /// <summary>
        /// 将未读消息改为已读
        /// </summary>
        /// <param name="messageID">消息ID</param>
        /// <returns>是否成功</returns>
        public bool AppUpdateMessagesIsRead(string messageID)
        {
            return messageBLL.AppUpdateMessagesIsRead(Convert.ToInt32(messageID)) > 0 ? true : false;
        }

        public CommonService.Model.C_Messages GetMessages(string messageID)
        {
            return messageBLL.GetModel(Convert.ToInt32(messageID));
        }

        #endregion






       
    }
}
