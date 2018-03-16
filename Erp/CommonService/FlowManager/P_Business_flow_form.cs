using ICommonService.FlowManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.FlowManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“P_Business_flow_form”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 P_Business_flow_form.svc 或 P_Business_flow_form.svc.cs，然后开始调试。
    public class P_Business_flow_form : IP_Business_flow_form
    {
        CommonService.BLL.FlowManager.P_Business_flow_form bll = new CommonService.BLL.FlowManager.P_Business_flow_form();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="P_Business_flow_form_id"></param>
        /// <returns></returns>
        public bool Exists(int P_Business_flow_form_id)
        {
            return bll.Exists(P_Business_flow_form_id);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByBusinessflowCodeAndFormCode(Guid P_Business_flow_code, Guid F_Form_code)
        {
            return bll.ExistsByBusinessflowCodeAndFormCode(P_Business_flow_code, F_Form_code);
        }

        /// <summary>
        /// 检查当前业务流程，表单是否存在重做记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns>如果存在，返回true;不存在，返回false</returns>   
        public bool ExistsRelDoneFormByBusinessflowCodeAndFormCode(Guid businessFlowCode, Guid formCode)
        {
            return bll.ExistsRelDoneFormByBusinessflowCodeAndFormCode(businessFlowCode, formCode);
        }

        /// <summary>
        /// 根据业务流程guid和表单guid，获取有效的业务流程表单关联Guid及其状态
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns>返回有效业务流程表单关联Guid</returns>
        public string GetEffectBusinessFlowFormCode(Guid businessFlowCode, Guid formCode)
        {
            return bll.GetEffectBusinessFlowFormCode(businessFlowCode, formCode);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.FlowManager.P_Business_flow_form model, int type)
        {
            return bll.Add(model, type);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.FlowManager.P_Business_flow_form model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_form_code">业务流程关联表单Guid</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow_form Get(Guid P_Business_flow_form_code)
        {
            return bll.Get(P_Business_flow_form_code);
        }

        /// <summary>
        /// 保存计划设定
        /// </summary>
        /// <param name="v_FormPlan"></param>
        /// <returns></returns>        
        public bool SavePlanSet(CommonService.Model.Customer.V_FormPlan v_FormPlan, string type)
        {
            return bll.SavePlanSet(v_FormPlan, type);
        }

        /// <summary>
        /// 得到计划设定
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>        
        public CommonService.Model.Customer.V_FormPlan GetPlanSet(Guid businessFlowCode, Guid businessFlowFormCode)
        {
            return bll.GetPlanSet(businessFlowCode, businessFlowFormCode);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="businessFlowFormCode"></param>
        /// <returns></returns>
        public bool Delete(string businessFlowFormCode, int type)
        {
            return bll.Delete(businessFlowFormCode, type);
        }

        /// <summary>
        /// 向前移动
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public bool MoveForward(Guid businessFlowCode, Guid businessFlowFormCode)
        {
            return bll.MoveForward(businessFlowCode, businessFlowFormCode);
        }

        /// <summary>
        /// 向后移动
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public bool MoveBackward(Guid businessFlowCode, Guid businessFlowFormCode)
        {
            return bll.MoveBackward(businessFlowCode, businessFlowFormCode);
        }


        /// <summary>
        /// 根据业务流程Guid获取关联所有表单数据列表
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>        
        public List<CommonService.Model.FlowManager.P_Business_flow_form> GetBusinessFlowForms(Guid businessFlowCode)
        {
            return bll.GetBusinessFlowForms(businessFlowCode);
        }

        /// <summary>
        /// 根据业务流程Guid获取有效关联表单数据(去掉已作废的表单)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> GetEffectiveBusinessFlowForms(Guid businessFlowCode)
        {
            return bll.GetEffectiveBusinessFlowForms(businessFlowCode);
        }

        /// <summary>
        /// 根据业务流程Guid获取所有关联表单数据(含有表单类型),只针对根级表单属性做处理
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>        
        public List<CommonService.Model.FlowManager.P_Business_flow_form> GetBusinessFlowFormsWithFormType(Guid businessFlowCode)
        {
            return bll.GetBusinessFlowFormsWithFormType(businessFlowCode);
        }

        /// <summary>
        /// 获取记录总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.FlowManager.P_Business_flow_form model)
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
        public List<Model.FlowManager.P_Business_flow_form> GetListByPage(Model.FlowManager.P_Business_flow_form model, string orderby, int startIndex, int endIndex)
        {
            return bll.GetListByPage(model, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 查看配置的表单是否可以删除
        /// </summary>
        /// <param name="P_Business_flow_form_code">业务流程关联表单Guid集合</param>
        /// <returns></returns>
        public bool GetisNoDefault(string P_Business_flow_form_codes)
        {
            return bll.GetisNoDefault(P_Business_flow_form_codes);
        }
        /// <summary>
        /// 批量保存计划设定
        /// </summary>
        /// <param name="v_FormPlan"></param>
        /// <returns></returns>
        public bool OperateSavePlanSet(Model.Customer.V_FormPlan v_FormPlan, string type)
        {
            return bll.OperateSavePlanSet(v_FormPlan, type);
        }

        #region App专用

        /// <summary>
        /// 根据阶段GUID获取该阶段下所有表单，不包含已作废表单
        /// </summary>
        /// <param name="guid">流程GUID</param>
        /// <returns>表单列表</returns>
        public List<Model.FlowManager.P_Business_flow_form> AppGetCaseStageFormInfo(Guid? guid)
        {
            return bll.GetEffectiveBusinessFlowForms(guid.Value);
        }

        #endregion
    }

}
