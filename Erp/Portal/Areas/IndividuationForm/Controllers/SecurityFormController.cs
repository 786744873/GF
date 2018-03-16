using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.IndividuationForm.Controllers
{
    /// <summary>
    /// 保全表单(个性化)
    /// </summary>
    public class SecurityFormController : BaseController
    {
        private readonly ICommonService.CustomerForm.IF_FormPropertyValue _formPropertyValueWCF;

        public SecurityFormController()
        {
            _formPropertyValueWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormPropertyValue>("FormPropertyValueWCF");
        }

        //
        // GET: /IndividuationForm/SecurityForm/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建或者修改Action
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateOrEdit()
        {
            return View();
        }


        /// <summary>
        /// 动态生成个性化被保全人下拉(html串)
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public string GenerateIndividDropDownHtmls(string formCode,string formPropertyCode, string businessFlowFormCode)
        {            
            string dropItems = String.Empty;

            List<CommonService.Model.CustomerForm.F_FormPropertyValue> dataSourceFormPropertyValues = _formPropertyValueWCF.GetCustFormPropertyValues(new Guid(formCode),
                new Guid(formPropertyCode), new Guid(businessFlowFormCode));
            foreach (CommonService.Model.CustomerForm.F_FormPropertyValue dataSourcePropertyValue in dataSourceFormPropertyValues)
            {
                dropItems += "<option value=" + dataSourcePropertyValue.F_FormPropertyValue_code.ToString() + ">" + dataSourcePropertyValue.F_FormPropertyValue_value + "</option>";
            }         

            return dropItems;
        }


	}
}