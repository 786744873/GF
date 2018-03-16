using CommonService.Model.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AppService
{
    public class ProcessManager : IProcessManager
    {
        CommonService.BLL.FlowManager.P_Business_flow bll = new CommonService.BLL.FlowManager.P_Business_flow();
        CommonService.BLL.FlowManager.P_Business_flow_form blltable = new CommonService.BLL.FlowManager.P_Business_flow_form();
        CommonService.BLL.MonitorManager.M_Entry_Statistics statBLL = new CommonService.BLL.MonitorManager.M_Entry_Statistics();
        /// <summary>
        /// 条目变更业务逻辑层
        /// </summary>
        CommonService.BLL.MonitorManager.M_Entry_Change entryChangeBLL = new CommonService.BLL.MonitorManager.M_Entry_Change();

        #region App专用
        /// <summary>
        /// 根据案件GUID获取该案件下所有的一级业务流程
        /// </summary>
        /// <param name="guid">案件GUID</param>
        /// <returns>业务流程列表</returns>
        public List<CommonService.Model.FlowManager.P_Business_flow> AppGetCaseStageInfo(string guid, string usercode)
        {
            return bll.AppGetCaseStageInfo(Guid.Parse(guid), Guid.Parse(usercode));
        }

        /// <summary>
        /// 获取业务流程实体
        /// </summary>
        /// <param name="guid">业务流程GUID</param>
        /// <returns>业务流程实体</returns>
        public CommonService.Model.FlowManager.P_Business_flow AppGetCaseEachStageInfo(string guid)
        {
            return bll.GetModel(Guid.Parse(guid));
        }
        #endregion

        #region App专用 阶段表单信息

        /// <summary>
        /// 根据阶段GUID获取该阶段下所有表单，不包含已作废表单
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> AppGetCaseStageFormInfo(string guid)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_form> list = blltable.AppGetCaseStageFormInfo(guid); //获取到所有表单

            return list;
        }
        #endregion

        #region 进程管理
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
        public List<CommonService.Model.MonitorManager.M_Entry_Statistics> GetProcessList(CommonService.Model.MonitorManager.M_Entry_Statistics model, CommonService.Model.CaseManager.B_Case casemodel, string orderby, int startIndex, int endIndex, CommonService.Model.SysManager.C_Userinfo user)
        {
            return statBLL.AppGetListByPage(model, casemodel, orderby, startIndex, endIndex, false, user._c_userinfo_roleid, user._c_userinfo_code, user._c_userinfo_post, user._c_userinfo_organization, "");
        }




        /// <summary>
        /// 获取进程管理总数
        /// </summary>
        /// <param name="model">进程管理实体条件</param>
        /// <param name="casemodel">案件实体条件</param>
        /// <param name="userCode">子用户GUID</param>
        /// <param name="postCode">岗位GUID</param>
        /// <param name="deptCode">部门GUID</param>
        /// <returns></returns>
        public int GetProcessListCount(CommonService.Model.MonitorManager.M_Entry_Statistics model, CommonService.Model.CaseManager.B_Case casemodel, CommonService.Model.SysManager.C_Userinfo user)
        {
            return statBLL.GetRecordCount(model, casemodel, "", false, user.C_Userinfo_code, user.C_Userinfo_post, user.C_Userinfo_Organization);
        }
        #endregion

        /// <summary>
        /// 根据条目变更编码，条目统计编码，来源类型，获取条目统计信息
        /// </summary>
        /// <param name="entryChangeCode">条目变更编码</param>
        /// <param name="entryStatisticsCode">条目统计编码</param>
        /// <param name="fromSourceType">来源类型(1代表来源申请变更；2代表来源变更审核)</param>
        /// <returns></returns>      
        public List<CommonService.Model.CustomModel.KeyValueModel> GetEntryStatistics(string entryChangeCode, string entryStatisticsCode, string fromSourceType)
        {
            return entryChangeBLL.GetEntryStatistics(entryChangeCode, entryStatisticsCode, fromSourceType);
        }

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
        public int AproveEntryChange(string entryChangeCode, string approvalDuration, string approvalReaso, string IsThrough, string operateChildrenUserCode, string operateChildrenUserName)
        {
            return entryChangeBLL.AproveEntryChange(entryChangeCode,approvalDuration, approvalReaso, IsThrough, operateChildrenUserCode, operateChildrenUserName);
        }

        /// <summary>
        /// 根据条目变更标识，获取条目变更信息
        /// </summary>
        /// <param name="entryChangeCode">条目变更标识</param>
        /// <returns></returns>    
        public CommonService.Model.MonitorManager.M_Entry_Change GetEntryChange(string entryChangeCode)
        {
            return entryChangeBLL.GetEntryChange(entryChangeCode);
        }


    }
}