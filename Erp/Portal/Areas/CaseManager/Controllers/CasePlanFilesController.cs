using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CaseManager.Controllers
{
    public class CasePlanFilesController : BaseController
    {
        //
        // GET: /CaseManager/CasePlanFiles/
        private readonly ICommonService.IC_Files _filesWCF;
        public CasePlanFilesController()
        {
            #region 服务初始化
            _filesWCF = ServiceProxyFactory.Create<ICommonService.IC_Files>("FilesWCF");
            #endregion
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EvidencesubmittedList(FormCollection form, string type, string casecode, string checkedFileCode, int? page = 1)
        {
            CommonService.Model.C_Files file = new CommonService.Model.C_Files();
            if (!String.IsNullOrEmpty(form["C_Files_name"]))
            {//涉案项目名称查询条件
                file.C_Files_name = form["C_Files_name"].Trim();
            }
            if(!String.IsNullOrEmpty(casecode))
            {
                file.C_Files_link = new Guid(casecode);
            }
            if (!String.IsNullOrEmpty(form["C_Files_link"]))
            {//案件编码查询条件
                file.C_Files_link = new Guid(form["C_Files_link"].Trim());
            }
            ViewBag.type = type;
            ViewBag.fileConditon = file;
            ViewBag.checkedFileCode = checkedFileCode;
            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取涉案项目数据信息
            List<CommonService.Model.C_Files> menu = _filesWCF.GetListByPage(file,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(menu);
        }
	}
}