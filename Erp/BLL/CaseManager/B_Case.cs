using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Maticsoft.Common;
using CommonService.Model;
using CommonService.Common;
using System.Collections;
using System.Text;
using CommonService.Model.FlowManager;
namespace CommonService.BLL.CaseManager
{
    /// <summary>
    /// 案件表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/05/12
    /// </summary>
    public partial class B_Case
    {
        #region
        private readonly CommonService.DAL.CaseManager.B_Case dal = new CommonService.DAL.CaseManager.B_Case();
        private readonly CommonService.DAL.CaseManager.B_Case_link clDal = new DAL.CaseManager.B_Case_link();
        private readonly CommonService.DAL.C_Parameters parDal = new DAL.C_Parameters();
        private readonly CommonService.BLL.SysManager.C_Userinfo userinfoBll = new CommonService.BLL.SysManager.C_Userinfo();
        private readonly CommonService.DAL.SysManager.C_Userinfo userinfoDal = new CommonService.DAL.SysManager.C_Userinfo();
        private readonly CommonService.BLL.SysManager.C_Organization orgBLL = new CommonService.BLL.SysManager.C_Organization();
        private readonly CommonService.DAL.SysManager.C_Organization orgDAL = new CommonService.DAL.SysManager.C_Organization();
        private readonly CommonService.DAL.SysManager.C_ChiefExpert_Minister ministerDAL = new DAL.SysManager.C_ChiefExpert_Minister();
        /// <summary>
        /// 业务流程数据访问层
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow bfDAL = new DAL.FlowManager.P_Business_flow();
        /// <summary>
        /// 业务流程业务逻辑
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow bfBLL = new FlowManager.P_Business_flow();
        /// <summary>
        /// 业务流程关联表单业务逻辑
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow_form bffBLL = new FlowManager.P_Business_flow_form();
        private readonly CommonService.DAL.FlowManager.P_Business_flow_form bffDAL = new DAL.FlowManager.P_Business_flow_form();
        private readonly CommonService.DAL.C_Region regDAL = new DAL.C_Region();
        /// <summary>
        /// 表单属性数据访问类
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_FormProperty formPropertyDAL = new CommonService.DAL.CustomerForm.F_FormProperty();
        /// <summary>
        /// 表单属性值业务访问层
        /// </summary>
        private readonly CommonService.BLL.CustomerForm.F_FormPropertyValue formPropertyValueBll = new CommonService.BLL.CustomerForm.F_FormPropertyValue();
        /// <summary>
        /// 消息数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();
        /// <summary>
        /// 业务流程关联表单关联用户业务逻辑层
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow_form_user businessFlowFormUserBLL = new CommonService.BLL.FlowManager.P_Business_flow_form_user();
        /// <summary>
        /// 角色-角色权限业务访问逻辑层
        /// </summary>
        private readonly CommonService.BLL.SysManager.C_Role_Role_Power roleRolePowerBLL = new CommonService.BLL.SysManager.C_Role_Role_Power();
        /// <summary>
        /// 表单审核业务访问层
        /// </summary>
        private readonly CommonService.BLL.CustomerForm.F_FormCheck formCheckBLL = new CommonService.BLL.CustomerForm.F_FormCheck();
        private readonly CommonService.DAL.CaseManager.B_CaseLevelchange caseLevelChangeDal = new CommonService.DAL.CaseManager.B_CaseLevelchange();
        private readonly CommonService.BLL.CaseManager.B_CaseLevelchange caseLevelChangeBLL = new CommonService.BLL.CaseManager.B_CaseLevelchange();
        private readonly CommonService.DAL.CaseManager.B_CaseLevelChangeRecords caseLevelChangeRecordsDal = new CommonService.DAL.CaseManager.B_CaseLevelChangeRecords();
        #endregion

        public B_Case()
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
        public bool Exists(int B_Case_id)
        {
            return dal.Exists(B_Case_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_Case model)
        {
            model.B_Case_number = NumberAssignment(model.B_Case_number);
            CommonService.Model.CaseManager.B_Case_link caseLinks = clDal.GetModelByFkCodeAndType(model.B_Case_code.Value, 11);
            #region
            if (caseLinks != null && caseLinks.C_FK_code != null)
            {
                Model.SysManager.C_Userinfo buzhang = userinfoBll.GetBuZhangByUserCode(caseLinks.C_FK_code.Value); //直接找部长
                //案件的负责人默认为客户的专业顾问的部长
                if (buzhang != null)
                {
                    model.B_Case_person = buzhang.C_Userinfo_code; //部长赋值

                    BLL.SysManager.C_ChiefExpert_Minister ccmBLL = new SysManager.C_ChiefExpert_Minister(); //部长首席关联
                    Model.SysManager.C_ChiefExpert_Minister ccm = ccmBLL.GetModelByMinister(buzhang.C_Userinfo_code.Value); //根据部长GUID获取首席
                    if (ccm != null)
                    {
                        model.B_Case_firstClassResponsiblePerson = ccm.C_ChiefExpert_Code; //首席赋值
                    }
                }

                #region 给部长发送新增案件消息
                if (model.B_Case_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.新增案件);
                    message.C_Messages_link = model.B_Case_code.Value;
                    message.C_Messages_createTime = DateTime.Now;
                    message.C_Messages_person = model.B_Case_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                #endregion
                #region 给首席发送新增案件消息
                if (model.B_Case_person != null)
                {
                    //根据部长guid查找首席guid
                    CommonService.Model.SysManager.C_ChiefExpert_Minister ministerModel = ministerDAL.GetModelByMinister(model.B_Case_person.Value);
                    if (ministerModel != null)
                    {
                        CommonService.Model.C_Messages message = new Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.新增案件);
                        message.C_Messages_link = model.B_Case_code.Value;
                        message.C_Messages_createTime = DateTime.Now;
                        message.C_Messages_person = ministerModel.C_ChiefExpert_Code;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;

                        messageDAL.Add(message);
                    }
                }
                #endregion

            }
            #endregion

            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CaseManager.B_Case model)
        {
            CommonService.Model.CaseManager.B_Case bcase = dal.GetModel(model.B_Case_code.Value);

            model.B_Case_number = bcase.B_Case_number;
            CommonService.Model.CaseManager.B_Case_link caseLinks = clDal.GetModelByFkCodeAndType(model.B_Case_code.Value, 11);
            if (caseLinks != null && caseLinks.C_FK_code != null)
            {
                Model.SysManager.C_Userinfo buzhang = userinfoBll.GetBuZhangByUserCode(caseLinks.C_FK_code.Value); //直接找部长
                //案件的负责人默认为客户的专业顾问的部长
                if (buzhang != null)
                {
                    model.B_Case_person = buzhang.C_Userinfo_code; //部长赋值

                    BLL.SysManager.C_ChiefExpert_Minister ccmBLL = new SysManager.C_ChiefExpert_Minister(); //部长首席关联
                    Model.SysManager.C_ChiefExpert_Minister ccm = ccmBLL.GetModelByMinister(buzhang.C_Userinfo_code.Value); //根据部长GUID获取首席
                    if (ccm != null)
                    {
                        model.B_Case_firstClassResponsiblePerson = ccm.C_ChiefExpert_Code; //首席赋值
                    }
                }
            }
            #region 在“首席专家”或者"部长"改变的时候，变更"表单审核"中的审核人(若表单最后审核人为"首席专家"或者"部长"的时候，才需要变更)
            //目前不考虑“首席专家”或者"部长"是同一人，并且案件的级别更改
            List<CommonService.Model.CustomerForm.F_FormCheck> unFormChecks = formCheckBLL.GetUnCheckRecordByFkCode(model.B_Case_code.Value);
            foreach (CommonService.Model.CustomerForm.F_FormCheck formCheck in unFormChecks)
            {
                if (model.B_Case_person != bcase.B_Case_person)
                {//变更部长
                    if (formCheck.F_FormCheck_checkPerson == bcase.B_Case_person)
                    {
                        formCheck.F_FormCheck_checkPerson = model.B_Case_person;
                        formCheckBLL.Update(formCheck);
                    }
                }
                if (bcase.B_Case_firstClassResponsiblePerson != model.B_Case_firstClassResponsiblePerson)
                {//变更首席专家
                    if (formCheck.F_FormCheck_checkPerson == bcase.B_Case_firstClassResponsiblePerson)
                    {
                        formCheck.F_FormCheck_checkPerson = model.B_Case_firstClassResponsiblePerson;
                        formCheckBLL.Update(formCheck);
                    }
                }
            }
            #endregion

            #region 当案件分配负责人时，给该负责人发送消息
            if (model.B_Case_person != bcase.B_Case_person)
            {
                CommonService.Model.C_Messages message = new Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.新增案件);
                message.C_Messages_link = model.B_Case_code.Value;
                message.C_Messages_createTime = DateTime.Now;
                message.C_Messages_person = model.B_Case_person;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
            }
            #endregion

