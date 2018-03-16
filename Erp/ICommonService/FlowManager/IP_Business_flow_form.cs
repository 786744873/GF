using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.FlowManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IP_Business_flow”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IP_Business_flow_form
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        [OperationContract]
        int GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int P_Business_flow_form_id);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool ExistsByBusinessflowCodeAndFormCode(Guid P_Business_flow_code, Guid F_Form_code);

        /// <summary>
        /// 检查当前业务流程，表单是否存在重做记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns>如果存在，返回true;不存在，返回false</returns>
        [OperationContract]
        bool ExistsRelDoneFormByBusinessflowCodeAndFormCode(Guid businessFlowCode, Guid formCode);

        /// <summary>
        /// 根据业务流程guid和表单guid，获取有效的业务流程表单关联Guid,及其状态
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns>返回有效业务流程表单关联Guid</returns>
        [OperationContract]
        string GetEffectBusinessFlowFormCode(Guid businessFlowCode, Guid formCode);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.FlowManager.P_Business_flow_form model, int type);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.FlowManager.P_Business_flow_form model);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_form_code">业务流程关联表单Guid</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.FlowManager.P_Business_flow_form Get(Guid P_Business_flow_form_code);
        /// <summary>
        /// 查看配置的表单是否可以删除
        /// </summary>
        /// <param name="P_Business_flow_form_code">业务流程关联表单Guid集合</param>
        /// <returns></returns>
        [OperationContract]
        bool GetisNoDefault(string P_Business_flow_form_codes);

        /// <summary>
        /// 向前移动
        /// </summary>
        /// <param name="businessFlowCode"></param>
        /// <param name="businessFlowFormCode"></param>
        /// <returns></returns>
        [OperationContract]
        bool MoveForward(Guid businessFlowCode, Guid businessFlowFormCode);

        /// <summary>
        ///  向后移动
        /// </summary>
        /// <param name="businessFlowCode"></param>
        /// <param name="businessFlowFormCode"></param>
        /// <returns></returns>
        [OperationContract]
        bool MoveBackward(Guid businessFlowCode, Guid businessFlowFormCode);

        /// <summary>
        /// 保存计划设定
        /// </summary>
        /// <param name="v_FormPlan"></param>
        /// <returns></returns>
        [OperationContract]
        bool SavePlanSet(CommonService.Model.Customer.V_FormPlan v_FormPlan, string type);

        /// <summary>
        /// 批量保存计划设定
        /// </summary>
        /// <param name="v_FormPlan"></param>
        /// <returns></returns>
        [OperationContract]
        bool OperateSavePlanSet(CommonService.Model.Customer.V_FormPlan v_FormPlan, string type);

        /// <summary>
        /// 得到计划设定
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.Customer.V_FormPlan GetPlanSet(Guid businessFlowCode, Guid businessFlowFormCode);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(string businessFlowFormCode, int type);

        /// <summary>
        /// 根据业务流程Guid获取关联所有表单数据列表
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Business_flow_form> GetBusinessFlowForms(Guid businessFlowCode);

        /// <summary>
        /// 根据业务流程Guid获取有效关联表单数据(去掉已作废的表单)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Business_flow_form> GetEffectiveBusinessFlowForms(Guid businessFlowCode);

        /// <summary>
        /// 根据业务流程Guid获取所有关联表单数据(含有表单类型),只针对根级表单属性做处理
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Business_flow_form> GetBusinessFlowFormsWithFormType(Guid businessFlowCode);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.FlowManager.P_Business_flow_form model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.FlowManager.P_Business_flow_form> GetListByPage(CommonService.Model.FlowManager.P_Business_flow_form model, string orderby, int startIndex, int endIndex);

        #region App专用

        /// <summary>
        /// 根据阶段GUID获取该阶段下所有表单，不包含已作废表单
        /// </summary>
        /// <param name="guid">流程GUID</param>
        /// <returns>表单列表</returns>
        [WebInvoke(UriTemplate = "AppGetCaseStageFormInfo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CommonService.Model.FlowManager.P_Business_flow_form> AppGetCaseStageFormInfo(Guid? guid);

        #endregion
    }
}
