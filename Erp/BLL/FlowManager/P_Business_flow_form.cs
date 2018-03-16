using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Maticsoft.Common;
using CommonService.Model;
using CommonService.Common;
using System.Collections;
namespace CommonService.BLL.FlowManager
{
    /// <summary>
    /// 业务流程----表单中间表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/13
    /// </summary>
    public partial class P_Business_flow_form
    {
        #region .......
        /// <summary>
        /// 业务流程-表单-用户关联表业务访问类
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow_form_user businessFlowFormUserBLL = new CommonService.BLL.FlowManager.P_Business_flow_form_user();
        /// <summary>
        /// 表单属性值业务访问层
        /// </summary>
        private readonly CommonService.BLL.CustomerForm.F_FormPropertyValue formPropertyValueBll = new CommonService.BLL.CustomerForm.F_FormPropertyValue();
        private readonly CommonService.DAL.FlowManager.P_Business_flow_form dal = new CommonService.DAL.FlowManager.P_Business_flow_form();
        /// <summary>
        /// 业务流程-表单-用户数据访问类
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow_form_user businessFlowFormUserDAL = new CommonService.DAL.FlowManager.P_Business_flow_form_user();
        /// <summary>
        /// 业务流程数据访问类
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow businessFlowDAL = new CommonService.DAL.FlowManager.P_Business_flow();
        /// <summary>
        /// 表单属性数据访问类
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_FormProperty formPropertyDAL = new CommonService.DAL.CustomerForm.F_FormProperty();
        /// <summary>
        /// 用户数据访问层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_Userinfo userinfoDAL = new DAL.SysManager.C_Userinfo();
        /// <summary>
        /// 消息数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();
        /// <summary>
        /// 客户数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Customer customerDAL = new CommonService.DAL.C_Customer();
        /// <summary>
        /// 商机数据访问层
        /// </summary>
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance businessChanceDAL = new DAL.BusinessChanceManager.B_BusinessChance();
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance_link bclDal = new CommonService.DAL.BusinessChanceManager.B_BusinessChance_link();
        #endregion

