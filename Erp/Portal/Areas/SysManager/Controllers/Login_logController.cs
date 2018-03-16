using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.SysManager.Controllers
{
    /// <summary>
    /// 系统登录日志
    /// 作者：陈永俊
    /// 日期：2015-6-3 11:57:45
    /// </summary>
    public class Login_logController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Log _LogWCF;
        private readonly ICommonService.IC_Parameters _ParametersWCF;
        //
        // GET: /SysManager/Login_log/
        public Login_logController()
        {
            #region 服务初始化
            _LogWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Log>("LogWCF");
            _ParametersWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
        public ActionResult Index()
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

            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改

            //登录类型
            List<CommonService.Model.C_Parameters> logTypeList = _ParametersWCF.GetChildrenByParentId(Convert.ToInt32(LoginEnum.登录类型));
            ViewBag.LogTypeList = logTypeList;

            //登陆记录查询模型
            CommonService.Model.SysManager.C_Log logConditon = new CommonService.Model.SysManager.C_Log();

            string strWhere = "";
            string logType = "";
            if (!String.IsNullOrEmpty(form["C_Log_Type"]))
            {//登录类型查询条件
                if (form["C_Log_Type"].ToString() != "0")
                {
                    logType = form["C_Log_Type"].Trim().ToString();
                    strWhere = "C_Log_Type=" + logType;
                }
                else
                {
                    logType = "0";
                }
            }
            ViewBag.logType = logType;

            //岗位查询模型传递到前端视图中
            ViewBag.LogConditon = logConditon;

            #endregion

            //获取登陆记录总记录数
            this.TotalRecordCount = _LogWCF.GetRecordCount(strWhere);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取登陆记录数据信息
            List<CommonService.Model.SysManager.C_Log> menus = _LogWCF.GetListByPage(strWhere,
                 "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(menus);
        }
    }
}