            return dal.Update(model);
        }

        /// <summary>
        /// 首席确认案件时操作
        /// </summary>
        public bool ChiefUpdate(CommonService.Model.CaseManager.B_Case model)
        {
            CommonService.Model.CaseManager.B_Case bcase = dal.GetModel(model.B_Case_code.Value);

            if (bcase.B_Case_isSure == false) //如果是未确认的
            {
                model.B_Case_isSure = true;
                model.B_Case_sureDate = DateTime.Now;
            }

            model.B_Case_number = bcase.B_Case_number;

            #region 在“首席专家”或者"部长"改变的时候，变更"表单审核"中的审核人(若表单最后审核人为"首席专家"或者"部长"的时候，才需要变更)
            //目前不考虑“首席专家”或者"部长"是同一人，并且案件的级别更改
            List<CommonService.Model.CustomerForm.F_FormCheck> unFormChecks = formCheckBLL.GetUnCheckRecordByFkCode(model.B_Case_code.Value);
            foreach (CommonService.Model.CustomerForm.F_FormCheck formCheck in unFormChecks)
            {
                if (model.B_Case_person != bcase.B_Case_person)
                {//变更部长
                    if (formCheck.F_FormCheck_checkPerson == bcase.B_Case_person)
                    {
                        formCheck.F_FormCheck_checkPerson = model.B_Case_person;
                        formCheckBLL.Update(formCheck);
                    }
                }
                if (bcase.B_Case_firstClassResponsiblePerson != model.B_Case_firstClassResponsiblePerson)
                {//变更首席专家
                    if (formCheck.F_FormCheck_checkPerson == bcase.B_Case_firstClassResponsiblePerson)
                    {
                        formCheck.F_FormCheck_checkPerson = model.B_Case_firstClassResponsiblePerson;
                        formCheckBLL.Update(formCheck);
                    }
                }
            }
            #endregion

            #region 当案件分配负责人时，给该负责人发送消息
            if (model.B_Case_person != bcase.B_Case_person)
            {
                CommonService.Model.C_Messages message = new Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.新增案件);
                message.C_Messages_link = model.B_Case_code.Value;
                message.C_Messages_createTime = DateTime.Now;
                message.C_Messages_person = model.B_Case_person;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
            }
            #endregion

