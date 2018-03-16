using CommonService.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.CustomerForm
{
    /// <summary>
    /// 表单审核表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/06/06
    /// </summary>
    public partial class F_FormCheck
    {
        private readonly CommonService.DAL.CustomerForm.F_FormCheck dal = new CommonService.DAL.CustomerForm.F_FormCheck();
        /// <summary>
        /// 流程数据访问类
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Flow flowDAL = new CommonService.DAL.FlowManager.P_Flow();
        /// <summary>
        /// 业务流程数据访问类
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow businessFlowDAL = new CommonService.DAL.FlowManager.P_Business_flow();
        /// <summary>
        /// 业务流程表单关联数据访问类
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow_form businessFlowFormDAL = new CommonService.DAL.FlowManager.P_Business_flow_form();
        /// <summary>
        /// 业务流程表单关联业务访问类
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow_form businessFlowFormBLL = new FlowManager.P_Business_flow_form();
        /// <summary>
        /// 案件数据访问类
        /// </summary>
        private readonly CommonService.DAL.CaseManager.B_Case caseDAL = new CommonService.DAL.CaseManager.B_Case();
        /// <summary>
        /// 表单属性数据访问类
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_FormProperty formPropertyDAL = new CommonService.DAL.CustomerForm.F_FormProperty();
        /// <summary>
        /// 表单属性值数据访问类
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_FormPropertyValue formPropertyValueDAL = new CommonService.DAL.CustomerForm.F_FormPropertyValue();
        /// <summary>
        /// 表单属性值业务访问层
        /// </summary>
        private readonly CommonService.BLL.CustomerForm.F_FormPropertyValue formPropertyValueBll = new CommonService.BLL.CustomerForm.F_FormPropertyValue();
        /// <summary>
        /// 案件关联表业务访问层
        /// </summary>
        private readonly CommonService.BLL.CaseManager.B_Case_link caseLinkBLL = new CommonService.BLL.CaseManager.B_Case_link();
        /// <summary>
        /// 业务流程业务访问类
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow businessFlowBLL = new CommonService.BLL.FlowManager.P_Business_flow();
        /// <summary>
        /// 消息数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();
        /// <summary>
        /// 商机数据访问层
        /// </summary>
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance businessChanceDAL = new DAL.BusinessChanceManager.B_BusinessChance();
        /// <summary>
        /// 表单数据访问层
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_Form formDAL = new CommonService.DAL.CustomerForm.F_Form();

        public F_FormCheck()
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
        public bool Exists(int F_FormCheck_id)
        {
            return dal.Exists(F_FormCheck_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_FormCheck model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 提交表单审核
        /// </summary>
        /// <param name="formChecks">表单审核集合</param>
        /// <returns></returns>
        public int SubmitForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks, string fkType)
        {
            ArrayList businessFlowPersonRepins = new ArrayList();//流程负责人集合
            int status = 1;//代表提交成功
            int count = 0;//已提交表单记数(这里需要特殊处理一个不可提交表单的服务端验证逻辑，用"-1"来标识，代表：提交表单所属业务流程及其父级业务流程线上的业务负责人没有设置)
            bool isHasValidatedSetBusinessFlowPerson = false;//是否已经验证过“提交表单所属业务流程及其父级业务流程线上的业务负责人有没有设置过”
            Guid? businessFlowCode = null;
            /**
             * author:hety
             * date:2015-06-08
             * description:
             * (1)、只有自定义表单状态为"未提交"或"未通过"时，才可以提交表单
             * (2)、如果提交表单所属业务流程及其父级业务流程线上的业务负责人没有设置，则不可以提交表单
             * (3)、提交表单时，需要赋值当前审核业务流程Guid，当前审核人，以及当前审核状态
             * (4)、给当前审核人发送消息
             ***/

            foreach (CommonService.Model.CustomerForm.F_FormCheck formCheck in formChecks)
            {
                CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = businessFlowFormDAL.GetModel(formCheck.F_FormCheck_business_flow_form_code.Value);

                if (businessFlowForm != null)
                {
                    businessFlowCode = businessFlowForm.P_Business_flow_code;

                    #region 处理逻辑(2),这里只需要写在这个遍历里，并且只需验证一次(为提高效率)，因为所提交的表单均属于同一个业务流程，要么都通过验证，要么都不能通过验证
                    if (!isHasValidatedSetBusinessFlowPerson)
                    {
                        if (!businessFlowBLL.ExistsBusinessFlowResponsiblePerson(businessFlowCode.Value))
                        {
                            count = -1;//代表：提交表单所属业务流程及其父级业务流程线上的业务负责人没有设置
                        }
                        isHasValidatedSetBusinessFlowPerson = true;
                        if (count == -1)
                        {
                            break;//没有验证通过，跳出
                        }
                    }

                    #endregion

                    if (businessFlowForm.P_Business_flow_form_status.Value == Convert.ToInt32(FormStatusEnum.未提交) || businessFlowForm.P_Business_flow_form_status.Value == Convert.ToInt32(FormStatusEnum.未通过))
                    {
                        businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已提交);
                        businessFlowFormDAL.Update(businessFlowForm);

                        #region 个性化处理"预期收益计算"表单提交业务逻辑
                        Guid yuqishouyiFormCode = new Guid("128EBF60-F58E-4AE2-B3B7-826DD62A0960");//预期收益计算表单
                        if (businessFlowForm.F_Form_code.Value.ToString().ToUpper() == yuqishouyiFormCode.ToString().ToUpper())
                        {
                            SendUnCheckMessageToZygwAfterSubmitYuqishouyiForm(formCheck,businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_code.Value);
                            count++;
                            continue;
                        }
                        
                        #endregion

                        //审核默认信息处理
                        CommonService.Model.FlowManager.P_Business_flow businessFlow = businessFlowDAL.GetModel(businessFlowForm.P_Business_flow_code.Value);
                        CommonService.Model.FlowManager.P_Flow flow = flowDAL.GetModel(businessFlow.P_Flow_code.Value);
                        CommonService.Model.CustomerForm.F_Form form = formDAL.GetModel(businessFlowForm.F_Form_code.Value);
                        //是否首席必审
                        if (form.F_Form_IsChiefCheck == true)
                        {
                            businessFlowPersonRepins = RecursionSubmitFormToChief(formCheck, businessFlowForm, businessFlow, fkType, businessFlowPersonRepins);
                        }
                        else if (flow.P_Flow_IsChiefCheck == true)
                        {
                            businessFlowPersonRepins = RecursionSubmitFormToChief(formCheck, businessFlowForm, businessFlow, fkType, businessFlowPersonRepins);
                        }
                        else
                        {
                            businessFlowPersonRepins = RecursionSubmitForm(formCheck, businessFlowForm, businessFlow, fkType, businessFlowPersonRepins);
                        }

                        count++;
                    }
                }
            }
            if (count == 0)
            {
                status = 0;//代表没有符合条件可以提交的表单
            }
            else if (count == -1)
            {
                status = -1;//提交表单所属业务流程及其父级业务流程线上的业务负责人尚未设置
            }
            else //流程是否结束，张东洋2015/9/3
            {
                #region 判断流程下所有表单是否全部审核通过，如果是，则将流程设为结束状态
                if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                {
                    if (businessFlowCode != null)
                    {
                        bool isAllFormCheckPass = true;//是否当前业务流程下所有表单审核通过
                        List<CommonService.Model.FlowManager.P_Business_flow_form> RelBusinessFlowForms = businessFlowFormBLL.OnlyGetBusinessFlowForms(businessFlowCode.Value);
                        foreach (CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm in RelBusinessFlowForms)
                        {
                            if (businessFlowForm.P_Business_flow_form_status != Convert.ToInt32(FormStatusEnum.已通过))
                            {
                                isAllFormCheckPass = false;
                                break;
                            }
                        }
                        if (isAllFormCheckPass)
                        {
                            DateTime now = DateTime.Now;
                            Model.FlowManager.P_Business_flow businessFlow = businessFlowDAL.GetModel(businessFlowCode.Value);
                            CommonService.Model.FlowManager.P_Flow flow = flowDAL.GetModel(businessFlow.P_Flow_code.Value);
                            if (!flow.P_Flow_IsCrossForm)
                            {//流程"是否交单"为"否"
                                //结束当前业务流程
                                businessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                businessFlow.P_Business_flow_factEndTime = now;
                                businessFlowDAL.Update(businessFlow);
                                //根据业务流程"实际结束时间"更新关联条目统计信息时间值
                                businessFlowDAL.UpdateEntryStatisticsByBusinessFlowTime(businessFlowCode.Value, "factEndTime", now);

                                //发送队列消息
                                MSMQ.SendMessage();
                            }
                            else
                            {
                                if (businessFlow.P_Business_person != null)
                                {
                                    CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.可结案);
                                    message.C_Messages_link = businessFlow.P_Fk_code;
                                    message.C_Messages_createTime = now;
                                    message.C_Messages_person = businessFlow.P_Business_person;
                                    message.C_Messages_isRead = 0;
                                    message.C_Messages_content = "";
                                    message.C_Messages_isValidate = 1;

                                    messageDAL.Add(message);
                                }
                            }

                        }
                    }
                }
                #endregion
            }

            return status;
        }

        /// <summary>
        /// 递归提交表单审核
        /// </summary>
        /// <param name="formCheck">需审核的表单</param>
        /// <param name="businessFlowForm"></param>
        /// <param name="businessFlow">关联业务流程</param>
        /// <param name="fkType">153、案件 154、商机</param>
        /// <param name="businessFlowPersonRepins">消息人集合</param>
        /// <returns></returns>
        public ArrayList RecursionSubmitForm(CommonService.Model.CustomerForm.F_FormCheck formCheck, CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm, CommonService.Model.FlowManager.P_Business_flow businessFlow, string fkType, ArrayList businessFlowPersonRepins)
        {
            //当前时间
            //张东洋 2015/9/3
            DateTime now = DateTime.Now;

            if (formCheck.F_FormCheck_creator != businessFlow.P_Business_person)
            {//审核人是否是自己
                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;

                dal.Add(formCheck);

                if (!businessFlowPersonRepins.Contains(businessFlow.P_Business_person))
                {//仅需要给流程负责人发一条需要审核的消息
                    businessFlowPersonRepins.Add(businessFlow.P_Business_person);
                    #region 给当前审核人发送消息
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                    message.C_Messages_link = businessFlow.P_Fk_code;
                    message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                    message.C_Messages_person = businessFlow.P_Business_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                    #endregion
                }
            }
            else
            {
                if (businessFlowForm.P_Business_flow_form_isDefault == 1)
                {//默认表单
                    #region
                    if (businessFlow.P_Flow_parent != null)
                    {
                        CommonService.Model.FlowManager.P_Business_flow businessFlowParent = businessFlowDAL.GetModel(businessFlow.P_Flow_parent.Value);
                        if (businessFlowParent != null)
                        {
                            businessFlowPersonRepins = RecursionSubmitForm(formCheck, businessFlowForm, businessFlowParent, fkType, businessFlowPersonRepins);
                        }
                    }
                    else
                    {
                        #region 代表上一级审核人为案件负责人或者商机负责人审核
                        if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                        {
                            #region 案件
                            CommonService.Model.CaseManager.B_Case bcase = caseDAL.GetModel(businessFlow.P_Fk_code.Value);
                            if (bcase != null)
                            {
                                if (bcase.B_Case_person == formCheck.F_FormCheck_creator)
                                {
                                    if (bcase.B_Case_levelType == 2)
                                    {//如果案件为策划级案件，则提交给案件一级负责人审核
                                        #region
                                        if (bcase.B_Case_firstClassResponsiblePerson == formCheck.F_FormCheck_creator)
                                        {
                                            businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                            businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);

                                            #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                            CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                            if (factEndTimeFormProperty != null)
                                            {
                                                //更新审核信息中的审核时间为当前时间
                                                //张东洋 2015/9/3
                                                formCheck.F_FormCheck_checkDate = now;
                                                Update(formCheck);

                                                formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                                businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                                //发送队列消息
                                                MSMQ.SendMessage();
                                            }
                                            #endregion

                                            businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                        }
                                        else
                                        {
                                            formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                            formCheck.F_FormCheck_checkBusinessCode = bcase.B_Case_code;//businessFlow.P_Fk_code;
                                            formCheck.F_FormCheck_checkPerson = bcase.B_Case_firstClassResponsiblePerson;

                                            dal.Add(formCheck);

                                            if (!businessFlowPersonRepins.Contains(bcase.B_Case_firstClassResponsiblePerson))
                                            {//仅需要给流程负责人发一条需要审核的消息
                                                businessFlowPersonRepins.Add(bcase.B_Case_firstClassResponsiblePerson);
                                                #region 给当前审核人发送消息
                                                CommonService.Model.C_Messages message = new Model.C_Messages();
                                                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                                message.C_Messages_link = businessFlow.P_Fk_code;
                                                message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                                                message.C_Messages_person = bcase.B_Case_firstClassResponsiblePerson;
                                                message.C_Messages_isRead = 0;
                                                message.C_Messages_content = "";
                                                message.C_Messages_isValidate = 1;

                                                messageDAL.Add(message);
                                                #endregion
                                            }
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        #region
                                        formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                        //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                        formCheck.F_FormCheck_checkBusinessCode = bcase.B_Case_code;
                                        //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                                        formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                                        dal.Add(formCheck);

                                        businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                        businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);

                                        #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                        CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                        if (factEndTimeFormProperty != null)
                                        {
                                            //更新审核信息中的审核时间为当前时间
                                            //张东洋 2015/9/3
                                            formCheck.F_FormCheck_checkDate = now;
                                            Update(formCheck);

                                            formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                            businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                            //发送队列消息
                                            MSMQ.SendMessage();
                                        }
                                        #endregion

                                        businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                        #endregion
                                    }
                                }
                                else
                                {
                                    #region
                                    formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                    //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                    formCheck.F_FormCheck_checkBusinessCode = bcase.B_Case_code;
                                    formCheck.F_FormCheck_checkPerson = bcase.B_Case_person;

                                    dal.Add(formCheck);

                                    if (!businessFlowPersonRepins.Contains(bcase.B_Case_person))
                                    {
                                        businessFlowPersonRepins.Add(bcase.B_Case_person);
                                        #region 给当前审核人发送消息
                                        CommonService.Model.C_Messages message = new Model.C_Messages();
                                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                        message.C_Messages_link = businessFlow.P_Fk_code;
                                        message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                                        message.C_Messages_person = bcase.B_Case_person;
                                        message.C_Messages_isRead = 0;
                                        message.C_Messages_content = "";
                                        message.C_Messages_isValidate = 1;

                                        messageDAL.Add(message);
                                        #endregion
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region 商机
                            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessFlow.P_Fk_code.Value);
                            if (businessChance != null)
                            {
                                if (businessChance.B_BusinessChance_person == formCheck.F_FormCheck_creator)
                                {
                                    formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                    formCheck.F_FormCheck_checkBusinessCode = businessChance.B_BusinessChance_code;
                                    formCheck.F_FormCheck_checkPerson = businessChance.B_BusinessChance_person;

                                    dal.Add(formCheck);

                                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                    businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);

                                    #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                    CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                    if (factEndTimeFormProperty != null)
                                    {
                                        //更新审核信息中的审核时间为当前时间
                                        //张东洋 2015/9/3
                                        formCheck.F_FormCheck_checkDate = now;
                                        Update(formCheck);

                                        formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                        businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                        //发送队列消息
                                        MSMQ.SendMessage();
                                    }
                                    #endregion

                                    businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                }
                                else
                                {
                                    formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                    formCheck.F_FormCheck_checkBusinessCode = businessChance.B_BusinessChance_code;
                                    formCheck.F_FormCheck_checkPerson = businessChance.B_BusinessChance_person;

                                    dal.Add(formCheck);

                                    if (!businessFlowPersonRepins.Contains(businessChance.B_BusinessChance_person))
                                    {
                                        businessFlowPersonRepins.Add(businessChance.B_BusinessChance_person);

                                        #region 给当前审核人发送消息
                                        CommonService.Model.C_Messages message = new Model.C_Messages();
                                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                        message.C_Messages_link = businessFlow.P_Fk_code;
                                        message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                                        message.C_Messages_person = businessChance.B_BusinessChance_person;
                                        message.C_Messages_isRead = 0;
                                        message.C_Messages_content = "";
                                        message.C_Messages_isValidate = 1;

                                        messageDAL.Add(message);
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    #region
                    if (businessFlow.P_Business_flow_auditType == Convert.ToInt32(BusinessFlowAuditType.仅监控当前预设流程))
                    {
                        formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                        formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                        formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;

                        dal.Add(formCheck);

                        businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                        businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);

                        #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                        CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                        if (factEndTimeFormProperty != null)
                        {
                            //更新审核信息中的审核时间为当前时间
                            //张东洋 2015/9/3
                            formCheck.F_FormCheck_checkDate = now;
                            Update(formCheck);

                            formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                            //发送队列消息
                            MSMQ.SendMessage();
                        }
                        #endregion

                        businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                    }
                    else
                    {
                        if (businessFlow.P_Flow_parent != null)
                        {
                            CommonService.Model.FlowManager.P_Business_flow businessFlowParent = businessFlowDAL.GetModel(businessFlow.P_Flow_parent.Value);
                            if (businessFlowParent != null)
                            {
                                businessFlowPersonRepins = RecursionSubmitForm(formCheck, businessFlowForm, businessFlowParent, fkType, businessFlowPersonRepins);
                            }
                        }
                        else
                        {
                            #region 代表上一级审核人为案件负责人或者商机负责人审核
                            if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                            {
                                #region 案件
                                CommonService.Model.CaseManager.B_Case bcase = caseDAL.GetModel(businessFlow.P_Fk_code.Value);
                                if (bcase != null)
                                {
                                    if (bcase.B_Case_person == formCheck.F_FormCheck_creator)
                                    {
                                        if (bcase.B_Case_levelType == 2)
                                        {//如果案件为策划级案件，则提交给案件一级负责人审核
                                            #region
                                            if (bcase.B_Case_firstClassResponsiblePerson == formCheck.F_FormCheck_creator)
                                            {
                                                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);

                                                #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                                CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                                if (factEndTimeFormProperty != null)
                                                {
                                                    //更新审核信息中的审核时间为当前时间
                                                    //张东洋 2015/9/3
                                                    formCheck.F_FormCheck_checkDate = now;
                                                    Update(formCheck);

                                                    formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                                    //发送队列消息
                                                    MSMQ.SendMessage();
                                                }
                                                #endregion

                                                businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                            }
                                            else
                                            {
                                                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                                formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                                                formCheck.F_FormCheck_checkPerson = bcase.B_Case_firstClassResponsiblePerson;

                                                dal.Add(formCheck);

                                                if (!businessFlowPersonRepins.Contains(bcase.B_Case_firstClassResponsiblePerson))
                                                {//仅需要给流程负责人发一条需要审核的消息
                                                    businessFlowPersonRepins.Add(bcase.B_Case_firstClassResponsiblePerson);
                                                    #region 给当前审核人发送消息
                                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                                    message.C_Messages_link = businessFlow.P_Fk_code;
                                                    message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                                                    message.C_Messages_person = bcase.B_Case_firstClassResponsiblePerson;
                                                    message.C_Messages_isRead = 0;
                                                    message.C_Messages_content = "";
                                                    message.C_Messages_isValidate = 1;

                                                    messageDAL.Add(message);
                                                    #endregion
                                                }
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            #region
                                            formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                            //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                            formCheck.F_FormCheck_checkBusinessCode = bcase.B_Case_code;
                                            //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                                            formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                                            dal.Add(formCheck);

                                            businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                            businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);

                                            #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                            CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                            if (factEndTimeFormProperty != null)
                                            {
                                                //更新审核信息中的审核时间为当前时间
                                                //张东洋 2015/9/3
                                                formCheck.F_FormCheck_checkDate = now;
                                                Update(formCheck);

                                                formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                                businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                                //发送队列消息
                                                MSMQ.SendMessage();
                                            }
                                            #endregion

                                            businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                            #endregion
                                        }
                                    }
                                    else
                                    {
                                        #region
                                        formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                        //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                        formCheck.F_FormCheck_checkBusinessCode = bcase.B_Case_code;
                                        formCheck.F_FormCheck_checkPerson = bcase.B_Case_person;

                                        dal.Add(formCheck);

                                        if (!businessFlowPersonRepins.Contains(bcase.B_Case_person))
                                        {
                                            businessFlowPersonRepins.Add(bcase.B_Case_person);
                                            #region 给当前审核人发送消息
                                            CommonService.Model.C_Messages message = new Model.C_Messages();
                                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                            message.C_Messages_link = businessFlow.P_Fk_code;
                                            message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                                            message.C_Messages_person = bcase.B_Case_person;
                                            message.C_Messages_isRead = 0;
                                            message.C_Messages_content = "";
                                            message.C_Messages_isValidate = 1;

                                            messageDAL.Add(message);
                                            #endregion
                                        }
                                        #endregion
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                #region 商机
                                CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessFlow.P_Fk_code.Value);
                                if (businessChance != null)
                                {
                                    if (businessChance.B_BusinessChance_person == formCheck.F_FormCheck_creator)
                                    {
                                        formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                        formCheck.F_FormCheck_checkBusinessCode = businessChance.B_BusinessChance_code;
                                        formCheck.F_FormCheck_checkPerson = businessChance.B_BusinessChance_person;

                                        dal.Add(formCheck);

                                        businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                        businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);

                                        #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                        CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                        if (factEndTimeFormProperty != null)
                                        {
                                            //更新审核信息中的审核时间为当前时间
                                            //张东洋 2015/9/3
                                            formCheck.F_FormCheck_checkDate = now;
                                            Update(formCheck);

                                            formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                            businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                            //发送队列消息
                                            MSMQ.SendMessage();
                                        }
                                        #endregion

                                        businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                    }
                                    else
                                    {
                                        formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                        formCheck.F_FormCheck_checkBusinessCode = businessChance.B_BusinessChance_code;
                                        formCheck.F_FormCheck_checkPerson = businessChance.B_BusinessChance_person;

                                        dal.Add(formCheck);

                                        if (!businessFlowPersonRepins.Contains(businessChance.B_BusinessChance_person))
                                        {
                                            businessFlowPersonRepins.Add(businessChance.B_BusinessChance_person);

                                            #region 给当前审核人发送消息
                                            CommonService.Model.C_Messages message = new Model.C_Messages();
                                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                            message.C_Messages_link = businessFlow.P_Fk_code;
                                            message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                                            message.C_Messages_person = businessChance.B_BusinessChance_person;
                                            message.C_Messages_isRead = 0;
                                            message.C_Messages_content = "";
                                            message.C_Messages_isValidate = 1;

                                            messageDAL.Add(message);
                                            #endregion
                                        }
                                    }
                                }
                                #endregion
                            }
                            #endregion
                        }
                    }
                    #endregion
                }
            }

            return businessFlowPersonRepins;
        }

        /// <summary>
        /// 递归提交表单审核(专指：必须提交到首席)
        /// </summary>
        /// <param name="formCheck">需审核的表单</param>
        /// <param name="businessFlowForm"></param>
        /// <param name="businessFlow">关联业务流程</param>
        /// <param name="fkType">153、案件 154、商机</param>
        /// <param name="businessFlowPersonRepins">消息人集合</param>
        /// <returns></returns>
        public ArrayList RecursionSubmitFormToChief(CommonService.Model.CustomerForm.F_FormCheck formCheck, CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm, CommonService.Model.FlowManager.P_Business_flow businessFlow, string fkType, ArrayList businessFlowPersonRepins)
        {
            //当前时间
            //张东洋 2015/9/3
            DateTime now = DateTime.Now;

            if (formCheck.F_FormCheck_creator != businessFlow.P_Business_person)
            {//审核人是否是自己
                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;

                dal.Add(formCheck);

                if (!businessFlowPersonRepins.Contains(businessFlow.P_Business_person))
                {//仅需要给流程负责人发一条需要审核的消息
                    businessFlowPersonRepins.Add(businessFlow.P_Business_person);
                    #region 给当前审核人发送消息
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                    message.C_Messages_link = businessFlow.P_Fk_code;
                    message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                    message.C_Messages_person = businessFlow.P_Business_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                    #endregion
                }
            }
            else
            {
                #region
                if (businessFlow.P_Flow_parent != null)
                {
                    CommonService.Model.FlowManager.P_Business_flow businessFlowParent = businessFlowDAL.GetModel(businessFlow.P_Flow_parent.Value);
                    if (businessFlowParent != null)
                    {
                        businessFlowPersonRepins = RecursionSubmitFormToChief(formCheck, businessFlowForm, businessFlowParent, fkType, businessFlowPersonRepins);
                    }
                }
                else
                {
                    #region 代表上一级审核人为案件负责人或者商机负责人审核
                    if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                    {
                        #region 案件
                        CommonService.Model.CaseManager.B_Case bcase = caseDAL.GetModel(businessFlow.P_Fk_code.Value);
                        if (bcase != null)
                        {
                            if (bcase.B_Case_person == formCheck.F_FormCheck_creator)
                            {
                                #region
                                if (bcase.B_Case_firstClassResponsiblePerson == formCheck.F_FormCheck_creator)
                                {
                                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                    businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);

                                    #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                    CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                    if (factEndTimeFormProperty != null)
                                    {
                                        //更新审核信息中的审核时间为当前时间
                                        //张东洋 2015/9/3
                                        formCheck.F_FormCheck_checkDate = now;
                                        Update(formCheck);

                                        formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                        businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                        //发送队列消息
                                        MSMQ.SendMessage();
                                    }
                                    #endregion

                                    businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                }
                                else
                                {
                                    formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                    formCheck.F_FormCheck_checkBusinessCode = bcase.B_Case_code;//businessFlow.P_Fk_code;
                                    formCheck.F_FormCheck_checkPerson = bcase.B_Case_firstClassResponsiblePerson;

                                    dal.Add(formCheck);

                                    if (!businessFlowPersonRepins.Contains(bcase.B_Case_firstClassResponsiblePerson))
                                    {//仅需要给流程负责人发一条需要审核的消息
                                        businessFlowPersonRepins.Add(bcase.B_Case_firstClassResponsiblePerson);
                                        #region 给当前审核人发送消息
                                        CommonService.Model.C_Messages message = new Model.C_Messages();
                                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                        message.C_Messages_link = businessFlow.P_Fk_code;
                                        message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                                        message.C_Messages_person = bcase.B_Case_firstClassResponsiblePerson;
                                        message.C_Messages_isRead = 0;
                                        message.C_Messages_content = "";
                                        message.C_Messages_isValidate = 1;

                                        messageDAL.Add(message);
                                        #endregion
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                #region
                                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                formCheck.F_FormCheck_checkBusinessCode = bcase.B_Case_code;
                                formCheck.F_FormCheck_checkPerson = bcase.B_Case_person;

                                dal.Add(formCheck);

                                if (!businessFlowPersonRepins.Contains(bcase.B_Case_person))
                                {
                                    businessFlowPersonRepins.Add(bcase.B_Case_person);
                                    #region 给当前审核人发送消息
                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                    message.C_Messages_link = businessFlow.P_Fk_code;
                                    message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                                    message.C_Messages_person = bcase.B_Case_person;
                                    message.C_Messages_isRead = 0;
                                    message.C_Messages_content = "";
                                    message.C_Messages_isValidate = 1;

                                    messageDAL.Add(message);
                                    #endregion
                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region 商机
                        CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessFlow.P_Fk_code.Value);
                        if (businessChance != null)
                        {
                            if (businessChance.B_BusinessChance_person == formCheck.F_FormCheck_creator)
                            {
                                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                formCheck.F_FormCheck_checkBusinessCode = businessChance.B_BusinessChance_code;
                                formCheck.F_FormCheck_checkPerson = businessChance.B_BusinessChance_person;

                                dal.Add(formCheck);

                                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);

                                #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                if (factEndTimeFormProperty != null)
                                {
                                    //更新审核信息中的审核时间为当前时间
                                    //张东洋 2015/9/3
                                    formCheck.F_FormCheck_checkDate = now;
                                    Update(formCheck);

                                    formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                    businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                    //发送队列消息
                                    MSMQ.SendMessage();
                                }
                                #endregion

                                businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                            }
                            else
                            {
                                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                formCheck.F_FormCheck_checkBusinessCode = businessChance.B_BusinessChance_code;
                                formCheck.F_FormCheck_checkPerson = businessChance.B_BusinessChance_person;

                                dal.Add(formCheck);

                                if (!businessFlowPersonRepins.Contains(businessChance.B_BusinessChance_person))
                                {
                                    businessFlowPersonRepins.Add(businessChance.B_BusinessChance_person);

                                    #region 给当前审核人发送消息
                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                    message.C_Messages_link = businessFlow.P_Fk_code;
                                    message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                                    message.C_Messages_person = businessChance.B_BusinessChance_person;
                                    message.C_Messages_isRead = 0;
                                    message.C_Messages_content = "";
                                    message.C_Messages_isValidate = 1;

                                    messageDAL.Add(message);
                                    #endregion
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
            }

            return businessFlowPersonRepins;
        }


        /// <summary>
        /// 审核表单
        /// </summary>
        /// <param name="formChecks">表单审核集合</param>
        /// <returns></returns>
        public int CheckForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks, string fkType)
        {
            ArrayList creatorRepins = new ArrayList();//提交人集合
            int status = 1;//代表提交成功
            int count = 0;//审核表单记数
            bool isAllowPassYuqishouyiForm = true;//是否允许审核"预期收益计算"表单(此变量只针对此表单有效)
            /**
             * author:hety
             * date:2015-06-09
             * description:
             * (1)、只有已提交审核的业务流程表单，才可以进行审核
             * (2)、当前审核人(登录人)必须与预先设置好的默认审核人一致时，才可以进行审核
             * (2.1)、追加一业务逻辑:如果当前审核表单为“预期收益计算”表单时，这时候需要检查专家顾问或者首席专家是否已经裁定过，如果没有裁定，则不可以进行审核
             * (3)、如果业务流程关联表单为默认表单(及必审表单)，则必须由一级负责人及其流程线上的其他级别审核人审核
             * (4)、如果业务流程关联表单所属业务流程为“仅监控当前流程”，此时“主协办律师”提交审核后，该业务流程的负责人进行审核，审核通过，该表单就算通过
             * (5)、如果业务流程关联表单所属业务流程为“完全监控”，此时，提交审核的表单应该一级一级向上提交并审核，一直到“案件负责人”审核通过后，表单才能算是通过，中途如果遇到未通过，表单状态直接更改为未通过，可重新提交审核。
             * (6)、表单审核通过时，会更新"表单实际结束时间"值，并且修改当前表单上"实际结束时间"关联条目统计信息时间值
             * (7)、当业务流程上的所有表单审核通过时，需要修改当前业务流程状态为"已结束"以及业务流程"实际结束时间"，并且修改当前业务流程上"实际结束时间"关联的条目统计信息时间值
             * (8)、对于大结案或退案阶段（只针对案件）审核通过后,需要抄送消息给首席专家
             **/
            DateTime? checkFormTime = null;//审核时间
            Guid? checkPerson = null;//审核人
            if (formChecks.FirstOrDefault() != null)
            {
                checkFormTime = formChecks.FirstOrDefault().F_FormCheck_checkDate;
                checkPerson = formChecks.FirstOrDefault().F_FormCheck_creator;
            }
            Guid? businessFlowCode = null;//表单所属业务流程
            CommonService.Model.FlowManager.P_Business_flow businessFlow = null;
            foreach (CommonService.Model.CustomerForm.F_FormCheck formCheck in formChecks)
            {
                #region 处理问题(1)
                CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = businessFlowFormDAL.GetModel(formCheck.F_FormCheck_business_flow_form_code.Value);
                if (businessFlowForm == null) continue;
                if (businessFlowForm.P_Business_flow_form_status != Convert.ToInt32(FormStatusEnum.已提交)) continue;
                #endregion

                #region 处理问题(2)
                ///最近一条需要审核的记录（也是需要处理的审核业务记录）
                CommonService.Model.CustomerForm.F_FormCheck maxTimeFormCheck = dal.GetMaxTimeModelByBusinessFlowFormCode(formCheck.F_FormCheck_business_flow_form_code.Value);
                if (maxTimeFormCheck == null) continue;
                if (maxTimeFormCheck.F_FormCheck_checkPerson != formCheck.F_FormCheck_checkPerson) continue;
                #endregion

                #region 处理问题(2.1)
                if (!this.CheckIsAllowPassYuqishouyiForm(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value))
                {
                    isAllowPassYuqishouyiForm = false;
                    continue;
                }
                #endregion

                #region 处理问题(3)、(4)、(5)、(6)
                if (businessFlow == null)
                {
                    businessFlow = businessFlowDAL.GetModel(businessFlowForm.P_Business_flow_code.Value);//表单所属业务流程对象
                }
                // CommonService.Model.FlowManager.P_Business_flow businessFlow = businessFlowDAL.GetModel(businessFlowForm.P_Business_flow_code.Value);//表单所属业务流程对象(hety,2015-06-30,之前处理逻辑，这样写应该会影响效率，因为每次都需要查询一次数据库，后来已优化过)
                if (businessFlow == null) continue;
                businessFlowCode = businessFlow.P_Business_flow_code;

                CommonService.Model.FlowManager.P_Flow flow = flowDAL.GetModel(businessFlow.P_Flow_code.Value);
                CommonService.Model.CustomerForm.F_Form form = formDAL.GetModel(businessFlowForm.F_Form_code.Value);
                //是否首席必审
                if (form.F_Form_IsChiefCheck == true)
                {
                    creatorRepins = RecursionCheckFormToChief(formCheck, maxTimeFormCheck, businessFlowForm, businessFlow, fkType, creatorRepins);
                    count++;
                }
                else if (flow.P_Flow_IsChiefCheck == true)
                {
                    creatorRepins = RecursionCheckFormToChief(formCheck, maxTimeFormCheck, businessFlowForm, businessFlow, fkType, creatorRepins);
                    count++;
                }
                else
                {
                    if (businessFlowForm.P_Business_flow_form_isDefault == 1)
                    {
                        #region 默认表单(必审表单)
                        creatorRepins = RecursionCheckForm(formCheck, maxTimeFormCheck, businessFlowForm, businessFlow, fkType, creatorRepins);
                        count++;
                        #endregion
                    }
                    else
                    {
                        if (businessFlow.P_Business_flow_auditType == Convert.ToInt32(BusinessFlowAuditType.仅监控当前预设流程))
                        {
                            #region
                            maxTimeFormCheck.F_FormCheck_state = formCheck.F_FormCheck_state;
                            maxTimeFormCheck.F_FormCheck_checkDate = formCheck.F_FormCheck_checkDate;
                            maxTimeFormCheck.F_FormCheck_content = formCheck.F_FormCheck_content;
                            dal.Update(maxTimeFormCheck);//更改审核信息

                            int? messagetSmallType = Convert.ToInt32(MessageTinyTypeEnum.审核未通过);//消息小类

                            if (formCheck.F_FormCheck_state == Convert.ToInt32(FormCheckStatusEnum.不通过))
                            {
                                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.未通过);
                                messagetSmallType = Convert.ToInt32(MessageTinyTypeEnum.审核未通过);
                            }
                            else if (formCheck.F_FormCheck_state == Convert.ToInt32(FormCheckStatusEnum.通过))
                            {
                                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                messagetSmallType = Convert.ToInt32(MessageTinyTypeEnum.审核通过);

                                #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                if (factEndTimeFormProperty != null)
                                {
                                    formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                    businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                    //发送队列消息
                                    MSMQ.SendMessage();
                                }
                                #endregion
                            }
                            businessFlowFormDAL.Update(businessFlowForm);//更改表单状态

                            #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                            CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                            if (recentySubmitCheck != null)
                            {
                                if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                {
                                    creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                    message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                    message.C_Messages_type = messagetSmallType;
                                    message.C_Messages_link = businessFlow.P_Fk_code;
                                    message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                    message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                    message.C_Messages_isRead = 0;
                                    message.C_Messages_content = "";
                                    message.C_Messages_isValidate = 1;

                                    messageDAL.Add(message);
                                }
                            }
                            #endregion

                            count++;
                            #endregion
                        }
                        else if (businessFlow.P_Business_flow_auditType == Convert.ToInt32(BusinessFlowAuditType.完全监控))
                        {
                            creatorRepins = RecursionCheckForm(formCheck, maxTimeFormCheck, businessFlowForm, businessFlow, fkType, creatorRepins);
                            count++;
                        }
                    }
                }
                #endregion
            }

            #region 处理问题(7)、(8)
            if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
            {
                if (count != 0 && businessFlowCode != null)
                {
                    bool isAllFormCheckPass = true;//是否当前业务流程下所有表单审核通过
                    List<CommonService.Model.FlowManager.P_Business_flow_form> RelBusinessFlowForms = businessFlowFormBLL.OnlyGetBusinessFlowForms(businessFlowCode.Value);
                    foreach (CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm in RelBusinessFlowForms)
                    {
                        if (businessFlowForm.P_Business_flow_form_status != Convert.ToInt32(FormStatusEnum.已通过))
                        {
                            isAllFormCheckPass = false;
                            break;
                        }
                    }
                    if (isAllFormCheckPass)
                    {
                        CommonService.Model.FlowManager.P_Flow flow = flowDAL.GetModel(businessFlow.P_Flow_code.Value);
                        if (!flow.P_Flow_IsCrossForm)
                        {
                            //结束当前业务流程
                            businessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                            businessFlow.P_Business_flow_factEndTime = checkFormTime;
                            businessFlowDAL.Update(businessFlow);
                            //根据业务流程"实际结束时间"更新关联条目统计信息时间值
                            businessFlowDAL.UpdateEntryStatisticsByBusinessFlowTime(businessFlowCode.Value, "factEndTime", checkFormTime.Value);

                            //发送队列消息
                            MSMQ.SendMessage();
                        }
                        else
                        {
                            if (businessFlow.P_Business_person != null)
                            {
                                CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.可结案);
                                message.C_Messages_link = businessFlow.P_Fk_code;
                                message.C_Messages_createTime = DateTime.Now;
                                message.C_Messages_person = businessFlow.P_Business_person;
                                message.C_Messages_isRead = 0;
                                message.C_Messages_content = "";
                                message.C_Messages_isValidate = 1;

                                messageDAL.Add(message);
                            }
                        }
                    }
                }
            }
            #endregion

            if (count == 0)
            {
                status = 0;//代表没有符合条件可以审核的表单
            }

            #region 只针对"预期收益计算"表单的状态
            if (!isAllowPassYuqishouyiForm)
            {
                status = 2;//代表预期收益表单尚未裁定，不可以进行审核
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 递归审核表单
        /// </summary>
        /// <param name="formCheck">WCF传入审核对象</param>
        /// <param name="maxTimeFormCheck">最近一条需要审核的记录对象</param>
        /// <param name="businessFlowForm">业务流程关联表单对象</param>
        /// <param name="businessFlow">业务流程对象</param>
        private ArrayList RecursionCheckForm(CommonService.Model.CustomerForm.F_FormCheck formCheck, CommonService.Model.CustomerForm.F_FormCheck maxTimeFormCheck, CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm, CommonService.Model.FlowManager.P_Business_flow businessFlow, string fkType, ArrayList creatorRepins)
        {
            #region
            maxTimeFormCheck.F_FormCheck_state = formCheck.F_FormCheck_state;
            maxTimeFormCheck.F_FormCheck_checkDate = formCheck.F_FormCheck_checkDate;
            maxTimeFormCheck.F_FormCheck_content = formCheck.F_FormCheck_content;
            dal.Update(maxTimeFormCheck);//更改审核信息
            if (formCheck.F_FormCheck_state == Convert.ToInt32(FormCheckStatusEnum.不通过))
            {
                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.未通过);
                businessFlowFormDAL.Update(businessFlowForm);//更改表单状态    

                #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                if (recentySubmitCheck != null)
                {
                    if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                    {
                        creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                        CommonService.Model.C_Messages message = new Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核未通过);
                        message.C_Messages_link = businessFlow.P_Fk_code;
                        message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                        message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;

                        messageDAL.Add(message);
                    }
                }
                #endregion
            }
            else if (formCheck.F_FormCheck_state == Convert.ToInt32(FormCheckStatusEnum.通过))
            {
                #region 这种情况需要层层往上提交，直到所属案件负责人(一级负责人)审核通过，表单才可以审核通过
                CommonService.Model.FlowManager.P_Business_flow thisCheckBusinessFlow = businessFlowDAL.GetModel(maxTimeFormCheck.F_FormCheck_checkBusinessCode.Value);//当前审核信息关联业务流程对象
                if (thisCheckBusinessFlow == null)
                {//代表业务流程线上的审核人均已审核通过，这是需要对应案件负责人，或者商机负责人审核,并且改变表单状态为"已通过"
                    #region
                    if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                    {
                        #region 案件
                        CommonService.Model.CaseManager.B_Case bcase = caseDAL.GetModel(businessFlow.P_Fk_code.Value);
                        if (formCheck.F_FormCheck_creator == bcase.B_Case_person)
                        {
                            if (bcase.B_Case_levelType == 2)
                            {
                                if (formCheck.F_FormCheck_creator == bcase.B_Case_firstClassResponsiblePerson)
                                {
                                    #region
                                    formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                    //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                    formCheck.F_FormCheck_checkBusinessCode = bcase.B_Case_code;
                                    //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                                    formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                                    dal.Add(formCheck);

                                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                    businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                    businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                    #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                    CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                    if (factEndTimeFormProperty != null)
                                    {
                                        formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                        businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                        //发送队列消息
                                        MSMQ.SendMessage();
                                    }
                                    #endregion

                                    #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                    CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                    if (recentySubmitCheck != null)
                                    {
                                        if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                        {
                                            creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                            CommonService.Model.C_Messages message = new Model.C_Messages();
                                            message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                            message.C_Messages_link = businessFlow.P_Fk_code;
                                            message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                            message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                            message.C_Messages_isRead = 0;
                                            message.C_Messages_content = "";
                                            message.C_Messages_isValidate = 1;

                                            messageDAL.Add(message);
                                        }
                                    }
                                    #endregion

                                    #endregion
                                }
                                else
                                {
                                    #region
                                    CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                    newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                    newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                    newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                    newFormCheck.F_FormCheck_checkBusinessCode = maxTimeFormCheck.F_FormCheck_checkBusinessCode;
                                    if (bcase.B_Case_firstClassResponsiblePerson != null)
                                    {
                                        newFormCheck.F_FormCheck_checkPerson = bcase.B_Case_firstClassResponsiblePerson;
                                    }
                                    newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                    newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                    newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                    newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                    dal.Add(newFormCheck);
                                    #endregion

                                    #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                    if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                    {
                                        creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                        CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                        submitMessage.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                        submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                        submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                        submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                        submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                        submitMessage.C_Messages_isRead = 0;
                                        submitMessage.C_Messages_content = "";
                                        submitMessage.C_Messages_isValidate = 1;

                                        messageDAL.Add(submitMessage);
                                    }
                                    #endregion
                                }
                            }
                            else
                            {
                                #region
                                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                formCheck.F_FormCheck_checkBusinessCode = bcase.B_Case_code;
                                //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                                formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                                dal.Add(formCheck);

                                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                if (factEndTimeFormProperty != null)
                                {
                                    formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                    businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                    //发送队列消息
                                    MSMQ.SendMessage();
                                }
                                #endregion

                                #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                if (recentySubmitCheck != null)
                                {
                                    if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                    {
                                        creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                        CommonService.Model.C_Messages message = new Model.C_Messages();
                                        message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                        message.C_Messages_link = businessFlow.P_Fk_code;
                                        message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                        message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                        message.C_Messages_isRead = 0;
                                        message.C_Messages_content = "";
                                        message.C_Messages_isValidate = 1;

                                        messageDAL.Add(message);
                                    }
                                }
                                #endregion

                                #endregion
                            }
                        }
                        else if (formCheck.F_FormCheck_creator == bcase.B_Case_firstClassResponsiblePerson)
                        {
                            #region
                            formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                            //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                            formCheck.F_FormCheck_checkBusinessCode = bcase.B_Case_code;
                            //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                            formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                            dal.Add(formCheck);

                            businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                            businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                            businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                            #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                            CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                            if (factEndTimeFormProperty != null)
                            {
                                formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                //发送队列消息
                                MSMQ.SendMessage();
                            }
                            #endregion

                            #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                            CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                            if (recentySubmitCheck != null)
                            {
                                if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                {
                                    creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                    message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                    message.C_Messages_link = businessFlow.P_Fk_code;
                                    message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                    message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                    message.C_Messages_isRead = 0;
                                    message.C_Messages_content = "";
                                    message.C_Messages_isValidate = 1;

                                    messageDAL.Add(message);
                                }
                            }
                            #endregion

                            #endregion
                        }else
                        {
                            #region
                            CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                            newFormCheck.F_FormCheck_code = Guid.NewGuid();
                            newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                            newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                            newFormCheck.F_FormCheck_checkBusinessCode = maxTimeFormCheck.F_FormCheck_checkBusinessCode;
                            if (bcase.B_Case_firstClassResponsiblePerson != null)
                            {
                                newFormCheck.F_FormCheck_checkPerson = bcase.B_Case_person;
                            }
                            newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                            newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                            newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                            newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                            dal.Add(newFormCheck);
                            #endregion

                            #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                            if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                            {
                                creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                submitMessage.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                submitMessage.C_Messages_isRead = 0;
                                submitMessage.C_Messages_content = "";
                                submitMessage.C_Messages_isValidate = 1;

                                messageDAL.Add(submitMessage);
                            }
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {
                        #region 商机
                        CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessFlow.P_Fk_code.Value);
                        if (formCheck.F_FormCheck_creator == businessChance.B_BusinessChance_person)
                        {
                            formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                            formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                            formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;

                            dal.Add(formCheck);

                            businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                            businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                            businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                            #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                            CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                            if (factEndTimeFormProperty != null)
                            {
                                formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                //发送队列消息
                                MSMQ.SendMessage();
                            }
                            #endregion

                            #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                            CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                            if (recentySubmitCheck != null)
                            {
                                if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                {
                                    creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                    message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                    message.C_Messages_link = businessFlow.P_Fk_code;
                                    message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                    message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                    message.C_Messages_isRead = 0;
                                    message.C_Messages_content = "";
                                    message.C_Messages_isValidate = 1;

                                    messageDAL.Add(message);
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region
                            CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                            newFormCheck.F_FormCheck_code = Guid.NewGuid();
                            newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                            newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                            newFormCheck.F_FormCheck_checkBusinessCode = maxTimeFormCheck.F_FormCheck_checkBusinessCode;
                            if (businessChance.B_BusinessChance_person != null)
                            {
                                newFormCheck.F_FormCheck_checkPerson = businessChance.B_BusinessChance_person;
                            }
                            newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                            newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                            newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                            newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                            dal.Add(newFormCheck);
                            #endregion

                            #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                            if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                            {
                                creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                submitMessage.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                submitMessage.C_Messages_isRead = 0;
                                submitMessage.C_Messages_content = "";
                                submitMessage.C_Messages_isValidate = 1;

                                messageDAL.Add(submitMessage);
                            }
                            #endregion
                        }


                        #endregion
                    }
                    #endregion
                }
                else
                {
                    Guid? nextCheckPerson = null;//下一个环节审核人Guid
                    if (thisCheckBusinessFlow.P_Flow_parent != null)
                    {
                        creatorRepins = ParentRecursionCheckForm(formCheck, thisCheckBusinessFlow, businessFlowForm, businessFlow, fkType, creatorRepins);
                    }
                    else
                    {
                        #region 代表上一级审核人为案件负责人或者商机负责人审核
                        //获取表单所属业务流程关联流程对象
                        CommonService.Model.FlowManager.P_Flow flow = flowDAL.GetModel(businessFlow.P_Flow_code.Value);
                        if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                        {
                            #region 案件
                            CommonService.Model.CaseManager.B_Case bCase = caseDAL.GetModel(businessFlow.P_Fk_code.Value);
                            if (bCase != null)
                            {
                                if (bCase.B_Case_person == formCheck.F_FormCheck_creator)
                                {
                                    if (bCase.B_Case_levelType == 2)
                                    {
                                        if (bCase.B_Case_firstClassResponsiblePerson == formCheck.F_FormCheck_creator)
                                        {
                                            #region
                                            formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                            //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                            formCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                            //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                                            formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                                            dal.Add(formCheck);

                                            businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                            businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                            businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                            #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                            CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                            if (factEndTimeFormProperty != null)
                                            {
                                                formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                                businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                                //发送队列消息
                                                MSMQ.SendMessage();
                                            }
                                            #endregion

                                            #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                            CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                            if (recentySubmitCheck != null)
                                            {
                                                if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                                {
                                                    creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                                    message.C_Messages_link = businessFlow.P_Fk_code;
                                                    message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                                    message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                                    message.C_Messages_isRead = 0;
                                                    message.C_Messages_content = "";
                                                    message.C_Messages_isValidate = 1;

                                                    messageDAL.Add(message);
                                                }
                                            }
                                            #endregion

                                            #endregion
                                        }
                                        else
                                        {
                                            #region
                                            CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                            newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                            newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                            newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                            //newFormCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                            newFormCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                            if (bCase.B_Case_firstClassResponsiblePerson != null)
                                            {
                                                newFormCheck.F_FormCheck_checkPerson = bCase.B_Case_firstClassResponsiblePerson;
                                            }
                                            newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                            newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                            newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                            newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                            dal.Add(newFormCheck);
                                            #endregion

                                            #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                            if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                            {
                                                creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                                CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                                submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                                submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                                submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                                submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                                submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                                submitMessage.C_Messages_isRead = 0;
                                                submitMessage.C_Messages_content = "";
                                                submitMessage.C_Messages_isValidate = 1;

                                                messageDAL.Add(submitMessage);
                                            }
                                            #endregion
                                        }
                                    }
                                    else
                                    {
                                        #region

                                        formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                        //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                        formCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                        //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                                        formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                                        dal.Add(formCheck);

                                        businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                        businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                        businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                        #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                        CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                        if (factEndTimeFormProperty != null)
                                        {
                                            formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                            businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                            //发送队列消息
                                            MSMQ.SendMessage();
                                        }
                                        #endregion

                                        #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                        CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                        if (recentySubmitCheck != null)
                                        {
                                            if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                            {
                                                creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                                CommonService.Model.C_Messages message = new Model.C_Messages();
                                                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                                message.C_Messages_link = businessFlow.P_Fk_code;
                                                message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                                message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                                message.C_Messages_isRead = 0;
                                                message.C_Messages_content = "";
                                                message.C_Messages_isValidate = 1;

                                                messageDAL.Add(message);
                                            }
                                        }
                                        #endregion

                                        #endregion
                                    }
                                }
                                else
                                {
                                    #region
                                    CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                    newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                    newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                    newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                    //newFormCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                    newFormCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                    newFormCheck.F_FormCheck_checkPerson = bCase.B_Case_person;
                                    newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                    newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                    newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                    newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                    dal.Add(newFormCheck);
                                    #endregion

                                    #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                    if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                    {
                                        creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                        CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                        submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                        submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                        submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                        submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                        submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                        submitMessage.C_Messages_isRead = 0;
                                        submitMessage.C_Messages_content = "";
                                        submitMessage.C_Messages_isValidate = 1;

                                        messageDAL.Add(submitMessage);
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region 商机
                            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessFlow.P_Fk_code.Value);
                            if (businessChance != null)
                            {
                                if (businessChance.B_BusinessChance_person == formCheck.F_FormCheck_creator)
                                {
                                    #region
                                    formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                    formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                                    formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;

                                    dal.Add(formCheck);

                                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                    businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                    businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                    #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                    CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                    if (factEndTimeFormProperty != null)
                                    {
                                        formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                        businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                        //发送队列消息
                                        MSMQ.SendMessage();
                                    }
                                    #endregion

                                    #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                    CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                    if (recentySubmitCheck != null)
                                    {
                                        if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                        {
                                            creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                            CommonService.Model.C_Messages message = new Model.C_Messages();
                                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                            message.C_Messages_link = businessFlow.P_Fk_code;
                                            message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                            message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                            message.C_Messages_isRead = 0;
                                            message.C_Messages_content = "";
                                            message.C_Messages_isValidate = 1;

                                            messageDAL.Add(message);
                                        }
                                    }
                                    #endregion

                                    #endregion
                                }
                                else
                                {
                                    #region
                                    CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                    newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                    newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                    newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                    newFormCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                                    newFormCheck.F_FormCheck_checkPerson = businessChance.B_BusinessChance_person;
                                    newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                    newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                    newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                    newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                    dal.Add(newFormCheck);
                                    #endregion

                                    #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                    if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                    {
                                        creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                        CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                        submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                        submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                        submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                        submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                        submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                        submitMessage.C_Messages_isRead = 0;
                                        submitMessage.C_Messages_content = "";
                                        submitMessage.C_Messages_isValidate = 1;

                                        messageDAL.Add(submitMessage);
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                }
                #endregion
            }
            return creatorRepins;
            #endregion
        }

        public ArrayList ParentRecursionCheckForm(CommonService.Model.CustomerForm.F_FormCheck formCheck, CommonService.Model.FlowManager.P_Business_flow thisCheckBusinessFlow, CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm, CommonService.Model.FlowManager.P_Business_flow businessFlow, string fkType, ArrayList creatorRepins)
        {
            #region
            //当前审核信息关联业务流程上一级对象
            CommonService.Model.FlowManager.P_Business_flow parentCheckBusinessFlow = businessFlowDAL.GetModel(thisCheckBusinessFlow.P_Flow_parent.Value);
            Guid? nextCheckPerson = null;//下一个环节审核人Guid
            if (formCheck.F_FormCheck_creator == parentCheckBusinessFlow.P_Business_person)
            {
                if (parentCheckBusinessFlow.P_Flow_parent != null)
                {
                    creatorRepins = ParentRecursionCheckForm(formCheck, parentCheckBusinessFlow, businessFlowForm, businessFlow, fkType, creatorRepins);
                }
                else
                {
                    #region 代表上一级审核人为案件负责人或者商机负责人审核
                    //获取表单所属业务流程关联流程对象
                    CommonService.Model.FlowManager.P_Flow flow = flowDAL.GetModel(businessFlow.P_Flow_code.Value);
                    if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                    {
                        #region 案件
                        CommonService.Model.CaseManager.B_Case bCase = caseDAL.GetModel(businessFlow.P_Fk_code.Value);
                        if (bCase != null)
                        {
                            if (bCase.B_Case_person == formCheck.F_FormCheck_creator)
                            {
                                if (bCase.B_Case_levelType == 2)
                                {
                                    if (bCase.B_Case_firstClassResponsiblePerson == formCheck.F_FormCheck_creator)
                                    {
                                        #region
                                        formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                        //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                        formCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                        //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                                        formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                                        dal.Add(formCheck);

                                        businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                        businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                        businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                        #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                        CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                        if (factEndTimeFormProperty != null)
                                        {
                                            formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                            businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                            //发送队列消息
                                            MSMQ.SendMessage();
                                        }
                                        #endregion

                                        #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                        CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                        if (recentySubmitCheck != null)
                                        {
                                            if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                            {
                                                creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                                CommonService.Model.C_Messages message = new Model.C_Messages();
                                                message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                                message.C_Messages_link = businessFlow.P_Fk_code;
                                                message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                                message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                                message.C_Messages_isRead = 0;
                                                message.C_Messages_content = "";
                                                message.C_Messages_isValidate = 1;

                                                messageDAL.Add(message);
                                            }
                                        }
                                        #endregion

                                        #endregion
                                    }
                                    else
                                    {
                                        #region
                                        CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                        newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                        newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                        newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                        //newFormCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                        newFormCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                        if (bCase.B_Case_firstClassResponsiblePerson != null)
                                        {
                                            newFormCheck.F_FormCheck_checkPerson = bCase.B_Case_firstClassResponsiblePerson;
                                        }
                                        newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                        newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                        newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                        newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                        dal.Add(newFormCheck);
                                        #endregion

                                        #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                        if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                        {
                                            creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                            CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                            submitMessage.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                            submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                            submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                            submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                            submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                            submitMessage.C_Messages_isRead = 0;
                                            submitMessage.C_Messages_content = "";
                                            submitMessage.C_Messages_isValidate = 1;

                                            messageDAL.Add(submitMessage);
                                        }
                                        #endregion
                                    }
                                }
                                else
                                {
                                    #region
                                    formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                    //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                    formCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                    //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                                    formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                                    dal.Add(formCheck);

                                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                    businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                    businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                    #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                    CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                    if (factEndTimeFormProperty != null)
                                    {
                                        formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                        businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                        //发送队列消息
                                        MSMQ.SendMessage();
                                    }
                                    #endregion

                                    #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                    CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                    if (recentySubmitCheck != null)
                                    {
                                        if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                        {
                                            creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                            CommonService.Model.C_Messages message = new Model.C_Messages();
                                            message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                            message.C_Messages_link = businessFlow.P_Fk_code;
                                            message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                            message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                            message.C_Messages_isRead = 0;
                                            message.C_Messages_content = "";
                                            message.C_Messages_isValidate = 1;

                                            messageDAL.Add(message);
                                        }
                                    }
                                    #endregion

                                    #endregion
                                }
                            }
                            else
                            {
                                #region
                                CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;//2015-09-30,hety，注释
                                //newFormCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                                newFormCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                newFormCheck.F_FormCheck_checkPerson = bCase.B_Case_person;
                                newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                dal.Add(newFormCheck);
                                #endregion

                                #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                {
                                    creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                    CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                    submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                    submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                    submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                    submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                    submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                    submitMessage.C_Messages_isRead = 0;
                                    submitMessage.C_Messages_content = "";
                                    submitMessage.C_Messages_isValidate = 1;

                                    messageDAL.Add(submitMessage);
                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region 商机
                        CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessFlow.P_Fk_code.Value);
                        if (businessChance != null)
                        {
                            if (businessChance.B_BusinessChance_person == formCheck.F_FormCheck_creator)
                            {
                                #region
                                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                                formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;

                                dal.Add(formCheck);

                                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                if (factEndTimeFormProperty != null)
                                {
                                    formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                    businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                    //发送队列消息
                                    MSMQ.SendMessage();
                                }
                                #endregion

                                #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                if (recentySubmitCheck != null)
                                {
                                    if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                    {
                                        creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                        CommonService.Model.C_Messages message = new Model.C_Messages();
                                        message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                        message.C_Messages_link = businessFlow.P_Fk_code;
                                        message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                        message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                        message.C_Messages_isRead = 0;
                                        message.C_Messages_content = "";
                                        message.C_Messages_isValidate = 1;

                                        messageDAL.Add(message);
                                    }
                                }
                                #endregion

                                #endregion
                            }
                            else
                            {
                                #region
                                CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                newFormCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                                newFormCheck.F_FormCheck_checkPerson = businessChance.B_BusinessChance_person;
                                newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                dal.Add(newFormCheck);
                                #endregion

                                #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                {
                                    creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                    CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                    submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                    submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                    submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                    submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                    submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                    submitMessage.C_Messages_isRead = 0;
                                    submitMessage.C_Messages_content = "";
                                    submitMessage.C_Messages_isValidate = 1;

                                    messageDAL.Add(submitMessage);
                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
            }
            else
            {
                #region
                CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                newFormCheck.F_FormCheck_code = Guid.NewGuid();
                newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                newFormCheck.F_FormCheck_checkBusinessCode = thisCheckBusinessFlow.P_Flow_parent;
                if (parentCheckBusinessFlow != null)
                {
                    newFormCheck.F_FormCheck_checkPerson = parentCheckBusinessFlow.P_Business_person;
                    nextCheckPerson = newFormCheck.F_FormCheck_checkPerson;
                }
                newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                dal.Add(newFormCheck);
                #endregion

                #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                //CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                //if (recentySubmitCheck != null)
                //{
                //    if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                //    {
                //        creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                //        CommonService.Model.C_Messages message = new Model.C_Messages();
                //        message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                //        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                //        message.C_Messages_link = businessFlow.P_Fk_code;
                //        message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                //        message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                //        message.C_Messages_isRead = 0;
                //        message.C_Messages_content = "";
                //        message.C_Messages_isValidate = 1;

                //        messageDAL.Add(message);
                //    }
                //}
                #endregion

                #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                if (!creatorRepins.Contains(nextCheckPerson))
                {
                    creatorRepins.Add(nextCheckPerson);

                    CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                    submitMessage.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                    submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                    submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                    submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                    submitMessage.C_Messages_person = nextCheckPerson;
                    submitMessage.C_Messages_isRead = 0;
                    submitMessage.C_Messages_content = "";
                    submitMessage.C_Messages_isValidate = 1;

                    messageDAL.Add(submitMessage);
                }
                #endregion
            }

            return creatorRepins;
            #endregion
        }

        /// <summary>
        /// 个性化表单直接审核
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="operateUserCode">当前操作人Guid</param>
        /// <returns></returns>
        public int IndividuationCheckForm(Guid businessFlowFormCode,Guid operateUserCode)
        {
            int status = 0;

            /**
             * author:hety 
             * date:2016-03-07
             * description:个性化表单审核
             * (1)、当前表单为已通过
             * (2)、处理审核纪要信息
             * (3)、更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
             * (4)、当业务流程上的所有表单审核通过时，需要修改当前业务流程状态为"已结束"以及业务流程"实际结束时间"，并且修改当前业务流程上"实际结束时间"关联的条目统计信息时间值
             **/

            DateTime now = DateTime.Now;

            #region 处理业务(1)
            CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = businessFlowFormDAL.GetModel(businessFlowFormCode); 
            businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
            businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
            businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
            #endregion

            #region 处理业务(2)
            ///最近一条需要审核的记录（也是需要处理的审核业务记录）
            CommonService.Model.CustomerForm.F_FormCheck maxTimeFormCheck = dal.GetMaxTimeModelByBusinessFlowFormCode(businessFlowFormCode);
            maxTimeFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
            maxTimeFormCheck.F_FormCheck_checkPerson = operateUserCode;
            maxTimeFormCheck.F_FormCheck_checkDate = now;
            maxTimeFormCheck.F_FormCheck_content = "自动审核通过";
            dal.Update(maxTimeFormCheck);//更改审核信息
            #endregion

            #region 处理业务(3)
            CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
            if (factEndTimeFormProperty != null)
            {
                formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, now.ToString("yyyy-MM-dd HH:mm:ss"));
                businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", now);
                //发送队列消息
                MSMQ.SendMessage();
            }
            #endregion 

            #region 处理问题(4)
            bool isAllFormCheckPass = true;//是否当前业务流程下所有表单审核通过
            List<CommonService.Model.FlowManager.P_Business_flow_form> RelBusinessFlowForms = businessFlowFormBLL.OnlyGetBusinessFlowForms(businessFlowForm.P_Business_flow_code.Value);
            foreach (CommonService.Model.FlowManager.P_Business_flow_form relBusFlowForm in RelBusinessFlowForms)
            {
                if (relBusFlowForm.P_Business_flow_form_status != Convert.ToInt32(FormStatusEnum.已通过))
                {
                    isAllFormCheckPass = false;
                    break;
                }
            }
            if (isAllFormCheckPass)
            {
                CommonService.Model.FlowManager.P_Business_flow businessFlow = businessFlowDAL.GetModel(businessFlowForm.P_Business_flow_code.Value);//表单所属业务流程对象
                //结束当前业务流程
                businessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                businessFlow.P_Business_flow_factEndTime = now;
                businessFlowDAL.Update(businessFlow);
                //根据业务流程"实际结束时间"更新关联条目统计信息时间值
                businessFlowDAL.UpdateEntryStatisticsByBusinessFlowTime(businessFlow.P_Business_flow_code.Value, "factEndTime", now);

                //发送队列消息
                MSMQ.SendMessage();
            }
            #endregion

            status = 1;

            return status;
        }

        /// <summary>
        /// 递归审核表单(专指：必须提交到首席)
        /// </summary>
        /// <param name="formCheck">WCF传入审核对象</param>
        /// <param name="maxTimeFormCheck">最近一条需要审核的记录对象</param>
        /// <param name="businessFlowForm">业务流程关联表单对象</param>
        /// <param name="businessFlow">业务流程对象</param>
        private ArrayList RecursionCheckFormToChief(CommonService.Model.CustomerForm.F_FormCheck formCheck, CommonService.Model.CustomerForm.F_FormCheck maxTimeFormCheck, CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm, CommonService.Model.FlowManager.P_Business_flow businessFlow, string fkType, ArrayList creatorRepins)
        {
            #region
            maxTimeFormCheck.F_FormCheck_state = formCheck.F_FormCheck_state;
            maxTimeFormCheck.F_FormCheck_checkDate = formCheck.F_FormCheck_checkDate;
            maxTimeFormCheck.F_FormCheck_content = formCheck.F_FormCheck_content;
            dal.Update(maxTimeFormCheck);//更改审核信息
            if (formCheck.F_FormCheck_state == Convert.ToInt32(FormCheckStatusEnum.不通过))
            {
                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.未通过);
                businessFlowFormDAL.Update(businessFlowForm);//更改表单状态    

                #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                if (recentySubmitCheck != null)
                {
                    if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                    {
                        creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                        CommonService.Model.C_Messages message = new Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核未通过);
                        message.C_Messages_link = businessFlow.P_Fk_code;
                        message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                        message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;

                        messageDAL.Add(message);
                    }
                }
                #endregion
            }
            else if (formCheck.F_FormCheck_state == Convert.ToInt32(FormCheckStatusEnum.通过))
            {
                #region 这种情况需要层层往上提交，直到所属案件负责人(一级负责人)审核通过，表单才可以审核通过
                CommonService.Model.FlowManager.P_Business_flow thisCheckBusinessFlow = businessFlowDAL.GetModel(maxTimeFormCheck.F_FormCheck_checkBusinessCode.Value);//当前审核信息关联业务流程对象
                if (thisCheckBusinessFlow == null)
                {//代表业务流程线上的审核人均已审核通过，这是需要对应案件负责人，或者商机负责人审核,并且改变表单状态为"已通过"
                    #region
                    if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                    {
                        #region 案件
                        CommonService.Model.CaseManager.B_Case bcase = caseDAL.GetModel(businessFlow.P_Fk_code.Value);
                        if (formCheck.F_FormCheck_creator == bcase.B_Case_person)
                        {
                            if (formCheck.F_FormCheck_creator == bcase.B_Case_firstClassResponsiblePerson)
                            {
                                #region
                                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                formCheck.F_FormCheck_checkBusinessCode = bcase.B_Case_code;
                                //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                                formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                                dal.Add(formCheck);

                                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                if (factEndTimeFormProperty != null)
                                {
                                    formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                    businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                    //发送队列消息
                                    MSMQ.SendMessage();
                                }
                                #endregion

                                #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                if (recentySubmitCheck != null)
                                {
                                    if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                    {
                                        creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                        CommonService.Model.C_Messages message = new Model.C_Messages();
                                        message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                        message.C_Messages_link = businessFlow.P_Fk_code;
                                        message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                        message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                        message.C_Messages_isRead = 0;
                                        message.C_Messages_content = "";
                                        message.C_Messages_isValidate = 1;

                                        messageDAL.Add(message);
                                    }
                                }
                                #endregion

                                #endregion
                            }
                            else
                            {
                                #region
                                CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                newFormCheck.F_FormCheck_checkBusinessCode = maxTimeFormCheck.F_FormCheck_checkBusinessCode;
                                if (bcase.B_Case_firstClassResponsiblePerson != null)
                                {
                                    newFormCheck.F_FormCheck_checkPerson = bcase.B_Case_firstClassResponsiblePerson;
                                }
                                newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                dal.Add(newFormCheck);
                                #endregion

                                #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                {
                                    creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                    CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                    submitMessage.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                    submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                    submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                    submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                    submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                    submitMessage.C_Messages_isRead = 0;
                                    submitMessage.C_Messages_content = "";
                                    submitMessage.C_Messages_isValidate = 1;

                                    messageDAL.Add(submitMessage);
                                }
                                #endregion
                            }
                        }
                        else if (formCheck.F_FormCheck_creator == bcase.B_Case_firstClassResponsiblePerson)
                        {
                            #region
                            formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                            //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                            formCheck.F_FormCheck_checkBusinessCode = bcase.B_Case_code;
                            //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                            formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                            dal.Add(formCheck);

                            businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                            businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                            businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                            #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                            CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                            if (factEndTimeFormProperty != null)
                            {
                                formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                //发送队列消息
                                MSMQ.SendMessage();
                            }
                            #endregion

                            #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                            CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                            if (recentySubmitCheck != null)
                            {
                                if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                {
                                    creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                    message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                    message.C_Messages_link = businessFlow.P_Fk_code;
                                    message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                    message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                    message.C_Messages_isRead = 0;
                                    message.C_Messages_content = "";
                                    message.C_Messages_isValidate = 1;

                                    messageDAL.Add(message);
                                }
                            }
                            #endregion

                            #endregion
                        }
                        else
                        {
                            #region
                            CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                            newFormCheck.F_FormCheck_code = Guid.NewGuid();
                            newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                            newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                            newFormCheck.F_FormCheck_checkBusinessCode = maxTimeFormCheck.F_FormCheck_checkBusinessCode;
                            if (bcase.B_Case_firstClassResponsiblePerson != null)
                            {
                                newFormCheck.F_FormCheck_checkPerson = bcase.B_Case_person;
                            }
                            newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                            newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                            newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                            newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                            dal.Add(newFormCheck);
                            #endregion

                            #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                            if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                            {
                                creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                submitMessage.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                submitMessage.C_Messages_isRead = 0;
                                submitMessage.C_Messages_content = "";
                                submitMessage.C_Messages_isValidate = 1;

                                messageDAL.Add(submitMessage);
                            }
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {
                        #region 商机
                        CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessFlow.P_Fk_code.Value);
                        if (formCheck.F_FormCheck_creator == businessChance.B_BusinessChance_person)
                        {
                            formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                            formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                            formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;

                            dal.Add(formCheck);

                            businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                            businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                            businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                            #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                            CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                            if (factEndTimeFormProperty != null)
                            {
                                formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                //发送队列消息
                                MSMQ.SendMessage();
                            }
                            #endregion

                            #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                            CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                            if (recentySubmitCheck != null)
                            {
                                if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                {
                                    creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                    message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                    message.C_Messages_link = businessFlow.P_Fk_code;
                                    message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                    message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                    message.C_Messages_isRead = 0;
                                    message.C_Messages_content = "";
                                    message.C_Messages_isValidate = 1;

                                    messageDAL.Add(message);
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region
                            CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                            newFormCheck.F_FormCheck_code = Guid.NewGuid();
                            newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                            newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                            newFormCheck.F_FormCheck_checkBusinessCode = maxTimeFormCheck.F_FormCheck_checkBusinessCode;
                            if (businessChance.B_BusinessChance_person != null)
                            {
                                newFormCheck.F_FormCheck_checkPerson = businessChance.B_BusinessChance_person;
                            }
                            newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                            newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                            newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                            newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                            dal.Add(newFormCheck);
                            #endregion

                            #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                            if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                            {
                                creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                submitMessage.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                submitMessage.C_Messages_isRead = 0;
                                submitMessage.C_Messages_content = "";
                                submitMessage.C_Messages_isValidate = 1;

                                messageDAL.Add(submitMessage);
                            }
                            #endregion
                        }


                        #endregion
                    }
                    #endregion
                }
                else
                {
                    Guid? nextCheckPerson = null;//下一个环节审核人Guid
                    if (thisCheckBusinessFlow.P_Flow_parent != null)
                    {
                        creatorRepins = ParentRecursionCheckFormToChief(formCheck, thisCheckBusinessFlow, businessFlowForm, businessFlow, fkType, creatorRepins);
                    }
                    else
                    {
                        #region 代表上一级审核人为案件负责人或者商机负责人审核
                        //获取表单所属业务流程关联流程对象
                        CommonService.Model.FlowManager.P_Flow flow = flowDAL.GetModel(businessFlow.P_Flow_code.Value);
                        if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                        {
                            #region 案件
                            CommonService.Model.CaseManager.B_Case bCase = caseDAL.GetModel(businessFlow.P_Fk_code.Value);
                            if (bCase != null)
                            {
                                if (bCase.B_Case_person == formCheck.F_FormCheck_creator)
                                {
                                    if (bCase.B_Case_firstClassResponsiblePerson == formCheck.F_FormCheck_creator)
                                    {
                                        #region
                                        formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                        //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                        formCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                        //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                                        formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                                        dal.Add(formCheck);

                                        businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                        businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                        businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                        #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                        CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                        if (factEndTimeFormProperty != null)
                                        {
                                            formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                            businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                            //发送队列消息
                                            MSMQ.SendMessage();
                                        }
                                        #endregion

                                        #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                        CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                        if (recentySubmitCheck != null)
                                        {
                                            if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                            {
                                                creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                                CommonService.Model.C_Messages message = new Model.C_Messages();
                                                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                                message.C_Messages_link = businessFlow.P_Fk_code;
                                                message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                                message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                                message.C_Messages_isRead = 0;
                                                message.C_Messages_content = "";
                                                message.C_Messages_isValidate = 1;

                                                messageDAL.Add(message);
                                            }
                                        }
                                        #endregion

                                        #endregion
                                    }
                                    else
                                    {
                                        #region
                                        CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                        newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                        newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                        newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                        //newFormCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                        newFormCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                        if (bCase.B_Case_firstClassResponsiblePerson != null)
                                        {
                                            newFormCheck.F_FormCheck_checkPerson = bCase.B_Case_firstClassResponsiblePerson;
                                        }
                                        newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                        newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                        newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                        newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                        dal.Add(newFormCheck);
                                        #endregion

                                        #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                        if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                        {
                                            creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                            CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                            submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                            submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                            submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                            submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                            submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                            submitMessage.C_Messages_isRead = 0;
                                            submitMessage.C_Messages_content = "";
                                            submitMessage.C_Messages_isValidate = 1;

                                            messageDAL.Add(submitMessage);
                                        }
                                        #endregion
                                    }
                                }
                                else
                                {
                                    #region
                                    CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                    newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                    newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                    newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                    //newFormCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                    newFormCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                    newFormCheck.F_FormCheck_checkPerson = bCase.B_Case_person;
                                    newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                    newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                    newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                    newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                    dal.Add(newFormCheck);
                                    #endregion

                                    #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                    if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                    {
                                        creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                        CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                        submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                        submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                        submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                        submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                        submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                        submitMessage.C_Messages_isRead = 0;
                                        submitMessage.C_Messages_content = "";
                                        submitMessage.C_Messages_isValidate = 1;

                                        messageDAL.Add(submitMessage);
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region 商机
                            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessFlow.P_Fk_code.Value);
                            if (businessChance != null)
                            {
                                if (businessChance.B_BusinessChance_person == formCheck.F_FormCheck_creator)
                                {
                                    #region
                                    formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                    formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                                    formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;

                                    dal.Add(formCheck);

                                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                    businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                    businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                    #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                    CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                    if (factEndTimeFormProperty != null)
                                    {
                                        formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                        businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                        //发送队列消息
                                        MSMQ.SendMessage();
                                    }
                                    #endregion

                                    #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                    CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                    if (recentySubmitCheck != null)
                                    {
                                        if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                        {
                                            creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                            CommonService.Model.C_Messages message = new Model.C_Messages();
                                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                            message.C_Messages_link = businessFlow.P_Fk_code;
                                            message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                            message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                            message.C_Messages_isRead = 0;
                                            message.C_Messages_content = "";
                                            message.C_Messages_isValidate = 1;

                                            messageDAL.Add(message);
                                        }
                                    }
                                    #endregion

                                    #endregion
                                }
                                else
                                {
                                    #region
                                    CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                    newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                    newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                    newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                    newFormCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                                    newFormCheck.F_FormCheck_checkPerson = businessChance.B_BusinessChance_person;
                                    newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                    newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                    newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                    newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                    dal.Add(newFormCheck);
                                    #endregion

                                    #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                    if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                    {
                                        creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                        CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                        submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                        submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                        submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                        submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                        submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                        submitMessage.C_Messages_isRead = 0;
                                        submitMessage.C_Messages_content = "";
                                        submitMessage.C_Messages_isValidate = 1;

                                        messageDAL.Add(submitMessage);
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                }
                #endregion
            }
            return creatorRepins;
            #endregion
        }

        public ArrayList ParentRecursionCheckFormToChief(CommonService.Model.CustomerForm.F_FormCheck formCheck, CommonService.Model.FlowManager.P_Business_flow thisCheckBusinessFlow, CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm, CommonService.Model.FlowManager.P_Business_flow businessFlow, string fkType, ArrayList creatorRepins)
        {
            #region
            //当前审核信息关联业务流程上一级对象
            CommonService.Model.FlowManager.P_Business_flow parentCheckBusinessFlow = businessFlowDAL.GetModel(thisCheckBusinessFlow.P_Flow_parent.Value);
            Guid? nextCheckPerson = null;//下一个环节审核人Guid
            if (formCheck.F_FormCheck_creator == parentCheckBusinessFlow.P_Business_person)
            {
                if (parentCheckBusinessFlow.P_Flow_parent != null)
                {
                    creatorRepins = ParentRecursionCheckFormToChief(formCheck, parentCheckBusinessFlow, businessFlowForm, businessFlow, fkType, creatorRepins);
                }
                else
                {
                    #region 代表上一级审核人为案件负责人或者商机负责人审核
                    //获取表单所属业务流程关联流程对象
                    CommonService.Model.FlowManager.P_Flow flow = flowDAL.GetModel(businessFlow.P_Flow_code.Value);
                    if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                    {
                        #region 案件
                        CommonService.Model.CaseManager.B_Case bCase = caseDAL.GetModel(businessFlow.P_Fk_code.Value);
                        if (bCase != null)
                        {
                            if (bCase.B_Case_person == formCheck.F_FormCheck_creator)
                            {
                                if (bCase.B_Case_firstClassResponsiblePerson == formCheck.F_FormCheck_creator)
                                {
                                    #region
                                    formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                    //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                    formCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                    //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                                    formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                                    dal.Add(formCheck);

                                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                    businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                    businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                    #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                    CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                    if (factEndTimeFormProperty != null)
                                    {
                                        formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                        businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                        //发送队列消息
                                        MSMQ.SendMessage();
                                    }
                                    #endregion

                                    #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                    CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                    if (recentySubmitCheck != null)
                                    {
                                        if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                        {
                                            creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                            CommonService.Model.C_Messages message = new Model.C_Messages();
                                            message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                            message.C_Messages_link = businessFlow.P_Fk_code;
                                            message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                            message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                            message.C_Messages_isRead = 0;
                                            message.C_Messages_content = "";
                                            message.C_Messages_isValidate = 1;

                                            messageDAL.Add(message);
                                        }
                                    }
                                    #endregion

                                    #endregion
                                }
                                else
                                {
                                    #region
                                    CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                    newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                    newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                    newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                    //newFormCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                    newFormCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                    if (bCase.B_Case_firstClassResponsiblePerson != null)
                                    {
                                        newFormCheck.F_FormCheck_checkPerson = bCase.B_Case_firstClassResponsiblePerson;
                                    }
                                    newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                    newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                    newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                    newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                    dal.Add(newFormCheck);
                                    #endregion

                                    #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                    if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                    {
                                        creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                        CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                        submitMessage.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                        submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                        submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                        submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                        submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                        submitMessage.C_Messages_isRead = 0;
                                        submitMessage.C_Messages_content = "";
                                        submitMessage.C_Messages_isValidate = 1;

                                        messageDAL.Add(submitMessage);
                                    }
                                    #endregion
                                }
                            }
                            else if (bCase.B_Case_firstClassResponsiblePerson == formCheck.F_FormCheck_creator)
                            {
                                #region
                                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                //formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;//2015-09-30,hety，注释
                                formCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                //formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;//2015-09-30,hety，注释
                                formCheck.F_FormCheck_checkPerson = formCheck.F_FormCheck_creator;

                                dal.Add(formCheck);

                                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                if (factEndTimeFormProperty != null)
                                {
                                    formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                    businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                    //发送队列消息
                                    MSMQ.SendMessage();
                                }
                                #endregion

                                #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                if (recentySubmitCheck != null)
                                {
                                    if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                    {
                                        creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                        CommonService.Model.C_Messages message = new Model.C_Messages();
                                        message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                        message.C_Messages_link = businessFlow.P_Fk_code;
                                        message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                        message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                        message.C_Messages_isRead = 0;
                                        message.C_Messages_content = "";
                                        message.C_Messages_isValidate = 1;

                                        messageDAL.Add(message);
                                    }
                                }
                                #endregion

                                #endregion
                            }
                            else
                            {
                                #region
                                CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;//2015-09-30,hety，注释
                                //newFormCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                                newFormCheck.F_FormCheck_checkBusinessCode = bCase.B_Case_code;
                                newFormCheck.F_FormCheck_checkPerson = bCase.B_Case_person;
                                newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                dal.Add(newFormCheck);
                                #endregion

                                #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                {
                                    creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                    CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                    submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                    submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                    submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                    submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                    submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                    submitMessage.C_Messages_isRead = 0;
                                    submitMessage.C_Messages_content = "";
                                    submitMessage.C_Messages_isValidate = 1;

                                    messageDAL.Add(submitMessage);
                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region 商机
                        CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessFlow.P_Fk_code.Value);
                        if (businessChance != null)
                        {
                            if (businessChance.B_BusinessChance_person == formCheck.F_FormCheck_creator)
                            {
                                #region
                                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                                formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;

                                dal.Add(formCheck);

                                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                #region 更改当前表单实际结束时间值以及当前表单实际结束时间关联条目统计信息时间值
                                CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                if (factEndTimeFormProperty != null)
                                {
                                    formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                    businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", formCheck.F_FormCheck_checkDate.Value);
                                    //发送队列消息
                                    MSMQ.SendMessage();
                                }
                                #endregion

                                #region 审核通过（当某个人审核通过时，给提交的人发送消息）;审核未通过（当审核未通过时，给提交的人发送消息）
                                CommonService.Model.CustomerForm.F_FormCheck recentySubmitCheck = dal.GetRecentySubmitCheck(businessFlowForm.P_Business_flow_form_code.Value);
                                if (recentySubmitCheck != null)
                                {
                                    if (!creatorRepins.Contains(recentySubmitCheck.F_FormCheck_creator))
                                    {
                                        creatorRepins.Add(recentySubmitCheck.F_FormCheck_creator);

                                        CommonService.Model.C_Messages message = new Model.C_Messages();
                                        message.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                                        message.C_Messages_link = businessFlow.P_Fk_code;
                                        message.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                        message.C_Messages_person = recentySubmitCheck.F_FormCheck_creator;
                                        message.C_Messages_isRead = 0;
                                        message.C_Messages_content = "";
                                        message.C_Messages_isValidate = 1;

                                        messageDAL.Add(message);
                                    }
                                }
                                #endregion

                                #endregion
                            }
                            else
                            {
                                #region
                                CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                newFormCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                                newFormCheck.F_FormCheck_checkPerson = businessChance.B_BusinessChance_person;
                                newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                                newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                                newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                                dal.Add(newFormCheck);
                                #endregion

                                #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                                if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                                {
                                    creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                                    CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                                    submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                    submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                    submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                                    submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                                    submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                                    submitMessage.C_Messages_isRead = 0;
                                    submitMessage.C_Messages_content = "";
                                    submitMessage.C_Messages_isValidate = 1;

                                    messageDAL.Add(submitMessage);
                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
            }
            else
            {
                #region
                CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                newFormCheck.F_FormCheck_code = Guid.NewGuid();
                newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                newFormCheck.F_FormCheck_checkBusinessCode = thisCheckBusinessFlow.P_Flow_parent;
                if (parentCheckBusinessFlow != null)
                {
                    newFormCheck.F_FormCheck_checkPerson = parentCheckBusinessFlow.P_Business_person;
                    nextCheckPerson = newFormCheck.F_FormCheck_checkPerson;
                }
                newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                dal.Add(newFormCheck);
                #endregion

                #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                if (!creatorRepins.Contains(nextCheckPerson))
                {
                    creatorRepins.Add(nextCheckPerson);

                    CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                    submitMessage.C_Messages_fType = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(MessageBigTypeEnum.案件) : Convert.ToInt32(MessageBigTypeEnum.商机);
                    submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                    submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                    submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                    submitMessage.C_Messages_person = nextCheckPerson;
                    submitMessage.C_Messages_isRead = 0;
                    submitMessage.C_Messages_content = "";
                    submitMessage.C_Messages_isValidate = 1;

                    messageDAL.Add(submitMessage);
                }
                #endregion
            }

            return creatorRepins;
            #endregion
        }

        /// <summary>
        /// author:hety
        /// date:2015-09-25
        /// description:
        /// 检查预期收益表单是否已经裁定，如果尚未裁定，则不可以审核此表单
        /// 裁定条件:
        /// (1)、如果财务尚未裁定，则不可以审核表单
        /// (2)、如果财务已裁定，并且对应"预期收益金额"大于等于100000时，这时如果首席专家尚未裁定，则不可以审核表单
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns>返回true，为允许通过；返回false，为不允许通过</returns>
        private bool CheckIsAllowPassYuqishouyiForm(Guid formCode, Guid businessFlowFormCode)
        {
            bool isAllowPass = true;//默认允许通过
            Guid yuqishouyiFormCode = new Guid("128EBF60-F58E-4AE2-B3B7-826DD62A0960");//预期收益计算表单

            if (formCode.ToString().ToUpper() == yuqishouyiFormCode.ToString().ToUpper())
            {
                isAllowPass = false;
                //财务(审核人)属性Guid
                Guid cwCheckPerson = new Guid("1f5a41eb-ed9b-4753-84b9-8277d8eaf8c4");
                //财务(预期收益金额)属性Guid
                Guid cwYuqishouyiMoney = new Guid("6b6bcb4e-7b3a-4cf9-bb5d-37f4a576d752");
                //首席专家(审核人)属性Guid
                Guid sxzjCheckPerson = new Guid("6cda7b58-b098-4597-8847-14d2de3d2956");

                CommonService.Model.CustomerForm.F_FormPropertyValue cwCheckPersonObject = formPropertyValueBll.GetModel(formCode, businessFlowFormCode, cwCheckPerson);
                if (cwCheckPersonObject != null)
                {
                    if (!String.IsNullOrEmpty(cwCheckPersonObject.F_FormPropertyValue_value))
                    {
                        CommonService.Model.CustomerForm.F_FormPropertyValue cwYuqishouyiMoneyObject = formPropertyValueBll.GetModel(formCode, businessFlowFormCode, cwYuqishouyiMoney);
                        if (cwYuqishouyiMoneyObject != null)
                        {
                            decimal cwYuqishouyiConfimMoney = 0.00M;
                            if (decimal.TryParse(cwYuqishouyiMoneyObject.F_FormPropertyValue_value, out cwYuqishouyiConfimMoney))
                            {
                                if (cwYuqishouyiConfimMoney < 100000.00M)
                                {
                                    isAllowPass = true;
                                }
                                else
                                {//金额大于等于100000.00，需要验证首席专家尚是否裁定
                                    CommonService.Model.CustomerForm.F_FormPropertyValue sxzjCheckPersonObject = formPropertyValueBll.GetModel(formCode, businessFlowFormCode, sxzjCheckPerson);
                                    if (sxzjCheckPersonObject != null)
                                    {
                                        if (!String.IsNullOrEmpty(sxzjCheckPersonObject.F_FormPropertyValue_value))
                                        {
                                            isAllowPass = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return isAllowPass;
        }

        /// <summary>
        /// author:hety
        /// date:2015-09-25
        /// description:
        /// 在提交“预期收益计算表单”之后，需要给关联专业顾问发送待审核消息
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        private void SendUnCheckMessageToZygwAfterSubmitYuqishouyiForm(CommonService.Model.CustomerForm.F_FormCheck formCheck, Guid formCode, Guid businessFlowCode)
        {
            CommonService.Model.FlowManager.P_Business_flow businessFlow = businessFlowDAL.GetModel(businessFlowCode);
            if (businessFlow != null)
            {
                Guid caseCode = Guid.Empty;//案件Guid
                if (businessFlow.P_Fk_code != null)
                {
                    caseCode = businessFlow.P_Fk_code.Value;
                }
                DateTime now = DateTime.Now;
                List<CommonService.Model.CaseManager.B_Case_link> caseLinks = caseLinkBLL.GetCaseLinksByCaseAndType(caseCode, Convert.ToInt32(CaselinkEnum.销售顾问));
                foreach (CommonService.Model.CaseManager.B_Case_link caseLink in caseLinks)
                {//实际上一个案件目前只有一个专业顾问
                    CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                    message.C_Messages_link = caseCode;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = caseLink.C_FK_code;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                //增加一条提交纪要(这时候，不赋值下级审核人，因为下级审核人待定，可能为财务，也可能是首席专家)预期收益表单省去中间的审核过程纪要
                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                formCheck.F_FormCheck_checkBusinessCode = caseCode;
                dal.Add(formCheck);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CustomerForm.F_FormCheck model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid F_FormCheck_code)
        {

            return dal.Delete(F_FormCheck_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string F_FormCheck_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(F_FormCheck_idlist, 0));
        }
        /// <summary>
        /// 表单值中是否包含必填项未填写的
        /// </summary>
        /// <param name="businessFlowFormCodes">业务流程表单guid</param>
        /// <returns></returns>
        public bool IsValidate(string businessFlowFormCodes)
        {
            bool isValidate = false;
            string[] businessFlowFormCodesGroup = businessFlowFormCodes.Split(',');
            CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = businessFlowFormDAL.GetModel(new Guid(businessFlowFormCodesGroup[0]));
            List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowFormList = businessFlowFormBLL.erpGetCaseStageFormInfo(businessFlowForm.P_Business_flow_code.Value.ToString());
            foreach (CommonService.Model.FlowManager.P_Business_flow_form item in businessFlowFormList)
            {
                if(businessFlowFormCodesGroup.Contains(item.P_Business_flow_form_code.Value.ToString()))
                {
                    if(!item.Isvalidate)
                    {
                        isValidate = true;
                        break;
                    }
                }
            }
            return isValidate;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormCheck GetModel(Guid F_FormCheck_code)
        {
            return dal.GetModel(F_FormCheck_code);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CustomerForm.F_FormCheck GetModelByFormCodeAndPersonAndCheckDate(Guid business_flow_form_code, Guid checkPerson)
        {
            return dal.GetModelByFormCodeAndPersonAndCheckDate(business_flow_form_code, checkPerson);
        }

        /// <summary>
        /// 根据业务流程表单关联Guid，获取最近表单提交记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public CommonService.Model.CustomerForm.F_FormCheck GetRecentySubmitCheck(Guid businessFlowFormCode)
        {
            return dal.GetRecentySubmitCheck(businessFlowFormCode);
        }

        /// <summary>
        /// 根据业务流程表单关联GUID，获得数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetListByBusinessflowformCode(Guid F_FormCheck_business_flow_form_code)
        {
            return DataTableToList(dal.GetListByBusinessflowformCode(F_FormCheck_business_flow_form_code).Tables[0]);
        }

        /// <summary>
        /// 根据案件Guid或者商机Guid，获取表单尚未审核记录
        /// </summary>
        /// <param name="fkCode">案件Guid或者商机Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetUnCheckRecordByFkCode(Guid fkCode)
        {
            return DataTableToList(dal.GetUnCheckRecordByFkCode(fkCode).Tables[0]);
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
        /// 根据业务流程表单关联Guid，获取首次表单提交记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetFirstTimeFormCheckRecord(Guid businessFlowFormCode)
        {
            DataSet ds = dal.GetFirstTimeFormCheckRecord(businessFlowFormCode);
            return DataTableToList(ds.Tables[0]);
        }


        /// <summary>
        /// 根据业务流程表单关联Guid，获取审核记录
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetFormCheckRecord(Guid businessFlowFormCode)
        {
            DataSet ds = dal.GetFormCheckRecord(businessFlowFormCode);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据流程guid 获取全部提交记录
        /// </summary>
        /// <param name="flowcode"></param>
        /// <returns></returns>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetFirstTimeFormCheckRecordForflowcode(Guid flowcode)
        {
            DataSet ds = dal.GetFirstTimeFormCheckRecordForflowcode(flowcode);
            return DataTableToList(ds.Tables[0]);

        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormCheck> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.CustomerForm.F_FormCheck> modelList = new List<CommonService.Model.CustomerForm.F_FormCheck>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CustomerForm.F_FormCheck model;
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
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.CustomerForm.F_FormCheck model)
        {
            // return dal.GetRecordCount("");
            return 0;
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CustomerForm.F_FormCheck> GetListByPage(CommonService.Model.CustomerForm.F_FormCheck model, string orderby, int startIndex, int endIndex)
        {
            //return dal.GetListByPage("", orderby, startIndex, endIndex);
            return null;
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  App专用

        /// <summary>
        /// 获取最后一次提交的审核列表
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public List<Model.CustomerForm.F_FormCheck> AppGetCheckList(Guid guid)
        {
            return DataTableToList(dal.AppGetCheckList(guid).Tables[0]);
        }

        #endregion
    }
}
