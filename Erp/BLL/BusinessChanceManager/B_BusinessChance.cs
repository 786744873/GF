using System;
using System.Data;
using System.Collections.Generic;
using CommonService.Common;
using CommonService.Model;
using System.Collections;
using System.Linq;
namespace CommonService.BLL.BusinessChanceManager
{
    /// <summary>
    /// 商机表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/07/27
    /// </summary>
    public partial class B_BusinessChance
    {
        #region ......
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance dal = new CommonService.DAL.BusinessChanceManager.B_BusinessChance();
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance_link bclDal = new CommonService.DAL.BusinessChanceManager.B_BusinessChance_link();
        private readonly CommonService.DAL.C_Competitor comDal = new CommonService.DAL.C_Competitor();
        private readonly CommonService.BLL.SysManager.C_Userinfo userinfoBll = new CommonService.BLL.SysManager.C_Userinfo();
        private readonly CommonService.DAL.SysManager.C_Userinfo userinfoDal = new CommonService.DAL.SysManager.C_Userinfo();
        private readonly CommonService.BLL.SysManager.C_Post postBll = new CommonService.BLL.SysManager.C_Post();
        private readonly CommonService.DAL.SysManager.C_Organization orgDAL = new CommonService.DAL.SysManager.C_Organization();
        private readonly CommonService.BLL.SysManager.C_Organization_post org_postBll = new CommonService.BLL.SysManager.C_Organization_post();
        private readonly CommonService.DAL.C_Region regionDAL = new CommonService.DAL.C_Region();
        /// <summary>
        /// 部长首席关联表逻辑层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_ChiefExpert_Minister MinisterDAL = new DAL.SysManager.C_ChiefExpert_Minister();
        /// <summary>
        /// 业务流程业务逻辑
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow bfBLL = new CommonService.BLL.FlowManager.P_Business_flow();
        /// <summary>
        /// 业务流程数据访问层
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow bfDAL = new CommonService.DAL.FlowManager.P_Business_flow();
        /// <summary>
        /// 消息数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();
        /// <summary>
        /// 业务流程—表单中间表逻辑
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow_form bffBLL = new CommonService.BLL.FlowManager.P_Business_flow_form();
        /// <summary>
        /// 业务流程—表单中间表数据访问层
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow_form bffDAL = new CommonService.DAL.FlowManager.P_Business_flow_form();
        /// <summary>
        /// 表单属性数据访问类
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_FormProperty formPropertyDAL = new CommonService.DAL.CustomerForm.F_FormProperty();
        /// <summary>
        /// 表单属性值业务访问层
        /// </summary>
        private readonly CommonService.BLL.CustomerForm.F_FormPropertyValue formPropertyValueBll = new CommonService.BLL.CustomerForm.F_FormPropertyValue();
        /// <summary>
        /// 业务流程关联表单关联用户业务逻辑层
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow_form_user businessFlowFormUserBLL = new CommonService.BLL.FlowManager.P_Business_flow_form_user();
        /// <summary>
        /// 案件业务逻辑层
        /// </summary>
        private readonly CommonService.BLL.CaseManager.B_Case caseBll = new CommonService.BLL.CaseManager.B_Case();
        /// <summary>
        /// 案件关联表业务逻辑层
        /// </summary>
        private readonly CommonService.BLL.CaseManager.B_Case_link caseLinkBll = new CommonService.BLL.CaseManager.B_Case_link();
        /// <summary>
        /// 涉案合同权益分配业务逻辑层
        /// </summary>
        private readonly CommonService.BLL.CaseManager.B_EqAllot eqallotBll = new CommonService.BLL.CaseManager.B_EqAllot();
        /// <summary>
        /// 费用承担业务逻辑层
        /// </summary>
        private readonly CommonService.BLL.CaseManager.B_BearToPay bearToPayBll = new CommonService.BLL.CaseManager.B_BearToPay();
        /// <summary>
        /// 担保物协定业务逻辑层
        /// </summary>
        private readonly CommonService.BLL.CaseManager.B_Oppint oppintBll = new CommonService.BLL.CaseManager.B_Oppint();
        /// <summary>
        /// 附件业务逻辑层
        /// </summary>
        private readonly CommonService.BLL.C_Files filesBll = new CommonService.BLL.C_Files();
        /// <summary>
        /// 收款明细业务逻辑层
        /// </summary>
        private readonly CommonService.BLL.CaseManager.B_RDetail rdetailBll = new CommonService.BLL.CaseManager.B_RDetail();
        /// <summary>
        /// 参数表数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Parameters parDal = new CommonService.DAL.C_Parameters();
        /// <summary>
        /// 区域数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Region regionDal = new CommonService.DAL.C_Region();
        /// <summary>
        /// 角色-角色权限业务访问逻辑层
        /// </summary>
        private readonly CommonService.BLL.SysManager.C_Role_Role_Power roleRolePowerBLL = new CommonService.BLL.SysManager.C_Role_Role_Power();
        /// <summary>
        /// 表单审核业务访问层
        /// </summary>
        private readonly CommonService.BLL.CustomerForm.F_FormCheck formCheckBLL = new CommonService.BLL.CustomerForm.F_FormCheck();
        /// <summary>
        /// 组织架构-岗位-用户中间表数据访问层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_Organization_post_user orgPostUserDAL = new CommonService.DAL.SysManager.C_Organization_post_user();
        #endregion
        public B_BusinessChance()
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
        public bool Exists(int B_BusinessChance_id)
        {
            return dal.Exists(B_BusinessChance_id);
        }

        /// <summary>
        /// 是否存在该条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsByName(Model.BusinessChanceManager.B_BusinessChance model)
        {
            return dal.ExistsByName(model);
        }

