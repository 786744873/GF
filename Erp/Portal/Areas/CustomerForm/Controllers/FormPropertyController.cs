using CommonService.Common;
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
    /// 表单属性控制器
    /// </summary>
    public class FormPropertyController : BaseController
    {
        private readonly ICommonService.CustomerForm.IF_FormProperty _formPropertyWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;

        public FormPropertyController()
        {
            #region 服务初始化
            _formPropertyWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormProperty>("FormPropertyWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }

        //
        // GET: /CustomerForm/FormProperty/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string formCode, string parentPropertyCode)
        {
            InitializationPageParameter();
            //创建初始化实体
            CommonService.Model.CustomerForm.F_FormProperty formProperty = new CommonService.Model.CustomerForm.F_FormProperty();
            formProperty.F_FormProperty_code = Guid.NewGuid();
            if (!String.IsNullOrEmpty(formCode))
            {
                formProperty.F_FormProperty_form = new Guid(formCode);
            }
            if (String.IsNullOrEmpty(parentPropertyCode))
            {
                formProperty.F_FormProperty_parent = Guid.Empty;
            }
            else
            {
                formProperty.F_FormProperty_parent = new Guid(parentPropertyCode);
            }            
            formProperty.F_FormProperty_fieldName = "";
            formProperty.F_FormProperty_fieldLength = 20;
            formProperty.F_FormProperty_isRequire = false;
            formProperty.F_FormProperty_isShow = true;
            formProperty.F_FormProperty_isOnlyRead = false;
            formProperty.F_FormProperty_isBase = false;
            formProperty.F_FormProperty_isDelete = false;
            formProperty.F_FormProperty_isSum = false;
            formProperty.F_FormProperty_isShowInHistory = true;
            formProperty.F_FormProperty_triggerEvent_Type = Convert.ToInt32(TriggerEventTypeEnum.无事件);
            formProperty.F_FormProperty_creator = Context.UIContext.Current.UserCode;
            formProperty.F_FormProperty_createTime = DateTime.Now;

            return View(formProperty);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="formPropertyCode"></param>
        /// <returns></returns>
        public ActionResult Edit(string formPropertyCode)
        {
            InitializationPageParameter();
            CommonService.Model.CustomerForm.F_FormProperty formProperty = _formPropertyWCF.Get(new Guid(formPropertyCode));
            return View("Create", formProperty);
        }

        /// <summary>
        /// 向前移动表单属性Action
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MoveForward(string formCode, string formPropertyCode)
        {
            bool isSuccess = _formPropertyWCF.MoveForward(new Guid(formCode), new Guid(formPropertyCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("上移属性成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("上移属性失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 向后移动表单属性Action
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MoveBackward(string formCode, string formPropertyCode)
        {
            bool isSuccess = _formPropertyWCF.MoveBackward(new Guid(formCode), new Guid(formPropertyCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("下移属性成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("下移属性失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="formPropertyCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string formPropertyCode)
        {
            bool isSuccess = _formPropertyWCF.Delete(new Guid(formPropertyCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除表单属性成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除表单属性失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="formProperty"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.CustomerForm.F_FormProperty formProperty)
        {
            //去掉字段值前后可能存在的空格
            formProperty.F_FormProperty_fieldName = formProperty.F_FormProperty_fieldName.Trim();
            //服务方法调用
            int formPropertyId = 0;

            if (formProperty.F_FormProperty_fieldName.Contains("_"))
            {
                return Json(TipHelper.JsonData("您输入的字段名称中</br>不可以包括\"_\"(下划线)", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

            if (formProperty.F_FormProperty_id > 0)
            {//修改
                bool isUpdateSuccess = false;
                if (_formPropertyWCF.ExistsFieldNameByFormCodeAndPropertyCode(formProperty.F_FormProperty_fieldName, formProperty.F_FormProperty_form.Value, formProperty.F_FormProperty_code.Value))
                {
                    return Json(TipHelper.JsonData("您输入的字段名称重复", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                else
                {
                    isUpdateSuccess = _formPropertyWCF.Update(formProperty);
                }               
                if (isUpdateSuccess)
                {
                    formPropertyId = formProperty.F_FormProperty_id;
                }
            }
            else
            {//添加
                if (_formPropertyWCF.ExistsFieldNameByFormCode(formProperty.F_FormProperty_fieldName, formProperty.F_FormProperty_form.Value))
                {
                    return Json(TipHelper.JsonData("您输入的字段名称重复", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                else
                {
                    formProperty.F_FormProperty_createTime = DateTime.Now;
                    formPropertyId = _formPropertyWCF.Add(formProperty);
                }
            }

            if (formPropertyId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存表单属性信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存表单属性信息成功", "/customerform/formproperty/create?formCode="+formProperty.F_FormProperty_form, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存表单属性信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存表单属性失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form,string formCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.CustomerForm.F_FormProperty formPropertyConditon = new CommonService.Model.CustomerForm.F_FormProperty();

            if (!String.IsNullOrEmpty(form["F_FormProperty_showName"]))
            {//名称查询条件
                formPropertyConditon.F_FormProperty_showName = form["F_FormProperty_showName"].Trim();
            }
            if (!String.IsNullOrEmpty(form["F_FormProperty_form"]))
            {//表单Guid
                formPropertyConditon.F_FormProperty_form = new Guid(form["F_FormProperty_form"].Trim());
            }
            if (!String.IsNullOrEmpty(formCode))
            {
                formPropertyConditon.F_FormProperty_form = new Guid(formCode);
            }
            this.AddressUrlParameters = "?formCode=" + formPropertyConditon.F_FormProperty_form;
            this.PageSize = 12;

            //查询模型传递到前端视图中
            ViewBag.FormPropertyConditon = formPropertyConditon;

            #endregion

            //获取总记录数
            this.TotalRecordCount = _formPropertyWCF.GetRecordCount(formPropertyConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = _formPropertyWCF.GetListByPage(formPropertyConditon,
                "F_FormProperty_orderBy Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(formPropertys);
        }

        /// <summary>
        /// 子列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="parentPropertyCode">父表单属性Guid</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult ChildrenList(FormCollection form, string formCode,string parentPropertyCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.CustomerForm.F_FormProperty formPropertyConditon = new CommonService.Model.CustomerForm.F_FormProperty();

            if (!String.IsNullOrEmpty(form["F_FormProperty_showName"]))
            {//名称查询条件
                formPropertyConditon.F_FormProperty_showName = form["F_FormProperty_showName"].Trim();
            }
            if (!String.IsNullOrEmpty(form["F_FormProperty_form"]))
            {//表单Guid
                formPropertyConditon.F_FormProperty_form = new Guid(form["F_FormProperty_form"].Trim());
            }
            if (!String.IsNullOrEmpty(formCode))
            {
                formPropertyConditon.F_FormProperty_form = new Guid(formCode);
            }
            if (!String.IsNullOrEmpty(form["F_FormProperty_parent"]))
            {//父亲属性Guid
                formPropertyConditon.F_FormProperty_parent = new Guid(form["F_FormProperty_parent"].Trim());
            }
            if (!String.IsNullOrEmpty(parentPropertyCode))
            {
                formPropertyConditon.F_FormProperty_parent = new Guid(parentPropertyCode);
            }

            this.AddressUrlParameters = "?formCode=" + formPropertyConditon.F_FormProperty_form + "&parentPropertyCode=" + formPropertyConditon.F_FormProperty_parent;
            this.PageSize = 12;

            //查询模型传递到前端视图中
            ViewBag.FormPropertyConditon = formPropertyConditon;

            #endregion

            //获取总记录数
            this.TotalRecordCount = _formPropertyWCF.GetRecordCount(formPropertyConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = _formPropertyWCF.GetListByPage(formPropertyConditon,
                "F_FormProperty_orderBy Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(formPropertys);
        }


        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //控件类型参数集合
            List<CommonService.Model.C_Parameters> UIControlTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(FormEnum.控件类型));
            ViewBag.UIControlTypes = UIControlTypes;
            //事件类型参数集合
            List<CommonService.Model.C_Parameters> TriggerEventTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.触发事件类型));
            ViewBag.TriggerEventTypes = TriggerEventTypes;
        }

	}
}