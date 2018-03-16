using CommonService.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL
{
    /// <summary>
    /// 客户表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/04/28
    /// </summary>
    public partial class C_Customer
    {
        private readonly CommonService.DAL.C_Customer dal = new CommonService.DAL.C_Customer();
        private readonly CommonService.BLL.C_Customer_Region cusRegBll = new BLL.C_Customer_Region();
        private readonly CommonService.DAL.C_Region regDal = new DAL.C_Region();
        private readonly CommonService.BLL.SysManager.C_Userinfo_region userregDal = new BLL.SysManager.C_Userinfo_region();

        private readonly CommonService.BLL.SysManager.C_Userinfo userDal = new BLL.SysManager.C_Userinfo();
        private readonly CommonService.DAL.CaseManager.B_Case_link clDal = new DAL.CaseManager.B_Case_link();
        private readonly CommonService.DAL.CaseManager.B_Case caseDal = new DAL.CaseManager.B_Case();
        private readonly CommonService.BLL.CaseManager.B_Case caseBll = new BLL.CaseManager.B_Case();
        /// <summary>
        /// 用户数据访问层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_Userinfo userinfoDAL = new CommonService.DAL.SysManager.C_Userinfo();
        /// <summary>
        /// 组织机构数据访问层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_Organization orgDAL = new CommonService.DAL.SysManager.C_Organization();
        /// <summary>
        /// 消息数据访问层
        /// </summary>
        private readonly CommonService.DAL.C_Messages messageDAL = new CommonService.DAL.C_Messages();

        /// <summary>
        /// 业务流程数据访问层
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow bfDAL = new CommonService.DAL.FlowManager.P_Business_flow();
        /// <summary>
        /// 业务流程—表单中间表数据访问层
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow_form bffDAL = new CommonService.DAL.FlowManager.P_Business_flow_form();
        /// <summary>
        /// 表单属性数据访问类
        /// </summary>
        private readonly CommonService.DAL.CustomerForm.F_FormProperty formPropertyDAL = new CommonService.DAL.CustomerForm.F_FormProperty();

        private readonly CommonService.BLL.SysManager.C_Role_Role_Power rolepowerbll = new SysManager.C_Role_Role_Power();
        private readonly CommonService.BLL.SysManager.C_Organization organizationbll = new SysManager.C_Organization();
        /// <summary>
        /// 业务流程业务逻辑
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow bfBLL = new CommonService.BLL.FlowManager.P_Business_flow();
        /// <summary>
        /// 业务流程—表单中间表逻辑
        /// </summary>
        private readonly CommonService.BLL.FlowManager.P_Business_flow_form bffBLL = new CommonService.BLL.FlowManager.P_Business_flow_form();
        /// <summary>
        /// 表单属性值业务访问层
        /// </summary>
        private readonly CommonService.BLL.CustomerForm.F_FormPropertyValue formPropertyValueBll = new CommonService.BLL.CustomerForm.F_FormPropertyValue();
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
        /// <summary>
        /// 用户业务访问层
        /// </summary>
        private readonly CommonService.BLL.SysManager.C_Userinfo userinfoBLL = new CommonService.BLL.SysManager.C_Userinfo();
        /// <summary>
        /// 部长首席关联表逻辑层
        /// </summary>
        private readonly CommonService.DAL.SysManager.C_ChiefExpert_Minister MinisterDAL = new DAL.SysManager.C_ChiefExpert_Minister();
        private readonly CommonService.BLL.BusinessChanceManager.B_BusinessChance businessChanceBll = new BusinessChanceManager.B_BusinessChance();
        public C_Customer()
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
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(CommonService.Model.C_Customer model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByCustomerName(string C_Customer_name, int C_Customer_businessType)
        {
            return dal.ExistsByCustomerName(C_Customer_name, C_Customer_businessType);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByCustomerNameAndCode(string C_Customer_name, Guid C_Customer_code, int C_Customer_businessType)
        {
            return dal.ExistsByCustomerNameAndCode(C_Customer_name, C_Customer_code, C_Customer_businessType);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.C_Customer model)
        {
            #region 根据专业顾问修改部长和首席
            if (model.C_Customer_consultant != null)
            {
                CommonService.BLL.SysManager.C_Userinfo userinfoBll = new SysManager.C_Userinfo();
                Model.SysManager.C_Userinfo buzhang = userinfoBll.GetBuZhangByUserCode(model.C_Customer_consultant.Value); //直接找部长
                //案件的负责人默认为客户的专业顾问的部长
                if (buzhang != null)
                {
                    model.C_Customer_responsiblePerson = buzhang.C_Userinfo_code; //部长赋值

                    BLL.SysManager.C_ChiefExpert_Minister ccmBLL = new SysManager.C_ChiefExpert_Minister(); //部长首席关联
                    Model.SysManager.C_ChiefExpert_Minister ccm = ccmBLL.GetModelByMinister(buzhang.C_Userinfo_code.Value); //根据部长GUID获取首席
                    if (ccm != null)
                    {
                        model.C_Customer_chiefResponsiblePerson = ccm.C_ChiefExpert_Code; //首席赋值
                    }
                }
            }
            #endregion


            #region 如果此客户有默认部长，则给部长发送消息
            if (model.C_Customer_responsiblePerson != null && model.C_Customer_responsiblePerson.Value != Guid.Empty)
            {
                CommonService.Model.C_Messages message = new Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.新增案件);//用新增案件的消息类型，代表新增客户
                message.C_Messages_link = model.C_Customer_code;
                message.C_Messages_createTime = DateTime.Now;
                message.C_Messages_person = model.C_Customer_responsiblePerson;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
            }
            #endregion

            return dal.Add(model);
        }
        /// <summary>
        /// 根据客户guid，来查看客户的部长和首席专家是否为空，如果为空则为部长和首席专家添加数据   ---cyj
        /// </summary>
        /// <param name="customerCode">客户code</param>
        /// <param name="userOrgCode">销售顾问所在组织架构code</param>
        /// <returns></returns>
        public void SetMinisterAndChiefResponsible(string customerCode,Guid? userOrgCode)
        {
            CommonService.Model.C_Customer cModel = new Model.C_Customer();
            cModel = dal.GetModel(new Guid(customerCode));
            Guid userorgcode = (Guid)userOrgCode;
            if (cModel.C_Customer_consultant != null)
            {
                if (cModel.C_Customer_responsiblePerson == null)
                {
                    CommonService.Model.SysManager.C_Userinfo consultantUser = userinfoDAL.GetModelByCode(cModel.C_Customer_consultant.Value);//销售顾问数据模型
                    //获取销售顾问所在组织机构所有用户
                    List<CommonService.Model.SysManager.C_Userinfo> userinfoList = userinfoBLL.GetUserinfosByOrganizationID(userorgcode);
                    Guid userinfoCode = Guid.Empty;
                    foreach (CommonService.Model.SysManager.C_Userinfo user_info in userinfoList)
                    {
                        bool flag = userinfoDAL.ExistsRolePowerByUserinfoCode(user_info.C_Userinfo_code.Value);
                        if (flag)
                        {
                            userinfoCode = user_info.C_Userinfo_code.Value;
                            break;
                        }
                    }
                    if (userinfoCode == Guid.Empty)
                    {
                        //CommonService.Model.SysManager.C_Organization organization = orgDAL.GetModel(userorgcode);
                        List<CommonService.Model.SysManager.C_Userinfo> userinfos = userinfoBLL.GetUserinfosByOrganizationID(userorgcode);
                        foreach (CommonService.Model.SysManager.C_Userinfo item in userinfos)
                        {
                            bool flag = userinfoDAL.ExistsRolePowerByUserinfoCode(item.C_Userinfo_code.Value);
                            if (flag)
                            {
                                userinfoCode = item.C_Userinfo_code.Value;
                                break;
                            }
                        }
                    }
                    //客户负责人默认为客户专业顾问的部长
                    cModel.C_Customer_responsiblePerson = userinfoCode;
                }
                if (cModel.C_Customer_chiefResponsiblePerson == null)
                {
                    //根据部长去找首席
                    CommonService.Model.SysManager.C_ChiefExpert_Minister Mmodel = new Model.SysManager.C_ChiefExpert_Minister();
                    Mmodel = MinisterDAL.GetModelByMinister(cModel.C_Customer_responsiblePerson.Value);
                    if (Mmodel != null)
                        cModel.C_Customer_chiefResponsiblePerson = Mmodel.C_ChiefExpert_Code;
                }
                dal.Update(cModel);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.C_Customer model)
        {
            CommonService.Model.C_Customer cmodel = dal.GetModel(model.C_Customer_code.Value);
            if (cmodel.C_Customer_consultant != model.C_Customer_consultant)
            {
                #region 根据专业顾问修改客户的部长和首席
                if (model.C_Customer_consultant != null)
                {
                    CommonService.BLL.SysManager.C_Userinfo userinfoBll = new SysManager.C_Userinfo();
                    Model.SysManager.C_Userinfo buzhang = userinfoBll.GetBuZhangByUserCode(model.C_Customer_consultant.Value); //直接找部长
                    //案件的负责人默认为客户的专业顾问的部长
                    if (buzhang != null)
                    {
                        model.C_Customer_responsiblePerson = buzhang.C_Userinfo_code; //部长赋值

                        BLL.SysManager.C_ChiefExpert_Minister ccmBLL = new SysManager.C_ChiefExpert_Minister(); //部长首席关联
                        Model.SysManager.C_ChiefExpert_Minister ccm = ccmBLL.GetModelByMinister(buzhang.C_Userinfo_code.Value); //根据部长GUID获取首席
                        if (ccm != null)
                        {
                            model.C_Customer_chiefResponsiblePerson = ccm.C_ChiefExpert_Code; //首席赋值
                        }
                    }
                }
                #endregion

                #region 根据新的专业顾问 修改此客户相关的案件的部长以及首席
                List<CommonService.Model.CaseManager.B_Case> listCase = caseBll.GetCaseListByCustomer(model.C_Customer_code.Value);
                foreach (var item in listCase)
                {
                    item.B_Case_person = model.C_Customer_responsiblePerson;
                    item.B_Case_firstClassResponsiblePerson = model.C_Customer_chiefResponsiblePerson;
                    caseDal.Update(item);
                }
                #endregion

                #region 根据新的专业顾问 修改此客户相关的商机的部长以及首席
                List<CommonService.Model.BusinessChanceManager.B_BusinessChance> listBusinessChance = businessChanceBll.GetBusinessChanceListByCustomer(model.C_Customer_code.Value);
                foreach (var item in listBusinessChance)
                {
                    item.B_BusinessChance_person = model.C_Customer_responsiblePerson;
                    item.B_BusinessChance_firstClassResponsiblePerson = model.C_Customer_chiefResponsiblePerson;
                    businessChanceBll.Update(item);
                }
                #endregion

            }
            dal.Update(model);
            if (model.C_Customer_consultant != null)
            {
                Guid consultant = model.C_Customer_consultant.Value;//销售顾问Guid
                //根据销售顾问Guid获取关联案件
                List<CommonService.Model.CaseManager.B_Case_link> bcaseLinks = clDal.GetConsultantListByFKcode(new Guid(model.C_Customer_code.ToString()));
                foreach (CommonService.Model.CaseManager.B_Case_link bcaselink in bcaseLinks)
                {
                    List<CommonService.Model.CaseManager.B_Case_link> bcaselinkList = clDal.GetConsultantListByCasecode(bcaselink.B_Case_code.Value);
                    foreach (CommonService.Model.CaseManager.B_Case_link case_link in bcaselinkList)
                    {
                        case_link.C_FK_code = consultant;
                        clDal.Update(case_link);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 设置客户计划
        /// </summary>
        /// <param name="model">客户数据模型</param>
        /// <returns></returns>        
        public bool SetCustomerPlan(CommonService.Model.C_Customer model)
        {
            CommonService.Model.C_Customer dbCustomer = this.GetModel(model.C_Customer_code.Value);

            #region 在“首席专家”或者"部长"改变的时候，变更"表单审核"中的审核人(若表单最后审核人为"首席专家"或者"部长"的时候，才需要变更)
            //目前不考虑“首席专家”或者"部长"是同一人，
            List<CommonService.Model.CustomerForm.F_FormCheck> unFormChecks = formCheckBLL.GetUnCheckRecordByFkCode(model.C_Customer_code.Value);
            foreach (CommonService.Model.CustomerForm.F_FormCheck formCheck in unFormChecks)
            {
                if (model.C_Customer_responsiblePerson != dbCustomer.C_Customer_responsiblePerson)
                {//变更部长
                    if (formCheck.F_FormCheck_checkPerson == dbCustomer.C_Customer_responsiblePerson)
                    {
                        formCheck.F_FormCheck_checkPerson = model.C_Customer_responsiblePerson;
                        formCheckBLL.Update(formCheck);
                    }
                }
                if (dbCustomer.C_Customer_chiefResponsiblePerson != model.C_Customer_chiefResponsiblePerson)
                {//变更首席专家
                    if (formCheck.F_FormCheck_checkPerson == dbCustomer.C_Customer_chiefResponsiblePerson)
                    {
                        formCheck.F_FormCheck_checkPerson = model.C_Customer_chiefResponsiblePerson;
                        formCheckBLL.Update(formCheck);
                    }
                }
            }
            #endregion

            #region 当客户分配负责人时，给该负责人发送消息
            if (model.C_Customer_responsiblePerson != dbCustomer.C_Customer_responsiblePerson)
            {
                CommonService.Model.C_Messages message = new Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.新增案件);//用新增案件的消息类型，代表新增客户
                message.C_Messages_link = model.C_Customer_code.Value;
                message.C_Messages_createTime = DateTime.Now;
                message.C_Messages_person = model.C_Customer_responsiblePerson;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                messageDAL.Add(message);
            }
            #endregion

            return dal.SetCustomerPlan(model);
        }

        /// <summary>
        /// 启动客户任务
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <param name="startPersonCode">启动人Guid</param>
        /// <returns></returns>       
        public bool StartTask(Guid customerCode, Guid startPersonCode)
        {
            bool isSuccess = false;

            /**
             * author:hety
             * date:2015-11-26 
             * description:启动客户任务
             ****/

            DateTime now = DateTime.Now;
            CommonService.Model.C_Customer customer = this.GetModel(customerCode);
            if (customer.C_Customer_goingStatus != Convert.ToInt32(BusinessFlowStatus.未开始))
            {
                return isSuccess;
            }
            customer.C_Customer_factStartTime = now;
            customer.C_Customer_goingStatus = Convert.ToInt32(BusinessFlowStatus.正在进行);
            isSuccess = dal.Update(customer);

            List<CommonService.Model.FlowManager.P_Business_flow> business_flow = bfBLL.GetListByFkCode(customerCode);
            SetSingleTopBusinessFlow(business_flow, now, startPersonCode);

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
                bf.P_Business_startPerson = startPersonCode;
                bf.P_Business_startTime = now;
                bf.P_Business_flow_factStartTime = now;
                bf.P_Business_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                bf.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.已通过);
                bfDAL.Update(bf);

                #region 业务流程启动时，给业务流程负责人发送消息
                if (bf.P_Business_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
                    }

                    #region 启动表单时，给表单的主办律师发送消息
                    if (bff.P_Business_flow_form_person != null)
                    {
                        if (!businessFlowFormRepins.Contains(bff.P_Business_flow_form_person.ToString()))
                        {//处理启用不同表单时，如果表单主办律师出现重复的情况，只需要发一条消息
                            businessFlowFormRepins.Add(bff.P_Business_flow_form_person.ToString());

                            CommonService.Model.C_Messages message = new Model.C_Messages();
                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
        /// 递归加载所有业务流程
        /// </summary>
        /// <param name="parentCode">上级流程Code</param>
        /// <param name="businessFlowList">业务流程集合</param>
        /// <param name="now">当前时间</param>
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
                bf.P_Business_startPerson = startPersonCode;
                bf.P_Business_startTime = now;
                bf.P_Business_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
                bf.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.已通过);
                bfDAL.Update(bf);

                #region 业务流程启动时，给业务流程负责人发送消息
                if (bf.P_Business_person != null)
                {
                    CommonService.Model.C_Messages message = new Model.C_Messages();
                    message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
                    }
                    #region 启动表单时，给表单的主办律师发送消息
                    if (bff.P_Business_flow_form_person != null)
                    {
                        if (!businessFlowFormRepins.Contains(bff.P_Business_flow_form_person.ToString()))
                        {//处理启用不同表单时，如果表单主办律师出现重复的情况，只需要发一条消息
                            businessFlowFormRepins.Add(bff.P_Business_flow_form_person.ToString());

                            CommonService.Model.C_Messages message = new Model.C_Messages();
                            message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
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
        public bool Delete(Guid C_Customer_code)
        {
            bool isSuccess = false;
            isSuccess = dal.Delete(C_Customer_code);
            if (isSuccess)
            {//删除客户区域关联关系
                cusRegBll.DeleteByCustomerCode(C_Customer_code);
            }
            return isSuccess;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_Customer_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(C_Customer_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.C_Customer GetModel(Guid C_Customer_code)
        {
            CommonService.Model.C_Customer customer = dal.GetModel(C_Customer_code);
            if (customer == null) return null;
            string regionCodeStr = "";
            string regionNameStr = "";
            List<CommonService.Model.C_Customer_Region> customerRegions = cusRegBll.GetListByCustomerCode(customer.C_Customer_code.Value);
            foreach (CommonService.Model.C_Customer_Region customerRegion in customerRegions)
            {
                regionCodeStr += customerRegion.C_Customer_Region_relRegion + ",";
                CommonService.Model.C_Region region = regDal.GetModelByCode(new Guid(customerRegion.C_Customer_Region_relRegion.Value.ToString()));
                if (region != null)
                {
                    regionNameStr += region.C_Region_name + ",";
                }
            }
            customer.C_Customer_Region_code = regionCodeStr == "" ? regionCodeStr : regionCodeStr.Substring(0, regionCodeStr.Length - 1);
            customer.C_Customer_Region_name = regionNameStr == "" ? regionNameStr : regionNameStr.Substring(0, regionNameStr.Length - 1);

            return customer;
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.C_Customer GetModelByCache(int C_Customer_id)
        {

            string CacheKey = "C_CustomerModel-" + C_Customer_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(C_Customer_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.C_Customer)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Customer> GetAllList()
        {
            DataSet ds = dal.GetAllList();
            return DataTableToList(ds.Tables[0]);
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
        public List<CommonService.Model.C_Customer> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.C_Customer> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.C_Customer> modelList = new List<CommonService.Model.C_Customer>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.C_Customer model;
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

        private void SetDep(Guid guid, List<Guid> DepIds)
        {
            var OrganizationList = organizationbll.GetModelByParent(guid);
            if (OrganizationList.Count > 0)
            {
                foreach (var item in OrganizationList)
                {
                    DepIds.Add(item.C_Organization_code.Value);
                    SetDep(item.C_Organization_code.Value, DepIds);
                }
            }
        }
        public int GetListByPageCount(string strWhere)
        {
            return dal.GetListByPageCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_Customer> GetListByPageAll(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(strWhere, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        /// 获取客户总数
        /// </summary>
        public int GetCustomerListCount(Model.C_Customer model, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
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

            return dal.GetCustomerListCount(model, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode);
        }
        /// <summary>
        /// 分页获取客户列表
        /// </summary>
        public List<Model.C_Customer> GetCustomerListByPage(Model.C_Customer model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, Guid? postCode, Guid? deptCode)
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

            List<Model.C_Customer> customer = DataTableToList(dal.GetCustomerListByPage(model, orderby, startIndex, endIndex, IsPreSetManager, rolePowerIds, userCode, postCode, deptCode).Tables[0]);
            return customer;
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
        /// 删除客户
        /// </summary>
        /// <param name="guid">客户GUID</param>
        /// <returns>0 不成功 1 成功 2 该客户的添加日期不是当天 </returns>
        public int DeleteCustomer(Guid? guid)
        {
            int result = 0;
            Model.C_Customer customer = GetModel(guid.Value); //获取到删除的客户
            if (customer != null)
            {
                if (customer.C_Customer_createTime.Value != null && customer.C_Customer_createTime.Value.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd")) //如果客户的添加日期不是当天
                {
                    result = 2;
                }
                else
                {
                    bool flag = Delete(guid.Value);
                    if (flag)
                    {
                        result = 1;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.C_Customer> AppGetListByPage(Model.C_Customer model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, int? RoleId, Guid? userCode, Guid? postCode, Guid? deptCode, int type)
        {
            StringBuilder but = new StringBuilder();
            StringBuilder but2 = new StringBuilder();
            if (model.C_Customer_responsibleDept != null)
            {
                //查找当前部门下所有的子级部门
                List<Guid> DepIds = new List<Guid>();
                DepIds.Add(new Guid(model.C_Customer_responsibleDept.ToString()));
                var OrganizationList = organizationbll.GetModelByParent(new Guid(model.C_Customer_responsibleDept.ToString()));
                foreach (var item in OrganizationList)
                {
                    DepIds.Add(item.C_Organization_code.Value);
                    SetDep(item.C_Organization_code.Value, DepIds);

                }
                //找到所有此部门下的所有用户
                foreach (var item in DepIds)
                {
                    var UserinfoList = userDal.GetUserinfosByOrganizationID(item);
                    foreach (var item2 in UserinfoList)
                    {
                        but2.Append(item2.C_Userinfo_code + ",");
                    }
                }
            }
            string FRegion = "";
            if (!IsPreSetManager)
            {
                //根据组织架构code获取当前选择组织架构下的所有用户


                //--专业顾问和部长权限(若为专业顾问则直接根据当前用户取数据，若为部长则先取到该部门下所有的人再取数据)
                //判断是否走组织架构权限还是不走
                if (RoleId == 12 || RoleId == 11 || RoleId == 1018 || RoleId == 1019 || RoleId == 1020)
                {
                    var reglist = userregDal.GetModelList(" C_Userinfo_code='" + userCode + "'");
                    foreach (var item in reglist)
                    {
                        FRegion = FRegion + item.C_Region_code + ",";
                    }

                }
                else
                {

                    int rolepowerNumber = rolepowerbll.GetModelList("C_Roles_id=" + RoleId + " and C_Role_Power_id=5").Count;
                    if (rolepowerNumber > 0)
                    {
                        //查找当前部门下所有的子级部门
                        List<Guid> DepIds = new List<Guid>();
                        DepIds.Add(deptCode.Value);
                        var OrganizationList = organizationbll.GetModelByParent(deptCode.Value);
                        foreach (var item in OrganizationList)
                        {
                            DepIds.Add(item.C_Organization_code.Value);
                        }

                        //找到所有此部门下的所有用户
                        foreach (var item in DepIds)
                        {
                            var UserinfoList = userDal.GetUserinfosByOrganizationID(item);
                            foreach (var item2 in UserinfoList)
                            {
                                but.Append(item2.C_Userinfo_code + ",");
                            }
                        }
                    }
                    else
                    {
                        but.Append("," + userCode + ",");
                    }
                }
            }

            return DataTableToList(dal.AppGetListByPage(model, orderby, startIndex, endIndex, but.ToString(), but2.ToString(), FRegion, userCode, type).Tables[0]);
        }


        #endregion
    }
}
