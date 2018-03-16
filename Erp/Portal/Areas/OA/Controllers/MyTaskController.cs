using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.OA.Controllers
{
    /// <summary>
    /// 代办任务控制器
    /// </summary>
    public class MyTaskController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.OA.IO_Form _oFormWCF;

        public MyTaskController()
        {
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _oFormWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form>("oFormWCF");
        }

        //
        // GET: /OA/MyTask/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 默认列表Action(菜单超链接打开)
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            InitializationPageParameter();
            return View();
        }

        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxList(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //表单查询模型
            CommonService.Model.OA.O_Form oFormConditon = new CommonService.Model.OA.O_Form();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    oFormConditon.O_Form_f_form_name = title;
                }
                #endregion
            }
        
            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _oFormWCF.GetMyTaskRecordCount(oFormConditon, Context.UIContext.Current.IsPreSetManager, Context.UIContext.Current.UserCode);
            //数据信息
            List<CommonService.Model.OA.O_Form> oForms = _oFormWCF.GetMyTaskListByPage(oFormConditon,
                "O_Form_applyTime Desc", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength, Context.UIContext.Current.IsPreSetManager, Context.UIContext.Current.UserCode);
            //转化数据格式
            var result = from c in oForms
                         select new[] { 
                 c.O_Form_code.Value.ToString(), 
                 c.O_Form_flow==null ? "" : c.O_Form_flow.Value.ToString(), 
                 c.O_Form_f_form_name,
                 c.O_Form_flow_name,
                 c.O_Form_applyPerson_name==null?"": c.O_Form_applyPerson_name,
                 c.O_Form_applyTime==null?"":c.O_Form_applyTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                 c.O_Form_applyStatus_name==null?"":c.O_Form_applyStatus_name 
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

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
 
        }

	}
}