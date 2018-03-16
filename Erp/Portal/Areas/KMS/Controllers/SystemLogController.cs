using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.KMS.Controllers
{
    public class SystemLogController : BaseController
    {
        private readonly ICommonService.KMS.IK_Kms_Log _kmsLogWCF;
        public SystemLogController()
        {
            #region 服务初始化
            _kmsLogWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Kms_Log>("K_Kms_LogWCF");
            #endregion
        }
        //
        // GET: /KMS/SystemLog/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录日志
        /// </summary>
        /// <returns></returns>
        public ActionResult LogList()
        {
            //查询入口类型
            List<CommonService.Model.KMS.K_Kms_Log> logTypeList = _kmsLogWCF.GetLogType();
            ViewBag.LogTypeList = logTypeList;
            ViewBag.LogType = "";
            return View();
        }

        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxLogList(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Kms_Log Conditon = new CommonService.Model.KMS.K_Kms_Log();

            //string isExecutedSearch = Request.Params.Get("isExecutedSearch");

            //登录类型查询
            string logType = Request.Params.Get("logType");
            if (logType != null && logType != "")
            {
                Conditon.K_Kms_Log_type = logType;
                ViewBag.LogType = logType;
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _kmsLogWCF.GetRecordCount(Conditon);
            //数据信息
            List<CommonService.Model.KMS.K_Kms_Log> knowledge = _kmsLogWCF.GetListByPage(Conditon,
                "K_Kms_Log_id desc", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in knowledge
                         select new[] { 
                 c.K_Kms_Log_id.ToString(),
                 c.K_Kms_Log_usercode.ToString(),
                 c.K_Kms_Log_username,
                 c.K_Kms_Log_type, 
                 c.K_Kms_Log_ip,
                 c.K_Kms_Log_datetime.Value.ToString("yyyy-MM-dd HH:mm:ss")
            };
            //返回json数据
            return Json(
                new
                {
                    sEcho = param.sEcho,
                    iTotalRecords = this.TotalRecordCount,
                    iTotalDisplayRecords = this.TotalRecordCount,
                    aaData = result
                }
            );

            #endregion
        }
	}
}