            return dal.Update(model);
        }

        #region 案件编码赋值

        /// <summary>
        /// 案件编码赋值
        /// </summary>
        /// <param name="caseNumber"></param>
        /// <returns></returns>
        private string NumberAssignment(string caseNumber)
        {
            CommonService.Model.CaseManager.B_Case caseModel = dal.GetModelByNumber(caseNumber);
            string caseNum = "";
            if (caseModel != null)
            {
                caseNum = caseModel.B_Case_number.Substring(caseModel.B_Case_number.Length - 4, 4);
                int n = int.Parse(caseNum) + 1;
                caseNumber = caseNumber + n.ToString("0000");
            }
            else
            {
                caseNumber = caseNumber + "0000";
            }

            return caseNumber;
        }

        #endregion

        /// <summary>
        /// 修改案件进行状态
        /// </summary>
        public bool UpdateState(Guid B_Case_code, Guid startPersonCode)
        {
            bool isSuccess = true;

            try
            {
                #region 启动案件任务
                DateTime now = DateTime.Now;
                CommonService.Model.CaseManager.B_Case bcase = GetModel(B_Case_code);
                bcase.B_Case_factStartTime = now;
                bcase.B_Case_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                isSuccess = dal.Update(bcase);

                #endregion

                #region 启动业务流程

                List<CommonService.Model.FlowManager.P_Business_flow> business_flow = bfBLL.GetListByFkCode(B_Case_code);
                SetSingleTopBusinessFlow(business_flow, now, startPersonCode);

                #endregion

            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }

        /// <summary>
        /// 修改预期收益金额
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="expectedGrant">预期收益金额</param>
        /// <returns></returns>
        public bool UpdateExpectedGrant(Guid caseCode, Decimal expectedGrant)
        {
            return dal.UpdateExpectedGrant(caseCode, expectedGrant);
        }

        /// <summary>
        /// 装载顶级业务流程
        /// </summary>
        /// <param name="businessFlowList">业务流程集合</param>
        private void SetSingleTopBusinessFlow(List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList, DateTime now, Guid startPersonCode)
        {
            ArrayList businessFlowFormRepins = new ArrayList();//表单主办律师集合
            string BusinessflowCode = "";
            var topBusinessFlowList = from allList in businessFlowList
                                      where allList.P_Business_flow_level == 1
                                      orderby allList.P_Business_order ascending
                                      select allList;
            if (topBusinessFlowList.Count() != 0)
            {
                BusinessflowCode = topBusinessFlowList.First().P_Business_flow_code.ToString();

                //启动业务流程
                CommonService.Model.FlowManager.P_Business_flow bf = bfBLL.GetModel(new Guid(BusinessflowCode));
                bf.P_Business_startTime = now;
                bf.P_Business_startPerson = startPersonCode;
                bf.P_Business_flow_factStartTime = now;
                bf.P_Business_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                bf.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.已通过);
                bfDAL.Update(bf);

                #region 业务流程启动时，给业务流程负责人发送消息
                if (bf.P_Business_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.流程启动);
                    message.C_Messages_link = bf.P_Fk_code;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = bf.P_Business_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                #endregion

                #region 启动业务流程时，需要根据业务流程实际开始时间，更新关联条目统计信息时间值
                //业务流程实际开始时间
                bfDAL.UpdateEntryStatisticsByBusinessFlowTime(bf.P_Business_flow_code.Value, "factStartTime", now);
                #endregion

                List<CommonService.Model.FlowManager.P_Business_flow_form> bffs = bffBLL.OnlyGetBusinessFlowForms(new Guid(BusinessflowCode));
                foreach (var bff in bffs)
                {//启动业务流程关联表单
                    bff.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                    bffDAL.Update(bff);
                    //更改表单实际开始时间以及根据表单实际开始时间，更新关联条目统计信息时间值
                    CommonService.Model.CustomerForm.F_FormProperty factStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(bff.F_Form_code.Value, "factStartTime");
                    if (factStartTimeFormProperty != null)
                    {
                        formPropertyValueBll.Update(bff.F_Form_code.Value, bff.P_Business_flow_form_code.Value, factStartTimeFormProperty.F_FormProperty_code.Value, now.ToString("yyyy-MM-dd HH:mm:ss"));
                        bffDAL.UpdateEntryStatisticsByFormTime(bff.P_Business_flow_form_code.Value, "factStartTime", now);
                    }

                    #region 启动表单时，给表单的主办律师发送消息
                    if (bff.P_Business_flow_form_person != null)
                    {
                        if (!businessFlowFormRepins.Contains(bff.P_Business_flow_form_person.ToString()))
                        {//处理启用不同表单时，如果表单主办律师出现重复的情况，只需要发一条消息
                            businessFlowFormRepins.Add(bff.P_Business_flow_form_person.ToString());

                            CommonService.Model.C_Messages message = new Model.C_Messages();
                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                            message.C_Messages_link = bf.P_Fk_code;
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
                        CommonService.Model.C_Messages message = new Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                        message.C_Messages_link = bf.P_Fk_code;
                        message.C_Messages_createTime = now;
                        message.C_Messages_person = businessFlowFormUser.P_Business_flow_form_user_user;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;

                        messageDAL.Add(message);
                    }
                    #endregion
                }

                SetSignleRecursionTree(new Guid(BusinessflowCode), businessFlowList, now, startPersonCode);
                //发送队列消息
                MSMQ.SendMessage();
            }

        }

        /// <summary>
        /// 递归加载所有业务流程
        /// </summary>
        /// <param name="parentCode">上级流程Code</param>
        /// <param name="businessFlowList">业务流程集合</param>
        private void SetSignleRecursionTree(Guid parentCode, List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList, DateTime now, Guid startPersonCode)
        {
            ArrayList businessFlowFormRepins = new ArrayList();//表单主办律师集合
            string BusinessflowCode = "";
            var lowbusinessFlowList = from allList in businessFlowList
                                      where allList.P_Flow_parent == parentCode
                                      orderby allList.P_Business_order ascending
                                      select allList;
            if (lowbusinessFlowList.Count() != 0)
            {
                BusinessflowCode = lowbusinessFlowList.First().P_Business_flow_code.ToString();

                //启动业务流程
                CommonService.Model.FlowManager.P_Business_flow bf = bfBLL.GetModel(new Guid(BusinessflowCode));
                bf.P_Business_flow_factStartTime = now;
                bf.P_Business_startTime = now;
                bf.P_Business_startPerson = startPersonCode;
                bf.P_Business_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                bf.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.已通过);
                bfDAL.Update(bf);

                #region 业务流程启动时，给业务流程负责人发送消息
                if (bf.P_Business_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.流程启动);
                    message.C_Messages_link = bf.P_Fk_code;
                    message.C_Messages_createTime = now;
                    message.C_Messages_person = bf.P_Business_person;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                #endregion

                #region 启动业务流程时，需要根据业务流程实际开始时间，更新关联条目统计信息时间值
                //业务流程实际开始时间
                bfDAL.UpdateEntryStatisticsByBusinessFlowTime(bf.P_Business_flow_code.Value, "factStartTime", now);
                #endregion

                List<CommonService.Model.FlowManager.P_Business_flow_form> bffs = bffBLL.OnlyGetBusinessFlowForms(new Guid(BusinessflowCode));
                foreach (var bff in bffs)
                {//启动业务流程关联表单
                    bff.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                    bffDAL.Update(bff);
                    //更改表单实际开始时间以及根据表单实际开始时间，更新关联条目统计信息时间值
                    CommonService.Model.CustomerForm.F_FormProperty factStartTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(bff.F_Form_code.Value, "factStartTime");
                    if (factStartTimeFormProperty != null)
                    {
                        formPropertyValueBll.Update(bff.F_Form_code.Value, bff.P_Business_flow_form_code.Value, factStartTimeFormProperty.F_FormProperty_code.Value, now.ToString("yyyy-MM-dd HH:mm:ss"));
                        bffDAL.UpdateEntryStatisticsByFormTime(bff.P_Business_flow_form_code.Value, "factStartTime", now);
                    }
                    #region 启动表单时，给表单的主办律师发送消息
                    if (bff.P_Business_flow_form_person != null)
                    {
                        if (!businessFlowFormRepins.Contains(bff.P_Business_flow_form_person.ToString()))
                        {//处理启用不同表单时，如果表单主办律师出现重复的情况，只需要发一条消息
                            businessFlowFormRepins.Add(bff.P_Business_flow_form_person.ToString());

                            CommonService.Model.C_Messages message = new Model.C_Messages();
                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                            message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                            message.C_Messages_link = bf.P_Fk_code;
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
                        CommonService.Model.C_Messages message = new Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单启动);
                        message.C_Messages_link = bf.P_Fk_code;
                        message.C_Messages_createTime = now;
                        message.C_Messages_person = businessFlowFormUser.P_Business_flow_form_user_user;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;

                        messageDAL.Add(message);
                    }
                    #endregion
                }

                SetSignleRecursionTree(new Guid(BusinessflowCode), businessFlowList, now, startPersonCode);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid B_Case_code)
        {
            bool isSuccess = false;
            isSuccess = dal.Delete(B_Case_code);
            isSuccess = clDal.Delete(B_Case_code);
            return isSuccess;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string B_Case_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(B_Case_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case GetModel(Guid B_Case_code)
        {
            CommonService.Model.CaseManager.B_Case caseModel = dal.GetModel(B_Case_code);

            if (caseModel != null && caseModel.B_Case_person == null) //部长为空
            {
                List<CommonService.Model.CaseManager.B_Case_link> caseLinks = clDal.GetConsultantListByCasecode(B_Case_code); //获取专业顾问
                if (caseLinks.Count > 0)
                {
                    Model.SysManager.C_Userinfo buzhang = userinfoBll.GetBuZhangByUserCode(caseLinks.First().C_FK_code.Value); //先找部长助理
                    if (buzhang == null)
                    {
                        buzhang = userinfoBll.GetZhuLiByUserCode(caseLinks.First().C_FK_code.Value); //如果没有助理就找部长
                    }

                    //案件的负责人默认为客户的专业顾问的部长
                    if (buzhang != null)
                    {
                        caseModel.B_Case_person = buzhang.C_Userinfo_code; //部长赋值

                        BLL.SysManager.C_ChiefExpert_Minister ccmBLL = new SysManager.C_ChiefExpert_Minister(); //部长首席关联
                        Model.SysManager.C_ChiefExpert_Minister ccm = ccmBLL.GetModelByMinister(buzhang.C_Userinfo_code.Value); //根据部长GUID获取首席
                        if (ccm != null)
                        {
                            caseModel.B_Case_firstClassResponsiblePerson = ccm.C_ChiefExpert_Code; //首席赋值
                        }
                        Update(caseModel);
                    }
                }

            }
            else if (caseModel != null && caseModel.B_Case_firstClassResponsiblePerson == null) //首席为空
            {
                BLL.SysManager.C_ChiefExpert_Minister ccmBLL = new SysManager.C_ChiefExpert_Minister(); //部长首席关联
                Model.SysManager.C_ChiefExpert_Minister ccm = ccmBLL.GetModelByMinister(caseModel.B_Case_person.Value); //根据部长GUID获取首席
                if (ccm != null)
                {
                    caseModel.B_Case_firstClassResponsiblePerson = ccm.C_ChiefExpert_Code; //首席赋值
                    Update(caseModel);
                }
            }

            if (caseModel == null)
            {
                caseModel = new CommonService.Model.CaseManager.B_Case();
            }

            #region 变量
            string customerCodeStr = "";
            string customerNameStr = "";
            string clientCodeStr = "";
            string clientNameStr = "";
            string personCodeStr = "";
            string personNameStr = "";
            string personTypeStr = "";
            string executerCodeStr = "";
            string executerNameStr = "";
            string executerTypeStr = "";
            string projectCodeStr = "";
            string projectNameStr = "";
            string regionCodeStr = "";
            string regionNameStr = "";
            string consultantCodeStr = "";
            string consultantNameStr = "";
            #endregion

            #region
            List<Model.CaseManager.B_Case_link> Customers = clDal.GetCustomerListByCasecode(B_Case_code);
            foreach (var customer in Customers)
            {
                if (customer.B_Case_link_type == 0)
                { //客户
                    customerCodeStr += customer.C_FK_code.ToString() + ',';
                    customerNameStr += customer.C_Customer_name + ',';
                }
                else if (customer.B_Case_link_type == 1)
                {//委托人
                    clientCodeStr += customer.C_FK_code.ToString() + ',';
                    clientNameStr += customer.C_Customer_name + ',';
                }
            }

            List<Model.CaseManager.B_Case_link> CRivals = clDal.GetCRivalListByCasecode(B_Case_code);
            foreach (var crival in CRivals)
            {
                if (crival.B_Case_link_type == 2)
                {//对方当事人（公司）
                    personCodeStr += crival.C_FK_code.ToString() + ',';
                    personNameStr += crival.C_CRival_name + ',';
                    personTypeStr += crival.B_Case_link_type.ToString() + ',';
                }
                else if (crival.B_Case_link_type == 4)
                { //被执行人（公司）
                    executerCodeStr += crival.C_FK_code.ToString() + ',';
                    executerNameStr += crival.C_CRival_name + ',';
                    executerTypeStr += crival.B_Case_link_type.ToString() + ',';
                }
            }

            List<Model.CaseManager.B_Case_link> PRivals = clDal.GetPRivalListByCasecode(B_Case_code);
            foreach (var prival in PRivals)
            {
                if (prival.B_Case_link_type == 3)
                {//对方当事人（个人）
                    personCodeStr += prival.C_FK_code.ToString() + ',';
                    personNameStr += prival.C_PRival_name + ',';
                    personTypeStr += prival.B_Case_link_type.ToString() + ',';
                }
                else if (prival.B_Case_link_type == 5)
                {//被执行人（个人）
                    executerCodeStr += prival.C_FK_code.ToString() + ',';
                    executerNameStr += prival.C_PRival_name + ',';
                    executerTypeStr += prival.B_Case_link_type.ToString() + ',';
                }
            }

            List<Model.CaseManager.B_Case_link> Projects = clDal.GetProjectListByCasecode(B_Case_code);
            foreach (var project in Projects)
            {
                if (project.B_Case_link_type == 7)
                {//工程
                    projectCodeStr += project.C_FK_code.ToString() + ',';
                    projectNameStr += project.C_Involved_project_name + ',';
                }
            }

            List<Model.CaseManager.B_Case_link> Regions = clDal.GetRegionListByCasecode(B_Case_code);
            foreach (var region in Regions)
            {
                if (region.B_Case_link_type == 6)
                { //区域
                    regionCodeStr += region.C_FK_code.ToString() + ',';
                    regionNameStr += region.C_Region_name + ',';
                }
            }

            List<Model.CaseManager.B_Case_link> Consultants = clDal.GetConsultantListByCasecode(B_Case_code);
            foreach (var consultant in Consultants)
            {
                if (consultant.B_Case_link_type == 11)
                {//销售顾问
                    consultantCodeStr += consultant.C_FK_code.ToString() + ',';
                    consultantNameStr += consultant.C_Userinfo_name + ',';
                }
            }

            #endregion

            #region 虚拟字段赋值
            caseModel.C_Customer_code = customerCodeStr == "" ? customerCodeStr : customerCodeStr.Substring(0, customerCodeStr.Length - 1);
            caseModel.C_Customer_name = customerNameStr == "" ? customerNameStr : customerNameStr.Substring(0, customerNameStr.Length - 1);
            caseModel.C_Client_code = clientCodeStr == "" ? clientCodeStr : clientCodeStr.Substring(0, clientCodeStr.Length - 1);
            caseModel.C_Client_name = clientNameStr == "" ? clientNameStr : clientNameStr.Substring(0, clientNameStr.Length - 1);
            caseModel.C_Person_code = personCodeStr == "" ? personCodeStr : personCodeStr.Substring(0, personCodeStr.Length - 1);
            caseModel.C_Person_name = personNameStr == "" ? personNameStr : personNameStr.Substring(0, personNameStr.Length - 1);
            caseModel.C_Person_type = personTypeStr == "" ? personTypeStr : personTypeStr.Substring(0, personTypeStr.Length - 1);
            caseModel.C_Executer_code = executerCodeStr == "" ? executerCodeStr : executerCodeStr.Substring(0, executerCodeStr.Length - 1);
            caseModel.C_Executer_name = executerNameStr == "" ? executerNameStr : executerNameStr.Substring(0, executerNameStr.Length - 1);
            caseModel.C_Executer_type = executerTypeStr == "" ? executerTypeStr : executerTypeStr.Substring(0, executerTypeStr.Length - 1);
            caseModel.C_Project_code = projectCodeStr == "" ? projectCodeStr : projectCodeStr.Substring(0, projectCodeStr.Length - 1);
            caseModel.C_Project_name = projectNameStr == "" ? projectNameStr : projectNameStr.Substring(0, projectNameStr.Length - 1);
            caseModel.C_Region_code = regionCodeStr == "" ? regionCodeStr : regionCodeStr.Substring(0, regionCodeStr.Length - 1);
            caseModel.C_Region_name = regionNameStr == "" ? regionNameStr : regionNameStr.Substring(0, regionNameStr.Length - 1);
            caseModel.B_Consultant_code = consultantCodeStr == "" ? consultantCodeStr : consultantCodeStr.Substring(0, consultantCodeStr.Length - 1);
            caseModel.B_Case_consultant_name = consultantNameStr == "" ? consultantNameStr : consultantNameStr.Substring(0, consultantNameStr.Length - 1);
            #endregion

            return caseModel;
        }
        /// <summary>
        /// 得到一个案件对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case GetModelNo(Guid B_Case_code)
        {
            return dal.GetModel(B_Case_code);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.CaseManager.B_Case GetModelByCache(int B_Case_id)
        {
            string CacheKey = "B_CaseModel-" + B_Case_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(B_Case_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.CaseManager.B_Case)objModel;
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
        public List<CommonService.Model.CaseManager.B_Case> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.CaseManager.B_Case> modelList = new List<CommonService.Model.CaseManager.B_Case>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CaseManager.B_Case model;
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
            return dal.GetAllList();
        }

        /// <summary>
        /// 分页获取数据总记录数
        /// </summary>
        public int GetRecordCount(CommonService.Model.CaseManager.B_Case model, bool IsPreSetManager, int? RoleId, Guid? userCode, Guid? postCode, Guid? deptCode)
        {

            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersByRoleId(RoleId.Value);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }


            #region 搜索条件-部门处理
            String userinfoStr = "";
            if (model.B_Case_organizationCode != null && model.B_Case_organizationCode != "")
            {
                List<CommonService.Model.SysManager.C_Userinfo> userinfos = userinfoBll.GetUserinfosByOrganizationID(new Guid(model.B_Case_organizationCode));
                foreach (CommonService.Model.SysManager.C_Userinfo userinfo in userinfos)
                {
                    userinfoStr += "'" + userinfo.C_Userinfo_code + "'" + ",";
                }
                userinfoStr = SetSignleRecursionOrganization(model.B_Case_organizationCode, userinfoStr);
                if (userinfoStr != "")
                {
                    userinfoStr = userinfoStr.Substring(0, userinfoStr.Length - 1);
                }
            }
            if (model.B_Consultant_code != null && model.B_Consultant_code != "")
            {
                if (userinfoStr != "")
                {
                    model.B_Consultant_code = "('" + new Guid(model.B_Consultant_code) + "'," + userinfoStr + ")";
                }
                else
                {
                    model.B_Consultant_code = "('" + model.B_Consultant_code + "')";
                }
            }
            else
            {
                if (userinfoStr != "")
                {
                    model.B_Consultant_code = "(" + userinfoStr + ")";
                }
            }
            #endregion


            int recordCount = 0;
            if (model.B_Case_relationCode == null)
            {
                model.B_Case_relationCode = Guid.Empty;
            }
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = bfBLL.GetListByFlowCode(model.B_Case_relationCode.Value);
            if (businessFlows.Count() != 0)
            {
                foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in businessFlows)
                {
                    model.B_Case_code = businessFlow.P_Fk_code;
                    recordCount += dal.GetRecordCount(model, IsPreSetManager, rolePowerIds, RoleId, userCode, postCode, deptCode);
                }
            }
            else
            {
                recordCount = dal.GetRecordCount(model, IsPreSetManager, rolePowerIds, RoleId, userCode, postCode, deptCode);
            }

            return dal.GetRecordCount(model, IsPreSetManager, rolePowerIds, RoleId, userCode, postCode, deptCode);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_Case> GetListByPage(CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, int? RoleId, Guid? userCode, Guid? postCode, Guid? deptCode)
        {

            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersByRoleId(RoleId.Value);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }


            #region 搜索条件-部门处理
            String userinfoStr = "";
            if (model.B_Case_organizationCode != null && model.B_Case_organizationCode != "")
            {
                List<CommonService.Model.SysManager.C_Userinfo> userinfos = userinfoBll.GetUserinfosByOrganizationID(new Guid(model.B_Case_organizationCode));
                foreach (CommonService.Model.SysManager.C_Userinfo userinfo in userinfos)
                {
                    userinfoStr += "'" + userinfo.C_Userinfo_code + "'" + ",";
                }
                userinfoStr = SetSignleRecursionOrganization(model.B_Case_organizationCode, userinfoStr);
                if (userinfoStr != "")
                {
                    userinfoStr = userinfoStr.Substring(0, userinfoStr.Length - 1);
                }
            }
            if (model.B_Consultant_code != null && model.B_Consultant_code != "")
            {
                if (userinfoStr != "")
                {
                    model.B_Consultant_code = "('" + new Guid(model.B_Consultant_code) + "'," + userinfoStr + ")";
                }
                else
                {
                    model.B_Consultant_code = "('" + model.B_Consultant_code + "')";
                }
            }
            else
            {
                if (userinfoStr != "")
                {
                    model.B_Consultant_code = "(" + userinfoStr + ")";
                }
            }
            #endregion




            List<CommonService.Model.CaseManager.B_Case> cases = new List<Model.CaseManager.B_Case>();
            if (model.B_Case_relationCode == null)
            {
                model.B_Case_relationCode = Guid.Empty;
            }
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = bfBLL.GetListByFlowCode(model.B_Case_relationCode.Value);
            if (businessFlows.Count() != 0)
            {
                foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in businessFlows)
                {
                    model.B_Case_code = businessFlow.P_Fk_code;
                    List<CommonService.Model.CaseManager.B_Case> bcase = DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex, IsPreSetManager, rolePowerIds, RoleId, userCode, postCode, deptCode).Tables[0]);
                    if (bcase.Count > 0)
                        cases.Add(bcase.First());
                }
            }
            else
            {
                cases = DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex, IsPreSetManager, rolePowerIds, RoleId, userCode, postCode, deptCode).Tables[0]);
            }

            return cases;
        }

        public int GetListByPageByCount(CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, int? RoleId, Guid? userCode, Guid? postCode, Guid? deptCode)
        {

            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersByRoleId(RoleId.Value);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }


            #region 搜索条件-部门处理
            String userinfoStr = "";
            if (model.B_Case_organizationCode != null && model.B_Case_organizationCode != "")
            {
                List<CommonService.Model.SysManager.C_Userinfo> userinfos = userinfoBll.GetUserinfosByOrganizationID(new Guid(model.B_Case_organizationCode));
                foreach (CommonService.Model.SysManager.C_Userinfo userinfo in userinfos)
                {
                    userinfoStr += "'" + userinfo.C_Userinfo_code + "'" + ",";
                }
                userinfoStr = SetSignleRecursionOrganization(model.B_Case_organizationCode, userinfoStr);
                if (userinfoStr != "")
                {
                    userinfoStr = userinfoStr.Substring(0, userinfoStr.Length - 1);
                }
            }
            if (model.B_Consultant_code != null && model.B_Consultant_code != "")
            {
                if (userinfoStr != "")
                {
                    model.B_Consultant_code = "('" + new Guid(model.B_Consultant_code) + "'," + userinfoStr + ")";
                }
                else
                {
                    model.B_Consultant_code = "('" + model.B_Consultant_code + "')";
                }
            }
            else
            {
                if (userinfoStr != "")
                {
                    model.B_Consultant_code = "(" + userinfoStr + ")";
                }
            }
            #endregion




            int Numbers = 0;
            if (model.B_Case_relationCode == null)
            {
                model.B_Case_relationCode = Guid.Empty;
            }
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = bfBLL.GetListByFlowCode(model.B_Case_relationCode.Value);
            if (businessFlows.Count() != 0)
            {
                foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in businessFlows)
                {
                    model.B_Case_code = businessFlow.P_Fk_code;
                    var rows = dal.GetListByPageByCount(model, orderby, startIndex, endIndex, IsPreSetManager, rolePowerIds, RoleId, userCode, postCode, deptCode);
                    if (Convert.ToInt32(rows.ToString()) > 0)
                        Numbers++;
                }
            }
            else
            {
                Numbers = Convert.ToInt32(dal.GetListByPageByCount(model, orderby, startIndex, endIndex, IsPreSetManager, rolePowerIds, RoleId, userCode, postCode, deptCode));
            }

            return Numbers;
        }



        /// <summary>
        /// 分页获取权限数据总记录
        /// </summary>
        /// <param name="model">案件查询模型</param>
        /// <param name="IsPreSetManager">是否内置系统管理员</param>      
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <param name="deptCode">部门Guid</param>
        /// <returns></returns>
        public int GetPowerRecordCount(CommonService.Model.Customer.V_LawyerCondition vLawyerCond, CommonService.Model.CaseManager.B_Case model, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            //如果为内置系统管理员，则不允许查关联角色权限
            int recordCount = 0;
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersOrgUserPostCode(deptCode, userCode, postCode);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }

            recordCount = dal.GetPowerRecordCount(vLawyerCond, model, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode);
            return recordCount;
        }

        /// <summary>
        /// 分页获取权限数据列表
        /// </summary>
        /// <param name="model">案件查询模型</param>
        /// <param name="orderby">排序</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">结束索引</param>
        /// <param name="IsPreSetManager">是否内置系统管理员</param>      
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <param name="deptCode">部门Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CaseManager.B_Case> GetPowerListByPage(CommonService.Model.Customer.V_LawyerCondition vLawyerCond, CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersOrgUserPostCode(deptCode, userCode, postCode);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }            

            List<CommonService.Model.CaseManager.B_Case> cases = DataTableToList(dal.GetPowerListByPage(vLawyerCond, model, orderby, startIndex, endIndex, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode).Tables[0]);
            return cases;
        }

        /// <summary>
        /// 导出关联权限的案件数据(hety,2016-03-10)
        /// </summary>
        /// <param name="model">案件查询模型</param>
        /// <param name="orderby">排序</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">结束索引</param>
        /// <param name="IsPreSetManager">是否内置系统管理员</param>      
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <param name="deptCode">部门Guid</param>
        /// <returns></returns>
        public List<CommonService.Model.CaseManager.B_Case> ExportPowerListByPage(CommonService.Model.Customer.V_LawyerCondition vLawyerCond, CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
        {
            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersOrgUserPostCode(deptCode, userCode, postCode);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }

            List<CommonService.Model.CaseManager.B_Case> cases = DataTableToList(dal.ExportPowerListByPage(vLawyerCond, model, orderby, startIndex, endIndex, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode).Tables[0]);
            return cases;
        }


        /// <summary>
        /// 过滤条件
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IsPreSetManager"></param>   
        /// <param name="userCode"></param>
        /// <param name="postCode"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public int GetPowerRecordCaseMainCount(CommonService.Model.CaseManager.B_Case model, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode, string tj)
        {
            //如果为内置系统管理员，则不允许查关联角色权限
            int recordCount = 0;
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersOrgUserPostCode(deptCode, userCode, postCode);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }
            recordCount = dal.GetPowerRecordCaseMainCount(model, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode, tj);
            return recordCount;
        }

        ///条件过滤
        public List<CommonService.Model.CaseManager.B_Case> GetPowerListB_caseMainByPage(CommonService.Model.CaseManager.B_Case model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode, string tj)
        {
            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersOrgUserPostCode(deptCode, userCode, postCode);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }
            List<CommonService.Model.CaseManager.B_Case> cases = DataTableToList(dal.GetPowerListB_caseMainByPage(model, orderby, startIndex, endIndex, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode, tj).Tables[0]);
            return cases;
        }

        public String SetSignleRecursionOrganization(string parentOrganizationCode, string userinfoStr)
        {
            List<CommonService.Model.SysManager.C_Organization> organizations = orgBLL.GetModelByParent(new Guid(parentOrganizationCode));
            if (organizations != null)
            {
                foreach (CommonService.Model.SysManager.C_Organization organization in organizations)
                {
                    List<CommonService.Model.SysManager.C_Userinfo> userinfos = userinfoBll.GetUserinfosByOrganizationID(organization.C_Organization_code.Value);
                    foreach (CommonService.Model.SysManager.C_Userinfo userinfo in userinfos)
                    {
                        userinfoStr += "'" + userinfo.C_Userinfo_code + "'" + ",";
                    }
                    userinfoStr = SetSignleRecursionOrganization(organization.C_Organization_code.Value.ToString(), userinfoStr);
                }
            }
            return userinfoStr;
        }

        /// <summary>
        /// 根据表单guid得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_Case GetModelbyFormcode(Guid formCode)
        {
            return dal.GetModelbyFormcode(formCode);
        }

        /// <summary>
        /// 根据表单表Code和表单字段名称，得到该值
        /// </summary>
        /// <param name="F_FormPropertyValue_BusinessFlowFormCode"></param>
        /// <param name="F_Form_chineseName"></param>
        /// <returns></returns>
        public string GetFormValue(string F_FormPropertyValue_BusinessFlowFormCode, string F_Form_chineseName, string F_Form_code)
        {
            return dal.GetFormValue(F_FormPropertyValue_BusinessFlowFormCode, F_Form_chineseName, F_Form_code);
        }

        /// <summary>
        /// 案件转移
        /// </summary>
        /// <param name="lawyer">在办律师</param>
        /// <param name="TransferTo">转移给</param>
        /// <param name="transferType">转移类型</param>
        /// <param name="courtCodes">法院Guid</param>
        /// <returns></returns>
        public bool CaseTransfer(Guid lawyer, Guid TransferTo, string transferType, string courtCodes)
        {
            bool IsSuccess = true;
            string[] courtCodeList = courtCodes.Split(',');
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList = bfBLL.GetListByPerson(lawyer);//取得在办律师所负责的业务流程
            List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowFormList = bffBLL.GetListByPersonAndBusinessFlowState(lawyer);//取得在办律师所负责的表单

            #region 业务流程转移
            if (Convert.ToInt32(transferType) == Convert.ToInt32(TransferType.全部转移) || Convert.ToInt32(transferType) == Convert.ToInt32(TransferType.转移阶段))
            {
                foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in businessFlowList)
                {
                    if (businessFlow.P_Fk_code == null)
                        continue;
                    CommonService.Model.CaseManager.B_Case bcase = dal.GetModel(businessFlow.P_Fk_code.Value);//业务流程关联的案件
                    if (bcase == null)
                        continue;
                    List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms = bffBLL.GetBusinessFlowForms(businessFlow.P_Business_flow_code.Value);//业务流程关联表单
                    string[] caseCourts = new string[4];
                    if (courtCodes != "")
                    {
                        #region 法院不为空
                        caseCourts[0] = bcase.B_Case_courtFirst.ToString();
                        caseCourts[1] = bcase.B_Case_courtSecond.ToString();
                        caseCourts[2] = bcase.B_Case_courtExec.ToString();
                        caseCourts[3] = bcase.B_Case_Trial.ToString();

                        foreach (string courtCode in courtCodeList)
                        {
                            if (caseCourts.Contains(courtCode))
                            {
                                businessFlow.P_Business_person = TransferTo;
                                IsSuccess = bfDAL.Update(businessFlow);

                                foreach (CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm in businessFlowForms)
                                {
                                    CommonService.Model.CustomerForm.F_FormCheck formCheck = formCheckBLL.GetModelByFormCodeAndPersonAndCheckDate(businessFlowForm.P_Business_flow_form_code.Value, lawyer);
                                    if (formCheck != null)
                                    {
                                        formCheck.F_FormCheck_checkPerson = TransferTo;
                                        formCheckBLL.Update(formCheck);
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region 法院为空
                        businessFlow.P_Business_person = TransferTo;
                        IsSuccess = bfDAL.Update(businessFlow);

                        foreach (CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm in businessFlowForms)
                        {
                            CommonService.Model.CustomerForm.F_FormCheck formCheck = formCheckBLL.GetModelByFormCodeAndPersonAndCheckDate(businessFlowForm.P_Business_flow_form_code.Value, lawyer);
                            if (formCheck != null)
                            {
                                formCheck.F_FormCheck_checkPerson = TransferTo;
                                formCheckBLL.Update(formCheck);
                            }
                        }
                        #endregion
                    }
                }
            }
            #endregion

            #region 表单转移
            if (Convert.ToInt32(transferType) == Convert.ToInt32(TransferType.全部转移) || Convert.ToInt32(transferType) == Convert.ToInt32(TransferType.转移表单))
            {
                foreach (CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm in businessFlowFormList)
                {
                    CommonService.Model.FlowManager.P_Business_flow businessFlow = bfDAL.GetModel(businessFlowForm.P_Business_flow_code.Value);
                    if (businessFlow.P_Fk_code == null)
                        continue;
                    CommonService.Model.CaseManager.B_Case bcase = dal.GetModel(businessFlow.P_Fk_code.Value);//业务流程关联的案件
                    if (bcase == null)
                        continue;
                    string[] caseCourts = new string[4];
                    if (courtCodes != "")
                    {
                        #region 法院不为空
                        caseCourts[0] = bcase.B_Case_courtFirst.ToString();
                        caseCourts[1] = bcase.B_Case_courtSecond.ToString();
                        caseCourts[2] = bcase.B_Case_courtExec.ToString();
                        caseCourts[3] = bcase.B_Case_Trial.ToString();

                        foreach (string courtCode in courtCodeList)
                        {
                            if (caseCourts.Contains(courtCode))
                            {
                                businessFlowForm.P_Business_flow_form_person = TransferTo;
                                IsSuccess = bffDAL.Update(businessFlowForm);
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region 法院为空
                        businessFlowForm.P_Business_flow_form_person = TransferTo;
                        IsSuccess = bffDAL.Update(businessFlowForm);
                        #endregion
                    }
                }
            }
            #endregion

            return IsSuccess;
        }

        /// <summary>
        /// 案件转化
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="applicationPerson">申请人</param>
        /// <param name="TransformationType">转化类型</param>
        /// <param name="Reason">理由</param>
        /// <returns></returns>
        public bool CaseTransformation(Guid caseCode, Guid applicationPerson, string TransformationType, string Reason, bool IsPreSetManager, bool isChiefExpert)
        {
            #region 添加案件级别变更记录信息
            CommonService.Model.CaseManager.B_CaseLevelChangeRecords caseLevelChangeRecords = new CommonService.Model.CaseManager.B_CaseLevelChangeRecords();
            caseLevelChangeRecords.B_CaseLevelChangeRecords_code = Guid.NewGuid();
            caseLevelChangeRecords.B_Case_code = caseCode;
            caseLevelChangeRecords.B_CaseLevelChangeRecords_type = Convert.ToInt32(CaseLevelChangeRecordTypeEnum.手动);
            caseLevelChangeRecords.B_CaseLevelChangeRecords_applicationData = DateTime.Now;
            caseLevelChangeRecords.B_CaseLevelChangeRecords_applicationPerson = applicationPerson;
            caseLevelChangeRecords.B_CaseLevelChangeRecords_conversionReasons = Reason;
            caseLevelChangeRecords.B_CaseLevelChangeRecords_creator = applicationPerson;
            caseLevelChangeRecords.B_CaseLevelChangeRecords_createTime = DateTime.Now;
            caseLevelChangeRecords.B_CaseLevelChangeRecords_isDelete = false;            
            if ( isChiefExpert || IsPreSetManager)
            {//首席专家无需审核，直接通过
                caseLevelChangeRecords.B_CaseLevelChangeRecords_auditor = applicationPerson;
                caseLevelChangeRecords.B_CaseLevelChangeRecords_actualChangeDate = DateTime.Now;
                caseLevelChangeRecords.B_CaseLevelChangeRecords_auditOpinion = Reason;
                caseLevelChangeRecords.B_CaseLevelChangeRecords_isAudit = true;
            }
            else
            {
                caseLevelChangeRecords.B_CaseLevelChangeRecords_isAudit = false;
            }
            //添加案件级别变更记录信息
            caseLevelChangeRecordsDal.Add(caseLevelChangeRecords);
            #endregion

            #region 记录案件级别变更信息
            string[] TransformationTypes = TransformationType.Split(',');

            #region 首席或内置管理员调整重大难案
            if ( isChiefExpert || IsPreSetManager)
            {//首席专家
                List<CommonService.Model.CaseManager.B_CaseLevelchange> caseLevelChanges = caseLevelChangeBLL.GetListByCaseCode(caseCode, 2);
                if (TransformationType != "")
                {
                    foreach (CommonService.Model.CaseManager.B_CaseLevelchange caseLevelChange in caseLevelChanges)
                    {
                        if (!TransformationTypes.Contains(caseLevelChange.B_CaseLevelchange_type.ToString()))
                        {
                            caseLevelChangeDal.Delete(caseLevelChange.B_CaseLevelchange_code.Value);
                        }
                    }
                }
                else
                {
                    foreach (CommonService.Model.CaseManager.B_CaseLevelchange caseLevelChange in caseLevelChanges)
                    {
                        caseLevelChangeDal.Delete(caseLevelChange.B_CaseLevelchange_code.Value);
                    }
                }
            }
            #endregion

            if (TransformationType != "")
            {
                //将案件之前的变更记录删除
                List<CommonService.Model.CaseManager.B_CaseLevelchange> caseLevelChangeList = caseLevelChangeBLL.GetListByCaseCode(caseCode, 2);
                foreach (CommonService.Model.CaseManager.B_CaseLevelchange caseLevelChange in caseLevelChangeList)
                {
                    caseLevelChangeDal.Delete(caseLevelChange.B_CaseLevelchange_code.Value);
                }
                foreach (string item in TransformationTypes)
                {
                    CommonService.Model.CaseManager.B_CaseLevelchange caseLevelChange = new CommonService.Model.CaseManager.B_CaseLevelchange();
                    caseLevelChange.B_CaseLevelchange_code = Guid.NewGuid();
                    caseLevelChange.B_Case_code = caseCode;
                    caseLevelChange.B_CaseLevelchange_type = Convert.ToInt32(item);
                    caseLevelChange.B_CaseLevelchange_changeRecord = caseLevelChangeRecords.B_CaseLevelChangeRecords_code.Value;
                    if ( isChiefExpert || IsPreSetManager)
                    {//首席专家无需审核，直接通过
                        caseLevelChange.B_CaseLevelchange_state = Convert.ToInt32(CaseLevelChangeStateEnum.通过);
                        caseLevelChange.B_CaseLevelchange_IsValid = true;
                    }
                    else
                    {
                        caseLevelChange.B_CaseLevelchange_state = Convert.ToInt32(CaseLevelChangeStateEnum.待审核);
                        caseLevelChange.B_CaseLevelchange_IsValid = false;
                    }
                    caseLevelChange.B_CaseLevelchange_creator = applicationPerson;
                    caseLevelChange.B_CaseLevelchange_createTime = DateTime.Now;
                    caseLevelChange.B_CaseLevelchange_isDelete = false;

                    //添加案件级别变更记录
                    caseLevelChangeDal.Add(caseLevelChange);
                }
                CommonService.Model.CaseManager.B_Case bcase = dal.GetModel(caseCode);
                #region 给案件首席发送审核消息，如果变更申请人是首席，则不用发消息
                if (bcase.B_Case_firstClassResponsiblePerson != null && isChiefExpert && (!IsPreSetManager))
                {
                    CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                    message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.案件级别变更申请);
                    message.C_Messages_link = caseCode;
                    message.C_Messages_createTime = DateTime.Now;
                    message.C_Messages_person = bcase.B_Case_firstClassResponsiblePerson;
                    message.C_Messages_isRead = 0;
                    message.C_Messages_content = "";
                    message.C_Messages_isValidate = 1;

                    messageDAL.Add(message);
                }
                #endregion

                if ( isChiefExpert || IsPreSetManager)
                {//首席专家无需审核，直接通过,将案件改为策划级案件
                    bcase.B_Case_levelType = 2;
                    dal.Update(bcase);
                }
            }
            #endregion

            return true;
        }

        /// <summary>
        /// 转化审核
        /// </summary>
        /// <param name="CaseLevelchangeCodeStr">案件级别变更Guid</param>
        /// <param name="auditPerson">审核人</param>
        /// <param name="CaseLevelchangeRecord">案件级别变更记录Guid</param>
        /// <param name="ConversionReasons">审核理由</param>
        /// <returns></returns>
        public bool CaseTransformationCheck(string CaseLevelchangeCodeStr, Guid auditPerson, Guid CaseLevelchangeRecord, string ConversionReasons, bool IsPreSetManager, int? caseLevelChangeState)
        {
            #region 案件级别变更记录信息审核信息赋值
            CommonService.Model.CaseManager.B_CaseLevelChangeRecords caseLevelChangeRecords = caseLevelChangeRecordsDal.GetModel(CaseLevelchangeRecord);
            caseLevelChangeRecords.B_CaseLevelChangeRecords_auditor = auditPerson;
            caseLevelChangeRecords.B_CaseLevelChangeRecords_actualChangeDate = DateTime.Now;
            caseLevelChangeRecords.B_CaseLevelChangeRecords_auditOpinion = ConversionReasons;
            caseLevelChangeRecords.B_CaseLevelChangeRecords_isAudit = true;
            //案件级别变更记录信息修改
            caseLevelChangeRecordsDal.Update(caseLevelChangeRecords);
            #endregion

            #region 案件级别变更审核信息赋值
            string[] CaseLevelchangeCodes = CaseLevelchangeCodeStr.Split(',');
            foreach (string CaseLevelchangeCode in CaseLevelchangeCodes)
            {
                CommonService.Model.CaseManager.B_CaseLevelchange caseLevelChange = caseLevelChangeDal.GetModel(new Guid(CaseLevelchangeCode));
                caseLevelChange.B_CaseLevelchange_state = caseLevelChangeState;
                caseLevelChange.B_CaseLevelchange_IsValid = true;
                //案件级别变更审核
                caseLevelChangeDal.Update(caseLevelChange);
            }
            #endregion

            #region 如果案件级别变更审核通过，修改案件为策划级案件
            if (caseLevelChangeState == Convert.ToInt32(CaseLevelChangeStateEnum.通过))
            {
                CommonService.Model.CaseManager.B_Case bcase = dal.GetModel(caseLevelChangeRecords.B_Case_code.Value);
                bcase.B_Case_levelType = 2;
                dal.Update(bcase);
            }
            #endregion

            #region 给申请人发送审核消息
            CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
            message.C_Messages_type = caseLevelChangeState == Convert.ToInt32(CaseLevelChangeStateEnum.通过) ? Convert.ToInt32(MessageTinyTypeEnum.案件级别变更通过) : Convert.ToInt32(MessageTinyTypeEnum.案件级别变更未通过);
            message.C_Messages_link = caseLevelChangeRecords.B_Case_code;
            message.C_Messages_createTime = DateTime.Now;
            message.C_Messages_person = caseLevelChangeRecords.B_CaseLevelChangeRecords_applicationPerson;
            message.C_Messages_isRead = 0;
            message.C_Messages_content = "";
            message.C_Messages_isValidate = 1;

            messageDAL.Add(message);
            #endregion

            return true;
        }
        /// <summary>
        /// 根据客户code找相关的案件
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public List<CommonService.Model.CaseManager.B_Case> GetCaseListByCustomer(Guid customerCode)
        {
            return DataTableToList(dal.GetCaseListByCustomer(customerCode).Tables[0]);
        }
        #endregion  BasicMethod

        #region 报表
        /// <summary>
        /// 根据年份统计
        /// </summary>
        /// <returns></returns>
        public DataSet GetReportByYear()
        {
            return dal.GetReportByYear();
        }

        /// <summary>
        /// 客户团队收案类型统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetReportByCaseTypeCount(Model.Reporting.R_CaseType_Reporting model)
        {
            return dal.GetReportByCaseTypeCount(model);
        }

        /// <summary>
        /// 客户团队收案类型统计
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.Reporting.R_CaseType_Reporting> GetReportByCaseType(Model.Reporting.R_CaseType_Reporting model, int startIndex, int endIndex)
        {
            List<Model.Reporting.R_CaseType_Reporting> lst = new List<Model.Reporting.R_CaseType_Reporting>();
            DataSet ds = dal.GetReportByCaseType(model, startIndex, endIndex);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Model.Reporting.R_CaseType_Reporting rcr = dal.R_CaseType_ReportingTranslate(row);
                lst.Add(rcr);
            }
            return lst;
        }

        /// <summary>
        /// 区域收案统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetReportByAreaCount(Model.Reporting.R_CaseArea_Reporting model)
        {
            return dal.GetReportByAreaCount(model);
        }

        /// <summary>
        /// 区域收案统计
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.Reporting.R_CaseArea_Reporting> GetReportByArea(Model.Reporting.R_CaseArea_Reporting model, int startIndex, int endIndex)
        {
            List<Model.Reporting.R_CaseArea_Reporting> lst = new List<Model.Reporting.R_CaseArea_Reporting>();
            DataSet ds = dal.GetReportByArea(model, startIndex, endIndex);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Model.Reporting.R_CaseArea_Reporting rcr = dal.R_CaseArea_ReportingTranslate(row);
                lst.Add(rcr);
            }
            return lst;
        }

        /// <summary>
        /// 部门收案统计数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetReportByOrganCount(Model.Reporting.R_CaseOrgan_Reporting model)
        {
            return dal.GetReportByOrganCount(model);
        }

        /// <summary>
        /// 部门收案统计
        /// </summary>
        /// <param name="model"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.Reporting.R_CaseOrgan_Reporting> GetReportByArea(Model.Reporting.R_CaseOrgan_Reporting model, int startIndex, int endIndex)
        {
            List<Model.Reporting.R_CaseOrgan_Reporting> lst = new List<Model.Reporting.R_CaseOrgan_Reporting>();
            DataSet ds = dal.GetReportByOrgan(model, startIndex, endIndex);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Model.Reporting.R_CaseOrgan_Reporting rcr = dal.R_CaseOrgan_ReportingTranslate(row);
                lst.Add(rcr);
            }
            return lst;
        }

        #endregion

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
        public List<Model.CaseManager.B_Case> AppMyCase(Model.SysManager.C_Userinfo user, int startIndex, int endIndex, string orderBy, Model.CaseManager.B_Case bcase)
        {
            return GetPowerListByPage(null, bcase, orderBy, startIndex, endIndex, user.C_Userinfo_name == "admin" ? true : false, user.C_Userinfo_code, user.C_Userinfo_post, user.C_Userinfo_Organization);
        }

        /// <summary>
        /// App端根据权限获取案件数量
        /// </summary>
        /// <param name="user">子用户实体</param>
        /// <param name="bcase">案件实体（查询条件）</param>
        /// <returns></returns>
        public int AppMyCaseCount(Model.SysManager.C_Userinfo user, Model.CaseManager.B_Case bcase)
        {
            return GetPowerRecordCount(null, bcase, user.C_Userinfo_name == "admin" ? true : false, user.C_Userinfo_code, user.C_Userinfo_post, user.C_Userinfo_Organization);
        }


        /// <summary>
        /// 获取监控中心横向列表数量
        /// </summary>
        /// <param name="userGuid">用户GUID</param>
        /// <param name="RoleId">用户角色</param>
        /// <param name="deptCode">用户部门ID</param>
        /// <returns></returns>
        public List<Model.CustomModel.KeyValueModel> GetMonitorCase(Guid? userGuid, int? RoleId, Guid? deptCode)
        {
            #region 权限字符串获取
            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;

            List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = roleRolePowerBLL.GetRolePowersByRoleId(RoleId.Value);
            foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
            {
                rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
            }

            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }
            #endregion

            List<Model.CustomModel.KeyValueModel> list = new List<Model.CustomModel.KeyValueModel>();
            Model.CustomModel.KeyValueModel keyValueAll = new Model.CustomModel.KeyValueModel(); //先加一条全部的数据
            keyValueAll.Id = "0"; //为0的是全部
            keyValueAll.Key = "全部";
            keyValueAll.Value = GetPowerRecordCount(null, new Model.CaseManager.B_Case(), false, userGuid, null, deptCode).ToString();
            list.Add(keyValueAll);

            DataSet ds = dal.GetMonitorCase(false, rolePowerIds, userGuid, deptCode);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Model.CustomModel.KeyValueModel keyValue = new Model.CustomModel.KeyValueModel();
                if (item["P_Flow_code"] != null)
                {
                    keyValue.Id = item["P_Flow_code"].ToString();
                }

                if (item["P_Flow_name"] != null)
                {
                    keyValue.Key = item["P_Flow_name"].ToString();
                }

                if (item["CaseCount"] != null)
                {
                    keyValue.Value = item["CaseCount"].ToString();
                }

                list.Add(keyValue);
            }

            return list;
        }

        /// <summary>
        /// 根据用户GUID获取他应该审核的案件
        /// </summary>
        /// <param name="guid">用户GUID</param>
        /// <returns>案件列表</returns>
        public List<Model.CaseManager.B_Case> GetPendingCase(CommonService.Model.CaseManager.B_Case bcase, Guid? guid, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetPendingCase(bcase, guid, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 启动案件
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="startPersonCode">启动人Guid</param>
        /// <returns>-2代表此案件沒有配置阶段，无法启动;-1代表已启动，不可以重复启动;0代表案件启动失败;1代表案件启动成功</returns>
        public int AppStartCase(string caseCode, string startPersonCode)
        {
            Guid _caseCode = new Guid(caseCode);
            Guid _startPersonCode = new Guid(startPersonCode);
            int state = 0;//0代表案件启动失败
            CommonService.Model.CaseManager.B_Case case_info = dal.GetModel(_caseCode);
            if (case_info == null)
                return state;
            if (case_info.B_Case_state != Convert.ToInt32(BusinessFlowStatus.未开始))
            {
                state = -1;//-1代表已启动，不可以重复启动
                return state;
            }
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = bfBLL.GetListByFkCode(_caseCode);
            if (businessFlows.Count == 0)
            {
                state = -2;//-2代表此案件沒有配置阶段，无法启动
                return state;
            }
            if (this.UpdateState(_caseCode, _startPersonCode))
            {
                state = 1;//1代表案件启动成功
            }
            else
            {
                state = 0;//0代表案件启动失败
            }

            return state;
        }

        /// <summary>
        /// 开启单个业务流程
        /// </summary>     
        /// <param name="fkType">业务类型：153、案件 154、商机</param>
        /// <param name="fkCode">业务Guid：案件Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="loginChildrenUser">当前登录子用户Guid</param>
        /// <returns>1代表成功 0代表没有符合条件可以开启的业务流程</returns>       
        public int AppStartSingleBusinessFlow(string fkType, string fkCode, string businessFlowCode, string loginChildrenUser)
        {
            int state = 0;
            int _fkType = Convert.ToInt32(fkType);
            Guid _fkCode = new Guid(fkCode);
            Guid _businessFlowCode = new Guid(businessFlowCode);
            Guid _loginChildrenUser = new Guid(loginChildrenUser);
            DateTime now = DateTime.Now;

            /**
             * author:hety
             * date:2015-12-21
             * description：App启动阶段业务逻辑(主要采用现有ERP系统逻辑，进行扩展)
             * (1)、在App启动阶段的时候，如果对应案件没有启动，则自动启动案件(商机业务先不包括在内，如果以后需要再进行扩展)
             * (2)、调用现有业务流程开启逻辑，进行开启此业务逻辑(只能开启一个业务流程)
             ***/

            #region 处理业务(1)
            if (_fkType == Convert.ToInt32(FlowTypeEnum.案件))
            {
                CommonService.Model.CaseManager.B_Case bCase = dal.GetModel(_fkCode);
                if (bCase.B_Case_state == Convert.ToInt32(BusinessFlowStatus.未开始))
                {
                    bCase.B_Case_factStartTime = now;
                    bCase.B_Case_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                    dal.Update(bCase);
                }
            }
            else if (_fkType == Convert.ToInt32(FlowTypeEnum.商机))
            {

            }
            #endregion

            #region 处理业务(2)
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = new List<P_Business_flow>();
            CommonService.Model.FlowManager.P_Business_flow businessFlow = new CommonService.Model.FlowManager.P_Business_flow();
            businessFlow.P_Business_flow_code = _businessFlowCode;
            businessFlow.P_Business_startPerson = _loginChildrenUser;
            businessFlow.P_Business_startTime = now;
            businessFlow.P_Business_flow_factStartTime = now;
            businessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
            businessFlows.Add(businessFlow);

            state = bfBLL.StartBusinessFlow(businessFlows, fkType);
            #endregion

            return state;
        }


        /// <summary>
        /// 根据案件编码获取专业顾问、专家部长、首席专家
        /// </summary>
        /// <param name="caseCode">案件GUID</param>
        /// <returns></returns>
        public List<CommonService.Model.CustomModel.KeyValueModel> GetPersonByCaseCode(string caseCode)
        {
            Model.CaseManager.B_Case bcase = GetModel(Guid.Parse(caseCode)); //获取到案件
            List<Model.CaseManager.B_Case_link> bcl = clDal.GetConsultantListByCasecode(Guid.Parse(caseCode)); //获取专业顾问列表


            List<CommonService.Model.CustomModel.KeyValueModel> resultList = new List<Model.CustomModel.KeyValueModel>();
            CommonService.Model.CustomModel.KeyValueModel zygw = new Model.CustomModel.KeyValueModel();
            zygw.Key = "专业顾问";
            if (bcl.Count > 0)
            {
                zygw.Value = bcl[0].C_FK_code == null ? "" : bcl[0].C_FK_code.ToString();
            }
            resultList.Add(zygw);

            CommonService.Model.CustomModel.KeyValueModel zjbz = new Model.CustomModel.KeyValueModel();
            zjbz.Key = "专家部长";
            zjbz.Value = bcase.B_Case_person == null ? "" : bcase.B_Case_person.ToString();
            resultList.Add(zjbz);

            CommonService.Model.CustomModel.KeyValueModel sxzj = new Model.CustomModel.KeyValueModel();
            sxzj.Key = "首席专家";
            sxzj.Value = bcase.B_Case_firstClassResponsiblePerson == null ? "" : bcase.B_Case_firstClassResponsiblePerson.ToString();
            resultList.Add(sxzj);

            return resultList;
        }

        #endregion
    }
}

