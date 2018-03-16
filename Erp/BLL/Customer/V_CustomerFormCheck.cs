using CommonService.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.Customer
{
    /// <summary>
    /// 虚拟客户表单审核业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/11/30
    /// </summary>
    public partial class V_CustomerFormCheck
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
        /// 客户数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Customer customerDAL = new CommonService.DAL.C_Customer();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CustomerForm.F_FormCheck model)
        {
            return dal.Add(model);
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
        /// 提交表单审核
        /// </summary>
        /// <param name="formChecks">表单审核集合</param>
        /// <returns></returns>
        public int SubmitForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks)
        {          
            ArrayList businessFlowPersonRepins = new ArrayList();//流程负责人集合
            int status = 1;//代表提交成功
            int count = 0;//已提交表单记数(这里需要特殊处理一个不可提交表单的服务端验证逻辑，用"-1"来标识，代表：提交表单所属业务流程及其父级业务流程线上的业务负责人没有设置)
            bool isHasValidatedSetBusinessFlowPerson = false;//是否已经验证过“提交表单所属业务流程及其父级业务流程线上的业务负责人有没有设置过”        
            CommonService.Model.FlowManager.P_Business_flow businessFlow = null;//提交表单关联业务流程数据模型
            /**
             * author:hety
             * date:2015-11-30
             * description:注意：针对同一种消息小类型，同一个人，只可以发送一次消息
             * ************特别提醒：目前表单最上级审核人，只能追溯到客户负责人,尚无追溯到客户首席负责人(如以后需要，则必须对目前现有业务逻辑进行扩展)
             * (1)、只有自定义表单状态为"未提交"或"未通过"时，才可以提交表单
             * (2)、如果提交表单所属业务流程及其父级业务流程线上的业务负责人没有设置，则不可以提交表单
             * (3)、提交表单时，需要赋值当前审核业务流程Guid，当前审核人，以及当前审核状态(如果提交表单时，业务流程线上的负责人或者客户的负责人与提交人一致时，则直接表单审核通过)
             * (4)、给当前审核人发送消息(注意：同一个人不可重复发送审核表单的信息)
             * (5)、如果业务流程下的所有表单审核通过，则结束对应业务流程
             ***/

            foreach (CommonService.Model.CustomerForm.F_FormCheck formCheck in formChecks)
            {
                CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = businessFlowFormDAL.GetModel(formCheck.F_FormCheck_business_flow_form_code.Value);

                if (businessFlowForm != null)
                {
                    #region 处理逻辑(1)
                    if (!(businessFlowForm.P_Business_flow_form_status.Value == Convert.ToInt32(FormStatusEnum.未提交) || businessFlowForm.P_Business_flow_form_status.Value == Convert.ToInt32(FormStatusEnum.未通过)))
                    {
                        continue;
                    }
                    #endregion

                    #region 处理逻辑(2),这里只需要写在这个遍历里，并且只需验证一次(为提高效率)，因为所提交的表单均属于同一个业务流程，要么都通过验证，要么都不能通过验证
                    if (!isHasValidatedSetBusinessFlowPerson)
                    {
                        if (!businessFlowBLL.ExistsBusinessFlowResponsiblePerson(businessFlowForm.P_Business_flow_code.Value))
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

                    //提交表单
                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已提交);
                    businessFlowFormDAL.Update(businessFlowForm);

                    #region 处理逻辑(3)、(4)
                    if (businessFlow == null)
                    {
                        businessFlow = businessFlowDAL.GetModel(businessFlowForm.P_Business_flow_code.Value);
                    }
                    businessFlowPersonRepins = RecursionSubmitForm(formCheck, businessFlowForm, businessFlow, businessFlowPersonRepins);
                    #endregion

                    count++;
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

            #region 处理业务(5)
            if (count > 0)
            {
                if (businessFlow != null)
                {
                    bool isAllFormCheckPass = true;//是否当前业务流程下所有表单审核通过
                    List<CommonService.Model.FlowManager.P_Business_flow_form> RelBusinessFlowForms = businessFlowFormBLL.OnlyGetBusinessFlowForms(businessFlow.P_Business_flow_code.Value);
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
                        //结束当前业务流程
                        businessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                        businessFlow.P_Business_flow_factEndTime = now;
                        businessFlowDAL.Update(businessFlow);                       
                    }
                }
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 递归提交表单审核
        /// </summary>
        /// <param name="formCheck">需审核的表单</param>
        /// <param name="businessFlowForm">需要审核的业务流程表单</param>
        /// <param name="businessFlow">关联业务流程</param>
         /// <param name="businessFlowPersonRepins">消息人集合</param>
        /// <returns></returns>
        public ArrayList RecursionSubmitForm(CommonService.Model.CustomerForm.F_FormCheck formCheck, CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm, CommonService.Model.FlowManager.P_Business_flow businessFlow,ArrayList businessFlowPersonRepins)
        {
            if (formCheck.F_FormCheck_creator != businessFlow.P_Business_person)
            {//当前审核人是否为相关业务流程的负责人（否）
                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;

                dal.Add(formCheck);

                if (!businessFlowPersonRepins.Contains(businessFlow.P_Business_person))
                {//仅需要给流程负责人发一条需要审核的消息
                    businessFlowPersonRepins.Add(businessFlow.P_Business_person);
                    #region 给当前表单审核人发送消息
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
            {//当前审核人是否为相关业务流程的负责人（是）
                if (businessFlowForm.P_Business_flow_form_isDefault == 1)
                {//默认表单(及其必审表单)
                    #region
                    if (businessFlow.P_Flow_parent != null)
                    {
                        CommonService.Model.FlowManager.P_Business_flow businessFlowParent = businessFlowDAL.GetModel(businessFlow.P_Flow_parent.Value);
                        if (businessFlowParent != null)
                        {
                            businessFlowPersonRepins = RecursionSubmitForm(formCheck, businessFlowForm, businessFlowParent, businessFlowPersonRepins);
                        }
                    }
                    else
                    {
                        #region 代表上一级审核人为客户负责人审核
                        CommonService.Model.C_Customer customer = customerDAL.GetModel(businessFlow.P_Fk_code.Value);
                        if (customer != null)
                        {
                            if (customer.C_Customer_responsiblePerson == formCheck.F_FormCheck_creator)
                            {//当前审核人为客户负责人
                                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                formCheck.F_FormCheck_checkBusinessCode = customer.C_Customer_code;
                                formCheck.F_FormCheck_checkPerson = customer.C_Customer_responsiblePerson;
                                formCheck.F_FormCheck_checkDate = formCheck.F_FormCheck_createTime;

                                dal.Add(formCheck);

                                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);

                                #region 更改当前表单实际结束时间值
                                CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                if (factEndTimeFormProperty != null)
                                {                                     
                                    formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                                #endregion

                                businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                            }
                            else
                            {//当前审核人不为客户负责人
                                formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                formCheck.F_FormCheck_checkBusinessCode = customer.C_Customer_code;
                                formCheck.F_FormCheck_checkPerson = customer.C_Customer_responsiblePerson;

                                dal.Add(formCheck);

                                if (!businessFlowPersonRepins.Contains(customer.C_Customer_responsiblePerson))
                                {
                                    businessFlowPersonRepins.Add(customer.C_Customer_responsiblePerson);

                                    #region 给当前审核人发送消息
                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                    message.C_Messages_link = businessFlow.P_Fk_code;
                                    message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                                    message.C_Messages_person = customer.C_Customer_responsiblePerson;
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
                else
                {
                    #region
                    if (businessFlow.P_Business_flow_auditType == Convert.ToInt32(BusinessFlowAuditType.仅监控当前预设流程))
                    {
                        formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                        formCheck.F_FormCheck_checkBusinessCode = businessFlowForm.P_Business_flow_code;
                        formCheck.F_FormCheck_checkPerson = businessFlow.P_Business_person;
                        formCheck.F_FormCheck_checkDate = formCheck.F_FormCheck_createTime;

                        dal.Add(formCheck);

                        businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                        businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);

                        #region 更改当前表单实际结束时间值
                        CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                        if (factEndTimeFormProperty != null)
                        {
                            formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
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
                                businessFlowPersonRepins = RecursionSubmitForm(formCheck, businessFlowForm, businessFlowParent, businessFlowPersonRepins);
                            }
                        }
                        else
                        {
                            #region 代表上一级审核人为客户负责人审核
                            CommonService.Model.C_Customer customer = customerDAL.GetModel(businessFlow.P_Fk_code.Value);
                            if (customer != null)
                            {
                                if (customer.C_Customer_responsiblePerson == formCheck.F_FormCheck_creator)
                                {//当前审核人也为客户负责人
                                    formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                    formCheck.F_FormCheck_checkBusinessCode = customer.C_Customer_code;
                                    formCheck.F_FormCheck_checkPerson = customer.C_Customer_responsiblePerson;
                                    formCheck.F_FormCheck_checkDate = formCheck.F_FormCheck_createTime;

                                    dal.Add(formCheck);

                                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                    businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);

                                    #region 更改当前表单实际结束时间值
                                    CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                    if (factEndTimeFormProperty != null)
                                    {                                         
                                        formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));  
                                    }
                                    #endregion

                                    businessFlowFormDAL.Update(businessFlowForm);//更改表单状态
                                }
                                else
                                {//当前审核人不为客户负责人
                                    formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                                    formCheck.F_FormCheck_checkBusinessCode = customer.C_Customer_code;
                                    formCheck.F_FormCheck_checkPerson = customer.C_Customer_responsiblePerson;

                                    dal.Add(formCheck);

                                    if (!businessFlowPersonRepins.Contains(customer.C_Customer_responsiblePerson))
                                    {
                                        businessFlowPersonRepins.Add(customer.C_Customer_responsiblePerson);

                                        #region 给当前审核人发送消息
                                        CommonService.Model.C_Messages message = new Model.C_Messages();
                                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                                        message.C_Messages_link = businessFlow.P_Fk_code;
                                        message.C_Messages_createTime = formCheck.F_FormCheck_createTime;
                                        message.C_Messages_person = customer.C_Customer_responsiblePerson;
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
                    }
                    #endregion
                }
            }

            return businessFlowPersonRepins;
        }

        /// <summary>
        /// 审核表单
        /// </summary>
        /// <param name="formChecks">表单审核集合</param>
        /// <returns></returns>
        public int CheckForm(List<CommonService.Model.CustomerForm.F_FormCheck> formChecks)
        {                      
            int status = 1;//代表审核成功
            int count = 0;//审核表单记数
            ArrayList creatorRepins = new ArrayList();//审核人集合
            /**
             * author:hety
             * date:2015-12-01
             * description:注意：针对同一种消息小类型，同一个人，只可以发送一次消息；另外在审核表单时，如果待审核表单，业务流程线上的负责人或者客户的负责人与审核人一致时，则直接表单审核通过)
             * ************特别提醒：目前表单最上级审核人，只能追溯到客户负责人,尚无追溯到客户首席负责人(如以后需要，则必须对目前现有业务逻辑进行扩展)
             * (1)、只有已提交审核的业务流程表单，才可以进行审核
             * (2)、当前审核人(登录人)必须与预先设置好的默认审核人一致时，才可以进行审核            
             * (3)、如果业务流程关联表单为默认表单(及必审表单)，则必须由一级负责人及其流程线上的其他级别审核人审核
             * (4)、如果业务流程关联表单所属业务流程为“仅监控当前流程”，此时“主协办律师”提交审核后，该业务流程的负责人进行审核，审核通过，该表单就算通过
             * (5)、如果业务流程关联表单所属业务流程为“完全监控”，此时，提交审核的表单应该一级一级向上提交并审核，一直到“客户负责人”审核通过后，表单才能算是通过，中途如果遇到未通过，表单状态直接更改为未通过，可重新提交审核。
             * (6)、表单审核通过时，会更新"表单实际结束时间"值
             * (7)、当业务流程上的所有表单审核通过时，需要修改当前业务流程状态为"已结束"以及业务流程"实际结束时间"          
             **/
            DateTime? checkFormTime = null;//审核时间
            Guid? checkPerson = null;//审核人
            if (formChecks.FirstOrDefault() != null)
            {
                checkFormTime = formChecks.FirstOrDefault().F_FormCheck_checkDate;
                checkPerson = formChecks.FirstOrDefault().F_FormCheck_creator;
            }           
            CommonService.Model.FlowManager.P_Business_flow businessFlow = null;//待审核表单所属业务流程数据模型
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

                #region 处理问题(3)、(4)、(5)、(6)
                if (businessFlow == null)
                {
                    businessFlow = businessFlowDAL.GetModel(businessFlowForm.P_Business_flow_code.Value);//表单所属业务流程对象
                }              
                if (businessFlow == null) continue;                
                if (businessFlowForm.P_Business_flow_form_isDefault == 1)
                {
                    #region 默认表单(必审表单)
                    creatorRepins = RecursionCheckForm(formCheck, maxTimeFormCheck, businessFlowForm, businessFlow,creatorRepins);
                    count++;
                    #endregion
                }
                else
                {
                    if (businessFlow.P_Business_flow_auditType == Convert.ToInt32(BusinessFlowAuditType.仅监控当前预设流程))
                    {
                        #region 审核"仅监控当前预设流程"表单业务逻辑
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

                            #region 更改当前表单实际结束时间值
                            CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                            if (factEndTimeFormProperty != null)
                            {
                                formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
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
                                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
                        creatorRepins = RecursionCheckForm(formCheck, maxTimeFormCheck, businessFlowForm, businessFlow, creatorRepins);
                        count++;
                    }
                }
                #endregion
            }

            #region 处理问题(7)
            if (count != 0 && businessFlow != null)
            {
                bool isAllFormCheckPass = true;//是否当前业务流程下所有表单审核通过
                List<CommonService.Model.FlowManager.P_Business_flow_form> RelBusinessFlowForms = businessFlowFormBLL.OnlyGetBusinessFlowForms(businessFlow.P_Business_flow_code.Value);
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
                    //结束当前业务流程
                    businessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                    businessFlow.P_Business_flow_factEndTime = checkFormTime;
                    businessFlowDAL.Update(businessFlow);                     
                }
            }
            #endregion

            if (count == 0)
            {
                status = 0;//代表没有符合条件可以审核的表单
            }
            return status;
        }

        /// <summary>
        /// 递归审核表单
        /// </summary>
        /// <param name="formCheck">WCF传入审核对象</param>
        /// <param name="maxTimeFormCheck">最近一条需要审核的记录对象</param>
        /// <param name="businessFlowForm">业务流程关联表单对象</param>
        /// <param name="businessFlow">业务流程对象</param>
        private ArrayList RecursionCheckForm(CommonService.Model.CustomerForm.F_FormCheck formCheck, CommonService.Model.CustomerForm.F_FormCheck maxTimeFormCheck, CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm, CommonService.Model.FlowManager.P_Business_flow businessFlow, ArrayList creatorRepins)
        {           
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
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
                #region 这种情况需要层层往上提交，直到所属客户负责人审核通过，表单才可以审核通过
                CommonService.Model.FlowManager.P_Business_flow thisCheckBusinessFlow = businessFlowDAL.GetModel(maxTimeFormCheck.F_FormCheck_checkBusinessCode.Value);//当前审核信息关联业务流程对象
                if (thisCheckBusinessFlow == null)
                {//代表业务流程线上的审核人均已审核通过，这时需要对应客户负责人审核,并且改变表单状态为"已通过"
                    #region 此种情况表单审核结束
                    CommonService.Model.C_Customer customer = customerDAL.GetModel(businessFlow.P_Fk_code.Value);
                    //if (formCheck.F_FormCheck_creator == customer.C_Customer_responsiblePerson)
                    //{
                        //formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                        //formCheck.F_FormCheck_checkBusinessCode = customer.C_Customer_code;
                        //formCheck.F_FormCheck_checkPerson = customer.C_Customer_responsiblePerson;

                        //dal.Add(formCheck);                                   

                        businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                        businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                        businessFlowFormDAL.Update(businessFlowForm);//更改表单状态

                        #region 更改当前表单实际结束时间值
                        CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                        if (factEndTimeFormProperty != null)
                        {
                            formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
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
                                message.C_Messages_fType =Convert.ToInt32(MessageBigTypeEnum.客户);
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
                    //}
                    //else
                    //{
                    //    #region 提交上级表单审核人
                    //    CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                    //    newFormCheck.F_FormCheck_code = Guid.NewGuid();
                    //    newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                    //    newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                    //    newFormCheck.F_FormCheck_checkBusinessCode = maxTimeFormCheck.F_FormCheck_checkBusinessCode;
                    //    if (customer.C_Customer_responsiblePerson != null)
                    //    {
                    //        newFormCheck.F_FormCheck_checkPerson = customer.C_Customer_responsiblePerson;
                    //    }
                    //    newFormCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.未审核);
                    //    newFormCheck.F_FormCheck_isDelete = formCheck.F_FormCheck_isDelete;
                    //    newFormCheck.F_FormCheck_creator = formCheck.F_FormCheck_creator;
                    //    newFormCheck.F_FormCheck_createTime = formCheck.F_FormCheck_createTime;

                    //    dal.Add(newFormCheck);
                    //    #endregion

                    //    #region 表单审核（当表单提交审核给某个人时，给这个“某个人”发送消息）
                    //    if (!creatorRepins.Contains(newFormCheck.F_FormCheck_checkPerson))
                    //    {
                    //        creatorRepins.Add(newFormCheck.F_FormCheck_checkPerson);

                    //        CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                    //        submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                    //        submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                    //        submitMessage.C_Messages_link = businessFlow.P_Fk_code;
                    //        submitMessage.C_Messages_createTime = formCheck.F_FormCheck_checkDate;
                    //        submitMessage.C_Messages_person = newFormCheck.F_FormCheck_checkPerson;
                    //        submitMessage.C_Messages_isRead = 0;
                    //        submitMessage.C_Messages_content = "";
                    //        submitMessage.C_Messages_isValidate = 1;

                    //        messageDAL.Add(submitMessage);
                    //    }
                    //    #endregion
                    //}
                    #endregion
                }
                else
                {
                    Guid? nextCheckPerson = null;//下一个环节审核人Guid
                    if (thisCheckBusinessFlow.P_Flow_parent != null)
                    {
                        creatorRepins = ParentRecursionCheckForm(formCheck, thisCheckBusinessFlow, businessFlowForm, businessFlow, creatorRepins);
                    }
                    else
                    {
                        #region 代表上一级审核人为客户负责人审核                                      
                        CommonService.Model.C_Customer customer = customerDAL.GetModel(businessFlow.P_Fk_code.Value);
                        if (customer != null)
                        {
                            if (customer.C_Customer_responsiblePerson == formCheck.F_FormCheck_creator)
                            {
                                #region 这种情况表单审核直接结束
                                //formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                                //formCheck.F_FormCheck_checkBusinessCode = customer.C_Customer_code;
                                //formCheck.F_FormCheck_checkPerson = customer.C_Customer_responsiblePerson;

                                //dal.Add(formCheck);

                                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                businessFlowFormDAL.Update(businessFlowForm);//更改表单状态

                                #region 更改当前表单实际结束时间值
                                CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                if (factEndTimeFormProperty != null)
                                {
                                    formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
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
                                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
                                #region 提交表单审核人
                                CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                                newFormCheck.F_FormCheck_code = Guid.NewGuid();
                                newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                                newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                                newFormCheck.F_FormCheck_checkBusinessCode = customer.C_Customer_code;
                                newFormCheck.F_FormCheck_checkPerson = customer.C_Customer_responsiblePerson;
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
                                    submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
                }
                #endregion
            }
            return creatorRepins;             
        }

        /// <summary>
        /// 递归处理上级审核人
        /// </summary>
        /// <param name="formCheck"></param>
        /// <param name="thisCheckBusinessFlow"></param>
        /// <param name="businessFlowForm"></param>
        /// <param name="businessFlow"></param>
        /// <param name="creatorRepins"></param>
        /// <returns></returns>
        public ArrayList ParentRecursionCheckForm(CommonService.Model.CustomerForm.F_FormCheck formCheck, CommonService.Model.FlowManager.P_Business_flow thisCheckBusinessFlow, CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm, CommonService.Model.FlowManager.P_Business_flow businessFlow, ArrayList creatorRepins)
        {
            //当前审核信息关联业务流程上一级对象
            CommonService.Model.FlowManager.P_Business_flow parentCheckBusinessFlow = businessFlowDAL.GetModel(thisCheckBusinessFlow.P_Flow_parent.Value);
            Guid? nextCheckPerson = null;//下一个环节审核人Guid
            if (formCheck.F_FormCheck_creator == parentCheckBusinessFlow.P_Business_person)
            {
                if (parentCheckBusinessFlow.P_Flow_parent != null)
                {
                    creatorRepins = ParentRecursionCheckForm(formCheck, parentCheckBusinessFlow, businessFlowForm, businessFlow, creatorRepins);
                }
                else
                {
                    #region 代表上一级审核人为客户负责人审核
                    //获取表单所属业务流程关联流程对象
                    
                    CommonService.Model.C_Customer customer = customerDAL.GetModel(businessFlow.P_Fk_code.Value);
                    if (customer != null)
                    {
                        if (customer.C_Customer_responsiblePerson == formCheck.F_FormCheck_creator)
                        {
                            #region 这种情况表单审核结束
                            //formCheck.F_FormCheck_state = Convert.ToInt32(FormCheckStatusEnum.通过);
                            //formCheck.F_FormCheck_checkBusinessCode = customer.C_Customer_code;
                            //formCheck.F_FormCheck_checkPerson = customer.C_Customer_responsiblePerson;

                            //dal.Add(formCheck);

                            businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                            businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                            businessFlowFormDAL.Update(businessFlowForm);//更改表单状态

                            #region 更改当前表单实际结束时间值
                            CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                            if (factEndTimeFormProperty != null)
                            {
                                formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, formCheck.F_FormCheck_checkDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));  
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
                                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
                            #region 提交下一级表单审核人
                            CommonService.Model.CustomerForm.F_FormCheck newFormCheck = new Model.CustomerForm.F_FormCheck();
                            newFormCheck.F_FormCheck_code = Guid.NewGuid();
                            newFormCheck.F_FormCheck_business_flow_form_code = formCheck.F_FormCheck_business_flow_form_code;
                            newFormCheck.F_FormCheck_isFirstSubmit = formCheck.F_FormCheck_isFirstSubmit;
                            newFormCheck.F_FormCheck_checkBusinessCode = customer.C_Customer_code;
                            newFormCheck.F_FormCheck_checkPerson = customer.C_Customer_responsiblePerson;
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
                                submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
            }
            else
            {
                #region 提交上级业务流程审核信息
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
                    submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
        }


    }
}
