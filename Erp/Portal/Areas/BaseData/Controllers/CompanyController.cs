using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BaseData.Controllers
{
    /// <summary>
    /// 客户公司控制器
    /// </summary>
    public class CompanyController : BaseController
    {
        private readonly ICommonService.IC_Company _companyWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        public CompanyController()
        {
            #region 服务初始化
            _companyWCF = ServiceProxyFactory.Create<ICommonService.IC_Company>("CompanyWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }

        //
        // GET: /BaseData/Company/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string customerCode)
        {
            InitializationPageParameter();
            //创建初始化客户公司实体
            CommonService.Model.C_Company company = new CommonService.Model.C_Company();
            company.C_Company_name = "";
            company.C_Company_code = Guid.NewGuid();
            company.C_Company_isDelete = false;
            company.C_Company_isDefault = false;

            if (!String.IsNullOrEmpty(customerCode))
            {
                company.C_Company_customer = new Guid(customerCode);
            }
            company.C_Company_creator = Context.UIContext.Current.UserCode;
            company.C_Company_createTime = DateTime.Now;

            return View(company);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string companyCode)
        {
            InitializationPageParameter();
            CommonService.Model.C_Company company = _companyWCF.Get(new Guid(companyCode));
            return View("Create", company);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.C_Company company)
        {
            //服务方法调用
            int companyId = 0;

            if (company.C_Company_id > 0)
            {//修改
                bool isUpdateSuccess = _companyWCF.Update(company);
                if (isUpdateSuccess)
                {
                    companyId = company.C_Company_id;
                }
            }
            else
            {//添加
                company.C_Company_createTime = DateTime.Now;
                companyId = _companyWCF.Add(company);
            }

            if (companyId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存公司信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存公司信息成功", "/basedata/company/create?customerCode=" + company.C_Company_customer, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存公司信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存公司信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string companyCode)
        {
            bool isSuccess = _companyWCF.Delete(new Guid(companyCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除公司信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除公司信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form,string customerCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户公司查询模型
            CommonService.Model.C_Company companyConditon = new CommonService.Model.C_Company();
            //客户Guid条件(url参数)
            if (!String.IsNullOrEmpty(customerCode))
            {
                companyConditon.C_Company_customer = new Guid(customerCode);
            }          
            if (companyConditon.C_Company_customer!=null)
            {//url参数到地址栏
                this.AddressUrlParameters = "?customerCode=" + companyConditon.C_Company_customer;
            }

            //公司查询模型传递到前端视图中
            ViewBag.CompanyConditon = companyConditon;
            this.PageSize = 13;

            #endregion

            //获取客户公司总记录数
            this.TotalRecordCount = _companyWCF.GetRecordCount(companyConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户公司数据信息
            List<CommonService.Model.C_Company> companys = _companyWCF.GetListByPage(companyConditon,
                "C_Company_createTime Desc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(companys);
        }

        /// <summary>
        /// 查看列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="customerCode">客户Guid</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ViewList(FormCollection form, string customerCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户公司查询模型
            CommonService.Model.C_Company companyConditon = new CommonService.Model.C_Company();
            //客户Guid条件(url参数)
            if (!String.IsNullOrEmpty(customerCode))
            {
                companyConditon.C_Company_customer = new Guid(customerCode);
            }
            if (companyConditon.C_Company_customer != null)
            {//url参数到地址栏
                this.AddressUrlParameters = "?customerCode=" + companyConditon.C_Company_customer;
            }
            this.PageSize = 13;

            #endregion

            //获取客户公司总记录数
            this.TotalRecordCount = _companyWCF.GetRecordCount(companyConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户公司数据信息
            List<CommonService.Model.C_Company> companys = _companyWCF.GetListByPage(companyConditon,
                "C_Company_createTime Desc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(companys);
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //公司性质参数集合
            List<CommonService.Model.C_Parameters> CompanyPropertys = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CompanyEnum.公司性质));
            ViewBag.CompanyPropertys = CompanyPropertys;  
        }

	}
}