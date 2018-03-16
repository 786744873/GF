using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AppService
{
    [ServiceContract]
    public interface IProcessManager
    {
       
        #region App专用 案件阶段信息

        /// <summary>
        /// 根据案件GUID获取该案件下所有的流程
        /// </summary>
        /// <param name="guid">案件GUID</param>
        /// <returns>业务流程列表</returns>
        [WebInvoke(UriTemplate = "AppGetCaseStageInfo/{guid}/{usercode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.FlowManager.P_Business_flow> AppGetCaseStageInfo(string guid,string usercode);

        /// <summary>
        /// 获取业务流程实体
        /// </summary>
        /// <param name="guid">业务流程GUID</param>
        /// <returns>业务流程实体</returns>
        [WebInvoke(UriTemplate = "AppGetCaseEachStageInfo/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.FlowManager.P_Business_flow AppGetCaseEachStageInfo(string guid);

        #endregion
        #region App专用 阶段表单信息

        /// <summary>
        /// 根据阶段GUID获取该阶段下所有表单，不包含已作废表单
        /// </summary>
        /// <param name="guid">流程GUID</param>
        /// <returns>表单列表</returns>
        [WebInvoke(UriTemplate = "AppGetCaseStageFormInfo/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.FlowManager.P_Business_flow_form> AppGetCaseStageFormInfo(string guid);

        /// <summary>
        /// 获取进程管理列表
        /// </summary>
        /// <param name="model">进程管理实体条件</param>
        /// <param name="casemodel">案件实体条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <param name="RoleId">角色ID</param>
        /// <param name="userCode">子用户GUID</param>
        /// <param name="postCode">岗位GUID</param>
        /// <param name="deptCode">部门GUID</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetProcessList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<CommonService.Model.MonitorManager.M_Entry_Statistics> GetProcessList(CommonService.Model.MonitorManager.M_Entry_Statistics model, CommonService.Model.CaseManager.B_Case casemodel, string orderby, int startIndex, int endIndex,CommonService.Model.SysManager.C_Userinfo user);

        /// <summary>
        /// 获取进程管理总数
        /// </summary>
        /// <param name="model">进程管理实体条件</param>
        /// <param name="casemodel">案件实体条件</param>
        /// <param name="RoleId">角色ID</param>
        /// <param name="userCode">子用户GUID</param>
        /// <param name="postCode">岗位GUID</param>
        /// <param name="deptCode">部门GUID</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetProcessListCount", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int GetProcessListCount(CommonService.Model.MonitorManager.M_Entry_Statistics model, CommonService.Model.CaseManager.B_Case casemodel, CommonService.Model.SysManager.C_Userinfo user);
        #endregion

        /// <summary>
        /// 根据条目变更编码，条目统计编码，来源类型，获取条目统计信息
        /// </summary>
        /// <param name="entryChangeCode">条目变更编码</param>
        /// <param name="entryStatisticsCode">条目统计编码</param>
        /// <param name="fromSourceType">来源类型(1代表来源申请变更；2代表来源变更审核)</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetEntryStatistics/{entryChangeCode}/{entryStatisticsCode}/{fromSourceType}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomModel.KeyValueModel> GetEntryStatistics(string entryChangeCode, string entryStatisticsCode, string fromSourceType);

        /// <summary>
        /// 审批变更时长业务
        /// </summary>
        /// <param name="entryChangeCode">条目变更标识</param>
        /// <param name="approvalDuration">变更审批时长</param>
        /// <param name="approvalReaso">变更审批理由</param>
        /// <param name="IsThrough">变更类型</param>
        /// <param name="operateChildrenUserCode">操作子用户标识</param>
        /// <param name="operateChildrenUserName">操作子用户名称</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "AproveEntryChange", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int AproveEntryChange(string entryChangeCode,string approvalDuration, string approvalReaso, string IsThrough, string operateChildrenUserCode, string operateChildrenUserName);

        /// <summary> 
        /// 根据条目变更标识，获取条目变更信息
        /// </summary>
        /// <param name="entryChangeCode">条目变更标识</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetEntryChange/{entryChangeCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.MonitorManager.M_Entry_Change GetEntryChange(string entryChangeCode);

    }
}