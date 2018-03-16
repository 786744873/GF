using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BusinessChanceManager.Controllers
{
    /// <summary>
    /// 商机计划Control
    /// </summary>
    public class ChancePlanController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance _businessChanceWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance_link _businessChance_linkWCF;

        public ChancePlanController()
        {
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _businessChanceWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance>("BusinessChanceWCF");
            _businessChance_linkWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance_link>("BusinessChance_linkWCF");
        }

        //
        // GET: /BusinessChanceManager/ChancePlan/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 显示设置商机计划
        /// </summary>
        /// <param name="fkType">流程类型(只为商机)</param>
        /// <param name="pkCode">商机Guid</param>
        /// <returns></returns>
        public ActionResult ShowSetChangePlan(string fkType, string pkCode)
        {
            //专家部长
            List<CommonService.Model.SysManager.C_Userinfo> users = _userinfoWCF.GetAllChildList(1);
            ViewBag.users = users;
            //首席
            List<CommonService.Model.SysManager.C_Userinfo> firstUsers = _userinfoWCF.GetAllChildList(2);
            ViewBag.firstUsers = firstUsers;

            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(pkCode));

            #region 是否显示"保存"按钮(商机负责人或者一级负责人或专业顾问或内置系统管理员有此按钮权限)
            bool isShowSaveBtn = false;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                isShowSaveBtn = true;
            }
            else
            {
                if (businessChance.B_BusinessChance_person != null)
                {//商机负责人
                    if (businessChance.B_BusinessChance_person == Context.UIContext.Current.UserCode)
                    {
                        isShowSaveBtn = true;
                    }
                }
                if (businessChance.B_BusinessChance_firstClassResponsiblePerson != null)
                {//一级负责人
                    if (businessChance.B_BusinessChance_firstClassResponsiblePerson == Context.UIContext.Current.UserCode)
                    {
                        isShowSaveBtn = true;
                    }
                }
                if (!isShowSaveBtn)
                {//专业顾问
                    List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> businessChanceLinks = _businessChance_linkWCF.GetBusinessChanceLinks(new Guid(pkCode), 5);
                    if (businessChanceLinks.Where(p => p.C_FK_code == Context.UIContext.Current.UserCode).Count() != 0)
                    {
                        isShowSaveBtn = true;
                    }
                }

            }
            ViewBag.IsShowSaveBtn = isShowSaveBtn;
            #endregion

            #region 一级负责人或内置系统管理员，拥有所有修改页面数据的权限；而二级负责人或专业顾问，只可以修改计划时间
            int editPagePropertyType = 0;//修改页面元素类型
            if (Context.UIContext.Current.IsPreSetManager)
            {
                editPagePropertyType = 1;//代表修改所有元素
            }
            else
            {
                if (businessChance.B_BusinessChance_person != null)
                {//二级负责人
                    if (businessChance.B_BusinessChance_person == Context.UIContext.Current.UserCode)
                    {
                        editPagePropertyType = 2;//只可修改计划时间
                    }
                }

                if (editPagePropertyType != 2)
                {//专业顾问
                    List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> businessChanceLinks = _businessChance_linkWCF.GetBusinessChanceLinks(new Guid(pkCode), 5);
                    if (businessChanceLinks.Where(p => p.C_FK_code == Context.UIContext.Current.UserCode).Count() != 0)
                    {
                        editPagePropertyType = 2;//只可修改计划时间
                    }
                }

                if (businessChance.B_BusinessChance_firstClassResponsiblePerson != null)
                {//一级负责人
                    if (businessChance.B_BusinessChance_firstClassResponsiblePerson == Context.UIContext.Current.UserCode)
                    {
                        editPagePropertyType = 1;//代表修改所有元素
                    }
                }
            }
            ViewBag.EditPagePropertyType = editPagePropertyType;
            #endregion

            return View("SetChangePlan", businessChance);
        }

        /// <summary>
        /// 设置商机计划
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetChangePlan(FormCollection form, CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance)
        {
            if (DateTime.Compare(businessChance.B_BusinessChance_planStartTime.Value, businessChance.B_BusinessChance_planEndTime.Value) < 0)
            {
                if (form["B_BusinessChance_firstClassResponsiblePerson"] != "请选择")
                {
                    businessChance.B_BusinessChance_firstClassResponsiblePerson = new Guid(form["B_BusinessChance_firstClassResponsiblePerson"]);
                }
                else
                {
                    businessChance.B_BusinessChance_firstClassResponsiblePerson = null;
                }
                if (form["B_BusinessChance_person"] != "请选择")
                {
                    businessChance.B_BusinessChance_person = new Guid(form["B_BusinessChance_person"]);
                }
                else
                {
                    businessChance.B_BusinessChance_person = null;
                }
                businessChance.B_BusinessChance_planStartTime = Convert.ToDateTime(form["B_BusinessChance_planStartTime"]);
                businessChance.B_BusinessChance_planEndTime = Convert.ToDateTime(form["B_BusinessChance_planEndTime"]);
                bool isUpdateSuccess = _businessChanceWCF.Update(businessChance);
                if (isUpdateSuccess)
                {
                    //保存成功提示固定写法
                    return Json(TipHelper.JsonData("设定计划信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));                   
                }
                else
                {
                    //保存失败固定写法
                    return Json(TipHelper.JsonData("设定计划信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ParentPage, OperateTypeAfterTip.NoAction));
                }
            }
            else
            {
                return Json(TipHelper.JsonData("计划开始时间不能大于计划结束时间！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ParentPage, OperateTypeAfterTip.NoAction));
            }
        }

	}
}