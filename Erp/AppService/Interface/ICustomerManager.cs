using CommonService.Model.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace AppService
{
    [ServiceContract]
    public interface ICustomerManager
    {         
        #region App专用 查询添加我的日程

        /// <summary>
        /// 通过主用户GUID获取日程
        /// </summary>
        /// <param name="userCode">主用户GUID</param>
        /// <returns>日程列表</returns>
        [WebInvoke(UriTemplate = "AppGetSchedule/{userCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.OA.O_Schedule> AppGetSchedule(string userCode);

        /// <summary>
        /// 通过主用户GUID获取日程
        /// </summary>
        /// <param name="userCode">主用户GUID</param>
        /// <returns>日程列表</returns>
        [WebInvoke(UriTemplate = "GetScheduleByCode/{SchCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.OA.O_Schedule GetScheduleByCode(string SchCode);

        /// <summary>
        /// 添加日程
        /// </summary>
        /// <param name="model">日程实体</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "AppAddSchedule", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int AppAddSchedule(CommonService.Model.OA.O_Schedule model, List<CommonService.Model.OA.O_Schedule_user> lst);

        /// <summary>
        /// 修改日程
        /// </summary>
        /// <param name="model">日程实体</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "AppUpdateSchedule", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int AppUpdateSchedule(CommonService.Model.OA.O_Schedule model, List<CommonService.Model.OA.O_Schedule_user> lst);

        /// <summary>
        /// 根据用户GUID和日期获取日程
        /// </summary>
        /// <param name="userCode">用户GUID</param>
        /// <param name="dt">日期</param>
        /// <returns>日程列表</returns>
        [WebInvoke(UriTemplate = "GetListByDateAndUser/{userCode}/{dt}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.OA.O_Schedule> GetListByDateAndUser(string userCode, string dt);

        /// <summary>
        /// 根据日程GUID获取该日程关联所有用户
        /// </summary>
        /// <param name="guid">日程GUID</param>
        /// <returns>用户日程关联列表</returns>
        [WebInvoke(UriTemplate = "GetUserListByScheduleCode/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.OA.O_Schedule_user> GetUserListByScheduleCode(string guid);

        /// <summary>
        /// 获取日程列表（未读在上）
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetListByUserAndMessages/{userCode}/{startIndex}/{endIndex}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.OA.O_Schedule> GetListByUserAndMessages(string userCode, string startIndex, string endIndex);
        #endregion
        #region
        /// <summary>
        /// 增加一条Bug信息
        /// </summary>
        [WebInvoke(UriTemplate = "AddAppBugLog", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int AddAppBugLog(CommonService.Model.C_AppBugLog model);
        #endregion
        #region App专用 客户
        /// <summary>
        /// 获取客户信息
        /// </summary>
        /// <param name="model">客户实体条件</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <returns>客户列表</returns>
        [WebInvoke(UriTemplate = "GetCustomerList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<CommonService.Model.C_Customer> GetCustomerList(CommonService.Model.C_Customer model, int startIndex, int endIndex, C_Userinfo user, int type);

        /// <summary>
        /// 获取客户跟踪数据
        /// </summary>
        /// <param name="model">客户跟踪实体条件</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">结束位置</param>     
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetFollowUpsByCustCode", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<CommonService.Model.C_Customer_Follow> GetFollowUpsByCustCode(CommonService.Model.C_Customer_Follow model, int startIndex, int endIndex);

        /// <summary>
        /// 获取客户联系人数据
        /// </summary>
        /// <param name="model">客户联系人实体条件</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">结束位置</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetContactsByCustCode", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<CommonService.Model.C_Contacts> GetContactsByCustCode(CommonService.Model.C_Contacts model,int startIndex, int endIndex);

        /// <summary>
        /// 获取客户实体
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetCustomer/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.C_Customer GetCustomer(string guid);

        [WebInvoke(UriTemplate = "GetPerson/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.C_PRival GetPerson(string guid);


        [WebInvoke(UriTemplate = "GetCompany/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.C_CRival GetCompany(string guid);

        /// <summary>
        /// 获取客户总数
        /// </summary>
        /// <param name="model">客户实体条件</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <returns>数量</returns>
        [WebInvoke(UriTemplate = "GetCustomerCount", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int GetCustomerCount(CommonService.Model.C_Customer model, C_Userinfo user);

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="model">客户实体</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "AddCustomer", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int AddCustomer(CommonService.Model.C_Customer model);

        /// <summary>
        /// 操作客户联系人
        /// </summary>
        /// <param name="model">客户联系人实体</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "OperateCustomerContact", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int OperateCustomerContact(CommonService.Model.C_Contacts model);

        /// <summary>
        /// 根据联系人Guid，获取联系人实体
        /// </summary>
        /// <param name="contactCode">联系人Code</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetCustomerContact/{contactCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.C_Contacts GetCustomerContact(string contactCode);

        /// <summary>
        /// 根据客户跟踪Id，获取客户跟踪实体
        /// </summary>
        /// <param name="customerFollowId">客户跟踪Id</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetCustomerFollow/{customerFollowId}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.C_Customer_Follow GetCustomerFollow(string customerFollowId);

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="guid">客户GUID</param>
        /// <returns>0 不成功 1 成功 2 该客户的添加日期不是当天 3 未知错误</returns>
        [WebInvoke(UriTemplate = "DeleteCustomer/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int DeleteCustomer(string guid);

        /// <summary>
        /// 删除客户联系人
        /// </summary>
        /// <param name="customerCode">客户GUID</param>
        /// <param name="contactCode">联系人GUID</param>
        /// <returns>0 删除失败， 1 删除成功， 2 该联系人有客户跟进，不可以删除</returns>
        [WebInvoke(UriTemplate = "DeleteCustomerContact/{customerCode}/{contactCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int DeleteCustomerContact(string customerCode,string contactCode);

        /// <summary>
        /// 删除客户跟踪
        /// </summary>     
        /// <param name="customerFollowId">客户跟踪ID</param>
        /// <returns>0 删除失败， 1 删除成功</returns>
        [WebInvoke(UriTemplate = "DeleteCustomerFollow/{customerFollowId}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int DeleteCustomerFollow(string customerFollowId);

        /// <summary>
        /// 保存客户跟踪
        /// </summary>
        /// <param name="model">客户跟踪实体</param>
        /// <returns>返回1代表，成功；0代表失败</returns>
        [WebInvoke(UriTemplate = "SaveCustomerFollow", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int SaveCustomerFollow(CommonService.Model.C_Customer_Follow model);

        #endregion

    }
}