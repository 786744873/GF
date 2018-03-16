using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BaseData.Controllers
{
    /// <summary>
    /// 委托人控制器
    /// </summary>
    public class ClientController : BaseController
    {
        private readonly ICommonService.IC_Customer _customerWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Customer_Customer _customerClientWCF;
        private readonly ICommonService.IC_Customer_Region _customerRegionWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
        public ClientController()
        {
            #region 服务初始化
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _customerClientWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Customer>("CustomerClientWCF");
            _customerRegionWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Region>("Customer_RegionWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            #endregion
        }

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
            //创建初始化组委托人实体
            CommonService.Model.C_Customer customer = new CommonService.Model.C_Customer();
            customer.C_Customer_name = "";
            customer.C_Customer_code = Guid.NewGuid();
            customer.C_Customer_isDelete = false;
            customer.C_Customer_creator = Context.UIContext.Current.UserCode;
            customer.C_Customer_createTime = DateTime.Now;
            customer.C_Customer_businessType = Convert.ToInt32(CustomerBusiness.委托人);
            customer.C_Customer_yearTurnover = 0.00M;
            customer.C_Customer_consultant = Context.UIContext.Current.UserCode;
            customer.C_Customer_consultant_name = Context.UIContext.Current.UserName;
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
            return View("Create", customer);
        }

        /// <summary>
        /// tab 页签
        /// </summary>
        /// <param name="customerCode">委托人Guid</param>
        /// <returns></returns>
        public ActionResult TabDetails(string customerCode)
        {
            ViewBag.CustomerCode = customerCode;
            return View();
        }

        /// <summary>
        /// 委托人 tab 页签
        /// </summary>
        /// <param name="customerCode">委托人Guid</param>
        /// <returns></returns>
        public ActionResult ClientTabDetails(string customerCode)
        {
            ViewBag.CustomerCode = customerCode;
            return View();
        }

        /// <summary>
        /// 委托人信息详情
        /// </summary>
        /// <param name="customerCode">委托人Guid</param>
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
            {//判断委托人是否存在
                return Json(TipHelper.JsonData("此委托人名称已存在！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
            {//销售顾问赋值
                customer.C_Customer_consultant = new Guid(form["mainLawyerlookup.Code"].Trim());
            }
            if (!String.IsNullOrEmpty(form["responsibleDeptlookup.Code"]))
            {//负责部门
                customer.C_Customer_responsibleDept = new Guid(form["responsibleDeptlookup.Code"].Trim());
            }

            #region 关联区域

            List<CommonService.Model.C_Customer_Region> customerRegionList = new List<CommonService.Model.C_Customer_Region>();
            string regionCodeStr = Guid.Empty.ToString();
            if (!String.IsNullOrEmpty(form["regionlookup.Code"]))
            {
                regionCodeStr = form["regionlookup.Code"];
            }
            string[] regionCodes = regionCodeStr.Split(',');
            foreach (var regionCode in regionCodes)
            {
                CommonService.Model.C_Customer_Region customerRegion = new CommonService.Model.C_Customer_Region();
                customerRegion.C_Customer_Region_customer = customer.C_Customer_code.Value;
                customerRegion.C_Customer_Region_relRegion = new Guid(regionCode);
                customerRegion.C_Customer_Region_isDelete = 0;
                customerRegion.C_Customer_Region_creator = Context.UIContext.Current.UserCode;
                customerRegion.C_Customer_Region_createTime = DateTime.Now;

                customerRegionList.Add(customerRegion);
            }
            _customerRegionWCF.OperateList(customerRegionList);

            #endregion

            //服务方法调用
            int customerId = 0;

            if (customer.C_Customer_id > 0)
            {//修改
                bool isUpdateSuccess = _customerWCF.Update(customer);
                if (isUpdateSuccess)
                {
                    customerId = customer.C_Customer_id;
                }
            }
            else
            {//添加
                customer.C_Customer_createTime = DateTime.Now;
                customerId = _customerWCF.Add(customer);
                #region 关联客户
                if (customer.C_Customer_relcode != null)
                {
                    CommonService.Model.C_Customer_Customer customerClient = new CommonService.Model.C_Customer_Customer();
                    customerClient.C_Customer_Customer_customer = customer.C_Customer_relcode;
                    customerClient.C_Customer_Customer_relCustomer = customer.C_Customer_code;
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
                    return Json(TipHelper.JsonData("保存委托人信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存委托人信息成功", "/baseData/client/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存委托人信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存委托人信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
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
                return Json(TipHelper.JsonData("删除委托人信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除委托人信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 关联委托人信息
        /// </summary>
        /// <param name="c_Clients_codes">委托人Guid串，逗号隔开</param>
        /// <param name="relationCode">关联Guid(如客户Guid)</param>
        /// <returns></returns>
        public ActionResult RelationClient(string c_Clients_codes, string relationCode)
        {
            bool isSuccess = false;
            string[] client_codes = c_Clients_codes.Split(',');

            for (int i = 0; i < client_codes.Length; i++)
            {
                if (!String.IsNullOrEmpty(client_codes[i]))
                {
                    CommonService.Model.C_Customer_Customer customerClient = new CommonService.Model.C_Customer_Customer();
                    customerClient.C_Customer_Customer_customer = new Guid(relationCode);
                    customerClient.C_Customer_Customer_relCustomer = new Guid(client_codes[i]);
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
        /// 删除关联委托人信息
        /// </summary>
        /// <param name="relationCode">关联Guid（如客户Guid）</param>
        /// <param name="clientCode">委托人Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteCustomerCustomer(string relationCode,string clientCode)
        {
            bool isSuccess = _customerClientWCF.Delete(new Guid(relationCode),new Guid(clientCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除关联委托人信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除关联委托人信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
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


            //委托人查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//客户名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); 
            }
            customerConditon.C_Customer_businessType = Convert.ToInt32(CustomerBusiness.委托人);
            if (!String.IsNullOrEmpty(form["consultantlookup.Code"]))
            {//专业顾问
                customerConditon.C_Customer_consultant = new Guid(form["consultantlookup.Code"]);
                customerConditon.C_Customer_consultant_name = form["consultantlookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["C_Region_code"]) && (form["C_Region_code"].ToString()) != "全部")
            {//区域
                customerConditon.C_Customer_Region_code = form["C_Region_code"];
            }
            else {
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

            //获取委托人总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取委托人数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(customers);
        }
        #region 数据导出功能
        public FileResult Export(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //委托人查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//委托人名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); ;
            }
            customerConditon.C_Customer_businessType = Convert.ToInt32(CustomerBusiness.委托人);
            //委托人查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;

            #endregion

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取案件数据信息
            List<CommonService.Model.C_Customer> checkList = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", 1, 1000000, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

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

            row1.CreateCell(0).SetCellValue("委托人名称");
            row1.CreateCell(1).SetCellValue("委托人级别");
            row1.CreateCell(2).SetCellValue("委托人类型");
            row1.CreateCell(3).SetCellValue("委托人来源");
            row1.CreateCell(4).SetCellValue("委托人忠诚度");
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
                rowtemp.CreateCell(5).SetCellValue(checkList[i].C_Customer_consultant_name.ToString());
                rowtemp.CreateCell(6).SetCellValue(checkList[i].C_Customer_lastContactDate.ToString());
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
            string fileName = "委托人列表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion
        /// <summary>
        /// 关联列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="customerCode">客户Guid</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult RelList(FormCollection form, string customerCode, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //委托人查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//委托人名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["C_Customer_code"]))
            {//客户Guid查询条件
                customerConditon.C_Customer_code = new Guid(form["C_Customer_code"].Trim());
            }
            if (!String.IsNullOrEmpty(customerCode))
            {
                customerConditon.C_Customer_code = new Guid(customerCode);
            }
            if (customerConditon.C_Customer_code != null)
            {
                this.AddressUrlParameters = "?customerCode=" + customerConditon.C_Customer_code;
            }

            customerConditon.C_Customer_reldatatype = 1;//客户关联委托人数据
            customerConditon.C_Customer_Region_code = Guid.Empty.ToString();//关联区域

            //委托人查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;

            #endregion

            //获取委托人总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取委托人数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(customers);
        }

        /// <summary>
        /// 多选全部委托人
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
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 17;

            //获取委托人数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            return View(customers);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="customerCode">客户Guid(关联Guid)</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string customerCode,  int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //委托人查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//委托人名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["C_Customer_code"]))
            {//客户Guid查询条件
                customerConditon.C_Customer_code = new Guid(form["C_Customer_code"].Trim());
            }
            if (!String.IsNullOrEmpty(customerCode))
            {
                customerConditon.C_Customer_code = new Guid(customerCode);
            }
            if (customerConditon.C_Customer_code != null)
            {
                this.AddressUrlParameters = "?customerCode=" + customerConditon.C_Customer_code;
            }

            customerConditon.C_Customer_reldatatype = 1;//客户关联委托人数据

            //委托人查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;

            #endregion

            //获取委托人总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取委托人数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            return View(customers);
        }

        /// <summary>
        /// 单选回调委托人列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SingleCallbackRefList(FormCollection form, string customerCode, string isChecked, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //委托人查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//委托人名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["C_Customer_code"]))
            {//客户Guid查询条件
                customerConditon.C_Customer_code = new Guid(form["C_Customer_code"].Trim());
            }
            if (!String.IsNullOrEmpty(customerCode))
            {
                customerConditon.C_Customer_code = new Guid(customerCode);
            }
            if (customerConditon.C_Customer_code != null)
            {
                this.AddressUrlParameters = "?customerCode=" + customerConditon.C_Customer_code;
            }
            if (!String.IsNullOrEmpty(form["isChecked"])||isChecked==null)
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
                if (ischeck == "1" || isChecked == null)
                {
                    customerConditon.C_Customer_Region_code = regionCodes;
                }
                else
                {
                    customerConditon.C_Customer_Region_code = Guid.Empty.ToString();
                }
            }
            //customerConditon.C_Customer_reldatatype = 1;//客户关联委托人数据

            //委托人查询模型传递到前端视图中
            ViewBag.CustomerConditon = customerConditon;
            this.PageSize = 8;
            #endregion

            //获取委托人总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取委托人数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            return View(customers);
        }
        /// <summary>
        /// 修改委托人table页
        /// </summary>
        /// <param name="clientCode"></param>
        /// <returns></returns>
        public ActionResult UpdateTableDeatils(string customerCode)
        {
            ViewBag.customerCode = customerCode;
            return View();
        }
        /// <summary>
        /// 修改委托人table页
        /// </summary>
        /// <param name="clientCode"></param>
        /// <returns></returns>
        public ActionResult ClientTableDeatils(string customerCode)
        {
            ViewBag.customerCode = customerCode;
            return View();
        }
        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //委托人类型参数集合
            List<CommonService.Model.C_Parameters> CustomerTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户类型));
            ViewBag.CustomerTypes = CustomerTypes;
            //行业参数集合
            List<CommonService.Model.C_Parameters> Industrys = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.行业));
            ViewBag.Industrys = Industrys;
            //委托人来源参数集合
            List<CommonService.Model.C_Parameters> CustomerSources = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户来源));
            ViewBag.CustomerSources = CustomerSources;
            //委托人级别参数集合
            List<CommonService.Model.C_Parameters> CustomerLevels = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户级别));
            ViewBag.CustomerLevels = CustomerLevels;
            //是否签约委托人状态参数集合
            List<CommonService.Model.C_Parameters> IsSignedStates = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.是否签约客户));
            ViewBag.IsSignedStates = IsSignedStates;
            //签约委托人状态参数集合
            List<CommonService.Model.C_Parameters> SignedStates = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.签约客户状态));
            ViewBag.SignedStates = SignedStates;
            //委托人忠诚度参数集合
            List<CommonService.Model.C_Parameters> CustomerLoyaltys = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户忠诚度));
            ViewBag.CustomerLoyaltys = CustomerLoyaltys;
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        /// <param name="customer">委托人对象</param>
        private void InitializationPageParameter(CommonService.Model.C_Customer customer)
        {
            //委托人类型参数集合
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
            //委托人来源参数集合
            CommonService.Model.C_Parameters CustomerSource = _parameterWCF.GetModel(customer.C_Customer_source.Value);
            ViewBag.CustomerSource = CustomerSource;
            //委托人级别参数集合
            CommonService.Model.C_Parameters CustomerLevel = _parameterWCF.GetModel(customer.C_Customer_level.Value);
            ViewBag.CustomerLevel = CustomerLevel;
            //是否签约委托人状态参数集合
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
            //签约委托人状态参数集合
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
            //委托人忠诚度参数集合
            CommonService.Model.C_Parameters CustomerLoyalty = _parameterWCF.GetModel(customer.C_Customer_loyalty.Value);
            ViewBag.CustomerLoyalty = CustomerLoyalty;
        }
    }
}