using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Portal.Areas.IndividuationForm.Controllers
{
    /// <summary>
    /// 诉讼方案表单(个性化)
    /// </summary>
    public class LegalPlanFormController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.CustomerForm.IF_Form _formWCF;
        private readonly ICommonService.CustomerForm.IF_FormProperty _formPropertyWCF;
        private readonly ICommonService.CustomerForm.IF_FormPropertyValue _formPropertyValueWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;

        public LegalPlanFormController()
        {
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _formWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_Form>("FormWCF");
            _formPropertyWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormProperty>("FormPropertyWCF");
            _formPropertyValueWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormPropertyValue>("FormPropertyValueWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
        }

        //
        // GET: /IndividuationForm/LegalPlanForm/
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
        /// 保存
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult SaveHeadItems(FormCollection form)
        {
            bool isSaveSuccess = false;
            string fFormCode = form["fFormCode"];//表单Guid
            string businessFlowCode = form["businessFlowCode"];//业务流程Guid
            string businessFlowFormCode = form["businessFlowFormCode"];//业务流程表单关联Guid       
            string fkType = form["fkType"];//流程类型(案件或者商机类型)

            string formKey = String.Empty;
            DateTime now = DateTime.Now;

            #region 处理虚拟属性数量(虚拟属性不会做数据库处理)
            int virtualPropertyCount = 0;//虚拟属性数量
            for (int i = 0; i < form.AllKeys.Length; i++)
            {
                formKey = form.AllKeys[i];
                if (formKey.StartsWith("virtualField_"))
                {
                    virtualPropertyCount++;
                }
            }
            #endregion

            #region 处理表单头属性值
            int headPropertyCount = 0;//单头属性数量
            bool isFirsLoadCheckBoxText = true;//是否首次加载 Checkbox Text 组合控件
            List<CommonService.Model.Customer.V_FormPropertyValue> V_FormPropertyValues = new List<CommonService.Model.Customer.V_FormPropertyValue>();
            for (int i = 0; i < form.AllKeys.Length; i++)
            {
                formKey = form.AllKeys[i];
                if (formKey.StartsWith("formproperty_"))
                {//表明为正规自定义表单属性
                    string[] formKeyGroup = formKey.Split('_');
                    if (formKeyGroup.Length == 3)
                    {//代表 普通表单元素(文本框，日期框，单选按钮，下拉框，复选框)
                        CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();
                        //这里表单属性值Id之所以这么赋值，是因为 UI 中 Form 的"表单元素 name 值"已关联到了表单属性值Guid
                        propertyValue.FormPropertyValue_Code = new Guid(formKeyGroup[2]);
                        propertyValue.FormPropertyValue_Value = form[formKey];
                        V_FormPropertyValues.Add(propertyValue);
                        headPropertyCount++;
                    }
                    else
                    {//代表 弹出参照UI控件,和自定义checkbox+text组合控件
                        if (Convert.ToInt32(formKeyGroup[1]) == Convert.ToInt32(UiControlType.不严谨单选弹出框))
                        {//这种情况只保存"显示名称"到数据库中
                            if (formKey.Contains(".Code"))
                            {
                                headPropertyCount++;
                                continue;
                            }
                            if (formKey.Contains(".Name"))
                            {
                                CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();
                                //这里表单属性值Guid之所以这么赋值，是因为 UI 中 Form 的"表单元素 name 值"已关联到了表单属性值Guid
                                propertyValue.FormPropertyValue_Code = new Guid(formKeyGroup[2]);
                                propertyValue.FormPropertyValue_Value = form[formKey];
                                V_FormPropertyValues.Add(propertyValue);
                                headPropertyCount++;
                            }
                        }
                        else if (Convert.ToInt32(formKeyGroup[1]) == Convert.ToInt32(UiControlType.单选弹出框))
                        {
                            //这种情况是虚拟属性，只是用来在UI中显示名称的，不需要保存到数据中
                            if (formKey.Contains(".Name"))
                            {
                                headPropertyCount++;
                                continue;
                            }
                            if (formKey.Contains(".Code"))
                            {
                                CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();
                                //这里表单属性值Guid之所以这么赋值，是因为 UI 中 Form 的"表单元素 name 值"已关联到了表单属性值Guid
                                propertyValue.FormPropertyValue_Code = new Guid(formKeyGroup[2]);
                                propertyValue.FormPropertyValue_Value = form[formKey];
                                V_FormPropertyValues.Add(propertyValue);
                                headPropertyCount++;
                            }
                        }
                        else if (Convert.ToInt32(formKeyGroup[1]) == Convert.ToInt32(UiControlType.复选框))
                        {
                            if (formKey.Contains("_checkbox"))
                            {//checkbox+text组合控件
                                if (formKeyGroup.Length == 5)
                                {//跳过这种情况
                                    if (isFirsLoadCheckBoxText)
                                    {
                                        string checkboxFormKey = formKeyGroup[0] + "_" + formKeyGroup[1] + "_" + formKeyGroup[2] + "_" + formKeyGroup[3];
                                        if (form[checkboxFormKey] == null)
                                        {//这种情况是所有复选框都取消了选中状态，在表单里是取不到对应的表单属性值的，故此要把其属性值设置为空
                                            CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();
                                            propertyValue.FormPropertyValue_Code = new Guid(formKeyGroup[2]);
                                            propertyValue.FormPropertyValue_Value = "";
                                            V_FormPropertyValues.Add(propertyValue);
                                        }
                                        isFirsLoadCheckBoxText = false;
                                    }
                                    headPropertyCount++;
                                    continue;
                                }
                                else
                                {
                                    CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();                                  
                                    propertyValue.FormPropertyValue_Code = new Guid(formKeyGroup[2]);
                                    //这个地方的值要拆分处理,格式为：700_10.20&701_201.23
                                    string checkBoxTextValue = String.Empty;
                                    string[] checkBoxValueGroup = form[formKey].Split(',');
                                    for (int k = 0; k < checkBoxValueGroup.Length; k++)
                                    {
                                        checkBoxTextValue += checkBoxValueGroup[k] + "_" + form[formKey + "_" + checkBoxValueGroup[k]] + "&";
                                    }
                                    if (!String.IsNullOrEmpty(checkBoxTextValue))
                                    {
                                        checkBoxTextValue = checkBoxTextValue.Substring(0, checkBoxTextValue.Length-1);
                                    }
                                    propertyValue.FormPropertyValue_Value = checkBoxTextValue;
                                    V_FormPropertyValues.Add(propertyValue);
                                    headPropertyCount++;
                                }                     
                            }
                        }
                    }

                }
            }
            #endregion

            #region 处理 table 数量
            Dictionary<string, int> itemGroup = new Dictionary<string, int>();
            for (int i = 0; i < form.AllKeys.Length; i++)
            {
                if (form.AllKeys[i].StartsWith("itemGroup_"))
                {
                    string itemGroupValue = form[i];
                    itemGroup.Add(itemGroupValue.Split('_')[0], int.Parse(itemGroupValue.Split('_')[1]));
                }
            }
            #endregion

            if (form.AllKeys.Length == (4 + itemGroup.Count + headPropertyCount + virtualPropertyCount))
            {
                return Json(TipHelper.JsonData("请您填写明细信息！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

            #region 处理表单子表属性值
            List<CommonService.Model.CustomerForm.F_FormPropertyValue> FormPropertyValues = new List<CommonService.Model.CustomerForm.F_FormPropertyValue>();//表单属性值集合

            #region 新增时，处理行转列的分组标识
            Dictionary<string, string> rowToColumnGroup = new Dictionary<string, string>();
            for (int i = 0; i < form.AllKeys.Length; i++)
            {
                if (form.AllKeys[i].StartsWith("items_"))
                {
                    string formPropertyName = form.AllKeys[i];//表单属性名称
                    string[] formPropertyNameGroup = formPropertyName.Split('_');
                    if (!rowToColumnGroup.Keys.Contains("items_" + formPropertyNameGroup[1] + "_" + formPropertyNameGroup[2]))
                    {
                        rowToColumnGroup.Add("items_" + formPropertyNameGroup[1] + "_" + formPropertyNameGroup[2], Guid.NewGuid().ToString());
                    }
                }
            }

            #endregion

            foreach (KeyValuePair<string, int> dict in itemGroup)
            {
                for (int i = 0; i < form.AllKeys.Length; i++)
                {
                    if (form.AllKeys[i].StartsWith("items_" + dict.Key + "_"))
                    {
                        /*
                         * 自定义table表单元素属性名称格式："items_"+"父亲属性Guid(即普通子表属性)_"+"行索引_"+"属性字段名称_"+"属性Guid"+"_"+"属性UI类型"(如果对应行数据已保存，则还需要+"_属性值Id")
                         * 通过表单属性名称中是否包含"_属性值Id"来确定操作是新增还是修改
                         **/
                        string formPropertyName = form.AllKeys[i];//表单属性名称
                        string[] formPropertyNameGroup = formPropertyName.Split('_');
                        string rowToColumnKey = "items_" + formPropertyNameGroup[1] + "_" + formPropertyNameGroup[2];
                        if (formPropertyNameGroup.Length == 6)
                        {//新增                           
                            CommonService.Model.CustomerForm.F_FormPropertyValue propertyValue = new CommonService.Model.CustomerForm.F_FormPropertyValue();
                            propertyValue.F_FormPropertyValue_code = Guid.NewGuid();
                            propertyValue.F_FormPropertyValue_form = new Guid(fFormCode);
                            propertyValue.F_FormPropertyValue_formProperty = new Guid(formPropertyNameGroup[4]);
                            propertyValue.F_FormPropertyValue_BusinessFlowFormCode = new Guid(businessFlowFormCode);
                            propertyValue.F_FormPropertyValue_value = form[i];
                            propertyValue.F_FormPropertyValue_isDelete = false;
                            propertyValue.F_FormPropertyValue_creator = Context.UIContext.Current.UserCode;
                            propertyValue.F_FormPropertyValue_createTime = now;
                            propertyValue.F_FormPropertyValue_group = new Guid(rowToColumnGroup[rowToColumnKey]);//行转列分组标识

                            FormPropertyValues.Add(propertyValue);
                        }
                        else if (formPropertyNameGroup.Length == 7)
                        {//这种情况对于普通文本框，单选框，多行文本框，复选框一定为修改;但是对于"弹出对话框"带回的UI控件，一定为新增                           
                            CommonService.Model.CustomerForm.F_FormPropertyValue propertyValue = new CommonService.Model.CustomerForm.F_FormPropertyValue();

                            if (Convert.ToInt32(formPropertyNameGroup[5]) == Convert.ToInt32(UiControlType.不严谨单选弹出框))
                            {//新增
                                if (formPropertyNameGroup[6].Contains(".Code")) continue;
                                propertyValue.F_FormPropertyValue_code = Guid.NewGuid();
                                propertyValue.F_FormPropertyValue_form = new Guid(fFormCode);
                                propertyValue.F_FormPropertyValue_formProperty = new Guid(formPropertyNameGroup[4]);
                                propertyValue.F_FormPropertyValue_BusinessFlowFormCode = new Guid(businessFlowFormCode);
                                propertyValue.F_FormPropertyValue_value = form[i];
                                propertyValue.F_FormPropertyValue_isDelete = false;
                                propertyValue.F_FormPropertyValue_creator = Context.UIContext.Current.UserCode;
                                propertyValue.F_FormPropertyValue_createTime = now;
                                propertyValue.F_FormPropertyValue_group = new Guid(rowToColumnGroup[rowToColumnKey]);//行转列分组标识

                                FormPropertyValues.Add(propertyValue);
                            }
                            else
                            {//修改
                                propertyValue.F_FormPropertyValue_id = int.Parse(formPropertyNameGroup[6]);
                                propertyValue.F_FormPropertyValue_value = form[i];
                                FormPropertyValues.Add(propertyValue);
                            }

                        }
                        else if (formPropertyNameGroup.Length == 8)
                        {//这种情况只针对"弹出对话框"带回的UI控件，一定是修改
                            CommonService.Model.CustomerForm.F_FormPropertyValue propertyValue = new CommonService.Model.CustomerForm.F_FormPropertyValue();
                            if (Convert.ToInt32(formPropertyNameGroup[5]) == Convert.ToInt32(UiControlType.不严谨单选弹出框))
                            {
                                if (formPropertyNameGroup[6].Contains(".Code")) continue;
                            }
                            propertyValue.F_FormPropertyValue_id = int.Parse(formPropertyNameGroup[7]);
                            propertyValue.F_FormPropertyValue_value = form[i];
                            FormPropertyValues.Add(propertyValue);
                        }
                    }
                }

            }
            #endregion

            isSaveSuccess = _formPropertyValueWCF.SaveHeadItemsFormPropertyValue(V_FormPropertyValues, FormPropertyValues, new Guid(fFormCode), new Guid(businessFlowFormCode));

            if (isSaveSuccess)
            {
                return Json(TipHelper.JsonData("保存信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 动态生成单选弹出框(只应用于普通编辑页面中)
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <param name="htmlAttributes">验证信息</param>
        /// <returns></returns>
        public PartialViewResult GenerateSingleCallbackRefList(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue, string htmlAttributes)
        {
            ViewBag.FormPropertyValue = formPropertyValue;
            ViewBag.HtmlAttributes = htmlAttributes;
            return PartialView("SingleCallbackRefList");
        }

        /// <summary>
        /// 动态生成复选框+文本框
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <returns></returns>
        public PartialViewResult GenerateCheckboxText(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue, string htmlAttributes)
        {
            ViewBag.FormPropertyValue = formPropertyValue;
            ViewBag.HtmlAttributes = htmlAttributes;

            int parentId = -1;
            if (!String.IsNullOrEmpty(formPropertyValue.F_FormProperty_dataSource_conditionValue))
            {
                parentId = Convert.ToInt32(formPropertyValue.F_FormProperty_dataSource_conditionValue);
            }
            List<CommonService.Model.C_Parameters> childrenParameters = this.InitializationParameter(parentId);            
            return PartialView("CheckboxTextPartial", childrenParameters);
        }

        /// <summary>
        /// 生成参数名称
        /// </summary>
        /// <param name="paraId">参数Id</param>
        /// <returns></returns>
        public string GenerateParaName(string paraId)
        { 
            string paraName = String.Empty;
            CommonService.Model.C_Parameters Para = _parameterWCF.GetModel(int.Parse(paraId));
            if (Para != null)
            {
                paraName = Para.C_Parameters_name;
            }
            return paraName;
        }


        /// <summary>
        /// 生成主子结构界面的表单(这里专用于生成文书的数据结构)
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public ActionResult CreateDocument(string formCode, string businessFlowFormCode, string businessFlowCode, string fkType)
        {
            CommonService.Model.CustomerForm.F_Form formvalue = _formWCF.Get(new Guid(formCode));
            ViewBag.formCon = formvalue;
            ViewBag.BusinessFlowCode = businessFlowCode;
            ViewBag.FkType = fkType;
            ViewBag.FormCode = formCode;
            ViewBag.BusinessFlowFormCode = businessFlowFormCode;
            int formStatus = Convert.ToInt32(FormStatusEnum.已提交);
            //获取业务流程关联表单
            CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = _businessFlowFormWCF.Get(new Guid(businessFlowFormCode));
            if (businessFlowForm != null)
            {
                formStatus = businessFlowForm.P_Business_flow_form_status.Value;
            }
 
            //获取表单头编辑属性及其属性值
            List<CommonService.Model.CustomerForm.F_FormProperty> editFormPropertys = _formPropertyWCF.GetOAHeadEditFormPropertyValueList(new Guid(formCode), new Guid(businessFlowFormCode));
            ViewBag.EditFormPropertys = editFormPropertys;
            //获取表单明细属性
            List<CommonService.Model.CustomerForm.F_FormProperty> itemFormPropertys = _formPropertyWCF.GetList(new Guid(formCode));
            //获取表单明细属性值
            DataSet itemFormPropertyValues = _formPropertyValueWCF.DynamicLoadCustmerFormListValues(new Guid(formCode), new Guid(businessFlowFormCode));
            ViewBag.DynamicItemFormPropertyValues = itemFormPropertyValues;

            return View(itemFormPropertys);
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        private List<CommonService.Model.C_Parameters> InitializationParameter(int parentId)
        {
            //参数集合
            List<CommonService.Model.C_Parameters> childrenParameters = _parameterWCF.GetChildrenByParentId(parentId);
            if (childrenParameters.Count == 0)
            {
                childrenParameters = new List<CommonService.Model.C_Parameters>();
            }
            return childrenParameters;
        }



	}
}