using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maticsoft.Common;
using CommonService.Common;
using Context;
using Portal.Controllers;
using System.IO;

namespace Portal.Areas.BaseData.Controllers
{
    public class PrincipalController : BaseController
    {
        private readonly ICommonService.IC_Principal _principalWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
        private readonly ICommonService.IC_Customer_Region _customerRegionWCF;
        private readonly ICommonService.IC_Customer_Customer _customerClientWCF;
        private readonly ICommonService.IC_Region _regionWCF;
     
        public PrincipalController()
        {
            #region 服务初始化
            _principalWCF = ServiceProxyFactory.Create<ICommonService.IC_Principal>("PrincipalWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            _customerRegionWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Region>("Customer_RegionWCF");
            _customerClientWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Customer>("CustomerClientWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
           
            #endregion
        }

        //
        // GET: /BaseData/Principal/
        public override ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 委托人详细信息
        /// </summary>
        /// <param name="principalCode">委托人GUID</param>
        /// <returns></returns>
        public ActionResult Details(string principalCode)
        {
            CommonService.Model.C_Principal principal = _principalWCF.Get(new Guid(principalCode));
            InitializationPageParameter(principal);
            return View(principal);
        }
        /// <summary>
        /// tab 页签
        /// </summary>
        /// <param name="customerCode">委托人Guid</param>
        /// <returns></returns>
        public ActionResult TabDetails(string principalCode)
        {
            ViewBag.principalCode = principalCode;
            return View();
        }
        /// <summary>
        /// 委托人tab页签
        /// </summary>
        /// <param name="principalCode"></param>
        /// <returns></returns>
        public ActionResult PrincipalTabDetails(string principalCode)
        {
            ViewBag.principalCode = principalCode;
            return View();
        }
        /// <summary>
        /// 查看列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="customerCode">客户Guid(关联Guid)</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string principalCode, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //委托人查询模型
            CommonService.Model.C_Principal principalConditon = new CommonService.Model.C_Principal();

            if (!String.IsNullOrEmpty(form["C_Principal_name"]))
            {//委托人名称查询条件
                principalConditon.C_Principal_name = form["C_Principal_name"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["C_Principal_code"]))
            {//客户Guid查询条件
                principalConditon.C_Principal_code = new Guid(form["C_Principal_code"].Trim());
            }
            if (!String.IsNullOrEmpty(principalCode))
            {
                principalConditon.C_Principal_code = new Guid(principalCode);
            }
            if (principalConditon.C_Principal_code != null)
            {
                this.AddressUrlParameters = "?principalCode=" + principalConditon.C_Principal_code;
            }

            principalConditon.C_Principal_reldatatype = 1;//客户关联委托人数据

            //委托人查询模型传递到前端视图中
            ViewBag.principalConditon = principalConditon;

            #endregion

            //获取委托人总记录数
            this.TotalRecordCount = _principalWCF.GetRecordCount(principalConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取委托人数据信息
            List<CommonService.Model.C_Principal> principal = _principalWCF.GetListByPage(principalConditon,
                "C_Principal_id Asc,T.C_Principal_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(principal);
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
            CommonService.Model.C_Principal principalConditon = new CommonService.Model.C_Principal();

            if (!String.IsNullOrEmpty(form["C_Principal_name"]))
            {//客户名称查询条件
                principalConditon.C_Principal_name = form["C_Principal_name"].Trim();
            }
            principalConditon.C_Principal_businessType = Convert.ToInt32(CustomerBusiness.委托人);
            if (!String.IsNullOrEmpty(form["consultantlookup.Code"]))
            {//专业顾问
                principalConditon.C_Principal_consultant = new Guid(form["consultantlookup.Code"]);
                principalConditon.C_principal_consultant_name = form["consultantlookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["C_Region_code"]) && (form["C_Region_code"].ToString()) != "全部")
            {//区域
                principalConditon.C_principal_Region_code = form["C_Region_code"];
            }
            else
            {
                principalConditon.C_principal_Region_code = Guid.Empty.ToString();
            }
            if (!String.IsNullOrEmpty(form["responsibleDeptlookup.Code"]))
            {//组织架构
                principalConditon.C_Principal_responsibleDept = new Guid(form["responsibleDeptlookup.Code"]);
                principalConditon.C_principal_responsibledept_name = form["responsibleDeptlookup.Name"];
            }

            //客户查询模型传递到前端视图中
            ViewBag.PrincipalConditon = principalConditon;
            #endregion

            //获取委托人总记录数
            this.TotalRecordCount = _principalWCF.GetRecordCount(principalConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取委托人数据信息
            List<CommonService.Model.C_Principal> principal = _principalWCF.GetListByPage(principalConditon,
                "C_Principal_id Asc,T.C_Principal_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(principal);
        }

        
        [HttpGet]
        public ActionResult Create(string relCode)
        {
            InitializationPageParameter();
            //创建初始化组委托人实体
            CommonService.Model.C_Principal principal = new CommonService.Model.C_Principal();
            principal.C_Principal_name = "";
            principal.C_Principal_code = Guid.NewGuid();
            principal.C_Principal_isDelete = false;
            principal.C_Principal_creator = Context.UIContext.Current.UserCode;
            principal.C_Principal_createTime = DateTime.Now;
            principal.C_Principal_businessType = Convert.ToInt32(CustomerBusiness.委托人);
            principal.C_Principal_yearTurnover = 0.00M;
            principal.C_Principal_consultant = Context.UIContext.Current.UserCode;
            principal.C_principal_consultant_name = Context.UIContext.Current.UserName;
            if (!string.IsNullOrEmpty(relCode))
            {
                principal.C_principal_relCode = new Guid(relCode);
            }
            return View(principal);

        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(string principalCode)
        {
            InitializationPageParameter();
            CommonService.Model.C_Principal principal = _principalWCF.Get(new Guid(principalCode));
            return View("Create", principal);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="principalCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string principalCode)
        {
            bool isSuccess = _principalWCF.Delete(new Guid(principalCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除客户信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));

            }
            else
            {
                return Json(TipHelper.JsonData("删除客户信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        #region 数据导出功能
        public FileResult Export(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //委托人查询模型
            CommonService.Model.C_Principal principalConditon = new CommonService.Model.C_Principal();

            if (!String.IsNullOrEmpty(form["C_Principal_name"]))
            {//委托人名称查询条件
                principalConditon.C_Principal_name = form["C_Principal_name"].Trim(); ;
            }
            principalConditon.C_Principal_businessType = Convert.ToInt32(CustomerBusiness.委托人);
            //委托人查询模型传递到前端视图中
            ViewBag.principalConditon = principalConditon;

            #endregion

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取案件数据信息
            List<CommonService.Model.C_Principal> checkList = _principalWCF.GetListByPage(principalConditon,
                "C_Principal_id Asc,T.C_Principal_name Asc", 1, 1000000);

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
            //row1.CreateCell(5).SetCellValue("专业顾问");
            row1.CreateCell(5).SetCellValue("最后接触日期");
            row1.CreateCell(6).SetCellValue("是否签约");
            row1.CreateCell(7).SetCellValue("签约状态");
            row1.CreateCell(8).SetCellValue("备注");
            //....N行

            //将数据逐步写入sheet1各个行
            for (int i = 0; i < checkList.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(checkList[i].C_Principal_name.ToString());

                if (checkList[i].C_Principal_level == 35)
                {
                    rowtemp.CreateCell(1).SetCellValue("普通客户");
                }
                else if (checkList[i].C_Principal_level == 36)
                {
                    rowtemp.CreateCell(1).SetCellValue("重点客户");
                }
                else if (checkList[i].C_Principal_level == 37)
                {
                    rowtemp.CreateCell(1).SetCellValue("战略客户");
                }
                if (checkList[i].C_Principal_type == 23)
                {
                    rowtemp.CreateCell(2).SetCellValue("个体户");
                }
                else if (checkList[i].C_Principal_type == 24)
                {
                    rowtemp.CreateCell(2).SetCellValue("单位");
                }
                else if (checkList[i].C_Principal_type == 25)
                {
                    rowtemp.CreateCell(2).SetCellValue("自然人");
                }
                if (checkList[i].C_Principal_source == 30)
                {
                    rowtemp.CreateCell(3).SetCellValue("内部资源");
                }
                else if (checkList[i].C_Principal_source == 31)
                {
                    rowtemp.CreateCell(3).SetCellValue("网络广告");
                }
                else if (checkList[i].C_Principal_source == 32)
                {
                    rowtemp.CreateCell(3).SetCellValue("电话推广");
                }
                else if (checkList[i].C_Principal_source == 33)
                {
                    rowtemp.CreateCell(3).SetCellValue("老客户推荐");
                }
                else if (checkList[i].C_Principal_source == 34)
                {
                    rowtemp.CreateCell(3).SetCellValue("网站推广");
                }
                if (checkList[i].C_Principal_loyalty == 43)
                {
                    rowtemp.CreateCell(4).SetCellValue("高");
                }
                else if (checkList[i].C_Principal_loyalty == 44)
                {
                    rowtemp.CreateCell(4).SetCellValue("中");
                }
                else if (checkList[i].C_Principal_loyalty == 45)
                {
                    rowtemp.CreateCell(4).SetCellValue("低");
                }
                //rowtemp.CreateCell(5).SetCellValue(checkList[i].C_principal_consultant_name.ToString());
                rowtemp.CreateCell(5).SetCellValue(checkList[i].C_Principal_lastContactDate.ToString());
                if (checkList[i].C_Principal_isSignedState == 38)
                {
                    rowtemp.CreateCell(6).SetCellValue("未签约");
                }
                else if (checkList[i].C_Principal_isSignedState == 39)
                {
                    rowtemp.CreateCell(6).SetCellValue("已签约");
                }
                if (checkList[i].C_Principal_signedState == 40)
                {
                    rowtemp.CreateCell(7).SetCellValue("正常");
                }
                else if (checkList[i].C_Principal_signedState == 41)
                {
                    rowtemp.CreateCell(7).SetCellValue("流失");
                }
                else if (checkList[i].C_Principal_signedState == 42)
                {
                    rowtemp.CreateCell(7).SetCellValue("死亡");
                }
                if (checkList[i].C_principal_remark!=null)
                {
                    rowtemp.CreateCell(8).SetCellValue(checkList[i].C_principal_remark.ToString());
                }
                

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
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.C_Principal principal)
        {
            if (_principalWCF.Exists(principal))
            {//判断委托人是否存在
                return Json(TipHelper.JsonData("此委托人名称已存在！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
            {//销售顾问赋值
                principal.C_Principal_consultant = new Guid(form["mainLawyerlookup.Code"].Trim());
            }
            if (!String.IsNullOrEmpty(form["responsibleDeptlookup.Code"]))
            {//负责部门
                principal.C_Principal_responsibleDept = new Guid(form["responsibleDeptlookup.Code"].Trim());
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
                customerRegion.C_Customer_Region_customer = principal.C_Principal_code.Value;
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

            if (principal.C_Principal_id > 0)
            {//修改
                bool isUpdateSuccess = _principalWCF.Update(principal);
                if (isUpdateSuccess)
                {
                    customerId = principal.C_Principal_id;
                }
            }
            else
            {//添加
                principal.C_Principal_createTime = DateTime.Now;
                customerId = _principalWCF.Add(principal);
                #region 关联客户
                if (principal.C_principal_relCode != null)
                {
                    CommonService.Model.C_Customer_Customer customerClient = new CommonService.Model.C_Customer_Customer();
                    customerClient.C_Customer_Customer_customer = principal.C_principal_relCode;
                    customerClient.C_Customer_Customer_relCustomer = principal.C_Principal_code;
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
        /// 修改委托人table页
        /// </summary>
        /// <param name="clientCode"></param>
        /// <returns></returns>
        public ActionResult UpdateTableDeatils(string principalCode)
        {
            ViewBag.principalCode = principalCode;
            return View();
        }
        /// <summary>
        /// 修改委托人table页
        /// </summary>
        /// <param name="clientCode"></param>
        /// <returns></returns>
        public ActionResult PrincipalTableDeatils(string principalCode)
        {
            ViewBag.principalCode = principalCode;
            return View();
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //客户类型参数集合
            List<CommonService.Model.C_Parameters> PrincipalTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户类型));
            ViewBag.PrincipalTypes = PrincipalTypes;
            //行业参数集合
            List<CommonService.Model.C_Parameters> Industrys = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.行业));
            ViewBag.Industrys = Industrys;
            //客户来源参数集合
            List<CommonService.Model.C_Parameters> PrincipalSources = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户来源));
            ViewBag.PrincipalSources = PrincipalSources;
            //客户级别参数集合
            List<CommonService.Model.C_Parameters> PrincipalLevels = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户级别));
            ViewBag.PrincipalLevels = PrincipalLevels;
            //是否签约客户状态参数集合
            List<CommonService.Model.C_Parameters> IsSignedStates = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.是否签约客户));
            ViewBag.IsSignedStates = IsSignedStates;
            //签约客户状态参数集合
            List<CommonService.Model.C_Parameters> SignedStates = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.签约客户状态));
            ViewBag.SignedStates = SignedStates;
            //客户忠诚度参数集合
            List<CommonService.Model.C_Parameters> PrincipalLoyaltys = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户忠诚度));
            ViewBag.PrincipalLoyaltys = PrincipalLoyaltys;

        }
        /// <summary>
        /// 初始化页面参数
        /// </summary>
        /// <param name="customer">客户对象</param>
        private void InitializationPageParameter(CommonService.Model.C_Principal principal)
        {
            //客户类型参数集合
            CommonService.Model.C_Parameters PrincipalType = _parameterWCF.GetModel(principal.C_Principal_type.Value);
            ViewBag.PrincipalType = PrincipalType;
            //行业参数集合
            CommonService.Model.C_Parameters Industry = new CommonService.Model.C_Parameters();
            if (principal.C_Principal_industryCode == null)
            {
                ViewBag.Industry = Industry;
            }
            else
            {
                Industry = _parameterWCF.GetModel(principal.C_Principal_industryCode.Value);
                ViewBag.Industry = Industry;
            }
            //客户来源参数集合
            CommonService.Model.C_Parameters PrincipalSource = _parameterWCF.GetModel(principal.C_Principal_source.Value);
            ViewBag.PrincipalSource = PrincipalSource;
            //客户级别参数集合
            CommonService.Model.C_Parameters PrincipalLevel = _parameterWCF.GetModel(principal.C_Principal_level.Value);
            ViewBag.PrincipalLevel = PrincipalLevel;
            //是否签约客户状态参数集合
            CommonService.Model.C_Parameters IsSignedState = new CommonService.Model.C_Parameters();
            if (principal.C_Principal_isSignedState == null)
            {
                ViewBag.IsSignedState = IsSignedState;
            }
            else
            {
                IsSignedState = _parameterWCF.GetModel(principal.C_Principal_isSignedState.Value);
                ViewBag.IsSignedState = IsSignedState;
            }
            //签约客户状态参数集合
            CommonService.Model.C_Parameters SignedState = new CommonService.Model.C_Parameters();
            if (principal.C_Principal_signedState == null)
            {
                ViewBag.SignedState = SignedState;
            }
            else
            {
                SignedState = _parameterWCF.GetModel(principal.C_Principal_signedState.Value);
                ViewBag.SignedState = SignedState;
            }
            //客户忠诚度参数集合
            CommonService.Model.C_Parameters PrincipalLoyalty = _parameterWCF.GetModel(principal.C_Principal_loyalty.Value);
            ViewBag.PrincipalLoyalty = PrincipalLoyalty;


        }
        /// <summary>
        /// 客户关联委托人
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
            CommonService.Model.C_Principal principalConditon = new CommonService.Model.C_Principal();

            if (!String.IsNullOrEmpty(form["C_Principal_name"]))
            {//委托人名称查询条件
                principalConditon.C_Principal_name = form["C_Principal_name"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["C_Principal_code"]))
            {//客户Guid查询条件
                principalConditon.C_Principal_code = new Guid(form["C_Principal_code"].Trim());
            }
            if (!String.IsNullOrEmpty(customerCode))
            {
                principalConditon.C_Principal_code = new Guid(customerCode);
            }
            if (principalConditon.C_Principal_code != null)
            {
                this.AddressUrlParameters = "?principalCode=" + principalConditon.C_Principal_code;
            }

            principalConditon.C_Principal_reldatatype = 1;//客户关联委托人数据
            principalConditon.C_principal_Region_code = Guid.Empty.ToString();//关联区域

            //委托人查询模型传递到前端视图中
            ViewBag.PrincipalConditon = principalConditon;

            #endregion

            //获取委托人总记录数
            this.TotalRecordCount = _principalWCF.GetRecordCount(principalConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取委托人数据信息
            List<CommonService.Model.C_Principal> principal = _principalWCF.GetListByPage(principalConditon,
                "C_Principal_id Asc,T.C_Principal_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(principal);
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
            CommonService.Model.C_Principal principalConditon = new CommonService.Model.C_Principal();

            if (!String.IsNullOrEmpty(form["C_Principal_name"]))
            {//委托人名称查询条件
                principalConditon.C_Principal_name = form["C_Principal_name"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["C_Principal_code"]))
            {//客户Guid查询条件
                principalConditon.C_Principal_code = new Guid(form["C_Principal_code"].Trim());
            }
            if (!String.IsNullOrEmpty(relCode))
            {
                principalConditon.C_principal_relCode = new Guid(relCode);
            }
            if (principalConditon.C_principal_relCode != null)
            {
                this.AddressUrlParameters = "?relCode=" + principalConditon.C_principal_relCode;
            }

           
            principalConditon.C_principal_Region_code = Guid.Empty.ToString();//关联区域

            //委托人查询模型传递到前端视图中
            ViewBag.PrincipalConditon = principalConditon;

            #endregion

            //获取委托人总记录数
            this.TotalRecordCount = _principalWCF.GetRecordCount(principalConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取委托人数据信息
            List<CommonService.Model.C_Principal> principal = _principalWCF.GetListByPage(principalConditon,
                "C_Principal_id Asc,T.C_Principal_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(principal);
        }
        /// <summary>
        /// 关联委托人信息
        /// </summary>
        /// <param name="c_Clients_codes">委托人Guid串，逗号隔开</param>
        /// <param name="relationCode">关联Guid(如客户Guid)</param>
        /// <returns></returns>
        public ActionResult RelationClient(string c_Principals_codes, string relationCode)
        {
            bool isSuccess = false;
            string[] principal_codes = c_Principals_codes.Split(',');

            for (int i = 0; i < principal_codes.Length; i++)
            {
                if (!String.IsNullOrEmpty(principal_codes[i]))
                {
                    CommonService.Model.C_Customer_Customer customerClient = new CommonService.Model.C_Customer_Customer();
                    customerClient.C_Customer_Customer_customer = new Guid(relationCode);
                    customerClient.C_Customer_Customer_relCustomer = new Guid(principal_codes[i]);
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
        public ActionResult DeletePrincipalPrincipal(string relationCode, string principalCode)
        {
            bool isSuccess = _customerClientWCF.Delete(new Guid(relationCode), new Guid(principalCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除关联委托人信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除关联委托人信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
    }
}
