using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace AppService.Interface
{
    /// <summary>
    /// 表单契约接口
    /// </summary>
    [ServiceContract]
    public interface IForm
    {
        #region App专用 添加审核信息 审核表单
        /// <summary>
        /// 根据表单GUID获取该表单下所有的历史纪要
        /// </summary>
        /// <param name="guid">表单GUID</param>
        /// <returns>历史纪要列表</returns>
        [WebInvoke(UriTemplate = "AppGetHistoricalSummary", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomerForm.F_FormCheck> AppGetHistoricalSummary(string guid);

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="lst">需要提交的表单集合</param>
        /// <returns>状态：1成功 0不成功</returns>
        [WebInvoke(UriTemplate = "AppAddAuditInfo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int AppAddAuditInfo(List<CommonService.Model.CustomerForm.F_FormCheck> lst);

        /// <summary>
        /// 审核表单
        /// </summary>
        /// <param name="lst">审核表单集合</param>
        /// <returns>状态：1成功 0不成功</returns>
        [WebInvoke(UriTemplate = "AppCheckList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int AppCheckList(List<CommonService.Model.CustomerForm.F_FormCheck> lst);

        /// <summary>
        /// 获取当前用户可以审核的表单集合
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="loginChildrenUserCode">当前登录子用户Guid</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetCheckOwnFormsByUser/{businessFlowCode}/{loginChildrenUserCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.Customer.V_User> GetCheckOwnFormsByUser(string businessFlowCode, string loginChildrenUserCode);

        /// <summary>
        /// 获取可以保存自定义表单的用户集合
        /// </summary>
        /// <param name="businessFlowCode">业务流程表单关联Guid</param>  
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetSaveOwnFormUsers/{businessFlowFormCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.Customer.V_User> GetSaveOwnFormUsers(string businessFlowFormCode);

        #endregion
    }
}