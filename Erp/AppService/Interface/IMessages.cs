using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
namespace AppService
{
    /// <summary>
    /// 接口层C_Messages消息表
    /// </summary>
    [ServiceContract]
    public interface IMessages
    {
        #region App专用
        /// <summary>
        /// 根据用户GUID获取该用户的消息数量
        /// </summary>
        /// <param name="guid">主用户GUID</param>
        /// <returns>消息数量集合</returns>
        [WebInvoke(UriTemplate = "AppGetMessageList/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomModel.KeyValueModel> AppGetMessageList(string guid);


        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="startIndex">开始条数</param>
        /// <param name="endIndex">结尾条数</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="model">文章实体（查询条件）</param>
        /// <returns>返回值通知公告列表</returns>
        [WebInvoke(UriTemplate = "AppGetArticle", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<CommonService.Model.OA.O_Article> AppGetArticle(int startIndex, int endIndex, string orderBy, CommonService.Model.OA.O_Article model);



        /// <summary>
        /// 获取文章
        /// </summary>
        /// <param name="startIndex">开始条数</param>
        /// <param name="endIndex">结尾条数</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="model">文章实体（查询条件）</param>
        /// <returns>返回值通知公告列表</returns>
        [WebInvoke(UriTemplate = "AppArticle/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.OA.O_Article AppArticle(string guid);


        /// <summary>
        /// 根据GUID使公告已读
        /// </summary>

        [WebInvoke(UriTemplate = "AppIsRead/{articleguid}/{userguid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool AppIsRead(string articleguid, string userguid);

        /// <summary>
        /// 获取消息列表
        /// </summary>
        /// <param name="bigType">消息大类型</param>
        /// <param name="smallType">消息小类型</param>
        /// <param name="guid">用户GUID</param>
        /// <returns>消息列表</returns>
        [WebInvoke(UriTemplate = "AppGetMessages/{bigType}/{msgType}/{guid}/{startIndex}/{endIndex}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.C_Messages> AppGetMessages(string bigType, string msgType, string guid, string startIndex, string endIndex);

        /// <summary>
        /// 获取消息数量集合
        /// </summary>
        /// <param name="messageCategoryBigClass">消息大类型</param>
        /// <param name="messageCategoryLevel">消息级别</param>
        /// <param name="loginChildrenUser">用户GUID</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetMessagesCount/{messageCategoryBigClass}/{messageCategoryLevel}/{loginChildrenUser}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.C_Messages_Category> GetMessagesCount(string messageCategoryBigClass, string messageCategoryLevel, string loginChildrenUser);

        /// <summary>
        /// 将未读消息改为已读
        /// </summary>
        /// <param name="messageID">消息ID</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "AppUpdateMessagesIsRead/{messageID}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool AppUpdateMessagesIsRead(string messageID);

        /// <summary>
        /// 将未读消息改为已读
        /// </summary>
        /// <param name="messageID">消息ID</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "GetMessages/{messageID}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.C_Messages GetMessages(string messageID);
        #endregion
    }
}