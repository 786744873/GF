using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CustomerForm.Controllers
{
    /// <summary>
    ///表单时间声明表控制器
    ///作者：崔慧栋
    ///日期：2015/06/10
    /// </summary>
    public class FormDateDeclareController : BaseController
    {
        private readonly ICommonService.CustomerForm.IF_FormDateDeclare _formDateDeclareWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.CustomerForm.IF_Form _formWCF;
        public FormDateDeclareController()
        {
            #region 服务初始化
            _formDateDeclareWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormDateDeclare>("FormDateDeclareWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _formWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_Form>("FormWCF");
            #endregion
        }
        //
        // GET: /CustomerForm/FormDateDeclare/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 表单关联所有表单时间Action
        /// </summary>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        public ActionResult FormRelationFormDateDeclareList(string flowCode,string formCode,string type)
        {
            List<CommonService.Model.CustomerForm.F_FormDateDeclare> formDateDeclares;
            if (flowCode == "{flowCode}" && formCode == "{formCode}")
            {
                formDateDeclares = new List<CommonService.Model.CustomerForm.F_FormDateDeclare>();
            }else if(flowCode!="{flowCode}" && formCode=="{formCode}")
            {
                CommonService.Model.FlowManager.P_Flow flow = _flowWCF.GetModel(new Guid(flowCode));
                CommonService.Model.CustomerForm.F_Form form = new CommonService.Model.CustomerForm.F_Form();
                formDateDeclares = _formDateDeclareWCF.GetListByFormCode(new Guid(flowCode), 1);

                ViewBag.codes = flow.P_Flow_code + "," + form.F_Form_code;
                ViewBag.names = flow.P_Flow_name + "-" + form.F_Form_chineseName;
            }
            else
            {
                formCode = formCode.Substring(0, formCode.Length - 2);
                CommonService.Model.FlowManager.P_Flow flow= _flowWCF.GetModel(new Guid(flowCode));
                CommonService.Model.CustomerForm.F_Form form = _formWCF.Get(new  Guid(formCode));
                formDateDeclares = _formDateDeclareWCF.GetListByFormCode(new Guid(formCode),0);

                ViewBag.codes=flow.P_Flow_code+","+form.F_Form_code;
                ViewBag.names = flow.P_Flow_name+"-"+form.F_Form_chineseName;
            }
            ViewBag.type = type;
            return View(formDateDeclares);
        }
	}
}