        public P_Business_flow_form()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int P_Business_flow_form_id)
        {
            return dal.Exists(P_Business_flow_form_id);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByBusinessflowCodeAndFormCode(Guid P_Business_flow_code, Guid F_Form_code)
        {
            return dal.ExistsByBusinessflowCodeAndFormCode(P_Business_flow_code, F_Form_code);
        }

        /// <summary>
        /// 检查当前业务流程，表单是否存在重做记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns>如果存在，返回true;不存在，返回false</returns>   
        public bool ExistsRelDoneFormByBusinessflowCodeAndFormCode(Guid businessFlowCode, Guid formCode)
        {
            return dal.ExistsRelDoneFormByBusinessflowCodeAndFormCode(businessFlowCode, formCode);
        }

        /// <summary>
        /// 根据业务流程guid和表单guid，获取有效的业务流程表单关联Guid及其状态
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns>返回有效业务流程表单关联Guid</returns>       
        public string GetEffectBusinessFlowFormCode(Guid businessFlowCode, Guid formCode)
        {
            return dal.GetEffectBusinessFlowFormCode(businessFlowCode, formCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.FlowManager.P_Business_flow_form model, int type)
        {
            /*
             * hety,2015-05-25,新增时需要处理排序列字段,并且初始化表单属性值，并且生成条目统计信息
             ***/
            //初始化默认表单属性值
            formPropertyValueBll.InitializationFormPropertyValue(model.F_Form_code.Value, model.P_Business_flow_form_code.Value, model.P_Business_flow_form_creator.Value);

            CommonService.Model.FlowManager.P_Business_flow businessFlow = businessFlowDAL.GetModel(model.P_Business_flow_code.Value);

            //设置表单计划开始时间、计划结束时间为对应业务流程的计划开始时间和计划结束时间
            #region(2)、
            //处理"计划开始时间"属性           
            if (businessFlow.P_Business_flow_planStartTime != null)
            {

                CommonService.Model.CustomerForm.F_FormProperty planStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(model.F_Form_code.Value, "planStartTime");
                if (planStartTimeFormProperty != null)
                {
                    formPropertyValueBll.Update(model.F_Form_code.Value, model.P_Business_flow_form_code.Value, planStartTimeFormProperty.F_FormProperty_code.Value, businessFlow.P_Business_flow_planStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                }
            }
            //处理"计划结束时间"属性实体
            if (businessFlow.P_Business_flow_planEndTime != null)
            {
                CommonService.Model.CustomerForm.F_FormProperty planEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(model.F_Form_code.Value, "planEndTime");
                if (planEndTimeFormProperty != null)
                {
                    formPropertyValueBll.Update(model.F_Form_code.Value, model.P_Business_flow_form_code.Value, planEndTimeFormProperty.F_FormProperty_code.Value, businessFlow.P_Business_flow_planEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                }
            }
            #endregion

            CommonService.Model.FlowManager.P_Business_flow_form maxOrderBusinessFlowForm = dal.GetMaxOrderModel(model.P_Business_flow_code.Value);
            int order = 1;
            if (maxOrderBusinessFlowForm != null)
            {
                order = maxOrderBusinessFlowForm.P_Business_flow_form_order.Value + 1;
            }
            model.P_Business_flow_form_order = order;

            if (type == 1)
            {//案件
                //案件表单默认负责人为流程的负责人
                model.P_Business_flow_form_person = businessFlow.P_Business_person;
                //生成条目统计信息(起点流程+起点表单)
                dal.GenerateEntryStatisticsByAddForm(businessFlow.P_Fk_code.Value, Convert.ToInt32(FlowTypeEnum.案件), businessFlow.P_Flow_code.Value, model.F_Form_code.Value, model.P_Business_flow_form_creator.Value);
            }
            else if (type == 2)
            {//商机
                //商机表单默认负责人为商机的专业顾问
                string consultantCodeStr = "";
                string consultantNameStr = "";
                List<Model.BusinessChanceManager.B_BusinessChance_link> Consultants = bclDal.GetConsultantListByBusinessChancecode(businessFlow.P_Fk_code.Value);
                foreach (var consultant in Consultants)
                {
                    if (consultant.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.销售顾问))
                    {//销售顾问
                        consultantCodeStr += consultant.C_FK_code.ToString() + ',';
                        consultantNameStr += consultant.C_Userinfo_name + ',';
                    }
                }
                string[] businessChance_consultantCodes = consultantCodeStr == "" ? null : consultantCodeStr.Split(',');
                model.P_Business_flow_form_person = new Guid(businessChance_consultantCodes[0]);
            }
            else if (type == 3)
            {//客户
                //客户表单默认负责人为客户的专业顾问
                CommonService.Model.C_Customer customer = customerDAL.GetModel(businessFlow.P_Fk_code.Value);
                if (customer != null && customer.C_Customer_consultant != null)
                {
                    model.P_Business_flow_form_person = customer.C_Customer_consultant;
                }
            }

            if (businessFlow.P_Business_state == Convert.ToInt32(BusinessFlowStatus.正在进行)) //如果流程状态是正在进行，表单的状态也设置为正在进行
            {
                model.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
            }
            int result = dal.Add(model);

            #region 如果流程状态为正在进行，则表单应该给出实际开始时间 张东洋 2015/9/3
            if (businessFlow.P_Business_state == Convert.ToInt32(BusinessFlowStatus.正在进行))
            {
                DateTime now = DateTime.Now;
                //处理"计划开始时间"属性           
                if (businessFlow.P_Business_flow_planStartTime != null)
                {

                    CommonService.Model.CustomerForm.F_FormProperty planStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(model.F_Form_code.Value, "planStartTime");
                    if (planStartTimeFormProperty != null)
                    {
                        formPropertyValueBll.Update(model.F_Form_code.Value, model.P_Business_flow_form_code.Value, planStartTimeFormProperty.F_FormProperty_code.Value, now.ToString("yyyy-MM-dd HH:mm:ss"));
                        if (type == 1)
                        {
                            dal.UpdateEntryStatisticsByFormTime(model.P_Business_flow_form_code.Value, "planStartTime", businessFlow.P_Business_flow_planStartTime.Value);
                            MSMQ.SendMessage();
                        }
                    }
                }
                //处理"计划结束时间"属性实体
                if (businessFlow.P_Business_flow_planEndTime != null)
                {
                    CommonService.Model.CustomerForm.F_FormProperty planEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(model.F_Form_code.Value, "planEndTime");
                    if (planEndTimeFormProperty != null)
                    {
                        formPropertyValueBll.Update(model.F_Form_code.Value, model.P_Business_flow_form_code.Value, planEndTimeFormProperty.F_FormProperty_code.Value, businessFlow.P_Business_flow_planEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        if (type == 1)
                        {
                            dal.UpdateEntryStatisticsByFormTime(model.P_Business_flow_form_code.Value, "planEndTime", businessFlow.P_Business_flow_planEndTime.Value);
                            MSMQ.SendMessage();
                        }
                    }
                }

                //实际开始时间为当前时间
                CommonService.Model.CustomerForm.F_FormProperty factStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(model.F_Form_code.Value, "factStartTime");
                if (factStartTimeFormProperty != null)
                {

                    formPropertyValueBll.Update(model.F_Form_code.Value, model.P_Business_flow_form_code.Value, factStartTimeFormProperty.F_FormProperty_code.Value, now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (type == 1)
                    {
                        dal.UpdateEntryStatisticsByFormTime(model.P_Business_flow_form_code.Value, "factStartTime", now);
                        MSMQ.SendMessage();
                    }
                }

                //此处不确定是否给默认负责人发消息，分配了表单之后，会有默认负责（暂时发消息，如需修改，就在此处修改）
                CommonService.Model.C_Messages message = new Model.C_Messages();
                if (type == 1)
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                else if (type == 2)
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                else if (type == 3)
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                message.C_Messages_link = businessFlow.P_Fk_code;
                message.C_Messages_createTime = DateTime.Now;
                message.C_Messages_person = model.P_Business_flow_form_person;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
            }
            #endregion
            return result;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.FlowManager.P_Business_flow_form model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新数据排列顺序
        /// </summary>
        /// <returns></returns>
        public bool UpdateOrder(Guid guid,int order)
        {
            return dal.UpdateOrder(guid, order);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="P_Business_flow_form_code">业务流程关联表单Guid</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow_form Get(Guid P_Business_flow_form_code)
        {
            return dal.GetModel(P_Business_flow_form_code);
        }
        /// <summary>
        /// 查看配置的表单是否可以删除
        /// </summary>
        /// <param name="P_Business_flow_form_code">业务流程关联表单Guid集合</param>
        /// <returns></returns>
        public bool GetisNoDefault(string P_Business_flow_form_codes)
        {
            int flag = 0;
            string[] codes = P_Business_flow_form_codes.Split(',');
            foreach (var item in codes)
            {
                CommonService.Model.FlowManager.P_Business_flow_form model = dal.GetModel(new Guid(item.ToString()));
                if (model.P_Business_flow_form_isDefault == 1)
                    flag++;
            }
            if (flag > 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 保存计划设定
        /// </summary>
        /// <param name="v_FormPlan"></param>
        /// <returns></returns>        
        public bool SavePlanSet(CommonService.Model.Customer.V_FormPlan v_FormPlan, string type)
        {
            /**
             * Author:hety
             * Date:2015-05-28
             * Description:
             * (1)、需要更新"任务要求"值到业务流程表中
             * (2)、需要更新"计划开始时间"和"计划结束时间"值到表单属性值表中,并且更新当前表单所关联条目统计信息的时间值
             * (3)、需要更新"主办律师"值到业务流程表单关联表中
             * (4)、协办律师数据插入,只有增加和删除逻辑
             * (5)、更改计划设定状态为true
             ***/

            //(1)、
            businessFlowDAL.UpdateRequire(v_FormPlan.BusinessFlowCode.Value, v_FormPlan.Require);
            //得到业务流程表单关联实体
            CommonService.Model.FlowManager.P_Business_flow_form BusinessFlowForm = dal.GetModel(v_FormPlan.BusinessFlowFormCode.Value);

            CommonService.Model.FlowManager.P_Business_flow business_flow = businessFlowDAL.GetModel(v_FormPlan.BusinessFlowCode.Value);
            #region(2)、
            //处理"计划开始时间"属性           
            if (v_FormPlan.PlanStartTime != null)
            {
                CommonService.Model.CustomerForm.F_FormProperty planStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(BusinessFlowForm.F_Form_code.Value, "planStartTime");
                if (planStartTimeFormProperty != null)
                {
                    formPropertyValueBll.Update(BusinessFlowForm.F_Form_code.Value, v_FormPlan.BusinessFlowFormCode.Value, planStartTimeFormProperty.F_FormProperty_code.Value, v_FormPlan.PlanStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (type == "1")
                    {
                        dal.UpdateEntryStatisticsByFormTime(v_FormPlan.BusinessFlowFormCode.Value, "planStartTime", v_FormPlan.PlanStartTime.Value);
                        MSMQ.SendMessage();
                    }
                }
            }
            //处理"计划结束时间"属性实体
            if (v_FormPlan.PlanEndTime != null)
            {
                CommonService.Model.CustomerForm.F_FormProperty planEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(BusinessFlowForm.F_Form_code.Value, "planEndTime");
                if (planEndTimeFormProperty != null)
                {
                    formPropertyValueBll.Update(BusinessFlowForm.F_Form_code.Value, v_FormPlan.BusinessFlowFormCode.Value, planEndTimeFormProperty.F_FormProperty_code.Value, v_FormPlan.PlanEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (type == "1")
                    {
                        dal.UpdateEntryStatisticsByFormTime(v_FormPlan.BusinessFlowFormCode.Value, "planEndTime", v_FormPlan.PlanEndTime.Value);
                        MSMQ.SendMessage();
                    }
                }
            }
            #endregion
            //(3)、
            dal.UpdatePerson(v_FormPlan.BusinessFlowFormCode.Value, v_FormPlan.MainLawyerCode.Value);
            #region(4)、
            if (String.IsNullOrEmpty(v_FormPlan.AssistLawyerCodes))
            {//直接删除业务流程表单关联的所有用户
                businessFlowFormUserDAL.DeleteByBusinessFlowFormCode(v_FormPlan.BusinessFlowFormCode.Value);
            }
            else
            {
                //获取业务流程表单用户已关联集合数据
                List<CommonService.Model.FlowManager.P_Business_flow_form_user> BusinessFlowFormUsers = businessFlowFormUserBLL.GetListByBusinessFlowFormCode(v_FormPlan.BusinessFlowFormCode.Value);
                string[] assistLawyers = v_FormPlan.AssistLawyerCodes.ToString().Split(',');
                #region 处理新增的
                for (int i = 0; i < assistLawyers.Length; i++)
                {
                    var existsBusinessFlowFormUsers = from allList in BusinessFlowFormUsers
                                                      where allList.P_Business_flow_form_user_user.Value.ToString() == assistLawyers[i]
                                                      select allList;
                    if (existsBusinessFlowFormUsers.Count() == 0)
                    {
                        //增加
                        CommonService.Model.FlowManager.P_Business_flow_form_user business_flow_form_user = new Model.FlowManager.P_Business_flow_form_user();
                        business_flow_form_user.P_Business_flow_form_user_code = Guid.NewGuid();
                        business_flow_form_user.P_Business_flow_form_code = v_FormPlan.BusinessFlowFormCode;
                        business_flow_form_user.P_Business_flow_form_user_isdelete = false;
                        business_flow_form_user.P_Business_flow_form_user_user = new Guid(assistLawyers[i]);
                        business_flow_form_user.P_Business_flow_form_user_creator = v_FormPlan.Creator;
                        business_flow_form_user.P_Business_flow_form_user_createTime = DateTime.Now;

                        businessFlowFormUserDAL.Add(business_flow_form_user);
                    }
                }
                #endregion
                #region 处理删除的
                foreach (CommonService.Model.FlowManager.P_Business_flow_form_user busFlowFormUser in BusinessFlowFormUsers)
                {
                    bool isExists = false;
                    for (int i = 0; i < assistLawyers.Length; i++)
                    {
                        if (busFlowFormUser.P_Business_flow_form_user_user.Value.ToString() == assistLawyers[i])
                        {
                            isExists = true;
                            break;
                        }
                    }
                    if (!isExists)
                    {
                        businessFlowFormUserDAL.Delete(busFlowFormUser.P_Business_flow_form_user_code.Value);
                    }
                }
                #endregion
            }

            #endregion

            #region 修改表单主办律师，当表单已经启动，给修改后的主办律师发送消息

            if (!BusinessFlowForm.P_Business_flow_form_person.ToString().Equals(v_FormPlan.MainLawyerCode.ToString()))
            {
                if (BusinessFlowForm.P_Business_flow_form_state == Convert.ToInt32(BusinessFlowStatus.正在进行))
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    if (type == "1")
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    else if (type == "2")
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    else if (type == "3")
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                    message.C_Messages_link = business_flow.P_Fk_code;
                    message.C_Messages_createTime = DateTime.Now;
                    message.C_Messages_person = v_FormPlan.MainLawyerCode;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;
                    messageDAL.Add(message);
                }
            }

            #endregion

            #region(5)
            dal.UpdateIsPlan(v_FormPlan.BusinessFlowFormCode.Value, true);
            #endregion

            return true;
        }

        /// <summary>
        /// 得到计划设定
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>           
        public CommonService.Model.Customer.V_FormPlan GetPlanSet(Guid businessFlowCode, Guid businessFlowFormCode)
        {
            string userinfoCodes = "";
            string userinfoNames = "";
            CommonService.Model.Customer.V_FormPlan v_FormPlan = new Model.Customer.V_FormPlan();
            CommonService.Model.FlowManager.P_Business_flow_form business_flow_form = dal.GetPersonModelByCode(businessFlowFormCode);
            List<CommonService.Model.FlowManager.P_Business_flow_form_user> business_flow_form_users = businessFlowFormUserBLL.GetListByBusinessFlowFormCode(businessFlowFormCode);
            foreach (var business_flow_form_user in business_flow_form_users)
            {
                CommonService.Model.SysManager.C_Userinfo userinfo = userinfoDAL.GetModelByCode(business_flow_form_user.P_Business_flow_form_user_user.Value);
                userinfoCodes += userinfo.C_Userinfo_code + ",";
                userinfoNames += userinfo.C_Userinfo_name + ",";
            }
            v_FormPlan.BusinessFlowCode = businessFlowCode;
            v_FormPlan.BusinessFlowFormCode = businessFlowFormCode;
            v_FormPlan.MainLawyerCode = business_flow_form.P_Business_flow_form_person;
            v_FormPlan.MainLawyerName = business_flow_form.P_Business_flow_form_person_name;
            v_FormPlan.AssistLawyerCodes = userinfoCodes == "" ? userinfoCodes : userinfoCodes.Substring(0, userinfoCodes.Length - 1);
            v_FormPlan.AssistLawyerNames = userinfoNames == "" ? userinfoNames : userinfoNames.Substring(0, userinfoNames.Length - 1);
            v_FormPlan.Require = businessFlowDAL.GetModel(businessFlowCode).P_Business_flow_require;

            #region 计划时间属性赋值
            CommonService.Model.CustomerForm.F_FormProperty planStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(business_flow_form.F_Form_code.Value, "planStartTime");
            if (planStartTimeFormProperty != null)
            {
                CommonService.Model.CustomerForm.F_FormPropertyValue planStartTimeFormPropertyValue = new Model.CustomerForm.F_FormPropertyValue();
                planStartTimeFormPropertyValue = formPropertyValueBll.GetModel(business_flow_form.F_Form_code.Value, businessFlowFormCode, planStartTimeFormProperty.F_FormProperty_code.Value);
                if (planStartTimeFormPropertyValue != null && planStartTimeFormPropertyValue.F_FormPropertyValue_value != "")
                {
                    v_FormPlan.PlanStartTime = DateTime.Parse(planStartTimeFormPropertyValue.F_FormPropertyValue_value);
                }
            }


            CommonService.Model.CustomerForm.F_FormProperty planEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(business_flow_form.F_Form_code.Value, "planEndTime");
            if (planEndTimeFormProperty != null)
            {
                CommonService.Model.CustomerForm.F_FormPropertyValue planEndTimeFormPropertyValue = new Model.CustomerForm.F_FormPropertyValue();
                planEndTimeFormPropertyValue = formPropertyValueBll.GetModel(business_flow_form.F_Form_code.Value, businessFlowFormCode, planEndTimeFormProperty.F_FormProperty_code.Value);
                if (planEndTimeFormPropertyValue != null && planEndTimeFormPropertyValue.F_FormPropertyValue_value != "")
                {
                    v_FormPlan.PlanEndTime = DateTime.Parse(planEndTimeFormPropertyValue.F_FormPropertyValue_value);
                }
            }
            #endregion

            return v_FormPlan;
        }

        /// <summary>
        /// 批量保存计划设定
        /// </summary>
        /// <param name="v_FormPlan"></param>
        /// <returns></returns>
        public bool OperateSavePlanSet(Model.Customer.V_FormPlan v_FormPlan, string type)
        {
            ArrayList businessFlowFormRepins = new ArrayList();//表单主办律师集合
            //(1)、
            businessFlowDAL.UpdateRequire(v_FormPlan.BusinessFlowCode.Value, v_FormPlan.Require);
            string[] businessFlowFormCodes = v_FormPlan.MulityBusinessFlowFormCode.Split(',');
            foreach (var businessFlowFormCode in businessFlowFormCodes)
            {
                //得到业务流程表单关联实体
                CommonService.Model.FlowManager.P_Business_flow_form BusinessFlowForm = dal.GetModel(new Guid(businessFlowFormCode));

                CommonService.Model.FlowManager.P_Business_flow business_flow = businessFlowDAL.GetModel(v_FormPlan.BusinessFlowCode.Value);
                #region(2)、
                //处理"计划开始时间"属性           
                if (v_FormPlan.PlanStartTime != null)
                {
                    CommonService.Model.CustomerForm.F_FormProperty planStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(BusinessFlowForm.F_Form_code.Value, "planStartTime");
                    if (planStartTimeFormProperty != null)
                    {
                        formPropertyValueBll.Update(BusinessFlowForm.F_Form_code.Value, new Guid(businessFlowFormCode), planStartTimeFormProperty.F_FormProperty_code.Value, v_FormPlan.PlanStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        dal.UpdateEntryStatisticsByFormTime(new Guid(businessFlowFormCode), "planStartTime", v_FormPlan.PlanStartTime.Value);
                        MSMQ.SendMessage();
                    }
                }
                //处理"计划结束时间"属性实体
                if (v_FormPlan.PlanEndTime != null)
                {
                    CommonService.Model.CustomerForm.F_FormProperty planEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(BusinessFlowForm.F_Form_code.Value, "planEndTime");
                    if (planEndTimeFormProperty != null)
                    {
                        formPropertyValueBll.Update(BusinessFlowForm.F_Form_code.Value, new Guid(businessFlowFormCode), planEndTimeFormProperty.F_FormProperty_code.Value, v_FormPlan.PlanEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        dal.UpdateEntryStatisticsByFormTime(new Guid(businessFlowFormCode), "planEndTime", v_FormPlan.PlanEndTime.Value);
                        MSMQ.SendMessage();
                    }
                }
                #endregion
                //(3)、
                dal.UpdatePerson(new Guid(businessFlowFormCode), v_FormPlan.MainLawyerCode.Value);
                #region(4)、
                if (String.IsNullOrEmpty(v_FormPlan.AssistLawyerCodes))
                {//直接删除业务流程表单关联的所有用户
                    businessFlowFormUserDAL.DeleteByBusinessFlowFormCode(new Guid(businessFlowFormCode));
                }
                else
                {
                    //获取业务流程表单用户已关联集合数据
                    List<CommonService.Model.FlowManager.P_Business_flow_form_user> BusinessFlowFormUsers = businessFlowFormUserBLL.GetListByBusinessFlowFormCode(new Guid(businessFlowFormCode));
                    string[] assistLawyers = v_FormPlan.AssistLawyerCodes.ToString().Split(',');
                    #region 处理新增的
                    for (int i = 0; i < assistLawyers.Length; i++)
                    {
                        var existsBusinessFlowFormUsers = from allList in BusinessFlowFormUsers
                                                          where allList.P_Business_flow_form_user_user.Value.ToString() == assistLawyers[i]
                                                          select allList;
                        if (existsBusinessFlowFormUsers.Count() == 0)
                        {
                            //增加
                            CommonService.Model.FlowManager.P_Business_flow_form_user business_flow_form_user = new Model.FlowManager.P_Business_flow_form_user();
                            business_flow_form_user.P_Business_flow_form_user_code = Guid.NewGuid();
                            business_flow_form_user.P_Business_flow_form_code = new Guid(businessFlowFormCode);
                            business_flow_form_user.P_Business_flow_form_user_isdelete = false;
                            business_flow_form_user.P_Business_flow_form_user_user = new Guid(assistLawyers[i]);
                            business_flow_form_user.P_Business_flow_form_user_creator = v_FormPlan.Creator;
                            business_flow_form_user.P_Business_flow_form_user_createTime = DateTime.Now;

                            businessFlowFormUserDAL.Add(business_flow_form_user);
                        }
                    }
                    #endregion
                    #region 处理删除的
                    foreach (CommonService.Model.FlowManager.P_Business_flow_form_user busFlowFormUser in BusinessFlowFormUsers)
                    {
                        bool isExists = false;
                        for (int i = 0; i < assistLawyers.Length; i++)
                        {
                            if (busFlowFormUser.P_Business_flow_form_user_user.Value.ToString() == assistLawyers[i])
                            {
                                isExists = true;
                                break;
                            }
                        }
                        if (!isExists)
                        {
                            businessFlowFormUserDAL.Delete(busFlowFormUser.P_Business_flow_form_user_code.Value);
                        }
                    }
                    #endregion
                }
                #endregion

                #region 修改表单主办律师，当表单已经启动，给修改后的主办律师发送消息

                if (!BusinessFlowForm.P_Business_flow_form_person.ToString().Equals(v_FormPlan.MainLawyerCode.ToString()))
                {
                    if (BusinessFlowForm.P_Business_flow_form_state == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        if (!businessFlowFormRepins.Contains(BusinessFlowForm.P_Business_flow_form_person.ToString()))
                        {//处理修改表单主办律师时，如果表单主办律师出现重复的情况，只需要发一条消息
                            businessFlowFormRepins.Add(BusinessFlowForm.P_Business_flow_form_person.ToString());

                            CommonService.Model.C_Messages message = new Model.C_Messages();
                            message.C_Messages_fType = Convert.ToInt32(type) == 1 ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                            message.C_Messages_link = business_flow.P_Fk_code;
                            message.C_Messages_createTime = DateTime.Now;
                            message.C_Messages_person = v_FormPlan.MainLawyerCode;
                            message.C_Messages_isRead = 0;
                            message.C_Messages_content = "";
                            message.C_Messages_isValidate = 1;

                            messageDAL.Add(message);
                        }
                    }
                }

                #endregion

                #region(5)
                dal.UpdateIsPlan(new Guid(businessFlowFormCode), true);
                #endregion
            }

            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="businessFlowFormCode"></param>
        /// <param name="type">调用此Action来源类型：1为案件；2为商机；3为客户</param>
        /// <returns></returns>
        public bool Delete(string businessFlowFormCode, int type)
        {
            /*
             * Author:hety
             * Date:2015-05-28
             * Description:删除业务流程关联表单数据时，要把业务流程关联表单用户数据以及业务流程关联表单属性值数据都删除掉,并且删除关联条目统计信息
             * */
            string[] businessFlowFormCodes = businessFlowFormCode.Split(',');
            foreach (var businessFlowForm_Code in businessFlowFormCodes)
            {
                //删除业务流程关联表单用户
                businessFlowFormUserDAL.DeleteByBusinessFlowFormCode(new Guid(businessFlowForm_Code));
                //删除关联表单属性值
                CommonService.Model.FlowManager.P_Business_flow_form BusinessFlowForm = dal.GetModel(new Guid(businessFlowForm_Code));
                formPropertyValueBll.Delete(BusinessFlowForm.F_Form_code.Value, new Guid(businessFlowForm_Code));

                //删除条目统计信息(只针对案件)
                if (type == 1)
                {
                    dal.DeleteEntryStatisticsByBusinessFlowFormCode(new Guid(businessFlowForm_Code));
                }

                dal.Delete(new Guid(businessFlowForm_Code));
            }


            return true;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string P_Business_flow_form_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(P_Business_flow_form_idlist, 0));
        }
        /// <summary>
        /// 根据业务流程Guid删除数据
        /// </summary>
        /// <param name="businessCode">业务流程Guid</param>
        /// <returns></returns>
        public bool DeleteByBusinessFlowCode(Guid businessFlowCode)
        {
            return dal.DeleteByBusinessFlowCode(businessFlowCode);
        }

        /// <summary>
        /// 向前移动
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public bool MoveForward(Guid businessFlowCode, Guid businessFlowFormCode)
        {
            /**
             **作者：贺太玉
             **2015/05/25
             **业务说明：1,先获的当前业务流程关联表单的显示顺序号；2,获取向前移动一个顺序单位的业务流程关联表单对象；3,当前需要移动的业务流程关联表单与向前一个单位的业务流程关联表单交互顺序号；4,如果已经移动到第一位，则不可以再继续
             *移动；4,显示属性顺序号不可以重复
             **/
            CommonService.Model.FlowManager.P_Business_flow_form thisBusinessFlowForm = dal.GetModel(businessFlowFormCode);
            CommonService.Model.FlowManager.P_Business_flow_form forwardBusinessFlowForm = dal.GetModel(businessFlowCode, ConditonType.小于, thisBusinessFlowForm.P_Business_flow_form_order.Value);
            if (forwardBusinessFlowForm != null)
            {
                int thisBusinessFlowFormOrderBy = thisBusinessFlowForm.P_Business_flow_form_order.Value;
                int forwardBusinessFlowFormOrderBy = forwardBusinessFlowForm.P_Business_flow_form_order.Value;
                thisBusinessFlowForm.P_Business_flow_form_order = forwardBusinessFlowFormOrderBy;
                dal.Update(thisBusinessFlowForm);
                forwardBusinessFlowForm.P_Business_flow_form_order = thisBusinessFlowFormOrderBy;
                dal.Update(forwardBusinessFlowForm);
            }
            return true;
        }

        /// <summary>
        /// 向后移动
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public bool MoveBackward(Guid businessFlowCode, Guid businessFlowFormCode)
        {
            /**
             **作者：贺太玉
             **2015/05/25
             **业务说明：1,先获的当前业务流程关联表单的显示顺序号；2,获取向后移动一个顺序单位的业务流程关联表单对象；3,当前需要移动的业务流程关联表单与向后一个业务流程关联表单的顺序号交互顺序号；4,如果已经移动到最后一位，则不可以再继续
             *移动；4,显示业务流程关联表单顺序号不可以重复
            **/
            CommonService.Model.FlowManager.P_Business_flow_form thisBusinessFlowForm = dal.GetModel(businessFlowFormCode);
            CommonService.Model.FlowManager.P_Business_flow_form backwardBusinessFlowForm = dal.GetModel(businessFlowCode, ConditonType.大于, thisBusinessFlowForm.P_Business_flow_form_order.Value);
            if (backwardBusinessFlowForm != null)
            {
                int thisBusinessFlowFormOrderBy = thisBusinessFlowForm.P_Business_flow_form_order.Value;
                int backwardBusinessFlowFormOrderBy = backwardBusinessFlowForm.P_Business_flow_form_order.Value;
                thisBusinessFlowForm.P_Business_flow_form_order = backwardBusinessFlowFormOrderBy;
                dal.Update(thisBusinessFlowForm);
                backwardBusinessFlowForm.P_Business_flow_form_order = thisBusinessFlowFormOrderBy;
                dal.Update(backwardBusinessFlowForm);
            }
            return true;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> GetListByPerson(Guid P_Business_flow_form_person)
        {
            return DataTableToList(dal.GetListByPerson(P_Business_flow_form_person).Tables[0]);
        }
         /// <summary>
        /// 根据负责人获得数据列表(关联业务流程状态为“未开始”和“正在进行”)
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> GetListByPersonAndBusinessFlowState(Guid P_Business_flow_form_person)
        {
            return DataTableToList(dal.GetListByPersonAndBusinessFlowState(P_Business_flow_form_person).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_form> modelList = new List<CommonService.Model.FlowManager.P_Business_flow_form>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.FlowManager.P_Business_flow_form model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        /// <summary>
        /// 根据业务流程Guid获取关联所有表单数据
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> GetBusinessFlowForms(Guid businessFlowCode)
        {
            return DataTableToList(dal.GetBusinessFlowForms(businessFlowCode).Tables[0]);
        }

        /// <summary>
        /// 根据业务流程Guid获取有效关联表单数据(去掉已作废的表单)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> GetEffectiveBusinessFlowForms(Guid businessFlowCode)
        {
            return DataTableToList(dal.GetEffectiveBusinessFlowForms(businessFlowCode).Tables[0]);
        }

        /// <summary>
        /// 根据业务流程Guid获取所有关联表单数据(含有表单类型),只针对根级表单属性做处理
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> GetBusinessFlowFormsWithFormType(Guid businessFlowCode)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_form> BusinessFlowForms = DataTableToList(dal.GetBusinessFlowFormsWithFormType(businessFlowCode).Tables[0]);
            /*
             * author:hety
             * date:2015-06-04
             * description:如果表单属性UI类型为"Tab容器"的情况，需要再次获取此表单属性的Guid
             * 
             * */
            foreach (var item in BusinessFlowForms)
            {
                if (item.P_Business_flow_form_type.Value == 2)
                {
                    CommonService.Model.CustomerForm.F_FormProperty formProperty = formPropertyDAL.GetModel(item.F_Form_code.Value, Guid.Empty, Convert.ToInt32(UiControlType.Tab容器));
                    if (formProperty != null)
                    {
                        item.P_Business_flow_form_propertyCode = formProperty.F_FormProperty_code;
                    }

                }
            }
            return BusinessFlowForms;
        }


        /// <summary>
        /// 根据业务流程Guid获取关联所有表单数据(仅为业务流程关联表单表)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> OnlyGetBusinessFlowForms(Guid businessFlowCode)
        {
            return DataTableToList(dal.OnlyGetBusinessFlowForms(businessFlowCode).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.FlowManager.P_Business_flow_form model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> GetListByPage(CommonService.Model.FlowManager.P_Business_flow_form model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod



        internal string GetCoNames(Guid businessFlowCode)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_form> list = GetBusinessFlowForms(businessFlowCode);
            string names = ",";
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (!names.Contains("," + item.P_Business_flow_form_person_name + ","))
                        names = names + item.P_Business_flow_form_person_name + ",";
                }
            }
            if (names == ",") return "";
            else
                return names;


        }
        /// <summary>
        /// 根据业务流程guid和表单guid，获取有效的业务流程表单关联其状态
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns>返回有效业务流程表单关联Guid</returns>   
        internal string GetEffectBusinessFlowFormCodeStatus(Guid businessFlowCode, Guid formCode)
        {
            return dal.GetEffectBusinessFlowFormCodeStatus(businessFlowCode, formCode);
        }
        /// <summary>
        /// 根据阶段GUID获取该阶段下所有表单，不包含已作废表单
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> erpGetCaseStageFormInfo(string guid)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_form> list = DataTableToList(dal.GetEffectiveBusinessFlowForms(new Guid(guid)).Tables[0]);
            foreach (var item in list)
            {
                item.Isvalidate = erpIsValidate(item);
            }
            return list;
        }

        /// <summary>
        /// 表单值中是否包含必填项未填写的
        /// </summary>
        /// <param name="form">业务流程表单实体</param>
        /// <returns>是否通过</returns>
        public bool erpIsValidate(CommonService.Model.FlowManager.P_Business_flow_form form)
        {
            BLL.CustomerForm.F_FormProperty propertyBLL = new CustomerForm.F_FormProperty();
            List<CommonService.Model.CustomerForm.F_FormProperty> list = propertyBLL.GetValuesByBusinessFormCode(form.P_Business_flow_form_code);
            List<CommonService.Model.CustomerForm.F_FormProperty> newList = list.Where(p => p.F_FormProperty_isRequire == true && 
                                                                    (string.IsNullOrEmpty(p.V_FormPropertyValue_Value) == true) && 
                                                                    p.F_FormProperty_uiType != 207 &&
                                                                    (p.F_FormProperty_code.Value.ToString() != "28105e12-c30c-4128-9076-622677affe9f" && //预期收益计算-专业顾问审核意见
                                                                     p.F_FormProperty_code.Value.ToString() != "ab21dc0e-5ad0-4959-9410-611dde6a7d99" && //预期收益计算-专业顾问审核时间
                                                                     p.F_FormProperty_code.Value.ToString() != "9367c08b-bbe0-4bca-ae6a-82123419e9ae")//预期收益计算-审核时间
                                                                    ).ToList();
            if (newList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #region App专用
        /// <summary>
        /// 根据阶段GUID获取该阶段下所有表单，不包含已作废表单
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow_form> AppGetCaseStageFormInfo(string guid)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_form> list = DataTableToList(dal.GetEffectiveBusinessFlowForms(new Guid(guid)).Tables[0]);
            foreach (var item in list)
            {
                item.Isvalidate = IsValidate(item);
            }
            return list;
        }

        /// <summary>
        /// 表单值中是否包含必填项未填写的
        /// </summary>
        /// <param name="form">业务流程表单实体</param>
        /// <returns>是否通过</returns>
        public bool IsValidate(CommonService.Model.FlowManager.P_Business_flow_form form)
        {
            BLL.CustomerForm.F_FormProperty propertyBLL = new CustomerForm.F_FormProperty();
            List<CommonService.Model.CustomerForm.F_FormProperty> list = propertyBLL.GetValuesByBusinessFormCode(form.P_Business_flow_form_code);
            List<CommonService.Model.CustomerForm.F_FormProperty> newList = list.Where(p => p.F_FormProperty_isRequire == true && (string.IsNullOrEmpty(p.V_FormPropertyValue_Value) == true) && p.F_FormProperty_uiType != 207 && p._f_formproperty_code != Guid.Parse("28105E12-C30C-4128-9076-622677AFFE9F") && p._f_formproperty_code != Guid.Parse("AB21DC0E-5AD0-4959-9410-611DDE6A7D99") && p._f_formproperty_code != Guid.Parse("9367C08B-BBE0-4BCA-AE6A-82123419E9AE")).ToList();
            if (newList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}

