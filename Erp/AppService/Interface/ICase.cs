using AppService.Model;
using CommonService.Model.CustomModel;
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
    /// 案件契约接口
    /// </summary>
    [ServiceContract]
    public interface ICase
    {


        #region App专用

        /// <summary>
        /// App端根据权限获取案件列表
        /// </summary>
        /// <param name="user">子用户实体</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="endIndex">截止位置</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="bcase">案件实体（查询条件）</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "AppMyCase", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<CommonService.Model.CaseManager.B_Case> AppMyCase(CommonService.Model.SysManager.C_Userinfo user, int startIndex, int endIndex, string orderBy, CommonService.Model.CaseManager.B_Case bcase);

        /// <summary>
        /// App端根据权限获取案件数量
        /// </summary>
        /// <param name="user">子用户实体</param>
        /// <param name="bcase">案件实体（查询条件）</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "AppMyCaseCount", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int AppMyCaseCount(CommonService.Model.SysManager.C_Userinfo user, CommonService.Model.CaseManager.B_Case bcase);

        /// <summary>
        /// 添加案件
        /// </summary>
        /// <param name="bcase">案件实体</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "AddCaseInfo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int AddCaseInfo(CommonService.Model.CaseManager.B_Case bcase);

        /// <summary>
        /// 更新案件
        /// </summary>
        /// <param name="bcase">案件实体</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "UpdateCaseInfo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool UpdateCaseInfo(CommonService.Model.CaseManager.B_Case bcase);

        /// <summary>
        /// 获取任务分解添加的业务流程
        /// </summary>
        [WebInvoke(UriTemplate = "DecomposeCaseLevelList/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.FlowManager.P_Business_flow> DecomposeCaseLevelList(string guid);

        /// <summary>
        /// 获取任务分解业务流程中的每个阶段的所有表单未配置的
        /// </summary>
        [WebInvoke(UriTemplate = "DecomposeCaseLevelFormNoneSelectList/{businessFlowCode}/{flowCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.FlowManager.P_Flow_form> DecomposeCaseLevelFormNoneSelectList(string businessFlowCode, string flowCode);


        /// <summary>
        /// 获取任务分解业务流程中的每个阶段的所有表单已经配置的
        /// </summary>
        [WebInvoke(UriTemplate = "DecomposeCaseLevelFormHadSelectList/{businessFlowCode}/{flowCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.FlowManager.P_Business_flow_form> DecomposeCaseLevelFormHadSelectList(string businessFlowCode, string flowCode);


        /// <summary>
        /// 将表单添加到阶段中
        /// </summary>
        [WebInvoke(UriTemplate = "FormToAddBusinessFlowForm/{businessFlowCode}/{item}/{isDefault}/{type}/{usercode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int FormToAddBusinessFlowForm(string businessFlowCode, string item, string isDefault, string type, string usercode);


        /// <summary>
        /// 更新表单排列顺序
        /// </summary>
        [WebInvoke(UriTemplate = "UpdateBusinessFlowFormOrder", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int UpdateBusinessFlowFormOrder(List<KeyValueModel> list);

        /// <summary>
        /// 删除已经添加到阶段中的表单
        /// </summary>
        [WebInvoke(UriTemplate = "DeleteBusinessFlowForm/{businessFlowFormCode}/{type}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int DeleteBusinessFlowForm(string businessFlowFormCode, string type);




        /// <summary>
        /// 获取未选择的所有阶段信息
        /// </summary>
        [WebInvoke(UriTemplate = "GetAllNoneSelectFlow/{caseguid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.FlowManager.P_Flow> GetAllNoneSelectFlow(string caseguid);


        /// <summary>
        /// 添加案件阶段
        /// </summary>
        /// <param name="bcase">案件实体</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "AddBusinessFlow", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int AddBusinessFlow(CommonService.Model.FlowManager.P_Business_flow bf, int type);

        /// <summary>
        /// 修改案件阶段
        /// </summary>
        /// <param name="bcase">案件实体</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "UpdateBusinessFlow", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool UpdateBusinessFlow(CommonService.Model.FlowManager.P_Business_flow bf, int type);

        /// <summary>
        /// 删除案件阶段
        /// </summary>
        /// <param name="bcase">案件实体</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "DeleteBusinessFlow/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool DeleteBusinessFlow(string guid);

        /// <summary>
        /// 获取表单计划
        /// </summary>
        [WebInvoke(UriTemplate = "GetPlanSet/{businessFlowCode}/{businessFlowFormCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.Customer.V_FormPlan GetPlanSet(string businessFlowCode, string businessFlowFormCode);

         /// <summary>
        /// 添加表单计划
        /// </summary>
        [WebInvoke(UriTemplate = "OperateSavePlanSet", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool OperateSavePlanSet(CommonService.Model.Customer.V_FormPlan v_FormPlan, string type);

        /// <summary>
        /// 获取表单中间表与表单表
        /// </summary>
        /// <param name="bcase">案件实体</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "GetFlowFormAndFlowEntity/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        FlowFormAndFlowEntity GetFlowFormAndFlowEntity(string guid);




        #endregion

        #region App专用 表单值
        /// <summary>
        /// 根据业务流程Guid，表单Guid，获取编辑表单头自定义属性值历史记录（不包含隐藏控件）
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "CaseLevelFormAttribute/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomerForm.F_FormProperty> GetValuesByBusinessFormCode(string guid);

        /// <summary>
        /// 获取表单中子列表的数据（手机专用）
        /// </summary>
        /// <param name="FormCode">表单GUID</param>
        /// <param name="FormPropertyValueCode">业务流程表单中间表GUID</param>
        /// <returns>数据列表</returns>
        [WebInvoke(UriTemplate = "GetAppDetailsList/{FormCode}/{FormPropertyValueCode}/{FormPropertyCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<List<CommonService.Model.CustomerForm.F_FormProperty>> GetAppDetailsList(string FormCode, string FormPropertyValueCode, string FormPropertyCode);

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="formChecks">根据表单生成的审核表数据</param>
        /// <param name="fkType">153、案件 154、商机</param>
        /// <returns>1代表成功 0代表没有符合条件可以提交的表单 -1代表提交表单所属业务流程及其父级业务流程线上的业务负责人尚未设置</returns>
        [WebInvoke(UriTemplate = "SubmitForm", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int SubmitForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks, string fkType);

        /// <summary>
        /// 审核表单
        /// </summary>
        /// <param name="formChecks">根据表单生成的审核表数据</param>
        /// <param name="fkType">153、案件 154、商机</param>
        /// <returns>1代表成功 0代表没有符合条件可以审核的表单 -1代表提交表单所属业务流程及其父级业务流程线上的业务负责人尚未设置</returns>
        [WebInvoke(UriTemplate = "CheckForm", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int CheckForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks, string fkType);


        /// <summary>
        /// 获取表单的计划时间与实际时间
        /// </summary>
        [WebInvoke(UriTemplate = "GetFactAndPlanTime/{formCode}/{businessFlowFormCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomModel.KeyValueModel> GetFactAndPlanTime(string formCode, string businessFlowFormCode);

        /// <summary>
        /// 根据业务流程表单关联Guid，获取提交记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetFirstTimeFormCheckRecord/{businessFlowFormCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomerForm.F_FormCheck> GetFirstTimeFormCheckRecord(string businessFlowFormCode);

        /// <summary>
        /// 根据业务流程表单关联Guid，获取审核记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
         [WebInvoke(UriTemplate = "GetFormCheckRecord/{businessFlowFormCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomerForm.F_FormCheck> GetFormCheckRecord(string businessFlowFormCode);


         /// <summary>
        /// 获取监控中心横向列表数量
        /// </summary>
        /// <param name="userGuid">用户GUID</param>
        /// <param name="RoleId">用户角色</param>
        /// <param name="deptCode">用户部门ID</param>
        /// <returns></returns>
        /// 
        [WebInvoke(UriTemplate = "GetMonitorCase/{userGuid}/{RoleId}/{deptCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomModel.KeyValueModel> GetMonitorCase(string userGuid, string RoleId, string deptCode);

        /// <summary>
        /// 根据用户GUID获取他应该审核的案件
        /// </summary>
        /// <param name="guid">用户GUID</param>
        /// <returns>案件列表</returns>
        [WebInvoke(UriTemplate = "GetPendingCase", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<CommonService.Model.CaseManager.B_Case> GetPendingCase(CommonService.Model.SysManager.C_Userinfo user, string startIndex, string endIndex, CommonService.Model.CaseManager.B_Case bcase);


        /// <summary>
        /// 根据用户GUID获取他应该审核的案件的数量
        /// </summary>
        /// <param name="guid">用户GUID</param>
        /// <returns>案件列表</returns>
        [WebInvoke(UriTemplate = "GetPendingCaseCount", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int GetPendingCaseCount(CommonService.Model.SysManager.C_Userinfo user, string startIndex, string endIndex, CommonService.Model.CaseManager.B_Case bcase);



        /// <summary>
        /// 获取自定义数据列表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetParameters/{tableName}/{searchName}/{startIndex}/{endIndex}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomModel.KeyValueModel> GetParameters(string tableName, string searchName, string startIndex, string endIndex);

        /// <summary>
        /// 通过表单获取关联数据（App专用）
        /// </summary>
        /// <param name="formCode">表单GUID</param>
        /// <param name="formPropertyCode">表单属性GUID</param>
        /// <param name="businessFlowFormCode">业务流程表单关联GUID</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetParametersByForm/{formCode}/{formPropertyCode}/{businessFlowFormCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomModel.KeyValueModel> GetParametersByForm(string formCode, string formPropertyCode, string businessFlowFormCode);

        /// <summary>
        /// 更新表单值
        /// </summary>
        /// <param name="businessFlowFormCode">表单值GUID</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        [WebInvoke(UriTemplate = "UpdateFormValue", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool UpdateFormValue(CommonService.Model.CustomModel.KeyValueModel keyvalue);

        /// <summary>
        /// 获得属性列表
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyParent">父亲属性Guid</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetPropertyByParent/{formCode}/{formPropertyParent}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomerForm.F_FormProperty> GetPropertyByParent(string formCode, string formPropertyParent);

        /// <summary>
        /// 添加属性值
        /// </summary>
        /// <param name="list"></param>
        [WebInvoke(UriTemplate = "AddPropertyValues", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool AddPropertyValues(List<CommonService.Model.CustomerForm.F_FormPropertyValue> list);

        /// <summary>
        /// 更新属性值
        /// </summary>
        /// <param name="list"></param>
        [WebInvoke(UriTemplate = "UpdatePropertyValues", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool UpdatePropertyValues(List<CommonService.Model.CustomerForm.F_FormPropertyValue> list);

        /// <summary>
        /// 启动案件
        /// </summary>     
        /// <param name="caseCode">案件Guid</param>
        /// <param name="startPersonCode">启动人Guid</param>
        /// <returns>-2代表此案件沒有配置阶段，无法启动;-1代表已启动，不可以重复启动;0代表案件启动失败;1代表案件启动成功</returns>
        [WebInvoke(UriTemplate = "AppStartCase/{caseCode}/{startPersonCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int AppStartCase(string caseCode, string startPersonCode);

        /// <summary>
        /// 开启单个业务流程
        /// </summary>     
        /// <param name="fkType">业务类型：153、案件 154、商机</param>
        /// <param name="fkCode">业务Guid：案件Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="loginChildrenUser">当前登录子用户Guid</param>
        /// <returns>1代表成功 0代表没有符合条件可以开启的业务流程</returns>
        [WebInvoke(UriTemplate = "StartSingleBusinessFlow/{fkType}/{fkCode}/{businessFlowCode}/{loginChildrenUser}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int StartSingleBusinessFlow(string fkType,string fkCode,string businessFlowCode,string loginChildrenUser);

        /// <summary>
        /// 根据groupCode删除表单子列表数据
        /// </summary>
        /// <param name="groupCode">分组GUID</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "AppDeleteDetailsById/{id}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int AppDeleteDetailsById(string id);


        /// <summary>
        /// 更新预期收益计算接口
        /// </summary>
        /// <param name="list"></param>
        [WebInvoke(UriTemplate = "UpdateExpectedReturnPropertyValues", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool UpdateExpectedReturnPropertyValues(List<CommonService.Model.CustomerForm.F_FormPropertyValue> list, int type);

         /// <summary>
        /// 根据案件编码获取专业顾问、专家部长、首席专家
        /// </summary>
        /// <param name="caseCode">案件GUID</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetPersonByCaseCode/{caseCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomModel.KeyValueModel> GetPersonByCaseCode(string caseCode);

        /// <summary>
        /// 根据案件编码获取案件详细信息
        /// </summary>
        /// <param name="caseCode">案件GUID</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetCaseByCaseCode/{caseCode}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommonService.Model.CaseManager.B_Case GetCaseByCaseCode(string caseCode);

        /// <summary>
        /// 获取最后一次提交的审核列表
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "AppGetCheckList/{guid}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.CustomerForm.F_FormCheck> AppGetCheckList(string guid);


        /// <summary>
        /// 更新预期收益计算接口
        /// </summary>
        /// <param name="list"></param>
        [WebInvoke(UriTemplate = "GetCaseMaintainInfoList", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<CommonService.Model.CaseManager.B_CaseMaintain> GetCaseMaintainInfoList(CommonService.Model.CaseManager.B_CaseMaintain model, int startindex, int endindex,string orderby);



        /// <summary>
        /// 更新预期收益计算接口
        /// </summary>
        /// <param name="list"></param>
        [WebInvoke(UriTemplate = "AddCaseMaintainInfo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int AddCaseMaintainInfo(CommonService.Model.CaseManager.B_CaseMaintain model2);


        /// <summary>
        /// 删除维护信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "CaseMaintainDelete/{id}", Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool CaseMaintainDelete(string id);

        /// <summary>
        /// 更新维护信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "CaseMaintainUpdate", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool CaseMaintainUpdate(CommonService.Model.CaseManager.B_CaseMaintain model);
        #endregion
    }
}
