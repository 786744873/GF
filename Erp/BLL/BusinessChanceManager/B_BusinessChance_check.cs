using CommonService.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.BusinessChanceManager
{
    /// <summary>
    /// 商机审查表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/10/30
    /// </summary>
    public partial class B_BusinessChance_check
    {
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance_check dal = new CommonService.DAL.BusinessChanceManager.B_BusinessChance_check();
        /// <summary>
        /// 商机数据访问层
        /// </summary>
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance businessChanceDAL = new CommonService.DAL.BusinessChanceManager.B_BusinessChance();
        /// <summary>
        /// 业务流程数据访问层
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow businessFlowDAL = new CommonService.DAL.FlowManager.P_Business_flow();

        /// <summary>
        /// 业务流程—表单中间表数据访问层
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow_form businessFlowFormDAL = new CommonService.DAL.FlowManager.P_Business_flow_form();

        /// <summary>
        /// 表单属性数据访问类
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_FormProperty formPropertyDAL = new CommonService.DAL.CustomerForm.F_FormProperty();

        /// <summary>
        /// 消息数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();

        /// <summary>
        /// 商机业务访问层
        /// </summary>
        private readonly CommonService.BLL.BusinessChanceManager.B_BusinessChance businessChanceBLL = new CommonService.BLL.BusinessChanceManager.B_BusinessChance();
        /// <summary>
        /// 业务流程—表单中间表业务访问层
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow_form businessFlowFormBLL = new CommonService.BLL.FlowManager.P_Business_flow_form();
        /// <summary>
        /// 表单属性值业务访问层
        /// </summary>
        private readonly CommonService.BLL.CustomerForm.F_FormPropertyValue formPropertyValueBLL = new CommonService.BLL.CustomerForm.F_FormPropertyValue();

        public B_BusinessChance_check()
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
        public bool Exists(int B_BusinessChance_check_id)
        {
            return dal.Exists(B_BusinessChance_check_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid B_BusinessChance_checkCode)
        {
            return dal.Delete(B_BusinessChance_checkCode);
        }

        /// <summary>
        /// 提交审查
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public bool SubmitCheck(Guid businessChanceCode, Guid userCode)
        {
            /***
             * author:hety
             * date:2015-11-02
             * description:提交审查
             * (1)、改变商机审查状态为"已审查"
             * (2)、发送审查消息给部长
             * (3)、新增商机审查信息 
             ***/
            bool flag = false;

            #region 处理业务(1)
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessChanceCode);
            if (businessChance == null)
                return flag;
            if (businessChance.B_BusinessChance_checkStatus != Convert.ToInt32(BusinessChanceCheckEnum.未审查))
                return flag;
            flag = businessChanceDAL.UpdateCheckStatus(businessChanceCode, Convert.ToInt32(BusinessChanceCheckEnum.审查中));
            #endregion

            #region 处理业务(2)
           
            if (businessChance.B_BusinessChance_person != null)
            {
                CommonService.Model.C_Messages message = new Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.商机审查);
                message.C_Messages_link = businessChance.B_BusinessChance_code.Value;
                message.C_Messages_createTime = DateTime.Now;
                message.C_Messages_person = businessChance.B_BusinessChance_person;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
            }


            #endregion

            #region 处理业务(3)
            CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessChangeCheck = new Model.BusinessChanceManager.B_BusinessChance_check();
            businessChangeCheck.B_BusinessChance_check_code = Guid.NewGuid();
            businessChangeCheck.B_BusinessChance_checkPersonType = Convert.ToInt32(BusinessChanceCheckPersonTypeEnum.部长);
            businessChangeCheck.B_BusinessChance_check_BusinessChance_code = businessChanceCode;
            businessChangeCheck.B_BusinessChance_check_isChecked = false;
            businessChangeCheck.B_BusinessChance_check_isDelete = false;
            businessChangeCheck.B_BusinessChance_check_creator = userCode;
            businessChangeCheck.B_BusinessChance_check_createTime = DateTime.Now;

            dal.Add(businessChangeCheck);
            #endregion

            return flag;
        }

        /// <summary>
        /// 提交部长商机审查
        /// </summary>
        /// <param name="businessCheck">商机审查数据模型</param>
        /// <returns></returns>        
        public bool SubmitMinisterCheck(CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessCheck)
        {
            bool flag = false;

            /**
             * author:hety 
             * date:2015-11-04
             * description:提交部长商机审查逻辑
             * (1)、更新商机审查信息数据
             * (2)、根据审查类型，执行不同的业务逻辑
             * (2.1)、审查类型为："通过"
             * (2.2)、审查类型为："不通过"
             * (2.3)、审查类型为："保持现状"
             ***/

            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessCheck.B_BusinessChance_check_BusinessChance_code.Value);
            CommonService.Model.FlowManager.P_Business_flow crossFormBusinessFlow = businessFlowDAL.GetCrossFormBusinessFlow(Convert.ToInt32(FlowTypeEnum.商机), businessCheck.B_BusinessChance_check_BusinessChance_code.Value);
            CommonService.Model.BusinessChanceManager.B_BusinessChance_check dataBusinessCheck = dal.GetModel(businessCheck.B_BusinessChance_check_code.Value);

            if (dataBusinessCheck == null)
                return flag;
            if (dataBusinessCheck.B_BusinessChance_check_isChecked)
                return flag;
            if (businessChance == null)
                return flag;
            if (crossFormBusinessFlow == null)
                return flag;
            DateTime now = DateTime.Now;

            #region 处理业务(1)
            flag = dal.Update(businessCheck);
            #endregion

            #region 处理业务(2.1)
            if (businessCheck.B_BusinessChance_check_checkType == Convert.ToInt32(BusinessChanceCheckOpinionTypeEnum.通过))
            {
                #region 给此商机下的交单阶段的业务流程负责人，发送消息
                if (crossFormBusinessFlow != null && crossFormBusinessFlow.P_Business_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.商机审查通过);
                    message.C_Messages_link = businessCheck.B_BusinessChance_check_BusinessChance_code.Value;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = crossFormBusinessFlow.P_Business_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                #endregion

                #region 给商机一级负责人发送消息
                if (businessChance.B_BusinessChance_firstClassResponsiblePerson != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.商机审查);
                    message.C_Messages_link = businessCheck.B_BusinessChance_check_BusinessChance_code.Value;
                    message.C_Messages_createTime = DateTime.Now;
                    message.C_Messages_person = businessChance.B_BusinessChance_firstClassResponsiblePerson;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                #endregion

                #region 新增商机审查信息
                CommonService.Model.BusinessChanceManager.B_BusinessChance_check newBusinessChangeCheck = new Model.BusinessChanceManager.B_BusinessChance_check();
                newBusinessChangeCheck.B_BusinessChance_check_code = Guid.NewGuid();
                newBusinessChangeCheck.B_BusinessChance_checkPersonType = Convert.ToInt32(BusinessChanceCheckPersonTypeEnum.首席);
                newBusinessChangeCheck.B_BusinessChance_check_BusinessChance_code = businessCheck.B_BusinessChance_check_BusinessChance_code.Value;
                newBusinessChangeCheck.B_BusinessChance_check_isChecked = false;
                newBusinessChangeCheck.B_BusinessChance_check_isDelete = false;
                newBusinessChangeCheck.B_BusinessChance_check_creator = businessCheck.B_BusinessChance_check_checkPerson;
                newBusinessChangeCheck.B_BusinessChance_check_createTime = DateTime.Now;

                dal.Add(newBusinessChangeCheck);
                #endregion
            }
            #endregion

            #region 处理业务(2.2)
            if (businessCheck.B_BusinessChance_check_checkType == Convert.ToInt32(BusinessChanceCheckOpinionTypeEnum.不通过))
            {
                #region 改变进行状态为"已结束",商机审查状态为"已流失"
                businessChanceDAL.UpdateStatus(businessCheck.B_BusinessChance_check_BusinessChance_code.Value,
                    Convert.ToInt32(BusinessFlowStatus.已结束), Convert.ToInt32(BusinessChanceCheckEnum.已流失));
                #endregion

                #region 给此商机下的交单阶段的业务流程负责人，发送消息
                if (crossFormBusinessFlow != null && crossFormBusinessFlow.P_Business_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.商机流失);
                    message.C_Messages_link = businessCheck.B_BusinessChance_check_BusinessChance_code.Value;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = crossFormBusinessFlow.P_Business_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                #endregion

                #region 结束商机下的交单阶段及其表单
                if (crossFormBusinessFlow != null)
                {
                    if (crossFormBusinessFlow.P_Business_state != Convert.ToInt32(BusinessFlowStatus.已结束))
                    {//结束交单业务流程
                        crossFormBusinessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                        crossFormBusinessFlow.P_Business_flow_factEndTime = now;
                        businessFlowDAL.Update(crossFormBusinessFlow);
                    }                    
                }
                List<CommonService.Model.FlowManager.P_Business_flow_form> bffs = businessFlowFormBLL.OnlyGetBusinessFlowForms(crossFormBusinessFlow.P_Business_flow_code.Value);
                foreach (var bff in bffs)
                {//结束交单业务流程关联表单
                    if (bff.P_Business_flow_form_state != Convert.ToInt32(BusinessFlowStatus.已结束)) 
                    {
                        bff.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                        bff.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                        businessFlowFormDAL.Update(bff);
                        //更改表单实际结束时间
                        CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(bff.F_Form_code.Value, "factEndTime");
                        if (factEndTimeFormProperty != null)
                        {
                            formPropertyValueBLL.Update(bff.F_Form_code.Value, bff.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region 处理业务(2.3)
            if (businessCheck.B_BusinessChance_check_checkType == Convert.ToInt32(BusinessChanceCheckOpinionTypeEnum.保持现状))
            {
                //改变商机审查状态为"未审查"
                businessChanceDAL.UpdateCheckStatus(businessCheck.B_BusinessChance_check_BusinessChance_code.Value, Convert.ToInt32(BusinessChanceCheckEnum.未审查));
                //给此商机下的交单阶段的业务流程负责人，发送消息
                if (crossFormBusinessFlow != null && crossFormBusinessFlow.P_Business_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.保持现状);
                    message.C_Messages_link = businessCheck.B_BusinessChance_check_BusinessChance_code.Value;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = crossFormBusinessFlow.P_Business_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
            }
            #endregion

            return flag;
        }

        /// <summary>
        /// 提交首席商机审查
        /// </summary>
        /// <param name="businessCheck">商机审查数据模型</param>
        /// <returns></returns>
        public bool SubmitChiefCheck(CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessCheck)
        {
            bool flag = false;

            /**
             * author:hety 
             * date:2015-11-05
             * description:提交首席商机审查逻辑
             * (1)、更新商机审查信息数据
             * (2)、根据审查类型，执行不同的业务逻辑
             * (2.1)、审查类型为："通过"
             * (2.2)、审查类型为："不通过"
             * (2.3)、审查类型为："保持现状"
             ***/

            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = businessChanceDAL.GetModel(businessCheck.B_BusinessChance_check_BusinessChance_code.Value);
            CommonService.Model.FlowManager.P_Business_flow crossFormBusinessFlow = businessFlowDAL.GetCrossFormBusinessFlow(Convert.ToInt32(FlowTypeEnum.商机), businessCheck.B_BusinessChance_check_BusinessChance_code.Value);
            CommonService.Model.BusinessChanceManager.B_BusinessChance_check dataBusinessCheck = dal.GetModel(businessCheck.B_BusinessChance_check_code.Value);

            if (dataBusinessCheck == null)
                return flag;
            if (dataBusinessCheck.B_BusinessChance_check_isChecked)
                return flag;
            if (businessChance == null)
                return flag;
            if (crossFormBusinessFlow == null)
                return flag;
            DateTime now = DateTime.Now;

            #region 处理业务(1)
            flag = dal.Update(businessCheck);
            #endregion

            #region 处理业务(2.1)
            if (businessCheck.B_BusinessChance_check_checkType == Convert.ToInt32(BusinessChanceCheckOpinionTypeEnum.通过))
            {
                #region 改变进行状态为"已结束",商机审查状态为"已转案件"
                businessChanceDAL.UpdateStatus(businessCheck.B_BusinessChance_check_BusinessChance_code.Value,
                    Convert.ToInt32(BusinessFlowStatus.已结束), Convert.ToInt32(BusinessChanceCheckEnum.已转案件));
                #endregion

                #region 给此商机下的交单阶段的业务流程负责人，发送消息
                if (crossFormBusinessFlow != null && crossFormBusinessFlow.P_Business_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.商机审查通过);
                    message.C_Messages_link = businessCheck.B_BusinessChance_check_BusinessChance_code.Value;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = crossFormBusinessFlow.P_Business_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                #endregion

                #region 给商机负责人发送消息
                if (businessChance.B_BusinessChance_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.商机审查通过);
                    message.C_Messages_link = businessCheck.B_BusinessChance_check_BusinessChance_code.Value;
                    message.C_Messages_createTime = DateTime.Now;
                    message.C_Messages_person = businessChance.B_BusinessChance_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                #endregion

                #region 结束商机下的交单阶段及其表单
                if (crossFormBusinessFlow != null)
                {
                    if (crossFormBusinessFlow.P_Business_state != Convert.ToInt32(BusinessFlowStatus.已结束))
                    {//结束交单业务流程
                        crossFormBusinessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                        crossFormBusinessFlow.P_Business_flow_factEndTime = now;
                        businessFlowDAL.Update(crossFormBusinessFlow);
                    }
                }
                List<CommonService.Model.FlowManager.P_Business_flow_form> bffs = businessFlowFormBLL.OnlyGetBusinessFlowForms(crossFormBusinessFlow.P_Business_flow_code.Value);
                foreach (var bff in bffs)
                {//结束交单业务流程关联表单
                    if (bff.P_Business_flow_form_state != Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        bff.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                        bff.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                        businessFlowFormDAL.Update(bff);
                        //更改表单实际结束时间
                        CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(bff.F_Form_code.Value, "factEndTime");
                        if (factEndTimeFormProperty != null)
                        {
                            formPropertyValueBLL.Update(bff.F_Form_code.Value, bff.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                }
                #endregion

                #region 商机转案件
                businessChanceBLL.TranslateToCaseFromBusinessChance(businessCheck.B_BusinessChance_check_BusinessChance_code.Value, businessCheck.B_BusinessChance_check_category);
                #endregion
           
            }
            #endregion

            #region 处理业务(2.2)
            if (businessCheck.B_BusinessChance_check_checkType == Convert.ToInt32(BusinessChanceCheckOpinionTypeEnum.不通过))
            {
                #region 改变进行状态为"已结束",商机审查状态为"已流失"
                businessChanceDAL.UpdateStatus(businessCheck.B_BusinessChance_check_BusinessChance_code.Value,
                    Convert.ToInt32(BusinessFlowStatus.已结束), Convert.ToInt32(BusinessChanceCheckEnum.已流失));
                #endregion

                #region 给此商机下的交单阶段的业务流程负责人，发送消息
                if (crossFormBusinessFlow != null && crossFormBusinessFlow.P_Business_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.商机流失);
                    message.C_Messages_link = businessCheck.B_BusinessChance_check_BusinessChance_code.Value;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = crossFormBusinessFlow.P_Business_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                #endregion

                #region 给商机负责人发送消息
                if (businessChance.B_BusinessChance_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.商机流失);
                    message.C_Messages_link = businessCheck.B_BusinessChance_check_BusinessChance_code.Value;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = businessChance.B_BusinessChance_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                #endregion

                #region 结束商机下的交单阶段及其表单
                if (crossFormBusinessFlow != null)
                {
                    if (crossFormBusinessFlow.P_Business_state != Convert.ToInt32(BusinessFlowStatus.已结束))
                    {//结束交单业务流程
                        crossFormBusinessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                        crossFormBusinessFlow.P_Business_flow_factEndTime = now;
                        businessFlowDAL.Update(crossFormBusinessFlow);
                    }
                }
                List<CommonService.Model.FlowManager.P_Business_flow_form> bffs = businessFlowFormBLL.OnlyGetBusinessFlowForms(crossFormBusinessFlow.P_Business_flow_code.Value);
                foreach (var bff in bffs)
                {//结束交单业务流程关联表单
                    if (bff.P_Business_flow_form_state != Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        bff.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                        bff.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);
                        businessFlowFormDAL.Update(bff);
                        //更改表单实际结束时间
                        CommonService.Model.CustomerForm.F_FormProperty factEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(bff.F_Form_code.Value, "factEndTime");
                        if (factEndTimeFormProperty != null)
                        {
                            formPropertyValueBLL.Update(bff.F_Form_code.Value, bff.P_Business_flow_form_code.Value, factEndTimeFormProperty.F_FormProperty_code.Value, now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                }
                #endregion
            }
            #endregion

            #region 处理业务(2.3)
            if (businessCheck.B_BusinessChance_check_checkType == Convert.ToInt32(BusinessChanceCheckOpinionTypeEnum.保持现状))
            {
                //改变商机审查状态为"未审查"
                businessChanceDAL.UpdateCheckStatus(businessCheck.B_BusinessChance_check_BusinessChance_code.Value, Convert.ToInt32(BusinessChanceCheckEnum.未审查));
                //给此商机下的交单阶段的业务流程负责人，发送消息
                if (crossFormBusinessFlow != null && crossFormBusinessFlow.P_Business_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.保持现状);
                    message.C_Messages_link = businessCheck.B_BusinessChance_check_BusinessChance_code.Value;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = crossFormBusinessFlow.P_Business_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                //给商机负责人发送消息
                if (businessChance.B_BusinessChance_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.保持现状);
                    message.C_Messages_link = businessCheck.B_BusinessChance_check_BusinessChance_code.Value;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = businessChance.B_BusinessChance_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
            }
            #endregion

            return flag;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string B_BusinessChance_check_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(B_BusinessChance_check_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetModel(Guid B_BusinessChance_checkCode)
        {

            return dal.GetModel(B_BusinessChance_checkCode);
        }

        /// <summary>
        /// 根据商机Guid，审查人员类型获取最近一条没有审核的商机审查信息
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="checkPersonType">审查人员类型</param>
        /// <returns></returns>
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetUnCheckedChanceCheck(Guid businessChanceCode, int checkPersonType)
        {
            return dal.GetUnCheckedChanceCheck(businessChanceCode, checkPersonType);
        }

        /// <summary>
        /// 根据商机Guid，审查人员类型获取最近一条已审核的商机审查信息
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="checkPersonType">审查人员类型</param>
        /// <returns></returns>
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetLatestChanceCheck(Guid businessChanceCode, int checkPersonType)
        {
            return dal.GetLatestChanceCheck(businessChanceCode, checkPersonType);
        }

        /// <summary>
        /// 根据商机Guid，审查人员类型获取最近一条已审核的商机审查信息
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>      
        public CommonService.Model.BusinessChanceManager.B_BusinessChance_check GetLatestChanceCheckByBusinessChance(Guid businessChanceCode)
        {
            return dal.GetLatestChanceCheckByBusinessChance(businessChanceCode);
        }

        /// <summary>
        /// 根据商机Guid，获取全部已审查记录
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_check> GetChekedBusinessChanceChecks(Guid businessChanceCode)
        {
            DataSet ds = dal.GetChekedBusinessChanceChecks(businessChanceCode);
            return DataTableToList(ds.Tables[0]);
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
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_check> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_check> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.BusinessChanceManager.B_BusinessChance_check> modelList = new List<CommonService.Model.BusinessChanceManager.B_BusinessChance_check>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.BusinessChanceManager.B_BusinessChance_check model;
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
        public int GetRecordCount(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model)
        {
            return 0;
            //return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance_check> GetListByPage(CommonService.Model.BusinessChanceManager.B_BusinessChance_check model, string orderby, int startIndex, int endIndex)
        {
            return null;
            //return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
    }
}