        /// <summary>
        /// 修改商机进行状态
        /// </summary>
        /// <param name="B_BusinessChance_code">商机Guid</param>
        /// <param name="startPersonCode">启动人Guid</param>
        /// <returns></returns>
        public bool UpdateState(Guid B_BusinessChance_code, Guid startPersonCode)
        {
            bool isSuccess = true;

            try
            {
                #region 启动商机任务
                DateTime now = DateTime.Now;
                CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = GetModel(B_BusinessChance_code);
                if (businessChance.B_BusinessChance_state != Convert.ToInt32(BusinessFlowStatus.未开始))
                {
                    return isSuccess;
                }
                businessChance.B_BusinessChance_factStartTime = now;
                businessChance.B_BusinessChance_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                isSuccess = dal.Update(businessChance);

                #endregion

                #region 启动业务流程

                List<CommonService.Model.FlowManager.P_Business_flow> business_flow = bfBLL.GetListByFkCode(B_BusinessChance_code);
                SetSingleTopBusinessFlow(business_flow, now, startPersonCode);

                #endregion

            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }

        /// <summary>
        /// 装载顶级业务流程
        /// </summary>
        /// <param name="businessFlowList">业务流程集合</param>
        /// <param name="now">当前操作时间</param>
        /// <param name="startPersonCode">启动人Guid</param>
        private void SetSingleTopBusinessFlow(List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList, DateTime now, Guid startPersonCode)
        {
            ArrayList businessFlowFormRepins = new ArrayList();//表单主办律师集合
            string BusinessflowCode = "";
            var topBusinessFlowList = from allList in businessFlowList
                                      where allList.P_Business_flow_level == 1 && allList.P_Business_state == Convert.ToInt32(BusinessFlowStatus.未开始)
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
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
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
                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
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
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
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
        /// <param name="now">当前操作时间</param>
        /// <param name="startPersonCode">启动人Guid</param>
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
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
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
                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
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
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
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
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.BusinessChanceManager.B_BusinessChance model)
        {
            #region 根据专业顾问给部长和首席赋值
            CommonService.Model.BusinessChanceManager.B_BusinessChance_link businessLink = bclDal.GetModelByFk_codeAndType(model.B_BusinessChance_code.Value, 5);
            if (businessLink != null && businessLink.C_FK_code != null)
            {
                Model.SysManager.C_Userinfo buzhang = userinfoBll.GetBuZhangByUserCode(businessLink.C_FK_code.Value); //直接找部长
                //案件的负责人默认为客户的专业顾问的部长
                if (buzhang != null)
                {
                    model.B_BusinessChance_person = buzhang.C_Userinfo_code; //部长赋值

                    BLL.SysManager.C_ChiefExpert_Minister ccmBLL = new SysManager.C_ChiefExpert_Minister(); //部长首席关联
                    Model.SysManager.C_ChiefExpert_Minister ccm = ccmBLL.GetModelByMinister(buzhang.C_Userinfo_code.Value); //根据部长GUID获取首席
                    if (ccm != null)
                    {
                        model.B_BusinessChance_firstClassResponsiblePerson = ccm.C_ChiefExpert_Code; //首席赋值
                    }
                }
            }
            #endregion

            #region 如果此商机有默认部长，则给部长发送消息
            if (model.B_BusinessChance_person != null && model.B_BusinessChance_person.Value != Guid.Empty)
            {
                CommonService.Model.C_Messages message = new Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.新增案件);
                message.C_Messages_link = model.B_BusinessChance_code;
                message.C_Messages_createTime = DateTime.Now;
                message.C_Messages_person = model.B_BusinessChance_person;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
            }
            #endregion

            #region 商机编码
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChanceModel = dal.GetModelByNumber(model.B_BusinessChance_number);
            string caseNum = "";
            if (businessChanceModel != null)
            {
                caseNum = businessChanceModel.B_BusinessChance_number.Substring(businessChanceModel.B_BusinessChance_number.Length - 4, 4);
                int n = int.Parse(caseNum) + 1;
                model.B_BusinessChance_number = model.B_BusinessChance_number + n.ToString("0000");
            }
            else
            {
                model.B_BusinessChance_number = model.B_BusinessChance_number + "0000";
            }
            #endregion

            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.BusinessChanceManager.B_BusinessChance model)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = GetModel(model.B_BusinessChance_code.Value);
            #region 根据专业顾问修改部长和首席
            CommonService.Model.BusinessChanceManager.B_BusinessChance_link businessLink = bclDal.GetModelByFk_codeAndType(businessChance.B_BusinessChance_code.Value, 5);
            if (businessLink != null && businessLink.C_FK_code != null)
            {
                Model.SysManager.C_Userinfo buzhang = userinfoBll.GetBuZhangByUserCode(businessLink.C_FK_code.Value); //直接找部长
                //案件的负责人默认为客户的专业顾问的部长
                if (buzhang != null)
                {
                    model.B_BusinessChance_person = buzhang.C_Userinfo_code; //部长赋值

                    BLL.SysManager.C_ChiefExpert_Minister ccmBLL = new SysManager.C_ChiefExpert_Minister(); //部长首席关联
                    Model.SysManager.C_ChiefExpert_Minister ccm = ccmBLL.GetModelByMinister(buzhang.C_Userinfo_code.Value); //根据部长GUID获取首席
                    if (ccm != null)
                    {
                        model.B_BusinessChance_firstClassResponsiblePerson = ccm.C_ChiefExpert_Code; //首席赋值
                    }
                }
            }
            #endregion
            model.B_BusinessChance_number = businessChance.B_BusinessChance_number;

            #region 在“首席专家”或者"部长"改变的时候，变更"表单审核"中的审核人(若表单最后审核人为"首席专家"或者"部长"的时候，才需要变更)
            //目前不考虑“首席专家”或者"部长"是同一人，
            List<CommonService.Model.CustomerForm.F_FormCheck> unFormChecks = formCheckBLL.GetUnCheckRecordByFkCode(model.B_BusinessChance_code.Value);
            foreach (CommonService.Model.CustomerForm.F_FormCheck formCheck in unFormChecks)
            {
                if (model.B_BusinessChance_person != businessChance.B_BusinessChance_person)
                {//变更部长
                    if (formCheck.F_FormCheck_checkPerson == businessChance.B_BusinessChance_person)
                    {
                        formCheck.F_FormCheck_checkPerson = model.B_BusinessChance_person;
                        formCheckBLL.Update(formCheck);
                    }
                }
                if (businessChance.B_BusinessChance_firstClassResponsiblePerson != model.B_BusinessChance_firstClassResponsiblePerson)
                {//变更首席专家
                    if (formCheck.F_FormCheck_checkPerson == businessChance.B_BusinessChance_firstClassResponsiblePerson)
                    {
                        formCheck.F_FormCheck_checkPerson = model.B_BusinessChance_firstClassResponsiblePerson;
                        formCheckBLL.Update(formCheck);
                    }
                }
            }
            #endregion

