using Maticsoft.Common;
using CommonService.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BaseData.Controllers
{
    public class CasePlanParametersController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parametersWCF;
        //
        // GET: /BaseData/CasePlanParameters/
        public CasePlanParametersController()
        {
            #region 服务初始化
            _parametersWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(FormCollection form, string type, string casecode,string checkedParametersCode, int? page = 1)
        {
            CommonService.Model.C_Parameters parameter = new CommonService.Model.C_Parameters();
            if (!String.IsNullOrEmpty(form["C_Parameters_name"]))
            {//涉案项目名称查询条件
                parameter.C_Parameters_name = form["C_Parameters_name"].Trim();
            }
            parameter.C_Parameters_parent = Convert.ToInt32(FileBelongTypeEnum.案件);
            ViewBag.type = type;
            ViewBag.checkedParametersCode = checkedParametersCode;
            ViewBag.parameterConditon = parameter;
            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            List<CommonService.Model.C_Parameters> menu = _parametersWCF.GetListByPage(parameter,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(menu);
        }
    }
}