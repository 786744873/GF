using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context;

namespace Portal.Areas.BusinessChanceManager.Controllers
{
    /// <summary>
    /// 商机交单控制器
    /// </summary>
    public class ChanceCrossFormController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance _businessChanceWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance_link _businessChance_linkWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance_check _businessChance_checkWCF;

        public ChanceCrossFormController()
        {
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _businessChanceWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance>("BusinessChanceWCF");
            _businessChance_linkWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance_link>("BusinessChance_linkWCF");
            _businessChance_checkWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance_check>("B_BusinessChance_checkWCF");
        }

        //
        // GET: /BusinessChanceManager/ChanceCrossForm/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 提交审查
        /// </summary>
        /// <param name="fkCode">商机Guid</param>
        /// <returns></returns>
        public ActionResult SubmitCheck(string fkCode)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(fkCode));
            if (businessChance == null)
            {
                return Json(TipHelper.JsonData("此商机已被删除！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> BusinessChanceLinks = _businessChance_linkWCF.GetBusinessChanceAllLinks(new Guid(fkCode));

            if (BusinessChanceLinks.Where(p => p.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.客户)).Count() == 0)
            {
                return Json(TipHelper.JsonData("商机基本信息中的客户不能为空</br>请填写后再进行提交！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (BusinessChanceLinks.Where(p => p.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.委托人)).Count() == 0)
            {
                return Json(TipHelper.JsonData("商机基本信息中的委托人不能为空</br>请填写后再进行提交！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (BusinessChanceLinks.Where(p => p.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.对方当事人个人)).Count() == 0 && BusinessChanceLinks.Where(p => p.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.对方当事人公司)).Count() == 0)
            {
                return Json(TipHelper.JsonData("商机基本信息中的对方当事人不能为空</br>请填写后再进行提交！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (BusinessChanceLinks.Where(p => p.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.区域)).Count() == 0)
            {
                return Json(TipHelper.JsonData("商机基本信息中的所属区域不能为空</br>请填写后再进行提交！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (businessChance.B_BusinessChance_Case_nature==null)
            {
                return Json(TipHelper.JsonData("商机基本信息中的案件性质不能为空</br>请填写后再进行提交！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            //if (String.IsNullOrEmpty(businessChance.B_BusinessChance_number))
            //{
            //    return Json(TipHelper.JsonData("商机基本信息中的商机编码不能为空</br>请填写后再进行提交！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            //}
            if (BusinessChanceLinks.Where(p => p.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.工程)).Count() == 0)
            {
                return Json(TipHelper.JsonData("商机基本信息中的工程不能为空</br>请填写后再进行提交！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (BusinessChanceLinks.Where(p => p.B_BusinessChance_link_type == Convert.ToInt32(BusinessChancelinkEnum.销售顾问)).Count() == 0)
            {
                return Json(TipHelper.JsonData("商机基本信息中的销售顾问不能为空</br>请填写后再进行提交！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (businessChance.B_BusinessChance_registerTime == null)
            {
                return Json(TipHelper.JsonData("商机基本信息中的预收案时间不能为空</br>请填写后再进行提交！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (businessChance.B_BusinessChance_customerType == null)
            {
                return Json(TipHelper.JsonData("商机基本信息中的客户类型不能为空</br>请填写后再进行提交！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

            //提交商机审查
            bool isSuccess = _businessChance_checkWCF.SubmitCheck(new Guid(fkCode), UIContext.Current.UserCode.Value);

            if (isSuccess)
            {
                return Json(TipHelper.JsonData("提交商机审查信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {
                return Json(TipHelper.JsonData("提交商机审查信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }            
        }

        /// <summary>
        /// 部长商机审查视图
        /// </summary>
        /// <param name="fkCode">商机Guid</param>
        /// <returns></returns>
        public ActionResult MinisterCheck(string fkCode)
        {
            this.InitializationPageParameter();           
            CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessChanceCheck = _businessChance_checkWCF.GetUnCheckedChanceCheck(new Guid(fkCode), Convert.ToInt32(BusinessChanceCheckPersonTypeEnum.部长)); 
            return View(businessChanceCheck);
        }

        /// <summary>
        /// 提交部长商机审查(部长确认审查)
        /// </summary>
        /// <param name="businessCheck">商机审查数据模型</param>
        /// <param name="form">表单</param>
        /// <returns></returns>
        public ActionResult SubmitMinisterCheck(CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessCheck,FormCollection form)
        {
            businessCheck.B_BusinessChance_check_checkPerson = UIContext.Current.UserCode;
            businessCheck.B_BusinessChance_check_checkTime = DateTime.Now;
            businessCheck.B_BusinessChance_check_isChecked = true;

            if (businessCheck.B_BusinessChance_check_checkType == Convert.ToInt32(BusinessChanceCheckOpinionTypeEnum.通过))
            {
                businessCheck.B_BusinessChance_check_Nature = Convert.ToInt32(form["nature"].ToString());
            }
            else
            {
                businessCheck.B_BusinessChance_check_Nature = null;
                businessCheck.B_BusinessChance_check_planStartTime = null;
                businessCheck.B_BusinessChance_check_planEndTime = null;               
            }

            bool flag = _businessChance_checkWCF.SubmitMinisterCheck(businessCheck);

            if (flag)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("确认审查成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("确认审查失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 首席商机审查视图
        /// </summary>
        /// <param name="fkCode">商机Guid</param>
        /// <returns></returns>
        public ActionResult ChiefCheck(string fkCode)
        {
            /**
             * author:hety
             * date:2015-11-04
             * description:只有部长通过商机审查时，首席才会看到
             ***/

            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(fkCode));

            this.InitializationPageParameter();
            //首席需要审查的数据模型
            CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessChanceCheck = _businessChance_checkWCF.GetUnCheckedChanceCheck(new Guid(fkCode), Convert.ToInt32(BusinessChanceCheckPersonTypeEnum.首席));
            //最近一次部长一审查的数据模型
            CommonService.Model.BusinessChanceManager.B_BusinessChance_check latestChanceCheck = _businessChance_checkWCF.GetLatestChanceCheck(new Guid(fkCode), Convert.ToInt32(BusinessChanceCheckPersonTypeEnum.部长));
            //首席数据模型赋值最近一次部长一审查的数据模型值
            businessChanceCheck.B_BusinessChance_check_checkType = latestChanceCheck.B_BusinessChance_check_checkType;
            if (businessChance != null && businessChance.B_BusinessChance_person != null)
            {//确认部长，默认赋商机部长
                businessChanceCheck.B_BusinessChance_check_confirmPerson = businessChance.B_BusinessChance_person;
            }            
            businessChanceCheck.B_BusinessChance_check_planStartTime = latestChanceCheck.B_BusinessChance_check_planStartTime;
            businessChanceCheck.B_BusinessChance_check_planEndTime = latestChanceCheck.B_BusinessChance_check_planEndTime;
            businessChanceCheck.B_BusinessChance_check_Nature = latestChanceCheck.B_BusinessChance_check_Nature;
            businessChanceCheck.B_BusinessChance_check_category = Convert.ToInt32(CaseCategoryEnum.指挥级);

            this.SetChiefs();
            ViewBag.LatestChanceCheck = latestChanceCheck;

            return View(businessChanceCheck);
        }

        /// <summary>
        /// 提交首席商机审查(首席确认审查)
        /// </summary>
        /// <param name="businessCheck">首席审查数据模型</param>
        /// <param name="form">表单</param>
        /// <returns></returns>
        public ActionResult SubmitChiefCheck(CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessCheck, FormCollection form)
        {
            businessCheck.B_BusinessChance_check_checkPerson = UIContext.Current.UserCode;
            businessCheck.B_BusinessChance_check_checkTime = DateTime.Now;
            businessCheck.B_BusinessChance_check_isChecked = true;

            if (businessCheck.B_BusinessChance_check_checkType == Convert.ToInt32(BusinessChanceCheckOpinionTypeEnum.通过))
            {
                if (businessCheck.B_BusinessChance_check_Nature != Convert.ToInt32(CaseNatureEnum.类型案件))
                {
                    businessCheck.B_BusinessChance_check_category = null;
                }
            }
            else
            {
                businessCheck.B_BusinessChance_check_Nature = null;
                businessCheck.B_BusinessChance_check_category = null;
                businessCheck.B_BusinessChance_check_planStartTime = null;
                businessCheck.B_BusinessChance_check_planEndTime = null;
                businessCheck.B_BusinessChance_check_confirmPerson = null;
            }

            bool flag = _businessChance_checkWCF.SubmitChiefCheck(businessCheck);

            if (flag)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("确认审查成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("确认审查失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 查看商机审查历史记录
        /// </summary>
        /// <param name="fkCode">商机Guid</param>
        /// <returns></returns>
        public ActionResult HistoryCheck(string fkCode)
        {
            List<CommonService.Model.BusinessChanceManager.B_BusinessChance_check> businessChanceChecks = _businessChance_checkWCF.GetChekedBusinessChanceChecks(new Guid(fkCode));
            return View(businessChanceChecks);
        }

        /// <summary>
        /// 设置所有部长
        /// </summary>
        private void SetChiefs()
        {
            List<CommonService.Model.SysManager.C_Userinfo> Chiefs = _userinfoWCF.GetAllChildList(1);
            ViewBag.Chiefs = Chiefs;
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //商机审查意见类型参数集合
            List<CommonService.Model.C_Parameters> CheckOpinionTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(BusinessChanceEnum.商机审查意见类型));
            ViewBag.CheckOpinionTypes = CheckOpinionTypes;
 
        }

	}
}