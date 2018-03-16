using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.FinanceManager.Controllers
{
    /// <summary>
    /// 费用报销单Control
    /// </summary>
    public class FeeReimbursementController : BaseController
    {
        private readonly ICommonService.CustomerForm.IF_FormProperty _formPropertyWCF;
        private readonly ICommonService.CustomerForm.IF_FormPropertyValue _formPropertyValueWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.SysManager.IC_Organization _organizationWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance _businessChanceWCF;
        CommonService.Common.RMBCapitalization rmbCapitalization = new CommonService.Common.RMBCapitalization();
        private readonly ICommonService.FinanceManager.IC_Voucher _voucherWCF;
        private readonly ICommonService.FinanceManager.IC_Voucher_Form _voucherFormWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePower;

        public FeeReimbursementController()
        {
            #region 服务初始化
            _formPropertyWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormProperty>("FormPropertyWCF");
            _formPropertyValueWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormPropertyValue>("FormPropertyValueWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _organizationWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization>("OrganizationWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _businessChanceWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance>("BusinessChanceWCF");
            _voucherWCF = ServiceProxyFactory.Create<ICommonService.FinanceManager.IC_Voucher>("VoucherWCF");
            _voucherFormWCF = ServiceProxyFactory.Create<ICommonService.FinanceManager.IC_Voucher_Form>("Voucher_FormWCF");
            _roleRolePower = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            #endregion
        }

        //
        // GET: /FinanceManager/FeeReimbursement/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();

            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)

            string formCode = "4B483102-0B05-418A-ACC0-41313D5D083E";//费用报销单Guid(固定值)
            string condition = "1=1 ";//查询条件

            #region 列表数据权限处理
            if (!UIContext.Current.IsPreSetManager)
            {
                StringBuilder strPowerSql = new StringBuilder();
                string rolePowerIds = this.GetRolePowers();
                strPowerSql.Append(" and (1<>1 ");
                strPowerSql.Append(" or (O_Form_applyPerson='" + Context.UIContext.Current.UserCode + "') ");
                if (rolePowerIds.Contains(",18,"))
                {//专业顾问数据权限               

                }
                else if (rolePowerIds.Contains(",19,"))
                {//可以看到自己的和自己负责流程下所有表单负责人的               
                    strPowerSql.Append(" or exists(select 1 from P_Business_flow As PF with(nolock) where PF.P_Business_flow_code=TT.P_Business_flow_code and PF.P_Business_isdelete=0 and PF.P_Business_person='" + UIContext.Current.UserCode + "' ) ");
                }
                else if (rolePowerIds.Contains(",20,"))
                {//可以看到自己的

                }
                else if (rolePowerIds.Contains(",21,"))
                {//可以看到自己负责所有案件下所有表单中的
                    strPowerSql.Append(" or exists(select 1 from B_Case As B with(nolock) where B.B_Case_isDelete=0 and B.B_Case_code=TT.P_Fk_code and B.B_Case_person='" + UIContext.Current.UserCode + "' ) ");
                }
                else if (rolePowerIds.Contains(",6,"))
                {//可以看到自己负责所有区域内的
                    strPowerSql.Append("or exists(select 1 from C_Organization_post_user_region as OPUR with(nolock),B_Case_link As BCL with(nolock) ");
                    strPowerSql.Append("where OPUR.C_region_code=BCL.C_FK_code ");
                    strPowerSql.Append("and OPUR.C_User_code='" + UIContext.Current.UserCode + "' ");
                    strPowerSql.Append("and BCL.B_Case_link_type=6 ");
                    strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
                    strPowerSql.Append("and BCL.B_Case_code=TT.P_Fk_code) ");
                }
                strPowerSql.Append(") ");
                condition = condition + strPowerSql;
            }
            #endregion

            if (!String.IsNullOrEmpty(form["O_Form_applyPerson_name"]))
            {//申请人名称查询条件
                condition = condition + "and O_Form_applyPerson_name like '%" + form["O_Form_applyPerson_name"].Trim() + "%'";
                ViewBag.applyPersonName = form["O_Form_applyPerson_name"].Trim();
            }
            else
            {
                ViewBag.applyPersonName = "";
            }

            if (!String.IsNullOrEmpty(form["ClientOrParty"]))
            {//委托人/对方当事人
                StringBuilder strSql = new StringBuilder();
                strSql.Append("and (exists(select 1 from B_Case_link As CL with(nolock),C_Customer As C with(nolock) where CL.B_Case_link_isDelete=0 and CL.B_Case_link_type=1 and CL.B_Case_code=TT.P_Fk_code and CL.C_FK_code=C.C_Customer_code and C.C_Customer_name like '%" + form["ClientOrParty"] + "%') ");
                strSql.Append("or exists(select 1 from B_Case_link As CL1 with(nolock),C_CRival As CR with(nolock) where CL1.B_Case_link_isDelete=0 and CL1.B_Case_link_type=2 and CL1.B_Case_code=TT.P_Fk_code and CL1.C_FK_code=CR.C_CRival_code and CR.C_CRival_name like '%" + form["ClientOrParty"] + "%') ");
                strSql.Append("or exists(select 1 from B_Case_link As CL2 with(nolock),C_PRival As PR with(nolock) where CL2.B_Case_link_isDelete=0 and CL2.B_Case_link_type=3 and CL2.B_Case_code=TT.P_Fk_code and CL2.C_FK_code=PR.C_PRival_code and PR.C_PRival_name like '%" + form["ClientOrParty"] + "%'))");
                condition = condition + strSql;

                ViewBag.ClientOrParty = form["ClientOrParty"];
            }
            if (!String.IsNullOrEmpty(form["FeeReimbursementNumber"]))
            {//编号
                condition = condition + "and \"0DDD0794-DC54-45BF-9BFF-FD595EA09AA3\" like '%" + form["FeeReimbursementNumber"].Trim() + "%'";
                ViewBag.FeeReimbursementNumber = form["FeeReimbursementNumber"];
            }
            if (!String.IsNullOrEmpty(form["CaseNumber"]))
            {//案号
                condition = condition + "and exists(select * from B_Case as C with(nolock) where C.B_Case_code=TT.P_Fk_code and C.B_Case_number like '%" + form["CaseNumber"] + "%')";
                ViewBag.CaseNumber = form["CaseNumber"];
            }
            if (!String.IsNullOrEmpty(form["P_flow_code"]) && form["P_flow_code"].ToString() != "全部")
            {//阶段名称查询条件
                condition = condition + "and exists(select * from P_Flow as F right join P_Business_flow as BF on BF.P_Flow_code=F.P_Flow_code where TT.P_Business_flow_code=BF.P_Business_flow_code and F.P_Flow_code='" + form["P_flow_code"] + "')";
                ViewBag.Business_flow_code = form["P_flow_code"];
            }
            if (!String.IsNullOrEmpty(form["PaymentStatus"]) && form["PaymentStatus"].ToString() != "全部")
            {//付款状态
                condition = condition + "and \"0EACB483-D8EF-4141-A767-229DCD71F55A\" = " + form["PaymentStatus"].Trim();
                ViewBag.PaymentStatus = form["PaymentStatus"];
            }
            if ((!String.IsNullOrEmpty(form["CostGenerationTime"])) && (!String.IsNullOrEmpty(form["CostGenerationTime1"])))
            {//费用产生时间
                condition = condition + "and \"A9797CAA-076A-4B6E-8D59-99FE4B9E8F4D\" between '" + form["CostGenerationTime"] + "' and '" + form["CostGenerationTime1"] + "' ";
                ViewBag.CostGenerationTime = form["CostGenerationTime"];
                ViewBag.CostGenerationTime1 = form["CostGenerationTime1"];
            }
            else
            {
                ViewBag.CostGenerationTime = "";
                ViewBag.CostGenerationTime1 = "";
            }
            if (!String.IsNullOrEmpty(form["InvoiceType"]) && form["InvoiceType"].ToString() != "全部")
            {//发票种类
                condition = condition + "and \"801E7FA0-F768-478A-BA73-C418F0D763CF\" = " + form["InvoiceType"].Trim();
                ViewBag.InvoiceTypeId = form["InvoiceType"];
            }
            List<CommonService.Model.FlowManager.P_Flow> casestage = _flowWCF.GetAllList();
            ViewBag.casestage = casestage;
            #endregion

            List<CommonService.Model.CaseManager.B_Case> caseList = _caseWCF.GetModelList(string.Empty);
            ViewBag.caseList = caseList;
            //获取表单明细属性
            List<CommonService.Model.CustomerForm.F_FormProperty> itemFormPropertys = _formPropertyWCF.GetList(new Guid(formCode));

            this.TotalRecordCount = _formPropertyValueWCF.DynamicLoadFeeFormListCount(new Guid(formCode), condition);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取表单明细属性值
            DataSet itemFormPropertyValues = _formPropertyValueWCF.DynamicLoadFeeFormListValues(new Guid(formCode), (this.ThisPageIndex - 1) * this.PageSize + 1,
                this.ThisPageIndex * this.PageSize, condition);
            ViewBag.DynamicItemFormPropertyValues = itemFormPropertyValues;

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(itemFormPropertys);
        }



        /// <summary>
        /// 数据列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <param name="Form_formCode">表单code</param>
        /// <returns></returns>
        public ActionResult ListByForm(FormCollection form, string Form_formCode, int? page = 1)
        {
            InitializationPageParameter();

            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)

            string formCode = "4B483102-0B05-418A-ACC0-41313D5D083E";//费用报销单Guid(固定值)
           string condition = " O_Form_businessFlowform='" + Form_formCode + "' ";

            List<CommonService.Model.FlowManager.P_Flow> casestage = _flowWCF.GetAllList();
            ViewBag.casestage = casestage;
            #endregion

            List<CommonService.Model.CaseManager.B_Case> caseList = _caseWCF.GetModelList(string.Empty);
            ViewBag.caseList = caseList;
            //获取表单明细属性
            List<CommonService.Model.CustomerForm.F_FormProperty> itemFormPropertys = _formPropertyWCF.GetList(new Guid(formCode));

            this.TotalRecordCount = _formPropertyValueWCF.DynamicLoadFeeFormListCount(new Guid(formCode), condition);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取表单明细属性值
            DataSet itemFormPropertyValues = _formPropertyValueWCF.DynamicLoadFeeFormListValues(new Guid(formCode), 1,
                1000, condition);
            ViewBag.DynamicItemFormPropertyValues = itemFormPropertyValues;

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(itemFormPropertys);
        }



        public ActionResult GeneratingDocuments(string formPropertyValueGroup)
        {
            //List<CommonService.Model.CustomerForm.F_FormPropertyValue> formpropertyValues = _formPropertyValueWCF.GetListByFormPropertyValueGroup(new Guid(formPropertyValueGroup));
            string formCode = "4B483102-0B05-418A-ACC0-41313D5D083E";//费用报销单Guid(固定值)
            string condition = "1=1 ";
            DataSet itemFormPropertyValue = null;

            if (!String.IsNullOrEmpty(formPropertyValueGroup))
            {
                string[] groups = formPropertyValueGroup.Split(',');
                string formPropertyValueGroupStr = "";
                foreach (var group in groups)
                {
                    formPropertyValueGroupStr += "'" + group + "',";
                }
                if (formPropertyValueGroupStr != "")
                {
                    formPropertyValueGroupStr = formPropertyValueGroupStr.Substring(0, formPropertyValueGroupStr.Length - 1);
                }
                condition += "and formPropertyValueGroup in (" + formPropertyValueGroupStr + ")";

                itemFormPropertyValue = _formPropertyValueWCF.DynamicLoadFeeFormListValues(new Guid(formCode), 1,
                10000, condition);
            }
            ViewBag.formPropertyValueGroup = formPropertyValueGroup;
            DataTable dt = itemFormPropertyValue.Tables[0];
            //List<CommonService.Model.SysManager.C_Organization> organizations = _organizationWCF.GetAllList();
            //ViewBag.organizations = organizations;

            Guid applyPerson = Guid.Empty;
            if (!String.IsNullOrEmpty(dt.Rows[0]["O_Form_applyPerson"].ToString()))
            {
                applyPerson = new Guid(dt.Rows[0]["O_Form_applyPerson"].ToString());
            }
            CommonService.Model.SysManager.C_Userinfo userinfo = _userinfoWCF.GetModelByUserCode(applyPerson);
            ViewBag.userinfo = userinfo;
            //发票种类参数集合
            List<CommonService.Model.C_Parameters> InvoiceType1 = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.费用类型));
            List<CommonService.Model.C_Parameters> InvoiceType2 = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.垫付款类型));
            List<CommonService.Model.C_Parameters> InvoiceType = InvoiceType1.Concat(InvoiceType2).ToList();
            //摘要
            List<CommonService.Model.Customer.V_Abstract> abstractList = new List<CommonService.Model.Customer.V_Abstract>();
            List<string> caseArrayList = new List<string>();
            Decimal TotalAmount = 0;
            DateTime? applyTime = null;
            string manager = "";
            string regionCode = "";
            string regionName = "";
            int cou = dt.Rows.Count;
            foreach (DataRow dr in dt.Rows)
            {
                CommonService.Model.FlowManager.P_Business_flow businessFlow = new CommonService.Model.FlowManager.P_Business_flow();
                string number = "";
                if (!String.IsNullOrEmpty(dr["P_Business_flow_code"].ToString()))
                {

                    businessFlow = _bussinessFlowWCF.Get(new Guid(dr["P_Business_flow_code"].ToString()));
                    CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(businessFlow.P_Fk_code.Value);
                    if (bcase != null)
                    {
                        number = bcase.B_Case_number;
                        if (bcase.C_Region_code != "")
                        {
                            regionCode = bcase.C_Region_code.Split(',')[0];
                            regionName = bcase.C_Region_name.Split(',')[0];
                        }
                        if (bcase.B_Case_person != null)
                        {
                            CommonService.Model.SysManager.C_Userinfo uModel = _userinfoWCF.GetModelByUserCode(bcase.B_Case_person.Value);
                            if (uModel != null)
                                manager = _userinfoWCF.GetModelByUserCode(bcase.B_Case_person.Value).C_Userinfo_name;
                        }
                    }
                    else
                    {
                        CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(businessFlow.P_Fk_code.Value);
                        number = businessChance.B_BusinessChance_number;
                        manager = businessChance.B_Businesschance_personName;
                    }
                }
                CommonService.Model.C_Parameters parameter = InvoiceType.Where(p => p.C_Parameters_id == Convert.ToInt32(dr["801E7FA0-F768-478A-BA73-C418F0D763CF"])).FirstOrDefault();
                decimal InvoiceValue = Convert.ToDecimal(dr["B6F68C64-0960-429C-AD14-E28B11251153"].ToString());
                if (!string.IsNullOrEmpty(dr["BB84BC11-4A54-43EC-874B-605397D45ABE"].ToString()))
                {
                    int caseCount = Convert.ToInt32(dr["BB84BC11-4A54-43EC-874B-605397D45ABE"].ToString());//案件 
                    decimal InvoiceValue2 = InvoiceValue / caseCount;
                    CommonService.Model.Customer.V_Abstract vabstract = new CommonService.Model.Customer.V_Abstract();
                    vabstract.Number = number;
                    vabstract.InvoiceType = parameter.C_Parameters_name;
                    vabstract.InvoiceValue = InvoiceValue2;

                    TotalAmount += Convert.ToDecimal(InvoiceValue2);
                    CommonService.Model.Customer.V_Abstract v_abstract = abstractList.Where(a => a.Number == vabstract.Number).FirstOrDefault();
                    if (v_abstract != null)
                    {
                        if (v_abstract.InvoiceType == vabstract.InvoiceType)
                        {
                            v_abstract.InvoiceValue = v_abstract.InvoiceValue + vabstract.InvoiceValue;
                            int i = abstractList.FindIndex(a => a.Number == v_abstract.Number);
                            abstractList[i].InvoiceValue = v_abstract.InvoiceValue;
                        }
                        else
                        {
                            abstractList.Add(vabstract);
                        }
                    }
                    else
                    {
                        abstractList.Add(vabstract);
                    }
                    //caseArrayList.Add(number + "：" + parameter.C_Parameters_name + "：" + InvoiceValue2.ToString("0.00"));
                }
                else
                {
                    CommonService.Model.Customer.V_Abstract vabstract = new CommonService.Model.Customer.V_Abstract();
                    vabstract.Number = number;
                    vabstract.InvoiceType = parameter.C_Parameters_name;
                    vabstract.InvoiceValue = InvoiceValue;

                    TotalAmount += Convert.ToDecimal(InvoiceValue);
                    CommonService.Model.Customer.V_Abstract v_abstract = abstractList.Where(a => a.Number == vabstract.Number).FirstOrDefault();
                    if (v_abstract != null)
                    {
                        if (v_abstract.InvoiceType == vabstract.InvoiceType)
                        {
                            v_abstract.InvoiceValue = v_abstract.InvoiceValue + vabstract.InvoiceValue;
                            int i = abstractList.FindIndex(a => a.Number == v_abstract.Number);
                            abstractList[i].InvoiceValue = v_abstract.InvoiceValue;
                        }
                        else
                        {
                            abstractList.Add(vabstract);
                        }
                    }
                    else
                    {
                        abstractList.Add(vabstract);
                    }
                    //caseArrayList.Add(number + "：" + parameter.C_Parameters_name + "：" + InvoiceValue.ToString("0.00"));
                }
                if (dr["O_Form_applyTime"].ToString() != "")
                {
                    applyTime = Convert.ToDateTime(dr["O_Form_applyTime"]);
                }
            }
            string TotalAmountToUppercaseAmount = rmbCapitalization.RMBAmount(Convert.ToDouble(TotalAmount));
            ViewBag.TotalAmount = TotalAmount;
            ViewBag.TotalAmountToUppercaseAmount = TotalAmountToUppercaseAmount;
            string abstractStr;
            foreach (CommonService.Model.Customer.V_Abstract abstractItem in abstractList)
            {
                List<CommonService.Model.Customer.V_Abstract> items = abstractList.Where(a => a.Number == abstractItem.Number).ToList();
                abstractStr = abstractItem.Number + "：";
                string abstracts = "";
                foreach (CommonService.Model.Customer.V_Abstract item in items)
                {
                    abstracts += item.InvoiceType + "：" + item.InvoiceValue + "  ";
                }
                abstractStr = abstractStr + abstracts;
                if (!caseArrayList.Contains(abstractStr))
                {
                    caseArrayList.Add(abstractStr);
                }
            }
            ViewBag.caseArrayList = caseArrayList;
            ViewBag.applyTime = applyTime;
            List<CommonService.Model.SysManager.C_Organization> orgList = new List<CommonService.Model.SysManager.C_Organization>();
            if (userinfo != null)
            {
                orgList = _organizationWCF.GetListByUserCode(applyPerson);
                //org = organizations.Where(o => o.C_Organization_code == userinfo.C_Userinfo_Organization).FirstOrDefault();
            }
            ViewBag.OrganizationList = orgList;
            ViewBag.Manager = manager;
            ViewBag.regionCode = regionCode;
            ViewBag.regionName = regionName;
            ViewBag.DynamicItemFormPropertyValue = itemFormPropertyValue;
            return View();
        }

        /// <summary>
        /// 生成单据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form)
        {
            int isSuccess = 0;
            string formPropertyValueGroup = form["formPropertyValueGroup"];
            string applyPerson = form["O_Form_applyPerson"];//申请人
            string applyTime = form["applyTime"];//申请时间
            string organizationCode = form["organizationCode"];//部门
            string paymentMethod = form["paymentMethod"];//付款方式
            string TotalAmount = form["TotalAmount"];//金额
            string regionCode = form["regionCode"];//区域

            #region 添加一条凭证信息
            List<CommonService.Model.FinanceManager.C_Voucher> vouchers = _voucherWCF.GetAllList();
            string number = "";
            int num = 001;
            if (vouchers.Count() != 0)
            {
                number = vouchers.FirstOrDefault().C_Voucher_number;
                num = int.Parse(number.Substring(number.Length - 3, 3)) + 1;
            }
            CommonService.Model.FinanceManager.C_Voucher voucher = new CommonService.Model.FinanceManager.C_Voucher();
            voucher.C_Voucher_code = Guid.NewGuid();
            voucher.C_Voucher_number = "SC" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + num.ToString("000");
            voucher.C_Voucher_state = 0;
            voucher.C_Voucher_applicationTime = DateTime.Now;
            if (applyPerson != null)
            {
                voucher.C_Voucher_applicationPerson = new Guid(applyPerson);
            }
            voucher.C_Voucher_documentType = Convert.ToInt32(DocumentTypeEnum.报销);
            if (!String.IsNullOrEmpty(organizationCode))
            {
                voucher.C_Voucher_department = new Guid(organizationCode);
            }
            voucher.C_Voucher_amounts = Convert.ToDecimal(TotalAmount);
            voucher.C_Voucher_auditStatus = Convert.ToInt32(FormApprovalTypeEnum.未审核);
            voucher.C_Voucher_paymentMethod = Convert.ToInt32(paymentMethod);
            voucher.C_Voucher_region = regionCode == "" ? Guid.Empty : new Guid(regionCode);
            voucher.C_Voucher_isDelete = false;
            voucher.C_Voucher_creator = Context.UIContext.Current.UserCode;
            voucher.C_Voucher_createTime = DateTime.Now;
            voucher.C_Voucher_type = 1;//1是erp
            isSuccess = _voucherWCF.Add(voucher);
            #endregion

            #region 凭证信息—子表单中间表
            List<CommonService.Model.FinanceManager.C_Voucher_Form> voucherFormList = new List<CommonService.Model.FinanceManager.C_Voucher_Form>();
            string[] formPropertyValueGroups = formPropertyValueGroup.Split(',');
            foreach (var group in formPropertyValueGroups)
            {
                CommonService.Model.FinanceManager.C_Voucher_Form voucherForm = new CommonService.Model.FinanceManager.C_Voucher_Form();
                voucherForm.F_Form_code = new Guid(group);
                voucherForm.C_Voucher_code = voucher.C_Voucher_code;

                voucherFormList.Add(voucherForm);
            }
            _voucherFormWCF.OperateList(voucherFormList);
            #endregion

            if (isSuccess > 0)
            {
                //保存成功提示固定写法
                return Json(voucher.C_Voucher_number);
            }
            else
            {
                //保存失败固定写法
                return Json(0);
            }
        }

        /// <summary>
        /// 获取当前登录用户关联角色权限
        /// </summary>
        /// <returns></returns>
        private string GetRolePowers()
        {
            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!UIContext.Current.IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = _roleRolePower.GetRolePowersByUserCode(Context.UIContext.Current.UserCode);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }

            return rolePowerIds;
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //费用种类参数集合
            List<CommonService.Model.C_Parameters> FeeTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.费用种类));
            ViewBag.FeeTypes = FeeTypes;
            //发票种类参数集合
            List<CommonService.Model.C_Parameters> InvoiceType1 = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.费用类型));
            List<CommonService.Model.C_Parameters> InvoiceType2 = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.垫付款类型));
            List<CommonService.Model.C_Parameters> InvoiceType = InvoiceType1.Concat(InvoiceType2).ToList();
            ViewBag.InvoiceType = InvoiceType;
            //付款状态参数集合
            List<CommonService.Model.C_Parameters> PayStatus = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.付款状态));
            ViewBag.PayStatus = PayStatus;
        }
    }
}