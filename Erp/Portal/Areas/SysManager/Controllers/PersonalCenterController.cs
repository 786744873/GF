using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.SysManager.Controllers
{
    public class PersonalCenterController : BaseController
    {
        //
        // GET: /SysManager/PersonalCenter/
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.Feedback.IC_Feedback _feedbackWCF;
        public PersonalCenterController()
        {
            #region 服务初始化
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _feedbackWCF = ServiceProxyFactory.Create<ICommonService.Feedback.IC_Feedback>("FeedbackWCF");
            #endregion
        }
        public ActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// 页面布局
        /// </summary>
        /// <returns></returns>
        public ActionResult DefaultLayout()
        {
            return View();
        }

        /// <summary>
        /// 基本设置
        /// </summary>
        /// <returns></returns>
        public ActionResult BasicSettings()
        {
            string userCode = Context.UIContext.Current.RootUserCode.ToString();
            CommonService.Model.SysManager.C_Userinfo userinfo = _userinfoWCF.GetModelByUserCode(new Guid(userCode));
            List<CommonService.Model.Feedback.C_Feedback> feedbackList = new List<CommonService.Model.Feedback.C_Feedback>();
            if(Context.UIContext.Current.IsPreSetManager)
            {
                feedbackList = _feedbackWCF.GetAllList();
            }else
            {
                feedbackList = _feedbackWCF.GetListByApplicant(userinfo.C_Userinfo_code.Value);
            }
            ViewBag.feedbackList = feedbackList;
            int AdoptCount = 0;
            int Integral = 0;
            foreach (CommonService.Model.Feedback.C_Feedback feedback in feedbackList)
            {
                if(feedback.C_Feedback_state==Convert.ToInt32(FeedbackStateEnum.已采纳))
                {
                    AdoptCount++;
                }
                Integral = Integral + Convert.ToInt32(feedback.C_Feedback_Integral);
            }
            ViewBag.AdoptCount = AdoptCount;
            ViewBag.Integral = Integral;
            ViewBag.FeedbackCount = feedbackList.Count();
            return View(userinfo);
        }


        /// <summary>
        /// 页面初始
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            string username = Context.UIContext.Current.RootUserCode.ToString();
            CommonService.Model.SysManager.C_Userinfo userinfo = _userinfoWCF.GetModelByUserCode(new Guid(username));
            return View(userinfo);
        }

        /// <summary>
        /// 修改资料
        /// </summary>
        /// <returns></returns>
        public ActionResult ModifyingData()
        {
            string username = Context.UIContext.Current.RootUserCode.ToString();
            CommonService.Model.SysManager.C_Userinfo userinfo = _userinfoWCF.GetModelByUserCode(new Guid(username));
            return View(userinfo);
        }

        /// <summary>
        /// 处理修改密码事件
        /// </summary>
        /// <param name="form"></param>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.SysManager.C_Userinfo userinfo)
        {
            string newpassword = form["newpass"];
            string surenewpass = form["surenewpass"];
            string oldpass = form["oldpass"];
            if (string.IsNullOrEmpty(oldpass) || string.IsNullOrEmpty(newpassword) || string.IsNullOrEmpty(surenewpass))
            {
                return Json(TipHelper.JsonData("请完善信息！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            else
            {
                string oldmd5 = Encryption.GetMd5("" + oldpass + "");
                if (oldmd5.Equals(userinfo.C_Userinfo_password))
                {
                    if (newpassword.Equals(surenewpass))
                    {
                        userinfo.C_Userinfo_password = Encryption.GetMd5("" + newpassword + "");
                        if (_userinfoWCF.UpdatePass(userinfo))
                        {
                            return Json(TipHelper.JsonData("修改密码成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
                        }
                        else
                            return Json(TipHelper.JsonData("修改密码失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));

                    }
                    else
                    {
                        return Json(TipHelper.JsonData("新密码不一致！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                    }
                }
                else
                {
                    return Json(TipHelper.JsonData("旧密码输入错误！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
            return View();
        }

        /// <summary>
        /// 保存资料
        /// </summary>
        /// <param name="form"></param>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveData(FormCollection form, CommonService.Model.SysManager.C_Userinfo userinfo)
        {
            if (_userinfoWCF.Update(userinfo))
            {
                return Json(TipHelper.JsonData("修改资料成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
                return Json(TipHelper.JsonData("修改资料失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
        }
    }
}