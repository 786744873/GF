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
    /// 表单控制器
    /// </summary>
    public class FormController : BaseController
    {
        private readonly ICommonService.CustomerForm.IF_Form _formWCF;
        private readonly ICommonService.FlowManager.IP_Flow_form _flowformWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;

        public FormController()
        {
            #region 服务初始化
            _formWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_Form>("FormWCF");
            _flowformWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow_form>("Flow_formWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }

        //
        // GET: /CustomerForm/Form/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            this.InitializationPageParameter();
            //创建初始化实体
            CommonService.Model.CustomerForm.F_Form form = new CommonService.Model.CustomerForm.F_Form();

            form.F_Form_code = Guid.NewGuid();
            form.F_Form_isDelete = false;
            form.F_Form_creator = Context.UIContext.Current.UserCode;
            form.F_Form_type = Convert.ToInt32(FormTypeEnum.案件表单);
            form.F_Form_createTime = DateTime.Now;

            return View(form);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="formCode"></param>
        /// <returns></returns>
        public ActionResult Edit(string formCode)
        {
            this.InitializationPageParameter();
            CommonService.Model.CustomerForm.F_Form form = _formWCF.Get(new Guid(formCode));
            return View("Create", form);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.CustomerForm.F_Form fform)
        {
            //去掉标识值前后可能存在的空格
            fform.F_Form_englishName = fform.F_Form_englishName.Trim();
            //服务方法调用
            int formId = 0;

            if (fform.F_Form_id > 0)
            {//修改
                bool isUpdateSuccess = _formWCF.Update(fform);
                if (isUpdateSuccess)
                {
                    formId = fform.F_Form_id;
                }
            }
            else
            {//添加
                if (_formWCF.ExistsFormIdentification(fform.F_Form_englishName))
                {                  
                    return Json(TipHelper.JsonData("您输入的字母标识重复", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));                  
                }
                else
                {
                    fform.F_Form_createTime = DateTime.Now;
                    formId = _formWCF.Add(fform);
                }                
            }

            if (formId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存表单信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存表单信息成功", "/customerform/form/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存表单信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存表单信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="formCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string formCode)
        {
            bool isSuccess = _formWCF.Delete(new Guid(formCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除表单信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除表单信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }


        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, int? page = 1)
        {
            this.InitializationPageParameter();

            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.CustomerForm.F_Form formConditon = new CommonService.Model.CustomerForm.F_Form();

            if (!String.IsNullOrEmpty(form["F_Form_chineseName"]))
            {//名称查询条件
                formConditon.F_Form_chineseName = form["F_Form_chineseName"].Trim(); ;
            }

            //查询模型传递到前端视图中
            ViewBag.FormConditon = formConditon;

            #endregion

            //获取总记录数
            this.TotalRecordCount = _formWCF.GetRecordCount(formConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.CustomerForm.F_Form> forms = _formWCF.GetListByPage(formConditon,
                "F_Form_createTime Desc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(forms);
        }

        /// <summary>
        /// 表单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult FlowRelationFormList(int? FlowType)
        {
            //获取数据信息
            List<CommonService.Model.CustomerForm.F_Form> forms = _formWCF.GetAllListByFlowType(Convert.ToInt32(FlowType));
            
            return View(forms);
        }

        /// <summary>
        /// 关联表单添加
        /// </summary>
        /// <returns></returns>
        public ActionResult RelationContact(string flowCode, string formCodes)
        {
            bool isSuccess = false;

            List<CommonService.Model.FlowManager.P_Flow_form> flowForms = new List<CommonService.Model.FlowManager.P_Flow_form>();

            if (flowCode != "" && formCodes!="")
            {//关联流程
                string[] form_codes = formCodes.Split(',');
                foreach(var formCode in form_codes)
                {
                    CommonService.Model.FlowManager.P_Flow_form flowForm = new CommonService.Model.FlowManager.P_Flow_form();
                    flowForm.P_Flow_code = new Guid(flowCode);
                    flowForm.F_Form_code = new Guid(formCode);
                    flowForm.P_Flow_form_creator = Context.UIContext.Current.UserCode;
                    flowForm.P_Flow_form_createTime = DateTime.Now;
                    flowForm.P_Flow_form_isDelete = 0;
                    flowForm.P_Flow_form_isDefault = 1;
                    flowForms.Add(flowForm);
                }                
            }

            isSuccess = _flowformWCF.OpreateList(flowForms);

            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("关联表单信息成功！", "iframe_businessFlowForm", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("关联表单信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //表单类型参数集合
            List<CommonService.Model.C_Parameters> FormTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(FormEnum.表单类型));
            ViewBag.FormTypes = FormTypes;
        }

	}
}