            #region 当商机分配负责人时，给该负责人发送消息
            if (model.B_BusinessChance_person != businessChance.B_BusinessChance_person)
            {
                CommonService.Model.C_Messages message = new Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.新增案件);
                message.C_Messages_link = model.B_BusinessChance_code.Value;
                message.C_Messages_createTime = DateTime.Now;
                message.C_Messages_person = model.B_BusinessChance_person;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
            }
            #endregion

            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid B_BusinessChance_code)
        {
            bool isSuccess = false;
            isSuccess = dal.Delete(B_BusinessChance_code);
            isSuccess = bclDal.DeleteByBusinessChanceCode(B_BusinessChance_code);
            return isSuccess;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string B_BusinessChance_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(B_BusinessChance_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.BusinessChanceManager.B_BusinessChance GetModel(Guid B_BusinessChance_code)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = dal.GetModel(B_BusinessChance_code);

            #region 变量
            string customerCodeStr = "";
            string customerNameStr = "";
            string clientCodeStr = "";
            string clientNameStr = "";
            string personCodeStr = "";
            string personNameStr = "";
            string personTypeStr = "";
            string projectCodeStr = "";
            string projectNameStr = "";
            string consultantCodeStr = "";
            string consultantNameStr = "";
            string regionCodeStr = "";
            string regionNameStr = "";
            #endregion

            #region
            List<Model.BusinessChanceManager.B_BusinessChance_link> Customers = bclDal.GetCustomerListByBusinessChancecode(B_BusinessChance_code);
            foreach (var customer in Customers)
            {
                if (customer.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.客户))
                { //客户
                    customerCodeStr += customer.C_FK_code.ToString() + ',';
                    customerNameStr += customer.C_Customer_name + ',';
                }
                else if (customer.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.委托人))
                {//委托人
                    clientCodeStr += customer.C_FK_code.ToString() + ',';
                    clientNameStr += customer.C_Customer_name + ',';
                }
            }

            List<Model.BusinessChanceManager.B_BusinessChance_link> CRivals = bclDal.GetCRivalListByBusinessChancecode(B_BusinessChance_code);
            foreach (var crival in CRivals)
            {
                if (crival.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.对方当事人公司))
                {//对方当事人（公司）
                    personCodeStr += crival.C_FK_code.ToString() + ',';
                    personNameStr += crival.C_CRival_name + ',';
                    personTypeStr += crival.B_BusinessChance_link_type.ToString() + ',';
                }
            }

            List<Model.BusinessChanceManager.B_BusinessChance_link> PRivals = bclDal.GetPRivalListByBusinessChancecode(B_BusinessChance_code);
            foreach (var prival in PRivals)
            {
                if (prival.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.对方当事人个人))
                {//对方当事人（个人）
                    personCodeStr += prival.C_FK_code.ToString() + ',';
                    personNameStr += prival.C_PRival_name + ',';
                    personTypeStr += prival.B_BusinessChance_link_type.ToString() + ',';
                }
            }

            List<Model.BusinessChanceManager.B_BusinessChance_link> Projects = bclDal.GetProjectListByBusinessChancecode(B_BusinessChance_code);
            foreach (var project in Projects)
            {
                if (project.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.工程))
                {//工程
                    projectCodeStr += project.C_FK_code.ToString() + ',';
                    projectNameStr += project.C_Involved_project_name + ',';
                }
            }

            List<Model.BusinessChanceManager.B_BusinessChance_link> Consultants = bclDal.GetConsultantListByBusinessChancecode(B_BusinessChance_code);
            foreach (var consultant in Consultants)
            {
                if (consultant.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.销售顾问))
                {//销售顾问
                    consultantCodeStr += consultant.C_FK_code.ToString() + ',';
                    consultantNameStr += consultant.C_Userinfo_name + ',';
                }
            }

            List<Model.BusinessChanceManager.B_BusinessChance_link> Regions = bclDal.GetRegionListByBusinessChancecode(B_BusinessChance_code);
            foreach (var region in Regions)
            {
                if (region.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.区域))
                {//区域
                    regionCodeStr += region.C_FK_code.ToString() + ',';
                    regionNameStr += region.C_Region_name + ',';
                }
            }

            #endregion

            #region 虚拟字段赋值
            businessChance.B_BusinessChance_Customer_code = customerCodeStr == "" ? customerCodeStr : customerCodeStr.Substring(0, customerCodeStr.Length - 1);
            businessChance.B_BusinessChance_Customer_name = customerNameStr == "" ? customerNameStr : customerNameStr.Substring(0, customerNameStr.Length - 1);
            businessChance.B_BusinessChance_Client_code = clientCodeStr == "" ? clientCodeStr : clientCodeStr.Substring(0, clientCodeStr.Length - 1);
            businessChance.B_BusinessChance_Client_name = clientNameStr == "" ? clientNameStr : clientNameStr.Substring(0, clientNameStr.Length - 1);
            businessChance.B_BusinessChance_Person_code = personCodeStr == "" ? personCodeStr : personCodeStr.Substring(0, personCodeStr.Length - 1);
            businessChance.B_BusinessChance_Person_name = personNameStr == "" ? personNameStr : personNameStr.Substring(0, personNameStr.Length - 1);
            businessChance.B_BusinessChance_Person_type = personTypeStr == "" ? personTypeStr : personTypeStr.Substring(0, personTypeStr.Length - 1);
            businessChance.B_BusinessChance_Project_code = projectCodeStr == "" ? projectCodeStr : projectCodeStr.Substring(0, projectCodeStr.Length - 1);
            businessChance.B_BusinessChance_Project_name = projectNameStr == "" ? projectNameStr : projectNameStr.Substring(0, projectNameStr.Length - 1);
            businessChance.B_BusinessChance_consultant_code = consultantCodeStr == "" ? consultantCodeStr : consultantCodeStr.Substring(0, consultantCodeStr.Length - 1);
            businessChance.B_BusinessChance_consultant_name = consultantNameStr == "" ? consultantNameStr : consultantNameStr.Substring(0, consultantNameStr.Length - 1);
            businessChance.B_BusinessChance_Region_code = regionCodeStr == "" ? regionCodeStr : regionCodeStr.Substring(0, regionCodeStr.Length - 1);
            businessChance.B_BusinessChance_Region_name = regionNameStr == "" ? regionNameStr : regionNameStr.Substring(0, regionNameStr.Length - 1);
            #endregion

            #region 关联竞争对手
            CommonService.Model.C_Competitor competitor = comDal.GetModel(businessChance.B_BusinessChance_Competitor.Value);
            if (competitor != null)
            {
                businessChance.B_BusinessChance_Competitor = competitor.C_Competitor_code;
                businessChance.B_BusinessChance_Competitor_name = competitor.C_Competitor_name;
            }
            #endregion

            #region 一级负责人
            if (businessChance.B_BusinessChance_firstClassResponsiblePerson == null)
            {
                if (businessChance.B_BusinessChance_consultant_code != "")
                {
                    string[] businessChance_consultantCodes = businessChance.B_BusinessChance_consultant_code.Split(',');
                    //专业顾问实体
                    //CommonService.Model.SysManager.C_Userinfo userinfo = userinfoDal.GetModelByUserCode(new Guid(businessChance_consultantCodes[0]));
                    CommonService.Model.SysManager.C_Organization_post_user organizationPostUserModel = orgPostUserDAL.GetModelByPostAndUser(new Guid("C5E154C7-D8FE-46D4-9FA6-07084403A88E"), new Guid(businessChance_consultantCodes[0]));
                    List<CommonService.Model.SysManager.C_Post> postList = postBll.GetList();//所有岗位集合
                    ArrayList postCodes = new ArrayList();//岗位-首席专家集合
                    foreach (CommonService.Model.SysManager.C_Post post in postList)
                    {
                        if (post.C_Post_name.Contains("首席专家"))
                        {
                            postCodes.Add(post.C_Post_code);
                        }
                    }
                    //专业顾问所属组织机构下岗位集合
                    List<CommonService.Model.SysManager.C_Organization_post> org_postList = org_postBll.GetListByOrgCode(organizationPostUserModel.C_Organization_code.Value);
                    string chiefExpert = "";//首席专家
                    foreach (var postCode in postCodes)
                    {
                        foreach (var org_post in org_postList)
                        {
                            if (org_post.C_Post_code.ToString() == postCode.ToString())
                            {
                                chiefExpert = org_post.C_Post_code.ToString();
                            }
                        }
                    }
                    if (!String.IsNullOrEmpty(chiefExpert))
                    {
                        CommonService.Model.SysManager.C_Userinfo chiefExpertModel = userinfoDal.GetModelByUserCode(new Guid(chiefExpert));
                        businessChance.B_BusinessChance_firstClassResponsiblePerson = chiefExpertModel.C_Userinfo_code;
                        businessChance.B_BusinessChance_firstClassResponsiblePerson_name = chiefExpertModel.C_Userinfo_name;
                    }
                }
            }
            #endregion

            return businessChance;
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.BusinessChanceManager.B_BusinessChance GetModelByCache(int B_BusinessChance_id)
        {

            string CacheKey = "B_BusinessChanceModel-" + B_BusinessChance_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(B_BusinessChance_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.BusinessChanceManager.B_BusinessChance)objModel;
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
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.BusinessChanceManager.B_BusinessChance> modelList = new List<CommonService.Model.BusinessChanceManager.B_BusinessChance>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.BusinessChanceManager.B_BusinessChance model;
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
        public int GetRecordCount(CommonService.Model.BusinessChanceManager.B_BusinessChance model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.BusinessChanceManager.B_BusinessChance> GetListByPage(CommonService.Model.BusinessChanceManager.B_BusinessChance model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 商机转案件
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>
        public bool BusinessChanceConvertCase(Guid businessChanceCode, string levelType)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = GetModel(businessChanceCode);

            #region 案件信息

            CommonService.Model.CaseManager.B_Case bcase = new Model.CaseManager.B_Case();
            bcase.B_Case_code = Guid.NewGuid();
            bcase.B_Case_contractNo = "";
            bcase.B_Case_type = businessChance.B_BusinessChance_type;
            bcase.B_Case_nature = businessChance.B_BusinessChance_Case_nature;
            bcase.B_Case_customerType = businessChance.B_BusinessChance_customerType;
            bcase.B_Case_registerTime = DateTime.Now;
            bcase.B_Case_remark = businessChance.B_BusinessChance_remark;
            bcase.B_Case_state = Convert.ToInt32(BusinessFlowStatus.未开始);
            bcase.B_Case_transferTargetMoney = businessChance.B_BusinessChance_transferTargetMoney;
            bcase.B_Case_transferTargetOther = businessChance.B_BusinessChance_transferTargetOther;
            bcase.B_Case_expectedGrant = businessChance.B_BusinessChance_expectedGrant;
            bcase.B_Case_execMoney = businessChance.B_BusinessChance_execMoney;
            bcase.B_Case_execOther = businessChance.B_BusinessChance_execOther;
            bcase.B_Case_courtFirst = businessChance.B_BusinessChance_courtFirst;
            bcase.B_Case_courtSecond = businessChance.B_BusinessChance_courtSecond;
            bcase.B_Case_courtExec = businessChance.B_BusinessChance_courtExec;
            bcase.B_Case_Trial = null;
            bcase.B_Case_Requirement = businessChance.B_BusinessChance_Requirement;
            bcase.B_Case_Remarks = businessChance.B_BusinessChance_remarks;
            bcase.B_Case_creator = businessChance.B_BusinessChance_creator;
            bcase.B_Case_createTime = DateTime.Now;
            bcase.B_Case_isDelete = 0;
            bcase.B_Case_person = businessChance.B_BusinessChance_person;
            bcase.B_Case_firstClassResponsiblePerson = businessChance.B_BusinessChance_firstClassResponsiblePerson;
            bcase.B_Case_levelType = Convert.ToInt32(levelType);
            bcase.C_Client_name = businessChance.B_BusinessChance_Client_name;
            bcase.B_Case_Rival_name = businessChance.B_BusinessChance_Person_name;
            bcase.C_Region_code = businessChance.B_BusinessChance_Region_code;
            bcase.B_Case_businessChance_Code = businessChance.B_BusinessChance_code;

            //案件名称
            string[] clientNames = bcase.C_Client_name.Split(',');
            foreach (var clientName in clientNames)
            {
                bcase.B_Case_name += clientName + "+";
            }
            bcase.B_Case_name = bcase.B_Case_name.Substring(0, bcase.B_Case_name.Length - 1);
            CommonService.Model.C_Parameters Case_type = parDal.GetModel(bcase.B_Case_type.Value);
            bcase.B_Case_name += "_" + Case_type.C_Parameters_name + "_";
            string[] rivalNames = bcase.B_Case_Rival_name.Split(',');
            foreach (var rivalName in rivalNames)
            {
                bcase.B_Case_name += rivalName + "+";
            }
            bcase.B_Case_name = bcase.B_Case_name.Substring(0, bcase.B_Case_name.Length - 1);

            //案件编码
            string region = bcase.C_Region_code.Split(',').First();
            string regionAbbreviation = regionDal.GetModelByCode(new Guid(region)).C_Region_abbreviation;
            string caseType = parDal.GetModel(bcase.B_Case_type.Value).C_Parameters_abbreviation;
            bcase.B_Case_number = "BC" + DateTime.Now.ToString("yyyy") + regionAbbreviation + "MS" + caseType;
            #region 案件关联表信息

            List<CommonService.Model.CaseManager.B_Case_link> caseLinks = new List<Model.CaseManager.B_Case_link>();

            #region 客户
            if (!String.IsNullOrEmpty(businessChance.B_BusinessChance_Customer_code))
            {
                string[] customerCodes = businessChance.B_BusinessChance_Customer_code.Split(',');
                foreach (var customerCode in customerCodes)
                {
                    CommonService.Model.CaseManager.B_Case_link caselink = new CommonService.Model.CaseManager.B_Case_link();
                    caselink.B_Case_code = bcase.B_Case_code;
                    caselink.C_FK_code = new Guid(customerCode);
                    caselink.B_Case_link_type = Convert.ToInt32(CaselinkEnum.客户);
                    caselink.B_Case_link_creator = bcase.B_Case_creator;
                    caselink.B_Case_link_createTime = bcase.B_Case_createTime;
                    caselink.B_Case_link_isDelete = 0;

                    caseLinks.Add(caselink);
                }
            }

            #endregion

            #region 委托人
            if (!String.IsNullOrEmpty(businessChance.B_BusinessChance_Client_code))
            {
                string[] clientCodes = businessChance.B_BusinessChance_Client_code.Split(',');
                foreach (var clientCode in clientCodes)
                {
                    CommonService.Model.CaseManager.B_Case_link caselink = new CommonService.Model.CaseManager.B_Case_link();
                    caselink.B_Case_code = bcase.B_Case_code;
                    caselink.C_FK_code = new Guid(clientCode);
                    caselink.B_Case_link_type = Convert.ToInt32(CaselinkEnum.委托人);
                    caselink.B_Case_link_creator = bcase.B_Case_creator;
                    caselink.B_Case_link_createTime = bcase.B_Case_createTime;
                    caselink.B_Case_link_isDelete = 0;

                    caseLinks.Add(caselink);
                }
            }

            #endregion

            #region 对方当事人
            if (!String.IsNullOrEmpty(businessChance.B_BusinessChance_Person_code))
            {
                string[] partyCodes = businessChance.B_BusinessChance_Person_code.Split(',');
                string[] partyType = businessChance.B_BusinessChance_Person_type.Split(',');
                int i = 0;
                foreach (var party_code in partyCodes)
                {
                    CommonService.Model.CaseManager.B_Case_link thisPerson = new CommonService.Model.CaseManager.B_Case_link();
                    thisPerson.B_Case_code = bcase.B_Case_code;
                    thisPerson.C_FK_code = new Guid(party_code);
                    thisPerson.B_Case_link_type = Convert.ToInt32(partyType[i]);
                    thisPerson.B_Case_link_creator = bcase.B_Case_creator;
                    thisPerson.B_Case_link_createTime = bcase.B_Case_createTime;
                    thisPerson.B_Case_link_isDelete = 0;

                    caseLinks.Add(thisPerson);
                    i++;
                }
            }

            #endregion

            #region 工程
            if (!String.IsNullOrEmpty(businessChance.B_BusinessChance_Project_code))
            {
                string[] projectCodes = businessChance.B_BusinessChance_Project_code.Split(',');
                foreach (var project_code in projectCodes)
                {
                    CommonService.Model.CaseManager.B_Case_link project = new CommonService.Model.CaseManager.B_Case_link();
                    project.B_Case_code = bcase.B_Case_code;
                    project.C_FK_code = new Guid(project_code);
                    project.B_Case_link_type = Convert.ToInt32(CaselinkEnum.工程);
                    project.B_Case_link_creator = bcase.B_Case_creator;
                    project.B_Case_link_createTime = bcase.B_Case_createTime;
                    project.B_Case_link_isDelete = 0;

                    caseLinks.Add(project);
                }
            }

            #endregion

            #region 专业顾问
            CommonService.Model.BusinessChanceManager.B_BusinessChance_link bcl = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
            DataSet ds = bclDal.GetLinkByCode((Guid)businessChance.B_BusinessChance_code, Convert.ToInt32(CaselinkEnum.销售顾问));
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                CommonService.Model.CaseManager.B_Case_link project = new CommonService.Model.CaseManager.B_Case_link();
                project.B_Case_code = bcase.B_Case_code;
                project.C_FK_code = new Guid(item["C_FK_code"].ToString());
                project.B_Case_link_type = Convert.ToInt32(CaselinkEnum.销售顾问);
                project.B_Case_link_creator = bcase.B_Case_creator;
                project.B_Case_link_createTime = bcase.B_Case_createTime;
                project.B_Case_link_isDelete = 0;

                caseLinks.Add(project);

            }
            #endregion

            #region 区域
            if (!String.IsNullOrEmpty(businessChance.B_BusinessChance_Region_code))
            {
                string[] regionCodes = businessChance.B_BusinessChance_Region_code.Split(',');
                foreach (var region_code in regionCodes)
                {
                    CommonService.Model.CaseManager.B_Case_link area = new CommonService.Model.CaseManager.B_Case_link();
                    area.B_Case_code = bcase.B_Case_code;
                    area.C_FK_code = new Guid(region_code);
                    area.B_Case_link_type = Convert.ToInt32(CaselinkEnum.所属区域);
                    area.B_Case_link_creator = bcase.B_Case_creator;
                    area.B_Case_link_createTime = bcase.B_Case_createTime;
                    area.B_Case_link_isDelete = 0;

                    caseLinks.Add(area);
                }
            }

            #endregion

            caseLinkBll.OperateList(caseLinks);

            #endregion
            caseBll.Add(bcase);

            #region 给案件的负责人和一级负责人发送新增案件消息
            if (bcase.B_Case_person != null)
            {
                CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.新增案件);
                submitMessage.C_Messages_link = bcase.B_Case_code;
                submitMessage.C_Messages_createTime = bcase.B_Case_createTime;
                submitMessage.C_Messages_person = bcase.B_Case_person;
                submitMessage.C_Messages_isRead = 0;
                submitMessage.C_Messages_content = "";
                submitMessage.C_Messages_isValidate = 1;

                messageDAL.Add(submitMessage);
            }
            if (bcase.B_Case_firstClassResponsiblePerson != null)
            {
                CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.新增案件);
                submitMessage.C_Messages_link = bcase.B_Case_code;
                submitMessage.C_Messages_createTime = bcase.B_Case_createTime;
                submitMessage.C_Messages_person = bcase.B_Case_firstClassResponsiblePerson;
                submitMessage.C_Messages_isRead = 0;
                submitMessage.C_Messages_content = "";
                submitMessage.C_Messages_isValidate = 1;

                messageDAL.Add(submitMessage);
            }
            #endregion

            #endregion

            #region 案件附表信息

            #region 客户约定
            //涉案合同权益分配
            List<CommonService.Model.CaseManager.B_EqAllot> eqallots = eqallotBll.GetAllListByCaseCode(businessChanceCode);
            foreach (CommonService.Model.CaseManager.B_EqAllot eqallot in eqallots)
            {
                eqallot.B_EqAllot_code = Guid.NewGuid();
                eqallot.B_Case_code = bcase.B_Case_code;

                eqallotBll.Add(eqallot);
            }
            //费用承担
            List<CommonService.Model.CaseManager.B_BearToPay> bearToPays = bearToPayBll.GetListByCaseCode(businessChanceCode);
            foreach (CommonService.Model.CaseManager.B_BearToPay bearToPay in bearToPays)
            {
                bearToPay.B_BearToPay_code = Guid.NewGuid();
                bearToPay.B_Case_code = bcase.B_Case_code;

                bearToPayBll.Add(bearToPay);
            }
            //担保物协定
            List<CommonService.Model.CaseManager.B_Oppint> oppints = oppintBll.GetListByCaseCode(businessChanceCode);
            foreach (CommonService.Model.CaseManager.B_Oppint oppint in oppints)
            {
                oppint.B_Oppint_code = Guid.NewGuid();
                oppint.B_Case_code = bcase.B_Case_code;

                oppintBll.Add(oppint);
            }

            #endregion

            //收案材料清单
            List<CommonService.Model.C_Files> files = filesBll.GetListByFileLink(businessChanceCode);
            foreach (CommonService.Model.C_Files file in files)
            {
                file.C_Files_code = Guid.NewGuid();
                file.C_Files_link = bcase.B_Case_code;

                filesBll.Add(file);
            }

            //收款明细
            List<CommonService.Model.CaseManager.B_RDetail> rdetails = rdetailBll.GetListByRelationCode(businessChanceCode);
            foreach (CommonService.Model.CaseManager.B_RDetail rdetail in rdetails)
            {
                rdetail.B_RDetail_code = Guid.NewGuid();
                rdetail.B_Case_code = bcase.B_Case_code;

                rdetailBll.Add(rdetail);
            }

            #endregion

            #region 结束当前商机没有结束的业务流程以及表单
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList = bfBLL.GetListByFkCode(businessChanceCode);
            foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in businessFlowList)
            {
                if (businessFlow.P_Business_state != Convert.ToInt32(BusinessFlowStatus.已结束))
                {
                    //结束当前业务流程
                    businessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                    businessFlow.P_Business_flow_factEndTime = DateTime.Now;
                    bfDAL.Update(businessFlow);
                    //根据业务流程"实际结束时间"更新关联条目统计信息时间值
                    bfDAL.UpdateEntryStatisticsByBusinessFlowTime(businessFlow.P_Business_flow_code.Value, "factEndTime", businessFlow.P_Business_flow_factEndTime.Value);

                    //发送队列消息
                    MSMQ.SendMessage();

                    List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms = bffBLL.OnlyGetBusinessFlowForms(businessFlow.P_Business_flow_code.Value);
                    foreach (CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm in businessFlowForms)
                    {
                        if (businessFlowForm.P_Business_flow_form_state != Convert.ToInt32(BusinessFlowStatus.已结束))
                        {
                            businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                            businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);

                            #region 更新表单实际结束时间
                            CommonService.Model.CustomerForm.F_FormProperty planEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                            if (planEndTimeFormProperty != null)
                            {
                                formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, planEndTimeFormProperty.F_FormProperty_code.Value, businessFlow.P_Business_flow_factEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                bffDAL.UpdateEntryStatisticsByFormTime(businessFlowForm.P_Business_flow_form_code.Value, "factEndTime", businessFlow.P_Business_flow_factEndTime.Value);
                                MSMQ.SendMessage();
                            }
                            #endregion

                            bffDAL.Update(businessFlowForm);
                        }
                    }
                }
            }
            #endregion

            businessChance.B_BusinessChance_state = Convert.ToInt32(BusinessFlowStatus.已结束);
            dal.Update(businessChance);

            return true;
        }

        /// <summary>
        /// 商机转案件
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="caseCategory">案件分类</param>
        /// <returns></returns>
        public bool TranslateToCaseFromBusinessChance(Guid businessChanceCode, int? caseCategory)
        {
            /***
             * author:hety
             * date:2015-11-05
             * Description:商机转案件
             ***/
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = GetModel(businessChanceCode);

            #region 案件信息

            CommonService.Model.CaseManager.B_Case bcase = new Model.CaseManager.B_Case();
            bcase.B_Case_code = Guid.NewGuid();
            bcase.B_Case_contractNo = "";
            bcase.B_Case_type = businessChance.B_BusinessChance_type;
            bcase.B_Case_nature = businessChance.B_BusinessChance_Case_nature;
            bcase.B_Case_customerType = businessChance.B_BusinessChance_customerType;
            bcase.B_Case_registerTime = DateTime.Now;
            bcase.B_Case_remark = businessChance.B_BusinessChance_remark;
            bcase.B_Case_state = Convert.ToInt32(BusinessFlowStatus.未开始);
            bcase.B_Case_transferTargetMoney = businessChance.B_BusinessChance_transferTargetMoney;
            bcase.B_Case_transferTargetOther = businessChance.B_BusinessChance_transferTargetOther;
            bcase.B_Case_expectedGrant = businessChance.B_BusinessChance_expectedGrant;
            bcase.B_Case_execMoney = businessChance.B_BusinessChance_execMoney;
            bcase.B_Case_execOther = businessChance.B_BusinessChance_execOther;
            bcase.B_Case_courtFirst = businessChance.B_BusinessChance_courtFirst;
            bcase.B_Case_courtSecond = businessChance.B_BusinessChance_courtSecond;
            bcase.B_Case_courtExec = businessChance.B_BusinessChance_courtExec;
            bcase.B_Case_Trial = null;
            bcase.B_Case_Requirement = businessChance.B_BusinessChance_Requirement;
            bcase.B_Case_Remarks = businessChance.B_BusinessChance_remarks;
            bcase.B_Case_creator = businessChance.B_BusinessChance_creator;
            bcase.B_Case_createTime = DateTime.Now;
            bcase.B_Case_isDelete = 0;
            bcase.B_Case_person = businessChance.B_BusinessChance_person;
            bcase.B_Case_firstClassResponsiblePerson = businessChance.B_BusinessChance_firstClassResponsiblePerson;
            bcase.B_Case_levelType = caseCategory;
            bcase.C_Client_name = businessChance.B_BusinessChance_Client_name;
            bcase.B_Case_Rival_name = businessChance.B_BusinessChance_Person_name;
            bcase.C_Region_code = businessChance.B_BusinessChance_Region_code;
            bcase.B_Case_businessChance_Code = businessChance.B_BusinessChance_code;

            //案件名称
            string[] clientNames = bcase.C_Client_name.Split(',');
            foreach (var clientName in clientNames)
            {
                bcase.B_Case_name += clientName + "+";
            }
            bcase.B_Case_name = bcase.B_Case_name.Substring(0, bcase.B_Case_name.Length - 1);
            CommonService.Model.C_Parameters Case_type = parDal.GetModel(bcase.B_Case_type.Value);
            bcase.B_Case_name += "_" + Case_type.C_Parameters_name + "_";
            string[] rivalNames = bcase.B_Case_Rival_name.Split(',');
            foreach (var rivalName in rivalNames)
            {
                bcase.B_Case_name += rivalName + "+";
            }
            bcase.B_Case_name = bcase.B_Case_name.Substring(0, bcase.B_Case_name.Length - 1);

            //案件编码
            string region = bcase.C_Region_code.Split(',').First();
            string regionAbbreviation = regionDal.GetModelByCode(new Guid(region)).C_Region_abbreviation;
            string caseType = parDal.GetModel(bcase.B_Case_type.Value).C_Parameters_abbreviation;
            bcase.B_Case_number = "BC" + DateTime.Now.ToString("yyyy") + regionAbbreviation + "MS" + caseType;
            #region 案件关联表信息

            List<CommonService.Model.CaseManager.B_Case_link> caseLinks = new List<Model.CaseManager.B_Case_link>();

            #region 客户
            if (!String.IsNullOrEmpty(businessChance.B_BusinessChance_Customer_code))
            {
                string[] customerCodes = businessChance.B_BusinessChance_Customer_code.Split(',');
                foreach (var customerCode in customerCodes)
                {
                    CommonService.Model.CaseManager.B_Case_link caselink = new CommonService.Model.CaseManager.B_Case_link();
                    caselink.B_Case_code = bcase.B_Case_code;
                    caselink.C_FK_code = new Guid(customerCode);
                    caselink.B_Case_link_type = Convert.ToInt32(CaselinkEnum.客户);
                    caselink.B_Case_link_creator = bcase.B_Case_creator;
                    caselink.B_Case_link_createTime = bcase.B_Case_createTime;
                    caselink.B_Case_link_isDelete = 0;

                    caseLinks.Add(caselink);
                }
            }

            #endregion

            #region 委托人
            if (!String.IsNullOrEmpty(businessChance.B_BusinessChance_Client_code))
            {
                string[] clientCodes = businessChance.B_BusinessChance_Client_code.Split(',');
                foreach (var clientCode in clientCodes)
                {
                    CommonService.Model.CaseManager.B_Case_link caselink = new CommonService.Model.CaseManager.B_Case_link();
                    caselink.B_Case_code = bcase.B_Case_code;
                    caselink.C_FK_code = new Guid(clientCode);
                    caselink.B_Case_link_type = Convert.ToInt32(CaselinkEnum.委托人);
                    caselink.B_Case_link_creator = bcase.B_Case_creator;
                    caselink.B_Case_link_createTime = bcase.B_Case_createTime;
                    caselink.B_Case_link_isDelete = 0;

                    caseLinks.Add(caselink);
                }
            }

            #endregion

            #region 对方当事人
            if (!String.IsNullOrEmpty(businessChance.B_BusinessChance_Person_code))
            {
                string[] partyCodes = businessChance.B_BusinessChance_Person_code.Split(',');
                string[] partyType = businessChance.B_BusinessChance_Person_type.Split(',');
                int i = 0;
                foreach (var party_code in partyCodes)
                {
                    CommonService.Model.CaseManager.B_Case_link thisPerson = new CommonService.Model.CaseManager.B_Case_link();
                    thisPerson.B_Case_code = bcase.B_Case_code;
                    thisPerson.C_FK_code = new Guid(party_code);
                    thisPerson.B_Case_link_type = Convert.ToInt32(partyType[i]);
                    thisPerson.B_Case_link_creator = bcase.B_Case_creator;
                    thisPerson.B_Case_link_createTime = bcase.B_Case_createTime;
                    thisPerson.B_Case_link_isDelete = 0;

                    caseLinks.Add(thisPerson);
                    i++;
                }
            }

            #endregion

            #region 工程
            if (!String.IsNullOrEmpty(businessChance.B_BusinessChance_Project_code))
            {
                string[] projectCodes = businessChance.B_BusinessChance_Project_code.Split(',');
                foreach (var project_code in projectCodes)
                {
                    CommonService.Model.CaseManager.B_Case_link project = new CommonService.Model.CaseManager.B_Case_link();
                    project.B_Case_code = bcase.B_Case_code;
                    project.C_FK_code = new Guid(project_code);
                    project.B_Case_link_type = Convert.ToInt32(CaselinkEnum.工程);
                    project.B_Case_link_creator = bcase.B_Case_creator;
                    project.B_Case_link_createTime = bcase.B_Case_createTime;
                    project.B_Case_link_isDelete = 0;

                    caseLinks.Add(project);
                }
            }

            #endregion

            #region 专业顾问
            CommonService.Model.BusinessChanceManager.B_BusinessChance_link bcl = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
            DataSet ds = bclDal.GetLinkByCode((Guid)businessChance.B_BusinessChance_code, Convert.ToInt32(CaselinkEnum.销售顾问));
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                CommonService.Model.CaseManager.B_Case_link project = new CommonService.Model.CaseManager.B_Case_link();
                project.B_Case_code = bcase.B_Case_code;
                project.C_FK_code = new Guid(item["C_FK_code"].ToString());
                project.B_Case_link_type = Convert.ToInt32(CaselinkEnum.销售顾问);
                project.B_Case_link_creator = bcase.B_Case_creator;
                project.B_Case_link_createTime = bcase.B_Case_createTime;
                project.B_Case_link_isDelete = 0;

                caseLinks.Add(project);

            }
            #endregion

            #region 区域
            if (!String.IsNullOrEmpty(businessChance.B_BusinessChance_Region_code))
            {
                string[] regionCodes = businessChance.B_BusinessChance_Region_code.Split(',');
                foreach (var region_code in regionCodes)
                {
                    CommonService.Model.CaseManager.B_Case_link area = new CommonService.Model.CaseManager.B_Case_link();
                    area.B_Case_code = bcase.B_Case_code;
                    area.C_FK_code = new Guid(region_code);
                    area.B_Case_link_type = Convert.ToInt32(CaselinkEnum.所属区域);
                    area.B_Case_link_creator = bcase.B_Case_creator;
                    area.B_Case_link_createTime = bcase.B_Case_createTime;
                    area.B_Case_link_isDelete = 0;

                    caseLinks.Add(area);
                }
            }

            #endregion

            caseLinkBll.OperateList(caseLinks);

            #endregion
            caseBll.Add(bcase);

            #region 给案件的负责人和一级负责人发送新增案件消息
            if (bcase.B_Case_person != null)
            {
                CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.新增案件);
                submitMessage.C_Messages_link = bcase.B_Case_code;
                submitMessage.C_Messages_createTime = bcase.B_Case_createTime;
                submitMessage.C_Messages_person = bcase.B_Case_person;
                submitMessage.C_Messages_isRead = 0;
                submitMessage.C_Messages_content = "";
                submitMessage.C_Messages_isValidate = 1;

                messageDAL.Add(submitMessage);
            }
            if (bcase.B_Case_firstClassResponsiblePerson != null)
            {
                CommonService.Model.C_Messages submitMessage = new Model.C_Messages();
                submitMessage.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                submitMessage.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.新增案件);
                submitMessage.C_Messages_link = bcase.B_Case_code;
                submitMessage.C_Messages_createTime = bcase.B_Case_createTime;
                submitMessage.C_Messages_person = bcase.B_Case_firstClassResponsiblePerson;
                submitMessage.C_Messages_isRead = 0;
                submitMessage.C_Messages_content = "";
                submitMessage.C_Messages_isValidate = 1;

                messageDAL.Add(submitMessage);
            }
            #endregion

            #endregion

            #region 案件附表信息

            #region 客户约定
            //涉案合同权益分配
            List<CommonService.Model.CaseManager.B_EqAllot> eqallots = eqallotBll.GetAllListByCaseCode(businessChanceCode);
            foreach (CommonService.Model.CaseManager.B_EqAllot eqallot in eqallots)
            {
                eqallot.B_EqAllot_code = Guid.NewGuid();
                eqallot.B_Case_code = bcase.B_Case_code;

                eqallotBll.Add(eqallot);
            }
            //费用承担
            List<CommonService.Model.CaseManager.B_BearToPay> bearToPays = bearToPayBll.GetListByCaseCode(businessChanceCode);
            foreach (CommonService.Model.CaseManager.B_BearToPay bearToPay in bearToPays)
            {
                bearToPay.B_BearToPay_code = Guid.NewGuid();
                bearToPay.B_Case_code = bcase.B_Case_code;

                bearToPayBll.Add(bearToPay);
            }
            //担保物协定
            List<CommonService.Model.CaseManager.B_Oppint> oppints = oppintBll.GetListByCaseCode(businessChanceCode);
            foreach (CommonService.Model.CaseManager.B_Oppint oppint in oppints)
            {
                oppint.B_Oppint_code = Guid.NewGuid();
                oppint.B_Case_code = bcase.B_Case_code;

                oppintBll.Add(oppint);
            }

            #endregion

            //收案材料清单
            List<CommonService.Model.C_Files> files = filesBll.GetListByFileLink(businessChanceCode);
            foreach (CommonService.Model.C_Files file in files)
            {
                file.C_Files_code = Guid.NewGuid();
                file.C_Files_link = bcase.B_Case_code;

                filesBll.Add(file);
            }

            //收款明细
            List<CommonService.Model.CaseManager.B_RDetail> rdetails = rdetailBll.GetListByRelationCode(businessChanceCode);
            foreach (CommonService.Model.CaseManager.B_RDetail rdetail in rdetails)
            {
                rdetail.B_RDetail_code = Guid.NewGuid();
                rdetail.B_Case_code = bcase.B_Case_code;

                rdetailBll.Add(rdetail);
            }

            #endregion

            #region 结束当前商机没有结束的业务流程以及表单
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList = bfBLL.GetListByFkCode(businessChanceCode);
            foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in businessFlowList)
            {
                if (businessFlow.P_Business_state != Convert.ToInt32(BusinessFlowStatus.已结束))
                {
                    //结束当前业务流程
                    businessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                    businessFlow.P_Business_flow_factEndTime = DateTime.Now;
                    bfDAL.Update(businessFlow);

                    List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms = bffBLL.OnlyGetBusinessFlowForms(businessFlow.P_Business_flow_code.Value);
                    foreach (CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm in businessFlowForms)
                    {
                        if (businessFlowForm.P_Business_flow_form_state != Convert.ToInt32(BusinessFlowStatus.已结束))
                        {
                            businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.已结束);
                            businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.已通过);

                            #region 更新表单实际结束时间
                            CommonService.Model.CustomerForm.F_FormProperty planEndTimeFormProperty = formPropertyDAL.GetModelByFormAndPropertyFieldName(businessFlowForm.F_Form_code.Value, "factEndTime");
                            if (planEndTimeFormProperty != null)
                            {
                                formPropertyValueBll.Update(businessFlowForm.F_Form_code.Value, businessFlowForm.P_Business_flow_form_code.Value, planEndTimeFormProperty.F_FormProperty_code.Value, businessFlow.P_Business_flow_factEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                            #endregion

                            bffDAL.Update(businessFlowForm);
                        }
                    }
                }
            }
            #endregion

            return true;
        }


        /// <summary>
        /// 分页获取权限数据总记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IsPreSetManager"></param>
        /// <param name="RoleId"></param>
        /// <param name="userCode"></param>
        /// <param name="postCode"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public int GetPowerRecordCount(Model.BusinessChanceManager.B_BusinessChance model, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
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
            recordCount = dal.GetPowerRecordCount(model, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode);
            return recordCount;
        }
        /// <summary>
        /// 分页获取权限数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="IsPreSetManager"></param>
        /// <param name="RoleId"></param>
        /// <param name="userCode"></param>
        /// <param name="postCode"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public List<Model.BusinessChanceManager.B_BusinessChance> GetPowerListByPage(Model.BusinessChanceManager.B_BusinessChance model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
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
            List<CommonService.Model.BusinessChanceManager.B_BusinessChance> businessChance = DataTableToList(dal.GetPowerListByPage(model, orderby, startIndex, endIndex, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode).Tables[0]);
            return businessChance;
        }
        /// <summary>
        /// 根据客户的code获得此客户相关的商机的列表
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public List<Model.BusinessChanceManager.B_BusinessChance> GetBusinessChanceListByCustomer(Guid customerCode)
        {
            return DataTableToList(dal.GetBusinessChanceListByCustomer(customerCode).Tables[0]);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

