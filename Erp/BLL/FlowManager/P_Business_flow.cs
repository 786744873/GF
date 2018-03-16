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
    /// 业务流程表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/18
    /// </summary>
    public partial class P_Business_flow
    {
        #region 。。。。。
        private readonly CommonService.DAL.FlowManager.P_Business_flow dal = new CommonService.DAL.FlowManager.P_Business_flow();
        /// <summary>
        /// 表单属性数据访问类
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_FormProperty formPropertyDAL = new CommonService.DAL.CustomerForm.F_FormProperty();
        /// <summary>
        /// 表单属性值业务访问层
        /// </summary>
        private readonly CommonService.BLL.CustomerForm.F_FormPropertyValue formPropertyValueBll = new CommonService.BLL.CustomerForm.F_FormPropertyValue();
        /// <summary>
        /// 业务流程关联表单数据访问类
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow_form businessFlowFormDAL = new CommonService.DAL.FlowManager.P_Business_flow_form(); 
        /// <summary>
        /// 业务流程关联表单业务逻辑类
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow_form businessFlowFormBLL = new CommonService.BLL.FlowManager.P_Business_flow_form();
        /// <summary>
        /// 业务流程-表单-用户数据访问类
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow_form_user businessFlowFormUserDAL = new CommonService.DAL.FlowManager.P_Business_flow_form_user();
        /// <summary>
        /// 流程关联表单业务访问类
        /// </summary>
        private CommonService.BLL.FlowManager.P_Flow_form flowFormBLL = new CommonService.BLL.FlowManager.P_Flow_form();
        /// <summary>
        /// 业务流程关联表单业务访问类
        /// </summary>
        private CommonService.BLL.FlowManager.P_Business_flow_form businesssFlowFormBLL = new CommonService.BLL.FlowManager.P_Business_flow_form();
        /// <summary>
        /// 业务流程申请记录业务逻辑层
        /// </summary>
        private CommonService.BLL.FlowManager.P_Business_flow_applyRecord businessFlowApplyRecordBLL = new CommonService.BLL.FlowManager.P_Business_flow_applyRecord();
        /// <summary>
        /// 消息数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();
        /// <summary>
        /// 客户数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Customer customerDAL = new DAL.C_Customer();
        /// <summary>
        /// 业务流程关联表单关联用户业务逻辑层
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow_form_user businessFlowFormUserBLL = new CommonService.BLL.FlowManager.P_Business_flow_form_user();
        /// <summary>
        /// 商机数据访问层
        /// </summary>
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance businessChanceDAL = new CommonService.DAL.BusinessChanceManager.B_BusinessChance();
        /// <summary>
        /// 表单审核数据访问层
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_FormCheck formCheckDAL = new CommonService.DAL.CustomerForm.F_FormCheck();
        /// <summary>
        /// 业务流程申请记录数据访问层
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow_applyRecord businessFlowApplyRecordDAL = new CommonService.DAL.FlowManager.P_Business_flow_applyRecord();
        private readonly CommonService.BLL.CaseManager.B_Case_Confirm confirmBLL = new CommonService.BLL.CaseManager.B_Case_Confirm();
        #endregion

        public P_Business_flow()
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
        public bool Exists(int P_Business_flow_id)
        {
            return dal.Exists(P_Business_flow_id);
        }

        /// <summary>
        /// 检查当前业务流程及其父亲业务流程，是否都设置了负责人
        /// </summary>
        /// <param name="businessFlowCode">当前业务流程Guid</param>
        /// <returns></returns>
        public bool ExistsBusinessFlowResponsiblePerson(Guid businessFlowCode)
        {
            /*
             * author:hety
             * date:2015-11-23
             * description:检查当前业务流程及其父亲业务流程，是否都设置了负责人
             */
            bool isHasSet = false;

            CommonService.Model.FlowManager.P_Business_flow businessFlow = this.GetModel(businessFlowCode);
            if (businessFlow != null)
            {
                if (businessFlow.P_Business_person != null)
                {
                    if (businessFlow.P_Flow_parent != null)
                    {
                        isHasSet = this.RecursionExistsBusinessFlowResponsiblePerson(businessFlow.P_Flow_parent.Value);
                    }
                    else
                    {
                        isHasSet = true;
                    }
                }
            }

            return isHasSet;
        }

        /// <summary>
        /// 递归检查当前业务流程及其父亲业务流程，是否都设置了负责人
        /// </summary>
        /// <param name="parentBusinessFlowCode">父亲业务流程</param>
        private bool RecursionExistsBusinessFlowResponsiblePerson(Guid parentBusinessFlowCode)
        {
            bool isHasSet = false;
            CommonService.Model.FlowManager.P_Business_flow businessFlow = this.GetModel(parentBusinessFlowCode);
            if (businessFlow != null)
            {
                if (businessFlow.P_Business_person != null)
                {
                    if (businessFlow.P_Flow_parent != null)
                    {
                        isHasSet = this.RecursionExistsBusinessFlowResponsiblePerson(businessFlow.P_Flow_parent.Value);
                    }
                    else
                    {
                        isHasSet = true;
                    }
                }
            }

            return isHasSet;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByFkCodeAndFlowCode(Guid P_Fk_code, Guid P_Flow_code,int type)
        {
            return dal.ExistsByFkCodeAndFlowCode(P_Fk_code, P_Flow_code,type);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">业务流程数据模型</param>
        /// <param name="flowType">流程类型(案件或者商机)</param> 
        /// <returns></returns>
        public int Add(CommonService.Model.FlowManager.P_Business_flow model, int flowType)
        {
            #region 新增业务流程时，插入流程关联默认表单以及默认表单属性值，同时生成条目统计信息(生成条目只针对案件)
            List<CommonService.Model.FlowManager.P_Flow_form> FlowForms = flowFormBLL.GetListByFlowCode(model.P_Flow_code.Value, 1);
            int flowFormOrder = 0;
            foreach (CommonService.Model.FlowManager.P_Flow_form flowForm in FlowForms)
            {
                flowFormOrder++;
                CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = new Model.FlowManager.P_Business_flow_form();
                businessFlowForm.P_Business_flow_form_code = Guid.NewGuid();
                businessFlowForm.P_Business_flow_code = model.P_Business_flow_code;
                businessFlowForm.F_Form_code = flowForm.F_Form_code;
                businessFlowForm.P_Business_flow_form_order = flowFormOrder;
                businessFlowForm.P_Business_flow_form_isDefault = 1;
                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.未提交);
                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.未开始);
                businessFlowForm.P_Business_flow_form_person = model.P_Business_person;
                businessFlowForm.P_Business_flow_form_isdelete = 0;
                businessFlowForm.P_Business_flow_form_creator = model.P_Business_creator;
                businessFlowForm.P_Business_flow_form_createTime = DateTime.Now;
                businessFlowForm.P_Business_flow_form_isPlan = false;
                businessFlowFormDAL.Add(businessFlowForm);
                //初始化默认表单属性值
                formPropertyValueBll.InitializationFormPropertyValue(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, model.P_Business_creator.Value);
                //设置表单计划开始时间、计划结束时间为对应业务流程的计划开始时间和计划结束时间
                #region(2)、
                //处理"计划开始时间"属性           
                if (model.P_Business_flow_planStartTime != null)
                {
                    CommonService.Model.CustomerForm.F_FormProperty planStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "planStartTime");
                    if (planStartTimeFormProperty != null)
                    {
                        formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, planStartTimeFormProperty.F_FormProperty_code.Value, model.P_Business_flow_planStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                    }
                }
                //处理"计划结束时间"属性实体
                if (model.P_Business_flow_planEndTime != null)
                {
                    CommonService.Model.CustomerForm.F_FormProperty planEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "planEndTime");
                    if (planEndTimeFormProperty != null)
                    {
                        formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, planEndTimeFormProperty.F_FormProperty_code.Value, model.P_Business_flow_planEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                    }
                }
                #endregion

                //生成条目统计信息(起点流程+起点表单)(只针对案件)
                if (flowType == Convert.ToInt32(FlowTypeEnum.案件))
                {
                    businessFlowFormDAL.GenerateEntryStatisticsByAddForm(model.P_Fk_code.Value, Convert.ToInt32(FlowTypeEnum.案件), model.P_Flow_code.Value, businessFlowForm.F_Form_code.Value, model.P_Business_creator.Value);
                }
            }
            #endregion

            if (model.P_Flow_parent == null)
            {//根业务流程添加
                model.P_Business_flow_level = 1;
                CommonService.Model.FlowManager.P_Business_flow maxOrderModel = dal.GetMaxOrderModelByLevel(model.P_Business_flow_level.Value, model.P_Fk_code.Value);
                model.P_Business_order = maxOrderModel == null ? 1 : maxOrderModel.P_Business_order.Value + 1;
            }
            else
            {
                CommonService.Model.FlowManager.P_Business_flow parentModel = dal.GetModel(model.P_Flow_parent.Value);
                model.P_Business_flow_level = parentModel.P_Business_flow_level + 1;
                CommonService.Model.FlowManager.P_Business_flow maxOrderModel = dal.GetMaxOrderModelByParent(model.P_Flow_parent.Value);
                model.P_Business_order = maxOrderModel == null ? 1 : maxOrderModel.P_Business_order.Value + 1;
            }
            //新增流程时，生成对应条目统计信息(起点流程)(只针对案件)
            if (flowType == Convert.ToInt32(FlowTypeEnum.案件))
            {
                dal.GenerateEntryStatisticsByAddBusinessFlow(model.P_Fk_code.Value, Convert.ToInt32(FlowTypeEnum.案件), model.P_Flow_code.Value, model.P_Business_creator.Value);
            }

            #region 如果设置了业务流程"计划开始时间"或者"计划结束时间",则需要修改关联条目统计表中时间值信息(只针对案件)
            if (flowType == Convert.ToInt32(FlowTypeEnum.案件))
            {
                if (model.P_Business_flow_planStartTime != null)
                {//计划开始时间
                    dal.UpdateEntryStatisticsByBusinessFlowTime(model.P_Business_flow_code.Value, "planStartTime", model.P_Business_flow_planStartTime.Value);
                    MSMQ.SendMessage();
                }
                if (model.P_Business_flow_planEndTime != null)
                {//计划结束时间
                    dal.UpdateEntryStatisticsByBusinessFlowTime(model.P_Business_flow_code.Value, "planEndTime", model.P_Business_flow_planEndTime.Value);
                    MSMQ.SendMessage();
                }
            }
            #endregion

            #region 只针对商机
            if (flowType == Convert.ToInt32(FlowTypeEnum.商机))
            {
                this.DealBusinessChanceBeforeAddBusinessFlow(model);
            }
            #endregion

            #region 只针对客户
            if (flowType == Convert.ToInt32(FlowTypeEnum.客户))
            {
                this.DealCustomerBeforeAddBusinessFlow(model);
            }
            #endregion

            return dal.Add(model);
        }

        /// <summary>
        /// 在商机业务流程增加之前，处理相关业务逻辑
        /// </summary>
        /// <param name="businessFlow">业务流程数据模型</param>       
        private void DealBusinessChanceBeforeAddBusinessFlow(CommonService.Model.FlowManager.P_Business_flow businessFlow)
        {
            /**
             * author:hety
             * date:2015-10-22
             * description:
             * (1)、新增业务流程申请记录表数据，如果申请人与商机负责人是同一个人，则需要赋值"审查人"、"审查时间"等值
             * (2)、在新增业务流程时，如果申请人与商机负责人不是同一个人，则需要发送消息给商机负责人
             * (3)、在新增业务流程时，如果申请人与商机负责人是同一个人，则不需要发送消息给商机负责人
             * (4)、在新增业务流程时，如果申请人与商机负责人是同一个人，则业务流程"申请状态"变更为"配置通过"           
             * (5)、保存业务流程申请记录
             * 
             ***/

            Guid applyUser = businessFlow.P_Business_creator.Value;//申请人赋值为创建人
            DateTime now = DateTime.Now;//当前时间
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessFlow.P_Fk_code.Value);//关联商机
            string applyDetail = String.Empty;//申请详细
            string auditDetail = String.Empty;//审查详细

            #region 处理业务(1)
            applyDetail = "申请配置" + businessFlow.P_Business_flow_name;//默认"申请配置"
            CommonService.Model.FlowManager.P_Business_flow_applyRecord businessFlowApplyRecord = new Model.FlowManager.P_Business_flow_applyRecord();
            businessFlowApplyRecord.P_Business_flow_applyRecord_code = Guid.NewGuid();
            businessFlowApplyRecord.P_Business_flow_applyRecord_creator = applyUser;
            businessFlowApplyRecord.P_Business_flow_applyRecord_createTime = now;
            businessFlowApplyRecord.P_Business_flow_applyRecord_isDelete = false;
            businessFlowApplyRecord.P_Business_flow_applyRecord_recordType = Convert.ToInt32(BusinessFlowRecordTypeEnum.配置);
            businessFlowApplyRecord.P_Business_flow_applyRecord_businessFlow = businessFlow.P_Business_flow_code;
            businessFlowApplyRecord.P_Business_flow_applyRecord_applyUser = applyUser;
            businessFlowApplyRecord.P_Business_flow_applyRecord_applyTime = now;
            businessFlowApplyRecord.P_Business_flow_applyRecord_applyDetail = applyDetail;
            #endregion

            #region 处理业务(2)、(3)、(4)
            if (businessChance != null)
            {
                if (businessChance.B_BusinessChance_person != null)
                {
                    if (businessChance.B_BusinessChance_person.Value.ToString().ToLower() == applyUser.ToString().ToLower())
                    {
                        #region 申请人与商机负责人是同一个人
                        auditDetail = "配置通过" + businessFlow.P_Business_flow_name;//默认"配置通过"
                        businessFlow.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.配置通过);
                        businessFlowApplyRecord.P_Business_flow_applyRecord_auditUser = applyUser;
                        businessFlowApplyRecord.P_Business_flow_applyRecord_auditTime = now;
                        businessFlowApplyRecord.P_Business_flow_applyRecord_auditDetail = auditDetail;
                        #endregion
                    }
                    else
                    {
                        #region 申请人与商机负责人不是同一个人
                        CommonService.Model.C_Messages message = new Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.商机配置);
                        message.C_Messages_link = businessChance.B_BusinessChance_code;
                        message.C_Messages_createTime = now;
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

            #region 处理业务(5)
            businessFlowApplyRecordDAL.Add(businessFlowApplyRecord);
            #endregion

        }

        /// <summary>
        /// 在客户业务流程增加之前，处理相关业务逻辑
        /// </summary>
        /// <param name="businessFlow">业务流程数据模型</param>       
        private void DealCustomerBeforeAddBusinessFlow(CommonService.Model.FlowManager.P_Business_flow businessFlow)
        {
            /**
             * author:hety
             * date:2015-11-25
             * description:
             * (1)、新增业务流程申请记录表数据，如果申请人与客户负责人是同一个人，则需要赋值"审查人"、"审查时间"等值
             * (2)、在新增业务流程时，如果申请人与客户负责人不是同一个人，则需要发送消息给客户负责人
             * (3)、在新增业务流程时，如果申请人与客户负责人是同一个人，则不需要发送消息给客户负责人
             * (4)、在新增业务流程时，如果申请人与客户负责人是同一个人，则业务流程"申请状态"变更为"配置通过"           
             * (5)、保存业务流程申请记录
             * 
             ***/

            Guid applyUser = businessFlow.P_Business_creator.Value;//申请人赋值为创建人
            DateTime now = DateTime.Now;//当前时间
            CommonService.Model.C_Customer customer = customerDAL.GetModel(businessFlow.P_Fk_code.Value);//关联客户
            string applyDetail = String.Empty;//申请详细
            string auditDetail = String.Empty;//审查详细

            #region 处理业务(1)
            applyDetail = "申请配置" + businessFlow.P_Business_flow_name;//默认"申请配置"
            CommonService.Model.FlowManager.P_Business_flow_applyRecord businessFlowApplyRecord = new Model.FlowManager.P_Business_flow_applyRecord();
            businessFlowApplyRecord.P_Business_flow_applyRecord_code = Guid.NewGuid();
            businessFlowApplyRecord.P_Business_flow_applyRecord_creator = applyUser;
            businessFlowApplyRecord.P_Business_flow_applyRecord_createTime = now;
            businessFlowApplyRecord.P_Business_flow_applyRecord_isDelete = false;
            businessFlowApplyRecord.P_Business_flow_applyRecord_recordType = Convert.ToInt32(BusinessFlowRecordTypeEnum.配置);
            businessFlowApplyRecord.P_Business_flow_applyRecord_businessFlow = businessFlow.P_Business_flow_code;
            businessFlowApplyRecord.P_Business_flow_applyRecord_applyUser = applyUser;
            businessFlowApplyRecord.P_Business_flow_applyRecord_applyTime = now;
            businessFlowApplyRecord.P_Business_flow_applyRecord_applyDetail = applyDetail;
            #endregion

            #region 处理业务(2)、(3)、(4)
            if (customer != null)
            {
                if (customer.C_Customer_responsiblePerson != null)
                {
                    if (customer.C_Customer_responsiblePerson.Value.ToString().ToLower() == applyUser.ToString().ToLower())
                    {
                        #region 申请人与客户负责人是同一个人
                        auditDetail = "配置通过" + businessFlow.P_Business_flow_name;//默认"配置通过"
                        businessFlow.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.配置通过);
                        businessFlowApplyRecord.P_Business_flow_applyRecord_auditUser = applyUser;
                        businessFlowApplyRecord.P_Business_flow_applyRecord_auditTime = now;
                        businessFlowApplyRecord.P_Business_flow_applyRecord_auditDetail = auditDetail;
                        #endregion
                    }
                    else
                    {
                        #region 申请人与商机负责人不是同一个人
                        CommonService.Model.C_Messages message = new Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.客户配置);
                        message.C_Messages_link = customer.C_Customer_code;
                        message.C_Messages_createTime = now;
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

            #region 处理业务(5)
            businessFlowApplyRecordDAL.Add(businessFlowApplyRecord);
            #endregion

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">业务流程数据模型</param>
        /// <param name="type">类型：1代表案件；2代表商机;3代表客户</param>
        /// <returns></returns>
        public bool Update(CommonService.Model.FlowManager.P_Business_flow model, int type)
        {
            #region 更新业务流程时，如果对应关联流程发生了变化，则要先删除业务流程关联表单以及默认表单属性值，然后从新插入默认流程关联表单以及默认表单属性值
            CommonService.Model.FlowManager.P_Business_flow oldBusinessFlow = dal.GetModel(model.P_Business_flow_code.Value);
            if (!oldBusinessFlow.P_Flow_code.ToString().Equals(model.P_Flow_code.ToString()))
            {
                #region 删除业务流程关联表单用户数据以及关联表单属性值数据
                List<CommonService.Model.FlowManager.P_Business_flow_form> OriginalBusinessFlowForms = businesssFlowFormBLL.OnlyGetBusinessFlowForms(model.P_Business_flow_code.Value);
                foreach (CommonService.Model.FlowManager.P_Business_flow_form originalBusinessFlowForm in OriginalBusinessFlowForms)
                {
                    //删除关联表单属性值
                    formPropertyValueBll.Delete(originalBusinessFlowForm.F_Form_code.Value, originalBusinessFlowForm.P_Business_flow_form_code.Value);
                    //删除业务流程关联表单用户
                    businessFlowFormUserDAL.DeleteByBusinessFlowFormCode(originalBusinessFlowForm.P_Business_flow_form_code.Value);
                }
                #endregion
                //删除业务流程关联表单数据
                businessFlowFormDAL.DeleteByBusinessFlowCode(model.P_Business_flow_code.Value);

                #region 对应关联流程发生了变化，需要把原有流程关联的条目统计信息删除，然后按新流程重新生成条目统计信息(起点流程)(只针对案件)
                if (type == 1)
                {
                    dal.DeleteEntryStatisticsByBusinessFlowCode(model.P_Business_flow_code.Value);
                    dal.GenerateEntryStatisticsByAddBusinessFlow(model.P_Fk_code.Value, Convert.ToInt32(FlowTypeEnum.案件), model.P_Flow_code.Value, model.P_Business_creator.Value);
                }
                #endregion

                //新增，新增时的排序列，从数据库表里已对应的基础上进行累加
                int flowFormOrder = 0;
                CommonService.Model.FlowManager.P_Business_flow_form maxOrderBusinessFlowForm = businessFlowFormDAL.GetMaxOrderModel(model.P_Business_flow_code.Value);
                if (maxOrderBusinessFlowForm != null)
                {
                    flowFormOrder = maxOrderBusinessFlowForm.P_Business_flow_form_order.Value;
                }

                List<CommonService.Model.FlowManager.P_Flow_form> FlowForms = flowFormBLL.GetListByFlowCode(model.P_Flow_code.Value, 1);
                foreach (CommonService.Model.FlowManager.P_Flow_form flowForm in FlowForms)
                {
                    flowFormOrder++;
                    CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = new Model.FlowManager.P_Business_flow_form();
                    businessFlowForm.P_Business_flow_form_code = Guid.NewGuid();
                    businessFlowForm.P_Business_flow_code = model.P_Business_flow_code;
                    businessFlowForm.F_Form_code = flowForm.F_Form_code;
                    businessFlowForm.P_Business_flow_form_order = flowFormOrder;
                    businessFlowForm.P_Business_flow_form_isDefault = 1;
                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.未提交);
                    businessFlowForm.P_Business_flow_form_isdelete = 0;
                    businessFlowForm.P_Business_flow_form_creator = model.P_Business_creator;
                    businessFlowForm.P_Business_flow_form_createTime = DateTime.Now;
                    businessFlowForm.P_Business_flow_form_isPlan = false;

                    businessFlowFormDAL.Add(businessFlowForm);

                    //初始化默认表单属性值
                    formPropertyValueBll.InitializationFormPropertyValue(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, model.P_Business_creator.Value);
                    //设置表单计划开始时间、计划结束时间为对应业务流程的计划开始时间和计划结束时间

                    #region(2)、
                    //处理"计划开始时间"属性           
                    if (model.P_Business_flow_planStartTime != null)
                    {
                        CommonService.Model.CustomerForm.F_FormProperty planStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "planStartTime");
                        if (planStartTimeFormProperty != null)
                        {
                            formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, planStartTimeFormProperty.F_FormProperty_code.Value, model.P_Business_flow_planStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                        }
                    }
                    //处理"计划结束时间"属性实体
                    if (model.P_Business_flow_planEndTime != null)
                    {
                        CommonService.Model.CustomerForm.F_FormProperty planEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "planEndTime");
                        if (planEndTimeFormProperty != null)
                        {
                            formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, planEndTimeFormProperty.F_FormProperty_code.Value, model.P_Business_flow_planEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                        }
                    }
                    #endregion

                    //生成条目统计信息(起点流程+起点表单)(只针对案件)
                    if (type == 1)
                    {
                        businessFlowFormDAL.GenerateEntryStatisticsByAddForm(model.P_Fk_code.Value, Convert.ToInt32(FlowTypeEnum.案件), model.P_Flow_code.Value, businessFlowForm.F_Form_code.Value, model.P_Business_creator.Value);
                    }
                }
            }
            #endregion

            #region 修改流程负责人，当案件已经启动，给修改后的负责人发送消息
            if (!oldBusinessFlow.P_Business_person.ToString().Equals(model.P_Business_person.ToString()))
            {
                if (model.P_Business_state == Convert.ToInt32(BusinessFlowStatus.正在进行))
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    if (type == 1)
                    {
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    }
                    else if (type == 2)
                    {
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    }
                    else if (type == 3)
                    {
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                    }
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.流程启动);
                    message.C_Messages_link = model.P_Fk_code;
                    message.C_Messages_createTime = DateTime.Now;
                    message.C_Messages_person = model.P_Business_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                #region  修改流程负责人之后给未设定的表单修改审核人
                businessFlowFormDAL.UpdatePersonisPlanNo(new Guid(model.P_Business_flow_code.ToString()), new Guid(model.P_Business_person.ToString()));
                #endregion

                #region 修改流程负责人之后将原负责人需要审核的表单给修改后的负责人
                if (oldBusinessFlow.P_Business_person != null)
                {
                    CommonService.Model.CustomerForm.F_FormCheck formCheck = formCheckDAL.GetModelByCheckBusinessCodeAndCheckPerson(model.P_Business_flow_code.Value, oldBusinessFlow.P_Business_person.Value);
                    if (formCheck != null)
                    {
                        formCheck.F_FormCheck_checkPerson = model.P_Business_person;
                        formCheckDAL.Update(formCheck);

                        CommonService.Model.C_Messages message = new Model.C_Messages();
                        if (type == 1)
                        {
                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                        }
                        else if (type == 2)
                        {
                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                        }
                        else if (type == 3)
                        {
                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                        }
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                        message.C_Messages_link = model.P_Fk_code;
                        message.C_Messages_createTime = DateTime.Now;
                        message.C_Messages_person = model.P_Business_person;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;

                        messageDAL.Add(message);
                    }
                }

                #endregion
            }
            #endregion

            #region 修改时，为了保证数据的完整性，无论业务流程的"计划开始时间"或者"计划结束时间"是否更改,都需要修改关联条目统计表中时间值信息(只针对案件)
            if (type == 1)
            {
                //计划开始时间
                if (model.P_Business_flow_planStartTime != null)
                {
                    dal.UpdateEntryStatisticsByBusinessFlowTime(model.P_Business_flow_code.Value, "planStartTime", model.P_Business_flow_planStartTime.Value);
                }
                //计划结束时间
                if (model.P_Business_flow_planEndTime != null)
                {
                    dal.UpdateEntryStatisticsByBusinessFlowTime(model.P_Business_flow_code.Value, "planEndTime", model.P_Business_flow_planEndTime.Value);
                }
                MSMQ.SendMessage();
            }
            #endregion

            return dal.Update(model);
        }

        /// <summary>
        /// 向前移动
        /// </summary>
        /// <param name="fkCode">业务外键Guid</param>          
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public bool MoveForward(Guid fkCode, Guid businessFlowCode)
        {
            /**
             **作者：贺太玉
             **2015/05/15
             **业务说明：1,先获的当前业务流程的显示顺序号；2,获取向前移动一个顺序单位的业务流程对象；3,当前需要移动的业务流程与向前一个单位的业务流程交互顺序号；4,如果已经移动到第一位，则不可以再继续
             *移动；4,显示顺序号不可以重复
             **/
            CommonService.Model.FlowManager.P_Business_flow thisBusinessFlow = dal.GetModel(businessFlowCode);
            CommonService.Model.FlowManager.P_Business_flow forwardBusinessFlow = dal.GetModel(fkCode, ConditonType.小于, thisBusinessFlow.P_Business_order.Value, thisBusinessFlow.P_Business_flow_level.Value, thisBusinessFlow.P_Flow_parent);
            if (forwardBusinessFlow != null)
            {
                int thisBusinessFlowOrderBy = thisBusinessFlow.P_Business_order.Value;
                int forwardBusinessFlowOrderBy = forwardBusinessFlow.P_Business_order.Value;
                thisBusinessFlow.P_Business_order = forwardBusinessFlowOrderBy;
                dal.Update(thisBusinessFlow);
                forwardBusinessFlow.P_Business_order = thisBusinessFlowOrderBy;
                dal.Update(forwardBusinessFlow);
            }
            return true;
        }

        /// <summary>
        /// 向后移动
        /// </summary>
        /// <param name="fkCode">业务外键Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>      
        /// <returns></returns>
        public bool MoveBackward(Guid fkCode, Guid businessFlowCode)
        {
            /**
             **作者：贺太玉
             **2015/05/15
             **业务说明：1,先获的当前业务流程的显示顺序号；2,获取向后移动一个顺序单位的业务流程对象；3,当前需要移动的业务流程与向后一个单位的业务流程交互顺序号；4,如果已经移动到最后一位，则不可以再继续
             *移动；4,显示顺序号不可以重复
            **/
            CommonService.Model.FlowManager.P_Business_flow thisBusinessFlow = dal.GetModel(businessFlowCode);
            CommonService.Model.FlowManager.P_Business_flow backwardBusinessFlow = dal.GetModel(fkCode, ConditonType.大于, thisBusinessFlow.P_Business_order.Value, thisBusinessFlow.P_Business_flow_level.Value, thisBusinessFlow.P_Flow_parent);
            if (backwardBusinessFlow != null)
            {
                int thisBusinessFlowOrderBy = thisBusinessFlow.P_Business_order.Value;
                int backwardBusinessFlowOrderBy = backwardBusinessFlow.P_Business_order.Value;
                thisBusinessFlow.P_Business_order = backwardBusinessFlowOrderBy;
                dal.Update(thisBusinessFlow);
                backwardBusinessFlow.P_Business_order = thisBusinessFlowOrderBy;
                dal.Update(backwardBusinessFlow);
            }
            return true;
        }

        /// <summary>
        /// 启动业务流程
        /// </summary>
        /// <param name="businessFlows">需要启动的业务流程集合</param>
        /// <returns></returns>     
        public int StartBusinessFlow(List<CommonService.Model.FlowManager.P_Business_flow> businessFlows, string fkType)
        {
            ArrayList businessFlowRespins = new ArrayList();//业务流程负责人集合
            ArrayList businessFlowFormRespins = new ArrayList();//业务流程关联表单负责人集合
            ArrayList businessFlowFormUserRespins = new ArrayList();//业务流程关联表单协办律师集合
            int status = 0;
            /*
             * author:hety
             * date:2015-06-15
             * description:
             * (1)、只有"未开始的"业务流程才可以启动
             * (2)、需要更新当前业务流程关联表单的状态以及"实际开始时间"
             * (3)、需要根据"实际开始时间"更新业务流程关联条目统计信息的时间值,以及更新业务流程表单关联条目统计信息的时间值
             * (4)、启动业务流程时，给业务流程的负责人发送消息
             * (5)、启动表单时，给表单的主办律师以及协办律师发送消息
             **/
            foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in businessFlows)
            {
                CommonService.Model.FlowManager.P_Business_flow oldBusinessFlow = dal.GetModel(businessFlow.P_Business_flow_code.Value);
                if (oldBusinessFlow != null)
                {
                    if (oldBusinessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.未开始) || oldBusinessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        oldBusinessFlow.P_Business_startPerson = businessFlow.P_Business_startPerson;
                        oldBusinessFlow.P_Business_startTime = businessFlow.P_Business_startTime;
                        oldBusinessFlow.P_Business_flow_factStartTime = businessFlow.P_Business_flow_factStartTime;
                        oldBusinessFlow.P_Business_startReason = businessFlow.P_Business_startReason;
                        oldBusinessFlow.P_Business_state = businessFlow.P_Business_state;
                        dal.Update(oldBusinessFlow);

                        if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                        {
                            SetSingleParentBusinessFlow(oldBusinessFlow);//启动父级流程
                            SetSingleChiledBusinessFlow(oldBusinessFlow);//启动子集流程

                            #region 业务流程启动时，给业务流程负责人发送消息
                            if (oldBusinessFlow.P_Business_person != null)
                            {
                                if (!businessFlowRespins.Contains(oldBusinessFlow.P_Business_person.ToString()))
                                {//处理启用不用业务流程时，如果业务流程负责人出现重复的情况，只需要发一条消息
                                    businessFlowRespins.Add(oldBusinessFlow.P_Business_person.ToString());

                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.流程启动);
                                    message.C_Messages_link = oldBusinessFlow.P_Fk_code;
                                    message.C_Messages_createTime = businessFlow.P_Business_flow_factStartTime;
                                    message.C_Messages_person = oldBusinessFlow.P_Business_person;
                                    message.C_Messages_isRead = 0;
                                    message.C_Messages_content = "";
                                    message.C_Messages_isValidate = 1;

                                    messageDAL.Add(message);
                                }
                            }
                            #endregion

                            #region 更新业务流程关联条目统计信息时间值
                            //业务流程实际开始时间
                            dal.UpdateEntryStatisticsByBusinessFlowTime(businessFlow.P_Business_flow_code.Value, "factStartTime", businessFlow.P_Business_flow_factStartTime.Value);
                            #endregion

                            #region 处理关联表单业务
                            List<CommonService.Model.FlowManager.P_Business_flow_form> bffs = businesssFlowFormBLL.OnlyGetBusinessFlowForms(businessFlow.P_Business_flow_code.Value);
                            foreach (var bff in bffs)
                            {
                                //启动业务流程关联表单
                                bff.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                                businessFlowFormDAL.Update(bff);
                                //更改表单实际开始时间,并且更新业务流程表单关联条目统计信息时间值
                                CommonService.Model.CustomerForm.F_FormProperty factStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(bff.F_Form_code.Value, "factStartTime");
                                if (factStartTimeFormProperty != null)
                                {
                                    formPropertyValueBll.Update(bff.F_Form_code.Value, bff.P_Business_flow_form_code.Value, factStartTimeFormProperty.F_FormProperty_code.Value, businessFlow.P_Business_flow_factStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                    businessFlowFormDAL.UpdateEntryStatisticsByFormTime(bff.P_Business_flow_form_code.Value, "factStartTime", businessFlow.P_Business_flow_factStartTime.Value);
                                }

                                #region 启动表单时，给表单的主办律师发送消息
                                if (bff.P_Business_flow_form_person != null)
                                {
                                    if (!businessFlowFormRespins.Contains(bff.P_Business_flow_form_person.ToString()))
                                    {//处理启用不同表单时，如果表单主办律师出现重复的情况，只需要发一条消息
                                        businessFlowFormRespins.Add(bff.P_Business_flow_form_person.ToString());

                                        CommonService.Model.C_Messages message = new Model.C_Messages();
                                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                                        message.C_Messages_link = oldBusinessFlow.P_Fk_code;
                                        message.C_Messages_createTime = businessFlow.P_Business_flow_factStartTime;
                                        message.C_Messages_person = bff.P_Business_flow_form_person;
                                        message.C_Messages_isRead = 0;
                                        message.C_Messages_content = "";
                                        message.C_Messages_isValidate = 1;

                                        messageDAL.Add(message);
                                    }
                                }
                                #endregion

                                #region 启动表单时，给表单的协办律师发送消息
                                List<CommonService.Model.FlowManager.P_Business_flow_form_user> BusinessFlowFormUsers = businessFlowFormUserBLL.GetListByBusinessFlowFormCode(bff.P_Business_flow_form_code.Value);
                                foreach (CommonService.Model.FlowManager.P_Business_flow_form_user businessFlowFormUser in BusinessFlowFormUsers)
                                {
                                    if (!businessFlowFormUserRespins.Contains(businessFlowFormUser.P_Business_flow_form_user_user))
                                    {
                                        businessFlowFormUserRespins.Add(businessFlowFormUser.P_Business_flow_form_user_user);

                                        CommonService.Model.C_Messages message = new Model.C_Messages();
                                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                                        message.C_Messages_link = oldBusinessFlow.P_Fk_code;
                                        message.C_Messages_createTime = businessFlow.P_Business_flow_factStartTime; ;
                                        message.C_Messages_person = businessFlowFormUser.P_Business_flow_form_user_user;
                                        message.C_Messages_isRead = 0;
                                        message.C_Messages_content = "";
                                        message.C_Messages_isValidate = 1;

                                        messageDAL.Add(message);
                                    }
                                }
                                #endregion
                            }
                            #endregion

                            status = 1;
                        }
                        else
                        {
                            #region 商机处理
                            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(oldBusinessFlow.P_Fk_code.Value);
                            List<CommonService.Model.FlowManager.P_Business_flow> businessFlowlist = GetListByFkCode(businessChance.B_BusinessChance_code.Value);
                            if (oldBusinessFlow.P_Business_flow_applicationStatus == Convert.ToInt32(BusinessFlowApplicationStatueType.未提交))
                            {
                                bool IsApplicationStatue = true;
                                foreach (CommonService.Model.FlowManager.P_Business_flow business_Flow in businessFlowlist)
                                {
                                    if (business_Flow.P_Business_flow_applicationStatus == Convert.ToInt32(BusinessFlowApplicationStatueType.已提交))
                                    {
                                        IsApplicationStatue = false;
                                    }
                                    break;
                                }
                                if (IsApplicationStatue)
                                {
                                    oldBusinessFlow.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.已提交);
                                    dal.Update(oldBusinessFlow);

                                    #region 申请启动流程时，给商机负责人发送消息
                                    if (businessChance.B_BusinessChance_person != null)
                                    {
                                        CommonService.Model.C_Messages message = new Model.C_Messages();
                                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.进入下一流程);
                                        message.C_Messages_link = oldBusinessFlow.P_Fk_code;
                                        message.C_Messages_createTime = DateTime.Now;
                                        message.C_Messages_person = businessChance.B_BusinessChance_person;
                                        message.C_Messages_isRead = 0;
                                        message.C_Messages_content = "";
                                        message.C_Messages_isValidate = 1;

                                        messageDAL.Add(message);
                                    }
                                    #endregion

                                    status = 1;
                                }
                            }
                            else if (oldBusinessFlow.P_Business_flow_applicationStatus == Convert.ToInt32(BusinessFlowApplicationStatueType.已通过))
                            {
                                foreach (CommonService.Model.FlowManager.P_Business_flow business_Flow in businessFlowlist)
                                {
                                    if (business_Flow.P_Business_flow_applicationStatus == Convert.ToInt32(BusinessFlowApplicationStatueType.已提交))
                                    {
                                        //结束流程
                                        oldBusinessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                        oldBusinessFlow.P_Business_flow_factEndTime = DateTime.Now;
                                        //oldBusinessFlow.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.已通过);
                                        dal.Update(oldBusinessFlow);

                                        #region 审核流程通过时，给申请人发送消息
                                        if (businessChance.B_BusinessChance_person != null)
                                        {
                                            CommonService.Model.C_Messages message = new Model.C_Messages();
                                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过流程);
                                            message.C_Messages_link = oldBusinessFlow.P_Fk_code;
                                            message.C_Messages_createTime = DateTime.Now;
                                            message.C_Messages_person = oldBusinessFlow.P_Business_person;
                                            message.C_Messages_isRead = 0;
                                            message.C_Messages_content = "";
                                            message.C_Messages_isValidate = 1;

                                            messageDAL.Add(message);
                                        }
                                        #endregion

                                        List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms = businesssFlowFormBLL.OnlyGetBusinessFlowForms(oldBusinessFlow.P_Business_flow_code.Value);
                                        foreach (CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm in businessFlowForms)
                                        {
                                            if (businessFlowForm.P_Business_flow_form_status != Convert.ToInt32(FormStatusEnum.已通过))
                                            {
                                                businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                                                businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);

                                                #region 更新表单实际结束时间
                                                CommonService.Model.CustomerForm.F_FormProperty planEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                                                if (planEndTimeFormProperty != null)
                                                {
                                                    formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, planEndTimeFormProperty.F_FormProperty_code.Value, oldBusinessFlow.P_Business_flow_factEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                                    businessFlowFormDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", oldBusinessFlow.P_Business_flow_factEndTime.Value);
                                                    MSMQ.SendMessage();
                                                }
                                                #endregion

                                                businessFlowFormDAL.Update(businessFlowForm);
                                            }
                                        }

                                        business_Flow.P_Business_startTime = DateTime.Now;
                                        business_Flow.P_Business_flow_factStartTime = DateTime.Now;
                                        business_Flow.P_Business_startReason = "";
                                        business_Flow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                                        business_Flow.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.已通过);
                                        dal.Update(business_Flow);

                                        #region 业务流程启动时，给业务流程负责人发送消息
                                        if (business_Flow.P_Business_person != null)
                                        {
                                            CommonService.Model.C_Messages message = new Model.C_Messages();
                                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.流程启动);
                                            message.C_Messages_link = business_Flow.P_Fk_code;
                                            message.C_Messages_createTime = business_Flow.P_Business_flow_factStartTime;
                                            message.C_Messages_person = business_Flow.P_Business_person;
                                            message.C_Messages_isRead = 0;
                                            message.C_Messages_content = "";
                                            message.C_Messages_isValidate = 1;

                                            messageDAL.Add(message);
                                        }
                                        #endregion

                                        #region 更新业务流程关联条目统计信息时间值
                                        //业务流程实际开始时间
                                        dal.UpdateEntryStatisticsByBusinessFlowTime(business_Flow.P_Business_flow_code.Value, "factStartTime", business_Flow.P_Business_flow_factStartTime.Value);
                                        #endregion

                                        #region 处理关联表单业务
                                        List<CommonService.Model.FlowManager.P_Business_flow_form> bffs = businesssFlowFormBLL.OnlyGetBusinessFlowForms(business_Flow.P_Business_flow_code.Value);
                                        foreach (var bff in bffs)
                                        {
                                            //启动业务流程关联表单
                                            bff.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                                            businessFlowFormDAL.Update(bff);
                                            //更改表单实际开始时间,并且更新业务流程表单关联条目统计信息时间值
                                            CommonService.Model.CustomerForm.F_FormProperty factStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(bff.F_Form_code.Value, "factStartTime");
                                            if (factStartTimeFormProperty != null)
                                            {
                                                formPropertyValueBll.Update(bff.F_Form_code.Value, bff.P_Business_flow_form_code.Value, factStartTimeFormProperty.F_FormProperty_code.Value, business_Flow.P_Business_flow_factStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                                businessFlowFormDAL.UpdateEntryStatisticsByFormTime(bff.P_Business_flow_form_code.Value, "factStartTime", business_Flow.P_Business_flow_factStartTime.Value);
                                            }

                                            #region 启动表单时，给表单的主办律师发送消息
                                            if (bff.P_Business_flow_form_person != null)
                                            {
                                                if (!businessFlowFormRespins.Contains(bff.P_Business_flow_form_person.ToString()))
                                                {//处理启用不同表单时，如果表单主办律师出现重复的情况，只需要发一条消息
                                                    businessFlowFormRespins.Add(bff.P_Business_flow_form_person.ToString());

                                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                                                    message.C_Messages_link = business_Flow.P_Fk_code;
                                                    message.C_Messages_createTime = business_Flow.P_Business_flow_factStartTime;
                                                    message.C_Messages_person = bff.P_Business_flow_form_person;
                                                    message.C_Messages_isRead = 0;
                                                    message.C_Messages_content = "";
                                                    message.C_Messages_isValidate = 1;

                                                    messageDAL.Add(message);
                                                }
                                            }
                                            #endregion

                                            #region 启动表单时，给表单的协办律师发送消息
                                            List<CommonService.Model.FlowManager.P_Business_flow_form_user> BusinessFlowFormUsers = businessFlowFormUserBLL.GetListByBusinessFlowFormCode(bff.P_Business_flow_form_code.Value);
                                            foreach (CommonService.Model.FlowManager.P_Business_flow_form_user businessFlowFormUser in BusinessFlowFormUsers)
                                            {
                                                if (!businessFlowFormUserRespins.Contains(businessFlowFormUser.P_Business_flow_form_user_user))
                                                {
                                                    businessFlowFormUserRespins.Add(businessFlowFormUser.P_Business_flow_form_user_user);

                                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                                                    message.C_Messages_link = business_Flow.P_Fk_code;
                                                    message.C_Messages_createTime = business_Flow.P_Business_flow_factStartTime; ;
                                                    message.C_Messages_person = businessFlowFormUser.P_Business_flow_form_user_user;
                                                    message.C_Messages_isRead = 0;
                                                    message.C_Messages_content = "";
                                                    message.C_Messages_isValidate = 1;

                                                    messageDAL.Add(message);
                                                }
                                            }
                                            #endregion
                                        }
                                        #endregion

                                        status = 1;
                                        break;
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
            }

            if (status != 0)
            {
                //发送队列消息
                MSMQ.SendMessage();
            }

            return status;
        }

        private void SetSingleParentBusinessFlow(CommonService.Model.FlowManager.P_Business_flow oldBusinessFlow)
        {
            ArrayList businessFlowFormRespins = new ArrayList();//业务流程关联表单负责人集合
            ArrayList businessFlowFormUserRespins = new ArrayList();//业务流程关联表单协办律师集合
            if (oldBusinessFlow.P_Flow_parent != null)
            {
                //判断该业务流程的父级业务流程是否为空
                CommonService.Model.FlowManager.P_Business_flow businessFlowParent = dal.GetModel(oldBusinessFlow.P_Flow_parent.Value);
                if (businessFlowParent != null)
                {
                    //判断父级流程是否启动
                    if (businessFlowParent.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        businessFlowParent.P_Business_startPerson = oldBusinessFlow.P_Business_startPerson;
                        businessFlowParent.P_Business_startTime = oldBusinessFlow.P_Business_startTime;
                        businessFlowParent.P_Business_flow_factStartTime = oldBusinessFlow.P_Business_flow_factStartTime;
                        businessFlowParent.P_Business_startReason = oldBusinessFlow.P_Business_startReason;
                        businessFlowParent.P_Business_state = oldBusinessFlow.P_Business_state;
                        dal.Update(businessFlowParent);

                        #region 业务流程启动时，给业务流程负责人发送消息
                        if (businessFlowParent.P_Business_person != null)
                        {
                            CommonService.Model.C_Messages message = new Model.C_Messages();
                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.流程启动);
                            message.C_Messages_link = businessFlowParent.P_Fk_code;
                            message.C_Messages_createTime = oldBusinessFlow.P_Business_flow_factStartTime;
                            message.C_Messages_person = businessFlowParent.P_Business_person;
                            message.C_Messages_isRead = 0;
                            message.C_Messages_content = "";
                            message.C_Messages_isValidate = 1;

                            messageDAL.Add(message);
                        }
                        #endregion

                        #region 更新业务流程关联条目统计信息时间值
                        //业务流程实际开始时间
                        dal.UpdateEntryStatisticsByBusinessFlowTime(oldBusinessFlow.P_Business_flow_code.Value, "factStartTime", oldBusinessFlow.P_Business_flow_factStartTime.Value);
                        #endregion

                        #region 处理关联表单业务
                        List<CommonService.Model.FlowManager.P_Business_flow_form> bffs = businesssFlowFormBLL.OnlyGetBusinessFlowForms(businessFlowParent.P_Business_flow_code.Value);
                        foreach (var bff in bffs)
                        {
                            //启动业务流程关联表单
                            bff.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                            businessFlowFormDAL.Update(bff);
                            //更改表单实际开始时间,并且更新业务流程表单关联条目统计信息时间值
                            CommonService.Model.CustomerForm.F_FormProperty factStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(bff.F_Form_code.Value, "factStartTime");
                            if (factStartTimeFormProperty != null)
                            {
                                formPropertyValueBll.Update(bff.F_Form_code.Value, bff.P_Business_flow_form_code.Value, factStartTimeFormProperty.F_FormProperty_code.Value, businessFlowParent.P_Business_flow_factStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                businessFlowFormDAL.UpdateEntryStatisticsByFormTime(bff.P_Business_flow_form_code.Value, "factStartTime", businessFlowParent.P_Business_flow_factStartTime.Value);
                            }

                            #region 启动表单时，给表单的主办律师发送消息
                            if (bff.P_Business_flow_form_person != null)
                            {
                                if (!businessFlowFormRespins.Contains(bff.P_Business_flow_form_person))
                                {
                                    businessFlowFormRespins.Add(bff.P_Business_flow_form_person);

                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                                    message.C_Messages_link = businessFlowParent.P_Fk_code;
                                    message.C_Messages_createTime = businessFlowParent.P_Business_flow_factStartTime;
                                    message.C_Messages_person = bff.P_Business_flow_form_person;
                                    message.C_Messages_isRead = 0;
                                    message.C_Messages_content = "";
                                    message.C_Messages_isValidate = 1;

                                    messageDAL.Add(message);
                                }
                            }
                            #endregion

                            #region 启动表单时，给表单的协办律师发送消息
                            List<CommonService.Model.FlowManager.P_Business_flow_form_user> BusinessFlowFormUsers = businessFlowFormUserBLL.GetListByBusinessFlowFormCode(bff.P_Business_flow_form_code.Value);
                            foreach (CommonService.Model.FlowManager.P_Business_flow_form_user businessFlowFormUser in BusinessFlowFormUsers)
                            {
                                if (!businessFlowFormUserRespins.Contains(businessFlowFormUser.P_Business_flow_form_user_user))
                                {
                                    businessFlowFormUserRespins.Add(businessFlowFormUser.P_Business_flow_form_user_user);

                                    CommonService.Model.C_Messages message = new Model.C_Messages();
                                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                                    message.C_Messages_link = businessFlowParent.P_Fk_code;
                                    message.C_Messages_createTime = businessFlowParent.P_Business_flow_factStartTime; ;
                                    message.C_Messages_person = businessFlowFormUser.P_Business_flow_form_user_user;
                                    message.C_Messages_isRead = 0;
                                    message.C_Messages_content = "";
                                    message.C_Messages_isValidate = 1;

                                    messageDAL.Add(message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        SetSingleChiledBusinessFlow(businessFlowParent);
                    }

                    SetSingleParentBusinessFlow(businessFlowParent);
                }
            }

        }

        private void SetSingleChiledBusinessFlow(CommonService.Model.FlowManager.P_Business_flow oldBusinessFlow)
        {
            ArrayList businessFlowFormRespins = new ArrayList();//业务流程关联表单负责人集合
            ArrayList businessFlowFormUserRespins = new ArrayList();//业务流程关联表单协办律师集合
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = GetListByParentCode(oldBusinessFlow.P_Business_flow_code.Value);
            if (businessFlows.Count() != 0)
            {
                CommonService.Model.FlowManager.P_Business_flow business_Flow = businessFlows.First();
                if (business_Flow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.未开始))
                {
                    business_Flow.P_Business_startPerson = oldBusinessFlow.P_Business_startPerson;
                    business_Flow.P_Business_startTime = oldBusinessFlow.P_Business_startTime;
                    business_Flow.P_Business_flow_factStartTime = oldBusinessFlow.P_Business_flow_factStartTime;
                    business_Flow.P_Business_startReason = oldBusinessFlow.P_Business_startReason;
                    business_Flow.P_Business_state = oldBusinessFlow.P_Business_state;
                    dal.Update(business_Flow);

                    #region 业务流程启动时，给业务流程负责人发送消息
                    if (business_Flow.P_Business_person != null)
                    {
                        CommonService.Model.C_Messages message = new Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.流程启动);
                        message.C_Messages_link = business_Flow.P_Fk_code;
                        message.C_Messages_createTime = business_Flow.P_Business_flow_factStartTime;
                        message.C_Messages_person = business_Flow.P_Business_person;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;

                        messageDAL.Add(message);
                    }
                    #endregion

                    #region 更新业务流程关联条目统计信息时间值
                    //业务流程实际开始时间
                    dal.UpdateEntryStatisticsByBusinessFlowTime(oldBusinessFlow.P_Business_flow_code.Value, "factStartTime", oldBusinessFlow.P_Business_flow_factStartTime.Value);
                    #endregion

                    #region 处理关联表单业务
                    List<CommonService.Model.FlowManager.P_Business_flow_form> bffs = businesssFlowFormBLL.OnlyGetBusinessFlowForms(business_Flow.P_Business_flow_code.Value);
                    foreach (var bff in bffs)
                    {
                        //启动业务流程关联表单
                        bff.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                        businessFlowFormDAL.Update(bff);
                        //更改表单实际开始时间,并且更新业务流程表单关联条目统计信息时间值
                        CommonService.Model.CustomerForm.F_FormProperty factStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(bff.F_Form_code.Value, "factStartTime");
                        if (factStartTimeFormProperty != null)
                        {
                            formPropertyValueBll.Update(bff.F_Form_code.Value, bff.P_Business_flow_form_code.Value, factStartTimeFormProperty.F_FormProperty_code.Value, business_Flow.P_Business_flow_factStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            businessFlowFormDAL.UpdateEntryStatisticsByFormTime(bff.P_Business_flow_form_code.Value, "factStartTime", business_Flow.P_Business_flow_factStartTime.Value);
                        }

                        #region 启动表单时，给表单的主办律师发送消息
                        if (bff.P_Business_flow_form_person != null)
                        {
                            if (!businessFlowFormRespins.Contains(bff.P_Business_flow_form_person))
                            {
                                businessFlowFormRespins.Add(bff.P_Business_flow_form_person);

                                CommonService.Model.C_Messages message = new Model.C_Messages();
                                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                                message.C_Messages_link = business_Flow.P_Fk_code;
                                message.C_Messages_createTime = business_Flow.P_Business_flow_factStartTime;
                                message.C_Messages_person = bff.P_Business_flow_form_person;
                                message.C_Messages_isRead = 0;
                                message.C_Messages_content = "";
                                message.C_Messages_isValidate = 1;

                                messageDAL.Add(message);
                            }
                        }
                        #endregion

                        #region 启动表单时，给表单的协办律师发送消息
                        List<CommonService.Model.FlowManager.P_Business_flow_form_user> BusinessFlowFormUsers = businessFlowFormUserBLL.GetListByBusinessFlowFormCode(bff.P_Business_flow_form_code.Value);
                        foreach (CommonService.Model.FlowManager.P_Business_flow_form_user businessFlowFormUser in BusinessFlowFormUsers)
                        {
                            if (!businessFlowFormUserRespins.Contains(businessFlowFormUser.P_Business_flow_form_user_user))
                            {
                                businessFlowFormUserRespins.Add(businessFlowFormUser.P_Business_flow_form_user_user);

                                CommonService.Model.C_Messages message = new Model.C_Messages();
                                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                                message.C_Messages_link = business_Flow.P_Fk_code;
                                message.C_Messages_createTime = business_Flow.P_Business_flow_factStartTime;
                                message.C_Messages_person = businessFlowFormUser.P_Business_flow_form_user_user;
                                message.C_Messages_isRead = 0;
                                message.C_Messages_content = "";
                                message.C_Messages_isValidate = 1;

                                messageDAL.Add(message);
                            }
                        }
                        #endregion
                    }
                    #endregion
                }

                SetSingleChiledBusinessFlow(business_Flow);
            }
        }

        /// <summary>
        /// 删除一条数据(删除时，需要流程关联的条目统计信息删除)
        /// </summary>
        public bool Delete(Guid businessFlowCode)
        {
            bool isSuccess = dal.Delete(businessFlowCode);
            dal.DeleteEntryStatisticsByBusinessFlowCode(businessFlowCode);

            #region 删除关联子集业务流程
            if (isSuccess)
            {
                List<CommonService.Model.FlowManager.P_Business_flow> BusinessFlows = GetListByParentCode(businessFlowCode);
                foreach (CommonService.Model.FlowManager.P_Business_flow childrenBusinessFlow in BusinessFlows)
                {
                    dal.Delete(childrenBusinessFlow.P_Business_flow_code.Value);
                    dal.DeleteEntryStatisticsByBusinessFlowCode(childrenBusinessFlow.P_Business_flow_code.Value);
                    RecursionDelete(childrenBusinessFlow.P_Business_flow_code.Value);
                }
            }
            #endregion

            return isSuccess;
        }

        /// <summary>
        /// 同意业务流程申请配置
        /// </summary>
        /// <param name="fkType">流程类型(客户或者商机)</param>
        /// <param name="fkCode">业务Guid(客户Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作用户Guid</param>
        /// <returns></returns>       
        public bool AgreeBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            bool isSuccess = false;

            /**
             * author:hety
             * date:2015-10-23
             * description:目前此业务只针对商机或客户
             * (1)、更改业务流程"申请状态"为"配置通过"
             * (2)、赋值业务流程申请记录中的"审查项"
             * (3)、发送消息给申请人
             ***/
            DateTime now = DateTime.Now;
            CommonService.Model.FlowManager.P_Business_flow businessFlow = dal.GetModel(businessFlowCode);

            if (businessFlow == null)
                return isSuccess;
            if (businessFlow.P_Business_flow_applicationStatus == Convert.ToInt32(BusinessFlowApplicationStatueType.配置通过))
                return isSuccess;

            #region 处理业务(1)
            isSuccess = dal.UpdateApplicationStatus(businessFlowCode, Convert.ToInt32(BusinessFlowApplicationStatueType.配置通过));
            #endregion

            #region 处理业务(2)、(3)
            List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> ApplyRecords = businessFlowApplyRecordBLL.GetUnAuditList(businessFlowCode, Convert.ToInt32(BusinessFlowRecordTypeEnum.配置));
            foreach (CommonService.Model.FlowManager.P_Business_flow_applyRecord applyRecord in ApplyRecords)
            {
                applyRecord.P_Business_flow_applyRecord_auditUser = operateUser;
                applyRecord.P_Business_flow_applyRecord_auditTime = now;
                applyRecord.P_Business_flow_applyRecord_auditDetail = ("配置通过" + (businessFlow == null ? "" : businessFlow.P_Business_flow_name));

                businessFlowApplyRecordDAL.Update(applyRecord);

                #region 发送消息
                CommonService.Model.C_Messages message = new Model.C_Messages();
                if (fkType == Convert.ToInt32(FlowTypeEnum.商机))
                {
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.配置通过);
                }
                else if (fkType == Convert.ToInt32(FlowTypeEnum.客户))
                {
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.客户配置通过);
                }
                message.C_Messages_link = fkCode;
                message.C_Messages_createTime = now;
                message.C_Messages_person = applyRecord.P_Business_flow_applyRecord_applyUser;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
                #endregion
            }

            #endregion

            return isSuccess;
        }

        /// <summary>
        /// 拒绝业务流程申请配置
        /// </summary>
        /// <param name="fkType">流程类型(客户或者商机)</param>
        /// <param name="fkCode">业务Guid(客户Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作用户Guid</param>
        /// <returns></returns>       
        public bool UnAgreeBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            bool isSuccess = false;

            /**
             * author:hety
             * date:2015-10-23
             * description:目前此业务只针对商机或者客户
             * (1)、更改业务流程"申请状态"为"配置未通过"，并且删除此业务流程
             * (2)、赋值业务流程申请记录中的"审查项"
             * (3)、发送消息给申请人
             ***/
            DateTime now = DateTime.Now;
            CommonService.Model.FlowManager.P_Business_flow businessFlow = dal.GetModel(businessFlowCode);

            if (businessFlow == null)
                return isSuccess;
            if (businessFlow.P_Business_flow_applicationStatus == Convert.ToInt32(BusinessFlowApplicationStatueType.配置未通过))
                return isSuccess;

            #region 处理业务(1)
            isSuccess = dal.UpdateApplicationStatus(businessFlowCode, Convert.ToInt32(BusinessFlowApplicationStatueType.配置未通过));
            //this.Delete(businessFlowCode);//目前商家业务流程只有一级，所以可以直接调用之前逻辑，执行删除，不用考虑递归业务流程关联的业务流程申请记录。
            #endregion

            #region 处理业务(2)、(3)
            List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> ApplyRecords = businessFlowApplyRecordBLL.GetUnAuditList(businessFlowCode, Convert.ToInt32(BusinessFlowRecordTypeEnum.配置));
            foreach (CommonService.Model.FlowManager.P_Business_flow_applyRecord applyRecord in ApplyRecords)
            {
                applyRecord.P_Business_flow_applyRecord_auditUser = operateUser;
                applyRecord.P_Business_flow_applyRecord_auditTime = now;
                applyRecord.P_Business_flow_applyRecord_auditDetail = ("配置未通过" + (businessFlow == null ? "" : businessFlow.P_Business_flow_name));

                businessFlowApplyRecordDAL.Update(applyRecord);

                #region 发送消息
                CommonService.Model.C_Messages message = new Model.C_Messages();
                if (fkType == Convert.ToInt32(FlowTypeEnum.商机))
                {
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.配置未通过);
                }
                else if (fkType == Convert.ToInt32(FlowTypeEnum.客户))
                {
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.客户配置未通过);
                }

                message.C_Messages_link = fkCode;
                message.C_Messages_createTime = now;
                message.C_Messages_person = applyRecord.P_Business_flow_applyRecord_applyUser;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
                #endregion
            }

            #endregion

            return isSuccess;
        }

        /// <summary>
        /// 申请开启业务流程
        /// </summary>
        /// <param name="fkType">流程类型(客户或者商机)</param>
        /// <param name="fkCode">业务Guid(客户Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>       
        public bool ApplyOpenBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            bool isSuccess = false;

            if (fkType == Convert.ToInt32(FlowTypeEnum.商机))
            {
                isSuccess = this.ChanceApplyOpenBusinessFlow(fkType, fkCode, businessFlowCode, operateUser);
            }
            else if (fkType == Convert.ToInt32(FlowTypeEnum.客户))
            {
                isSuccess = this.CustomerApplyOpenBusinessFlow(fkType, fkCode, businessFlowCode, operateUser);
            }

            return isSuccess;
        }

        /// <summary>
        /// 商机申请开启业务流程
        /// </summary>
        /// <param name="fkType">流程类型(客户或者商机)</param>
        /// <param name="fkCode">业务Guid(客户Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>       
        public bool ChanceApplyOpenBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            bool isSuccess = false;

            /**
              * author:hety
              * date:2015-10-23
              * description:目前此业务只针对商机
              * (1)、更改业务流程"申请状态"为"已提交"
              * (2)、新增业务流程申请记录
              * (3)、发送消息给商机负责人
              ***/

            DateTime now = DateTime.Now;
            CommonService.Model.FlowManager.P_Business_flow businessFlow = dal.GetModel(businessFlowCode);
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessFlow.P_Fk_code.Value);//关联商机

            if (businessFlow == null)
                return isSuccess;
            if (businessFlow.P_Business_flow_applicationStatus == Convert.ToInt32(BusinessFlowApplicationStatueType.已提交))
                return isSuccess;

            #region 处理业务(1)
            isSuccess = dal.UpdateApplicationStatus(businessFlowCode, Convert.ToInt32(BusinessFlowApplicationStatueType.已提交));
            #endregion

            #region 处理业务(2)
            CommonService.Model.FlowManager.P_Business_flow_applyRecord businessFlowApplyRecord = new Model.FlowManager.P_Business_flow_applyRecord();
            businessFlowApplyRecord.P_Business_flow_applyRecord_code = Guid.NewGuid();
            businessFlowApplyRecord.P_Business_flow_applyRecord_creator = operateUser;
            businessFlowApplyRecord.P_Business_flow_applyRecord_createTime = now;
            businessFlowApplyRecord.P_Business_flow_applyRecord_isDelete = false;
            businessFlowApplyRecord.P_Business_flow_applyRecord_recordType = Convert.ToInt32(BusinessFlowRecordTypeEnum.开启);
            businessFlowApplyRecord.P_Business_flow_applyRecord_businessFlow = businessFlowCode;
            businessFlowApplyRecord.P_Business_flow_applyRecord_applyUser = operateUser;
            businessFlowApplyRecord.P_Business_flow_applyRecord_applyTime = now;
            businessFlowApplyRecord.P_Business_flow_applyRecord_applyDetail = ("申请开启" + (businessFlow == null ? "" : businessFlow.P_Business_flow_name));
            businessFlowApplyRecordDAL.Add(businessFlowApplyRecord);
            #endregion

            #region 处理业务(3)
            if (businessChance != null)
            {
                if (businessChance.B_BusinessChance_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.商机开启);
                    message.C_Messages_link = fkCode;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = businessChance.B_BusinessChance_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
            }
            #endregion

            return isSuccess;
        }

        /// <summary>
        /// 客户申请业务流程
        /// </summary>
        /// <param name="fkType">流程类型(客户或者商机)</param>
        /// <param name="fkCode">业务Guid(客户Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作人Guid</param>
        /// <returns></returns>
        public bool CustomerApplyOpenBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            bool isSuccess = false;

            /**
              * author:hety
              * date:2015-11-26
              * description:目前此业务只针对客户
              * (1)、更改业务流程"申请状态"为"已提交"
              * (2)、新增业务流程申请记录
              * (3)、发送消息给商机负责人
              ***/

            DateTime now = DateTime.Now;
            CommonService.Model.FlowManager.P_Business_flow businessFlow = dal.GetModel(businessFlowCode);
            CommonService.Model.C_Customer customer = customerDAL.GetModel(businessFlow.P_Fk_code.Value);//关联客户

            if (businessFlow == null)
                return isSuccess;
            if (businessFlow.P_Business_flow_applicationStatus == Convert.ToInt32(BusinessFlowApplicationStatueType.已提交))
                return isSuccess;

            #region 处理业务(1)
            isSuccess = dal.UpdateApplicationStatus(businessFlowCode, Convert.ToInt32(BusinessFlowApplicationStatueType.已提交));
            #endregion

            #region 处理业务(2)
            CommonService.Model.FlowManager.P_Business_flow_applyRecord businessFlowApplyRecord = new Model.FlowManager.P_Business_flow_applyRecord();
            businessFlowApplyRecord.P_Business_flow_applyRecord_code = Guid.NewGuid();
            businessFlowApplyRecord.P_Business_flow_applyRecord_creator = operateUser;
            businessFlowApplyRecord.P_Business_flow_applyRecord_createTime = now;
            businessFlowApplyRecord.P_Business_flow_applyRecord_isDelete = false;
            businessFlowApplyRecord.P_Business_flow_applyRecord_recordType = Convert.ToInt32(BusinessFlowRecordTypeEnum.开启);
            businessFlowApplyRecord.P_Business_flow_applyRecord_businessFlow = businessFlowCode;
            businessFlowApplyRecord.P_Business_flow_applyRecord_applyUser = operateUser;
            businessFlowApplyRecord.P_Business_flow_applyRecord_applyTime = now;
            businessFlowApplyRecord.P_Business_flow_applyRecord_applyDetail = ("申请开启" + (businessFlow == null ? "" : businessFlow.P_Business_flow_name));
            businessFlowApplyRecordDAL.Add(businessFlowApplyRecord);
            #endregion

            #region 处理业务(3)
            if (customer != null)
            {
                if (customer.C_Customer_responsiblePerson != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.客户开启);
                    message.C_Messages_link = fkCode;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = customer.C_Customer_responsiblePerson;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
            }
            #endregion

            return isSuccess;
        }

        /// <summary>
        /// 驳回已申请开启的业务流程
        /// </summary>
        /// <param name="fkType">流程类型(客户或者商机)</param>
        /// <param name="fkCode">业务Guid(客户Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作人Guid</param>
        /// <returns></returns>     
        public bool RejectAppliedBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            bool isSuccess = false;

            /**
             * author:hety
             * date:2015-10-26
             * description:目前此业务只针对商机
             * (1)、更改业务流程"申请状态"为"配置通过"
             * (2)、赋值业务流程申请记录中的"审查项"
             * (3)、发送消息给申请人
             ***/

            DateTime now = DateTime.Now;
            CommonService.Model.FlowManager.P_Business_flow businessFlow = dal.GetModel(businessFlowCode);

            if (businessFlow == null)
                return isSuccess;
            if (businessFlow.P_Business_flow_applicationStatus != Convert.ToInt32(BusinessFlowApplicationStatueType.已提交))
                return isSuccess;

            #region 处理业务(1)
            isSuccess = dal.UpdateApplicationStatus(businessFlowCode, Convert.ToInt32(BusinessFlowApplicationStatueType.未通过));
            #endregion

            #region 处理业务(2)、(3)
            List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> ApplyRecords = businessFlowApplyRecordBLL.GetUnAuditList(businessFlowCode, Convert.ToInt32(BusinessFlowRecordTypeEnum.开启));
            foreach (CommonService.Model.FlowManager.P_Business_flow_applyRecord applyRecord in ApplyRecords)
            {
                applyRecord.P_Business_flow_applyRecord_auditUser = operateUser;
                applyRecord.P_Business_flow_applyRecord_auditTime = now;
                applyRecord.P_Business_flow_applyRecord_auditDetail = ("开启流程驳回" + (businessFlow == null ? "" : businessFlow.P_Business_flow_name));

                businessFlowApplyRecordDAL.Update(applyRecord);

                #region 发送消息
                CommonService.Model.C_Messages message = new Model.C_Messages();
                if (fkType == Convert.ToInt32(FlowTypeEnum.商机))
                {
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.开启流程驳回);
                }
                else if (fkType == Convert.ToInt32(FlowTypeEnum.客户))
                {
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.开启客户流程驳回);
                }
                message.C_Messages_link = fkCode;
                message.C_Messages_createTime = now;
                message.C_Messages_person = applyRecord.P_Business_flow_applyRecord_applyUser;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
                #endregion
            }
            #endregion

            return isSuccess;
        }

        /// <summary>
        /// 开启已申请开启的业务流程
        /// </summary>
        /// <param name="fkType">流程类型(客户或者商机)</param>
        /// <param name="fkCode">业务Guid(客户Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作人Guid</param>
        /// <returns></returns>
        public bool StartAppliedBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            bool isSuccess = false;
            if (fkType == Convert.ToInt32(FlowTypeEnum.商机))
            {
                isSuccess = this.ChanceStartAppliedBusinessFlow(fkType, fkCode, businessFlowCode, operateUser);
            }
            else if (fkType == Convert.ToInt32(FlowTypeEnum.客户))
            {
                isSuccess = this.CustomerStartAppliedBusinessFlow(fkType, fkCode, businessFlowCode, operateUser);
            }
            return isSuccess;
        }

        /// <summary>
        /// 商机开启 已申请开启的业务流程
        /// </summary>
        /// <param name="fkType">流程类型(商机)</param>
        /// <param name="fkCode">业务Guid(商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作人Guid</param>
        /// <returns></returns>
        public bool ChanceStartAppliedBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            bool isSuccess = false;

            /**
              * author:hety
              * date:2015-10-26
              * description:目前此业务只针对商机(并且商机的业务流程只有一级)
              * (1)、更改业务流程"进行状态"为"正在进行",并且赋予实际开始时间，并且发送消息给业务流程负责人
              * (2)、赋值业务流程申请记录中的"审查项"
              * (3)、发送消息给申请人
              * (4)、更改业务流程下所有表单的"进行状态"为"正在进行"，并且赋予实际开始时间，并且发送消息给表单律师
              * (5)、处理其它业务流程进行状态为"正在进行"及其关联表单的业务：业务流程进行状态改为"已结束"，业务流程实际结束时间赋值；以及关联表单的"进行状态"为"已结束"，并且赋予实际开始时间
            ***/

            DateTime now = DateTime.Now;
            CommonService.Model.FlowManager.P_Business_flow businessFlow = dal.GetModel(businessFlowCode);

            if (businessFlow == null)
                return isSuccess;
            if (businessFlow.P_Business_state != Convert.ToInt32(BusinessFlowStatus.未开始))
                return isSuccess;

            #region 处理业务(1)
            businessFlow.P_Business_startTime = now;
            businessFlow.P_Business_startPerson = operateUser;
            businessFlow.P_Business_flow_factStartTime = now;
            businessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
            businessFlow.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.已通过);
            isSuccess = dal.Update(businessFlow);

            #region 发送消息
            CommonService.Model.C_Messages businessFlowResponsivePersonMessage = new Model.C_Messages();
            businessFlowResponsivePersonMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
            businessFlowResponsivePersonMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.流程启动);
            businessFlowResponsivePersonMessage.C_Messages_link = fkCode;
            businessFlowResponsivePersonMessage.C_Messages_createTime = now;
            businessFlowResponsivePersonMessage.C_Messages_person = businessFlow.P_Business_person;
            businessFlowResponsivePersonMessage.C_Messages_isRead = 0;
            businessFlowResponsivePersonMessage.C_Messages_content = "";
            businessFlowResponsivePersonMessage.C_Messages_isValidate = 1;

            messageDAL.Add(businessFlowResponsivePersonMessage);
            #endregion

            #endregion

            #region 处理业务(2)、(3)
            List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> ApplyRecords = businessFlowApplyRecordBLL.GetUnAuditList(businessFlowCode, Convert.ToInt32(BusinessFlowRecordTypeEnum.开启));
            foreach (CommonService.Model.FlowManager.P_Business_flow_applyRecord applyRecord in ApplyRecords)
            {
                applyRecord.P_Business_flow_applyRecord_auditUser = operateUser;
                applyRecord.P_Business_flow_applyRecord_auditTime = now;
                applyRecord.P_Business_flow_applyRecord_auditDetail = ("开启流程通过" + (businessFlow == null ? "" : businessFlow.P_Business_flow_name));

                businessFlowApplyRecordDAL.Update(applyRecord);

                #region 发送消息
                CommonService.Model.C_Messages businessFlowApplyMessage = new Model.C_Messages();
                businessFlowApplyMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                businessFlowApplyMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.开启流程通过);
                businessFlowApplyMessage.C_Messages_link = fkCode;
                businessFlowApplyMessage.C_Messages_createTime = now;
                businessFlowApplyMessage.C_Messages_person = applyRecord.P_Business_flow_applyRecord_applyUser;
                businessFlowApplyMessage.C_Messages_isRead = 0;
                businessFlowApplyMessage.C_Messages_content = "";
                businessFlowApplyMessage.C_Messages_isValidate = 1;

                messageDAL.Add(businessFlowApplyMessage);
                #endregion
            }
            #endregion

            #region 处理业务(4)
            ArrayList businessFlowFormLayers = new ArrayList();//表单律师集合
            List<CommonService.Model.FlowManager.P_Business_flow_form> bffs = businesssFlowFormBLL.OnlyGetBusinessFlowForms(businessFlowCode);
            foreach (var bff in bffs)
            {//启动业务流程关联表单
                bff.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                businessFlowFormDAL.Update(bff);
                //更改表单实际开始时间
                CommonService.Model.CustomerForm.F_FormProperty factStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(bff.F_Form_code.Value, "factStartTime");
                if (factStartTimeFormProperty != null)
                {
                    formPropertyValueBll.Update(bff.F_Form_code.Value, bff.P_Business_flow_form_code.Value, factStartTimeFormProperty.F_FormProperty_code.Value, now.ToString("yyyy-MM-dd HH:mm:ss"));
                }

                #region 启动表单时，给表单的主办律师发送消息
                if (bff.P_Business_flow_form_person != null)
                {
                    if (!businessFlowFormLayers.Contains(bff.P_Business_flow_form_person.ToString().ToLower()))
                    {//处理启用不同表单时，如果表单律师出现重复的情况，只需要发一条消息
                        businessFlowFormLayers.Add(bff.P_Business_flow_form_person.ToString().ToLower());

                        CommonService.Model.C_Messages message = new Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                        message.C_Messages_link = fkCode;
                        message.C_Messages_createTime = now;
                        message.C_Messages_person = bff.P_Business_flow_form_person;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;

                        messageDAL.Add(message);
                    }
                }
                #endregion

                #region 启动表单时，给表单的协办律师发送消息
                List<CommonService.Model.FlowManager.P_Business_flow_form_user> BusinessFlowFormUsers = businessFlowFormUserBLL.GetListByBusinessFlowFormCode(bff.P_Business_flow_form_code.Value);
                foreach (CommonService.Model.FlowManager.P_Business_flow_form_user businessFlowFormUser in BusinessFlowFormUsers)
                {
                    if (businessFlowFormUser.P_Business_flow_form_user_user != null)
                    {
                        if (!businessFlowFormLayers.Contains(businessFlowFormUser.P_Business_flow_form_user_user.ToString().ToLower()))
                        {//处理启用不同表单时，如果表单律师出现重复的情况，只需要发一条消息
                            businessFlowFormLayers.Add(businessFlowFormUser.P_Business_flow_form_user_user.ToString().ToLower());

                            CommonService.Model.C_Messages message = new Model.C_Messages();
                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                            message.C_Messages_link = fkCode;
                            message.C_Messages_createTime = now;
                            message.C_Messages_person = businessFlowFormUser.P_Business_flow_form_user_user;
                            message.C_Messages_isRead = 0;
                            message.C_Messages_content = "";
                            message.C_Messages_isValidate = 1;

                            messageDAL.Add(message);
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region 处理业务(5)
            List<CommonService.Model.FlowManager.P_Business_flow> PureBusinessFlows = this.GetPureListByFkCode(fkCode);
            foreach (CommonService.Model.FlowManager.P_Business_flow pureBusinessFlow in PureBusinessFlows)
            {
                if (pureBusinessFlow.P_Business_flow_code.Value.ToString().ToLower() == businessFlowCode.ToString().ToLower())
                    continue;//过滤掉当前正在操作的业务流程
                if (pureBusinessFlow.P_Business_state != Convert.ToInt32(BusinessFlowStatus.正在进行))
                    continue;
                #region 正在进行的业务流程值处理
                pureBusinessFlow.P_Business_flow_factEndTime = now;
                pureBusinessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                dal.Update(pureBusinessFlow);
                #endregion

                #region 处理关联表单
                List<CommonService.Model.FlowManager.P_Business_flow_form> BusinessFlowForm = businesssFlowFormBLL.OnlyGetBusinessFlowForms(pureBusinessFlow.P_Business_flow_code.Value);
                foreach (var businessFlowForm in BusinessFlowForm)
                {//启动业务流程关联表单
                    businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                    businessFlowFormDAL.Update(businessFlowForm);
                    //更改表单实际结束时间
                    CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                    if (factEndTimeFormProperty != null)
                    {
                        formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, now.ToString("yyyy-MM-dd HH:mm:ss"));

                    }
                }
                #endregion

            }
            #endregion

            return isSuccess;
        }

        /// <summary>
        /// 客户开启 已申请开启的业务流程
        /// </summary>
        /// <param name="fkType">流程类型(客户)</param>
        /// <param name="fkCode">业务Guid(客户Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="operateUser">操作人Guid</param>
        /// <returns></returns>
        public bool CustomerStartAppliedBusinessFlow(int fkType, Guid fkCode, Guid businessFlowCode, Guid operateUser)
        {
            bool isSuccess = false;

            /**
              * author:hety
              * date:2015-11-26
              * description:目前此业务只针对客户(并且客户的业务流程只有一级)
              * (1)、更改业务流程"进行状态"为"正在进行",并且赋予实际开始时间，并且发送消息给业务流程负责人
              * (2)、赋值业务流程申请记录中的"审查项"
              * (3)、发送消息给申请人
              * (4)、更改业务流程下所有表单的"进行状态"为"正在进行"，并且赋予实际开始时间，并且发送消息给表单律师
              * (5)、处理其它业务流程进行状态为"正在进行"及其关联表单的业务：业务流程进行状态改为"已结束"，业务流程实际结束时间赋值；以及关联表单的"进行状态"为"已结束"，并且赋予实际开始时间
            ***/

            DateTime now = DateTime.Now;
            CommonService.Model.FlowManager.P_Business_flow businessFlow = dal.GetModel(businessFlowCode);

            if (businessFlow == null)
                return isSuccess;
            if (businessFlow.P_Business_state != Convert.ToInt32(BusinessFlowStatus.未开始))
                return isSuccess;

            #region 处理业务(1)
            businessFlow.P_Business_startTime = now;
            businessFlow.P_Business_startPerson = operateUser;
            businessFlow.P_Business_flow_factStartTime = now;
            businessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
            businessFlow.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.已通过);
            isSuccess = dal.Update(businessFlow);

            #region 发送消息
            CommonService.Model.C_Messages businessFlowResponsivePersonMessage = new Model.C_Messages();
            businessFlowResponsivePersonMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
            businessFlowResponsivePersonMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.流程启动);
            businessFlowResponsivePersonMessage.C_Messages_link = fkCode;
            businessFlowResponsivePersonMessage.C_Messages_createTime = now;
            businessFlowResponsivePersonMessage.C_Messages_person = businessFlow.P_Business_person;
            businessFlowResponsivePersonMessage.C_Messages_isRead = 0;
            businessFlowResponsivePersonMessage.C_Messages_content = "";
            businessFlowResponsivePersonMessage.C_Messages_isValidate = 1;

            messageDAL.Add(businessFlowResponsivePersonMessage);
            #endregion

            #endregion

            #region 处理业务(2)、(3)
            List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> ApplyRecords = businessFlowApplyRecordBLL.GetUnAuditList(businessFlowCode, Convert.ToInt32(BusinessFlowRecordTypeEnum.开启));
            foreach (CommonService.Model.FlowManager.P_Business_flow_applyRecord applyRecord in ApplyRecords)
            {
                applyRecord.P_Business_flow_applyRecord_auditUser = operateUser;
                applyRecord.P_Business_flow_applyRecord_auditTime = now;
                applyRecord.P_Business_flow_applyRecord_auditDetail = ("开启流程通过" + (businessFlow == null ? "" : businessFlow.P_Business_flow_name));

                businessFlowApplyRecordDAL.Update(applyRecord);

                #region 发送消息
                CommonService.Model.C_Messages businessFlowApplyMessage = new Model.C_Messages();
                businessFlowApplyMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                businessFlowApplyMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.开启客户流程通过);
                businessFlowApplyMessage.C_Messages_link = fkCode;
                businessFlowApplyMessage.C_Messages_createTime = now;
                businessFlowApplyMessage.C_Messages_person = applyRecord.P_Business_flow_applyRecord_applyUser;
                businessFlowApplyMessage.C_Messages_isRead = 0;
                businessFlowApplyMessage.C_Messages_content = "";
                businessFlowApplyMessage.C_Messages_isValidate = 1;

                messageDAL.Add(businessFlowApplyMessage);
                #endregion
            }
            #endregion

            #region 处理业务(4)
            ArrayList businessFlowFormLayers = new ArrayList();//表单律师集合
            List<CommonService.Model.FlowManager.P_Business_flow_form> bffs = businesssFlowFormBLL.OnlyGetBusinessFlowForms(businessFlowCode);
            foreach (var bff in bffs)
            {//启动业务流程关联表单
                bff.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                businessFlowFormDAL.Update(bff);
                //更改表单实际开始时间
                CommonService.Model.CustomerForm.F_FormProperty factStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(bff.F_Form_code.Value, "factStartTime");
                if (factStartTimeFormProperty != null)
                {
                    formPropertyValueBll.Update(bff.F_Form_code.Value, bff.P_Business_flow_form_code.Value, factStartTimeFormProperty.F_FormProperty_code.Value, now.ToString("yyyy-MM-dd HH:mm:ss"));
                }

                #region 启动表单时，给表单的主办律师发送消息
                if (bff.P_Business_flow_form_person != null)
                {
                    if (!businessFlowFormLayers.Contains(bff.P_Business_flow_form_person.ToString().ToLower()))
                    {//处理启用不同表单时，如果表单律师出现重复的情况，只需要发一条消息
                        businessFlowFormLayers.Add(bff.P_Business_flow_form_person.ToString().ToLower());

                        CommonService.Model.C_Messages message = new Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                        message.C_Messages_link = fkCode;
                        message.C_Messages_createTime = now;
                        message.C_Messages_person = bff.P_Business_flow_form_person;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;

                        messageDAL.Add(message);
                    }
                }
                #endregion

                #region 启动表单时，给表单的协办律师发送消息
                List<CommonService.Model.FlowManager.P_Business_flow_form_user> BusinessFlowFormUsers = businessFlowFormUserBLL.GetListByBusinessFlowFormCode(bff.P_Business_flow_form_code.Value);
                foreach (CommonService.Model.FlowManager.P_Business_flow_form_user businessFlowFormUser in BusinessFlowFormUsers)
                {
                    if (businessFlowFormUser.P_Business_flow_form_user_user != null)
                    {
                        if (!businessFlowFormLayers.Contains(businessFlowFormUser.P_Business_flow_form_user_user.ToString().ToLower()))
                        {//处理启用不同表单时，如果表单律师出现重复的情况，只需要发一条消息
                            businessFlowFormLayers.Add(businessFlowFormUser.P_Business_flow_form_user_user.ToString().ToLower());

                            CommonService.Model.C_Messages message = new Model.C_Messages();
                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                            message.C_Messages_link = fkCode;
                            message.C_Messages_createTime = now;
                            message.C_Messages_person = businessFlowFormUser.P_Business_flow_form_user_user;
                            message.C_Messages_isRead = 0;
                            message.C_Messages_content = "";
                            message.C_Messages_isValidate = 1;

                            messageDAL.Add(message);
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region 处理业务(5)
            List<CommonService.Model.FlowManager.P_Business_flow> PureBusinessFlows = this.GetPureListByFkCode(fkCode);
            foreach (CommonService.Model.FlowManager.P_Business_flow pureBusinessFlow in PureBusinessFlows)
            {
                if (pureBusinessFlow.P_Business_flow_code.Value.ToString().ToLower() == businessFlowCode.ToString().ToLower())
                    continue;//过滤掉当前正在操作的业务流程
                if (pureBusinessFlow.P_Business_state != Convert.ToInt32(BusinessFlowStatus.正在进行))
                    continue;
                #region 正在进行的业务流程值处理
                pureBusinessFlow.P_Business_flow_factEndTime = now;
                pureBusinessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                dal.Update(pureBusinessFlow);
                #endregion

                #region 处理关联表单
                List<CommonService.Model.FlowManager.P_Business_flow_form> BusinessFlowForm = businesssFlowFormBLL.OnlyGetBusinessFlowForms(pureBusinessFlow.P_Business_flow_code.Value);
                foreach (var businessFlowForm in BusinessFlowForm)
                {//启动业务流程关联表单
                    businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                    businessFlowFormDAL.Update(businessFlowForm);
                    //更改表单实际结束时间
                    CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                    if (factEndTimeFormProperty != null)
                    {
                        formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, now.ToString("yyyy-MM-dd HH:mm:ss"));

                    }
                }
                #endregion

            }
            #endregion

            return isSuccess;
        }


        /// <summary>
        /// 更改负责人
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessPersonCode">负责人Guid</param>
        /// <returns></returns>
        public bool UpdatePerson(Guid businessFlowCode, Guid businessPersonCode)
        {
            return dal.UpdatePerson(businessFlowCode, businessPersonCode);
        }

        /// <summary>
        /// 递归删除
        /// </summary>
        /// <param name="parentBusinessCode">父亲业务流程Guid</param>
        /// <returns></returns>
        private void RecursionDelete(Guid parentBusinessCode)
        {
            List<CommonService.Model.FlowManager.P_Business_flow> BusinessFlows = GetListByParentCode(parentBusinessCode);
            foreach (CommonService.Model.FlowManager.P_Business_flow childrenBusinessFlow in BusinessFlows)
            {
                dal.Delete(childrenBusinessFlow.P_Business_flow_code.Value);
                dal.DeleteEntryStatisticsByBusinessFlowCode(childrenBusinessFlow.P_Business_flow_code.Value);
                RecursionDelete(childrenBusinessFlow.P_Business_flow_code.Value);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string P_Business_flow_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(P_Business_flow_idlist, 0));
        }

        /// <summary>
        /// 根据案件Guid和用户Guid获得结案业务流程
        /// </summary>
        /// <param name="CaseCode">案件Guid</param>
        /// <param name="businessFlowPerson">当前用户Guid</param>
        /// <returns></returns>
        public Model.FlowManager.P_Business_flow GetModelIsCrossForm(Guid CaseCode, Guid businessFlowPerson)
        {
            CommonService.Model.FlowManager.P_Business_flow businessFlow = dal.GetModelIsCrossForm(CaseCode, businessFlowPerson);
            if(businessFlow!=null)
            {
                bool isAllFormCheckPass = true;//是否当前业务流程下所有表单审核通过
                List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms = businessFlowFormBLL.GetBusinessFlowForms(businessFlow.P_Business_flow_code.Value);
                foreach(CommonService.Model.FlowManager.P_Business_flow_form item in businessFlowForms)
                {
                    if(item.P_Business_flow_form_status!= Convert.ToInt32(FormStatusEnum.已通过))
                    {
                        isAllFormCheckPass = false;
                        break;
                    }
                }
                if (isAllFormCheckPass)
                {
                    CommonService.Model.CaseManager.B_Case_Confirm caseConfirm = confirmBLL.GetModelByCaseAndBusinessFlow(CaseCode, businessFlow.P_Business_flow_code.Value);
                    if (caseConfirm != null)
                    {
                        if (caseConfirm.B_Case_Confirm_checkState == Convert.ToInt32(CaseConfirmStateEnum.未通过))
                        {
                            return businessFlow;
                        }
                        else
                        {
                            businessFlow = null;
                        }
                    }
                    else
                    {
                        return businessFlow;
                    }
                }else
                {
                    businessFlow = null;
                }
            }
            return businessFlow;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.FlowManager.P_Business_flow GetModel(Guid P_Business_flow_code)
        {
            return dal.GetModel(P_Business_flow_code);
        }
        /// <summary>
        /// 获取客户正在进行的流程
        /// </summary>
        /// <param name="flowType">流程类型(案件或者商机或者客户)</param>
        /// <param name="pkCode">案件Guid或者商机Guid或者客户guid</param>
        /// <param name="pkCode">流程状态</param>
        /// <returns></returns>
        public CommonService.Model.FlowManager.P_Business_flow GetCustomerIngBusinessFlow(int flowType, Guid pkCode, int P_Business_state)
        {
            return dal.GetCustomerIngBusinessFlow(flowType, pkCode, P_Business_state);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 根据流程Guid获得数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetListByFlowCode(Guid P_Flow_code)
        {
            return DataTableToList(dal.GetListByFlowCode(P_Flow_code).Tables[0]);
        }
           /// <summary>
        /// 根据流程"是否监控"为"是"获得数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetAllListByFlowIsMonitor()
        {
            return DataTableToList(dal.GetAllListByFlowIsMonitor().Tables[0]);
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
        public List<CommonService.Model.FlowManager.P_Business_flow> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.FlowManager.P_Business_flow> modelList = new List<CommonService.Model.FlowManager.P_Business_flow>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.FlowManager.P_Business_flow model;
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
        /// 根据负责人获得数据
        /// </summary>
        /// <param name="P_Business_person"></param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetListByPerson(Guid P_Business_person)
        {
            return DataTableToList(dal.GetListByPerson(P_Business_person).Tables[0]);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="fkCode">关联案件或商机Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetListByFkCode(Guid fkCode)
        {
            return DataTableToList(dal.GetListByFkCode(fkCode).Tables[0]);
        }

        /// <summary>
        /// 根据业务Guid(案件Guid或者商机Guid)，获取所有存粹的业务流程集合
        /// </summary>
        /// <param name="fkCode">案件Guid或者商机Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetPureListByFkCode(Guid fkCode)
        {
            return DataTableToList(dal.GetPureListByFkCode(fkCode).Tables[0]);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="parentCode">父亲流程Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetListByParentCode(Guid parentCode)
        {
            return DataTableToList(dal.GetListByParentCode(parentCode).Tables[0]);
        }

        /// <summary>
        /// 通过案件Guid或商机Guid，业务流程级别获取集合
        /// </summary>
        /// <param name="fkCode">案件Guid或商机Guid</param>
        /// <param name="level">级别</param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetListByFkCodeAndLevel(Guid fkCode, int level)
        {
            return DataTableToList(dal.GetListByFkCodeAndLevel(fkCode, level).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.FlowManager.P_Business_flow model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetListByPage(CommonService.Model.FlowManager.P_Business_flow model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }
        /// <summary>
        /// 开启下一级流程
        /// </summary>
        /// <param name="P_Fk_code">外键(商机/案件/客户（guid）)</param>
        /// <param name="nextOrder">要开启的流程的顺序</param>
        /// <returns></returns>
        public bool StarNextFlow(Guid P_Fk_code,int nextOrder)
        {
            bool flag = true;
            //获取下一级流程，并且开启下一级流程
            CommonService.Model.FlowManager.P_Business_flow model = dal.GetNextOrderModelByPkcode(P_Fk_code, nextOrder);
            if (model != null)
            {
                model.P_Business_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                if (!dal.Update(model))
                    flag = false;
            }
            return flag;
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
        /// <summary>
        /// 根据案件编号获取流程
        /// </summary>
        /// <param name="caseNumber"></param>
        /// <returns></returns>
        public List<CommonService.Model.FlowManager.P_Business_flow> GetListByCaseNumber(string caseNumber)
        {
            return DataTableToList(dal.GetListByCaseNumber(caseNumber).Tables[0]);
        }
        #endregion  ExtensionMethod

        #region App专用

        /// <summary>
        /// 根据案件GUID获取该案件下所有的流程
        /// </summary>
        /// <param name="guid">案件GUID</param>
        /// <returns>业务流程列表</returns>
        public List<Model.FlowManager.P_Business_flow> AppGetCaseStageInfo(Guid? guid, Guid? userCode)
        {
            List<Model.FlowManager.P_Business_flow> lstResult = GetListByFkCodeAndLevel(guid.Value, 1);
            foreach (var item in lstResult)
            {
                item.Isedit = CheckResponsible(item.P_Business_flow_code.Value, userCode);
            }
            return lstResult;
        }

        /// <summary>
        /// 验证是否有需要操作的表单
        /// </summary>
        /// <param name="P_Business_flow_code">流程GUID</param>
        /// <param name="userCode">用户GUID</param>
        /// <returns></returns>
        public int CheckResponsible(Guid P_Business_flow_code, Guid? userCode)
        {
            int flag = 0;
            //找到此流程下面所有表单
            List<CommonService.Model.FlowManager.P_Business_flow_form> BusinessFlowForms = businesssFlowFormBLL.GetBusinessFlowFormsWithFormType(P_Business_flow_code);
            foreach (var item in BusinessFlowForms)
            {
                //第一种，必须显示提示的是（当前有表单被驳回，并且自己是表单的负责人
                if (item.P_Business_flow_form_status == Convert.ToInt32(FormStatusEnum.未通过) && item.ResponsiblePersonGuids.ToLower().Contains(userCode.Value.ToString().ToLower()))
                {
                    flag = 1;
                    break;
                }
                //第二种必须提示的是（当前需要填写数据，必须自己是表单负责人）。
                if (item.P_Business_flow_form_status == Convert.ToInt32(FormStatusEnum.未提交) && item.ResponsiblePersonGuids.ToLower().Contains(userCode.Value.ToString().ToLower()))
                {
                    flag = 2;
                    break;
                }
                //第三种必须提示的是(该审批该表单的人，该表单必须是已提交状态）
                if (item.P_Business_flow_form_status == Convert.ToInt32(FormStatusEnum.已提交))
                {
                    //再判断该表单是否是当前用户审核（根据审核表）
                    if (IsHasCheckFormPower(P_Business_flow_code, userCode.Value))
                    {
                        flag = 3;
                        break;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 检查当前用户是否有"审核表单"的权限
        /// </summary>
        /// <param name="businessFlowCode"></param>
        /// <returns></returns>
        private bool IsHasCheckFormPower(Guid businessFlowCode, Guid userCode)
        {
            CommonService.BLL.Customer.V_User oBLL = new CommonService.BLL.Customer.V_User();
            bool isHasCheckForm = false;
            List<CommonService.Model.Customer.V_User> V_User = oBLL.GetCheckOwnFormUsers(businessFlowCode);
            var powerUserList = from allList in V_User
                                where allList.UserCode == userCode
                                select allList;
            if (powerUserList.Count() != 0)
            {
                isHasCheckForm = true;//代表"允许当前登录用户审核"
            }


            return isHasCheckForm;
        }
        #endregion
    }
}

