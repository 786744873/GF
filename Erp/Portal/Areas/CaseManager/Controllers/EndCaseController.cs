using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context;

namespace Portal.Areas.CaseManager.Controllers
{
    /// <summary>
    /// 结案控制器
    /// </summary>
    public class EndCaseController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.CaseManager.IB_Case_Confirm _caseConfirmWCF;
        private readonly ICommonService.CaseManager.IB_Case_Check _caseCheckWCF;

        public EndCaseController()
        {
            #region 服务初始化
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _caseConfirmWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_Confirm>("CaseConfirmWCF");
            _caseCheckWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_Check>("Case_CheckWCF");
            #endregion
        }

        //
        // GET: /CaseManager/EndCase/
        public override ActionResult Index()
        {
            return View();
        }

        public ActionResult Confirm(string fkCode, string businessFlowCode)
        {
            this.InitializationPageParameter();

            CommonService.Model.CaseManager.B_Case_Confirm caseConfirm = null;
            //先检查案件和业务流程关联的结案数据是否存在,不存在的时候才创建
            List<CommonService.Model.CaseManager.B_Case_Confirm> caseConfirms = 
                _caseConfirmWCF.GetListByCaseAndBusinessFlow(new Guid(fkCode), new Guid(businessFlowCode));

            if (caseConfirms.Count() != 0)
            {
                caseConfirm = caseConfirms.FirstOrDefault();
            }
            else
            {
                caseConfirm = new CommonService.Model.CaseManager.B_Case_Confirm();
                caseConfirm.B_Case_Confirm_isDelete = false;
                caseConfirm.B_Case_Confirm_code = Guid.NewGuid();
                caseConfirm.B_Case_code = new Guid(fkCode);
                caseConfirm.P_Business_Flow_code = new Guid(businessFlowCode);
                //caseConfirm.B_Case_Confirm_SuggestType = Convert.ToInt32(EndCaseSuggestEnum.结案);
            }
 
            return View(caseConfirm);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.CaseManager.B_Case_Confirm caseConfirm)
        {
            //服务方法调用
            int caseConfirmId = 0;

            if (caseConfirm.B_Case_Confirm_id > 0)
            {//修改
                bool isUpdateSuccess = _caseConfirmWCF.Update(caseConfirm);
                if (isUpdateSuccess)
                {
                    caseConfirmId = caseConfirm.B_Case_Confirm_id;
                }
            }
            else
            {//添加
                caseConfirm.B_Case_Confirm_createTime = DateTime.Now;
                caseConfirm.B_Case_Confirm_creator = UIContext.Current.UserCode;
                caseConfirmId = _caseConfirmWCF.Add(caseConfirm);
            }

            if (caseConfirmId > 0)
            {
                return Json(TipHelper.JsonData("结案确认成功", ""));//默认仅仅保存
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("结案确认失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="fkCode">案件Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public ActionResult Create(string fkCode, string businessFlowCode)
        {
            CommonService.Model.CaseManager.B_Case_Confirm caseConfirm = new CommonService.Model.CaseManager.B_Case_Confirm();
            
            caseConfirm.B_Case_Confirm_code = Guid.NewGuid();
            caseConfirm.B_Case_code = new Guid(fkCode);
            caseConfirm.P_Business_Flow_code = new Guid(businessFlowCode);
            caseConfirm.B_Case_Confirm_checkState = Convert.ToInt32(CaseConfirmStateEnum.在审核);
            caseConfirm.B_Case_Confirm_isDelete = false;
            return View(caseConfirm);
        }

        [HttpPost]
        public ActionResult SaveForm(FormCollection form, CommonService.Model.CaseManager.B_Case_Confirm caseConfirm)
        {
            //服务方法调用
            int caseConfirmId = 0;

            if (caseConfirm.B_Case_Confirm_id > 0)
            {//修改
                //bool isUpdateSuccess = _caseConfirmWCF.Update(caseConfirm);
                //if (isUpdateSuccess)
                //{
                //    caseConfirmId = caseConfirm.B_Case_Confirm_id;
                //}
            }
            else
            {//添加
                caseConfirm.B_Case_Confirm_createTime = DateTime.Now;
                caseConfirm.B_Case_Confirm_creator = UIContext.Current.UserCode;
                caseConfirmId = _caseConfirmWCF.Add(caseConfirm);
            }

            if (caseConfirmId > 0)
            {
                return Json(TipHelper.JsonData("提交结案成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("提交结案失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 结案确认
        /// </summary>
        /// <returns></returns>
        public ActionResult ConfirmCase(string B_Case_Confirm_Code)
        {
            List<CommonService.Model.CaseManager.B_Case_Check> caseCheckList = _caseCheckWCF.GetListByConfirmCode(new Guid(B_Case_Confirm_Code));
            CommonService.Model.CaseManager.B_Case_Confirm confirm = _caseConfirmWCF.GetModel(new Guid(B_Case_Confirm_Code));
            ViewBag.confirm = confirm;
            return View(caseCheckList);
        }

        [HttpPost]
        public ActionResult SaveCaseCheck(FormCollection form,CommonService.Model.CaseManager.B_Case_Check model)
        {
            //服务方法调用
            bool caseCheckId = false;
            string state = form["state"];
            model.B_Case_Check_State = Convert.ToInt32(state);
            model.B_Case_Check_checkTime = DateTime.Now;
            caseCheckId = _caseCheckWCF.Update(model);

            if (caseCheckId)
            {
                return Json(TipHelper.JsonData("结案确认成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("结案确认失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //结案意见参数集合
            List<CommonService.Model.C_Parameters> EndCaseSuggests = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.结案意见));
            ViewBag.EndCaseSuggests = EndCaseSuggests; 
        }

	}
}