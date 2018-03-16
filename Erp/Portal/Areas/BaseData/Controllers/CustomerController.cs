using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BaseData.Controllers
{
    /// <summary>
    /// 客户控制器
    /// </summary>
    public class CustomerController : BaseController
    {
        private readonly ICommonService.IC_Customer _customerWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Customer_Customer _customerClientWCF;
        private readonly ICommonService.IC_Customer_Region _customerRegionWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
        private readonly ICommonService.IC_Customer_ChangHistory _customer_ChangHistoryWCF;
        private readonly ICommonService.IC_Messages _messageWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.SysManager.IC_Organization_post_user_region _postuser_regionWCF;
        public CustomerController()
        {
            #region 服务初始化
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _customerClientWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Customer>("CustomerClientWCF");
            _customerRegionWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Region>("Customer_RegionWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            _customer_ChangHistoryWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_ChangHistory>("Customer_ChangHistoryWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _postuser_regionWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post_user_region>("C_Organization_post_user_regionWCF");
            #endregion
        }

        string customerConsultant = "";//客户专业顾问名称
        string customerResponsibleDept = "";//客户负责部门名称
        //
        // GET: /BaseData/Customer/
        public override ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="relCode">关联Guid</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string relCode)
        {
            InitializationPageParameter();
            //创建初始化组客户实体
            CommonService.Model.C_Customer customer = new CommonService.Model.C_Customer();
            customer.C_Customer_name = "";
            customer.C_Customer_code = Guid.NewGuid();
            customer.C_Customer_isDelete = false;
            customer.C_Customer_creator = Context.UIContext.Current.UserCode;
            customer.C_Customer_createTime = DateTime.Now;
            customer.C_Customer_businessType = Convert.ToInt32(CustomerBusiness.客户);
            customer.C_Customer_yearTurnover = 0.00M;
            if (Context.UIContext.Current.PostGroupCode == Context.PostGroup.ProfessionalConsultant)
            {
                customer.C_Customer_consultant = Context.UIContext.Current.UserCode;
                customer.C_Customer_consultant_name = Context.UIContext.Current.UserName;
            }
            //默认专业顾问
            if (Context.UIContext.Current.UserRoles.Contains("8"))
            {
                customer.C_Customer_consultant = Context.UIContext.Current.UserCode;
                customer.C_Customer_consultant_name = Context.UIContext.Current.UserName;
            }
            customer.C_Customer_goingStatus = Convert.ToInt32(BusinessFlowStatus.未开始);
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Organization_post_user_region> userinfoRegion = _postuser_regionWCF.GetOrgUserPostRegions(UIContext.Current.OrgCode.Value, UIContext.Current.UserCode.Value, UIContext.Current.PostCode.Value);
                if (userinfoRegion.Count() > 0)
                {
                    customer.C_Customer_Region_code = userinfoRegion.FirstOrDefault().C_region_code.ToString();
                    customer.C_Customer_Region_name = userinfoRegion.FirstOrDefault().C_region_name;
                }
            }
            if (!String.IsNullOrEmpty(relCode))
            {
                customer.C_Customer_relcode = new Guid(relCode);
            }
            return View(customer);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>

        public ActionResult Edit(string customerCode)
        {
            InitializationPageParameter();
            CommonService.Model.C_Customer customer = _customerWCF.Get(new Guid(customerCode));
            ViewBag.SaveType = "2";
            return View("create", customer);
        }
        /// <summary>
        /// tab 页签
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <returns></returns>
        public ActionResult TabDetails(string customerCode)
        {
            ViewBag.CustomerCode = customerCode;
            return View();
        }

        /// <summary>
        /// 客户 tab 页签
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <returns></returns>
        public ActionResult CustTabDetails(string customerCode)
        {
            ViewBag.CustomerCode = customerCode;
            return View();
        }

        /// <summary>
        /// 客户信息详情
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <returns></returns>
        public ActionResult Details(string customerCode)
        {
            CommonService.Model.C_Customer customer = _customerWCF.Get(new Guid(customerCode));
            InitializationPageParameter(customer);
            return View(customer);
        }
          
        /// <summary>
        /// 提交表单
        /// </summary> 
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.C_Customer customer)
        {
            if (_customerWCF.Exists(customer))
            {//判断客户名称是否存在
                return Json(TipHelper.JsonData("此客户名称已存在！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
            {//专业顾问赋值
                customer.C_Customer_consultant = new Guid(form["mainLawyerlookup.Code"].Trim());
            }
            if (!String.IsNullOrEmpty(form["responsibleDeptlookup.Code"]))
            {//负责部门赋值
                customer.C_Customer_responsibleDept = new Guid(form["responsibleDeptlookup.Code"].Trim())  ;
            }

            customerConsultant = form["mainLawyerlookup.Name"];//客户专业顾问名称
            customerResponsibleDept = form["responsibleDeptlookup.Name"];//客户负责部门名称

            #region 关联区域

            string regionCode = form["mainLawyerlookup.RegionCode"];//客户关连区域code
            string regionName = form["mainLawyerlookup.RegionName"];//客户关连区域名称

            customer.C_Customer_Region_code = regionCode.ToString();
            customer.C_Customer_Region_name = regionName;

            CommonService.Model.C_Customer_Region customerRegion = new CommonService.Model.C_Customer_Region();
            customerRegion.C_Customer_Region_customer = customer.C_Customer_code.Value;
            customerRegion.C_Customer_Region_relRegion = new Guid(regionCode);
            customerRegion.C_Customer_Region_isDelete = 0;
            customerRegion.C_Customer_Region_creator = customer.C_Customer_creator;
            customerRegion.C_Customer_Region_createTime = DateTime.Now;

            _customerRegionWCF.DeleteByCustomerCode(customer.C_Customer_code.Value);
            _customerRegionWCF.Add(customerRegion);

            //Guid? userinfoChilds = new Guid();
            //if (customer.C_Customer_consultant != null)
            //{
            //    userinfoChilds = customer.C_Customer_consultant.Value;//专业顾问
            //}
            //else
            //{
            //    userinfoChilds = customer.C_Customer_responsiblePerson.Value;//专家部长
            //}
            //if (userinfoChilds != null)
            //{
            //    List<CommonService.Model.SysManager.C_Organization_post_user_region> userinfoRegion = _postuser_regionWCF.GetOrgUserPostRegions(UIContext.Current.OrgCode.Value, userinfoChilds.Value, UIContext.Current.PostCode.Value);
            //    if (userinfoRegion.Count() > 0)
            //    {
            //        customer.C_Customer_Region_code = userinfoRegion.FirstOrDefault().C_region_code.ToString();
            //        customer.C_Customer_Region_name = userinfoRegion.FirstOrDefault().C_region_name;

            //        CommonService.Model.C_Customer_Region customerRegion = new CommonService.Model.C_Customer_Region();
            //        customerRegion.C_Customer_Region_customer = customer.C_Customer_code.Value;
            //        customerRegion.C_Customer_Region_relRegion = userinfoRegion.FirstOrDefault().C_region_code;
            //        customerRegion.C_Customer_Region_isDelete = 0;
            //        customerRegion.C_Customer_Region_creator = customer.C_Customer_creator;
            //        customerRegion.C_Customer_Region_createTime = DateTime.Now;

            //        _customerRegionWCF.DeleteByCustomerCode(customer.C_Customer_code.Value);
            //        _customerRegionWCF.Add(customerRegion);
            //    }
            //}

            #endregion

            //服务方法调用
            int customerId = 0;

            if (customer.C_Customer_id > 0)
            {//修改
                bool isUpdateSuccess = CustomerChange(customer);
                if (isUpdateSuccess)
                {
                    customerId = customer.C_Customer_id;
                }
                bool isUpdate = _customerWCF.Update(customer);
            }
            else
            {//添加
                customer.C_Customer_createTime = DateTime.Now;
                customerId = _customerWCF.Add(customer);

                #region 关联委托人
                if (customer.C_Customer_relcode != null)
                {
                    CommonService.Model.C_Customer_Customer customerClient = new CommonService.Model.C_Customer_Customer();
                    customerClient.C_Customer_Customer_customer = customer.C_Customer_code;
                    customerClient.C_Customer_Customer_relCustomer = customer.C_Customer_relcode;
                    customerClient.C_Customer_Customer_isDelete = false;
                    customerClient.C_Customer_Customer_creator = Context.UIContext.Current.UserCode;
                    customerClient.C_Customer_Customer_createTime = DateTime.Now;

                    _customerClientWCF.Add(customerClient);
                }
                #endregion
            }

            if (customerId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存客户信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存客户信息成功", "/baseData/customer/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存客户信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存客户信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

        }
        /// <summary>
        /// 记录修改后的客户信息
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        private bool CustomerChange(CommonService.Model.C_Customer newCustomer)
        {
            CommonService.Model.C_Customer oldCustomer = _customerWCF.Get(newCustomer.C_Customer_code.Value);
            List<CommonService.Model.C_Customer_ChangHistory> customerChangHistoryList = new List<CommonService.Model.C_Customer_ChangHistory>();

            //新客户实体
            Type newCustomerType = newCustomer.GetType();
            System.Reflection.PropertyInfo[] newCustomerPs = newCustomerType.GetProperties();
            //老客户实体
            Type oldCustomerType = oldCustomer.GetType();
            System.Reflection.PropertyInfo[] oldCustomerPs = oldCustomerType.GetProperties();

            #region 记录修改后的客户信息
            for (int i = 0; i < newCustomerPs.Count(); i++)
            {
                object oldObj = oldCustomerPs[i].GetValue(oldCustomer, null);
                //string oldName = oldCustomerPs[i].Name;
                object newObj = newCustomerPs[i].GetValue(newCustomer, null);
                //string newName = newCustomerPs[i].Name;
                if (newObj != null && newObj != "")
                {
                    if (!newObj.Equals(oldObj))
                    {
                        CommonService.Model.C_Customer_ChangHistory customerChangHistory = new CommonService.Model.C_Customer_ChangHistory();
                        customerChangHistory.C_Customer_ChangHistory_code = Guid.NewGuid();
                        customerChangHistory.C_Customer_ChangHistory_customer = newCustomer.C_Customer_code.Value;
                        customerChangHistory.C_Customer_ChangHistory_type = Convert.ToInt32(ChangHistoryTypeEnum.客户);
                        customerChangHistory.C_Customer_ChangHistory_field = newCustomerPs[i].Name;
                        switch (newCustomerPs[i].Name)
                        {
                            case "C_Customer_name":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "客户名称";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_type": customerChangHistory.C_Customer_ChangHistory_fieldName = "客户类型";
                                List<CommonService.Model.C_Parameters> CustomerTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户类型));
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : CustomerTypes.Where(c => c.C_Parameters_id == Convert.ToInt32(oldObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = CustomerTypes.Where(c => c.C_Parameters_id == Convert.ToInt32(newObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "C_Customer_Category": customerChangHistory.C_Customer_ChangHistory_fieldName = "客户类别";
                                List<CommonService.Model.C_Parameters> Category = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户类别));
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : Category.Where(c => c.C_Parameters_id == Convert.ToInt32(oldObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = Category.Where(c => c.C_Parameters_id == Convert.ToInt32(newObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "C_Customer_State": customerChangHistory.C_Customer_ChangHistory_fieldName = "客户状态";
                                List<CommonService.Model.C_Parameters> State = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户状态));
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : State.Where(c => c.C_Parameters_id == Convert.ToInt32(oldObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = State.Where(c => c.C_Parameters_id == Convert.ToInt32(newObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "C_Customer_industryCode": customerChangHistory.C_Customer_ChangHistory_fieldName = "行业";
                                List<CommonService.Model.C_Parameters> Industrys = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.行业));
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : Industrys.Where(c => c.C_Parameters_id == Convert.ToInt32(oldObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = Industrys.Where(c => c.C_Parameters_id == Convert.ToInt32(newObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "C_Customer_yearTurnover":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "年营业额";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_companySize":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "公司规模";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_source": customerChangHistory.C_Customer_ChangHistory_fieldName = "客户来源";
                                List<CommonService.Model.C_Parameters> CustomerSources = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户来源));
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : CustomerSources.Where(c => c.C_Parameters_id == Convert.ToInt32(oldObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = CustomerSources.Where(c => c.C_Parameters_id == Convert.ToInt32(newObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "C_Customer_level": customerChangHistory.C_Customer_ChangHistory_fieldName = "客户级别";
                                List<CommonService.Model.C_Parameters> CustomerLevels = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户级别));
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : CustomerLevels.Where(c => c.C_Parameters_id == Convert.ToInt32(oldObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = CustomerLevels.Where(c => c.C_Parameters_id == Convert.ToInt32(newObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "C_Customer_tel":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "电话";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_fax":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "传真";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_shortName":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "客户简称";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_email": customerChangHistory.C_Customer_ChangHistory_fieldName = "Email";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_mainContactPhone":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "联系人电话";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_isSignedState": customerChangHistory.C_Customer_ChangHistory_fieldName = "是否签约客户";
                                List<CommonService.Model.C_Parameters> IsSignedStates = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.是否签约客户));
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : IsSignedStates.Where(c => c.C_Parameters_id == Convert.ToInt32(oldObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = IsSignedStates.Where(c => c.C_Parameters_id == Convert.ToInt32(newObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "C_Customer_address":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "营业地址";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_signedState": customerChangHistory.C_Customer_ChangHistory_fieldName = "签约客户状态";
                                List<CommonService.Model.C_Parameters> SignedStates = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.签约客户状态));
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : SignedStates.Where(c => c.C_Parameters_id == Convert.ToInt32(oldObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = SignedStates.Where(c => c.C_Parameters_id == Convert.ToInt32(newObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "C_Customer_consultant":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "专业顾问";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldCustomer.C_Customer_consultant_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = customerConsultant;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "C_Customer_contacter":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "联系人";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_website":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "公司网址";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_lastContactDate":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "最后接触日期";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_responsibleDept":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "负责部门";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldCustomer.C_Customer_responsibleDept_Name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = customerResponsibleDept;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "C_Customer_value":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "客户价值";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "C_Customer_loyalty": customerChangHistory.C_Customer_ChangHistory_fieldName = "客户忠诚度";
                                List<CommonService.Model.C_Parameters> CustomerLoyaltys = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户忠诚度));
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : CustomerLoyaltys.Where(c => c.C_Parameters_id == Convert.ToInt32(oldObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = CustomerLoyaltys.Where(c => c.C_Parameters_id == Convert.ToInt32(newObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "C_Customer_remark":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "备注";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                        }
                        customerChangHistory.C_Customer_ChangHistory_submitPerson = Context.UIContext.Current.UserCode;
                        customerChangHistory.C_Customer_ChangHistory_submitDate = DateTime.Now;
                        customerChangHistory.C_Customer_ChangHistory_isDelete = false;
                        customerChangHistory.C_Customer_ChangHistory_creator = Context.UIContext.Current.UserCode;
                        customerChangHistory.C_Customer_ChangHistory_createTime = DateTime.Now;

                        if (Context.UIContext.Current.PostGroupCode == PostGroup.ChiefExpert || Context.UIContext.Current.PostGroupCode == PostGroup.Minister || Context.UIContext.Current.IsPreSetManager)
                        {//首席专家、专家部长不用审核，直接通过，审核人为自己
                            customerChangHistory.C_Customer_ChangHistory_state = Convert.ToInt32(CustomerChangHistoryStateEnum.已通过);
                            customerChangHistory.C_Customer_ChangHistory_checkPerson = UIContext.Current.UserCode;
                            customerChangHistory.C_Customer_ChangHistory_checkDate = DateTime.Now;
                        }
                        else
                        {
                            customerChangHistory.C_Customer_ChangHistory_state = Convert.ToInt32(CustomerChangHistoryStateEnum.待审核);
                            customerChangHistory.C_Customer_ChangHistory_checkPerson = newCustomer.C_Customer_responsiblePerson;
                            //customerChangHistory.C_Customer_ChangHistory_checkDate = DateTime.Now;
                        }

                        customerChangHistoryList.Add(customerChangHistory);
                    }
                }
            }
            #endregion

            bool isSuccess = false;
            isSuccess = _customer_ChangHistoryWCF.OpreateList(customerChangHistoryList);
            if (Context.UIContext.Current.PostGroupCode == PostGroup.ChiefExpert || Context.UIContext.Current.PostGroupCode == PostGroup.Minister || Context.UIContext.Current.IsPreSetManager)
            {//首席专家、专家部长不用审核，直接通过，审核人为自己
                isSuccess = _customerWCF.Update(newCustomer);
            }
            else
            {
                if (customerChangHistoryList.Count > 0 && isSuccess)
                {
                    #region 给客户负责人发送消息
                    if (newCustomer.C_Customer_responsiblePerson != null)
                    {
                        CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.客户);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.客户变更申请);
                        message.C_Messages_link = newCustomer.C_Customer_code;
                        message.C_Messages_createTime = DateTime.Now;
                        message.C_Messages_person = newCustomer.C_Customer_responsiblePerson;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;

                        _messageWCF.Add(message);
                    }
                    #endregion
                }
            }

            return isSuccess;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string customerCode)
        {
            bool isSuccess = _customerWCF.Delete(new Guid(customerCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除客户信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除客户信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 关联客户信息
        /// </summary>
        /// <param name="c_Clients_codes">客户Guid串，逗号隔开</param>
        /// <param name="c_Customer_codes">关联Guid(如委托人Guid)</param>
        /// <returns></returns>
        public ActionResult RelationCustomer(string c_Customer_codes, string relationCode)
        {
            bool isSuccess = false;
            string[] customer_codes = c_Customer_codes.Split(',');

            for (int i = 0; i < customer_codes.Length; i++)
            {
                if (!String.IsNullOrEmpty(customer_codes[i]))
                {
                    CommonService.Model.C_Customer_Customer customerClient = new CommonService.Model.C_Customer_Customer();
                    customerClient.C_Customer_Customer_customer = new Guid(customer_codes[i]);
                    customerClient.C_Customer_Customer_relCustomer = new Guid(relationCode);
                    customerClient.C_Customer_Customer_isDelete = false;
                    customerClient.C_Customer_Customer_creator = Context.UIContext.Current.UserCode;
                    customerClient.C_Customer_Customer_createTime = DateTime.Now;

                    _customerClientWCF.Add(customerClient);
                    isSuccess = true;
                }
            }

            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("关联委托人信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("关联委托人信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 客户tab
        /// </summary>
        /// <returns></returns>
        public ActionResult ListTab()
        {
            if (UIContext.Current.IsPreSetManager)
            {
                return RedirectToAction("list");
            }

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
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;

            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//客户名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); ;
            }
            customerConditon.C_Customer_businessType = Convert.ToInt32(CustomerBusiness.客户);
            if (!String.IsNullOrEmpty(form["consultantlookup.Code"]))
            {//专业顾问
                customerConditon.C_Customer_consultant = new Guid(form["consultantlookup.Code"]);
                customerConditon.C_Customer_consultant_name = form["consultantlookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["C_Region_code"]) && (form["C_Region_code"].ToString()) != "全部")
            {//区域
                customerConditon.C_Customer_Region_code = form["C_Region_code"];
            }
            else
            {
                customerConditon.C_Customer_Region_code = Guid.Empty.ToString();
            }
            if (!String.IsNullOrEmpty(form["responsibleDeptlookup.Code"]))
            {//组织架构
                customerConditon.C_Customer_responsibleDept = new Guid(form["responsibleDeptlookup.Code"]);
                customerConditon.C_Customer_responsibleDept_Name = form["responsibleDeptlookup.Name"];
            }

            //客户查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;

            #endregion

            this.AddressUrlParameters = "?type=1";

            //用户所属部门
            Guid? orgCode = GetOrgCode(form);
            //用户所属岗位
            Guid? postCode = GetPostCode(form);
            //用户所属岗位组
            Guid? postGroupCode = GetPostGroupCode(form);

            ViewBag.CustomerConditon = customerConditon;

            //获取客户总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, postCode, orgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Desc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, postCode, orgCode);

            #region 权限
            this.DistributedInitButtonsPower(orgCode, postCode);
            this.DistributedInitLogin(orgCode, postCode, postGroupCode);
            #endregion

            return View(customers);
        }
        #region 数据导出功能
        public FileResult Export(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();

            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//客户名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); ;
            }
            customerConditon.C_Customer_businessType = Convert.ToInt32(CustomerBusiness.客户);
            if (!String.IsNullOrEmpty(form["consultantlookup.Code"]))
            {//专业顾问
                customerConditon.C_Customer_consultant = new Guid(form["consultantlookup.Code"]);
                customerConditon.C_Customer_consultant_name = form["consultantlookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["C_Region_code"]) && (form["C_Region_code"].ToString()) != "全部")
            {//区域
                customerConditon.C_Customer_Region_code = form["C_Region_code"];
            }
            else
            {
                customerConditon.C_Customer_Region_code = Guid.Empty.ToString();
            }
            if (!String.IsNullOrEmpty(form["responsibleDeptlookup.Code"]))
            {//组织架构
                customerConditon.C_Customer_responsibleDept = new Guid(form["responsibleDeptlookup.Code"]);
                customerConditon.C_Customer_responsibleDept_Name = form["responsibleDeptlookup.Name"];
            }

            //客户查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;

            #endregion

            //用户所属部门
            Guid? orgCode = GetOrgCode(form);
            //用户所属岗位
            Guid? postCode = GetPostCode(form);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取案件数据信息
            List<CommonService.Model.C_Customer> checkList = _customerWCF.GetCustomerListByPage(customerConditon,
                "", 1, 1000000, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, postCode, orgCode);

            #region 权限
            this.InitializationButtonsPower();
            #endregion
            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);

            row1.CreateCell(0).SetCellValue("客户名称");
            row1.CreateCell(1).SetCellValue("客户级别");
            row1.CreateCell(2).SetCellValue("客户类型");
            row1.CreateCell(3).SetCellValue("客户来源");
            row1.CreateCell(4).SetCellValue("客户忠诚度");
            row1.CreateCell(5).SetCellValue("专业顾问");
            row1.CreateCell(6).SetCellValue("最后接触日期");
            row1.CreateCell(7).SetCellValue("是否签约");
            row1.CreateCell(8).SetCellValue("签约状态");
            row1.CreateCell(9).SetCellValue("备注");
            //....N行

            //将数据逐步写入sheet1各个行
            for (int i = 0; i < checkList.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(checkList[i].C_Customer_name.ToString());

                if (checkList[i].C_Customer_level == 35)
                {
                    rowtemp.CreateCell(1).SetCellValue("普通客户");
                }
                else if (checkList[i].C_Customer_level == 36)
                {
                    rowtemp.CreateCell(1).SetCellValue("重点客户");
                }
                else if (checkList[i].C_Customer_level == 37)
                {
                    rowtemp.CreateCell(1).SetCellValue("战略客户");
                }
                if (checkList[i].C_Customer_type == 23)
                {
                    rowtemp.CreateCell(2).SetCellValue("个体户");
                }
                else if (checkList[i].C_Customer_type == 24)
                {
                    rowtemp.CreateCell(2).SetCellValue("单位");
                }
                else if (checkList[i].C_Customer_type == 25)
                {
                    rowtemp.CreateCell(2).SetCellValue("自然人");
                }
                if (checkList[i].C_Customer_source == 30)
                {
                    rowtemp.CreateCell(3).SetCellValue("内部资源");
                }
                else if (checkList[i].C_Customer_source == 31)
                {
                    rowtemp.CreateCell(3).SetCellValue("网络广告");
                }
                else if (checkList[i].C_Customer_source == 32)
                {
                    rowtemp.CreateCell(3).SetCellValue("电话推广");
                }
                else if (checkList[i].C_Customer_source == 33)
                {
                    rowtemp.CreateCell(3).SetCellValue("老客户推荐");
                }
                else if (checkList[i].C_Customer_source == 34)
                {
                    rowtemp.CreateCell(3).SetCellValue("网站推广");
                }
                if (checkList[i].C_Customer_loyalty == 43)
                {
                    rowtemp.CreateCell(4).SetCellValue("高");
                }
                else if (checkList[i].C_Customer_loyalty == 44)
                {
                    rowtemp.CreateCell(4).SetCellValue("中");
                }
                else if (checkList[i].C_Customer_loyalty == 45)
                {
                    rowtemp.CreateCell(4).SetCellValue("低");
                }
                if (checkList[i].C_Customer_consultant_name != null)
                {
                    rowtemp.CreateCell(5).SetCellValue(checkList[i].C_Customer_consultant_name.ToString());
                }
                else
                {
                    rowtemp.CreateCell(5).SetCellValue("");
                }
                if (checkList[i].C_Customer_lastContactDate != null)
                {
                    rowtemp.CreateCell(6).SetCellValue(checkList[i].C_Customer_lastContactDate.ToString());
                }
                else
                {
                    rowtemp.CreateCell(6).SetCellValue("");
                }
                if (checkList[i].C_Customer_isSignedState == 38)
                {
                    rowtemp.CreateCell(7).SetCellValue("未签约");
                }
                else if (checkList[i].C_Customer_isSignedState == 39)
                {
                    rowtemp.CreateCell(7).SetCellValue("已签约");
                }
                if (checkList[i].C_Customer_signedState == 40)
                {
                    rowtemp.CreateCell(8).SetCellValue("正常");
                }
                else if (checkList[i].C_Customer_signedState == 41)
                {
                    rowtemp.CreateCell(8).SetCellValue("流失");
                }
                else if (checkList[i].C_Customer_signedState == 42)
                {
                    rowtemp.CreateCell(8).SetCellValue("死亡");
                }
                rowtemp.CreateCell(9).SetCellValue(checkList[i].C_Customer_remark.ToString());

                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "客户列表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion
        /// <summary>
        /// 模糊查重列表
        /// </summary>
        /// <returns></returns>
        public ActionResult FuzzyCheckingList(FormCollection form, string keyWord, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)
            string where = "";
            //客户查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();
            if (!String.IsNullOrEmpty(keyWord))
            {
                customerConditon.C_Customer_name = keyWord.Trim();
            }
            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//客户名称查询条件
                where = form["C_Customer_name"].Trim();
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim();
            }
            //customerConditon.C_Customer_businessType = Convert.ToInt32(CustomerBusiness.客户);
            //客户查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;

            #endregion

            //获取客户总记录数
            this.TotalRecordCount = _customerWCF.GetListByPageCount(" C_Customer_name like" + "'%" + customerConditon.C_Customer_name + "%'");

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 12;
            if (customerConditon.C_Customer_name != "")
            {
                //获取客户数据信息
                List<CommonService.Model.C_Customer> customers = _customerWCF.GetListByPageAll(" C_Customer_name like" + "'%" + customerConditon.C_Customer_name + "%'", "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
                return View(customers);
            }
            else
            {
                //获取客户数据信息
                List<CommonService.Model.C_Customer> customers = _customerWCF.GetListByPageAll("", "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
                return View(customers);
            }
            //List<CommonService.Model.C_Customer> customers = _customerWCF.GetAllList();

        }

        /// <summary>
        /// 关联列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="clientCode">委托人Guid</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult RelList(FormCollection form, string clientCode, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//客户名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["C_Customer_code"]))
            {//委托人Guid查询条件
                customerConditon.C_Customer_code = new Guid(form["C_Customer_code"].Trim());
            }
            if (!String.IsNullOrEmpty(clientCode))
            {
                customerConditon.C_Customer_code = new Guid(clientCode);
            }
            if (customerConditon.C_Customer_code != null)
            {
                this.AddressUrlParameters = "?clientCode=" + customerConditon.C_Customer_code;
            }

            customerConditon.C_Customer_reldatatype = 2;//委托人关联客户数据
            customerConditon.C_Customer_Region_code = Guid.Empty.ToString();//关联区域

            //客户查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;

            #endregion

            //获取客户总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, true,
                UIContext.Current.UserCode, null, null);//第二个参数为true，则表示无权限控制，获取所有关连委托人的客户

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, true,
                UIContext.Current.UserCode, null, null);//第二个参数为true，则表示无权限控制，获取所有关连委托人的客户

            #region 权限
            this.InitializationButtonsPower();
            #endregion


            return View(customers);
        }

        /// <summary>
        /// 多选全部客户
        /// </summary>
        /// <param name="form"></param>
        /// <param name="relCode">关联Guid</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MulityRefList(FormCollection form, string relCode, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //委托人查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//委托人名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["C_Customer_relcode"]))
            {//关联Guid查询条件
                customerConditon.C_Customer_relcode = new Guid(form["C_Customer_relcode"].Trim());
            }
            if (!String.IsNullOrEmpty(relCode))
            {
                customerConditon.C_Customer_relcode = new Guid(relCode);
            }
            if (customerConditon.C_Customer_relcode != null)
            {
                this.AddressUrlParameters = "?relCode=" + customerConditon.C_Customer_relcode;
            }
            customerConditon.C_Customer_Region_code = Guid.Empty.ToString();
            //委托人查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;

            #endregion

            //获取委托人总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, true,
                UIContext.Current.UserCode, null, null);
            this.PageSize = 17;

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取委托人数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, true,
                UIContext.Current.UserCode, null, null);

            return View(customers);
        }

        /// <summary>
        /// 单选回调客户列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList(FormCollection form, string isChecked, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//客户名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); ;
            }
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                if (!String.IsNullOrEmpty(form["isChecked"]) || isChecked == null)
                {//关联Guid串
                    string regionCodes = "";
                    List<CommonService.Model.SysManager.C_Userinfo> UserInfos = new List<CommonService.Model.SysManager.C_Userinfo>();
                    //获取当前用户关联区域
                    Guid userCode = new Guid(Context.UIContext.Current.UserCode.ToString());
                    List<CommonService.Model.SysManager.C_Userinfo_region> userInfoRegionList = _userinfo_areaWCF.GetListByUserinfoCode(userCode);
                    if (userInfoRegionList.Count != 0)
                    {
                        foreach (CommonService.Model.SysManager.C_Userinfo_region userinfoRegion in userInfoRegionList)
                        {
                            regionCodes += userinfoRegion.C_Region_code + ",";
                        }
                        regionCodes = regionCodes != "" ? regionCodes.Substring(0, regionCodes.Length - 1) : Guid.Empty.ToString();
                    }
                    string ischeck = "";
                    if (isChecked != null)
                    {
                        ischeck = form["isChecked"].Trim();
                    }
                    ViewBag.ischeck = ischeck;
                    if (ischeck != "0" || isChecked == null)
                    {
                        customerConditon.C_Customer_Region_code = regionCodes;
                    }
                    else
                    {
                        customerConditon.C_Customer_Region_code = Guid.Empty.ToString();
                    }
                }
            }
            else
            {
                customerConditon.C_Customer_Region_code = Guid.Empty.ToString();
            }
            customerConditon.C_Customer_businessType = Convert.ToInt32(CustomerBusiness.客户);
            //客户查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;
            this.PageSize = 8;

            #endregion

            //获取客户总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            return View(customers);
        }

        /// <summary>
        /// 多选回调客户列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MulityCallbackRefList(FormCollection form, string type, string customerCodes, string checkedCustomerCodes, string isChecked, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            int bussineType = Convert.ToInt32(CustomerBusiness.客户);
            string customer_customercodes = "";

            //客户查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//客户名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["C_Customer_businessType"]))
            {//类型查询条件
                bussineType = Int32.Parse(form["C_Customer_businessType"].Trim());
            }
            if (!String.IsNullOrEmpty(type))
            {
                bussineType = Int32.Parse(type);
            }
            if (!String.IsNullOrEmpty(form["C_Customer_codes"]))
            {//关联Guid串
                customer_customercodes = form["C_Customer_codes"].Trim();
            }
            if (!String.IsNullOrEmpty(customerCodes))
            {
                customer_customercodes = customerCodes;
            }
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                if (!String.IsNullOrEmpty(form["isChecked"]) || isChecked == null)
                {//关联Guid串
                    string regionCodes = "";
                    List<CommonService.Model.SysManager.C_Userinfo> UserInfos = new List<CommonService.Model.SysManager.C_Userinfo>();
                    //获取当前用户关联区域
                    Guid userCode = new Guid(Context.UIContext.Current.UserCode.ToString());
                    List<CommonService.Model.SysManager.C_Userinfo_region> userInfoRegionList = _userinfo_areaWCF.GetListByUserinfoCode(userCode);
                    if (userInfoRegionList.Count != 0)
                    {
                        foreach (CommonService.Model.SysManager.C_Userinfo_region userinfoRegion in userInfoRegionList)
                        {
                            regionCodes += userinfoRegion.C_Region_code + ",";
                        }
                        regionCodes = regionCodes != "" ? regionCodes.Substring(0, regionCodes.Length - 1) : Guid.Empty.ToString();
                    }
                    string ischeck = "";
                    if (isChecked != null)
                    {
                        ischeck = form["isChecked"].Trim();
                    }

                    ViewBag.ischeck = ischeck;
                    if (ischeck != "0")
                    {//查看当前用户关联区域内的客户
                        customerConditon.C_Customer_Region_code = regionCodes;
                    }
                    else
                    {//查看全部客户
                        customerConditon.C_Customer_Region_code = Guid.Empty.ToString();
                    }
                }
            }
            else
            {
                customerConditon.C_Customer_Region_code = Guid.Empty.ToString();
            }

            if (bussineType == Convert.ToInt32(CustomerBusiness.客户))
            {//只加载客户信息
                customerConditon.C_Customer_businessType = Convert.ToInt32(CustomerBusiness.客户);
            }
            else if (bussineType == Convert.ToInt32(CustomerBusiness.委托人))
            {//客户关联委托人
                //
                customerConditon.C_Customer_businessType = bussineType;
                if (customerCodes != "")
                {
                    customerConditon.C_Customer_reldatatype = 3;
                    customerConditon.C_Customer_relcodes = "," + customerCodes + ",";
                }
            }


            this.AddressUrlParameters = "?type=" + bussineType + "&customerCodes=" + customer_customercodes;

            //客户查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;
            ViewBag.BussinessType = bussineType;
            ViewBag.Customer_customercodes = customer_customercodes;
            ViewBag.checkedCustomerCodes = checkedCustomerCodes;
            ViewBag.customerCodes = customerCodes;
            this.PageSize = 8;

            #endregion

            //获取客户总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            return View(customers);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="clientCode">委托人Guid(关联Guid)</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string clientCode, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//客户名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["C_Customer_code"]))
            {//委托人Guid查询条件
                customerConditon.C_Customer_code = new Guid(form["C_Customer_code"].Trim());
            }
            if (!String.IsNullOrEmpty(clientCode))
            {
                customerConditon.C_Customer_code = new Guid(clientCode);
            }
            if (customerConditon.C_Customer_code != null)
            {
                this.AddressUrlParameters = "?clientCode=" + customerConditon.C_Customer_code;
            }

            customerConditon.C_Customer_reldatatype = 2;//委托人关联客户数据

            //客户查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;

            #endregion

            //获取客户总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, true,
                UIContext.Current.UserCode, null, null);//第二个参数为true，则表示无权限控制，获取所有关连委托人的客户

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, true,
                UIContext.Current.UserCode, null, null);//第二个参数为true，则表示无权限控制，获取所有关连委托人的客户

            return View(customers);
        }

        #region 自定义表单普通编辑页面所用Callback带回
        /// <summary>
        /// 单选回调法院列表(自定义表单调用)
        /// </summary>
        /// <param name="form">查询表单</param>
        /// <param name="lookupgroup">单选弹出分组</param>
        /// <param name="propertyValueCode">表单属性值Guid</param>
        /// <param name="mappingField">映射字段(这个字段值要保存到属性值表中"值字段")</param>
        /// <param name="mappingFieldName">映射字段显示字段(只用来做界面显示)</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList_CustomerForm(FormCollection form, string lookupgroup, string propertyValueCode, string mappingField, string mappingFieldName, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//客户名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); ;
            }
            customerConditon.C_Customer_businessType = Convert.ToInt32(CustomerBusiness.客户);
            //客户查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;
            this.PageSize = 8;

            #endregion
            #region 参照配置条件
            string _lookupgroup = String.Empty;
            string _propertyValueCode = String.Empty;
            string _mappingField = String.Empty;
            string _mappingFieldName = String.Empty;

            if (!String.IsNullOrEmpty(form["lookupgroup"]))
            {
                _lookupgroup = form["lookupgroup"];
            }
            if (!String.IsNullOrEmpty(form["propertyValueCode"]))
            {
                _propertyValueCode = form["propertyValueCode"];
            }
            if (!String.IsNullOrEmpty(lookupgroup))
            {
                _lookupgroup = lookupgroup;
            }
            if (!String.IsNullOrEmpty(propertyValueCode))
            {
                _propertyValueCode = propertyValueCode;
            }
            ViewBag.Lookupgroup = _lookupgroup;
            ViewBag.PropertyValueCode = _propertyValueCode;
            ViewBag.MappingField = _mappingField;
            ViewBag.MappingFieldName = _mappingFieldName;

            this.AddressUrlParameters = "?lookupgroup=" + _lookupgroup;//加入地址栏条件
            this.AddressUrlParameters = this.AddressUrlParameters + "&propertyValueCode=" + _propertyValueCode;
            #endregion

            //获取客户总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            return View(customers);
        }

        #endregion


        #region 自定义表单列表编辑页面所用Callback带回
        /// <summary>
        /// 单选回调法院列表(自定义表单调用)
        /// </summary>
        /// <param name="form">查询表单</param>
        /// <param name="lookupgroup">单选弹出分组</param>
        /// <param name="rebuildProperty">重组表单属性</param>
        /// <param name="mappingField">映射字段(这个字段值要保存到属性值表中"值字段")</param>
        /// <param name="mappingFieldName">映射字段显示字段(只用来做界面显示)</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList_CustomerForm_List(FormCollection form, string lookupgroup, string rebuildProperty, string mappingField, string mappingFieldName, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//客户名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); ;
            }
            customerConditon.C_Customer_businessType = Convert.ToInt32(CustomerBusiness.客户);
            //客户查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;
            this.PageSize = 8;

            #endregion
            #region 参照配置条件
            string _lookupgroup = String.Empty;
            string _rebuildProperty = String.Empty;
            string _mappingField = String.Empty;
            string _mappingFieldName = String.Empty;

            if (!String.IsNullOrEmpty(form["lookupgroup"]))
            {
                _lookupgroup = form["lookupgroup"];
            }
            if (!String.IsNullOrEmpty(form["rebuildProperty"]))
            {
                _rebuildProperty = form["rebuildProperty"];
            }
            if (!String.IsNullOrEmpty(lookupgroup))
            {
                _lookupgroup = lookupgroup;
            }
            if (!String.IsNullOrEmpty(rebuildProperty))
            {
                _rebuildProperty = rebuildProperty;
            }
            ViewBag.Lookupgroup = _lookupgroup;
            ViewBag.RebuildProperty = _rebuildProperty;
            ViewBag.MappingField = _mappingField;
            ViewBag.MappingFieldName = _mappingFieldName;

            this.AddressUrlParameters = "?lookupgroup=" + _lookupgroup;//加入地址栏条件
            this.AddressUrlParameters = this.AddressUrlParameters + "&rebuildProperty=" + _rebuildProperty;
            #endregion

            //获取客户总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            return View(customers);
        }

        #endregion

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //客户类型参数集合
            List<CommonService.Model.C_Parameters> CustomerTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户类型));
            ViewBag.CustomerTypes = CustomerTypes;
            //行业参数集合
            List<CommonService.Model.C_Parameters> Industrys = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.行业));
            ViewBag.Industrys = Industrys;
            //客户来源参数集合
            List<CommonService.Model.C_Parameters> CustomerSources = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户来源));
            ViewBag.CustomerSources = CustomerSources;
            //客户级别参数集合
            List<CommonService.Model.C_Parameters> CustomerLevels = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户级别));
            ViewBag.CustomerLevels = CustomerLevels;
            //是否签约客户状态参数集合
            List<CommonService.Model.C_Parameters> IsSignedStates = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.是否签约客户));
            ViewBag.IsSignedStates = IsSignedStates;
            //签约客户状态参数集合
            List<CommonService.Model.C_Parameters> SignedStates = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.签约客户状态));
            ViewBag.SignedStates = SignedStates;
            //客户忠诚度参数集合
            List<CommonService.Model.C_Parameters> CustomerLoyaltys = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户忠诚度));
            ViewBag.CustomerLoyaltys = CustomerLoyaltys;
            //客户状态参数集合
            List<CommonService.Model.C_Parameters> State = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户状态));
            ViewBag.State = State;
            //客户类别参数集合
            List<CommonService.Model.C_Parameters> Category = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户类别));
            ViewBag.Category = Category;
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        /// <param name="customer">客户对象</param>
        private void InitializationPageParameter(CommonService.Model.C_Customer customer)
        {
            //客户类型参数集合
            CommonService.Model.C_Parameters CustomerType = _parameterWCF.GetModel(customer.C_Customer_type.Value);
            ViewBag.CustomerType = CustomerType;
            //行业参数集合
            CommonService.Model.C_Parameters Industry = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_industryCode == null)
            {
                ViewBag.Industry = Industry;
            }
            else
            {
                Industry = _parameterWCF.GetModel(customer.C_Customer_industryCode.Value);
                ViewBag.Industry = Industry;
            }
            //客户来源参数集合
            CommonService.Model.C_Parameters CustomerSource = _parameterWCF.GetModel(customer.C_Customer_source.Value);
            ViewBag.CustomerSource = CustomerSource;
            //客户级别参数集合
            CommonService.Model.C_Parameters CustomerLevel = _parameterWCF.GetModel(customer.C_Customer_level.Value);
            ViewBag.CustomerLevel = CustomerLevel;
            //是否签约客户状态参数集合
            CommonService.Model.C_Parameters IsSignedState = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_isSignedState == null)
            {
                ViewBag.IsSignedState = IsSignedState;
            }
            else
            {
                IsSignedState = _parameterWCF.GetModel(customer.C_Customer_isSignedState.Value);
                ViewBag.IsSignedState = IsSignedState;
            }
            //签约客户状态参数集合
            CommonService.Model.C_Parameters SignedState = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_signedState == null)
            {
                ViewBag.SignedState = SignedState;
            }
            else
            {
                SignedState = _parameterWCF.GetModel(customer.C_Customer_signedState.Value);
                ViewBag.SignedState = SignedState;
            }
            //客户忠诚度参数集合
            CommonService.Model.C_Parameters CustomerLoyalty = _parameterWCF.GetModel(customer.C_Customer_loyalty.Value);
            ViewBag.CustomerLoyalty = CustomerLoyalty;
            //客户状态参数集合
            CommonService.Model.C_Parameters State = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_State == null)
            {
                ViewBag.State = State;
            }
            else
            {
                State = _parameterWCF.GetModel(customer.C_Customer_State.Value);
                ViewBag.State = State;
            }
            //客户类别参数集合
            CommonService.Model.C_Parameters Category = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_Category == null)
            {
                ViewBag.Category = Category;
            }
            else
            {
                Category = _parameterWCF.GetModel(customer.C_Customer_Category.Value);
                ViewBag.Category = Category;
            }
        }

        /// <summary>
        /// 启动客户任务
        /// </summary>
        /// <returns></returns>
        public ActionResult StartCustomerTask(string customerCode)
        {
            CommonService.Model.C_Customer customer = _customerWCF.Get(new Guid(customerCode));
            List<CommonService.Model.FlowManager.P_Business_flow> fLists = _bussinessFlowWCF.GetListByFkCode(new Guid(customerCode));
            if (fLists.Count == 0)
            {
                return Json(TipHelper.JsonData("请先配置流程！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            else
            {
                if (customer.C_Customer_goingStatus == Convert.ToInt32(BusinessFlowStatus.未开始))
                {
                    bool isUpdateSuccess = _customerWCF.StartTask(new Guid(customerCode), UIContext.Current.UserCode.Value);
                    if (isUpdateSuccess)
                    {
                        //保存成功提示固定写法
                        return Json(TipHelper.JsonData("成功启动客户任务！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
                    }
                    else
                    {
                        //保存失败固定写法
                        return Json(TipHelper.JsonData("启动客户任务失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                    }
                }
                else
                {
                    return Json(TipHelper.JsonData("不可重复启动！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }

            }
        }
        /// <summary>
        /// 修改客户信息table页签(编辑操作)
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateTableDetails(string CustomerCode)
        {
            ViewBag.CustomerCode = CustomerCode;
            #region 权限
            this.InitializationButtonsPower();
            #endregion
            return View();
        }

        /// <summary>
        /// 修改客户基本信息table页签
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateCustomerTableDetails(string CustomerCode)
        {
            ViewBag.CustomerCode = CustomerCode;
            #region 权限
            this.InitializationButtonsPower();
            #endregion
            return View();
        }

        #region 用户所属部门岗位

        /// <summary>
        /// 用户所属部门
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Guid? GetOrgCode(FormCollection form)
        {
            Guid? orgCode = null;
            //所属部门Guid
            if (!String.IsNullOrEmpty(form["orgCode"]))
            {
                orgCode = new Guid(form["orgCode"]);
            }
            if (Request.QueryString["orgCode"] != null)
            {
                orgCode = new Guid(Request.QueryString["orgCode"]);
            }
            if (orgCode != null)
                this.AddressUrlParameters += "&orgCode=" + orgCode;
            ViewBag.OrgCode = orgCode;

            return orgCode;
        }
        /// <summary>
        /// 用户所属岗位
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Guid? GetPostCode(FormCollection form)
        {
            Guid? postCode = null;

            //所属岗位Guid
            if (!String.IsNullOrEmpty(form["postCode"]))
            {
                postCode = new Guid(form["postCode"]);
            }
            if (Request.QueryString["postCode"] != null)
            {
                postCode = new Guid(Request.QueryString["postCode"]);
            }
            if (postCode != null)
                this.AddressUrlParameters += "&postCode=" + postCode;
            ViewBag.PostCode = postCode;

            return postCode;
        }
        /// <summary>
        /// 获取所属岗位组
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Guid? GetPostGroupCode(FormCollection form)
        {
            Guid? postGroupCode = null;

            //所属岗位组
            if (!String.IsNullOrEmpty(form["postGroupCode"]))
            {
                postGroupCode = new Guid(form["postGroupCode"]);
            }
            if (Request.QueryString["postGroupCode"] != null)
            {
                postGroupCode = new Guid(Request.QueryString["postGroupCode"]);
            }
            if (postGroupCode != null)
                this.AddressUrlParameters += "&postGroupCode=" + postGroupCode;
            ViewBag.PostGroupCode = postGroupCode;

            return postGroupCode;
        }

        #endregion
    }
}