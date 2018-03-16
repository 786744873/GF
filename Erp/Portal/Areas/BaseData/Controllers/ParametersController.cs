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
    /// 数据字典控制器
    /// </summary>
    public class ParametersController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parametersWCF;
        private readonly ICommonService.CustomerForm.IF_FormProperty _formPropertyWCF;

        public ParametersController()
        {
            #region 服务初始化
            _parametersWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _formPropertyWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormProperty>("FormPropertyWCF");
            #endregion
        }
        //
        // GET: /BaseData/Parameters/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int? parametersID)
        {
            //创建初始化参数实体
            CommonService.Model.C_Parameters parameters = new CommonService.Model.C_Parameters();
            parameters.C_Parameters_name = "";
            parameters.C_Parameters_order = 1;
            parameters.C_Parameters_parent = parametersID == null ? 0 : parametersID;
            parameters.C_Parameters_isDelete = 0;

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(parameters);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int parametersID)
        {
            CommonService.Model.C_Parameters parameter = _parametersWCF.GetModel(parametersID);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View("Create", parameter);
        }

        public ActionResult List(FormCollection form, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //参数查询模型
            CommonService.Model.C_Parameters parConditon = new CommonService.Model.C_Parameters();

            if (!String.IsNullOrEmpty(form["C_Parameters_name"]))
            {//参数名称查询条件
                parConditon.C_Parameters_name = form["C_Parameters_name"].Trim(); ;
            }

            //参数查询模型传递到前端视图中
            ViewBag.ParConditon = parConditon;

            #endregion

            //获取参数总记录数
            this.TotalRecordCount = _parametersWCF.GetRecordCount(parConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Parameters> parameters = _parametersWCF.GetListByPage(parConditon, "C_Parameters_parent Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(parameters);
        }

        /// <summary>
        /// 单选一级参数Action
        /// </summary>
        /// <param name="form"></param>
        /// <param name="relationCode">关联Guid</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SingleFirstLevelRefList(FormCollection form, string relationCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //参数查询模型
            CommonService.Model.C_Parameters parConditon = new CommonService.Model.C_Parameters();

            if (!String.IsNullOrEmpty(form["C_Parameters_name"]))
            {//参数名称查询条件
                parConditon.C_Parameters_name = form["C_Parameters_name"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["RelationCode"]))
            {//参数名称查询条件
                relationCode = form["RelationCode"].Trim(); ;
            }
            this.AddressUrlParameters = "?relationCode=" + relationCode;
            parConditon.C_Parameters_parent = 0;

            //参数查询模型传递到前端视图中
            ViewBag.ParConditon = parConditon;
            ViewBag.RelationCode = relationCode;

            #endregion

            this.PageSize = 11;

            //获取参数总记录数
            this.TotalRecordCount = _parametersWCF.GetRecordCount(parConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.C_Parameters> parameters = _parametersWCF.GetListByPage(parConditon, "C_Parameters_order Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(parameters);
        }

        /// <summary>
        /// 确认关联参数
        /// </summary>
        /// <param name="relationCode">关联Guid</param>
        /// <returns></returns>
        public ActionResult RelationParameter(int parametersId, string relationCode)
        {
            /***
             * hety,2015-05-14
             * 业务说明：自定义表单属性设置(UI控件关联了参数表)
             * ***/
            bool isSuccess = false;
            CommonService.Model.CustomerForm.F_FormProperty formProperty = _formPropertyWCF.Get(new Guid(relationCode));
            if (formProperty != null)
            {
                formProperty.F_FormProperty_dataSource_type = Convert.ToInt32(CustomerFormDataSourceType.参数表);
                formProperty.F_FormProperty_dataSource = "C_Parameters";
                formProperty.F_FormProperty_dataSource_mappingField = "C_Parameters_id";
                formProperty.F_FormProperty_dataSource_mappingFieldName = "C_Parameters_name";
                formProperty.F_FormProperty_dataSource_conditionField = "C_Parameters_parent";
                formProperty.F_FormProperty_dataSource_conditionValue = parametersId.ToString();
                formProperty.F_FormProperty_dataSource_conditionType = Convert.ToInt32(ConditonType.等于);

                isSuccess = _formPropertyWCF.Update(formProperty);
            }

            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("关联选中参数成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("关联选中参数失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.C_Parameters parameters)
        {
            //服务方法调用
            int parametersId = 0;

            if (parameters.C_Parameters_id > 0)
            {//修改
                bool isUpdateSuccess = _parametersWCF.Update(parameters);
                if (isUpdateSuccess)
                {
                    parametersId = parameters.C_Parameters_id;
                }
            }
            else
            {//添加
                parametersId = _parametersWCF.Add(parameters);
            }

            if (parametersId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存参数信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存参数信息成功", "/basedata/parameters/create?parametersID=" + parameters.C_Parameters_parent, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存参数信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存参数信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int parametersID)
        {
            bool isSuccess = _parametersWCF.Delete(parametersID);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除参数信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除参数信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        #region 自定义表单所用

        /// <summary>
        /// 多选回调参数列表(自定义表单调用)
        /// </summary>
        /// <param name="form">查询表单</param>
        /// <param name="lookupgroup">多选弹出分组</param>
        /// <param name="propertyValueCode">表单属性值Guid</param>
        /// <param name="mappingField">映射字段(这个字段值要保存到属性值表中"值字段")</param>
        /// <param name="mappingFieldName">映射字段显示字段(只用来做界面显示)</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ActionResult MulityCallbackRefList_ParametersForm(FormCollection form, string lookupgroup, string propertyValueCode, string mappingField, string mappingFieldName, string V_formpropertyvalue_value, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //参数查询模型
            CommonService.Model.C_Parameters parameterConditon = new CommonService.Model.C_Parameters();

            if (!String.IsNullOrEmpty(form["C_Parameters_name"]))
            {//参数名称查询条件
                parameterConditon.C_Parameters_name = form["C_Parameters_name"].Trim(); ;
            }
            if (!String.IsNullOrEmpty(form["C_Parameters_parent"]))
            {//父亲参数Guid
                parameterConditon.C_Parameters_parent = Convert.ToInt32(form["C_Parameters_parent"]);
            }
            if (Request.QueryString["C_Parameters_parent"] != null)
            {
                parameterConditon.C_Parameters_parent = int.Parse(Request.QueryString["C_Parameters_parent"]);
            }
            if (parameterConditon.C_Parameters_parent != null)
            {//附加Request条件
                this.AddressUrlParameters = "?C_Parameters_parent=" + parameterConditon.C_Parameters_parent;
            }
            if (!String.IsNullOrEmpty(form["V_formpropertyvalue_value"]))
            {
                ViewBag.V_formpropertyvalue_value = form["V_formpropertyvalue_value"];
                this.AddressUrlParameters = this.AddressUrlParameters + "&V_formpropertyvalue_value=" + form["V_formpropertyvalue_value"];
            }
            if (Request.QueryString["V_formpropertyvalue_value"] != null)
            {
                ViewBag.V_formpropertyvalue_value = Request.QueryString["V_formpropertyvalue_value"];
                this.AddressUrlParameters = this.AddressUrlParameters + "&V_formpropertyvalue_value=" + Request.QueryString["V_formpropertyvalue_value"];
            }
            else
            {
                this.AddressUrlParameters = this.AddressUrlParameters + "&V_formpropertyvalue_value=" + V_formpropertyvalue_value;
                ViewBag.V_formpropertyvalue_value = V_formpropertyvalue_value;
            }

            //参数查询模型传递到前端视图中
            ViewBag.ParameterConditon = parameterConditon;
            this.PageSize = 8;

            #endregion


            #region 参照配置条件
            string _lookupgroup = String.Empty;
            string _propertyValueCode = String.Empty;
            string _mappingField = String.Empty;
            string _mappingFieldName = String.Empty;

            if (!String.IsNullOrEmpty(form["lookupgroup"]))
            {
                _lookupgroup = form["lookupgroup"];
            }
            if (!String.IsNullOrEmpty(form["propertyValueCode"]))
            {
                _propertyValueCode = form["propertyValueCode"];
            }
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


            this.AddressUrlParameters = this.AddressUrlParameters + "&lookupgroup=" + _lookupgroup;//加入地址栏条件
            this.AddressUrlParameters = this.AddressUrlParameters + "&propertyValueCode=" + _propertyValueCode;

            #endregion

            //获取参数总记录数
            this.TotalRecordCount = _parametersWCF.GetRecordCount(parameterConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取参数数据信息
            List<CommonService.Model.C_Parameters> customers = _parametersWCF.GetListByPage(parameterConditon, "C_Parameters_order Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(customers);
        }

        #endregion

        public ActionResult Test()
        {
            return View();
        }
    }
}