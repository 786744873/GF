using CommonService.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.OA
{
    /// <summary>
    /// 表单表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    public partial class O_Form
    {
        private readonly CommonService.DAL.OA.O_Form dal = new DAL.OA.O_Form();
        private readonly CommonService.BLL.OA.O_FlowSet flowsetBLL = new BLL.OA.O_FlowSet();
        private readonly CommonService.BLL.OA.O_Form_AuditFlow FAflowBLL = new O_Form_AuditFlow();
        private readonly CommonService.BLL.OA.O_FlowSet_AuditPerson flowsetPerBLL = new O_FlowSet_AuditPerson();
        private readonly CommonService.BLL.OA.O_Form_AuditPerson FAPbll = new O_Form_AuditPerson();
        /// <summary>
        /// 表单属性值业务方法层
        /// </summary>
        private readonly CommonService.BLL.CustomerForm.F_FormPropertyValue formPropertyValueBLL = new CommonService.BLL.CustomerForm.F_FormPropertyValue();
        /// <summary>
        /// 业务流程数据访问类
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow businessFlowDAL = new CommonService.DAL.FlowManager.P_Business_flow();
        /// <summary>
        /// 业务流程表单关联数据访问类
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Business_flow_form businessFlowFormDAL = new CommonService.DAL.FlowManager.P_Business_flow_form();
        /// <summary>
        /// 案件数据访问类
        /// </summary>
        private readonly CommonService.DAL.CaseManager.B_Case caseDAL = new CommonService.DAL.CaseManager.B_Case();
        /// <summary>
        /// 商机数据访问层
        /// </summary>
        private readonly CommonService.DAL.BusinessChanceManager.B_BusinessChance businessChanceDAL = new DAL.BusinessChanceManager.B_BusinessChance();
        /// <summary>
        /// 流程数据访问类
        /// </summary>
        private readonly CommonService.DAL.FlowManager.P_Flow flowDAL = new CommonService.DAL.FlowManager.P_Flow();

        public O_Form()
        { }
        #region  BasicMethod

        /// <summary>
        /// 根据表单Guid，获取表单自定义类型(如普通编辑表单，单头明细行表单，明细行表单)(返回1代表普通编辑表单;2代表主子表单;3代表)
        /// </summary>
        /// <param name="formCode">表单Guid(ERP系统表单GUID)</param>
        /// <returns>返回1代表普通编辑表单;2代表主子表单;3代表明细子表</returns>
        public int GetFormCustomerType(Guid formCode)
        {
            return dal.GetFormCustomerType(formCode);
        }

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
        public bool Exists(int O_Form_id)
        {
            return dal.Exists(O_Form_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_Form model)
        {
            /*
             *author:hety
             *date:2015-08-07
             *description:创建表单的时候，初始化表单结构
             ***/
            int customerType = dal.GetFormCustomerType(model.O_Form_f_form.Value);
            //先删除关联表单属性值数据
            formPropertyValueBLL.Delete(model.O_Form_f_form.Value, model.O_Form_code.Value);
            if (customerType == 1)
            {//普通编辑表单，需要初始化属性值
                formPropertyValueBLL.InitializationOAFormPropertyValue(model.O_Form_f_form.Value, model.O_Form_code.Value, model.O_Form_creator.Value);
            }
            else if (customerType == 3)
            {//普通子表表单，仅仅不初始化子属性，其余表单属性均初始化
                formPropertyValueBLL.InitializationOAItemsFormPropertyValue(model.O_Form_f_form.Value, model.O_Form_code.Value, model.O_Form_creator.Value);
            }
            else if (customerType == 2)
            {//主子表表单，仅仅不初始化子属性，其余表单属性均初始化
                //先初始化 父亲属性为'00000000-0000-0000-0000-000000000000'的属性值
                formPropertyValueBLL.InitializationOAItemsFormPropertyValue(model.O_Form_f_form.Value, model.O_Form_code.Value, model.O_Form_creator.Value);
                //再初始化 主表编辑属性值以及子表属性值
                formPropertyValueBLL.InitializationOAHeadItemsPropertyValue(model.O_Form_f_form.Value, model.O_Form_code.Value, model.O_Form_creator.Value);
            }

            return dal.Add(model);
        }

        /// <summary>
        /// 提交财务表单(专指费用报销单和费用借款单)
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="submitUserCode">提交用户Guid</param>
        /// <returns></returns>
        public bool SubmitFinanceForm(Guid fFormCode, Guid oFormCode, Guid businessFlowFormCode, Guid submitUserCode)
        {
            bool isSuccess = false;
            DateTime now = DateTime.Now;
            /**
             * author:hety
             * date:2015-08-29
             * description:提交财务表单(专指费用报销单和费用借款单)
             * (1)、
             **/
            CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = businessFlowFormDAL.GetModel(businessFlowFormCode);
            CommonService.Model.FlowManager.P_Business_flow businessFlow = businessFlowDAL.GetModel(businessFlowForm.P_Business_flow_code.Value);
            CommonService.Model.FlowManager.P_Flow flow = flowDAL.GetModel(businessFlow.P_Flow_code.Value);
            CommonService.Model.OA.O_Form oForm = dal.GetModel(oFormCode);

            if (oForm.O_Form_applyStatus != Convert.ToInt32(FormApplyTypeEnum.未提交) && oForm.O_Form_applyStatus != Convert.ToInt32(FormApplyTypeEnum.未通过))
            {
                return isSuccess;
            }
            oForm.O_Form_applyPerson = submitUserCode;
            oForm.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.已提交);
            oForm.O_Form_applyTime = now;

            if (businessFlowForm.P_Business_flow_form_isDefault == 1)
            {
                #region 默认表单业务逻辑处理
                this.RecursionSetFinanceFormAuditInfo(businessFlow, submitUserCode, oFormCode, flow.P_Flow_type.Value.ToString(), now, Guid.Empty);
                isSuccess = this.DealFormAuditData(oFormCode, submitUserCode, now);
                if (isSuccess)
                {
                    //协同办公表单
                    oForm.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.已通过);
                }
                dal.Update(oForm);
                isSuccess = true;
                #endregion
            }
            else
            {
                #region 非默认表单业务逻辑处理

                if (businessFlow.P_Business_flow_auditType == Convert.ToInt32(BusinessFlowAuditType.仅监控当前预设流程))
                {
                    #region 协同办公表单审批流程初始化
                    CommonService.Model.OA.O_Form_AuditFlow oFromAuditFlow = new Model.OA.O_Form_AuditFlow();
                    oFromAuditFlow.O_Form_AuditFlow_code = Guid.NewGuid();
                    oFromAuditFlow.O_Form_AuditFlow_o_form = oFormCode;
                    oFromAuditFlow.O_Form_AuditFlow_flowSet_order = 1;
                    oFromAuditFlow.O_Form_AuditFlow_flowSet_auditType = Convert.ToInt32(AuditTypeEnum.并且);
                    oFromAuditFlow.O_Form_AuditFlow_isDelete = false;
                    oFromAuditFlow.O_Form_AuditFlow_creator = submitUserCode;
                    oFromAuditFlow.O_Form_AuditFlow_createTime = now;
                    #endregion

                    #region 协同办公表单审批人初始化
                    CommonService.Model.OA.O_Form_AuditPerson oFormAuditPerson = new Model.OA.O_Form_AuditPerson();
                    oFormAuditPerson.O_Form_AuditPerson_code = Guid.NewGuid();
                    oFormAuditPerson.O_Form_AuditPerson_formAuditFlow = oFromAuditFlow.O_Form_AuditFlow_code;
                    oFormAuditPerson.O_Form_AuditPerson_isDelete = false;
                    oFormAuditPerson.O_Form_AuditPerson_creator = submitUserCode;
                    oFormAuditPerson.O_Form_AuditPerson_createTime = now;
                    #endregion

                    #region 仅监控当前预设流程业务处理
                    //如果提交用户Guid与业务流程负责人是同一个人，则直接审批通过；否则一级一级向上提交审批
                    if (businessFlow.P_Business_person.Value == submitUserCode)
                    {
                        //审批流程
                        oFromAuditFlow.O_Form_AuditFlow_auditStatus = Convert.ToInt32(FormAuditTypeEnum.已通过);
                        oFromAuditFlow.O_Form_AuditFlow_auditTime = now;
                        //审批人
                        oFormAuditPerson.O_Form_AuditPerson_auditPerson = businessFlow.P_Business_person;
                        oFormAuditPerson.O_Form_AuditPerson_auditTime = now;
                        oFormAuditPerson.O_Form_AuditPerson_status = Convert.ToInt32(FormApprovalTypeEnum.已通过);
                        oFormAuditPerson.O_Form_AuditPerson_content = "提交并且审批通过";
                        //协同办公表单
                        oForm.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.已通过);
                        
                    }
                    else
                    {
                        //审批流程
                        oFromAuditFlow.O_Form_AuditFlow_auditStatus = Convert.ToInt32(FormAuditTypeEnum.未开始);
                        //审批人
                        oFormAuditPerson.O_Form_AuditPerson_auditPerson = businessFlow.P_Business_person;
                        oFormAuditPerson.O_Form_AuditPerson_status = Convert.ToInt32(FormApprovalTypeEnum.未审核);
                    }
                    FAflowBLL.Add(oFromAuditFlow);
                    FAPbll.Add(oFormAuditPerson);
                    dal.Update(oForm);
                    isSuccess = true;
                    #endregion
                }
                else
                {
                    #region 完全监控业务流程处理
                    this.RecursionSetFinanceFormAuditInfo(businessFlow, submitUserCode, oFormCode, flow.P_Flow_type.Value.ToString(), now, Guid.Empty);
                    isSuccess = this.DealFormAuditData(oFormCode, submitUserCode, now);
                    if (isSuccess)
                    {
                        //协同办公表单
                        oForm.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.已通过);
                    }
                    dal.Update(oForm);
                    isSuccess = true;
                    #endregion
                }

                #endregion
            }

            return isSuccess;
        }

        /// <summary>
        /// 预设财务表单审批流程(专指财务借款单和财务报销单)
        /// </summary>
        /// <param name="businessFlow">业务流程实体</param>
        /// <param name="submitUserCode">提交用户Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="fkType">153、案件 154、商机</param>
        /// <param name="now">当前时间</param>
        /// <param name="beforeAuditPerson">上一个审批用户Guid(用来处理是否插入不间断审批流程中，审批人是同一个人的情况(这种情况只需插入一次))</param>
        public void RecursionSetFinanceFormAuditInfo(CommonService.Model.FlowManager.P_Business_flow businessFlow,
            Guid submitUserCode, Guid oFormCode, string fkType, DateTime now, Guid beforeAuditPerson)
        {
            if (beforeAuditPerson != businessFlow.P_Business_person.Value)
            {
                this.InitializationFormAuditData(oFormCode, submitUserCode, businessFlow.P_Business_person.Value, now);
            }

            if (businessFlow.P_Flow_parent != null)
            {//设置审批人为业务流程上的负责人
                CommonService.Model.FlowManager.P_Business_flow businessFlowParent = businessFlowDAL.GetModel(businessFlow.P_Flow_parent.Value);
                if (businessFlowParent != null)
                {
                    RecursionSetFinanceFormAuditInfo(businessFlowParent, submitUserCode, oFormCode, fkType, now, businessFlow.P_Business_person.Value);
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
                        if (beforeAuditPerson != bcase.B_Case_person.Value)
                        {
                            this.InitializationFormAuditData(oFormCode, submitUserCode, bcase.B_Case_person.Value, now);
                            beforeAuditPerson = bcase.B_Case_person.Value;
                        }

                        if (bcase.B_Case_levelType == 2)
                        {//策划级案件
                            if (beforeAuditPerson != bcase.B_Case_firstClassResponsiblePerson.Value)
                            {
                                this.InitializationFormAuditData(oFormCode, submitUserCode, bcase.B_Case_firstClassResponsiblePerson.Value, now);
                            }
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
                        if (beforeAuditPerson != businessChance.B_BusinessChance_person.Value)
                        {
                            this.InitializationFormAuditData(oFormCode, submitUserCode, businessChance.B_BusinessChance_person.Value, now);
                        }

                    }
                    #endregion
                }
                #endregion
            }
        }

        /// <summary>
        /// 初始化表单审批数据
        /// </summary>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="submitUserCode">提交用户Guid</param>
        /// <param name="auditPersonCode">审批人Guid</param>
        /// <param name="now">当前时间</param>
        private void InitializationFormAuditData(Guid oFormCode, Guid submitUserCode, Guid auditPersonCode, DateTime now)
        {
            #region 协同办公表单审批流程初始化
            CommonService.Model.OA.O_Form_AuditFlow oFromAuditFlow = new Model.OA.O_Form_AuditFlow();
            oFromAuditFlow.O_Form_AuditFlow_code = Guid.NewGuid();
            oFromAuditFlow.O_Form_AuditFlow_o_form = oFormCode;
            oFromAuditFlow.O_Form_AuditFlow_flowSet_order = FAflowBLL.GetMaxOrder(oFormCode) + 1;
            oFromAuditFlow.O_Form_AuditFlow_flowSet_auditType = Convert.ToInt32(AuditTypeEnum.并且);
            oFromAuditFlow.O_Form_AuditFlow_auditStatus = Convert.ToInt32(FormAuditTypeEnum.未开始);
            oFromAuditFlow.O_Form_AuditFlow_isDelete = false;
            oFromAuditFlow.O_Form_AuditFlow_creator = submitUserCode;
            oFromAuditFlow.O_Form_AuditFlow_createTime = now;
            #endregion

            #region 协同办公表单审批人初始化
            CommonService.Model.OA.O_Form_AuditPerson oFormAuditPerson = new Model.OA.O_Form_AuditPerson();
            oFormAuditPerson.O_Form_AuditPerson_code = Guid.NewGuid();
            oFormAuditPerson.O_Form_AuditPerson_formAuditFlow = oFromAuditFlow.O_Form_AuditFlow_code;
            oFormAuditPerson.O_Form_AuditPerson_auditPerson = auditPersonCode;
            oFormAuditPerson.O_Form_AuditPerson_status = Convert.ToInt32(FormApprovalTypeEnum.未审核);
            oFormAuditPerson.O_Form_AuditPerson_isDelete = false;
            oFormAuditPerson.O_Form_AuditPerson_creator = submitUserCode;
            oFormAuditPerson.O_Form_AuditPerson_createTime = now;
            #endregion

            #region 保存协同办公初始化数据
            FAflowBLL.Add(oFromAuditFlow);
            FAPbll.Add(oFormAuditPerson);
            #endregion

        }

        /// <summary>
        /// 处理表单审批数据(状态),并且返回表单是否可以审批通过的标识
        /// </summary>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="submitUserCode">提交用户Guid</param>
        /// <param name="now">当前时间</param>
        /// <returns></returns>
        private bool DealFormAuditData(Guid oFormCode, Guid submitUserCode, DateTime now)
        {
            bool isPassAuditForm = false;//是否可以通过表单审核
            int formAuditFlowCount = 0;
            List<CommonService.Model.OA.O_Form_AuditFlow> oFormAuditFlows = FAflowBLL.GetFormAuditFlowsByFormCode(oFormCode);

            foreach (CommonService.Model.OA.O_Form_AuditFlow formAuditFlow in oFormAuditFlows)
            {
                formAuditFlowCount++;
                if (formAuditFlowCount > 1)
                {
                    isPassAuditForm = false;
                    break;
                }
                List<CommonService.Model.OA.O_Form_AuditPerson> FormAuditPersons = FAPbll.GetFormAuditPersonsByFormAuditFlowCode(formAuditFlow.O_Form_AuditFlow_code.Value);
                foreach (CommonService.Model.OA.O_Form_AuditPerson auditPerson in FormAuditPersons)
                {
                    if (auditPerson.O_Form_AuditPerson_auditPerson == submitUserCode)
                    {//赋值审批人与当前提交人为同一个，则设置为"已通过"(这种情况下一个审批流程下关联的审批人只有一个)
                        auditPerson.O_Form_AuditPerson_auditTime = now;
                        auditPerson.O_Form_AuditPerson_status = Convert.ToInt32(FormApprovalTypeEnum.已通过);
                        auditPerson.O_Form_AuditPerson_content = "提交并且审批通过";

                        FAPbll.Update(auditPerson);
                        isPassAuditForm = true;

                    }
                }
                if (isPassAuditForm)
                {
                    formAuditFlow.O_Form_AuditFlow_auditStatus = Convert.ToInt32(FormAuditTypeEnum.已通过);
                    formAuditFlow.O_Form_AuditFlow_auditTime = now;

                    FAflowBLL.Update(formAuditFlow);
                }
            }

            return isPassAuditForm;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_Form model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid O_Form_code)
        {

            return dal.Delete(O_Form_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_Form_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(O_Form_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_Form GetModel(Guid O_Form_code)
        {

            return dal.GetModel(O_Form_code);
        }

        /// <summary>
        /// 通过业务流程表单关联Guid，得到一条数据
        /// </summary>
        /// <param name="businessFlowform">业务流程表单关联Guid</param>
        /// <returns></returns> 
        public CommonService.Model.OA.O_Form GetByBusinessFlowformCode(Guid businessFlowform)
        {
            return dal.GetByBusinessFlowformCode(businessFlowform);
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
        public List<CommonService.Model.OA.O_Form> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.OA.O_Form> modelList = new List<CommonService.Model.OA.O_Form>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.OA.O_Form model;
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
        public int GetRecordCount(CommonService.Model.OA.O_Form model)
        {
            return dal.GetRecordCount(model);
        }

        /// <summary>
        ///  获取待办任务总记录数
        /// </summary>
        /// <param name="model">查询模型数据</param>
        /// <param name="isPreSetManager">是否为内置系统管理员账号</param>
        /// <param name="userCode">当前登录子用户</param>
        /// <returns></returns>
        public int GetMyTaskRecordCount(CommonService.Model.OA.O_Form model, bool isPreSetManager, Guid? userCode)
        {
            return dal.GetMyTaskRecordCount(model, isPreSetManager, userCode);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_Form> GetListByPage(CommonService.Model.OA.O_Form model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }

        /// <summary>
        ///  获取待办任务总记录数
        /// </summary>
        /// <param name="model">查询模型数据</param>
        /// <param name="isPreSetManager">是否为内置系统管理员账号</param>
        /// <param name="userCode">当前登录子用户</param>
        /// <returns></returns>
        public List<CommonService.Model.OA.O_Form> GetMyTaskListByPage(CommonService.Model.OA.O_Form model, string orderby, int startIndex, int endIndex, bool isPreSetManager, Guid? userCode)
        {
            return DataTableToList(dal.GetMyTaskListByPage(model, orderby, startIndex, endIndex, isPreSetManager, userCode).Tables[0]);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 增加或者修改表单时多条数据操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOrAddList(CommonService.Model.OA.O_Form model, int type)
        {
            bool flag = true;
            if (type == 1)
            {//添加数据
                model.O_Form_createTime = DateTime.Now;
                if (!(Add(model) > 0))//先向表单表中添加数据
                    flag = false;
                else
                {//再向表单审批流程表   和   	表单审批人表  中添加数据
                    List<CommonService.Model.OA.O_FlowSet> flowsetLists = flowsetBLL.GetListByFlowCode(new Guid(model.O_Form_flow.ToString()));//所有预设
                    foreach (var item in flowsetLists)
                    {//遍历流程预设添加到表单审批流程表中
                        Guid code = Guid.NewGuid();
                        CommonService.Model.OA.O_Form_AuditFlow FAmodel = new Model.OA.O_Form_AuditFlow();
                        FAmodel.O_Form_AuditFlow_code = code;
                        FAmodel.O_Form_AuditFlow_o_form = model.O_Form_code;
                        FAmodel.O_Form_AuditFlow_flowSet = item.O_FlowSet_code;
                        FAmodel.O_Form_AuditFlow_flowSet_order = item.O_FlowSet_order;
                        FAmodel.O_Form_AuditFlow_flowSet_auditType = item.O_FlowSet_auditType;
                        FAmodel.O_Form_AuditFlow_flowSet_rule = item.O_FlowSet_rule;
                        FAmodel.O_Form_AuditFlow_isDelete = false;
                        FAmodel.O_Form_AuditFlow_creator = model.O_Form_creator;
                        FAmodel.O_Form_AuditFlow_createTime = DateTime.Now;
                        FAmodel.O_Form_AuditFlow_auditStatus = Convert.ToInt32(FormAuditTypeEnum.未开始);
                        if (!(FAflowBLL.Add(FAmodel) > 0))
                            flag = false;
                        List<CommonService.Model.OA.O_FlowSet_AuditPerson> flowsetPerList = flowsetPerBLL.GetApplyListByflowCode(new Guid(item.O_FlowSet_code.ToString()));//所有的审核人
                        foreach (var item2 in flowsetPerList)
                        { //遍历所有的预设审核人添加到表单审批人表中
                            CommonService.Model.OA.O_Form_AuditPerson FAPmodel = new Model.OA.O_Form_AuditPerson();
                            FAPmodel.O_Form_AuditPerson_code = Guid.NewGuid();
                            FAPmodel.O_Form_AuditPerson_formAuditFlow = code;
                            FAPmodel.O_Form_AuditPerson_isDelete = false;
                            FAPmodel.O_Form_AuditPerson_auditPerson = item2.O_FlowSet_auditPerson_auditPerson;
                            FAPmodel.O_Form_AuditPerson_creator = model.O_Form_creator;
                            FAPmodel.O_Form_AuditPerson_createTime = DateTime.Now;
                            FAPmodel.O_Form_AuditPerson_status = Convert.ToInt32(FormApprovalTypeEnum.未审核);
                            if (!(FAPbll.Add(FAPmodel) > 0))
                                flag = false;
                        }
                    }

                }

            }
            else
            { //修改数据
                //CommonService.Model.OA.O_Form Fmodel = GetModel(new Guid(model.O_Form_code.ToString()));//老的实体
                //if (!Update(model))//先修改表单表数据
                //    flag = false;
                //if (Fmodel.O_Form_flow != model.O_Form_flow)
                //{ //修改了流程
                //    CommonService.Model.OA.O_Form Fmodel2 = GetModel(new Guid(model.O_Form_code.ToString()));//修改完FORM后  从新获取FORM的实体
                //    //先删除之前的表单审批流程表的信息

                //}
            }

            return flag;
        }
        /// <summary>
        /// 通过业务流程表单关联Guid，得到未提交的数据
        /// </summary>
        /// <param name="businessFlowform">业务流程表单关联Guid</param>
        /// <returns></returns> 
        public CommonService.Model.OA.O_Form GetModelByBusinessFlowformCode(Guid businessFlowform, Guid fForm, Guid O_Form_creator)
        {
            return dal.GetModelByBusinessFlowformCode(businessFlowform, fForm, O_Form_creator);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
