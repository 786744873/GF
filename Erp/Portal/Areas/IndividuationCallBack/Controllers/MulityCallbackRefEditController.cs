using CommonService.Model.Customer;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.IndividuationCallBack.Controllers
{
    /// <summary>
    /// 个性化多个编辑框带回控制器(多个值带回)
    /// </summary>
    public class MulityCallbackRefEditController : BaseController
    {
        private readonly ICommonService.CustomerForm.IF_FormPropertyValue _formPropertyValueWCF;

        public MulityCallbackRefEditController()
        {
            _formPropertyValueWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormPropertyValue>("FormPropertyValueWCF");
        }

        //
        // GET: /IndividuationCallBack/MulityCallbackRefEdit/
        public override ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 人员编辑框多选Callback带回布局Action(自定义表单调用)
        /// </summary>
        /// <param name="lookupgroup">多选弹出编辑框分组</param>
        /// <param name="propertyValueCode">表单属性值Guid</param>
        /// <returns></returns>
        public ActionResult MulityCallbackRefEdit_PersonForm(string lookupgroup, string propertyValueCode)
        {
            #region 参照配置条件
            string _lookupgroup = String.Empty;
            string _propertyValueCode = String.Empty;
            string _mappingField = String.Empty;
            string _mappingFieldName = String.Empty;

            if (!String.IsNullOrEmpty(lookupgroup))
            {
                _lookupgroup = lookupgroup;
            }
            if (!String.IsNullOrEmpty(propertyValueCode))
            {
                _propertyValueCode = propertyValueCode;
            }
            ViewBag.Lookupgroup = _lookupgroup;
            ViewBag.PropertyValueCode = _propertyValueCode;
            ViewBag.MappingField = _mappingField;
            ViewBag.MappingFieldName = _mappingFieldName;
            #endregion

            #region 把数据库存放的属性值格式，转化为UI界面中容易解析的数据格式
            CommonService.Model.CustomerForm.F_FormPropertyValue FormPropertyValue = _formPropertyValueWCF.Get(new Guid(propertyValueCode));
            List<V_KeyValue> v_KeyValues = new List<V_KeyValue>();
            if (FormPropertyValue != null)
            {
                if (!String.IsNullOrEmpty(FormPropertyValue.F_FormPropertyValue_value))
                {
                    if (FormPropertyValue.F_FormPropertyValue_value.Contains("&"))
                    {
                        string[] propertyValueGroup = FormPropertyValue.F_FormPropertyValue_value.Split('&');
                        string[] keyGroup = propertyValueGroup[0].Split(',');//属性值键组
                        string[] valueGroup = propertyValueGroup[1].Split(',');//属性值值组
                        if (keyGroup.Length == valueGroup.Length)
                        {
                            for (int i = 0; i < keyGroup.Length; i++)
                            {
                                V_KeyValue keyValue = new V_KeyValue();
                                keyValue.Key=keyGroup[i];
                                keyValue.Value = valueGroup[i];

                                v_KeyValues.Add(keyValue);
                            }
                        }
                    }
                }               
            }
            ViewBag.VKeyValue = v_KeyValues;
            #endregion

            return View();
        }
	}
}